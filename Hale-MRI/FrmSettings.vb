Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore.Metadata.Internal

Public Class FrmSettings
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mBoundControls As List(Of Control) = Nothing    ' List of Controls bound to the MasterSource.
#End Region
#Region "Public Interface"
    Public Overrides Property Database As HaleMRIContext
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        SettingsBindingSource.DataSource = Database.Settings.Local.ToBindingList()
    End Sub
    Private Property BoundControls As List(Of Control)
        Get
            Return mBoundControls
        End Get
        Set(controls As List(Of Control))
            ' Assigns "change" event handlers to any bound controls. 
            ' This notifies us when a record is being editted.
            If controls IsNot Nothing Then
                For Each ctrl In controls
                    Select Case True
                        Case TypeOf ctrl Is TextBox
                            AddHandler CType(ctrl, TextBox).TextChanged, AddressOf Bound_TextChanged
                        Case TypeOf ctrl Is ComboBox
                            AddHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf Bound_SelectionChangeCommitted
                        Case TypeOf ctrl Is CheckBox
                            AddHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf Bound_CheckChanged
                        Case TypeOf ctrl Is DataGridView
                            AddHandler CType(ctrl, DataGridView).CellBeginEdit, AddressOf Bound_CellBeginEdit
                        Case Else
                            ' Handle other control types if necessary.
                    End Select
                Next
            End If
            mBoundControls = controls
        End Set
    End Property

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
        BindingSourceSave(Database, SettingsBindingSource)
        SaveUndoControlsEnabled = False
    End Sub

    Private Sub UndoSettings()
        BindingSourceUndo(Database, SettingsBindingSource)
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

    Private Sub CmdDatabaseFile_Click(sender As Object, e As EventArgs) Handles CmdDatabaseFile.Click
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Database File",
            .Filter = "Database Files (*.accdb)|*.accdb|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        }
        If ofd.ShowDialog() = DialogResult.OK Then TxtDatabaseFile.Text = ofd.FileName
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
        BoundControls = New List(Of Control) From {
            TxtCompanyName,
            TxtCompanyAddress,
            TxtCompanyWebsite,
            TxtCompanyEmail,
            TxtCompanyPhone,
            TxtCompanyContact,
            TxtDatabaseFile,
            TxtConnectionString,
            TxtDefaultFolder
        }
    End Sub
#End Region
End Class