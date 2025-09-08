Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Blade
        Public Property BladeCount As Short

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()
    End Class
End Namespace
