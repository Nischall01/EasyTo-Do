Module SetColorScheme

#Region "Scheme Methods"

    Public Sub Light()
        SetSideBarScheme("Light")
        SetMyDayColorScheme("Light")
        SetRepeatedColorScheme("Light")
        SetImportantColorScheme("Light")
        SetPlannedColorScheme("Light")
        SetTasksColorScheme("Light")
    End Sub

    Public Sub Dark()
        SetSideBarScheme("Dark")
        SetMyDayColorScheme("Dark")
        SetRepeatedColorScheme("Dark")
        SetImportantColorScheme("Dark")
        SetPlannedColorScheme("Dark")
        SetTasksColorScheme("Dark")
    End Sub

    Public Sub Custom()
        SetSideBarScheme("Custom")
        SetMyDayColorScheme("Custom")
        SetRepeatedColorScheme("Custom")
        SetImportantColorScheme("Custom")
        SetPlannedColorScheme("Custom")
        SetTasksColorScheme("Custom")
    End Sub

#End Region

#Region "Side Bar"

    Private Sub SetSideBarScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.Pfp_CircularPictureBox.Invalidate()

                MainWindow.CustomButton1.Label1.ForeColor = Color.Black
                MainWindow.CustomButton2.Label1.ForeColor = Color.Black
                MainWindow.CustomButton3.Label1.ForeColor = Color.Black
                MainWindow.CustomButton4.Label1.ForeColor = Color.Black
                MainWindow.CustomButton5.Label1.ForeColor = Color.Black
                MainWindow.MainSidebarTableLayoutPanel.BackColor = Color.White

                MainWindow.Username_Label.ForeColor = Color.Black
                MainWindow.Test_BackColors.Hide()

                MainWindow.Settings_Button.FlatAppearance.MouseOverBackColor = Color.DarkGray
                MainWindow.Settings_Button.FlatAppearance.MouseDownBackColor = Color.Gray
            Case "Dark"
                MainWindow.Pfp_CircularPictureBox.Invalidate()

                MainWindow.CustomButton1.Label1.ForeColor = Color.White
                MainWindow.CustomButton2.Label1.ForeColor = Color.White
                MainWindow.CustomButton3.Label1.ForeColor = Color.White
                MainWindow.CustomButton4.Label1.ForeColor = Color.White
                MainWindow.CustomButton5.Label1.ForeColor = Color.White
                MainWindow.MainSidebarTableLayoutPanel.BackColor = Color.FromArgb(30, 30, 30)

                MainWindow.Username_Label.ForeColor = Color.White
                MainWindow.Test_BackColors.Hide()

                MainWindow.Settings_Button.FlatAppearance.MouseOverBackColor = Color.DarkGray
                MainWindow.Settings_Button.FlatAppearance.MouseDownBackColor = Color.Gray
            Case "Custom"
                MainWindow.Pfp_CircularPictureBox.Invalidate()

                MainWindow.Test_BackColors.Show()
        End Select
    End Sub

#End Region

#Region "Individual Panels"

    Private Sub SetMyDayColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.MyDayInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.MyDayInstance.MyDay_Label.ForeColor = Color.Black
                MainWindow.MyDayInstance.DayDate_Label.ForeColor = Color.Black
                MainWindow.MyDayInstance.Time_Label.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Show()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.MyDayInstance.MainTlp.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.MyDay_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.DayDate_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.Time_Label.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetRepeatedColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.RepeatedInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.RepeatedInstance.Repeated_Label.ForeColor = Color.Black

                MainWindow.RepeatedInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.RepeatedInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.Show()
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.RepeatedInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.RepeatedInstance.AddNewTask_TextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.RepeatedInstance.MainTlp.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.RepeatedInstance.Repeated_Label.ForeColor = Color.White

                MainWindow.RepeatedInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.RepeatedInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.RepeatedInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.RepeatedInstance.AddNewTask_TextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetImportantColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.ImportantInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.ImportantInstance.Important_Label.ForeColor = Color.Black

                MainWindow.ImportantInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.ImportantInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.ImportantInstance.TaskDescription_RichTextBox.Show()
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.ImportantInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.ImportantInstance.AddNewTask_TextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.ImportantInstance.MainTlp.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.ImportantInstance.Important_Label.ForeColor = Color.White

                MainWindow.ImportantInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.ImportantInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.ImportantInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.ImportantInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.ImportantInstance.AddNewTask_TextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetPlannedColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.PlannedInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.PlannedInstance.Planned_Label.ForeColor = Color.Black

                MainWindow.PlannedInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.PlannedInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.PlannedInstance.TaskDescription_RichTextBox.Show()
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.PlannedInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.PlannedInstance.AddNewTask_TextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.PlannedInstance.MainTlp.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.PlannedInstance.Planned_Label.ForeColor = Color.White

                MainWindow.PlannedInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.PlannedInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.PlannedInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.PlannedInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.PlannedInstance.AddNewTask_TextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetTasksColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.TasksInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.TasksInstance.Tasks_Label.ForeColor = Color.Black

                MainWindow.TasksInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.TasksInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.TasksInstance.TaskDescription_RichTextBox.Show()
                MainWindow.TasksInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.TasksInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.TasksInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.TasksInstance.AddNewTask_TextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.TasksInstance.MainTlp.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.TasksInstance.Tasks_Label.ForeColor = Color.White

                MainWindow.TasksInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.TasksInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.TasksInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.TasksInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.TasksInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.TasksInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.TasksInstance.AddNewTask_TextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub

#End Region

End Module