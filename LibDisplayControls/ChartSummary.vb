Imports System.Windows.Forms.DataVisualization.Charting
Imports Accessibility
Imports LibDatabase.Models

Public Class ChartSummary
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
    ''' Tolerance Class for Chart1
    ''' </summary>
    ''' <returns>ToleranceClass</returns>
    Public Property TolClass As Tolerance = Nothing
    ''' <summary>
    ''' Basis pitch style used for tolerance lines
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Basis As String = Nothing
    ''' <summary>
    ''' Allow progressive pitch for tolerance lines
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property APP As Boolean = False
#End Region
#Region "Computed Properties"
    ''' <summary>
    ''' Basis pitch value used for tolerance lines based on Basis property and JobDetails data
    ''' </summary>
    ''' <returns>Double</returns>
    Private ReadOnly Property BasisPitch As Double
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
                TolClass Is Nothing OrElse
            String.IsNullOrEmpty(Basis) Then
            Return
        End If
        Me.SuspendLayout()
        Chart1.Titles.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Dim bp As Double = BasisPitch
        Dim cArea As ChartArea = Chart1.ChartAreas.Add("Summary")
        Dim leg As Legend = Chart1.Legends.Add("Legend")
        leg.Alignment = StringAlignment.Center
        leg.Docking = Docking.Top
        leg.Title = mJobDetails.Job.Vessel.Customer.ToString() + " " + mJobDetails.Job.Vessel.VesselName.ToString() + " " + mJobDetails.Job.PropellerRotation.ToString() + " " + mJobDetails.StartDate.ToString() + " Class " + mJobDetails.ToleranceClass.ToString()
        Chart1.Titles.Add("Title").Text = "Hale MRI - Summary Chart1"
        cArea.AxisY.Title = "Pitch"
        cArea.AxisX.MajorGrid.Enabled = False
        cArea.AxisX.MinorGrid.Enabled = False
        cArea.AxisX.MinorTickMark.Enabled = False
        cArea.AxisY.Minimum = bp * 0.8
        cArea.AxisY.Maximum = bp * 1.2
        cArea.AxisY.Interval = bp * 0.1
        cArea.AxisY.MajorGrid.Enabled = False
        cArea.AxisY.MinorGrid.Enabled = False
        cArea.AxisY.MajorTickMark.Enabled = True
        cArea.AxisY.MinorTickMark.Enabled = True
        Chart1.Annotations.Clear()
        Chart1.Annotations.Add(New TextAnnotation With {
                              .Text = "Tol Basis - " + Basis + " Pitch = " + bp.ToString(),
                              .AnchorX = 0.25,
                              .AnchorY = 0.25
        })
        If APP Then
            Chart1.Annotations.Add(New TextAnnotation With {
                                  .Text = "Allow Progressive Pitch",
                                  .AnchorX = 0.25,
                                  .AnchorY = 0.3
            })
        End If ' play with location to put in correct position
        Dim I As Integer
        Dim x As Integer
        PitchTable.Controls.Clear()
        PitchTable.RowCount = 1
        PitchTable.ColumnCount = 1
        For x = 1 To mJobDetails.Job.PropellerBlades
            PitchTable.RowCount += 1
            BladeTable.RowCount += 1
            Dim bt As New TextBox With {.Text = "Blade " + x,
                .Dock = DockStyle.Fill,
                .TextAlign = HorizontalAlignment.Center}
            BladeTable.Controls.Add(bt, 0, x - 1)
            Dim ser As Series = Chart1.Series.Add("Blade" + x.ToString())
            Dim avgpitch As Double = 0
            Dim pitchcount As Integer = 0
            ser.ChartType = SeriesChartType.Column
            ser.ChartArea = cArea.Name
            ser.Color = GraphColorArray(x)
            Dim BladeData As List(Of RadiusMeasurement) = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
            Dim y As Integer = 0
            For Each rm As RadiusMeasurement In BladeData
                y += 1
                If x = 1 Then
                    PitchTable.ColumnCount += 1
                End If
                Dim pitch = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                avgpitch += pitch
                pitchcount += 1
                ser.Points.AddXY(Math.Round(CType(rm.Radius, Double)).ToString(), pitch)
                Dim fc As Color = ToColor(CheckBladeRadiusPitch(TolClass, pitch, bp, False))
                Dim txt As New TextBox With {.Text = Math.Round(pitch, 3).ToString(),
                    .ForeColor = fc,
                    .Dock = DockStyle.Fill,
                .TextAlign = HorizontalAlignment.Center}
                PitchTable.Controls.Add(txt, y, x - 1)
                If x = 1 Then ' set up strip lines on each column based on tolerance class and APP
                    If APP = False Then
                        Dim sline As New StripLine With {
                            .IntervalOffset = bp - (bp * (TolClass.MeanPitchPerRadiusPercent / 100)),
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Blue,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                            }
                        cArea.AxisY.StripLines.Add(sline)
                        sline = New StripLine With {
                            .IntervalOffset = bp + (bp * (TolClass.MeanPitchPerRadiusPercent / 100)),
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Red,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                        }
                        cArea.AxisY.StripLines.Add(sline)
                        sline = New StripLine With {
                            .IntervalOffset = bp,
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Black,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                        }
                    Else
                        Dim appPitch As Double = 0
                        For Each rm2 As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(rad) Math.Round(rad.Radius.Value) = Math.Round(rm.Radius.Value))
                            appPitch += GetAverageBladePitch(rm2.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion.Value, mJobDetails.Job.LeExclusion.Value)
                        Next
                        appPitch /= mJobDetails.Job.PropellerBlades
                        Dim sline As New StripLine With {
                            .IntervalOffset = appPitch - (appPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Blue,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                        }
                        cArea.AxisY.StripLines.Add(sline)
                        sline = New StripLine With {
                            .IntervalOffset = appPitch + (appPitch * (TolClass.MeanPitchPerRadiusPercent / 100)),
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Red,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                        }
                        cArea.AxisY.StripLines.Add(sline)
                        sline = New StripLine With {
                            .IntervalOffset = appPitch,
                            .BorderWidth = 1,
                            .BorderDashStyle = ChartDashStyle.Solid,
                            .BorderColor = Color.Black,
                            .StripWidth = Math.Round(CType(rm.Radius, Double)).ToString()
                        }
                    End If
                End If
            Next
            If x = 1 Then
                PitchTable.ColumnCount += 1
            End If
            avgpitch /= pitchcount
            ser.Points.AddXY("Bld Avg", avgpitch)
            Dim ac As Color = ToColor(CheckBladePitch(TolClass, avgpitch, bp, False))
            Dim avgtext As New TextBox With {.Text = Math.Round(avgpitch, 3).ToString(),
                .ForeColor = ac,
                .Dock = DockStyle.Fill,
                .TextAlign = HorizontalAlignment.Center}
            PitchTable.Controls.Add(avgtext, y + 1, x + 1)
        Next
        For I = 0 To PitchTable.ColumnCount - 1
            PitchTable.RowStyles(I).SizeType = SizeType.Percent
            PitchTable.RowStyles(I).Height = 100 / PitchTable.ColumnCount
        Next
        Dim seri As Series = Chart1.Series.Add("Wheel")
        seri.ChartType = SeriesChartType.Column
        seri.ChartArea = cArea.Name
        seri.Color = GraphColorArray(3)
        seri.Points.AddXY("Wheel Avg", mJobDetails.WheelPitch)
        Dim wc As Color = ToColor(CheckWheelPitch(TolClass, mJobDetails.WheelPitch, bp, False))
        Dim wheel As New TextBox With {.Text = Math.Round(mJobDetails.WheelPitch.Value, 3).ToString(),
            .ForeColor = wc,
            .Dock = DockStyle.Fill,
            .TextAlign = HorizontalAlignment.Center}
        PitchTable.Controls.Add(wheel, PitchTable.ColumnCount - 1, PitchTable.RowCount - 1)
        For I = 0 To PitchTable.RowCount
            PitchTable.RowStyles(I).SizeType = SizeType.Percent
            PitchTable.RowStyles(I).Height = 100 / mJobDetails.Job.PropellerBlades + 1
            BladeTable.RowStyles(I).SizeType = SizeType.Percent
            BladeTable.RowStyles(I).Height = 100 / mJobDetails.Job.PropellerBlades + 1
        Next
        PitchTable.BorderStyle = BorderStyle.Fixed3D
        Me.ResumeLayout()
    End Sub
#End Region
End Class
