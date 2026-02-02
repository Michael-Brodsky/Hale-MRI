Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports Newtonsoft.Json.Linq
Imports LibDatabase.StoredProcedures

''' <summary>
''' Form for Opening, Closing, Editing and Printing reports.
''' Manages database Report entities and serves as the 
''' palette for displaying report elements (controls).
''' NOTE:
'''     This form only manages itself and its own controls 
'''     (e.g. menus, form size) and maintains database
'''     currency with respect to report layouts. The visual
'''     report elements are managed by the ReportGenerator
'''     (e.g. control visibility, size, location, drag/drop
'''     and editing). This form should not modify any report
'''     controls, as this may cause unexpected behavior.
'''     
''' </summary>
Public Class FrmReports
    Inherits FrmDatabaseForm
#Region "Types abd Constants"
    Private Const kNewReportName As String = "*New Report*"
#End Region
#Region "Private Members"
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record
    Private mReport As Report = Nothing                     ' The current report.
    Private mReportGenerator As ReportGenerator = Nothing   ' The ReportGenerator for runtime report layout and formatting.
    Private mResizeToPagePounds As Boolean = False          ' Indicates whether this form is sized to the current printer page size.
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(ReportDataBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Sets or gets the database context for this form.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
    ''' </summary>
    ''' <returns></returns>
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            If mJobDetails IsNot Nothing Then
                ' This is the JobDetails and measurements data for the report.
                ReportDataBindingSource.DataSource = ReportDataLoad(mJobDetails)
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ReportsBindingSource.DataSource = Database.Reports.Local.ToBindingList()
        MasterSource = ReportDataBindingSource
        MyBase.BindDataSources()
    End Sub

    Private Sub ContextMenuOpening()
        ' Enable context menu items according the current report and edit state.
        If mReport Is Nothing Then
            For Each item As ToolStripItem In ReportContextMenuStrip.Items
                item.Enabled = False
            Next
        Else
            AddNewContextMenuItem.Enabled = True
            BringToFrontContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
            CutContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Cut)
            DeleteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Delete)
            PasteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Paste)
            SelectAllContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.SelectAll)
            SendToBackContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
            UndoContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Undo)
        End If
    End Sub

    Private Sub ContextMenuStripShow(sender As Object, e As MouseEventArgs)
        ' Shows/hides the context menu and positions it according to
        ' where the mouse was clicked.
        If e.Button = MouseButtons.Right AndAlso mReport IsNot Nothing Then
            ' Show the context menu at the mouse location.
            If sender Is Me Then
                ReportContextMenuStrip.Show(Me, e.Location)
            Else
                ReportContextMenuStrip.Show(CType(sender, Control), e.Location)
            End If
        Else
            ReportContextMenuStrip.Hide()
        End If
    End Sub

    Private Sub EditDropDownOpening()
        ' Enables/disables Edit menu items according to the ReportGenerator's 
        ' current Edit state.
        If mReport Is Nothing Then
            For Each item As ToolStripItem In EditToolStripMenuItem.DropDownItems
                item.Enabled = False
            Next
        Else
            ' Only selected text can be copied. Duplicate report elements are not allowed.
            If TypeOf Me.ActiveControl Is TextBoxBase Then
                If CType(Me.ActiveControl, TextBoxBase).SelectionLength > 0 Then
                    CopyToolStripMenuItem.Enabled = True
                Else
                    CopyToolStripMenuItem.Enabled = False
                End If
            Else
                CopyToolStripMenuItem.Enabled = False
            End If
            CutToolStripMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Cut)
            DeleteToolStripMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Delete)
            PasteToolStripMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Paste)
            SelectAllToolStripMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.SelectAll)
        End If
    End Sub

    Private Sub ElementsDropdownOpening()
        ' Checks/unchecks and enables/disables Elements menu items according
        ' to the current visibility or report elements.
        For Each item As ToolStripItem In ElementsToolStripMenuItem.DropDownItems
            If TypeOf item Is ToolStripMenuItem Then
                Dim toolstripItem As ToolStripMenuItem = CType(item, ToolStripMenuItem)
                toolstripItem.Checked = mReportGenerator.VisibleControls.Any(Function(rc) rc.Name = toolstripItem.Text)
                ' The Header and Letterhead itemsChecked state also effects the 
                ' HeaderItemsToolStripMenuItem and LetterheadImageToolStripMenuItem menu items
                Select Case toolstripItem.Text
                    Case "Header"
                        ElementsToolStripMenuItem.DropDownItems.Item("HeaderItemsToolStripMenuItem").Enabled = toolstripItem.Checked
                    Case "Letterhead"
                        ElementsToolStripMenuItem.DropDownItems.Item("LetterheadImageToolStripMenuItem").Enabled = toolstripItem.Checked
                    Case Else
                End Select
            End If
        Next
    End Sub

    Private Sub FormMenuConfigure(rpt As Report)
        ' Enable menu items according to whether a Report is currently open.
        If rpt IsNot Nothing Then
            ElementsToolStripMenuItem.Enabled = True
        Else
            ElementsToolStripMenuItem.Enabled = False
        End If
        SettingsToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        ReportContextMenuStrip.Enabled = ElementsToolStripMenuItem.Enabled
    End Sub

    Private Sub FormResizeTo(pd As PrintDocument)
        ' Get default printer settings to determine page bounds
        Dim pageBounds As Rectangle = pd.DefaultPageSettings.Bounds
        Dim pageMargins As Margins = pd.DefaultPageSettings.Margins

        ' Set form bounds to match the printable area
        Me.Bounds = pageBounds
        Me.MaximizedBounds = Me.Bounds
        Me.MaximumSize = New Size(Me.Bounds.Width, Me.Bounds.Height)

        ' Set the ReportGenerator Vertical and HorizontalLimit to the page margins.
        mReportGenerator.HorizontalLimit = pageMargins.Left
        mReportGenerator.VerticalLimit = pageMargins.Top

        ' Disable the form maximize box.
        Me.MaximizeBox = False
    End Sub

    Private Sub HeaderItemToggle(menuItem As ToolStripMenuItem)
        ' Checks/unchecks header menus items according to their
        ' corresponding control's current visibility.
        Dim headerItem As ReportGenerator.HeaderItem = Nothing
        If Not mReportGenerator.HeaderItems.TryGetValue(menuItem.Text, headerItem) Then Return
        menuItem.Checked = Not menuItem.Checked
        headerItem.Control.Visible = menuItem.Checked
        headerItem.Label.Visible = headerItem.Control.Visible
    End Sub

    Private Sub HeaderMenuItemsCheck()
        ' Checks/unchecks Elements-->Header Items menu items according to 
        ' their corresponding HeaderItem visibility.
        Dim visibleItems As List(Of ReportGenerator.HeaderItem) =
            mReportGenerator.HeaderItems.Values.Where(Function(hi) hi.Control.Visible).ToList()
        For Each item As ToolStripMenuItem In HeaderItemsToolStripMenuItem.DropDownItems
            item.Checked = visibleItems.Any(Function(hi) hi.Label.Text = item.Text)
        Next

    End Sub

    Private Sub LetterheadOpen(fileName As String)
        ' Loads the selected image file into the letterhead
        ' PictureBox and removes the border.
        Dim selectedImage As Image = Image.FromFile(fileName)
        Letterhead.Image = selectedImage
        Letterhead.BorderStyle = BorderStyle.None
        mReport.ReportElements.First(Function(lh) lh.ElementName = "Letterhead").Data = fileName
    End Sub

    Private Sub LetterheadSelect()
        ' Opens a file dialog allowing the user to select the
        ' letterhead image file.
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = STR_DIALOG_FILTER_IMAGE,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            LetterheadOpen(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub PageSetup(sender As Object, e As EventArgs)
        ' Opens the page setup dialog.
        PageSetupDialog.Document = PrintDocument
        If PageSetupDialog.ShowDialog() = DialogResult.OK Then
            Dim margins As Printing.Margins = PrintDocument.DefaultPageSettings.Margins
            Dim paperSize As PaperSize = PrintDocument.DefaultPageSettings.PaperSize
            Dim isLandscape As Boolean = PrintDocument.DefaultPageSettings.Landscape
            If ResizeToPageBounds Then FormResizeTo(PageSetupDialog.Document)
        End If
    End Sub

    Private Sub PopupsHide()

    End Sub

    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Prints the inside of the form's client area, excluding borders and title bar, scaled to the
        ' paper's printable area.
        ' TODO: See what fits on one page and handle multiple pages if needed. Set captureWidth and captureHeight
        ' based on e.PageBounds and e.MarginBounds.
        mReportGenerator.ReportGenerate(sender, e)
        Dim startX As Integer = Me.Bounds.Width - Me.ClientSize.Width
        Dim startY As Integer = Me.Bounds.Height - Me.ClientSize.Height + FormMenuStrip.Height
        Dim captureWidth As Integer = Me.ClientSize.Width
        Dim captureHeight As Integer = Me.ClientSize.Height
        Dim sourceRectangle As New Rectangle(startX, startY, captureWidth, captureHeight)
        Dim formBitmap As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height) ' Capture full form
        Me.DrawToBitmap(formBitmap, New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height))
        Dim croppedBitmap As New Bitmap(captureWidth, captureHeight)
        Using g As Graphics = Graphics.FromImage(croppedBitmap)
            g.DrawImage(formBitmap, New Rectangle(0, 0, captureWidth, captureHeight), sourceRectangle, GraphicsUnit.Pixel)  ' Crop to client area
        End Using
        If ResizeToPageBounds Then
            e.Graphics.DrawImage(croppedBitmap, e.MarginBounds.Left, e.MarginBounds.Top)    ' Center the image within the page margins
        Else
            Dim scaledBitmap As New Bitmap(e.MarginBounds.Width, e.MarginBounds.Height)
            Using g As Graphics = Graphics.FromImage(scaledBitmap)
                g.DrawImage(croppedBitmap, New Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height))    ' Scale to paper printable area (inside margins).
            End Using
            e.Graphics.DrawImage(scaledBitmap, e.MarginBounds.Left, e.MarginBounds.Top)     ' Center the image within the page margins
        End If
        formBitmap.Dispose()
        croppedBitmap.Dispose()
        e.HasMorePages = False
    End Sub

    Private Sub PrintPreview(sender As Object, e As EventArgs)
        ' Opens the print preview dialog.
        PrintPreviewDialog.Document = PrintDocument
        If PrintPreviewDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument.Print()
        End If
    End Sub

    Private Property Report As Report
        Get
            Return mReport
        End Get
        Set(value As Report)
            mReport = value
            If value IsNot Nothing Then
                Me.Text = value.ReportName
                mReportGenerator.GridSize = If(value.GridSize, 0)
                ReportsExportToolStripMenuItem.Enabled = True
                ReportElementsLoad(value.ReportElements)
                FormMenuConfigure(value)
                ElementsToolStripMenuItem.Enabled = True
            End If
        End Set
    End Property

    Private Sub ReportAddNew(ByRef rpt As Report)
        ' Adds a new report to the database and the Reports menu drop down list.
        Database.Reports.Add(rpt)
        ReportsToolStripMenuAdd(New ToolStripMenuItem(rpt.ReportName))
    End Sub

    Private Function ReportClose() As DialogResult
        ' Closes the current report.
        Dim result As DialogResult = DialogResult.None
        ReportUpdate() ' Update the current Report and ReportElements. If anything changed, prompt user to save changes.
        If Database.ChangeTracker.HasChanges() Then
            result = MessageBox.Show("There are unsaved changes. Do you want to save them?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            Select Case result
                Case DialogResult.Yes
                    Database.SaveChanges()
                Case DialogResult.No
                    Database.ChangeTracker.Clear()
                Case DialogResult.Cancel
                    result = DialogResult.Cancel
                Case Else
            End Select
        End If
        If result <> DialogResult.Cancel Then
            For Each re As ReportGenerator.ReportControl In mReportGenerator.VisibleControls
                mReportGenerator.ControlHide(re)
            Next
            Me.Text = "Reports"
            ReportsExportToolStripMenuItem.Enabled = False
            mReport = Nothing
            FormMenuConfigure(mReport)
        End If
        Return result
    End Function

    Private Function ReportControlToElement(rc As ReportGenerator.ReportControl) As ReportElement
        ' Returns the Database ReportElement corresponding to the given ReportControl in the current report.
        Return mReport.ReportElements.FirstOrDefault(Function(re) re.ElementName = rc.Name.ToString())
    End Function

    Private Function ReportDataLoad(ByVal jobDetails As JobDetail) As BindingList(Of JobDetail)
        ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements sorted.
        Dim data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd.Id = jobDetails.Id.ToString()) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .AsSplitQuery().ToList()
            )
        ' Sort measurements by Id.
        For Each jd As JobDetail In data
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
        Return data
    End Function

    Private Sub ReportEditorOpen()
        ' Opens the Reports editor form.
        Dim editor As New FrmReportsEditor(Me.ReportsBindingSource, Me.EmployeeBindingSource)
        editor.ShowDialog()
        Dim rpt As Report = editor.Current
        If rpt IsNot Me.Report Then
            If Me.Report IsNot Nothing Then
                If ReportClose() = DialogResult.Cancel Then Exit Sub
                Me.Report = ReportOpen(rpt.ReportName)
            End If
        End If
    End Sub

    Private Sub ReportElementsLoad(elements As List(Of ReportElement))
        ' Makes the selected ReportControl.Controls and HeaderItem.Controls visible and
        ' loads any data.
        If elements IsNot Nothing Then
            Dim visibleControls As List(Of ReportGenerator.ReportControl) = New List(Of ReportGenerator.ReportControl)()
            For Each re As ReportElement In elements
                Dim reportControl As ReportGenerator.ReportControl = mReportGenerator.ReportControls.FirstOrDefault(Function(ce) ce.Name = re.ElementName)
                Select Case reportControl.Control.Name
                    Case "Letterhead"
                        If re.Data IsNot Nothing Then LetterheadOpen(re.Data)
                        mReportGenerator.VerticalLimit = Math.Max(Me.Controls("Letterhead").Bounds.Bottom, mReportGenerator.VerticalLimit)
                    Case "Header"
                        If re.Data IsNot Nothing Then
                            Dim headerItems As List(Of String) = re.Data.Split(";"c).ToList()
                            Dim visibleItems As List(Of ReportGenerator.HeaderItem) =
                                mReportGenerator.HeaderItems.Values _
                                    .Where(Function(p) headerItems.Contains(p.Name)) _
                                    .ToList()
                            For Each item As ReportGenerator.HeaderItem In visibleItems
                                item.Control.Visible = True
                                item.Label.Visible = True
                            Next
                        End If
                        mReportGenerator.VerticalLimit = Math.Max(Me.Controls("Header").Bounds.Bottom, mReportGenerator.VerticalLimit)
                    Case Else
                End Select
                reportControl.Control.Location = New Point(re.PositionX, re.PositionY)
                reportControl.Control.Size = New Size(re.SizeWidth, re.SizeHeight)
                visibleControls.Add(reportControl)
            Next
            mReportGenerator.VisibleControls = visibleControls
        Else
            mReportGenerator.VisibleControls = Nothing
        End If
    End Sub

    Private Function ReportElementToControl(elem As ReportElement, ByVal from As List(Of ReportGenerator.ReportControl)) As ReportGenerator.ReportControl
        Return from.FirstOrDefault(Function(rc) rc.Name = elem.ElementName)
    End Function

    Private Sub ReportElementToggle(ByRef menuItem As ToolStripMenuItem)
        Dim item As ToolStripMenuItem = menuItem
        Dim rc As ReportGenerator.ReportControl = mReportGenerator.ReportControls.FirstOrDefault(Function(c) c.Name = item.Text)
        If menuItem.Checked Then
            mReportGenerator.ControlHide(rc)
        Else
            mReportGenerator.ControlShow(rc)
        End If
        menuItem.Checked = Not menuItem.Checked
    End Sub

    Private Sub ReportExport()
        Dim saveFileDialog1 As New SaveFileDialog() With {
            .Filter = STR_DIALOG_FILTER_CSV,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            ReportToFile(saveFileDialog1.FileName)
        End If
    End Sub

    Private Function ReportFromFile(fileName As String) As Report
        Dim rpt As Report = Nothing
        If File.Exists(fileName) Then
            Dim elems As New List(Of ReportElement)
            Dim content As String() = File.ReadAllLines(fileName)
            For Each line As String In content
                line = line.Trim()
                If line.Length > 0 AndAlso line(0) <> "'"c Then
                    Dim values As String() = line.Split(";"c)
                    Select Case values(0)
                        Case "<Report>"
                            rpt = ReportFromFileReport(values.Skip(1).ToArray())
                        Case "<Element>"
                            elems.Add(ReportFromFileElement(values.Skip(1).ToArray()))
                        Case Else
                    End Select
                End If
            Next
            If rpt IsNot Nothing Then
                For Each re As ReportElement In elems
                    rpt.ReportElements.Add(re)
                Next
            End If
        End If
        Return rpt
    End Function

    Private Function ReportFromFileElement(ByVal values() As String) As ReportElement
        Return New ReportElement With {
            .ElementName = values(0),
            .PositionX = values(1),
            .PositionY = values(2),
            .SizeWidth = values(3),
            .SizeHeight = values(4),
            .Zorder = values(5),
            .Data = If(Not String.IsNullOrEmpty(values(6)), values(6), Nothing)
        }
    End Function

    Private Function ReportFromFileReport(values() As String) As Report
        Return New Report() With {
            .ReportName = values(0),
            .LastModifed = Date.Now,
            .ModifiedBy = Me.User.Id,
            .GridSize = Integer.Parse(values(1))
        }
    End Function

    Private Sub ReportGeneratorInitialize()
        ' Initialize the ReportGenerator and set up event handlers for all report elements.
        mReportGenerator = New ReportGenerator() With {
            .ParentForm = Me,
            .HorizontalLimit = 0,
            .VerticalLimit = Me.FormMenuStrip.Bounds.Bottom,
            .GridSize = 0,
            .ReportControls = New List(Of ReportGenerator.ReportControl) From {
                New ReportGenerator.ReportControl(Letterhead, True, False, False, Nothing, Nothing, Nothing),
                New ReportGenerator.ReportControl(Header, True, False, False, Nothing, Nothing, Nothing),
                New ReportGenerator.ReportControl(ChartBladeHeight, True, True, True, Nothing, Nothing, New ReportDataDelegate(AddressOf Reporting.ChartBladeHeight_Data)),
                New ReportGenerator.ReportControl(ChartAngularPosition, True, True, True, Nothing, Nothing, New ReportDataDelegate(AddressOf Reporting.ChartAngularPosition_Data))
            },
           .HeaderItems = New Dictionary(Of String, ReportGenerator.HeaderItem) From {
                {"Job No.", New ReportGenerator.HeaderItem(TxtJobNumber, LabJobNumber, "JobNo")},
                {"Customer", New ReportGenerator.HeaderItem(TxtCustomer, LabCustomer, "Cust")},
                {"Vessel", New ReportGenerator.HeaderItem(TxtVessel, LabVessel, "Vess")},
                {"Manufacturer", New ReportGenerator.HeaderItem(TxtManufacturer, LabManufacturer, "Mfg")},
                {"Part No.", New ReportGenerator.HeaderItem(TxtPartNumber, LabPartNumber, "P/N")},
                {"S/N", New ReportGenerator.HeaderItem(TxtSerialNumber, LabSerialNumber, "S/N")},
                {"Stamp No.", New ReportGenerator.HeaderItem(TxtStampNumber, LabStampNumber, "Stamp")},
                {"Inspected By", New ReportGenerator.HeaderItem(TxtInspectedBy, LabInspectedBy, "InspBy")},
                {"Job Id", New ReportGenerator.HeaderItem(TxtJobId, LabJobId, "JobId")},
                {"Class", New ReportGenerator.HeaderItem(TxtClass, LabClass, "Cls")},
                {"Repair Status", New ReportGenerator.HeaderItem(TxtRepairStatus, LabRepairStatus, "RStat")},
                {"Style", New ReportGenerator.HeaderItem(TxtStyle, LabStyle, "Style")},
                {"Material", New ReportGenerator.HeaderItem(TxtMaterial, LabMaterial, "Matl")},
                {"Bore", New ReportGenerator.HeaderItem(TxtBore, LabBore, "Bore")},
                {"DAR", New ReportGenerator.HeaderItem(TxtDAR, LabDAR, "DAR")},
                {"Cup", New ReportGenerator.HeaderItem(TxtCup, LabCup, "Bore")},
                {"File Name", New ReportGenerator.HeaderItem(TxtFileName, LabFilename, "File")},
                {"Scan Date", New ReportGenerator.HeaderItem(TxtScanDate, LabScanDate, "DAR")},
                {"Performed By", New ReportGenerator.HeaderItem(TxtPerformedBy, LabPerformedBy, "PerfBy")},
                {"Rotation", New ReportGenerator.HeaderItem(TxtRotation, LabRotation, "Rotn")},
                {"Marked Dia", New ReportGenerator.HeaderItem(TxtMarkedDiameter, LabMarkedDiameter, "MrkDia")},
                {"Measured Dia", New ReportGenerator.HeaderItem(TxtMeasuredDiameter, LabMeasuredDiameter, "MeasDia")},
                {"Marked Pitch", New ReportGenerator.HeaderItem(TxtMarkedPitch, LabMarkedPitch, "MrkPit")},
                {"Wheel Pitch", New ReportGenerator.HeaderItem(TxtWheelPitch, LabWheelPitch, "WhlPit")}
            }
        }
        For Each rc As ReportGenerator.ReportControl In mReportGenerator.ReportControls
            Dim elementMenuItem As ToolStripMenuItem = Me.ElementsToolStripMenuItem.DropDownItems.Add(rc.Name)
            AddHandler elementMenuItem.Click, AddressOf Me.ReportElement_Clicked
            AddHandler rc.Control.MouseDown, AddressOf Me.Control_MouseDown
        Next
        ' TODO: Header dropdown items are hardcoded in the designer. Probably should be 
        ' added programmatically, like ReportControls above, in case they change.
        For Each hd As ReportGenerator.HeaderItem In mReportGenerator.HeaderItems.Values.ToList()
            AddHandler hd.Control.Click, AddressOf Me.HeaderItem_Click
        Next
    End Sub

    Private Sub ReportImport()
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = STR_DIALOG_FILTER_CSV,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim newReport As Report = ReportFromFile(openFileDialog1.FileName)
            If newReport IsNot Nothing Then
                If Report IsNot Nothing Then
                    If ReportClose() = DialogResult.Cancel Then Exit Sub
                End If
                Report = newReport
                ReportAddNew(newReport)
            End If
        End If
    End Sub

    Private Function ReportNameInput() As String
        Dim reportName As String = String.Empty
        FrmInputBox.Text = "Save Report As"
        FrmInputBox.Prompt = "Enter the new name of the report:"
        FrmInputBox.InputText = Me.Report.ReportName
        FrmInputBox.TxtInput.Select()
        FrmInputBox.TxtInput.SelectAll()
        Dim result As DialogResult = FrmInputBox.ShowDialog()
        If result = DialogResult.OK Then reportName = FrmInputBox.InputText
        Return reportName
    End Function

    Private Function ReportOpen(ByVal reportName As String) As Report
        Dim result As Report = Nothing
        If Not String.IsNullOrEmpty(reportName) Then
            result = Database.Reports _
                .Include(Function(r) r.ReportElements) _
                .FirstOrDefault(Function(r) r.ReportName = reportName.ToString())
            ReportDataGet() ' See function for explanation.
        End If
        Return result
    End Function

    Private Sub ReportToFile(fileName As String)
        Const commentReport As String = "'---Report---"
        Const commentElements As String = "'---Elements---"
        Dim content As String =
            $"{commentReport}{Environment.NewLine}" &
            $"<Report>;{Report.ReportName};{Report.GridSize}{Environment.NewLine}"
        content += commentElements & Environment.NewLine
        For Each re As ReportElement In mReport.ReportElements
            content += $"<Element>;{re.ElementName};{re.PositionX};{re.PositionY};{re.SizeWidth};{re.SizeHeight};{re.Zorder};{If(re.Data, "")}{Environment.NewLine}"
        Next
        File.WriteAllText(fileName, content)
    End Sub

    Private Property ResizeToPageBounds As Boolean
        Get
            Return mResizeToPagePounds
        End Get
        Set(value As Boolean)
            If value Then
                ' Disable the form maximize box.
                Me.MaximizeBox = False
            Else
                ' Set form bounds to the screen working area
                Me.MaximizedBounds = Screen.FromControl(Me).WorkingArea
                Me.MaximumSize = Size.Empty

                ' Enable the form maximize box.
                Me.MaximizeBox = True
            End If
            mResizeToPagePounds = value
        End Set
    End Property

    Private Sub ReportSave()
        ' Save the current report layout to the database.
        ReportUpdate()
        If Database.ChangeTracker.HasChanges() Then Database.SaveChanges()
    End Sub

    Private Sub ReportSaveAs()
        ' Save the current report layout to the database with a different name.
        If Me.Report IsNot Nothing Then
            Dim reportsMenuItem As ToolStripMenuItem = ToolStripMenuItemGet(ReportsToolStripMenuItem, Me.Report.ReportName)
            Me.Report.ReportName = ReportNameInput()
            ReportSave()
            Me.Text = Me.Report.ReportName
            If reportsMenuItem IsNot Nothing Then reportsMenuItem.Text = Me.Report.ReportName
        End If
    End Sub

    Private Sub ReportsToolStripMenuAdd(item As ToolStripMenuItem, Optional ByVal index As Integer = 0)
        ' Adds a report to the ReportsToolStripMenu
        ReportsToolStripMenuItem.DropDownItems.Insert(index, item)
        AddHandler item.Click, AddressOf ReportsItemClickHandler
    End Sub

    Private Sub ReportsToolStripMenuInitialize()
        ' Populate the Reports menu with available reports from the database.
        Dim i As Integer = 0
        For Each rpt As Report In ReportsBindingSource
            ReportsToolStripMenuAdd(New ToolStripMenuItem(rpt.ReportName), i)
            i += 1
        Next
    End Sub

    Private Sub ReportUpdate()
        ' Update ReportElements in the database.
        If mReport Is Nothing OrElse mReport.ReportElements Is Nothing OrElse mReportGenerator Is Nothing Then
            Return
        End If

        ' If this is a new unsaved report, save it now.
        If mReport.Id Is Nothing Then
            Database.SaveChanges()
        End If

        ' Remove any deleted elements
        Dim toRemove As List(Of ReportElement) = mReport.ReportElements _
            .Where(Function(re) ReportElementToControl(re, mReportGenerator.VisibleControls) Is Nothing) _
            .ToList()

        If toRemove.Count > 0 Then
            ' Remove from EF change tracker in a single call
            Database.ReportElements.RemoveRange(toRemove)
            ' Also remove from the in-memory collection to keep UI/model consistent
            For Each re In toRemove
                mReport.ReportElements.Remove(re)
            Next
        End If

        ' Update/add any changed/added elements.
        For Each rc As ReportGenerator.ReportControl In mReportGenerator.VisibleControls
            Dim re As ReportElement = ReportControlToElement(rc)
            If re IsNot Nothing Then
                If re.SizeHeight <> rc.Control.Height Then
                    re.SizeHeight = rc.Control.Height
                End If
                If re.SizeWidth <> rc.Control.Width Then
                    re.SizeWidth = rc.Control.Width
                End If
                If re.PositionX <> rc.Control.Location.X Then
                    re.PositionX = rc.Control.Location.X
                End If
                If re.PositionY <> rc.Control.Location.Y Then
                    re.PositionY = rc.Control.Location.Y
                End If
            Else
                mReport.ReportElements.Add(New ReportElement() With {
                    .ReportId = mReport.Id,
                    .ElementName = rc.Name,
                    .PositionX = rc.Control.Location.X,
                    .PositionY = rc.Control.Location.Y,
                    .SizeWidth = rc.Control.Size.Width,
                    .SizeHeight = rc.Control.Size.Height
                })
            End If
        Next

        ' Update header items
        Dim visibleItems As List(Of String) =
            mReportGenerator.HeaderItems.Values.Where(Function(hi) hi.Control.Visible).Select(Function(hi) hi.Name).ToList()
        Dim headerElement As ReportElement = mReport.ReportElements.FirstOrDefault(Function(re) re.Report Is mReport And re.ElementName = "Header")
        If headerElement IsNot Nothing Then
            Dim headerItems As List(Of String) = Nothing
            If headerElement.Data IsNot Nothing Then headerItems = headerElement.Data.Split(";"c).ToList
            If headerItems IsNot Nothing AndAlso visibleItems IsNot Nothing AndAlso Not visibleItems.SequenceEqual(headerItems) Then
                headerElement.Data = String.Join(";", visibleItems)
            End If
        End If

        ' Save report metadata if anything changed.
        If Database.ChangeTracker.HasChanges() Then
            mReport.LastModifed = Now
            mReport.ModifiedBy = Me.User.Id
            mReport.GridSize = mReportGenerator.GridSize
        End If
    End Sub

    Private Function ToolStripMenuItemGet(menu As ToolStripMenuItem, txt As String) As ToolStripMenuItem
        Dim menuItem As ToolStripMenuItem = Nothing
        For Each item As ToolStripItem In menu.DropDownItems
            If TypeOf item Is ToolStripMenuItem Then
                If item.Text = txt Then
                    menuItem = CType(item, ToolStripMenuItem)
                    Exit For
                End If
            End If
        Next
        Return menuItem
    End Function

#End Region
#Region "Event Handlers"
#Region "Form Events"
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ContextMenuStripShow(sender, e)
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs)
        Dim result As DialogResult = If(Report IsNot Nothing, ReportClose(), DialogResult.None)
        e.Cancel = (result = DialogResult.Cancel)
        MyBase.Form_Closing(sender, e)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.KeyPreview = True
        ReportGeneratorInitialize()
        ReportsToolStripMenuInitialize()
        FormResizeTo(New PrintDocument())
        Me.ResizeToPageBounds = True
    End Sub

    Private Sub Form_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Select Case e.Button
            Case MouseButtons.Right
                ContextMenuStripShow(sender, e)
            Case MouseButtons.Left
                PopupsHide()
            Case Else
        End Select
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        ' DELETE key not being passed to Form_KeyDown, so we handle it here.
        Select Case keyData
            Case Keys.Delete
                mReportGenerator.DeleteSelected()
                Return True
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    Private Sub ReportGenerator_ReportEvent(sender As Object, e As ReportGenerator.ReportEventArgs)
        ' Not used
    End Sub
#End Region
#Region "Print Events"
    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument.PrintPage
        PrintPage(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument.Print()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreview(sender, e)
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetup(sender, e)
    End Sub
#End Region
#Region "Form Menu Events"
    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        EditDropDownOpening()
    End Sub
    Private Sub EditCopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        SendKeys.Send("^C")
    End Sub

    Private Sub EditCutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        SendKeys.Send("^X")
    End Sub

    Private Sub EditDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        SendKeys.Send("{DEL}")
    End Sub

    Private Sub ElementsHeaderItemClickHandler(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click, ToolStripMenuItem9.Click, ToolStripMenuItem10.Click, ToolStripMenuItem11.Click, ToolStripMenuItem12.Click, ToolStripMenuItem13.Click, ToolStripMenuItem14.Click, ToolStripMenuItem15.Click, ToolStripMenuItem16.Click, ToolStripMenuItem17.Click, ToolStripMenuItem18.Click, ToolStripMenuItem19.Click, ToolStripMenuItem20.Click, ToolStripMenuItem21.Click, ToolStripMenuItem22.Click, ToolStripMenuItem23.Click, ToolStripMenuItem24.Click, ToolStripMenuItem25.Click, ToolStripMenuItem26.Click, ToolStripMenuItem27.Click, ToolStripMenuItem28.Click, ToolStripMenuItem29.Click, ToolStripMenuItem30.Click, ToolStripMenuItem31.Click
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub ElementsLetterheadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetterheadImageToolStripMenuItem.Click
        Try
            LetterheadSelect()
        Catch ex As Exception
            MessageBox.Show("Error loading letterhead: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub EditPasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        SendKeys.Send("^V")
    End Sub

    Private Sub ElementsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ElementsToolStripMenuItem.DropDownOpening
        ElementsDropdownOpening()
    End Sub

    Private Sub FileCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        If Report IsNot Nothing Then ReportClose()
        'Dim result As DialogResult = If(Report IsNot Nothing, ReportClose(), DialogResult.None)
        'If result <> DialogResult.Cancel Then Report = Nothing
    End Sub

    Private Sub FileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        CloseForm(Me)
    End Sub

    Private Sub FileNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileNewToolStripMenuItem.Click
        If ReportClose() = DialogResult.Cancel Then Exit Sub
        Me.Report = New Report() With {
            .ReportName = $"New Report  ({(Database.Reports.Local.Where(Function(r) r.ReportName Like kNewReportName).Count() + 1)})"
        }
        ReportAddNew(Me.Report)
    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ReportEditorOpen()
    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ReportSave()
    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ReportSaveAs()
    End Sub

    Private Sub HeaderItemsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles HeaderItemsToolStripMenuItem.DropDownOpening
        HeaderMenuItemsCheck()
    End Sub

    Private Sub ReportElement_Clicked(sender As Object, e As EventArgs)
        ReportElementToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderItem_Click(sender As Object, e As EventArgs)
        mReportGenerator.SelectedControls = Nothing
    End Sub

    Private Sub ReportsItemClickHandler(sender As Object, e As EventArgs)
        Report = ReportOpen(CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub ReportsEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsEditToolStripMenuItem.Click
        ReportEditorOpen()
    End Sub

    Private Sub ReportsExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsExportToolStripMenuItem.Click
        ReportExport()
    End Sub

    Private Sub ReportsImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsImportToolStripMenuItem.Click
        ReportImport()
    End Sub
#End Region
#Region "Context Menu Events"
    Private Sub ReportContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles ReportContextMenuStrip.Opening
        ContextMenuOpening()
    End Sub

    Private Sub BringToFrontContextMenuItem_Click(sender As Object, e As EventArgs) Handles BringToFrontContextMenuItem.Click
        SendKeys.Send("^F")
    End Sub

    Private Sub CutContextMenuItem_Click(sender As Object, e As EventArgs) Handles CutContextMenuItem.Click
        SendKeys.Send("^X")
    End Sub

    Private Sub UndoContextMenuItem_Click(sender As Object, e As EventArgs) Handles UndoContextMenuItem.Click
        SendKeys.Send("^Z")
    End Sub

    Private Sub PasteContextMenuItem_Click(sender As Object, e As EventArgs) Handles PasteContextMenuItem.Click
        SendKeys.Send("^V")
    End Sub

    Private Sub DeleteContextMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteContextMenuItem.Click
        SendKeys.Send("{DEL}")
    End Sub

    Private Sub SelectAllContextMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllContextMenuItem.Click
        SendKeys.Send("^A")
    End Sub

    Private Sub SendToBackContextMenuItem_Click(sender As Object, e As EventArgs) Handles SendToBackContextMenuItem.Click
        SendKeys.Send("^B")
    End Sub
#End Region
#End Region
#Region "Data Delegates"
    Private Sub ReportDataGet()
        ' NOTE: Data delegates should be called once for each ReportControl, the first time it becomes visible.
        ' Data Delegates can be passed any client control, e.g. FrmMeasurements.ChartBladeHeight,
        ' FrmReports.ChartBladeHeight, etc., but can only work with one control at a time. For instance, I
        ' copied the code for Reporting.ChartBladeHeight() from FrmMeasurements.ShowTrack(), but it seems we're
        ' doing several things at once in FrmMeasurements.ShowTrack() on two graphs, so that will have to be
        ' split up into two separate methods. Once that's done, you can just call Reporting.ChartBladeHeight()
        ' from FrmMeasurements.ShowTrack(), passing the args in a ReportDataArgs guy (in FrmMeasurements.ShowTrack()
        ' you would call   directly:
        '   ChartBladeHeight_Data
        '   (
        '       ChartBladeHeight,     
        '       New ReportDataArgs
        '       (
        '           ComboReferenceBlade.SelectedValue,
        '           ComboReferencePoint.SelectedValue,
        '           ComboReferenceRadius.SelectedValue,
        '           JobDetails
        '       )
        '   )
        '
        ' Here, we will have to get the args from some Report setting and provide controls to select those.
        ' I just hardcoded some values to demonstrate.
        Dim rc As ReportGenerator.ReportControl = mReportGenerator.ReportControls.First(Function(ctrl) ctrl.Name = "ChartBladeHeight")
        rc.Data.DynamicInvoke(ChartBladeHeight, New ReportDataArgs(1, "Mid", 49.99, JobDetails))
        rc.HasData = True

        rc = mReportGenerator.ReportControls.First(Function(ctrl) ctrl.Name = "ChartAngularPosition")
        rc.Data.DynamicInvoke(ChartAngularPosition, New ReportDataArgs(1, "Mid", 49.99, JobDetails))
        rc.HasData = True

        ' This does create some redundancy in the calls, esp in FrmMeasurements.ShowTrack()
        ' when calling ShowRake(). I'll see if there's a way to make it more efficient.
    End Sub
#End Region
End Class