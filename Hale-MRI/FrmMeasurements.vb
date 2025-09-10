Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibEncoder
Imports LibEncoder.USDigital
Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel

''' <summary>
''' This form provides a user inteface for taking
''' and inserting measurements into JobDetail records.
''' </summary>

Public Class FrmMeasurements
    Inherits FrmDatabaseForm
#Region "Constants"

#End Region
#Region "Private Members"
    Private mBlades As Integer
    Private mHardware As WorkstationEncoders
    Private mJobDetails As JobDetail
    Private mJob As Job
    Private Scanning As Boolean
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return mJobDetails
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Property Hardware As WorkstationEncoders
        Get
            Return mHardware
        End Get
        Set(value As WorkstationEncoders)
            mHardware = value
        End Set
    End Property
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
        End Set
    End Property

    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            If value IsNot Nothing Then
                mJobDetails = value
                Job = mJobDetails.Job
                If mJobDetails IsNot Nothing Then
                    JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) From {mJobDetails}.ToList()
                    BindMasterDetails(JobDetailsBindingSource, CellMeasurementsBindingSource, "CellMeasurements")
                    BindMasterDetails(JobDetailsBindingSource, ExtremeMeasurementsBindingSource, "ExtremeMeasurements")
                    BindMasterDetails(JobDetailsBindingSource, RadiusMeasurementBindingSource, "RadiusMeasurements")
                End If
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"

    Private Sub Scan(ScanRadius As Double, ScanBlade As Integer, ScanAngle As Double) ' Scans   a single blade radius, Function completion relies on correct operation of the hardware
        'Input radius as a percentage to ensure accurate storage in the database
        If Database IsNot Nothing Then
            Dim BladeIDs As New List(Of Integer?)
            Dim Radii As New List(Of Double?)
            Dim LECells As New List(Of Integer?)
            Dim TECells As New List(Of Integer?)
            Dim Angles As New List(Of Double?)
            Dim Depths As New List(Of Double?)
            If Database IsNot Nothing Then
                ' Get the existing radius measurements for the current job details
                For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
                    BladeIDs.Add(bladID)
                Next
                For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
                    Radii.Add(Rad)
                Next
                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
                    LECells.Add(integ)
                Next
                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
                    TECells.Add(integ)
                Next
                For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
                    Angles.Add(Ange)
                Next
                For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
                    Depths.Add(Dept)
                Next
            End If
            Dim AngleArray As Double() = New Double(0) {}
            Dim DepthArray As Double() = New Double(0) {}
            Dim n As Integer = 1
            Dim pointtotal As Integer = (360 / Job.PropellerBlades)
            Dim ScanIncrement As Double = 360 * Hardware.Workstation.ScanIncrement / Hardware.Workstation.AngleResolution 'This is the increment in degrees for each scan point
            TxtStatus.Text = "Scanning Blade " & ScanBlade.ToString() & " at " & ScanRadius.ToString() & "% Radius"
            If ScanRadius < 0 Or ScanRadius > 100 Then
                MessageBox.Show("Invalid radius value. Please scan a radius between 0 and 100.", "Invalid Radius", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtStatus.Text = "Idle"
                Return
            End If
            With Hardware.Encoders
                AngleArray(0) = .Angle()
                DepthArray(0) = .Depth()
                For n = 1 To pointtotal
                    While .Angle() > Int((AngleArray(n - 1) + ScanIncrement) / ScanIncrement + 0.5) / ScanIncrement
                        If Scanning = False Then
                            GoTo exittheFor
                        End If
                        txtAngle.Text = .Angle().ToString()
                        txtDepth.Text = .Depth().ToString()
                        System.Threading.Thread.Sleep(5)
                    End While

                    If .Angle() < 180 And ScanBlade = 1 Then
                        AngleArray(n) = .Angle() - 360
                    Else
                        AngleArray(n) = .Angle()
                    End If
                    DepthArray(n) = .Depth()
                Next
exittheFor:
                If .Angle() > 180 And ScanBlade = 1 Then
                    AngleArray(n) = .Angle() - 360
                Else
                    AngleArray(n) = .Angle()
                End If
                DepthArray(n) = .Depth()
                timerMeasurements.Enabled = True
                'Need to add a check for duplicate radius measurements for the same blade and radius so we can remove old data
                ' Save the measurements to the database
                Dim needdelete As Boolean = False
                Dim celltotal As Integer = 0
                Dim x As Integer = 0
                For Each bladID In BladeIDs
                    If bladID.Value = ScanBlade And Math.Round(Radii(x).Value) = Math.Round(ScanRadius) Then
                        needdelete = True
                        x += 1
                        Exit For
                    End If
                    Dim lecell As Integer = LECells(x).Value
                    Dim tecell As Integer = TECells(x).Value
                    celltotal += tecell - lecell + 1 ' + 1 to include the cell stated by the actual values
                    x += 1
                Next
                If needdelete = True Then
                    ' Remove existing measurements for this blade and radius
                    Dim existingRadiusMeasurements = Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id And r.BladeId = ScanBlade And Math.Round(r.Radius.Value) = Math.Round(ScanRadius)).ToList()
                    For Each rdsm In existingRadiusMeasurements
                        Database.RadiusMeasurements.Remove(rdsm)
                    Next
                    Dim existingCellMeasurements = Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Skip(celltotal).ToList()
                    Dim y As Integer = 0
                    Dim lecell As Integer = LECells(x).Value
                    Dim tecell As Integer = TECells(x).Value
                    Dim cellsToRemove As Integer = tecell - lecell + 1
                    For Each cm In existingCellMeasurements
                        If y >= (cellsToRemove) Then
                            Exit For
                        End If
                        Database.CellMeasurements.Remove(cm)
                        y += 1
                    Next
                    Database.SaveChanges()
                End If
                Dim rm As New RadiusMeasurement With {
                    .JobDetailsId = JobDetails.Id,
                    .BladeId = ScanBlade,
                    .Radius = Math.Round(ScanRadius, 2),
                    .LeCell = 0,
                    .TeCell = AngleArray.Length()
                }
                For x = 0 To AngleArray.Length - 1
                    Dim cm As New CellMeasurement With {
                        .JobDetailsId = JobDetails.Id,
                        .Angle = AngleArray(x),
                        .Depth = DepthArray(x)
                    }
                Next
            End With
        End If
    End Sub
    Private Function GetPitchofBladeRadius(Blade As Integer, Radius As Double) As Double()
        Dim PitchArray As Double() = {0}
        If Database IsNot Nothing Then
            Dim BladeIDs As New List(Of Integer?)
            Dim Radii As New List(Of Double?)
            Dim LECells As New List(Of Integer?)
            Dim TECells As New List(Of Integer?)
            Dim Angles As New List(Of Double?)
            Dim Depths As New List(Of Double?)
            For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
                BladeIDs.Add(bladID)
            Next
            For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
                Radii.Add(Rad)
            Next
            For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
                LECells.Add(integ)
            Next
            For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
                TECells.Add(integ)
            Next
            For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
                Angles.Add(Ange)
            Next
            For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
                Depths.Add(Dept)
            Next

            Dim celltotal As Integer = 0
            Dim x As Integer = 0
            For Each bladID In BladeIDs
                If bladID.Value = Blade And Math.Round(Radii(x).Value) = Math.Round(Radius) Then
                    x += 1
                    Exit For
                End If
                Dim lecell As Integer = LECells(x).Value
                Dim tecell As Integer = TECells(x).Value
                celltotal += tecell - lecell + 1 ' + 1 to include the cell stated by the actual values
                x += 1
            Next
            Dim celldiff As Integer = TECells(x).Value - LECells(x).Value
            For x = 0 To celldiff - 1
                Dim angle1 As Double = Angles(celltotal + x).GetValueOrDefault()
                Dim depth1 As Double = Depths(celltotal + x).GetValueOrDefault()
                Dim angle2 As Double = Angles(celltotal + x + 1).GetValueOrDefault()
                Dim depth2 As Double = Depths(celltotal + x + 1).GetValueOrDefault()
                Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
                PitchArray(x) = pitch
            Next

        End If
        Return PitchArray
    End Function
    Private ReadOnly Property PitchofRadiusSegments As Double()
        Get
            ' This property calculates the average pitch for each radius segment based on the radius measurements and cell measurements. It returns an array of average Pitch Values
            Dim pitcharray As Double() = {0}
            If Database IsNot Nothing Then

                Dim BladeIDs As New List(Of Integer?)
                Dim Radii As New List(Of Double?)
                Dim LECells As New List(Of Integer?)
                Dim TECells As New List(Of Integer?)
                Dim Angles As New List(Of Double?)
                Dim Depths As New List(Of Double?)
                For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
                    BladeIDs.Add(bladID)
                Next
                For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
                    Radii.Add(Rad)
                Next
                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
                    LECells.Add(integ)
                Next
                For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
                    TECells.Add(integ)
                Next
                For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
                    Angles.Add(Ange)
                Next
                For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
                    Depths.Add(Dept)
                Next
                Dim PitchbyBladeRadius = New Double(BladeIDs.Count) {}

                Dim cellcount As Integer = 0
                For i = 0 To BladeIDs.Count - 1
                    Dim bladid = BladeIDs(i)
                    Dim bladeIndex As Integer = bladid - 1
                    Dim radius As Double = Radii(i).GetValueOrDefault()
                    Dim leCell As Integer = LECells(i).GetValueOrDefault()
                    Dim teCell As Integer = TECells(i).GetValueOrDefault()
                    Dim celldiff As Integer = teCell - leCell + cellcount

                    Dim totalpitch As Double = 0
                    Dim pitchcount As Integer = 0
                    For x = cellcount To celldiff - 1
                        Dim angle1 As Double = Angles(x).GetValueOrDefault()
                        Dim depth1 As Double = Depths(x).GetValueOrDefault()
                        Dim angle2 As Double = Angles(x + 1).GetValueOrDefault()
                        Dim depth2 As Double = Depths(x + 1).GetValueOrDefault()
                        Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
                        totalpitch += pitch
                        pitchcount += 1
                    Next
                    If pitchcount > 0 Then
                        Dim averagePitch As Double = Math.Round(totalpitch / pitchcount, 2)
                        PitchbyBladeRadius(i) = averagePitch
                    End If
                Next
                pitcharray = PitchbyBladeRadius
                Return pitcharray
            End If

            Return pitcharray
        End Get
    End Property
    Private Sub UpdateBladeRadiusPlot(BladeNum As Integer, RadiusPerc As Double)
        'Updates a single blade and radius in the plot graph
        'Dim PitchArray As Double() = GetPitchofBladeRadius(BladeNum, RadiusPerc)

    End Sub
    Private Sub HomeEncoders()
        With Hardware.Encoders
            .ResetCount(USDigital.ANGLE_ENCODER)
            .ResetCount(USDigital.RADIUS_ENCODER)
            .ResetCount(USDigital.DEPTH_ENCODER)
        End With
        cmdHome.Visible = False
        cmdHome.Enabled = False
    End Sub
    Private Sub MeasurementsGet()
        ' Uset this in place of UpdateFields()
        With Hardware.Encoders
            txtAngle.Text = .Angle
            txtRadius.Text = .Radius(Job.PropellerDiameter).Value
            txtDepth.Text = .Depth
            txtRadiusPercent.Text = .Radius((Job.PropellerDiameter).Value * 100.0).ToString()
            txtBlade.Text = MRIMath.GetBladeNumber(.Angle(), Job.PropellerBlades).ToString()
        End With
    End Sub
    Private Sub UpdatePitchByRadiusTableFull()
        'need to implement a method to check the table for existing data and clear or update if necessary
        While GridBladebyRadius.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 1
            GridBladebyRadius.Columns.RemoveAt(GridBladebyRadius.Columns.Count - 1) 'remove all but the blade column
        End While
        GridBladebyRadius.Rows.Clear() 'remove all rows
        If Database IsNot Nothing Then
            Dim BladeIDs As New List(Of Integer?) 'Commented out sections have been moved to the PitchofRadiusSegments property as it will be used in multiple places
            Dim Radii As New List(Of Double?)
            'Dim LECells As New List(Of Integer?)
            'Dim TECells As New List(Of Integer?)
            'Dim Angles As New List(Of Double?)
            'Dim Depths As New List(Of Double?)

            'Database.RadiusMeasurements.OrderBy(Of Integer)(Function(r) r.BladeId).Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Where(Function(r) r.BladeId).ToList()

            Dim colBladeIDS As New List(Of Integer?)
            Dim colRadii As New List(Of Double?)
            For Each bladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.BladeId).ToList()
                BladeIDs.Add(bladID)
            Next
            For Each Rad In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.Radius).ToList()
                Radii.Add(Rad)
            Next
            For Each BladID In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).OrderBy(Function(r) r.Radius).Distinct.ToList()
                colBladeIDS.Add(BladID.BladeId)
                colRadii.Add(BladID.Radius)
            Next


            'For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.LeCell).ToList()
            '    LECells.Add(integ)
            'Next
            'For Each integ In Database.RadiusMeasurements.Where(Function(r) r.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(r) r.TeCell).ToList()
            '    TECells.Add(integ)
            'Next
            'For Each Ange In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Angle).ToList()
            '    Angles.Add(Ange)
            'Next
            'For Each Dept In Database.CellMeasurements.Where(Function(c) c.JobDetailsId = JobDetails.Id).AsSplitQuery().Select(Function(c) c.Depth).ToList()
            '    Depths.Add(Dept)
            'Next

            'Dim cellcount As Integer = 0
            'For i = 0 To BladeIDs.Count - 1
            '    Dim bladid = BladeIDs(i)
            '    Dim bladeIndex As Integer = bladid - 1
            '    Dim radius As Double = Radii(i).GetValueOrDefault()
            '    Dim leCell As Integer = LECells(i).GetValueOrDefault()
            '    Dim teCell As Integer = TECells(i).GetValueOrDefault()
            '    Dim celldiff As Integer = teCell - leCell + cellcount

            '    Dim totalpitch As Double = 0
            '    Dim pitchcount As Integer = 0
            '    For x = cellcount To celldiff - 1
            '        Dim angle1 As Double = Angles(x).GetValueOrDefault()
            '        Dim depth1 As Double = Depths(x).GetValueOrDefault()
            '        Dim angle2 As Double = Angles(x + 1).GetValueOrDefault()
            '        Dim depth2 As Double = Depths(x + 1).GetValueOrDefault()
            '        Dim pitch As Double = MRIMath.GetPitch(angle1, angle2, depth1, depth2)
            '        totalpitch += pitch
            '        pitchcount += 1
            '    Next
            '    If pitchcount > 0 Then
            '        Dim averagePitch As Double = Math.Round(totalpitch / pitchcount, 2)
            '        PitchbyBladeRadius(i) = averagePitch
            '    End If
            'Next

            Dim PitchbyBladeRadius As Double() = PitchofRadiusSegments
            Dim radcountlist = colBladeIDS.FindAll(Function(b) b = 1)
            Dim Raditerator = 0

            While GridBladebyRadius.Columns.GetColumnCount(DataGridViewElementStates.Visible) - 1 < radcountlist.Count
                Dim Radius As Double = colRadii(Raditerator).Value
                Radius = Math.Round(Radius, 0)
                GridBladebyRadius.Columns.Add(Radius.ToString(), Radius & "%")
                Raditerator += 1
            End While

            While GridBladebyRadius.Rows.Count < Job.PropellerBlades
                GridBladebyRadius.Rows.Add()
            End While
            For Each row In GridBladebyRadius.Rows
                GridBladebyRadius.Rows(row.Index).Cells(0).Value = row.Index + 1
            Next
            Raditerator = 0
            For i = 0 To BladeIDs.Count - 1
                Dim Bindex As Integer = BladeIDs(i) - 1
                GridBladebyRadius.Rows(Bindex).Cells(Math.Round(Radii(i).Value, 0).ToString()).Value = PitchbyBladeRadius(i)
                Raditerator += 1
            Next
            GridBladebyRadius.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)

        End If
    End Sub

#End Region
#Region "UI Event Handlers"
    Private Sub CmdHome_Click(sender As Object, e As EventArgs) Handles cmdHome.Click
        HomeEncoders()
    End Sub
    Private Sub CmdStopScan_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub CountUpdate_Tick(sender As Object, e As EventArgs)
        'UpdateFields()
    End Sub
    Private Sub CmdZero_Click(sender As Object, e As EventArgs) Handles cmdZero.Click
        Try
            mHardware.Encoders.ResetCount(ANGLE_ENCODER)
            mHardware.Encoders.ResetCount(RADIUS_ENCODER)
            mHardware.Encoders.ResetCount(DEPTH_ENCODER)
        Catch ex As Exception
            MessageBox.Show("Error zeroing encoders: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmdStartScan_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub FrmMeasurements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Job = Database.Jobs.Where(Function(j) j.JobNumber = 3427).FirstOrDefault()
            'JobDetails = Database.JobDetails.FirstOrDefault(Function(j) j.JobId = Job.Id)
            timerMeasurements.Interval = Database.Settings.FirstOrDefault().EncoderCalibrationSampleRate
            PlotGraph.Series(0).Color = Color.Green
            PlotGraph.Series(1).Color = Color.Red
            PlotGraph.Series(2).Color = Color.Blue
        Catch ex As Exception
            MessageBox.Show("Error loading settings: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChkMeasurements_CheckedChanged(sender As Object, e As EventArgs) Handles chkMeasurements.CheckedChanged
        Dim dp = New DataVisualization.Charting.DataPoint(0.5, 0.5)
        Dim dp2 = New DataVisualization.Charting.DataPoint(0.5, 0)
        Dim dp3 = New DataVisualization.Charting.DataPoint(0.5, -0.5)
        PlotGraph.Series(0).Points.Add(dp2)
        PlotGraph.Series(1).Points.Add(dp)
        PlotGraph.Series(2).Points.Add(dp3)
        Try
            timerMeasurements.Enabled = chkMeasurements.Checked
            cmdHome.Enabled = Not chkMeasurements.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
        Try
            UpdatePitchByRadiusTableFull()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, STR_TITLE_APPLICATION_ERROR)
        End Try
    End Sub

    Private Sub TimerMeasurements_Tick(sender As Object, e As EventArgs) Handles timerMeasurements.Tick
        Try
            MeasurementsGet()
        Catch ex As Exception
            chkMeasurements.Checked = False
            MessageBox.Show("Error updating measurements: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class