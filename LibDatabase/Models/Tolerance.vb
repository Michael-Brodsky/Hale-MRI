Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Tolerance
        Public Property ToleranceClass As String

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
