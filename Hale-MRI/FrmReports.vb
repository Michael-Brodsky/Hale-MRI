Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Printing
Imports System.IO
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDisplayControls
Imports Microsoft.EntityFrameworkCore
Imports Newtonsoft.Json.Linq

Public Class FrmReports
    Inherits FrmDatabaseForm
#Region "Types and Constants"
    Private Const kPageHorizontalMarginMin As Integer = 20
    Private Const kPageSeparatorHeight As UInteger = 20
#End Region
#Region "Private Members"
    Private mJobDetails As JobDetail = Nothing              ' The current JobDetail record.
    Private WithEvents mPageSetupDoc As New PrintDocument() ' The print page setup document used to retrieve printer settings.
    Private WithEvents mReportGenerator As ReportGenerator  ' Manages report visual elements and operations.
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
                ControlsLoadData(mReportGenerator?.VisibleControls)
            End If
        End Set
    End Property

    Public Property Report As Report
        Get
            Return mReport
        End Get
        Set(value As Report)
            If ReportClose() = DialogResult.None Then
                mReportGenerator.Zoom = 1.0F
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
        If mReport Is Nothing Then
            For Each item As ToolStripItem In ControlContextMenuStrip.Items
                item.Enabled = False
            Next
        Else
            AddNewContextMenuItem.Enabled = True
            BringToFrontContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
            CutContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Cut)
            DeleteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Delete)
            PasteContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Paste)
            SelectAllContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.SelectAll)
            SendToBackContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.ZOrder)
            UndoContextMenuItem.Enabled = (mReportGenerator.Edit And ReportGenerator.Edits.Undo)
        End If
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

    Private Sub ControlsLoadData(controls As ObservableCollection(Of DisplayControl))
        For Each dc As DisplayControl In controls
            dc.Data = Me.JobDetails
        Next
    End Sub

    Private Sub DisplayControlToggle(ByRef menuItem As ToolStripMenuItem)
        ' Toggles the visibility of the DisplayControl referenced
        ' by the given menuItem and sets the menuItem.Checked 
        ' state accordingly.
        Dim item As ToolStripMenuItem = menuItem
        Dim dc As DisplayControl = mReportGenerator.ManagedControls.First(Function(c) c.Name = item.Text)
        menuItem.Checked = Not menuItem.Checked
        If menuItem.Checked Then
            If Not mReportGenerator.VisibleControls.ToList().Contains(dc) Then
                mReportGenerator.VisibleControls.Add(dc)
            End If
        Else
            mReportGenerator.VisibleControls.Remove(dc)
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
        ' Checks/unchecks and enables/disables Elements menu items according
        ' to the current visibility or report elements.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ''' The DisplayControl.Name (and consequently the ReportElement.ElementName)
        ''' may not be human-readable, i.e "ChartAngulartPosition" might be a bit wonky,
        ''' so maybe use DisplayControl.Tag property as a "display name", then give our
        ''' ElementsToolStripMenuItems a Name equal to DisplayControl.Name but set the 
        ''' Text property to DisplayControl.Tag. This way we can display any text in 
        ''' drop down list items. Also the Letterhead and Header dropdown items are
        ''' separated from the other controls and the starting index for the other
        ''' controls may not always be 3.
        LetterheadToolStripMenuItem.Checked = mReportGenerator.VisibleControls.Select(Function(dc) dc.Name).ToList.Contains("ReportLetterhead")
        LetterheadToolStripMenuItem.DropDown.Enabled = LetterheadToolStripMenuItem.Checked
        HeaderToolStripMenuItem.Checked = mReportGenerator.VisibleControls.Select(Function(dc) dc.Name).ToList.Contains("ReportHeader")
        HeaderToolStripMenuItem.DropDown.Enabled = HeaderToolStripMenuItem.Checked
        For i As Integer = 3 To ElementsToolStripMenuItem.DropDownItems.Count - 1
            Dim item = ElementsToolStripMenuItem.DropDownItems(i)
            If TypeOf item Is ToolStripMenuItem Then
                Dim toolstripItem As ToolStripMenuItem = CType(item, ToolStripMenuItem)
                toolstripItem.Checked = mReportGenerator.VisibleControls.Any(Function(dc) dc.Name = toolstripItem.Text)
            End If
        Next
    End Sub

    Private Sub ElementsMenuInitialize()
        ' Populate the Elements menu with all available ReportControls.
        For Each dc As DisplayControl In mReportGenerator.ManagedControls.ToList()
            If Not (dc.Name = "ReportHeader" Or dc.Name = "ReportLetterhead") Then
                Dim elementMenuItem As ToolStripMenuItem = Me.ElementsToolStripMenuItem.DropDownItems.Add(dc.Name)
                AddHandler elementMenuItem.Click, AddressOf Me.ReportsElementsToolStripMenuItem_Click
                AddHandler dc.MouseDown, AddressOf Me.Control_MouseDown
            End If
        Next
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
        SettingsToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        ViewToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
        ReportsExportToolStripMenuItem.Enabled = ElementsToolStripMenuItem.Enabled
    End Sub

    Private Sub HeaderToggle()
        HeaderToolStripMenuItem.Checked = Not HeaderToolStripMenuItem.Checked
        Dim header As DisplayControl = mReportGenerator.ManagedControls.First(Function(dc) dc.Name = "ReportHeader")
        If Not HeaderToolStripMenuItem.Checked Then
            mReportGenerator.VisibleControls.Remove(header)
        Else
            If Not mReportGenerator.VisibleControls.Contains(header) Then
                mReportGenerator.VisibleControls.Add(header)
            End If
        End If
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

    Private Sub LetterheadToggle()
        LetterheadToolStripMenuItem.Checked = Not LetterheadToolStripMenuItem.Checked
        Dim letterHead As DisplayControl = mReportGenerator.ManagedControls.First(Function(dc) dc.Name = "ReportLetterhead")
        If Not LetterheadToolStripMenuItem.Checked Then
            mReportGenerator.VisibleControls.Remove(letterHead)
        Else
            If Not mReportGenerator.VisibleControls.Contains(letterHead) Then
                mReportGenerator.VisibleControls.Add(letterHead)
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
        Dim top As Integer = Me.FormMenuStrip.Bottom
        Dim previousPage As ReportPage = mReportGenerator?.Pages.
            Where(Function(p) p IsNot pg).
            OrderByDescending(Function(p) p.Bottom).
            FirstOrDefault()
        If previousPage IsNot Nothing Then top = previousPage.Bottom
        pg.Top = top + kPageSeparatorHeight
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
        If PageSetupDialog.ShowDialog() = DialogResult.None Then
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
            mReportGenerator.Clear()
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
        Dim visibleHeaderItems As List(Of String) = rh?.VisibleControls.Select(Function(hi) hi.Tag.ToString()).ToList()
        Dim visibleElementItems As List(Of String) = re?.Data.Split(";"c).ToList()
        If re Is Nothing Then
            ReportElementAddNew(elements, rh, String.Join(";", visibleHeaderItems))
        ElseIf rh IsNot Nothing Then
            If Not visibleHeaderItems.SequenceEqual(visibleElementItems) Then re.Data = String.Join(";", visibleHeaderItems)
        Else
            elements.Remove(re)
        End If
    End Sub

    Private Sub ReportMetadataUpdate(ByRef report As Report)
        report.LastModifed = Now
        report.ModifiedBy = Me.User.Id
    End Sub

    Private Sub ReportPropertiesUpdate(ByRef report As Report)
        If report.GridSize <> mReportGenerator.GridSize Then report.GridSize = mReportGenerator.GridSize
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
            .GridSize = 10,
            .ParentForm = Me,
            .VerticalLimit = Me.FormMenuStrip.Height,
            .Zoom = 1.0F,
            .ManagedControls = New ObservableCollection(Of DisplayControl) From {
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
        If report IsNot Nothing Then
            mReportGenerator.Pages.Add(New ReportPage())
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
                                LetterheadLoad(report, DirectCast(dc, ReportLetterhead), re.Data)
                            End If
                        Case Else
                    End Select
                    dc.Location = New Point(re.PositionX, re.PositionY)
                    dc.Size = New Size(re.SizeWidth, re.SizeHeight)
                    dc.Data = Me.JobDetails
                    mReportGenerator.VisibleControls.Add(dc)
                End If
            Next
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
            $"<Report>;{Report.ReportName};{Report.GridSize}{Environment.NewLine}"
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

        ' Update Report properties.
        ReportPropertiesUpdate(mReport)

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
#End Region
#Region "Event Handlers"
#Region "Form Events"
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ControlContextMenuStripShow(sender, e)
    End Sub
    Private Sub FrmReports2_ControlAdded(sender As Object, e As ControlEventArgs) Handles MyBase.ControlAdded
        If TypeOf e.Control Is ReportPage Then
            Dim pg As ReportPage = DirectCast(e.Control, ReportPage)
            PagePositionVertical(pg)
            PagePositionHorizontal(pg)
        End If
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Not FormClose()
        MyBase.Form_Closing(sender, e)
    End Sub

    Private Sub FrmReports2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MasterSource = ReportsBindingSource
        ReportGeneratorInitialize()
        ReportsMenuInitialize()
        HeaderMenuInitialize()
        ElementsMenuInitialize()
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
        LetterheadToggle()
    End Sub

    Private Sub ElementsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ElementsToolStripMenuItem.DropDownOpening
        ElementsDropdownOpening()
    End Sub

    Private Sub FileCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Dim unused = ReportClose()
    End Sub

    Private Sub FileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FileNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileNewToolStripMenuItem.Click
        ReportNew()
    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ReportEditorOpen()
    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ReportSave()
    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ReportSaveAs()
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
        HeaderToggle()
    End Sub

    Private Sub JobsOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobsOpenToolStripMenuItem.Click
        JobSelectorOpen()
    End Sub

    Private Sub JobsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles JobsToolStripMenuItem.DropDownOpening
        JobsDropDownOpening()
    End Sub

    Private Sub LetterheadImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetterheadImageToolStripMenuItem.Click
        LetterheadFileSelect()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PrintPageSetup(sender, e)
    End Sub

    Private Sub ReportsElementsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DisplayControlToggle(CType(sender, ToolStripMenuItem))
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

    Private Sub ZoomActualSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualSizeToolStripMenuItem.Click
        mReportGenerator.Zoom = 1.0F
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        mReportGenerator.Zoom += 0.1F
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        mReportGenerator.Zoom -= 0.1F
    End Sub
#End Region
#Region "Context Menu Events"
    Private Sub AddNewPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewPageToolStripMenuItem.Click

    End Sub

    Private Sub ControlContextMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles ControlContextMenuStrip.Opening
        ControlContextMenuOpening()
    End Sub

    Private Sub DeletePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePageToolStripMenuItem.Click

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        mReportGenerator.PageAddNew(New ReportPage)
    End Sub
#End Region
#End Region
End Class