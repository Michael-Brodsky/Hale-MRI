Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class ExtremeMeasurement
        Public Property Id As Integer?

        Public Property JobDetailsId As Integer

        Public Property BladeId As Short

        Public Property Extreme As Double

        Public Overridable Property JobDetails As JobDetail
    End Class
End Namespace
