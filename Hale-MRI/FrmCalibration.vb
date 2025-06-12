Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.Imex
Imports LibEncoder
Public Class FrmCalibration
#Region "Constants"
    Private Const STR_ERR_CALIBRATE As String = "Calibration failed"
    Private Const STR_ERR_CALIBRATION_DEFAULT As String = "Default"
    Private Const STR_ERR_CALIBRATION_READ As String = "Error retrieving calibration data from the database: "
    Private Const STR_ERR_CALIBRATION_WRITE As String = "Error saving calibration data to the database: "
    Private Const STR_ERR_EXPORT As String = "Error exporting calibration data: "
    Private Const STR_ERR_IMPORT As String = "Error importing calibration data: "
    Private Const STR_ERR_INITIALIZATION As String = "Initialization failed"
    Private Const STR_ERR_RESET As String = "Reset failed"
    Private Const STR_STATUS_NOT_INITIALIZED As String = "Not Initialized"
    Private Const STR_STATUS_ERROR As String = "Encoder Error"
    Private Const STR_STATUS_NO_ENCODERS As String = "No encoders"
    Private Const STR_STATUS_READY As String = "Ready"
    Private Const STR_TITLE_APPLICATION_ERROR As String = "Application Error"
    Private Const STR_TITLE_CALIBRATION_ERROR As String = "Calibration Data Error"
    Private Const STR_TITLE_ENCODER_ERROR As String = "Encoder Error"
#End Region
#Region "Private Members"
    Private mHardware As WorkstationEncoders
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
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
            If mHardware IsNot Nothing Then
                If mHardware.Encoders IsNot Nothing Then
                    If Not mHardware.Encoders.Initialized Then EncodersInitialize()
                    EncodersControlsEnabled(mHardware.Encoders.Initialized)
                End If
                If mHardware.Workstation IsNot Nothing Then WorkstationCalibrationShow()
                SaveCancelControlsEnabled(False)   ' The text changed events will enable these, so disable them initially
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
        CalibrationDataExport(mHardware.Workstation, outFile)
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
        With mHardware.Workstation
            .AngleCalibration = Double.Parse(txtAngleCalibration.Text)
            .DepthCalibration = Double.Parse(txtDepthCalibration.Text)
            .RadiusCalibration = Double.Parse(txtRadiusCalibration.Text)
            .AngleResolution = Integer.Parse(txtAngleResolution.Text)
            .DepthResolution = Integer.Parse(txtDepthResolution.Text)
            .RadiusResolution = Integer.Parse(txtRadiusResolution.Text)
            .RadiusOffset = Integer.Parse(txtRadiusOffsetR.Text)
            .RadiusOffsetL = Integer.Parse(txtRadiusOffsetL.Text)
            .HalfProbeDiameter = Integer.Parse(txtHalfProbeDiameter.Text)
            .ScanIncrement = Integer.Parse(txtScanIncrement.Text)
            .FixedOffset = Integer.Parse(txtFixedOffset.Text)
        End With
    End Sub
    Private Sub CalibrationSave()
        ' Save the calibration data from UI components to the encoder hardware and database
        Dim db As New HaleMRIContext()
        If mHardware.Workstation Is Nothing Then
            ' If no workstation exists for the current machine, create a new one
            mHardware.Workstation = New Workstation With {.Hostname = My.Computer.Name}
            CalibrationParse()
            db.Workstations.Add(mHardware.Workstation)
        Else
            ' Update the existing workstation with new calibration data
            CalibrationParse()
            db.Workstations.Update(mHardware.Workstation)
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
        ResetAngleToolStripMenuItem.Enabled = value
    End Sub
    Private Sub EncodersCalibrationSet(Optional ByVal ws As Workstation = Nothing)
        ' Set the encoder calibration values from the workstation data or UI components
        If ws IsNot Nothing Then
            If Not IsDBNull(ws.AngleCalibration) Then mHardware.Encoders.AngleCalibration = ws.AngleCalibration
            If Not IsDBNull(ws.DepthCalibration) Then mHardware.Encoders.DepthCalibration = ws.DepthCalibration
            If Not IsDBNull(ws.RadiusCalibration) Then mHardware.Encoders.RadiusCalibration = ws.RadiusCalibration
            If Not IsDBNull(ws.RadiusOffset) Then mHardware.Encoders.RadiusOffset = ws.RadiusOffset
        Else
            mHardware.Encoders.AngleCalibration = Double.Parse(txtAngleCalibration.Text)
            mHardware.Encoders.DepthCalibration = Double.Parse(txtDepthCalibration.Text)
            mHardware.Encoders.RadiusCalibration = Double.Parse(txtRadiusCalibration.Text)
            mHardware.Encoders.RadiusOffset = Integer.Parse(txtRadiusOffsetR.Text)
        End If
    End Sub
    Private Sub EncodersCalibrationShow()
        ' Load encoder calibration data into UI components
        txtAngleCalibration.Text = mHardware.Encoders.AngleCalibration.ToString()
        txtDepthCalibration.Text = mHardware.Encoders.DepthCalibration.ToString()
        txtRadiusCalibration.Text = mHardware.Encoders.RadiusCalibration.ToString()
        txtRadiusOffsetR.Text = mHardware.Encoders.RadiusOffset.ToString()
    End Sub
    Private Sub EncodersErrorShow(prompt As String, msg As String)
        ' Display an error message and update the UI accordingly
        MsgBox(prompt & ": " & msg, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        StatusLabel.Text = STR_STATUS_ERROR
        EncodersControlsEnabled(False)
    End Sub
    Private Sub EncodersInitialize()
        ' Initialize the encoder hardware and update the UI accordingly
        mHardware.Encoders.Initialize()
        StatusLabel.Text = STR_STATUS_READY
        EncodersControlsEnabled(True)
    End Sub
    Private Sub FormInitialize()
        ' Initialize the form and controls
        WorkstationLabel.Text = My.Computer.Name
    End Sub
    Private Sub ImexControlsEnabled(ByVal value As Boolean)
        cmdImportCalibration.Enabled = value
        cmdExportCalibration.Enabled = value
    End Sub
    Private Sub GetAngleCalibration()
        mHardware.Encoders.Calibrate(USDigital.ANGLE_ENCODER)
        txtAngleCalibration.Text = mHardware.Encoders.AngleCalibration.ToString()
    End Sub
    Private Sub GetDepthCalibration()
        mHardware.Encoders.Calibrate(USDigital.DEPTH_ENCODER)
        txtDepthCalibration.Text = mHardware.Encoders.DepthCalibration.ToString()
    End Sub
    Private Sub GetRadiusCalibration()
        mHardware.Encoders.Calibrate(USDigital.RADIUS_ENCODER)
        txtRadiusCalibration.Text = mHardware.Encoders.RadiusCalibration.ToString()
    End Sub
    Private Sub WorkstationCalibrationShow(Optional ByVal ws As Workstation = Nothing)
        ' Display the calibration data from the workstation in the UI components
        If ws Is Nothing Then ws = mHardware.Workstation
        txtAngleCalibration.Text = ws.AngleCalibration.ToString()
        txtDepthCalibration.Text = ws.DepthCalibration.ToString()
        txtRadiusCalibration.Text = ws.RadiusCalibration.ToString()
        txtAngleResolution.Text = ws.AngleResolution.ToString()
        txtDepthResolution.Text = ws.DepthResolution.ToString()
        txtRadiusResolution.Text = ws.RadiusResolution.ToString()
        txtRadiusOffsetR.Text = ws.RadiusOffset.ToString()
        txtRadiusOffsetL.Text = ws.RadiusOffsetL.ToString()
        txtHalfProbeDiameter.Text = ws.HalfProbeDiameter.ToString()
        txtScanIncrement.Text = ws.ScanIncrement.ToString()
        txtFixedOffset.Text = ws.FixedOffset.ToString()
    End Sub
#End Region
#Region "UI Event Handlers"
    Private Sub CmdAngleCalibration_Click(sender As Object, e As EventArgs) Handles cmdAngleCalibration.Click
        ' Calibrate the angle encoder and update the UI with the new calibration value
        Try
            GetAngleCalibration()
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_CALIBRATE, ex.Message)
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
            MsgBox(STR_ERR_CALIBRATION_WRITE & ex.Message, MsgBoxStyle.Critical, STR_TITLE_CALIBRATION_ERROR)
        End Try
    End Sub
    Private Sub CmdDepthCalibration_Click(sender As Object, e As EventArgs) Handles cmdDepthCalibration.Click
        ' Calibrate the depth encoder and update the UI with the new calibration value
        Try
            GetDepthCalibration()
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_CALIBRATE, ex.Message)
        End Try
    End Sub
    Private Sub CmdImportCalibration_Click(sender As Object, e As EventArgs) Handles cmdImportCalibration.Click
        ' Import calibration data from a file and update the UI accordingly
        Try
            CalibrationImport(txtCalibrationFile.Text)
        Catch ex As Exception
            MsgBox(STR_ERR_IMPORT & ex.Message, MsgBoxStyle.Critical, STR_TITLE_CALIBRATION_ERROR)
        End Try
    End Sub
    Private Sub CmdRadiusCalibration_Click(sender As Object, e As EventArgs) Handles cmdRadiusCalibration.Click
        ' Calibrate the radius encoder and update the UI with the new calibration value
        Try
            GetRadiusCalibration()
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_CALIBRATE, ex.Message)
        End Try
    End Sub
    Private Sub CmdSaveCalibration_Click(sender As Object, e As EventArgs) Handles cmdSaveCalibration.Click
        Try
            ' Save the calibration data to the encoder hardware and database
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
    Private Sub FrmHardware_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormInitialize()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub InitializeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InitializeToolStripMenuItem.Click
        Try
            EncodersInitialize()
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_INITIALIZATION, ex.Message)
        End Try
    End Sub
    Private Sub ResetAngleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetAngleToolStripMenuItem.Click
        Try
            mHardware.Encoders.ResetCount(USDigital.ANGLE_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_RESET, ex.Message)
        End Try
    End Sub
    Private Sub ResetDepthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetDepthToolStripMenuItem.Click
        Try
            mHardware.Encoders.ResetCount(USDigital.DEPTH_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_RESET, ex.Message)
        End Try
    End Sub
    Private Sub ResetRadiusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetRadiusToolStripMenuItem.Click
        Try
            mHardware.Encoders.ResetCount(USDigital.RADIUS_ENCODER)
        Catch ex As Exception
            EncodersErrorShow(STR_ERR_RESET, ex.Message)
        End Try
    End Sub
    Private Sub TxtAngleCalibration_TextChanged(sender As Object, e As EventArgs) Handles txtAngleCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtAngleResolution_TextChanged(sender As Object, e As EventArgs) Handles txtAngleResolution.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtCalibrationFile_TextChanged(sender As Object, e As EventArgs) Handles txtCalibrationFile.TextChanged
        ImexControlsEnabled(txtCalibrationFile.Text.Length > 0)
    End Sub
    Private Sub TxtDepthCalibration_TextChanged(sender As Object, e As EventArgs) Handles txtDepthCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtDepthResolution_TextChanged(sender As Object, e As EventArgs) Handles txtDepthResolution.TextChanged
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
    Private Sub TxtRadiusOffset_TextChanged(sender As Object, e As EventArgs) Handles txtRadiusOffsetR.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusOffsetL_TextChanged(sender As Object, e As EventArgs) Handles txtRadiusOffsetL.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusResolution_TextChanged(sender As Object, e As EventArgs) Handles txtRadiusResolution.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub txtScanIncrement_TextChanged(sender As Object, e As EventArgs) Handles txtScanIncrement.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub

    Private Sub TimerCalibration_Tick(sender As Object, e As EventArgs) Handles timerCalibration.Tick
        Try
            GetAngleCalibration()
            GetDepthCalibration()
            GetRadiusCalibration()
        Catch ex As Exception
            timerCalibration.Enabled = False
            EncodersErrorShow(STR_ERR_CALIBRATE, ex.Message)
        End Try
    End Sub
    Private Sub chkCalibrateAll_Click(sender As Object, e As EventArgs) Handles chkCalibrateAll.Click
        Try
            timerCalibration.Enabled = chkCalibrateAll.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
#End Region
End Class