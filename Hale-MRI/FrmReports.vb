Imports System.ComponentModel
Imports System.Drawing.Printing
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore

''' <summary>
''' Form for Opening, Closing, Editting and Printing reports.
''' Manages database Report entities and serves as the 
''' palette for displaying report elements (controls).
''' NOTE:
'''     This form only manages itself and its own controls 
'''     (e.g. menus, form size) and maintains database
'''     currency with respect to report layouts. The visual
'''     report elements are managed by the ReportGenerator
'''     (e.g. contol visibility, size, location, drag/drop
'''     and edting). This form should not modify any report
'''     controls, as this may cause unexpected behavior.
'''     
''' </summary>
Public Class FrmReports
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record
    Private mReport As Report = Nothing                     ' The current report.
    Private mReportGenerator As ReportGenerator = Nothing  ' The ReportGenerator for runtime report layout and formatting.
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

    Private Sub ContextMenuMenuItemsEnable()
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

    Private Sub ControlVisible(ctrl As Control, visible As Boolean, Optional ByVal modify As Boolean = False)
        ' Sets the visibility and behavior of the given control in the report,
        ' and optionally modifies the database accordingly.
        ctrl.Visible = visible
        If visible Then
            AddHandler ctrl.MouseClick, AddressOf Control_MouseClick
            AddHandler ctrl.Enter, AddressOf Control_Enter
            AddHandler ctrl.KeyDown, AddressOf Control_KeyDown
            AddHandler ctrl.Leave, AddressOf Control_Leave
            AddHandler ctrl.MouseDown, AddressOf Control_MouseDown
            AddHandler ctrl.MouseHover, AddressOf Control_MouseHover
            AddHandler ctrl.MouseMove, AddressOf Control_MouseMove
            AddHandler ctrl.MouseUp, AddressOf Control_MouseUp
            AddHandler ctrl.Paint, AddressOf Control_Paint
            AddHandler ctrl.Resize, AddressOf Control_Resize
            mReportGenerator.ReportControls.Add(ctrl)
            If modify Then _
            Database.ReportElements.Add(New ReportElement() With {
                .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
                .ElementName = ctrl.Name,
                .PositionX = ctrl.Location.X,
                .PositionY = ctrl.Location.Y,
                .SizeWidth = ctrl.Size.Width,
                .SizeHeight = ctrl.Size.Height
            })
            If JobDetails IsNot Nothing Then
                Select Case ctrl.Name
                    Case "Chart1"
                        UpdateBladeAverageGraph(Chart1, JobDetails, GetToleranceTable(Database, "II"), Job?.DesiredPitch)
                End Select
            End If
        Else
            If modify Then Database.ReportElements.Remove(ReportElementGet(ctrl))
            mReportGenerator.ReportControls.Remove(ctrl)
            RemoveHandler ctrl.MouseClick, AddressOf Control_MouseClick
            RemoveHandler ctrl.Enter, AddressOf Control_Enter
            RemoveHandler ctrl.KeyDown, AddressOf Control_KeyDown
            RemoveHandler ctrl.Leave, AddressOf Control_Leave
            RemoveHandler ctrl.MouseDown, AddressOf Control_MouseDown
            RemoveHandler ctrl.MouseHover, AddressOf Control_MouseHover
            RemoveHandler ctrl.MouseMove, AddressOf Control_MouseMove
            RemoveHandler ctrl.MouseUp, AddressOf Control_MouseUp
            RemoveHandler ctrl.Paint, AddressOf Control_Paint
            RemoveHandler ctrl.Resize, AddressOf Control_Resize
        End If
        If modify Then Database.SaveChanges()
        ElementMenuItemsUpdate(ctrl, visible)
    End Sub

    Private Sub FormResizeTo(e As PrintEventArgs)

    End Sub

    Private Sub DataSourcesInitialize()
        'ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
        'MasterSource = MeasurementDataBindingSource
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
    End Sub

    Private Sub LetterheadSelect()
        ' Opens a file dialog allowing the user to select the
        ' letterhead image file.
        OpenFileDialog1.Filter = STR_DIALOG_FILTER_IMAGE
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                LetterheadOpen(OpenFileDialog1.FileName)
                mReport.LetterHeadFile = OpenFileDialog1.FileName
            Catch ex As Exception
                MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PopupsHide()

    End Sub

    Private Function ReportControlToElement(rc As ReportGenerator.ReportControl) As ReportElement
        ' Returns the Database ReportElement corresponding to the given ReportControl in the current report.
        Return mReport.ReportElements.FirstOrDefault(Function(re) re.ElementName = rc.Name.ToString())
    End Function

    Private Property Report As String
        Get
            Return If(mReport?.ReportName, "")
        End Get
        Set(value As String)
            Me.Text = "Reports"
            If Not String.IsNullOrEmpty(value) Then
                mReport = Database.Reports _
                    .Include(Function(r) r.ReportElements) _
                    .FirstOrDefault(Function(r) r.ReportName = value.ToString())
            Else
                mReport = Nothing
            End If
            If mReport IsNot Nothing Then
                Me.Text = mReport.ReportName
                mReportGenerator.GridSize = mReport.GridSize
            End If
            ReportLoad(mReport?.ReportElements)
        End Set
    End Property

    Private Function ReportClose() As DialogResult
        ' Closes the current report.
        Dim result As DialogResult = DialogResult.None
        ReportUpdate() ' Update the current Report and ReportElements. If anything changed, prompt user to save chages.
        If Database.ChangeTracker.HasChanges() Then
            result = MessageBox.Show("There are unsaved changes. Do you want to save them before exiting?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
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
        If result <> DialogResult.Cancel Then Report = Nothing
        Return result
    End Function

    Private Sub ReportElementAddNew(ctrl As Control, item As ToolStripMenuItem)
        ' Adds a new report element to the current report and database.
        If ctrl IsNot Nothing Then
            mReportGenerator.ControlPositionNew(ctrl)
            ControlVisible(ctrl, True, True)
            'Database.ReportElements.Add(New ReportElement() With {
            '    .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
            '    .ElementName = ctrl.Name,
            '    .PositionX = ctrl.Location.X,
            '    .PositionY = ctrl.Location.Y,
            '    .SizeWidth = ctrl.Size.Width,
            '    .SizeHeight = ctrl.Size.Height
            '})
            'Database.SaveChanges()
        End If
    End Sub

    Private Sub ReportElementCut(ctrl As Control)
        ' Cuts the specified control from its current parent and stores it for pasting.
        mCutControl = ctrl
        mControlIsDeleted = False
        ControlVisible(mCutControl, False, True)
        'Database.ReportElements.Remove(
        'base.ReportElements.FirstOrDefault(Function(re) re.Report.ReportName = mReport AndAlso re.ElementName = mCutControl.Name)
        ')
    End Sub

    Private Sub ReportElementDelete(ctrl As Control)
        ' Deletes the specified control from the current report and database.
        mCutControl = ctrl
        mControlIsDeleted = True
        ControlVisible(mCutControl, False, True)
        'Dim elementToRemove As ReportElement = ReportElementGet(ctrl)
        'If elementToRemove IsNot Nothing Then
        '    Database.ReportElements.Remove(elementToRemove)
        '    Database.SaveChanges()
        '    mCurrentElements.Remove(elementToRemove)
        '    mReportGenerator.ReportElements.Remove(ctrl)
        'End If
    End Sub

    Private Function ReportElementGet(ctrl As Control) As ReportElement
        ' Returns the Database ReportElement corresponding to the given control in the current report.
        Return Database.ReportElements.FirstOrDefault(Function(re) re.Report.ReportName = mReport AndAlso re.ElementName = ctrl.Name.ToString())
    End Function

    Private Sub ReportEditorOpen()
        ' Opens the Reports editor form.
        ShowForm(gFrmReportsEditor, Database, User)
    End Sub

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

    Private Function ReportElementToControl(elem As ReportElement, ByVal from As List(Of ReportGenerator.ReportControl)) As ReportGenerator.ReportControl
        Return from.FirstOrDefault(Function(rc) rc.Name = elem.ElementName)
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
                New ReportGenerator.ReportControl(Chart1, True, True, True, Nothing, Nothing, Nothing),
                New ReportGenerator.ReportControl(Chart2, True, True, True, Nothing, Nothing, Nothing)
            },
           .headerItems = New Dictionary(Of String, ReportGenerator.HeaderItem) From {
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
        For Each hd As ReportGenerator.HeaderItem In mReportGenerator.HeaderItems.Values.ToList()
            AddHandler hd.Control.Click, AddressOf Me.HeaderItem_Click
        Next
    End Sub

    Private Sub ReportLoad(elements As List(Of ReportElement))
        For Each ctrl As Control In mAllElements
            ControlVisible(ctrl, False, False)
        Next
        For Each re As ReportElement In elements
            Dim control As Control = mAllElements.FirstOrDefault(Function(ce) ce.Name = re.ElementName)
            If control IsNot Nothing Then
                control.Location = New Point(re.PositionX, re.PositionY)
                control.Size = New Size(re.SizeWidth, re.SizeHeight)
                ControlVisible(control, True, False)
            End If
        Next
        mReportGenerator.ReportControls = mReportGenerator.ReportControls
    End Sub

    Private Function ReportNameInput() As String
        Dim reportName As String = String.Empty
        FrmInputBox.Text = "Save Report As"
        FrmInputBox.Prompt = "Enter the new name of the report:"
        FrmInputBox.InputText = ""
        Dim result As DialogResult = FrmInputBox.ShowDialog()
        If result = DialogResult.OK Then reportName = FrmInputBox.InputText
        Return reportName
    End Function

    Private Property ResizeToPagePounds As Boolean
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

    Private Sub ReportSave(Optional reportName As String = "")
        ' Save the current report layout to the database.
        ReportUpdate()
        If Not String.IsNullOrEmpty(reportName) Then mReport.ReportName = reportName
        If Database.ChangeTracker.HasChanges() Then Database.SaveChanges()
    End Sub

    Private Sub ReportsToolStripMenuInitialize()
        ' Populate the Reports menu with available reports from the database.
        Dim reportsMenu As ToolStripMenuItem = ReportsToolStripMenuItem
        Dim i As Integer = 0
        For Each rpt As Report In ReportsBindingSource
            Dim subItem As New ToolStripMenuItem(rpt.ReportName)
            reportsMenu.DropDownItems.Insert(i, subItem)
            AddHandler subItem.Click, AddressOf ReportsItemClickHandler
            i += 1
        Next
    End Sub

    Private Sub ReportUpdate()
        ' Update ReportElements in the database.
        If mReport Is Nothing OrElse mReport.ReportElements Is Nothing OrElse mReportGenerator Is Nothing Then
            Return
        End If

        ' Remove any deleted elements
        Dim toRemove As List(Of ReportElement) = mReport.ReportElements _
            .Where(Function(re) ReportElementToControl(re, mReportGenerator.VisibleControls) Is Nothing) _
            .ToList()

    Private Sub SortMeasurementData(ByRef jobDetails As BindingList(Of JobDetail))
        For Each jd As JobDetail In jobDetails
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
    End Sub
#End Region
#Region "Event Handlers"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

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
            If headerItems Is Nothing OrElse Not visibleItems.SequenceEqual(headerItems) Then
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
#End Region
#Region "Event Handlers"
#Region "Form Events"
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ContextMenuStripShow(sender, e)
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs)
        ReportUpdate()
        Dim result As DialogResult = ReportClose()
        e.Cancel = (result = DialogResult.Cancel)
        MyBase.Form_Closing(sender, e)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.KeyPreview = True
        ReportGeneratorInitialize()
        ReportsToolStripMenuInitialize()
        FormResizeTo(New PrintDocument())
        Me.ResizeToPagePounds = True
        ' Open the default report if one is set.
        Report = If(Database.Reports.FirstOrDefault(Function(dr) dr.IsDefault = True)?.ReportName, "")
    End Sub


    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        DataGridJobs.Location = New Point((Me.ClientSize.Width - DataGridJobs.Width) \ 2, (Me.ClientSize.Height - DataGridJobs.Height) \ 2)
        DataGridJobs.Size = New Size(Me.ClientSize.Width - 40, Me.ClientSize.Height - 80)
        DataGridJobs.Visible = True
        DataGridJobs.BringToFront()
    End Sub

    Private Sub PrintToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem1.Click
        PrintDocument1.Print()
        'PrintPreviewDialog1.Document = PrintDocument1
        'If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
        '    PrintDocument1.Print()
        'End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog1.Document = PrintDocument1
        If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog1.Document = PrintDocument1
        If PageSetupDialog1.ShowDialog() = DialogResult.OK Then
            Dim margins As Printing.Margins = PrintDocument1.DefaultPageSettings.Margins
            Dim paperSize As PaperSize = PrintDocument1.DefaultPageSettings.PaperSize
            Dim isLandscape As Boolean = PrintDocument1.DefaultPageSettings.Landscape
        End If
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
        ' Prints the inside of the form's client area, excluding borders and title bar, scaled to the
        ' paper's printable area.
        ' TODO: See what fits on one page and handle multiple pages if needed. Set captureWidth and captureHeight
        ' based on e.PageBounds and e.MarginBounds.
        mReportGenerator.ReportGenerate(sender, e)
        Exit Sub
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
        Dim scaledBitmap As New Bitmap(e.MarginBounds.Width, e.MarginBounds.Height)
        Using g As Graphics = Graphics.FromImage(scaledBitmap)
            g.DrawImage(croppedBitmap, New Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height))    ' Scale to paper printable area (inside margins).
        End Using
        e.Graphics.DrawImage(scaledBitmap, e.MarginBounds.Left, e.MarginBounds.Top)  ' Center the image within the page margins
        formBitmap.Dispose()
        croppedBitmap.Dispose()
        e.HasMorePages = False
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument.Print()
        'PrintPreviewDialog1.Document = PrintDocument1
        'If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
        '    PrintDocument1.Print()
        'End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog.Document = PrintDocument
        If PrintPreviewDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument.Print()
        End If
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog.Document = PrintDocument
        If PageSetupDialog.ShowDialog() = DialogResult.OK Then
            Dim margins As Printing.Margins = PrintDocument.DefaultPageSettings.Margins
            Dim paperSize As PaperSize = PrintDocument.DefaultPageSettings.PaperSize
            Dim isLandscape As Boolean = PrintDocument.DefaultPageSettings.Landscape
            If ResizeToPagePounds Then FormResizeTo(PageSetupDialog.Document)
        End If
    End Sub

#End Region
#Region "Form Menu Events"
    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
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
        LetterheadSelect()
    End Sub


    Private Sub EditPasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        SendKeys.Send("^V")
    End Sub

    Private Sub ElementsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ElementsToolStripMenuItem.DropDownOpening
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

    Private Sub FileCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Dim unused = ReportClose()
    End Sub


    Private Sub FileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        CloseForm(Me)
    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ReportSave()
    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ReportSave(ReportNameInput())
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
        Dim clickedItem As ToolStripItem = TryCast(sender, ToolStripMenuItem)
        If clickedItem IsNot Nothing Then Report = clickedItem.Text
    End Sub

    Private Sub ReportsEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsEditToolStripMenuItem.Click
        ReportEditorOpen()
    End Sub
#End Region
#Region "Context Menu Events"
    Private Sub ReportContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles ReportContextMenuStrip.Opening
        ContextMenuMenuItemsEnable()
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
End Class