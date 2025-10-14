Imports System.ComponentModel
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
Imports Microsoft.EntityFrameworkCore
#Const NO_ENCODERS = True
Public Class Form1
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private Const kMaxSamplesPerScan As Integer = 200           ' Maximum number of samples per scan (this is a database Setting).
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
    Private mRadiusPercent As New MovingAverage(2)              ' Keeps a moving average of RadiusPercent measurements during a scan.
    Private mRadiusMeasurement As RadiusMeasurement = Nothing   ' Stores the RadiusMeasurement to which CellMeasurements collected during a scan are assigned to. 
    Private mSampleCount As Integer                             ' Number of samples for the current scan.
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
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

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
                        .OrderBy(Function(jd) jd.StartDate) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(cm) cm.CellMeasurements) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(em) em.ExtremeMeasurements) _
                        .AsSplitQuery().ToList()
                    )
#If NO_ENCODERS Then
                mEncoderData = Database.RadiusMeasurements.Where(Function(cm) cm.JobDetailsId = 5).Include(Function(m) m.CellMeasurements).ToList()
#End If
                ShowJobInfo()
            End If
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
                    .AsSplitQuery().ToList()
                )
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
        ' values as required.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
            TxtBlade.Text = blade
            TxtAngle.Text = angle.ToString()
            TxtRadius.Text = radius.Value.ToString()
            TxtDepth.Text = depth.ToString()
            TxtRadiusPercent.Text = (radius.Value * 100).ToString()
            MeasurementsSave(angle, depth, radius)
        End With
    End Sub

    Private Sub MeasurementsGet(byval reset as boolean)
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required. Saves the measurements if the angle measurement 
        ' changes by more than some specified amount.
        static lastAngle as double = 0.0
        if reset then lastAngle=0.0
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
            TxtBlade.Text = blade
            TxtAngle.Text = angle.ToString()
            TxtRadius.Text = radius.Value.ToString()
            TxtDepth.Text = depth.ToString()
            TxtRadiusPercent.Text = (radius.Value * 100).ToString()
            if Math.Abs(angle - lastAngle) > 1.0 then MeasurementsSave(angle, depth, radius)
        End With
    End Sub
#End If

    Private Sub MeasurementsSave(ByVal angle As Double, ByVal depth As Double, ByVal radius As IEncoderHardware.RadiusMeasurement)
        ' Updates the RadiusPercent moving average and saves the given angle and depth measurements.
        mRadiusPercent.Input(radius.Value)
        Dim cm As New CellMeasurement With {
            .RadiusMeasurement = mRadiusMeasurement,
            .Angle = angle,
            .Depth = depth
        }
        Database.CellMeasurements.Add(cm)
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

    Private Sub SaveRadiusMeasurement()
        ' Update and save the current RadiusMeasurement with the moving average
        ' we collected while scanning.
        mRadiusMeasurement.Radius = mRadiusPercent.Output()
        mRadiusMeasurement.BladeId = Integer.Parse(TxtBlade.Text)
        ShowBladePitchByRadiusPercent(True)
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
            Return EncoderStatusStrip1.TimerOn
        End Get
        Set(value As Boolean)
            If value Then
                NewRadiusMeasurement()
                mSampleCount = 0
                EncoderStatusStrip1.TimerOn = True
            Else
#If NO_ENCODERS Then
                mRd += 1
                If mRd = mEncoderData.Count Then mRd = 0
#End If
                EncoderStatusStrip1.TimerOn = False
                SaveRadiusMeasurement()
            End If
            ScanControlsEnabled(value)
        End Set
    End Property

    Private Sub ShowBladePitchByRadiusPercent(ByVal show As Boolean)
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
        Dim bsBlades As New BindingList(Of Integer)
        For i As Integer = 1 To mJob.PropellerBlades
            bsBlades.Add(i)
        Next
        Dim strBlades As String = If(Job?.PropellerBlades IsNot Nothing, $"Blades = {Job?.PropellerBlades}", "")
        Dim strDiameter As String = If(Job?.PropellerDiameter IsNot Nothing, $"Dia = {Job?.PropellerDiameter}", "")
        Dim strBore As String = If(Job?.PropellerBore IsNot Nothing, $"Dia = {Job?.PropellerBore}", "")
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = If(Job?.PropellerManufacturer?.ManufacturerName, "")
        TxtStyle.Text = If(Job?.PropellerStyleNavigation?.Style1, "")
        TxtMaterial.Text = If(Job?.PropellerMaterialNavigation?.Material1, "")
        TxtBlades.Text = strBlades
        TxtDiameter.Text = strDiameter
        TxtBore.Text = strBore
    End Sub

    Private Sub ShowJobDetailsInfo()
        ' Update any controls that consume data from the current JobDetail record.
        ShowBladePitchByRadiusPercent(True)
    End Sub
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize form controls. This method needs to initialize all form controls
            ' based on some predefined "states". For example: if no encoders are detected,
            ' they're not initialized or in an error state, then disable all controls that 
            ' can access the encoders. 

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
            AddHandler EncoderStatusStrip1.EncoderEvent, AddressOf Encoders_EncoderEvent
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
        Catch ex As Exception
            MessageBox.Show("Error loading measurements form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles EncoderStatusStrip events so we can update our controls accordingly.
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
                    RefreshAll(New List(Of FrmDatabaseForm) From {mFrmJobs})
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
                RefreshAll(New List(Of FrmDatabaseForm) From {mFrmJobs})
                PanelMeasurements.Enabled = True
            Case "Undo"
                ' Enable the PanelMeasurements when the user has cancelled the JobDetails record changes.
                If Me.Current IsNot Nothing Then
                    'JobDetailsBindingSource.ResetCurrentItem() ' This should be handled in BindingSourceUndo()
                    ShowJobDetailsInfo()
                    PanelMeasurements.Enabled = True
                End If
            Case Else
        End Select
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            MeasurementsGet()
            mSampleCount += 1
            If mSampleCount = kMaxSamplesPerScan Then Scanning = False
        Catch ex As Exception
            Scanning = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobDetailsBindingSource.AddingNew
        Try
            Dim newJobDetail As JobDetail = CreateNewJobDetail()
            e.NewObject = newJobDetail
            Database.JobDetails.Add(newJobDetail)
        Catch ex As Exception
            MessageBox.Show("Error adding new job details record: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
#End Region
End Class