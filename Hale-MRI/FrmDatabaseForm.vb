Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel
Partial Public Class FrmDatabaseForm
    Private mDataBase As HaleMRIContext = Nothing
    Private mDataSource As BindingSource = Nothing
    Protected WithEvents mNavigator As RecordNavigationBar = Nothing
    Protected Overridable Property Caption As String
        Get
            Return If(mNavigator IsNot Nothing, mNavigator.Caption, String.Empty)
        End Get
        Set(value As String)
            If mNavigator IsNot Nothing Then mNavigator.Caption = value
        End Set
    End Property
    Public Overridable ReadOnly Property Current
        Get
            Return BindingSourceCurrent(DataSource)
        End Get
    End Property
    Protected Overridable Property DataSource As BindingSource
        Get
            Return mDataSource
        End Get
        Set(value As BindingSource)
            mDataSource = value
            If mNavigator IsNot Nothing Then mNavigator.DataSource = mDataSource
        End Set
    End Property
    Public Overridable Property Database As HaleMRIContext
        Get
            Return mDataBase
        End Get
        Set(value As HaleMRIContext)
            mDataBase = value
            If mNavigator IsNot Nothing Then mNavigator.Database = mDataBase
        End Set
    End Property
    Protected Overridable Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then
                mNavigator.Database = mDataBase
            End If
        End Set
    End Property
    Private Sub FrmDatabaseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Derived forms with a DataGridView.SelectionChanged event will fire
        ' after the FormClosing event, resulting in an error. So, we set the
        ' Database property to Nothing. Derived forms should check Database
        ' Is Nothing in the SelectionChanged events to avoid errors.
        Database = Nothing
    End Sub

    Public Shared Function FindEntity(Of T As Class)(entity As DbSet(Of T), id As Integer) As T
        Return entity.Find(id)
    End Function

    Protected Property EntityClass As Object
End Class