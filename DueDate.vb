Imports System.ComponentModel

Public Class DueDate
    Public DueDate_SelectedTaskIndex As Integer
    Private selectedDate As DateTime

    Private AlreadySetDueDate As Date

    Private dt As New DataTable()

    Private connectionString As String = My.Settings.ConnectionString

    Private Sub DueDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        LoadTable()
        GetAlreadySetDueDate()
        DueDateInitialization()
    End Sub

    Private Sub CloseReminder_Button_Click(sender As Object, e As EventArgs) Handles CloseReminder_Button.Click
        Me.Close()
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        selectedDate = e.Start
    End Sub

    Private Async Sub MonthCalendar1_MouseDown(sender As Object, e As MouseEventArgs) Handles MonthCalendar1.MouseDown
        If selectedDate <> DateTime.MinValue Then
            AddDueDate(selectedDate)
            Await Task.Delay(50)
            Me.Close()
        End If
    End Sub

    Private Sub DueDateInitialization()
        MonthCalendar1.SetDate(AlreadySetDueDate)
    End Sub

#Region "Database and DataTables"
    Private Sub LoadTable()
        Dim query As String = "SELECT * FROM My_Day ORDER BY Task_Index"
        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub AddDueDate(DateSet As DateTime) ' The method to add the reminder to the database
        Dim query As String = "UPDATE My_Day SET DueDate = @DueDate WHERE Task_Index = @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@DueDate", DateSet)
                command.Parameters.AddWithValue("@TaskIndex", DueDate_SelectedTaskIndex)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        'MessageBox.Show("Task description updated successfully.")
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
    End Sub

    Private Sub GetAlreadySetDueDate()
        For Each row As DataRow In dt.Rows
            If row("Task_Index") = DueDate_SelectedTaskIndex Then
                If IsDBNull(row("DueDate")) Then
                    AlreadySetDueDate = Nothing
                Else
                    AlreadySetDueDate = row("DueDate")
                End If
                Exit For
            End If
        Next
    End Sub
#End Region
End Class