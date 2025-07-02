Imports LibDatabase.Models
Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore
Public Module BindingSources
    Public Function BindDataSet(Of T As {DbSet(Of T), New})(ByRef dataSet As DbSet(Of T)) As System.ComponentModel.BindingList(Of T)
        dataSet.Load()
        Return dataSet.Local.ToBindingList()
    End Function
    Public Sub BindMasterDetails(ByRef masterSource As BindingSource, ByRef detailsSource As BindingSource, masterPropertyName As String)
        detailsSource.DataSource = masterSource
        detailsSource.DataMember = masterPropertyName
    End Sub
End Module
