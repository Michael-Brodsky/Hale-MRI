<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        JobDetailsBindingSource = New BindingSource(components)
        CellMeasurementsBindingSource = New BindingSource(components)
        ExtremeMeasurementsBindingSource = New BindingSource(components)
        RadiusMeasurementBindingSource = New BindingSource(components)
        JobsBindingSource = New BindingSource(components)
        TeExclusionsBindingSource = New BindingSource(components)
        LeExclusionsBindingSource = New BindingSource(components)
        DataGridRadius = New DataGridView()
        BladeIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RadiusDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LeCellDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TeCellDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PanelPropeller = New Panel()
        TxtBlades = New TextBox()
        TxtRotation = New TextBox()
        LabBlades = New Label()
        LabRotation = New Label()
        TxtMaterial = New TextBox()
        TxtStyle = New TextBox()
        LabMaterial = New Label()
        LabStyle = New Label()
        TxtBore = New TextBox()
        TxtDiameter = New TextBox()
        LabBore = New Label()
        LabDiameter = New Label()
        PanelJob = New Panel()
        TxtJobDescription = New TextBox()
        TxtInspectedBy = New TextBox()
        TxtJobStartDate = New TextBox()
        LabInspectedBy = New Label()
        LabJobStartDate = New Label()
        LabVessel = New Label()
        LabCustomer = New Label()
        LabJobNumber = New Label()
        LabJobDescription = New Label()
        TxtVessel = New TextBox()
        TxtCustomer = New TextBox()
        TxtJobNumber = New TextBox()
        DataGridCell = New DataGridView()
        AngleDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DepthDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DataGridExtreme = New DataGridView()
        BladeIdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        ExtremeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PanelJobData = New Panel()
        LabWheelPitch = New Label()
        TxtWheelPitch = New TextBox()
        LabDesiredPitch = New Label()
        LabMarkedPitch = New Label()
        TxtDesiredPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        LabTEExclusion = New Label()
        LabLEExclusion = New Label()
        ComboTeExclusion = New ComboBox()
        ComboLEExclusion = New ComboBox()
        LabRadiusMeasurements = New Label()
        LabCellMeasurements = New Label()
        LabExtremeMeasurements = New Label()
        PanelMeasurement = New Panel()
        LabMeasurementType = New Label()
        LabSelectedBlade = New Label()
        ChkScan = New CheckBox()
        ComboMeasurementType = New ComboBox()
        ComboSelectedBlade = New ComboBox()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(TeExclusionsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(LeExclusionsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridRadius, ComponentModel.ISupportInitialize).BeginInit()
        PanelPropeller.SuspendLayout()
        PanelJob.SuspendLayout()
        CType(DataGridCell, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridExtreme, ComponentModel.ISupportInitialize).BeginInit()
        PanelJobData.SuspendLayout()
        PanelMeasurement.SuspendLayout()
        SuspendLayout()
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' CellMeasurementsBindingSource
        ' 
        CellMeasurementsBindingSource.DataSource = GetType(LibDatabase.Models.CellMeasurement)
        ' 
        ' ExtremeMeasurementsBindingSource
        ' 
        ExtremeMeasurementsBindingSource.DataSource = GetType(LibDatabase.Models.ExtremeMeasurement)
        ' 
        ' RadiusMeasurementBindingSource
        ' 
        RadiusMeasurementBindingSource.DataSource = GetType(LibDatabase.Models.RadiusMeasurement)
        ' 
        ' JobsBindingSource
        ' 
        JobsBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' LeExclusionsBindingSource
        ' 
        LeExclusionsBindingSource.DataSource = GetType(LibDatabase.Models.Exclusion)
        ' 
        ' DataGridRadius
        ' 
        DataGridRadius.AllowUserToAddRows = False
        DataGridRadius.AllowUserToDeleteRows = False
        DataGridRadius.AutoGenerateColumns = False
        DataGridRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridRadius.Columns.AddRange(New DataGridViewColumn() {BladeIdDataGridViewTextBoxColumn, RadiusDataGridViewTextBoxColumn, LeCellDataGridViewTextBoxColumn, TeCellDataGridViewTextBoxColumn})
        DataGridRadius.DataSource = RadiusMeasurementBindingSource
        DataGridRadius.Location = New Point(645, 30)
        DataGridRadius.Name = "DataGridRadius"
        DataGridRadius.ReadOnly = True
        DataGridRadius.Size = New Size(360, 295)
        DataGridRadius.TabIndex = 245
        ' 
        ' BladeIdDataGridViewTextBoxColumn
        ' 
        BladeIdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        BladeIdDataGridViewTextBoxColumn.DataPropertyName = "BladeId"
        BladeIdDataGridViewTextBoxColumn.HeaderText = "Blade"
        BladeIdDataGridViewTextBoxColumn.Name = "BladeIdDataGridViewTextBoxColumn"
        BladeIdDataGridViewTextBoxColumn.ReadOnly = True
        BladeIdDataGridViewTextBoxColumn.Width = 61
        ' 
        ' RadiusDataGridViewTextBoxColumn
        ' 
        RadiusDataGridViewTextBoxColumn.DataPropertyName = "Radius"
        RadiusDataGridViewTextBoxColumn.HeaderText = "Radius"
        RadiusDataGridViewTextBoxColumn.MinimumWidth = 120
        RadiusDataGridViewTextBoxColumn.Name = "RadiusDataGridViewTextBoxColumn"
        RadiusDataGridViewTextBoxColumn.ReadOnly = True
        RadiusDataGridViewTextBoxColumn.Width = 120
        ' 
        ' LeCellDataGridViewTextBoxColumn
        ' 
        LeCellDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        LeCellDataGridViewTextBoxColumn.DataPropertyName = "LeCell"
        LeCellDataGridViewTextBoxColumn.HeaderText = "LE Cell"
        LeCellDataGridViewTextBoxColumn.Name = "LeCellDataGridViewTextBoxColumn"
        LeCellDataGridViewTextBoxColumn.ReadOnly = True
        LeCellDataGridViewTextBoxColumn.Width = 67
        ' 
        ' TeCellDataGridViewTextBoxColumn
        ' 
        TeCellDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        TeCellDataGridViewTextBoxColumn.DataPropertyName = "TeCell"
        TeCellDataGridViewTextBoxColumn.HeaderText = "TE Cell"
        TeCellDataGridViewTextBoxColumn.Name = "TeCellDataGridViewTextBoxColumn"
        TeCellDataGridViewTextBoxColumn.ReadOnly = True
        TeCellDataGridViewTextBoxColumn.Width = 68
        ' 
        ' PanelPropeller
        ' 
        PanelPropeller.AutoSize = True
        PanelPropeller.BorderStyle = BorderStyle.Fixed3D
        PanelPropeller.Controls.Add(TxtBlades)
        PanelPropeller.Controls.Add(TxtRotation)
        PanelPropeller.Controls.Add(LabBlades)
        PanelPropeller.Controls.Add(LabRotation)
        PanelPropeller.Controls.Add(TxtMaterial)
        PanelPropeller.Controls.Add(TxtStyle)
        PanelPropeller.Controls.Add(LabMaterial)
        PanelPropeller.Controls.Add(LabStyle)
        PanelPropeller.Controls.Add(TxtBore)
        PanelPropeller.Controls.Add(TxtDiameter)
        PanelPropeller.Controls.Add(LabBore)
        PanelPropeller.Controls.Add(LabDiameter)
        PanelPropeller.Location = New Point(12, 193)
        PanelPropeller.Name = "PanelPropeller"
        PanelPropeller.Size = New Size(289, 132)
        PanelPropeller.TabIndex = 266
        ' 
        ' TxtBlades
        ' 
        TxtBlades.BackColor = SystemColors.Control
        TxtBlades.BorderStyle = BorderStyle.None
        TxtBlades.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerBlades", True))
        TxtBlades.Location = New Point(92, 66)
        TxtBlades.Name = "TxtBlades"
        TxtBlades.ReadOnly = True
        TxtBlades.Size = New Size(190, 16)
        TxtBlades.TabIndex = 256
        ' 
        ' TxtRotation
        ' 
        TxtRotation.BackColor = SystemColors.Control
        TxtRotation.BorderStyle = BorderStyle.None
        TxtRotation.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerRotation", True))
        TxtRotation.Location = New Point(92, 44)
        TxtRotation.Name = "TxtRotation"
        TxtRotation.ReadOnly = True
        TxtRotation.Size = New Size(190, 16)
        TxtRotation.TabIndex = 255
        ' 
        ' LabBlades
        ' 
        LabBlades.AutoSize = True
        LabBlades.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBlades.ForeColor = SystemColors.HotTrack
        LabBlades.Location = New Point(0, 66)
        LabBlades.Name = "LabBlades"
        LabBlades.Size = New Size(43, 15)
        LabBlades.TabIndex = 254
        LabBlades.Text = "Blades"
        ' 
        ' LabRotation
        ' 
        LabRotation.AutoSize = True
        LabRotation.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRotation.ForeColor = SystemColors.HotTrack
        LabRotation.Location = New Point(0, 44)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(55, 15)
        LabRotation.TabIndex = 253
        LabRotation.Text = "Rotation"
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.BackColor = SystemColors.Control
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerMaterial", True))
        TxtMaterial.Location = New Point(92, 22)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(190, 16)
        TxtMaterial.TabIndex = 252
        ' 
        ' TxtStyle
        ' 
        TxtStyle.BackColor = SystemColors.Control
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerStyle", True))
        TxtStyle.Location = New Point(92, 0)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(190, 16)
        TxtStyle.TabIndex = 251
        ' 
        ' LabMaterial
        ' 
        LabMaterial.AutoSize = True
        LabMaterial.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMaterial.ForeColor = SystemColors.HotTrack
        LabMaterial.Location = New Point(0, 22)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(53, 15)
        LabMaterial.TabIndex = 250
        LabMaterial.Text = "Material"
        ' 
        ' LabStyle
        ' 
        LabStyle.AutoSize = True
        LabStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStyle.ForeColor = SystemColors.HotTrack
        LabStyle.Location = New Point(1, 0)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(35, 15)
        LabStyle.TabIndex = 249
        LabStyle.Text = "Style"
        ' 
        ' TxtBore
        ' 
        TxtBore.BackColor = SystemColors.Control
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerBore", True))
        TxtBore.Location = New Point(92, 109)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(190, 16)
        TxtBore.TabIndex = 248
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.BackColor = SystemColors.Control
        TxtDiameter.BorderStyle = BorderStyle.None
        TxtDiameter.DataBindings.Add(New Binding("Text", JobsBindingSource, "PropellerDiameter", True))
        TxtDiameter.Location = New Point(92, 88)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.ReadOnly = True
        TxtDiameter.Size = New Size(190, 16)
        TxtDiameter.TabIndex = 247
        ' 
        ' LabBore
        ' 
        LabBore.AutoSize = True
        LabBore.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBore.ForeColor = SystemColors.HotTrack
        LabBore.Location = New Point(1, 110)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(34, 15)
        LabBore.TabIndex = 246
        LabBore.Text = "Bore"
        ' 
        ' LabDiameter
        ' 
        LabDiameter.AutoSize = True
        LabDiameter.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDiameter.ForeColor = SystemColors.HotTrack
        LabDiameter.Location = New Point(0, 88)
        LabDiameter.Name = "LabDiameter"
        LabDiameter.Size = New Size(60, 15)
        LabDiameter.TabIndex = 245
        LabDiameter.Text = "Diameter"
        ' 
        ' PanelJob
        ' 
        PanelJob.AutoSize = True
        PanelJob.BorderStyle = BorderStyle.Fixed3D
        PanelJob.Controls.Add(TxtJobDescription)
        PanelJob.Controls.Add(TxtInspectedBy)
        PanelJob.Controls.Add(TxtJobStartDate)
        PanelJob.Controls.Add(LabInspectedBy)
        PanelJob.Controls.Add(LabJobStartDate)
        PanelJob.Controls.Add(LabVessel)
        PanelJob.Controls.Add(LabCustomer)
        PanelJob.Controls.Add(LabJobNumber)
        PanelJob.Controls.Add(LabJobDescription)
        PanelJob.Controls.Add(TxtVessel)
        PanelJob.Controls.Add(TxtCustomer)
        PanelJob.Controls.Add(TxtJobNumber)
        PanelJob.Location = New Point(11, 12)
        PanelJob.Name = "PanelJob"
        PanelJob.Size = New Size(289, 156)
        PanelJob.TabIndex = 267
        ' 
        ' TxtJobDescription
        ' 
        TxtJobDescription.BackColor = SystemColors.Control
        TxtJobDescription.BorderStyle = BorderStyle.None
        TxtJobDescription.DataBindings.Add(New Binding("Text", JobsBindingSource, "Description", True))
        TxtJobDescription.Location = New Point(89, 111)
        TxtJobDescription.Multiline = True
        TxtJobDescription.Name = "TxtJobDescription"
        TxtJobDescription.ReadOnly = True
        TxtJobDescription.Size = New Size(193, 38)
        TxtJobDescription.TabIndex = 267
        ' 
        ' TxtInspectedBy
        ' 
        TxtInspectedBy.BackColor = SystemColors.Control
        TxtInspectedBy.BorderStyle = BorderStyle.None
        TxtInspectedBy.DataBindings.Add(New Binding("Text", JobsBindingSource, "InspectedByNavigation.EmployeeName", True))
        TxtInspectedBy.Location = New Point(92, 90)
        TxtInspectedBy.Name = "TxtInspectedBy"
        TxtInspectedBy.ReadOnly = True
        TxtInspectedBy.Size = New Size(190, 16)
        TxtInspectedBy.TabIndex = 266
        ' 
        ' TxtJobStartDate
        ' 
        TxtJobStartDate.BackColor = SystemColors.Control
        TxtJobStartDate.BorderStyle = BorderStyle.None
        TxtJobStartDate.DataBindings.Add(New Binding("Text", JobsBindingSource, "StartDate", True))
        TxtJobStartDate.Location = New Point(92, 69)
        TxtJobStartDate.Name = "TxtJobStartDate"
        TxtJobStartDate.Size = New Size(190, 16)
        TxtJobStartDate.TabIndex = 265
        ' 
        ' LabInspectedBy
        ' 
        LabInspectedBy.AutoSize = True
        LabInspectedBy.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabInspectedBy.ForeColor = SystemColors.HotTrack
        LabInspectedBy.Location = New Point(1, 90)
        LabInspectedBy.Name = "LabInspectedBy"
        LabInspectedBy.Size = New Size(79, 15)
        LabInspectedBy.TabIndex = 272
        LabInspectedBy.Text = "Inspected By"
        LabInspectedBy.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabJobStartDate
        ' 
        LabJobStartDate.AutoSize = True
        LabJobStartDate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobStartDate.ForeColor = SystemColors.HotTrack
        LabJobStartDate.Location = New Point(1, 69)
        LabJobStartDate.Name = "LabJobStartDate"
        LabJobStartDate.Size = New Size(65, 15)
        LabJobStartDate.TabIndex = 271
        LabJobStartDate.Text = "Start Date"
        LabJobStartDate.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabVessel
        ' 
        LabVessel.AutoSize = True
        LabVessel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabVessel.ForeColor = SystemColors.HotTrack
        LabVessel.Location = New Point(1, 48)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(41, 15)
        LabVessel.TabIndex = 270
        LabVessel.Text = "Vessel"
        LabVessel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabCustomer
        ' 
        LabCustomer.AutoSize = True
        LabCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCustomer.ForeColor = SystemColors.HotTrack
        LabCustomer.Location = New Point(1, 27)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(61, 15)
        LabCustomer.TabIndex = 269
        LabCustomer.Text = "Customer"
        LabCustomer.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabJobNumber
        ' 
        LabJobNumber.AutoSize = True
        LabJobNumber.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabJobNumber.ForeColor = SystemColors.HotTrack
        LabJobNumber.Location = New Point(2, 0)
        LabJobNumber.Name = "LabJobNumber"
        LabJobNumber.Size = New Size(37, 21)
        LabJobNumber.TabIndex = 268
        LabJobNumber.Text = "Job"
        LabJobNumber.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabJobDescription
        ' 
        LabJobDescription.AutoSize = True
        LabJobDescription.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobDescription.ForeColor = SystemColors.HotTrack
        LabJobDescription.Location = New Point(1, 111)
        LabJobDescription.Name = "LabJobDescription"
        LabJobDescription.Size = New Size(71, 15)
        LabJobDescription.TabIndex = 273
        LabJobDescription.Text = "Description"
        LabJobDescription.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TxtVessel
        ' 
        TxtVessel.BackColor = SystemColors.Control
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.DataBindings.Add(New Binding("Text", JobsBindingSource, "Vessel.VesselName", True))
        TxtVessel.Location = New Point(92, 48)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(190, 16)
        TxtVessel.TabIndex = 264
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.BackColor = SystemColors.Control
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.DataBindings.Add(New Binding("Text", JobsBindingSource, "Vessel.Customer.CustomerName", True))
        TxtCustomer.Location = New Point(92, 27)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(190, 16)
        TxtCustomer.TabIndex = 263
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BackColor = SystemColors.Control
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.DataBindings.Add(New Binding("Text", JobsBindingSource, "JobNumber", True))
        TxtJobNumber.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        TxtJobNumber.Location = New Point(92, 0)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.ReadOnly = True
        TxtJobNumber.Size = New Size(190, 22)
        TxtJobNumber.TabIndex = 262
        ' 
        ' DataGridCell
        ' 
        DataGridCell.AllowUserToAddRows = False
        DataGridCell.AllowUserToDeleteRows = False
        DataGridCell.AutoGenerateColumns = False
        DataGridCell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridCell.Columns.AddRange(New DataGridViewColumn() {AngleDataGridViewTextBoxColumn, DepthDataGridViewTextBoxColumn})
        DataGridCell.DataSource = CellMeasurementsBindingSource
        DataGridCell.Location = New Point(1011, 30)
        DataGridCell.Name = "DataGridCell"
        DataGridCell.ReadOnly = True
        DataGridCell.Size = New Size(284, 628)
        DataGridCell.TabIndex = 268
        ' 
        ' AngleDataGridViewTextBoxColumn
        ' 
        AngleDataGridViewTextBoxColumn.DataPropertyName = "Angle"
        AngleDataGridViewTextBoxColumn.HeaderText = "Angle"
        AngleDataGridViewTextBoxColumn.MinimumWidth = 120
        AngleDataGridViewTextBoxColumn.Name = "AngleDataGridViewTextBoxColumn"
        AngleDataGridViewTextBoxColumn.ReadOnly = True
        AngleDataGridViewTextBoxColumn.Width = 120
        ' 
        ' DepthDataGridViewTextBoxColumn
        ' 
        DepthDataGridViewTextBoxColumn.DataPropertyName = "Depth"
        DepthDataGridViewTextBoxColumn.HeaderText = "Depth"
        DepthDataGridViewTextBoxColumn.MinimumWidth = 120
        DepthDataGridViewTextBoxColumn.Name = "DepthDataGridViewTextBoxColumn"
        DepthDataGridViewTextBoxColumn.ReadOnly = True
        DepthDataGridViewTextBoxColumn.Width = 120
        ' 
        ' DataGridExtreme
        ' 
        DataGridExtreme.AllowUserToAddRows = False
        DataGridExtreme.AllowUserToDeleteRows = False
        DataGridExtreme.AutoGenerateColumns = False
        DataGridExtreme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridExtreme.Columns.AddRange(New DataGridViewColumn() {BladeIdDataGridViewTextBoxColumn1, ExtremeDataGridViewTextBoxColumn})
        DataGridExtreme.DataSource = ExtremeMeasurementsBindingSource
        DataGridExtreme.Location = New Point(646, 360)
        DataGridExtreme.Name = "DataGridExtreme"
        DataGridExtreme.ReadOnly = True
        DataGridExtreme.Size = New Size(359, 295)
        DataGridExtreme.TabIndex = 269
        ' 
        ' BladeIdDataGridViewTextBoxColumn1
        ' 
        BladeIdDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        BladeIdDataGridViewTextBoxColumn1.DataPropertyName = "BladeId"
        BladeIdDataGridViewTextBoxColumn1.HeaderText = "Blade"
        BladeIdDataGridViewTextBoxColumn1.Name = "BladeIdDataGridViewTextBoxColumn1"
        BladeIdDataGridViewTextBoxColumn1.ReadOnly = True
        BladeIdDataGridViewTextBoxColumn1.Width = 61
        ' 
        ' ExtremeDataGridViewTextBoxColumn
        ' 
        ExtremeDataGridViewTextBoxColumn.DataPropertyName = "Extreme"
        ExtremeDataGridViewTextBoxColumn.HeaderText = "Extreme"
        ExtremeDataGridViewTextBoxColumn.MinimumWidth = 120
        ExtremeDataGridViewTextBoxColumn.Name = "ExtremeDataGridViewTextBoxColumn"
        ExtremeDataGridViewTextBoxColumn.ReadOnly = True
        ExtremeDataGridViewTextBoxColumn.Width = 120
        ' 
        ' PanelJobData
        ' 
        PanelJobData.AutoSize = True
        PanelJobData.BorderStyle = BorderStyle.Fixed3D
        PanelJobData.Controls.Add(LabWheelPitch)
        PanelJobData.Controls.Add(TxtWheelPitch)
        PanelJobData.Controls.Add(LabDesiredPitch)
        PanelJobData.Controls.Add(LabMarkedPitch)
        PanelJobData.Controls.Add(TxtDesiredPitch)
        PanelJobData.Controls.Add(TxtMarkedPitch)
        PanelJobData.Controls.Add(LabTEExclusion)
        PanelJobData.Controls.Add(LabLEExclusion)
        PanelJobData.Controls.Add(ComboTeExclusion)
        PanelJobData.Controls.Add(ComboLEExclusion)
        PanelJobData.Location = New Point(327, 12)
        PanelJobData.Name = "PanelJobData"
        PanelJobData.Size = New Size(291, 156)
        PanelJobData.TabIndex = 270
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.AutoSize = True
        LabWheelPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabWheelPitch.Location = New Point(1, 64)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(74, 15)
        LabWheelPitch.TabIndex = 246
        LabWheelPitch.Text = "Wheel Pitch"
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.DataBindings.Add(New Binding("Text", JobsBindingSource, "WheelPitch", True))
        TxtWheelPitch.Location = New Point(94, 61)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.Size = New Size(190, 23)
        TxtWheelPitch.TabIndex = 245
        ' 
        ' LabDesiredPitch
        ' 
        LabDesiredPitch.AutoSize = True
        LabDesiredPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDesiredPitch.Location = New Point(1, 35)
        LabDesiredPitch.Name = "LabDesiredPitch"
        LabDesiredPitch.Size = New Size(81, 15)
        LabDesiredPitch.TabIndex = 244
        LabDesiredPitch.Text = "Desired Pitch"
        ' 
        ' LabMarkedPitch
        ' 
        LabMarkedPitch.AutoSize = True
        LabMarkedPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMarkedPitch.Location = New Point(1, 6)
        LabMarkedPitch.Name = "LabMarkedPitch"
        LabMarkedPitch.Size = New Size(81, 15)
        LabMarkedPitch.TabIndex = 243
        LabMarkedPitch.Text = "Marked Pitch"
        ' 
        ' TxtDesiredPitch
        ' 
        TxtDesiredPitch.DataBindings.Add(New Binding("Text", JobsBindingSource, "DesiredPitch", True))
        TxtDesiredPitch.Location = New Point(94, 32)
        TxtDesiredPitch.Name = "TxtDesiredPitch"
        TxtDesiredPitch.Size = New Size(190, 23)
        TxtDesiredPitch.TabIndex = 242
        ' 
        ' TxtMarkedPitch
        ' 
        TxtMarkedPitch.DataBindings.Add(New Binding("Text", JobsBindingSource, "MarkedPitch", True))
        TxtMarkedPitch.Location = New Point(93, 3)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.Size = New Size(190, 23)
        TxtMarkedPitch.TabIndex = 241
        ' 
        ' LabTEExclusion
        ' 
        LabTEExclusion.AutoSize = True
        LabTEExclusion.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabTEExclusion.Location = New Point(1, 123)
        LabTEExclusion.Name = "LabTEExclusion"
        LabTEExclusion.Size = New Size(74, 15)
        LabTEExclusion.TabIndex = 240
        LabTEExclusion.Text = "TE Exclusion"
        ' 
        ' LabLEExclusion
        ' 
        LabLEExclusion.AutoSize = True
        LabLEExclusion.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabLEExclusion.Location = New Point(1, 93)
        LabLEExclusion.Name = "LabLEExclusion"
        LabLEExclusion.Size = New Size(73, 15)
        LabLEExclusion.TabIndex = 239
        LabLEExclusion.Text = "LE Exclusion"
        ' 
        ' ComboTeExclusion
        ' 
        ComboTeExclusion.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "TeExclusion", True))
        ComboTeExclusion.DataSource = TeExclusionsBindingSource
        ComboTeExclusion.DisplayMember = "Exclusion1"
        ComboTeExclusion.FormattingEnabled = True
        ComboTeExclusion.Location = New Point(94, 119)
        ComboTeExclusion.Name = "ComboTeExclusion"
        ComboTeExclusion.Size = New Size(190, 23)
        ComboTeExclusion.TabIndex = 238
        ComboTeExclusion.ValueMember = "Exclusion1"
        ' 
        ' ComboLEExclusion
        ' 
        ComboLEExclusion.DataBindings.Add(New Binding("SelectedValue", JobsBindingSource, "LeExclusion", True))
        ComboLEExclusion.DataSource = LeExclusionsBindingSource
        ComboLEExclusion.DisplayMember = "Exclusion1"
        ComboLEExclusion.FormattingEnabled = True
        ComboLEExclusion.Location = New Point(94, 90)
        ComboLEExclusion.Name = "ComboLEExclusion"
        ComboLEExclusion.Size = New Size(190, 23)
        ComboLEExclusion.TabIndex = 237
        ComboLEExclusion.ValueMember = "Exclusion1"
        ' 
        ' LabRadiusMeasurements
        ' 
        LabRadiusMeasurements.AutoSize = True
        LabRadiusMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRadiusMeasurements.Location = New Point(645, 12)
        LabRadiusMeasurements.Name = "LabRadiusMeasurements"
        LabRadiusMeasurements.Size = New Size(129, 15)
        LabRadiusMeasurements.TabIndex = 271
        LabRadiusMeasurements.Text = "Radius Measurements"
        ' 
        ' LabCellMeasurements
        ' 
        LabCellMeasurements.AutoSize = True
        LabCellMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCellMeasurements.Location = New Point(1010, 12)
        LabCellMeasurements.Name = "LabCellMeasurements"
        LabCellMeasurements.Size = New Size(113, 15)
        LabCellMeasurements.TabIndex = 272
        LabCellMeasurements.Text = "Cell Measurements"
        ' 
        ' LabExtremeMeasurements
        ' 
        LabExtremeMeasurements.AutoSize = True
        LabExtremeMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabExtremeMeasurements.Location = New Point(645, 342)
        LabExtremeMeasurements.Name = "LabExtremeMeasurements"
        LabExtremeMeasurements.Size = New Size(141, 15)
        LabExtremeMeasurements.TabIndex = 273
        LabExtremeMeasurements.Text = "Extreme Measurements"
        ' 
        ' PanelMeasurement
        ' 
        PanelMeasurement.BorderStyle = BorderStyle.Fixed3D
        PanelMeasurement.Controls.Add(LabMeasurementType)
        PanelMeasurement.Controls.Add(LabSelectedBlade)
        PanelMeasurement.Controls.Add(ChkScan)
        PanelMeasurement.Controls.Add(ComboMeasurementType)
        PanelMeasurement.Controls.Add(ComboSelectedBlade)
        PanelMeasurement.Location = New Point(327, 195)
        PanelMeasurement.Name = "PanelMeasurement"
        PanelMeasurement.Size = New Size(291, 130)
        PanelMeasurement.TabIndex = 280
        ' 
        ' LabMeasurementType
        ' 
        LabMeasurementType.AutoSize = True
        LabMeasurementType.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMeasurementType.Location = New Point(4, 36)
        LabMeasurementType.Name = "LabMeasurementType"
        LabMeasurementType.Size = New Size(85, 15)
        LabMeasurementType.TabIndex = 284
        LabMeasurementType.Text = "Measurement"
        ' 
        ' LabSelectedBlade
        ' 
        LabSelectedBlade.AutoSize = True
        LabSelectedBlade.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabSelectedBlade.Location = New Point(4, 7)
        LabSelectedBlade.Name = "LabSelectedBlade"
        LabSelectedBlade.Size = New Size(38, 15)
        LabSelectedBlade.TabIndex = 283
        LabSelectedBlade.Text = "Blade"
        ' 
        ' ChkScan
        ' 
        ChkScan.Appearance = Appearance.Button
        ChkScan.AutoSize = True
        ChkScan.Image = My.Resources.Resources.Measure
        ChkScan.Location = New Point(95, 101)
        ChkScan.Name = "ChkScan"
        ChkScan.Size = New Size(22, 22)
        ChkScan.TabIndex = 282
        ChkScan.UseVisualStyleBackColor = True
        ' 
        ' ComboMeasurementType
        ' 
        ComboMeasurementType.FormattingEnabled = True
        ComboMeasurementType.Location = New Point(95, 33)
        ComboMeasurementType.Name = "ComboMeasurementType"
        ComboMeasurementType.Size = New Size(185, 23)
        ComboMeasurementType.TabIndex = 281
        ' 
        ' ComboSelectedBlade
        ' 
        ComboSelectedBlade.FormattingEnabled = True
        ComboSelectedBlade.Location = New Point(95, 4)
        ComboSelectedBlade.Name = "ComboSelectedBlade"
        ComboSelectedBlade.Size = New Size(185, 23)
        ComboSelectedBlade.TabIndex = 280
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1305, 668)
        Controls.Add(PanelMeasurement)
        Controls.Add(LabExtremeMeasurements)
        Controls.Add(LabCellMeasurements)
        Controls.Add(LabRadiusMeasurements)
        Controls.Add(PanelJobData)
        Controls.Add(DataGridExtreme)
        Controls.Add(DataGridCell)
        Controls.Add(PanelJob)
        Controls.Add(PanelPropeller)
        Controls.Add(DataGridRadius)
        Name = "Form4"
        Text = "Form4"
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(TeExclusionsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(LeExclusionsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridRadius, ComponentModel.ISupportInitialize).EndInit()
        PanelPropeller.ResumeLayout(False)
        PanelPropeller.PerformLayout()
        PanelJob.ResumeLayout(False)
        PanelJob.PerformLayout()
        CType(DataGridCell, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridExtreme, ComponentModel.ISupportInitialize).EndInit()
        PanelJobData.ResumeLayout(False)
        PanelJobData.PerformLayout()
        PanelMeasurement.ResumeLayout(False)
        PanelMeasurement.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents CellMeasurementsBindingSource As BindingSource
    Friend WithEvents ExtremeMeasurementsBindingSource As BindingSource
    Friend WithEvents RadiusMeasurementBindingSource As BindingSource
    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents LeExclusionsBindingSource As BindingSource
    Friend WithEvents TeExclusionsBindingSource As BindingSource
    Friend WithEvents DataGridRadius As DataGridView
    Friend WithEvents BladeIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RadiusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LeCellDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TeCellDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PanelPropeller As Panel
    Friend WithEvents TxtBlades As TextBox
    Friend WithEvents TxtRotation As TextBox
    Friend WithEvents LabBlades As Label
    Friend WithEvents LabRotation As Label
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents LabMaterial As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents LabBore As Label
    Friend WithEvents LabDiameter As Label
    Friend WithEvents PanelJob As Panel
    Friend WithEvents TxtJobDescription As TextBox
    Friend WithEvents TxtInspectedBy As TextBox
    Friend WithEvents TxtJobStartDate As TextBox
    Friend WithEvents LabInspectedBy As Label
    Friend WithEvents LabJobStartDate As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents LabJobNumber As Label
    Friend WithEvents LabJobDescription As Label
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents DataGridCell As DataGridView
    Friend WithEvents DataGridExtreme As DataGridView
    Friend WithEvents BladeIdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ExtremeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AngleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DepthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PanelJobData As Panel
    Friend WithEvents LabWheelPitch As Label
    Friend WithEvents TxtWheelPitch As TextBox
    Friend WithEvents LabDesiredPitch As Label
    Friend WithEvents LabMarkedPitch As Label
    Friend WithEvents TxtDesiredPitch As TextBox
    Friend WithEvents TxtMarkedPitch As TextBox
    Friend WithEvents LabTEExclusion As Label
    Friend WithEvents LabLEExclusion As Label
    Friend WithEvents ComboTeExclusion As ComboBox
    Friend WithEvents ComboLEExclusion As ComboBox
    Friend WithEvents LabRadiusMeasurements As Label
    Friend WithEvents LabCellMeasurements As Label
    Friend WithEvents LabExtremeMeasurements As Label
    Friend WithEvents PanelMeasurement As Panel
    Friend WithEvents LabMeasurementType As Label
    Friend WithEvents LabSelectedBlade As Label
    Friend WithEvents ChkScan As CheckBox
    Friend WithEvents ComboMeasurementType As ComboBox
    Friend WithEvents ComboSelectedBlade As ComboBox
End Class
