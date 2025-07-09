Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports LibDatabase.StoredProcedures
Imports LibDatabase.ModelExtensions
Imports System.ComponentModel
Imports Equin.ApplicationFramework
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data.Common


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
            If RecordNavigationBar1.Current IsNot Nothing Then
                Return CType(CustomerBindingSource.Current, Customer)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Public Function Find(id As Integer) As Integer
        If RecordNavigationBar1.RecordSource.SupportsSearching Then
            Return RecordNavigationBar1.RecordSource.Find("Id", id)
        Else
            Dim index = Database.Customers.Local.ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then RecordNavigationBar1.RecordSource.Position = index
            Return index
        End If
    End Function
    Private Sub BindDataSources()
        ' Bind the data tables to the respective BindingSources.
        'CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList() '.ToDataTable()

        'CustomerBindingSource.DataSource = New BindingList(Of Customer)(Database.Customers.Local.ToList)
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        StateCodeBindingSource.DataSource = Database.StateCodes.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        ' Bind Customers (master) to Vessels (details). This automatically updates
        ' the Vessels list when a Customer is selected. (Vessel to Jobs is handled
        ' in DatagridCustomerVessels_SelectionChanged)
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
        RecordNavigationBar1.Database = MyBase.Database
        RecordNavigationBar1.RecordSource = CustomerBindingSource
        ' RecordNavigationBar1.SearchSource = New BindingSource With {.DataSource = Database.Customers.Local.ToBindingList().ToDataTable()}
    End Sub

    Private Sub DatagridCustomerVessels_SelectionChanged(sender As Object, e As EventArgs) Handles datagridCustomerVessels.SelectionChanged
        ' Update the Jobs list when the selected vessel changes.    
        If Database IsNot Nothing Then
            Try
                JobBindingSource.DataSource = TryCast(datagridCustomerVessels.CurrentRow?.DataBoundItem, Vessel)?.Jobs.ToList
            Catch ex As Exception
                MessageBox.Show("Error updating vessel jobs list: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub DatagridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels, Database)
            mFrmVessels.Find(VesselBindingSource.Current.Id)
            mFrmVessels.Filter = "Id = " & VesselBindingSource.Current.Id.ToString
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database)
            mFrmJobs.CurrentId = JobBindingSource.Current.Id
        Catch ex As Exception
            MessageBox.Show("Error opening job details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the nav bar properties.
        RecordNavigationBar1.Caption = "Customers"                  ' Caption
        RecordNavigationBar1.BoundControl = dataGridCustomers       ' Bound control
        'RecordNavigationBar1.Database = MyBase.Database             ' HaleMRIContext
        'RecordNavigationBar1.RecordSource = CustomerBindingSource   ' BindingSource
    End Sub

    Private Sub dataGridCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dataGridCustomers.SelectionChanged

    End Sub

    Private Sub dataGridCustomers_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridCustomers.CellValueChanged

    End Sub

    Private Sub dataGridCustomers_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridCustomers.CurrentCellChanged

    End Sub
End Class