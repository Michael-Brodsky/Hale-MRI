''' <summary>
''' Digital FIR Cumulative Moving Average Filter
''' y[n+1] = (x[n+1] + n * y[n]) / (n + 1)
''' </summary>
Public Class MovingAverage
    Private mWindow() As Double = Array.Empty(Of Double)    ' Data buffer, implemented as a linear FIF0 queue.
    Private N As UShort = 0                                 ' Pointer to the buffer's current "tail" element.

    Public Sub New()
        ' Creates an uninitialized MovingAverage filter.
    End Sub

    Public Sub New(sz As UShort)
        ' Creates and initializes a MovingAverage filter of size sz.
        Size = sz
    End Sub

    Public Sub Clear()
        ' Clears and reinitializes the data buffer.
        Dim sz As UShort = Size
        Size = sz  ' Size = Size, without the CA2245 warning.
    End Sub

    Public Sub Input(value As Double)
        ' Effectively pushes "value" on to the end of the data buffer and updates Total.
        Total -= mWindow(N)
        Total += value
        mWindow(N) = value
        N = (N + 1) Mod Size
    End Sub
    Public Function Output() As Double
        ' Returns the current moving average.
        Return Total / Size
    End Function

    Public Function Output(value As Double) As Double
        ' Adds the given value to the data buffer and returns the resulting moving average.
        Input(value)
        Return Output()
    End Function

    Public Property Size As UShort
        Get
            Return mWindow.Length
        End Get
        Set(value As UShort)
            ReDim mWindow(value - 1)    ' Initialize the data buffer.
            Total = 0                   ' Clear the cumulative sum.
            N = 0                       ' Reset the tail pointer.
        End Set
    End Property

    Private Property Total As Double = 0.0  ' Holds the data buffer's cumulative sum.
End Class
