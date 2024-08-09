Public Class Repeated_View
    Dim connectionString As String = My.Settings.ConnectionString

    Private dt As New DataTable

    Private Sub Repeated_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToRepeated()
    End Sub

    Public Sub LoadTasksToRepeated()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE IsRepeated = 1 ORDER BY EntryDateTime;"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                Using adapter As New SqlCeDataAdapter(command)
                    connection.Open()
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

        Repeated_CheckedListBox.Items.Clear()
        For Each row As DataRow In dt.Rows
            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            Repeated_CheckedListBox.Items.Add(item, item.IsDone)
        Next
    End Sub
End Class