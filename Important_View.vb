Imports System.Data.SqlServerCe

Public Class Important_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

#Region "On Load"

    ' Form on load 
    Private Sub Important_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToImportant()
    End Sub

#End Region

#Region "Data Handling"

    ' Load important tasks onto the CheckedListBox.
    Public Sub LoadTasksToImportant()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE IsImportant = 1 ORDER BY EntryDateTime;"

        Important_CheckedListBox.Items.Clear()

        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            Important_CheckedListBox.Items.Clear()
            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
                Important_CheckedListBox.Items.Add(item, item.IsDone)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    ' Add a new Task Event Handler
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim newTask As String = AddNewTask_TextBox.Text
            If String.IsNullOrWhiteSpace(newTask) Then Exit Sub

            Dim newTaskId As Integer = Task.AddNewTasks.Important(newTask)

            For i As Integer = 0 To Important_CheckedListBox.Items.Count - 1
                If Important_CheckedListBox.Items(i).ID = newTaskId Then
                    Important_CheckedListBox.SelectedIndex = i
                    Exit For
                End If
            Next

            AddNewTask_TextBox.Clear()
            AddNewTask_TextBox.Focus()
        End If
    End Sub

    ' CheckedListBox's selected index change event handler
    Private Sub Important_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Important_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Important_CheckedListBox.SelectedIndex
        SelectedTaskItem = CType(Important_CheckedListBox.SelectedItem, TaskItem)
    End Sub

    ' Task delete event handlers {
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Important_CheckedListBox.SelectedIndex <> -1 Then
            DeleteTaskInvoker()
        End If
    End Sub

    Private Sub Important_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Important_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete Then
            If Important_CheckedListBox.SelectedIndex <> -1 Then
                DeleteTaskInvoker()
            End If
        End If
    End Sub
    ' }

#End Region

#Region "Helper Methods"

    'Task DeleteTask method invoker
    Private Sub DeleteTaskInvoker()
        If SelectedTaskItem IsNot Nothing AndAlso SelectedTaskItem.ID > 0 Then
            Task.DeleteTask(SelectedTaskItem.ID)

            If Important_CheckedListBox.Items.Count > 0 Then
                Important_CheckedListBox.SelectedIndex = Math.Max(0, SelectedTaskIndex - 1)
            Else
                Important_CheckedListBox_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
    End Sub

#End Region
End Class