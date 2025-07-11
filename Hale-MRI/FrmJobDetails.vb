Imports LibDatabase.Models

Public Class FrmJobDetails
    Inherits FrmDatabaseForm
    Public Property Current As Customer
        Set(value As Customer)
            Me.Find(value.Id)
        End Set
        Get
            If Navigator.Current IsNot Nothing Then
                Return CType(JobDetailBindingSource.Current, Customer)
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
        ToleranceBindingSource.DataSource = Database.Tolerances.Local.ToBindingList()
        RotationBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ExclusionBindingSource.DataSource = Database.Exclusions.Local.ToBindingList()
        ' Set the navigation bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Job Details"
        Navigator.MasterSource = JobDetailBindingSource
        Navigator.MasterControl = DataGridJobDetails
    End Sub
End Class