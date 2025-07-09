<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        DataGridView1 = New DataGridView()
        CustomerName = New DataGridViewTextBoxColumn()
        RecordNavigationBar1 = New RecordNavigationBar()
        DataGridView2 = New DataGridView()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        VesselBindingSource = New BindingSource(components)
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {CustomerName})
        DataGridView1.Location = New Point(57, 84)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1275, 195)
        DataGridView1.TabIndex = 0
        ' 
        ' CustomerName
        ' 
        CustomerName.DataPropertyName = "CustomerName"
        CustomerName.HeaderText = "Customer Name"
        CustomerName.MinimumWidth = 10
        CustomerName.Name = "CustomerName"
        CustomerName.Width = 200
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.BoundControl = Nothing
        RecordNavigationBar1.Caption = "Caption"
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = ""
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(57, 57)
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.RecordSource = Nothing
        RecordNavigationBar1.Size = New Size(729, 30)
        RecordNavigationBar1.TabIndex = 1
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AutoGenerateColumns = False
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn})
        DataGridView2.DataSource = VesselBindingSource
        DataGridView2.Location = New Point(57, 322)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.Size = New Size(374, 150)
        DataGridView2.TabIndex = 2
        ' 
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "VesselName"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 10
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.Width = 200
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1422, 621)
        Controls.Add(DataGridView2)
        Controls.Add(RecordNavigationBar1)
        Controls.Add(DataGridView1)
        Name = "Form1"
        Text = "Form1"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VesselBindingSource As BindingSource
End Class
