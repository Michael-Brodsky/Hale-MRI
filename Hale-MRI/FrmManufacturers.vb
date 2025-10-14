Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore

''' <summary>
''' This form provides a user interface for editing 
''' Manufacturer records and accessing related 
''' Propeller records.
''' </summary>
Public Class FrmManufacturers
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmPropellers As FrmPropellers
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected Manufacturer,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As Manufacturer
        Get
            Return BindingSourceCurrent(MasterSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Gets or sets the current filter object.
    ''' </summary>
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

    ''' <summary>
    ''' Gets or sets a flag indicating whether the current filter is active.
    ''' </summary>
    Public Property FilterOn As Boolean
        Get
            Return mFilterOn
        End Get
        Set(value As Boolean)
            mFilterOn = value
            If Navigator IsNot Nothing Then Navigator.FilterOn = mFilterOn
        End Set
    End Property

    ''' <summary>
    ''' Finds the given Manufacturer in the MasterSource and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The Manufacturer to find.</param>
    ''' <returns>The found Manufacturer, or Nothing if not found.</returns>
    Public Function Find(item As Manufacturer) As Manufacturer
        Dim result As Manufacturer = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function

    ''' <summary>
    ''' Refreshes the form data and sorts the Propellers of each Manufacturer by PartNumber.
    ''' </summary>
    Public Overrides Sub Refresh()
        MyBase.Refresh()
        FormSort(MasterSource?.DataSource)
    End Sub
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources are used by ComboBox lists in the grids and need to be loaded first.
        StatesBindingSource.DataSource = Database.StateCodes.Local.ToBindingList
        CountryCodesBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList
        ' Retrieve Manufacturers sorted by ManufacturerName, including their Propellers.
        Dim manufacturers = New BindingList(Of Manufacturer)(Database.Manufacturers _
            .OrderBy(Function(m) m.ManufacturerName) _
            .Include(Function(m) m.Propellers).ToList()
        )
        FormSort(manufacturers)
        ManufacturersBindingSource.DataSource = New BindingList(Of Manufacturer)(manufacturers)
        ' Bind the master BindingSource (Manufacturers) to the details BindingSource (Propellers).
        BindMasterDetails(ManufacturersBindingSource, PropellersBindingSource, "Propellers")
    End Sub

    Private Function DeleteConfirm() As Boolean
        Dim prompt As String = If(DataGridManufacturers.SelectedRows.Count = 1,
            $"Delete manufacturer '{Current.ManufacturerName}'?",
            $"Delete the {DataGridManufacturers.SelectedRows.Count} selected manufacturers?")
        Return (
            MessageBox.Show(
                $"Delete {DataGridManufacturers.SelectedRows.Count} row(s)?",
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedManufacturers()
        For Each row As DataGridViewRow In DataGridManufacturers.SelectedRows
            Dim m As Manufacturer = CType(row.DataBoundItem, Manufacturer)
            If m IsNot Nothing Then
                Database.Remove(m)
                DataGridManufacturers.Rows.Remove(row)
            End If
        Next
        Database.SaveChanges()
    End Sub

    Private Sub FormSort(ByRef manufacturers As BindingList(Of Manufacturer))
        For Each m In manufacturers
            If m?.Propellers IsNot Nothing AndAlso m.Propellers.Count > 1 Then
                m.Propellers = m.Propellers.OrderBy(Function(p) p.PartNumber).ToList()
            End If
        Next
    End Sub
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
    Private Sub DataGridPropeller_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridPropellers.CellMouseDoubleClick
        Try
            ShowForm(mFrmPropellers, Database, User)
            mFrmPropellers.Find(PropellersBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "propellers", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmManufacturers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridManufacturers}
            MasterSource = ManufacturersBindingSource
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "manufacturers", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ManufacturersBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles ManufacturersBindingSource.AddingNew
        Try
            Dim newManufacturer As New Manufacturer()
            e.NewObject = newManufacturer
            Database.Manufacturers.Add(newManufacturer)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_ADDNEW, "manufacturer", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Try
            Select Case e.EventName
                Case "Delete"
                    If DeleteConfirm() Then
                        DeleteSelectedManufacturers()
                        RefreshAll()
                    End If
                Case "FilterOff"
                Case "FilterOn"
                Case "GotoFirst"
                Case "GotoLast"
                Case "GotoNext"
                Case "GotoPrev"
                Case "Refresh"
                Case "Save"
                    RefreshAll()
                Case "Undo"
                Case Else
            End Select
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_NAVIGATION, ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class