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
    Private mNewPropeller As Propeller = Nothing              ' The new Vessel being added, if any.
#End Region
#Region "Public Interface"
    Public Sub AddNew(ByVal manufacturer As Manufacturer)
        mNewPropeller = New Propeller With {.Manufacturer = manufacturer}
        PropellerBindingSource.AddNew()
    End Sub
    ''' <summary>
    ''' Returns the currently selected Propeller,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As Propeller
        Get
            Return BindingSourceCurrent(MasterSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    Public Property Filter As Object
        Get
            Return mFilter
        End Get
        Set(value As Object)
            mFilter = value
            If Navigator IsNot Nothing Then Navigator.Filter = mFilter
            FilterOn = mFilter IsNot Nothing
        End Set
    End Property

    Public Property FilterOn As Boolean
        Get
            Return mFilterOn
        End Get
        Set(value As Boolean)
            mFilterOn = value
            If Navigator IsNot Nothing Then Navigator.FilterOn = mFilterOn
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

    ''' <summary>
    ''' Refreshes all form data bindings, including sorting the
    ''' Customers' Vessels and Jobs.
    ''' </summary>
    Public Overrides Sub Refresh()
        MyBase.Refresh()
        MasterSource.DataSource = FormSort(MasterSource?.DataSource)
    End Sub
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources are used by ComboBox lists in the grids and need to be loaded first.
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList()
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList()
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList()
        RotationsBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ManufacturersBindingSource.DataSource = New BindingList(Of Manufacturer)(Database.Manufacturers.Local.OrderBy(Function(p) p.ManufacturerName).ToList())
        ' These DataSources query the database, as they may change while the application is open.
        Dim propellers = Database.Propellers.Local.ToBindingList()
        PropellerBindingSource.DataSource = FormSort(propellers)
    End Sub

    Private Function DeleteConfirm() As Boolean
        Dim prompt As String = If(DataGridPropellers.SelectedRows.Count = 1,
            $"Delete propeller '{Current?.PartNumber}'?",
            $"Delete the {DataGridPropellers.SelectedRows.Count} selected propellers?")
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
            If p IsNot Nothing Then
                Database.Remove(p)
                DataGridPropellers.Rows.Remove(row)
            End If
        Next
        Database.SaveChanges()
    End Sub

    Private Function FormSort(ByVal propellers As BindingList(Of Propeller)) As BindingList(Of Propeller)
        Return New BindingList(Of Propeller)(propellers _
            .OrderBy(Function(p) p.Manufacturer?.ManufacturerName) _
            .ThenBy(Function(p) p.PartNumber).ToList())
    End Function
    Protected Overrides Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If Navigator IsNot Nothing Then Navigator.MasterSource = mMasterSource
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
        Try
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridPropellers}
            MasterSource = PropellerBindingSource
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "propellers", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Try
            Select Case e.EventName
                Case "Delete"
                    If DeleteConfirm() Then
                        DeleteSelectedPropellers()
                        RefreshAll()
                    End If
                Case "FilterOff"
                Case "FilterOn"
                Case "Find"
                    Find(Database.Propellers.Local.OrderBy(Function(p) p.PartNumber).Where(Function(p) p.PartNumber.StartsWith(e.Key)).FirstOrDefault())
                Case "GotoFirst"
                Case "GotoLast"
                Case "GotoNext"
                Case "GotoPrev"
                Case "Refresh"
                    Me.Refresh()
                Case "Save"
                    RefreshAll()
                Case "Undo"
                Case Else
            End Select
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_NAVIGATION, ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PropellerBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles PropellerBindingSource.AddingNew
        Try
            Dim newPropeller = If(mNewPropeller, New Propeller())
            e.NewObject = newPropeller
            Database.Propellers.Add(newPropeller)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_ADDNEW, "propeller", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridPropellers_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridPropellers.DefaultValuesNeeded
        Try
            e.Row.Cells("Manufacturer").Value = "" ' Default to "Unknown" manufacturer.
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_NO_DEFAULT_VALUE, ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class