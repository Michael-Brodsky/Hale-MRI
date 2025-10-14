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
    Private mMasterSource As BindingSource = Nothing    ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' The form's RecordNavigationBar.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmJobs As FrmJobs
    Private mFrmCustomers As FrmCustomers
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current As Vessel
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

    Public Function Find(item As Vessel) As Vessel
        Dim result As Vessel = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        FormSort(MasterSource?.DataSource)
    End Sub
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources are used by ComboBox lists in the grids and need to be loaded first.
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        CustomerBindingSource.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        ' Retrieve Vessels sorted by VesselName, including their Jobs.
        Dim vessels = New BindingList(Of Vessel)(Database.Vessels _
            .OrderBy(Function(v) v.VesselName) _
            .Include(Function(v) v.Jobs).ToList()
        )
        FormSort(vessels)
        VesselBindingSource.DataSource = vessels
        ' Bind the master BindingSource (Vessels) to the details BindingSource (Jobs).
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
    End Sub

    Private Function DeleteConfirm() As Boolean
        Dim prompt As String = If(DataGridVessels.SelectedRows.Count = 1,
            $"Delete vessel '{Current.VesselName}'?",
            $"Delete the {DataGridVessels.SelectedRows.Count} selected vessels?")
        Return (
            MessageBox.Show(
                prompt,
                STR_TITLE_DEFAULT,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) = DialogResult.OK
            )
    End Function

    Private Sub DeleteSelectedVessels()
        For Each row As DataGridViewRow In DataGridVessels.SelectedRows
            Dim v As Vessel = CType(row.DataBoundItem, Vessel)
            If v IsNot Nothing Then
                Database.Remove(v)
                DataGridVessels.Rows.Remove(row)
            End If
        Next
        Database.SaveChanges()
    End Sub

    Private Sub FormSort(ByRef vessels As BindingList(Of Vessel))
        For Each v In vessels
            If v?.Jobs IsNot Nothing AndAlso v.Jobs.Count > 1 Then
                v.Jobs = v.Jobs.OrderBy(Function(j) j.JobNumber).ToList()
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
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected Job as the current record.
        Try
            ShowForm(mFrmJobs, Database, User)
            mFrmJobs.Find(BindingSourceCurrent(JobsBindingSource))
        Catch ex As Exception
            MessageBox.Show("Error opening vessel job: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Try
            Select Case e.EventName
                Case "Delete"
                    If DeleteConfirm() Then
                        DeleteSelectedVessels()
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

    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridVessels}
            MasterSource = VesselBindingSource
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "vessels", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridVessels_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs)
        Try
            e.Row.Cells("CustomerId").Value = VesselBindingSource.Current.Customer?.Id
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_NO_DEFAULT_VALUE, ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVessels.CellMouseDoubleClick
        ' Open the Customers form with the selected Customer as the current record.
        Try
            ShowForm(mFrmCustomers, Database, User)
            mFrmCustomers.Find(Current?.Customer)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FORM_OPEN, "jobs", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VesselBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles VesselBindingSource.AddingNew
        Try
            Dim newVessel As New Vessel()
            e.NewObject = newVessel
            Database.Vessels.Add(newVessel)
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_ADDNEW, "vessel", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class