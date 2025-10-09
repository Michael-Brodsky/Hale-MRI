Imports System.Diagnostics.Eventing.Reader
Imports LibDatabase.Models

Module MRIMath
    Public Function GetPitch(firstangle As Double, secondangle As Double, firstdepth As Double, seconddepth As Double) As Double
        'Pitch = (360 * Change in Depth) / Change in Angle
        ' SHOULD RETURN NON-ZERO VALUE IF DELTADEPTH = 0???
        Dim deltaangle = secondangle - firstangle
        Dim deltadepth = seconddepth - firstdepth
        Return If(deltaangle <> 0.0, Math.Abs((360.0 * deltadepth) / deltaangle), 0.0)
    End Function

    Public Function GetChordLength(bladenum As Integer, radperc As Integer) As Double
        'Nothing we are doing now uses this need to fully implement
        Dim chordlength As Double
        Dim Diameter As Double = 22 'can replace this with database reference or global variable

        'need to figure out best way to implement/get these values. Likely using TE/LE Cells to locate rows of relevent scandata
        Dim deltaangle As Double = 30 'Total change in angle on a radius of one blade
        Dim deltadepth As Double = 4 'Total change in depth on a radius of one blade

        Dim adjusteddiameter As Double = Diameter * (radperc / 100) 'Gets the value side of a radius measurement from a radius percent needed for an arc length calculation

        Dim arclength = adjusteddiameter * Math.PI * deltaangle / 360 'Gets the length of the arc/flat of the radial chord

        Dim squared = Math.Pow(deltadepth, 2) + Math.Pow(arclength, 2)
        chordlength = Math.Sqrt(squared) 'Pythagorean theorum to get chord length from change in depth and arc length

        Return chordlength
    End Function

    Public Function GetBladeNumber(Angle As Double, Blades As Integer) As Integer
        'CurrentBlade = Blades - Math.Ceiling(Angle/(360/Blades))
        Return CInt(Math.Ceiling(Angle / (360 / Blades)))
        'Return If(Blades <> 0, Blades - CInt(Math.Ceiling(Angle / (360 / Blades))), 0)
    End Function

    Public Function GetAverageBladePitch(ByVal cellMeasurements As List(Of CellMeasurement)) As Double
        Dim avgPitch As Double = 0.0
        Dim pitch As New List(Of Double)
        For i As Integer = 1 To cellMeasurements.Count - 1
            Dim cmCurrent As CellMeasurement = cellMeasurements(i)
            Dim cmPrevious As CellMeasurement = cellMeasurements(i - 1)
            ' GETPITCH() RETURNS 0.0 IF CONSECUTIVE ANGLES/DEPTHS ARE EQUAL.
            ' IF ALL ARE EQUAL, THEN AVG PITCH WILL RETURN 0.0
            ' IS THIS VALID???
            Dim p As Double = GetPitch(cmCurrent?.Angle, cmPrevious?.Angle, cmCurrent?.Depth, cmPrevious?.Depth)
            If p <> 0.0 Then pitch.Add(p)
        Next
        If pitch.Count > 0 Then avgPitch = pitch.Average()
        Return avgPitch
    End Function
End Module
