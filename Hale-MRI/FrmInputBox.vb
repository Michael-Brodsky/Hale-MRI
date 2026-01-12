Public Class FrmInputBox
    Public Property Title As String
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property

    Public Property Prompt As String
        Get
            Return labPrompt.Text
        End Get
        Set(value As String)
            labPrompt.Text = value
        End Set
    End Property

    Public Property InputText As String
        Get
            Return TxtInput.Text
        End Get
        Set(value As String)
            TxtInput.Text = value
        End Set
    End Property

    Private Sub TxtInput_TextChanged(sender As Object, e As EventArgs) Handles TxtInput.TextChanged
        If TxtInput.TextLength > 0 Then
            CmdOK.Enabled = True
        Else
            CmdOK.Enabled = False
        End If
        CmdCancel.Enabled = CmdOK.Enabled
    End Sub
End Class