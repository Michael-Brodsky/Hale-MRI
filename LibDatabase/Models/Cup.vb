Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Cup
        Public Property Cup1 As Double

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
