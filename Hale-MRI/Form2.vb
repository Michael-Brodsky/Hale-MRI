Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports System.Drawing.Printing
Imports System.Numerics

Public Class Form2
    Inherits FrmDatabaseForm

    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mReportGenerator As ReportGenerator = Nothing

    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
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
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJob.JobDetails.FirstOrDefault())
                ShowHeader(mJob)
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
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJobDetails)
                ShowHeader(mJob)
            End If
        End Set
    End Property

    Protected Overrides Property MasterSource As BindingSource

    Private Sub ConfigureChart()
        'ChartBladeHeight.ChartAreas.Clear()
        'ChartBladeHeight.Series.Clear()
        'ChartBladeHeight.Titles.Clear()
        'Dim chartArea1 As New ChartArea()
        'ChartBladeHeight.ChartAreas.Add(chartArea1)
        'ChartBladeHeight.Titles.Add("Blade Height")
    End Sub

    Private Sub ConfigureControls()
        mReportGenerator = New ReportGenerator(New List(Of Control) From {
            Chart1,
            Chart2,
            Chart3
        })
        ControlVisible(Chart1, True)
        ControlVisible(Chart2, True)
        ControlVisible(Chart3, True)
    End Sub

    Private Sub ControlVisible(element As Control, visible As Boolean)
        element.Visible = visible
        If visible Then
            AddHandler element.MouseClick, AddressOf Control_MouseClick
            AddHandler element.Enter, AddressOf Control_Enter
            AddHandler element.Leave, AddressOf Control_Leave
            AddHandler element.MouseDown, AddressOf Control_MouseDown
            AddHandler element.MouseMove, AddressOf Control_MouseMove
            AddHandler element.MouseUp, AddressOf Control_MouseUp
            AddHandler element.Paint, AddressOf Control_Paint
        Else
            RemoveHandler element.MouseClick, AddressOf Control_MouseClick
            RemoveHandler element.Enter, AddressOf Control_Enter
            RemoveHandler element.Leave, AddressOf Control_Leave
            RemoveHandler element.MouseDown, AddressOf Control_MouseDown
            RemoveHandler element.MouseMove, AddressOf Control_MouseMove
            RemoveHandler element.MouseUp, AddressOf Control_MouseUp
            RemoveHandler element.Paint, AddressOf Control_Paint
        End If
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

    Private Sub ShowHeader(ByVal j As Job)
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = If(Database.Manufacturers.Local.FirstOrDefault(Function(mfr) mfr.Id = If(Job?.PropellerManufacturerId, 0))?.ManufacturerName, "")
        TxtPartNumber.Text = Job?.PropellerPartNumber
        TxtSerialNumber.Text = Job?.SerialNumber
        TxtStampNumber.Text = Job?.StampNumber
        TxtInspectedBy.Text = Database.Employees.Local.FirstOrDefault(Function(emp) emp.Id = JobDetails?.PerformedBy)?.EmployeeName

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
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MasterSource = JobDetailsBindingSource
        ConfigureControls()
        ConfigureChart()
    End Sub

    Private Sub ChartBladeHeight_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Dim s = SeriesBladeHeight(Current?.RadiusMeasurements, Job?.PropellerBlades, 1, "LE", "50")
        s.Name = "Blade Height"
        s.XValueMember = "Blade"
        s.YValueMembers = "Height"
        'ChartBladeHeight.Series.Add(s)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

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

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Prints the inside of the form's client area, excluding borders and title bar, scaled to the
        ' paper's printable area.
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

#Region "Dragging the Form"
    Private Sub Control_MouseClick(sender As Object, e As MouseEventArgs)
        ' mReportGenerator.ControlSelect(sender, e)
    End Sub

    Private Sub Control_Enter(sender As Object, e As EventArgs)
        mReportGenerator.ControlEnter(sender, e)
    End Sub
    Private Sub Control_Leave(sender As Object, e As EventArgs)
        mReportGenerator.ControlLeave(sender, e)
    End Sub
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlSelect(sender, e)
        mReportGenerator.ControlDragStart(sender, e)
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlDragMove(sender, e)
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        mReportGenerator.ControlDragDrop(sender, e)
    End Sub

    Private Sub Control_Paint(sender As Object, e As PaintEventArgs)
        mReportGenerator.ControlRepaint(sender, e)
    End Sub

    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'mReportGenerator.ReportRepaint(sender, e)
    End Sub
#End Region
#End Region
End Class