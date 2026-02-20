Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class ReportElement
        Public Property Id As Integer?

        Public Property ReportId As Integer

        Public Property ElementName As String

        Public Property PositionX As Short?

        Public Property PositionY As Short?

        Public Property SizeWidth As Short?

        Public Property SizeHeight As Short?

        Public Property Zorder As Short?

        Public Property Data As String

        Public Overridable Property Report As Report
    End Class
End Namespace
