Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' Base form for all application forms that consume data
''' from the database.
''' </summary>
''' 
''' <summary>
''' Base class for all forms that access the database.
''' </summary>
Partial Public Class FrmDatabaseForm
    Inherits Form
    ''' NOTE: Properties and methods qualified as Overridable
    ''' should be MustOverride. However, that would make this
    ''' an abstract class and prevent any derived forms from
    ''' being edited in the VS Designer.
    Public Overridable Property Database As HaleMRIContext  ' This property MUST be overridden in derived forms.

    Public Overrides Sub Refresh()

    End Sub

    Public Property User As Employee                        ' This property should not be overridden, as all derived forms should share the same user.

    Protected Overridable Sub BindDataSources()
        ' Derived forms MUST override this method to perform any 
        ' automatic, implementation-specific binding. 
    End Sub

    Private Sub FrmDatabaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The Database property will be changed in all open derived forms, 
        ' but we only want to do this once, on Form_Load.
        If Database IsNot Nothing Then BindDataSources()
    End Sub
End Class