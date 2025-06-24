Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Style
        Public Property Style1 As String

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()

        Public Overridable Property Propellers As ICollection(Of Propeller) = New List(Of Propeller)()
    End Class
End Namespace
