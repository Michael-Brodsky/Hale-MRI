Imports LibDatabase.Contexts
Imports System.ComponentModel
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports LibDatabase
Public Class FrmVessels
    Inherits FrmDatabaseForm
#Region "Private Members"
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mJobsForm As FrmJobs
#End Region
#Region "Public Interface"
    Public Property Current As Vessel
        Set(value As Vessel)
            Me.Find(value.Id)
        End Set
        Get
            If Navigator.Current IsNot Nothing Then
                Return CType(VesselBindingSource.Current, Vessel)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Public Property Filter As String
        Set(value As String)
            Navigator.Filter = value
        End Set
        Get
            Return Navigator.Filter
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        If VesselBindingSource.SupportsSearching Then
            Return VesselBindingSource.Find("Id", id)
        Else
            Dim index = Database.Vessels.Local.OrderBy(Function(v) v.VesselName).ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then VesselBindingSource.Position = index
            Return index
        End If
    End Function
#End Region
#Region "Private Interface"
    Private Sub BindDataSources()
        ' Order the Vessels list by VesselName ...
        Dim vessels = Database.Vessels.Include(Function(v) v.Jobs).OrderBy(Function(v) v.VesselName).ToList()
        ' ... and each Vessel's Jobs list by JobNumber.
        For Each v In vessels
            v.Jobs = v.Jobs.OrderBy(Function(j) j.JobNumber).ToList()
        Next
        ' Bind the master BindingSource (Vessels) to the details BindingSource (Jobs).
        VesselBindingSource.DataSource = New BindingList(Of Vessel)(vessels)
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
        ' Order the dropdown lists alphabetically.
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        ManufacturerBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList()
        ' Set the nav bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Vessels"
        Navigator.MasterControl = DataGridVessels
        Navigator.MasterSource = VesselBindingSource
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mJobsForm, Database)
            mJobsForm.Find(JobsBindingSource.Current.Id)
            'mJobsForm.Filter = JobsBindingSource.Current.Id
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class