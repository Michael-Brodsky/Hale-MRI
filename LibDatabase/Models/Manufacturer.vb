Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Manufacturer
        Public Property Id As Integer?

        Public Property ManufacturerName As String

        Public Property Address As String

        Public Property City As String

        Public Property State As String

        Public Property PostalCode As String

        Public Property CountryCode As String

        Public Property Telephone As String

        Public Property Email As String

        Public Property Website As String

        Public Overridable Property CountryCodeNavigation As CountryCode

        Public Overridable Property Jobs As ICollection(Of Job) = New List(Of Job)()

        Public Overridable Property Propellers As ICollection(Of Propeller) = New List(Of Propeller)()

        Public Overridable Property StateNavigation As StateCode
    End Class
End Namespace
