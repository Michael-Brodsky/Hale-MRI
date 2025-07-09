Imports LibDatabase.Models
Imports System.IO
Imports System.Text.RegularExpressions
Public Module Imex
#Region "Constants"
    ' Enumerates significant line numbers in calibration data text files.
    Private Enum CalibrationLineId
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
    ' Enumerates significant line numbers in scan data text files.
    Private Enum ScanDataLineId
        idFileType = 0
        idCustomer = 1
        idVessel = 2
        idJobNumber = 3
        idDiameter = 4
        idMarkedPitch = 5
        idRotation = 6
        idClass = 7
        idStage = 8
        idID = 9
        idFileName = 10
        idDateTime = 11
        idExclusions = 12
        idPartNumber = 13
        idSerialNumber = 14
        idStampNumber = 15
        idInspectedBy = 16
        idDesiredPitch = 17
        idDAR = 18
        idBore = 19
        idCup = 20
        idManufacturer = 21
        idStyle = 22
        idMaterial = 23
        idRadiusFirst = 24
        idRadiusLast = 33
        idBladeCount = 34
    End Enum
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
        ' Exports the calibration data from the workstation to a text file.
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
#End Region
#Region "Private Interface"
    Private Sub ReadCalibrationData(ByRef ws As Workstation, ByVal istream As StreamReader)
        Dim line As String
        Dim lineId As CalibrationLineId = CalibrationLineId.cdAngleResolution
        Dim pattern As New Regex("[^0-9\.\- ]+")
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
    Private Function TrimReplace(pattern As Regex, ByVal s As String) As String
        If s Is Nothing Then Return String.Empty
        Return pattern.Replace(s, String.Empty).Trim()
    End Function
    Private Sub WriteCalibrationsData(ByVal ws As Workstation, ByRef istream As StreamWriter)
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
