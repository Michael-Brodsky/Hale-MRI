Imports LibDatabase.Contexts
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore.Metadata.Internal

Public Class FrmSettings
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mSettingsControls As New List(Of Tuple(Of String, Control))
#End Region
#Region "Public Interface"
    Public Overrides Property Database As HaleMRIContext
#End Region
#Region "Private Interface"
    Private Sub HandleControl(ByVal aControl As Control)
        ' Assigns "change" event handlers to any settings controls 
        ' to notify us when a record is being editted.
        If aControl IsNot Nothing Then
            Select Case True
                Case TypeOf aControl Is TextBox
                    AddHandler CType(aControl, TextBox).TextChanged, AddressOf Bound_TextChanged
                Case TypeOf aControl Is ComboBox
                    AddHandler CType(aControl, ComboBox).SelectionChangeCommitted, AddressOf Bound_SelectionChangeCommitted
                Case TypeOf aControl Is CheckBox
                    AddHandler CType(aControl, CheckBox).CheckedChanged, AddressOf Bound_CheckChanged
                Case TypeOf aControl Is DataGridView
                    AddHandler CType(aControl, DataGridView).CellBeginEdit, AddressOf Bound_CellBeginEdit
                Case Else
                    ' Handle other control types if necessary.
            End Select
        End If
    End Sub

    Private Property SaveUndoControlsEnabled As Boolean
        Get
            Return CmdSave.Enabled Or CmdUndo.Enabled
        End Get
        Set(value As Boolean)
            CmdSave.Enabled = value
            CmdUndo.Enabled = value
        End Set
    End Property

    Private Sub SaveSettings()
        SaveUndoControlsEnabled = False
    End Sub

    Private Sub UndoSettings()
        SaveUndoControlsEnabled = False
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub Bound_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        SaveUndoControlsEnabled = True
    End Sub

    Private Sub Bound_CheckChanged(sender As Object, e As EventArgs)
        SaveUndoControlsEnabled = True
    End Sub

    Private Sub Bound_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If cmb.SelectedIndex <> kNoCurrentSelection Then
            SaveUndoControlsEnabled = True
        End If
    End Sub

    Private Sub Bound_TextChanged(sender As Object, e As EventArgs)
        Dim txtbox As TextBox = CType(sender, TextBox)
        If txtbox.Modified Then
            SaveUndoControlsEnabled = True
            txtbox.Modified = False ' Reset the modified state to prevent repeated triggering.
        End If
    End Sub

    Private Sub CmdDatabaseFile_Click(sender As Object, e As EventArgs)
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Database File",
            .Filter = "Database Files (*.accdb)|*.accdb|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        }
        If ofd.ShowDialog = DialogResult.OK Then TxtDatabaseFile.Text = ofd.FileName
    End Sub

    Private Sub CmdDefaultFolder_Click(sender As Object, e As EventArgs) Handles CmdDefaultFolder.Click
        Dim ofd As New FolderBrowserDialog With {
            .Description = "Select Default Application Folder",
            .RootFolder = Environment.SpecialFolder.MyComputer
        }
        If ofd.ShowDialog() = DialogResult.OK Then TxtDefaultFolder.Text = ofd.SelectedPath
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        SaveSettings()
    End Sub

    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click
        UndoSettings()
    End Sub

    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_NAME, TxtCompanyName))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_ADDRESS, TxtCompanyAddress))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_PHONE, TxtCompanyPhone))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_CONTACT, TxtCompanyContact))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_EMAIL, TxtCompanyEmail))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_COMPANY_WEBSITE, TxtCompanyWebsite))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_APPLICATION_DATABASE_FILE, TxtDatabaseFile))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_APPLICATION_CONNECTION_STRING, TxtConnectionString))
        mSettingsControls.Add(New Tuple(Of String, Control)(STR_SETTING_APPLICATION_DEFAULT_FOLDER, TxtDefaultFolder))
        For Each settingControl As Tuple(Of String, Control) In mSettingsControls
            HandleControl(settingControl.Item2)
            If Database IsNot Nothing Then settingControl.Item2.Text = SettingsGet(Database, settingControl.Item1)
        Next
    End Sub
#End Region
End Class