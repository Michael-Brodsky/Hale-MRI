Imports LibDatabase.Contexts
Imports System.ComponentModel
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Hale_MRI.RecordNavigationBar
Public Class FrmVessels
    Inherits FrmDatabaseForm
#Region "Private Members"
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly; use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmJobs As FrmJobs
#End Region
#Region "Public Interface"
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
#End Region
#Region "Private Interface"
    Private Sub BindDataSources()
        ' Order the Vessels list by VesselName ...
        Dim vessels = Database.Vessels.Include(Function(v) v.Jobs).OrderBy(Function(v) v.VesselName).ToList()
        ' ... and each Vessel's Jobs list by JobNumber.
        For Each v In vessels
            v.Jobs = v.Jobs.OrderBy(Function(j) j.JobNumber).ToList()
        Next
        ' Bind the master BindingSource (Vessels) to the details BindingSource (Jobs).
        VesselBindingSource.DataSource = New BindingList(Of Vessel)(vessels)
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
        ' Order the dropdown lists alphabetically.
        CustomerBindingSource.DataSource = Database.Customers.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = Database.VesselServiceTypes.Local.ToBindingList()
        ManufacturerBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList()
        ' Set the nav bar properties.
        Navigator = RecordNavigationBar1
        Navigator.Caption = "Vessels"
        'Navigator.MasterControl = DataGridVessels
        DataSource = VesselBindingSource
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub DataGridVesselJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridVesselJobs.CellMouseDoubleClick
        ' Open the Jobs form with the selected job as the current record.
        Try
            ShowForm(mFrmJobs, Database)
            mFrmJobs.Filter = Nothing
            mFrmJobs.Find(JobsBindingSource.Current)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Navigator_Event(sender As Object, e As NavigationEventArgs) Handles mNavigator.NavigationEvent
        Select Case e.EventName
            Case "Delete"

            Case "FilterOff"

            Case "FilterOn"

            Case "GotoFirst"
                VesselBindingSource.Position = 0
            Case "GotoLast"
                VesselBindingSource.Position = VesselBindingSource.Count - 1
            Case "GotoNext"
                If VesselBindingSource.Position < VesselBindingSource.Count - 1 Then VesselBindingSource.Position += 1
            Case "GotoPrev"
                If VesselBindingSource.Position > 0 Then VesselBindingSource.Position -= 1
            Case "Save"
                If VesselBindingSource.Current.Id Is Nothing Then
                    ' If the current job is new, add it to the databese.
                    'JobAddNew()
                Else
                    ' If the current job is not new, save changes to the current job.
                    BindingSourceSave(Database, VesselBindingSource)
                End If
            Case "Undo"
                BindingSourceUndo(Database, VesselBindingSource)
                'If JobBindingSource.Current Is Nothing Then
                'FiltersClear()
                'ComboJobs.Enabled = True
                'End If
            Case Else

        End Select
    End Sub
#End Region
End Class