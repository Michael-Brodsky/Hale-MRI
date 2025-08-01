' This module manages creating, showing and disposing of application forms.
Imports LibDatabase.Contexts
Module FormInstances
    Public Sub ShowForm(Of F As {Form, New})(ByRef frm As F)
        frm = Application.OpenForms.OfType(Of F)().FirstOrDefault()
        If frm Is Nothing OrElse Not frm.IsHandleCreated Then
            ' If no instance of the form is open, create and show a new instance
            frm = New F()
            frm.Show()
        Else
            ' If an instance is already open, bring it to the front
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
        End If
    End Sub
    Public Sub ShowForm(Of F As {FrmDatabaseForm, New})(ByRef frm As F, ByRef dB As HaleMRIContext, Optional ByVal windowState As FormWindowState = FormWindowState.Normal, Optional ByVal modal As Boolean = False)
        frm = Application.OpenForms.OfType(Of F)().FirstOrDefault()
        If frm Is Nothing OrElse Not frm.IsHandleCreated Then
            ' If no instance of the form is open, create and show a new instance
            frm = New F With {
                .Database = dB
            }
            If modal Then
                ' Show the form as a modal dialog
                frm.ShowDialog()
            Else
                frm.WindowState = windowState
                frm.Show()
            End If
        Else
            If modal Then
                ' Show the form as a modal dialog
                frm.ShowDialog()
            Else
                ' If an instance is already open, bring it to the front
                frm.WindowState = windowState
                frm.BringToFront()
            End If
        End If
    End Sub
    Public Sub CloseForm(Of F As {Form, New})(ByRef frm As F)
        If frm IsNot Nothing AndAlso frm.IsHandleCreated Then
            ' Close the form if it is open
            frm.Close()
            frm.Dispose()
            frm = Nothing
        End If
    End Sub
End Module
