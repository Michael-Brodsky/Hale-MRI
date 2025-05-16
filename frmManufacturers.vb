Public Class frmManufacturers
    Private Sub ManufacturersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ManufacturersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ManufacturersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HaleMRIDataSet)

    End Sub

    Private Sub frmManufacturers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HaleMRIDataSet.Manufacturers' table. You can move, or remove it, as needed.
        Me.ManufacturersTableAdapter.Fill(Me.HaleMRIDataSet.Manufacturers)

    End Sub
End Class