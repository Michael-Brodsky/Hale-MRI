Imports LibDatabase.StoredProcedures
Imports LibDatabase.Models
Imports LibEncoder
Imports LibDatabase
Imports System.Threading
Public Class FrmHaleMRI
    Private mWorkstationEncoders As New WorkstationEncoders()
    Private mFrmCalibration As FrmCalibration
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobDetails As FrmJobDetails
    Private mFrmJobs As FrmJobs
    Private mFrmMeasurements As FrmMeasurements
    Private mFrmVessels As FrmVessels
    Private Sub CmdCalibrate_Click(sender As Object, e As EventArgs) Handles cmdCalibrate.Click
        If mFrmCalibration Is Nothing Then
            mFrmCalibration = New FrmCalibration(mWorkstationEncoders)
            mFrmCalibration.Show()
        Else
            mFrmCalibration.WindowState = FormWindowState.Normal
            mFrmCalibration.BringToFront()
        End If
    End Sub
    Private Sub CmdCustomers_Click(sender As Object, e As EventArgs) Handles cmdCustomers.Click
        If mFrmCustomers Is Nothing Then mFrmCustomers = New FrmCustomers()
        mFrmCustomers.Show()
    End Sub
    Private Sub CmdJobs_Click(sender As Object, e As EventArgs) Handles cmdJobs.Click
        If mFrmJobs Is Nothing Then mFrmJobs = New FrmJobs
        mFrmJobs.Show()
    End Sub
    Private Sub CmdMeasure_Click(sender As Object, e As EventArgs) Handles cmdMeasure.Click
        If mFrmMeasurements Is Nothing Then mFrmMeasurements = New FrmMeasurements(mWorkstationEncoders)
        mFrmMeasurements.Show()
    End Sub
    Private Sub CmdVessels_Click(sender As Object, e As EventArgs) Handles cmdVessels.Click
        If mFrmVessels Is Nothing Then mFrmVessels = New FrmVessels
        mFrmVessels.Show()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If mFrmJobDetails IsNot Nothing Then
            mFrmJobDetails.Close()
            mFrmJobDetails.Dispose()
        End If
        If mFrmCalibration IsNot Nothing Then
            mFrmCalibration.Close()
            mFrmCalibration.Dispose()
        End If
        If mFrmMeasurements IsNot Nothing Then
            mFrmMeasurements.Close()
            mFrmMeasurements.Dispose()
        End If
        If mFrmCustomers IsNot Nothing Then
            mFrmCustomers.Close()
            mFrmCustomers.Dispose()
        End If
        If mFrmJobs IsNot Nothing Then
            mFrmJobs.Close()
            mFrmJobs.Dispose()
        End If
        If mFrmVessels IsNot Nothing Then
            mFrmVessels.Close()
            mFrmVessels.Dispose()
        End If
        mFrmCalibration = Nothing
        mFrmJobDetails = Nothing
        mFrmMeasurements = Nothing
        mFrmCustomers = Nothing
        mFrmJobs = Nothing
        mFrmVessels = Nothing
        mWorkstationEncoders = Nothing
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
