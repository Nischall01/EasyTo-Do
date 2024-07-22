Public Class Important
    Private Sub MainTableLayoutPanel_BackColorChanged(sender As Object, e As EventArgs) Handles MainTableLayoutPanel.BackColorChanged
        PictureBox_FormIcon.BackColor = MainTableLayoutPanel.BackColor
        TextBox_FormName.BackColor = MainTableLayoutPanel.BackColor
    End Sub
End Class