Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Namespace Models
    Partial Public Class Setting
        Public Property Id As Integer?

        Public Property JobNumberMin As Integer

        Public Property CompanyName As String

        Public Property CompanyAddress As String

        Public Property CompanyWebsite As String

        Public Property CompanyEmail As String

        Public Property CompanyPhone As String

        Public Property CompanyContact As String

        Public Property ApplicationDatabaseFile As String

        Public Property ApplicationConnectionString As String

        Public Property ApplicationDefaultFolder As String

        Public Property EncoderDataInitialDirectory As String

        Public Property EncoderCalibrationSampleRate As Integer?
    End Class
End Namespace
