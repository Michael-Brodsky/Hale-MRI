Public Class ReportHeader
    Inherits DisplayControl

    Private mItems As String
#Region "Constructors"
    ''' <summary>
    ''' Creates a new ReportHeader object.
    ''' </summary>
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' Creates a new ReportHeader object with the given properties.
    ''' </summary>
    Public Sub New(name As String, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                   Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As Object = Nothing)
        MyBase.New(name, selectable, sizeable, movable, maxSize, minSize, data)
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new ReportHeader object by copying properties from another instance.
    ''' </summary>
    Public Sub New(ByVal other As ReportHeader)
        MyBase.New(other)
        InitializeComponent()
    End Sub
#End Region
#Region "Public Interface"
    Public Property Items As String
        Get
            Return mItems
        End Get
        Set(value As String)
            ItemsSet(value)
            mItems = value
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub ItemsSet(listItems As String)
        Dim items As String() = listItems.Split(New String() {";"c}, StringSplitOptions.RemoveEmptyEntries)
        For Each ctrl As Control In Header.Controls
            If ctrl.Tag IsNot Nothing Then
                ctrl.Visible = items.Contains(ctrl.Tag.ToString())
            End If
        Next
    End Sub
#End Region
End Class
