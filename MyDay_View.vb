Imports System.Threading

Public Class MyDay_View
    Private connectionString As String = My.Settings.ConnectionString
    Private MyDayDT As New DataTable()
    Private MyDayDT_TaskTitleOnly As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True
    Private UserDefaultTimeFormat As String = My.Settings.TimeFormat

#Region "On Load"
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    ' Form on load : Initializes the Repeated tasks view
    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMyDay()

        ReminderTimer.Interval = 1000 ' Set interval to 5 seconds
        ReminderTimer.Start() ' Start the Timers

        NotifyIcon1.Text = "EasyTo_do"
        NotifyIcon1.Icon = My.Resources.EasyToDo_Icon
        NotifyIcon1.Visible = True
    End Sub

    Private Sub InitializeMyDay()
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select

        DayDate_Label.Text = DateTime.Now.ToString("dddd, MMMM dd")

        DisableTaskProperties(True)
    End Sub

#End Region

#Region "Data Loading Actions"

    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_MyDay()
        MyDayDT.Clear()
        MyDayDT_TaskTitleOnly.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE DueDate = @Today ORDER BY ReminderDateTime;"
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks WHERE DueDate = @Today ORDER BY ReminderDateTime;"

        Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(MyDayDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
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
        MyDay_CheckedListBox.Items.Clear()

        For Each row As DataRow In MyDayDT.Rows
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
            MyDay_CheckedListBox.Items.Add(item, item.IsDone)
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

            CustomButton_AddDueDate.Enabled = False
            CustomButton_AddDueDate.ButtonText = TextPlaceholders.DueDateButton

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
            CustomButton_AddDueDate.Enabled = True
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
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    ' Key Down event to add a new task
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrWhiteSpace(AddNewTask_TextBox.Text) Then Exit Sub
            Dim NewTaskID As Integer = TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.MyDay_CheckedListBox, ViewName.MyDay)

        End If
    End Sub

    Private Sub MyDay_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles MyDay_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    ' Button event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If MyDay_CheckedListBox.Items.Count > 0 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, MyDayDT) Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTaskItem.ID)
            End If
            MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
        Else
            UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If TaskManager.IsTaskImportant(SelectedTaskItem.ID, MyDayDT) Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If TaskManager.IsTaskImportant(SelectedTaskItem.ID, MyDayDT) Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If MyDay_CheckedListBox.SelectedIndex = -1 Or MyDay_CheckedListBox.Items.Count = 0 Or SelectedTaskItem Is Nothing Then
            Exit Sub
        End If
        TaskManager.DeleteTask(SelectedTaskItem.ID, Me.MyDay_CheckedListBox, SelectedTaskIndex, ViewName.MyDay)
        If MyDay_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Delete Then
            Button_DeleteTask.PerformClick()
        End If
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

    Private Sub TaskTitle_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskTitle_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If TaskTitle_TextBox.Text Is String.Empty Then
                ViewsManager.RefreshTasks()
            Else
                TaskManager.UpdateTitle(SelectedTaskItem.ID, TaskTitle_TextBox.Text)
            End If
            Me.ActiveControl = Nothing
            UiUtils.TaskSelection_Retain(MyDay_CheckedListBox, SelectedTaskItem.ID)
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

                If MyDay_CheckedListBox.Items.Count > 0 Then
                    Me.ActiveControl = Nothing
                    MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
                End If
            End If
        End If
    End Sub

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        DisableTaskProperties(True)
    End Sub

    Private Sub MyDay_Label_Click(sender As Object, e As EventArgs) Handles MyDay_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
        DisableTaskProperties(True)
    End Sub
    Private Sub Label_DayDate_Click(sender As Object, e As EventArgs) Handles DayDate_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
    End Sub

    Private Sub TableLayoutPanel1_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_DateAndTimeHolder.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
    End Sub

    Private Sub Time_Label_Click(sender As Object, e As EventArgs) Handles Time_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        UiUtils.TaskSelection_Clear(Me.MyDay_CheckedListBox)
    End Sub

    Private Sub ReminderTimer_Tick(sender As Object, e As EventArgs) Handles ReminderTimer.Tick
        CheckReminders()
        If UserDefaultTimeFormat = "12" Then
            Time_Label.Text = DateTime.Now.ToString("hh:mm tt")
        Else
            Time_Label.Text = DateTime.Now.ToString("HH:MM")
        End If
    End Sub
    Private Sub CheckReminders()
        Dim currentTime As DateTime = DateTime.Now

        For Each row As DataRow In MyDayDT.Rows
            ' Check if the Reminder_DateTime column is not null
            If row("ReminderDateTime") IsNot DBNull.Value Then
                ' Directly cast to DateTime
                Dim reminderTime As DateTime = row("ReminderDateTime")

                ' Convert both current time and reminder time to string in the same format
                Dim currentTimeString As String = currentTime.ToString("yyyy-MM-dd HH:mm:ss")
                Dim reminderTimeString As String = reminderTime.ToString("yyyy-MM-dd HH:mm:ss")

                ' Compare the formatted date and time strings
                If currentTimeString = reminderTimeString Then
                    Dim ImportantTask As String = row("Task")
                    ImportantTask = ImportantTask.Substring(3)
                    ' Display reminder
                    If row("Description") IsNot DBNull.Value And row("IsImportant") = True Then
                        ShowNotification(ImportantTask, True, row("Description"))
                    ElseIf row("Description") IsNot DBNull.Value And row("IsImportant") = False Then
                        ShowNotification(row("Task"), False, row("Description"))
                    ElseIf row("Description") Is DBNull.Value And row("IsImportant") = True Then
                        ShowNotification(ImportantTask, True)
                    ElseIf row("Description") Is DBNull.Value And row("IsImportant") = False Then
                        ShowNotification(row("Task"), False)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ShowNotification(title As String, IsImportant As Boolean, Optional message As String = " ")
        NotifyIcon1.BalloonTipTitle = title
        If IsImportant Then
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Warning
            NotifyIcon1.BalloonTipText = message
        Else
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
            NotifyIcon1.BalloonTipText = message
        End If
        NotifyIcon1.ShowBalloonTip(5000) ' 3000 milliseconds = 5 seconds
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        If MainWindow IsNot Nothing Then
            MainWindow.Activate()
            MainWindow.WindowState = FormWindowState.Normal
            MainWindow.TopMost = True
        End If
    End Sub

    ' Dispose of the NotifyIcon when the form is closed
    Private Sub My_Day_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        NotifyIcon1.Dispose()
    End Sub

#End Region

#Region "Data Handling (My Day Table)"

    Private Sub MyDay_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyDay_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = MyDay_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = MyDay_CheckedListBox.SelectedItem

            DisableTaskProperties(False)
            TaskTitle_TextBox.Text = TaskManager.GetTaskString(SelectedTaskItem.ID, MyDayDT_TaskTitleOnly)

            Label_TaskEntryDateTime.Text = TaskManager.GetTaskEntryDateTimeString(SelectedTaskItem.ID, MyDayDT)

            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, MyDayDT) Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If

            If TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, MyDayDT) <> String.Empty Then
                If My.Settings.ColorScheme = "Dark" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Pink
                ElseIf My.Settings.ColorScheme = "Light" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Black
                End If
                TaskDescription_RichTextBox.Text = TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, MyDayDT)
            Else
                TaskDescription_RichTextBox.ForeColor = Color.Gray
                TaskDescription_RichTextBox.Text = TextPlaceholders.Description
            End If

            Dim ReminderTime As String = TaskManager.GetReminderString(SelectedTaskItem.ID, MyDayDT)
            If ReminderTime <> String.Empty Then
                CustomButton_AddReminder.ButtonText = ReminderTime
            Else
                CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton
            End If

            Dim RepeatFrequency As String = TaskManager.GetRepeatString(SelectedTaskItem.ID, MyDayDT)
            If RepeatFrequency <> String.Empty Then
                CustomButton_Repeat.ButtonText = RepeatFrequency
            Else
                CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton
            End If

            Dim ReminderDueDate As String = TaskManager.GetDueDateString(SelectedTaskItem.ID, MyDayDT)
            If ReminderDueDate <> String.Empty Then
                CustomButton_AddDueDate.ButtonText = ReminderDueDate
            Else
                CustomButton_AddDueDate.ButtonText = TextPlaceholders.DueDateButton
            End If
        Else
            DisableTaskProperties(True)
            TaskTitle_TextBox.Clear()
        End If
    End Sub


    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub MyDay_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles MyDay_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Or MyDay_CheckedListBox.SelectedIndex = -1 Then Exit Sub

        TaskManager.UpdateStatus(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    Private Sub CustomButton_AddReminder_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowReminderDialog(SelectedTaskItem.ID, Me.MyDay_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip1, Me.CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowRepeatDialog(SelectedTaskItem.ID, Me.MyDay_CheckedListBox)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip2, Me.CustomButton_Repeat)
        End If
    End Sub

    Private Sub CustomButton_DueDate_MouseClick(sender As Object, e As MouseEventArgs) Handles CustomButton_AddDueDate.MouseClick
        If e.Button = MouseButtons.Left Then
            TaskManager.ShowDueDateDialog(SelectedTaskItem.ID, SelectedTaskIndex, Me.MyDay_CheckedListBox, ViewName.MyDay)
        ElseIf e.Button = MouseButtons.Right Then
            UiUtils.ShowContextMenuCentered(Me.ContextMenuStrip3, Me.CustomButton_AddDueDate)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TaskManager.RemoveReminder(SelectedTaskItem.ID, Me.MyDay_CheckedListBox, SelectedTaskIndex)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TaskManager.RemoveRepeat(SelectedTaskItem.ID, Me.MyDay_CheckedListBox, SelectedTaskIndex, ViewName.MyDay)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        TaskManager.RemoveDueDate(SelectedTaskItem.ID, Me.MyDay_CheckedListBox, SelectedTaskIndex, ViewName.MyDay)
    End Sub

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.TaskSelection_Clear(MyDay_CheckedListBox)
        'MsgBox("Left MyDay")
        'MsgBox("M SelectedItemIndex = " & MyDay_CheckedListBox.SelectedIndex)
    End Sub

#End Region
End Class
