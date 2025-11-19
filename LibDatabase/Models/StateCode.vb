Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class StateCode
        Public Property StateCode1 As String

        Public Property StateName As String

        Public Overridable Property Customers As ICollection(Of Customer) = New List(Of Customer)()

        Public Overridable Property Manufacturers As ICollection(Of Manufacturer) = New List(Of Manufacturer)()
    End Class
End Namespace
