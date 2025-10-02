Imports System.ComponentModel
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibEncoder
Imports LibEncoder.EncoderHardware
Imports Microsoft.EntityFrameworkCore


Public Class Form1
    Inherits FrmDatabaseForm

    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mRadiusPercent As New MovingAverage(2)              ' Keeps a moving average of RadiusPercent measurements during a scan.
    Private mRadiusMeasurement As RadiusMeasurement = Nothing   ' Stores the RadiusMeasurement to which CellMeasurements collected during a scan are assigned to. 

    Public ReadOnly Property Current
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
            ' intializes the encoder hardware.
            With EncoderStatusStrip1
                .Hardware = value
                If .Hardware IsNot Nothing Then
                    EncoderStatusStrip1.TimerInterval = Database.Settings.Local.FirstOrDefault().EncoderCalibrationSampleRate
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
                ShowJobInfo()
            End If
        End Set
    End Property

    Private Sub BladeRadiusUpdate()

    End Sub

    Private Sub CreateNewMeasurement()

    End Sub

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

    Private Sub MeasurementControlsEnable(ByVal enabled As Boolean)

    End Sub

    Private Sub MeasurementsGet()
        ' Poll the encoders and display the returned measurement values.
        ' Once you have the values you want, reference the values displayed 
        ' in the TextBoxes. Do not make further calls to encoder methods,
        ' as this will take another measurement, which may differ from the
        ' one displayed.
    End Sub

    Private Property Navigator As RecordNavigationBar

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
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = Job?.PropellerManufacturer?.ManufacturerName
        TxtStyle.Text = Job?.PropellerStyleNavigation?.Style1
        TxtMaterial.Text = Job?.PropellerMaterialNavigation?.Material1
        TxtBlades.Text = $"Blades = {Job?.PropellerBlades}"
        TxtDiameter.Text = $"Dia = {Job?.PropellerDiameter}"
        TxtBore.Text = $"Bore = {Job?.PropellerBore}"
    End Sub

    Private Sub ShowJobDetailsInfo()
        ShowBladePitchByRadiusPercent(True)
    End Sub

    Private Sub ChkAutoScan_CheckedChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            MessageBox.Show("Error toggling the encoders scan timer: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdHomeEncoders_Click(sender As Object, e As EventArgs)
        Try
            EncoderStatusStrip1.ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error homing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Navigator.Database = Database
            Navigator.MasterSource = JobDetailsBindingSource
            Navigator.BoundControls = New List(Of Control) From {DataGridJobDetails}

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
        ' Handles EncoderStausStrip events so we can update our controls accordingly.
    End Sub

    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        mJobDetails = Me.Current
        If Me.JobDetails IsNot Nothing Then ShowJobDetailsInfo()
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        ' Handles Navigator events so we can update our controls accordingly.
        Select Case e.EventName
            Case "AddNew"
                ' Disable the PanelMeasurements when the user is adding a new JobDetails record.
                PanelMeasurements.Enabled = False
            Case "Delete"
                If DeleteConfirm() Then DeleteJobDetail()
            Case "Editing"
                ' Disable the PanelMeasurements when the user is editing the JobDetails record, 
                ' unless it's the wheel pitch TextBox, which is also bound to the JobDetailsBindingSource.
                'If Me.ActiveControl Is DataGridJobDetails Then PanelMeasurements.Enabled = False
            Case "FilterOff"
            Case "FilterOn"
            Case "Find"
            Case "GotoFirst", "GotoNext", "GotoPrev"
            Case "GotoLast"
            Case "Save"
                ' Enable the PanelMeasurements when the user has saved the JobDetails record.
                PanelMeasurements.Enabled = True
            Case "Undo"
                ' Enable the PanelMeasurements when the user has cancelled the JobDetails record changes.
                If Me.Current IsNot Nothing Then
                    JobDetailsBindingSource.ResetCurrentItem()
                    ShowJobDetailsInfo()
                    PanelMeasurements.Enabled = True
                End If
            Case Else
        End Select
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            MeasurementsGet()
        Catch ex As Exception
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobDetailsBindingSource.AddingNew
        Dim newJobDetail As JobDetail = CreateNewJobDetail()
        e.NewObject = newJobDetail
        Database.JobDetails.Add(newJobDetail)
    End Sub
End Class