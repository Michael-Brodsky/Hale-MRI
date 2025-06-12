Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Rotation
        Public Property Rotation1 As String

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
