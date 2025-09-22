Imports System.ComponentModel
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibEncoder.EncoderHardware
Imports Microsoft.EntityFrameworkCore
Imports System.Linq


Public Class Form1
    Inherits FrmDatabaseForm

    Private mJobDetails As JobDetail
    Private mJob As Job

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
            With EncoderStatusStrip1
                .Hardware = value
                If .Hardware IsNot Nothing AndAlso .Hardware.Encoders IsNot Nothing AndAlso Not .Hardware.Encoders.Initialized Then EncoderStatusStrip1.Initialize()
            End With
        End Set
    End Property

    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                ' Load all JobDetail records and their measurements data.
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails _
                .Where(Function(j) j.Job Is mJob) _
                .Include(Function(cm) cm.CellMeasurements) _
                .Include(Function(em) em.ExtremeMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .OrderBy(Function(sd) sd.StartDate).ToList())
                JobDetailsBindingSource.MoveLast()
                JobDetailsBindingSource.MoveFirst()
                ShowJobInfo()
            End If
        End Set
    End Property

    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                ' Load only the given JobDetail record and its measurements data.
                Database.Entry(mJobDetails).Collection(Function(cm) cm.CellMeasurements).Load()
                Database.Entry(mJobDetails).Collection(Function(em) em.ExtremeMeasurements).Load()
                Database.Entry(mJobDetails).Collection(Function(rm) rm.RadiusMeasurements).Load()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) From {mJobDetails}.ToList()
                ShowJobInfo()
            End If
        End Set
    End Property

    Private Sub BladeRadiusUpdate()
        Dim rm As IList(Of RadiusMeasurement) = If(RadiusMeasurementBindingSource.Count > 0, RadiusMeasurementBindingSource.List, New List(Of RadiusMeasurement))
        BladeRadiusBindingSource.DataSource =
                If(JobDetails IsNot Nothing AndAlso JobDetails.Id IsNot Nothing,
                    rm.ToList() _
                    .GroupBy(Function(cm) cm?.BladeId) _
                    .Select(Function(brm) New With {.BladeId = brm.Key, .AvgRadius = brm.Average(Function(cm) cm?.Radius)}) _
                    .OrderBy(Function(cm) cm?.BladeId) _
                    .ToList(),
                Nothing)
        'End If
    End Sub

    Private Sub CreateNewMeasurement()
        CellMeasurementsBindingSource.AddNew()
        ExtremeMeasurementsBindingSource.AddNew()
        RadiusMeasurementBindingSource.AddNew()
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
        TxtAngle.Enabled = enabled
        TxtDepth.Enabled = enabled
        TxtRadius.Enabled = enabled
        TxtRadiusPercent.Enabled = enabled
        TxtWheelPitch.Enabled = enabled
        ChkAutoScan.Enabled = enabled AndAlso Hardware.Encoders.Initialized
        CmdHomeEncoders.Enabled = ChkAutoScan.Enabled AndAlso Not ChkAutoScan.Checked
    End Sub

    Private Sub MeasurementsGet()
        ' Poll the encoders and display the returned measurement values.
        ' Once you have the values you want, reference the values displayed 
        ' in the TextBoxes. Do not make further calls to encoder methods,
        ' as this will take another measurement, which may differ from the
        ' one displayed.
        TxtAngle.Text = EncoderStatusStrip1.Angle().ToString()
        TxtRadius.Text = EncoderStatusStrip1.Radius(Job?.PropellerDiameter).Value.ToString()
        TxtDepth.Text = EncoderStatusStrip1.Depth().ToString()
        TxtRadiusPercent.Text = EncoderStatusStrip1.Radius((Job?.PropellerDiameter)).Value * 100.0.ToString()
    End Sub

    Private Property Navigator As RecordNavigationBar

    Private Sub ShowJobInfo()
        ' Show the current Customer, Vessel, Job and Propeller info.
        Dim bsBlades As New BindingList(Of Integer)
        For i As Integer = 1 To mJob.PropellerBlades
            bsBlades.Add(i)
        Next
        ComboBlade.DataSource = bsBlades
        ComboBlade.SelectedItem = Nothing
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

    Private Sub ChkAutoScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAutoScan.CheckedChanged
        Try
            ' Toggle the auto scan timer on/off.
            EncoderStatusStrip1.TimerOn = ChkAutoScan.Checked
            ' Update our controls accordingly.
            ChkAutoScan.Text = If(ChkAutoScan.Checked, "Stop", "Start")
            CmdHomeEncoders.Enabled = Not ChkAutoScan.Checked   ' Home button disabled while scanning.
            ComboBlade.Enabled = Not ChkAutoScan.Checked        ' Blade changes disabled while scanning.
            ' JobDetails changes disabled while scanning.
            RecordNavigationBar1.Enabled = Not ChkAutoScan.Checked AndAlso Current IsNot Nothing
            DataGridJobDetails.IsEnabled(RecordNavigationBar1.Enabled)
        Catch ex As Exception
            MessageBox.Show("Error toggling the encoders scan timer: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdHomeEncoders_Click(sender As Object, e As EventArgs) Handles CmdHomeEncoders.Click
        Try
            EncoderStatusStrip1.ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error homing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize ane form controls.
            DataGridBladeRadius.AutoGenerateColumns = False
            PanelMeasurements.Enabled = (EncoderStatusStrip1.Status = EncoderStatus.Ready)
            ' Initialize the Navigator
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {
                DataGridJobDetails,
                TxtAngle,
                TxtDepth,
                TxtRadius,
                TxtWheelPitch
            }
            Navigator.Database = Database
            Navigator.MasterSource = JobDetailsBindingSource
            ' Bind JobDetails (master) to Cell, Extreme and RadiusMeasurements (details)
            BindMasterDetails(JobDetailsBindingSource, CellMeasurementsBindingSource, "CellMeasurements")
            BindMasterDetails(JobDetailsBindingSource, ExtremeMeasurementsBindingSource, "ExtremeMeasurements")
            BindMasterDetails(JobDetailsBindingSource, RadiusMeasurementBindingSource, "RadiusMeasurements")
            ' These are needed by the DataGridJobDetails.
            ClassBindingSource.DataSource = New BindingList(Of Tolerance)(Database.Tolerances.Local.ToBindingList())
            EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.OrderBy(Function(em) em.EmployeeName).ToList())
            MeasurementTypesBindingSource.DataSource = New BindingList(Of MeasurementType)(Database.MeasurementTypes.OrderBy(Function(mt) mt.Id).ToList())
            ' Set the auto scan sample rate.
            EncoderStatusStrip1.TimerInterval = Database.Settings.Local.FirstOrDefault().EncoderCalibrationSampleRate
            ' Add Navigator and EncoderStatusStrip event handlers.
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
            AddHandler EncoderStatusStrip1.EncoderEvent, AddressOf Encoders_EncoderEvent
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show("Error opening the measurements form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles EncoderStausStrip events so we can update our controls accordingly.
        Select Case e.EventName
            Case "Error", "NoEncoders", "NotInitialized"
                ' Disable the PanelMeasurements when the encoders state would prevent
                ' measurements from being taken.
                PanelMeasurements.Enabled = False
            Case "Ready"
                ' Enable the PanelMeasurements if the encoders are intialized and
                ' we're not currently taking measurements.
                If Not ChkAutoScan.Checked Then PanelMeasurements.Enabled = True
            Case Else
        End Select
    End Sub
    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        ' For example, show the average RadiusMeasurements.Radius for each blade of a JobDetail record.
        ' The LINQ query is the SQL equivqalent of:
        '   SELECT [Blade ID] AS [BladeId], Avg([Radius]) AS [AvgRadius]
        '   FROM [Radius Measurements]
        '   GROUP BY [Blade ID]
        '   ORDER BY [Blade ID];
        '
        ' The DataGridBladeRadius is bound to the BladeRadiusBindingSource and
        ' has two colmuns with DataPropertyName "BladeId" and "AvgRadius" which
        ' are the same names of the columns produced by the LINQ query.
        mJobDetails = Me.Current
        If Me.JobDetails IsNot Nothing Then BladeRadiusUpdate()

        'BladeRadiusBindingSource.ResetBindings(False)
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
                If Me.ActiveControl Is DataGridJobDetails Then PanelMeasurements.Enabled = False
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
                    BladeRadiusUpdate()
                    PanelMeasurements.Enabled = True
                End If
            Case Else
        End Select
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            MeasurementsGet()
        Catch ex As Exception
            ChkAutoScan.Checked = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobDetailsBindingSource.AddingNew
        Dim newJobDetail As JobDetail = CreateNewJobDetail()
        e.NewObject = newJobDetail
        Database.JobDetails.Add(newJobDetail)
    End Sub

    Private Sub CellMeasurementsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles CellMeasurementsBindingSource.AddingNew
        Dim newMeasurement As New CellMeasurement With {
            .JobDetails = mJobDetails,
            .Angle = Double.Parse(TxtAngle.Text),
            .Depth = Double.Parse(TxtDepth.Text)
        }
        e.NewObject = newMeasurement
        Database.CellMeasurements.Add(newMeasurement)
    End Sub

    Private Sub ExtremeMeasurementsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles ExtremeMeasurementsBindingSource.AddingNew
        Dim newMeasurement As New ExtremeMeasurement With {
            .JobDetails = mJobDetails,
            .BladeId = ComboBlade.SelectedValue,
            .Extreme = 42.0
        }
        e.NewObject = newMeasurement
        Database.ExtremeMeasurements.Add(newMeasurement)
    End Sub

    Private Sub RadiusMeasurementBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles RadiusMeasurementBindingSource.AddingNew
        Dim newMeasurement As New LibDatabase.Models.RadiusMeasurement With {
            .JobDetails = mJobDetails,
            .BladeId = ComboBlade.SelectedValue,
            .Radius = Double.Parse(TxtRadius.Text)
        }
        e.NewObject = newMeasurement
        Database.RadiusMeasurements.Add(newMeasurement)
    End Sub

    Private Sub ChkAutoScan_Click(sender As Object, e As EventArgs) Handles ChkAutoScan.Click
        CmdSaveMeasurement.Enabled = Not ChkAutoScan.Checked
        CmdUndoMeasurement.Enabled = Not ChkAutoScan.Checked
    End Sub

    Private Sub CmdSaveMeasurement_Click(sender As Object, e As EventArgs) Handles CmdSaveMeasurement.Click
        CreateNewMeasurement()
        BindingSourceSave(Database, JobDetailsBindingSource)
        CmdSaveMeasurement.Enabled = False
        CmdUndoMeasurement.Enabled = False
    End Sub

    Private Sub CmdUndoMeasurement_Click(sender As Object, e As EventArgs) Handles CmdUndoMeasurement.Click
        TxtAngle.Clear()
        TxtDepth.Clear()
        TxtRadius.Clear()
        TxtRadiusPercent.Clear()
        CmdSaveMeasurement.Enabled = False
        CmdUndoMeasurement.Enabled = False
    End Sub

    Private Sub ComboBlade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBlade.SelectedIndexChanged
        ' Disable the measurement controls if no blade is selected.
        MeasurementControlsEnable(ComboBlade.SelectedItem IsNot Nothing)
    End Sub

    Private Sub CmdNext_Click(sender As Object, e As EventArgs) Handles CmdNext.Click
        ComboBlade.SelectedIndex = If(ComboBlade.SelectedIndex < ComboBlade.Items.Count - 1, ComboBlade.SelectedIndex + 1, 0)
        ChkAutoScan.Checked = True
    End Sub
End Class