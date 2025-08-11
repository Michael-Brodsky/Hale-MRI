Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore
'Imports Admin
Public Class FrmHaleMRI
#Region "Private Members"
    Private mDatabase As New HaleMRIContext
    Private mWorkstationEncoders As New WorkstationEncoders()
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmCalibration As FrmCalibration
    Private mFrmCustomers As FrmCustomers
    Private mFrmJobDetails As FrmJobDetails
    Private mFrmJobs As FrmJobs
    Private mFrmManufacturers As FrmManufacturers
    Private mFrmMeasurements As FrmMeasurements
    Private mFrmReports As FrmReports
    Private mFrmPropellers As FrmPropellers
    Private mFrmSettings As FrmSettings
    Private mFrmVessels As FrmVessels
#End Region
#Region "Private Interface"
    Private Sub Login(ByVal userName As String, ByVal password As String)
        ' This method should handle user login logic.
        ' For now, it just clears the text boxes.
        If String.IsNullOrWhiteSpace(userName) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If ApplicationLogin(userName, password) <> kLoginFailed Then
            ' If login is successful, proceed to the main application.
            ' Here you can initialize the main form or load the necessary data.
            PanelLogin.Hide() ' Hide the login form if needed.
            PanelMenuButtons.Show() ' Show the main menu buttons.
        Else
            ' If login fails, show an error message.
            MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TxtUser.Text = String.Empty
        TxtPassword.Text = String.Empty
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdLoginCancel.Click
        Try
            TxtPassword.Text = String.Empty
            TxtUser.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmdCustomers_Click(sender As Object, e As EventArgs) Handles CmdCustomers.Click
        Try
            ShowForm(mFrmCustomers, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening customers form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdJobDetails_Click(sender As Object, e As EventArgs)
        Try
            ShowForm(mFrmJobDetails, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening job details form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdJobs_Click(sender As Object, e As EventArgs) Handles CmdJobs.Click
        Try
            ShowForm(mFrmJobs, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening jobs form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdManufacturers_Click(sender As Object, e As EventArgs) Handles CmdManufacturers.Click
        Try
            ShowForm(mFrmManufacturers, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening manufacturers form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdLoginOK.Click
        Try
            Login(TxtUser.Text, TxtPassword.Text)
        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdPropellers_Click(sender As Object, e As EventArgs) Handles CmdPropellers.Click
        Try
            ShowForm(mFrmPropellers, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening propellers form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdReports_Click(sender As Object, e As EventArgs) Handles CmdReports.Click
        Try
            ShowForm(mFrmReports)
        Catch ex As Exception
            MessageBox.Show("Error opening reports form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdSettings_Click(sender As Object, e As EventArgs) Handles CmdSettings.Click
        Try
            ShowForm(mFrmSettings)
        Catch ex As Exception
            MessageBox.Show("Error opening settings form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdVessels_Click(sender As Object, e As EventArgs) Handles CmdVessels.Click
        Try
            ShowForm(mFrmVessels, mDatabase)
        Catch ex As Exception
            MessageBox.Show("Error opening vessels form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdWorkstation_Click(sender As Object, e As EventArgs) Handles CmdWorkstation.Click
        Try
            ShowForm(mFrmCalibration)
            If mFrmCalibration.Hardware Is Nothing Then mFrmCalibration.Hardware = mWorkstationEncoders
        Catch ex As Exception
            MessageBox.Show("Error opening calibration form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmHaleMRI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Dispose of any resources we created.
        CloseForm(mFrmCalibration)
        CloseForm(mFrmCustomers)
        CloseForm(mFrmJobDetails)
        CloseForm(mFrmJobs)
        CloseForm(mFrmManufacturers)
        CloseForm(mFrmMeasurements)
        CloseForm(mFrmReports)
        CloseForm(mFrmSettings)
        CloseForm(mFrmVessels)
        If mDatabase IsNot Nothing Then mDatabase.Dispose()
        mDatabase = Nothing
    End Sub

    Private Sub FrmHaleMRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure database created and load all data except the "Measurements" tables.
        Try
            mDatabase.Database.EnsureCreated()
            mDatabase.Customers.Load()
            mDatabase.Vessels.Load()
            mDatabase.Jobs.Load()
            mDatabase.JobDetails.Load()
            mDatabase.Employees.Load()
            mDatabase.Manufacturers.Load()
            mDatabase.Propellers.Load()
            mDatabase.VesselServiceTypes.Load()
            mDatabase.StateCodes.Load()
            mDatabase.CountryCodes.Load()
            mDatabase.Materials.Load()
            mDatabase.Blades.Load()
            mDatabase.Styles.Load()
            mDatabase.Tolerances.Load()
            mDatabase.Rotations.Load
            mDatabase.Exclusions.Load()
            mDatabase.Cups.Load()
            mDatabase.Workstations.Load()
        Catch ex As Exception
            MessageBox.Show("Error loading database: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtUser_TextChanged(sender As Object, e As EventArgs) Handles TxtUser.TextChanged
        Try
            CmdLoginOK.Enabled = Not String.IsNullOrWhiteSpace(TxtUser.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtPassword.Text)
            CmdLoginCancel.Enabled = CmdLoginOK.Enabled
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged
        Try
            CmdLoginOK.Enabled = Not String.IsNullOrWhiteSpace(TxtUser.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtPassword.Text)
            CmdLoginCancel.Enabled = CmdLoginOK.Enabled
        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class
