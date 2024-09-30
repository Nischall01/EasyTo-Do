Module SetColorScheme

    'Private Const DarkColor As

#Region "Scheme Methods"

    Public Sub Light()
        SetSideBarScheme("Light")
        SetMyDayColorScheme("Light")
        SetRepeatedColorScheme("Light")
        SetImportantColorScheme("Light")
        SetPlannedColorScheme("Light")
        SetTasksColorScheme("Light")
        SetCustomTitleBarScheme("Light")
    End Sub

    Public Sub Dark()
        SetSideBarScheme("Dark")
        SetMyDayColorScheme("Dark")
        SetRepeatedColorScheme("Dark")
        SetImportantColorScheme("Dark")
        SetPlannedColorScheme("Dark")
        SetTasksColorScheme("Dark")
        SetCustomTitleBarScheme("Dark")
    End Sub

    Public Sub Custom()
        SetSideBarScheme("Custom")
        SetMyDayColorScheme("Custom")
        SetRepeatedColorScheme("Custom")
        SetImportantColorScheme("Custom")
        SetPlannedColorScheme("Custom")
        SetTasksColorScheme("Custom")
        SetCustomTitleBarScheme("Custom")
    End Sub

#End Region

#Region "Custom Taskbar"

    Public Sub SetCustomTitleBarScheme(Scheme As String)
        Select Case Scheme
            Case "Light"

                MainWindow.Label1.ForeColor = Color.Black

                MainWindow.Button1.Image = GlobalResources.CancelIcon_Black
                MainWindow.Button1.BackColor = Color.Transparent
                MainWindow.Button3.Image = GlobalResources.MinimizeIcon_Black
                If MainWindow.isMaximized Then
                    MainWindow.Button2.Image = GlobalResources.RestoreIcon_Black
                Else
                    MainWindow.Button2.Image = GlobalResources.FullscreenIcon_Black
                End If

                MainWindow.Panel1.BackColor = Color.FromArgb(217, 217, 217)

                MainWindow.Button4.Image = GlobalResources.ModeSwitch_Light

            Case "Dark"
                MainWindow.Label1.ForeColor = Color.White

                MainWindow.Button1.Image = GlobalResources.CancelIcon_White
                MainWindow.Button1.BackColor = Color.Transparent
                MainWindow.Button3.Image = GlobalResources.MinimizeIcon_White
                If MainWindow.isMaximized Then
                    MainWindow.Button2.Image = GlobalResources.RestoreIcon_White
                Else
                    MainWindow.Button2.Image = GlobalResources.FullscreenIcon_White
                End If

                MainWindow.Panel1.BackColor = Color.FromArgb(38, 38, 38)

                MainWindow.Button4.Image = GlobalResources.ModeSwitch_Dark
            Case "Custom"
        End Select
    End Sub

#End Region

#Region "Side Bar"

    Private Sub SetSideBarScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.Pfp_CircularPictureBox.Invalidate()
                MainWindow.MainSidebarTableLayoutPanel.BackColor = Color.FromArgb(225, 225, 225)

                MainWindow.CustomButton1.Label1.ForeColor = Color.Black
                MainWindow.CustomButton2.Label1.ForeColor = Color.Black
                MainWindow.CustomButton3.Label1.ForeColor = Color.Black
                MainWindow.CustomButton4.Label1.ForeColor = Color.Black
                MainWindow.CustomButton5.Label1.ForeColor = Color.Black

                MainWindow.Username_Label.ForeColor = Color.Black
                MainWindow.Test_BackColors.Hide()

                MainWindow.Settings_Button.BackgroundImage = GlobalResources.SettingsIcon_Black

                MainWindow.Help_Button.BackgroundImage = GlobalResources.HelpIcon_Black
            Case "Dark"
                MainWindow.Pfp_CircularPictureBox.Invalidate()

                MainWindow.MainSidebarTableLayoutPanel.BackColor = Color.FromArgb(30, 30, 30)

                MainWindow.CustomButton1.Label1.ForeColor = Color.White
                MainWindow.CustomButton2.Label1.ForeColor = Color.White
                MainWindow.CustomButton3.Label1.ForeColor = Color.White
                MainWindow.CustomButton4.Label1.ForeColor = Color.White
                MainWindow.CustomButton5.Label1.ForeColor = Color.White

                MainWindow.Username_Label.ForeColor = Color.White
                MainWindow.Test_BackColors.Hide()

                MainWindow.Settings_Button.BackgroundImage = GlobalResources.SettingsIcon_White

                MainWindow.Help_Button.BackgroundImage = GlobalResources.HelpIcon_White
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
                MainWindow.MyDayInstance.MainTlp_SubTlpTaskView.BackColor = Color.White
                MainWindow.MyDayInstance.MyDayView_Label.ForeColor = Color.Black
                MainWindow.MyDayInstance.DayDate_Label.ForeColor = Color.Black
                MainWindow.MyDayInstance.Time_Label.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Show()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.WhiteSmoke
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.MyDay_CheckedListBox.ForeColor = Color.Black
                MainWindow.MyDayInstance.MyDay_CheckedListBox.BackColor = Color.White

                MainWindow.MyDayInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(214, 214, 214)
                MainWindow.MyDayInstance.CloseTaskProperties_Button.ForeColor = Color.Black
                MainWindow.MyDayInstance.Label_ADT.ForeColor = Color.Black
                MainWindow.MyDayInstance.Label_TaskEntryDateTime.ForeColor = Color.Black

                MainWindow.MyDayInstance.CustomButton_AddReminder.Label1.ForeColor = Color.Black
                MainWindow.MyDayInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                MainWindow.MyDayInstance.CustomButton_Repeat.Label1.ForeColor = Color.Black
                MainWindow.MyDayInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black
                MainWindow.MyDayInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.Black
                MainWindow.MyDayInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_Black

                MainWindow.MyDayInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
            Case "Dark"
                MainWindow.MyDayInstance.MainTlp_SubTlpTaskView.BackColor = Color.FromArgb(16, 12, 10)
                MainWindow.MyDayInstance.MyDayView_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.DayDate_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.Time_Label.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(30, 30, 30)
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.MyDay_CheckedListBox.ForeColor = Color.White
                MainWindow.MyDayInstance.MyDay_CheckedListBox.BackColor = Color.FromArgb(16, 12, 10)

                MainWindow.MyDayInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(41, 41, 41)
                MainWindow.MyDayInstance.CloseTaskProperties_Button.ForeColor = Color.White
                MainWindow.MyDayInstance.Label_ADT.ForeColor = Color.White
                MainWindow.MyDayInstance.Label_TaskEntryDateTime.ForeColor = Color.White

                MainWindow.MyDayInstance.CustomButton_AddReminder.Label1.ForeColor = Color.White
                MainWindow.MyDayInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                MainWindow.MyDayInstance.CustomButton_Repeat.Label1.ForeColor = Color.White
                MainWindow.MyDayInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White
                MainWindow.MyDayInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.White
                MainWindow.MyDayInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_White

                MainWindow.MyDayInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetRepeatedColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.RepeatedInstance.MainTlp_SubTlpTaskView.BackColor = Color.White
                MainWindow.RepeatedInstance.RepeatedView_Label.ForeColor = Color.Black

                MainWindow.RepeatedInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.RepeatedInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.Show()
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.RepeatedInstance.AddNewTask_TextBox.BackColor = Color.WhiteSmoke
                MainWindow.RepeatedInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.RepeatedInstance.Repeated_CheckedListBox.ForeColor = Color.Black
                MainWindow.RepeatedInstance.Repeated_CheckedListBox.BackColor = Color.White

                MainWindow.RepeatedInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(214, 214, 214)
                MainWindow.RepeatedInstance.CloseTaskProperties_Button.ForeColor = Color.Black
                MainWindow.RepeatedInstance.Label_ADT.ForeColor = Color.Black
                MainWindow.RepeatedInstance.Label_TaskEntryDateTime.ForeColor = Color.Black

                MainWindow.RepeatedInstance.CustomButton_AddReminder.Label1.ForeColor = Color.Black
                MainWindow.RepeatedInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                MainWindow.RepeatedInstance.CustomButton_Repeat.Label1.ForeColor = Color.Black
                MainWindow.RepeatedInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black

                MainWindow.RepeatedInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
            Case "Dark"
                MainWindow.RepeatedInstance.MainTlp_SubTlpTaskView.BackColor = Color.FromArgb(16, 12, 10)
                MainWindow.RepeatedInstance.RepeatedView_Label.ForeColor = Color.White

                MainWindow.RepeatedInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.RepeatedInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(30, 30, 30)
                MainWindow.RepeatedInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.RepeatedInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.RepeatedInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.RepeatedInstance.Repeated_CheckedListBox.ForeColor = Color.White
                MainWindow.RepeatedInstance.Repeated_CheckedListBox.BackColor = Color.FromArgb(16, 12, 10)

                MainWindow.RepeatedInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(41, 41, 41)
                MainWindow.RepeatedInstance.CloseTaskProperties_Button.ForeColor = Color.White
                MainWindow.RepeatedInstance.Label_ADT.ForeColor = Color.White
                MainWindow.RepeatedInstance.Label_TaskEntryDateTime.ForeColor = Color.White

                MainWindow.RepeatedInstance.CustomButton_AddReminder.Label1.ForeColor = Color.White
                MainWindow.RepeatedInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                MainWindow.RepeatedInstance.CustomButton_Repeat.Label1.ForeColor = Color.White
                MainWindow.RepeatedInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White

                MainWindow.RepeatedInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetImportantColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.ImportantInstance.MainTlp_SubTlpTaskView.BackColor = Color.White
                MainWindow.ImportantInstance.ImportantView_Label.ForeColor = Color.Black

                MainWindow.ImportantInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.ImportantInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.ImportantInstance.TaskDescription_RichTextBox.Show()
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.ImportantInstance.AddNewTask_TextBox.BackColor = Color.WhiteSmoke
                MainWindow.ImportantInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.ImportantInstance.Important_CheckedListBox.ForeColor = Color.Black
                MainWindow.ImportantInstance.Important_CheckedListBox.BackColor = Color.White

                MainWindow.ImportantInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(214, 214, 214)
                MainWindow.ImportantInstance.CloseTaskProperties_Button.ForeColor = Color.Black
                MainWindow.ImportantInstance.Label_ADT.ForeColor = Color.Black
                MainWindow.ImportantInstance.Label_TaskEntryDateTime.ForeColor = Color.Black

                MainWindow.ImportantInstance.CustomButton_AddReminder.Label1.ForeColor = Color.Black
                MainWindow.ImportantInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                MainWindow.ImportantInstance.CustomButton_Repeat.Label1.ForeColor = Color.Black
                MainWindow.ImportantInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black
                MainWindow.ImportantInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.Black
                MainWindow.ImportantInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_Black

                MainWindow.ImportantInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
            Case "Dark"
                MainWindow.ImportantInstance.MainTlp_SubTlpTaskView.BackColor = Color.FromArgb(16, 12, 10)
                MainWindow.ImportantInstance.ImportantView_Label.ForeColor = Color.White

                MainWindow.ImportantInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.ImportantInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.ImportantInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(30, 30, 30)
                MainWindow.ImportantInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.ImportantInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.ImportantInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.ImportantInstance.Important_CheckedListBox.ForeColor = Color.White
                MainWindow.ImportantInstance.Important_CheckedListBox.BackColor = Color.FromArgb(16, 12, 10)

                MainWindow.ImportantInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(41, 41, 41)
                MainWindow.ImportantInstance.CloseTaskProperties_Button.ForeColor = Color.White
                MainWindow.ImportantInstance.Label_ADT.ForeColor = Color.White
                MainWindow.ImportantInstance.Label_TaskEntryDateTime.ForeColor = Color.White

                MainWindow.ImportantInstance.CustomButton_AddReminder.Label1.ForeColor = Color.White
                MainWindow.ImportantInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                MainWindow.ImportantInstance.CustomButton_Repeat.Label1.ForeColor = Color.White
                MainWindow.ImportantInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White
                MainWindow.ImportantInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.White
                MainWindow.ImportantInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_White

                MainWindow.ImportantInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetPlannedColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.PlannedInstance.MainTlp_SubTlpTaskView.BackColor = Color.White
                MainWindow.PlannedInstance.PlannedView_Label.ForeColor = Color.Black

                MainWindow.PlannedInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.PlannedInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.PlannedInstance.TaskDescription_RichTextBox.Show()
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.PlannedInstance.AddNewTask_TextBox.BackColor = Color.WhiteSmoke
                MainWindow.PlannedInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.PlannedInstance.Planned_CheckedListBox.ForeColor = Color.Black
                MainWindow.PlannedInstance.Planned_CheckedListBox.BackColor = Color.White

                MainWindow.PlannedInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(214, 214, 214)
                MainWindow.PlannedInstance.CloseTaskProperties_Button.ForeColor = Color.Black
                MainWindow.PlannedInstance.Label_ADT.ForeColor = Color.Black
                MainWindow.PlannedInstance.Label_TaskEntryDateTime.ForeColor = Color.Black

                MainWindow.PlannedInstance.CustomButton_AddReminder.Label1.ForeColor = Color.Black
                MainWindow.PlannedInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                MainWindow.PlannedInstance.CustomButton_Repeat.Label1.ForeColor = Color.Black
                MainWindow.PlannedInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black
                MainWindow.PlannedInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.Black
                MainWindow.PlannedInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_Black

                MainWindow.PlannedInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
            Case "Dark"
                MainWindow.PlannedInstance.MainTlp_SubTlpTaskView.BackColor = Color.FromArgb(16, 12, 10)
                MainWindow.PlannedInstance.PlannedView_Label.ForeColor = Color.White

                MainWindow.PlannedInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.PlannedInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.PlannedInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(30, 30, 30)
                MainWindow.PlannedInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.PlannedInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.PlannedInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.PlannedInstance.Planned_CheckedListBox.ForeColor = Color.White
                MainWindow.PlannedInstance.Planned_CheckedListBox.BackColor = Color.FromArgb(16, 12, 10)

                MainWindow.PlannedInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(41, 41, 41)
                MainWindow.PlannedInstance.CloseTaskProperties_Button.ForeColor = Color.White
                MainWindow.PlannedInstance.Label_ADT.ForeColor = Color.White
                MainWindow.PlannedInstance.Label_TaskEntryDateTime.ForeColor = Color.White

                MainWindow.PlannedInstance.CustomButton_AddReminder.Label1.ForeColor = Color.White
                MainWindow.PlannedInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                MainWindow.PlannedInstance.CustomButton_Repeat.Label1.ForeColor = Color.White
                MainWindow.PlannedInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White
                MainWindow.PlannedInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.White
                MainWindow.PlannedInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_White

                MainWindow.PlannedInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
            Case "Custom"

        End Select
    End Sub

    Private Sub SetTasksColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.TasksInstance.MainTlp_SubTlpTaskView.BackColor = Color.White
                MainWindow.TasksInstance.TasksView_Label.ForeColor = Color.Black

                MainWindow.TasksInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.TasksInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.TasksInstance.TaskDescription_RichTextBox.Show()
                MainWindow.TasksInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.TasksInstance.TaskDescription_RichTextBox.ForeColor = Color.Black

                MainWindow.TasksInstance.AddNewTask_TextBox.BackColor = Color.WhiteSmoke
                MainWindow.TasksInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.TasksInstance.Tasks_CheckedListBox.ForeColor = Color.Black
                MainWindow.TasksInstance.Tasks_CheckedListBox.BackColor = Color.White

                MainWindow.TasksInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(214, 214, 214)
                MainWindow.TasksInstance.CloseTaskProperties_Button.ForeColor = Color.Black
                MainWindow.TasksInstance.Label_ADT.ForeColor = Color.Black
                MainWindow.TasksInstance.Label_TaskEntryDateTime.ForeColor = Color.Black

                MainWindow.TasksInstance.CustomButton_AddReminder.Label1.ForeColor = Color.Black
                MainWindow.TasksInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_Black
                MainWindow.TasksInstance.CustomButton_Repeat.Label1.ForeColor = Color.Black
                MainWindow.TasksInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_Black
                MainWindow.TasksInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.Black
                MainWindow.TasksInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_Black

                MainWindow.TasksInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_Black
            Case "Dark"
                MainWindow.TasksInstance.MainTlp_SubTlpTaskView.BackColor = Color.FromArgb(16, 12, 10)
                MainWindow.TasksInstance.TasksView_Label.ForeColor = Color.White

                MainWindow.TasksInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.TasksInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.TasksInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.TasksInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(30, 30, 30)
                MainWindow.TasksInstance.TaskDescription_RichTextBox.ForeColor = Color.White

                MainWindow.TasksInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.TasksInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.TasksInstance.Tasks_CheckedListBox.ForeColor = Color.White
                MainWindow.TasksInstance.Tasks_CheckedListBox.BackColor = Color.FromArgb(16, 12, 10)

                MainWindow.TasksInstance.MainTlp_SubTlpTaskProperties.BackColor = Color.FromArgb(41, 41, 41)
                MainWindow.TasksInstance.CloseTaskProperties_Button.ForeColor = Color.White
                MainWindow.TasksInstance.Label_ADT.ForeColor = Color.White
                MainWindow.TasksInstance.Label_TaskEntryDateTime.ForeColor = Color.White

                MainWindow.TasksInstance.CustomButton_AddReminder.Label1.ForeColor = Color.White
                MainWindow.TasksInstance.CustomButton_AddReminder.PictureBox1.Image = GlobalResources.ReminderIcon_White
                MainWindow.TasksInstance.CustomButton_Repeat.Label1.ForeColor = Color.White
                MainWindow.TasksInstance.CustomButton_Repeat.PictureBox1.Image = GlobalResources.RepeatIcon_White
                MainWindow.TasksInstance.CustomButton_AddDueDate.Label1.ForeColor = Color.White
                MainWindow.TasksInstance.CustomButton_AddDueDate.PictureBox1.Image = GlobalResources.DueDateIcon_White

                MainWindow.TasksInstance.DeleteTask_Button.BackgroundImage = GlobalResources.DeleteIcon_White
            Case "Custom"

        End Select
    End Sub

#End Region

End Module