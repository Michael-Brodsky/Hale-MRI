Imports System.Diagnostics.Eventing.Reader

Module MRIMath
    Public Function GetPitch(firstangle As Double, secondangle As Double, firstdepth As Double, seconddepth As Double) As Double
        'Parameters might change depending on how we can access data from database
        Dim deltaangle = secondangle - firstangle
        Dim deltadepth = seconddepth - firstdepth
        Dim pitch As Double
        If (deltaangle <> 0) Then
            pitch = (360 * deltadepth) / deltaangle
            If (pitch <= 0) Then
                pitch *= -1
            End If
        Else
            pitch = 0
        End If
        Return pitch
    End Function
    Public Function GetChordLength(bladenum As Integer, radperc As Integer) As Double
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

End Module
