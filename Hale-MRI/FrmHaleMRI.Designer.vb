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
        CmdWorkstation = New Button()
        cmdVessels = New Button()
        cmdCustomers = New Button()
        CustomerBindingSource = New BindingSource(components)
        CustomerBindingSource1 = New BindingSource(components)
        CmdSettings = New Button()
        PanelLogin = New Panel()
        LabLogin = New Label()
        CmdCancel = New Button()
        CmdOK = New Button()
        LabPassword = New Label()
        LabUser = New Label()
        TxtPassword = New TextBox()
        TxtUser = New TextBox()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        PanelLogin.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmdJobs
        ' 
        cmdJobs.Image = My.Resources.Resources.DocumentGroup
        cmdJobs.ImageAlign = ContentAlignment.BottomCenter
        cmdJobs.Location = New Point(178, 6)
        cmdJobs.Margin = New Padding(2, 1, 2, 1)
        cmdJobs.Name = "cmdJobs"
        cmdJobs.Size = New Size(82, 82)
        cmdJobs.TabIndex = 2
        cmdJobs.Text = "Jobs"
        cmdJobs.UseVisualStyleBackColor = True
        ' 
        ' CmdWorkstation
        ' 
        CmdWorkstation.Image = My.Resources.Resources.Measure
        CmdWorkstation.ImageAlign = ContentAlignment.BottomCenter
        CmdWorkstation.Location = New Point(264, 6)
        CmdWorkstation.Margin = New Padding(2, 1, 2, 1)
        CmdWorkstation.Name = "CmdWorkstation"
        CmdWorkstation.Size = New Size(82, 82)
        CmdWorkstation.TabIndex = 3
        CmdWorkstation.Text = "Workstation"
        CmdWorkstation.UseVisualStyleBackColor = True
        ' 
        ' cmdVessels
        ' 
        cmdVessels.ImageAlign = ContentAlignment.BottomCenter
        cmdVessels.Location = New Point(92, 6)
        cmdVessels.Margin = New Padding(2, 1, 2, 1)
        cmdVessels.Name = "cmdVessels"
        cmdVessels.Size = New Size(82, 82)
        cmdVessels.TabIndex = 5
        cmdVessels.Text = "Vessels"
        cmdVessels.UseVisualStyleBackColor = True
        ' 
        ' cmdCustomers
        ' 
        cmdCustomers.Image = My.Resources.Resources.ContactCard
        cmdCustomers.ImageAlign = ContentAlignment.BottomCenter
        cmdCustomers.Location = New Point(6, 6)
        cmdCustomers.Margin = New Padding(2, 1, 2, 1)
        cmdCustomers.Name = "cmdCustomers"
        cmdCustomers.Size = New Size(82, 82)
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
        ' CmdSettings
        ' 
        CmdSettings.Image = My.Resources.Resources.Settings
        CmdSettings.ImageAlign = ContentAlignment.BottomCenter
        CmdSettings.Location = New Point(350, 6)
        CmdSettings.Margin = New Padding(2, 1, 2, 1)
        CmdSettings.Name = "CmdSettings"
        CmdSettings.Size = New Size(82, 82)
        CmdSettings.TabIndex = 7
        CmdSettings.Text = "Settings"
        CmdSettings.UseVisualStyleBackColor = True
        ' 
        ' PanelLogin
        ' 
        PanelLogin.BorderStyle = BorderStyle.FixedSingle
        PanelLogin.Controls.Add(LabLogin)
        PanelLogin.Controls.Add(CmdCancel)
        PanelLogin.Controls.Add(CmdOK)
        PanelLogin.Controls.Add(LabPassword)
        PanelLogin.Controls.Add(LabUser)
        PanelLogin.Controls.Add(TxtPassword)
        PanelLogin.Controls.Add(TxtUser)
        PanelLogin.Location = New Point(407, 149)
        PanelLogin.Name = "PanelLogin"
        PanelLogin.Size = New Size(275, 134)
        PanelLogin.TabIndex = 8
        ' 
        ' LabLogin
        ' 
        LabLogin.AutoSize = True
        LabLogin.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabLogin.Location = New Point(79, 10)
        LabLogin.Name = "LabLogin"
        LabLogin.Size = New Size(102, 15)
        LabLogin.TabIndex = 6
        LabLogin.Text = "Application Login"
        ' 
        ' CmdCancel
        ' 
        CmdCancel.Enabled = False
        CmdCancel.Image = My.Resources.Resources.Cancel
        CmdCancel.Location = New Point(118, 95)
        CmdCancel.Name = "CmdCancel"
        CmdCancel.Size = New Size(38, 24)
        CmdCancel.TabIndex = 5
        CmdCancel.UseVisualStyleBackColor = True
        ' 
        ' CmdOK
        ' 
        CmdOK.Enabled = False
        CmdOK.Image = My.Resources.Resources.Checkmark
        CmdOK.Location = New Point(79, 95)
        CmdOK.Name = "CmdOK"
        CmdOK.Size = New Size(38, 24)
        CmdOK.TabIndex = 4
        CmdOK.UseVisualStyleBackColor = True
        ' 
        ' LabPassword
        ' 
        LabPassword.AutoSize = True
        LabPassword.Location = New Point(16, 69)
        LabPassword.Name = "LabPassword"
        LabPassword.Size = New Size(57, 15)
        LabPassword.TabIndex = 3
        LabPassword.Text = "Password"
        ' 
        ' LabUser
        ' 
        LabUser.AutoSize = True
        LabUser.Location = New Point(16, 42)
        LabUser.Name = "LabUser"
        LabUser.Size = New Size(30, 15)
        LabUser.TabIndex = 2
        LabUser.Text = "User"
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(79, 66)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.PasswordChar = "*"c
        TxtPassword.Size = New Size(172, 23)
        TxtPassword.TabIndex = 1
        ' 
        ' TxtUser
        ' 
        TxtUser.Location = New Point(79, 37)
        TxtUser.Name = "TxtUser"
        TxtUser.Size = New Size(172, 23)
        TxtUser.TabIndex = 0
        ' 
        ' FrmHaleMRI
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1036, 416)
        Controls.Add(PanelLogin)
        Controls.Add(CmdSettings)
        Controls.Add(cmdCustomers)
        Controls.Add(cmdVessels)
        Controls.Add(CmdWorkstation)
        Controls.Add(cmdJobs)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmHaleMRI"
        Text = "Hale-MRI"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        PanelLogin.ResumeLayout(False)
        PanelLogin.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents cmdJobs As Button
    Friend WithEvents CmdWorkstation As Button
    Friend WithEvents cmdVessels As Button
    Friend WithEvents cmdCustomers As Button
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource1 As BindingSource
    Friend WithEvents CmdSettings As Button
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents LabPassword As Label
    Friend WithEvents LabUser As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtUser As TextBox
    Friend WithEvents CmdCancel As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents LabLogin As Label

End Class
