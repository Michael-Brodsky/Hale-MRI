Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Public Class FrmCustomers
    Dim dB As New HaleMRIContext()
    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dB.Database.EnsureCreated()
        dB.Customers.Load()
        dB.StateCodes.Load()
        dB.CountryCodes.Load()
        dB.Vessels.Load()
        dB.Jobs.Load()
        dB.Employees.Load()
        CustomerBindingSource.DataSource = dB.Customers.Local.ToBindingList()
        StateCodeBindingSource.DataSource = dB.StateCodes.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = dB.CountryCodes.Local.ToBindingList()
        EmployeeBindingSource.DataSource = dB.Employees.Local.ToBindingList()
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
    End Sub

    Private Sub FrmCustomers_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dB.Dispose()
        dB = Nothing
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        dB.SaveChanges()
        dataGridCustomers.Refresh()
    End Sub

    Private Sub DatagridCustomerVessels_SelectionChanged(sender As Object, e As EventArgs) Handles datagridCustomerVessels.SelectionChanged
        If dB IsNot Nothing Then
            Dim selectedVessel = TryCast(datagridCustomerVessels.CurrentRow?.DataBoundItem, Vessel)
            JobBindingSource.DataSource = selectedVessel?.Jobs.ToList
        End If
    End Sub

    Private Sub DatagridCustomerVessels_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridCustomerVessels.CellContentDoubleClick

    End Sub
End Class