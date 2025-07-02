<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVessels
    Inherits System.Windows.Forms.Form

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
        DataGridView1 = New DataGridView()
        VesselNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CustomerId = New DataGridViewComboBoxColumn()
        CustomerBindingSource = New BindingSource(components)
        PrimaryVesselNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HullIdNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CallSignDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BuildYearDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Flag = New DataGridViewComboBoxColumn()
        CountryCodeBindingSource = New BindingSource(components)
        ServiceTypeId = New DataGridViewComboBoxColumn()
        VesselServiceTypeBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        TableLayoutPanel2 = New TableLayoutPanel()
        DataGridView3 = New DataGridView()
        labVesselJobsTitle = New Label()
        JobsBindingSource = New BindingSource(components)
        IdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        VesselIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StartDateDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InspectedByDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ManufacturerIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PartNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PartDescriptionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        SerialNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StampNumberDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        MaterialDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StyleDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladesDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BladesNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InspectedByNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        JobDetailsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ManufacturerDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        MaterialNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        StyleNavigationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        VesselDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        CType(DataGridView3, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {VesselNameDataGridViewTextBoxColumn, CustomerId, PrimaryVesselNumberDataGridViewTextBoxColumn, HullIdNumberDataGridViewTextBoxColumn, CallSignDataGridViewTextBoxColumn, BuildYearDataGridViewTextBoxColumn, Flag, ServiceTypeId})
        DataGridView1.DataSource = VesselBindingSource
        DataGridView1.Location = New Point(29, 30)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 82
        DataGridView1.Size = New Size(2081, 600)
        DataGridView1.TabIndex = 0
        ' 
        ' VesselNameDataGridViewTextBoxColumn
        ' 
        VesselNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        VesselNameDataGridViewTextBoxColumn.DataPropertyName = "VesselName"
        VesselNameDataGridViewTextBoxColumn.HeaderText = "Vessel Name"
        VesselNameDataGridViewTextBoxColumn.MinimumWidth = 282
        VesselNameDataGridViewTextBoxColumn.Name = "VesselNameDataGridViewTextBoxColumn"
        VesselNameDataGridViewTextBoxColumn.Width = 282
        ' 
        ' CustomerId
        ' 
        CustomerId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CustomerId.DataPropertyName = "CustomerId"
        CustomerId.DataSource = CustomerBindingSource
        CustomerId.DisplayMember = "CustomerName"
        CustomerId.HeaderText = "Customer"
        CustomerId.MinimumWidth = 284
        CustomerId.Name = "CustomerId"
        CustomerId.ValueMember = "Id"
        CustomerId.Width = 284
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataSource = GetType(LibDatabase.Models.Customer)
        ' 
        ' PrimaryVesselNumberDataGridViewTextBoxColumn
        ' 
        PrimaryVesselNumberDataGridViewTextBoxColumn.DataPropertyName = "PrimaryVesselNumber"
        PrimaryVesselNumberDataGridViewTextBoxColumn.HeaderText = "Primary Vessel Number"
        PrimaryVesselNumberDataGridViewTextBoxColumn.MinimumWidth = 310
        PrimaryVesselNumberDataGridViewTextBoxColumn.Name = "PrimaryVesselNumberDataGridViewTextBoxColumn"
        PrimaryVesselNumberDataGridViewTextBoxColumn.Width = 310
        ' 
        ' HullIdNumberDataGridViewTextBoxColumn
        ' 
        HullIdNumberDataGridViewTextBoxColumn.DataPropertyName = "HullIdNumber"
        HullIdNumberDataGridViewTextBoxColumn.HeaderText = "Hull Id Number"
        HullIdNumberDataGridViewTextBoxColumn.MinimumWidth = 234
        HullIdNumberDataGridViewTextBoxColumn.Name = "HullIdNumberDataGridViewTextBoxColumn"
        HullIdNumberDataGridViewTextBoxColumn.Width = 234
        ' 
        ' CallSignDataGridViewTextBoxColumn
        ' 
        CallSignDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        CallSignDataGridViewTextBoxColumn.DataPropertyName = "CallSign"
        CallSignDataGridViewTextBoxColumn.HeaderText = "Call Sign"
        CallSignDataGridViewTextBoxColumn.MinimumWidth = 180
        CallSignDataGridViewTextBoxColumn.Name = "CallSignDataGridViewTextBoxColumn"
        CallSignDataGridViewTextBoxColumn.Width = 180
        ' 
        ' BuildYearDataGridViewTextBoxColumn
        ' 
        BuildYearDataGridViewTextBoxColumn.DataPropertyName = "BuildYear"
        BuildYearDataGridViewTextBoxColumn.HeaderText = "Build Year"
        BuildYearDataGridViewTextBoxColumn.MinimumWidth = 170
        BuildYearDataGridViewTextBoxColumn.Name = "BuildYearDataGridViewTextBoxColumn"
        BuildYearDataGridViewTextBoxColumn.Width = 170
        ' 
        ' Flag
        ' 
        Flag.DataPropertyName = "Flag"
        Flag.DataSource = CountryCodeBindingSource
        Flag.DisplayMember = "Country"
        Flag.HeaderText = "Flag"
        Flag.MinimumWidth = 272
        Flag.Name = "Flag"
        Flag.ValueMember = "Alpha2Code"
        Flag.Width = 272
        ' 
        ' CountryCodeBindingSource
        ' 
        CountryCodeBindingSource.DataSource = GetType(LibDatabase.Models.CountryCode)
        ' 
        ' ServiceTypeId
        ' 
        ServiceTypeId.DataPropertyName = "ServiceTypeId"
        ServiceTypeId.DataSource = VesselServiceTypeBindingSource
        ServiceTypeId.DisplayMember = "ServiceType"
        ServiceTypeId.HeaderText = "Service Type"
        ServiceTypeId.MinimumWidth = 224
        ServiceTypeId.Name = "ServiceTypeId"
        ServiceTypeId.ValueMember = "Id"
        ServiceTypeId.Width = 224
        ' 
        ' VesselServiceTypeBindingSource
        ' 
        VesselServiceTypeBindingSource.DataSource = GetType(LibDatabase.Models.VesselServiceType)
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataSource = GetType(LibDatabase.Models.Vessel)
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(DataGridView3, 0, 1)
        TableLayoutPanel2.Controls.Add(labVesselJobsTitle, 0, 0)
        TableLayoutPanel2.Location = New Point(29, 670)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(2081, 336)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' DataGridView3
        ' 
        DataGridView3.AllowUserToAddRows = False
        DataGridView3.AllowUserToDeleteRows = False
        DataGridView3.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView3.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn, VesselIdDataGridViewTextBoxColumn, JobNumberDataGridViewTextBoxColumn, StartDateDataGridViewTextBoxColumn, DescriptionDataGridViewTextBoxColumn, InspectedByDataGridViewTextBoxColumn, ManufacturerIdDataGridViewTextBoxColumn, PartNumberDataGridViewTextBoxColumn, PartDescriptionDataGridViewTextBoxColumn, SerialNumberDataGridViewTextBoxColumn, StampNumberDataGridViewTextBoxColumn, MaterialDataGridViewTextBoxColumn, StyleDataGridViewTextBoxColumn, BladesDataGridViewTextBoxColumn, BladesNavigationDataGridViewTextBoxColumn, InspectedByNavigationDataGridViewTextBoxColumn, JobDetailsDataGridViewTextBoxColumn, ManufacturerDataGridViewTextBoxColumn, MaterialNavigationDataGridViewTextBoxColumn, StyleNavigationDataGridViewTextBoxColumn, VesselDataGridViewTextBoxColumn})
        DataGridView3.DataSource = JobsBindingSource
        DataGridView3.Location = New Point(0, 35)
        DataGridView3.Margin = New Padding(0)
        DataGridView3.Name = "DataGridView3"
        DataGridView3.RowHeadersWidth = 82
        DataGridView3.Size = New Size(2081, 301)
        DataGridView3.TabIndex = 3
        ' 
        ' labVesselJobsTitle
        ' 
        labVesselJobsTitle.AutoSize = True
        labVesselJobsTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        labVesselJobsTitle.Location = New Point(0, 0)
        labVesselJobsTitle.Margin = New Padding(0, 0, 3, 3)
        labVesselJobsTitle.Name = "labVesselJobsTitle"
        labVesselJobsTitle.Size = New Size(66, 32)
        labVesselJobsTitle.TabIndex = 0
        labVesselJobsTitle.Text = "Jobs"
        ' 
        ' JobsBindingSource
        ' 
        JobsBindingSource.DataSource = GetType(LibDatabase.Models.Job)
        ' 
        ' IdDataGridViewTextBoxColumn
        ' 
        IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn.HeaderText = "Id"
        IdDataGridViewTextBoxColumn.MinimumWidth = 10
        IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        IdDataGridViewTextBoxColumn.Width = 200
        ' 
        ' VesselIdDataGridViewTextBoxColumn
        ' 
        VesselIdDataGridViewTextBoxColumn.DataPropertyName = "VesselId"
        VesselIdDataGridViewTextBoxColumn.HeaderText = "VesselId"
        VesselIdDataGridViewTextBoxColumn.MinimumWidth = 10
        VesselIdDataGridViewTextBoxColumn.Name = "VesselIdDataGridViewTextBoxColumn"
        VesselIdDataGridViewTextBoxColumn.Width = 200
        ' 
        ' JobNumberDataGridViewTextBoxColumn
        ' 
        JobNumberDataGridViewTextBoxColumn.DataPropertyName = "JobNumber"
        JobNumberDataGridViewTextBoxColumn.HeaderText = "JobNumber"
        JobNumberDataGridViewTextBoxColumn.MinimumWidth = 10
        JobNumberDataGridViewTextBoxColumn.Name = "JobNumberDataGridViewTextBoxColumn"
        JobNumberDataGridViewTextBoxColumn.Width = 200
        ' 
        ' StartDateDataGridViewTextBoxColumn
        ' 
        StartDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate"
        StartDateDataGridViewTextBoxColumn.HeaderText = "StartDate"
        StartDateDataGridViewTextBoxColumn.MinimumWidth = 10
        StartDateDataGridViewTextBoxColumn.Name = "StartDateDataGridViewTextBoxColumn"
        StartDateDataGridViewTextBoxColumn.Width = 200
        ' 
        ' DescriptionDataGridViewTextBoxColumn
        ' 
        DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        DescriptionDataGridViewTextBoxColumn.MinimumWidth = 10
        DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        DescriptionDataGridViewTextBoxColumn.Width = 200
        ' 
        ' InspectedByDataGridViewTextBoxColumn
        ' 
        InspectedByDataGridViewTextBoxColumn.DataPropertyName = "InspectedBy"
        InspectedByDataGridViewTextBoxColumn.HeaderText = "InspectedBy"
        InspectedByDataGridViewTextBoxColumn.MinimumWidth = 10
        InspectedByDataGridViewTextBoxColumn.Name = "InspectedByDataGridViewTextBoxColumn"
        InspectedByDataGridViewTextBoxColumn.Width = 200
        ' 
        ' ManufacturerIdDataGridViewTextBoxColumn
        ' 
        ManufacturerIdDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerId"
        ManufacturerIdDataGridViewTextBoxColumn.HeaderText = "ManufacturerId"
        ManufacturerIdDataGridViewTextBoxColumn.MinimumWidth = 10
        ManufacturerIdDataGridViewTextBoxColumn.Name = "ManufacturerIdDataGridViewTextBoxColumn"
        ManufacturerIdDataGridViewTextBoxColumn.Width = 200
        ' 
        ' PartNumberDataGridViewTextBoxColumn
        ' 
        PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.HeaderText = "PartNumber"
        PartNumberDataGridViewTextBoxColumn.MinimumWidth = 10
        PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        PartNumberDataGridViewTextBoxColumn.Width = 200
        ' 
        ' PartDescriptionDataGridViewTextBoxColumn
        ' 
        PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        PartDescriptionDataGridViewTextBoxColumn.HeaderText = "PartDescription"
        PartDescriptionDataGridViewTextBoxColumn.MinimumWidth = 10
        PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        PartDescriptionDataGridViewTextBoxColumn.Width = 200
        ' 
        ' SerialNumberDataGridViewTextBoxColumn
        ' 
        SerialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber"
        SerialNumberDataGridViewTextBoxColumn.HeaderText = "SerialNumber"
        SerialNumberDataGridViewTextBoxColumn.MinimumWidth = 10
        SerialNumberDataGridViewTextBoxColumn.Name = "SerialNumberDataGridViewTextBoxColumn"
        SerialNumberDataGridViewTextBoxColumn.Width = 200
        ' 
        ' StampNumberDataGridViewTextBoxColumn
        ' 
        StampNumberDataGridViewTextBoxColumn.DataPropertyName = "StampNumber"
        StampNumberDataGridViewTextBoxColumn.HeaderText = "StampNumber"
        StampNumberDataGridViewTextBoxColumn.MinimumWidth = 10
        StampNumberDataGridViewTextBoxColumn.Name = "StampNumberDataGridViewTextBoxColumn"
        StampNumberDataGridViewTextBoxColumn.Width = 200
        ' 
        ' MaterialDataGridViewTextBoxColumn
        ' 
        MaterialDataGridViewTextBoxColumn.DataPropertyName = "Material"
        MaterialDataGridViewTextBoxColumn.HeaderText = "Material"
        MaterialDataGridViewTextBoxColumn.MinimumWidth = 10
        MaterialDataGridViewTextBoxColumn.Name = "MaterialDataGridViewTextBoxColumn"
        MaterialDataGridViewTextBoxColumn.Width = 200
        ' 
        ' StyleDataGridViewTextBoxColumn
        ' 
        StyleDataGridViewTextBoxColumn.DataPropertyName = "Style"
        StyleDataGridViewTextBoxColumn.HeaderText = "Style"
        StyleDataGridViewTextBoxColumn.MinimumWidth = 10
        StyleDataGridViewTextBoxColumn.Name = "StyleDataGridViewTextBoxColumn"
        StyleDataGridViewTextBoxColumn.Width = 200
        ' 
        ' BladesDataGridViewTextBoxColumn
        ' 
        BladesDataGridViewTextBoxColumn.DataPropertyName = "Blades"
        BladesDataGridViewTextBoxColumn.HeaderText = "Blades"
        BladesDataGridViewTextBoxColumn.MinimumWidth = 10
        BladesDataGridViewTextBoxColumn.Name = "BladesDataGridViewTextBoxColumn"
        BladesDataGridViewTextBoxColumn.Width = 200
        ' 
        ' BladesNavigationDataGridViewTextBoxColumn
        ' 
        BladesNavigationDataGridViewTextBoxColumn.DataPropertyName = "BladesNavigation"
        BladesNavigationDataGridViewTextBoxColumn.HeaderText = "BladesNavigation"
        BladesNavigationDataGridViewTextBoxColumn.MinimumWidth = 10
        BladesNavigationDataGridViewTextBoxColumn.Name = "BladesNavigationDataGridViewTextBoxColumn"
        BladesNavigationDataGridViewTextBoxColumn.Width = 200
        ' 
        ' InspectedByNavigationDataGridViewTextBoxColumn
        ' 
        InspectedByNavigationDataGridViewTextBoxColumn.DataPropertyName = "InspectedByNavigation"
        InspectedByNavigationDataGridViewTextBoxColumn.HeaderText = "InspectedByNavigation"
        InspectedByNavigationDataGridViewTextBoxColumn.MinimumWidth = 10
        InspectedByNavigationDataGridViewTextBoxColumn.Name = "InspectedByNavigationDataGridViewTextBoxColumn"
        InspectedByNavigationDataGridViewTextBoxColumn.Width = 200
        ' 
        ' JobDetailsDataGridViewTextBoxColumn
        ' 
        JobDetailsDataGridViewTextBoxColumn.DataPropertyName = "JobDetails"
        JobDetailsDataGridViewTextBoxColumn.HeaderText = "JobDetails"
        JobDetailsDataGridViewTextBoxColumn.MinimumWidth = 10
        JobDetailsDataGridViewTextBoxColumn.Name = "JobDetailsDataGridViewTextBoxColumn"
        JobDetailsDataGridViewTextBoxColumn.Width = 200
        ' 
        ' ManufacturerDataGridViewTextBoxColumn
        ' 
        ManufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer"
        ManufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer"
        ManufacturerDataGridViewTextBoxColumn.MinimumWidth = 10
        ManufacturerDataGridViewTextBoxColumn.Name = "ManufacturerDataGridViewTextBoxColumn"
        ManufacturerDataGridViewTextBoxColumn.Width = 200
        ' 
        ' MaterialNavigationDataGridViewTextBoxColumn
        ' 
        MaterialNavigationDataGridViewTextBoxColumn.DataPropertyName = "MaterialNavigation"
        MaterialNavigationDataGridViewTextBoxColumn.HeaderText = "MaterialNavigation"
        MaterialNavigationDataGridViewTextBoxColumn.MinimumWidth = 10
        MaterialNavigationDataGridViewTextBoxColumn.Name = "MaterialNavigationDataGridViewTextBoxColumn"
        MaterialNavigationDataGridViewTextBoxColumn.Width = 200
        ' 
        ' StyleNavigationDataGridViewTextBoxColumn
        ' 
        StyleNavigationDataGridViewTextBoxColumn.DataPropertyName = "StyleNavigation"
        StyleNavigationDataGridViewTextBoxColumn.HeaderText = "StyleNavigation"
        StyleNavigationDataGridViewTextBoxColumn.MinimumWidth = 10
        StyleNavigationDataGridViewTextBoxColumn.Name = "StyleNavigationDataGridViewTextBoxColumn"
        StyleNavigationDataGridViewTextBoxColumn.Width = 200
        ' 
        ' VesselDataGridViewTextBoxColumn
        ' 
        VesselDataGridViewTextBoxColumn.DataPropertyName = "Vessel"
        VesselDataGridViewTextBoxColumn.HeaderText = "Vessel"
        VesselDataGridViewTextBoxColumn.MinimumWidth = 10
        VesselDataGridViewTextBoxColumn.Name = "VesselDataGridViewTextBoxColumn"
        VesselDataGridViewTextBoxColumn.Width = 200
        ' 
        ' FrmVessels
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2136, 1134)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(DataGridView1)
        Name = "FrmVessels"
        Text = "Vessels"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CountryCodeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselServiceTypeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(DataGridView3, ComponentModel.ISupportInitialize).EndInit()
        CType(JobsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents CountryCodeBindingSource As BindingSource
    Friend WithEvents VesselServiceTypeBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents VesselNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerId As DataGridViewComboBoxColumn
    Friend WithEvents PrimaryVesselNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HullIdNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CallSignDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BuildYearDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Flag As DataGridViewComboBoxColumn
    Friend WithEvents ServiceTypeId As DataGridViewComboBoxColumn
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents labVesselJobsTitle As Label
    Friend WithEvents JobsBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VesselIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InspectedByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ManufacturerIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StampNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MaterialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StyleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BladesNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InspectedByNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JobDetailsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ManufacturerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MaterialNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StyleNavigationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VesselDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
