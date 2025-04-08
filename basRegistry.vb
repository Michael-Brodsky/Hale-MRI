Imports Microsoft.Win32
Module basRegistry
    Public Function GetRegLocalMachineValue64(ByVal aRegKey As String, Optional ByVal aRegValue As String = "") As String
        Dim regRoot As RegistryKey
        Dim regKey As RegistryKey

        GetRegLocalMachineValue64 = ""
        regRoot = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
        If regRoot IsNot Nothing Then
            regKey = regRoot.OpenSubKey(aRegKey)
            If regKey IsNot Nothing Then
                If aRegValue = "" Then
                    GetRegLocalMachineValue64 = "(Default)"
                Else
                    GetRegLocalMachineValue64 = regKey.GetValue(aRegValue)
                End If
            End If
        End If
    End Function

    Public Function GetRegistryValue6432(ByVal aRegKey As String, ByVal aRegValue As String) As String
        Dim readValue As Object

        GetRegistryValue6432 = ""
        readValue = My.Computer.Registry.GetValue(aRegKey, aRegValue, Nothing)
        If readValue IsNot Nothing Then GetRegistryValue6432 = readValue.ToString()
    End Function
End Module
