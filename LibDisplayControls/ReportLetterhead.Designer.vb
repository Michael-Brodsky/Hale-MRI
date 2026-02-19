<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportLetterhead
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
        LetterheadPictureBox = New PictureBox()
        CType(LetterheadPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LetterheadPictureBox
        ' 
        LetterheadPictureBox.Dock = DockStyle.Fill
        LetterheadPictureBox.Location = New Point(0, 0)
        LetterheadPictureBox.MaximumSize = New Size(827, 111)
        LetterheadPictureBox.MinimumSize = New Size(16, 16)
        LetterheadPictureBox.Name = "LetterheadPictureBox"
        LetterheadPictureBox.Size = New Size(783, 109)
        LetterheadPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        LetterheadPictureBox.TabIndex = 28
        LetterheadPictureBox.TabStop = False
        ' 
        ' ReportLetterhead
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(LetterheadPictureBox)
        Name = "ReportLetterhead"
        Size = New Size(783, 109)
        CType(LetterheadPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LetterheadPictureBox As PictureBox

End Class
