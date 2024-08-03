Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Imports System.Data.SqlServerCe
Imports System.Runtime.CompilerServices
Imports System.Threading

Public Class My_Day

    Private AddReminderButtonPlaceholderText As String = "Add Reminder"
    Private RepeatButtonPlaceholderText As String = "Repeat"
    Private DescriptionPlaceholderText As String = "Add Description..."

    Private UserDefaultTimeFormat As Integer = 12

    ' Image cache variables
    Private UncheckedImportantIcon As Image
    Private CheckedImportantIcon As Image
    Private DisabledImportantIcon As Image

    'Private HasReminder As Boolean

    Private dt As New DataTable()
    Private CurrentDateTime As DateTime = DateTime.Now
    Private IsTaskPropertiesVisible As Boolean = True
    Private Task As String
    Private Done As Boolean

    Private connectionString As String = "Data Source=To_Do.sdf;Persist Security Info=False;"

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    '---------------------------------------------------------------------------------Initialization----------------------------------------------------------------------------------------'
#Region "Initialization"
    Private Sub InitializeMy_day()
        AddNewTask_TextBox.Focus()
        LoadTasksToCheckedListView()
        ShowOrHideTaskProperties()
        DayDate_Label.Text = CurrentDateTime.ToString("dddd, MMMM dd")

        LoadCachedImages()
        DisableTaskProperties(True)
    End Sub

    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMy_day()

        ReminderTimer.Interval = 1000 ' Set interval to 5 seconds
        ReminderTimer.Start() ' Start the Timer

        NotifyIcon1.Text = "EasyTo_do"
        NotifyIcon1.Icon = My.Resources.EasyToDo_Icon
        NotifyIcon1.Visible = True
    End Sub

    Private Sub LoadCachedImages()
        ' Cache images
        UncheckedImportantIcon = My.Resources._1
        CheckedImportantIcon = My.Resources._2
        DisabledImportantIcon = My.Resources._3
    End Sub

    Private Sub DisableTaskProperties(Disable As Boolean)
        If Disable Then
            TaskTitle_TextBox.Text = Nothing
            Label_TaskEntryDateTime.Text = Nothing
            Button_Important.BackgroundImage = DisabledImportantIcon

            If My.Settings.ColorScheme = "Dark" Then
                TaskTitle_TextBox.BackColor = Color.FromArgb(30, 30, 30)
                TaskTitle_TextBox.Enabled = False
                TaskDescription_RichTextBox.Hide()
            End If
            TaskDescription_RichTextBox.Text = Nothing
            TaskDescription_RichTextBox.Enabled = False

            Label_ADT.Enabled = False
            Label_TaskEntryDateTime.Enabled = False
            Button_Important.Enabled = False

            CustomButton_AddReminder.Enabled = False
            CustomButton_AddReminder.ButtonText = AddReminderButtonPlaceholderText
            CustomButton_Repeat.Enabled = False
            CustomButton_DueDate.Enabled = False

            Button_DeleteTask.Enabled = False


        Else
            If My.Settings.ColorScheme = "Dark" Then
                TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                TaskTitle_TextBox.Enabled = True

                TaskDescription_RichTextBox.Show()
            End If
            TaskDescription_RichTextBox.Enabled = True
            Label_ADT.Enabled = True
            Label_TaskEntryDateTime.Enabled = True
            Button_Important.Enabled = True
            CustomButton_Repeat.Enabled = True
            CustomButton_DueDate.Enabled = True
            CustomButton_AddReminder.Enabled = True
            Button_DeleteTask.Enabled = True
        End If
    End Sub
#End Region

    '---------------------------------------------------------------------------------Data Handling---------------------------------------------------------------------------------------------'
#Region "Data Handling"
    Private Sub LoadTasksToCheckedListView()
        Dim query As String = "SELECT * FROM My_Day ORDER BY Task_Index"

        CheckedListBox_MyDay.Items.Clear()
        dt.Clear()

        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            ' Fill CheckedListBox with data from the DataTable
            For Each row As DataRow In dt.Rows
                Dim itemText As String = row("Task").ToString()
                Dim isChecked As Boolean = row("Done")
                CheckedListBox_MyDay.Items.Add(itemText, isChecked)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub AddNewTaskToTable_My_Day(NewTask As String)
        Dim CurrentDateTime As DateTime = DateTime.Now
        Dim newTaskIndex As Integer

        ' Determine the next available Task_Index
        Dim queryGetMaxIndex As String = "SELECT MAX(Task_Index) FROM My_Day"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(queryGetMaxIndex, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    newTaskIndex = If(result Is DBNull.Value, 0, Convert.ToInt32(result) + 1)
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                    Return
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                    Return
                End Try
            End Using
        End Using

        ' Insert the new task with the determined Task_Index
        Dim queryInsertTask As String = "INSERT INTO My_Day (Task, Entry_DateTime, Task_Index) VALUES (@Task, @Entry_DateTime, @TaskIndex)"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(queryInsertTask, connection)
                command.Parameters.AddWithValue("@Task", NewTask)
                command.Parameters.AddWithValue("@Entry_DateTime", CurrentDateTime)
                command.Parameters.AddWithValue("@TaskIndex", newTaskIndex)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        ' Optionally notify success
                        ' MessageBox.Show("Task added successfully.")
                    Else
                        MessageBox.Show("No rows were affected. The task might not have been added.")
                    End If
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using

        ' Reload the data to reflect changes
        LoadTasksToCheckedListView()

        ' Focus on added task after DataTable reload
        If CheckedListBox_MyDay.Items.Count > 0 Then
            CheckedListBox_MyDay.SelectedIndex = newTaskIndex
            CheckedListBox_MyDay.Focus()
        End If
    End Sub

    Private Sub HardResetTable_My_Day()
        Dim dropTableQuery As String = "DROP TABLE My_Day"
        Dim createTableQuery As String = "CREATE TABLE My_Day (
                Id INT IDENTITY(1,1) NOT NULL,
                Task_Index INT NOT NULL,
                Task NVARCHAR(255) NULL,
                Task_Description NVARCHAR(4000) NULL,
                Entry_DateTime DATETIME NULL,
                Done BIT NULL DEFAULT 0,
                Important BIT NULL DEFAULT 0,
                Reminder_DateTime DATETIME NULL,
                CONSTRAINT My_Day_PK PRIMARY KEY (Id));"

        Using connection As New SqlCeConnection(connectionString)
            Try
                connection.Open()

                ' Begin a transaction
                Using transaction = connection.BeginTransaction()
                    ' Drop the table if it exists
                    Using dropCommand As New SqlCeCommand(dropTableQuery, connection, transaction)
                        dropCommand.ExecuteNonQuery()
                    End Using

                    ' Recreate the table
                    Using createCommand As New SqlCeCommand(createTableQuery, connection, transaction)
                        createCommand.ExecuteNonQuery()
                    End Using

                    ' Commit the transaction
                    transaction.Commit()
                End Using

            Catch ex As SqlCeException
                ' Detailed SQL CE exception
                MessageBox.Show("SQL CE Error: " & ex.Message)
            Catch ex As Exception
                ' General exception
                MessageBox.Show("Unexpected Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using

        ' Reload the data to reflect changes
        LoadTasksToCheckedListView()
        DisableTaskProperties(True)
    End Sub

    Private Sub DeleteTaskFromTable_My_Day(TaskIndex As Integer)
        ' The TaskIndex is used to find and delete the task
        Dim countQuery As String = "SELECT COUNT(*) FROM My_Day"
        Dim deleteQuery As String = "DELETE FROM My_Day WHERE Task_Index = @TaskIndex"
        Dim updateQuery As String = "UPDATE My_Day SET Task_Index = Task_Index - 1 WHERE Task_Index > @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Try
                connection.Open()

                ' Begin a transaction
                Using transaction = connection.BeginTransaction()
                    Dim taskCount As Integer

                    ' Check the number of tasks
                    Using countCommand As New SqlCeCommand(countQuery, connection, transaction)
                        taskCount = Convert.ToInt32(countCommand.ExecuteScalar())
                    End Using

                    ' If there's only one task, delete it and skip re-sequencing
                    If taskCount = 1 Then
                        HardResetTable_My_Day()
                        Exit Sub
                    Else
                        ' Delete the task
                        Using deleteCommand As New SqlCeCommand(deleteQuery, connection, transaction)
                            deleteCommand.Parameters.AddWithValue("@TaskIndex", TaskIndex)
                            deleteCommand.ExecuteNonQuery()
                        End Using

                        ' Re-sequence the Task_Index
                        Using updateCommand As New SqlCeCommand(updateQuery, connection, transaction)
                            updateCommand.Parameters.AddWithValue("@TaskIndex", TaskIndex)
                            updateCommand.ExecuteNonQuery()
                        End Using
                    End If

                    ' Commit the transaction
                    transaction.Commit()
                End Using

            Catch ex As SqlCeException
                ' Detailed SQL CE exception
                MessageBox.Show("SQL CE Error: " & ex.Message)
            Catch ex As Exception
                ' General exception
                MessageBox.Show("Unexpected Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using
        LoadTasksToCheckedListView()
    End Sub

    Private Sub UpdateTaskDescription(taskIndex As Integer, newDescription As String)
        Dim query As String = "UPDATE My_Day SET Task_Description = @NewDescription WHERE Task_Index = @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@NewDescription", newDescription)
                command.Parameters.AddWithValue("@TaskIndex", taskIndex)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        'MessageBox.Show("Task description updated successfully.")
                    Else
                        MessageBox.Show("No task found with the specified index.")
                    End If
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using
        LoadTasksToCheckedListView()

        If CheckedListBox_MyDay.Items.Count > 0 Then
            CheckedListBox_MyDay.SelectedIndex = taskIndex
            CheckedListBox_MyDay.Focus()
        End If
    End Sub
#End Region

    '-----------------------------------------------------------------------------Task Handling------------------------------------------------------------------------------'
#Region "Task Handling"
    Private Sub ShowOrHideTaskProperties()
        If IsTaskPropertiesVisible Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 77%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 23%
            IsTaskPropertiesVisible = False
        Else
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 100%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 0%
            IsTaskPropertiesVisible = True
        End If
    End Sub

    Private Sub EnterTaskTo_My_Day_ChecklistBox()
        Dim NewMy_DayTask As String = AddNewTask_TextBox.Text
        If NewMy_DayTask Is String.Empty Then
            Exit Sub
        End If
        CheckedListBox_MyDay.Items.Add(NewMy_DayTask)
        AddNewTaskToTable_My_Day(NewMy_DayTask)

        AddNewTask_TextBox.Clear()
        AddNewTask_TextBox.Focus()
    End Sub

    Private Sub DoneCheckChanged(itemIndex As Integer, isChecked As Boolean)
        Dim done As Integer = If(isChecked, 1, 0)

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Done = @Done WHERE Task_Index = @Task_Index"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    ' Use specific type for parameters
                    command.Parameters.Add("@Task_Index", SqlDbType.Int).Value = itemIndex
                    command.Parameters.Add("@Done", SqlDbType.Int).Value = done

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("SQL CE Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Unexpected Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ImportantCheckChanged(TaskIndex As Integer, isChecked As Boolean)
        'MsgBox("Item Index: " & itemIndex)
        'MsgBox("IsChecked: " & isChecked)

        Dim Important As Integer = If(isChecked, 1, 0)

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Important = @Important WHERE Task_Index = @Task_Index"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@Task_Index", TaskIndex)
                    command.Parameters.AddWithValue("@Important", Important)

                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating task status: " & ex.Message)
        End Try

        LoadTasksToCheckedListView()
        ' Retain Focus after DataTable Reload
        If CheckedListBox_MyDay.Items.Count > 0 Then
            CheckedListBox_MyDay.SelectedIndex = TaskIndex
            CheckedListBox_MyDay.Focus()
        End If
    End Sub

    Private Function IsTaskImportant() As Boolean
        Dim selectedIndex As Integer = CheckedListBox_MyDay.SelectedIndex
        If selectedIndex < 0 Then
            Return False
        End If

        ' Find the task in the DataTable
        For Each row As DataRow In dt.Rows
            If row("Task_Index") = selectedIndex Then
                ' Check if the task is marked as important
                If Convert.ToInt16(row("Important")) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        ' If no matching task is found
        Return False
    End Function

    Private Function GetTaskEntryDateTime() As String
        Dim TaskId As Integer = CheckedListBox_MyDay.SelectedIndex
        Dim TaskEntryDateTime As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("Task_Index") = TaskId Then
                If UserDefaultTimeFormat = 12 Then
                    TaskEntryDateTime = Convert.ToDateTime(row("Entry_DateTime")).ToString("yyyy-MM-dd  |  hh:mm tt")
                Else
                    TaskEntryDateTime = Convert.ToDateTime(row("Entry_DateTime")).ToString("yyyy-MM-dd  |  HH:mm")
                End If
                Exit For
            End If
        Next
        Return TaskEntryDateTime
    End Function

    Private Function GetTaskDescription() As String
        Dim TaskId As Integer = CheckedListBox_MyDay.SelectedIndex
        Dim TaskDescription As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("Task_Index") = TaskId Then
                TaskDescription = row("Task_Description").ToString
                Exit For
            End If
        Next
        Return TaskDescription
    End Function

    Public Function GetReminder() As String
        Dim TaskId As Integer = CheckedListBox_MyDay.SelectedIndex
        Dim TaskReminder As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("Task_Index") = TaskId Then
                If IsDBNull(row("Reminder_DateTime")) Then
                    Return String.Empty
                Else
                    Dim reminderDateTime As DateTime = Convert.ToDateTime(row("Reminder_DateTime"))
                    If UserDefaultTimeFormat = 12 Then
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
#End Region

    '-----------------------------------------------------------------Event Handlers---------------------------------------------------'
#Region "Event Handlers"
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties()
    End Sub

    Private Sub TextBox_AddNewTask_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            EnterTaskTo_My_Day_ChecklistBox()

            '   IncrementCheckedListBoxHeight() ' Increment

        End If
    End Sub

    Private Sub CheckedListBox_MyDay_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox_MyDay.ItemCheck
        Dim itemIndex As Integer
        itemIndex = e.Index
        DoneCheckChanged(itemIndex, e.NewValue = CheckState.Checked)
    End Sub

    Private Sub CheckedListBox_MyDay_MouseDown(sender As Object, e As MouseEventArgs) Handles CheckedListBox_MyDay.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties()
        End If
    End Sub

    Private Sub CheckedListBox_MyDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_MyDay.SelectedIndexChanged
        If CheckedListBox_MyDay.SelectedIndex = -1 Then
            DisableTaskProperties(True)
            TaskTitle_TextBox.Clear()
        Else
            DisableTaskProperties(False)
            TaskTitle_TextBox.Text = CheckedListBox_MyDay.SelectedItem.ToString()
            Label_TaskEntryDateTime.Text = GetTaskEntryDateTime()

            If GetTaskDescription() <> String.Empty Then
                If My.Settings.ColorScheme = "Dark" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Pink
                End If
                TaskDescription_RichTextBox.Text = GetTaskDescription()
            Else
                TaskDescription_RichTextBox.ForeColor = Color.Gray
                TaskDescription_RichTextBox.Text = DescriptionPlaceholderText
            End If

            If IsTaskImportant() Then
                Button_Important.BackgroundImage = CheckedImportantIcon
            Else
                Button_Important.BackgroundImage = UncheckedImportantIcon
            End If

            If GetReminder() <> String.Empty Then
                CustomButton_AddReminder.ButtonText = GetReminder()
            Else
                CustomButton_AddReminder.ButtonText = AddReminderButtonPlaceholderText
            End If

        End If
    End Sub

    Private Sub Button_Important_Click(sender As Object, e As EventArgs) Handles Button_Important.Click
        If IsTaskImportant() Then
            ImportantCheckChanged(CheckedListBox_MyDay.SelectedIndex, CheckState.Unchecked)
        Else
            ImportantCheckChanged(CheckedListBox_MyDay.SelectedIndex, CheckState.Checked)
        End If
    End Sub

    Private Sub Button_Important_MouseEnter(sender As Object, e As EventArgs) Handles Button_Important.MouseEnter
        If IsTaskImportant() Then
            Exit Sub
        End If
        Button_Important.BackgroundImage = CheckedImportantIcon
    End Sub

    Private Sub Button_Important1_MouseLeave(sender As Object, e As EventArgs) Handles Button_Important.MouseLeave
        If IsTaskImportant() Then
            Exit Sub
        End If
        Button_Important.BackgroundImage = UncheckedImportantIcon
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        DeleteTaskFromTable_My_Day(CheckedListBox_MyDay.SelectedIndex)

        ' DecrementCheckedListBoxHeight() ' Decrement

        DisableTaskProperties(True)
    End Sub

    Private Sub RichTextBox1_Enter(sender As Object, e As EventArgs) Handles TaskDescription_RichTextBox.Enter
        If My.Settings.ColorScheme = "Dark" Then
            TaskDescription_RichTextBox.ForeColor = Color.White
        End If
        If TaskDescription_RichTextBox.Text = DescriptionPlaceholderText Then
            TaskDescription_RichTextBox.Text = String.Empty
        End If
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TaskDescription_RichTextBox.KeyDown

        ' Check if Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            ' Check if Shift key is also pressed
            If e.Shift Then
                ' Allow default behavior (new line)
            Else
                ' Prevent the default behavior
                e.SuppressKeyPress = True
                UpdateTaskDescription(CheckedListBox_MyDay.SelectedIndex, TaskDescription_RichTextBox.Text)
            End If
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs)
        AddNewTask_TextBox.Focus()
    End Sub

    Private Sub TextBox_AddNewTask_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpTop_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpTop.Click
        Me.ActiveControl = Nothing
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub SubTlpTaskView_SubTlpBottom_Click(sender As Object, e As EventArgs) Handles SubTlpTaskView_SubTlpBottom.Click
        Me.ActiveControl = Nothing
        LoseListItemFocus()
        DisableTaskProperties(True)
    End Sub

    Private Sub LoseListItemFocus()
        CheckedListBox_MyDay.SelectedIndex = -1
    End Sub

    Private Sub CustomButton_AddReminder_Click(sender As Object, e As MouseEventArgs) Handles CustomButton_AddReminder.Click
        If e.Button = MouseButtons.Left Then
            Dim AddReminder_time_Instance = New AddReminder_Time_ With {
                .Reminder_SelectedTaskIndex = CheckedListBox_MyDay.SelectedIndex, .NeedsDatePicker = False
            }
            AddReminder_time_Instance.ShowDialog()
            AddReminder_time_Instance.BringToFront()
            LoadTasksToCheckedListView()
            If CheckedListBox_MyDay.Items.Count > 0 Then
                CheckedListBox_MyDay.SelectedIndex = AddReminder_time_Instance.Reminder_SelectedTaskIndex
                CheckedListBox_MyDay.Focus()
            End If
            AddReminder_time_Instance.Dispose()
        ElseIf e.Button = MouseButtons.Right Then
            ShowContextMenuCentered(ContextMenuStrip1, CustomButton_AddReminder)
        End If
    End Sub

    Private Sub ShowContextMenuCentered(contextMenu As ContextMenuStrip, control As Control)
        ' Calculate the center position of the control on the screen
        Dim buttonCenterScreenPosition As Point = control.PointToScreen(New Point(control.Width / 2, control.Height / 2))

        ' Calculate the location to show the ContextMenuStrip centered over the control
        Dim contextMenuPosition As New Point(buttonCenterScreenPosition.X - (contextMenu.Width / 2), buttonCenterScreenPosition.Y - (contextMenu.Height / 2))

        ' Show the ContextMenuStrip at the calculated position
        contextMenu.Show(contextMenuPosition)
    End Sub

    Private Sub RemoveReminder()
        Dim query As String = "UPDATE My_Day SET Reminder_DateTime = NULL WHERE Task_Index = @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@TaskIndex", CheckedListBox_MyDay.SelectedIndex)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        'MessageBox.Show("Reminder removed successfully.")
                    Else
                        MessageBox.Show("No task found with the specified index.")
                    End If
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using
        LoadTasksToCheckedListView()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim ToDeleteReminderTaskIndex As Integer = CheckedListBox_MyDay.SelectedIndex
        RemoveReminder()
        If CheckedListBox_MyDay.Items.Count > 0 Then
            CheckedListBox_MyDay.SelectedIndex = ToDeleteReminderTaskIndex
            CheckedListBox_MyDay.Focus()
        End If
    End Sub

    Private Sub ReminderTimer_Tick(sender As Object, e As EventArgs) Handles ReminderTimer.Tick
        CheckReminders()
        Time_Label.Text = DateTime.Now.ToString("hh:mm tt")
    End Sub
    Private Sub CheckReminders()
        Dim currentTime As DateTime = DateTime.Now

        For Each row As DataRow In dt.Rows
            ' Check if the Reminder_DateTime column is not null
            If row("Reminder_DateTime") IsNot DBNull.Value Then
                ' Directly cast to DateTime
                Dim reminderTime As DateTime = row("Reminder_DateTime")

                ' Convert both current time and reminder time to string in the same format
                Dim currentTimeString As String = currentTime.ToString("yyyy-MM-dd HH:mm:ss")
                Dim reminderTimeString As String = reminderTime.ToString("yyyy-MM-dd HH:mm:ss")

                ' Compare the formatted date and time strings
                If reminderTimeString = currentTimeString Then
                    ' Display reminder
                    If row("Task_Description") IsNot DBNull.Value And row("Important") = True Then
                        ShowNotification(row("Task"), True, row("Task_Description"))
                    ElseIf row("Task_Description") IsNot DBNull.Value And row("Important") = False Then
                        ShowNotification(row("Task"), False, row("Task_Description"))
                    ElseIf row("Task_Description") Is DBNull.Value And row("Important") = True Then
                        ShowNotification(row("Task"), True)
                    ElseIf row("Task_Description") Is DBNull.Value And row("Important") = False Then
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

    Private Sub Label_MyDay_Click(sender As Object, e As EventArgs)
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub

    Private Sub Label_DayDate_Click(sender As Object, e As EventArgs) Handles DayDate_Label.Click
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub

    Private Sub TableLayoutPanel1_Click(sender As Object, e As EventArgs) Handles TableLayoutPanel1.Click
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub

    Private Sub Time_Label_Click(sender As Object, e As EventArgs) Handles Time_Label.Click
        Me.ActiveControl = Nothing
        LoseListItemFocus()
    End Sub
#End Region

    Private Sub RichTextBox1_EnabledChanged(sender As Object, e As EventArgs)
        If Not TaskDescription_RichTextBox.Enabled Then
            TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40) ' Set your desired background color
        End If
    End Sub

    Private Sub SubTlpTaskProperties_SubTlpTaskFeatureButtons_Paint(sender As Object, e As PaintEventArgs) Handles SubTlpTaskProperties_SubTlpTaskFeatureButtons.Paint

    End Sub

    Private Sub MainTlp_SubTlpTaskProperties_Paint(sender As Object, e As PaintEventArgs) Handles MainTlp_SubTlpTaskProperties.Paint

    End Sub
End Class
