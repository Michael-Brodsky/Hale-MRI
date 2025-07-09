<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeasurements
    Inherits System.Windows.Forms.Form

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
        labBlade = New Label()
        txtAngle = New TextBox()
        labAngle = New Label()
        labDepth = New Label()
        txtDepth = New TextBox()
        labRadius = New Label()
        txtRadius = New TextBox()
        labRadiusPercent = New Label()
        txtRadiusPercent = New TextBox()
        labDiameter = New Label()
        txtDiameter = New TextBox()
        labWheelPitch = New Label()
        txtWheelPitch = New TextBox()
        cmdStopScan = New Button()
        cmdSetTip = New Button()
        cmdHome = New Button()
        cmdStartScan = New Button()
        cmdZero = New Button()
        StatusStrip1 = New StatusStrip()
        WorkstationLabel = New ToolStripStatusLabel()
        EncodersSplitButton = New ToolStripSplitButton()
        InitializeToolStripMenuItem = New ToolStripMenuItem()
        ResetAngleToolStripMenuItem = New ToolStripMenuItem()
        ResetDepthToolStripMenuItem = New ToolStripMenuItem()
        ResetRadiusToolStripMenuItem = New ToolStripMenuItem()
        StatusLabel = New ToolStripStatusLabel()
        txtBlade = New TextBox()
        CountUpdate = New Timer(components)
        GridBladebyRadius = New DataGridView()
        Blades = New DataGridViewTextBoxColumn()
        BindingSource1 = New BindingSource(components)
        tloMeasurements = New TableLayoutPanel()
        gBoxPlotGraph = New GroupBox()
        Chart1 = New DataVisualization.Charting.Chart()
        tloPlotGraph = New TableLayoutPanel()
        StatusStrip1.SuspendLayout()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).BeginInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        tloMeasurements.SuspendLayout()
        gBoxPlotGraph.SuspendLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        tloPlotGraph.SuspendLayout()
        SuspendLayout()
        ' 
        ' labBlade
        ' 
        labBlade.AutoSize = True
        labBlade.Dock = DockStyle.Bottom
        labBlade.Location = New Point(140, 27)
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
        txtAngle.Location = New Point(2, 43)
        txtAngle.Margin = New Padding(2, 1, 0, 1)
        txtAngle.Name = "txtAngle"
        txtAngle.Size = New Size(136, 23)
        txtAngle.TabIndex = 2
        ' 
        ' labAngle
        ' 
        labAngle.AutoSize = True
        labAngle.Dock = DockStyle.Bottom
        labAngle.Location = New Point(2, 27)
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
        labDepth.Location = New Point(416, 27)
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
        txtDepth.Location = New Point(416, 43)
        txtDepth.Margin = New Padding(2, 1, 2, 1)
        txtDepth.Name = "txtDepth"
        txtDepth.Size = New Size(203, 23)
        txtDepth.TabIndex = 4
        ' 
        ' labRadius
        ' 
        labRadius.AutoSize = True
        labRadius.Dock = DockStyle.Bottom
        labRadius.Location = New Point(209, 27)
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
        txtRadius.Location = New Point(209, 43)
        txtRadius.Margin = New Padding(2, 1, 2, 1)
        txtRadius.Name = "txtRadius"
        txtRadius.Size = New Size(203, 23)
        txtRadius.TabIndex = 6
        ' 
        ' labRadiusPercent
        ' 
        labRadiusPercent.AutoSize = True
        tloMeasurements.SetColumnSpan(labRadiusPercent, 2)
        labRadiusPercent.Dock = DockStyle.Bottom
        labRadiusPercent.Location = New Point(209, 111)
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
        txtRadiusPercent.Location = New Point(209, 127)
        txtRadiusPercent.Margin = New Padding(2, 1, 2, 1)
        txtRadiusPercent.Name = "txtRadiusPercent"
        txtRadiusPercent.Size = New Size(203, 23)
        txtRadiusPercent.TabIndex = 8
        ' 
        ' labDiameter
        ' 
        labDiameter.AutoSize = True
        labDiameter.Dock = DockStyle.Bottom
        labDiameter.Location = New Point(2, 111)
        labDiameter.Margin = New Padding(2, 0, 2, 0)
        labDiameter.Name = "labDiameter"
        labDiameter.Size = New Size(65, 15)
        labDiameter.TabIndex = 11
        labDiameter.Text = "Diameter"
        ' 
        ' txtDiameter
        ' 
        tloMeasurements.SetColumnSpan(txtDiameter, 3)
        txtDiameter.Dock = DockStyle.Top
        txtDiameter.Location = New Point(2, 127)
        txtDiameter.Margin = New Padding(2, 1, 2, 1)
        txtDiameter.Name = "txtDiameter"
        txtDiameter.Size = New Size(203, 23)
        txtDiameter.TabIndex = 10
        ' 
        ' labWheelPitch
        ' 
        labWheelPitch.AutoSize = True
        tloMeasurements.SetColumnSpan(labWheelPitch, 2)
        labWheelPitch.Dock = DockStyle.Bottom
        labWheelPitch.Location = New Point(416, 111)
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
        txtWheelPitch.Location = New Point(416, 127)
        txtWheelPitch.Margin = New Padding(2, 1, 2, 1)
        txtWheelPitch.Name = "txtWheelPitch"
        txtWheelPitch.Size = New Size(203, 23)
        txtWheelPitch.TabIndex = 12
        ' 
        ' cmdStopScan
        ' 
        cmdStopScan.Location = New Point(347, 211)
        cmdStopScan.Margin = New Padding(2, 1, 2, 1)
        cmdStopScan.Name = "cmdStopScan"
        cmdStopScan.Size = New Size(65, 23)
        cmdStopScan.TabIndex = 14
        cmdStopScan.Text = "Stop Scan"
        cmdStopScan.UseVisualStyleBackColor = True
        ' 
        ' cmdSetTip
        ' 
        cmdSetTip.Location = New Point(485, 211)
        cmdSetTip.Margin = New Padding(2, 1, 2, 1)
        cmdSetTip.Name = "cmdSetTip"
        cmdSetTip.Size = New Size(65, 21)
        cmdSetTip.TabIndex = 15
        cmdSetTip.Text = "Set Tip"
        cmdSetTip.UseVisualStyleBackColor = True
        ' 
        ' cmdHome
        ' 
        cmdHome.Location = New Point(416, 211)
        cmdHome.Margin = New Padding(2, 1, 2, 1)
        cmdHome.Name = "cmdHome"
        cmdHome.Size = New Size(65, 23)
        cmdHome.TabIndex = 16
        cmdHome.Text = "Home"
        cmdHome.UseVisualStyleBackColor = True
        ' 
        ' cmdStartScan
        ' 
        cmdStartScan.Location = New Point(278, 211)
        cmdStartScan.Margin = New Padding(2, 1, 2, 1)
        cmdStartScan.Name = "cmdStartScan"
        cmdStartScan.Size = New Size(65, 23)
        cmdStartScan.TabIndex = 17
        cmdStartScan.Text = "Start Scan"
        cmdStartScan.UseVisualStyleBackColor = True
        ' 
        ' cmdZero
        ' 
        cmdZero.Location = New Point(554, 211)
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
        ' txtBlade
        ' 
        txtBlade.Dock = DockStyle.Top
        txtBlade.Location = New Point(138, 43)
        txtBlade.Margin = New Padding(0, 1, 2, 1)
        txtBlade.Name = "txtBlade"
        txtBlade.Size = New Size(67, 23)
        txtBlade.TabIndex = 20
        ' 
        ' CountUpdate
        ' 
        CountUpdate.Enabled = True
        CountUpdate.Interval = 25
        ' 
        ' GridBladebyRadius
        ' 
        GridBladebyRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladebyRadius.Columns.AddRange(New DataGridViewColumn() {Blades})
        tloMeasurements.SetColumnSpan(GridBladebyRadius, 9)
        GridBladebyRadius.Dock = DockStyle.Fill
        GridBladebyRadius.Location = New Point(0, 252)
        GridBladebyRadius.Margin = New Padding(0)
        GridBladebyRadius.Name = "GridBladebyRadius"
        GridBladebyRadius.RowHeadersVisible = False
        GridBladebyRadius.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        tloMeasurements.SetRowSpan(GridBladebyRadius, 4)
        GridBladebyRadius.SelectionMode = DataGridViewSelectionMode.CellSelect
        GridBladebyRadius.Size = New Size(621, 168)
        GridBladebyRadius.TabIndex = 21
        ' 
        ' Blades
        ' 
        Blades.HeaderText = "Blades"
        Blades.Name = "Blades"
        Blades.Width = 65
        ' 
        ' BindingSource1
        ' 
        BindingSource1.DataSource = GetType(LibDatabase.Models.CellMeasurement)
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
        tloMeasurements.Controls.Add(txtBlade, 2, 1)
        tloMeasurements.Controls.Add(labBlade, 2, 0)
        tloMeasurements.Controls.Add(txtRadius, 3, 1)
        tloMeasurements.Controls.Add(labRadius, 3, 0)
        tloMeasurements.Controls.Add(txtDepth, 6, 1)
        tloMeasurements.Controls.Add(labDepth, 6, 0)
        tloMeasurements.Controls.Add(txtDiameter, 0, 3)
        tloMeasurements.Controls.Add(labDiameter, 0, 2)
        tloMeasurements.Controls.Add(labWheelPitch, 6, 2)
        tloMeasurements.Controls.Add(labRadiusPercent, 3, 2)
        tloMeasurements.Controls.Add(txtWheelPitch, 6, 3)
        tloMeasurements.Controls.Add(txtRadiusPercent, 3, 3)
        tloMeasurements.Controls.Add(GridBladebyRadius, 0, 6)
        tloMeasurements.Controls.Add(cmdZero, 8, 5)
        tloMeasurements.Controls.Add(cmdHome, 6, 5)
        tloMeasurements.Controls.Add(cmdSetTip, 7, 5)
        tloMeasurements.Controls.Add(cmdStopScan, 5, 5)
        tloMeasurements.Controls.Add(cmdStartScan, 4, 5)
        tloMeasurements.Controls.Add(gBoxPlotGraph, 11, 0)
        tloMeasurements.Dock = DockStyle.Fill
        tloMeasurements.Location = New Point(0, 0)
        tloMeasurements.Name = "tloMeasurements"
        tloMeasurements.RowCount = 13
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
        tloMeasurements.RowStyles.Add(New RowStyle(SizeType.Percent, 7.69230843F))
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
        tloMeasurements.SetRowSpan(gBoxPlotGraph, 7)
        gBoxPlotGraph.Size = New Size(345, 294)
        gBoxPlotGraph.TabIndex = 22
        gBoxPlotGraph.TabStop = False
        gBoxPlotGraph.Text = "Plot"
        ' 
        ' Chart1
        ' 
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.Maximum = 1R
        ChartArea1.AxisX.Minimum = -1R
        ChartArea1.AxisY.Interval = 10R
        ChartArea1.AxisY.LabelStyle.Enabled = False
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.Maximum = 1R
        ChartArea1.AxisY.Minimum = -1R
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
        Chart1.Size = New Size(232, 225)
        Chart1.TabIndex = 23
        Chart1.Text = "Chart1"
        ' 
        ' tloPlotGraph
        ' 
        tloPlotGraph.ColumnCount = 2
        tloPlotGraph.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        tloPlotGraph.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        tloPlotGraph.Controls.Add(Chart1, 1, 0)
        tloPlotGraph.Dock = DockStyle.Fill
        tloPlotGraph.Location = New Point(3, 19)
        tloPlotGraph.Margin = New Padding(0)
        tloPlotGraph.Name = "tloPlotGraph"
        tloPlotGraph.RowCount = 2
        tloPlotGraph.RowStyles.Add(New RowStyle(SizeType.Percent, 85F))
        tloPlotGraph.RowStyles.Add(New RowStyle(SizeType.Percent, 15F))
        tloPlotGraph.Size = New Size(339, 272)
        tloPlotGraph.TabIndex = 0
        ' 
        ' FrmMeasurements
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 571)
        Controls.Add(tloMeasurements)
        Controls.Add(StatusStrip1)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmMeasurements"
        Text = "Measurements"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).EndInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        tloMeasurements.ResumeLayout(False)
        tloMeasurements.PerformLayout()
        gBoxPlotGraph.ResumeLayout(False)
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        tloPlotGraph.ResumeLayout(False)
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
    Friend WithEvents labDiameter As Label
    Friend WithEvents txtDiameter As TextBox
    Friend WithEvents labWheelPitch As Label
    Friend WithEvents txtWheelPitch As TextBox
    Friend WithEvents cmdStopScan As Button
    Friend WithEvents cmdSetTip As Button
    Friend WithEvents cmdHome As Button
    Friend WithEvents cmdStartScan As Button
    Friend WithEvents cmdZero As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents WorkstationLabel As ToolStripStatusLabel
    Friend WithEvents EncodersSplitButton As ToolStripSplitButton
    Friend WithEvents InitializeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetAngleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetDepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetRadiusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents txtBlade As TextBox
    Friend WithEvents CountUpdate As Timer
    Friend WithEvents GridBladebyRadius As DataGridView
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Blades As DataGridViewTextBoxColumn
    Friend WithEvents tloMeasurements As TableLayoutPanel
    Friend WithEvents gBoxPlotGraph As GroupBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents tloPlotGraph As TableLayoutPanel
End Class
