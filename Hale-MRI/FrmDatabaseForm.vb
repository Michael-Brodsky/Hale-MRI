Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' Base class for all forms that access the database.
''' </summary>
Partial Public Class FrmDatabaseForm
    Inherits Form
    ''' NOTE: Properties and methods qualified as Overridable
    ''' should be MustOverride. However, that would make this
    ''' an abstract class and prevent any derived forms from
    ''' being edited in the VS Designer.

    ''' <summary>
    ''' The database context used to access data.
    ''' This property MUST be overridden in derived forms.
    ''' </summary>
    Public Overridable Property Database As HaleMRIContext

    ''' <summary>
    ''' Refreshes a data-bound form's MasterList, if any. 
    ''' This facilitates data concurrency across forms.
    ''' </summary>
    Public Overrides Sub Refresh()
        If MasterSource IsNot Nothing Then MasterSource.ResetBindings(False)
        MyBase.Refresh()
    End Sub

    ''' <summary>
    ''' The user currently logged into the application.
    ''' This property should not be overridden, as all derived forms
    ''' should share the same user.
    ''' </summary>
    Public Property User As Employee

    ''' <summary>
    ''' Performs any automatic, implementation-specific
    ''' binding of data sources to controls. Derived forms MUST 
    ''' override this method.
    ''' </summary>
    Protected Overridable Sub BindDataSources()

    End Sub

    ''' <summary>
    ''' Automatically called when the form is loaded.
    ''' If the Database property has been set, this calls BindDataSources
    ''' to bind data sources to controls.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form_Loading(sender As Object, e As EventArgs) Handles MyBase.Load
        If Database IsNot Nothing Then BindDataSources()
    End Sub

    ''' <summary>
    ''' Automatically called when the form is closing.
    ''' This clears the Database property to ensure that
    ''' the database context can be disposed of if no
    ''' other forms are using it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Overridable Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Some forms may need to set Database to Nothing before closing.
        Database = Nothing
    End Sub

    ''' <summary>
    ''' The "master" BindingSource for the form, if any.
    ''' This is the BindingSource that controls record navigation
    ''' and to which other BindingSources may be related in a
    ''' master/details scenario. This property MUST be overridden 
    ''' in derived forms.
    ''' </summary>
    Protected Overridable Property MasterSource As BindingSource

    ''' <summary>
    ''' Refreshes all open FrmDatabaseForm forms, or the given list of forms.
    ''' </summary>
    ''' <param name="forms">Optional list of forms to refresh. If not given, all open FrmDatabaseForm forms will be refreshed.</param>
    ''' <remarks>
    ''' This method is intended to be called after changes have been made
    ''' to the database in order to ensure that all open forms display
    ''' current data.
    ''' </remarks>
    Protected Overridable Sub RefreshAll(Optional ByVal forms As List(Of FrmDatabaseForm) = Nothing)
        ' Refreshes the given list of forms, or all open FrmDatabaseForm forms if none given.
        Dim openForms = If(forms, Application.OpenForms.OfType(Of FrmDatabaseForm)().ToList())
        For Each frm In openForms
            If frm IsNot Me Then frm.Refresh()  ' We don't need to refresh ourselves.
        Next
    End Sub
End Class