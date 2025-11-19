Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class CountryCode
        Public Property Alpha2Code As String

        Public Property Alpha3Code As String

        Public Property Country As String

        Public Property Numeric As Integer?

        Public Overridable Property Customers As ICollection(Of Customer) = New List(Of Customer)()

        Public Overridable Property Manufacturers As ICollection(Of Manufacturer) = New List(Of Manufacturer)()
    End Class
End Namespace
