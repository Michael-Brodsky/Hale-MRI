Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore

Public Class Form1
    Inherits FrmDatabaseForm

    Private mJobDetails As JobDetail
    Private mJob As Job

    Public ReadOnly Property Current
        Get
            Return mJobDetails
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
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails _
                .Where(Function(j) j.Job Is mJob) _
                .Include(Function(cm) cm.CellMeasurements) _
                .Include(Function(em) em.ExtremeMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .OrderBy(Function(sd) sd.StartDate).ToList())
                mJobDetails = mJob?.JobDetails?.FirstOrDefault()
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
                Database.Entry(mJobDetails).Collection(Function(cm) cm.CellMeasurements).Load()
                Database.Entry(mJobDetails).Collection(Function(em) em.ExtremeMeasurements).Load()
                Database.Entry(mJobDetails).Collection(Function(rm) rm.RadiusMeasurements).Load()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) From {mJobDetails}.ToList()
                ShowJobInfo()
            End If
        End Set
    End Property

    Private Sub MeasurementsGet()
        ' Poll the encoders and display the returned measurement values.
        TxtAngle.Text = EncoderStatusStrip1.Angle().ToString()
        TxtRadius.Text = EncoderStatusStrip1.Radius(Job?.PropellerDiameter).Value.ToString()
        TxtDepth.Text = EncoderStatusStrip1.Depth().ToString()
        TxtRadiusPercent.Text = EncoderStatusStrip1.Radius((Job?.PropellerDiameter)).Value * 100.0.ToString()
    End Sub

    Private Property Navigator As RecordNavigationBar

    Private Sub ShowJobInfo()
        ' Show the current Customer, Vessel and Job and Propeller info.
        Dim mfg As Manufacturer = Job?.PropellerManufacturer
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
            EncoderStatusStrip1.TimerOn = ChkAutoScan.Checked
            ChkAutoScan.Text = If(ChkAutoScan.Checked, "Stop", "Start")
        Catch ex As Exception
            MessageBox.Show("Error toggling the auto scan timer: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize ane form controls.
            ChkAutoScan.Text = If(ChkAutoScan.Checked, "Stop", "Start")
            ' Initialize the Navigator
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridJobDetails}
            Navigator.Database = Database
            Navigator.MasterSource = JobDetailsBindingSource
            ' Bind JobDetails (master) to Cell, Extreme and RadiusMeasurements (details)
            BindMasterDetails(JobDetailsBindingSource, CellMeasurementsBindingSource, "CellMeasurements")
            BindMasterDetails(JobDetailsBindingSource, ExtremeMeasurementsBindingSource, "ExtremeMeasurements")
            BindMasterDetails(JobDetailsBindingSource, RadiusMeasurementBindingSource, "RadiusMeasurements")
            ' These are needed by the DataGridJobDetails.
            EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.OrderBy(Function(em) em.EmployeeName).ToList())
            ClassBindingSource.DataSource = New BindingList(Of Tolerance)(Database.Tolerances.Local.ToBindingList())
            ' Initialize the EncoderStatusStrip1's .
            EncoderStatusStrip1.TimerInterval = Database.Settings.Local.FirstOrDefault().EncoderCalibrationSampleRate
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
        Catch ex As Exception
            MessageBox.Show("Error opening the measurements form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged

    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            MeasurementsGet()
        Catch ex As Exception
            ChkAutoScan.Checked = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class