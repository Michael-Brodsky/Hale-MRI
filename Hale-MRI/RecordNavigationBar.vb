Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Internal
Public Class RecordNavigationBar
    ' This class binds a DataGridView control to a
    ' custom DataTable based BindingSource and exposes
    ' properties and methods to coordinate user events
    ' between them. The class supports basic data 
    ' navigation (searching, sorting, filtering,
    ' traversing), updates, and manages the appearance
    ' and functionality of it's own and the bound
    ' DataGridView controls.

    Private mBindingSource As BindingSource = Nothing   ' The client's data BindingSource control we manage.
    Private mBountControl As DataGridView = Nothing     ' The client's DataGridView control we manage.
    Private mFilter As String = ""                      ' The current BindingSource filter as a SQL Where clause, if any.
    Public Property BoundControl As DataGridView
        Set(value As DataGridView)
            SetBoundControl(value)
        End Set
        Get
            Return mBountControl
        End Get
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
            Return mBindingSource.Current
        End Get
    End Property
    Public Property Database As HaleMRIContext
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
            If mBindingSource IsNot Nothing Then ChkToggleFilter.Checked = value
        End Set
        Get
            Return ChkToggleFilter.Checked
        End Get
    End Property
    Public Function Find(propertyName As String, key As Object) As Integer
        Dim index = RecordSource.Find(propertyName, key)
        Position = index
        Return index
    End Function
    Public Property Position As Integer
        Set(value As Integer)
            SetPosition(value)
        End Set
        Get
            Return mBindingSource.Position
        End Get
    End Property
    Public ReadOnly Property RecordCount As UInt32
        Get
            Return mBindingSource.Count
        End Get
    End Property
    Public Property RecordSource As BindingSource
        Set(value As BindingSource)
            SetBindingSource(value)
        End Set
        Get
            Return mBindingSource
        End Get
    End Property
    Private Sub BoundControl_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
        ' Confirm deletes before saving changes to dB.
    End Sub
    Private Sub BoundControl_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        ' Confirm additions before saving changes to dB.
    End Sub
    Private Sub ChkToggleFilter_CheckedChanged(sender As Object, e As EventArgs) Handles ChkToggleFilter.CheckedChanged
        ' Toggle the BindingSource.Filter according to the checkbox's state.
        Try
            If ChkToggleFilter.Checked AndAlso Not String.IsNullOrEmpty(mFilter) Then
                RecordSource.Filter = mFilter
            Else
                RecordSource.RemoveFilter()
            End If
        Catch ex As Exception
            MessageBox.Show("Error filtering records: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdAddNew_Click(sender As Object, e As EventArgs) Handles CmdAddNew.Click
        ' Add a new empty row to the DatagridView control.
        If RecordSource IsNot Nothing Then
            Try
                RecordSource.AddNew()
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
            MessageBox.Show("Error deleting record(s): " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoFirst_Click(sender As Object, e As EventArgs) Handles CmdGotoFirst.Click
        ' Move the cursor to the DataGridView control's first record.
        Try
            RecordSource.Position = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoLast_Click(sender As Object, e As EventArgs) Handles CmdGotoLast.Click
        ' Move the cursor to the DataGridView control's last record.
        Try
            RecordSource.Position = RecordSource.Count - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdGotoNext_Click(sender As Object, e As EventArgs) Handles CmdGotoNext.Click
        ' Move the cursor to the DataGridView control's next record.
        Try
            If RecordSource.Position < RecordSource.Count - 1 Then RecordSource.Position += 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdGotoPrevious_Click(sender As Object, e As EventArgs) Handles cmdGotoPrevious.Click
        ' Move the cursor to the DataGridView control's previous record.
        Try
            If RecordSource.Position > 0 Then RecordSource.Position -= 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        ' Save any pending changes to the database.
        If Database IsNot Nothing Then
            Try
                Database.SaveChanges()
            Catch ex As Exception
                MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If BoundControl IsNot Nothing Then BoundControl.Refresh()
        End If
    End Sub
    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click
        ' Cancel any pending changes to the database.
        If Database IsNot Nothing Then
            Try
                Rollback(Of Customer)(Database)   ' Only the Customer table is editable on this form.
            Catch ex As Exception
                MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If BoundControl IsNot Nothing Then BoundControl.Refresh()
        End If
    End Sub
    Private Sub RecordSource_DataSourceChanged(sender As Object, e As EventArgs)
        ' Update the currently displayed position when the BindingSource underlying data changes.
        Try
            ShowPosition()
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

    Private Sub RemoveSelectedRows()
        ' Remove the DataGridView control's curently selected rows.
        Dim rows() = BoundControl.SelectedRows.Cast(Of DataGridViewRow)().Select(Function(dgvr) dgvr.DataBoundItem).ToArray
        If rows.Length > 0 Then
            If MessageBox.Show($"You are about to delete {rows.Length} record(s). Click OK to continue or Cancel to cancel the delete.", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                For Each row In rows
                    RecordSource.Remove(row)
                Next
                RecordSource.EndEdit()
                ' Only do this if confirmed by user.
                'Database.SaveChanges()
                'BoundControl.Refresh()
            End If
        End If
    End Sub
    Private Sub SetBindingSource(value As BindingSource)
        ' Add handlers for the BindingSource that may effect the DataGridView control's state/appearance.
        mBindingSource = value
        If mBindingSource IsNot Nothing Then
            AddHandler mBindingSource.PositionChanged, AddressOf RecordSource_PositionChanged
            AddHandler mBindingSource.DataSourceChanged, AddressOf RecordSource_DataSourceChanged
            ShowPosition()
        End If
    End Sub
    Private Sub SetBoundControl(value As DataGridView)
        ' Add handlers for the DataGridView control that may effect it's state/appearance.
        mBountControl = value
        If mBountControl IsNot Nothing Then
            AddHandler mBountControl.RowsRemoved, AddressOf BoundControl_RowsRemoved
            AddHandler mBountControl.RowsAdded, AddressOf BoundControl_RowsAdded
        End If
    End Sub
    Private Sub SetPosition(value As Integer)
        ' Set the BindingSource.Position property only if it's valid.
        If mBindingSource IsNot Nothing AndAlso value >= 0 Then mBindingSource.Position = value
    End Sub
    Private Sub ShowPosition()
        ' Show the current position and count on the control.
        If mBindingSource.Count > 0 AndAlso mBindingSource.Position >= 0 Then
            Me.TxtCurrentPosition.Text = $"{mBindingSource.Position + 1} of {mBindingSource.Count}".ToString
        Else
            Me.TxtCurrentPosition.Text = ""
        End If
    End Sub
End Class
