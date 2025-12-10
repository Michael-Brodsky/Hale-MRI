<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReports
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
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PageSetupDialog1 = New PageSetupDialog()
        ChartBladeHeight = New DataVisualization.Charting.Chart()
        ChartAngularPosition = New DataVisualization.Charting.Chart()
        PanelHeader = New Panel()
        TablePropeller = New TableLayoutPanel()
        LabBore = New Label()
        LabDiameter = New Label()
        LabBlades = New Label()
        LabRotation = New Label()
        LabMaterial = New Label()
        LabStyle = New Label()
        LabManufacturer = New Label()
        TxtManufacturer = New TextBox()
        TxtStyle = New TextBox()
        TxtMaterial = New TextBox()
        TxtRotation = New TextBox()
        TxtBlades = New TextBox()
        TxtDiameter = New TextBox()
        TxtBore = New TextBox()
        TableCustomerVessel = New TableLayoutPanel()
        TxtVessel = New TextBox()
        TxtCustomer = New TextBox()
        LabVessel = New Label()
        LabCustomer = New Label()
        TableJob = New TableLayoutPanel()
        TxtDescription = New TextBox()
        TxtEmployee = New TextBox()
        TxtClass = New TextBox()
        TxtMeasurement = New TextBox()
        TxtStartDate = New TextBox()
        LabEmployee = New Label()
        LabClass = New Label()
        LabMeasurement = New Label()
        LabStartDate = New Label()
        LabJobNumber = New Label()
        LabDescription = New Label()
        TxtJobNumber = New TextBox()
        ChartBladeAverages = New DataVisualization.Charting.Chart()
        Chart1 = New DataVisualization.Charting.Chart()
        JobDetailsBindingSource = New BindingSource(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).BeginInit()
        PanelHeader.SuspendLayout()
        TablePropeller.SuspendLayout()
        TableCustomerVessel.SuspendLayout()
        TableJob.SuspendLayout()
        CType(ChartBladeAverages, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ' ChartBladeHeight
        ' 
        ChartArea1.Name = "ChartArea1"
        ChartBladeHeight.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        ChartBladeHeight.Legends.Add(Legend1)
        ChartBladeHeight.Location = New Point(18, 216)
        ChartBladeHeight.Name = "ChartBladeHeight"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        ChartBladeHeight.Series.Add(Series1)
        ChartBladeHeight.Size = New Size(221, 179)
        ChartBladeHeight.TabIndex = 2
        ChartBladeHeight.Text = "Track"
        ' 
        ' ChartAngularPosition
        ' 
        ChartArea2.Name = "ChartArea1"
        ChartAngularPosition.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        ChartAngularPosition.Legends.Add(Legend2)
        ChartAngularPosition.Location = New Point(245, 216)
        ChartAngularPosition.Name = "ChartAngularPosition"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        ChartAngularPosition.Series.Add(Series2)
        ChartAngularPosition.Size = New Size(229, 179)
        ChartAngularPosition.TabIndex = 3
        ChartAngularPosition.Text = "Track"
        ' 
        ' PanelHeader
        ' 
        PanelHeader.Controls.Add(TablePropeller)
        PanelHeader.Controls.Add(TableCustomerVessel)
        PanelHeader.Controls.Add(TableJob)
        PanelHeader.Location = New Point(12, 12)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(1181, 156)
        PanelHeader.TabIndex = 4
        ' 
        ' TablePropeller
        ' 
        TablePropeller.ColumnCount = 8
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 69.76744F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.2325573F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 94F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 61F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 55F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 64F))
        TablePropeller.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 587F))
        TablePropeller.Controls.Add(LabBore, 6, 0)
        TablePropeller.Controls.Add(LabDiameter, 5, 0)
        TablePropeller.Controls.Add(LabBlades, 4, 0)
        TablePropeller.Controls.Add(LabRotation, 3, 0)
        TablePropeller.Controls.Add(LabMaterial, 2, 0)
        TablePropeller.Controls.Add(LabStyle, 1, 0)
        TablePropeller.Controls.Add(LabManufacturer, 0, 0)
        TablePropeller.Controls.Add(TxtManufacturer, 0, 1)
        TablePropeller.Controls.Add(TxtStyle, 1, 1)
        TablePropeller.Controls.Add(TxtMaterial, 2, 1)
        TablePropeller.Controls.Add(TxtRotation, 3, 1)
        TablePropeller.Controls.Add(TxtBlades, 4, 1)
        TablePropeller.Controls.Add(TxtDiameter, 5, 1)
        TablePropeller.Controls.Add(TxtBore, 6, 1)
        TablePropeller.Location = New Point(3, 106)
        TablePropeller.Name = "TablePropeller"
        TablePropeller.RowCount = 2
        TablePropeller.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TablePropeller.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TablePropeller.Size = New Size(1175, 46)
        TablePropeller.TabIndex = 2
        ' 
        ' LabBore
        ' 
        LabBore.AutoSize = True
        LabBore.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBore.Location = New Point(526, 0)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(34, 15)
        LabBore.TabIndex = 8
        LabBore.Text = "Bore"
        ' 
        ' LabDiameter
        ' 
        LabDiameter.AutoSize = True
        LabDiameter.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDiameter.Location = New Point(456, 0)
        LabDiameter.Name = "LabDiameter"
        LabDiameter.Size = New Size(60, 15)
        LabDiameter.TabIndex = 7
        LabDiameter.Text = "Diameter"
        ' 
        ' LabBlades
        ' 
        LabBlades.AutoSize = True
        LabBlades.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBlades.Location = New Point(401, 0)
        LabBlades.Name = "LabBlades"
        LabBlades.Size = New Size(43, 15)
        LabBlades.TabIndex = 6
        LabBlades.Text = "Blades"
        ' 
        ' LabRotation
        ' 
        LabRotation.AutoSize = True
        LabRotation.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRotation.Location = New Point(340, 0)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(55, 15)
        LabRotation.TabIndex = 5
        LabRotation.Text = "Rotation"
        ' 
        ' LabMaterial
        ' 
        LabMaterial.AutoSize = True
        LabMaterial.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMaterial.Location = New Point(246, 0)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(53, 15)
        LabMaterial.TabIndex = 4
        LabMaterial.Text = "Material"
        ' 
        ' LabStyle
        ' 
        LabStyle.AutoSize = True
        LabStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStyle.Location = New Point(173, 0)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(35, 15)
        LabStyle.TabIndex = 3
        LabStyle.Text = "Style"
        ' 
        ' LabManufacturer
        ' 
        LabManufacturer.AutoSize = True
        LabManufacturer.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabManufacturer.Location = New Point(3, 0)
        LabManufacturer.Name = "LabManufacturer"
        LabManufacturer.Size = New Size(84, 15)
        LabManufacturer.TabIndex = 2
        LabManufacturer.Text = "Manufacturer"
        ' 
        ' TxtManufacturer
        ' 
        TxtManufacturer.BorderStyle = BorderStyle.None
        TxtManufacturer.Location = New Point(3, 25)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.Size = New Size(164, 16)
        TxtManufacturer.TabIndex = 9
        ' 
        ' TxtStyle
        ' 
        TxtStyle.BorderStyle = BorderStyle.None
        TxtStyle.Location = New Point(173, 25)
        TxtStyle.Name = "TxtStyle"
        TxtStyle.Size = New Size(67, 16)
        TxtStyle.TabIndex = 10
        ' 
        ' TxtMaterial
        ' 
        TxtMaterial.BorderStyle = BorderStyle.None
        TxtMaterial.Location = New Point(246, 25)
        TxtMaterial.Name = "TxtMaterial"
        TxtMaterial.Size = New Size(88, 16)
        TxtMaterial.TabIndex = 11
        ' 
        ' TxtRotation
        ' 
        TxtRotation.BorderStyle = BorderStyle.None
        TxtRotation.Location = New Point(340, 25)
        TxtRotation.Name = "TxtRotation"
        TxtRotation.Size = New Size(55, 16)
        TxtRotation.TabIndex = 12
        ' 
        ' TxtBlades
        ' 
        TxtBlades.BorderStyle = BorderStyle.None
        TxtBlades.Location = New Point(401, 25)
        TxtBlades.Name = "TxtBlades"
        TxtBlades.Size = New Size(49, 16)
        TxtBlades.TabIndex = 13
        ' 
        ' TxtDiameter
        ' 
        TxtDiameter.BorderStyle = BorderStyle.None
        TxtDiameter.Location = New Point(456, 25)
        TxtDiameter.Name = "TxtDiameter"
        TxtDiameter.Size = New Size(64, 16)
        TxtDiameter.TabIndex = 14
        ' 
        ' TxtBore
        ' 
        TxtBore.BorderStyle = BorderStyle.None
        TxtBore.Location = New Point(526, 25)
        TxtBore.Name = "TxtBore"
        TxtBore.Size = New Size(58, 16)
        TxtBore.TabIndex = 15
        ' 
        ' TableCustomerVessel
        ' 
        TableCustomerVessel.ColumnCount = 2
        TableCustomerVessel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableCustomerVessel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableCustomerVessel.Controls.Add(TxtVessel, 1, 1)
        TableCustomerVessel.Controls.Add(TxtCustomer, 0, 1)
        TableCustomerVessel.Controls.Add(LabVessel, 1, 0)
        TableCustomerVessel.Controls.Add(LabCustomer, 0, 0)
        TableCustomerVessel.Location = New Point(3, 56)
        TableCustomerVessel.Name = "TableCustomerVessel"
        TableCustomerVessel.RowCount = 2
        TableCustomerVessel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TableCustomerVessel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TableCustomerVessel.Size = New Size(493, 44)
        TableCustomerVessel.TabIndex = 1
        ' 
        ' TxtVessel
        ' 
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.Location = New Point(249, 25)
        TxtVessel.Name = "TxtVessel"
        TxtVessel.Size = New Size(241, 16)
        TxtVessel.TabIndex = 8
        ' 
        ' TxtCustomer
        ' 
        TxtCustomer.BorderStyle = BorderStyle.None
        TxtCustomer.Location = New Point(3, 25)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.Size = New Size(240, 16)
        TxtCustomer.TabIndex = 7
        ' 
        ' LabVessel
        ' 
        LabVessel.AutoSize = True
        LabVessel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabVessel.Location = New Point(249, 0)
        LabVessel.Name = "LabVessel"
        LabVessel.Size = New Size(41, 15)
        LabVessel.TabIndex = 3
        LabVessel.Text = "Vessel"
        ' 
        ' LabCustomer
        ' 
        LabCustomer.AutoSize = True
        LabCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCustomer.Location = New Point(3, 0)
        LabCustomer.Name = "LabCustomer"
        LabCustomer.Size = New Size(61, 15)
        LabCustomer.TabIndex = 2
        LabCustomer.Text = "Customer"
        ' 
        ' TableJob
        ' 
        TableJob.ColumnCount = 6
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45.1219521F))
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 54.8780479F))
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 91F))
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 57F))
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 166F))
        TableJob.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 615F))
        TableJob.Controls.Add(TxtDescription, 5, 1)
        TableJob.Controls.Add(TxtEmployee, 4, 1)
        TableJob.Controls.Add(TxtClass, 3, 1)
        TableJob.Controls.Add(TxtMeasurement, 2, 1)
        TableJob.Controls.Add(TxtStartDate, 1, 1)
        TableJob.Controls.Add(LabEmployee, 4, 0)
        TableJob.Controls.Add(LabClass, 3, 0)
        TableJob.Controls.Add(LabMeasurement, 2, 0)
        TableJob.Controls.Add(LabStartDate, 1, 0)
        TableJob.Controls.Add(LabJobNumber, 0, 0)
        TableJob.Controls.Add(LabDescription, 5, 0)
        TableJob.Controls.Add(TxtJobNumber, 0, 1)
        TableJob.Location = New Point(3, 3)
        TableJob.Name = "TableJob"
        TableJob.RowCount = 2
        TableJob.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TableJob.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TableJob.Size = New Size(1175, 47)
        TableJob.TabIndex = 0
        ' 
        ' TxtDescription
        ' 
        TxtDescription.BorderStyle = BorderStyle.None
        TxtDescription.Location = New Point(563, 25)
        TxtDescription.Name = "TxtDescription"
        TxtDescription.Size = New Size(609, 16)
        TxtDescription.TabIndex = 11
        ' 
        ' TxtEmployee
        ' 
        TxtEmployee.BorderStyle = BorderStyle.None
        TxtEmployee.Location = New Point(397, 25)
        TxtEmployee.Name = "TxtEmployee"
        TxtEmployee.Size = New Size(160, 16)
        TxtEmployee.TabIndex = 10
        ' 
        ' TxtClass
        ' 
        TxtClass.BorderStyle = BorderStyle.None
        TxtClass.Location = New Point(340, 25)
        TxtClass.Name = "TxtClass"
        TxtClass.Size = New Size(51, 16)
        TxtClass.TabIndex = 9
        ' 
        ' TxtMeasurement
        ' 
        TxtMeasurement.BorderStyle = BorderStyle.None
        TxtMeasurement.Location = New Point(249, 25)
        TxtMeasurement.Name = "TxtMeasurement"
        TxtMeasurement.Size = New Size(85, 16)
        TxtMeasurement.TabIndex = 8
        ' 
        ' TxtStartDate
        ' 
        TxtStartDate.BorderStyle = BorderStyle.None
        TxtStartDate.Location = New Point(114, 25)
        TxtStartDate.Name = "TxtStartDate"
        TxtStartDate.Size = New Size(129, 16)
        TxtStartDate.TabIndex = 7
        ' 
        ' LabEmployee
        ' 
        LabEmployee.AutoSize = True
        LabEmployee.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabEmployee.Location = New Point(397, 0)
        LabEmployee.Name = "LabEmployee"
        LabEmployee.Size = New Size(61, 15)
        LabEmployee.TabIndex = 5
        LabEmployee.Text = "Employee"
        ' 
        ' LabClass
        ' 
        LabClass.AutoSize = True
        LabClass.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabClass.Location = New Point(340, 0)
        LabClass.Name = "LabClass"
        LabClass.Size = New Size(33, 15)
        LabClass.TabIndex = 4
        LabClass.Text = "Class"
        ' 
        ' LabMeasurement
        ' 
        LabMeasurement.AutoSize = True
        LabMeasurement.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMeasurement.Location = New Point(249, 0)
        LabMeasurement.Name = "LabMeasurement"
        LabMeasurement.Size = New Size(85, 15)
        LabMeasurement.TabIndex = 3
        LabMeasurement.Text = "Measurement"
        ' 
        ' LabStartDate
        ' 
        LabStartDate.AutoSize = True
        LabStartDate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStartDate.Location = New Point(114, 0)
        LabStartDate.Name = "LabStartDate"
        LabStartDate.Size = New Size(65, 15)
        LabStartDate.TabIndex = 2
        LabStartDate.Text = "Start Date"
        ' 
        ' LabJobNumber
        ' 
        LabJobNumber.AutoSize = True
        LabJobNumber.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobNumber.Location = New Point(3, 0)
        LabJobNumber.Name = "LabJobNumber"
        LabJobNumber.Size = New Size(26, 15)
        LabJobNumber.TabIndex = 1
        LabJobNumber.Text = "Job"
        ' 
        ' LabDescription
        ' 
        LabDescription.AutoSize = True
        LabDescription.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDescription.Location = New Point(563, 0)
        LabDescription.Name = "LabDescription"
        LabDescription.Size = New Size(71, 15)
        LabDescription.TabIndex = 0
        LabDescription.Text = "Description"
        ' 
        ' TxtJobNumber
        ' 
        TxtJobNumber.BorderStyle = BorderStyle.None
        TxtJobNumber.Location = New Point(3, 25)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.Size = New Size(105, 16)
        TxtJobNumber.TabIndex = 6
        ' 
        ' ChartBladeAverages
        ' 
        ChartArea3.Name = "ChartArea1"
        ChartBladeAverages.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        ChartBladeAverages.Legends.Add(Legend3)
        ChartBladeAverages.Location = New Point(480, 216)
        ChartBladeAverages.Name = "ChartBladeAverages"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        ChartBladeAverages.Series.Add(Series3)
        ChartBladeAverages.Size = New Size(229, 179)
        ChartBladeAverages.TabIndex = 5
        ChartBladeAverages.Text = "Chart1"
        ' 
        ' Chart1
        ' 
        ChartArea4.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Chart1.Legends.Add(Legend4)
        Chart1.Location = New Point(715, 216)
        Chart1.Name = "Chart1"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Chart1.Series.Add(Series4)
        Chart1.Size = New Size(475, 179)
        Chart1.TabIndex = 6
        Chart1.Text = "ChartSummary"
        ' 
        ' JobDetailsBindingSource
        ' 
        JobDetailsBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Location = New Point(18, 425)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(200, 100)
        TableLayoutPanel1.TabIndex = 7
        ' 
        ' FrmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1205, 703)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Chart1)
        Controls.Add(ChartBladeAverages)
        Controls.Add(PanelHeader)
        Controls.Add(ChartBladeHeight)
        Controls.Add(ChartAngularPosition)
        Name = "FrmReports"
        Text = "Reports"
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).EndInit()
        PanelHeader.ResumeLayout(False)
        TablePropeller.ResumeLayout(False)
        TablePropeller.PerformLayout()
        TableCustomerVessel.ResumeLayout(False)
        TableCustomerVessel.PerformLayout()
        TableJob.ResumeLayout(False)
        TableJob.PerformLayout()
        CType(ChartBladeAverages, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        CType(JobDetailsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents ChartBladeHeight As DataVisualization.Charting.Chart
    Friend WithEvents ChartAngularPosition As DataVisualization.Charting.Chart
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents ChartBladeAverages As DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents JobDetailsBindingSource As BindingSource
    Friend WithEvents TableJob As TableLayoutPanel
    Friend WithEvents LabDescription As Label
    Friend WithEvents LabEmployee As Label
    Friend WithEvents LabClass As Label
    Friend WithEvents LabMeasurement As Label
    Friend WithEvents LabStartDate As Label
    Friend WithEvents LabJobNumber As Label
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents TxtEmployee As TextBox
    Friend WithEvents TxtClass As TextBox
    Friend WithEvents TxtMeasurement As TextBox
    Friend WithEvents TxtStartDate As TextBox
    Friend WithEvents TxtJobNumber As TextBox
    Friend WithEvents TableCustomerVessel As TableLayoutPanel
    Friend WithEvents TxtVessel As TextBox
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents LabVessel As Label
    Friend WithEvents LabCustomer As Label
    Friend WithEvents TablePropeller As TableLayoutPanel
    Friend WithEvents LabBore As Label
    Friend WithEvents LabDiameter As Label
    Friend WithEvents LabBlades As Label
    Friend WithEvents LabRotation As Label
    Friend WithEvents LabMaterial As Label
    Friend WithEvents LabStyle As Label
    Friend WithEvents LabManufacturer As Label
    Friend WithEvents TxtManufacturer As TextBox
    Friend WithEvents TxtStyle As TextBox
    Friend WithEvents TxtMaterial As TextBox
    Friend WithEvents TxtRotation As TextBox
    Friend WithEvents TxtBlades As TextBox
    Friend WithEvents TxtDiameter As TextBox
    Friend WithEvents TxtBore As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
