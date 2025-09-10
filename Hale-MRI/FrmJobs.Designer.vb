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
        JobsBindingSource = New BindingSource(components)
        JobDetailsBindingSource = New BindingSource(components)
        LabJob = New Label()
        LabVessel = New Label()
        LabCustomer = New Label()
        ComboJobs = New ComboBox()
        ComboVessels = New ComboBox()
        ComboCustomers = New ComboBox()
        DataGridJobDetails = New DataGridView()
        DateStarted = New DataGridViewTextBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        EmployeesBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        TxtBore = New TextBox()
        TxtDiameter = New TextBox()
        TxtPartNumber = New TextBox()
        LabDesiredPitch = New Label()
        LabMarkedPitch = New Label()
        TxtDesiredPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        LabDAR = New Label()
        LabCup = New Label()
        LabTEExclusion = New Label()
        LabLEExclusion = New Label()
        LabBore = New Label()
        ComboInspectedBy = New ComboBox()
        LabStampNumber = New Label()
        TxtStampNumber = New TextBox()
        LabSerialNumber = New Label()
        Label1 = New Label()
        LabDiameter = New Label()
        LabBlades = New Label()
        LabRotation = New Label()
        LabMaterial = New Label()
        LabStyle = New Label()
        LabManufacturer = New Label()
        TxtSerialNumber = New TextBox()
        LabPartNumber = New Label()
        TxtDAR = New TextBox()
        ComboTeExclusion = New ComboBox()
        ComboLEExclusion = New ComboBox()
        ComboBlades = New ComboBox()
        ComboRotation = New ComboBox()
        ComboCup = New ComboBox()
        ComboMaterial = New ComboBox()
        ComboStyle = New ComboBox()
        ComboManufacturer = New ComboBox()
        CmdScanDataPick = New Button()
        CmdScanDataExport = New Button()
        CmdScanDataImport = New Button()
        labCalibrationFile = New Label()
        TxtScanDataFile = New TextBox()
        RecordNavigationBar1 = New RecordNavigationBar()
        LabMeasurements = New Label()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' JobsBindingSource
        ' 
        JobsBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' LabJob
        ' 
        LabJob.AutoSize = True
        LabJob.Font = New Font("Segoe UI", 9F)
        LabJob.Location = New Point(29, 137)
        LabJob.Name = "LabJob"
        LabJob.Size = New Size(25, 15)
        LabJob.TabIndex = 192
        LabJob.Text = "Job"
        ' 
        ' LabVessel
        ' 
        LabVessel.AutoSize = True
        LabVessel.Location = New Point(29, 108)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(38, 15)
        LabVessel.TabIndex = 191
        LabVessel.Text = "Vessel"
        ' 
        ' LabCustomer
        ' 
        LabCustomer.AutoSize = True
        LabCustomer.Location = New Point(29, 79)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(59, 15)
        LabCustomer.TabIndex = 190
        LabCustomer.Text = "Customer"
        ' 
        ' ComboJobs
        ' 
        ComboJobs.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboJobs.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboJobs.DataSource = JobsBindingSource
        ComboJobs.DisplayMember = "JobNumber"
        ComboJobs.Font = New Font("Segoe UI", 9F)
        ComboJobs.FormattingEnabled = True
        ComboJobs.Location = New Point(94, 134)
        ComboJobs.Name = "ComboJobs"
        ComboJobs.Size = New Size(228, 23)
        ComboJobs.TabIndex = 189
        ComboJobs.ValueMember = "Id"
        ' 
        ' ComboVessels
        ' 
        ComboVessels.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboVessels.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboVessels.DisplayMember = "VesselName"
        ComboVessels.FormattingEnabled = True
        ComboVessels.Location = New Point(94, 105)
        ComboVessels.Name = "ComboVessels"
        ComboVessels.Size = New Size(228, 23)
        ComboVessels.TabIndex = 188
        ComboVessels.ValueMember = "Id"
        ' 
        ' ComboCustomers
        ' 
        ComboCustomers.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboCustomers.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboCustomers.DisplayMember = "CustomerName"
        ComboCustomers.FormattingEnabled = True
        ComboCustomers.Location = New Point(94, 76)
        ComboCustomers.Name = "ComboCustomers"
        ComboCustomers.Size = New Size(228, 23)
        ComboCustomers.TabIndex = 187
        ComboCustomers.ValueMember = "Id"
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridJobDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {DateStarted, PerformedBy, Description})
        DataGridJobDetails.Location = New Point(451, 379)
        DataGridJobDetails.Margin = New Padding(0)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ReadOnly = True
        DataGridJobDetails.RowHeadersWidth = 82
        DataGridJobDetails.Size = New Size(642, 282)
        DataGridJobDetails.TabIndex = 193
        ' 
        ' DateStarted
        ' 
        DateStarted.DataPropertyName = "StartDate"
        DateStarted.HeaderText = "Date Started"
        DateStarted.MinimumWidth = 140
        DateStarted.Name = "DateStarted"
        DateStarted.ReadOnly = True
        DateStarted.Width = 140
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
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeesBindingSource.Sort = ""
        ' 
        ' Description
        ' 
        Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.MinimumWidth = 298
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Width = 298
        ' 
        ' TxtBore
        ' 
        TxtBore.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerBore", True))
        TxtBore.Location = New Point(536, 280)
        TxtBore.Name = "TxtBore"
        TxtBore.Size = New Size(190, 23)
        TxtBore.TabIndex = 258
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerDiameter", True))
        TxtDiameter.Location = New Point(536, 251)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.Size = New Size(190, 23)
        TxtDiameter.TabIndex = 257
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerPartNumber", True))
        TxtPartNumber.Location = New Point(536, 105)
        TxtPartNumber.Name = "TxtPartNumber"
        TxtPartNumber.Size = New Size(190, 23)
        TxtPartNumber.TabIndex = 256
        ' 
        ' LabDesiredPitch
        ' 
        LabDesiredPitch.AutoSize = True
        LabDesiredPitch.Location = New Point(793, 166)
        LabDesiredPitch.Name = "LabDesiredPitch"
        LabDesiredPitch.Size = New Size(76, 15)
        LabDesiredPitch.TabIndex = 255
        LabDesiredPitch.Text = "Desired Pitch"
        ' 
        ' LabMarkedPitch
        ' 
        LabMarkedPitch.AutoSize = True
        LabMarkedPitch.Location = New Point(793, 137)
        LabMarkedPitch.Name = "LabMarkedPitch"
        LabMarkedPitch.Size = New Size(77, 15)
        LabMarkedPitch.TabIndex = 254
        LabMarkedPitch.Text = "Marked Pitch"
        ' 
        ' TxtDesiredPitch
        ' 
        TxtDesiredPitch.DataBindings.Add(New Binding("Text", JobsBindingSource, "DesiredPitch", True))
        TxtDesiredPitch.Location = New Point(903, 163)
        TxtDesiredPitch.Name = "TxtDesiredPitch"
        TxtDesiredPitch.Size = New Size(190, 23)
        TxtDesiredPitch.TabIndex = 253
        ' 
        ' TxtMarkedPitch
        ' 
        TxtMarkedPitch.DataBindings.Add(New Binding("Text", JobsBindingSource, "MarkedPitch", True))
        TxtMarkedPitch.Location = New Point(903, 134)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.Size = New Size(190, 23)
        TxtMarkedPitch.TabIndex = 252
        ' 
        ' LabDAR
        ' 
        LabDAR.AutoSize = True
        LabDAR.Location = New Point(793, 283)
        LabDAR.Name = "LabDAR"
        LabDAR.Size = New Size(39, 15)
        LabDAR.TabIndex = 251
        LabDAR.Text = "D.A.R."
        ' 
        ' LabCup
        ' 
        LabCup.AutoSize = True
        LabCup.Location = New Point(793, 252)
        LabCup.Name = "LabCup"
        LabCup.Size = New Size(29, 15)
        LabCup.TabIndex = 250
        LabCup.Text = "Cup"
        ' 
        ' LabTEExclusion
        ' 
        LabTEExclusion.AutoSize = True
        LabTEExclusion.Location = New Point(793, 225)
        LabTEExclusion.Name = "LabTEExclusion"
        LabTEExclusion.Size = New Size(72, 15)
        LabTEExclusion.TabIndex = 249
        LabTEExclusion.Text = "TE Exclusion"
        ' 
        ' LabLEExclusion
        ' 
        LabLEExclusion.AutoSize = True
        LabLEExclusion.Location = New Point(793, 195)
        LabLEExclusion.Name = "LabLEExclusion"
        LabLEExclusion.Size = New Size(71, 15)
        LabLEExclusion.TabIndex = 248
        LabLEExclusion.Text = "LE Exclusion"
        ' 
        ' LabBore
        ' 
        LabBore.AutoSize = True
        LabBore.Location = New Point(451, 283)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(31, 15)
        LabBore.TabIndex = 247
        LabBore.Text = "Bore"
        ' 
        ' ComboInspectedBy
        ' 
        ComboInspectedBy.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "InspectedBy", True))
        ComboInspectedBy.DataSource = EmployeesBindingSource
        ComboInspectedBy.DisplayMember = "EmployeeName"
        ComboInspectedBy.Font = New Font("Segoe UI", 9F)
        ComboInspectedBy.FormattingEnabled = True
        ComboInspectedBy.Location = New Point(903, 309)
        ComboInspectedBy.Name = "ComboInspectedBy"
        ComboInspectedBy.Size = New Size(190, 23)
        ComboInspectedBy.TabIndex = 246
        ComboInspectedBy.ValueMember = "Id"
        ' 
        ' LabStampNumber
        ' 
        LabStampNumber.AutoSize = True
        LabStampNumber.Location = New Point(793, 108)
        LabStampNumber.Name = "LabStampNumber"
        LabStampNumber.Size = New Size(88, 15)
        LabStampNumber.TabIndex = 245
        LabStampNumber.Text = "Stamp Number"
        ' 
        ' TxtStampNumber
        ' 
        TxtStampNumber.DataBindings.Add(New Binding("Text", JobsBindingSource, "StampNumber", True))
        TxtStampNumber.Location = New Point(903, 105)
        TxtStampNumber.Name = "TxtStampNumber"
        TxtStampNumber.Size = New Size(190, 23)
        TxtStampNumber.TabIndex = 244
        ' 
        ' LabSerialNumber
        ' 
        LabSerialNumber.AutoSize = True
        LabSerialNumber.Location = New Point(793, 79)
        LabSerialNumber.Name = "LabSerialNumber"
        LabSerialNumber.Size = New Size(82, 15)
        LabSerialNumber.TabIndex = 243
        LabSerialNumber.Text = "Serial Number"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F)
        Label1.Location = New Point(793, 312)
        Label1.Name = "Label1"
        Label1.Size = New Size(74, 15)
        Label1.TabIndex = 242
        Label1.Text = "Inspected By"
        ' 
        ' LabDiameter
        ' 
        LabDiameter.AutoSize = True
        LabDiameter.Location = New Point(451, 254)
        LabDiameter.Name = "LabDiameter"
        LabDiameter.Size = New Size(55, 15)
        LabDiameter.TabIndex = 241
        LabDiameter.Text = "Diameter"
        ' 
        ' LabBlades
        ' 
        LabBlades.AutoSize = True
        LabBlades.Location = New Point(451, 224)
        LabBlades.Name = "LabBlades"
        LabBlades.Size = New Size(41, 15)
        LabBlades.TabIndex = 240
        LabBlades.Text = "Blades"
        ' 
        ' LabRotation
        ' 
        LabRotation.AutoSize = True
        LabRotation.Location = New Point(451, 195)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(52, 15)
        LabRotation.TabIndex = 239
        LabRotation.Text = "Rotation"
        ' 
        ' LabMaterial
        ' 
        LabMaterial.AutoSize = True
        LabMaterial.Location = New Point(451, 166)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(50, 15)
        LabMaterial.TabIndex = 238
        LabMaterial.Text = "Material"
        ' 
        ' LabStyle
        ' 
        LabStyle.AutoSize = True
        LabStyle.Location = New Point(451, 137)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(32, 15)
        LabStyle.TabIndex = 237
        LabStyle.Text = "Style"
        ' 
        ' LabManufacturer
        ' 
        LabManufacturer.AutoSize = True
        LabManufacturer.Location = New Point(451, 79)
        LabManufacturer.Name = "LabManufacturer"
        LabManufacturer.Size = New Size(79, 15)
        LabManufacturer.TabIndex = 236
        LabManufacturer.Text = "Manufacturer"
        ' 
        ' TxtSerialNumber
        ' 
        TxtSerialNumber.DataBindings.Add(New Binding("Text", JobsBindingSource, "SerialNumber", True))
        TxtSerialNumber.Location = New Point(903, 76)
        TxtSerialNumber.Name = "TxtSerialNumber"
        TxtSerialNumber.Size = New Size(190, 23)
        TxtSerialNumber.TabIndex = 235
        ' 
        ' LabPartNumber
        ' 
        LabPartNumber.AutoSize = True
        LabPartNumber.Location = New Point(451, 108)
        LabPartNumber.Name = "LabPartNumber"
        LabPartNumber.Size = New Size(75, 15)
        LabPartNumber.TabIndex = 234
        LabPartNumber.Text = "Part Number"
        ' 
        ' TxtDAR
        ' 
        TxtDAR.DataBindings.Add(New Binding("Text", JobsBindingSource, "Dar", True))
        TxtDAR.Location = New Point(903, 279)
        TxtDAR.Name = "TxtDAR"
        TxtDAR.Size = New Size(190, 23)
        TxtDAR.TabIndex = 233
        ' 
        ' ComboTeExclusion
        ' 
        ComboTeExclusion.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "TeExclusion", True))
        ComboTeExclusion.DisplayMember = "Exclusion1"
        ComboTeExclusion.FormattingEnabled = True
        ComboTeExclusion.Location = New Point(903, 221)
        ComboTeExclusion.Name = "ComboTeExclusion"
        ComboTeExclusion.Size = New Size(190, 23)
        ComboTeExclusion.TabIndex = 232
        ComboTeExclusion.ValueMember = "Exclusion1"
        ' 
        ' ComboLEExclusion
        ' 
        ComboLEExclusion.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "LeExclusion", True))
        ComboLEExclusion.DisplayMember = "Exclusion1"
        ComboLEExclusion.FormattingEnabled = True
        ComboLEExclusion.Location = New Point(903, 192)
        ComboLEExclusion.Name = "ComboLEExclusion"
        ComboLEExclusion.Size = New Size(190, 23)
        ComboLEExclusion.TabIndex = 231
        ComboLEExclusion.ValueMember = "Exclusion1"
        ' 
        ' ComboBlades
        ' 
        ComboBlades.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "PropellerBlades", True))
        ComboBlades.DisplayMember = "BladeCount"
        ComboBlades.FormattingEnabled = True
        ComboBlades.Location = New Point(536, 221)
        ComboBlades.Name = "ComboBlades"
        ComboBlades.Size = New Size(190, 23)
        ComboBlades.TabIndex = 230
        ComboBlades.ValueMember = "BladeCount"
        ' 
        ' ComboRotation
        ' 
        ComboRotation.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "PropellerRotation", True))
        ComboRotation.DisplayMember = "Rotation1"
        ComboRotation.FormattingEnabled = True
        ComboRotation.Location = New Point(536, 192)
        ComboRotation.Name = "ComboRotation"
        ComboRotation.Size = New Size(190, 23)
        ComboRotation.TabIndex = 229
        ComboRotation.ValueMember = "Rotation1"
        ' 
        ' ComboCup
        ' 
        ComboCup.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "Cup", True))
        ComboCup.DisplayMember = "Cup1"
        ComboCup.FormattingEnabled = True
        ComboCup.Location = New Point(903, 250)
        ComboCup.Name = "ComboCup"
        ComboCup.Size = New Size(190, 23)
        ComboCup.TabIndex = 228
        ComboCup.ValueMember = "Cup1"
        ' 
        ' ComboMaterial
        ' 
        ComboMaterial.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "PropellerMaterial", True))
        ComboMaterial.DisplayMember = "Material1"
        ComboMaterial.FormattingEnabled = True
        ComboMaterial.Location = New Point(536, 163)
        ComboMaterial.Name = "ComboMaterial"
        ComboMaterial.Size = New Size(190, 23)
        ComboMaterial.TabIndex = 227
        ComboMaterial.ValueMember = "Material1"
        ' 
        ' ComboStyle
        ' 
        ComboStyle.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "PropellerStyle", True))
        ComboStyle.DisplayMember = "Style1"
        ComboStyle.FormattingEnabled = True
        ComboStyle.Location = New Point(536, 134)
        ComboStyle.Name = "ComboStyle"
        ComboStyle.Size = New Size(190, 23)
        ComboStyle.TabIndex = 226
        ComboStyle.ValueMember = "Style1"
        ' 
        ' ComboManufacturer
        ' 
        ComboManufacturer.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "PropellerManufacturerId", True))
        ComboManufacturer.DisplayMember = "ManufacturerName"
        ComboManufacturer.FormattingEnabled = True
        ComboManufacturer.Location = New Point(536, 76)
        ComboManufacturer.Name = "ComboManufacturer"
        ComboManufacturer.Size = New Size(190, 23)
        ComboManufacturer.TabIndex = 225
        ComboManufacturer.ValueMember = "Id"
        ' 
        ' CmdScanDataPick
        ' 
        CmdScanDataPick.Image = My.Resources.Resources.OpenfileDialog
        CmdScanDataPick.Location = New Point(326, 279)
        CmdScanDataPick.Margin = New Padding(2, 1, 2, 1)
        CmdScanDataPick.Name = "CmdScanDataPick"
        CmdScanDataPick.Size = New Size(35, 22)
        CmdScanDataPick.TabIndex = 263
        CmdScanDataPick.UseVisualStyleBackColor = True
        ' 
        ' CmdScanDataExport
        ' 
        CmdScanDataExport.Enabled = False
        CmdScanDataExport.Image = My.Resources.Resources.Export
        CmdScanDataExport.Location = New Point(170, 308)
        CmdScanDataExport.Margin = New Padding(2, 1, 2, 1)
        CmdScanDataExport.Name = "CmdScanDataExport"
        CmdScanDataExport.Size = New Size(72, 22)
        CmdScanDataExport.TabIndex = 265
        CmdScanDataExport.UseVisualStyleBackColor = True
        ' 
        ' CmdScanDataImport
        ' 
        CmdScanDataImport.Enabled = False
        CmdScanDataImport.Image = My.Resources.Resources.Import
        CmdScanDataImport.Location = New Point(94, 308)
        CmdScanDataImport.Margin = New Padding(2, 1, 2, 1)
        CmdScanDataImport.Name = "CmdScanDataImport"
        CmdScanDataImport.Size = New Size(72, 22)
        CmdScanDataImport.TabIndex = 264
        CmdScanDataImport.UseVisualStyleBackColor = True
        ' 
        ' labCalibrationFile
        ' 
        labCalibrationFile.AutoSize = True
        labCalibrationFile.Location = New Point(29, 282)
        labCalibrationFile.Margin = New Padding(2, 0, 2, 0)
        labCalibrationFile.Name = "labCalibrationFile"
        labCalibrationFile.Size = New Size(59, 15)
        labCalibrationFile.TabIndex = 261
        labCalibrationFile.Text = "Scan Data"
        ' 
        ' TxtScanDataFile
        ' 
        TxtScanDataFile.Location = New Point(94, 279)
        TxtScanDataFile.Margin = New Padding(2, 1, 2, 1)
        TxtScanDataFile.Name = "TxtScanDataFile"
        TxtScanDataFile.Size = New Size(228, 23)
        TxtScanDataFile.TabIndex = 262
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(364, 12)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 266
        ' 
        ' LabMeasurements
        ' 
        LabMeasurements.AutoSize = True
        LabMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMeasurements.Location = New Point(451, 364)
        LabMeasurements.Name = "LabMeasurements"
        LabMeasurements.Size = New Size(90, 15)
        LabMeasurements.TabIndex = 267
        LabMeasurements.Text = "Measurements"
        ' 
        ' FrmJobs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1128, 708)
        Controls.Add(LabMeasurements)
        Controls.Add(RecordNavigationBar1)
        Controls.Add(CmdScanDataPick)
        Controls.Add(CmdScanDataExport)
        Controls.Add(CmdScanDataImport)
        Controls.Add(labCalibrationFile)
        Controls.Add(TxtScanDataFile)
        Controls.Add(TxtBore)
        Controls.Add(TxtDiameter)
        Controls.Add(TxtPartNumber)
        Controls.Add(LabDesiredPitch)
        Controls.Add(LabMarkedPitch)
        Controls.Add(TxtDesiredPitch)
        Controls.Add(TxtMarkedPitch)
        Controls.Add(LabDAR)
        Controls.Add(LabCup)
        Controls.Add(LabTEExclusion)
        Controls.Add(LabLEExclusion)
        Controls.Add(LabBore)
        Controls.Add(ComboInspectedBy)
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
        Controls.Add(ComboMaterial)
        Controls.Add(ComboStyle)
        Controls.Add(ComboManufacturer)
        Controls.Add(DataGridJobDetails)
        Controls.Add(LabJob)
        Controls.Add(LabVessel)
        Controls.Add(LabCustomer)
        Controls.Add(ComboJobs)
        Controls.Add(ComboVessels)
        Controls.Add(ComboCustomers)
        Name = "FrmJobs"
        Text = "Jobs"
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents LabJob As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents ComboJobs As ComboBox
    Friend WithEvents ComboVessels As ComboBox
    Friend WithEvents ComboCustomers As ComboBox
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents LabDesiredPitch As Label
    Friend WithEvents LabMarkedPitch As Label
    Friend WithEvents TxtDesiredPitch As TextBox
    Friend WithEvents TxtMarkedPitch As TextBox
    Friend WithEvents LabDAR As Label
    Friend WithEvents LabCup As Label
    Friend WithEvents LabTEExclusion As Label
    Friend WithEvents LabLEExclusion As Label
    Friend WithEvents LabBore As Label
    Friend WithEvents ComboInspectedBy As ComboBox
    Friend WithEvents LabStampNumber As Label
    Friend WithEvents TxtStampNumber As TextBox
    Friend WithEvents LabSerialNumber As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabDiameter As Label
    Friend WithEvents LabBlades As Label
    Friend WithEvents LabRotation As Label
    Friend WithEvents LabMaterial As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents LabManufacturer As Label
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents LabPartNumber As Label
    Friend WithEvents TxtDAR As TextBox
    Friend WithEvents ComboTeExclusion As ComboBox
    Friend WithEvents ComboLEExclusion As ComboBox
    Friend WithEvents ComboBlades As ComboBox
    Friend WithEvents ComboRotation As ComboBox
    Friend WithEvents ComboCup As ComboBox
    Friend WithEvents ComboMaterial As ComboBox
    Friend WithEvents ComboStyle As ComboBox
    Friend WithEvents ComboManufacturer As ComboBox
    Friend WithEvents CmdScanDataPick As Button
    Friend WithEvents CmdScanDataExport As Button
    Friend WithEvents CmdScanDataImport As Button
    Friend WithEvents labCalibrationFile As Label
    Friend WithEvents TxtScanDataFile As TextBox
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents DateStarted As DataGridViewTextBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents LabMeasurements As Label
End Class
