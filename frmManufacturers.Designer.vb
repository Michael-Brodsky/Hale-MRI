<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManufacturers
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManufacturers))
        Dim Manufacturer_NameLabel As System.Windows.Forms.Label
        Me.HaleMRIDataSet = New Hale_MRI.HaleMRIDataSet()
        Me.ManufacturersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ManufacturersTableAdapter = New Hale_MRI.HaleMRIDataSetTableAdapters.ManufacturersTableAdapter()
        Me.TableAdapterManager = New Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager()
        Me.ManufacturersBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ManufacturersBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Manufacturer_NameTextBox = New System.Windows.Forms.TextBox()
        Manufacturer_NameLabel = New System.Windows.Forms.Label()
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManufacturersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManufacturersBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ManufacturersBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'HaleMRIDataSet
        '
        Me.HaleMRIDataSet.DataSetName = "HaleMRIDataSet"
        Me.HaleMRIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ManufacturersBindingSource
        '
        Me.ManufacturersBindingSource.DataMember = "Manufacturers"
        Me.ManufacturersBindingSource.DataSource = Me.HaleMRIDataSet
        '
        'ManufacturersTableAdapter
        '
        Me.ManufacturersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Cell_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.Job_DetailsTableAdapter = Nothing
        Me.TableAdapterManager.JobsTableAdapter = Nothing
        Me.TableAdapterManager.ManufacturersTableAdapter = Me.ManufacturersTableAdapter
        Me.TableAdapterManager.PropellersTableAdapter = Nothing
        Me.TableAdapterManager.Radius_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VesselsTableAdapter = Nothing
        '
        'ManufacturersBindingNavigator
        '
        Me.ManufacturersBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ManufacturersBindingNavigator.BindingSource = Me.ManufacturersBindingSource
        Me.ManufacturersBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ManufacturersBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ManufacturersBindingNavigator.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ManufacturersBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ManufacturersBindingNavigatorSaveItem})
        Me.ManufacturersBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ManufacturersBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ManufacturersBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ManufacturersBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ManufacturersBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ManufacturersBindingNavigator.Name = "ManufacturersBindingNavigator"
        Me.ManufacturersBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ManufacturersBindingNavigator.Size = New System.Drawing.Size(2061, 50)
        Me.ManufacturersBindingNavigator.TabIndex = 0
        Me.ManufacturersBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(46, 19)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(46, 36)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 39)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(70, 32)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(46, 36)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(46, 36)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(46, 44)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(46, 36)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'ManufacturersBindingNavigatorSaveItem
        '
        Me.ManufacturersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ManufacturersBindingNavigatorSaveItem.Image = CType(resources.GetObject("ManufacturersBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ManufacturersBindingNavigatorSaveItem.Name = "ManufacturersBindingNavigatorSaveItem"
        Me.ManufacturersBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.ManufacturersBindingNavigatorSaveItem.Text = "Save Data"
        '
        'Manufacturer_NameLabel
        '
        Manufacturer_NameLabel.AutoSize = True
        Manufacturer_NameLabel.Location = New System.Drawing.Point(59, 103)
        Manufacturer_NameLabel.Name = "Manufacturer_NameLabel"
        Manufacturer_NameLabel.Size = New System.Drawing.Size(207, 25)
        Manufacturer_NameLabel.TabIndex = 1
        Manufacturer_NameLabel.Text = "Manufacturer Name:"
        '
        'Manufacturer_NameTextBox
        '
        Me.Manufacturer_NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ManufacturersBindingSource, "Manufacturer Name", True))
        Me.Manufacturer_NameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Manufacturer_NameTextBox.Location = New System.Drawing.Point(272, 100)
        Me.Manufacturer_NameTextBox.Name = "Manufacturer_NameTextBox"
        Me.Manufacturer_NameTextBox.Size = New System.Drawing.Size(476, 31)
        Me.Manufacturer_NameTextBox.TabIndex = 2
        '
        'frmManufacturers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2061, 973)
        Me.Controls.Add(Manufacturer_NameLabel)
        Me.Controls.Add(Me.Manufacturer_NameTextBox)
        Me.Controls.Add(Me.ManufacturersBindingNavigator)
        Me.Name = "frmManufacturers"
        Me.Text = "Manufacturers"
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManufacturersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManufacturersBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ManufacturersBindingNavigator.ResumeLayout(False)
        Me.ManufacturersBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HaleMRIDataSet As HaleMRIDataSet
    Friend WithEvents ManufacturersBindingSource As BindingSource
    Friend WithEvents ManufacturersTableAdapter As HaleMRIDataSetTableAdapters.ManufacturersTableAdapter
    Friend WithEvents TableAdapterManager As HaleMRIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ManufacturersBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents ManufacturersBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents Manufacturer_NameTextBox As TextBox
End Class
