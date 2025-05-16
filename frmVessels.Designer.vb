<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVessels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVessels))
        Dim Vessel_NameLabel As System.Windows.Forms.Label
        Me.HaleMRIDataSet = New Hale_MRI.HaleMRIDataSet()
        Me.VesselsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VesselsTableAdapter = New Hale_MRI.HaleMRIDataSetTableAdapters.VesselsTableAdapter()
        Me.TableAdapterManager = New Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager()
        Me.VesselsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.VesselsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Vessel_NameTextBox = New System.Windows.Forms.TextBox()
        Vessel_NameLabel = New System.Windows.Forms.Label()
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VesselsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'HaleMRIDataSet
        '
        Me.HaleMRIDataSet.DataSetName = "HaleMRIDataSet"
        Me.HaleMRIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VesselsBindingSource
        '
        Me.VesselsBindingSource.DataMember = "Vessels"
        Me.VesselsBindingSource.DataSource = Me.HaleMRIDataSet
        '
        'VesselsTableAdapter
        '
        Me.VesselsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Cell_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.Job_DetailsTableAdapter = Nothing
        Me.TableAdapterManager.JobsTableAdapter = Nothing
        Me.TableAdapterManager.ManufacturersTableAdapter = Nothing
        Me.TableAdapterManager.PropellersTableAdapter = Nothing
        Me.TableAdapterManager.Radius_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VesselsTableAdapter = Me.VesselsTableAdapter
        '
        'VesselsBindingNavigator
        '
        Me.VesselsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.VesselsBindingNavigator.BindingSource = Me.VesselsBindingSource
        Me.VesselsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.VesselsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.VesselsBindingNavigator.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.VesselsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.VesselsBindingNavigatorSaveItem})
        Me.VesselsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.VesselsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.VesselsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.VesselsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.VesselsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.VesselsBindingNavigator.Name = "VesselsBindingNavigator"
        Me.VesselsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.VesselsBindingNavigator.Size = New System.Drawing.Size(2059, 50)
        Me.VesselsBindingNavigator.TabIndex = 0
        Me.VesselsBindingNavigator.Text = "BindingNavigator1"
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
        'VesselsBindingNavigatorSaveItem
        '
        Me.VesselsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.VesselsBindingNavigatorSaveItem.Image = CType(resources.GetObject("VesselsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.VesselsBindingNavigatorSaveItem.Name = "VesselsBindingNavigatorSaveItem"
        Me.VesselsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.VesselsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'Vessel_NameLabel
        '
        Vessel_NameLabel.AutoSize = True
        Vessel_NameLabel.Location = New System.Drawing.Point(59, 103)
        Vessel_NameLabel.Name = "Vessel_NameLabel"
        Vessel_NameLabel.Size = New System.Drawing.Size(145, 25)
        Vessel_NameLabel.TabIndex = 1
        Vessel_NameLabel.Text = "Vessel Name:"
        '
        'Vessel_NameTextBox
        '
        Me.Vessel_NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VesselsBindingSource, "Vessel Name", True))
        Me.Vessel_NameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vessel_NameTextBox.Location = New System.Drawing.Point(272, 100)
        Me.Vessel_NameTextBox.Name = "Vessel_NameTextBox"
        Me.Vessel_NameTextBox.Size = New System.Drawing.Size(476, 31)
        Me.Vessel_NameTextBox.TabIndex = 2
        '
        'frmVessels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2059, 1001)
        Me.Controls.Add(Vessel_NameLabel)
        Me.Controls.Add(Me.Vessel_NameTextBox)
        Me.Controls.Add(Me.VesselsBindingNavigator)
        Me.Name = "frmVessels"
        Me.Text = "Vessels"
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VesselsBindingNavigator.ResumeLayout(False)
        Me.VesselsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HaleMRIDataSet As HaleMRIDataSet
    Friend WithEvents VesselsBindingSource As BindingSource
    Friend WithEvents VesselsTableAdapter As HaleMRIDataSetTableAdapters.VesselsTableAdapter
    Friend WithEvents TableAdapterManager As HaleMRIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents VesselsBindingNavigator As BindingNavigator
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
    Friend WithEvents VesselsBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents Vessel_NameTextBox As TextBox
End Class
