<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeasurements
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        labBlade = New Label()
        txtAngle = New TextBox()
        labAngle = New Label()
        labDepth = New Label()
        txtDepth = New TextBox()
        labRadius = New Label()
        txtRadius = New TextBox()
        RadiusMeasurementBindingSource = New BindingSource(components)
        labRadiusPercent = New Label()
        txtRadiusPercent = New TextBox()
        labWheelPitch = New Label()
        txtWheelPitch = New TextBox()
        cmdSetTip = New Button()
        cmdHome = New Button()
        cmdZero = New Button()
        StatusStrip1 = New StatusStrip()
        WorkstationLabel = New ToolStripStatusLabel()
        EncodersSplitButton = New ToolStripSplitButton()
        InitializeToolStripMenuItem = New ToolStripMenuItem()
        ResetAngleToolStripMenuItem = New ToolStripMenuItem()
        ResetDepthToolStripMenuItem = New ToolStripMenuItem()
        ResetRadiusToolStripMenuItem = New ToolStripMenuItem()
        StatusLabel = New ToolStripStatusLabel()
        GridBladebyRadius = New DataGridView()
        BladeIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        tloMeasurements = New TableLayoutPanel()
        gBoxPlotGraph = New GroupBox()
        tloPlotGraph = New TableLayoutPanel()
        Chart1 = New DataVisualization.Charting.Chart()
        GrpTrack = New GroupBox()
        tloTrack = New TableLayoutPanel()
        GraphTrack = New DataVisualization.Charting.Chart()
        GrpRefBlades = New DataVisualization.Charting.Chart()
        RadTrackLeadingEdge = New RadioButton()
        RadTrackMidBlade = New RadioButton()
        RadTrackTrailingEdge = New RadioButton()
        LblRefBlade = New Label()
        LblRefRadius = New Label()
        LblRake = New Label()
        CboxRefBlade = New ComboBox()
        ComboBox2 = New ComboBox()
        TxtRake = New TextBox()
        GrpLocalPitch = New GroupBox()
        TloLocalPitchDetails = New TableLayoutPanel()
        CmdLPDS = New Button()
        CmdLPDI = New Button()
        CmdLPDII = New Button()
        CmdLPDIII = New Button()
        CheckBox1 = New CheckBox()
        CheckBox2 = New CheckBox()
        CheckBox3 = New CheckBox()
        CheckBox4 = New CheckBox()
        CheckBox5 = New CheckBox()
        CheckBox6 = New CheckBox()
        LblLocalPitchDetails = New Label()
        CheckBox7 = New CheckBox()
        CheckBox8 = New CheckBox()
        CheckBox9 = New CheckBox()
        LblLPDS1 = New Label()
        LblLPDI1 = New Label()
        LblLPDII1 = New Label()
        LblLPDIII1 = New Label()
        LblLPDS2 = New Label()
        LblLPDI2 = New Label()
        LblLPDII2 = New Label()
        LblLPDIII2 = New Label()
        LblLPDS3 = New Label()
        LblLPDI3 = New Label()
        LblLPDII3 = New Label()
        LblLPDIII3 = New Label()
        LblLPDS4 = New Label()
        LblLPDI4 = New Label()
        LblLPDII4 = New Label()
        LblLPDIII4 = New Label()
        LblLPDS5 = New Label()
        LblLPDI5 = New Label()
        LblLPDII5 = New Label()
        LblLPDIII5 = New Label()
        LblLPDS6 = New Label()
        LblLPDI6 = New Label()
        LblLPDII6 = New Label()
        LblLPDIII6 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        LblOffsetToHub = New Label()
        CboxOffsetToHub = New ComboBox()
        LblStatus = New Label()
        TxtStatus = New TextBox()
        GrpSystem = New GroupBox()
        Tlo = New TableLayoutPanel()
        RadSysImperical = New RadioButton()
        RadSysMetric = New RadioButton()
        ComboBladeId = New ComboBox()
        chkMeasurements = New CheckBox()
        CellMeasurementsBindingSource = New BindingSource(components)
        ExtremeMeasurementsBindingSource = New BindingSource(components)
        timerMeasurements = New Timer(components)
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).BeginInit()
        tloMeasurements.SuspendLayout()
        gBoxPlotGraph.SuspendLayout()
        tloPlotGraph.SuspendLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        GrpTrack.SuspendLayout()
        tloTrack.SuspendLayout()
        CType(GraphTrack, ComponentModel.ISupportInitialize).BeginInit()
        CType(GrpRefBlades, ComponentModel.ISupportInitialize).BeginInit()
        GrpLocalPitch.SuspendLayout()
        TloLocalPitchDetails.SuspendLayout()
        GrpSystem.SuspendLayout()
        Tlo.SuspendLayout()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' labBlade
        ' 
        labBlade.AutoSize = True
        labBlade.Dock = DockStyle.Bottom
        labBlade.Location = New Point(140, 23)
        labBlade.Margin = New Padding(2, 0, 2, 0)
        labBlade.Name = "labBlade"
        labBlade.Size = New Size(65, 15)
        labBlade.TabIndex = 1
        labBlade.Text = "Blade"
        ' 
        ' txtAngle
        ' 
        tloMeasurements.SetColumnSpan(txtAngle, 2)
        txtAngle.Dock = DockStyle.Top
        txtAngle.Location = New Point(2, 39)
        txtAngle.Margin = New Padding(2, 1, 0, 1)
        txtAngle.Name = "txtAngle"
        txtAngle.Size = New Size(136, 23)
        txtAngle.TabIndex = 2
        ' 
        ' labAngle
        ' 
        labAngle.AutoSize = True
        labAngle.Dock = DockStyle.Bottom
        labAngle.Location = New Point(2, 23)
        labAngle.Margin = New Padding(2, 0, 2, 0)
        labAngle.Name = "labAngle"
        labAngle.Size = New Size(65, 15)
        labAngle.TabIndex = 3
        labAngle.Text = "Angle"
        ' 
        ' labDepth
        ' 
        labDepth.AutoSize = True
        labDepth.Dock = DockStyle.Bottom
        labDepth.Location = New Point(416, 23)
        labDepth.Margin = New Padding(2, 0, 2, 0)
        labDepth.Name = "labDepth"
        labDepth.Size = New Size(65, 15)
        labDepth.TabIndex = 5
        labDepth.Text = "Depth"
        ' 
        ' txtDepth
        ' 
        tloMeasurements.SetColumnSpan(txtDepth, 3)
        txtDepth.Dock = DockStyle.Top
        txtDepth.Location = New Point(416, 39)
        txtDepth.Margin = New Padding(2, 1, 2, 1)
        txtDepth.Name = "txtDepth"
        txtDepth.Size = New Size(203, 23)
        txtDepth.TabIndex = 4
        ' 
        ' labRadius
        ' 
        labRadius.AutoSize = True
        labRadius.Dock = DockStyle.Bottom
        labRadius.Location = New Point(209, 23)
        labRadius.Margin = New Padding(2, 0, 2, 0)
        labRadius.Name = "labRadius"
        labRadius.Size = New Size(65, 15)
        labRadius.TabIndex = 7
        labRadius.Text = "Radius"
        ' 
        ' txtRadius
        ' 
        tloMeasurements.SetColumnSpan(txtRadius, 3)
        txtRadius.Dock = DockStyle.Top
        txtRadius.Location = New Point(209, 39)
        txtRadius.Margin = New Padding(2, 1, 2, 1)
        txtRadius.Name = "txtRadius"
        txtRadius.Size = New Size(203, 23)
        txtRadius.TabIndex = 6
        ' 
        ' RadiusMeasurementBindingSource
        ' 
        RadiusMeasurementBindingSource.DataSource = GetType(LibDatabase.Models.RadiusMeasurement)
        ' 
        ' labRadiusPercent
        ' 
        labRadiusPercent.AutoSize = True
        tloMeasurements.SetColumnSpan(labRadiusPercent, 2)
        labRadiusPercent.Dock = DockStyle.Bottom
        labRadiusPercent.Location = New Point(209, 99)
        labRadiusPercent.Margin = New Padding(2, 0, 2, 0)
        labRadiusPercent.Name = "labRadiusPercent"
        labRadiusPercent.Size = New Size(134, 15)
        labRadiusPercent.TabIndex = 9
        labRadiusPercent.Text = "Radius Percent"
        ' 
        ' txtRadiusPercent
        ' 
        tloMeasurements.SetColumnSpan(txtRadiusPercent, 3)
        txtRadiusPercent.Dock = DockStyle.Top
        txtRadiusPercent.Location = New Point(209, 115)
        txtRadiusPercent.Margin = New Padding(2, 1, 2, 1)
        txtRadiusPercent.Name = "txtRadiusPercent"
        txtRadiusPercent.Size = New Size(203, 23)
        txtRadiusPercent.TabIndex = 8
        ' 
        ' labWheelPitch
        ' 
        labWheelPitch.AutoSize = True
        tloMeasurements.SetColumnSpan(labWheelPitch, 2)
        labWheelPitch.Dock = DockStyle.Bottom
        labWheelPitch.Location = New Point(416, 99)
        labWheelPitch.Margin = New Padding(2, 0, 2, 0)
        labWheelPitch.Name = "labWheelPitch"
        labWheelPitch.Size = New Size(134, 15)
        labWheelPitch.TabIndex = 13
        labWheelPitch.Text = "Wheel Pitch"
        ' 
        ' txtWheelPitch
        ' 
        tloMeasurements.SetColumnSpan(txtWheelPitch, 3)
        txtWheelPitch.Dock = DockStyle.Top
        txtWheelPitch.Location = New Point(416, 115)
        txtWheelPitch.Margin = New Padding(2, 1, 2, 1)
        txtWheelPitch.Name = "txtWheelPitch"
        txtWheelPitch.Size = New Size(203, 23)
        txtWheelPitch.TabIndex = 12
        ' 
        ' cmdSetTip
        ' 
        cmdSetTip.Location = New Point(485, 191)
        cmdSetTip.Margin = New Padding(2, 1, 2, 1)
        cmdSetTip.Name = "cmdSetTip"
        cmdSetTip.Size = New Size(65, 21)
        cmdSetTip.TabIndex = 15
        cmdSetTip.Text = "Set Tip"
        cmdSetTip.UseVisualStyleBackColor = True
        ' 
        ' cmdHome
        ' 
        cmdHome.Location = New Point(416, 191)
        cmdHome.Margin = New Padding(2, 1, 2, 1)
        cmdHome.Name = "cmdHome"
        cmdHome.Size = New Size(65, 23)
        cmdHome.TabIndex = 16
        cmdHome.Text = "Home"
        cmdHome.UseVisualStyleBackColor = True
        ' 
        ' cmdZero
        ' 
        cmdZero.Location = New Point(554, 191)
        cmdZero.Margin = New Padding(2, 1, 2, 1)
        cmdZero.Name = "cmdZero"
        cmdZero.Size = New Size(65, 22)
        cmdZero.TabIndex = 18
        cmdZero.Text = "Zero"
        cmdZero.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {WorkstationLabel, EncodersSplitButton, StatusLabel})
        StatusStrip1.Location = New Point(0, 546)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 8, 0)
        StatusStrip1.Size = New Size(1104, 25)
        StatusStrip1.TabIndex = 19
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' WorkstationLabel
        ' 
        WorkstationLabel.Margin = New Padding(29, 6, 26, 4)
        WorkstationLabel.Name = "WorkstationLabel"
        WorkstationLabel.Size = New Size(71, 15)
        WorkstationLabel.Text = "Workstation"
        WorkstationLabel.ToolTipText = "Workstation Name"
        ' 
        ' EncodersSplitButton
        ' 
        EncodersSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image
        EncodersSplitButton.DropDownItems.AddRange(New ToolStripItem() {InitializeToolStripMenuItem, ResetAngleToolStripMenuItem, ResetDepthToolStripMenuItem, ResetRadiusToolStripMenuItem})
        EncodersSplitButton.ImageTransparentColor = Color.Magenta
        EncodersSplitButton.Margin = New Padding(0, 4, 10, 0)
        EncodersSplitButton.Name = "EncodersSplitButton"
        EncodersSplitButton.Size = New Size(16, 21)
        EncodersSplitButton.Text = "Encoders"
        ' 
        ' InitializeToolStripMenuItem
        ' 
        InitializeToolStripMenuItem.Name = "InitializeToolStripMenuItem"
        InitializeToolStripMenuItem.Size = New Size(137, 22)
        InitializeToolStripMenuItem.Text = "Initialize"
        ' 
        ' ResetAngleToolStripMenuItem
        ' 
        ResetAngleToolStripMenuItem.Name = "ResetAngleToolStripMenuItem"
        ResetAngleToolStripMenuItem.Size = New Size(137, 22)
        ResetAngleToolStripMenuItem.Text = "Reset Angle"
        ' 
        ' ResetDepthToolStripMenuItem
        ' 
        ResetDepthToolStripMenuItem.Name = "ResetDepthToolStripMenuItem"
        ResetDepthToolStripMenuItem.Size = New Size(137, 22)
        ResetDepthToolStripMenuItem.Text = "Reset Depth"
        ' 
        ' ResetRadiusToolStripMenuItem
        ' 
        ResetRadiusToolStripMenuItem.Name = "ResetRadiusToolStripMenuItem"
        ResetRadiusToolStripMenuItem.Size = New Size(137, 22)
        ResetRadiusToolStripMenuItem.Text = "ResetRadius"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(39, 20)
        StatusLabel.Text = "Status"
        StatusLabel.ToolTipText = "Encoder Status"
        ' 
        ' GridBladebyRadius
        ' 
        GridBladebyRadius.AutoGenerateColumns = False
        GridBladebyRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladebyRadius.Columns.AddRange(New DataGridViewColumn() {BladeIdDataGridViewTextBoxColumn})
        tloMeasurements.SetColumnSpan(GridBladebyRadius, 9)
        GridBladebyRadius.DataSource = RadiusMeasurementBindingSource
        GridBladebyRadius.Dock = DockStyle.Fill
        GridBladebyRadius.Location = New Point(0, 228)
        GridBladebyRadius.Margin = New Padding(0)
        GridBladebyRadius.Name = "GridBladebyRadius"
        GridBladebyRadius.RowHeadersVisible = False
        GridBladebyRadius.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        tloMeasurements.SetRowSpan(GridBladebyRadius, 4)
        GridBladebyRadius.SelectionMode = DataGridViewSelectionMode.CellSelect
        GridBladebyRadius.Size = New Size(621, 152)
        GridBladebyRadius.TabIndex = 21
        ' 
        ' BladeIdDataGridViewTextBoxColumn
        ' 
        BladeIdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        BladeIdDataGridViewTextBoxColumn.DataPropertyName = "BladeId"
        BladeIdDataGridViewTextBoxColumn.HeaderText = "BladeId"
        BladeIdDataGridViewTextBoxColumn.Name = "BladeIdDataGridViewTextBoxColumn"
        BladeIdDataGridViewTextBoxColumn.Width = 71
        ' 
        ' tloMeasurements
        ' 
        tloMeasurements.ColumnCount = 16
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloMeasurements.Controls.Add(labAngle, 0, 0)
        tloMeasurements.Controls.Add(txtAngle, 0, 1)
        tloMeasurements.Controls.Add(labBlade, 2, 0)
        tloMeasurements.Controls.Add(txtRadius, 3, 1)
        tloMeasurements.Controls.Add(labRadius, 3, 0)
        tloMeasurements.Controls.Add(txtDepth, 6, 1)
        tloMeasurements.Controls.Add(labDepth, 6, 0)
        tloMeasurements.Controls.Add(labWheelPitch, 6, 2)
        tloMeasurements.Controls.Add(labRadiusPercent, 3, 2)
        tloMeasurements.Controls.Add(txtWheelPitch, 6, 3)
        tloMeasurements.Controls.Add(txtRadiusPercent, 3, 3)
        tloMeasurements.Controls.Add(GridBladebyRadius, 0, 6)
        tloMeasurements.Controls.Add(gBoxPlotGraph, 11, 0)
        tloMeasurements.Controls.Add(GrpTrack, 0, 10)
        tloMeasurements.Controls.Add(GrpLocalPitch, 9, 6)
        tloMeasurements.Controls.Add(LblOffsetToHub, 0, 2)
        tloMeasurements.Controls.Add(CboxOffsetToHub, 0, 3)
        tloMeasurements.Controls.Add(LblStatus, 0, 4)
        tloMeasurements.Controls.Add(TxtStatus, 0, 5)
        tloMeasurements.Controls.Add(cmdHome, 6, 5)
        tloMeasurements.Controls.Add(cmdSetTip, 7, 5)
        tloMeasurements.Controls.Add(cmdZero, 8, 5)
        tloMeasurements.Controls.Add(GrpSystem, 9, 0)
        tloMeasurements.Controls.Add(ComboBladeId, 2, 1)
        tloMeasurements.Controls.Add(chkMeasurements, 3, 5)
        tloMeasurements.Dock = DockStyle.Fill
        tloMeasurements.Location = New Point(0, 0)
        tloMeasurements.Name = "tloMeasurements"
        tloMeasurements.RowCount = 14
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        tloMeasurements.Size = New Size(1104, 546)
        tloMeasurements.TabIndex = 22
        ' 
        ' gBoxPlotGraph
        ' 
        tloMeasurements.SetColumnSpan(gBoxPlotGraph, 5)
        gBoxPlotGraph.Controls.Add(tloPlotGraph)
        gBoxPlotGraph.Dock = DockStyle.Fill
        gBoxPlotGraph.Location = New Point(759, 0)
        gBoxPlotGraph.Margin = New Padding(0)
        gBoxPlotGraph.Name = "gBoxPlotGraph"
        tloMeasurements.SetRowSpan(gBoxPlotGraph, 6)
        gBoxPlotGraph.Size = New Size(345, 228)
        gBoxPlotGraph.TabIndex = 22
        gBoxPlotGraph.TabStop = False
        gBoxPlotGraph.Text = "Plot"
        ' 
        ' tloPlotGraph
        ' 
        tloPlotGraph.ColumnCount = 2
        tloPlotGraph.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0F))
        tloPlotGraph.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70.0F))
        tloPlotGraph.Controls.Add(Chart1, 1, 0)
        tloPlotGraph.Dock = DockStyle.Fill
        tloPlotGraph.Location = New Point(3, 19)
        tloPlotGraph.Margin = New Padding(0)
        tloPlotGraph.Name = "tloPlotGraph"
        tloPlotGraph.RowCount = 2
        tloPlotGraph.RowStyles.Add(New RowStyle(SizeType.Percent, 85.0F))
        tloPlotGraph.RowStyles.Add(New RowStyle(SizeType.Percent, 15.0F))
        tloPlotGraph.Size = New Size(339, 206)
        tloPlotGraph.TabIndex = 0
        ' 
        ' Chart1
        ' 
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.Maximum = 1.0R
        ChartArea1.AxisX.Minimum = -1.0R
        ChartArea1.AxisY.Interval = 10.0R
        ChartArea1.AxisY.LabelStyle.Enabled = False
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.Maximum = 1.0R
        ChartArea1.AxisY.Minimum = -1.0R
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Chart1.Dock = DockStyle.Fill
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(104, 3)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = DataVisualization.Charting.SeriesChartType.Point
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New Size(232, 169)
        Chart1.TabIndex = 23
        Chart1.Text = "Chart1"
        ' 
        ' GrpTrack
        ' 
        tloMeasurements.SetColumnSpan(GrpTrack, 9)
        GrpTrack.Controls.Add(tloTrack)
        GrpTrack.Dock = DockStyle.Fill
        GrpTrack.Location = New Point(0, 380)
        GrpTrack.Margin = New Padding(0)
        GrpTrack.Name = "GrpTrack"
        GrpTrack.Padding = New Padding(1, 2, 1, 1)
        tloMeasurements.SetRowSpan(GrpTrack, 4)
        GrpTrack.Size = New Size(621, 166)
        GrpTrack.TabIndex = 24
        GrpTrack.TabStop = False
        GrpTrack.Text = "Track"
        ' 
        ' tloTrack
        ' 
        tloTrack.ColumnCount = 4
        tloTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 37.5F))
        tloTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        tloTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        tloTrack.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 37.5F))
        tloTrack.Controls.Add(GraphTrack, 0, 0)
        tloTrack.Controls.Add(GrpRefBlades, 3, 0)
        tloTrack.Controls.Add(RadTrackLeadingEdge, 1, 0)
        tloTrack.Controls.Add(RadTrackMidBlade, 1, 2)
        tloTrack.Controls.Add(RadTrackTrailingEdge, 1, 4)
        tloTrack.Controls.Add(LblRefBlade, 2, 0)
        tloTrack.Controls.Add(LblRefRadius, 2, 2)
        tloTrack.Controls.Add(LblRake, 2, 4)
        tloTrack.Controls.Add(CboxRefBlade, 2, 1)
        tloTrack.Controls.Add(ComboBox2, 2, 3)
        tloTrack.Controls.Add(TxtRake, 2, 5)
        tloTrack.Dock = DockStyle.Fill
        tloTrack.Location = New Point(1, 18)
        tloTrack.Name = "tloTrack"
        tloTrack.RowCount = 6
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6666679F))
        tloTrack.Size = New Size(619, 147)
        tloTrack.TabIndex = 0
        ' 
        ' GraphTrack
        ' 
        ChartArea2.Name = "ChartArea1"
        GraphTrack.ChartAreas.Add(ChartArea2)
        GraphTrack.Dock = DockStyle.Fill
        Legend2.Name = "Legend1"
        GraphTrack.Legends.Add(Legend2)
        GraphTrack.Location = New Point(3, 3)
        GraphTrack.Name = "GraphTrack"
        tloTrack.SetRowSpan(GraphTrack, 6)
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        GraphTrack.Series.Add(Series2)
        GraphTrack.Size = New Size(226, 141)
        GraphTrack.TabIndex = 23
        GraphTrack.Text = "Chart2"
        ' 
        ' GrpRefBlades
        ' 
        ChartArea3.Name = "ChartArea1"
        GrpRefBlades.ChartAreas.Add(ChartArea3)
        GrpRefBlades.Dock = DockStyle.Fill
        Legend3.Name = "Legend1"
        GrpRefBlades.Legends.Add(Legend3)
        GrpRefBlades.Location = New Point(389, 3)
        GrpRefBlades.Name = "GrpRefBlades"
        tloTrack.SetRowSpan(GrpRefBlades, 6)
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        GrpRefBlades.Series.Add(Series3)
        GrpRefBlades.Size = New Size(227, 141)
        GrpRefBlades.TabIndex = 24
        GrpRefBlades.Text = "Chart2"
        ' 
        ' RadTrackLeadingEdge
        ' 
        RadTrackLeadingEdge.AutoSize = True
        RadTrackLeadingEdge.Dock = DockStyle.Fill
        RadTrackLeadingEdge.Location = New Point(247, 3)
        RadTrackLeadingEdge.Margin = New Padding(15, 3, 3, 3)
        RadTrackLeadingEdge.Name = "RadTrackLeadingEdge"
        tloTrack.SetRowSpan(RadTrackLeadingEdge, 2)
        RadTrackLeadingEdge.Size = New Size(59, 42)
        RadTrackLeadingEdge.TabIndex = 25
        RadTrackLeadingEdge.TabStop = True
        RadTrackLeadingEdge.Text = "LE"
        RadTrackLeadingEdge.UseVisualStyleBackColor = True
        ' 
        ' RadTrackMidBlade
        ' 
        RadTrackMidBlade.AutoSize = True
        RadTrackMidBlade.Dock = DockStyle.Fill
        RadTrackMidBlade.Location = New Point(247, 51)
        RadTrackMidBlade.Margin = New Padding(15, 3, 3, 3)
        RadTrackMidBlade.Name = "RadTrackMidBlade"
        tloTrack.SetRowSpan(RadTrackMidBlade, 2)
        RadTrackMidBlade.Size = New Size(59, 42)
        RadTrackMidBlade.TabIndex = 26
        RadTrackMidBlade.TabStop = True
        RadTrackMidBlade.Text = "Mid"
        RadTrackMidBlade.UseVisualStyleBackColor = True
        ' 
        ' RadTrackTrailingEdge
        ' 
        RadTrackTrailingEdge.AutoSize = True
        RadTrackTrailingEdge.Dock = DockStyle.Fill
        RadTrackTrailingEdge.Location = New Point(247, 99)
        RadTrackTrailingEdge.Margin = New Padding(15, 3, 3, 3)
        RadTrackTrailingEdge.Name = "RadTrackTrailingEdge"
        tloTrack.SetRowSpan(RadTrackTrailingEdge, 2)
        RadTrackTrailingEdge.Size = New Size(59, 45)
        RadTrackTrailingEdge.TabIndex = 27
        RadTrackTrailingEdge.TabStop = True
        RadTrackTrailingEdge.Text = "TE"
        RadTrackTrailingEdge.UseVisualStyleBackColor = True
        ' 
        ' LblRefBlade
        ' 
        LblRefBlade.AutoSize = True
        LblRefBlade.Dock = DockStyle.Bottom
        LblRefBlade.Location = New Point(312, 9)
        LblRefBlade.Name = "LblRefBlade"
        LblRefBlade.Size = New Size(71, 15)
        LblRefBlade.TabIndex = 28
        LblRefBlade.Text = "Ref Blade"
        ' 
        ' LblRefRadius
        ' 
        LblRefRadius.AutoSize = True
        LblRefRadius.Dock = DockStyle.Bottom
        LblRefRadius.Location = New Point(312, 57)
        LblRefRadius.Name = "LblRefRadius"
        LblRefRadius.Size = New Size(71, 15)
        LblRefRadius.TabIndex = 29
        LblRefRadius.Text = "Ref Radius"
        ' 
        ' LblRake
        ' 
        LblRake.AutoSize = True
        LblRake.Dock = DockStyle.Bottom
        LblRake.Location = New Point(312, 105)
        LblRake.Name = "LblRake"
        LblRake.Size = New Size(71, 15)
        LblRake.TabIndex = 30
        LblRake.Text = "Rake"
        ' 
        ' CboxRefBlade
        ' 
        CboxRefBlade.FormattingEnabled = True
        CboxRefBlade.Location = New Point(312, 27)
        CboxRefBlade.Name = "CboxRefBlade"
        CboxRefBlade.Size = New Size(71, 23)
        CboxRefBlade.TabIndex = 31
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(312, 75)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(71, 23)
        ComboBox2.TabIndex = 32
        ' 
        ' TxtRake
        ' 
        TxtRake.Location = New Point(312, 123)
        TxtRake.Name = "TxtRake"
        TxtRake.Size = New Size(71, 23)
        TxtRake.TabIndex = 33
        ' 
        ' GrpLocalPitch
        ' 
        tloMeasurements.SetColumnSpan(GrpLocalPitch, 7)
        GrpLocalPitch.Controls.Add(TloLocalPitchDetails)
        GrpLocalPitch.Dock = DockStyle.Fill
        GrpLocalPitch.Location = New Point(624, 231)
        GrpLocalPitch.Name = "GrpLocalPitch"
        tloMeasurements.SetRowSpan(GrpLocalPitch, 8)
        GrpLocalPitch.Size = New Size(477, 312)
        GrpLocalPitch.TabIndex = 25
        GrpLocalPitch.TabStop = False
        GrpLocalPitch.Text = "Local Pitch Details"
        ' 
        ' TloLocalPitchDetails
        ' 
        TloLocalPitchDetails.ColumnCount = 14
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 15.0F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.692309F))
        TloLocalPitchDetails.Controls.Add(CmdLPDS, 1, 1)
        TloLocalPitchDetails.Controls.Add(CmdLPDI, 3, 1)
        TloLocalPitchDetails.Controls.Add(CmdLPDII, 5, 1)
        TloLocalPitchDetails.Controls.Add(CmdLPDIII, 7, 1)
        TloLocalPitchDetails.Controls.Add(CheckBox1, 1, 3)
        TloLocalPitchDetails.Controls.Add(CheckBox2, 1, 4)
        TloLocalPitchDetails.Controls.Add(CheckBox3, 1, 5)
        TloLocalPitchDetails.Controls.Add(CheckBox4, 1, 6)
        TloLocalPitchDetails.Controls.Add(CheckBox5, 1, 7)
        TloLocalPitchDetails.Controls.Add(CheckBox6, 1, 9)
        TloLocalPitchDetails.Controls.Add(LblLocalPitchDetails, 1, 0)
        TloLocalPitchDetails.Controls.Add(CheckBox7, 9, 0)
        TloLocalPitchDetails.Controls.Add(CheckBox8, 9, 2)
        TloLocalPitchDetails.Controls.Add(CheckBox9, 11, 0)
        TloLocalPitchDetails.Controls.Add(LblLPDS1, 7, 3)
        TloLocalPitchDetails.Controls.Add(LblLPDI1, 8, 3)
        TloLocalPitchDetails.Controls.Add(LblLPDII1, 9, 3)
        TloLocalPitchDetails.Controls.Add(LblLPDIII1, 10, 3)
        TloLocalPitchDetails.Controls.Add(LblLPDS2, 7, 4)
        TloLocalPitchDetails.Controls.Add(LblLPDI2, 8, 4)
        TloLocalPitchDetails.Controls.Add(LblLPDII2, 9, 4)
        TloLocalPitchDetails.Controls.Add(LblLPDIII2, 10, 4)
        TloLocalPitchDetails.Controls.Add(LblLPDS3, 7, 5)
        TloLocalPitchDetails.Controls.Add(LblLPDI3, 8, 5)
        TloLocalPitchDetails.Controls.Add(LblLPDII3, 9, 5)
        TloLocalPitchDetails.Controls.Add(LblLPDIII3, 10, 5)
        TloLocalPitchDetails.Controls.Add(LblLPDS4, 7, 6)
        TloLocalPitchDetails.Controls.Add(LblLPDI4, 8, 6)
        TloLocalPitchDetails.Controls.Add(LblLPDII4, 9, 6)
        TloLocalPitchDetails.Controls.Add(LblLPDIII4, 10, 6)
        TloLocalPitchDetails.Controls.Add(LblLPDS5, 7, 7)
        TloLocalPitchDetails.Controls.Add(LblLPDI5, 8, 7)
        TloLocalPitchDetails.Controls.Add(LblLPDII5, 9, 7)
        TloLocalPitchDetails.Controls.Add(LblLPDIII5, 10, 7)
        TloLocalPitchDetails.Controls.Add(LblLPDS6, 7, 9)
        TloLocalPitchDetails.Controls.Add(LblLPDI6, 8, 9)
        TloLocalPitchDetails.Controls.Add(LblLPDII6, 9, 9)
        TloLocalPitchDetails.Controls.Add(LblLPDIII6, 10, 9)
        TloLocalPitchDetails.Controls.Add(TextBox1, 11, 7)
        TloLocalPitchDetails.Controls.Add(TextBox2, 11, 9)
        TloLocalPitchDetails.Dock = DockStyle.Fill
        TloLocalPitchDetails.Location = New Point(3, 19)
        TloLocalPitchDetails.Name = "TloLocalPitchDetails"
        TloLocalPitchDetails.RowCount = 12
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Percent, 9.090908F))
        TloLocalPitchDetails.RowStyles.Add(New RowStyle(SizeType.Absolute, 10.0F))
        TloLocalPitchDetails.Size = New Size(471, 290)
        TloLocalPitchDetails.TabIndex = 0
        ' 
        ' CmdLPDS
        ' 
        TloLocalPitchDetails.SetColumnSpan(CmdLPDS, 2)
        CmdLPDS.Dock = DockStyle.Fill
        CmdLPDS.Location = New Point(18, 28)
        CmdLPDS.Margin = New Padding(3, 3, 3, 25)
        CmdLPDS.Name = "CmdLPDS"
        TloLocalPitchDetails.SetRowSpan(CmdLPDS, 2)
        CmdLPDS.Size = New Size(64, 22)
        CmdLPDS.TabIndex = 1
        CmdLPDS.Text = "S"
        CmdLPDS.UseVisualStyleBackColor = True
        ' 
        ' CmdLPDI
        ' 
        TloLocalPitchDetails.SetColumnSpan(CmdLPDI, 2)
        CmdLPDI.Dock = DockStyle.Fill
        CmdLPDI.Location = New Point(88, 28)
        CmdLPDI.Margin = New Padding(3, 3, 3, 25)
        CmdLPDI.Name = "CmdLPDI"
        TloLocalPitchDetails.SetRowSpan(CmdLPDI, 2)
        CmdLPDI.Size = New Size(64, 22)
        CmdLPDI.TabIndex = 2
        CmdLPDI.Text = "I"
        CmdLPDI.UseVisualStyleBackColor = True
        ' 
        ' CmdLPDII
        ' 
        TloLocalPitchDetails.SetColumnSpan(CmdLPDII, 2)
        CmdLPDII.Dock = DockStyle.Fill
        CmdLPDII.Location = New Point(158, 28)
        CmdLPDII.Margin = New Padding(3, 3, 3, 25)
        CmdLPDII.Name = "CmdLPDII"
        TloLocalPitchDetails.SetRowSpan(CmdLPDII, 2)
        CmdLPDII.Size = New Size(64, 22)
        CmdLPDII.TabIndex = 3
        CmdLPDII.Text = "II"
        CmdLPDII.UseVisualStyleBackColor = True
        ' 
        ' CmdLPDIII
        ' 
        TloLocalPitchDetails.SetColumnSpan(CmdLPDIII, 2)
        CmdLPDIII.Dock = DockStyle.Fill
        CmdLPDIII.Location = New Point(228, 28)
        CmdLPDIII.Margin = New Padding(3, 3, 3, 25)
        CmdLPDIII.Name = "CmdLPDIII"
        TloLocalPitchDetails.SetRowSpan(CmdLPDIII, 2)
        CmdLPDIII.Size = New Size(64, 22)
        CmdLPDIII.TabIndex = 4
        CmdLPDIII.Text = "III"
        CmdLPDIII.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox1, 5)
        CheckBox1.Dock = DockStyle.Fill
        CheckBox1.Location = New Point(18, 78)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(169, 19)
        CheckBox1.TabIndex = 5
        CheckBox1.Text = "Local Pitch"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox2, 5)
        CheckBox2.Dock = DockStyle.Fill
        CheckBox2.Location = New Point(18, 103)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(169, 19)
        CheckBox2.TabIndex = 6
        CheckBox2.Text = "Mean Pitch for Radius"
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' CheckBox3
        ' 
        CheckBox3.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox3, 5)
        CheckBox3.Dock = DockStyle.Fill
        CheckBox3.Location = New Point(18, 128)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(169, 19)
        CheckBox3.TabIndex = 7
        CheckBox3.Text = "Mean Pitch for Blade"
        CheckBox3.UseVisualStyleBackColor = True
        ' 
        ' CheckBox4
        ' 
        CheckBox4.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox4, 5)
        CheckBox4.Dock = DockStyle.Fill
        CheckBox4.Location = New Point(18, 153)
        CheckBox4.Name = "CheckBox4"
        CheckBox4.Size = New Size(169, 19)
        CheckBox4.TabIndex = 8
        CheckBox4.Text = "Mean Pitch for Propeller"
        CheckBox4.UseVisualStyleBackColor = True
        ' 
        ' CheckBox5
        ' 
        CheckBox5.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox5, 5)
        CheckBox5.Dock = DockStyle.Fill
        CheckBox5.Location = New Point(18, 178)
        CheckBox5.Name = "CheckBox5"
        TloLocalPitchDetails.SetRowSpan(CheckBox5, 2)
        CheckBox5.Size = New Size(169, 44)
        CheckBox5.TabIndex = 9
        CheckBox5.Text = "Angular Deviation Between Consecutive Blades"
        CheckBox5.UseVisualStyleBackColor = True
        ' 
        ' CheckBox6
        ' 
        CheckBox6.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox6, 5)
        CheckBox6.Dock = DockStyle.Fill
        CheckBox6.Location = New Point(18, 228)
        CheckBox6.Name = "CheckBox6"
        TloLocalPitchDetails.SetRowSpan(CheckBox6, 2)
        CheckBox6.Size = New Size(169, 44)
        CheckBox6.TabIndex = 10
        CheckBox6.Text = "Relative Axial Position of Consecutive Blades"
        CheckBox6.UseVisualStyleBackColor = True
        ' 
        ' LblLocalPitchDetails
        ' 
        LblLocalPitchDetails.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(LblLocalPitchDetails, 6)
        LblLocalPitchDetails.Dock = DockStyle.Bottom
        LblLocalPitchDetails.Location = New Point(18, 10)
        LblLocalPitchDetails.Name = "LblLocalPitchDetails"
        LblLocalPitchDetails.Size = New Size(204, 15)
        LblLocalPitchDetails.TabIndex = 0
        LblLocalPitchDetails.Text = "Print Local Pitch Details"
        ' 
        ' CheckBox7
        ' 
        CheckBox7.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox7, 2)
        CheckBox7.Dock = DockStyle.Bottom
        CheckBox7.Location = New Point(298, 3)
        CheckBox7.Name = "CheckBox7"
        CheckBox7.Size = New Size(64, 19)
        CheckBox7.TabIndex = 11
        CheckBox7.Text = "App"
        CheckBox7.UseVisualStyleBackColor = True
        ' 
        ' CheckBox8
        ' 
        CheckBox8.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox8, 4)
        CheckBox8.Dock = DockStyle.Top
        CheckBox8.Location = New Point(298, 53)
        CheckBox8.Name = "CheckBox8"
        CheckBox8.Size = New Size(134, 19)
        CheckBox8.TabIndex = 12
        CheckBox8.Text = "Display Only"
        CheckBox8.UseVisualStyleBackColor = True
        ' 
        ' CheckBox9
        ' 
        CheckBox9.AutoSize = True
        TloLocalPitchDetails.SetColumnSpan(CheckBox9, 2)
        CheckBox9.Dock = DockStyle.Bottom
        CheckBox9.Location = New Point(368, 3)
        CheckBox9.Name = "CheckBox9"
        CheckBox9.Size = New Size(64, 19)
        CheckBox9.TabIndex = 13
        CheckBox9.Text = "Mins"
        CheckBox9.UseVisualStyleBackColor = True
        ' 
        ' LblLPDS1
        ' 
        LblLPDS1.AutoSize = True
        LblLPDS1.Dock = DockStyle.Fill
        LblLPDS1.Location = New Point(228, 75)
        LblLPDS1.Name = "LblLPDS1"
        LblLPDS1.Size = New Size(29, 25)
        LblLPDS1.TabIndex = 14
        LblLPDS1.Text = "S"
        LblLPDS1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI1
        ' 
        LblLPDI1.AutoSize = True
        LblLPDI1.Dock = DockStyle.Fill
        LblLPDI1.Location = New Point(263, 75)
        LblLPDI1.Name = "LblLPDI1"
        LblLPDI1.Size = New Size(29, 25)
        LblLPDI1.TabIndex = 15
        LblLPDI1.Text = "I"
        LblLPDI1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII1
        ' 
        LblLPDII1.AutoSize = True
        LblLPDII1.Dock = DockStyle.Fill
        LblLPDII1.Location = New Point(298, 75)
        LblLPDII1.Name = "LblLPDII1"
        LblLPDII1.Size = New Size(29, 25)
        LblLPDII1.TabIndex = 16
        LblLPDII1.Text = "II"
        LblLPDII1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII1
        ' 
        LblLPDIII1.AutoSize = True
        LblLPDIII1.Dock = DockStyle.Fill
        LblLPDIII1.Location = New Point(333, 75)
        LblLPDIII1.Name = "LblLPDIII1"
        LblLPDIII1.Size = New Size(29, 25)
        LblLPDIII1.TabIndex = 17
        LblLPDIII1.Text = "III"
        LblLPDIII1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDS2
        ' 
        LblLPDS2.AutoSize = True
        LblLPDS2.Dock = DockStyle.Fill
        LblLPDS2.Location = New Point(228, 100)
        LblLPDS2.Name = "LblLPDS2"
        LblLPDS2.Size = New Size(29, 25)
        LblLPDS2.TabIndex = 18
        LblLPDS2.Text = "S"
        LblLPDS2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI2
        ' 
        LblLPDI2.AutoSize = True
        LblLPDI2.Dock = DockStyle.Fill
        LblLPDI2.Location = New Point(263, 100)
        LblLPDI2.Name = "LblLPDI2"
        LblLPDI2.Size = New Size(29, 25)
        LblLPDI2.TabIndex = 19
        LblLPDI2.Text = "I"
        LblLPDI2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII2
        ' 
        LblLPDII2.AutoSize = True
        LblLPDII2.Dock = DockStyle.Fill
        LblLPDII2.Location = New Point(298, 100)
        LblLPDII2.Name = "LblLPDII2"
        LblLPDII2.Size = New Size(29, 25)
        LblLPDII2.TabIndex = 20
        LblLPDII2.Text = "II"
        LblLPDII2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII2
        ' 
        LblLPDIII2.AutoSize = True
        LblLPDIII2.Dock = DockStyle.Fill
        LblLPDIII2.Location = New Point(333, 100)
        LblLPDIII2.Name = "LblLPDIII2"
        LblLPDIII2.Size = New Size(29, 25)
        LblLPDIII2.TabIndex = 21
        LblLPDIII2.Text = "III"
        LblLPDIII2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDS3
        ' 
        LblLPDS3.AutoSize = True
        LblLPDS3.Dock = DockStyle.Fill
        LblLPDS3.Location = New Point(228, 125)
        LblLPDS3.Name = "LblLPDS3"
        LblLPDS3.Size = New Size(29, 25)
        LblLPDS3.TabIndex = 22
        LblLPDS3.Text = "S"
        LblLPDS3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI3
        ' 
        LblLPDI3.AutoSize = True
        LblLPDI3.Dock = DockStyle.Fill
        LblLPDI3.Location = New Point(263, 125)
        LblLPDI3.Name = "LblLPDI3"
        LblLPDI3.Size = New Size(29, 25)
        LblLPDI3.TabIndex = 23
        LblLPDI3.Text = "I"
        LblLPDI3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII3
        ' 
        LblLPDII3.AutoSize = True
        LblLPDII3.Dock = DockStyle.Fill
        LblLPDII3.Location = New Point(298, 125)
        LblLPDII3.Name = "LblLPDII3"
        LblLPDII3.Size = New Size(29, 25)
        LblLPDII3.TabIndex = 24
        LblLPDII3.Text = "II"
        LblLPDII3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII3
        ' 
        LblLPDIII3.AutoSize = True
        LblLPDIII3.Dock = DockStyle.Fill
        LblLPDIII3.Location = New Point(333, 125)
        LblLPDIII3.Name = "LblLPDIII3"
        LblLPDIII3.Size = New Size(29, 25)
        LblLPDIII3.TabIndex = 25
        LblLPDIII3.Text = "III"
        LblLPDIII3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDS4
        ' 
        LblLPDS4.AutoSize = True
        LblLPDS4.Dock = DockStyle.Fill
        LblLPDS4.Location = New Point(228, 150)
        LblLPDS4.Name = "LblLPDS4"
        LblLPDS4.Size = New Size(29, 25)
        LblLPDS4.TabIndex = 26
        LblLPDS4.Text = "S"
        LblLPDS4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI4
        ' 
        LblLPDI4.AutoSize = True
        LblLPDI4.Dock = DockStyle.Fill
        LblLPDI4.Location = New Point(263, 150)
        LblLPDI4.Name = "LblLPDI4"
        LblLPDI4.Size = New Size(29, 25)
        LblLPDI4.TabIndex = 27
        LblLPDI4.Text = "I"
        LblLPDI4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII4
        ' 
        LblLPDII4.AutoSize = True
        LblLPDII4.Dock = DockStyle.Fill
        LblLPDII4.Location = New Point(298, 150)
        LblLPDII4.Name = "LblLPDII4"
        LblLPDII4.Size = New Size(29, 25)
        LblLPDII4.TabIndex = 28
        LblLPDII4.Text = "II"
        LblLPDII4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII4
        ' 
        LblLPDIII4.AutoSize = True
        LblLPDIII4.Dock = DockStyle.Fill
        LblLPDIII4.Location = New Point(333, 150)
        LblLPDIII4.Name = "LblLPDIII4"
        LblLPDIII4.Size = New Size(29, 25)
        LblLPDIII4.TabIndex = 29
        LblLPDIII4.Text = "III"
        LblLPDIII4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDS5
        ' 
        LblLPDS5.AutoSize = True
        LblLPDS5.Dock = DockStyle.Fill
        LblLPDS5.Location = New Point(228, 175)
        LblLPDS5.Name = "LblLPDS5"
        TloLocalPitchDetails.SetRowSpan(LblLPDS5, 2)
        LblLPDS5.Size = New Size(29, 50)
        LblLPDS5.TabIndex = 30
        LblLPDS5.Text = "S"
        LblLPDS5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI5
        ' 
        LblLPDI5.AutoSize = True
        LblLPDI5.Dock = DockStyle.Fill
        LblLPDI5.Location = New Point(263, 175)
        LblLPDI5.Name = "LblLPDI5"
        TloLocalPitchDetails.SetRowSpan(LblLPDI5, 2)
        LblLPDI5.Size = New Size(29, 50)
        LblLPDI5.TabIndex = 31
        LblLPDI5.Text = "I"
        LblLPDI5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII5
        ' 
        LblLPDII5.AutoSize = True
        LblLPDII5.Dock = DockStyle.Fill
        LblLPDII5.Location = New Point(298, 175)
        LblLPDII5.Name = "LblLPDII5"
        TloLocalPitchDetails.SetRowSpan(LblLPDII5, 2)
        LblLPDII5.Size = New Size(29, 50)
        LblLPDII5.TabIndex = 32
        LblLPDII5.Text = "II"
        LblLPDII5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII5
        ' 
        LblLPDIII5.AutoSize = True
        LblLPDIII5.Dock = DockStyle.Fill
        LblLPDIII5.Location = New Point(333, 175)
        LblLPDIII5.Name = "LblLPDIII5"
        TloLocalPitchDetails.SetRowSpan(LblLPDIII5, 2)
        LblLPDIII5.Size = New Size(29, 50)
        LblLPDIII5.TabIndex = 33
        LblLPDIII5.Text = "III"
        LblLPDIII5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDS6
        ' 
        LblLPDS6.AutoSize = True
        LblLPDS6.Dock = DockStyle.Fill
        LblLPDS6.Location = New Point(228, 225)
        LblLPDS6.Name = "LblLPDS6"
        TloLocalPitchDetails.SetRowSpan(LblLPDS6, 2)
        LblLPDS6.Size = New Size(29, 50)
        LblLPDS6.TabIndex = 34
        LblLPDS6.Text = "S"
        LblLPDS6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDI6
        ' 
        LblLPDI6.AutoSize = True
        LblLPDI6.Dock = DockStyle.Fill
        LblLPDI6.Location = New Point(263, 225)
        LblLPDI6.Name = "LblLPDI6"
        TloLocalPitchDetails.SetRowSpan(LblLPDI6, 2)
        LblLPDI6.Size = New Size(29, 50)
        LblLPDI6.TabIndex = 35
        LblLPDI6.Text = "I"
        LblLPDI6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDII6
        ' 
        LblLPDII6.AutoSize = True
        LblLPDII6.Dock = DockStyle.Fill
        LblLPDII6.Location = New Point(298, 225)
        LblLPDII6.Name = "LblLPDII6"
        TloLocalPitchDetails.SetRowSpan(LblLPDII6, 2)
        LblLPDII6.Size = New Size(29, 50)
        LblLPDII6.TabIndex = 36
        LblLPDII6.Text = "II"
        LblLPDII6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblLPDIII6
        ' 
        LblLPDIII6.AutoSize = True
        LblLPDIII6.Dock = DockStyle.Fill
        LblLPDIII6.Location = New Point(333, 225)
        LblLPDIII6.Name = "LblLPDIII6"
        TloLocalPitchDetails.SetRowSpan(LblLPDIII6, 2)
        LblLPDIII6.Size = New Size(29, 50)
        LblLPDIII6.TabIndex = 37
        LblLPDIII6.Text = "III"
        LblLPDIII6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(368, 178)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(29, 23)
        TextBox1.TabIndex = 38
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(368, 228)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(29, 23)
        TextBox2.TabIndex = 39
        ' 
        ' LblOffsetToHub
        ' 
        LblOffsetToHub.AutoSize = True
        tloMeasurements.SetColumnSpan(LblOffsetToHub, 2)
        LblOffsetToHub.Dock = DockStyle.Bottom
        LblOffsetToHub.Location = New Point(3, 99)
        LblOffsetToHub.Name = "LblOffsetToHub"
        LblOffsetToHub.Size = New Size(132, 15)
        LblOffsetToHub.TabIndex = 26
        LblOffsetToHub.Text = "Offset Toward Hub"
        ' 
        ' CboxOffsetToHub
        ' 
        tloMeasurements.SetColumnSpan(CboxOffsetToHub, 2)
        CboxOffsetToHub.Dock = DockStyle.Top
        CboxOffsetToHub.FormattingEnabled = True
        CboxOffsetToHub.Location = New Point(3, 117)
        CboxOffsetToHub.Name = "CboxOffsetToHub"
        CboxOffsetToHub.Size = New Size(132, 23)
        CboxOffsetToHub.TabIndex = 27
        ' 
        ' LblStatus
        ' 
        LblStatus.AutoSize = True
        tloMeasurements.SetColumnSpan(LblStatus, 3)
        LblStatus.Dock = DockStyle.Bottom
        LblStatus.Location = New Point(3, 175)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(201, 15)
        LblStatus.TabIndex = 28
        LblStatus.Text = "Scan Status"
        ' 
        ' TxtStatus
        ' 
        tloMeasurements.SetColumnSpan(TxtStatus, 3)
        TxtStatus.Dock = DockStyle.Top
        TxtStatus.Location = New Point(3, 193)
        TxtStatus.Name = "TxtStatus"
        TxtStatus.Size = New Size(201, 23)
        TxtStatus.TabIndex = 29
        ' 
        ' GrpSystem
        ' 
        tloMeasurements.SetColumnSpan(GrpSystem, 2)
        GrpSystem.Controls.Add(Tlo)
        GrpSystem.Dock = DockStyle.Fill
        GrpSystem.Location = New Point(624, 3)
        GrpSystem.Name = "GrpSystem"
        GrpSystem.Padding = New Padding(1, 2, 0, 1)
        tloMeasurements.SetRowSpan(GrpSystem, 2)
        GrpSystem.Size = New Size(132, 70)
        GrpSystem.TabIndex = 30
        GrpSystem.TabStop = False
        GrpSystem.Text = "System"
        ' 
        ' Tlo
        ' 
        Tlo.ColumnCount = 1
        Tlo.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        Tlo.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        Tlo.Controls.Add(RadSysImperical, 0, 0)
        Tlo.Controls.Add(RadSysMetric, 0, 1)
        Tlo.Dock = DockStyle.Fill
        Tlo.Location = New Point(1, 18)
        Tlo.Margin = New Padding(0)
        Tlo.Name = "Tlo"
        Tlo.RowCount = 2
        Tlo.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        Tlo.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        Tlo.Size = New Size(131, 51)
        Tlo.TabIndex = 0
        ' 
        ' RadSysImperical
        ' 
        RadSysImperical.AutoSize = True
        RadSysImperical.Dock = DockStyle.Fill
        RadSysImperical.Location = New Point(15, 3)
        RadSysImperical.Margin = New Padding(15, 3, 3, 3)
        RadSysImperical.Name = "RadSysImperical"
        RadSysImperical.Size = New Size(113, 19)
        RadSysImperical.TabIndex = 0
        RadSysImperical.TabStop = True
        RadSysImperical.Text = "Imperical"
        RadSysImperical.UseVisualStyleBackColor = True
        ' 
        ' RadSysMetric
        ' 
        RadSysMetric.AutoSize = True
        RadSysMetric.Dock = DockStyle.Fill
        RadSysMetric.Location = New Point(15, 28)
        RadSysMetric.Margin = New Padding(15, 3, 3, 3)
        RadSysMetric.Name = "RadSysMetric"
        RadSysMetric.Size = New Size(113, 20)
        RadSysMetric.TabIndex = 1
        RadSysMetric.TabStop = True
        RadSysMetric.Text = "Metric"
        RadSysMetric.UseVisualStyleBackColor = True
        ' 
        ' ComboBladeId
        ' 
        ComboBladeId.DisplayMember = "BladeId"
        ComboBladeId.FormattingEnabled = True
        ComboBladeId.Location = New Point(140, 39)
        ComboBladeId.Margin = New Padding(2, 1, 2, 1)
        ComboBladeId.Name = "ComboBladeId"
        ComboBladeId.Size = New Size(65, 23)
        ComboBladeId.TabIndex = 32
        ComboBladeId.ValueMember = "BladeId"
        ' 
        ' chkMeasurements
        ' 
        chkMeasurements.Appearance = Appearance.Button
        chkMeasurements.Location = New Point(210, 193)
        chkMeasurements.Name = "chkMeasurements"
        chkMeasurements.Size = New Size(63, 23)
        chkMeasurements.TabIndex = 33
        chkMeasurements.Text = "Start"
        chkMeasurements.TextAlign = ContentAlignment.MiddleCenter
        chkMeasurements.UseVisualStyleBackColor = True
        ' 
        ' timerMeasurements
        ' 
        ' 
        ' FrmMeasurements
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 571)
        Controls.Add(tloMeasurements)
        Controls.Add(StatusStrip1)
        Name = "FrmMeasurements"
        Text = "Measurements"
        CType(RadiusMeasurementBindingSource, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).EndInit()
        tloMeasurements.ResumeLayout(False)
        tloMeasurements.PerformLayout()
        gBoxPlotGraph.ResumeLayout(False)
        tloPlotGraph.ResumeLayout(False)
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        GrpTrack.ResumeLayout(False)
        tloTrack.ResumeLayout(False)
        tloTrack.PerformLayout()
        CType(GraphTrack, ComponentModel.ISupportInitialize).EndInit()
        CType(GrpRefBlades, ComponentModel.ISupportInitialize).EndInit()
        GrpLocalPitch.ResumeLayout(False)
        TloLocalPitchDetails.ResumeLayout(False)
        TloLocalPitchDetails.PerformLayout()
        GrpSystem.ResumeLayout(False)
        Tlo.ResumeLayout(False)
        Tlo.PerformLayout()
        CType(CellMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ExtremeMeasurementsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents labBlade As Label
    Friend WithEvents txtAngle As TextBox
    Friend WithEvents labAngle As Label
    Friend WithEvents labDepth As Label
    Friend WithEvents txtDepth As TextBox
    Friend WithEvents labRadius As Label
    Friend WithEvents txtRadius As TextBox
    Friend WithEvents labRadiusPercent As Label
    Friend WithEvents txtRadiusPercent As TextBox
    Friend WithEvents labWheelPitch As Label
    Friend WithEvents txtWheelPitch As TextBox
    Friend WithEvents cmdSetTip As Button
    Friend WithEvents cmdHome As Button
    Friend WithEvents cmdZero As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents WorkstationLabel As ToolStripStatusLabel
    Friend WithEvents EncodersSplitButton As ToolStripSplitButton
    Friend WithEvents InitializeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetAngleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetDepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetRadiusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents GridBladebyRadius As DataGridView
    Friend WithEvents tloMeasurements As TableLayoutPanel
    Friend WithEvents gBoxPlotGraph As GroupBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents tloPlotGraph As TableLayoutPanel
    Friend WithEvents BladeIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RadiusMeasurementBindingSource As BindingSource
    Friend WithEvents GraphTrack As DataVisualization.Charting.Chart
    Friend WithEvents GrpTrack As GroupBox
    Friend WithEvents tloTrack As TableLayoutPanel
    Friend WithEvents GrpRefBlades As DataVisualization.Charting.Chart
    Friend WithEvents RadTrackLeadingEdge As RadioButton
    Friend WithEvents RadTrackMidBlade As RadioButton
    Friend WithEvents RadTrackTrailingEdge As RadioButton
    Friend WithEvents LblRefBlade As Label
    Friend WithEvents LblRefRadius As Label
    Friend WithEvents LblRake As Label
    Friend WithEvents CboxRefBlade As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TxtRake As TextBox
    Friend WithEvents GrpLocalPitch As GroupBox
    Friend WithEvents LblOffsetToHub As Label
    Friend WithEvents CboxOffsetToHub As ComboBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents GrpSystem As GroupBox
    Friend WithEvents Tlo As TableLayoutPanel
    Friend WithEvents RadSysImperical As RadioButton
    Friend WithEvents RadSysMetric As RadioButton
    Friend WithEvents TloLocalPitchDetails As TableLayoutPanel
    Friend WithEvents LblLocalPitchDetails As Label
    Friend WithEvents CmdLPDS As Button
    Friend WithEvents CmdLPDI As Button
    Friend WithEvents CmdLPDII As Button
    Friend WithEvents CmdLPDIII As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents LblLPDS1 As Label
    Friend WithEvents LblLPDI1 As Label
    Friend WithEvents LblLPDII1 As Label
    Friend WithEvents LblLPDIII1 As Label
    Friend WithEvents LblLPDS2 As Label
    Friend WithEvents LblLPDI2 As Label
    Friend WithEvents LblLPDII2 As Label
    Friend WithEvents LblLPDIII2 As Label
    Friend WithEvents LblLPDS3 As Label
    Friend WithEvents LblLPDI3 As Label
    Friend WithEvents LblLPDII3 As Label
    Friend WithEvents LblLPDIII3 As Label
    Friend WithEvents LblLPDS4 As Label
    Friend WithEvents LblLPDI4 As Label
    Friend WithEvents LblLPDII4 As Label
    Friend WithEvents LblLPDIII4 As Label
    Friend WithEvents LblLPDS5 As Label
    Friend WithEvents LblLPDI5 As Label
    Friend WithEvents LblLPDII5 As Label
    Friend WithEvents LblLPDIII5 As Label
    Friend WithEvents LblLPDS6 As Label
    Friend WithEvents LblLPDI6 As Label
    Friend WithEvents LblLPDII6 As Label
    Friend WithEvents LblLPDIII6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CellMeasurementsBindingSource As BindingSource
    Friend WithEvents ExtremeMeasurementsBindingSource As BindingSource
    Friend WithEvents ComboBladeId As ComboBox
    Friend WithEvents chkMeasurements As CheckBox
    Friend WithEvents timerMeasurements As Timer
End Class
