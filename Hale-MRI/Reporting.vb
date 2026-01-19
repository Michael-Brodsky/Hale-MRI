Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Formats.Asn1
Imports System.Windows.Forms.DataVisualization.Charting
Imports Hale_MRI.Reporting
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore.Metadata.Internal
Imports Windows.Win32.UI

''' <summary>
''' This module provides functionality for generating reports with draggable controls.
''' </summary>
Public Module Reporting
    Public Class ReportGenerator
        Private mDragStartPos As Point                      ' The starting mouse position of the drag operation.
        Private mIsDragging As Boolean = False              ' Indicates whether a drag operation is in progress.
        Private mIsResizing As Boolean = False              ' Indicates whether a resize operation is in progress.
        Private mLastControlPos As Point                    ' The last known position of the control being dragged.
        Private mLastControlSize As Size                    ' The last known size of the control being resized.    
        Private mTopSortedControls As List(Of Control)      ' The list of controls sorted by their top (Y) position.
        Private mTopLeftSortedControls As List(Of Control)  ' The list of controls sorted by their top (Y) and left (X) position.
        Public Sub New(controls As List(Of Control))
            mTopSortedControls = ElementSortByTop(controls)
            mTopLeftSortedControls = ElementSortByTopLeft(controls)
        End Sub

        Public Sub ControlCursorChange(sender As Object, e As MouseEventArgs, borderSize As Integer)
            ' Changes the cursor to indicate draggable borders when hovering over the control edges.
            Dim currentControl As Control = CType(sender, Control)
            If currentControl Is Me.SelectedControl Then
                If e.X <= borderSize OrElse e.X >= currentControl.Width - borderSize Then
                    currentControl.Cursor = Cursors.VSplit
                ElseIf e.Y <= borderSize OrElse e.Y >= currentControl.Height - borderSize Then
                    currentControl.Cursor = Cursors.HSplit
                Else
                    currentControl.Cursor = Cursors.Default
                End If
            End If
        End Sub

        Public Sub ControlDragDrop(sender As Object, e As MouseEventArgs)
            ' Finalizes the drag-and-drop operation for the control being dragged.
            If mIsDragging Then
                ElementDrop(CType(sender, Control), 10)
                mIsDragging = False
            End If
        End Sub

        Public Sub ControlDragMove(sender As Object, e As MouseEventArgs)
            ' Handles the drag-and-drop operation for moving the control being dragged.
            If mIsDragging AndAlso SelectedControl IsNot Nothing Then
                SelectedControl.Invalidate()
                Dim newX As Integer = SelectedControl.Left + (e.X - mDragStartPos.X)
                Dim newY As Integer = SelectedControl.Top + (e.Y - mDragStartPos.Y)
                ' Ensure the control stays within the bounds of the parent form.
                If newX < 0 Then
                    newX = 0
                ElseIf newX > ParentForm.ClientSize.Width - SelectedControl.Width Then
                    newX = ParentForm.ClientSize.Width - SelectedControl.Width
                End If
                If newY < 0 Then
                    newY = 0
                ElseIf newY > ParentForm.ClientSize.Height - SelectedControl.Height Then
                    newY = ParentForm.ClientSize.Height - SelectedControl.Height
                End If
                SelectedControl.Location = New Point(newX, newY)
            End If
        End Sub

        Public Sub ControlDragStart(sender As Object, e As MouseEventArgs)
            ' Initiates a drag-and-drop operation for the control being dragged.
            mIsDragging = True
            mDragStartPos = e.Location
            mLastControlPos = CType(sender, Control).Location
        End Sub

        Public Sub ControlEnter(sender As Object, e As EventArgs)

        End Sub

        Public Sub ControlLeave(sender As Object, e As EventArgs)

        End Sub

        Public Sub ControlMouseClick(sender As Object, e As MouseEventArgs)

        End Sub

        Public Sub ControlMouseDown(sender As Object, e As MouseEventArgs)
            ' Initiates resizing if the mouse is on the border of the control,
            ' else initiates drag drop.
            ControlSelect(sender, Nothing)
            If Me.SelectedControl.Cursor = Cursors.Default Then
                ControlDragStart(sender, e)
            Else
                ControlResizeStart(sender, e)
            End If
        End Sub

        Public Sub ControlMouseMove(sender As Object, e As MouseEventArgs)
            If mIsDragging Then
                ControlDragMove(sender, e)
            ElseIf mIsResizing Then
                ControlResizeMove(sender, e)
            Else
                ' Changes the cursor to indicate draggable borders when hovering over the control edges.
                ControlCursorChange(sender, e, 5)
            End If
        End Sub

        Public Sub ControlMouseUp(sender As Object, e As MouseEventArgs)
            ' Finalizes any ongoing drag or resize operation.
            If mIsDragging Then
                ControlDragDrop(sender, e)
            ElseIf mIsResizing Then
                ControlResizeEnd(sender, e)
            End If
        End Sub
        Public Sub ControlRepaint(sender As Object, e As PaintEventArgs)
            ' Redraws the border of the control being repainted.
            Dim currentControl As Control = CType(sender, Control)
            If currentControl Is Me.SelectedControl Then
                Dim rect As Rectangle = currentControl.ClientRectangle
                rect.Inflate(2, 2)
                ControlPaint.DrawBorder(e.Graphics, rect, Color.Blue, 3, ButtonBorderStyle.Solid,
                Color.Blue, 3, ButtonBorderStyle.Solid,
                Color.Blue, 3, ButtonBorderStyle.Solid,
                Color.Blue, 3, ButtonBorderStyle.Solid)
            Else
                ControlPaint.DrawBorder(e.Graphics, currentControl.ClientRectangle, currentControl.BackColor, ButtonBorderStyle.None)
            End If
        End Sub

        Public Sub ControlResizeEnd(sender As Object, e As MouseEventArgs)
            ' Finalizes the resize operation for the control being resized.
            If mIsResizing Then
                ElementDrop(CType(sender, Control), 10)
                mIsResizing = False
            End If
        End Sub

        Public Sub ControlResizeMove(sender As Object, e As MouseEventArgs)
            ' Handles the resize operation for the control being resized.
            SelectedControl.Invalidate()
            If Me.SelectedControl.Cursor = Cursors.VSplit Then
                Dim newWidth As Integer = mLastControlSize.Width + (e.X - mDragStartPos.X)
                ' Ensure the control width is within reasonable limits.
                If newWidth < 20 Then newWidth = 20
                SelectedControl.Width = newWidth
            ElseIf Me.SelectedControl.Cursor = Cursors.HSplit Then
                Dim newHeight As Integer = mLastControlSize.Height + (e.Y - mDragStartPos.Y)
                ' Ensure the control height is within reasonable limits.
                If newHeight < 20 Then newHeight = 20
                SelectedControl.Height = newHeight
            End If
        End Sub

        Public Sub ControlResizeStart(sender As Object, e As MouseEventArgs)
            ' Initiates a resize operation for the control being resized.
            mIsResizing = True
            mDragStartPos = e.Location
            mLastControlSize = CType(sender, Control).Size
        End Sub

        Public Sub ControlResize(sender As Object, e As EventArgs)
            ' Invalidates the control to trigger a repaint on resize.
            Dim currentControl As Control = CType(sender, Control)
            currentControl.Invalidate()
        End Sub

        Public Sub ControlSelect(sender As Object, e As EventArgs)
            ' Sets the selected control.
            Dim currentControl As Control = CType(sender, Control)
            If Me.SelectedControl IsNot Nothing Then Me.SelectedControl.Invalidate()
            Me.SelectedControl = currentControl
            Me.SelectedControl.Invalidate()
        End Sub

        Public Property EnteredControl As Control

        Public Sub FormMouseDown(sender As Object, e As MouseEventArgs)
            ' Clears the selected control when clicking on the form background.
            If Me.SelectedControl IsNot Nothing Then
                Me.SelectedControl.Invalidate()
                Me.SelectedControl = Nothing
            End If
        End Sub

        Public Property GridSize As Integer = 10

        Public Property HorizontalLimit As Integer = 0

        Public Property ParentForm As Form

        Public Sub ReportGenerate(sender As Object, e As PrintPageEventArgs)
            ' Generates the report by drawing each control onto the print page.
            Dim yOffset As Integer = 0
            For Each ctrl As Control In mTopLeftSortedControls
                If Not ctrl.Visible Then Continue For
                ' Draw each control at its specified location.
                Dim bmp As New Bitmap(ctrl.Width, ctrl.Height)
                ctrl.DrawToBitmap(bmp, New Rectangle(0, 0, ctrl.Width, ctrl.Height))
                e.Graphics.DrawImage(bmp, New Point(ctrl.Left, ctrl.Top + yOffset))
                bmp.Dispose()
            Next
        End Sub

        Public Property SelectedControl As Control

        Public Property VerticalLimit As Integer = 0

        Private Sub ElementDrop(element As Control, gridSize As Integer)
            mTopLeftSortedControls = ElementSortByTopLeft(mTopLeftSortedControls)
            ' Snaps the element to the nearest grid position based on the specified grid size.
            'For Each ctrl As Control In mTopSortedControls
            '    If ctrl IsNot element Then
            '        If ElementIsAbove(element, ctrl) Then
            '            ElementMoveAbove(element, ctrl, mTopSortedControls, 10)
            '            Exit Sub
            '        End If
            '    End If
            'Next
            'ElementReturnToLastPosition(element, mLastControlPos)
        End Sub

        Private Function ElementIsAbove(element As Control, other As Control) As Boolean
            ' Determines if 'element' control is above 'other' control based on Y coordinate.
            'Return element.Location.Y < other.Location.Y
        End Function

        Private Sub ElementMoveAbove(element As Control, other As Control, elements As List(Of Control), gridSize As Integer)
            ' Moves the element above the other element in the list of elements.
            'Dim otherIndex As Integer = elements.IndexOf(other)
            'Dim otherLocation As Point = other.Location
            'elements.Remove(element)
            'elements.Insert(otherIndex, element)
            'element.Location = otherLocation
            '' Reposition all lower elements based on their new order.
            'For i = otherIndex + 1 To elements.Count - 1
            '    elements(i).Location = New Point(elements(i).Location.X, elements(i - 1).Location.Y + elements(i - 1).Height + gridSize)
            'Next
        End Sub

        Private Sub ElementReturnToLastPosition(element As Control, lastPos As Point)
            ' Returns the element to its last known position.
            'element.Location = lastPos
        End Sub

        Private Function ElementSortByTop(elements As List(Of Control)) As List(Of Control)
            ' Sorts elements in ascending order of the Y coordinate. Need to improve to only handle visible elements.
            Dim sortedElements = elements.OrderBy(Function(c) c.Location.Y).ToList()
            Return sortedElements
        End Function

        Private Function ElementSortByTopLeft(elements As List(Of Control)) As List(Of Control)
            'Sorts by Y and then X (lexicographical sort). Need to improve to only handle visible elements.
            Dim sortedElements = elements.OrderBy(Function(c) c.Location.Y).ThenBy(Function(c) c.Location.X).ToList()
            Return sortedElements
        End Function
    End Class
#Region "Tables"
    Public Function UpdateRadiiAveragesTable(mJobDetails As JobDetail, Design As Boolean) As DataTable
        Dim mJob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("r/R", GetType(Integer))
        Dim rowRadiusBlade As DataRow

        For Each radmeas As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1)
            rowRadiusBlade = dtBladePitchByRadius.Rows.Add(Math.Round(radmeas.Radius.Value).ToString + " %")
        Next
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) Math.Round(r.Radius.Value).ToString + " %" = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(dtBladePitchByRadius.Rows.Find(Math.Round(rm.Radius.Value).ToString + " %"), dtBladePitchByRadius.Rows.Add(rm.Radius.Value).ToString + " %")
                colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim meancol As DataColumn = If(dtBladePitchByRadius.Columns("Mean"), dtBladePitchByRadius.Columns.Add("Mean", GetType(Double)))
            Dim avgPitch As Double = totalPitch / pitchCount
            row.Item(meancol) = Math.Round(avgPitch, 2)
            If Design Then
                Dim designcol As DataColumn = If(dtBladePitchByRadius.Columns("Design"), dtBladePitchByRadius.Columns.Add("Design", GetType(Double)))
                'add if here for design loaded check use design pitch if loaded and ref if not
                row.Item(designcol) = Math.Round(mJob.DesiredPitch.Value, 2)
            End If
        Next
        Return dtBladePitchByRadius
    End Function
    Public Function UpdateChordLengthTable(mJobDetails As JobDetail) As DataTable
        Dim mjob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtChordLength As New DataTable()
        Dim colRadius As DataColumn = dtChordLength.Columns.Add("Blade", GetType(Integer))
        Dim rowBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob?.PropellerBlades
            dtChordLength.Rows.Add(x)
        Next
        dtChordLength.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtChordLength.Rows
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowBlade = If(dtChordLength.Rows.Find(rm.BladeId), dtChordLength.Rows.Add(rm.BladeId))
                colRadius = If(dtChordLength.Columns(radiusPercent), dtChordLength.Columns.Add(radiusPercent, GetType(Double)))
                Dim ChordLength As Double = GetChordLength(rm.CellMeasurements.ToList(), mjob.PropellerDiameter, CInt(radiusPercent))
                rowBlade.Item(colRadius) = Math.Round(ChordLength, 2)
            Next
            colRadius = If(dtChordLength.Columns("Track"), dtChordLength.Columns.Add("Track", GetType(Double))) ' need to figure out what this is
        Next
        Return dtChordLength
    End Function

    Public Function UpdateISOTOLTable(basispitch As Double, Tolclass As Tolerance, Mins As Boolean) As DataTable
        Dim ISOTable As New DataTable()
        ISOTable.Columns.Add("TolType", GetType(String))
        ISOTable.Columns.Add("MinsApply", GetType(String))
        ISOTable.Columns.Add("TolPerc", GetType(String))
        ISOTable.Columns.Add("PlusMinus", GetType(String))
        ISOTable.Columns.Add("OverUnder", GetType(String))

        'Local Pitch
        Dim RowLocal As DataRow = ISOTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("MinsApply") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.LocalPitchPercent.ToString() & " %"
        Dim MinMax As Double
        MinMax = basispitch * (Tolclass.LocalPitchPercent / 100)
        If Mins And MinMax < Tolclass.LocalPitchMinimum * kMmToInch Then 'need checks for SYS type
            MinMax = Tolclass.LocalPitchMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " / " + (basispitch - MinMax)

        'Radius Average
        RowLocal = ISOTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerRadiusPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerRadiusPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerRadiusMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerRadiusMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Blade Average
        RowLocal = ISOTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchPerBladePercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchPerBladePercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchPerBladeMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchPerBladeMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"

        'Propeller Average
        RowLocal = ISOTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("Mins") = "Mins"
        RowLocal.Item("TolPerc") = Tolclass.MeanPitchForPropellerPercent.ToString() & " %"
        MinMax = basispitch * (Tolclass.MeanPitchForPropellerPercent / 100)
        If Mins And MinMax < Tolclass.MeanPitchForPropellerMinimum * kMmToInch Then
            MinMax = Tolclass.MeanPitchForPropellerMinimum * kMmToInch
        End If
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (basispitch + MinMax) + " In / " + (basispitch - MinMax) + " In"
        If Mins <> True Then
            ISOTable.Columns.RemoveAt(1)
        End If
        Return ISOTable
    End Function

    Public Function UpdateLocalPitchTable(mJobDetails As JobDetail, TolClass As Tolerance)
        Dim dtLPTable As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim rowRad As DataRow
        Dim colBlade As DataColumn
        Dim x As Integer
        Dim y As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                colBlade = dtLPTable.Columns.Add("RadCol")
                rowRad = dtLPTable.Rows.Add("BladeRow")
                rowRad.Item("RadCol") = "r/R"
            Else
                For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                    rowRad = If(dtLPTable.Rows.Find(rm.Radius.Value.ToString()), dtLPTable.Rows.Add(rm.Radius.Value.ToString()))
                    For y = 1 To TolClass.LocalPitchSectors
                        colBlade = If(dtLPTable.Columns("Blade" + rm.BladeId.ToString() + y.ToString()), dtLPTable.Columns.Add("Blade" + rm.BladeId.ToString() + y.ToString()))
                        rowRad.Item("Blade" + rm.BladeId.ToString() + y.ToString()) = GetLocalPitch(rm.CellMeasurements, TolClass.LocalPitchSectors, y, mJob.PropellerBlades, rm.Radius, mJob.TeExclusion, mJob.LeExclusion)
                    Next
                Next
            End If
        Next
        Return dtLPTable
    End Function

    Public Function UpdateBladeAveragesTable(mJobDetails As JobDetail) As DataTable
        Dim dtbladeaverage As New DataTable
        Dim mJob As Job = mJobDetails.Job
        Dim pitchrow As DataRow = dtbladeaverage.Rows.Add("Pitch")
        Dim BladeCol As DataColumn
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            BladeCol = dtbladeaverage.Columns.Add("Blade" + x)
            Dim pitchtotal As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                pitchtotal += GetAverageBladePitch(rm.CellMeasurements, mJob.TeExclusion, mJob.LeExclusion)
                pitchcount += 1
            Next
            pitchrow.Item(BladeCol) = pitchtotal / pitchcount
        Next
        Return dtbladeaverage
    End Function

    Public Function UpdateFederalToleranceListTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = ".75 %"
        MinMax = BasisPitch * (0.75 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.01
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateMichiganToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Section"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateStandardToleranceTable(BasisPitch As Double, Diameter As Double) As DataTable
        Dim TolTable As New DataTable()
        TolTable.Columns.Add("TolType", GetType(String))
        TolTable.Columns.Add("TolPerc", GetType(String))
        TolTable.Columns.Add("PlusMinus", GetType(String))
        TolTable.Columns.Add("OverUnder", GetType(String))

        'Radius
        Dim RowLocal As DataRow = TolTable.Rows.Add("Radius")
        RowLocal.Item("TolType") = "Radius"
        RowLocal.Item("TolPerc") = "0.3 %"
        Dim MinMax As Double = (Diameter / 2) * 0.003
        RowLocal.Item("PlusMinus") = "±" + MinMax + " In"
        RowLocal.Item("OverUnder") = ((Diameter / 2) + MinMax) + " / " + ((Diameter / 2) - MinMax)

        'Local Pitch
        RowLocal = TolTable.Rows.Add("Local Pitch")
        RowLocal.Item("TolType") = "Local Pitch"
        RowLocal.Item("TolPerc") = 2.ToString() & " %"
        MinMax = BasisPitch * (2 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In" 'need to change In to sys type once it is set up
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " / " + (BasisPitch - MinMax)

        'Radius Average
        RowLocal = TolTable.Rows.Add("Radius Average")
        RowLocal.Item("TolType") = "Radius Average"
        RowLocal.Item("TolPerc") = "1.5 %"
        MinMax = BasisPitch * (1.5 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Blade Average
        RowLocal = TolTable.Rows.Add("Blade Average")
        RowLocal.Item("TolType") = "Blade Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Propeller Average
        RowLocal = TolTable.Rows.Add("Propeller Average")
        RowLocal.Item("TolType") = "Propeller Average"
        RowLocal.Item("TolPerc") = "1 %"
        MinMax = BasisPitch * (1 / 100)
        RowLocal.Item("PlusMinus") = "±" + (MinMax) + " In"
        RowLocal.Item("OverUnder") = (BasisPitch + MinMax) + " In / " + (BasisPitch - MinMax) + " In"

        'Track
        RowLocal = TolTable.Rows.Add("Track")
        RowLocal.Item("TolType") = "Track"
        MinMax = BasisPitch * 0.005
        RowLocal.Item("PlusMinus") = (MinMax) + " In"
        Return TolTable
    End Function

    Public Function UpdateManualInspTable(mJob As Job) As DataTable
        Dim dtManualInsp As New DataTable()
        dtManualInsp.Columns.Add("InspectionItem", GetType(String))
        dtManualInsp.Columns.Add("Yes", GetType(String))
        dtManualInsp.Columns.Add("No", GetType(String))

        Dim row As DataRow = dtManualInsp.Rows.Add("ACCEPTABLE")
        row.Item("InspectionItem") = "ACCEPTABLE"
        row.Item("Yes") = "YES"
        row.Item("No") = "NO"
        row = dtManualInsp.Rows.Add("Blade Surface")
        row.Item("InspectionItem") = "Blade Surface"
        row = dtManualInsp.Rows.Add("Blade Edges")
        row.Item("InspectionItem") = "BladeEdges"
        row = dtManualInsp.Rows.Add("Static Balance")
        row.Item("Inspectionitem") = "Static Balance"
        row = dtManualInsp.Rows.Add("Thcikness")
        row.Item("InspectionItem") = "Thickness"
        row = dtManualInsp.Rows.Add("Bore")
        row.Item("InspectionItem") = "Bore"
        row = dtManualInsp.Rows.Add("Keyway")
        row.Item("InspectionItem") = "KeyWay"
        Return dtManualInsp
    End Function

    Public Function UpdateRadiusToleranceTable(Diameter As Double, TolClass As Tolerance) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Min")
        tolTable.Columns.Add("Design")
        tolTable.Columns.Add("Max")

        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Min") = "Min"
        row.Item("Design") = "Design"
        row.Item("Max") = "Max"
        row = tolTable.Rows.Add("Tolerance")
        Dim mintol As Double = (Diameter / 2) - ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Min") = Math.Round(mintol, 2)
        row.Item("Design") = Math.Round(Diameter / 2, 2)
        Dim maxtol As Double = (Diameter / 2) + ((Diameter / 2) * (TolClass.ExtremeRadiusPercent / 100))
        row.Item("Max") = Math.Round(maxtol, 2)
        Return tolTable
    End Function

    Public Function UpdateTrackToleranceTable(BasisPitch As Double) As DataTable
        Dim tolTable As New DataTable()
        tolTable.Columns.Add("Tolerance")
        Dim row As DataRow = tolTable.Rows.Add("Label")
        row.Item("Tolerance") = "Track Tolerance"
        row = tolTable.Rows.Add("MinMax")
        Dim minmax = BasisPitch * 0.01
        row.Item("Tolerance") = minmax.ToString()
        Return tolTable
    End Function

    Public Function UpdateRadiusBladeWheelAveragePitchTable(mJobDetails As JobDetail, TolClass As Tolerance, Basispitch As Double) As DataTable
        Dim Table As New DataTable()
        Dim mjob As Job = mJobDetails.Job

        Dim colRadius As DataColumn = Table.Columns.Add("Blade", GetType(Integer))
        Dim rowRadiusBlade As DataRow
        Dim x As Integer
        For x = 1 To mjob.PropellerBlades
            rowRadiusBlade = Table.Rows.Add(x)
        Next
        Table.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In Table.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0 ' Condensed these for loops into one to increase speed
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(Table.Rows.Find(rm.BladeId), Table.Rows.Add(rm.BladeId))
                colRadius = If(Table.Columns(radiusPercent), Table.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mjob.TeExclusion, mjob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim avgPitch As Double = totalPitch / pitchCount
            colRadius = If(Table.Columns("Average"), Table.Columns.Add("Average", GetType(Double)))
            row.Item(colRadius) = Math.Round(avgPitch, 2)
            colRadius = If(Table.Columns("Wheel"), Table.Columns.Add("Wheel", GetType(Double)))
            row.Item(colRadius) = mJobDetails.WheelPitch.Value
        Next
        rowRadiusBlade = Table.Rows.Add("Allow")
        Dim minmax As Double
        minmax = Basispitch * (TolClass.MeanPitchPerRadiusPercent / 100)
        Dim allow As String = (Basispitch + minmax).ToString() + " / " + (Basispitch - minmax).ToString()
        For Each col As DataColumn In Table.Columns
            If col.ColumnName = "Blade" Then
                rowRadiusBlade.Item(col) = "Allow"
            ElseIf col.ColumnName = "Average" Or col.ColumnName = "Wheel" Then
                rowRadiusBlade.Item(col) = "± " + TolClass.MeanPitchPerRadiusPercent / 100 + "%"
            Else
                rowRadiusBlade.Item(col) = allow
            End If
        Next
        Return Table
    End Function

    Public Function UpdateSkewTable(mJobDetails As JobDetail) As DataTable
        Dim dtable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim BladeCol As DataColumn = dtable.Columns.Add("Radius", GetType(String))
        Dim RadRow As DataRow
        Dim x As Integer
        For x = 1 To mJob.PropellerBlades
            Dim ReferenceRadius As RadiusMeasurement = mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x).FirstOrDefault()
            Dim ReferenceAngle As Double = GetChordMidAngle(ReferenceRadius.CellMeasurements)
            Dim ReferenceDepth As Double = GetChordMidDepth(ReferenceRadius.CellMeasurements)
            BladeCol = dtable.Columns.Add("Blade" + x, GetType(String))
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                RadRow = If(dtable.Rows.Find(Math.Round(rm.Radius.Value, 2)), dtable.Rows.Add(Math.Round(rm.Radius.Value, 2)))
                If x = 1 Then
                    RadRow.Item("Radius") = rm.Radius + "%"
                End If
                If rm.Radius = ReferenceRadius.Radius Then
                    RadRow.Item(BladeCol) = "Ref"
                Else
                    Dim rmdepth As Double = GetChordMidDepth(rm.CellMeasurements)
                    Dim rmangle As Double = GetChordMidAngle(rm.CellMeasurements)
                    Dim anglediff As Double = rmangle - ReferenceAngle
                    Dim chordDiff As Double = GetChordLength(ReferenceAngle, rmangle, ReferenceDepth, rmdepth, mJob.PropellerDiameter, rm.Radius)
                    Dim diffs As String = anglediff + "Deg / " + chordDiff + " In"
                    RadRow.Item(BladeCol) = diffs
                End If
            Next
        Next
        Return dtable
    End Function

    Public Function UpdateAngularSpacingTable(mJobDetails As JobDetail) As DataTable
        Dim dTable As New DataTable()
        Dim mJob As Job = mJobDetails.Job
        Dim bladecol As DataColumn = dTable.Columns.Add("Blade", GetType(String))
        bladecol = dTable.Columns.Add("Ang", GetType(String))
        Dim bladerow As DataRow
        Dim x As Integer
        For x = 0 To mJob.PropellerBlades
            If x = 0 Then
                bladerow = dTable.Rows.Add("Design")
                bladerow.Item("Blade") = "Design"
                bladerow.Item("Ang") = (360 / mJob.PropellerBlades).ToString() + " Deg"
            Else
                bladerow = dTable.Rows.Add("Blade" + x.ToString())
                bladerow.Item("Blade") = "Blade " + x.ToString()
                If x = 1 Then
                    bladerow.Item("Ang") = "Ref"
                Else
                    Dim refangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = 1 And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim currangle = GetChordMidAngle(mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x And Math.Round(r.Radius.Value) = 70).FirstOrDefault().CellMeasurements)
                    Dim anglespace As Double = currangle - refangle - ((360 / mJob.PropellerBlades) * (x - 1))
                    bladerow.Item("Ang") = anglespace.ToString("F2") + " Deg"
                End If
            End If
        Next
        Return dTable
    End Function
#End Region
#Region "Graphs"
    Public Sub UpdateBladeAverageGraph(Graph As Chart, mJobDetails As JobDetail, Tolclass As Tolerance, basispitch As Double)
        Graph.Series.Clear()
        Graph.ChartAreas.Clear()
        Graph.Legends.Clear()
        Graph.Titles.Clear()
        Graph.Annotations.Clear()
        Graph.PaletteCustomColors = GraphColorArray

        Dim cArea As ChartArea = Graph.ChartAreas.Add("BladeAverage")
        Dim ser As Series = Graph.Series.Add("Pitch")
        ser.ChartType = SeriesChartType.Bar
        ser.ChartArea = cArea.Name

        cArea.Axes(0).Minimum = 0
        cArea.Axes(0).Maximum = basispitch * 1.2
        cArea.Axes(0).Interval = 1
        cArea.Axes(0).MinorTickMark.Enabled = True
        cArea.Axes(0).MinorTickMark.Interval = 1
        cArea.Axes(0).MajorTickMark.Enabled = True
        cArea.Axes(0).MajorTickMark.Interval = 5

        cArea.Axes(1).Minimum = 1
        cArea.Axes(1).Maximum = mJobDetails.Job.PropellerBlades
        cArea.Axes(1).Interval = 1

        Dim x As Integer
        For x = 1 To mJobDetails.Job.PropellerBlades
            Dim avgpitch As Double = 0
            Dim pitchcount As Integer = 0
            For Each rm As RadiusMeasurement In mJobDetails.RadiusMeasurements.Where(Function(r) r.BladeId = x)
                avgpitch += GetAverageBladePitch(rm.CellMeasurements.ToList(), mJobDetails.Job.TeExclusion, mJobDetails.Job.LeExclusion)
                pitchcount += 1
            Next
            If pitchcount > 0 Then
                avgpitch /= pitchcount
            End If
            ser.Points.AddXY(avgpitch, x)
        Next
        'need to add tolerance lines
        Dim slineunder As New StripLine()
        slineunder.IntervalOffset = basispitch - (basispitch * (Tolclass.MeanPitchPerBladePercent / 100))
        slineunder.StripWidth = 0.01
        slineunder.BorderColor = Color.Black
        slineunder.BorderWidth = 2
        cArea.Axes(0).StripLines.Add(slineunder)

    End Sub
#End Region

End Module
