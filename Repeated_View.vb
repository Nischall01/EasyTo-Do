Imports System.Data.SqlServerCe

Public Class Repeated_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load 
    Private Sub Repeated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToRepeated()
        Select Case My.Settings.TaskPropertiesSidebarOnStart
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Handling"

    ' Load important tasks onto the CheckedListBox.
    Public Sub LoadTasksToRepeated()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE RepeatedDays IS NOT NULL;"

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()
                Using transaction = connection.BeginTransaction
                    Using command As New SqlCeCommand(query, connection)
                        Using adapter As New SqlCeDataAdapter(command)
                            adapter.Fill(dt)
                        End Using
                    End Using
                    transaction.Commit()
                End Using
            End Using
            dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}
            Repeated_CheckedListBox.Items.Clear()

            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
                Repeated_CheckedListBox.Items.Add(item, item.IsDone)
            Next

        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
        'DisableTaskProperties(True)
    End Sub

    ' KeyDown event to add a new task
    Private Sub AddNewTask_TextBox_MouseDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim newTask As String = AddNewTask_TextBox.Text
            If String.IsNullOrWhiteSpace(newTask) Then Exit Sub

            Dim NewTaskId As Integer = Task.AddNewTasks.Repeated(newTask)

            ' Prompt to add repeat frequency
            Dim DueDate_DialogInstance As New Repeat_Dialog With {.Repeat_SelectedTaskID = NewTaskId}
            DueDate_DialogInstance.ShowDialog()
            DueDate_DialogInstance.BringToFront()
            DueDate_DialogInstance.Dispose()

            For i As Integer = 0 To Repeated_CheckedListBox.Items.Count - 1
                If Repeated_CheckedListBox.Items(i).ID = NewTaskId Then
                    Repeated_CheckedListBox.SelectedIndex = i
                    Exit For
                End If
            Next

            AddNewTask_TextBox.Clear()
        End If
    End Sub

    ' CheckedListBox's selected index change event handler
    Private Sub Repeated_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Repeated_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Repeated_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Repeated_CheckedListBox.SelectedItem

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
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker()
        End If
    End Sub

    Private Sub Repeated_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Repeated_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Repeated_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker()
        End If
    End Sub
    ' }

    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub Repeated_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Repeated_CheckedListBox.ItemCheck
        If Views._isUiUpdating Then
            Exit Sub
        End If

        If SelectedTaskItem IsNot Nothing Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID, "Repeated")
        End If
        Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Button Click event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Task.ImportantCheckChanged(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                Task.ImportantCheckChanged(CheckState.Checked, SelectedTaskItem.ID)
            End If
        Else
            LoseListItemFocus()
        End If
    End Sub

    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    Private Sub Repeated_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Repeated_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        End If
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Repeated_CheckedListBox.SelectedIndex <> -1 Then
            If IsTaskImportant() Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
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

            ' Adjust the selected task index after deletion
            If Repeated_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= Repeated_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = Repeated_CheckedListBox.Items.Count - 1
                End If
                Repeated_CheckedListBox.SelectedIndex = SelectedTaskIndex
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
            Dim foundRow As DataRow = dt.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub LoseListItemFocus()
        Repeated_CheckedListBox.SelectedItem = Nothing
        Repeated_CheckedListBox.SelectedIndex = -1
    End Sub

#End Region

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left R")
        'MsgBox("R SelectedItemIndex = " & Repeated_CheckedListBox.SelectedIndex)
    End Sub
End Class