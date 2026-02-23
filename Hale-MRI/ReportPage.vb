Imports LibDisplayControls

Public Class ReportPage
    Implements ICloneable
#Region "Types and Constants"
    Public Delegate Sub MouseEventHandler(sender As Control, e As MouseEventArgs)
    Public Event MouseDownEvent As MouseEventHandler
    Public Event MouseMoveEvent As MouseEventHandler
#End Region
#Region "Private Members"
    Private mDocument As DocumentSettings = Nothing
    Private mGridSize As Integer = 0
#End Region
#Region "Constructors"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal other As ReportPage)
        InitializeComponent()

        Me.Document = other.Document
        Me.GridSize = other.GridSize
        Me.Name = other.Name
        For Each ctrl As DisplayControl In other.DisplayControls
            Dim newCtrl As DisplayControl = CType(ctrl.Clone(), DisplayControl)
            Me.Controls.Add(newCtrl)
        Next
    End Sub

    Public Property PageBounds As Rectangle

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New ReportPage(Me)
    End Function

    Public Function Copy(other As ReportPage) As ReportPage
        Me.Name = other.Name
        For Each ctrl As DisplayControl In Me.Controls.Cast(Of Control)().OfType(Of DisplayControl)()
            Dim matchingCtrl As DisplayControl = other.DisplayControls.FirstOrDefault(Function(c) c.Name = ctrl.Name)
            If matchingCtrl IsNot Nothing Then
                ctrl.Copy(matchingCtrl)
            End If
        Next
        Me.Document = other.Document
        Me.GridSize = other.GridSize
        Return Me
    End Function
#End Region
    Public ReadOnly Property DisplayControls As List(Of DisplayControl)
        Get
            Return Me.Controls.OfType(Of DisplayControl)().ToList()
        End Get
    End Property

    Public Property Document As DocumentSettings
        Get
            Return mDocument
        End Get
        Set(value As DocumentSettings)
            DocumentSet(value)
            mDocument = value
        End Set
    End Property

    Public Property GridSize As Integer
        Get
            Return mGridSize
        End Get
        Set(value As Integer)
            GridSizeSet(value)
            mGridSize = value
        End Set
    End Property

    Public Property VerticalLimit As Integer = 0

    Private Sub DocumentSet(doc As DocumentSettings)
        ' Pages cannot resize once they're set.
        Me.MaximumSize = Size.Empty
        Me.MinimumSize = Size.Empty
        Me.Size = New Size(doc.PaperWidth, doc.PaperHeight)
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.Margins.Location = New Point(doc.MarginLeft, doc.MarginTop)
        Me.Margins.Size = New Size(Me.Width - (doc.MarginRight + doc.MarginLeft), Me.Height - (doc.MarginBottom + doc.MarginTop))
        'Me.Margins.Bounds = New Rectangle(
        '    doc.MarginLeft,
        '    doc.MarginTop,
        '    Me.Width - (doc.MarginRight + doc.MarginLeft),
        '    Me.Height - (doc.MarginBottom + doc.MarginTop)
        ')
        Me.Refresh()
    End Sub

    Private Sub DocumentZoom(zoomFactor As Single)
        Me.Invalidate()
    End Sub

    Private Sub GridSizeSet(gridSize As Integer)
        For Each ctrl As DisplayControl In Me.DisplayControls
            ctrl.EdgeSize = gridSize
        Next
    End Sub
#Region "Event Handlers"

    Private Sub Margins_MouseDown(sender As Object, e As MouseEventArgs) Handles Margins.MouseDown
        RaiseEvent MouseDownEvent(Me.Margins, e)
    End Sub

    Private Sub PrintableArea_MouseDown(sender As Object, e As MouseEventArgs)
        RaiseEvent MouseDownEvent(Me, e)
    End Sub

    Private Sub ReportPage_ControlAdded(sender As Object, e As ControlEventArgs) Handles MyBase.ControlAdded
        Dim dc As DisplayControl = TryCast(e.Control, DisplayControl)
        If dc IsNot Nothing Then
            dc.BringToFront()
            dc.Visible = True
        End If
    End Sub

    Private Sub ReportPage_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        RaiseEvent MouseDownEvent(Me, e)
    End Sub
#End Region
End Class
