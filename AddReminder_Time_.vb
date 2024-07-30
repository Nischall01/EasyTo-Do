Public Class AddReminder_Time_

    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    Public Reminder_SelectedTaskIndex As Integer

    Private AlreadySetReminder As DateTime

    Private SelectedHour As String = String.Empty

    Private UserDefaultTimeFormat As Integer = 12

    Private CurrentDateTime As DateTime = DateTime.Now
    Private IsAM As Boolean
    Private IsSelectedTimeFormat12 As Boolean

    Private TimeSet As DateTime

    Private dt As New DataTable()

    Private connectionString As String = "Data Source=To_Do.sdf;Persist Security Info=False;"
#Region "Form Load"
    Private Sub AddReminder_Time__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        LoadTable()

        GetAlreadySetReminder()

        ReminderInitialization()
    End Sub

    Private Sub ReminderInitialization()

        ShowMinutes()

        If AlreadySetReminder <> Nothing Then
            If UserDefaultTimeFormat = 12 Then
                RadioButton1.PerformClick()
                Dim hour12Format As Integer = AlreadySetReminder.Hour Mod 12
                If hour12Format = 0 Then hour12Format = 12

                ComboBox1.SelectedItem = hour12Format.ToString("00")
                ComboBox2.SelectedText = AlreadySetReminder.Minute.ToString("00")

                If AlreadySetReminder.Hour < 12 Then
                    Button1.Text = "AM"
                    IsAM = True
                Else
                    Button1.Text = "PM"
                    IsAM = False
                End If
            Else
                RadioButton2.PerformClick()
                ComboBox1.SelectedItem = AlreadySetReminder.Hour.ToString("00")
                ComboBox2.SelectedText = AlreadySetReminder.Minute.ToString("00")
            End If
        Else
            If UserDefaultTimeFormat = 12 Then
                RadioButton1.PerformClick()
                ComboBox1.SelectedItem = CurrentDateTime.ToString("hh")

                If CurrentDateTime.Hour < 12 Then
                    Button1.Text = "AM"
                    IsAM = True
                Else
                    Button1.Text = "PM"
                    IsAM = False
                End If
            Else
                RadioButton2.PerformClick()
                ComboBox1.SelectedItem = CurrentDateTime.ToString("HH")
            End If

            Dim nearestFive As Integer = CInt(Math.Round(CurrentDateTime.Minute / 5.0) * 5)
            If nearestFive = 60 Then nearestFive = 55 ' Handle edge case where rounding up results in 60
            ComboBox2.SelectedItem = nearestFive.ToString("00")
        End If
    End Sub
#End Region

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


#Region "Database Table"
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
#End Region


#Region "Reminder Settings Methods"
    Private Sub GetAlreadySetReminder()
        For Each row As DataRow In dt.Rows
            If row("Task_Index") = Reminder_SelectedTaskIndex Then
                If IsDBNull(row("Reminder_DateTime")) Then
                    AlreadySetReminder = Nothing
                Else
                    AlreadySetReminder = row("Reminder_DateTime")
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub Show24hrFormatHours()
        ComboBox1.Items.Clear()
        For i As Integer = 0 To 23
            ComboBox1.Items.Add(i.ToString("00"))
        Next
    End Sub

    Private Sub Show12hrFormatHours()
        ComboBox1.Items.Clear()
        For i As Integer = 1 To 12
            ComboBox1.Items.Add(i.ToString("00"))
        Next
    End Sub

    Private Sub ShowMinutes()
        ComboBox2.Items.Clear()
        For i As Integer = 0 To 55 Step 5
            ComboBox2.Items.Add(i.ToString("00"))
        Next
    End Sub

    Private Sub XIIFormat()
        If SelectedHour = "01" Or "02" Or "03" Or "04" Or "05" Or "06" Or "07" Or "08" Or "09" Or "10" Or "11" Then
            If Not IsAM Then Button1_Click(Button1, EventArgs.Empty)
        End If

        Select Case SelectedHour
            Case "00"
                ComboBox1.SelectedItem = "12"
                If Not IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "12"
                ComboBox1.SelectedItem = "12"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "13"
                ComboBox1.SelectedItem = "01"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "14"
                ComboBox1.SelectedItem = "02"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "15"
                ComboBox1.SelectedItem = "03"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "16"
                ComboBox1.SelectedItem = "04"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "17"
                ComboBox1.SelectedItem = "05"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "18"
                ComboBox1.SelectedItem = "06"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "19"
                ComboBox1.SelectedItem = "07"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "20"
                ComboBox1.SelectedItem = "08"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "21"
                ComboBox1.SelectedItem = "09"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "22"
                ComboBox1.SelectedItem = "10"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
            Case "23"
                ComboBox1.SelectedItem = "11"
                If IsAM Then Button1_Click(Button1, EventArgs.Empty)
        End Select

        ComboBox1.Anchor = AnchorStyles.Right
        ComboBox2.Anchor = AnchorStyles.Right
        Button1.Show()
    End Sub

    Private Sub XXIVFormat()
        If Not IsAM Then
            Select Case SelectedHour
                Case "01"
                    ComboBox1.SelectedItem = "13"
                Case "02"
                    ComboBox1.SelectedItem = "14"
                Case "03"
                    ComboBox1.SelectedItem = "15"
                Case "04"
                    ComboBox1.SelectedItem = "16"
                Case "05"
                    ComboBox1.SelectedItem = "17"
                Case "06"
                    ComboBox1.SelectedItem = "18"
                Case "07"
                    ComboBox1.SelectedItem = "19"
                Case "08"
                    ComboBox1.SelectedItem = "20"
                Case "09"
                    ComboBox1.SelectedItem = "21"
                Case "10"
                    ComboBox1.SelectedItem = "22"
                Case "11"
                    ComboBox1.SelectedItem = "23"
                Case "12"
                    ComboBox1.SelectedItem = "12"
            End Select
        Else
            If SelectedHour = "12" Then
                ComboBox1.SelectedItem = "00"
            End If
        End If

        ComboBox1.Anchor = AnchorStyles.Right
        ComboBox2.Anchor = AnchorStyles.Left
        Button1.Hide()
    End Sub

    Private Sub AddReminder()
        Dim query As String = "UPDATE My_Day SET Reminder_DateTime = @Reminder_DateTime WHERE Task_Index = @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Reminder_DateTime", TimeSet)
                command.Parameters.AddWithValue("@TaskIndex", Reminder_SelectedTaskIndex)

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

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            HandleEnterKey()
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub HandleEnterKey()
        Button2_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Reimder Settings Button Events"
    Private Sub Button_CloseAddReminder_Click(sender As Object, e As EventArgs) Handles Button_CloseAddReminder.Click
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then

            IsSelectedTimeFormat12 = True

            If ComboBox1.SelectedItem IsNot Nothing Then
                SelectedHour = ComboBox1.SelectedItem.ToString()
            End If

            Show12hrFormatHours()

            XIIFormat()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then

            IsSelectedTimeFormat12 = False

            If ComboBox1.SelectedItem IsNot Nothing Then
                SelectedHour = ComboBox1.SelectedItem.ToString()
            End If

            Show24hrFormatHours()

            XXIVFormat()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsAM Then
            Button1.Text = "PM"
            IsAM = False
        Else
            Button1.Text = "AM"
            IsAM = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SetHour As Integer
        Dim SetMinute As Integer
        SetHour = Integer.Parse(ComboBox1.Text)
        SetMinute = Integer.Parse(ComboBox2.Text)

        If IsSelectedTimeFormat12 Then
            If SetHour = 12 And IsAM Then
                SetHour = 0 ' 12 AM should be 0 in 24-hour format
            ElseIf SetHour <> 12 And Not IsAM Then
                SetHour += 12
            End If
        End If

        TimeSet = New DateTime(CurrentDateTime.Year, CurrentDateTime.Month, CurrentDateTime.Day, SetHour, SetMinute, 0)

        AddReminder()

        Me.Close()
    End Sub
#End Region
End Class