<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobDetails))
        Dim Job_IDLabel As System.Windows.Forms.Label
        Me.HaleMRIDataSet = New Hale_MRI.HaleMRIDataSet()
        Me.Job_DetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Job_DetailsTableAdapter = New Hale_MRI.HaleMRIDataSetTableAdapters.Job_DetailsTableAdapter()
        Me.TableAdapterManager = New Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager()
        Me.Job_DetailsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.Job_DetailsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Job_IDTextBox = New System.Windows.Forms.TextBox()
        Job_IDLabel = New System.Windows.Forms.Label()
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Job_DetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Job_DetailsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Job_DetailsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'HaleMRIDataSet
        '
        Me.HaleMRIDataSet.DataSetName = "HaleMRIDataSet"
        Me.HaleMRIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Job_DetailsBindingSource
        '
        Me.Job_DetailsBindingSource.DataMember = "Job Details"
        Me.Job_DetailsBindingSource.DataSource = Me.HaleMRIDataSet
        '
        'Job_DetailsTableAdapter
        '
        Me.Job_DetailsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Cell_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.Job_DetailsTableAdapter = Me.Job_DetailsTableAdapter
        Me.TableAdapterManager.JobsTableAdapter = Nothing
        Me.TableAdapterManager.ManufacturersTableAdapter = Nothing
        Me.TableAdapterManager.PropellersTableAdapter = Nothing
        Me.TableAdapterManager.Radius_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VesselsTableAdapter = Nothing
        '
        'Job_DetailsBindingNavigator
        '
        Me.Job_DetailsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Job_DetailsBindingNavigator.BindingSource = Me.Job_DetailsBindingSource
        Me.Job_DetailsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Job_DetailsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Job_DetailsBindingNavigator.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Job_DetailsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Job_DetailsBindingNavigatorSaveItem})
        Me.Job_DetailsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Job_DetailsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Job_DetailsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Job_DetailsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Job_DetailsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Job_DetailsBindingNavigator.Name = "Job_DetailsBindingNavigator"
        Me.Job_DetailsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Job_DetailsBindingNavigator.Size = New System.Drawing.Size(1779, 42)
        Me.Job_DetailsBindingNavigator.TabIndex = 0
        Me.Job_DetailsBindingNavigator.Text = "BindingNavigator1"
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
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(46, 36)
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
        'Job_DetailsBindingNavigatorSaveItem
        '
        Me.Job_DetailsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Job_DetailsBindingNavigatorSaveItem.Image = CType(resources.GetObject("Job_DetailsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Job_DetailsBindingNavigatorSaveItem.Name = "Job_DetailsBindingNavigatorSaveItem"
        Me.Job_DetailsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.Job_DetailsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'Job_IDLabel
        '
        Job_IDLabel.AutoSize = True
        Job_IDLabel.Location = New System.Drawing.Point(60, 94)
        Job_IDLabel.Name = "Job_IDLabel"
        Job_IDLabel.Size = New System.Drawing.Size(79, 25)
        Job_IDLabel.TabIndex = 1
        Job_IDLabel.Text = "Job ID:"
        '
        'Job_IDTextBox
        '
        Me.Job_IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Job_DetailsBindingSource, "Job ID", True))
        Me.Job_IDTextBox.Location = New System.Drawing.Point(145, 91)
        Me.Job_IDTextBox.Name = "Job_IDTextBox"
        Me.Job_IDTextBox.Size = New System.Drawing.Size(100, 31)
        Me.Job_IDTextBox.TabIndex = 2
        '
        'frmJobDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1779, 873)
        Me.Controls.Add(Job_IDLabel)
        Me.Controls.Add(Me.Job_IDTextBox)
        Me.Controls.Add(Me.Job_DetailsBindingNavigator)
        Me.Name = "frmJobDetails"
        Me.Text = "Job Details"
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Job_DetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Job_DetailsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Job_DetailsBindingNavigator.ResumeLayout(False)
        Me.Job_DetailsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HaleMRIDataSet As HaleMRIDataSet
    Friend WithEvents Job_DetailsBindingSource As BindingSource
    Friend WithEvents Job_DetailsTableAdapter As HaleMRIDataSetTableAdapters.Job_DetailsTableAdapter
    Friend WithEvents TableAdapterManager As HaleMRIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Job_DetailsBindingNavigator As BindingNavigator
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
    Friend WithEvents Job_DetailsBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents Job_IDTextBox As TextBox
End Class
