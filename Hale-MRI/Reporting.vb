Imports System.Drawing.Printing
Imports Hale_MRI.Reporting
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

        Public Sub New()
            mTopSortedControls = New List(Of Control)()
            mTopLeftSortedControls = New List(Of Control)()
        End Sub

        Public Sub New(ctrls As List(Of Control))
            ReportElements = ctrls
            'mTopSortedControls = ElementSortByTop(Controls)
            'mTopLeftSortedControls = ElementSortByTopLeft(Controls)
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

        Public Property ReportElements As List(Of Control)
            Get
                Return mTopLeftSortedControls
            End Get
            Set(value As List(Of Control))
                mTopLeftSortedControls = ElementSortByTopLeft(value)
                mTopSortedControls = ElementSortByTop(value)
            End Set
        End Property

        Public Property EnteredControl As Control

        Public Sub FormMouseDown(sender As Object, e As MouseEventArgs)
            ' Clears the selected control when clicking on the form background.
            If Me.SelectedControl IsNot Nothing Then
                Me.SelectedControl.Invalidate()
                Me.SelectedControl = Nothing
            End If
        End Sub

        Public Property GridSize As Integer = 0

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
End Module
