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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        RecordNavigationBar1 = New RecordNavigationBar()
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
        tLayoutJobInfo = New TableLayoutPanel()
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtBlades = New TextBox()
        TxtDiameter = New TextBox()
        TxtBore = New TextBox()
        TxtCustomer = New TextBox()
        TxtJobNumber = New TextBox()
        LabPanelJob = New Label()
        PanelMeasurements = New Panel()
        tLayoutMeasurementPanel = New TableLayoutPanel()
        LabPanelMeasurements = New Label()
        LabAngle = New Label()
        TxtAngle = New TextBox()
        LabBlade = New Label()
        TxtBlade = New TextBox()
        LabOffsetToHub = New Label()
        ComboOffsetToHub = New ComboBox()
        LabRadius = New Label()
        TxtRadius = New TextBox()
        LabRadiusPercent = New Label()
        TxtRadiusPercent = New TextBox()
        LabDepth = New Label()
        TxtDepth = New TextBox()
        LabWheelPitch = New Label()
        TxtWheelPitch = New TextBox()
        CmdSetTip = New Button()
        CmdHome = New Button()
        ChkScan = New CheckBox()
        TxtStatus = New TextBox()
        CmdSetRef = New Button()
        CmdMeasureExtremes = New Button()
        CmdGetRef = New Button()
        GridBladePitch = New DataGridView()
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
        LabTrackPanel = New Label()
        PanelPlot = New Panel()
        tLayoutPlotPanel = New TableLayoutPanel()
        LabPlot = New Label()
        chartPlot = New DataVisualization.Charting.Chart()
        LabTolerance = New Label()
        ComboTolerance = New ComboBox()
        LabBasis = New Label()
        TxtBasis = New TextBox()
        ChkPlotAngularDeviation = New CheckBox()
        ComboPitchBasis = New ComboBox()
        LabPitchBasis = New Label()
        ComboPlotReferenceBlade = New ComboBox()
        LabPanelPlot = New Label()
        PanelLocalPitchDetails = New Panel()
        tLayoutLocalPitchDetails = New TableLayoutPanel()
        LabLocalPitchDetails = New Label()
        LabPrintPitch = New Label()
        CmdPrintClassS = New Button()
        CmdPrintClassI = New Button()
        CmdPrintClassII = New Button()
        CmdPrintClassIII = New Button()
        CmdPrintClassCustom = New Button()
        ChkAllowProgPitch = New CheckBox()
        ChkMinimumsApply = New CheckBox()
        ChkDisplayOnly = New CheckBox()
        ChkAxialPosition = New CheckBox()
        ChkAngularDeviation = New CheckBox()
        ChkMeanPitchPropeller = New CheckBox()
        ChkMeanPitchBlade = New CheckBox()
        ChkMeanPitchRadius = New CheckBox()
        ChkLocalPitch = New CheckBox()
        tLayoutLPLabels = New TableLayoutPanel()
        LabTolAPC = New Label()
        LabTolAPIII = New Label()
        LabTolAPII = New Label()
        LabTolAPI = New Label()
        LabTolAPS = New Label()
        LabTolADC = New Label()
        LabTolADIII = New Label()
        LabTolADII = New Label()
        LabTolADI = New Label()
        LabTolADS = New Label()
        LabTolMPPC = New Label()
        LabTolMPPIII = New Label()
        LabTolMPPII = New Label()
        LabTolMPPI = New Label()
        LabTolMPPS = New Label()
        LabTolMPBC = New Label()
        LabTolMPBIII = New Label()
        LabTolMPBII = New Label()
        LabTolMPBI = New Label()
        LabTolMPBS = New Label()
        LabTolMPRC = New Label()
        LabTolMPRIII = New Label()
        LabTolMPRII = New Label()
        LabTolMPRI = New Label()
        LabTolMPRS = New Label()
        LabTolLPC = New Label()
        LabTolLPII = New Label()
        LabTolLPI = New Label()
        LabTolLPS = New Label()
        TxtAngularDeviation = New TextBox()
        TxtAxialPosition = New TextBox()
        TLayoutMeasurement = New TableLayoutPanel()
        EncoderStatusStrip1 = New EncoderStatusStrip()
        PanelGrids = New Panel()
        TLayoutGrids = New TableLayoutPanel()
        Lab = New Label()
        LabGrids = New Label()
        TLayoutPlotandLP = New TableLayoutPanel()
        tLayoutNavigationButtons = New TableLayoutPanel()
        CmdComparisonForm = New Button()
        CmdInspectForm = New Button()
        CmdGraphForm = New Button()
        CmdLocalPitchForm = New Button()
        CmdMeasureForm = New Button()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelJob.SuspendLayout()
        tLayoutJobInfo.SuspendLayout()
        PanelMeasurements.SuspendLayout()
        tLayoutMeasurementPanel.SuspendLayout()
        CType(GridBladePitch, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).BeginInit()
        PanelTrack.SuspendLayout()
        tLayoutTrack.SuspendLayout()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).BeginInit()
        PanelPlot.SuspendLayout()
        tLayoutPlotPanel.SuspendLayout()
        CType(chartPlot, ComponentModel.ISupportInitialize).BeginInit()
        PanelLocalPitchDetails.SuspendLayout()
        tLayoutLocalPitchDetails.SuspendLayout()
        tLayoutLPLabels.SuspendLayout()
        TLayoutMeasurement.SuspendLayout()
        PanelGrids.SuspendLayout()
        TLayoutGrids.SuspendLayout()
        TLayoutPlotandLP.SuspendLayout()
        tLayoutNavigationButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        TLayoutMeasurement.SetColumnSpan(RecordNavigationBar1, 3)
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Dock = DockStyle.Right
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(600, 0)
        RecordNavigationBar1.Margin = New Padding(0, 0, 15, 0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(569, 33)
        RecordNavigationBar1.TabIndex = 0
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
        DataGridJobDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridJobDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridJobDetails.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridJobDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDate, MeasurementTypeDataGridViewTextBoxColumn, ToleranceClassDataGridViewTextBoxColumn, PerformedBy, Description})
        TLayoutMeasurement.SetColumnSpan(DataGridJobDetails, 3)
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        DataGridJobDetails.DefaultCellStyle = DataGridViewCellStyle3
        DataGridJobDetails.Dock = DockStyle.Right
        DataGridJobDetails.Location = New Point(604, 37)
        DataGridJobDetails.Margin = New Padding(4, 4, 15, 4)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.RowHeadersVisible = False
        DataGridJobDetails.ScrollBars = ScrollBars.None
        DataGridJobDetails.Size = New Size(565, 72)
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
        MeasurementTypeDataGridViewTextBoxColumn.Width = 119
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
        ToleranceClassDataGridViewTextBoxColumn.Width = 65
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
        Description.Width = 103
        ' 
        ' PanelJob
        ' 
        PanelJob.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelJob.BorderStyle = BorderStyle.Fixed3D
        PanelJob.Controls.Add(tLayoutJobInfo)
        PanelJob.Controls.Add(LabPanelJob)
        PanelJob.Dock = DockStyle.Fill
        PanelJob.Location = New Point(10, 113)
        PanelJob.Margin = New Padding(10, 0, 1, 0)
        PanelJob.Name = "PanelJob"
        PanelJob.Size = New Size(201, 162)
        PanelJob.TabIndex = 7
        ' 
        ' tLayoutJobInfo
        ' 
        tLayoutJobInfo.AutoSize = True
        tLayoutJobInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tLayoutJobInfo.ColumnCount = 2
        tLayoutJobInfo.ColumnStyles.Add(New ColumnStyle())
        tLayoutJobInfo.ColumnStyles.Add(New ColumnStyle())
        tLayoutJobInfo.Controls.Add(TxtVessel, 0, 3)
        tLayoutJobInfo.Controls.Add(TxtManufacturer, 0, 4)
        tLayoutJobInfo.Controls.Add(TxtStyle, 0, 5)
        tLayoutJobInfo.Controls.Add(TxtMaterial, 0, 6)
        tLayoutJobInfo.Controls.Add(TxtBlades, 0, 7)
        tLayoutJobInfo.Controls.Add(TxtDiameter, 0, 8)
        tLayoutJobInfo.Controls.Add(TxtBore, 0, 9)
        tLayoutJobInfo.Controls.Add(TxtCustomer, 0, 2)
        tLayoutJobInfo.Controls.Add(TxtJobNumber, 0, 0)
        tLayoutJobInfo.Dock = DockStyle.Fill
        tLayoutJobInfo.Location = New Point(0, 0)
        tLayoutJobInfo.Margin = New Padding(4)
        tLayoutJobInfo.Name = "tLayoutJobInfo"
        tLayoutJobInfo.RowCount = 10
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        tLayoutJobInfo.Size = New Size(197, 158)
        tLayoutJobInfo.TabIndex = 6
        ' 
        ' TxtVessel
        ' 
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.Font = New Font("Segoe UI", 8F)
        TxtVessel.Location = New Point(4, 45)
        TxtVessel.Margin = New Padding(4, 0, 4, 0)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(203, 15)
        TxtVessel.TabIndex = 2
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.Font = New Font("Segoe UI", 8F)
        TxtManufacturer.Location = New Point(4, 60)
        TxtManufacturer.Margin = New Padding(4, 0, 4, 0)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(203, 15)
        TxtManufacturer.TabIndex = 4
        ' 
        ' TxtStyle
        ' 
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Font = New Font("Segoe UI", 8F)
        TxtStyle.Location = New Point(4, 75)
        TxtStyle.Margin = New Padding(4, 0, 4, 0)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(203, 15)
        TxtStyle.TabIndex = 0
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Font = New Font("Segoe UI", 8F)
        TxtMaterial.Location = New Point(4, 90)
        TxtMaterial.Margin = New Padding(4, 0, 4, 0)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(200, 15)
        TxtMaterial.TabIndex = 8
        ' 
        ' TxtBlades
        ' 
        TxtBlades.BorderStyle = BorderStyle.None
        TxtBlades.Font = New Font("Segoe UI", 8F)
        TxtBlades.Location = New Point(4, 105)
        TxtBlades.Margin = New Padding(4, 0, 4, 0)
        TxtBlades.Name = "TxtBlades"
        TxtBlades.ReadOnly = True
        TxtBlades.Size = New Size(200, 15)
        TxtBlades.TabIndex = 5
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.BorderStyle = BorderStyle.None
        TxtDiameter.Font = New Font("Segoe UI", 8F)
        TxtDiameter.Location = New Point(4, 120)
        TxtDiameter.Margin = New Padding(4, 0, 4, 0)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.ReadOnly = True
        TxtDiameter.Size = New Size(200, 15)
        TxtDiameter.TabIndex = 6
        ' 
        ' TxtBore
        ' 
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Font = New Font("Segoe UI", 8F)
        TxtBore.Location = New Point(4, 135)
        TxtBore.Margin = New Padding(4, 0, 4, 0)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(200, 15)
        TxtBore.TabIndex = 7
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.Font = New Font("Segoe UI", 8F)
        TxtCustomer.Location = New Point(4, 30)
        TxtCustomer.Margin = New Padding(4, 0, 4, 0)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(203, 15)
        TxtCustomer.TabIndex = 1
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BackColor = SystemColors.Control
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold)
        TxtJobNumber.Location = New Point(4, 4)
        TxtJobNumber.Margin = New Padding(4)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.Size = New Size(211, 50)
        TxtJobNumber.TabIndex = 7
        ' 
        ' LabPanelJob
        ' 
        LabPanelJob.BackColor = SystemColors.ActiveCaption
        LabPanelJob.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelJob.Location = New Point(-3, 0)
        LabPanelJob.Margin = New Padding(4, 0, 4, 0)
        LabPanelJob.Name = "LabPanelJob"
        LabPanelJob.Size = New Size(219, 20)
        LabPanelJob.TabIndex = 15
        LabPanelJob.Text = "Job"
        ' 
        ' PanelMeasurements
        ' 
        PanelMeasurements.BorderStyle = BorderStyle.Fixed3D
        TLayoutMeasurement.SetColumnSpan(PanelMeasurements, 3)
        PanelMeasurements.Controls.Add(tLayoutMeasurementPanel)
        PanelMeasurements.Dock = DockStyle.Fill
        PanelMeasurements.Location = New Point(212, 113)
        PanelMeasurements.Margin = New Padding(0)
        PanelMeasurements.Name = "PanelMeasurements"
        PanelMeasurements.Size = New Size(582, 162)
        PanelMeasurements.TabIndex = 8
        ' 
        ' tLayoutMeasurementPanel
        ' 
        tLayoutMeasurementPanel.ColumnCount = 12
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 10F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 9.090908F))
        tLayoutMeasurementPanel.Controls.Add(LabPanelMeasurements, 0, 0)
        tLayoutMeasurementPanel.Controls.Add(LabAngle, 0, 1)
        tLayoutMeasurementPanel.Controls.Add(TxtAngle, 0, 2)
        tLayoutMeasurementPanel.Controls.Add(LabBlade, 2, 1)
        tLayoutMeasurementPanel.Controls.Add(TxtBlade, 2, 2)
        tLayoutMeasurementPanel.Controls.Add(LabOffsetToHub, 0, 3)
        tLayoutMeasurementPanel.Controls.Add(ComboOffsetToHub, 0, 4)
        tLayoutMeasurementPanel.Controls.Add(LabRadius, 3, 1)
        tLayoutMeasurementPanel.Controls.Add(TxtRadius, 3, 2)
        tLayoutMeasurementPanel.Controls.Add(LabRadiusPercent, 3, 3)
        tLayoutMeasurementPanel.Controls.Add(TxtRadiusPercent, 3, 4)
        tLayoutMeasurementPanel.Controls.Add(LabDepth, 6, 1)
        tLayoutMeasurementPanel.Controls.Add(TxtDepth, 6, 2)
        tLayoutMeasurementPanel.Controls.Add(LabWheelPitch, 6, 3)
        tLayoutMeasurementPanel.Controls.Add(TxtWheelPitch, 6, 4)
        tLayoutMeasurementPanel.Controls.Add(CmdSetTip, 10, 6)
        tLayoutMeasurementPanel.Controls.Add(CmdHome, 7, 6)
        tLayoutMeasurementPanel.Controls.Add(ChkScan, 4, 6)
        tLayoutMeasurementPanel.Controls.Add(TxtStatus, 0, 6)
        tLayoutMeasurementPanel.Controls.Add(CmdSetRef, 10, 3)
        tLayoutMeasurementPanel.Controls.Add(CmdMeasureExtremes, 10, 2)
        tLayoutMeasurementPanel.Controls.Add(CmdGetRef, 10, 4)
        tLayoutMeasurementPanel.Dock = DockStyle.Fill
        tLayoutMeasurementPanel.Location = New Point(0, 0)
        tLayoutMeasurementPanel.Margin = New Padding(4)
        tLayoutMeasurementPanel.Name = "tLayoutMeasurementPanel"
        tLayoutMeasurementPanel.RowCount = 7
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 10F))
        tLayoutMeasurementPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        tLayoutMeasurementPanel.Size = New Size(578, 158)
        tLayoutMeasurementPanel.TabIndex = 22
        ' 
        ' LabPanelMeasurements
        ' 
        LabPanelMeasurements.BackColor = SystemColors.ActiveCaption
        tLayoutMeasurementPanel.SetColumnSpan(LabPanelMeasurements, 12)
        LabPanelMeasurements.Dock = DockStyle.Fill
        LabPanelMeasurements.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelMeasurements.Location = New Point(0, 0)
        LabPanelMeasurements.Margin = New Padding(0)
        LabPanelMeasurements.Name = "LabPanelMeasurements"
        LabPanelMeasurements.Size = New Size(578, 20)
        LabPanelMeasurements.TabIndex = 14
        LabPanelMeasurements.Text = "Measurements"
        ' 
        ' LabAngle
        ' 
        LabAngle.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabAngle, 2)
        LabAngle.Dock = DockStyle.Bottom
        LabAngle.Location = New Point(4, 25)
        LabAngle.Margin = New Padding(4, 0, 4, 0)
        LabAngle.Name = "LabAngle"
        LabAngle.Size = New Size(94, 20)
        LabAngle.TabIndex = 16
        LabAngle.Text = "Angle"
        ' 
        ' TxtAngle
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtAngle, 2)
        TxtAngle.Dock = DockStyle.Fill
        TxtAngle.Location = New Point(4, 49)
        TxtAngle.Margin = New Padding(4, 4, 0, 4)
        TxtAngle.Name = "TxtAngle"
        TxtAngle.Size = New Size(98, 27)
        TxtAngle.TabIndex = 1
        ' 
        ' LabBlade
        ' 
        LabBlade.AutoSize = True
        LabBlade.Dock = DockStyle.Bottom
        LabBlade.Location = New Point(106, 20)
        LabBlade.Margin = New Padding(4, 0, 4, 0)
        LabBlade.Name = "LabBlade"
        LabBlade.Size = New Size(43, 25)
        LabBlade.TabIndex = 10
        LabBlade.Text = "Blade"
        ' 
        ' TxtBlade
        ' 
        TxtBlade.Dock = DockStyle.Fill
        TxtBlade.Location = New Point(102, 49)
        TxtBlade.Margin = New Padding(0, 4, 0, 4)
        TxtBlade.Name = "TxtBlade"
        TxtBlade.Size = New Size(51, 27)
        TxtBlade.TabIndex = 4
        ' 
        ' LabOffsetToHub
        ' 
        LabOffsetToHub.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabOffsetToHub, 3)
        LabOffsetToHub.Dock = DockStyle.Bottom
        LabOffsetToHub.Location = New Point(4, 75)
        LabOffsetToHub.Margin = New Padding(4, 0, 4, 0)
        LabOffsetToHub.Name = "LabOffsetToHub"
        LabOffsetToHub.Size = New Size(145, 20)
        LabOffsetToHub.TabIndex = 13
        LabOffsetToHub.Text = "Offset To Hub"
        ' 
        ' ComboOffsetToHub
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(ComboOffsetToHub, 3)
        ComboOffsetToHub.Dock = DockStyle.Fill
        ComboOffsetToHub.FormattingEnabled = True
        ComboOffsetToHub.Location = New Point(4, 99)
        ComboOffsetToHub.Margin = New Padding(4, 4, 0, 4)
        ComboOffsetToHub.Name = "ComboOffsetToHub"
        ComboOffsetToHub.Size = New Size(149, 28)
        ComboOffsetToHub.TabIndex = 5
        ' 
        ' LabRadius
        ' 
        LabRadius.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabRadius, 3)
        LabRadius.Dock = DockStyle.Bottom
        LabRadius.Location = New Point(157, 25)
        LabRadius.Margin = New Padding(4, 0, 4, 0)
        LabRadius.Name = "LabRadius"
        LabRadius.Size = New Size(145, 20)
        LabRadius.TabIndex = 11
        LabRadius.Text = "Radius"
        ' 
        ' TxtRadius
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtRadius, 3)
        TxtRadius.Dock = DockStyle.Top
        TxtRadius.Location = New Point(157, 49)
        TxtRadius.Margin = New Padding(4, 4, 0, 4)
        TxtRadius.Name = "TxtRadius"
        TxtRadius.Size = New Size(149, 27)
        TxtRadius.TabIndex = 3
        ' 
        ' LabRadiusPercent
        ' 
        LabRadiusPercent.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabRadiusPercent, 3)
        LabRadiusPercent.Dock = DockStyle.Bottom
        LabRadiusPercent.Location = New Point(157, 75)
        LabRadiusPercent.Margin = New Padding(4, 0, 4, 0)
        LabRadiusPercent.Name = "LabRadiusPercent"
        LabRadiusPercent.Size = New Size(145, 20)
        LabRadiusPercent.TabIndex = 14
        LabRadiusPercent.Text = "Radius Percent"
        ' 
        ' TxtRadiusPercent
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtRadiusPercent, 3)
        TxtRadiusPercent.Dock = DockStyle.Top
        TxtRadiusPercent.Location = New Point(157, 99)
        TxtRadiusPercent.Margin = New Padding(4, 4, 0, 4)
        TxtRadiusPercent.Name = "TxtRadiusPercent"
        TxtRadiusPercent.Size = New Size(149, 27)
        TxtRadiusPercent.TabIndex = 6
        ' 
        ' LabDepth
        ' 
        LabDepth.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabDepth, 3)
        LabDepth.Dock = DockStyle.Bottom
        LabDepth.Location = New Point(310, 25)
        LabDepth.Margin = New Padding(4, 0, 4, 0)
        LabDepth.Name = "LabDepth"
        LabDepth.Size = New Size(145, 20)
        LabDepth.TabIndex = 12
        LabDepth.Text = "Depth"
        ' 
        ' TxtDepth
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtDepth, 3)
        TxtDepth.Dock = DockStyle.Top
        TxtDepth.Location = New Point(310, 49)
        TxtDepth.Margin = New Padding(4, 4, 0, 4)
        TxtDepth.Name = "TxtDepth"
        TxtDepth.Size = New Size(149, 27)
        TxtDepth.TabIndex = 2
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.AutoSize = True
        tLayoutMeasurementPanel.SetColumnSpan(LabWheelPitch, 3)
        LabWheelPitch.Dock = DockStyle.Bottom
        LabWheelPitch.Location = New Point(310, 75)
        LabWheelPitch.Margin = New Padding(4, 0, 4, 0)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(145, 20)
        LabWheelPitch.TabIndex = 15
        LabWheelPitch.Text = "Wheel Pitch"
        ' 
        ' TxtWheelPitch
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtWheelPitch, 3)
        TxtWheelPitch.Dock = DockStyle.Top
        TxtWheelPitch.Location = New Point(310, 99)
        TxtWheelPitch.Margin = New Padding(4, 4, 0, 4)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.Size = New Size(149, 27)
        TxtWheelPitch.TabIndex = 7
        ' 
        ' CmdSetTip
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(CmdSetTip, 2)
        CmdSetTip.Dock = DockStyle.Fill
        CmdSetTip.Image = My.Resources.Resources.SettingsPanel
        CmdSetTip.ImageAlign = ContentAlignment.MiddleRight
        CmdSetTip.Location = New Point(469, 130)
        CmdSetTip.Margin = New Padding(0)
        CmdSetTip.Name = "CmdSetTip"
        CmdSetTip.Size = New Size(109, 28)
        CmdSetTip.TabIndex = 20
        CmdSetTip.Text = "Set tip"
        CmdSetTip.TextAlign = ContentAlignment.MiddleLeft
        CmdSetTip.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdSetTip.UseVisualStyleBackColor = True
        ' 
        ' CmdHome
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(CmdHome, 2)
        CmdHome.Dock = DockStyle.Fill
        CmdHome.Image = My.Resources.Resources.Home
        CmdHome.ImageAlign = ContentAlignment.MiddleRight
        CmdHome.Location = New Point(357, 130)
        CmdHome.Margin = New Padding(0)
        CmdHome.Name = "CmdHome"
        CmdHome.Size = New Size(102, 28)
        CmdHome.TabIndex = 19
        CmdHome.Text = "Home"
        CmdHome.TextAlign = ContentAlignment.MiddleLeft
        CmdHome.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdHome.UseVisualStyleBackColor = True
        ' 
        ' ChkScan
        ' 
        ChkScan.Appearance = Appearance.Button
        tLayoutMeasurementPanel.SetColumnSpan(ChkScan, 2)
        ChkScan.Dock = DockStyle.Fill
        ChkScan.Image = My.Resources.Resources.Timer
        ChkScan.ImageAlign = ContentAlignment.MiddleRight
        ChkScan.Location = New Point(204, 130)
        ChkScan.Margin = New Padding(0)
        ChkScan.Name = "ChkScan"
        ChkScan.Size = New Size(102, 28)
        ChkScan.TabIndex = 17
        ChkScan.Text = " Scan"
        ChkScan.TextImageRelation = TextImageRelation.ImageBeforeText
        ChkScan.UseVisualStyleBackColor = True
        ' 
        ' TxtStatus
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(TxtStatus, 4)
        TxtStatus.Dock = DockStyle.Top
        TxtStatus.Location = New Point(4, 134)
        TxtStatus.Margin = New Padding(4)
        TxtStatus.Name = "TxtStatus"
        TxtStatus.Size = New Size(196, 27)
        TxtStatus.TabIndex = 21
        ' 
        ' CmdSetRef
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(CmdSetRef, 2)
        CmdSetRef.Dock = DockStyle.Fill
        CmdSetRef.Location = New Point(470, 71)
        CmdSetRef.Margin = New Padding(1)
        CmdSetRef.Name = "CmdSetRef"
        CmdSetRef.Size = New Size(107, 23)
        CmdSetRef.TabIndex = 23
        CmdSetRef.Text = "Set Ref"
        CmdSetRef.UseVisualStyleBackColor = True
        ' 
        ' CmdMeasureExtremes
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(CmdMeasureExtremes, 2)
        CmdMeasureExtremes.Dock = DockStyle.Fill
        CmdMeasureExtremes.Location = New Point(470, 46)
        CmdMeasureExtremes.Margin = New Padding(1)
        CmdMeasureExtremes.Name = "CmdMeasureExtremes"
        CmdMeasureExtremes.Size = New Size(107, 23)
        CmdMeasureExtremes.TabIndex = 22
        CmdMeasureExtremes.Text = "Measure Extreme Radii"
        CmdMeasureExtremes.UseVisualStyleBackColor = True
        ' 
        ' CmdGetRef
        ' 
        tLayoutMeasurementPanel.SetColumnSpan(CmdGetRef, 2)
        CmdGetRef.Dock = DockStyle.Fill
        CmdGetRef.Location = New Point(470, 96)
        CmdGetRef.Margin = New Padding(1)
        CmdGetRef.Name = "CmdGetRef"
        CmdGetRef.Size = New Size(107, 23)
        CmdGetRef.TabIndex = 24
        CmdGetRef.Text = "Get Ref"
        CmdGetRef.UseVisualStyleBackColor = True
        ' 
        ' GridBladePitch
        ' 
        GridBladePitch.AllowUserToAddRows = False
        GridBladePitch.AllowUserToDeleteRows = False
        GridBladePitch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        GridBladePitch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladePitch.Dock = DockStyle.Fill
        GridBladePitch.Location = New Point(683, 20)
        GridBladePitch.Margin = New Padding(0)
        GridBladePitch.Name = "GridBladePitch"
        GridBladePitch.RowHeadersVisible = False
        GridBladePitch.Size = New Size(101, 139)
        GridBladePitch.TabIndex = 22
        ' 
        ' GridBladebyRadius
        ' 
        GridBladebyRadius.AllowUserToAddRows = False
        GridBladebyRadius.AllowUserToDeleteRows = False
        GridBladebyRadius.AllowUserToOrderColumns = True
        GridBladebyRadius.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        GridBladebyRadius.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        GridBladebyRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladebyRadius.Dock = DockStyle.Fill
        GridBladebyRadius.Location = New Point(0, 20)
        GridBladebyRadius.Margin = New Padding(0)
        GridBladebyRadius.Name = "GridBladebyRadius"
        GridBladebyRadius.RowHeadersVisible = False
        GridBladebyRadius.Size = New Size(683, 139)
        GridBladebyRadius.TabIndex = 0
        ' 
        ' PictureBoxLogo
        ' 
        PictureBoxLogo.Dock = DockStyle.Fill
        PictureBoxLogo.Image = My.Resources.Resources.Hale_MRI_logo
        PictureBoxLogo.InitialImage = Nothing
        PictureBoxLogo.Location = New Point(0, 0)
        PictureBoxLogo.Margin = New Padding(0)
        PictureBoxLogo.Name = "PictureBoxLogo"
        TLayoutMeasurement.SetRowSpan(PictureBoxLogo, 2)
        PictureBoxLogo.Size = New Size(212, 113)
        PictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxLogo.TabIndex = 9
        PictureBoxLogo.TabStop = False
        ' 
        ' PanelTrack
        ' 
        PanelTrack.BorderStyle = BorderStyle.Fixed3D
        TLayoutMeasurement.SetColumnSpan(PanelTrack, 4)
        PanelTrack.Controls.Add(tLayoutTrack)
        PanelTrack.Dock = DockStyle.Fill
        PanelTrack.Location = New Point(10, 437)
        PanelTrack.Margin = New Padding(10, 0, 0, 0)
        PanelTrack.Name = "PanelTrack"
        PanelTrack.Size = New Size(784, 162)
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
        tLayoutTrack.Margin = New Padding(0)
        tLayoutTrack.Name = "tLayoutTrack"
        tLayoutTrack.RowCount = 9
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutTrack.Size = New Size(780, 158)
        tLayoutTrack.TabIndex = 0
        ' 
        ' ChartBladeHeight
        ' 
        ChartArea1.Name = "ChartArea1"
        ChartBladeHeight.ChartAreas.Add(ChartArea1)
        ChartBladeHeight.Dock = DockStyle.Fill
        Legend1.Name = "Legend1"
        ChartBladeHeight.Legends.Add(Legend1)
        ChartBladeHeight.Location = New Point(0, 21)
        ChartBladeHeight.Margin = New Padding(0, 1, 0, 0)
        ChartBladeHeight.Name = "ChartBladeHeight"
        tLayoutTrack.SetRowSpan(ChartBladeHeight, 8)
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        ChartBladeHeight.Series.Add(Series1)
        ChartBladeHeight.Size = New Size(312, 137)
        ChartBladeHeight.TabIndex = 0
        ChartBladeHeight.Text = "Track"
        ' 
        ' ChartAngularPosition
        ' 
        ChartArea2.Name = "ChartArea1"
        ChartAngularPosition.ChartAreas.Add(ChartArea2)
        ChartAngularPosition.Dock = DockStyle.Fill
        Legend2.Name = "Legend1"
        ChartAngularPosition.Legends.Add(Legend2)
        ChartAngularPosition.Location = New Point(471, 23)
        ChartAngularPosition.Name = "ChartAngularPosition"
        tLayoutTrack.SetRowSpan(ChartAngularPosition, 8)
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        ChartAngularPosition.Series.Add(Series2)
        ChartAngularPosition.Size = New Size(306, 132)
        ChartAngularPosition.TabIndex = 1
        ChartAngularPosition.Text = "Track"
        ' 
        ' LabRefBlade
        ' 
        LabRefBlade.AutoSize = True
        LabRefBlade.Dock = DockStyle.Bottom
        LabRefBlade.Location = New Point(316, 20)
        LabRefBlade.Margin = New Padding(4, 0, 4, 0)
        LabRefBlade.Name = "LabRefBlade"
        LabRefBlade.Size = New Size(148, 17)
        LabRefBlade.TabIndex = 2
        LabRefBlade.Text = "Reference Blade"
        ' 
        ' ComboReferenceBlade
        ' 
        ComboReferenceBlade.Dock = DockStyle.Top
        ComboReferenceBlade.FormattingEnabled = True
        ComboReferenceBlade.Location = New Point(316, 37)
        ComboReferenceBlade.Margin = New Padding(4, 0, 4, 0)
        ComboReferenceBlade.Name = "ComboReferenceBlade"
        ComboReferenceBlade.Size = New Size(148, 28)
        ComboReferenceBlade.TabIndex = 3
        ' 
        ' LabRefPoint
        ' 
        LabRefPoint.AutoSize = True
        LabRefPoint.Dock = DockStyle.Bottom
        LabRefPoint.Location = New Point(316, 54)
        LabRefPoint.Margin = New Padding(4, 0, 4, 0)
        LabRefPoint.Name = "LabRefPoint"
        LabRefPoint.Size = New Size(148, 17)
        LabRefPoint.TabIndex = 4
        LabRefPoint.Text = "Reference Point"
        ' 
        ' LabRefRadius
        ' 
        LabRefRadius.AutoSize = True
        LabRefRadius.Dock = DockStyle.Bottom
        LabRefRadius.Location = New Point(316, 88)
        LabRefRadius.Margin = New Padding(4, 0, 4, 0)
        LabRefRadius.Name = "LabRefRadius"
        LabRefRadius.Size = New Size(148, 17)
        LabRefRadius.TabIndex = 6
        LabRefRadius.Text = "Reference Radius"
        ' 
        ' ComboReferenceRadius
        ' 
        ComboReferenceRadius.FormattingEnabled = True
        ComboReferenceRadius.Location = New Point(316, 105)
        ComboReferenceRadius.Margin = New Padding(4, 0, 4, 0)
        ComboReferenceRadius.Name = "ComboReferenceRadius"
        ComboReferenceRadius.Size = New Size(125, 28)
        ComboReferenceRadius.TabIndex = 7
        ' 
        ' LabRake
        ' 
        LabRake.AutoSize = True
        LabRake.Dock = DockStyle.Bottom
        LabRake.Location = New Point(316, 122)
        LabRake.Margin = New Padding(4, 0, 4, 0)
        LabRake.Name = "LabRake"
        LabRake.Size = New Size(148, 17)
        LabRake.TabIndex = 8
        LabRake.Text = "Rake"
        ' 
        ' ComboReferencePoint
        ' 
        ComboReferencePoint.FormattingEnabled = True
        ComboReferencePoint.Items.AddRange(New Object() {"LE", "Mid", "TE"})
        ComboReferencePoint.Location = New Point(316, 71)
        ComboReferencePoint.Margin = New Padding(4, 0, 4, 0)
        ComboReferencePoint.Name = "ComboReferencePoint"
        ComboReferencePoint.Size = New Size(125, 28)
        ComboReferencePoint.TabIndex = 5
        ' 
        ' TxtRake
        ' 
        TxtRake.Location = New Point(316, 139)
        TxtRake.Margin = New Padding(4, 0, 4, 0)
        TxtRake.Name = "TxtRake"
        TxtRake.Size = New Size(125, 27)
        TxtRake.TabIndex = 9
        ' 
        ' LabTrackPanel
        ' 
        LabTrackPanel.BackColor = SystemColors.ActiveCaption
        tLayoutTrack.SetColumnSpan(LabTrackPanel, 3)
        LabTrackPanel.Dock = DockStyle.Top
        LabTrackPanel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabTrackPanel.Location = New Point(0, 0)
        LabTrackPanel.Margin = New Padding(0)
        LabTrackPanel.Name = "LabTrackPanel"
        LabTrackPanel.Size = New Size(780, 20)
        LabTrackPanel.TabIndex = 12
        LabTrackPanel.Text = "Track"
        ' 
        ' PanelPlot
        ' 
        PanelPlot.BorderStyle = BorderStyle.Fixed3D
        PanelPlot.Controls.Add(tLayoutPlotPanel)
        PanelPlot.Dock = DockStyle.Fill
        PanelPlot.Location = New Point(5, 0)
        PanelPlot.Margin = New Padding(5, 0, 15, 0)
        PanelPlot.Name = "PanelPlot"
        PanelPlot.Size = New Size(370, 243)
        PanelPlot.TabIndex = 11
        ' 
        ' tLayoutPlotPanel
        ' 
        tLayoutPlotPanel.ColumnCount = 2
        tLayoutPlotPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        tLayoutPlotPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tLayoutPlotPanel.Controls.Add(LabPlot, 0, 0)
        tLayoutPlotPanel.Controls.Add(chartPlot, 1, 1)
        tLayoutPlotPanel.Controls.Add(LabTolerance, 0, 3)
        tLayoutPlotPanel.Controls.Add(ComboTolerance, 0, 4)
        tLayoutPlotPanel.Controls.Add(LabBasis, 0, 5)
        tLayoutPlotPanel.Controls.Add(TxtBasis, 0, 6)
        tLayoutPlotPanel.Controls.Add(ChkPlotAngularDeviation, 0, 7)
        tLayoutPlotPanel.Controls.Add(ComboPitchBasis, 0, 2)
        tLayoutPlotPanel.Controls.Add(LabPitchBasis, 0, 1)
        tLayoutPlotPanel.Controls.Add(ComboPlotReferenceBlade, 0, 10)
        tLayoutPlotPanel.Dock = DockStyle.Fill
        tLayoutPlotPanel.Location = New Point(0, 0)
        tLayoutPlotPanel.Name = "tLayoutPlotPanel"
        tLayoutPlotPanel.RowCount = 11
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutPlotPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutPlotPanel.Size = New Size(366, 239)
        tLayoutPlotPanel.TabIndex = 1
        ' 
        ' LabPlot
        ' 
        LabPlot.BackColor = SystemColors.ActiveCaption
        tLayoutPlotPanel.SetColumnSpan(LabPlot, 2)
        LabPlot.Dock = DockStyle.Fill
        LabPlot.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPlot.Location = New Point(0, 0)
        LabPlot.Margin = New Padding(0)
        LabPlot.Name = "LabPlot"
        LabPlot.Size = New Size(366, 15)
        LabPlot.TabIndex = 15
        LabPlot.Text = "Measurements"
        ' 
        ' chartPlot
        ' 
        ChartArea3.Name = "ChartArea1"
        chartPlot.ChartAreas.Add(ChartArea3)
        chartPlot.Dock = DockStyle.Fill
        chartPlot.Location = New Point(103, 18)
        chartPlot.Name = "chartPlot"
        tLayoutPlotPanel.SetRowSpan(chartPlot, 10)
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = DataVisualization.Charting.SeriesChartType.Radar
        Series3.IsVisibleInLegend = False
        Series3.Name = "Series1"
        chartPlot.Series.Add(Series3)
        chartPlot.Size = New Size(260, 218)
        chartPlot.TabIndex = 0
        chartPlot.Text = "ChartPlot"
        ' 
        ' LabTolerance
        ' 
        LabTolerance.AutoSize = True
        LabTolerance.Dock = DockStyle.Bottom
        LabTolerance.Location = New Point(3, 64)
        LabTolerance.Name = "LabTolerance"
        LabTolerance.Size = New Size(94, 20)
        LabTolerance.TabIndex = 17
        LabTolerance.Text = "Tolerance"
        ' 
        ' ComboTolerance
        ' 
        ComboTolerance.Dock = DockStyle.Top
        ComboTolerance.FormattingEnabled = True
        ComboTolerance.Location = New Point(3, 87)
        ComboTolerance.Name = "ComboTolerance"
        ComboTolerance.Size = New Size(94, 28)
        ComboTolerance.TabIndex = 18
        ' 
        ' LabBasis
        ' 
        LabBasis.AutoSize = True
        LabBasis.Dock = DockStyle.Bottom
        LabBasis.Location = New Point(3, 110)
        LabBasis.Name = "LabBasis"
        LabBasis.Size = New Size(94, 20)
        LabBasis.TabIndex = 19
        LabBasis.Text = "Basis"
        ' 
        ' TxtBasis
        ' 
        TxtBasis.Dock = DockStyle.Top
        TxtBasis.Location = New Point(3, 133)
        TxtBasis.Name = "TxtBasis"
        TxtBasis.Size = New Size(94, 27)
        TxtBasis.TabIndex = 20
        ' 
        ' ChkPlotAngularDeviation
        ' 
        ChkPlotAngularDeviation.AutoSize = True
        ChkPlotAngularDeviation.Dock = DockStyle.Fill
        ChkPlotAngularDeviation.Location = New Point(15, 156)
        ChkPlotAngularDeviation.Margin = New Padding(15, 3, 3, 3)
        ChkPlotAngularDeviation.Name = "ChkPlotAngularDeviation"
        tLayoutPlotPanel.SetRowSpan(ChkPlotAngularDeviation, 2)
        ChkPlotAngularDeviation.Size = New Size(82, 37)
        ChkPlotAngularDeviation.TabIndex = 21
        ChkPlotAngularDeviation.Text = "Angular Deviation"
        ChkPlotAngularDeviation.UseVisualStyleBackColor = True
        ' 
        ' ComboPitchBasis
        ' 
        ComboPitchBasis.Dock = DockStyle.Top
        ComboPitchBasis.FormattingEnabled = True
        ComboPitchBasis.Location = New Point(3, 41)
        ComboPitchBasis.Name = "ComboPitchBasis"
        ComboPitchBasis.Size = New Size(94, 28)
        ComboPitchBasis.TabIndex = 16
        ' 
        ' LabPitchBasis
        ' 
        LabPitchBasis.AutoSize = True
        LabPitchBasis.Dock = DockStyle.Bottom
        LabPitchBasis.Location = New Point(3, 18)
        LabPitchBasis.Name = "LabPitchBasis"
        LabPitchBasis.Size = New Size(94, 20)
        LabPitchBasis.TabIndex = 22
        LabPitchBasis.Text = "Pitch Basis"
        ' 
        ' ComboPlotReferenceBlade
        ' 
        ComboPlotReferenceBlade.FormattingEnabled = True
        ComboPlotReferenceBlade.Location = New Point(3, 219)
        ComboPlotReferenceBlade.Name = "ComboPlotReferenceBlade"
        ComboPlotReferenceBlade.Size = New Size(94, 28)
        ComboPlotReferenceBlade.TabIndex = 23
        ' 
        ' LabPanelPlot
        ' 
        LabPanelPlot.BackColor = SystemColors.ActiveCaption
        LabPanelPlot.Dock = DockStyle.Fill
        LabPanelPlot.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPanelPlot.Location = New Point(0, 0)
        LabPanelPlot.Margin = New Padding(0)
        LabPanelPlot.Name = "LabPanelPlot"
        LabPanelPlot.Size = New Size(366, 20)
        LabPanelPlot.TabIndex = 13
        LabPanelPlot.Text = "Plot"
        ' 
        ' PanelLocalPitchDetails
        ' 
        PanelLocalPitchDetails.Controls.Add(tLayoutLocalPitchDetails)
        PanelLocalPitchDetails.Dock = DockStyle.Fill
        PanelLocalPitchDetails.Location = New Point(5, 243)
        PanelLocalPitchDetails.Margin = New Padding(5, 0, 15, 0)
        PanelLocalPitchDetails.Name = "PanelLocalPitchDetails"
        PanelLocalPitchDetails.Size = New Size(370, 243)
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
        tLayoutLocalPitchDetails.Controls.Add(LabLocalPitchDetails, 0, 0)
        tLayoutLocalPitchDetails.Controls.Add(LabPrintPitch, 0, 1)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassS, 0, 2)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassI, 1, 2)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassII, 2, 2)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassIII, 3, 2)
        tLayoutLocalPitchDetails.Controls.Add(CmdPrintClassCustom, 4, 2)
        tLayoutLocalPitchDetails.Controls.Add(ChkAllowProgPitch, 3, 1)
        tLayoutLocalPitchDetails.Controls.Add(ChkMinimumsApply, 5, 1)
        tLayoutLocalPitchDetails.Controls.Add(ChkDisplayOnly, 5, 2)
        tLayoutLocalPitchDetails.Controls.Add(ChkAxialPosition, 0, 8)
        tLayoutLocalPitchDetails.Controls.Add(ChkAngularDeviation, 0, 7)
        tLayoutLocalPitchDetails.Controls.Add(ChkMeanPitchPropeller, 0, 6)
        tLayoutLocalPitchDetails.Controls.Add(ChkMeanPitchBlade, 0, 5)
        tLayoutLocalPitchDetails.Controls.Add(ChkMeanPitchRadius, 0, 4)
        tLayoutLocalPitchDetails.Controls.Add(ChkLocalPitch, 0, 3)
        tLayoutLocalPitchDetails.Controls.Add(tLayoutLPLabels, 3, 3)
        tLayoutLocalPitchDetails.Controls.Add(TxtAngularDeviation, 5, 7)
        tLayoutLocalPitchDetails.Controls.Add(TxtAxialPosition, 5, 8)
        tLayoutLocalPitchDetails.Dock = DockStyle.Fill
        tLayoutLocalPitchDetails.Location = New Point(0, 0)
        tLayoutLocalPitchDetails.Margin = New Padding(0)
        tLayoutLocalPitchDetails.Name = "tLayoutLocalPitchDetails"
        tLayoutLocalPitchDetails.RowCount = 9
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        tLayoutLocalPitchDetails.Size = New Size(370, 243)
        tLayoutLocalPitchDetails.TabIndex = 0
        ' 
        ' LabLocalPitchDetails
        ' 
        LabLocalPitchDetails.BackColor = SystemColors.ActiveCaption
        tLayoutLocalPitchDetails.SetColumnSpan(LabLocalPitchDetails, 7)
        LabLocalPitchDetails.Dock = DockStyle.Fill
        LabLocalPitchDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabLocalPitchDetails.Location = New Point(0, 0)
        LabLocalPitchDetails.Margin = New Padding(0)
        LabLocalPitchDetails.Name = "LabLocalPitchDetails"
        LabLocalPitchDetails.Size = New Size(370, 20)
        LabLocalPitchDetails.TabIndex = 18
        LabLocalPitchDetails.Text = "ISO 484/Custom Tolerances"
        ' 
        ' LabPrintPitch
        ' 
        LabPrintPitch.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(LabPrintPitch, 3)
        LabPrintPitch.Dock = DockStyle.Fill
        LabPrintPitch.Location = New Point(4, 20)
        LabPrintPitch.Margin = New Padding(4, 0, 4, 0)
        LabPrintPitch.Name = "LabPrintPitch"
        LabPrintPitch.Size = New Size(148, 27)
        LabPrintPitch.TabIndex = 0
        LabPrintPitch.Text = "Print Pitch Details"
        LabPrintPitch.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' CmdPrintClassS
        ' 
        CmdPrintClassS.Dock = DockStyle.Fill
        CmdPrintClassS.Location = New Point(1, 48)
        CmdPrintClassS.Margin = New Padding(1)
        CmdPrintClassS.Name = "CmdPrintClassS"
        CmdPrintClassS.Size = New Size(50, 25)
        CmdPrintClassS.TabIndex = 1
        CmdPrintClassS.Text = "S"
        CmdPrintClassS.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassI
        ' 
        CmdPrintClassI.Dock = DockStyle.Fill
        CmdPrintClassI.Location = New Point(53, 48)
        CmdPrintClassI.Margin = New Padding(1)
        CmdPrintClassI.Name = "CmdPrintClassI"
        CmdPrintClassI.Size = New Size(50, 25)
        CmdPrintClassI.TabIndex = 2
        CmdPrintClassI.Text = "I"
        CmdPrintClassI.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassII
        ' 
        CmdPrintClassII.Dock = DockStyle.Fill
        CmdPrintClassII.Location = New Point(105, 48)
        CmdPrintClassII.Margin = New Padding(1)
        CmdPrintClassII.Name = "CmdPrintClassII"
        CmdPrintClassII.Size = New Size(50, 25)
        CmdPrintClassII.TabIndex = 3
        CmdPrintClassII.Text = "II"
        CmdPrintClassII.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassIII
        ' 
        CmdPrintClassIII.Dock = DockStyle.Fill
        CmdPrintClassIII.Location = New Point(157, 48)
        CmdPrintClassIII.Margin = New Padding(1)
        CmdPrintClassIII.Name = "CmdPrintClassIII"
        CmdPrintClassIII.Size = New Size(50, 25)
        CmdPrintClassIII.TabIndex = 4
        CmdPrintClassIII.Text = "III"
        CmdPrintClassIII.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintClassCustom
        ' 
        CmdPrintClassCustom.Dock = DockStyle.Fill
        CmdPrintClassCustom.Location = New Point(209, 48)
        CmdPrintClassCustom.Margin = New Padding(1)
        CmdPrintClassCustom.Name = "CmdPrintClassCustom"
        CmdPrintClassCustom.Size = New Size(50, 25)
        CmdPrintClassCustom.TabIndex = 5
        CmdPrintClassCustom.Text = "Cust"
        CmdPrintClassCustom.UseVisualStyleBackColor = True
        ' 
        ' ChkAllowProgPitch
        ' 
        ChkAllowProgPitch.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkAllowProgPitch, 2)
        ChkAllowProgPitch.Dock = DockStyle.Fill
        ChkAllowProgPitch.Location = New Point(160, 24)
        ChkAllowProgPitch.Margin = New Padding(4)
        ChkAllowProgPitch.Name = "ChkAllowProgPitch"
        ChkAllowProgPitch.Size = New Size(96, 19)
        ChkAllowProgPitch.TabIndex = 6
        ChkAllowProgPitch.Text = "App"
        ChkAllowProgPitch.UseVisualStyleBackColor = True
        ' 
        ' ChkMinimumsApply
        ' 
        ChkMinimumsApply.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkMinimumsApply, 2)
        ChkMinimumsApply.Dock = DockStyle.Fill
        ChkMinimumsApply.Location = New Point(264, 24)
        ChkMinimumsApply.Margin = New Padding(4)
        ChkMinimumsApply.Name = "ChkMinimumsApply"
        ChkMinimumsApply.Size = New Size(102, 19)
        ChkMinimumsApply.TabIndex = 7
        ChkMinimumsApply.Text = "Minimums Apply"
        ChkMinimumsApply.UseVisualStyleBackColor = True
        ' 
        ' ChkDisplayOnly
        ' 
        ChkDisplayOnly.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkDisplayOnly, 2)
        ChkDisplayOnly.Dock = DockStyle.Fill
        ChkDisplayOnly.Location = New Point(264, 51)
        ChkDisplayOnly.Margin = New Padding(4)
        ChkDisplayOnly.Name = "ChkDisplayOnly"
        ChkDisplayOnly.Size = New Size(102, 19)
        ChkDisplayOnly.TabIndex = 8
        ChkDisplayOnly.Text = "Display Only"
        ChkDisplayOnly.UseVisualStyleBackColor = True
        ' 
        ' ChkAxialPosition
        ' 
        ChkAxialPosition.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkAxialPosition, 3)
        ChkAxialPosition.Dock = DockStyle.Fill
        ChkAxialPosition.Location = New Point(12, 213)
        ChkAxialPosition.Margin = New Padding(12, 4, 4, 4)
        ChkAxialPosition.Name = "ChkAxialPosition"
        ChkAxialPosition.Size = New Size(140, 26)
        ChkAxialPosition.TabIndex = 14
        ChkAxialPosition.Text = "Relative Axial Position of consecutive blades"
        ChkAxialPosition.UseVisualStyleBackColor = True
        ' 
        ' ChkAngularDeviation
        ' 
        ChkAngularDeviation.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkAngularDeviation, 3)
        ChkAngularDeviation.Dock = DockStyle.Fill
        ChkAngularDeviation.Location = New Point(12, 186)
        ChkAngularDeviation.Margin = New Padding(12, 4, 4, 4)
        ChkAngularDeviation.Name = "ChkAngularDeviation"
        ChkAngularDeviation.Size = New Size(140, 19)
        ChkAngularDeviation.TabIndex = 13
        ChkAngularDeviation.Text = "Angular Deviation between consecutive blades"
        ChkAngularDeviation.UseVisualStyleBackColor = True
        ' 
        ' ChkMeanPitchPropeller
        ' 
        ChkMeanPitchPropeller.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkMeanPitchPropeller, 3)
        ChkMeanPitchPropeller.Dock = DockStyle.Fill
        ChkMeanPitchPropeller.Location = New Point(12, 159)
        ChkMeanPitchPropeller.Margin = New Padding(12, 4, 4, 4)
        ChkMeanPitchPropeller.Name = "ChkMeanPitchPropeller"
        ChkMeanPitchPropeller.Size = New Size(140, 19)
        ChkMeanPitchPropeller.TabIndex = 12
        ChkMeanPitchPropeller.Text = "Mean Pitch of Propeller"
        ChkMeanPitchPropeller.UseVisualStyleBackColor = True
        ' 
        ' ChkMeanPitchBlade
        ' 
        ChkMeanPitchBlade.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkMeanPitchBlade, 3)
        ChkMeanPitchBlade.Dock = DockStyle.Fill
        ChkMeanPitchBlade.Location = New Point(12, 132)
        ChkMeanPitchBlade.Margin = New Padding(12, 4, 4, 4)
        ChkMeanPitchBlade.Name = "ChkMeanPitchBlade"
        ChkMeanPitchBlade.Size = New Size(140, 19)
        ChkMeanPitchBlade.TabIndex = 11
        ChkMeanPitchBlade.Text = "Mean Pitch of Blades"
        ChkMeanPitchBlade.UseVisualStyleBackColor = True
        ' 
        ' ChkMeanPitchRadius
        ' 
        ChkMeanPitchRadius.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkMeanPitchRadius, 3)
        ChkMeanPitchRadius.Dock = DockStyle.Fill
        ChkMeanPitchRadius.Location = New Point(12, 105)
        ChkMeanPitchRadius.Margin = New Padding(12, 4, 4, 4)
        ChkMeanPitchRadius.Name = "ChkMeanPitchRadius"
        ChkMeanPitchRadius.Size = New Size(140, 19)
        ChkMeanPitchRadius.TabIndex = 10
        ChkMeanPitchRadius.Text = "Mean Pitch of Radius"
        ChkMeanPitchRadius.UseVisualStyleBackColor = True
        ' 
        ' ChkLocalPitch
        ' 
        ChkLocalPitch.AutoSize = True
        tLayoutLocalPitchDetails.SetColumnSpan(ChkLocalPitch, 3)
        ChkLocalPitch.Dock = DockStyle.Fill
        ChkLocalPitch.Location = New Point(12, 78)
        ChkLocalPitch.Margin = New Padding(12, 4, 4, 4)
        ChkLocalPitch.Name = "ChkLocalPitch"
        ChkLocalPitch.Size = New Size(140, 19)
        ChkLocalPitch.TabIndex = 9
        ChkLocalPitch.Text = "Local Pitch"
        ChkLocalPitch.UseVisualStyleBackColor = True
        ' 
        ' tLayoutLPLabels
        ' 
        tLayoutLPLabels.ColumnCount = 5
        tLayoutLocalPitchDetails.SetColumnSpan(tLayoutLPLabels, 2)
        tLayoutLPLabels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutLPLabels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutLPLabels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutLPLabels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutLPLabels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutLPLabels.Controls.Add(LabTolAPC, 4, 5)
        tLayoutLPLabels.Controls.Add(LabTolAPIII, 3, 5)
        tLayoutLPLabels.Controls.Add(LabTolAPII, 2, 5)
        tLayoutLPLabels.Controls.Add(LabTolAPI, 1, 5)
        tLayoutLPLabels.Controls.Add(LabTolAPS, 0, 5)
        tLayoutLPLabels.Controls.Add(LabTolADC, 4, 4)
        tLayoutLPLabels.Controls.Add(LabTolADIII, 3, 4)
        tLayoutLPLabels.Controls.Add(LabTolADII, 2, 4)
        tLayoutLPLabels.Controls.Add(LabTolADI, 1, 4)
        tLayoutLPLabels.Controls.Add(LabTolADS, 0, 4)
        tLayoutLPLabels.Controls.Add(LabTolMPPC, 4, 3)
        tLayoutLPLabels.Controls.Add(LabTolMPPIII, 3, 3)
        tLayoutLPLabels.Controls.Add(LabTolMPPII, 2, 3)
        tLayoutLPLabels.Controls.Add(LabTolMPPI, 1, 3)
        tLayoutLPLabels.Controls.Add(LabTolMPPS, 0, 3)
        tLayoutLPLabels.Controls.Add(LabTolMPBC, 4, 2)
        tLayoutLPLabels.Controls.Add(LabTolMPBIII, 3, 2)
        tLayoutLPLabels.Controls.Add(LabTolMPBII, 2, 2)
        tLayoutLPLabels.Controls.Add(LabTolMPBI, 1, 2)
        tLayoutLPLabels.Controls.Add(LabTolMPBS, 0, 2)
        tLayoutLPLabels.Controls.Add(LabTolMPRC, 4, 1)
        tLayoutLPLabels.Controls.Add(LabTolMPRIII, 3, 1)
        tLayoutLPLabels.Controls.Add(LabTolMPRII, 2, 1)
        tLayoutLPLabels.Controls.Add(LabTolMPRI, 1, 1)
        tLayoutLPLabels.Controls.Add(LabTolMPRS, 0, 1)
        tLayoutLPLabels.Controls.Add(LabTolLPC, 4, 0)
        tLayoutLPLabels.Controls.Add(LabTolLPII, 2, 0)
        tLayoutLPLabels.Controls.Add(LabTolLPI, 1, 0)
        tLayoutLPLabels.Controls.Add(LabTolLPS, 0, 0)
        tLayoutLPLabels.Dock = DockStyle.Fill
        tLayoutLPLabels.Location = New Point(156, 74)
        tLayoutLPLabels.Margin = New Padding(0)
        tLayoutLPLabels.Name = "tLayoutLPLabels"
        tLayoutLPLabels.RowCount = 6
        tLayoutLocalPitchDetails.SetRowSpan(tLayoutLPLabels, 6)
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        tLayoutLPLabels.Size = New Size(104, 169)
        tLayoutLPLabels.TabIndex = 15
        ' 
        ' LabTolAPC
        ' 
        LabTolAPC.AutoSize = True
        LabTolAPC.Dock = DockStyle.Fill
        LabTolAPC.Location = New Point(84, 140)
        LabTolAPC.Margin = New Padding(4, 0, 4, 0)
        LabTolAPC.Name = "LabTolAPC"
        LabTolAPC.Size = New Size(16, 29)
        LabTolAPC.TabIndex = 29
        LabTolAPC.Text = "C"
        LabTolAPC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolAPIII
        ' 
        LabTolAPIII.AutoSize = True
        LabTolAPIII.Dock = DockStyle.Fill
        LabTolAPIII.Location = New Point(64, 140)
        LabTolAPIII.Margin = New Padding(4, 0, 4, 0)
        LabTolAPIII.Name = "LabTolAPIII"
        LabTolAPIII.Size = New Size(12, 29)
        LabTolAPIII.TabIndex = 28
        LabTolAPIII.Text = "III"
        LabTolAPIII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolAPII
        ' 
        LabTolAPII.AutoSize = True
        LabTolAPII.Dock = DockStyle.Fill
        LabTolAPII.Location = New Point(44, 140)
        LabTolAPII.Margin = New Padding(4, 0, 4, 0)
        LabTolAPII.Name = "LabTolAPII"
        LabTolAPII.Size = New Size(12, 29)
        LabTolAPII.TabIndex = 27
        LabTolAPII.Text = "II"
        LabTolAPII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolAPI
        ' 
        LabTolAPI.AutoSize = True
        LabTolAPI.Dock = DockStyle.Fill
        LabTolAPI.Location = New Point(24, 140)
        LabTolAPI.Margin = New Padding(4, 0, 4, 0)
        LabTolAPI.Name = "LabTolAPI"
        LabTolAPI.Size = New Size(12, 29)
        LabTolAPI.TabIndex = 26
        LabTolAPI.Text = "I"
        LabTolAPI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolAPS
        ' 
        LabTolAPS.AutoSize = True
        LabTolAPS.Dock = DockStyle.Fill
        LabTolAPS.Location = New Point(4, 140)
        LabTolAPS.Margin = New Padding(4, 0, 4, 0)
        LabTolAPS.Name = "LabTolAPS"
        LabTolAPS.Size = New Size(12, 29)
        LabTolAPS.TabIndex = 25
        LabTolAPS.Text = "S"
        LabTolAPS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolADC
        ' 
        LabTolADC.AutoSize = True
        LabTolADC.Dock = DockStyle.Fill
        LabTolADC.Location = New Point(84, 112)
        LabTolADC.Margin = New Padding(4, 0, 4, 0)
        LabTolADC.Name = "LabTolADC"
        LabTolADC.Size = New Size(16, 28)
        LabTolADC.TabIndex = 24
        LabTolADC.Text = "C"
        LabTolADC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolADIII
        ' 
        LabTolADIII.AutoSize = True
        LabTolADIII.Dock = DockStyle.Fill
        LabTolADIII.Location = New Point(64, 112)
        LabTolADIII.Margin = New Padding(4, 0, 4, 0)
        LabTolADIII.Name = "LabTolADIII"
        LabTolADIII.Size = New Size(12, 28)
        LabTolADIII.TabIndex = 23
        LabTolADIII.Text = "III"
        LabTolADIII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolADII
        ' 
        LabTolADII.AutoSize = True
        LabTolADII.Dock = DockStyle.Fill
        LabTolADII.Location = New Point(44, 112)
        LabTolADII.Margin = New Padding(4, 0, 4, 0)
        LabTolADII.Name = "LabTolADII"
        LabTolADII.Size = New Size(12, 28)
        LabTolADII.TabIndex = 22
        LabTolADII.Text = "II"
        LabTolADII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolADI
        ' 
        LabTolADI.AutoSize = True
        LabTolADI.Dock = DockStyle.Fill
        LabTolADI.Location = New Point(24, 112)
        LabTolADI.Margin = New Padding(4, 0, 4, 0)
        LabTolADI.Name = "LabTolADI"
        LabTolADI.Size = New Size(12, 28)
        LabTolADI.TabIndex = 21
        LabTolADI.Text = "I"
        LabTolADI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolADS
        ' 
        LabTolADS.AutoSize = True
        LabTolADS.Dock = DockStyle.Fill
        LabTolADS.Location = New Point(4, 112)
        LabTolADS.Margin = New Padding(4, 0, 4, 0)
        LabTolADS.Name = "LabTolADS"
        LabTolADS.Size = New Size(12, 28)
        LabTolADS.TabIndex = 20
        LabTolADS.Text = "S"
        LabTolADS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPPC
        ' 
        LabTolMPPC.AutoSize = True
        LabTolMPPC.Dock = DockStyle.Fill
        LabTolMPPC.Location = New Point(84, 84)
        LabTolMPPC.Margin = New Padding(4, 0, 4, 0)
        LabTolMPPC.Name = "LabTolMPPC"
        LabTolMPPC.Size = New Size(16, 28)
        LabTolMPPC.TabIndex = 19
        LabTolMPPC.Text = "C"
        LabTolMPPC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPPIII
        ' 
        LabTolMPPIII.AutoSize = True
        LabTolMPPIII.Dock = DockStyle.Fill
        LabTolMPPIII.Location = New Point(64, 84)
        LabTolMPPIII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPPIII.Name = "LabTolMPPIII"
        LabTolMPPIII.Size = New Size(12, 28)
        LabTolMPPIII.TabIndex = 18
        LabTolMPPIII.Text = "III"
        LabTolMPPIII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPPII
        ' 
        LabTolMPPII.AutoSize = True
        LabTolMPPII.Dock = DockStyle.Fill
        LabTolMPPII.Location = New Point(44, 84)
        LabTolMPPII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPPII.Name = "LabTolMPPII"
        LabTolMPPII.Size = New Size(12, 28)
        LabTolMPPII.TabIndex = 17
        LabTolMPPII.Text = "II"
        LabTolMPPII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPPI
        ' 
        LabTolMPPI.AutoSize = True
        LabTolMPPI.Dock = DockStyle.Fill
        LabTolMPPI.Location = New Point(24, 84)
        LabTolMPPI.Margin = New Padding(4, 0, 4, 0)
        LabTolMPPI.Name = "LabTolMPPI"
        LabTolMPPI.Size = New Size(12, 28)
        LabTolMPPI.TabIndex = 16
        LabTolMPPI.Text = "I"
        LabTolMPPI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPPS
        ' 
        LabTolMPPS.AutoSize = True
        LabTolMPPS.Dock = DockStyle.Fill
        LabTolMPPS.Location = New Point(4, 84)
        LabTolMPPS.Margin = New Padding(4, 0, 4, 0)
        LabTolMPPS.Name = "LabTolMPPS"
        LabTolMPPS.Size = New Size(12, 28)
        LabTolMPPS.TabIndex = 15
        LabTolMPPS.Text = "S"
        LabTolMPPS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPBC
        ' 
        LabTolMPBC.AutoSize = True
        LabTolMPBC.Dock = DockStyle.Fill
        LabTolMPBC.Location = New Point(84, 56)
        LabTolMPBC.Margin = New Padding(4, 0, 4, 0)
        LabTolMPBC.Name = "LabTolMPBC"
        LabTolMPBC.Size = New Size(16, 28)
        LabTolMPBC.TabIndex = 14
        LabTolMPBC.Text = "C"
        LabTolMPBC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPBIII
        ' 
        LabTolMPBIII.AutoSize = True
        LabTolMPBIII.Dock = DockStyle.Fill
        LabTolMPBIII.Location = New Point(64, 56)
        LabTolMPBIII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPBIII.Name = "LabTolMPBIII"
        LabTolMPBIII.Size = New Size(12, 28)
        LabTolMPBIII.TabIndex = 13
        LabTolMPBIII.Text = "III"
        LabTolMPBIII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPBII
        ' 
        LabTolMPBII.AutoSize = True
        LabTolMPBII.Dock = DockStyle.Fill
        LabTolMPBII.Location = New Point(44, 56)
        LabTolMPBII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPBII.Name = "LabTolMPBII"
        LabTolMPBII.Size = New Size(12, 28)
        LabTolMPBII.TabIndex = 12
        LabTolMPBII.Text = "II"
        LabTolMPBII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPBI
        ' 
        LabTolMPBI.AutoSize = True
        LabTolMPBI.Dock = DockStyle.Fill
        LabTolMPBI.Location = New Point(24, 56)
        LabTolMPBI.Margin = New Padding(4, 0, 4, 0)
        LabTolMPBI.Name = "LabTolMPBI"
        LabTolMPBI.Size = New Size(12, 28)
        LabTolMPBI.TabIndex = 11
        LabTolMPBI.Text = "I"
        LabTolMPBI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPBS
        ' 
        LabTolMPBS.AutoSize = True
        LabTolMPBS.Dock = DockStyle.Fill
        LabTolMPBS.Location = New Point(4, 56)
        LabTolMPBS.Margin = New Padding(4, 0, 4, 0)
        LabTolMPBS.Name = "LabTolMPBS"
        LabTolMPBS.Size = New Size(12, 28)
        LabTolMPBS.TabIndex = 10
        LabTolMPBS.Text = "S"
        LabTolMPBS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPRC
        ' 
        LabTolMPRC.AutoSize = True
        LabTolMPRC.Dock = DockStyle.Fill
        LabTolMPRC.Location = New Point(84, 28)
        LabTolMPRC.Margin = New Padding(4, 0, 4, 0)
        LabTolMPRC.Name = "LabTolMPRC"
        LabTolMPRC.Size = New Size(16, 28)
        LabTolMPRC.TabIndex = 9
        LabTolMPRC.Text = "C"
        LabTolMPRC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPRIII
        ' 
        LabTolMPRIII.AutoSize = True
        LabTolMPRIII.Dock = DockStyle.Fill
        LabTolMPRIII.Location = New Point(64, 28)
        LabTolMPRIII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPRIII.Name = "LabTolMPRIII"
        LabTolMPRIII.Size = New Size(12, 28)
        LabTolMPRIII.TabIndex = 8
        LabTolMPRIII.Text = "III"
        LabTolMPRIII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPRII
        ' 
        LabTolMPRII.AutoSize = True
        LabTolMPRII.Dock = DockStyle.Fill
        LabTolMPRII.Location = New Point(44, 28)
        LabTolMPRII.Margin = New Padding(4, 0, 4, 0)
        LabTolMPRII.Name = "LabTolMPRII"
        LabTolMPRII.Size = New Size(12, 28)
        LabTolMPRII.TabIndex = 7
        LabTolMPRII.Text = "II"
        LabTolMPRII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPRI
        ' 
        LabTolMPRI.AutoSize = True
        LabTolMPRI.Dock = DockStyle.Fill
        LabTolMPRI.Location = New Point(24, 28)
        LabTolMPRI.Margin = New Padding(4, 0, 4, 0)
        LabTolMPRI.Name = "LabTolMPRI"
        LabTolMPRI.Size = New Size(12, 28)
        LabTolMPRI.TabIndex = 6
        LabTolMPRI.Text = "I"
        LabTolMPRI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolMPRS
        ' 
        LabTolMPRS.AutoSize = True
        LabTolMPRS.Dock = DockStyle.Fill
        LabTolMPRS.Location = New Point(4, 28)
        LabTolMPRS.Margin = New Padding(4, 0, 4, 0)
        LabTolMPRS.Name = "LabTolMPRS"
        LabTolMPRS.Size = New Size(12, 28)
        LabTolMPRS.TabIndex = 5
        LabTolMPRS.Text = "S"
        LabTolMPRS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolLPC
        ' 
        LabTolLPC.AutoSize = True
        LabTolLPC.Dock = DockStyle.Fill
        LabTolLPC.Location = New Point(84, 0)
        LabTolLPC.Margin = New Padding(4, 0, 4, 0)
        LabTolLPC.Name = "LabTolLPC"
        LabTolLPC.Size = New Size(16, 28)
        LabTolLPC.TabIndex = 4
        LabTolLPC.Text = "C"
        LabTolLPC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolLPII
        ' 
        LabTolLPII.AutoSize = True
        LabTolLPII.Dock = DockStyle.Fill
        LabTolLPII.Location = New Point(44, 0)
        LabTolLPII.Margin = New Padding(4, 0, 4, 0)
        LabTolLPII.Name = "LabTolLPII"
        LabTolLPII.Size = New Size(12, 28)
        LabTolLPII.TabIndex = 2
        LabTolLPII.Text = "II"
        LabTolLPII.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolLPI
        ' 
        LabTolLPI.AutoSize = True
        LabTolLPI.Dock = DockStyle.Fill
        LabTolLPI.Location = New Point(24, 0)
        LabTolLPI.Margin = New Padding(4, 0, 4, 0)
        LabTolLPI.Name = "LabTolLPI"
        LabTolLPI.Size = New Size(12, 28)
        LabTolLPI.TabIndex = 1
        LabTolLPI.Text = "I"
        LabTolLPI.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabTolLPS
        ' 
        LabTolLPS.AutoSize = True
        LabTolLPS.Dock = DockStyle.Fill
        LabTolLPS.Location = New Point(4, 0)
        LabTolLPS.Margin = New Padding(4, 0, 4, 0)
        LabTolLPS.Name = "LabTolLPS"
        LabTolLPS.Size = New Size(12, 28)
        LabTolLPS.TabIndex = 0
        LabTolLPS.Text = "S"
        LabTolLPS.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TxtAngularDeviation
        ' 
        tLayoutLocalPitchDetails.SetColumnSpan(TxtAngularDeviation, 2)
        TxtAngularDeviation.Dock = DockStyle.Top
        TxtAngularDeviation.Location = New Point(264, 186)
        TxtAngularDeviation.Margin = New Padding(4)
        TxtAngularDeviation.Name = "TxtAngularDeviation"
        TxtAngularDeviation.Size = New Size(102, 27)
        TxtAngularDeviation.TabIndex = 16
        ' 
        ' TxtAxialPosition
        ' 
        tLayoutLocalPitchDetails.SetColumnSpan(TxtAxialPosition, 2)
        TxtAxialPosition.Dock = DockStyle.Top
        TxtAxialPosition.Location = New Point(264, 213)
        TxtAxialPosition.Margin = New Padding(4)
        TxtAxialPosition.Name = "TxtAxialPosition"
        TxtAxialPosition.Size = New Size(102, 27)
        TxtAxialPosition.TabIndex = 17
        ' 
        ' TLayoutMeasurement
        ' 
        TLayoutMeasurement.ColumnCount = 6
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 212F))
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutMeasurement.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutMeasurement.Controls.Add(EncoderStatusStrip1, 0, 5)
        TLayoutMeasurement.Controls.Add(PanelGrids, 0, 3)
        TLayoutMeasurement.Controls.Add(PictureBoxLogo, 0, 0)
        TLayoutMeasurement.Controls.Add(PanelJob, 0, 2)
        TLayoutMeasurement.Controls.Add(PanelMeasurements, 1, 2)
        TLayoutMeasurement.Controls.Add(PanelTrack, 0, 4)
        TLayoutMeasurement.Controls.Add(RecordNavigationBar1, 3, 0)
        TLayoutMeasurement.Controls.Add(DataGridJobDetails, 3, 1)
        TLayoutMeasurement.Controls.Add(TLayoutPlotandLP, 4, 2)
        TLayoutMeasurement.Controls.Add(tLayoutNavigationButtons, 1, 1)
        TLayoutMeasurement.Dock = DockStyle.Fill
        TLayoutMeasurement.Location = New Point(0, 0)
        TLayoutMeasurement.Margin = New Padding(4)
        TLayoutMeasurement.Name = "TLayoutMeasurement"
        TLayoutMeasurement.RowCount = 6
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Absolute, 33F))
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLayoutMeasurement.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TLayoutMeasurement.Size = New Size(1184, 636)
        TLayoutMeasurement.TabIndex = 23
        ' 
        ' EncoderStatusStrip1
        ' 
        EncoderStatusStrip1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TLayoutMeasurement.SetColumnSpan(EncoderStatusStrip1, 6)
        EncoderStatusStrip1.Dock = DockStyle.Fill
        EncoderStatusStrip1.Hardware = Nothing
        EncoderStatusStrip1.Location = New Point(3, 603)
        EncoderStatusStrip1.Margin = New Padding(3, 4, 3, 4)
        EncoderStatusStrip1.Name = "EncoderStatusStrip1"
        EncoderStatusStrip1.Size = New Size(1178, 29)
        EncoderStatusStrip1.TabIndex = 24
        EncoderStatusStrip1.TimerInterval = 100L
        EncoderStatusStrip1.TimerOn = False
        EncoderStatusStrip1.WorkstationName = ""
        ' 
        ' PanelGrids
        ' 
        TLayoutMeasurement.SetColumnSpan(PanelGrids, 4)
        PanelGrids.Controls.Add(TLayoutGrids)
        PanelGrids.Dock = DockStyle.Fill
        PanelGrids.Location = New Point(10, 275)
        PanelGrids.Margin = New Padding(10, 0, 0, 3)
        PanelGrids.Name = "PanelGrids"
        PanelGrids.Size = New Size(784, 159)
        PanelGrids.TabIndex = 24
        ' 
        ' TLayoutGrids
        ' 
        TLayoutGrids.ColumnCount = 2
        TLayoutGrids.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutGrids.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 101F))
        TLayoutGrids.Controls.Add(Lab, 1, 0)
        TLayoutGrids.Controls.Add(LabGrids, 0, 0)
        TLayoutGrids.Controls.Add(GridBladePitch, 1, 1)
        TLayoutGrids.Controls.Add(GridBladebyRadius, 0, 1)
        TLayoutGrids.Dock = DockStyle.Fill
        TLayoutGrids.Location = New Point(0, 0)
        TLayoutGrids.Margin = New Padding(4)
        TLayoutGrids.Name = "TLayoutGrids"
        TLayoutGrids.RowCount = 2
        TLayoutGrids.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TLayoutGrids.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLayoutGrids.Size = New Size(784, 159)
        TLayoutGrids.TabIndex = 0
        ' 
        ' Lab
        ' 
        Lab.BackColor = SystemColors.ActiveCaption
        Lab.Dock = DockStyle.Top
        Lab.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Lab.Location = New Point(683, 0)
        Lab.Margin = New Padding(0)
        Lab.Name = "Lab"
        Lab.Size = New Size(101, 20)
        Lab.TabIndex = 24
        Lab.Text = "Blade Pitch"
        ' 
        ' LabGrids
        ' 
        LabGrids.BackColor = SystemColors.ActiveCaption
        LabGrids.Dock = DockStyle.Top
        LabGrids.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabGrids.Location = New Point(0, 0)
        LabGrids.Margin = New Padding(0)
        LabGrids.Name = "LabGrids"
        LabGrids.Size = New Size(683, 20)
        LabGrids.TabIndex = 23
        LabGrids.Text = "Avg Pitch"
        ' 
        ' TLayoutPlotandLP
        ' 
        TLayoutPlotandLP.ColumnCount = 1
        TLayoutMeasurement.SetColumnSpan(TLayoutPlotandLP, 2)
        TLayoutPlotandLP.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutPlotandLP.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 23F))
        TLayoutPlotandLP.Controls.Add(PanelLocalPitchDetails, 0, 1)
        TLayoutPlotandLP.Controls.Add(PanelPlot, 0, 0)
        TLayoutPlotandLP.Dock = DockStyle.Fill
        TLayoutPlotandLP.Location = New Point(794, 113)
        TLayoutPlotandLP.Margin = New Padding(0)
        TLayoutPlotandLP.Name = "TLayoutPlotandLP"
        TLayoutPlotandLP.RowCount = 2
        TLayoutMeasurement.SetRowSpan(TLayoutPlotandLP, 3)
        TLayoutPlotandLP.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutPlotandLP.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutPlotandLP.Size = New Size(390, 486)
        TLayoutPlotandLP.TabIndex = 25
        ' 
        ' tLayoutNavigationButtons
        ' 
        tLayoutNavigationButtons.ColumnCount = 5
        TLayoutMeasurement.SetColumnSpan(tLayoutNavigationButtons, 2)
        tLayoutNavigationButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutNavigationButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutNavigationButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutNavigationButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutNavigationButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutNavigationButtons.Controls.Add(CmdComparisonForm, 4, 0)
        tLayoutNavigationButtons.Controls.Add(CmdInspectForm, 3, 0)
        tLayoutNavigationButtons.Controls.Add(CmdGraphForm, 2, 0)
        tLayoutNavigationButtons.Controls.Add(CmdLocalPitchForm, 1, 0)
        tLayoutNavigationButtons.Controls.Add(CmdMeasureForm, 0, 0)
        tLayoutNavigationButtons.Dock = DockStyle.Fill
        tLayoutNavigationButtons.Location = New Point(212, 33)
        tLayoutNavigationButtons.Margin = New Padding(0)
        tLayoutNavigationButtons.Name = "tLayoutNavigationButtons"
        tLayoutNavigationButtons.RowCount = 1
        tLayoutNavigationButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tLayoutNavigationButtons.Size = New Size(388, 80)
        tLayoutNavigationButtons.TabIndex = 26
        ' 
        ' CmdComparisonForm
        ' 
        CmdComparisonForm.Dock = DockStyle.Fill
        CmdComparisonForm.Location = New Point(311, 3)
        CmdComparisonForm.Name = "CmdComparisonForm"
        CmdComparisonForm.Size = New Size(74, 74)
        CmdComparisonForm.TabIndex = 4
        CmdComparisonForm.Text = "Comp."
        CmdComparisonForm.UseVisualStyleBackColor = True
        ' 
        ' CmdInspectForm
        ' 
        CmdInspectForm.Dock = DockStyle.Fill
        CmdInspectForm.Location = New Point(234, 3)
        CmdInspectForm.Name = "CmdInspectForm"
        CmdInspectForm.Size = New Size(71, 74)
        CmdInspectForm.TabIndex = 3
        CmdInspectForm.Text = "Inspect"
        CmdInspectForm.UseVisualStyleBackColor = True
        ' 
        ' CmdGraphForm
        ' 
        CmdGraphForm.Dock = DockStyle.Fill
        CmdGraphForm.Location = New Point(157, 3)
        CmdGraphForm.Name = "CmdGraphForm"
        CmdGraphForm.Size = New Size(71, 74)
        CmdGraphForm.TabIndex = 2
        CmdGraphForm.Text = "Graph"
        CmdGraphForm.UseVisualStyleBackColor = True
        ' 
        ' CmdLocalPitchForm
        ' 
        CmdLocalPitchForm.Dock = DockStyle.Fill
        CmdLocalPitchForm.Location = New Point(80, 3)
        CmdLocalPitchForm.Name = "CmdLocalPitchForm"
        CmdLocalPitchForm.Size = New Size(71, 74)
        CmdLocalPitchForm.TabIndex = 1
        CmdLocalPitchForm.Text = "Local Pitch"
        CmdLocalPitchForm.UseVisualStyleBackColor = True
        ' 
        ' CmdMeasureForm
        ' 
        CmdMeasureForm.Dock = DockStyle.Fill
        CmdMeasureForm.Location = New Point(3, 3)
        CmdMeasureForm.Name = "CmdMeasureForm"
        CmdMeasureForm.Size = New Size(71, 74)
        CmdMeasureForm.TabIndex = 0
        CmdMeasureForm.Text = "Measure"
        CmdMeasureForm.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(1184, 636)
        Controls.Add(TLayoutMeasurement)
        Font = New Font("Segoe UI", 11F)
        Margin = New Padding(3, 1, 3, 1)
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
        tLayoutMeasurementPanel.ResumeLayout(False)
        tLayoutMeasurementPanel.PerformLayout()
        CType(GridBladePitch, ComponentModel.ISupportInitialize).EndInit()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).EndInit()
        PanelTrack.ResumeLayout(False)
        tLayoutTrack.ResumeLayout(False)
        tLayoutTrack.PerformLayout()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).EndInit()
        PanelPlot.ResumeLayout(False)
        tLayoutPlotPanel.ResumeLayout(False)
        tLayoutPlotPanel.PerformLayout()
        CType(chartPlot, ComponentModel.ISupportInitialize).EndInit()
        PanelLocalPitchDetails.ResumeLayout(False)
        tLayoutLocalPitchDetails.ResumeLayout(False)
        tLayoutLocalPitchDetails.PerformLayout()
        tLayoutLPLabels.ResumeLayout(False)
        tLayoutLPLabels.PerformLayout()
        TLayoutMeasurement.ResumeLayout(False)
        TLayoutMeasurement.PerformLayout()
        PanelGrids.ResumeLayout(False)
        TLayoutGrids.ResumeLayout(False)
        TLayoutPlotandLP.ResumeLayout(False)
        tLayoutNavigationButtons.ResumeLayout(False)
        ResumeLayout(False)
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
    Friend WithEvents CmdSetTip As Button
    Friend WithEvents CmdHome As Button
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
    Friend WithEvents TLayoutMeasurement As TableLayoutPanel
    Friend WithEvents PanelGrids As Panel
    Friend WithEvents TLayoutGrids As TableLayoutPanel
    Friend WithEvents TLayoutPlot As TableLayoutPanel
    Friend WithEvents Lab As Label
    Friend WithEvents LabGrids As Label
    Friend WithEvents TLayoutPlotandLP As TableLayoutPanel
    Friend WithEvents ChkAxialPosition As CheckBox
    Friend WithEvents ChkAngularDeviation As CheckBox
    Friend WithEvents ChkMeanPitchPropeller As CheckBox
    Friend WithEvents ChkMeanPitchBlade As CheckBox
    Friend WithEvents ChkMeanPitchRadius As CheckBox
    Friend WithEvents ChkLocalPitch As CheckBox
    Friend WithEvents tLayoutLPLabels As TableLayoutPanel
    Friend WithEvents LabTolAPC As Label
    Friend WithEvents LabTolAPIII As Label
    Friend WithEvents LabTolAPII As Label
    Friend WithEvents LabTolAPI As Label
    Friend WithEvents LabTolAPS As Label
    Friend WithEvents LabTolADC As Label
    Friend WithEvents LabTolADIII As Label
    Friend WithEvents LabTolADII As Label
    Friend WithEvents LabTolADI As Label
    Friend WithEvents LabTolADS As Label
    Friend WithEvents LabTolMPPC As Label
    Friend WithEvents LabTolMPPIII As Label
    Friend WithEvents LabTolMPPII As Label
    Friend WithEvents LabTolMPPI As Label
    Friend WithEvents LabTolMPPS As Label
    Friend WithEvents LabTolMPBC As Label
    Friend WithEvents LabTolMPBIII As Label
    Friend WithEvents LabTolMPBII As Label
    Friend WithEvents LabTolMPBI As Label
    Friend WithEvents LabTolMPBS As Label
    Friend WithEvents LabTolMPRC As Label
    Friend WithEvents LabTolMPRIII As Label
    Friend WithEvents LabTolMPRII As Label
    Friend WithEvents LabTolMPRI As Label
    Friend WithEvents LabTolMPRS As Label
    Friend WithEvents LabTolLPC As Label
    Friend WithEvents LabTolLPII As Label
    Friend WithEvents LabTolLPI As Label
    Friend WithEvents LabTolLPS As Label
    Friend WithEvents TxtAngularDeviation As TextBox
    Friend WithEvents TxtAxialPosition As TextBox
    Friend WithEvents tLayoutMeasurementPanel As TableLayoutPanel
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents CmdSetRef As Button
    Friend WithEvents CmdMeasureExtremes As Button
    Friend WithEvents CmdGetRef As Button
    Friend WithEvents LabPlotRefBlade As Label
    Friend WithEvents ComboPlotRefBlade As ComboBox
    Friend WithEvents LabLocalPitchDetails As Label
    Friend WithEvents tLayoutPlotPanel As TableLayoutPanel
    Friend WithEvents LabPlot As Label
    Friend WithEvents ChkPlotAngularDeviation As CheckBox
    Friend WithEvents LabPitchBasis As Label
    Friend WithEvents ComboPlotReferenceBlade As ComboBox
    Friend WithEvents tLayoutNavigationButtons As TableLayoutPanel
    Friend WithEvents CmdInspectForm As Button
    Friend WithEvents CmdGraphForm As Button
    Friend WithEvents CmdLocalPitchForm As Button
    Friend WithEvents CmdMeasureForm As Button
    Friend WithEvents CmdComparisonForm As Button
    'Friend WithEvents ComboPlotRefBlade As ComboBox
End Class
