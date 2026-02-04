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
        ReportsBindingSource = New BindingSource(components)
        FormMenuStrip = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        FileNewToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator11 = New ToolStripSeparator()
        OpenToolStripMenuItem = New ToolStripMenuItem()
        FileRecentToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        CloseToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        SaveToolStripMenuItem = New ToolStripMenuItem()
        SaveAsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        FilePrintToolStripMenuItem = New ToolStripMenuItem()
        PrintToolStripMenuItem = New ToolStripMenuItem()
        PrintPreviewToolStripMenuItem = New ToolStripMenuItem()
        PageSetupToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        EditToolStripMenuItem = New ToolStripMenuItem()
        CutToolStripMenuItem = New ToolStripMenuItem()
        CopyToolStripMenuItem = New ToolStripMenuItem()
        PasteToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator9 = New ToolStripSeparator()
        SelectAllToolStripMenuItem = New ToolStripMenuItem()
        JobsToolStripMenuItem = New ToolStripMenuItem()
        JobsOpenToolStripMenuItem = New ToolStripMenuItem()
        JobsRecentToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator13 = New ToolStripSeparator()
        JobsCloseToolStripMenuItem = New ToolStripMenuItem()
        ReportsToolStripMenuItem = New ToolStripMenuItem()
        ReportsToolStripSeparator1 = New ToolStripSeparator()
        ReportsEditToolStripMenuItem = New ToolStripMenuItem()
        ReportsImportToolStripMenuItem = New ToolStripMenuItem()
        ReportsExportToolStripMenuItem = New ToolStripMenuItem()
        ElementsToolStripMenuItem = New ToolStripMenuItem()
        LetterheadToolStripMenuItem = New ToolStripMenuItem()
        LetterheadImageToolStripMenuItem = New ToolStripMenuItem()
        HeaderToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator8 = New ToolStripSeparator()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripMenuItem()
        ReportContextMenuStrip = New ContextMenuStrip(components)
        UndoContextMenuItem = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        CutContextMenuItem = New ToolStripMenuItem()
        PasteContextMenuItem = New ToolStripMenuItem()
        DeleteContextMenuItem = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        BringToFrontContextMenuItem = New ToolStripMenuItem()
        SendToBackContextMenuItem = New ToolStripMenuItem()
        ToolStripSeparator10 = New ToolStripSeparator()
        SelectAllContextMenuItem = New ToolStripMenuItem()
        ToolStripSeparator7 = New ToolStripSeparator()
        AddNewContextMenuItem = New ToolStripMenuItem()
        ReportDataBindingSource = New BindingSource(components)
        Letterhead = New PictureBox()
        Header = New TableLayoutPanel()
        TxtWheelPitch = New TextBox()
        TxtMarkedPitch = New TextBox()
        JobBindingSource = New BindingSource(components)
        TxtMeasuredDiameter = New TextBox()
        TxtMarkedDiameter = New TextBox()
        TxtRotation = New TextBox()
        TxtPerformedBy = New TextBox()
        EmployeeBindingSource = New BindingSource(components)
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
        CustomerBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        TxtVessel = New TextBox()
        TxtManufacturer = New TextBox()
        ManufacturerBindingSource = New BindingSource(components)
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
        PrintDocument = New Printing.PrintDocument()
        PrintPreviewDialog = New PrintPreviewDialog()
        PageSetupDialog = New PageSetupDialog()
        ChartBladeHeight = New DataVisualization.Charting.Chart()
        ChartAngularPosition = New DataVisualization.Charting.Chart()
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        FormMenuStrip.SuspendLayout()
        ReportContextMenuStrip.SuspendLayout()
        CType(ReportDataBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(Letterhead, ComponentModel.ISupportInitialize).BeginInit()
        Header.SuspendLayout()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ReportsBindingSource
        ' 
        ReportsBindingSource.DataSource = GetType(LibDatabase.Models.Report)
        ReportsBindingSource.Sort = "ReportName"
        ' 
        ' FormMenuStrip
        ' 
        FormMenuStrip.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, JobsToolStripMenuItem, ReportsToolStripMenuItem, ElementsToolStripMenuItem, SettingsToolStripMenuItem})
        FormMenuStrip.Location = New Point(0, 0)
        FormMenuStrip.Name = "FormMenuStrip"
        FormMenuStrip.Size = New Size(850, 24)
        FormMenuStrip.TabIndex = 2
        FormMenuStrip.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {FileNewToolStripMenuItem, ToolStripSeparator11, OpenToolStripMenuItem, FileRecentToolStripMenuItem, ToolStripSeparator1, CloseToolStripMenuItem, ToolStripSeparator3, SaveToolStripMenuItem, SaveAsToolStripMenuItem, ToolStripSeparator4, FilePrintToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' FileNewToolStripMenuItem
        ' 
        FileNewToolStripMenuItem.Name = "FileNewToolStripMenuItem"
        FileNewToolStripMenuItem.Size = New Size(186, 22)
        FileNewToolStripMenuItem.Text = "New"
        ' 
        ' ToolStripSeparator11
        ' 
        ToolStripSeparator11.Name = "ToolStripSeparator11"
        ToolStripSeparator11.Size = New Size(183, 6)
        ' 
        ' OpenToolStripMenuItem
        ' 
        OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        OpenToolStripMenuItem.Size = New Size(186, 22)
        OpenToolStripMenuItem.Text = "Open"
        ' 
        ' FileRecentToolStripMenuItem
        ' 
        FileRecentToolStripMenuItem.Name = "FileRecentToolStripMenuItem"
        FileRecentToolStripMenuItem.Size = New Size(186, 22)
        FileRecentToolStripMenuItem.Text = "Recent"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(183, 6)
        ' 
        ' CloseToolStripMenuItem
        ' 
        CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        CloseToolStripMenuItem.Size = New Size(186, 22)
        CloseToolStripMenuItem.Text = "Close"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(183, 6)
        ' 
        ' SaveToolStripMenuItem
        ' 
        SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), Image)
        SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        SaveToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        SaveToolStripMenuItem.Size = New Size(186, 22)
        SaveToolStripMenuItem.Text = "Save"
        ' 
        ' SaveAsToolStripMenuItem
        ' 
        SaveAsToolStripMenuItem.Image = CType(resources.GetObject("SaveAsToolStripMenuItem.Image"), Image)
        SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        SaveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S"
        SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Shift Or Keys.S
        SaveAsToolStripMenuItem.Size = New Size(186, 22)
        SaveAsToolStripMenuItem.Text = "Save As"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(183, 6)
        ' 
        ' FilePrintToolStripMenuItem
        ' 
        FilePrintToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PrintToolStripMenuItem, PrintPreviewToolStripMenuItem, PageSetupToolStripMenuItem})
        FilePrintToolStripMenuItem.Name = "FilePrintToolStripMenuItem"
        FilePrintToolStripMenuItem.Size = New Size(186, 22)
        FilePrintToolStripMenuItem.Text = "Print"
        ' 
        ' PrintToolStripMenuItem
        ' 
        PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        PrintToolStripMenuItem.Size = New Size(143, 22)
        PrintToolStripMenuItem.Text = "Print"
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
        ToolStripSeparator2.Size = New Size(183, 6)
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(186, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem, DeleteToolStripMenuItem, ToolStripSeparator9, SelectAllToolStripMenuItem})
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(39, 20)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' CutToolStripMenuItem
        ' 
        CutToolStripMenuItem.Enabled = False
        CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), Image)
        CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        CutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X"
        CutToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.X
        CutToolStripMenuItem.Size = New Size(164, 22)
        CutToolStripMenuItem.Text = "Cut"
        ' 
        ' CopyToolStripMenuItem
        ' 
        CopyToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), Image)
        CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        CopyToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.C
        CopyToolStripMenuItem.Size = New Size(164, 22)
        CopyToolStripMenuItem.Text = "Copy"
        ' 
        ' PasteToolStripMenuItem
        ' 
        PasteToolStripMenuItem.Enabled = False
        PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), Image)
        PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        PasteToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.V
        PasteToolStripMenuItem.Size = New Size(164, 22)
        PasteToolStripMenuItem.Text = "Paste"
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Image = My.Resources.Resources.Cancel
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        DeleteToolStripMenuItem.ShortcutKeys = Keys.Delete
        DeleteToolStripMenuItem.Size = New Size(164, 22)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' ToolStripSeparator9
        ' 
        ToolStripSeparator9.Name = "ToolStripSeparator9"
        ToolStripSeparator9.Size = New Size(161, 6)
        ' 
        ' SelectAllToolStripMenuItem
        ' 
        SelectAllToolStripMenuItem.Enabled = False
        SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), Image)
        SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A"
        SelectAllToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.A
        SelectAllToolStripMenuItem.Size = New Size(164, 22)
        SelectAllToolStripMenuItem.Text = "Select All"
        ' 
        ' JobsToolStripMenuItem
        ' 
        JobsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {JobsOpenToolStripMenuItem, JobsRecentToolStripMenuItem, ToolStripSeparator13, JobsCloseToolStripMenuItem})
        JobsToolStripMenuItem.Name = "JobsToolStripMenuItem"
        JobsToolStripMenuItem.Size = New Size(42, 20)
        JobsToolStripMenuItem.Text = "Jobs"
        ' 
        ' JobsOpenToolStripMenuItem
        ' 
        JobsOpenToolStripMenuItem.Name = "JobsOpenToolStripMenuItem"
        JobsOpenToolStripMenuItem.Size = New Size(110, 22)
        JobsOpenToolStripMenuItem.Text = "Open"
        ' 
        ' JobsRecentToolStripMenuItem
        ' 
        JobsRecentToolStripMenuItem.Name = "JobsRecentToolStripMenuItem"
        JobsRecentToolStripMenuItem.Size = New Size(110, 22)
        JobsRecentToolStripMenuItem.Text = "Recent"
        ' 
        ' ToolStripSeparator13
        ' 
        ToolStripSeparator13.Name = "ToolStripSeparator13"
        ToolStripSeparator13.Size = New Size(107, 6)
        ' 
        ' JobsCloseToolStripMenuItem
        ' 
        JobsCloseToolStripMenuItem.Name = "JobsCloseToolStripMenuItem"
        JobsCloseToolStripMenuItem.Size = New Size(110, 22)
        JobsCloseToolStripMenuItem.Text = "Close"
        ' 
        ' ReportsToolStripMenuItem
        ' 
        ReportsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ReportsToolStripSeparator1, ReportsEditToolStripMenuItem, ReportsImportToolStripMenuItem, ReportsExportToolStripMenuItem})
        ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        ReportsToolStripMenuItem.Size = New Size(59, 20)
        ReportsToolStripMenuItem.Text = "Reports"
        ' 
        ' ReportsToolStripSeparator1
        ' 
        ReportsToolStripSeparator1.Name = "ReportsToolStripSeparator1"
        ReportsToolStripSeparator1.Size = New Size(107, 6)
        ' 
        ' ReportsEditToolStripMenuItem
        ' 
        ReportsEditToolStripMenuItem.Name = "ReportsEditToolStripMenuItem"
        ReportsEditToolStripMenuItem.Size = New Size(110, 22)
        ReportsEditToolStripMenuItem.Text = "Edit"
        ' 
        ' ReportsImportToolStripMenuItem
        ' 
        ReportsImportToolStripMenuItem.Name = "ReportsImportToolStripMenuItem"
        ReportsImportToolStripMenuItem.Size = New Size(110, 22)
        ReportsImportToolStripMenuItem.Text = "Import"
        ' 
        ' ReportsExportToolStripMenuItem
        ' 
        ReportsExportToolStripMenuItem.Enabled = False
        ReportsExportToolStripMenuItem.Name = "ReportsExportToolStripMenuItem"
        ReportsExportToolStripMenuItem.Size = New Size(110, 22)
        ReportsExportToolStripMenuItem.Text = "Export"
        ' 
        ' ElementsToolStripMenuItem
        ' 
        ElementsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LetterheadToolStripMenuItem, HeaderToolStripMenuItem, ToolStripSeparator8})
        ElementsToolStripMenuItem.Enabled = False
        ElementsToolStripMenuItem.Name = "ElementsToolStripMenuItem"
        ElementsToolStripMenuItem.Size = New Size(67, 20)
        ElementsToolStripMenuItem.Text = "Elements"
        ' 
        ' LetterheadToolStripMenuItem
        ' 
        LetterheadToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LetterheadImageToolStripMenuItem})
        LetterheadToolStripMenuItem.Name = "LetterheadToolStripMenuItem"
        LetterheadToolStripMenuItem.Size = New Size(130, 22)
        LetterheadToolStripMenuItem.Text = "Letterhead"
        ' 
        ' LetterheadImageToolStripMenuItem
        ' 
        LetterheadImageToolStripMenuItem.Name = "LetterheadImageToolStripMenuItem"
        LetterheadImageToolStripMenuItem.Size = New Size(107, 22)
        LetterheadImageToolStripMenuItem.Text = "Image"
        ' 
        ' HeaderToolStripMenuItem
        ' 
        HeaderToolStripMenuItem.Name = "HeaderToolStripMenuItem"
        HeaderToolStripMenuItem.Size = New Size(130, 22)
        HeaderToolStripMenuItem.Text = "Header"
        ' 
        ' ToolStripSeparator8
        ' 
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New Size(127, 6)
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem1})
        SettingsToolStripMenuItem.Enabled = False
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(61, 20)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem2, ToolStripMenuItem3, ToolStripMenuItem4, ToolStripMenuItem5})
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(101, 22)
        ToolStripMenuItem1.Text = "Class"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(83, 22)
        ToolStripMenuItem2.Text = "I"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(83, 22)
        ToolStripMenuItem3.Text = "II"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(83, 22)
        ToolStripMenuItem4.Text = "III"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(83, 22)
        ToolStripMenuItem5.Text = "S"
        ' 
        ' ReportContextMenuStrip
        ' 
        ReportContextMenuStrip.Items.AddRange(New ToolStripItem() {UndoContextMenuItem, ToolStripSeparator6, CutContextMenuItem, PasteContextMenuItem, DeleteContextMenuItem, ToolStripSeparator5, BringToFrontContextMenuItem, SendToBackContextMenuItem, ToolStripSeparator10, SelectAllContextMenuItem, ToolStripSeparator7, AddNewContextMenuItem})
        ReportContextMenuStrip.Name = "ContextMenuStrip1"
        ReportContextMenuStrip.Size = New Size(165, 204)
        ' 
        ' UndoContextMenuItem
        ' 
        UndoContextMenuItem.Name = "UndoContextMenuItem"
        UndoContextMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
        UndoContextMenuItem.Size = New Size(164, 22)
        UndoContextMenuItem.Text = "Undo"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(161, 6)
        ' 
        ' CutContextMenuItem
        ' 
        CutContextMenuItem.Name = "CutContextMenuItem"
        CutContextMenuItem.ShortcutKeys = Keys.Control Or Keys.X
        CutContextMenuItem.Size = New Size(164, 22)
        CutContextMenuItem.Text = "Cut"
        ' 
        ' PasteContextMenuItem
        ' 
        PasteContextMenuItem.Name = "PasteContextMenuItem"
        PasteContextMenuItem.ShortcutKeys = Keys.Control Or Keys.V
        PasteContextMenuItem.Size = New Size(164, 22)
        PasteContextMenuItem.Text = "Paste"
        ' 
        ' DeleteContextMenuItem
        ' 
        DeleteContextMenuItem.Name = "DeleteContextMenuItem"
        DeleteContextMenuItem.ShortcutKeys = Keys.Delete
        DeleteContextMenuItem.Size = New Size(164, 22)
        DeleteContextMenuItem.Text = "Delete"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(161, 6)
        ' 
        ' BringToFrontContextMenuItem
        ' 
        BringToFrontContextMenuItem.Name = "BringToFrontContextMenuItem"
        BringToFrontContextMenuItem.Size = New Size(164, 22)
        BringToFrontContextMenuItem.Text = "Bring To Front"
        ' 
        ' SendToBackContextMenuItem
        ' 
        SendToBackContextMenuItem.Name = "SendToBackContextMenuItem"
        SendToBackContextMenuItem.Size = New Size(164, 22)
        SendToBackContextMenuItem.Text = "Send To Back"
        ' 
        ' ToolStripSeparator10
        ' 
        ToolStripSeparator10.Name = "ToolStripSeparator10"
        ToolStripSeparator10.Size = New Size(161, 6)
        ' 
        ' SelectAllContextMenuItem
        ' 
        SelectAllContextMenuItem.Name = "SelectAllContextMenuItem"
        SelectAllContextMenuItem.ShortcutKeys = Keys.Control Or Keys.A
        SelectAllContextMenuItem.Size = New Size(164, 22)
        SelectAllContextMenuItem.Text = "Select All"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(161, 6)
        ' 
        ' AddNewContextMenuItem
        ' 
        AddNewContextMenuItem.Name = "AddNewContextMenuItem"
        AddNewContextMenuItem.Size = New Size(164, 22)
        AddNewContextMenuItem.Text = "Add New"
        ' 
        ' ReportDataBindingSource
        ' 
        ReportDataBindingSource.AllowNew = False
        ReportDataBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' Letterhead
        ' 
        Letterhead.BorderStyle = BorderStyle.FixedSingle
        Letterhead.Location = New Point(12, 27)
        Letterhead.MaximumSize = New Size(827, 111)
        Letterhead.MinimumSize = New Size(16, 16)
        Letterhead.Name = "Letterhead"
        Letterhead.Size = New Size(827, 111)
        Letterhead.SizeMode = PictureBoxSizeMode.StretchImage
        Letterhead.TabIndex = 21
        Letterhead.TabStop = False
        Letterhead.Visible = False
        ' 
        ' Header
        ' 
        Header.ColumnCount = 6
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.121212F))
        Header.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.212122F))
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
        Header.Location = New Point(12, 144)
        Header.Name = "Header"
        Header.RowCount = 8
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        Header.Size = New Size(827, 224)
        Header.TabIndex = 22
        Header.Visible = False
        ' 
        ' TxtWheelPitch
        ' 
        TxtWheelPitch.Anchor = AnchorStyles.Left
        TxtWheelPitch.BorderStyle = BorderStyle.None
        TxtWheelPitch.DataBindings.Add(New Binding("Text", ReportDataBindingSource, "WheelPitch", True))
        TxtWheelPitch.Location = New Point(653, 202)
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
        TxtMarkedPitch.DataBindings.Add(New Binding("Text", JobBindingSource, "MarkedPitch", True))
        TxtMarkedPitch.Location = New Point(653, 174)
        TxtMarkedPitch.Name = "TxtMarkedPitch"
        TxtMarkedPitch.ReadOnly = True
        TxtMarkedPitch.Size = New Size(168, 16)
        TxtMarkedPitch.TabIndex = 48
        TxtMarkedPitch.TabStop = False
        TxtMarkedPitch.Tag = "MrkPit"
        TxtMarkedPitch.Visible = False
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataMember = "Job"
        JobBindingSource.DataSource = ReportDataBindingSource
        ' 
        ' TxtMeasuredDiameter
        ' 
        TxtMeasuredDiameter.Anchor = AnchorStyles.Left
        TxtMeasuredDiameter.BorderStyle = BorderStyle.None
        TxtMeasuredDiameter.Location = New Point(653, 146)
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
        TxtMarkedDiameter.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerDiameter", True))
        TxtMarkedDiameter.Location = New Point(653, 118)
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
        TxtRotation.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerRotation", True))
        TxtRotation.Location = New Point(653, 90)
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
        TxtPerformedBy.DataBindings.Add(New Binding("Text", EmployeeBindingSource, "EmployeeName", True))
        TxtPerformedBy.Location = New Point(653, 62)
        TxtPerformedBy.Name = "TxtPerformedBy"
        TxtPerformedBy.ReadOnly = True
        TxtPerformedBy.Size = New Size(168, 16)
        TxtPerformedBy.TabIndex = 44
        TxtPerformedBy.TabStop = False
        TxtPerformedBy.Tag = "PerfBy"
        TxtPerformedBy.Visible = False
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.AllowNew = False
        EmployeeBindingSource.DataMember = "PerformedByNavigation"
        EmployeeBindingSource.DataSource = ReportDataBindingSource
        EmployeeBindingSource.Sort = ""
        ' 
        ' TxtScanDate
        ' 
        TxtScanDate.Anchor = AnchorStyles.Left
        TxtScanDate.BorderStyle = BorderStyle.None
        TxtScanDate.DataBindings.Add(New Binding("Text", ReportDataBindingSource, "StartDate", True))
        TxtScanDate.Location = New Point(653, 34)
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
        TxtFileName.DataBindings.Add(New Binding("Text", ReportDataBindingSource, "FileName", True))
        TxtFileName.Location = New Point(653, 6)
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
        LabFilename.Location = New Point(553, 6)
        LabFilename.Name = "LabFilename"
        LabFilename.Size = New Size(62, 15)
        LabFilename.TabIndex = 34
        LabFilename.Text = "File Name"
        LabFilename.Visible = False
        ' 
        ' LabJobId
        ' 
        LabJobId.Anchor = AnchorStyles.Left
        LabJobId.AutoSize = True
        LabJobId.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabJobId.ForeColor = SystemColors.ControlText
        LabJobId.Location = New Point(278, 6)
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
        LabJobNumber.Location = New Point(3, 6)
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
        LabCustomer.Location = New Point(3, 34)
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
        LabVessel.Location = New Point(3, 62)
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
        LabManufacturer.Location = New Point(3, 90)
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
        LabPartNumber.Location = New Point(3, 118)
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
        LabSerialNumber.Location = New Point(3, 146)
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
        LabStampNumber.Location = New Point(3, 174)
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
        LabInspectedBy.Location = New Point(3, 202)
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
        TxtCustomer.DataBindings.Add(New Binding("Text", CustomerBindingSource, "CustomerName", True))
        TxtCustomer.Location = New Point(103, 34)
        TxtCustomer.Name = "TxtCustomer"
        TxtCustomer.ReadOnly = True
        TxtCustomer.Size = New Size(165, 16)
        TxtCustomer.TabIndex = 11
        TxtCustomer.TabStop = False
        TxtCustomer.Tag = "Cust"
        TxtCustomer.Visible = False
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataMember = "Customer"
        CustomerBindingSource.DataSource = VesselBindingSource
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataMember = "Vessel"
        VesselBindingSource.DataSource = JobBindingSource
        ' 
        ' TxtVessel
        ' 
        TxtVessel.Anchor = AnchorStyles.Left
        TxtVessel.BorderStyle = BorderStyle.None
        TxtVessel.DataBindings.Add(New Binding("Text", VesselBindingSource, "VesselName", True))
        TxtVessel.Location = New Point(103, 62)
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
        TxtManufacturer.DataBindings.Add(New Binding("Text", ManufacturerBindingSource, "ManufacturerName", True))
        TxtManufacturer.Location = New Point(103, 90)
        TxtManufacturer.Name = "TxtManufacturer"
        TxtManufacturer.ReadOnly = True
        TxtManufacturer.Size = New Size(165, 16)
        TxtManufacturer.TabIndex = 13
        TxtManufacturer.TabStop = False
        TxtManufacturer.Tag = "Mfg"
        TxtManufacturer.Visible = False
        ' 
        ' ManufacturerBindingSource
        ' 
        ManufacturerBindingSource.DataMember = "PropellerManufacturer"
        ManufacturerBindingSource.DataSource = JobBindingSource
        ' 
        ' TxtPartNumber
        ' 
        TxtPartNumber.Anchor = AnchorStyles.Left
        TxtPartNumber.BorderStyle = BorderStyle.None
        TxtPartNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerPartNumber", True))
        TxtPartNumber.Location = New Point(103, 118)
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
        TxtSerialNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "SerialNumber", True))
        TxtSerialNumber.Location = New Point(103, 146)
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
        TxtStampNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "StampNumber", True))
        TxtStampNumber.Location = New Point(103, 174)
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
        TxtInspectedBy.DataBindings.Add(New Binding("Text", EmployeeBindingSource, "EmployeeName", True))
        TxtInspectedBy.Location = New Point(103, 202)
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
        LabClass.Location = New Point(278, 34)
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
        LabRepairStatus.Location = New Point(278, 62)
        LabRepairStatus.Name = "LabRepairStatus"
        LabRepairStatus.Size = New Size(81, 15)
        LabRepairStatus.TabIndex = 20
        LabRepairStatus.Text = "Repair Status"
        LabRepairStatus.Visible = False
        ' 
        ' LabStyle
        ' 
        LabStyle.Anchor = AnchorStyles.Left
        LabStyle.AutoSize = True
        LabStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabStyle.ForeColor = SystemColors.ControlText
        LabStyle.Location = New Point(278, 90)
        LabStyle.Name = "LabStyle"
        LabStyle.Size = New Size(35, 15)
        LabStyle.TabIndex = 21
        LabStyle.Text = "Style"
        LabStyle.Visible = False
        ' 
        ' LabMaterial
        ' 
        LabMaterial.Anchor = AnchorStyles.Left
        LabMaterial.AutoSize = True
        LabMaterial.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMaterial.ForeColor = SystemColors.ControlText
        LabMaterial.Location = New Point(278, 118)
        LabMaterial.Name = "LabMaterial"
        LabMaterial.Size = New Size(53, 15)
        LabMaterial.TabIndex = 22
        LabMaterial.Text = "Material"
        LabMaterial.Visible = False
        ' 
        ' LabBore
        ' 
        LabBore.Anchor = AnchorStyles.Left
        LabBore.AutoSize = True
        LabBore.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabBore.ForeColor = SystemColors.ControlText
        LabBore.Location = New Point(278, 146)
        LabBore.Name = "LabBore"
        LabBore.Size = New Size(34, 15)
        LabBore.TabIndex = 23
        LabBore.Text = "Bore"
        LabBore.Visible = False
        ' 
        ' LabDAR
        ' 
        LabDAR.Anchor = AnchorStyles.Left
        LabDAR.AutoSize = True
        LabDAR.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabDAR.ForeColor = SystemColors.ControlText
        LabDAR.Location = New Point(278, 174)
        LabDAR.Name = "LabDAR"
        LabDAR.Size = New Size(32, 15)
        LabDAR.TabIndex = 24
        LabDAR.Text = "DAR"
        LabDAR.Visible = False
        ' 
        ' LabCup
        ' 
        LabCup.Anchor = AnchorStyles.Left
        LabCup.AutoSize = True
        LabCup.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabCup.ForeColor = SystemColors.ControlText
        LabCup.Location = New Point(278, 202)
        LabCup.Name = "LabCup"
        LabCup.Size = New Size(28, 15)
        LabCup.TabIndex = 25
        LabCup.Text = "Cup"
        LabCup.Visible = False
        ' 
        ' TxtClass
        ' 
        TxtClass.Anchor = AnchorStyles.Left
        TxtClass.BorderStyle = BorderStyle.None
        TxtClass.DataBindings.Add(New Binding("Text", ReportDataBindingSource, "ToleranceClass", True))
        TxtClass.Location = New Point(378, 34)
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
        TxtRepairStatus.Location = New Point(378, 62)
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
        TxtStyle.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerStyle", True))
        TxtStyle.Location = New Point(378, 90)
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
        TxtMaterial.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerMaterial", True))
        TxtMaterial.Location = New Point(378, 118)
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
        TxtBore.DataBindings.Add(New Binding("Text", JobBindingSource, "PropellerBore", True))
        TxtBore.Location = New Point(378, 146)
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
        TxtDAR.DataBindings.Add(New Binding("Text", JobBindingSource, "Dar", True))
        TxtDAR.Location = New Point(378, 174)
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
        TxtCup.DataBindings.Add(New Binding("Text", JobBindingSource, "Cup", True))
        TxtCup.Location = New Point(378, 202)
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
        LabScanDate.Location = New Point(553, 34)
        LabScanDate.Name = "LabScanDate"
        LabScanDate.Size = New Size(63, 15)
        LabScanDate.TabIndex = 35
        LabScanDate.Text = "Scan Date"
        LabScanDate.Visible = False
        ' 
        ' LabPerformedBy
        ' 
        LabPerformedBy.Anchor = AnchorStyles.Left
        LabPerformedBy.AutoSize = True
        LabPerformedBy.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabPerformedBy.ForeColor = SystemColors.ControlText
        LabPerformedBy.Location = New Point(553, 62)
        LabPerformedBy.Name = "LabPerformedBy"
        LabPerformedBy.Size = New Size(85, 15)
        LabPerformedBy.TabIndex = 36
        LabPerformedBy.Text = "Performed By"
        LabPerformedBy.Visible = False
        ' 
        ' LabMarkedPitch
        ' 
        LabMarkedPitch.Anchor = AnchorStyles.Left
        LabMarkedPitch.AutoSize = True
        LabMarkedPitch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabMarkedPitch.ForeColor = SystemColors.ControlText
        LabMarkedPitch.Location = New Point(553, 174)
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
        LabWheelPitch.Location = New Point(553, 202)
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
        LabMeasuredDiameter.Location = New Point(553, 146)
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
        LabMarkedDiameter.Location = New Point(553, 118)
        LabMarkedDiameter.Name = "LabMarkedDiameter"
        LabMarkedDiameter.Size = New Size(71, 15)
        LabMarkedDiameter.TabIndex = 37
        LabMarkedDiameter.Text = "Marked Dia"
        LabMarkedDiameter.Visible = False
        ' 
        ' LabRotation
        ' 
        LabRotation.Anchor = AnchorStyles.Left
        LabRotation.AutoSize = True
        LabRotation.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabRotation.ForeColor = SystemColors.ControlText
        LabRotation.Location = New Point(553, 90)
        LabRotation.Name = "LabRotation"
        LabRotation.Size = New Size(55, 15)
        LabRotation.TabIndex = 39
        LabRotation.Text = "Rotation"
        LabRotation.Visible = False
        ' 
        ' TxtJobId
        ' 
        TxtJobId.Anchor = AnchorStyles.Left
        TxtJobId.BorderStyle = BorderStyle.None
        TxtJobId.DataBindings.Add(New Binding("Text", ReportDataBindingSource, "Id", True))
        TxtJobId.Location = New Point(378, 6)
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
        TxtJobNumber.DataBindings.Add(New Binding("Text", JobBindingSource, "JobNumber", True))
        TxtJobNumber.Location = New Point(103, 6)
        TxtJobNumber.Name = "TxtJobNumber"
        TxtJobNumber.ReadOnly = True
        TxtJobNumber.Size = New Size(165, 16)
        TxtJobNumber.TabIndex = 10
        TxtJobNumber.TabStop = False
        TxtJobNumber.Tag = "JobNo"
        TxtJobNumber.Visible = False
        ' 
        ' PrintDocument
        ' 
        ' 
        ' PrintPreviewDialog
        ' 
        PrintPreviewDialog.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog.ClientSize = New Size(400, 300)
        PrintPreviewDialog.Enabled = True
        PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), Icon)
        PrintPreviewDialog.Name = "PrintPreviewDialog1"
        PrintPreviewDialog.Visible = False
        ' 
        ' ChartBladeHeight
        ' 
        ChartArea1.Name = "ChartArea1"
        ChartBladeHeight.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        ChartBladeHeight.Legends.Add(Legend1)
        ChartBladeHeight.Location = New Point(13, 388)
        ChartBladeHeight.Margin = New Padding(0, 1, 0, 0)
        ChartBladeHeight.Name = "ChartBladeHeight"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        ChartBladeHeight.Series.Add(Series1)
        ChartBladeHeight.Size = New Size(312, 137)
        ChartBladeHeight.TabIndex = 25
        ChartBladeHeight.Text = "Track"
        ChartBladeHeight.Visible = False
        ' 
        ' ChartAngularPosition
        ' 
        ChartArea2.Name = "ChartArea1"
        ChartAngularPosition.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        ChartAngularPosition.Legends.Add(Legend2)
        ChartAngularPosition.Location = New Point(340, 388)
        ChartAngularPosition.Name = "ChartAngularPosition"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        ChartAngularPosition.Series.Add(Series2)
        ChartAngularPosition.Size = New Size(306, 137)
        ChartAngularPosition.TabIndex = 26
        ChartAngularPosition.Text = "Track"
        ChartAngularPosition.Visible = False
        ' 
        ' FrmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(850, 1061)
        Controls.Add(ChartAngularPosition)
        Controls.Add(ChartBladeHeight)
        Controls.Add(Header)
        Controls.Add(Letterhead)
        Controls.Add(FormMenuStrip)
        KeyPreview = True
        Name = "FrmReports"
        Text = "FrmReports"
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        FormMenuStrip.ResumeLayout(False)
        FormMenuStrip.PerformLayout()
        ReportContextMenuStrip.ResumeLayout(False)
        CType(ReportDataBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(Letterhead, ComponentModel.ISupportInitialize).EndInit()
        Header.ResumeLayout(False)
        Header.PerformLayout()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartBladeHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartAngularPosition, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ReportsBindingSource As BindingSource
    Friend WithEvents FormMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents FilePrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LetterheadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HeaderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ReportContextMenuStrip As ContextMenuStrip
    Friend WithEvents UndoContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents CutContextMenuItem As ToolStripMenuItem
    Friend WithEvents PasteContextMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents SelectAllContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents AddNewContextMenuItem As ToolStripMenuItem
    Friend WithEvents ReportDataBindingSource As BindingSource
    Friend WithEvents Letterhead As PictureBox
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
    Friend WithEvents TxtJobId As TextBox
    Friend WithEvents LabJobId As Label
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
    Friend WithEvents ReportsToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ReportsEditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents ManufacturerBindingSource As BindingSource
    Friend WithEvents BringToFrontContextMenuItem As ToolStripMenuItem
    Friend WithEvents SendToBackContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents PrintDocument As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog As PrintPreviewDialog
    Friend WithEvents PageSetupDialog As PageSetupDialog
    Friend WithEvents FileNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents ReportsImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChartBladeHeight As DataVisualization.Charting.Chart
    Friend WithEvents ChartAngularPosition As DataVisualization.Charting.Chart
    Friend WithEvents LetterheadImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsRecentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsOpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents JobsCloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileRecentToolStripMenuItem As ToolStripMenuItem
End Class
