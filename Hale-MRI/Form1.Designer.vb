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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        RecordNavigationBar1 = New RecordNavigationBar()
        EncoderStatusStrip1 = New EncoderStatusStrip()
        JobDetailsBindingSource = New BindingSource(components)
        DataGridJobDetails = New DataGridView()
        StartDate = New DataGridViewTextBoxColumn()
        MeasurementTypeDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        MeasurementTypesBindingSource = New BindingSource(components)
        ToleranceClassDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        ClassBindingSource = New BindingSource(components)
        PerformedBy = New DataGridViewComboBoxColumn()
        EmployeesBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        TxtJobNumber = New TextBox()
        PanelJob = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtBlades = New TextBox()
        TxtDiameter = New TextBox()
        TxtBore = New TextBox()
        TxtCustomer = New TextBox()
        PanelMeasurements = New Panel()
        GridBladebyRadius = New DataGridView()
        PictureBoxLogo = New PictureBox()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelJob.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        PanelMeasurements.SuspendLayout()
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RecordNavigationBar1
        ' 
        RecordNavigationBar1.AutoSize = True
        RecordNavigationBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        RecordNavigationBar1.BoundControls = Nothing
        RecordNavigationBar1.Database = Nothing
        RecordNavigationBar1.Filter = Nothing
        RecordNavigationBar1.FilterOn = False
        RecordNavigationBar1.Location = New Point(522, 11)
        RecordNavigationBar1.Margin = New Padding(0)
        RecordNavigationBar1.MasterSource = Nothing
        RecordNavigationBar1.Name = "RecordNavigationBar1"
        RecordNavigationBar1.Size = New Size(635, 24)
        RecordNavigationBar1.TabIndex = 0
        ' 
        ' EncoderStatusStrip1
        ' 
        EncoderStatusStrip1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        EncoderStatusStrip1.Hardware = Nothing
        EncoderStatusStrip1.Location = New Point(-1, 648)
        EncoderStatusStrip1.Name = "EncoderStatusStrip1"
        EncoderStatusStrip1.Size = New Size(1145, 23)
        EncoderStatusStrip1.TabIndex = 1
        EncoderStatusStrip1.TimerInterval = 100L
        EncoderStatusStrip1.TimerOn = False
        EncoderStatusStrip1.WorkstationName = ""
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' DataGridJobDetails
        ' 
        DataGridJobDetails.AllowUserToAddRows = False
        DataGridJobDetails.AllowUserToDeleteRows = False
        DataGridJobDetails.AutoGenerateColumns = False
        DataGridJobDetails.BorderStyle = BorderStyle.Fixed3D
        DataGridJobDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobDetails.Columns.AddRange(New DataGridViewColumn() {StartDate, MeasurementTypeDataGridViewTextBoxColumn, ToleranceClassDataGridViewTextBoxColumn, PerformedBy, Description})
        DataGridJobDetails.DataSource = JobDetailsBindingSource
        DataGridJobDetails.Location = New Point(522, 48)
        DataGridJobDetails.Name = "DataGridJobDetails"
        DataGridJobDetails.ScrollBars = ScrollBars.None
        DataGridJobDetails.Size = New Size(635, 50)
        DataGridJobDetails.TabIndex = 4
        ' 
        ' StartDate
        ' 
        StartDate.DataPropertyName = "StartDate"
        StartDate.HeaderText = "Start Date"
        StartDate.MinimumWidth = 120
        StartDate.Name = "StartDate"
        StartDate.Width = 120
        ' 
        ' MeasurementTypeDataGridViewTextBoxColumn
        ' 
        MeasurementTypeDataGridViewTextBoxColumn.DataPropertyName = "MeasurementTypeId"
        MeasurementTypeDataGridViewTextBoxColumn.DataSource = MeasurementTypesBindingSource
        MeasurementTypeDataGridViewTextBoxColumn.DisplayMember = "MeasurementType1"
        MeasurementTypeDataGridViewTextBoxColumn.HeaderText = "Measurement"
        MeasurementTypeDataGridViewTextBoxColumn.MinimumWidth = 90
        MeasurementTypeDataGridViewTextBoxColumn.Name = "MeasurementTypeDataGridViewTextBoxColumn"
        MeasurementTypeDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        MeasurementTypeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        MeasurementTypeDataGridViewTextBoxColumn.ValueMember = "Id"
        MeasurementTypeDataGridViewTextBoxColumn.Width = 90
        ' 
        ' MeasurementTypesBindingSource
        ' 
        MeasurementTypesBindingSource.DataSource = GetType(LibDatabase.Models.MeasurementType)
        ' 
        ' ToleranceClassDataGridViewTextBoxColumn
        ' 
        ToleranceClassDataGridViewTextBoxColumn.DataPropertyName = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.DataSource = ClassBindingSource
        ToleranceClassDataGridViewTextBoxColumn.DisplayMember = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.HeaderText = "Class"
        ToleranceClassDataGridViewTextBoxColumn.MinimumWidth = 60
        ToleranceClassDataGridViewTextBoxColumn.Name = "ToleranceClassDataGridViewTextBoxColumn"
        ToleranceClassDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        ToleranceClassDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        ToleranceClassDataGridViewTextBoxColumn.ValueMember = "ToleranceClass"
        ToleranceClassDataGridViewTextBoxColumn.Width = 60
        ' 
        ' ClassBindingSource
        ' 
        ClassBindingSource.DataSource = GetType(LibDatabase.Models.Tolerance)
        ' 
        ' PerformedBy
        ' 
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeesBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.HeaderText = "Employee"
        PerformedBy.MinimumWidth = 130
        PerformedBy.Name = "PerformedBy"
        PerformedBy.Resizable = DataGridViewTriState.True
        PerformedBy.SortMode = DataGridViewColumnSortMode.Automatic
        PerformedBy.ValueMember = "Id"
        PerformedBy.Width = 130
        ' 
        ' EmployeesBindingSource
        ' 
        EmployeesBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeesBindingSource.Sort = ""
        ' 
        ' Description
        ' 
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.Name = "Description"
        Description.Width = 200
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BackColor = SystemColors.Control
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        TxtJobNumber.Location = New Point(258, 11)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.Size = New Size(258, 25)
        TxtJobNumber.TabIndex = 6
        TxtJobNumber.TextAlign = HorizontalAlignment.Right
        ' 
        ' PanelJob
        ' 
        PanelJob.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelJob.BorderStyle = BorderStyle.Fixed3D
        PanelJob.Controls.Add(TableLayoutPanel1)
        PanelJob.Location = New Point(12, 111)
        PanelJob.Name = "PanelJob"
        PanelJob.Size = New Size(191, 531)
        PanelJob.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(TxtVessel, 0, 1)
        TableLayoutPanel1.Controls.Add(TxtManufacturer, 0, 2)
        TableLayoutPanel1.Controls.Add(TxtStyle, 0, 3)
        TableLayoutPanel1.Controls.Add(TxtMaterial, 0, 4)
        TableLayoutPanel1.Controls.Add(TxtBlades, 0, 5)
        TableLayoutPanel1.Controls.Add(TxtDiameter, 0, 6)
        TableLayoutPanel1.Controls.Add(TxtBore, 0, 7)
        TableLayoutPanel1.Controls.Add(TxtCustomer, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 8
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(187, 120)
        TableLayoutPanel1.TabIndex = 6
        ' 
        ' TxtVessel
        ' 
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.Font = New Font("Segoe UI", 8F)
        TxtVessel.Location = New Point(3, 15)
        TxtVessel.Margin = New Padding(3, 0, 3, 0)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(177, 15)
        TxtVessel.TabIndex = 2
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.Font = New Font("Segoe UI", 8F)
        TxtManufacturer.Location = New Point(3, 30)
        TxtManufacturer.Margin = New Padding(3, 0, 3, 0)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(177, 15)
        TxtManufacturer.TabIndex = 4
        ' 
        ' TxtStyle
        ' 
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Font = New Font("Segoe UI", 8F)
        TxtStyle.Location = New Point(3, 45)
        TxtStyle.Margin = New Padding(3, 0, 3, 0)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(177, 15)
        TxtStyle.TabIndex = 0
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Font = New Font("Segoe UI", 8F)
        TxtMaterial.Location = New Point(3, 60)
        TxtMaterial.Margin = New Padding(3, 0, 3, 0)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(175, 15)
        TxtMaterial.TabIndex = 8
        ' 
        ' TxtBlades
        ' 
        TxtBlades.BorderStyle = BorderStyle.None
        TxtBlades.Font = New Font("Segoe UI", 8F)
        TxtBlades.Location = New Point(3, 75)
        TxtBlades.Margin = New Padding(3, 0, 3, 0)
        TxtBlades.Name = "TxtBlades"
        TxtBlades.ReadOnly = True
        TxtBlades.Size = New Size(175, 15)
        TxtBlades.TabIndex = 5
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.BorderStyle = BorderStyle.None
        TxtDiameter.Font = New Font("Segoe UI", 8F)
        TxtDiameter.Location = New Point(3, 90)
        TxtDiameter.Margin = New Padding(3, 0, 3, 0)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.ReadOnly = True
        TxtDiameter.Size = New Size(175, 15)
        TxtDiameter.TabIndex = 6
        ' 
        ' TxtBore
        ' 
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Font = New Font("Segoe UI", 8F)
        TxtBore.Location = New Point(3, 105)
        TxtBore.Margin = New Padding(3, 0, 3, 0)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(175, 15)
        TxtBore.TabIndex = 7
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.Font = New Font("Segoe UI", 8F)
        TxtCustomer.Location = New Point(3, 0)
        TxtCustomer.Margin = New Padding(3, 0, 3, 0)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(177, 15)
        TxtCustomer.TabIndex = 1
        ' 
        ' PanelMeasurements
        ' 
        PanelMeasurements.BorderStyle = BorderStyle.Fixed3D
        PanelMeasurements.Controls.Add(GridBladebyRadius)
        PanelMeasurements.Location = New Point(215, 111)
        PanelMeasurements.Name = "PanelMeasurements"
        PanelMeasurements.Size = New Size(942, 531)
        PanelMeasurements.TabIndex = 8
        ' 
        ' GridBladebyRadius
        ' 
        GridBladebyRadius.AllowUserToAddRows = False
        GridBladebyRadius.AllowUserToDeleteRows = False
        GridBladebyRadius.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        GridBladebyRadius.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        GridBladebyRadius.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBladebyRadius.Location = New Point(14, 232)
        GridBladebyRadius.Name = "GridBladebyRadius"
        GridBladebyRadius.Size = New Size(576, 181)
        GridBladebyRadius.TabIndex = 0
        ' 
        ' PictureBoxLogo
        ' 
        PictureBoxLogo.Image = CType(resources.GetObject("PictureBoxLogo.Image"), Image)
        PictureBoxLogo.InitialImage = CType(resources.GetObject("PictureBoxLogo.InitialImage"), Image)
        PictureBoxLogo.Location = New Point(12, 12)
        PictureBoxLogo.Name = "PictureBoxLogo"
        PictureBoxLogo.Size = New Size(189, 86)
        PictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxLogo.TabIndex = 9
        PictureBoxLogo.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1193, 671)
        Controls.Add(PictureBoxLogo)
        Controls.Add(PanelMeasurements)
        Controls.Add(PanelJob)
        Controls.Add(TxtJobNumber)
        Controls.Add(DataGridJobDetails)
        Controls.Add(EncoderStatusStrip1)
        Controls.Add(RecordNavigationBar1)
        Name = "Form1"
        Text = "Measurements"
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ClassBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelJob.ResumeLayout(False)
        PanelJob.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        PanelMeasurements.ResumeLayout(False)
        CType(GridBladebyRadius, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RecordNavigationBar1 As RecordNavigationBar
    Friend WithEvents EncoderStatusStrip1 As EncoderStatusStrip
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents DataGridJobDetails As DataGridView
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents ClassBindingSource As BindingSource
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents PanelJob As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtBlades As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents PanelMeasurements As Panel
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents MeasurementTypesBindingSource As BindingSource
    Friend WithEvents StartDate As DataGridViewTextBoxColumn
    Friend WithEvents MeasurementTypeDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents ToleranceClassDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents GridBladebyRadius As DataGridView
End Class
