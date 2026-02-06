Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmReportsEditor
    Inherits Form
#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal reports As BindingSource, ByVal employees As BindingSource)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EmployeesBindingSource.DataSource = employees.DataSource
        EmployeesBindingSource.DataMember = employees.DataMember
        ReportsBindingSource.DataSource = reports.DataSource
        ReportsBindingSource.DataMember = reports.DataMember
    End Sub
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
    ''' Finds the given Report and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The Report to find.</param>
    ''' <returns>The found Report, or Nothing if not found.</returns>
    Public Function Find(item As Report) As Report
        Dim result As Report = Nothing
        Dim pos As Integer = BindingSourceFind(ReportsBindingSource, item)
        If pos <> kNoCurrentRecord Then
            ReportsBindingSource.Position = pos
            result = Current
        End If
        Return result
    End Function
#End Region
#Region "Private Interface"
#End Region
#Region "Event Handlers"
    Private Sub FrmReportsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridReports.AutoGenerateColumns = False
    End Sub

    Private Sub DataGridReports_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridReports.MouseDoubleClick
        Me.Close()
    End Sub
#End Region
End Class