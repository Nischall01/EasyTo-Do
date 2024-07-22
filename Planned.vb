Public Class Planned
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim text As String = "Planned"
        Dim font As New Font("Yu Gothic UI Semibold", 20, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)

        ' Draw the text in the center of the PictureBox
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = 0
        Dim textY As Single = (PictureBox1.ClientSize.Height - textSize.Height) / 2

        ' Draw the text
        e.Graphics.DrawString(text, font, brush, New PointF(textX, textY))
    End Sub
End Class