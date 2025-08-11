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
        CustomerBindingSource = New BindingSource(components)
        CustomerBindingSource1 = New BindingSource(components)
        PanelLogin = New Panel()
        LabLogin = New Label()
        CmdLoginCancel = New Button()
        CmdLoginOK = New Button()
        LabPassword = New Label()
        LabUser = New Label()
        TxtPassword = New TextBox()
        TxtUser = New TextBox()
        PanelMenuButtons = New TableLayoutPanel()
        CmdSettings = New Button()
        CmdWorkstation = New Button()
        CmdReports = New Button()
        CmdJobs = New Button()
        CmdPropellers = New Button()
        CmdManufacturers = New Button()
        CmdVessels = New Button()
        CmdCustomers = New Button()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        PanelLogin.SuspendLayout()
        PanelMenuButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' CustomerBindingSource1
        ' 
        CustomerBindingSource1.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' PanelLogin
        ' 
        PanelLogin.BorderStyle = BorderStyle.FixedSingle
        PanelLogin.Controls.Add(LabLogin)
        PanelLogin.Controls.Add(CmdLoginCancel)
        PanelLogin.Controls.Add(CmdLoginOK)
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
        ' CmdLoginCancel
        ' 
        CmdLoginCancel.Enabled = False
        CmdLoginCancel.Image = My.Resources.Resources.Cancel
        CmdLoginCancel.Location = New Point(118, 95)
        CmdLoginCancel.Name = "CmdLoginCancel"
        CmdLoginCancel.Size = New Size(38, 24)
        CmdLoginCancel.TabIndex = 5
        CmdLoginCancel.UseVisualStyleBackColor = True
        ' 
        ' CmdLoginOK
        ' 
        CmdLoginOK.Enabled = False
        CmdLoginOK.Image = My.Resources.Resources.StatusOK_18_18
        CmdLoginOK.Location = New Point(79, 95)
        CmdLoginOK.Name = "CmdLoginOK"
        CmdLoginOK.Size = New Size(38, 24)
        CmdLoginOK.TabIndex = 4
        CmdLoginOK.UseVisualStyleBackColor = True
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
        ' PanelMenuButtons
        ' 
        PanelMenuButtons.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelMenuButtons.AutoSize = True
        PanelMenuButtons.ColumnCount = 8
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.ColumnStyles.Add(New ColumnStyle())
        PanelMenuButtons.Controls.Add(CmdSettings, 7, 0)
        PanelMenuButtons.Controls.Add(CmdWorkstation, 6, 0)
        PanelMenuButtons.Controls.Add(CmdReports, 5, 0)
        PanelMenuButtons.Controls.Add(CmdJobs, 4, 0)
        PanelMenuButtons.Controls.Add(CmdPropellers, 3, 0)
        PanelMenuButtons.Controls.Add(CmdManufacturers, 2, 0)
        PanelMenuButtons.Controls.Add(CmdVessels, 1, 0)
        PanelMenuButtons.Controls.Add(CmdCustomers, 0, 0)
        PanelMenuButtons.Location = New Point(124, 12)
        PanelMenuButtons.Name = "PanelMenuButtons"
        PanelMenuButtons.Padding = New Padding(3)
        PanelMenuButtons.RowCount = 1
        PanelMenuButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        PanelMenuButtons.Size = New Size(792, 102)
        PanelMenuButtons.TabIndex = 12
        PanelMenuButtons.Visible = False
        ' 
        ' CmdSettings
        ' 
        CmdSettings.Image = My.Resources.Resources.Settings
        CmdSettings.ImageAlign = ContentAlignment.BottomCenter
        CmdSettings.Location = New Point(691, 4)
        CmdSettings.Margin = New Padding(2, 1, 2, 1)
        CmdSettings.Name = "CmdSettings"
        CmdSettings.Size = New Size(94, 94)
        CmdSettings.TabIndex = 16
        CmdSettings.Text = "Settings"
        CmdSettings.UseVisualStyleBackColor = True
        ' 
        ' CmdWorkstation
        ' 
        CmdWorkstation.Image = My.Resources.Resources.Computer
        CmdWorkstation.ImageAlign = ContentAlignment.BottomCenter
        CmdWorkstation.Location = New Point(593, 4)
        CmdWorkstation.Margin = New Padding(2, 1, 2, 1)
        CmdWorkstation.Name = "CmdWorkstation"
        CmdWorkstation.Size = New Size(94, 94)
        CmdWorkstation.TabIndex = 15
        CmdWorkstation.Text = "Workstation"
        CmdWorkstation.UseVisualStyleBackColor = True
        ' 
        ' CmdReports
        ' 
        CmdReports.Image = My.Resources.Resources.DocumentGroup
        CmdReports.ImageAlign = ContentAlignment.BottomCenter
        CmdReports.Location = New Point(495, 4)
        CmdReports.Margin = New Padding(2, 1, 2, 1)
        CmdReports.Name = "CmdReports"
        CmdReports.Size = New Size(94, 94)
        CmdReports.TabIndex = 14
        CmdReports.Text = "Reports"
        CmdReports.UseVisualStyleBackColor = True
        ' 
        ' CmdJobs
        ' 
        CmdJobs.Image = My.Resources.Resources._Property
        CmdJobs.ImageAlign = ContentAlignment.BottomCenter
        CmdJobs.Location = New Point(397, 4)
        CmdJobs.Margin = New Padding(2, 1, 2, 1)
        CmdJobs.Name = "CmdJobs"
        CmdJobs.Size = New Size(94, 94)
        CmdJobs.TabIndex = 13
        CmdJobs.Text = "Jobs"
        CmdJobs.UseVisualStyleBackColor = True
        ' 
        ' CmdPropellers
        ' 
        CmdPropellers.Image = My.Resources.Resources.Propeller18
        CmdPropellers.ImageAlign = ContentAlignment.BottomCenter
        CmdPropellers.Location = New Point(299, 4)
        CmdPropellers.Margin = New Padding(2, 1, 2, 1)
        CmdPropellers.Name = "CmdPropellers"
        CmdPropellers.Size = New Size(94, 94)
        CmdPropellers.TabIndex = 12
        CmdPropellers.Text = "Propellers"
        CmdPropellers.UseVisualStyleBackColor = True
        ' 
        ' CmdManufacturers
        ' 
        CmdManufacturers.Image = My.Resources.Resources.Factory_icon16
        CmdManufacturers.ImageAlign = ContentAlignment.BottomCenter
        CmdManufacturers.Location = New Point(201, 4)
        CmdManufacturers.Margin = New Padding(2, 1, 2, 1)
        CmdManufacturers.Name = "CmdManufacturers"
        CmdManufacturers.Size = New Size(94, 94)
        CmdManufacturers.TabIndex = 11
        CmdManufacturers.Text = "Manufacturers"
        CmdManufacturers.UseVisualStyleBackColor = True
        ' 
        ' CmdVessels
        ' 
        CmdVessels.Image = My.Resources.Resources.FluidLayout
        CmdVessels.ImageAlign = ContentAlignment.BottomCenter
        CmdVessels.Location = New Point(103, 4)
        CmdVessels.Margin = New Padding(2, 1, 2, 1)
        CmdVessels.Name = "CmdVessels"
        CmdVessels.Size = New Size(94, 94)
        CmdVessels.TabIndex = 8
        CmdVessels.Text = "Vessels"
        CmdVessels.UseVisualStyleBackColor = True
        ' 
        ' CmdCustomers
        ' 
        CmdCustomers.Image = My.Resources.Resources.ContactCard
        CmdCustomers.ImageAlign = ContentAlignment.BottomCenter
        CmdCustomers.Location = New Point(5, 4)
        CmdCustomers.Margin = New Padding(2, 1, 2, 1)
        CmdCustomers.Name = "CmdCustomers"
        CmdCustomers.Size = New Size(94, 94)
        CmdCustomers.TabIndex = 7
        CmdCustomers.Text = "Customers"
        CmdCustomers.UseVisualStyleBackColor = True
        ' 
        ' FrmHaleMRI
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1036, 416)
        Controls.Add(PanelMenuButtons)
        Controls.Add(PanelLogin)
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmHaleMRI"
        Text = "Hale-MRI"
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        PanelLogin.ResumeLayout(False)
        PanelLogin.PerformLayout()
        PanelMenuButtons.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource1 As BindingSource
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents LabPassword As Label
    Friend WithEvents LabUser As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtUser As TextBox
    Friend WithEvents CmdLoginCancel As Button
    Friend WithEvents CmdLoginOK As Button
    Friend WithEvents LabLogin As Label
    Friend WithEvents PanelMenuButtons As TableLayoutPanel
    Friend WithEvents CmdSettings As Button
    Friend WithEvents CmdWorkstation As Button
    Friend WithEvents CmdReports As Button
    Friend WithEvents CmdJobs As Button
    Friend WithEvents CmdPropellers As Button
    Friend WithEvents CmdManufacturers As Button
    Friend WithEvents CmdVessels As Button
    Friend WithEvents CmdCustomers As Button

End Class
