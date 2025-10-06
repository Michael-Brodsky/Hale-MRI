Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class JobDetail
        Public Property Id As Integer?

        Public Property JobId As Integer

        Public Property FileName As String

        Public Property Description As String

        Public Property StartDate As Date?

        Public Property PerformedBy As Integer?

        Public Property ToleranceClass As String

        Public Property WheelPitch As Double?

        Public Property MeasurementTypeId As Integer?

        Public Overridable Property BladeMeasurements As ICollection(Of BladeMeasurement) = New List(Of BladeMeasurement)()

        Public Overridable Property Job As Job

        Public Overridable Property MeasurementType As MeasurementType

        Public Overridable Property PerformedByNavigation As Employee

        Public Overridable Property RadiusMeasurements As ICollection(Of RadiusMeasurement) = New List(Of RadiusMeasurement)()

        Public Overridable Property ToleranceClassNavigation As Tolerance
    End Class
End Namespace
