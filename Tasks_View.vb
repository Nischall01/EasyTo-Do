Public Class Tasks_View

    Private TasksDT As New DataTable()
    Private TasksDT_TaskTitleOnly As New DataTable()

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
    Private Sub Tasks_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeTasks()
        InitializeReminder()
    End Sub

    ' Initializes the Repeated tasks view. '
    Private Sub InitializeTasks()
        Select Case SettingsCache.TaskPropertiesSidebarStateOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select

        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    Private Sub InitializeReminder()
        ReminderTimer.Interval = 1000 ' Interval set to 1 seconds
        ReminderTimer.Start() ' Start the Timer

        ReminderNotification.Text = "EasyTo_do"
        ReminderNotification.Icon = My.Resources.EasyToDo_Icon
        ReminderNotification.Visible = True
    End Sub

#End Region

#Region "Data Loading Actions"

    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Tasks()
        TasksDT.Clear()
        TasksDT_TaskTitleOnly.Clear()

        Dim query As String
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks;"

        If SettingsCache.HideCompletedTasks Then
            query = "SELECT * FROM Tasks " &
            "Where IsDone = 0 " & ' Filter to show only incomplete tasks
            "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
            "ReminderDateTime, IsImportant DESC;"
        Else
            If SettingsCache.SortByCompletionStatus Then
                query = "SELECT * FROM Tasks " &
                "ORDER BY IsDone ASC, " &
                "CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            Else
                query = "SELECT * FROM Tasks " &
                "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            End If
        End If

        Using connection As New SqlCeConnection(SettingsCache.connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(TasksDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(TasksDT_TaskTitleOnly)
                End Using
            End Using
        End Using

        TasksDT.PrimaryKey = New DataColumn() {TasksDT.Columns("TaskID")}
        TasksDT_TaskTitleOnly.PrimaryKey = New DataColumn() {TasksDT_TaskTitleOnly.Columns("TaskID")}
    End Sub

    ' Load tasks onto the CheckedListBox
    Public Sub LoadTasksToTasksView()
        LoadTasksToDataTables_Tasks()
        Tasks_CheckedListBox.BeginUpdate() ' Prevent UI from redrawing until complete
        Tasks_CheckedListBox.Items.Clear()

        For Each row As DataRow In TasksDT.Rows
            Dim taskDisplayName As String = row("Task").ToString()

            ' Format reminder time
            If Not row.IsNull("ReminderDateTime") Then
                Dim reminderDateTime As DateTime = row("ReminderDateTime")
                taskDisplayName = $"{reminderDateTime:(hh:mmtt)}".ToLower & $" {taskDisplayName}"
            End If

            If Not row.IsNull("RepeatedDays") Then
                taskDisplayName = $"{taskDisplayName} {GlobalResources.repeatedTaskIndicator}"
            End If

            ' Format due date
            If Not row.IsNull("DueDate") Then
                Dim dueDate As DateTime = row("DueDate")

                If dueDate = DateTime.Today Then
                    taskDisplayName = $"(Today) {taskDisplayName}"
                Else
                    taskDisplayName = $"{dueDate:(dd/MM)} {taskDisplayName}" ' Adds due date in dd/MM format
                End If
            End If

            ' Mark task as important
            If row("IsImportant") Then
                taskDisplayName = $"{GlobalResources.importantTaskIndicator} {taskDisplayName}" ' Adds '!' to mark important tasks
            End If

            ' Add the task to the list
            Dim taskItem As New TaskItem(taskDisplayName, row("TaskID"), row.Field(Of Boolean)("IsDone"))
            Tasks_CheckedListBox.Items.Add(taskItem, taskItem.IsDone)
        Next

        Tasks_CheckedListBox.EndUpdate() ' UI refresh happens once after all items are added
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
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
            Case TaskPropertiesSidebarAction.DisableAndHide
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

    Private Sub EnableOrDisable_TaskPropertiesSidebar(State As TaskPropertiesState)
        Select Case State
            Case TaskPropertiesState.Disable
                TaskTitle_TextBox.Text = Nothing
                Label_TaskEntryDateTime.Text = Nothing
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Disabled

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

                CustomButton_AddDueDate.Enabled = False
                CustomButton_AddDueDate.ButtonText = TextPlaceholders.DueDateButton

                DeleteTask_Button.Enabled = False
            Case TaskPropertiesState.Enable
                If SettingsCache.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(30, 30, 30)
                    Important_Button.BackColor = Color.FromArgb(21, 21, 21)
                    TaskDescription_RichTextBox.Show()
                Else
                    Important_Button.BackColor = Color.FromArgb(234, 234, 234)
                End If
                TaskTitle_TextBox.Enabled = True
                Label_ADT.Enabled = True
                Label_TaskEntryDateTime.Enabled = True
                Important_Button.Enabled = True
                CustomButton_AddReminder.Enabled = True
                CustomButton_Repeat.Enabled = True
                CustomButton_AddDueDate.Enabled = True
                TaskDescription_RichTextBox.Enabled = True
                DeleteTask_Button.Enabled = True
        End Select
    End Sub

#End Region

    ' It updates the UI with the details of the selected task, including the task title, entry date/time, importance status,
    ' description, reminder time, and repeat frequency. If no task is selected, the task properties are disabled and cleared.
    Private Sub LoadSelectedTaskProperties()
        SelectedTask_Properties = TaskManager.GetTaskProperties(SelectedTask_ID, TasksDT)

        If SelectedTask_Properties Is Nothing Then
            ' Handle the case where task details are not found
            MsgBox("Task details not found.")
            Exit Sub
        End If

        ' Cache task details to avoid multiple lookups
        Dim title As String = SelectedTask_Properties.Title
        Dim entryDateTime As String = SelectedTask_Properties.EntryDateTime
        Dim isImportant As Boolean = SelectedTask_Properties.IsImportant
        Dim taskDescription As String = SelectedTask_Properties.Description
        Dim reminderDateTime As String = SelectedTask_Properties.ReminderDateTime
        Dim repeatFrequency As String = SelectedTask_Properties.RepeatFrequency
        Dim isRepeated As Boolean = SelectedTask_Properties.IsRepeated
        Dim dueDate As String = SelectedTask_Properties.DueDate

        ' Enable task properties sidebar
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Enable)

        ' Set task title
        TaskTitle_TextBox.Text = title

        ' Set task entry date and time
        Label_TaskEntryDateTime.Text = entryDateTime

        ' Update important icon
        If SettingsCache.ColorScheme = "Dark" Then
            Important_Button.BackgroundImage = If(isImportant, GlobalResources.ImportantIcon_Checked, GlobalResources.ImportantIcon_Unchecked_White)
        Else
            Important_Button.BackgroundImage = If(isImportant, GlobalResources.ImportantIcon_Checked, GlobalResources.ImportantIcon_Unchecked_Black)
        End If

        ' Disable or enable due date button based on task repetition
        CustomButton_AddDueDate.Enabled = Not isRepeated

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

        ' Update due date button text
        CustomButton_AddDueDate.ButtonText = If(String.IsNullOrEmpty(dueDate), TextPlaceholders.DueDateButton, dueDate)
    End Sub

#Region "Event Handlers"

    ' Event handler triggered when the user selects a task from the Tasks_CheckedListBox.
    Private Sub Tasks_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tasks_CheckedListBox.SelectedIndexChanged
        SelectedTask_Index = Tasks_CheckedListBox.SelectedIndex

        If SelectedTask_Index <> -1 Then
            SelectedTask_Item = Tasks_CheckedListBox.SelectedItem
            SelectedTask_ID = SelectedTask_Item.ID
            LoadSelectedTaskProperties()
        End If
    End Sub

    ' Add new task '
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrWhiteSpace(AddNewTask_TextBox.Text) Then Exit Sub
            TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.Tasks_CheckedListBox, ViewName.Tasks)
            If Tasks_CheckedListBox.Items.Count = 1 Then
                MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            End If
        End If
    End Sub

    ' ItemCheck event to change the 'IsDone' status of the selected task
    Private Async Sub Tasks_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Tasks_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then Exit Sub

        ' Store the current index before making changes
        Dim previousIndex As Integer = SelectedTask_Index

        ' Update the task status based on the checkbox state
        TaskManager.UpdateStatus(e.NewValue = CheckState.Checked, SelectedTask_ID)

        If e.NewValue = CheckState.Checked Then
            SFXPlayer.Play()
        End If

        Await Task.Delay(10)
        UiUtils.TaskSelection_Clear(Tasks_CheckedListBox)
        ViewsManager.RefreshTasks()
        Me.ActiveControl = Me.AddNewTask_TextBox
    End Sub

    ' Toggle the task's 'IsImportant' status when the important button is clicked
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        Me.ActiveControl = Nothing
        If Tasks_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTask_ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTask_ID)
            End If
            UiUtils.TaskSelection_Retain(Tasks_CheckedListBox, SelectedTask_ID)
        Else
            UiUtils.TaskSelection_Clear(Me.Tasks_CheckedListBox)
        End If
    End Sub

    ' Hide task properties panel
    Private Sub CloseTaskProperties_Button_Click(sender As Object, e As EventArgs) Handles CloseTaskProperties_Button.Click
        Me.ActiveControl = Nothing
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
    End Sub

    ' Toggle task properties panel on right-click
    Private Sub Tasks_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Tasks_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Toggle) ' Toggle the visibility of task properties
        End If
    End Sub

    ' MouseEnter event to temporarily display the Important icon when hovering over the button
    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Tasks_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Checked
        End If
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Tasks_CheckedListBox.SelectedIndex <> -1 Then
            If SelectedTask_Properties.IsImportant Then
                Exit Sub
            End If

            If SettingsCache.ColorScheme = "Dark" Then
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Unchecked_Black
            Else
                Important_Button.BackgroundImage = GlobalResources.ImportantIcon_Unchecked_White
            End If
        End If
    End Sub

    Private Sub DeleteTask_Button_Click(sender As Object, e As EventArgs) Handles DeleteTask_Button.Click
        Me.ActiveControl = Nothing
        If Tasks_CheckedListBox.SelectedIndex = -1 Or Tasks_CheckedListBox.Items.Count = 0 Or SelectedTask_Item Is Nothing Then
            Exit Sub
        End If

        If SettingsCache.onDeleteAskForConfirmation Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then
                Exit Sub
            End If
        End If
        TaskManager.DeleteTask(SelectedTask_ID, Me.Tasks_CheckedListBox, SelectedTask_Index, ViewName.Tasks)

        If Tasks_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Delete Then
            DeleteTask_Button.PerformClick()
        End If
    End Sub

    Private Sub Tasks_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.TaskSelection_Clear(Tasks_CheckedListBox)
        'MsgBox("Left Tasks view")
        'MsgBox("SelectedItemIndex = " & Tasks_CheckedListBox.SelectedIndex)
    End Sub

    ' Dispose of the NotifyIcon when the form is closed
    Private Sub Tasks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ReminderNotification.Dispose()
    End Sub

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        UiUtils.TaskSelection_Clear(Me.Tasks_CheckedListBox)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Tasks_CheckedListBox)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Tasks_CheckedListBox)
    End Sub

    Private Sub Tasks_Label_Click(sender As Object, e As EventArgs) Handles TasksView_Label.Click
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
        MainWindow.ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.Tasks_CheckedListBox)
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowReminderDialog(SelectedTask_ID, Me.Tasks_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip1, Me.CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowRepeatDialog(SelectedTask_ID, Me.Tasks_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip2, Me.CustomButton_Repeat)
        End If
    End Sub

    Private Sub CustomButton_DueDate_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddDueDate.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowDueDateDialog(SelectedTask_ID, SelectedTask_Index, Me.Tasks_CheckedListBox, ViewName.MyDay)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip3, Me.CustomButton_AddDueDate)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TaskManager.RemoveReminder(SelectedTask_ID, Me.Tasks_CheckedListBox, SelectedTask_Index)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TaskManager.RemoveRepeat(SelectedTask_ID, Me.Tasks_CheckedListBox, SelectedTask_Index, ViewName.MyDay)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        TaskManager.RemoveDueDate(SelectedTask_ID, Me.Tasks_CheckedListBox, SelectedTask_Index, ViewName.MyDay)
    End Sub

    Private Sub TaskTitle_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskTitle_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If TaskTitle_TextBox.Text Is String.Empty Then
                ViewsManager.RefreshTasks()
            Else
                TaskManager.UpdateTitle(SelectedTask_ID, TaskTitle_TextBox.Text)
            End If
            Me.ActiveControl = Nothing
            UiUtils.TaskSelection_Retain(Me.Tasks_CheckedListBox, SelectedTask_ID)
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
                Tasks_CheckedListBox.SelectedIndex = SelectedTask_Index
            End If
        End If
    End Sub

    Private Sub Button_DeleteTask_MouseEnter(sender As Object, e As EventArgs) Handles DeleteTask_Button.MouseEnter
        DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Hover
    End Sub

    Private Sub Button_DeleteTask_MouseLeave(sender As Object, e As EventArgs) Handles DeleteTask_Button.MouseLeave
        If My.Settings.ColorScheme = "Dark" Then
            DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
        Else
            DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
        End If
    End Sub

#End Region

End Class