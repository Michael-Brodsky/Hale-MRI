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
            If CustomerBindingSource.SupportsSearching Then
                CustomerBindingSource.Find("Id", value)
            Else
                Me.Find(value.Id)
            End If
        End Set
        Get
            If RecordNavigationBar1.Current IsNot Nothing Then
                Return CType(VesselBindingSource.Current, Vessel)
            Else
                Return Nothing
            End If
        End Get
    End Property
    'Public Property CurrentVessel As Vessel
    '    ' Gets/sets the form's current Vessel record.
    '    Set(value As Vessel)
    '        If value IsNot Nothing Then CurrentId = value.Id
    '    End Set
    '    Get
    '        If VesselBindingSource.Current IsNot Nothing Then
    '            Return CType(VesselBindingSource.Current, Vessel)
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property
    'Public Property CurrentId As Integer
    '    ' Gets/sets the form's current VesselId.
    '    Set(value As Integer)
    '        Dim x = VesselBindingSource.SupportsFiltering
    '        If VesselBindingSource.SupportsSearching Then
    '            VesselBindingSource.Find("Id", value)
    '        Else
    '            Dim index = Database.Vessels.Local.ToList().FindIndex(Function(v) v.Id = value)
    '            If index <> kNoCurrentRecord Then VesselBindingSource.Position = index
    '        End If
    '    End Set
    '    Get
    '        If VesselBindingSource.Current IsNot Nothing Then
    '            Return VesselBindingSource.Current.Id
    '        Else
    '            Return kNoCurrentRecord
    '        End If
    '    End Get
    'End Property
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
            RecordNavigationBar1.Filter = value
        End Set
        Get
            Return RecordNavigationBar1.Filter
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
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        'VesselBindingSource.DataSource = New EntityHelper(Of Vessel)(Database.Vessels.Local.ToBindingList())
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList()
        ManufacturerBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList()
        ' Bind Vessels (master) to Jobs (details). This automatically updates
        ' the Jobs list when a Vessel is selected.
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")

        'RecordNavigationBar1.RecordSource = bs
        'RecordNavigationBar1.SearchSource = New BindingSource With {
        '    .DataSource = Database.Vessels.Local.ToList().ToDataTable()
        '}
    End Sub
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs)
        ' Undo any pending database changes and refresh the form.
        If Database IsNot Nothing Then
            Try
                Rollback(Of Vessel)(Database)   ' Only the Vessels table is editable on this form.
                DataGridVessels.Refresh()
            Catch ex As Exception
                MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs)
        ' Save changes to the database context.
        Try
            Database.SaveChanges()
            DataGridVessels.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mJobsForm, Database)
            mJobsForm.CurrentId = JobsBindingSource.Current.Id
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the nav bar properties.
        RecordNavigationBar1.Caption = "Vessels"
        RecordNavigationBar1.BoundControl = DataGridVessels
        RecordNavigationBar1.Database = MyBase.Database
        RecordNavigationBar1.RecordSource = VesselBindingSource
    End Sub
End Class