<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmComparison
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
        tLayoutComparison = New TableLayoutPanel()
        PictLogo = New PictureBox()
        DataGridJobDetails = New DataGridView()
        tlayoutComparisonControls = New TableLayoutPanel()
        ComboRadiusorBlade = New ComboBox()
        ChkExamineoneBlade = New CheckBox()
        ChkSpline = New CheckBox()
        ChkShowTrack = New CheckBox()
        ChkGraphEntireScan = New CheckBox()
        ChkKeepforComp = New CheckBox()
        LabRefPitch = New Label()
        LabSegments = New Label()
        LabRadiusorBlade = New Label()
        LabTrackRefBlade = New Label()
        TxtRefPitch = New TextBox()
        ChkCenterRef = New CheckBox()
        ComboTrackRefBlade = New ComboBox()
        CmdSelectProgression = New Button()
        CmdPrintAllGraphs = New Button()
        LblAxesScaling = New Label()
        CBoxAxesScaling = New ComboBox()
        LblFont = New Label()
        TrackFont = New TrackBar()
        TrackSegments = New TrackBar()
        PanelChart = New Panel()
        TLayoutCompCharts = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        JobDetailsBindingSource = New BindingSource(components)
        MeasurementTypesBindingSource = New BindingSource(components)
        EmployeeBindingSource = New BindingSource(components)
        ToleranceBindingSource = New BindingSource(components)
        StartDateCol = New DataGridViewTextBoxColumn()
        MeasurementTypeCol = New DataGridViewComboBoxColumn()
        ClassCol = New DataGridViewComboBoxColumn()
        EmployeeCol = New DataGridViewComboBoxColumn()
        DescriptionCol = New DataGridViewTextBoxColumn()
        TLayoutNavigation = New TableLayoutPanel()
        CmdMeasure = New Button()
        CmdLocalPitch = New Button()
        CmdGraph = New Button()
        CmdInspect = New Button()
        CmdComparison = New Button()
        tLayoutComparison.SuspendLayout()
        CType(PictLogo, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        tlayoutComparisonControls.SuspendLayout()
        CType(TrackFont, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackSegments, ComponentModel.ISupportInitialize).BeginInit()
        PanelChart.SuspendLayout()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ToleranceBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TLayoutNavigation.SuspendLayout()
        SuspendLayout()
        ' 
        ' tLayoutComparison
        ' 
        tLayoutComparison.ColumnCount = 7
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 202F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 10F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutComparison.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tLayoutComparison.Controls.Add(PictLogo, 0, 0)
        tLayoutComparison.Controls.Add(DataGridJobDetails, 4, 1)
        tLayoutComparison.Controls.Add(tlayoutComparisonControls, 0, 2)
        tLayoutComparison.Controls.Add(PanelChart, 1, 2)
        tLayoutComparison.Controls.Add(RecordNavigationBar1, 4, 0)
        tLayoutComparison.Controls.Add(TLayoutNavigation, 2, 1)
        tLayoutComparison.Dock = DockStyle.Fill
        tLayoutComparison.Location = New Point(0, 0)
        tLayoutComparison.Name = "tLayoutComparison"
        tLayoutComparison.RowCount = 3
        tLayoutComparison.RowStyles.Add(New RowStyle(SizeType.Absolute, 33F))
        tLayoutComparison.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tLayoutComparison.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tLayoutComparison.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tLayoutComparison.Size = New Size(1184, 636)
        tLayoutComparison.TabIndex = 0
        ' 
        ' PictLogo
        ' 
        tLayoutComparison.SetColumnSpan(PictLogo, 2)
        PictLogo.Dock = DockStyle.Fill
        PictLogo.Image = My.Resources.Resources.HaleMRIlogo
        PictLogo.Location = New Point(1, 0)
        PictLogo.Margin = New Padding(1, 0, 0, 0)
        PictLogo.Name = "PictLogo"
        tLayoutComparison.SetRowSpan(PictLogo, 2)
        PictLogo.Size = New Size(211, 113)
        PictLogo.SizeMode = PictureBoxSizeMode.StretchImage
        PictLogo.TabIndex = 0
        PictLogo.TabStop = False
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridJobDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDateCol, MeasurementTypeCol, ClassCol, EmployeeCol, DescriptionCol})
        tLayoutComparison.SetColumnSpan(DataGridJobDetails, 3)
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Dock = DockStyle.Fill
        DataGridJobDetails.Location = New Point(603, 36)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.RowHeadersVisible = False
        DataGridJobDetails.Size = New Size(578, 74)
        DataGridJobDetails.TabIndex = 1
        ' 
        ' tlayoutComparisonControls
        ' 
        tlayoutComparisonControls.ColumnCount = 1
        tlayoutComparisonControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlayoutComparisonControls.Controls.Add(ComboRadiusorBlade, 0, 10)
        tlayoutComparisonControls.Controls.Add(ChkExamineoneBlade, 0, 6)
        tlayoutComparisonControls.Controls.Add(ChkSpline, 0, 15)
        tlayoutComparisonControls.Controls.Add(ChkShowTrack, 0, 5)
        tlayoutComparisonControls.Controls.Add(ChkGraphEntireScan, 0, 4)
        tlayoutComparisonControls.Controls.Add(ChkKeepforComp, 0, 3)
        tlayoutComparisonControls.Controls.Add(LabRefPitch, 0, 0)
        tlayoutComparisonControls.Controls.Add(LabSegments, 0, 11)
        tlayoutComparisonControls.Controls.Add(LabRadiusorBlade, 0, 9)
        tlayoutComparisonControls.Controls.Add(LabTrackRefBlade, 0, 7)
        tlayoutComparisonControls.Controls.Add(TxtRefPitch, 0, 1)
        tlayoutComparisonControls.Controls.Add(ChkCenterRef, 0, 2)
        tlayoutComparisonControls.Controls.Add(ComboTrackRefBlade, 0, 8)
        tlayoutComparisonControls.Controls.Add(CmdSelectProgression, 0, 13)
        tlayoutComparisonControls.Controls.Add(CmdPrintAllGraphs, 0, 14)
        tlayoutComparisonControls.Controls.Add(LblAxesScaling, 0, 16)
        tlayoutComparisonControls.Controls.Add(CBoxAxesScaling, 0, 17)
        tlayoutComparisonControls.Controls.Add(LblFont, 0, 18)
        tlayoutComparisonControls.Controls.Add(TrackFont, 0, 19)
        tlayoutComparisonControls.Controls.Add(TrackSegments, 0, 12)
        tlayoutComparisonControls.Dock = DockStyle.Fill
        tlayoutComparisonControls.Location = New Point(1, 113)
        tlayoutComparisonControls.Margin = New Padding(1, 0, 0, 0)
        tlayoutComparisonControls.Name = "tlayoutComparisonControls"
        tlayoutComparisonControls.RowCount = 21
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tlayoutComparisonControls.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlayoutComparisonControls.Size = New Size(201, 523)
        tlayoutComparisonControls.TabIndex = 3
        ' 
        ' ComboRadiusorBlade
        ' 
        ComboRadiusorBlade.Dock = DockStyle.Top
        ComboRadiusorBlade.FormattingEnabled = True
        ComboRadiusorBlade.Location = New Point(3, 270)
        ComboRadiusorBlade.Margin = New Padding(3, 0, 3, 0)
        ComboRadiusorBlade.Name = "ComboRadiusorBlade"
        ComboRadiusorBlade.Size = New Size(195, 28)
        ComboRadiusorBlade.TabIndex = 18
        ' 
        ' ChkExamineoneBlade
        ' 
        ChkExamineoneBlade.AutoSize = True
        ChkExamineoneBlade.Dock = DockStyle.Left
        ChkExamineoneBlade.Location = New Point(10, 173)
        ChkExamineoneBlade.Margin = New Padding(10, 3, 3, 3)
        ChkExamineoneBlade.Name = "ChkExamineoneBlade"
        ChkExamineoneBlade.Size = New Size(155, 24)
        ChkExamineoneBlade.TabIndex = 16
        ChkExamineoneBlade.Text = "Examine one Blade"
        ChkExamineoneBlade.UseVisualStyleBackColor = True
        ' 
        ' ChkSpline
        ' 
        ChkSpline.AutoSize = True
        ChkSpline.Dock = DockStyle.Left
        ChkSpline.Location = New Point(10, 413)
        ChkSpline.Margin = New Padding(10, 3, 3, 3)
        ChkSpline.Name = "ChkSpline"
        ChkSpline.Size = New Size(69, 24)
        ChkSpline.TabIndex = 15
        ChkSpline.Text = "Spline"
        ChkSpline.UseVisualStyleBackColor = True
        ' 
        ' ChkShowTrack
        ' 
        ChkShowTrack.AutoSize = True
        ChkShowTrack.Dock = DockStyle.Left
        ChkShowTrack.Location = New Point(10, 143)
        ChkShowTrack.Margin = New Padding(10, 3, 3, 3)
        ChkShowTrack.Name = "ChkShowTrack"
        ChkShowTrack.Size = New Size(102, 24)
        ChkShowTrack.TabIndex = 8
        ChkShowTrack.Text = "Show Track"
        ChkShowTrack.UseVisualStyleBackColor = True
        ' 
        ' ChkGraphEntireScan
        ' 
        ChkGraphEntireScan.AutoSize = True
        ChkGraphEntireScan.Dock = DockStyle.Left
        ChkGraphEntireScan.Location = New Point(10, 113)
        ChkGraphEntireScan.Margin = New Padding(10, 3, 3, 3)
        ChkGraphEntireScan.Name = "ChkGraphEntireScan"
        ChkGraphEntireScan.Size = New Size(145, 24)
        ChkGraphEntireScan.TabIndex = 7
        ChkGraphEntireScan.Text = "Graph Entire Scan"
        ChkGraphEntireScan.UseVisualStyleBackColor = True
        ' 
        ' ChkKeepforComp
        ' 
        ChkKeepforComp.AutoSize = True
        ChkKeepforComp.Dock = DockStyle.Left
        ChkKeepforComp.Location = New Point(10, 83)
        ChkKeepforComp.Margin = New Padding(10, 3, 3, 3)
        ChkKeepforComp.Name = "ChkKeepforComp"
        ChkKeepforComp.Size = New Size(169, 24)
        ChkKeepforComp.TabIndex = 6
        ChkKeepforComp.Text = "Keep for Comparison"
        ChkKeepforComp.UseVisualStyleBackColor = True
        ' 
        ' LabRefPitch
        ' 
        LabRefPitch.AutoSize = True
        LabRefPitch.Dock = DockStyle.Bottom
        LabRefPitch.Location = New Point(3, 0)
        LabRefPitch.Name = "LabRefPitch"
        LabRefPitch.Size = New Size(195, 20)
        LabRefPitch.TabIndex = 0
        LabRefPitch.Text = "Ref Pitch"
        ' 
        ' LabSegments
        ' 
        LabSegments.AutoSize = True
        LabSegments.Dock = DockStyle.Bottom
        LabSegments.Location = New Point(3, 300)
        LabSegments.Name = "LabSegments"
        LabSegments.Size = New Size(195, 20)
        LabSegments.TabIndex = 3
        LabSegments.Text = "Segments"
        ' 
        ' LabRadiusorBlade
        ' 
        LabRadiusorBlade.AutoSize = True
        LabRadiusorBlade.Dock = DockStyle.Bottom
        LabRadiusorBlade.Location = New Point(3, 250)
        LabRadiusorBlade.Name = "LabRadiusorBlade"
        LabRadiusorBlade.Size = New Size(195, 20)
        LabRadiusorBlade.TabIndex = 2
        LabRadiusorBlade.Text = "Radius"
        ' 
        ' LabTrackRefBlade
        ' 
        LabTrackRefBlade.AutoSize = True
        LabTrackRefBlade.Dock = DockStyle.Bottom
        LabTrackRefBlade.Location = New Point(3, 200)
        LabTrackRefBlade.Name = "LabTrackRefBlade"
        LabTrackRefBlade.Size = New Size(195, 20)
        LabTrackRefBlade.TabIndex = 1
        LabTrackRefBlade.Text = "Track Ref Blade"
        ' 
        ' TxtRefPitch
        ' 
        TxtRefPitch.Dock = DockStyle.Top
        TxtRefPitch.Location = New Point(3, 23)
        TxtRefPitch.Name = "TxtRefPitch"
        TxtRefPitch.Size = New Size(195, 27)
        TxtRefPitch.TabIndex = 4
        ' 
        ' ChkCenterRef
        ' 
        ChkCenterRef.AutoSize = True
        ChkCenterRef.Dock = DockStyle.Left
        ChkCenterRef.Location = New Point(10, 53)
        ChkCenterRef.Margin = New Padding(10, 3, 3, 3)
        ChkCenterRef.Name = "ChkCenterRef"
        ChkCenterRef.Size = New Size(97, 24)
        ChkCenterRef.TabIndex = 5
        ChkCenterRef.Text = "Center Ref"
        ChkCenterRef.UseVisualStyleBackColor = True
        ' 
        ' ComboTrackRefBlade
        ' 
        ComboTrackRefBlade.Dock = DockStyle.Top
        ComboTrackRefBlade.FormattingEnabled = True
        ComboTrackRefBlade.Location = New Point(3, 220)
        ComboTrackRefBlade.Margin = New Padding(3, 0, 3, 0)
        ComboTrackRefBlade.Name = "ComboTrackRefBlade"
        ComboTrackRefBlade.Size = New Size(195, 28)
        ComboTrackRefBlade.TabIndex = 17
        ' 
        ' CmdSelectProgression
        ' 
        CmdSelectProgression.Dock = DockStyle.Fill
        CmdSelectProgression.Location = New Point(1, 351)
        CmdSelectProgression.Margin = New Padding(1)
        CmdSelectProgression.Name = "CmdSelectProgression"
        CmdSelectProgression.Size = New Size(199, 28)
        CmdSelectProgression.TabIndex = 20
        CmdSelectProgression.Text = "Select Progression"
        CmdSelectProgression.UseVisualStyleBackColor = True
        ' 
        ' CmdPrintAllGraphs
        ' 
        CmdPrintAllGraphs.Dock = DockStyle.Fill
        CmdPrintAllGraphs.Location = New Point(1, 381)
        CmdPrintAllGraphs.Margin = New Padding(1)
        CmdPrintAllGraphs.Name = "CmdPrintAllGraphs"
        CmdPrintAllGraphs.Size = New Size(199, 28)
        CmdPrintAllGraphs.TabIndex = 21
        CmdPrintAllGraphs.Text = "Print All Graphs"
        CmdPrintAllGraphs.UseVisualStyleBackColor = True
        ' 
        ' LblAxesScaling
        ' 
        LblAxesScaling.AutoSize = True
        LblAxesScaling.Dock = DockStyle.Fill
        LblAxesScaling.Location = New Point(3, 440)
        LblAxesScaling.Name = "LblAxesScaling"
        LblAxesScaling.Size = New Size(195, 20)
        LblAxesScaling.TabIndex = 22
        LblAxesScaling.Text = "Axes Scaling"
        ' 
        ' CBoxAxesScaling
        ' 
        CBoxAxesScaling.Dock = DockStyle.Fill
        CBoxAxesScaling.FormattingEnabled = True
        CBoxAxesScaling.Location = New Point(3, 460)
        CBoxAxesScaling.Margin = New Padding(3, 0, 3, 0)
        CBoxAxesScaling.Name = "CBoxAxesScaling"
        CBoxAxesScaling.Size = New Size(195, 28)
        CBoxAxesScaling.TabIndex = 23
        ' 
        ' LblFont
        ' 
        LblFont.AutoSize = True
        LblFont.Dock = DockStyle.Bottom
        LblFont.Location = New Point(3, 490)
        LblFont.Name = "LblFont"
        LblFont.Size = New Size(195, 20)
        LblFont.TabIndex = 24
        LblFont.Text = "Font"
        ' 
        ' TrackFont
        ' 
        TrackFont.Dock = DockStyle.Top
        TrackFont.Location = New Point(0, 510)
        TrackFont.Margin = New Padding(0)
        TrackFont.Maximum = 22
        TrackFont.Minimum = 9
        TrackFont.Name = "TrackFont"
        TrackFont.Size = New Size(201, 35)
        TrackFont.TabIndex = 25
        TrackFont.Value = 11
        ' 
        ' TrackSegments
        ' 
        TrackSegments.Dock = DockStyle.Fill
        TrackSegments.Location = New Point(3, 323)
        TrackSegments.Minimum = 1
        TrackSegments.Name = "TrackSegments"
        TrackSegments.Size = New Size(195, 24)
        TrackSegments.TabIndex = 26
        TrackSegments.Value = 1
        ' 
        ' PanelChart
        ' 
        PanelChart.AutoScroll = True
        tLayoutComparison.SetColumnSpan(PanelChart, 6)
        PanelChart.Controls.Add(TLayoutCompCharts)
        PanelChart.Dock = DockStyle.Fill
        PanelChart.Location = New Point(202, 113)
        PanelChart.Margin = New Padding(0)
        PanelChart.Name = "PanelChart"
        PanelChart.Size = New Size(982, 523)
        PanelChart.TabIndex = 4
        ' 
        ' TLayoutCompCharts
        ' 
        TLayoutCompCharts.ColumnCount = 1
        TLayoutCompCharts.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutCompCharts.Dock = DockStyle.Top
        TLayoutCompCharts.Location = New Point(0, 0)
        TLayoutCompCharts.Margin = New Padding(0)
        TLayoutCompCharts.Name = "TLayoutCompCharts"
        TLayoutCompCharts.RowCount = 2
        TLayoutCompCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutCompCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutCompCharts.Size = New Size(982, 400)
        TLayoutCompCharts.TabIndex = 0
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        tLayoutComparison.SetColumnSpan(RecordNavigationBar1, 3)
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
        RecordNavigationBar1.TabIndex = 5
        ' 
        ' JobDetailsBindingSource
        ' 
        ' 
        ' MeasurementTypesBindingSource
        ' 
        MeasurementTypesBindingSource.DataSource = GetType(LibDatabase.Models.MeasurementType)
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        ' 
        ' ToleranceBindingSource
        ' 
        ToleranceBindingSource.DataSource = GetType(LibDatabase.Models.Tolerance)
        ' 
        ' StartDateCol
        ' 
        StartDateCol.HeaderText = "Start Date"
        StartDateCol.Name = "StartDateCol"
        StartDateCol.Width = 101
        ' 
        ' MeasurementTypeCol
        ' 
        MeasurementTypeCol.HeaderText = "Measurement"
        MeasurementTypeCol.Name = "MeasurementTypeCol"
        MeasurementTypeCol.Width = 105
        ' 
        ' ClassCol
        ' 
        ClassCol.DataSource = ToleranceBindingSource
        ClassCol.DisplayMember = "ToleranceClass"
        ClassCol.HeaderText = "Class"
        ClassCol.Name = "ClassCol"
        ClassCol.ValueMember = "ToleranceClass"
        ClassCol.Width = 48
        ' 
        ' EmployeeCol
        ' 
        EmployeeCol.DataSource = EmployeeBindingSource
        EmployeeCol.HeaderText = "Employee"
        EmployeeCol.Name = "EmployeeCol"
        EmployeeCol.Width = 81
        ' 
        ' DescriptionCol
        ' 
        DescriptionCol.HeaderText = "Description"
        DescriptionCol.Name = "DescriptionCol"
        DescriptionCol.Width = 110
        ' 
        ' TLayoutNavigation
        ' 
        TLayoutNavigation.ColumnCount = 5
        tLayoutComparison.SetColumnSpan(TLayoutNavigation, 2)
        TLayoutNavigation.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutNavigation.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutNavigation.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutNavigation.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutNavigation.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TLayoutNavigation.Controls.Add(CmdComparison, 4, 0)
        TLayoutNavigation.Controls.Add(CmdInspect, 3, 0)
        TLayoutNavigation.Controls.Add(CmdGraph, 2, 0)
        TLayoutNavigation.Controls.Add(CmdLocalPitch, 1, 0)
        TLayoutNavigation.Controls.Add(CmdMeasure, 0, 0)
        TLayoutNavigation.Dock = DockStyle.Fill
        TLayoutNavigation.Location = New Point(212, 33)
        TLayoutNavigation.Margin = New Padding(0)
        TLayoutNavigation.Name = "TLayoutNavigation"
        TLayoutNavigation.RowCount = 1
        TLayoutNavigation.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLayoutNavigation.Size = New Size(388, 80)
        TLayoutNavigation.TabIndex = 6
        ' 
        ' CmdMeasure
        ' 
        CmdMeasure.Dock = DockStyle.Fill
        CmdMeasure.Location = New Point(3, 3)
        CmdMeasure.Name = "CmdMeasure"
        CmdMeasure.Size = New Size(71, 74)
        CmdMeasure.TabIndex = 0
        CmdMeasure.Text = "Measure"
        CmdMeasure.UseVisualStyleBackColor = True
        ' 
        ' CmdLocalPitch
        ' 
        CmdLocalPitch.Dock = DockStyle.Fill
        CmdLocalPitch.Location = New Point(80, 3)
        CmdLocalPitch.Name = "CmdLocalPitch"
        CmdLocalPitch.Size = New Size(71, 74)
        CmdLocalPitch.TabIndex = 1
        CmdLocalPitch.Text = "Local Pitch"
        CmdLocalPitch.UseVisualStyleBackColor = True
        ' 
        ' CmdGraph
        ' 
        CmdGraph.Dock = DockStyle.Fill
        CmdGraph.Location = New Point(157, 3)
        CmdGraph.Name = "CmdGraph"
        CmdGraph.Size = New Size(71, 74)
        CmdGraph.TabIndex = 2
        CmdGraph.Text = "Graph"
        CmdGraph.UseVisualStyleBackColor = True
        ' 
        ' CmdInspect
        ' 
        CmdInspect.Dock = DockStyle.Fill
        CmdInspect.Location = New Point(234, 3)
        CmdInspect.Name = "CmdInspect"
        CmdInspect.Size = New Size(71, 74)
        CmdInspect.TabIndex = 3
        CmdInspect.Text = "Inspect"
        CmdInspect.UseVisualStyleBackColor = True
        ' 
        ' CmdComparison
        ' 
        CmdComparison.Dock = DockStyle.Fill
        CmdComparison.Location = New Point(311, 3)
        CmdComparison.Name = "CmdComparison"
        CmdComparison.Size = New Size(74, 74)
        CmdComparison.TabIndex = 4
        CmdComparison.Text = "Comp."
        CmdComparison.UseVisualStyleBackColor = True
        ' 
        ' FrmComparison
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1184, 636)
        Controls.Add(tLayoutComparison)
        Font = New Font("Segoe UI", 11F)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmComparison"
        Text = "FrmComparison"
        tLayoutComparison.ResumeLayout(False)
        tLayoutComparison.PerformLayout()
        CType(PictLogo, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        tlayoutComparisonControls.ResumeLayout(False)
        tlayoutComparisonControls.PerformLayout()
        CType(TrackFont, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackSegments, ComponentModel.ISupportInitialize).EndInit()
        PanelChart.ResumeLayout(False)
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ToleranceBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TLayoutNavigation.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tLayoutComparison As TableLayoutPanel
    Friend WithEvents PictLogo As PictureBox
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents tlayoutComparisonControls As TableLayoutPanel
    Friend WithEvents ChkExamineoneBlade As CheckBox
    Friend WithEvents ChkSpline As CheckBox
    Friend WithEvents ChkShowTrack As CheckBox
    Friend WithEvents ChkGraphEntireScan As CheckBox
    Friend WithEvents ChkKeepforComp As CheckBox
    Friend WithEvents LabRefPitch As Label
    Friend WithEvents LabSegments As Label
    Friend WithEvents LabRadiusorBlade As Label
    Friend WithEvents LabTrackRefBlade As Label
    Friend WithEvents TxtRefPitch As TextBox
    Friend WithEvents ChkCenterRef As CheckBox
    Friend WithEvents ComboRadiusorBlade As ComboBox
    Friend WithEvents ComboTrackRefBlade As ComboBox
    Friend WithEvents CmdSelectProgression As Button
    Friend WithEvents CmdPrintAllGraphs As Button
    Friend WithEvents PanelChart As Panel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents MeasurementTypesBindingSource As BindingSource
    Friend WithEvents TLayoutCompCharts As TableLayoutPanel
    Friend WithEvents LblAxesScaling As Label
    Friend WithEvents CBoxAxesScaling As ComboBox
    Friend WithEvents LblFont As Label
    Friend WithEvents TrackFont As TrackBar
    Friend WithEvents TrackSegments As TrackBar
    Friend WithEvents StartDateCol As DataGridViewTextBoxColumn
    Friend WithEvents MeasurementTypeCol As DataGridViewComboBoxColumn
    Friend WithEvents ClassCol As DataGridViewComboBoxColumn
    Friend WithEvents ToleranceBindingSource As BindingSource
    Friend WithEvents EmployeeCol As DataGridViewComboBoxColumn
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents DescriptionCol As DataGridViewTextBoxColumn
    Friend WithEvents TLayoutNavigation As TableLayoutPanel
    Friend WithEvents CmdComparison As Button
    Friend WithEvents CmdInspect As Button
    Friend WithEvents CmdGraph As Button
    Friend WithEvents CmdLocalPitch As Button
    Friend WithEvents CmdMeasure As Button
End Class
