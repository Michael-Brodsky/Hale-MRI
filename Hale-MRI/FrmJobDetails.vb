Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmJobDetails
    Inherits FrmDatabaseForm

    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.

    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(mMasterSource)
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

    Public Function Find(item As JobDetail) As JobDetail
        Dim result As JobDetail = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = MasterSource.Current
        End If
        Return result
    End Function

    Protected Overrides Sub BindDataSources()

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

    Private Sub FrmJobDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bind the form BindingSources to the respective context model local views.
        JobDetailBindingSource.DataSource = Database.JobDetails.Local.ToBindingList()
        'ToleranceBindingSource.DataSource = Database.Tolerances.Local.ToBindingList()
        RotationBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ExclusionBindingSource.DataSource = Database.Exclusions.Local.ToBindingList()
        ' Set the navigation bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Job Details"
        MasterSource = JobDetailBindingSource
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