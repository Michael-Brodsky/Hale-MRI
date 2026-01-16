Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports System.Drawing.Printing

Public Class FrmReports
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mAllElements As List(Of Control) = Nothing              ' The list of all available report elements.
    Private mControlIsDeleted As Boolean = False                    ' Flag indicating if a control is being deleted.   
    Private mCurrentElements As List(Of ReportElement) = Nothing    ' The list of currently loaded report elements.
    Private mCutControl As Control = Nothing                        ' The control being cut. 
    Private mJobDetails As JobDetail                                ' The current JobDetail record
    Private mJob As Job                                             ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing                ' The form's "master" BindingSource.
    Private mReport As String = ""                                  ' The currently loaded report.
    Private mReportGenerator As ReportGenerator = Nothing           ' The ReportGenerator for runtime form layout and formatting.
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the BindingSource for the measurement data displayed in the report.
    ''' </summary>
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(MeasurementDataBindingSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext
    ''' <summary>
    ''' Loads all JobDetails and their Cell, Extreme and RadiusMeasurements
    ''' for the given Job.
    ''' </summary>
    ''' <returns></returns>
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                ' These are for the Job selection datagrid.
                EmployeeBindingSource.DataSource = Database.Employees.Local.ToBindingList()
                JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails.OrderBy(Function(m) m.JobId).ThenBy(Function(m) m.MeasurementTypeId).ToList())
                MeasurementTypeBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList()
                ' This is the JobDetails data for the report.
                MeasurementDataBindingSource.DataSource = GetMeasurementData(mJob.JobDetails.FirstOrDefault())
            End If
        End Set
    End Property

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
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                ' These are for the Job selection datagrid.
                EmployeeBindingSource.DataSource = Database.Employees.Local.ToBindingList()
                JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails.OrderBy(Function(m) m.JobId).ThenBy(Function(m) m.MeasurementTypeId).ToList())
                MeasurementTypeBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList()
                ' This is the JobDetails data for the report.
                MeasurementDataBindingSource.DataSource = GetMeasurementData(mJobDetails)
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Protected Overrides Property MasterSource As BindingSource

    Private Sub ChartLoad()

    End Sub

    Private Sub ContextMenuStripShow(sender As Object, e As MouseEventArgs)
        ' Enables/disables context menu items based on the current state.
        If e.Button = MouseButtons.Right Then
            For Each item As ToolStripItem In ContextMenuStrip1.Items
                item.Enabled = False
            Next
            ' If there is a cut control, enable Paste and Undo
            If mCutControl IsNot Nothing Then
                PasteToolStripMenuItem1.Enabled = Not mControlIsDeleted
                UndoToolStripMenuItem.Enabled = True
            Else
                ' No cut control, enable Add, Cut, Delete, Select All.   
                AddNewToolStripMenuItem.Enabled = True
                CutToolStripMenuItem1.Enabled = sender IsNot Me
                DeleteToolStripMenuItem1.Enabled = sender IsNot Me
                SelectAllToolStripMenuItem.Enabled = True
            End If
            ' Show the context menu at the mouse location.
            Dim ctrl As Control = CType(sender, Control)
            If sender Is Me Then
                ContextMenuStrip1.Show(Me, e.Location)
            Else
                ContextMenuStrip1.Show(ctrl, e.Location)
            End If
        Else
            ContextMenuStrip1.Hide()
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
        ElementMenuItemsUpdate(ctrl, visible)
    End Sub

    Protected Overrides Sub BindDataSources()
        ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
        MasterSource = MeasurementDataBindingSource
        MyBase.BindDataSources()
    End Sub

    Private Sub DataSourcesInitialize()
        'ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
        'MasterSource = MeasurementDataBindingSource
    End Sub

    Private Sub ElementMenuItemsUpdate(ctrl As Control, isVisible As Boolean)
        Dim elementsMenu As ToolStripMenuItem = ElementsToolStripMenuItem
        Dim addnewContextMenu As ToolStripMenuItem = AddNewToolStripMenuItem
        For Each item In elementsMenu.DropDownItems
            If TypeOf item IsNot ToolStripMenuItem Then Continue For
            If item.Text = ctrl.Name Then
                item.Checked = isVisible
                Exit For
            End If
        Next
        For Each item As ToolStripMenuItem In addnewContextMenu.DropDownItems
            If TypeOf item IsNot ToolStripMenuItem Then Continue For
            If item.Text = ctrl.Name Then
                item.Enabled = Not isVisible
                Exit For
            End If
        Next
    End Sub

    Private Sub ElementsToolStripMenuIntialize()
        ' Initializes the Elements and AddNew menus with available report elements.
        Dim elementsMenu As ToolStripMenuItem = ElementsToolStripMenuItem
        Dim addnewContextMenu As ToolStripMenuItem = AddNewToolStripMenuItem
        For Each ctrl In mAllElements
            Dim elementsItem As New ToolStripMenuItem(ctrl.Name)
            If Not (ctrl.Name = "Letterhead" Or ctrl.Name = "Header") Then
                elementsMenu.DropDownItems.Add(elementsItem)
                AddHandler elementsItem.Click, AddressOf ElementsItemClickHandler
            End If
            Dim addnewItem As New ToolStripMenuItem(ctrl.Name)
            If Not (ctrl.Name = "Letterhead" Or ctrl.Name = "Header") Then
                addnewContextMenu.DropDownItems.Add(addnewItem)
                AddHandler addnewItem.Click, AddressOf ElementsItemClickHandler
            End If
        Next
    End Sub

    Private Function GetMeasurementData(ByVal jobDetails As JobDetail) As BindingList(Of JobDetail)
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
        SortMeasurementData(data)
        Return data
    End Function

    Private Sub HeaderItemToggle(sender As Object, e As EventArgs)
        ' Toggles the visibility of header elements.
        Dim clickedItem = TryCast(sender, ToolStripMenuItem)
        If clickedItem IsNot Nothing Then
        End If
    End Sub

    Private Property Report As String
        Get
            Return mReport
        End Get
        Set(value As String)
            Dim reportElements As List(Of ReportElement)
            mReport = value
            If Not String.IsNullOrEmpty(mReport) Then
                ' Load report layout and formatting
                reportElements = New List(Of ReportElement)(
                    Database.ReportElements _
                        .Where(Function(re) re.Report.ReportName = mReport) _
                        .Include(Function(re) re.Report) _
                        .ToList())
                Me.Text = "Reports - " & mReport
            Else
                ' Clear report layout and formatting
                reportElements = New List(Of ReportElement)()
                Me.Text = "Reports"
            End If
            ReportLoad(reportElements)
        End Set
    End Property

    Private Sub ReportAddNew()
        ' Prompt the user for a new report name and add it to the database.
        FrmInputBox.Text = "Add New Report"
        FrmInputBox.Prompt = "Enter the name of the new report:"
        FrmInputBox.InputText = ""
        Dim result As DialogResult = FrmInputBox.ShowDialog()
        If result = DialogResult.OK Then
            Dim newReportName As String = FrmInputBox.InputText.Trim()
            If Not String.IsNullOrEmpty(newReportName) Then
                Dim newReport As New Report() With {
                    .ReportName = newReportName,
                    .IsDefault = False,
                    .LastModifed = DateTime.Now,
                    .ModifiedBy = User?.Id
                }
                Database.Reports.Add(newReport)
                Database.SaveChanges()  ' Only save the new Report.
                Dim reportsMenu As ToolStripMenuItem = ReportsToolStripMenuItem
                Dim subItem As New ToolStripMenuItem(newReport.ReportName)
                reportsMenu.DropDownItems.Insert(reportsMenu.DropDownItems.Count - 2, subItem)
                AddHandler subItem.Click, AddressOf ReportsItemClickHandler
                'ReportBindingSource.ResetBindings(False)
                'ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
                Report = newReportName
            End If
        End If
    End Sub

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

    Private Sub ReportElementPaste()
        If mCutControl IsNot Nothing Then
            ' Add the control to the new destination.
            ' The location properties (Top, Left) are preserved
            mCutControl.Location = mReportGenerator.PasteLocation
            ControlVisible(mCutControl, True, True)
            mReportGenerator.ReportControls = mReportGenerator.ReportControls ' This sorts the controls by top, left position
            'Database.ReportElements.Add(New ReportElement() With {
            '    .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
            '    .ElementName = mCutControl.Name,
            '    .PositionX = mReportGenerator.PasteLocation.X,
            '    .PositionY = mReportGenerator.PasteLocation.Y,
            '    .SizeWidth = mCutControl.Size.Width,
            '    .SizeHeight = mCutControl.Size.Height
            '})
            ' Clear the storage variable
            mCutControl = Nothing
        End If
    End Sub

    Private Sub ReportElementUndo()
        If mCutControl IsNot Nothing Then
            ' Add the control to the new destination container
            ' The location properties (Top, Left) are preserved
            ControlVisible(mCutControl, True)
            'mCutControl.Location = mReportGenerator.PasteLocation
            mReportGenerator.ReportControls = mReportGenerator.ReportControls ' This sorts the controls by top, left position
            'Database.ReportElements.Add(New ReportElement() With {
            '    .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
            '    .ElementName = mCutControl.Name,
            '    .PositionX = mCutControl.Location.X,
            '    .PositionY = mCutControl.Location.Y,
            '    .SizeWidth = mCutControl.Size.Width,
            '    .SizeHeight = mCutControl.Size.Height
            '})
            ' Clear the storage variable
            mCutControl = Nothing
        End If
    End Sub

    Private Sub ReportElementUpdate(ctrl As Control)
        Dim elementToUpdate As ReportElement = ReportElementGet(ctrl)
        With elementToUpdate
            .PositionX = ctrl.Location.X
            .PositionY = ctrl.Location.Y
            .SizeWidth = ctrl.Size.Width
            .SizeHeight = ctrl.Size.Height
        End With
    End Sub

    Private Sub ReportControlsInitialize()
        ' All available report elements must be listed here before setting the Report property.
        ' ADD NEW ELEMENTS HERE. Create the element, hook it up, and add it to mAllElements.
        mAllElements = New List(Of Control) From {
            Letterhead,
            Header,
            Chart1,
            Chart2,
            Chart3,
            Chart4,
            Chart5,
            Chart6,
            Chart7,
            Chart8,
            GrdRadiiAverages,
            GrdChordLength
        }
    End Sub

    Private Sub ReportGeneratorInitialize()
        ' Initialize the ReportGenerator and set up event handlers for all report elements.
        mReportGenerator = New ReportGenerator() With {
            .ParentForm = Me,
            .HorizontalLimit = 10,
            .VerticalLimit = MenuStrip1.Height
        }
    End Sub

    Private Sub ReportLoad(elements As List(Of ReportElement))
        For Each ctrl As Control In mAllElements
            ControlVisible(ctrl, False)
        Next
        For Each re As ReportElement In elements
            Dim control As Control = mAllElements.FirstOrDefault(Function(ce) ce.Name = re.ElementName)
            If control IsNot Nothing Then
                control.Location = New Point(re.PositionX, re.PositionY)
                control.Size = New Size(re.SizeWidth, re.SizeHeight)
                ControlVisible(control, True)
            End If
        Next
        mReportGenerator.ReportControls = mReportGenerator.ReportControls
    End Sub

    Private Sub ReportSave()
        Database.SaveChanges()
    End Sub

    Private Sub ReportSaveAs()
        ' Not implemented

    End Sub
    Private Sub ReportsToolStripMenuIntialize()
        ' Populate the Reports menu with available reports from the database.
        Dim reportsMenu As ToolStripMenuItem = ReportsToolStripMenuItem
        For Each rpt As Report In ReportBindingSource
            Dim subItem As New ToolStripMenuItem(rpt.ReportName)
            reportsMenu.DropDownItems.Add(subItem)
            AddHandler subItem.Click, AddressOf ReportsItemClickHandler
        Next
        If ReportBindingSource.Count > 0 Then
            Dim separatorItem As New ToolStripSeparator()
            reportsMenu.DropDownItems.Add(separatorItem)
        End If
        Dim addNewItem As New ToolStripMenuItem("Add New")
        reportsMenu.DropDownItems.Add(addNewItem)
        AddHandler addNewItem.Click, AddressOf ReportsItemClickHandler
    End Sub

    Private Sub ShowHeader(ByVal j As Job)
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = If(Database.Manufacturers.Local.FirstOrDefault(Function(mfr) mfr.Id = If(Job?.PropellerManufacturerId, 0))?.ManufacturerName, "")
        TxtPartNumber.Text = Job?.PropellerPartNumber
        TxtSerialNumber.Text = Job?.SerialNumber
        TxtStampNumber.Text = Job?.StampNumber
        TxtInspectedBy.Text = Database.Employees.Local.FirstOrDefault(Function(emp) emp.Id = If(Job?.InspectedBy, 0))?.EmployeeName

        TxtJobId.Text = If(JobDetails?.Id, "").ToString()
        TxtClass.Text = JobDetails?.ToleranceClass
        TxtRepairStatus.Text = Database.MeasurementTypes.Local.FirstOrDefault(Function(mt) mt.Id = If(JobDetails?.MeasurementTypeId, 0))?.MeasurementType1
        TxtStyle.Text = Job?.PropellerStyle
        TxtMaterial.Text = Job?.PropellerMaterial
        TxtBore.Text = Job?.PropellerBore
        TxtDAR.Text = Job?.Dar.ToString()
        TxtCup.Text = Job?.Cup.ToString()

        TxtFileName.Text = JobDetails?.FileName
        TxtScanDate.Text = If(JobDetails?.StartDate, "").ToString()
        TxtPerformedBy.Text = Database.Employees.Local.FirstOrDefault(Function(emp) emp.Id = If(JobDetails?.PerformedBy, 0))?.EmployeeName
        TxtRotation.Text = Job?.PropellerRotation
        TxtMarkedDiameter.Text = If(Job?.PropellerDiameter, "").ToString()
        TxtMeasuredDiameter.Text = "" ' New field added to Job model but not yet implemented
        TxtMarkedPitch.Text = If(Job?.MarkedPitch, "").ToString()
        TxtWheelPitch.Text = If(JobDetails?.WheelPitch, "").ToString()
    End Sub

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

    Private Sub ElementsItemClickHandler(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click, ToolStripMenuItem7.Click
        Dim clickedItem = TryCast(sender, ToolStripMenuItem)
        If clickedItem IsNot Nothing Then
            Dim control = mAllElements.FirstOrDefault(Function(ce) ce.Name = clickedItem.Text.ToString())
            If control IsNot Nothing Then
                If control.Visible Then
                    ControlVisible(control, False, True)
                Else
                    ReportElementAddNew(control, clickedItem)
                End If
            End If
        End If
    End Sub

    Private Sub HeaderItemClickHandler(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click, ToolStripMenuItem9.Click, ToolStripMenuItem10.Click, ToolStripMenuItem11.Click, ToolStripMenuItem12.Click, ToolStripMenuItem13.Click, ToolStripMenuItem14.Click, ToolStripMenuItem15.Click, ToolStripMenuItem16.Click, ToolStripMenuItem17.Click, ToolStripMenuItem18.Click, ToolStripMenuItem19.Click, ToolStripMenuItem20.Click, ToolStripMenuItem21.Click, ToolStripMenuItem22.Click, ToolStripMenuItem23.Click, ToolStripMenuItem24.Click, ToolStripMenuItem25.Click, ToolStripMenuItem26.Click, ToolStripMenuItem27.Click, ToolStripMenuItem28.Click, ToolStripMenuItem29.Click, ToolStripMenuItem30.Click, ToolStripMenuItem31.Click
        HeaderItemToggle(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FrmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridJobs.AutoGenerateColumns = False
        'DataSourcesInitialize()
        ReportsToolStripMenuIntialize()
        ReportGeneratorInitialize()
        ReportControlsInitialize()
        ElementsToolStripMenuIntialize()
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

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Prints the inside of the form's client area, excluding borders and title bar, scaled to the
        ' paper's printable area.
        ' TODO: See what fits on one page and handle multiple pages if needed. Set captureWidth and captureHeight
        ' based on e.PageBounds and e.MarginBounds.
        mReportGenerator.ReportGenerate(sender, e)
        Exit Sub
        Dim startX As Integer = Me.Bounds.Width - Me.ClientSize.Width
        Dim startY As Integer = Me.Bounds.Height - Me.ClientSize.Height + MenuStrip1.Height
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

    Private Sub ReportsItemClickHandler(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripItem = TryCast(sender, ToolStripMenuItem)

        If clickedItem IsNot Nothing Then
            If clickedItem.Text = "Add New" Then
                ReportAddNew()
            Else
                Report = clickedItem.Text
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ReportSave()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click

    End Sub

#Region "Dragging the Form"

    Private Sub Control_MouseClick(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseClick(sender, e)
    End Sub

    Private Sub Control_Enter(sender As Object, e As EventArgs)
        mReportGenerator.ControlEnter(sender, e)
    End Sub

    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        If mReportGenerator.ControlKeyDown(sender, e) = Keys.Delete Then
            ReportElementDelete(CType(sender, Control))
        End If
    End Sub

    Private Sub Control_Leave(sender As Object, e As EventArgs)
        mReportGenerator.ControlLeave(sender, e)
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseDown(sender, e)
        DataGridJobs.Visible = False
        If e.Button = MouseButtons.Right Then
            ContextMenuStripShow(sender, e)
        Else
            ContextMenuStrip1.Hide()
        End If
    End Sub

    Private Sub Control_MouseHover(sender As Object, e As EventArgs)
        Dim hoveredControl As Control = CType(sender, Control)

        ' Set and show the tooltip dynamically
        Me.ToolTip1.SetToolTip(hoveredControl, hoveredControl.Name)
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseMove(sender, e)
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseUp(sender, e)
        ReportElementUpdate(CType(sender, Control))
    End Sub

    Private Sub Control_Paint(sender As Object, e As PaintEventArgs)
        mReportGenerator.ControlRepaint(sender, e)
    End Sub

    Private Sub Control_Resize(sender As Object, e As EventArgs)
        mReportGenerator.ControlResize(sender, e)
    End Sub

    Private Sub FrmReports_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'mReportGenerator.ReportRepaint(sender, e)
    End Sub

    Private Sub FrmReports_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        mReportGenerator.FormMouseDown(sender, e)
        DataGridJobs.Visible = False
        ContextMenuStripShow(sender, e)
    End Sub

    Private Sub CutContextMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        ReportElementCut(CType(mReportGenerator.SelectedControl, Control))
    End Sub

    Private Sub DeleteContextMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        ReportElementDelete(CType(mReportGenerator.SelectedControl, Control))
    End Sub

    Private Sub PasteContextMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        ReportElementPaste()
    End Sub

    Private Sub SelectAllContextMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ' Not implemented
    End Sub

    Private Sub UndoContextMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        ReportElementUndo()
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs)
        If Database.ChangeTracker.HasChanges() Then
            Dim result As DialogResult = MessageBox.Show("There are unsaved changes. Do you want to save them before exiting?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ReportSave()
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
        MyBase.Form_Closing(sender, e)
    End Sub

#End Region
#End Region
End Class