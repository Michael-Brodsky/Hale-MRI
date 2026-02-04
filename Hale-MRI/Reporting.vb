Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Module Reporting
    ' ReportDataDelegate type - a delegate method that can be
    ' invoked when a client control needs to update its data.
    Public Class ReportDataArgs
        Public Property Args() As Object

        Public Sub New()

        End Sub

        Public Sub New(ByVal ParamArray args())
            Me.Args = args
        End Sub
    End Class

    Public Delegate Sub ReportDataDelegate(ByRef sender As Object, e As ReportDataArgs)

    Public Sub ChartBladeHeight_Data(ByRef sender As Object, e As ReportDataArgs)
        Const kHeightOffset As Double = 0.2 ' Offset to add to data points for visual comparison?
        Dim client As Chart = CType(sender, Chart)
        Dim refBlade As Integer? = CType(e.Args(0), Integer?)
        Dim refPoint As String = CType(e.Args(1), String)
        Dim refRadius As Double = CType(e.Args(2), Double)
        Dim data As JobDetail = CType(e.Args(3), JobDetail)

        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesHeight As Series = ChartCreateSeries(client, "BladeHeight", "Blade", "Height")
            Dim radiusMeasurements As List(Of RadiusMeasurement) = data?.RadiusMeasurements?.Where(Function(r) r.BladeId = refBlade).OrderBy(Function(r) CType(r.Radius, Double)).ToList()
            Dim innerRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault() ' RadiusMeasurement at smallest radius
            Dim outerRm As RadiusMeasurement = radiusMeasurements?.LastOrDefault()  ' RadiusMeasurement at largest radius
            Dim refRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)    ' RadiusMeasurement at reference radius
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)                 ' Depth at reference radius and point
            Dim refAngle As Double = TrackGetAngle(refRm, refPoint)                 ' Angle at reference radius and point
            ' Plot each blade's data points
            If innerRm Is Nothing Or outerRm Is Nothing Then
                Return
            End If
            For i As Integer = 1 To data.Job.PropellerBlades
                Dim b As Integer = i
                Dim rm As RadiusMeasurement = data?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = b)
                If rm IsNot Nothing Then
                    Dim bladeDepth As Double = TrackGetDepth(rm, refPoint)
                    Dim bladeHeight As Double = Math.Abs(refDepth - bladeDepth) + kHeightOffset
                    ChartAddPoint(client, seriesHeight, $"{b}", bladeHeight, (b = refBlade))
                End If
            Next
        End If
    End Sub

    Public Sub ChartAngularPosition_Data(ByRef sender As Object, e As ReportDataArgs)
        Const kHeightOffset As Double = 0.2 ' Offset to add to data points for visual comparison?
        Dim client As Chart = CType(sender, Chart)
        Dim refBlade As Integer? = CType(e.Args(0), Integer?)
        Dim refPoint As String = CType(e.Args(1), String)
        Dim refRadius As Double = CType(e.Args(2), Double)
        Dim data As JobDetail = CType(e.Args(3), JobDetail)

        If refBlade IsNot Nothing AndAlso refPoint IsNot Nothing AndAlso refRadius > 0 Then
            Dim seriesPosition As Series = ChartCreateSeries(client, "AngularPosition", "Blade", "Position")
            Dim radiusMeasurements As List(Of RadiusMeasurement) = data?.RadiusMeasurements?.Where(Function(r) r.BladeId = refBlade).OrderBy(Function(r) CType(r.Radius, Double)).ToList()
            Dim innerRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault() ' RadiusMeasurement at smallest radius
            Dim outerRm As RadiusMeasurement = radiusMeasurements?.LastOrDefault()  ' RadiusMeasurement at largest radius
            Dim refRm As RadiusMeasurement = radiusMeasurements?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)    ' RadiusMeasurement at reference radius
            Dim refDepth As Double = TrackGetDepth(refRm, refPoint)                 ' Depth at reference radius and point
            Dim refAngle As Double = TrackGetAngle(refRm, refPoint)                 ' Angle at reference radius and point

            ' Plot each blade's data points
            If innerRm Is Nothing Or outerRm Is Nothing Then
                Return
            End If
            For i As Integer = 1 To data.Job.PropellerBlades
                Dim b As Integer = i
                Dim rm As RadiusMeasurement = data?.RadiusMeasurements?.FirstOrDefault(Function(r) r.BladeId = b)
                If rm IsNot Nothing Then
                    Dim bladeAngle As Double = TrackGetAngle(rm, refPoint)
                    Dim bladePosition As Double = Math.Abs(refAngle - bladeAngle) - ((360 / data.Job.PropellerBlades) * Math.Abs(refBlade.Value - rm.BladeId.Value)) + kHeightOffset
                    ChartAddPoint(client, seriesPosition, $"{b}", bladePosition, (b = refBlade))
                End If
            Next
        End If
    End Sub
End Module
