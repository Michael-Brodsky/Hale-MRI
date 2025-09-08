Imports LibDatabase.Models

Public Class FrmJobDetails
    Inherits FrmDatabaseForm
    Public Property Filter As String
        Set(value As String)
            'Navigator.Filter = value
        End Set
        Get
            Return Nothing
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        If Navigator.MasterSource.SupportsSearching Then
            Return Navigator.MasterSource.Find("Id", id)
        Else
            Dim index = Database.JobDetails.Local.ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then Navigator.MasterSource.Position = index
            Return index
        End If
    End Function

    Private Sub FrmJobDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the form BindingSources to the respective context model local views.
        JobDetailBindingSource.DataSource = Database.JobDetails.Local.ToBindingList()
        'ToleranceBindingSource.DataSource = Database.Tolerances.Local.ToBindingList()
        RotationBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ExclusionBindingSource.DataSource = Database.Exclusions.Local.ToBindingList()
        ' Set the navigation bar properties.
        Navigator = RecordNavigationBar1
        Caption = "Job Details"
        DataSource = JobDetailBindingSource
        'Navigator.MasterControl = DataGridJobDetails
    End Sub

    Private Sub DataGridJobDetails_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridJobDetails.CellMouseDoubleClick
        Try
            'ShowForm(mFrmMeasurements, Database)
            'mFrmMeasurements.JobDetails = CType(JobDetailBindingSource.Current, JobDetail)
            'mFrmMeasurements.Job = JobDetailBindingSource.Current.Job
        Catch ex As Exception
            MessageBox.Show("Error opening measurements form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class