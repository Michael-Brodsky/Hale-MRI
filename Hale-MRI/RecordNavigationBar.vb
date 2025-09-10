Imports LibDatabase.Contexts
Imports System.ComponentModel

''' <summary>
''' Form Control that can be used by data consumers (forms
''' that derive from FrmDatabaseForm) to visually navigate
''' and manipulate data in the parent form's master  
''' BindingSource, and handle certain events for controls 
''' bound to it.
''' </summary>
''' 
Public Class RecordNavigationBar
#Region "Private Members"
    Private mBoundControls As List(Of Control) = Nothing    ' List of Controls bound to the MasterSource.
    Private mDatabase As HaleMRIContext = Nothing           ' The current database context.
    Private mMasterSource As BindingSource = Nothing        ' The current master BindingSource.
    Private mFilter As Object = Nothing                     ' The current filter object, if any.
#End Region
#Region "Public Inteface"
    Public Property BoundControls As List(Of Control)
        Get
            Return mBoundControls
        End Get
        Set(controls As List(Of Control))
            ' Assigns "change" event handlers to any bound controls. 
            ' This notifies us when a record is being editted.
            If controls IsNot Nothing Then
                For Each ctrl In controls
                    Select Case True
                        Case TypeOf ctrl Is TextBox
                            AddHandler CType(ctrl, TextBox).TextChanged, AddressOf Bound_TextChanged
                        Case TypeOf ctrl Is ComboBox
                            AddHandler CType(ctrl, ComboBox).SelectionChangeCommitted, AddressOf Bound_SelectionChangeCommitted
                        Case TypeOf ctrl Is CheckBox
                            AddHandler CType(ctrl, CheckBox).CheckedChanged, AddressOf Bound_CheckChanged
                        Case TypeOf ctrl Is DataGridView
                            AddHandler CType(ctrl, DataGridView).CellBeginEdit, AddressOf Bound_CellBeginEdit
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
            Return MasterSource.Count
        End Get
    End Property

    Public ReadOnly Property Current As Object
        Get
            Return BindingSourceCurrent(MasterSource)
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

    Public Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            Me.Enabled = Database IsNot Nothing AndAlso MasterSource IsNot Nothing
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
            MasterSource.Position = value
        End Set
        Get
            Return MasterSource.Position
        End Get
    End Property

    Public Sub ShowPosition()
        TxtCurrentPosition.Text = $"{Me.Position + 1} of {Me.Count}".ToString
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub Bound_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        SaveUndoControlsEnabled = True
    End Sub

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
        MasterSource.AddNew()
    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Delete"))
    End Sub

    Private Sub CmdFind_Click(sender As Object, e As EventArgs) Handles CmdFind.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Find", TxtFind.Text))
    End Sub

    Private Sub CmdGotoFirst_Click(sender As Object, e As EventArgs) Handles CmdGotoFirst.Click
        MasterSource.MoveFirst()
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoFirst"))
    End Sub

    Private Sub CmdGotoLast_Click(sender As Object, e As EventArgs) Handles CmdGotoLast.Click
        MasterSource.MoveLast()
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoLast"))
    End Sub

    Private Sub CmdGotoNext_Click(sender As Object, e As EventArgs) Handles CmdGotoNext.Click
        If Me.Position + 1 < Me.Count Then
            MasterSource.MoveNext()
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoNext"))
        End If
    End Sub
    Private Sub CmdGotoPrevious_Click(sender As Object, e As EventArgs) Handles CmdGotoPrevious.Click
        If Me.Position > 0 Then
            MasterSource.MovePrevious()
            RaiseEvent NavigationEvent(Me, New NavigationEventArgs("GotoNext"))
        End If
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Save"))
        BindingSourceSave(Database, MasterSource)
        SaveUndoControlsEnabled = False
    End Sub
    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click
        RaiseEvent NavigationEvent(Me, New NavigationEventArgs("Undo"))
        BindingSourceUndo(Database, MasterSource)
        SaveUndoControlsEnabled = False
    End Sub
    Private Sub DataSource_AddingNew(sender As Object, e As AddingNewEventArgs)
        CmdUndo.Enabled = True
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

    Public Sub ControlsEnable()
        ' Enables our Controls according to the master BindingSource's
        ' current state.
        CmdGotoFirst.Enabled = Not CmdUndo.Enabled AndAlso Me.Count > 0                 ' Navigation allowed only if MasterSource has records.
        CmdAddNew.Enabled = Not CmdUndo.Enabled AndAlso Me.Position <> kNoCurrentRecord ' Adding allowed only if a record is currently selected and not being editted.
        TxtCurrentPosition.Enabled = Me.Position <> kNoCurrentRecord                    ' Position Control enabled only if a record is currently selected.
        ' The remaining Control states can be computed.
        CmdGotoLast.Enabled = CmdGotoFirst.Enabled
        CmdGotoNext.Enabled = CmdGotoFirst.Enabled
        CmdGotoPrevious.Enabled = CmdGotoFirst.Enabled
        CmdDelete.Enabled = CmdAddNew.Enabled
        CmdFind.Enabled = CmdGotoFirst.Enabled
        TxtFind.Enabled = CmdFind.Enabled
        If Not CmdUndo.Enabled Then CmdSave.Enabled = False
        ' BoundControls are enabled only if the MasterSource has records and a record is currently selected.
        BoundControlsEnabled = Me.Position <> kNoCurrentRecord AndAlso Me.Count > 0
    End Sub

    Private WriteOnly Property HandleDataSourceEvents As Boolean
        Set(value As Boolean)
            Static handled As Boolean
            If value <> handled AndAlso MasterSource IsNot Nothing Then
                If value Then
                    AddHandler MasterSource.AddingNew, AddressOf DataSource_AddingNew
                    AddHandler MasterSource.PositionChanged, AddressOf DataSource_PositionChanged
                    ' Set our initial controls' states.
                    ShowPosition()
                    ControlsEnable()
                Else
                    RemoveHandler MasterSource.AddingNew, AddressOf DataSource_AddingNew
                    RemoveHandler MasterSource.PositionChanged, AddressOf DataSource_PositionChanged
                End If
                handled = value
            End If
        End Set
    End Property

    Private WriteOnly Property SaveUndoControlsEnabled As Boolean
        ' The Save and Undo Controls are enabled only when the current record is being editted. 
        ' This will also enable any navigation and modification Controls accordingly.
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
