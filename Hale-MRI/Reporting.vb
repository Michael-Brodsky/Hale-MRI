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
            mTopSortedControls = ControlsSortByTop(controls)
            mTopLeftSortedControls = ControlsSortByTopLeft(controls)
        End Sub

        Public Sub ControlDragDrop(sender As Object, e As MouseEventArgs)
            ' Finalizes the drag-and-drop operation for the control being dragged.
            ControlDrop(CType(sender, Control), 10)
            mIsDragging = False
        End Sub

        Public Sub ControlDragMove(sender As Object, e As MouseEventArgs)
            ' Handles the drag-and-drop operation for moving the control being dragged.
            If mIsDragging Then
                Dim currentControl As Control = CType(sender, Control)
                Dim newX As Integer = currentControl.Left + (e.X - mDragStartPos.X)
                Dim newY As Integer = currentControl.Top + (e.Y - mDragStartPos.Y)
                currentControl.Location = New Point(newX, newY)
            End If
        End Sub

        Public Sub ControlDragStart(sender As Object, e As MouseEventArgs)
            ' Initiates a drag-and-drop operation for the control being dragged.
            mIsDragging = True
            mDragStartPos = e.Location
            mLastControlPos = CType(sender, Control).Location
        End Sub

        Private Sub ControlDrop(element As Control, gridSize As Integer)
            ' Snaps the element to the nearest grid position based on the specified grid size.
            For Each ctrl As Control In mTopSortedControls
                If ctrl IsNot element Then
                    If ControlIsAbove(element, ctrl) Then
                        ControlMoveAbove(element, ctrl, mTopSortedControls, 10)
                        Exit Sub
                    End If
                End If
            Next
            ControlReturnToLastPosition(element, mLastControlPos)
        End Sub

        Public Function ControlIsAbove(element As Control, other As Control) As Boolean
            ' Determines if 'element' control is above 'other' control based on Y coordinate.
            Return element.Location.Y < other.Location.Y
        End Function

        Private Sub ControlMoveAbove(element As Control, other As Control, elements As List(Of Control), gridSize As Integer)
            ' Moves the element above the other element in the list of elements.
            Dim otherIndex As Integer = elements.IndexOf(other)
            Dim otherLocation As Point = other.Location
            elements.Remove(element)
            elements.Insert(otherIndex, element)
            element.Location = otherLocation
            ' Reposition all lower elements based on their new order.
            For i = otherIndex + 1 To elements.Count - 1
                elements(i).Location = New Point(elements(i).Location.X, elements(i - 1).Location.Y + elements(i - 1).Height + gridSize)
            Next
        End Sub

        Private Sub ControlReturnToLastPosition(element As Control, lastPos As Point)
            ' Returns the element to its last known position.
            element.Location = lastPos
        End Sub

        Public Function ControlsSortByTop(elements As List(Of Control)) As List(Of Control)
            ' Sorts elements in ascending order of the Y coordinate.
            Dim sortedControls = elements.OrderBy(Function(c) c.Location.Y).ToList()
            Return sortedControls
        End Function

        Public Function ControlsSortByTopLeft(elements As List(Of Control)) As List(Of Control)
            'Sorts by Y and then X (lexicographical sort)
            Dim sortedControls = elements.OrderBy(Function(c) c.Location.Y).ThenBy(Function(c) c.Location.X).ToList()
            Return sortedControls
        End Function
    End Class
End Module
