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
