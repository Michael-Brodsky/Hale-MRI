Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Tolerance
        Public Property ToleranceClass As String

        Public Property LocalPitchSectors As Integer

        Public Property LocalPitchPercent As Double

        Public Property LocalPitchMinimum As Double

        Public Property MeanPitchPerRadiusPercent As Double

        Public Property MeanPitchPerRadiusMinimum As Double

        Public Property MeanPitchPerBladePercent As Double

        Public Property MeanPitchForPropellerPercent As Double

        Public Property MeanPitchPerBladeMinimum As Double

        Public Property MeanPitchForPropellerMinimum As Double

        Public Property ExtremeRadiusPercent As Double

        Public Property ExtremeRadiusMinimum As Double

        Public Property BladeThicknessPlus As Double

        Public Property BladeThicknessMinus As Double

        Public Property ChordLengthPercent As Double

        Public Property ChordLengthMinimum As Double

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
