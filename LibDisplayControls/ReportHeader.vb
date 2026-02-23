Imports System.Collections.ObjectModel
Imports LibDatabase.Models

Public Class ReportHeader
    Inherits DisplayControl
#Region "Types and Constants"
    Private kLetterheadHeight As Integer = 120
    Private kHeaderHeight As Integer = 162
#End Region
#Region "Private Members"
    Private WithEvents mVisibleItems As New ObservableCollection(Of Control)
    Private mBindingSource As New BindingSource()
#End Region
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
    Public ReadOnly Property ItemLabels As List(Of Label)
        Get
            Return Header.Controls.Cast(Of Control)().
                OfType(Of Label)().
                Where(Function(l) l.Tag IsNot Nothing).
                ToList()
        End Get
    End Property

    Public ReadOnly Property ItemControls As List(Of Control)
        Get
            Return Header.Controls.Cast(Of Control)().
                Where(Function(ctrl) TypeOf ctrl IsNot Label).
                ToList()
        End Get
    End Property

    Private Function LabelByText(text As String) As Label
        Return Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Text = text)
    End Function

    Public Function ControlToLabel(ctrl As Control) As Label
        Return Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Tag.ToString = ctrl.Name)
    End Function

    Public Sub ItemHide(ByVal itemName As String)
        mVisibleItems.Remove(LabelByText(itemName))
    End Sub

    Public Sub ItemShow(ByVal itemTag As String)
        Dim ctrl As Control = Me.ItemControls.FirstOrDefault(Function(hi) hi.Tag.ToString() = itemTag)
        If Not mVisibleItems.Contains(ctrl) Then
            mVisibleItems.Add(ctrl)
        End If
    End Sub

    Public Sub ItemVisible(ByVal itemName As String, ByVal visible As Boolean)
        If visible Then
            ItemShow(itemName)
        Else
            ItemHide(itemName)
        End If
    End Sub

    Public ReadOnly Property VisibleTags As List(Of String)
        Get
            Return ItemControls.Where(Function(hi) hi.Visible = True).Select(Function(hi) hi.Name).ToList()
        End Get
    End Property

    Public Property VisibleItems As List(Of String)
        Get
            Return mVisibleItems.Select(Function(hi) hi.Tag.ToString()).ToList()
        End Get
        Set(value As List(Of String))
            For Each item As Control In mVisibleItems.ToList()
                mVisibleItems.Remove(item)
            Next
            For Each item As String In value
                ItemShow(item)
            Next
        End Set
    End Property
    Public ReadOnly Property ManagedItems As List(Of String)
        Get
            Return Me.ItemLabels.Select(Function(hi) hi.Text)
        End Get
    End Property
#End Region
#Region "Private Interface"
    Private Sub ControlVisible(ctrl As Control, visible As Boolean)
        If ctrl IsNot Nothing Then
            ctrl.Visible = visible
            Dim lab As Label = Me.ItemLabels.FirstOrDefault(Function(hi) hi.Tag = ctrl.Name)
            If lab IsNot Nothing Then lab.Visible = visible
        End If
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub VisibleItems_CollectionChanged(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Handles mVisibleItems.CollectionChanged
        ' Update visibility of controls based on the current collection of visible items.
        If e.NewItems IsNot Nothing Then
            For Each newItem As Control In e.NewItems
                ControlVisible(newItem, True)
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each oldItem As Control In e.OldItems
                ControlVisible(oldItem, False)
            Next
        End If
    End Sub

    Private Sub ReportHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Data IsNot Nothing Then
            Me.JobDetailsBindingSource.DataSource = TryCast(Me.Data, JobDetail)
        End If
    End Sub

    Private Sub Header_Paint(sender As Object, e As PaintEventArgs) Handles Header.Paint

    End Sub
#End Region
End Class
