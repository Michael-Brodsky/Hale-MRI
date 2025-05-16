<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHaleMRI
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
        Me.MenuHaleMRI = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VesselsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManufacturersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropellersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHaleMRI.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHaleMRI
        '
        Me.MenuHaleMRI.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuHaleMRI.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuHaleMRI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuHaleMRI.Location = New System.Drawing.Point(0, 0)
        Me.MenuHaleMRI.Name = "MenuHaleMRI"
        Me.MenuHaleMRI.Size = New System.Drawing.Size(1730, 40)
        Me.MenuHaleMRI.TabIndex = 0
        Me.MenuHaleMRI.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(71, 38)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 39)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(219, 44)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.ToolStripSeparator1, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(74, 38)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(286, 44)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(283, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(286, 44)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(286, 44)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(286, 44)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(286, 44)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomersToolStripMenuItem, Me.VesselsToolStripMenuItem, Me.JobsToolStripMenuItem, Me.ManufacturersToolStripMenuItem, Me.PropellersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(85, 38)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'CustomersToolStripMenuItem
        '
        Me.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem"
        Me.CustomersToolStripMenuItem.Size = New System.Drawing.Size(359, 44)
        Me.CustomersToolStripMenuItem.Text = "Customers"
        '
        'VesselsToolStripMenuItem
        '
        Me.VesselsToolStripMenuItem.Name = "VesselsToolStripMenuItem"
        Me.VesselsToolStripMenuItem.Size = New System.Drawing.Size(359, 44)
        Me.VesselsToolStripMenuItem.Text = "Vessels"
        '
        'JobsToolStripMenuItem
        '
        Me.JobsToolStripMenuItem.Name = "JobsToolStripMenuItem"
        Me.JobsToolStripMenuItem.Size = New System.Drawing.Size(359, 44)
        Me.JobsToolStripMenuItem.Text = "Jobs"
        '
        'ManufacturersToolStripMenuItem
        '
        Me.ManufacturersToolStripMenuItem.Name = "ManufacturersToolStripMenuItem"
        Me.ManufacturersToolStripMenuItem.Size = New System.Drawing.Size(359, 44)
        Me.ManufacturersToolStripMenuItem.Text = "Manufacturers"
        '
        'PropellersToolStripMenuItem
        '
        Me.PropellersToolStripMenuItem.Name = "PropellersToolStripMenuItem"
        Me.PropellersToolStripMenuItem.Size = New System.Drawing.Size(359, 44)
        Me.PropellersToolStripMenuItem.Text = "Propellers"
        '
        'frmHaleMRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1730, 921)
        Me.Controls.Add(Me.MenuHaleMRI)
        Me.MainMenuStrip = Me.MenuHaleMRI
        Me.Name = "frmHaleMRI"
        Me.Text = "Hale MRI"
        Me.MenuHaleMRI.ResumeLayout(False)
        Me.MenuHaleMRI.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHaleMRI As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VesselsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManufacturersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropellersToolStripMenuItem As ToolStripMenuItem
End Class
