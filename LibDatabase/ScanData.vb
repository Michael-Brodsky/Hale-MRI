Imports LibDatabase.Models

Public Class ScanData
    Public Overridable Property Customer As Customer
    Public Overridable Property Job As Job

    Public Sub New()
        ' Default constructor
    End Sub
    Public Sub New(customer As Customer, job As Job)
        ' Constructor that initializes the ScanData with a specific Customer and Job
        Me.Customer = customer
        Me.Job = job
    End Sub
End Class
