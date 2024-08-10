Module Task
    Private ReadOnly connectionString As String = My.Settings.ConnectionString

    ' Class with methods to add new task for each view
    Public Class AddNewTasks

        'Method to add new task to MyDay view
        Public Shared Function MyDay(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, DueDate) VALUES (@Task, @EntryDateTime, @DueDate)"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(queryInsertTask, connection)
                    command.Parameters.AddWithValue("@Task", NewTask)
                    command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                    command.Parameters.AddWithValue("@DueDate", DateTime.Today)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' Optionally notify success
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Repeated view
        Public Shared Function Repeated(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, IsRepeated) VALUES (@Task, @EntryDateTime, @IsRepeated)"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(queryInsertTask, connection)
                    command.Parameters.AddWithValue("@Task", NewTask)
                    command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                    command.Parameters.AddWithValue("@IsRepeated", 1)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' Optionally notify success
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Important view
        Public Shared Function Important(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, IsImportant) VALUES (@Task, @EntryDateTime, @IsImportant)"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(queryInsertTask, connection)
                    command.Parameters.AddWithValue("@Task", NewTask)
                    command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                    command.Parameters.AddWithValue("@IsImportant", 1)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' Optionally notify success
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Planned view
        Public Shared Function Planned(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(queryInsertTask, connection)
                    command.Parameters.AddWithValue("@Task", NewTask)
                    command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' Optionally notify success
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Tasks view
        Public Shared Function Tasks(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(queryInsertTask, connection)
                    command.Parameters.AddWithValue("@Task", NewTask)
                    command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' Optionally notify success
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

    End Class

    ' Method to delete a task 
    Public Sub DeleteTask(SelectedTaskID As Integer)
        Dim query As String = "DELETE FROM Tasks WHERE TaskID = @TaskID"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@TaskID", SelectedTaskID)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using
        Views.RefreshTasks()
    End Sub


#Region "Helper Methods"

    ' Method to retrieve the largest TaskID which is also most recent Task's ID 
    Private Function GetNewlyAddedTaskID()
        Dim newTaskId As Integer
        Dim queryGetMaxId As String = "SELECT MAX(TaskID) FROM Tasks"

        Using connection As New SqlCeConnection(connectionString)
            Using maxIdCommand As New SqlCeCommand(queryGetMaxId, connection)

                Try
                    connection.Open()
                    newTaskId = maxIdCommand.ExecuteScalar()
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                    newTaskId = -1
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                    newTaskId = -1
                End Try
            End Using
        End Using
        Return newTaskId
    End Function

#End Region
End Module
