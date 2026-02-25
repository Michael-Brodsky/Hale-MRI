Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Public Class ChartCompLine
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
    Public Sub New(name As String, Optional displayName As String = Nothing, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                   Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As Object = Nothing)
        MyBase.New(name, displayName, selectable, sizeable, movable, maxSize, minSize, data)
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
#Region "Client Properties"
    ''' <summary>
    ''' Data Used to plot chart
    ''' </summary>
    ''' <returns>RadiusMeasurement</returns>
    Public Property rm As RadiusMeasurement = Nothing
    ''' <summary>
    ''' Loaded Progression Measurements for making tolerance and reference lines
    ''' </summary>
    ''' <returns>List(Of CellMeasurement)</returns>
    Public Property Progcm As List(Of CellMeasurement) = Nothing
    ''' <summary>
    ''' Loaded RadiusMeasurements for making a Reference Line if no Prog is loaded
    ''' </summary>
    ''' <returns>List(Of CellMeasurement)</returns>
    Public Property Trackcm As List(Of CellMeasurement) = Nothing
    ''' <summary>
    ''' Tolerance Class for Chart1
    ''' </summary>
    ''' <returns>ToleranceClass</returns>
    Public Property TolClass As Tolerance = Nothing
    ''' <summary>
    ''' Reference Pitch
    ''' </summary>
    ''' <returns>Double</returns>
    Public Property RefPitch As Double = 0
    ''' <summary>
    ''' Determines max and min Y axis scaling
    ''' </summary>
    ''' <returns>Double</returns>
    Public Property AxesScaling As Double = 1
    '''<summary>
    '''determines whether thegraph is in spline or line mode
    '''</summary>
    '''<returns>Boolean</returns>
    Public Property spline As Boolean = False
    '''<summary>
    '''Show Track determines whether the chart points are offset by a height value taken from Trackcm
    '''</summary>
    '''<returns>Boolean</returns>
    Public Property showTrack As Boolean = False
    '''<summary>
    ''' Determines whther LEE and TEE are used in line graph calulations
    '''</summary>
    '''<returns>Boolean</returns>
    Public Property EntireScan As Boolean = False
    ''' <summary>
    ''' Center Reference for placement of points
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property CenterRef As Boolean = False
    '''<summary>
    '''Number of sections to graph
    ''' </summary>
    ''' <returns>Integer</returns>
    Public Property Sections As Integer = 10
#End Region
#Region "Computed Properties"
    ''' <summary>
    ''' Returns the TEE value from the associated Job
    ''' </summary>
    ''' <returns>Double</returns>
    Private ReadOnly Property TEE As Double
        Get
            If EntireScan Then
                Return 0
            Else
                Return rm.JobDetails.Job.TeExclusion
            End If
        End Get
    End Property
    ''' <summary>
    ''' Returns the TEE value from the associated Job
    ''' </summary>
    ''' <returns>Double</returns>
    Private ReadOnly Property LEE As Double
        Get
            If EntireScan Then
                Return 0
            Else
                Return rm.JobDetails.Job.LeExclusion
            End If
        End Get
    End Property
    Private Property HeightAtRefPoint As Double = 0
#End Region
#End Region
#Region "Private Interface"
    Protected Overrides Sub ShowData()
        If rm Is Nothing OrElse
                TolClass Is Nothing OrElse
                RefPitch = 0 Then
            Return
        End If
        Dim refheights As List(Of Double) = GetRefHeightsStraight(CenterRef, RefPitch, rm.JobDetails.Job.PropellerBlades)
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        Chart1.Annotations.Clear()

        Dim cArea As ChartArea = Chart1.ChartAreas.Add("LPLineArea")
        Dim ser As Series = Chart1.Series.Add("LPLineSeries")
        ChartCompLine_Add_Ref()
        For Each sr As Series In Chart1.Series
            sr.ChartArea = cArea.Name
            If spline Then
                sr.ChartType = SeriesChartType.Spline
            Else
                sr.ChartType = SeriesChartType.Line
            End If
        Next

        Dim newheights As New List(Of Double)
        For x = 0 To 20
            newheights.Add(refheights(x) + HeightAtRefPoint)
        Next
        'need to revisit this function to make it make 20 points and be able to print out the height difference for each section.

        Dim lpline As New List(Of Double)
        For x = 0 To 20
            If x = 0 Then
                lpline.Add(GetLocalHeightStartSector(rm.CellMeasurements, 20, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
            Else
                lpline.Add(GetLocalHeightEndSector(rm.CellMeasurements, 20, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
            End If
            ser.Points.Add(x * 5, lpline(x))
        Next
        Dim sectionsHeightdiff As New List(Of Double)
        Dim angperblade As Double = 360 / rm.JobDetails.Job.PropellerBlades
        Dim anglediffbetweenpoints As Double = angperblade / Sections
        Dim heightdiffbetweenpoints As Double = (RefPitch * anglediffbetweenpoints) / 360
        For x = 0 To Sections
            If CenterRef Then
                sectionsHeightdiff.Add(heightdiffbetweenpoints * Math.Abs((Sections / 2) - x))
            Else
                sectionsHeightdiff.Add(heightdiffbetweenpoints * x)
            End If
        Next
        For x = 0 To Sections
            Dim sline As StripLine
            If x = Sections Then
                sline = New StripLine With {
                    .IntervalOffset = 100,
                    .ForeColor = Color.Black}
            ElseIf x = 0 Then
                sline = New StripLine With {
                    .IntervalOffset = 0,
                    .ForeColor = Color.Black,
                    .Text = GetLocalPitch(rm.CellMeasurements, Sections, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE).ToString(),
                    .TextAlignment = StringAlignment.Center}
            Else
                sline = New StripLine With {
                    .IntervalOffset = x * (100 / Sections),
                    .ForeColor = Color.Red,
                    .Text = GetLocalPitch(rm.CellMeasurements, Sections, x + 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE).ToString(),
                    .TextAlignment = StringAlignment.Center}
            End If
            cArea.AxisX.StripLines.Add(sline)
            Dim Anon As TextAnnotation
            If x = Sections Then
                'need to get and edit height for each section here
                Dim heit As Double = GetLocalHeightEndSector(rm.CellMeasurements, Sections, Sections, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                heit -= sectionsHeightdiff(Sections)
                Anon = New TextAnnotation With {
                    .AxisX = cArea.AxisX,
                    .X = 95,
                    .Y = AxesScaling / -4,
                    .AllowMoving = False,
                    .Text = heit.ToString()}
            Else
                Dim heit As Double = GetLocalHeightStartSector(rm.CellMeasurements, Sections, x + 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                heit -= sectionsHeightdiff(0)
                Anon = New TextAnnotation With {
                    .AxisX = cArea.AxisX,
                    .X = x * (100 / Sections),
                    .Y = AxesScaling / -4,
                    .AllowMoving = False,
                    .Text = heit.ToString()}
            End If
        Next

        cArea.Position.Auto = False
        cArea.Position.Height = 100
        cArea.Position.Width = 100
        cArea.AxisX.Minimum = -5
        cArea.AxisX.Maximum = 105
        cArea.AxisY.Minimum = -AxesScaling ' need to add control for managing y Axis Scaling
        cArea.AxisY.Maximum = AxesScaling
        cArea.AxisY.Title = "Bld " + rm.BladeId.ToString() + " " + rm.Radius.ToString()
    End Sub

    Private Sub ChartCompLine_Add_Ref()
        Dim refser As Series = Chart1.Series.Add("Ref")
        Dim tolhighser As Series = Chart1.Series.Add("TolHigh")
        Dim tollowser As Series = Chart1.Series.Add("TolLow")
        Dim refheights As List(Of Double) = GetRefHeightsStraight(CenterRef, RefPitch, rm.JobDetails.Job.PropellerBlades)
        Dim x As Integer
        If Progcm Is Nothing Then 'all creation and management of reference and tolerance lines are handled here
            For x = 0 To 10
                refser.Points.Add(x * 10, 0)
            Next
            If showTrack = True Then
                If CenterRef Then
                    HeightAtRefPoint = GetLocalHeightEndSector(Trackcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) 'need to be able to pull ref points from tracked blade
                Else
                    HeightAtRefPoint = GetLocalHeightStartSector(Trackcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
            Else
                If CenterRef Then
                    HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                Else
                    HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
            End If
            Chart1.Series(tollowser.Name).Enabled = False
            Chart1.Series(tolhighser.Name).Enabled = False
        Else
            Dim tollisthigh As List(Of Double) = GetRefHeightsHighTol(CenterRef, RefPitch, TolClass, rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
            Dim tollistlow As List(Of Double) = GetRefHeightsLowTol(CenterRef, RefPitch, TolClass, rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
            For x = 0 To 10
                Dim height As Double
                If x = 0 Then
                    height = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                Else
                    height = GetLocalHeightEndSector(Progcm, 10, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                End If
                height -= refheights(x)  'need to add a change in here that changes height based on center ref point and the ref height at that point
                refser.Points.Add(x * 10, height)
                tolhighser.Points.Add(x * 10, tollisthigh(x))
                tollowser.Points.Add(x * 10, tollistlow(x))
                If showTrack = True Then
                    If CenterRef Then
                        HeightAtRefPoint = GetLocalHeightEndSector(Progcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    Else
                        HeightAtRefPoint = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    End If
                Else
                    If CenterRef Then
                        HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    Else
                        HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
                    End If
                End If
            Next
        End If
    End Sub
#End Region
End Class
