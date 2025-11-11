Namespace Models
    Partial Public Class Exclusion
        Public Property Exclusion1 As Double

        Public Overridable Property JobLeExclusionNavigations As ICollection(Of Job) = New List(Of Job)()

        Public Overridable Property JobTeExclusionNavigations As ICollection(Of Job) = New List(Of Job)()
    End Class
End Namespace
