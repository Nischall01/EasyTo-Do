Namespace Helper
    Module UiHelpers
        Public Sub RetainItemSelection(ByVal CLB As CheckedListBox, ByVal SelectedTaskIndex As Integer)
            CLB.SelectedIndex = SelectedTaskIndex
        End Sub

        Public Sub ItemSelectionAfterTaskDeletion(ByVal CLB As CheckedListBox, ByVal SelectedTaskIndex As Integer, View As Views.ViewName)
            ' Adjust the selected task index after deletion
            If CLB.Items.Count > 0 Then
                If SelectedTaskIndex >= CLB.Items.Count Then
                    SelectedTaskIndex = CLB.Items.Count - 1
                End If
                CLB.SelectedIndex = SelectedTaskIndex
            Else
                Select Case View
                    Case ViewName.MyDay
                        MainWindow.MyDayInstance.DisableTaskProperties(True)
                    Case ViewName.Repeated
                        MainWindow.RepeatedInstance.DisableTaskProperties(True)
                    Case ViewName.Important
                        MainWindow.ImportantInstance.DisableTaskProperties(True)
                    Case ViewName.Planned
                        MainWindow.PlannedInstance.DisableTaskProperties(True)
                    Case ViewName.Tasks
                        MainWindow.TasksInstance.DisableTaskProperties(True)
                End Select
            End If
        End Sub
    End Module
End Namespace

Module HelperMethods
    '*' Add New Task
    Public Sub AddNewTask(TextBox As TextBox, CLB As CheckedListBox, View As Views.ViewName)
        Dim NewTaskId As Integer
        Select Case View
            Case ViewName.MyDay
                NewTaskId = Task.AddNewTasks.MyDay(TextBox.Text)
            Case ViewName.Repeated
                NewTaskId = Task.AddNewTasks.Repeated(TextBox.Text)
            Case ViewName.Important
                NewTaskId = Task.AddNewTasks.Important(TextBox.Text)
            Case ViewName.Planned
                NewTaskId = Task.AddNewTasks.Planned(TextBox.Text)
            Case ViewName.Tasks
                NewTaskId = Task.AddNewTasks.Tasks(TextBox.Text)
        End Select

        ' Select the newly added task
        For i As Integer = 0 To CLB.Items.Count - 1
            If CLB.Items(i).ID = NewTaskId Then
                CLB.SelectedIndex = i
                Exit For
            End If
        Next

        TextBox.Clear()
    End Sub

    '*' Delete Task
    Public Sub DeleteTask(SelectedTaskItem As TaskItem)
        Task.DeleteTask(SelectedTaskItem.ID)
    End Sub

    '*' Add Reminder
    Public Sub ShowReminderDialog(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
        Dim Reminder_DialogInstance = New Reminder_Dialog With {.Reminder_SelectedTaskID = SelectedTaskItem.ID, .NeedsDatePicker = True}
        Reminder_DialogInstance.ShowDialog()
        Reminder_DialogInstance.BringToFront()
        Reminder_DialogInstance.Dispose()

        CLB.SelectedIndex = SelectedTaskIndex
    End Sub

    '*' Repeat Task
    Public Sub ShowRepeatDialog(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
        Dim Repeat_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = SelectedTaskItem.ID}
        Repeat_DialogInstance.ShowDialog()
        Repeat_DialogInstance.BringToFront()
        Repeat_DialogInstance.Dispose()

        CLB.SelectedIndex = SelectedTaskIndex
    End Sub

    '*' Add DueDate
    Public Sub ShowDueDateDialog(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
        Dim ItemCountBeforeDueDateChange As Integer = CLB.Items.Count

        Dim DueDate_DialogInstance As New DueDate_Dialog With {.DueDate_SelectedTaskID = SelectedTaskItem.ID}
        DueDate_DialogInstance.ShowDialog()
        DueDate_DialogInstance.BringToFront()
        DueDate_DialogInstance.Dispose()

        If CLB.Items.Count < ItemCountBeforeDueDateChange Then
            CLB.SelectedIndex = SelectedTaskIndex - 1
        Else
            CLB.SelectedIndex = SelectedTaskIndex
        End If
    End Sub

    '*" Check if Selected task is important or not
    Public Function IsTaskImportant(SelectedTaskItem As TaskItem, DT As DataTable) As Boolean
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing Then Return False

        Return CBool(foundRow("IsImportant"))
    End Function

    '*' Get Task
    Public Function GetTaskString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("Task")) Then Return String.Empty

        Return (foundRow("Task"))
    End Function

    '*' Get the task's description
    Public Function GetTaskDescriptionString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("Description")) Then Return String.Empty

        Return (foundRow("Description"))
    End Function

    '*' Get the task's reminder and return as string
    Public Function GetReminderString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("ReminderDateTime")) Then Return String.Empty

        Dim TaskReminder As String
        Dim reminderDateTime As DateTime = Convert.ToDateTime(foundRow("ReminderDateTime"))
        If (reminderDateTime).Date = (DateTime.Today).Date Then
            If My.Settings.TimeFormat = "12" Then
                TaskReminder = reminderDateTime.ToString("hh:mm tt")
            Else
                TaskReminder = reminderDateTime.ToString("HH:mm")
            End If
        Else
            If My.Settings.TimeFormat = "12" Then
                TaskReminder = reminderDateTime.ToString("(dd/MM) hh:mm tt")
            Else
                TaskReminder = reminderDateTime.ToString("(dd/MM) HH:mm")
            End If
        End If
        Return TaskReminder
    End Function

    '*' Get the task's repeat frequency and return the string
    Public Function GetRepeatString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("RepeatedDays")) Then Return String.Empty

        Dim TaskRepeatFrequency As String
        If foundRow("RepeatedDays") = "sun mon tue wed thu fri sat" Then
            TaskRepeatFrequency = "Everyday"
        Else
            TaskRepeatFrequency = "Every..."
        End If
        Return TaskRepeatFrequency
    End Function

    '*' Get the task's DueDate and return as string
    Public Function GetDueDateString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("DueDate")) Then Return String.Empty

        Return CType(foundRow("DueDate"), String)
    End Function

    '*' Get the task's EntryDateTime and return as string
    Public Function GetTaskEntryDateTimeString(SelectedTaskItem As TaskItem, DT As DataTable) As String
        Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)

        If foundRow Is Nothing OrElse IsDBNull(foundRow("EntryDateTime")) Then Return String.Empty

        Dim TaskEntryDateTime As String
        If My.Settings.TimeFormat = "12" Then
            TaskEntryDateTime = Convert.ToDateTime(foundRow("EntryDateTime")).ToString("yyyy-MM-dd  |  hh:mm tt")
        Else
            TaskEntryDateTime = Convert.ToDateTime(foundRow("EntryDateTime")).ToString("yyyy-MM-dd  |  HH:mm")
        End If
        Return TaskEntryDateTime
    End Function
End Module
