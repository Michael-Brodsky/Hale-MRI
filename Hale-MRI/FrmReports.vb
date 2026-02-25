Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Http
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDisplayControls
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Newtonsoft.Json.Linq

Public Class FrmReports
    Inherits FrmContent
#Region "Types and Constants"
    Private Const kPageHorizontalMarginMin As Integer = 20
    Private Const kPageSeparatorHeight As UInteger = 20
    Private Const kZoomFactorDefault As Single = 1.0F
    Private Const kZoomFactorMax As Single = 2.0F
    Private Const kZoomFactorMin As Single = 0.5F
#End Region
#Region "Private Members"
    Private mClickedPage As ReportPage = Nothing
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record.
    Private WithEvents mPageSetupDoc As New PrintDocument() ' The print page setup document used to retrieve printer settings.
    Private WithEvents mReportGenerator As ReportGenerator  ' Manages report visual elements and operations.
    Private mReport As Report                               ' The currently open report, if any.
    Private mZoomFactor = kZoomFactorDefault
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
                ControlsLoadData(mReportGenerator?.VisibleControls)
            End If
        End Set
    End Property

    Public Property Report As Report
        Get
            Return mReport
        End Get
        Set(value As Report)
            If ReportClose() <> DialogResult.Cancel Then
                'mReportGenerator.Zoom = 1.0F
                ReportLoad(value)
                FormMenusSet(value)
                ReportNameMenuItemCheck(value, True)
                mReport = value
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ReportsBindingSource.DataSource = New BindingList(Of Report)(Database.Reports.ToList())
    End Sub

    Private Sub ControlContextMenuOpening()
        ' Enable context menu items according the current report and edit state.
        'If mReport Is Nothing Then
        '    For Each item As ToolStripItem In ControlContextMenuStrip.Items
        '        item.Enabled = False
        '    Next
        'Else
        BringToFrontContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
        CutContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Cut)
        DeleteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Delete)
        PasteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Paste)
        SelectAllContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.SelectAll)
        SendToBackContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
        UndoContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Undo)
        'End If
    End Sub

    Private Sub ControlContextMenuStripShow(sender As Object, e As MouseEventArgs)
        ' Shows/hides the context menu and positions it according to
        ' where the mouse was clicked.
        If e.Button = MouseButtons.Right AndAlso mReport IsNot Nothing Then
            ' Show the context menu at the mouse location.
            If sender Is Me Then
                ControlContextMenuStrip.Show(Me, e.Location)
            Else
                ControlContextMenuStrip.Show(CType(sender, Control), e.Location)
            End If
        Else
            ControlContextMenuStrip.Hide()
        End If
    End Sub

    Private Sub ControlsLoadData(controls As List(Of DisplayControl))
        For Each dc As DisplayControl In controls
            dc.Data = Me.JobDetails
        Next
    End Sub

    Private Sub DisplayControlToggle(menuItem As ToolStripMenuItem)
        ' Toggles the visibility of the DisplayControl referenced
        ' by the given menuItem.
        Dim dc As DisplayControl = mReportGenerator.ManagedControls.First(Function(c) c.Name = menuItem.Name)
        ' The letterhead and header menus have dropdowns and need to be enabled accordingly.
        If menuItem Is ReportLetterhead OrElse menuItem Is ReportHeader Then
            menuItem.DropDown.Enabled = menuItem.Checked
        End If
        ' Show/hide the DisplayControl according the whether the menuItem is checked.
        If menuItem.Checked Then
            dc.Scale(New SizeF(mZoomFactor, mZoomFactor))
            If dc.Location = Point.Empty Then
                For Each pg As ReportPage In mReportGenerator.Pages
                    If IsReportPageVisibleInView(pg) Then
                        dc.Location = New Point((pg.ClientRectangle.Width - dc.Width) / 2, pg.VerticalLimit + (pg.ClientRectangle.Bottom - pg.VerticalLimit - dc.Height) / 2)
                    End If
                Next
            End If
            mReportGenerator.ControlShow(dc)
        Else
            mReportGenerator.ControlHide(dc)
        End If
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

    Private Sub ElementsDropdownOpening()
        ' Enables the letterhead and header dropdowns.
        ReportLetterhead.DropDown.Enabled = ReportLetterhead.Checked
        ReportHeader.DropDown.Enabled = ReportHeader.Checked
    End Sub

    Private Sub FileDropDownOpening()
        ' Enables File menu items according to the current Report.
        CloseToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        FilePrintToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveToolStripMenuItem.Enabled = Me.Report IsNot Nothing
        SaveAsToolStripMenuItem.Enabled = Me.Report IsNot Nothing
    End Sub

    Private Function FormClose() As Boolean
        Return ReportClose() <> DialogResult.Cancel
    End Function

    Private Sub FormMenusSet(ByVal report As Report)
        Me.Text = $"Reports {If(report IsNot Nothing, $"- {report.ReportName}", "")}"
        ElementsToolStripMenuItem.Enabled = report IsNot Nothing
        CloseToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        FilePrintToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        SettingsToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        ViewToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        ReportsExportToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
    End Sub

    Private Sub GridSizeSet(ByVal value As String)
        Dim gs As Integer = 0
        Integer.TryParse(value, gs)
        If gs <> mReportGenerator.GridSize Then mReportGenerator.GridSize = gs
    End Sub

    Private Sub HeaderItemToggle(item As ToolStripMenuItem)
        Dim headerControl As ReportHeader = DirectCast(mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = "ReportHeader"), ReportHeader)
        headerControl.ItemVisible(item.Tag.ToString(), item.Checked)
    End Sub

    Private Sub HeaderLoad(report As Report, header As ReportHeader, data As String)
        Dim visibleItems As List(Of String) = data.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList()
        For Each item As ToolStripMenuItem In ReportHeader.DropDownItems
            item.Checked = visibleItems.Contains(item.Tag.ToString())
        Next
    End Sub

    Private Sub HeaderMenuInitialize()
        ' Initialize the Header menu with a list of all available header items.
        Dim headerMenu As ToolStripMenuItem = ReportHeader
        Dim headerControl As ReportHeader = DirectCast(mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = "ReportHeader"), ReportHeader)
        Dim headerItems As List(Of Control) = headerControl.ItemControls
        For Each item As Control In headerItems
            Dim lab As Label = headerControl.ControlToLabel(item)
            Dim menuItem As New ToolStripMenuItem() With {
                .Tag = item.Tag,
                .Text = lab.Text,
                .CheckOnClick = True
            }
            headerMenu.DropDownItems.Add(menuItem)
            AddHandler menuItem.CheckedChanged, AddressOf HeaderItemToolStripMenuItem_CheckedChanged
        Next
    End Sub

    Public Function IsReportPageVisibleInView(ByVal pg As ReportPage) As Boolean

        ' Get the viewable client rectangle of the parent container
        Dim containerRect As Rectangle = pg.Parent.ClientRectangle

        ' Get the child control's bounds relative to the screen
        Dim childRectInScreen As Rectangle = pg.Parent.RectangleToScreen(pg.Bounds)
        ' Convert the container's client rectangle to screen coordinates for comparison
        Dim containerRectInScreen As Rectangle = pg.Parent.RectangleToScreen(containerRect)

        ' Check if the child's screen bounds intersect with the container's viewable screen bounds
        Return containerRectInScreen.IntersectsWith(childRectInScreen)
    End Function

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
        If dlg.ShowDialog() = DialogResult.None Then
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
            LetterheadLoad(mReport, mReportGenerator.ManagedControls.FirstOrDefault(Function(pg) pg.Name = "ReportLetterhead"), openFileDialog1.FileName)
        End If
    End Sub

    Private Sub LetterheadLoad(report As Report, letterhead As ReportLetterhead, filePath As String)
        ' Loads the letterhead image from a file.
        If letterhead IsNot Nothing Then
            If File.Exists(filePath) Then
                letterhead.Image = Image.FromFile(filePath)
                report.ReportElements.First(Function(lh) lh.ElementName = "ReportLetterhead").Data = filePath
            Else
                letterhead.Image = letterhead.ErrorImage
            End If
        End If
    End Sub

    Protected Overrides Property MasterSource As BindingSource

    Private Sub PageRemove(ByRef pg As ReportPage)
        Dim pageIndex As Integer = mReportGenerator.PageDelete(mClickedPage)
        Dim previousPage As ReportPage = If(pageIndex > 0, mReportGenerator.Pages(pageIndex - 1), Nothing)
        For i As Integer = pageIndex To mReportGenerator.Pages.Count - 1
            PagePosition(mReportGenerator.Pages(i), previousPage)
            previousPage = mReportGenerator.Pages(i)
        Next
    End Sub

    Private Sub PageContextMenuStripShow(sender As ReportPage, e As MouseEventArgs)

    End Sub

    Private Sub PagePosition(pg As ReportPage, ByVal previousPage As ReportPage, Optional ByVal zoomFactor As Single = 0)
        If zoomFactor <> 0 Then pg.Scale(New SizeF(zoomFactor, zoomFactor))
        PagePositionVertical(pg, previousPage)
        PagePositionHorizontal(pg)
        Debug.WriteLine($"{pg.Name} {pg.Bounds}")
    End Sub

    Private Sub PagePositionHorizontal(pg As ReportPage)
        If pg.ClientRectangle.Width < Me.ClientRectangle.Width - 2 * kPageHorizontalMarginMin Then
            pg.Left = (Me.ClientRectangle.Width - pg.Width) / 2
        Else
            pg.Left = kPageHorizontalMarginMin
        End If
    End Sub

    Private Sub PagePositionVertical(pg As ReportPage, ByVal previousPage As ReportPage)
        Dim top As Integer = Me.FormMenuStrip.Bottom
        If previousPage IsNot Nothing Then top = previousPage.Bottom
        pg.Top = top + kPageSeparatorHeight * mZoomFactor
    End Sub

    Private Function PrintCapturePageImage(ByVal pg As ReportPage) As Bitmap
        ' Returns a bitmap image of the given ReportPage.
        Dim bmp As New Bitmap(pg.Width, pg.Height)

        pg.Margins.Visible = False
        pg.DrawToBitmap(bmp, New Rectangle(0, 0, pg.Width, pg.Height))
        pg.Margins.Visible = True

        Return bmp
    End Function

    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Prints each report page.
        Dim lastPage As Integer = mReportGenerator.Pages.Count - 1

        For i As Integer = 0 To lastPage
            Dim pageBitmap As Bitmap = PrintCapturePageImage(mReportGenerator.Pages(i))
            e.Graphics.DrawImage(pageBitmap, 0, 0)
            e.HasMorePages = Not (i = lastPage)
        Next
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

    Private Sub PrintPreview(sender As Object, e As EventArgs)
        ' Opens the print preview dialog.
        PrintPreviewDialog.Document = PrintDocument
        If PrintPreviewDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument.Print()
        End If
    End Sub

    Private Function ReportClose() As DialogResult
        ' Closes the current report if one is open.
        Dim result As DialogResult = DialogResult.None

        If mReport IsNot Nothing Then
            ReportUpdate()
            If Database.ChangeTracker.HasChanges() Then
                result = MessageBox.Show(STR_PROMPT_UNSAVED_CHANGES, STR_TITLE_DEFAULT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                Select Case result
                    Case DialogResult.Yes
                        Database.SaveChanges()
                    Case DialogResult.No
                        Database.ChangeTracker.Clear()
                    Case DialogResult.Cancel
                        result = DialogResult.Cancel
                    Case Else
                End Select
            End If
        End If
        If result <> DialogResult.Cancel Then
            'mReportGenerator.Clear()
            For Each item As ToolStripItem In ElementsToolStripMenuItem.DropDownItems
                If TypeOf item Is ToolStripMenuItem Then
                    DirectCast(item, ToolStripMenuItem).Checked = False
                End If
            Next
            FormMenusSet(Nothing)
            ReportNameMenuItemCheck(mReport, False)
            mReport = Nothing
        End If
        Return result
    End Function

    Private Sub ReportElementAddNew(ByRef elements As List(Of ReportElement), dc As DisplayControl, Optional data As String = Nothing)
        ' Adds a new ReportElement to the current Report with the given DisplayControl's properties.
        elements.Add(New ReportElement() With {
            .ElementName = dc.Name,
            .PositionX = dc.Location.X,
            .PositionY = dc.Location.Y,
            .SizeWidth = dc.Size.Width,
            .SizeHeight = dc.Size.Height,
            .Data = data
        })
    End Sub

    Private Sub ReportElementsUpdate(ByRef elements As List(Of ReportElement))
        ' Remove any deleted elements
        If elements IsNot Nothing Then
            Dim toRemove As List(Of ReportElement) = elements.
                Where(Function(re) Not mReportGenerator.VisibleControls.Select(Function(dc) dc.Name).ToList().Contains(re.ElementName)).
                ToList()

            If toRemove.Count > 0 Then
                ' Remove from EF change tracker in a single call
                Database.ReportElements.RemoveRange(toRemove)
                ' Also remove from the in-memory collection to keep UI/model consistent
                For Each re In toRemove
                    elements.Remove(re)
                Next
            End If

            ' Update/add any changed/new elements.
            For Each dc As DisplayControl In mReportGenerator.VisibleControls
                Dim re As ReportElement = elements.FirstOrDefault(Function(el) el.ElementName = dc.Name)
                If re IsNot Nothing Then
                    ReportElementUpdate(re, dc)
                Else
                    ReportElementAddNew(elements, dc)
                End If
            Next
        End If
    End Sub

    Private Sub ReportElementUpdate(ByRef re As ReportElement, ByVal dc As DisplayControl)
        If re.SizeHeight <> dc.Height Then
            re.SizeHeight = dc.Height
        End If
        If re.SizeWidth <> dc.Width Then
            re.SizeWidth = dc.Width
        End If
        If re.PositionX <> dc.Location.X Then
            re.PositionX = dc.Location.X
        End If
        If re.PositionY <> dc.Location.Y Then
            re.PositionY = dc.Location.Y
        End If
        If re.Zorder <> dc.ZOrder Then
            re.Zorder = dc.ZOrder
        End If
    End Sub

    Private Sub ReportHeaderUpdate(ByRef elements As List(Of ReportElement), ByRef re As ReportElement, ByVal rh As ReportHeader)
        Dim headerData As String = String.Join(";"c, rh?.VisibleItems)
        Dim elementData As String = re?.Data
        If re Is Nothing Then
            ReportElementAddNew(elements, rh, headerData)
        ElseIf rh IsNot Nothing Then
            If headerData <> elementData Then re.Data = headerData
        Else
            elements.Remove(re)
        End If
    End Sub

    Private Sub ReportEditorOpen()
        ' Opens the Reports editor form.
        Dim editor As New FrmReportsEditor(Me.ReportsBindingSource, Me.EmployeeBindingSource)
        If editor.ShowDialog() = DialogResult.OK Then
            Dim rpt As Report = editor.Current
            If rpt IsNot Me.Report Then
                If ReportClose() = DialogResult.Cancel Then Return
                ReportOpen(rpt.ReportName)
            End If
        End If
    End Sub

    Private Sub ReportExport()
        ' Exports a Report as a csv file.
        Dim saveFileDialog1 As New SaveFileDialog() With {
            .Filter = STR_DIALOG_FILTER_CSV,
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If saveFileDialog1.ShowDialog() = DialogResult.None Then
            ReportToFile(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub ReportGeneratorInitialize()
        mReportGenerator = New ReportGenerator() With {
            .Document = New DocumentSettings(New PrintDocument()),
            .ParentForm = Me,
            .VerticalLimit = Me.FormMenuStrip.Height,
            .ManagedControls = New ObservableCollection(Of DisplayControl) From {
                New ReportLetterhead("ReportLetterhead", "Letterhead", True),
                New ReportHeader("ReportHeader", "Header", True),
                New ChartAngularPosition("ChartAngularPosition", "Angular Position", True, True, True),
                New ChartBladeHeight("ChartBladeHeight", "Blade Height", True, True, True)
            }
        }
        For Each dc As DisplayControl In mReportGenerator.ManagedControls
            Dim item As ToolStripMenuItem = ElementsToolStripMenuItem.DropDownItems.OfType(Of ToolStripMenuItem)().FirstOrDefault(Function(it) it.Name = dc.Name)
            If item Is Nothing Then
                item = New ToolStripMenuItem() With {
                    .Name = dc.Name,
                    .Text = dc.DisplayName,
                    .CheckOnClick = True
                }
                Me.ElementsToolStripMenuItem.DropDownItems.Add(item)
            End If
            AddHandler item.CheckedChanged, AddressOf Me.ElementsToolStripMenuItem_CheckChanged
            AddHandler dc.MouseDownEvent, AddressOf Me.Control_MouseDown
        Next
    End Sub

    Private Sub ReportImport()

    End Sub

    Private Sub ReportLoad(ByVal report As Report)
        If report IsNot Nothing Then
            mReportGenerator.PageInsert(New ReportPage())
            For Each re As ReportElement In report?.ReportElements
                Dim dc As DisplayControl = mReportGenerator.ManagedControls.FirstOrDefault(Function(c) c.Name = re.ElementName)
                If dc IsNot Nothing Then
                    Select Case True
                        Case TypeOf dc Is ReportHeader
                            Dim header = DirectCast(dc, ReportHeader)
                            header.Data = Me.JobDetails
                            If re.Data IsNot Nothing Then
                                HeaderLoad(report, header, re.Data)
                                'header.VisibleItems = re.Data.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList()
                            End If
                        Case TypeOf dc Is ReportLetterhead
                            Dim letterhead = DirectCast(dc, ReportLetterhead)
                            If re.Data IsNot Nothing Then
                                LetterheadLoad(report, letterhead, re.Data)
                            End If
                        Case Else
                    End Select
                    dc.Location = New Point(re.PositionX, re.PositionY)
                    dc.Size = New Size(re.SizeWidth, re.SizeHeight)
                    dc.Data = Me.JobDetails
                    Dim menuItem As ToolStripMenuItem = ElementsToolStripMenuItem.DropDownItems.OfType(Of ToolStripMenuItem)().FirstOrDefault(Function(it) it.Name = re.ElementName)
                    menuItem.Checked = True
                End If
            Next
        End If
    End Sub

    Private Sub ReportMetadataUpdate(ByRef report As Report)
        report.LastModifed = Now
        report.ModifiedBy = Me.User.Id
    End Sub

    Private Sub ReportsMenuItemAdd(item As ToolStripMenuItem, Optional ByVal index As Integer = 0)
        ' Adds a report to the ReportsToolStripMenu
        ReportsToolStripMenuItem.DropDownItems.Insert(index, item)
        AddHandler item.Click, AddressOf ReportsToolStripMenuItem_Click
    End Sub

    Private Sub ReportNameMenuItemCheck(ByVal report As Report, ByVal checked As Boolean)
        Dim menuItem As ToolStripMenuItem = ReportsToolStripMenuItem.DropDownItems.OfType(Of ToolStripMenuItem)().
            FirstOrDefault(Function(item) item.Text = report?.ReportName)
        If menuItem IsNot Nothing Then menuItem.Checked = checked
    End Sub

    Private Sub ReportNew()
        If ReportClose() = DialogResult.None Then Me.Report = New Report()
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
        ' Save the current report layout to the database.
        ReportUpdate()
        If Database.ChangeTracker.HasChanges() Then Database.SaveChanges()
    End Sub

    Private Sub ReportSaveAs()
        If Not String.IsNullOrEmpty(Name) Then
            Dim reportsMenuItem As ToolStripMenuItem = ToolStripMenuItemGet(ReportsToolStripMenuItem, Me.Report.ReportName)
            FrmInputBox.Text = "Save Report As"
            FrmInputBox.Prompt = "Enter the new name of the report:"
            FrmInputBox.InputText = Me.Report.ReportName
            FrmInputBox.TxtInput.Select()
            FrmInputBox.TxtInput.SelectAll()
            If FrmInputBox.ShowDialog() = DialogResult.OK Then
                Me.Report.ReportName = FrmInputBox.InputText
                ReportSave()
                Me.Text = Me.Report.ReportName
                If reportsMenuItem IsNot Nothing Then reportsMenuItem.Text = Me.Report.ReportName
            End If
        End If
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
            $"<Report>;{Report.ReportName}{Environment.NewLine}"
        content += commentElements & Environment.NewLine
        For Each re As ReportElement In mReport.ReportElements
            content += $"<Element>;{re.ElementName};{re.PositionX};{re.PositionY};{re.SizeWidth};{re.SizeHeight};{re.Zorder};{If(re.Data, "")}{Environment.NewLine}"
        Next
        File.WriteAllText(fileName, content)
    End Sub

    Private Sub ReportUpdate()
        ' Update ReportElements in the database. Remove any hidden elements from the Report,
        ' add any visible elements not in the Report, and check element properties for
        ' changes.

        ' If this is a new unsaved report, save it now so we get a valid ReportId.
        If mReport.Id Is Nothing Then
            Database.SaveChanges()
        End If

        ' Update the Report.ReportElements to contain only the currently visible ReportControls.
        ReportElementsUpdate(mReport?.ReportElements)

        ' Update header items.
        Dim headerElement As ReportElement = mReport.ReportElements.FirstOrDefault(Function(re) re.Report Is mReport And re.ElementName = "ReportHeader")
        Dim headerControl As DisplayControl = mReportGenerator.VisibleControls.FirstOrDefault(Function(dc) dc.Name = "ReportHeader")
        If headerElement IsNot Nothing AndAlso headerControl IsNot Nothing Then
            ReportHeaderUpdate(mReport.ReportElements, headerElement, headerControl)
        End If

        ' Update report metadata if anything changed.
        If Database.ChangeTracker.HasChanges() Then
            ReportMetadataUpdate(mReport)
        End If
    End Sub

    Private Function ToolStripMenuItemGet(menu As ToolStripMenuItem, txt As String) As ToolStripMenuItem
        Dim menuItem As ToolStripMenuItem = Nothing
        For Each item As ToolStripItem In menu.DropDownItems
            If TypeOf item Is ToolStripMenuItem Then
                If item.Text = txt Then
                    menuItem = CType(item, ToolStripMenuItem)
                    Exit For
                End If
            End If
        Next
        Return menuItem
    End Function
    Private Sub ViewMenuInitialize()
        PageMarginsToolStripMenuItem.CheckOnClick = True
    End Sub

    Private Sub ZoomAdjust(ByVal factor As Single)
        Dim newZoomFactor As Single = Math.Round(mZoomFactor + factor, 2)
        newZoomFactor = Math.Min(Math.Max(newZoomFactor, kZoomFactorMin), kZoomFactorMax)
        Dim zoomAdjust As Single = newZoomFactor / mZoomFactor
        mZoomFactor = newZoomFactor
        Me.SuspendLayout()
        Dim previousPage As ReportPage = Nothing
        For Each pg As ReportPage In mReportGenerator.Pages
            PagePosition(pg, previousPage, zoomAdjust)
            previousPage = pg
        Next
        Me.ResumeLayout()
    End Sub
#End Region
#Region "Event Handlers"
#Region "Form Events"
    Private Sub Content_ControlAdded(sender As Object, e As ControlEventArgs) Handles ToolStripContainer2.ContentPanel.ControlAdded
        If TypeOf e.Control Is ReportPage Then
            Dim pg As ReportPage = DirectCast(e.Control, ReportPage)
            Dim previousPage As ReportPage = mReportGenerator?.Pages.
                Where(Function(p) p IsNot pg).
                OrderByDescending(Function(p) p.Bottom).
                FirstOrDefault()
            Me.SuspendLayout()
            PagePosition(pg, previousPage, mZoomFactor)
            Me.ResumeLayout()
            RemoveHandler pg.MouseDownEvent, AddressOf Me.Page_MouseDown
            AddHandler pg.MouseDownEvent, AddressOf Me.Page_MouseDown
        End If
    End Sub

    Private Sub Content_ControlRemoved(sender As Object, e As ControlEventArgs) Handles ToolStripContainer2.ContentPanel.ControlRemoved

    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then ControlContextMenuStrip.Show(CType(sender, Control), e.Location)
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Not FormClose()
        MyBase.Form_Closing(sender, e)
    End Sub

    Private Sub FrmReports2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mContent = Me.ToolStripContainer2.ContentPanel
        Me.ToolStripContainer2.ContentPanel.AutoScroll = True
        MasterSource = ReportsBindingSource
        ReportGeneratorInitialize()
        ReportsMenuInitialize()
        HeaderMenuInitialize()
        ViewMenuInitialize()
        FormMenusSet(mReport)
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

    Private Sub FrmReports_ZoomChanged(zoomFactor As Single) Handles mReportGenerator.ZoomEvent
        For Each pg As ReportPage In Me.Controls.OfType(Of ReportPage)()
            PagePositionHorizontal(pg)
        Next
    End Sub

    Private Sub Page_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            If TypeOf sender Is ReportPage Then
                mClickedPage = DirectCast(sender, ReportPage)
            Else
                mClickedPage = DirectCast(DirectCast(sender, Control).Parent, ReportPage)
            End If
            PageContextMenuStrip.Show(DirectCast(sender, Control), e.Location)
        End If
    End Sub
#End Region
#Region "Form Menu Events"
    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
        EditDropDownOpening()
    End Sub

    Private Sub EditCopyToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SendKeys.Send("^C")
    End Sub

    Private Sub EditCutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SendKeys.Send("^X")
    End Sub

    Private Sub EditDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SendKeys.Send("{DEL}")
    End Sub

    Private Sub EditPasteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SendKeys.Send("^V")
    End Sub

    Private Sub ElementsToolStripMenuItem_CheckChanged(sender As Object, e As EventArgs)
        DisplayControlToggle(DirectCast(sender, ToolStripMenuItem))
    End Sub

    Private Sub ElementsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ElementsToolStripMenuItem.DropDownOpening
        ElementsDropdownOpening()
    End Sub

    Private Sub FileCloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim unused = ReportClose()
    End Sub

    Private Sub FileExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FileNewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportNew()
    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportEditorOpen()
    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportSave()
    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportSaveAs()
    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
        FileDropDownOpening()
    End Sub

    Private Sub GridSizeToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs)
        GridSizeSet(GridSizeToolStripTextBox.Text)
    End Sub

    Private Sub HeaderItemToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs)
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub HeaderItemToolStripMenuItem_Click(sender As Object, e As EventArgs)
        HeaderItemToggle(CType(sender, ToolStripMenuItem))
    End Sub

    Private Sub ImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LetterheadFileSelect()
    End Sub

    Private Sub JobsOpenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        JobSelectorOpen()
    End Sub

    Private Sub JobsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
        JobsDropDownOpening()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PrintPageSetup(sender, e)
    End Sub

    Private Sub ReportsToolStripMenuAdd(item As ToolStripMenuItem, Optional ByVal index As Integer = 0)
        ' Adds a report to the ReportsToolStripMenu
        ReportsToolStripMenuItem.DropDownItems.Insert(index, item)
        AddHandler item.Click, AddressOf ReportsToolStripMenuItem_Click
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

    Private Sub ReportsEditToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportEditorOpen()
    End Sub

    Private Sub ReportsExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportExport()
    End Sub

    Private Sub ReportsImportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ReportImport()
    End Sub

    Private Sub ReportsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
        ReportsDropDownOpening()
    End Sub

    Private Sub ZoomActualSizeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ZoomAdjust(1.0F - mZoomFactor)
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ZoomAdjust(0.1F)
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ZoomAdjust(-0.1F)
    End Sub
#End Region
#Region "Control Context Menu Events"
    Private Sub BringToFrontContextMenuItem_Click(sender As Object, e As EventArgs) Handles BringToFrontContextMenuItem.Click

    End Sub

    Private Sub ControlContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles ControlContextMenuStrip.Opening
        ControlContextMenuOpening()
    End Sub

    Private Sub CutContextMenuItem_Click(sender As Object, e As EventArgs) Handles CutContextMenuItem.Click

    End Sub

    Private Sub DeleteContextMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteContextMenuItem.Click

    End Sub

    Private Sub PasteContextMenuItem_Click(sender As Object, e As EventArgs) Handles PasteContextMenuItem.Click

    End Sub

    Private Sub SendToBackContextMenuItem_Click(sender As Object, e As EventArgs) Handles SendToBackContextMenuItem.Click

    End Sub

    Private Sub SelectAllContextMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllContextMenuItem.Click

    End Sub

    Private Sub UndoContextMenuItem_Click(sender As Object, e As EventArgs) Handles UndoContextMenuItem.Click

    End Sub
#End Region
#Region "Page Context Menu Events"
    Private Sub InsertNewPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertNewPageToolStripMenuItem.Click
        mReportGenerator.PageInsert(New ReportPage(), mClickedPage)
    End Sub

    Private Shared ReadOnly separator As Char() = New Char() {";"c}

    Private Sub DeletePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePageToolStripMenuItem.Click
        PageRemove(mClickedPage)
    End Sub

    Private Sub PageContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles PageContextMenuStrip.Opening

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

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument.PrintPage
        PrintPage(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument.Print()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreview(sender, e)
    End Sub

    Private Sub PageMarginsToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs)
        mReportGenerator.MarginsVisible = PageMarginsToolStripMenuItem.Checked
    End Sub
#End Region
#End Region
End Class