Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports FxResources.System.Data
Imports LibDatabase
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Microsoft.EntityFrameworkCore.Migrations.Operations
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
    Public Function ImportFiles(ByVal fileSpec As String) As Integer
        ' Returns a count of scan data files matching and imported from
        ' the file specification. FileSpec should be a full path to a file or a wildcard pattern.
        Dim result As Integer = 0
        If Not Directory.Exists(Path.GetDirectoryName(fileSpec)) Then
            Throw New DirectoryNotFoundException("Directory not found: " & Path.GetDirectoryName(fileSpec))
        End If
        If Path.GetFileName(fileSpec) = "" Then fileSpec = Path.Combine(Path.GetDirectoryName(fileSpec), "*.*")
        'On Error Resume Next
        Using dB As New HaleMRIContext
            For Each fileName As String In Directory.GetFiles(Path.GetDirectoryName(fileSpec), Path.GetFileName(fileSpec))
                Debug.Print("Importing: " & fileName)
                WorkstationStatusStrip1.Operation = fileName
                ImportScanData(dB, fileName)
                If dB.ChangeTracker.HasChanges AndAlso result > 0 AndAlso result Mod 100 = 0 Then
                    Try
                        'For Each entry As EntityEntry In dB.ChangeTracker.Entries
                        '    Select Case entry.Entity.GetType().Name
                        '        Case "Vessel"
                        '            Debug.Print(entry.Entity.GetType().Name & " " & entry.Entity.VesselName & " " & entry.State.ToString)
                        '        Case "Customer"
                        '            Debug.Print(entry.Entity.GetType().Name & " " & entry.Entity.CustomerName & " " & entry.State.ToString)
                        '        Case Else
                        '    End Select
                        'Next
                        'Debug.Print("------------------------------------------------")
                        dB.SaveChanges()
                        'dB.ChangeTracker.Clear()
                    Catch ex As Exception
                        DebugTracking(dB)
                        MsgBox(fileName & ": " & ex.Message & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Critical, STR_TITLE_DATABASE_ERROR)
                    End Try
                End If
                Application.DoEvents()
                result += 1
            Next
            If dB.ChangeTracker.HasChanges Then dB.SaveChanges()
        End Using
        Return result
    End Function
    Private Sub ImportScanData(ByRef dB As HaleMRIContext, ByVal fileName As String)
        ' Import scan data from the specified file
        Dim sd As ScanData = ScanDataImport(fileName)
        If sd IsNot Nothing AndAlso sd.Job IsNot Nothing Then ScanDataAddJob(dB, sd)
    End Sub
    Private Function ScanDataAddVessel(ByRef db As HaleMRIContext, ByVal sdCustomer As Customer) As Vessel
        ' Insert or lookup the customer and vessel data in the database.
        Dim v As Vessel = Nothing
        If sdCustomer Is Nothing OrElse sdCustomer.Vessels.Count = 0 OrElse String.IsNullOrEmpty(sdCustomer.Vessels(0).VesselName) Then
            v = New Vessel With {.VesselName = "(New Vessel)"}
        Else
            v = db.Vessels.FirstOrDefault(Function(u) u.VesselName = sdCustomer.Vessels(0).VesselName.ToString)
            If v Is Nothing Then v = New Vessel With {.VesselName = sdCustomer.Vessels(0).VesselName}
        End If
        If v.Customer Is Nothing Then
            If sdCustomer Is Nothing OrElse String.IsNullOrEmpty(sdCustomer.CustomerName) Then
                ' If no customer is provided, create a new customer with default values.
                v.Customer = New Customer With {.CustomerName = "(New Customer)"}
            Else
                v.Customer = db.Customers.FirstOrDefault(Function(u) u.CustomerName = sdCustomer.CustomerName.ToString)
                If v.Customer Is Nothing Then v.Customer = New Customer With {.CustomerName = sdCustomer.CustomerName}
            End If
        End If
        Return v
    End Function
    Private Sub JobDataValidate(ByRef db As HaleMRIContext, ByRef j As Job)
        ' Ensure that the scan data is properly formatted and valid in the
        ' associated lookup tables (table names beginning with a tilde (~)).
        With j
            ' If no employee is provided, create a new employee with default values.
            If .InspectedByNavigation IsNot Nothing AndAlso Not String.IsNullOrEmpty(.InspectedByNavigation.EmployeeName) Then
                If Not QryEmployeeNameExists(db, FormatString(.InspectedByNavigation.EmployeeName)) Then
                    db.Employees.Add(.InspectedByNavigation)
                Else
                    .InspectedByNavigation = db.Employees.FirstOrDefault(Function(u) u.EmployeeName = .InspectedByNavigation.EmployeeName.ToString)
                End If
            End If
            ' If no manufacturer is provided, create a new manufacturer with default values.
            If .Manufacturer IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Manufacturer.ManufacturerName) Then
                If Not QryManufacturerNameExists(db, FormatString(.Manufacturer.ManufacturerName)) Then
                    ' If the manufacturer does not exist in the database, add it.
                    db.Manufacturers.Add(.Manufacturer)
                Else
                    .Manufacturer = db.Manufacturers.FirstOrDefault(Function(m) m.ManufacturerName = .Manufacturer.ManufacturerName.ToString)
                End If
            End If
            ' Validate the job data before adding it to the database.
            If .Blades IsNot Nothing AndAlso Not db.Blades.Any(Function(b) b.BladeCount = .Blades.ToString) Then .Blades = Nothing
            If .Style IsNot Nothing AndAlso Not db.Styles.Any(Function(s) s.Style1 = .Style.ToString) Then .Style = Nothing
            If .Material IsNot Nothing AndAlso Not db.Materials.Any(Function(m) m.Material1 = .Material.ToString) Then .Material = Nothing
            If .JobDetails IsNot Nothing Then
                If .JobDetails(0).Cup IsNot Nothing AndAlso Not db.Cups.Any(Function(c) c.Cup1 = .JobDetails(0).Cup.ToString) Then
                    .JobDetails(0).Cup = Nothing ' If the cup does not exist, set it to Nothing.
                End If
                If .JobDetails(0).Rotation IsNot Nothing AndAlso Not db.Rotations.Any(Function(r) r.Rotation1 = .JobDetails(0).Rotation.ToString) Then
                    .JobDetails(0).Rotation = Nothing ' If the rotation does not exist, set it to Nothing.
                End If
                If .JobDetails(0).LeExclusion IsNot Nothing AndAlso Not db.Exclusions.Any(Function(e) e.Exclusion1 = .JobDetails(0).LeExclusion.ToString) Then
                    .JobDetails(0).LeExclusion = Nothing ' If the left exclusion does not exist, set it to Nothing.
                End If
                If .JobDetails(0).TeExclusion IsNot Nothing AndAlso Not db.Exclusions.Any(Function(e) e.Exclusion1 = .JobDetails(0).TeExclusion.ToString) Then
                    .JobDetails(0).TeExclusion = Nothing ' If the top exclusion does not exist, set it to Nothing.
                End If
                If .JobDetails(0).ToleranceClass IsNot Nothing AndAlso Not db.Tolerances.Any(Function(t) t.ToleranceClass = .JobDetails(0).ToleranceClass.ToString) Then
                    .JobDetails(0).ToleranceClass = Nothing ' If the tolerance class does not exist, set it to Nothing.
                End If
            End If

        End With
    End Sub
    Private Sub ScanDataAddJob(ByRef db As HaleMRIContext, ByRef sd As ScanData)
        With sd
            Dim jFromDb As Job = db.Jobs.FirstOrDefault(Function(u) u.JobNumber = .Job.JobNumber.ToString)
            If jFromDb IsNot Nothing Then
                .Job.JobDetails(0).Job = jFromDb
                db.JobDetails.AddRange(.Job.JobDetails)
                Exit Sub
            Else
                JobDataValidate(db, .Job)
                Dim v As Vessel = ScanDataAddVessel(db, .Customer)
                If db.ChangeTracker.HasChanges Then
                    For Each entry As EntityEntry(Of Job) In db.ChangeTracker.Entries(Of Job)()
                        If entry.State = EntityState.Added AndAlso entry.Entity.JobNumber = sd.Job.JobNumber Then
                            Try
                                db.SaveChanges()
                            Catch ex As Exception
                                MsgBox(ex.Message & vbCrLf & ex.InnerException.Message)
                            End Try
                        End If
                    Next
                    For Each entry As EntityEntry(Of Vessel) In db.ChangeTracker.Entries(Of Vessel)()
                        If entry.State = EntityState.Added AndAlso entry.Entity.VesselName = v.VesselName Then
                            Try
                                db.SaveChanges()
                            Catch ex As Exception
                                MsgBox(ex.Message & vbCrLf & ex.InnerException.Message)
                            End Try
                        End If
                    Next
                    For Each entry As EntityEntry(Of Customer) In db.ChangeTracker.Entries(Of Customer)()
                        If entry.State = EntityState.Added AndAlso entry.Entity.CustomerName = v.Customer.CustomerName Then
                            Try
                                db.SaveChanges()
                            Catch ex As Exception
                                MsgBox(ex.Message & vbCrLf & ex.InnerException.Message)
                            End Try
                        End If
                    Next

                End If
                .Job.Vessel = v
                'v.Jobs.Add(.Job) ' Associate the job with the vessel.
                db.Jobs.Add(.Job)
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
        'Try
        ImportFiles(txtScanDataFile.Text)
        'Catch ex As Exception
        'MsgBox("Error importing scan data: " & ex.Message, MsgBoxStyle.Critical, "Import Error")
        'End Try
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
    Private Sub DebugTracking(ByVal dB As HaleMRIContext)
        For Each entry As EntityEntry In dB.ChangeTracker.Entries
            Select Case entry.Entity.GetType().Name
                Case "Customer"
                    Dim str As String = If(entry.Entity.Id IsNot Nothing, entry.Entity.Id.ToString(), "(New)")
                    Debug.Print(entry.Entity.GetType().Name & ": " & entry.Entity.CustomerName & " " & str & " " & " = " & entry.State.ToString())
                Case "Vessel"
                    Dim str As String = If(entry.Entity.Id IsNot Nothing, entry.Entity.Id.ToString(), "(New)")
                    Debug.Print(entry.Entity.GetType().Name & ": " & entry.Entity.VesselName & " " & str & " " & " = " & entry.State.ToString())
                Case Else
            End Select
        Next
        Debug.Print("------------------------------------------------")
    End Sub
End Class