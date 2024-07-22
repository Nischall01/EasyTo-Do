Public Class Daily
    Private Sub Daily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim textbox1 As New TextBox

        textbox1.Show()
        textbox1.Text = "Daily"

        Me.Controls.Add(textbox1)
    End Sub

    Private Sub MainTableLayoutPanel_BackColorChanged(sender As Object, e As EventArgs) Handles MainTableLayoutPanel.BackColorChanged
        PictureBox_FormIcon.BackColor = MainTableLayoutPanel.BackColor
        TextBox_FormName.BackColor = MainTableLayoutPanel.BackColor
    End Sub
End Class