Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Public Class FrmVessels
    Dim dB As New HaleMRIContext()
    Public Property CurrentRecord As Vessel
        ' This property allows setting the current vessel record in the form.
        Set(value As Vessel)
            If value IsNot Nothing Then
                If VesselBindingSource.SupportsSearching Then
                    VesselBindingSource.Filter = $"ID = {value.Id}"
                Else
                    Dim index = dB.Vessels.Local.ToList().FindIndex(Function(v) v.Id = value.Id)
                    If index <> -1 Then VesselBindingSource.Position = index
                End If
            End If
        End Set
        Get
            If VesselBindingSource.Current IsNot Nothing Then
                Return CType(VesselBindingSource.Current, Vessel)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the database context and ensure all necessary data is loaded.
        ' Any data table used in the form should be loaded here.
        dB.Vessels.Load()
        dB.Customers.Load()
        dB.Jobs.Load()
        dB.CountryCodes.Load()
        dB.VesselServiceTypes.Load()
        ' Bind the data tables to the respective BindingSources.
        CustomerBindingSource.DataSource = dB.Customers.Local.ToBindingList()
        VesselBindingSource.DataSource = dB.Vessels.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = dB.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = dB.VesselServiceTypes.Local.ToBindingList()
        ' Bind Vessels (master) to Jobs (details). This automatically updates
        ' the Jobs list when a Vessel is selected.
        BindMasterDetails(VesselBindingSource, JobsBindingSource, "Jobs")
    End Sub

    Private Sub FrmVessels_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dB.Dispose()
        dB = Nothing
    End Sub
End Class