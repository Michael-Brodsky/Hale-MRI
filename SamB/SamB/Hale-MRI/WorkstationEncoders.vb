Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
Imports Microsoft.EntityFrameworkCore
Public Class WorkstationEncoders
    ' This class encapsulates the encoder hardware and workstation calibration data
    ' and performs routine initialization.
    Private mWorkstation As Workstation             ' Workstation calibration data from database 
    Private mEncoders As EncoderHardware            ' Encoder hardware instance
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
        ' Constructor retrieves the workstation calibration data and initializes the encoders
        mEncoders = New EncoderHardware(New USDigital())
        Using dbContext As New HaleMRIContext()
            Me.Workstation = QryWorkstationCalibration(dbContext, My.Computer.Name)
            Me.PollingInterval = dbContext.Settings.FirstOrDefault().EncoderCalibrationSampleRate
        End Using
    End Sub
    Private Sub InitializeEncoders()
        ' Copy the workstation calibration data to the encoders
        If mWorkstation IsNot Nothing AndAlso mEncoders IsNot Nothing Then
            mEncoders.AngleCalibration = mWorkstation.AngleCalibration
            mEncoders.DepthCalibration = mWorkstation.DepthCalibration
            mEncoders.RadiusCalibration = mWorkstation.RadiusCalibration
        End If
    End Sub
End Class
