Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' Base form for all application forms that consume data
''' from the database.
''' </summary>
''' 

Partial Public Class FrmDatabaseForm
    Inherits Form
    Public Overridable Property Database As HaleMRIContext

    Public Property User As Employee

    Protected Overridable Sub BindDataSources()
        ' Derived forms MUST override this method to perform any 
        ' implementation-specific binding. Note: this method
        ' should be qualified as "MustOverride", but that makes
        ' this class abstract and prevents opening any derived
        ' forms in the designer.
    End Sub

    'Protected Overridable Sub FrmDatabaseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '    ' Derived forms with a DataGridView.SelectionChanged event will fire
    '    ' after the FormClosing event, resulting in an error. So, we set the
    '    ' Database property to Nothing. Derived forms should check Database
    '    ' Is Nothing in the SelectionChanged events to avoid errors.
    '    Database = Nothing
    'End Sub

    Private Sub FrmDatabaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The Database property will be changed in all open derived forms, 
        ' but we only want to do this once, on Form_Load.
        If Database IsNot Nothing Then BindDataSources()
    End Sub
End Class