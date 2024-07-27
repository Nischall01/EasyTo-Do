Imports System.Data.SqlServerCe

Public Class My_Day

    ' Image cache variables
    Private UncheckedImportantIcon As Image
    Private CheckedImportantIcon As Image

    Private dt As New DataTable()
    Private CurrentDateTime As DateTime = DateTime.Now
    Private IsTaskPropertiesVisible As Boolean = False
    Private Task As String
    Private Done As Boolean

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
    End Sub

    Private Sub DisableTaskProperties(Confirmation As Boolean)
        If Confirmation Then
            TextBox1.Enabled = False
            Label1.Enabled = False
            Label2.Enabled = False
            Button1.Enabled = False
            CustomButton_21.Enabled = False
            CustomButton_22.Enabled = False
            CustomButton_24.Enabled = False
            Button3.Enabled = False
        Else
            Button1.Enabled = True
            Label1.Enabled = True
            Label2.Enabled = True
            CustomButton_21.Enabled = True
            CustomButton_22.Enabled = True
            CustomButton_24.Enabled = True
            Button3.Enabled = True
        End If
    End Sub
#End Region

    '---------------------------------------------------Data Handling---------------------------------------------------'
#Region "Data Handling"
    Private Sub ReloadDataTable()
        ' Clear the DataTable
        dt.Clear()
        ' Reload data from the database
        LoadTasksToCheckedListView()
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
                Dim isChecked As Boolean = row("Done")
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
        Dim query As String = "INSERT INTO My_Day (Task, Entry_DateTime) VALUES (@NewTask, @Entry_DateTime)"

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
        ReloadDataTable()
        ' Focus on added task after DataTable Reload
        CheckedListBox_MyDay.SelectedIndex = CheckedListBox_MyDay.Items.Count - 1
        CheckedListBox_MyDay.Focus()
    End Sub
#End Region

    '---------------------------------------------------Task Properties Handling---------------------------------------------------'
#Region "Task Properties Handling"
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

    Private Sub ImportantCheckChanged(itemIndex As Integer, isChecked As Boolean)
        'MsgBox("Item Index: " & itemIndex)
        'MsgBox("IsChecked: " & isChecked)

        Dim Important As Integer = If(isChecked, 1, 0)
        Dim id As Integer = itemIndex + 1 ' DataTable Id starts From 1 not 0 like ListView

        Try
            ' Update the database with the new 'Done' value
            Dim query As String = "UPDATE My_Day SET Important = @Important WHERE Id = @Id"

            Using connection As New SqlCeConnection("Data Source=D:\_Programs\_Visual_Studio_Workspace\EasyTo-do\To_Do.sdf;Persist Security Info=False;")
                Using command As New SqlCeCommand(query, connection)
                    command.Parameters.AddWithValue("@Id", id)
                    command.Parameters.AddWithValue("@Important", Important)

                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating task status: " & ex.Message)
        End Try

        ReloadDataTable()
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

        CheckedListBox_MyDay.Items.Add(NewMy_DayTask)
        AddNewTaskToTable_My_Day(NewMy_DayTask)
        TextBox_AddNewTask.Clear()
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
        If CheckedListBox_MyDay.SelectedIndex <> -1 Then
            TextBox1.Text = CheckedListBox_MyDay.SelectedItem.ToString()
            Label2.Text = GetTaskEntryDateTime(CheckedListBox_MyDay.SelectedIndex)

            If IsTaskImportant() Then
                Button1.BackgroundImage = CheckedImportantIcon
            Else
                Button1.BackgroundImage = UncheckedImportantIcon
            End If
        Else
            TextBox1.Clear()
        End If
    End Sub

    Private Function IsTaskImportant() As Boolean
        Dim selectedIndex As Integer = CheckedListBox_MyDay.SelectedIndex
        If selectedIndex < 0 Then
            Return False
        End If

        ' Retrieve the task ID from the DataTable
        Dim taskId As Integer = selectedIndex + 1 ' Assuming task IDs are 1-based

        ' Find the task in the DataTable
        For Each row As DataRow In dt.Rows
            If row("Id") = taskId Then
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

    Private Function GetTaskEntryDateTime(TaskIndex As Integer) As String
        Dim TaskId As Integer = TaskIndex + 1
        Dim TaskEntryDateTime As String = String.Empty

        For Each row As DataRow In dt.Rows
            If row("Id") = TaskId Then
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
#End Region
End Class
