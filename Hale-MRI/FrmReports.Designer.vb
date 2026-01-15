<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReports
    Inherits FrmDatabaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReports))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        MeasurementDataBindingSource = New BindingSource(components)
        HeaderLayoutPanel = New TableLayoutPanel()
        TxtWheelPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        TxtMeasuredDiameter = New TextBox()
        TxtMarkedDiameter = New TextBox()
        TxtRotation = New TextBox()
        TxtPerformedBy = New TextBox()
        TxtScanDate = New TextBox()
        TxtFileName = New TextBox()
        Label1 = New Label()
        TxtJobId = New TextBox()
        LabJobId = New Label()
        LabJobNumber = New Label()
        LabCustomer = New Label()
        LabVessel = New Label()
        LabManufacturer = New Label()
        LabPartNumber = New Label()
        LabSerialNumber = New Label()
        LabStampNumber = New Label()
        LabInspectedBy = New Label()
        TxtJobNumber = New TextBox()
        TxtCustomer = New TextBox()
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        TxtPartNumber = New TextBox()
        TxtSerialNumber = New TextBox()
        TxtStampNumber = New TextBox()
        TxtInspectedBy = New TextBox()
        LabClass = New Label()
        LabRepairStatus = New Label()
        LabStyle = New Label()
        LabMaterial = New Label()
        LabBore = New Label()
        LabDAR = New Label()
        LabCup = New Label()
        TxtClass = New TextBox()
        TxtRepairStatus = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtBore = New TextBox()
        TxtDAR = New TextBox()
        TxtCup = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PageSetupDialog1 = New PageSetupDialog()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        OpenToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        CloseToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        SaveToolStripMenuItem = New ToolStripMenuItem()
        SaveAsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        PrintToolStripMenuItem = New ToolStripMenuItem()
        PrintToolStripMenuItem1 = New ToolStripMenuItem()
        PrintPreviewToolStripMenuItem = New ToolStripMenuItem()
        PageSetupToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        EditToolStripMenuItem = New ToolStripMenuItem()
        CutToolStripMenuItem = New ToolStripMenuItem()
        CopyToolStripMenuItem = New ToolStripMenuItem()
        PasteToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        ReportsToolStripMenuItem = New ToolStripMenuItem()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ReportBindingSource = New BindingSource(components)
        TableReports = New TableLayoutPanel()
        labReports = New Label()
        ListReports = New ListBox()
        GrdRadiiAverages = New DataGridView()
        GrdChordLength = New DataGridView()
        Chart1 = New DataVisualization.Charting.Chart()
        Chart2 = New DataVisualization.Charting.Chart()
        Chart3 = New DataVisualization.Charting.Chart()
        DataGridJobs = New DataGridView()
        JobNumber = New DataGridViewComboBoxColumn()
        JobBindingSource = New BindingSource(components)
        DescriptionDataGridViewTextBoxColumn = New DataGridViewComboBoxColumn()
        MeasurementTypeBindingSource = New BindingSource(components)
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PerformedBy = New DataGridViewComboBoxColumn()
        EmployeeBindingSource = New BindingSource(components)
        Description = New DataGridViewTextBoxColumn()
        JobDetailsBindingSource = New BindingSource(components)
        ContextMenuStrip1 = New ContextMenuStrip(components)
        UndoToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        CutToolStripMenuItem1 = New ToolStripMenuItem()
        PasteToolStripMenuItem1 = New ToolStripMenuItem()
        DeleteToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        SelectAllToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator7 = New ToolStripSeparator()
        AddNewToolStripMenuItem = New ToolStripMenuItem()
        Chart4 = New DataVisualization.Charting.Chart()
        Chart5 = New DataVisualization.Charting.Chart()
        Chart6 = New DataVisualization.Charting.Chart()
        Chart7 = New DataVisualization.Charting.Chart()
        Chart8 = New DataVisualization.Charting.Chart()
        Chart9 = New DataVisualization.Charting.Chart()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripMenuItem()
        ElementsToolStripMenuItem = New ToolStripMenuItem()
        CType(MeasurementDataBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        HeaderLayoutPanel.SuspendLayout()
        MenuStrip1.SuspendLayout()
        CType(ReportBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableReports.SuspendLayout()
        CType(GrdRadiiAverages, ComponentModel.ISupportInitialize).BeginInit()
        CType(GrdChordLength, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart3, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridJobs, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(MeasurementTypeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        CType(Chart4, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart5, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart6, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart7, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart8, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart9, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MeasurementDataBindingSource
        ' 
        MeasurementDataBindingSource.AllowNew = False
        MeasurementDataBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' HeaderLayoutPanel
        ' 
        HeaderLayoutPanel.ColumnCount = 6
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        HeaderLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
        HeaderLayoutPanel.Controls.Add(TxtWheelPitch, 5, 7)
        HeaderLayoutPanel.Controls.Add(TxtMarkedPitch, 5, 6)
        HeaderLayoutPanel.Controls.Add(TxtMeasuredDiameter, 5, 5)
        HeaderLayoutPanel.Controls.Add(TxtMarkedDiameter, 5, 4)
        HeaderLayoutPanel.Controls.Add(TxtRotation, 5, 3)
        HeaderLayoutPanel.Controls.Add(TxtPerformedBy, 5, 2)
        HeaderLayoutPanel.Controls.Add(TxtScanDate, 5, 1)
        HeaderLayoutPanel.Controls.Add(TxtFileName, 5, 0)
        HeaderLayoutPanel.Controls.Add(Label1, 4, 0)
        HeaderLayoutPanel.Controls.Add(TxtJobId, 3, 0)
        HeaderLayoutPanel.Controls.Add(LabJobId, 2, 0)
        HeaderLayoutPanel.Controls.Add(LabJobNumber, 0, 0)
        HeaderLayoutPanel.Controls.Add(LabCustomer, 0, 1)
        HeaderLayoutPanel.Controls.Add(LabVessel, 0, 2)
        HeaderLayoutPanel.Controls.Add(LabManufacturer, 0, 3)
        HeaderLayoutPanel.Controls.Add(LabPartNumber, 0, 4)
        HeaderLayoutPanel.Controls.Add(LabSerialNumber, 0, 5)
        HeaderLayoutPanel.Controls.Add(LabStampNumber, 0, 6)
        HeaderLayoutPanel.Controls.Add(LabInspectedBy, 0, 7)
        HeaderLayoutPanel.Controls.Add(TxtJobNumber, 1, 0)
        HeaderLayoutPanel.Controls.Add(TxtCustomer, 1, 1)
        HeaderLayoutPanel.Controls.Add(TxtVessel, 1, 2)
        HeaderLayoutPanel.Controls.Add(TxtManufacturer, 1, 3)
        HeaderLayoutPanel.Controls.Add(TxtPartNumber, 1, 4)
        HeaderLayoutPanel.Controls.Add(TxtSerialNumber, 1, 5)
        HeaderLayoutPanel.Controls.Add(TxtStampNumber, 1, 6)
        HeaderLayoutPanel.Controls.Add(TxtInspectedBy, 1, 7)
        HeaderLayoutPanel.Controls.Add(LabClass, 2, 1)
        HeaderLayoutPanel.Controls.Add(LabRepairStatus, 2, 2)
        HeaderLayoutPanel.Controls.Add(LabStyle, 2, 3)
        HeaderLayoutPanel.Controls.Add(LabMaterial, 2, 4)
        HeaderLayoutPanel.Controls.Add(LabBore, 2, 5)
        HeaderLayoutPanel.Controls.Add(LabDAR, 2, 6)
        HeaderLayoutPanel.Controls.Add(LabCup, 2, 7)
        HeaderLayoutPanel.Controls.Add(TxtClass, 3, 1)
        HeaderLayoutPanel.Controls.Add(TxtRepairStatus, 3, 2)
        HeaderLayoutPanel.Controls.Add(TxtStyle, 3, 3)
        HeaderLayoutPanel.Controls.Add(TxtMaterial, 3, 4)
        HeaderLayoutPanel.Controls.Add(TxtBore, 3, 5)
        HeaderLayoutPanel.Controls.Add(TxtDAR, 3, 6)
        HeaderLayoutPanel.Controls.Add(TxtCup, 3, 7)
        HeaderLayoutPanel.Controls.Add(Label2, 4, 1)
        HeaderLayoutPanel.Controls.Add(Label3, 4, 2)
        HeaderLayoutPanel.Controls.Add(Label7, 4, 6)
        HeaderLayoutPanel.Controls.Add(Label8, 4, 7)
        HeaderLayoutPanel.Controls.Add(Label5, 4, 5)
        HeaderLayoutPanel.Controls.Add(Label4, 4, 4)
        HeaderLayoutPanel.Controls.Add(Label6, 4, 3)
        HeaderLayoutPanel.Location = New Point(12, 160)
        HeaderLayoutPanel.Name = "HeaderLayoutPanel"
        HeaderLayoutPanel.RowCount = 8
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        HeaderLayoutPanel.Size = New Size(827, 219)
        HeaderLayoutPanel.TabIndex = 0
        HeaderLayoutPanel.Visible = False
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.Anchor = AnchorStyles.Left
        TxtWheelPitch.BorderStyle = BorderStyle.None
        TxtWheelPitch.Location = New Point(653, 196)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.ReadOnly = True
        TxtWheelPitch.Size = New Size(168, 16)
        TxtWheelPitch.TabIndex = 49
        ' 
        ' TxtMarkedPitch
        ' 
        TxtMarkedPitch.Anchor = AnchorStyles.Left
        TxtMarkedPitch.BorderStyle = BorderStyle.None
        TxtMarkedPitch.Location = New Point(653, 167)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.ReadOnly = True
        TxtMarkedPitch.Size = New Size(168, 16)
        TxtMarkedPitch.TabIndex = 48
        ' 
        ' TxtMeasuredDiameter
        ' 
        TxtMeasuredDiameter.Anchor = AnchorStyles.Left
        TxtMeasuredDiameter.BorderStyle = BorderStyle.None
        TxtMeasuredDiameter.Location = New Point(653, 140)
        TxtMeasuredDiameter.Name = "TxtMeasuredDiameter"
        TxtMeasuredDiameter.ReadOnly = True
        TxtMeasuredDiameter.Size = New Size(168, 16)
        TxtMeasuredDiameter.TabIndex = 47
        ' 
        ' TxtMarkedDiameter
        ' 
        TxtMarkedDiameter.Anchor = AnchorStyles.Left
        TxtMarkedDiameter.BorderStyle = BorderStyle.None
        TxtMarkedDiameter.Location = New Point(653, 113)
        TxtMarkedDiameter.Name = "TxtMarkedDiameter"
        TxtMarkedDiameter.ReadOnly = True
        TxtMarkedDiameter.Size = New Size(168, 16)
        TxtMarkedDiameter.TabIndex = 46
        ' 
        ' TxtRotation
        ' 
        TxtRotation.Anchor = AnchorStyles.Left
        TxtRotation.BorderStyle = BorderStyle.None
        TxtRotation.Location = New Point(653, 86)
        TxtRotation.Name = "TxtRotation"
        TxtRotation.ReadOnly = True
        TxtRotation.Size = New Size(168, 16)
        TxtRotation.TabIndex = 45
        ' 
        ' TxtPerformedBy
        ' 
        TxtPerformedBy.Anchor = AnchorStyles.Left
        TxtPerformedBy.BorderStyle = BorderStyle.None
        TxtPerformedBy.Location = New Point(653, 59)
        TxtPerformedBy.Name = "TxtPerformedBy"
        TxtPerformedBy.ReadOnly = True
        TxtPerformedBy.Size = New Size(168, 16)
        TxtPerformedBy.TabIndex = 44
        ' 
        ' TxtScanDate
        ' 
        TxtScanDate.Anchor = AnchorStyles.Left
        TxtScanDate.BorderStyle = BorderStyle.None
        TxtScanDate.Location = New Point(653, 32)
        TxtScanDate.Name = "TxtScanDate"
        TxtScanDate.ReadOnly = True
        TxtScanDate.Size = New Size(168, 16)
        TxtScanDate.TabIndex = 43
        ' 
        ' TxtFileName
        ' 
        TxtFileName.Anchor = AnchorStyles.Left
        TxtFileName.BorderStyle = BorderStyle.None
        TxtFileName.Location = New Point(653, 5)
        TxtFileName.Name = "TxtFileName"
        TxtFileName.ReadOnly = True
        TxtFileName.Size = New Size(168, 16)
        TxtFileName.TabIndex = 42
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label1.Location = New Point(553, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 15)
        Label1.TabIndex = 34
        Label1.Text = "File Name"
        ' 
        ' TxtJobId
        ' 
        TxtJobId.Anchor = AnchorStyles.Left
        TxtJobId.BorderStyle = BorderStyle.None
        TxtJobId.Location = New Point(378, 5)
        TxtJobId.Name = "TxtJobId"
        TxtJobId.ReadOnly = True
        TxtJobId.Size = New Size(165, 16)
        TxtJobId.TabIndex = 26
        ' 
        ' LabJobId
        ' 
        LabJobId.Anchor = AnchorStyles.Left
        LabJobId.AutoSize = True
        LabJobId.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabJobId.Location = New Point(278, 6)
        LabJobId.Name = "LabJobId"
        LabJobId.Size = New Size(40, 15)
        LabJobId.TabIndex = 18
        LabJobId.Text = "Job Id"
        ' 
        ' LabJobNumber
        ' 
        LabJobNumber.Anchor = AnchorStyles.Left
        LabJobNumber.AutoSize = True
        LabJobNumber.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabJobNumber.Location = New Point(3, 6)
        LabJobNumber.Name = "LabJobNumber"
        LabJobNumber.Size = New Size(48, 15)
        LabJobNumber.TabIndex = 0
        LabJobNumber.Text = "Job No."
        ' 
        ' LabCustomer
        ' 
        LabCustomer.Anchor = AnchorStyles.Left
        LabCustomer.AutoSize = True
        LabCustomer.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabCustomer.Location = New Point(3, 33)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(61, 15)
        LabCustomer.TabIndex = 3
        LabCustomer.Text = "Customer"
        ' 
        ' LabVessel
        ' 
        LabVessel.Anchor = AnchorStyles.Left
        LabVessel.AutoSize = True
        LabVessel.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabVessel.Location = New Point(3, 60)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(41, 15)
        LabVessel.TabIndex = 4
        LabVessel.Text = "Vessel"
        ' 
        ' LabManufacturer
        ' 
        LabManufacturer.Anchor = AnchorStyles.Left
        LabManufacturer.AutoSize = True
        LabManufacturer.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabManufacturer.Location = New Point(3, 87)
        LabManufacturer.Name = "LabManufacturer"
        LabManufacturer.Size = New Size(84, 15)
        LabManufacturer.TabIndex = 5
        LabManufacturer.Text = "Manufacturer"
        ' 
        ' LabPartNumber
        ' 
        LabPartNumber.Anchor = AnchorStyles.Left
        LabPartNumber.AutoSize = True
        LabPartNumber.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabPartNumber.Location = New Point(3, 114)
        LabPartNumber.Name = "LabPartNumber"
        LabPartNumber.Size = New Size(52, 15)
        LabPartNumber.TabIndex = 6
        LabPartNumber.Text = "Part No."
        ' 
        ' LabSerialNumber
        ' 
        LabSerialNumber.Anchor = AnchorStyles.Left
        LabSerialNumber.AutoSize = True
        LabSerialNumber.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabSerialNumber.Location = New Point(3, 141)
        LabSerialNumber.Name = "LabSerialNumber"
        LabSerialNumber.Size = New Size(28, 15)
        LabSerialNumber.TabIndex = 7
        LabSerialNumber.Text = "S/N"
        ' 
        ' LabStampNumber
        ' 
        LabStampNumber.Anchor = AnchorStyles.Left
        LabStampNumber.AutoSize = True
        LabStampNumber.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabStampNumber.Location = New Point(3, 168)
        LabStampNumber.Name = "LabStampNumber"
        LabStampNumber.Size = New Size(65, 15)
        LabStampNumber.TabIndex = 8
        LabStampNumber.Text = "Stamp No."
        ' 
        ' LabInspectedBy
        ' 
        LabInspectedBy.Anchor = AnchorStyles.Left
        LabInspectedBy.AutoSize = True
        LabInspectedBy.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabInspectedBy.Location = New Point(3, 196)
        LabInspectedBy.Name = "LabInspectedBy"
        LabInspectedBy.Size = New Size(79, 15)
        LabInspectedBy.TabIndex = 9
        LabInspectedBy.Text = "Inspected By"
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.Anchor = AnchorStyles.Left
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Location = New Point(103, 5)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.ReadOnly = True
        TxtJobNumber.Size = New Size(165, 16)
        TxtJobNumber.TabIndex = 10
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.Anchor = AnchorStyles.Left
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.Location = New Point(103, 32)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(165, 16)
        TxtCustomer.TabIndex = 11
        ' 
        ' TxtVessel
        ' 
        TxtVessel.Anchor = AnchorStyles.Left
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.Location = New Point(103, 59)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(165, 16)
        TxtVessel.TabIndex = 12
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.Anchor = AnchorStyles.Left
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.Location = New Point(103, 86)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(165, 16)
        TxtManufacturer.TabIndex = 13
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.Anchor = AnchorStyles.Left
        TxtPartNumber.BorderStyle = BorderStyle.None
        TxtPartNumber.Location = New Point(103, 113)
        TxtPartNumber.Name = "TxtPartNumber"
        TxtPartNumber.ReadOnly = True
        TxtPartNumber.Size = New Size(165, 16)
        TxtPartNumber.TabIndex = 14
        ' 
        ' TxtSerialNumber
        ' 
        TxtSerialNumber.Anchor = AnchorStyles.Left
        TxtSerialNumber.BorderStyle = BorderStyle.None
        TxtSerialNumber.Location = New Point(103, 140)
        TxtSerialNumber.Name = "TxtSerialNumber"
        TxtSerialNumber.ReadOnly = True
        TxtSerialNumber.Size = New Size(165, 16)
        TxtSerialNumber.TabIndex = 15
        ' 
        ' TxtStampNumber
        ' 
        TxtStampNumber.Anchor = AnchorStyles.Left
        TxtStampNumber.BorderStyle = BorderStyle.None
        TxtStampNumber.Location = New Point(103, 167)
        TxtStampNumber.Name = "TxtStampNumber"
        TxtStampNumber.ReadOnly = True
        TxtStampNumber.Size = New Size(165, 16)
        TxtStampNumber.TabIndex = 16
        ' 
        ' TxtInspectedBy
        ' 
        TxtInspectedBy.Anchor = AnchorStyles.Left
        TxtInspectedBy.BorderStyle = BorderStyle.None
        TxtInspectedBy.Location = New Point(103, 196)
        TxtInspectedBy.Name = "TxtInspectedBy"
        TxtInspectedBy.ReadOnly = True
        TxtInspectedBy.Size = New Size(165, 16)
        TxtInspectedBy.TabIndex = 17
        ' 
        ' LabClass
        ' 
        LabClass.Anchor = AnchorStyles.Left
        LabClass.AutoSize = True
        LabClass.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabClass.Location = New Point(278, 33)
        LabClass.Name = "LabClass"
        LabClass.Size = New Size(33, 15)
        LabClass.TabIndex = 19
        LabClass.Text = "Class"
        ' 
        ' LabRepairStatus
        ' 
        LabRepairStatus.Anchor = AnchorStyles.Left
        LabRepairStatus.AutoSize = True
        LabRepairStatus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabRepairStatus.Location = New Point(278, 60)
        LabRepairStatus.Name = "LabRepairStatus"
        LabRepairStatus.Size = New Size(81, 15)
        LabRepairStatus.TabIndex = 20
        LabRepairStatus.Text = "Repair Status"
        ' 
        ' LabStyle
        ' 
        LabStyle.Anchor = AnchorStyles.Left
        LabStyle.AutoSize = True
        LabStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabStyle.Location = New Point(278, 87)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(35, 15)
        LabStyle.TabIndex = 21
        LabStyle.Text = "Style"
        ' 
        ' LabMaterial
        ' 
        LabMaterial.Anchor = AnchorStyles.Left
        LabMaterial.AutoSize = True
        LabMaterial.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabMaterial.Location = New Point(278, 114)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(53, 15)
        LabMaterial.TabIndex = 22
        LabMaterial.Text = "Material"
        ' 
        ' LabBore
        ' 
        LabBore.Anchor = AnchorStyles.Left
        LabBore.AutoSize = True
        LabBore.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabBore.Location = New Point(278, 141)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(34, 15)
        LabBore.TabIndex = 23
        LabBore.Text = "Bore"
        ' 
        ' LabDAR
        ' 
        LabDAR.Anchor = AnchorStyles.Left
        LabDAR.AutoSize = True
        LabDAR.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabDAR.Location = New Point(278, 168)
        LabDAR.Name = "LabDAR"
        LabDAR.Size = New Size(32, 15)
        LabDAR.TabIndex = 24
        LabDAR.Text = "DAR"
        ' 
        ' LabCup
        ' 
        LabCup.Anchor = AnchorStyles.Left
        LabCup.AutoSize = True
        LabCup.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        LabCup.Location = New Point(278, 196)
        LabCup.Name = "LabCup"
        LabCup.Size = New Size(28, 15)
        LabCup.TabIndex = 25
        LabCup.Text = "Cup"
        ' 
        ' TxtClass
        ' 
        TxtClass.Anchor = AnchorStyles.Left
        TxtClass.BorderStyle = BorderStyle.None
        TxtClass.Location = New Point(378, 32)
        TxtClass.Name = "TxtClass"
        TxtClass.ReadOnly = True
        TxtClass.Size = New Size(165, 16)
        TxtClass.TabIndex = 27
        ' 
        ' TxtRepairStatus
        ' 
        TxtRepairStatus.Anchor = AnchorStyles.Left
        TxtRepairStatus.BorderStyle = BorderStyle.None
        TxtRepairStatus.Location = New Point(378, 59)
        TxtRepairStatus.Name = "TxtRepairStatus"
        TxtRepairStatus.ReadOnly = True
        TxtRepairStatus.Size = New Size(165, 16)
        TxtRepairStatus.TabIndex = 28
        ' 
        ' TxtStyle
        ' 
        TxtStyle.Anchor = AnchorStyles.Left
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Location = New Point(378, 86)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(165, 16)
        TxtStyle.TabIndex = 29
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.Anchor = AnchorStyles.Left
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Location = New Point(378, 113)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(165, 16)
        TxtMaterial.TabIndex = 30
        ' 
        ' TxtBore
        ' 
        TxtBore.Anchor = AnchorStyles.Left
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Location = New Point(378, 140)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(165, 16)
        TxtBore.TabIndex = 31
        ' 
        ' TxtDAR
        ' 
        TxtDAR.Anchor = AnchorStyles.Left
        TxtDAR.BorderStyle = BorderStyle.None
        TxtDAR.Location = New Point(378, 167)
        TxtDAR.Name = "TxtDAR"
        TxtDAR.ReadOnly = True
        TxtDAR.Size = New Size(165, 16)
        TxtDAR.TabIndex = 32
        ' 
        ' TxtCup
        ' 
        TxtCup.Anchor = AnchorStyles.Left
        TxtCup.BorderStyle = BorderStyle.None
        TxtCup.Location = New Point(378, 196)
        TxtCup.Name = "TxtCup"
        TxtCup.ReadOnly = True
        TxtCup.Size = New Size(165, 16)
        TxtCup.TabIndex = 33
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label2.Location = New Point(553, 33)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 35
        Label2.Text = "Scan Date"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label3.Location = New Point(553, 60)
        Label3.Name = "Label3"
        Label3.Size = New Size(85, 15)
        Label3.TabIndex = 36
        Label3.Text = "Performed By"
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Left
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label7.Location = New Point(553, 168)
        Label7.Name = "Label7"
        Label7.Size = New Size(81, 15)
        Label7.TabIndex = 40
        Label7.Text = "Marked Pitch"
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.Left
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label8.Location = New Point(553, 196)
        Label8.Name = "Label8"
        Label8.Size = New Size(74, 15)
        Label8.TabIndex = 41
        Label8.Text = "Wheel Pitch"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Left
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label5.Location = New Point(553, 141)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 15)
        Label5.TabIndex = 38
        Label5.Text = "Measured Dia"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Left
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label4.Location = New Point(553, 114)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 15)
        Label4.TabIndex = 37
        Label4.Text = "Marked Dia"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Left
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label6.Location = New Point(553, 87)
        Label6.Name = "Label6"
        Label6.Size = New Size(55, 15)
        Label6.TabIndex = 39
        Label6.Text = "Rotation"
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, ReportsToolStripMenuItem, ElementsToolStripMenuItem, SettingsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(850, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenToolStripMenuItem, ToolStripSeparator1, CloseToolStripMenuItem, ToolStripSeparator3, SaveToolStripMenuItem, SaveAsToolStripMenuItem, ToolStripSeparator4, PrintToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' OpenToolStripMenuItem
        ' 
        OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        OpenToolStripMenuItem.Size = New Size(114, 22)
        OpenToolStripMenuItem.Text = "Open"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(111, 6)
        ' 
        ' CloseToolStripMenuItem
        ' 
        CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        CloseToolStripMenuItem.Size = New Size(114, 22)
        CloseToolStripMenuItem.Text = "Close"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(111, 6)
        ' 
        ' SaveToolStripMenuItem
        ' 
        SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        SaveToolStripMenuItem.Size = New Size(114, 22)
        SaveToolStripMenuItem.Text = "Save"
        ' 
        ' SaveAsToolStripMenuItem
        ' 
        SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        SaveAsToolStripMenuItem.Size = New Size(114, 22)
        SaveAsToolStripMenuItem.Text = "Save As"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(111, 6)
        ' 
        ' PrintToolStripMenuItem
        ' 
        PrintToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PrintToolStripMenuItem1, PrintPreviewToolStripMenuItem, PageSetupToolStripMenuItem})
        PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        PrintToolStripMenuItem.Size = New Size(114, 22)
        PrintToolStripMenuItem.Text = "Print"
        ' 
        ' PrintToolStripMenuItem1
        ' 
        PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        PrintToolStripMenuItem1.Size = New Size(143, 22)
        PrintToolStripMenuItem1.Text = "Print"
        ' 
        ' PrintPreviewToolStripMenuItem
        ' 
        PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        PrintPreviewToolStripMenuItem.Size = New Size(143, 22)
        PrintPreviewToolStripMenuItem.Text = "Print Preview"
        ' 
        ' PageSetupToolStripMenuItem
        ' 
        PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        PageSetupToolStripMenuItem.Size = New Size(143, 22)
        PageSetupToolStripMenuItem.Text = "Page Setup"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(111, 6)
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(114, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem, DeleteToolStripMenuItem})
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(39, 20)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' CutToolStripMenuItem
        ' 
        CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        CutToolStripMenuItem.Size = New Size(107, 22)
        CutToolStripMenuItem.Text = "Cut"
        ' 
        ' CopyToolStripMenuItem
        ' 
        CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        CopyToolStripMenuItem.Size = New Size(107, 22)
        CopyToolStripMenuItem.Text = "Copy"
        ' 
        ' PasteToolStripMenuItem
        ' 
        PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        PasteToolStripMenuItem.Size = New Size(107, 22)
        PasteToolStripMenuItem.Text = "Paste"
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(107, 22)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' ReportsToolStripMenuItem
        ' 
        ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        ReportsToolStripMenuItem.Size = New Size(59, 20)
        ReportsToolStripMenuItem.Text = "Reports"
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem1})
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(61, 20)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem2, ToolStripMenuItem3, ToolStripMenuItem4, ToolStripMenuItem5})
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(180, 22)
        ToolStripMenuItem1.Text = "Class"
        ' 
        ' ReportBindingSource
        ' 
        ReportBindingSource.DataSource = GetType(LibDatabase.Models.Report)
        ' 
        ' TableReports
        ' 
        TableReports.AutoSize = True
        TableReports.ColumnCount = 1
        TableReports.ColumnStyles.Add(New ColumnStyle())
        TableReports.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        TableReports.Controls.Add(labReports, 0, 0)
        TableReports.Controls.Add(ListReports, 0, 1)
        TableReports.Location = New Point(15, 27)
        TableReports.Name = "TableReports"
        TableReports.RowCount = 2
        TableReports.RowStyles.Add(New RowStyle(SizeType.Percent, 12.6760559F))
        TableReports.RowStyles.Add(New RowStyle(SizeType.Percent, 87.3239441F))
        TableReports.Size = New Size(200, 163)
        TableReports.TabIndex = 9
        TableReports.Visible = False
        ' 
        ' labReports
        ' 
        labReports.AutoSize = True
        labReports.BackColor = SystemColors.Highlight
        labReports.Dock = DockStyle.Fill
        labReports.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        labReports.ForeColor = SystemColors.ControlLightLight
        labReports.Location = New Point(3, 0)
        labReports.Name = "labReports"
        labReports.Size = New Size(194, 20)
        labReports.TabIndex = 10
        labReports.Text = "Open Report"
        labReports.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ListReports
        ' 
        ListReports.DataSource = ReportBindingSource
        ListReports.DisplayMember = "ReportName"
        ListReports.Dock = DockStyle.Top
        ListReports.FormattingEnabled = True
        ListReports.ItemHeight = 15
        ListReports.Location = New Point(3, 20)
        ListReports.Margin = New Padding(3, 0, 3, 0)
        ListReports.Name = "ListReports"
        ListReports.Size = New Size(194, 139)
        ListReports.TabIndex = 9
        ' 
        ' GrdRadiiAverages
        ' 
        GrdRadiiAverages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GrdRadiiAverages.Location = New Point(12, 765)
        GrdRadiiAverages.Name = "GrdRadiiAverages"
        GrdRadiiAverages.RowHeadersVisible = False
        GrdRadiiAverages.Size = New Size(240, 150)
        GrdRadiiAverages.TabIndex = 7
        ' 
        ' GrdChordLength
        ' 
        GrdChordLength.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GrdChordLength.Location = New Point(12, 921)
        GrdChordLength.Name = "GrdChordLength"
        GrdChordLength.RowHeadersVisible = False
        GrdChordLength.Size = New Size(240, 150)
        GrdChordLength.TabIndex = 8
        ' 
        ' Chart1
        ' 
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(12, 385)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New Size(250, 151)
        Chart1.TabIndex = 10
        Chart1.Text = "Chart1"
        Chart1.Visible = False
        ' 
        ' Chart2
        ' 
        ChartArea2.Name = "ChartArea1"
        Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Chart2.Legends.Add(Legend2)
        Chart2.Location = New Point(30, 397)
        Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Chart2.Series.Add(Series2)
        Chart2.Size = New Size(250, 151)
        Chart2.TabIndex = 11
        Chart2.Text = "Chart2"
        Chart2.Visible = False
        ' 
        ' Chart3
        ' 
        ChartArea3.Name = "ChartArea1"
        Chart3.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Chart3.Legends.Add(Legend3)
        Chart3.Location = New Point(41, 407)
        Chart3.Name = "Chart3"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Chart3.Series.Add(Series3)
        Chart3.Size = New Size(250, 151)
        Chart3.TabIndex = 12
        Chart3.Text = "Chart3"
        Chart3.Visible = False
        ' 
        ' DataGridJobs
        ' 
        DataGridJobs.AutoGenerateColumns = False
        DataGridJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridJobs.Columns.AddRange(New DataGridViewColumn() {JobNumber, DescriptionDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, PerformedBy, Description})
        DataGridJobs.DataSource = JobDetailsBindingSource
        DataGridJobs.Location = New Point(15, 45)
        DataGridJobs.Name = "DataGridJobs"
        DataGridJobs.ReadOnly = True
        DataGridJobs.Size = New Size(823, 150)
        DataGridJobs.TabIndex = 13
        DataGridJobs.Visible = False
        ' 
        ' JobNumber
        ' 
        JobNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        JobNumber.DataPropertyName = "JobId"
        JobNumber.DataSource = JobBindingSource
        JobNumber.DisplayMember = "JobNumber"
        JobNumber.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        JobNumber.HeaderText = "Job"
        JobNumber.Name = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Resizable = DataGridViewTriState.True
        JobNumber.ValueMember = "Id"
        JobNumber.Width = 39
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.AllowNew = False
        JobBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        JobBindingSource.Sort = "JobNumber"
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "MeasurementTypeId"
        DescriptionDataGridViewTextBoxColumn.DataSource = MeasurementTypeBindingSource
        DescriptionDataGridViewTextBoxColumn.DisplayMember = "MeasurementType1"
        DescriptionDataGridViewTextBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Measurement"
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        DescriptionDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True
        DescriptionDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic
        DescriptionDataGridViewTextBoxColumn.ValueMember = "Id"
        ' 
        ' MeasurementTypeBindingSource
        ' 
        MeasurementTypeBindingSource.AllowNew = False
        MeasurementTypeBindingSource.DataSource = GetType(LibDatabase.Models.MeasurementType)
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.ReadOnly = True
        StartDateDataGridViewTextBoxColumn.Width = 21
        ' 
        ' PerformedBy
        ' 
        PerformedBy.DataPropertyName = "PerformedBy"
        PerformedBy.DataSource = EmployeeBindingSource
        PerformedBy.DisplayMember = "EmployeeName"
        PerformedBy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        PerformedBy.HeaderText = "Performed By"
        PerformedBy.Name = "PerformedBy"
        PerformedBy.ReadOnly = True
        PerformedBy.ValueMember = "Id"
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.AllowNew = False
        EmployeeBindingSource.DataSource = GetType(LibDatabase.Models.Employee)
        EmployeeBindingSource.Sort = "EmployeeName"
        ' 
        ' Description
        ' 
        Description.DataPropertyName = "Description"
        Description.HeaderText = "Description"
        Description.Name = "Description"
        Description.ReadOnly = True
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        JobDetailsBindingSource.Sort = "JobId"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {UndoToolStripMenuItem, ToolStripSeparator6, CutToolStripMenuItem1, PasteToolStripMenuItem1, DeleteToolStripMenuItem1, ToolStripSeparator5, SelectAllToolStripMenuItem, ToolStripSeparator7, AddNewToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(124, 154)
        ' 
        ' UndoToolStripMenuItem
        ' 
        UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        UndoToolStripMenuItem.Size = New Size(123, 22)
        UndoToolStripMenuItem.Text = "Undo"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(120, 6)
        ' 
        ' CutToolStripMenuItem1
        ' 
        CutToolStripMenuItem1.Name = "CutToolStripMenuItem1"
        CutToolStripMenuItem1.Size = New Size(123, 22)
        CutToolStripMenuItem1.Text = "Cut"
        ' 
        ' PasteToolStripMenuItem1
        ' 
        PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1"
        PasteToolStripMenuItem1.Size = New Size(123, 22)
        PasteToolStripMenuItem1.Text = "Paste"
        ' 
        ' DeleteToolStripMenuItem1
        ' 
        DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        DeleteToolStripMenuItem1.Size = New Size(123, 22)
        DeleteToolStripMenuItem1.Text = "Delete"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(120, 6)
        ' 
        ' SelectAllToolStripMenuItem
        ' 
        SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        SelectAllToolStripMenuItem.Size = New Size(123, 22)
        SelectAllToolStripMenuItem.Text = "Select All"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(120, 6)
        ' 
        ' AddNewToolStripMenuItem
        ' 
        AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        AddNewToolStripMenuItem.Size = New Size(123, 22)
        AddNewToolStripMenuItem.Text = "Add New"
        ' 
        ' Chart4
        ' 
        ChartArea4.Name = "ChartArea1"
        Chart4.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Chart4.Legends.Add(Legend4)
        Chart4.Location = New Point(58, 419)
        Chart4.Name = "Chart4"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Chart4.Series.Add(Series4)
        Chart4.Size = New Size(250, 151)
        Chart4.TabIndex = 14
        Chart4.Text = "Chart4"
        Chart4.Visible = False
        ' 
        ' Chart5
        ' 
        ChartArea5.Name = "ChartArea1"
        Chart5.ChartAreas.Add(ChartArea5)
        Legend5.Name = "Legend1"
        Chart5.Legends.Add(Legend5)
        Chart5.Location = New Point(75, 432)
        Chart5.Name = "Chart5"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Chart5.Series.Add(Series5)
        Chart5.Size = New Size(250, 151)
        Chart5.TabIndex = 15
        Chart5.Text = "Chart5"
        Chart5.Visible = False
        ' 
        ' Chart6
        ' 
        ChartArea6.Name = "ChartArea1"
        Chart6.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Chart6.Legends.Add(Legend6)
        Chart6.Location = New Point(93, 443)
        Chart6.Name = "Chart6"
        Series6.ChartArea = "ChartArea1"
        Series6.Legend = "Legend1"
        Series6.Name = "Series1"
        Chart6.Series.Add(Series6)
        Chart6.Size = New Size(250, 151)
        Chart6.TabIndex = 16
        Chart6.Text = "Chart6"
        Chart6.Visible = False
        ' 
        ' Chart7
        ' 
        ChartArea7.Name = "ChartArea1"
        Chart7.ChartAreas.Add(ChartArea7)
        Legend7.Name = "Legend1"
        Chart7.Legends.Add(Legend7)
        Chart7.Location = New Point(115, 457)
        Chart7.Name = "Chart7"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Chart7.Series.Add(Series7)
        Chart7.Size = New Size(250, 151)
        Chart7.TabIndex = 17
        Chart7.Text = "Chart7"
        Chart7.Visible = False
        ' 
        ' Chart8
        ' 
        ChartArea8.Name = "ChartArea1"
        Chart8.ChartAreas.Add(ChartArea8)
        Legend8.Name = "Legend1"
        Chart8.Legends.Add(Legend8)
        Chart8.Location = New Point(143, 471)
        Chart8.Name = "Chart8"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Series1"
        Chart8.Series.Add(Series8)
        Chart8.Size = New Size(250, 151)
        Chart8.TabIndex = 18
        Chart8.Text = "Chart8"
        Chart8.Visible = False
        ' 
        ' Chart9
        ' 
        ChartArea9.Name = "ChartArea1"
        Chart9.ChartAreas.Add(ChartArea9)
        Legend9.Name = "Legend1"
        Chart9.Legends.Add(Legend9)
        Chart9.Location = New Point(166, 484)
        Chart9.Name = "Chart9"
        Series9.ChartArea = "ChartArea1"
        Series9.Legend = "Legend1"
        Series9.Name = "Series1"
        Chart9.Series.Add(Series9)
        Chart9.Size = New Size(250, 151)
        Chart9.TabIndex = 19
        Chart9.Text = "Chart9"
        Chart9.Visible = False
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(180, 22)
        ToolStripMenuItem2.Text = "I"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(180, 22)
        ToolStripMenuItem3.Text = "II"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(180, 22)
        ToolStripMenuItem4.Text = "III"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(180, 22)
        ToolStripMenuItem5.Text = "S"
        ' 
        ' ElementsToolStripMenuItem
        ' 
        ElementsToolStripMenuItem.Name = "ElementsToolStripMenuItem"
        ElementsToolStripMenuItem.Size = New Size(67, 20)
        ElementsToolStripMenuItem.Text = "Elements"
        ' 
        ' FrmReports
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(850, 1061)
        Controls.Add(Chart9)
        Controls.Add(Chart8)
        Controls.Add(Chart7)
        Controls.Add(Chart6)
        Controls.Add(Chart5)
        Controls.Add(Chart4)
        Controls.Add(DataGridJobs)
        Controls.Add(Chart3)
        Controls.Add(Chart2)
        Controls.Add(Chart1)
        Controls.Add(TableReports)
        Controls.Add(GrdChordLength)
        Controls.Add(GrdRadiiAverages)
        Controls.Add(HeaderLayoutPanel)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "FrmReports"
        Text = "Reports"
        CType(MeasurementDataBindingSource, ComponentModel.ISupportInitialize).EndInit()
        HeaderLayoutPanel.ResumeLayout(False)
        HeaderLayoutPanel.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(ReportBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableReports.ResumeLayout(False)
        TableReports.PerformLayout()
        CType(GrdRadiiAverages, ComponentModel.ISupportInitialize).EndInit()
        CType(GrdChordLength, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart2, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart3, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridJobs, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(MeasurementTypeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        CType(Chart4, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart5, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart6, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart7, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart8, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart9, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MeasurementDataBindingSource As BindingSource
    Friend WithEvents HeaderLayoutPanel As TableLayoutPanel
    Friend WithEvents LabJobNumber As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabManufacturer As Label
    Friend WithEvents LabPartNumber As Label
    Friend WithEvents LabSerialNumber As Label
    Friend WithEvents LabStampNumber As Label
    Friend WithEvents LabInspectedBy As Label
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents TxtStampNumber As TextBox
    Friend WithEvents TxtInspectedBy As TextBox
    Friend WithEvents LabJobId As Label
    Friend WithEvents LabClass As Label
    Friend WithEvents LabRepairStatus As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents LabMaterial As Label
    Friend WithEvents TxtJobId As TextBox
    Friend WithEvents LabBore As Label
    Friend WithEvents LabDAR As Label
    Friend WithEvents LabCup As Label
    Friend WithEvents TxtClass As TextBox
    Friend WithEvents TxtRepairStatus As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TxtDAR As TextBox
    Friend WithEvents TxtCup As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtWheelPitch As TextBox
    Friend WithEvents TxtMarkedPitch As TextBox
    Friend WithEvents TxtMeasuredDiameter As TextBox
    Friend WithEvents TxtMarkedDiameter As TextBox
    Friend WithEvents TxtRotation As TextBox
    Friend WithEvents TxtPerformedBy As TextBox
    Friend WithEvents TxtScanDate As TextBox
    Friend WithEvents TxtFileName As TextBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    'Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ReportBindingSource As BindingSource
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TableReports As TableLayoutPanel
    Friend WithEvents labReports As Label
    Friend WithEvents ListReports As ListBox
    Friend WithEvents GrdRadiiAverages As DataGridView
    Friend WithEvents GrdChordLength As DataGridView
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridJobs As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents AddNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents Chart4 As DataVisualization.Charting.Chart
    Friend WithEvents Chart5 As DataVisualization.Charting.Chart
    Friend WithEvents Chart6 As DataVisualization.Charting.Chart
    Friend WithEvents Chart7 As DataVisualization.Charting.Chart
    Friend WithEvents Chart8 As DataVisualization.Charting.Chart
    Friend WithEvents Chart9 As DataVisualization.Charting.Chart
    Friend WithEvents MeasurementTypeBindingSource As BindingSource
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents JobNumber As DataGridViewComboBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewComboBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PerformedBy As DataGridViewComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ElementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
End Class
