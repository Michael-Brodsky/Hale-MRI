Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' This form provides a user interface for editing
''' Propeller records.
''' </summary>
Public Class FrmPropellers
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(mMasterSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Property Filter As Object
        Get
            Return mFilter
        End Get
        Set(value As Object)
            mFilter = value
            If mNavigator IsNot Nothing Then mNavigator.Filter = mFilter
            FilterOn = mFilter IsNot Nothing
        End Set
    End Property

    Public Property FilterOn As Boolean
        Get
            Return mFilterOn
        End Get
        Set(value As Boolean)
            mFilterOn = value
            If mNavigator IsNot Nothing Then mNavigator.FilterOn = mFilterOn
        End Set
    End Property

    Public Function Find(item As Propeller) As Propeller
        Dim result As Propeller = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = MasterSource.Current
        End If
        Return result
    End Function
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources query the database, as they may change while
        ' the application is open.
        PropellerBindingSource.DataSource = New BindingList(Of Propeller)(Database.Propellers.OrderBy(Function(e) e.Description).ToList())
        ManufacturersBindingSource.DataSource = New BindingList(Of Manufacturer)(Database.Manufacturers.OrderBy(Function(e) e.ManufacturerName).ToList())
        ' These DataSources use LocalViews, which are loaded on application
        ' startup, and not expected to change.
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList()
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList()
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList()
        RotationsBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ' Configure the RecordNavigator.
        Navigator = RecordNavigationBar1
        MasterSource = PropellerBindingSource
    End Sub

    Private Function DeleteConfirm() As Boolean
        Return (
            MessageBox.Show(
                $"Delete {DataGridPropellers.SelectedRows.Count} row(s)?",
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedPropellers()
        For Each row As DataGridViewRow In DataGridPropellers.SelectedRows
            Dim p As Propeller = CType(row.DataBoundItem, Propeller)
            If p IsNot Nothing Then PropellerBindingSource.Remove(p)
        Next
    End Sub

    Protected Overrides Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If mNavigator IsNot Nothing Then mNavigator.MasterSource = mMasterSource
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then mNavigator.Database = Database
        End Set
    End Property
#End Region
#Region "Event Handlers"
    Private Sub FrmPropellers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator = RecordNavigationBar1
        Navigator.BoundControls = New List(Of Control) From {
           DataGridPropellers
        }
        MasterSource = PropellerBindingSource
        DataGridPropellers.ClearSelection()
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Select Case e.EventName
            Case "Delete"
                If DeleteConfirm() Then DeleteSelectedPropellers()
            Case "FilterOff"
            Case "FilterOn"
            Case "GotoFirst"
            Case "GotoLast"
            Case "GotoNext"
            Case "GotoPrev"
            Case "Save"
            Case "Undo"
            Case Else
        End Select
    End Sub

    Private Sub PropellerBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles PropellerBindingSource.AddingNew
        Dim newPropeller As New Propeller()
        e.NewObject = newPropeller
        Database.Propellers.Add(newPropeller)
    End Sub
#End Region
End Class