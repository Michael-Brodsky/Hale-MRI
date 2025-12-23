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
        Private mLastControlPos As Point                    ' The last known position of the control being dragged.
        Private mTopSortedControls As List(Of Control)      ' The list of controls sorted by their top (Y) position.
        Private mTopLeftSortedControls As List(Of Control)  ' The list of controls sorted by their top (Y) and left (X) position.
        Public Sub New(controls As List(Of Control))
            mTopSortedControls = ElementSortByTop(controls)
            mTopLeftSortedControls = ElementSortByTopLeft(controls)
        End Sub

        Public Sub ControlDragDrop(sender As Object, e As MouseEventArgs)
            ' Finalizes the drag-and-drop operation for the control being dragged.
            If mIsDragging Then
                '    ElementDrop(CType(sender, Control), 10)
                mIsDragging = False
            End If
        End Sub

        Public Sub ControlDragMove(sender As Object, e As MouseEventArgs)
            ' Handles the drag-and-drop operation for moving the control being dragged.
            If mIsDragging AndAlso SelectedControl IsNot Nothing Then
                SelectedControl.Invalidate()
                Dim newX As Integer = SelectedControl.Left + (e.X - mDragStartPos.X)
                Dim newY As Integer = SelectedControl.Top + (e.Y - mDragStartPos.Y)
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
            ' Sets the selected control when the mouse enters the control area.
            'Me.EnteredControl = CType(sender, Control)
            'Me.EnteredControl.Invalidate()
        End Sub
        Public Sub ControlLeave(sender As Object, e As EventArgs)
            ' Clears the selected control when the mouse leaves the control area.
            'Dim currentControl As Control = CType(sender, Control)
            'If currentControl Is Me.SelectedControl Then
            '    Me.SelectedControl = Nothing
            '    currentControl.Invalidate()
            'End If
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

        Public Sub ControlSelect(sender As Object, e As EventArgs)
            ' Sets the selected control.
            Dim currentControl As Control = CType(sender, Control)
            If Me.SelectedControl IsNot Nothing Then Me.SelectedControl.Invalidate()
            Me.SelectedControl = currentControl
            Me.SelectedControl.Invalidate()
        End Sub

        Public Property EnteredControl As Control

        Public Property SelectedControl As Control

        Private Sub ElementDrop(element As Control, gridSize As Integer)
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
