Public Class Important_View
    Private connectionString As String = My.Settings.ConnectionString

    Private dt As New DataTable()

    Private Sub Important_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToImportant()
    End Sub

#Region "Data Handling"
    ' Load tasks onto the Checked list Box.
    Public Sub LoadTasksToImportant()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE IsImportant = 1 ORDER BY EntryDateTime;"

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
    End Sub


    Private Sub DeleteTask(taskID As Integer)
        Dim query As String = "DELETE FROM Tasks WHERE TaskID = @TaskID"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@TaskID", taskID)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        Views.RefreshTasks()
    End Sub
#End Region

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        Dim TaskToDelete As TaskItem = Important_CheckedListBox.SelectedItem
        DeleteTask(TaskToDelete.ID)
    End Sub
End Class