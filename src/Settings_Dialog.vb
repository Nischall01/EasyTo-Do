﻿Imports System.IO

Public Class Settings_Dialog

    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    Public Sub New()
        InitializeComponent()
        Me.FormBorderStyle = FormBorderStyle.None
        ColorScheme_Custom_RadioBtn.Enabled = False
    End Sub

#Region "Window Dragging Logic"

    Private Sub TableLayoutPanel18_MouseDown(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel18.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startX = e.X
            startY = e.Y
        End If
    End Sub

    Private Sub TableLayoutPanel18_MouseMove(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel18.MouseMove
        If isDragging Then
            Dim currentPos = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(currentPos.X - startX, currentPos.Y - startY)
        End If
    End Sub

    Private Sub TableLayoutPanel18_MouseUp(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel18.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

#End Region

    Private Sub ColorScheme_Changed(Sender As Object, e As EventArgs) Handles ColorScheme_Light_RadioBtn.CheckedChanged, ColorScheme_Dark_RadioBtn.CheckedChanged, ColorScheme_Custom_RadioBtn.CheckedChanged
        If ColorScheme_Light_RadioBtn.Checked Then

            Me.BackColor = Color.FromArgb(255, 255, 255)
            TabPage1.BackColor = Color.FromArgb(255, 255, 255)
            TabPage2.BackColor = Color.FromArgb(255, 255, 255)
            TabPage3.BackColor = Color.FromArgb(255, 255, 255)
            TabPage4.BackColor = Color.FromArgb(255, 255, 255)

            Label1.ForeColor = Color.Black
            ColorScheme_Light_RadioBtn.ForeColor = Color.Black
            ColorScheme_Dark_RadioBtn.ForeColor = Color.Black
            ColorScheme_Custom_RadioBtn.ForeColor = Color.Black

            Label2.ForeColor = Color.Black
            RadioButton2.ForeColor = Color.Black
            RadioButton3.ForeColor = Color.Black

            Label3.ForeColor = Color.Black
            RadioButton4.ForeColor = Color.Black
            RadioButton1.ForeColor = Color.Black

            Label4.ForeColor = Color.Black
            RadioButton6.ForeColor = Color.Black
            RadioButton5.ForeColor = Color.Black

            Label5.ForeColor = Color.Black
            CheckBox1.ForeColor = Color.Black
            CheckBox2.ForeColor = Color.Black

            Label6.ForeColor = Color.Black
            RadioButton7.ForeColor = Color.Black
            RadioButton8.ForeColor = Color.Black

            Label7.ForeColor = Color.Black
            RadioButton9.ForeColor = Color.Black
            RadioButton10.ForeColor = Color.Black

            Label8.ForeColor = Color.Black
            RadioButton12.ForeColor = Color.Black
            RadioButton11.ForeColor = Color.Black

            Label9.ForeColor = Color.Black

            Label11.ForeColor = Color.Black
            RadioButton13.ForeColor = Color.Black
            RadioButton14.ForeColor = Color.Black

            Label14.ForeColor = Color.Black
            RadioButton20.ForeColor = Color.Black
            RadioButton19.ForeColor = Color.Black

            Label10.ForeColor = Color.Black
            RadioButton21.ForeColor = Color.Black
            RadioButton22.ForeColor = Color.Black

            Label12.ForeColor = Color.Black
            RadioButton23.ForeColor = Color.Black
            RadioButton24.ForeColor = Color.Black

            Label13.ForeColor = Color.Black
            RadioButton25.ForeColor = Color.Black
            RadioButton26.ForeColor = Color.Black

            My.Settings.ColorScheme = "Light"
            SetColorScheme.Light()
        ElseIf ColorScheme_Dark_RadioBtn.Checked Then

            Me.BackColor = Color.FromArgb(20, 20, 20)
            TabPage1.BackColor = Color.FromArgb(20, 20, 20)
            TabPage2.BackColor = Color.FromArgb(20, 20, 20)
            TabPage3.BackColor = Color.FromArgb(20, 20, 20)
            TabPage4.BackColor = Color.FromArgb(20, 20, 20)

            Label1.ForeColor = Color.White
            ColorScheme_Light_RadioBtn.ForeColor = Color.White
            ColorScheme_Dark_RadioBtn.ForeColor = Color.White
            ColorScheme_Custom_RadioBtn.ForeColor = Color.White

            Label2.ForeColor = Color.White
            RadioButton2.ForeColor = Color.White
            RadioButton3.ForeColor = Color.White

            Label3.ForeColor = Color.White
            RadioButton4.ForeColor = Color.White
            RadioButton1.ForeColor = Color.White

            Label4.ForeColor = Color.White
            RadioButton6.ForeColor = Color.White
            RadioButton5.ForeColor = Color.White

            Label5.ForeColor = Color.White
            CheckBox1.ForeColor = Color.White
            CheckBox2.ForeColor = Color.White

            Label6.ForeColor = Color.White
            RadioButton7.ForeColor = Color.White
            RadioButton8.ForeColor = Color.White

            Label7.ForeColor = Color.White
            RadioButton9.ForeColor = Color.White
            RadioButton10.ForeColor = Color.White

            Label8.ForeColor = Color.White
            RadioButton12.ForeColor = Color.White
            RadioButton11.ForeColor = Color.White

            Label9.ForeColor = Color.White

            Label11.ForeColor = Color.White
            RadioButton13.ForeColor = Color.White
            RadioButton14.ForeColor = Color.White

            Label14.ForeColor = Color.White
            RadioButton20.ForeColor = Color.White
            RadioButton19.ForeColor = Color.White

            Label10.ForeColor = Color.White
            RadioButton21.ForeColor = Color.White
            RadioButton22.ForeColor = Color.White

            Label12.ForeColor = Color.White
            RadioButton23.ForeColor = Color.White
            RadioButton24.ForeColor = Color.White

            Label13.ForeColor = Color.White
            RadioButton25.ForeColor = Color.White
            RadioButton26.ForeColor = Color.White

            My.Settings.ColorScheme = "Dark"
            SetColorScheme.Dark()
        Else
            My.Settings.ColorScheme = "Custom"
            SetColorScheme.Custom()
        End If
        SettingsCache.UpdateSettingsCache()
    End Sub

    Private Sub Sidebar_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton3.Checked Then
            My.Settings.SidebarStateOnStart = "Expanded"
        ElseIf RadioButton2.Checked Then
            My.Settings.SidebarStateOnStart = "Collapsed"
        End If
    End Sub

    Private Sub TaskPropertiesSidebar_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged, RadioButton1.CheckedChanged
        If RadioButton4.Checked Then
            My.Settings.TaskPropertiesSidebarStateOnStart = "Expanded"
        ElseIf RadioButton1.Checked Then
            My.Settings.TaskPropertiesSidebarStateOnStart = "Collapsed"
        End If
    End Sub

    Private Sub TimeFormat_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged, RadioButton5.CheckedChanged
        If RadioButton6.Checked Then
            My.Settings.TimeFormat = "12"
        ElseIf RadioButton5.Checked Then
            My.Settings.TimeFormat = "24"
        End If
        SettingsCache.UpdateSettingsCache()
    End Sub

    Private Sub OnDeleteAskForConfirmation_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged, RadioButton8.CheckedChanged
        If RadioButton7.Checked Then
            My.Settings.OnDeleteAskForConfirmation = True
        ElseIf RadioButton8.Checked Then
            My.Settings.OnDeleteAskForConfirmation = False
        End If
        SettingsCache.UpdateSettingsCache()
    End Sub

    Private Sub Sorting_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged, RadioButton10.CheckedChanged
        If RadioButton9.Checked Then
            My.Settings.SortByCompletionStatus = True
        ElseIf RadioButton10.Checked Then
            My.Settings.SortByCompletionStatus = False
        End If
        SettingsCache.UpdateSettingsCache()
        ViewsManager.RefreshTasks()
    End Sub

    Private Sub HideCompletedTasks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged, RadioButton12.CheckedChanged
        If RadioButton11.Checked Then
            My.Settings.HideCompletedTasks = True
        ElseIf RadioButton12.Checked Then
            My.Settings.HideCompletedTasks = False
        End If
        SettingsCache.UpdateSettingsCache()
        ViewsManager.RefreshTasks()
    End Sub

    Private Sub TasksSize_TrackBar_Scroll(sender As Object, e As EventArgs) Handles TasksSize_TrackBar.Scroll
        Dim TrackBarValue As Integer = TasksSize_TrackBar.Value

        My.Settings.TasksSize = TrackBarValue

        Dim fontSize As Single = GetFontSizeFromValue(TasksSize_TrackBar.Value)

        MainWindow.ChangeTasksSize(fontSize)
    End Sub

    Private Sub TasksFont_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton13.CheckedChanged, RadioButton14.CheckedChanged
        If RadioButton13.Checked Then
            SelectedFont_TextBox.Enabled = False
            SelectTasksFont_Button.Enabled = False

            Dim fontSize As Single = GetFontSizeFromValue(TasksSize_TrackBar.Value)

            MainWindow.ChangeTasksFont(GlobalResources.DefaultFont)
            SelectedFont_TextBox.Clear()

            My.Settings.IsTaskFontDefault = True

        ElseIf RadioButton14.Checked Then
            SelectedFont_TextBox.Enabled = True
            SelectTasksFont_Button.Enabled = True

            MainWindow.ChangeTasksFont(SettingsCache.SelectedTaskFont)
            SelectedFont_TextBox.Text = SettingsCache.SelectedTaskFont.Name

            My.Settings.IsTaskFontDefault = False

        End If
    End Sub

    Private Sub SelectTasksFont_Click(sender As Object, e As EventArgs) Handles SelectTasksFont_Button.Click
        ' Load the saved font from My.Settings into FontDialog1 before showing it
        FontDialog1.Font = SettingsCache.SelectedTaskFont
        ' Show the FontDialog and check if the user clicked OK
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            ' Retrieve the selected font from FontDialog1
            Dim selectedFont As Font = FontDialog1.Font

            SelectedFont_TextBox.Text = selectedFont.Name

            MainWindow.ChangeTasksFont(selectedFont)
            My.Settings.SelectedTaskFont = selectedFont
            SettingsCache.UpdateSettingsCache()
        End If
    End Sub

    Private Sub OnStartupCheckForUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton19.CheckedChanged, RadioButton20.CheckedChanged
        If RadioButton19.Checked Then
            My.Settings.OnStartupCheckForUpdate = True
        ElseIf RadioButton20.Checked Then
            My.Settings.OnStartupCheckForUpdate = False
        End If
    End Sub

    Private Sub OnCloseRunInTheBackground_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton21.CheckedChanged, RadioButton22.CheckedChanged
        If RadioButton21.Checked Then
            My.Settings.OnCloseRunInTheBackground = True
        ElseIf RadioButton22.Checked Then
            My.Settings.OnCloseRunInTheBackground = False
        End If
        SettingsCache.UpdateSettingsCache()
    End Sub

    Private Sub RunOnStartup_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton23.CheckedChanged, RadioButton24.CheckedChanged
        If RadioButton23.Checked Then
            My.Settings.RunOnWindowsStartup = True

            TableLayoutPanel31.Enabled = True

            If My.Settings.PopupOnStartup Then
                StartupShortcut.CreateStartupShortcut(1)
            Else
                StartupShortcut.CreateStartupShortcut(2)
            End If

        ElseIf RadioButton24.Checked Then
            My.Settings.RunOnWindowsStartup = False

            TableLayoutPanel31.Enabled = False

            StartupShortcut.DeleteStartupShortcut()
        End If
    End Sub

    Private Sub PopupOnStartup_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton25.CheckedChanged, RadioButton26.CheckedChanged
        If RadioButton25.Checked Then
            My.Settings.PopupOnStartup = True
            StartupShortcut.DeleteStartupShortcut()
            StartupShortcut.CreateStartupShortcut(1)
        ElseIf RadioButton26.Checked Then
            My.Settings.PopupOnStartup = False
            StartupShortcut.DeleteStartupShortcut()
            StartupShortcut.CreateStartupShortcut(2)
        End If
    End Sub

    Private Sub PfpSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            My.Settings.IsPfpVisible = False
            MainWindow.Pfp_CircularPictureBox.Hide()
        Else
            My.Settings.IsPfpVisible = True
            MainWindow.Pfp_CircularPictureBox.Show()
        End If
    End Sub

    Private Sub UsernameSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            My.Settings.IsUsernameVisible = False
            MainWindow.Username_Label.Hide()
        Else
            My.Settings.IsUsernameVisible = True
            MainWindow.Username_Label.Show()
            If MainWindow.IsSidebarExpanded = False Then
                MainWindow.Username_Label.Hide()
            End If
        End If
    End Sub

    ' Helper function to get the font size based on the input value
    Private Function GetFontSizeFromValue(Value As Integer) As Single
        Select Case Value
            Case 0
                Return 12.75F
            Case 1
                Return 13.0F
            Case 2
                Return 14.0F
            Case 3
                Return 15.0F
            Case 4
                Return 16.0F
            Case 5
                Return 17.0F
            Case Else
                Return 12.75F
        End Select
    End Function

    Private Sub CloseSettingsDialog_Button_Click(sender As Object, e As EventArgs) Handles CloseSettingsDialog_Button.Click
        Me.Close()
    End Sub
End Class