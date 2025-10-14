<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPropellers
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
        RecordNavigationBar1 = New RecordNavigationBar()
        DataGridPropellers = New DataGridView()
        ManufacturersBindingSource = New BindingSource(components)
        StylesBindingSource = New BindingSource(components)
        BladesBindingSource = New BindingSource(components)
        RotationsBindingSource = New BindingSource(components)
        MaterialsBindingSource = New BindingSource(components)
        PropellerBindingSource = New BindingSource(components)
        Manufacturer = New DataGridViewComboBoxColumn()
        PartNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Style = New DataGridViewComboBoxColumn()
        Blades = New DataGridViewComboBoxColumn()
        Rotation = New DataGridViewComboBoxColumn()
        Material = New DataGridViewComboBoxColumn()
        Diameter = New DataGridViewTextBoxColumn()
        HubDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BoreDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladeWidthDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladeAreaDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        WeightDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CType(DataGridPropellers, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(RotationsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(PropellerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(12, 12)
        RecordNavigationBar1.Margin = New Padding(0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.NoUpdates = False
        RecordNavigationBar1.Size = New Size(644, 24)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' DataGridPropellers
        ' 
        DataGridPropellers.AutoGenerateColumns = False
        DataGridPropellers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridPropellers.Columns.AddRange(New DataGridViewColumn() {Manufacturer, PartNumberDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn, Style, Blades, Rotation, Material, Diameter, HubDataGridViewTextBoxColumn, BoreDataGridViewTextBoxColumn, BladeWidthDataGridViewTextBoxColumn, BladeAreaDataGridViewTextBoxColumn, WeightDataGridViewTextBoxColumn})
        DataGridPropellers.DataSource = PropellerBindingSource
        DataGridPropellers.Location = New Point(12, 58)
        DataGridPropellers.Name = "DataGridPropellers"
        DataGridPropellers.Size = New Size(1413, 579)
        DataGridPropellers.TabIndex = 1
        ' 
        ' ManufacturersBindingSource
        ' 
        ManufacturersBindingSource.DataSource = GetType(LibDatabase.Models.Manufacturer)
        ManufacturersBindingSource.Sort = "ManufacturerName ASC"
        ' 
        ' StylesBindingSource
        ' 
        StylesBindingSource.DataSource = GetType(LibDatabase.Models.Style)
        ' 
        ' BladesBindingSource
        ' 
        BladesBindingSource.DataSource = GetType(LibDatabase.Models.Blade)
        ' 
        ' RotationsBindingSource
        ' 
        RotationsBindingSource.DataSource = GetType(LibDatabase.Models.Rotation)
        ' 
        ' MaterialsBindingSource
        ' 
        MaterialsBindingSource.DataSource = GetType(LibDatabase.Models.Material)
        ' 
        ' PropellerBindingSource
        ' 
        PropellerBindingSource.DataSource = GetType(LibDatabase.Models.Propeller)
        PropellerBindingSource.Sort = "ManufacturerID ASC"
        ' 
        ' Manufacturer
        ' 
        Manufacturer.DataPropertyName = "ManufacturerId"
        Manufacturer.DataSource = ManufacturersBindingSource
        Manufacturer.DisplayMember = "ManufacturerName"
        Manufacturer.HeaderText = "Manufacturer"
        Manufacturer.MinimumWidth = 160
        Manufacturer.Name = "Manufacturer"
        Manufacturer.ValueMember = "Id"
        Manufacturer.Width = 160
        ' 
        ' PartNumberDataGridViewTextBoxColumn
        ' 
        PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.HeaderText = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.MinimumWidth = 100
        PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 210
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.Width = 210
        ' 
        ' Style
        ' 
        Style.DataPropertyName = "Style"
        Style.DataSource = StylesBindingSource
        Style.DisplayMember = "Style1"
        Style.HeaderText = "Style"
        Style.MinimumWidth = 100
        Style.Name = "Style"
        Style.ValueMember = "Style1"
        ' 
        ' Blades
        ' 
        Blades.DataPropertyName = "Blades"
        Blades.DataSource = BladesBindingSource
        Blades.DisplayMember = "BladeCount"
        Blades.HeaderText = "Blades"
        Blades.MinimumWidth = 80
        Blades.Name = "Blades"
        Blades.ValueMember = "BladeCount"
        Blades.Width = 80
        ' 
        ' Rotation
        ' 
        Rotation.DataPropertyName = "Rotation"
        Rotation.DataSource = RotationsBindingSource
        Rotation.DisplayMember = "Rotation1"
        Rotation.HeaderText = "Rotation"
        Rotation.MinimumWidth = 80
        Rotation.Name = "Rotation"
        Rotation.ValueMember = "Rotation1"
        Rotation.Width = 80
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
        ' Diameter
        ' 
        Diameter.DataPropertyName = "Diameter"
        Diameter.HeaderText = "Diameter"
        Diameter.MinimumWidth = 80
        Diameter.Name = "Diameter"
        Diameter.Width = 80
        ' 
        ' HubDataGridViewTextBoxColumn
        ' 
        HubDataGridViewTextBoxColumn.DataPropertyName = "Hub"
        HubDataGridViewTextBoxColumn.HeaderText = "Hub"
        HubDataGridViewTextBoxColumn.MinimumWidth = 80
        HubDataGridViewTextBoxColumn.Name = "HubDataGridViewTextBoxColumn"
        HubDataGridViewTextBoxColumn.Width = 80
        ' 
        ' BoreDataGridViewTextBoxColumn
        ' 
        BoreDataGridViewTextBoxColumn.DataPropertyName = "Bore"
        BoreDataGridViewTextBoxColumn.HeaderText = "Bore"
        BoreDataGridViewTextBoxColumn.MinimumWidth = 80
        BoreDataGridViewTextBoxColumn.Name = "BoreDataGridViewTextBoxColumn"
        BoreDataGridViewTextBoxColumn.Width = 80
        ' 
        ' BladeWidthDataGridViewTextBoxColumn
        ' 
        BladeWidthDataGridViewTextBoxColumn.DataPropertyName = "BladeWidth"
        BladeWidthDataGridViewTextBoxColumn.HeaderText = "Blade Width"
        BladeWidthDataGridViewTextBoxColumn.Name = "BladeWidthDataGridViewTextBoxColumn"
        ' 
        ' BladeAreaDataGridViewTextBoxColumn
        ' 
        BladeAreaDataGridViewTextBoxColumn.DataPropertyName = "BladeArea"
        BladeAreaDataGridViewTextBoxColumn.HeaderText = "Blade Area"
        BladeAreaDataGridViewTextBoxColumn.Name = "BladeAreaDataGridViewTextBoxColumn"
        ' 
        ' WeightDataGridViewTextBoxColumn
        ' 
        WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
        WeightDataGridViewTextBoxColumn.HeaderText = "Weight"
        WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
        ' 
        ' FrmPropellers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1440, 649)
        Controls.Add(DataGridPropellers)
        Controls.Add(RecordNavigationBar1)
        Name = "FrmPropellers"
        Text = "Propellers"
        CType(DataGridPropellers, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturersBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(StylesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BladesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(RotationsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MaterialsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(PropellerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents DataGridPropellers As DataGridView
    Friend WithEvents RotationlInertiaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropellerBindingSource As BindingSource
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents StylesBindingSource As BindingSource
    Friend WithEvents BladesBindingSource As BindingSource
    Friend WithEvents RotationsBindingSource As BindingSource
    Friend WithEvents MaterialsBindingSource As BindingSource
    Friend WithEvents Manufacturer As DataGridViewComboBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Style As DataGridViewComboBoxColumn
    Friend WithEvents Blades As DataGridViewComboBoxColumn
    Friend WithEvents Rotation As DataGridViewComboBoxColumn
    Friend WithEvents Material As DataGridViewComboBoxColumn
    Friend WithEvents Diameter As DataGridViewTextBoxColumn
    Friend WithEvents HubDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BoreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladeWidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladeAreaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
