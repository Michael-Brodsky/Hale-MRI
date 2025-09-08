Imports LibDatabase.Contexts
Imports LibDatabase.StoredProcedures
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
Imports System.ComponentModel
Imports System.Reflection
Public Class RecordNavigationBar
#Region "Private Members"
    Private mBoundControls As List(Of Control) = Nothing
    Private mDatabase As HaleMRIContext = Nothing
    Private mDataSource As BindingSource = Nothing
    Private mFilter As Object = Nothing
#End Region
#Region "Public Inteface"
    Public Property BoundControls As List(Of Control)
        Get
            Return mBoundControls
        End Get
        Set(controls As List(Of Control))
            If controls IsNot Nothing Then
                For Each ctrl In controls
                    Select Case True
                        Case TypeOf ctrl Is TextBox
                            AddHandler CType(ctrl, TextBox).TextChanged, AddressOf Bound_TextChanged
                        Case TypeOf ctrl Is ComboBox
                            AddHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf Bound_SelectionChangeCommitted
                        Case TypeOf ctrl Is CheckBox
                            AddHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf Bound_CheckChanged
                        Case Else
                            ' Handle other control types if necessary.
                    End Select
                Next
            End If
            mBoundControls = controls
        End Set
    End Property

    Public Property Caption As String
        Set(value As String)
            LabCaption.Text = value
        End Set
        Get
            Return LabCaption.Text
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return DataSource.Count
        End Get
    End Property

    Public ReadOnly Property Current As Object
        Get
            Return BindingSourceCurrent(DataSource)
        End Get
    End Property

    Public Property Database As HaleMRIContext
        Get
            Return mDatabase
        End Get
        Set(value As HaleMRIContext)
            mDatabase = value
            If mDatabase Is Nothing Then Me.Enabled = False
        End Set
    End Property

    Public Property DataSource As BindingSource
        Get
            Return mDataSource
        End Get
        Set(value As BindingSource)
            mDataSource = value
            Me.Enabled = Database IsNot Nothing AndAlso mDataSource IsNot Nothing
        End Set
    End Property

    Public Overloads Property Enabled As Boolean
        Get
            Return MyBase.Enabled
        End Get
        Set(value As Boolean)
            MyBase.Enabled = value
            HandleDataSourceEvents = MyBase.Enabled
        End Set
    End Property

    Public Property Filter As Object
        Get
            Return mFilter
        End Get
        Set(value As Object)
            mFilter = value
            ChkToggleFilter.Enabled = mFilter IsNot Nothing
        End Set
    End Property

    Public Property FilterOn As Boolean
        Get
            Return ChkToggleFilter.Checked
        End Get
        Set(value As Boolean)
            ChkToggleFilter.Checked = value
        End Set
    End Property

    Public Class NavigationEventArgs
        Inherits EventArgs
        ' Custom event arguments for navigation events.
        ' When raised, clients can inspect the properties.
        Public Property EventName As String
        Public Property Value As Object
        Public Sub New(eventName As String, Optional value As Object = Nothing)
            Me.EventName = eventName
            Me.Value = value
        End Sub
    End Class

    Public Delegate Sub NavigationEventHandler(sender As Object, e As NavigationEventArgs)

    Public Event NavigationEvent As NavigationEventHandler

    Public Property Position As Integer
        Set(value As Integer)
            DataSource.Position = value
        End Set
        Get
            Return DataSource.Position
        End Get
    End Property

    Public Property MasterSource As BindingSource
        Set(value As BindingSource)
            DataSource = value
        End Set
        Get
            Return DataSource
        End Get
    End Property

    Public Sub ShowPosition()
        TxtCurrentPosition.Text = $"{Me.Position + 1} of {Me.Count}".ToString
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub Bound_CheckChanged(sender As Object, e As EventArgs)
        SaveUndoControlsEnabled = True
    End Sub

    Private Sub Bound_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If cmb.SelectedIndex <> kNoCurrentSelection Then
            SaveUndoControlsEnabled = True
        End If
    End Sub

    Private Sub Bound_TextChanged(sender As Object, e As EventArgs)
        Dim txtbox As TextBox = CType(sender, TextBox)
        If txtbox.Modified Then
            SaveUndoControlsEnabled = True
            txtbox.Modified = False ' Reset the modified state to prevent repeated triggering.
        End If
    End Sub

    Private Sub ChkToggleFilter_Click(sender As Object, e As EventArgs) Handles ChkToggleFilter.Click
        If ChkToggleFilter.Checked Then
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("FilterOn"))
        Else
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("FilterOff"))
        End If
    End Sub

    Private Sub CmdAddNew_Click(sender As Object, e As EventArgs) Handles CmdAddNew.Click
        DataSource.AddNew()
    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click

    End Sub

    Private Sub CmdFind_Click(sender As Object, e As EventArgs) Handles CmdFind.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Find", TxtFind.Text))
    End Sub

    Private Sub CmdGotoFirst_Click(sender As Object, e As EventArgs) Handles CmdGotoFirst.Click
        DataSource.MoveFirst()
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoFirst"))
    End Sub

    Private Sub CmdGotoLast_Click(sender As Object, e As EventArgs) Handles CmdGotoLast.Click
        MasterSource.MoveLast()
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoLast"))
    End Sub

    Private Sub CmdGotoNext_Click(sender As Object, e As EventArgs) Handles CmdGotoNext.Click
        If Me.Position + 1 < Me.Count Then
            DataSource.MoveNext()
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoNext"))
        End If
    End Sub
    Private Sub CmdGotoPrevious_Click(sender As Object, e As EventArgs) Handles CmdGotoPrevious.Click
        If Me.Position > 0 Then
            DataSource.MovePrevious()
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoNext"))
        End If
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Save"))
        BindingSourceSave(Database, DataSource)
        SaveUndoControlsEnabled = False
    End Sub
    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Undo"))
        BindingSourceUndo(Database, DataSource)
        SaveUndoControlsEnabled = False
    End Sub
    Private Sub DataSource_AddingNew(sender As Object, e As AddingNewEventArgs)
        CmdUndo.Enabled = True
    End Sub

    Private Sub MasterSource_BindingComplete(sender As Object, e As BindingCompleteEventArgs)

    End Sub

    Private Sub MasterSource_DataSourceChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MasterSource_ListChanged(sender As Object, e As ListChangedEventArgs)

    End Sub

    Private Sub DataSource_PositionChanged(sender As Object, e As EventArgs)
        ShowPosition()
        ControlsEnable()
    End Sub
#End Region
#Region "Private Interface"
    Private WriteOnly Property BoundControlsEnabled As Boolean
        Set(value As Boolean)
            If mBoundControls IsNot Nothing Then
                For Each ctrl In mBoundControls
                    ctrl.Enabled = value
                Next
            End If
        End Set
    End Property

    Private Sub ControlsEnable()
        CmdGotoFirst.Enabled = Not CmdUndo.Enabled AndAlso Me.Count > 0
        CmdAddNew.Enabled = Not CmdUndo.Enabled AndAlso Me.Position <> kNoCurrentRecord
        TxtCurrentPosition.Enabled = Me.Position <> kNoCurrentRecord

        CmdGotoLast.Enabled = CmdGotoFirst.Enabled
        CmdGotoNext.Enabled = CmdGotoFirst.Enabled
        CmdGotoPrevious.Enabled = CmdGotoFirst.Enabled
        CmdDelete.Enabled = CmdAddNew.Enabled
        CmdFind.Enabled = CmdGotoFirst.Enabled
        TxtFind.Enabled = CmdFind.Enabled
        If Not CmdUndo.Enabled Then CmdSave.Enabled = False

        BoundControlsEnabled = Me.Position <> kNoCurrentRecord AndAlso Me.Count > 0
    End Sub

    Private WriteOnly Property HandleDataSourceEvents As Boolean
        Set(value As Boolean)
            Static handled As Boolean
            If value <> handled AndAlso DataSource IsNot Nothing Then
                If value Then
                    AddHandler DataSource.AddingNew, AddressOf DataSource_AddingNew
                    'AddHandler mMasterSource.BindingComplete, AddressOf MasterSource_BindingComplete
                    'AddHandler mMasterSource.DataSourceChanged, AddressOf MasterSource_DataSourceChanged
                    'AddHandler mMasterSource.ListChanged, AddressOf MasterSource_ListChanged
                    AddHandler DataSource.PositionChanged, AddressOf DataSource_PositionChanged
                    ShowPosition()
                    ControlsEnable()
                Else
                    RemoveHandler DataSource.AddingNew, AddressOf DataSource_AddingNew
                    RemoveHandler DataSource.PositionChanged, AddressOf DataSource_PositionChanged
                End If
                handled = value
            End If
        End Set
    End Property

    Private WriteOnly Property SaveUndoControlsEnabled As Boolean
        Set(value As Boolean)
            CmdSave.Enabled = value
            CmdUndo.Enabled = CmdSave.Enabled
            CmdGotoFirst.Enabled = Not CmdSave.Enabled
            CmdAddNew.Enabled = Not CmdSave.Enabled

            CmdGotoLast.Enabled = CmdGotoFirst.Enabled
            CmdGotoNext.Enabled = CmdGotoFirst.Enabled
            CmdGotoPrevious.Enabled = CmdGotoFirst.Enabled
            CmdDelete.Enabled = CmdAddNew.Enabled
        End Set
    End Property
#End Region
End Class
