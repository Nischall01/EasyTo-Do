Imports System.Threading

Namespace TaskManager
    Module TaskManager
        '*' Add New Task
        Public Function AddNewTask(TextBox As TextBox, CLB As CheckedListBox, View As ViewName)
            Dim NewTaskId As Integer
            Select Case View
                Case ViewName.MyDay
                    NewTaskId = TaskCRUDHandler.AddNewTask.MyDay(TextBox.Text)
                Case ViewName.Repeated
                    NewTaskId = TaskCRUDHandler.AddNewTask.Repeated(TextBox.Text)
                Case ViewName.Important
                    NewTaskId = TaskCRUDHandler.AddNewTask.Important(TextBox.Text)
                Case ViewName.Planned
                    NewTaskId = TaskCRUDHandler.AddNewTask.Planned(TextBox.Text)
                Case ViewName.Tasks
                    NewTaskId = TaskCRUDHandler.AddNewTask.Tasks(TextBox.Text)
            End Select
            TextBox.Clear()
            UiUtils.TaskSelection_Retain(CLB, NewTaskId)
            Return NewTaskId
        End Function

        '*' Delete Task
        Public Sub DeleteTask(TaskID As Integer, CLB As CheckedListBox, TaskIndex As Integer, View As ViewName)
            TaskCRUDHandler.DeleteTask(TaskID)
            UiUtils.TaskSelection_Shift(CLB, TaskIndex, View)
        End Sub

        '*' Add Reminder
        Public Sub ShowReminderDialog(TaskID As Integer, CLB As CheckedListBox)
            Dim Reminder_DialogInstance = New Reminder_Dialog With {.Reminder_SelectedTaskID = TaskID, .NeedsDatePicker = True}
            Reminder_DialogInstance.ShowDialog()
            Reminder_DialogInstance.BringToFront()
            Reminder_DialogInstance.Dispose()
            UiUtils.TaskSelection_Retain(CLB, TaskID)
        End Sub

        '*' Remove Reminder
        Public Sub RemoveReminder(TaskID As Integer, CLB As CheckedListBox, TaskIndex As Integer)
            TaskPropertiesCRUDHandler.RemoveReminder(TaskID)
            UiUtils.TaskSelection_Retain(CLB, TaskID)
        End Sub

        '*' Repeat Task
        Public Sub ShowRepeatDialog(TaskID As Integer, CLB As CheckedListBox)
            Dim Repeat_DialogInstance = New Repeat_Dialog With {.Repeat_SelectedTaskID = TaskID}
            Repeat_DialogInstance.ShowDialog()
            Repeat_DialogInstance.BringToFront()
            Repeat_DialogInstance.Dispose()
            UiUtils.TaskSelection_Retain(CLB, TaskID)
        End Sub

        '*' Remove Repeat
        Public Sub RemoveRepeat(TaskID As Integer, CLB As CheckedListBox, TaskIndex As Integer, View As ViewName)
            Dim TaskCount As Integer = CLB.Items.Count
            TaskPropertiesCRUDHandler.RemoveRepeat(TaskID)
            If CLB.Items.Count < TaskCount Then
                UiUtils.TaskSelection_Shift(CLB, TaskIndex, View)
            Else
                UiUtils.TaskSelection_Retain(CLB, TaskID)
            End If
        End Sub

        '*' Add DueDate
        Public Sub ShowDueDateDialog(TaskID As Integer, TaskIndex As Integer, CLB As CheckedListBox, View As ViewName)
            Dim TaskCountBeforeAddingDueDate As Integer = CLB.Items.Count

            Dim DueDate_DialogInstance = New DueDate_Dialog With {.DueDate_SelectedTaskID = TaskID}
            DueDate_DialogInstance.ShowDialog()
            DueDate_DialogInstance.BringToFront()
            DueDate_DialogInstance.Dispose()

            If CLB.Items.Count < TaskCountBeforeAddingDueDate Then
                UiUtils.TaskSelection_Shift(CLB, TaskIndex, View)
            Else
                UiUtils.TaskSelection_Retain(CLB, TaskID)
            End If
        End Sub

        '*' Remove DueDate
        Public Sub RemoveDueDate(TaskID As Integer, CLB As CheckedListBox, TaskIndex As Integer, View As ViewName)
            Dim TaskCountBeforeRemoval As Integer = CLB.Items.Count
            TaskPropertiesCRUDHandler.RemoveDueDate(TaskID)
            If CLB.Items.Count < TaskCountBeforeRemoval Then
                UiUtils.TaskSelection_Shift(CLB, TaskIndex, View)
            Else
                UiUtils.TaskSelection_Retain(CLB, TaskID)
            End If
        End Sub

        Public Sub UpdateStatus(CheckState As Boolean, TaskID As Integer)
            TaskCRUDHandler.UpdateStatus(CheckState, TaskID)
        End Sub

        Public Sub UpdateTitle(TaskID As Integer, NewTitle As String)
            TaskCRUDHandler.UpdateTitle(TaskID, NewTitle)
        End Sub

        Public Sub UpdateImportance(CheckState As Boolean, TaskID As Integer)
            TaskPropertiesCRUDHandler.UpdateImportance(CheckState, TaskID)
        End Sub

        Public Sub UpdateDescription(TaskID As Integer, NewDescription As String)
            TaskPropertiesCRUDHandler.UpdateDescription(TaskID, NewDescription)
        End Sub

        '*" Check if Selected task is important or not
        Public Function IsTaskImportant(TaskID As Integer, DT As DataTable) As Boolean
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

            If foundRow Is Nothing Then Return False

            Return CBool(foundRow("IsImportant"))
        End Function

        '*' Get Task
        Public Function GetTaskString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

            If foundRow Is Nothing OrElse IsDBNull(foundRow("Task")) Then Return String.Empty

            Return (foundRow("Task"))
        End Function

        '*' Get the task's description
        Public Function GetTaskDescriptionString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

            If foundRow Is Nothing OrElse IsDBNull(foundRow("Description")) Then Return String.Empty

            Return (foundRow("Description"))
        End Function

        '*' Get the task's reminder and return as string
        Public Function GetReminderString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

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
        Public Function GetRepeatString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

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
        Public Function GetDueDateString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

            If foundRow Is Nothing OrElse IsDBNull(foundRow("DueDate")) Then Return String.Empty

            Return CType(foundRow("DueDate"), String)
        End Function

        '*' Get the task's EntryDateTime and return as string
        Public Function GetTaskEntryDateTimeString(TaskID As Integer, DT As DataTable) As String
            Dim foundRow As DataRow = DT.Rows.Find(TaskID)

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
End Namespace
