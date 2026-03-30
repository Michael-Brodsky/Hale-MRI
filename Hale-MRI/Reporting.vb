Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDisplayControls.MRIMath
Imports LibDisplayControls.Tolerances

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

    Public Sub ChartPolarPlot_Data(ByRef sender As Object, e As ReportDataArgs)
        Dim ChartPlot As Chart = CType(sender, Chart)
        Dim mJobDetails As JobDetail = CType(e.Args(0), JobDetail)
        Dim TolClass As Tolerance = CType(e.Args(1), Tolerance)
        Dim basispitch As Double = CType(e.Args(2), Double)
        If mJobDetails Is Nothing Then Return

        ' Clear any existing chart areas and series.
        ChartPlot.ChartAreas.Clear()
        ChartPlot.Series.Clear()
        ChartPlot.Titles.Clear()

        ' Add a ChartArea and Title for the point graph
        Dim chartArea1 As New ChartArea()
        chartArea1.AxisX.MajorGrid.Enabled = False
        chartArea1.AxisY.MajorGrid.Enabled = False
        chartArea1.AxisX.LabelStyle.Enabled = False
        chartArea1.AxisY.LabelStyle.Enabled = False
        chartArea1.AxisX.MajorTickMark.Enabled = False
        chartArea1.AxisY.MajorTickMark.Enabled = False
        chartArea1.AxisX.LineWidth = 0
        chartArea1.AxisY.LineWidth = 0
        ChartPlot.ChartAreas.Add(chartArea1)

        ' Get a list of RadiusMeasurements for this JobDetail.
        Dim radiusMeasurements As List(Of RadiusMeasurement) =
            mJobDetails?.RadiusMeasurements _
            .OrderBy(Function(b) b.BladeId) _
            .ThenBy(Function(r) CType(r.Radius, Double)) _
            .ToList()
        ' The chart axes min/max values are the greatest radius value,
        ' this way the arcs always start at the outside of the chart area.
        chartArea1.AxisX.Maximum = kBladePlotAxesMax
        chartArea1.AxisX.Minimum = -chartArea1.AxisX.Maximum
        chartArea1.AxisY.Maximum = chartArea1.AxisX.Maximum
        chartArea1.AxisY.Minimum = -chartArea1.AxisY.Maximum
        ' Each RadiusMeasurement is a new Series of Points that circumscribes an arc
        ' having a radius equal to RadiusMeasurement.Radius. 
        For Each rm As RadiusMeasurement In radiusMeasurements
            Dim s As New Series With {
                .ChartType = SeriesChartType.Point,
                .MarkerStyle = MarkerStyle.Circle,
                .MarkerSize = 5
            }
            Dim cellMeasurements As List(Of CellMeasurement) = rm.CellMeasurements.ToList()
            Dim arcColors As New List(Of ToleranceColor)
            Dim sector As Integer = 1
            For sector = 1 To TolClass.LocalPitchSectors
                arcColors.Add(CheckLocalPitchTolerance(TolClass, GetLocalPitch(cellMeasurements, TolClass.LocalPitchSectors, sector, mJobDetails.Job.PropellerDiameter, rm.Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion), basispitch, True))
            Next
            Dim cellPerSector As Integer = CInt(Math.Floor(cellMeasurements.Count / TolClass.LocalPitchSectors))
            For i As Integer = 1 To cellMeasurements.Count - 1
                Dim currentSector As Integer = Math.Truncate(i / cellPerSector)
                Dim cmCurrent As CellMeasurement = cellMeasurements(i)
                Dim cmPrevious As CellMeasurement = cellMeasurements(i - 1)
                Dim angle As Double = (cmCurrent?.Angle + cmPrevious?.Angle) / 2
                Dim coordinates = PolarToCartesian(rm.Radius, angle)
                Dim p As Integer = s.Points.AddXY(coordinates.x, coordinates.y) ' Need a mathematical formula based on data in the dB or functions in MRIMath module x,y=f(a,b) ???
                Dim pointcolor As ToleranceColor = arcColors(Math.Min(currentSector, arcColors.Count - 1))
                s.Points(p).Color = ToColor(pointcolor)
            Next
            ChartPlot.Series.Add(s)
        Next
    End Sub
    Public Sub ChartBladeAverage_Data(ByRef Sender As Object, e As ReportDataArgs)
        Dim Graph As Chart = CType(Sender, Chart)
        Dim mJobDetails As JobDetail = CType(e.Args(0), JobDetail)
        Dim TolClass As Tolerance = CType(e.Args(1), Tolerance)
        Dim basispitch As Double = CType(e.Args(2), Double)

        Graph.Series.Clear()
        Graph.ChartAreas.Clear()
        Graph.Legends.Clear()
        Graph.Titles.Clear()
        Graph.Annotations.Clear()

        Dim cArea As ChartArea = Graph.ChartAreas.Add("BladeAverage")
        Dim ser As Series = Graph.Series.Add("Pitch")
        ser.ChartType = SeriesChartType.Bar
        ser.ChartArea = cArea.Name
        cArea.AxisY2.Enabled = AxisEnabled.False
        cArea.AxisX2.Enabled = AxisEnabled.False

        cArea.Axes(1).Minimum = 0
        cArea.Axes(1).Maximum = basispitch * 1.2
        cArea.Axes(1).Interval = 1
        cArea.Axes(1).MinorTickMark.Enabled = True
        cArea.Axes(1).MinorTickMark.Interval = 1
        cArea.Axes(1).MajorTickMark.Enabled = True
        cArea.Axes(1).MajorTickMark.Interval = 5
        cArea.Axes(1).MajorGrid.Enabled = True
        cArea.Axes(1).MajorGrid.Interval = basispitch * 1.2

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
        .IntervalOffset = basispitch - (basispitch * (TolClass.MeanPitchPerBladePercent / 100)),
        .StripWidth = 0.01,
        .BorderColor = Color.Black,
        .BorderWidth = 2,
        .Text = (basispitch - (basispitch * (TolClass.MeanPitchPerBladePercent / 100))).ToString(),
        .TextOrientation = TextOrientation.Horizontal,
        .TextLineAlignment = StringAlignment.Near,
        .ForeColor = Color.Red
    }
        cArea.Axes(1).StripLines.Add(slineunder)
        Dim slineover As New StripLine With {
        .IntervalOffset = basispitch + (basispitch * (TolClass.MeanPitchPerBladePercent / 100)),
        .StripWidth = 0.01,
        .BorderColor = Color.Black,
        .BorderWidth = 2,
        .Text = (basispitch + (basispitch * (TolClass.MeanPitchPerBladePercent / 100))).ToString(),
        .TextOrientation = TextOrientation.Horizontal,
        .TextLineAlignment = StringAlignment.Far,
        .ForeColor = Color.Blue
    }
        cArea.Axes(1).StripLines.Add(slineover)

    End Sub

    Public Sub ChartLocalPitchBarSectorsByBlade_Data(ByRef Sender As Object, e As ReportDataArgs)
        Dim Graph As Chart = CType(Sender, Chart)
        Dim mJobDetails As JobDetail = CType(e.Args(0), JobDetail)
        Dim TolClass As Tolerance = CType(e.Args(1), Tolerance)
        Dim Radius As Double = CType(e.Args(2), Double)
        Dim Basis As String = CType(e.Args(3), String)
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

        Graph.Titles.Clear()
        Graph.ChartAreas.Clear()
        Graph.Series.Clear()
        Graph.Legends.Clear()

        Dim cArea As ChartArea = Graph.ChartAreas.Add("Pitch")
        Dim x As Integer
        Dim y As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim ser As Series = Graph.Series.Add("Blade" + x.ToString())
            ser.ChartType = SeriesChartType.Column
            ser.ChartArea = cArea.Name
            ser.Color = GraphColorArray(x)
            Dim BladeData As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x And r.Radius = Radius).FirstOrDefault()
            For y = 1 To TolClass.LocalPitchSectors
                Dim localpitch As Double = GetLocalPitch(BladeData.CellMeasurements, TolClass.LocalPitchSectors, y, mJobDetails.Job.PropellerDiameter, Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                If y = 1 And TolClass.LocalPitchSectors = 1 Then
                    ser.Points.AddXY("Total Radius", localpitch)
                ElseIf y = 1 And TolClass.LocalPitchSectors <> 1 Then
                    ser.Points.AddXY("LE", localpitch)
                ElseIf y = TolClass.LocalPitchSectors And y <> 1 Then
                    ser.Points.AddXY("TE", localpitch)
                Else
                    ser.Points.AddXY(y.ToString(), localpitch)
                End If
            Next
        Next

        cArea.AxisY.Minimum = BasisPitch * 0.8
        cArea.AxisY.Maximum = BasisPitch * 1.2

        'need to handle striplines for Progressive pitch - measured against average for that section on that radius 
        ' also need to be able to make strip lines appear on one section of bars

        Dim leg As Legend = Graph.Legends.Add("Legend")
        leg.Alignment = StringAlignment.Center
        leg.Title = Radius.ToString() + "Radius - Compare to " + Basis + " - Minimums Apply"

        Dim title As Title = Graph.Titles.Add("TopTitle")
        If TolClass.ToleranceClass = "C" Then
            title.Text = "Local Pitch Custom Class"
        Else
            title.Text = "Local Pitch ISO 484 " + TolClass.ToleranceClass
        End If
        title = Graph.Titles.Add("YTitle")
        title.Alignment = ContentAlignment.TopCenter
        cArea.AxisY.Title = "Segment Pitch"


    End Sub

    Public Sub ChartLocalPitchBarBladesBySector_Data(ByRef Sender As Object, e As ReportDataArgs)
        Dim Graph As Chart = CType(Sender, Chart)
        Dim mJobDetails As JobDetail = CType(e.Args(0), JobDetail)
        Dim TolClass As Tolerance = CType(e.Args(1), Tolerance)
        Dim Radius As Double = CType(e.Args(2), Double)
        Dim Basis As String = CType(e.Args(3), String)
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

        Graph.Titles.Clear()
        Graph.ChartAreas.Clear()
        Graph.Series.Clear()
        Graph.Legends.Clear()

        Dim cArea As ChartArea = Graph.ChartAreas.Add("Pitch")
        Dim x As Integer
        Dim y As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim ser As Series = Graph.Series.Add("Blade" + x.ToString())
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
        Dim leg As Legend = Graph.Legends.Add("Legend")
        leg.Alignment = StringAlignment.Center
        leg.Title = Radius.ToString() + "Radius - Compare to " + Basis + " - Minimums Apply"

        Dim title As Title = Graph.Titles.Add("TopTitle")
        If TolClass.ToleranceClass = "C" Then
            title.Text = "Local Pitch Custom Class"
        Else
            title.Text = "Local Pitch ISO 484 " + TolClass.ToleranceClass
        End If
        title = Graph.Titles.Add("YTitle")
        title.Alignment = ContentAlignment.TopCenter
        cArea.AxisY.Title = "Segment Pitch"

    End Sub
    'make actual summary graph function

    'Public Sub ChartSummary_Data(ByRef Sender As Object, e As ReportDataArgs)
    '    Dim Graph As Chart = CType(Sender, Chart)
    '    Dim mJobDetails As JobDetail = CType(e.Args(0), JobDetail)
    '    Dim TolClass As Tolerance = CType(e.Args(1), Tolerance)
    '    Dim Basis As String = CType(e.Args(2), String)
    '    Dim APP As Boolean = CType(e.Args(3), Boolean)
    '    Dim BasisPitch As Double
    '    If Basis = "Marked" Then
    '        BasisPitch = mJobDetails.Job.MarkedPitch
    '    ElseIf Basis = "Desired" Then
    '        BasisPitch = mJobDetails.Job.DesiredPitch
    '    ElseIf Basis = "Design" Then
    '        BasisPitch = 0
    '    Else
    '        Basis = "Mean"
    '        BasisPitch = mJobDetails.WheelPitch
    '    End If
    '    Graph.Titles.Clear()
    '    Graph.ChartAreas.Clear()
    '    Graph.Series.Clear()
    '    Graph.Legends.Clear()
    '    Dim cArea As ChartArea = Graph.ChartAreas.Add("Summary")
    '    Dim leg As Legend = Graph.Legends.Add("Legend")
    '    leg.Alignment = StringAlignment.Center
    '    leg.Docking = Docking.Top
    '    leg.Title = mJobDetails.Job.Vessel.Customer.ToString() + " " + mJobDetails.Job.Vessel.VesselName.ToString() + " " + mJobDetails.Job.PropellerRotation.ToString() + " " + mJobDetails.StartDate.ToString() + " Class " + mJobDetails.ToleranceClass.ToString()
    '    Graph.Titles.Add("Title").Text = "Hale MRI - Summary Graph"
    '    cArea.AxisY.Title = "Pitch"
    '    cArea.AxisX.MajorGrid.Enabled = False
    '    cArea.AxisX.MinorGrid.Enabled = False
    '    cArea.AxisX.MinorTickMark.Enabled = False
    '    cArea.AxisY.Minimum = BasisPitch * 0.8
    '    cArea.AxisY.Maximum = BasisPitch * 1.2
    '    cArea.AxisY.Interval = BasisPitch * 0.1
    '    cArea.AxisY.MajorGrid.Enabled = False
    '    cArea.AxisY.MinorGrid.Enabled = False
    '    cArea.AxisY.MajorTickMark.Enabled = True
    '    cArea.AxisY.MinorTickMark.Enabled = True
    '    Graph.Annotations.Clear()
    '    Graph.Annotations.Add(New TextAnnotation With {
    '                          .Text = "Tol Basis - " + Basis + " Pitch = " + BasisPitch.ToString(),
    '                          .AnchorX = 0.25,
    '                          .AnchorY = 0.25
    '    })
    '    If APP Then
    '        Graph.Annotations.Add(New TextAnnotation With {
    '                              .Text = "Allow Progressive Pitch",
    '                              .AnchorX = 0.25,
    '                              .AnchorY = 0.3
    '        })
    '    End If ' play with location to put in correct position
    '    Dim x As Integer
    '    For x = 1 To mJobDetails.Job.PropellerBlades
    '        Dim ser As Series = Graph.Series.Add("Blade" + x.ToString())
    '        Dim avgpitch As Double = 0
    '        Dim pitchcount As Integer = 0
    '        ser.ChartType = SeriesChartType.Column
    '        ser.ChartArea = cArea.Name
    '        ser.Color = GraphColorArray(x)
    '        Dim BladeData As List(Of RadiusMeasurement) = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
    '        For Each rm As RadiusMeasurement In BladeData
    '            Dim pitch = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
    '            avgpitch += pitch
    '            pitchcount += 1
    '            ser.Points.AddXY(Math.Round(CType(rm.Radius, Double)).ToString(), pitch)
    '            If x = 1 Then ' set up strip lines on each column based on tolerance class and APP
    '                If APP = False Then
    '                    Dim sline As New StripLine With {
    '                        .IntervalOffset = BasisPitch - (BasisPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Blue,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                        }
    '                    cArea.AxisY.StripLines.Add(sline)
    '                    sline = New StripLine With {
    '                        .IntervalOffset = BasisPitch + (BasisPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Red,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                    }
    '                    cArea.AxisY.StripLines.Add(sline)
    '                    sline = New StripLine With {
    '                        .IntervalOffset = BasisPitch,
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Black,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                    }
    '                Else
    '                    Dim appPitch As Double = 0
    '                    For Each rm2 As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(rad) Math.Round(rad.Radius.Value) = Math.Round(rm.Radius.Value))
    '                        appPitch += GetAverageBladePitch(rm2.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
    '                    Next
    '                    appPitch /= mJobDetails.Job.PropellerBlades
    '                    Dim sline As New StripLine With {
    '                        .IntervalOffset = appPitch - (appPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Blue,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                    }
    '                    cArea.AxisY.StripLines.Add(sline)
    '                    sline = New StripLine With {
    '                        .IntervalOffset = appPitch + (appPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Red,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                    }
    '                    cArea.AxisY.StripLines.Add(sline)
    '                    sline = New StripLine With {
    '                        .IntervalOffset = appPitch,
    '                        .BorderWidth = 1,
    '                        .BorderDashStyle = ChartDashStyle.Solid,
    '                        .BorderColor = Color.Black,
    '                        .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
    '                    }
    '                End If
    '            End If
    '        Next
    '        avgpitch /= pitchcount
    '        ser.Points.AddXY("Bld Avg", avgpitch)
    '    Next
    '    Dim seri As Series = Graph.Series.Add("Wheel")
    '    seri.ChartType = SeriesChartType.Column
    '    seri.ChartArea = cArea.Name
    '    seri.Color = GraphColorArray(3)
    '    seri.Points.AddXY("Wheel Avg", mJobDetails.WheelPitch)

    'End Sub

#Region "Tables"
    Public Function UpdateRadiiAveragesTable(mJobDetails As JobDetail, Design As Boolean) As DataTable
        Dim mJob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("r/R", GetType(Integer))
        Dim rowRadiusBlade As DataRow

        For Each radmeas As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1)
            rowRadiusBlade = dtBladePitchByRadius.Rows.Add(Math.Round(radmeas.Radius.Value).ToString + " %")
        Next
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value).ToString + " %" = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(dtBladePitchByRadius.Rows.Find(Math.Round(rm.Radius.Value).ToString + " %"), dtBladePitchByRadius.Rows.Add(rm.Radius.Value).ToString + " %")
                colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim meancol As DataColumn = If(dtBladePitchByRadius.Columns("Mean"), dtBladePitchByRadius.Columns.Add("Mean", GetType(Double)))
            Dim avgPitch As Double = totalPitch / pitchCount
            row.Item(meancol) = Math.Round(avgPitch, 2)
            If Design Then
                Dim designcol As DataColumn = If(dtBladePitchByRadius.Columns("Design"), dtBladePitchByRadius.Columns.Add("Design", GetType(Double)))
                'add if here for design loaded check use design pitch if loaded and ref if not
                row.Item(designcol) = Math.Round(mJob.DesiredPitch.Value, 2)
            End If
        Next
        Return dtBladePitchByRadius
    End Function
    Public Function UpdateChordLengthTable(mJobDetails As JobDetail) As DataTable
        Dim mjob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtChordLength As New DataTable()
        Dim colRadius As DataColumn = dtChordLength.Columns.Add("Blade", GetType(Integer))
        Dim rowBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob?.PropellerBlades
            dtChordLength.Rows.Add(x)
        Next
        dtChordLength.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtChordLength.Rows
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowBlade = If(dtChordLength.Rows.Find(rm.BladeId), dtChordLength.Rows.Add(rm.BladeId))
                colRadius = If(dtChordLength.Columns(radiusPercent), dtChordLength.Columns.Add(radiusPercent, GetType(Double)))
                Dim ChordLength As Double = GetChordLength(rm.CellMeasurements.FirstOrDefault.Angle.Value, rm.CellMeasurements.LastOrDefault.Angle.Value, rm.CellMeasurements.FirstOrDefault.Depth.Value, rm.CellMeasurements.LastOrDefault.Depth.Value, mjob.PropellerDiameter, CInt(radiusPercent))
                rowBlade.Item(colRadius) = Math.Round(ChordLength, 2)
            Next
            colRadius = If(dtChordLength.Columns("Track"), dtChordLength.Columns.Add("Track", GetType(Double))) ' need to figure out what this is
        Next
        Return dtChordLength
    End Function

    Public Function UpdateISOTOLTable(basispitch As Double, Tolclass As Tolerance, Mins As Boolean) As DataTable
        Dim ISOTable As New DataTable()
        ISOTable.Columns.Add("TolType", GetType(String))
        ISOTable.Columns.Add("MinsApply", GetType(String))
        ISOTable.Columns.Add("TolPerc", GetType(String))
        ISOTable.Columns.Add("PlusMinus", GetType(String))
        ISOTable.Columns.Add("OverUnder", GetType(String))

        'Local Pitch
        Dim RowLocal As DataRow = ISOTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("MinsApply") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.LocalPitchPercent.ToString() & " %"
        Dim MinMax As Double
        MinMax = basispitch * (Tolclass.LocalPitchPercent / 100)
        If Mins And MinMax < Tolclass.LocalPitchMinimum * kMmToInch Then 'need checks for SYS type
            MinMax = Tolclass.LocalPitchMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " / " + (basispitch - MinMax)

        'Radius Average
        RowLocal = ISOTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerRadiusPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerRadiusPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerRadiusMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerRadiusMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Blade Average
        RowLocal = ISOTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerBladePercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerBladePercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerBladeMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerBladeMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Propeller Average
        RowLocal = ISOTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchForPropellerPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchForPropellerPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchForPropellerMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchForPropellerMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"
        If Mins <> True Then
            ISOTable.Columns.RemoveAt(1)
        End If
        Return ISOTable
    End Function

    Public Function UpdateLocalPitchTable(mJobDetails As JobDetail, TolClass As Tolerance)
        Dim dtLPTable As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim rowRad As DataRow
        Dim colBlade As DataColumn
        Dim x As Integer
        Dim y As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                colBlade = dtLPTable.Columns.Add("RadCol")
                rowRad = dtLPTable.Rows.Add("BladeRow")
                rowRad.Item("RadCol") = "r/R"
            Else
                For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                    rowRad = If(dtLPTable.Rows.Find(rm.Radius.Value.ToString()), dtLPTable.Rows.Add(rm.Radius.Value.ToString()))
                    For y = 1 To TolClass.LocalPitchSectors
                        colBlade = If(dtLPTable.Columns("Blade" + rm.BladeId.ToString() + y.ToString()), dtLPTable.Columns.Add("Blade" + rm.BladeId.ToString() + y.ToString()))
                        rowRad.Item("Blade" + rm.BladeId.ToString() + y.ToString()) = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, y, mJob.PropellerBlades, rm.Radius, mJob.TeExclusion, mJob.LeExclusion)
                    Next
                Next
            End If
        Next
        Return dtLPTable
    End Function

    Public Function UpdateBladeAveragesTable(mJobDetails As JobDetail) As DataTable
        Dim dtbladeaverage As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim pitchrow As DataRow = dtbladeaverage.Rows.Add("Pitch")
        Dim BladeCol As DataColumn
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            BladeCol = dtbladeaverage.Columns.Add("Blade" + x)
            Dim pitchtotal As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                pitchtotal += GetAverageBladePitch(rm.CellMeasurements, mJob.TeExclusion, mJob.LeExclusion)
                pitchcount += 1
            Next
            pitchrow.Item(BladeCol) = pitchtotal / pitchcount
        Next
        Return dtbladeaverage
    End Function

    Public Function UpdateFederalToleranceListTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = ".75 %"
        MinMax = BasisPitch * (0.75 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.01
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateMichiganToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateStandardToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateManualInspTable() As DataTable
        Dim dtManualInsp As New DataTable()
        dtManualInsp.Columns.Add("InspectionItem", GetType(String))
        dtManualInsp.Columns.Add("Yes", GetType(String))
        dtManualInsp.Columns.Add("No", GetType(String))

        Dim row As DataRow = dtManualInsp.Rows.Add("ACCEPTABLE")
        row.Item("InspectionItem") = "ACCEPTABLE"
        row.Item("Yes") = "YES"
        row.Item("No") = "NO"
        row = dtManualInsp.Rows.Add("Blade Surface")
        row.Item("InspectionItem") = "Blade Surface"
        row = dtManualInsp.Rows.Add("Blade Edges")
        row.Item("InspectionItem") = "BladeEdges"
        row = dtManualInsp.Rows.Add("Static Balance")
        row.Item("Inspectionitem") = "Static Balance"
        row = dtManualInsp.Rows.Add("Thcikness")
        row.Item("InspectionItem") = "Thickness"
        row = dtManualInsp.Rows.Add("Bore")
        row.Item("InspectionItem") = "Bore"
        row = dtManualInsp.Rows.Add("Keyway")
        row.Item("InspectionItem") = "KeyWay"
        Return dtManualInsp
    End Function

    Public Function UpdateRadiusToleranceTable(Diameter As Double, TolClass As Tolerance) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Min")
        tolTable.Columns.Add("Design")
        tolTable.Columns.Add("Max")

        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Min") = "Min"
        row.Item("Design") = "Design"
        row.Item("Max") = "Max"
        row = tolTable.Rows.Add("Tolerance")
        Dim mintol As Double = (Diameter / 2) - ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Min") = Math.Round(mintol, 2)
        row.Item("Design") = Math.Round(Diameter / 2, 2)
        Dim maxtol As Double = (Diameter / 2) + ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Max") = Math.Round(maxtol, 2)
        Return tolTable
    End Function

    Public Function UpdateTrackToleranceTable(BasisPitch As Double) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Tolerance")
        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Tolerance") = "Track Tolerance"
        row = tolTable.Rows.Add("MinMax")
        Dim minmax = BasisPitch * 0.01
        row.Item("Tolerance") = minmax.ToString()
        Return tolTable
    End Function

    Public Function UpdateRadiusBladeWheelAveragePitchTable(mJobDetails As JobDetail, TolClass As Tolerance, Basispitch As Double) As DataTable
        Dim Table As New DataTable()
        Dim mjob As Job = mJobDetails.Job

        Dim colRadius As DataColumn = Table.Columns.Add("Blade", GetType(Integer))
        Dim rowRadiusBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob.PropellerBlades
            rowRadiusBlade = Table.Rows.Add(x)
        Next
        Table.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In Table.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0 ' Condensed these for loops into one to increase speed
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(Table.Rows.Find(rm.BladeId), Table.Rows.Add(rm.BladeId))
                colRadius = If(Table.Columns(radiusPercent), Table.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mjob.TeExclusion, mjob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim avgPitch As Double = totalPitch / pitchCount
            colRadius = If(Table.Columns("Average"), Table.Columns.Add("Average", GetType(Double)))
            row.Item(colRadius) = Math.Round(avgPitch, 2)
            colRadius = If(Table.Columns("Wheel"), Table.Columns.Add("Wheel", GetType(Double)))
            row.Item(colRadius) = mJobDetails.WheelPitch.Value
        Next
        rowRadiusBlade = Table.Rows.Add("Allow")
        Dim minmax As Double
        minmax = Basispitch * (TolClass.MeanPitchPerRadiusPercent / 100)
        Dim allow As String = (Basispitch + minmax).ToString() + " / " + (Basispitch - minmax).ToString()
        For Each col As DataColumn In Table.Columns
            If col.ColumnName = "Blade" Then
                rowRadiusBlade.Item(col) = "Allow"
            ElseIf col.ColumnName = "Average" Or col.ColumnName = "Wheel" Then
                rowRadiusBlade.Item(col) = "± " + TolClass.MeanPitchPerRadiusPercent / 100 + "%"
            Else
                rowRadiusBlade.Item(col) = allow
            End If
        Next
        Return Table
    End Function

    Public Function UpdateSkewTable(mJobDetails As JobDetail) As DataTable
        Dim dtable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim BladeCol As DataColumn = dtable.Columns.Add("Radius", GetType(String))
        Dim RadRow As DataRow
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            Dim ReferenceRadius As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).FirstOrDefault()
            Dim ReferenceAngle As Double = GetChordMidAngle(ReferenceRadius.CellMeasurements)
            Dim ReferenceDepth As Double = GetChordMidDepth(ReferenceRadius.CellMeasurements)
            BladeCol = dtable.Columns.Add("Blade" + x, GetType(String))
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                RadRow = If(dtable.Rows.Find(Math.Round(rm.Radius.Value, 2)), dtable.Rows.Add(Math.Round(rm.Radius.Value, 2)))
                If x = 1 Then
                    RadRow.Item("Radius") = rm.Radius + "%"
                End If
                If rm.Radius = ReferenceRadius.Radius Then
                    RadRow.Item(BladeCol) = "Ref"
                Else
                    Dim rmdepth As Double = GetChordMidDepth(rm.CellMeasurements)
                    Dim rmangle As Double = GetChordMidAngle(rm.CellMeasurements)
                    Dim anglediff As Double = rmangle - ReferenceAngle
                    Dim chordDiff As Double = GetChordLength(ReferenceAngle, rmangle, ReferenceDepth, rmdepth, mJob.PropellerDiameter, rm.Radius)
                    Dim diffs As String = anglediff + "Deg / " + chordDiff + " In"
                    RadRow.Item(BladeCol) = diffs
                End If
            Next
        Next
        Return dtable
    End Function

    Public Function UpdateAngularSpacingTable(mJobDetails As JobDetail) As DataTable
        Dim dTable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim bladecol As DataColumn = dTable.Columns.Add("Blade", GetType(String))
        bladecol = dTable.Columns.Add("Ang", GetType(String))
        Dim bladerow As DataRow
        Dim x As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                bladerow = dTable.Rows.Add("Design")
                bladerow.Item("Blade") = "Design"
                bladerow.Item("Ang") = (360 / mJob.PropellerBlades).ToString() + " Deg"
            Else
                bladerow = dTable.Rows.Add("Blade" + x.ToString())
                bladerow.Item("Blade") = "Blade " + x.ToString()
                If x = 1 Then
                    bladerow.Item("Ang") = "Ref"
                Else
                    Dim refangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1 And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim currangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim anglespace As Double = currangle - refangle - ((360 / mJob.PropellerBlades) * (x - 1))
                    bladerow.Item("Ang") = anglespace.ToString("F2") + " Deg"
                End If
            End If
        Next
        Return dTable
    End Function
#End Region
#Region "Graphs"
    'Public Sub UpdateLineGraph(rm As RadiusMeasurement, LineChart As Chart, Database As HaleMRIContext, Optional Progcm As List(Of CellMeasurement) = Nothing, Optional Trackcm As List(Of CellMeasurement) = Nothing)
    '    'Might have to change this as it directly pulls the visual, including scaling loaded progression and all other settings, from the comparison form

    '    'this is a group of variables that will be pulled from the comparison form. They will be given set values for testing purposes
    '    Dim centerRef As Boolean = True ' dictates whether the reference heights are calculated from the start or center of the chord
    '    Dim RefPitch As Double = 22
    '    Dim entireScan As Boolean = False ' handles the exclusion zones, if true no exclusion zones are applied
    '    Dim showTrack As Boolean = True ' handles whether or not to use the HeightAtRefPoint from the tracked blade or the current radius measurement
    '    Dim HeightAtRefPoint As Double = 0.0 ' this value is only used to modify the actual LPline series the tolerance lines and reference lines are not affected by it
    '    Dim spline As Boolean = False ' dictates whether the graph lines are spline or straight lines
    '    Dim AxesScaling As Double = 1.0
    '    Dim refheights As List(Of Double) = GetRefHeightsStraight(centerRef, RefPitch, rm.JobDetails.Job.PropellerBlades)

    '    Dim LEE As Double = rm.JobDetails.Job.LeExclusion.Value
    '    Dim TEE As Double = rm.JobDetails.Job.TeExclusion.Value
    '    If entireScan Then
    '        LEE = 0
    '        TEE = 0
    '    End If

    '    LineChart.Series.Clear()
    '    LineChart.ChartAreas.Clear()
    '    LineChart.Legends.Clear()
    '    LineChart.Titles.Clear()
    '    LineChart.Annotations.Clear()

    '    LineChart.PaletteCustomColors = GraphColorArray
    '    Dim cArea As ChartArea = LineChart.ChartAreas.Add("LPLineArea")
    '    Dim ser As Series = LineChart.Series.Add("LPLineSeries")
    '    Dim refser As Series = LineChart.Series.Add("Ref")
    '    Dim tolhighser As Series = LineChart.Series.Add("TolHigh")
    '    Dim tollowser As Series = LineChart.Series.Add("TolLow")

    '    Dim x As Integer
    '    If Progcm Is Nothing Then 'all creation and management of reference and tolerance lines are handled here
    '        For x = 0 To 10
    '            refser.Points.Add(x * 10, 0)
    '        Next
    '        If showTrack = True Then
    '            If centerRef Then
    '                HeightAtRefPoint = GetLocalHeightEndSector(Trackcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) 'need to be able to pull ref points from tracked blade
    '            Else
    '                HeightAtRefPoint = GetLocalHeightStartSector(Trackcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '            End If
    '        Else
    '            If centerRef Then
    '                HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '            Else
    '                HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '            End If
    '        End If
    '    Else
    '        Dim tollisthigh As List(Of Double) = GetRefHeightsHighTol(centerRef, RefPitch, GetToleranceTable(Database, rm.JobDetails.ToleranceClass), rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
    '        Dim tollistlow As List(Of Double) = GetRefHeightsLowTol(centerRef, RefPitch, GetToleranceTable(Database, rm.JobDetails.ToleranceClass), rm.JobDetails.Job.PropellerBlades, rm.CellMeasurements)
    '        For x = 0 To 10
    '            Dim height As Double
    '            If x = 0 Then
    '                height = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '            Else
    '                height = GetLocalHeightEndSector(Progcm, 10, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '            End If
    '            height -= refheights(x)  'need to add a change in here that changes height based on center ref point and the ref height at that point
    '            refser.Points.Add(x * 10, height)
    '            tolhighser.Points.Add(x * 10, tollisthigh(x))
    '            tollowser.Points.Add(x * 10, tollistlow(x))
    '            If showTrack = True Then
    '                If centerRef Then
    '                    HeightAtRefPoint = GetLocalHeightEndSector(Progcm, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '                Else
    '                    HeightAtRefPoint = GetLocalHeightStartSector(Progcm, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '                End If
    '            Else
    '                If centerRef Then
    '                    HeightAtRefPoint = GetLocalHeightEndSector(rm.CellMeasurements, 10, 5, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '                Else
    '                    HeightAtRefPoint = GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE)
    '                End If
    '            End If
    '        Next
    '    End If
    '    Dim newheights As New List(Of Double)
    '    For x = 0 To 10
    '            newheights.Add(refheights(x) + HeightAtRefPoint)
    '        Next

    '        Dim lpline As New List(Of Double)
    '    For x = 0 To 10
    '        If x = 0 Then
    '            lpline.Add(GetLocalHeightStartSector(rm.CellMeasurements, 10, 1, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
    '        Else
    '            lpline.Add(GetLocalHeightEndSector(rm.CellMeasurements, 10, x, rm.JobDetails.Job.PropellerDiameter, rm.Radius, TEE, LEE) - newheights(x))
    '        End If
    '        ser.Points.Add(x * 10, lpline(x))
    '    Next

    '    'need a for loop that edits the lpline heights based on the reference height at that point
    '    If spline = False Then
    '        ser.ChartType = SeriesChartType.Line
    '        refser.ChartType = SeriesChartType.Line
    '        tollowser.ChartType = SeriesChartType.Line
    '        tolhighser.ChartType = SeriesChartType.Line
    '    Else
    '        ser.ChartType = SeriesChartType.Spline
    '        refser.ChartType = SeriesChartType.Spline
    '        tollowser.ChartType = SeriesChartType.Spline
    '        tolhighser.ChartType = SeriesChartType.Spline
    '    End If

    '    refser.ChartArea = cArea.Name
    '    tolhighser.ChartArea = cArea.Name
    '    tollowser.ChartArea = cArea.Name
    '    ser.ChartArea = cArea.Name
    '    LineChart.ChartAreas(0).Position.Auto = False
    '    LineChart.ChartAreas(0).Position.Height = 100
    '    LineChart.ChartAreas(0).Position.Width = 100
    '    LineChart.ChartAreas(0).AxisX.Minimum = -5
    '    LineChart.ChartAreas(0).AxisX.Maximum = 105
    '    LineChart.ChartAreas(0).AxisY.Minimum = -AxesScaling ' need to add control for managing y Axis Scaling
    '    LineChart.ChartAreas(0).AxisY.Maximum = AxesScaling
    'End Sub



    Private Sub UpdateRadiusBladeWheelAveragePitchGraph(Graph As Chart, mJobDetails As JobDetail, TolClass As Tolerance, basispitch As Double)
        Graph.ChartAreas.Clear()
        Graph.Series.Clear()
        Graph.Legends.Clear()
        Graph.Titles.Clear()
        Dim cArea As ChartArea = Graph.ChartAreas.Add("Area1")
        Dim x As Integer
        Dim proppitch As Double = 0
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim ser As Series = Graph.Series.Add("Blade" + x.ToString())
            ser.ChartArea = "Area1"
            Dim totpitch As Double = 0
            ser.ChartType = SeriesChartType.Bar
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                Dim avgpitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                Dim pointind As Integer = ser.Points.AddXY(Math.Round(rm.Radius.Value).ToString() + "%", avgpitch)
                totpitch += avgpitch
                ser.Points(pointind).Color = GraphColorArray(x - 1)
            Next
            Dim meanpitch As Double = totpitch / mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).Count()
            ser.Points.AddXY("Bld Avg", meanpitch)
            proppitch += meanpitch
        Next
        Dim propavg As Double = proppitch / mJobDetails.Job.PropellerBlades
        Dim serprop As Series = Graph.Series.Add("Wheel Avg")
        serprop.ChartArea = "Area1"
        serprop.ChartType = SeriesChartType.Bar
        serprop.Points.AddXY("Wheel Avg", propavg)

        cArea.AxisY.Minimum = basispitch * 0.8
        cArea.AxisY.Maximum = basispitch * 1.2

        Dim sline As New StripLine With {
            .IntervalOffset = basispitch * 1 - (TolClass.MeanPitchPerBladePercent / 100),
            .StripWidth = basispitch * (TolClass.MeanPitchPerBladePercent / 100) * 2,
            .BorderColor = Color.Red,
            .BorderWidth = 2,
            .ForeColor = Color.Green
        }
        cArea.AxisY.StripLines.Add(sline)
        Dim leg As Legend = Graph.Legends.Add("Legends")
        leg.Docking = Docking.Top
    End Sub
#End Region
End Module
