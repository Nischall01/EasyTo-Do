Imports System.Data.SqlServerCe
Imports System.Diagnostics

Public Class Tasks_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load 
    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToTasks() ' Load all tasks into the CheckedListBox
        Select Case My.Settings.TaskPropertiesSidebarOnStart
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Handling"

    ' Load tasks onto the CheckedListBox
    Public Sub LoadTasksToTasks()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks ORDER BY DueDate;"

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
            dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}
            Tasks_CheckedListBox.Items.Clear()

            'Tasks_CheckedListBox.BeginUpdate() ' Begin update to prevent flickering
            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), CBool(row("IsDone")))
                Tasks_CheckedListBox.Items.Add(item, item.IsDone)
            Next
            'Tasks_CheckedListBox.EndUpdate() ' End update after all items are added

        Catch ex As SqlCeException
            MessageBox.Show("An SQL error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim newTask As String = AddNewTask_TextBox.Text
            If String.IsNullOrWhiteSpace(newTask) Then Exit Sub ' Ensure the task is not empty

            Dim newTaskId As Integer = Task.AddNewTasks.Tasks(newTask) ' Add the new task to the database


            ' Select the newly added task in the CheckedListBox
            For i As Integer = 0 To Tasks_CheckedListBox.Items.Count - 1
                Dim taskItem = CType(Tasks_CheckedListBox.Items(i), TaskItem)
                If taskItem.ID = newTaskId Then
                    Tasks_CheckedListBox.SelectedIndex = i
                    Exit For
                End If
            Next

            AddNewTask_TextBox.Clear() ' Clear the input field
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
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID, "Tasks")
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
            DeleteTaskInvoker() ' Invoke the task deletion method
        End If
    End Sub

    ' Handle task deletion using the Delete key
    Private Sub Tasks_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Tasks_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Tasks_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker()
        End If
    End Sub

#End Region

#Region "Helper Methods"

    ' Task.DeleteTask method invoker
    Private Sub DeleteTaskInvoker()
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
            Dim foundRow As DataRow = dt.Rows.Find(SelectedTaskItem.ID)
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


    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left T")
        'MsgBox("T SelectedItemIndex = " & Tasks_CheckedListBox.SelectedIndex)
    End Sub
End Class
