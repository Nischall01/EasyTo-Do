Namespace TaskPropertiesCRUDHandler
    Module TaskPropertiesCRUDHandler
        ' Shared connection string variable
        Private ReadOnly connectionString As String = My.Settings.ConnectionString

        ' Method to update task description
        Public Sub UpdateDescription(TaskID As Integer, NewDescription As String)
            Dim query As String = "UPDATE Tasks SET Description = @NewDescription WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID},
                    {"@NewDescription", NewDescription}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                'MessageBox.Show("Task description updated successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to change IsImportant status
        Public Sub UpdateImportance(CheckState As Boolean, TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET IsImportant = @IsImportant WHERE TaskID = @TaskID"
            Dim IsImportant As Integer = If(CheckState, 1, 0)
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID},
                    {"@IsImportant", IsImportant}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                'MessageBox.Show("Task's importance updated successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to set DueDate
        Public Sub SetDueDate(DateSet As DateTime, TaskID As Integer)
            Dim query As String = If(DateSet = DateTime.Today,
                "UPDATE Tasks SET DueDate = @DueDate WHERE TaskID = @TaskID",
                "UPDATE Tasks SET DueDate = @DueDate, Section = 'Planned' WHERE TaskID = @TaskID")
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID},
                    {"@DueDate", DateSet}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                'MessageBox.Show("DueDate set successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to remove DueDate
        Public Sub RemoveDueDate(TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET DueDate = Null WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
                {
                    {"@TaskID", TaskID}
                }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                'MessageBox.Show("DueDate removed successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to set Reminder
        Public Sub SetReminder(TimeSet As DateTime, TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET ReminderDateTime = @ReminderDateTime WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
            {
                {"@TaskID", TaskID},
                {"@ReminderDateTime", TimeSet}
            }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Reminder set successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to remove Reminder
        Public Sub RemoveReminder(TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET ReminderDateTime = NULL WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
            {
                {"@TaskID", TaskID}
            }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Reminder removed successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to set Repeat
        Public Sub SetRepeat(RepeatedDays As String, TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET RepeatedDays = @RepeatedDays, Section = 'Repeated', DueDate = NULL WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
            {
                {"@TaskID", TaskID},
                {"@RepeatedDays", RepeatedDays}
            }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Repeat set successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub

        ' Method to remove Repeat
        Public Sub RemoveRepeat(TaskID As Integer)
            Dim query As String = "UPDATE Tasks SET RepeatedDays = NULL WHERE TaskID = @TaskID"
            Dim parameters As New Dictionary(Of String, Object) From
            {
                {"@TaskID", TaskID}
            }
            Dim rowsAffected As Integer = ExecuteQuery(query, parameters)
            If rowsAffected > 0 Then
                ' MessageBox.Show("Repeat removed successfully.")
            Else
                MessageBox.Show("No task found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ViewsManager.RefreshTasks()
        End Sub


        '' Helper Methods ''


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
