Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Workstation
        Public Property Id As Integer?

        Public Property StationName As String

        Public Property Hostname As String

        Public Property AngleResolution As Short?

        Public Property RadiusResolution As Short?

        Public Property DepthResolution As Short?

        Public Property RadiusOffset As Short?

        Public Property HalfProbeDiameter As Short?

        Public Property ScanIncrement As Short?

        Public Property FixedOffset As Short?

        Public Property RadiusOffsetL As Short?

        Public Property AngleCalibration As Double?

        Public Property RadiusCalibration As Double?

        Public Property DepthCalibration As Double?
    End Class
End Namespace
