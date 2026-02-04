Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports Hale_MRI.ReportGenerator
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports Newtonsoft.Json.Linq

''' <summary>
''' Class that manages report Opening, Closing, Editing, 
''' Printing and Database currency.
''' </summary>
Public Class FrmReports
    Inherits FrmDatabaseForm
    ' This form serves as a palette for displaying and 
    ' printing report elements (charts, graphs, tables, etc).
    ' NOTE:
    '     This form only manages itself and its own controls 
    '     (e.g. menus, form size, header, letterhead) and 
    '     maintains database currency with respect to report 
    '     layouts. The visual elements are managed by the
    '     ReportGenerator (e.g. control visibility, size, 
    '     location, drag/drop, editing and print rendering). 
    '     This form should not modify any ReportControls or 
    '     properties, as this may cause unexpected behavior.
    '     Report elements get their properties and data from
    '     the Reporting module, which must define a delegate
    '     method that must be assigned to the containing 
    '     ReportControls's Data member.
    '     
    '     ReportControl - refers to objects that encapsulate 
    '     report controls (charts, graphs), and are defined
    '     and managed by the ReportGenerator.
    '     
    '     ReportElement - refers to database entities defined
    '     in LibDatabase.Models and managed by this Form.
#Region "Types and Constants"
    ' Header item container type.
    Private Class HeaderItem
        Public Property Control As Control      ' The display control.
        Public ReadOnly Property Id As String   ' The display control's database id - Stored in the Header ReportElement's Data field when visible.
            Get
                Return If(Me.Control IsNot Nothing, Control.Tag, "")
            End Get
        End Property
        Public Property Label As Label          ' The display control's associated Label.
        Public Property MenuItem As ToolStripMenuItem   ' This object's associated ToolStripMenuItem.
        Public Property Visible As Boolean
            Get
                Return If(Me.Control IsNot Nothing, Me.Control.Visible, False)
            End Get
            Set(value As Boolean)
                If Me.Control IsNot Nothing Then Me.Control.Visible = value
                If Me.Label IsNot Nothing Then Me.Label.Visible = value
            End Set
        End Property
        Public Sub New(ctrl As Control, lab As Label, menuItem As ToolStripMenuItem)
            Me.Control = ctrl
            Me.Label = lab
            Me.MenuItem = menuItem
            If menuItem IsNot Nothing Then
                AddHandler menuItem.CheckedChanged, AddressOf Me.HeaderItemToolStripMenuItem_CheckedChanged
            End If
        End Sub
        Private Sub HeaderItemToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs)
            ' Integrates header control visibility and its corresponding
            ' ToolStripMenuItem.Checked state.
            Me.Visible = Me.MenuItem.Checked
        End Sub
    End Class

    Private Const kNewReportName As String = "*New Report*"
#End Region
#Region "Private Members"
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record
    Private mReport As Report = Nothing                     ' The current report.
    Private mReportGenerator As ReportGenerator = Nothing   ' The ReportGenerator for runtime report layout and formatting.
    Private mResizeToPagePounds As Boolean = False          ' Indicates whether this form is sized to the current printer page size.
#End Region
#Region "Public Interface"
    ' <summary>
    ' Returns the currently selected JobDetail,
    ' or Nothing if there is no selected record.
    ' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(ReportDataBindingSource)
        End Get
    End Property

    ' <summary>
    ' Sets or gets the database context for this form.
    ' </summary>
    Public Overrides Property Database As HaleMRIContext

    ' <summary>
    ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
    ' </summary>
    ' <returns></returns>
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
            End If
        Next
    End Sub

    Private Sub ElementsToolStripMenuInitialize()
        ' Populate the Elements menu with all available ReportControls.
        For Each rc As ReportGenerator.ReportControl In mReportGenerator.ReportControls
            If Not (rc.Name = "Header" Or rc.Name = "Letterhead") Then
                Dim elementMenuItem As ToolStripMenuItem = Me.ElementsToolStripMenuItem.DropDownItems.Add(rc.Name)
                AddHandler elementMenuItem.Click, AddressOf Me.ReportsElementsToolStripMenuItem_Click
                AddHandler rc.Control.MouseDown, AddressOf Me.Control_MouseDown
            End If
        Next
    End Sub

    Private Sub FileDropDownOpening()
        ' Enables File menu items according to the current Report.
        CloseToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveAsToolStripMenuItem.Enabled = Me.Report IsNot Nothing
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

    Private Sub HeaderControlShow(ByVal show As Boolean)
        ' Adjust the Report layout to make room for the Header.

    End Sub

    Private Sub HeaderInitialize()
        ' This creates a list of HeaderItems from the controls in
        ' the HeaderLayoutPanel automatically, eliminating the need
        ' to initialize a list manually. Adding/removing header
        ' controls is done entirely at design time, requiring no
        ' additional code.
        Dim headerControls As List(Of Control) = Header.Controls.Cast(Of Control)().
            OrderByDescending(Function(c) c.TabStop).
            ThenBy(Function(c) c.TabIndex).
            ToList()
        HeaderItems = New Dictionary(Of String, HeaderItem)
        For Each ctrl As Control In headerControls
            If TypeOf ctrl IsNot Label Then
                Dim lab As Label = Header.Controls.OfType(Of Label)().FirstOrDefault(Function(c) c.Tag IsNot Nothing AndAlso c.Tag.ToString() = ctrl.Name.ToString())
                If lab IsNot Nothing Then
                    Dim menuItem As ToolStripMenuItem = HeaderToolStripMenuItem.DropDownItems.Add(lab.Text)
                    AddHandler menuItem.Click, AddressOf HeaderItemToolStripMenuItem_Click
                    HeaderItems.Add(lab.Text, New HeaderItem(ctrl, lab, menuItem))
                End If
            End If
        Next
    End Sub

    Private Property HeaderItems As Dictionary(Of String, HeaderItem)   ' Stores a list of all available header controls and their states.

    Private Sub HeaderItemToggle(menuItem As ToolStripMenuItem)
        ' Checks/unchecks header menus items according to their
        ' corresponding control's current visibility.
        Dim headerItem As HeaderItem = HeaderItems(menuItem.Text)
        menuItem.Checked = Not menuItem.Checked
        headerItem.Visible = menuItem.Checked
    End Sub

    Private Sub HeaderDropDownOpening()
        ' Checks/unchecks Header dropdown items according to 
        ' their current visibility.
        Dim visibleItems As List(Of HeaderItem) =
            HeaderItems.Values.Where(Function(hi) hi.Visible).ToList()
        For Each item As ToolStripMenuItem In HeaderToolStripMenuItem.DropDownItems
            item.Checked = visibleItems.Any(Function(hi) hi.Label.Text = item.Text)
        Next
    End Sub

    Private Sub HeaderControlToggle()
        ' Toggles the visibility of the Header ReportControl (the layout panel)
        ' and enables the Header drop down items accordingly.
        Dim rc As ReportGenerator.ReportControl = mReportGenerator.ReportControls.First(Function(c) c.Name = "Header")
        HeaderToolStripMenuItem.Checked = Not HeaderToolStripMenuItem.Checked
        If HeaderToolStripMenuItem.Checked Then
            mReportGenerator.ControlShow(rc)
        Else
            mReportGenerator.ControlHide(rc)
        End If
        For Each item As ToolStripItem In HeaderToolStripMenuItem.DropDownItems
            If TypeOf item Is ToolStripMenuItem Then
                item.Enabled = HeaderToolStripMenuItem.Checked
            End If
        Next
    End Sub

    Private Sub JobsDropDownOpening()
        JobsCloseToolStripMenuItem.Enabled = Me.JobDetails IsNot Nothing
    End Sub

    Private Sub LetterheadControlShow(ByVal show As Boolean)
        ' Adjust the Report layout to make room for the Letterhead.
        mReportGenerator.VerticalLimit = Math.Max(Me.Controls("Letterhead").Bounds.Bottom, mReportGenerator.VerticalLimit)
    End Sub

    Private Sub LetterheadFileOpen(ByVal fileName As String)
        ' Loads the selected image file into the letterhead
        ' PictureBox and removes the border.
        Dim selectedImage As Image = Image.FromFile(fileName)
        Letterhead.Image = selectedImage
        Letterhead.BorderStyle = BorderStyle.None
        mReport.ReportElements.First(Function(lh) lh.ElementName = "Letterhead").Data = fileName
    End Sub

    Private Sub LetterheadFileSelect()
        ' Opens a file dialog allowing the user to select the
        ' letterhead image file.
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = STR_DIALOG_FILTER_IMAGE,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            LetterheadFileOpen(openFileDialog1.FileName)
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
        ' Not used - may want to hide context menus and other forms when certain events occur.
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
        Dim scaledBitmap As New Bitmap(e.MarginBounds.Width, e.MarginBounds.Height)
        Using g As Graphics = Graphics.FromImage(scaledBitmap)
                g.DrawImage(croppedBitmap, New Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height))    ' Scale to paper printable area (inside margins).
            End Using
            e.Graphics.DrawImage(scaledBitmap, e.MarginBounds.Left, e.MarginBounds.Top)     ' Center the image within the page margins
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

    Private Sub ReportElementAddNew(rc As ReportGenerator.ReportControl)
        ' Adds a new ReportElement to the current Report with the given ReportControls properties.
        mReport.ReportElements.Add(New ReportElement() With {
            .ElementName = rc.Name,
            .PositionX = rc.Control.Location.X,
            .PositionY = rc.Control.Location.Y,
            .SizeWidth = rc.Control.Size.Width,
            .SizeHeight = rc.Control.Size.Height
        })
    End Sub

    Private Sub ReportElementsLoad(elements As List(Of ReportElement))
        ' Makes the listed ReportElements' corresponding ReportControls and
        ' HeaderItems visible and loads any control data.
        HeaderItems.Values.ToList().ForEach(Sub(hi) hi.MenuItem.Checked = False)
        mReportGenerator.VisibleControls = Nothing
        If elements IsNot Nothing Then
            Dim visibleControls As New List(Of ReportGenerator.ReportControl)()
            For Each reportElement As ReportElement In elements
                Dim reportControl As ReportGenerator.ReportControl = mReportGenerator.ReportControls.FirstOrDefault(Function(ce) ce.Name = reportElement.ElementName)
                ' The Header and Letterhead controls have additional requirements
                ' not handled by the ReportGenerator, so we handle them here.
                Select Case reportControl.Name
                    Case "Letterhead"
                        LetterheadControlShow(True)
                        If reportElement.Data IsNot Nothing Then LetterheadFileOpen(reportElement.Data)
                    Case "Header"
                        If reportElement.Data IsNot Nothing Then
                            Dim itemList As List(Of String) = reportElement.Data.Split(";"c).ToList()
                            Dim visibleItems As List(Of HeaderItem) =
                                HeaderItems.Values.
                                Where(Function(hi) itemList.Contains(hi.Id)).
                                ToList()
                            visibleItems.ForEach(Sub(hi) hi.MenuItem.Checked = True)
                        End If
                        HeaderControlShow(True)
                        mReportGenerator.VerticalLimit = Math.Max(Me.Controls("Header").Bounds.Bottom, mReportGenerator.VerticalLimit)
                    Case Else
                End Select
                ' Initially set the control's location and size, 
                ' and add it to the list of visible controls.
                reportControl.Control.Location = New Point(reportElement.PositionX, reportElement.PositionY)
                reportControl.Control.Size = New Size(reportElement.SizeWidth, reportElement.SizeHeight)
                visibleControls.Add(reportControl)
            Next
            mReportGenerator.VisibleControls = visibleControls
        End If
    End Sub

    Private Sub ReportElementsUpdate()
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
                ReportElementUpdate(re, rc)
            Else
                ReportElementAddNew(rc)
            End If
        Next
    End Sub

    Private Function ReportElementToControl(ByVal elem As ReportElement, ByVal from As List(Of ReportGenerator.ReportControl)) As ReportGenerator.ReportControl
        ' Returns a ReportElement's corresponding ReportControl.
        Return from.FirstOrDefault(Function(rc) rc.Name = elem.ElementName)
    End Function

    Private Sub ReportElementToggle(ByRef menuItem As ToolStripMenuItem)
        ' Toggles the visibility of the ReportControl referenced
        ' by the given menuItem and sets the menuItem.Checked 
        ' state accordingly.
        Dim item As ToolStripMenuItem = menuItem
        Dim rc As ReportGenerator.ReportControl = mReportGenerator.ReportControls.First(Function(c) c.Name = item.Text)
        menuItem.Checked = Not menuItem.Checked
        If menuItem.Checked Then
            mReportGenerator.ControlShow(rc)
        Else
            mReportGenerator.ControlHide(rc)
        End If
    End Sub
    Private Sub ReportElementUpdate(ByRef re As ReportElement, ByVal rc As ReportGenerator.ReportControl)
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
        If re.Zorder <> rc.ZOrder Then
            re.Zorder = rc.ZOrder
        End If
    End Sub

    Private Sub ReportExport()
        ' Exports a Report as a csv file.
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
        ' Read a Report and layout data from a csv file and
        ' adds it to the database.
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
        ' Returns a new ReportElement created from a list of strings.
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
        ' Returns a new Report created from a list of strings.
        Return New Report() With {
            .ReportName = values(0),
            .LastModifed = Date.Now,
            .ModifiedBy = Me.User.Id,
            .GridSize = Integer.Parse(values(1))
        }
    End Function

    Private Sub ReportGeneratorInitialize()
        ' Initialize the ReportGenerator.
        ' Note: HeaderItems have been removed from the ReportGenerator
        ' and are now handled by this form automatically.
        ' We only need to initialize the ReportControls and that's it.
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
            }
        }
    End Sub

    Private Sub ReportHeaderUpdate(ByRef he As ReportElement, ByVal hc As ReportGenerator.ReportControl)
        If hc IsNot Nothing Then
            ' If the Header control is visible
            Dim hcItems As List(Of String) =
                HeaderItems.Values.Where(Function(hi) hi.Visible).Select(Function(hi) hi.Id).ToList()
            ' Either add it to the Report, or ...
            If he Is Nothing Then
                ReportElementAddNew(hc)
            Else
                Dim heItems As List(Of String) = If(he.Data IsNot Nothing, he.Data.Split(";"c).ToList, New List(Of String))
                ' ... update its properties.
                If Not hcItems.SequenceEqual(heItems) Then
                    he.Data = String.Join(";", hcItems)
                End If
            End If
        End If
    End Sub

    Private Sub ReportImport()
        ' Imports a Report from a csv file.
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

    Private Sub ReportMetadataUpdate()
        mReport.LastModifed = Now
        mReport.ModifiedBy = Me.User.Id
    End Sub

    Private Function ReportNameInput() As String
        ' Prompt user for a Report name.
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
        ' Open a Report record by name.
        Dim result As Report = Nothing
        If Not String.IsNullOrEmpty(reportName) Then
            result = Database.Reports _
                .Include(Function(r) r.ReportElements) _
                .FirstOrDefault(Function(r) r.ReportName = reportName.ToString())
            ReportDataGet() ' See function for explanation.
        End If
        Return result
    End Function

    Private Sub ReportPropertiesUpdate()
        If mReport.GridSize <> mReportGenerator.GridSize Then mReport.GridSize = mReportGenerator.GridSize
    End Sub

    Private Sub ReportToFile(fileName As String)
        ' Writes the current Report and layout data to a csv file.
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
                ' Set form bounds to the screen working area.
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
        ' Update ReportElements in the database. Remove any hidden elements from the Report,
        ' add any visible elements not in the Report, and check element properties for
        ' changes.

        ' If this is a new unsaved report, save it now so we get a valid ReportId.
        If mReport.Id Is Nothing Then
            Database.SaveChanges()
        End If

        ' Update the Report.ReportElements to contain only the currently visible ReportControls.
        ReportElementsUpdate()

        ' Update header items.
        Dim headerControl As ReportGenerator.ReportControl = mReportGenerator.VisibleControls.FirstOrDefault(Function(rc) rc.Name = "Header")
        Dim headerElement As ReportElement = mReport.ReportElements.FirstOrDefault(Function(re) re.Report Is mReport And re.ElementName = "Header")
        ReportHeaderUpdate(headerElement, headerControl)

        ' Update Report properties.
        ReportPropertiesUpdate()

        ' Update report metadata if anything changed.
        If Database.ChangeTracker.HasChanges() Then
            ReportMetadataUpdate()
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
    ' Some (most) of these need Try blocks!!!
    ' Change the method name for clarity, I just
    ' used the auto-generated names, which are,
    ' of course, stoopid.
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
        ElementsToolStripMenuInitialize()
        HeaderInitialize()
        ' These set the form size to the default printer paper size. Not strictly necessary.
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

    Private Sub ElementsLetterheadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetterheadToolStripMenuItem.Click
        Try
            LetterheadFileSelect()
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

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        FileDropDownOpening()
    End Sub

    Private Sub HeaderToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles HeaderToolStripMenuItem.DropDownOpening
        HeaderDropDownOpening()
    End Sub

    Private Sub ReportsElementsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportElementToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderItemToolStripMenuItem_Click(sender As Object, e As EventArgs)
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeaderToolStripMenuItem.Click
        HeaderControlToggle()
    End Sub

    Private Sub JobsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles JobsToolStripMenuItem.DropDownOpening
        JobsDropDownOpening()
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
        ' FrmReports.ChartAngularPosition, etc., but can only work with one control at a time. For instance, I
        ' copied the code for Reporting.ChartBladeHeight() from FrmMeasurements.ShowTrack(), but it seems we're
        ' doing several things at once in FrmMeasurements.ShowTrack() on two graphs, so that will have to be
        ' split up into two separate methods. Once that's done, you can just call Reporting.ChartBladeHeight()
        ' from FrmMeasurements.ShowTrack(), passing the args in a ReportDataArgs guy (in FrmMeasurements.ShowTrack()
        ' you would call directly:
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
        ' If reports supports control settings (like Reference Blade, Point, Radius, etc.) we will have to provide
        ' the controls and any args from them. The display control and any additional settings controls can be put
        ' into a GroupBox, which then becomes the containing ReportControl object.
        ' I just hardcoded some values to demonstrate the calls.
        Dim rc As ReportGenerator.ReportControl = mReportGenerator.ReportControls.First(Function(ctrl) ctrl.Name = "ChartBladeHeight")
        rc.Data.DynamicInvoke(ChartBladeHeight, New ReportDataArgs(1, "Mid", 49.99, JobDetails))
        rc.HasData = True
        ' Note that I use 'First' not 'FirstOrDefault' to get the ReportControl by Name and there is
        ' no If rc Is Nothing Then. This is because it would be a design-time error (misnamed objects)
        ' to return nothing and the additional overhead is unwarranted.
        rc = mReportGenerator.ReportControls.First(Function(ctrl) ctrl.Name = "ChartAngularPosition")
        rc.Data.DynamicInvoke(ChartAngularPosition, New ReportDataArgs(1, "Mid", 49.99, JobDetails))
        rc.HasData = True

        ' This does create some redundancy in the calls, esp in FrmMeasurements.ShowTrack()
        ' when calling ShowRake(). I'll see if there's a way to make it more efficient.
    End Sub
#End Region
End Class