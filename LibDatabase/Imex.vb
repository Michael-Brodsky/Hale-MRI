Imports LibDatabase.Models
Imports LibDatabase.Contexts
Imports System.IO
Imports System.Text.RegularExpressions

''' <summary>
''' Exposes methods to import and export calibration and scan data text files.
''' See docs/ScanData Format.docx
''' </summary>
Public Module Imex
#Region "Types and Constants"
    ''' <summary>
    ''' Enumerates significant line numbers in calibration data text files.
    ''' </summary>
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

    ''' <summary>
    ''' Enumerates significant line numbers in scan data text files.
    ''' </summary>
    Private Enum ScanDataLineId
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

    ''' <summary>
    ''' Type that aggregates exclusion values.
    ''' </summary>
    Private Structure Exclusions
        Public LeExclusion As Double
        Public TeExclusion As Double
    End Structure

    ''' <summary>
    ''' Type that aggregates cell measurement values.
    ''' </summary>
    Private Class CellMeasurement
        Public Property BladeID As Integer
        Public Property Angle As Double
        Public Property Depth As Double
    End Class

    ''' <summary>
    ''' Collects cell measurements from a text file over multiple lines using a state machine.
    ''' </summary>
    Private Class Cell
        Private Enum MeasurementState
            Angle
            Depth
            Done
        End Enum
        Private mMeasurements As New List(Of CellMeasurement)()
        Private mBlade As Integer = 0
        Private mBladeCells As List(Of Integer)
        Public WriteOnly Property BladeCells As List(Of Integer)
            Set(value As List(Of Integer))
                mBladeCells = value
                Dim x = mBladeCells.Sum()
                x = x
            End Set
        End Property
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

            If mMeasurements.Count = m Then
                mMeasurements.Add(New CellMeasurement())
                mMeasurements(m).BladeID = mBlade + 1
            End If
            Select Case state
                Case MeasurementState.Angle
                    mMeasurements(m).Angle = Convert.ToDouble(value)
                Case MeasurementState.Depth
                    mMeasurements(m).Depth = Convert.ToDouble(value)
                Case Else
            End Select
            state += 1
            If state = MeasurementState.Done Then
                mBladeCells(mBlade) -= 1
                If mBladeCells(mBlade) = 0 Then
                    mBlade += 1
                End If
                state = MeasurementState.Angle
                m += 1
            End If
        End Sub
    End Class

    ''' <summary>
    ''' Collects extreme measurements from a text file over multiple lines using a state machine.
    ''' </summary>
    Private Class Extremes
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

    ''' <summary>
    ''' Type that aggregates radius measurement values.
    ''' </summary>
    Private Class RadiusMeasurementT
        Public Property Radius As Double
        Public Property LeCell As Integer
        Public Property TeCell As Integer
    End Class

    ''' <summary>
    ''' Collects radius measurements from a text file over multiple lines using a state machine.
    ''' </summary>
    Private Class Radius
        Private Enum MeasurementState
            Radius
            LeCell
            TeCell
            Done
        End Enum
        Private Const kLinesPerMeasurement As Integer = 3
        Private mMeasurements As New List(Of RadiusMeasurementT)()
        Private mBlades As New List(Of Integer)()
        Private mBladeCells As New List(Of Integer)()
        Public WriteOnly Property BladeCount As Integer
            Set(ByVal value As Integer)
                For i As Integer = 1 To value
                    mMeasurements.Add(New RadiusMeasurementT())
                Next
                mBlades.Add(value)
                mBladeCells.Add(0)
            End Set
        End Property
        Public ReadOnly Property BladeCells As List(Of Integer)
            Get
                Return mBladeCells
            End Get
        End Property
        Public ReadOnly Property Blades As List(Of Integer)
            Get
                Return mBlades
            End Get
        End Property
        Public ReadOnly Property Measurements As List(Of RadiusMeasurementT)
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
            If mMeasurements.Count = m Then mMeasurements.Add(New RadiusMeasurementT())
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
                mBladeCells(blade) += (mMeasurements(n + m).TeCell - mMeasurements(n + m).LeCell) + 1
                state = MeasurementState.Radius
                m += 1
                If m = mBlades(blade) Then
                    'mBladeCells(blade) += 1
                    m = 0
                    n += mBlades(blade)
                    blade += 1
                End If
            End If
        End Sub
    End Class

    ' Hale-MRI scan data/calibration file string constants.
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
        ' Exports the Workstation's calibration data to a text file.
        If File.Exists(outFile) Then Throw New IOException("Calibration data file already exists: " & outFile)
        Dim ostream As New StreamWriter(outFile, True)
        WriteCalibrationsData(ws, ostream)
        ostream.Close()
    End Sub

    Public Function CalibrationDataImport(ByVal name As String, ByVal inFile As String) As Workstation
        ' Imports calibration data from a text file into a Workstation object.
        If Not File.Exists(inFile) Then Throw New FileNotFoundException("Calibration data file not found.", inFile)
        Dim istream As New StreamReader(inFile)
        Dim ws As New Workstation With {.Hostname = name}
        ReadCalibrationData(ws, istream)
        istream.Close()
        Return ws
    End Function

    Public Function ScanDataAdd(db As HaleMRIContext, ByVal importedJob As Job) As Job
        ' Returns the Job added to the database. Job data is verified. If a Job with
        ' the same JobNumber exists in the database, then append only the JobDetails,
        ' else add a new Job.
        Dim result As Job = Nothing
        If importedJob IsNot Nothing Then
            ' Check any JobDetails data first.
            importedJob.JobDetails(0).PerformedByNavigation = GetEmployee(db, importedJob.JobDetails(0)?.PerformedByNavigation)
            importedJob.JobDetails(0).MeasurementType = GetMeasurementType(db, New MeasurementType With {.MeasurementType1 = importedJob.JobDetails(0)?.Description})
            ' Check if the Job exists.
            Dim existingJob As Job = db.Jobs.FirstOrDefault(Function(j) j.JobNumber = importedJob.JobNumber.ToString())
            If existingJob Is Nothing Then
                ' If it does not, verify the imported Job data.
                If Not VesselExists(db, importedJob?.Vessel) Then GetCustomer(db, importedJob?.Vessel.Customer)
                importedJob.PropellerManufacturer = GetManufacturer(db, importedJob?.PropellerManufacturer)
                importedJob.LeExclusionNavigation = GetExclusion(db, importedJob?.LeExclusionNavigation)
                importedJob.TeExclusionNavigation = GetExclusion(db, importedJob?.TeExclusionNavigation)
                importedJob.CupNavigation = GetCup(db, importedJob?.CupNavigation)
                importedJob.PropellerStyleNavigation = GetPropellerStyle(db, importedJob?.PropellerStyleNavigation)
                importedJob.PropellerMaterialNavigation = GetPropellerMaterial(db, importedJob?.PropellerMaterialNavigation)
                importedJob.PropellerBladesNavigation = GetPropellerBlades(db, importedJob?.PropellerBladesNavigation)
                importedJob.PropellerRotationNavigation = GetPropellerRotation(db, importedJob?.PropellerRotationNavigation)
                ' Add the new Job.
                db.Jobs.Add(importedJob)
                result = importedJob
            ElseIf importedJob.JobDetails?.Count > 0 Then
                ' If it does and the imported Job has JobDetails, add them to the existing Job.
                existingJob.JobDetails.Add(importedJob.JobDetails(0))
                result = existingJob
            End If
            If db.ChangeTracker.HasChanges() Then db.SaveChanges()
        End If
        Return result
    End Function

    Public Sub ScanDataExport(ByVal j As Job, ByVal outFile As String)
        ' Writes Job data to a scan data text file.
        If File.Exists(outFile) Then Throw New IOException("Scan data file already exists: " & outFile)
        Dim ostream As New StreamWriter(outFile, True)
        WriteScanData(ostream, j)
    End Sub

    Public Function ScanDataImport(ByVal inFile As String) As Job
        ' Imports scan data from a text file and returns a Job object.
        If Not File.Exists(inFile) Then Throw New FileNotFoundException("Scan data file not found.", inFile)
        Dim istream As New StreamReader(inFile)
        Dim j As Job = ReadScanData(istream, File.ReadAllLines(inFile).Length)
        istream.Close()
        Return j
    End Function
#End Region
#Region "Private Interface"
    Private Function GetCup(db As HaleMRIContext, ByVal newCup As Cup) As Cup
        ' Returns an existing Exclusion if an Exclusion with the same Exclusion1
        ' is found in the database, else returns newExclusion.
        Return If(newCup IsNot Nothing,
            db.Cups.Local.FirstOrDefault(Function(c) c.Cup1 = newCup?.Cup1.ToString()),
            Nothing)
    End Function

    Private Sub GetCustomer(db As HaleMRIContext, ByRef newCustomer As Customer)
        ' Returns TRUE and sets newCustomer to an existing Customer if a Customer with the same CustomerName
        ' is found in the database, else returns FALSE. Customers with missing CustomerNames are assigned a
        ' unique string. newCustomer must be a valid Customer object.
        Dim customerName As String = newCustomer.CustomerName
        If String.IsNullOrWhiteSpace(newCustomer.CustomerName) Then newCustomer.CustomerName = $"(New Customer {db.Customers.Count + 1})"
        newCustomer = If(db.Customers.Local.FirstOrDefault(Function(c) c.CustomerName = customerName.ToString()), newCustomer)
    End Sub

    Private Function GetEmployee(db As HaleMRIContext, ByVal newEmployee As Employee) As Employee
        ' Returns an existing Employee if an Employee with the same EmployeeName
        ' is found in the database, else returns newEmployee.
        Return If(Not String.IsNullOrWhiteSpace(newEmployee?.EmployeeName),
            If(db.Employees.Local.FirstOrDefault(Function(e) e.EmployeeName = newEmployee?.EmployeeName.ToString()), newEmployee),
            Nothing)
    End Function

    Private Function GetExclusion(db As HaleMRIContext, ByVal newExclusion As Exclusion) As Exclusion
        ' Returns the first Exclusion with a matching Exclusion1
        ' found in the database, else returns Nothing.
        Return If(newExclusion IsNot Nothing,
            db.Exclusions.Local.FirstOrDefault(Function(e) e.Exclusion1 = newExclusion?.Exclusion1.ToString()),
            Nothing)
    End Function

    Private Function GetManufacturer(db As HaleMRIContext, ByVal newManufacturer As Manufacturer) As Manufacturer
        ' Returns an existing Manufacturer if a Manufacturer with the same ManufacturerName
        ' is found in the database, else returns newManufacturer.
        Return If(Not String.IsNullOrWhiteSpace(newManufacturer?.ManufacturerName),
            If(db.Manufacturers.Local.FirstOrDefault(Function(m) m.ManufacturerName = newManufacturer?.ManufacturerName.ToString()), newManufacturer),
            Nothing)
    End Function

    Private Function GetMeasurementType(db As HaleMRIContext, ByVal newMeasurementType As MeasurementType) As MeasurementType
        ' Returns the first MeasurementType with a matching MeasurementType1
        ' found in the database, else returns Nothing.
        Return If(newMeasurementType IsNot Nothing,
            db.MeasurementTypes.Local.FirstOrDefault(Function(m) m.MeasurementType1 = newMeasurementType?.MeasurementType1.ToString()),
            Nothing)
    End Function

    Private Function GetPropellerBlades(db As HaleMRIContext, ByVal newBlade As Blade) As Blade
        ' Returns the first MeasurementType with a matching MeasurementType1
        ' found in the database, else returns Nothing.
        Return If(newBlade IsNot Nothing,
            db.Blades.Local.FirstOrDefault(Function(b) b.BladeCount = newBlade?.BladeCount.ToString()),
            Nothing)
    End Function

    Private Function GetPropellerMaterial(db As HaleMRIContext, ByVal newMaterial As Material) As Material
        ' Returns the first MeasurementType with a matching MeasurementType1
        ' found in the database, else returns Nothing.
        Return If(newMaterial IsNot Nothing,
            db.Materials.Local.FirstOrDefault(Function(m) m.Material1 = newMaterial?.Material1.ToString()),
            Nothing)
    End Function

    Private Function GetPropellerRotation(db As HaleMRIContext, ByVal newRotation As Rotation) As Rotation
        ' Returns the first MeasurementType with a matching MeasurementType1
        ' found in the database, else returns Nothing.
        Return If(newRotation IsNot Nothing,
            db.Rotations.Local.FirstOrDefault(Function(r) r.Rotation1 = newRotation?.Rotation1.ToString()),
            Nothing)
    End Function

    Private Function GetPropellerStyle(db As HaleMRIContext, ByVal newStyle As Style) As Style
        ' Returns the first MeasurementType with a matching MeasurementType1
        ' found in the database, else returns Nothing.
        Return If(newStyle IsNot Nothing,
            db.Styles.Local.FirstOrDefault(Function(s) s.Style1 = newStyle?.Style1.ToString()),
            Nothing)
    End Function

    Private Function VesselExists(db As HaleMRIContext, ByRef newVessel As Vessel) As Boolean
        ' Returns TRUE and sets newVessel to an existing Vessel if a Vessel with the same VesselName
        ' is found in the database, else returns FALSE. Vessels with missing VesselNames are assigned 
        ' a unique string. newVessel must be a valid Vessel object.
        Dim vesselName As String = newVessel.VesselName
        If String.IsNullOrWhiteSpace(newVessel.VesselName) Then newVessel.VesselName = $"(New Vessel {db.Vessels.Count + 1})"
        Dim existingVessel As Vessel = db.Vessels.Local.FirstOrDefault(Function(v) v.VesselName = vesselName.ToString())
        newVessel = If(existingVessel, newVessel)
        Return newVessel Is existingVessel
    End Function

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

    Private Function ReadScanData(ByVal istream As StreamReader, ByVal lineCount As Integer) As Job
        ' Reads and parses a scan data text file for relevant data and returns a Job object
        ' populated from the parsed text.
        Dim line As String
        Dim lineId As ScanDataLineId = ScanDataLineId.idFileType
        Dim skipped As Integer = 0
        Dim regex As New Regex("[^A-Za-z0-9\,\.\/\-\~\: ]+")    ' Matches anything that is not a letter, digit, comma, period, slash, hyphen, tilde, colon, or space.
        Dim radii As New Radius()
        Dim cells As New Cell()
        Dim extremes As New Extremes()
        Dim c As Customer = Nothing
        Dim v As Vessel = Nothing
        Dim j As Job = Nothing
        Dim tempD As Double
        On Error Resume Next
        Do While Not istream.EndOfStream
            line = TrimReplace(regex, istream.ReadLine())
            If String.IsNullOrWhiteSpace(line) Then
                ' If the line is empty, skip it.
                'skipped += 1
                GoTo Skip_Line
            End If
            Select Case lineId
                Case ScanDataLineId.idFileType
                    ' Skip this line, which is always the first line.
                    skipped = 1
                Case ScanDataLineId.idCustomer
                    ' ScanDataAdd() will generate a unique customer name if none found.
                    c = New Customer With {.CustomerName = line}
                Case ScanDataLineId.idVessel
                    ' ScanDataAdd() will generate a unique vessel name if none found.
                    v = New Vessel With {
                        .VesselName = line,
                        .Customer = If(c, New Customer With {.CustomerName = String.Empty})
                    }
                Case ScanDataLineId.idJobNumber
                    ' Valid job number is required.
                    Dim jobNumber As Integer = 0
                    If Not Int32.TryParse(line, jobNumber) OrElse jobNumber < 1 Then Exit Do
                    j = New Job With {
                        .JobNumber = jobNumber,
                        .Vessel = If(v, New Vessel With {
                            .VesselName = String.Empty,
                            .Customer = If(c, New Customer With {.CustomerName = String.Empty})
                        })
                    }
                    If j IsNot Nothing Then
                        j.JobDetails = New List(Of JobDetail) From {
                        New JobDetail()
                    }
                    Else
                        Exit Do
                    End If
                Case ScanDataLineId.idDiameter
                    j.PropellerDiameter = Convert.ToDouble(line)
                Case ScanDataLineId.idMarkedPitch
                    j.MarkedPitch = Convert.ToDouble(line)
                Case ScanDataLineId.idRotation
                    j.PropellerRotation = line
                Case ScanDataLineId.idClass
                    j.JobDetails(0).ToleranceClass = line
                Case ScanDataLineId.idStage
                    j.JobDetails(0).Description = line
                Case ScanDataLineId.idFileName
                    j.JobDetails(0).FileName = line
                Case ScanDataLineId.idDateTime
                    j.JobDetails(0).StartDate = DateTime.Parse(line)
                Case ScanDataLineId.idExclusions
                    If InStr(line, kMRIDummyText) > 0 Then
                        Dim exclusions As String() = line.Split("~"c)
                        Dim ex As New Exclusions With {
                                .LeExclusion = Convert.ToDouble(exclusions(0))
                            }
                        If exclusions.Length = 2 Then ex.TeExclusion = Convert.ToDouble(exclusions(1))
                        j.LeExclusion = ex.LeExclusion
                        j.TeExclusion = ex.TeExclusion
                    End If
                Case ScanDataLineId.idPartNumber
                    j.PropellerPartNumber = line
                Case ScanDataLineId.idSerialNumber
                    j.SerialNumber = line
                Case ScanDataLineId.idStampNumber
                    j.StampNumber = line
                Case ScanDataLineId.idInspectedBy
                    j.JobDetails(0).PerformedByNavigation = New Employee With {.EmployeeName = line}
                Case ScanDataLineId.idDesiredPitch
                    j.DesiredPitch = Convert.ToDouble(line)
                Case ScanDataLineId.idDAR
                    j.Dar = Convert.ToDouble(line)
                Case ScanDataLineId.idBore
                    j.PropellerBore = line
                Case ScanDataLineId.idCup
                    j.Cup = Convert.ToDouble(line)
                Case ScanDataLineId.idManufacturer
                    j.PropellerManufacturer = New Manufacturer With {.ManufacturerName = line}
                Case ScanDataLineId.idStyle
                    j.PropellerStyle = line
                Case ScanDataLineId.idMaterial
                    j.PropellerMaterial = line
                Case ScanDataLineId.idRadiusFirst To ScanDataLineId.idRadiusLast
                    ' Read blade measurement counts
                    radii.BladeCount = Convert.ToInt32(line)
                Case ScanDataLineId.idBladeCount
                    ' Valid blade count is required.
                    j.PropellerBlades = Convert.ToInt32(line)
                    If j.PropellerBlades < 2 OrElse j.PropellerBlades > 10 Then Exit Do
                Case ScanDataLineId.idBladeCount + 1 To ScanDataLineId.idBladeCount + radii.LineCount
                    ' Read radius measurements
                    radii.Value = line
                Case ScanDataLineId.idBladeCount + radii.LineCount + 1 To lineCount - j.PropellerBlades - skipped + 1
                    ' Read cell measurements
                    If lineId = ScanDataLineId.idBladeCount + radii.LineCount + 1 Then cells.BladeCells = radii.BladeCells
                    cells.Value = line
                Case Is > lineCount - j.PropellerBlades - skipped + 1
                    If line = kMRIEndOfFile Then
                        ' End of file marker, save measurements
                        SaveMeasurements(j, radii, extremes, cells)
                    Else
                        extremes.Value = line
                    End If
                Case Is > lineCount
                    ' Valid line count is required.
                    Exit Do
                Case Else
                    skipped += 1
            End Select
Skip_Line:
            If lineId >= ScanDataLineId.idJobNumber AndAlso j Is Nothing Then Exit Do
            lineId += 1
        Loop
        Return j
    End Function

    Private Sub WriteScanData(ByVal ostream As StreamWriter, ByVal j As Job)
        ' Writes the scan data to a text file in the expected order.
    End Sub

    Private Sub SaveMeasurements(ByRef j As Job, ByVal radii As Radius, ByVal extremes As Extremes, ByVal cells As Cell)
        ' Saves the collected cell, extreme and radius measurements.
        If radii IsNot Nothing Then
            Dim cmFirst As Integer = 0
            Dim cmLast As Integer = 0
            Dim b As Integer = 1
            Dim m As Integer = 0
            For Each rm As RadiusMeasurementT In radii.Measurements
                Dim i As Integer = 0
                Dim newRadiusMeasurement As New Models.RadiusMeasurement With {
                    .BladeId = b,
                    .Radius = rm.Radius,
                    .LeCell = rm.LeCell,
                    .TeCell = rm.TeCell
                }
                j.JobDetails(0).RadiusMeasurements.Add(newRadiusMeasurement)
                cmLast = cmFirst + newRadiusMeasurement.TeCell - newRadiusMeasurement.LeCell
                For i = cmFirst To cmLast
                    newRadiusMeasurement.CellMeasurements.Add(New Models.CellMeasurement With {
                          .Angle = cells.Measurements(i).Angle,
                          .Depth = cells.Measurements(i).Depth
                    })
                Next
                cmFirst = i
                m += 1
                If m = radii.Blades(b - 1) Then
                    newRadiusMeasurement.ExtremeMeasurements.Add(New Models.ExtremeMeasurement With {
                        .Extreme = extremes.Measurements(b - 1)
                    })
                    m = 0
                    b += 1
                End If
            Next
        End If
    End Sub

    Private Sub SaveCellMeasurements(ByRef j As Job, ByVal cells As Cell)
        ' Saves cell measurements into Job.JobDetails.RadiusMeasurement.CellMeasurement
        'For Each cm As CellMeasurement In cells.Measurements
        '    j.JobDetails(0).CellMeasurements.Add(New Models.CellMeasurement With {
        '        .BladeId = cm.BladeID,
        '        .Angle = cm.Angle,
        '        .Depth = cm.Depth
        '    })
        'Next
    End Sub

    Private Sub SaveExtremeMeasurements(ByRef j As Job, ByVal extremes As Extremes)
        ' Saves extreme measurements into Job.JobDetails.ExtremeMeasurement
        'Dim b As Integer = 1
        'For Each em As Double In extremes.Measurements
        '    j.JobDetails(0).ExtremeMeasurements.Add(New Models.ExtremeMeasurement With {
        '    .BladeId = b,
        '    .Extreme = em
        '    })
        '    b += 1
        'Next
    End Sub

    Private Sub SaveRadiusMeasurements(ByRef j As Job, ByVal radii As Radius)
        ' Saves radius measurements into Job.JobDetails.RadiusMeasurement
        'Dim b As Integer = 1
        'Dim m As Integer = 0
        'For Each rm As RadiusMeasurement In radii.Measurements
        '    j.JobDetails(0).RadiusMeasurements.Add(New Models.RadiusMeasurement With {
        '        .BladeId = b,
        '        .Radius = rm.Radius,
        '        .LeCell = rm.LeCell,
        '        .TeCell = rm.TeCell
        '    })
        '    m += 1
        '    If m = radii.Blades(b - 1) Then
        '        m = 0
        '        b += 1
        '    End If
        'Next
    End Sub

    Private Function TrimReplace(pattern As Regex, ByVal s As String) As String
        ' Returns a string with unwanted characters removed using a regex pattern.
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
