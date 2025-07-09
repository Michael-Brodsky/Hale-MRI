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
        tloCustomers = New TableLayoutPanel()
        SuspendLayout()
        ' 
        ' tloCustomers
        ' 
        tloCustomers.ColumnCount = 16
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.25F))
        tloCustomers.Dock = DockStyle.Fill
        tloCustomers.Location = New Point(0, 0)
        tloCustomers.Name = "tloCustomers"
        tloCustomers.RowCount = 9
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.RowStyles.Add(New RowStyle(SizeType.Percent, 11.1111107F))
        tloCustomers.Size = New Size(1264, 681)
        tloCustomers.TabIndex = 0
        ' 
        ' FrmCustomers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1264, 681)
        Controls.Add(tloCustomers)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmCustomers"
        Text = "Customers"
        ResumeLayout(False)
    End Sub

    Friend WithEvents tloCustomers As TableLayoutPanel
End Class
