Namespace TaskProperties

    Module DueDate
        Private ReadOnly connectionString As String = My.Settings.ConnectionString

        'Method to set DueDate
        Public Sub SetDueDate(DateSet As DateTime, DueDate_SelectedTaskID As Integer)
            Dim query As String

            If DateSet = DateTime.Today Then
                query = "UPDATE Tasks SET DueDate = @DueDate WHERE TaskID = @TaskID"
            Else
                query = "UPDATE Tasks SET DueDate = @DueDate , Section = 'Planned' WHERE TaskID = @TaskID"
            End If

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@DueDate", DateSet)
                    command.Parameters.AddWithValue("@TaskID", DueDate_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("DueDate set successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub

        'Method to Remove DueDate
        Public Sub RemoveDueDate(DueDate_SelectedTaskID As Integer)
            Dim query As String = "UPDATE Tasks SET DueDate = Null WHERE TaskID = @TaskID"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@TaskID", DueDate_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("DueDate removed successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub
    End Module

    Module Reminder
        Private ReadOnly connectionString As String = My.Settings.ConnectionString

        Public Sub SetReminder(TimeSet As DateTime, Reminder_SelectedTaskID As Integer)
            Dim query As String = "UPDATE Tasks SET ReminderDateTime = @ReminderDateTime WHERE TaskID = @TaskID"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@ReminderDateTime", TimeSet)
                    command.Parameters.AddWithValue("@TaskID", Reminder_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Reminder set successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub

        Public Sub RemoveReminder(Reminder_SelectedTaskID As Integer)
            Dim query As String = "UPDATE Tasks SET ReminderDateTime = NULL WHERE TaskID = @TaskID"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@TaskID", Reminder_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Reminder removed successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub
    End Module

    Module Repeat
        Private ReadOnly connectionString As String = My.Settings.ConnectionString

        Public Sub SetRepeat(RepeatedDays As String, Repeat_SelectedTaskID As Integer)
            Dim query As String = "UPDATE Tasks SET RepeatedDays = @RepeatedDays WHERE TaskID = @TaskID"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@RepeatedDays", RepeatedDays)
                    command.Parameters.AddWithValue("@TaskID", Repeat_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Repeat set successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub

        Public Sub RemoveRepeat(Repeat_SelectedTaskID As Integer)
            Dim query As String = "UPDATE Tasks SET RepeatedDays = Null WHERE TaskID = @TaskID"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@TaskID", Repeat_SelectedTaskID)

                    Try
                        connection.Open()
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            'MessageBox.Show("Repeat removed successfully.")
                        Else
                            MessageBox.Show("No task found with the specified index.")
                        End If
                    Catch ex As SqlCeException
                        MessageBox.Show("SQL CE Error: " & ex.Message)
                    Catch ex As Exception
                        MessageBox.Show("Unexpected Error: " & ex.Message)
                    End Try
                End Using
            End Using
            Views.RefreshTasks()
        End Sub
    End Module

End Namespace
