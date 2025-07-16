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
        TxtRadiusOffsetR = New TextBox()
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
        TxtRadiusOffsetL = New TextBox()
        labScanIncrement = New Label()
        txtScanIncrement = New TextBox()
        labHalfProbeDiameter = New Label()
        txtHalfProbeDiameter = New TextBox()
        labFixedOffset = New Label()
        txtFixedOffset = New TextBox()
        labRadiusResolution = New Label()
        TxtRadiusResolution = New TextBox()
        labDepthResolution = New Label()
        Label7 = New Label()
        cmdCalibrationFile = New Button()
        cmdZeroCalibration = New Button()
        cmdDefaultCalibration = New Button()
        timerCalibration = New Timer(components)
        ToolTipSave = New ToolTip(components)
        TxtAngleResolution = New TextBox()
        TxtDepthResolution = New TextBox()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtAngleCalibration
        ' 
        txtAngleCalibration.Location = New Point(141, 126)
        txtAngleCalibration.Margin = New Padding(2, 1, 2, 1)
        txtAngleCalibration.Name = "txtAngleCalibration"
        txtAngleCalibration.ReadOnly = True
        txtAngleCalibration.Size = New Size(188, 23)
        txtAngleCalibration.TabIndex = 9
        ' 
        ' labAngleCalibration
        ' 
        labAngleCalibration.AutoSize = True
        labAngleCalibration.Location = New Point(17, 132)
        labAngleCalibration.Margin = New Padding(2, 0, 2, 0)
        labAngleCalibration.Name = "labAngleCalibration"
        labAngleCalibration.Size = New Size(99, 15)
        labAngleCalibration.TabIndex = 8
        labAngleCalibration.Text = "Angle Calibration"
        ' 
        ' cmdAngleCalibration
        ' 
        cmdAngleCalibration.Enabled = False
        cmdAngleCalibration.Image = My.Resources.Resources.Measure
        cmdAngleCalibration.Location = New Point(345, 128)
        cmdAngleCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdAngleCalibration.Name = "cmdAngleCalibration"
        cmdAngleCalibration.Size = New Size(82, 22)
        cmdAngleCalibration.TabIndex = 10
        cmdAngleCalibration.Text = "Calibrate"
        cmdAngleCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(cmdAngleCalibration, "Calibrate Angle Encoder")
        cmdAngleCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdRadiusCalibration
        ' 
        cmdRadiusCalibration.Enabled = False
        cmdRadiusCalibration.Image = My.Resources.Resources.Measure
        cmdRadiusCalibration.Location = New Point(345, 177)
        cmdRadiusCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdRadiusCalibration.Name = "cmdRadiusCalibration"
        cmdRadiusCalibration.Size = New Size(82, 22)
        cmdRadiusCalibration.TabIndex = 16
        cmdRadiusCalibration.Text = "Calibrate"
        cmdRadiusCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(cmdRadiusCalibration, "Calibrate Radius Encoder")
        cmdRadiusCalibration.UseVisualStyleBackColor = True
        ' 
        ' labRadiusCalibration
        ' 
        labRadiusCalibration.AutoSize = True
        labRadiusCalibration.Location = New Point(17, 181)
        labRadiusCalibration.Margin = New Padding(2, 0, 2, 0)
        labRadiusCalibration.Name = "labRadiusCalibration"
        labRadiusCalibration.Size = New Size(103, 15)
        labRadiusCalibration.TabIndex = 14
        labRadiusCalibration.Text = "Radius Calibration"
        ' 
        ' txtRadiusCalibration
        ' 
        txtRadiusCalibration.Location = New Point(141, 176)
        txtRadiusCalibration.Margin = New Padding(2, 1, 2, 1)
        txtRadiusCalibration.Name = "txtRadiusCalibration"
        txtRadiusCalibration.ReadOnly = True
        txtRadiusCalibration.Size = New Size(188, 23)
        txtRadiusCalibration.TabIndex = 15
        ' 
        ' cmdDepthCalibration
        ' 
        cmdDepthCalibration.Enabled = False
        cmdDepthCalibration.Image = My.Resources.Resources.Measure
        cmdDepthCalibration.Location = New Point(345, 152)
        cmdDepthCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdDepthCalibration.Name = "cmdDepthCalibration"
        cmdDepthCalibration.Size = New Size(82, 22)
        cmdDepthCalibration.TabIndex = 13
        cmdDepthCalibration.Text = "Calibrate"
        cmdDepthCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(cmdDepthCalibration, "Calibrate Depth Encoder")
        cmdDepthCalibration.UseVisualStyleBackColor = True
        ' 
        ' labDepthCalibration
        ' 
        labDepthCalibration.AutoSize = True
        labDepthCalibration.Location = New Point(17, 156)
        labDepthCalibration.Margin = New Padding(2, 0, 2, 0)
        labDepthCalibration.Name = "labDepthCalibration"
        labDepthCalibration.Size = New Size(100, 15)
        labDepthCalibration.TabIndex = 11
        labDepthCalibration.Text = "Depth Calibration"
        ' 
        ' txtDepthCalibration
        ' 
        txtDepthCalibration.Location = New Point(141, 151)
        txtDepthCalibration.Margin = New Padding(2, 1, 2, 1)
        txtDepthCalibration.Name = "txtDepthCalibration"
        txtDepthCalibration.ReadOnly = True
        txtDepthCalibration.Size = New Size(188, 23)
        txtDepthCalibration.TabIndex = 12
        ' 
        ' labRadiusOffsetR
        ' 
        labRadiusOffsetR.AutoSize = True
        labRadiusOffsetR.Location = New Point(17, 288)
        labRadiusOffsetR.Margin = New Padding(2, 0, 2, 0)
        labRadiusOffsetR.Name = "labRadiusOffsetR"
        labRadiusOffsetR.Size = New Size(87, 15)
        labRadiusOffsetR.TabIndex = 22
        labRadiusOffsetR.Text = "Radius Offset R"
        ' 
        ' TxtRadiusOffsetR
        ' 
        TxtRadiusOffsetR.Location = New Point(141, 285)
        TxtRadiusOffsetR.Margin = New Padding(2, 1, 2, 1)
        TxtRadiusOffsetR.Name = "TxtRadiusOffsetR"
        TxtRadiusOffsetR.Size = New Size(188, 23)
        TxtRadiusOffsetR.TabIndex = 23
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {WorkstationLabel, EncodersSplitButton, StatusLabel})
        StatusStrip1.Location = New Point(0, 475)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 8, 0)
        StatusStrip1.Size = New Size(795, 25)
        StatusStrip1.TabIndex = 33
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' WorkstationLabel
        ' 
        WorkstationLabel.Margin = New Padding(29, 6, 26, 4)
        WorkstationLabel.Name = "WorkstationLabel"
        WorkstationLabel.Size = New Size(71, 15)
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
        EncodersSplitButton.Size = New Size(16, 21)
        EncodersSplitButton.Text = "Encoders"
        ' 
        ' InitializeToolStripMenuItem
        ' 
        InitializeToolStripMenuItem.Name = "InitializeToolStripMenuItem"
        InitializeToolStripMenuItem.Size = New Size(137, 22)
        InitializeToolStripMenuItem.Text = "Initialize"
        ' 
        ' ResetAngleToolStripMenuItem
        ' 
        ResetAngleToolStripMenuItem.Name = "ResetAngleToolStripMenuItem"
        ResetAngleToolStripMenuItem.Size = New Size(137, 22)
        ResetAngleToolStripMenuItem.Text = "Reset Angle"
        ' 
        ' ResetDepthToolStripMenuItem
        ' 
        ResetDepthToolStripMenuItem.Name = "ResetDepthToolStripMenuItem"
        ResetDepthToolStripMenuItem.Size = New Size(137, 22)
        ResetDepthToolStripMenuItem.Text = "Reset Depth"
        ' 
        ' ResetRadiusToolStripMenuItem
        ' 
        ResetRadiusToolStripMenuItem.Name = "ResetRadiusToolStripMenuItem"
        ResetRadiusToolStripMenuItem.Size = New Size(137, 22)
        ResetRadiusToolStripMenuItem.Text = "ResetRadius"
        ' 
        ' StatusLabel
        ' 
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New Size(39, 20)
        StatusLabel.Text = "Status"
        StatusLabel.ToolTipText = "Encoder Status"
        ' 
        ' cmdSaveCalibration
        ' 
        cmdSaveCalibration.Enabled = False
        cmdSaveCalibration.Image = My.Resources.Resources.Save
        cmdSaveCalibration.Location = New Point(17, 432)
        cmdSaveCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdSaveCalibration.Name = "cmdSaveCalibration"
        cmdSaveCalibration.Size = New Size(72, 22)
        cmdSaveCalibration.TabIndex = 31
        ToolTipSave.SetToolTip(cmdSaveCalibration, "Save Changes")
        cmdSaveCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdCancelCalibration
        ' 
        cmdCancelCalibration.Enabled = False
        cmdCancelCalibration.Image = My.Resources.Resources.Cancel
        cmdCancelCalibration.Location = New Point(92, 432)
        cmdCancelCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdCancelCalibration.Name = "cmdCancelCalibration"
        cmdCancelCalibration.Size = New Size(72, 22)
        cmdCancelCalibration.TabIndex = 32
        ToolTipSave.SetToolTip(cmdCancelCalibration, "Cancel Changes")
        cmdCancelCalibration.UseVisualStyleBackColor = True
        ' 
        ' txtCalibrationFile
        ' 
        txtCalibrationFile.Location = New Point(141, 20)
        txtCalibrationFile.Margin = New Padding(2, 1, 2, 1)
        txtCalibrationFile.Name = "txtCalibrationFile"
        txtCalibrationFile.Size = New Size(596, 23)
        txtCalibrationFile.TabIndex = 1
        ' 
        ' labCalibrationFile
        ' 
        labCalibrationFile.AutoSize = True
        labCalibrationFile.Location = New Point(17, 23)
        labCalibrationFile.Margin = New Padding(2, 0, 2, 0)
        labCalibrationFile.Name = "labCalibrationFile"
        labCalibrationFile.Size = New Size(86, 15)
        labCalibrationFile.TabIndex = 0
        labCalibrationFile.Text = "Calibration File"
        ' 
        ' cmdImportCalibration
        ' 
        cmdImportCalibration.Enabled = False
        cmdImportCalibration.Image = My.Resources.Resources.Import
        cmdImportCalibration.Location = New Point(17, 52)
        cmdImportCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdImportCalibration.Name = "cmdImportCalibration"
        cmdImportCalibration.Size = New Size(72, 22)
        cmdImportCalibration.TabIndex = 3
        ToolTipSave.SetToolTip(cmdImportCalibration, "Import Calibration From File")
        cmdImportCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdExportCalibration
        ' 
        cmdExportCalibration.Enabled = False
        cmdExportCalibration.Image = My.Resources.Resources.Export
        cmdExportCalibration.Location = New Point(92, 52)
        cmdExportCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdExportCalibration.Name = "cmdExportCalibration"
        cmdExportCalibration.Size = New Size(72, 22)
        cmdExportCalibration.TabIndex = 4
        ToolTipSave.SetToolTip(cmdExportCalibration, "Export Calibration To File")
        cmdExportCalibration.UseVisualStyleBackColor = True
        ' 
        ' chkCalibrateAll
        ' 
        chkCalibrateAll.Appearance = Appearance.Button
        chkCalibrateAll.Enabled = False
        chkCalibrateAll.Image = My.Resources.Resources.Timer
        chkCalibrateAll.ImageAlign = ContentAlignment.MiddleRight
        chkCalibrateAll.Location = New Point(345, 104)
        chkCalibrateAll.Margin = New Padding(2, 1, 2, 1)
        chkCalibrateAll.Name = "chkCalibrateAll"
        chkCalibrateAll.Size = New Size(82, 23)
        chkCalibrateAll.TabIndex = 5
        chkCalibrateAll.Text = "    Cal All"
        chkCalibrateAll.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(chkCalibrateAll, "Calibrate All Encoders Continuously")
        chkCalibrateAll.UseVisualStyleBackColor = True
        ' 
        ' labRadiusOffsetL
        ' 
        labRadiusOffsetL.AutoSize = True
        labRadiusOffsetL.Location = New Point(18, 313)
        labRadiusOffsetL.Margin = New Padding(2, 0, 2, 0)
        labRadiusOffsetL.Name = "labRadiusOffsetL"
        labRadiusOffsetL.Size = New Size(86, 15)
        labRadiusOffsetL.TabIndex = 24
        labRadiusOffsetL.Text = "Radius Offset L"
        ' 
        ' TxtRadiusOffsetL
        ' 
        TxtRadiusOffsetL.Location = New Point(141, 310)
        TxtRadiusOffsetL.Margin = New Padding(2, 1, 2, 1)
        TxtRadiusOffsetL.Name = "TxtRadiusOffsetL"
        TxtRadiusOffsetL.Size = New Size(188, 23)
        TxtRadiusOffsetL.TabIndex = 25
        ' 
        ' labScanIncrement
        ' 
        labScanIncrement.AutoSize = True
        labScanIncrement.Location = New Point(18, 363)
        labScanIncrement.Margin = New Padding(2, 0, 2, 0)
        labScanIncrement.Name = "labScanIncrement"
        labScanIncrement.Size = New Size(89, 15)
        labScanIncrement.TabIndex = 27
        labScanIncrement.Text = "Scan Increment"
        ' 
        ' txtScanIncrement
        ' 
        txtScanIncrement.Location = New Point(141, 360)
        txtScanIncrement.Margin = New Padding(2, 1, 2, 1)
        txtScanIncrement.Name = "txtScanIncrement"
        txtScanIncrement.Size = New Size(188, 23)
        txtScanIncrement.TabIndex = 28
        ' 
        ' labHalfProbeDiameter
        ' 
        labHalfProbeDiameter.AutoSize = True
        labHalfProbeDiameter.Location = New Point(18, 338)
        labHalfProbeDiameter.Margin = New Padding(2, 0, 2, 0)
        labHalfProbeDiameter.Name = "labHalfProbeDiameter"
        labHalfProbeDiameter.Size = New Size(94, 15)
        labHalfProbeDiameter.TabIndex = 26
        labHalfProbeDiameter.Text = "Half Probe Diam"
        ' 
        ' txtHalfProbeDiameter
        ' 
        txtHalfProbeDiameter.Location = New Point(141, 335)
        txtHalfProbeDiameter.Margin = New Padding(2, 1, 2, 1)
        txtHalfProbeDiameter.Name = "txtHalfProbeDiameter"
        txtHalfProbeDiameter.Size = New Size(188, 23)
        txtHalfProbeDiameter.TabIndex = 26
        ' 
        ' labFixedOffset
        ' 
        labFixedOffset.AutoSize = True
        labFixedOffset.Location = New Point(18, 388)
        labFixedOffset.Margin = New Padding(2, 0, 2, 0)
        labFixedOffset.Name = "labFixedOffset"
        labFixedOffset.Size = New Size(69, 15)
        labFixedOffset.TabIndex = 29
        labFixedOffset.Text = "Fixed Offset"
        ' 
        ' txtFixedOffset
        ' 
        txtFixedOffset.Location = New Point(141, 385)
        txtFixedOffset.Margin = New Padding(2, 1, 2, 1)
        txtFixedOffset.Name = "txtFixedOffset"
        txtFixedOffset.Size = New Size(188, 23)
        txtFixedOffset.TabIndex = 30
        ' 
        ' labRadiusResolution
        ' 
        labRadiusResolution.AutoSize = True
        labRadiusResolution.Location = New Point(17, 263)
        labRadiusResolution.Margin = New Padding(2, 0, 2, 0)
        labRadiusResolution.Name = "labRadiusResolution"
        labRadiusResolution.Size = New Size(101, 15)
        labRadiusResolution.TabIndex = 20
        labRadiusResolution.Text = "Radius Resolution"
        ' 
        ' TxtRadiusResolution
        ' 
        TxtRadiusResolution.Location = New Point(141, 260)
        TxtRadiusResolution.Margin = New Padding(2, 1, 2, 1)
        TxtRadiusResolution.Name = "TxtRadiusResolution"
        TxtRadiusResolution.Size = New Size(188, 23)
        TxtRadiusResolution.TabIndex = 21
        ' 
        ' labDepthResolution
        ' 
        labDepthResolution.AutoSize = True
        labDepthResolution.Location = New Point(17, 238)
        labDepthResolution.Margin = New Padding(2, 0, 2, 0)
        labDepthResolution.Name = "labDepthResolution"
        labDepthResolution.Size = New Size(98, 15)
        labDepthResolution.TabIndex = 19
        labDepthResolution.Text = "Depth Resolution"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(17, 213)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(97, 15)
        Label7.TabIndex = 17
        Label7.Text = "Angle Resolution"
        ' 
        ' cmdCalibrationFile
        ' 
        cmdCalibrationFile.Image = My.Resources.Resources.OpenfileDialog
        cmdCalibrationFile.Location = New Point(741, 21)
        cmdCalibrationFile.Margin = New Padding(2, 1, 2, 1)
        cmdCalibrationFile.Name = "cmdCalibrationFile"
        cmdCalibrationFile.Size = New Size(35, 22)
        cmdCalibrationFile.TabIndex = 2
        ToolTipSave.SetToolTip(cmdCalibrationFile, "Select Calibration File")
        cmdCalibrationFile.UseVisualStyleBackColor = True
        ' 
        ' cmdZeroCalibration
        ' 
        cmdZeroCalibration.Enabled = False
        cmdZeroCalibration.Image = My.Resources.Resources.Home
        cmdZeroCalibration.Location = New Point(431, 104)
        cmdZeroCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdZeroCalibration.Name = "cmdZeroCalibration"
        cmdZeroCalibration.Size = New Size(82, 23)
        cmdZeroCalibration.TabIndex = 6
        cmdZeroCalibration.Text = "Zero"
        cmdZeroCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(cmdZeroCalibration, "Zero Calibration")
        cmdZeroCalibration.UseVisualStyleBackColor = True
        ' 
        ' cmdDefaultCalibration
        ' 
        cmdDefaultCalibration.Image = My.Resources.Resources.DefaultConstraint
        cmdDefaultCalibration.Location = New Point(517, 104)
        cmdDefaultCalibration.Margin = New Padding(2, 1, 2, 1)
        cmdDefaultCalibration.Name = "cmdDefaultCalibration"
        cmdDefaultCalibration.Size = New Size(82, 23)
        cmdDefaultCalibration.TabIndex = 7
        cmdDefaultCalibration.Text = "Default"
        cmdDefaultCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(cmdDefaultCalibration, "Load Default Calibration")
        cmdDefaultCalibration.UseVisualStyleBackColor = True
        ' 
        ' timerCalibration
        ' 
        timerCalibration.Interval = 200
        ' 
        ' TxtAngleResolution
        ' 
        TxtAngleResolution.Location = New Point(141, 210)
        TxtAngleResolution.Margin = New Padding(2, 1, 2, 1)
        TxtAngleResolution.Name = "TxtAngleResolution"
        TxtAngleResolution.Size = New Size(188, 23)
        TxtAngleResolution.TabIndex = 18
        ' 
        ' TxtDepthResolution
        ' 
        TxtDepthResolution.Location = New Point(141, 235)
        TxtDepthResolution.Margin = New Padding(2, 1, 2, 1)
        TxtDepthResolution.Name = "TxtDepthResolution"
        TxtDepthResolution.Size = New Size(188, 23)
        TxtDepthResolution.TabIndex = 19
        ' 
        ' FrmCalibration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(795, 500)
        Controls.Add(TxtDepthResolution)
        Controls.Add(TxtAngleResolution)
        Controls.Add(cmdDefaultCalibration)
        Controls.Add(cmdZeroCalibration)
        Controls.Add(cmdCalibrationFile)
        Controls.Add(labRadiusResolution)
        Controls.Add(TxtRadiusResolution)
        Controls.Add(labDepthResolution)
        Controls.Add(Label7)
        Controls.Add(labFixedOffset)
        Controls.Add(txtFixedOffset)
        Controls.Add(labScanIncrement)
        Controls.Add(txtScanIncrement)
        Controls.Add(labHalfProbeDiameter)
        Controls.Add(txtHalfProbeDiameter)
        Controls.Add(labRadiusOffsetL)
        Controls.Add(TxtRadiusOffsetL)
        Controls.Add(chkCalibrateAll)
        Controls.Add(cmdExportCalibration)
        Controls.Add(cmdImportCalibration)
        Controls.Add(labCalibrationFile)
        Controls.Add(txtCalibrationFile)
        Controls.Add(cmdCancelCalibration)
        Controls.Add(cmdSaveCalibration)
        Controls.Add(StatusStrip1)
        Controls.Add(labRadiusOffsetR)
        Controls.Add(TxtRadiusOffsetR)
        Controls.Add(cmdDepthCalibration)
        Controls.Add(labDepthCalibration)
        Controls.Add(txtDepthCalibration)
        Controls.Add(cmdRadiusCalibration)
        Controls.Add(labRadiusCalibration)
        Controls.Add(txtRadiusCalibration)
        Controls.Add(cmdAngleCalibration)
        Controls.Add(labAngleCalibration)
        Controls.Add(txtAngleCalibration)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmCalibration"
        Text = "Encoder Calibration"
        ToolTipSave.SetToolTip(Me, "Calibrate Angle" & vbCrLf)
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
    Friend WithEvents TxtRadiusOffsetR As TextBox
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
    Friend WithEvents TxtRadiusOffsetL As TextBox
    Friend WithEvents labScanIncrement As Label
    Friend WithEvents txtScanIncrement As TextBox
    Friend WithEvents labHalfProbeDiameter As Label
    Friend WithEvents txtHalfProbeDiameter As TextBox
    Friend WithEvents labFixedOffset As Label
    Friend WithEvents txtFixedOffset As TextBox
    Friend WithEvents labRadiusResolution As Label
    Friend WithEvents TxtRadiusResolution As TextBox
    Friend WithEvents labDepthResolution As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdCalibrationFile As Button
    Friend WithEvents cmdZeroCalibration As Button
    Friend WithEvents cmdDefaultCalibration As Button
    Friend WithEvents timerCalibration As Timer
    Friend WithEvents ToolTipSave As ToolTip
    Friend WithEvents ResetDepthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetRadiusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TxtAngleResolution As TextBox
    Friend WithEvents TxtDepthResolution As TextBox
End Class
