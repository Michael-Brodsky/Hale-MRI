Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
'Imports Admin
Public Class FrmHaleMRI
#Region "Private Members"
    Private mDatabase As HaleMRIContext
    Private mWorkstationEncoders As WorkstationEncoders
    Private mUser As Employee
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' NOTE: All form instances are now declared as public members of FormInstances.vb
    ' Use those members and the FormInstances.ShowForm/CloseForm methods to show/close 
    ' forms. Do not create new instances of forms directly.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#End Region
#Region "Private Interface"
    Private Sub Login(ByVal userName As String, ByVal password As String)
        ' This method should handle user login logic.
        ' For now, it just clears the text boxes.
        If String.IsNullOrWhiteSpace(userName) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        mUser = ApplicationLogin(mDatabase, userName, password)
        If mUser IsNot Nothing Then
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
            ShowForm(gFrmCustomers, mDatabase, mUser)
        Catch ex As Exception
            MessageBox.Show("Error opening customers form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdJobDetails_Click(sender As Object, e As EventArgs)
        Try
            ShowForm(gFrmJobDetails, mDatabase, mUser)
        Catch ex As Exception
            MessageBox.Show("Error opening job details form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdJobs_Click(sender As Object, e As EventArgs) Handles CmdJobs.Click
        Try
            ShowForm(gFrmJobs, mDatabase, mUser)
            gFrmJobs.Hardware = mWorkstationEncoders
        Catch ex As Exception
            MessageBox.Show("Error opening jobs form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdManufacturers_Click(sender As Object, e As EventArgs) Handles CmdManufacturers.Click
        Try
            ShowForm(gFrmManufacturers, mDatabase, mUser)
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
            ShowForm(gFrmPropellers, mDatabase, mUser)
        Catch ex As Exception
            MessageBox.Show("Error opening propellers form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdReports_Click(sender As Object, e As EventArgs) Handles CmdReports.Click
        Try
            Dim cp As New CustomPanel With {.Bounds = New Rectangle(100, 100, 100, 100), .Visible = True, .Parent = Me}
            cp.BringToFront()
            'ShowForm(gFrmReports)
        Catch ex As Exception
            MessageBox.Show("Error opening reports form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdSettings_Click(sender As Object, e As EventArgs) Handles CmdSettings.Click
        Try
            ShowForm(gFrmSettings, mDatabase, mUser)
        Catch ex As Exception
            MessageBox.Show("Error opening settings form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdVessels_Click(sender As Object, e As EventArgs) Handles CmdVessels.Click
        Try
            ShowForm(gFrmVessels, mDatabase, mUser)
        Catch ex As Exception
            MessageBox.Show("Error opening vessels form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdWorkstation_Click(sender As Object, e As EventArgs) Handles CmdWorkstation.Click
        Try
            ShowForm(gFrmCalibration)
            gFrmCalibration.Hardware = mWorkstationEncoders
        Catch ex As Exception
            MessageBox.Show("Error opening calibration form: " & ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmHaleMRI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Dispose of any resources we created.
        CloseForm(gFrmInputBox)
        CloseForm(gFrmComparison)
        CloseForm(gFrmReports)
        CloseForm(gFrmLocalPitch)
        CloseForm(gFrmMeasurements)
        CloseForm(gFrmJobDetails)
        CloseForm(gFrmJobs)
        CloseForm(gFrmPropellers)
        CloseForm(gFrmVessels)
        CloseForm(gFrmCustomers)
        CloseForm(gFrmCalibration)
        CloseForm(gFrmManufacturers)
        CloseForm(gFrmSettings)
        If mDatabase IsNot Nothing Then mDatabase.Dispose()
        mDatabase = Nothing
    End Sub

    Private Sub FrmHaleMRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure database created and load all data except the "Measurements" tables.
        Try
            mDatabase = New HaleMRIContext()
#If DEBUG Then
            MessageBox.Show("This is a Debug build.")
            mDatabase.Database.EnsureCreated()
#End If
            mDatabase.Customers.Load()
            mDatabase.Vessels.Load()
            mDatabase.Jobs.Load()
            mDatabase.JobDetails.Load()
            mDatabase.Employees.OrderBy(Function(emp) emp.EmployeeName).Load()
            mDatabase.Manufacturers.OrderBy(Function(mfg) mfg.ManufacturerName).Load()
            mDatabase.MeasurementTypes.Load()
            mDatabase.Propellers.Load()
            mDatabase.VesselServiceTypes.OrderBy(Function(vst) vst.ServiceType).Load()
            mDatabase.StateCodes.OrderBy(Function(stc) stc.StateName).Load()
            mDatabase.CountryCodes.OrderBy(Function(ctr) ctr.Country).Load()
            mDatabase.Materials.Load()
            mDatabase.Blades.Load()
            mDatabase.Styles.Load()
            mDatabase.Tolerances.Load()
            mDatabase.Rotations.Load
            mDatabase.Exclusions.Load()
            mDatabase.Cups.Load()
            mDatabase.Workstations.Load()
            mDatabase.Settings.Load()
            mDatabase.Reports.OrderBy(Function(rpt) rpt.ReportName).Load()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

#End Region
End Class
