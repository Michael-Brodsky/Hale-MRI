<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartSummary
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Chart1 = New DataVisualization.Charting.Chart()
        TableLayoutPanel1 = New TableLayoutPanel()
        PitchTable = New TableLayoutPanel()
        BladeTable = New TableLayoutPanel()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Chart1
        ' 
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        TableLayoutPanel1.SetColumnSpan(Chart1, 2)
        Chart1.Dock = DockStyle.Fill
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(3, 3)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New Size(367, 148)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart1"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 88F))
        TableLayoutPanel1.Controls.Add(Chart1, 0, 0)
        TableLayoutPanel1.Controls.Add(PitchTable, 1, 1)
        TableLayoutPanel1.Controls.Add(BladeTable, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 65F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 35F))
        TableLayoutPanel1.Size = New Size(373, 238)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' PitchTable
        ' 
        PitchTable.ColumnCount = 2
        PitchTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        PitchTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        PitchTable.Dock = DockStyle.Fill
        PitchTable.Location = New Point(44, 154)
        PitchTable.Margin = New Padding(0)
        PitchTable.Name = "PitchTable"
        PitchTable.RowCount = 2
        PitchTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        PitchTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        PitchTable.Size = New Size(329, 84)
        PitchTable.TabIndex = 1
        ' 
        ' BladeTable
        ' 
        BladeTable.ColumnCount = 1
        BladeTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        BladeTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        BladeTable.Dock = DockStyle.Fill
        BladeTable.Location = New Point(0, 154)
        BladeTable.Margin = New Padding(0)
        BladeTable.Name = "BladeTable"
        BladeTable.RowCount = 1
        BladeTable.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        BladeTable.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        BladeTable.Size = New Size(44, 84)
        BladeTable.TabIndex = 2
        ' 
        ' ChartSummary
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "ChartSummary"
        Size = New Size(373, 238)
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PitchTable As TableLayoutPanel
    Friend WithEvents BladeTable As TableLayoutPanel

End Class
