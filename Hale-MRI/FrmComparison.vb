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
Public Class FrmComparison
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
    Private chartStyle As DataVisualization.Charting.SeriesChartType = SeriesChartType.Line
    Private ProgRadius As RadiusMeasurement = Nothing
    Private ProgLoaded As Boolean = False
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
    Private Sub OrientCharts(chartnum As Integer)
        Dim x As Integer
        For x = 0 To chartnum - 1
            ChartComparison.ChartAreas.ElementAt(x).Position.Auto = False
            ChartComparison.ChartAreas.ElementAt(x).Position.Height = 100 / chartnum
            ChartComparison.ChartAreas.ElementAt(x).Position.Width = 100
            ChartComparison.ChartAreas.ElementAt(x).AxisX.Minimum = -5
            ChartComparison.ChartAreas.ElementAt(x).AxisX.Maximum = 105
            ChartComparison.ChartAreas.ElementAt(x).AxisY.Minimum = 1 ' need to add control for managing y Axis Scaling
            ChartComparison.ChartAreas.ElementAt(x).AxisY.Maximum = 10
            ChartComparison.ChartAreas.ElementAt(x).Position.Y = x * (100 / chartnum)

        Next
        ChartComparison.Height = chartnum * 250
    End Sub
    Private Sub CreateChartAreas(radorBlade As Boolean)
        'radorBlade true = all radii False = one rad on all blades
        If radorBlade Then
            For Each RM As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = ComboRadiusorBlade.SelectedItem)
                ChartComparison.ChartAreas.Add("Rad" + Math.Round(RM.Radius.Value).ToString())
                ChartComparison.ChartAreas("Rad" + Math.Round(RM.Radius.Value).ToString()).AxisY.Title = "Bld " + ComboRadiusorBlade.SelectedItem.ToString() + "Radius " + RM.Radius.Value.ToString()
            Next
        Else
            Dim x As Integer
            For x = 1 To Job.PropellerBlades
                ChartComparison.ChartAreas.Add("Blade" + x.ToString())
                ChartComparison.ChartAreas("Blade" + x.ToString()).AxisY.Title = "Bld " + x.ToString() + " " + ComboRadiusorBlade.SelectedItem.ToString()
            Next
        End If
    End Sub
    Private Sub CreateChartSeriesLP(radorBlade As Boolean)
        'radorBlade true = all radii False = one rad on all blades
        If radorBlade Then
            For Each Chart As DataVisualization.Charting.ChartArea In ChartComparison.ChartAreas
                Dim ns As Series = ChartComparison.Series.Add("LPSeries" + Chart.Name)
                ns.ChartType = chartStyle
                ns.ChartArea = Chart.Name
                'add ifs checking for what to plot here as well as change the Axes titles and scaling
                'also ask about the other lines, they are tolerances
                'if Prog is not loaded need a series that makes a flat line at 0
                'if show track is checked plot based off track pos of selected ref blade
                If ChkCenterRef.Checked Then
                    'adjust points by center point amount or first point
                    'add points to series
                    'add labels for local pitch and track position
                    'These are height values
                    'GetLocalHeight() need to figure out method of getting the correct radiusMeasurement for graph
                End If

            Next
        End If
    End Sub
    Private Sub CreateChartSeriesTrack(radorBlade As Boolean)
        If radorBlade Then
            For Each Chart As DataVisualization.Charting.ChartArea In ChartComparison.ChartAreas
                Dim ns As Series = ChartComparison.Series.Add("TrackSeries" + Chart.Name)
                ns.ChartType = SeriesChartType.StepLine
                ns.ChartArea = Chart.Name
                'add ifs checking for what to plot here as well as change the Axes titles and scaling
                'if prog loaded plot exact heights of selected track ref blade, if not plot flat line at 0
                If ProgLoaded AndAlso ProgRadius IsNot Nothing Then
                    Dim IncludedAngle As Double = Math.Abs(ProgRadius.CellMeasurements.LastOrDefault().Angle.Value - ProgRadius.CellMeasurements.FirstOrDefault().Angle.Value)
                    If ChkGraphEntireScan.Checked = False Then
                        Dim cl As Double = GetChordLength(ProgRadius.CellMeasurements, mJob.PropellerDiameter, Math.Round(ProgRadius.Radius.Value))
                        Dim lezoneangle As Double = IncludedAngle * (Job.LeExclusion / cl)
                        Dim tezoneangle As Double = IncludedAngle * (Job.TeExclusion / cl)
                        IncludedAngle = IncludedAngle - lezoneangle - tezoneangle
                    End If
                    'plot based off track position of selected ref blade
                    'GetTrackHeight() need to figure out method of getting the correct radiusMeasurement for graph
                    Dim x As Integer
                    For x = 1 To 20
                        Dim trackheight As Double = GetLocalHeight(ProgRadius.CellMeasurements.ToList(), 20, x, Job.PropellerDiameter, ProgRadius.Radius.Value, mJob.TeExclusion, mJob.TeExclusion)
                        'need method to get heights relative to track position - find ideal height difference between points
                        'using height between points we can use a difference * points from ref to get actual height at track position to calculate blade heights
                        'reverse engineer pitch calculation to get heights

                        ns.Points.AddXY((x - 1) * 5, 5) ' placeholder y, y needs to be height at track position
                    Next
                Else
                    ns.Points.AddXY(0, 0)
                    ns.Points.AddXY(100, 0)
                End If
            Next
        End If
    End Sub
    Private Sub ShowCompChart()
        ChartComparison.Series.Clear()
        ChartComparison.ChartAreas.Clear()
        CreateChartAreas(ChkExamineoneBlade.Checked)
        OrientCharts(ChartComparison.ChartAreas.Count)
        CreateChartSeriesLP(ChkExamineoneBlade.Checked)
        ' going to have to handle all modifications and plotting of charts here fully programmatically
    End Sub
#End Region
#Region "Private Interface"
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
    Private Sub ChartUpdate()
        ShowCompChart()

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
    Private Sub FrmComparison_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load event handler code here
    End Sub

    Private Sub ChkCenterRef_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCenterRef.CheckedChanged

    End Sub

    Private Sub ChkKeepforComp_CheckedChanged(sender As Object, e As EventArgs) Handles ChkKeepforComp.CheckedChanged

    End Sub

    Private Sub ChkGraphEntireScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGraphEntireScan.CheckedChanged

    End Sub

    Private Sub ChkShowTrack_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowTrack.CheckedChanged

    End Sub

    Private Sub ChkExamineoneBlade_CheckedChanged(sender As Object, e As EventArgs) Handles ChkExamineoneBlade.CheckedChanged
        ChartUpdate()
    End Sub

    Private Sub ChkSpline_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSpline.CheckedChanged

    End Sub
#End Region
End Class