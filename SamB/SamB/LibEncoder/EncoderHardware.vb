Public Class EncoderHardware
    ' This class is responsible for calibrating and acquiring data from the hardware sensors
    ' and exposing the IEncoderData API.
    Private mEncoder As IEncoderHardware
    Public Sub New(aHardware As IEncoderHardware)
        ' Create and initialize a new instance of the EncoderData class
        mEncoder = aHardware
    End Sub
    Public Property AngleCalibration() As Double
        Get
            ' Return the angle calibration value
            Return mEncoder.AngleCalibration
        End Get
        Set(ByVal value As Double)
            ' Set the angle calibration value
            mEncoder.AngleCalibration = value
        End Set
    End Property
    Public Property DepthCalibration() As Double
        Get
            ' Return the depth calibration value
            Return mEncoder.DepthCalibration
        End Get
        Set(ByVal value As Double)
            ' Set the depth calibration value
            mEncoder.DepthCalibration = value
        End Set
    End Property
    Public ReadOnly Property Initialized As Boolean
        Get
            ' Return whether the encoder is initialized
            Return mEncoder.Initialized
        End Get
    End Property
    Public Property RadiusCalibration() As Double
        Get
            ' Return the radius calibration value
            Return mEncoder.RadiusCalibration
        End Get
        Set(ByVal value As Double)
            ' Set the radius calibration value
            mEncoder.RadiusCalibration = value
        End Set
    End Property
    Public Property RadiusOffset() As Integer
        Get
            ' Return the radius offset value
            Return mEncoder.RadiusOffset
        End Get
        Set(ByVal value As Integer)
            ' Set the radius offset value
            mEncoder.RadiusOffset = value
        End Set
    End Property
    Public Sub ResetCount(ByVal encoderNo As Integer)
        ' Reset the chosen encoder count
        mEncoder.ResetCount(encoderNo)
    End Sub
    Public Sub Initialize()
        mEncoder.Initialize()
    End Sub
    Public Function Angle() As Double
        ' Return the angle value
        Return mEncoder.Angle()
    End Function
    Public Function Calibrate(ByVal encoderNo As Integer) As Double
        Return mEncoder.Calibrate(encoderNo)
    End Function
    Public Function Depth() As Double
        ' Return the depth value
        Return mEncoder.Depth()
    End Function
    Public Function Radius(ByVal diameter As Double) As IEncoderHardware.RadiusMeasurement
        ' Return the radius value
        Return mEncoder.Radius(diameter)
    End Function
End Class
