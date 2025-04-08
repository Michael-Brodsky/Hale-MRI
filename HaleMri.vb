Imports Microsoft.Win32

Public Class HaleMri
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error GoTo ErrorHandler
        txtResult.Text = GetRegLocalMachineValue64(txtKey.Text, txtValue.Text)
        If txtResult.Text = "" Then MsgBox("Key not found")
        Exit Sub

ErrorHandler:
        MsgBox(Err.Description)
    End Sub

End Class
