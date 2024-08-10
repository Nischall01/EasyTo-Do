Module DueDate
    Private ReadOnly connectionString As String = My.Settings.ConnectionString

    'Method to set DueDate
    Public Sub SetDueDate(DateSet As DateTime, DueDate_SelectedTaskID As Integer)
        Dim query As String = "UPDATE Tasks SET DueDate = @DueDate WHERE TaskID = @TaskID"

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
