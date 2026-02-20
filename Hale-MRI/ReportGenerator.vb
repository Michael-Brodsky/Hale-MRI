Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Printing
Imports System.Net.Security
Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports Newtonsoft.Json.Linq
Imports Windows.Win32.UI
Imports LibDisplayControls.MRIMath

''' <summary>
''' Class that manages report visual elements 
''' and editing.
''' </summary>
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

        Public ReadOnly Property ZOrder As Integer
            Get
                Return If(Me.Control IsNot Nothing, Me.Control.Parent.Controls.GetChildIndex(Me.Control), kNoCurrentSelection)
            End Get
        End Property

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
    Private Const kUndoMax As Integer = 32                      ' Maximum size of the undo stack in elements.
#End Region
#Region "Private Members"
    Private mBounds As Rectangle                                ' the bounding Rectangle within which a control can be dragged/resized.
    Private mDragStartPos As Point                              ' The starting mouse position of the drag operation.
    Private mEdit As Edits = Edits.None                         ' Bitmask indicating which edit operations are currently permissible.
    Private mGridSize As Integer = 0                            ' The report grid size, in pixels.
    'Private mHorizontalLimit As Integer = 0                     ' The limit of where a control can be horizontally dragged/resized.
    Private mIsDragging As Boolean = False                      ' Indicates whether a drag operation is in progress.
    Private mIsMultiSelect As Boolean = False                   ' Indicates whether multiple selection is active.
    Private mIsResizing As Boolean = False                      ' Indicates whether a resize operation is in progress.
    Private mParentForm As Form                                 ' The parent form containing the report controls.
    Private mPasteLocation As Point                             ' The location of a right mouse click.
    Private mResizeInProgress As Boolean = False                ' Indicates that a resize action has fired either the Control_LocationChanged or Control_Resize event.
    Private mResizePoint As ResizePoints                        ' The resize cursor/type of resize operation.
    Private mUndoStack As New Stack(Of List(Of ReportControl))  ' Stores a LIFO list of report layout snapshots (objects must be Clones).
    ' Private mVerticalLimit As Integer = 0                       ' The limit of where a control can be vertically dragged/resized.
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
            If value <> mBounds Then
                ReportControlsReposition(value)
                mBounds = value
            End If
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
        If rc IsNot Nothing AndAlso Not mVisibleControls.Any(Function(vc) vc.Name = rc.Name) Then mVisibleControls.Add(rc)
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
                ReportControlsReposition(, value)
                mGridSize = value
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
                    If loc.X < Bounds.X Then
                        loc.X = Bounds.X
                    ElseIf (loc.X + rc.Control.Width) > Bounds.Width Then
                        loc.X = Bounds.Width - rc.Control.Width
                    End If
                    If loc.Y < Bounds.Y Then
                        loc.X = Bounds.Y
                    ElseIf (loc.Y + rc.Control.Height) > Bounds.Height Then
                        loc.Y = Bounds.Height - rc.Control.Height
                    End If
                    ' Relocate the control to the paste position.
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
        ' Drag selected controls to a new location.
        Dim newLocations As New List(Of Point)()

        ' Get the mouse position offset from the drag start location.
        Dim cursorPos As Point = e.Location
        Dim deltaX As Integer = cursorPos.X - mDragStartPos.X
        Dim deltaY As Integer = cursorPos.Y - mDragStartPos.Y
        ' Apply grid snapping if GridSize is set
        If GridSize > 0 Then
            deltaX = Math.Round(deltaX / GridSize) * GridSize
            deltaY = Math.Round(deltaY / GridSize) * GridSize
        End If
        If deltaX = 0 And deltaY = 0 Then Exit Sub

        For Each sc In SelectedControls
            Dim location As New Point()
            If sc.IsMovable Then
                Dim newX As Integer = sc.Control.Left + deltaX
                Dim newY As Integer = sc.Control.Top + deltaY
                ' Enforce Bounds limits. Stop moving when any selected controls goes out of bounds.
                If newX < Bounds.X OrElse
                newX > (Bounds.Width - sc.Control.Width) OrElse
                newY < Bounds.Y OrElse
                newY > (Bounds.Height - sc.Control.Height) Then Exit Sub
                location.X = newX
                location.Y = newY
            End If
            newLocations.Add(location)
        Next

        ' Relocate selected controls to their new positions.
        Dim i As Integer
        For Each sc In SelectedControls
            If newLocations(i) <> Point.Empty Then
                sc.Control.Location = newLocations(i)
            End If
            i += 1
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
            If SelectedControls(i).LastPosition <> SelectedControls(i).Control.Location OrElse SelectedControls(i).LastPosition <> SelectedControls(i).Control.Location Then
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

    Private Sub ReportControlsReposition(Optional boundsRect As Rectangle = Nothing, Optional gridSz? As Integer = Nothing)
        For Each rc As ReportControl In VisibleControls
            If boundsRect <> Rectangle.Empty Then
                Dim loc As Rectangle = rc.Control.Bounds
                If loc.X < boundsRect.X Then
                    loc.X = boundsRect.X
                ElseIf (loc.X + loc.Width) > boundsRect.Width Then
                    loc.X = boundsRect.Width - loc.Width
                End If
                If loc.Y < boundsRect.Y Then
                    loc.Y = boundsRect.Y
                ElseIf (loc.Y + loc.Height) > boundsRect.Height Then
                    loc.Y = boundsRect.Height - loc.Height
                End If
                rc.Control.Location = loc.Location
            End If
            If gridSz IsNot Nothing Then

            End If
        Next
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
        Dim newBounds As New List(Of Rectangle)
        ' Compute the offset of the current mouse position from the drag start position.
        Dim cursorPos As Point = ctrl.PointToScreen(e.Location)
        Dim deltaX As Integer = cursorPos.X - mDragStartPos.X
        Dim deltaY As Integer = cursorPos.Y - mDragStartPos.Y

        ' Apply grid snapping if GridSize is set
        If GridSize > 0 Then
            deltaX = Math.Round(deltaX / GridSize) * GridSize
            deltaY = Math.Round(deltaY / GridSize) * GridSize
        End If
        If deltaX = 0 And deltaY = 0 Then Exit Sub

        For Each sc In mSelectedControls
            Dim bound As New Rectangle()
            If sc.IsSizeable Then
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

                ' Enforce Bounds ...
                Dim hLocation As New Point(If(newLocation <> Point.Empty, newLocation, sc.Control.Location))
                Dim hSize As New Size(If(newSize <> Size.Empty, newSize, sc.Control.Size))
                Dim vLocation As New Point(If(newLocation <> Point.Empty, newLocation, sc.Control.Location))
                Dim vSize As New Size(If(newSize <> Size.Empty, newSize, sc.Control.Size))
                If hLocation.X < Bounds.X OrElse
                (hLocation.X + hSize.Width) > Bounds.Width OrElse
                vLocation.Y < Bounds.Y OrElse
                (vLocation.Y + vSize.Height) > Bounds.Height Then Exit Sub

                ' ...and Size limits.
                If sc.MaxSize <> Size.Empty AndAlso
                (newSize.Width > sc.MaxSize.Width Or newSize.Height > sc.MaxSize.Height) Then Exit Sub

                ' Save the new control bounds.
                bound.Location = newLocation
                bound.Size = newSize
            End If
            newBounds.Add(bound)
        Next

        ' Resize/relocate controls to their new bounds.
        Dim i As Integer
        For Each sc In SelectedControls
            If newBounds(i).Location <> Point.Empty Then
                sc.Control.Location = newBounds(i).Location
            End If
            If newBounds(i).Size <> Size.Empty Then
                sc.Control.Size = newBounds(i).Size
            End If
            i += 1
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
