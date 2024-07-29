Public Class AddReminder_Time_
    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    Dim SelectedHour As String = String.Empty

    Private UserDefaultTimeFormat As Integer = 12

    Private CurrentDateTime As DateTime = DateTime.Now
    Private IsAM As Boolean

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

    Private Sub Button_CloseAddReminder_Click(sender As Object, e As EventArgs) Handles Button_CloseAddReminder.Click
        Me.Close()
    End Sub

    Private Sub AddReminder_Time__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        ShowMinutes()

        If UserDefaultTimeFormat = 12 Then
            RadioButton1.PerformClick()
            ComboBox1.SelectedItem = CurrentDateTime.ToString("hh")
        ElseIf UserDefaultTimeFormat = 24 Then
            RadioButton2.PerformClick()
            ComboBox1.SelectedItem = CurrentDateTime.ToString("HH")
        Else
            RadioButton1.PerformClick()
            ComboBox1.SelectedItem = CurrentDateTime.ToString("hh")
        End If

        If CurrentDateTime.Hour < 12 Then
            Button1.Text = "AM"
            IsAM = True
        Else
            Button1.Text = "PM"
            IsAM = False
        End If

        Dim nearestFive As Integer = CInt(Math.Round(CurrentDateTime.Minute / 5.0) * 5)
        If nearestFive = 60 Then nearestFive = 55 ' Handle edge case where rounding up results in 60
        ComboBox2.SelectedItem = nearestFive.ToString("00")

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then

            If ComboBox1.SelectedItem IsNot Nothing Then
                SelectedHour = ComboBox1.SelectedItem.ToString()
            End If

            Show12hrFormatHours()

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

            'TableLayoutPanel5.ColumnStyles(0).Width = 18
            'TableLayoutPanel5.ColumnStyles(1).Width = 28
            'TableLayoutPanel5.ColumnStyles(2).Width = 8
            'TableLayoutPanel5.ColumnStyles(3).Width = 28
            'TableLayoutPanel5.ColumnStyles(4).Width = 18
            Button1.Show()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then


            If ComboBox1.SelectedItem IsNot Nothing Then
                SelectedHour = ComboBox1.SelectedItem.ToString()
            End If

            Show24hrFormatHours()

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

            'TableLayoutPanel5.ColumnStyles(0).Width = 50
            'TableLayoutPanel5.ColumnStyles(1).Width = 50
            'TableLayoutPanel5.ColumnStyles(2).Width = 0
            Button1.Hide()
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
        For i As Integer = 0 To 55 Step 5
            ComboBox2.Items.Add(i.ToString("00"))
        Next
    End Sub
End Class