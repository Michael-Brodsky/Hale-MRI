Imports System.ComponentModel
Imports Hale_MRI.EncoderStatusStrip
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
Imports Microsoft.EntityFrameworkCore

''' <summary>
''' This form provides a user inteface for taking, 
''' computing, saving, displaying and inserting 
''' blade measurements.
''' </summary>
Public Class FrmMeasurements
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mRadiusPercent As New MovingAverage(2)              ' Keeps a moving average of RadiusPercent measurements during a scan.
    Private mRadiusMeasurement As RadiusMeasurement = Nothing   ' Stores the RadiusMeasurement to which CellMeasurements collected during a scan are assigned to. 
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Property Hardware As WorkstationEncoders
        Get
            Return EncoderStatusStrip1.Hardware
        End Get
        Set(value As WorkstationEncoders)
            ' Assigns the given value to EncoderStatusStrip1, retrieves and assigns
            ' the scan sampling rate from the database and, if not already,
            ' intializes the encoder hardware.
            With EncoderStatusStrip1
                .Hardware = value
                If .Hardware IsNot Nothing Then
                    EncoderStatusStrip1.TimerInterval = Integer.Parse(SettingsGet(Database, STR_SETTING_ENCODER_DEFAULT_SAMPLE_PERIOD))
                    If .Hardware.Encoders IsNot Nothing AndAlso Not .Hardware.Encoders.Initialized Then EncoderStatusStrip1.Initialize()
                End If
            End With
        End Set
    End Property

    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            ' Loads all of the given Job's JobDetails and their Cell, Extreme and RadiusMeasurements.
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) _
                    (Database.JobDetails _
                        .Where(Function(jd) jd.Job Is mJob) _
                        .OrderBy(Function(jd) jd.StartDate) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(cm) cm.CellMeasurements) _
                        .Include(Function(jd) jd.RadiusMeasurements) _
                        .ThenInclude(Function(em) em.ExtremeMeasurements) _
                        .AsSplitQuery().ToList()
                    )
            End If
            Debug.Print(JobDetailsBindingSource.Count)
        End Set
    End Property

    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            ' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) _
                    (Database.JobDetails _
                    .Where(Function(jd) jd Is mJobDetails) _
                    .Include(Function(rm) rm.RadiusMeasurements) _
                    .ThenInclude(Function(m) m.CellMeasurements) _
                    .Include(Function(rm) rm.RadiusMeasurements) _
                    .ThenInclude(Function(m) m.ExtremeMeasurements) _
                    .AsSplitQuery().ToList()
                )
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"

    '    Private Sub Scan(ScanRadius As Double, ScanBlade As Integer, ScanAngle As Double) ' Scans   a single blade radius, Function completion relies on correct operation of the hardware
    '        'Input radius as a percentage to ensure accurate storage in the database
    '        If Database IsNot Nothing Then
    '            Dim BladeIDs As New List(Of Integer?)
    '            Dim Radii As New List(Of Double?)
    '            Dim LECells As New List(Of Integer?)
    '            Dim TECells As New List(Of Integer?)
    '            Dim Angles As New List(Of Double?)
    '            Dim Depths As New List(Of Double?)
    '            Dim angleMeasurement As Double = 0
    '            Dim depthMeasurement As Double = 0
    '            If Database IsNot Nothing Then
    '                ' Get the existing radius measurements for the current job details
    '                For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
    '                    BladeIDs.Add(bladID)
    '                Next
    '                For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
    '                    Radii.Add(Rad)
    '                Next
    '                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
    '                    LECells.Add(integ)
    '                Next
    '                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
    '                    TECells.Add(integ)
    '                Next
    '                For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
    '                    Angles.Add(Ange)
    '                Next
    '                For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
    '                    Depths.Add(Dept)
    '                Next
    '            End If
    '            Dim AngleArray As Double() = New Double(0) {}
    '            Dim DepthArray As Double() = New Double(0) {}
    '            Dim n As Integer = 1
    '            Dim pointtotal As Integer = (360 / Job.PropellerBlades)
    '            Dim ScanIncrement As Double = 360 * Hardware.Workstation.ScanIncrement / Hardware.Workstation.AngleResolution 'This is the increment in degrees for each scan point
    '            TxtStatus.Text = "Scanning Blade " & ScanBlade.ToString() & " at " & ScanRadius.ToString() & "% Radius"
    '            If ScanRadius < 0 Or ScanRadius > 100 Then
    '                MessageBox.Show("Invalid radius value. Please scan a radius between 0 and 100.", "Invalid Radius", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                TxtStatus.Text = "Idle"
    '                Return
    '            End If
    '            With EncoderStatusStrip1
    '                angleMeasurement = AngleArray(0) = .Angle()
    '                depthMeasurement = DepthArray(0) = .Depth
    '            End With
    '            For n = 1 To pointtotal
    '                While angleMeasurement > Int((AngleArray(n - 1) + ScanIncrement) / ScanIncrement + 0.5) / ScanIncrement
    '                    'If Scanning = False Then
    '                    'GoTo exittheFor
    '                    'End If
    '                    txtAngle.Text = angleMeasurement.ToString()
    '                    txtDepth.Text = depthMeasurement.ToString()
    '                    System.Threading.Thread.Sleep(5)
    '                End While

    '                If angleMeasurement < 180 And ScanBlade = 1 Then
    '                    AngleArray(n) = angleMeasurement - 360
    '                Else
    '                    AngleArray(n) = angleMeasurement
    '                End If
    '                DepthArray(n) = depthMeasurement
    '            Next
    'exittheFor:
    '            If angleMeasurement > 180 And ScanBlade = 1 Then
    '                AngleArray(n) = angleMeasurement - 360
    '            Else
    '                AngleArray(n) = angleMeasurement
    '            End If
    '            DepthArray(n) = depthMeasurement
    '            'timerMeasurements.Enabled = True
    '            'Need to add a check for duplicate radius measurements for the same blade and radius so we can remove old data
    '            ' Save the measurements to the database
    '            Dim needdelete As Boolean = False
    '            Dim celltotal As Integer = 0
    '            Dim x As Integer = 0
    '            For Each bladID In BladeIDs
    '                If bladID.Value = ScanBlade And Math.Round(Radii(x).Value) = Math.Round(ScanRadius) Then
    '                    needdelete = True
    '                    x += 1
    '                    Exit For
    '                End If
    '                Dim lecell As Integer = LECells(x).Value
    '                Dim tecell As Integer = TECells(x).Value
    '                celltotal += tecell - lecell + 1 ' + 1 to include the cell stated by the actual values
    '                x += 1
    '            Next
    '            If needdelete = True Then
    '                ' Remove existing measurements for this blade and radius
    '                Dim existingRadiusMeasurements = Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id And r.BladeId = ScanBlade And Math.Round(r.Radius.Value) = Math.Round(ScanRadius)).ToList()
    '                For Each rdsm In existingRadiusMeasurements
    '                    Database.RadiusMeasurements.Remove(rdsm)
    '                Next
    '                Dim existingCellMeasurements = Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Skip(celltotal).ToList()
    '                Dim y As Integer = 0
    '                Dim lecell As Integer = LECells(x).Value
    '                Dim tecell As Integer = TECells(x).Value
    '                Dim cellsToRemove As Integer = tecell - lecell + 1
    '                For Each cm In existingCellMeasurements
    '                    If y >= (cellsToRemove) Then
    '                        Exit For
    '                    End If
    '                    Database.CellMeasurements.Remove(cm)
    '                    y += 1
    '                Next
    '                Database.SaveChanges()
    '            End If
    '            Dim rm As New RadiusMeasurement With {
    '                .JobDetailsId = JobDetails.Id,
    '                .BladeId = ScanBlade,
    '                .Radius = Math.Round(ScanRadius, 2),
    '                .LeCell = 0,
    '                .TeCell = AngleArray.Length()
    '            }
    '            For x = 0 To AngleArray.Length - 1
    '                Dim cm As New CellMeasurement With {
    '                    .JobDetailsId = JobDetails.Id,
    '                    .Angle = AngleArray(x),
    '                    .Depth = DepthArray(x)
    '                }
    '            Next
    '        End If
    '    End Sub
    '    Private Function GetPitchofBladeRadius(Blade As Integer, Radius As Double) As Double()
    '        Dim PitchArray As Double() = {0}
    '        If Database IsNot Nothing Then
    '            Dim BladeIDs As New List(Of Integer?)
    '            Dim Radii As New List(Of Double?)
    '            Dim LECells As New List(Of Integer?)
    '            Dim TECells As New List(Of Integer?)
    '            Dim Angles As New List(Of Double?)
    '            Dim Depths As New List(Of Double?)
    '            For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
    '                BladeIDs.Add(bladID)
    '            Next
    '            For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
    '                Radii.Add(Rad)
    '            Next
    '            For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
    '                LECells.Add(integ)
    '            Next
    '            For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
    '                TECells.Add(integ)
    '            Next
    '            For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
    '                Angles.Add(Ange)
    '            Next
    '            For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
    '                Depths.Add(Dept)
    '            Next

    '            Dim celltotal As Integer = 0
    '            Dim x As Integer = 0
    '            For Each bladID In BladeIDs
    '                If bladID.Value = Blade And Math.Round(Radii(x).Value) = Math.Round(Radius) Then
    '                    x += 1
    '                    Exit For
    '                End If
    '                Dim lecell As Integer = LECells(x).Value
    '                Dim tecell As Integer = TECells(x).Value
    '                celltotal += tecell - lecell + 1 ' + 1 to include the cell stated by the actual values
    '                x += 1
    '            Next
    '            Dim celldiff As Integer = TECells(x).Value - LECells(x).Value
    '            For x = 0 To celldiff - 1
    '                Dim angle1 As Double = Angles(celltotal + x).GetValueOrDefault()
    '                Dim depth1 As Double = Depths(celltotal + x).GetValueOrDefault()
    '                Dim angle2 As Double = Angles(celltotal + x + 1).GetValueOrDefault()
    '                Dim depth2 As Double = Depths(celltotal + x + 1).GetValueOrDefault()
    '                Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
    '                PitchArray(x) = pitch
    '            Next

    '        End If
    '        Return PitchArray
    '    End Function
    '    Private ReadOnly Property PitchofRadiusSegments As Double()
    '        Get
    '            ' This property calculates the average pitch for each radius segment based on the radius measurements and cell measurements. It returns an array of average Pitch Values
    '            Dim pitcharray As Double() = {0}
    '            If Database IsNot Nothing Then

    '                Dim BladeIDs As New List(Of Integer?)
    '                Dim Radii As New List(Of Double?)
    '                Dim LECells As New List(Of Integer?)
    '                Dim TECells As New List(Of Integer?)
    '                Dim Angles As New List(Of Double?)
    '                Dim Depths As New List(Of Double?)
    '                For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
    '                    BladeIDs.Add(bladID)
    '                Next
    '                For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
    '                    Radii.Add(Rad)
    '                Next
    '                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
    '                    LECells.Add(integ)
    '                Next
    '                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
    '                    TECells.Add(integ)
    '                Next
    '                For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
    '                    Angles.Add(Ange)
    '                Next
    '                For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
    '                    Depths.Add(Dept)
    '                Next
    '                Dim PitchbyBladeRadius = New Double(BladeIDs.Count) {}

    '                Dim cellcount As Integer = 0
    '                For i = 0 To BladeIDs.Count - 1
    '                    Dim bladid = BladeIDs(i)
    '                    Dim bladeIndex As Integer = bladid - 1
    '                    Dim radius As Double = Radii(i).GetValueOrDefault()
    '                    Dim leCell As Integer = LECells(i).GetValueOrDefault()
    '                    Dim teCell As Integer = TECells(i).GetValueOrDefault()
    '                    Dim celldiff As Integer = teCell - leCell + cellcount

    '                    Dim totalpitch As Double = 0
    '                    Dim pitchcount As Integer = 0
    '                    For x = cellcount To celldiff - 1
    '                        Dim angle1 As Double = Angles(x).GetValueOrDefault()
    '                        Dim depth1 As Double = Depths(x).GetValueOrDefault()
    '                        Dim angle2 As Double = Angles(x + 1).GetValueOrDefault()
    '                        Dim depth2 As Double = Depths(x + 1).GetValueOrDefault()
    '                        Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
    '                        totalpitch += pitch
    '                        pitchcount += 1
    '                    Next
    '                    If pitchcount > 0 Then
    '                        Dim averagePitch As Double = Math.Round(totalpitch / pitchcount, 2)
    '                        PitchbyBladeRadius(i) = averagePitch
    '                    End If
    '                Next
    '                pitcharray = PitchbyBladeRadius
    '                Return pitcharray
    '            End If

    '            Return pitcharray
    '        End Get
    '    End Property
    '    Private Sub UpdateBladeRadiusPlot(BladeNum As Integer, RadiusPerc As Double)
    '        'Updates a single blade and radius in the plot graph
    '        'Dim PitchArray As Double() = GetPitchofBladeRadius(BladeNum, RadiusPerc)

    '    End Sub

    '    Private Sub UpdatePitchByRadiusTableFull()
    '        'need to implement a method to check the table for existing data and clear or update if necessary
    '        While GridBladebyRadius.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 1
    '            GridBladebyRadius.Columns.RemoveAt(GridBladebyRadius.Columns.Count - 1) 'remove all but the blade column
    '        End While
    '        GridBladebyRadius.Rows.Clear() 'remove all rows
    '        If Database IsNot Nothing Then
    '            Dim BladeIDs As New List(Of Integer?) 'Commented out sections have been moved to the PitchofRadiusSegments property as it will be used in multiple places
    '            Dim Radii As New List(Of Double?)
    '            'Dim LECells As New List(Of Integer?)
    '            'Dim TECells As New List(Of Integer?)
    '            'Dim Angles As New List(Of Double?)
    '            'Dim Depths As New List(Of Double?)

    '            'Database.RadiusMeasurements.OrderBy(Of Integer)(Function(r) r.BladeId).Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Where(Function(r) r.BladeId).ToList()

    '            Dim colBladeIDS As New List(Of Integer?)
    '            Dim colRadii As New List(Of Double?)
    '            For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
    '                BladeIDs.Add(bladID)
    '            Next
    '            For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
    '                Radii.Add(Rad)
    '            Next
    '            For Each BladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).OrderBy(Function(r) r.Radius).Distinct.ToList()
    '                colBladeIDS.Add(BladID.BladeId)
    '                colRadii.Add(BladID.Radius)
    '            Next


    '            'For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
    '            '    LECells.Add(integ)
    '            'Next
    '            'For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
    '            '    TECells.Add(integ)
    '            'Next
    '            'For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
    '            '    Angles.Add(Ange)
    '            'Next
    '            'For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
    '            '    Depths.Add(Dept)
    '            'Next

    '            'Dim cellcount As Integer = 0
    '            'For i = 0 To BladeIDs.Count - 1
    '            '    Dim bladid = BladeIDs(i)
    '            '    Dim bladeIndex As Integer = bladid - 1
    '            '    Dim radius As Double = Radii(i).GetValueOrDefault()
    '            '    Dim leCell As Integer = LECells(i).GetValueOrDefault()
    '            '    Dim teCell As Integer = TECells(i).GetValueOrDefault()
    '            '    Dim celldiff As Integer = teCell - leCell + cellcount

    '            '    Dim totalpitch As Double = 0
    '            '    Dim pitchcount As Integer = 0
    '            '    For x = cellcount To celldiff - 1
    '            '        Dim angle1 As Double = Angles(x).GetValueOrDefault()
    '            '        Dim depth1 As Double = Depths(x).GetValueOrDefault()
    '            '        Dim angle2 As Double = Angles(x + 1).GetValueOrDefault()
    '            '        Dim depth2 As Double = Depths(x + 1).GetValueOrDefault()
    '            '        Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
    '            '        totalpitch += pitch
    '            '        pitchcount += 1
    '            '    Next
    '            '    If pitchcount > 0 Then
    '            '        Dim averagePitch As Double = Math.Round(totalpitch / pitchcount, 2)
    '            '        PitchbyBladeRadius(i) = averagePitch
    '            '    End If
    '            'Next

    '            Dim PitchbyBladeRadius As Double() = PitchofRadiusSegments
    '            Dim radcountlist = colBladeIDS.FindAll(Function(b) b = 1)
    '            Dim Raditerator = 0

    '            While GridBladebyRadius.Columns.GetColumnCount(DataGridViewElementStates.Visible) - 1 < radcountlist.Count
    '                Dim Radius As Double = colRadii(Raditerator).Value
    '                Radius = Math.Round(Radius, 0)
    '                GridBladebyRadius.Columns.Add(Radius.ToString(), Radius & "%")
    '                Raditerator += 1
    '            End While

    '            While GridBladebyRadius.Rows.Count < Job.PropellerBlades
    '                GridBladebyRadius.Rows.Add()
    '            End While
    '            For Each row In GridBladebyRadius.Rows
    '                GridBladebyRadius.Rows(row.Index).Cells(0).Value = row.Index + 1
    '            Next
    '            Raditerator = 0
    '            For i = 0 To BladeIDs.Count - 1
    '                Dim Bindex As Integer = BladeIDs(i) - 1
    '                GridBladebyRadius.Rows(Bindex).Cells(Math.Round(Radii(i).Value, 0).ToString()).Value = PitchbyBladeRadius(i)
    '                Raditerator += 1
    '            Next
    '            GridBladebyRadius.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)

    '        End If
    '    End Sub

    '#End Region
    '#Region "UI Event Handlers"
    '    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles cmdHome.Click
    '        HomeEncoders()
    '    End Sub
    '    Private Sub CmdStopScan_Click(sender As Object, e As EventArgs)
    '    End Sub
    '    Private Sub CountUpdate_Tick(sender As Object, e As EventArgs)
    '        'UpdateFields()
    '    End Sub

    '    Private Sub CmdStartScan_Click(sender As Object, e As EventArgs)


    '    End Sub

    '    'Private Sub ChkMeasurements_CheckedChanged(sender As Object, e As EventArgs) Handles chkMeasurements.CheckedChanged
    '    '    Dim dp = New DataVisualization.Charting.DataPoint(0.5, 0.5)
    '    '    Dim dp2 = New DataVisualization.Charting.DataPoint(0.5, 0)
    '    '    Dim dp3 = New DataVisualization.Charting.DataPoint(0.5, -0.5)
    '    '    PlotGraph.Series(0).Points.Add(dp2)
    '    '    PlotGraph.Series(1).Points.Add(dp)
    '    '    PlotGraph.Series(2).Points.Add(dp3)
    '    '    Try
    '    '        'timerMeasurements.Enabled = chkMeasurements.Checked
    '    '        cmdHome.Enabled = Not chkMeasurements.Checked
    '    '    Catch ex As Exception
    '    '        MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
    '    '    End Try
    '    '    Try
    '    '        UpdatePitchByRadiusTableFull()
    '    '    Catch ex As Exception
    '    '        MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
    '    '    End Try
    '    'End Sub
    '#End Region
    '#Region "NEW PRIVATE INTERFACE"
    '    Private Sub HomeEncoders()
    '        ' Resets all encoders and updates the form state accordingly.
    '        EncoderStatusStrip1.ResetAll()
    '        cmdHome.Enabled = False
    '    End Sub
#End Region
#Region "NEW PRIVATE INTERFACE"
    Protected Overrides Property MasterSource As BindingSource

    Private Sub MeasurementsGet()
        ' Calls encoder angle, depth and radius methods ONCE, and uses the returned
        ' values as required.
        With EncoderStatusStrip1
            Dim angle As Double = .Angle()
            Dim depth As Double = .Depth()
            Dim radius As IEncoderHardware.RadiusMeasurement = .Radius(Job.PropellerDiameter)
            Dim blade As Integer = GetBladeNumber(angle, Job.PropellerBlades)
            txtBlade.Text = blade
            txtAngle.Text = angle.ToString()
            txtRadius.Text = radius.Value.ToString()
            txtDepth.Text = depth.ToString()
            txtRadiusPercent.Text = (radius.Value * 100).ToString()
            MeasurementsSave(angle, depth, radius)
        End With
    End Sub

    Private Sub MeasurementsSave(ByVal angle As Double, ByVal depth As Double, ByVal radius As IEncoderHardware.RadiusMeasurement)
        ' Updates the RadiusPercent moving average and saves the given angle and depth measurements.
        mRadiusPercent.Input(radius.Value)
        Dim cm As New CellMeasurement With {
            .RadiusMeasurement = mRadiusMeasurement,
            .Angle = angle,
            .Depth = depth
        }
        Database.CellMeasurements.Add(cm)
    End Sub

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
            .TeCell = RadiusMeasurementsBindingSource.Count + 1
        }
        Database.RadiusMeasurements.Add(mRadiusMeasurement)
    End Sub

    Private Sub SaveRadiusMeasurement()
        ' Update and save the current RadiusMeasurement with the moving average
        ' we collected while scanning.
        mRadiusMeasurement.Radius = mRadiusPercent.Output()
        mRadiusMeasurement.BladeId = Integer.Parse(txtBlade.Text)
        ShowBladePitchByRadiusPercent(True)
    End Sub

    Private Sub ScanStart()
        NewRadiusMeasurement()
        EncoderStatusStrip1.TimerOn = True
    End Sub

    Private Sub ScanStop()
        EncoderStatusStrip1.TimerOn = False
        SaveRadiusMeasurement()
    End Sub

    Private Sub ShowBladePitchByRadiusPercent(ByVal show As Boolean)
        ' Displays each blade's average pitch by radius percent in the
        ' data grid. Each distinct blade creates a new row and each
        ' distinct radius percent creates a new column.
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("Blade", GetType(Integer))
        Dim rowBlade As DataRow
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.OrderBy(Function(b) b.BladeId)
            Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString("F2")   ' Round radiusPercent to nearest whole number (1%).
            rowBlade = If(dtBladePitchByRadius.Rows.Find(rm.BladeId), dtBladePitchByRadius.Rows.Add(rm.BladeId))
            colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
            rowBlade.Item(colRadius) = GetAverageBladePitch(rm.CellMeasurements.ToList())
        Next
        GridBladebyRadius.DataSource = dtBladePitchByRadius
    End Sub
#End Region
#Region "NEW EVENT HANDLERS"
    Private Sub ChkMeasurements_CheckedChanged(sender As Object, e As EventArgs) Handles chkMeasurements.CheckedChanged
        Try
            If chkMeasurements.Checked Then
                ScanStart()
            Else
                ScanStop()
            End If
            cmdHome.Enabled = Not chkMeasurements.Checked
        Catch ex As Exception
            EncoderStatusStrip1.TimerOn = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub CmdZero_Click(sender As Object, e As EventArgs) Handles cmdZero.Click
        ' Zeroes the encoders.
        Try
            EncoderStatusStrip1.ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error zeroing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Encoders_EncoderEvent(sender As Object, e As EncoderEventArgs)
        ' Handles encoder hardware events so we can update our controls accordingly.
        Select Case e.EventName
            Case "Error", "NoEncoders", "NotInitialized"
                ' Place the form controls in a state that disables any encoder calls, 
                ' e.g. start/stop scanning, home, etc. EncoderStatusStrip1 provides
                ' a control to intialize the encoders.

                chkMeasurements.Checked = False ' Stop scanning, lest ye create a domino effect of cascading exceptions :)

            Case "Ready"
                ' This event is raised after successful completion of any encoder call.
                ' It can be used to enable form controls as appropriate. When scanning,
                ' it only needs to be checked once, after the last encoder call returns.
                ' A simply way is to enclose any code in an IF block:

                If Not EncoderStatusStrip1.TimerOn Then
                    ' Do Something
                End If

            Case "Busy"
                ' This event is raised at the start of any encoder call. It can be 
                ' useful in cases where a call doesn't return immediately (there's
                ' some lag) to prevent users from continuously clicking a button
                ' when all they needed was to be patient.
            Case Else
        End Select
    End Sub

    Private Sub FrmMeasurements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize form controls. This method needs to initialize all form controls
            ' based on some predefined "states". For example: if no encoders are detected,
            ' they're not initialized or in an error state, then disable all controls that 
            ' can access the encoders. 

            PlotGraph.Series(0).Color = Color.Green
            PlotGraph.Series(1).Color = Color.Red
            PlotGraph.Series(2).Color = Color.Blue

            ' EncoderStatusStrip1 handles the encoder hardware and its controls automatically. 
            ' It raises events notifying clients of anything relevant. These events can, for
            ' instance, be used to update this form's state and take periodic measurements.
            ' See Encoders_EncoderEvent() and ScanTimer_Tick() for examples.
            AddHandler EncoderStatusStrip1.EncoderEvent, AddressOf Encoders_EncoderEvent
            AddHandler EncoderStatusStrip1.Timer.Tick, AddressOf ScanTimer_Tick
        Catch ex As Exception
            MessageBox.Show("Error loading the form: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        ' This event fires anytime the user selects a new JobDetails record (Intial, Interim, Final, etc.)
        ' For now it just keeps the form's JobDetails property current.
        mJobDetails = Me.Current

        ' Show any existing data for the current JobDeatils record.
        If mJobDetails IsNot Nothing Then ShowBladePitchByRadiusPercent(True)
    End Sub

    Private Sub ScanTimer_Tick(sender As Object, e As EventArgs)
        ' This event fires on each EncoderStatusStrip1 timer tick and gets the next set of measurements from the encoders.
        Try
            MeasurementsGet()
        Catch ex As Exception
            chkMeasurements.Checked = False
            MessageBox.Show("Error getting measurements from the encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class