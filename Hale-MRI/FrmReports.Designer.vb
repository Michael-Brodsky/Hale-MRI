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
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title5 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title6 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        JobDetailsBindingSource = New BindingSource(components)
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
        PrintToolStripMenuItem = New ToolStripMenuItem()
        PrintToolStripMenuItem1 = New ToolStripMenuItem()
        PrintPreviewToolStripMenuItem = New ToolStripMenuItem()
        PageSetupToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        Chart1 = New DataVisualization.Charting.Chart()
        Chart2 = New DataVisualization.Charting.Chart()
        Chart3 = New DataVisualization.Charting.Chart()
        GrdRadiiAverages = New DataGridView()
        GrdChordLength = New DataGridView()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        HeaderLayoutPanel.SuspendLayout()
        MenuStrip1.SuspendLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart3, ComponentModel.ISupportInitialize).BeginInit()
        CType(GrdRadiiAverages, ComponentModel.ISupportInitialize).BeginInit()
        CType(GrdChordLength, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        HeaderLayoutPanel.Location = New Point(12, 42)
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
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(850, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenToolStripMenuItem, ToolStripSeparator1, PrintToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' OpenToolStripMenuItem
        ' 
        OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        OpenToolStripMenuItem.Size = New Size(103, 22)
        OpenToolStripMenuItem.Text = "Open"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(100, 6)
        ' 
        ' PrintToolStripMenuItem
        ' 
        PrintToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PrintToolStripMenuItem1, PrintPreviewToolStripMenuItem, PageSetupToolStripMenuItem})
        PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        PrintToolStripMenuItem.Size = New Size(103, 22)
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
        ToolStripSeparator2.Size = New Size(100, 6)
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(103, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' Chart1
        ' 
        ChartArea4.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Chart1.Legends.Add(Legend4)
        Chart1.Location = New Point(12, 267)
        Chart1.Name = "Chart1"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Chart1.Series.Add(Series4)
        Chart1.Size = New Size(300, 160)
        Chart1.TabIndex = 4
        Chart1.Text = "Chart1"
        Title4.Name = "Title1"
        Chart1.Titles.Add(Title4)
        ' 
        ' Chart2
        ' 
        ChartArea5.Name = "ChartArea1"
        Chart2.ChartAreas.Add(ChartArea5)
        Legend5.Name = "Legend1"
        Chart2.Legends.Add(Legend5)
        Chart2.Location = New Point(12, 433)
        Chart2.Name = "Chart2"
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Chart2.Series.Add(Series5)
        Chart2.Size = New Size(300, 160)
        Chart2.TabIndex = 5
        Chart2.Text = "Chart2"
        Title5.Name = "Title2"
        Chart2.Titles.Add(Title5)
        ' 
        ' Chart3
        ' 
        ChartArea6.Name = "ChartArea1"
        Chart3.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Chart3.Legends.Add(Legend6)
        Chart3.Location = New Point(12, 599)
        Chart3.Name = "Chart3"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = DataVisualization.Charting.SeriesChartType.Line
        Series6.Legend = "Legend1"
        Series6.Name = "Series1"
        Chart3.Series.Add(Series6)
        Chart3.Size = New Size(300, 160)
        Chart3.TabIndex = 6
        Chart3.Text = "Chart3"
        Title6.Name = "Title3"
        Chart3.Titles.Add(Title6)
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
        ' FrmReports
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(850, 1061)
        Controls.Add(GrdChordLength)
        Controls.Add(GrdRadiiAverages)
        Controls.Add(Chart3)
        Controls.Add(Chart2)
        Controls.Add(Chart1)
        Controls.Add(HeaderLayoutPanel)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "FrmReports"
        Text = "Form2"
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        HeaderLayoutPanel.ResumeLayout(False)
        HeaderLayoutPanel.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart2, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart3, ComponentModel.ISupportInitialize).EndInit()
        CType(GrdRadiiAverages, ComponentModel.ISupportInitialize).EndInit()
        CType(GrdChordLength, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents JobDetailsBindingSource As BindingSource
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
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents GrdRadiiAverages As DataGridView
    Friend WithEvents GrdChordLength As DataGridView
End Class
