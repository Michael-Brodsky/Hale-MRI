<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobs
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJobs))
        CustomerBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        JobDetailsBindingSource = New BindingSource(components)
        EmployeesBindingSource = New BindingSource(components)
        ManufacturersBindingSource = New BindingSource(components)
        BladesBindingSource = New BindingSource(components)
        MaterialsBindingSource = New BindingSource(components)
        StylesBindingSource = New BindingSource(components)
        ToolTip1 = New ToolTip(components)
        ComboJobs = New ComboBox()
        JobBindingSource = New BindingSource(components)
        ComboVessels = New ComboBox()
        ComboCustomers = New ComboBox()
        CmdFiltersClear = New Button()
        LabJob = New Label()
        LabVessel = New Label()
        LabCustomer = New Label()
        labJobsJobDetailsTitle = New Label()
        DataGridJobDetails = New DataGridView()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ComboManufacturer = New ComboBox()
        ComboStyle = New ComboBox()
        ComboMaterial = New ComboBox()
        TxtDiameter = New TextBox()
        ComboBore = New ComboBox()
        ComboCup = New ComboBox()
        ComboRotation = New ComboBox()
        RotationBindingSource = New BindingSource(components)
        ComboBlades = New ComboBox()
        ComboTeExclusion = New ComboBox()
        ComboLEExclusion = New ComboBox()
        ExclusionsBindingSource = New BindingSource(components)
        TxtDAR = New TextBox()
        LabPartNumber = New Label()
        TxtSerialNumber = New TextBox()
        LabManufacturer = New Label()
        LabStyle = New Label()
        LabMaterial = New Label()
        LabRotation = New Label()
        LabBlades = New Label()
        LabDiameter = New Label()
        Label1 = New Label()
        LabSerialNumber = New Label()
        LabStampNumber = New Label()
        TxtStampNumber = New TextBox()
        TxtPartNumber = New TextBox()
        ComboInspectedBy = New ComboBox()
        LabBore = New Label()
        LabLEExclusion = New Label()
        LabTEExclusion = New Label()
        LabDAR = New Label()
        LabCup = New Label()
        RecordNavigationBar1 = New RecordNavigationBar()
        CupBindingSource = New BindingSource(components)
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(RotationBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExclusionsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CupBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        CustomerBindingSource.Sort = ""
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        VesselBindingSource.Sort = ""
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        JobDetailsBindingSource.Sort = "StartDate ASC"
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeesBindingSource.Sort = ""
        ' 
        ' ManufacturersBindingSource
        ' 
        ManufacturersBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ManufacturersBindingSource.Sort = ""
        ' 
        ' BladesBindingSource
        ' 
        BladesBindingSource.DataSource = GetType(LibDatabase.Models.Blade)
        ' 
        ' MaterialsBindingSource
        ' 
        MaterialsBindingSource.DataSource = GetType(LibDatabase.Models.Material)
        MaterialsBindingSource.Sort = ""
        ' 
        ' StylesBindingSource
        ' 
        StylesBindingSource.DataSource = GetType(LibDatabase.Models.Style)
        ' 
        ' ComboJobs
        ' 
        ComboJobs.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboJobs.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboJobs.DataSource = JobBindingSource
        ComboJobs.DisplayMember = "JobNumber"
        ComboJobs.Font = New Font("Segoe UI", 9F)
        ComboJobs.FormattingEnabled = True
        ComboJobs.Location = New Point(106, 189)
        ComboJobs.Name = "ComboJobs"
        ComboJobs.Size = New Size(190, 23)
        ComboJobs.TabIndex = 13
        ToolTip1.SetToolTip(ComboJobs, "Search by job number")
        ComboJobs.ValueMember = "Id"
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        JobBindingSource.Sort = ""
        ' 
        ' ComboVessels
        ' 
        ComboVessels.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboVessels.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboVessels.DataSource = VesselBindingSource
        ComboVessels.DisplayMember = "VesselName"
        ComboVessels.FormattingEnabled = True
        ComboVessels.Location = New Point(106, 129)
        ComboVessels.Name = "ComboVessels"
        ComboVessels.Size = New Size(190, 23)
        ComboVessels.TabIndex = 12
        ToolTip1.SetToolTip(ComboVessels, "Search by Vessel name")
        ComboVessels.ValueMember = "Id"
        ' 
        ' ComboCustomers
        ' 
        ComboCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboCustomers.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboCustomers.DataSource = CustomerBindingSource
        ComboCustomers.DisplayMember = "CustomerName"
        ComboCustomers.FormattingEnabled = True
        ComboCustomers.Location = New Point(106, 69)
        ComboCustomers.Name = "ComboCustomers"
        ComboCustomers.Size = New Size(190, 23)
        ComboCustomers.TabIndex = 11
        ToolTip1.SetToolTip(ComboCustomers, "Search by customer name")
        ComboCustomers.ValueMember = "Id"
        ' 
        ' CmdFiltersClear
        ' 
        CmdFiltersClear.Image = My.Resources.Resources.ClearWindowContent
        CmdFiltersClear.Location = New Point(106, 250)
        CmdFiltersClear.Name = "CmdFiltersClear"
        CmdFiltersClear.Size = New Size(67, 24)
        CmdFiltersClear.TabIndex = 17
        ToolTip1.SetToolTip(CmdFiltersClear, "Clear search criteria")
        CmdFiltersClear.UseVisualStyleBackColor = True
        ' 
        ' LabJob
        ' 
        LabJob.AutoSize = True
        LabJob.Font = New Font("Segoe UI", 9F)
        LabJob.Location = New Point(41, 193)
        LabJob.Name = "LabJob"
        LabJob.Size = New Size(25, 15)
        LabJob.TabIndex = 16
        LabJob.Text = "Job"
        ' 
        ' LabVessel
        ' 
        LabVessel.AutoSize = True
        LabVessel.Location = New Point(41, 131)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(38, 15)
        LabVessel.TabIndex = 15
        LabVessel.Text = "Vessel"
        ' 
        ' LabCustomer
        ' 
        LabCustomer.AutoSize = True
        LabCustomer.Location = New Point(41, 72)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(59, 15)
        LabCustomer.TabIndex = 14
        LabCustomer.Text = "Customer"
        ' 
        ' labJobsJobDetailsTitle
        ' 
        labJobsJobDetailsTitle.AutoSize = True
        labJobsJobDetailsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labJobsJobDetailsTitle.Location = New Point(367, 335)
        labJobsJobDetailsTitle.Margin = New Padding(0, 0, 2, 1)
        labJobsJobDetailsTitle.Name = "labJobsJobDetailsTitle"
        labJobsJobDetailsTitle.Size = New Size(86, 20)
        labJobsJobDetailsTitle.TabIndex = 18
        labJobsJobDetailsTitle.Text = "Job Details"
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridJobDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDateDataGridViewTextBoxColumn, PerformedBy, DescriptionDataGridViewTextBoxColumn})
        DataGridJobDetails.DataSource = JobBindingSource
        DataGridJobDetails.Location = New Point(367, 356)
        DataGridJobDetails.Margin = New Padding(0)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ReadOnly = True
        DataGridJobDetails.RowHeadersWidth = 82
        DataGridJobDetails.Size = New Size(642, 265)
        DataGridJobDetails.TabIndex = 19
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 120
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.ReadOnly = True
        StartDateDataGridViewTextBoxColumn.Width = 120
        ' 
        ' PerformedBy
        ' 
        PerformedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeesBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        PerformedBy.HeaderText = "Performed By"
        PerformedBy.MinimumWidth = 120
        PerformedBy.Name = "PerformedBy"
        PerformedBy.ReadOnly = True
        PerformedBy.ValueMember = "Id"
        PerformedBy.Width = 120
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 120
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn.Width = 120
        ' 
        ' ComboManufacturer
        ' 
        ComboManufacturer.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "ManufacturerId", True))
        ComboManufacturer.DataSource = ManufacturersBindingSource
        ComboManufacturer.DisplayMember = "ManufacturerName"
        ComboManufacturer.FormattingEnabled = True
        ComboManufacturer.Location = New Point(461, 69)
        ComboManufacturer.Name = "ComboManufacturer"
        ComboManufacturer.Size = New Size(190, 23)
        ComboManufacturer.TabIndex = 20
        ComboManufacturer.ValueMember = "Id"
        ' 
        ' ComboStyle
        ' 
        ComboStyle.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "Style", True))
        ComboStyle.DataSource = StylesBindingSource
        ComboStyle.DisplayMember = "Style1"
        ComboStyle.FormattingEnabled = True
        ComboStyle.Location = New Point(461, 127)
        ComboStyle.Name = "ComboStyle"
        ComboStyle.Size = New Size(190, 23)
        ComboStyle.TabIndex = 21
        ComboStyle.ValueMember = "Style1"
        ' 
        ' ComboMaterial
        ' 
        ComboMaterial.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "Material", True))
        ComboMaterial.DataSource = MaterialsBindingSource
        ComboMaterial.DisplayMember = "Material1"
        ComboMaterial.FormattingEnabled = True
        ComboMaterial.Location = New Point(461, 156)
        ComboMaterial.Name = "ComboMaterial"
        ComboMaterial.Size = New Size(190, 23)
        ComboMaterial.TabIndex = 22
        ComboMaterial.ValueMember = "Material1"
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.DataBindings.Add(New Binding("Text", JobBindingSource, "Diameter", True))
        TxtDiameter.Location = New Point(461, 243)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.Size = New Size(190, 23)
        TxtDiameter.TabIndex = 23
        ' 
        ' ComboBore
        ' 
        ComboBore.FormattingEnabled = True
        ComboBore.Location = New Point(461, 272)
        ComboBore.Name = "ComboBore"
        ComboBore.Size = New Size(190, 23)
        ComboBore.TabIndex = 28
        ' 
        ' ComboCup
        ' 
        ComboCup.DataSource = CupBindingSource
        ComboCup.DisplayMember = "Cup1"
        ComboCup.FormattingEnabled = True
        ComboCup.Location = New Point(819, 186)
        ComboCup.Name = "ComboCup"
        ComboCup.Size = New Size(190, 23)
        ComboCup.TabIndex = 29
        ComboCup.ValueMember = "Cup1"
        ' 
        ' ComboRotation
        ' 
        ComboRotation.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "Rotation", True))
        ComboRotation.DataSource = RotationBindingSource
        ComboRotation.DisplayMember = "Rotation1"
        ComboRotation.FormattingEnabled = True
        ComboRotation.Location = New Point(461, 185)
        ComboRotation.Name = "ComboRotation"
        ComboRotation.Size = New Size(190, 23)
        ComboRotation.TabIndex = 30
        ComboRotation.ValueMember = "Rotation1"
        ' 
        ' RotationBindingSource
        ' 
        RotationBindingSource.DataSource = GetType(LibDatabase.Models.Rotation)
        ' 
        ' ComboBlades
        ' 
        ComboBlades.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "Blades", True))
        ComboBlades.DataSource = BladesBindingSource
        ComboBlades.DisplayMember = "BladeCount"
        ComboBlades.FormattingEnabled = True
        ComboBlades.Location = New Point(461, 214)
        ComboBlades.Name = "ComboBlades"
        ComboBlades.Size = New Size(190, 23)
        ComboBlades.TabIndex = 31
        ComboBlades.ValueMember = "BladeCount"
        ' 
        ' ComboTeExclusion
        ' 
        ComboTeExclusion.DataSource = ExclusionsBindingSource
        ComboTeExclusion.DisplayMember = "Exclusion1"
        ComboTeExclusion.FormattingEnabled = True
        ComboTeExclusion.Location = New Point(819, 157)
        ComboTeExclusion.Name = "ComboTeExclusion"
        ComboTeExclusion.Size = New Size(190, 23)
        ComboTeExclusion.TabIndex = 33
        ComboTeExclusion.ValueMember = "Exclusion1"
        ' 
        ' ComboLEExclusion
        ' 
        ComboLEExclusion.DataSource = ExclusionsBindingSource
        ComboLEExclusion.DisplayMember = "Exclusion1"
        ComboLEExclusion.FormattingEnabled = True
        ComboLEExclusion.Location = New Point(819, 128)
        ComboLEExclusion.Name = "ComboLEExclusion"
        ComboLEExclusion.Size = New Size(190, 23)
        ComboLEExclusion.TabIndex = 32
        ComboLEExclusion.ValueMember = "Exclusion1"
        ' 
        ' ExclusionsBindingSource
        ' 
        ExclusionsBindingSource.DataSource = GetType(LibDatabase.Models.Exclusion)
        ' 
        ' TxtDAR
        ' 
        TxtDAR.Location = New Point(819, 214)
        TxtDAR.Name = "TxtDAR"
        TxtDAR.Size = New Size(190, 23)
        TxtDAR.TabIndex = 34
        ' 
        ' LabPartNumber
        ' 
        LabPartNumber.AutoSize = True
        LabPartNumber.Location = New Point(366, 102)
        LabPartNumber.Name = "LabPartNumber"
        LabPartNumber.Size = New Size(75, 15)
        LabPartNumber.TabIndex = 35
        LabPartNumber.Text = "Part Number"
        ' 
        ' TxtSerialNumber
        ' 
        TxtSerialNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "SerialNumber", True))
        TxtSerialNumber.Location = New Point(819, 70)
        TxtSerialNumber.Name = "TxtSerialNumber"
        TxtSerialNumber.Size = New Size(190, 23)
        TxtSerialNumber.TabIndex = 36
        ' 
        ' LabManufacturer
        ' 
        LabManufacturer.AutoSize = True
        LabManufacturer.Location = New Point(366, 73)
        LabManufacturer.Name = "LabManufacturer"
        LabManufacturer.Size = New Size(79, 15)
        LabManufacturer.TabIndex = 37
        LabManufacturer.Text = "Manufacturer"
        ' 
        ' LabStyle
        ' 
        LabStyle.AutoSize = True
        LabStyle.Location = New Point(366, 132)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(32, 15)
        LabStyle.TabIndex = 38
        LabStyle.Text = "Style"
        ' 
        ' LabMaterial
        ' 
        LabMaterial.AutoSize = True
        LabMaterial.Location = New Point(366, 161)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(50, 15)
        LabMaterial.TabIndex = 39
        LabMaterial.Text = "Material"
        ' 
        ' LabRotation
        ' 
        LabRotation.AutoSize = True
        LabRotation.Location = New Point(366, 191)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(52, 15)
        LabRotation.TabIndex = 40
        LabRotation.Text = "Rotation"
        ' 
        ' LabBlades
        ' 
        LabBlades.AutoSize = True
        LabBlades.Location = New Point(366, 221)
        LabBlades.Name = "LabBlades"
        LabBlades.Size = New Size(41, 15)
        LabBlades.TabIndex = 41
        LabBlades.Text = "Blades"
        ' 
        ' LabDiameter
        ' 
        LabDiameter.AutoSize = True
        LabDiameter.Location = New Point(366, 249)
        LabDiameter.Name = "LabDiameter"
        LabDiameter.Size = New Size(55, 15)
        LabDiameter.TabIndex = 42
        LabDiameter.Text = "Diameter"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F)
        Label1.Location = New Point(709, 276)
        Label1.Name = "Label1"
        Label1.Size = New Size(74, 15)
        Label1.TabIndex = 43
        Label1.Text = "Inspected By"
        ' 
        ' LabSerialNumber
        ' 
        LabSerialNumber.AutoSize = True
        LabSerialNumber.Location = New Point(709, 73)
        LabSerialNumber.Name = "LabSerialNumber"
        LabSerialNumber.Size = New Size(82, 15)
        LabSerialNumber.TabIndex = 44
        LabSerialNumber.Text = "Serial Number"
        ' 
        ' LabStampNumber
        ' 
        LabStampNumber.AutoSize = True
        LabStampNumber.Location = New Point(709, 102)
        LabStampNumber.Name = "LabStampNumber"
        LabStampNumber.Size = New Size(88, 15)
        LabStampNumber.TabIndex = 46
        LabStampNumber.Text = "Stamp Number"
        ' 
        ' TxtStampNumber
        ' 
        TxtStampNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "StampNumber", True))
        TxtStampNumber.Location = New Point(819, 99)
        TxtStampNumber.Name = "TxtStampNumber"
        TxtStampNumber.Size = New Size(190, 23)
        TxtStampNumber.TabIndex = 45
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "PartNumber", True))
        TxtPartNumber.Location = New Point(461, 98)
        TxtPartNumber.Name = "TxtPartNumber"
        TxtPartNumber.Size = New Size(190, 23)
        TxtPartNumber.TabIndex = 47
        ' 
        ' ComboInspectedBy
        ' 
        ComboInspectedBy.DataBindings.Add(New Binding("SelectedValue", JobBindingSource, "InspectedBy", True))
        ComboInspectedBy.DataSource = EmployeesBindingSource
        ComboInspectedBy.DisplayMember = "EmployeeName"
        ComboInspectedBy.Font = New Font("Segoe UI", 9F)
        ComboInspectedBy.FormattingEnabled = True
        ComboInspectedBy.Location = New Point(819, 273)
        ComboInspectedBy.Name = "ComboInspectedBy"
        ComboInspectedBy.Size = New Size(190, 23)
        ComboInspectedBy.TabIndex = 52
        ComboInspectedBy.ValueMember = "Id"
        ' 
        ' LabBore
        ' 
        LabBore.AutoSize = True
        LabBore.Location = New Point(366, 276)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(31, 15)
        LabBore.TabIndex = 55
        LabBore.Text = "Bore"
        ' 
        ' LabLEExclusion
        ' 
        LabLEExclusion.AutoSize = True
        LabLEExclusion.Location = New Point(709, 131)
        LabLEExclusion.Name = "LabLEExclusion"
        LabLEExclusion.Size = New Size(71, 15)
        LabLEExclusion.TabIndex = 56
        LabLEExclusion.Text = "LE Exclusion"
        ' 
        ' LabTEExclusion
        ' 
        LabTEExclusion.AutoSize = True
        LabTEExclusion.Location = New Point(709, 161)
        LabTEExclusion.Name = "LabTEExclusion"
        LabTEExclusion.Size = New Size(72, 15)
        LabTEExclusion.TabIndex = 57
        LabTEExclusion.Text = "TE Exclusion"
        ' 
        ' LabDAR
        ' 
        LabDAR.AutoSize = True
        LabDAR.Location = New Point(709, 218)
        LabDAR.Name = "LabDAR"
        LabDAR.Size = New Size(39, 15)
        LabDAR.TabIndex = 59
        LabDAR.Text = "D.A.R."
        ' 
        ' LabCup
        ' 
        LabCup.AutoSize = True
        LabCup.Location = New Point(709, 188)
        LabCup.Name = "LabCup"
        LabCup.Size = New Size(29, 15)
        LabCup.TabIndex = 58
        LabCup.Text = "Cup"
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.EditMode = False
        RecordNavigationBar1.Filter = ""
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(280, 12)
        RecordNavigationBar1.MasterControl = Nothing
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 60
        ' 
        ' CupBindingSource
        ' 
        CupBindingSource.DataSource = GetType(LibDatabase.Models.Cup)
        ' 
        ' FrmJobs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1052, 718)
        Controls.Add(RecordNavigationBar1)
        Controls.Add(LabDAR)
        Controls.Add(LabCup)
        Controls.Add(LabTEExclusion)
        Controls.Add(LabLEExclusion)
        Controls.Add(LabBore)
        Controls.Add(ComboInspectedBy)
        Controls.Add(TxtPartNumber)
        Controls.Add(LabStampNumber)
        Controls.Add(TxtStampNumber)
        Controls.Add(LabSerialNumber)
        Controls.Add(Label1)
        Controls.Add(LabDiameter)
        Controls.Add(LabBlades)
        Controls.Add(LabRotation)
        Controls.Add(LabMaterial)
        Controls.Add(LabStyle)
        Controls.Add(LabManufacturer)
        Controls.Add(TxtSerialNumber)
        Controls.Add(LabPartNumber)
        Controls.Add(TxtDAR)
        Controls.Add(ComboTeExclusion)
        Controls.Add(ComboLEExclusion)
        Controls.Add(ComboBlades)
        Controls.Add(ComboRotation)
        Controls.Add(ComboCup)
        Controls.Add(ComboBore)
        Controls.Add(TxtDiameter)
        Controls.Add(ComboMaterial)
        Controls.Add(ComboStyle)
        Controls.Add(ComboManufacturer)
        Controls.Add(labJobsJobDetailsTitle)
        Controls.Add(DataGridJobDetails)
        Controls.Add(CmdFiltersClear)
        Controls.Add(LabJob)
        Controls.Add(LabVessel)
        Controls.Add(LabCustomer)
        Controls.Add(ComboJobs)
        Controls.Add(ComboVessels)
        Controls.Add(ComboCustomers)
        Name = "FrmJobs"
        Text = "Jobs"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(RotationBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ExclusionsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CupBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents BladesBindingSource As BindingSource
    Friend WithEvents MaterialsBindingSource As BindingSource
    Friend WithEvents StylesBindingSource As BindingSource
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents LabJob As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents ComboJobs As ComboBox
    Friend WithEvents ComboVessels As ComboBox
    Friend WithEvents ComboCustomers As ComboBox
    Friend WithEvents CmdFiltersClear As Button
    Friend WithEvents labJobsJobDetailsTitle As Label
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents ComboManufacturer As ComboBox
    Friend WithEvents ComboStyle As ComboBox
    Friend WithEvents ComboMaterial As ComboBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents ComboBore As ComboBox
    Friend WithEvents ComboCup As ComboBox
    Friend WithEvents ComboRotation As ComboBox
    Friend WithEvents ComboBlades As ComboBox
    Friend WithEvents ComboTeExclusion As ComboBox
    Friend WithEvents ComboLEExclusion As ComboBox
    Friend WithEvents TxtDAR As TextBox
    Friend WithEvents LabPartNumber As Label
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents LabManufacturer As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents LabMaterial As Label
    Friend WithEvents LabRotation As Label
    Friend WithEvents LabBlades As Label
    Friend WithEvents LabDiameter As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabSerialNumber As Label
    Friend WithEvents LabStampNumber As Label
    Friend WithEvents TxtStampNumber As TextBox
    Friend WithEvents RotationBindingSource As BindingSource
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents ComboInspectedBy As ComboBox
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabBore As Label
    Friend WithEvents LabLEExclusion As Label
    Friend WithEvents LabTEExclusion As Label
    Friend WithEvents LabDAR As Label
    Friend WithEvents LabCup As Label
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents ExclusionsBindingSource As BindingSource
    Friend WithEvents CupBindingSource As BindingSource
End Class
