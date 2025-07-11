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
        DataGridVessels = New DataGridView()
        CustomerBindingSource = New BindingSource(components)
        CountryCodeBindingSource = New BindingSource(components)
        VesselServiceTypeBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        TableLayoutPanel2 = New TableLayoutPanel()
        labVesselJobsTitle = New Label()
        DataGridVesselJobs = New DataGridView()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobsBindingSource = New BindingSource(components)
        ManufacturerBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CustomerId = New DataGridViewComboBoxColumn()
        PrimaryVesselNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HullIdNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CallSignDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BuildYearDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Flag = New DataGridViewComboBoxColumn()
        ServiceTypeId = New DataGridViewComboBoxColumn()
        CType(DataGridVessels, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridVessels
        ' 
        DataGridVessels.AutoGenerateColumns = False
        DataGridVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridVessels.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn, CustomerId, PrimaryVesselNumberDataGridViewTextBoxColumn, HullIdNumberDataGridViewTextBoxColumn, CallSignDataGridViewTextBoxColumn, BuildYearDataGridViewTextBoxColumn, Flag, ServiceTypeId})
        DataGridVessels.DataSource = VesselBindingSource
        DataGridVessels.Location = New Point(2, 43)
        DataGridVessels.Margin = New Padding(2, 1, 2, 1)
        DataGridVessels.Name = "DataGridVessels"
        DataGridVessels.RowHeadersWidth = 82
        DataGridVessels.Size = New Size(1480, 498)
        DataGridVessels.TabIndex = 0
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
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Controls.Add(labVesselJobsTitle, 0, 0)
        TableLayoutPanel2.Controls.Add(DataGridVesselJobs, 0, 1)
        TableLayoutPanel2.Location = New Point(16, 576)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Size = New Size(927, 223)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 2, 1)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(41, 20)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' DataGridVesselJobs
        ' 
        DataGridVesselJobs.AllowUserToAddRows = False
        DataGridVesselJobs.AllowUserToDeleteRows = False
        DataGridVesselJobs.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridVesselJobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
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
        ' JobsBindingSource
        ' 
        JobsBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' ManufacturerBindingSource
        ' 
        ManufacturerBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridVessels, 0, 1)
        TableLayoutPanel1.Location = New Point(16, 12)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Size = New Size(1484, 542)
        TableLayoutPanel1.TabIndex = 6
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
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "Vessel Name"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 240
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.Width = 240
        ' 
        ' CustomerId
        ' 
        CustomerId.DataPropertyName = "CustomerId"
        CustomerId.DataSource = CustomerBindingSource
        CustomerId.DisplayMember = "CustomerName"
        CustomerId.HeaderText = "Customer"
        CustomerId.MinimumWidth = 100
        CustomerId.Name = "CustomerId"
        CustomerId.ValueMember = "Id"
        CustomerId.Width = 200
        ' 
        ' PrimaryVesselNumberDataGridViewTextBoxColumn
        ' 
        PrimaryVesselNumberDataGridViewTextBoxColumn.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumberDataGridViewTextBoxColumn.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumberDataGridViewTextBoxColumn.MinimumWidth = 180
        PrimaryVesselNumberDataGridViewTextBoxColumn.Name = "PrimaryVesselNumberDataGridViewTextBoxColumn"
        PrimaryVesselNumberDataGridViewTextBoxColumn.Width = 180
        ' 
        ' HullIdNumberDataGridViewTextBoxColumn
        ' 
        HullIdNumberDataGridViewTextBoxColumn.DataPropertyName = "HullIdNumber"
        HullIdNumberDataGridViewTextBoxColumn.HeaderText = "Hull Id Number"
        HullIdNumberDataGridViewTextBoxColumn.MinimumWidth = 180
        HullIdNumberDataGridViewTextBoxColumn.Name = "HullIdNumberDataGridViewTextBoxColumn"
        HullIdNumberDataGridViewTextBoxColumn.Width = 180
        ' 
        ' CallSignDataGridViewTextBoxColumn
        ' 
        CallSignDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CallSignDataGridViewTextBoxColumn.DataPropertyName = "CallSign"
        CallSignDataGridViewTextBoxColumn.HeaderText = "Call Sign"
        CallSignDataGridViewTextBoxColumn.MinimumWidth = 180
        CallSignDataGridViewTextBoxColumn.Name = "CallSignDataGridViewTextBoxColumn"
        CallSignDataGridViewTextBoxColumn.Width = 180
        ' 
        ' BuildYearDataGridViewTextBoxColumn
        ' 
        BuildYearDataGridViewTextBoxColumn.DataPropertyName = "BuildYear"
        BuildYearDataGridViewTextBoxColumn.HeaderText = "Build Year"
        BuildYearDataGridViewTextBoxColumn.MinimumWidth = 100
        BuildYearDataGridViewTextBoxColumn.Name = "BuildYearDataGridViewTextBoxColumn"
        ' 
        ' Flag
        ' 
        Flag.DataPropertyName = "Flag"
        Flag.DataSource = CountryCodeBindingSource
        Flag.DisplayMember = "Country"
        Flag.HeaderText = "Flag"
        Flag.MinimumWidth = 100
        Flag.Name = "Flag"
        Flag.ValueMember = "Alpha2Code"
        ' 
        ' ServiceTypeId
        ' 
        ServiceTypeId.DataPropertyName = "ServiceTypeId"
        ServiceTypeId.DataSource = VesselServiceTypeBindingSource
        ServiceTypeId.DisplayMember = "ServiceType"
        ServiceTypeId.HeaderText = "Service Type"
        ServiceTypeId.MinimumWidth = 180
        ServiceTypeId.Name = "ServiceTypeId"
        ServiceTypeId.ValueMember = "Id"
        ServiceTypeId.Width = 180
        ' 
        ' FrmVessels
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1512, 808)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(TableLayoutPanel2)
        Margin = New Padding(1, 0, 1, 0)
        Name = "FrmVessels"
        Text = "Vessels"
        CType(DataGridVessels, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).EndInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridVessels As DataGridView
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents VesselServiceTypeBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridVesselJobs As DataGridView
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents ManufacturerBindingSource As BindingSource
    Friend WithEvents JobNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerId As DataGridViewComboBoxColumn
    Friend WithEvents PrimaryVesselNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HullIdNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CallSignDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BuildYearDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Flag As DataGridViewComboBoxColumn
    Friend WithEvents ServiceTypeId As DataGridViewComboBoxColumn
End Class
