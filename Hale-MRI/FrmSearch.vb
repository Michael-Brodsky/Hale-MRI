Imports LibDatabase.Models
Public Class FrmSearch
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetailsForm As FrmJobDetails
    ' Flags to prevent unnecessary updates when the form is loading and during selection changes.
    Private mIsLoading As Boolean = True
    Private mJobSelectionChanged As Boolean = False
    Private mVesselSelectionChanged As Boolean = False
#End Region
#Region "Event Handlers"
    Private Sub CmdSearchClear_Click(sender As Object, e As EventArgs) Handles CmdSearchClear.Click
        Try
            SearchClear()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComboCustomers_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCustomers.SelectedValueChanged
        ' Show the vessels for the selected customer.
        If Not mIsLoading AndAlso ComboCustomers.SelectedItem IsNot Nothing Then
            If Not mVesselSelectionChanged Then
                VesselBindingSource.DataSource = Database.Vessels.Local.Where(Function(v) v.CustomerId = ComboCustomers.SelectedValue).ToList()
            End If
        End If
    End Sub
    Private Sub ComboCustomers_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboCustomers.Validating
        SelectionValidate(ComboCustomers)
    End Sub
    Private Sub ComboVessels_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboVessels.SelectedValueChanged
        ' Show the jobs and customer for the selected vessel.
        If Not mIsLoading AndAlso ComboVessels.SelectedItem IsNot Nothing Then
            If Not mJobSelectionChanged Then
                JobBindingSource.DataSource = Database.Jobs.Local.Where(Function(j) j.VesselId = ComboVessels.SelectedValue).ToList()
            End If
            mVesselSelectionChanged = True
            ComboCustomers.SelectedItem = Database.Customers.Local.FirstOrDefault(Function(c) c.Id = CType(ComboVessels.SelectedItem, Vessel).CustomerId)
            mVesselSelectionChanged = False
        End If
    End Sub
    Private Sub ComboVessels_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboVessels.Validating
        SelectionValidate(ComboVessels)
    End Sub

    Private Sub ComboJobs_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboJobs.SelectedValueChanged
        ' Show the job details, vessel and customer for the selected job.
        If Not mIsLoading AndAlso ComboJobs.SelectedItem IsNot Nothing Then
            mJobSelectionChanged = True
            ComboVessels.SelectedItem = Database.Vessels.Local.FirstOrDefault(Function(v) v.Id = CType(ComboJobs.SelectedItem, Job).VesselId)
            JobShow(True)
            mJobSelectionChanged = False
        End If
    End Sub
    Private Sub ComboJobs_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboJobs.Validating
        SelectionValidate(ComboJobs)
    End Sub
    Private Sub FrmSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Clear the job details data source when the form is closing, otherwise an exception occurs.
        JobShow(False)
    End Sub
    Private Sub FrmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchClear()
        ' Load the related Job data.
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList
        ' Bind the details BindingSources to the master BindingSources on the property of the master model.
        BindMasterDetails(JobBindingSource, JobDetailsBindingSource, "JobDetails")
    End Sub
#End Region
#Region "Private Interface"
    Private Sub JobShow(ByVal visible As Boolean)
        ' Show/hide the job and job details data.
        ' This needs cleaned up. Shouldn't have to do it programmatically..
        If visible Then
            If TxtPartNumber.DataBindings.Count = 0 Then TxtPartNumber.DataBindings.Add("Text", JobBindingSource, "PartNumber", True, DataSourceUpdateMode.OnPropertyChanged)
            If TxtSerialNumber.DataBindings.Count = 0 Then TxtSerialNumber.DataBindings.Add("Text", JobBindingSource, "SerialNumber", True, DataSourceUpdateMode.OnPropertyChanged)
            If TxtStampNumber.DataBindings.Count = 0 Then TxtStampNumber.DataBindings.Add("Text", JobBindingSource, "StampNumber", True, DataSourceUpdateMode.OnPropertyChanged)
            If TxtDiameter.DataBindings.Count = 0 Then TxtDiameter.DataBindings.Add("Text", JobDetailsBindingSource, "Diameter", True, DataSourceUpdateMode.OnPropertyChanged)
            If TxtMarkedPitch.DataBindings.Count = 0 Then TxtMarkedPitch.DataBindings.Add("Text", JobDetailsBindingSource, "MarkedPitch", True, DataSourceUpdateMode.OnPropertyChanged)
            If TxtDesiredPitch.DataBindings.Count = 0 Then TxtDesiredPitch.DataBindings.Add("Text", JobDetailsBindingSource, "DesiredPitch", True, DataSourceUpdateMode.OnPropertyChanged)
            ComboInspectedBy.DataSource = Database.Employees.Local.ToBindingList()
            ComboInspectedBy.DisplayMember = "EmployeeName"
            ComboInspectedBy.ValueMember = "Id"
            If ComboInspectedBy.DataBindings.Count = 0 Then ComboInspectedBy.DataBindings.Add("SelectedValue", JobBindingSource, "InspectedBy", True, DataSourceUpdateMode.OnPropertyChanged)
            DataGridJobDetails.DataSource = Database.JobDetails.Local.Where(Function(jd) jd.JobId = ComboJobs.SelectedValue).ToList()
        Else
            TxtPartNumber.DataBindings.Clear()
            TxtSerialNumber.DataBindings.Clear()
            TxtStampNumber.DataBindings.Clear()
            TxtDiameter.DataBindings.Clear()
            TxtMarkedPitch.DataBindings.Clear()
            TxtDesiredPitch.DataBindings.Clear()
            ComboInspectedBy.DataBindings.Clear()
            TxtPartNumber.Clear()
            TxtSerialNumber.Clear()
            TxtStampNumber.Clear()
            TxtDiameter.Clear()
            TxtMarkedPitch.Clear()
            TxtDesiredPitch.Clear()
            ComboInspectedBy.DataSource = Nothing
            DataGridJobDetails.DataSource = Nothing
        End If
    End Sub
    Private Sub SearchClear()
        ' Clear all selections and reset the data sources for the search combo boxes.
        mIsLoading = True
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        VesselBindingSource.DataSource = Database.Vessels.Local.ToBindingList()
        JobBindingSource.DataSource = Database.Jobs.Local.ToBindingList()
        JobShow(False)
        ComboCustomers.SelectedItem = Nothing
        ComboVessels.SelectedItem = Nothing
        ComboJobs.SelectedItem = Nothing
        mIsLoading = False
    End Sub
    Private Sub SelectionValidate(sender As ComboBox)
        ' If the given search box is empty, clear the search results,
        ' else validate the entry.
        If sender.Text = String.Empty Then
            SearchClear()
        ElseIf ComboJobs.SelectedItem Is Nothing Then
            MessageBox.Show(STR_ERR_INVALID_SELECTION, STR_TITLE_DEFAULT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub DataGridJobDetails_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridJobDetails.CellMouseDoubleClick
        ' Open the JobDetailss form with the selected job as the current record.
        Try
            ShowForm(mJobDetailsForm, Database)
            'mJobDetailsForm.Filter = "JobId = " & JobDetailsBindingSource.Current.JobId
            mJobDetailsForm.Find(JobDetailsBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class