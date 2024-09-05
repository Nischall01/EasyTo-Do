Public Class Settings_Dialog

    Private TimeFormatAtStart As String

    Public Sub New()
        InitializeComponent()
        TimeFormatAtStart = My.Settings.TimeFormat
    End Sub

    Private Sub ColorScheme_Changed(Sender As Object, e As EventArgs) Handles ColorScheme_Light_RadioBtn.CheckedChanged, ColorScheme_Dark_RadioBtn.CheckedChanged, ColorScheme_Custom_RadioBtn.CheckedChanged
        If ColorScheme_Light_RadioBtn.Checked Then
            Me.BackColor = Color.FromArgb(250, 250, 250)

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

            My.Settings.ColorScheme = "Light"
            SetColorScheme.Light()
        ElseIf ColorScheme_Dark_RadioBtn.Checked Then
            Me.BackColor = Color.FromArgb(35, 35, 35)

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

            My.Settings.ColorScheme = "Dark"
            SetColorScheme.Dark()
        Else
            My.Settings.ColorScheme = "Custom"
            SetColorScheme.Custom()
        End If
    End Sub

    Private Sub Sidebar_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton3.Checked Then
            My.Settings.SidebarOnStart = "Expanded"
        ElseIf RadioButton2.Checked Then
            My.Settings.SidebarOnStart = "Collapsed"
        End If
    End Sub

    Private Sub TaskPropertiesSidebar_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged, RadioButton1.CheckedChanged
        If RadioButton4.Checked Then
            My.Settings.TaskPropertiesSidebarOnStart = "Expanded"
        ElseIf RadioButton1.Checked Then
            My.Settings.TaskPropertiesSidebarOnStart = "Collapsed"
        End If
    End Sub

    Private Sub TimeFormat_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged, RadioButton5.CheckedChanged
        If RadioButton6.Checked Then
            My.Settings.TimeFormat = "12"
        ElseIf RadioButton5.Checked Then
            My.Settings.TimeFormat = "24"
        End If
    End Sub

    Private Sub TimeFormat_Clicked(sender As Object, e As EventArgs) Handles RadioButton6.Click, RadioButton5.Click
        MessageBox.Show("The time format change will take effect after restarting the application.", "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PfpSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        If CheckBox1.Checked Then
            My.Settings.IsPfpVisible = False
            MainWindow.Pfp_CircularPictureBox.Hide()
        Else
            My.Settings.IsPfpVisible = True
            MainWindow.Pfp_CircularPictureBox.Show()
        End If

        If CheckBox2.Checked Then
            My.Settings.IsUsernameVisible = False
            MainWindow.Username_Label.Hide()
        Else
            My.Settings.IsUsernameVisible = True
            MainWindow.Username_Label.Show()
        End If
    End Sub

End Class