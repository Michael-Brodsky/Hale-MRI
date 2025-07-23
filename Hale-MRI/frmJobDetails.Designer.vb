<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobDetails
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
        TableLayoutPanel1 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        DataGridJobDetails = New DataGridView()
        FileNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PerformedByDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ToleranceClass = New DataGridViewComboBoxColumn()
        ToleranceBindingSource = New BindingSource(components)
        Rotation = New DataGridViewComboBoxColumn()
        RotationBindingSource = New BindingSource(components)
        DiameterDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BoreDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        MarkedPitchDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DesiredPitchDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WheelPitchDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LeExclusion = New DataGridViewComboBoxColumn()
        ExclusionBindingSource = New BindingSource(components)
        TeExclusion = New DataGridViewComboBoxColumn()
        CupDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DarDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CellMeasurementsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CupNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ExtremeMeasurementsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LeExclusionNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PerformedByNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RadiusMeasurementsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RotationNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TeExclusionNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ToleranceClassNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobDetailBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        TableLayoutPanel1.SuspendLayout()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(ToleranceBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(RotationBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExclusionBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridJobDetails, 0, 1)
        TableLayoutPanel1.Location = New Point(12, 12)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(1484, 542)
        TableLayoutPanel1.TabIndex = 7
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = ""
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(0, 0)
        RecordNavigationBar1.Margin = New Padding(0, 0, 0, 12)
        RecordNavigationBar1.MasterControl = Nothing
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {FileNameDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, PerformedByDataGridViewTextBoxColumn, ToleranceClass, Rotation, DiameterDataGridViewTextBoxColumn, BoreDataGridViewTextBoxColumn, MarkedPitchDataGridViewTextBoxColumn, DesiredPitchDataGridViewTextBoxColumn, WheelPitchDataGridViewTextBoxColumn, LeExclusion, TeExclusion, CupDataGridViewTextBoxColumn, DarDataGridViewTextBoxColumn, CellMeasurementsDataGridViewTextBoxColumn, CupNavigationDataGridViewTextBoxColumn, ExtremeMeasurementsDataGridViewTextBoxColumn, JobDataGridViewTextBoxColumn, LeExclusionNavigationDataGridViewTextBoxColumn, PerformedByNavigationDataGridViewTextBoxColumn, RadiusMeasurementsDataGridViewTextBoxColumn, RotationNavigationDataGridViewTextBoxColumn, TeExclusionNavigationDataGridViewTextBoxColumn, ToleranceClassNavigationDataGridViewTextBoxColumn})
        DataGridJobDetails.DataSource = JobDetailBindingSource
        DataGridJobDetails.Location = New Point(3, 45)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.Size = New Size(1478, 494)
        DataGridJobDetails.TabIndex = 1
        ' 
        ' FileNameDataGridViewTextBoxColumn
        ' 
        FileNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        FileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName"
        FileNameDataGridViewTextBoxColumn.HeaderText = "FileName"
        FileNameDataGridViewTextBoxColumn.MinimumWidth = 140
        FileNameDataGridViewTextBoxColumn.Name = "FileNameDataGridViewTextBoxColumn"
        FileNameDataGridViewTextBoxColumn.Width = 140
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        ' 
        ' PerformedByDataGridViewTextBoxColumn
        ' 
        PerformedByDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        PerformedByDataGridViewTextBoxColumn.DataPropertyName = "PerformedBy"
        PerformedByDataGridViewTextBoxColumn.HeaderText = "Performed By"
        PerformedByDataGridViewTextBoxColumn.MinimumWidth = 120
        PerformedByDataGridViewTextBoxColumn.Name = "PerformedByDataGridViewTextBoxColumn"
        PerformedByDataGridViewTextBoxColumn.Width = 120
        ' 
        ' ToleranceClass
        ' 
        ToleranceClass.DataPropertyName = "ToleranceClass"
        ToleranceClass.DataSource = ToleranceBindingSource
        ToleranceClass.DisplayMember = "ToleranceClass"
        ToleranceClass.HeaderText = "Tolerance"
        ToleranceClass.Name = "ToleranceClass"
        ToleranceClass.ValueMember = "ToleranceClass"
        ' 
        ' ToleranceBindingSource
        ' 
        ToleranceBindingSource.DataSource = GetType(LibDatabase.Models.Tolerance)
        ' 
        ' Rotation
        ' 
        Rotation.DataPropertyName = "Rotation"
        Rotation.DataSource = RotationBindingSource
        Rotation.DisplayMember = "Rotation1"
        Rotation.HeaderText = "Rotation"
        Rotation.Name = "Rotation"
        Rotation.ValueMember = "Rotation1"
        ' 
        ' RotationBindingSource
        ' 
        RotationBindingSource.DataSource = GetType(LibDatabase.Models.Rotation)
        ' 
        ' DiameterDataGridViewTextBoxColumn
        ' 
        DiameterDataGridViewTextBoxColumn.DataPropertyName = "Diameter"
        DiameterDataGridViewTextBoxColumn.HeaderText = "Diameter"
        DiameterDataGridViewTextBoxColumn.Name = "DiameterDataGridViewTextBoxColumn"
        ' 
        ' BoreDataGridViewTextBoxColumn
        ' 
        BoreDataGridViewTextBoxColumn.DataPropertyName = "Bore"
        BoreDataGridViewTextBoxColumn.HeaderText = "Bore"
        BoreDataGridViewTextBoxColumn.Name = "BoreDataGridViewTextBoxColumn"
        ' 
        ' MarkedPitchDataGridViewTextBoxColumn
        ' 
        MarkedPitchDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        MarkedPitchDataGridViewTextBoxColumn.DataPropertyName = "MarkedPitch"
        MarkedPitchDataGridViewTextBoxColumn.HeaderText = "Marked Pitch"
        MarkedPitchDataGridViewTextBoxColumn.MinimumWidth = 100
        MarkedPitchDataGridViewTextBoxColumn.Name = "MarkedPitchDataGridViewTextBoxColumn"
        ' 
        ' DesiredPitchDataGridViewTextBoxColumn
        ' 
        DesiredPitchDataGridViewTextBoxColumn.DataPropertyName = "DesiredPitch"
        DesiredPitchDataGridViewTextBoxColumn.HeaderText = "Desired Pitch"
        DesiredPitchDataGridViewTextBoxColumn.Name = "DesiredPitchDataGridViewTextBoxColumn"
        ' 
        ' WheelPitchDataGridViewTextBoxColumn
        ' 
        WheelPitchDataGridViewTextBoxColumn.DataPropertyName = "WheelPitch"
        WheelPitchDataGridViewTextBoxColumn.HeaderText = "Wheel Pitch"
        WheelPitchDataGridViewTextBoxColumn.Name = "WheelPitchDataGridViewTextBoxColumn"
        ' 
        ' LeExclusion
        ' 
        LeExclusion.DataPropertyName = "LeExclusion"
        LeExclusion.DataSource = ExclusionBindingSource
        LeExclusion.DisplayMember = "Exclusion1"
        LeExclusion.HeaderText = "LeExclusion"
        LeExclusion.MinimumWidth = 100
        LeExclusion.Name = "LeExclusion"
        LeExclusion.ValueMember = "Exclusion1"
        ' 
        ' ExclusionBindingSource
        ' 
        ExclusionBindingSource.DataSource = GetType(LibDatabase.Models.Exclusion)
        ' 
        ' TeExclusion
        ' 
        TeExclusion.DataPropertyName = "TeExclusion"
        TeExclusion.DataSource = ExclusionBindingSource
        TeExclusion.DisplayMember = "Exclusion1"
        TeExclusion.HeaderText = "TeExclusion"
        TeExclusion.MinimumWidth = 100
        TeExclusion.Name = "TeExclusion"
        TeExclusion.ValueMember = "Exclusion1"
        ' 
        ' CupDataGridViewTextBoxColumn
        ' 
        CupDataGridViewTextBoxColumn.DataPropertyName = "Cup"
        CupDataGridViewTextBoxColumn.HeaderText = "Cup"
        CupDataGridViewTextBoxColumn.Name = "CupDataGridViewTextBoxColumn"
        ' 
        ' DarDataGridViewTextBoxColumn
        ' 
        DarDataGridViewTextBoxColumn.DataPropertyName = "Dar"
        DarDataGridViewTextBoxColumn.HeaderText = "Dar"
        DarDataGridViewTextBoxColumn.Name = "DarDataGridViewTextBoxColumn"
        ' 
        ' CellMeasurementsDataGridViewTextBoxColumn
        ' 
        CellMeasurementsDataGridViewTextBoxColumn.DataPropertyName = "CellMeasurements"
        CellMeasurementsDataGridViewTextBoxColumn.HeaderText = "CellMeasurements"
        CellMeasurementsDataGridViewTextBoxColumn.Name = "CellMeasurementsDataGridViewTextBoxColumn"
        ' 
        ' CupNavigationDataGridViewTextBoxColumn
        ' 
        CupNavigationDataGridViewTextBoxColumn.DataPropertyName = "CupNavigation"
        CupNavigationDataGridViewTextBoxColumn.HeaderText = "CupNavigation"
        CupNavigationDataGridViewTextBoxColumn.Name = "CupNavigationDataGridViewTextBoxColumn"
        ' 
        ' ExtremeMeasurementsDataGridViewTextBoxColumn
        ' 
        ExtremeMeasurementsDataGridViewTextBoxColumn.DataPropertyName = "ExtremeMeasurements"
        ExtremeMeasurementsDataGridViewTextBoxColumn.HeaderText = "ExtremeMeasurements"
        ExtremeMeasurementsDataGridViewTextBoxColumn.Name = "ExtremeMeasurementsDataGridViewTextBoxColumn"
        ' 
        ' JobDataGridViewTextBoxColumn
        ' 
        JobDataGridViewTextBoxColumn.DataPropertyName = "Job"
        JobDataGridViewTextBoxColumn.HeaderText = "Job"
        JobDataGridViewTextBoxColumn.Name = "JobDataGridViewTextBoxColumn"
        ' 
        ' LeExclusionNavigationDataGridViewTextBoxColumn
        ' 
        LeExclusionNavigationDataGridViewTextBoxColumn.DataPropertyName = "LeExclusionNavigation"
        LeExclusionNavigationDataGridViewTextBoxColumn.HeaderText = "LeExclusionNavigation"
        LeExclusionNavigationDataGridViewTextBoxColumn.Name = "LeExclusionNavigationDataGridViewTextBoxColumn"
        ' 
        ' PerformedByNavigationDataGridViewTextBoxColumn
        ' 
        PerformedByNavigationDataGridViewTextBoxColumn.DataPropertyName = "PerformedByNavigation"
        PerformedByNavigationDataGridViewTextBoxColumn.HeaderText = "PerformedByNavigation"
        PerformedByNavigationDataGridViewTextBoxColumn.Name = "PerformedByNavigationDataGridViewTextBoxColumn"
        ' 
        ' RadiusMeasurementsDataGridViewTextBoxColumn
        ' 
        RadiusMeasurementsDataGridViewTextBoxColumn.DataPropertyName = "RadiusMeasurements"
        RadiusMeasurementsDataGridViewTextBoxColumn.HeaderText = "RadiusMeasurements"
        RadiusMeasurementsDataGridViewTextBoxColumn.Name = "RadiusMeasurementsDataGridViewTextBoxColumn"
        ' 
        ' RotationNavigationDataGridViewTextBoxColumn
        ' 
        RotationNavigationDataGridViewTextBoxColumn.DataPropertyName = "RotationNavigation"
        RotationNavigationDataGridViewTextBoxColumn.HeaderText = "RotationNavigation"
        RotationNavigationDataGridViewTextBoxColumn.Name = "RotationNavigationDataGridViewTextBoxColumn"
        ' 
        ' TeExclusionNavigationDataGridViewTextBoxColumn
        ' 
        TeExclusionNavigationDataGridViewTextBoxColumn.DataPropertyName = "TeExclusionNavigation"
        TeExclusionNavigationDataGridViewTextBoxColumn.HeaderText = "TeExclusionNavigation"
        TeExclusionNavigationDataGridViewTextBoxColumn.Name = "TeExclusionNavigationDataGridViewTextBoxColumn"
        ' 
        ' ToleranceClassNavigationDataGridViewTextBoxColumn
        ' 
        ToleranceClassNavigationDataGridViewTextBoxColumn.DataPropertyName = "ToleranceClassNavigation"
        ToleranceClassNavigationDataGridViewTextBoxColumn.HeaderText = "ToleranceClassNavigation"
        ToleranceClassNavigationDataGridViewTextBoxColumn.Name = "ToleranceClassNavigationDataGridViewTextBoxColumn"
        ' 
        ' JobDetailBindingSource
        ' 
        JobDetailBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' FrmJobDetails
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1509, 700)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmJobDetails"
        Text = "Job Details"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(ToleranceBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(RotationBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ExclusionBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents JobDetailBindingSource As BindingSource
    Friend WithEvents ToleranceBindingSource As BindingSource
    Friend WithEvents RotationBindingSource As BindingSource
    Friend WithEvents ExclusionBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents FileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PerformedByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ToleranceClass As DataGridViewComboBoxColumn
    Friend WithEvents Rotation As DataGridViewComboBoxColumn
    Friend WithEvents DiameterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BoreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MarkedPitchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DesiredPitchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WheelPitchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LeExclusion As DataGridViewComboBoxColumn
    Friend WithEvents TeExclusion As DataGridViewComboBoxColumn
    Friend WithEvents CupDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DarDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CellMeasurementsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CupNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExtremeMeasurementsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LeExclusionNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PerformedByNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RadiusMeasurementsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RotationNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TeExclusionNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ToleranceClassNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
