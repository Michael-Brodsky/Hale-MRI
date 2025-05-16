Public Class USDigital
    ' Concrete implementation of the IPropellerData interface for the USDigital hardware.
    Implements IPropellerData
    Public Sub New()
        ' Create and initialize a new instance of the USDigital data acquisition hardware class
        Init()
    End Sub
    Public Function Angle() As Double Implements IPropellerData.Angle
        ' Return the angle value
        Return IPropellerData_Angle()
    End Function
    Public Function Depth() As Double Implements IPropellerData.Depth
        ' Return the depth value
        Return IPropellerData_Depth()
    End Function
    Public Function Radius() As Double Implements IPropellerData.Radius
        ' Return the radius value
        Return IPropellerData_Radius()
    End Function

    Private Sub Init()
        ' Hardware specific initialization code
    End Sub
    Private Function IPropellerData_Angle() As Double
        ' Hardware specific code to get the angle value
        Return 0.0
    End Function

    Private Function IPropellerData_Depth() As Double
        ' Hardware specific code to get the depth value
        Return 0.0
    End Function

    Private Function IPropellerData_Radius() As Double
        ' Hardware specific code to get the radius value
        Return 0.0
    End Function
End Class
