Imports LibDatabase.StoredProcedures
Imports LibDatabase.Models
Imports LibEncoder
Imports LibDatabase
Imports System.Threading
Imports LibDatabase.Contexts
Public Class FrmHaleMRI
    Private mWorkstationEncoders As New WorkstationEncoders()
    Private mFrmCalibration As FrmCalibration
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobDetails As FrmJobDetails
    Private mFrmJobs As FrmJobs
    Private mFrmMeasurements As FrmMeasurements
    Private mFrmVessels As FrmVessels
    'Git commit hash: 65eb0ef
    Private Sub CmdCalibrate_Click(sender As Object, e As EventArgs) Handles cmdCalibrate.Click
        ShowForm(mFrmCalibration)
        If mFrmCalibration.Hardware Is Nothing Then mFrmCalibration.Hardware = mWorkstationEncoders
    End Sub
    Private Sub CmdCustomers_Click(sender As Object, e As EventArgs) Handles cmdCustomers.Click
        ShowForm(mFrmCustomers)
    End Sub
    Private Sub CmdJobs_Click(sender As Object, e As EventArgs) Handles cmdJobs.Click
        ShowForm(mFrmJobs)
    End Sub
    Private Sub CmdMeasure_Click(sender As Object, e As EventArgs) Handles cmdMeasure.Click
        ShowForm(mFrmMeasurements)
        If mFrmMeasurements.Hardware Is Nothing Then mFrmMeasurements.Hardware = mWorkstationEncoders
    End Sub
    Private Sub CmdVessels_Click(sender As Object, e As EventArgs) Handles cmdVessels.Click
        ShowForm(mFrmVessels)
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm(mFrmCalibration)
        CloseForm(mFrmCustomers)
        CloseForm(mFrmJobDetails)
        CloseForm(mFrmJobs)
        CloseForm(mFrmMeasurements)
        CloseForm(mFrmVessels)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim x = ImexFiles("C:\Hale MRI 4\ScanData*.txt")
        'If x IsNot Nothing Then
        'Each file As String In x

        '
        'End If
    End Sub
End Class
