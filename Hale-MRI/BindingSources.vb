Imports LibDatabase.Contexts
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore
Imports System.Runtime.CompilerServices
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.ComponentModel

''' <summary>
''' Defines methods that operate on form BindingSources.
''' </summary>
''' 
Public Module BindingSources
    Public Function BindingSourceCurrent(bs As BindingSource) As Object
        ' Returns the current record in the BindingSource, or Nothing if there is no current record.
        Return If(bs IsNot Nothing AndAlso bs.Position <> kNoCurrentRecord, bs.Current, Nothing)
    End Function

    Public Function BindingSourceFind(bs As BindingSource, key As Object) As Integer
        ' Returns the BindingSource index of the record matching the given key.
        Return bs.IndexOf(key)
    End Function

    Public Sub BindingSourceRemove(ByRef bs As BindingSource)
        ' Removes the current record from the BindingSource.
        bs.RemoveCurrent()
        bs.EndEdit()
    End Sub

    Public Sub BindingSourceRemove(Of T As Class)(db As HaleMRIContext, ByRef bs As BindingSource, ByRef entity As DbSet(Of T))
        ' Removes the current record from the BindingSource and Database.
        entity.Remove(BindingSourceCurrent(bs))
        BindingSourceRemove(bs)
        db.SaveChanges()
        bs.ResetCurrentItem()
    End Sub

    Public Sub BindingSourceSave(db As HaleMRIContext, ByRef bs As BindingSource)
        ' Saves the current BindingSource record to the Database.
        bs.EndEdit()
        db.SaveChanges()
    End Sub

    Public Sub BindingSourceUndo(db As HaleMRIContext, ByRef bs As BindingSource)
        ' Undoes changes made to the current BindingSource record and
        ' rollsback any associated pending Database changes.
        bs.CancelEdit()
        Rollback(db, bs.DataSource)
        bs.ResetCurrentItem()
    End Sub

    Public Sub BindMasterDetails(ByRef masterSource As BindingSource, ByRef detailsSource As BindingSource, masterPropertyName As String)
        ' Binds a master BindingSource to a details BindingSource using the specified property name.
        detailsSource.DataSource = masterSource
        detailsSource.DataMember = masterPropertyName
    End Sub

    Public Sub BindingListFilter(Of T As Class)(db As HaleMRIContext, ByRef sourceList As BindingList(Of T), propertyName As String, key As Object)
        ' Filters a BindingList(Of T) to records matching the specified property name and key.
        Dim result As New List(Of T)
        If key IsNot Nothing AndAlso sourceList IsNot Nothing AndAlso Not IsDBNull(key) Then
            ' It uses LINQ to query a DbSet of type T.
            Dim qry As IQueryable(Of T) = db.Set(Of T)().AsQueryable()
            ' Create a parameter expression for the entity type T (Function(x) x.propertyName = key)
            Dim param As ParameterExpression = Expression.Parameter(GetType(T), "x")
            Dim propExp As MemberExpression = Expression.Property(param, propertyName)
            Dim propExpression As Expression
            If propExp.Type.IsGenericType AndAlso propExp.Type.GetGenericTypeDefinition() Is GetType(Nullable(Of)) Then
                ' Handle nullable entity member types
                Dim filter As ConstantExpression = Expression.Constant(Convert.ChangeType(key, propExp.Type.GetGenericArguments()(0)))
                Dim typeFilter As Expression = Expression.Convert(filter, propExp.Type)
                propExpression = Expression.Equal(propExp, typeFilter)
            Else
                ' Handle non-nullable entity member types
                propExpression = Expression.Equal(propExp, Expression.Constant(key))
            End If
            ' Create the lambda expression for the query.
            Dim exp As Expression(Of Func(Of T, Boolean)) = Expression.Lambda(Of Func(Of T, Boolean))(propExpression, param)
            result = qry.Where(exp).ToList() ' Evaluate DbSet(of T).Where(Function(x) x.propertyName = key) and return a list of matching entities.
        End If
        sourceList = New BindingList(Of T)(result)  ' Convert the result to a BindingList(Of T) for data binding.
    End Sub

    <Extension()>
    Public Function EntityType(bs As BindingSource) As Type
        ' Returns a BindingSource's underlying entity type.
        Dim fi = GetType(BindingSource).GetField("_itemType", BindingFlags.NonPublic Or BindingFlags.Instance)
        Return TryCast(fi?.GetValue(bs), Type)
    End Function
End Module