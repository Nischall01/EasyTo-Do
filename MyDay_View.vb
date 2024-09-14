Imports System.Runtime.InteropServices

Public Class MyDay_View

    Private IsTaskPropertiesVisible As Boolean
    Private lastUpdatedMinute As Integer = -1
    Private MyDayDT As New DataTable()
    Private MyDayDT_TaskTitleOnly As New DataTable()

    Private SelectedTask_ID As Integer
    Private SelectedTask_Index As Integer
    Private SelectedTask_Item As TaskItem
    Private SelectedTask_Properties As TaskProperties

#Region "On Load"

    ' Initializes the form components and enables key preview for handling keyboard events at the form level. '
    Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    ' Initializes the MyDay tasks view. '
    Private Sub InitializeMyDay()
        Select Case SettingsCache.TaskPropertiesSidebarStateOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select

        DayDate_Label.Text = DateTime.Now.ToString("dddd, MMMM dd")

        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    ' Form on load : Initializes the MyDay tasks view. '
    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMyDay()

        ClockTimer.Interval = 1000 ' Set interval to 5 seconds
        ClockTimer.Start() ' Start the Timers
    End Sub

#End Region

#Region "Data Loading Actions"

    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_MyDay()
        MyDayDT.Clear()
        MyDayDT_TaskTitleOnly.Clear()

        Dim TodayDay As String = (DateTime.Today.DayOfWeek.ToString).Substring(0, 3)

        Dim query As String
        Dim queryTitleOnly As String = "Select TaskID, Task FROM Tasks " &
            "WHERE DueDate = @Today Or RepeatedDays Like '%' + CAST(@TodayDay AS NVARCHAR) + '%';"

        If SettingsCache.HideCompletedTasks Then
            query = "SELECT * FROM Tasks " &
            "WHERE (DueDate = @Today OR RepeatedDays LIKE '%' + CAST(@TodayDay AS NVARCHAR) + '%') " &
            "AND IsDone = 0 " & ' Filter to show only incomplete tasks
            "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
            "ReminderDateTime, IsImportant DESC;"
        Else
            If SettingsCache.SortByCompletionStatus Then
                query = "SELECT * FROM Tasks " &
                "WHERE DueDate = @Today OR RepeatedDays LIKE '%' + CAST(@TodayDay AS NVARCHAR) + '%' " &
                "ORDER BY IsDone ASC, " &
                "CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            Else
                query = "SELECT * FROM Tasks " &
                "WHERE DueDate = @Today OR RepeatedDays LIKE '%' + CAST(@TodayDay AS NVARCHAR) + '%' " &
                "ORDER BY CASE WHEN ReminderDateTime IS NULL THEN 1 ELSE 0 END, " &
                "ReminderDateTime, IsImportant DESC;"
            End If
        End If

        Using connection As New SqlCeConnection(SettingsCache.connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                command.Parameters.AddWithValue("@TodayDay", TodayDay)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(MyDayDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                command.Parameters.AddWithValue("@TodayDay", TodayDay)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(MyDayDT_TaskTitleOnly)
                End Using
            End Using
        End Using

        MyDayDT.PrimaryKey = New DataColumn() {MyDayDT.Columns("TaskID")}
        MyDayDT_TaskTitleOnly.PrimaryKey = New DataColumn() {MyDayDT_TaskTitleOnly.Columns("TaskID")}
    End Sub

    ' Load tasks onto the CheckedListBox.
    Public Sub LoadTasksToMyDayView()
        LoadTasksToDataTables_MyDay()
        MyDay_CheckedListBox.BeginUpdate() ' Prevent UI from redrawing until complete
        MyDay_CheckedListBox.Items.Clear()

        For Each row As DataRow In MyDayDT.Rows
            Dim taskDisplayName As String = row("Task").ToString()

            If Not row.IsNull("ReminderDateTime") Then
                Dim reminderDateTime As DateTime = row("ReminderDateTime")
                taskDisplayName = $"{reminderDateTime:(hh:mmtt)}".ToLower & $" {taskDisplayName}"
            End If

            If Not row.IsNull("RepeatedDays") Then
                taskDisplayName = $"{taskDisplayName} {GlobalResources.repeatedTaskIndicator}"
            End If

            If row("IsImportant") Then
                taskDisplayName = $"{GlobalResources.importantTaskIndicator} {taskDisplayName}"
            End If

            Dim taskItem As New TaskItem(taskDisplayName, row("TaskID"), row("IsDone"))
            MyDay_CheckedListBox.Items.Add(taskItem, taskItem.IsDone)

        Next

        MyDay_CheckedListBox.EndUpdate() ' UI refresh happens once after all items are added
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
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
            Case TaskPropertiesSidebarAction.DisableAndHide
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

    Private Sub EnableOrDisable_TaskPropertiesSidebar(State As TaskPropertiesState)
        Select Case State
            Case TaskPropertiesState.Disable
                TaskTitle_TextBox.Text = Nothing
                Label_TaskEntryDateTime.Text = Nothing
                Important_Button.BackgroundImage = GlobalResources.DisabledImportantIcon

                If SettingsCache.ColorScheme = "Dark" Then
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

                CustomButton_AddDueDate.Enabled = False
                CustomButton_AddDueDate.ButtonText = TextPlaceholders.DueDateButton

                Button_DeleteTask.Enabled = False
            Case TaskPropertiesState.Enable
                If SettingsCache.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                    TaskDescription_RichTextBox.Show()
                End If
                TaskTitle_TextBox.Enabled = True
                Label_ADT.Enabled = True
                Label_TaskEntryDateTime.Enabled = True
                Important_Button.Enabled = True
                CustomButton_AddReminder.Enabled = True
                CustomButton_Repeat.Enabled = True
                CustomButton_AddDueDate.Enabled = True
                TaskDescription_RichTextBox.Enabled = True
                Button_DeleteTask.Enabled = True
        End Select
    End Sub

    Private Sub ShowOrHide_TaskPropertiesSidebar(action As TaskPropertiesVisibility)
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

#End Region

#Region "Clock"

    Private Sub ReminderTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        If SettingsCache.TimeFormat = "12" Then
            Time_Label.Text = DateTime.Now.ToString("hh:mm:ss tt")
        Else
            Time_Label.Text = DateTime.Now.ToString("HH:mm:ss")
        End If
    End Sub

#End Region

    ' It updates the UI with the details of the selected task, including the task title, entry date/time, importance status,
    ' description, reminder time, and repeat frequency. If no task is selected, the task properties are disabled and cleared.
    Private Sub LoadSelectedTaskProperties()
        SelectedTask_Properties = TaskManager.GetTaskProperties(SelectedTask_ID, MyDayDT)

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
        Important_Button.BackgroundImage = If(isImportant, GlobalResources.CheckedImportantIcon, GlobalResources.UncheckedImportantIcon)

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

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    ' Add new task '
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrWhiteSpace(AddNewTask_TextBox.Text) Then Exit Sub
            TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.MyDay_CheckedListBox, ViewName.MyDay)
            If MyDay_CheckedListBox.Items.Count = 1 Then
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            End If
        End If
    End Sub

    ' Close Task properties sidebar '
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If MyDay_CheckedListBox.SelectedIndex = -1 Or MyDay_CheckedListBox.Items.Count = 0 Or SelectedTask_Item Is Nothing Then
            Exit Sub
        End If

        If SettingsCache.onDeleteAskForConfirmation Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then
                Exit Sub
            End If
        End If
        TaskManager.DeleteTask(SelectedTask_ID, Me.MyDay_CheckedListBox, SelectedTask_Index, ViewName.MyDay)

        If MyDay_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowReminderDialog(SelectedTask_ID, Me.MyDay_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip1, Me.CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_DueDate_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddDueDate.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowDueDateDialog(SelectedTask_ID, SelectedTask_Index, Me.MyDay_CheckedListBox, ViewName.MyDay)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip3, Me.CustomButton_AddDueDate)
        End If
    End Sub

    Private Sub CustomButton_Repeat_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowRepeatDialog(SelectedTask_ID, Me.MyDay_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip2, Me.CustomButton_Repeat)
        End If
    End Sub

    ' Button event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If MyDay_CheckedListBox.Items.Count > 0 Then
            If SelectedTask_Properties.IsImportant Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTask_ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTask_ID)
            End If
            UiUtils.TaskSelection_Retain(MyDay_CheckedListBox, SelectedTask_ID)
        Else
            UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If SelectedTask_Properties.IsImportant Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = GlobalResources.CheckedImportantIcon
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If SelectedTask_Properties.IsImportant Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = GlobalResources.UncheckedImportantIcon
    End Sub

    Private Sub Label_DayDate_Click(sender As Object, e As EventArgs) Handles DayDate_Label.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Delete Then
            Button_DeleteTask.PerformClick()
        End If
    End Sub

    ' ItemCheck event to change the 'IsDone' status of the selected task
    Private Async Sub MyDay_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles MyDay_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then Exit Sub

        ' Store the current index before making changes
        Dim previousIndex As Integer = SelectedTask_Index

        ' Update the task status based on the checkbox state
        TaskManager.UpdateStatus(e.NewValue = CheckState.Checked, SelectedTask_ID)

        ' # Option 1

        'If SettingsCache.HideCompletedTasks Or SettingsCache.SortByCompletionStatus Then
        '    Await Task.Delay(15)
        '    UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        '    ViewsManager.RefreshTasks()
        '    Me.ActiveControl = Me.AddNewTask_TextBox
        'Else
        '    ' Trigger flickering effect by deselecting and reselecting
        '    If previousIndex > 0 Then
        '        MyDay_CheckedListBox.SelectedIndex = -1
        '        Await Task.Delay(UiUtils.FilckerDelay) ' Flicker delay
        '    End If
        '    MyDay_CheckedListBox.SelectedIndex = previousIndex
        'End If

        ' # Option 2

        Await Task.Delay(10)
        UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        ViewsManager.RefreshTasks()
        Me.ActiveControl = Me.AddNewTask_TextBox
    End Sub

    Private Sub MyDay_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles MyDay_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    ' Event handler triggered when the user selects a task from the Repeated_CheckedListBox.
    Private Sub MyDay_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyDay_CheckedListBox.SelectedIndexChanged
        SelectedTask_Index = MyDay_CheckedListBox.SelectedIndex

        If SelectedTask_Index <> -1 Then
            SelectedTask_Item = MyDay_CheckedListBox.SelectedItem
            SelectedTask_ID = SelectedTask_Item.ID
            LoadSelectedTaskProperties()
        End If
    End Sub

    Private Sub MyDay_Label_Click(sender As Object, e As EventArgs) Handles MyDay_Label.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        'MsgBox("Left MyDay view")
        'MsgBox("SelectedItemIndex = " & MyDay_CheckedListBox.SelectedIndex)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    Private Sub TableLayoutPanel1_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_DateAndTimeHolder.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
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
                MyDay_CheckedListBox.SelectedIndex = SelectedTask_Index
            End If
        End If
    End Sub

    Private Sub TaskTitle_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskTitle_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If TaskTitle_TextBox.Text Is String.Empty Then
                ViewsManager.RefreshTasks()
            Else
                TaskManager.UpdateTitle(SelectedTask_ID, TaskTitle_TextBox.Text)
            End If
            Me.ActiveControl = Nothing
            UiUtils.TaskSelection_Retain(Me.MyDay_CheckedListBox, SelectedTask_ID)
        End If
    End Sub

    Private Sub Time_Label_Click(sender As Object, e As EventArgs) Handles Time_Label.Click
        ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TaskManager.RemoveReminder(SelectedTask_ID, Me.MyDay_CheckedListBox, SelectedTask_Index)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TaskManager.RemoveRepeat(SelectedTask_ID, Me.MyDay_CheckedListBox, SelectedTask_Index, ViewName.MyDay)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        TaskManager.RemoveDueDate(SelectedTask_ID, Me.MyDay_CheckedListBox, SelectedTask_Index, ViewName.MyDay)
    End Sub

#End Region

End Class