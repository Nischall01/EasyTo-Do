﻿Module Repeat
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
