Public Class Planned_View
    Private connectionString As String = My.Settings.ConnectionString
    Private PlannedDT As New DataTable()
    Private PlannedDT_TaskTitleOnly As New DataTable()

    Private SelectedTaskIndex As Integer = -1
    Private SelectedTaskItem As TaskItem

    Private IsTaskPropertiesVisible As Boolean = True

#Region "On Load"

    ' Initializes the form components and enables key preview for handling keyboard events at the form level. '
    Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub

    ' Form on load : Initializes the Repeated tasks view. '
    Private Sub Planned_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializePlanned()
    End Sub

    ' Initializes the Repeated tasks view. '
    Private Sub InitializePlanned()
        Select Case My.Settings.TaskPropertiesSidebarOnStart ' Sets the Task Properties initial sidebar state based on user setting
            Case "Expanded"
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            Case "Collapsed"
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select

        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

#End Region

#Region "Data Loading Actions"

    ' Load tasks onto the DataTables
    Private Sub LoadTasksToDataTables_Tasks()
        PlannedDT.Clear()
        PlannedDT_TaskTitleOnly.Clear()
        Dim query As String = "SELECT * FROM Tasks WHERE Section = 'Planned' ORDER BY DueDate;"
        Dim queryTitleOnly As String = "SELECT TaskID, Task FROM Tasks WHERE Section = 'Planned' ORDER BY DueDate;"

        Using connection As New SqlCeConnection(connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(PlannedDT)
                End Using
            End Using
            Using command As New SqlCeCommand(queryTitleOnly, connection)
                command.Parameters.AddWithValue("@Today", DateTime.Today)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(PlannedDT_TaskTitleOnly)
                End Using
            End Using
        End Using
        PlannedDT.PrimaryKey = New DataColumn() {PlannedDT.Columns("TaskID")}
        PlannedDT_TaskTitleOnly.PrimaryKey = New DataColumn() {PlannedDT_TaskTitleOnly.Columns("TaskID")}
    End Sub

    ' Load planned tasks into the CheckedListBox.
    Public Sub LoadTasksToPlannedView()
        LoadTasksToDataTables_Tasks()
        Planned_CheckedListBox.Items.Clear()

        For Each row As DataRow In PlannedDT.Rows
            If Not row.IsNull("ReminderDateTime") AndAlso TypeOf row("ReminderDateTime") Is DateTime Then
                Dim RemindedTask As String = row("Task")
                Dim reminderDateTime As DateTime = row.Field(Of DateTime)("ReminderDateTime")
                row("Task") = reminderDateTime.ToString("(hh:mmtt)").ToLower() + "  " + RemindedTask
            End If

            If Not row.IsNull("DueDate") AndAlso TypeOf row("DueDate") Is DateTime Then
                Dim PlannedTask As String = row("Task")
                Dim reminderDueDate As DateTime = row.Field(Of DateTime)("DueDate")
                row("Task") = reminderDueDate.ToString("(dd/MM)").ToLower() + "  " + PlannedTask
            End If

            If row("IsImportant") Then
                Dim ImportantTask As String = "!" + "  " + row("Task")
                row("Task") = ImportantTask
            End If

            Dim item As New TaskItem(row("Task"), row("TaskID"), row("IsDone") <> 0)
            Planned_CheckedListBox.Items.Add(item, item.IsDone)
        Next
    End Sub

#End Region

#Region "Task Properties Sidebar Management"

    ' Enum defining the different actions for managing the task properties sidebar.
    Public Enum TaskPropertiesSidebarAction
        DisableOnly
        HideOnly
        DisableAndHide
    End Enum

    ' This method allows external components to disable or hide the task properties sidebar.
    Public Sub DisableAndHide_TaskPropertiesSidebar(Optional action As TaskPropertiesSidebarAction = TaskPropertiesSidebarAction.DisableAndHide)
        Select Case action
            Case TaskPropertiesSidebarAction.DisableOnly
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
            Case TaskPropertiesSidebarAction.HideOnly
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
            Case TaskPropertiesSidebarAction.DisableAndHide
                EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Hide)
        End Select
    End Sub

    Private Sub EnableOrDisable_TaskPropertiesSidebar(State As TaskPropertiesState)
        Select Case State
            Case TaskPropertiesState.Disable
                TaskTitle_TextBox.Text = Nothing
                Label_TaskEntryDateTime.Text = Nothing
                Important_Button.BackgroundImage = ImageCache.DisabledImportantIcon

                If My.Settings.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(30, 30, 30)
                    TaskDescription_RichTextBox.Hide()
                End If
                TaskTitle_TextBox.Enabled = False
                TaskDescription_RichTextBox.Text = Nothing
                TaskDescription_RichTextBox.Enabled = False

                Label_ADT.Enabled = False
                Label_TaskEntryDateTime.Enabled = False
                Important_Button.Enabled = False

                CustomButton_AddReminder.Enabled = False
                CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton

                CustomButton_Repeat.Enabled = False
                CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton

                Button_DeleteTask.Enabled = False
            Case TaskPropertiesState.Enable
                If My.Settings.ColorScheme = "Dark" Then
                    TaskTitle_TextBox.BackColor = Color.FromArgb(40, 40, 40)
                    TaskDescription_RichTextBox.Show()
                End If
                TaskTitle_TextBox.Enabled = True
                TaskDescription_RichTextBox.Enabled = True
                Label_ADT.Enabled = True
                Label_TaskEntryDateTime.Enabled = True
                Important_Button.Enabled = True
                CustomButton_Repeat.Enabled = True
                CustomButton_AddReminder.Enabled = True
                Button_DeleteTask.Enabled = True
        End Select
    End Sub

    Private Sub ShowOrHide_TaskPropertiesSidebar(action As TaskPropertiesVisibility)
        Select Case action
            Case TaskPropertiesVisibility.Show
                IsTaskPropertiesVisible = True
            Case TaskPropertiesVisibility.Hide
                IsTaskPropertiesVisible = False
            Case TaskPropertiesVisibility.Toggle
                IsTaskPropertiesVisible = Not IsTaskPropertiesVisible
        End Select
        UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, Me.MainTlp)
    End Sub

#End Region

#Region "Event Handlers"

    ' Event handler triggered when the user selects a task from the Planned_CheckedListBox.
    ' It updates the UI with the details of the selected task, including the task title, entry date/time, importance status, 
    ' description, reminder time, and repeat frequency. If no task is selected, the task properties are disabled and cleared.
    Private Sub Planned_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Planned_CheckedListBox.SelectedIndexChanged
        SelectedTaskIndex = Planned_CheckedListBox.SelectedIndex

        If SelectedTaskIndex <> -1 Then
            SelectedTaskItem = Planned_CheckedListBox.SelectedItem

            EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Enable)
            TaskTitle_TextBox.Text = TaskManager.GetTaskString(SelectedTaskItem.ID, PlannedDT_TaskTitleOnly)

            Label_TaskEntryDateTime.Text = TaskManager.GetTaskEntryDateTimeString(SelectedTaskItem.ID, PlannedDT)

            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, PlannedDT) Then
                Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
            Else
                Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
            End If

            If TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, PlannedDT) <> String.Empty Then
                If My.Settings.ColorScheme = "Dark" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Pink
                ElseIf My.Settings.ColorScheme = "Light" Then
                    TaskDescription_RichTextBox.ForeColor = Color.Black
                End If
                TaskDescription_RichTextBox.Text = TaskManager.GetTaskDescriptionString(SelectedTaskItem.ID, PlannedDT)
            Else
                TaskDescription_RichTextBox.ForeColor = Color.Gray
                TaskDescription_RichTextBox.Text = TextPlaceholders.Description
            End If

            Dim ReminderTime As String = TaskManager.GetReminderString(SelectedTaskItem.ID, PlannedDT)
            If ReminderTime <> String.Empty Then
                CustomButton_AddReminder.ButtonText = ReminderTime
            Else
                CustomButton_AddReminder.ButtonText = TextPlaceholders.AddReminderButton
            End If

            Dim RepeatFrequency As String = TaskManager.GetRepeatString(SelectedTaskItem.ID, PlannedDT)
            If RepeatFrequency <> String.Empty Then
                CustomButton_Repeat.ButtonText = RepeatFrequency
            Else
                CustomButton_Repeat.ButtonText = TextPlaceholders.RepeatButton
            End If
        End If
    End Sub

    Private Sub AddNewTask_TextBox_Enter(sender As Object, e As EventArgs) Handles AddNewTask_TextBox.Enter
        UiUtils.TaskSelection_Clear(Me.Planned_CheckedListBox)
        EnableOrDisable_TaskPropertiesSidebar(TaskPropertiesState.Disable)
    End Sub

    ' Add a new Task Event Handler
    Private Sub AddNewTask_TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddNewTask_TextBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrWhiteSpace(AddNewTask_TextBox.Text) Then Exit Sub
            Dim NewTaskId As Integer = TaskManager.AddNewTask(Me.AddNewTask_TextBox, Me.Planned_CheckedListBox, ViewName.Planned)
            TaskManager.ShowDueDateDialog(NewTaskId, SelectedTaskIndex, Me.Planned_CheckedListBox, ViewName.Planned)
            If Planned_CheckedListBox.Items.Count = 1 Then
                ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Show)
            End If
        End If
    End Sub

    Private Sub Button_DeleteTask_Click(sender As Object, e As EventArgs) Handles Button_DeleteTask.Click
        If Planned_CheckedListBox.SelectedIndex = -1 Or Planned_CheckedListBox.Items.Count = 0 Or SelectedTaskItem Is Nothing Then
            Exit Sub
        End If
        TaskManager.DeleteTask(SelectedTaskItem.ID, Me.Planned_CheckedListBox, SelectedTaskIndex, ViewName.Planned)
        If Planned_CheckedListBox.Items.Count = 0 Then
            Me.ActiveControl = AddNewTask_TextBox
        End If
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Delete Then
            Button_DeleteTask.PerformClick()
        End If
    End Sub

    Private Sub Planned_CheckedListBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Planned_CheckedListBox.KeyDown
        If e.KeyValue = Keys.Delete AndAlso Planned_CheckedListBox.SelectedIndex <> -1 Then

        End If
    End Sub
    ' }

    ' Item Check event to change the 'IsDone' status of the selected task
    Private Sub Planned_CheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles Planned_CheckedListBox.ItemCheck
        If ViewsManager.isUiUpdating Then
            Exit Sub
        End If

        If SelectedTaskItem IsNot Nothing Then
            TaskManager.UpdateStatus(e.NewValue = CheckState.Checked, SelectedTaskItem.ID)
        End If
        Planned_CheckedListBox.SelectedIndex = SelectedTaskIndex
    End Sub

    ' Button Click event to change the 'IsImportant' status of the selected task
    Private Sub Important_Button_Click(sender As Object, e As EventArgs) Handles Important_Button.Click
        If Planned_CheckedListBox.SelectedIndex <> -1 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, PlannedDT) Then
                TaskManager.UpdateImportance(CheckState.Unchecked, SelectedTaskItem.ID)
            Else
                TaskManager.UpdateImportance(CheckState.Checked, SelectedTaskItem.ID)
            End If
            Planned_CheckedListBox.SelectedIndex = SelectedTaskIndex
        Else
            UiUtils.TaskSelection_Clear(Me.Planned_CheckedListBox)
        End If
    End Sub

    Private Sub Planned_CheckedListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Planned_CheckedListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            ShowOrHide_TaskPropertiesSidebar(TaskPropertiesVisibility.Toggle)
        End If
    End Sub

    Private Sub Important_Button_MouseEnter(sender As Object, e As EventArgs) Handles Important_Button.MouseEnter
        If Planned_CheckedListBox.SelectedIndex <> -1 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, PlannedDT) Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.CheckedImportantIcon
        End If
    End Sub

    Private Sub Important_Button_MouseLeave(sender As Object, e As EventArgs) Handles Important_Button.MouseLeave
        If Planned_CheckedListBox.SelectedIndex <> -1 Then
            If TaskManager.IsTaskImportant(SelectedTaskItem.ID, PlannedDT) Then
                Exit Sub
            End If
            Important_Button.BackgroundImage = ImageCache.UncheckedImportantIcon
        End If
    End Sub

    Private Sub Planned_View_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        UiUtils.TaskSelection_Clear(Me.Planned_CheckedListBox)
        'MsgBox("Left Planned view")
        'MsgBox("SelectedItemIndex = " & Planned_CheckedListBox.SelectedIndex) '
    End Sub

#End Region
End Class