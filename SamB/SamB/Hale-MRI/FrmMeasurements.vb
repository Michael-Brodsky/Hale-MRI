Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.Imex
Imports LibEncoder
Public Class FrmMeasurements
#Region "Constants"

#End Region
#Region "Private Members"
    Private mBlades As Integer
    Private mHardware As WorkstationEncoders
#End Region
#Region "Public Interface"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByRef wse As WorkstationEncoders)
        ' This call is required by the designer.
        InitializeComponent()
        Dim db As New HaleMRIContext()
        mHardware = wse
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Property Hardware As WorkstationEncoders
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Function CurrentBlade() As Integer
        Dim db As HaleMRIContext
        Dim blades As Integer
        Return Math.Truncate(mHardware.Encoders.Angle / (360 / 4)) + 1
        'Replace 4 with number of blades from Database
    End Function
    Private Sub HomeEncoders()
        With mHardware.Encoders
            .ResetCount(USDigital.ANGLE_ENCODER)
            .ResetCount(USDigital.RADIUS_ENCODER)
            .ResetCount(USDigital.DEPTH_ENCODER)
        End With
        cmdHome.Visible = False
        cmdHome.Enabled = False
    End Sub
    Private Sub UpdateFields()
        With mHardware.Encoders
            txtAngle.Text = .Angle
            txtRadius.Text = .Radius(22).Value
            txtDepth.Text = .Depth
            txtRadiusPercent.Text = .Radius(22).Percent
            txtBlade.Text = CurrentBlade().ToString()
        End With
    End Sub

#End Region
#Region "UI Event Handlers"
    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles cmdHome.Click
        HomeEncoders()
    End Sub
    Private Sub CmdStopScan_Click(sender As Object, e As EventArgs) Handles cmdStopScan.Click
        UpdateFields()
    End Sub
    Private Sub CountUpdate_Tick(sender As Object, e As EventArgs) Handles CountUpdate.Tick
        UpdateFields()
    End Sub
    Private Sub CmdZero_Click(sender As Object, e As EventArgs) Handles cmdZero.Click
        mHardware.Encoders.ResetCount(0)
        mHardware.Encoders.ResetCount(1)
        mHardware.Encoders.ResetCount(2)
    End Sub
#End Region
End Class