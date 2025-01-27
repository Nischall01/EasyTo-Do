﻿Public Class Repeated_View

    Private RepeatedDT As New DataTable()
    Private RepeatedDT_TaskTitleOnly As New DataTable()

    Private SelectedTask_Item As TaskItem
    Private SelectedTask_Properties As TaskProperties
    Private SelectedTask_Index As Integer
    Private SelectedTask_ID As Integer

    Private IsTaskPropertiesVisible As Boolean

#Region "On Load"

    ' Initializes the form components and enables key preview for handling keyboard events at the form level. '
    Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    ' Form on load : Initializes the Repeated tasks view. '
    Private Sub Repeated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeRepeated()
    End Sub

    ' Initializes the Repeated tasks view. '
    Private Sub InitializeRepeated()
        Select Case SettingsCache.TaskPropertiesSidebarStateOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select

        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

#End Region

#Region "Data Loading Actions"

    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Repeated()
        RepeatedDT.Clear()
        RepeatedDT_TaskTitleOnly.Clear()

        Dim query As String
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks " &
            "WHERE RepeatedDays IS NOT NULL;"

        If SettingsCache.HideCompletedTasks Then
            query = "SELECT * FROM Tasks " &
            "WHERE RepeatedDays IS NOT NULL " &
            "AND IsDone = 0 " & ' Filter to show only incomplete tasks
            "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
            "ReminderDateTime, IsImportant DESC;"
        Else
            If SettingsCache.SortByCompletionStatus Then
                query = "SELECT * FROM Tasks " &
                "WHERE RepeatedDays IS NOT NULL " &
                "ORDER BY IsDone ASC, " &
                "CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            Else
                query = "SELECT * FROM Tasks " &
                "WHERE RepeatedDays IS NOT NULL " &
                "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            End If
        End If

        Using connection As New SqlCeConnection(SettingsCache.connectionString)
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

    ' Load repeated tasks onto the CheckedListBox.
    Public Sub LoadTasksToRepeatedView()
        LoadTasksToDataTables_Repeated()
        Repeated_CheckedListBox.BeginUpdate() ' Prevent UI from redrawing until complete
        Repeated_CheckedListBox.Items.Clear()

        For Each row As DataRow In RepeatedDT.Rows
            Dim taskDisplayName As String = row("Task")

            If Not row.IsNull("ReminderDateTime") Then
                Dim reminderDateTime As DateTime = row("ReminderDateTime")
                taskDisplayName = $"{reminderDateTime:(hh:mmtt)}".ToLower & $" {taskDisplayName}"
            End If

            If row("IsImportant") Then
                taskDisplayName = $"{GlobalResources.importantTaskIndicator} {taskDisplayName}"
            End If

            Dim taskItem As New TaskItem(taskDisplayName, row("TaskID"), row("IsDone"))
            Repeated_CheckedListBox.Items.Add(taskItem, taskItem.IsDone)
        Next

        Repeated_CheckedListBox.EndUpdate() ' UI refresh happens once after all items are added
    End Sub

#End Region

#Region "Task Properties Sidebar Management"

    ' Enum defining the different actions for managing the task properties sidebar.
    Public Enum TaskPropertiesSidebarAction
        DisableOnly
        HideOnly
        DisableAndHide
    End Enum

    ' This method allows external components to disable or hide the task properties sidebar.
    Public Sub DisableHide_TaskPropertiesSidebar(Optional action As TaskPropertiesSidebarAction = TaskPropertiesSidebarAction.DisableAndHide)
        Select Case action
            Case TaskPropertiesSidebarAction.DisableOnly
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
            Case TaskPropertiesSidebarAction.HideOnly
                MainWindow.ShowOrHide_TaskPropertiesSidebar(MainWindow.TaskPropertiesVisibility.Hide)
            Case TaskPropertiesSidebarAction.DisableAndHide
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
                MainWindow.ShowOrHide_TaskPropertiesSidebar(MainWindow.TaskPropertiesVisibility.Hide)
        End Select
    End Sub

    Private Sub EnableOrDisable_TaskPropertiesSidebar(State As TaskPropertiesState)
        Select Case State
            Case TaskPropertiesState.Disable
                TaskTitle_TextBox.Text = Nothing
                Label_TaskEntryDateTime.Text = Nothing
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Disabled

                DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Disabled
                CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Disabled
                CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Disabled

                If SettingsCache.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                    Important_Button.BackColor = Color.Transparent
                    TaskDescription_RichTextBox.Hide()
                Else
                    Important_Button.BackColor = Color.Transparent
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

                DeleteTask_Button.Enabled = False
            Case TaskPropertiesState.Enable
                If SettingsCache.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(30, 30, 30)
                    Important_Button.BackColor = Color.FromArgb(21, 21, 21)
                    TaskDescription_RichTextBox.Show()

                    DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White

                    CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                    CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White
                Else
                    Important_Button.BackColor = Color.FromArgb(234, 234, 234)

                    DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black

                    CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                    CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black
                End If
                TaskTitle_TextBox.Enabled = True
                Label_ADT.Enabled = True
                Label_TaskEntryDateTime.Enabled = True
                Important_Button.Enabled = True
                CustomButton_AddReminder.Enabled = True
                CustomButton_Repeat.Enabled = True
                TaskDescription_RichTextBox.Enabled = True
                DeleteTask_Button.Enabled = True
        End Select
    End Sub

#End Region

    ' It updates the UI with the details of the selected task, including the task title, entry date/time, importance status,
    ' description, reminder time, and repeat frequency. If no task is selected, the task properties are disabled and cleared.
    Private Sub LoadSelectedTaskProperties()
        SelectedTask_Properties = TaskManager.GetTaskProperties(SelectedTask_ID, RepeatedDT)

        If SelectedTask_Properties Is Nothing Then
            ' Handle the case where task details are not found
            MsgBox("Task details not found.")
            Exit Sub
        End If

        ' Cache task details to avoid multiple lookups
        Dim isImportant As Boolean = SelectedTask_Properties.IsImportant
        Dim taskDescription As String = SelectedTask_Properties.Description
        Dim reminderDateTime As String = SelectedTask_Properties.ReminderDateTime
        Dim repeatFrequency As String = SelectedTask_Properties.RepeatFrequency

        ' Enable task properties sidebar
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Enable)

        ' Set task title
        TaskTitle_TextBox.Text = SelectedTask_Properties.Title

        ' Set task entry date and time
        Label_TaskEntryDateTime.Text = SelectedTask_Properties.EntryDateTime

        ' Update important icon
        If SettingsCache.ColorScheme = "Dark" Then
            Important_Button.BackgroundImage = If(isImportant, GlobalResources.ImportantIcon_Checked, GlobalResources.ImportantIcon_Unchecked_White)
        Else
            Important_Button.BackgroundImage = If(isImportant, GlobalResources.ImportantIcon_Checked, GlobalResources.ImportantIcon_Unchecked_Black)
        End If

        ' Update task description
        If String.IsNullOrEmpty(taskDescription) Then
            TaskDescription_RichTextBox.ForeColor = Color.Gray
            TaskDescription_RichTextBox.Text = TextPlaceholders.Description
        Else
            TaskDescription_RichTextBox.ForeColor = If(SettingsCache.ColorScheme = "Dark", Color.Pink, Color.Black)
            TaskDescription_RichTextBox.Text = taskDescription
        End If

        ' Update reminder button text
        CustomButton_AddReminder.ButtonText = If(String.IsNullOrEmpty(reminderDateTime), TextPlaceholders.AddReminderButton, reminderDateTime)

        ' Update repeat button text
        CustomButton_Repeat.ButtonText = If(String.IsNullOrEmpty(repeatFrequency), TextPlaceholders.RepeatButton, repeatFrequency)
    End Sub

#Region "Event Handlers"

    ' Event handler triggered when the user selects a task from the Repeated_CheckedListBox.
    Private Sub Repeated_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Repeated_CheckedListBox.SelectedIndexChanged
        SelectedTask_Index = Repeated_CheckedListBox.SelectedIndex

        If SelectedTask_Index <> -1 Then
            SelectedTask_Item = Repeated_CheckedListBox.SelectedItem
            SelectedTask_ID = SelectedTask_Item.ID
            LoadSelectedTaskProperties()
        Else
            DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
        End If
    End Sub

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        UiUtils.TaskSelection_Clear(Me.Repeated_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Repeated_CheckedListBox)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Repeated_CheckedListBox)
    End Sub

    Private Sub Repeated_Label_Click(sender As Object, e As EventArgs) Handles RepeatedView_Label.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Repeated_CheckedListBox)
    End Sub

    Private Sub TaskTitle_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskTitle_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If TaskTitle_TextBox.Text Is String.Empty Then
                ViewsManager.RefreshTasks()
            Else
                TaskManager.UpdateTitle(SelectedTask_ID, TaskTitle_TextBox.Text)
            End If
            Me.ActiveControl = Nothing
            UiUtils.TaskSelection_Retain(Me.Repeated_CheckedListBox, SelectedTask_ID)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TaskDescription_Enter(sender As Object, e As EventArgs) Handles TaskDescription_RichTextBox.Enter
        If SettingsCache.ColorScheme = "Dark" Then
            TaskDescription_RichTextBox.ForeColor = Color.White
        ElseIf SettingsCache.ColorScheme = "Light" Then
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
                TaskManager.UpdateDescription(SelectedTask_ID, TaskDescription_RichTextBox.Text)
                Me.ActiveControl = Nothing
                Repeated_CheckedListBox.SelectedIndex = SelectedTask_Index
            End If
        End If
    End Sub

    ' KeyDown event to add a new task when pressing the Enter key
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrWhiteSpace(AddNewTask_TextBox.Text) Then Exit Sub
            Dim NewTaskId As Integer = TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.Repeated_CheckedListBox, ViewName.Repeated)
            TaskManager.ShowRepeatDialog(NewTaskId, Me.Repeated_CheckedListBox, True)
            If Repeated_CheckedListBox.Items.Count = 1 Then
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            End If
        End If
    End Sub

    Private Sub DeleteTask_Button_Click(sender As Object, e As EventArgs) Handles DeleteTask_Button.Click
        Me.ActiveControl = Nothing
        If Repeated_CheckedListBox.SelectedIndex = -1 Or Repeated_CheckedListBox.Items.Count = 0 Or SelectedTask_Item Is Nothing Then Exit Sub

        If SettingsCache.OnDeleteAskForConfirmation Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then
                Exit Sub
            End If
        End If
        TaskManager.DeleteTask(SelectedTask_ID, Me.Repeated_CheckedListBox, SelectedTask_Index, ViewName.Repeated)

        If Repeated_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Delete Then
            DeleteTask_Button.PerformClick()
        End If
    End Sub

    ' Event handler for deleting a selected task when the Delete key is pressed
    Private Sub Repeated_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Repeated_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Repeated_CheckedListBox.SelectedIndex <> -1 Then
            TaskManager.DeleteTask(SelectedTask_ID, Me.Repeated_CheckedListBox, SelectedTask_Index, ViewName.Repeated)
        End If
    End Sub

    ' ItemCheck event to update the 'IsDone' status of the selected task
    Private Async Sub Repeated_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Repeated_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then Exit Sub

        ' Store the current index before making changes
        Dim previousIndex As Integer = SelectedTask_Index

        ' Update the task status based on the checkbox state
        TaskManager.UpdateStatus(e.NewValue = CheckState.Checked, SelectedTask_ID)

        If e.NewValue = CheckState.Checked Then
            SFXPlayer.Play()
        End If

        Await Task.Delay(10)
        UiUtils.TaskSelection_Clear(Repeated_CheckedListBox)
        ViewsManager.RefreshTasks()
        Me.ActiveControl = Me.AddNewTask_TextBox
    End Sub

    ' Click event for toggling the importance status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        Me.ActiveControl = Nothing
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTask_ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTask_ID)
            End If
            UiUtils.TaskSelection_Retain(Repeated_CheckedListBox, SelectedTask_ID)
        Else
            UiUtils.TaskSelection_Clear(Repeated_CheckedListBox)
        End If
    End Sub

    ' Click event for hiding the task properties panel
    Private Sub CloseTaskProperties_Button_Click(sender As Object, e As EventArgs) Handles CloseTaskProperties_Button.Click
        Me.ActiveControl = Nothing
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
    End Sub

    ' Right-click event to toggle the visibility of the task properties panel
    Private Sub Repeated_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Repeated_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    ' MouseEnter event to temporarily display the Important icon when hovering over the button
    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Checked
        End If
    End Sub

    ' MouseLeave event to revert the Important icon when the mouse leaves the button
    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                Exit Sub
            End If

            If SettingsCache.ColorScheme = "Dark" Then
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Unchecked_White
            Else
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Unchecked_Black
            End If
        End If
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowReminderDialog(SelectedTask_ID, Me.Repeated_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip1, Me.CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowRepeatDialog(SelectedTask_ID, Me.Repeated_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip2, Me.CustomButton_Repeat)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TaskManager.RemoveReminder(SelectedTask_ID, Me.Repeated_CheckedListBox, SelectedTask_Index)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TaskManager.RemoveRepeat(SelectedTask_ID, Me.Repeated_CheckedListBox, SelectedTask_Index, ViewName.Repeated)
        If Repeated_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    ' Clear selected task after leaving the View
    Private Sub Repeated_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.TaskSelection_Clear(Repeated_CheckedListBox)
        'MsgBox("Left Repeated view")
        'MsgBox("SelectedItemIndex = " & Repeated_CheckedListBox.SelectedIndex)
    End Sub

    Private Sub DeleteTask_Button_MouseEnter(sender As Object, e As EventArgs) Handles DeleteTask_Button.MouseEnter
        DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Hover
    End Sub

    Private Sub DeleteTask_Button_MouseLeave(sender As Object, e As EventArgs) Handles DeleteTask_Button.MouseLeave
        If SettingsCache.ColorScheme = "Dark" Then
            DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
        Else
            DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
        End If
    End Sub

#End Region

End Class