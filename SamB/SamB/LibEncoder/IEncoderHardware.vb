Public Interface IEncoderHardware
    ' Type that aggregates the radius value and its percentage of the diameter.
    Structure RadiusMeasurement
        Public Value As Double
        Public Percent As Double
    End Structure
    ' Defines the application programming interface (API) for calibrating and acquiring data from the hardware sensors.
    ReadOnly Property Initialized As Boolean
    Property AngleCalibration As Double
    Property DepthCalibration As Double
    Property RadiusCalibration As Double
    Property RadiusOffset As Integer
    Function Angle() As Double
    Function Calibrate(ByVal encoderNo As Integer) As Double
    Function Depth() As Double
    Function Radius(ByVal diameter As Double) As RadiusMeasurement
    Function ResetCount(ByVal encoderNo As Double) As Boolean
    Sub Initialize()
End Interface
