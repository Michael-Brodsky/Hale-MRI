<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalPitchTable
    Inherits DisplayControl

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
        TLayoutControl = New TableLayoutPanel()
        LabTolClass = New Label()
        TLayoutBackground = New TableLayoutPanel()
        TLayoutTolerances = New TableLayoutPanel()
        LabWheelLoLimit = New Label()
        LabWheelLoLabel = New Label()
        LabWheelHiLimit = New Label()
        LabWheelHiLabel = New Label()
        LabBladeLoLimit = New Label()
        LabBladeLoLabel = New Label()
        LabBladeHiLimit = New Label()
        LabBladeHiLabel = New Label()
        LabRadiusLoLimit = New Label()
        LabRadiusLoLabel = New Label()
        LabRadiusHiLimit = New Label()
        LabRadiusHiLabel = New Label()
        LabWheelPitch = New Label()
        LabWheelPitchLabel = New Label()
        LabLPLoLimit = New Label()
        LabLPLoLabel = New Label()
        LabLPHiLimit = New Label()
        LabLPHiLabel = New Label()
        TLayoutControl.SuspendLayout()
        TLayoutTolerances.SuspendLayout()
        SuspendLayout()
        ' 
        ' TLayoutControl
        ' 
        TLayoutControl.AutoScroll = True
        TLayoutControl.ColumnCount = 1
        TLayoutControl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutControl.Controls.Add(LabTolClass, 0, 0)
        TLayoutControl.Controls.Add(TLayoutBackground, 0, 1)
        TLayoutControl.Controls.Add(TLayoutTolerances, 0, 2)
        TLayoutControl.Dock = DockStyle.Fill
        TLayoutControl.Location = New Point(0, 0)
        TLayoutControl.Name = "TLayoutControl"
        TLayoutControl.RowCount = 3
        TLayoutControl.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TLayoutControl.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLayoutControl.RowStyles.Add(New RowStyle(SizeType.Absolute, 100F))
        TLayoutControl.Size = New Size(853, 234)
        TLayoutControl.TabIndex = 0
        ' 
        ' LabTolClass
        ' 
        LabTolClass.AutoSize = True
        LabTolClass.Dock = DockStyle.Bottom
        LabTolClass.Font = New Font("Segoe UI", 18F)
        LabTolClass.Location = New Point(3, 3)
        LabTolClass.Name = "LabTolClass"
        LabTolClass.Size = New Size(847, 32)
        LabTolClass.TabIndex = 0
        LabTolClass.Text = "Label"
        LabTolClass.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TLayoutBackground
        ' 
        TLayoutBackground.ColumnCount = 1
        TLayoutBackground.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutBackground.Dock = DockStyle.Fill
        TLayoutBackground.Font = New Font("Segoe UI", 12F)
        TLayoutBackground.Location = New Point(0, 45)
        TLayoutBackground.Margin = New Padding(0, 10, 0, 10)
        TLayoutBackground.Name = "TLayoutBackground"
        TLayoutBackground.RowCount = 1
        TLayoutBackground.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLayoutBackground.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TLayoutBackground.Size = New Size(853, 79)
        TLayoutBackground.TabIndex = 1
        ' 
        ' TLayoutTolerances
        ' 
        TLayoutTolerances.ColumnCount = 6
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180F))
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 85F))
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180F))
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 85F))
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 115F))
        TLayoutTolerances.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLayoutTolerances.Controls.Add(LabWheelLoLimit, 3, 3)
        TLayoutTolerances.Controls.Add(LabWheelLoLabel, 2, 3)
        TLayoutTolerances.Controls.Add(LabWheelHiLimit, 1, 3)
        TLayoutTolerances.Controls.Add(LabWheelHiLabel, 0, 3)
        TLayoutTolerances.Controls.Add(LabBladeLoLimit, 3, 2)
        TLayoutTolerances.Controls.Add(LabBladeLoLabel, 2, 2)
        TLayoutTolerances.Controls.Add(LabBladeHiLimit, 1, 2)
        TLayoutTolerances.Controls.Add(LabBladeHiLabel, 0, 2)
        TLayoutTolerances.Controls.Add(LabRadiusLoLimit, 3, 1)
        TLayoutTolerances.Controls.Add(LabRadiusLoLabel, 2, 1)
        TLayoutTolerances.Controls.Add(LabRadiusHiLimit, 1, 1)
        TLayoutTolerances.Controls.Add(LabRadiusHiLabel, 0, 1)
        TLayoutTolerances.Controls.Add(LabWheelPitch, 5, 0)
        TLayoutTolerances.Controls.Add(LabWheelPitchLabel, 4, 0)
        TLayoutTolerances.Controls.Add(LabLPLoLimit, 3, 0)
        TLayoutTolerances.Controls.Add(LabLPLoLabel, 2, 0)
        TLayoutTolerances.Controls.Add(LabLPHiLimit, 1, 0)
        TLayoutTolerances.Controls.Add(LabLPHiLabel, 0, 0)
        TLayoutTolerances.Dock = DockStyle.Fill
        TLayoutTolerances.Location = New Point(0, 134)
        TLayoutTolerances.Margin = New Padding(0)
        TLayoutTolerances.Name = "TLayoutTolerances"
        TLayoutTolerances.RowCount = 4
        TLayoutTolerances.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TLayoutTolerances.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TLayoutTolerances.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TLayoutTolerances.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TLayoutTolerances.Size = New Size(853, 100)
        TLayoutTolerances.TabIndex = 2
        ' 
        ' LabWheelLoLimit
        ' 
        LabWheelLoLimit.AutoSize = True
        LabWheelLoLimit.Dock = DockStyle.Top
        LabWheelLoLimit.Font = New Font("Segoe UI", 12F)
        LabWheelLoLimit.ForeColor = Color.Blue
        LabWheelLoLimit.Location = New Point(448, 75)
        LabWheelLoLimit.Name = "LabWheelLoLimit"
        LabWheelLoLimit.Size = New Size(79, 21)
        LabWheelLoLimit.TabIndex = 21
        LabWheelLoLimit.Text = "22.2222"
        ' 
        ' LabWheelLoLabel
        ' 
        LabWheelLoLabel.AutoSize = True
        LabWheelLoLabel.Dock = DockStyle.Top
        LabWheelLoLabel.Font = New Font("Segoe UI", 12F)
        LabWheelLoLabel.ForeColor = Color.Blue
        LabWheelLoLabel.Location = New Point(268, 75)
        LabWheelLoLabel.Name = "LabWheelLoLabel"
        LabWheelLoLabel.Size = New Size(174, 21)
        LabWheelLoLabel.TabIndex = 20
        LabWheelLoLabel.Text = "Wheel Pitch Lo Limit ="
        ' 
        ' LabWheelHiLimit
        ' 
        LabWheelHiLimit.AutoSize = True
        LabWheelHiLimit.Dock = DockStyle.Top
        LabWheelHiLimit.Font = New Font("Segoe UI", 12F)
        LabWheelHiLimit.ForeColor = Color.Red
        LabWheelHiLimit.Location = New Point(183, 75)
        LabWheelHiLimit.Name = "LabWheelHiLimit"
        LabWheelHiLimit.Size = New Size(79, 21)
        LabWheelHiLimit.TabIndex = 19
        LabWheelHiLimit.Text = "22.2222"
        ' 
        ' LabWheelHiLabel
        ' 
        LabWheelHiLabel.AutoSize = True
        LabWheelHiLabel.Dock = DockStyle.Top
        LabWheelHiLabel.Font = New Font("Segoe UI", 12F)
        LabWheelHiLabel.ForeColor = Color.Red
        LabWheelHiLabel.Location = New Point(3, 75)
        LabWheelHiLabel.Name = "LabWheelHiLabel"
        LabWheelHiLabel.Size = New Size(174, 21)
        LabWheelHiLabel.TabIndex = 18
        LabWheelHiLabel.Text = "Wheel Pitch Hi Limit ="
        ' 
        ' LabBladeLoLimit
        ' 
        LabBladeLoLimit.AutoSize = True
        LabBladeLoLimit.Dock = DockStyle.Top
        LabBladeLoLimit.Font = New Font("Segoe UI", 12F)
        LabBladeLoLimit.ForeColor = Color.Blue
        LabBladeLoLimit.Location = New Point(448, 50)
        LabBladeLoLimit.Name = "LabBladeLoLimit"
        LabBladeLoLimit.Size = New Size(79, 21)
        LabBladeLoLimit.TabIndex = 15
        LabBladeLoLimit.Text = "22.2222"
        ' 
        ' LabBladeLoLabel
        ' 
        LabBladeLoLabel.AutoSize = True
        LabBladeLoLabel.Font = New Font("Segoe UI", 12F)
        LabBladeLoLabel.ForeColor = Color.Blue
        LabBladeLoLabel.Location = New Point(268, 50)
        LabBladeLoLabel.Name = "LabBladeLoLabel"
        LabBladeLoLabel.Size = New Size(161, 21)
        LabBladeLoLabel.TabIndex = 14
        LabBladeLoLabel.Text = "Blade Pitch Lo Limit ="
        ' 
        ' LabBladeHiLimit
        ' 
        LabBladeHiLimit.AutoSize = True
        LabBladeHiLimit.Dock = DockStyle.Top
        LabBladeHiLimit.Font = New Font("Segoe UI", 12F)
        LabBladeHiLimit.ForeColor = Color.Red
        LabBladeHiLimit.Location = New Point(183, 50)
        LabBladeHiLimit.Name = "LabBladeHiLimit"
        LabBladeHiLimit.Size = New Size(79, 21)
        LabBladeHiLimit.TabIndex = 13
        LabBladeHiLimit.Text = "22.2222"
        ' 
        ' LabBladeHiLabel
        ' 
        LabBladeHiLabel.AutoSize = True
        LabBladeHiLabel.Dock = DockStyle.Top
        LabBladeHiLabel.Font = New Font("Segoe UI", 12F)
        LabBladeHiLabel.ForeColor = Color.Red
        LabBladeHiLabel.Location = New Point(3, 50)
        LabBladeHiLabel.Name = "LabBladeHiLabel"
        LabBladeHiLabel.Size = New Size(174, 21)
        LabBladeHiLabel.TabIndex = 12
        LabBladeHiLabel.Text = "Blade Pitch Hi Limit ="
        ' 
        ' LabRadiusLoLimit
        ' 
        LabRadiusLoLimit.AutoSize = True
        LabRadiusLoLimit.Dock = DockStyle.Top
        LabRadiusLoLimit.Font = New Font("Segoe UI", 12F)
        LabRadiusLoLimit.ForeColor = Color.Blue
        LabRadiusLoLimit.Location = New Point(448, 25)
        LabRadiusLoLimit.Name = "LabRadiusLoLimit"
        LabRadiusLoLimit.Size = New Size(79, 21)
        LabRadiusLoLimit.TabIndex = 9
        LabRadiusLoLimit.Text = "22.2222"
        ' 
        ' LabRadiusLoLabel
        ' 
        LabRadiusLoLabel.AutoSize = True
        LabRadiusLoLabel.Dock = DockStyle.Top
        LabRadiusLoLabel.Font = New Font("Segoe UI", 12F)
        LabRadiusLoLabel.ForeColor = Color.Blue
        LabRadiusLoLabel.Location = New Point(268, 25)
        LabRadiusLoLabel.Name = "LabRadiusLoLabel"
        LabRadiusLoLabel.Size = New Size(174, 21)
        LabRadiusLoLabel.TabIndex = 8
        LabRadiusLoLabel.Text = "Radius Pitch Lo Limit ="
        ' 
        ' LabRadiusHiLimit
        ' 
        LabRadiusHiLimit.AutoSize = True
        LabRadiusHiLimit.Dock = DockStyle.Top
        LabRadiusHiLimit.Font = New Font("Segoe UI", 12F)
        LabRadiusHiLimit.ForeColor = Color.Red
        LabRadiusHiLimit.Location = New Point(183, 25)
        LabRadiusHiLimit.Name = "LabRadiusHiLimit"
        LabRadiusHiLimit.Size = New Size(79, 21)
        LabRadiusHiLimit.TabIndex = 7
        LabRadiusHiLimit.Text = "22.2222"
        ' 
        ' LabRadiusHiLabel
        ' 
        LabRadiusHiLabel.AutoSize = True
        LabRadiusHiLabel.Font = New Font("Segoe UI", 12F)
        LabRadiusHiLabel.ForeColor = Color.Red
        LabRadiusHiLabel.Location = New Point(3, 25)
        LabRadiusHiLabel.Name = "LabRadiusHiLabel"
        LabRadiusHiLabel.Size = New Size(168, 21)
        LabRadiusHiLabel.TabIndex = 6
        LabRadiusHiLabel.Text = "Radius Pitch Hi Limit ="
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.AutoSize = True
        LabWheelPitch.Dock = DockStyle.Top
        LabWheelPitch.Font = New Font("Segoe UI", 12F)
        LabWheelPitch.Location = New Point(648, 0)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(202, 21)
        LabWheelPitch.TabIndex = 5
        LabWheelPitch.Text = "22.2222"
        ' 
        ' LabWheelPitchLabel
        ' 
        LabWheelPitchLabel.AutoSize = True
        LabWheelPitchLabel.Dock = DockStyle.Top
        LabWheelPitchLabel.Font = New Font("Segoe UI", 12F)
        LabWheelPitchLabel.Location = New Point(533, 0)
        LabWheelPitchLabel.Name = "LabWheelPitchLabel"
        LabWheelPitchLabel.Size = New Size(109, 21)
        LabWheelPitchLabel.TabIndex = 4
        LabWheelPitchLabel.Text = "Wheel Pitch ="
        ' 
        ' LabLPLoLimit
        ' 
        LabLPLoLimit.AutoSize = True
        LabLPLoLimit.Dock = DockStyle.Top
        LabLPLoLimit.Font = New Font("Segoe UI", 12F)
        LabLPLoLimit.ForeColor = Color.Blue
        LabLPLoLimit.Location = New Point(448, 0)
        LabLPLoLimit.Name = "LabLPLoLimit"
        LabLPLoLimit.Size = New Size(79, 21)
        LabLPLoLimit.TabIndex = 3
        LabLPLoLimit.Text = "22.2222"
        ' 
        ' LabLPLoLabel
        ' 
        LabLPLoLabel.AutoSize = True
        LabLPLoLabel.Dock = DockStyle.Top
        LabLPLoLabel.Font = New Font("Segoe UI", 12F)
        LabLPLoLabel.ForeColor = Color.Blue
        LabLPLoLabel.Location = New Point(268, 0)
        LabLPLoLabel.Name = "LabLPLoLabel"
        LabLPLoLabel.Size = New Size(174, 21)
        LabLPLoLabel.TabIndex = 2
        LabLPLoLabel.Text = "Local Pitch Lo Limit ="
        ' 
        ' LabLPHiLimit
        ' 
        LabLPHiLimit.AutoSize = True
        LabLPHiLimit.Dock = DockStyle.Top
        LabLPHiLimit.Font = New Font("Segoe UI", 12F)
        LabLPHiLimit.ForeColor = Color.Red
        LabLPHiLimit.Location = New Point(183, 0)
        LabLPHiLimit.Name = "LabLPHiLimit"
        LabLPHiLimit.Size = New Size(79, 21)
        LabLPHiLimit.TabIndex = 1
        LabLPHiLimit.Text = "22.2222"
        ' 
        ' LabLPHiLabel
        ' 
        LabLPHiLabel.AutoSize = True
        LabLPHiLabel.Dock = DockStyle.Top
        LabLPHiLabel.Font = New Font("Segoe UI", 12F)
        LabLPHiLabel.ForeColor = Color.Red
        LabLPHiLabel.Location = New Point(3, 0)
        LabLPHiLabel.Name = "LabLPHiLabel"
        LabLPHiLabel.Size = New Size(174, 21)
        LabLPHiLabel.TabIndex = 0
        LabLPHiLabel.Text = "Local Pitch Hi Limit ="
        ' 
        ' LocalPitchTable
        ' 
        AutoScaleMode = AutoScaleMode.None
        Controls.Add(TLayoutControl)
        Name = "LocalPitchTable"
        Size = New Size(853, 234)
        TLayoutControl.ResumeLayout(False)
        TLayoutControl.PerformLayout()
        TLayoutTolerances.ResumeLayout(False)
        TLayoutTolerances.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TLayoutControl As TableLayoutPanel
    Friend WithEvents LabTolClass As Label
    Friend WithEvents TLayoutBackground As TableLayoutPanel
    Friend WithEvents TLayoutTolerances As TableLayoutPanel
    Friend WithEvents LabWheelPitch As Label
    Friend WithEvents LabWheelPitchLabel As Label
    Friend WithEvents LabLPLoLimit As Label
    Friend WithEvents LabLPLoLabel As Label
    Friend WithEvents LabLPHiLimit As Label
    Friend WithEvents LabLPHiLabel As Label
    Friend WithEvents LabWheelLoLimit As Label
    Friend WithEvents LabWheelLoLabel As Label
    Friend WithEvents LabWheelHiLimit As Label
    Friend WithEvents LabWheelHiLabel As Label
    Friend WithEvents LabBladeLoLimit As Label
    Friend WithEvents LabBladeLoLabel As Label
    Friend WithEvents LabBladeHiLimit As Label
    Friend WithEvents LabBladeHiLabel As Label
    Friend WithEvents LabRadiusLoLimit As Label
    Friend WithEvents LabRadiusLoLabel As Label
    Friend WithEvents LabRadiusHiLimit As Label
    Friend WithEvents LabRadiusHiLabel As Label

End Class
