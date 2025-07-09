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
        CType(DataGridManufacturers, ComponentModel.ISupportInitialize).BeginInit()
        CType(StatesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridManufacturers
        ' 
        DataGridManufacturers.AllowUserToOrderColumns = True
        DataGridManufacturers.AutoGenerateColumns = False
        DataGridManufacturers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridManufacturers.Columns.AddRange(New DataGridViewColumn() {ManufacturerNameDataGridViewTextBoxColumn, AddressDataGridViewTextBoxColumn, CityDataGridViewTextBoxColumn, State, PostalCodeDataGridViewTextBoxColumn, TelephoneDataGridViewTextBoxColumn, CountryCode, EmailDataGridViewTextBoxColumn, WebsiteDataGridViewTextBoxColumn})
        DataGridManufacturers.DataSource = ManufacturersBindingSource
        DataGridManufacturers.Location = New Point(12, 12)
        DataGridManufacturers.Name = "DataGridManufacturers"
        DataGridManufacturers.Size = New Size(1443, 437)
        DataGridManufacturers.TabIndex = 0
        ' 
        ' ManufacturerNameDataGridViewTextBoxColumn
        ' 
        ManufacturerNameDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerName"
        ManufacturerNameDataGridViewTextBoxColumn.HeaderText = "Manufacturer Name"
        ManufacturerNameDataGridViewTextBoxColumn.MinimumWidth = 240
        ManufacturerNameDataGridViewTextBoxColumn.Name = "ManufacturerNameDataGridViewTextBoxColumn"
        ManufacturerNameDataGridViewTextBoxColumn.Width = 240
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
        CityDataGridViewTextBoxColumn.MinimumWidth = 200
        CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        CityDataGridViewTextBoxColumn.Width = 200
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
        ' 
        ' FrmManufacturers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1532, 643)
        Controls.Add(DataGridManufacturers)
        Name = "FrmManufacturers"
        Text = "Manufacturers"
        CType(DataGridManufacturers, ComponentModel.ISupportInitialize).EndInit()
        CType(StatesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridManufacturers As DataGridView
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents ManufacturerNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewComboBoxColumn
    Friend WithEvents StatesBindingSource As BindingSource
    Friend WithEvents PostalCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelephoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CountryCode As DataGridViewComboBoxColumn
    Friend WithEvents CountryCodesBindingSource As BindingSource
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WebsiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
