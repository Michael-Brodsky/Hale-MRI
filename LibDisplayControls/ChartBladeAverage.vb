Imports LibDatabase.Models
Imports System.Windows.Forms.DataVisualization.Charting

Public Class ChartBladeAverage
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
    ''' <returns>JobDetail</returns>
    Public Property mJobDetails As JobDetail = Nothing
    ''' <summary>
    ''' Loaded Progression Measurements for making tolerance and reference lines
    ''' </summary>
    ''' <returns>Tolerance</returns>
    Public Property TolClass As Tolerance = Nothing
    ''' <summary>
    ''' Loaded RadiusMeasurements for making a Reference Line if no Prog is loaded
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Basis As String = Nothing
#End Region
#Region "Computated Properties"
    Private ReadOnly Property BasisPitch
        Get
            If mJobDetails Is Nothing Then
                Return 0
            End If
            Select Case Basis
                Case "Marked"
                    Return mJobDetails.Job.MarkedPitch
                Case "Desired"
                    Return mJobDetails.Job.DesiredPitch
                Case "Design"
                    Return 0 ' need to set  up loading designs for comparison
                Case Else ' "Mean"
                    Return mJobDetails.WheelPitch
            End Select
        End Get
    End Property
#End Region
#End Region
#Region "Private Interface"
    Protected Overrides Sub ShowData()
        If mJobDetails Is Nothing OrElse
                TolClass Is Nothing Then Exit Sub

        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        Chart1.Annotations.Clear()
        Dim bp As Double = BasisPitch

        Dim cArea As ChartArea = Chart1.ChartAreas.Add("BladeAverage")
        Dim ser As Series = Chart1.Series.Add("Pitch")
        ser.ChartType = SeriesChartType.Bar
        ser.ChartArea = cArea.Name
        cArea.AxisY2.Enabled = AxisEnabled.False
        cArea.AxisX2.Enabled = AxisEnabled.False

        cArea.Axes(1).Minimum = 0
        cArea.Axes(1).Maximum = bp * 1.2
        cArea.Axes(1).Interval = 1
        cArea.Axes(1).MinorTickMark.Enabled = True
        cArea.Axes(1).MinorTickMark.Interval = 1
        cArea.Axes(1).MajorTickMark.Enabled = True
        cArea.Axes(1).MajorTickMark.Interval = 5
        cArea.Axes(1).MajorGrid.Enabled = True
        cArea.Axes(1).MajorGrid.Interval = bp * 1.2

        cArea.Axes(0).Minimum = 0
        cArea.Axes(0).Maximum = mJobDetails.Job.PropellerBlades + 1
        cArea.Axes(0).Interval = 1
        cArea.Axes(0).Title = "Blade"
        cArea.Axes(0).TitleFont = New Font("Arial", 14, FontStyle.Bold)
        cArea.Axes(0).IsMarginVisible = True

        Dim x As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim avgpitch As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                avgpitch += GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                pitchcount += 1
            Next
            If pitchcount > 0 Then
                avgpitch /= pitchcount
            End If
            Dim pointind As Integer = ser.Points.AddXY(x, avgpitch)
            ser.Points(pointind).Color = GraphColorArray(x - 1)
        Next
        Dim slineunder As New StripLine With {
        .IntervalOffset = bp - (bp * (TolClass.MeanPitchPerBladePercent / 100)),
        .StripWidth = 0.01,
        .BorderColor = Color.Black,
        .BorderWidth = 2,
        .Text = (bp - (bp * (TolClass.MeanPitchPerBladePercent / 100))).ToString(),
        .TextOrientation = TextOrientation.Horizontal,
        .TextLineAlignment = StringAlignment.Near,
        .ForeColor = Color.Red
    }
        cArea.Axes(1).StripLines.Add(slineunder)
        Dim slineover As New StripLine With {
        .IntervalOffset = bp + (bp * (TolClass.MeanPitchPerBladePercent / 100)),
        .StripWidth = 0.01,
        .BorderColor = Color.Black,
        .BorderWidth = 2,
        .Text = (bp + (bp * (TolClass.MeanPitchPerBladePercent / 100))).ToString(),
        .TextOrientation = TextOrientation.Horizontal,
        .TextLineAlignment = StringAlignment.Far,
        .ForeColor = Color.Blue
    }
        cArea.Axes(1).StripLines.Add(slineover)
    End Sub
#End Region
End Class
