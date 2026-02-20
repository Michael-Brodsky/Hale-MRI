Imports LibDisplayControls
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
        ReportsBindingSource = New BindingSource(components)
        ReportDataBindingSource = New BindingSource(components)
        EmployeeBindingSource = New BindingSource(components)
        JobBindingSource = New BindingSource(components)
        VesselBindingSource = New BindingSource(components)
        CustomerBindingSource = New BindingSource(components)
        ManufacturerBindingSource = New BindingSource(components)
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
        ToolStripSeparator12 = New ToolStripSeparator()
        ReportsSettingsToolStripMenuItem = New ToolStripMenuItem()
        SettingsClassToolStripMenuItem = New ToolStripMenuItem()
        Class1ToolStripMenuItem = New ToolStripMenuItem()
        Class2ToolStripMenuItem = New ToolStripMenuItem()
        Class3ToolStripMenuItem = New ToolStripMenuItem()
        ClassSToolStripMenuItem = New ToolStripMenuItem()
        ElementsToolStripMenuItem = New ToolStripMenuItem()
        LetterheadToolStripMenuItem = New ToolStripMenuItem()
        LetterheadImageToolStripMenuItem = New ToolStripMenuItem()
        HeaderToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator8 = New ToolStripSeparator()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        ClassToolStripMenuItem = New ToolStripMenuItem()
        ClassSpecialToolStripMenuItem = New ToolStripMenuItem()
        ClassIToolStripMenuItem = New ToolStripMenuItem()
        ClasasIIToolStripMenuItem = New ToolStripMenuItem()
        ClassIIIToolStripMenuItem = New ToolStripMenuItem()
        BasisToolStripMenuItem = New ToolStripMenuItem()
        MeanToolStripMenuItem = New ToolStripMenuItem()
        MarkedToolStripMenuItem = New ToolStripMenuItem()
        DesiredToolStripMenuItem = New ToolStripMenuItem()
        PrecisionToolStripMenuItem = New ToolStripMenuItem()
        And00ToolStripMenuItem = New ToolStripMenuItem()
        And000ToolStripMenuItem = New ToolStripMenuItem()
        ViewToolStripMenuItem = New ToolStripMenuItem()
        ZoomInToolStripMenuItem = New ToolStripMenuItem()
        ZoomOutToolStripMenuItem = New ToolStripMenuItem()
        ActualSizeToolStripMenuItem = New ToolStripMenuItem()
        ControlContextMenuStrip = New ContextMenuStrip(components)
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
        PrintDocument = New Printing.PrintDocument()
        PrintPreviewDialog = New PrintPreviewDialog()
        PageSetupDialog = New PageSetupDialog()
        PageContextMenuStrip = New ContextMenuStrip(components)
        AddNewPageToolStripMenuItem = New ToolStripMenuItem()
        DeletePageToolStripMenuItem = New ToolStripMenuItem()
        BasisMeanToolStripMenuItem = New ToolStripMenuItem()
        BasisMarkedToolStripMenuItem = New ToolStripMenuItem()
        BasisDesiredToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripMenuItem()
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ReportDataBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        FormMenuStrip.SuspendLayout()
        ControlContextMenuStrip.SuspendLayout()
        PageContextMenuStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' ReportsBindingSource
        ' 
        ReportsBindingSource.DataSource = GetType(LibDatabase.Models.Report)
        ReportsBindingSource.Sort = "ReportName"
        ' 
        ' ReportDataBindingSource
        ' 
        ReportDataBindingSource.AllowNew = False
        ReportDataBindingSource.DataSource = GetType(LibDatabase.Models.JobDetail)
        ' 
        ' EmployeeBindingSource
        ' 
        EmployeeBindingSource.AllowNew = False
        EmployeeBindingSource.DataMember = "PerformedByNavigation"
        EmployeeBindingSource.DataSource = ReportDataBindingSource
        EmployeeBindingSource.Sort = ""
        ' 
        ' JobBindingSource
        ' 
        JobBindingSource.DataMember = "Job"
        JobBindingSource.DataSource = ReportDataBindingSource
        ' 
        ' VesselBindingSource
        ' 
        VesselBindingSource.DataMember = "Vessel"
        VesselBindingSource.DataSource = JobBindingSource
        ' 
        ' CustomerBindingSource
        ' 
        CustomerBindingSource.DataMember = "Customer"
        CustomerBindingSource.DataSource = VesselBindingSource
        ' 
        ' ManufacturerBindingSource
        ' 
        ManufacturerBindingSource.DataMember = "PropellerManufacturer"
        ManufacturerBindingSource.DataSource = JobBindingSource
        ' 
        ' FormMenuStrip
        ' 
        FormMenuStrip.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, JobsToolStripMenuItem, ReportsToolStripMenuItem, ElementsToolStripMenuItem, SettingsToolStripMenuItem, ViewToolStripMenuItem})
        FormMenuStrip.Location = New Point(0, 0)
        FormMenuStrip.Name = "FormMenuStrip"
        FormMenuStrip.Size = New Size(1180, 24)
        FormMenuStrip.TabIndex = 3
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
        CloseToolStripMenuItem.Enabled = False
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
        SaveToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), Image)
        SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        SaveToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        SaveToolStripMenuItem.Size = New Size(186, 22)
        SaveToolStripMenuItem.Text = "Save"
        ' 
        ' SaveAsToolStripMenuItem
        ' 
        SaveAsToolStripMenuItem.Enabled = False
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
        FilePrintToolStripMenuItem.Enabled = False
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
        JobsCloseToolStripMenuItem.Enabled = False
        JobsCloseToolStripMenuItem.Name = "JobsCloseToolStripMenuItem"
        JobsCloseToolStripMenuItem.Size = New Size(110, 22)
        JobsCloseToolStripMenuItem.Text = "Close"
        ' 
        ' ReportsToolStripMenuItem
        ' 
        ReportsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ReportsToolStripSeparator1, ReportsEditToolStripMenuItem, ReportsImportToolStripMenuItem, ReportsExportToolStripMenuItem, ToolStripSeparator12, ReportsSettingsToolStripMenuItem})
        ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        ReportsToolStripMenuItem.Size = New Size(59, 20)
        ReportsToolStripMenuItem.Text = "Reports"
        ' 
        ' ReportsToolStripSeparator1
        ' 
        ReportsToolStripSeparator1.Name = "ReportsToolStripSeparator1"
        ReportsToolStripSeparator1.Size = New Size(113, 6)
        ' 
        ' ReportsEditToolStripMenuItem
        ' 
        ReportsEditToolStripMenuItem.Name = "ReportsEditToolStripMenuItem"
        ReportsEditToolStripMenuItem.Size = New Size(116, 22)
        ReportsEditToolStripMenuItem.Text = "Edit"
        ' 
        ' ReportsImportToolStripMenuItem
        ' 
        ReportsImportToolStripMenuItem.Name = "ReportsImportToolStripMenuItem"
        ReportsImportToolStripMenuItem.Size = New Size(116, 22)
        ReportsImportToolStripMenuItem.Text = "Import"
        ' 
        ' ReportsExportToolStripMenuItem
        ' 
        ReportsExportToolStripMenuItem.Enabled = False
        ReportsExportToolStripMenuItem.Name = "ReportsExportToolStripMenuItem"
        ReportsExportToolStripMenuItem.Size = New Size(116, 22)
        ReportsExportToolStripMenuItem.Text = "Export"
        ' 
        ' ToolStripSeparator12
        ' 
        ToolStripSeparator12.Name = "ToolStripSeparator12"
        ToolStripSeparator12.Size = New Size(113, 6)
        ' 
        ' ReportsSettingsToolStripMenuItem
        ' 
        ReportsSettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SettingsClassToolStripMenuItem})
        ReportsSettingsToolStripMenuItem.Enabled = False
        ReportsSettingsToolStripMenuItem.Name = "ReportsSettingsToolStripMenuItem"
        ReportsSettingsToolStripMenuItem.Size = New Size(116, 22)
        ReportsSettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' SettingsClassToolStripMenuItem
        ' 
        SettingsClassToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Class1ToolStripMenuItem, Class2ToolStripMenuItem, Class3ToolStripMenuItem, ClassSToolStripMenuItem})
        SettingsClassToolStripMenuItem.Name = "SettingsClassToolStripMenuItem"
        SettingsClassToolStripMenuItem.Size = New Size(101, 22)
        SettingsClassToolStripMenuItem.Text = "Class"
        ' 
        ' Class1ToolStripMenuItem
        ' 
        Class1ToolStripMenuItem.Name = "Class1ToolStripMenuItem"
        Class1ToolStripMenuItem.Size = New Size(83, 22)
        Class1ToolStripMenuItem.Text = "I"
        ' 
        ' Class2ToolStripMenuItem
        ' 
        Class2ToolStripMenuItem.Name = "Class2ToolStripMenuItem"
        Class2ToolStripMenuItem.Size = New Size(83, 22)
        Class2ToolStripMenuItem.Text = "II"
        ' 
        ' Class3ToolStripMenuItem
        ' 
        Class3ToolStripMenuItem.Name = "Class3ToolStripMenuItem"
        Class3ToolStripMenuItem.Size = New Size(83, 22)
        Class3ToolStripMenuItem.Text = "III"
        ' 
        ' ClassSToolStripMenuItem
        ' 
        ClassSToolStripMenuItem.Name = "ClassSToolStripMenuItem"
        ClassSToolStripMenuItem.Size = New Size(83, 22)
        ClassSToolStripMenuItem.Text = "S"
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
        SettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ClassToolStripMenuItem, BasisToolStripMenuItem, PrecisionToolStripMenuItem})
        SettingsToolStripMenuItem.Enabled = False
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(61, 20)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' ClassToolStripMenuItem
        ' 
        ClassToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ClassSpecialToolStripMenuItem, ClassIToolStripMenuItem, ClasasIIToolStripMenuItem, ClassIIIToolStripMenuItem})
        ClassToolStripMenuItem.Name = "ClassToolStripMenuItem"
        ClassToolStripMenuItem.Size = New Size(122, 22)
        ClassToolStripMenuItem.Text = "Class"
        ' 
        ' ClassSpecialToolStripMenuItem
        ' 
        ClassSpecialToolStripMenuItem.CheckOnClick = True
        ClassSpecialToolStripMenuItem.Name = "ClassSpecialToolStripMenuItem"
        ClassSpecialToolStripMenuItem.Size = New Size(83, 22)
        ClassSpecialToolStripMenuItem.Text = "S"
        ' 
        ' ClassIToolStripMenuItem
        ' 
        ClassIToolStripMenuItem.CheckOnClick = True
        ClassIToolStripMenuItem.Name = "ClassIToolStripMenuItem"
        ClassIToolStripMenuItem.Size = New Size(83, 22)
        ClassIToolStripMenuItem.Text = "I"
        ' 
        ' ClasasIIToolStripMenuItem
        ' 
        ClasasIIToolStripMenuItem.CheckOnClick = True
        ClasasIIToolStripMenuItem.Name = "ClasasIIToolStripMenuItem"
        ClasasIIToolStripMenuItem.Size = New Size(83, 22)
        ClasasIIToolStripMenuItem.Text = "II"
        ' 
        ' ClassIIIToolStripMenuItem
        ' 
        ClassIIIToolStripMenuItem.CheckOnClick = True
        ClassIIIToolStripMenuItem.Name = "ClassIIIToolStripMenuItem"
        ClassIIIToolStripMenuItem.Size = New Size(83, 22)
        ClassIIIToolStripMenuItem.Text = "III"
        ' 
        ' BasisToolStripMenuItem
        ' 
        BasisToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {MeanToolStripMenuItem, MarkedToolStripMenuItem, DesiredToolStripMenuItem})
        BasisToolStripMenuItem.Name = "BasisToolStripMenuItem"
        BasisToolStripMenuItem.Size = New Size(122, 22)
        BasisToolStripMenuItem.Text = "Basis"
        ' 
        ' MeanToolStripMenuItem
        ' 
        MeanToolStripMenuItem.Name = "MeanToolStripMenuItem"
        MeanToolStripMenuItem.Size = New Size(114, 22)
        MeanToolStripMenuItem.Text = "Mean"
        ' 
        ' MarkedToolStripMenuItem
        ' 
        MarkedToolStripMenuItem.Name = "MarkedToolStripMenuItem"
        MarkedToolStripMenuItem.Size = New Size(114, 22)
        MarkedToolStripMenuItem.Text = "Marked"
        ' 
        ' DesiredToolStripMenuItem
        ' 
        DesiredToolStripMenuItem.Name = "DesiredToolStripMenuItem"
        DesiredToolStripMenuItem.Size = New Size(114, 22)
        DesiredToolStripMenuItem.Text = "Desired"
        ' 
        ' PrecisionToolStripMenuItem
        ' 
        PrecisionToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {And00ToolStripMenuItem, And000ToolStripMenuItem})
        PrecisionToolStripMenuItem.Name = "PrecisionToolStripMenuItem"
        PrecisionToolStripMenuItem.Size = New Size(122, 22)
        PrecisionToolStripMenuItem.Text = "Precision"
        ' 
        ' And00ToolStripMenuItem
        ' 
        And00ToolStripMenuItem.Name = "And00ToolStripMenuItem"
        And00ToolStripMenuItem.Size = New Size(136, 22)
        And00ToolStripMenuItem.Text = ".0 and .00"
        ' 
        ' And000ToolStripMenuItem
        ' 
        And000ToolStripMenuItem.Name = "And000ToolStripMenuItem"
        And000ToolStripMenuItem.Size = New Size(136, 22)
        And000ToolStripMenuItem.Text = ".00 and .000"
        ' 
        ' ViewToolStripMenuItem
        ' 
        ViewToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ZoomInToolStripMenuItem, ZoomOutToolStripMenuItem, ActualSizeToolStripMenuItem})
        ViewToolStripMenuItem.Enabled = False
        ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        ViewToolStripMenuItem.Size = New Size(44, 20)
        ViewToolStripMenuItem.Text = "View"
        ' 
        ' ZoomInToolStripMenuItem
        ' 
        ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem"
        ZoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl++"
        ZoomInToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Oemplus
        ZoomInToolStripMenuItem.Size = New Size(171, 22)
        ZoomInToolStripMenuItem.Text = "Zoom In"
        ' 
        ' ZoomOutToolStripMenuItem
        ' 
        ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        ZoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-"
        ZoomOutToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.OemMinus
        ZoomOutToolStripMenuItem.Size = New Size(171, 22)
        ZoomOutToolStripMenuItem.Text = "Zoom Out"
        ' 
        ' ActualSizeToolStripMenuItem
        ' 
        ActualSizeToolStripMenuItem.Name = "ActualSizeToolStripMenuItem"
        ActualSizeToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.D0
        ActualSizeToolStripMenuItem.Size = New Size(171, 22)
        ActualSizeToolStripMenuItem.Text = "Actual Size"
        ' 
        ' ControlContextMenuStrip
        ' 
        ControlContextMenuStrip.Items.AddRange(New ToolStripItem() {UndoContextMenuItem, ToolStripSeparator6, CutContextMenuItem, PasteContextMenuItem, DeleteContextMenuItem, ToolStripSeparator5, BringToFrontContextMenuItem, SendToBackContextMenuItem, ToolStripSeparator10, SelectAllContextMenuItem, ToolStripSeparator7, AddNewContextMenuItem})
        ControlContextMenuStrip.Name = "ContextMenuStrip1"
        ControlContextMenuStrip.Size = New Size(165, 204)
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
        ' PageContextMenuStrip
        ' 
        PageContextMenuStrip.Items.AddRange(New ToolStripItem() {AddNewPageToolStripMenuItem, DeletePageToolStripMenuItem})
        PageContextMenuStrip.Name = "PageContextMenuStrip"
        PageContextMenuStrip.Size = New Size(153, 48)
        ' 
        ' AddNewPageToolStripMenuItem
        ' 
        AddNewPageToolStripMenuItem.Name = "AddNewPageToolStripMenuItem"
        AddNewPageToolStripMenuItem.Size = New Size(152, 22)
        AddNewPageToolStripMenuItem.Text = "Add New Page"
        ' 
        ' DeletePageToolStripMenuItem
        ' 
        DeletePageToolStripMenuItem.Name = "DeletePageToolStripMenuItem"
        DeletePageToolStripMenuItem.Size = New Size(152, 22)
        DeletePageToolStripMenuItem.Text = "Delete Page"
        ' 
        ' BasisMeanToolStripMenuItem
        ' 
        BasisMeanToolStripMenuItem.Name = "BasisMeanToolStripMenuItem"
        BasisMeanToolStripMenuItem.Size = New Size(180, 22)
        BasisMeanToolStripMenuItem.Text = "Mean"
        ' 
        ' BasisMarkedToolStripMenuItem
        ' 
        BasisMarkedToolStripMenuItem.Name = "BasisMarkedToolStripMenuItem"
        BasisMarkedToolStripMenuItem.Size = New Size(180, 22)
        BasisMarkedToolStripMenuItem.Text = "Marked"
        ' 
        ' BasisDesiredToolStripMenuItem
        ' 
        BasisDesiredToolStripMenuItem.Name = "BasisDesiredToolStripMenuItem"
        BasisDesiredToolStripMenuItem.Size = New Size(180, 22)
        BasisDesiredToolStripMenuItem.Text = "Desired"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(180, 22)
        ToolStripMenuItem2.Text = "S"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(180, 22)
        ToolStripMenuItem3.Text = "I"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(180, 22)
        ToolStripMenuItem4.Text = "II"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(180, 22)
        ToolStripMenuItem5.Text = "III"
        ' 
        ' FrmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1180, 580)
        Controls.Add(FormMenuStrip)
        KeyPreview = True
        Name = "FrmReports"
        Text = "FrmReports2"
        CType(ReportsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ReportDataBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(EmployeeBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(JobBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(VesselBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CustomerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ManufacturerBindingSource, ComponentModel.ISupportInitialize).EndInit()
        FormMenuStrip.ResumeLayout(False)
        FormMenuStrip.PerformLayout()
        ControlContextMenuStrip.ResumeLayout(False)
        PageContextMenuStrip.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ReportsBindingSource As BindingSource
    Friend WithEvents ReportDataBindingSource As BindingSource
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents JobBindingSource As BindingSource
    Friend WithEvents VesselBindingSource As BindingSource
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents ManufacturerBindingSource As BindingSource
    Friend WithEvents FormMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileRecentToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsOpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsRecentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents JobsCloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ReportsEditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ReportsSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsClassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Class1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Class2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Class3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LetterheadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LetterheadImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HeaderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ControlContextMenuStrip As ContextMenuStrip
    Friend WithEvents UndoContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents CutContextMenuItem As ToolStripMenuItem
    Friend WithEvents PasteContextMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BringToFrontContextMenuItem As ToolStripMenuItem
    Friend WithEvents SendToBackContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents SelectAllContextMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents AddNewContextMenuItem As ToolStripMenuItem
    Friend WithEvents PrintDocument As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog As PrintPreviewDialog
    Friend WithEvents PageSetupDialog As PageSetupDialog
    Friend WithEvents PageContextMenuStrip As ContextMenuStrip
    Friend WithEvents AddNewPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeletePageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BasisMeanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BasisMarkedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BasisDesiredToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassSpecialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClasasIIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassIIIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BasisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MeanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarkedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesiredToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrecisionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents And00ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents And000ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomInToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualSizeToolStripMenuItem As ToolStripMenuItem
End Class
