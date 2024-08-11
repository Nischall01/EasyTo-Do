Imports System.Data.SqlServerCe

Public Class Planned_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load 
    Private Sub Planned_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToPlanned()
    End Sub

#End Region

#Region "Data Handling"

    ' Load planned tasks into the CheckedListBox.
    Public Sub LoadTasksToPlanned()
        dt.Clear()
        'Dim query As String = "SELECT * FROM Tasks WHERE DueDate IS NOT NULL ORDER BY DueDate;"
        Dim query As String = "SELECT * FROM Tasks WHERE Section = 'Planned' ORDER BY DueDate;"

        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
            dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}

            Planned_CheckedListBox.Items.Clear()
            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
                Planned_CheckedListBox.Items.Add(item, item.IsDone)
            Next
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        LoseListItemFocus()
        'DisableTaskProperties(True)
    End Sub

    ' Add a new Task Event Handler
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim newTask As String = AddNewTask_TextBox.Text
            If String.IsNullOrWhiteSpace(newTask) Then Exit Sub

            Dim NewTaskId As Integer = Task.AddNewTasks.Planned(newTask)

            ' Prompt to add due date
            Dim DueDate_DialogInstance As New DueDate_Dialog With {.DueDate_SelectedTaskID = NewTaskId}
            DueDate_DialogInstance.ShowDialog()
            DueDate_DialogInstance.BringToFront()
            DueDate_DialogInstance.Dispose()

            For i As Integer = 0 To Planned_CheckedListBox.Items.Count - 1
                If Planned_CheckedListBox.Items(i).ID = NewTaskId Then
                    Planned_CheckedListBox.SelectedIndex = i
                    Exit For
                End If
            Next

            AddNewTask_TextBox.Clear()
        End If
    End Sub

    ' CheckedListBox's selected index change event handler
    Private Sub Planned_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Planned_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Planned_CheckedListBox.SelectedIndex
        SelectedTaskItem = Planned_CheckedListBox.SelectedItem

        If Planned_CheckedListBox.SelectedIndex = -1 Then
        Else
            ' Change important icon with respect to selected task
            If IsTaskImportant() Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If
        End If
    End Sub

    ' Task delete event handlers {
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        DeleteTaskInvoker()
    End Sub

    Private Sub Planned_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Planned_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete Then
            If Planned_CheckedListBox.SelectedIndex <> -1 Then
                DeleteTaskInvoker()
            End If
        End If
    End Sub
    ' }

    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub Planned_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Planned_CheckedListBox.ItemCheck
        If Not IsNothing(SelectedTaskItem) Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID, "Planned")
        Else
            Exit Sub
        End If
    End Sub

    ' Button Click event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Planned_CheckedListBox.Items.Count > 0 Then
            If IsTaskImportant() Then
                Task.ImportantCheckChanged(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                Task.ImportantCheckChanged(CheckState.Checked, SelectedTaskItem.ID)
            End If
        Else
            LoseListItemFocus()
        End If
    End Sub

    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties("Hide")
    End Sub

    Private Sub Planned_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Planned_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties()
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If IsTaskImportant() Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If IsTaskImportant() Then
            Exit Sub
        End If
        Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
    End Sub

#End Region

#Region "Helper Methods"

    'Task DeleteTask method invoker
    Private Sub DeleteTaskInvoker()
        If SelectedTaskItem IsNot Nothing AndAlso SelectedTaskItem.ID > 0 Then
            Task.DeleteTask(SelectedTaskItem.ID)

            If Planned_CheckedListBox.Items.Count > 0 Then
                Planned_CheckedListBox.SelectedIndex = Math.Max(0, SelectedTaskIndex - 1)
            Else
                Planned_CheckedListBox_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Function IsTaskImportant() As Boolean
        Try
            If SelectedTaskItem.ID <= 0 Then
                Return False
            End If

            ' Find the task in the DataTable
            Dim foundRow As DataRow = dt.Rows.Find(SelectedTaskItem.ID)
            If foundRow IsNot Nothing Then
                Return CBool(foundRow("IsImportant"))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Private Sub ShowOrHideTaskProperties(Optional Force As String = "Show")
        If Force = "Show" Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 75%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 25%
            IsTaskPropertiesVisible = False
            Exit Sub
        End If

        If IsTaskPropertiesVisible Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 75%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 25%
            IsTaskPropertiesVisible = False
        Else
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 100%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 0%
            IsTaskPropertiesVisible = True
        End If
    End Sub

    Private Sub LoseListItemFocus()
        Planned_CheckedListBox.SelectedIndex = -1
        SelectedTaskIndex = Nothing
        SelectedTaskItem = Nothing
    End Sub

#End Region
End Class