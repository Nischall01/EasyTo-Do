Public Class DueDate_Dialog
    Public DueDate_SelectedTaskID As Integer

    Private AlreadySetDueDate As Date

    Private dt As New DataTable()

    Private connectionString As String = My.Settings.ConnectionString

    Private Sub DueDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        LoadTable()
        GetAlreadySetDueDate()
        DueDateInitialization()
    End Sub

#Region "Database DataTable"

    Private Sub LoadTable()
        Dim query As String = "SELECT * FROM Tasks"
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

#End Region

    Private Sub CloseReminder_Button_Click(sender As Object, e As EventArgs) Handles CloseReminder_Button.Click
        Me.Close()
    End Sub

    Private Sub DueDateInitialization()
        MonthCalendar1.SetDate(AlreadySetDueDate)
    End Sub

    Private Sub GetAlreadySetDueDate()
        For Each row As DataRow In dt.Rows
            If row("TaskID") = DueDate_SelectedTaskID Then
                If IsDBNull(row("DueDate")) Then
                    AlreadySetDueDate = Nothing
                Else
                    AlreadySetDueDate = row("DueDate")
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SelectedDate As DateTime = MonthCalendar1.SelectionEnd

        If SelectedDate.ToString("yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Can't pick today as the due date in Planned View." & vbCrLf & "Please use My Day View for that.")
            Exit Sub
        End If

        TaskPropertiesCRUDHandler.SetDueDate(SelectedDate.Date, DueDate_SelectedTaskID)
        Me.Close()
    End Sub

End Class