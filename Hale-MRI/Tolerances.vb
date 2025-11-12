

Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Storage

Enum ToleranceColor
    Pass ' Light Green
    Fail ' Red
    Low ' Turqoise
    VeryLow ' Blue
    ExtraLow ' Grey
    High ' Yellow
    VeryHigh ' Dark Red
    ExtraHigh ' Purple
    BadData ' Black
End Enum

Module Tolerances
    Public Function CheckLocalPitchTolerance(ToleranceTable As LibDatabase.Models.Tolerance, localpitch As Double, basispitch As Double) As ToleranceColor
        ' Check if the local pitch is within tolerance of the basis pitch based on the tolerance class.
        Dim pitchTolerance As Double
        Select Case ToleranceTable.ToleranceClass
            Case "S"
                pitchTolerance = (basispitch * (ToleranceTable.LocalPitchPercent / 100)) ' Local Pitch Tolerance for Class S Propellers  Need to pull these percents from database table later
                If (pitchTolerance * Constants.kInchToMm) < ToleranceTable.LocalPitchMinimum Then
                    pitchTolerance = ToleranceTable.LocalPitchMinimum * Constants.kMmToInch ' Minimum tolerance of 10 mils converted to inches
                End If
            Case "I"
                pitchTolerance = (basispitch * (ToleranceTable.LocalPitchPercent / 100)) ' Local Pitch Tolerance for Class I Propellers
                If (pitchTolerance * Constants.kInchToMm) < ToleranceTable.LocalPitchMinimum Then
                    pitchTolerance = ToleranceTable.LocalPitchMinimum * Constants.kMmToInch ' Minimum tolerance of 15 mils converted to inches
                End If
            Case "II"
                pitchTolerance = (basispitch * (ToleranceTable.LocalPitchPercent / 100)) ' Local Pitch Tolerance for Class II Propellers  Need to pull these percents from database table later
                If (pitchTolerance * Constants.kInchToMm) < ToleranceTable.LocalPitchMinimum Then
                    pitchTolerance = ToleranceTable.LocalPitchMinimum * Constants.kMmToInch ' Minimum tolerance of 20 mils converted to inches
                End If
            Case "III"
                Return ToleranceColor.Pass ' Class III Propellers have no local pitch tolerance
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
End Module