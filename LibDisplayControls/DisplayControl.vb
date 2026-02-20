Imports System.Collections.ObjectModel

Partial Public Class DisplayControl
    Inherits UserControl
    Implements ICloneable

#Region "Types and Constants"
    ''' <summary>
    ''' Enumerates valid control resize "grab" points.
    ''' </summary>
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

    Public Delegate Sub MouseEventHandler(sender As DisplayControl, e As MouseEventArgs)
    Public Delegate Sub KeyEventHandler(sender As DisplayControl, e As KeyEventArgs)
    Public Event ControlEvent As ControlEventHandler
    Public Event MouseDownEvent As MouseEventHandler
    Public Event MouseMoveEvent As MouseEventHandler
    Public Event MouseUpEvent As MouseEventHandler
    Public Event KeyEvent As KeyEventHandler

    Private Const kControlEdgeSizeMin As Integer = 3                            ' Control's selection border size in pixels.
    Private Const kControlBorderSize As Integer = 3                             ' Control's selection border size in pixels.
    Private kControlBorderInflate As Size = New Size(2, 2)                      ' Control's selection border offset from the control's border.
    Private kControlBorderColor As Color = Color.Blue                           ' Control's selection border color
    Private kControlBorderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid  ' Control's selection border style.
#End Region
#Region "Private Members"
    Private mData As Object = Nothing                                           ' The control's data source.
    Private mDragOffset As Point
    Private mEdgeSize As Integer = kControlEdgeSizeMin                          ' Control's selection border size in pixels.
    Private mSelected As Boolean = False                                        ' Indicates whether the control is selected.
#End Region
#Region "Constructors"
    ''' <summary>
    ''' Creates a new DisplayControl object.
    ''' </summary>
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ''' <summary>
    ''' Creates a new DisplayControl object with specified properties.
    ''' </summary           
    ''' <param name="ctrl"></param>
    ''' <param name="selectable"></param>
    ''' <param name="sizeable"></param>
    ''' <param name="movable"></param>
    ''' <param name="maxSize"></param>
    ''' <param name="minSize"></param>
    ''' <param name="data"></param>
    Public Sub New(name As String, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                   Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As Object = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        Me.Data = data
        Me.IsSelectable = selectable
        Me.IsSizeable = sizeable
        Me.IsMovable = movable
        Me.MaxSize = maxSize
        Me.MinSize = maxSize
        Me.Name = name
    End Sub

    ''' <summary>
    ''' Creates a new DisplayControl object by copying properties from another instance.
    ''' </summary>
    ''' <param name="other">The DisplayControl instance to copy from.</param>
    Public Sub New(ByVal other As DisplayControl)
        ' This call is required by the designer.
        InitializeComponent()

        Me.Data = other.Data
        Me.EdgeSize = other.EdgeSize
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
        Return New DisplayControl(Me)
    End Function

    Public Function Copy(other As DisplayControl) As DisplayControl
        Me.Data = other.Data
        Me.EdgeSize = other.EdgeSize
        Me.IsMovable = other.IsMovable
        Me.IsSelectable = other.IsSelectable
        Me.IsSizeable = other.IsSizeable
        Me.LastPosition = other.LastPosition
        Me.LastSize = other.LastSize
        Me.MaxSize = other.MaxSize
        Me.MinSize = other.MinSize
        Me.Location = Me.LastPosition
        Me.Size = Me.LastSize
        Return Me
    End Function

    Public ReadOnly Property DragOffset As Point
        Get
            Return mDragOffset
        End Get
    End Property
#End Region
#Region "Public Interface"
    Public Shared Sub ControlsAddInTo(controls As ObservableCollection(Of DisplayControl), ByRef into As ObservableCollection(Of DisplayControl), Optional ByVal clone As Boolean = False)
        ' Adds an ObservableCollection of DisplayControl to another ObservableCollection, optionally adding their clones.
        For Each dc As DisplayControl In controls
            If clone Then
                into.Add(CType(dc.Clone, DisplayControl))
            Else
                into.Add(dc)
            End If
        Next
    End Sub

    Public Shared Sub ControlsAddInTo(controls As List(Of DisplayControl), ByRef into As ObservableCollection(Of DisplayControl), Optional ByVal clone As Boolean = False)
        ' Adds a list of DisplayControl to an ObservableCollection, optionally adding their clones.
        For Each dc As DisplayControl In controls
            If clone Then
                into.Add(CType(dc.Clone, DisplayControl))
            Else
                into.Add(dc)
            End If
        Next
    End Sub

    Public Shared Sub ControlsAddInTo(controls As List(Of DisplayControl), ByRef into As List(Of DisplayControl), Optional ByVal clone As Boolean = False)
        ' Adds a list of DisplayControl to another List, optionally adding their clones.
        For Each dc As DisplayControl In controls
            If clone Then
                into.Add(CType(dc.Clone, DisplayControl))
            Else
                into.Add(dc)
            End If
        Next
    End Sub

    Public Shared Sub ControlsRemoveFrom(controls As List(Of DisplayControl), ByRef from As ObservableCollection(Of DisplayControl))
        ' Removes a List of DisplayControl from an ObservableCollection.
        For Each dc As DisplayControl In controls
            from.Remove(dc)
        Next
    End Sub

    Public Shared Sub ControlsRemoveFrom(controls As ObservableCollection(Of DisplayControl), ByRef from As ObservableCollection(Of DisplayControl))
        ' Removes an ObservableCollection of DisplayControl from another ObservableCollection.
        For Each dc As DisplayControl In controls
            from.Remove(dc)
        Next
    End Sub

    Public Shared Sub ControlsRemoveFrom(controls As List(Of DisplayControl), ByRef from As List(Of DisplayControl))
        ' Removes a List of DisplayControl from another List.
        from.RemoveAll(Function(item) controls.Contains(item))
    End Sub

    ''' <summary>
    ''' Returns a new instance of a DisplayControl subclass by its full name (including namespace).
    ''' </summary>
    ''' <param name="controlFullName"></param>
    ''' <returns>DisplayControl</returns>
    Public Shared Function CreateInstance(ByVal controlFullName As String) As DisplayControl
        Dim controlType As Type = GetControlType(controlFullName)
        If controlType IsNot Nothing Then
            Return TryCast(Activator.CreateInstance(Type.GetType(controlFullName, False, True)), DisplayControl)
        End If
        Return Nothing
    End Function

    'Public ReadOnly Property DragOffset As Point
    '    Get
    '        Return mDragOffset
    '    End Get
    'End Property

    Public Function FindTopMostParent(ByVal dc As DisplayControl) As Control
        ' Start with the control itself
        Dim ctrl As Control = dc

        ' Loop as long as the current control has a parent
        While ctrl.Parent IsNot Nothing
            ' Move up to the next parent in the hierarchy
            ctrl = ctrl.Parent
        End While

        ' Return the control that has no parent (the top-level parent)
        Return ctrl
    End Function

    ''' <summary>
    ''' Returns the Type of the named control.
    ''' </summary>
    ''' <param name="controlTypeName"></param>
    ''' <returns>Type</returns>
    Public Shared Function GetControlType(controlTypeName As String) As Type
        Return Type.GetType(controlTypeName, False, True)
    End Function

    Public Property EdgeSize As Integer
        Get
            Return mEdgeSize
        End Get
        Set(value As Integer)
            If value < kControlEdgeSizeMin Then
                value = kControlEdgeSizeMin
            End If
            mEdgeSize = value
        End Set
    End Property


    Public Property IsSelectable As Boolean

    Public Property IsMovable As Boolean

    Public Property IsSizeable As Boolean

    Public Property LastPosition As Point = New Point()

    Public Property LastSize As Size = New Size()

    Public Property MaxSize As Size = New Size()

    Public Property MinSize As Size = New Size()

    Public Property ResizePoint As ResizePoints

    Public Property Selected As Boolean
        Get
            Return mSelected
        End Get
        Set(value As Boolean)
            mSelected = value
            Me.Refresh()
        End Set
    End Property

    Public ReadOnly Property ZOrder As Integer
        Get
            If Me.Parent Is Nothing Then
                Return -1
            End If
            Return Me.Parent.Controls.GetChildIndex(Me)
        End Get
    End Property

    Public Overridable Property Data As Object
        Get
            Return mData
        End Get
        Set(value As Object)
            mData = value
            ShowData()
        End Set
    End Property
#End Region
#Region "Private Interface"
    Protected Overridable Sub ShowData()

    End Sub

    Private Sub ControlAdd(e As ControlEventArgs)
        If Me.IsSelectable Then
            AddHandler e.Control.MouseDown, AddressOf DisplayControl_MouseDown
            AddHandler e.Control.MouseUp, AddressOf Me.DisplayControl_MouseUp
            AddHandler e.Control.Paint, AddressOf Me.DisplayControl_Paint
        End If
        If Me.IsMovable Or Me.IsSizeable Then
            AddHandler e.Control.LocationChanged, AddressOf Me.DisplayControl_LocationChanged
            AddHandler e.Control.MouseMove, AddressOf Me.DisplayControl_MouseMove
        End If
    End Sub

    Private Sub ControlRemove(e As ControlEventArgs)
        For Each ctrl As Control In Me.Controls
            If Me.IsSelectable Then
                RemoveHandler e.Control.MouseDown, AddressOf DisplayControl_MouseDown
                RemoveHandler e.Control.MouseUp, AddressOf Me.DisplayControl_MouseUp
                RemoveHandler e.Control.Paint, AddressOf Me.DisplayControl_Paint
            End If
            If Me.IsMovable Or Me.IsSizeable Then
                RemoveHandler e.Control.LocationChanged, AddressOf Me.DisplayControl_LocationChanged
                RemoveHandler e.Control.MouseMove, AddressOf Me.DisplayControl_MouseMove
            End If
        Next
    End Sub

    Private Sub DrawBorder(g As Graphics)
        If Me.Selected Then
            ' Draw selection rectangle
            Dim rect As Rectangle = Me.ClientRectangle
            rect.Inflate(kControlBorderInflate.Width, kControlBorderInflate.Height)
            ControlPaint.DrawBorder(g, rect,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle,
                kControlBorderColor, kControlBorderSize, kControlBorderStyle)
        Else
            ' Draw normal border
            ControlPaint.DrawBorder(g, Me.ClientRectangle, Me.BackColor, ButtonBorderStyle.None)
        End If
    End Sub

    Public Sub DrawCursor(e As MouseEventArgs)
        ' Change the cursor based on the mouse position for resizing.
        If Me.Selected Then
            If Me.IsSizeable Then
                Dim rect As Rectangle = Me.ClientRectangle
                If e.X >= rect.Right - EdgeSize AndAlso e.Y >= rect.Bottom - EdgeSize Then
                    Me.Cursor = Cursors.SizeNWSE ' Bottom-right corner
                    ResizePoint = ResizePoints.BottomRightCorner
                ElseIf e.X <= rect.Left + EdgeSize AndAlso e.Y >= rect.Bottom - EdgeSize Then
                    Me.Cursor = Cursors.SizeNESW ' Bottom-left corner
                    ResizePoint = ResizePoints.BottomLeftCorner
                ElseIf e.X >= rect.Right - EdgeSize AndAlso e.Y <= rect.Top + EdgeSize Then
                    Me.Cursor = Cursors.SizeNESW ' Top-right corner
                    ResizePoint = ResizePoints.TopRightCorner
                ElseIf e.X <= rect.Left + EdgeSize AndAlso e.Y <= rect.Top + EdgeSize Then
                    Me.Cursor = Cursors.SizeNWSE ' Top-left corner
                    ResizePoint = ResizePoints.TopLeftCorner
                ElseIf e.X >= rect.Right - EdgeSize Then
                    Me.Cursor = Cursors.SizeWE ' Right edge
                    ResizePoint = ResizePoints.RightEdge
                ElseIf e.X <= rect.Left + EdgeSize Then
                    Me.Cursor = Cursors.SizeWE ' Left edge
                    ResizePoint = ResizePoints.LeftEdge
                ElseIf e.Y >= rect.Bottom - EdgeSize Then
                    Me.Cursor = Cursors.SizeNS ' Bottom edge
                    ResizePoint = ResizePoints.BottomEdge
                ElseIf e.Y <= rect.Top + EdgeSize Then
                    Me.Cursor = Cursors.SizeNS ' Top edge
                    ResizePoint = ResizePoints.TopEdge
                Else
                    Me.Cursor = Cursors.Default ' Default cursor
                    ResizePoint = ResizePoints.None
                End If
            Else
                Me.Cursor = Cursors.Default
            End If
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DisplayControl_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        'Debug.WriteLine($"LocationChanged: {Me.Name} moved from {mDebugLocation} to {Me.Location}")
        'mDebugLocation = Me.Location
        'Dim ctrl As DisplayControl = DirectCast(sender, DisplayControl)
        'If ctrl.Parent Is Nothing Then Return
        'Dim pBounds As Rectangle = ctrl.Parent.ClientRectangle
        'Dim newLocation As Point = ctrl.Location
        'If newLocation.X < 0 Then newLocation.X = 0
        'If newLocation.Y < 0 Then newLocation.Y = 0

        '' Ensure Bottom/Right is within bounds.
        'If newLocation.X + ctrl.Width > pBounds.Width Then
        '    newLocation.X = pBounds.Width - ctrl.Width
        'End If
        'If newLocation.Y + ctrl.Height > pBounds.Height Then
        '    newLocation.Y = pBounds.Height - ctrl.Height
        'End If

        '' Apply corrected location, removing handler to prevent recursive loop.
        'If newLocation = ctrl.Location Then
        '    If Me.IsOutOfParentBounds Then
        '        Me.IsOutOfParentBounds = False
        '    End If
        '    Return
        'End If
        'RemoveHandler ctrl.LocationChanged, AddressOf DisplayControl_LocationChanged
        'ctrl.Location = newLocation
        'Me.IsOutOfParentBounds = True
        'AddHandler ctrl.LocationChanged, AddressOf DisplayControl_LocationChanged
    End Sub

    Private Sub DisplayControl_ControlsAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
        ControlAdd(e)
    End Sub

    Private Sub DisplayControl_ControlsRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved
        ControlRemove(e)
    End Sub

    Private Sub DisplayControl_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim args As New MouseEventArgs(e.Button, e.Clicks, Me.PointToClient(System.Windows.Forms.Cursor.Position).X, Me.PointToClient(System.Windows.Forms.Cursor.Position).Y, e.Delta)
        RaiseEvent MouseDownEvent(Me, args)
        mDragOffset = e.Location
        'If Me.Selected AndAlso Me.IsMovable AndAlso Me.Cursor Is Cursors.Default Then
        '    Me.DoDragDrop(New DataObject("DisplayControl", Me), DragDropEffects.Move)
        'End If
    End Sub

    Private Sub DisplayControl_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        DrawCursor(e)
        If Me.Selected Then
            Dim args As New MouseEventArgs(e.Button, e.Clicks, Me.PointToClient(System.Windows.Forms.Cursor.Position).X, Me.PointToClient(System.Windows.Forms.Cursor.Position).Y, e.Delta)
            RaiseEvent MouseMoveEvent(Me, args)
        End If
    End Sub

    Private Sub DisplayControl_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim args As New MouseEventArgs(e.Button, e.Clicks, Me.PointToClient(System.Windows.Forms.Cursor.Position).X, Me.PointToClient(System.Windows.Forms.Cursor.Position).Y, e.Delta)
        RaiseEvent MouseUpEvent(Me, args)
    End Sub

    Private Sub DisplayControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        DrawBorder(e.Graphics)
    End Sub

    Private Sub DisplayControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Debug.WriteLine($"Resize: {Me.Name} resized from {mDebugSize} to {Me.Size}")
        'mDebugSize = Me.Size
        'Dim ctrl = DirectCast(sender, DisplayControl)
        'If ctrl.Parent Is Nothing Then Return

        '' Calculate the max possible dimensions based on current position
        'Dim pBounds As Rectangle = ctrl.Parent.ClientRectangle
        'Dim maxWidth As Integer = ctrl.Parent.ClientSize.Width - ctrl.Left
        'Dim maxHeight As Integer = ctrl.Parent.ClientSize.Height - ctrl.Top

        '' Clamp the size (ensuring it's at least 1x1 to avoid errors)
        'Dim newWidth As Integer = Math.Clamp(ctrl.Width, 1, Math.Max(1, maxWidth))
        'Dim newHeight As Integer = Math.Clamp(ctrl.Height, 1, Math.Max(1, maxHeight))

        '' Apply only if values changed to prevent event recursion
        'If ctrl.Width <> newWidth OrElse ctrl.Height <> newHeight Then
        '    ctrl.Size = New Size(newWidth, newHeight)
        'End If
    End Sub
#End Region
End Class
