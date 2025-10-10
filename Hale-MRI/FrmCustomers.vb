Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking.Internal

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
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmVessels As FrmVessels
    Private mFrmJobs As FrmJobs
#End Region
#Region "Public Interface"
    Public Function AddNew(ByVal c As Customer) As Customer
        Dim newCustomer As Customer = BindingSourceAddNew(MasterSource, c)
        Navigator.CmdSave.Enabled = True
        Return newCustomer
    End Function

    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(mMasterSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Function Find(item As Customer) As Customer
        Dim result As Customer = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = MasterSource.Current
        End If
        Return result
    End Function

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        VesselBindingSource.ResetBindings(False)
        BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
        DataGridVesselJobs.Refresh()
    End Sub
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' Master list is Customers sorted by CustomerName.
        Dim customers = Database.Customers.Include(Function(c) c.Vessels).OrderBy(Function(c) c.CustomerName).ToList()
        ' Each customer's Vessels list is sorted by VesselName.
        For Each c In customers
            c.Vessels = c.Vessels.OrderBy(Function(v) v.VesselName).ToList()
            ' Each vessel's Jobs list is sorted by StartDate.
            For Each v In c.Vessels
                v.Jobs = v.Jobs.OrderBy(Function(j) j.JobNumber).ToList()
            Next
        Next
        CustomerBindingSource.DataSource = New BindingList(Of Customer)(customers)
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        StateCodeBindingSource.DataSource = Database.StateCodes.Local.ToBindingList()
        ' Bind: Customers (master) -> Vessels (details), Vessels (master) -> Jobs (details)).
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
        BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
        'If VesselBindingSource.Count > 0 Then BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
    End Sub

    Private Function DeleteConfirm() As Boolean
        Return (
            MessageBox.Show(
                $"Delete {DataGridCustomers.SelectedRows.Count} row(s)?",
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedCustomers()
        For Each row As DataGridViewRow In DataGridCustomers.SelectedRows
            Dim c As Customer = CType(row.DataBoundItem, Customer)
            If c IsNot Nothing Then CustomerBindingSource.Remove(c)
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
    Private Sub DataGridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DatagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels, Database, User)
            mFrmVessels.Find(BindingSourceCurrent(VesselBindingSource))
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database, User)
            'mFrmJobs.Filter = Nothing
            mFrmJobs.Find(JobBindingSource.Current)
        Catch ex As Exception
            MessageBox.Show("Error opening job details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator = RecordNavigationBar1
        Navigator.BoundControls = New List(Of Control) From {
           DataGridCustomers
        }
        MasterSource = CustomerBindingSource
        AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        DataGridCustomers.ClearSelection()
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Select Case e.EventName
            Case "Delete"
                If DeleteConfirm() Then DeleteSelectedCustomers()
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

    Private Sub CustomerBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles CustomerBindingSource.AddingNew
        Dim newCustomer As New Customer()
        e.NewObject = newCustomer
        Database.Customers.Add(newCustomer)
    End Sub

    Private Sub DatagridCustomerVessels_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DatagridCustomerVessels.MouseDoubleClick

    End Sub
#End Region
End Class