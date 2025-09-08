Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Material
        Public Property Material1 As String

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()
    End Class
End Namespace
