Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Win32
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
    Private ScanIncrement As Double = 1.8                     ' The angle increment between samples in degrees(this will be recalculated on form load but this is the default value).
    Private LastScannedAngle As Double = 1000               ' The last angle measurement saved during scanning (Used with scanincrement to determine when to save a new measurement).
    ' Other forms we can work with.
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobs As FrmJobs
    Private mFrmManufacturers As FrmManufacturers
    Private mFrmVessels As FrmVessels
#If NO_ENCODERS Then
    Private mCm As Integer = 0
    Private mEncoderData As List(Of RadiusMeasurement) = Nothing
    Private mRd As Integer = 0
#End If
#End Region
#Region "Public Interface"
    Public Sub AddNew(ByVal job As Job)
        mNewJobDetail = New JobDetail With {
            .Job = job,
            .StartDate = Date.Now,
            .PerformedByNavigation = Me.User
        }
        MasterSource.AddNew()
    End Sub
    ''' <summary>
    ''' Returns the currently selected Job,
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

    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            ' Loads all of the given Job's JobDetails and their Cell, Extreme and RadiusMeasurements.
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) _
                    (Database.JobDetails _
                        .Where(Function(jd) jd.Job Is mJob) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(cm) cm.CellMeasurements) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(em) em.ExtremeMeasurements) _
                        .OrderBy(Function(jd) jd.StartDate) _
                        .AsSplitQuery().ToList()
                    )
                FormSort(JobDetailsBindingSource?.DataSource)
#If NO_ENCODERS Then
                mEncoderData = Database.RadiusMeasurements.Where(Function(cm) cm.JobDetailsId = 13063).Include(Function(m) m.CellMeasurements).ToList()
#End If
                ShowJobInfo()
            End If
            Dim rm1 As RadiusMeasurement = mJobDetails.RadiusMeasurements.FirstOrDefault()
            Dim cm1 As List(Of CellMeasurement) = rm1?.CellMeasurements.OrderBy(Function(x) x.Id).ToList()
            For Each cm As CellMeasurement In cm1
                Dim id As Integer = cm.Id
                Dim angle As Double = cm.Angle
                Dim depth As Double = cm.Depth
            Next
        End Set
    End Property

    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) _
                    (Database.JobDetails _
                    .Where(Function(jd) jd Is mJobDetails) _
                    .Include(Function(rm) rm.RadiusMeasurements) _
                    .ThenInclude(Function(m) m.CellMeasurements) _
                    .Include(Function(rm) rm.RadiusMeasurements) _
                    .ThenInclude(Function(m) m.ExtremeMeasurements) _
                    .OrderBy(Function(jd) jd.StartDate) _
                    .AsSplitQuery().ToList()
                )
                FormSort(JobDetailsBindingSource?.DataSource)
#If NO_ENCODERS Then
                mEncoderData = Database.RadiusMeasurements.Where(Function(cm) cm.JobDetailsId = 5).Include(Function(m) m.CellMeasurements).ToList()
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
            If (lastAngle - angle) > ScanIncrement Then
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
        LastScannedAngle = angle
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
        Database.RadiusMeasurements.Add(mRadiusMeasurement)
    End Sub

    Private Function ReferenceRadiiGet(ByVal blade As Integer) As List(Of Double)
        ' Returns a list of reference radii for the given blade.
        Dim radii As New List(Of Double)
        If mJobDetails?.RadiusMeasurements IsNot Nothing Then
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements
                If rm.BladeId = blade Then radii.Add(Math.Round(CType(rm.Radius, Double)).ToString("F2"))
            Next
        End If
        Return radii
    End Function

    Private Sub SaveRadiusMeasurement()
        ' Update and save the current RadiusMeasurement with the moving average
        ' we collected while scanning.
        If Database.RadiusMeasurements.Contains(mJobDetails.RadiusMeasurements.Where(Function(rm) rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).First()) Then
            Database.RadiusMeasurements.Remove(mJobDetails.RadiusMeasurements.Where(Function(rm) rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).First())
        End If
        mRadiusMeasurement.Radius = mRadiusPercent.Output()
        mRadiusMeasurement.BladeId = Integer.Parse(TxtBlade.Text)
        mRadiusMeasurement.TeCell = mSampleCount - 1
        Database.SaveChanges()
        ShowBladePitch(True)
        ' 1. Check rm values
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

    Private Sub ShowBladePitch(ByVal show As Boolean)
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("Blade", GetType(Integer))
        Dim rowBlade As DataRow
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.OrderBy(Function(b) b.BladeId)
            Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString("F2")
            rowBlade = If(dtBladePitchByRadius.Rows.Find(rm.BladeId), dtBladePitchByRadius.Rows.Add(rm.BladeId))
            colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
            rowBlade.Item(colRadius) = GetAverageBladePitch(rm.CellMeasurements.ToList())
        Next
        GridBladebyRadius.DataSource = dtBladePitchByRadius
    End Sub

    Private Sub ShowJobInfo()
        ' Show the current Customer, Vessel, Job and Propeller info.
        Dim bsReferenceBlades As New BindingList(Of Integer)
        For i As Integer = 1 To mJob.PropellerBlades
            bsReferenceBlades.Add(i)
        Next
        ComboReferenceBlade.DataSource = bsReferenceBlades
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
        ComboReferencePoint.SelectedItem = "LE"
        ComboPitchBasis.SelectedItem = "Mean"
        ComboTolerance.SelectedItem = JobDetails?.ToleranceClass
        ShowPitchBasis()
    End Sub

    Private Sub ShowJobDetailsInfo()
        ' Update any controls that consume data from the current JobDetail record.
        ShowBladePitch(True)
        ShowTrack()
        ShowPlot()
    End Sub

    Private Sub ShowPitchBasis()
        Select Case ComboPitchBasis.SelectedItem.ToString()
            Case "Mean"
                TxtBasis.Text = ((Job?.MarkedPitch + Job?.DesiredPitch) / 2.0).ToString()
            Case "Marked"
                TxtBasis.Text = Job?.MarkedPitch.ToString()
            Case "Desired"
                TxtBasis.Text = Job?.DesiredPitch.ToString()
            Case Else
        End Select
    End Sub

    Private Sub ShowTrack()
        Const kHeightOffset As Double = 0.2 ' Offset to add to bladeHeight for visual comparison? 
        Dim refBlade As Integer? = ComboReferenceBlade.SelectedValue
        Dim refPoint As String = ComboReferencePoint.SelectedValue
        Dim refRadius As Double = ComboReferenceRadius.SelectedValue
        ' If all three reference values are given, calculate and plot the data.
        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesHeight As Series = ChartCreateSeries(ChartBladeHeight, "BladeHeight", "Blade", "Height")
            Dim seriesPosition As Series = ChartCreateSeries(ChartAngularPosition, "AngularPosition", "Blade", "Position")
            Dim refRm As RadiusMeasurement = mJobDetails?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = refBlade AndAlso Math.Round(CType(r.Radius, Double)) = refRadius)
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)
            Dim refAngle As Double = TrackGetAngle(refRm, refPoint)
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
            ShowRake(refRadius) ' Assuming the 'radius' argument is the currently selected one in the combo box?
        End If
    End Sub

    Private Sub ShowPlot()

    End Sub

    Private Sub ShowRake(ByVal radius As Double)
        ' Need specific definitions for these values so they can be translated dB calls to retrieve proper values.
        Dim innerDepth As Double = 0.0  'Innermost depth is the Depth at the smallest recorded radius percent at the selected reference point on the selected reference blade
        Dim outerDepth As Double = 0.0  'Outermost depth is the Depth at the largest recorded radius percent at the selected reference point on the selected reference blade
        Dim innerRadius As Double = 0.0 'Inner and outer most radii are the smallest and largest recorded radii percent on a selected reference blade
        Dim outerRadius As Double = 0.0 'Inner and outer most radii are the smallest and largest recorded radii percent on a selected reference blade
        ''''''''''''''''''''''''''''''''''''''''''
        Dim deltaDepth As Double = innerDepth - outerDepth
        Dim lengthRadius As Double = (radius * outerRadius / 100.0) - (radius * innerRadius / 100.0)
        Dim rake As Double = Math.Atan2(deltaDepth, lengthRadius) * (180.0 / Math.PI)
        TxtRake.Text = rake.ToString("F2")
    End Sub

    Private Function TrackGetAngle(ByVal rm As RadiusMeasurement, ByVal point As String) As Double
        ' Returns the Depth CellMeasurement for the given RadiusMeasurement at the given point (LE, Mid or TE).
        Dim angle As Double = 0.0
        If rm IsNot Nothing AndAlso Not String.IsNullOrEmpty(point) Then
            Select Case point
                Case "LE"
                    angle = rm.CellMeasurements.FirstOrDefault()?.Angle
                Case "Mid"
                    angle = rm.CellMeasurements.ElementAt(rm.CellMeasurements.Count \ 2)?.Angle
                Case "TE"
                    angle = rm.CellMeasurements.LastOrDefault()?.Angle
                Case Else
            End Select
        End If
        Return angle
    End Function

    Private Function TrackGetDepth(ByVal rm As RadiusMeasurement, ByVal point As String) As Double
        ' Returns the Depth CellMeasurement for the given RadiusMeasurement at the given point (LE, Mid or TE).
        Dim depth As Double = 0.0
        If rm IsNot Nothing AndAlso Not String.IsNullOrEmpty(point) Then
            Select Case point
                Case "LE"
                    depth = rm.CellMeasurements.FirstOrDefault()?.Depth
                Case "Mid"
                    depth = rm.CellMeasurements.ElementAt(rm.CellMeasurements.Count \ 2)?.Depth
                Case "TE"
                    depth = rm.CellMeasurements.LastOrDefault()?.Depth
                Case Else
            End Select
        End If
        Return depth
    End Function
#End Region
#Region "Event Handlers"
    Private Sub ChkScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkScan.CheckedChanged
        Try
            Me.Scanning = ChkScan.Checked
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize form controls. This method needs to initialize all form controls
            ' based on some predefined "states". For example: if no encoders are detected,
            ' they're not initialized or in an error state, then disable all controls that 
            ' can access the encoders. 
            Dim tolerances As List(Of Tolerance) = Database.Tolerances.Local.ToList()
            tolerances.Add(New Tolerance With {.ToleranceClass = "Custom"})
            ComboTolerance.DataSource = tolerances
            ComboReferencePoint.DataSource = New List(Of String) From {"LE", "Mid", "TE"}
            ComboPitchBasis.DataSource = New List(Of String) From {"Mean", "Marked", "Desired"}

            ' Initialize the DataGridJobDetails.
            DataGridJobDetails.AutoGenerateColumns = False
            EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList()
            ClassBindingSource.DataSource = Database.Tolerances.Local.ToBindingList()
            MeasurementTypesBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList()

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

    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles EncoderStatusStrip events so we can update our controls accordingly.
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
        mJobDetails = Me.Current
        If Me.JobDetails IsNot Nothing Then ShowJobDetailsInfo()
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
                MeasurementsGet(LastScannedAngle)
                If mSampleCount = kMaxSamplesPerScan Then Scanning = False
            Else
                MeasurementsGet()
            End If
        Catch ex As Exception
            Scanning = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EncoderStatusStrip1_Load(sender As Object, e As EventArgs)
        ScanIncrement = EncoderStatusStrip1.Hardware.Workstation.ScanIncrement / EncoderStatusStrip1.Hardware.Workstation.AngleResolution
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
#End Region
End Class