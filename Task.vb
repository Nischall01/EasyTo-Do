Module Task
    Private ReadOnly connectionString As String = My.Settings.ConnectionString

    ' Class with methods to add new task for each view
    Public Class AddNewTasks

        'Method to add new task to MyDay view
        Public Shared Function MyDay(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, DueDate) VALUES (@Task, @EntryDateTime, @DueDate)"

            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()

                    Using command As New SqlCeCommand(queryInsertTask, connection)
                        command.Parameters.AddWithValue("@Task", NewTask)
                        command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                        command.Parameters.AddWithValue("@DueDate", DateTime.Today)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Repeated view
        Public Shared Function Repeated(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"

            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()

                    Using command As New SqlCeCommand(queryInsertTask, connection)
                        command.Parameters.AddWithValue("@Task", NewTask)
                        command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Important view
        Public Shared Function Important(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, IsImportant) VALUES (@Task, @EntryDateTime, @IsImportant)"

            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()

                    Using command As New SqlCeCommand(queryInsertTask, connection)
                        command.Parameters.AddWithValue("@Task", NewTask)
                        command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                        command.Parameters.AddWithValue("@IsImportant", 1)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Planned view
        Public Shared Function Planned(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime, Section) VALUES (@Task, @EntryDateTime, @Section)"

            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()

                    Using command As New SqlCeCommand(queryInsertTask, connection)
                        command.Parameters.AddWithValue("@Task", NewTask)
                        command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)
                        command.Parameters.AddWithValue("@Section", "Planned")

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

        'Method to add new task to Tasks view
        Public Shared Function Tasks(NewTask As String) As Integer
            Dim queryInsertTask As String = "INSERT INTO Tasks (Task, EntryDateTime) VALUES (@Task, @EntryDateTime)"
            Try
                Using connection As New SqlCeConnection(connectionString)
                    connection.Open()

                    Using command As New SqlCeCommand(queryInsertTask, connection)
                        command.Parameters.AddWithValue("@Task", NewTask)
                        command.Parameters.AddWithValue("@EntryDateTime", DateTime.Now)


                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            ' MessageBox.Show("Task added successfully.")
                        Else
                            MessageBox.Show("No rows were affected. The task might not have been added.")
                        End If
                    End Using
                End Using
            Catch ex As SqlCeException
                MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Views.RefreshTasks()
            Return GetNewlyAddedTaskID()
        End Function

    End Class

    ' Method to change IsDone status
    Public Sub DoneCheckChanged(CheckState As Boolean, SelectedTaskID As Integer)
        Dim query As String = "UPDATE Tasks SET IsDone = @IsDone WHERE TaskID = @TaskID"
        Dim IsDone As Integer = If(CheckState, 1, 0)

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()

                Using command As New SqlCeCommand(query, connection)
                    ' Use specific type for parameters
                    command.Parameters.AddWithValue("@TaskID", SelectedTaskID)
                    command.Parameters.AddWithValue("@IsDone", IsDone)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        ' MessageBox.Show("Task's importance updated successfully.")
                    Else
                        MessageBox.Show("No task found with the specified ID.")
                    End If
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
        'MsgBox("Done")
    End Sub

    ' Method to change IsImportant status
    Public Sub ImportantCheckChanged(CheckState As Boolean, SelectedTaskID As Integer)
        'MsgBox("Task ID: " & TaskID)
        'MsgBox("IsChecked: " & isChecked)
        Dim query As String = "UPDATE Tasks SET IsImportant = @IsImportant WHERE TaskID = @TaskID"
        Dim IsImportant As Integer = If(CheckState, 1, 0)

        Try
            Using connection As New SqlCeConnection(connectionString)

                connection.Open()
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@TaskID", SelectedTaskID)
                    command.Parameters.AddWithValue("@IsImportant", IsImportant)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        'MessageBox.Show("Task's importance updated successfully.")
                    Else
                        MessageBox.Show("No task found with the specified ID.")
                    End If
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
    End Sub


    ' Method to delete a task 
    Public Sub DeleteTask(SelectedTaskID As Integer)
        Dim query As String = "DELETE FROM Tasks WHERE TaskID = @TaskID"

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()

                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@TaskID", SelectedTaskID)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        'MessageBox.Show("Task deleted successfully.")
                    Else
                        MessageBox.Show("No task found with the specified ID.")
                    End If
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
    End Sub

    Public Sub UpdateTitle(SelectedTaskID As Integer, NewTitle As String)
        Dim query As String = "UPDATE Tasks SET Task = @NewTitle WHERE TaskID = @TaskID"

        Try
            Using connection As New SqlCeConnection(connectionString)

                connection.Open()
                Using transaction = connection.BeginTransaction()
                    Using command As New SqlCeCommand(query, connection)
                        command.Parameters.AddWithValue("@NewTitle", NewTitle)
                        command.Parameters.AddWithValue("@TaskID", SelectedTaskID)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Task description updated successfully.")
                        Else
                            MessageBox.Show("No task found with the specified ID.")
                        End If
                    End Using
                    transaction.Commit()
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
        'Method to update task description
    End Sub

    Public Sub UpdateDescription(NewDescription As String, SelectedTaskID As Integer)
        Dim query As String = "UPDATE Tasks SET Description = @NewDescription WHERE TaskID = @TaskID"

        Try
            Using connection As New SqlCeConnection(connectionString)

                connection.Open()
                Using transaction = connection.BeginTransaction()
                    Using command As New SqlCeCommand(query, connection)
                        command.Parameters.AddWithValue("@NewDescription", NewDescription)
                        command.Parameters.AddWithValue("@TaskID", SelectedTaskID)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Task description updated successfully.")
                        Else
                            MessageBox.Show("No task found with the specified ID.")
                        End If
                    End Using
                    transaction.Commit()
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
        'Method to update task description
    End Sub

#Region "Helper Methods"

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
            MessageBox.Show("SQL CE Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            newTaskId = -1
        Catch ex As Exception
            MessageBox.Show("Unexpected Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            newTaskId = -1
        End Try
        Return newTaskId
    End Function

    'Method to hard reset the table when the table is empty. So that the id indexing is refreshed/reset.
    Private Sub HardResetTableTasks()
        Dim dropTableQuery As String = "DROP TABLE Tasks"
        Dim createTableQuery As String = "
                                          CREATE TABLE Tasks (
                                          TaskID INT IDENTITY(1,1) NOT NULL,
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
                                          ALTER TABLE [Tasks]
                                          ADD CONSTRAINT [Tasks_PK] PRIMARY KEY ([TaskID]);
                                         "
        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()

                ' Begin a transaction
                Using transaction = connection.BeginTransaction()
                    ' Drop the table if it exists
                    Using dropCommand As New SqlCeCommand(dropTableQuery, connection, transaction)
                        dropCommand.ExecuteNonQuery()
                    End Using
                    ' Recreate the table
                    Using createCommand As New SqlCeCommand(createTableQuery, connection, transaction)
                        createCommand.ExecuteNonQuery()
                    End Using
                    ' Commit the transaction
                    transaction.Commit()
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Views.RefreshTasks()
    End Sub

#End Region
End Module
