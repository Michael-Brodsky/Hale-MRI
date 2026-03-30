Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Storage
Imports LibDisplayControls.MRIMath

Public Module Tolerances
    Enum ToleranceColor
        Pass ' Light Green
        Fail ' Red
        Low ' Turquoise
        VeryLow ' Blue
        ExtraLow ' Grey
        High ' Yellow
        VeryHigh ' Dark Red
        ExtraHigh ' Purple
        BadData ' Black
    End Enum
    Public Function ToColor(tc As ToleranceColor) As Color ' returns a System.Drawing.Color based on the ToleranceColor enumeration
        Select Case tc
            Case ToleranceColor.Pass
                Return Color.DarkGreen
            Case ToleranceColor.Fail
                Return Color.Red
            Case ToleranceColor.Low
                Return Color.Turquoise
            Case ToleranceColor.VeryLow
                Return Color.Blue
            Case ToleranceColor.ExtraLow
                Return Color.Gray
            Case ToleranceColor.High
                Return Color.Yellow
            Case ToleranceColor.VeryHigh
                Return Color.DarkRed
            Case ToleranceColor.ExtraHigh
                Return Color.Purple
            Case ToleranceColor.BadData
                Return Color.Black
            Case Else
                Return Color.Black
        End Select
    End Function
    Public Function CheckAxialPosition(ToleranceTable As LibDatabase.Models.Tolerance, blade1depth As Double, blade2depth As Double) As ToleranceColor
        'checks the tolerance on the angular deviation between two consecutive blades

        Dim deltadepth = Math.Abs(blade1depth - blade2depth)
        Dim tolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S"
                tolerance = 0.005
            Case "I"
                tolerance = 0.01
            Case "II"
                tolerance = 0.015
            Case "III"
                tolerance = 0.03
            Case Else
                Return ToleranceColor.BadData
        End Select
        If deltadepth <= blade1depth * tolerance Then
            Return ToleranceColor.Pass
        Else
            Return ToleranceColor.Fail
        End If
    End Function
    Public Function CheckAngularDeviation(ToleranceTable As LibDatabase.Models.Tolerance, blades As Integer, blade1angle As Double, blade2angle As Double) As ToleranceColor
        'checks the tolerance on the angular deviation between two consecutive blades
        Dim angleperblade As Double = 360 / blades
        Dim angulardeviation = Math.Abs(Math.Abs(blade1angle - blade2angle) - angleperblade)
        Dim tolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I"
                tolerance = 0.01
            Case "II", "III"
                tolerance = 0.02
            Case Else
                Return ToleranceColor.BadData
        End Select
        If angulardeviation <= angleperblade * tolerance Then
            Return ToleranceColor.Pass
        Else
            Return ToleranceColor.Fail
        End If
    End Function
    Public Function CheckBladePitch(ToleranceTable As LibDatabase.Models.Tolerance, bladepitch As Double, basispitch As Double, minsApply As Boolean) As ToleranceColor
        ' Checks a Radius measurements average pitch against basis pitch and tolerance to determine color coding
        Dim PitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I", "II", "III", "D"
                PitchTolerance = (basispitch * (ToleranceTable.MeanPitchPerBladePercent / 100)) ' Make sure Tolerance Class is good
                If minsApply Then
                    If (PitchTolerance * Constants.kInchToMm) < ToleranceTable.MeanPitchPerBladeMinimum Then
                        PitchTolerance = ToleranceTable.MeanPitchPerBladeMinimum * Constants.kMmToInch ' Minimum tolerance converted to inches
                    End If
                End If
            Case Else
                Return ToleranceColor.BadData ' Unknown tolerance class
        End Select
        Dim lowerLimit As Double = basispitch - PitchTolerance
        Dim upperLimit As Double = basispitch + PitchTolerance
        If bladepitch < lowerLimit Then
            Return ToleranceColor.VeryLow
        ElseIf bladepitch > upperLimit Then
            Return ToleranceColor.Fail
        Else
            Return ToleranceColor.BadData
        End If
    End Function
    Public Function CheckWheelPitch(ToleranceTable As LibDatabase.Models.Tolerance, wheelpitch As Double, basispitch As Double, minsApply As Boolean) As ToleranceColor
        ' Checks a jobDetails Wheel Pitch measurement against basis pitch and tolerance to determine color coding
        Dim PitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I", "II", "III", "D"
                PitchTolerance = (basispitch * (ToleranceTable.MeanPitchForPropellerPercent / 100)) ' Make sure Tolerance Class is good
                If minsApply Then
                    If (PitchTolerance * Constants.kInchToMm) < ToleranceTable.MeanPitchForPropellerMinimum Then
                        PitchTolerance = ToleranceTable.MeanPitchForPropellerMinimum * Constants.kMmToInch ' Minimum tolerance converted to inches
                    End If
                End If
            Case Else
                Return ToleranceColor.BadData ' Unknown tolerance class
        End Select
        Dim lowerLimit As Double = basispitch - PitchTolerance
        Dim upperLimit As Double = basispitch + PitchTolerance
        If wheelpitch < lowerLimit Then
            Return ToleranceColor.VeryLow
        ElseIf wheelpitch > upperLimit Then
            Return ToleranceColor.Fail
        Else
            Return ToleranceColor.Pass
        End If
    End Function
    Public Function CheckBladeRadiusPitch(ToleranceTable As LibDatabase.Models.Tolerance, bladeradiuspitch As Double, basispitch As Double, minsApply As Boolean) As ToleranceColor
        ' Checks a Radius measurements average pitch against basis pitch and tolerance to determine color coding
        Dim PitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I", "II", "III", "D"
                PitchTolerance = (basispitch * (ToleranceTable.MeanPitchPerRadiusPercent / 100)) ' Make sure Tolerance Class is good
                If minsApply Then
                    If (PitchTolerance * Constants.kInchToMm) < ToleranceTable.MeanPitchPerRadiusMinimum Then
                        PitchTolerance = ToleranceTable.MeanPitchPerRadiusMinimum * Constants.kMmToInch ' Minimum tolerance converted to inches
                    End If
                End If
            Case Else
                Return ToleranceColor.BadData ' Unknown tolerance class
        End Select
        Dim lowerLimit As Double = basispitch - PitchTolerance
        Dim upperLimit As Double = basispitch + PitchTolerance
        If bladeradiuspitch < lowerLimit Then
            Return ToleranceColor.VeryLow
        ElseIf bladeradiuspitch > upperLimit Then
            Return ToleranceColor.Fail
        Else
            Return ToleranceColor.BadData
        End If
    End Function
    Public Function CheckLocalPitchTolerance(ToleranceTable As LibDatabase.Models.Tolerance, localpitch As Double, basispitch As Double, minsApply As Boolean) As ToleranceColor
        ' Check if the local pitch is within tolerance of the basis pitch based on the tolerance class.
        Dim pitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I", "II"
                pitchTolerance = (basispitch * (ToleranceTable.LocalPitchPercent / 100)) ' Local Pitch Tolerance for Class S Propellers
                If minsApply Then
                    If (pitchTolerance * Constants.kInchToMm) < ToleranceTable.LocalPitchMinimum Then
                        pitchTolerance = ToleranceTable.LocalPitchMinimum * Constants.kMmToInch ' Minimum Tolerance converted to inches
                    End If
                End If
            Case "III", "D"
                pitchTolerance = (basispitch * (0.5))
            Case Else
                Return ToleranceColor.BadData ' Unknown tolerance class
        End Select
        Dim lowerLimit As Double = basispitch - pitchTolerance
        Dim upperLimit As Double = basispitch + pitchTolerance

        If localpitch < lowerLimit Then
            If localpitch < lowerLimit - pitchTolerance Then
                If localpitch < lowerLimit - (2 * pitchTolerance) Then
                    Return ToleranceColor.ExtraLow
                End If
                Return ToleranceColor.VeryLow
            End If
            Return ToleranceColor.Low
        ElseIf localpitch > upperLimit Then
            If localpitch > upperLimit + pitchTolerance Then
                If localpitch > upperLimit + (2 * pitchTolerance) Then
                    Return ToleranceColor.ExtraHigh
                End If
                Return ToleranceColor.VeryHigh
            End If
            Return ToleranceColor.High
        Else
            Return ToleranceColor.Pass
        End If
    End Function

    Public Function CheckLocalPitchToleranceNoPlot(ToleranceTable As LibDatabase.Models.Tolerance, localpitch As Double, basispitch As Double, minsApply As Boolean) As ToleranceColor
        ' Check if the local pitch is within tolerance of the basis pitch based on the tolerance class.
        Dim pitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S", "I", "II"
                pitchTolerance = (basispitch * (ToleranceTable.LocalPitchPercent / 100)) ' Local Pitch Tolerance for Class S Propellers
                If minsApply Then
                    If (pitchTolerance * Constants.kInchToMm) < ToleranceTable.LocalPitchMinimum Then
                        pitchTolerance = ToleranceTable.LocalPitchMinimum * Constants.kMmToInch ' Minimum Tolerance converted to inches
                    End If
                End If
            Case "III", "D"
                pitchTolerance = (basispitch * (0.5))
            Case Else
                Return ToleranceColor.BadData ' Unknown tolerance class
        End Select
        Dim lowerLimit As Double = basispitch - pitchTolerance
        Dim upperLimit As Double = basispitch + pitchTolerance

        If localpitch < lowerLimit Then
            Return ToleranceColor.VeryLow
        ElseIf localpitch > upperLimit Then
            Return ToleranceColor.Fail
        Else
            Return ToleranceColor.BadData
        End If
    End Function

    Public Function GetToleranceTable(Database As LibDatabase.Contexts.HaleMRIContext, toleranceClass As String) As LibDatabase.Models.Tolerance
        ' Retrieves the Tolerance table from the database based on the tolerance class.
        If Database.Tolerances.Local.Where(Function(tol) tol.ToleranceClass = toleranceClass).Any() Then
            Return Database.Tolerances.Local.Where(Function(tol) tol.ToleranceClass = toleranceClass).FirstOrDefault()
        Else
            Return Database.Tolerances.Local.FirstOrDefault() ' Return Default Tolerance Class D if not found
        End If
    End Function
    Public Function ShowLocalPitchTolerance(mJobDetails As JobDetail, minsApply As Boolean, app As Boolean, classes As List(Of Tolerance)) As Integer
        ' made for use in ShowTolerances in FrmMeasurements only returns an integer representing which class passed
        Dim passingClass As Integer = 0
        Dim y As Integer
        For y = 1 To mJobDetails.Job.PropellerBlades 'check for correct number of Radii so as to accurately depict Tolerance classes
            Dim count = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = y).ToList().Count
            If count < 7 And passingClass <= 1 Then
                passingClass += 2 'not enough rads Class S and I fail
                If count < 5 And passingClass <= 2 Then
                    passingClass += 1 'not enough rads Class II fails
                    If count < 3 And passingClass <= 3 Then
                        passingClass += 1 'not enough rads Class III fails
                    End If
                End If
            End If
        Next
        If app Then
            For Each tol As Tolerance In classes
                If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                If passingClass > classes.IndexOf(tol) Then Continue For
                Dim sectors As Integer = tol.LocalPitchSectors
                For n = 1 To tol.LocalPitchSectors
                    If passingClass > classes.IndexOf(tol) Then Continue For
                    For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = 1).ToList()
                        If passingClass > classes.IndexOf(tol) Then Continue For
                        Dim avgpitch As Double = 0.0
                        Dim pitcount As Integer = 0
                        For Each Rad As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                            Dim Pitch = GetLocalPitch(Rad.CellMeasurements, sectors, n, mJobDetails.Job.PropellerDiameter, Rad.Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                            avgpitch += Pitch
                            pitcount += 1
                        Next
                        avgpitch /= pitcount
                        For Each Rad As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                            If passingClass > classes.IndexOf(tol) Then Continue For
                            Dim pitch = GetLocalPitch(Rad.CellMeasurements, sectors, n, mJobDetails.Job.PropellerDiameter, Rad.Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                            Dim pitchCheck = CheckLocalPitchTolerance(tol, pitch, avgpitch, minsApply)
                            If pitchCheck <> ToleranceColor.Pass Then
                                passingClass += 1
                            End If
                        Next
                    Next
                Next
            Next
        Else
            For Each tol As Tolerance In classes
                If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                If passingClass > classes.IndexOf(tol) Then Continue For
                For Each rm In mJobDetails?.RadiusMeasurements
                    Dim Sectors As Integer = tol.LocalPitchSectors
                    For n = 1 To Sectors
                        If passingClass > classes.IndexOf(tol) Then Continue For
                        Dim pitch As Double = GetLocalPitch(rm.CellMeasurements.ToList(), Sectors, n, mJobDetails.Job.PropellerDiameter, rm.Radius, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                        Dim LocalPitch As ToleranceColor = CheckLocalPitchTolerance(tol, pitch, mJobDetails.Job.DesiredPitch, minsApply)
                        If LocalPitch <> ToleranceColor.Pass Then
                            passingClass += 1
                        End If
                    Next
                Next
            Next
        End If
        Return 3 ' if we get here it means that Class S I and II failed so we return 3 meaning III auto passes
    End Function
    Public Function ShowMeanPitchRadiusTolerance(mJobDetails As JobDetail, minsapply As Boolean, app As Boolean, classes As List(Of Tolerance)) As Integer
        ' made for use in ShowTolerances in FrmMeasurements only returns an integer representing the passing class
        Dim passingClass As Integer = 0
        Dim y As Integer
        For y = 1 To mJobDetails.Job.PropellerBlades 'check for correct number of Radii so as to accurately depict Tolerance classes
            Dim count = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = y).ToList().Count
            If count < 7 And passingClass <= 1 Then
                passingClass += 2 'not enough rads Class S and I fail
                If count < 5 And passingClass <= 2 Then
                    passingClass += 1 'not enough rads Class II fails
                    If count < 3 And passingClass <= 3 Then
                        passingClass += 1 'not enough rads Class III fails
                    End If
                End If
            End If
        Next
        If app Then
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements
                Dim avgpitch As Double = 0.0
                For Each rad As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value) = Math.Round(rm.Radius.Value)).ToList()
                    avgpitch += GetAverageBladePitch(rad.CellMeasurements, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                Next
                avgpitch /= mJobDetails.Job.PropellerBlades
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements, mJobDetails?.Job.TeExclusion, mJobDetails?.Job.LeExclusion)
                For Each tol As Tolerance In classes
                    If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                    If passingClass > classes.IndexOf(tol) Then Continue For
                    Dim pitchcheck = CheckBladeRadiusPitch(tol, pitch, avgpitch, minsapply)
                    If pitchcheck <> ToleranceColor.BadData Then
                        passingClass += 1
                    End If
                Next
            Next
        Else
            For Each rm In mJobDetails?.RadiusMeasurements
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                For Each tol As Tolerance In classes
                    If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                    If passingClass > classes.IndexOf(tol) Then Continue For
                    Dim MeanPitch As ToleranceColor = CheckBladeRadiusPitch(tol, pitch, mJobDetails.Job.DesiredPitch, minsapply)
                    If MeanPitch <> ToleranceColor.BadData Then
                        passingClass += 1
                    End If
                Next
            Next
        End If
        Return passingClass
    End Function
    Public Function ShowMeanPitchBladeTolerance(mJobDetails As JobDetail, minsapply As Boolean, app As Boolean, classes As List(Of Tolerance)) As Integer
        Dim passingClass As Integer = 0
        Dim y As Integer
        For y = 1 To mJobDetails.Job.PropellerBlades 'check for correct number of Radii so as to accurately depict Tolerance classes
            Dim count = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = y).ToList().Count
            If count < 7 And passingClass <= 1 Then
                passingClass += 2 'not enough rads Class S and I fail
                If count < 5 And passingClass <= 2 Then
                    passingClass += 1 'not enough rads Class II fails
                    If count < 3 And passingClass <= 3 Then
                        passingClass += 1 'not enough rads Class III fails
                    End If
                End If
            End If
        Next
        If app Then
            Dim avgbladepitch As Double = 0.0
            Dim x As Integer
            For x = 1 To mJobDetails.Job.PropellerBlades
                Dim avgpitch As Double = 0.0
                Dim list = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                For Each rm As RadiusMeasurement In list
                    avgpitch += GetAverageBladePitch(rm.CellMeasurements, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                Next
                avgpitch /= list.Count
                avgbladepitch += avgpitch
            Next
            avgbladepitch /= mJobDetails.Job.PropellerBlades
            For x = 1 To mJobDetails.Job.PropellerBlades
                Dim avgpitch As Double = 0.0
                Dim list = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                For Each rm As RadiusMeasurement In list
                    avgpitch += GetAverageBladePitch(rm.CellMeasurements, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                Next
                avgpitch /= list.Count
                For Each tol As Tolerance In classes
                    If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                    If passingClass > classes.IndexOf(tol) Then Continue For
                    Dim BladePitch As ToleranceColor = CheckBladePitch(tol, avgpitch, mJobDetails.Job.DesiredPitch, minsapply)
                    If BladePitch <> ToleranceColor.BadData Then
                        passingClass += 1
                    End If
                Next
            Next
        Else
            Dim blade As Integer
            For blade = 1 To mJobDetails.Job.PropellerBlades
                Dim pitchTotal As Double = 0
                Dim Count As Integer = 0
                For Each rm In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = blade).ToList()
                    Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements, mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                    pitchTotal += pitch
                    Count += 1
                Next
                For Each tol As Tolerance In classes
                    If passingClass < classes.IndexOf(tol) Then Return passingClass 'return the highest class that passed - means that all others will auto pass
                    If passingClass > classes.IndexOf(tol) Then Continue For
                    Dim BladePitch As ToleranceColor = CheckBladePitch(tol, (pitchTotal / Count), mJobDetails.Job.DesiredPitch, minsapply)
                    If BladePitch <> ToleranceColor.BadData Then
                        passingClass += 1
                    End If
                Next
            Next
        End If
        Return passingClass
    End Function
End Module