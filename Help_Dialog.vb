Public Class Help_Dialog

    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    Private Sub About_Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub

#Region "Window Dragging Logic"

    Private Sub TableLayoutPanel3_MouseDown(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel3.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startX = e.X
            startY = e.Y
        End If
    End Sub

    Private Sub TableLayoutPanel3_MouseMove(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel3.MouseMove
        If isDragging Then
            Dim currentPos = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(currentPos.X - startX, currentPos.Y - startY)
        End If
    End Sub

    Private Sub TableLayoutPanel3_MouseUp(sender As Object, e As MouseEventArgs) Handles TableLayoutPanel3.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

#End Region

    Private Sub CloseHelpDialog_Button_Click(sender As Object, e As EventArgs) Handles CloseHelpDialog_Button.Click
        Me.Close()
    End Sub

    ' Handle the LinkClicked event to open the URL in the default web browser
    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Process.Start(New ProcessStartInfo(e.LinkText) With {.UseShellExecute = True})
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.ActiveControl = Nothing
        Process.Start("https://github.com/Nischall01/EasyTo-Do?tab=readme-ov-file#how-to-use-easyto-do")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ActiveControl = Nothing
        MainWindow.CheckForUpdate(0)
    End Sub

End Class