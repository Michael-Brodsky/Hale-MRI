Imports LibDatabase.Contexts
Imports LibDatabase.StoredProcedures
Public Class RecordNavigationBar
    ' This class binds a DataGridView control to a
    ' custom DataTable based BindingSource and exposes
    ' properties and methods to coordinate user events
    ' between them. The class supports basic data 
    ' navigation (searching, sorting, filtering,
    ' traversing), updates, and manages the appearance
    ' and functionality of it's own and the bound
    ' DataGridView controls.
#Region "Private Members"
    Private mMasterSource As BindingSource = Nothing                ' The client's data BindingSource we manage.
    Private WithEvents mMasterControl As DataGridView = Nothing     ' The client's DataGridView control we manage.
    Private mFilter As String = ""                                  ' The current BindingSource filter as a SQL Where clause, if any.
    Private mEditMode As Boolean = False                            ' The current edit mode state of the RecordNavigator and any bound controls.
    Private mBoundControls As New List(Of Control)()                ' The list of controls bound to the BindingSource.
#End Region
#Region "Public Inteface"
    Public Property BoundControls As List(Of Control)
        Get
            Return mBoundControls
        End Get
        Set(value As List(Of Control))
            mBoundControls = value
            BindControls(True)
        End Set
    End Property
    Public Property Caption As String
        Set(value As String)
            LabCaption.Text = value
        End Set
        Get
            Return LabCaption.Text
        End Get
    End Property
    Public ReadOnly Property Current As Object
        Get
            Return mMasterSource.Current
        End Get
    End Property
    Public Property Database As HaleMRIContext
    Public Function Find(propertyName As String, key As Object) As Integer
        Dim index = MasterSource.Find(propertyName, key)
        Position = index
        Return index
    End Function
    Public Property EditMode As Boolean
        Get
            Return mEditMode
        End Get
        Set(value As Boolean)
            SetEditMode(value)
        End Set
    End Property
    Public Overloads Property Enabled As Boolean
        Set(value As Boolean)
            ' Enable or disable the RecordNavigationBar and any bound controls.
            If mBoundControls IsNot Nothing Then
                For Each ctrl In mBoundControls
                    ctrl.Enabled = value
                Next
            End If
            MyBase.Enabled = value
        End Set
        Get
            Return MyBase.Enabled
        End Get
    End Property
    Public Property Filter As String
        Set(value As String)
            mFilter = value
            FilterOn = Not String.IsNullOrEmpty(mFilter)
        End Set
        Get
            Return mFilter
        End Get
    End Property
    Public Property FilterOn As Boolean
        Set(value As Boolean)
            If mMasterSource IsNot Nothing Then ChkToggleFilter.Checked = value
        End Set
        Get
            Return ChkToggleFilter.Checked
        End Get
    End Property
    Public Property MasterControl As DataGridView
    Public Property MasterSource As BindingSource
        Set(value As BindingSource)
            SetBindingSource(value)
        End Set
        Get
            Return mMasterSource
        End Get
    End Property
    Public Property Position As Integer
        Set(value As Integer)
            SetPosition(value)
        End Set
        Get
            Return mMasterSource.Position
        End Get
    End Property
    Public ReadOnly Property RecordCount As UInt32
        Get
            Return mMasterSource.Count
        End Get
    End Property
#End Region
#Region "Event Handlers"
    Private Sub BoundClick(sender As Object, e As EventArgs)
        EditMode = True
    End Sub
    Private Sub BoundSelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If cmb.SelectedIndex <> -1 Then
            EditMode = True
        End If
    End Sub
    Private Sub BoundTextChanged(sender As Object, e As EventArgs)
        Dim txtbox As TextBox = CType(sender, TextBox)
        If txtbox.Modified Then
            ' If the TextBox control's text has been modified, set the edit mode to true.
            EditMode = True
            txtbox.Modified = False ' Reset the modified state to prevent repeated triggering.
        End If
    End Sub
    Private Sub ChkToggleFilter_CheckedChanged(sender As Object, e As EventArgs) Handles ChkToggleFilter.CheckedChanged
        ' Toggle the BindingSource.Filter according to the checkbox's state.
        Try
            If ChkToggleFilter.Checked AndAlso Not String.IsNullOrEmpty(mFilter) Then
                MasterSource.Filter = mFilter
            Else
                MasterSource.RemoveFilter()
            End If
        Catch ex As Exception
            MessageBox.Show("Error filtering records: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdAddNew_Click(sender As Object, e As EventArgs) Handles CmdAddNew.Click
        ' Add a new empty row to the DatagridView control.
        If MasterSource IsNot Nothing Then
            Try
                MasterSource.AddNew()
            Catch ex As Exception
                MessageBox.Show("Error adding new record: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        ' Delete the DataGridView control's currently selected rows.
        Try
            RemoveSelectedRows()
        Catch ex As Exception
            MessageBox.Show("Error deleting record(s): " & ex.InnerException.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoFirst_Click(sender As Object, e As EventArgs) Handles CmdGotoFirst.Click
        ' Move the cursor to the DataGridView control's first record.
        Try
            MasterSource.Position = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoLast_Click(sender As Object, e As EventArgs) Handles CmdGotoLast.Click
        ' Move the cursor to the DataGridView control's last record.
        Try
            MasterSource.Position = MasterSource.Count - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoNext_Click(sender As Object, e As EventArgs) Handles CmdGotoNext.Click
        ' Move the cursor to the DataGridView control's next record.
        Try
            If MasterSource.Position < MasterSource.Count - 1 Then MasterSource.Position += 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdGotoPrevious_Click(sender As Object, e As EventArgs) Handles CmdGotoPrevious.Click
        ' Move the cursor to the DataGridView control's previous record.
        Try
            If MasterSource.Position > 0 Then MasterSource.Position -= 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        ' Save any pending changes to the database.
        If Database IsNot Nothing Then
            Try
                BindingSourceSave(Database, MasterSource)
                EditMode = False ' Disable edit mode after saving changes.
            Catch ex As Exception
                MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If MasterControl IsNot Nothing Then MasterControl.Refresh()
        End If
    End Sub
    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click
        ' Cancel any pending changes to the database.
        If Database IsNot Nothing Then
            Try
                BindingSourceUndo(Database, MasterSource)
                EditMode = False ' Disable edit mode after undoing changes.
            Catch ex As Exception
                MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub RecordSource_DataSourceChanged(sender As Object, e As EventArgs)
        ' Update the currently displayed position when the BindingSource underlying data changes.
        Try
            ShowPosition()
            EditMode = False ' Disable edit mode when the data source changes.
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecordSource_PositionChanged(sender As Object, e As EventArgs)
        ' Update the currently displayed position when the DataGridView control's cursor moves underlying data changes.
        Try
            ShowPosition()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RecordSource_RowsRemoved(ByRef sender As Object, ByRef e As DataGridViewRowsRemovedEventArgs)
        ' Update the currently displayed position when the BindingSource underlying data changes.
    End Sub
#End Region
#Region "Private Interface"
    Private Sub BindControls(ByVal bind As Boolean)
        ' Adds/removes event handlers to the collection of currently bound controls
        ' to enable/disable them and set the EditMode of the RecordNavigationBar.
        If mBoundControls IsNot Nothing Then
            For Each ctrl In mBoundControls
                Select Case True
                    Case TypeOf ctrl Is TextBox
                        If bind Then
                            AddHandler CType(ctrl, TextBox).TextChanged, AddressOf BoundTextChanged
                        Else
                            RemoveHandler CType(ctrl, TextBox).TextChanged, AddressOf BoundTextChanged
                        End If
                    Case TypeOf ctrl Is ComboBox
                        If bind Then
                            AddHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf BoundSelectionChangeCommitted
                        Else
                            RemoveHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf BoundSelectionChangeCommitted
                        End If
                    Case TypeOf ctrl Is CheckBox
                        If bind Then
                            AddHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf BoundClick
                        Else
                            RemoveHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf BoundClick
                        End If
                    Case Else
                        ' Handle other control types if necessary.
                End Select
            Next
        End If
    End Sub
    Private Sub RemoveSelectedRows()
        ' Remove the DataGridView control's curently selected rows.
        Dim rows() = MasterControl.SelectedRows.Cast(Of DataGridViewRow)().Select(Function(dgvr) dgvr.DataBoundItem).ToArray
        If rows.Length > 0 Then
            If MessageBox.Show($"You are about to permanently delete {rows.Length} record(s). Click OK to continue or Cancel to cancel the delete.", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                For Each row In rows
                    MasterSource.Remove(row)
                Next
                MasterSource.EndEdit()
                Database.SaveChanges()
                If MasterControl IsNot Nothing Then MasterControl.Refresh()
            End If
        End If
    End Sub
    Private Sub SetBindingSource(value As BindingSource)
        ' Add handlers for the BindingSource that may effect the DataGridView control's state/appearance.
        mMasterSource = value
        If mMasterSource IsNot Nothing Then
            AddHandler mMasterSource.PositionChanged, AddressOf RecordSource_PositionChanged
            AddHandler mMasterSource.DataSourceChanged, AddressOf RecordSource_DataSourceChanged
            ShowPosition()
        End If
    End Sub
    Private Sub SetEditMode(ByVal value As Boolean)
        ' Set the enabled state of the RecordNavigationBar's controls
        ' according to the given value
        CmdAddNew.Enabled = Not value
        CmdDelete.Enabled = Not value
        CmdGotoFirst.Enabled = Not value
        CmdGotoLast.Enabled = Not value
        CmdGotoNext.Enabled = Not value
        CmdGotoPrevious.Enabled = Not value
        CmdSave.Enabled = value
        CmdUndo.Enabled = value
        mEditMode = value
    End Sub
    Private Sub SetPosition(value As Integer)
        ' Set the BindingSource.Position property only if it's valid.
        If mMasterSource IsNot Nothing AndAlso value >= 0 Then mMasterSource.Position = value
    End Sub
    Private Sub ShowPosition()
        ' Show the current position and count on the control.
        If mMasterSource.Count > 0 AndAlso mMasterSource.Position >= 0 Then
            Me.TxtCurrentPosition.Text = $"{mMasterSource.Position + 1} of {mMasterSource.Count}".ToString
        Else
            Me.TxtCurrentPosition.Text = ""
        End If
    End Sub
#End Region
End Class
