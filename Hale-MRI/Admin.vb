Imports LibDatabase.Contexts
Imports LibDatabase.Models

Module Admin
    Public Const kLoginFailed As Integer = -1
    Friend Function ApplicationLogin(dB As HaleMRIContext, ByVal userName As String, ByVal password As String) As Employee
        ' Returns the Employee whose name and password match those given.
        Return dB.Employees.Where(Function(u) u.EmployeeName = userName.ToString() AndAlso u.Password = password.ToString()).FirstOrDefault()
    End Function
End Module
