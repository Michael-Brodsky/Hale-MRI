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

        Public Property [Class] As String

        Public Property Rotation As String

        Public Property Diameter As Double?

        Public Property Bore As String

        Public Property MarkedPitch As Double?

        Public Property DesiredPitch As Double?

        Public Property WheelPitch As Double?

        Public Property LeExclusion As Double?

        Public Property TeExclusion As Double?

        Public Property Cup As Double?

        Public Property Dar As Double?

        Public Overridable Property CellMeasurements As ICollection(Of CellMeasurement) = New List(Of CellMeasurement)()

        Public Overridable Property ClassNavigation As Tolerance

        Public Overridable Property CupNavigation As Cup

        Public Overridable Property ExtremeMeasurements As ICollection(Of ExtremeMeasurement) = New List(Of ExtremeMeasurement)()

        Public Overridable Property Job As Job

        Public Overridable Property LeExclusionNavigation As Exclusion

        Public Overridable Property PerformedByNavigation As Employee

        Public Overridable Property RadiusMeasurements As ICollection(Of RadiusMeasurement) = New List(Of RadiusMeasurement)()

        Public Overridable Property RotationNavigation As Rotation

        Public Overridable Property TeExclusionNavigation As Exclusion
    End Class
End Namespace
