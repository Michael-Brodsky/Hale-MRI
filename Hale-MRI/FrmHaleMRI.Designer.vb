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
        components = New ComponentModel.Container()
        cmdJobs = New Button()
        cmdCalibrate = New Button()
        cmdVessels = New Button()
        cmdMeasure = New Button()
        cmdCustomers = New Button()
        CustomerBindingSource = New BindingSource(components)
        CustomerBindingSource1 = New BindingSource(components)
        CmdJobDetails = New Button()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cmdJobs
        ' 
        cmdJobs.ImageAlign = ContentAlignment.BottomCenter
        cmdJobs.Location = New Point(168, 6)
        cmdJobs.Margin = New Padding(2, 1, 2, 1)
        cmdJobs.Name = "cmdJobs"
        cmdJobs.Size = New Size(78, 68)
        cmdJobs.TabIndex = 2
        cmdJobs.Text = "Jobs"
        cmdJobs.UseVisualStyleBackColor = True
        ' 
        ' cmdCalibrate
        ' 
        cmdCalibrate.ImageAlign = ContentAlignment.BottomCenter
        cmdCalibrate.Location = New Point(413, 6)
        cmdCalibrate.Margin = New Padding(2, 1, 2, 1)
        cmdCalibrate.Name = "cmdCalibrate"
        cmdCalibrate.Size = New Size(78, 68)
        cmdCalibrate.TabIndex = 3
        cmdCalibrate.Text = "Calibrate"
        cmdCalibrate.UseVisualStyleBackColor = True
        ' 
        ' cmdVessels
        ' 
        cmdVessels.ImageAlign = ContentAlignment.BottomCenter
        cmdVessels.Location = New Point(87, 6)
        cmdVessels.Margin = New Padding(2, 1, 2, 1)
        cmdVessels.Name = "cmdVessels"
        cmdVessels.Size = New Size(78, 68)
        cmdVessels.TabIndex = 5
        cmdVessels.Text = "Vessels"
        cmdVessels.UseVisualStyleBackColor = True
        ' 
        ' cmdMeasure
        ' 
        cmdMeasure.ImageAlign = ContentAlignment.BottomCenter
        cmdMeasure.Location = New Point(331, 6)
        cmdMeasure.Margin = New Padding(2, 1, 2, 1)
        cmdMeasure.Name = "cmdMeasure"
        cmdMeasure.Size = New Size(78, 68)
        cmdMeasure.TabIndex = 4
        cmdMeasure.Text = "Measure"
        cmdMeasure.UseVisualStyleBackColor = True
        ' 
        ' cmdCustomers
        ' 
        cmdCustomers.ImageAlign = ContentAlignment.BottomCenter
        cmdCustomers.Location = New Point(6, 6)
        cmdCustomers.Margin = New Padding(2, 1, 2, 1)
        cmdCustomers.Name = "cmdCustomers"
        cmdCustomers.Size = New Size(78, 68)
        cmdCustomers.TabIndex = 6
        cmdCustomers.Text = "Customers"
        cmdCustomers.UseVisualStyleBackColor = True
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' CustomerBindingSource1
        ' 
        CustomerBindingSource1.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' CmdJobDetails
        ' 
        CmdJobDetails.ImageAlign = ContentAlignment.BottomCenter
        CmdJobDetails.Location = New Point(250, 6)
        CmdJobDetails.Margin = New Padding(2, 1, 2, 1)
        CmdJobDetails.Name = "CmdJobDetails"
        CmdJobDetails.Size = New Size(78, 68)
        CmdJobDetails.TabIndex = 7
        CmdJobDetails.Text = "Job Details"
        CmdJobDetails.UseVisualStyleBackColor = True
        ' 
        ' FrmHaleMRI
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1036, 416)
        Controls.Add(CmdJobDetails)
        Controls.Add(cmdCustomers)
        Controls.Add(cmdVessels)
        Controls.Add(cmdMeasure)
        Controls.Add(cmdCalibrate)
        Controls.Add(cmdJobs)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmHaleMRI"
        Text = "Hale-MRI"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents cmdJobs As Button
    Friend WithEvents cmdCalibrate As Button
    Friend WithEvents cmdVessels As Button
    Friend WithEvents cmdMeasure As Button
    Friend WithEvents cmdCustomers As Button
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource1 As BindingSource
    Friend WithEvents CmdJobDetails As Button

End Class
