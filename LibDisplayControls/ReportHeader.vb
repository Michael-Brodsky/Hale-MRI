Imports System.Collections.ObjectModel
Imports LibDatabase.Models

Public Class ReportHeader
    Inherits DisplayControl

    Private mItems As String
    Private WithEvents mVisibleItems As New ObservableCollection(Of Control)
    Private mBindingSource As New BindingSource()
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
    Public ReadOnly Property LabeledItems As List(Of Label)
        Get
            Return Header.Controls.Cast(Of Control)().OfType(Of Label)().Where(Function(l) l.Tag IsNot Nothing).ToList()
        End Get
    End Property

    Public ReadOnly Property TaggedItems As List(Of Control)
        Get
            Return Header.Controls.Cast(Of Control)().Where(Function(c) c.Tag IsNot Nothing).ToList()
        End Get
    End Property

    Public Function LabelByText(text As String) As Label
        Return Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Text = text)
    End Function

    Public Function ControlByTag(tag As String) As Control
        Return Header.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Tag?.ToString() = tag)
    End Function

    Public Function LabelToTag(lab As Label) As Control
        Dim ctrlLabel As Label = Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l Is lab)
        Return Header.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlLabel.Tag)
    End Function

    Public Function TagToLabel(tag As Control) As Label
        Dim ctrl As Control = Header.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c Is tag)
        Return Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Tag?.ToString() = ctrl?.Name)
    End Function

    Public Sub VisibleByLabel(label As String, visible As Boolean)
        Dim ctrlLabel As Label = Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Tag?.ToString() = label)
        Dim ctrl As Control = Header.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlLabel.Tag)
        If ctrl IsNot Nothing Then
            If visible AndAlso Not mVisibleItems.Contains(ctrl) Then
                mVisibleItems.Add(ctrl)
            ElseIf Not visible AndAlso mVisibleItems.Contains(ctrl) Then
                mVisibleItems.Remove(ctrl)
            End If
        End If
    End Sub

    Public Sub VisibleByTag(tag As String, visible As Boolean)
        Dim ctrl As Control = Header.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Tag?.ToString() = tag)
        If ctrl IsNot Nothing Then
            If visible AndAlso Not mVisibleItems.Contains(ctrl) Then
                mVisibleItems.Add(ctrl)
            ElseIf Not visible AndAlso mVisibleItems.Contains(ctrl) Then
                mVisibleItems.Remove(ctrl)
            End If
        End If
    End Sub

    Public ReadOnly Property VisibleItems As List(Of Control)
        Get
            Return mVisibleItems.ToList()
        End Get
    End Property

    Public ReadOnly Property VisibleLabels As List(Of Label)
        Get
            Return LabeledItems.Where(Function(l) l.Visible).ToList()
        End Get
    End Property

#End Region
#Region "Private Interface"
    Private Sub ItemsSet(listItems As String)
        If Not String.IsNullOrWhiteSpace(listItems) Then
            ' Split on ';', remove empty entries and trim each item.
            Dim items As String() = listItems.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
            For Each ctrl As Control In Header.Controls
                If ctrl.Tag IsNot Nothing Then
                    If items.Contains(ctrl.Tag.ToString()) Then
                        mVisibleItems.Add(ctrl)
                    Else
                        mVisibleItems.Remove(ctrl)
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub ItemVisible(ctrl As Control, visible As Boolean)
        ctrl.Visible = visible
        Dim ctrlLabel As Label = Header.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Tag?.ToString() = ctrl.Name)
        If ctrlLabel IsNot Nothing Then ctrlLabel.Visible = visible
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub VisibleItems_CollectionChanged(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Handles mVisibleItems.CollectionChanged
        ' Update visibility of controls based on the current collection of visible items.
        If e.NewItems IsNot Nothing Then
            For Each newItem As Control In e.NewItems
                ItemVisible(newItem, True)
            Next
        End If
        If e.OldItems IsNot Nothing Then
            For Each oldItem As Control In e.OldItems
                ItemVisible(oldItem, False)
            Next
        End If
    End Sub

    Private Sub ReportHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.JobDetailsBindingSource.DataSource = TryCast(Me.Data, JobDetail)
    End Sub
#End Region
End Class
