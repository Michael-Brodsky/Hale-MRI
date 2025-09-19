<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        RecordNavigationBar1 = New RecordNavigationBar()
        EncoderStatusStrip1 = New EncoderStatusStrip()
        JobDetailsBindingSource = New BindingSource(components)
        CellMeasurementsBindingSource = New BindingSource(components)
        ExtremeMeasurementsBindingSource = New BindingSource(components)
        RadiusMeasurementBindingSource = New BindingSource(components)
        DataGridJobDetails = New DataGridView()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        MeasurementTypesBindingSource = New BindingSource(components)
        ToleranceClassDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        ClassBindingSource = New BindingSource(components)
        PerformedByDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        EmployeesBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        TxtJobNumber = New TextBox()
        PanelJob = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtBlades = New TextBox()
        TxtDiameter = New TextBox()
        TxtBore = New TextBox()
        TxtCustomer = New TextBox()
        PanelMeasurements = New Panel()
        LabBladeRadius = New Label()
        DataGridBladeRadius = New DataGridView()
        BladeId = New DataGridViewTextBoxColumn()
        AvgRadius = New DataGridViewTextBoxColumn()
        BladeRadiusBindingSource = New BindingSource(components)
        CmdUndoMeasurement = New Button()
        CmdSaveMeasurement = New Button()
        LabWheelPitch = New Label()
        TxtWheelPitch = New TextBox()
        CmdHomeEncoders = New Button()
        LabBlade = New Label()
        ComboBlade = New ComboBox()
        LabRadiusPercent = New Label()
        TxtRadiusPercent = New TextBox()
        ChkAutoScan = New CheckBox()
        LabDepth = New Label()
        TxtDepth = New TextBox()
        LabRadius = New Label()
        TxtRadius = New TextBox()
        LabAngle = New Label()
        TxtAngle = New TextBox()
        PictureBoxLogo = New PictureBox()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelJob.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        PanelMeasurements.SuspendLayout()
        CType(DataGridBladeRadius, ComponentModel.ISupportInitialize).BeginInit()
        CType(BladeRadiusBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(479, 11)
        RecordNavigationBar1.Margin = New Padding(0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(635, 24)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' EncoderStatusStrip1
        ' 
        EncoderStatusStrip1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        EncoderStatusStrip1.Hardware = Nothing
        EncoderStatusStrip1.Location = New Point(-1, 648)
        EncoderStatusStrip1.Name = "EncoderStatusStrip1"
        EncoderStatusStrip1.Size = New Size(1145, 23)
        EncoderStatusStrip1.TabIndex = 1
        EncoderStatusStrip1.TimerInterval = 100L
        EncoderStatusStrip1.TimerOn = False
        EncoderStatusStrip1.WorkstationName = ""
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
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridJobDetails.BorderStyle = BorderStyle.Fixed3D
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDateDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn, ToleranceClassDataGridViewTextBoxColumn, PerformedByDataGridViewTextBoxColumn, Description})
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Location = New Point(479, 48)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ScrollBars = ScrollBars.None
        DataGridJobDetails.Size = New Size(635, 50)
        DataGridJobDetails.TabIndex = 4
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Date"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 152
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.Width = 152
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "MeasurementTypeId"
        DescriptionDataGridViewTextBoxColumn.DataSource = MeasurementTypesBindingSource
        DescriptionDataGridViewTextBoxColumn.DisplayMember = "MeasurementType1"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Measurement"
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        DescriptionDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        DescriptionDataGridViewTextBoxColumn.ValueMember = "Id"
        ' 
        ' MeasurementTypesBindingSource
        ' 
        MeasurementTypesBindingSource.DataSource = GetType(LibDatabase.Models.MeasurementType)
        ' 
        ' ToleranceClassDataGridViewTextBoxColumn
        ' 
        ToleranceClassDataGridViewTextBoxColumn.DataPropertyName = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.DataSource = ClassBindingSource
        ToleranceClassDataGridViewTextBoxColumn.DisplayMember = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.HeaderText = "Class"
        ToleranceClassDataGridViewTextBoxColumn.MinimumWidth = 50
        ToleranceClassDataGridViewTextBoxColumn.Name = "ToleranceClassDataGridViewTextBoxColumn"
        ToleranceClassDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        ToleranceClassDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        ToleranceClassDataGridViewTextBoxColumn.ValueMember = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.Width = 50
        ' 
        ' ClassBindingSource
        ' 
        ClassBindingSource.DataSource = GetType(LibDatabase.Models.Tolerance)
        ' 
        ' PerformedByDataGridViewTextBoxColumn
        ' 
        PerformedByDataGridViewTextBoxColumn.DataPropertyName = "PerformedBy"
        PerformedByDataGridViewTextBoxColumn.DataSource = EmployeesBindingSource
        PerformedByDataGridViewTextBoxColumn.DisplayMember = "EmployeeName"
        PerformedByDataGridViewTextBoxColumn.HeaderText = "Performed By"
        PerformedByDataGridViewTextBoxColumn.MinimumWidth = 140
        PerformedByDataGridViewTextBoxColumn.Name = "PerformedByDataGridViewTextBoxColumn"
        PerformedByDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        PerformedByDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        PerformedByDataGridViewTextBoxColumn.ValueMember = "Id"
        PerformedByDataGridViewTextBoxColumn.Width = 140
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeesBindingSource.Sort = ""
        ' 
        ' Description
        ' 
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.MinimumWidth = 152
        Description.Name = "Description"
        Description.Width = 152
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BackColor = SystemColors.Control
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        TxtJobNumber.Location = New Point(215, 11)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.Size = New Size(258, 25)
        TxtJobNumber.TabIndex = 6
        TxtJobNumber.TextAlign = HorizontalAlignment.Right
        ' 
        ' PanelJob
        ' 
        PanelJob.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelJob.BorderStyle = BorderStyle.Fixed3D
        PanelJob.Controls.Add(TableLayoutPanel1)
        PanelJob.Location = New Point(12, 111)
        PanelJob.Name = "PanelJob"
        PanelJob.Size = New Size(191, 531)
        PanelJob.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(TxtVessel, 0, 1)
        TableLayoutPanel1.Controls.Add(TxtManufacturer, 0, 2)
        TableLayoutPanel1.Controls.Add(TxtStyle, 0, 3)
        TableLayoutPanel1.Controls.Add(TxtMaterial, 0, 4)
        TableLayoutPanel1.Controls.Add(TxtBlades, 0, 5)
        TableLayoutPanel1.Controls.Add(TxtDiameter, 0, 6)
        TableLayoutPanel1.Controls.Add(TxtBore, 0, 7)
        TableLayoutPanel1.Controls.Add(TxtCustomer, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 8
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(187, 120)
        TableLayoutPanel1.TabIndex = 6
        ' 
        ' TxtVessel
        ' 
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.Font = New Font("Segoe UI", 8F)
        TxtVessel.Location = New Point(3, 15)
        TxtVessel.Margin = New Padding(3, 0, 3, 0)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(177, 15)
        TxtVessel.TabIndex = 2
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.Font = New Font("Segoe UI", 8F)
        TxtManufacturer.Location = New Point(3, 30)
        TxtManufacturer.Margin = New Padding(3, 0, 3, 0)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(177, 15)
        TxtManufacturer.TabIndex = 4
        ' 
        ' TxtStyle
        ' 
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Font = New Font("Segoe UI", 8F)
        TxtStyle.Location = New Point(3, 45)
        TxtStyle.Margin = New Padding(3, 0, 3, 0)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(177, 15)
        TxtStyle.TabIndex = 0
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Font = New Font("Segoe UI", 8F)
        TxtMaterial.Location = New Point(3, 60)
        TxtMaterial.Margin = New Padding(3, 0, 3, 0)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(175, 15)
        TxtMaterial.TabIndex = 8
        ' 
        ' TxtBlades
        ' 
        TxtBlades.BorderStyle = BorderStyle.None
        TxtBlades.Font = New Font("Segoe UI", 8F)
        TxtBlades.Location = New Point(3, 75)
        TxtBlades.Margin = New Padding(3, 0, 3, 0)
        TxtBlades.Name = "TxtBlades"
        TxtBlades.ReadOnly = True
        TxtBlades.Size = New Size(175, 15)
        TxtBlades.TabIndex = 5
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.BorderStyle = BorderStyle.None
        TxtDiameter.Font = New Font("Segoe UI", 8F)
        TxtDiameter.Location = New Point(3, 90)
        TxtDiameter.Margin = New Padding(3, 0, 3, 0)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.ReadOnly = True
        TxtDiameter.Size = New Size(175, 15)
        TxtDiameter.TabIndex = 6
        ' 
        ' TxtBore
        ' 
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Font = New Font("Segoe UI", 8F)
        TxtBore.Location = New Point(3, 105)
        TxtBore.Margin = New Padding(3, 0, 3, 0)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(175, 15)
        TxtBore.TabIndex = 7
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.Font = New Font("Segoe UI", 8F)
        TxtCustomer.Location = New Point(3, 0)
        TxtCustomer.Margin = New Padding(3, 0, 3, 0)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(177, 15)
        TxtCustomer.TabIndex = 1
        ' 
        ' PanelMeasurements
        ' 
        PanelMeasurements.BorderStyle = BorderStyle.Fixed3D
        PanelMeasurements.Controls.Add(LabBladeRadius)
        PanelMeasurements.Controls.Add(DataGridBladeRadius)
        PanelMeasurements.Controls.Add(CmdUndoMeasurement)
        PanelMeasurements.Controls.Add(CmdSaveMeasurement)
        PanelMeasurements.Controls.Add(LabWheelPitch)
        PanelMeasurements.Controls.Add(TxtWheelPitch)
        PanelMeasurements.Controls.Add(CmdHomeEncoders)
        PanelMeasurements.Controls.Add(LabBlade)
        PanelMeasurements.Controls.Add(ComboBlade)
        PanelMeasurements.Controls.Add(LabRadiusPercent)
        PanelMeasurements.Controls.Add(TxtRadiusPercent)
        PanelMeasurements.Controls.Add(ChkAutoScan)
        PanelMeasurements.Controls.Add(LabDepth)
        PanelMeasurements.Controls.Add(TxtDepth)
        PanelMeasurements.Controls.Add(LabRadius)
        PanelMeasurements.Controls.Add(TxtRadius)
        PanelMeasurements.Controls.Add(LabAngle)
        PanelMeasurements.Controls.Add(TxtAngle)
        PanelMeasurements.Location = New Point(215, 111)
        PanelMeasurements.Name = "PanelMeasurements"
        PanelMeasurements.Size = New Size(905, 531)
        PanelMeasurements.TabIndex = 8
        ' 
        ' LabBladeRadius
        ' 
        LabBladeRadius.AutoSize = True
        LabBladeRadius.Location = New Point(12, 116)
        LabBladeRadius.Name = "LabBladeRadius"
        LabBladeRadius.Size = New Size(74, 15)
        LabBladeRadius.TabIndex = 18
        LabBladeRadius.Text = "Blade Radius"
        ' 
        ' DataGridBladeRadius
        ' 
        DataGridBladeRadius.AutoGenerateColumns = False
        DataGridBladeRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridBladeRadius.Columns.AddRange(New DataGridViewColumn() {BladeId, AvgRadius})
        DataGridBladeRadius.DataSource = BladeRadiusBindingSource
        DataGridBladeRadius.Location = New Point(12, 134)
        DataGridBladeRadius.Name = "DataGridBladeRadius"
        DataGridBladeRadius.Size = New Size(423, 150)
        DataGridBladeRadius.TabIndex = 17
        ' 
        ' BladeId
        ' 
        BladeId.DataPropertyName = "BladeId"
        BladeId.HeaderText = "Blade"
        BladeId.MinimumWidth = 60
        BladeId.Name = "BladeId"
        BladeId.ReadOnly = True
        BladeId.Width = 60
        ' 
        ' AvgRadius
        ' 
        AvgRadius.DataPropertyName = "AvgRadius"
        AvgRadius.HeaderText = "Radius"
        AvgRadius.MinimumWidth = 160
        AvgRadius.Name = "AvgRadius"
        AvgRadius.Width = 160
        ' 
        ' CmdUndoMeasurement
        ' 
        CmdUndoMeasurement.Enabled = False
        CmdUndoMeasurement.Image = My.Resources.Resources.Cancel
        CmdUndoMeasurement.Location = New Point(814, 30)
        CmdUndoMeasurement.Name = "CmdUndoMeasurement"
        CmdUndoMeasurement.Size = New Size(36, 23)
        CmdUndoMeasurement.TabIndex = 16
        CmdUndoMeasurement.UseVisualStyleBackColor = True
        ' 
        ' CmdSaveMeasurement
        ' 
        CmdSaveMeasurement.Enabled = False
        CmdSaveMeasurement.Image = CType(resources.GetObject("CmdSaveMeasurement.Image"), Image)
        CmdSaveMeasurement.Location = New Point(772, 30)
        CmdSaveMeasurement.Name = "CmdSaveMeasurement"
        CmdSaveMeasurement.Size = New Size(36, 23)
        CmdSaveMeasurement.TabIndex = 15
        CmdSaveMeasurement.UseVisualStyleBackColor = True
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.AutoSize = True
        LabWheelPitch.Location = New Point(441, 62)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(70, 15)
        LabWheelPitch.TabIndex = 13
        LabWheelPitch.Text = "Wheel Pitch"
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "WheelPitch", True))
        TxtWheelPitch.Location = New Point(441, 80)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.Size = New Size(173, 23)
        TxtWheelPitch.TabIndex = 12
        ' 
        ' CmdHomeEncoders
        ' 
        CmdHomeEncoders.Image = My.Resources.Resources.Home
        CmdHomeEncoders.ImageAlign = ContentAlignment.MiddleRight
        CmdHomeEncoders.Location = New Point(695, 30)
        CmdHomeEncoders.Name = "CmdHomeEncoders"
        CmdHomeEncoders.Size = New Size(71, 23)
        CmdHomeEncoders.TabIndex = 11
        CmdHomeEncoders.Text = "Home"
        CmdHomeEncoders.TextAlign = ContentAlignment.MiddleLeft
        CmdHomeEncoders.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdHomeEncoders.UseVisualStyleBackColor = True
        ' 
        ' LabBlade
        ' 
        LabBlade.AutoSize = True
        LabBlade.Location = New Point(12, 12)
        LabBlade.Name = "LabBlade"
        LabBlade.Size = New Size(36, 15)
        LabBlade.TabIndex = 10
        LabBlade.Text = "Blade"
        ' 
        ' ComboBlade
        ' 
        ComboBlade.FormattingEnabled = True
        ComboBlade.Location = New Point(12, 31)
        ComboBlade.Name = "ComboBlade"
        ComboBlade.Size = New Size(65, 23)
        ComboBlade.TabIndex = 9
        ' 
        ' LabRadiusPercent
        ' 
        LabRadiusPercent.AutoSize = True
        LabRadiusPercent.Location = New Point(262, 62)
        LabRadiusPercent.Name = "LabRadiusPercent"
        LabRadiusPercent.Size = New Size(85, 15)
        LabRadiusPercent.TabIndex = 8
        LabRadiusPercent.Text = "Radius Percent"
        ' 
        ' TxtRadiusPercent
        ' 
        TxtRadiusPercent.Location = New Point(262, 80)
        TxtRadiusPercent.Name = "TxtRadiusPercent"
        TxtRadiusPercent.Size = New Size(173, 23)
        TxtRadiusPercent.TabIndex = 7
        ' 
        ' ChkAutoScan
        ' 
        ChkAutoScan.Appearance = Appearance.Button
        ChkAutoScan.Image = My.Resources.Resources.Timer
        ChkAutoScan.ImageAlign = ContentAlignment.MiddleRight
        ChkAutoScan.Location = New Point(619, 30)
        ChkAutoScan.Margin = New Padding(2, 1, 2, 1)
        ChkAutoScan.Name = "ChkAutoScan"
        ChkAutoScan.Size = New Size(71, 23)
        ChkAutoScan.TabIndex = 6
        ChkAutoScan.Text = "Start"
        ChkAutoScan.TextImageRelation = TextImageRelation.ImageBeforeText
        ChkAutoScan.UseVisualStyleBackColor = True
        ' 
        ' LabDepth
        ' 
        LabDepth.AutoSize = True
        LabDepth.Location = New Point(441, 12)
        LabDepth.Name = "LabDepth"
        LabDepth.Size = New Size(39, 15)
        LabDepth.TabIndex = 5
        LabDepth.Text = "Depth"
        ' 
        ' TxtDepth
        ' 
        TxtDepth.Location = New Point(441, 30)
        TxtDepth.Name = "TxtDepth"
        TxtDepth.Size = New Size(173, 23)
        TxtDepth.TabIndex = 4
        ' 
        ' LabRadius
        ' 
        LabRadius.AutoSize = True
        LabRadius.Location = New Point(262, 12)
        LabRadius.Name = "LabRadius"
        LabRadius.Size = New Size(42, 15)
        LabRadius.TabIndex = 3
        LabRadius.Text = "Radius"
        ' 
        ' TxtRadius
        ' 
        TxtRadius.Location = New Point(262, 30)
        TxtRadius.Name = "TxtRadius"
        TxtRadius.Size = New Size(173, 23)
        TxtRadius.TabIndex = 2
        ' 
        ' LabAngle
        ' 
        LabAngle.AutoSize = True
        LabAngle.Location = New Point(83, 12)
        LabAngle.Name = "LabAngle"
        LabAngle.Size = New Size(38, 15)
        LabAngle.TabIndex = 1
        LabAngle.Text = "Angle"
        ' 
        ' TxtAngle
        ' 
        TxtAngle.Location = New Point(83, 30)
        TxtAngle.Name = "TxtAngle"
        TxtAngle.Size = New Size(173, 23)
        TxtAngle.TabIndex = 0
        ' 
        ' PictureBoxLogo
        ' 
        PictureBoxLogo.Image = CType(resources.GetObject("PictureBoxLogo.Image"), Image)
        PictureBoxLogo.InitialImage = CType(resources.GetObject("PictureBoxLogo.InitialImage"), Image)
        PictureBoxLogo.Location = New Point(12, 12)
        PictureBoxLogo.Name = "PictureBoxLogo"
        PictureBoxLogo.Size = New Size(189, 86)
        PictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxLogo.TabIndex = 9
        PictureBoxLogo.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1131, 671)
        Controls.Add(PictureBoxLogo)
        Controls.Add(PanelMeasurements)
        Controls.Add(PanelJob)
        Controls.Add(TxtJobNumber)
        Controls.Add(DataGridJobDetails)
        Controls.Add(EncoderStatusStrip1)
        Controls.Add(RecordNavigationBar1)
        Name = "Form1"
        Text = "Measurements"
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelJob.ResumeLayout(False)
        PanelJob.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        PanelMeasurements.ResumeLayout(False)
        PanelMeasurements.PerformLayout()
        CType(DataGridBladeRadius, ComponentModel.ISupportInitialize).EndInit()
        CType(BladeRadiusBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents EncoderStatusStrip1 As EncoderStatusStrip
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents CellMeasurementsBindingSource As BindingSource
    Friend WithEvents ExtremeMeasurementsBindingSource As BindingSource
    Friend WithEvents RadiusMeasurementBindingSource As BindingSource
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ClassBindingSource As BindingSource
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents PanelJob As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtBlades As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents PanelMeasurements As Panel
    Friend WithEvents LabDepth As Label
    Friend WithEvents TxtDepth As TextBox
    Friend WithEvents LabRadius As Label
    Friend WithEvents TxtRadius As TextBox
    Friend WithEvents LabAngle As Label
    Friend WithEvents TxtAngle As TextBox
    Friend WithEvents ChkAutoScan As CheckBox
    Friend WithEvents LabRadiusPercent As Label
    Friend WithEvents TxtRadiusPercent As TextBox
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents MeasurementTypesBindingSource As BindingSource
    Friend WithEvents LabBlade As Label
    Friend WithEvents ComboBlade As ComboBox
    Friend WithEvents CmdHomeEncoders As Button
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents ToleranceClassDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents PerformedByDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents LabWheelPitch As Label
    Friend WithEvents TxtWheelPitch As TextBox
    Friend WithEvents CmdUndoMeasurement As Button
    Friend WithEvents CmdSaveMeasurement As Button
    Friend WithEvents DataGridBladeRadius As DataGridView
    Friend WithEvents LabBladeRadius As Label
    Friend WithEvents BladeRadiusBindingSource As BindingSource
    Friend WithEvents BladeId As DataGridViewTextBoxColumn
    Friend WithEvents AvgRadius As DataGridViewTextBoxColumn
End Class
