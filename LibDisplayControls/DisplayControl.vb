Imports System.Reflection
Partial Public Class DisplayControl
    Inherits UserControl
    Implements ICloneable

#Region "Types and Constants"
    Public Delegate Sub ControlEventHandler(sender As DisplayControl, e As EventArgs)
    Public Delegate Sub MouseEventHandler(sender As DisplayControl, e As MouseEventArgs)
    Public Delegate Sub KeyEventHandler(sender As DisplayControl, e As KeyEventArgs)
    Public Event ControlEvent As ControlEventHandler
    Public Event MouseDownEvent As MouseEventHandler
    Public Event MouseUpEvent As MouseEventHandler
    Public Event KeyEvent As KeyEventHandler

    Private Const kControlEdgeSize As Integer = 5                               ' Control's drag edge size in pixels.
    Private Const kControlBorderSize As Integer = 3                             ' Control's selection border size in pixels.
    Private kControlBorderInflate As Size = New Size(2, 2)                      ' Control's selection border offset from the control's border.
    Private kControlBorderColor As Color = Color.Blue                           ' Control's selection border color
    Private kControlBorderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid  ' Control's selection border style.
#End Region
#Region "Private Members"
    Private mData As Object = Nothing
    Private mSelected As Boolean = False
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
#End Region
#Region "Public Interface"
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

    ''' <summary>
    ''' Returns the Type of the named control.
    ''' </summary>
    ''' <param name="controlTypeName"></param>
    ''' <returns>Type</returns>
    Public Shared Function GetControlType(controlTypeName As String) As Type
        Return Type.GetType(controlTypeName, False, True)
    End Function

    Public Property IsSelectable As Boolean

    Public Property IsMovable As Boolean

    Public Property IsSizeable As Boolean

    Public Property LastPosition As Point = New Point()

    Public Property LastSize As Size = New Size()

    Public Property MaxSize As Size = New Size()

    Public Property MinSize As Size = New Size()

    Public Property Selected As Boolean
        Get
            Return mSelected
        End Get
        Set(value As Boolean)
            If value Then
                LastPosition = Me.Location
                LastSize = Me.Size
            End If
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

    Private Sub ControlAdd(e As ControlEventArgs)
        If Me.IsSelectable Then
            AddHandler e.Control.MouseDown, AddressOf DisplayControl_MouseDown
            AddHandler e.Control.MouseUp, AddressOf Me.DisplayControl_MouseUp
            AddHandler e.Control.Paint, AddressOf Me.DisplayControl_Paint
        End If
        If Me.IsMovable Or Me.IsSizeable Then
            AddHandler e.Control.LocationChanged, AddressOf Me.DisplayControl_LocationChanged
            AddHandler e.Control.MouseMove, AddressOf Me.DisplayControl_MouseMove
            AddHandler e.Control.Resize, AddressOf Me.DisplayControl_Resize
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
                RemoveHandler e.Control.Resize, AddressOf Me.DisplayControl_Resize
            End If
        Next
    End Sub

    Private Sub DisplayControl_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub DisplayControl_ControlsAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
        ControlAdd(e)
    End Sub

    Private Sub DisplayControl_ControlsRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved
        ControlRemove(e)
    End Sub

    Private Sub DisplayControl_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        RaiseEvent MouseDownEvent(Me, e)
    End Sub

    Private Sub DisplayControl_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

    End Sub

    Private Sub DisplayControl_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        RaiseEvent MouseUpEvent(Me, e)
    End Sub

    Private Sub DisplayControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        DrawBorder(e.Graphics)
    End Sub

    Private Sub DisplayControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub
#End Region
End Class
