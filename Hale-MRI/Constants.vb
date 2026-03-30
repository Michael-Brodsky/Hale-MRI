Imports System.Windows.Forms.DataVisualization.Charting

''' <summary>
''' Defines numeric constants used throughout the application.
''' </summary>
''' 
Module Constants
    Public Const kNoCurrentRecord As Integer = -1
    Public Const kNoCurrentSelection As Integer = -1
    Public Const kBladePlotAxesMax As Integer = 100
    Public Const kBladePlotChartType As SeriesChartType = SeriesChartType.Point
    Public Const kBladePlotMarkerSize As Integer = 5
    Public Const kBladePlotMarkerStyle As MarkerStyle = MarkerStyle.Circle
    Public Const kInchToMm As Double = 25.4 ' Multiply inches by this to get millimeters
    Public Const kMmToInch As Double = 0.0393701 ' Multiply millimeters by this to get inches
    Public Const kEncoderPollingIntervalDefault As Integer = 5
End Module
