Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Public Class FrmVessels
    Dim dB As New HaleMRIContext()

    Private Sub FrmVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dB.Vessels.Load()
        dB.Customers.Load()
        dB.Jobs.Load()
        dB.CountryCodes.Load()
        dB.VesselServiceTypes.Load()
        CustomerBindingSource.DataSource = dB.Customers.Local.ToBindingList()
        VesselBindingSource.DataSource = dB.Vessels.Local.ToBindingList()
        CountryCodeBindingSource.DataSource = dB.CountryCodes.Local.ToBindingList()
        VesselServiceTypeBindingSource.DataSource = dB.VesselServiceTypes.Local.ToBindingList()
        JobsBindingSource.DataSource = VesselBindingSource
        JobsBindingSource.DataMember = "Jobs"
    End Sub

    Private Sub FrmVessels_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dB.Dispose()
        dB = Nothing
    End Sub
End Class