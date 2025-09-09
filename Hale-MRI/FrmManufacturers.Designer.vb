<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManufacturers
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
        DataGridManufacturers = New DataGridView()
        ManufacturerNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        AddressDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CityDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        State = New DataGridViewComboBoxColumn()
        StatesBindingSource = New BindingSource(components)
        PostalCodeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TelephoneDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CountryCode = New DataGridViewComboBoxColumn()
        CountryCodesBindingSource = New BindingSource(components)
        EmailDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WebsiteDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ManufacturersBindingSource = New BindingSource(components)
        RecordNavigationBar1 = New RecordNavigationBar()
        PropellersBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        labCustomerVesselsTitle = New Label()
        DataGridPropellers = New DataGridView()
        PartNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StyleDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        MaterialDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladesDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DiameterDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HubDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RotationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BoreDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladeWidthDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladeAreaDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WeightDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CType(DataGridManufacturers, ComponentModel.ISupportInitialize).BeginInit()
        CType(StatesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(PropellersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        CType(DataGridPropellers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridManufacturers
        ' 
        DataGridManufacturers.AllowUserToOrderColumns = True
        DataGridManufacturers.AutoGenerateColumns = False
        DataGridManufacturers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridManufacturers.Columns.AddRange(New DataGridViewColumn() {ManufacturerNameDataGridViewTextBoxColumn, AddressDataGridViewTextBoxColumn, CityDataGridViewTextBoxColumn, State, PostalCodeDataGridViewTextBoxColumn, TelephoneDataGridViewTextBoxColumn, CountryCode, EmailDataGridViewTextBoxColumn, WebsiteDataGridViewTextBoxColumn})
        DataGridManufacturers.DataSource = ManufacturersBindingSource
        DataGridManufacturers.Location = New Point(12, 48)
        DataGridManufacturers.Name = "DataGridManufacturers"
        DataGridManufacturers.Size = New Size(1484, 484)
        DataGridManufacturers.TabIndex = 0
        ' 
        ' ManufacturerNameDataGridViewTextBoxColumn
        ' 
        ManufacturerNameDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerName"
        ManufacturerNameDataGridViewTextBoxColumn.HeaderText = "Manufacturer Name"
        ManufacturerNameDataGridViewTextBoxColumn.MinimumWidth = 220
        ManufacturerNameDataGridViewTextBoxColumn.Name = "ManufacturerNameDataGridViewTextBoxColumn"
        ManufacturerNameDataGridViewTextBoxColumn.Width = 220
        ' 
        ' AddressDataGridViewTextBoxColumn
        ' 
        AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        AddressDataGridViewTextBoxColumn.MinimumWidth = 240
        AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        AddressDataGridViewTextBoxColumn.Width = 240
        ' 
        ' CityDataGridViewTextBoxColumn
        ' 
        CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        CityDataGridViewTextBoxColumn.HeaderText = "City"
        CityDataGridViewTextBoxColumn.MinimumWidth = 160
        CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        CityDataGridViewTextBoxColumn.Width = 160
        ' 
        ' State
        ' 
        State.DataPropertyName = "State"
        State.DataSource = StatesBindingSource
        State.DisplayMember = "StateName"
        State.HeaderText = "State"
        State.Name = "State"
        State.ValueMember = "StateCode1"
        ' 
        ' StatesBindingSource
        ' 
        StatesBindingSource.DataSource = GetType(LibDatabase.Models.StateCode)
        ' 
        ' PostalCodeDataGridViewTextBoxColumn
        ' 
        PostalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode"
        PostalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode"
        PostalCodeDataGridViewTextBoxColumn.MinimumWidth = 100
        PostalCodeDataGridViewTextBoxColumn.Name = "PostalCodeDataGridViewTextBoxColumn"
        ' 
        ' TelephoneDataGridViewTextBoxColumn
        ' 
        TelephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone"
        TelephoneDataGridViewTextBoxColumn.HeaderText = "Telephone"
        TelephoneDataGridViewTextBoxColumn.MinimumWidth = 100
        TelephoneDataGridViewTextBoxColumn.Name = "TelephoneDataGridViewTextBoxColumn"
        ' 
        ' CountryCode
        ' 
        CountryCode.DataPropertyName = "CountryCode"
        CountryCode.DataSource = CountryCodesBindingSource
        CountryCode.DisplayMember = "Alpha3Code"
        CountryCode.HeaderText = "Country Code"
        CountryCode.Name = "CountryCode"
        CountryCode.ValueMember = "Alpha2Code"
        ' 
        ' CountryCodesBindingSource
        ' 
        CountryCodesBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' EmailDataGridViewTextBoxColumn
        ' 
        EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        EmailDataGridViewTextBoxColumn.MinimumWidth = 200
        EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        EmailDataGridViewTextBoxColumn.Width = 200
        ' 
        ' WebsiteDataGridViewTextBoxColumn
        ' 
        WebsiteDataGridViewTextBoxColumn.DataPropertyName = "Website"
        WebsiteDataGridViewTextBoxColumn.HeaderText = "Website"
        WebsiteDataGridViewTextBoxColumn.MinimumWidth = 200
        WebsiteDataGridViewTextBoxColumn.Name = "WebsiteDataGridViewTextBoxColumn"
        WebsiteDataGridViewTextBoxColumn.Width = 200
        ' 
        ' ManufacturersBindingSource
        ' 
        ManufacturersBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ManufacturersBindingSource.Sort = "ManufacturerName ASC"
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(12, 12)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 1
        ' 
        ' PropellersBindingSource
        ' 
        PropellersBindingSource.DataSource = GetType(LibDatabase.Models.Propeller)
        PropellersBindingSource.Sort = ""
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(labCustomerVesselsTitle, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridPropellers, 0, 1)
        TableLayoutPanel1.Location = New Point(12, 555)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1487, 273)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' labCustomerVesselsTitle
        ' 
        labCustomerVesselsTitle.AutoSize = True
        labCustomerVesselsTitle.Dock = DockStyle.Fill
        labCustomerVesselsTitle.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        labCustomerVesselsTitle.Location = New Point(0, 0)
        labCustomerVesselsTitle.Margin = New Padding(0, 0, 2, 1)
        labCustomerVesselsTitle.Name = "labCustomerVesselsTitle"
        labCustomerVesselsTitle.Size = New Size(1485, 20)
        labCustomerVesselsTitle.TabIndex = 4
        labCustomerVesselsTitle.Text = "Propellers"
        ' 
        ' DataGridPropellers
        ' 
        DataGridPropellers.AllowUserToAddRows = False
        DataGridPropellers.AllowUserToDeleteRows = False
        DataGridPropellers.AutoGenerateColumns = False
        DataGridPropellers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridPropellers.Columns.AddRange(New DataGridViewColumn() {PartNumberDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn, StyleDataGridViewTextBoxColumn, MaterialDataGridViewTextBoxColumn, BladesDataGridViewTextBoxColumn, DiameterDataGridViewTextBoxColumn, HubDataGridViewTextBoxColumn, RotationDataGridViewTextBoxColumn, BoreDataGridViewTextBoxColumn, BladeWidthDataGridViewTextBoxColumn, BladeAreaDataGridViewTextBoxColumn, WeightDataGridViewTextBoxColumn})
        DataGridPropellers.DataSource = PropellersBindingSource
        DataGridPropellers.Location = New Point(3, 24)
        DataGridPropellers.MultiSelect = False
        DataGridPropellers.Name = "DataGridPropellers"
        DataGridPropellers.ReadOnly = True
        DataGridPropellers.Size = New Size(1481, 246)
        DataGridPropellers.TabIndex = 3
        ' 
        ' PartNumberDataGridViewTextBoxColumn
        ' 
        PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.HeaderText = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 220
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn.Width = 220
        ' 
        ' StyleDataGridViewTextBoxColumn
        ' 
        StyleDataGridViewTextBoxColumn.DataPropertyName = "Style"
        StyleDataGridViewTextBoxColumn.HeaderText = "Style"
        StyleDataGridViewTextBoxColumn.Name = "StyleDataGridViewTextBoxColumn"
        StyleDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' MaterialDataGridViewTextBoxColumn
        ' 
        MaterialDataGridViewTextBoxColumn.DataPropertyName = "Material"
        MaterialDataGridViewTextBoxColumn.HeaderText = "Material"
        MaterialDataGridViewTextBoxColumn.Name = "MaterialDataGridViewTextBoxColumn"
        MaterialDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' BladesDataGridViewTextBoxColumn
        ' 
        BladesDataGridViewTextBoxColumn.DataPropertyName = "Blades"
        BladesDataGridViewTextBoxColumn.HeaderText = "Blades"
        BladesDataGridViewTextBoxColumn.Name = "BladesDataGridViewTextBoxColumn"
        BladesDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' DiameterDataGridViewTextBoxColumn
        ' 
        DiameterDataGridViewTextBoxColumn.DataPropertyName = "Diameter"
        DiameterDataGridViewTextBoxColumn.HeaderText = "Diameter"
        DiameterDataGridViewTextBoxColumn.Name = "DiameterDataGridViewTextBoxColumn"
        DiameterDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' HubDataGridViewTextBoxColumn
        ' 
        HubDataGridViewTextBoxColumn.DataPropertyName = "Hub"
        HubDataGridViewTextBoxColumn.HeaderText = "Hub"
        HubDataGridViewTextBoxColumn.Name = "HubDataGridViewTextBoxColumn"
        HubDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' RotationDataGridViewTextBoxColumn
        ' 
        RotationDataGridViewTextBoxColumn.DataPropertyName = "Rotation"
        RotationDataGridViewTextBoxColumn.HeaderText = "Rotation"
        RotationDataGridViewTextBoxColumn.Name = "RotationDataGridViewTextBoxColumn"
        RotationDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' BoreDataGridViewTextBoxColumn
        ' 
        BoreDataGridViewTextBoxColumn.DataPropertyName = "Bore"
        BoreDataGridViewTextBoxColumn.HeaderText = "Bore"
        BoreDataGridViewTextBoxColumn.Name = "BoreDataGridViewTextBoxColumn"
        BoreDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' BladeWidthDataGridViewTextBoxColumn
        ' 
        BladeWidthDataGridViewTextBoxColumn.DataPropertyName = "BladeWidth"
        BladeWidthDataGridViewTextBoxColumn.HeaderText = "BladeWidth"
        BladeWidthDataGridViewTextBoxColumn.Name = "BladeWidthDataGridViewTextBoxColumn"
        BladeWidthDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' BladeAreaDataGridViewTextBoxColumn
        ' 
        BladeAreaDataGridViewTextBoxColumn.DataPropertyName = "BladeArea"
        BladeAreaDataGridViewTextBoxColumn.HeaderText = "BladeArea"
        BladeAreaDataGridViewTextBoxColumn.Name = "BladeAreaDataGridViewTextBoxColumn"
        BladeAreaDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' WeightDataGridViewTextBoxColumn
        ' 
        WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
        WeightDataGridViewTextBoxColumn.HeaderText = "Weight"
        WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        WeightDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' FrmManufacturers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1509, 831)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(RecordNavigationBar1)
        Controls.Add(DataGridManufacturers)
        Name = "FrmManufacturers"
        Text = "Manufacturers"
        CType(DataGridManufacturers, ComponentModel.ISupportInitialize).EndInit()
        CType(StatesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(PropellersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(DataGridPropellers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridManufacturers As DataGridView
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents StatesBindingSource As BindingSource
    Friend WithEvents CountryCodesBindingSource As BindingSource
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents PropellersBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridPropellers As DataGridView
    Friend WithEvents labCustomerVesselsTitle As Label
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StyleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MaterialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DiameterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HubDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RotationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BoreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladeWidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladeAreaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ManufacturerNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewComboBoxColumn
    Friend WithEvents PostalCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelephoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CountryCode As DataGridViewComboBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WebsiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
