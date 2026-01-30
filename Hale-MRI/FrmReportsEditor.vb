Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmReportsEditor
    Inherits FrmDatabaseForm
#Region "Constructors"
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected Report,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As Report
        Get
            Return BindingSourceCurrent(ReportsBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Sets or gets the database context for this form.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Finds the given Report and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The Report to find.</param>
    ''' <returns>The found Report, or Nothing if not found.</returns>
    Public Function Find(item As Report) As Report
        Dim result As Report = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        EmployeesBindingSource.DataSource = New BindingList(Of Employee)(Database.Employees.ToList())
        ReportsBindingSource.DataSource = New BindingList(Of Report)(Database.Reports.OrderBy(Function(r) r.ReportName).ToList())
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub FrmReportsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridReports.AutoGenerateColumns = False
    End Sub
#End Region
End Class