Imports System.IO

Public Module FileLogger
    ' Thread-safe minimal file logger for simple value logging.
    Private ReadOnly lockObj As New Object()
    Private ReadOnly logDirectoryName As String = Path.Combine("C:\Users\super\OneDrive\Documents", "logs")
    Private ReadOnly logFileName As String = Path.Combine(logDirectoryName, "app.log")

    Private Sub EnsureLogDirectory()
        Try
            If Not Directory.Exists(logDirectoryName) Then
                Directory.CreateDirectory(logDirectoryName)
            End If
        Catch
            ' Ignore directory creation failures
        End Try
    End Sub

    Public Sub Log(message As String)
        Try
            EnsureLogDirectory()
            Dim entry As String = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [INFO] {1}{2}", DateTime.Now, message, Environment.NewLine)
            SyncLock lockObj
                ' Append text safely; use File.AppendAllText which opens/closes stream for each write.
                File.AppendAllText(logFileName, entry)
            End SyncLock
        Catch
            ' Ensure logging never throws to caller
        End Try
    End Sub

    Public Sub LogException(ex As Exception)
        Try
            EnsureLogDirectory()
            Dim entry As String = String.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [ERROR] {1}{2}StackTrace:{3}{4}{5}", DateTime.Now, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace, Environment.NewLine)
            SyncLock lockObj
                File.AppendAllText(logFileName, entry)
            End SyncLock
        Catch
            ' Swallow exceptions from logging
        End Try
    End Sub
End Module
