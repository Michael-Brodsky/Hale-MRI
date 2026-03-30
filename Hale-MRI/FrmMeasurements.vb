Imports System.ComponentModel
Imports System.Security.Cryptography
Imports System.Windows.Forms.DataVisualization.Charting
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
Imports Microsoft.EntityFrameworkCore
Imports LibDisplayControls.MRIMath
Imports LibDisplayControls.Tolerances
Imports LibDisplayControls
Public Class FrmMeasurements
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private Const kMaxSamplesPerScan As Integer = 200           ' Maximum number of samples per scan (this is a database Setting).
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
    Private mNewJobDetail As JobDetail = Nothing                ' The new JobDetail record being added.
    Private mRadiusPercent As New MovingAverage(2)              ' Keeps a moving average of RadiusPercent measurements during a scan.
    Private mRadiusMeasurement As RadiusMeasurement = Nothing   ' Stores the RadiusMeasurement to which CellMeasurements collected during a scan are assigned to. 
    Private mSampleCount As Integer                             ' Number of samples for the current scan.
    Private mScanIncrement As Double = 1.8                      ' The angle increment between samples in degrees(this will be recalculated on form load but this is the default value).
    Private mHomeSet As Boolean = False                       ' Whether the home position has been set for the current JobDetail.
    Private mLastScannedAngle As Double = Double.MaxValue       ' The last angle measurement saved during scanning (Used with mScanIncrement to determine when to save a new measurement).
    Private mTolerance As String = String.Empty
    Private mScannedPoints As Integer = 0

#If NO_ENCODERS Then
    Private mCm As Integer = 0
    Private mEncoderData As List(Of RadiusMeasurement) = Nothing
    Private mRd As Integer = 0
#End If
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Adds a new JobDetail for the given Job
    ''' </summary>
    ''' <param name="job"></param>
    Public Sub AddNew(ByVal job As Job)
        mNewJobDetail = New JobDetail With {
            .Job = job,
            .StartDate = Date.Now,
            .PerformedByNavigation = Me.User
        }
        MasterSource.AddNew()
    End Sub
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext
    ''' <summary>
    ''' Finds the given JobDetail and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The JobDetail to find.</param>
    ''' <returns>The found JobDetail, or Nothing if not found.</returns>
    Public Function Find(item As JobDetail) As JobDetail
        Dim result As JobDetail = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function
    ''' <summary>
    ''' Gets/sets the encoder hardware used by the form.
    ''' </summary>
    ''' <returns></returns>
    Public Property Hardware As WorkstationEncoders
        Get
            Return EncoderStatusStrip1.Hardware
        End Get
        Set(value As WorkstationEncoders)
            ' Assigns the given value to EncoderStatusStrip1, retrieves and assigns
            ' the scan sampling rate from the database and, if not already,
            ' initializes the encoder hardware.
            With EncoderStatusStrip1
                .Hardware = value
                If .Hardware IsNot Nothing Then
                    EncoderStatusStrip1.TimerInterval = Integer.Parse(SettingsGet(Database, STR_SETTING_ENCODER_DEFAULT_SAMPLE_PERIOD))
                    If .Hardware.Encoders IsNot Nothing AndAlso Not .Hardware.Encoders.Initialized Then EncoderStatusStrip1.Initialize()
                End If
            End With
        End Set
    End Property
    ''' <summary>
    ''' Loads all JobDetails and their Cell, Extreme and RadiusMeasurements
    ''' for the given Job.
    ''' </summary>
    ''' <returns></returns>
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJob)
                If mJob.LeExclusion Is Nothing Then mJob.LeExclusion = 0
                If mJob.TeExclusion Is Nothing Then mJob.TeExclusion = 0
                If Job.PropellerRotation = "L" Then
                    EncoderStatusStrip1.Hardware.Encoders.SetForward(0, False)
                Else
                    EncoderStatusStrip1.Hardware.Encoders.SetForward(0, True)
                End If
                ShowJobInfo()
            End If
        End Set
    End Property

    Public Property SelectedTolerance As String
        Get
            Return mJobDetails.ToleranceClass
        End Get
        Set(value As String)
            mTolerance = value
            If mJobDetails IsNot Nothing Then
                mJobDetails.ToleranceClass = value
                Database.SaveChanges()
                ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
                ShowBladePlot()
                ShowTrack()
                RefreshAll()
            End If
        End Set
    End Property

    Public Property HomeSet As Boolean
        Get
            Return mHomeSet
        End Get
        Set(value As Boolean)
            mHomeSet = value
            CmdHome.Enabled = Not value
            If value = True Then
                If JobDetails.RadiusMeasurements.Count >= 1 Then
                    Dim result = MessageBox.Show("Setting Home Position for this job will remove the previously scanned data.", "Set Home", MessageBoxButtons.OKCancel)
                    If result = DialogResult.OK Then
                        mJobDetails.RadiusMeasurements.Clear()
                        Database.SaveChanges()
                        ShowBladePitch(True)
                        ShowBladePlot()
                        ShowTrack()
                        ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
                        CmdHome.Visible = False
                        ChkScan.Enabled = True
                        ChkScan.BackColor = Color.ForestGreen
                    Else
                        mHomeSet = False
                        CmdHome.Enabled = True
                    End If
                    Exit Property
                End If
                CmdHome.Visible = False
                ChkScan.Enabled = True
                TxtStatus.Text = "Ready to Scan"
                ChkScan.BackColor = Color.ForestGreen
            End If
        End Set
    End Property
    ''' <summary>
    ''' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
    ''' </summary>
    ''' <returns></returns>
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            mJob = mJobDetails?.Job
            CmdHome.Enabled = True
            If mJobDetails IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJobDetails)
                ShowJobInfo()
            End If
        End Set
    End Property
    Public Property MinsApply As Boolean
        Get
            Return ChkMinimumsApply.Checked
        End Get
        Set(value As Boolean)
            ChkMinimumsApply.Checked = value
            ShowBladePitch(True)
            ShowBladePlot()
            ShowTrack()
            ShowTolerances(value, ChkAllowProgPitch.Checked)
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Function CreateNewJobDetail() As JobDetail
        Return New JobDetail With {
            .Job = mJob,
            .StartDate = Date.Now,
            .PerformedByNavigation = Me.User
        }
    End Function

    Private Function DeleteConfirm() As Boolean
        Return (MessageBox.Show($"Delete job detail and all measurements from {JobDetails?.StartDate}?", STR_TITLE_DEFAULT, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK)
    End Function

    Private Sub DeleteJobDetail()
        BindingSourceRemove(Database, JobDetailsBindingSource, Database.JobDetails)
    End Sub

    Private Sub FormSort(ByRef jobDetails As BindingList(Of JobDetail))
        For Each jd As JobDetail In jobDetails
            For Each rm As RadiusMeasurement In jd?.RadiusMeasurements
                rm.CellMeasurements = rm.CellMeasurements.OrderBy(Function(cm) cm.Id).ToList()
                rm.ExtremeMeasurements = rm.ExtremeMeasurements.OrderBy(Function(em) em.Id).ToList()
            Next
        Next
    End Sub

    Private Function GetMeasurementData(j As Object) As BindingList(Of JobDetail)
        Dim data As BindingList(Of JobDetail) = Nothing
        If TypeOf j Is Job Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd.Job Is CType(j, Job)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        ElseIf TypeOf j Is JobDetail Then
            data = New BindingList(Of JobDetail)(
            Database.JobDetails _
                .Where(Function(jd) jd Is CType(j, JobDetail)) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.CellMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .ThenInclude(Function(m) m.ExtremeMeasurements) _
                .OrderBy(Function(jd) jd.StartDate) _
                .AsSplitQuery().ToList()
            )
        End If
        FormSort(data)
        Return data
    End Function
    Private Sub MeasurementsGet()
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required. This one doesn't save Measurements.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
            TxtBlade.Text = blade
            TxtAngle.Text = Math.Round(angle, 2).ToString() + " °"
            TxtRadius.Text = Math.Round(radius.Value * 2, 2).ToString() + " In."
            TxtDepth.Text = Math.Round(depth, 2).ToString() + " In."
            TxtRadiusPercent.Text = Math.Round(radius.Percent * 100.0, 2).ToString() + " %"
            PlotVisualization(angle, radius.Percent * 100)
        End With
    End Sub
    Private Sub MeasurementsGet(lastAngle As Double)
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required. Saves the measurements if the angle measurement 
        ' changes by more than some specified amount.
        ' Doesn't change the Blade Number textbox as it wouldn't change during scanning.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            If TxtBlade.Text = "1" And angle >= 180 Then
                angle -= 360.0 'this is a simple way to handle overscan when crossing 0 degrees on blade 1 - this will make the change in angle consistent when crossing 0 degrees
            End If
            TxtAngle.Text = Math.Round(angle, 2).ToString() + " °"
            TxtRadius.Text = Math.Round(radius.Value * 2, 2).ToString() + " In."
            TxtDepth.Text = Math.Round(depth, 2).ToString() + " In."
            TxtRadiusPercent.Text = Math.Round(radius.Percent * 100.0, 2).ToString() + " %"
            If (lastAngle - angle) > mScanIncrement Then
                MeasurementsSave(angle, depth, radius)
                mSampleCount += 1
            End If
        End With
    End Sub
    Private Sub MeasurementsSave(ByVal angle As Double, ByVal depth As Double, ByVal radius As IEncoderHardware.RadiusMeasurement)
        ' Updates the RadiusPercent moving average and saves the given angle and depth measurements.
        If TxtBlade.Text = "1" And angle > 180.0 Then 'this is a simple way to handle overscan when crossing 0 degrees on blade 1
            angle -= 360.0                                           ' this will make the change in angle consistent when crossing 0 degrees
        End If
        mRadiusPercent.Input(radius.Percent * 100)
        Dim cm As New CellMeasurement With {
            .RadiusMeasurement = mRadiusMeasurement,
            .Angle = angle,
            .Depth = depth
        }
        Database.CellMeasurements.Add(cm)
        mLastScannedAngle = angle
    End Sub
    Private Sub PlotVisualization(angle As Double, radius As Double)
        If mJobDetails.Job.PropellerRotation = "L" Then
            angle = 360 - angle
        End If
        Dim img As New NamedImage With {
            .Name = "PlotVisualization",
            .Image = New Bitmap(1600, 1600)}
        Using g As Graphics = Graphics.FromImage(img.Image)
            g.Clear(Color.Transparent)
            Dim pen As New Pen(Color.White, 15)
            Dim halfheight As Double = 800
            Dim halfwidth As Double = 800
            Dim adjustedheight As Double = halfheight + (halfheight * Math.Sin(angle * Math.PI / 180.0))
            Dim adjustedwidth As Double = halfwidth + (halfwidth * Math.Cos(angle * Math.PI / 180.0))
            g.DrawLine(pen, New Point(halfwidth, halfheight), New Point(adjustedwidth, adjustedheight))
            Dim adjustedradius As Double = radius / 100
            Dim adjwidth As Double = halfwidth * adjustedradius
            Dim adjheight As Double = halfheight * adjustedradius
            Dim Ellipsewidth As Double = adjwidth * 2
            Dim Ellipseheight As Double = adjheight * 2
            pen.Color = Color.White
            g.DrawEllipse(pen, CType(halfwidth - adjwidth, Integer), CType(halfheight - adjheight, Integer), CType(Ellipsewidth, Integer), CType(Ellipseheight, Integer))
        End Using
        chartPlot.Images.Clear()
        chartPlot.Images.Add(img)
        If chartPlot.ChartAreas.Count = 0 Then Return
        chartPlot.ChartAreas(0).BackImage = "PlotVisualization"
    End Sub

    Protected Overrides Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If Navigator IsNot Nothing Then Navigator.MasterSource = mMasterSource
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then mNavigator.Database = Database
        End Set
    End Property
    Private Sub NewRadiusMeasurement()
        ' RadiusMeasurement is now parent (PK) of Cell and ExtremeMeasurements
        ' (FK). Clear the previous moving average and create a new
        ' RadiusMeasurement with .Radius = 0, which will be updated at
        ' the end of the scan.
        mRadiusPercent.Clear()
        mRadiusMeasurement = New RadiusMeasurement With {
            .JobDetails = Me.JobDetails,
            .Radius = 0.0,
            .LeCell = 0,
            .TeCell = 0
        }
        mLastScannedAngle = 1000.0 'ensure first measurement is always saved
        'mRadiusPercent.Input(Double.Parse(TxtRadiusPercent.Text))
    End Sub

    Private Function ReferenceRadiiGet(ByVal blade As Integer) As List(Of Double)
        ' Returns a list of reference radii for the given blade.
        Dim radii As New List(Of Double)
        If mJobDetails?.RadiusMeasurements IsNot Nothing Then
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements
                If rm.BladeId = blade Then radii.Add(Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES))
            Next
        End If
        Return radii
    End Function

    Private Sub SaveRadiusMeasurement()
        ' Update and save the current RadiusMeasurement with the moving average
        ' we collected while scanning.
        If Database.RadiusMeasurements.Local.Where(Function(rm) rm.JobDetailsId = mJobDetails.Id And rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).Any() Then
            Database.RadiusMeasurements.Local.Remove(Database.RadiusMeasurements.Local.Where(Function(rm) rm.JobDetailsId = mJobDetails.Id And rm.BladeId = Integer.Parse(TxtBlade.Text) And Math.Round(rm.Radius().Value) = Math.Round(mRadiusPercent.Output())).FirstOrDefault())
        End If
        If mSampleCount < 3 Then ' if less than 3 samples then we consider this a bad scan and we don't save the measurement
            JobDetails.RadiusMeasurements.Remove(mRadiusMeasurement)
            TxtStatus.Text = "Ready to Scan"
            ChkScan.Text = "Scan"
            Return
        End If
        mRadiusMeasurement.Radius = mRadiusPercent.Output()
        mRadiusMeasurement.BladeId = Integer.Parse(TxtBlade.Text)
        mRadiusMeasurement.TeCell = mSampleCount - 1
        Database.RadiusMeasurements.Add(mRadiusMeasurement)
        Database.SaveChanges()
        TxtStatus.Text = "Ready to Scan"
        ChkScan.Text = "Scan"
        ComboReferenceBlade.SelectedIndex = mRadiusMeasurement.BladeId - 1
        Dim radlist = ReferenceRadiiGet(mRadiusMeasurement.BladeId)
        ComboReferenceRadius.DataSource = radlist
        ComboReferenceRadius.SelectedIndex = radlist.IndexOf(Math.Round(mRadiusMeasurement.Radius.Value))
    End Sub

    Private Sub ScanControlsEnabled(ByVal isScanning As Boolean)
    End Sub

    Private Property Scanning As Boolean
        Get
            Return ChkScan.Checked
        End Get
        Set(value As Boolean)
            If value Then
                NewRadiusMeasurement()
                mSampleCount = 0
                TxtStatus.Text = "Scanning..."
                ChkScan.Text = "Stop"
                ChkScan.BackColor = Color.Red
                TxtStatus.BackColor = Color.Red
            Else
                TxtStatus.Text = "Saving Measurements..."
                ChkScan.BackColor = Color.ForestGreen
                TxtStatus.BackColor = Color.ForestGreen
                SaveRadiusMeasurement()
                ShowBladePitch(True)
                ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
                ShowBladePlot()
                ShowTrack()
            End If
            ScanControlsEnabled(value)
        End Set
    End Property

    Private Function ShowMeanPitchPropellerTolerance(minsapply As Boolean, app As Boolean, classes As List(Of Tolerance)) As Integer
        Dim passingClass = 0
        For Each tol As Tolerance In classes
            If passingClass < classes.IndexOf(tol) Then
                Return passingClass
            End If
            Dim pitch = mJobDetails.WheelPitch
            Dim meanPitch As ToleranceColor = CheckWheelPitch(tol, pitch, mJob.DesiredPitch, minsapply)
            If meanPitch <> ToleranceColor.Pass Then
                passingClass += 1
            End If
        Next
        Return passingClass
    End Function
    Private Function ShowAngularDeviationTolerance(classes As List(Of Tolerance), radius As Double) As Integer
        Dim passingClass As Integer = 0
        Dim largestDeviation As Double = 0.0
        For Each tol As Tolerance In classes
            If passingClass < classes.IndexOf(tol) Then
                Exit For
            End If
            Dim blade As Integer
            For blade = 1 To mJob?.PropellerBlades
                Dim rad As RadiusMeasurement
                Dim rad2 As RadiusMeasurement
                Dim nextBlade As Integer = blade + 1
                If blade = mJob.PropellerBlades Then
                    nextBlade = 1
                End If
                If mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = blade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).Any() Then
                    rad = mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = blade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).FirstOrDefault()
                    rad2 = mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = nextBlade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).FirstOrDefault()
                Else ' if no radii at selected radius then no classes pass inspection
                    Return 5
                End If
                Dim bladeMidAngle = GetChordMidAngle(rad.CellMeasurements) ' need to make all necessary checks to select a good radius measurement
                Dim nextBladeMidAngle = GetChordMidAngle(rad2.CellMeasurements)
                If rad2.BladeId = 1 Then
                    nextBladeMidAngle += 360
                End If
                Dim CurrentDeviation As Double
                If bladeMidAngle - nextBladeMidAngle < 0 Then
                    CurrentDeviation = nextBladeMidAngle - bladeMidAngle
                    If CurrentDeviation < mJobDetails.Job.PropellerBlades / 360 Then
                        CurrentDeviation = (mJobDetails.Job.PropellerBlades / 360) - CurrentDeviation
                    Else
                        CurrentDeviation = CurrentDeviation - (360 / mJobDetails.Job.PropellerBlades)
                    End If
                Else
                    CurrentDeviation = Math.Abs(bladeMidAngle - nextBladeMidAngle)
                    If CurrentDeviation < mJobDetails.Job.PropellerBlades / 360 Then
                        CurrentDeviation = (mJobDetails.Job.PropellerBlades / 360) - CurrentDeviation
                    Else
                        CurrentDeviation = CurrentDeviation - (360 / mJobDetails.Job.PropellerBlades)
                    End If
                End If
                If largestDeviation < Math.Abs(CurrentDeviation) Then
                    largestDeviation = CurrentDeviation
                End If
                Dim angDeviationCheck As ToleranceColor = CheckAngularDeviation(tol, mJob.PropellerBlades, bladeMidAngle, nextBladeMidAngle)
                If angDeviationCheck <> ToleranceColor.Pass Then
                    passingClass += 1
                    Exit For
                End If
            Next
        Next
        TxtAngularDeviation.Text = Math.Round(Math.Abs(largestDeviation), 2).ToString("F2") + "°"
        Return passingClass
    End Function
    Private Function ShowAxialPositionTolerance(classes As List(Of Tolerance), radius As Double) As Integer
        Dim passingClass As Integer = 0
        Dim largestDeviation As Double = 0.0
        For Each tol As Tolerance In classes
            If passingClass < classes.IndexOf(tol) Then
                Return passingClass
            End If
            Dim blade As Integer
            For blade = 1 To mJob?.PropellerBlades
                Dim rad As RadiusMeasurement
                Dim rad2 As RadiusMeasurement
                Dim nextBlade As Integer = blade + 1
                If blade = mJob.PropellerBlades Then
                    nextBlade = 1
                End If
                If mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = blade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).Any() Then
                    rad = mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = blade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).FirstOrDefault()
                    rad2 = mJobDetails?.RadiusMeasurements.Where(Function(rm) rm.BladeId = nextBlade).Where(Function(rm) Math.Round(rm.Radius.Value) = radius).FirstOrDefault()
                Else ' if no radii at selected radius then no classes pass inspection
                    Return 5
                End If
                Dim bladeMidDepth = GetChordMidDepth(rad.CellMeasurements) ' need to make all necessary checks to select a good radius measurement
                Dim nextBladeMidDepth = GetChordMidDepth(rad2.CellMeasurements)
                If largestDeviation < Math.Abs(bladeMidDepth - nextBladeMidDepth) Then
                    largestDeviation = Math.Abs(bladeMidDepth - nextBladeMidDepth)
                End If
                Dim axialPosCheck As ToleranceColor = CheckAngularDeviation(tol, mJob.PropellerBlades, bladeMidDepth, nextBladeMidDepth)
                If axialPosCheck <> ToleranceColor.Pass Then
                    passingClass += 1
                    Exit For
                End If
            Next
        Next
        TxtAxialPosition.Text = Math.Round(largestDeviation, 2).ToString() + " In."
        Return passingClass
    End Function
    Private Sub ShowTolerances(mins As Boolean, app As Boolean)
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim Classes As New List(Of Tolerance) From {GetToleranceTable(Database, "S"), GetToleranceTable(Database, "I"), GetToleranceTable(Database, "II"), GetToleranceTable(Database, "III"), GetToleranceTable(Database, "Custom")}
        ' Classes(0) = Class S Classes(1) = Class I Classes(2) = Class II Classes(3) = Class III Classes(4) = Custom
        If ChkLocalPitch.Checked Then
            Dim LocalPitchClass As Integer = ShowLocalPitchTolerance(JobDetails, mins, app, Classes) 'need to implement local pitch radius restrictions IE class S needs 5 radii
            Select Case LocalPitchClass
                Case 0
                    LabTolLPS.ForeColor = Color.Green
                    LabTolLPI.ForeColor = Color.Green
                    LabTolLPII.ForeColor = Color.Green
                    LabTolLPC.ForeColor = Color.Green
                Case 1
                    LabTolLPS.ForeColor = Color.Red
                    LabTolLPI.ForeColor = Color.Green
                    LabTolLPII.ForeColor = Color.Green
                    LabTolLPC.ForeColor = Color.Green
                Case 2
                    LabTolLPS.ForeColor = Color.Red
                    LabTolLPI.ForeColor = Color.Red
                    LabTolLPII.ForeColor = Color.Green
                    LabTolLPC.ForeColor = Color.Green
                Case 3
                    LabTolLPS.ForeColor = Color.Red
                    LabTolLPI.ForeColor = Color.Red
                    LabTolLPII.ForeColor = Color.Red
                    LabTolLPC.ForeColor = Color.Green
                Case Else
                    LabTolLPS.ForeColor = Color.Red
                    LabTolLPI.ForeColor = Color.Red
                    LabTolLPII.ForeColor = Color.Red
                    LabTolLPC.ForeColor = Color.Red
            End Select
        End If
        If ChkMeanPitchRadius.Checked Then
            Dim MeanPitchRadiusClass As Integer = ShowMeanPitchRadiusTolerance(mJobDetails, mins, app, Classes)
            Select Case MeanPitchRadiusClass
                Case 0
                    LabTolMPRS.ForeColor = Color.Green
                    LabTolMPRI.ForeColor = Color.Green
                    LabTolMPRII.ForeColor = Color.Green
                    LabTolMPRIII.ForeColor = Color.Green
                    LabTolMPRC.ForeColor = Color.Green
                Case 1
                    LabTolMPRS.ForeColor = Color.Red
                    LabTolMPRI.ForeColor = Color.Green
                    LabTolMPRII.ForeColor = Color.Green
                    LabTolMPRIII.ForeColor = Color.Green
                    LabTolMPRC.ForeColor = Color.Green
                Case 2
                    LabTolMPRS.ForeColor = Color.Red
                    LabTolMPRI.ForeColor = Color.Red
                    LabTolMPRII.ForeColor = Color.Green
                    LabTolMPRIII.ForeColor = Color.Green
                    LabTolMPRC.ForeColor = Color.Green
                Case 3
                    LabTolMPRS.ForeColor = Color.Red
                    LabTolMPRI.ForeColor = Color.Red
                    LabTolMPRII.ForeColor = Color.Red
                    LabTolMPRIII.ForeColor = Color.Green
                    LabTolMPRC.ForeColor = Color.Green
                Case 4
                    LabTolMPRS.ForeColor = Color.Red
                    LabTolMPRI.ForeColor = Color.Red
                    LabTolMPRII.ForeColor = Color.Red
                    LabTolMPRIII.ForeColor = Color.Red
                    LabTolMPRC.ForeColor = Color.Green
                Case 5
                    LabTolMPRS.ForeColor = Color.Red
                    LabTolMPRI.ForeColor = Color.Red
                    LabTolMPRII.ForeColor = Color.Red
                    LabTolMPRIII.ForeColor = Color.Red
                    LabTolMPRC.ForeColor = Color.Red
            End Select
        End If
        If ChkMeanPitchBlade.Checked Then
            Dim MeanPitchBladeClass As Integer = ShowMeanPitchBladeTolerance(mJobDetails, mins, app, Classes)
            Select Case MeanPitchBladeClass
                Case 0
                    LabTolMPBS.ForeColor = Color.Green
                    LabTolMPBI.ForeColor = Color.Green
                    LabTolMPBII.ForeColor = Color.Green
                    LabTolMPBIII.ForeColor = Color.Green
                    LabTolMPBC.ForeColor = Color.Green
                Case 1
                    LabTolMPBS.ForeColor = Color.Red
                    LabTolMPBI.ForeColor = Color.Green
                    LabTolMPBII.ForeColor = Color.Green
                    LabTolMPBIII.ForeColor = Color.Green
                    LabTolMPBC.ForeColor = Color.Green
                Case 2
                    LabTolMPBS.ForeColor = Color.Red
                    LabTolMPBI.ForeColor = Color.Red
                    LabTolMPBII.ForeColor = Color.Green
                    LabTolMPBIII.ForeColor = Color.Green
                    LabTolMPBC.ForeColor = Color.Green
                Case 3
                    LabTolMPBS.ForeColor = Color.Red
                    LabTolMPBI.ForeColor = Color.Red
                    LabTolMPBII.ForeColor = Color.Red
                    LabTolMPBIII.ForeColor = Color.Green
                    LabTolMPBC.ForeColor = Color.Green
                Case 4
                    LabTolMPBS.ForeColor = Color.Red
                    LabTolMPBI.ForeColor = Color.Red
                    LabTolMPBII.ForeColor = Color.Red
                    LabTolMPBIII.ForeColor = Color.Red
                    LabTolMPBC.ForeColor = Color.Green
                Case Else
                    LabTolMPBS.ForeColor = Color.Red
                    LabTolMPBI.ForeColor = Color.Red
                    LabTolMPBII.ForeColor = Color.Red
                    LabTolMPBIII.ForeColor = Color.Red
                    LabTolMPBC.ForeColor = Color.Red
            End Select
        End If
        If ChkMeanPitchPropeller.Checked Then
            Dim MeanPitchPropellerClass = ShowMeanPitchPropellerTolerance(mins, app, Classes)
            Select Case MeanPitchPropellerClass
                Case 0
                    LabTolMPPS.ForeColor = Color.Green
                    LabTolMPPI.ForeColor = Color.Green
                    LabTolMPPII.ForeColor = Color.Green
                    LabTolMPPIII.ForeColor = Color.Green
                    LabTolMPPC.ForeColor = Color.Green
                Case 1
                    LabTolMPPS.ForeColor = Color.Red
                    LabTolMPPI.ForeColor = Color.Green
                    LabTolMPPII.ForeColor = Color.Green
                    LabTolMPPIII.ForeColor = Color.Green
                    LabTolMPPC.ForeColor = Color.Green
                Case 2
                    LabTolMPPS.ForeColor = Color.Red
                    LabTolMPPI.ForeColor = Color.Red
                    LabTolMPPII.ForeColor = Color.Green
                    LabTolMPPIII.ForeColor = Color.Green
                    LabTolMPPC.ForeColor = Color.Green
                Case 3
                    LabTolMPPS.ForeColor = Color.Red
                    LabTolMPPI.ForeColor = Color.Red
                    LabTolMPPII.ForeColor = Color.Red
                    LabTolMPPIII.ForeColor = Color.Green
                    LabTolMPPC.ForeColor = Color.Green
                Case 4
                    LabTolMPPS.ForeColor = Color.Red
                    LabTolMPPI.ForeColor = Color.Red
                    LabTolMPPII.ForeColor = Color.Red
                    LabTolMPPIII.ForeColor = Color.Red
                    LabTolMPPC.ForeColor = Color.Green
                Case Else
                    LabTolMPPS.ForeColor = Color.Red
                    LabTolMPPI.ForeColor = Color.Red
                    LabTolMPPII.ForeColor = Color.Red
                    LabTolMPPIII.ForeColor = Color.Red
                    LabTolMPPC.ForeColor = Color.Red
            End Select
        End If
        If ChkAngularDeviation.Checked Then
            Dim AngularDeviationClass As Integer = ShowAngularDeviationTolerance(Classes, 70)
            Select Case AngularDeviationClass
                Case 0
                    LabTolADS.ForeColor = Color.Green
                    LabTolADI.ForeColor = Color.Green
                    LabTolADII.ForeColor = Color.Green
                    LabTolADIII.ForeColor = Color.Green
                    LabTolADC.ForeColor = Color.Green
                Case 1
                    LabTolADS.ForeColor = Color.Red
                    LabTolADI.ForeColor = Color.Green
                    LabTolADII.ForeColor = Color.Green
                    LabTolADIII.ForeColor = Color.Green
                    LabTolADC.ForeColor = Color.Green
                Case 2
                    LabTolADS.ForeColor = Color.Red
                    LabTolADI.ForeColor = Color.Red
                    LabTolADII.ForeColor = Color.Green
                    LabTolADIII.ForeColor = Color.Green
                    LabTolADC.ForeColor = Color.Green
                Case 3
                    LabTolADS.ForeColor = Color.Red
                    LabTolADI.ForeColor = Color.Red
                    LabTolADII.ForeColor = Color.Red
                    LabTolADIII.ForeColor = Color.Green
                    LabTolADC.ForeColor = Color.Green
                Case 4
                    LabTolADS.ForeColor = Color.Red
                    LabTolADI.ForeColor = Color.Red
                    LabTolADII.ForeColor = Color.Red
                    LabTolADIII.ForeColor = Color.Red
                    LabTolADC.ForeColor = Color.Green
                Case Else
                    LabTolADS.ForeColor = Color.Red
                    LabTolADI.ForeColor = Color.Red
                    LabTolADII.ForeColor = Color.Red
                    LabTolADIII.ForeColor = Color.Red
                    LabTolADC.ForeColor = Color.Red
            End Select
        End If
        If ChkAxialPosition.Checked Then
            Dim AxialPositionClass = ShowAxialPositionTolerance(Classes, 70)
            Select Case AxialPositionClass
                Case 0
                    LabTolAPS.ForeColor = Color.Green
                    LabTolAPI.ForeColor = Color.Green
                    LabTolAPII.ForeColor = Color.Green
                    LabTolAPIII.ForeColor = Color.Green
                    LabTolAPC.ForeColor = Color.Green
                Case 1
                    LabTolAPS.ForeColor = Color.Red
                    LabTolAPI.ForeColor = Color.Green
                    LabTolAPII.ForeColor = Color.Green
                    LabTolAPIII.ForeColor = Color.Green
                    LabTolAPC.ForeColor = Color.Green
                Case 2
                    LabTolAPS.ForeColor = Color.Red
                    LabTolAPI.ForeColor = Color.Red
                    LabTolAPII.ForeColor = Color.Green
                    LabTolAPIII.ForeColor = Color.Green
                    LabTolAPC.ForeColor = Color.Green
                Case 3
                    LabTolAPS.ForeColor = Color.Red
                    LabTolAPI.ForeColor = Color.Red
                    LabTolAPII.ForeColor = Color.Red
                    LabTolAPIII.ForeColor = Color.Green
                    LabTolAPC.ForeColor = Color.Green
                Case 4
                    LabTolAPS.ForeColor = Color.Red
                    LabTolAPI.ForeColor = Color.Red
                    LabTolAPII.ForeColor = Color.Red
                    LabTolAPIII.ForeColor = Color.Red
                    LabTolAPC.ForeColor = Color.Green
                Case Else
                    LabTolAPS.ForeColor = Color.Red
                    LabTolAPI.ForeColor = Color.Red
                    LabTolAPII.ForeColor = Color.Red
                    LabTolAPIII.ForeColor = Color.Red
                    LabTolAPC.ForeColor = Color.Red
            End Select
        End If
    End Sub
    Private Sub ShowBladePitch(show As Boolean)
        Dim dtBladePitch As New DataTable()
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim PitchBasis As Double
        If ComboPitchBasis.Text = "Mean" Then
            PitchBasis = mJobDetails.WheelPitch
        ElseIf ComboPitchBasis.Text = "Marked" Then
            PitchBasis = mJobDetails.Job.MarkedPitch
        ElseIf ComboPitchBasis.Text = "Desired" Then
            PitchBasis = mJobDetails.Job.DesiredPitch
        End If
        Dim ToleranceTable As Tolerance = GetToleranceTable(Database, If(mJobDetails?.ToleranceClass, "D"))
        Dim TotalPitchWheel As Double = 0.0
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("Blade", GetType(Integer))
        Dim colPitch As DataColumn = dtBladePitch.Columns.Add("Blade", GetType(Double))
        Dim rowRadiusBlade As DataRow
        Dim rowBladeBlade As DataRow
        Dim x As Integer
        For x = 1 To Job?.PropellerBlades
            rowRadiusBlade = dtBladePitchByRadius.Rows.Add(x)
            rowBladeBlade = dtBladePitch.Rows.Add(x)
        Next
        GridBladePitch.DataSource = dtBladePitch
        dtBladePitch.Columns.Add("Avg Pitch", GetType(String))
        GridBladebyRadius.DataSource = dtBladePitchByRadius
        dtBladePitch.PrimaryKey = New DataColumn() {colPitch}
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0 ' Condensed these for loops into one to increase speed
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade")).ToList().OrderBy(Function(r) r.Radius)
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(dtBladePitchByRadius.Rows.Find(rm.BladeId), dtBladePitchByRadius.Rows.Add(rm.BladeId))
                colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(String)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2).ToString("F2")
                Dim textAvgBladePitchColor As ToleranceColor = CheckBladeRadiusPitch(ToleranceTable, pitch, PitchBasis, MinsApply) ' Check tolerance and adjust text color
                GridBladebyRadius.Rows(dtBladePitchByRadius.Rows.IndexOf(row)).Cells(colRadius.Ordinal).Style.ForeColor = ToColor(textAvgBladePitchColor)
                totalPitch += pitch
                pitchCount += 1
            Next
            colPitch = If(dtBladePitch.Columns("Avg Pitch"), dtBladePitch.Columns.Add("Avg Pitch", GetType(String)))
            Dim avgPitch As Double = totalPitch / pitchCount
            TotalPitchWheel += avgPitch
            Dim bladePitchColor As ToleranceColor = CheckBladePitch(ToleranceTable, avgPitch, PitchBasis, MinsApply) ' Check tolerance and adjust text color
            dtBladePitch.Rows(row.Item("Blade") - 1).Item("Avg Pitch") = Math.Round(totalPitch / pitchCount, 3).ToString("F3")
            GridBladePitch.Rows(row.Item("Blade") - 1).Cells(1).Style.ForeColor = Tolerances.ToColor(bladePitchColor)
        Next
        mJobDetails.WheelPitch = TotalPitchWheel / mJob.PropellerBlades
        Dim textWheelPitchColor As ToleranceColor = CheckWheelPitch(ToleranceTable, mJobDetails.WheelPitch, PitchBasis, True)
        TxtWheelPitch.ForeColor = Tolerances.ToColor(textWheelPitchColor)
        TxtWheelPitch.Text = mJobDetails.WheelPitch.ToString()
        GridBladePitch.Columns(0).Visible = False
        TLayoutGrids.ColumnStyles(1).Width = GridBladePitch.Columns(1).Width + 3
        For Each Col As DataGridViewColumn In GridBladebyRadius.Columns
            Col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        rowRadiusBlade = dtBladePitchByRadius.Rows(0)
        For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = 1).ToList().OrderBy(Function(r) r.Radius)
            Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
            colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(String)))
            Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
            Dim textAvgBladePitchColor As ToleranceColor = CheckBladeRadiusPitch(ToleranceTable, pitch, PitchBasis, MinsApply) ' Check tolerance and adjust text color
            GridBladebyRadius.Rows(0).Cells(colRadius.Ordinal).Style.ForeColor = ToColor(textAvgBladePitchColor)
        Next
    End Sub

    Private Sub ShowJobInfo()
        ' Show the current Customer, Vessel, Job and Propeller info.
        Dim bsReferenceBlades As New BindingList(Of Integer)
        For i As Integer = 1 To mJob.PropellerBlades
            bsReferenceBlades.Add(i)
        Next
        Dim strBlades As String = If(Job?.PropellerBlades IsNot Nothing, $"Blades = {Job?.PropellerBlades}", "")
        Dim strDiameter As String = If(Job?.PropellerDiameter IsNot Nothing, $"Dia = {Job?.PropellerDiameter}", "")
        Dim strBore As String = If(Job?.PropellerBore IsNot Nothing, $"Bore = {Job?.PropellerBore}", "")
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = If(Job?.PropellerManufacturer?.ManufacturerName, "")
        TxtStyle.Text = If(Job?.PropellerStyleNavigation?.Style1, "")
        TxtMaterial.Text = If(Job?.PropellerMaterialNavigation?.Material1, "")
        TxtBlades.Text = strBlades
        TxtDiameter.Text = strDiameter
        TxtBore.Text = strBore
        ComboReferenceBlade.DataSource = bsReferenceBlades
        ComboReferencePoint.SelectedItem = "LE"
        ComboReferenceRadius.DataSource = ReferenceRadiiGet(ComboReferenceBlade.SelectedValue)
        ComboPitchBasis.SelectedItem = "Marked"
        ComboTolerance.SelectedItem = GetToleranceTable(Database, JobDetails?.ToleranceClass)
        CmdHome.Visible = True
        ShowPitchBasis()
    End Sub

    Private Sub ShowJobDetailsInfo()
        ' Update any controls that consume data from the current JobDetail record.
        ShowBladePitch(True)
        ShowTrack()
        ShowBladePlot()
    End Sub

    Private Sub ShowPitchBasis()
        Select Case ComboPitchBasis.SelectedItem.ToString()
            Case "Mean"
                If TxtWheelPitch.Text <> "NaN" Then
                    TxtBasis.Text = TxtWheelPitch.Text
                Else
                    TxtBasis.Text = Job?.MarkedPitch.ToString()
                End If
            Case "Marked"
                TxtBasis.Text = Job?.MarkedPitch.ToString()
            Case "Desired"
                TxtBasis.Text = Job?.DesiredPitch.ToString()
            Case Else
        End Select
        ShowBladePlot()
        ShowBladePitch(True)
    End Sub

    Private Sub ShowTrack()
        If ComboReferenceRadius.Items.Count > 0 Then
            If ComboReferenceRadius.SelectedValue Is Nothing Then
                ComboReferenceRadius.SelectedIndex = 0
            End If
        End If

        ChartBladeHeight1.BladeCount = mJobDetails?.Job?.PropellerBlades
        ChartBladeHeight1.ReferenceBlade = ComboReferenceBlade.SelectedValue
        ChartBladeHeight1.ReferencePoint = ComboReferencePoint.SelectedValue
        ChartBladeHeight1.ReferenceRadius = ComboReferenceRadius.SelectedValue
        ChartBladeHeight1.Data = mJobDetails?.RadiusMeasurements
        ChartBladeHeight1.RadiusMeasurements = mJobDetails?.RadiusMeasurements?.
            Where(Function(r) r.BladeId = ChartBladeHeight1.ReferenceBlade).
            OrderBy(Function(r) CType(r.Radius, Double)).ToList()

        ChartAngularPosition1.BladeCount = ChartBladeHeight1.BladeCount
        ChartAngularPosition1.ReferenceBlade = ChartBladeHeight1.ReferenceBlade
        ChartAngularPosition1.ReferencePoint = ChartBladeHeight1.ReferencePoint
        ChartAngularPosition1.ReferenceRadius = ChartBladeHeight1.ReferenceRadius
        ChartAngularPosition1.Data = ChartBladeHeight1.Data
        ChartAngularPosition1.RadiusMeasurements = ChartBladeHeight1.RadiusMeasurements

        ShowRake(
            ChartBladeHeight1.InnerDepth,
            ChartBladeHeight1.OuterDepth,
            ChartBladeHeight1.InnerRadius?.Radius,
            ChartBladeHeight1.OuterRadius?.Radius,
            ChartBladeHeight1.ReferenceRadius
        )
    End Sub

    Private Sub ShowBladePlot()
        If mJobDetails Is Nothing Then Return

        ' Clear any existing chart areas and series.
        chartPlot.ChartAreas.Clear()
        chartPlot.Series.Clear()
        chartPlot.Titles.Clear()

        ' Add a ChartArea and Title for the point graph
        Dim chartArea1 As New ChartArea()
        chartArea1.AxisX.MajorGrid.Enabled = False
        chartArea1.AxisY.MajorGrid.Enabled = False
        chartArea1.AxisX.LabelStyle.Enabled = False
        chartArea1.AxisY.LabelStyle.Enabled = False
        chartArea1.AxisX.MajorTickMark.Enabled = False
        chartArea1.AxisY.MajorTickMark.Enabled = False
        chartArea1.AxisX.LineWidth = 0
        chartArea1.AxisY.LineWidth = 0
        chartArea1.Position = New ElementPosition(0, 0, 100, 100)
        chartArea1.InnerPlotPosition = New ElementPosition(0, 0, 100, 100)
        chartArea1.BackColor = Color.Transparent
        chartArea1.BackImageWrapMode = ChartImageWrapMode.Scaled
        chartPlot.ChartAreas.Add(chartArea1)

        ' Get a list of RadiusMeasurements for this JobDetail.
        Dim radiusMeasurements As List(Of RadiusMeasurement) =
            mJobDetails?.RadiusMeasurements _
            .OrderBy(Function(b) b.BladeId) _
            .ThenBy(Function(r) CType(r.Radius, Double)) _
            .ToList()
        ' The chart axes min/max values are the greatest radius value,
        ' this way the arcs always start at the outside of the chart area.
        chartArea1.AxisX.Maximum = kBladePlotAxesMax
        chartArea1.AxisX.Minimum = -chartArea1.AxisX.Maximum
        chartArea1.AxisY.Maximum = chartArea1.AxisX.Maximum
        chartArea1.AxisY.Minimum = -chartArea1.AxisY.Maximum
        ' Each RadiusMeasurement is a new Series of Points that circumscribes an arc
        ' having a radius equal to RadiusMeasurement.Radius. 
        If ComboTolerance.Text = "" Then
            Return
        End If
        If TxtBasis.Text = "" Then
            Return
        End If
        Dim tolClass As Tolerance = Database.Tolerances.Where(Function(t) t.ToleranceClass = ComboTolerance.Text).FirstOrDefault()
        Dim basisPitch As Double = Double.Parse(TxtBasis.Text)
        Dim x As Integer
        For x = 1 To Job.PropellerBlades
            Dim midangfound As Boolean = False
            Dim midang As Double = 0
            Dim sr As New Series With {
                    .ChartType = SeriesChartType.Point,
                    .MarkerSize = 20,
                    .MarkerStyle = MarkerStyle.Star10,
                    .MarkerColor = GraphColorArray(x - 1),
                    .Name = "BladeLab" + x.ToString(),
                    .Label = x.ToString(),
                    .LabelForeColor = Color.White}
            If JobDetails?.RadiusMeasurements.Contains(JobDetails?.RadiusMeasurements.FirstOrDefault(Function(r) r.BladeId = x)) Then
                Dim rad As RadiusMeasurement = JobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = x).FirstOrDefault()
                Dim mid As Double = GetChordMidAngle(rad.CellMeasurements)
                Dim bladelabpoint = PolarToCartesian(25, mid)
                sr.Points.AddXY(bladelabpoint.x, bladelabpoint.y)
                chartPlot.Series.Add(sr)
            End If
            For Each rm As RadiusMeasurement In radiusMeasurements.Where(Function(r) r.BladeId = x).ToList()
                If ChkPlotAngularDeviation.Checked Then
                    If midangfound = False Then
                        If rm.Radius >= 65 And rm.Radius <= 75 Then
                            midangfound = True
                            midang = GetChordMidAngle(rm.CellMeasurements)
                            Dim ser As New Series With {
                                .ChartType = SeriesChartType.Line,
                                .Name = "MidAngBlade" + x.ToString(),
                                .Color = Color.White,
                                .BorderWidth = 3
                            }
                            Dim midangcoordslow = PolarToCartesian(25, midang)
                            Dim midangcoordshigh = PolarToCartesian(100, midang)
                            ser.Points.AddXY(midangcoordslow.x, midangcoordslow.y)
                            ser.Points.AddXY(midangcoordshigh.x, midangcoordshigh.y)
                            chartPlot.Series.Add(ser)
                        End If
                    End If
                End If
                Dim s As New Series With {
                    .ChartType = SeriesChartType.Line,
                    .MarkerStyle = MarkerStyle.Circle,
                    .MarkerSize = 5
                }
                Dim cellMeasurements As List(Of CellMeasurement) = rm.CellMeasurements.ToList()
                Dim arcColors As New List(Of ToleranceColor)
                Dim sector As Integer = 1
                For sector = 1 To tolClass.LocalPitchSectors
                    arcColors.Add(CheckLocalPitchTolerance(tolClass, GetLocalPitch(cellMeasurements, tolClass.LocalPitchSectors, sector, Job.PropellerDiameter, rm.Radius, Job.TeExclusion, Job.LeExclusion), basisPitch, True))
                Next
                Dim cellPerSector As Integer = (Math.Floor(cellMeasurements.Count / tolClass.LocalPitchSectors))
                For i As Integer = 1 To cellMeasurements.Count - 1
                    Dim currentSector As Integer = Math.Truncate(i / cellPerSector)
                    Dim cmCurrent As CellMeasurement = cellMeasurements(i)
                    Dim cmPrevious As CellMeasurement = cellMeasurements(i - 1)
                    Dim angle As Double = (cmCurrent?.Angle + cmPrevious?.Angle) / 2
                    Dim coordinates = PolarToCartesian(rm.Radius, angle)
                    Dim p As Integer = s.Points.AddXY(coordinates.x, coordinates.y) ' Need a mathematical formula based on data in the dB or functions in MRIMath module x,y=f(a,b) ???
                    Dim pointcolor As ToleranceColor = arcColors(Math.Min(currentSector, arcColors.Count - 1))
                    s.Points(p).Color = ToColor(pointcolor)
                Next
                chartPlot.Series.Add(s)
            Next
        Next
    End Sub

    Private Sub ShowRake(ByVal innerDepth As Double?, ByVal outerDepth As Double?, ByVal innerRadius As Double?, ByVal outerRadius As Double?, ByVal radius As Double?)
        Dim deltaDepth As Double? = innerDepth - outerDepth
        Dim lengthRadius As Double? = (radius * outerRadius / 100.0) - (radius * innerRadius / 100.0)
        Dim rake As Double? = If(deltaDepth.HasValue AndAlso lengthRadius.HasValue, Math.Atan2(deltaDepth, lengthRadius) * (180.0 / Math.PI), Nothing)
        TxtRake.Text = rake?.ToString(STR_PARAM_DECIMAL_PLACES)
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub ChkScan_CheckedChanged(sender As Object, e As EventArgs) Handles ChkScan.CheckedChanged
        Try
            Scanning = ChkScan.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles CmdHome.Click
        HomeSet = True
        If HomeSet = False Then
            Exit Sub
        End If
        Try
            EncoderStatusStrip1.ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error homing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdSetTip_Click(sender As Object, e As EventArgs) Handles CmdSetTip.Click

    End Sub

    Private Sub CmdZero_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboPitchBasis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboPitchBasis.SelectedIndexChanged
        ShowPitchBasis()
    End Sub

    Private Sub ComboReferenceBlade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferenceBlade.SelectedIndexChanged
        Dim selrad As Integer = ComboReferenceRadius.SelectedIndex
        ComboReferenceRadius.DataSource = ReferenceRadiiGet(ComboReferenceBlade.SelectedValue).Order().ToList()
        If selrad <> 0 And selrad <= ComboReferenceRadius.Items.Count Then
            ComboReferenceRadius.SelectedIndex = selrad
        ElseIf ComboReferenceBlade.Items.Count = 0 Then
            ComboReferenceBlade.SelectedIndex = Nothing
        Else
            ComboReferenceRadius.SelectedIndex = 0
        End If
        ShowTrack()
    End Sub

    Private Sub ComboReferencePoint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferencePoint.SelectedIndexChanged
        ShowTrack()
    End Sub

    Private Sub ComboReferenceRadius_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboReferenceRadius.SelectedIndexChanged
        ShowTrack()
    End Sub

    Private Sub ComboTolerance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTolerance.SelectedIndexChanged
        SelectedTolerance = DirectCast(ComboTolerance.SelectedItem, Tolerance).ToleranceClass
        RefreshAll()
        ShowBladePlot()
    End Sub

    Private Sub DataGridJobDetails_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridJobDetails.MouseDoubleClick
        If Current IsNot Nothing Then
            ShowForm(gFrmReports, Database, User)
            gFrmReports.JobDetails = Current
        End If
    End Sub

    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles EncoderStatusStrip events so we can update our controls accordingly.
    End Sub

    Private Sub EncoderStatusStrip1_Load(sender As Object, e As EventArgs)
        mScanIncrement = EncoderStatusStrip1.Hardware.Workstation.ScanIncrement
    End Sub

    Protected Overrides Sub Form_Closing(sender As Object, e As FormClosingEventArgs)
        On Error Resume Next
        EncoderStatusStrip1.TimerOn = False
        DataGridJobDetails.EndEdit()
        DataGridJobDetails.DataSource = Nothing
        'JobDetailsBindingSource.SuspendBinding()
        MyBase.Form_Closing(sender, e)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize form controls. This method needs to initialize all form controls
            ' based on some predefined "states". For example: if no encoders are detected,
            ' they're not initialized or in an error state, then disable all controls that 
            ' can access the encoders. 
            Dim tolerances = Database.Tolerances.Local.ToList
            tolerances.Add(New Tolerance With {.ToleranceClass = "C"})
            ComboTolerance.DataSource = tolerances
            ComboTolerance.DisplayMember = "ToleranceClass"
            ComboTolerance.ValueMember = "ToleranceClass"
            ComboReferencePoint.DataSource = New List(Of String) From {"LE", "Mid", "TE"}
            ComboPitchBasis.DataSource = New List(Of String) From {"Mean", "Marked", "Desired"}

            Me.WindowState = FormWindowState.Maximized

            ' Initialize the DataGridJobDetails.
            DataGridJobDetails.AutoGenerateColumns = False
            'For Each emp As Employee In Database.Employees.Local.ToList()
            '    EmployeesBindingSource.Add(emp)
            'Next

            EmployeesBindingSource.DataSource = Database.Employees.Local.ToBindingList

            'For Each tolclass As Tolerance In Database.Tolerances.Local.ToList()
            '    ClassBindingSource.Add(tolclass)
            'Next
            ClassBindingSource.DataSource = Database.Tolerances.Local.ToBindingList
            'For Each mtype As MeasurementType In Database.MeasurementTypes.Local.ToList()
            '    MeasurementTypesBindingSource.Add(mtype)
            'Next
            MeasurementTypesBindingSource.DataSource = Database.MeasurementTypes.Local.ToBindingList

            ' Initialize the Navigator
            Navigator = RecordNavigationBar1
            Navigator.BoundControls = New List(Of Control) From {DataGridJobDetails}
            MasterSource = JobDetailsBindingSource

            ' EncoderStatusStrip1 handles the encoder hardware and its controls automatically. 
            ' It raises events notifying clients of anything relevant. These events can, for
            ' instance, be used to update this form's state and take periodic measurements.
            ' See Encoders_EncoderEvent() and ScanTimer_Tick() for examples.
            AddHandler EncoderStatusStrip1.Load, AddressOf EncoderStatusStrip1_Load
            AddHandler EncoderStatusStrip1.EncoderEvent, AddressOf Encoders_EncoderEvent
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
            AddHandler Navigator.NavigationEvent, AddressOf Navigator_NavigationEvent
            EncoderStatusStrip1.TimerOn = True
            ChkMinimumsApply.Checked = True
        Catch ex As Exception
            MessageBox.Show("Error loading measurements form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridComboTolerance_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub JobDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles JobDetailsBindingSource.AddingNew
        Try
            Dim newJobDetail As JobDetail = If(mNewJobDetail, CreateNewJobDetail())
            e.NewObject = newJobDetail
            Database.JobDetails.Add(newJobDetail)
        Catch ex As Exception
            MessageBox.Show("Error adding new job details record: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        If mJobDetails IsNot Current Then
            mJobDetails = Current
            If JobDetails IsNot Nothing Then
                ShowJobDetailsInfo()
            End If
        End If
    End Sub

    Private Sub Navigator_NavigationEvent(sender As Object, e As NavigationEventArgs)
        ' Handles Navigator events so we can update our controls accordingly.
        Select Case e.EventName
            Case "AddNew"
                ' Disable PanelMeasurements when the user is adding a new JobDetails record.
                PanelMeasurements.Enabled = False
                PanelGrids.Enabled = False
                PanelPlot.Enabled = False
                PanelTrack.Enabled = False
                PanelLocalPitchDetails.Enabled = False
            Case "Delete"
                If DeleteConfirm() Then
                    DeleteJobDetail()
                    RefreshAll()
                End If
            Case "Editing"
                ' Disable the PanelMeasurements when the user is editing the JobDetails record. 
                PanelMeasurements.Enabled = False
                PanelGrids.Enabled = False
                PanelPlot.Enabled = False
                PanelTrack.Enabled = False
                PanelLocalPitchDetails.Enabled = False
            Case "FilterOff"
            Case "FilterOn"
            Case "Find"
            Case "GotoFirst", "GotoNext", "GotoPrev"
            Case "GotoLast"
            Case "Save"
                ' Refresh any open database forms affected by our changes and enable PanelMeasurements.
                RefreshAll()
                PanelMeasurements.Enabled = True
                PanelGrids.Enabled = True
                PanelPlot.Enabled = True
                PanelTrack.Enabled = True
                PanelLocalPitchDetails.Enabled = True
                ChkScan.Select()
            Case "Undo"
                ' Enable the PanelMeasurements when the user has cancelled the JobDetails record changes.
                If Me.Current IsNot Nothing Then
                    ShowJobDetailsInfo()
                    PanelMeasurements.Enabled = True
                    PanelGrids.Enabled = True
                    PanelPlot.Enabled = True
                    PanelTrack.Enabled = True
                    PanelLocalPitchDetails.Enabled = True
                End If
            Case Else
                PanelMeasurements.Enabled = True
                PanelGrids.Enabled = True
                PanelPlot.Enabled = True
                PanelTrack.Enabled = True
                PanelLocalPitchDetails.Enabled = True
        End Select
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        Try
            If Scanning Then
                MeasurementsGet(mLastScannedAngle)
                If mSampleCount = kMaxSamplesPerScan Then Scanning = False
            Else
                MeasurementsGet()
            End If
        Catch ex As Exception
            Scanning = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtCustomer_DoubleClick(sender As Object, e As EventArgs) Handles TxtCustomer.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(gFrmCustomers, Database, User)
            gFrmCustomers.Find(Job?.Vessel?.Customer)
        End If
    End Sub

    Private Sub TxtJobNumber_DoubleClick(sender As Object, e As EventArgs) Handles TxtJobNumber.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(gFrmJobs, Database, User)
            gFrmJobs.Find(Job)
        End If
    End Sub
    Private Sub TxtManufacturer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TxtManufacturer.MouseDoubleClick
        If Job IsNot Nothing Then
            ShowForm(gFrmManufacturers, Database, User)
            gFrmManufacturers.Find(Job?.PropellerManufacturer)
        End If
    End Sub

    Private Sub TxtVessel_DoubleClick(sender As Object, e As EventArgs) Handles TxtVessel.DoubleClick
        If Job IsNot Nothing Then
            ShowForm(gFrmVessels, Database, User)
            gFrmVessels.Find(Job?.Vessel)
        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        EncoderStatusStrip1.TimerOn = True
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        EncoderStatusStrip1.TimerOn = False
    End Sub

    Private Sub ChkLocalPitch_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLocalPitch.CheckedChanged
        If ChkLocalPitch.Checked Then
            ChkLocalPitch.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            ChkLocalPitch.ForeColor = Color.DimGray
            LabTolLPS.ForeColor = Color.DimGray
            LabTolLPI.ForeColor = Color.DimGray
            LabTolLPII.ForeColor = Color.DimGray
            LabTolLPC.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub ChkMeanPitchRadius_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMeanPitchRadius.CheckedChanged
        If ChkMeanPitchRadius.Checked Then
            ChkMeanPitchRadius.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            LabTolMPRS.ForeColor = Color.DimGray
            LabTolMPRI.ForeColor = Color.DimGray
            LabTolMPRII.ForeColor = Color.DimGray
            LabTolMPRIII.ForeColor = Color.DimGray
            LabTolMPRC.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub ChkMeanPitchBlade_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMeanPitchBlade.CheckedChanged
        If ChkMeanPitchBlade.Checked Then
            ChkMeanPitchBlade.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            LabTolMPBS.ForeColor = Color.DimGray
            LabTolMPBI.ForeColor = Color.DimGray
            LabTolMPBII.ForeColor = Color.Black
            LabTolMPBIII.ForeColor = Color.Black
            LabTolMPBC.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub ChkMeanPitchPropeller_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMeanPitchPropeller.CheckedChanged
        If ChkMeanPitchPropeller.Checked Then
            ChkMeanPitchPropeller.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            LabTolMPPS.ForeColor = Color.DimGray
            LabTolMPPI.ForeColor = Color.DimGray
            LabTolMPPII.ForeColor = Color.DimGray
            LabTolMPPIII.ForeColor = Color.DimGray
            LabTolMPPC.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub ChkAngularDeviation_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAngularDeviation.CheckedChanged
        If ChkAngularDeviation.Checked Then
            ChkAngularDeviation.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            LabTolADS.ForeColor = Color.DimGray
            LabTolADI.ForeColor = Color.DimGray
            LabTolADII.ForeColor = Color.DimGray
            LabTolADIII.ForeColor = Color.DimGray
            LabTolADC.ForeColor = Color.Black
        End If
    End Sub
    Private Sub ChkAxialPosition_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAxialPosition.CheckedChanged
        If ChkAxialPosition.Checked Then
            ChkAxialPosition.ForeColor = Color.White
            ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
        Else
            LabTolAPS.ForeColor = Color.DimGray
            LabTolAPI.ForeColor = Color.DimGray
            LabTolAPII.ForeColor = Color.DimGray
            LabTolAPIII.ForeColor = Color.DimGray
            LabTolAPC.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub CmdSetRef_Click(sender As Object, e As EventArgs) Handles CmdSetRef.Click
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim refcell As New ReferenceCell
        mJobDetails.ReferenceCell = refcell
        Dim userInput As String = InputBox("Describe where the Reference is being taken from (e.g. 'Leading Edge at 70 Radius on Blade 1'):", "Reference Set")
        mJobDetails.ReferenceCell.ReferenceDescription = userInput
        mJobDetails.ReferenceCell.ReferenceRadius = Double.Parse(TxtRadius.Text.Remove(TxtRadius.Text.IndexOf(CType(" ", Char))))
        mJobDetails.ReferenceCell.ReferenceAngle = Double.Parse(TxtAngle.Text.Remove(TxtAngle.Text.IndexOf(CType(" ", Char))))
        mJobDetails.ReferenceCell.ReferenceDepth = Double.Parse(TxtDepth.Text.Remove(TxtDepth.Text.IndexOf(CType(" ", Char))))
        Database.SaveChanges()
    End Sub

    Private Sub CmdGetRef_Click(sender As Object, e As EventArgs) Handles CmdGetRef.Click
        If mJobDetails Is Nothing Then
            Return
        End If
        Dim res As DialogResult = MessageBox.Show("This will set the encoder counts to the Reference Cell values. The reference point was recorded at " + mJobDetails.ReferenceCell.ReferenceDescription, "Reference Point", MessageBoxButtons.OKCancel)
        If res = DialogResult.Cancel Then
            Return
        End If
        'resetting counts is multiplying by calibrations
        Dim refRadius As Double = mJobDetails.ReferenceCell.ReferenceRadius
        Dim refAngle As Double = mJobDetails.ReferenceCell.ReferenceAngle
        Dim refDepth As Double = mJobDetails.ReferenceCell.ReferenceDepth

        If Math.Round(refRadius) <> Math.Round(Double.Parse(TxtRadius.Text.Remove(TxtRadius.Text.IndexOf(CType(" ", Char))))) Then
            Hardware.Encoders.SetEncoderCount(1, CInt(refRadius * Hardware.Encoders.RadiusCalibration))
        End If
        If Math.Round(refAngle) <> Math.Round(Double.Parse(TxtAngle.Text.Remove(TxtAngle.Text.IndexOf(CType(" ", Char))))) Then
            Hardware.Encoders.SetEncoderCount(0, CInt(refAngle * Hardware.Encoders.AngleCalibration))
        End If
        If Math.Round(refDepth) <> Math.Round(Double.Parse(TxtDepth.Text.Remove(TxtDepth.Text.IndexOf(CType(" ", Char))))) Then
            Hardware.Encoders.SetEncoderCount(2, CInt(refDepth * Hardware.Encoders.DepthCalibration))
        End If
    End Sub

    Private Sub CmdComparisonForm_Click(sender As Object, e As EventArgs) Handles CmdComparisonForm.Click
        If Current IsNot Nothing Then
            ShowForm(gFrmComparison, Database, User)
            gFrmComparison.JobDetails = Current
        End If
    End Sub

    Private Sub FrmMeasurements_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Dim halfheight As Integer = CInt((chartPlot.Width - chartPlot.Height) / 2)
        chartPlot.Margin = New Padding(halfheight, 0, halfheight, 0)
    End Sub

    Private Sub FrmMeasurements_StyleChanged(sender As Object, e As EventArgs) Handles MyBase.StyleChanged
        Dim halfheight As Integer = CInt((chartPlot.Width - chartPlot.Height) / 2)
        chartPlot.Margin = New Padding(halfheight, 0, halfheight, 0)
    End Sub

    Private Sub ChkPlotAngularDeviation_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPlotAngularDeviation.CheckedChanged
        ShowBladePlot()
    End Sub

    Private Sub ChkMinimumsApply_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMinimumsApply.CheckedChanged
        MinsApply = ChkMinimumsApply.Checked
    End Sub

    Private Sub CmdPrintClassS_Click(sender As Object, e As EventArgs) Handles CmdPrintClassS.Click
        Dim inspect As New FrmInspect(JobDetails, GetToleranceTable(Database, "S"), ComboPitchBasis.Text, ChkAllowProgPitch.Checked, MinsApply)
        inspect.Show()
    End Sub

    Private Sub CmdPrintClassI_Click(sender As Object, e As EventArgs) Handles CmdPrintClassI.Click
        Dim inspect As New FrmInspect(JobDetails, GetToleranceTable(Database, "I"), ComboPitchBasis.Text, ChkAllowProgPitch.Checked, MinsApply)
        inspect.Show()
    End Sub

    Private Sub CmdPrintClassII_Click(sender As Object, e As EventArgs) Handles CmdPrintClassII.Click
        Dim inspect As New FrmInspect(JobDetails, GetToleranceTable(Database, "II"), ComboPitchBasis.Text, ChkAllowProgPitch.Checked, MinsApply)
        inspect.Show()
    End Sub

    Private Sub CmdPrintClassIII_Click(sender As Object, e As EventArgs) Handles CmdPrintClassIII.Click
        Dim inspect As New FrmInspect(JobDetails, GetToleranceTable(Database, "III"), ComboPitchBasis.Text, ChkAllowProgPitch.Checked, MinsApply)
        inspect.Show()
    End Sub

    Private Sub CmdPrintClassCustom_Click(sender As Object, e As EventArgs) Handles CmdPrintClassCustom.Click

    End Sub

    Private Sub ChkAllowProgPitch_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAllowProgPitch.CheckedChanged
        ShowBladePlot()
        ShowBladePitch(True)
        ShowTolerances(MinsApply, ChkAllowProgPitch.Checked)
    End Sub

#End Region
End Class