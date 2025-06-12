<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmHaleMRI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        cmdJobs = New Button()
        cmdCalibrate = New Button()
        cmdVessels = New Button()
        cmdMeasure = New Button()
        cmdCustomers = New Button()
        SuspendLayout()
        ' 
        ' cmdJobs
        ' 
        cmdJobs.ImageAlign = ContentAlignment.BottomCenter
        cmdJobs.Location = New Point(312, 12)
        cmdJobs.Name = "cmdJobs"
        cmdJobs.Size = New Size(144, 144)
        cmdJobs.TabIndex = 2
        cmdJobs.Text = "Jobs"
        cmdJobs.UseVisualStyleBackColor = True
        ' 
        ' cmdCalibrate
        ' 
        cmdCalibrate.ImageAlign = ContentAlignment.BottomCenter
        cmdCalibrate.Location = New Point(612, 12)
        cmdCalibrate.Name = "cmdCalibrate"
        cmdCalibrate.Size = New Size(144, 144)
        cmdCalibrate.TabIndex = 3
        cmdCalibrate.Text = "Calibrate"
        cmdCalibrate.UseVisualStyleBackColor = True
        ' 
        ' cmdVessels
        ' 
        cmdVessels.ImageAlign = ContentAlignment.BottomCenter
        cmdVessels.Location = New Point(162, 12)
        cmdVessels.Name = "cmdVessels"
        cmdVessels.Size = New Size(144, 144)
        cmdVessels.TabIndex = 5
        cmdVessels.Text = "Vessels"
        cmdVessels.UseVisualStyleBackColor = True
        ' 
        ' cmdMeasure
        ' 
        cmdMeasure.ImageAlign = ContentAlignment.BottomCenter
        cmdMeasure.Location = New Point(462, 12)
        cmdMeasure.Name = "cmdMeasure"
        cmdMeasure.Size = New Size(144, 144)
        cmdMeasure.TabIndex = 4
        cmdMeasure.Text = "Measure"
        cmdMeasure.UseVisualStyleBackColor = True
        ' 
        ' cmdCustomers
        ' 
        cmdCustomers.ImageAlign = ContentAlignment.BottomCenter
        cmdCustomers.Location = New Point(12, 12)
        cmdCustomers.Name = "cmdCustomers"
        cmdCustomers.Size = New Size(144, 144)
        cmdCustomers.TabIndex = 6
        cmdCustomers.Text = "Customers"
        cmdCustomers.UseVisualStyleBackColor = True
        ' 
        ' FrmHaleMRI
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2096, 888)
        Controls.Add(cmdCustomers)
        Controls.Add(cmdVessels)
        Controls.Add(cmdMeasure)
        Controls.Add(cmdCalibrate)
        Controls.Add(cmdJobs)
        Name = "FrmHaleMRI"
        Text = "Hale-MRI"
        ResumeLayout(False)
    End Sub
    Friend WithEvents cmdJobs As Button
    Friend WithEvents cmdCalibrate As Button
    Friend WithEvents cmdVessels As Button
    Friend WithEvents cmdMeasure As Button
    Friend WithEvents cmdCustomers As Button

End Class
