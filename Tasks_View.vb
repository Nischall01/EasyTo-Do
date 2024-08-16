Imports System.Data.SqlServerCe
Imports System.Diagnostics

Public Class Tasks_View
    Private connectionString As String = My.Settings.ConnectionString
    Private TasksDT As New DataTable()
    Private TasksDT_TaskTitleOnly As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load : Initializes the Repeated tasks view
    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Loading Actions"
    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Tasks()
        TasksDT.Clear()
        TasksDT_TaskTitleOnly.Clear()
        Dim query As String = "SELECT * FROM Tasks ORDER BY DueDate;"
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks ORDER BY DueDate;"

        Using connection As New SqlCeConnection(connectionString)
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
        Tasks_CheckedListBox.Items.Clear()

        For Each row As DataRow In TasksDT.Rows
            If Not row.IsNull("ReminderDateTime") AndAlso TypeOf row("ReminderDateTime") Is DateTime Then
                Dim RemindedTask As String = row("Task")
                Dim reminderDateTime As DateTime = row.Field(Of DateTime)("ReminderDateTime")
                row("Task") = reminderDateTime.ToString("(hh:mmtt)").ToLower() + "  " + RemindedTask
            End If

            If Not row.IsNull("DueDate") AndAlso TypeOf row("DueDate") Is DateTime Then
                If row("DueDate") = DateTime.Today Then
                    Dim PlannedTask As String = row("Task")
                    row("Task") = "(Today)" + "  " + PlannedTask
                Else
                    Dim PlannedTask As String = row("Task")
                    Dim reminderDueDate As DateTime = row.Field(Of DateTime)("DueDate")
                    row("Task") = reminderDueDate.ToString("(dd/MM)").ToLower() + "  " + PlannedTask
                End If
            End If

                If row("IsImportant") Then
                Dim ImportantTask As String = "!" + "  " + row("Task")
                row("Task") = ImportantTask
            End If

            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            Tasks_CheckedListBox.Items.Add(item, item.IsDone)
        Next
    End Sub
#End Region

#Region "Event Handlers"

    ' When the AddNewTask_TextBox gains focus
    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus() ' Clear the selection and focus
    End Sub

    ' Handle adding a new task when the Enter key is pressed
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddNewTasksTask()
        End If
    End Sub

    ' Update the selected task item when the selection changes
    Private Sub Tasks_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tasks_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Tasks_CheckedListBox.SelectedIndex
        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Tasks_CheckedListBox.SelectedItem

            ' Update the important icon based on the selected task's importance
            UpdateImportantButtonIcon()
        End If
    End Sub

    ' Update the task's 'IsDone' status when the checked state changes
    Private Sub Tasks_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Tasks_CheckedListBox.ItemCheck
        If Views._isUiUpdating Then
            Exit Sub
        End If

        'MsgBox("ItemCheck Triggered")
        If SelectedTaskItem IsNot Nothing Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        End If
        Tasks_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Toggle the task's 'IsImportant' status when the important button is clicked
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Tasks_CheckedListBox.Items.Count > 0 AndAlso SelectedTaskItem IsNot Nothing Then
            Dim newImportanceStatus As CheckState = If(IsTaskImportant(), CheckState.Unchecked, CheckState.Checked)
            Task.ImportantCheckChanged(newImportanceStatus, SelectedTaskItem.ID)
            UpdateImportantButtonIcon()

            Tasks_CheckedListBox.SelectedIndex = SelectedTaskIndex
        End If
    End Sub

    ' Hide task properties panel when the close button is clicked
    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide) ' Hide the task properties panel
    End Sub

    ' Show task properties panel on right-click
    Private Sub Tasks_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Tasks_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle) ' Toggle the visibility of task properties
        End If
    End Sub

    ' Change the important button icon on mouse enter
    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Not IsTaskImportant() Then
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        End If
    End Sub

    ' Reset the important button icon on mouse leave
    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Not IsTaskImportant() Then
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
        End If
    End Sub

    ' Handle task deletion when the delete button is clicked
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Tasks_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask() ' Invoke the task deletion method
        End If
    End Sub

    ' Handle task deletion using the Delete key
    Private Sub Tasks_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Tasks_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Tasks_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left T")
        'MsgBox("T SelectedItemIndex = " & Tasks_CheckedListBox.SelectedIndex)
    End Sub

#End Region

#Region "Helper Methods"

    ' Task.AddNewTasks.Task method invoker
    Private Sub AddNewTasksTask()
        Dim newTask As String = AddNewTask_TextBox.Text
        If String.IsNullOrWhiteSpace(newTask) Then Exit Sub ' Ensure the task is not empty. If empty -> exit method

        Dim newTaskId As Integer = Task.AddNewTasks.Tasks(newTask) ' Add the new task to the database and get its ID

        ' Select the newly added task
        For i As Integer = 0 To Tasks_CheckedListBox.Items.Count - 1
            If Tasks_CheckedListBox.Items(i).ID = newTaskId Then
                Tasks_CheckedListBox.SelectedIndex = i
                Exit For
            End If
        Next

        AddNewTask_TextBox.Clear() ' Clear the input field
    End Sub

    ' Task.DeleteTask method invoker
    Private Sub DeleteSelectedTask()
        If SelectedTaskItem Is Nothing Then
            MessageBox.Show("No task is selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Task.DeleteTask(SelectedTaskItem.ID)

            'Adjust the selected task index after deletion
            If Tasks_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= Tasks_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = Tasks_CheckedListBox.Items.Count - 1
                End If
                Tasks_CheckedListBox.SelectedIndex = SelectedTaskIndex
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Check if the selected task is marked as important
    Private Function IsTaskImportant() As Boolean
        If SelectedTaskItem Is Nothing OrElse SelectedTaskItem.ID <= 0 Then
            Return False
        End If

        Try
            ' Locate the task in the DataTable using the primary key
            Dim foundRow As DataRow = TasksDT.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing AndAlso Not IsDBNull(foundRow("IsImportant")) Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ' Show or hide the task properties panel
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

    ' Update the important button icon based on the task's importance
    Private Sub UpdateImportantButtonIcon()
        If IsTaskImportant() Then
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        Else
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
        End If
    End Sub

    ' Lose focus on the task list items
    Private Sub LoseListItemFocus()
        Tasks_CheckedListBox.SelectedItem = Nothing
        Tasks_CheckedListBox.SelectedIndex = -1
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
End Class
