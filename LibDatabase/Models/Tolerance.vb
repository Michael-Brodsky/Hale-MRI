Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Tolerance
        Public Property ToleranceClass As String

        Public Property LocalPitchPercent As Double

        Public Property LocalPitchMinimum As Double

        Public Property MeanPitchPerRadiusPercent As Integer

        Public Property MeanPitchPerRadiusMinimum As Double

        Public Property MeanPitchPerBlade As Double?

        Public Property MeanPitchForPropeller As Double

        Public Property DisplayColor As String

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
