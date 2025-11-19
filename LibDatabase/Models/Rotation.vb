Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Rotation
        Public Property Rotation1 As String

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()
    End Class
End Namespace
