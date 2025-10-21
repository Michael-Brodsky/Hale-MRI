Imports System.Windows.Forms.DataVisualization.Charting

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
End Module
