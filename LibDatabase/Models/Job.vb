Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Job
        Public Property Id As Integer?

        Public Property VesselId As Integer

        Public Property InspectedBy As Integer?

        Public Property JobNumber As Integer

        Public Property StartDate As Date?

        Public Property Description As String

        Public Property SerialNumber As String

        Public Property StampNumber As String

        Public Property DesiredPitch As Double?

        Public Property MarkedPitch As Double?

        Public Property LeExclusion As Double?

        Public Property TeExclusion As Double?

        Public Property Cup As Double?

        Public Property Dar As Double?

        Public Property PropellerManufacturerId As Integer?

        Public Property PropellerPartNumber As String

        Public Property PropellerDescription As String

        Public Property PropellerStyle As String

        Public Property PropellerMaterial As String

        Public Property PropellerBlades As Short

        Public Property PropellerDiameter As Double?

        Public Property PropellerRotation As String

        Public Property PropellerBore As String

        Public Overridable Property CupNavigation As Cup

        Public Overridable Property InspectedByNavigation As Employee

        Public Overridable Property JobDetails As ICollection(Of JobDetail) = New List(Of JobDetail)()

        Public Overridable Property LeExclusionNavigation As Exclusion

        Public Overridable Property PropellerBladesNavigation As Blade

        Public Overridable Property PropellerManufacturer As Manufacturer

        Public Overridable Property PropellerMaterialNavigation As Material

        Public Overridable Property PropellerRotationNavigation As Rotation

        Public Overridable Property PropellerStyleNavigation As Style

        Public Overridable Property TeExclusionNavigation As Exclusion

        Public Overridable Property Vessel As Vessel
    End Class
End Namespace
