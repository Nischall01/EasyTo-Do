Public Class Planned_View
    Private connectionString As String = My.Settings.ConnectionString
    Private PlannedDT As New DataTable()
    Private PlannedDT_TaskTitleOnly As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load : Initializes the Repeated tasks view
    Private Sub Planned_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Handling"
    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Tasks()
        PlannedDT.Clear()
        PlannedDT_TaskTitleOnly.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE Section = 'Planned' ORDER BY DueDate;"
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks WHERE Section = 'Planned' ORDER BY DueDate;"

        Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(PlannedDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(PlannedDT_TaskTitleOnly)
                End Using
            End Using
        End Using
        PlannedDT.PrimaryKey = New DataColumn() {PlannedDT.Columns("TaskID")}
        PlannedDT_TaskTitleOnly.PrimaryKey = New DataColumn() {PlannedDT_TaskTitleOnly.Columns("TaskID")}
    End Sub

    ' Load planned tasks into the CheckedListBox.
    Public Sub LoadTasksToPlannedView()
        LoadTasksToDataTables_Tasks()
        Planned_CheckedListBox.Items.Clear()

        For Each row As DataRow In PlannedDT.Rows
            If Not row.IsNull("ReminderDateTime") AndAlso TypeOf row("ReminderDateTime") Is DateTime Then
                Dim RemindedTask As String = row("Task")
                Dim reminderDateTime As DateTime = row.Field(Of DateTime)("ReminderDateTime")
                row("Task") = reminderDateTime.ToString("(hh:mmtt)").ToLower() + "  " + RemindedTask
            End If

            If Not row.IsNull("DueDate") AndAlso TypeOf row("DueDate") Is DateTime Then
                Dim PlannedTask As String = row("Task")
                Dim reminderDueDate As DateTime = row.Field(Of DateTime)("DueDate")
                row("Task") = reminderDueDate.ToString("(dd/MM)").ToLower() + "  " + PlannedTask
            End If

            If row("IsImportant") Then
                Dim ImportantTask As String = "!" + "  " + row("Task")
                row("Task") = ImportantTask
            End If

            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            Planned_CheckedListBox.Items.Add(item, item.IsDone)
        Next
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
        'DisableTaskProperties(True)
    End Sub

    ' Add a new Task Event Handler
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            AddNewPlannedTask()
        End If
    End Sub

    ' CheckedListBox's selected index change event handler
    Private Sub Planned_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Planned_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Planned_CheckedListBox.SelectedIndex

        If Planned_CheckedListBox.SelectedIndex <> -1 Then
            SelectedTaskItem = Planned_CheckedListBox.SelectedItem

            ' Change important icon with respect to selected task
            If IsTaskImportant() Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If
        Else
        End If
    End Sub

    ' Task delete event handlers {
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Planned_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub

    Private Sub Planned_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Planned_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Planned_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub
    ' }

    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub Planned_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Planned_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then
            Exit Sub
        End If

        If SelectedTaskItem IsNot Nothing Then
            TaskManager.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        End If
        Planned_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Button Click event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Planned_CheckedListBox.Items.Count > 0 Then
            If IsTaskImportant() Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTaskItem.ID)
            End If
        Else
            LoseListItemFocus()
        End If
    End Sub

    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    Private Sub Planned_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Planned_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle)
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

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left P")
        'MsgBox("P SelectedItemIndex = " & Planned_CheckedListBox.SelectedIndex) '
    End Sub

#End Region

#Region "Helper Methods"

    ' Task.AddNewTasks.Planned method invoker
    Private Sub AddNewPlannedTask()
        Dim newTask As String = AddNewTask_TextBox.Text
        If String.IsNullOrWhiteSpace(newTask) Then Exit Sub ' Ensure the task is not empty. If empty -> exit method

        Dim NewTaskId As Integer = TaskCRUDHandler.AddNewTask.Planned(newTask) ' Add the new task to the database and get its ID

        ' Prompt to add due date
        Dim DueDate_DialogInstance As New DueDate_Dialog With {.DueDate_SelectedTaskID = NewTaskId}
        DueDate_DialogInstance.ShowDialog()
        DueDate_DialogInstance.BringToFront()
        DueDate_DialogInstance.Dispose()

        ' Select the newly added task
        For i As Integer = 0 To Planned_CheckedListBox.Items.Count - 1
            If Planned_CheckedListBox.Items(i).ID = NewTaskId Then
                Planned_CheckedListBox.SelectedIndex = i
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
            TaskManager.DeleteTask(SelectedTaskItem.ID)

            ' Adjust the selected task index after deletion
            If Planned_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= Planned_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = Planned_CheckedListBox.Items.Count - 1
                End If
                Planned_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsTaskImportant() As Boolean
        Try
            If SelectedTaskItem.ID <= 0 Then
                Return False
            End If

            ' Find the task in the DataTable
            Dim foundRow As DataRow = PlannedDT.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ' Show or hide the task properties panel
    Private Sub ShowOrHideTaskProperties(action As TaskPropertiesVisibility)
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

    Private Sub LoseListItemFocus()
        Planned_CheckedListBox.SelectedItem = Nothing
        Planned_CheckedListBox.SelectedIndex = -1
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