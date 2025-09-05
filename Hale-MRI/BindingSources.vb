Imports LibDatabase.Contexts
Imports System.Runtime.CompilerServices
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.ComponentModel
Imports LibDatabase.StoredProcedures
Public Module BindingSources
    Public Function BindingSourceCurrent(bs As BindingSource) As Object
        ' Returns the current object in the BindingSource, or Nothing if there is no current object.
        Return If(bs IsNot Nothing AndAlso bs.Position <> kNoCurrentRecord, bs.Current, Nothing)
    End Function
    Public Function BindingSourceFind(ByVal id As Integer, bs As BindingSource) As Integer
        ' Returns the position of a record in a BindingSource whose Id field matches the given id.
        Dim result As Integer = kNoCurrentRecord
        Dim list As IList = bs.List
        For Each item In list
            Dim t As Type = item.GetType()
            Dim pi As PropertyInfo = t.GetProperty("Id")
            Dim itemId As Integer = CInt(pi.GetValue(item, Nothing))
            If itemId = id Then
                result = list.IndexOf(item)
                Exit For
            End If
        Next
        Return result
    End Function
    Public Sub BindingSourceSave(db As HaleMRIContext, ByRef bs As BindingSource)
        ' Saves the current record in the BindingSource to the database.
        bs.EndEdit()
        db.SaveChanges()
    End Sub
    Public Sub BindingSourceUndo(db As HaleMRIContext, ByRef bs As BindingSource)
        ' Undoes changes made to the current record in the BindingSource.
        bs.CancelEdit()
        Rollback(db, bs.DataSource)
        bs.ResetCurrentItem()
    End Sub
    Public Sub BindMasterDetails(ByRef masterSource As BindingSource, ByRef detailsSource As BindingSource, masterPropertyName As String)
        ' Binds a master BindingSource to a details BindingSource using the specified property name.
        ' Call this once after instantiating the master and details BindingSources.
        detailsSource.DataSource = masterSource
        detailsSource.DataMember = masterPropertyName
    End Sub
    Public Sub GetRelatedEntities(Of T As Class)(db As HaleMRIContext, ByRef relatedSource As BindingList(Of T), propertyName As String, key As Object)
        ' Returns a list of entities of type T that match the specified property name and key.
        ' This function is used to "bind" a master control with a details control when their
        ' binding sources are based on types not compatible with BindMasterDetails(), e.g.
        ' (DataTable, DataView, other searchable/filterable types.) This function must be
        ' called each time the current record changes in the master control.
        Dim result As New List(Of T)
        If key IsNot Nothing AndAlso relatedSource IsNot Nothing AndAlso Not IsDBNull(key) Then
            ' It uses LINQ to query a DbSet of type T.
            Dim qry = db.Set(Of T)().AsQueryable()
            ' Create a parameter expression for the entity type T (Function(x) x.propertyName = key)
            Dim param = Expression.Parameter(GetType(T), "x")
            Dim propExp As MemberExpression = Expression.Property(param, propertyName)
            Dim propExpression As Expression
            If propExp.Type.IsGenericType AndAlso propExp.Type.GetGenericTypeDefinition() Is GetType(Nullable(Of)) Then
                ' Handle nullable entity member types
                Dim filter = Expression.Constant(Convert.ChangeType(key, propExp.Type.GetGenericArguments()(0)))
                Dim typeFilter As Expression = Expression.Convert(filter, propExp.Type)
                propExpression = Expression.Equal(propExp, typeFilter)
            Else
                ' Handle non-nullable entity member types
                propExpression = Expression.Equal(propExp, Expression.Constant(key))
            End If
            ' Create the lambda expression for the query.
            Dim exp = Expression.Lambda(Of Func(Of T, Boolean))(propExpression, param)
            result = qry.Where(exp).ToList() ' Evaluate DbSet(of T).Where(Function(x) x.propertyName = key) and return a list of matching entities.
        End If
        relatedSource = New BindingList(Of T)(result)  ' Convert the result to a BindingList(Of T) for data binding.
    End Sub
    <Extension()>
    Public Function GetUnderlyingEntityType(bs As BindingSource) As Type
        Dim fi = GetType(BindingSource).GetField("_itemType", BindingFlags.NonPublic Or BindingFlags.Instance)
        Return TryCast(fi?.GetValue(bs), Type)
    End Function
End Module
