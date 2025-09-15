<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncoderStatusStrip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EncoderStatusStrip))
        StatusStrip1 = New StatusStrip()
        TSLabelWorkstationName = New ToolStripStatusLabel()
        TSButtonEncoders = New ToolStripSplitButton()
        InitializeToolStripMenuItem = New ToolStripMenuItem()
        ResetToolStripMenuItem = New ToolStripMenuItem()
        AngleToolStripMenuItem = New ToolStripMenuItem()
        DepthToolStripMenuItem = New ToolStripMenuItem()
        RadiusToolStripMenuItem = New ToolStripMenuItem()
        AllToolStripMenuItem = New ToolStripMenuItem()
        TSLabelEncodersStatus = New ToolStripStatusLabel()
        TSButtonTimer = New ToolStripSplitButton()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.AutoSize = False
        StatusStrip1.Items.AddRange(New ToolStripItem() {TSLabelWorkstationName, TSButtonEncoders, TSLabelEncodersStatus, TSButtonTimer})
        StatusStrip1.Location = New Point(0, 1)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1145, 22)
        StatusStrip1.TabIndex = 0
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' TSLabelWorkstationName
        ' 
        TSLabelWorkstationName.Margin = New Padding(10, 3, 0, 2)
        TSLabelWorkstationName.Name = "TSLabelWorkstationName"
        TSLabelWorkstationName.Size = New Size(106, 17)
        TSLabelWorkstationName.Text = "Workstation Name"
        ' 
        ' TSButtonEncoders
        ' 
        TSButtonEncoders.DisplayStyle = ToolStripItemDisplayStyle.Image
        TSButtonEncoders.DropDownItems.AddRange(New ToolStripItem() {InitializeToolStripMenuItem, ResetToolStripMenuItem})
        TSButtonEncoders.Image = CType(resources.GetObject("TSButtonEncoders.Image"), Image)
        TSButtonEncoders.ImageTransparentColor = Color.Magenta
        TSButtonEncoders.Margin = New Padding(10, 2, 10, 0)
        TSButtonEncoders.Name = "TSButtonEncoders"
        TSButtonEncoders.Size = New Size(32, 20)
        TSButtonEncoders.Text = "ToolStripSplitButton1"
        ' 
        ' InitializeToolStripMenuItem
        ' 
        InitializeToolStripMenuItem.Name = "InitializeToolStripMenuItem"
        InitializeToolStripMenuItem.Size = New Size(180, 22)
        InitializeToolStripMenuItem.Text = "Initialize"
        ' 
        ' ResetToolStripMenuItem
        ' 
        ResetToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AngleToolStripMenuItem, DepthToolStripMenuItem, RadiusToolStripMenuItem, AllToolStripMenuItem})
        ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        ResetToolStripMenuItem.Size = New Size(180, 22)
        ResetToolStripMenuItem.Text = "Reset"
        ' 
        ' AngleToolStripMenuItem
        ' 
        AngleToolStripMenuItem.Name = "AngleToolStripMenuItem"
        AngleToolStripMenuItem.Size = New Size(109, 22)
        AngleToolStripMenuItem.Text = "Angle"
        ' 
        ' DepthToolStripMenuItem
        ' 
        DepthToolStripMenuItem.Name = "DepthToolStripMenuItem"
        DepthToolStripMenuItem.Size = New Size(109, 22)
        DepthToolStripMenuItem.Text = "Depth"
        ' 
        ' RadiusToolStripMenuItem
        ' 
        RadiusToolStripMenuItem.Name = "RadiusToolStripMenuItem"
        RadiusToolStripMenuItem.Size = New Size(109, 22)
        RadiusToolStripMenuItem.Text = "Radius"
        ' 
        ' AllToolStripMenuItem
        ' 
        AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        AllToolStripMenuItem.Size = New Size(109, 22)
        AllToolStripMenuItem.Text = "All"
        ' 
        ' TSLabelEncodersStatus
        ' 
        TSLabelEncodersStatus.Name = "TSLabelEncodersStatus"
        TSLabelEncodersStatus.Size = New Size(90, 17)
        TSLabelEncodersStatus.Text = "Encoders Status"
        ' 
        ' TSButtonTimer
        ' 
        TSButtonTimer.DisplayStyle = ToolStripItemDisplayStyle.Image
        TSButtonTimer.Image = My.Resources.Resources.Timer
        TSButtonTimer.ImageTransparentColor = Color.Magenta
        TSButtonTimer.Margin = New Padding(10, 2, 10, 0)
        TSButtonTimer.Name = "TSButtonTimer"
        TSButtonTimer.Size = New Size(32, 20)
        TSButtonTimer.Text = "TSButtonTimer"
        ' 
        ' EncoderStatusStrip
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        Controls.Add(StatusStrip1)
        Name = "EncoderStatusStrip"
        Size = New Size(1145, 23)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TSLabelWorkstationName As ToolStripStatusLabel
    Friend WithEvents TSButtonEncoders As ToolStripSplitButton
    Friend WithEvents InitializeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AngleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RadiusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TSLabelEncodersStatus As ToolStripStatusLabel
    Friend WithEvents TSButtonTimer As ToolStripSplitButton

End Class
