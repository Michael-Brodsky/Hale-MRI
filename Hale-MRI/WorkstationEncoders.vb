Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder

''' <summary>
''' Encapsulates the encoder hardware and workstation calibration data,
''' and performs routine initialization.
''' </summary>
''' 

Public Class WorkstationEncoders
#Region "Private Members"
    Private mWorkstation As Workstation             ' Workstation calibration data from database 
    Private mEncoders As EncoderHardware            ' Encoder hardware instance
#End Region
#Region "Public Interface"
    Public Property PollingInterval As Long = 200   ' Encoder polling interval in milliseconds
    Public Property Encoders As EncoderHardware     ' Gets or sets the encoder hardware instance.
        Get
            Return mEncoders
        End Get
        Set(value As EncoderHardware)
            mEncoders = value
            InitializeEncoders()
        End Set
    End Property
    Public Property Workstation As Workstation      ' Gets or sets the workstation calibration data.
        Get
            Return mWorkstation
        End Get
        Set(value As Workstation)
            mWorkstation = value
            InitializeEncoders()
        End Set
    End Property
    Public Sub New()
        ' Constructor retrieves the workstation calibration data and initializes the USDigital encoders
        mEncoders = New EncoderHardware(New USDigital())
        Using dbContext As New HaleMRIContext()
            Me.Workstation = QryWorkstationCalibration(dbContext, FormatString(My.Computer.Name))
            Me.PollingInterval = Integer.Parse(SettingsGet(dbContext, STR_SETTING_ENCODER_DEFAULT_SAMPLE_PERIOD))
        End Using
    End Sub
#End Region
#Region "Private Interface"
    Private Sub InitializeEncoders()
        ' Copy the workstation calibration data to the encoder calibration properties.
        If mWorkstation IsNot Nothing AndAlso mEncoders IsNot Nothing Then
            mEncoders.AngleCalibration = mWorkstation.AngleCalibration
            mEncoders.DepthCalibration = mWorkstation.DepthCalibration
            mEncoders.RadiusCalibration = mWorkstation.RadiusCalibration
            mEncoders.RadiusOffset = mWorkstation.RadiusOffset
        End If
    End Sub
#End Region
End Class
