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
    Public Sub ShowForm(Of F As {FrmDatabaseForm, New})(ByRef frm As F, ByRef dB As HaleMRIContext)
        frm = Application.OpenForms.OfType(Of F)().FirstOrDefault()
        If frm Is Nothing OrElse Not frm.IsHandleCreated Then
            ' If no instance of the form is open, create and show a new instance
            frm = New F With {
                .Database = dB
            }
            frm.Show()
        Else
            ' If an instance is already open, bring it to the front
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
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
