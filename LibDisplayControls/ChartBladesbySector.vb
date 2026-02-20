Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Public Class ChartBladesbySector
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
#End Region
#Region "Private Interface"
    Protected Overrides Sub ShowData()
        Dim BasisPitch As Double
        If Basis = "Marked" Then
            BasisPitch = mJobDetails.Job.MarkedPitch
        ElseIf Basis = "Desired" Then
            BasisPitch = mJobDetails.Job.DesiredPitch
        ElseIf Basis = "Progressive" Then
            BasisPitch = mJobDetails.WheelPitch
        ElseIf Basis = "Design" Then
            BasisPitch = 0
        Else
            Basis = "Mean"
            BasisPitch = mJobDetails.WheelPitch
        End If

        Chart1.Titles.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Series.Clear()
        Chart1.Legends.Clear()

        Dim cArea As ChartArea = Chart1.ChartAreas.Add("Pitch")
        Dim x As Integer
        Dim y As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim ser As Series = Chart1.Series.Add("Blade" + x.ToString())
            ser.ChartType = SeriesChartType.Column
            ser.ChartArea = cArea.Name
            ser.Color = GraphColorArray(x)
            Dim BladeData As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x And r.Radius = Radius).FirstOrDefault()
            For y = 1 To TolClass.LocalPitchSectors
                Dim localpitch As Double = GetLocalPitch(BladeData.CellMeasurements, TolClass.LocalPitchSectors, y, mJobDetails.Job.PropellerDiameter, Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                ser.Points.AddXY("Blade " + x.ToString(), localpitch)
            Next
        Next
        cArea.AxisY.Minimum = BasisPitch * 0.8
        cArea.AxisY.Maximum = BasisPitch * 1.2
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
