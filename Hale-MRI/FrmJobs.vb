Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase
Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' This form provides a user inteface for editing Job
''' records and accessing related JobDetail records.
''' </summary>

Partial Public Class FrmJobs
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private Enum JobPosition
        ' Used by the NavigationEventHandler to initially 
        ' select a Job when none is currently selected.
        First = 1
        Last = 2
    End Enum

    Private mAddingNew As Boolean = False               ' Flag indicating whether we're currently adding a new Job.
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
    Private mSelectedJob As Job = Nothing               ' The currently selected Job, if any.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmCustomers As FrmCustomers
    Private mFrmVessels As FrmVessels
    Private mFrmMeasurements As FrmMeasurements
#End Region
#Region "Public Interface"
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
            HandleSelectionChanges = False
            mFilterOn = value
            If mFilterOn AndAlso mFilter IsNot Nothing Then
                FiltersApply()
            ElseIf Not mFilterOn AndAlso mFilter IsNot Nothing Then
                FiltersRemove()
            End If
            If mNavigator IsNot Nothing Then mNavigator.FilterOn = mFilterOn
            HandleSelectionChanges = True
        End Set
    End Property

    Public Function Find(item As Job) As Job
        Dim result As Job = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            CurrentJob = MasterSource.Item(pos)
            result = CurrentJob
        End If
        Return result
    End Function
#End Region
#Region "Private Interface"
    Private Property AddingNew As Boolean
        Get
            Return mAddingNew
        End Get
        Set(value As Boolean)
            mAddingNew = value
            HandleSelectionChanges = mAddingNew
            ComboJobs.Enabled = Not mAddingNew
        End Set
    End Property

    Private Sub AddNewJob()
        ' The add new Job event and database changes are handled by the Navigator, 
        ' but we have to create the new Job object and populate the data from the
        ' form's controls.
        Dim newJob As Job = BindingSourceCurrent(JobsBindingSource)
        newJob.Vessel = CurrentVessel
        newJob.JobNumber = Database.Jobs.Max(Function(j) j.JobNumber) + 1
        Database.Jobs.Add(newJob)
    End Sub

    Protected Overrides Sub BindDataSources()
        If Database IsNot Nothing Then
            ' These DataSources use LocalViews, which are loaded on application
            ' startup, and not expected to change.
            ComboBlades.DataSource = Database.Blades.Local.ToBindingList
            ComboCup.DataSource = Database.Cups.Local.ToBindingList
            ComboLEExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            ComboMaterial.DataSource = Database.Materials.Local.ToBindingList
            ComboRotation.DataSource = Database.Rotations.Local.ToBindingList
            ComboStyle.DataSource = Database.Styles.Local.ToBindingList
            ComboTeExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            ' These DataSources query the database, as they may change while
            ' the application is open.
            EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.OrderBy(Function(e) e.EmployeeName).ToList())
            ComboInspectedBy.DataSource = EmployeesBindingSource.DataSource
            ComboManufacturer.DataSource = New BindingList(Of Manufacturer)(Database.Manufacturers.OrderBy(Function(m) m.ManufacturerName).ToList())
            ' Get the current list of Customers, Vessels and Jobs, and bind
            ' Jobs (master) to JobDetails (details).
            FiltersRemove()
            BindMasterDetails(JobsBindingSource, JobDetailsBindingSource, "JobDetails")
            HandleSelectionChanges = True
        End If
        SelectedJob = Nothing
    End Sub

    Private Property CurrentCustomer As Customer
        Get
            Return ComboCustomers.SelectedItem
        End Get
        Set(value As Customer)
            ComboCustomers.SelectedItem = value
        End Set
    End Property

    Private Property CurrentJob As Job
        Get
            Return ComboJobs.SelectedItem
        End Get
        Set(value As Job)
            ComboJobs.SelectedItem = value
        End Set
    End Property

    Private Property CurrentVessel As Vessel
        Get
            Return ComboVessels.SelectedItem
        End Get
        Set(value As Vessel)
            ComboVessels.SelectedItem = value
        End Set
    End Property

    Private Function DeleteConfirm() As Boolean
        Return (MessageBox.Show($"Delete job {CurrentJob.JobNumber}?", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK)
    End Function

    Private Sub FilterByCustomer()
        ' Filter the vessels drop down to include only the currently selected Customer's Vessels.
        CurrentVessel = Nothing ' Blank the currently selected vessel in case the current Customer has no Vessels.
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.Local.Where(Function(v) v.Customer Is CurrentCustomer).ToList())
        ' The first Customer Vessel, if any, should now be selected.
        FilterByVessel()
    End Sub

    Private Sub FilterByJob()
        ' Currently not used.
    End Sub

    Private Sub FilterByVessel()
        ' Filter the jobs drop down to include only the currently selected Vessel's Jobs.
        CurrentJob = Nothing    ' Blank the currently selected job in case the current Vessel has no Jobs.
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.Where(Function(j) j.Vessel Is CurrentVessel).ToList())
        ' The JobsBindingSource index pointer doesn't change, even when requeried. So it will select the
        ' Nth Job in the list, even though the list may have changed. We want the currently selected Job
        ' to remain selected, not the possibly different Job at the old index:
        If CurrentVessel IsNot Nothing AndAlso CurrentVessel IsNot SelectedJob?.Vessel Then
            JobsBindingSource.MoveFirst()
            SelectedJob = CurrentJob
        End If
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
        ' Filtering changes the Customers, Vessels and Jobs lists, but
        ' we don't want the current selections to change, unless there
        ' are no current selections or a list becomes empty:
        If JobsBindingSource.Count = 0 Then
            SelectedJob = Nothing
        ElseIf SelectedJob Is Nothing Then
            SelectedJob = CurrentJob
        ElseIf CurrentJob IsNot SelectedJob Then
            CurrentJob = SelectedJob
        End If
    End Sub

    Private Sub FiltersRemove()
        ' Save the currently selected Customer, Vessel and Job.
        Dim currJob As Job = CurrentJob
        Dim currVessel As Vessel = CurrentVessel
        Dim currCustomer As Customer = CurrentCustomer
        ' Blank the associated controls.
        ShowCurrent(Nothing, Nothing, Nothing)
        ' Get current lists of Customers, Vessels and Jobs from the database.
        ComboCustomers.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.OrderBy(Function(v) v.VesselName).ToList())
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.OrderBy(Function(j) j.JobNumber).ToList())
        ' Show the previously selected Customer, Vessel and Job.
        ShowCurrent(currCustomer, currVessel, currJob)
    End Sub

    Private WriteOnly Property HandleSelectionChanges As Boolean
        Set(value As Boolean)
            Static handled As Boolean
            If value <> handled Then
                If value Then
                    AddHandler ComboVessels.SelectedIndexChanged, AddressOf ComboVessels_SelectedIndexChanged
                    AddHandler ComboJobs.SelectedIndexChanged, AddressOf ComboJobs_SelectedIndexChanged
                Else
                    RemoveHandler ComboJobs.SelectedIndexChanged, AddressOf ComboJobs_SelectedIndexChanged
                    RemoveHandler ComboVessels.SelectedIndexChanged, AddressOf ComboVessels_SelectedIndexChanged
                End If
                handled = value
            End If
        End Set
    End Property

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

    Private Sub SaveChanges()
        ' Database changes are handled by the Navigator, but the special case of
        ' adding a new Job has additional steps that are taken here.
        If AddingNew Then
            AddNewJob()
            AddingNew = False
        End If
    End Sub

    Private WriteOnly Property ScanDataEnabled As Boolean
        Set(value As Boolean)
            CmdScanDataImport.Enabled = value
            CmdScanDataExport.Enabled = value
        End Set
    End Property

    Private Sub ScanDataExport()

    End Sub
    Private Sub ScanDataImport()
        ' Import scan data from a file, add it to the database and show the job details.
        Dim importedJob As Job = Imex.ScanDataImport(TxtScanDataFile.Text)
        If importedJob Is Nothing Then
            ' If no job was created, show an error message.
            MessageBox.Show("No job was created from the scan data file because it is corrupted or missing required data.", STR_TITLE_DEFAULT, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' ScanDataAdd will generate a unique JobNumber.
        importedJob = ScanDataAdd(importedJob, Database)
        Database.SaveChanges()
        ' After saving, we need to refresh the JobsBindingSource.
        If FilterOn Then
            FilterOn = False
        Else
            FiltersRemove()
        End If
        ' Show the imported Job.
        CurrentJob = importedJob
    End Sub

    Private Sub ScanDataPick()
        Dim ofd As New OpenFileDialog With {
            .Title = "Select ScanData File",
            .Filter = "ScanData Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        }
        If ofd.ShowDialog() = DialogResult.OK Then TxtScanDataFile.Text = ofd.FileName
    End Sub

    Private Sub SelectJob(ByVal pos As JobPosition)
        ' When the form first opens nothing is selected and all Job controls are disabled.
        ' Selections from the Customers, Vessels and Jobs drop downs are handled by their
        ' respective SelectionChangeCommitted events. When an initial selection is made
        ' from the Navigator (which is unaware of this form's state), those events won't
        ' fire and we have to make the selection here.
        HandleSelectionChanges = True
        JobsBindingSource.ResumeBinding()
        Select Case pos
            Case JobPosition.First
                JobsBindingSource.MoveFirst()
            Case JobPosition.Last
                JobsBindingSource.MoveLast()
            Case Else
        End Select
        SelectedJob = BindingSourceCurrent(JobsBindingSource)
        CurrentVessel = SelectedJob?.Vessel
        Navigator.ShowPosition()
    End Sub

    Private Property SelectedJob As Job
        Get
            Return mSelectedJob
        End Get
        Set(value As Job)
            mSelectedJob = value
            ' If a Job is selected, enable the controls and display the Job and 
            ' any JobDetails data, else blank and disable the associated controls.
            If mSelectedJob IsNot Nothing Then
                JobsBindingSource.ResumeBinding()
                If CurrentJob IsNot SelectedJob Then CurrentJob = SelectedJob
                DataGridJobDetails.DataSource = JobDetailsBindingSource
            Else
                JobsBindingSource.SuspendBinding()
                DataGridJobDetails.DataSource = Nothing
            End If
        End Set
    End Property

    Private Sub ShowCurrent(selectedCustomer As Customer, selectedVessel As Vessel, selectedJob As Job)
        ' Convenience method to display all three current selections at once.
        CurrentCustomer = selectedCustomer
        CurrentVessel = selectedVessel
        CurrentJob = selectedJob
    End Sub

    Private Sub UndoChanges()
        ' The undo event and database updates are handled by the Navigator.
        ' Here, we handle any changes required to the form's controls as a
        ' result of the undo.
        If AddingNew Then
            AddingNew = False
            CurrentJob = SelectedJob
        End If
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub CmdScanDataImport_Click(sender As Object, e As EventArgs) Handles CmdScanDataImport.Click
        ScanDataImport()
    End Sub

    Private Sub CmdScanDataExport_Click(sender As Object, e As EventArgs) Handles CmdScanDataExport.Click
        ScanDataExport()
    End Sub

    Private Sub CmdScanDataPick_Click(sender As Object, e As EventArgs) Handles CmdScanDataPick.Click
        ScanDataPick()
    End Sub

    Private Sub DataGridJobDetails_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridJobDetails.CellMouseDoubleClick
        ShowForm(mFrmMeasurements, Database)
        mFrmMeasurements.JobDetails = BindingSourceCurrent(JobDetailsBindingSource)
    End Sub

    Protected Overrides Sub FrmDatabaseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' For some reason the base class method doesn't prevent the DataGridJobDetails
        ' from throwing an exception when we're closing, so do this:
        DataGridJobDetails.DataSource = Nothing
        MasterSource.SuspendBinding()
        MyBase.FrmDatabaseForm_FormClosing(sender, e)
    End Sub

    Private Sub FrmJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridJobDetails.AutoGenerateColumns = False
        Navigator = RecordNavigationBar1
        Navigator.Caption = ""
        Navigator.Left = DataGridJobDetails.Left - Navigator.Margin.Left
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
        MasterSource = JobsBindingSource
        AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
    End Sub

    Private Sub JobsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobsBindingSource.AddingNew
        AddingNew = True
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Select Case e.EventName
            Case "Delete"
                If DeleteConfirm() Then
                    Dim v As Vessel = CurrentVessel ' Save the current Vessel in case this is it's only Job, which would blank it after deleting the Job.
                    BindingSourceRemove(Database, JobsBindingSource, Database.Jobs)
                    If JobsBindingSource.Count = 0 Then CurrentVessel = v   ' If no Jobs remain for the current Vessel, restore it.
                End If
            Case "FilterOff"
                FilterOn = False
            Case "FilterOn"
                FilterOn = True
            Case "Find"
                ' Not implemented. Receives a parameter of type Object from the Navigator
                ' that can be used to search the JobsBindingSource.
            Case "GotoFirst", "GotoNext", "GotoPrev"
                If JobsBindingSource.IsBindingSuspended Then SelectJob(JobPosition.First)
                Navigator.ControlsEnable()
            Case "GotoLast"
                If JobsBindingSource.IsBindingSuspended Then SelectJob(JobPosition.Last)
                Navigator.ControlsEnable()
            Case "Save"
                SaveChanges()
            Case "Undo"
                UndoChanges()
            Case Else
        End Select
    End Sub

    Private Sub TxtScanDataFile_TextChanged(sender As Object, e As EventArgs) Handles TxtScanDataFile.TextChanged
        ScanDataEnabled = (TxtScanDataFile.Text.Length > 0)
    End Sub
#End Region
    ''' <summary>
    ''' Event handlers for the Customers, Vessels and Jobs combo boxes.
    ''' These handle auto-completes, selection changes and double-clicks 
    ''' and apply the appropriate filters and to open the associated form
    ''' for the selected record.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
#Region "ComboCustomers Event Handlers"
    Private Sub ComboCustomers_Enter(sender As Object, e As EventArgs) Handles ComboCustomers.Enter
        AddHandler ComboCustomers.SelectedValueChanged, AddressOf ComboCustomers_SelectedValueChanged
    End Sub
    Private Sub ComboCustomers_Leave(sender As Object, e As EventArgs) Handles ComboCustomers.Leave
        RemoveHandler ComboCustomers.SelectedValueChanged, AddressOf ComboCustomers_SelectedValueChanged
    End Sub

    Private Sub ComboCustomers_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboCustomers.MouseClick
        If ComboDoubleClick() Then
            Dim c As Customer = CurrentCustomer
            If c IsNot Nothing Then
                ShowForm(mFrmCustomers, Database)
                mFrmCustomers.Find(c)
            End If
        End If
    End Sub

    Private Sub ComboCustomers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboCustomers.SelectionChangeCommitted
        Filter = CurrentCustomer
    End Sub

    Private Sub ComboCustomers_SelectedValueChanged(sender As Object, e As EventArgs)
        Filter = CurrentCustomer
    End Sub
#End Region
#Region "ComboJobs Event Handlers"
    Private Sub ComboJobs_MouseClick(sender As Object, e As EventArgs) Handles ComboJobs.MouseClick
        If ComboDoubleClick() Then
            Dim j As Job = BindingSourceCurrent(JobsBindingSource)
            If j IsNot Nothing Then
                ShowForm(mFrmMeasurements, Database)
                mFrmMeasurements.Job = j
            End If
        End If
    End Sub
    Private Sub ComboJobs_SelectedIndexChanged(sender As Object, e As EventArgs)
        HandleSelectionChanges = False
        SelectedJob = CurrentJob
        HandleSelectionChanges = True
        CurrentVessel = SelectedJob?.Vessel
    End Sub
#End Region
#Region "ComboVessels Event Handlers"
    Private Sub ComboVessels_Enter(sender As Object, e As EventArgs) Handles ComboVessels.Enter
        AddHandler ComboVessels.SelectedValueChanged, AddressOf ComboVessels_SelectedValueChanged
    End Sub

    Private Sub ComboVessels_Leave(sender As Object, e As EventArgs) Handles ComboVessels.Leave
        RemoveHandler ComboVessels.SelectedValueChanged, AddressOf ComboVessels_SelectedValueChanged
    End Sub

    Private Sub ComboVessels_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboVessels.MouseClick
        If ComboDoubleClick() Then
            Dim v As Vessel = CurrentVessel
            If v IsNot Nothing Then
                ShowForm(mFrmVessels, Database)
                mFrmVessels.Find(v)
            End If
        End If
    End Sub

    Private Sub ComboVessels_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboVessels.SelectionChangeCommitted
        Filter = CurrentVessel
    End Sub

    Private Sub ComboVessels_SelectedIndexChanged(sender As Object, e As EventArgs)
        CurrentCustomer = CurrentVessel?.Customer
    End Sub

    Private Sub ComboVessels_SelectedValueChanged(sender As Object, e As EventArgs)
        Filter = CurrentVessel
    End Sub
#End Region
End Class