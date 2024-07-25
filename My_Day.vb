Imports System.Data.SqlServerCe

Public Class My_Day
    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox_AddNewTask.Focus()
    End Sub
    Private Sub AddNewTaskToTable_My_Day(NewTask As String)
        Dim connectionString As String = "Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;"
        Dim query As String = "INSERT INTO My_Day (Task, Done) VALUES (@NewTask, 0)"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@NewTask", NewTask)

                Try
                    ' Open the connection
                    connection.Open()
                    ' Execute the command
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Task added successfully.")
                    Else
                        MessageBox.Show("No rows were affected. The task might not have been added.")
                    End If

                Catch ex As SqlCeException
                    ' Detailed SQL CE exception
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    ' General exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub EnterTaskTo_My_Day_ChecklistBox()
        Dim NewMy_DayTask As String = TextBox_AddNewTask.Text
        CheckedListBox_MyDay.Items.Add(NewMy_DayTask)

        AddNewTaskToTable_My_Day(NewMy_DayTask)

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