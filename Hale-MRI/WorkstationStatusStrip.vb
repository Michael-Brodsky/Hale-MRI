Imports LibEncoder
Public Class WorkstationStatusStrip
    Public Enum EncoderStatus
        NotInitialized
        EncoderError
        NoEncoders
        Ready
    End Enum
    Public Const STR_ENCODER_NOT_INITIALIZED As String = "Not Initialized"
    Public Const STR_ENCODER_ERROR As String = "Encoder Error"
    Public Const STR_ENCODER_NO_ENCODERS As String = "No Encoders"
    Public Const STR_ENCODER_READY As String = "Ready"
    Private mEncoders As EncoderHardware
    Private mStatus As EncoderStatus = EncoderStatus.NoEncoders
    Private Sub EncoderInitializeMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderInitializeMenuItem.Click
        Try
            EncodersInitialize()
        Catch ex As Exception
            EncodersErrorShow(STR_ENCODER_ERROR, ex.Message)
        End Try
    End Sub
    Private Sub EncoderRadiusResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderRadiusResetMenuItem.Click
        Try
            mEncoders.ResetCount(USDigital.RADIUS_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ENCODER_ERROR, ex.Message)
        End Try
    End Sub
    Private Sub EncodersErrorShow(prompt As String, msg As String)
        ' Display an error message and update the UI accordingly
        MsgBox(prompt & ": " & msg, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        Status = EncoderStatus.EncoderError
    End Sub
    Private Sub EncodersInitialize()
        mEncoders.Initialize()
        If mEncoders.Initialized Then
            Status = EncoderStatus.Ready
        Else
            Status = EncoderStatus.NotInitialized
        End If
    End Sub
    Private Sub EncoderDepthResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderDepthResetMenuItem.Click
        Try
            mEncoders.ResetCount(USDigital.DEPTH_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ENCODER_ERROR, ex.Message)
        End Try
    End Sub
    Private Sub EncoderAngleResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderAngleResetMenuItem.Click
        Try
            mEncoders.ResetCount(USDigital.ANGLE_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ENCODER_ERROR, ex.Message)
        End Try
    End Sub
    Public Property Encoders As EncoderHardware
        Get
            Return mEncoders
        End Get
        Set(value As EncoderHardware)
            mEncoders = value
            If mEncoders IsNot Nothing Then
                EncoderButton.Enabled = True
            Else
                EncoderStatusLabel.Text = STR_ENCODER_NO_ENCODERS
                EncoderButton.Enabled = False
            End If
        End Set
    End Property
    Public Property Operation As String
        Get
            Return OperationStatusLabel.Text
        End Get
        Set(value As String)
            OperationStatusLabel.Text = value
        End Set
    End Property
    Public Property Status As EncoderStatus
        Get
            Return mStatus
        End Get
        Set(value As EncoderStatus)
            mStatus = value
            Select Case value
                Case EncoderStatus.NotInitialized
                    EncoderStatusLabel.Text = STR_ENCODER_NOT_INITIALIZED
                Case EncoderStatus.EncoderError
                    EncoderStatusLabel.Text = STR_ENCODER_ERROR
                Case EncoderStatus.NoEncoders
                    EncoderStatusLabel.Text = STR_ENCODER_NO_ENCODERS
                Case EncoderStatus.Ready
                    EncoderStatusLabel.Text = STR_ENCODER_READY
            End Select
        End Set
    End Property
    Public Property WorkstationName As String
        Get
            Return WorkstationNameLabel.Text
        End Get
        Set(value As String)
            WorkstationNameLabel.Text = value
        End Set
    End Property
End Class
