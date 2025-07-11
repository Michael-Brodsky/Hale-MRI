Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDatabase.StoredProcedures
Public Class FrmJobs
    Inherits FrmDatabaseForm
    ' Define the DataGridView's double-clickable column indices.
    Private Const kJobsVesselColumnId As Short = 1
    Private Const kJobsManufacturerColumnId As Short = 5
    Private Const kJobsInspectedByColumnId As Short = 12
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mJobDetailsForm As FrmJobDetails
    Private mFrmVessels As FrmVessels
    Private mFrmManufacturers As FrmManufacturers
    Public Property Current As Job
        Set(value As Job)
            Me.Find(value.Id)
        End Set
        Get
            If Navigator.Current IsNot Nothing Then
                Return CType(JobBindingSource.Current, Job)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        If JobBindingSource.SupportsSearching Then
            Return JobBindingSource.Find("Id", id)
        Else
            Dim index = Database.Vessels.Local.ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then JobBindingSource.Position = index
            Return index
        End If
    End Function
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs)
        ' Undo any pending database changes and refresh the form.
        If Database IsNot Nothing Then
            Try
                Rollback(Of Job)(Database)   ' Only the Jobs table is editable on this form.
                DataGridJobs.Refresh()
            Catch ex As Exception
                MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs)
        ' Save changes to the database context.
        If Database IsNot Nothing Then
            Try
                Database.SaveChanges()
                DataGridJobs.Refresh()
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
    Private Sub FrmJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the form BindingSources to the respective context model local views.
        JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList
        ' Bind the details BindingSources to the master BindingSources on the property of the master model.
        BindMasterDetails(JobBindingSource, JobDetailsBindingSource, "JobDetails")
        ' Set the nav bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Jobs"                  ' Caption
        Navigator.MasterControl = DataGridJobs       ' Bound control
        Navigator.Database = MyBase.Database        ' HaleMRIContext
        Navigator.MasterSource = JobBindingSource   ' BindingSource
    End Sub

    Private Sub DataGridJobDetails_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridJobDetails.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mJobDetailsForm, Database)
            mJobDetailsForm.Find(JobDetailsBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class