<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPage
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        PageSeparator = New Panel()
        PrintableArea = New Panel()
        Margins = New CustomPanel()
        PrintableArea.SuspendLayout()
        SuspendLayout()
        ' 
        ' PageSeparator
        ' 
        PageSeparator.Dock = DockStyle.Bottom
        PageSeparator.Location = New Point(0, 214)
        PageSeparator.Name = "PageSeparator"
        PageSeparator.Size = New Size(238, 20)
        PageSeparator.TabIndex = 1
        ' 
        ' PrintableArea
        ' 
        PrintableArea.BorderStyle = BorderStyle.FixedSingle
        PrintableArea.Controls.Add(Margins)
        PrintableArea.Dock = DockStyle.Fill
        PrintableArea.Location = New Point(0, 0)
        PrintableArea.Name = "PrintableArea"
        PrintableArea.Size = New Size(238, 234)
        PrintableArea.TabIndex = 2
        ' 
        ' Margins
        ' 
        Margins.BackColor = SystemColors.Control
        Margins.BorderColor = Color.Silver
        Margins.BorderWidth = 1
        Margins.DashBorderStyle = Drawing2D.DashStyle.Dash
        Margins.DashPatternStyle = New Single() {3F, 1F}
        Margins.Location = New Point(15, 51)
        Margins.Name = "Margins"
        Margins.Size = New Size(200, 100)
        Margins.TabIndex = 0
        ' 
        ' ReportPage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        Controls.Add(PageSeparator)
        Controls.Add(PrintableArea)
        Name = "ReportPage"
        Size = New Size(238, 234)
        PrintableArea.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents PageSeparator As Panel
    Friend WithEvents PrintableArea As Panel
    Friend WithEvents Margins As CustomPanel

End Class
