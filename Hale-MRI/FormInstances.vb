''' <summary>
''' Defines methods for managing application form instances
''' and certain custom event handlers.
''' </summary>
''' 
Imports System.Runtime.CompilerServices
Imports LibDatabase.Contexts
Imports LibDatabase.Models

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

    Public Sub ShowForm(Of F As {FrmDatabaseForm, New})(ByRef frm As F, ByRef dB As HaleMRIContext, ByVal user As Employee, Optional ByVal windowState As FormWindowState = FormWindowState.Normal, Optional ByVal modal As Boolean = False)
        frm = Application.OpenForms.OfType(Of F)().FirstOrDefault()
        If frm Is Nothing OrElse Not frm.IsHandleCreated Then
            ' If no instance of the form is open, create and show a new instance
            frm = New F With {
                .Database = dB,
                .User = user
            }
            If modal Then
                ' Show the form as a modal dialog
                frm.ShowDialog()
            Else
                ' Show the form in the given window state
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

    Public Sub RefreshForm(Of F As {FrmDatabaseForm, New})(ByRef frm As F)
        ' If the form is open, refresh it.
        frm = Application.OpenForms.OfType(Of F)().FirstOrDefault()
        If frm IsNot Nothing AndAlso frm.IsHandleCreated Then frm.Refresh()
    End Sub

    Public Sub CloseForm(Of F As {Form, New})(ByRef frm As F)
        If frm IsNot Nothing AndAlso frm.IsHandleCreated Then
            ' Close the form if it is open
            frm.Close()
            frm.Dispose()
            frm = Nothing
        End If
    End Sub

    <Extension()>
    Public Sub IsEnabled(dataGrid As DataGridView, value As Boolean)
        dataGrid.Enabled = value
        If dataGrid.Enabled Then
            dataGrid.DefaultCellStyle.BackColor = SystemColors.Window
            dataGrid.DefaultCellStyle.ForeColor = SystemColors.ControlText
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText
            dataGrid.EnableHeadersVisualStyles = True
        Else
            dataGrid.DefaultCellStyle.BackColor = SystemColors.Control
            dataGrid.DefaultCellStyle.ForeColor = SystemColors.GrayText
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText
            dataGrid.CurrentCell = Nothing
            dataGrid.EnableHeadersVisualStyles = False
        End If
        dataGrid.Refresh()
    End Sub

    <Extension()>
    Public Function DoubleClicked(combo As System.Windows.Forms.ComboBox) As Boolean
        ' Returns True if the specified ComboBox was double-clicked, else
        ' returns False. We need this because VB.NET/WinForms doesn't support
        ' the ComboBox double-click event.
        Const kDblClickTime As Integer = 500 ' Maximum time between clicks for a double-click, in milliseconds
        Static lastControl As System.Windows.Forms.ComboBox = Nothing
        Static lastClick As DateTime = DateTime.MinValue
        Dim result As Boolean = False
        If lastControl Is Nothing OrElse lastControl Is combo Then
            If (DateTime.Now - lastClick).TotalMilliseconds <= kDblClickTime Then
                ' If the time since the last click is within the double-click threshold, return true.
                result = True
                lastClick = DateTime.MinValue ' Reset lastClick to prevent further double-clicks
            Else
                lastClick = DateTime.Now
            End If
        End If
        lastControl = combo
        Return result
    End Function

    <Extension()>
    Public Function NotInList(combo As System.Windows.Forms.ComboBox, e As KeyEventArgs) As Boolean
        ' Returns True if the user pressed Enter or Return, the combo text is not empty,
        ' and no existing item is selected in the combo box.
        Return ((e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Return) AndAlso Not String.IsNullOrEmpty(combo.Text) AndAlso combo.SelectedIndex = kNoCurrentRecord)
    End Function
End Module
