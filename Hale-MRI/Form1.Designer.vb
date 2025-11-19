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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        RecordNavigationBar1 = New RecordNavigationBar()
        EncoderStatusStrip1 = New EncoderStatusStrip()
        JobDetailsBindingSource = New BindingSource(components)
        DataGridJobDetails = New DataGridView()
        StartDate = New DataGridViewTextBoxColumn()
        MeasurementTypeDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        MeasurementTypesBindingSource = New BindingSource(components)
        ToleranceClassDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        ClassBindingSource = New BindingSource(components)
        PerformedBy = New DataGridViewComboBoxColumn()
        EmployeesBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        PanelJob = New Panel()
        TxtJobNumber = New TextBox()
        tLayoutJobInfo = New TableLayoutPanel()
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtBlades = New TextBox()
        TxtDiameter = New TextBox()
        TxtBore = New TextBox()
        TxtCustomer = New TextBox()
        PanelMeasurements = New Panel()
        GridBladePitch = New DataGridView()
        CmdZero = New Button()
        CmdSetTip = New Button()
        CmdHome = New Button()
        LabAvgBladePitch = New Label()
        ChkScan = New CheckBox()
        LabAngle = New Label()
        LabWheelPitch = New Label()
        LabRadiusPercent = New Label()
        LabOffsetToHub = New Label()
        LabDepth = New Label()
        LabRadius = New Label()
        LabBlade = New Label()
        TxtWheelPitch = New TextBox()
        TxtRadiusPercent = New TextBox()
        ComboOffsetToHub = New ComboBox()
        TxtBlade = New TextBox()
        TxtRadius = New TextBox()
        TxtDepth = New TextBox()
        TxtAngle = New TextBox()
        GridBladebyRadius = New DataGridView()
        PictureBoxLogo = New PictureBox()
        PanelTrack = New Panel()
        tLayoutTrack = New TableLayoutPanel()
        ChartBladeHeight = New DataVisualization.Charting.Chart()
        ChartAngularPosition = New DataVisualization.Charting.Chart()
        LabRefBlade = New Label()
        ComboReferenceBlade = New ComboBox()
        LabRefPoint = New Label()
        LabRefRadius = New Label()
        ComboReferenceRadius = New ComboBox()
        LabRake = New Label()
        ComboReferencePoint = New ComboBox()
        TxtRake = New TextBox()
        PanelPlot = New Panel()
        chartPlot = New DataVisualization.Charting.Chart()
        LabTrackPanel = New Label()
        LabPanelPlot = New Label()
        LabPanelMeasurements = New Label()
        LabPanelJob = New Label()
        ComboPitchBasis = New ComboBox()
        ComboTolerance = New ComboBox()
        LabPitchBasis = New Label()
        LabTolerance = New Label()
        TxtBasis = New TextBox()
        LabBasis = New Label()
        PanelLocalPitchDetails = New Panel()
        tLayoutLocalPitchDetails = New TableLayoutPanel()
        LabPrintPitch = New Label()
        CmdPrintClassS = New Button()
        CmdPrintClassI = New Button()
        CmdPrintClassII = New Button()
        CmdPrintClassIII = New Button()
        CmdPrintClassCustom = New Button()
        ChkAllowProgPitch = New CheckBox()
        ChkMinimumsApply = New CheckBox()
        ChkDisplayOnly = New CheckBox()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelJob.SuspendLayout()
        tLayoutJobInfo.SuspendLayout()
        PanelMeasurements.SuspendLayout()
        CType(GridBladePitch, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).BeginInit()
        PanelTrack.SuspendLayout()
        tLayoutTrack.SuspendLayout()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).BeginInit()
        PanelPlot.SuspendLayout()
        CType(chartPlot, ComponentModel.ISupportInitialize).BeginInit()
        PanelLocalPitchDetails.SuspendLayout()
        tLayoutLocalPitchDetails.SuspendLayout()
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
        RecordNavigationBar1.Location = New Point(462, 12)
        RecordNavigationBar1.Margin = New Padding(0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(644, 24)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' EncoderStatusStrip1
        ' 
        EncoderStatusStrip1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        EncoderStatusStrip1.Dock = DockStyle.Bottom
        EncoderStatusStrip1.Hardware = Nothing
        EncoderStatusStrip1.Location = New Point(0, 780)
        EncoderStatusStrip1.Name = "EncoderStatusStrip1"
        EncoderStatusStrip1.Size = New Size(1115, 23)
        EncoderStatusStrip1.TabIndex = 1
        EncoderStatusStrip1.TimerInterval = 100L
        EncoderStatusStrip1.TimerOn = False
        EncoderStatusStrip1.WorkstationName = ""
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridJobDetails.BorderStyle = BorderStyle.Fixed3D
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDate, MeasurementTypeDataGridViewTextBoxColumn, ToleranceClassDataGridViewTextBoxColumn, PerformedBy, Description})
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Location = New Point(462, 48)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ScrollBars = ScrollBars.None
        DataGridJobDetails.Size = New Size(635, 50)
        DataGridJobDetails.TabIndex = 4
        ' 
        ' StartDate
        ' 
        StartDate.DataPropertyName = "StartDate"
        StartDate.HeaderText = "Start Date"
        StartDate.MinimumWidth = 120
        StartDate.Name = "StartDate"
        StartDate.Width = 120
        ' 
        ' MeasurementTypeDataGridViewTextBoxColumn
        ' 
        MeasurementTypeDataGridViewTextBoxColumn.DataPropertyName = "MeasurementTypeId"
        MeasurementTypeDataGridViewTextBoxColumn.DataSource = MeasurementTypesBindingSource
        MeasurementTypeDataGridViewTextBoxColumn.DisplayMember = "MeasurementType1"
        MeasurementTypeDataGridViewTextBoxColumn.HeaderText = "Measurement"
        MeasurementTypeDataGridViewTextBoxColumn.MinimumWidth = 90
        MeasurementTypeDataGridViewTextBoxColumn.Name = "MeasurementTypeDataGridViewTextBoxColumn"
        MeasurementTypeDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        MeasurementTypeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        MeasurementTypeDataGridViewTextBoxColumn.ValueMember = "Id"
        MeasurementTypeDataGridViewTextBoxColumn.Width = 90
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
        ToleranceClassDataGridViewTextBoxColumn.MinimumWidth = 60
        ToleranceClassDataGridViewTextBoxColumn.Name = "ToleranceClassDataGridViewTextBoxColumn"
        ToleranceClassDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        ToleranceClassDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        ToleranceClassDataGridViewTextBoxColumn.ValueMember = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.Width = 60
        ' 
        ' ClassBindingSource
        ' 
        ClassBindingSource.DataSource = GetType(LibDatabase.Models.Tolerance)
        ' 
        ' PerformedBy
        ' 
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeesBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.HeaderText = "Employee"
        PerformedBy.MinimumWidth = 130
        PerformedBy.Name = "PerformedBy"
        PerformedBy.Resizable = DataGridViewTriState.True
        PerformedBy.SortMode = DataGridViewColumnSortMode.Automatic
        PerformedBy.ValueMember = "Id"
        PerformedBy.Width = 130
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
        Description.Name = "Description"
        Description.Width = 200
        ' 
        ' PanelJob
        ' 
        PanelJob.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelJob.BorderStyle = BorderStyle.Fixed3D
        PanelJob.Controls.Add(TxtJobNumber)
        PanelJob.Controls.Add(tLayoutJobInfo)
        PanelJob.Location = New Point(12, 131)
        PanelJob.Name = "PanelJob"
        PanelJob.Size = New Size(191, 641)
        PanelJob.TabIndex = 7
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BackColor = SystemColors.Control
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TxtJobNumber.Location = New Point(3, 0)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.Size = New Size(184, 50)
        TxtJobNumber.TabIndex = 7
        ' 
        ' tLayoutJobInfo
        ' 
        tLayoutJobInfo.AutoSize = True
        tLayoutJobInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tLayoutJobInfo.ColumnCount = 2
        tLayoutJobInfo.ColumnStyles.Add(New ColumnStyle())
        tLayoutJobInfo.ColumnStyles.Add(New ColumnStyle())
        tLayoutJobInfo.Controls.Add(TxtVessel, 0, 1)
        tLayoutJobInfo.Controls.Add(TxtManufacturer, 0, 2)
        tLayoutJobInfo.Controls.Add(TxtStyle, 0, 3)
        tLayoutJobInfo.Controls.Add(TxtMaterial, 0, 4)
        tLayoutJobInfo.Controls.Add(TxtBlades, 0, 5)
        tLayoutJobInfo.Controls.Add(TxtDiameter, 0, 6)
        tLayoutJobInfo.Controls.Add(TxtBore, 0, 7)
        tLayoutJobInfo.Controls.Add(TxtCustomer, 0, 0)
        tLayoutJobInfo.Location = New Point(3, 56)
        tLayoutJobInfo.Name = "tLayoutJobInfo"
        tLayoutJobInfo.RowCount = 8
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.RowStyles.Add(New RowStyle())
        tLayoutJobInfo.Size = New Size(183, 120)
        tLayoutJobInfo.TabIndex = 6
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
        PanelMeasurements.Controls.Add(GridBladePitch)
        PanelMeasurements.Controls.Add(CmdZero)
        PanelMeasurements.Controls.Add(CmdSetTip)
        PanelMeasurements.Controls.Add(CmdHome)
        PanelMeasurements.Controls.Add(LabAvgBladePitch)
        PanelMeasurements.Controls.Add(ChkScan)
        PanelMeasurements.Controls.Add(LabAngle)
        PanelMeasurements.Controls.Add(LabWheelPitch)
        PanelMeasurements.Controls.Add(LabRadiusPercent)
        PanelMeasurements.Controls.Add(LabOffsetToHub)
        PanelMeasurements.Controls.Add(LabDepth)
        PanelMeasurements.Controls.Add(LabRadius)
        PanelMeasurements.Controls.Add(LabBlade)
        PanelMeasurements.Controls.Add(TxtWheelPitch)
        PanelMeasurements.Controls.Add(TxtRadiusPercent)
        PanelMeasurements.Controls.Add(ComboOffsetToHub)
        PanelMeasurements.Controls.Add(TxtBlade)
        PanelMeasurements.Controls.Add(TxtRadius)
        PanelMeasurements.Controls.Add(TxtDepth)
        PanelMeasurements.Controls.Add(TxtAngle)
        PanelMeasurements.Controls.Add(GridBladebyRadius)
        PanelMeasurements.Location = New Point(209, 131)
        PanelMeasurements.Name = "PanelMeasurements"
        PanelMeasurements.Size = New Size(588, 410)
        PanelMeasurements.TabIndex = 8
        ' 
        ' GridBladePitch
        ' 
        GridBladePitch.AllowUserToAddRows = False
        GridBladePitch.AllowUserToDeleteRows = False
        GridBladePitch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        GridBladePitch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladePitch.Location = New Point(495, 226)
        GridBladePitch.Name = "GridBladePitch"
        GridBladePitch.RowHeadersVisible = False
        GridBladePitch.Size = New Size(89, 177)
        GridBladePitch.TabIndex = 22
        ' 
        ' CmdZero
        ' 
        CmdZero.Image = My.Resources.Resources.SendtoBack
        CmdZero.ImageAlign = ContentAlignment.MiddleRight
        CmdZero.Location = New Point(509, 161)
        CmdZero.Name = "CmdZero"
        CmdZero.Size = New Size(70, 25)
        CmdZero.TabIndex = 21
        CmdZero.Text = "Zero"
        CmdZero.TextAlign = ContentAlignment.MiddleLeft
        CmdZero.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdZero.UseVisualStyleBackColor = True
        ' 
        ' CmdSetTip
        ' 
        CmdSetTip.Image = My.Resources.Resources.SettingsPanel
        CmdSetTip.ImageAlign = ContentAlignment.MiddleRight
        CmdSetTip.Location = New Point(433, 161)
        CmdSetTip.Name = "CmdSetTip"
        CmdSetTip.Size = New Size(70, 25)
        CmdSetTip.TabIndex = 20
        CmdSetTip.Text = "Set Tip"
        CmdSetTip.TextAlign = ContentAlignment.MiddleLeft
        CmdSetTip.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdSetTip.UseVisualStyleBackColor = True
        ' 
        ' CmdHome
        ' 
        CmdHome.Image = My.Resources.Resources.Home
        CmdHome.ImageAlign = ContentAlignment.MiddleRight
        CmdHome.Location = New Point(357, 161)
        CmdHome.Name = "CmdHome"
        CmdHome.Size = New Size(70, 25)
        CmdHome.TabIndex = 19
        CmdHome.Text = "Home"
        CmdHome.TextAlign = ContentAlignment.MiddleLeft
        CmdHome.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdHome.UseVisualStyleBackColor = True
        ' 
        ' LabAvgBladePitch
        ' 
        LabAvgBladePitch.AutoSize = True
        LabAvgBladePitch.Location = New Point(3, 208)
        LabAvgBladePitch.Name = "LabAvgBladePitch"
        LabAvgBladePitch.Size = New Size(90, 15)
        LabAvgBladePitch.TabIndex = 18
        LabAvgBladePitch.Text = "Avg Blade Pitch"
        ' 
        ' ChkScan
        ' 
        ChkScan.Appearance = Appearance.Button
        ChkScan.Image = My.Resources.Resources.Timer
        ChkScan.ImageAlign = ContentAlignment.MiddleRight
        ChkScan.Location = New Point(251, 161)
        ChkScan.Name = "ChkScan"
        ChkScan.Size = New Size(70, 25)
        ChkScan.TabIndex = 17
        ChkScan.Text = " Scan"
        ChkScan.TextImageRelation = TextImageRelation.ImageBeforeText
        ChkScan.UseVisualStyleBackColor = True
        ' 
        ' LabAngle
        ' 
        LabAngle.AutoSize = True
        LabAngle.Location = New Point(3, 7)
        LabAngle.Name = "LabAngle"
        LabAngle.Size = New Size(38, 15)
        LabAngle.TabIndex = 16
        LabAngle.Text = "Angle"
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.AutoSize = True
        LabWheelPitch.Location = New Point(418, 78)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(70, 15)
        LabWheelPitch.TabIndex = 15
        LabWheelPitch.Text = "Wheel Pitch"
        ' 
        ' LabRadiusPercent
        ' 
        LabRadiusPercent.AutoSize = True
        LabRadiusPercent.Location = New Point(251, 78)
        LabRadiusPercent.Name = "LabRadiusPercent"
        LabRadiusPercent.Size = New Size(85, 15)
        LabRadiusPercent.TabIndex = 14
        LabRadiusPercent.Text = "Radius Percent"
        ' 
        ' LabOffsetToHub
        ' 
        LabOffsetToHub.AutoSize = True
        LabOffsetToHub.Location = New Point(3, 78)
        LabOffsetToHub.Name = "LabOffsetToHub"
        LabOffsetToHub.Size = New Size(81, 15)
        LabOffsetToHub.TabIndex = 13
        LabOffsetToHub.Text = "Offset To Hub"
        ' 
        ' LabDepth
        ' 
        LabDepth.AutoSize = True
        LabDepth.Location = New Point(418, 7)
        LabDepth.Name = "LabDepth"
        LabDepth.Size = New Size(39, 15)
        LabDepth.TabIndex = 12
        LabDepth.Text = "Depth"
        ' 
        ' LabRadius
        ' 
        LabRadius.AutoSize = True
        LabRadius.Location = New Point(251, 7)
        LabRadius.Name = "LabRadius"
        LabRadius.Size = New Size(42, 15)
        LabRadius.TabIndex = 11
        LabRadius.Text = "Radius"
        ' 
        ' LabBlade
        ' 
        LabBlade.AutoSize = True
        LabBlade.Location = New Point(170, 7)
        LabBlade.Name = "LabBlade"
        LabBlade.Size = New Size(36, 15)
        LabBlade.TabIndex = 10
        LabBlade.Text = "Blade"
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.Location = New Point(418, 96)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.Size = New Size(161, 23)
        TxtWheelPitch.TabIndex = 7
        ' 
        ' TxtRadiusPercent
        ' 
        TxtRadiusPercent.Location = New Point(251, 96)
        TxtRadiusPercent.Name = "TxtRadiusPercent"
        TxtRadiusPercent.Size = New Size(161, 23)
        TxtRadiusPercent.TabIndex = 6
        ' 
        ' ComboOffsetToHub
        ' 
        ComboOffsetToHub.FormattingEnabled = True
        ComboOffsetToHub.Location = New Point(3, 96)
        ComboOffsetToHub.Name = "ComboOffsetToHub"
        ComboOffsetToHub.Size = New Size(161, 23)
        ComboOffsetToHub.TabIndex = 5
        ' 
        ' TxtBlade
        ' 
        TxtBlade.Location = New Point(170, 25)
        TxtBlade.Name = "TxtBlade"
        TxtBlade.Size = New Size(75, 23)
        TxtBlade.TabIndex = 4
        ' 
        ' TxtRadius
        ' 
        TxtRadius.Location = New Point(251, 25)
        TxtRadius.Name = "TxtRadius"
        TxtRadius.Size = New Size(161, 23)
        TxtRadius.TabIndex = 3
        ' 
        ' TxtDepth
        ' 
        TxtDepth.Location = New Point(418, 25)
        TxtDepth.Name = "TxtDepth"
        TxtDepth.Size = New Size(161, 23)
        TxtDepth.TabIndex = 2
        ' 
        ' TxtAngle
        ' 
        TxtAngle.Location = New Point(3, 25)
        TxtAngle.Name = "TxtAngle"
        TxtAngle.Size = New Size(161, 23)
        TxtAngle.TabIndex = 1
        ' 
        ' GridBladebyRadius
        ' 
        GridBladebyRadius.AllowUserToAddRows = False
        GridBladebyRadius.AllowUserToDeleteRows = False
        GridBladebyRadius.AllowUserToOrderColumns = True
        GridBladebyRadius.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        GridBladebyRadius.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        GridBladebyRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladebyRadius.Location = New Point(3, 226)
        GridBladebyRadius.Name = "GridBladebyRadius"
        GridBladebyRadius.RowHeadersVisible = False
        GridBladebyRadius.Size = New Size(495, 177)
        GridBladebyRadius.TabIndex = 0
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
        ' PanelTrack
        ' 
        PanelTrack.BorderStyle = BorderStyle.Fixed3D
        PanelTrack.Controls.Add(tLayoutTrack)
        PanelTrack.Location = New Point(209, 562)
        PanelTrack.Name = "PanelTrack"
        PanelTrack.Size = New Size(588, 212)
        PanelTrack.TabIndex = 10
        ' 
        ' tLayoutTrack
        ' 
        tLayoutTrack.ColumnCount = 3
        tLayoutTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        tLayoutTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        tLayoutTrack.Controls.Add(ChartBladeHeight, 0, 1)
        tLayoutTrack.Controls.Add(ChartAngularPosition, 2, 1)
        tLayoutTrack.Controls.Add(LabRefBlade, 1, 1)
        tLayoutTrack.Controls.Add(ComboReferenceBlade, 1, 2)
        tLayoutTrack.Controls.Add(LabRefPoint, 1, 3)
        tLayoutTrack.Controls.Add(LabRefRadius, 1, 5)
        tLayoutTrack.Controls.Add(ComboReferenceRadius, 1, 6)
        tLayoutTrack.Controls.Add(LabRake, 1, 7)
        tLayoutTrack.Controls.Add(ComboReferencePoint, 1, 4)
        tLayoutTrack.Controls.Add(TxtRake, 1, 8)
        tLayoutTrack.Controls.Add(LabTrackPanel, 0, 0)
        tLayoutTrack.Dock = DockStyle.Fill
        tLayoutTrack.Location = New Point(0, 0)
        tLayoutTrack.Name = "tLayoutTrack"
        tLayoutTrack.RowCount = 9
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111116F))
        tLayoutTrack.Size = New Size(584, 208)
        tLayoutTrack.TabIndex = 0
        ' 
        ' ChartBladeHeight
        ' 
        ChartArea4.Name = "ChartArea1"
        ChartBladeHeight.ChartAreas.Add(ChartArea4)
        ChartBladeHeight.Dock = DockStyle.Fill
        Legend3.Name = "Legend1"
        ChartBladeHeight.Legends.Add(Legend3)
        ChartBladeHeight.Location = New Point(3, 26)
        ChartBladeHeight.Name = "ChartBladeHeight"
        tLayoutTrack.SetRowSpan(ChartBladeHeight, 8)
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        ChartBladeHeight.Series.Add(Series4)
        ChartBladeHeight.Size = New Size(227, 179)
        ChartBladeHeight.TabIndex = 0
        ChartBladeHeight.Text = "Track"
        ' 
        ' ChartAngularPosition
        ' 
        ChartArea5.Name = "ChartArea1"
        ChartAngularPosition.ChartAreas.Add(ChartArea5)
        ChartAngularPosition.Dock = DockStyle.Fill
        Legend4.Name = "Legend1"
        ChartAngularPosition.Legends.Add(Legend4)
        ChartAngularPosition.Location = New Point(352, 26)
        ChartAngularPosition.Name = "ChartAngularPosition"
        tLayoutTrack.SetRowSpan(ChartAngularPosition, 8)
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        ChartAngularPosition.Series.Add(Series5)
        ChartAngularPosition.Size = New Size(229, 179)
        ChartAngularPosition.TabIndex = 1
        ChartAngularPosition.Text = "Track"
        ' 
        ' LabRefBlade
        ' 
        LabRefBlade.AutoSize = True
        LabRefBlade.Dock = DockStyle.Bottom
        LabRefBlade.Location = New Point(236, 31)
        LabRefBlade.Name = "LabRefBlade"
        LabRefBlade.Size = New Size(110, 15)
        LabRefBlade.TabIndex = 2
        LabRefBlade.Text = "Reference Blade"
        ' 
        ' ComboReferenceBlade
        ' 
        ComboReferenceBlade.Dock = DockStyle.Top
        ComboReferenceBlade.FormattingEnabled = True
        ComboReferenceBlade.Location = New Point(236, 46)
        ComboReferenceBlade.Margin = New Padding(3, 0, 3, 0)
        ComboReferenceBlade.Name = "ComboReferenceBlade"
        ComboReferenceBlade.Size = New Size(110, 23)
        ComboReferenceBlade.TabIndex = 3
        ' 
        ' LabRefPoint
        ' 
        LabRefPoint.AutoSize = True
        LabRefPoint.Dock = DockStyle.Bottom
        LabRefPoint.Location = New Point(236, 77)
        LabRefPoint.Name = "LabRefPoint"
        LabRefPoint.Size = New Size(110, 15)
        LabRefPoint.TabIndex = 4
        LabRefPoint.Text = "Reference Point"
        ' 
        ' LabRefRadius
        ' 
        LabRefRadius.AutoSize = True
        LabRefRadius.Dock = DockStyle.Bottom
        LabRefRadius.Location = New Point(236, 123)
        LabRefRadius.Name = "LabRefRadius"
        LabRefRadius.Size = New Size(110, 15)
        LabRefRadius.TabIndex = 6
        LabRefRadius.Text = "Reference Radius"
        ' 
        ' ComboReferenceRadius
        ' 
        ComboReferenceRadius.FormattingEnabled = True
        ComboReferenceRadius.Location = New Point(236, 138)
        ComboReferenceRadius.Margin = New Padding(3, 0, 3, 0)
        ComboReferenceRadius.Name = "ComboReferenceRadius"
        ComboReferenceRadius.Size = New Size(110, 23)
        ComboReferenceRadius.TabIndex = 7
        ' 
        ' LabRake
        ' 
        LabRake.AutoSize = True
        LabRake.Dock = DockStyle.Bottom
        LabRake.Location = New Point(236, 169)
        LabRake.Name = "LabRake"
        LabRake.Size = New Size(110, 15)
        LabRake.TabIndex = 8
        LabRake.Text = "Rake"
        ' 
        ' ComboReferencePoint
        ' 
        ComboReferencePoint.FormattingEnabled = True
        ComboReferencePoint.Items.AddRange(New Object() {"LE", "Mid", "TE"})
        ComboReferencePoint.Location = New Point(236, 92)
        ComboReferencePoint.Margin = New Padding(3, 0, 3, 0)
        ComboReferencePoint.Name = "ComboReferencePoint"
        ComboReferencePoint.Size = New Size(110, 23)
        ComboReferencePoint.TabIndex = 5
        ' 
        ' TxtRake
        ' 
        TxtRake.Location = New Point(236, 184)
        TxtRake.Margin = New Padding(3, 0, 3, 0)
        TxtRake.Name = "TxtRake"
        TxtRake.Size = New Size(110, 23)
        TxtRake.TabIndex = 9
        ' 
        ' PanelPlot
        ' 
        PanelPlot.BorderStyle = BorderStyle.Fixed3D
        PanelPlot.Controls.Add(chartPlot)
        PanelPlot.Location = New Point(803, 131)
        PanelPlot.Name = "PanelPlot"
        PanelPlot.Size = New Size(294, 294)
        PanelPlot.TabIndex = 11
        ' 
        ' chartPlot
        ' 
        ChartArea6.Name = "ChartArea1"
        chartPlot.ChartAreas.Add(ChartArea6)
        chartPlot.Dock = DockStyle.Fill
        chartPlot.Location = New Point(0, 0)
        chartPlot.Name = "chartPlot"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = DataVisualization.Charting.SeriesChartType.Radar
        Series6.IsVisibleInLegend = False
        Series6.Name = "Series1"
        chartPlot.Series.Add(Series6)
        chartPlot.Size = New Size(290, 290)
        chartPlot.TabIndex = 0
        chartPlot.Text = "ChartPlot"
        ' 
        ' LabTrackPanel
        ' 
        LabTrackPanel.BackColor = SystemColors.ActiveCaption
        tLayoutTrack.SetColumnSpan(LabTrackPanel, 3)
        LabTrackPanel.Dock = DockStyle.Top
        LabTrackPanel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabTrackPanel.Location = New Point(3, 0)
        LabTrackPanel.Name = "LabTrackPanel"
        LabTrackPanel.Size = New Size(578, 15)
        LabTrackPanel.TabIndex = 12
        LabTrackPanel.Text = "Track"
        ' 
        ' LabPanelPlot
        ' 
        LabPanelPlot.BackColor = SystemColors.ActiveCaption
        LabPanelPlot.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelPlot.Location = New Point(803, 113)
        LabPanelPlot.Name = "LabPanelPlot"
        LabPanelPlot.Size = New Size(295, 15)
        LabPanelPlot.TabIndex = 13
        LabPanelPlot.Text = "Plot"
        ' 
        ' LabPanelMeasurements
        ' 
        LabPanelMeasurements.BackColor = SystemColors.ActiveCaption
        LabPanelMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelMeasurements.Location = New Point(209, 113)
        LabPanelMeasurements.Name = "LabPanelMeasurements"
        LabPanelMeasurements.Size = New Size(588, 15)
        LabPanelMeasurements.TabIndex = 14
        LabPanelMeasurements.Text = "Measurements"
        ' 
        ' LabPanelJob
        ' 
        LabPanelJob.BackColor = SystemColors.ActiveCaption
        LabPanelJob.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelJob.Location = New Point(12, 113)
        LabPanelJob.Name = "LabPanelJob"
        LabPanelJob.Size = New Size(191, 15)
        LabPanelJob.TabIndex = 15
        LabPanelJob.Text = "Job"
        ' 
        ' ComboPitchBasis
        ' 
        ComboPitchBasis.FormattingEnabled = True
        ComboPitchBasis.Location = New Point(803, 448)
        ComboPitchBasis.Name = "ComboPitchBasis"
        ComboPitchBasis.Size = New Size(121, 23)
        ComboPitchBasis.TabIndex = 16
        ' 
        ' ComboTolerance
        ' 
        ComboTolerance.DisplayMember = "ToleranceClass"
        ComboTolerance.FormattingEnabled = True
        ComboTolerance.Location = New Point(974, 448)
        ComboTolerance.Name = "ComboTolerance"
        ComboTolerance.Size = New Size(121, 23)
        ComboTolerance.TabIndex = 17
        ComboTolerance.ValueMember = "ToleranceClass"
        ' 
        ' LabPitchBasis
        ' 
        LabPitchBasis.AutoSize = True
        LabPitchBasis.Location = New Point(803, 430)
        LabPitchBasis.Name = "LabPitchBasis"
        LabPitchBasis.Size = New Size(34, 15)
        LabPitchBasis.TabIndex = 18
        LabPitchBasis.Text = "Pitch"
        ' 
        ' LabTolerance
        ' 
        LabTolerance.AutoSize = True
        LabTolerance.Location = New Point(972, 431)
        LabTolerance.Name = "LabTolerance"
        LabTolerance.Size = New Size(58, 15)
        LabTolerance.TabIndex = 19
        LabTolerance.Text = "Tolerance"
        ' 
        ' TxtBasis
        ' 
        TxtBasis.Location = New Point(803, 496)
        TxtBasis.Name = "TxtBasis"
        TxtBasis.Size = New Size(121, 23)
        TxtBasis.TabIndex = 20
        ' 
        ' LabBasis
        ' 
        LabBasis.AutoSize = True
        LabBasis.Location = New Point(803, 478)
        LabBasis.Name = "LabBasis"
        LabBasis.Size = New Size(33, 15)
        LabBasis.TabIndex = 21
        LabBasis.Text = "Basis"
        ' 
        ' PanelLocalPitchDetails
        ' 
        PanelLocalPitchDetails.Controls.Add(tLayoutLocalPitchDetails)
        PanelLocalPitchDetails.Location = New Point(803, 546)
        PanelLocalPitchDetails.Name = "PanelLocalPitchDetails"
        PanelLocalPitchDetails.Size = New Size(295, 228)
        PanelLocalPitchDetails.TabIndex = 22
        ' 
        ' tLayoutLocalPitchDetails
        ' 
        tLayoutLocalPitchDetails.ColumnCount = 7
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 14.2857141F))
        tLayoutLocalPitchDetails.Controls.Add(LabPrintPitch, 0, 0)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassS, 0, 1)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassI, 1, 1)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassII, 2, 1)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassIII, 3, 1)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassCustom, 4, 1)
        tLayoutLocalPitchDetails.Controls.Add(ChkAllowProgPitch, 3, 0)
        tLayoutLocalPitchDetails.Controls.Add(ChkMinimumsApply, 5, 0)
        tLayoutLocalPitchDetails.Controls.Add(ChkDisplayOnly, 5, 1)
        tLayoutLocalPitchDetails.Dock = DockStyle.Fill
        tLayoutLocalPitchDetails.Location = New Point(0, 0)
        tLayoutLocalPitchDetails.Name = "tLayoutLocalPitchDetails"
        tLayoutLocalPitchDetails.RowCount = 8
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.Size = New Size(295, 228)
        tLayoutLocalPitchDetails.TabIndex = 0
        ' 
        ' LabPrintPitch
        ' 
        LabPrintPitch.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(LabPrintPitch, 3)
        LabPrintPitch.Dock = DockStyle.Fill
        LabPrintPitch.Location = New Point(3, 0)
        LabPrintPitch.Name = "LabPrintPitch"
        LabPrintPitch.Size = New Size(120, 28)
        LabPrintPitch.TabIndex = 0
        LabPrintPitch.Text = "Print Pitch Details"
        LabPrintPitch.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' CmdPrintClassS
        ' 
        CmdPrintClassS.Dock = DockStyle.Fill
        CmdPrintClassS.Location = New Point(3, 31)
        CmdPrintClassS.Name = "CmdPrintClassS"
        CmdPrintClassS.Size = New Size(36, 22)
        CmdPrintClassS.TabIndex = 1
        CmdPrintClassS.Text = "S"
        CmdPrintClassS.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassI
        ' 
        CmdPrintClassI.Dock = DockStyle.Fill
        CmdPrintClassI.Location = New Point(45, 31)
        CmdPrintClassI.Name = "CmdPrintClassI"
        CmdPrintClassI.Size = New Size(36, 22)
        CmdPrintClassI.TabIndex = 2
        CmdPrintClassI.Text = "I"
        CmdPrintClassI.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassII
        ' 
        CmdPrintClassII.Dock = DockStyle.Fill
        CmdPrintClassII.Location = New Point(87, 31)
        CmdPrintClassII.Name = "CmdPrintClassII"
        CmdPrintClassII.Size = New Size(36, 22)
        CmdPrintClassII.TabIndex = 3
        CmdPrintClassII.Text = "II"
        CmdPrintClassII.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassIII
        ' 
        CmdPrintClassIII.Dock = DockStyle.Fill
        CmdPrintClassIII.Location = New Point(129, 31)
        CmdPrintClassIII.Name = "CmdPrintClassIII"
        CmdPrintClassIII.Size = New Size(36, 22)
        CmdPrintClassIII.TabIndex = 4
        CmdPrintClassIII.Text = "III"
        CmdPrintClassIII.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassCustom
        ' 
        CmdPrintClassCustom.Dock = DockStyle.Fill
        CmdPrintClassCustom.Location = New Point(171, 31)
        CmdPrintClassCustom.Name = "CmdPrintClassCustom"
        CmdPrintClassCustom.Size = New Size(36, 22)
        CmdPrintClassCustom.TabIndex = 5
        CmdPrintClassCustom.Text = "Cust"
        CmdPrintClassCustom.UseVisualStyleBackColor = True
        ' 
        ' ChkAllowProgPitch
        ' 
        ChkAllowProgPitch.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkAllowProgPitch, 2)
        ChkAllowProgPitch.Dock = DockStyle.Fill
        ChkAllowProgPitch.Location = New Point(129, 3)
        ChkAllowProgPitch.Name = "ChkAllowProgPitch"
        ChkAllowProgPitch.Size = New Size(78, 22)
        ChkAllowProgPitch.TabIndex = 6
        ChkAllowProgPitch.Text = "App"
        ChkAllowProgPitch.UseVisualStyleBackColor = True
        ' 
        ' ChkMinimumsApply
        ' 
        ChkMinimumsApply.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkMinimumsApply, 2)
        ChkMinimumsApply.Dock = DockStyle.Fill
        ChkMinimumsApply.Location = New Point(213, 3)
        ChkMinimumsApply.Name = "ChkMinimumsApply"
        ChkMinimumsApply.Size = New Size(79, 22)
        ChkMinimumsApply.TabIndex = 7
        ChkMinimumsApply.Text = "Minimums Apply"
        ChkMinimumsApply.UseVisualStyleBackColor = True
        ' 
        ' ChkDisplayOnly
        ' 
        ChkDisplayOnly.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkDisplayOnly, 2)
        ChkDisplayOnly.Dock = DockStyle.Fill
        ChkDisplayOnly.Location = New Point(213, 31)
        ChkDisplayOnly.Name = "ChkDisplayOnly"
        ChkDisplayOnly.Size = New Size(79, 22)
        ChkDisplayOnly.TabIndex = 8
        ChkDisplayOnly.Text = "Display Only"
        ChkDisplayOnly.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(1115, 803)
        Controls.Add(PanelLocalPitchDetails)
        Controls.Add(LabBasis)
        Controls.Add(TxtBasis)
        Controls.Add(LabTolerance)
        Controls.Add(LabPitchBasis)
        Controls.Add(ComboTolerance)
        Controls.Add(ComboPitchBasis)
        Controls.Add(LabPanelJob)
        Controls.Add(LabPanelMeasurements)
        Controls.Add(LabPanelPlot)
        Controls.Add(PanelPlot)
        Controls.Add(PanelTrack)
        Controls.Add(PictureBoxLogo)
        Controls.Add(PanelMeasurements)
        Controls.Add(PanelJob)
        Controls.Add(DataGridJobDetails)
        Controls.Add(EncoderStatusStrip1)
        Controls.Add(RecordNavigationBar1)
        Name = "Form1"
        Text = "Measurements"
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelJob.ResumeLayout(False)
        PanelJob.PerformLayout()
        tLayoutJobInfo.ResumeLayout(False)
        tLayoutJobInfo.PerformLayout()
        PanelMeasurements.ResumeLayout(False)
        PanelMeasurements.PerformLayout()
        CType(GridBladePitch, ComponentModel.ISupportInitialize).EndInit()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).EndInit()
        PanelTrack.ResumeLayout(False)
        tLayoutTrack.ResumeLayout(False)
        tLayoutTrack.PerformLayout()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).EndInit()
        PanelPlot.ResumeLayout(False)
        CType(chartPlot, ComponentModel.ISupportInitialize).EndInit()
        PanelLocalPitchDetails.ResumeLayout(False)
        tLayoutLocalPitchDetails.ResumeLayout(False)
        tLayoutLocalPitchDetails.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents EncoderStatusStrip1 As EncoderStatusStrip
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ClassBindingSource As BindingSource
    Friend WithEvents PanelJob As Panel
    Friend WithEvents tLayoutJobInfo As TableLayoutPanel
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtBlades As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents PanelMeasurements As Panel
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents MeasurementTypesBindingSource As BindingSource
    Friend WithEvents StartDate As DataGridViewTextBoxColumn
    Friend WithEvents MeasurementTypeDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents ToleranceClassDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents GridBladebyRadius As DataGridView
    Friend WithEvents TxtBlade As TextBox
    Friend WithEvents TxtRadius As TextBox
    Friend WithEvents TxtDepth As TextBox
    Friend WithEvents TxtAngle As TextBox
    Friend WithEvents TxtRadiusPercent As TextBox
    Friend WithEvents ComboOffsetToHub As ComboBox
    Friend WithEvents TxtWheelPitch As TextBox
    Friend WithEvents LabAngle As Label
    Friend WithEvents LabWheelPitch As Label
    Friend WithEvents LabRadiusPercent As Label
    Friend WithEvents LabOffsetToHub As Label
    Friend WithEvents LabDepth As Label
    Friend WithEvents LabRadius As Label
    Friend WithEvents LabBlade As Label
    Friend WithEvents ChkScan As CheckBox
    Friend WithEvents CmdZero As Button
    Friend WithEvents CmdSetTip As Button
    Friend WithEvents CmdHome As Button
    Friend WithEvents LabAvgBladePitch As Label
    Friend WithEvents PanelTrack As Panel
    Friend WithEvents PanelPlot As Panel
    Friend WithEvents LabTrackPanel As Label
    Friend WithEvents LabPanelPlot As Label
    Friend WithEvents LabPanelMeasurements As Label
    Friend WithEvents LabPanelJob As Label
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents tLayoutTrack As TableLayoutPanel
    Friend WithEvents ChartBladeHeight As DataVisualization.Charting.Chart
    Friend WithEvents ChartAngularPosition As DataVisualization.Charting.Chart
    Friend WithEvents LabRefBlade As Label
    Friend WithEvents ComboReferenceBlade As ComboBox
    Friend WithEvents LabRefPoint As Label
    Friend WithEvents ComboReferencePoint As ComboBox
    Friend WithEvents LabRefRadius As Label
    Friend WithEvents ComboReferenceRadius As ComboBox
    Friend WithEvents LabRake As Label
    Friend WithEvents chartPlot As DataVisualization.Charting.Chart
    Friend WithEvents TxtRake As TextBox
    Friend WithEvents ComboPitchBasis As ComboBox
    Friend WithEvents ComboTolerance As ComboBox
    Friend WithEvents LabPitchBasis As Label
    Friend WithEvents LabTolerance As Label
    Friend WithEvents TxtBasis As TextBox
    Friend WithEvents LabBasis As Label
    Friend WithEvents PanelLocalPitchDetails As Panel
    Friend WithEvents GridBladePitch As DataGridView
    Friend WithEvents tLayoutLocalPitchDetails As TableLayoutPanel
    Friend WithEvents LabPrintPitch As Label
    Friend WithEvents CmdPrintClassS As Button
    Friend WithEvents CmdPrintClassI As Button
    Friend WithEvents CmdPrintClassII As Button
    Friend WithEvents CmdPrintClassIII As Button
    Friend WithEvents CmdPrintClassCustom As Button
    Friend WithEvents ChkAllowProgPitch As CheckBox
    Friend WithEvents ChkMinimumsApply As CheckBox
    Friend WithEvents ChkDisplayOnly As CheckBox
End Class
