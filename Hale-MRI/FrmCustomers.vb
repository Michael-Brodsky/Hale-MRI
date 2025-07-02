Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Public Class FrmCustomers
    Dim dB As New HaleMRIContext()
    Private mFrmVessels As FrmVessels
    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the database context and ensure all necessary data is loaded.
        ' Any data table used in the form should be loaded here.
        dB.Database.EnsureCreated()
        dB.Customers.Load()
        dB.StateCodes.Load()
        dB.CountryCodes.Load()
        dB.Vessels.Load()
        dB.Jobs.Load()
        dB.Employees.Load()
        ' Bind the data tables to the respective BindingSources.
        CustomerBindingSource.DataSource = dB.Customers.Local.ToBindingList()
        StateCodeBindingSource.DataSource = dB.StateCodes.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = dB.CountryCodes.Local.ToBindingList()
        EmployeeBindingSource.DataSource = dB.Employees.Local.ToBindingList()
        ' Bind Customers (master) to Vessels (details). This automatically updates
        ' the Vessels list when a Customer is selected. (Vessel to Jobs is handled
        ' in DatagridCustomerVessels_SelectionChanged)
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
    End Sub

    Private Sub FrmCustomers_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dB.Dispose()
        dB = Nothing
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        ' Save changes to the database context.
        Try
            dB.SaveChanges()
            dataGridCustomers.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DatagridCustomerVessels_SelectionChanged(sender As Object, e As EventArgs) Handles datagridCustomerVessels.SelectionChanged
        ' Update the Jobs list when the selected vessel changes.    
        If dB IsNot Nothing Then
            Try
                Dim selectedVessel = TryCast(datagridCustomerVessels.CurrentRow?.DataBoundItem, Vessel)
                JobBindingSource.DataSource = selectedVessel?.Jobs.ToList
            Catch ex As Exception
                MessageBox.Show("Error updating vessel jobs list: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DatagridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels)
            mFrmVessels.CurrentRecord = TryCast(datagridCustomerVessels.CurrentRow?.DataBoundItem, Vessel)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class