' This module emulates the USB4 hardware API functions for testing purposes.
' This code is a mock implementation and does not interact with actual hardware.
Module USB4
    Public Const USB4_SUCCESS As Long = 0
    Public Function USB4_GetCount(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByRef pulVal As Long) As Long
        Static v As Long = 1
        pulVal = v
        v = v + 1
        Return USB4_SUCCESS
    End Function
    Public Function USB4_Initialize(ByRef iDeviceCount As Integer) As Long
        iDeviceCount = 1
        Return USB4_SUCCESS
    End Function
    Public Function USB4_ResetCount(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer) As Long
        Return USB4_SUCCESS
    End Function
    Public Function USB4_SetCounterEnabled(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByVal bVal As Long) As Long
        Return USB4_SUCCESS
    End Function
    Public Function USB4_SetCounterMode(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByVal iVal As Integer) As Long
        Return USB4_SUCCESS
    End Function
    Public Function USB4_SetForward(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByVal bVal As Long) As Long
        Return USB4_SUCCESS
    End Function
    Public Function USB4_SetMultiplier(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByVal iVal As Integer) As Long
        Return USB4_SUCCESS
    End Function
    Public Function USB4_SetPresetValue(ByVal iDeviceNo As Integer, ByVal iEncoder As Integer, ByVal ulVal As Long) As Long
        Return USB4_SUCCESS
    End Function
End Module
