Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Storage

Module Tolerances
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
        Dim angulardeviation = Math.Abs(blade1angle - blade2angle - angleperblade)
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

    Public Function GetToleranceTable(Database As LibDatabase.Contexts.HaleMRIContext, toleranceClass As String) As LibDatabase.Models.Tolerance
        ' Retrieves the Tolerance table from the database based on the tolerance class.
        If Database.Tolerances.Local.Where(Function(tol) tol.ToleranceClass = toleranceClass).Any() Then
            Return Database.Tolerances.Local.Where(Function(tol) tol.ToleranceClass = toleranceClass).FirstOrDefault()
        Else
            Return Database.Tolerances.Local.FirstOrDefault() ' Return Default Tolerance Class D if not found
        End If
    End Function
End Module