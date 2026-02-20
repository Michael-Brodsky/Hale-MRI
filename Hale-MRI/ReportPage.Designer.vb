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
        Margins = New CustomPanel()
        SuspendLayout()
        ' 
        ' Margins
        ' 
        Margins.BorderColor = Color.Black
        Margins.BorderWidth = 1
        Margins.DashBorderStyle = Drawing2D.DashStyle.Dash
        Margins.DashPatternStyle = New Single() {3F, 1F}
        Margins.Location = New Point(16, 72)
        Margins.Name = "Margins"
        Margins.Size = New Size(200, 100)
        Margins.TabIndex = 0
        ' 
        ' ReportPage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        Controls.Add(Margins)
        Name = "ReportPage"
        Size = New Size(238, 234)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Margins As CustomPanel

End Class
