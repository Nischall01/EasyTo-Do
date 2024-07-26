Imports System.Data.SqlServerCe

Public Class My_Day

    Private dt As New DataTable()

    Private CurrentDateTime As DateTime = DateTime.Now

    Private IsTaskPropertiesVisible As Boolean = False

    Private Task As String
    Private Done As Boolean

    Private Sub InitializeMy_day()
        TextBox_AddNewTask.Focus()
        LoadTasksToCheckedListView()
        ShowOrHideTaskProperties()
        Label3.Text = CurrentDateTime.ToString("dddd, MMMM dd")
    End Sub

    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMy_day()
    End Sub

    Private Sub TextBox_AddNewTask_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_AddNewTask.KeyDown
        If e.KeyValue = Keys.Enter Then
            EnterTaskTo_My_Day_ChecklistBox()
        End If
    End Sub

    '---------------------------------------------------------- BackEnd / Data Procedures --------------------------------------------------------'

    Private Sub EnterTaskTo_My_Day_ChecklistBox()
        Dim NewMy_DayTask As String = TextBox_AddNewTask.Text

        CheckedListBox_MyDay.Items.Add(NewMy_DayTask)
        AddNewTaskToTable_My_Day(NewMy_DayTask)
        TextBox_AddNewTask.Clear()
    End Sub

    Private Sub LoadTasksToCheckedListView()
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

            CheckedListBox_MyDay.Items.Clear()

            ' Fill CheckedListBox with data from the DataTable
            For Each row As DataRow In dt.Rows
                Dim itemText As String = row("Task").ToString()
                Dim isChecked As Boolean = row("Done") <> 0 ' Convert Done to Boolean
                CheckedListBox_MyDay.Items.Add(itemText, isChecked)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub AddNewTaskToTable_My_Day(NewTask As String)
        Dim CurrentDateTime As DateTime = DateTime.Now

        Dim connectionString As String = "Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;"
        Dim query As String = "INSERT INTO My_Day (Task, Done, Entry_DateTime) VALUES (@NewTask, 0, @Entry_DateTime)"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@NewTask", NewTask)
                command.Parameters.AddWithValue("@Entry_DateTime", CurrentDateTime)

                Try
                    ' Open the connection
                    connection.Open()
                    ' Execute the command
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        'MessageBox.Show("Task added successfully.")
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

    'Private Sub SaveChanges()
    '    Try
    '        ' Get the DataTable that contains only the modified rows
    '        Dim changes As DataTable = dt.GetChanges(DataRowState.Modified)

    '        If changes IsNot Nothing AndAlso changes.Rows.Count > 0 Then
    '            For Each row As DataRow In changes.Rows
    '                Dim id As Integer = Convert.ToInt32(row("Id"))
    '                Dim task As String = row("Task").ToString()
    '                Dim done As Integer = Convert.ToInt32(row("Done"))

    '                Dim query As String = "UPDATE My_Day SET Task = @Task, Done = @Done WHERE Id = @Id"

    '                Using connection As New SqlCeConnection("Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;")
    '                    Using command As New SqlCeCommand(query, connection)
    '                        command.Parameters.AddWithValue("@Id", id)
    '                        command.Parameters.AddWithValue("@Task", task)
    '                        command.Parameters.AddWithValue("@Done", done)

    '                        connection.Open()
    '                        command.ExecuteNonQuery()
    '                        connection.Close()
    '                    End Using
    '                End Using
    '            Next

    '            MessageBox.Show("Changes saved successfully.")
    '            ' Accept changes in the original DataTable
    '            dt.AcceptChanges()
    '        Else
    '            MessageBox.Show("No changes to save.")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error saving changes: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub DoneCheckChanged(itemIndex As Integer, isChecked As Boolean)
        'MsgBox("Item Index: " & itemIndex)
        'MsgBox("IsChecked: " & isChecked)

        Dim done As Integer = If(isChecked, 1, 0)
        Dim id As Integer = itemIndex + 1 ' DataTable Id starts From 1 not 0 like ListView

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Done = @Done WHERE Id = @Id"

            Using connection As New SqlCeConnection("Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;")
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@Id", id)
                    command.Parameters.AddWithValue("@Done", done)

                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating task status: " & ex.Message)
        End Try
    End Sub

    Private Sub CheckedListBox_MyDay_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        Dim itemIndex As Integer
        itemIndex = e.Index
        DoneCheckChanged(itemIndex, e.NewValue = CheckState.Checked)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ShowOrHideTaskProperties()
    End Sub

    Private Sub ShowOrHideTaskProperties()
        If IsTaskPropertiesVisible Then
            MainTableLayoutPanel.ColumnStyles(0).SizeType = SizeType.Percent
            MainTableLayoutPanel.ColumnStyles(0).Width = 73%
            MainTableLayoutPanel.ColumnStyles(1).SizeType = SizeType.Percent
            MainTableLayoutPanel.ColumnStyles(1).Width = 27%
            IsTaskPropertiesVisible = False
        Else
            MainTableLayoutPanel.ColumnStyles(0).SizeType = SizeType.Percent
            MainTableLayoutPanel.ColumnStyles(0).Width = 100%
            MainTableLayoutPanel.ColumnStyles(1).SizeType = SizeType.Percent
            MainTableLayoutPanel.ColumnStyles(1).Width = 0%
            IsTaskPropertiesVisible = True
        End If
    End Sub

    Private Sub CheckedListBox_MyDay_MouseDown(sender As Object, e As MouseEventArgs) Handles CheckedListBox_MyDay.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties()
        End If
    End Sub

    Private Sub CheckedListBox_MyDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_MyDay.SelectedIndexChanged
        If CheckedListBox_MyDay.SelectedIndex <> -1 Then
            TextBox1.Text = CheckedListBox_MyDay.SelectedItem.ToString()
        End If
    End Sub
End Class