Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class RadiusMeasurement
        Public Property Id As Integer?

        Public Property JobDetailsId As Integer

        Public Property BladeId As Integer?

        Public Property Radius As Double?

        Public Property LeCell As Short?

        Public Property TeCell As Integer?

        Public Overridable Property JobDetails As JobDetail
    End Class
End Namespace
