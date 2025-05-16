<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobs))
        Dim Job_NumberLabel As System.Windows.Forms.Label
        Me.HaleMRIDataSet = New Hale_MRI.HaleMRIDataSet()
        Me.JobsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.JobsTableAdapter = New Hale_MRI.HaleMRIDataSetTableAdapters.JobsTableAdapter()
        Me.TableAdapterManager = New Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager()
        Me.JobsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.JobsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Job_NumberTextBox = New System.Windows.Forms.TextBox()
        Job_NumberLabel = New System.Windows.Forms.Label()
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.JobsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'HaleMRIDataSet
        '
        Me.HaleMRIDataSet.DataSetName = "HaleMRIDataSet"
        Me.HaleMRIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'JobsBindingSource
        '
        Me.JobsBindingSource.DataMember = "Jobs"
        Me.JobsBindingSource.DataSource = Me.HaleMRIDataSet
        '
        'JobsTableAdapter
        '
        Me.JobsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Cell_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.Job_DetailsTableAdapter = Nothing
        Me.TableAdapterManager.JobsTableAdapter = Me.JobsTableAdapter
        Me.TableAdapterManager.ManufacturersTableAdapter = Nothing
        Me.TableAdapterManager.PropellersTableAdapter = Nothing
        Me.TableAdapterManager.Radius_MeasurementsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Hale_MRI.HaleMRIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VesselsTableAdapter = Nothing
        '
        'JobsBindingNavigator
        '
        Me.JobsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.JobsBindingNavigator.BindingSource = Me.JobsBindingSource
        Me.JobsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.JobsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.JobsBindingNavigator.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.JobsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.JobsBindingNavigatorSaveItem})
        Me.JobsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.JobsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.JobsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.JobsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.JobsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.JobsBindingNavigator.Name = "JobsBindingNavigator"
        Me.JobsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.JobsBindingNavigator.Size = New System.Drawing.Size(1939, 50)
        Me.JobsBindingNavigator.TabIndex = 0
        Me.JobsBindingNavigator.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(70, 36)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(46, 36)
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
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 42)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 39)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 42)
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
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'JobsBindingNavigatorSaveItem
        '
        Me.JobsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.JobsBindingNavigatorSaveItem.Image = CType(resources.GetObject("JobsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.JobsBindingNavigatorSaveItem.Name = "JobsBindingNavigatorSaveItem"
        Me.JobsBindingNavigatorSaveItem.Size = New System.Drawing.Size(46, 36)
        Me.JobsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'Job_NumberLabel
        '
        Job_NumberLabel.AutoSize = True
        Job_NumberLabel.Location = New System.Drawing.Point(59, 103)
        Job_NumberLabel.Name = "Job_NumberLabel"
        Job_NumberLabel.Size = New System.Drawing.Size(134, 25)
        Job_NumberLabel.TabIndex = 1
        Job_NumberLabel.Text = "Job Number:"
        '
        'Job_NumberTextBox
        '
        Me.Job_NumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.JobsBindingSource, "Job Number", True))
        Me.Job_NumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Job_NumberTextBox.Location = New System.Drawing.Point(272, 100)
        Me.Job_NumberTextBox.Name = "Job_NumberTextBox"
        Me.Job_NumberTextBox.Size = New System.Drawing.Size(253, 31)
        Me.Job_NumberTextBox.TabIndex = 2
        '
        'frmJobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1939, 986)
        Me.Controls.Add(Job_NumberLabel)
        Me.Controls.Add(Me.Job_NumberTextBox)
        Me.Controls.Add(Me.JobsBindingNavigator)
        Me.Name = "frmJobs"
        Me.Text = "Jobs"
        CType(Me.HaleMRIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.JobsBindingNavigator.ResumeLayout(False)
        Me.JobsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HaleMRIDataSet As HaleMRIDataSet
    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents JobsTableAdapter As HaleMRIDataSetTableAdapters.JobsTableAdapter
    Friend WithEvents TableAdapterManager As HaleMRIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents JobsBindingNavigator As BindingNavigator
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
    Friend WithEvents JobsBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents Job_NumberTextBox As TextBox
End Class
