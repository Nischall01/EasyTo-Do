Imports System.Data.SqlServerCe

Public Class Tasks
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim text As String = "Tasks"
        Dim font As New Font("Yu Gothic UI Semibold", 20, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)

        ' Draw the text in the center of the PictureBox
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = 0
        Dim textY As Single = (PictureBox1.ClientSize.Height - textSize.Height) / 2

        ' Draw the text
        e.Graphics.DrawString(text, font, brush, New PointF(textX, textY))
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Dim connectionString As String = "Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;"
        Dim query As String = "SELECT * FROM My_Day"

        ' Create a DataTable to hold the data
        Dim dataTable As New DataTable()

        Try
            ' Create a new SqlCeConnection
            Using connection As New SqlCeConnection(connectionString)
                ' Create a new SqlCeCommand
                Using command As New SqlCeCommand(query, connection)
                    ' Create a new SqlCeDataAdapter
                    Using adapter As New SqlCeDataAdapter(command)
                        ' Open the connection
                        connection.Open()
                        ' Fill the DataTable with data from the database
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using

            ' Bind the DataTable to the DataGridView
            DataGridView1.DataSource = dataTable

        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadDataIntoDataGridView()
    End Sub
End Class