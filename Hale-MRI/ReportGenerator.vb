Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Printing

Public Class ReportGenerator
#Region "Types and Constants"
    ' Enumerates valid edit permissions values
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

    ' Enumerates valid control resize "grab" points.
    Public Enum ResizePoints
        None = 0
        RightEdge = 1
        LeftEdge = 2
        TopEdge = 3
        BottomEdge = 4
        TopRightCorner = 5
        BottomRightCorner = 6
        BottomLeftCorner = 7
        TopLeftCorner = 8
    End Enum

    'Report control container type.
    Public Class ReportControl
        Implements ICloneable
        Public Control As Control       ' The display control. 
        Public Data As [Delegate]       ' Display control's data delegate.
        Public HasData As Boolean       ' Indicates whether the control has display data.
        Public IsMovable As Boolean     ' Indicates whether the display control is moveable, including z-order. 
        Public IsSelectable As Boolean  ' Indicates whether the display control is selectable. 
        Public IsSizeable As Boolean    ' Indicates whether the display control is sizeable. 
        Public LastPosition As Point    ' The display control's last position (for undos).
        Public LastSize As Size         ' The display control's last size (for undos).
        Public MaxSize As Size          ' The display control's maximum size (0 = no max).
        Public MinSize As Size          ' The display control's minimum size (0 = no min).
        Public Name As String           ' This object's human-readable name.

        Public Sub New(ctrl As Control, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                       Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As [Delegate] = Nothing)
            ' Constructor
            Me.Control = ctrl
            Me.Data = data
            Me.IsMovable = movable
            Me.IsSelectable = selectable
            Me.IsSizeable = sizeable
            Me.MaxSize = maxSize
            Me.MinSize = minSize
            Me.Name = ctrl.Name
        End Sub

        Public Sub New(ByVal other As ReportControl)
            ' Clone constructor.
            Me.Control = other.Control
            Me.Data = other.Data
            Me.IsMovable = other.IsMovable
            Me.IsSelectable = other.IsSelectable
            Me.IsSizeable = other.IsSizeable
            Me.LastPosition = other.LastPosition
            Me.LastSize = other.LastSize
            Me.MaxSize = other.MaxSize
            Me.MinSize = other.MinSize
            Me.Name = other.Name
        End Sub

        Public Function Clone() As Object Implements ICloneable.Clone
            Return New ReportControl(Me)
        End Function
    End Class

    ' Header item container type.
    Public Class HeaderItem
        Public Control As Control   ' The header item display control.
        Public Label As Label       ' The display control's associated Label.
        Public Name As String       ' This object's human-readable name.
        Public Sub New(ctrl As Control, lab As Label, name As String)
            Me.Control = ctrl
            Me.Label = lab
            Me.Name = name
        End Sub
    End Class

    ' ReportEvent arguments type.
    Public Class ReportEventArgs
        Public Property EventName As String
        Public Property Value As Object
        Public Sub New(eventName As String, value As Object)
            Me.EventName = eventName
            Me.Value = value
        End Sub
    End Class

    Public Delegate Sub ReportEventHandler(sender As Object, e As ReportEventArgs)  ' ReportEvent handler prototype.

    Public Event ReportEvent As ReportEventHandler              ' Custom event type for signaling clients.

    Private Const kControlEdgeSize As Integer = 5               ' Control's drag edge size in pixels.
    Private Const kControlBorderSize As Integer = 3             ' Control's selection border size in pixels.
    Private kControlBorderInflate As Size = New Size(2, 2)      ' Control's selection border offset from the control's border.
    Private kControlBorderColor As Color = Color.Blue           ' Control's selection border color
    Private kControlBorderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid  ' Control's selection border style.
    Private Const kUndoMax As Integer = 32                      ' Maximum sise of the undo stack in elements.
#End Region
#Region "Private Members"
    Private mBounds As Rectangle                                ' the bounding Rectangle within which a control can be dragged/resized.
    Private mDragStartPos As Point                              ' The starting mouse position of the drag operation.
    Private mEdit As Edits = Edits.None                         ' Bitmask indicating which edit operations are currently permissible.
    Private mGridSize As Integer = 0                            ' The report grid size, in pixels.
    Private mHorizontalLimit As Integer = 0                     ' The limit of where a control can be horizontally dragged/resized.
    Private mIsDragging As Boolean = False                      ' Indicates whether a drag operation is in progress.
    Private mIsMultiSelect As Boolean = False                   ' Indicates whether multiple selection is active.
    Private mIsResizing As Boolean = False                      ' Indicates whether a resize operation is in progress.
    Private mParentForm As Form                                 ' The parent form containing the report controls.
    Private mPasteLocation As Point                             ' The location of a right mouse click.
    Private mResizeInProgress As Boolean = False                ' Indicates that a resize action has fired either the Control_LocationChanged or Control_Resize event.
    Private mResizePoint As ResizePoints                        ' The resize cursor/type of resize operation.
    Private mUndoStack As New Stack(Of List(Of ReportControl))  ' Stores a LIFO list of report layout snapshots (objects must be Clones).
    Private mVerticalLimit As Integer = 0                       ' The limit of where a control can be vertically dragged/resized.
    Private WithEvents mReportControls As New ObservableCollection(Of ReportControl)    ' The collection of all available report controls.
    Private WithEvents mSelectedControls As New ObservableCollection(Of ReportControl)  ' The collection of currently selected controls
    Private WithEvents mVisibleControls As New ObservableCollection(Of ReportControl)   ' The collection of currently visible report controls.
#End Region
#Region "Constructors"
    Public Sub New()
        AddHandler mReportControls.CollectionChanged, AddressOf Me.ReportControls_CollectionChanged
        AddHandler mSelectedControls.CollectionChanged, AddressOf Me.SelectedControls_CollectionChanged
        AddHandler mVisibleControls.CollectionChanged, AddressOf Me.VisibleControls_CollectionChanged
    End Sub

    Public Sub New(controls As List(Of ReportControl))
        RemoveHandler mReportControls.CollectionChanged, AddressOf Me.ReportControls_CollectionChanged
        RemoveHandler mSelectedControls.CollectionChanged, AddressOf Me.SelectedControls_CollectionChanged
        RemoveHandler mVisibleControls.CollectionChanged, AddressOf Me.VisibleControls_CollectionChanged
        AddHandler mReportControls.CollectionChanged, AddressOf Me.ReportControls_CollectionChanged
        AddHandler mSelectedControls.CollectionChanged, AddressOf Me.SelectedControls_CollectionChanged
        AddHandler mVisibleControls.CollectionChanged, AddressOf Me.VisibleControls_CollectionChanged
        ReportControls = controls
    End Sub
#End Region
#Region "Public Interface"
    Public Property Bounds As Rectangle
        Get
            Return mBounds
        End Get
        Set(value As Rectangle)
            ReportControlsReposition(value)
            mBounds = value
        End Set
    End Property

    '''''''''''''''''''''''''''''''''''''''''''''''''''' 
    ' These methods are provided for clients to handle
    ' events not handled here, e.g. menu events.
    '
    Public Sub ControlHide(rc As ReportControl)
        If rc IsNot Nothing Then mVisibleControls.Remove(rc)
    End Sub

    Public Sub ControlShow(rc As ReportControl)
        If rc IsNot Nothing Then mVisibleControls.Add(rc)
    End Sub

    Public Sub DeleteSelected()
        ControlsDelete(SelectedControls)
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''' 

    Public ReadOnly Property Edit As Edits
        Get
            Return mEdit
        End Get
    End Property

    Public Property GridSize As Integer
        Get
            Return mGridSize
        End Get
        Set(value As Integer)
            If value <> mGridSize Then
                ReportControlsReposition(,, value)
                mGridSize = value
            End If
        End Set
    End Property

    Public Property HeaderItems As Dictionary(Of String, HeaderItem)

    Public Property HorizontalLimit As Integer
        Get
            Return mHorizontalLimit
        End Get
        Set(value As Integer)
            If value <> mHorizontalLimit Then
                ReportControlsReposition(, value,)
                mHorizontalLimit = value
            End If
        End Set
    End Property

    Public Property ParentForm As Form
        Get
            Return mParentForm
        End Get
        Set(value As Form)
            ParentFormSet(value)
        End Set
    End Property

    Public Property ReportControls As List(Of ReportControl)
        Get
            Return mReportControls.ToList()
        End Get
        Set(value As List(Of ReportControl))
            ControlsRemoveFrom(ReportControls, mReportControls)
            If value IsNot Nothing Then ControlsAddInTo(ReportControlsSort(value), mReportControls)
        End Set
    End Property

    Public ReadOnly Property PasteLocation As Point
        Get
            Return mPasteLocation
        End Get
    End Property

    Public Sub ReportGenerate(sender As Object, e As PrintPageEventArgs)
        ' Generates the report by drawing each control onto the print page.
        Dim yOffset As Integer = 0
        For Each ctrl As Control In ReportControlsSort(ReportControls).Select(Function(rc) rc.Control)
            If Not ctrl.Visible Then Continue For
            ' Draw each control at its specified location.
            Dim bmp As New Bitmap(ctrl.Width, ctrl.Height)
            ctrl.DrawToBitmap(bmp, New Rectangle(0, 0, ctrl.Width, ctrl.Height))
            e.Graphics.DrawImage(bmp, New Point(ctrl.Left, ctrl.Top + yOffset))
            bmp.Dispose()
        Next
    End Sub

    Public Property SelectedControls As List(Of ReportControl)
        Get
            Return mSelectedControls.ToList()
        End Get
        Set(value As List(Of ReportControl))
            ' In order to fire the CollectionChanged event properly, we need to remove the old
            ' items and add the new items individually.
            ControlsRemoveFrom(SelectedControls, mSelectedControls)
            If value IsNot Nothing Then ControlsAddInTo(value, mSelectedControls)
        End Set
    End Property

    Public Property VerticalLimit As Integer
        Get
            Return mVerticalLimit
        End Get
        Set(value As Integer)
            ReportControlsReposition(value,,)
            If value <> mVerticalLimit Then
                mVerticalLimit = value
            End If
        End Set
    End Property

    Public Property VisibleControls As List(Of ReportControl)
        Get
            Return mVisibleControls.ToList()
        End Get
        Set(value As List(Of ReportControl))
            ' In order to fire the CollectionChanged event properly, we need to remove the old
            ' items and add the new items individually.
            ControlsRemoveFrom(VisibleControls, mVisibleControls)
            If value IsNot Nothing Then ControlsAddInTo(value, mVisibleControls)
            LayoutSet(ReportControls)
        End Set
    End Property

#End Region
#Region "Private Interface"
    Private Function CtrlToReportControl(ctrl As Control, collection As ObservableCollection(Of ReportControl)) As ReportControl
        ' Returns a ReportControl having the same name as the given Control from an ObservableCollection.
        Return collection.FirstOrDefault(Function(c) c.Name = ctrl.Name)
    End Function

    Private Sub ControlDrawBorder(ctrl As Control, e As PaintEventArgs)
        ' Draws a control's border based on whether it is currently selected.
        If IsSelected(ctrl) Then
            ' Draw selection rectangle
            Dim rect As Rectangle = ctrl.ClientRectangle
            rect.Inflate(kControlBorderInflate.Width, kControlBorderInflate.Height)
            ControlPaint.DrawBorder(e.Graphics, rect,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle)
        Else
            ' Draw normal border
            ControlPaint.DrawBorder(e.Graphics, ctrl.ClientRectangle, ctrl.BackColor, ButtonBorderStyle.None)
        End If
    End Sub

    Private Sub ControlsAddInTo(controls As List(Of ReportControl), ByRef into As List(Of ReportControl), Optional ByVal clone As Boolean = False)
        ' Adds a list of ReportControls to a List, optionally adding their clones.
        If clone Then
            For Each rc As ReportControl In controls
                into.Add(CType(rc.Clone, ReportControl))
            Next
        Else
            into = New List(Of ReportControl)(controls)
        End If
    End Sub

    Private Sub ControlsAddInTo(controls As List(Of ReportControl), ByRef into As ObservableCollection(Of ReportControl), Optional ByVal clone As Boolean = False)
        ' Adds a list of ReportControls to an ObservableCollection, optionally adding their clones.
        For Each rc As ReportControl In controls
            If clone Then
                into.Add(CType(rc.Clone, ReportControl))
            Else
                into.Add(rc)
            End If
        Next
    End Sub

    Private Sub ControlsBringToFront(controls As List(Of ReportControl))
        ' Brings the currently selected ReportControls to the front of the Z-Order.
        For Each rc As ReportControl In controls
            If rc.IsMovable Then rc.Control.BringToFront()
        Next
    End Sub

    Private Sub ControlsCut(controls As List(Of ReportControl))
        ' Cuts the currently selected ReportControls from the report.
        UndoSave()
        CutControls = SelectedControls
        ControlsRemoveFrom(SelectedControls, mVisibleControls)
        EditPermissionsSet()
    End Sub

    Private Sub ControlsDelete(controls As List(Of ReportControl))
        ' Deletes the currently selected ReportControls from the report.
        UndoSave()
        ControlsRemoveFrom(SelectedControls, mVisibleControls)
        EditPermissionsSet()
    End Sub

    Private Sub ControlsPaste(controls As List(Of ReportControl))
        ' Pastes any CutControls back into the report.
        If CutControls IsNot Nothing Then
            Dim firstControl As ReportControl = controls.FirstOrDefault()
            Dim deltaX As Integer = mPasteLocation.X - firstControl.LastPosition.X
            Dim deltaY As Integer = mPasteLocation.Y - firstControl.LastPosition.Y
            UndoSave()
            For Each rc As ReportControl In controls
                If rc.IsMovable Then
                    ' Enforce horizontal and vertical limits.
                    Dim loc As New Point(rc.LastPosition.X + deltaX, rc.LastPosition.Y + deltaY)
                    If HorizontalLimit > 0 Then
                        If loc.X < HorizontalLimit Then loc.X = HorizontalLimit
                        If (loc.X + rc.Control.Width) > (mParentForm.ClientRectangle.Right - HorizontalLimit) Then
                            loc.X = mParentForm.ClientRectangle.Right - HorizontalLimit - rc.Control.Width
                        End If
                    End If
                    If VerticalLimit > 0 Then
                        If loc.Y < VerticalLimit Then loc.Y = VerticalLimit
                        If (loc.Y + rc.Control.Height) > (mParentForm.ClientRectangle.Bottom - GridSize) Then
                            loc.Y = mParentForm.ClientRectangle.Bottom - GridSize - rc.Control.Height
                        End If
                    End If
                    rc.Control.Location = loc
                End If
                mVisibleControls.Add(rc)
            Next
            CutControls = Nothing   ' CutControls can only be pasted once.
            EditPermissionsSet()
        End If
    End Sub

    Private Sub ControlsSelectAll(controls As List(Of ReportControl))
        ' Selects all currently VisibleControls.
        For Each rc As ReportControl In controls
            If Not mSelectedControls.Contains(rc) Then
                mSelectedControls.Add(rc)
            End If
        Next
    End Sub

    Private Sub ControlsSendToBack(controls As List(Of ReportControl))
        ' Sends the currently selected ReportControls to the back of the Z-Order.
        For Each rc As ReportControl In controls
            If rc.IsMovable Then rc.Control.SendToBack()
        Next
    End Sub

    Private Sub ControlsUndo()
        ' Undoes the last layout changed operation (e.g. Cut, Paste, Move, etc.)
        If mUndoStack.Count > 0 Then
            Dim redo As List(Of ReportControl) = mUndoStack.Pop()   ' Pop the previous layout from the UndoStack.
            ControlsRemoveFrom(VisibleControls, mVisibleControls)   ' Hide all currently visible controls
            For Each rc As ReportControl In redo
                rc.Control.Location = rc.LastPosition   ' Reposition and resize each control to it's previous values.
                rc.Control.Size = rc.LastSize
            Next
            ControlsAddInTo(redo, mVisibleControls)     ' Show all controls in the previous layout.
        End If
    End Sub

    Private Sub ControlsRemoveFrom(controls As List(Of ReportControl), ByRef from As ObservableCollection(Of ReportControl))
        ' Removes a list of ReportControls from an ObservableCollection
        For Each rc As ReportControl In controls
            Dim items As List(Of ReportControl) = from.Where(Function(c) c.Name = rc.Name).ToList()
            For Each item As ReportControl In items
                from.Remove(item)
            Next
        Next
    End Sub

    Private Sub ControlToggleSelect(ctrl As Control, e As MouseEventArgs)
        ' Toggles the selection state of a ReportControl.
        Dim rc As ReportControl = CtrlToReportControl(ctrl, mReportControls)
        If rc.IsSelectable Then
            If Not IsSelected(rc) Then
                If Not mIsMultiSelect Then
                    ControlsRemoveFrom(SelectedControls, mSelectedControls)
                End If
                mSelectedControls.Add(rc)
            Else
                If mIsMultiSelect Then
                    mSelectedControls.Remove(rc)
                End If
            End If
        End If
        ' Set/reset the mIsDragging and mIsResizing flags.
        If mSelectedControls.Count = 0 Then
            mIsDragging = False
            mIsResizing = False
        Else
            If ctrl.Cursor = Cursors.Default Then
                DragStart(ctrl, e)
            Else
                ResizeStart(ctrl, e)
            End If
        End If
    End Sub

    Public Sub ControlCursorChange(ctrl As Control, e As MouseEventArgs)
        ' Change the cursor based on the mouse position for resizing.
        If IsSelected(ctrl) Then
            Dim rc As ReportControl = CtrlToReportControl(ctrl, mVisibleControls)
            If rc.IsSizeable Then
                Dim rect As Rectangle = ctrl.ClientRectangle
                If e.X >= rect.Right - kControlEdgeSize AndAlso e.Y >= rect.Bottom - kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNWSE ' Bottom-right corner
                    mResizePoint = ResizePoints.BottomRightCorner
                ElseIf e.X <= rect.Left + kControlEdgeSize AndAlso e.Y >= rect.Bottom - kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNESW ' Bottom-left corner
                    mResizePoint = ResizePoints.BottomLeftCorner
                ElseIf e.X >= rect.Right - kControlEdgeSize AndAlso e.Y <= rect.Top + kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNESW ' Top-right corner
                    mResizePoint = ResizePoints.TopRightCorner
                ElseIf e.X <= rect.Left + kControlEdgeSize AndAlso e.Y <= rect.Top + kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNWSE ' Top-left corner
                    mResizePoint = ResizePoints.TopLeftCorner
                ElseIf e.X >= rect.Right - kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeWE ' Right edge
                    mResizePoint = ResizePoints.RightEdge
                ElseIf e.X <= rect.Left + kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeWE ' Left edge
                    mResizePoint = ResizePoints.LeftEdge
                ElseIf e.Y >= rect.Bottom - kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNS ' Bottom edge
                    mResizePoint = ResizePoints.BottomEdge
                ElseIf e.Y <= rect.Top + kControlEdgeSize Then
                    ctrl.Cursor = Cursors.SizeNS ' Top edge
                    mResizePoint = ResizePoints.TopEdge
                Else
                    ctrl.Cursor = Cursors.Default ' Default cursor
                    mResizePoint = ResizePoints.None
                End If
            Else
                ctrl.Cursor = Cursors.Default
            End If
        Else
            ctrl.Cursor = Cursors.Default
        End If
    End Sub

    Private Property CutControls As List(Of ReportControl)  ' The current list of controls that can be pasted.

    Private Sub DragEnd(ctrl As Control)
        ' DragStart() pushes an element onto the UndoStack.
        ' LayoutCheck() pops it off if nothing changed as the
        ' undo would be redundant.
        LayoutCheck()
        mIsDragging = False
    End Sub

    Private Sub DragMove(ctrl As Control, e As MouseEventArgs)
        For Each sc In mSelectedControls
            If sc.IsMovable Then
                Dim cursorPos As Point = e.Location
                Dim deltaX As Integer = cursorPos.X - mDragStartPos.X
                Dim deltaY As Integer = cursorPos.Y - mDragStartPos.Y
                Dim newX As Integer = sc.Control.Left + deltaX
                Dim newY As Integer = sc.Control.Top + deltaY
                ' Apply grid snapping if GridSize is set
                If GridSize > 0 Then
                    newX = Math.Round(newX / GridSize) * GridSize
                    newY = Math.Round(newY / GridSize) * GridSize
                End If
                ' Enforce horizontal and vertical limits if set
                If HorizontalLimit > 0 Then
                    newX = Math.Max(HorizontalLimit, newX)
                    newX = Math.Min(newX, mParentForm.ClientRectangle.Right - sc.Control.Width - HorizontalLimit)
                End If
                If VerticalLimit > 0 Then
                    newY = Math.Max(VerticalLimit, newY)
                    newY = Math.Min(newY, mParentForm.ClientRectangle.Bottom - sc.Control.Height - GridSize)
                End If
                ' Position the control at the new location.
                sc.Control.Location = New Point(newX, newY)
            End If
        Next
    End Sub

    Private Sub DragStart(ctrl As Control, e As MouseEventArgs)
        UndoSave()  ' This method is called on Mouse_Down, before any Mouse_Move occurs, but we save the current layout here for convenience.
        mDragStartPos = e.Location
        mIsDragging = True
    End Sub

    Private Sub EditPermissionsSet(Optional e As NotifyCollectionChangedEventArgs = Nothing)
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

    Private Function IsSelected(ctrl As Control) As Boolean
        ' Returns TRUE if the given display control's containing ReportControl
        ' is selected, else returns FALSE.
        Return SelectedControls IsNot Nothing AndAlso SelectedControls.Any(Function(sc) sc.Name = ctrl.Name)
    End Function

    Private Function IsSelected(rc As ReportControl) As Boolean
        ' Returns TRUE if the given ReportControl
        ' is selected, else returns FALSE.
        Return SelectedControls IsNot Nothing AndAlso SelectedControls.Any(Function(sc) sc.Name = rc.Name)
    End Function

    Private Sub LayoutCheck()
        ' Checks the current to the previous layout and pop's 
        ' the last element from the UndoStack if they're the same.
        Dim i As Integer
        For i = 0 To SelectedControls.Count - 1
            If SelectedControls(i).LastPosition <> SelectedControls(i).Control.Location Then
                LayoutSet(SelectedControls, True)
                GoTo Done
            End If
        Next
        Dim unused As List(Of ReportControl) = mUndoStack.Pop

Done:
        EditPermissionsSet()
    End Sub

    Private Sub LayoutSet(controls As List(Of ReportControl), Optional ByVal lof As Boolean = False)
        ' Sets the ReportControls' LastPosition and LastSize
        ' to their current Location and Size.
        For Each rc As ReportControl In controls
            rc.LastPosition = rc.Control.Location
            rc.LastSize = rc.Control.Size
        Next
    End Sub

    Private Sub ParentFormSet(frm As Form)
        ' Detach event handlers from the old parent form, if any.
        If mParentForm IsNot Nothing Then
            RemoveHandler mParentForm.KeyUp, AddressOf Me.Form_KeyUp
            RemoveHandler mParentForm.KeyDown, AddressOf Me.Form_KeyDown
            RemoveHandler mParentForm.MouseDown, AddressOf Me.Form_MouseDown
        End If
        ' Attach event handlers to the new parent form, if any.
        If frm IsNot Nothing Then
            AddHandler frm.KeyDown, AddressOf Me.Form_KeyDown
            AddHandler frm.KeyUp, AddressOf Me.Form_KeyUp
            AddHandler frm.MouseDown, AddressOf Me.Form_MouseDown
        End If
        mParentForm = frm
    End Sub

    Private Sub ReportControlAdd(rc As ReportControl)
        ' Attach appropriate event handlers.
        If rc.IsSelectable Then
            AddHandler rc.Control.MouseDown, AddressOf Me.Control_MouseDown
            AddHandler rc.Control.MouseUp, AddressOf Me.Control_MouseUp
            AddHandler rc.Control.Paint, AddressOf Me.Control_Paint
        End If
        If rc.IsMovable Or rc.IsSizeable Then
            AddHandler rc.Control.LocationChanged, AddressOf Me.Control_LocationChanged
            AddHandler rc.Control.MouseMove, AddressOf Me.Control_MouseMove
            AddHandler rc.Control.Resize, AddressOf Me.Control_Resize
        End If
    End Sub

    Private Sub ReportControlRemove(rc As ReportControl)
        ' Detach event handlers.
        If rc.IsSelectable Then
            RemoveHandler rc.Control.MouseDown, AddressOf Me.Control_MouseDown
            RemoveHandler rc.Control.MouseUp, AddressOf Me.Control_MouseUp
            RemoveHandler rc.Control.Paint, AddressOf Me.Control_Paint
        End If
        If rc.IsMovable Or rc.IsSizeable Then
            RemoveHandler rc.Control.LocationChanged, AddressOf Me.Control_LocationChanged
            RemoveHandler rc.Control.MouseMove, AddressOf Me.Control_MouseMove
            RemoveHandler rc.Control.Resize, AddressOf Me.Control_Resize
        End If
    End Sub

    Private Sub ReportControlsReposition(rect As Rectangle)

    End Sub
    Private Sub ReportControlsReposition(Optional vLimit As Integer = -1, Optional hLimit As Integer = -1, Optional gridSz As Integer = -1)
        If vLimit > -1 AndAlso vLimit > mVerticalLimit Then

        End If
        If hLimit > -1 AndAlso vLimit > mVerticalLimit Then

        End If
        If gridSz > -1 AndAlso gridSz > mGridSize Then

        End If
    End Sub

    Private Function ReportControlsSort(controls As List(Of ReportControl)) As List(Of ReportControl)
        'Sorts by Y and then X (lexicographical sort). 
        Return controls.OrderBy(Function(c) c.Control.Location.Y).ThenBy(Function(c) c.Control.Location.X).ToList()
    End Function

    Private Sub ResizeEnd(ctrl As Control)
        ' ResizeStart() pushes an element onto the UndoStack.
        ' LayoutCheck() pops it off if nothing changed as the
        ' undo would be redundant.
        LayoutCheck()
        mIsResizing = False
    End Sub

    Private Sub ResizeMove(ctrl As Control, e As MouseEventArgs)
        ' Compute the offset of the current mouse position from the drag start position.
        Dim cursorPos As Point = ctrl.PointToScreen(e.Location)
        Dim deltaX As Integer = cursorPos.X - mDragStartPos.X
        Dim deltaY As Integer = cursorPos.Y - mDragStartPos.Y
        For Each sc In mSelectedControls
            If sc.IsSizeable Then
                ' Apply grid snapping if GridSize is set
                If GridSize > 0 Then
                    deltaX = Math.Round(deltaX / GridSize) * GridSize
                    deltaY = Math.Round(deltaY / GridSize) * GridSize
                End If
                If deltaX = 0 And deltaY = 0 Then Exit Sub
                Dim newSize As Size
                Dim newLocation As Point
                ' Stretch the control according to the edge grabbed and the mouse move direction.
                Select Case mResizePoint
                    Case ResizePoints.RightEdge
                        newSize = New Size(sc.LastSize.Width + deltaX, sc.Control.Height)
                    Case ResizePoints.LeftEdge
                        newLocation = New Point(sc.LastPosition.X + deltaX, sc.Control.Top)
                        newSize = New Size(sc.LastSize.Width - deltaX, sc.Control.Height)
                    Case ResizePoints.TopEdge
                        newLocation = New Point(sc.Control.Left, sc.LastPosition.Y + deltaY)
                        newSize = New Size(sc.Control.Width, sc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomEdge
                        newSize = New Size(sc.Control.Width, sc.LastSize.Height + deltaY)
                    Case ResizePoints.TopRightCorner
                        newLocation = New Point(sc.Control.Left, sc.LastPosition.Y + deltaY)
                        newSize = New Size(sc.LastSize.Width + deltaX, sc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomRightCorner
                        newSize = New Size(sc.LastSize.Width + deltaX, sc.LastSize.Height + deltaY)
                    Case ResizePoints.TopLeftCorner
                        newLocation = New Point(sc.LastPosition.X + deltaX, sc.LastPosition.Y + deltaY)
                        newSize = New Size(sc.LastSize.Width - deltaX, sc.LastSize.Height - deltaY)
                    Case ResizePoints.BottomLeftCorner
                        newSize = New Size(sc.LastSize.Width - deltaX, sc.LastSize.Height + deltaY)
                        newLocation = New Point(sc.LastPosition.X + deltaX, sc.Control.Top)
                    Case Else
                        Exit Sub
                End Select
                ' Enforce horizontal and vertical limits if set.
                If HorizontalLimit > 0 Then
                    Dim locationLimit As New Point(If(newLocation <> Point.Empty, newLocation, sc.Control.Location))
                    Dim sizeLimit As New Size(If(newSize <> Size.Empty, newSize, sc.Control.Size))
                    If (locationLimit.X < HorizontalLimit Or (locationLimit.X + sizeLimit.Width) > (mParentForm.ClientRectangle.Right - HorizontalLimit)) Then Exit Sub
                End If
                If VerticalLimit > 0 Then
                    Dim locationLimit As New Point(If(newLocation <> Point.Empty, newLocation, sc.Control.Location))
                    Dim sizeLimit As New Size(If(newSize <> Size.Empty, newSize, sc.Control.Size))
                    If (locationLimit.Y < VerticalLimit Or (locationLimit.Y + sizeLimit.Height) > (mParentForm.ClientRectangle.Bottom - GridSize)) Then Exit Sub
                End If
                ' Re-size/locate the control accordingly.
                If newSize <> Size.Empty Then
                    If sc.MinSize <> Size.Empty Then
                        If (newSize.Width < sc.MinSize.Width Or newSize.Height < sc.MinSize.Height) Then Exit Sub
                    End If
                    If sc.MaxSize <> Size.Empty Then
                        If (newSize.Width > sc.MaxSize.Width Or newSize.Height > sc.MaxSize.Height) Then Exit Sub
                    End If
                    sc.Control.Size = newSize
                End If
                If newLocation <> Point.Empty Then
                    sc.Control.Location = newLocation
                End If
            End If
        Next
    End Sub

    Private Sub ResizeStart(ctrl As Control, e As MouseEventArgs)
        UndoSave()  ' This method is called on Mouse_Down, before any Mouse_Move occurs, but we save the current layout here for convenience.
        mDragStartPos = ctrl.PointToScreen(e.Location)
        mIsResizing = True
    End Sub

    Private Sub UndoSave()
        ' Pushes a snapshot of the current report layout onto the undo stack.
        If mUndoStack.Count < kUndoMax Then
            Dim undo As New List(Of ReportControl)
            ControlsAddInTo(VisibleControls, undo, True)
            For Each rc As ReportControl In undo
                rc.LastPosition = rc.Control.Location
                rc.LastSize = rc.Control.Size
            Next
            mUndoStack.Push(undo)
        End If
    End Sub

#End Region
#Region "Event Handlers"
    Public Sub Control_LocationChanged(sender As Object, e As EventArgs)
        If mIsResizing Then
            mResizeInProgress = True    ' Prevents cascaded calls to Control_MouseMove when during a Resize operation.
        End If
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Right
            Case MouseButtons.Left
                ControlToggleSelect(CType(sender, Control), e)
        End Select
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If mResizeInProgress Then
            mResizeInProgress = False   ' Once the Resize is handled, we can enable the MouseDown event.
        Else
            Dim ctrl As Control = CType(sender, Control)
            If mIsDragging Then
                DragMove(ctrl, e)
            ElseIf mIsResizing Then
                ResizeMove(ctrl, e)
            Else
                ControlCursorChange(ctrl, e)
            End If
        End If
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        Dim ctrl As Control = CType(sender, Control)
        If mIsDragging Then
            DragEnd(ctrl)
        ElseIf mIsResizing Then
            ResizeEnd(ctrl)
        End If
    End Sub

    Public Sub Control_Paint(sender As Object, e As PaintEventArgs)
        ControlDrawBorder(CType(sender, Control), e)
    End Sub

    Private Sub Control_Resize(sender As Object, e As EventArgs)
        mResizeInProgress = True    ' Prevents cascaded calls to Control_MouseMove when during a Resize operation.
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A
                    ControlsSelectAll(VisibleControls)
                Case Keys.B
                    ControlsSendToBack(SelectedControls)
                Case Keys.F
                    ControlsBringToFront(SelectedControls)
                Case Keys.V
                    ControlsPaste(CutControls)
                Case Keys.X
                    ControlsCut(SelectedControls)
                Case Keys.Z
                    ControlsUndo()
                Case Keys.ControlKey
                    mIsMultiSelect = True
                Case Else
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            ControlsDelete(SelectedControls)
        End If
        e.Handled = True
    End Sub

    Private Sub Form_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            mIsMultiSelect = False
        End If
        e.Handled = True
    End Sub

    Public Sub Form_MouseDown(sender As Object, e As MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Right
                mPasteLocation = e.Location
            Case MouseButtons.Left
                ControlsRemoveFrom(SelectedControls, mSelectedControls)
        End Select
    End Sub

    Private Sub ReportControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        ' Handle additions and removals of ReportControls in the collection.
        ' This hooks up our event handlers. The ReportControls collection
        ' should only be set once by the client.
        Select Case e.Action
            Case NotifyCollectionChangedAction.Add
                If e.NewItems IsNot Nothing Then
                    For Each rc As ReportControl In e.NewItems
                        ReportControlAdd(rc)
                    Next
                End If
            Case NotifyCollectionChangedAction.Remove
                If e.OldItems IsNot Nothing Then
                    For Each rc As ReportControl In e.OldItems
                        ReportControlRemove(rc)
                    Next
                End If
            Case NotifyCollectionChangedAction.Reset, NotifyCollectionChangedAction.Replace
                If e.OldItems IsNot Nothing Then
                    For Each rc As ReportControl In e.OldItems
                        ReportControlRemove(rc)
                    Next
                End If
                If e.NewItems IsNot Nothing Then
                    For Each rc As ReportControl In e.NewItems
                        ReportControlAdd(rc)
                    Next
                End If
        End Select
    End Sub

    Private Sub SelectedControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        ' We need to call Control.Refresh() for each control so that the Repaint() event fires.
        If e.NewItems IsNot Nothing Then
            For Each rc As ReportControl In e.NewItems
                rc.Control.Refresh()
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each rc As ReportControl In e.OldItems
                rc.Control.Refresh()
            Next
        End If
        EditPermissionsSet()
    End Sub

    Private Sub VisibleControls_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        ' Changes the visibility of ReportControls.
        If e.NewItems IsNot Nothing Then
            For Each rc As ReportControl In e.NewItems
                rc.Control.Visible = True       ' Added controls are visible. 
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each rc As ReportControl In e.OldItems
                rc.Control.Visible = False      ' Removed controls are hidden ...
                mSelectedControls.Remove(rc)    ' ... and deselected.
            Next
        End If
        EditPermissionsSet(e)
    End Sub
#End Region
End Class
