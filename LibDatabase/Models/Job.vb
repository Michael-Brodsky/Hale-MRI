Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Job
        Public Property Id As Integer?

        Public Property VesselId As Integer

        Public Property JobNumber As Integer

        Public Property StartDate As Date?

        Public Property Description As String

        Public Property InspectedBy As Integer?

        Public Property ManufacturerId As Integer?

        Public Property PartNumber As String

        Public Property PartDescription As String

        Public Property SerialNumber As String

        Public Property StampNumber As String

        Public Property Material As String

        Public Property Style As String

        Public Property Blades As Short?

        Public Overridable Property InspectedByNavigation As Employee

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()

        Public Overridable Property Manufacturer As Manufacturer

        Public Overridable Property Vessel As Vessel
    End Class
End Namespace
