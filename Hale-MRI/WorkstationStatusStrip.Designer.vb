<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkstationStatusStrip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkstationStatusStrip))
        StatusStrip1 = New StatusStrip()
        WorkstationNameLabel = New ToolStripStatusLabel()
        EncoderButton = New ToolStripSplitButton()
        EncoderInitializeMenuItem = New ToolStripMenuItem()
        EncoderAngleResetMenuItem = New ToolStripMenuItem()
        EncoderDepthResetMenuItem = New ToolStripMenuItem()
        EncoderRadiusResetMenuItem = New ToolStripMenuItem()
        EncoderStatusLabel = New ToolStripStatusLabel()
        OperationStatusLabel = New ToolStripStatusLabel()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {WorkstationNameLabel, EncoderButton, EncoderStatusLabel, OperationStatusLabel})
        StatusStrip1.Location = New Point(0, 108)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1642, 42)
        StatusStrip1.TabIndex = 0
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' WorkstationNameLabel
        ' 
        WorkstationNameLabel.Margin = New Padding(30, 6, 26, 4)
        WorkstationNameLabel.Name = "WorkstationNameLabel"
        WorkstationNameLabel.Size = New Size(261, 32)
        WorkstationNameLabel.Text = "WorkstationNameLabel"
        ' 
        ' EncoderButton
        ' 
        EncoderButton.DisplayStyle = ToolStripItemDisplayStyle.Image
        EncoderButton.DropDownItems.AddRange(New ToolStripItem() {EncoderInitializeMenuItem, EncoderAngleResetMenuItem, EncoderDepthResetMenuItem, EncoderRadiusResetMenuItem})
        EncoderButton.Image = CType(resources.GetObject("EncoderButton.Image"), Image)
        EncoderButton.ImageTransparentColor = Color.Magenta
        EncoderButton.Name = "EncoderButton"
        EncoderButton.Size = New Size(59, 38)
        EncoderButton.Text = "Encoders"
        ' 
        ' EncoderInitializeMenuItem
        ' 
        EncoderInitializeMenuItem.Name = "EncoderInitializeMenuItem"
        EncoderInitializeMenuItem.Size = New Size(281, 44)
        EncoderInitializeMenuItem.Text = "Initialize"
        ' 
        ' EncoderAngleResetMenuItem
        ' 
        EncoderAngleResetMenuItem.Name = "EncoderAngleResetMenuItem"
        EncoderAngleResetMenuItem.Size = New Size(281, 44)
        EncoderAngleResetMenuItem.Text = "Angle Reset"
        ' 
        ' EncoderDepthResetMenuItem
        ' 
        EncoderDepthResetMenuItem.Name = "EncoderDepthResetMenuItem"
        EncoderDepthResetMenuItem.Size = New Size(281, 44)
        EncoderDepthResetMenuItem.Text = "Depth Reset"
        ' 
        ' EncoderRadiusResetMenuItem
        ' 
        EncoderRadiusResetMenuItem.Name = "EncoderRadiusResetMenuItem"
        EncoderRadiusResetMenuItem.Size = New Size(281, 44)
        EncoderRadiusResetMenuItem.Text = "Radius Reset"
        ' 
        ' EncoderStatusLabel
        ' 
        EncoderStatusLabel.Name = "EncoderStatusLabel"
        EncoderStatusLabel.Size = New Size(220, 32)
        EncoderStatusLabel.Text = "EncoderStatusLabel"
        ' 
        ' OperationStatusLabel
        ' 
        OperationStatusLabel.Name = "OperationStatusLabel"
        OperationStatusLabel.Size = New Size(241, 32)
        OperationStatusLabel.Text = "OperationStatusLabel"
        ' 
        ' WorkstationStatusStrip
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(StatusStrip1)
        Name = "WorkstationStatusStrip"
        Size = New Size(1642, 150)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents WorkstationNameLabel As ToolStripStatusLabel
    Friend WithEvents EncoderButton As ToolStripSplitButton
    Friend WithEvents EncoderInitializeMenuItem As ToolStripMenuItem
    Friend WithEvents EncoderAngleResetMenuItem As ToolStripMenuItem
    Friend WithEvents EncoderDepthResetMenuItem As ToolStripMenuItem
    Friend WithEvents EncoderRadiusResetMenuItem As ToolStripMenuItem
    Friend WithEvents EncoderStatusLabel As ToolStripStatusLabel
    Friend WithEvents OperationStatusLabel As ToolStripStatusLabel

End Class
