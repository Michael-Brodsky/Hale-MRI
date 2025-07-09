Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Employee
        Public Property Id As Integer?

        Public Property EmployeeName As String

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()
    End Class
End Namespace
