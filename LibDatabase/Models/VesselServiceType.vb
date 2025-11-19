Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class VesselServiceType
        Public Property Id As Integer

        Public Property ServiceType As String

        Public Property Description As String

        Public Overridable Property Vessels As ICollection(Of Vessel) = New List(Of Vessel)()
    End Class
End Namespace
