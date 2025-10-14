Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking.Internal
Imports Microsoft.EntityFrameworkCore.Migrations.Operations

''' <summary>
''' This form provides a user interface for editing 
''' Customer records and accessing related Vessel and
''' Job records.
''' </summary>

Partial Public Class FrmCustomers
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' The form's RecordNavigationBar.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmVessels As FrmVessels
    Private mFrmJobs As FrmJobs
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected Customer,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As Customer
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
    ''' Finds the given Customer and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The Customer to find.</param>
    ''' <returns>The found Customer, or Nothing if not found.</returns>
    Public Function Find(item As Customer) As Customer
        Dim result As Customer = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function

    ''' <summary>
    ''' Refreshes all form data bindings, including sorting the
    ''' Customers' Vessels and Jobs.
    ''' </summary>
    Public Overrides Sub Refresh()
        MyBase.Refresh()
        FormSort(MasterSource?.DataSource)
    End Sub
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources are used by ComboBox lists in the grids and need to be loaded first.
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        EmployeeBindingSource.DataSource = Database.Employees.Local.ToBindingList()
        StateCodeBindingSource.DataSource = Database.StateCodes.Local.ToBindingList()
        ' Retrieve Customers sorted by CustomerName, including their Vessels and Jobs.
        Dim customers = New BindingList(Of Customer)(Database.Customers _
            .OrderBy(Function(c) c.CustomerName) _
            .Include(Function(c) c.Vessels) _
            .ThenInclude(Function(v) v.Jobs).ToList()
        )
        ' Sort the Customers' Vessels and Jobs.
        FormSort(customers)
        CustomerBindingSource.DataSource = customers 'New BindingList(Of Customer)(customers)
        ' Bind: Customers (master) -> Vessels (details), Vessels (master) -> Jobs (details).
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
        BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
    End Sub

    Private Function DeleteConfirm() As Boolean
        Dim prompt As String = If(DataGridCustomers.SelectedRows.Count = 1,
            $"Delete customer '{Current.CustomerName}'?",
            $"Delete the {DataGridCustomers.SelectedRows.Count} selected customers?")
        Return (
            MessageBox.Show(
                prompt,
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedCustomers()
        ' Delete the Customer from the database and the row from the DataGrid.
        For Each row As DataGridViewRow In DataGridCustomers.SelectedRows
            Dim c As Customer = CType(row.DataBoundItem, Customer)
            If c IsNot Nothing Then
                ' We need to explicitly remove related Vessels before calling Database.SaveChanges(),
                ' otherwise we get a foreign key constraint error (probably due to multilevel
                ' Master/Details binding).
                For Each v As Vessel In c.Vessels
                    Database.Remove(v)
                Next
                Database.Remove(c)
            End If
            DataGridCustomers.Rows.Remove(row)
        Next
        Database.SaveChanges()
    End Sub

    Private Sub FormSort(ByRef customers As BindingList(Of Customer))
        For Each c As Customer In customers
            If c?.Vessels IsNot Nothing Then
                If c.Vessels.Count > 1 Then
                    c.Vessels = c.Vessels.OrderBy(Function(cc) cc.VesselName).ToList()
                End If
                For Each v As Vessel In c.Vessels
                    If v?.Jobs IsNot Nothing Then
                        If v.Jobs.Count > 1 Then
                            v.Jobs = v.Jobs.OrderBy(Function(vv) vv.JobNumber).ToList()
                        End If
                    End If
                Next
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
    Private Sub DataGridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DatagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels, Database, User)
            mFrmVessels.Find(BindingSourceCurrent(VesselBindingSource))
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "vessels", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected Job as the current record.
        Try
            ShowForm(mFrmJobs, Database, User)
            mFrmJobs.Find(JobBindingSource.Current)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "jobs", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DataGridCustomers.AutoGenerateColumns = False
            DatagridCustomerVessels.AutoGenerateColumns = False
            DataGridVesselJobs.AutoGenerateColumns = False
            DataGridCustomers.DataSource = CustomerBindingSource
            DatagridCustomerVessels.DataSource = VesselBindingSource
            DataGridVesselJobs.DataSource = JobBindingSource
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridCustomers}
            MasterSource = CustomerBindingSource
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "customers", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Try
            Select Case e.EventName
                Case "Delete"
                    If DeleteConfirm() Then
                        DeleteSelectedCustomers()
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

    Private Sub CustomerBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles CustomerBindingSource.AddingNew
        Try
            Dim newCustomer As New Customer()
            e.NewObject = newCustomer
            Database.Customers.Add(newCustomer)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_ADDNEW, "customer", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class