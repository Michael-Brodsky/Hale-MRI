Imports LibDatabase.Contexts
Partial Public Class FrmDatabaseForm
    Public Overridable Property Database As HaleMRIContext
    Private Sub FrmDatabaseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Derived forms with a DataGridView.SelectionChanged event will fire
        ' after the FormClosing event, resulting in an error. So, we set the
        ' Database property to Nothing. Derived forms should check Database
        ' Is Nothing in the SelectionChanged event to avoid errors.
        Database = Nothing
    End Sub
End Class