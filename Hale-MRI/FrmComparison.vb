Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDisplayControls.MRIMath
Imports LibDisplayControls
Public Class FrmComparison
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
    Private mProgRadius As RadiusMeasurement = Nothing
    Private mProgLoaded As Boolean = False
    Private mCharts As List(Of ChartCompLine) = New List(Of ChartCompLine)
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
    Public Property CenterRef As Boolean
        Get
            Return ChkCenterRef.Checked
        End Get
        Set(value As Boolean)
            ChkCenterRef.Checked = value
        End Set
    End Property
    Public Property GraphEntireScan As Boolean
        Get
            Return ChkGraphEntireScan.Checked
        End Get
        Set(value As Boolean)
            ChkGraphEntireScan.Checked = value
        End Set
    End Property
    Public Property ShowTrack As Boolean
        Get
            Return ChkShowTrack.Checked
        End Get
        Set(value As Boolean)
            ChkShowTrack.Checked = value
        End Set
    End Property
    Public Property ExamineOneBlade As Boolean
        Get
            Return ChkExamineoneBlade.Checked
        End Get
        Set(value As Boolean)
            ChkExamineoneBlade.Checked = value
        End Set
    End Property
    Public Property Spline As Boolean
        Get
            Return ChkSpline.Checked
        End Get
        Set(value As Boolean)
            ChkSpline.Checked = value
        End Set
    End Property
    Public Property ComparisonFont As Integer
        Get
            Return TrackFont.Value
        End Get
        Set(value As Integer)
            TrackFont.Value = value
        End Set
    End Property
    Public Property KeepForComp As Boolean
        Get
            Return ChkKeepforComp.Checked
        End Get
        Set(value As Boolean)
            ChkKeepforComp.Checked = value
        End Set
    End Property
    Public Property Sections As Integer
        Get
            Return TrackSegments.Value
        End Get
        Set(value As Integer)
            TrackSegments.Value = value
        End Set
    End Property

#End Region
#Region "Private Interface"
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
    Private Sub UpdateCharts() ' need to make the hookup between forms so that this form has data to pass to controls and can be displayed
        If ExamineOneBlade Then
            For Each rm As RadiusMeasurement In Current.RadiusMeasurements.Where(Function(r) r.BladeId = ComboRadiusorBlade.SelectedIndex + 1)
                TLayoutCompCharts.Controls.Clear()
                TLayoutCompCharts.RowCount = Current.RadiusMeasurements.Where(Function(r) r.BladeId = ComboRadiusorBlade.SelectedIndex + 1).Count()
                TLayoutCompCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 100 / TLayoutCompCharts.RowCount))
                TLayoutCompCharts.Height = TLayoutCompCharts.RowCount * 250
                Dim i As Integer = 0
                Dim graph As New ChartCompLine()
                graph.CenterRef = CenterRef
                graph.EntireScan = GraphEntireScan
                graph.showTrack = ShowTrack
                graph.spline = Spline
                graph.Sections = Sections
                graph.Dock = DockStyle.Fill
                graph.rm = rm
                graph.TolClass = GetToleranceTable(Database, JobDetails.ToleranceClass)
                graph.Progcm = mProgRadius?.CellMeasurements
                graph.Trackcm = Current.RadiusMeasurements.Where(Function(r) r.BladeId = ComboTrackRefBlade.SelectedIndex + 1 And Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).First()?.CellMeasurements
                TLayoutCompCharts.Controls.Add(graph)
                mCharts.Add(graph)
                TLayoutCompCharts.SetRow(graph, i)
                i += 1
                graph.Data = rm
            Next
        Else
            For Each rm As RadiusMeasurement In Current.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value).ToString = ComboRadiusorBlade.SelectedItem.ToString())
                TLayoutCompCharts.Controls.Clear()
                TLayoutCompCharts.RowCount = Job.PropellerBlades
                TLayoutCompCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 100 / TLayoutCompCharts.RowCount))
                TLayoutCompCharts.Height = TLayoutCompCharts.RowCount * 250
                Dim i As Integer = 0
                Dim graph As New ChartCompLine()
                graph.CenterRef = CenterRef
                graph.EntireScan = GraphEntireScan
                graph.showTrack = ShowTrack
                graph.spline = Spline
                graph.Sections = Sections
                graph.Dock = DockStyle.Fill
                graph.rm = rm
                graph.TolClass = GetToleranceTable(Database, JobDetails.ToleranceClass)
                graph.Progcm = mProgRadius?.CellMeasurements
                graph.Trackcm = Current.RadiusMeasurements.Where(Function(r) r.BladeId = ComboTrackRefBlade.SelectedIndex + 1 And Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).First()?.CellMeasurements
                TLayoutCompCharts.Controls.Add(graph)
                mCharts.Add(graph)
                TLayoutCompCharts.SetRow(graph, i)
                i += 1
                graph.Data = rm
            Next
        End If
    End Sub
    Private Sub FormSort(ByRef jobDetails As BindingList(Of JobDetail))
        For Each jd As JobDetail In jobDetails
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
    End Sub
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
            UpdateCharts()
        End If
    End Sub
    Private Sub FrmComparison_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load event handler code here
        Navigator = RecordNavigationBar1
        Navigator.BoundControls = New List(Of Control) From {DataGridJobDetails}
        MasterSource = JobDetailsBindingSource
    End Sub

    Private Sub ChkCenterRef_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCenterRef.CheckedChanged
        For Each chart In mCharts
            chart.CenterRef = CenterRef
        Next
    End Sub

    Private Sub ChkKeepforComp_CheckedChanged(sender As Object, e As EventArgs) Handles ChkKeepforComp.CheckedChanged

    End Sub

    Private Sub ChkGraphEntireScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGraphEntireScan.CheckedChanged
        For Each chart In mCharts
            chart.EntireScan = GraphEntireScan
        Next
    End Sub

    Private Sub ChkShowTrack_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowTrack.CheckedChanged
        For Each chart In mCharts
            chart.showTrack = ShowTrack
        Next
    End Sub

    Private Sub ChkExamineoneBlade_CheckedChanged(sender As Object, e As EventArgs) Handles ChkExamineoneBlade.CheckedChanged
        'need to cahnge the ComboRadius to say blade and have blades instead of Rads
        If ChkExamineoneBlade.Checked Then
            ComboRadiusorBlade.Items.Clear()
            Dim I As Integer
            For I = 1 To Job.PropellerBlades
                ComboRadiusorBlade.Items.Add(I.ToString())
            Next
            ComboRadiusorBlade.SelectedIndex = 0
            LabRadiusorBlade.Text = "Blade: " + ComboRadiusorBlade.SelectedItem.ToString()
        Else
            ComboRadiusorBlade.Items.Clear()
            For Each rm As RadiusMeasurement In Current.RadiusMeasurements.Where(Function(r) r.BladeId = 1)
                ComboRadiusorBlade.Items.Add(Math.Round(rm.Radius.Value).ToString())
            Next
            ComboRadiusorBlade.SelectedIndex = 0
            LabRadiusorBlade.Text = "Radius: " + ComboRadiusorBlade.SelectedItem.ToString()
        End If
        UpdateCharts()
    End Sub

    Private Sub ChkSpline_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSpline.CheckedChanged
        For Each chart In mCharts
            chart.spline = Spline
        Next
    End Sub

    Private Sub TrackFont_ValueChanged(sender As Object, e As EventArgs) Handles TrackFont.ValueChanged
        Dim tfont As New Font(Me.Font.FontFamily, TrackFont.Value)
        Me.Font = tfont

    End Sub

    Private Sub TrackSegments_ValueChanged(sender As Object, e As EventArgs) Handles TrackSegments.ValueChanged
        LabSegments.Text = "Segments: " & TrackSegments.Value.ToString()
        'add a function here to update graphs
    End Sub

    Private Sub CmdMeasure_Click(sender As Object, e As EventArgs) Handles CmdMeasure.Click
        ShowForm(gFrmMeasurements, Database, User)
    End Sub
#End Region
End Class