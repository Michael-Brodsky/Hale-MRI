Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Vessel
        Public Property Id As Integer?

        Public Property CustomerId As Integer

        Public Property ServiceTypeId As Integer?

        Public Property VesselName As String

        Public Property PrimaryVesselNumber As String

        Public Property HullIdNumber As String

        Public Property CallSign As String

        Public Property Flag As String

        Public Property BuildYear As Short?

        Public Overridable Property Customer As Customer

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()

        Public Overridable Property ServiceType As VesselServiceType
    End Class
End Namespace
