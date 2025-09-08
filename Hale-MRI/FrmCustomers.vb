Imports System.ComponentModel
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking.Internal
Public Class FrmCustomers
    Inherits FrmDatabaseForm
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmVessels As FrmVessels
    Private mFrmJobs As FrmJobs

    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Public Property Filter As String
        Set(value As String)
            'Navigator.Filter = value
        End Set
        Get
            Return Nothing
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        Return Nothing
    End Function
    Private Sub BindDataSources()
        ' Master list is Customers sorted by CustomerName.
        Dim customers = Database.Customers.Include(Function(c) c.Vessels).OrderBy(Function(c) c.CustomerName).ToList()
        ' Each customer's Vessels list is sorted by VesselName.
        For Each c In customers
            c.Vessels = c.Vessels.OrderBy(Function(v) v.VesselName).ToList()
            ' Each vessel's Jobs list is sorted by StartDate.
            For Each v In c.Vessels
                v.Jobs = v.Jobs.OrderBy(Function(j) j.StartDate).ToList()
            Next
        Next
        CustomerBindingSource.DataSource = New BindingList(Of Customer)(customers)
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        StateCodeBindingSource.DataSource = Database.StateCodes.Local.ToBindingList()
        ' Bind: Customers (master) -> Vessels (details), Vessels (master) -> Jobs (details)).
        BindMasterDetails(CustomerBindingSource, VesselBindingSource, "Vessels")
        BindMasterDetails(VesselBindingSource, JobBindingSource, "Jobs")
        ' Set the navigation bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Customers"
        DataSource = CustomerBindingSource
        'Navigator.MasterControl = dataGridCustomers
    End Sub
    Private Sub DatagridCustomerVessels_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DatagridCustomerVessels.CellMouseDoubleClick
        ' Open the Vessels form with the selected vessel as the current record.
        Try
            ShowForm(mFrmVessels, Database)
            mFrmVessels.Filter = Nothing
            'mFrmVessels.Current = VesselBindingSource.Current
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database)
            mFrmJobs.Filter = Nothing
            mFrmJobs.Find(JobBindingSource.Current)
        Catch ex As Exception
            MessageBox.Show("Error opening job details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Navigator_Event(sender As Object, e As NavigationEventArgs) Handles mNavigator.NavigationEvent
        Select Case e.EventName
            Case "Delete"

            Case "FilterOff"

            Case "FilterOn"

            Case "GotoFirst"
                CustomerBindingSource.Position = 0
            Case "GotoLast"
                CustomerBindingSource.Position = CustomerBindingSource.Count - 1
            Case "GotoNext"
                If CustomerBindingSource.Position < CustomerBindingSource.Count - 1 Then CustomerBindingSource.Position += 1
            Case "GotoPrev"
                If CustomerBindingSource.Position > 0 Then CustomerBindingSource.Position -= 1
            Case "Save"
                If CustomerBindingSource.Current.Id Is Nothing Then
                    ' If the current job is new, add it to the databese.
                    'JobAddNew()
                Else
                    ' If the current job is not new, save changes to the current job.
                    BindingSourceSave(Database, CustomerBindingSource)
                End If
            Case "Undo"
                BindingSourceUndo(Database, CustomerBindingSource)
                'If JobBindingSource.Current Is Nothing Then
                'FiltersClear()
                'ComboJobs.Enabled = True
                'End If
            Case Else

        End Select
    End Sub
End Class