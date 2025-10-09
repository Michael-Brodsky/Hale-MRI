Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase
Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmJobs
    Inherits FrmDatabaseForm
#Region "Types and Constants"
    Private Enum GetAJob
        First = 1
        Last = 2
    End Enum
#End Region
#Region "Private Members"
    Private mFilter As Object = Nothing          ' The current form filter object, if any.
    Private mFilterOn As Boolean = False         ' Flag indicating whether the current form filter is active.
    ' Declare all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmCustomers As FrmCustomers
    Private mFrmVessels As FrmVessels
    Private mFrmMeasurements As Form1
    'Private mFrmMeasurements As FrmMeasurements
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return CurrentJob
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Property Filter As Object
        Get
            Return mFilter
        End Get
        Set(value As Object)
            mFilter = value
            Navigator.Filter = mFilter
            FilterOn = mFilter IsNot Nothing
        End Set
    End Property

    Public Property FilterOn As Boolean
        Get
            Return mFilterOn
        End Get
        Set(value As Boolean)
            mFilterOn = value
            If mFilterOn AndAlso mFilter IsNot Nothing Then
                FiltersApply()
            ElseIf Not mFilterOn AndAlso mFilter IsNot Nothing Then
                FiltersRemove()
            End If
            Navigator.FilterOn = mFilterOn
        End Set
    End Property

    Public Function Find(item As Job) As Job
        ' Searches for the given Job and, if found, selects and returns it.
        Dim result As Job = Nothing
        Dim pos As Integer = BindingSourceFind(JobsBindingSource, item)
        If pos <> kNoCurrentRecord Then
            SelectedJob = item
            result = CurrentJob
        End If
        Return result
    End Function

    Public Property Hardware As WorkstationEncoders ' We need to pass this to the measurements form.
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' Populate all drop down lists and bind JobsBindingSource (master) to JobDetailsBindingSource (details).
        If Database IsNot Nothing Then
            ComboBlades.DataSource = Database.Blades.Local.ToBindingList
            ComboCup.DataSource = Database.Cups.Local.ToBindingList
            ComboLEExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            ComboMaterial.DataSource = Database.Materials.Local.ToBindingList
            ComboManufacturer.DataSource = Database.Manufacturers.Local.ToBindingList
            ComboRotation.DataSource = Database.Rotations.Local.ToBindingList
            ComboStyle.DataSource = Database.Styles.Local.ToBindingList
            ComboTeExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.OrderBy(Function(e) e.EmployeeName).ToList())
            FiltersRemove()
            BindMasterDetails(JobsBindingSource, JobDetailsBindingSource, "JobDetails")
        End If
    End Sub

    Private Function CreateNewJob() As Job
        ' Returns a new Job with a unique job number and the currently selected Vessel.
        Return New Job With {
            .Vessel = SelectedVessel,
            .StartDate = Date.Now,
            .JobNumber = If(Database.Jobs.Any(), Database.Jobs.Max(Function(job) job.JobNumber) + 1, 1)
        }
    End Function

    Private ReadOnly Property CurrentJob As Job
        Get
            Return BindingSourceCurrent(JobsBindingSource)
        End Get
    End Property

    Private Function DeleteConfirm() As Boolean
        Return (MessageBox.Show($"Delete job {CurrentJob.JobNumber}?", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK)
    End Function

    Private Sub DeleteJob()
        BindingSourceRemove(Database, JobsBindingSource, Database.Jobs)
    End Sub

    Private Sub FilterByCustomer()
        ' Filter the vessels drop down to include only the currently selected Customer's Vessels.
        SelectedVessel = Nothing    ' Blank the currently selected vessel in case the current Customer has no Vessels.
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.Where(Function(v) v.Customer Is SelectedCustomer).ToList())
        If ComboVessels.Items.Count > 0 Then SelectedVessel = CType(ComboVessels.Items(0), Vessel)
        ' The first Customer Vessel, if any, should now be selected.
        FilterByVessel()
    End Sub

    Private Sub FilterByJob()
        ' Currently not used.
    End Sub

    Private Sub FilterByVessel()
        ' Filter the jobs drop down to include only the currently selected Vessel's Jobs.
        SelectedJob = Nothing   ' Blank the currently selected Job in case the current Vessel has no Jobs.
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Where(Function(j) j.Vessel Is SelectedVessel).ToList())
        If JobsBindingSource.Count > 0 Then SelectedJob = CType(JobsBindingSource(0), Job)
    End Sub

    Private Sub FiltersApply()
        Select Case True
            Case TypeOf Filter Is Customer
                FilterByCustomer()
            Case TypeOf Filter Is Vessel
                FilterByVessel()
            Case TypeOf Filter Is Job
                FilterByJob()
            Case Else
                ' Handle other filter types if necessary.
        End Select
    End Sub

    Private Sub FiltersRemove()
        ' Save the currently selected Customer, Vessel and Job.
        Dim displayedCustomer As Customer = SelectedCustomer
        Dim displayedVessel As Vessel = SelectedVessel
        Dim displayedJob As Job = SelectedJob
        ' Refresh the drop down lists.
        ComboCustomers.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.OrderBy(Function(v) v.VesselName).ToList())
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.OrderBy(Function(j) j.JobNumber).ToList())
        ' Show the previously selected Customer, Vessel and Job.
        SelectedJob = displayedJob
        SelectedVessel = displayedVessel
        SelectedCustomer = displayedCustomer
    End Sub

    Private WriteOnly Property InitialJob As GetAJob
        Set(value As GetAJob)
            JobSelected = True
            Select Case value
                Case GetAJob.First
                    JobsBindingSource.MoveFirst()
                Case GetAJob.Last
                    JobsBindingSource.MoveLast()
                Case Else
            End Select
            Navigator.Refresh()
        End Set
    End Property

    Private Property JobSelected As Boolean
        Get
            Return Not JobsBindingSource.IsBindingSuspended
        End Get
        Set(value As Boolean)
            If value Then
                JobsBindingSource.ResumeBinding()
                DataGridJobDetails.DataSource = JobDetailsBindingSource
                ' If the no job was selected and user selects the first job in list,
                ' binding source position wont change and the navigator won't
                ' enable its controls. So we help along a bit here.
                Navigator.Refresh()
            Else
                JobsBindingSource.SuspendBinding()
                DataGridJobDetails.DataSource = Nothing
            End If
        End Set
    End Property

    Private WriteOnly Property JobSelectionEnabled As Boolean
        Set(value As Boolean)
            ComboCustomers.Enabled = value
            ComboVessels.Enabled = value
            ComboJobs.Enabled = value
            ScanDataPickEnabled = value
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar

    Private Property PreviousJob As Job

    Private Sub ScanDataExport()

    End Sub

    Private WriteOnly Property ScanDataImexEnabled As Boolean
        Set(value As Boolean)
            CmdScanDataImport.Enabled = value
            CmdScanDataExport.Enabled = value
        End Set
    End Property

    Private Sub ScanDataImport()
        ' Import scan data from a file, add it to the database and show the job data.
        Dim scandataFile As String = TxtScanDataFile.Text
        Dim importedJob As Job = Imex.ScanDataImport(scandataFile)
        If importedJob Is Nothing Then
            ' If no job was created, show an error message.
            MessageBox.Show("No job was created from the scan data file because it is corrupted or missing required data.", STR_TITLE_DEFAULT, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' Add the Job created from the imported scan data to the database.
        importedJob = ScanDataAdd(Database, importedJob)
        ' We need to refresh the EmployeesBindingSource in case a new employee was added.
        EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.OrderBy(Function(e) e.EmployeeName).ToList())
        ' Clear the form filters and show the imported Job.
        If FilterOn Then
            FilterOn = False
        Else
            FiltersRemove()
        End If
        SelectedJob = importedJob
        TxtScanDataFile.Text = scandataFile
    End Sub

    Private Sub ScanDataPick()
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Scan Data File",
            .Filter = "ScanData Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .InitialDirectory = If(SettingsGet(Database, STR_SETTING_APPLICATION_DEFAULT_FOLDER), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        }
        If ofd.ShowDialog() = DialogResult.OK Then TxtScanDataFile.Text = ofd.FileName
    End Sub

    Private WriteOnly Property ScanDataPickEnabled As Boolean
        Set(value As Boolean)
            TxtScanDataFile.Enabled = value
            CmdScanDataPick.Enabled = value
            If Not value Then ScanDataImexEnabled = False
        End Set
    End Property

    Private Property SelectedCustomer As Customer
        Get
            Return CType(ComboCustomers.SelectedItem, Customer)
        End Get
        Set(value As Customer)
            ComboCustomers.SelectedItem = value
        End Set
    End Property

    Private Property SelectedJob As Job
        Get
            Return CType(ComboJobs.SelectedItem, Job)
        End Get
        Set(value As Job)
            If value IsNot Nothing AndAlso JobsBindingSource.IsBindingSuspended Then JobSelected = True
            ComboJobs.SelectedItem = value
        End Set
    End Property

    Private Property SelectedVessel As Vessel
        Get
            Return CType(ComboVessels.SelectedItem, Vessel)
        End Get
        Set(value As Vessel)
            ComboVessels.SelectedItem = value
            If ComboVessels.SelectedItem IsNot Nothing AndAlso JobsBindingSource.Count = 0 Then Navigator.CmdAddNew.Enabled = True
        End Set
    End Property
#End Region
#Region "Event Handlers"
    Private Sub CmdScanDataExport_Click(sender As Object, e As EventArgs) Handles CmdScanDataExport.Click
        Try
            ScanDataExport()
        Catch ex As Exception
            MessageBox.Show("Error opening jobs form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdScanDataImport_Click(sender As Object, e As EventArgs) Handles CmdScanDataImport.Click
        Try
            ScanDataImport()
        Catch ex As Exception
            MessageBox.Show("Error importing scan data: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdScanDataPick_Click(sender As Object, e As EventArgs) Handles CmdScanDataPick.Click
        Try
            ScanDataPick()
        Catch ex As Exception
            MessageBox.Show("Error selecting scan data file: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboCustomers_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboCustomers.MouseClick
        Try
            If SelectedCustomer IsNot Nothing AndAlso ComboCustomers.DoubleClicked() Then
                ShowForm(mFrmCustomers, Database, User)
                mFrmCustomers.Find(SelectedCustomer)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening the customers form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboCustomers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboCustomers.SelectionChangeCommitted
        Try
            Filter = SelectedCustomer
        Catch ex As Exception
            MessageBox.Show("Filtering error: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboJobs_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboJobs.MouseClick
        ' Open the measurements form with the clicked Job record.
        Try
            If CurrentJob IsNot Nothing AndAlso ComboJobs.DoubleClicked() Then
                ShowForm(mFrmMeasurements, Database, User)
                mFrmMeasurements.Hardware = Hardware
                mFrmMeasurements.Job = CurrentJob
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening the job details form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboJobs_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboJobs.SelectionChangeCommitted
        Try
            ' If no Job is currently selected and a valid selection was made ...
            If Not JobSelected AndAlso SelectedJob IsNot Nothing Then
                ' ... save the selected Job so we can restore it after setting JobSelected = True
                Dim j As Job = SelectedJob
                JobSelected = True
                SelectedJob = j
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting a job: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboStyle_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboStyle.SelectionChangeCommitted
        ' Automatically chnage the blade count for certain propeller styles.
        If ComboStyle.SelectedItem IsNot Nothing Then
            Select Case ComboStyle.SelectedValue
                Case "3-Blade"

                Case "4-Blade", "Dura Quad", "Dyna Quad", "Equi Quad"

                Case Else
            End Select
        End If
    End Sub

    Private Sub ComboVessels_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboVessels.MouseClick
        Try
            If SelectedVessel IsNot Nothing AndAlso ComboVessels.DoubleClicked() Then
                ShowForm(mFrmVessels, Database, User)
                mFrmVessels.Find(SelectedVessel)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening the vessels form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboVessels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboVessels.SelectedIndexChanged
        If SelectedVessel IsNot Nothing Then
            SelectedCustomer = SelectedVessel?.Customer
            If JobsBindingSource.Count = 0 And Navigator IsNot Nothing Then Navigator.CmdAddNew.Enabled = True
        End If
    End Sub

    Private Sub ComboVessels_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboVessels.SelectionChangeCommitted
        Try
            Filter = SelectedVessel
        Catch ex As Exception
            MessageBox.Show("Filtering error: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridJobDetails_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridJobDetails.CellMouseDoubleClick
        ' Open the measurements form with the clicked JobDetail record.
        Try
            ShowForm(mFrmMeasurements, Database, User)
            mFrmMeasurements.Hardware = Hardware
            mFrmMeasurements.JobDetails = BindingSourceCurrent(JobDetailsBindingSource)
        Catch ex As Exception
            MessageBox.Show("Error opening the job details form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormJobs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        DataGridJobDetails.DataSource = Nothing
    End Sub

    Private Sub FormJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DataGridJobDetails.AutoGenerateColumns = False
            DataGridJobDetails.DataSource = Nothing
            Navigator = RecordNavigationBar1
            ' These are the controls bound to the JobsBindingSource that the Navigator will enable automatically
            ' and notify us when any changes are made.
            Navigator.BoundControls = New List(Of Control) From {
                ComboManufacturer,
                TxtPartNumber,
                ComboStyle,
                ComboMaterial,
                ComboRotation,
                ComboBlades,
                TxtBore,
                TxtDiameter,
                TxtSerialNumber,
                TxtStampNumber,
                TxtMarkedPitch,
                TxtDesiredPitch,
                ComboLEExclusion,
                ComboTeExclusion,
                ComboCup,
                ComboInspectedBy,
                TxtDAR
            }
            Navigator.Database = Database
            Navigator.MasterSource = JobsBindingSource  ' The Navigator manages the Job records and notifies us when changes occur.
            JobSelected = False                         ' Nothing is initially selected when this form loads.
            AddHandler JobsBindingSource.CurrentChanged, AddressOf JobsBindingSource_CurrentChanged
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Catch ex As Exception
            MessageBox.Show("Error opening the jobs form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobsBindingSource_CurrentChanged(sender As Object, e As EventArgs)
        Try
            If CurrentJob IsNot Nothing Then SelectedVessel = CurrentJob?.Vessel
            TxtScanDataFile.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("Error moving to the selected record: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobsBindingSource.AddingNew
        Try
            Dim newJob As Job = CreateNewJob()
            PreviousJob = SelectedJob
            e.NewObject = newJob
            Database.Jobs.Add(newJob)
            JobSelectionEnabled = False
        Catch ex As Exception
            MessageBox.Show("Error adding a new job: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        ' Handles Navigator events so we can update our control states accordingly.
        ' TODO: Record Nav Bar should send control as NavigationEventArgs parameter.
        Select Case e.EventName
            Case "AddNew"
                ' No action required. Handled in JobsBindingSource_AddingNew.
            Case "Delete"
                If DeleteConfirm() Then DeleteJob()
            Case "Editing"
                JobSelectionEnabled = Not e.Value
            Case "FilterOff"
                FilterOn = False
            Case "FilterOn"
                FilterOn = True
            Case "Find"
                ' Not implemented. Receives a parameter of type Object from the Navigator
                ' that can be used to search the JobsBindingSource.
            Case "GotoFirst", "GotoNext", "GotoPrev"
                If JobsBindingSource.IsBindingSuspended Then InitialJob = GetAJob.First
            Case "GotoLast"
                If JobsBindingSource.IsBindingSuspended Then InitialJob = GetAJob.Last
            Case "Save"
                JobSelectionEnabled = True
            Case "Undo"
                If PreviousJob IsNot Nothing Then SelectedJob = PreviousJob
                JobSelectionEnabled = True
            Case Else
        End Select
    End Sub

    Private Sub TxtScanDataFile_TextChanged(sender As Object, e As EventArgs) Handles TxtScanDataFile.TextChanged
        Try
            ScanDataImexEnabled = (TxtScanDataFile.Text.Length > 0)
        Catch ex As Exception
            MessageBox.Show("Error selecting scan data file: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class