<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportHeader
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
        components = New ComponentModel.Container()
        Header = New TableLayoutPanel()
        TxtWheelPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        TxtMeasuredDiameter = New TextBox()
        TxtMarkedDiameter = New TextBox()
        TxtRotation = New TextBox()
        TxtPerformedBy = New TextBox()
        TxtScanDate = New TextBox()
        TxtFileName = New TextBox()
        LabFilename = New Label()
        LabJobId = New Label()
        LabJobNumber = New Label()
        LabCustomer = New Label()
        LabVessel = New Label()
        LabManufacturer = New Label()
        LabPartNumber = New Label()
        LabSerialNumber = New Label()
        LabStampNumber = New Label()
        LabInspectedBy = New Label()
        TxtCustomer = New TextBox()
        JobDetailsBindingSource = New BindingSource(components)
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
        LabScanDate = New Label()
        LabPerformedBy = New Label()
        LabMarkedPitch = New Label()
        LabWheelPitch = New Label()
        LabMeasuredDiameter = New Label()
        LabMarkedDiameter = New Label()
        LabRotation = New Label()
        TxtJobId = New TextBox()
        TxtJobNumber = New TextBox()
        Header.SuspendLayout()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Header
        ' 
        Header.ColumnCount = 6
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.21212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.21212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.21212F))
        Header.Controls.Add(TxtWheelPitch, 5, 7)
        Header.Controls.Add(TxtMarkedPitch, 5, 6)
        Header.Controls.Add(TxtMeasuredDiameter, 5, 5)
        Header.Controls.Add(TxtMarkedDiameter, 5, 4)
        Header.Controls.Add(TxtRotation, 5, 3)
        Header.Controls.Add(TxtPerformedBy, 5, 2)
        Header.Controls.Add(TxtScanDate, 5, 1)
        Header.Controls.Add(TxtFileName, 5, 0)
        Header.Controls.Add(LabFilename, 4, 0)
        Header.Controls.Add(LabJobId, 2, 0)
        Header.Controls.Add(LabJobNumber, 0, 0)
        Header.Controls.Add(LabCustomer, 0, 1)
        Header.Controls.Add(LabVessel, 0, 2)
        Header.Controls.Add(LabManufacturer, 0, 3)
        Header.Controls.Add(LabPartNumber, 0, 4)
        Header.Controls.Add(LabSerialNumber, 0, 5)
        Header.Controls.Add(LabStampNumber, 0, 6)
        Header.Controls.Add(LabInspectedBy, 0, 7)
        Header.Controls.Add(TxtCustomer, 1, 1)
        Header.Controls.Add(TxtVessel, 1, 2)
        Header.Controls.Add(TxtManufacturer, 1, 3)
        Header.Controls.Add(TxtPartNumber, 1, 4)
        Header.Controls.Add(TxtSerialNumber, 1, 5)
        Header.Controls.Add(TxtStampNumber, 1, 6)
        Header.Controls.Add(TxtInspectedBy, 1, 7)
        Header.Controls.Add(LabClass, 2, 1)
        Header.Controls.Add(LabRepairStatus, 2, 2)
        Header.Controls.Add(LabStyle, 2, 3)
        Header.Controls.Add(LabMaterial, 2, 4)
        Header.Controls.Add(LabBore, 2, 5)
        Header.Controls.Add(LabDAR, 2, 6)
        Header.Controls.Add(LabCup, 2, 7)
        Header.Controls.Add(TxtClass, 3, 1)
        Header.Controls.Add(TxtRepairStatus, 3, 2)
        Header.Controls.Add(TxtStyle, 3, 3)
        Header.Controls.Add(TxtMaterial, 3, 4)
        Header.Controls.Add(TxtBore, 3, 5)
        Header.Controls.Add(TxtDAR, 3, 6)
        Header.Controls.Add(TxtCup, 3, 7)
        Header.Controls.Add(LabScanDate, 4, 1)
        Header.Controls.Add(LabPerformedBy, 4, 2)
        Header.Controls.Add(LabMarkedPitch, 4, 6)
        Header.Controls.Add(LabWheelPitch, 4, 7)
        Header.Controls.Add(LabMeasuredDiameter, 4, 5)
        Header.Controls.Add(LabMarkedDiameter, 4, 4)
        Header.Controls.Add(LabRotation, 4, 3)
        Header.Controls.Add(TxtJobId, 3, 0)
        Header.Controls.Add(TxtJobNumber, 1, 0)
        Header.ForeColor = SystemColors.InactiveCaption
        Header.Location = New Point(0, 0)
        Header.Margin = New Padding(0)
        Header.Name = "Header"
        Header.RowCount = 8
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Header.Size = New Size(815, 162)
        Header.TabIndex = 29
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.Anchor = AnchorStyles.Left
        TxtWheelPitch.BorderStyle = BorderStyle.None
        TxtWheelPitch.Location = New Point(641, 143)
        TxtWheelPitch.Name = "TxtWheelPitch"
        TxtWheelPitch.ReadOnly = True
        TxtWheelPitch.Size = New Size(168, 16)
        TxtWheelPitch.TabIndex = 49
        TxtWheelPitch.TabStop = False
        TxtWheelPitch.Tag = "WhlPit"
        TxtWheelPitch.Visible = False
        ' 
        ' TxtMarkedPitch
        ' 
        TxtMarkedPitch.Anchor = AnchorStyles.Left
        TxtMarkedPitch.BorderStyle = BorderStyle.None
        TxtMarkedPitch.Location = New Point(641, 123)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.ReadOnly = True
        TxtMarkedPitch.Size = New Size(168, 16)
        TxtMarkedPitch.TabIndex = 48
        TxtMarkedPitch.TabStop = False
        TxtMarkedPitch.Tag = "MrkPit"
        TxtMarkedPitch.Visible = False
        ' 
        ' TxtMeasuredDiameter
        ' 
        TxtMeasuredDiameter.Anchor = AnchorStyles.Left
        TxtMeasuredDiameter.BorderStyle = BorderStyle.None
        TxtMeasuredDiameter.Location = New Point(641, 103)
        TxtMeasuredDiameter.Name = "TxtMeasuredDiameter"
        TxtMeasuredDiameter.ReadOnly = True
        TxtMeasuredDiameter.Size = New Size(168, 16)
        TxtMeasuredDiameter.TabIndex = 47
        TxtMeasuredDiameter.TabStop = False
        TxtMeasuredDiameter.Tag = "MeasDia"
        TxtMeasuredDiameter.Visible = False
        ' 
        ' TxtMarkedDiameter
        ' 
        TxtMarkedDiameter.Anchor = AnchorStyles.Left
        TxtMarkedDiameter.BorderStyle = BorderStyle.None
        TxtMarkedDiameter.Location = New Point(641, 83)
        TxtMarkedDiameter.Name = "TxtMarkedDiameter"
        TxtMarkedDiameter.ReadOnly = True
        TxtMarkedDiameter.Size = New Size(168, 16)
        TxtMarkedDiameter.TabIndex = 46
        TxtMarkedDiameter.TabStop = False
        TxtMarkedDiameter.Tag = "MrkDia"
        TxtMarkedDiameter.Visible = False
        ' 
        ' TxtRotation
        ' 
        TxtRotation.Anchor = AnchorStyles.Left
        TxtRotation.BorderStyle = BorderStyle.None
        TxtRotation.Location = New Point(641, 63)
        TxtRotation.Name = "TxtRotation"
        TxtRotation.ReadOnly = True
        TxtRotation.Size = New Size(168, 16)
        TxtRotation.TabIndex = 45
        TxtRotation.TabStop = False
        TxtRotation.Tag = "Rotn"
        TxtRotation.Visible = False
        ' 
        ' TxtPerformedBy
        ' 
        TxtPerformedBy.Anchor = AnchorStyles.Left
        TxtPerformedBy.BorderStyle = BorderStyle.None
        TxtPerformedBy.Location = New Point(641, 43)
        TxtPerformedBy.Name = "TxtPerformedBy"
        TxtPerformedBy.ReadOnly = True
        TxtPerformedBy.Size = New Size(168, 16)
        TxtPerformedBy.TabIndex = 44
        TxtPerformedBy.TabStop = False
        TxtPerformedBy.Tag = "PerfBy"
        TxtPerformedBy.Visible = False
        ' 
        ' TxtScanDate
        ' 
        TxtScanDate.Anchor = AnchorStyles.Left
        TxtScanDate.BorderStyle = BorderStyle.None
        TxtScanDate.Location = New Point(641, 23)
        TxtScanDate.Name = "TxtScanDate"
        TxtScanDate.ReadOnly = True
        TxtScanDate.Size = New Size(168, 16)
        TxtScanDate.TabIndex = 43
        TxtScanDate.TabStop = False
        TxtScanDate.Tag = "Scan"
        TxtScanDate.Visible = False
        ' 
        ' TxtFileName
        ' 
        TxtFileName.Anchor = AnchorStyles.Left
        TxtFileName.BorderStyle = BorderStyle.None
        TxtFileName.Location = New Point(641, 3)
        TxtFileName.Name = "TxtFileName"
        TxtFileName.ReadOnly = True
        TxtFileName.Size = New Size(168, 16)
        TxtFileName.TabIndex = 42
        TxtFileName.TabStop = False
        TxtFileName.Tag = "File"
        TxtFileName.Visible = False
        ' 
        ' LabFilename
        ' 
        LabFilename.Anchor = AnchorStyles.Left
        LabFilename.AutoSize = True
        LabFilename.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabFilename.ForeColor = SystemColors.ControlText
        LabFilename.Location = New Point(543, 2)
        LabFilename.Name = "LabFilename"
        LabFilename.Size = New Size(62, 15)
        LabFilename.TabIndex = 34
        LabFilename.Tag = "TxtFileName"
        LabFilename.Text = "File Name"
        LabFilename.Visible = False
        ' 
        ' LabJobId
        ' 
        LabJobId.Anchor = AnchorStyles.Left
        LabJobId.AutoSize = True
        LabJobId.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobId.ForeColor = SystemColors.ControlText
        LabJobId.Location = New Point(273, 2)
        LabJobId.Name = "LabJobId"
        LabJobId.Size = New Size(40, 15)
        LabJobId.TabIndex = 18
        LabJobId.Tag = "TxtJobId"
        LabJobId.Text = "Job Id"
        LabJobId.Visible = False
        ' 
        ' LabJobNumber
        ' 
        LabJobNumber.Anchor = AnchorStyles.Left
        LabJobNumber.AutoSize = True
        LabJobNumber.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobNumber.ForeColor = SystemColors.ControlText
        LabJobNumber.Location = New Point(3, 2)
        LabJobNumber.Name = "LabJobNumber"
        LabJobNumber.Size = New Size(48, 15)
        LabJobNumber.TabIndex = 0
        LabJobNumber.Tag = "TxtJobNumber"
        LabJobNumber.Text = "Job No."
        LabJobNumber.Visible = False
        ' 
        ' LabCustomer
        ' 
        LabCustomer.Anchor = AnchorStyles.Left
        LabCustomer.AutoSize = True
        LabCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCustomer.ForeColor = SystemColors.ControlText
        LabCustomer.Location = New Point(3, 22)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(61, 15)
        LabCustomer.TabIndex = 3
        LabCustomer.Tag = "TxtCustomer"
        LabCustomer.Text = "Customer"
        LabCustomer.Visible = False
        ' 
        ' LabVessel
        ' 
        LabVessel.Anchor = AnchorStyles.Left
        LabVessel.AutoSize = True
        LabVessel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabVessel.ForeColor = SystemColors.ControlText
        LabVessel.Location = New Point(3, 42)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(41, 15)
        LabVessel.TabIndex = 4
        LabVessel.Tag = "TxtVessel"
        LabVessel.Text = "Vessel"
        LabVessel.Visible = False
        ' 
        ' LabManufacturer
        ' 
        LabManufacturer.Anchor = AnchorStyles.Left
        LabManufacturer.AutoSize = True
        LabManufacturer.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabManufacturer.ForeColor = SystemColors.ControlText
        LabManufacturer.Location = New Point(3, 62)
        LabManufacturer.Name = "LabManufacturer"
        LabManufacturer.Size = New Size(84, 15)
        LabManufacturer.TabIndex = 5
        LabManufacturer.Tag = "TxtManufacturer"
        LabManufacturer.Text = "Manufacturer"
        LabManufacturer.Visible = False
        ' 
        ' LabPartNumber
        ' 
        LabPartNumber.Anchor = AnchorStyles.Left
        LabPartNumber.AutoSize = True
        LabPartNumber.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPartNumber.ForeColor = SystemColors.ControlText
        LabPartNumber.Location = New Point(3, 82)
        LabPartNumber.Name = "LabPartNumber"
        LabPartNumber.Size = New Size(52, 15)
        LabPartNumber.TabIndex = 6
        LabPartNumber.Tag = "TxtPartNumber"
        LabPartNumber.Text = "Part No."
        LabPartNumber.Visible = False
        ' 
        ' LabSerialNumber
        ' 
        LabSerialNumber.Anchor = AnchorStyles.Left
        LabSerialNumber.AutoSize = True
        LabSerialNumber.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabSerialNumber.ForeColor = SystemColors.ControlText
        LabSerialNumber.Location = New Point(3, 102)
        LabSerialNumber.Name = "LabSerialNumber"
        LabSerialNumber.Size = New Size(28, 15)
        LabSerialNumber.TabIndex = 7
        LabSerialNumber.Tag = "TxtSerialNumber"
        LabSerialNumber.Text = "S/N"
        LabSerialNumber.Visible = False
        ' 
        ' LabStampNumber
        ' 
        LabStampNumber.Anchor = AnchorStyles.Left
        LabStampNumber.AutoSize = True
        LabStampNumber.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStampNumber.ForeColor = SystemColors.ControlText
        LabStampNumber.Location = New Point(3, 122)
        LabStampNumber.Name = "LabStampNumber"
        LabStampNumber.Size = New Size(65, 15)
        LabStampNumber.TabIndex = 8
        LabStampNumber.Tag = "TxtStampNumber"
        LabStampNumber.Text = "Stamp No."
        LabStampNumber.Visible = False
        ' 
        ' LabInspectedBy
        ' 
        LabInspectedBy.Anchor = AnchorStyles.Left
        LabInspectedBy.AutoSize = True
        LabInspectedBy.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabInspectedBy.ForeColor = SystemColors.ControlText
        LabInspectedBy.Location = New Point(3, 143)
        LabInspectedBy.Name = "LabInspectedBy"
        LabInspectedBy.Size = New Size(79, 15)
        LabInspectedBy.TabIndex = 9
        LabInspectedBy.Tag = "TxtInspectedBy"
        LabInspectedBy.Text = "Inspected By"
        LabInspectedBy.Visible = False
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.Anchor = AnchorStyles.Left
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "Job.Vessel.Customer.CustomerName", True))
        TxtCustomer.Location = New Point(101, 23)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(165, 16)
        TxtCustomer.TabIndex = 11
        TxtCustomer.TabStop = False
        TxtCustomer.Tag = "Cust"
        TxtCustomer.Visible = False
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' TxtVessel
        ' 
        TxtVessel.Anchor = AnchorStyles.Left
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "Job.Vessel.VesselName", True))
        TxtVessel.Location = New Point(101, 43)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.ReadOnly = True
        TxtVessel.Size = New Size(165, 16)
        TxtVessel.TabIndex = 12
        TxtVessel.TabStop = False
        TxtVessel.Tag = "Vess"
        TxtVessel.Visible = False
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.Anchor = AnchorStyles.Left
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "Job.PropellerManufacturer.ManufacturerName", True))
        TxtManufacturer.Location = New Point(101, 63)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(165, 16)
        TxtManufacturer.TabIndex = 13
        TxtManufacturer.TabStop = False
        TxtManufacturer.Tag = "Mfg"
        TxtManufacturer.Visible = False
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.Anchor = AnchorStyles.Left
        TxtPartNumber.BorderStyle = BorderStyle.None
        TxtPartNumber.Location = New Point(101, 83)
        TxtPartNumber.Name = "TxtPartNumber"
        TxtPartNumber.ReadOnly = True
        TxtPartNumber.Size = New Size(165, 16)
        TxtPartNumber.TabIndex = 14
        TxtPartNumber.TabStop = False
        TxtPartNumber.Tag = "P/N"
        TxtPartNumber.Visible = False
        ' 
        ' TxtSerialNumber
        ' 
        TxtSerialNumber.Anchor = AnchorStyles.Left
        TxtSerialNumber.BorderStyle = BorderStyle.None
        TxtSerialNumber.Location = New Point(101, 103)
        TxtSerialNumber.Name = "TxtSerialNumber"
        TxtSerialNumber.ReadOnly = True
        TxtSerialNumber.Size = New Size(165, 16)
        TxtSerialNumber.TabIndex = 15
        TxtSerialNumber.TabStop = False
        TxtSerialNumber.Tag = "S/N"
        TxtSerialNumber.Visible = False
        ' 
        ' TxtStampNumber
        ' 
        TxtStampNumber.Anchor = AnchorStyles.Left
        TxtStampNumber.BorderStyle = BorderStyle.None
        TxtStampNumber.Location = New Point(101, 123)
        TxtStampNumber.Name = "TxtStampNumber"
        TxtStampNumber.ReadOnly = True
        TxtStampNumber.Size = New Size(165, 16)
        TxtStampNumber.TabIndex = 16
        TxtStampNumber.TabStop = False
        TxtStampNumber.Tag = "Stamp"
        TxtStampNumber.Visible = False
        ' 
        ' TxtInspectedBy
        ' 
        TxtInspectedBy.Anchor = AnchorStyles.Left
        TxtInspectedBy.BorderStyle = BorderStyle.None
        TxtInspectedBy.Location = New Point(101, 143)
        TxtInspectedBy.Name = "TxtInspectedBy"
        TxtInspectedBy.ReadOnly = True
        TxtInspectedBy.Size = New Size(165, 16)
        TxtInspectedBy.TabIndex = 17
        TxtInspectedBy.TabStop = False
        TxtInspectedBy.Tag = "InspBy"
        TxtInspectedBy.Visible = False
        ' 
        ' LabClass
        ' 
        LabClass.Anchor = AnchorStyles.Left
        LabClass.AutoSize = True
        LabClass.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabClass.ForeColor = SystemColors.ControlText
        LabClass.Location = New Point(273, 22)
        LabClass.Name = "LabClass"
        LabClass.Size = New Size(33, 15)
        LabClass.TabIndex = 19
        LabClass.Tag = "TxtClass"
        LabClass.Text = "Class"
        LabClass.Visible = False
        ' 
        ' LabRepairStatus
        ' 
        LabRepairStatus.Anchor = AnchorStyles.Left
        LabRepairStatus.AutoSize = True
        LabRepairStatus.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRepairStatus.ForeColor = SystemColors.ControlText
        LabRepairStatus.Location = New Point(273, 42)
        LabRepairStatus.Name = "LabRepairStatus"
        LabRepairStatus.Size = New Size(81, 15)
        LabRepairStatus.TabIndex = 20
        LabRepairStatus.Tag = "TxtRepairStatus"
        LabRepairStatus.Text = "Repair Status"
        LabRepairStatus.Visible = False
        ' 
        ' LabStyle
        ' 
        LabStyle.Anchor = AnchorStyles.Left
        LabStyle.AutoSize = True
        LabStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStyle.ForeColor = SystemColors.ControlText
        LabStyle.Location = New Point(273, 62)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(35, 15)
        LabStyle.TabIndex = 21
        LabStyle.Tag = "TxtStyle"
        LabStyle.Text = "Style"
        LabStyle.Visible = False
        ' 
        ' LabMaterial
        ' 
        LabMaterial.Anchor = AnchorStyles.Left
        LabMaterial.AutoSize = True
        LabMaterial.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMaterial.ForeColor = SystemColors.ControlText
        LabMaterial.Location = New Point(273, 82)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(53, 15)
        LabMaterial.TabIndex = 22
        LabMaterial.Tag = "TxtMaterial"
        LabMaterial.Text = "Material"
        LabMaterial.Visible = False
        ' 
        ' LabBore
        ' 
        LabBore.Anchor = AnchorStyles.Left
        LabBore.AutoSize = True
        LabBore.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBore.ForeColor = SystemColors.ControlText
        LabBore.Location = New Point(273, 102)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(34, 15)
        LabBore.TabIndex = 23
        LabBore.Tag = "TxtBore"
        LabBore.Text = "Bore"
        LabBore.Visible = False
        ' 
        ' LabDAR
        ' 
        LabDAR.Anchor = AnchorStyles.Left
        LabDAR.AutoSize = True
        LabDAR.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDAR.ForeColor = SystemColors.ControlText
        LabDAR.Location = New Point(273, 122)
        LabDAR.Name = "LabDAR"
        LabDAR.Size = New Size(32, 15)
        LabDAR.TabIndex = 24
        LabDAR.Tag = "TxtDAR"
        LabDAR.Text = "DAR"
        LabDAR.Visible = False
        ' 
        ' LabCup
        ' 
        LabCup.Anchor = AnchorStyles.Left
        LabCup.AutoSize = True
        LabCup.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCup.ForeColor = SystemColors.ControlText
        LabCup.Location = New Point(273, 143)
        LabCup.Name = "LabCup"
        LabCup.Size = New Size(28, 15)
        LabCup.TabIndex = 25
        LabCup.Tag = "TxtCup"
        LabCup.Text = "Cup"
        LabCup.Visible = False
        ' 
        ' TxtClass
        ' 
        TxtClass.Anchor = AnchorStyles.Left
        TxtClass.BorderStyle = BorderStyle.None
        TxtClass.Location = New Point(371, 23)
        TxtClass.Name = "TxtClass"
        TxtClass.ReadOnly = True
        TxtClass.Size = New Size(165, 16)
        TxtClass.TabIndex = 27
        TxtClass.TabStop = False
        TxtClass.Tag = "Cls"
        TxtClass.Visible = False
        ' 
        ' TxtRepairStatus
        ' 
        TxtRepairStatus.Anchor = AnchorStyles.Left
        TxtRepairStatus.BorderStyle = BorderStyle.None
        TxtRepairStatus.Location = New Point(371, 43)
        TxtRepairStatus.Name = "TxtRepairStatus"
        TxtRepairStatus.ReadOnly = True
        TxtRepairStatus.Size = New Size(165, 16)
        TxtRepairStatus.TabIndex = 28
        TxtRepairStatus.TabStop = False
        TxtRepairStatus.Tag = "RStat"
        TxtRepairStatus.Visible = False
        ' 
        ' TxtStyle
        ' 
        TxtStyle.Anchor = AnchorStyles.Left
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Location = New Point(371, 63)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.ReadOnly = True
        TxtStyle.Size = New Size(165, 16)
        TxtStyle.TabIndex = 29
        TxtStyle.TabStop = False
        TxtStyle.Tag = "Style"
        TxtStyle.Visible = False
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.Anchor = AnchorStyles.Left
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Location = New Point(371, 83)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.ReadOnly = True
        TxtMaterial.Size = New Size(165, 16)
        TxtMaterial.TabIndex = 30
        TxtMaterial.TabStop = False
        TxtMaterial.Tag = "Matl"
        TxtMaterial.Visible = False
        ' 
        ' TxtBore
        ' 
        TxtBore.Anchor = AnchorStyles.Left
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Location = New Point(371, 103)
        TxtBore.Name = "TxtBore"
        TxtBore.ReadOnly = True
        TxtBore.Size = New Size(165, 16)
        TxtBore.TabIndex = 31
        TxtBore.TabStop = False
        TxtBore.Tag = "Bore"
        TxtBore.Visible = False
        ' 
        ' TxtDAR
        ' 
        TxtDAR.Anchor = AnchorStyles.Left
        TxtDAR.BorderStyle = BorderStyle.None
        TxtDAR.Location = New Point(371, 123)
        TxtDAR.Name = "TxtDAR"
        TxtDAR.ReadOnly = True
        TxtDAR.Size = New Size(165, 16)
        TxtDAR.TabIndex = 32
        TxtDAR.TabStop = False
        TxtDAR.Tag = "DAR"
        TxtDAR.Visible = False
        ' 
        ' TxtCup
        ' 
        TxtCup.Anchor = AnchorStyles.Left
        TxtCup.BorderStyle = BorderStyle.None
        TxtCup.Location = New Point(371, 143)
        TxtCup.Name = "TxtCup"
        TxtCup.ReadOnly = True
        TxtCup.Size = New Size(165, 16)
        TxtCup.TabIndex = 33
        TxtCup.TabStop = False
        TxtCup.Tag = "Cup"
        TxtCup.Visible = False
        ' 
        ' LabScanDate
        ' 
        LabScanDate.Anchor = AnchorStyles.Left
        LabScanDate.AutoSize = True
        LabScanDate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabScanDate.ForeColor = SystemColors.ControlText
        LabScanDate.Location = New Point(543, 22)
        LabScanDate.Name = "LabScanDate"
        LabScanDate.Size = New Size(63, 15)
        LabScanDate.TabIndex = 35
        LabScanDate.Tag = "TxtScanDate"
        LabScanDate.Text = "Scan Date"
        LabScanDate.Visible = False
        ' 
        ' LabPerformedBy
        ' 
        LabPerformedBy.Anchor = AnchorStyles.Left
        LabPerformedBy.AutoSize = True
        LabPerformedBy.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPerformedBy.ForeColor = SystemColors.ControlText
        LabPerformedBy.Location = New Point(543, 42)
        LabPerformedBy.Name = "LabPerformedBy"
        LabPerformedBy.Size = New Size(85, 15)
        LabPerformedBy.TabIndex = 36
        LabPerformedBy.Tag = "TxtPerformedBy"
        LabPerformedBy.Text = "Performed By"
        LabPerformedBy.Visible = False
        ' 
        ' LabMarkedPitch
        ' 
        LabMarkedPitch.Anchor = AnchorStyles.Left
        LabMarkedPitch.AutoSize = True
        LabMarkedPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMarkedPitch.ForeColor = SystemColors.ControlText
        LabMarkedPitch.Location = New Point(543, 122)
        LabMarkedPitch.Name = "LabMarkedPitch"
        LabMarkedPitch.Size = New Size(81, 15)
        LabMarkedPitch.TabIndex = 40
        LabMarkedPitch.Tag = "TxtMarkedPitch"
        LabMarkedPitch.Text = "Marked Pitch"
        LabMarkedPitch.Visible = False
        ' 
        ' LabWheelPitch
        ' 
        LabWheelPitch.Anchor = AnchorStyles.Left
        LabWheelPitch.AutoSize = True
        LabWheelPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabWheelPitch.ForeColor = SystemColors.ControlText
        LabWheelPitch.Location = New Point(543, 143)
        LabWheelPitch.Name = "LabWheelPitch"
        LabWheelPitch.Size = New Size(74, 15)
        LabWheelPitch.TabIndex = 41
        LabWheelPitch.Tag = "TxtWheelPitch"
        LabWheelPitch.Text = "Wheel Pitch"
        LabWheelPitch.Visible = False
        ' 
        ' LabMeasuredDiameter
        ' 
        LabMeasuredDiameter.Anchor = AnchorStyles.Left
        LabMeasuredDiameter.AutoSize = True
        LabMeasuredDiameter.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMeasuredDiameter.ForeColor = SystemColors.ControlText
        LabMeasuredDiameter.Location = New Point(543, 102)
        LabMeasuredDiameter.Name = "LabMeasuredDiameter"
        LabMeasuredDiameter.Size = New Size(83, 15)
        LabMeasuredDiameter.TabIndex = 38
        LabMeasuredDiameter.Tag = "TxtMeasuredDiameter"
        LabMeasuredDiameter.Text = "Measured Dia"
        LabMeasuredDiameter.Visible = False
        ' 
        ' LabMarkedDiameter
        ' 
        LabMarkedDiameter.Anchor = AnchorStyles.Left
        LabMarkedDiameter.AutoSize = True
        LabMarkedDiameter.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMarkedDiameter.ForeColor = SystemColors.ControlText
        LabMarkedDiameter.Location = New Point(543, 82)
        LabMarkedDiameter.Name = "LabMarkedDiameter"
        LabMarkedDiameter.Size = New Size(71, 15)
        LabMarkedDiameter.TabIndex = 37
        LabMarkedDiameter.Tag = "TxtMarkedDiameter"
        LabMarkedDiameter.Text = "Marked Dia"
        LabMarkedDiameter.Visible = False
        ' 
        ' LabRotation
        ' 
        LabRotation.Anchor = AnchorStyles.Left
        LabRotation.AutoSize = True
        LabRotation.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRotation.ForeColor = SystemColors.ControlText
        LabRotation.Location = New Point(543, 62)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(55, 15)
        LabRotation.TabIndex = 39
        LabRotation.Tag = "TxtRotation"
        LabRotation.Text = "Rotation"
        LabRotation.Visible = False
        ' 
        ' TxtJobId
        ' 
        TxtJobId.Anchor = AnchorStyles.Left
        TxtJobId.BorderStyle = BorderStyle.None
        TxtJobId.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "JobId", True))
        TxtJobId.Location = New Point(371, 3)
        TxtJobId.Name = "TxtJobId"
        TxtJobId.ReadOnly = True
        TxtJobId.Size = New Size(165, 16)
        TxtJobId.TabIndex = 26
        TxtJobId.TabStop = False
        TxtJobId.Tag = "JobId"
        TxtJobId.Visible = False
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.Anchor = AnchorStyles.Left
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.DataBindings.Add(New Binding("Text", JobDetailsBindingSource, "Job.JobNumber", True))
        TxtJobNumber.Location = New Point(101, 3)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.ReadOnly = True
        TxtJobNumber.Size = New Size(165, 16)
        TxtJobNumber.TabIndex = 10
        TxtJobNumber.TabStop = False
        TxtJobNumber.Tag = "JobNo"
        TxtJobNumber.Visible = False
        ' 
        ' ReportHeader
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Header)
        Margin = New Padding(0)
        Name = "ReportHeader"
        Size = New Size(815, 162)
        Header.ResumeLayout(False)
        Header.PerformLayout()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Header As TableLayoutPanel
    Friend WithEvents TxtWheelPitch As TextBox
    Friend WithEvents TxtMarkedPitch As TextBox
    Friend WithEvents TxtMeasuredDiameter As TextBox
    Friend WithEvents TxtMarkedDiameter As TextBox
    Friend WithEvents TxtRotation As TextBox
    Friend WithEvents TxtPerformedBy As TextBox
    Friend WithEvents TxtScanDate As TextBox
    Friend WithEvents TxtFileName As TextBox
    Friend WithEvents LabFilename As Label
    Friend WithEvents LabJobId As Label
    Friend WithEvents LabJobNumber As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabManufacturer As Label
    Friend WithEvents LabPartNumber As Label
    Friend WithEvents LabSerialNumber As Label
    Friend WithEvents LabStampNumber As Label
    Friend WithEvents LabInspectedBy As Label
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents TxtStampNumber As TextBox
    Friend WithEvents TxtInspectedBy As TextBox
    Friend WithEvents LabClass As Label
    Friend WithEvents LabRepairStatus As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents LabMaterial As Label
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
    Friend WithEvents LabScanDate As Label
    Friend WithEvents LabPerformedBy As Label
    Friend WithEvents LabMarkedPitch As Label
    Friend WithEvents LabWheelPitch As Label
    Friend WithEvents LabMeasuredDiameter As Label
    Friend WithEvents LabMarkedDiameter As Label
    Friend WithEvents LabRotation As Label
    Friend WithEvents TxtJobId As TextBox
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents JobDetailsBindingSource As BindingSource

End Class
