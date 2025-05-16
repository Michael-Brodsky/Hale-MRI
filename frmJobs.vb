Public Class frmJobs
    Private Sub JobsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles JobsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.JobsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HaleMRIDataSet)

    End Sub

    Private Sub frmJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HaleMRIDataSet.Jobs' table. You can move, or remove it, as needed.
        Me.JobsTableAdapter.Fill(Me.HaleMRIDataSet.Jobs)

    End Sub
End Class