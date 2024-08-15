Imports System.Data.SqlServerCe

Public Class Repeated_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load : Initializes the Repeated tasks view
    Private Sub Repeated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Handling"

    ' Load important tasks onto the CheckedListBox.
    Public Sub LoadTasksToRepeatedView()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE RepeatedDays IS NOT NULL;"

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()
                Using transaction = connection.BeginTransaction
                    Using command As New SqlCeCommand(query, connection)
                        Using adapter As New SqlCeDataAdapter(command)
                            adapter.Fill(dt)
                        End Using
                    End Using
                    transaction.Commit()
                End Using
            End Using
            dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}
            Repeated_CheckedListBox.Items.Clear()

            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
                Repeated_CheckedListBox.Items.Add(item, item.IsDone)
            Next

        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    ' Clear any selected task when entering the text box
    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
    End Sub

    ' KeyDown event to add a new task when pressing the Enter key
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            AddNewRepeatedTask()
        End If
    End Sub

    ' Event handler for changing the selected task in the CheckedListBox
    Private Sub Repeated_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Repeated_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Repeated_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Repeated_CheckedListBox.SelectedItem

            ' Update the Important button icon based on the task's importance status
            If IsTaskImportant() Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If
        End If
    End Sub

    ' Event handler for deleting a selected task when the delete button is clicked
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub

    ' Event handler for deleting a selected task when the Delete key is pressed
    Private Sub Repeated_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Repeated_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Repeated_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub

    ' ItemCheck event to update the 'IsDone' status of the selected task
    Private Sub Repeated_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Repeated_CheckedListBox.ItemCheck
        If Views._isUiUpdating Then
            Exit Sub
        End If

        If SelectedTaskItem IsNot Nothing Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        End If
        Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Click event for toggling the importance status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Task.ImportantCheckChanged(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                Task.ImportantCheckChanged(CheckState.Checked, SelectedTaskItem.ID)
            End If
            Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
        Else
            LoseListItemFocus()
        End If
    End Sub

    ' Click event for hiding the task properties panel
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    ' Right-click event to toggle the visibility of the task properties panel
    Private Sub Repeated_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Repeated_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    ' MouseEnter event to temporarily display the Important icon when hovering over the button
    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        End If
    End Sub

    ' MouseLeave event to revert the Important icon when the mouse leaves the button
    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
        End If
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If SelectedTaskItem Is Nothing Then
            Exit Sub
        End If
        If e.Button = MouseButtons.Left Then
            Dim Reminder_DialogInstance = New Reminder_Dialog With {.Reminder_SelectedTaskID = SelectedTaskItem.ID, .NeedsDatePicker = False}

            Reminder_DialogInstance.ShowDialog()
            Reminder_DialogInstance.BringToFront()

            If Repeated_CheckedListBox.Items.Count > 0 Then
                Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If

            Reminder_DialogInstance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip1, CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_Click(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If SelectedTaskItem Is Nothing Then
            Exit Sub
        End If
        If e.Button = MouseButtons.Left Then
            Dim Repeat_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = SelectedTaskItem.ID}

            Repeat_DialogInstance.ShowDialog()
            Repeat_DialogInstance.BringToFront()

            If Repeated_CheckedListBox.Items.Count > 0 Then
                Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If

            Repeat_DialogInstance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip2, CustomButton_Repeat)
        End If
    End Sub

    ' Clear selected task after leaving the View
    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left R")
        'MsgBox("R SelectedItemIndex = " & Repeated_CheckedListBox.SelectedIndex)
    End Sub

#End Region

#Region "Helper Methods"

    ' Task.AddNewTasks.Repeated method invoker
    Private Sub AddNewRepeatedTask()
        Dim newTask As String = AddNewTask_TextBox.Text
        If String.IsNullOrWhiteSpace(newTask) Then Exit Sub ' Ensure the task is not empty. If empty -> exit method

        Dim NewTaskId As Integer = Task.AddNewTasks.Repeated(newTask) ' Add the new task to the database and get its ID

        ' Prompt to add repeat frequency
        Dim DueDate_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = NewTaskId}
        DueDate_DialogInstance.ShowDialog()
        DueDate_DialogInstance.BringToFront()
        DueDate_DialogInstance.Dispose()

        ' Select the newly added task
        For i As Integer = 0 To Repeated_CheckedListBox.Items.Count - 1
            If Repeated_CheckedListBox.Items(i).ID = NewTaskId Then
                Repeated_CheckedListBox.SelectedIndex = i
                Exit For
            End If
        Next

        AddNewTask_TextBox.Clear() ' Clear the input field
    End Sub

    ' Task.DeleteTask method invoker
    Private Sub DeleteSelectedTask()
        If SelectedTaskItem Is Nothing Then
            MessageBox.Show("No task is selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Task.DeleteTask(SelectedTaskItem.ID)

            ' Adjust the selected task index after deletion
            If Repeated_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= Repeated_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = Repeated_CheckedListBox.Items.Count - 1
                End If
                Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Check if the selected task is important
    Private Function IsTaskImportant() As Boolean
        Try
            If SelectedTaskItem.ID <= 0 Then
                Return False
            End If

            ' Find the task in the DataTable
            Dim foundRow As DataRow = dt.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ' Show or hide the task properties panel
    Private Sub ShowOrHideTaskProperties(action As Views.TaskPropertiesVisibility)
        Select Case action
            Case TaskPropertiesVisibility.Show
                IsTaskPropertiesVisible = True
            Case TaskPropertiesVisibility.Hide
                IsTaskPropertiesVisible = False
            Case TaskPropertiesVisibility.Toggle
                IsTaskPropertiesVisible = Not IsTaskPropertiesVisible
        End Select

        If IsTaskPropertiesVisible Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 75%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 25%
        Else
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 100%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 0%
        End If
    End Sub

    ' Lose CheckedListBox item selection/focus
    Private Sub LoseListItemFocus()
        Repeated_CheckedListBox.SelectedItem = Nothing
        Repeated_CheckedListBox.SelectedIndex = -1
    End Sub

    Private Sub ShowContextMenuCentered(contextMenu As ContextMenuStrip, control As Control)
        ' Calculate the center position of the control on the screen
        Dim buttonCenterScreenPosition As Point = control.PointToScreen(New Point(control.Width / 2, control.Height / 2))

        ' Calculate the location to show the ContextMenuStrip centered over the control
        Dim contextMenuPosition As New Point(buttonCenterScreenPosition.X - (contextMenu.Width / 2), buttonCenterScreenPosition.Y - (contextMenu.Height / 2))

        ' Show the ContextMenuStrip at the calculated position
        contextMenu.Show(contextMenuPosition)
    End Sub

#End Region

    Public Sub DisableTaskProperties(Disable As Boolean)
        If Disable Then
            TaskTitle_TextBox.Text = Nothing
            Label_TaskEntryDateTime.Text = Nothing
            Important_Button.BackgroundImage = ImageCache.DisabledImportantIcon

            If My.Settings.ColorScheme = "Dark" Then
                TaskTitle_TextBox.BackColor = Color.FromArgb(30, 30, 30)
                TaskDescription_RichTextBox.Hide()
            End If
            TaskTitle_TextBox.Enabled = False
            TaskDescription_RichTextBox.Text = Nothing
            TaskDescription_RichTextBox.Enabled = False

            Label_ADT.Enabled = False
            Label_TaskEntryDateTime.Enabled = False
            Important_Button.Enabled = False

            CustomButton_AddReminder.Enabled = False
            CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton

            CustomButton_Repeat.Enabled = False
            CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton

            Button_DeleteTask.Enabled = False

        Else
            If My.Settings.ColorScheme = "Dark" Then
                TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                TaskDescription_RichTextBox.Show()
            End If
            TaskTitle_TextBox.Enabled = True
            TaskDescription_RichTextBox.Enabled = True
            Label_ADT.Enabled = True
            Label_TaskEntryDateTime.Enabled = True
            Important_Button.Enabled = True
            CustomButton_Repeat.Enabled = True
            CustomButton_AddReminder.Enabled = True
            Button_DeleteTask.Enabled = True
        End If
    End Sub
End Class