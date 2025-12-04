Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
'Imports LibEncoder.IEncoderHardware
Imports Microsoft.EntityFrameworkCore
#Const NO_ENCODERS = False
Public Class Form1
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private Const kMaxSamplesPerScan As Integer = 200           ' Maximum number of samples per scan (this is a database Setting).
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
    Private mNewJobDetail As JobDetail = Nothing                ' The new JobDetail record being added.
    Private mRadiusPercent As New MovingAverage(2)              ' Keeps a moving average of RadiusPercent measurements during a scan.
    Private mRadiusMeasurement As RadiusMeasurement = Nothing   ' Stores the RadiusMeasurement to which CellMeasurements collected during a scan are assigned to. 
    Private mSampleCount As Integer                             ' Number of samples for the current scan.
    Private mScanIncrement As Double = 1.8                      ' The angle increment between samples in degrees(this will be recalculated on form load but this is the default value).
    Private mLastScannedAngle As Double = Double.MaxValue       ' The last angle measurement saved during scanning (Used with mScanIncrement to determine when to save a new measurement).
    ' Other forms we can work with.
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobs As FrmJobs
    Private mFrmManufacturers As FrmManufacturers
    Private mFrmReports As Form2
    Private mFrmVessels As FrmVessels
#If NO_ENCODERS Then
    Private mCm As Integer = 0
    Private mEncoderData As List(Of RadiusMeasurement) = Nothing
    Private mRd As Integer = 0
#End If
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Adds a new JobDetail for the given Job
    ''' </summary>
    ''' <param name="job"></param>
    Public Sub AddNew(ByVal job As Job)
        mNewJobDetail = New JobDetail With {
            .Job = job,
            .StartDate = Date.Now,
            .PerformedByNavigation = Me.User
        }
        MasterSource.AddNew()
    End Sub
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Finds the given JobDetail and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The JobDetail to find.</param>
    ''' <returns>The found JobDetail, or Nothing if not found.</returns>
    Public Function Find(item As JobDetail) As JobDetail
        Dim result As JobDetail = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function

    ''' <summary>
    ''' Gets/sets the encoder hardware used by the form.
    ''' </summary>
    ''' <returns></returns>
    Public Property Hardware As WorkstationEncoders
        Get
            Return EncoderStatusStrip1.Hardware
        End Get
        Set(value As WorkstationEncoders)
            ' Assigns the given value to EncoderStatusStrip1, retrieves and assigns
            ' the scan sampling rate from the database and, if not already,
            ' initializes the encoder hardware.
            With EncoderStatusStrip1
                .Hardware = value
                If .Hardware IsNot Nothing Then
                    EncoderStatusStrip1.TimerInterval = Integer.Parse(SettingsGet(Database, STR_SETTING_ENCODER_DEFAULT_SAMPLE_PERIOD))
                    If .Hardware.Encoders IsNot Nothing AndAlso Not .Hardware.Encoders.Initialized Then EncoderStatusStrip1.Initialize()
                End If
            End With
        End Set
    End Property

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
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJob)
#If NO_ENCODERS Then
                mEncoderData = Database.RadiusMeasurements.Where(Function(cm) cm.JobDetailsId = 13063).Include(Function(m) m.CellMeasurements).ToList()
#End If
                ShowJobInfo()
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
#If NO_ENCODERS Then
                mEncoderData = Database.RadiusMeasurements.Where(Function(cm) cm.JobDetailsId = 13063).Include(Function(m) m.CellMeasurements).ToList()
#End If
                ShowJobInfo()
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Function CreateNewJobDetail() As JobDetail
        Return New JobDetail With {
            .Job = mJob,
            .StartDate = Date.Now,
            .PerformedByNavigation = Me.User
        }
    End Function

    Private Function DeleteConfirm() As Boolean
        Return (MessageBox.Show($"Delete job detail and all measurements from {JobDetails?.StartDate}?", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK)
    End Function

    Private Sub DeleteJobDetail()
        BindingSourceRemove(Database, JobDetailsBindingSource, Database.JobDetails)
    End Sub

    Private Sub FormSort(ByRef jobDetails As BindingList(Of JobDetail))
        For Each jd As JobDetail In jobDetails
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
    End Sub

    Private Function GetMeasurementData(j As Object) As BindingList(Of JobDetail)
        Dim data As BindingList(Of JobDetail) = Nothing
        If TypeOf j Is Job Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd.Job Is CType(j, Job)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        ElseIf TypeOf j Is JobDetail Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd Is CType(j, JobDetail)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        End If
        FormSort(data)
        Return data
    End Function
#If NO_ENCODERS Then
    Private Sub MeasurementsGet()
        Dim rand As New System.Random()
        Dim offset As Double = rand.Next(-500, 500 + 1) / 1000.0
        Dim angle As Double = mEncoderData(mRd).CellMeasurements(mCm).Angle
        Dim depth As Double = mEncoderData(mRd).CellMeasurements(mCm).Depth
        Dim radius As New IEncoderHardware.RadiusMeasurement With {.Value = mEncoderData(mRd).Radius + offset, .Percent = .Value / Job?.PropellerDiameter / 2.0}
        Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
        TxtBlade.Text = blade
        TxtAngle.Text = angle.ToString()
        TxtRadius.Text = radius.Value.ToString()
        TxtDepth.Text = depth.ToString()
        TxtRadiusPercent.Text = (radius.Percent * 100).ToString()
        MeasurementsSave(angle, depth, radius)
        mCm += 1
        If mCm = mEncoderData(mRd).CellMeasurements.Count Then
            ChkScan.Checked = False
            'Scanning = False
            mCm = 0
        End If
    End Sub

    Private Sub MeasurementsGet(lastAngle As Double)
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            TxtAngle.Text = Math.Round(angle, 2).ToString()
            TxtRadius.Text = radius.Value.ToString()
            TxtDepth.Text = depth.ToString()
            TxtRadiusPercent.Text = (radius.Percent * 100.0).ToString()
            If (lastAngle - angle) > mScanIncrement Then
                MeasurementsSave(angle, depth, radius)
                mSampleCount += 1
            End If
        End With
    End Sub
#Else
    Private Sub MeasurementsGet()
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required. This one doesn't save Measurements.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
            TxtBlade.Text = blade
            TxtAngle.Text = Math.Round(angle, 2).ToString()
            TxtRadius.Text = radius.Value.ToString()
            TxtDepth.Text = depth.ToString()
            TxtRadiusPercent.Text = (radius.Percent * 100.0).ToString()
        End With
    End Sub
    Private Sub MeasurementsGet(lastAngle As Double)
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required. Saves the measurements if the angle measurement 
        ' changes by more than some specified amount.
        ' Doesn't change the Blade Number textbox as it wouldn't change during scanning.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            TxtAngle.Text = Math.Round(angle, 2).ToString()
            TxtRadius.Text = radius.Value.ToString()
            TxtDepth.Text = depth.ToString()
            TxtRadiusPercent.Text = (radius.Percent * 100.0).ToString()
            If (lastAngle - angle) > mScanIncrement Then
                MeasurementsSave(angle, depth, radius)
                mSampleCount += 1
            End If
        End With
    End Sub
#End If
    Private Sub MeasurementsSave(ByVal angle As Double, ByVal depth As Double, ByVal radius As IEncoderHardware.RadiusMeasurement)
        ' Updates the RadiusPercent moving average and saves the given angle and depth measurements.
        If TxtBlade.Text = "1" And angle > 180.0 Then 'this is a simple way to handle overscan when crossing 0 degrees on blade 1
            angle -= 360.0                                           ' this will make the change in angle consistent when crossing 0 degrees
        End If
        mRadiusPercent.Input(radius.Percent * 100)
        Dim cm As New CellMeasurement With {
            .RadiusMeasurement = mRadiusMeasurement,
            .Angle = angle,
            .Depth = depth
        }
        Database.CellMeasurements.Add(cm)
        mLastScannedAngle = angle
    End Sub

    Protected Overrides Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If Navigator IsNot Nothing Then Navigator.MasterSource = mMasterSource
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then mNavigator.Database = Database
        End Set
    End Property


    Private Sub NewRadiusMeasurement()
        ' RadiusMeasurement is now parent (PK) of Cell and ExtremeMeasurements
        ' (FK). Clear the previous moving average and create a new
        ' RadiusMeasurement with .Radius = 0, which will be updated at
        ' the end of the scan.
        mRadiusPercent.Clear()
        mRadiusMeasurement = New RadiusMeasurement With {
            .JobDetails = Me.JobDetails,
            .Radius = 0.0,
            .LeCell = 0,
            .TeCell = 0
        }
        mLastScannedAngle = 1000.0 'ensure first measurement is always saved
        'mRadiusPercent.Input(Double.Parse(TxtRadiusPercent.Text))
    End Sub

    Private Function ReferenceRadiiGet(ByVal blade As Integer) As List(Of Double)
        ' Returns a list of reference radii for the given blade.
        Dim radii As New List(Of Double)
        If mJobDetails?.RadiusMeasurements IsNot Nothing Then
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements
                If rm.BladeId = blade Then radii.Add(Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES))
            Next
        End If
        Return radii
    End Function

    Private Sub SaveRadiusMeasurement()
        ' Update and save the current RadiusMeasurement with the moving average
        ' we collected while scanning.
        If Database.RadiusMeasurements.Local.Where(Function(rm) rm.JobDetailsId = mJobDetails.Id And rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).Any() Then
            Database.RadiusMeasurements.Local.Remove(Database.RadiusMeasurements.Local.Where(Function(rm) rm.JobDetailsId = mJobDetails.Id And rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).FirstOrDefault())
        End If
        mRadiusMeasurement.Radius = mRadiusPercent.Output()
        mRadiusMeasurement.BladeId = Integer.Parse(TxtBlade.Text)
        mRadiusMeasurement.TeCell = mSampleCount - 1
        Database.RadiusMeasurements.Add(mRadiusMeasurement)
        Database.SaveChanges()
        ShowBladePitch(True)
    End Sub

    Private Sub ScanControlsEnabled(ByVal isScanning As Boolean)
        ' Disable any controls that can interfere with the
        ' encoders while scanning. Enable them when done.
        CmdHome.Enabled = Not isScanning
        CmdSetTip.Enabled = CmdHome.Enabled
        CmdZero.Enabled = CmdHome.Enabled
    End Sub

    Private Property Scanning As Boolean
        Get
            Return ChkScan.Checked
        End Get
        Set(value As Boolean)
            If value Then
                NewRadiusMeasurement()
                mSampleCount = 0
            Else
#If NO_ENCODERS Then
                mRd += 1
                If mRd = mEncoderData.Count Then mRd = 0
#End If
                SaveRadiusMeasurement()
            End If
            ScanControlsEnabled(value)
        End Set
    End Property

    Private Sub ShowBladePitch(show As Boolean)
        Dim dtBladePitch As New DataTable()
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim ToleranceTable As Tolerance = GetToleranceTable(Database, If(mJobDetails?.ToleranceClass, "D"))
        Dim TotalPitchWheel As Double = 0.0
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("Blade", GetType(Integer))
        Dim colPitch As DataColumn = dtBladePitch.Columns.Add("Blade", GetType(Double))
        Dim rowBlade As DataRow
        Dim x As Integer
        For x = 1 To Job?.PropellerBlades
            rowBlade = dtBladePitchByRadius.Rows.Add(x)
            rowBlade = dtBladePitch.Rows.Add(x)
        Next
        GridBladebyRadius.DataSource = dtBladePitchByRadius
        dtBladePitch.PrimaryKey = New DataColumn() {colPitch}
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.OrderBy(Function(r) r.Radius).ToList()
            Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
            rowBlade = If(dtBladePitchByRadius.Rows.Find(rm.BladeId), dtBladePitchByRadius.Rows.Add(rm.BladeId))
            colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
            Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList())
            rowBlade.Item(colRadius) = Math.Round(pitch, 2)
            Dim textavgbladepitchcolor As ToleranceColor = CheckBladeRadiusPitch(ToleranceTable, pitch, Job.DesiredPitch) ' Check tolerance and adjust text color
            GridBladebyRadius.Rows(rm.BladeId - 1).Cells(colRadius.Ordinal).Style.ForeColor = Tolerances.ToColor(textavgbladepitchcolor)
            TotalPitchWheel += GetAverageBladePitch(rm.CellMeasurements.ToList())
        Next
        mJobDetails.WheelPitch = TotalPitchWheel / mJobDetails.RadiusMeasurements.Count
        Dim textwheelpitchcolor As ToleranceColor = CheckWheelPitch(ToleranceTable, mJobDetails.WheelPitch, Job.DesiredPitch)
        TxtWheelPitch.ForeColor = Tolerances.ToColor(textwheelpitchcolor)
        TxtWheelPitch.Text = mJobDetails.WheelPitch.ToString()
        GridBladebyRadius.Refresh()
        GridBladePitch.DataSource = dtBladePitch
        dtBladePitch.Columns.Add("Avg Pitch", GetType(Double))
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                rowBlade = If(dtBladePitch.Rows.Find(rm.BladeId), dtBladePitch.Rows.Find(1))
                colPitch = If(dtBladePitch.Columns("Avg Pitch"), dtBladePitch.Columns.Add("Avg Pitch", GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList())
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim avgpitch As Double = totalPitch / pitchCount
            Dim bladepitchcolor As ToleranceColor = CheckBladePitch(ToleranceTable, avgpitch, Job.DesiredPitch) ' Check tolerance and adjust text color
            dtBladePitch.Rows(row.Item("Blade") - 1).Item("Avg Pitch") = Math.Round(totalPitch / pitchCount, 2)
            GridBladePitch.Rows(row.Item("Blade") - 1).Cells(1).Style.ForeColor = Tolerances.ToColor(bladepitchcolor)
        Next
        GridBladePitch.Columns(0).Visible = False
    End Sub

    Private Sub ShowJobInfo()
        ' Show the current Customer, Vessel, Job and Propeller info.
        Dim bsReferenceBlades As New BindingList(Of Integer)
        For i As Integer = 1 To mJob.PropellerBlades
            bsReferenceBlades.Add(i)
        Next
        Dim strBlades As String = If(Job?.PropellerBlades IsNot Nothing, $"Blades = {Job?.PropellerBlades}", "")
        Dim strDiameter As String = If(Job?.PropellerDiameter IsNot Nothing, $"Dia = {Job?.PropellerDiameter}", "")
        Dim strBore As String = If(Job?.PropellerBore IsNot Nothing, $"Bore = {Job?.PropellerBore}", "")
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = If(Job?.PropellerManufacturer?.ManufacturerName, "")
        TxtStyle.Text = If(Job?.PropellerStyleNavigation?.Style1, "")
        TxtMaterial.Text = If(Job?.PropellerMaterialNavigation?.Material1, "")
        TxtBlades.Text = strBlades
        TxtDiameter.Text = strDiameter
        TxtBore.Text = strBore
        ComboReferenceBlade.DataSource = bsReferenceBlades
        ComboReferencePoint.SelectedItem = "LE"
        ComboReferenceRadius.DataSource = ReferenceRadiiGet(ComboReferenceBlade.SelectedValue)
        ComboPitchBasis.SelectedItem = "Marked"
        ComboTolerance.SelectedItem = JobDetails?.ToleranceClass
        ShowPitchBasis()
    End Sub

    Private Sub ShowJobDetailsInfo()
        ' Update any controls that consume data from the current JobDetail record.
        ShowBladePitch(True)
        ShowTrack()
        ShowBladePlot()
    End Sub

    Private Sub ShowPitchBasis()
        Select Case ComboPitchBasis.SelectedItem.ToString()
            Case "Mean"
                If TxtWheelPitch.Text <> "NaN" Then
                    TxtBasis.Text = TxtWheelPitch.Text
                Else
                    TxtBasis.Text = Job?.MarkedPitch.ToString()
                End If
            Case "Marked"
                TxtBasis.Text = Job?.MarkedPitch.ToString()
            Case "Desired"
                TxtBasis.Text = Job?.DesiredPitch.ToString()
            Case Else
        End Select
        ShowBladePlot()
        ShowBladePitch(True)
    End Sub

    Private Sub ShowTrack()
        Const kHeightOffset As Double = 0.2 ' Offset to add to data points for visual comparison?
        Dim refBlade As Integer? = ComboReferenceBlade.SelectedValue
        Dim refPoint As String = ComboReferencePoint.SelectedValue
        Dim refRadius As Double = ComboReferenceRadius.SelectedValue
        ' If all three reference values are given, calculate and plot the data.
        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesHeight As Series = ChartCreateSeries(ChartBladeHeight, "BladeHeight", "Blade", "Height")
            Dim seriesPosition As Series = ChartCreateSeries(ChartAngularPosition, "AngularPosition", "Blade", "Position")
            Dim radiusMeasurements As List(Of RadiusMeasurement) = mJobDetails?.RadiusMeasurements?.Where(Function(r) r.BladeId = refBlade).OrderBy(Function(r) CType(r.Radius, Double)).ToList()
            Dim innerRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault() ' RadiusMeasurement at smallest radius
            Dim innerDepth As Double = TrackGetDepth(innerRm, refPoint)             ' Depth at smallest radius and reference point
            Dim outerRm As RadiusMeasurement = radiusMeasurements?.LastOrDefault()  ' RadiusMeasurement at largest radius
            Dim outerDepth As Double = TrackGetDepth(outerRm, refPoint)             ' Depth at largest radius and reference point
            Dim refRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)    ' RadiusMeasurement at reference radius
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)                 ' Depth at reference radius and point
            Dim refAngle As Double = TrackGetAngle(refRm, refPoint)                 ' Angle at reference radius and point
            ' Plot each blade's data points
            For i As Integer = 1 To Job?.PropellerBlades
                Dim b As Integer = i
                Dim rm As RadiusMeasurement = mJobDetails?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = b)
                If rm IsNot Nothing Then
                    Dim bladeDepth As Double = TrackGetDepth(rm, refPoint)
                    Dim bladeAngle As Double = TrackGetAngle(rm, refPoint)
                    Dim bladeHeight As Double = Math.Abs(refDepth - bladeDepth) + kHeightOffset
                    Dim bladePosition As Double = Math.Abs(refAngle - bladeAngle) - ((360 / Job?.PropellerBlades) * Math.Abs(refBlade.Value - rm.BladeId.Value)) + kHeightOffset
                    ChartAddPoint(ChartBladeHeight, seriesHeight, $"{b}", bladeHeight, (b = refBlade))
                    ChartAddPoint(ChartAngularPosition, seriesPosition, $"{b}", bladePosition, (b = refBlade))
                End If
            Next
            ShowRake(innerDepth, outerDepth, innerRm.Radius, outerRm.Radius, refRadius)
        End If
    End Sub

    Private Sub ShowBladePlot()
        If mJobDetails Is Nothing Then Return

        ' Clear any existing chart areas and series.
        chartPlot.ChartAreas.Clear()
        chartPlot.Series.Clear()
        chartPlot.Titles.Clear()

        ' Add a ChartArea and Title for the point graph
        Dim chartArea1 As New ChartArea()
        chartArea1.AxisX.MajorGrid.Enabled = False
        chartArea1.AxisY.MajorGrid.Enabled = False
        chartArea1.AxisX.LabelStyle.Enabled = False
        chartArea1.AxisY.LabelStyle.Enabled = False
        chartArea1.AxisX.MajorTickMark.Enabled = False
        chartArea1.AxisY.MajorTickMark.Enabled = False
        chartArea1.AxisX.LineWidth = 0
        chartArea1.AxisY.LineWidth = 0
        chartPlot.ChartAreas.Add(chartArea1)
        chartPlot.Titles.Add("Blade Tolerances By Radius")

        ' Get a list of RadiusMeasurements for this JobDetail.
        Dim radiusMeasurements As List(Of RadiusMeasurement) =
            mJobDetails?.RadiusMeasurements _
            .OrderBy(Function(b) b.BladeId) _
            .ThenBy(Function(r) CType(r.Radius, Double)) _
            .ToList()
        ' The chart axes min/max values are the greatest radius value,
        ' this way the arcs always start at the outside of the chart area.
        chartArea1.AxisX.Maximum = kBladePlotAxesMax
        chartArea1.AxisX.Minimum = -chartArea1.AxisX.Maximum
        chartArea1.AxisY.Maximum = chartArea1.AxisX.Maximum
        chartArea1.AxisY.Minimum = -chartArea1.AxisY.Maximum
        If Not (String.IsNullOrEmpty(TxtBasis.Text) Or String.IsNullOrEmpty(ComboTolerance.Text)) Then
            Dim TolClass As Tolerance = Database.Tolerances.FirstOrDefault(Function(t) t.ToleranceClass = ComboTolerance.Text)
            Dim BasisPitch As Double = Double.Parse(TxtBasis.Text)
            ' Each RadiusMeasurement is a new Series of Points that circumscribes an arc
            ' having a radius equal to RadiusMeasurement.Radius. 
            For Each rm As RadiusMeasurement In radiusMeasurements
                Dim s As New Series With {
                    .ChartType = kBladePlotChartType,
                    .MarkerStyle = kBladePlotMarkerStyle,
                    .MarkerSize = kBladePlotMarkerSize
                }
                Dim cellMeasurements As List(Of CellMeasurement) = rm.CellMeasurements.ToList()
                ' Each CellMeasurement in the RadiusMeasurement defines a Point on the arc.
                For i As Integer = 1 To cellMeasurements.Count - 1
                    Dim cmCurrent As CellMeasurement = cellMeasurements(i)
                    Dim cmPrevious As CellMeasurement = cellMeasurements(i - 1)
                    Dim pitch As Double = GetPitch(cmCurrent?.Angle, cmPrevious?.Angle, cmCurrent?.Depth, cmPrevious?.Depth)
                    Dim angle As Double = (cmCurrent?.Angle + cmPrevious?.Angle) / 2
                    Dim theta As Double = cmPrevious.Angle * Math.PI / 180
                    Dim coordinates = PolarToCartesian(rm.Radius, angle)
                    ' Cartesian point coordinates are computed from polar coordinates (r,theta), where 
                    ' r is RadiusMeasurement.Radius and theta is CellMeasurement.Angle
                    Dim p As Integer = s.Points.AddXY(coordinates.x, coordinates.y)
                    ' Set the point color based on tolerance class, pitch and basis pitch.
                    Dim pointcolor As ToleranceColor = Tolerances.CheckLocalPitchTolerance(TolClass, pitch, BasisPitch)
                    s.Points(p).Color = ToColor(pointcolor)
                Next
                chartPlot.Series.Add(s)
            Next
        End If
    End Sub

    Private Sub ShowRake(ByVal innerDepth As Double, ByVal outerDepth As Double, ByVal innerRadius As Double, ByVal outerRadius As Double, ByVal radius As Double)
        Dim deltaDepth As Double = innerDepth - outerDepth
        Dim lengthRadius As Double = (radius * outerRadius / 100.0) - (radius * innerRadius / 100.0)
        Dim rake As Double = Math.Atan2(deltaDepth, lengthRadius) * (180.0 / Math.PI)
        TxtRake.Text = rake.ToString(STR_PARAM_DECIMAL_PLACES)
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub ChkScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkScan.CheckedChanged
        Try
            Scanning = ChkScan.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles CmdHome.Click
        Try
            EncoderStatusStrip1.ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error homing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdSetTip_Click(sender As Object, e As EventArgs) Handles CmdSetTip.Click

    End Sub

    Private Sub CmdZero_Click(sender As Object, e As EventArgs) Handles CmdZero.Click

    End Sub

    Private Sub ComboPitchBasis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboPitchBasis.SelectedIndexChanged
        ShowPitchBasis()
    End Sub

    Private Sub ComboReferenceBlade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferenceBlade.SelectedIndexChanged
        ComboReferenceRadius.DataSource = ReferenceRadiiGet(ComboReferenceBlade.SelectedValue)
        ShowTrack()
    End Sub

    Private Sub ComboReferencePoint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferencePoint.SelectedIndexChanged
        ShowTrack()
    End Sub

    Private Sub ComboReferenceRadius_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferenceRadius.SelectedIndexChanged
        ShowTrack()
    End Sub

    Private Sub ComboTolerance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTolerance.SelectedIndexChanged
        ShowBladePlot()
    End Sub

    Private Sub DataGridJobDetails_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridJobDetails.MouseDoubleClick
        If Current IsNot Nothing Then
            ShowForm(mFrmReports, Database, User)
            mFrmReports.JobDetails = Current
        End If
    End Sub

    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles EncoderStatusStrip events so we can update our controls accordingly.
    End Sub

    Private Sub EncoderStatusStrip1_Load(sender As Object, e As EventArgs)
        mScanIncrement = EncoderStatusStrip1.Hardware.Workstation.ScanIncrement / EncoderStatusStrip1.Hardware.Workstation.AngleResolution
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        EncoderStatusStrip1.TimerOn = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Load
        Try
            ' Initialize form controls. This method needs to initialize all form controls
            ' based on some predefined "states". For example: if no encoders are detected,
            ' they're not initialized or in an error state, then disable all controls that 
            ' can access the encoders. 
            Dim tolerances = Database.Tolerances.Local.ToList
            tolerances.Add(New Tolerance With {.ToleranceClass = "Custom"})
            ComboTolerance.DataSource = tolerances
            ComboReferencePoint.DataSource = New List(Of String) From {"LE", "Mid", "TE"}
            ComboPitchBasis.DataSource = New List(Of String) From {"Mean", "Marked", "Desired"}

            ' Initialize the DataGridJobDetails.
            DataGridJobDetails.AutoGenerateColumns = False
            EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
            ClassBindingSource.DataSource = Database.Tolerances.Local.ToBindingList
            MeasurementTypesBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList

            ' Initialize the Navigator
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridJobDetails}
            MasterSource = JobDetailsBindingSource

            ' EncoderStatusStrip1 handles the encoder hardware and its controls automatically. 
            ' It raises events notifying clients of anything relevant. These events can, for
            ' instance, be used to update this form's state and take periodic measurements.
            ' See Encoders_EncoderEvent() and ScanTimer_Tick() for examples.
            AddHandler EncoderStatusStrip1.Load, AddressOf EncoderStatusStrip1_Load
            AddHandler EncoderStatusStrip1.EncoderEvent, AddressOf Encoders_EncoderEvent
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
            EncoderStatusStrip1.TimerOn = True
        Catch ex As Exception
            MessageBox.Show("Error loading measurements form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobDetailsBindingSource.AddingNew
        Try
            Dim newJobDetail As JobDetail = If(mNewJobDetail, CreateNewJobDetail())
            e.NewObject = newJobDetail
            Database.JobDetails.Add(newJobDetail)
        Catch ex As Exception
            MessageBox.Show("Error adding new job details record: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        If mJobDetails IsNot Current Then
            mJobDetails = Current
            If JobDetails IsNot Nothing Then ShowJobDetailsInfo()
        End If
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        ' Handles Navigator events so we can update our controls accordingly.
        Select Case e.EventName
            Case "AddNew"
                ' Disable PanelMeasurements when the user is adding a new JobDetails record.
                PanelMeasurements.Enabled = False
            Case "Delete"
                If DeleteConfirm() Then
                    DeleteJobDetail()
                    RefreshAll()
                End If
            Case "Editing"
                ' Disable the PanelMeasurements when the user is editing the JobDetails record. 
                PanelMeasurements.Enabled = False
            Case "FilterOff"
            Case "FilterOn"
            Case "Find"
            Case "GotoFirst", "GotoNext", "GotoPrev"
            Case "GotoLast"
            Case "Save"
                ' Refresh any open database forms affected by our changes and enable PanelMeasurements.
                RefreshAll()
                PanelMeasurements.Enabled = True
            Case "Undo"
                ' Enable the PanelMeasurements when the user has cancelled the JobDetails record changes.
                If Me.Current IsNot Nothing Then
                    ShowJobDetailsInfo()
                    PanelMeasurements.Enabled = True
                End If
            Case Else
        End Select
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            If Scanning Then
                MeasurementsGet(mLastScannedAngle)
                If mSampleCount = kMaxSamplesPerScan Then Scanning = False
            Else
                MeasurementsGet()
            End If
        Catch ex As Exception
            Scanning = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtCustomer_DoubleClick(sender As Object, e As EventArgs) Handles TxtCustomer.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(mFrmCustomers, Database, User)
            mFrmCustomers.Find(Job?.Vessel?.Customer)
        End If
    End Sub

    Private Sub TxtJobNumber_DoubleClick(sender As Object, e As EventArgs) Handles TxtJobNumber.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(mFrmJobs, Database, User)
            mFrmJobs.Find(Job)
        End If
    End Sub
    Private Sub TxtManufacturer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TxtManufacturer.MouseDoubleClick
        If Job IsNot Nothing Then
            ShowForm(mFrmManufacturers, Database, User)
            mFrmManufacturers.Find(Job?.PropellerManufacturer)
        End If
    End Sub

    Private Sub TxtVessel_DoubleClick(sender As Object, e As EventArgs) Handles TxtVessel.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(mFrmVessels, Database, User)
            mFrmVessels.Find(Job?.Vessel)
        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        EncoderStatusStrip1.TimerOn = True
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        EncoderStatusStrip1.TimerOn = False
    End Sub
#End Region
End Class