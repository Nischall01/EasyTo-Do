Imports System.Data.SqlServerCe

Public Class My_Day

    ' Image cache variables
    Private UncheckedImportantIcon As Image
    Private CheckedImportantIcon As Image
    Private DisabledImportantIcon As Image

    Private dt As New DataTable()
    Private CurrentDateTime As DateTime = DateTime.Now
    Private IsTaskPropertiesVisible As Boolean = False
    Private Task As String
    Private Done As Boolean

    Private connectionString As String = "Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;"

    '---------------------------------------------------Initialization---------------------------------------------------'
#Region "Initialization"
    Private Sub InitializeMy_day()
        TextBox_AddNewTask.Focus()
        LoadTasksToCheckedListView()
        ShowOrHideTaskProperties()
        Label3.Text = CurrentDateTime.ToString("dddd, MMMM dd")

        LoadCachedImages()
        DisableTaskProperties(True)
    End Sub

    Private Sub My_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMy_day()
    End Sub

    Private Sub LoadCachedImages()
        ' Cache images
        UncheckedImportantIcon = Image.FromFile("C:\Users\Nischal\Downloads\1.png")
        CheckedImportantIcon = Image.FromFile("C:\Users\Nischal\Downloads\2.png")
        DisabledImportantIcon = Image.FromFile("C:\Users\Nischal\Downloads\3.png")
    End Sub

    Private Sub DisableTaskProperties(Disable As Boolean)
        If Disable Then
            TextBox1.Text = Nothing
            Label2.Text = Nothing
            Button1.BackgroundImage = DisabledImportantIcon

            TextBox1.Enabled = False
            Label1.Enabled = False
            Label2.Enabled = False
            Button1.Enabled = False
            CustomButton_21.Enabled = False
            CustomButton_22.Enabled = False
            CustomButton_24.Enabled = False
            Button_DeleteTask.Enabled = False
        Else
            TextBox1.Enabled = True
            Label1.Enabled = True
            Label2.Enabled = True
            Button1.Enabled = True
            CustomButton_21.Enabled = True
            CustomButton_22.Enabled = True
            CustomButton_24.Enabled = True
            Button_DeleteTask.Enabled = True
        End If
    End Sub
#End Region

    '---------------------------------------------------Data Handling---------------------------------------------------'
#Region "Data Handling"
    Private Sub LoadTasksToCheckedListView()
        CheckedListBox_MyDay.SelectedIndex = -1

        Dim query As String = "SELECT * FROM My_Day ORDER BY Task_Index"

        CheckedListBox_MyDay.Items.Clear()
        dt.Clear()

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
                CheckedListBox_MyDay.Items.Add(itemText, isChecked)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub AddNewTaskToTable_My_Day(NewTask As String, TaskDescription As String)
        Dim CurrentDateTime As DateTime = DateTime.Now
        Dim newTaskIndex As Integer

        ' Determine the next available Task_Index
        Dim queryGetMaxIndex As String = "SELECT MAX(Task_Index) FROM My_Day"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(queryGetMaxIndex, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    newTaskIndex = If(result Is DBNull.Value, 0, Convert.ToInt32(result) + 1)
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                    Return
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                    Return
                End Try
            End Using
        End Using

        ' Use String.Empty if TaskDescription is Nothing or empty
        TaskDescription = If(String.IsNullOrEmpty(TaskDescription), String.Empty, TaskDescription)

        ' Insert the new task with the determined Task_Index
        Dim queryInsertTask As String = "INSERT INTO My_Day (Task, Task_Description, Entry_DateTime, Task_Index) VALUES (@Task, @TaskDescription, @Entry_DateTime, @TaskIndex)"

        Using connection As New SqlCeConnection(connectionString)
            Using command As New SqlCeCommand(queryInsertTask, connection)
                command.Parameters.AddWithValue("@Task", NewTask)
                command.Parameters.AddWithValue("@TaskDescription", TaskDescription)
                command.Parameters.AddWithValue("@Entry_DateTime", CurrentDateTime)
                command.Parameters.AddWithValue("@TaskIndex", newTaskIndex)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        ' Optionally notify success
                        ' MessageBox.Show("Task added successfully.")
                    Else
                        MessageBox.Show("No rows were affected. The task might not have been added.")
                    End If
                Catch ex As SqlCeException
                    MessageBox.Show("SQL CE Error: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("Unexpected Error: " & ex.Message)
                End Try
            End Using
        End Using

        ' Reload the data to reflect changes
        LoadTasksToCheckedListView()

        ' Focus on added task after DataTable reload
        If CheckedListBox_MyDay.Items.Count > 0 Then
            CheckedListBox_MyDay.SelectedIndex = CheckedListBox_MyDay.Items.Count - 1
            CheckedListBox_MyDay.Focus()
        End If
    End Sub

    Private Sub HardResetTable_My_Day()
        Dim dropTableQuery As String = "DROP TABLE My_Day"
        Dim createTableQuery As String = "CREATE TABLE My_Day (
                Id INT IDENTITY(1,1) NOT NULL,
                Task_Index INT NOT NULL,
                Task NVARCHAR(255) NULL,
                Task_Description NVARCHAR(4000) NULL,
                Entry_DateTime DATETIME NULL,
                Done BIT NULL DEFAULT 0,
                Important BIT NULL DEFAULT 0,
                CONSTRAINT My_Day_PK PRIMARY KEY (Id));"

        Using connection As New SqlCeConnection(connectionString)
            Try
                connection.Open()

                ' Begin a transaction
                Using transaction = connection.BeginTransaction()
                    ' Drop the table if it exists
                    Using dropCommand As New SqlCeCommand(dropTableQuery, connection, transaction)
                        dropCommand.ExecuteNonQuery()
                    End Using

                    ' Recreate the table
                    Using createCommand As New SqlCeCommand(createTableQuery, connection, transaction)
                        createCommand.ExecuteNonQuery()
                    End Using

                    ' Commit the transaction
                    transaction.Commit()
                End Using

            Catch ex As SqlCeException
                ' Detailed SQL CE exception
                MessageBox.Show("SQL CE Error: " & ex.Message)
            Catch ex As Exception
                ' General exception
                MessageBox.Show("Unexpected Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using

        ' Reload the data to reflect changes
        LoadTasksToCheckedListView()
        DisableTaskProperties(True)
    End Sub


    Private Sub DeleteTaskFromTable_My_Day(TaskIndex As Integer)
        ' The TaskIndex is used to find and delete the task
        Dim countQuery As String = "SELECT COUNT(*) FROM My_Day"
        Dim deleteQuery As String = "DELETE FROM My_Day WHERE Task_Index = @TaskIndex"
        Dim updateQuery As String = "UPDATE My_Day SET Task_Index = Task_Index - 1 WHERE Task_Index > @TaskIndex"

        Using connection As New SqlCeConnection(connectionString)
            Try
                connection.Open()

                ' Begin a transaction
                Using transaction = connection.BeginTransaction()
                    Dim taskCount As Integer

                    ' Check the number of tasks
                    Using countCommand As New SqlCeCommand(countQuery, connection, transaction)
                        taskCount = Convert.ToInt32(countCommand.ExecuteScalar())
                    End Using

                    ' If there's only one task, delete it and skip re-sequencing
                    If taskCount = 1 Then
                        HardResetTable_My_Day()
                        Exit Sub
                    Else
                        ' Delete the task
                        Using deleteCommand As New SqlCeCommand(deleteQuery, connection, transaction)
                            deleteCommand.Parameters.AddWithValue("@TaskIndex", TaskIndex)
                            deleteCommand.ExecuteNonQuery()
                        End Using

                        ' Re-sequence the Task_Index
                        Using updateCommand As New SqlCeCommand(updateQuery, connection, transaction)
                            updateCommand.Parameters.AddWithValue("@TaskIndex", TaskIndex)
                            updateCommand.ExecuteNonQuery()
                        End Using
                    End If

                    ' Commit the transaction
                    transaction.Commit()
                End Using

            Catch ex As SqlCeException
                ' Detailed SQL CE exception
                MessageBox.Show("SQL CE Error: " & ex.Message)
            Catch ex As Exception
                ' General exception
                MessageBox.Show("Unexpected Error: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using
        LoadTasksToCheckedListView()
    End Sub

#End Region

    '---------------------------------------------------Task Properties Handling---------------------------------------------------'
#Region "Task Properties Handling"
    Private Sub DoneCheckChanged(itemIndex As Integer, isChecked As Boolean)
        Dim done As Integer = If(isChecked, 1, 0)

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Done = @Done WHERE Task_Index = @Task_Index"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    ' Use specific type for parameters
                    command.Parameters.Add("@Task_Index", SqlDbType.Int).Value = itemIndex
                    command.Parameters.Add("@Done", SqlDbType.Int).Value = done

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("SQL CE Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Unexpected Error: " & ex.Message)
        End Try
    End Sub


    Private Sub ImportantCheckChanged(itemIndex As Integer, isChecked As Boolean)
        'MsgBox("Item Index: " & itemIndex)
        'MsgBox("IsChecked: " & isChecked)

        Dim Important As Integer = If(isChecked, 1, 0)
        Dim id As Integer = itemIndex + 1 ' DataTable Id starts From 1 not 0 like ListView

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Important = @Important WHERE Task_Index = @Task_Index"

            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@Task_Index", itemIndex)
                    command.Parameters.AddWithValue("@Important", Important)

                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating task status: " & ex.Message)
        End Try

        LoadTasksToCheckedListView()
        ' Retain Focus after DataTable Reload
        If CheckedListBox_MyDay.Items.Count > 0 AndAlso itemIndex >= 0 AndAlso itemIndex < CheckedListBox_MyDay.Items.Count Then
            CheckedListBox_MyDay.SelectedIndex = itemIndex
            CheckedListBox_MyDay.Focus()
        End If
    End Sub
#End Region

    '---------------------------------------------------Event Handlers---------------------------------------------------'
#Region "Event Handlers"
    Private Sub TextBox_AddNewTask_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_AddNewTask.KeyDown
        If e.KeyValue = Keys.Enter Then
            EnterTaskTo_My_Day_ChecklistBox()
        End If
    End Sub

    Private Sub EnterTaskTo_My_Day_ChecklistBox()
        Dim NewMy_DayTask As String = TextBox_AddNewTask.Text
        If NewMy_DayTask Is String.Empty Then
            Exit sub
        End If
        CheckedListBox_MyDay.Items.Add(NewMy_DayTask)
        AddNewTaskToTable_My_Day(NewMy_DayTask, "")
        TextBox_AddNewTask.Clear()
        TextBox_AddNewTask.Focus()
    End Sub

    Private Sub CheckedListBox_MyDay_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox_MyDay.ItemCheck
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
        If CheckedListBox_MyDay.SelectedIndex = -1 Then
            DisableTaskProperties(True)
            TextBox1.Clear()
        Else
            DisableTaskProperties(False)
            TextBox1.Text = CheckedListBox_MyDay.SelectedItem.ToString()
            Label2.Text = GetTaskEntryDateTime()

            If IsTaskImportant() Then
                Button1.BackgroundImage = CheckedImportantIcon
            Else
                Button1.BackgroundImage = UncheckedImportantIcon
            End If
        End If
    End Sub

    Private Function IsTaskImportant() As Boolean
        Dim selectedIndex As Integer = CheckedListBox_MyDay.SelectedIndex
        If selectedIndex < 0 Then
            Return False
        End If

        ' Find the task in the DataTable
        For Each row As DataRow In dt.Rows
            If row("Task_Index") = selectedIndex Then
                ' Check if the task is marked as important
                If Convert.ToInt16(row("Important")) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        ' If no matching task is found
        Return False
    End Function

    Private Function GetTaskEntryDateTime() As String
        Dim TaskId As Integer = CheckedListBox_MyDay.SelectedIndex
        Dim TaskEntryDateTime As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("Task_Index") = TaskId Then
                ' Convert the DateTime to a string in your desired format
                TaskEntryDateTime = Convert.ToDateTime(row("Entry_DateTime")).ToString("yyyy-MM-dd  |  hh:mm tt")
                Exit For
            End If
        Next
        Return TaskEntryDateTime
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsTaskImportant() Then
            ImportantCheckChanged(CheckedListBox_MyDay.SelectedIndex, CheckState.Unchecked)
        Else
            ImportantCheckChanged(CheckedListBox_MyDay.SelectedIndex, CheckState.Checked)
        End If

    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        If IsTaskImportant() Then
            Exit Sub
        End If
        Button1.BackgroundImage = CheckedImportantIcon
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        If IsTaskImportant() Then
            Exit Sub
        End If
        Button1.BackgroundImage = UncheckedImportantIcon
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        DeleteTaskFromTable_My_Day(CheckedListBox_MyDay.SelectedIndex)
        DisableTaskProperties(True)
    End Sub

    Private Sub TextBox_AddNewTask_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox_AddNewTask.MouseClick
        LoadTasksToCheckedListView()
        DisableTaskProperties(True)
    End Sub
#End Region
End Class
