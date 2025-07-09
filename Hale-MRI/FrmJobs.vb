Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDatabase.StoredProcedures
Public Class FrmJobs
    Inherits FrmDatabaseForm
    Private Const kJobsVesselColumnId As Short = 1
    Private Const kJobsManufacturerColumnId As Short = 5
    Private Const kJobsInspectedByColumnId As Short = 12

    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mJobDetailsForm As FrmJobDetails
    Private mFrmVessels As FrmVessels
    'Private mFormEmployees As FrmEmployees
    Private mFrmManufacturers As FrmManufacturers
    Public Property CurrentJob As Job
        ' Gets/sets the form's current Job record.
        Set(value As Job)
            If value IsNot Nothing Then CurrentId = value.Id
        End Set
        Get
            If JobBindingSource.Current IsNot Nothing Then
                Return CType(JobBindingSource.Current, Job)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property CurrentId As Integer
        ' Gets/sets the form's current JobId.
        Set(value As Integer)
            If JobBindingSource.SupportsSearching Then
                JobBindingSource.Find("Id", value)
            Else
                Dim index = Database.Jobs.Local.ToList().FindIndex(Function(v) v.Id = value)
                If index <> kNoCurrentRecord Then JobBindingSource.Position = index
            End If
        End Set
        Get
            If JobBindingSource.Current IsNot Nothing Then
                Return JobBindingSource.Current.Id
            Else
                Return kNoCurrentRecord
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
    Private Sub BindDataSources()
        ' Bind the data tables to the respective BindingSources.
        JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList
        BindMasterDetails(JobBindingSource, JobDetailsBindingSource, "JobDetails")
    End Sub
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs)
        ' Undo any pending database changes and refresh the form.
        If Database IsNot Nothing Then
            Try
                Rollback(Of Job)(Database)   ' Only the Jobs table is editable on this form.
                DataGridJobs.Refresh
            Catch ex As Exception
                MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs)
        ' Save changes to the database context.
        If Database IsNot Nothing Then
            Try
                Database.SaveChanges
                DataGridJobs.Refresh
            Catch ex As Exception
                MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub DataGridJobs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridJobs.CellDoubleClick
        Try
            Select Case e.ColumnIndex
                Case kJobsVesselColumnId
                    ShowForm(mFrmVessels, Database)
                    mFrmVessels.Find(JobBindingSource.Current.VesselId)
                Case kJobsManufacturerColumnId
                    ShowForm(mFrmManufacturers, Database)
                    mFrmManufacturers.CurrentId = JobBindingSource.Current.ManufacturerId
                Case kJobsInspectedByColumnId
                    'ShowForm(mFormEmployees, Database)
                    'mFormEmployees.CurrentRecord = TryCast(DataGridJobs.CurrentRow?.DataBoundItem, Employee)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RecordNavigationBar1_Load(sender As Object, e As EventArgs) Handles RecordNavigationBar1.Load
        ' Set the nav bar properties.
        RecordNavigationBar1.Caption = "Jobs"                  ' Caption
        RecordNavigationBar1.BoundControl = DataGridJobs       ' Bound control
        RecordNavigationBar1.Database = MyBase.Database        ' HaleMRIContext
        RecordNavigationBar1.RecordSource = JobBindingSource   ' BindingSource
    End Sub
End Class