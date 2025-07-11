<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobs
    'Inherits System.Windows.Forms.Form
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
        DataGridJobs = New DataGridView()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        VesselId = New DataGridViewComboBoxColumn()
        VesselBindingSource = New BindingSource(components)
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PartDescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ManufacturerId1 = New DataGridViewComboBoxColumn()
        ManufacturersBindingSource = New BindingSource(components)
        PartNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        SerialNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StampNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Material = New DataGridViewComboBoxColumn()
        MaterialsBindingSource = New BindingSource(components)
        Style1 = New DataGridViewComboBoxColumn()
        StylesBindingSource = New BindingSource(components)
        Blades1 = New DataGridViewComboBoxColumn()
        BladesBindingSource = New BindingSource(components)
        InspectedBy1 = New DataGridViewComboBoxColumn()
        EmployeesBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        TableLayoutPanel2 = New TableLayoutPanel()
        labJobsJobDetailsTitle = New Label()
        DataGridJobDetails = New DataGridView()
        StartDateDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        DescriptionDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        JobDetailsBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        CType(DataGridJobs, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridJobs
        ' 
        DataGridJobs.AutoGenerateColumns = False
        DataGridJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobs.Columns.AddRange(New DataGridViewColumn() {JobNumberDataGridViewTextBoxColumn, VesselId, DescriptionDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, PartDescriptionDataGridViewTextBoxColumn, ManufacturerId1, PartNumberDataGridViewTextBoxColumn, SerialNumberDataGridViewTextBoxColumn, StampNumberDataGridViewTextBoxColumn, Material, Style1, Blades1, InspectedBy1})
        DataGridJobs.DataSource = JobBindingSource
        DataGridJobs.Location = New Point(2, 43)
        DataGridJobs.Margin = New Padding(2, 1, 2, 1)
        DataGridJobs.Name = "DataGridJobs"
        DataGridJobs.RowHeadersWidth = 82
        DataGridJobs.Size = New Size(1827, 461)
        DataGridJobs.TabIndex = 0
        ' 
        ' JobNumberDataGridViewTextBoxColumn
        ' 
        JobNumberDataGridViewTextBoxColumn.DataPropertyName = "JobNumber"
        JobNumberDataGridViewTextBoxColumn.HeaderText = "Job Number"
        JobNumberDataGridViewTextBoxColumn.MinimumWidth = 96
        JobNumberDataGridViewTextBoxColumn.Name = "JobNumberDataGridViewTextBoxColumn"
        JobNumberDataGridViewTextBoxColumn.Width = 96
        ' 
        ' VesselId
        ' 
        VesselId.DataPropertyName = "VesselId"
        VesselId.DataSource = VesselBindingSource
        VesselId.DisplayMember = "VesselName"
        VesselId.HeaderText = "Vessel"
        VesselId.MinimumWidth = 160
        VesselId.Name = "VesselId"
        VesselId.ValueMember = "Id"
        VesselId.Width = 160
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Job Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 330
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.Width = 330
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 150
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.Width = 150
        ' 
        ' PartDescriptionDataGridViewTextBoxColumn
        ' 
        PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Part Description"
        PartDescriptionDataGridViewTextBoxColumn.MinimumWidth = 190
        PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        PartDescriptionDataGridViewTextBoxColumn.Width = 190
        ' 
        ' ManufacturerId1
        ' 
        ManufacturerId1.DataPropertyName = "ManufacturerId"
        ManufacturerId1.DataSource = ManufacturersBindingSource
        ManufacturerId1.DisplayMember = "ManufacturerName"
        ManufacturerId1.HeaderText = "Manufacturer"
        ManufacturerId1.Name = "ManufacturerId1"
        ManufacturerId1.ValueMember = "Id"
        ' 
        ' ManufacturersBindingSource
        ' 
        ManufacturersBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ' 
        ' PartNumberDataGridViewTextBoxColumn
        ' 
        PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        PartNumberDataGridViewTextBoxColumn.MinimumWidth = 10
        PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        ' 
        ' SerialNumberDataGridViewTextBoxColumn
        ' 
        SerialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber"
        SerialNumberDataGridViewTextBoxColumn.HeaderText = "Serial Number"
        SerialNumberDataGridViewTextBoxColumn.MinimumWidth = 120
        SerialNumberDataGridViewTextBoxColumn.Name = "SerialNumberDataGridViewTextBoxColumn"
        SerialNumberDataGridViewTextBoxColumn.Width = 120
        ' 
        ' StampNumberDataGridViewTextBoxColumn
        ' 
        StampNumberDataGridViewTextBoxColumn.DataPropertyName = "StampNumber"
        StampNumberDataGridViewTextBoxColumn.HeaderText = "Stamp Number"
        StampNumberDataGridViewTextBoxColumn.MinimumWidth = 120
        StampNumberDataGridViewTextBoxColumn.Name = "StampNumberDataGridViewTextBoxColumn"
        StampNumberDataGridViewTextBoxColumn.Width = 120
        ' 
        ' Material
        ' 
        Material.DataPropertyName = "Material"
        Material.DataSource = MaterialsBindingSource
        Material.DisplayMember = "Material1"
        Material.HeaderText = "Material"
        Material.Name = "Material"
        Material.ValueMember = "Material1"
        ' 
        ' MaterialsBindingSource
        ' 
        MaterialsBindingSource.DataSource = GetType(LibDatabase.Models.Material)
        ' 
        ' Style1
        ' 
        Style1.DataPropertyName = "Style"
        Style1.DataSource = StylesBindingSource
        Style1.DisplayMember = "Style1"
        Style1.HeaderText = "Style"
        Style1.Name = "Style1"
        Style1.ValueMember = "Style1"
        ' 
        ' StylesBindingSource
        ' 
        StylesBindingSource.DataSource = GetType(LibDatabase.Models.Style)
        ' 
        ' Blades1
        ' 
        Blades1.DataPropertyName = "Blades"
        Blades1.DataSource = BladesBindingSource
        Blades1.DisplayMember = "BladeCount"
        Blades1.HeaderText = "Blades"
        Blades1.MinimumWidth = 60
        Blades1.Name = "Blades1"
        Blades1.ValueMember = "BladeCount"
        Blades1.Width = 60
        ' 
        ' BladesBindingSource
        ' 
        BladesBindingSource.DataSource = GetType(LibDatabase.Models.Blade)
        ' 
        ' InspectedBy1
        ' 
        InspectedBy1.DataPropertyName = "InspectedBy"
        InspectedBy1.DataSource = EmployeesBindingSource
        InspectedBy1.DisplayMember = "EmployeeName"
        InspectedBy1.HeaderText = "Inspected By"
        InspectedBy1.Name = "InspectedBy1"
        InspectedBy1.ValueMember = "Id"
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(labJobsJobDetailsTitle, 0, 0)
        TableLayoutPanel2.Controls.Add(DataGridJobDetails, 0, 1)
        TableLayoutPanel2.Location = New Point(11, 535)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1700, 286)
        TableLayoutPanel2.TabIndex = 9
        ' 
        ' labJobsJobDetailsTitle
        ' 
        labJobsJobDetailsTitle.AutoSize = True
        labJobsJobDetailsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labJobsJobDetailsTitle.Location = New Point(0, 0)
        labJobsJobDetailsTitle.Margin = New Padding(0, 0, 2, 1)
        labJobsJobDetailsTitle.Name = "labJobsJobDetailsTitle"
        labJobsJobDetailsTitle.Size = New Size(86, 20)
        labJobsJobDetailsTitle.TabIndex = 0
        labJobsJobDetailsTitle.Text = "Job Details"
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridJobDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDateDataGridViewTextBoxColumn1, PerformedBy, DescriptionDataGridViewTextBoxColumn1})
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Location = New Point(0, 21)
        DataGridJobDetails.Margin = New Padding(0)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ReadOnly = True
        DataGridJobDetails.RowHeadersWidth = 82
        DataGridJobDetails.Size = New Size(903, 265)
        DataGridJobDetails.TabIndex = 3
        ' 
        ' StartDateDataGridViewTextBoxColumn1
        ' 
        StartDateDataGridViewTextBoxColumn1.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn1.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn1.MinimumWidth = 10
        StartDateDataGridViewTextBoxColumn1.Name = "StartDateDataGridViewTextBoxColumn1"
        StartDateDataGridViewTextBoxColumn1.ReadOnly = True
        StartDateDataGridViewTextBoxColumn1.Width = 200
        ' 
        ' PerformedBy
        ' 
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeesBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        PerformedBy.HeaderText = "Performed By"
        PerformedBy.MinimumWidth = 10
        PerformedBy.Name = "PerformedBy"
        PerformedBy.ReadOnly = True
        PerformedBy.ValueMember = "Id"
        PerformedBy.Width = 120
        ' 
        ' DescriptionDataGridViewTextBoxColumn1
        ' 
        DescriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn1.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn1.MinimumWidth = 500
        DescriptionDataGridViewTextBoxColumn1.Name = "DescriptionDataGridViewTextBoxColumn1"
        DescriptionDataGridViewTextBoxColumn1.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn1.Width = 500
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridJobs, 0, 1)
        TableLayoutPanel1.Location = New Point(12, 12)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(1831, 504)
        TableLayoutPanel1.TabIndex = 10
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
        ' FrmJobs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1857, 830)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(TableLayoutPanel2)
        Margin = New Padding(1, 0, 1, 0)
        Name = "FrmJobs"
        Text = "Jobs"
        CType(DataGridJobs, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridJobs As DataGridView
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents labJobsJobDetailsTitle As Label
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents BladesBindingSource As BindingSource
    Friend WithEvents MaterialsBindingSource As BindingSource
    Friend WithEvents StylesBindingSource As BindingSource
    Friend WithEvents StartDateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents JobNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VesselId As DataGridViewComboBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ManufacturerId1 As DataGridViewComboBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StampNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewComboBoxColumn
    Friend WithEvents Style1 As DataGridViewComboBoxColumn
    Friend WithEvents Blades1 As DataGridViewComboBoxColumn
    Friend WithEvents InspectedBy1 As DataGridViewComboBoxColumn
End Class
