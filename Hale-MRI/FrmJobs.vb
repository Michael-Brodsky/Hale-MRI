Imports System.ComponentModel
Imports System.Reflection.Metadata.Ecma335
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase
Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmJobs
    Inherits FrmDatabaseForm

    Private Enum JobPosition
        First = 1
        Last = 2
    End Enum
    Private mAddingNew As Boolean = False
    Private mBoundControls As List(Of Control) = Nothing
    Private mFilter As Object = Nothing
    Private mFilterOn As Boolean = False
    Private mSelectedJob As Job = Nothing

    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            BindDataSources()
        End Set
    End Property

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
            If mFilterOn <> value Then
                mFilterOn = value
                HandleSelectionChanges = False
                If mFilterOn AndAlso mFilter IsNot Nothing Then
                    FiltersApply()
                ElseIf Not mFilterOn AndAlso mFilter IsNot Nothing Then
                    FiltersRemove()
                End If
                Navigator.FilterOn = mFilterOn
                HandleSelectionChanges = True
            End If
        End Set
    End Property

    Public Function Find(ByVal j As Job) As Job
        Dim result As Job = MyBase.FindEntity(EntityClass, j?.Id)
        If result IsNot Nothing Then CurrentJob = result
        Return result
    End Function

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
        Dim newJob As Job = BindingSourceCurrent(JobsBindingSource)
        newJob.Vessel = CurrentVessel
        newJob.JobNumber = Database.Jobs.Max(Function(j) j.JobNumber) + 1
        Database.Jobs.Add(newJob)
    End Sub

    Private Sub BindDataSources()
        If Database IsNot Nothing Then
            FiltersRemove()
            EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList
            ComboBlades.DataSource = Database.Blades.Local.ToBindingList
            ComboCup.DataSource = Database.Cups.Local.ToBindingList
            ComboInspectedBy.DataSource = EmployeesBindingSource.DataSource 'Database.Employees.Local.ToBindingList
            ComboLEExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            ComboManufacturer.DataSource = Database.Manufacturers.Local.ToBindingList
            ComboMaterial.DataSource = Database.Materials.Local.ToBindingList
            ComboRotation.DataSource = Database.Rotations.Local.ToBindingList
            ComboStyle.DataSource = Database.Styles.Local.ToBindingList
            ComboTeExclusion.DataSource = Database.Exclusions.Local.ToBindingList
            BindMasterDetails(JobsBindingSource, JobDetailsBindingSource, "JobDetails")
            HandleSelectionChanges = True
        End If
        SelectedJob = Nothing
    End Sub

    Private Property BoundControls As List(Of Control)
        Get
            Return mBoundControls
        End Get
        Set(controls As List(Of Control))
            If controls IsNot Nothing Then
                For Each ctrl In controls
                    Select Case True
                        Case TypeOf ctrl Is TextBox
                            AddHandler CType(ctrl, TextBox).TextChanged, AddressOf Bound_TextChanged
                        Case TypeOf ctrl Is ComboBox
                            AddHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf Bound_SelectionChangeCommitted
                        Case TypeOf ctrl Is CheckBox
                            AddHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf Bound_CheckChanged
                        Case Else
                            ' Handle other control types if necessary.
                    End Select
                Next
            End If
            mBoundControls = controls
        End Set
    End Property

    Private WriteOnly Property BoundControlsEnabled As Boolean
        Set(value As Boolean)
            If mBoundControls IsNot Nothing Then
                For Each ctrl In mBoundControls
                    ctrl.Enabled = value
                Next
            End If
        End Set
    End Property

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

    Private Sub FilterByCustomer()
        CurrentVessel = Nothing
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.Local.Where(Function(v) v.Customer Is CType(ComboCustomers.SelectedItem, Customer)).ToList())
        FilterByVessel()
    End Sub

    Private Sub FilterByJob()
        ' Currently not used.
    End Sub

    Private Sub FilterByVessel()
        CurrentJob = Nothing
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.Where(Function(j) j.Vessel Is CType(ComboVessels.SelectedItem, Vessel)).ToList())
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
        If JobsBindingSource.Count = 0 Then
            SelectedJob = Nothing
        ElseIf SelectedJob Is Nothing Then
            SelectedJob = CurrentJob
        ElseIf CurrentJob IsNot SelectedJob Then
            CurrentJob = SelectedJob
        End If
    End Sub

    Private Sub FiltersRemove()
        Dim currJob As Job = CurrentJob
        Dim currVessel As Vessel = CurrentVessel
        Dim currCustomer As Customer = CurrentCustomer
        ShowCurrent(Nothing, Nothing, Nothing)
        ComboCustomers.DataSource = New BindingList(Of Customer)(Database.Customers.OrderBy(Function(c) c.CustomerName).ToList())
        ComboVessels.DataSource = New BindingList(Of Vessel)(Database.Vessels.OrderBy(Function(v) v.VesselName).ToList())
        JobsBindingSource.DataSource = New BindingList(Of Job)(Database.Jobs.Local.OrderBy(Function(j) j.JobNumber).ToList())
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

    Private Sub SaveChanges()
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
            If mSelectedJob IsNot Nothing Then
                JobsBindingSource.ResumeBinding()
                If CurrentJob IsNot SelectedJob Then CurrentJob = SelectedJob
                BoundControlsEnabled = True
                DataGridJobDetails.DataSource = JobDetailsBindingSource
            Else
                JobsBindingSource.SuspendBinding()
                BoundControlsEnabled = False
                DataGridJobDetails.DataSource = Nothing
            End If
        End Set
    End Property

    Private Sub ShowCurrent(selectedCustomer As Customer, selectedVessel As Vessel, selectedJob As Job)
        CurrentCustomer = selectedCustomer
        CurrentVessel = selectedVessel
        CurrentJob = selectedJob
    End Sub

    Private Sub UndoChanges()
        If AddingNew Then
            AddingNew = False
            CurrentJob = SelectedJob
        End If
    End Sub

    Private Sub Bound_CheckChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Bound_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If cmb.SelectedIndex <> kNoCurrentSelection Then

        End If
    End Sub
    Private Sub Bound_TextChanged(sender As Object, e As EventArgs)
        Dim txtbox As TextBox = CType(sender, TextBox)
        If txtbox.Modified Then
            ' If the TextBox control's text has been modified, set the edit mode to SaveUndo.
            txtbox.Modified = False ' Reset the modified state to prevent repeated triggering.
        End If
    End Sub

    Private Sub CmdScanDataImport_Click(sender As Object, e As EventArgs) Handles CmdScanDataImport.Click
        ScanDataImport()
    End Sub

    Private Sub CmdScanDataExport_Click(sender As Object, e As EventArgs) Handles CmdScanDataExport.Click
        ScanDataExport()
    End Sub
    Private Sub CmdScanDataPick_Click(sender As Object, e As EventArgs) Handles CmdScanDataPick.Click
        ScanDataPick()
    End Sub

    Private Sub ComboCustomers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboCustomers.SelectionChangeCommitted
        Filter = CurrentCustomer
    End Sub

    Private Sub ComboJobs_SelectedIndexChanged(sender As Object, e As EventArgs)
        HandleSelectionChanges = False
        SelectedJob = CurrentJob
        HandleSelectionChanges = True
        CurrentVessel = SelectedJob?.Vessel
    End Sub

    Private Sub ComboVessels_SelectedIndexChanged(sender As Object, e As EventArgs)
        CurrentCustomer = CurrentVessel?.Customer
    End Sub

    Private Sub ComboVessels_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboVessels.SelectionChangeCommitted
        Filter = CurrentVessel
    End Sub

    Private Sub FrmJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridJobDetails.AutoGenerateColumns = False
        Navigator = RecordNavigationBar1
        Navigator.Caption = ""
        EntityClass = Database.Jobs
        DataSource = JobsBindingSource
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
        AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
        Find(Database.Jobs.FirstOrDefault())
        'BoundControlsEnabled = (SelectedJob IsNot Nothing)
    End Sub

    Private Sub JobsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobsBindingSource.AddingNew
        AddingNew = True
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        Select Case e.EventName
            Case "Delete"

            Case "FilterOff"
                FilterOn = False
            Case "FilterOn"
                FilterOn = True
            Case "Find"
            Case "GotoFirst", "GotoNext", "GotoPrev"
                If JobsBindingSource.IsBindingSuspended Then SelectJob(JobPosition.First)
            Case "GotoLast"
                If JobsBindingSource.IsBindingSuspended Then SelectJob(JobPosition.Last)
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
End Class