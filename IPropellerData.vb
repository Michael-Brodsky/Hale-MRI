Public Interface IPropellerData
    ' Defines the application programming interface (API) for acquiring data from the hardware sensors.
    Function Angle() As Double
    Function Depth() As Double
    Function Radius() As Double
End Interface
