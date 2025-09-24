<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSettings
    Inherits FrmDatabaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
        TabControl1 = New TabControl()
        TabPageShop = New TabPage()
        LabCompanyPhone = New Label()
        Label5 = New Label()
        LabCompanyWebsite = New Label()
        LabCompanyEmail = New Label()
        LabCompanyAddress = New Label()
        LabCompanyName = New Label()
        TxtCompanyPhone = New TextBox()
        SettingsBindingSource = New BindingSource(components)
        TxtCompanyEmail = New TextBox()
        TxtCompanyWebsite = New TextBox()
        TxtCompanyContact = New TextBox()
        TxtCompanyAddress = New TextBox()
        TxtCompanyName = New TextBox()
        TabPageApplication = New TabPage()
        CmdDefaultFolder = New Button()
        LabDefaultFolder = New Label()
        TxtDefaultFolder = New TextBox()
        TabPageDatabase = New TabPage()
        LabDatabaseMaintenance = New Label()
        ComboDatabaseMaintenance = New ComboBox()
        CmdDatabaseFile = New Button()
        Label1 = New Label()
        LabDatabasePath = New Label()
        TxtConnectionString = New TextBox()
        TxtDatabaseFile = New TextBox()
        CmdUndo = New Button()
        CmdSave = New Button()
        TabControl1.SuspendLayout()
        TabPageShop.SuspendLayout()
        CType(SettingsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TabPageApplication.SuspendLayout()
        TabPageDatabase.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageShop)
        TabControl1.Controls.Add(TabPageApplication)
        TabControl1.Controls.Add(TabPageDatabase)
        TabControl1.Location = New Point(32, 29)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(597, 356)
        TabControl1.TabIndex = 6
        ' 
        ' TabPageShop
        ' 
        TabPageShop.Controls.Add(LabCompanyPhone)
        TabPageShop.Controls.Add(Label5)
        TabPageShop.Controls.Add(LabCompanyWebsite)
        TabPageShop.Controls.Add(LabCompanyEmail)
        TabPageShop.Controls.Add(LabCompanyAddress)
        TabPageShop.Controls.Add(LabCompanyName)
        TabPageShop.Controls.Add(TxtCompanyPhone)
        TabPageShop.Controls.Add(TxtCompanyEmail)
        TabPageShop.Controls.Add(TxtCompanyWebsite)
        TabPageShop.Controls.Add(TxtCompanyContact)
        TabPageShop.Controls.Add(TxtCompanyAddress)
        TabPageShop.Controls.Add(TxtCompanyName)
        TabPageShop.Location = New Point(4, 24)
        TabPageShop.Name = "TabPageShop"
        TabPageShop.Padding = New Padding(3)
        TabPageShop.Size = New Size(589, 328)
        TabPageShop.TabIndex = 0
        TabPageShop.Text = "Shop"
        TabPageShop.UseVisualStyleBackColor = True
        ' 
        ' LabCompanyPhone
        ' 
        LabCompanyPhone.AutoSize = True
        LabCompanyPhone.Location = New Point(103, 227)
        LabCompanyPhone.Name = "LabCompanyPhone"
        LabCompanyPhone.Size = New Size(49, 15)
        LabCompanyPhone.TabIndex = 17
        LabCompanyPhone.Text = "Contact"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(103, 198)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 15)
        Label5.TabIndex = 16
        Label5.Text = "Phone"
        ' 
        ' LabCompanyWebsite
        ' 
        LabCompanyWebsite.AutoSize = True
        LabCompanyWebsite.Location = New Point(103, 169)
        LabCompanyWebsite.Name = "LabCompanyWebsite"
        LabCompanyWebsite.Size = New Size(36, 15)
        LabCompanyWebsite.TabIndex = 15
        LabCompanyWebsite.Text = "Email"
        ' 
        ' LabCompanyEmail
        ' 
        LabCompanyEmail.AutoSize = True
        LabCompanyEmail.Location = New Point(103, 140)
        LabCompanyEmail.Name = "LabCompanyEmail"
        LabCompanyEmail.Size = New Size(49, 15)
        LabCompanyEmail.TabIndex = 14
        LabCompanyEmail.Text = "Website"
        ' 
        ' LabCompanyAddress
        ' 
        LabCompanyAddress.AutoSize = True
        LabCompanyAddress.Location = New Point(103, 111)
        LabCompanyAddress.Name = "LabCompanyAddress"
        LabCompanyAddress.Size = New Size(49, 15)
        LabCompanyAddress.TabIndex = 13
        LabCompanyAddress.Text = "Address"
        ' 
        ' LabCompanyName
        ' 
        LabCompanyName.AutoSize = True
        LabCompanyName.Location = New Point(103, 82)
        LabCompanyName.Name = "LabCompanyName"
        LabCompanyName.Size = New Size(39, 15)
        LabCompanyName.TabIndex = 12
        LabCompanyName.Text = "Name"
        ' 
        ' TxtCompanyPhone
        ' 
        TxtCompanyPhone.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyContact", True))
        TxtCompanyPhone.Location = New Point(158, 224)
        TxtCompanyPhone.Name = "TxtCompanyPhone"
        TxtCompanyPhone.Size = New Size(164, 23)
        TxtCompanyPhone.TabIndex = 11
        ' 
        ' SettingsBindingSource
        ' 
        SettingsBindingSource.DataSource = GetType(LibDatabase.Models.Setting)
        ' 
        ' TxtCompanyEmail
        ' 
        TxtCompanyEmail.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyWebsite", True))
        TxtCompanyEmail.Location = New Point(158, 137)
        TxtCompanyEmail.Name = "TxtCompanyEmail"
        TxtCompanyEmail.Size = New Size(320, 23)
        TxtCompanyEmail.TabIndex = 10
        ' 
        ' TxtCompanyWebsite
        ' 
        TxtCompanyWebsite.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyEmail", True))
        TxtCompanyWebsite.Location = New Point(158, 166)
        TxtCompanyWebsite.Name = "TxtCompanyWebsite"
        TxtCompanyWebsite.Size = New Size(320, 23)
        TxtCompanyWebsite.TabIndex = 9
        ' 
        ' TxtCompanyContact
        ' 
        TxtCompanyContact.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyPhone", True))
        TxtCompanyContact.Location = New Point(158, 195)
        TxtCompanyContact.Name = "TxtCompanyContact"
        TxtCompanyContact.Size = New Size(164, 23)
        TxtCompanyContact.TabIndex = 8
        ' 
        ' TxtCompanyAddress
        ' 
        TxtCompanyAddress.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyAddress", True))
        TxtCompanyAddress.Location = New Point(158, 108)
        TxtCompanyAddress.Name = "TxtCompanyAddress"
        TxtCompanyAddress.Size = New Size(320, 23)
        TxtCompanyAddress.TabIndex = 7
        ' 
        ' TxtCompanyName
        ' 
        TxtCompanyName.DataBindings.Add(New Binding("Text", SettingsBindingSource, "CompanyName", True))
        TxtCompanyName.Location = New Point(158, 79)
        TxtCompanyName.Name = "TxtCompanyName"
        TxtCompanyName.Size = New Size(320, 23)
        TxtCompanyName.TabIndex = 6
        ' 
        ' TabPageApplication
        ' 
        TabPageApplication.Controls.Add(CmdDefaultFolder)
        TabPageApplication.Controls.Add(LabDefaultFolder)
        TabPageApplication.Controls.Add(TxtDefaultFolder)
        TabPageApplication.Location = New Point(4, 24)
        TabPageApplication.Name = "TabPageApplication"
        TabPageApplication.Padding = New Padding(3)
        TabPageApplication.Size = New Size(589, 328)
        TabPageApplication.TabIndex = 1
        TabPageApplication.Text = "Application"
        TabPageApplication.UseVisualStyleBackColor = True
        ' 
        ' CmdDefaultFolder
        ' 
        CmdDefaultFolder.Image = My.Resources.Resources.OpenfileDialog
        CmdDefaultFolder.Location = New Point(495, 69)
        CmdDefaultFolder.Margin = New Padding(2, 1, 2, 1)
        CmdDefaultFolder.Name = "CmdDefaultFolder"
        CmdDefaultFolder.Size = New Size(35, 22)
        CmdDefaultFolder.TabIndex = 265
        CmdDefaultFolder.UseVisualStyleBackColor = True
        ' 
        ' LabDefaultFolder
        ' 
        LabDefaultFolder.AutoSize = True
        LabDefaultFolder.Location = New Point(61, 71)
        LabDefaultFolder.Name = "LabDefaultFolder"
        LabDefaultFolder.Size = New Size(81, 15)
        LabDefaultFolder.TabIndex = 5
        LabDefaultFolder.Text = "Default Folder"
        ' 
        ' TxtDefaultFolder
        ' 
        TxtDefaultFolder.DataBindings.Add(New Binding("Text", SettingsBindingSource, "ApplicationDefaultFolder", True))
        TxtDefaultFolder.Location = New Point(170, 68)
        TxtDefaultFolder.Name = "TxtDefaultFolder"
        TxtDefaultFolder.Size = New Size(320, 23)
        TxtDefaultFolder.TabIndex = 2
        ' 
        ' TabPageDatabase
        ' 
        TabPageDatabase.Controls.Add(LabDatabaseMaintenance)
        TabPageDatabase.Controls.Add(ComboDatabaseMaintenance)
        TabPageDatabase.Controls.Add(CmdDatabaseFile)
        TabPageDatabase.Controls.Add(Label1)
        TabPageDatabase.Controls.Add(LabDatabasePath)
        TabPageDatabase.Controls.Add(TxtConnectionString)
        TabPageDatabase.Controls.Add(TxtDatabaseFile)
        TabPageDatabase.Location = New Point(4, 24)
        TabPageDatabase.Name = "TabPageDatabase"
        TabPageDatabase.Padding = New Padding(3)
        TabPageDatabase.Size = New Size(589, 328)
        TabPageDatabase.TabIndex = 2
        TabPageDatabase.Text = "Database"
        TabPageDatabase.UseVisualStyleBackColor = True
        ' 
        ' LabDatabaseMaintenance
        ' 
        LabDatabaseMaintenance.AutoSize = True
        LabDatabaseMaintenance.Location = New Point(61, 129)
        LabDatabaseMaintenance.Name = "LabDatabaseMaintenance"
        LabDatabaseMaintenance.Size = New Size(76, 15)
        LabDatabaseMaintenance.TabIndex = 271
        LabDatabaseMaintenance.Text = "Maintenance"
        ' 
        ' ComboDatabaseMaintenance
        ' 
        ComboDatabaseMaintenance.FormattingEnabled = True
        ComboDatabaseMaintenance.Items.AddRange(New Object() {"Daily", "Semi-Weekly", "Weekly", "Bi-Weekly", "Monthly", "Never"})
        ComboDatabaseMaintenance.Location = New Point(170, 126)
        ComboDatabaseMaintenance.Name = "ComboDatabaseMaintenance"
        ComboDatabaseMaintenance.Size = New Size(121, 23)
        ComboDatabaseMaintenance.TabIndex = 270
        ' 
        ' CmdDatabaseFile
        ' 
        CmdDatabaseFile.Image = My.Resources.Resources.OpenfileDialog
        CmdDatabaseFile.Location = New Point(495, 69)
        CmdDatabaseFile.Margin = New Padding(2, 1, 2, 1)
        CmdDatabaseFile.Name = "CmdDatabaseFile"
        CmdDatabaseFile.Size = New Size(35, 22)
        CmdDatabaseFile.TabIndex = 269
        CmdDatabaseFile.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(61, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(103, 15)
        Label1.TabIndex = 268
        Label1.Text = "Connection String"
        ' 
        ' LabDatabasePath
        ' 
        LabDatabasePath.AutoSize = True
        LabDatabasePath.Location = New Point(61, 71)
        LabDatabasePath.Name = "LabDatabasePath"
        LabDatabasePath.Size = New Size(76, 15)
        LabDatabasePath.TabIndex = 267
        LabDatabasePath.Text = "Database File"
        ' 
        ' TxtConnectionString
        ' 
        TxtConnectionString.DataBindings.Add(New Binding("Text", SettingsBindingSource, "ApplicationConnectionString", True))
        TxtConnectionString.Location = New Point(170, 97)
        TxtConnectionString.Name = "TxtConnectionString"
        TxtConnectionString.Size = New Size(320, 23)
        TxtConnectionString.TabIndex = 266
        ' 
        ' TxtDatabaseFile
        ' 
        TxtDatabaseFile.DataBindings.Add(New Binding("Text", SettingsBindingSource, "ApplicationDatabaseFile", True))
        TxtDatabaseFile.Location = New Point(170, 68)
        TxtDatabaseFile.Name = "TxtDatabaseFile"
        TxtDatabaseFile.Size = New Size(320, 23)
        TxtDatabaseFile.TabIndex = 265
        ' 
        ' CmdUndo
        ' 
        CmdUndo.Enabled = False
        CmdUndo.Image = CType(resources.GetObject("CmdUndo.Image"), Image)
        CmdUndo.Location = New Point(74, 391)
        CmdUndo.Margin = New Padding(0, 3, 0, 3)
        CmdUndo.Name = "CmdUndo"
        CmdUndo.Size = New Size(38, 24)
        CmdUndo.TabIndex = 13
        CmdUndo.UseVisualStyleBackColor = True
        ' 
        ' CmdSave
        ' 
        CmdSave.Enabled = False
        CmdSave.Image = CType(resources.GetObject("CmdSave.Image"), Image)
        CmdSave.Location = New Point(36, 391)
        CmdSave.Margin = New Padding(3, 3, 0, 3)
        CmdSave.Name = "CmdSave"
        CmdSave.Size = New Size(38, 24)
        CmdSave.TabIndex = 12
        CmdSave.UseVisualStyleBackColor = True
        ' 
        ' FrmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(673, 454)
        Controls.Add(CmdUndo)
        Controls.Add(CmdSave)
        Controls.Add(TabControl1)
        Name = "FrmSettings"
        Text = "Settings"
        TabControl1.ResumeLayout(False)
        TabPageShop.ResumeLayout(False)
        TabPageShop.PerformLayout()
        CType(SettingsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TabPageApplication.ResumeLayout(False)
        TabPageApplication.PerformLayout()
        TabPageDatabase.ResumeLayout(False)
        TabPageDatabase.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageShop As TabPage
    Friend WithEvents TxtCompanyPhone As TextBox
    Friend WithEvents TxtCompanyEmail As TextBox
    Friend WithEvents TxtCompanyWebsite As TextBox
    Friend WithEvents TxtCompanyContact As TextBox
    Friend WithEvents TxtCompanyAddress As TextBox
    Friend WithEvents TxtCompanyName As TextBox
    Friend WithEvents TabPageApplication As TabPage
    Friend WithEvents LabCompanyPhone As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabCompanyWebsite As Label
    Friend WithEvents LabCompanyEmail As Label
    Friend WithEvents LabCompanyAddress As Label
    Friend WithEvents LabCompanyName As Label
    Friend WithEvents SettingsBindingSource As BindingSource
    Friend WithEvents LabDefaultFolder As Label
    Friend WithEvents TxtDefaultFolder As TextBox
    Friend WithEvents CmdDefaultFolder As Button
    Friend WithEvents CmdUndo As Button
    Friend WithEvents CmdSave As Button
    Friend WithEvents TabPageDatabase As TabPage
    Friend WithEvents CmdDatabaseFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LabDatabasePath As Label
    Friend WithEvents TxtConnectionString As TextBox
    Friend WithEvents TxtDatabaseFile As TextBox
    Friend WithEvents LabDatabaseMaintenance As Label
    Friend WithEvents ComboDatabaseMaintenance As ComboBox
End Class
