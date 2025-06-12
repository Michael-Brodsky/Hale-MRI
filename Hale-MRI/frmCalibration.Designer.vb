<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalibration
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalibration))
        txtAngleCalibration = New TextBox()
        labAngleCalibration = New Label()
        cmdAngleCalibration = New Button()
        cmdRadiusCalibration = New Button()
        labRadiusCalibration = New Label()
        txtRadiusCalibration = New TextBox()
        cmdDepthCalibration = New Button()
        labDepthCalibration = New Label()
        txtDepthCalibration = New TextBox()
        labRadiusOffsetR = New Label()
        txtRadiusOffsetR = New TextBox()
        StatusStrip1 = New StatusStrip()
        WorkstationLabel = New ToolStripStatusLabel()
        EncodersSplitButton = New ToolStripSplitButton()
        InitializeToolStripMenuItem = New ToolStripMenuItem()
        ResetAngleToolStripMenuItem = New ToolStripMenuItem()
        ResetDepthToolStripMenuItem = New ToolStripMenuItem()
        ResetRadiusToolStripMenuItem = New ToolStripMenuItem()
        StatusLabel = New ToolStripStatusLabel()
        cmdSaveCalibration = New Button()
        cmdCancelCalibration = New Button()
        txtCalibrationFile = New TextBox()
        labCalibrationFile = New Label()
        cmdImportCalibration = New Button()
        cmdExportCalibration = New Button()
        chkCalibrateAll = New CheckBox()
        labRadiusOffsetL = New Label()
        txtRadiusOffsetL = New TextBox()
        labScanIncrement = New Label()
        txtScanIncrement = New TextBox()
        labHalfProbeDiameter = New Label()
        txtHalfProbeDiameter = New TextBox()
        labFixedOffset = New Label()
        txtFixedOffset = New TextBox()
        labRadiusResolution = New Label()
        txtRadiusResolution = New TextBox()
        labDepthResolution = New Label()
        txtDepthResolution = New TextBox()
        Label7 = New Label()
        txtAngleResolution = New TextBox()
        cmdCalibrationFile = New Button()
        cmdZeroCalibration = New Button()
        cmdDefaultCalibration = New Button()
        timerCalibration = New Timer(components)
        ToolTipSave = New ToolTip(components)
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtAngleCalibration
        ' 
        txtAngleCalibration.Location = New Point(261, 268)
        txtAngleCalibration.Name = "txtAngleCalibration"
        txtAngleCalibration.ReadOnly = True
        txtAngleCalibration.Size = New Size(346, 39)
        txtAngleCalibration.TabIndex = 0
        ' 
        ' labAngleCalibration
        ' 
        labAngleCalibration.AutoSize = True
        labAngleCalibration.Location = New Point(31, 268)
        labAngleCalibration.Name = "labAngleCalibration"
        labAngleCalibration.Size = New Size(198, 32)
        labAngleCalibration.TabIndex = 1
        labAngleCalibration.Text = "Angle Calibration"
        ' 
        ' cmdAngleCalibration
        ' 
        cmdAngleCalibration.Enabled = False
        cmdAngleCalibration.Location = New Point(640, 269)
        cmdAngleCalibration.Name = "cmdAngleCalibration"
        cmdAngleCalibration.Size = New Size(152, 39)
        cmdAngleCalibration.TabIndex = 2
        cmdAngleCalibration.Text = "Calibrate"
        ToolTipSave.SetToolTip(cmdAngleCalibration, "Calibrate Angle Encoder")
        cmdAngleCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdRadiusCalibration
        ' 
        cmdRadiusCalibration.Enabled = False
        cmdRadiusCalibration.Location = New Point(640, 359)
        cmdRadiusCalibration.Name = "cmdRadiusCalibration"
        cmdRadiusCalibration.Size = New Size(152, 39)
        cmdRadiusCalibration.TabIndex = 5
        cmdRadiusCalibration.Text = "Calibrate"
        ToolTipSave.SetToolTip(cmdRadiusCalibration, "Calibrate Radius Encoder")
        cmdRadiusCalibration.UseVisualStyleBackColor = True
        ' 
        ' labRadiusCalibration
        ' 
        labRadiusCalibration.AutoSize = True
        labRadiusCalibration.Location = New Point(31, 358)
        labRadiusCalibration.Name = "labRadiusCalibration"
        labRadiusCalibration.Size = New Size(206, 32)
        labRadiusCalibration.TabIndex = 4
        labRadiusCalibration.Text = "Radius Calibration"
        ' 
        ' txtRadiusCalibration
        ' 
        txtRadiusCalibration.Location = New Point(261, 358)
        txtRadiusCalibration.Name = "txtRadiusCalibration"
        txtRadiusCalibration.ReadOnly = True
        txtRadiusCalibration.Size = New Size(346, 39)
        txtRadiusCalibration.TabIndex = 3
        ' 
        ' cmdDepthCalibration
        ' 
        cmdDepthCalibration.Enabled = False
        cmdDepthCalibration.Location = New Point(640, 314)
        cmdDepthCalibration.Name = "cmdDepthCalibration"
        cmdDepthCalibration.Size = New Size(152, 39)
        cmdDepthCalibration.TabIndex = 8
        cmdDepthCalibration.Text = "Calibrate"
        ToolTipSave.SetToolTip(cmdDepthCalibration, "Calibrate Depth Encoder")
        cmdDepthCalibration.UseVisualStyleBackColor = True
        ' 
        ' labDepthCalibration
        ' 
        labDepthCalibration.AutoSize = True
        labDepthCalibration.Location = New Point(31, 313)
        labDepthCalibration.Name = "labDepthCalibration"
        labDepthCalibration.Size = New Size(202, 32)
        labDepthCalibration.TabIndex = 7
        labDepthCalibration.Text = "Depth Calibration"
        ' 
        ' txtDepthCalibration
        ' 
        txtDepthCalibration.Location = New Point(261, 313)
        txtDepthCalibration.Name = "txtDepthCalibration"
        txtDepthCalibration.ReadOnly = True
        txtDepthCalibration.Size = New Size(346, 39)
        txtDepthCalibration.TabIndex = 6
        ' 
        ' labRadiusOffsetR
        ' 
        labRadiusOffsetR.AutoSize = True
        labRadiusOffsetR.Location = New Point(31, 583)
        labRadiusOffsetR.Name = "labRadiusOffsetR"
        labRadiusOffsetR.Size = New Size(177, 32)
        labRadiusOffsetR.TabIndex = 10
        labRadiusOffsetR.Text = "Radius Offset R"
        ' 
        ' txtRadiusOffsetR
        ' 
        txtRadiusOffsetR.Location = New Point(261, 583)
        txtRadiusOffsetR.Name = "txtRadiusOffsetR"
        txtRadiusOffsetR.Size = New Size(346, 39)
        txtRadiusOffsetR.TabIndex = 9
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {WorkstationLabel, EncodersSplitButton, StatusLabel})
        StatusStrip1.Location = New Point(0, 910)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(2089, 42)
        StatusStrip1.TabIndex = 11
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
        EncodersSplitButton.Image = CType(resources.GetObject("EncodersSplitButton.Image"), Image)
        EncodersSplitButton.ImageTransparentColor = Color.Magenta
        EncodersSplitButton.Margin = New Padding(0, 4, 10, 0)
        EncodersSplitButton.Name = "EncodersSplitButton"
        EncodersSplitButton.Size = New Size(59, 38)
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
        ' cmdSaveCalibration
        ' 
        cmdSaveCalibration.Enabled = False
        cmdSaveCalibration.Image = CType(resources.GetObject("cmdSaveCalibration.Image"), Image)
        cmdSaveCalibration.Location = New Point(31, 833)
        cmdSaveCalibration.Name = "cmdSaveCalibration"
        cmdSaveCalibration.Size = New Size(134, 45)
        cmdSaveCalibration.TabIndex = 12
        ToolTipSave.SetToolTip(cmdSaveCalibration, "Save Changes")
        cmdSaveCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdCancelCalibration
        ' 
        cmdCancelCalibration.Enabled = False
        cmdCancelCalibration.Image = CType(resources.GetObject("cmdCancelCalibration.Image"), Image)
        cmdCancelCalibration.Location = New Point(171, 833)
        cmdCancelCalibration.Name = "cmdCancelCalibration"
        cmdCancelCalibration.Size = New Size(134, 45)
        cmdCancelCalibration.TabIndex = 13
        ToolTipSave.SetToolTip(cmdCancelCalibration, "Cancel Changes")
        cmdCancelCalibration.UseVisualStyleBackColor = True
        ' 
        ' txtCalibrationFile
        ' 
        txtCalibrationFile.Location = New Point(261, 42)
        txtCalibrationFile.Name = "txtCalibrationFile"
        txtCalibrationFile.Size = New Size(1104, 39)
        txtCalibrationFile.TabIndex = 14
        ' 
        ' labCalibrationFile
        ' 
        labCalibrationFile.AutoSize = True
        labCalibrationFile.Location = New Point(31, 49)
        labCalibrationFile.Name = "labCalibrationFile"
        labCalibrationFile.Size = New Size(173, 32)
        labCalibrationFile.TabIndex = 15
        labCalibrationFile.Text = "Calibration File"
        ' 
        ' cmdImportCalibration
        ' 
        cmdImportCalibration.Enabled = False
        cmdImportCalibration.Image = CType(resources.GetObject("cmdImportCalibration.Image"), Image)
        cmdImportCalibration.Location = New Point(31, 112)
        cmdImportCalibration.Name = "cmdImportCalibration"
        cmdImportCalibration.Size = New Size(134, 45)
        cmdImportCalibration.TabIndex = 16
        ToolTipSave.SetToolTip(cmdImportCalibration, "Import Calibration From File")
        cmdImportCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdExportCalibration
        ' 
        cmdExportCalibration.Enabled = False
        cmdExportCalibration.Image = CType(resources.GetObject("cmdExportCalibration.Image"), Image)
        cmdExportCalibration.Location = New Point(171, 112)
        cmdExportCalibration.Name = "cmdExportCalibration"
        cmdExportCalibration.Size = New Size(134, 45)
        cmdExportCalibration.TabIndex = 17
        ToolTipSave.SetToolTip(cmdExportCalibration, "Export Calibration To File")
        cmdExportCalibration.UseVisualStyleBackColor = True
        ' 
        ' chkCalibrateAll
        ' 
        chkCalibrateAll.Appearance = Appearance.Button
        chkCalibrateAll.Enabled = False
        chkCalibrateAll.Image = CType(resources.GetObject("chkCalibrateAll.Image"), Image)
        chkCalibrateAll.ImageAlign = ContentAlignment.MiddleRight
        chkCalibrateAll.Location = New Point(640, 221)
        chkCalibrateAll.Name = "chkCalibrateAll"
        chkCalibrateAll.Size = New Size(152, 42)
        chkCalibrateAll.TabIndex = 18
        chkCalibrateAll.Text = "    Cal All"
        ToolTipSave.SetToolTip(chkCalibrateAll, "Calibrate All Encoders Continuously")
        chkCalibrateAll.UseVisualStyleBackColor = True
        ' 
        ' labRadiusOffsetL
        ' 
        labRadiusOffsetL.AutoSize = True
        labRadiusOffsetL.Location = New Point(31, 628)
        labRadiusOffsetL.Name = "labRadiusOffsetL"
        labRadiusOffsetL.Size = New Size(174, 32)
        labRadiusOffsetL.TabIndex = 20
        labRadiusOffsetL.Text = "Radius Offset L"
        ' 
        ' txtRadiusOffsetL
        ' 
        txtRadiusOffsetL.Location = New Point(261, 628)
        txtRadiusOffsetL.Name = "txtRadiusOffsetL"
        txtRadiusOffsetL.Size = New Size(346, 39)
        txtRadiusOffsetL.TabIndex = 19
        ' 
        ' labScanIncrement
        ' 
        labScanIncrement.AutoSize = True
        labScanIncrement.Location = New Point(31, 718)
        labScanIncrement.Name = "labScanIncrement"
        labScanIncrement.Size = New Size(179, 32)
        labScanIncrement.TabIndex = 24
        labScanIncrement.Text = "Scan Increment"
        ' 
        ' txtScanIncrement
        ' 
        txtScanIncrement.Location = New Point(261, 718)
        txtScanIncrement.Name = "txtScanIncrement"
        txtScanIncrement.Size = New Size(346, 39)
        txtScanIncrement.TabIndex = 23
        ' 
        ' labHalfProbeDiameter
        ' 
        labHalfProbeDiameter.AutoSize = True
        labHalfProbeDiameter.Location = New Point(31, 673)
        labHalfProbeDiameter.Name = "labHalfProbeDiameter"
        labHalfProbeDiameter.Size = New Size(189, 32)
        labHalfProbeDiameter.TabIndex = 22
        labHalfProbeDiameter.Text = "Half Probe Diam"
        ' 
        ' txtHalfProbeDiameter
        ' 
        txtHalfProbeDiameter.Location = New Point(261, 673)
        txtHalfProbeDiameter.Name = "txtHalfProbeDiameter"
        txtHalfProbeDiameter.Size = New Size(346, 39)
        txtHalfProbeDiameter.TabIndex = 21
        ' 
        ' labFixedOffset
        ' 
        labFixedOffset.AutoSize = True
        labFixedOffset.Location = New Point(31, 763)
        labFixedOffset.Name = "labFixedOffset"
        labFixedOffset.Size = New Size(142, 32)
        labFixedOffset.TabIndex = 26
        labFixedOffset.Text = "Fixed Offset"
        ' 
        ' txtFixedOffset
        ' 
        txtFixedOffset.Location = New Point(261, 763)
        txtFixedOffset.Name = "txtFixedOffset"
        txtFixedOffset.Size = New Size(346, 39)
        txtFixedOffset.TabIndex = 25
        ' 
        ' labRadiusResolution
        ' 
        labRadiusResolution.AutoSize = True
        labRadiusResolution.Location = New Point(31, 538)
        labRadiusResolution.Name = "labRadiusResolution"
        labRadiusResolution.Size = New Size(203, 32)
        labRadiusResolution.TabIndex = 32
        labRadiusResolution.Text = "Radius Resolution"
        ' 
        ' txtRadiusResolution
        ' 
        txtRadiusResolution.Location = New Point(261, 538)
        txtRadiusResolution.Name = "txtRadiusResolution"
        txtRadiusResolution.Size = New Size(346, 39)
        txtRadiusResolution.TabIndex = 31
        ' 
        ' labDepthResolution
        ' 
        labDepthResolution.AutoSize = True
        labDepthResolution.Location = New Point(31, 493)
        labDepthResolution.Name = "labDepthResolution"
        labDepthResolution.Size = New Size(199, 32)
        labDepthResolution.TabIndex = 30
        labDepthResolution.Text = "Depth Resolution"
        ' 
        ' txtDepthResolution
        ' 
        txtDepthResolution.Location = New Point(261, 493)
        txtDepthResolution.Name = "txtDepthResolution"
        txtDepthResolution.Size = New Size(346, 39)
        txtDepthResolution.TabIndex = 29
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(31, 448)
        Label7.Name = "Label7"
        Label7.Size = New Size(195, 32)
        Label7.TabIndex = 28
        Label7.Text = "Angle Resolution"
        ' 
        ' txtAngleResolution
        ' 
        txtAngleResolution.Location = New Point(261, 448)
        txtAngleResolution.Name = "txtAngleResolution"
        txtAngleResolution.Size = New Size(346, 39)
        txtAngleResolution.TabIndex = 27
        ' 
        ' cmdCalibrationFile
        ' 
        cmdCalibrationFile.Image = CType(resources.GetObject("cmdCalibrationFile.Image"), Image)
        cmdCalibrationFile.Location = New Point(1375, 42)
        cmdCalibrationFile.Name = "cmdCalibrationFile"
        cmdCalibrationFile.Size = New Size(65, 38)
        cmdCalibrationFile.TabIndex = 33
        ToolTipSave.SetToolTip(cmdCalibrationFile, "Select Calibration File")
        cmdCalibrationFile.UseVisualStyleBackColor = True
        ' 
        ' cmdZeroCalibration
        ' 
        cmdZeroCalibration.Enabled = False
        cmdZeroCalibration.Location = New Point(640, 404)
        cmdZeroCalibration.Name = "cmdZeroCalibration"
        cmdZeroCalibration.Size = New Size(152, 39)
        cmdZeroCalibration.TabIndex = 34
        cmdZeroCalibration.Text = "Zero"
        ToolTipSave.SetToolTip(cmdZeroCalibration, "Zero Calibration")
        cmdZeroCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdDefaultCalibration
        ' 
        cmdDefaultCalibration.Location = New Point(640, 449)
        cmdDefaultCalibration.Name = "cmdDefaultCalibration"
        cmdDefaultCalibration.Size = New Size(152, 39)
        cmdDefaultCalibration.TabIndex = 35
        cmdDefaultCalibration.Text = "Default"
        ToolTipSave.SetToolTip(cmdDefaultCalibration, "Load Default Calibration")
        cmdDefaultCalibration.UseVisualStyleBackColor = True
        ' 
        ' timerCalibration
        ' 
        timerCalibration.Interval = 200
        ' 
        ' FrmCalibration
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2089, 952)
        Controls.Add(cmdDefaultCalibration)
        Controls.Add(cmdZeroCalibration)
        Controls.Add(cmdCalibrationFile)
        Controls.Add(labRadiusResolution)
        Controls.Add(txtRadiusResolution)
        Controls.Add(labDepthResolution)
        Controls.Add(txtDepthResolution)
        Controls.Add(Label7)
        Controls.Add(txtAngleResolution)
        Controls.Add(labFixedOffset)
        Controls.Add(txtFixedOffset)
        Controls.Add(labScanIncrement)
        Controls.Add(txtScanIncrement)
        Controls.Add(labHalfProbeDiameter)
        Controls.Add(txtHalfProbeDiameter)
        Controls.Add(labRadiusOffsetL)
        Controls.Add(txtRadiusOffsetL)
        Controls.Add(chkCalibrateAll)
        Controls.Add(cmdExportCalibration)
        Controls.Add(cmdImportCalibration)
        Controls.Add(labCalibrationFile)
        Controls.Add(txtCalibrationFile)
        Controls.Add(cmdCancelCalibration)
        Controls.Add(cmdSaveCalibration)
        Controls.Add(StatusStrip1)
        Controls.Add(labRadiusOffsetR)
        Controls.Add(txtRadiusOffsetR)
        Controls.Add(cmdDepthCalibration)
        Controls.Add(labDepthCalibration)
        Controls.Add(txtDepthCalibration)
        Controls.Add(cmdRadiusCalibration)
        Controls.Add(labRadiusCalibration)
        Controls.Add(txtRadiusCalibration)
        Controls.Add(cmdAngleCalibration)
        Controls.Add(labAngleCalibration)
        Controls.Add(txtAngleCalibration)
        Name = "FrmCalibration"
        Text = "Encoder Calibration"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtAngleCalibration As TextBox
    Friend WithEvents labAngleCalibration As Label
    Friend WithEvents cmdAngleCalibration As Button
    Friend WithEvents cmdRadiusCalibration As Button
    Friend WithEvents labRadiusCalibration As Label
    Friend WithEvents txtRadiusCalibration As TextBox
    Friend WithEvents cmdDepthCalibration As Button
    Friend WithEvents labDepthCalibration As Label
    Friend WithEvents txtDepthCalibration As TextBox
    Friend WithEvents labRadiusOffsetR As Label
    Friend WithEvents txtRadiusOffsetR As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents WorkstationLabel As ToolStripStatusLabel
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents EncodersSplitButton As ToolStripSplitButton
    Friend WithEvents InitializeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetAngleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmdSaveCalibration As Button
    Friend WithEvents cmdCancelCalibration As Button
    Friend WithEvents txtCalibrationFile As TextBox
    Friend WithEvents labCalibrationFile As Label
    Friend WithEvents cmdImportCalibration As Button
    Friend WithEvents cmdExportCalibration As Button
    Friend WithEvents chkCalibrateAll As CheckBox
    Friend WithEvents labRadiusOffsetL As Label
    Friend WithEvents txtRadiusOffsetL As TextBox
    Friend WithEvents labScanIncrement As Label
    Friend WithEvents txtScanIncrement As TextBox
    Friend WithEvents labHalfProbeDiameter As Label
    Friend WithEvents txtHalfProbeDiameter As TextBox
    Friend WithEvents labFixedOffset As Label
    Friend WithEvents txtFixedOffset As TextBox
    Friend WithEvents labRadiusResolution As Label
    Friend WithEvents txtRadiusResolution As TextBox
    Friend WithEvents labDepthResolution As Label
    Friend WithEvents txtDepthResolution As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAngleResolution As TextBox
    Friend WithEvents cmdCalibrationFile As Button
    Friend WithEvents cmdZeroCalibration As Button
    Friend WithEvents cmdDefaultCalibration As Button
    Friend WithEvents timerCalibration As Timer
    Friend WithEvents ToolTipSave As ToolTip
    Friend WithEvents ResetDepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetRadiusToolStripMenuItem As ToolStripMenuItem
End Class
