<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportsEditor
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
        DataGridReports = New DataGridView()
        EmployeesBindingSource = New BindingSource(components)
        ReportsBindingSource = New BindingSource(components)
        ReportName = New DataGridViewTextBoxColumn()
        LastModified = New DataGridViewTextBoxColumn()
        ModifiedBy = New DataGridViewComboBoxColumn()
        CType(DataGridReports, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridReports
        ' 
        DataGridReports.AutoGenerateColumns = False
        DataGridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridReports.Columns.AddRange(New DataGridViewColumn() {ReportName, LastModified, ModifiedBy})
        DataGridReports.DataSource = ReportsBindingSource
        DataGridReports.Location = New Point(12, 12)
        DataGridReports.Name = "DataGridReports"
        DataGridReports.Size = New Size(524, 377)
        DataGridReports.TabIndex = 0
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeesBindingSource.Sort = ""
        ' 
        ' ReportsBindingSource
        ' 
        ReportsBindingSource.Sort = ""
        ' 
        ' ReportName
        ' 
        ReportName.DataPropertyName = "ReportName"
        ReportName.HeaderText = "Report Name"
        ReportName.MinimumWidth = 140
        ReportName.Name = "ReportName"
        ReportName.Resizable = DataGridViewTriState.True
        ReportName.Width = 140
        ' 
        ' LastModified
        ' 
        LastModified.DataPropertyName = "LastModified"
        LastModified.HeaderText = "Last Modified"
        LastModified.MinimumWidth = 140
        LastModified.Name = "LastModified"
        LastModified.ReadOnly = True
        LastModified.Width = 140
        ' 
        ' ModifiedBy
        ' 
        ModifiedBy.DataPropertyName = "ModifiedBy"
        ModifiedBy.DataSource = EmployeesBindingSource
        ModifiedBy.DisplayMember = "EmployeeName"
        ModifiedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        ModifiedBy.HeaderText = "Modified By"
        ModifiedBy.MinimumWidth = 140
        ModifiedBy.Name = "ModifiedBy"
        ModifiedBy.ReadOnly = True
        ModifiedBy.Resizable = DataGridViewTriState.True
        ModifiedBy.SortMode = DataGridViewColumnSortMode.Automatic
        ModifiedBy.ValueMember = "Id"
        ModifiedBy.Width = 140
        ' 
        ' FrmReportsEditor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(550, 450)
        Controls.Add(DataGridReports)
        Name = "FrmReportsEditor"
        Text = "Reports Editor"
        CType(DataGridReports, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridReports As DataGridView
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ReportsBindingSource As BindingSource
    Friend WithEvents ReportName As DataGridViewTextBoxColumn
    Friend WithEvents LastModified As DataGridViewTextBoxColumn
    Friend WithEvents ModifiedBy As DataGridViewComboBoxColumn
End Class
