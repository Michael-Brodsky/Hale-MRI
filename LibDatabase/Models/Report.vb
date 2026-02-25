Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Report
        Public Property Id As Integer?

        Public Property ReportName As String

        Public Property Description As String

        Public Property LastModifed As Date?

        Public Property ModifiedBy As Integer?

        Public Overridable Property ReportElements As ICollection(Of ReportElement) = New List(Of ReportElement)()
    End Class
End Namespace
