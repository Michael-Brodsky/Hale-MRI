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
        DataGridCustomers = New DataGridView()
        CustomerName = New DataGridViewTextBoxColumn()
        Address = New DataGridViewTextBoxColumn()
        City = New DataGridViewTextBoxColumn()
        State = New DataGridViewComboBoxColumn()
        StateCodeBindingSource = New BindingSource(components)
        PostalCode = New DataGridViewTextBoxColumn()
        CountryCode = New DataGridViewComboBoxColumn()
        CountryCodeBindingSource = New BindingSource(components)
        Telephone = New DataGridViewTextBoxColumn()
        Email = New DataGridViewTextBoxColumn()
        Website = New DataGridViewTextBoxColumn()
        CustomerBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        PanelCustomerVessels = New TableLayoutPanel()
        DatagridCustomerVessels = New DataGridView()
        VesselName = New DataGridViewTextBoxColumn()
        PrimaryVesselNumber = New DataGridViewTextBoxColumn()
        CallSign = New DataGridViewTextBoxColumn()
        Flag = New DataGridViewComboBoxColumn()
        BuildYear = New DataGridViewTextBoxColumn()
        labCustomerVesselsTitle = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        RecordNavigationBar1 = New RecordNavigationBar()
        TableLayoutPanel2 = New TableLayoutPanel()
        labVesselJobsTitle = New Label()
        DataGridVesselJobs = New DataGridView()
        JobNumber = New DataGridViewTextBoxColumn()
        StartDate = New DataGridViewTextBoxColumn()
        InspectedBy = New DataGridViewComboBoxColumn()
        EmployeeBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        CType(DataGridCustomers, ComponentModel.ISupportInitialize).BeginInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelCustomerVessels.SuspendLayout()
        CType(DatagridCustomerVessels, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridCustomers
        ' 
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridCustomers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridCustomers.Columns.AddRange(New DataGridViewColumn() {CustomerName, Address, City, State, PostalCode, CountryCode, Telephone, Email, Website})
        DataGridCustomers.Location = New Point(0, 36)
        DataGridCustomers.Margin = New Padding(0)
        DataGridCustomers.Name = "DataGridCustomers"
        DataGridCustomers.RowHeadersWidth = 82
        DataGridCustomers.Size = New Size(1545, 484)
        DataGridCustomers.TabIndex = 0
        ' 
        ' CustomerName
        ' 
        CustomerName.DataPropertyName = "CustomerName"
        CustomerName.HeaderText = "Customer Name"
        CustomerName.MinimumWidth = 160
        CustomerName.Name = "CustomerName"
        CustomerName.Width = 160
        ' 
        ' Address
        ' 
        Address.DataPropertyName = "Address"
        Address.HeaderText = "Address"
        Address.MinimumWidth = 200
        Address.Name = "Address"
        Address.Width = 200
        ' 
        ' City
        ' 
        City.DataPropertyName = "City"
        City.HeaderText = "City"
        City.MinimumWidth = 160
        City.Name = "City"
        City.Width = 160
        ' 
        ' State
        ' 
        State.DataPropertyName = "State"
        State.DataSource = StateCodeBindingSource
        State.DisplayMember = "StateName"
        State.HeaderText = "State"
        State.MinimumWidth = 140
        State.Name = "State"
        State.ValueMember = "StateCode1"
        State.Width = 140
        ' 
        ' StateCodeBindingSource
        ' 
        StateCodeBindingSource.DataSource = GetType(LibDatabase.Models.StateCode)
        ' 
        ' PostalCode
        ' 
        PostalCode.DataPropertyName = "PostalCode"
        PostalCode.HeaderText = "Postal Code"
        PostalCode.Name = "PostalCode"
        ' 
        ' CountryCode
        ' 
        CountryCode.DataPropertyName = "CountryCode"
        CountryCode.DataSource = CountryCodeBindingSource
        CountryCode.DisplayMember = "Country"
        CountryCode.HeaderText = "Country Code"
        CountryCode.MinimumWidth = 180
        CountryCode.Name = "CountryCode"
        CountryCode.ValueMember = "Alpha2Code"
        CountryCode.Width = 180
        ' 
        ' CountryCodeBindingSource
        ' 
        CountryCodeBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' Telephone
        ' 
        Telephone.DataPropertyName = "Telephone"
        Telephone.HeaderText = "Telephone"
        Telephone.MinimumWidth = 120
        Telephone.Name = "Telephone"
        Telephone.Width = 120
        ' 
        ' Email
        ' 
        Email.HeaderText = "Email"
        Email.MinimumWidth = 200
        Email.Name = "Email"
        Email.Width = 200
        ' 
        ' Website
        ' 
        Website.HeaderText = "Website"
        Website.MinimumWidth = 200
        Website.Name = "Website"
        Website.Width = 200
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        VesselBindingSource.Sort = ""
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' PanelCustomerVessels
        ' 
        PanelCustomerVessels.ColumnCount = 1
        PanelCustomerVessels.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        PanelCustomerVessels.Controls.Add(DatagridCustomerVessels, 0, 1)
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
        ' DatagridCustomerVessels
        ' 
        DatagridCustomerVessels.AllowUserToAddRows = False
        DatagridCustomerVessels.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DatagridCustomerVessels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DatagridCustomerVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DatagridCustomerVessels.Columns.AddRange(New DataGridViewColumn() {VesselName, PrimaryVesselNumber, CallSign, Flag, BuildYear})
        DatagridCustomerVessels.Dock = DockStyle.Fill
        DatagridCustomerVessels.Location = New Point(0, 21)
        DatagridCustomerVessels.Margin = New Padding(0)
        DatagridCustomerVessels.MultiSelect = False
        DatagridCustomerVessels.Name = "DatagridCustomerVessels"
        DatagridCustomerVessels.ReadOnly = True
        DatagridCustomerVessels.RowHeadersWidth = 82
        DatagridCustomerVessels.Size = New Size(884, 229)
        DatagridCustomerVessels.TabIndex = 2
        ' 
        ' VesselName
        ' 
        VesselName.DataPropertyName = "VesselName"
        VesselName.HeaderText = "Vessel Name"
        VesselName.MinimumWidth = 180
        VesselName.Name = "VesselName"
        VesselName.ReadOnly = True
        VesselName.Width = 180
        ' 
        ' PrimaryVesselNumber
        ' 
        PrimaryVesselNumber.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumber.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumber.MinimumWidth = 160
        PrimaryVesselNumber.Name = "PrimaryVesselNumber"
        PrimaryVesselNumber.ReadOnly = True
        PrimaryVesselNumber.Width = 160
        ' 
        ' CallSign
        ' 
        CallSign.DataPropertyName = "CallSign"
        CallSign.HeaderText = "Call Sign"
        CallSign.Name = "CallSign"
        CallSign.ReadOnly = True
        ' 
        ' Flag
        ' 
        Flag.DataPropertyName = "Flag"
        Flag.DataSource = CountryCodeBindingSource
        Flag.DisplayMember = "Country"
        Flag.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        Flag.HeaderText = "Flag"
        Flag.MinimumWidth = 200
        Flag.Name = "Flag"
        Flag.ReadOnly = True
        Flag.Resizable = DataGridViewTriState.True
        Flag.SortMode = DataGridViewColumnSortMode.Automatic
        Flag.ValueMember = "Alpha2Code"
        Flag.Width = 200
        ' 
        ' BuildYear
        ' 
        BuildYear.DataPropertyName = "BuildYear"
        BuildYear.HeaderText = "Build Year"
        BuildYear.Name = "BuildYear"
        BuildYear.ReadOnly = True
        ' 
        ' labCustomerVesselsTitle
        ' 
        labCustomerVesselsTitle.AutoSize = True
        labCustomerVesselsTitle.BackColor = SystemColors.ActiveCaption
        labCustomerVesselsTitle.Dock = DockStyle.Fill
        labCustomerVesselsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        labCustomerVesselsTitle.Location = New Point(0, 0)
        labCustomerVesselsTitle.Margin = New Padding(0, 0, 2, 1)
        labCustomerVesselsTitle.Name = "labCustomerVesselsTitle"
        labCustomerVesselsTitle.Size = New Size(882, 20)
        labCustomerVesselsTitle.TabIndex = 3
        labCustomerVesselsTitle.Text = "Vessels"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.AutoSize = True
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.Controls.Add(DataGridCustomers, 0, 1)
        TableLayoutPanel3.Controls.Add(RecordNavigationBar1, 0, 0)
        TableLayoutPanel3.Location = New Point(12, 12)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 3
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(1547, 546)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Enabled = False
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(0, 0)
        RecordNavigationBar1.Margin = New Padding(0, 0, 0, 12)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(635, 24)
        RecordNavigationBar1.TabIndex = 1
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(labVesselJobsTitle, 0, 0)
        TableLayoutPanel2.Controls.Add(DataGridVesselJobs, 0, 1)
        TableLayoutPanel2.Location = New Point(912, 558)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(647, 250)
        TableLayoutPanel2.TabIndex = 6
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.BackColor = SystemColors.ActiveCaption
        labVesselJobsTitle.Dock = DockStyle.Fill
        labVesselJobsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 2, 1)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(645, 20)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' DataGridVesselJobs
        ' 
        DataGridVesselJobs.AllowUserToAddRows = False
        DataGridVesselJobs.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridVesselJobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridVesselJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridVesselJobs.Columns.AddRange(New DataGridViewColumn() {JobNumber, StartDate, InspectedBy, Description})
        DataGridVesselJobs.Location = New Point(0, 21)
        DataGridVesselJobs.Margin = New Padding(0)
        DataGridVesselJobs.MultiSelect = False
        DataGridVesselJobs.Name = "DataGridVesselJobs"
        DataGridVesselJobs.ReadOnly = True
        DataGridVesselJobs.Size = New Size(647, 229)
        DataGridVesselJobs.TabIndex = 1
        ' 
        ' JobNumber
        ' 
        JobNumber.DataPropertyName = "JobNumber"
        JobNumber.HeaderText = "Job Number"
        JobNumber.Name = "JobNumber"
        JobNumber.ReadOnly = True
        ' 
        ' StartDate
        ' 
        StartDate.DataPropertyName = "StartDate"
        StartDate.HeaderText = "Start Date"
        StartDate.MinimumWidth = 120
        StartDate.Name = "StartDate"
        StartDate.ReadOnly = True
        StartDate.Width = 120
        ' 
        ' InspectedBy
        ' 
        InspectedBy.DataPropertyName = "InspectedBy"
        InspectedBy.DataSource = EmployeeBindingSource
        InspectedBy.DisplayMember = "EmployeeName"
        InspectedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        InspectedBy.HeaderText = "Inspected By"
        InspectedBy.MinimumWidth = 130
        InspectedBy.Name = "InspectedBy"
        InspectedBy.ReadOnly = True
        InspectedBy.Resizable = DataGridViewTriState.True
        InspectedBy.SortMode = DataGridViewColumnSortMode.Automatic
        InspectedBy.ValueMember = "Id"
        InspectedBy.Width = 130
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeeBindingSource.Sort = ""
        ' 
        ' Description
        ' 
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.MinimumWidth = 254
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Width = 254
        ' 
        ' FrmCustomers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1571, 817)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel3)
        Controls.Add(PanelCustomerVessels)
        Margin = New Padding(1, 0, 1, 0)
        Name = "FrmCustomers"
        Text = "Customers"
        CType(DataGridCustomers, ComponentModel.ISupportInitialize).EndInit()
        CType(StateCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelCustomerVessels.ResumeLayout(False)
        PanelCustomerVessels.PerformLayout()
        CType(DatagridCustomerVessels, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(DataGridVesselJobs, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridCustomers As DataGridView
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents StateCodeBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents PanelCustomerVessels As TableLayoutPanel
    Friend WithEvents DatagridCustomerVessels As DataGridView
    Friend WithEvents labCustomerVesselsTitle As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents DataGridVesselJobs As DataGridView
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents VesselName As DataGridViewTextBoxColumn
    Friend WithEvents PrimaryVesselNumber As DataGridViewTextBoxColumn
    Friend WithEvents CallSign As DataGridViewTextBoxColumn
    Friend WithEvents Flag As DataGridViewComboBoxColumn
    Friend WithEvents BuildYear As DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents City As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewComboBoxColumn
    Friend WithEvents PostalCode As DataGridViewTextBoxColumn
    Friend WithEvents CountryCode As DataGridViewComboBoxColumn
    Friend WithEvents Telephone As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Website As DataGridViewTextBoxColumn
    Friend WithEvents JobNumber As DataGridViewTextBoxColumn
    Friend WithEvents StartDate As DataGridViewTextBoxColumn
    Friend WithEvents InspectedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
End Class
