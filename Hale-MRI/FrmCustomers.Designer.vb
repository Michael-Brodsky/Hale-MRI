<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomers
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        dataGridCustomers = New DataGridView()
        CustomerNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        AddressDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CityDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        State = New DataGridViewComboBoxColumn()
        StateCodeBindingSource = New BindingSource(components)
        PostalCodeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CountryCode = New DataGridViewComboBoxColumn()
        CountryCodeBindingSource = New BindingSource(components)
        TelephoneDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EmailDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WebsiteDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CustomerBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        EmployeeBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        datagridCustomerVessels = New DataGridView()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PrimaryVesselNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HullIdNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        labCustomerVesselsTitle = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        DataGridView3 = New DataGridView()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        labVesselJobsTitle = New Label()
        cmdSave = New Button()
        cmdCancel = New Button()
        DataGridView2 = New DataGridView()
        CType(dataGridCustomers, ComponentModel.ISupportInitialize).BeginInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        CType(datagridCustomerVessels, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        CType(DataGridView3, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
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
        dataGridCustomers.Location = New Point(28, 27)
        dataGridCustomers.Name = "dataGridCustomers"
        dataGridCustomers.RowHeadersWidth = 82
        dataGridCustomers.Size = New Size(2080, 600)
        dataGridCustomers.TabIndex = 0
        ' 
        ' CustomerNameDataGridViewTextBoxColumn
        ' 
        CustomerNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CustomerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName"
        CustomerNameDataGridViewTextBoxColumn.HeaderText = "Customer Name"
        CustomerNameDataGridViewTextBoxColumn.MinimumWidth = 240
        CustomerNameDataGridViewTextBoxColumn.Name = "CustomerNameDataGridViewTextBoxColumn"
        CustomerNameDataGridViewTextBoxColumn.Width = 240
        ' 
        ' AddressDataGridViewTextBoxColumn
        ' 
        AddressDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        AddressDataGridViewTextBoxColumn.MinimumWidth = 280
        AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        AddressDataGridViewTextBoxColumn.Width = 280
        ' 
        ' CityDataGridViewTextBoxColumn
        ' 
        CityDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        CityDataGridViewTextBoxColumn.HeaderText = "City"
        CityDataGridViewTextBoxColumn.MinimumWidth = 200
        CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        CityDataGridViewTextBoxColumn.Width = 200
        ' 
        ' State
        ' 
        State.DataPropertyName = "State"
        State.DataSource = StateCodeBindingSource
        State.DisplayMember = "StateCode1"
        State.HeaderText = "State"
        State.MinimumWidth = 100
        State.Name = "State"
        State.ValueMember = "StateCode1"
        State.Width = 200
        ' 
        ' StateCodeBindingSource
        ' 
        StateCodeBindingSource.DataSource = GetType(LibDatabase.Models.StateCode)
        ' 
        ' PostalCodeDataGridViewTextBoxColumn
        ' 
        PostalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode"
        PostalCodeDataGridViewTextBoxColumn.HeaderText = "Postal Code"
        PostalCodeDataGridViewTextBoxColumn.MinimumWidth = 10
        PostalCodeDataGridViewTextBoxColumn.Name = "PostalCodeDataGridViewTextBoxColumn"
        PostalCodeDataGridViewTextBoxColumn.Width = 200
        ' 
        ' CountryCode
        ' 
        CountryCode.DataPropertyName = "CountryCode"
        CountryCode.DataSource = CountryCodeBindingSource
        CountryCode.DisplayMember = "Country"
        CountryCode.HeaderText = "Country Code"
        CountryCode.MinimumWidth = 200
        CountryCode.Name = "CountryCode"
        CountryCode.ValueMember = "Alpha2Code"
        CountryCode.Width = 200
        ' 
        ' CountryCodeBindingSource
        ' 
        CountryCodeBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' TelephoneDataGridViewTextBoxColumn
        ' 
        TelephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone"
        TelephoneDataGridViewTextBoxColumn.HeaderText = "Telephone"
        TelephoneDataGridViewTextBoxColumn.MinimumWidth = 10
        TelephoneDataGridViewTextBoxColumn.Name = "TelephoneDataGridViewTextBoxColumn"
        TelephoneDataGridViewTextBoxColumn.Width = 200
        ' 
        ' EmailDataGridViewTextBoxColumn
        ' 
        EmailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        EmailDataGridViewTextBoxColumn.MinimumWidth = 240
        EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        EmailDataGridViewTextBoxColumn.Width = 240
        ' 
        ' WebsiteDataGridViewTextBoxColumn
        ' 
        WebsiteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        WebsiteDataGridViewTextBoxColumn.DataPropertyName = "Website"
        WebsiteDataGridViewTextBoxColumn.HeaderText = "Website"
        WebsiteDataGridViewTextBoxColumn.MinimumWidth = 240
        WebsiteDataGridViewTextBoxColumn.Name = "WebsiteDataGridViewTextBoxColumn"
        WebsiteDataGridViewTextBoxColumn.Width = 240
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
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(datagridCustomerVessels, 0, 1)
        TableLayoutPanel1.Controls.Add(labCustomerVesselsTitle, 0, 0)
        TableLayoutPanel1.Location = New Point(28, 684)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(917, 336)
        TableLayoutPanel1.TabIndex = 3
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
        datagridCustomerVessels.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn, PrimaryVesselNumberDataGridViewTextBoxColumn, HullIdNumberDataGridViewTextBoxColumn})
        datagridCustomerVessels.DataSource = VesselBindingSource
        datagridCustomerVessels.Dock = DockStyle.Fill
        datagridCustomerVessels.Location = New Point(0, 35)
        datagridCustomerVessels.Margin = New Padding(0)
        datagridCustomerVessels.Name = "datagridCustomerVessels"
        datagridCustomerVessels.RowHeadersWidth = 82
        datagridCustomerVessels.Size = New Size(917, 301)
        datagridCustomerVessels.TabIndex = 2
        ' 
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "Vessel Name"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 282
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.Width = 282
        ' 
        ' PrimaryVesselNumberDataGridViewTextBoxColumn
        ' 
        PrimaryVesselNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        PrimaryVesselNumberDataGridViewTextBoxColumn.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumberDataGridViewTextBoxColumn.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumberDataGridViewTextBoxColumn.MinimumWidth = 310
        PrimaryVesselNumberDataGridViewTextBoxColumn.Name = "PrimaryVesselNumberDataGridViewTextBoxColumn"
        PrimaryVesselNumberDataGridViewTextBoxColumn.Width = 310
        ' 
        ' HullIdNumberDataGridViewTextBoxColumn
        ' 
        HullIdNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        HullIdNumberDataGridViewTextBoxColumn.DataPropertyName = "HullIdNumber"
        HullIdNumberDataGridViewTextBoxColumn.HeaderText = "Hull Id Number"
        HullIdNumberDataGridViewTextBoxColumn.MinimumWidth = 241
        HullIdNumberDataGridViewTextBoxColumn.Name = "HullIdNumberDataGridViewTextBoxColumn"
        HullIdNumberDataGridViewTextBoxColumn.Width = 241
        ' 
        ' labCustomerVesselsTitle
        ' 
        labCustomerVesselsTitle.AutoSize = True
        labCustomerVesselsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        labCustomerVesselsTitle.Location = New Point(0, 0)
        labCustomerVesselsTitle.Margin = New Padding(0, 0, 3, 3)
        labCustomerVesselsTitle.Name = "labCustomerVesselsTitle"
        labCustomerVesselsTitle.Size = New Size(94, 32)
        labCustomerVesselsTitle.TabIndex = 3
        labCustomerVesselsTitle.Text = "Vessels"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(DataGridView3, 0, 1)
        TableLayoutPanel2.Controls.Add(labVesselJobsTitle, 0, 0)
        TableLayoutPanel2.Location = New Point(975, 684)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1132, 336)
        TableLayoutPanel2.TabIndex = 4
        ' 
        ' DataGridView3
        ' 
        DataGridView3.AllowUserToAddRows = False
        DataGridView3.AllowUserToDeleteRows = False
        DataGridView3.AutoGenerateColumns = False
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView3.Columns.AddRange(New DataGridViewColumn() {JobNumberDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn})
        DataGridView3.DataSource = JobBindingSource
        DataGridView3.Location = New Point(0, 35)
        DataGridView3.Margin = New Padding(0)
        DataGridView3.Name = "DataGridView3"
        DataGridView3.RowHeadersWidth = 82
        DataGridView3.Size = New Size(1126, 301)
        DataGridView3.TabIndex = 3
        ' 
        ' JobNumberDataGridViewTextBoxColumn
        ' 
        JobNumberDataGridViewTextBoxColumn.DataPropertyName = "JobNumber"
        JobNumberDataGridViewTextBoxColumn.HeaderText = "Job Number"
        JobNumberDataGridViewTextBoxColumn.MinimumWidth = 200
        JobNumberDataGridViewTextBoxColumn.Name = "JobNumberDataGridViewTextBoxColumn"
        JobNumberDataGridViewTextBoxColumn.Width = 200
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "StartDate"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 300
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.Width = 300
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 542
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.Width = 542
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 3, 3)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(66, 32)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' cmdSave
        ' 
        cmdSave.Location = New Point(28, 1056)
        cmdSave.Name = "cmdSave"
        cmdSave.Size = New Size(146, 46)
        cmdSave.TabIndex = 5
        cmdSave.Text = "Save"
        cmdSave.UseVisualStyleBackColor = True
        ' 
        ' cmdCancel
        ' 
        cmdCancel.Location = New Point(180, 1056)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New Size(150, 46)
        cmdCancel.TabIndex = 6
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        ' 
        ' DataGridView2
        ' 
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(1103, 654)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.RowHeadersWidth = 82
        DataGridView2.Size = New Size(8, 8)
        DataGridView2.TabIndex = 7
        ' 
        ' FrmCustomers
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2136, 1134)
        Controls.Add(DataGridView2)
        Controls.Add(cmdCancel)
        Controls.Add(cmdSave)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(dataGridCustomers)
        Name = "FrmCustomers"
        Text = "Customers"
        CType(dataGridCustomers, ComponentModel.ISupportInitialize).EndInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(datagridCustomerVessels, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(DataGridView3, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dataGridCustomers As DataGridView
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents StateCodeBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents datagridCustomerVessels As DataGridView
    Friend WithEvents labCustomerVesselsTitle As Label
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrimaryVesselNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HullIdNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents DataGridView2 As DataGridView
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
