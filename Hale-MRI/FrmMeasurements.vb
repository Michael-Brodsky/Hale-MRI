Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LibDatabase
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Public Class FrmMeasurements
    Private mHardware As WorkstationEncoders
    Public Sub New()
        ' Default constructor that initializes the form without any specific EncoderHardware instance or Workstation calibration data
        InitializeComponent()
    End Sub
    Public Sub New(ByRef wse As WorkstationEncoders)
        ' Constructor that initializes the form with a specific EncoderHardware instance and Workstation calibration data
        InitializeComponent()
        Hardware = wse
    End Sub
    Public Property Hardware As WorkstationEncoders
        ' Property to get or set the EncoderHardware instance and Workstation calibration data
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
            WorkstationStatusStrip1.Encoders = mHardware.Encoders
            WorkstationStatusStrip1.WorkstationName = value.Workstation.Hostname
            WorkstationStatusStrip1.Operation = ""
            If mHardware.Encoders IsNot Nothing Then EncodersInitialize()
        End Set
    End Property
    Private Sub EncodersControlsEnabled(ByVal enabled As Boolean)
        ' Enable or disable controls related to the encoders
    End Sub
    Private Sub EncodersErrorShow(prompt As String, msg As String)
        ' Display an error message and update the UI accordingly
        MsgBox(prompt & ": " & msg, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        EncodersControlsEnabled(False)
        WorkstationStatusStrip1.Status = WorkstationStatusStrip.EncoderStatus.EncoderError
    End Sub
    Private Sub EncodersInitialize()
        ' Initialize the encoder hardware and update the UI accordingly
        Try
            mHardware.Encoders.Initialize()
            If mHardware.Encoders.Initialized Then
                WorkstationStatusStrip1.Status = WorkstationStatusStrip.EncoderStatus.Ready
                EncodersControlsEnabled(True)
            End If
        Catch ex As Exception
            EncodersErrorShow(WorkstationStatusStrip.STR_ENCODER_ERROR, ex.Message)
        End Try
    End Sub
    Private Sub ExportScanData(ByVal fileName As String)
        ' Export scan data to the specified file
        Dim sd = New ScanData(Nothing, Nothing)
        ScanDataExport(sd, fileName)
    End Sub
    Private Sub ImexControlsEnable(ByVal enabled As Boolean)
        ' Enable or disable controls related to import/export functionality
        cmdImportScanData.Enabled = enabled
        cmdExportScanData.Enabled = enabled
    End Sub
    Public Function ImportFiles(ByVal fileSpec As String) As String()
        ' Returns a list of scan data files matching and imported from
        ' the file specification. FileSpec should be a full path to a file or a wildcard pattern.
        Dim result = Array.Empty(Of String)()
        If Not Directory.Exists(Path.GetDirectoryName(fileSpec)) Then
            Throw New DirectoryNotFoundException("Directory not found: " & Path.GetDirectoryName(fileSpec))
        End If
        If Path.GetFileName(fileSpec) = "" Then fileSpec = Path.Combine(Path.GetDirectoryName(fileSpec), "*.*")
        On Error Resume Next
        For Each fileName As String In Directory.GetFiles(Path.GetDirectoryName(fileSpec), Path.GetFileName(fileSpec))
            WorkstationStatusStrip1.Operation = fileName
            ImportScanData(fileName)
            Application.DoEvents()
            result.AsEnumerable().ToList().Add(fileName)
        Next
        Return Directory.GetFiles(Path.GetDirectoryName(fileSpec), Path.GetFileName(fileSpec))
    End Function
    Private Sub ImportScanData(ByVal fileName As String)
        ' Import scan data from the specified file
        Dim sd As ScanData = ScanDataImport(fileName)
        If sd IsNot Nothing Then
            Using db As New HaleMRIContext
                With sd
                    ' Ensure both customer and vessel are provided, as they are required for the job.
                    If .Customer IsNot Nothing AndAlso .Customer.Vessels IsNot Nothing Then
                        CustomerDataValidate(db, .Customer) ' Validate the customer data before adding it to the database.)
                        If Not QryCustomerNameExists(db, FormatString(.Customer.CustomerName)) Then
                            ' If the customer does not exist, add it and the vessel to the database.
                            db.Customers.Add(.Customer)
                        Else
                            ' Associate the existing customer with the vessel.
                            .Customer.Vessels(0).Customer = db.Customers.FirstOrDefault(Function(c) c.CustomerName = FormatString(.Customer.CustomerName).ToString)
                            If Not QryVesselNameExists(db, FormatString(.Customer.Vessels(0).VesselName)) Then
                                ' If the vessel does not exist, add it to the database
                                db.Vessels.Add(.Customer.Vessels(0))
                            End If
                        End If
                    Else
                        Exit Sub ' Exit if no customer or vessel are provided.
                    End If
                    If .Job IsNot Nothing Then
                        .Job.Vessel = .Customer.Vessels(0)  ' Associate the vessel with the job.
                        JobDataValidate(db, .Job)           ' Validate the job data before adding it to the database.
                        If Not QryJobNumberExists(db, .Job.JobNumber) Then
                            ' If the job does not exist, add it and the job details to the database
                            db.Jobs.Add(.Job)
                        ElseIf .Job.JobDetails IsNot Nothing AndAlso .Job.JobDetails.Count > 0 Then
                            ' If the job exists, associate the existing job with the job details and add them to that job.
                            .Job.JobDetails(0).Job = db.Jobs.FirstOrDefault(Function(j) j.JobNumber = .Job.JobNumber.ToString)
                            db.JobDetails.AddRange(.Job.JobDetails)
                        End If
                    End If
                End With
                db.SaveChanges()
            End Using
        End If
    End Sub
    Private Sub CustomerDataValidate(ByRef db As HaleMRIContext, ByRef c As Customer)
        ' Ensure that the customer data is properly formatted and valid in the
        ' associated lookup tables (table names beginning with a tilde (~)).
        With c
            If c.Vessels Is Nothing OrElse c.Vessels.Count = 0 Then
                ' If no vessels are provided, create a new vessel with default values.
                c.Vessels = New List(Of Vessel) From {New Vessel With {.VesselName = "(New Vessel)"}}
            End If
        End With
    End Sub
    Private Sub JobDataValidate(ByRef db As HaleMRIContext, ByRef j As Job)
        ' Ensure that the scan data is properly formatted and valid in the
        ' associated lookup tables (table names beginning with a tilde (~)).
        With j
            If .InspectedBy IsNot Nothing AndAlso QryEmployeeNameExists(db, FormatString(.InspectedBy)) Then .InspectedBy = db.Employees.FirstOrDefault(Function(u) u.EmployeeName = .InspectedBy.ToString)?.EmployeeName
            If .Blades IsNot Nothing Then .Blades = db.Blades.FirstOrDefault(Function(b) b.BladeCount = .Blades.ToString)?.BladeCount
            If .Style IsNot Nothing Then .Style = db.Styles.FirstOrDefault(Function(s) s.Style1 = .Style.ToString)?.Style1
            If .Material IsNot Nothing Then .Material = db.Materials.FirstOrDefault(Function(m) m.Material1 = .Material.ToString)?.Material1
            If .JobDetails IsNot Nothing Then
                If .JobDetails(0).Cup IsNot Nothing Then .JobDetails(0).Cup = db.Cups.FirstOrDefault(Function(c) c.Cup1 = .JobDetails(0).Cup.ToString)?.Cup1
                If .JobDetails(0).Rotation IsNot Nothing Then .JobDetails(0).Rotation = db.Rotations.FirstOrDefault(Function(r) r.Rotation1 = .JobDetails(0).Rotation.ToString)?.Rotation1
                If .JobDetails(0).LeExclusion IsNot Nothing Then .JobDetails(0).LeExclusion = db.Exclusions.FirstOrDefault(Function(e) e.Exclusion1 = .JobDetails(0).LeExclusion.ToString)?.Exclusion1
                If .JobDetails(0).TeExclusion IsNot Nothing Then .JobDetails(0).TeExclusion = db.Exclusions.FirstOrDefault(Function(e) e.Exclusion1 = .JobDetails(0).LeExclusion.ToString)?.Exclusion1
                If .JobDetails(0).ToleranceClass IsNot Nothing Then .JobDetails(0).ToleranceClass = db.Tolerances.FirstOrDefault()?.ToleranceClass
            End If
        End With
    End Sub
    Private Sub ScanDataFilePick()
        ' Open a file dialog to select a calibration file
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Calibration File",
            .Filter = "Calibration Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        }
        If ofd.ShowDialog() = DialogResult.OK Then txtScanDataFile.Text = ofd.FileName
    End Sub
    Private Sub CmdImportScanData_Click(sender As Object, e As EventArgs) Handles cmdImportScanData.Click
        Try
            ImportFiles(txtScanDataFile.Text)
        Catch ex As Exception
            MsgBox("Error importing scan data: " & ex.Message, MsgBoxStyle.Critical, "Import Error")
        End Try
    End Sub

    Private Sub TxtScanDataFile_TextChanged(sender As Object, e As EventArgs) Handles txtScanDataFile.TextChanged
        Try
            ImexControlsEnable(txtScanDataFile.Text.Length > 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_DEFAULT)
        End Try
    End Sub

    Private Sub cmdCalibrationFile_Click(sender As Object, e As EventArgs) Handles cmdCalibrationFile.Click
        Try
            ScanDataFilePick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
End Class