Public Class PropellerData
    ' This class is responsible for acquiring data from the hardware sensors.
    Private m_hardware As IPropellerData

    Public Sub New(aHardware As IPropellerData)
        ' Create and intialize a new instance of the PropellerData class
        m_hardware = aHardware
    End Sub
    Public Function Angle() As Double
        ' Return the angle value
        Return m_hardware.Angle()
    End Function
    Public Function Depth() As Double
        ' Return the depth value
        Return m_hardware.Depth()
    End Function
    Public Function Radius() As Double
        ' Return the radius value
        Return m_hardware.Radius()
    End Function
End Class
