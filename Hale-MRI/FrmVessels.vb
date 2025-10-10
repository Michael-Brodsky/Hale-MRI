Imports LibDatabase.Contexts
Imports System.ComponentModel
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Hale_MRI.RecordNavigationBar
Public Class FrmVessels
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
    ' Define all forms this form can work with.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmJobs As FrmJobs
    Private mFrmCustomers As FrmCustomers
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(MasterSource)
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

    Public Function Find(item As Vessel) As Vessel
        Dim result As Vessel = Nothing
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
        ' These DataSources use LocalViews, which are loaded on application
        ' startup, and not expected to change.
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        ' These DataSources query the database, as they may change while
        ' the application is open.
        CustomerBindingSource.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        ManufacturerBindingSource.DataSource = New BindingList(Of Manufacturer)(Database.Manufacturers.OrderBy(Function(e) e.ManufacturerName).ToList())
        ' Order the Customer Vessels list by VesselName ...
        Dim vessels = Database.Vessels.Include(Function(v) v.Jobs).OrderBy(Function(v) v.VesselName).ToList()
        ' ... and each Vessel's Jobs list by JobNumber.
        For Each v In vessels
            v.Jobs = v.Jobs.OrderBy(Function(j) j.JobNumber).ToList()
        Next
        ' Bind the master BindingSource (Vessels) to the details BindingSource (Jobs).
        VesselBindingSource.DataSource = New BindingList(Of Vessel)(vessels)
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
    End Sub

    Private Function DeleteConfirm() As Boolean
        Return (
            MessageBox.Show(
                $"Delete {DataGridVessels.SelectedRows.Count} row(s)?",
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedVessels()
        For Each row As DataGridViewRow In DataGridVessels.SelectedRows
            Dim v As Vessel = CType(row.DataBoundItem, Vessel)
            If v IsNot Nothing Then Database.Remove(v)
            DataGridVessels.Rows.Remove(row)
        Next
        Database.SaveChanges()
        RefreshForm(mFrmCustomers, Database)
    End Sub

    Private Property MasterSource As BindingSource
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
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database, User)
            mFrmJobs.Find(BindingSourceCurrent(JobsBindingSource))
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Select Case e.EventName
            Case "Delete"
                If DeleteConfirm() Then DeleteSelectedVessels()
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

    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator = RecordNavigationBar1
        Navigator.BoundControls = New List(Of Control) From {
           DataGridVessels
        }
        MasterSource = VesselBindingSource
        AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        DataGridVessels.ClearSelection()
    End Sub

    Private Sub VesselBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles VesselBindingSource.AddingNew
        Dim newVessel As New Vessel()
        e.NewObject = newVessel
        Database.Vessels.Add(newVessel)
    End Sub

    Private Sub DataGridVessels_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs)
        e.Row.Cells("CustomerId").Value = VesselBindingSource.Current?.Customer.Id
    End Sub
#End Region
End Class