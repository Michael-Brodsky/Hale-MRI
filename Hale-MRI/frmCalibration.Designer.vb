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
        TxtAngleCalibration = New TextBox()
        labAngleCalibration = New Label()
        CmdAngleCalibration = New Button()
        CmdRadiusCalibration = New Button()
        labRadiusCalibration = New Label()
        TxtRadiusCalibration = New TextBox()
        CmdDepthCalibration = New Button()
        labDepthCalibration = New Label()
        TxtDepthCalibration = New TextBox()
        labRadiusOffsetR = New Label()
        TxtRadiusOffsetR = New TextBox()
        CmdSaveCalibration = New Button()
        CmdCancelCalibration = New Button()
        TxtCalibrationFile = New TextBox()
        labCalibrationFile = New Label()
        cmdImportCalibration = New Button()
        cmdExportCalibration = New Button()
        ChkCalibrateAll = New CheckBox()
        labRadiusOffsetL = New Label()
        TxtRadiusOffsetL = New TextBox()
        labScanIncrement = New Label()
        TxtScanIncrement = New TextBox()
        labHalfProbeDiameter = New Label()
        TxtHalfProbeDiameter = New TextBox()
        labFixedOffset = New Label()
        TxtFixedOffset = New TextBox()
        labRadiusResolution = New Label()
        TxtRadiusResolution = New TextBox()
        labDepthResolution = New Label()
        Label7 = New Label()
        CmdCalibrationFile = New Button()
        CmdZeroCalibration = New Button()
        CmdDefaultCalibration = New Button()
        timerCalibration = New Timer(components)
        ToolTipSave = New ToolTip(components)
        TxtAngleResolution = New TextBox()
        TxtDepthResolution = New TextBox()
        EncoderStatusStrip1 = New EncoderStatusStrip()
        SuspendLayout()
        ' 
        ' TxtAngleCalibration
        ' 
        TxtAngleCalibration.Location = New Point(141, 126)
        TxtAngleCalibration.Margin = New Padding(2, 1, 2, 1)
        TxtAngleCalibration.Name = "TxtAngleCalibration"
        TxtAngleCalibration.ReadOnly = True
        TxtAngleCalibration.Size = New Size(188, 23)
        TxtAngleCalibration.TabIndex = 9
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
        ' CmdAngleCalibration
        ' 
        CmdAngleCalibration.Image = My.Resources.Resources.Measure
        CmdAngleCalibration.ImageAlign = ContentAlignment.MiddleRight
        CmdAngleCalibration.Location = New Point(345, 128)
        CmdAngleCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdAngleCalibration.Name = "CmdAngleCalibration"
        CmdAngleCalibration.Size = New Size(82, 22)
        CmdAngleCalibration.TabIndex = 10
        CmdAngleCalibration.Text = "Calibrate"
        CmdAngleCalibration.TextAlign = ContentAlignment.MiddleLeft
        CmdAngleCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(CmdAngleCalibration, "Calibrate Angle Encoder")
        CmdAngleCalibration.UseVisualStyleBackColor = True
        ' 
        ' CmdRadiusCalibration
        ' 
        CmdRadiusCalibration.Image = My.Resources.Resources.Measure
        CmdRadiusCalibration.ImageAlign = ContentAlignment.MiddleRight
        CmdRadiusCalibration.Location = New Point(345, 177)
        CmdRadiusCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdRadiusCalibration.Name = "CmdRadiusCalibration"
        CmdRadiusCalibration.Size = New Size(82, 22)
        CmdRadiusCalibration.TabIndex = 16
        CmdRadiusCalibration.Text = "Calibrate"
        CmdRadiusCalibration.TextAlign = ContentAlignment.MiddleLeft
        CmdRadiusCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(CmdRadiusCalibration, "Calibrate Radius Encoder")
        CmdRadiusCalibration.UseVisualStyleBackColor = True
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
        ' TxtRadiusCalibration
        ' 
        TxtRadiusCalibration.Location = New Point(141, 176)
        TxtRadiusCalibration.Margin = New Padding(2, 1, 2, 1)
        TxtRadiusCalibration.Name = "TxtRadiusCalibration"
        TxtRadiusCalibration.ReadOnly = True
        TxtRadiusCalibration.Size = New Size(188, 23)
        TxtRadiusCalibration.TabIndex = 15
        ' 
        ' CmdDepthCalibration
        ' 
        CmdDepthCalibration.Image = My.Resources.Resources.Measure
        CmdDepthCalibration.ImageAlign = ContentAlignment.MiddleRight
        CmdDepthCalibration.Location = New Point(345, 152)
        CmdDepthCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdDepthCalibration.Name = "CmdDepthCalibration"
        CmdDepthCalibration.Size = New Size(82, 22)
        CmdDepthCalibration.TabIndex = 13
        CmdDepthCalibration.Text = "Calibrate"
        CmdDepthCalibration.TextAlign = ContentAlignment.MiddleLeft
        CmdDepthCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(CmdDepthCalibration, "Calibrate Depth Encoder")
        CmdDepthCalibration.UseVisualStyleBackColor = True
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
        ' TxtDepthCalibration
        ' 
        TxtDepthCalibration.Location = New Point(141, 151)
        TxtDepthCalibration.Margin = New Padding(2, 1, 2, 1)
        TxtDepthCalibration.Name = "TxtDepthCalibration"
        TxtDepthCalibration.ReadOnly = True
        TxtDepthCalibration.Size = New Size(188, 23)
        TxtDepthCalibration.TabIndex = 12
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
        ' CmdSaveCalibration
        ' 
        CmdSaveCalibration.Enabled = False
        CmdSaveCalibration.Image = My.Resources.Resources.Save
        CmdSaveCalibration.Location = New Point(17, 432)
        CmdSaveCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdSaveCalibration.Name = "CmdSaveCalibration"
        CmdSaveCalibration.Size = New Size(72, 22)
        CmdSaveCalibration.TabIndex = 31
        ToolTipSave.SetToolTip(CmdSaveCalibration, "Save Changes")
        CmdSaveCalibration.UseVisualStyleBackColor = True
        ' 
        ' CmdCancelCalibration
        ' 
        CmdCancelCalibration.Enabled = False
        CmdCancelCalibration.Image = My.Resources.Resources.Cancel
        CmdCancelCalibration.Location = New Point(92, 432)
        CmdCancelCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdCancelCalibration.Name = "CmdCancelCalibration"
        CmdCancelCalibration.Size = New Size(72, 22)
        CmdCancelCalibration.TabIndex = 32
        ToolTipSave.SetToolTip(CmdCancelCalibration, "Cancel Changes")
        CmdCancelCalibration.UseVisualStyleBackColor = True
        ' 
        ' TxtCalibrationFile
        ' 
        TxtCalibrationFile.Location = New Point(141, 20)
        TxtCalibrationFile.Margin = New Padding(2, 1, 2, 1)
        TxtCalibrationFile.Name = "TxtCalibrationFile"
        TxtCalibrationFile.Size = New Size(596, 23)
        TxtCalibrationFile.TabIndex = 1
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
        ' ChkCalibrateAll
        ' 
        ChkCalibrateAll.Appearance = Appearance.Button
        ChkCalibrateAll.Image = My.Resources.Resources.Timer
        ChkCalibrateAll.ImageAlign = ContentAlignment.MiddleRight
        ChkCalibrateAll.Location = New Point(345, 104)
        ChkCalibrateAll.Margin = New Padding(2, 1, 2, 1)
        ChkCalibrateAll.Name = "ChkCalibrateAll"
        ChkCalibrateAll.Size = New Size(82, 23)
        ChkCalibrateAll.TabIndex = 5
        ChkCalibrateAll.Text = "Cal All"
        ChkCalibrateAll.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(ChkCalibrateAll, "Calibrate All Encoders Continuously")
        ChkCalibrateAll.UseVisualStyleBackColor = True
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
        ' TxtScanIncrement
        ' 
        TxtScanIncrement.Location = New Point(141, 360)
        TxtScanIncrement.Margin = New Padding(2, 1, 2, 1)
        TxtScanIncrement.Name = "TxtScanIncrement"
        TxtScanIncrement.Size = New Size(188, 23)
        TxtScanIncrement.TabIndex = 28
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
        ' TxtHalfProbeDiameter
        ' 
        TxtHalfProbeDiameter.Location = New Point(141, 335)
        TxtHalfProbeDiameter.Margin = New Padding(2, 1, 2, 1)
        TxtHalfProbeDiameter.Name = "TxtHalfProbeDiameter"
        TxtHalfProbeDiameter.Size = New Size(188, 23)
        TxtHalfProbeDiameter.TabIndex = 26
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
        ' TxtFixedOffset
        ' 
        TxtFixedOffset.Location = New Point(141, 385)
        TxtFixedOffset.Margin = New Padding(2, 1, 2, 1)
        TxtFixedOffset.Name = "TxtFixedOffset"
        TxtFixedOffset.Size = New Size(188, 23)
        TxtFixedOffset.TabIndex = 30
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
        ' CmdCalibrationFile
        ' 
        CmdCalibrationFile.Image = My.Resources.Resources.OpenfileDialog
        CmdCalibrationFile.Location = New Point(741, 21)
        CmdCalibrationFile.Margin = New Padding(2, 1, 2, 1)
        CmdCalibrationFile.Name = "CmdCalibrationFile"
        CmdCalibrationFile.Size = New Size(35, 22)
        CmdCalibrationFile.TabIndex = 2
        ToolTipSave.SetToolTip(CmdCalibrationFile, "Select Calibration File")
        CmdCalibrationFile.UseVisualStyleBackColor = True
        ' 
        ' CmdZeroCalibration
        ' 
        CmdZeroCalibration.Image = My.Resources.Resources.Home
        CmdZeroCalibration.ImageAlign = ContentAlignment.MiddleRight
        CmdZeroCalibration.Location = New Point(431, 104)
        CmdZeroCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdZeroCalibration.Name = "CmdZeroCalibration"
        CmdZeroCalibration.Size = New Size(82, 23)
        CmdZeroCalibration.TabIndex = 6
        CmdZeroCalibration.Text = "Zero"
        CmdZeroCalibration.TextAlign = ContentAlignment.MiddleLeft
        CmdZeroCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(CmdZeroCalibration, "Zero Calibration")
        CmdZeroCalibration.UseVisualStyleBackColor = True
        ' 
        ' CmdDefaultCalibration
        ' 
        CmdDefaultCalibration.Image = My.Resources.Resources.DefaultConstraint
        CmdDefaultCalibration.ImageAlign = ContentAlignment.MiddleRight
        CmdDefaultCalibration.Location = New Point(517, 104)
        CmdDefaultCalibration.Margin = New Padding(2, 1, 2, 1)
        CmdDefaultCalibration.Name = "CmdDefaultCalibration"
        CmdDefaultCalibration.Size = New Size(82, 23)
        CmdDefaultCalibration.TabIndex = 7
        CmdDefaultCalibration.Text = "Default"
        CmdDefaultCalibration.TextAlign = ContentAlignment.MiddleLeft
        CmdDefaultCalibration.TextImageRelation = TextImageRelation.ImageBeforeText
        ToolTipSave.SetToolTip(CmdDefaultCalibration, "Load Default Calibration")
        CmdDefaultCalibration.UseVisualStyleBackColor = True
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
        ' EncoderStatusStrip1
        ' 
        EncoderStatusStrip1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        EncoderStatusStrip1.Hardware = Nothing
        EncoderStatusStrip1.Location = New Point(-1, 497)
        EncoderStatusStrip1.Name = "EncoderStatusStrip1"
        EncoderStatusStrip1.Size = New Size(796, 23)
        EncoderStatusStrip1.TabIndex = 33
        EncoderStatusStrip1.TimerInterval = 100L
        EncoderStatusStrip1.TimerOn = False
        EncoderStatusStrip1.WorkstationName = ""
        ' 
        ' FrmCalibration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(795, 520)
        Controls.Add(EncoderStatusStrip1)
        Controls.Add(TxtDepthResolution)
        Controls.Add(TxtAngleResolution)
        Controls.Add(CmdDefaultCalibration)
        Controls.Add(CmdZeroCalibration)
        Controls.Add(CmdCalibrationFile)
        Controls.Add(labRadiusResolution)
        Controls.Add(TxtRadiusResolution)
        Controls.Add(labDepthResolution)
        Controls.Add(Label7)
        Controls.Add(labFixedOffset)
        Controls.Add(TxtFixedOffset)
        Controls.Add(labScanIncrement)
        Controls.Add(TxtScanIncrement)
        Controls.Add(labHalfProbeDiameter)
        Controls.Add(TxtHalfProbeDiameter)
        Controls.Add(labRadiusOffsetL)
        Controls.Add(TxtRadiusOffsetL)
        Controls.Add(ChkCalibrateAll)
        Controls.Add(cmdExportCalibration)
        Controls.Add(cmdImportCalibration)
        Controls.Add(labCalibrationFile)
        Controls.Add(TxtCalibrationFile)
        Controls.Add(CmdCancelCalibration)
        Controls.Add(CmdSaveCalibration)
        Controls.Add(labRadiusOffsetR)
        Controls.Add(TxtRadiusOffsetR)
        Controls.Add(CmdDepthCalibration)
        Controls.Add(labDepthCalibration)
        Controls.Add(TxtDepthCalibration)
        Controls.Add(CmdRadiusCalibration)
        Controls.Add(labRadiusCalibration)
        Controls.Add(TxtRadiusCalibration)
        Controls.Add(CmdAngleCalibration)
        Controls.Add(labAngleCalibration)
        Controls.Add(TxtAngleCalibration)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmCalibration"
        Text = "Encoder Calibration"
        ToolTipSave.SetToolTip(Me, "Calibrate Angle" & vbCrLf)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtAngleCalibration As TextBox
    Friend WithEvents labAngleCalibration As Label
    Friend WithEvents CmdAngleCalibration As Button
    Friend WithEvents CmdRadiusCalibration As Button
    Friend WithEvents labRadiusCalibration As Label
    Friend WithEvents TxtRadiusCalibration As TextBox
    Friend WithEvents CmdDepthCalibration As Button
    Friend WithEvents labDepthCalibration As Label
    Friend WithEvents TxtDepthCalibration As TextBox
    Friend WithEvents labRadiusOffsetR As Label
    Friend WithEvents TxtRadiusOffsetR As TextBox
    Friend WithEvents CmdSaveCalibration As Button
    Friend WithEvents CmdCancelCalibration As Button
    Friend WithEvents TxtCalibrationFile As TextBox
    Friend WithEvents labCalibrationFile As Label
    Friend WithEvents cmdImportCalibration As Button
    Friend WithEvents cmdExportCalibration As Button
    Friend WithEvents ChkCalibrateAll As CheckBox
    Friend WithEvents labRadiusOffsetL As Label
    Friend WithEvents TxtRadiusOffsetL As TextBox
    Friend WithEvents labScanIncrement As Label
    Friend WithEvents TxtScanIncrement As TextBox
    Friend WithEvents labHalfProbeDiameter As Label
    Friend WithEvents TxtHalfProbeDiameter As TextBox
    Friend WithEvents labFixedOffset As Label
    Friend WithEvents TxtFixedOffset As TextBox
    Friend WithEvents labRadiusResolution As Label
    Friend WithEvents TxtRadiusResolution As TextBox
    Friend WithEvents labDepthResolution As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmdCalibrationFile As Button
    Friend WithEvents CmdZeroCalibration As Button
    Friend WithEvents CmdDefaultCalibration As Button
    Friend WithEvents timerCalibration As Timer
    Friend WithEvents ToolTipSave As ToolTip
    Friend WithEvents TxtAngleResolution As TextBox
    Friend WithEvents TxtDepthResolution As TextBox
    Friend WithEvents EncoderStatusStrip1 As EncoderStatusStrip
End Class
