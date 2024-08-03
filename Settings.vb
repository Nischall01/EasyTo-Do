Public Class Settings
    Private Sub ColorScheme_Changed(Sender As Object, e As EventArgs) Handles ColorScheme_Light_RadioBtn.CheckedChanged, ColorScheme_Dark_RadioBtn.CheckedChanged, ColorScheme_Custom_RadioBtn.CheckedChanged
        If ColorScheme_Light_RadioBtn.Checked Then
            Me.BackColor = Color.FromArgb(255, 255, 255)

            Label1.ForeColor = Color.Black
            ColorScheme_Light_RadioBtn.ForeColor = Color.Black
            ColorScheme_Dark_RadioBtn.ForeColor = Color.Black
            ColorScheme_Custom_RadioBtn.ForeColor = Color.Black

            My.Settings.ColorScheme = "Light"
            ColorScheme.Light()
        ElseIf ColorScheme_Dark_RadioBtn.Checked Then
            Me.BackColor = Color.FromArgb(30, 30, 30)

            Label1.ForeColor = Color.White
            ColorScheme_Light_RadioBtn.ForeColor = Color.White
            ColorScheme_Dark_RadioBtn.ForeColor = Color.White
            ColorScheme_Custom_RadioBtn.ForeColor = Color.White

            My.Settings.ColorScheme = "Dark"
            ColorScheme.Dark()
        Else
            My.Settings.ColorScheme = "Custom"
            ColorScheme.Custom()
        End If
    End Sub
End Class