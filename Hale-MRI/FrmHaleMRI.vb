Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore
Public Class FrmHaleMRI
    Private mDatabase As New HaleMRIContext
    Private mWorkstationEncoders As New WorkstationEncoders()
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmCalibration As FrmCalibration
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobDetails As FrmJobDetails
    Private mFrmJobs As FrmJobs
    Private mFrmMeasurements As FrmMeasurements
    Private mFrmVessels As FrmVessels
    Private Sub CmdCalibrate_Click(sender As Object, e As EventArgs) Handles cmdCalibrate.Click
        ShowForm(mFrmCalibration)
        If mFrmCalibration.Hardware Is Nothing Then mFrmCalibration.Hardware = mWorkstationEncoders
    End Sub
    Private Sub CmdCustomers_Click(sender As Object, e As EventArgs) Handles cmdCustomers.Click
        ShowForm(mFrmCustomers, mDatabase)
    End Sub
    Private Sub CmdJobDetails_Click(sender As Object, e As EventArgs) Handles CmdJobDetails.Click
        ShowForm(mFrmJobDetails, mDatabase)
    End Sub
    Private Sub CmdJobs_Click(sender As Object, e As EventArgs) Handles cmdJobs.Click
        ShowForm(mFrmJobs, mDatabase)
    End Sub
    'Private Sub CmdMeasure_Click(sender As Object, e As EventArgs) Handles cmdMeasure.Click
    '    ShowForm(mFrmMeasurements)
    '    If mFrmMeasurements.Hardware Is Nothing Then mFrmMeasurements.Hardware = mWorkstationEncoders
    'End Sub
    Private Sub CmdVessels_Click(sender As Object, e As EventArgs) Handles cmdVessels.Click
        ShowForm(mFrmVessels, mDatabase)
    End Sub
    Private Sub FrmHaleMRI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm(mFrmCalibration)
        CloseForm(mFrmCustomers)
        CloseForm(mFrmJobDetails)
        CloseForm(mFrmJobs)
        CloseForm(mFrmMeasurements)
        CloseForm(mFrmVessels)
        If mDatabase IsNot Nothing Then mDatabase.Dispose()
        mDatabase = Nothing
    End Sub

    Private Sub FrmHaleMRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure database created and load all data except the "Measurements" tables.
        mDatabase.Database.EnsureCreated()
        mDatabase.Customers.Load()
        mDatabase.Vessels.Load()
        mDatabase.Jobs.Load()
        'mDatabase.JobDetails.Include(Function(j) j.Job).Load()
        mDatabase.JobDetails.Load()
        mDatabase.Employees.Load()
        mDatabase.Manufacturers.Load()
        mDatabase.VesselServiceTypes.Load()
        mDatabase.StateCodes.Load()
        mDatabase.CountryCodes.Load()
        mDatabase.Materials.Load()
        mDatabase.Blades.Load()
        mDatabase.Styles.Load()
        mDatabase.Tolerances.Load()
        mDatabase.Rotations.Load
        mDatabase.Exclusions.Load()
        mDatabase.Workstations.Load()
    End Sub
End Class
