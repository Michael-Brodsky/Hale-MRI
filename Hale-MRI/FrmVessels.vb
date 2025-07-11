Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports LibDatabase
Public Class FrmVessels
    Inherits FrmDatabaseForm
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mJobsForm As FrmJobs
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
            Dim index = Database.Vessels.Local.ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then VesselBindingSource.Position = index
            Return index
        End If
    End Function
    Private Sub BindDataSources()
        ' Bind the data tables to the respective BindingSources.
        ' Bind Vessels (master) to Jobs (details). This automatically updates
        ' the Jobs list when a Vessel is selected.
        ' Set the nav bar properties
    End Sub
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mJobsForm, Database)
            mJobsForm.Find(JobsBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the form BindingSources to the respective context model local views.
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        JobsBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        ManufacturerBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList()
        ' Bind the details BindingSources to the master BindingSources on the property of the master model.
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
        ' Set the nav bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Vessels"
        Navigator.MasterControl = DataGridVessels
        Navigator.MasterSource = VesselBindingSource
    End Sub
End Class