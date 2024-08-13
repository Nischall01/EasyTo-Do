Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports System.Threading

Public Class MyDay_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private UserDefaultTimeFormat As String = My.Settings.TimeFormat
    Private IsTaskPropertiesVisible As Boolean = True

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    '---------------------------------------------------------------------------------Initialization----------------------------------------------------------------------------------------'
#Region "On Load"

    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMy_day()

        ReminderTimer.Interval = 1000 ' Set interval to 5 seconds
        ReminderTimer.Start() ' Start the Timers

        NotifyIcon1.Text = "EasyTo_do"
        NotifyIcon1.Icon = My.Resources.EasyToDo_Icon
        NotifyIcon1.Visible = True
    End Sub

    Private Sub InitializeMy_day()
        AddNewTask_TextBox.Focus()
        LoadTasksToMyDay()
        Select Case My.Settings.TaskPropertiesSidebarOnStart
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select

        DayDate_Label.Text = DateTime.Now.ToString("dddd, MMMM dd")

        DisableTaskProperties(True)
    End Sub

#End Region

    Private Sub DisableTaskProperties(Disable As Boolean)
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

    '-----------------------------------------------------------------------------Task Handling------------------------------------------------------------------------------'
#Region "Task Handling"
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

    Private Function GetTaskEntryDateTime() As String
        Dim TaskEntryDateTime As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("TaskID") = SelectedTaskItem.ID Then
                If UserDefaultTimeFormat = "12" Then
                    TaskEntryDateTime = Convert.ToDateTime(row("EntryDateTime")).ToString("yyyy-MM-dd  |  hh:mm tt")
                Else
                    TaskEntryDateTime = Convert.ToDateTime(row("EntryDateTime")).ToString("yyyy-MM-dd  |  HH:mm")
                End If
                Exit For
            End If
        Next
        Return TaskEntryDateTime
    End Function

    Private Function GetTaskDescription() As String
        Dim TaskDescription As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("TaskID") = SelectedTaskItem.ID Then
                TaskDescription = row("Description").ToString
                Exit For
            End If
        Next
        Return TaskDescription
    End Function

    Private Function GetReminder() As String
        Dim TaskReminder As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("TaskID") = SelectedTaskItem.ID Then
                If IsDBNull(row("ReminderDateTime")) Then
                    Return String.Empty
                Else
                    Dim reminderDateTime As DateTime = Convert.ToDateTime(row("ReminderDateTime"))
                    If UserDefaultTimeFormat = "12" Then
                        TaskReminder = reminderDateTime.ToString("hh:mm tt")
                    Else
                        TaskReminder = reminderDateTime.ToString("HH:mm")
                    End If
                End If
                Exit For
            End If
        Next
        Return TaskReminder
    End Function

    Private Function GetRepeat() As String
        Dim TaskRepeat As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("TaskID") = SelectedTaskItem.ID Then
                If IsDBNull(row("RepeatedDays")) Then
                    Return String.Empty
                Else
                    If row("RepeatedDays") = "sun mon tue wed thu fri sat" Then
                        TaskRepeat = "Everyday"
                    Else
                        TaskRepeat = "Every..."
                    End If
                End If
                Exit For
            End If
        Next
        Return TaskRepeat
    End Function

    Private Function GetDueDate() As String
        Dim TaskDueDate As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("TaskID") = SelectedTaskItem.ID Then
                If IsDBNull(row("DueDate")) Then
                    Return String.Empty
                Else
                    TaskDueDate = row("DueDate")
                End If
                Exit For
            End If
        Next
        Return TaskDueDate
    End Function
#End Region

    '-----------------------------------------------------------------Event Handlers---------------------------------------------------'
#Region "Event Handlers"
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    ' Key Down event to add a new task
    Private Sub AddNewTask_TextBox_MouseDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim newTask As String = AddNewTask_TextBox.Text
            If String.IsNullOrWhiteSpace(newTask) Then Exit Sub

            RemoveHandler MyDay_CheckedListBox.ItemCheck, AddressOf MyDay_CheckedListBox_ItemCheck
            Dim NewTaskId As Integer = Task.AddNewTasks.MyDay(newTask)
            AddHandler MyDay_CheckedListBox.ItemCheck, AddressOf MyDay_CheckedListBox_ItemCheck

            For i As Integer = 0 To MyDay_CheckedListBox.Items.Count - 1
                If MyDay_CheckedListBox.Items(i).ID = NewTaskId Then
                    MyDay_CheckedListBox.SelectedIndex = i
                    Exit For
                End If
            Next

            AddNewTask_TextBox.Clear()
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
            If IsTaskImportant() Then
                Task.ImportantCheckChanged(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                Task.ImportantCheckChanged(CheckState.Checked, SelectedTaskItem.ID)
            End If
            MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
        Else
            LoseListItemFocus()
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If IsTaskImportant() Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If IsTaskImportant() Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If MyDay_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker() ' Invoke the task deletion method
        End If
    End Sub

    Private Sub MyDay_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MyDay_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso MyDay_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker()
        End If
    End Sub

    Private Sub RichTextBox1_Enter(sender As Object, e As EventArgs) Handles TaskDescription_RichTextBox.Enter
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
                Task.UpdateDescription(TaskDescription_RichTextBox.Text, SelectedTaskItem.ID)

                If MyDay_CheckedListBox.Items.Count > 0 Then
                    Me.ActiveControl = Nothing
                    MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
                End If
            End If
        End If
    End Sub

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub MyDay_Label_Click(sender As Object, e As EventArgs) Handles MyDay_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub ShowContextMenuCentered(contextMenu As ContextMenuStrip, control As Control)
        ' Calculate the center position of the control on the screen
        Dim buttonCenterScreenPosition As Point = control.PointToScreen(New Point(control.Width / 2, control.Height / 2))

        ' Calculate the location to show the ContextMenuStrip centered over the control
        Dim contextMenuPosition As New Point(buttonCenterScreenPosition.X - (contextMenu.Width / 2), buttonCenterScreenPosition.Y - (contextMenu.Height / 2))

        ' Show the ContextMenuStrip at the calculated position
        contextMenu.Show(contextMenuPosition)
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

        For Each row As DataRow In dt.Rows
            ' Check if the Reminder_DateTime column is not null
            If row("ReminderDateTime") IsNot DBNull.Value Then
                ' Directly cast to DateTime
                Dim reminderTime As DateTime = row("ReminderDateTime")

                ' Convert both current time and reminder time to string in the same format
                Dim currentTimeString As String = currentTime.ToString("yyyy-MM-dd HH:mm:ss")
                Dim reminderTimeString As String = reminderTime.ToString("yyyy-MM-dd HH:mm:ss")
                ' Compare the formatted date and time strings
                If reminderTimeString = currentTimeString Then

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
        NotifyIcon1.ShowBalloonTip(3000) ' 3000 milliseconds = 3 seconds
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        If MainWindow IsNot Nothing Then
            MainWindow.Activate()
            MainWindow.WindowState = FormWindowState.Normal
            MainWindow.TopMost = True
            System.Threading.Thread.Sleep(500)
            MainWindow.TopMost = False
            SetForegroundWindow(MainWindow.Handle)
        End If
    End Sub

    ' Dispose of the NotifyIcon when the form is closed
    Private Sub My_Day_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        NotifyIcon1.Dispose()
    End Sub

    Private Sub Label_DayDate_Click(sender As Object, e As EventArgs) Handles DayDate_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub

    Private Sub TableLayoutPanel1_Click(sender As Object, e As EventArgs) Handles TableLayoutPanel1.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub

    Private Sub Time_Label_Click(sender As Object, e As EventArgs) Handles Time_Label.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub
#End Region

    Private Sub RichTextBox1_EnabledChanged(sender As Object, e As EventArgs)
        If Not TaskDescription_RichTextBox.Enabled Then
            TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40) ' Set your desired background color
        End If
    End Sub

#Region "Data Handling (My Day Table)"
    ' Load tasks onto the Checked list Box.
    Public Sub LoadTasksToMyDay()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE DueDate = @Today ORDER BY ReminderDateTime;"

        Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using transaction = connection.BeginTransaction
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@Today", DateTime.Today)
                    Using adapter As New SqlCeDataAdapter(command)

                        adapter.Fill(dt)
                    End Using
                End Using
                transaction.Commit()
            End Using
        End Using
        dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}
        MyDay_CheckedListBox.Items.Clear()

        For Each row As DataRow In dt.Rows
            If Not row.IsNull("ReminderDateTime") AndAlso TypeOf row("ReminderDateTime") Is DateTime Then
                Dim RemindedTask As String = row("Task")
                Dim reminderDateTime As DateTime = row.Field(Of DateTime)("ReminderDateTime")
                row("Task") = reminderDateTime.ToString("(hh:mmtt)").ToLower() + "  " + RemindedTask
                'row("Task") = RemindedTask + "  " + reminderDateTime.ToString("(hh:mmtt)").ToLower()
                'row("Task") = "~" + "  " + RemindedTask
                ' row("Task") = RemindedTask + "  " + "~"
            End If

            If row("IsImportant") Then
                Dim ImportantTask As String = "!" + "  " + row("Task")
                row("Task") = ImportantTask
            End If

            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            MyDay_CheckedListBox.Items.Add(item, item.IsDone)
        Next
    End Sub



    ' Task.DeleteTask method invoker
    Private Sub DeleteTaskInvoker()
        If SelectedTaskItem Is Nothing Then
            MessageBox.Show("No task is selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Task.DeleteTask(SelectedTaskItem.ID)

            ' Adjust the selected task index after deletion
            If MyDay_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= MyDay_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = MyDay_CheckedListBox.Items.Count - 1
                End If
                MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
            Else
                DisableTaskProperties(True)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MyDay_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyDay_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = MyDay_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = MyDay_CheckedListBox.SelectedItem

            DisableTaskProperties(False)
            TaskTitle_TextBox.Text = MyDay_CheckedListBox.SelectedItem.ToString()
            Label_TaskEntryDateTime.Text = GetTaskEntryDateTime()

            If GetTaskDescription() <> String.Empty Then
                If My.Settings.ColorScheme = "Dark" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Pink
                ElseIf My.Settings.ColorScheme = "Light" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Black
                End If
                TaskDescription_RichTextBox.Text = GetTaskDescription()
            Else
                TaskDescription_RichTextBox.ForeColor = Color.Gray
                TaskDescription_RichTextBox.Text = TextPlaceholders.Description
            End If

            If IsTaskImportant() Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If

            If GetReminder() <> String.Empty Then
                CustomButton_AddReminder.ButtonText = GetReminder()
            Else
                CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton
            End If

            If GetRepeat() <> String.Empty Then
                CustomButton_Repeat.ButtonText = GetRepeat()
            Else
                CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton
            End If

            If GetDueDate() <> String.Empty Then
                CustomButton_AddDueDate.ButtonText = GetDueDate()
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
        If Views._isUiUpdating Then
            Exit Sub
        End If

        'MsgBox("ItemCheck Triggered")
        If SelectedTaskItem IsNot Nothing Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID, "MyDay")
        End If
        MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    Private Sub CustomButton_AddReminder_Click(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.MouseClick
        If e.Button = MouseButtons.Left Then
            Dim Reminder_DialogInstance = New Reminder_Dialog With {.Reminder_SelectedTaskID = SelectedTaskItem.ID, .NeedsDatePicker = False}

            Reminder_DialogInstance.ShowDialog()
            Reminder_DialogInstance.BringToFront()

            If MyDay_CheckedListBox.Items.Count > 0 Then
                MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If

            Reminder_DialogInstance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip1, CustomButton_AddReminder)
        End If
    End Sub

    Private Sub CustomButton_Repeat_Click(sender As Object, e As MouseEventArgs) Handles CustomButton_Repeat.MouseClick
        If e.Button = MouseButtons.Left Then
            Dim Repeat_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = SelectedTaskItem.ID}

            Repeat_DialogInstance.ShowDialog()
            Repeat_DialogInstance.BringToFront()

            If MyDay_CheckedListBox.Items.Count > 0 Then
                MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If

            Repeat_DialogInstance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip2, CustomButton_Repeat)
        End If
    End Sub

    Private Sub CustomButton_DueDate_Click(sender As Object, e As MouseEventArgs) Handles CustomButton_AddDueDate.MouseClick
        Dim ItemCountBeforeDueDateChange As Integer = MyDay_CheckedListBox.Items.Count
        If e.Button = MouseButtons.Left Then
            Dim DueDate_DialogInstance As New DueDate_Dialog With {.DueDate_SelectedTaskID = SelectedTaskItem.ID}
            DueDate_DialogInstance.ShowDialog()
            DueDate_DialogInstance.BringToFront()

            If MyDay_CheckedListBox.Items.Count > 0 Then
                If MyDay_CheckedListBox.Items.Count < ItemCountBeforeDueDateChange Then
                    MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex - 1
                Else
                    MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
                End If
            End If
            DueDate_DialogInstance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip3, CustomButton_AddDueDate)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Reminder.RemoveReminder(SelectedTaskItem.ID)
        If MyDay_CheckedListBox.Items.Count > 0 Then
            MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Repeat.RemoveRepeat(SelectedTaskItem.ID)
        If MyDay_CheckedListBox.Items.Count > 0 Then
            MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        DueDate.RemoveDueDate(SelectedTaskItem.ID)
        If MyDay_CheckedListBox.Items.Count > 0 Then
            MyDay_CheckedListBox.SelectedIndex = SelectedTaskIndex
        End If
    End Sub

    Private Sub LoseListItemFocus()
        MyDay_CheckedListBox.SelectedItem = Nothing
        MyDay_CheckedListBox.SelectedIndex = -1
    End Sub

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left M")
        'MsgBox("M SelectedItemIndex = " & MyDay_CheckedListBox.SelectedIndex)
    End Sub
#End Region
End Class
