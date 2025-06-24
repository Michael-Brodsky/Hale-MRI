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
        cmdCalibrationFile = New Button()
        cmdExportScanData = New Button()
        cmdImportScanData = New Button()
        labScanDataFile = New Label()
        txtScanDataFile = New TextBox()
        WorkstationStatusStrip1 = New WorkstationStatusStrip()
        SuspendLayout()
        ' 
        ' comboBlade
        ' 
        comboBlade.FormattingEnabled = True
        comboBlade.Location = New Point(270, 225)
        comboBlade.Name = "comboBlade"
        comboBlade.Size = New Size(107, 40)
        comboBlade.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(40, 228)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 32)
        Label1.TabIndex = 1
        Label1.Text = "Blade"
        ' 
        ' txtAngle
        ' 
        txtAngle.Location = New Point(272, 354)
        txtAngle.Name = "txtAngle"
        txtAngle.Size = New Size(346, 39)
        txtAngle.TabIndex = 2
        ' 
        ' labAngle
        ' 
        labAngle.AutoSize = True
        labAngle.Location = New Point(42, 361)
        labAngle.Name = "labAngle"
        labAngle.Size = New Size(76, 32)
        labAngle.TabIndex = 3
        labAngle.Text = "Angle"
        ' 
        ' labDepth
        ' 
        labDepth.AutoSize = True
        labDepth.Location = New Point(42, 406)
        labDepth.Name = "labDepth"
        labDepth.Size = New Size(80, 32)
        labDepth.TabIndex = 5
        labDepth.Text = "Depth"
        ' 
        ' txtDepth
        ' 
        txtDepth.Location = New Point(272, 399)
        txtDepth.Name = "txtDepth"
        txtDepth.Size = New Size(346, 39)
        txtDepth.TabIndex = 4
        ' 
        ' labRadius
        ' 
        labRadius.AutoSize = True
        labRadius.Location = New Point(42, 451)
        labRadius.Name = "labRadius"
        labRadius.Size = New Size(84, 32)
        labRadius.TabIndex = 7
        labRadius.Text = "Radius"
        ' 
        ' txtRadius
        ' 
        txtRadius.Location = New Point(272, 444)
        txtRadius.Name = "txtRadius"
        txtRadius.Size = New Size(346, 39)
        txtRadius.TabIndex = 6
        ' 
        ' labRadiusPercent
        ' 
        labRadiusPercent.AutoSize = True
        labRadiusPercent.Location = New Point(42, 546)
        labRadiusPercent.Name = "labRadiusPercent"
        labRadiusPercent.Size = New Size(170, 32)
        labRadiusPercent.TabIndex = 9
        labRadiusPercent.Text = "Radius Percent"
        ' 
        ' txtRadiusPercent
        ' 
        txtRadiusPercent.Location = New Point(272, 539)
        txtRadiusPercent.Name = "txtRadiusPercent"
        txtRadiusPercent.Size = New Size(346, 39)
        txtRadiusPercent.TabIndex = 8
        ' 
        ' labDiameter
        ' 
        labDiameter.AutoSize = True
        labDiameter.Location = New Point(42, 591)
        labDiameter.Name = "labDiameter"
        labDiameter.Size = New Size(112, 32)
        labDiameter.TabIndex = 11
        labDiameter.Text = "Diameter"
        ' 
        ' txtDiameter
        ' 
        txtDiameter.Location = New Point(272, 584)
        txtDiameter.Name = "txtDiameter"
        txtDiameter.Size = New Size(346, 39)
        txtDiameter.TabIndex = 10
        ' 
        ' labWheelPitch
        ' 
        labWheelPitch.AutoSize = True
        labWheelPitch.Location = New Point(42, 636)
        labWheelPitch.Name = "labWheelPitch"
        labWheelPitch.Size = New Size(141, 32)
        labWheelPitch.TabIndex = 13
        labWheelPitch.Text = "Wheel Pitch"
        ' 
        ' txtWheelPitch
        ' 
        txtWheelPitch.Location = New Point(272, 629)
        txtWheelPitch.Name = "txtWheelPitch"
        txtWheelPitch.Size = New Size(346, 39)
        txtWheelPitch.TabIndex = 12
        ' 
        ' cmdAngle
        ' 
        cmdAngle.Location = New Point(652, 353)
        cmdAngle.Name = "cmdAngle"
        cmdAngle.Size = New Size(152, 40)
        cmdAngle.TabIndex = 14
        cmdAngle.Text = "Measure"
        cmdAngle.UseVisualStyleBackColor = True
        ' 
        ' cmdRadius
        ' 
        cmdRadius.Location = New Point(652, 443)
        cmdRadius.Name = "cmdRadius"
        cmdRadius.Size = New Size(152, 40)
        cmdRadius.TabIndex = 15
        cmdRadius.Text = "Measure"
        cmdRadius.UseVisualStyleBackColor = True
        ' 
        ' cmdDepth
        ' 
        cmdDepth.Location = New Point(652, 398)
        cmdDepth.Name = "cmdDepth"
        cmdDepth.Size = New Size(152, 40)
        cmdDepth.TabIndex = 16
        cmdDepth.Text = "Measure"
        cmdDepth.UseVisualStyleBackColor = True
        ' 
        ' cmdMeasureAll
        ' 
        cmdMeasureAll.Location = New Point(652, 307)
        cmdMeasureAll.Name = "cmdMeasureAll"
        cmdMeasureAll.Size = New Size(152, 40)
        cmdMeasureAll.TabIndex = 17
        cmdMeasureAll.Text = "Meas All"
        cmdMeasureAll.UseVisualStyleBackColor = True
        ' 
        ' cmdZero
        ' 
        cmdZero.Location = New Point(652, 489)
        cmdZero.Name = "cmdZero"
        cmdZero.Size = New Size(152, 40)
        cmdZero.TabIndex = 18
        cmdZero.Text = "Zero"
        cmdZero.UseVisualStyleBackColor = True
        ' 
        ' cmdCalibrationFile
        ' 
        cmdCalibrationFile.Location = New Point(1384, 31)
        cmdCalibrationFile.Name = "cmdCalibrationFile"
        cmdCalibrationFile.Size = New Size(65, 38)
        cmdCalibrationFile.TabIndex = 38
        cmdCalibrationFile.UseVisualStyleBackColor = True
        ' 
        ' cmdExportScanData
        ' 
        cmdExportScanData.Enabled = False
        cmdExportScanData.Location = New Point(180, 101)
        cmdExportScanData.Name = "cmdExportScanData"
        cmdExportScanData.Size = New Size(134, 45)
        cmdExportScanData.TabIndex = 37
        cmdExportScanData.UseVisualStyleBackColor = True
        ' 
        ' cmdImportScanData
        ' 
        cmdImportScanData.Enabled = False
        cmdImportScanData.Location = New Point(40, 101)
        cmdImportScanData.Name = "cmdImportScanData"
        cmdImportScanData.Size = New Size(134, 45)
        cmdImportScanData.TabIndex = 36
        cmdImportScanData.UseVisualStyleBackColor = True
        ' 
        ' labScanDataFile
        ' 
        labScanDataFile.AutoSize = True
        labScanDataFile.Location = New Point(40, 38)
        labScanDataFile.Name = "labScanDataFile"
        labScanDataFile.Size = New Size(164, 32)
        labScanDataFile.TabIndex = 35
        labScanDataFile.Text = "Scan Data File"
        ' 
        ' txtScanDataFile
        ' 
        txtScanDataFile.Location = New Point(270, 31)
        txtScanDataFile.Name = "txtScanDataFile"
        txtScanDataFile.Size = New Size(1104, 39)
        txtScanDataFile.TabIndex = 34
        txtScanDataFile.Text = "C:\Hale MRI 4\ScanData.txt"
        ' 
        ' WorkstationStatusStrip1
        ' 
        WorkstationStatusStrip1.Encoders = Nothing
        WorkstationStatusStrip1.Location = New Point(12, 882)
        WorkstationStatusStrip1.Name = "WorkstationStatusStrip1"
        WorkstationStatusStrip1.Size = New Size(1947, 46)
        WorkstationStatusStrip1.Status = WorkstationStatusStrip.EncoderStatus.NoEncoders
        WorkstationStatusStrip1.TabIndex = 39
        WorkstationStatusStrip1.WorkstationName = "WorkstationNameLabel"
        ' 
        ' FrmMeasurements
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1971, 940)
        Controls.Add(WorkstationStatusStrip1)
        Controls.Add(cmdCalibrationFile)
        Controls.Add(cmdExportScanData)
        Controls.Add(cmdImportScanData)
        Controls.Add(labScanDataFile)
        Controls.Add(txtScanDataFile)
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
    Friend WithEvents cmdCalibrationFile As Button
    Friend WithEvents cmdExportScanData As Button
    Friend WithEvents cmdImportScanData As Button
    Friend WithEvents labScanDataFile As Label
    Friend WithEvents txtScanDataFile As TextBox
    Friend WithEvents WorkstationStatusStrip1 As WorkstationStatusStrip
End Class
