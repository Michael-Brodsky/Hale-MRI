Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.ModelExtensions
Public Class Form1
    Inherits FrmDatabaseForm
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Public Property Filter As String
        Set(value As String)
            RecordNavigationBar1.Filter = value
        End Set
        Get
            Return RecordNavigationBar1.Filter
        End Get
    End Property
    Public Function Find(propertyName As String, key As Object) As Integer
        Return RecordNavigationBar1.Find(propertyName, key)
    End Function
    Private Sub BindDataSources()
        Dim bs = New BindingSource() With {.DataSource = Database.Customers.Local.ToBindingList().ToDataTable()}
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bs
        DataGridView1.Refresh()
        RecordNavigationBar1.Caption = "Customers"
        RecordNavigationBar1.BoundControl = DataGridView1
        RecordNavigationBar1.RecordSource = bs
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        RecordNavigationBar1.Database = Database
        'BindCustomerVessels()
        'Doevents
        'BindMasterDetails(bs, VesselBindingSource, "Vessels")
        'bs.Filter = "CustomerName = 'Jung'"
        'Debug.Print(bs.Find("CustomerName", "Point Judth"))
        'bs.Position = bs.Find("CustomerName", "Point Judth")
        'bs.AddNew()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Database IsNot Nothing Then
            Try
                BindCustomerVessels()
            Catch ex As Exception
                MessageBox.Show("Error updating vessel jobs list: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub BindCustomerVessels()
        Dim view As DataRowView = DataGridView1.CurrentRow?.DataBoundItem
        VesselBindingSource.DataSource = Database.Customers.Local.Where(Function(x) view.Row("Id") = x.Id).FirstOrDefault()?.Vessels.ToList()
    End Sub

    Private Sub DataGridView1_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow

    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow

    End Sub
End Class