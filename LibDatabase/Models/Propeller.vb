Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Propeller
        Public Property Id As Integer?

        Public Property ManufacturerId As Integer

        Public Property PartNumber As String

        Public Property Description As String

        Public Property Style As String

        Public Property Material As String

        Public Property Blades As Short?

        Public Property Diameter As Double?

        Public Property Hub As Double?

        Public Property Rotation As String

        Public Property Bore As Double?

        Public Property BladeWidth As Double?

        Public Property BladeArea As Double?

        Public Property Weight As Double?

        Public Property RotationalInertia As Double?

        Public Overridable Property BladesNavigation As Blade

        Public Overridable Property Manufacturer As Manufacturer

        Public Overridable Property MaterialNavigation As Material

        Public Overridable Property RotationNavigation As Rotation

        Public Overridable Property StyleNavigation As Style
    End Class
End Namespace
