Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore.ChangeTracking.Internal
Public Class FrmCustomers
    Inherits FrmDatabaseForm
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmVessels As FrmVessels
    Private mFrmJobs As FrmJobs
    Public Property Current As Customer
        Set(value As Customer)
            Me.Find(value.Id)
        End Set
        Get
            If Navigator.Current IsNot Nothing Then
                Return CType(CustomerBindingSource.Current, Customer)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property Filter As String
        Set(value As String)
            Navigator.Filter = value
        End Set
        Get
            Return Navigator.Filter
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        If Navigator.MasterSource.SupportsSearching Then
            Return Navigator.MasterSource.Find("Id", id)
        Else
            Dim index = Database.Customers.Local.ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then Navigator.MasterSource.Position = index
            Return index
        End If
    End Function
    Private Sub DatagridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels, Database)
            mFrmVessels.Find(VesselBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database)
            mFrmJobs.Find(JobBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening job details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the form BindingSources to the respective context model local views.
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        StateCodeBindingSource.DataSource = Database.StateCodes.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
        ' Bind the details BindingSources to the master BindingSources on the property of the master model.
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
        BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
        ' Set the navigation bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Customers"
        Navigator.MasterSource = CustomerBindingSource
        Navigator.MasterControl = dataGridCustomers
    End Sub
End Class