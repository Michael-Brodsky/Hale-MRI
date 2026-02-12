Imports System.Security.Cryptography
Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Public Class ChartAngularPosition
    Inherits DisplayControl
#Region "Types and Constants"
    Private Const kHeightOffset As Double = 0.2
#End Region
#Region "Constructors"
    ''' <summary>
    ''' Creates a new ChartAngularPosition object.
    ''' </summary>
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' Creates a new ChartAngularPosition object with the given properties.
    ''' </summary>
    Public Sub New(name As String, Optional selectable As Boolean = False, Optional sizeable As Boolean = False,
                   Optional movable As Boolean = False, Optional maxSize As Size = Nothing, Optional minSize As Size = Nothing, Optional data As Object = Nothing)
        MyBase.New(name, selectable, sizeable, movable, maxSize, minSize, data)
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new DisplayControl object by copying properties from another instance.
    ''' </summary>
    Public Sub New(ByVal other As ChartAngularPosition)
        MyBase.New(other)
        InitializeComponent()
    End Sub
#End Region
#Region "Public Interface"
#Region "Client Properties"
    ''' <summary>
    ''' Specialized getter/setter for the control's data source.
    ''' BladeCount, ReferenceBlade, ReferencePoint and ReferenceRadius
    ''' must be set prior to setting this property.
    ''' </summary>
    ''' <returns>List(Of RadiusMeasurement)</returns>
    Public Property RadiusMeasurements As List(Of RadiusMeasurement)

    ''' <summary>
    ''' Propeller blade count.
    ''' </summary>
    ''' <returns>Integer?</returns>
    Public Property BladeCount As Integer? = Nothing

    ''' <summary>
    ''' Propeller reference blade.
    ''' </summary>
    ''' <returns>UInteger?</returns>
    Public Property ReferenceBlade As Integer? = Nothing

    ''' <summary>
    ''' Blade reference point.
    ''' </summary>
    ''' <returns>String</returns>
    Public Property ReferencePoint As String = Nothing

    ''' <summary>
    ''' Blade reference radius.
    ''' </summary>
    ''' <returns></returns>
    Public Property ReferenceRadius As Double? = Nothing
#End Region
#Region "Computed Properties"
    Public ReadOnly Property InnerDepth As Double
        Get
            Return TrackGetDepth(InnerRadius, ReferencePoint)
        End Get
    End Property

    Public ReadOnly Property OuterDepth As Double
        Get
            Return TrackGetDepth(OuterRadius, ReferencePoint)
        End Get
    End Property

    ''' <summary>
    ''' RadiusMeasurement at smallest radius.
    ''' </summary>
    ''' <returns>RadiusMeasurement</returns>
    Public ReadOnly Property InnerRadius As RadiusMeasurement
        Get
            Return RadiusMeasurements?.FirstOrDefault()
        End Get
    End Property

    ''' <summary>
    ''' RadiusMeasurement at largest radius.
    ''' </summary>
    ''' <returns>RadiusMeasurement</returns>
    Public ReadOnly Property OuterRadius As RadiusMeasurement
        Get
            Return RadiusMeasurements?.LastOrDefault()
        End Get
    End Property

    ''' <summary>
    ''' Angle at reference radius and point.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ReferenceAngle As Double?
        Get
            Return TrackGetAngle(ReferenceRadiusMeasurement, ReferencePoint)
        End Get
    End Property

    ''' <summary>
    ''' Depth at reference radius and point.
    ''' </summary>
    ''' <returns>Double?</returns>
    Public ReadOnly Property ReferenceDepth As Double?
        Get
            Return TrackGetDepth(ReferenceRadiusMeasurement, ReferencePoint)
        End Get
    End Property
#End Region
#End Region
#Region "Private Interface"
    ''' <summary>
    ''' This property retrieves the RadiusMeasurement for a given blade ID 
    ''' from the Data property.
    ''' </summary>
    ''' <param name="blade"></param>
    ''' <returns>RadiusMeasurement</returns>
    Private ReadOnly Property ReferenceBladeMeasurement(ByVal blade As UInteger) As RadiusMeasurement
        Get
            Return CType(Data, List(Of RadiusMeasurement))?.FirstOrDefault(Function(r) r.BladeId = blade)
        End Get
    End Property

    ''' <summary>
    ''' This property retrieves the RadiusMeasurement for a given reference radius
    ''' from the RadiusMeasurements property.
    ''' </summary>
    ''' <param name="blade"></param>
    ''' <returns>RadiusMeasurement</returns>
    Private ReadOnly Property ReferenceRadiusMeasurement As RadiusMeasurement
        Get
            Return RadiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = ReferenceRadius)
        End Get
    End Property

    Protected Overrides Sub ShowData()
        ' Ensure required properties are set.
        If BladeCount Is Nothing OrElse
            RadiusMeasurements Is Nothing OrElse
            ReferenceBlade Is Nothing OrElse
            String.IsNullOrEmpty(ReferencePoint) OrElse
            ReferenceRadius Is Nothing Then Exit Sub

        ' Plot each blade's data points.
        Dim seriesPosition As Series = ChartCreateSeries(Chart1, "AngularPosition", "Blade", "Position")
        For i As Integer = 1 To BladeCount
            Dim b As Integer = i
            If ReferenceBladeMeasurement(b) IsNot Nothing Then
                Dim bladeAngle As Double = TrackGetAngle(ReferenceBladeMeasurement(b), ReferencePoint)
                Dim bladePosition As Double = Math.Abs(ReferenceAngle.Value - bladeAngle) - ((360 / BladeCount) * Math.Abs(ReferenceBlade.Value - ReferenceBladeMeasurement(b).BladeId.Value)) + kHeightOffset
                Dim p As Integer = seriesPosition.Points.AddXY($"{b}", bladePosition)
                seriesPosition.Points(p).Color = GraphColorArray(i - 1)
            End If
        Next
    End Sub
#End Region
End Class
