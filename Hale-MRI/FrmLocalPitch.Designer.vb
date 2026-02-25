<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocalPitch
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
        tLayoutLocalPitch = New TableLayoutPanel()
        tLayoutNavigationButtons = New TableLayoutPanel()
        CmdComparisonForm = New Button()
        CmdInspectForm = New Button()
        CmdGraphForm = New Button()
        CmdLocalPitchForm = New Button()
        CmdMeasureForm = New Button()
        LabCompareTo = New Label()
        ComboCompareto = New ComboBox()
        LabRadius = New Label()
        ChkShowReference = New CheckBox()
        ChkShowTable = New CheckBox()
        ComboRadius = New ComboBox()
        LabTolerance = New Label()
        ComboToleranceClass = New ComboBox()
        LabBlade = New Label()
        ComboBlade = New ComboBox()
        LabGraphStyle = New Label()
        ComboGraphStyle = New ComboBox()
        ChkCenterReference = New CheckBox()
        ChkIncludeTrack = New CheckBox()
        CmdPrint = New Button()
        pBoxLogo = New PictureBox()
        GridJobDetails = New DataGridView()
        StartDate = New DataGridViewTextBoxColumn()
        MeasurementType = New DataGridViewComboBoxColumn()
        ToleranceClass = New DataGridViewComboBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        Description = New DataGridViewTextBoxColumn()
        LabJobNumber = New Label()
        JobDetailsBindingSource = New BindingSource(components)
        EmployeesBindingSource = New BindingSource(components)
        BindingSource2 = New BindingSource(components)
        ClassBindingSource = New BindingSource(components)
        MeasurementTypesBindingSource = New BindingSource(components)
        TLayoutCharts = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        tLayoutLocalPitch.SuspendLayout()
        tLayoutNavigationButtons.SuspendLayout()
        CType(pBoxLogo, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BindingSource2, ComponentModel.ISupportInitialize).BeginInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tLayoutLocalPitch
        ' 
        tLayoutLocalPitch.ColumnCount = 5
        tLayoutLocalPitch.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 130F))
        tLayoutLocalPitch.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 82F))
        tLayoutLocalPitch.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tLayoutLocalPitch.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tLayoutLocalPitch.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tLayoutLocalPitch.Controls.Add(tLayoutNavigationButtons, 2, 1)
        tLayoutLocalPitch.Controls.Add(LabCompareTo, 0, 2)
        tLayoutLocalPitch.Controls.Add(ComboCompareto, 0, 3)
        tLayoutLocalPitch.Controls.Add(LabRadius, 0, 4)
        tLayoutLocalPitch.Controls.Add(ChkShowReference, 0, 15)
        tLayoutLocalPitch.Controls.Add(ChkShowTable, 0, 13)
        tLayoutLocalPitch.Controls.Add(ComboRadius, 0, 5)
        tLayoutLocalPitch.Controls.Add(LabTolerance, 0, 6)
        tLayoutLocalPitch.Controls.Add(ComboToleranceClass, 0, 7)
        tLayoutLocalPitch.Controls.Add(LabBlade, 0, 8)
        tLayoutLocalPitch.Controls.Add(ComboBlade, 0, 9)
        tLayoutLocalPitch.Controls.Add(LabGraphStyle, 0, 10)
        tLayoutLocalPitch.Controls.Add(ComboGraphStyle, 0, 11)
        tLayoutLocalPitch.Controls.Add(ChkCenterReference, 0, 12)
        tLayoutLocalPitch.Controls.Add(ChkIncludeTrack, 0, 14)
        tLayoutLocalPitch.Controls.Add(CmdPrint, 0, 16)
        tLayoutLocalPitch.Controls.Add(pBoxLogo, 0, 0)
        tLayoutLocalPitch.Controls.Add(GridJobDetails, 3, 1)
        tLayoutLocalPitch.Controls.Add(LabJobNumber, 2, 0)
        tLayoutLocalPitch.Controls.Add(TLayoutCharts, 1, 2)
        tLayoutLocalPitch.Controls.Add(RecordNavigationBar1, 3, 0)
        tLayoutLocalPitch.Dock = DockStyle.Fill
        tLayoutLocalPitch.Location = New Point(0, 0)
        tLayoutLocalPitch.Margin = New Padding(3, 5, 3, 4)
        tLayoutLocalPitch.Name = "tLayoutLocalPitch"
        tLayoutLocalPitch.RowCount = 18
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 33F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tLayoutLocalPitch.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tLayoutLocalPitch.Size = New Size(1184, 636)
        tLayoutLocalPitch.TabIndex = 0
        ' 
        ' tLayoutNavigationButtons
        ' 
        tLayoutNavigationButtons.ColumnCount = 5
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
        tLayoutNavigationButtons.Size = New Size(323, 80)
        tLayoutNavigationButtons.TabIndex = 27
        ' 
        ' CmdComparisonForm
        ' 
        CmdComparisonForm.Dock = DockStyle.Fill
        CmdComparisonForm.Location = New Point(259, 3)
        CmdComparisonForm.Name = "CmdComparisonForm"
        CmdComparisonForm.Size = New Size(61, 74)
        CmdComparisonForm.TabIndex = 4
        CmdComparisonForm.Text = "Comp."
        CmdComparisonForm.UseVisualStyleBackColor = True
        ' 
        ' CmdInspectForm
        ' 
        CmdInspectForm.Dock = DockStyle.Fill
        CmdInspectForm.Location = New Point(195, 3)
        CmdInspectForm.Name = "CmdInspectForm"
        CmdInspectForm.Size = New Size(58, 74)
        CmdInspectForm.TabIndex = 3
        CmdInspectForm.Text = "Inspect"
        CmdInspectForm.UseVisualStyleBackColor = True
        ' 
        ' CmdGraphForm
        ' 
        CmdGraphForm.Dock = DockStyle.Fill
        CmdGraphForm.Location = New Point(131, 3)
        CmdGraphForm.Name = "CmdGraphForm"
        CmdGraphForm.Size = New Size(58, 74)
        CmdGraphForm.TabIndex = 2
        CmdGraphForm.Text = "Graph"
        CmdGraphForm.UseVisualStyleBackColor = True
        ' 
        ' CmdLocalPitchForm
        ' 
        CmdLocalPitchForm.Dock = DockStyle.Fill
        CmdLocalPitchForm.Location = New Point(67, 3)
        CmdLocalPitchForm.Name = "CmdLocalPitchForm"
        CmdLocalPitchForm.Size = New Size(58, 74)
        CmdLocalPitchForm.TabIndex = 1
        CmdLocalPitchForm.Text = "Local Pitch"
        CmdLocalPitchForm.UseVisualStyleBackColor = True
        ' 
        ' CmdMeasureForm
        ' 
        CmdMeasureForm.Dock = DockStyle.Fill
        CmdMeasureForm.Location = New Point(3, 3)
        CmdMeasureForm.Name = "CmdMeasureForm"
        CmdMeasureForm.Size = New Size(58, 74)
        CmdMeasureForm.TabIndex = 0
        CmdMeasureForm.Text = "Measure"
        CmdMeasureForm.UseVisualStyleBackColor = True
        ' 
        ' LabCompareTo
        ' 
        LabCompareTo.AutoSize = True
        LabCompareTo.Dock = DockStyle.Bottom
        LabCompareTo.Location = New Point(3, 115)
        LabCompareTo.Name = "LabCompareTo"
        LabCompareTo.Size = New Size(124, 20)
        LabCompareTo.TabIndex = 0
        LabCompareTo.Text = "Compare to"
        ' 
        ' ComboCompareto
        ' 
        ComboCompareto.Dock = DockStyle.Top
        ComboCompareto.FormattingEnabled = True
        ComboCompareto.Location = New Point(3, 139)
        ComboCompareto.Margin = New Padding(3, 4, 3, 4)
        ComboCompareto.Name = "ComboCompareto"
        ComboCompareto.Size = New Size(124, 28)
        ComboCompareto.TabIndex = 1
        ' 
        ' LabRadius
        ' 
        LabRadius.AutoSize = True
        LabRadius.Dock = DockStyle.Bottom
        LabRadius.Location = New Point(3, 172)
        LabRadius.Name = "LabRadius"
        LabRadius.Size = New Size(124, 20)
        LabRadius.TabIndex = 5
        LabRadius.Text = "Radius"
        ' 
        ' ChkShowReference
        ' 
        ChkShowReference.AutoSize = True
        ChkShowReference.Dock = DockStyle.Fill
        ChkShowReference.Location = New Point(10, 491)
        ChkShowReference.Margin = New Padding(10, 3, 3, 3)
        ChkShowReference.Name = "ChkShowReference"
        ChkShowReference.Size = New Size(117, 24)
        ChkShowReference.TabIndex = 13
        ChkShowReference.Text = "Show Ref"
        ChkShowReference.UseVisualStyleBackColor = True
        ' 
        ' ChkShowTable
        ' 
        ChkShowTable.AutoSize = True
        ChkShowTable.Dock = DockStyle.Fill
        ChkShowTable.Location = New Point(10, 431)
        ChkShowTable.Margin = New Padding(10, 3, 3, 3)
        ChkShowTable.Name = "ChkShowTable"
        ChkShowTable.Size = New Size(117, 24)
        ChkShowTable.TabIndex = 11
        ChkShowTable.Text = "Show Table"
        ChkShowTable.UseVisualStyleBackColor = True
        ' 
        ' ComboRadius
        ' 
        ComboRadius.Dock = DockStyle.Fill
        ComboRadius.FormattingEnabled = True
        ComboRadius.Location = New Point(3, 196)
        ComboRadius.Margin = New Padding(3, 4, 3, 4)
        ComboRadius.Name = "ComboRadius"
        ComboRadius.Size = New Size(124, 28)
        ComboRadius.TabIndex = 2
        ' 
        ' LabTolerance
        ' 
        LabTolerance.AutoSize = True
        LabTolerance.Dock = DockStyle.Bottom
        LabTolerance.Location = New Point(3, 229)
        LabTolerance.Name = "LabTolerance"
        LabTolerance.Size = New Size(124, 20)
        LabTolerance.TabIndex = 6
        LabTolerance.Text = "Tolerance Class"
        ' 
        ' ComboToleranceClass
        ' 
        ComboToleranceClass.Dock = DockStyle.Fill
        ComboToleranceClass.FormattingEnabled = True
        ComboToleranceClass.Location = New Point(3, 253)
        ComboToleranceClass.Margin = New Padding(3, 4, 3, 4)
        ComboToleranceClass.Name = "ComboToleranceClass"
        ComboToleranceClass.Size = New Size(124, 28)
        ComboToleranceClass.TabIndex = 3
        ' 
        ' LabBlade
        ' 
        LabBlade.AutoSize = True
        LabBlade.Dock = DockStyle.Bottom
        LabBlade.Location = New Point(3, 286)
        LabBlade.Name = "LabBlade"
        LabBlade.Size = New Size(124, 20)
        LabBlade.TabIndex = 7
        LabBlade.Text = "Blade"
        ' 
        ' ComboBlade
        ' 
        ComboBlade.Dock = DockStyle.Fill
        ComboBlade.FormattingEnabled = True
        ComboBlade.Location = New Point(3, 310)
        ComboBlade.Margin = New Padding(3, 4, 3, 4)
        ComboBlade.Name = "ComboBlade"
        ComboBlade.Size = New Size(124, 28)
        ComboBlade.TabIndex = 4
        ' 
        ' LabGraphStyle
        ' 
        LabGraphStyle.AutoSize = True
        LabGraphStyle.Dock = DockStyle.Bottom
        LabGraphStyle.Location = New Point(3, 343)
        LabGraphStyle.Name = "LabGraphStyle"
        LabGraphStyle.Size = New Size(124, 20)
        LabGraphStyle.TabIndex = 8
        LabGraphStyle.Text = "Graph Style"
        ' 
        ' ComboGraphStyle
        ' 
        ComboGraphStyle.Dock = DockStyle.Fill
        ComboGraphStyle.FormattingEnabled = True
        ComboGraphStyle.Location = New Point(3, 367)
        ComboGraphStyle.Margin = New Padding(3, 4, 3, 4)
        ComboGraphStyle.Name = "ComboGraphStyle"
        ComboGraphStyle.Size = New Size(124, 28)
        ComboGraphStyle.TabIndex = 9
        ' 
        ' ChkCenterReference
        ' 
        ChkCenterReference.AutoSize = True
        ChkCenterReference.Dock = DockStyle.Fill
        ChkCenterReference.Location = New Point(10, 401)
        ChkCenterReference.Margin = New Padding(10, 3, 3, 3)
        ChkCenterReference.Name = "ChkCenterReference"
        ChkCenterReference.Size = New Size(117, 24)
        ChkCenterReference.TabIndex = 10
        ChkCenterReference.Text = "Center Ref"
        ChkCenterReference.UseVisualStyleBackColor = True
        ' 
        ' ChkIncludeTrack
        ' 
        ChkIncludeTrack.AutoSize = True
        ChkIncludeTrack.Dock = DockStyle.Fill
        ChkIncludeTrack.Location = New Point(10, 461)
        ChkIncludeTrack.Margin = New Padding(10, 3, 3, 3)
        ChkIncludeTrack.Name = "ChkIncludeTrack"
        ChkIncludeTrack.Size = New Size(117, 24)
        ChkIncludeTrack.TabIndex = 12
        ChkIncludeTrack.Text = "Include Track"
        ChkIncludeTrack.UseVisualStyleBackColor = True
        ' 
        ' CmdPrint
        ' 
        CmdPrint.Location = New Point(3, 521)
        CmdPrint.Name = "CmdPrint"
        CmdPrint.Size = New Size(75, 29)
        CmdPrint.TabIndex = 14
        CmdPrint.Text = "Print"
        CmdPrint.UseVisualStyleBackColor = True
        ' 
        ' pBoxLogo
        ' 
        tLayoutLocalPitch.SetColumnSpan(pBoxLogo, 2)
        pBoxLogo.Dock = DockStyle.Fill
        pBoxLogo.Image = My.Resources.Resources.HaleMRIlogo
        pBoxLogo.Location = New Point(0, 0)
        pBoxLogo.Margin = New Padding(0)
        pBoxLogo.Name = "pBoxLogo"
        tLayoutLocalPitch.SetRowSpan(pBoxLogo, 2)
        pBoxLogo.Size = New Size(212, 113)
        pBoxLogo.SizeMode = PictureBoxSizeMode.Zoom
        pBoxLogo.TabIndex = 15
        pBoxLogo.TabStop = False
        ' 
        ' GridJobDetails
        ' 
        GridJobDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        GridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDate, MeasurementType, ToleranceClass, PerformedBy, Description})
        tLayoutLocalPitch.SetColumnSpan(GridJobDetails, 2)
        GridJobDetails.Dock = DockStyle.Right
        GridJobDetails.Location = New Point(538, 36)
        GridJobDetails.Margin = New Padding(3, 3, 15, 3)
        GridJobDetails.Name = "GridJobDetails"
        GridJobDetails.RowHeadersVisible = False
        GridJobDetails.Size = New Size(631, 74)
        GridJobDetails.TabIndex = 18
        ' 
        ' StartDate
        ' 
        StartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        StartDate.DataPropertyName = "StartDate"
        StartDate.HeaderText = "Start Date"
        StartDate.Name = "StartDate"
        StartDate.Width = 101
        ' 
        ' MeasurementType
        ' 
        MeasurementType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        MeasurementType.DataPropertyName = "MeasurementType"
        MeasurementType.HeaderText = "Stage"
        MeasurementType.Name = "MeasurementType"
        MeasurementType.Resizable = DataGridViewTriState.True
        MeasurementType.SortMode = DataGridViewColumnSortMode.Automatic
        MeasurementType.Width = 72
        ' 
        ' ToleranceClass
        ' 
        ToleranceClass.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        ToleranceClass.DataPropertyName = "ToleranceClass"
        ToleranceClass.HeaderText = "Class"
        ToleranceClass.Name = "ToleranceClass"
        ToleranceClass.Resizable = DataGridViewTriState.True
        ToleranceClass.SortMode = DataGridViewColumnSortMode.Automatic
        ToleranceClass.Width = 67
        ' 
        ' PerformedBy
        ' 
        PerformedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.HeaderText = "Employee"
        PerformedBy.Name = "PerformedBy"
        PerformedBy.Resizable = DataGridViewTriState.True
        PerformedBy.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' Description
        ' 
        Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.Name = "Description"
        ' 
        ' LabJobNumber
        ' 
        LabJobNumber.AutoSize = True
        LabJobNumber.Dock = DockStyle.Left
        LabJobNumber.Font = New Font("Segoe UI", 16F)
        LabJobNumber.Location = New Point(227, 5)
        LabJobNumber.Margin = New Padding(15, 5, 3, 0)
        LabJobNumber.Name = "LabJobNumber"
        LabJobNumber.Size = New Size(157, 28)
        LabJobNumber.TabIndex = 19
        LabJobNumber.Text = "                        "
        ' 
        ' JobDetailsBindingSource
        ' 
        ' 
        ' TLayoutCharts
        ' 
        TLayoutCharts.ColumnCount = 1
        tLayoutLocalPitch.SetColumnSpan(TLayoutCharts, 4)
        TLayoutCharts.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLayoutCharts.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLayoutCharts.Dock = DockStyle.Fill
        TLayoutCharts.Location = New Point(130, 113)
        TLayoutCharts.Margin = New Padding(0)
        TLayoutCharts.Name = "TLayoutCharts"
        TLayoutCharts.RowCount = 1
        tLayoutLocalPitch.SetRowSpan(TLayoutCharts, 16)
        TLayoutCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLayoutCharts.Size = New Size(1054, 523)
        TLayoutCharts.TabIndex = 28
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        tLayoutLocalPitch.SetColumnSpan(RecordNavigationBar1, 2)
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Dock = DockStyle.Top
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(535, 0)
        RecordNavigationBar1.Margin = New Padding(0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(649, 27)
        RecordNavigationBar1.TabIndex = 29
        ' 
        ' FrmLocalPitch
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 636)
        Controls.Add(tLayoutLocalPitch)
        Font = New Font("Segoe UI", 11F)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmLocalPitch"
        Text = "Local Pitch"
        tLayoutLocalPitch.ResumeLayout(False)
        tLayoutLocalPitch.PerformLayout()
        tLayoutNavigationButtons.ResumeLayout(False)
        CType(pBoxLogo, ComponentModel.ISupportInitialize).EndInit()
        CType(GridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BindingSource2, ComponentModel.ISupportInitialize).EndInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tLayoutLocalPitch As TableLayoutPanel
    Friend WithEvents LabCompareTo As Label
    Friend WithEvents ComboCompareto As ComboBox
    Friend WithEvents ComboRadius As ComboBox
    Friend WithEvents ComboToleranceClass As ComboBox
    Friend WithEvents ComboBlade As ComboBox
    Friend WithEvents LabRadius As Label
    Friend WithEvents LabTolerance As Label
    Friend WithEvents LabBlade As Label
    Friend WithEvents LabGraphStyle As Label
    Friend WithEvents ComboGraphStyle As ComboBox
    Friend WithEvents ChkCenterReference As CheckBox
    Friend WithEvents ChkShowTable As CheckBox
    Friend WithEvents ChkIncludeTrack As CheckBox
    Friend WithEvents ChkShowReference As CheckBox
    Friend WithEvents CmdPrint As Button
    Friend WithEvents pBoxLogo As PictureBox
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents GridJobDetails As DataGridView
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents LabJobNumber As Label
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents ClassBindingSource As BindingSource
    Friend WithEvents MeasurementTypesBindingSource As BindingSource
    Friend WithEvents StartDate As DataGridViewTextBoxColumn
    Friend WithEvents MeasurementType As DataGridViewComboBoxColumn
    Friend WithEvents ToleranceClass As DataGridViewComboBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents tLayoutNavigationButtons As TableLayoutPanel
    Friend WithEvents CmdComparisonForm As Button
    Friend WithEvents CmdInspectForm As Button
    Friend WithEvents CmdGraphForm As Button
    Friend WithEvents CmdLocalPitchForm As Button
    Friend WithEvents CmdMeasureForm As Button
    Friend WithEvents TLayoutCharts As TableLayoutPanel
End Class
