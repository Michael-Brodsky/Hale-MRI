Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Public Class FrmJobs
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFrmCustomers As FrmCustomers
    Private mFrmVessels As FrmVessels
#End Region
#Region "Public Interface"
    Public Property Current As Job
        Get
            Return CType(JobBindingSource.Current, Job)
        End Get
        Set(value As Job)
            Me.Find(value.Id)
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
        Dim index As Integer
        If JobBindingSource.SupportsSearching Then
            index = JobBindingSource.Find("Id", id)
        Else
            FilterByJob(id)
            ComboJobs.Select()
            index = ComboJobs.SelectedIndex
        End If
        Return index
    End Function
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub BindDataSources()
        DataGridJobDetails.AutoGenerateColumns = False
        'Populate the drop down lists with the respective data.    
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList
        RotationBindingSource.DataSource = Database.Rotations.Local.ToBindingList
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList
        ExclusionsBindingSource.DataSource = Database.Exclusions.Local.ToBindingList
        CupBindingSource.DataSource = Database.Cups.Local.ToBindingList
        'Clear the search filters and bind the Jobs master to JobDetails.
        FiltersClear()
        BindMasterDetails(JobBindingSource, JobDetailsBindingSource, "JobDetails")
        ' Configure the RecordNavigator.
        Navigator = RecordNavigationBar1
        Navigator.Caption = ""
        Navigator.Left = DataGridJobDetails.Left - Navigator.Margin.Left
        Navigator.MasterSource = JobBindingSource
        Navigator.BoundControls = New List(Of Control) From {
            ComboManufacturer,
            ComboStyle,
            ComboMaterial,
            ComboRotation,
            ComboBlades,
            ComboBore,
            ComboLEExclusion,
            ComboTeExclusion,
            ComboCup,
            ComboInspectedBy,
            TxtDAR,
            TxtDiameter,
            TxtPartNumber,
            TxtSerialNumber,
            TxtStampNumber,
            DataGridJobDetails
        }
        Navigator.Enabled = False
    End Sub
    Private Sub FilterByCustomer()
        'Filter the vessels and jobs based on the selected customer.
        VesselBindingSource.DataSource = New BindingList(Of Vessel)(Database.Vessels.Local.Where(Function(v) v.CustomerId = ComboCustomers.SelectedItem.Id).OrderBy(Function(v) v.VesselName).ToList())
        JobBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.Where(Function(j) j.VesselId = ComboVessels.SelectedItem.Id).OrderBy(Function(j) j.JobNumber).ToList())
        JobBindingSource.ResumeBinding()
        Navigator.Enabled = True
        If DataGridJobDetails.DataSource Is Nothing Then DataGridJobDetails.DataSource = JobDetailsBindingSource
    End Sub
    Private Sub FilterByJob(ByVal selectedValue As Integer)
        'Display the selected job data and show the associated customer and vessel.
        JobBindingSource.ResumeBinding()
        Navigator.Enabled = True
        ComboJobs.SelectedValue = selectedValue ' This needs to be re-set to ensure the correct job is displayed.
        ComboVessels.SelectedValue = ComboJobs.SelectedItem.VesselId
        ComboCustomers.SelectedValue = ComboVessels.SelectedItem.CustomerId
        If DataGridJobDetails.DataSource Is Nothing Then DataGridJobDetails.DataSource = JobDetailsBindingSource
    End Sub
    Private Sub FilterByVessel()
        'Filter the jobs based on the selected vessel and show the customer.
        JobBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.Where(Function(j) j.VesselId = ComboVessels.SelectedItem.Id).OrderBy(Function(j) j.JobNumber).ToList())
        JobBindingSource.ResumeBinding()
        Navigator.Enabled = True
        ComboCustomers.SelectedValue = ComboVessels.SelectedItem.CustomerId
        If DataGridJobDetails.DataSource Is Nothing Then DataGridJobDetails.DataSource = JobDetailsBindingSource
    End Sub
    Private Sub FiltersClear()
        'Clear the search criteria and reset the data sources.
        DataGridJobDetails.DataSource = Nothing
        CustomerBindingSource.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        VesselBindingSource.DataSource = New BindingList(Of Vessel)(Database.Vessels.OrderBy(Function(v) v.VesselName).ToList())
        JobBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.OrderBy(Function(j) j.JobNumber).ToList())
        JobBindingSource.SuspendBinding()
        If Navigator IsNot Nothing Then Navigator.Enabled = False
        ComboCustomers.SelectedIndex = kNoCurrentSelection
        ComboVessels.SelectedIndex = kNoCurrentSelection
        ComboJobs.SelectedIndex = kNoCurrentSelection
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub CmdFiltersClear_Click(sender As Object, e As EventArgs) Handles CmdFiltersClear.Click
        Try
            FiltersClear()
        Catch ex As Exception
            MessageBox.Show("Error clearing filters: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs)
        Try
            BindingSourceSave(Database, JobBindingSource)
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdUndo_Click(sender As Object, e As EventArgs)
        Try
            BindingSourceUndo(Database, JobBindingSource)
        Catch ex As Exception
            MessageBox.Show("Error undoing changes: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboCustomers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboCustomers.SelectionChangeCommitted
        Try
            FilterByCustomer()
        Catch ex As Exception
            MessageBox.Show("Error selecting vessel: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboJobs_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboJobs.SelectionChangeCommitted
        Try
            FilterByJob(ComboJobs.SelectedValue)
        Catch ex As Exception
            MessageBox.Show("Error selecting job: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboVessels_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboVessels.SelectionChangeCommitted
        Try
            FilterByVessel()
        Catch ex As Exception
            MessageBox.Show("Error selecting vessel: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmJobs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Clear the job details data source when the form is closing, otherwise an exception occurs.
        DataGridJobDetails.DataSource = Nothing
    End Sub
    Private Sub ComboVessels_MouseUp(sender As Object, e As MouseEventArgs) Handles ComboVessels.MouseUp
        ' Handles the mousedouble click event on the ComboVessels control.
        Try
            If ComboDoubleClick() AndAlso ComboVessels.SelectedItem IsNot Nothing Then
                ShowForm(Of FrmVessels)(mFrmVessels, Database)
                mFrmVessels.Current = ComboVessels.SelectedItem
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening vessels form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class