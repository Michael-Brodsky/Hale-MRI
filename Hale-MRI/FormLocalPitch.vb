Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
'Imports LibEncoder.IEncoderHardware
Imports Microsoft.EntityFrameworkCore
Public Class FormLocalPitch
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Finds the given JobDetail and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The JobDetail to find.</param>
    ''' <returns>The found JobDetail, or Nothing if not found.</returns>
    Public Function Find(item As JobDetail) As JobDetail
        Dim result As JobDetail = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJobDetails)
            End If
        End Set
    End Property
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJob)
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Function GetMeasurementData(j As Object) As BindingList(Of JobDetail)
        Dim data As BindingList(Of JobDetail) = Nothing
        If TypeOf j Is Job Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd.Job Is CType(j, Job)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        ElseIf TypeOf j Is JobDetail Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd Is CType(j, JobDetail)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        End If
        FormSort(data)
        Return data
    End Function
    Private Sub FormSort(ByRef jobDetails As BindingList(Of JobDetail))
        For Each jd As JobDetail In jobDetails
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
    End Sub

    Protected Overrides Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If Navigator IsNot Nothing Then Navigator.MasterSource = mMasterSource
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then mNavigator.Database = Database
        End Set
    End Property

    Private Sub GridJobDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridJobDetails.CellContentClick

    End Sub

    Private Sub FormLocalPitch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tolerances = Database.Tolerances.Local.ToList
        tolerances.Add(New Tolerance With {.ToleranceClass = "Custom"})
        ComboToleranceClass.DataSource = tolerances
        ComboToleranceClass.DisplayMember = "ToleranceClass"
        ComboToleranceClass.ValueMember = "ToleranceClass"
        ComboCompareto.DataSource = New List(Of String) From {"Mean", "Marked", "Desired", "Progressive"}

        GridJobDetails.AutoGenerateColumns = False
        'For Each emp As Employee In Database.Employees.Local.ToList()
        '    EmployeesBindingSource.Add(emp)
        'Next

        EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList

        'For Each tolclass As Tolerance In Database.Tolerances.Local.ToList()
        '    ClassBindingSource.Add(tolclass)
        'Next
        ClassBindingSource.DataSource = Database.Tolerances.Local.ToBindingList
        'For Each mtype As MeasurementType In Database.MeasurementTypes.Local.ToList()
        '    MeasurementTypesBindingSource.Add(mtype)
        'Next
        MeasurementTypesBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList

        ' Initialize the Navigator
        Navigator = RecordNavigationBar1
        Navigator.BoundControls = New List(Of Control) From {GridJobDetails}
        MasterSource = JobDetailsBindingSource
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        ' Handles Navigator events so we can update our controls accordingly.
        Select Case e.EventName
            Case "AddNew"
                ' Disable PanelMeasurements when the user is adding a new JobDetails record.
            Case "Delete"
                ' put msg box here that says can't delete record on this form
            Case "Editing"
            Case "FilterOff"
            Case "FilterOn"
            Case "Find"
            Case "GotoFirst", "GotoNext", "GotoPrev"
            Case "GotoLast"
            Case "Save"
                ' Refresh any open database forms affected by our changes and enable PanelMeasurements.
                RefreshAll()
            Case "Undo"
                ' Enable the PanelMeasurements when the user has cancelled the JobDetails record changes.
                If Me.Current IsNot Nothing Then
                End If
            Case Else
        End Select
    End Sub
    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        If mJobDetails IsNot Current Then
            mJobDetails = Current
            'insert form updating function here
        End If
    End Sub
#End Region
End Class

