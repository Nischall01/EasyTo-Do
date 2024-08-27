﻿Public Class Repeated_View
    Private connectionString As String = My.Settings.ConnectionString
    Private RepeatedDT As New DataTable()
    Private RepeatedDT_TaskTitleOnly As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load : Initializes the Repeated tasks view
    Private Sub Repeated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeRepeated()
    End Sub

    Private Sub InitializeRepeated()
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select

        DisableTaskProperties(True)
    End Sub
#End Region

#Region "Data Loading Actions"
    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Repeated()
        RepeatedDT.Clear()
        RepeatedDT_TaskTitleOnly.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE RepeatedDays IS NOT NULL;"
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks WHERE RepeatedDays IS NOT NULL;"

        Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(RepeatedDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(RepeatedDT_TaskTitleOnly)
                End Using
            End Using
        End Using

        RepeatedDT.PrimaryKey = New DataColumn() {RepeatedDT.Columns("TaskID")}
        RepeatedDT_TaskTitleOnly.PrimaryKey = New DataColumn() {RepeatedDT_TaskTitleOnly.Columns("TaskID")}
    End Sub


    ' Load important tasks onto the CheckedListBox.
    Public Sub LoadTasksToRepeatedView()
        LoadTasksToDataTables_Repeated()
        Repeated_CheckedListBox.Items.Clear()

        For Each row As DataRow In RepeatedDT.Rows
            If Not row.IsNull("ReminderDateTime") AndAlso TypeOf row("ReminderDateTime") Is DateTime Then
                Dim RemindedTask As String = row("Task")
                Dim reminderDateTime As DateTime = row.Field(Of DateTime)("ReminderDateTime")
                row("Task") = reminderDateTime.ToString("(hh:mmtt)").ToLower() + "  " + RemindedTask
            End If

            If row("IsImportant") Then
                Dim ImportantTask As String = "!" + "  " + row("Task")
                row("Task") = ImportantTask
            End If

            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            Repeated_CheckedListBox.Items.Add(item, item.IsDone)
        Next
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

    Private Sub ShowOrHideTaskProperties(action As TaskPropertiesVisibility)
        Select Case action
            Case TaskPropertiesVisibility.Show
                IsTaskPropertiesVisible = True
            Case TaskPropertiesVisibility.Hide
                IsTaskPropertiesVisible = False
            Case TaskPropertiesVisibility.Toggle
                IsTaskPropertiesVisible = Not IsTaskPropertiesVisible
        End Select
        UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, Me.MainTlp)
    End Sub

#Region "Event Handlers"

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        UiUtils.ClearListItemSelection(Me.Repeated_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.ClearListItemSelection(Me.Repeated_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.ClearListItemSelection(Me.Repeated_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub MyDay_Label_Click(sender As Object, e As EventArgs) Handles Repeated_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.ClearListItemSelection(Me.Repeated_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub TaskDescription_Enter(sender As Object, e As EventArgs) Handles TaskDescription_RichTextBox.Enter
        If My.Settings.ColorScheme = "Dark" Then
            TaskDescription_RichTextBox.ForeColor = Color.White
        ElseIf My.Settings.ColorScheme = "Light" Then
            TaskDescription_RichTextBox.ForeColor = Color.FromArgb(69, 69, 69)
        End If
        If TaskDescription_RichTextBox.Text = TextPlaceholders.Description Then
            TaskDescription_RichTextBox.Text = String.Empty
        End If
    End Sub

    Private Sub TaskDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskDescription_RichTextBox.KeyDown
        ' Check if Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            ' Check if Shift key is also pressed
            If e.Shift Then
                ' Allow default behavior (new line)
            Else
                ' Prevent the default behavior
                e.SuppressKeyPress = True
                TaskManager.UpdateDescription(TaskDescription_RichTextBox.Text, SelectedTaskItem.ID)

                If Repeated_CheckedListBox.Items.Count > 0 Then
                    Me.ActiveControl = Nothing
                    Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
                End If
            End If
        End If
    End Sub

    ' KeyDown event to add a new task when pressing the Enter key
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.Repeated_CheckedListBox, ViewName.Repeated)
        End If
    End Sub

    ' Event handler for changing the selected task in the CheckedListBox
    Private Sub Repeated_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Repeated_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Repeated_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Repeated_CheckedListBox.SelectedItem

            DisableTaskProperties(False)
            TaskTitle_TextBox.Text = TaskManager.GetTaskString(SelectedTaskItem.ID, RepeatedDT_TaskTitleOnly)

            Label_TaskEntryDateTime.Text = TaskManager.GetTaskEntryDateTimeString(SelectedTaskItem.ID, RepeatedDT)

            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, RepeatedDT) Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If

            If TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, RepeatedDT) <> String.Empty Then
                If My.Settings.ColorScheme = "Dark" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Pink
                ElseIf My.Settings.ColorScheme = "Light" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Black
                End If
                TaskDescription_RichTextBox.Text = TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, RepeatedDT)
            Else
                TaskDescription_RichTextBox.ForeColor = Color.Gray
                TaskDescription_RichTextBox.Text = TextPlaceholders.Description
            End If

            Dim ReminderTime As String = TaskManager.GetReminderString(SelectedTaskItem.ID, RepeatedDT)
            If ReminderTime <> String.Empty Then
                CustomButton_AddReminder.ButtonText = ReminderTime
            Else
                CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton
            End If

            Dim RepeatFrequency As String = TaskManager.GetRepeatString(SelectedTaskItem.ID, RepeatedDT)
            If RepeatFrequency <> String.Empty Then
                CustomButton_Repeat.ButtonText = RepeatFrequency
            Else
                CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton
            End If
        Else
            DisableTaskProperties(True)
            TaskTitle_TextBox.Clear()
        End If
    End Sub

    ' Event handler for deleting a selected task when the delete button is clicked
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            TaskManager.DeleteTask(SelectedTaskItem.ID)
        End If
    End Sub

    ' Event handler for deleting a selected task when the Delete key is pressed
    Private Sub Repeated_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Repeated_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Repeated_CheckedListBox.SelectedIndex <> -1 Then
            TaskManager.DeleteTask(SelectedTaskItem.ID)
        End If
    End Sub

    ' ItemCheck event to update the 'IsDone' status of the selected task
    Private Sub Repeated_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Repeated_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then
            Exit Sub
        End If

        If SelectedTaskItem IsNot Nothing Then
            TaskManager.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        End If
        Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Click event for toggling the importance status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, RepeatedDT) Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTaskItem.ID)
            End If
            Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
        Else
            UiUtils.ClearListItemSelection(Repeated_CheckedListBox)
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
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, RepeatedDT) Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        End If
    End Sub

    ' MouseLeave event to revert the Important icon when the mouse leaves the button
    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, RepeatedDT) Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
        End If
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowReminderDialog(SelectedTaskItem.ID, SelectedTaskIndex, Me.Repeated_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip1, Me.CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowRepeatDialog(SelectedTaskItem.ID, SelectedTaskIndex, Me.Repeated_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip2, Me.CustomButton_Repeat)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TaskManager.RemoveReminder(SelectedTaskItem.ID)
        Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TaskManager.RemoveRepeat(SelectedTaskItem.ID)
        Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Clear selected task after leaving the View
    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.ClearListItemSelection(Repeated_CheckedListBox)
        'MsgBox("Left R")
        'MsgBox("R SelectedItemIndex = " & Repeated_CheckedListBox.SelectedIndex)
    End Sub

#End Region
End Class