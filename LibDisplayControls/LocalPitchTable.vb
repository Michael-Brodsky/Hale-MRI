Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports LibDatabase.Models

Public Class LocalPitchTable
    Inherits DisplayControl

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
    Public Property MJobDetails As JobDetail = Nothing
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
    ''' <summary>
    ''' Minimums Apply
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property Mins As Boolean = False
#End Region
#Region "Computed Properties"
    ''' <summary>
    ''' Basis pitch value used for tolerance lines based on Basis property and JobDetails data
    ''' </summary>
    ''' <returns>Double</returns>
    Private ReadOnly Property BasisPitch As Double
        Get
            If MJobDetails Is Nothing Then
                Return 0
            End If
            Select Case Basis
                Case "Marked"
                    Return MJobDetails.Job.MarkedPitch
                Case "Desired"
                    Return MJobDetails.Job.DesiredPitch
                Case "Design"
                    Return 0 ' need to set  up loading designs for comparison
                Case Else ' "Mean"
                    Return MJobDetails.WheelPitch
            End Select
        End Get
    End Property
    Public ReadOnly Property NeededSize As Size
        Get
            Dim contsize As New Size
            Dim height As Integer = 225 + (25 * (MJobDetails.Job.PropellerBlades * (TolClass.LocalPitchSectors + 1)))
            contsize.Height = height
            Dim Width As Integer = 100 + (85 * (MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1).ToList().Count + 1))
            contsize.Width = Width
            Return contsize
        End Get
    End Property
#End Region
#End Region
#Region "Private Interface"'need to add tolerance list and modify for APP
    Protected Overrides Sub ShowData()
        If MJobDetails Is Nothing OrElse
                TolClass Is Nothing OrElse
            String.IsNullOrEmpty(Basis) Then
            Return
        End If
        If APP = True Then
            LabTolClass.Text = "Local Pitch details for Class " + TolClass.ToleranceClass + " Inspection, allowing progressive pitch"
        Else
            LabTolClass.Text = "Local Pitch details for Class " + TolClass.ToleranceClass + " Inspection"
        End If
        Dim fontfam As New FontFamily("Arial")
        Dim tonf As New Font(fontfam, 12)
        LabTolClass.Font = New Font(fontfam, 18)
        Me.SuspendLayout()
        TLayoutBackground.RowCount = MJobDetails.Job.PropellerBlades
        TLayoutBackground.RowStyles.Clear()
        Dim x As Integer
        For x = 1 To MJobDetails.Job.PropellerBlades
            Dim tlayout As TableLayoutPanel
            If x = 1 Then
                tlayout = New TableLayoutPanel With {
                .Name = "Blade" + x.ToString(),
                .Dock = DockStyle.Fill,
                .RowCount = TolClass.LocalPitchSectors + 2,
                .ColumnCount = MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1).ToList().Count + 3,
                .Margin = New Padding(0, 0, 0, 0)}
            Else
                tlayout = New TableLayoutPanel With {
                .Name = "Blade" + x.ToString(),
                .Dock = DockStyle.Fill,
                .RowCount = TolClass.LocalPitchSectors + 1,
                .ColumnCount = MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1).ToList().Count + 3,
                .Margin = New Padding(0, 0, 0, 0)}
            End If
            'Manage ColumnStyles first two are absolute
            TLayoutBackground.Controls.Add(tlayout, 0, x - 1)
            Dim colsty As New ColumnStyle With {
                .SizeType = SizeType.Absolute,
                .Width = 65}
            tlayout.ColumnStyles.Add(colsty)
            colsty = New ColumnStyle With {
                .SizeType = SizeType.Absolute,
                .Width = 35}
            tlayout.ColumnStyles.Add(colsty)
            Dim y As Integer
            For y = 2 To tlayout.ColumnCount 'add the creation of the pitch labels and getting the pitches to this for loop
                colsty = New ColumnStyle With {
                    .Width = 100,
                    .SizeType = SizeType.Percent}
                tlayout.ColumnStyles.Add(colsty)
            Next
            ''manage RowStyles all should be percentage
            If x = 1 Then
                For q = 0 To TolClass.LocalPitchSectors + 1 'start from 0 to include the avg row
                    Dim rowsty As New RowStyle With {
                        .SizeType = SizeType.Percent,
                        .Height = 100}
                    tlayout.RowStyles.Add(rowsty)
                Next
            Else
                For q = 0 To TolClass.LocalPitchSectors 'start from 0 to include the avg row
                    Dim rowsty As New RowStyle With {
                        .SizeType = SizeType.Percent,
                        .Height = 100}
                    tlayout.RowStyles.Add(rowsty)
                Next
            End If
            Dim bldlab As New Label With {
                .Name = "LabBlade" + x.ToString(),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = "Bld " + x.ToString()}
            If x = 1 Then
                tlayout.Controls.Add(bldlab, 0, 1)
            Else
                tlayout.Controls.Add(bldlab, 0, 0)
            End If
            Dim telab As New Label With {
                .Name = "LabTE" + x.ToString(),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = "TE"}
            If x = 1 Then
                tlayout.Controls.Add(telab, 1, 1)
            Else
                tlayout.Controls.Add(telab, 1, 0)
            End If
            If TolClass.LocalPitchSectors <> 1 Then
                Dim LElab As New Label With {
                .Name = "LabLE" + x.ToString(),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = "LE"}
                If x = 1 Then
                    tlayout.Controls.Add(LElab, 1, TolClass.LocalPitchSectors)
                Else
                    tlayout.Controls.Add(LElab, 1, TolClass.LocalPitchSectors - 1)
                End If
            End If
            Dim avglab As New Label With {
                .Name = "avglab" + x.ToString(),
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = "Avg"}
            If x = 1 Then
                tlayout.Controls.Add(avglab, 0, TolClass.LocalPitchSectors + 1)
            Else
                tlayout.Controls.Add(avglab, 0, TolClass.LocalPitchSectors)
            End If
            Dim avgbladepitch As Double = 0.0
            y = 2
            If APP Then
                If x = 1 Then
                    For Each rm As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                        Dim avgpitch As Double = 0
                        Dim radlab As New Label With {
                            .Name = "BladeRad" + Math.Round(rm.Radius.Value).ToString(),
                            .TextAlign = ContentAlignment.MiddleLeft,
                            .Dock = DockStyle.Left,
                            .Text = Math.Round(rm.Radius.Value).ToString() + "%"}
                        tlayout.Controls.Add(radlab, y, 0)
                        For q = 0 To TolClass.LocalPitchSectors - 1
                            Dim tolpitch As Double = 0.0
                            For Each rad As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                                tolpitch += GetLocalPitch(rad.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rad.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Next
                            tolpitch /= MJobDetails.Job.PropellerBlades
                            Dim pitch = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rm.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Dim PitchCol = CheckLocalPitchToleranceNoPlot(TolClass, pitch, tolpitch, Mins)
                            Dim Pitchlab As New Label With {
                                    .Name = "Rad" + Math.Round(rm.Radius.Value).ToString() + (q + 1).ToString(),
                                    .Dock = DockStyle.Left,
                                    .Text = Math.Round(pitch, 2).ToString("F2"),
                                    .TextAlign = ContentAlignment.MiddleLeft,
                                    .ForeColor = ToColor(PitchCol)}
                            tlayout.Controls.Add(Pitchlab, y, q + 1)
                        Next
                        Dim tolavgpitch As Double = 0.0
                        For Each rad As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                            tolavgpitch += GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        Next
                        tolavgpitch /= MJobDetails.Job.PropellerBlades
                        avgpitch = GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        avgbladepitch += avgpitch
                        Dim avgPitchCol = CheckBladeRadiusPitch(TolClass, avgpitch, tolavgpitch, Mins)
                        Dim avgpitchlab As New Label With {
                                .Name = "avgpitch" + x.ToString() + Math.Round(rm.Radius.Value).ToString(),
                                .Dock = DockStyle.Fill,
                                .Text = Math.Round(avgpitch, 3).ToString("F3"),
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .ForeColor = ToColor(avgPitchCol),
                                .Margin = New Padding(20, 0, 0, 0)}
                        tlayout.Controls.Add(avgpitchlab, y, tlayout.RowCount - 1)
                        y += 1
                    Next
                Else
                    For Each rm As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                        Dim avgpitch As Double = 0.0
                        For q = 0 To TolClass.LocalPitchSectors - 1
                            Dim tolpitch As Double = 0.0
                            For Each rad As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                                tolpitch += GetLocalPitch(rad.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rad.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Next
                            tolpitch /= MJobDetails.Job.PropellerBlades
                            Dim pitch = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rm.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Dim PitchCol = CheckLocalPitchToleranceNoPlot(TolClass, pitch, tolpitch, Mins)
                            Dim Pitchlab As New Label With {
                                .Name = "Rad" + Math.Round(rm.Radius.Value).ToString() + (q + 1).ToString(),
                                .Dock = DockStyle.Fill,
                                .Text = Math.Round(pitch, 2).ToString("F2"),
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .ForeColor = ToColor(PitchCol)}
                            tlayout.Controls.Add(Pitchlab, y, q)
                        Next
                        Dim tolavgpitch As Double = 0.0
                        For Each rad As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                            tolavgpitch += GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        Next
                        tolavgpitch /= MJobDetails.Job.PropellerBlades
                        avgpitch = GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        avgbladepitch += avgpitch
                        Dim avgPitchCol = CheckBladeRadiusPitch(TolClass, avgpitch, tolavgpitch, Mins)
                        Dim avgpitchlab As New Label With {
                            .Name = "avgpitch" + x.ToString() + Math.Round(rm.Radius.Value).ToString(),
                            .Dock = DockStyle.Fill,
                            .Text = Math.Round(avgpitch, 3).ToString("F3"),
                            .TextAlign = ContentAlignment.MiddleLeft,
                            .ForeColor = ToColor(avgPitchCol),
                            .Margin = New Padding(20, 0, 0, 0)}
                        tlayout.Controls.Add(avgpitchlab, y, tlayout.RowCount - 1)
                        y += 1
                    Next
                End If
                Dim avgbladepitchtol As Double = 0.0
                Dim f As Integer
                For f = 1 To MJobDetails.Job.PropellerBlades
                    Dim avgradpitch As Double = 0.0
                    For Each rad As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = f).ToList()
                        avgradpitch += GetAverageBladePitch(rad.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                    Next
                    avgbladepitchtol += (avgradpitch / MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = f).ToList().Count)
                Next
                avgbladepitch /= MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList().Count
                Dim avgbladecol = CheckBladePitch(TolClass, avgbladepitch, avgbladepitchtol, Mins)
                Dim avgbladelab As New Label With {
                    .Name = "AvgBlade" + x.ToString(),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Text = Math.Round(avgbladepitch, 3).ToString("F3"),
                    .ForeColor = ToColor(avgbladecol)}
                tlayout.Controls.Add(avgbladelab, tlayout.ColumnCount - 1, tlayout.RowCount - 1)
                tlayout.Height = tlayout.RowCount * 25
                Dim rowstyl As New RowStyle With {
                    .SizeType = SizeType.Absolute,
                    .Height = tlayout.Height}
                TLayoutBackground.RowStyles.Add(rowstyl)
            Else
                If x = 1 Then
                    For Each rm As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                        Dim avgpitch As Double = 0
                        Dim radlab As New Label With {
                            .Name = "BladeRad" + Math.Round(rm.Radius.Value).ToString(),
                            .TextAlign = ContentAlignment.MiddleLeft,
                            .Dock = DockStyle.Left,
                            .Text = Math.Round(rm.Radius.Value).ToString("F2") + "%"}
                        tlayout.Controls.Add(radlab, y, 0)
                        For q = 0 To TolClass.LocalPitchSectors - 1
                            Dim pitch = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rm.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Dim PitchCol = CheckLocalPitchToleranceNoPlot(TolClass, pitch, BasisPitch, Mins)
                            Dim Pitchlab As New Label With {
                                    .Name = "Rad" + Math.Round(rm.Radius.Value).ToString() + (q + 1).ToString(),
                                    .Dock = DockStyle.Fill,
                                    .Text = Math.Round(pitch, 2).ToString("F2"),
                                    .TextAlign = ContentAlignment.MiddleLeft,
                                    .ForeColor = ToColor(PitchCol)}
                            tlayout.Controls.Add(Pitchlab, y, q + 1)
                        Next
                        avgpitch = GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        avgbladepitch += avgpitch
                        Dim avgPitchCol = CheckBladeRadiusPitch(TolClass, avgpitch, BasisPitch, Mins)
                        Dim avgpitchlab As New Label With {
                                .Name = "avgpitch" + x.ToString() + Math.Round(rm.Radius.Value).ToString(),
                                .Dock = DockStyle.Fill,
                                .Text = Math.Round(avgpitch, 3).ToString("F3"),
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .ForeColor = ToColor(avgPitchCol),
                                .Margin = New Padding(20, 0, 0, 0)}
                        tlayout.Controls.Add(avgpitchlab, y, tlayout.RowCount - 1)
                        y += 1
                    Next
                Else
                    For Each rm As RadiusMeasurement In MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                        Dim avgpitch As Double = 0
                        For q = 0 To TolClass.LocalPitchSectors - 1
                            Dim pitch = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, q + 1, MJobDetails.Job.PropellerDiameter, rm.Radius, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                            Dim PitchCol = CheckLocalPitchToleranceNoPlot(TolClass, pitch, BasisPitch, Mins)
                            Dim Pitchlab As New Label With {
                                    .Name = "Rad" + Math.Round(rm.Radius.Value).ToString() + (q + 1).ToString(),
                                    .Dock = DockStyle.Fill,
                                    .Text = Math.Round(pitch, 2).ToString("F2"),
                                    .TextAlign = ContentAlignment.MiddleLeft,
                                    .ForeColor = ToColor(PitchCol)}
                            tlayout.Controls.Add(Pitchlab, y, q)
                        Next
                        avgpitch = GetAverageBladePitch(rm.CellMeasurements, MJobDetails.Job.TeExclusion, MJobDetails.Job.LeExclusion)
                        avgbladepitch += avgpitch
                        Dim avgPitchCol = CheckBladeRadiusPitch(TolClass, avgpitch, BasisPitch, Mins)
                        Dim avgpitchlab As New Label With {
                                .Name = "avgpitch" + x.ToString() + Math.Round(rm.Radius.Value).ToString(),
                                .Dock = DockStyle.Fill,
                                .Text = Math.Round(avgpitch, 3).ToString("F3"),
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .ForeColor = ToColor(avgPitchCol),
                                .Margin = New Padding(20, 0, 0, 0)}
                        tlayout.Controls.Add(avgpitchlab, y, tlayout.RowCount - 1)
                        y += 1
                    Next
                End If
                avgbladepitch /= MJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList().Count
                Dim avgbladecol = CheckBladePitch(TolClass, avgbladepitch, BasisPitch, Mins)
                Dim avgbladelab As New Label With {
                    .Name = "AvgBlade" + x.ToString(),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Text = Math.Round(avgbladepitch, 3).ToString("F3"),
                    .ForeColor = ToColor(avgbladecol)}
                tlayout.Controls.Add(avgbladelab, tlayout.ColumnCount - 1, tlayout.RowCount - 1)
                tlayout.Height = tlayout.RowCount * 25
                Dim rowstyl As New RowStyle With {
                    .SizeType = SizeType.Absolute,
                    .Height = tlayout.Height}
                TLayoutBackground.RowStyles.Add(rowstyl)
            End If
        Next
        LabWheelPitch.Text = MJobDetails.WheelPitch.Value.ToString("F3")
        If APP = True Then
            TLayoutTolerances.Visible = False
        Else
            Dim pittol As Double = BasisPitch * (TolClass.LocalPitchPercent / 100)
            If (pittol * Constants.kInchToMm) < TolClass.LocalPitchMinimum And Mins = True Then
                pittol = TolClass.LocalPitchMinimum * Constants.kMmToInch
            End If
            LabLPHiLimit.Text = (BasisPitch + pittol).ToString("F3")
            LabLPLoLimit.Text = (BasisPitch - pittol).ToString("F3")
            pittol = BasisPitch * (TolClass.MeanPitchPerRadiusPercent / 100)
            If (pittol * Constants.kInchToMm) < TolClass.MeanPitchPerRadiusMinimum And Mins = True Then
                pittol = TolClass.MeanPitchPerRadiusMinimum * Constants.kMmToInch
            End If
            LabRadiusHiLimit.Text = (BasisPitch + pittol).ToString("F3")
            LabRadiusLoLimit.Text = (BasisPitch - pittol).ToString("F3")
            pittol = BasisPitch * (TolClass.MeanPitchPerBladePercent / 100)
            If (pittol * Constants.kInchToMm) < TolClass.MeanPitchPerBladeMinimum And Mins = True Then
                pittol = TolClass.MeanPitchPerBladeMinimum * Constants.kMmToInch
            End If
            LabBladeHiLimit.Text = (BasisPitch + pittol).ToString("F3")
            LabBladeLoLimit.Text = (BasisPitch - pittol).ToString("F3")
            pittol = BasisPitch * (TolClass.MeanPitchForPropellerPercent / 100)
            If (pittol * Constants.kInchToMm) < TolClass.MeanPitchForPropellerMinimum And Mins = True Then
                pittol = TolClass.MeanPitchForPropellerMinimum * Constants.kMmToInch
            End If
            LabWheelHiLimit.Text = (BasisPitch + pittol).ToString("F3")
            LabWheelLoLimit.Text = (BasisPitch - pittol).ToString("F3")
        End If
            Me.ResumeLayout()
    End Sub
#End Region
End Class
