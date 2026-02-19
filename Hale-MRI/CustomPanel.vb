Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class CustomPanel
    Inherits Panel

    Private mBorderColor As Color = Color.Black         ' Default border color
    Private mBorderWidth As Integer = 1                 ' Default border width in pixels
    Private mDashPattern As Single() = {3.0F, 1.0F}     ' Default dash pattern (3 pixels on, 1 pixel off)
    Private mDashStyle As DashStyle = DashStyle.Dash    ' Default to dashed border.

    Public Sub New()
        InitializeComponent()

        Me.SetStyle(
            ControlStyles.OptimizedDoubleBuffer Or
            ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.ResizeRedraw Or
            ControlStyles.UserPaint, True
        )
    End Sub

    Public Property BorderColor As Color
        Get
            Return mBorderColor
        End Get
        Set(value As Color)
            mBorderColor = value
            Me.Invalidate() ' Redraw the panel to update the border color
        End Set
    End Property

    <Category("Appearance")>
    Public Property BorderWidth As Integer
        Get
            Return mBorderWidth
        End Get
        Set(value As Integer)
            mBorderWidth = value
            Me.Invalidate() ' Redraw the panel to update the border width
        End Set
    End Property

    <Category("Appearance")>
    Public Property DashBorderStyle As DashStyle
        Get
            Return mDashStyle
        End Get
        Set(value As DashStyle)
            mDashStyle = value
            Me.Invalidate() ' Redraw the panel to update the border style
        End Set
    End Property

    Public Property DashPatternStyle As Single()
        Get
            Return mDashPattern
        End Get
        Set(value As Single())
            mDashPattern = value
            Me.Invalidate() ' Redraw the panel to update the border style
        End Set
    End Property

    ''' <summary>
    ''' Draws a CustomPanel object.
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Call the base class OnPaint to ensure standard functionality runs (like background painting)
        MyBase.OnPaint(e)

        ' Use the "Using" statement to ensure the Pen object is disposed of correctly
        Using p As New Pen(BorderColor, BorderWidth)
            ' Set the DashStyle property
            p.DashStyle = BorderStyle
            p.DashPattern = DashPatternStyle

            ' Calculate the rectangle area to draw the border
            ' Adjust the rectangle size and location to ensure the full border is visible
            Dim rect As New Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1)

            ' Draw the rectangle
            e.Graphics.DrawRectangle(p, rect)
        End Using
    End Sub
End Class
