Imports LibEncoder

''' <summary>
''' Form Control that can be used by clients that access
''' workstation encoder hardware to visually manipulate 
''' and provide real time status of the encoders. 
''' </summary>
''' 
Public Class WorkstationStatusStrip
#Region "Private Members"
    Private Const STR_STATUS_BUSY As String = "Busy"
    Private Const STR_STATUS_NOT_INITIALIZED As String = "Not Initialized"
    Private Const STR_STATUS_ERROR As String = "Encoder Error"
    Private Const STR_STATUS_NO_ENCODERS As String = "No encoders"
    Private Const STR_STATUS_READY As String = "Ready"
    Private mHardware As WorkstationEncoders
    Private mStatus As EncoderStatus = EncoderStatus.NoEncoders
#End Region
#Region "Public Interface"
    Public Enum EncoderStatus
        NotInitialized
        EncoderError
        NoEncoders
        Ready
        Busy
    End Enum

    Public Property Hardware As WorkstationEncoders
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            EncoderButton.Enabled = False
            mHardware = value
            If mHardware IsNot Nothing Then
                If mHardware.Workstation IsNot Nothing Then WorkstationName = mHardware.Workstation.StationName
                If mHardware.Encoders IsNot Nothing Then
                    If mHardware.Encoders.Initialized Then
                        Status = EncoderStatus.Ready
                    Else
                        Status = EncoderStatus.NotInitialized
                    End If
                Else
                    Status = EncoderStatus.NoEncoders
                End If
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
                    EncoderStatusLabel.Text = STR_STATUS_NOT_INITIALIZED
                    EncoderStatusLabel.ForeColor = Color.Red
                    EncoderButton.Enabled = True
                    EncoderMenuItemsEnable(False)
                Case EncoderStatus.EncoderError
                    EncoderStatusLabel.Text = STR_STATUS_ERROR
                    EncoderStatusLabel.ForeColor = Color.Red
                    EncoderButton.Enabled = True
                    EncoderMenuItemsEnable(False)
                Case EncoderStatus.NoEncoders
                    EncoderStatusLabel.Text = STR_STATUS_NO_ENCODERS
                    EncoderStatusLabel.ForeColor = Color.Red
                    EncoderButton.Enabled = True
                    EncoderMenuItemsEnable(False)
                Case EncoderStatus.Ready
                    EncoderStatusLabel.Text = STR_STATUS_READY
                    EncoderStatusLabel.ForeColor = Color.Green
                    EncoderButton.Enabled = True
                    EncoderMenuItemsEnable(True)
                Case EncoderStatus.Busy
                    EncoderStatusLabel.Text = STR_STATUS_BUSY
                    EncoderStatusLabel.ForeColor = Color.Black
                    EncoderButton.Enabled = False
            End Select
            Me.Refresh()
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

    Public Function Angle() As Double
        Dim result As Double = 0.0
        Try
            Status = EncoderStatus.Busy
            result = mHardware.Encoders.Angle()
            Status = EncoderStatus.Ready
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
        Return result
    End Function

    Public Function Calibrate(ByVal encoderNo As Integer) As Double
        Dim result As Double = 0.0
        Try
            Status = EncoderStatus.Busy
            result = mHardware.Encoders.Calibrate(encoderNo)
            Status = EncoderStatus.Ready
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
        Return result
    End Function

    Public Function Depth() As Double
        Dim result As Double = 0.0
        Try
            Status = EncoderStatus.Busy
            result = mHardware.Encoders.Depth()
            Status = EncoderStatus.Ready
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
        Return result
    End Function

    Public Sub Initialize()
        Try
            Status = EncoderStatus.Busy
            mHardware.Encoders.Initialize()
            Status = If(mHardware.Encoders.Initialized, EncoderStatus.Ready, EncoderStatus.NotInitialized)
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
    End Sub

    Public Function Radius(ByVal diameter As Double) As IEncoderHardware.RadiusMeasurement
        Dim result As IEncoderHardware.RadiusMeasurement
        Try
            Status = EncoderStatus.Busy
            result = mHardware.Encoders.Radius(diameter)
            Status = EncoderStatus.Ready
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
        Return result
    End Function

    Public Sub Reset(ByVal encoderNo As Integer)
        Try
            Status = EncoderStatus.Busy
            mHardware.Encoders.ResetCount(encoderNo)
            Status = EncoderStatus.Ready
        Catch ex As Exception
            Status = EncoderStatus.EncoderError
            Throw
        End Try
    End Sub
#End Region
#Region "Private Interface"
    Private Sub EncoderMenuItemsEnable(ByVal enabled As Boolean)
        EncoderAngleResetMenuItem.Enabled = enabled
        EncoderDepthResetMenuItem.Enabled = enabled
        EncoderRadiusResetMenuItem.Enabled = enabled
    End Sub
    Private Sub EncodersErrorShow(msg As String)
        ' Display an error message and update the UI accordingly
        Status = EncoderStatus.EncoderError
        MsgBox(msg, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub EncoderAngleResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderAngleResetMenuItem.Click
        Try
            Reset(USDigital.ANGLE_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(ex.Message)
        End Try
    End Sub
    Private Sub EncoderDepthResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderDepthResetMenuItem.Click
        Try
            Reset(USDigital.DEPTH_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(ex.Message)
        End Try
    End Sub
    Private Sub EncoderRadiusResetMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderRadiusResetMenuItem.Click
        Try
            Reset(USDigital.RADIUS_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(ex.Message)
        End Try
    End Sub
    Private Sub EncoderInitializeMenuItem_Click(sender As Object, e As EventArgs) Handles EncoderInitializeMenuItem.Click
        Try
            Initialize()
        Catch ex As Exception
            EncodersErrorShow(ex.Message)
        End Try
    End Sub
#End Region
End Class
