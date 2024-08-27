Public Class Repeat_Dialog
    Enum State
        Enable
        Disable
    End Enum

    Private connectionString As String = My.Settings.ConnectionString

    Private dt As New DataTable()

    Public Repeat_SelectedTaskID As Integer

    Private AlreadySetRepeat As String

    Private Sub Repeat_Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        LoadTable()
        GetAlreadySetRepeat()
        RepeatInitialization()
    End Sub

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

    Private Sub GetAlreadySetRepeat() ' Sub to get if the reminder for the task is already set or not
        For Each row As DataRow In dt.Rows
            If row("TaskID") = Repeat_SelectedTaskID Then
                If IsDBNull(row("RepeatedDays")) Then
                    AlreadySetRepeat = Nothing
                Else
                    AlreadySetRepeat = row("RepeatedDays")
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub RepeatInitialization()
        If AlreadySetRepeat <> Nothing Then
            Select Case AlreadySetRepeat
                Case Nothing
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                Case "sun mon tue wed thu fri sat"
                    RadioButton1.Checked = True
                Case Else
                    RadioButton2.Checked = True
                    If AlreadySetRepeat.Contains("sun") Then
                        CheckBox1.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("mon") Then
                        CheckBox2.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("tue") Then
                        CheckBox3.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("wed") Then
                        CheckBox4.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("thu") Then
                        CheckBox5.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("fri") Then
                        CheckBox6.Checked = True
                    End If
                    If AlreadySetRepeat.Contains("sat") Then
                        CheckBox7.Checked = True
                    End If
            End Select
        End If
    End Sub

    Private Sub CloseReminder_Button_Click(sender As Object, e As EventArgs) Handles CloseReminder_Button.Click
        Me.Close()
    End Sub

    Private Sub RepeatTypeChanged_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            EnableOrDisableDays(State.Enable)
        Else
            EnableOrDisableDays(State.Disable)
        End If
    End Sub

    Private Sub EnableOrDisableDays(DaysState As State)
        Select Case DaysState
            Case State.Enable
                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True
                CheckBox4.Enabled = True
                CheckBox5.Enabled = True
                CheckBox6.Enabled = True
                CheckBox7.Enabled = True
            Case State.Disable
                CheckBox1.Enabled = False
                CheckBox2.Enabled = False
                CheckBox3.Enabled = False
                CheckBox4.Enabled = False
                CheckBox5.Enabled = False
                CheckBox6.Enabled = False
                CheckBox7.Enabled = False
        End Select
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then
            Dim RepeatedDays As String = "sun mon tue wed thu fri sat"
            TaskPropertiesCRUDHandler.SetRepeat(RepeatedDays, Repeat_SelectedTaskID)
            Me.Close()
        ElseIf RadioButton2.Checked Then
            Dim days As New List(Of String)
            If CheckBox1.Checked Then days.Add("sun")
            If CheckBox2.Checked Then days.Add("mon")
            If CheckBox3.Checked Then days.Add("tue")
            If CheckBox4.Checked Then days.Add("wed")
            If CheckBox5.Checked Then days.Add("thu")
            If CheckBox6.Checked Then days.Add("fri")
            If CheckBox7.Checked Then days.Add("sat")

            Dim RepeatedDays As String = String.Join(" ", days)
            TaskPropertiesCRUDHandler.SetRepeat(RepeatedDays, Repeat_SelectedTaskID)
            Me.Close()
        End If
    End Sub


End Class