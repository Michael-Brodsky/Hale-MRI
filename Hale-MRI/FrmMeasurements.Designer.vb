<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeasurements
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
        comboBlade = New ComboBox()
        Label1 = New Label()
        txtAngle = New TextBox()
        labAngle = New Label()
        labDepth = New Label()
        txtDepth = New TextBox()
        labRadius = New Label()
        txtRadius = New TextBox()
        labRadiusPercent = New Label()
        txtRadiusPercent = New TextBox()
        labDiameter = New Label()
        txtDiameter = New TextBox()
        labWheelPitch = New Label()
        txtWheelPitch = New TextBox()
        cmdAngle = New Button()
        cmdRadius = New Button()
        cmdDepth = New Button()
        cmdMeasureAll = New Button()
        cmdZero = New Button()
        StatusStrip1 = New StatusStrip()
        WorkstationLabel = New ToolStripStatusLabel()
        EncodersSplitButton = New ToolStripSplitButton()
        InitializeToolStripMenuItem = New ToolStripMenuItem()
        ResetAngleToolStripMenuItem = New ToolStripMenuItem()
        ResetDepthToolStripMenuItem = New ToolStripMenuItem()
        ResetRadiusToolStripMenuItem = New ToolStripMenuItem()
        StatusLabel = New ToolStripStatusLabel()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' comboBlade
        ' 
        comboBlade.FormattingEnabled = True
        comboBlade.Location = New Point(261, 103)
        comboBlade.Name = "comboBlade"
        comboBlade.Size = New Size(107, 40)
        comboBlade.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(31, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 32)
        Label1.TabIndex = 1
        Label1.Text = "Blade"
        ' 
        ' txtAngle
        ' 
        txtAngle.Location = New Point(263, 232)
        txtAngle.Name = "txtAngle"
        txtAngle.Size = New Size(346, 39)
        txtAngle.TabIndex = 2
        ' 
        ' labAngle
        ' 
        labAngle.AutoSize = True
        labAngle.Location = New Point(33, 239)
        labAngle.Name = "labAngle"
        labAngle.Size = New Size(76, 32)
        labAngle.TabIndex = 3
        labAngle.Text = "Angle"
        ' 
        ' labDepth
        ' 
        labDepth.AutoSize = True
        labDepth.Location = New Point(33, 284)
        labDepth.Name = "labDepth"
        labDepth.Size = New Size(80, 32)
        labDepth.TabIndex = 5
        labDepth.Text = "Depth"
        ' 
        ' txtDepth
        ' 
        txtDepth.Location = New Point(263, 277)
        txtDepth.Name = "txtDepth"
        txtDepth.Size = New Size(346, 39)
        txtDepth.TabIndex = 4
        ' 
        ' labRadius
        ' 
        labRadius.AutoSize = True
        labRadius.Location = New Point(33, 329)
        labRadius.Name = "labRadius"
        labRadius.Size = New Size(84, 32)
        labRadius.TabIndex = 7
        labRadius.Text = "Radius"
        ' 
        ' txtRadius
        ' 
        txtRadius.Location = New Point(263, 322)
        txtRadius.Name = "txtRadius"
        txtRadius.Size = New Size(346, 39)
        txtRadius.TabIndex = 6
        ' 
        ' labRadiusPercent
        ' 
        labRadiusPercent.AutoSize = True
        labRadiusPercent.Location = New Point(33, 424)
        labRadiusPercent.Name = "labRadiusPercent"
        labRadiusPercent.Size = New Size(170, 32)
        labRadiusPercent.TabIndex = 9
        labRadiusPercent.Text = "Radius Percent"
        ' 
        ' txtRadiusPercent
        ' 
        txtRadiusPercent.Location = New Point(263, 417)
        txtRadiusPercent.Name = "txtRadiusPercent"
        txtRadiusPercent.Size = New Size(346, 39)
        txtRadiusPercent.TabIndex = 8
        ' 
        ' labDiameter
        ' 
        labDiameter.AutoSize = True
        labDiameter.Location = New Point(33, 469)
        labDiameter.Name = "labDiameter"
        labDiameter.Size = New Size(112, 32)
        labDiameter.TabIndex = 11
        labDiameter.Text = "Diameter"
        ' 
        ' txtDiameter
        ' 
        txtDiameter.Location = New Point(263, 462)
        txtDiameter.Name = "txtDiameter"
        txtDiameter.Size = New Size(346, 39)
        txtDiameter.TabIndex = 10
        ' 
        ' labWheelPitch
        ' 
        labWheelPitch.AutoSize = True
        labWheelPitch.Location = New Point(33, 514)
        labWheelPitch.Name = "labWheelPitch"
        labWheelPitch.Size = New Size(141, 32)
        labWheelPitch.TabIndex = 13
        labWheelPitch.Text = "Wheel Pitch"
        ' 
        ' txtWheelPitch
        ' 
        txtWheelPitch.Location = New Point(263, 507)
        txtWheelPitch.Name = "txtWheelPitch"
        txtWheelPitch.Size = New Size(346, 39)
        txtWheelPitch.TabIndex = 12
        ' 
        ' cmdAngle
        ' 
        cmdAngle.Location = New Point(643, 231)
        cmdAngle.Name = "cmdAngle"
        cmdAngle.Size = New Size(152, 40)
        cmdAngle.TabIndex = 14
        cmdAngle.Text = "Measure"
        cmdAngle.UseVisualStyleBackColor = True
        ' 
        ' cmdRadius
        ' 
        cmdRadius.Location = New Point(643, 321)
        cmdRadius.Name = "cmdRadius"
        cmdRadius.Size = New Size(152, 40)
        cmdRadius.TabIndex = 15
        cmdRadius.Text = "Measure"
        cmdRadius.UseVisualStyleBackColor = True
        ' 
        ' cmdDepth
        ' 
        cmdDepth.Location = New Point(643, 276)
        cmdDepth.Name = "cmdDepth"
        cmdDepth.Size = New Size(152, 40)
        cmdDepth.TabIndex = 16
        cmdDepth.Text = "Measure"
        cmdDepth.UseVisualStyleBackColor = True
        ' 
        ' cmdMeasureAll
        ' 
        cmdMeasureAll.Location = New Point(643, 185)
        cmdMeasureAll.Name = "cmdMeasureAll"
        cmdMeasureAll.Size = New Size(152, 40)
        cmdMeasureAll.TabIndex = 17
        cmdMeasureAll.Text = "Meas All"
        cmdMeasureAll.UseVisualStyleBackColor = True
        ' 
        ' cmdZero
        ' 
        cmdZero.Location = New Point(643, 367)
        cmdZero.Name = "cmdZero"
        cmdZero.Size = New Size(152, 40)
        cmdZero.TabIndex = 18
        cmdZero.Text = "Zero"
        cmdZero.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {WorkstationLabel, EncodersSplitButton, StatusLabel})
        StatusStrip1.Location = New Point(0, 898)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1971, 42)
        StatusStrip1.TabIndex = 19
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' WorkstationLabel
        ' 
        WorkstationLabel.Margin = New Padding(29, 6, 26, 4)
        WorkstationLabel.Name = "WorkstationLabel"
        WorkstationLabel.Size = New Size(141, 32)
        WorkstationLabel.Text = "Workstation"
        WorkstationLabel.ToolTipText = "Workstation Name"
        ' 
        ' EncodersSplitButton
        ' 
        EncodersSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image
        EncodersSplitButton.DropDownItems.AddRange(New ToolStripItem() {InitializeToolStripMenuItem, ResetAngleToolStripMenuItem, ResetDepthToolStripMenuItem, ResetRadiusToolStripMenuItem})
        EncodersSplitButton.ImageTransparentColor = Color.Magenta
        EncodersSplitButton.Margin = New Padding(0, 4, 10, 0)
        EncodersSplitButton.Name = "EncodersSplitButton"
        EncodersSplitButton.Size = New Size(27, 38)
        EncodersSplitButton.Text = "Encoders"
        ' 
        ' InitializeToolStripMenuItem
        ' 
        InitializeToolStripMenuItem.Name = "InitializeToolStripMenuItem"
        InitializeToolStripMenuItem.Size = New Size(277, 44)
        InitializeToolStripMenuItem.Text = "Initialize"
        ' 
        ' ResetAngleToolStripMenuItem
        ' 
        ResetAngleToolStripMenuItem.Name = "ResetAngleToolStripMenuItem"
        ResetAngleToolStripMenuItem.Size = New Size(277, 44)
        ResetAngleToolStripMenuItem.Text = "Reset Angle"
        ' 
        ' ResetDepthToolStripMenuItem
        ' 
        ResetDepthToolStripMenuItem.Name = "ResetDepthToolStripMenuItem"
        ResetDepthToolStripMenuItem.Size = New Size(277, 44)
        ResetDepthToolStripMenuItem.Text = "Reset Depth"
        ' 
        ' ResetRadiusToolStripMenuItem
        ' 
        ResetRadiusToolStripMenuItem.Name = "ResetRadiusToolStripMenuItem"
        ResetRadiusToolStripMenuItem.Size = New Size(277, 44)
        ResetRadiusToolStripMenuItem.Text = "ResetRadius"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(78, 32)
        StatusLabel.Text = "Status"
        StatusLabel.ToolTipText = "Encoder Status"
        ' 
        ' FrmMeasurements
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1971, 940)
        Controls.Add(StatusStrip1)
        Controls.Add(cmdZero)
        Controls.Add(cmdMeasureAll)
        Controls.Add(cmdDepth)
        Controls.Add(cmdRadius)
        Controls.Add(cmdAngle)
        Controls.Add(labWheelPitch)
        Controls.Add(txtWheelPitch)
        Controls.Add(labDiameter)
        Controls.Add(txtDiameter)
        Controls.Add(labRadiusPercent)
        Controls.Add(txtRadiusPercent)
        Controls.Add(labRadius)
        Controls.Add(txtRadius)
        Controls.Add(labDepth)
        Controls.Add(txtDepth)
        Controls.Add(labAngle)
        Controls.Add(txtAngle)
        Controls.Add(Label1)
        Controls.Add(comboBlade)
        Name = "FrmMeasurements"
        Text = "Measurements"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents comboBlade As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAngle As TextBox
    Friend WithEvents labAngle As Label
    Friend WithEvents labDepth As Label
    Friend WithEvents txtDepth As TextBox
    Friend WithEvents labRadius As Label
    Friend WithEvents txtRadius As TextBox
    Friend WithEvents labRadiusPercent As Label
    Friend WithEvents txtRadiusPercent As TextBox
    Friend WithEvents labDiameter As Label
    Friend WithEvents txtDiameter As TextBox
    Friend WithEvents labWheelPitch As Label
    Friend WithEvents txtWheelPitch As TextBox
    Friend WithEvents cmdAngle As Button
    Friend WithEvents cmdRadius As Button
    Friend WithEvents cmdDepth As Button
    Friend WithEvents cmdMeasureAll As Button
    Friend WithEvents cmdZero As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents WorkstationLabel As ToolStripStatusLabel
    Friend WithEvents EncodersSplitButton As ToolStripSplitButton
    Friend WithEvents InitializeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetAngleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetDepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetRadiusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusLabel As ToolStripStatusLabel
End Class
