Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Public Class ChartSectorsbyBlade
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
    ''' <summary>
    ''' determines which radius is being measured against each other
    ''' </summary>
    ''' <returns>Double</returns>
    Public Property Radius As Double = Nothing
#End Region
#Region "Computated Properties"
    Private ReadOnly Property BasisPitch As Double
        Get
            If Basis = "Marked" Then
                Return mJobDetails.Job.MarkedPitch
            ElseIf Basis = "Desired" Then
                Return mJobDetails.Job.DesiredPitch
            ElseIf Basis = "Progressive" Then
                Return mJobDetails.WheelPitch
            ElseIf Basis = "Design" Then
                Return 0
            Else
                Basis = "Mean"
                Return mJobDetails.WheelPitch
            End If
        End Get
    End Property
#End Region
#End Region
#Region "Private Interface"
    Protected Overrides Sub ShowData()
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim bp As Double = BasisPitch
        Chart1.Titles.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Series.Clear()
        Chart1.Legends.Clear()

        Dim cArea As ChartArea = Chart1.ChartAreas.Add("Pitch")
        Dim x As Integer
        Dim y As Integer
        For x = 1 To TolClass.LocalPitchSectors
            Dim ser As Series
            For y = 1 To mJobDetails.Job.PropellerBlades
                If x = 1 Then
                    ser = Chart1.Series.Add("Blade" + y.ToString())
                    ser.ChartType = SeriesChartType.Column
                    ser.ChartArea = cArea.Name
                    ser.Color = GraphColorArray(x)
                Else
                    ser = Chart1.Series("Blade" + y.ToString())
                End If
                Dim BladeData As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = y And r.Radius = Radius).FirstOrDefault()
                Dim localpitch As Double = GetLocalPitch(BladeData.CellMeasurements, TolClass.LocalPitchSectors, x, mJobDetails.Job.PropellerDiameter, Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                If TolClass.LocalPitchSectors = 1 Then
                    ser.Points.AddXY("Local Pitch", localpitch)
                Else
                    If y = 1 Then
                        ser.Points.AddXY("LE", localpitch)
                    ElseIf y = TolClass.LocalPitchSectors Then
                        ser.Points.AddXY("TE", localpitch)
                    Else
                        ser.Points.AddXY(x.ToString(), localpitch)
                    End If
                End If
            Next
        Next
        cArea.AxisY.Minimum = bp * 0.8
        cArea.AxisY.Maximum = bp * 1.2
        'need to handle striplines for Progressive pitch - measured against average for that section on that radius 
        'also need to be able to make strip lines appear on one section of bars
        Dim leg As Legend = Chart1.Legends.Add("Legend")
        leg.Alignment = StringAlignment.Center
        leg.Title = Radius.ToString() + "Radius - Compare to " + Basis + " - Minimums Apply"

        Dim title As Title = Chart1.Titles.Add("TopTitle")
        If TolClass.ToleranceClass = "C" Then
            title.Text = "Local Pitch Custom Class"
        Else
            title.Text = "Local Pitch ISO 484 " + TolClass.ToleranceClass
        End If
        title = Chart1.Titles.Add("YTitle")
        title.Alignment = ContentAlignment.TopCenter
        cArea.AxisY.Title = "Segment Pitch"
    End Sub
#End Region
End Class
