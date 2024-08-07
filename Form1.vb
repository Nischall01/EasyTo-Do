Public Class Form1
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = Keys.Enter Then
            ListView1.Items.Add(TextBox1.Text)
        End If
    End Sub
End Class