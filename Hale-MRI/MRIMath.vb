Imports System.Diagnostics.Eventing.Reader
Imports LibDatabase.Models

Module MRIMath
    Public Function GetLocalPitch(cm As List(Of CellMeasurement), sectors As Integer, sector As Integer, diameter As Double, radiusPercent As Double, TeExclusion As Double, LeExclusion As Double) As Double
        'Returns the local pitch of a sector based on the first and last cell measurements in that sector
        Dim startangle As Double = cm.FirstOrDefault().Angle
        Dim endangle As Double = cm.LastOrDefault().Angle
        Dim deltaangle As Double = startangle - endangle
        Dim cl As Double = GetChordLength(cm, diameter, CInt(radiusPercent))
        If cl <> 0 Then
            startangle -= (deltaangle * TeExclusion / cl)
            endangle += (deltaangle * LeExclusion / cl)
        End If ' bunch of math that finds the angle bounds of the sector excluding TE and LE Exclusion zones
        Dim sectorArc As Double = (startangle - endangle) / sectors
        Dim sectorstartangle As Double = startangle - (sectorArc * (sector - 1))
        Dim sectorendangle As Double = sectorstartangle - sectorArc

        Dim sectorstartovercell As CellMeasurement = cm.Where(Function(c) c.Angle >= sectorstartangle).LastOrDefault()
        Dim sectorstartundercell As CellMeasurement = cm.Where(Function(c) c.Angle <= sectorstartangle).FirstOrDefault()
        Dim sectorendundercell As CellMeasurement = cm.Where(Function(c) c.Angle >= sectorendangle).FirstOrDefault()
        Dim sectorendovercell As CellMeasurement = cm.Where(Function(c) c.Angle <= sectorendangle).LastOrDefault()
        Dim sectorstartdepth As Double = 0.0
        Dim sectorenddepth As Double = 0.0
        Dim Ratio As Double = 0.0
        If sectorstartovercell IsNot Nothing AndAlso sectorstartundercell IsNot Nothing Then
            'Linear interpolation to find the depth at the exact sector start angle
            If sectorstartangle - sectorstartundercell.Angle <> 0 Then
                If sectorstartovercell.Angle - sectorstartundercell.Angle <> 0 Then
                    Ratio = (sectorstartangle - sectorstartundercell.Angle) / (sectorstartovercell.Angle - sectorstartundercell.Angle)
                End If
            End If
            sectorstartdepth = sectorstartundercell.Depth + (Ratio * (sectorstartovercell.Depth - sectorstartundercell.Depth))
        End If
        If sectorendovercell IsNot Nothing AndAlso sectorendundercell IsNot Nothing Then
            'Linear interpolation to find the depth at the exact sector end angle
            If sectorendangle - sectorendundercell.Angle <> 0 Then
                If sectorendovercell.Angle - sectorendundercell.Angle <> 0 Then
                    Ratio = (sectorendangle - sectorendundercell.Angle) / (sectorendovercell.Angle - sectorendundercell.Angle)
                End If
            End If
            sectorenddepth = sectorendundercell.Depth + (Ratio * (sectorendovercell.Depth - sectorendundercell.Depth))
        End If
        Return GetPitch(sectorstartangle, sectorendangle, sectorstartdepth, sectorenddepth) 'sectorenddepth - sectorstartdepth) * (360 / sectorArc)
    End Function

    Public Function GetLocalHeight(cm As List(Of CellMeasurement), sectors As Integer, sector As Integer, diameter As Double, radiusPercent As Double, TeExclusion As Double, LeExclusion As Double) As Double
        'Returns the local height of a sector based on the first and last cell measurements in that sector
        Dim startangle As Double = cm.FirstOrDefault().Angle
        Dim endangle As Double = cm.LastOrDefault().Angle
        Dim deltaangle As Double = startangle - endangle
        Dim cl As Double = GetChordLength(cm, diameter, CInt(radiusPercent))
        If cl <> 0 Then
            startangle -= (deltaangle * TeExclusion / cl)
            endangle += (deltaangle * LeExclusion / cl)
        End If ' bunch of math that finds the angle bounds of the sector excluding TE and LE Exclusion zones
        Dim sectorArc As Double = (startangle - endangle) / sectors
        Dim sectorstartangle As Double = startangle - (sectorArc * (sector - 1))
        Dim sectorendangle As Double = sectorstartangle - sectorArc
        Dim sectorstartcell As CellMeasurement = cm.Where(Function(c) c.Angle >= sectorstartangle).LastOrDefault()
        Dim sectorendcell As CellMeasurement = cm.Where(Function(c) c.Angle <= sectorendangle).FirstOrDefault()
        Return Math.Abs(sectorendcell.Depth.Value - sectorstartcell.Depth.Value) ' returns the computed height of the sector
    End Function
    Public Function GetChordMidAngle(cm As List(Of CellMeasurement)) As Double
        Dim startangle As Double = cm.FirstOrDefault().Angle
        Dim endangle As Double = cm.LastOrDefault().Angle
        Dim deltaangle As Double = Math.Abs(startangle - endangle)
        Return startangle + (deltaangle / 2) ' returns the computed midpoint angle
    End Function

    Public Function GetChordMidDepth(cm As List(Of CellMeasurement)) As Double
        Dim angle As Double = GetChordMidAngle(cm)
        Dim startDepthcell As CellMeasurement = cm.Where(Function(c) c.Angle >= angle).LastOrDefault()
        Dim endDepthcell As CellMeasurement = cm.Where(Function(c) c.Angle <= angle).FirstOrDefault()
        Dim deltaDepth As Double = Math.Abs(startDepthcell.Depth.Value - endDepthcell.Depth.Value)
        Dim Ratio As Double = (angle - startDepthcell.Angle.Value) / (endDepthcell.Angle.Value - startDepthcell.Angle.Value)
        Dim interdepth = startDepthcell.Depth.Value + (deltaDepth * Ratio)
        Return interdepth ' returns the computed midpoint angle
    End Function

    Public Function GetPitch(firstangle As Double, secondangle As Double, firstdepth As Double, seconddepth As Double) As Double
        'Pitch = (360 * Change in Depth) / Change in Angle
        ' Can be used to get local pitch between two cellmeasurements,
        Dim deltaangle = secondangle - firstangle
        Dim deltadepth = seconddepth - firstdepth
        Return If(deltaangle <> 0.0, Math.Abs((360.0 * deltadepth) / deltaangle), 0.0)
    End Function

    Public Function GetChordLength(cm As List(Of CellMeasurement), diameter As Double, radperc As Integer) As Double
        'ChordLength = sqrt((Change in Depth)^2 + ((Diameter * Radius Percent) * PI *(Change in Angle / 360))^2)
        'used to get the chord length between two cell measurements in inches
        Dim deltaangle As Double = cm.LastOrDefault().Angle - cm.FirstOrDefault().Angle 'Total change in angle on a radius of one blade
        Dim deltadepth As Double = cm.LastOrDefault().Depth - cm.FirstOrDefault().Depth 'Total change in depth on a radius of one blade

        Dim adjusteddiameter As Double = diameter * (radperc / 100) 'Gets the value side of a radius measurement from a radius percent needed for an arc length calculation

        Dim arclength = adjusteddiameter * Math.PI * deltaangle / 360 'Gets the length of the arc/flat of the radial chord

        Dim squared = Math.Pow(deltadepth, 2) + Math.Pow(arclength, 2)
        Dim chordlength = Math.Sqrt(squared) 'Pythagorean theorem to get chord length from change in depth and arc length

        Return chordlength
    End Function

    Public Function GetBladeNumber(Angle As Double, Blades As Integer) As Integer
        'CurrentBlade = Blades - Math.Ceiling(Angle/(360/Blades))
        ' Return CInt(Math.Ceiling(Angle / (360 / Blades)))
        Return If(Blades <> 0, CInt(Math.Ceiling(Angle / (360 / Blades))), 1)
    End Function

    Public Function GetAverageBladePitch(ByVal cellMeasurements As List(Of CellMeasurement), TeExclusion As Double, LeExclusion As Double) As Double
        Dim avgPitch As Double = 0.0 ' Changed this due to terms written in the ISO standard of how to measure average pitch of a radial section
        'Dim pitch As New List(Of Double)
        'For i As Integer = 1 To 10
        '    Dim p As Double = GetLocalPitch(cellMeasurements, 10, i, 22, cellMeasurements.FirstOrDefault().RadiusMeasurement.Radius)
        '    If p <> 0.0 Then pitch.Add(p)
        'Next
        'If pitch.Count > 0 Then avgPitch = pitch.Average()
        avgPitch = GetLocalPitch(cellMeasurements, 1, 1, cellMeasurements.FirstOrDefault().RadiusMeasurement.JobDetails.Job.PropellerDiameter, cellMeasurements.FirstOrDefault().RadiusMeasurement.Radius, TeExclusion, LeExclusion)
        'Dim avgPitch As Double = GetPitch(cellMeasurements.First().Angle, cellMeasurements.Last().Angle, cellMeasurements.First().Depth, cellMeasurements.Last().Depth)
        Return avgPitch
    End Function

    Public Function PolarToCartesian(radius As Double, angleDegrees As Double) As (x As Double, y As Double)
        Dim angleRadians As Double = angleDegrees * (Math.PI / 180.0)
        Dim x As Double = radius * Math.Cos(angleRadians)
        Dim y As Double = radius * Math.Sin(angleRadians)
        Return (x, y)
    End Function
End Module
