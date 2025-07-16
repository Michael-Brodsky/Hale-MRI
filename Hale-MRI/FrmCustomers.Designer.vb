<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomers
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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        dataGridCustomers = New DataGridView()
        StateCodeBindingSource = New BindingSource(components)
        CountryCodeBindingSource = New BindingSource(components)
        CustomerBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        PanelCustomerVessels = New TableLayoutPanel()
        datagridCustomerVessels = New DataGridView()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PrimaryVesselNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HullIdNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CallSign = New DataGridViewTextBoxColumn()
        labCustomerVesselsTitle = New Label()
        PanelVesselJobs = New TableLayoutPanel()
        DataGridVesselJobs = New DataGridView()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        labVesselJobsTitle = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        CustomerNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        AddressDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CityDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        State = New DataGridViewComboBoxColumn()
        PostalCodeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CountryCode = New DataGridViewComboBoxColumn()
        TelephoneDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EmailDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WebsiteDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CType(dataGridCustomers, ComponentModel.ISupportInitialize).BeginInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelCustomerVessels.SuspendLayout()
        CType(datagridCustomerVessels, ComponentModel.ISupportInitialize).BeginInit()
        PanelVesselJobs.SuspendLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' dataGridCustomers
        ' 
        dataGridCustomers.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dataGridCustomers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dataGridCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridCustomers.Columns.AddRange(New DataGridViewColumn() {CustomerNameDataGridViewTextBoxColumn, AddressDataGridViewTextBoxColumn, CityDataGridViewTextBoxColumn, State, PostalCodeDataGridViewTextBoxColumn, CountryCode, TelephoneDataGridViewTextBoxColumn, EmailDataGridViewTextBoxColumn, WebsiteDataGridViewTextBoxColumn})
        dataGridCustomers.DataSource = CustomerBindingSource
        dataGridCustomers.Location = New Point(0, 42)
        dataGridCustomers.Margin = New Padding(0)
        dataGridCustomers.Name = "dataGridCustomers"
        dataGridCustomers.RowHeadersWidth = 82
        dataGridCustomers.Size = New Size(1826, 484)
        dataGridCustomers.TabIndex = 0
        ' 
        ' StateCodeBindingSource
        ' 
        StateCodeBindingSource.DataSource = GetType(LibDatabase.Models.StateCode)
        ' 
        ' CountryCodeBindingSource
        ' 
        CountryCodeBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' PanelCustomerVessels
        ' 
        PanelCustomerVessels.ColumnCount = 1
        PanelCustomerVessels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        PanelCustomerVessels.Controls.Add(datagridCustomerVessels, 0, 1)
        PanelCustomerVessels.Controls.Add(labCustomerVesselsTitle, 0, 0)
        PanelCustomerVessels.Location = New Point(15, 558)
        PanelCustomerVessels.Margin = New Padding(0)
        PanelCustomerVessels.Name = "PanelCustomerVessels"
        PanelCustomerVessels.RowCount = 2
        PanelCustomerVessels.RowStyles.Add(New RowStyle())
        PanelCustomerVessels.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        PanelCustomerVessels.Size = New Size(884, 250)
        PanelCustomerVessels.TabIndex = 3
        ' 
        ' datagridCustomerVessels
        ' 
        datagridCustomerVessels.AllowUserToAddRows = False
        datagridCustomerVessels.AllowUserToDeleteRows = False
        datagridCustomerVessels.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        datagridCustomerVessels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        datagridCustomerVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        datagridCustomerVessels.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn, PrimaryVesselNumberDataGridViewTextBoxColumn, HullIdNumberDataGridViewTextBoxColumn, CallSign})
        datagridCustomerVessels.DataSource = VesselBindingSource
        datagridCustomerVessels.Dock = DockStyle.Fill
        datagridCustomerVessels.Location = New Point(0, 21)
        datagridCustomerVessels.Margin = New Padding(0)
        datagridCustomerVessels.Name = "datagridCustomerVessels"
        datagridCustomerVessels.ReadOnly = True
        datagridCustomerVessels.RowHeadersWidth = 82
        datagridCustomerVessels.Size = New Size(884, 229)
        datagridCustomerVessels.TabIndex = 2
        ' 
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "Vessel Name"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 240
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.ReadOnly = True
        VesselNameDataGridViewTextBoxColumn.Width = 240
        ' 
        ' PrimaryVesselNumberDataGridViewTextBoxColumn
        ' 
        PrimaryVesselNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        PrimaryVesselNumberDataGridViewTextBoxColumn.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumberDataGridViewTextBoxColumn.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumberDataGridViewTextBoxColumn.MinimumWidth = 180
        PrimaryVesselNumberDataGridViewTextBoxColumn.Name = "PrimaryVesselNumberDataGridViewTextBoxColumn"
        PrimaryVesselNumberDataGridViewTextBoxColumn.ReadOnly = True
        PrimaryVesselNumberDataGridViewTextBoxColumn.Width = 180
        ' 
        ' HullIdNumberDataGridViewTextBoxColumn
        ' 
        HullIdNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        HullIdNumberDataGridViewTextBoxColumn.DataPropertyName = "HullIdNumber"
        HullIdNumberDataGridViewTextBoxColumn.HeaderText = "Hull Id Number"
        HullIdNumberDataGridViewTextBoxColumn.MinimumWidth = 180
        HullIdNumberDataGridViewTextBoxColumn.Name = "HullIdNumberDataGridViewTextBoxColumn"
        HullIdNumberDataGridViewTextBoxColumn.ReadOnly = True
        HullIdNumberDataGridViewTextBoxColumn.Width = 180
        ' 
        ' CallSign
        ' 
        CallSign.DataPropertyName = "CallSign"
        CallSign.HeaderText = "Call Sign"
        CallSign.MinimumWidth = 200
        CallSign.Name = "CallSign"
        CallSign.ReadOnly = True
        CallSign.Width = 200
        ' 
        ' labCustomerVesselsTitle
        ' 
        labCustomerVesselsTitle.AutoSize = True
        labCustomerVesselsTitle.Dock = DockStyle.Fill
        labCustomerVesselsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        labCustomerVesselsTitle.Location = New Point(0, 0)
        labCustomerVesselsTitle.Margin = New Padding(0, 0, 2, 1)
        labCustomerVesselsTitle.Name = "labCustomerVesselsTitle"
        labCustomerVesselsTitle.Size = New Size(882, 20)
        labCustomerVesselsTitle.TabIndex = 3
        labCustomerVesselsTitle.Text = "Vessels"
        ' 
        ' PanelVesselJobs
        ' 
        PanelVesselJobs.AutoSize = True
        PanelVesselJobs.ColumnCount = 1
        PanelVesselJobs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        PanelVesselJobs.Controls.Add(DataGridVesselJobs, 0, 1)
        PanelVesselJobs.Controls.Add(labVesselJobsTitle, 0, 0)
        PanelVesselJobs.Location = New Point(911, 558)
        PanelVesselJobs.Margin = New Padding(0)
        PanelVesselJobs.Name = "PanelVesselJobs"
        PanelVesselJobs.RowCount = 2
        PanelVesselJobs.RowStyles.Add(New RowStyle())
        PanelVesselJobs.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        PanelVesselJobs.Size = New Size(927, 250)
        PanelVesselJobs.TabIndex = 4
        ' 
        ' DataGridVesselJobs
        ' 
        DataGridVesselJobs.AllowUserToAddRows = False
        DataGridVesselJobs.AllowUserToDeleteRows = False
        DataGridVesselJobs.AutoGenerateColumns = False
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridVesselJobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridVesselJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridVesselJobs.Columns.AddRange(New DataGridViewColumn() {JobNumberDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn})
        DataGridVesselJobs.DataSource = JobBindingSource
        DataGridVesselJobs.Location = New Point(0, 21)
        DataGridVesselJobs.Margin = New Padding(0)
        DataGridVesselJobs.Name = "DataGridVesselJobs"
        DataGridVesselJobs.ReadOnly = True
        DataGridVesselJobs.RowHeadersWidth = 82
        DataGridVesselJobs.Size = New Size(925, 229)
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
        StartDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "StartDate"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 200
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.ReadOnly = True
        StartDateDataGridViewTextBoxColumn.Width = 200
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 540
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn.Width = 540
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.Dock = DockStyle.Fill
        labVesselJobsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 2, 1)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(925, 20)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.AutoSize = True
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.Controls.Add(dataGridCustomers, 0, 1)
        TableLayoutPanel3.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel3.Location = New Point(12, 12)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.Size = New Size(1826, 526)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(0, 0)
        RecordNavigationBar1.Margin = New Padding(0, 0, 0, 12)
        RecordNavigationBar1.MasterControl = Nothing
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 1
        ' 
        ' CustomerNameDataGridViewTextBoxColumn
        ' 
        CustomerNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CustomerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName"
        CustomerNameDataGridViewTextBoxColumn.HeaderText = "Customer Name"
        CustomerNameDataGridViewTextBoxColumn.MinimumWidth = 120
        CustomerNameDataGridViewTextBoxColumn.Name = "CustomerNameDataGridViewTextBoxColumn"
        CustomerNameDataGridViewTextBoxColumn.Width = 120
        ' 
        ' AddressDataGridViewTextBoxColumn
        ' 
        AddressDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        AddressDataGridViewTextBoxColumn.MinimumWidth = 120
        AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        AddressDataGridViewTextBoxColumn.Width = 120
        ' 
        ' CityDataGridViewTextBoxColumn
        ' 
        CityDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        CityDataGridViewTextBoxColumn.HeaderText = "City"
        CityDataGridViewTextBoxColumn.MinimumWidth = 120
        CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        CityDataGridViewTextBoxColumn.Width = 120
        ' 
        ' State
        ' 
        State.DataPropertyName = "State"
        State.DataSource = StateCodeBindingSource
        State.DisplayMember = "StateName"
        State.HeaderText = "State"
        State.MinimumWidth = 90
        State.Name = "State"
        State.ValueMember = "StateCode1"
        State.Width = 90
        ' 
        ' PostalCodeDataGridViewTextBoxColumn
        ' 
        PostalCodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        PostalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode"
        PostalCodeDataGridViewTextBoxColumn.HeaderText = "Postal Code"
        PostalCodeDataGridViewTextBoxColumn.MinimumWidth = 120
        PostalCodeDataGridViewTextBoxColumn.Name = "PostalCodeDataGridViewTextBoxColumn"
        PostalCodeDataGridViewTextBoxColumn.Width = 120
        ' 
        ' CountryCode
        ' 
        CountryCode.DataPropertyName = "CountryCode"
        CountryCode.DataSource = CountryCodeBindingSource
        CountryCode.DisplayMember = "Country"
        CountryCode.HeaderText = "Country Code"
        CountryCode.MinimumWidth = 120
        CountryCode.Name = "CountryCode"
        CountryCode.ValueMember = "Alpha2Code"
        CountryCode.Width = 120
        ' 
        ' TelephoneDataGridViewTextBoxColumn
        ' 
        TelephoneDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        TelephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone"
        TelephoneDataGridViewTextBoxColumn.HeaderText = "Telephone"
        TelephoneDataGridViewTextBoxColumn.MinimumWidth = 160
        TelephoneDataGridViewTextBoxColumn.Name = "TelephoneDataGridViewTextBoxColumn"
        TelephoneDataGridViewTextBoxColumn.Width = 160
        ' 
        ' EmailDataGridViewTextBoxColumn
        ' 
        EmailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        EmailDataGridViewTextBoxColumn.MinimumWidth = 120
        EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        EmailDataGridViewTextBoxColumn.Width = 120
        ' 
        ' WebsiteDataGridViewTextBoxColumn
        ' 
        WebsiteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        WebsiteDataGridViewTextBoxColumn.DataPropertyName = "Website"
        WebsiteDataGridViewTextBoxColumn.HeaderText = "Website"
        WebsiteDataGridViewTextBoxColumn.MinimumWidth = 120
        WebsiteDataGridViewTextBoxColumn.Name = "WebsiteDataGridViewTextBoxColumn"
        WebsiteDataGridViewTextBoxColumn.Width = 120
        ' 
        ' FrmCustomers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1852, 817)
        Controls.Add(TableLayoutPanel3)
        Controls.Add(PanelVesselJobs)
        Controls.Add(PanelCustomerVessels)
        Margin = New Padding(1, 0, 1, 0)
        Name = "FrmCustomers"
        Text = "Customers"
        CType(dataGridCustomers, ComponentModel.ISupportInitialize).EndInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelCustomerVessels.ResumeLayout(False)
        PanelCustomerVessels.PerformLayout()
        CType(datagridCustomerVessels, ComponentModel.ISupportInitialize).EndInit()
        PanelVesselJobs.ResumeLayout(False)
        PanelVesselJobs.PerformLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dataGridCustomers As DataGridView
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents StateCodeBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents PanelCustomerVessels As TableLayoutPanel
    Friend WithEvents datagridCustomerVessels As DataGridView
    Friend WithEvents labCustomerVesselsTitle As Label
    Friend WithEvents PanelVesselJobs As TableLayoutPanel
    Friend WithEvents DataGridVesselJobs As DataGridView
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrimaryVesselNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HullIdNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CallSign As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents JobNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewComboBoxColumn
    Friend WithEvents PostalCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CountryCode As DataGridViewComboBoxColumn
    Friend WithEvents TelephoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WebsiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
