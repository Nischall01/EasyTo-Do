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

    Private Sub MainTableLayoutPanel_BackColorChanged(sender As Object, e As EventArgs) Handles MainTableLayoutPanel.BackColorChanged
        PictureBox_FormIcon.BackColor = MainTableLayoutPanel.BackColor
        TextBox_FormName.BackColor = MainTableLayoutPanel.BackColor
    End Sub
End Class