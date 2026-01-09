Imports System.Drawing.Printing
Imports Hale_MRI.Reporting
Imports LibDatabase.Models
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
    Private Function UpdateRadiiAveragesTable(mJobDetails As JobDetail, MeanDesign As Boolean) As DataTable
        Dim mJob As Job = mJobDetails.Job
        If mJobDetails Is Nothing Then
            Return New DataTable()
        End If
        Dim dtBladePitchByRadius As New DataTable()
        Dim colRadius As DataColumn = dtBladePitchByRadius.Columns.Add("Blade", GetType(Integer))
        Dim rowRadiusBlade As DataRow
        Dim x As Integer
        For x = 1 To mJob?.PropellerBlades
            rowRadiusBlade = dtBladePitchByRadius.Rows.Add(x)
        Next
        dtBladePitchByRadius.PrimaryKey = New DataColumn() {colRadius}
        For Each row As DataRow In dtBladePitchByRadius.Rows
            Dim totalPitch As Double = 0.0
            Dim pitchCount As Integer = 0 ' Condensed these for loops into one to increase speed
            For Each rm As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = row.Item("Blade"))
                Dim radiusPercent As String = Math.Round(CType(rm.Radius, Double)).ToString(STR_PARAM_DECIMAL_PLACES)
                rowRadiusBlade = If(dtBladePitchByRadius.Rows.Find(rm.BladeId), dtBladePitchByRadius.Rows.Add(rm.BladeId))
                colRadius = If(dtBladePitchByRadius.Columns(radiusPercent), dtBladePitchByRadius.Columns.Add(radiusPercent, GetType(Double)))
                Dim pitch As Double = GetAverageBladePitch(rm.CellMeasurements.ToList(), mJob.TeExclusion, mJob.LeExclusion)
                rowRadiusBlade.Item(colRadius) = Math.Round(pitch, 2)
                totalPitch += pitch
                pitchCount += 1
            Next
            Dim avgPitch As Double = totalPitch / pitchCount
            If MeanDesign Then
                Dim meancol As DataColumn = If(dtBladePitchByRadius.Columns("Mean"), dtBladePitchByRadius.Columns.Add("Mean", GetType(Double)))
                Dim designcol As DataColumn = If(dtBladePitchByRadius.Columns("Design"), dtBladePitchByRadius.Columns.Add("Design", GetType(Double)))
                'add if here for design loaded check use design pitch if loaded and ref if not
                row.Item(designcol) = Math.Round(mJob.DesiredPitch.Value, 2)
                row.Item(meancol) = Math.Round(avgPitch, 2)
            End If
        Next
        Return dtBladePitchByRadius
    End Function
    Private Function UpdateChordLengthTable(mJobDetails As JobDetail) As DataTable
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

    'Private Sub UpdateISOTOLTable(Tolclass As Tolerance, Mins As Boolean)
    '    Dim ISOTable As New DataTable()
    '    ISOTable.Columns.Add("TolType", GetType(String))
    '    ISOTable.Columns.Add("MinsApply", GetType(String))
    '    ISOTable.Columns.Add("TolPerc", GetType(String))
    '    ISOTable.Columns.Add("PlusMinus", GetType(String))
    '    ISOTable.Columns.Add("OverUnder", GetType(String))

    '    GrdISOTolTable.DataSource = ISOTable
    '    If Mins Then
    '        GrdISOTolTable.Columns("MinsApply").Visible = True
    '    Else
    '        GrdISOTolTable.Columns("MinsApply").Visible = False
    '    End If
    '    Select Case Tolclass.ToleranceClass
    '        Case "S", "I", "II"
    '            Dim RowLocal As DataRow = ISOTable.Rows.Add("Local Pitch")
    '            RowLocal.Item("TolType") = "Local Pitch"
    '            RowLocal.Item("MinsApply") = "Mins"
    '            RowLocal.Item("TolPerc") = Tolclass.LocalPitchPercent.ToString("F2") & " %"
    '            Dim LocalMinMax As Double
    '            If 
    '            RowLocal.Item("PlusMinus") = "±" + (mJobDetails.WheelPitch * (Tolclass.LocalPitchPer) 'need to change wheel pitch to basis option on this form

    '    End Select
    'End Sub
#End Region

End Module
