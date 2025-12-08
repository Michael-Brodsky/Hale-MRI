Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class ReferenceCell
        Public Property Id As Integer?

        Public Property ReferenceAngle As Double?

        Public Property ReferenceDepth As Double?

        Public Property ReferenceRadius As Double?

        Public Property ReferenceDescription As String

        Public Overridable Property IdNavigation As JobDetail
    End Class
End Namespace
