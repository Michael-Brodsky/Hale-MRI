Public Class ReportLetterhead
    Inherits DisplayControl

    Public ReadOnly Property ErrorImage As Image
        Get
            Return LetterheadPictureBox.ErrorImage
        End Get
    End Property

    Public Property Image As Image
        Get
            Return LetterheadPictureBox.Image
        End Get
        Set(value As Image)
            Try
                LetterheadPictureBox.Image = value
            Catch ex As Exception
                LetterheadPictureBox.Image = LetterheadPictureBox.ErrorImage
            End Try
        End Set
    End Property
#Region "Constructors"
    ''' <summary>
    ''' Creates a new ReportLetterhead object.
    ''' </summary>
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new ReportLetterhead object with the given properties.
    ''' </summary>
    Public Sub New(name As String, Optional displayName As String = Nothing, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                   Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As Object = Nothing)
        MyBase.New(name, displayName, selectable, sizeable, movable, maxSize, minSize, data)
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new ReportLetterhead object by copying properties from another instance.
    ''' </summary>
    Public Sub New(ByVal other As ReportLetterhead)
        MyBase.New(other)
        InitializeComponent()
    End Sub
#End Region
End Class
