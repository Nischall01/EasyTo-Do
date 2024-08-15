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
    Public Sub DeleteTask(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox, View As Views.ViewName)
        Task.DeleteTask(SelectedTaskItem.ID)

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

    '*' Add Reminder
    Public Sub AddReminder(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
        Dim Reminder_DialogInstance = New Reminder_Dialog With {.Reminder_SelectedTaskID = SelectedTaskItem.ID, .NeedsDatePicker = True}
        Reminder_DialogInstance.ShowDialog()
        Reminder_DialogInstance.BringToFront()
        Reminder_DialogInstance.Dispose()

        CLB.SelectedIndex = SelectedTaskIndex
    End Sub

    '*' Repeat Task
    Public Sub RepeatTask(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
        Dim Repeat_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = SelectedTaskItem.ID}
        Repeat_DialogInstance.ShowDialog()
        Repeat_DialogInstance.BringToFront()
        Repeat_DialogInstance.Dispose()

        CLB.SelectedIndex = SelectedTaskIndex
    End Sub

    '*' Add DueDate
    Public Sub AddDueDate(SelectedTaskItem As TaskItem, SelectedTaskIndex As Integer, CLB As CheckedListBox)
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
        Try
            If SelectedTaskItem.ID <= 0 Then
                Return False
            End If

            ' Find the task in the DataTable
            Dim foundRow As DataRow = DT.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

End Module
