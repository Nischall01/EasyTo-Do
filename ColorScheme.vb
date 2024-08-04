Imports System.Xml

Module ColorScheme

#Region "Scheme Methods"
    Public Sub Light()
        SideBar("Light")
        SetMyDayColorScheme("Light")
        SetDailyColorScheme("Light")
    End Sub

    Public Sub Dark()
        SideBar("Dark")
        SetMyDayColorScheme("Dark")
        SetDailyColorScheme("Dark")
    End Sub

    Public Sub Custom()
        SideBar("Custom")
        SetMyDayColorScheme("Custom")
        SetDailyColorScheme("Custom")
    End Sub
#End Region

#Region "Side Bar"
    Private Sub SideBar(Scheme As String)
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

                MainWindow.Button1.FlatAppearance.MouseOverBackColor = Color.DarkGray
                MainWindow.Button1.FlatAppearance.MouseDownBackColor = Color.Gray
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

                MainWindow.Button1.FlatAppearance.MouseOverBackColor = Color.DarkGray
                MainWindow.Button1.FlatAppearance.MouseDownBackColor = Color.Gray
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

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.White
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.Black

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Show()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.White
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.Black
            Case "Dark"
                MainWindow.MyDayInstance.MainTlp.BackColor = Color.FromArgb(35, 35, 35)
                MainWindow.MyDayInstance.MyDay_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.DayDate_Label.ForeColor = Color.White
                MainWindow.MyDayInstance.Time_Label.ForeColor = Color.White

                MainWindow.MyDayInstance.AddNewTask_TextBox.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.MyDayInstance.AddNewTask_TextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.TaskTitle_TextBox.ForeColor = Color.White

                MainWindow.MyDayInstance.TaskDescription_RichTextBox.Hide()
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.BackColor = Color.FromArgb(40, 40, 40)
                MainWindow.MyDayInstance.TaskDescription_RichTextBox.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub
    Private Sub SetDailyColorScheme(Scheme As String)
        Select Case Scheme
            Case "Light"
                MainWindow.DailyInstance.MainTlp.BackColor = Color.FromArgb(255, 255, 255)
                MainWindow.DailyInstance.Daily_Label.ForeColor = Color.Black
                MainWindow.DailyInstance.TextBox_AddNewTask.BackColor = Color.White
                MainWindow.DailyInstance.TextBox_AddNewTask.ForeColor = Color.Black
            Case "Dark"
                MainWindow.DailyInstance.MainTlp.BackColor = Color.FromArgb(35, 35, 35)
                MainWindow.DailyInstance.Daily_Label.ForeColor = Color.White
                MainWindow.DailyInstance.TextBox_AddNewTask.BackColor = Color.FromArgb(45, 45, 45)
                MainWindow.DailyInstance.TextBox_AddNewTask.ForeColor = Color.White
            Case "Custom"

        End Select
    End Sub
#End Region
End Module
