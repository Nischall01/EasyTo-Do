Public Class DueDate_Dialog

    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    Public DueDate_SelectedTaskID As Integer

    Public isCloseButtonDisabled As Boolean

    Private AlreadySetDueDate As Date

    Private dt As New DataTable()

    Private ReadOnly connectionString As String = My.Settings.ConnectionString

    Private Sub DueDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        LoadTable()
        GetAlreadySetDueDate()
        DueDateInitialization()

        If isCloseButtonDisabled Then
            CloseDueDateDialog_Button.Enabled = False
        Else
            CloseDueDateDialog_Button.Enabled = True
        End If
    End Sub

#Region "Window Dragging Logic"

    Private Sub TableLayoutPanel2_MouseDown(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel2.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startX = e.X
            startY = e.Y
        End If
    End Sub

    Private Sub TableLayoutPanel2_MouseMove(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel2.MouseMove
        If isDragging Then
            Dim currentPos = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(currentPos.X - startX, currentPos.Y - startY)
        End If
    End Sub

    Private Sub TableLayoutPanel2_MouseUp(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel2.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

#End Region

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

    Private Sub CloseReminder_Button_Click(sender As Object, e As EventArgs) Handles CloseDueDateDialog_Button.Click
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