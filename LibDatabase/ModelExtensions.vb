Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.CompilerServices
Imports LibDatabase.Contexts

Public Module ModelExtensions
    <Extension()>
    Public Function ChangesPending(ByVal dB As HaleMRIContext) As Boolean
        ' Returns a Boolean indicating whether there are pending changes in the DbContext.
        Return dB.ChangeTracker.HasChanges()
    End Function

    <Extension()>
    Public Function Filter(Of T)(ByVal list As IEnumerable(Of T), ByVal filterParam As Func(Of T, Boolean)) As IEnumerable(Of T)
        ' Returns an enumerable collection, IEnumerable(Of DbSet(Of T)), 
        ' filtered according the filterParam expression.
        Return list.Where(filterParam).ToList()
    End Function
    <Extension()>
    Public Function ToDataTable(Of T)(ByVal data As IList(Of T)) As DataTable
        ' Returns a BindingSource, List(Of DbSet(Of T)), converted to a searchable DataTable.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table As New DataTable()

        For Each prop As PropertyDescriptor In properties
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next
        For Each item As T In data
            Dim row As DataRow = table.NewRow()

            For Each prop As PropertyDescriptor In properties
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next
            table.Rows.Add(row)
        Next

        Return table
    End Function
End Module
