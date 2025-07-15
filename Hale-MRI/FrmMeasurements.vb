Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.Imex
Imports LibEncoder
Imports LibEncoder.USDigital
Public Class FrmMeasurements
    Inherits FrmDatabaseForm
#Region "Constants"

#End Region
#Region "Private Members"
    Private mBlades As Integer
    Private mHardware As WorkstationEncoders
    Private mJobDetails As JobDetail
    Private mJob As Job
#End Region
#Region "Public Interface"
    Public Property Hardware As WorkstationEncoders
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
        End Set
    End Property
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                For i As Integer = 1 To mJob.Blades
                    ComboBladeId.Items.Add(i.ToString())
                Next
            End If
        End Set
    End Property
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            If value IsNot Nothing Then
                mJobDetails = value
                If mJobDetails IsNot Nothing Then
                    RadiusMeasurementBindingSource.DataSource = Database.RadiusMeasurements.Where(Function(j) j.JobDetailsId = mJobDetails.Id).ToList()
                    'CellMeasurementsBindingSource.DataSource = Database.CellMeasurements.Where(Function(j) j.JobDetailsId = mJobDetails.Id).ToList()
                    'ExtremeMeasurementsBindingSource.DataSource = Database.ExtremeMeasurements.Where(Function(j) j.JobDetailsId = mJobDetails.Id).ToList()
                End If
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub HomeEncoders()
        'With mHardware.Encoders
        '    .ResetCount(USDigital.ANGLE_ENCODER)
        '    .ResetCount(USDigital.RADIUS_ENCODER)
        '    .ResetCount(USDigital.DEPTH_ENCODER)
        'End With
        'cmdHome.Visible = False
        'cmdHome.Enabled = False
    End Sub
    Private Sub MeasurementsGet()
        ' Uset this in place of UpdateFields()
        txtAngle.Text = 42.0
        txtRadius.Text = 1.0
        txtDepth.Text = 99.9
        txtRadiusPercent.Text = 50.0
    End Sub
    Private Sub MeasurementsSave()
        ' Saves the currently displayed measurements to the database.
        If Database IsNot Nothing Then
            Dim cm As New CellMeasurement With {
                .JobDetailsId = mJobDetails.Id,
                .Angle = Convert.ToDouble(txtAngle.Text),
                .Depth = Convert.ToDouble(txtDepth.Text)
            }
            Dim rm As New RadiusMeasurement With {
                .JobDetailsId = mJobDetails.Id,
                .Radius = Convert.ToDouble(txtRadius.Text),
                .BladeId = ComboBladeId.SelectedIndex + 1
            }
            Database.CellMeasurements.Add(cm)
            Database.RadiusMeasurements.Add(rm)
            Database.SaveChanges()
        End If
    End Sub
    Private Sub UpdateFields()
        With mHardware.Encoders
            txtAngle.Text = .Angle
            txtRadius.Text = .Radius(mJobDetails.Diameter).Value
            txtDepth.Text = .Depth
            txtRadiusPercent.Text = .Radius((mJobDetails.Diameter).Value * 100.0).ToString()
        End With
    End Sub

#End Region
#Region "UI Event Handlers"
    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles cmdHome.Click
        HomeEncoders()
    End Sub
    Private Sub CmdStopScan_Click(sender As Object, e As EventArgs)
        Try
            MeasurementsSave()
        Catch ex As Exception
            MessageBox.Show("Error saving measurements: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CountUpdate_Tick(sender As Object, e As EventArgs)
        'UpdateFields()
    End Sub
    Private Sub CmdZero_Click(sender As Object, e As EventArgs) Handles cmdZero.Click
        Try
            mHardware.Encoders.ResetCount(ANGLE_ENCODER)
            mHardware.Encoders.ResetCount(RADIUS_ENCODER)
            mHardware.Encoders.ResetCount(DEPTH_ENCODER)
        Catch ex As Exception
            MessageBox.Show("Error zeroing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdStartScan_Click(sender As Object, e As EventArgs)
        Try
            MeasurementsGet()
        Catch ex As Exception
            MessageBox.Show("Error getting measurements: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmMeasurements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            timerMeasurements.Interval = Database.Settings.FirstOrDefault().EncoderCalibrationSampleRate
        Catch ex As Exception
            MessageBox.Show("Error loading settings: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChkMeasurements_CheckedChanged(sender As Object, e As EventArgs) Handles chkMeasurements.CheckedChanged
        Try
            timerMeasurements.Enabled = chkMeasurements.Checked
            cmdHome.Enabled = Not chkMeasurements.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub TimerMeasurements_Tick(sender As Object, e As EventArgs) Handles timerMeasurements.Tick
        Try
            MeasurementsGet()
        Catch ex As Exception
            chkMeasurements.Checked = False
            MessageBox.Show("Error updating measurements: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class