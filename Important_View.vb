﻿Imports System.Data.SqlServerCe

Public Class Important_View
    Private connectionString As String = My.Settings.ConnectionString
    Private dt As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Form on load : Initializes the Repeated tasks view
    Private Sub Important_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTasksToImportantView()

        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

#End Region

#Region "Data Handling"

    ' Load important tasks onto the CheckedListBox.
    Public Sub LoadTasksToImportantView()
        dt.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE IsImportant = 1 ORDER BY EntryDateTime;"

        Try
            Using connection As New SqlCeConnection(connectionString)
                connection.Open()
                Using transaction = connection.BeginTransaction
                    Using command As New SqlCeCommand(query, connection)
                        Using adapter As New SqlCeDataAdapter(command)
                            adapter.Fill(dt)
                        End Using
                    End Using
                    transaction.Commit()
                End Using
            End Using
            dt.PrimaryKey = New DataColumn() {dt.Columns("TaskID")}
            Important_CheckedListBox.Items.Clear()

            For Each row As DataRow In dt.Rows
                Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
                Important_CheckedListBox.Items.Add(item, item.IsDone)
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

    ' KeyDown event to add a new task
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddNewImportantTask()
        End If
    End Sub

    ' CheckedListBox's selected index change event handler
    Private Sub Important_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Important_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Important_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Important_CheckedListBox.SelectedItem
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        Else
        End If
    End Sub

    ' Task delete event handlers {
    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Important_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub

    Private Sub Important_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Important_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Important_CheckedListBox.SelectedIndex <> -1 Then
            DeleteSelectedTask()
        End If
    End Sub
    ' }

    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub Important_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Important_CheckedListBox.ItemCheck
        If Views._isUiUpdating Then
            Exit Sub
        End If

        'MsgBox("ItemCheck Triggered")
        If SelectedTaskItem IsNot Nothing Then
            Task.DoneCheckChanged(e.NewValue = CheckState.Checked, SelectedTaskItem.ID, "Important")
        End If
        Important_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    Private Sub Button_CloseTaskProperties_Click(sender As Object, e As EventArgs) Handles Button_CloseTaskProperties.Click
        ShowOrHideTaskProperties(TaskPropertiesVisibility.Hide)
    End Sub

    Private Sub Important_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Important_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHideTaskProperties(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    ' Button Click event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Important_CheckedListBox.Items.Count > 0 AndAlso SelectedTaskItem IsNot Nothing Then

            Task.ImportantCheckChanged(CheckState.Unchecked, SelectedTaskItem.ID)
            Important_CheckedListBox.SelectedIndex = SelectedTaskIndex - 1

            If Important_CheckedListBox.Items.Count = 0 Then
                SelectedTaskItem = Nothing
            End If
        Else
            LoseListItemFocus()
        End If
    End Sub

    Private Sub MyDay_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        LoseListItemFocus()
        'MsgBox("Left I")
        'MsgBox("I SelectedItemIndex = " & Important_CheckedListBox.SelectedIndex)
    End Sub

#End Region

#Region "Helper Methods"

    ' Task.AddNewTasks.Important method invoker
    Private Sub AddNewImportantTask()
        Dim newTask As String = AddNewTask_TextBox.Text
        If String.IsNullOrWhiteSpace(newTask) Then Exit Sub ' Ensure the task is not empty. If empty -> exit method

        Dim newTaskId As Integer = Task.AddNewTasks.Important(newTask) ' Add the new task to the database and get its ID

        ' Select the newly added task
        For i As Integer = 0 To Important_CheckedListBox.Items.Count - 1
            If Important_CheckedListBox.Items(i).ID = newTaskId Then
                Important_CheckedListBox.SelectedIndex = i
                Exit For
            End If
        Next

        AddNewTask_TextBox.Clear() ' Clear the input field
    End Sub

    ' Task.DeleteTask method invoker
    Private Sub DeleteSelectedTask()
        If SelectedTaskItem Is Nothing Then
            MessageBox.Show("No task is selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Task.DeleteTask(SelectedTaskItem.ID)

            ' Adjust the selected task index after deletion
            If Important_CheckedListBox.Items.Count > 0 Then
                If SelectedTaskIndex >= Important_CheckedListBox.Items.Count Then
                    SelectedTaskIndex = Important_CheckedListBox.Items.Count - 1
                End If
                Important_CheckedListBox.SelectedIndex = SelectedTaskIndex
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Show or hide the task properties panel
    Private Sub ShowOrHideTaskProperties(action As Views.TaskPropertiesVisibility)
        Select Case action
            Case TaskPropertiesVisibility.Show
                IsTaskPropertiesVisible = True
            Case TaskPropertiesVisibility.Hide
                IsTaskPropertiesVisible = False
            Case TaskPropertiesVisibility.Toggle
                IsTaskPropertiesVisible = Not IsTaskPropertiesVisible
        End Select

        If IsTaskPropertiesVisible Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 75%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 25%
        Else
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 100%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 0%
        End If
    End Sub

    Private Sub LoseListItemFocus()
        Important_CheckedListBox.SelectedItem = Nothing
        Important_CheckedListBox.SelectedIndex = -1
    End Sub

#End Region

End Class