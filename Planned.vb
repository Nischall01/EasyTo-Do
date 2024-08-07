Imports System.Data.SqlServerCe

Public Class Planned
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable

    Private Sub Planned_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToCheckedListView()
    End Sub

#Region "Data Handling"
    Private Sub LoadTasksToCheckedListView()
        Dim query As String = "SELECT * FROM My_Day WHERE DueDate IS NOT NULL ORDER BY Task_Index;"

        CheckedListBox_Planned.Items.Clear()

        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            ' Fill CheckedListBox with data from the DataTable
            For Each row As DataRow In dt.Rows
                Dim itemText As String = row("Task").ToString()
                Dim isChecked As Boolean = row("Done")
                CheckedListBox_Planned.Items.Add(itemText, isChecked)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub
#End Region
End Class
