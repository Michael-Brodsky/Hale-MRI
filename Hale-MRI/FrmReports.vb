Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDisplayControls
Imports Microsoft.EntityFrameworkCore

Public Class FrmReports
    Inherits FrmDatabaseForm
#Region "Types and Constants"
    Private Const kPageHorizontalMarginMin As Integer = 20
    Private Const kPageSeparatorHeight As UInteger = 20
#End Region
#Region "Private Members"
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record.
    Private WithEvents mPageSetupDoc As New PrintDocument() ' The print page setup document used to retrieve printer settings.
    Private mReportGenerator As ReportGenerator            ' Manages report visual elements and operations.
    Private mReport As Report                               ' The currently open report, if any.
#End Region
#Region "Public Interface"
    ' <summary>
    ' Returns the currently selected JobDetail,
    ' or Nothing if there is no selected record.
    ' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(ReportDataBindingSource)
        End Get
    End Property

    ' <summary>
    ' Sets or gets the database context for this form.
    ' </summary>
    Public Overrides Property Database As HaleMRIContext

    ' <summary>
    ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
    ' </summary>
    ' <returns></returns>
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            If mJobDetails IsNot Nothing Then
                ' This is the JobDetails and measurements data for the report.
                ReportDataBindingSource.DataSource = JobDataLoad(mJobDetails)
            End If
        End Set
    End Property

    Public Property Report As Report
        Get
            Return mReport
        End Get
        Set(value As Report)
            If Me.Report IsNot Nothing Then
                ReportClose()
            End If
            ReportLoad(value)
            mReport = value
        End Set
    End Property
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ReportsBindingSource.DataSource = New BindingList(Of Report)(Database.Reports.ToList())
    End Sub

    Private Sub DisplayControlToggle(ByRef menuItem As ToolStripMenuItem)

    End Sub

    Private Property Document As DocumentSettings
        Get
            Return mReportGenerator?.Document
        End Get
        Set(value As DocumentSettings)
            mReportGenerator.Document = value
        End Set
    End Property

    Private Sub EditDropDownOpening()
        ' Enables/disables Edit menu items according to the ReportGenerator's 
        ' current Edit state.
        ' Only selected text can be copied. Duplicate report elements are not allowed.
        If TypeOf Me.ActiveControl Is TextBoxBase Then
            If CType(Me.ActiveControl, TextBoxBase).SelectionLength > 0 Then
                CopyToolStripMenuItem.Enabled = True
            Else
                CopyToolStripMenuItem.Enabled = False
            End If
        Else
            CopyToolStripMenuItem.Enabled = False
        End If
        CutToolStripMenuItem.Enabled = mReport IsNot Nothing AndAlso (mReportGenerator.Edit And ReportGenerator.Edits.Cut)
        DeleteToolStripMenuItem.Enabled = mReport IsNot Nothing AndAlso (mReportGenerator.Edit And ReportGenerator.Edits.Delete)
        PasteToolStripMenuItem.Enabled = mReport IsNot Nothing AndAlso (mReportGenerator.Edit And ReportGenerator.Edits.Paste)
        SelectAllToolStripMenuItem.Enabled = mReport IsNot Nothing AndAlso (mReportGenerator.Edit And ReportGenerator.Edits.SelectAll)
    End Sub

    Private Sub FileDropDownOpening()
        ' Enables File menu items according to the current Report.
        CloseToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        FilePrintToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveAsToolStripMenuItem.Enabled = Me.Report IsNot Nothing
    End Sub

    Private Sub HeaderDropDownOpening()
        ' Checks/unchecks Header dropdown items according to 
        ' their current visibility.
        Dim header As ReportHeader = mReportGenerator.ManagedControls.FirstOrDefault(Function(dc) dc.Name = "ReportHeader")
        Dim visibleItems As List(Of Label) =
            header.LabeledItems.Where(Function(hi) hi.Visible).ToList()
        For Each item As ToolStripMenuItem In HeaderToolStripMenuItem.DropDownItems
            item.Checked = visibleItems.Any(Function(hi) hi.Text = item.Text)
        Next
    End Sub

    Private Sub HeaderItemsSet(header As ReportHeader, items As String)
        Dim itemTags As String() = items.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
        For Each menuItem As ToolStripMenuItem In HeaderToolStripMenuItem.DropDownItems
            menuItem.Checked = itemTags.Contains(menuItem.Tag)
        Next
    End Sub

    Private Sub HeaderItemToggle(item As ToolStripMenuItem)
        Dim headerControl As ReportHeader = DirectCast(mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = "ReportHeader"), ReportHeader)
        headerControl.VisibleByTag(item.Tag.ToString(), item.Checked)
    End Sub

    Private Sub HeaderMenuInitialize()
        ' Initialize the Header menu with a list of all available header items.
        Dim headerMenu As ToolStripMenuItem = HeaderToolStripMenuItem
        Dim headerControl As ReportHeader = DirectCast(mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = "ReportHeader"), ReportHeader)
        Dim labeledItems As List(Of Label) = headerControl.LabeledItems
        For Each labeledItem As Label In labeledItems
            Dim menuItem As New ToolStripMenuItem() With {
                .Tag = headerControl.LabelToTag(labeledItem).Tag,
                .Text = labeledItem.Text,
                .CheckOnClick = True
            }
            headerMenu.DropDownItems.Add(menuItem)
            AddHandler menuItem.CheckedChanged, AddressOf HeaderItemToolStripMenuItem_CheckedChanged
        Next
    End Sub

    Private Function JobDataLoad(ByVal jobDetails As JobDetail) As BindingList(Of JobDetail)
        ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements sorted.
        Dim data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd.Id = jobDetails.Id.ToString()) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .AsSplitQuery().ToList()
            )
        ' Sort measurements by Id.
        For Each jd As JobDetail In data
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
        Return data
    End Function

    Private Sub JobsDropDownOpening()
        JobsCloseToolStripMenuItem.Enabled = Me.JobDetails IsNot Nothing
    End Sub

    Private Sub JobSelect(jd As JobDetail)
        Me.JobDetails = jd
        For Each dc As DisplayControl In mReportGenerator.VisibleControls
            dc.Refresh()
        Next
    End Sub

    Private Sub JobSelectorOpen()
        Dim dlg As New FrmJobs With {
            .Database = Database,
            .User = User
        }
        If dlg.ShowDialog() = DialogResult.OK Then
            JobSelect(gFrmJobs.JobDetails)
        End If
    End Sub

    Private Sub LetterheadFileSelect()
        ' Opens a file dialog allowing the user to select the
        ' letterhead image file.
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = STR_DIALOG_FILTER_IMAGE,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            LetterheadLoad(mReportGenerator.ManagedControls.FirstOrDefault(Function(pg) pg.Name = "ReportLetterhead"), openFileDialog1.FileName)
        End If
    End Sub

    Private Sub LetterheadLoad(letterhead As ReportLetterhead, filePath As String)
        ' Loads the letterhead image from a file.
        If letterhead IsNot Nothing Then
            If File.Exists(filePath) Then
                letterhead.Image = Image.FromFile(filePath)
            Else
                letterhead.Image = letterhead.ErrorImage
            End If
        End If
    End Sub

    Protected Overrides Property MasterSource As BindingSource

    Private Sub PagePositionHorizontal(pg As ReportPage)
        If pg.ClientRectangle.Width < Me.ClientRectangle.Width - 2 * kPageHorizontalMarginMin Then
            pg.Left = (Me.ClientRectangle.Width - pg.Width) / 2
        Else
            pg.Left = kPageHorizontalMarginMin
        End If
    End Sub

    Private Sub PagePositionVertical(pg As ReportPage)
        Dim lastPage = mReportGenerator?.Pages.
            OrderByDescending(Function(p) p.Bottom).
            FirstOrDefault()
        Dim top As Integer = Me.FormMenuStrip.Bottom
        If lastPage IsNot Nothing Then top = lastPage.Bottom
        pg.Top = top + kPageSeparatorHeight
    End Sub

    Private Sub PrintPageSetup(sender As Object, e As EventArgs)
        ' Opens the page setup dialog.
        PageSetupDialog.Document = mPageSetupDoc
        If PageSetupDialog.ShowDialog() = DialogResult.OK Then
            mPageSetupDoc.PrinterSettings = PageSetupDialog.PrinterSettings
            mPageSetupDoc.OriginAtMargins = True
            mPageSetupDoc.Print()
        End If
    End Sub

    Private Sub ReportClose()
        mReportGenerator.Clear()
    End Sub

    Private Sub ReportExport()
        ' Exports a Report as a csv file.
        Dim saveFileDialog1 As New SaveFileDialog() With {
            .Filter = STR_DIALOG_FILTER_CSV,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            ReportToFile(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub ReportGeneratorInitialize()
        mReportGenerator = New ReportGenerator() With {
            .Document = New DocumentSettings(New PrintDocument()),
            .GridSize = 10,
            .PageSeparatorHeight = 20,
            .ParentForm = Me,
            .VerticalLimit = Me.FormMenuStrip.Height,
            .Zoom = 1.0F,
            .ManagedControls = New List(Of DisplayControl) From {
                New ChartAngularPosition("ChartAngularPosition", True, True, True),
                New ChartBladeHeight("ChartBladeHeight", True, True, True),
                New ReportHeader("ReportHeader", True),
                New ReportLetterhead("ReportLetterhead", True)
            }
        }
    End Sub

    Private Sub ReportImport()

    End Sub

    Private Sub ReportLoad(ByVal report As Report)
        mReportGenerator.Initialize()
        Dim vc As New List(Of DisplayControl)()
        For Each re As ReportElement In report?.ReportElements
            Dim dc As DisplayControl = mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = re.ElementName)
            If dc IsNot Nothing Then
                Select Case True
                    Case TypeOf dc Is ReportHeader
                        Dim hdr = DirectCast(dc, ReportHeader)
                        hdr.Data = Me.JobDetails
                        HeaderItemsSet(hdr, re.Data)
                    Case TypeOf dc Is ReportLetterhead
                        If re.Data IsNot Nothing Then
                            LetterheadLoad(DirectCast(dc, ReportLetterhead), re.Data)
                        End If
                    Case Else
                End Select
                dc.Location = New Point(re.PositionX, re.PositionY)
                dc.Size = New Size(re.SizeWidth, re.SizeHeight)
                vc.Add(dc)
            End If
        Next
        mReportGenerator.VisibleControls = vc
    End Sub

    Private Sub ReportEditorOpen()

    End Sub

    Private Sub ReportsMenuItemAdd(item As ToolStripMenuItem, Optional ByVal index As Integer = 0)
        ' Adds a report to the ReportsToolStripMenu
        ReportsToolStripMenuItem.DropDownItems.Insert(index, item)
        AddHandler item.Click, AddressOf ReportsToolStripMenuItem_Click
    End Sub

    Private Sub ReportNew()
        Me.Report = New Report()
    End Sub

    Private Sub ReportsMenuInitialize()
        ' Populate the Reports menu with available reports from the database.
        Dim i As Integer = 0
        For Each rpt As Report In ReportsBindingSource
            ReportsMenuItemAdd(New ToolStripMenuItem(rpt.ReportName), i)
            i += 1
        Next
    End Sub

    Private Sub ReportOpen(ByVal name As String)
        Report = Database.Reports.
            Include(Function(r) r.ReportElements).
            FirstOrDefault(Function(r) r.ReportName = name.ToString())
    End Sub

    Private Sub ReportSave()

    End Sub

    Private Sub ReportSaveAs(ByVal name As String)

    End Sub

    Private Sub ReportsDropDownOpening()
        ReportsExportToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        ReportsSettingsToolStripMenuItem.Enabled = Me.Report IsNot Nothing
    End Sub

    Private Sub ReportToFile(fileName As String)
        ' Writes the current Report and layout data to a csv file.
        Const commentReport As String = "'---Report---"
        Const commentElements As String = "'---Elements---"
        Dim content As String =
            $"{commentReport}{Environment.NewLine}" &
            $"<Report>;{Report.ReportName};{Report.GridSize}{Environment.NewLine}"
        content += commentElements & Environment.NewLine
        For Each re As ReportElement In mReport.ReportElements
            content += $"<Element>;{re.ElementName};{re.PositionX};{re.PositionY};{re.SizeWidth};{re.SizeHeight};{re.Zorder};{If(re.Data, "")}{Environment.NewLine}"
        Next
        File.WriteAllText(fileName, content)
    End Sub

#End Region
#Region "Event Handlers"
#Region "Form Events"
    Private Sub FrmReports2_ControlAdded(sender As Object, e As ControlEventArgs) Handles MyBase.ControlAdded
        If TypeOf e.Control Is ReportPage Then
            Dim pg As ReportPage = DirectCast(e.Control, ReportPage)
            PagePositionVertical(pg)
            PagePositionHorizontal(pg)
        End If
    End Sub

    Private Sub FrmReports2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub FrmReports2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MasterSource = ReportsBindingSource
        ReportGeneratorInitialize()
        ReportsMenuInitialize()
        HeaderMenuInitialize()
    End Sub

    Private Sub FrmReports2_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        For Each pg As ReportPage In Me.Controls.OfType(Of ReportPage)()
            PagePositionHorizontal(pg)
        Next
    End Sub

    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        ' Returning the current DisplayRectangle location prevents the 
        ' automatic scroll-back to the top or the start position.
        Return Me.DisplayRectangle.Location
    End Function
#End Region
#Region "Form Menu Events"
    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        EditDropDownOpening()
    End Sub

    Private Sub EditCopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        SendKeys.Send("^C")
    End Sub

    Private Sub EditCutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        SendKeys.Send("^X")
    End Sub

    Private Sub EditDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        SendKeys.Send("{DEL}")
    End Sub

    Private Sub EditPasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        SendKeys.Send("^V")
    End Sub

    Private Sub ElementsLetterheadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetterheadToolStripMenuItem.Click
        Try
            LetterheadFileSelect()
        Catch ex As Exception
            MessageBox.Show(String.Format(STR_ERR_FILE_OPEN, "letterhead", ex.Message), STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FileCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        If Report IsNot Nothing Then ReportClose()
    End Sub

    Private Sub FileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        CloseForm(Me)
    End Sub

    Private Sub FileNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileNewToolStripMenuItem.Click

    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ReportSave()
    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click

    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        FileDropDownOpening()
    End Sub
    Private Sub HeaderItemToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs)
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles HeaderToolStripMenuItem.DropDownOpening
        HeaderDropDownOpening()
    End Sub

    Private Sub HeaderItemToolStripMenuItem_Click(sender As Object, e As EventArgs)
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeaderToolStripMenuItem.Click
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub JobsOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobsOpenToolStripMenuItem.Click
        JobSelectorOpen()
    End Sub

    Private Sub JobsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles JobsToolStripMenuItem.DropDownOpening
        JobsDropDownOpening()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PrintPageSetup(sender, e)
    End Sub

    Private Sub ReportsElementsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DisplayControlToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub ReportsItemClickHandler(sender As Object, e As EventArgs)
        ReportOpen(CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub ReportsToolStripMenuAdd(item As ToolStripMenuItem, Optional ByVal index As Integer = 0)
        ' Adds a report to the ReportsToolStripMenu
        ReportsToolStripMenuItem.DropDownItems.Insert(index, item)
        AddHandler item.Click, AddressOf ReportsItemClickHandler
    End Sub

    Private Sub ReportsToolStripMenuInitialize()
        ' Populate the Reports menu with available reports from the database.
        Dim i As Integer = 0
        For Each rpt As Report In ReportsBindingSource
            ReportsToolStripMenuAdd(New ToolStripMenuItem(rpt.ReportName), i)
            i += 1
        Next
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportOpen(CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub ReportsEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsEditToolStripMenuItem.Click
        ReportEditorOpen()
    End Sub

    Private Sub ReportsExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsExportToolStripMenuItem.Click
        ReportExport()
    End Sub

    Private Sub ReportsImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsImportToolStripMenuItem.Click
        ReportImport()
    End Sub

    Private Sub ReportsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.DropDownOpening
        ReportsDropDownOpening()
    End Sub
#End Region
#Region "Context Menu Events"
    Private Sub AddNewPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewPageToolStripMenuItem.Click

    End Sub

    Private Sub DeletePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePageToolStripMenuItem.Click

    End Sub
#End Region
#Region "Print Events"
    Private Sub PageSetupDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles mPageSetupDoc.PrintPage
        Me.Document = New DocumentSettings(
            e.PageSettings.PaperSize.Width,
            e.PageSettings.PaperSize.Height,
            e.PageSettings.Margins.Left,
            e.PageSettings.Margins.Right,
            e.PageSettings.Margins.Top,
            e.PageSettings.Margins.Bottom,
            e.MarginBounds
        )
    End Sub
#End Region
#End Region
End Class