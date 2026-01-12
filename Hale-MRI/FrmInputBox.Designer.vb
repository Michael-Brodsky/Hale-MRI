<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputBox
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
        CmdCancel = New Button()
        CmdOK = New Button()
        TxtInput = New TextBox()
        labPrompt = New Label()
        SuspendLayout()
        ' 
        ' CmdCancel
        ' 
        CmdCancel.DialogResult = DialogResult.Cancel
        CmdCancel.Enabled = False
        CmdCancel.Image = My.Resources.Resources.Cancel
        CmdCancel.Location = New Point(51, 87)
        CmdCancel.Name = "CmdCancel"
        CmdCancel.Size = New Size(38, 24)
        CmdCancel.TabIndex = 7
        CmdCancel.UseVisualStyleBackColor = True
        ' 
        ' CmdOK
        ' 
        CmdOK.DialogResult = DialogResult.OK
        CmdOK.Enabled = False
        CmdOK.Image = My.Resources.Resources.StatusOK_18_18
        CmdOK.Location = New Point(12, 87)
        CmdOK.Name = "CmdOK"
        CmdOK.Size = New Size(38, 24)
        CmdOK.TabIndex = 6
        CmdOK.UseVisualStyleBackColor = True
        ' 
        ' TxtInput
        ' 
        TxtInput.Location = New Point(12, 58)
        TxtInput.Name = "TxtInput"
        TxtInput.Size = New Size(319, 23)
        TxtInput.TabIndex = 8
        ' 
        ' labPrompt
        ' 
        labPrompt.AutoSize = True
        labPrompt.Location = New Point(12, 40)
        labPrompt.Name = "labPrompt"
        labPrompt.Size = New Size(41, 15)
        labPrompt.TabIndex = 9
        labPrompt.Text = "Label1"
        ' 
        ' FrmInputBox
        ' 
        AcceptButton = CmdOK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = CmdCancel
        ClientSize = New Size(343, 149)
        Controls.Add(labPrompt)
        Controls.Add(TxtInput)
        Controls.Add(CmdCancel)
        Controls.Add(CmdOK)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmInputBox"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmInputBox"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmdCancel As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents TxtInput As TextBox
    Friend WithEvents labPrompt As Label
End Class
