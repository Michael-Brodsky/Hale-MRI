Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Module Graphing
    Public Function ChartCreateSeries(ByVal chart As Chart, ByVal name As String, ByVal xaxis As String, ByVal yaxis As String) As Series
        ' Returns a new Series added to the given Chart with the given axis labels.
        Dim newSeries As New Series With {
            .Name = name,
            .ChartType = SeriesChartType.Column,
            .XValueMember = xaxis,
            .YValueMembers = yaxis,
            .IsXValueIndexed = True,
            .IsVisibleInLegend = False
        }
        chart.Series.Clear()
        chart.Series.Add(newSeries)
        Return newSeries
    End Function

    Public Sub ChartAddPoint(ByVal chart As Chart, ByVal series As Series, ByVal x As String, ByVal y As Double, isRefBlade As Boolean)
        Dim barColors As Color() = {Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple} ' Teletubbies!
        Dim p As Integer = chart.Series(series.Name).Points.AddXY(x, y)
        chart.Series(series.Name).Points(p).Color = If(isRefBlade, Color.Black, barColors(p Mod barColors.Length))
    End Sub

    Public Function SeriesBladeHeight(ByVal rm As List(Of RadiusMeasurement), ByVal bladeCount As Integer, ByVal refBlade As Integer, ByVal refPoint As String, ByVal refRadius As String) As Series
        Const kHeightOffset As Double = 0.2 ' Adjust as needed to set zero height
        Dim s As New Series With {
            .ChartType = SeriesChartType.Column,
            .IsXValueIndexed = True,
            .IsVisibleInLegend = False
        }
        Dim innerRm As RadiusMeasurement = rm?.FirstOrDefault()
        Dim innerDepth As Double = TrackGetDepth(innerRm, refPoint)
        Dim outerRm As RadiusMeasurement = rm?.LastOrDefault()
        Dim outerDepth As Double = TrackGetDepth(outerRm, refPoint)
        Dim refRm As RadiusMeasurement = rm?.FirstOrDefault(Function(r) Math.Round(CType(r.Radius, Double)) = refRadius)
        Dim refDepth As Double = TrackGetDepth(refRm, refPoint)
        Dim refAngle As Double = TrackGetAngle(refRm, refPoint)
        For i As Integer = 1 To bladeCount
            Dim b As Integer = i
            Dim bladeRadius As RadiusMeasurement = rm?.FirstOrDefault(Function(r) r.BladeId = b)
            Dim bladeDepth As Double = TrackGetDepth(bladeRadius, refPoint)
            Dim bladeHeight As Double = Math.Abs(refDepth - bladeDepth) + kHeightOffset
            Dim p As Integer = s.Points.AddXY($"{b}", bladeHeight)
        Next
        Return s
    End Function

    Public Function TrackGetAngle(ByVal rm As RadiusMeasurement, ByVal point As String) As Double
        ' Returns the Angle CellMeasurement for the given RadiusMeasurement at the given point (LE, Mid or TE).
        Dim angle As Double = 0.0
        If rm IsNot Nothing AndAlso Not String.IsNullOrEmpty(point) Then
            Select Case point
                Case "LE"
                    angle = rm.CellMeasurements.FirstOrDefault()?.Angle
                Case "Mid"
                    angle = rm.CellMeasurements.ElementAt(rm.CellMeasurements.Count \ 2)?.Angle
                Case "TE"
                    angle = rm.CellMeasurements.LastOrDefault()?.Angle
                Case Else
            End Select
        End If
        Return angle
    End Function

    Public Function TrackGetDepth(ByVal rm As RadiusMeasurement, ByVal point As String) As Double
        ' Returns the Depth CellMeasurement for the given RadiusMeasurement at the given point (LE, Mid or TE).
        Dim depth As Double = 0.0
        If rm IsNot Nothing AndAlso Not String.IsNullOrEmpty(point) Then
            Select Case point
                Case "LE"
                    depth = rm.CellMeasurements.FirstOrDefault()?.Depth
                Case "Mid"
                    depth = rm.CellMeasurements.ElementAt(rm.CellMeasurements.Count \ 2)?.Depth
                Case "TE"
                    depth = rm.CellMeasurements.LastOrDefault()?.Depth
                Case Else
            End Select
        End If
        Return depth
    End Function

End Module
