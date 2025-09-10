Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.Imex
Imports LibEncoder
Imports Hale_MRI.WorkstationStatusStrip

''' <summary>
''' This form provides a user inteface for importing and editing
''' Workstation calibration data.
''' </summary>
''' 

Public Class FrmCalibration
#Region "Private Members"
    Private Const STR_ERR_CALIBRATION_READ As String = "Error retrieving calibration data from the database: "
    Private Const STR_ERR_CALIBRATION_WRITE As String = "Error saving calibration data to the database: "
    Private Const STR_ERR_EXPORT As String = "Error exporting calibration data: "
    Private Const STR_ERR_IMPORT As String = "Error importing calibration data: "
#End Region
#Region "Public Interface"
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
        ' This property sets the Hardware property of the WorkstationStatusStrip1 control so
        ' that its UI updates accordingly.
        Get
            Return WorkstationStatusStrip1.Hardware
        End Get
        Set(value As WorkstationEncoders)
            WorkstationStatusStrip1.Hardware = value
            If WorkstationStatusStrip1.Hardware IsNot Nothing Then
                If WorkstationStatusStrip1.Hardware.Workstation IsNot Nothing Then WorkstationCalibrationShow()
                SaveCancelControlsEnabled(False)   ' The text changed events will enable these, so disable them initially
                If WorkstationStatusStrip1.Hardware.Encoders IsNot Nothing Then
                    Try
                        If Not WorkstationStatusStrip1.Hardware.Encoders.Initialized Then WorkstationStatusStrip1.Initialize()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
                    End Try
                End If
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub SaveCancelControlsEnabled(ByVal value As Boolean)
        ' Enable or disable the Save and Cancel buttons based on the value parameter
        cmdSaveCalibration.Enabled = value
        cmdCancelCalibration.Enabled = value
    End Sub
    Private Sub CalibrationCancel()
        ' Cancel the calibration data changes and reset the UI components
        WorkstationCalibrationShow()
        EncodersCalibrationSet()
        SaveCancelControlsEnabled(False)
    End Sub
    Private Sub CalibrationDefault()
        ' Reset the calibration values to default
        Dim db As New HaleMRIContext()
        WorkstationCalibrationShow(db.Workstations.FirstOrDefault(Function(w) w.Hostname = STR_ERR_CALIBRATION_DEFAULT))
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub CalibrationExport(ByRef outFile As String)
        ' Export the calibration data to a file
        CalibrationDataExport(WorkstationStatusStrip1.Hardware.Workstation, outFile)
    End Sub
    Private Sub CalibrationFilePick()
        ' Open a file dialog to select a calibration file
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Calibration File",
            .Filter = "Calibration Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        }
        If ofd.ShowDialog() = DialogResult.OK Then txtCalibrationFile.Text = ofd.FileName
    End Sub
    Private Sub CalibrationImport(filePath As String)
        ' Import and show calibration data from a file
        WorkstationCalibrationShow(CalibrationDataImport(My.Computer.Name, filePath))
    End Sub
    Private Sub CalibrationParse()
        ' Parse the calibration data from UI components and update the Workstation instance
        With WorkstationStatusStrip1.Hardware.Workstation
            .AngleCalibration = Double.Parse(txtAngleCalibration.Text)
            .DepthCalibration = Double.Parse(txtDepthCalibration.Text)
            .RadiusCalibration = Double.Parse(txtRadiusCalibration.Text)
            .AngleResolution = Integer.Parse(TxtAngleResolution.Text)
            .DepthResolution = Integer.Parse(TxtDepthResolution.Text)
            .RadiusResolution = Integer.Parse(TxtRadiusResolution.Text)
            .RadiusOffset = Integer.Parse(TxtRadiusOffsetR.Text)
            .RadiusOffsetL = Integer.Parse(TxtRadiusOffsetL.Text)
            .HalfProbeDiameter = Integer.Parse(txtHalfProbeDiameter.Text)
            .ScanIncrement = Integer.Parse(txtScanIncrement.Text)
            .FixedOffset = Integer.Parse(txtFixedOffset.Text)
        End With
    End Sub
    Private Sub CalibrationSave()
        ' Save the calibration data from UI components to the encoder hardware and database
        Dim db As New HaleMRIContext()
        If WorkstationStatusStrip1.Hardware.Workstation Is Nothing Then
            ' If no workstation exists for the current machine, create a new one
            WorkstationStatusStrip1.Hardware.Workstation = New Workstation With {.Hostname = My.Computer.Name}
            CalibrationParse()
            db.Workstations.Add(WorkstationStatusStrip1.Hardware.Workstation)
        Else
            ' Update the existing workstation with new calibration data
            CalibrationParse()
            db.Workstations.Update(WorkstationStatusStrip1.Hardware.Workstation)
        End If
        db.SaveChanges()
        ' Update the encoder hardware with the new calibration values
        EncodersCalibrationSet()
        SaveCancelControlsEnabled(False)
    End Sub
    Private Sub CalibrationZero()
        ' Reset the calibration values to zero
        txtAngleCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
        txtDepthCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
        txtRadiusCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
    End Sub
    Private Sub EncodersControlsEnabled(ByVal value As Boolean)
        ' Enable or disable UI encoder controls based on the value parameter
        cmdAngleCalibration.Enabled = value
        cmdDepthCalibration.Enabled = value
        cmdRadiusCalibration.Enabled = value
        chkCalibrateAll.Enabled = value
        cmdZeroCalibration.Enabled = value
    End Sub
    Private Sub EncodersCalibrationSet(Optional ByVal ws As Workstation = Nothing)
        ' Set the encoder calibration values from the workstation data or UI components
        If ws IsNot Nothing Then
            If Not IsDBNull(ws.AngleCalibration) Then WorkstationStatusStrip1.Hardware.Encoders.AngleCalibration = ws.AngleCalibration
            If Not IsDBNull(ws.DepthCalibration) Then WorkstationStatusStrip1.Hardware.Encoders.DepthCalibration = ws.DepthCalibration
            If Not IsDBNull(ws.RadiusCalibration) Then WorkstationStatusStrip1.Hardware.Encoders.RadiusCalibration = ws.RadiusCalibration
            If Not IsDBNull(ws.RadiusOffset) Then WorkstationStatusStrip1.Hardware.Encoders.RadiusOffset = ws.RadiusOffset
        Else
            WorkstationStatusStrip1.Hardware.Encoders.AngleCalibration = Double.Parse(txtAngleCalibration.Text)
            WorkstationStatusStrip1.Hardware.Encoders.DepthCalibration = Double.Parse(txtDepthCalibration.Text)
            WorkstationStatusStrip1.Hardware.Encoders.RadiusCalibration = Double.Parse(txtRadiusCalibration.Text)
            WorkstationStatusStrip1.Hardware.Encoders.RadiusOffset = Integer.Parse(TxtRadiusOffsetR.Text)
        End If
    End Sub
    Private Sub EncodersCalibrationShow()
        ' Load encoder calibration data into UI components
        txtAngleCalibration.Text = WorkstationStatusStrip1.Hardware.Encoders.AngleCalibration.ToString()
        txtDepthCalibration.Text = WorkstationStatusStrip1.Hardware.Encoders.DepthCalibration.ToString()
        txtRadiusCalibration.Text = WorkstationStatusStrip1.Hardware.Encoders.RadiusCalibration.ToString()
        TxtRadiusOffsetR.Text = WorkstationStatusStrip1.Hardware.Encoders.RadiusOffset.ToString()
    End Sub
    Private Sub ImexControlsEnabled(ByVal value As Boolean)
        ' Enable or disable the Import and Export calibration controls based on the value parameter
        cmdImportCalibration.Enabled = value
        cmdExportCalibration.Enabled = value
    End Sub
    Private Sub GetAngleCalibration()
        ' Get the angle calibration value from the encoder hardware and update the UI component
        txtAngleCalibration.Text = WorkstationStatusStrip1.Calibrate(USDigital.ANGLE_ENCODER).ToString()
    End Sub
    Private Sub GetDepthCalibration()
        ' Get the depth calibration value from the encoder hardware and update the UI component
        txtDepthCalibration.Text = WorkstationStatusStrip1.Calibrate(USDigital.DEPTH_ENCODER).ToString()
    End Sub
    Private Sub GetRadiusCalibration()
        ' Get the radius calibration value from the encoder hardware and update the UI component
        txtRadiusCalibration.Text = WorkstationStatusStrip1.Calibrate(USDigital.RADIUS_ENCODER).ToString()
    End Sub
    Private Sub PollingEnable(ByVal enable As Boolean)
        ' Enable or disable the encoder polling timer and update the UI accordingly
        timerCalibration.Enabled = enable
        chkCalibrateAll.Checked = enable
        WorkstationStatusStrip1.Enabled = Not enable
    End Sub
    Private Sub WorkstationCalibrationShow(Optional ByVal ws As Workstation = Nothing)
        ' Display the calibration data from the workstation in the UI components
        If ws Is Nothing Then ws = WorkstationStatusStrip1.Hardware.Workstation
        txtAngleCalibration.Text = ws.AngleCalibration.ToString()
        txtDepthCalibration.Text = ws.DepthCalibration.ToString()
        txtRadiusCalibration.Text = ws.RadiusCalibration.ToString()
        TxtAngleResolution.Text = ws.AngleResolution.ToString()
        TxtDepthResolution.Text = ws.DepthResolution.ToString()
        TxtRadiusResolution.Text = ws.RadiusResolution.ToString()
        TxtRadiusOffsetR.Text = ws.RadiusOffset.ToString()
        TxtRadiusOffsetL.Text = ws.RadiusOffsetL.ToString()
        txtHalfProbeDiameter.Text = ws.HalfProbeDiameter.ToString()
        txtScanIncrement.Text = ws.ScanIncrement.ToString()
        txtFixedOffset.Text = ws.FixedOffset.ToString()
        Me.Refresh()
    End Sub
#End Region
#Region "UI Event Handlers"
    Private Sub ChkCalibrateAll_Click(sender As Object, e As EventArgs) Handles chkCalibrateAll.Click
        Try
            PollingEnable(chkCalibrateAll.Checked)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub CmdAngleCalibration_Click(sender As Object, e As EventArgs) Handles cmdAngleCalibration.Click
        Try
            GetAngleCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdCalibrationFile_Click(sender As Object, e As EventArgs) Handles cmdCalibrationFile.Click
        Try
            CalibrationFilePick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdCancelCalibration_Click(sender As Object, e As EventArgs) Handles cmdCancelCalibration.Click
        CalibrationCancel()
    End Sub
    Private Sub CmdDefaultCalibration_Click(sender As Object, e As EventArgs) Handles cmdDefaultCalibration.Click
        Try
            CalibrationDefault()
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_READ & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdExportCalibration_Click(sender As Object, e As EventArgs) Handles cmdExportCalibration.Click
        Try
            CalibrationExport(txtCalibrationFile.Text)
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_WRITE & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdDepthCalibration_Click(sender As Object, e As EventArgs) Handles cmdDepthCalibration.Click
        Try
            GetDepthCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdImportCalibration_Click(sender As Object, e As EventArgs) Handles cmdImportCalibration.Click
        Try
            CalibrationImport(txtCalibrationFile.Text)
        Catch ex As Exception
            MsgBox(STR_ERR_IMPORT & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdRadiusCalibration_Click(sender As Object, e As EventArgs) Handles cmdRadiusCalibration.Click
        Try
            GetRadiusCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdSaveCalibration_Click(sender As Object, e As EventArgs) Handles cmdSaveCalibration.Click
        Try
            CalibrationSave()
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_WRITE & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdZeroCalibration_Click(sender As Object, e As EventArgs) Handles cmdZeroCalibration.Click
        Try
            CalibrationZero()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub TimerCalibration_Tick(sender As Object, e As EventArgs) Handles timerCalibration.Tick
        Try
            GetAngleCalibration()
            GetDepthCalibration()
            GetRadiusCalibration()
        Catch ex As Exception
            PollingEnable(False)
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub

    Private Sub TxtAngleCalibration_TextChanged(sender As Object, e As EventArgs) Handles txtAngleCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtAngleResolution_TextChanged(sender As Object, e As EventArgs)
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtCalibrationFile_TextChanged(sender As Object, e As EventArgs) Handles txtCalibrationFile.TextChanged
        ImexControlsEnabled(txtCalibrationFile.Text.Length > 0)
    End Sub
    Private Sub TxtDepthCalibration_TextChanged(sender As Object, e As EventArgs) Handles txtDepthCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtDepthResolution_TextChanged(sender As Object, e As EventArgs)
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtFixedOffset_TextChanged(sender As Object, e As EventArgs) Handles txtFixedOffset.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtHalfProbeDiameter_TextChanged(sender As Object, e As EventArgs) Handles txtHalfProbeDiameter.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusCalibration_TextChanged(sender As Object, e As EventArgs) Handles txtRadiusCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusOffset_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusOffsetR.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusOffsetL_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusOffsetL.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusResolution_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusResolution.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub txtScanIncrement_TextChanged(sender As Object, e As EventArgs) Handles txtScanIncrement.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
#End Region
End Class