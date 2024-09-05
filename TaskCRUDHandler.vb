Namespace TaskCRUDHandler
    Module TaskCRUDHandler

        ' Shared connection string variable
        Private ReadOnly connectionString As String = My.Settings.ConnectionString

        ' Class with methods to add new task for each view
        Public Class AddNewTask

            ' Method to add new task to MyDay view
            Public Shared Function MyDay(NewTask As String) As Integer
                Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, DueDate) VALUES (@Task, @EntryDateTime, @DueDate)"
                Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@Task", NewTask},
                    {"@EntryDateTime", DateTime.Now},
                    {"@DueDate", DateTime.Today}
                }
                Dim rowsAffected As Integer = ExecuteQuery(queryInsertTask, parameters)
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Task added to MyDay successfully.")
                Else
                    MessageBox.Show("No task was added to MyDay. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                ViewsManager.RefreshTasks()
                Return GetNewlyAddedTaskID()
            End Function

            ' Method to add new task to Repeated view
            Public Shared Function Repeated(NewTask As String) As Integer
                Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"
                Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@Task", NewTask},
                    {"@EntryDateTime", DateTime.Now}
                }
                Dim rowsAffected As Integer = ExecuteQuery(queryInsertTask, parameters)
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Task added to Repeated view successfully.")
                Else
                    MessageBox.Show("No task was added to Repeated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                ViewsManager.RefreshTasks()
                Return GetNewlyAddedTaskID()
            End Function

            ' Method to add new task to Important view
            Public Shared Function Important(NewTask As String) As Integer
                Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, IsImportant) VALUES (@Task, @EntryDateTime, @IsImportant)"
                Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@Task", NewTask},
                    {"@EntryDateTime", DateTime.Now},
                    {"@IsImportant", 1}
                }
                Dim rowsAffected As Integer = ExecuteQuery(queryInsertTask, parameters)
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Task marked as Important successfully.")
                Else
                    MessageBox.Show("No task was added to Important. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                ViewsManager.RefreshTasks()
                Return GetNewlyAddedTaskID()
            End Function

            ' Method to add new task to Planned view
            Public Shared Function Planned(NewTask As String) As Integer
                Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, Section) VALUES (@Task, @EntryDateTime, @Section)"
                Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@Task", NewTask},
                    {"@EntryDateTime", DateTime.Now},
                    {"@Section", "Planned"}
                }
                Dim rowsAffected As Integer = ExecuteQuery(queryInsertTask, parameters)
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Task added to Planned view successfully.")
                Else
                    MessageBox.Show("No task was added to Planned. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                ViewsManager.RefreshTasks()
                Return GetNewlyAddedTaskID()
            End Function

            ' Method to add new task to Tasks view
            Public Shared Function Tasks(NewTask As String) As Integer
                Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"
                Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@Task", NewTask},
                    {"@EntryDateTime", DateTime.Now}
                }
                Dim rowsAffected As Integer = ExecuteQuery(queryInsertTask, parameters)
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Task added to Tasks view successfully.")
                Else
                    MessageBox.Show("No task was added to Tasks. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                ViewsManager.RefreshTasks()
                Return GetNewlyAddedTaskID()
            End Function

        End Class

        ' Method to delete a task
        Public Sub DeleteTask(TaskID As Integer)
            Dim queryDeleteTask As String = "DELETE FROM Tasks WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID}
                }
            Dim rowsAffected As Integer = ExecuteQuery(queryDeleteTask, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Task deleted successfully.")
                If GetTasksCount() = 0 Then
                    HardResetTableTasks()
                    Exit Sub
                End If
            Else
                MessageBox.Show("No task was found with the specified ID. Please verify and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to change IsDone status
        Public Sub UpdateStatus(CheckState As Boolean, TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET IsDone = @IsDone WHERE TaskID = @TaskID"
            Dim IsDone As Integer = If(CheckState, 1, 0)
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID},
                    {"@IsDone", IsDone}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Task status updated successfully.")
            Else
                MessageBox.Show("No task was found with the specified ID. Please verify And try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to update task title
        Public Sub UpdateTitle(TaskID As Integer, NewTitle As String)
            Dim query As String = "UPDATE Tasks SET Task = @NewTitle WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID},
                    {"@NewTitle", NewTitle}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                'MessageBox.Show("Task description updated successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.")
            End If
            ViewsManager.RefreshTasks()
            'Method to update task description
        End Sub

        'Method to hard reset the table when the table is empty. So that the id indexing is refreshed/reset.
        Private Sub HardResetTableTasks()
            Dim dropTableQuery As String = "DROP TABLE Tasks"
            Dim createTableQuery As String =
                                        "
                                          CREATE TABLE Tasks
                                          (
                                              TaskID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                                              Task NVARCHAR(256) NOT NULL,
                                              Description NVARCHAR(4000) NULL,
                                              IsDone BIT NOT NULL DEFAULT 0,
                                              IsImportant BIT NOT NULL DEFAULT 0,
                                              DueDate DATETIME NULL,
                                              Section NVARCHAR(256) NULL,
                                              EntryDateTime DATETIME NOT NULL,
                                              RepeatedDays NVARCHAR(256) NULL,
                                              ReminderDateTime DATETIME NULL
                                          );
                                        "
            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()
                    ' Drop the table if it exists
                    Using dropCommand As New SqlCeCommand(dropTableQuery, connection)
                        dropCommand.ExecuteNonQuery()
                    End Using
                    ' Recreate the table
                    Using createCommand As New SqlCeCommand(createTableQuery, connection)
                        createCommand.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL CE error occurred while resetting the Task table: " & ex.Message, "SQL CE Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An unexpected error occurred while resetting the Task table: " & ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            ViewsManager.RefreshTasks()
        End Sub

        '' Helper Methods ''

        ' Method to retrieve the largest TaskID which is also most recent Task's ID
        Private Function GetNewlyAddedTaskID()
            Dim newTaskId As Integer
            Dim queryGetMaxId As String = "SELECT MAX(TaskID) FROM Tasks"
            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()
                    Using maxIdCommand As New SqlCeCommand(queryGetMaxId, connection)
                        newTaskId = maxIdCommand.ExecuteScalar()
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL CE error occurred while getting newly added task's ID: " & ex.Message, "SQL CE Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                newTaskId = -1
            Catch ex As Exception
                MessageBox.Show("An unexpected error occurred while getting newly added task's ID: " & ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                newTaskId = -1
            End Try
            Return newTaskId
        End Function

        ' Method count number of Tasks in the table
        Private Function GetTasksCount() As Integer
            Dim count As Integer
            Dim queryCountTasks As String = "SELECT COUNT(*) FROM Tasks"
            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()
                    Using countCommand As New SqlCeCommand(queryCountTasks, connection)
                        count = Convert.ToInt32(countCommand.ExecuteScalar())
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL CE error occurred while counting the tasks: " & ex.Message, "SQL CE Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                count = -1
            Catch ex As Exception
                MessageBox.Show("An unexpected error occurred while counting the tasks: " & ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                count = -1
            End Try
            Return count
        End Function

        'Method to execute Non-Query
        Private Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As Integer
            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()
                    Using command As New SqlCeCommand(query, connection)
                        For Each param In parameters
                            command.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                        Return command.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show($"A SQL CE error occurred: {ex.Message}", "SQL CE Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            Catch ex As Exception
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
        End Function

    End Module
End Namespace