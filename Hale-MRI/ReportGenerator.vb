Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LibDisplayControls
Imports LibDisplayControls.DisplayControl
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports Newtonsoft.Json.Linq
Imports Windows.Win32.UI
Imports LibDisplayControls.MRIMath
Imports LibDatabase.Models
Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Contexts


''' <summary>
''' Type that aggregates printer paper and margin settings.
''' </summary>
Public Class DocumentSettings
    Public PaperWidth As Integer
    Public PaperHeight As Integer
    Public MarginLeft As Integer
    Public MarginRight As Integer
    Public MarginTop As Integer
    Public MarginBottom As Integer
    Public PrintableArea As Rectangle

    ''' <summary>
    ''' Creates a new DocumentSettings object with the given parameters.
    ''' </summary>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <param name="left"></param>
    ''' <param name="right"></param>
    ''' <param name="top"></param>
    ''' <param name="bottom"></param>
    ''' <param name="area"></param>
    Public Sub New(
            Optional ByVal width As Integer = 0,
            Optional ByVal height As Integer = 0,
            Optional ByVal left As Integer = 0,
            Optional ByVal right As Integer = 0,
            Optional ByVal top As Integer = 0,
            Optional ByVal bottom As Integer = 0,
            Optional ByVal area As Rectangle = Nothing
        )
        PaperWidth = width
        PaperHeight = height
        MarginLeft = left
        MarginRight = right
        MarginTop = top
        MarginBottom = bottom
        PrintableArea = area
    End Sub

    ''' <summary>
    ''' Creates a new DocumentSettings object from another PrintDocument.
    ''' </summary>
    ''' <param name="other"></param>
    Public Sub New(ByVal other As PrintDocument)
        PaperWidth = other.DefaultPageSettings.Bounds.Width
        PaperHeight = other.DefaultPageSettings.Bounds.Height
        MarginLeft = other.DefaultPageSettings.Margins.Left
        MarginRight = other.DefaultPageSettings.Margins.Right
        MarginTop = other.DefaultPageSettings.Margins.Top
        MarginBottom = other.DefaultPageSettings.Margins.Bottom
        PrintableArea = Rectangle.Round(other.DefaultPageSettings.PrintableArea)
    End Sub
End Class

''' <summary>
''' Type that manages visual elements of ReportPages and DisplayControls.
''' and editing.
''' </summary>
Public Class ReportGenerator
#Region "Types and Constants"
    Private kLetterheadHeight As Integer = 120
    Private kHeaderHeight As Integer = 162
    Private Const kHeaderSpacing As Integer = 20

    ''' <summary>
    ''' Zoom event handler signature
    ''' </summary>
    ''' <param name="zoomFactor"></param>
    Public Delegate Sub ZoomEventHandler(zoomFactor As Single)
    Public Event ZoomEvent As ZoomEventHandler

    ''' <summary>
    ''' Enumerates valid edit permissions values.
    ''' </summary>
    Public Enum Edits
        None = 0        ' No edits enabled.
        Copy = 1        ' Copy enabled.
        Cut = 2         ' Cut enabled.
        Delete = 4      ' Delete enabled.
        Paste = 8       ' Paste enabled.
        SelectAll = 16  ' SelectAll (and select any) enabled.
        Undo = 32       ' Undo enabled.
        ZOrder = 64     ' BringToFront/SendToBack enabled.
    End Enum

    ''' <summary>
    ''' Enumerates valid bounds check result values.
    ''' </summary>
    Private Enum BoundsChecks
        None = 0
        Horizontal = 1
        Vertical = 2
        Either = 3
        Both = 4
    End Enum

    Private Const kPageCountMax As Integer = 32
    Private Const kZoomFactorDefault As Single = 1.0F
    Private Const kZoomFactorMin As Single = 0.5F
    Private Const kZoomFactorMax As Single = 2.0F
    Private Const kUndoMax As Integer = 32                      ' Maximum size of the undo stack in elements.
#End Region
#Region "Private Members"
    Private mDocument As DocumentSettings = Nothing
    Private mClickedControl As DisplayControl = Nothing
    Private mClickOffsetPos As Point
    Private mDragStartPos As Point                              ' The starting mouse position of the drag operation.
    Private mEdit As Edits = Edits.None                         ' Bitmask indicating which edit operations are currently permissible.
    Private mGridSize As Integer = 0                            ' The report grid size, in pixels.
    Private mIsDragging As Boolean = False                      ' Indicates whether a drag operation is in progress.
    Private mIsMultiSelect As Boolean = False                   ' Indicates whether multiple selection is active.
    Private mIsResizing As Boolean = False                      ' Indicates whether a resize operation is in progress.
    Private mMarginsVisible As Boolean = False
    Private mPageBounds As Rectangle
    Private mParentForm As FrmContent = Nothing
    Private mPasteLocation As Point                             ' The location of a right mouse click.
    Private mResizePoint As ResizePoints                        ' The resize cursor/type of resize operation.
    Private mUndoStack As New Stack(Of List(Of DisplayControl))
    Private mUndoStack2 As New Stack(Of List(Of ReportPage))
    Private mUndoTemp As List(Of ReportPage) = Nothing
    Private mVerticalLimit As UInteger = 0
    Private WithEvents mManagedControls As New ObservableCollection(Of DisplayControl)  ' The collection of all controls currently managed by the ReportGenerator.
    Private WithEvents mPages As New ObservableCollection(Of ReportPage)                ' The collection of current report pages.
    Private WithEvents mSelectedControls As New ObservableCollection(Of DisplayControl) ' The collection of currently selected controls
    Private WithEvents mVisibleControls As New ObservableCollection(Of DisplayControl)  ' The collection of currently visible report controls.
#End Region
#Region "Public inteface"
    ''' <summary>
    ''' Removes all current ReportPages from the collection and
    ''' the ParentForm, if one exists.
    ''' </summary>
    Public Sub Clear()
        Me.VisibleControls = Nothing
        Me.Pages = Nothing
    End Sub

    Public Sub ControlHide(ByRef dc As DisplayControl)
        mVisibleControls.Remove(dc)
    End Sub '
    Public Sub ControlShow(ByRef dc As DisplayControl)
        If Not mVisibleControls.Contains(dc) Then
            mVisibleControls.Add(dc)
        End If
    End Sub

    Public Sub ControlVisible(ByRef dc As DisplayControl, ByVal visible As Boolean)
        If visible Then
            ControlShow(dc)
        Else
            ControlHide(dc)
        End If
    End Sub

    ''' <summary>
    ''' Gets/sets the current document settings. 
    ''' </summary>
    ''' <returns>DocumentSettings</returns>
    Public Property Document As DocumentSettings    ' Undoable
        Get
            Return mDocument
        End Get
        Set(value As DocumentSettings)
            DocumentSet(value)
            mDocument = value
        End Set
    End Property

    ''' <summary>
    ''' The current edit state.
    ''' </summary>
    ''' <returns>Edits</returns>
    Public ReadOnly Property Edit As Edits
        Get
            Return mEdit
        End Get
    End Property

    ''' <summary>
    ''' Gets Sets the current grid size, in pixels. A grid size of 0 indicates no grid (i.e. free movement).
    ''' </summary>
    ''' <returns>Integer</returns>
    Public Property GridSize As Integer
        Get
            Return mGridSize
        End Get
        Set(value As Integer)
            If value <> mGridSize Then
                GridSizeSet(value)
                mGridSize = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Initializes a report with a single blank page.
    ''' </summary>
    Public Sub Initialize()
        Me.Clear()
        PageInsert(New ReportPage())
    End Sub

    Public Property MarginsVisible As Boolean
        Get
            Return mMarginsVisible
        End Get
        Set(value As Boolean)
            MarginsVisibleSet(value)
            mMarginsVisible = value
        End Set
    End Property

    ''' <summary>
    ''' Deletes the given page and all of its DisplayControls from the current collection.
    ''' </summary>
    ''' <param name="pg"></param>
    Public Function PageDelete(ByRef pg As ReportPage) As Integer
        Dim pageIndex As Integer = -1
        For Each dc As DisplayControl In pg.DisplayControls
            mVisibleControls.Remove(dc)
        Next
        pageIndex = mPages.IndexOf(pg)
        mPages?.Remove(pg)
        Return pageIndex
    End Function

    ''' <summary>
    ''' Adds a new page to the report with default settings or the given ReportPage object, if any. 
    ''' The new page is added after the page at index 'after' or to the end of the current collection 
    ''' of pages, if not specified, and located accordingly on the ParentForm.
    ''' </summary>
    ''' <param name="pg"></param>
    ''' <param name="at"></param>
    Public Sub PageInsert(ByRef pg As ReportPage, Optional ByVal after As Integer = -1)
        If after > -1 Then
            mPages.Insert(after + 1, pg)
        Else
            mPages.Add(pg)
        End If
    End Sub

    ''' <summary>
    ''' Adds a new page to the report with default settings or the given ReportPage object, if any. 
    ''' The new page is added after the specified 'after' page or to the end of the current collection 
    ''' of pages, if not specified, and located accordingly on the ParentForm.
    ''' </summary>
    ''' <param name="pg"></param>
    ''' <param name="after"></param>
    Public Sub PageInsert(ByRef pg As ReportPage, ByVal after As ReportPage)
        If after IsNot Nothing Then
            mPages.Insert(mPages.IndexOf(after) + 1, pg)
        Else
            mPages.Add(pg)
        End If
    End Sub

    ''' <summary>
    ''' Gets/sets the current collection of DisplayControls that are managed by the ReportGenerator.
    ''' </summary>
    ''' <returns>List(Of DisplayControl)</returns>
    Public Property ManagedControls As ObservableCollection(Of DisplayControl)
        Get
            Return mManagedControls
        End Get
        Set(value As ObservableCollection(Of DisplayControl))
            ' In order to fire the CollectionChanged event properly, we need to remove the old
            ' items and add the new items individually.
            ControlsRemoveFrom(ManagedControls, mManagedControls)
            If value IsNot Nothing Then ControlsAddInTo(value, mManagedControls)
        End Set
    End Property

    Public Property PageBounds As Rectangle
        Get
            Return mPageBounds
        End Get
        Set(value As Rectangle)
            PageBoundsSet(value)
            mPageBounds = value
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets the current collection of ReportPages.
    ''' </summary>
    ''' <returns>List(Of ReportPage)</returns>
    Public Property Pages As List(Of ReportPage)
        Get
            Return mPages.ToList()
        End Get
        Set(value As List(Of ReportPage))
            Dim pages As New List(Of ReportPage)(mPages)
            For Each pg As ReportPage In pages
                mPages.Remove(pg)
            Next
            If value IsNot Nothing Then
                For Each pg As ReportPage In value
                    mPages.Add(pg)
                Next
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets the current parent form, where report controls are drawn.
    ''' </summary>
    ''' <returns>Form</returns>
    Public Property ParentForm As FrmContent
        Get
            Return mParentForm
        End Get
        Set(value As FrmContent)
            ParentFormSet(value)
            mParentForm = value
        End Set
    End Property

    ''' <summary>
    ''' Get/sets the list of currently selected controls.
    ''' </summary>
    ''' <returns>List(Of DisplayControl)</returns>
    Public Property SelectedControls As List(Of DisplayControl)
        Get
            Return mSelectedControls.ToList()
        End Get
        Set(value As List(Of DisplayControl))
            ' In order to fire the CollectionChanged event properly, we need to remove the old
            ' items and add the new items individually.
            ControlsRemoveFrom(SelectedControls, mSelectedControls)
            If value IsNot Nothing Then ControlsAddInTo(value, mSelectedControls)
        End Set
    End Property

    ''' <summary>
    ''' Get/sets the list of currently visible controls.
    ''' </summary>
    ''' <returns>List(Of DisplayControl)</returns>
    Public Property VisibleControls As List(Of DisplayControl)
        Get
            Return mVisibleControls.ToList()
        End Get
        Set(value As List(Of DisplayControl))
            ' In order to fire the CollectionChanged event properly, we need to remove the old
            ' items and add the new items individually.
            ControlsRemoveFrom(VisibleControls.ToList(), mVisibleControls)
            If value IsNot Nothing Then ControlsAddInTo(value, mVisibleControls)
            LayoutSave(mVisibleControls.ToList())
        End Set
    End Property

    ''' <summary>
    ''' Sets the top-most location where an object can be positioned on the parent form. 
    ''' </summary>
    ''' <returns>UInteger</returns>
    Public Property VerticalLimit As UInteger
        Get
            Return mVerticalLimit
        End Get
        Set(value As UInteger)
            VerticalLimitSet(value)
            mVerticalLimit = value
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Function ControlBounds(dc As DisplayControl, parentPage As ReportPage) As Rectangle
        Return New Rectangle(parentPage.PointToClient(dc.PointToScreen(Point.Empty)), dc.Size)
    End Function

    'Private Function ControlBoundsCheck(ByVal dc As DisplayControl, ByVal parentPage As ReportPage, offset As Point) As BoundsChecks
    Private Function ControlBoundsCheck(ByVal dc As DisplayControl, offset As Point) As BoundsChecks
        Dim result As BoundsChecks = BoundsChecks.None
        Dim parentPage As ReportPage = DirectCast(dc.Parent, ReportPage)
        Dim pageBounds = New Rectangle(
            parentPage.ClientRectangle.Left,
            parentPage.VerticalLimit,
            parentPage.ClientRectangle.Width,
            parentPage.ClientRectangle.Height - parentPage.VerticalLimit
        )
        If dc.Left + offset.X <= pageBounds.Left OrElse dc.Right + offset.X >= pageBounds.Right Then
            result = BoundsChecks.Horizontal
        ElseIf dc.Top + offset.Y <= pageBounds.Top OrElse dc.Bottom + offset.Y >= pageBounds.Bottom Then
            result = BoundsChecks.Vertical
        End If
        Debug.WriteLine($"ControlBoundsCheck: {dc.Name} {dc.Bounds} {pageBounds} {offset} {result}")
        Return result
    End Function
    Private Function ControlBoundsCheck2(ByVal dc As DisplayControl, offset As Point) As BoundsChecks
        Dim result As BoundsChecks = BoundsChecks.None
        Dim parentPage As ReportPage = DirectCast(dc.Parent, ReportPage)
        Dim dcBounds As Rectangle = dc.ControlBounds 'ControlBounds(dc, parentPage)
        Dim pageBounds = New Rectangle(
            parentPage.ClientRectangle.Left,
            parentPage.VerticalLimit,
            parentPage.ClientRectangle.Width,
            parentPage.ClientRectangle.Height - parentPage.VerticalLimit
        )
        If dcBounds.Left + offset.X <= pageBounds.Left OrElse dcBounds.Right + offset.X >= pageBounds.Right Then
            result = BoundsChecks.Horizontal
        ElseIf dcBounds.Top + offset.Y <= pageBounds.Top OrElse dcBounds.Bottom + offset.Y >= pageBounds.Bottom Then
            result = BoundsChecks.Vertical
        End If
        Debug.WriteLine($"ControlBoundsCheck: {dc.Name} {dcBounds} {pageBounds} {offset} {result}")
        Return result
    End Function
    Private Function ControlResizeCheck(ByVal dc As DisplayControl, loc As Point, sz As Size) As BoundsChecks
        ' Check whether a resize operation is outside the control's page bounds.
        Dim result As BoundsChecks = BoundsChecks.None
        Dim parentPage As ReportPage = DirectCast(dc.Parent, ReportPage)
        Dim dcBounds As Rectangle = dc.ControlBounds
        Dim hLocation As New Point(If(loc <> Point.Empty, loc, dcBounds.Location))
        Dim hSize As New Size(If(sz <> Size.Empty, sz, dc.Size))
        Dim vLocation As New Point(If(loc <> Point.Empty, loc, dcBounds.Location))
        Dim vSize As New Size(If(sz <> Size.Empty, sz, dc.Size))
        Dim pageBounds = New Rectangle(
            parentPage.ClientRectangle.Left,
            parentPage.VerticalLimit,
            parentPage.ClientRectangle.Width,
            parentPage.ClientRectangle.Height
        )

        If hLocation.X <= pageBounds.Left OrElse
            (hLocation.X + hSize.Width) >= pageBounds.Width OrElse
            vLocation.Y <= pageBounds.Top OrElse
            (vLocation.Y + vSize.Height) >= pageBounds.Height Then
            result = BoundsChecks.Either
        End If

        Return result
    End Function

    Private Sub ControlDrag(ByRef dc As DisplayControl, ByVal location As Point, ByVal pg As ReportPage)
        ' Move the control to location and, if set, to the given page.
        dc.Location = location
        If pg IsNot Nothing Then
            dc.Parent = pg
            ' If the control changed pages and is the one the mouse is over, move the cursor along with it
            If dc Is mClickedControl Then
                Dim dcPos As Point = dc.PointToScreen(Point.Empty)
                Dim curPos As Point = New Point(dcPos.X + dc.DragOffset.X, dcPos.Y + dc.DragOffset.Y)
                System.Windows.Forms.Cursor.Position = curPos
            End If
        End If
    End Sub

    Private Sub ControlsBringToFront(controls As List(Of DisplayControl))
        ' Brings the currently selected DisplayControl to the front of the Z-Order.
        For Each dc As DisplayControl In controls
            If dc.IsMovable Then dc.BringToFront()
        Next
    End Sub

    Private Sub ControlsCut(controls As List(Of DisplayControl))
        ' Cuts the currently selected ReportControls from the report.
        UndoSave(Me.Pages, mUndoStack2)
        CutControls = SelectedControls.ToList()
        ControlsRemoveFrom(SelectedControls, mVisibleControls)
        EditPermissionsSet()
    End Sub

    Private Sub ControlsDelete(controls As List(Of DisplayControl))
        ' Deletes the currently selected ReportControls from the report.
        UndoSave(Me.Pages, mUndoStack2)
        ControlsRemoveFrom(SelectedControls, mVisibleControls)
        EditPermissionsSet()
    End Sub

    Private Function ControlParentPage(dc As DisplayControl) As ReportPage
        ' Returns the control's parent page. This function is used because the
        ' control actually belongs to a page's PrintableArea which in turn
        ' belongs to the page.
        Dim ctrl As Control = dc.Parent

        While ctrl IsNot Nothing AndAlso TypeOf ctrl IsNot ReportPage
            ctrl = ctrl.Parent
        End While

        Return DirectCast(ctrl, ReportPage)
    End Function

    Private Sub ControlsPaste(ByRef controls As List(Of DisplayControl))
        ' Pastes any given controls back into the report.
        If controls IsNot Nothing Then
            Dim firstControl As DisplayControl = controls.FirstOrDefault()
            Dim deltaX As Integer = mPasteLocation.X - firstControl.LastPosition.X
            Dim deltaY As Integer = mPasteLocation.Y - firstControl.LastPosition.Y
            UndoSave(Me.Pages, mUndoStack2)
            For Each dc As DisplayControl In controls
                If dc.IsMovable Then
                    dc.Location = New Point(dc.LastPosition.X + deltaX, dc.LastPosition.Y + deltaY)
                End If
                mVisibleControls.Add(dc)
            Next
            controls = Nothing   'Controls can only be pasted into the report once.
            EditPermissionsSet()
        End If
    End Sub

    Private Sub ControlPosition(dc As DisplayControl)
        Dim pg As ReportPage = mPages.FirstOrDefault(Function(p) p.Bottom >= dc.Location.Y)
        ' Continue adding new pages until we find a page that the control fits on.
        Do While pg Is Nothing AndAlso mPages.Count < kPageCountMax
            mPages.Add(New ReportPage())
            pg = mPages.FirstOrDefault(Function(p) p.Bottom >= dc.Location.Y)
        Loop
        dc.EdgeSize = Me.GridSize
        pg?.Controls?.Add(dc)
    End Sub

    Private Sub ControlsRelocate(pg As ReportPage)
        For Each dc As DisplayControl In pg.DisplayControls
            If TypeOf dc Is ReportHeader Then
                HeaderPosition(dc)
            ElseIf TypeOf dc Is ReportLetterhead Then
                LetterheadPosition(dc)
            Else
                Dim dcBounds As Rectangle = ControlBounds(dc, pg)
                Dim pageBounds As Rectangle = pg.ClientRectangle
                If dc.Width > pageBounds.Width - 2 Then
                    dc.Width = pageBounds.Width - 2
                End If
                If dcBounds.Left < pageBounds.Left + 1 Then
                    dc.Left = pageBounds.Left + 1
                ElseIf dcBounds.Right > pageBounds.Right - 1 Then
                    dc.Left = pageBounds.Right - dc.Width - 1
                End If
            End If
        Next
    End Sub

    Private Sub ControlsReposition(pg As ReportPage)
        For Each dc As DisplayControl In pg.DisplayControls
            If TypeOf dc IsNot ReportHeader AndAlso
                TypeOf dc IsNot ReportLetterhead AndAlso
                dc.Top <= pg.VerticalLimit Then
                dc.Top = pg.VerticalLimit + 1
            End If
        Next
    End Sub

    Private Sub ControlRemove(dc As DisplayControl, pg As ReportPage)
        If pg IsNot Nothing Then
            pg.Controls.Remove(dc)
        End If
    End Sub

    Private Sub ControlsSelectAll(controls As List(Of DisplayControl))
        ' Selects all DisplayControl in the given list.
        If controls IsNot Nothing Then
            For Each dc As DisplayControl In controls
                If dc.IsSelectable AndAlso Not dc.Selected Then
                    mSelectedControls.Add(dc)
                End If
            Next
        End If
    End Sub

    Private Sub ControlsSendToBack(controls As List(Of DisplayControl))
        ' Sends the currently selected DisplayControl to the back of the Z-Order.
        For Each dc As DisplayControl In controls
            If dc.IsMovable Then dc.SendToBack()
        Next
    End Sub

    Private Sub ControlsUndo2()
        ' Undoes the last layout changed operation (e.g. Cut, Paste, Move, etc.)
        If mUndoStack.Count > 0 Then
            Dim redo As New List(Of DisplayControl)
            ControlsRemoveFrom(VisibleControls, mVisibleControls)   ' Hide all currently visible controls.
            For Each sc As DisplayControl In mUndoStack.Pop()       ' Pop the previous layout from the UndoStack.
                redo.Add(ManagedControls.FirstOrDefault(Function(dc) dc.Name = sc.Name)?.Copy(sc))
            Next
            ControlsAddInTo(redo, mVisibleControls)                 ' Show all controls in the previous layout.
        End If
    End Sub

    Private Sub ControlsUndo(ByRef pages As List(Of ReportPage), ByRef redoTo As Object)
        If TypeOf redoTo Is Stack(Of List(Of ReportPage)) Then
            Dim stk As Stack(Of List(Of ReportPage)) = DirectCast(redoTo, Stack(Of List(Of ReportPage)))
            If stk.Count > 0 Then
                pages = stk.Pop()
            End If
        ElseIf TypeOf redoTo Is List(Of ReportPage) Then
            Dim lst As List(Of ReportPage) = DirectCast(redoTo, List(Of ReportPage))
            pages = lst
        End If
    End Sub

    Private Sub ControlToggleSelect(dc As DisplayControl, e As MouseEventArgs)
        If dc.IsSelectable Then
            If Not dc.Selected Then
                If Not mIsMultiSelect Then
                    ControlsRemoveFrom(SelectedControls, mSelectedControls)
                End If
                mSelectedControls.Add(dc)
            ElseIf mIsMultiSelect Then
                mSelectedControls.Remove(dc)
            End If
        End If
        ' Set/reset the mIsDragging and mIsResizing flags.
        If mSelectedControls.Count = 0 Then
            mIsDragging = False
            mIsResizing = False
        Else
            If dc.Cursor = Cursors.Default Then
                DragStart(e)
            Else
                ResizeStart(dc, e)
            End If
        End If
    End Sub

    ''' <summary>
    ''' The current list of controls that can be pasted.
    ''' </summary>
    ''' <returns>List(Of DisplayControl)</returns>
    Private Property CutControls As List(Of DisplayControl)

    Private Sub DisplayControlAdd(ByRef dc As DisplayControl)
        ' Adds a DisplayControl to a ReportPage at its current location.
        If TypeOf dc Is ReportHeader Then
            HeaderPosition(dc)
        ElseIf TypeOf dc Is ReportLetterhead Then
            LetterheadPosition(dc)
        Else
            ControlPosition(dc)
        End If
    End Sub

    Private Sub DisplayControlRemove(ByRef dc As DisplayControl)
        Dim ctrl As DisplayControl = dc
        Dim pg As ReportPage = mPages.FirstOrDefault(Function(p) p.Controls.Contains(ctrl))
        If TypeOf dc Is ReportHeader Then
            HeaderRemove(dc, pg)
        ElseIf TypeOf dc Is ReportLetterhead Then
            LetterheadRemove(dc, pg)
        Else
        End If
        ControlRemove(dc, pg)

    End Sub

    Private Sub DocumentSet(ByVal settings As DocumentSettings)
        If mPages IsNot Nothing Then
            For Each pg As ReportPage In mPages
                pg.Document = settings
                ControlsRelocate(pg)
            Next
        End If
    End Sub

    Private Sub DragEnd(e As MouseEventArgs)    ' Undoable
        ' DragStart() pushes an element onto the UndoStack.
        ' LayoutCheck() pops it off if nothing changed as the
        ' undo would be redundant.
        LayoutCheck()
        mIsDragging = False
    End Sub

    Private Sub DragMove(sender As DisplayControl, e As MouseEventArgs)
        ' Drag selected controls to a new location.
        '
        ' Get the mouse position offset from the drag start location.
        Dim deltaX As Integer = e.Location.X - mDragStartPos.X
        Dim deltaY As Integer = e.Location.Y - mDragStartPos.Y
        ' Apply grid snapping if GridSize is set
        If GridSize > 0 Then
            deltaX = Math.Round(deltaX / GridSize) * GridSize
            deltaY = Math.Round(deltaY / GridSize) * GridSize
        End If
        If deltaX = 0 AndAlso deltaY = 0 Then Return

        ' Check all moveable controls. If any control can't
        ' be moved, then none will be moved.
        Dim movements As New List(Of ValueTuple(Of DisplayControl, Point, ReportPage))
        For Each dc In SelectedControls
            If dc.IsMovable Then
                ' Enforce page bounds.
                Dim pg As ReportPage = DirectCast(dc.Parent, ReportPage) 'ControlParentPage(dc)
                Select Case ControlBoundsCheck(dc, New Point(deltaX, deltaY))
                    Case BoundsChecks.None          ' Relocate control to new position according to the mouse offset.
                        movements.Add((dc, New Point(dc.Left + deltaX, dc.Top + deltaY), Nothing))
                    Case BoundsChecks.Horizontal    ' Controls cannot be dragged off page horizontally, so just return.
                        Return
                    Case BoundsChecks.Vertical      ' If there's an adjacent page, move the control there.
                        Dim pageIndex As Integer = mPages.IndexOf(pg)
                        Dim previousPage As ReportPage = If(pageIndex > 0, mPages(mPages.IndexOf(pg) - 1), Nothing)
                        Dim nextPage As ReportPage = If(pageIndex < mPages.Count - 1, mPages(mPages.IndexOf(pg) + 1), Nothing)
                        Dim adjacentPage As ReportPage = If(deltaY < 0, previousPage, nextPage)
                        If adjacentPage IsNot Nothing Then
                            Dim Y As Integer = 0
                            If adjacentPage Is nextPage Then
                                Y = 1
                            Else
                                Y = adjacentPage.ClientRectangle.Bottom - dc.Height - 1
                            End If
                            movements.Add((dc, New Point(dc.ControlBounds.Left, Y), adjacentPage))
                        Else                        ' If there's no adjacent page, return. 
                            Return
                        End If
                    Case Else
                End Select
            End If
        Next

        ' Now move the controls.
        For Each movement As ValueTuple(Of DisplayControl, Point, ReportPage) In movements
            Try
                ControlDrag(movement.Item1, movement.Item2, movement.Item3)
            Catch ex As Exception
                ' Swallow any errors and keep going.
            End Try
        Next
    End Sub

    Private Sub DragStart(e As MouseEventArgs)
        UndoSave(Me.Pages, mUndoTemp)  ' This method is called on Mouse_Down, before any Mouse_Move occurs, but we save the current layout here for convenience.
        mDragStartPos = e.Location
        mIsDragging = True
    End Sub

    Private Sub EditPermissionsSet(Optional e As NotifyCollectionChangedEventArgs = Nothing)
        ' Sets the current edit permissions based on the current report state.
        If SelectedControls.Count > 0 Then
            mEdit = mEdit Or Edits.Copy Or Edits.Cut Or Edits.Delete Or Edits.ZOrder
        Else
            mEdit = mEdit And Not Edits.Copy And Not Edits.Cut And Not Edits.Delete And Not Edits.ZOrder
        End If
        If VisibleControls.Count > 0 Then
            mEdit = mEdit Or Edits.SelectAll
        Else
            mEdit = mEdit And Not Edits.SelectAll
        End If
        If CutControls IsNot Nothing Then
            mEdit = mEdit Or Edits.Paste
        Else
            mEdit = mEdit And Not Edits.Paste
        End If
        If mUndoStack.Count > 0 Then
            mEdit = mEdit Or Edits.Undo
        Else
            mEdit = mEdit And Not Edits.Undo And Not Edits.Paste
        End If
    End Sub

    Private Sub GridSizeSet(value As Integer)
        ' Sets each report page's GridSize.
        If mPages IsNot Nothing Then
            For Each pg As ReportPage In mPages
                pg.GridSize = value
            Next
        End If
    End Sub

    Private Sub HeaderPosition(header As ReportHeader)
        If header IsNot Nothing Then
            Dim letterhead As ReportLetterhead = DirectCast(mVisibleControls.Where(Function(dc) dc.Name = "ReportLetterhead").FirstOrDefault(), ReportLetterhead)
            Dim parentPage As ReportPage = mPages(0)
            Dim margins As Control = parentPage.Controls("Margins")
            If letterhead IsNot Nothing Then
                header.Location = New Point(letterhead.Left, letterhead.Bottom + kHeaderSpacing)
                header.Size = New Size(letterhead.Width, kHeaderHeight)
            Else
                header.Location = New Point(parentPage.Margins.Left, parentPage.Margins.Top)
                header.Size = New Size(parentPage.Margins.Width, kHeaderHeight)
            End If
            header.Parent = parentPage
            parentPage.VerticalLimit = header.Bottom + 1
            ControlsReposition(parentPage)
        End If
    End Sub

    Private Sub HeaderRemove(header As ReportHeader, parentPage As ReportPage)
        Dim letterhead As ReportLetterhead = DirectCast(mVisibleControls.Where(Function(dc) dc.Name = "ReportLetterhead").FirstOrDefault(), ReportLetterhead)
        If letterhead IsNot Nothing Then
            parentPage.VerticalLimit = letterhead.Bottom + 1
        Else
            parentPage.VerticalLimit = 1
        End If

    End Sub

    Private Sub LayoutCheck()
        ' Checks the current to the previous layout and pop's 
        ' the last element from the UndoStack if they're the same.
        'Dim i As Integer
        'For i = 0 To SelectedControls.Count - 1
        '    If SelectedControls(i).LastPosition <> SelectedControls(i).Location OrElse SelectedControls(i).LastSize <> SelectedControls(i).Size Then
        '        LayoutSave(SelectedControls, True)
        '        GoTo Done
        '    End If
        'Next
        'Dim unused As List(Of DisplayControl) = mUndoStack.Pop
        LayoutSave(SelectedControls, True)
Done:
        EditPermissionsSet()
    End Sub

    Private Sub LayoutSave(ByRef controls As List(Of DisplayControl), Optional ByVal lof As Boolean = False)
        ' Sets the DisplayControl' LastPosition and LastSize
        ' to their current Location and Size.
        For Each dc As DisplayControl In controls
            dc.LastPosition = dc.Location
            dc.LastSize = dc.Size
        Next
    End Sub

    Private Sub LetterheadPosition(letterhead As ReportLetterhead)
        If letterhead IsNot Nothing Then
            Dim header As ReportHeader = DirectCast(mVisibleControls.Where(Function(dc) dc.Name = "ReportHeader").FirstOrDefault(), ReportHeader)
            Dim parentPage As ReportPage = mPages(0)
            letterhead.Location = New Point(parentPage.Margins.Left, parentPage.Margins.Top)
            letterhead.Size = New Size(parentPage.Margins.Width, kLetterheadHeight)
            If header IsNot Nothing Then
                header.Location = New Point(letterhead.Left, letterhead.Bottom + kHeaderSpacing)
                parentPage.VerticalLimit = header.Bottom + 1
            Else
                parentPage.VerticalLimit = letterhead.Bottom + 1
            End If
            letterhead.Parent = parentPage
            ControlsReposition(parentPage)
        End If
    End Sub

    Private Sub LetterheadRemove(letterhead As ReportLetterhead, parentPage As ReportPage)
        Dim header As ReportHeader = DirectCast(mVisibleControls.Where(Function(dc) dc.Name = "ReportHeader").FirstOrDefault(), ReportHeader)
        If header IsNot Nothing Then
            header.Location = New Point(letterhead.Location)
            parentPage.VerticalLimit = header.Bottom + 1
        Else
            parentPage.VerticalLimit = 1
        End If
    End Sub

    Private Sub ManagedControlAdd(ByRef dc As DisplayControl)
        ' Attach appropriate event handlers.
        If dc.IsSelectable Then
            AddHandler dc.MouseDownEvent, AddressOf Me.Control_MouseDown
            AddHandler dc.MouseUpEvent, AddressOf Me.Control_MouseUp
        End If
        If dc.IsMovable Or dc.IsSizeable Then
            AddHandler dc.MouseMoveEvent, AddressOf Me.Control_MouseMove
        End If
    End Sub

    Private Sub ManagedControlRemove(ByRef dc As DisplayControl)
        ' Detach any attached event handlers.
        If dc.IsSelectable Then
            RemoveHandler dc.MouseDownEvent, AddressOf Me.Control_MouseDown
            RemoveHandler dc.MouseUpEvent, AddressOf Me.Control_MouseUp
        End If
        If dc.IsMovable Or dc.IsSizeable Then
            RemoveHandler dc.MouseMoveEvent, AddressOf Me.Control_MouseMove
        End If
    End Sub

    Private Sub MarginsVisibleSet(ByVal visible As Boolean)
        For Each pg As ReportPage In mPages
            pg.Margins.Visible = visible
        Next
    End Sub

    Private Sub PageAdd(ByRef pg As ReportPage)
        Dim index As Integer = mPages.IndexOf(pg)
        pg.Name = PageUniqueName("Page_", Me.Pages)
        pg.Document = Me.Document
        pg.GridSize = Me.GridSize
        RemoveHandler pg.MouseDownEvent, AddressOf Me.Report_MouseDown
        AddHandler pg.MouseDownEvent, AddressOf Me.Report_MouseDown
        If Me.ParentForm IsNot Nothing Then mParentForm.Content.Controls.Add(pg)
        pg.Visible = True
    End Sub

    Private Sub PageBoundsSet(ByVal rect As Rectangle)
        For Each pg As ReportPage In mPages
            pg.PageBounds = rect
        Next
    End Sub

    Private Sub PageRemove(ByVal pg As ReportPage)
        mParentForm?.Content.Controls.Remove(pg)
    End Sub

    Private Function PageUniqueName(baseName As String, pages As List(Of ReportPage)) As String
        Dim counter As Integer = 1
        Dim newName As String = baseName & counter.ToString()

        ' Loop until no control with the same name exists
        While pages.Any(Function(pg) pg.Name = newName)
            counter += 1
            newName = baseName & counter.ToString()
        End While

        Return newName
    End Function

    Private Sub ParentFormSet(frm As Form)
        If mParentForm IsNot Nothing Then
            RemoveHandler mParentForm.KeyUp, AddressOf Me.Report_KeyUp
            RemoveHandler mParentForm.KeyDown, AddressOf Me.Report_KeyDown
            RemoveHandler mParentForm.MouseDown, AddressOf Me.Report_MouseDown
        End If
        ' Attach event handlers to the new parent form, if any.
        If frm IsNot Nothing Then
            AddHandler frm.KeyDown, AddressOf Me.Report_KeyDown
            AddHandler frm.KeyUp, AddressOf Me.Report_KeyUp
            AddHandler frm.MouseDown, AddressOf Me.Report_MouseDown
        End If
        If mPages IsNot Nothing Then
            For Each pg As ReportPage In mPages
                frm?.Controls.Add(pg)
            Next
        End If
    End Sub

    Private Sub ResizeEnd(e As MouseEventArgs)  ' Undoable
        ' ResizeStart() pushes an element onto the UndoStack.
        ' LayoutCheck() pops it off if nothing changed as the
        ' undo would be redundant.
        LayoutCheck()
        mIsResizing = False
    End Sub

    Private Sub ResizeMove(dc As DisplayControl, e As MouseEventArgs)
        ' Resize the selected controls.

        ' Get the mouse position offset from the drag start location.
        'Dim cursorPos As Point = Cursor.Position
        Dim dcBounds As Rectangle = dc.ControlBounds
        'Dim deltaX As Integer = cursorPos.X - mDragStartPos.X
        'Dim deltaY As Integer = cursorPos.Y - mDragStartPos.Y
        Dim deltaX As Integer = e.Location.X - mDragStartPos.X
        Dim deltaY As Integer = e.Location.Y - mDragStartPos.Y
        Dim offset As New Point(dc.Parent.PointToClient(MousePosition).X)
        Debug.WriteLine($"{dc.Parent.PointToClient(MousePosition)} {dc.Bounds} {DirectCast(dc.Parent, ReportPage).ClientRectangle}")
        ' Apply grid snapping if GridSize is set
        If GridSize > 0 Then
            deltaX = Math.Round(deltaX / GridSize) * GridSize
            deltaY = Math.Round(deltaY / GridSize) * GridSize
        End If
        If deltaX = 0 And deltaY = 0 Then Exit Sub

        ' Check all sizeable controls. If any control can't
        ' be sized, then none will be sized.
        Dim resizes As New List(Of ValueTuple(Of Point, Size, DisplayControl))
        For Each dc In mSelectedControls
            If dc.IsSizeable Then
                Dim pg As ReportPage = ControlParentPage(dc)
                If ControlBoundsCheck(dc, New Point(deltaX, deltaY)) <> BoundsChecks.None Then Return

                ' Stretch the control according to the edge grabbed and the mouse move direction.
                Dim newSize As Size
                Dim newLocation As Point
                Select Case mResizePoint
                    Case ResizePoints.RightEdge
                        newSize = New Size(dc.LastSize.Width + deltaX, dc.Height)
                    Case ResizePoints.LeftEdge
                        newLocation = New Point(dc.LastPosition.X + deltaX, dc.Top)
                        newSize = New Size(dc.LastSize.Width - deltaX, dc.Height)
                    Case ResizePoints.TopEdge
                        newLocation = New Point(dc.Left, dc.LastPosition.Y + deltaY)
                        newSize = New Size(dc.Width, dc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomEdge
                        newSize = New Size(dc.Width, dc.LastSize.Height + deltaY)
                    Case ResizePoints.TopRightCorner
                        newLocation = New Point(dc.Left, dc.LastPosition.Y + deltaY)
                        newSize = New Size(dc.LastSize.Width + deltaX, dc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomRightCorner
                        newSize = New Size(dc.LastSize.Width + deltaX, dc.LastSize.Height + deltaY)
                    Case ResizePoints.TopLeftCorner
                        newLocation = New Point(dc.LastPosition.X + deltaX, dc.LastPosition.Y + deltaY)
                        newSize = New Size(dc.LastSize.Width - deltaX, dc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomLeftCorner
                        newSize = New Size(dc.LastSize.Width - deltaX, dc.LastSize.Height + deltaY)
                        newLocation = New Point(dc.LastPosition.X + deltaX, dc.Top)
                    Case Else
                        Return
                End Select
                ' Enforce page bounds.
                'If ControlResizeCheck(dc, newLocation, newSize, pg) <> BoundsChecks.None Then Return
                'If ControlResizeCheck(dc, newLocation, newSize) <> BoundsChecks.None Then Return
                'resizes.Add((newLocation, newSize, dc))
            End If
        Next

        ' Now size the controls.
        For Each resize As ValueTuple(Of Point, Size, DisplayControl) In resizes
            If resize.Item1 <> Point.Empty Then
                resize.Item3.Location = resize.Item1
            End If
            If resize.Item2 <> Size.Empty Then
                resize.Item3.Size = resize.Item2
            End If
        Next
    End Sub

    Private Sub ResizeStart(dc As DisplayControl, e As MouseEventArgs)
        UndoSave(Me.Pages, mUndoTemp)  ' This method is called on Mouse_Down, before any Mouse_Move occurs, but we save the current layout here for convenience.
        mDragStartPos = System.Windows.Forms.Cursor.Position
        mResizePoint = dc.ResizePoint
        mIsResizing = True
    End Sub

    Private Sub UndoSave2()
        ' Pushes a snapshot of the current report layout onto the undo stack.
        If mUndoStack.Count < kUndoMax Then
            Dim undo As New ObservableCollection(Of DisplayControl)
            ControlsAddInTo(VisibleControls, undo, True)
            'For Each dc As DisplayControl In undo
            '    dc.LastPosition = dc.Location
            '    dc.LastSize = dc.Size
            'Next
            mUndoStack.Push(undo.ToList())
        End If
    End Sub

    Private Sub UndoSave(ByVal pages As List(Of ReportPage), ByRef saveTo As Object)
        ' Pushes a snapshot of the current report layout onto the undo stack.
        Dim undo As New List(Of ReportPage)
        For Each pg As ReportPage In pages
            undo.Add(DirectCast(pg.Clone, ReportPage))
        Next
        If TypeOf saveTo Is Stack(Of List(Of ReportPage)) Then
            Dim stk As Stack(Of List(Of ReportPage)) = DirectCast(saveTo, Stack(Of List(Of ReportPage)))
            If stk.Count < kUndoMax Then
                stk.Push(undo)
            End If
        ElseIf TypeOf saveTo Is List(Of ReportPage) Then
            Dim lst As List(Of ReportPage) = DirectCast(saveTo, List(Of ReportPage))
            saveTo = lst
        End If
    End Sub

    Private Sub VerticalLimitSet(ByVal limit As UInteger)
        If mPages IsNot Nothing Then
            For Each pg As ReportPage In mPages
                pg.Location = New Point(pg.Location.X, pg.Location.Y - mVerticalLimit + limit)
            Next
        End If
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub Control_MouseDown(sender As DisplayControl, e As MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Right
            Case MouseButtons.Left
                mClickedControl = sender
                ControlToggleSelect(sender, e)
        End Select
    End Sub

    Private Sub Control_MouseMove(sender As DisplayControl, e As MouseEventArgs)
        If mIsDragging Then
            DragMove(sender, e)
        ElseIf mIsResizing Then
            ResizeMove(sender, e)
        End If
    End Sub

    Private Sub Control_MouseUp(sender As DisplayControl, e As MouseEventArgs)
        If mIsDragging Then
            DragEnd(e)
        ElseIf mIsResizing Then
            ResizeEnd(e)
        End If
        mClickedControl = Nothing
    End Sub

    Private Sub ManagedControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles mManagedControls.CollectionChanged
        If e.NewItems IsNot Nothing Then
            For Each dc As DisplayControl In e.NewItems
                ManagedControlAdd(dc)
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each dc As DisplayControl In e.OldItems
                ManagedControlRemove(dc)
            Next
        End If
    End Sub

    Private Sub Pages_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles mPages.CollectionChanged
        ' Adds/removes pages to/from the report.
        If e.NewItems IsNot Nothing Then
            For Each pg As ReportPage In e.NewItems
                PageAdd(pg)
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each pg As ReportPage In e.OldItems
                PageRemove(pg)
            Next
        End If
    End Sub

    Private Sub Report_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A
                    ControlsSelectAll(VisibleControls.ToList())
                Case Keys.B
                    ControlsSendToBack(SelectedControls.ToList())
                Case Keys.F
                    ControlsBringToFront(SelectedControls.ToList())
                Case Keys.V
                    ControlsPaste(CutControls)
                Case Keys.X
                    ControlsCut(SelectedControls.ToList())
                Case Keys.Z
                    ControlsUndo(Me.Pages, mUndoStack2)
                Case Keys.ControlKey
                    mIsMultiSelect = True
                Case Else
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            ControlsDelete(SelectedControls.ToList())
        End If
        e.Handled = True
    End Sub

    Private Sub Report_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            mIsMultiSelect = False
        End If
        e.Handled = True
    End Sub

    Public Sub Report_MouseDown(sender As Object, e As MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Right
                mPasteLocation = e.Location
            Case MouseButtons.Left
                ControlsRemoveFrom(SelectedControls, mSelectedControls)
        End Select
    End Sub

    Private Sub SelectedControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles mSelectedControls.CollectionChanged
        ' Changes the selected status of DisplayControls in the report.
        If e.NewItems IsNot Nothing Then
            For Each dc As DisplayControl In e.NewItems
                dc.Selected = True
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each dc As DisplayControl In e.OldItems
                dc.Selected = False
            Next
        End If
        EditPermissionsSet()
    End Sub

    Private Sub VisibleControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles mVisibleControls.CollectionChanged
        ' Changes the visibility of DisplayControls in the report.
        If e.NewItems IsNot Nothing Then
            For Each dc As DisplayControl In e.NewItems
                DisplayControlAdd(dc)
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each dc As DisplayControl In e.OldItems
                DisplayControlRemove(dc)
            Next
        End If
        EditPermissionsSet(e)
    End Sub
#End Region
End Class
Public Module ReportingGraphs
#Region "Tables"
    Public Function UpdateRadiiAveragesTable(mJobDetails As JobDetail, Design As Boolean) As DataTable
        Dim mJob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("r/R", GetType(Integer))
        Dim rowRadiusBlade As DataRow

        For Each radmeas As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1)
            rowRadiusBlade = dtBladePitchByRadius.Rows.Add(Math.Round(radmeas.Radius.Value).ToString + " %")
        Next
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value).ToString + " %" = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(dtBladePitchByRadius.Rows.Find(Math.Round(rm.Radius.Value).ToString + " %"), dtBladePitchByRadius.Rows.Add(rm.Radius.Value).ToString + " %")
                colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim meancol As DataColumn = If(dtBladePitchByRadius.Columns("Mean"), dtBladePitchByRadius.Columns.Add("Mean", GetType(Double)))
            Dim avgPitch As Double = totalPitch / pitchCount
            row.Item(meancol) = Math.Round(avgPitch, 2)
            If Design Then
                Dim designcol As DataColumn = If(dtBladePitchByRadius.Columns("Design"), dtBladePitchByRadius.Columns.Add("Design", GetType(Double)))
                'add if here for design loaded check use design pitch if loaded and ref if not
                row.Item(designcol) = Math.Round(mJob.DesiredPitch.Value, 2)
            End If
        Next
        Return dtBladePitchByRadius
    End Function
    Public Function UpdateChordLengthTable(mJobDetails As JobDetail) As DataTable
        Dim mjob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtChordLength As New DataTable()
        Dim colRadius As DataColumn = dtChordLength.Columns.Add("Blade", GetType(Integer))
        Dim rowBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob?.PropellerBlades
            dtChordLength.Rows.Add(x)
        Next
        dtChordLength.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtChordLength.Rows
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowBlade = If(dtChordLength.Rows.Find(rm.BladeId), dtChordLength.Rows.Add(rm.BladeId))
                colRadius = If(dtChordLength.Columns(radiusPercent), dtChordLength.Columns.Add(radiusPercent, GetType(Double)))
                Dim ChordLength As Double = GetChordLength(rm.CellMeasurements.FirstOrDefault.Angle.Value, rm.CellMeasurements.LastOrDefault.Angle.Value, rm.CellMeasurements.FirstOrDefault.Depth.Value, rm.CellMeasurements.LastOrDefault.Depth.Value, mjob.PropellerDiameter, CInt(radiusPercent))
                rowBlade.Item(colRadius) = Math.Round(ChordLength, 2)
            Next
            colRadius = If(dtChordLength.Columns("Track"), dtChordLength.Columns.Add("Track", GetType(Double))) ' need to figure out what this is
        Next
        Return dtChordLength
    End Function

    Public Function UpdateISOTOLTable(basispitch As Double, Tolclass As Tolerance, Mins As Boolean) As DataTable
        Dim ISOTable As New DataTable()
        ISOTable.Columns.Add("TolType", GetType(String))
        ISOTable.Columns.Add("MinsApply", GetType(String))
        ISOTable.Columns.Add("TolPerc", GetType(String))
        ISOTable.Columns.Add("PlusMinus", GetType(String))
        ISOTable.Columns.Add("OverUnder", GetType(String))

        'Local Pitch
        Dim RowLocal As DataRow = ISOTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("MinsApply") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.LocalPitchPercent.ToString() & " %"
        Dim MinMax As Double
        MinMax = basispitch * (Tolclass.LocalPitchPercent / 100)
        If Mins And MinMax < Tolclass.LocalPitchMinimum * kMmToInch Then 'need checks for SYS type
            MinMax = Tolclass.LocalPitchMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " / " + (basispitch - MinMax)

        'Radius Average
        RowLocal = ISOTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerRadiusPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerRadiusPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerRadiusMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerRadiusMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Blade Average
        RowLocal = ISOTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerBladePercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerBladePercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerBladeMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerBladeMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Propeller Average
        RowLocal = ISOTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchForPropellerPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchForPropellerPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchForPropellerMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchForPropellerMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"
        If Mins <> True Then
            ISOTable.Columns.RemoveAt(1)
        End If
        Return ISOTable
    End Function

    Public Function UpdateLocalPitchTable(mJobDetails As JobDetail, TolClass As Tolerance)
        Dim dtLPTable As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim rowRad As DataRow
        Dim colBlade As DataColumn
        Dim x As Integer
        Dim y As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                colBlade = dtLPTable.Columns.Add("RadCol")
                rowRad = dtLPTable.Rows.Add("BladeRow")
                rowRad.Item("RadCol") = "r/R"
            Else
                For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                    rowRad = If(dtLPTable.Rows.Find(rm.Radius.Value.ToString()), dtLPTable.Rows.Add(rm.Radius.Value.ToString()))
                    For y = 1 To TolClass.LocalPitchSectors
                        colBlade = If(dtLPTable.Columns("Blade" + rm.BladeId.ToString() + y.ToString()), dtLPTable.Columns.Add("Blade" + rm.BladeId.ToString() + y.ToString()))
                        rowRad.Item("Blade" + rm.BladeId.ToString() + y.ToString()) = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, y, mJob.PropellerBlades, rm.Radius, mJob.TeExclusion, mJob.LeExclusion)
                    Next
                Next
            End If
        Next
        Return dtLPTable
    End Function

    Public Function UpdateBladeAveragesTable(mJobDetails As JobDetail) As DataTable
        Dim dtbladeaverage As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim pitchrow As DataRow = dtbladeaverage.Rows.Add("Pitch")
        Dim BladeCol As DataColumn
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            BladeCol = dtbladeaverage.Columns.Add("Blade" + x)
            Dim pitchtotal As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                pitchtotal += GetAverageBladePitch(rm.CellMeasurements, mJob.TeExclusion, mJob.LeExclusion)
                pitchcount += 1
            Next
            pitchrow.Item(BladeCol) = pitchtotal / pitchcount
        Next
        Return dtbladeaverage
    End Function

    Public Function UpdateFederalToleranceListTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = ".75 %"
        MinMax = BasisPitch * (0.75 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.01
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateMichiganToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateStandardToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateManualInspTable() As DataTable
        Dim dtManualInsp As New DataTable()
        dtManualInsp.Columns.Add("InspectionItem", GetType(String))
        dtManualInsp.Columns.Add("Yes", GetType(String))
        dtManualInsp.Columns.Add("No", GetType(String))

        Dim row As DataRow = dtManualInsp.Rows.Add("ACCEPTABLE")
        row.Item("InspectionItem") = "ACCEPTABLE"
        row.Item("Yes") = "YES"
        row.Item("No") = "NO"
        row = dtManualInsp.Rows.Add("Blade Surface")
        row.Item("InspectionItem") = "Blade Surface"
        row = dtManualInsp.Rows.Add("Blade Edges")
        row.Item("InspectionItem") = "BladeEdges"
        row = dtManualInsp.Rows.Add("Static Balance")
        row.Item("Inspectionitem") = "Static Balance"
        row = dtManualInsp.Rows.Add("Thcikness")
        row.Item("InspectionItem") = "Thickness"
        row = dtManualInsp.Rows.Add("Bore")
        row.Item("InspectionItem") = "Bore"
        row = dtManualInsp.Rows.Add("Keyway")
        row.Item("InspectionItem") = "KeyWay"
        Return dtManualInsp
    End Function

    Public Function UpdateRadiusToleranceTable(Diameter As Double, TolClass As Tolerance) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Min")
        tolTable.Columns.Add("Design")
        tolTable.Columns.Add("Max")

        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Min") = "Min"
        row.Item("Design") = "Design"
        row.Item("Max") = "Max"
        row = tolTable.Rows.Add("Tolerance")
        Dim mintol As Double = (Diameter / 2) - ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Min") = Math.Round(mintol, 2)
        row.Item("Design") = Math.Round(Diameter / 2, 2)
        Dim maxtol As Double = (Diameter / 2) + ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Max") = Math.Round(maxtol, 2)
        Return tolTable
    End Function

    Public Function UpdateTrackToleranceTable(BasisPitch As Double) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Tolerance")
        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Tolerance") = "Track Tolerance"
        row = tolTable.Rows.Add("MinMax")
        Dim minmax = BasisPitch * 0.01
        row.Item("Tolerance") = minmax.ToString()
        Return tolTable
    End Function

    Public Function UpdateRadiusBladeWheelAveragePitchTable(mJobDetails As JobDetail, TolClass As Tolerance, Basispitch As Double) As DataTable
        Dim Table As New DataTable()
        Dim mjob As Job = mJobDetails.Job

        Dim colRadius As DataColumn = Table.Columns.Add("Blade", GetType(Integer))
        Dim rowRadiusBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob.PropellerBlades
            rowRadiusBlade = Table.Rows.Add(x)
        Next
        Table.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In Table.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0 ' Condensed these for loops into one to increase speed
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(Table.Rows.Find(rm.BladeId), Table.Rows.Add(rm.BladeId))
                colRadius = If(Table.Columns(radiusPercent), Table.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mjob.TeExclusion, mjob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim avgPitch As Double = totalPitch / pitchCount
            colRadius = If(Table.Columns("Average"), Table.Columns.Add("Average", GetType(Double)))
            row.Item(colRadius) = Math.Round(avgPitch, 2)
            colRadius = If(Table.Columns("Wheel"), Table.Columns.Add("Wheel", GetType(Double)))
            row.Item(colRadius) = mJobDetails.WheelPitch.Value
        Next
        rowRadiusBlade = Table.Rows.Add("Allow")
        Dim minmax As Double
        minmax = Basispitch * (TolClass.MeanPitchPerRadiusPercent / 100)
        Dim allow As String = (Basispitch + minmax).ToString() + " / " + (Basispitch - minmax).ToString()
        For Each col As DataColumn In Table.Columns
            If col.ColumnName = "Blade" Then
                rowRadiusBlade.Item(col) = "Allow"
            ElseIf col.ColumnName = "Average" Or col.ColumnName = "Wheel" Then
                rowRadiusBlade.Item(col) = "± " + TolClass.MeanPitchPerRadiusPercent / 100 + "%"
            Else
                rowRadiusBlade.Item(col) = allow
            End If
        Next
        Return Table
    End Function

    Public Function UpdateSkewTable(mJobDetails As JobDetail) As DataTable
        Dim dtable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim BladeCol As DataColumn = dtable.Columns.Add("Radius", GetType(String))
        Dim RadRow As DataRow
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            Dim ReferenceRadius As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).FirstOrDefault()
            Dim ReferenceAngle As Double = GetChordMidAngle(ReferenceRadius.CellMeasurements)
            Dim ReferenceDepth As Double = GetChordMidDepth(ReferenceRadius.CellMeasurements)
            BladeCol = dtable.Columns.Add("Blade" + x, GetType(String))
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                RadRow = If(dtable.Rows.Find(Math.Round(rm.Radius.Value, 2)), dtable.Rows.Add(Math.Round(rm.Radius.Value, 2)))
                If x = 1 Then
                    RadRow.Item("Radius") = rm.Radius + "%"
                End If
                If rm.Radius = ReferenceRadius.Radius Then
                    RadRow.Item(BladeCol) = "Ref"
                Else
                    Dim rmdepth As Double = GetChordMidDepth(rm.CellMeasurements)
                    Dim rmangle As Double = GetChordMidAngle(rm.CellMeasurements)
                    Dim anglediff As Double = rmangle - ReferenceAngle
                    Dim chordDiff As Double = GetChordLength(ReferenceAngle, rmangle, ReferenceDepth, rmdepth, mJob.PropellerDiameter, rm.Radius)
                    Dim diffs As String = anglediff + "Deg / " + chordDiff + " In"
                    RadRow.Item(BladeCol) = diffs
                End If
            Next
        Next
        Return dtable
    End Function

    Public Function UpdateAngularSpacingTable(mJobDetails As JobDetail) As DataTable
        Dim dTable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim bladecol As DataColumn = dTable.Columns.Add("Blade", GetType(String))
        bladecol = dTable.Columns.Add("Ang", GetType(String))
        Dim bladerow As DataRow
        Dim x As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                bladerow = dTable.Rows.Add("Design")
                bladerow.Item("Blade") = "Design"
                bladerow.Item("Ang") = (360 / mJob.PropellerBlades).ToString() + " Deg"
            Else
                bladerow = dTable.Rows.Add("Blade" + x.ToString())
                bladerow.Item("Blade") = "Blade " + x.ToString()
                If x = 1 Then
                    bladerow.Item("Ang") = "Ref"
                Else
                    Dim refangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1 And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim currangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim anglespace As Double = currangle - refangle - ((360 / mJob.PropellerBlades) * (x - 1))
                    bladerow.Item("Ang") = anglespace.ToString("F2") + " Deg"
                End If
            End If
        Next
        Return dTable
    End Function
#End Region
#Region "Graphs"
    Public Sub UpdateBladeAverageGraph(Graph As Chart, mJobDetails As JobDetail, Tolclass As Tolerance, basispitch As Double)
        Graph.Series.Clear()
        Graph.ChartAreas.Clear()
        Graph.Legends.Clear()
        Graph.Titles.Clear()
        Graph.Annotations.Clear()

        Dim cArea As ChartArea = Graph.ChartAreas.Add("BladeAverage")
        Dim ser As Series = Graph.Series.Add("Pitch")
        ser.ChartType = SeriesChartType.Bar
        ser.ChartArea = cArea.Name
        cArea.AxisY2.Enabled = AxisEnabled.False
        cArea.AxisX2.Enabled = AxisEnabled.False

        cArea.Axes(1).Minimum = 0
        cArea.Axes(1).Maximum = basispitch * 1.2
        cArea.Axes(1).Interval = 1
        cArea.Axes(1).MinorTickMark.Enabled = True
        cArea.Axes(1).MinorTickMark.Interval = 1
        cArea.Axes(1).MajorTickMark.Enabled = True
        cArea.Axes(1).MajorTickMark.Interval = 5
        cArea.Axes(1).MajorGrid.Enabled = True
        cArea.Axes(1).MajorGrid.Interval = basispitch * 1.2

        cArea.Axes(0).Minimum = 0
        cArea.Axes(0).Maximum = mJobDetails.Job.PropellerBlades + 1
        cArea.Axes(0).Interval = 1
        cArea.Axes(0).Title = "Blade"
        cArea.Axes(0).TitleFont = New Font("Arial", 14, FontStyle.Bold)
        cArea.Axes(0).IsMarginVisible = True

        Dim x As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim avgpitch As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                avgpitch += GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                pitchcount += 1
            Next
            If pitchcount > 0 Then
                avgpitch /= pitchcount
            End If
            Dim pointind As Integer = ser.Points.AddXY(x, avgpitch)
            ser.Points(pointind).Color = GraphColorArray(x - 1)
        Next
        Dim slineunder As New StripLine With {
            .IntervalOffset = basispitch - (basispitch * (Tolclass.MeanPitchPerBladePercent / 100)),
            .StripWidth = 0.01,
            .BorderColor = Color.Black,
            .BorderWidth = 2,
            .Text = (basispitch - (basispitch * (Tolclass.MeanPitchPerBladePercent / 100))).ToString(),
            .TextOrientation = TextOrientation.Horizontal,
            .TextLineAlignment = StringAlignment.Near,
            .ForeColor = Color.Red
        }
        cArea.Axes(1).StripLines.Add(slineunder)
        Dim slineover As New StripLine With {
            .IntervalOffset = basispitch + (basispitch * (Tolclass.MeanPitchPerBladePercent / 100)),
            .StripWidth = 0.01,
            .BorderColor = Color.Black,
            .BorderWidth = 2,
            .Text = (basispitch + (basispitch * (Tolclass.MeanPitchPerBladePercent / 100))).ToString(),
            .TextOrientation = TextOrientation.Horizontal,
            .TextLineAlignment = StringAlignment.Far,
            .ForeColor = Color.Blue
        }
        cArea.Axes(1).StripLines.Add(slineover)

    End Sub
    Public Sub UpdateBladeHeightGraph(heightgraph As Chart, mJobDetails As JobDetail)
        'This pulls reference values from the Measurements form, the measurements form must be initialized for this to work
        If gFrmMeasurements Is Nothing Then
            Return
        End If
        heightgraph.Series.Clear()
        heightgraph.ChartAreas.Clear()
        heightgraph.Legends.Clear()
        heightgraph.Titles.Clear()
        heightgraph.Annotations.Clear()

        Const kHeightOffset As Double = 0.2 ' Offset to add to data points for visual comparison?
        Dim refBlade As Integer? = gFrmMeasurements.ComboReferenceBlade.SelectedValue
        Dim refPoint As String = gFrmMeasurements.ComboReferencePoint.SelectedValue
        Dim refRadius As Double = gFrmMeasurements.ComboReferenceRadius.SelectedValue
        ' If all three reference values are given, calculate and plot the data.
        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesHeight As Series = ChartCreateSeries(heightgraph, "BladeHeight", "Blade", "Height")
            Dim radiusMeasurements As List(Of RadiusMeasurement) = mJobDetails?.RadiusMeasurements?.Where(Function(r) r.BladeId = refBlade).OrderBy(Function(r) CType(r.Radius, Double)).ToList()
            Dim innerRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault() ' RadiusMeasurement at smallest radius
            Dim outerRm As RadiusMeasurement = radiusMeasurements?.LastOrDefault()  ' RadiusMeasurement at largest radius
            Dim refRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)    ' RadiusMeasurement at reference radius
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)                 ' Depth at reference radius and point
            ' Plot each blade's data points
            If innerRm Is Nothing Or outerRm Is Nothing Then
                Return
            End If
            For i As Integer = 1 To mJobDetails?.Job?.PropellerBlades
                Dim b As Integer = i
                Dim rm As RadiusMeasurement = mJobDetails?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = b)
                If rm IsNot Nothing Then
                    Dim bladeDepth As Double = TrackGetDepth(rm, refPoint)
                    Dim bladeHeight As Double = Math.Abs(refDepth - bladeDepth) + kHeightOffset
                    ChartAddPoint(heightgraph, seriesHeight, $"{b}", bladeHeight, (b = refBlade))
                End If
                heightgraph.Series(0).Points(i - 1).Color = GraphColorArray(i - 1)
            Next
        End If
    End Sub

    Private Sub UpdateAngularPositionGraph(angPosGraph As Chart, mJobDetails As JobDetail)
        If gFrmMeasurements Is Nothing Then
            Return
        End If
        Const kHeightOffset As Double = 0.2 ' Offset to add to data points for visual comparison?
        Dim refBlade As Integer? = gFrmMeasurements.ComboReferenceBlade.SelectedValue
        Dim refPoint As String = gFrmMeasurements.ComboReferencePoint.SelectedValue
        Dim refRadius As Double = gFrmMeasurements.ComboReferenceRadius.SelectedValue
        ' If all three reference values are given, calculate and plot the data.
        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesPosition As Series = ChartCreateSeries(angPosGraph, "AngularPosition", "Blade", "Position")
            Dim radiusMeasurements As List(Of RadiusMeasurement) = mJobDetails?.RadiusMeasurements?.Where(Function(r) r.BladeId = refBlade).OrderBy(Function(r) CType(r.Radius, Double)).ToList()
            Dim innerRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault() ' RadiusMeasurement at smallest radius
            Dim innerDepth As Double = TrackGetDepth(innerRm, refPoint)             ' Depth at smallest radius and reference point
            Dim outerRm As RadiusMeasurement = radiusMeasurements?.LastOrDefault()  ' RadiusMeasurement at largest radius
            Dim outerDepth As Double = TrackGetDepth(outerRm, refPoint)             ' Depth at largest radius and reference point
            Dim refRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)    ' RadiusMeasurement at reference radius
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)                 ' Depth at reference radius and point
            Dim refAngle As Double = TrackGetAngle(refRm, refPoint)                 ' Angle at reference radius and point
            ' Plot each blade's data points
            If innerRm Is Nothing Or outerRm Is Nothing Then
                Return
            End If
            For i As Integer = 1 To mJobDetails?.Job?.PropellerBlades
                Dim b As Integer = i
                Dim rm As RadiusMeasurement = mJobDetails?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = b)
                If rm IsNot Nothing Then
                    Dim bladeDepth As Double = TrackGetDepth(rm, refPoint)
                    Dim bladeAngle As Double = TrackGetAngle(rm, refPoint)
                    Dim bladeHeight As Double = Math.Abs(refDepth - bladeDepth) + kHeightOffset
                    Dim bladePosition As Double = Math.Abs(refAngle - bladeAngle) - ((360 / mJobDetails.Job?.PropellerBlades) * Math.Abs(refBlade.Value - rm.BladeId.Value)) + kHeightOffset
                    ChartAddPoint(angPosGraph, seriesPosition, $"{b}", bladePosition, (b = refBlade))
                End If
                angPosGraph.Series(0).Points(i - 1).Color = GraphColorArray(i - 1)
            Next
        End If
    End Sub
    Public Sub UpdateLineGraph(rm As RadiusMeasurement, LineChart As Chart, Database As HaleMRIContext, Optional Progcm As List(Of CellMeasurement) = Nothing, Optional Trackcm As List(Of CellMeasurement) = Nothing)
        'Might have to change this as it directly pulls the visual, including scaling loaded progression and all other settings, from the comparison form

        'this is a group of variables that will be pulled from the comparison form. They will be given set values for testing purposes
        Dim centerRef As Boolean = True ' dictates whether the reference heights are calculated from the start or center of the chord
        Dim RefPitch As Double = 22
        Dim entireScan As Boolean = False ' handles the exclusion zones, if true no exclusion zones are applied
        Dim showTrack As Boolean = True ' handles whether or not to use the HeightAtRefPoint from the tracked blade or the current radius measurement
        Dim HeightAtRefPoint As Double = 0.0 ' this value is only used to modify the actual LPline series the tolerance lines and reference lines are not affected by it
        Dim spline As Boolean = False ' dictates whether the graph lines are spline or straight lines
        Dim AxesScaling As Double = 1.0
        Dim refheights As List(Of Double) = GetRefHeightsStraight(centerRef, RefPitch, rm.JobDetails.Job.PropellerBlades)

        Dim LEE As Double = rm.JobDetails.Job.LeExclusion.Value
        Dim TEE As Double = rm.JobDetails.Job.TeExclusion.Value
        If entireScan Then
            LEE = 0
            TEE = 0
        End If

        LineChart.Series.Clear()
        LineChart.ChartAreas.Clear()
        LineChart.Legends.Clear()
        LineChart.Titles.Clear()
        LineChart.Annotations.Clear()

        LineChart.PaletteCustomColors = GraphColorArray
        Dim cArea As ChartArea = LineChart.ChartAreas.Add("LPLineArea")
        Dim ser As Series = LineChart.Series.Add("LPLineSeries")
        Dim refser As Series = LineChart.Series.Add("Ref")
        Dim tolhighser As Series = LineChart.Series.Add("TolHigh")
        Dim tollowser As Series = LineChart.Series.Add("TolLow")

        Dim x As Integer
        If Progcm Is Nothing Then 'all creation and management of reference and tolerance lines are handled here
            For x = 0 To 10
                refser.Points.Add(x * 10, 0)
            Next
            If showTrack = True Then
                If centerRef Then
                    HeightAtRefPoint = GetLocalHeightEndSector(Trackcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) 'need to be able to pull ref points from tracked blade
                Else
                    HeightAtRefPoint = GetLocalHeightStartSector(Trackcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
            Else
                If centerRef Then
                    HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                Else
                    HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
            End If
        Else
            Dim tollisthigh As List(Of Double) = GetRefHeightsHighTol(centerRef, RefPitch, GetToleranceTable(Database, rm.JobDetails.ToleranceClass), rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
            Dim tollistlow As List(Of Double) = GetRefHeightsLowTol(centerRef, RefPitch, GetToleranceTable(Database, rm.JobDetails.ToleranceClass), rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
            For x = 0 To 10
                Dim height As Double
                If x = 0 Then
                    height = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                Else
                    height = GetLocalHeightEndSector(Progcm, 10, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
                height -= refheights(x)  'need to add a change in here that changes height based on center ref point and the ref height at that point
                refser.Points.Add(x * 10, height)
                tolhighser.Points.Add(x * 10, tollisthigh(x))
                tollowser.Points.Add(x * 10, tollistlow(x))
                If showTrack = True Then
                    If centerRef Then
                        HeightAtRefPoint = GetLocalHeightEndSector(Progcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    Else
                        HeightAtRefPoint = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    End If
                Else
                    If centerRef Then
                        HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    Else
                        HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    End If
                End If
            Next
        End If
        Dim newheights As New List(Of Double)
        If showTrack = False Then 'need to populate newheights based on height at ref point
            For x = 0 To 10
                newheights.Add(refheights(x) + HeightAtRefPoint)
            Next
        End If

        Dim lpline As New List(Of Double)
        For x = 0 To 10
            If x = 0 Then
                lpline.Add(GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
            Else
                lpline.Add(GetLocalHeightEndSector(rm.CellMeasurements, 10, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
            End If
            ser.Points.Add(x * 10, lpline(x))
        Next

        'need a for loop that edits the lpline heights based on the reference height at that point
        If spline = False Then
            ser.ChartType = SeriesChartType.Line
            refser.ChartType = SeriesChartType.Line
            tollowser.ChartType = SeriesChartType.Line
            tolhighser.ChartType = SeriesChartType.Line
        Else
            ser.ChartType = SeriesChartType.Spline
            refser.ChartType = SeriesChartType.Spline
            tollowser.ChartType = SeriesChartType.Spline
            tolhighser.ChartType = SeriesChartType.Spline
        End If

        refser.ChartArea = cArea.Name
        tolhighser.ChartArea = cArea.Name
        tollowser.ChartArea = cArea.Name
        ser.ChartArea = cArea.Name
        LineChart.ChartAreas(0).Position.Auto = False
        LineChart.ChartAreas(0).Position.Height = 100
        LineChart.ChartAreas(0).Position.Width = 100
        LineChart.ChartAreas(0).AxisX.Minimum = -5
        LineChart.ChartAreas(0).AxisX.Maximum = 105
        LineChart.ChartAreas(0).AxisY.Minimum = -AxesScaling ' need to add control for managing y Axis Scaling
        LineChart.ChartAreas(0).AxisY.Maximum = AxesScaling
    End Sub

    Public Sub ShowBladePlot(mJobDetails As JobDetail, ChartPlot As Chart, TolClass As Tolerance, basispitch As Double)
        If mJobDetails Is Nothing Then Return

        ' Clear any existing chart areas and series.
        ChartPlot.ChartAreas.Clear()
        ChartPlot.Series.Clear()
        ChartPlot.Titles.Clear()

        ' Add a ChartArea and Title for the point graph
        Dim chartArea1 As New ChartArea()
        chartArea1.AxisX.MajorGrid.Enabled = False
        chartArea1.AxisY.MajorGrid.Enabled = False
        chartArea1.AxisX.LabelStyle.Enabled = False
        chartArea1.AxisY.LabelStyle.Enabled = False
        chartArea1.AxisX.MajorTickMark.Enabled = False
        chartArea1.AxisY.MajorTickMark.Enabled = False
        chartArea1.AxisX.LineWidth = 0
        chartArea1.AxisY.LineWidth = 0
        ChartPlot.ChartAreas.Add(chartArea1)
        ChartPlot.Titles.Add("Blade Tolerances By Radius")

        ' Get a list of RadiusMeasurements for this JobDetail.
        Dim radiusMeasurements As List(Of RadiusMeasurement) =
            mJobDetails?.RadiusMeasurements _
            .OrderBy(Function(b) b.BladeId) _
            .ThenBy(Function(r) CType(r.Radius, Double)) _
            .ToList()
        ' The chart axes min/max values are the greatest radius value,
        ' this way the arcs always start at the outside of the chart area.
        chartArea1.AxisX.Maximum = kBladePlotAxesMax
        chartArea1.AxisX.Minimum = -chartArea1.AxisX.Maximum
        chartArea1.AxisY.Maximum = chartArea1.AxisX.Maximum
        chartArea1.AxisY.Minimum = -chartArea1.AxisY.Maximum
        ' Each RadiusMeasurement is a new Series of Points that circumscribes an arc
        ' having a radius equal to RadiusMeasurement.Radius. 
        For Each rm As RadiusMeasurement In radiusMeasurements
            Dim s As New Series With {
                .ChartType = SeriesChartType.Point,
                .MarkerStyle = MarkerStyle.Circle,
                .MarkerSize = 5
            }
            Dim cellMeasurements As List(Of CellMeasurement) = rm.CellMeasurements.ToList()
            Dim arcColors As New List(Of ToleranceColor)
            Dim sector As Integer = 1
            For sector = 1 To TolClass.LocalPitchSectors
                arcColors.Add(CheckLocalPitchTolerance(TolClass, GetLocalPitch(cellMeasurements, TolClass.LocalPitchSectors, sector, mJobDetails.Job.PropellerDiameter, rm.Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion), basispitch, True))
            Next
            Dim cellPerSector As Integer = CInt(Math.Floor(cellMeasurements.Count / TolClass.LocalPitchSectors))
            For i As Integer = 1 To cellMeasurements.Count - 1
                Dim currentSector As Integer = Math.Truncate(i / cellPerSector)
                Dim cmCurrent As CellMeasurement = cellMeasurements(i)
                Dim cmPrevious As CellMeasurement = cellMeasurements(i - 1)
                Dim angle As Double = (cmCurrent?.Angle + cmPrevious?.Angle) / 2
                Dim coordinates = PolarToCartesian(rm.Radius, angle)
                Dim p As Integer = s.Points.AddXY(coordinates.x, coordinates.y) ' Need a mathematical formula based on data in the dB or functions in MRIMath module x,y=f(a,b) ???
                Dim pointcolor As ToleranceColor = arcColors(Math.Min(currentSector, arcColors.Count - 1))
                s.Points(p).Color = ToColor(pointcolor)
            Next
            ChartPlot.Series.Add(s)
        Next
    End Sub

    Private Sub UpdateRadiusBladeWheelAveragePitchGraph(Graph As Chart, mJobDetails As JobDetail, TolClass As Tolerance, basispitch As Double)
        Graph.ChartAreas.Clear()
        Graph.Series.Clear()
        Graph.Legends.Clear()
        Graph.Titles.Clear()
        Dim cArea As ChartArea = Graph.ChartAreas.Add("Area1")
        Dim x As Integer
        Dim proppitch As Double = 0
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim ser As Series = Graph.Series.Add("Blade" + x.ToString())
            ser.ChartArea = "Area1"
            Dim totpitch As Double = 0
            ser.ChartType = SeriesChartType.Bar
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                Dim avgpitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                Dim pointind As Integer = ser.Points.AddXY(Math.Round(rm.Radius.Value).ToString() + "%", avgpitch)
                totpitch += avgpitch
                ser.Points(pointind).Color = GraphColorArray(x - 1)
            Next
            Dim meanpitch As Double = totpitch / mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).Count()
            ser.Points.AddXY("Bld Avg", meanpitch)
            proppitch += meanpitch
        Next
        Dim propavg As Double = proppitch / mJobDetails.Job.PropellerBlades
        Dim serprop As Series = Graph.Series.Add("Wheel Avg")
        serprop.ChartArea = "Area1"
        serprop.ChartType = SeriesChartType.Bar
        serprop.Points.AddXY("Wheel Avg", propavg)

        cArea.AxisY.Minimum = basispitch * 0.8
        cArea.AxisY.Maximum = basispitch * 1.2

        Dim sline As New StripLine With {
            .IntervalOffset = basispitch * 1 - (TolClass.MeanPitchPerBladePercent / 100),
            .StripWidth = basispitch * (TolClass.MeanPitchPerBladePercent / 100) * 2,
            .BorderColor = Color.Red,
            .BorderWidth = 2,
            .ForeColor = Color.Green
        }
        cArea.AxisY.StripLines.Add(sline)
        Dim leg As Legend = Graph.Legends.Add("Legends")
        leg.Docking = Docking.Top
    End Sub
#End Region
End Module
