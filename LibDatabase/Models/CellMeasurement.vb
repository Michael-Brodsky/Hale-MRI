Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class CellMeasurement
        Public Property Id As Integer?

        Public Property JobDetailsId As Integer

        Public Property Angle As Double?

        Public Property Depth As Double?

        Public Overridable Property JobDetails As JobDetail
    End Class
End Namespace
