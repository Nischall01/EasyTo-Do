Imports System.Data.SqlClient
Imports System.Data.SqlServerCe

Public Class Tasks
    Private connectionString As String = My.Settings.ConnectionString

    Private dt As New DataTable()

    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToTasks()
    End Sub

#Region "Data Handling"
    ' Load tasks onto the Checked list Box.
    Public Sub LoadTasksToTasks()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks;"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                Using adapter As New SqlCeDataAdapter(command)
                    connection.Open()
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

        Tasks_CheckedListBox.Items.Clear()
        For Each row As DataRow In dt.Rows
            Dim item As New TaskItem(row("Task").ToString(), CInt(row("TaskID")), If(IsDBNull(row("IsDone")), False, CBool(row("IsDone"))))
            Tasks_CheckedListBox.Items.Add(item, item.IsDone)
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
    End Sub
#End Region

    Private Sub Delete_Button_Click(sender As Object, e As EventArgs) Handles Delete_Button.Click
        Dim TaskToDelete As TaskItem = Tasks_CheckedListBox.SelectedItem
        DeleteTask(TaskToDelete.TaskID)
        LoadTasksToTasks()
        MainWindow.MyDayInstance.LoadTasksToMyDay()
        MainWindow.ImportantInstance.LoadTasksToImportant()
    End Sub

    Private Sub Description_Button_Click(sender As Object, e As EventArgs) Handles Description_Button.Click
        Dim TaskToShowDescription As TaskItem = Tasks_CheckedListBox.SelectedItem
        For Each row As DataRow In dt.Rows
            If row("TaskId") = TaskToShowDescription.TaskID Then
                MsgBox(row("Description"))
            End If
        Next
    End Sub
End Class
