Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Customer
        Public Property Id As Integer?

        Public Property CustomerName As String

        Public Property Address As String

        Public Property City As String

        Public Property State As String

        Public Property PostalCode As String

        Public Property CountryCode As String

        Public Property Telephone As String

        Public Property Email As String

        Public Property Website As String

        Public Overridable Property CountryCodeNavigation As CountryCode

        Public Overridable Property StateNavigation As StateCode

        Public Overridable Property Vessels As ICollection(Of Vessel) = New List(Of Vessel)()
    End Class
End Namespace
