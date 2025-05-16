Public Class frmJobDetails
    Private Sub Job_DetailsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Job_DetailsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Job_DetailsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HaleMRIDataSet)

    End Sub

    Private Sub frmJobDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HaleMRIDataSet.Job_Details' table. You can move, or remove it, as needed.
        Me.Job_DetailsTableAdapter.Fill(Me.HaleMRIDataSet.Job_Details)

    End Sub
End Class