Public Class frmVessels
    Private Sub VesselsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles VesselsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.VesselsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HaleMRIDataSet)

    End Sub

    Private Sub frmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HaleMRIDataSet.Vessels' table. You can move, or remove it, as needed.
        Me.VesselsTableAdapter.Fill(Me.HaleMRIDataSet.Vessels)

    End Sub
End Class