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
        ' This property sets the Hardware property of the EncoderStatusStrip1 control so
        ' that its UI updates accordingly.
        Get
            Return EncoderStatusStrip1.Hardware
        End Get
        Set(value As WorkstationEncoders)
            EncoderStatusStrip1.Hardware = value
            If EncoderStatusStrip1.Hardware IsNot Nothing Then
                If EncoderStatusStrip1.Hardware.Workstation IsNot Nothing Then WorkstationCalibrationShow()
                SaveCancelControlsEnabled(False)   ' The text changed events will enable these, so disable them initially
                If EncoderStatusStrip1.Hardware.Encoders IsNot Nothing Then
                    Try
                        If Not EncoderStatusStrip1.Hardware.Encoders.Initialized Then EncoderStatusStrip1.Initialize()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
                    End Try
                End If
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub SaveCancelControlsEnabled(ByVal enabled As Boolean)
        ' Enable or disable the Save and Cancel buttons based on the value parameter
        CmdSaveCalibration.Enabled = enabled AndAlso DataEntryControlsFilled()
        CmdCancelCalibration.Enabled = enabled AndAlso DataEntryControlsFilled()
    End Sub
    Private Sub CalibrationCancel()
        ' Cancel the calibration data changes and reset the UI components
        WorkstationCalibrationShow()
        EncodersCalibrationSet()
        SaveCancelControlsEnabled(False)
    End Sub
    Private Sub CalibrationControlsEnable(ByVal enabled As Boolean)
        CmdZeroCalibration.Enabled = enabled
        CmdDefaultCalibration.Enabled = enabled
        CmdAngleCalibration.Enabled = enabled
        CmdDefaultCalibration.Enabled = enabled
        CmdDepthCalibration.Enabled = enabled
        CmdRadiusCalibration.Enabled = enabled
    End Sub
    Private Sub DataEntryControlsEnable(ByVal enabled As Boolean)
        TxtAngleResolution.Enabled = enabled
        TxtDepthResolution.Enabled = enabled
        TxtRadiusResolution.Enabled = enabled
        TxtRadiusOffsetR.Enabled = enabled
        TxtRadiusOffsetL.Enabled = enabled
        TxtHalfProbeDiameter.Enabled = enabled
        TxtScanIncrement.Enabled = enabled
        TxtFixedOffset.Enabled = enabled
    End Sub
    Private Function DataEntryControlsFilled() As Boolean
        Return _
            TxtAngleResolution.Text <> "" AndAlso
            TxtDepthResolution.Text <> "" AndAlso
            TxtRadiusResolution.Text <> "" AndAlso
            TxtRadiusOffsetR.Text <> "" AndAlso
            TxtRadiusOffsetL.Text <> "" AndAlso
            TxtHalfProbeDiameter.Text <> "" AndAlso
            TxtScanIncrement.Text <> "" AndAlso
            TxtFixedOffset.Text <> ""
    End Function
    Private Sub FileControlsEnable(ByVal enabled As Boolean)
        CmdCalibrationFile.Enabled = enabled
        TxtCalibrationFile.Enabled = enabled
    End Sub
    Private Sub FormControlsEnable(ByVal enabled As Boolean)
        CalibrationControlsEnable(enabled)
        DataEntryControlsEnable(enabled)
        FileControlsEnable(enabled)
        If Not enabled Then
            ImexControlsEnabled(False)
        Else
            ImexControlsEnabled(TxtCalibrationFile.Text <> "")
        End If
        SaveCancelControlsEnabled(enabled)
    End Sub
    Private Sub CalibrationDefault()
        ' Reset the calibration values to default
        Dim db As New HaleMRIContext()
        WorkstationCalibrationShow(db.Workstations.FirstOrDefault(Function(w) w.Hostname = STR_ERR_CALIBRATION_DEFAULT))
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub CalibrationExport(ByRef outFile As String)
        ' Export the calibration data to a file
        CalibrationDataExport(EncoderStatusStrip1.Hardware.Workstation, outFile)
    End Sub
    Private Sub CalibrationFilePick()
        ' Open a file dialog to select a calibration file
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Calibration File",
            .Filter = "Calibration Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        }
        If ofd.ShowDialog() = DialogResult.OK Then TxtCalibrationFile.Text = ofd.FileName
    End Sub
    Private Sub CalibrationImport(filePath As String)
        ' Import and show calibration data from a file
        WorkstationCalibrationShow(CalibrationDataImport(My.Computer.Name, filePath))
    End Sub
    Private Sub CalibrationParse()
        ' Parse the calibration data from UI components and update the Workstation instance
        With EncoderStatusStrip1.Hardware.Workstation
            .AngleCalibration = Double.Parse(TxtAngleCalibration.Text)
            .DepthCalibration = Double.Parse(TxtDepthCalibration.Text)
            .RadiusCalibration = Double.Parse(TxtRadiusCalibration.Text)
            .AngleResolution = Integer.Parse(TxtAngleResolution.Text)
            .DepthResolution = Integer.Parse(TxtDepthResolution.Text)
            .RadiusResolution = Integer.Parse(TxtRadiusResolution.Text)
            .RadiusOffset = Integer.Parse(TxtRadiusOffsetR.Text)
            .RadiusOffsetL = Integer.Parse(TxtRadiusOffsetL.Text)
            .HalfProbeDiameter = Integer.Parse(TxtHalfProbeDiameter.Text)
            .ScanIncrement = Integer.Parse(TxtScanIncrement.Text)
            .FixedOffset = Integer.Parse(TxtFixedOffset.Text)
        End With
    End Sub
    Private Sub CalibrationSave()
        ' Save the calibration data from UI components to the encoder hardware and database
        Dim db As New HaleMRIContext()
        If EncoderStatusStrip1.Hardware.Workstation Is Nothing Then
            ' If no workstation exists for the current machine, create a new one
            EncoderStatusStrip1.Hardware.Workstation = New Workstation With {.Hostname = My.Computer.Name}
            CalibrationParse()
            db.Workstations.Add(EncoderStatusStrip1.Hardware.Workstation)
        Else
            ' Update the existing workstation with new calibration data
            CalibrationParse()
            db.Workstations.Update(EncoderStatusStrip1.Hardware.Workstation)
        End If
        db.SaveChanges()
        ' Update the encoder hardware with the new calibration values
        EncodersCalibrationSet()
        SaveCancelControlsEnabled(False)
    End Sub
    Private Sub CalibrationZero()
        ' Reset the calibration values to zero
        TxtAngleCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
        TxtDepthCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
        TxtRadiusCalibration.Text = USDigital.CALIBRATION_DEFAULT.ToString()
    End Sub
    Private Sub EncodersControlsEnabled(ByVal value As Boolean)
        ' Enable or disable UI encoder controls based on the value parameter
        CmdAngleCalibration.Enabled = value
        CmdDepthCalibration.Enabled = value
        CmdRadiusCalibration.Enabled = value
        ChkCalibrateAll.Enabled = value
        CmdZeroCalibration.Enabled = value
    End Sub
    Private Sub EncodersCalibrationSet(Optional ByVal ws As Workstation = Nothing)
        ' Set the encoder calibration values from the workstation data or UI components
        If ws IsNot Nothing Then
            If Not IsDBNull(ws.AngleCalibration) Then EncoderStatusStrip1.Hardware.Encoders.AngleCalibration = ws.AngleCalibration
            If Not IsDBNull(ws.DepthCalibration) Then EncoderStatusStrip1.Hardware.Encoders.DepthCalibration = ws.DepthCalibration
            If Not IsDBNull(ws.RadiusCalibration) Then EncoderStatusStrip1.Hardware.Encoders.RadiusCalibration = ws.RadiusCalibration
            If Not IsDBNull(ws.RadiusOffset) Then EncoderStatusStrip1.Hardware.Encoders.RadiusOffset = ws.RadiusOffset
        Else
            EncoderStatusStrip1.Hardware.Encoders.AngleCalibration = Double.Parse(TxtAngleCalibration.Text)
            EncoderStatusStrip1.Hardware.Encoders.DepthCalibration = Double.Parse(TxtDepthCalibration.Text)
            EncoderStatusStrip1.Hardware.Encoders.RadiusCalibration = Double.Parse(TxtRadiusCalibration.Text)
            EncoderStatusStrip1.Hardware.Encoders.RadiusOffset = Integer.Parse(TxtRadiusOffsetR.Text)
        End If
    End Sub
    Private Sub EncodersCalibrationShow()
        ' Load encoder calibration data into UI components
        TxtAngleCalibration.Text = EncoderStatusStrip1.Hardware.Encoders.AngleCalibration.ToString()
        TxtDepthCalibration.Text = EncoderStatusStrip1.Hardware.Encoders.DepthCalibration.ToString()
        TxtRadiusCalibration.Text = EncoderStatusStrip1.Hardware.Encoders.RadiusCalibration.ToString()
        TxtRadiusOffsetR.Text = EncoderStatusStrip1.Hardware.Encoders.RadiusOffset.ToString()
    End Sub
    Private Sub ImexControlsEnabled(ByVal value As Boolean)
        ' Enable or disable the Import and Export calibration controls based on the value parameter
        cmdImportCalibration.Enabled = value
        cmdExportCalibration.Enabled = value
    End Sub
    Private Sub GetAngleCalibration()
        ' Get the angle calibration value from the encoder hardware and update the UI component
        TxtAngleCalibration.Text = EncoderStatusStrip1.CalibrateAngle().ToString()
    End Sub
    Private Sub GetDepthCalibration()
        ' Get the depth calibration value from the encoder hardware and update the UI component
        TxtDepthCalibration.Text = EncoderStatusStrip1.CalibrateDepth().ToString()
    End Sub
    Private Sub GetRadiusCalibration()
        ' Get the radius calibration value from the encoder hardware and update the UI component
        TxtRadiusCalibration.Text = EncoderStatusStrip1.CalibrateRadius().ToString()
    End Sub
    Private Sub PollingEnable(ByVal enable As Boolean)
        ' Enable or disable the encoder polling timer and update the UI accordingly
        timerCalibration.Enabled = enable
        ChkCalibrateAll.Checked = enable
        EncoderStatusStrip1.Enabled = Not enable
        FormControlsEnable(Not enable)
    End Sub
    Private Sub WorkstationCalibrationShow(Optional ByVal ws As Workstation = Nothing)
        ' Display the calibration data from the workstation in the UI components
        If ws Is Nothing Then ws = EncoderStatusStrip1.Hardware.Workstation
        TxtAngleCalibration.Text = ws.AngleCalibration.ToString()
        TxtDepthCalibration.Text = ws.DepthCalibration.ToString()
        TxtRadiusCalibration.Text = ws.RadiusCalibration.ToString()
        TxtAngleResolution.Text = ws.AngleResolution.ToString()
        TxtDepthResolution.Text = ws.DepthResolution.ToString()
        TxtRadiusResolution.Text = ws.RadiusResolution.ToString()
        TxtRadiusOffsetR.Text = ws.RadiusOffset.ToString()
        TxtRadiusOffsetL.Text = ws.RadiusOffsetL.ToString()
        TxtHalfProbeDiameter.Text = ws.HalfProbeDiameter.ToString()
        TxtScanIncrement.Text = ws.ScanIncrement.ToString()
        TxtFixedOffset.Text = ws.FixedOffset.ToString()
        Me.Refresh()
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub ChkCalibrateAll_Click(sender As Object, e As EventArgs) Handles ChkCalibrateAll.Click
        Try
            PollingEnable(ChkCalibrateAll.Checked)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub CmdAngleCalibration_Click(sender As Object, e As EventArgs) Handles CmdAngleCalibration.Click
        Try
            GetAngleCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdCalibrationFile_Click(sender As Object, e As EventArgs) Handles CmdCalibrationFile.Click
        Try
            CalibrationFilePick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdCancelCalibration_Click(sender As Object, e As EventArgs) Handles CmdCancelCalibration.Click
        CalibrationCancel()
    End Sub
    Private Sub CmdDefaultCalibration_Click(sender As Object, e As EventArgs) Handles CmdDefaultCalibration.Click
        Try
            CalibrationDefault()
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_READ & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdExportCalibration_Click(sender As Object, e As EventArgs) Handles cmdExportCalibration.Click
        Try
            CalibrationExport(TxtCalibrationFile.Text)
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_WRITE & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdDepthCalibration_Click(sender As Object, e As EventArgs) Handles CmdDepthCalibration.Click
        Try
            GetDepthCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdImportCalibration_Click(sender As Object, e As EventArgs) Handles cmdImportCalibration.Click
        Try
            CalibrationImport(TxtCalibrationFile.Text)
        Catch ex As Exception
            MsgBox(STR_ERR_IMPORT & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdRadiusCalibration_Click(sender As Object, e As EventArgs) Handles CmdRadiusCalibration.Click
        Try
            GetRadiusCalibration()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_ENCODER_ERROR)
        End Try
    End Sub
    Private Sub CmdSaveCalibration_Click(sender As Object, e As EventArgs) Handles CmdSaveCalibration.Click
        Try
            CalibrationSave()
        Catch ex As Exception
            MsgBox(STR_ERR_CALIBRATION_WRITE & ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub
    Private Sub CmdZeroCalibration_Click(sender As Object, e As EventArgs) Handles CmdZeroCalibration.Click
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

    Private Sub TxtAngleCalibration_TextChanged(sender As Object, e As EventArgs) Handles TxtAngleCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtAngleResolution_TextChanged(sender As Object, e As EventArgs) Handles TxtAngleResolution.TextChanged
        SaveCancelControlsEnabled(TxtAngleResolution.Text.Length > 0)
    End Sub
    Private Sub TxtCalibrationFile_TextChanged(sender As Object, e As EventArgs) Handles TxtCalibrationFile.TextChanged
        ImexControlsEnabled(TxtCalibrationFile.Text.Length > 0)
    End Sub
    Private Sub TxtDepthCalibration_TextChanged(sender As Object, e As EventArgs) Handles TxtDepthCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtDepthResolution_TextChanged(sender As Object, e As EventArgs) Handles TxtDepthResolution.TextChanged
        SaveCancelControlsEnabled(TxtDepthResolution.Text.Length > 0)
    End Sub
    Private Sub TxtFixedOffset_TextChanged(sender As Object, e As EventArgs) Handles TxtFixedOffset.TextChanged
        SaveCancelControlsEnabled(TxtFixedOffset.Text.Length > 0)
    End Sub
    Private Sub TxtHalfProbeDiameter_TextChanged(sender As Object, e As EventArgs) Handles TxtHalfProbeDiameter.TextChanged
        SaveCancelControlsEnabled(TxtHalfProbeDiameter.Text.Length > 0)
    End Sub
    Private Sub TxtRadiusCalibration_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusCalibration.TextChanged
        SaveCancelControlsEnabled(True)
    End Sub
    Private Sub TxtRadiusOffsetR_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusOffsetR.TextChanged
        SaveCancelControlsEnabled(TxtRadiusOffsetR.Text.Length > 0)
    End Sub
    Private Sub TxtRadiusOffsetL_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusOffsetL.TextChanged
        SaveCancelControlsEnabled(TxtRadiusOffsetL.Text.Length > 0)
    End Sub
    Private Sub TxtRadiusResolution_TextChanged(sender As Object, e As EventArgs) Handles TxtRadiusResolution.TextChanged
        SaveCancelControlsEnabled(TxtRadiusResolution.Text.Length > 0)
    End Sub
    Private Sub TxtScanIncrement_TextChanged(sender As Object, e As EventArgs) Handles TxtScanIncrement.TextChanged
        SaveCancelControlsEnabled(TxtScanIncrement.Text.Length > 0)
    End Sub
#End Region
End Class