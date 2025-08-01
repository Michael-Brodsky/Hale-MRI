<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
    Inherits FrmDatabaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        ComboCustomers = New ComboBox()
        CustomerBindingSource = New BindingSource(components)
        ComboVessels = New ComboBox()
        VesselBindingSource = New BindingSource(components)
        ComboJobs = New ComboBox()
        JobBindingSource = New BindingSource(components)
        LabCustomer = New Label()
        LabVessel = New Label()
        LabJob = New Label()
        CmdSearchClear = New Button()
        JobDetailsBindingSource = New BindingSource(components)
        EmployeesBindingSource = New BindingSource(components)
        ManufacturersBindingSource = New BindingSource(components)
        BladesBindingSource = New BindingSource(components)
        MaterialsBindingSource = New BindingSource(components)
        StylesBindingSource = New BindingSource(components)
        labJobsJobDetailsTitle = New Label()
        DataGridJobDetails = New DataGridView()
        StartDateDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        DescriptionDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        ToolTip1 = New ToolTip(components)
        TxtPartNumber = New TextBox()
        TxtSerialNumber = New TextBox()
        TxtStampNumber = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        LabInspectedBy = New Label()
        LabDesiredPitch = New Label()
        LabMarkedPitch = New Label()
        LabDiameter = New Label()
        TxtDesiredPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        TxtDiameter = New TextBox()
        ComboInspectedBy = New ComboBox()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ComboCustomers
        ' 
        ComboCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboCustomers.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboCustomers.DataSource = CustomerBindingSource
        ComboCustomers.DisplayMember = "CustomerName"
        ComboCustomers.FormattingEnabled = True
        ComboCustomers.Location = New Point(133, 42)
        ComboCustomers.Name = "ComboCustomers"
        ComboCustomers.Size = New Size(190, 23)
        ComboCustomers.TabIndex = 0
        ToolTip1.SetToolTip(ComboCustomers, "Search by customer name")
        ComboCustomers.ValueMember = "Id"
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' ComboVessels
        ' 
        ComboVessels.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboVessels.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboVessels.DataSource = VesselBindingSource
        ComboVessels.DisplayMember = "VesselName"
        ComboVessels.FormattingEnabled = True
        ComboVessels.Location = New Point(133, 102)
        ComboVessels.Name = "ComboVessels"
        ComboVessels.Size = New Size(190, 23)
        ComboVessels.TabIndex = 1
        ToolTip1.SetToolTip(ComboVessels, "Search by Vessel name")
        ComboVessels.ValueMember = "Id"
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' ComboJobs
        ' 
        ComboJobs.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboJobs.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboJobs.DataSource = JobBindingSource
        ComboJobs.DisplayMember = "JobNumber"
        ComboJobs.FormattingEnabled = True
        ComboJobs.Location = New Point(133, 162)
        ComboJobs.Name = "ComboJobs"
        ComboJobs.Size = New Size(190, 23)
        ComboJobs.TabIndex = 2
        ToolTip1.SetToolTip(ComboJobs, "Search by job number")
        ComboJobs.ValueMember = "Id"
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' LabCustomer
        ' 
        LabCustomer.AutoSize = True
        LabCustomer.Location = New Point(68, 45)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(59, 15)
        LabCustomer.TabIndex = 3
        LabCustomer.Text = "Customer"
        ' 
        ' LabVessel
        ' 
        LabVessel.AutoSize = True
        LabVessel.Location = New Point(68, 104)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(38, 15)
        LabVessel.TabIndex = 4
        LabVessel.Text = "Vessel"
        ' 
        ' LabJob
        ' 
        LabJob.AutoSize = True
        LabJob.Location = New Point(68, 166)
        LabJob.Name = "LabJob"
        LabJob.Size = New Size(25, 15)
        LabJob.TabIndex = 5
        LabJob.Text = "Job"
        ' 
        ' CmdSearchClear
        ' 
        CmdSearchClear.Image = My.Resources.Resources.ClearWindowContent
        CmdSearchClear.Location = New Point(133, 220)
        CmdSearchClear.Name = "CmdSearchClear"
        CmdSearchClear.Size = New Size(67, 24)
        CmdSearchClear.TabIndex = 6
        ToolTip1.SetToolTip(CmdSearchClear, "Clear search criteria")
        CmdSearchClear.UseVisualStyleBackColor = True
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        ' 
        ' ManufacturersBindingSource
        ' 
        ManufacturersBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ' 
        ' BladesBindingSource
        ' 
        BladesBindingSource.DataSource = GetType(LibDatabase.Models.Blade)
        ' 
        ' MaterialsBindingSource
        ' 
        MaterialsBindingSource.DataSource = GetType(LibDatabase.Models.Material)
        ' 
        ' StylesBindingSource
        ' 
        StylesBindingSource.DataSource = GetType(LibDatabase.Models.Style)
        ' 
        ' labJobsJobDetailsTitle
        ' 
        labJobsJobDetailsTitle.AutoSize = True
        labJobsJobDetailsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labJobsJobDetailsTitle.Location = New Point(530, 336)
        labJobsJobDetailsTitle.Margin = New Padding(0, 0, 2, 1)
        labJobsJobDetailsTitle.Name = "labJobsJobDetailsTitle"
        labJobsJobDetailsTitle.Size = New Size(86, 20)
        labJobsJobDetailsTitle.TabIndex = 7
        labJobsJobDetailsTitle.Text = "Job Details"
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridJobDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDateDataGridViewTextBoxColumn1, PerformedBy, DescriptionDataGridViewTextBoxColumn1})
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Location = New Point(530, 357)
        DataGridJobDetails.Margin = New Padding(0)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ReadOnly = True
        DataGridJobDetails.RowHeadersWidth = 82
        DataGridJobDetails.Size = New Size(903, 265)
        DataGridJobDetails.TabIndex = 8
        ' 
        ' StartDateDataGridViewTextBoxColumn1
        ' 
        StartDateDataGridViewTextBoxColumn1.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn1.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn1.MinimumWidth = 10
        StartDateDataGridViewTextBoxColumn1.Name = "StartDateDataGridViewTextBoxColumn1"
        StartDateDataGridViewTextBoxColumn1.ReadOnly = True
        StartDateDataGridViewTextBoxColumn1.Width = 200
        ' 
        ' PerformedBy
        ' 
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeesBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        PerformedBy.HeaderText = "Performed By"
        PerformedBy.MinimumWidth = 10
        PerformedBy.Name = "PerformedBy"
        PerformedBy.ReadOnly = True
        PerformedBy.ValueMember = "Id"
        PerformedBy.Width = 120
        ' 
        ' DescriptionDataGridViewTextBoxColumn1
        ' 
        DescriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn1.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn1.MinimumWidth = 500
        DescriptionDataGridViewTextBoxColumn1.Name = "DescriptionDataGridViewTextBoxColumn1"
        DescriptionDataGridViewTextBoxColumn1.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn1.Width = 500
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.Location = New Point(530, 42)
        TxtPartNumber.Name = "TxtPartNumber"
        TxtPartNumber.Size = New Size(144, 23)
        TxtPartNumber.TabIndex = 9
        ' 
        ' TxtSerialNumber
        ' 
        TxtSerialNumber.Location = New Point(530, 102)
        TxtSerialNumber.Name = "TxtSerialNumber"
        TxtSerialNumber.Size = New Size(144, 23)
        TxtSerialNumber.TabIndex = 10
        ' 
        ' TxtStampNumber
        ' 
        TxtStampNumber.Location = New Point(530, 162)
        TxtStampNumber.Name = "TxtStampNumber"
        TxtStampNumber.Size = New Size(144, 23)
        TxtStampNumber.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(431, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 15)
        Label1.TabIndex = 12
        Label1.Text = "Part Number"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(431, 105)
        Label2.Name = "Label2"
        Label2.Size = New Size(82, 15)
        Label2.TabIndex = 13
        Label2.Text = "Serial Number"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(431, 165)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 15)
        Label3.TabIndex = 14
        Label3.Text = "Stamp Number"
        ' 
        ' LabInspectedBy
        ' 
        LabInspectedBy.AutoSize = True
        LabInspectedBy.Location = New Point(431, 225)
        LabInspectedBy.Name = "LabInspectedBy"
        LabInspectedBy.Size = New Size(74, 15)
        LabInspectedBy.TabIndex = 16
        LabInspectedBy.Text = "Inspected By"
        ' 
        ' LabDesiredPitch
        ' 
        LabDesiredPitch.AutoSize = True
        LabDesiredPitch.Location = New Point(739, 165)
        LabDesiredPitch.Name = "LabDesiredPitch"
        LabDesiredPitch.Size = New Size(76, 15)
        LabDesiredPitch.TabIndex = 22
        LabDesiredPitch.Text = "Desired Pitch"
        ' 
        ' LabMarkedPitch
        ' 
        LabMarkedPitch.AutoSize = True
        LabMarkedPitch.Location = New Point(739, 105)
        LabMarkedPitch.Name = "LabMarkedPitch"
        LabMarkedPitch.Size = New Size(77, 15)
        LabMarkedPitch.TabIndex = 21
        LabMarkedPitch.Text = "Marked Pitch"
        ' 
        ' LabDiameter
        ' 
        LabDiameter.AutoSize = True
        LabDiameter.Location = New Point(739, 45)
        LabDiameter.Name = "LabDiameter"
        LabDiameter.Size = New Size(55, 15)
        LabDiameter.TabIndex = 20
        LabDiameter.Text = "Diameter"
        ' 
        ' TxtDesiredPitch
        ' 
        TxtDesiredPitch.Location = New Point(838, 162)
        TxtDesiredPitch.Name = "TxtDesiredPitch"
        TxtDesiredPitch.Size = New Size(144, 23)
        TxtDesiredPitch.TabIndex = 19
        ' 
        ' TxtMarkedPitch
        ' 
        TxtMarkedPitch.Location = New Point(838, 102)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.Size = New Size(144, 23)
        TxtMarkedPitch.TabIndex = 18
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.Location = New Point(838, 42)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.Size = New Size(144, 23)
        TxtDiameter.TabIndex = 17
        ' 
        ' ComboInspectedBy
        ' 
        ComboInspectedBy.DataSource = EmployeesBindingSource
        ComboInspectedBy.DisplayMember = "EmployeeName"
        ComboInspectedBy.FormattingEnabled = True
        ComboInspectedBy.Location = New Point(529, 222)
        ComboInspectedBy.Name = "ComboInspectedBy"
        ComboInspectedBy.Size = New Size(145, 23)
        ComboInspectedBy.TabIndex = 23
        ComboInspectedBy.ValueMember = "Id"
        ' 
        ' FrmSearch
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1468, 692)
        Controls.Add(ComboInspectedBy)
        Controls.Add(LabDesiredPitch)
        Controls.Add(LabMarkedPitch)
        Controls.Add(LabDiameter)
        Controls.Add(TxtDesiredPitch)
        Controls.Add(TxtMarkedPitch)
        Controls.Add(TxtDiameter)
        Controls.Add(LabInspectedBy)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TxtStampNumber)
        Controls.Add(TxtSerialNumber)
        Controls.Add(TxtPartNumber)
        Controls.Add(labJobsJobDetailsTitle)
        Controls.Add(DataGridJobDetails)
        Controls.Add(CmdSearchClear)
        Controls.Add(LabJob)
        Controls.Add(LabVessel)
        Controls.Add(LabCustomer)
        Controls.Add(ComboJobs)
        Controls.Add(ComboVessels)
        Controls.Add(ComboCustomers)
        Name = "FrmSearch"
        Text = "Jobs"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboCustomers As ComboBox
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents ComboVessels As ComboBox
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents ComboJobs As ComboBox
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents LabCustomer As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabJob As Label
    Friend WithEvents CmdSearchClear As Button
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents BladesBindingSource As BindingSource
    Friend WithEvents MaterialsBindingSource As BindingSource
    Friend WithEvents StylesBindingSource As BindingSource
    Friend WithEvents labJobsJobDetailsTitle As Label
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents StartDateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents TxtStampNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LabInspectedBy As Label
    Friend WithEvents LabDesiredPitch As Label
    Friend WithEvents LabMarkedPitch As Label
    Friend WithEvents LabDiameter As Label
    Friend WithEvents TxtDesiredPitch As TextBox
    Friend WithEvents TxtMarkedPitch As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents ComboInspectedBy As ComboBox
End Class
