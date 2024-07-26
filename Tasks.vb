Imports System.Data.SqlClient
Imports System.Data.SqlServerCe

Public Class Tasks
    Dim dt As New DataTable()

    Private Sub LoadDataIntoDataGridView()
        dt.Clear()

        Dim connectionString As String = "Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;"
        Dim query As String = "SELECT * FROM My_Day"

        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            DataGridView1.DataSource = dt
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub SaveChanges()
        Try
            ' Get the DataTable that contains only the modified rows
            Dim changes As DataTable = dt.GetChanges(DataRowState.Modified)

            If changes IsNot Nothing AndAlso changes.Rows.Count > 0 Then
                For Each row As DataRow In changes.Rows
                    Dim id As Integer = Convert.ToInt32(row("Id"))
                    Dim task As String = row("Task").ToString()
                    Dim done As Integer = Convert.ToInt32(row("Done"))

                    Dim query As String = "UPDATE My_Day SET Task = @Task, Done = @Done WHERE Id = @Id"

                    Using connection As New SqlCeConnection("Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;")
                        Using command As New SqlCeCommand(query, connection)
                            command.Parameters.AddWithValue("@Id", id)
                            command.Parameters.AddWithValue("@Task", task)
                            command.Parameters.AddWithValue("@Done", done)

                            connection.Open()
                            command.ExecuteNonQuery()
                            connection.Close()
                        End Using
                    End Using
                Next

                MessageBox.Show("Changes saved successfully.")
                ' Accept changes in the original DataTable
                dt.AcceptChanges()
            Else
                MessageBox.Show("No changes to save.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadDataIntoDataGridView()
    End Sub

    'Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
    '    SaveChanges()
    'End Sub

    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define columns
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("Task", GetType(String))
        dt.Columns.Add("Done", GetType(Integer))

        ' Bind DataTable to DataGridView
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveChanges()
    End Sub
End Class
