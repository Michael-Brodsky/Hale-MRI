<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVessels
    'Inherits System.Windows.Forms.Form
    Inherits FrmDatabaseForm
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        CustomerBindingSource = New BindingSource(components)
        CountryCodeBindingSource = New BindingSource(components)
        VesselServiceTypeBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        JobsBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        DataGridVessels = New DataGridView()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CustomerDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        PrimaryVesselNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HullIdNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CallSignDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        FlagDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        BuildYearDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ServiceTypeDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        DataGridVesselJobs = New DataGridView()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        labVesselJobsTitle = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        CType(DataGridVessels, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' CountryCodeBindingSource
        ' 
        CountryCodeBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' VesselServiceTypeBindingSource
        ' 
        VesselServiceTypeBindingSource.DataSource = GetType(LibDatabase.Models.VesselServiceType)
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' JobsBindingSource
        ' 
        JobsBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridVessels, 0, 1)
        TableLayoutPanel1.Location = New Point(16, 12)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(1289, 542)
        TableLayoutPanel1.TabIndex = 6
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(0, 0)
        RecordNavigationBar1.Margin = New Padding(0, 0, 0, 12)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(635, 24)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' DataGridVessels
        ' 
        DataGridVessels.AutoGenerateColumns = False
        DataGridVessels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        DataGridVessels.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridVessels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridVessels.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn, CustomerDataGridViewTextBoxColumn, PrimaryVesselNumberDataGridViewTextBoxColumn, HullIdNumberDataGridViewTextBoxColumn, CallSignDataGridViewTextBoxColumn, FlagDataGridViewTextBoxColumn, BuildYearDataGridViewTextBoxColumn, ServiceTypeDataGridViewTextBoxColumn})
        DataGridVessels.DataSource = VesselBindingSource
        DataGridVessels.Location = New Point(3, 39)
        DataGridVessels.Name = "DataGridVessels"
        DataGridVessels.Size = New Size(1283, 494)
        DataGridVessels.TabIndex = 1
        ' 
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "Vessel Name"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 180
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.Width = 180
        ' 
        ' CustomerDataGridViewTextBoxColumn
        ' 
        CustomerDataGridViewTextBoxColumn.DataPropertyName = "CustomerId"
        CustomerDataGridViewTextBoxColumn.DataSource = CustomerBindingSource
        CustomerDataGridViewTextBoxColumn.DisplayMember = "CustomerName"
        CustomerDataGridViewTextBoxColumn.HeaderText = "Customer"
        CustomerDataGridViewTextBoxColumn.MinimumWidth = 180
        CustomerDataGridViewTextBoxColumn.Name = "CustomerDataGridViewTextBoxColumn"
        CustomerDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        CustomerDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        CustomerDataGridViewTextBoxColumn.ValueMember = "Id"
        CustomerDataGridViewTextBoxColumn.Width = 180
        ' 
        ' PrimaryVesselNumberDataGridViewTextBoxColumn
        ' 
        PrimaryVesselNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        PrimaryVesselNumberDataGridViewTextBoxColumn.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumberDataGridViewTextBoxColumn.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumberDataGridViewTextBoxColumn.MinimumWidth = 170
        PrimaryVesselNumberDataGridViewTextBoxColumn.Name = "PrimaryVesselNumberDataGridViewTextBoxColumn"
        PrimaryVesselNumberDataGridViewTextBoxColumn.Width = 170
        ' 
        ' HullIdNumberDataGridViewTextBoxColumn
        ' 
        HullIdNumberDataGridViewTextBoxColumn.DataPropertyName = "HullIdNumber"
        HullIdNumberDataGridViewTextBoxColumn.HeaderText = "Hull Id Number"
        HullIdNumberDataGridViewTextBoxColumn.MinimumWidth = 150
        HullIdNumberDataGridViewTextBoxColumn.Name = "HullIdNumberDataGridViewTextBoxColumn"
        HullIdNumberDataGridViewTextBoxColumn.Width = 150
        ' 
        ' CallSignDataGridViewTextBoxColumn
        ' 
        CallSignDataGridViewTextBoxColumn.DataPropertyName = "CallSign"
        CallSignDataGridViewTextBoxColumn.HeaderText = "Call Sign"
        CallSignDataGridViewTextBoxColumn.MinimumWidth = 150
        CallSignDataGridViewTextBoxColumn.Name = "CallSignDataGridViewTextBoxColumn"
        CallSignDataGridViewTextBoxColumn.Width = 150
        ' 
        ' FlagDataGridViewTextBoxColumn
        ' 
        FlagDataGridViewTextBoxColumn.DataPropertyName = "Flag"
        FlagDataGridViewTextBoxColumn.DataSource = CountryCodeBindingSource
        FlagDataGridViewTextBoxColumn.DisplayMember = "Country"
        FlagDataGridViewTextBoxColumn.HeaderText = "Flag"
        FlagDataGridViewTextBoxColumn.MinimumWidth = 160
        FlagDataGridViewTextBoxColumn.Name = "FlagDataGridViewTextBoxColumn"
        FlagDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        FlagDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        FlagDataGridViewTextBoxColumn.ValueMember = "Alpha2Code"
        FlagDataGridViewTextBoxColumn.Width = 160
        ' 
        ' BuildYearDataGridViewTextBoxColumn
        ' 
        BuildYearDataGridViewTextBoxColumn.DataPropertyName = "BuildYear"
        BuildYearDataGridViewTextBoxColumn.HeaderText = "Build Year"
        BuildYearDataGridViewTextBoxColumn.MinimumWidth = 90
        BuildYearDataGridViewTextBoxColumn.Name = "BuildYearDataGridViewTextBoxColumn"
        BuildYearDataGridViewTextBoxColumn.Width = 90
        ' 
        ' ServiceTypeDataGridViewTextBoxColumn
        ' 
        ServiceTypeDataGridViewTextBoxColumn.DataPropertyName = "ServiceTypeId"
        ServiceTypeDataGridViewTextBoxColumn.DataSource = VesselServiceTypeBindingSource
        ServiceTypeDataGridViewTextBoxColumn.DisplayMember = "ServiceType"
        ServiceTypeDataGridViewTextBoxColumn.HeaderText = "Service Type"
        ServiceTypeDataGridViewTextBoxColumn.MinimumWidth = 160
        ServiceTypeDataGridViewTextBoxColumn.Name = "ServiceTypeDataGridViewTextBoxColumn"
        ServiceTypeDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        ServiceTypeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        ServiceTypeDataGridViewTextBoxColumn.ValueMember = "Id"
        ServiceTypeDataGridViewTextBoxColumn.Width = 160
        ' 
        ' DataGridVesselJobs
        ' 
        DataGridVesselJobs.AllowUserToAddRows = False
        DataGridVesselJobs.AllowUserToDeleteRows = False
        DataGridVesselJobs.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridVesselJobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridVesselJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridVesselJobs.Columns.AddRange(New DataGridViewColumn() {JobNumberDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn})
        DataGridVesselJobs.DataSource = JobsBindingSource
        DataGridVesselJobs.Location = New Point(0, 21)
        DataGridVesselJobs.Margin = New Padding(0)
        DataGridVesselJobs.Name = "DataGridVesselJobs"
        DataGridVesselJobs.ReadOnly = True
        DataGridVesselJobs.RowHeadersWidth = 82
        DataGridVesselJobs.Size = New Size(926, 202)
        DataGridVesselJobs.TabIndex = 3
        ' 
        ' JobNumberDataGridViewTextBoxColumn
        ' 
        JobNumberDataGridViewTextBoxColumn.DataPropertyName = "JobNumber"
        JobNumberDataGridViewTextBoxColumn.HeaderText = "Job Number"
        JobNumberDataGridViewTextBoxColumn.MinimumWidth = 100
        JobNumberDataGridViewTextBoxColumn.Name = "JobNumberDataGridViewTextBoxColumn"
        JobNumberDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 200
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.ReadOnly = True
        StartDateDataGridViewTextBoxColumn.Width = 200
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 542
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn.Width = 542
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 2, 1)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(41, 20)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(labVesselJobsTitle, 0, 0)
        TableLayoutPanel2.Controls.Add(DataGridVesselJobs, 0, 1)
        TableLayoutPanel2.Location = New Point(16, 576)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(927, 223)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' FrmVessels
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1392, 808)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(TableLayoutPanel2)
        Margin = New Padding(1, 0, 1, 0)
        Name = "FrmVessels"
        Text = "Vessels"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(DataGridVessels, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents VesselServiceTypeBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents DataGridVesselJobs As DataGridView
    Friend WithEvents JobNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridVessels As DataGridView
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents PrimaryVesselNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HullIdNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CallSignDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FlagDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents BuildYearDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ServiceTypeDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
End Class
