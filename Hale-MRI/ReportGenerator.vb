Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LibDisplayControls
Imports LibDisplayControls.DisplayControl
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports Newtonsoft.Json.Linq

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

        If hLocation.X <= PageBounds.Left OrElse
            (hLocation.X + hSize.Width) >= PageBounds.Width OrElse
            vLocation.Y <= PageBounds.Top OrElse
            (vLocation.Y + vSize.Height) >= PageBounds.Height Then
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
                Cursor.Position = curPos
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
        mDragStartPos = Cursor.Position
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
