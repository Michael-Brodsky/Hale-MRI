Imports LibDatabase.Models
Imports LibDatabase.Contexts
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Diagnostics.Metrics

Public Module Imex
    ' This module provides functionality to import and export calibration and scan data.
#Region "Types and Constants"
    Private Enum CalibrationLineId  ' Enumerates significant line numbers in calibration data text files.
        cdAngleResolution = 1
        cdAngleCalibration = 2
        cdRadiusResolution = 3
        cdRadiusCalibration = 4
        cdDepthResolution = 5
        cdDepthCalibration = 6
        cdRadiusOffset = 7
        cdHalfProbeDia = 8
        cdScanIncrement = 9
        cdRodDesign = 10
        cdShopName = 11
        cdFixedOffset = 12
        cdRadiusOffsetL = 13
    End Enum
    Private Enum ScanDataLineId     ' Enumerates significant line numbers in scan data text files.
        idFileType = 1
        idCustomer = 2
        idVessel = 3
        idJobNumber = 4
        idDiameter = 5
        idMarkedPitch = 6
        idRotation = 7
        idClass = 8
        idStage = 9
        idID = 10
        idFileName = 11
        idDateTime = 12
        idExclusions = 13
        idPartNumber = 14
        idSerialNumber = 15
        idStampNumber = 16
        idInspectedBy = 17
        idDesiredPitch = 18
        idDAR = 19
        idBore = 20
        idCup = 21
        idManufacturer = 22
        idStyle = 23
        idMaterial = 24
        idRadiusFirst = 25
        idRadiusLast = 34
        idBladeCount = 35
    End Enum
    Private Structure Exclusions    ' Type that aggregates exclusion values.
        Public LeExclusion As Double
        Public TeExclusion As Double
    End Structure
    Private Class CellMeasurement   ' Type that aggregates cell measurement values.
        Public Property Angle As Double
        Public Property Depth As Double
    End Class
    Private Class Cell              ' Collects cell measurements over multiple lines.
        Private Enum MeasurementState
            Angle
            Depth
            Done
        End Enum
        Private mMeasurements As New List(Of CellMeasurement)()
        Public ReadOnly Property Measurements As List(Of CellMeasurement)
            Get
                Return mMeasurements
            End Get
        End Property
        Public WriteOnly Property Value As String
            Set(ByVal value As String)
                SaveValue(value)
            End Set
        End Property
        Private Sub SaveValue(ByVal value As String)
            Static state As MeasurementState = MeasurementState.Angle
            Static m As Integer = 0

            If mMeasurements.Count = m Then mMeasurements.Add(New CellMeasurement())
            Select Case state
                Case MeasurementState.Angle
                    mMeasurements(m).Angle = Convert.ToDouble(value)
                Case MeasurementState.Depth
                    mMeasurements(m).Depth = Convert.ToDouble(value)
                Case Else
            End Select
            state += 1
            If state = MeasurementState.Done Then
                state = MeasurementState.Angle
                m += 1
            End If
        End Sub
    End Class
    Private Class Extremes          ' Collects extreme measurement values over multiple lines.
        Private mMeasurements As New List(Of Double)
        Public ReadOnly Property Measurements As List(Of Double)
            Get
                Return mMeasurements
            End Get
        End Property
        Public WriteOnly Property Value As String
            Set(ByVal value As String)
                mMeasurements.Add(Convert.ToDouble(value))
            End Set
        End Property
    End Class
    Private Class RadiusMeasurement ' Type that aggregates radius measurement values.
        Public Property Radius As Double
        Public Property LeCell As Integer
        Public Property TeCell As Integer
    End Class
    Private Class Radius            ' Collects radius measurements over multiple lines.
        Private Enum MeasurementState
            Radius
            LeCell
            TeCell
            Done
        End Enum
        Private Const kLinesPerMeasurement As Integer = 3
        Private mMeasurements As New List(Of RadiusMeasurement)()
        Private mBlades As New List(Of Integer)()
        Public WriteOnly Property BladeCount As Integer
            Set(ByVal value As Integer)
                'mBlades.Clear()
                For i As Integer = 1 To value
                    mMeasurements.Add(New RadiusMeasurement())
                Next
                mBlades.Add(value)
            End Set
        End Property
        Public ReadOnly Property Blades As List(Of Integer)
            Get
                Return mBlades
            End Get
        End Property
        Public ReadOnly Property Measurements As List(Of RadiusMeasurement)
            Get
                Return mMeasurements
            End Get
        End Property
        Public ReadOnly Property LineCount As Integer
            Get
                Return mBlades.Sum * kLinesPerMeasurement
            End Get
        End Property
        Public WriteOnly Property Value As String
            Set(ByVal value As String)
                SaveValue(value)
            End Set
        End Property
        Private Sub SaveValue(value As String)
            Static state As MeasurementState = MeasurementState.Radius
            Static blade As Integer = 0
            Static m As Integer = 0
            Static n As Integer = 0
            If mMeasurements.Count = m Then mMeasurements.Add(New RadiusMeasurement())
            Select Case state
                Case MeasurementState.Radius
                    mMeasurements(n + m).Radius = Convert.ToDouble(value)
                Case MeasurementState.LeCell
                    mMeasurements(n + m).LeCell = Convert.ToInt32(value)
                Case MeasurementState.TeCell
                    mMeasurements(n + m).TeCell = Convert.ToInt32(value)
                Case Else
            End Select
            state += 1
            If state = MeasurementState.Done Then
                state = MeasurementState.Radius
                m += 1
                If m = mBlades(blade) Then
                    m = 0
                    n += mBlades(blade)
                    blade += 1
                End If
            End If
        End Sub
    End Class
    ' Hale-MRI file string constants.
    Private Const kMRIFileType As String = "3"
    Private Const kMRIEndOfFile As String = "102"
    Private Const kMRIDummyText As String = "Dummy Text"
    Private Const kMRIRodDesignText As String = "#TRUE#"
    Private Const kMRIAngleResolution As String = "AngleResolution"
    Private Const kMRIAngleCalibration As String = "AngleCalibration"
    Private Const kMRIRadiusResolution As String = "RadiusResolution"
    Private Const kMRIRadiusCalibration As String = "RadiusCalibration"
    Private Const kMRIDepthResolution As String = "DepthResolution"
    Private Const kMRIDepthCalibration As String = "DepthCalibration"
    Private Const kMRIRadiusOffset As String = "RadiusOffset"
    Private Const kMRIHalfProbeDia As String = "HalfProbeDia"
    Private Const kMRIScanIncrement As String = "ScanIncrement"
    Private Const kMRIRodDesign As String = "RodDesign"
    Private Const kMRIShopName As String = "ShopName"
    Private Const kMRIFixedOffset As String = "FixedOffset"
    Private Const kMRIRadiusOffsetL As String = "RadiusOffsetL"
    Private Const kMRICalibrationWrite As String = """<Key> = "",<Value>"
#End Region
#Region "Public Interface"
    Public Sub CalibrationDataExport(ByVal ws As Workstation, ByVal outFile As String)
        ' Exports the workstation's calibration data to a text file.
        If File.Exists(outFile) Then Throw New IOException("Calibration data file already exists: " & outFile)
        Dim ostream As New StreamWriter(outFile, True)
        WriteCalibrationsData(ws, ostream)
        ostream.Close()
    End Sub
    Public Function CalibrationDataImport(ByVal name As String, ByVal inFile As String) As Workstation
        ' Imports the calibration data from a text file into a workstation object.
        If Not File.Exists(inFile) Then Throw New FileNotFoundException("Calibration data file not found.", inFile)
        Dim istream As New StreamReader(inFile)
        Dim ws As New Workstation With {.Hostname = name}
        ReadCalibrationData(ws, istream)
        istream.Close()
        Return ws
    End Function

    Public Sub ScanDataExport(ByVal sd As ScanData, ByVal outFile As String)
        If File.Exists(outFile) Then Throw New IOException("Scan data file already exists: " & outFile)
        Dim ostream As New StreamWriter(outFile, True)
    End Sub
    Public Function ScanDataImport(ByVal inFile As String) As ScanData
        ' Imports scan data from a text file and returns a ScanData object.
        If Not File.Exists(inFile) Then Throw New FileNotFoundException("Scan data file not found.", inFile)
        Dim istream As New StreamReader(inFile)
        Dim sd As New ScanData()
        ReadScanData(sd, istream, File.ReadAllLines(inFile).Length)
        istream.Close()
        Return sd
    End Function
#End Region
#Region "Private Interface"
    Private Sub ReadCalibrationData(ByRef ws As Workstation, ByVal istream As StreamReader)
        ' Reads calibration data from a text file and populates the Workstation object
        ' according to the line number.
        Dim line As String
        Dim lineId As CalibrationLineId = CalibrationLineId.cdAngleResolution
        Dim pattern As New Regex("[^0-9\.\- ]+")    'Matches anything that is not a digit, decimal point, negative sign, or space.
        Do While Not istream.EndOfStream
            line = TrimReplace(pattern, istream.ReadLine())
            If String.IsNullOrWhiteSpace(line) Then GoTo SkipLine
            Select Case lineId
                Case CalibrationLineId.cdAngleResolution
                    ws.AngleResolution = Convert.ToInt32(line)
                Case CalibrationLineId.cdAngleCalibration
                    ws.AngleCalibration = Convert.ToDouble(line)
                Case CalibrationLineId.cdRadiusResolution
                    ws.RadiusResolution = Convert.ToInt32(line)
                Case CalibrationLineId.cdRadiusCalibration
                    ws.RadiusCalibration = Convert.ToDouble(line)
                Case CalibrationLineId.cdDepthResolution
                    ws.DepthResolution = Convert.ToInt32(line)
                Case CalibrationLineId.cdDepthCalibration
                    ws.DepthCalibration = Convert.ToDouble(line)
                Case CalibrationLineId.cdRadiusOffset
                    ws.RadiusOffset = Convert.ToInt32(line)
                Case CalibrationLineId.cdHalfProbeDia
                    ws.HalfProbeDiameter = Convert.ToInt32(line)
                Case CalibrationLineId.cdScanIncrement
                    ws.ScanIncrement = Convert.ToInt32(line)
                Case CalibrationLineId.cdRodDesign
                    ' Not used in this implementation
                Case CalibrationLineId.cdShopName
                    ' Not used in this implementation
                Case CalibrationLineId.cdFixedOffset
                    ws.FixedOffset = Convert.ToInt32(line)
                Case CalibrationLineId.cdRadiusOffsetL
                    ws.RadiusOffsetL = Convert.ToInt32(line)
            End Select
SkipLine:
            lineId += 1
        Loop
    End Sub
    Private Sub ReadScanData(ByRef sd As ScanData, ByVal istream As StreamReader, ByVal lineCount As Integer)
        ' Reads scan data from a text file and populates the ScanData object
        ' according to the line number.
        Dim line As String
        Dim lineId As ScanDataLineId = ScanDataLineId.idFileType
        Dim skipped As Integer = 0
        Dim regex As New Regex("[^A-Za-z0-9\,\.\/\-\~\: ]+")    ' Matches anything that is not a letter, digit, comma, period, slash, hyphen, tilde, colon, or space.
        Dim radii As New Radius()
        Dim cells As New Cell()
        Dim extremes As New Extremes()
        On Error Resume Next
        Do While Not istream.EndOfStream
            line = TrimReplace(regex, istream.ReadLine())
            If lineId > ScanDataLineId.idJobNumber And String.IsNullOrWhiteSpace(line) Then GoTo SkipLine
            Select Case lineId
                Case ScanDataLineId.idFileType
                    ' Skip this line
                    skipped = 1
                Case ScanDataLineId.idCustomer
                    sd.Customer = New Customer With {.CustomerName = line}
                Case ScanDataLineId.idVessel
                    If sd.Customer Is Nothing Then sd.Customer = New Customer With {.CustomerName = String.Empty}
                    sd.Customer.Vessels = New List(Of Vessel) From {
                        New Vessel With {.VesselName = line}
                    }
                Case ScanDataLineId.idJobNumber
                    ' If we don't get a valid job number, exit the loop.
                    Dim jobNumber As Integer = Convert.ToInt32(line)
                    If jobNumber = 0 Then Exit Do
                    sd.Job = New Job With {
                        .JobNumber = jobNumber,
                        .JobDetails = New List(Of JobDetail) From {
                            New JobDetail With {.Diameter = Nothing}
                        }
                    }
                Case ScanDataLineId.idDiameter
                    sd.Job.JobDetails(0).Diameter = Convert.ToDouble(line)
                Case ScanDataLineId.idMarkedPitch
                    sd.Job.JobDetails(0).MarkedPitch = Convert.ToDouble(line)
                Case ScanDataLineId.idRotation
                    sd.Job.JobDetails(0).Rotation = line
                Case ScanDataLineId.idClass
                    sd.Job.JobDetails(0).ToleranceClass = line
                Case ScanDataLineId.idStage
                    sd.Job.JobDetails(0).Description = line
                Case ScanDataLineId.idFileName
                    sd.Job.JobDetails(0).FileName = line
                Case ScanDataLineId.idDateTime
                    sd.Job.JobDetails(0).StartDate = DateTime.Parse(line)
                Case ScanDataLineId.idExclusions
                    If InStr(line, kMRIDummyText) > 0 Then
                        Dim exclusions As String() = line.Split("~"c)
                        Dim ex As New Exclusions With {
                                .LeExclusion = Convert.ToDouble(exclusions(0))
                            }
                        If exclusions.Length = 2 Then ex.TeExclusion = Convert.ToDouble(exclusions(1))
                        sd.Job.JobDetails(0).LeExclusion = ex.LeExclusion
                        sd.Job.JobDetails(0).TeExclusion = ex.TeExclusion
                    End If
                Case ScanDataLineId.idPartNumber
                    sd.Job.PartNumber = line
                Case ScanDataLineId.idSerialNumber
                    sd.Job.SerialNumber = line
                Case ScanDataLineId.idStampNumber
                    sd.Job.StampNumber = line
                Case ScanDataLineId.idInspectedBy
                    sd.Job.InspectedByNavigation = New Employee With {.EmployeeName = line}
                Case ScanDataLineId.idDesiredPitch
                    sd.Job.JobDetails(0).DesiredPitch = Convert.ToDouble(line)
                Case ScanDataLineId.idDAR
                    sd.Job.JobDetails(0).Dar = Convert.ToDouble(line)
                Case ScanDataLineId.idBore
                    sd.Job.JobDetails(0).Bore = line
                Case ScanDataLineId.idCup
                    sd.Job.JobDetails(0).Cup = Convert.ToDouble(line)
                Case ScanDataLineId.idManufacturer
                    sd.Job.Manufacturer = New Manufacturer With {.ManufacturerName = line}
                Case ScanDataLineId.idStyle
                    sd.Job.Style = line
                Case ScanDataLineId.idMaterial
                    sd.Job.Material = line
                Case ScanDataLineId.idRadiusFirst To ScanDataLineId.idRadiusLast
                    ' Read blade measurement counts
                    radii.BladeCount = Convert.ToInt32(line)
                Case ScanDataLineId.idBladeCount
                    sd.Job.Blades = Convert.ToInt32(line)
                Case ScanDataLineId.idBladeCount + 1 To ScanDataLineId.idBladeCount + radii.LineCount
                    ' Read radius measurements
                    radii.Value = line
                Case ScanDataLineId.idBladeCount + radii.LineCount + 1 To lineCount - sd.Job.Blades - skipped + 1
                    ' Read cell measurements
                    cells.Value = line
                Case Is > lineCount - sd.Job.Blades - skipped + 1
                    If line = "102" Then
                        ' End of file marker, save measurements
                        SaveMeasurements(sd, radii, extremes, cells)
                    Else
                        extremes.Value = line
                    End If
                Case Is > lineCount
                    Exit Do
                Case Else
                    skipped += 1
            End Select
SkipLine:
            lineId += 1
            'If lineId > ScanDataLineId.idJobNumber And sd.Job Is Nothing Then Exit Do
        Loop
    End Sub
    Private Sub WriteScanData(ByVal sd As ScanData, ByVal ostream As StreamWriter)
        ' Writes the scan data to a text file in the expected order.
    End Sub
    Private Sub SaveMeasurements(ByRef sd As ScanData, ByVal radii As Radius, ByVal extremes As Extremes, ByVal cells As Cell)
        ' Saves the collected measurements into the ScanData object.
        SaveRadiusMeasurements(sd, radii)
        SaveCellMeasurements(sd, cells)
        SaveExtremeMeasurements(sd, extremes)
    End Sub
    Private Sub SaveCellMeasurements(ByRef sd As ScanData, ByVal cells As Cell)
        ' Saves cell measurements into the ScanData object.
        For Each cm As CellMeasurement In cells.Measurements
            sd.Job.JobDetails(0).CellMeasurements.Add(New Models.CellMeasurement With {
                .Angle = cm.Angle,
                .Depth = cm.Depth
            })
        Next
    End Sub
    Private Sub SaveExtremeMeasurements(ByRef sd As ScanData, ByVal extremes As Extremes)
        ' Saves extreme measurements into the ScanData object.
        Dim b As Integer = 1
        For Each em As Double In extremes.Measurements
            sd.Job.JobDetails(0).ExtremeMeasurements.Add(New Models.ExtremeMeasurement With {
                .BladeId = b,
                .Extreme = em
            })
            b += 1
        Next
    End Sub
    Private Sub SaveRadiusMeasurements(ByRef sd As ScanData, ByVal radii As Radius)
        ' Saves radius measurements into the ScanData object.
        Dim b As Integer = 1
        Dim m As Integer = 0
        For Each rm As RadiusMeasurement In radii.Measurements
            sd.Job.JobDetails(0).RadiusMeasurements.Add(New Models.RadiusMeasurement With {
                .BladeId = b,
                .Radius = rm.Radius,
                .LeCell = rm.LeCell,
                .TeCell = rm.TeCell
            })
            m += 1
            If m = radii.Blades(b - 1) Then
                m = 0
                b += 1
            End If
            b += 1
        Next
    End Sub
    Private Function TrimReplace(pattern As Regex, ByVal s As String) As String
        ' Removes unwanted characters from a string using a regex pattern.
        If s Is Nothing Then Return String.Empty
        Return pattern.Replace(s, String.Empty).Trim()
    End Function
    Private Sub WriteCalibrationsData(ByVal ws As Workstation, ByVal istream As StreamWriter)
        ' Writes the workstation's calibration data to a text file in the expected order.
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIAngleResolution), "<Value>", ws.AngleResolution))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIAngleCalibration), "<Value>", ws.AngleCalibration))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIRadiusResolution), "<Value>", ws.RadiusResolution))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIRadiusCalibration), "<Value>", ws.RadiusCalibration))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIDepthResolution), "<Value>", ws.DepthResolution))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIDepthCalibration), "<Value>", ws.DepthCalibration))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIRadiusOffset), "<Value>", ws.RadiusOffset))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIHalfProbeDia), "<Value>", ws.HalfProbeDiameter))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIScanIncrement), "<Value>", ws.ScanIncrement))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIRodDesign), "<Value>", kMRIRodDesignText))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIShopName), "<Value>", ws.Hostname))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIFixedOffset), "<Value>", ws.FixedOffset))
        istream.WriteLine(Replace(Replace(kMRICalibrationWrite, "<Key>", kMRIRadiusOffsetL), "<Value>", ws.RadiusOffsetL))
    End Sub
#End Region
End Module
