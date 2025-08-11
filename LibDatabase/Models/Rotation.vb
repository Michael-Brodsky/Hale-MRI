Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Rotation
        Public Property Rotation1 As String

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()

        Public Overridable Property Propellers As ICollection(Of Propeller) = New List(Of Propeller)()
    End Class
End Namespace
