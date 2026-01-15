Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports System.Drawing.Printing

Public Class FrmReports
    Inherits FrmDatabaseForm
    Private mAllElements As List(Of Control) = Nothing              ' The list of all available report elements.
    Private mCurrentElements As List(Of ReportElement) = Nothing    ' The list of currently loaded report elements.
    Private mCutControl As Control = Nothing                        ' The control being cut. 
    Private mJobDetails As JobDetail                                ' The current JobDetail record
    Private mJob As Job                                             ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing                ' The form's "master" BindingSource.
    Private mReport As String = ""                                  ' The currently loaded report.
    Private mReportGenerator As ReportGenerator = Nothing           ' The ReportGenerator for runtime form layout and formatting.

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
                EmployeeBindingSource.DataSource = Database.Employees.Local.ToBindingList()
                JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails.OrderBy(Function(m) m.JobId).ThenBy(Function(m) m.MeasurementTypeId).ToList())
                MeasurementTypeBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList()
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
                EmployeeBindingSource.DataSource = Database.Employees.Local.ToBindingList()
                JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails.OrderBy(Function(m) m.JobId).ThenBy(Function(m) m.MeasurementTypeId).ToList())
                MeasurementTypeBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList()
                MeasurementDataBindingSource.DataSource = GetMeasurementData(mJobDetails)
            End If
        End Set
    End Property

    Protected Overrides Property MasterSource As BindingSource
    Private Sub ConfigureChart()

    End Sub

    Private Sub ConfigureControls()

    End Sub

    Private Sub ContextMenuStripShow(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            For Each item As ToolStripItem In ContextMenuStrip1.Items
                item.Enabled = False
            Next
            If mCutControl IsNot Nothing Then
                PasteToolStripMenuItem1.Enabled = True
                UndoToolStripMenuItem.Enabled = True
            Else
                AddNewToolStripMenuItem.Enabled = True
                CutToolStripMenuItem1.Enabled = sender IsNot Me
                DeleteToolStripMenuItem1.Enabled = sender IsNot Me
                SelectAllToolStripMenuItem.Enabled = True
            End If
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

    Private Sub ControlVisible(element As Control, visible As Boolean)
        element.Visible = visible
        If visible Then
            AddHandler element.MouseClick, AddressOf Control_MouseClick
            AddHandler element.Enter, AddressOf Control_Enter
            AddHandler element.KeyDown, AddressOf Control_KeyDown
            AddHandler element.Leave, AddressOf Control_Leave
            AddHandler element.MouseDown, AddressOf Control_MouseDown
            AddHandler element.MouseMove, AddressOf Control_MouseMove
            AddHandler element.MouseUp, AddressOf Control_MouseUp
            AddHandler element.Paint, AddressOf Control_Paint
            AddHandler element.Resize, AddressOf Control_Resize
            mReportGenerator.ReportElements.Add(element)
        Else
            mReportGenerator.ReportElements.Remove(element)
            RemoveHandler element.MouseClick, AddressOf Control_MouseClick
            RemoveHandler element.Enter, AddressOf Control_Enter
            RemoveHandler element.KeyDown, AddressOf Control_KeyDown
            RemoveHandler element.Leave, AddressOf Control_Leave
            RemoveHandler element.MouseDown, AddressOf Control_MouseDown
            RemoveHandler element.MouseMove, AddressOf Control_MouseMove
            RemoveHandler element.MouseUp, AddressOf Control_MouseUp
            RemoveHandler element.Paint, AddressOf Control_Paint
            RemoveHandler element.Resize, AddressOf Control_Resize
        End If
    End Sub

    Private Sub DataSourcesInitialize()
        ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
        MasterSource = MeasurementDataBindingSource
    End Sub

    Private Sub ElementsToolStripMenuIntialize()
        Dim elementsMenu As ToolStripMenuItem = ElementsToolStripMenuItem
        For Each ctrl In mAllElements
            Dim subItem As New ToolStripMenuItem(ctrl.Name)
            elementsMenu.DropDownItems.Add(subItem)
            subItem.Checked = ctrl.Visible
            AddHandler subItem.Click, AddressOf ElementsItemClickHandler
        Next
    End Sub

    Private Function GetMeasurementData(ByVal jobDetails As JobDetail) As BindingList(Of JobDetail)
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
                Database.SaveChanges()
                ReportBindingSource.DataSource = Database.Reports.Local.ToBindingList()
                Report = newReportName
            End If
        End If
    End Sub

    Private Sub ReportElementAddNew(elem As Control, item As ToolStripMenuItem)
        If elem IsNot Nothing Then
            ControlVisible(elem, True)
            mReportGenerator.ControlPositionNew(elem)
            Database.ReportElements.Add(New ReportElement() With {
                .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
                .ElementName = elem.Name,
                .PositionX = elem.Location.X,
                .PositionY = elem.Location.Y,
                .SizeWidth = elem.Size.Width,
                .SizeHeight = elem.Size.Height
            })
            item.Checked = True
            Database.SaveChanges()
        End If
    End Sub

    Private Sub ReportElementCut(ctrl As Control)
        If ctrl IsNot Nothing AndAlso ctrl.Parent IsNot Nothing Then
            ' Store the control in the variable
            mCutControl = ctrl
            ' Remove it from its current parent (this is the "cut" action)
            ControlVisible(ctrl, False)
            ctrl.Parent.Controls.Remove(ctrl)
        End If
    End Sub

    Private Sub ReportElementDelete(ctrl As Control)
        Dim elementToRemove As ReportElement = mCurrentElements.FirstOrDefault(Function(re) re.ElementName = ctrl.Name)
        If elementToRemove IsNot Nothing Then
            Database.ReportElements.Remove(elementToRemove)
            Database.SaveChanges()
            mCurrentElements.Remove(elementToRemove)
            ControlVisible(ctrl, False)
            mReportGenerator.ReportElements.Remove(ctrl)
        End If
    End Sub

    Private Sub ReportElementPaste()
        If mCutControl IsNot Nothing Then
            ' Add the control to the new destination.
            ' The location properties (Top, Left) are preserved
            ControlVisible(mCutControl, True)
            mCutControl.Location = mReportGenerator.PasteLocation
            mReportGenerator.ReportElements = mReportGenerator.ReportElements ' This sorts the controls by top, left position
            Database.ReportElements.Add(New ReportElement() With {
                .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
                .ElementName = mCutControl.Name,
                .PositionX = mReportGenerator.PasteLocation.X,
                .PositionY = mReportGenerator.PasteLocation.Y,
                .SizeWidth = mCutControl.Size.Width,
                .SizeHeight = mCutControl.Size.Height
            })
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
            mReportGenerator.ReportElements = mReportGenerator.ReportElements ' This sorts the controls by top, left position
            Database.ReportElements.Add(New ReportElement() With {
                .Report = Database.Reports.FirstOrDefault(Function(r) r.ReportName = mReport),
                .ElementName = mCutControl.Name,
                .PositionX = mCutControl.Location.X,
                .PositionY = mCutControl.Location.Y,
                .SizeWidth = mCutControl.Size.Width,
                .SizeHeight = mCutControl.Size.Height
            })
            ' Clear the storage variable
            mCutControl = Nothing
        End If

    End Sub

    Private Sub ReportGeneratorInitialize()
        ' Initialize the ReportGenerator and set up event handlers for all report elements.
        mReportGenerator = New ReportGenerator() With {
            .ParentForm = Me,
            .HorizontalLimit = 10,
            .VerticalLimit = MenuStrip1.Height
        }
        ' All available report elements must be listed here before setting the Report property.
        ' ADD NEW ELEMENTS HERE. Create the element, hook it up, and add it to mAllElements.
        mAllElements = New List(Of Control) From {
            HeaderLayoutPanel,
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

    Private Sub ReportLoad(elements As List(Of ReportElement))
        'Dim reportElements As New List(Of Control)
        For Each ctrl As Control In mAllElements
            ControlVisible(ctrl, False)
        Next
        For Each re As ReportElement In elements
            Dim control As Control = mAllElements.FirstOrDefault(Function(ce) ce.Name = re.ElementName)
            If control IsNot Nothing Then
                'reportElements.Add(control)
                ControlVisible(control, True)
                control.Location = New Point(re.PositionX, re.PositionY)
                control.Size = New Size(re.SizeWidth, re.SizeHeight)
            End If
        Next
        mReportGenerator.ReportElements = mReportGenerator.ReportElements
        mCurrentElements = elements
    End Sub

    Private Sub ReportSave()
        For Each elem As Control In mReportGenerator.ReportElements
            Dim reportElement As ReportElement = Database.ReportElements.FirstOrDefault(Function(re) re.Report.ReportName = mReport AndAlso re.ElementName = elem.Name.ToString())
            If reportElement IsNot Nothing Then
                reportElement.PositionX = elem.Location.X
                reportElement.PositionY = elem.Location.Y
                reportElement.SizeWidth = elem.Size.Width
                reportElement.SizeHeight = elem.Size.Height
            End If
        Next
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
#Region "Event Handlers"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub ElementsItemClickHandler(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        If clickedItem IsNot Nothing Then
            Dim elementName As String = clickedItem.Text
            Dim control As Control = mAllElements.FirstOrDefault(Function(ce) ce.Name = elementName)
            ReportElementAddNew(control, clickedItem)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FrmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridJobs.AutoGenerateColumns = False
        DataSourcesInitialize()
        ReportsToolStripMenuIntialize()
        ReportGeneratorInitialize()
        ' Open the default report if one is set.
        Report = If(Database.Reports.FirstOrDefault(Function(dr) dr.IsDefault = True)?.ReportName, "")
        ElementsToolStripMenuIntialize()
    End Sub

    Private Sub ListReports_DoubleClick(sender As Object, e As EventArgs) Handles ListReports.DoubleClick
        Dim selectedReport = CType(ListReports.SelectedItem, Report)
        Report = selectedReport.ReportName
        DataGridJobs.Visible = False
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
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

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseMove(sender, e)
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlMouseUp(sender, e)
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

    Private Sub AddNewContextMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        'Not implemented. Needs a flyout menu of available elements.    
    End Sub

    Private Sub CutContextMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        mCutControl = mReportGenerator.SelectedControl
        ControlVisible(mCutControl, False)
        Database.ReportElements.Remove(
            Database.ReportElements.FirstOrDefault(Function(re) re.Report.ReportName = mReport AndAlso re.ElementName = mCutControl.Name)
        )
    End Sub

    Private Sub DeleteContextMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        ReportElementDelete(CType(mReportGenerator.SelectedControl, Control))
    End Sub

    Private Sub PasteContextMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        ReportElementPaste()
    End Sub

    Private Sub SelectAllContextMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click

    End Sub

    Private Sub UndoContextMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        ReportElementUndo()
    End Sub

#End Region
#End Region
End Class