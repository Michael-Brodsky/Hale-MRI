Imports Microsoft.Win32
Public Class Registrar
    Private _key As String
    Private _values As Dictionary(Of String, Object)
    Public Sub New(ByVal name As String)
        _key = name
        _values = New Dictionary(Of String, Object)
    End Sub
    Public Sub New(ByVal name As String, values As List(Of (Name As String, Value As Object)))
        _key = name
        _values = values.ToDictionary(Function(x) x.Name, Function(x) x.Value)
    End Sub
    Public Sub New(ByVal name As String, values As String())
        _key = name
        _values = New Dictionary(Of String, Object)
        For Each value As String In values
            _values.Add(value, String.Empty)
        Next
        Read()
    End Sub
    Public ReadOnly Property Exists As Boolean
        Get
            Dim regKey As Microsoft.Win32.RegistryKey = GetKey(_key)
            Return regKey IsNot Nothing
        End Get
    End Property
    Public Property Key As String
        Get
            Return _key
        End Get
        Set(value As String)
            _key = value
        End Set
    End Property
    Public ReadOnly Property Values As Dictionary(Of String, Object)
        Get
            Return _values
        End Get
    End Property
    Public Sub Delete()
        Dim regKey As Microsoft.Win32.RegistryKey = GetKey(_key)
        If regKey IsNot Nothing Then
            For Each kvp As KeyValuePair(Of String, Object) In _values
                Dim name As String = kvp.Key
                regKey.DeleteValue(name, False)
            Next
        End If
    End Sub
    Public Sub Read()
        Dim regKey As Microsoft.Win32.RegistryKey = GetKey(_key)
        If regKey IsNot Nothing Then
            For Each kvp As KeyValuePair(Of String, Object) In _values
                Dim name As String = kvp.Key
                Dim value As Object = kvp.Value
                _values(name) = regKey.GetValue(name, String.Empty)
            Next
        End If
    End Sub
    Public Sub Write()
        Dim regKey As Microsoft.Win32.RegistryKey = GetKey(_key)
        If regKey IsNot Nothing Then
            For Each kvp As KeyValuePair(Of String, Object) In _values
                Dim name As String = kvp.Key
                Dim value As Object = kvp.Value
                regKey.SetValue(name, value)
            Next
        End If
    End Sub
    Private Function GetKey(ByVal keyName As String) As RegistryKey
        Dim hive As String = _key.Substring(0, _key.IndexOf("\"c))
        Dim baseName As String = _key.Substring(hive.Length + 1)
        Dim baseKey As RegistryKey
        Select Case hive
            Case "HKEY_CURRENT_USER" : baseKey = Registry.CurrentUser
            Case "HKEY_LOCAL_MACHINE" : baseKey = Registry.LocalMachine
            Case "HKEY_CLASSES_ROOT" : baseKey = Registry.ClassesRoot
            Case "HKEY_USERS" : baseKey = Registry.Users
            Case "HKEY_PERFORMANCE_DATA" : baseKey = Registry.PerformanceData
            Case "HKEY_CURRENT_CONFIG" : baseKey = Registry.CurrentConfig
            Case Else
                Throw New ArgumentException("Invalid Registry Key Name " & hive)
        End Select
        Return baseKey.OpenSubKey(baseName, False)
    End Function
End Class
