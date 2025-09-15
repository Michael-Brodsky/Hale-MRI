''' <summary>
''' Defines the application programming interface (API) for calibrating and acquiring data from the hardware sensors.
''' </summary>
Public Interface IEncoderHardware
    ''' <summary>
    ''' Aggregates the radius value and its percentage of the diameter.
    ''' </summary>
    Structure RadiusMeasurement
        Public Value As Double
        Public Percent As Double
    End Structure

    ReadOnly Property Initialized As Boolean
    Property AngleCalibration As Double
    Property DepthCalibration As Double
    Property RadiusCalibration As Double
    Property RadiusOffset As Integer
    Sub Initialize()
    Sub ResetCount(ByVal encoderNo As Integer)
    Function Angle() As Double
    Function Calibrate(ByVal encoderNo As Integer) As Double
    Function Depth() As Double
    Function Radius(ByVal diameter As Double) As RadiusMeasurement
End Interface
