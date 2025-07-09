<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecordNavigationBar
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecordNavigationBar))
        CmdGotoFirst = New Button()
        cmdGotoPrevious = New Button()
        TxtCurrentPosition = New TextBox()
        CmdGotoNext = New Button()
        CmdGotoLast = New Button()
        CmdAddNew = New Button()
        CmdDelete = New Button()
        CmdFind = New Button()
        TxtFind = New TextBox()
        CmdSave = New Button()
        CmdUndo = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        LabCaption = New Label()
        ChkToggleFilter = New CheckBox()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' CmdGotoFirst
        ' 
        CmdGotoFirst.Image = CType(resources.GetObject("CmdGotoFirst.Image"), Image)
        CmdGotoFirst.Location = New Point(88, 3)
        CmdGotoFirst.Margin = New Padding(3, 3, 0, 3)
        CmdGotoFirst.Name = "CmdGotoFirst"
        CmdGotoFirst.Size = New Size(38, 24)
        CmdGotoFirst.TabIndex = 0
        CmdGotoFirst.TextImageRelation = TextImageRelation.ImageBeforeText
        CmdGotoFirst.UseVisualStyleBackColor = True
        ' 
        ' cmdGotoPrevious
        ' 
        cmdGotoPrevious.Image = CType(resources.GetObject("cmdGotoPrevious.Image"), Image)
        cmdGotoPrevious.Location = New Point(126, 3)
        cmdGotoPrevious.Margin = New Padding(0, 3, 0, 3)
        cmdGotoPrevious.Name = "cmdGotoPrevious"
        cmdGotoPrevious.Size = New Size(38, 24)
        cmdGotoPrevious.TabIndex = 1
        cmdGotoPrevious.UseVisualStyleBackColor = True
        ' 
        ' TxtCurrentPosition
        ' 
        TxtCurrentPosition.Location = New Point(164, 3)
        TxtCurrentPosition.Margin = New Padding(0, 3, 0, 3)
        TxtCurrentPosition.Name = "TxtCurrentPosition"
        TxtCurrentPosition.Size = New Size(100, 23)
        TxtCurrentPosition.TabIndex = 2
        TxtCurrentPosition.TextAlign = HorizontalAlignment.Center
        ' 
        ' CmdGotoNext
        ' 
        CmdGotoNext.Image = CType(resources.GetObject("CmdGotoNext.Image"), Image)
        CmdGotoNext.Location = New Point(264, 3)
        CmdGotoNext.Margin = New Padding(0, 3, 0, 3)
        CmdGotoNext.Name = "CmdGotoNext"
        CmdGotoNext.Size = New Size(38, 24)
        CmdGotoNext.TabIndex = 3
        CmdGotoNext.UseVisualStyleBackColor = True
        ' 
        ' CmdGotoLast
        ' 
        CmdGotoLast.Image = CType(resources.GetObject("CmdGotoLast.Image"), Image)
        CmdGotoLast.Location = New Point(302, 3)
        CmdGotoLast.Margin = New Padding(0, 3, 3, 3)
        CmdGotoLast.Name = "CmdGotoLast"
        CmdGotoLast.Size = New Size(38, 24)
        CmdGotoLast.TabIndex = 4
        CmdGotoLast.UseVisualStyleBackColor = True
        ' 
        ' CmdAddNew
        ' 
        CmdAddNew.Image = CType(resources.GetObject("CmdAddNew.Image"), Image)
        CmdAddNew.Location = New Point(346, 3)
        CmdAddNew.Margin = New Padding(3, 3, 0, 3)
        CmdAddNew.Name = "CmdAddNew"
        CmdAddNew.Size = New Size(38, 24)
        CmdAddNew.TabIndex = 5
        CmdAddNew.UseVisualStyleBackColor = True
        ' 
        ' CmdDelete
        ' 
        CmdDelete.Image = CType(resources.GetObject("CmdDelete.Image"), Image)
        CmdDelete.Location = New Point(384, 3)
        CmdDelete.Margin = New Padding(0, 3, 3, 3)
        CmdDelete.Name = "CmdDelete"
        CmdDelete.Size = New Size(37, 24)
        CmdDelete.TabIndex = 6
        CmdDelete.UseVisualStyleBackColor = True
        ' 
        ' CmdFind
        ' 
        CmdFind.Image = CType(resources.GetObject("CmdFind.Image"), Image)
        CmdFind.Location = New Point(468, 3)
        CmdFind.Margin = New Padding(0, 3, 0, 3)
        CmdFind.Name = "CmdFind"
        CmdFind.Size = New Size(38, 24)
        CmdFind.TabIndex = 8
        CmdFind.UseVisualStyleBackColor = True
        ' 
        ' TxtFind
        ' 
        TxtFind.Location = New Point(506, 3)
        TxtFind.Margin = New Padding(0, 3, 3, 3)
        TxtFind.Name = "TxtFind"
        TxtFind.Size = New Size(141, 23)
        TxtFind.TabIndex = 9
        ' 
        ' CmdSave
        ' 
        CmdSave.Image = CType(resources.GetObject("CmdSave.Image"), Image)
        CmdSave.Location = New Point(653, 3)
        CmdSave.Margin = New Padding(3, 3, 0, 3)
        CmdSave.Name = "CmdSave"
        CmdSave.Size = New Size(38, 24)
        CmdSave.TabIndex = 10
        CmdSave.UseVisualStyleBackColor = True
        ' 
        ' CmdUndo
        ' 
        CmdUndo.Image = CType(resources.GetObject("CmdUndo.Image"), Image)
        CmdUndo.Location = New Point(691, 3)
        CmdUndo.Margin = New Padding(0, 3, 0, 3)
        CmdUndo.Name = "CmdUndo"
        CmdUndo.Size = New Size(38, 24)
        CmdUndo.TabIndex = 11
        CmdUndo.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.ColumnCount = 13
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(CmdGotoFirst, 1, 0)
        TableLayoutPanel1.Controls.Add(CmdUndo, 12, 0)
        TableLayoutPanel1.Controls.Add(cmdGotoPrevious, 2, 0)
        TableLayoutPanel1.Controls.Add(CmdSave, 11, 0)
        TableLayoutPanel1.Controls.Add(TxtCurrentPosition, 3, 0)
        TableLayoutPanel1.Controls.Add(TxtFind, 10, 0)
        TableLayoutPanel1.Controls.Add(CmdGotoNext, 4, 0)
        TableLayoutPanel1.Controls.Add(CmdFind, 9, 0)
        TableLayoutPanel1.Controls.Add(CmdGotoLast, 5, 0)
        TableLayoutPanel1.Controls.Add(CmdAddNew, 6, 0)
        TableLayoutPanel1.Controls.Add(CmdDelete, 7, 0)
        TableLayoutPanel1.Controls.Add(LabCaption, 0, 0)
        TableLayoutPanel1.Controls.Add(ChkToggleFilter, 8, 0)
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(729, 30)
        TableLayoutPanel1.TabIndex = 12
        ' 
        ' LabCaption
        ' 
        LabCaption.AutoSize = True
        LabCaption.Dock = DockStyle.Left
        LabCaption.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        LabCaption.Location = New Point(0, 0)
        LabCaption.Margin = New Padding(0, 0, 3, 0)
        LabCaption.Name = "LabCaption"
        LabCaption.Size = New Size(82, 30)
        LabCaption.TabIndex = 12
        LabCaption.Text = "Caption"
        LabCaption.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ChkToggleFilter
        ' 
        ChkToggleFilter.Appearance = Appearance.Button
        ChkToggleFilter.Image = My.Resources.Resources.Filter
        ChkToggleFilter.ImageAlign = ContentAlignment.TopLeft
        ChkToggleFilter.Location = New Point(427, 3)
        ChkToggleFilter.Name = "ChkToggleFilter"
        ChkToggleFilter.RightToLeft = RightToLeft.Yes
        ChkToggleFilter.Size = New Size(38, 24)
        ChkToggleFilter.TabIndex = 13
        ChkToggleFilter.Text = " "
        ChkToggleFilter.TextAlign = ContentAlignment.TopLeft
        ChkToggleFilter.TextImageRelation = TextImageRelation.TextBeforeImage
        ChkToggleFilter.UseVisualStyleBackColor = True
        ' 
        ' RecordNavigationBar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        Controls.Add(TableLayoutPanel1)
        Name = "RecordNavigationBar"
        Size = New Size(729, 30)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmdGotoFirst As Button
    Friend WithEvents cmdGotoPrevious As Button
    Friend WithEvents TxtCurrentPosition As TextBox
    Friend WithEvents CmdGotoNext As Button
    Friend WithEvents CmdGotoLast As Button
    Friend WithEvents CmdAddNew As Button
    Friend WithEvents CmdDelete As Button
    Friend WithEvents CmdFind As Button
    Friend WithEvents TxtFind As TextBox
    Friend WithEvents CmdSave As Button
    Friend WithEvents CmdUndo As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabCaption As Label
    Friend WithEvents ChkToggleFilter As CheckBox

End Class
