Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Exclusion
        Public Property Exclusion1 As Double

        Public Overridable Property JobDetailLeExclusionNavigations As ICollection(Of JobDetail) = New List(Of JobDetail)()

        Public Overridable Property JobDetailTeExclusionNavigations As ICollection(Of JobDetail) = New List(Of JobDetail)()
    End Class
End Namespace
