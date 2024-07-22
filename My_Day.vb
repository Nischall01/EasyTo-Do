Public Class My_Day
    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox_AddNewTask.Focus()
    End Sub

    Private Sub EnterTaskTo_My_Day_ChecklistBox()
        Dim NewDailyTask As String = TextBox_AddNewTask.Text
        CheckedListBox_MyDay.Items.Add(NewDailyTask)
        TextBox_AddNewTask.Clear()
    End Sub

    Private Sub TextBox_AddNewTask_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_AddNewTask.KeyDown
        If e.KeyValue = Keys.Enter Then
            EnterTaskTo_My_Day_ChecklistBox()
        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim text As String = "My Day"
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