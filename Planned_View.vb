Imports System.Data.SqlServerCe

Public Class Planned_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable

    Private Sub Planned_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToPlanned()
    End Sub

#Region "Data Handling"
    Public Sub LoadTasksToPlanned()
        Dim query As String = "SELECT * FROM Tasks WHERE DueDate IS NOT NULL ORDER BY DueDate;"

        Planned_CheckedListBox.Items.Clear()

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
                Planned_CheckedListBox.Items.Add(itemText, isChecked)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub
#End Region
End Class
