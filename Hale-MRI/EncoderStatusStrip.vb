Imports LibEncoder
Imports LibEncoder.EncoderHardware
Imports LibEncoder.USDigital
''' <summary>
''' ToolStrip control that provides visual status and
''' control of workstation encoders.
''' </summary>
Public Class EncoderStatusStrip
#Region "Types and Constants"
    ''' <summary>
    ''' Enumerates valid encoder commands
    ''' </summary>
    Private Enum EncoderCommand
        Angle           ' Get angle measurement
        AngleCalibrate  ' Calibrate angle encoder
        AngleReset      ' Reset angle encoder
        Depth           ' Get depth measurement
        DepthCalibrate  ' Calibrate depth encoder
        DepthReset      ' Reset depth encoder
        Initialize      ' Initialize encoders
        Radius          ' Get radius measurement
        RadiusCalibrate ' Calibrate radius encoder
        RadiusReset     ' Reset radius encoder
    End Enum
    Private Const STR_STATUS_BUSY As String = "Busy"
    Private Const STR_STATUS_ERROR As String = "Encoder Error"
    Private Const STR_STATUS_NO_ENCODERS As String = "No Encoders"
    Private Const STR_STATUS_NOT_INITIALIZED As String = "Not Initialized"
    Private Const STR_STATUS_READY As String = "Ready"
#End Region
#Region "Private Members"
    Private mEncoderStatus As EncoderStatus = EncoderStatus.NoEncoders  ' The current encoders status.
    Private mHardware As WorkstationEncoders = Nothing                  ' The current encoders hardware.
    Private WithEvents mScanTimer As New Timer                          ' Continuous scan timer
    Private mTimerOn As Boolean = False                                 ' Flag indicating whether the scan timer is currently active.
#End Region
#Region "Public Interface"
    Public ReadOnly Property EncoderStatus As EncoderStatus
        Get
            Return mEncoderStatus
        End Get
    End Property

    Public Property Hardware As WorkstationEncoders
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
            ControlsInitialize()
        End Set
    End Property

    Public ReadOnly Property Timer As Timer
        Get
            Return mScanTimer
        End Get
    End Property

    Public Property TimerInterval As Long
        Get
            Return mScanTimer.Interval
        End Get
        Set(value As Long)
            mScanTimer.Interval = value
        End Set
    End Property

    Public Property TimerOn As Boolean
        Get
            Return mTimerOn
        End Get
        Set(value As Boolean)
            mTimerOn = value
            If mTimerOn Then
                mScanTimer.Start()
            Else
                mScanTimer.Stop()
                TSButtonTimer.Visible = False
            End If
        End Set
    End Property

    Public Property WorkstationName As String
        Get
            Return TSLabelWorkstationName.Text
        End Get
        Set(value As String)
            TSLabelWorkstationName.Text = value
        End Set
    End Property

    Public Function Angle() As Double
        Return CType(Command(EncoderCommand.Angle), Double)
    End Function

    Public Function CalibrateAngle() As Double
        Return CType(Command(EncoderCommand.AngleCalibrate), Double)
    End Function

    Public Function CalibrateDepth() As Double
        Return CType(Command(EncoderCommand.DepthCalibrate), Double)
    End Function

    Public Function CalibrateRadius() As Double
        Return CType(Command(EncoderCommand.RadiusCalibrate), Double)
    End Function

    Public Function Depth() As Double
        Return CType(Command(EncoderCommand.Depth), Double)
    End Function

    Public Sub Initialize()
        Command(EncoderCommand.Initialize)
    End Sub

    Public Function Radius(ByVal diameter As Double) As IEncoderHardware.RadiusMeasurement
        Return CType(Command(EncoderCommand.Radius, diameter), IEncoderHardware.RadiusMeasurement)
    End Function

    Public Sub ResetAngle()
        Command(EncoderCommand.AngleReset)
    End Sub

    Public Sub ResetDepth()
        Command(EncoderCommand.DepthReset)
    End Sub

    Public Sub ResetRadius()
        Command(EncoderCommand.RadiusReset)
    End Sub
#End Region
#Region "Private Interface"
    Private Sub ControlsInitialize()
        If mHardware IsNot Nothing Then
            Me.Enabled = True
            If mHardware.Workstation IsNot Nothing Then
                WorkstationName = mHardware.Workstation.StationName
            End If
            If mHardware.Encoders IsNot Nothing Then
                If mHardware.Encoders.Initialized Then
                    SetEncoderStatus(EncoderStatus.Ready)
                Else
                    SetEncoderStatus(EncoderStatus.NotInitialized)
                End If
            Else
                SetEncoderStatus(EncoderStatus.NoEncoders)
            End If
        Else
            Me.Enabled = False
            TSButtonEncoders.Enabled = False
            TSLabelWorkstationName.Text = ""
            TSLabelEncodersStatus.Text = ""
        End If
    End Sub

    Private Function Command(cmd As EncoderCommand, Optional ByVal param As Double = 0.0) As Object
        Dim result As Object = Nothing
        If mHardware IsNot Nothing AndAlso mHardware.Encoders IsNot Nothing Then
            Try
                SetEncoderStatus(EncoderStatus.Busy)
                Select Case cmd
                    Case EncoderCommand.Angle
                        result = mHardware.Encoders.Angle
                    Case EncoderCommand.AngleCalibrate
                        result = mHardware.Encoders.Calibrate(ANGLE_ENCODER)
                    Case EncoderCommand.AngleReset
                        mHardware.Encoders.ResetCount(ANGLE_ENCODER)
                    Case EncoderCommand.Depth
                        result = mHardware.Encoders.Depth
                    Case EncoderCommand.DepthCalibrate
                        result = mHardware.Encoders.Calibrate(DEPTH_ENCODER)
                    Case EncoderCommand.DepthReset
                        mHardware.Encoders.ResetCount(DEPTH_ENCODER)
                    Case EncoderCommand.Initialize
                        mHardware.Encoders.Initialize()
                    Case EncoderCommand.Radius
                        result = mHardware.Encoders.Radius(param)
                    Case EncoderCommand.RadiusCalibrate
                        result = mHardware.Encoders.Calibrate(RADIUS_ENCODER)
                    Case EncoderCommand.RadiusReset
                        mHardware.Encoders.ResetCount(RADIUS_ENCODER)
                End Select
                If mHardware.Encoders.Initialized Then SetEncoderStatus(EncoderStatus.Ready)
            Catch ex As Exception
                SetEncoderStatus(EncoderStatus.EncoderError)
            End Try
        End If
        Return result
    End Function

    Private Sub SetEncoderStatus(status As EncoderStatus)
        mEncoderStatus = status
        Select Case mEncoderStatus
            Case EncoderStatus.Busy
                TSLabelEncodersStatus.ForeColor = Color.Black
                TSLabelEncodersStatus.Text = STR_STATUS_BUSY
                TSButtonEncoders.Enabled = False
                Me.Refresh()
            Case EncoderStatus.EncoderError
                TSLabelEncodersStatus.ForeColor = Color.Red
                TSLabelEncodersStatus.Text = STR_STATUS_ERROR
            Case EncoderStatus.NoEncoders
                TSLabelEncodersStatus.ForeColor = Color.Red
                TSLabelEncodersStatus.Text = STR_STATUS_NO_ENCODERS
                TSButtonEncoders.Enabled = False
            Case EncoderStatus.NotInitialized
                TSLabelEncodersStatus.ForeColor = Color.Red
                TSLabelEncodersStatus.Text = STR_STATUS_NOT_INITIALIZED
                TSButtonEncoders.Enabled = True
            Case EncoderStatus.Ready
                TSLabelEncodersStatus.ForeColor = Color.Green
                TSLabelEncodersStatus.Text = STR_STATUS_READY
                TSButtonEncoders.Enabled = True
            Case Else
                TSLabelEncodersStatus.Text = ""
                TSButtonEncoders.Enabled = False
        End Select

    End Sub
#End Region
#Region "Event Handlers"
    Private Sub InitializeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitializeToolStripMenuItem.Click
        Me.Initialize()
    End Sub

    Private Sub AngleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AngleToolStripMenuItem.Click
        Me.ResetAngle()
    End Sub

    Private Sub DepthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepthToolStripMenuItem.Click
        Me.ResetDepth()
    End Sub

    Private Sub RadiusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RadiusToolStripMenuItem.Click
        Me.ResetRadius()
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        Me.ResetAngle()
        Me.ResetDepth()
        Me.ResetRadius()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TimerOn = True
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TimerOn = False
    End Sub

    Private Sub EncoderStatusStrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Enabled = False
        TSButtonEncoders.Enabled = False
        TSButtonTimer.Visible = False
        TSLabelWorkstationName.Text = ""
        TSLabelEncodersStatus.Text = ""
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs) Handles mScanTimer.Tick
        TSButtonTimer.Visible = Not TSButtonTimer.Visible
    End Sub
#End Region
End Class
