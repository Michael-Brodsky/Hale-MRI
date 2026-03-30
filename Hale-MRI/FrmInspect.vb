Imports LibDatabase.Models
Imports LibDisplayControls
Public Class FrmInspect
    Dim mLocalPitchtable As New LocalPitchTable With {
        .Dock = DockStyle.Fill,
        .Name = "InspectLP",
        .Visible = True}
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(mJobDetails As JobDetail, TolClass As Tolerance, Basis As String, APP As Boolean, Mins As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mLocalPitchtable.MJobDetails = mJobDetails
        mLocalPitchtable.TolClass = TolClass
        mLocalPitchtable.Basis = Basis
        mLocalPitchtable.APP = APP
        mLocalPitchtable.Mins = Mins
        mLocalPitchtable.Data = mJobDetails
        Me.Size = mLocalPitchtable.NeededSize
        Me.Controls.Add(mLocalPitchtable)
        Me.Refresh()
    End Sub

End Class