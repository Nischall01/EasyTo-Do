Imports System.Drawing.Text
Imports System.IO
Imports System.Media
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Design
Imports Microsoft.Win32

Public Class MainWindow

    'Custom titlebar variables

    Public isMaximized As Boolean = False
    Private CurrentNormalWindowSize As Size
    Private LastSavedWindowSize As Size
    Private workingArea As Rectangle = Screen.GetWorkingArea(Me)

    Private isDragging As Boolean = False
    Private startX As Integer
    Private startY As Integer

    ' Reminder variables

    Private ReminderDictionary As New Dictionary(Of Integer, DateTime)
    Private ReminderDT As New DataTable

    ' Constants

    Private Const CollapsedSidebarWidth As Integer = 55
    Private Const ExpandedSidebarWidth As Integer = 200
    Private Const MaxSidebarWidth As Integer = 333

    '  Vars for sidebar resizing logic

    Private lastsidebarstate As SidebarState
    Private WindowResized As Boolean = False

    ' Fields

    Private PfpLastEventTime As DateTime

    Public Shared IsSidebarExpanded As Boolean
    Private IsTaskPropertiesVisible As Boolean

    Public PrivateFonts As New PrivateFontCollection()

    Private ReadOnly DebounceDelay As TimeSpan = TimeSpan.FromMilliseconds(50)

    ' Enums

    Private Enum SidebarState
        Collapsed
        Expanded
        Maximized
    End Enum

    Public Enum TaskPropertiesSidebarAction
        DisableOnly
        HideOnly
        DisableAndHide
    End Enum

    Public Enum TaskPropertiesVisibility
        Toggle
        Show
        Hide
    End Enum

    ' Forms

    Public MyDayInstance As New MyDay_View()
    Public RepeatedInstance As New Repeated_View()
    Public ImportantInstance As New Important_View()
    Public PlannedInstance As New Planned_View()
    Public TasksInstance As New Tasks_View()
    Public SettingsInstance As New Settings_Dialog()

    Public Shared isUiUpdating As Boolean = False

    ' Dictionary to map view names to their corresponding task-loading actions
    Private ReadOnly TaskPropertiesVisibilityActions As New Dictionary(Of String, Action) From {
    {ViewName.MyDay, Sub() UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, MyDayInstance.MainTlp)},
    {ViewName.Repeated, Sub() UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, RepeatedInstance.MainTlp)},
    {ViewName.Important, Sub() UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, ImportantInstance.MainTlp)},
    {ViewName.Planned, Sub() UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, PlannedInstance.MainTlp)},
    {ViewName.Tasks, Sub() UiUtils.ToggleTaskProperties(IsTaskPropertiesVisible, TasksInstance.MainTlp)}
}

    Public Sub ShowOrHide_TaskPropertiesSidebar(action As TaskPropertiesVisibility)
        Dim activeViewName As ViewName = ViewsManager.GetActiveViewName()

        ' Adjust task properties visibility based on action
        Select Case action
            Case TaskPropertiesVisibility.Show
                IsTaskPropertiesVisible = True
            Case TaskPropertiesVisibility.Hide
                IsTaskPropertiesVisible = False
            Case TaskPropertiesVisibility.Toggle
                IsTaskPropertiesVisible = Not IsTaskPropertiesVisible
        End Select

        ' Refresh the active view TaskPropertiesSidebar first
        If TaskPropertiesVisibilityActions.ContainsKey(activeViewName) Then
            Try
                TaskPropertiesVisibilityActions(activeViewName).Invoke()
            Catch ex As Exception
                MessageBox.Show("An error occurred while refreshing the active view TaskPropertiesSidebar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Refresh other views TaskPropertiesSidebar
        For Each viewName In TaskPropertiesVisibilityActions.Keys
            If viewName <> activeViewName Then
                Try
                    TaskPropertiesVisibilityActions(viewName).Invoke()
                Catch ex As Exception
                    MessageBox.Show("An error occurred while refreshing TaskPropertiesSidebar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next
    End Sub

    Private Sub LoadCustomFont()
        ' Get the font stream from embedded resources
        Dim fontStream As Stream = Me.GetType().Assembly.GetManifestResourceStream("EasyTo_Do.Poppins-Regular.ttf")

        If fontStream Is Nothing Then
            MessageBox.Show("Font resource not found.")
            Return
        End If

        ' Read the font data
        Dim fontData As Byte() = New Byte(fontStream.Length - 1) {}
        fontStream.Read(fontData, 0, CInt(fontStream.Length))

        ' Allocate memory for the font and copy the data
        Dim fontPtr As IntPtr = Marshal.AllocCoTaskMem(fontData.Length)
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length)

        ' Add the font to the PrivateFontCollection
        PrivateFonts.AddMemoryFont(fontPtr, fontData.Length)

        ' Free the memory after use
        Marshal.FreeCoTaskMem(fontPtr)
    End Sub

#Region "Constructor and On Load"

    Public Sub New()
        InitializeComponent()
        LoadCustomFont()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        Dim minWidth As Integer = Screen.PrimaryScreen.Bounds.Width / 2
        Me.MinimumSize = New Size(minWidth, 575)
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureDatabaseExists("To_Do.sdf")
        InitializeApp()
        If My.Settings.OnStartupCheckForUpdate Then
            CheckForUpdate(1)
        End If
        InitializeReminder()
        InitializeTrayIconContextMenu()
    End Sub

    Private Sub InitializeTrayIconContextMenu()
        Dim contextMenu As New ContextMenuStrip()
        Dim exitItem As New ToolStripMenuItem("Exit")

        AddHandler exitItem.Click, AddressOf ExitItem_Click
        contextMenu.Items.Add(exitItem)

        ReminderNotification.ContextMenuStrip = contextMenu
    End Sub


    Private Sub ExitItem_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Hide the window if launched with "silent" argument (silent start for tray mode)
        If Environment.GetCommandLineArgs().Contains("--silent") Then
            Me.Visible = False
        End If
    End Sub

#End Region

#Region "Update"

    Public Async Sub CheckForUpdate(PromptType As Integer)
        Dim owner As String = "Nischall01"
        Dim repo As String = "EasyTo-Do"

        Try
            'Check If there Is an internet connection
            If Not GitHubReleaseChecker.IsInternetAvailable() Then
                If PromptType = 1 Then
                    Exit Sub
                ElseIf PromptType = 0 Then
                    MessageBox.Show("Error checking for updates due to an internet connection issue." & vbCrLf & vbCrLf &
                                "Ensure you're connected to the internet. If the issue persists, disable 'Check for updates on startup' in the 'Misc.' tab and report the issue on GitHub.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            ' Fetch the latest release and its tag asynchronously
            Dim latestRelease As String = Await GitHubReleaseChecker.GetLatestReleaseAsync(owner, repo)
            Dim latestRelease_Tag As String = Await GitHubReleaseChecker.GetLatestRelease_TagAsync(owner, repo)

            If String.Compare(latestRelease_Tag, "Could not get the latest release.", StringComparison.OrdinalIgnoreCase) = 0 Then
                MessageBox.Show("An error occurred while checking for updates." & vbCrLf & vbCrLf &
                            "If this error persists, disable the 'On Startup: Check for update' setting under the 'Misc.' tab and open an issue on my GitHub repository.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf String.Compare(latestRelease_Tag, "No internet connection.", StringComparison.OrdinalIgnoreCase) = 0 Then
                MessageBox.Show("Error checking for updates due to an internet connection issue." & vbCrLf & vbCrLf &
                                "Ensure you're connected to the internet. If the issue persists, disable 'Check for updates on startup' in the 'Misc.' tab and report the issue on GitHub.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Check if the latest release tag is different from the current version
            If String.Compare(latestRelease_Tag, My.Settings.Version.ToString, StringComparison.OrdinalIgnoreCase) <> 0 Then
                Dim result As DialogResult = MessageBox.Show(
                $"New update available: {latestRelease}" & Environment.NewLine & vbCrLf & "Would you like to update?",
                "Update Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            )
                ' Handle the user's response
                If result = DialogResult.Yes Then
                    Process.Start("https://github.com/Nischall01/EasyTo-Do/releases/latest")
                End If
            Else
                If PromptType = 1 Then
                    Exit Sub
                End If
                MessageBox.Show("Your application is up to date.", "No Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking for updates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Reminder"

    Private Sub InitializeReminder()
        ReminderTimer.Interval = 1000 ' Interval set to 1 seconds
        ReminderTimer.Start() ' Start the Timer

        ReminderNotification.Text = "EasyTo_do"
        ReminderNotification.Icon = My.Resources.EasyToDo_Icon
        ReminderNotification.Visible = True
    End Sub

    Private Sub LoadTasksToReminderDT()
        ReminderDT.Clear()

        Dim query As String = "SELECT TaskID, Task, Description,IsImportant, ReminderDateTime FROM Tasks WHERE ReminderDateTime IS NOT NULL AND IsDone = 0;"

        Using connection As New SqlCeConnection(SettingsCache.connectionString)
            connection.Open()
            Using command As New SqlCeCommand(query, connection)
                Using adapter As New SqlCeDataAdapter(command)
                    adapter.Fill(ReminderDT)
                End Using
            End Using
        End Using

        ReminderDT.PrimaryKey = New DataColumn() {ReminderDT.Columns("TaskID")}
    End Sub

    Public Sub CacheTasksWithReminder()
        LoadTasksToReminderDT()

        ' Create a temporary set to track existing TaskIDs
        Dim currentTaskIDs As New HashSet(Of Integer)()

        ' Update the dictionary with new or updated tasks
        For Each row As DataRow In ReminderDT.Rows
            Dim TaskID As Integer = row("TaskID")
            Dim TaskReminder As DateTime = row("ReminderDateTime")

            ' Add or update the task in the dictionary
            If ReminderDictionary.ContainsKey(TaskID) Then
                ReminderDictionary(TaskID) = TaskReminder
            Else
                ReminderDictionary.Add(TaskID, TaskReminder)
            End If

            ' Track the TaskID
            currentTaskIDs.Add(TaskID)
        Next

        ' Remove tasks from the dictionary that are no longer in ReminderDT
        Dim tasksToRemove As List(Of Integer) = ReminderDictionary.Keys.Except(currentTaskIDs).ToList()

        For Each taskID As Integer In tasksToRemove
            ReminderDictionary.Remove(taskID)
        Next
    End Sub

    Private Sub ReminderTimer_Tick(sender As Object, e As EventArgs) Handles ReminderTimer.Tick
        CheckReminders()
    End Sub

    Private Sub CheckReminders()
        Dim currentDateTime As DateTime = DateTime.Now

        For Each task As KeyValuePair(Of Integer, DateTime) In ReminderDictionary

            Dim taskID As Integer = task.Key
            Dim reminderDateTime As DateTime = task.Value

            Dim currentDateTimeString As String = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss")
            Dim reminderDateTimeString As String = reminderDateTime.ToString("yyyy-MM-dd HH:mm:ss")

            If currentDateTimeString = reminderDateTimeString Then
                Dim foundRow As DataRow = ReminderDT.Rows.Find(taskID)

                If foundRow IsNot Nothing Then
                    Dim TaskTitle As String = foundRow("Task")
                    Dim TaskDescription As String
                    If IsDBNull(foundRow("Description")) Then
                        TaskDescription = " "
                    Else
                        TaskDescription = foundRow("Description")
                    End If

                    If foundRow("IsImportant") = True Then
                        ShowNotification(TaskTitle, True, TaskDescription)
                    Else
                        ShowNotification(TaskTitle, False, TaskDescription)
                    End If
                Else
                    ' Task not found
                    MessageBox.Show("Task not found.")
                End If
            End If
        Next
    End Sub

    Private Sub ShowNotification(title As String, IsImportant As Boolean, Optional Description As String = " ")
        ReminderNotification.BalloonTipTitle = title
        If IsImportant Then
            ReminderNotification.BalloonTipIcon = ToolTipIcon.Warning
            ReminderNotification.BalloonTipText = Description
        Else
            ReminderNotification.BalloonTipIcon = ToolTipIcon.None
            ReminderNotification.BalloonTipText = Description
        End If
        ReminderNotification.ShowBalloonTip(5000) ' Hold for 5 seconds
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles ReminderNotification.BalloonTipClicked
        Me.Show()
        Me.TopMost = True
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.TopMost = False
    End Sub

#End Region

#Region "Database Check"

    Public Sub EnsureDatabaseExists(dbFilePath As String)
        ' Check if the database file exists
        If Not File.Exists(dbFilePath) Then
            ' Create a new database and initialize tables
            CreateDatabase(dbFilePath)
        End If
    End Sub

    Private Sub CreateDatabase(dbFilePath As String)
        Try
            ' Connection string for SQL CE database creation
            Dim connStr As String = $"Data Source={dbFilePath};"

            ' Create the SQL CE engine and initialize the new database
            Using engine As New SqlCeEngine(connStr)
                engine.CreateDatabase()
            End Using

            ' Create tables in the new database
            Using conn As New SqlCeConnection(connStr)
                conn.Open()

                ' SQL command to create the Tasks table
                Dim createTableCmd As New SqlCeCommand("
                CREATE TABLE Tasks (
                    TaskID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                    Task NVARCHAR(256) NOT NULL,
                    Description NVARCHAR(4000) NULL,
                    IsDone BIT NOT NULL DEFAULT 0,
                    IsImportant BIT NOT NULL DEFAULT 0,
                    DueDate DATETIME NULL,
                    Section NVARCHAR(256) NULL,
                    EntryDateTime DATETIME NOT NULL,
                    RepeatedDays NVARCHAR(256) NULL,
                    ReminderDateTime DATETIME NULL
                )", conn)

                ' Execute the command to create the table
                createTableCmd.ExecuteNonQuery()

                conn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error creating database: {ex.Message}")
        End Try
    End Sub

#End Region

#Region "Initialization Methods"

    Private Sub InitializeForms()
        AddFormToPanel(MyDayInstance)
        AddFormToPanel(RepeatedInstance)
        AddFormToPanel(ImportantInstance)
        AddFormToPanel(PlannedInstance)
        AddFormToPanel(TasksInstance)
    End Sub

    Private Sub InitializeApp()
        ' Initialize all forms
        InitializeForms()
        ' Initial state for sidebar is set as expanded
        Select Case My.Settings.SidebarStateOnStart
            Case "Expanded"
                SetSidebarState(SidebarState.Expanded)
            Case "Collapsed"
                SetSidebarState(SidebarState.Collapsed)
        End Select
        'Load the User Profile
        LoadProfile()
        'Load the tasks
        ViewsManager.RefreshTasks()
        ' Initial Form
        ShowForm(MyDayInstance)
        MyDayInstance.ActiveControl = MyDayInstance.AddNewTask_TextBox
        ' Load the Selected Appearance
        LoadSettings()

        If My.Settings.LastSavedWindowSize_Height <> 0 Or My.Settings.LastSavedWindowSize_Width <> 0 Then
            Dim ScreenWidth As Integer = workingArea.Width
            Dim ScreenHeight = workingArea.Height

            If My.Settings.LastSavedWindowSize_Width = ScreenWidth And My.Settings.LastSavedWindowSize_Height = ScreenHeight - 1 Then
                Button2.PerformClick()
                Exit Sub
            End If
            Me.Size = New Size(My.Settings.LastSavedWindowSize_Width, My.Settings.LastSavedWindowSize_Height)
            Me.CenterToScreen()
        End If
    End Sub

#End Region

#Region "Settings"

    Private Sub LoadSettings()
        SetSetting_ColorScheme()
        SetSetting_SidebarState()
        SetSetting_TaskPropertiesSidebarState()
        SetSetting_TimeFormat()
        SetSetting_ProfileVisibility()
        SetSetting_OnDeleteAskForConfirmation()
        SetSetting_Sorting()
        SetSetting_HideCompletedTasks()
        SetSetting_TasksSize()
        SetSetting_TasksFont()
        SetSetting_OnStartupCheckForUpdate()
        SetSetting_OnCloseRunInTheBackground()
        SetSetting_RunOnWindowsStartup()
        SetSetting_PopupOnStartup()
    End Sub

    Private Sub SetSetting_ColorScheme()
        Select Case My.Settings.ColorScheme
            Case "Light"
                SettingsInstance.ColorScheme_Light_RadioBtn.Checked = True
            Case "Dark"
                SettingsInstance.ColorScheme_Dark_RadioBtn.Checked = True
            Case "Custom"
                SettingsInstance.ColorScheme_Custom_RadioBtn.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_SidebarState()
        Select Case My.Settings.SidebarStateOnStart
            Case "Expanded"
                SettingsInstance.RadioButton3.Checked = True
            Case "Collapsed"
                SettingsInstance.RadioButton2.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_TaskPropertiesSidebarState()
        Select Case My.Settings.TaskPropertiesSidebarStateOnStart
            Case "Expanded"
                SettingsInstance.RadioButton4.Checked = True
            Case "Collapsed"
                SettingsInstance.RadioButton1.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_TimeFormat()
        Select Case My.Settings.TimeFormat
            Case "12"
                SettingsInstance.RadioButton6.Checked = True
            Case "24"
                SettingsInstance.RadioButton5.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_ProfileVisibility()
        Select Case My.Settings.IsPfpVisible
            Case True
                SettingsInstance.CheckBox1.Checked = False
            Case False
                SettingsInstance.CheckBox1.Checked = True
        End Select

        Select Case My.Settings.IsUsernameVisible
            Case True
                SettingsInstance.CheckBox2.Checked = False
            Case False
                SettingsInstance.CheckBox2.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_OnDeleteAskForConfirmation()
        Select Case My.Settings.OnDeleteAskForConfirmation
            Case True
                SettingsInstance.RadioButton7.Checked = True
            Case False
                SettingsInstance.RadioButton8.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_Sorting()
        Select Case My.Settings.SortByCompletionStatus
            Case True
                SettingsInstance.RadioButton9.Checked = True
            Case False
                SettingsInstance.RadioButton10.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_HideCompletedTasks()
        Select Case My.Settings.HideCompletedTasks
            Case True
                SettingsInstance.RadioButton11.Checked = True
            Case False
                SettingsInstance.RadioButton12.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_TasksSize()
        Select Case My.Settings.TasksSize
            Case 0
                SettingsInstance.TasksSize_TrackBar.Value = 0
            Case 1
                SettingsInstance.TasksSize_TrackBar.Value = 1
            Case 2
                SettingsInstance.TasksSize_TrackBar.Value = 2
            Case 3
                SettingsInstance.TasksSize_TrackBar.Value = 3
            Case 4
                SettingsInstance.TasksSize_TrackBar.Value = 4
            Case 5
                SettingsInstance.TasksSize_TrackBar.Value = 5
        End Select
    End Sub

    Private Sub SetSetting_TasksFont()
        Select Case My.Settings.IsTaskFontDefault
            Case True
                SettingsInstance.RadioButton13.Checked = True
            Case False
                SettingsInstance.RadioButton14.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_OnStartupCheckForUpdate()
        Select Case My.Settings.OnStartupCheckForUpdate
            Case True
                SettingsInstance.RadioButton19.Checked = True
            Case False
                SettingsInstance.RadioButton20.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_OnCloseRunInTheBackground()
        Select Case My.Settings.OnCloseRunInTheBackground
            Case True
                SettingsInstance.RadioButton21.Checked = True
            Case False
                SettingsInstance.RadioButton22.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_RunOnWindowsStartup()
        Select Case My.Settings.RunOnWindowsStartup
            Case True
                SettingsInstance.RadioButton23.Checked = True
            Case False
                SettingsInstance.RadioButton24.Checked = True
        End Select
    End Sub

    Private Sub SetSetting_PopupOnStartup()
        Select Case My.Settings.PopupOnStartup
            Case True
                SettingsInstance.RadioButton25.Checked = True
            Case False
                SettingsInstance.RadioButton26.Checked = True
        End Select
    End Sub

#End Region

#Region "UI Appearance"

    Private Sub HighlightActiveFormButton()
        ' Array of View buttons
        Dim ViewButtons() As CustomButton_2 = {CustomButton1, CustomButton2, CustomButton3, CustomButton4, CustomButton5}

        ' Enable all buttons first
        EnableAllButtonsEffects()

        ' Get the active view
        Dim activeView As ViewName = ViewsManager.GetActiveViewName()

        ' Index mapping from ViewName to button array
        Dim buttonIndex As Integer = CType(activeView, Integer)
        If buttonIndex >= 0 AndAlso buttonIndex < ViewButtons.Length Then
            ViewButtons(buttonIndex).DisableEffects()
        End If
    End Sub

    Private Sub EnableAllButtonsEffects()
        CustomButton1.EnableEffects()
        CustomButton2.EnableEffects()
        CustomButton3.EnableEffects()
        CustomButton4.EnableEffects()
        CustomButton5.EnableEffects()
    End Sub

    Public Sub ChangeTasksSize(fontSize As Single)

        ' Dictionary to map view names to their corresponding CheckedListBox controls
        Dim ViewsCheckedListBoxes As New Dictionary(Of String, CheckedListBox) From {
    {ViewName.MyDay, MyDayInstance.MyDay_CheckedListBox},
    {ViewName.Repeated, RepeatedInstance.Repeated_CheckedListBox},
    {ViewName.Important, ImportantInstance.Important_CheckedListBox},
    {ViewName.Planned, PlannedInstance.Planned_CheckedListBox},
    {ViewName.Tasks, TasksInstance.Tasks_CheckedListBox}
}

        Dim activeViewName As ViewName = ViewsManager.GetActiveViewName()

        If ViewsCheckedListBoxes.ContainsKey(activeViewName) Then
            ViewsCheckedListBoxes(activeViewName).Font = New Font(ViewsCheckedListBoxes(activeViewName).Font.FontFamily, fontSize)
        End If

        ' Refresh other views
        For Each viewName In ViewsCheckedListBoxes.Keys
            If viewName <> activeViewName Then
                ViewsCheckedListBoxes(viewName).Font = New Font(ViewsCheckedListBoxes(viewName).Font.FontFamily, fontSize)
            End If
        Next

    End Sub

    Public Sub ChangeTasksFont(NewFont As Font)
        Dim FontName As String = NewFont.Name
        Dim NewFontFixedSize As New Font(FontName, 10)

        ' Dictionary to map view names to their corresponding CheckedListBox controls
        Dim ViewsCheckedListBoxes As New Dictionary(Of String, CheckedListBox) From {
    {ViewName.MyDay, MyDayInstance.MyDay_CheckedListBox},
    {ViewName.Repeated, RepeatedInstance.Repeated_CheckedListBox},
    {ViewName.Important, ImportantInstance.Important_CheckedListBox},
    {ViewName.Planned, PlannedInstance.Planned_CheckedListBox},
    {ViewName.Tasks, TasksInstance.Tasks_CheckedListBox}
}

        ' Dictionary to map view names to their corresponding CheckedListBox controls
        Dim ViewsAddNewTask_TextBoxes As New Dictionary(Of String, TextBox) From {
    {ViewName.MyDay, MyDayInstance.AddNewTask_TextBox},
    {ViewName.Repeated, RepeatedInstance.AddNewTask_TextBox},
    {ViewName.Important, ImportantInstance.AddNewTask_TextBox},
    {ViewName.Planned, PlannedInstance.AddNewTask_TextBox},
    {ViewName.Tasks, TasksInstance.AddNewTask_TextBox}
}

        Dim activeViewName As ViewName = ViewsManager.GetActiveViewName()

        If ViewsCheckedListBoxes.ContainsKey(activeViewName) Then
            ViewsCheckedListBoxes(activeViewName).Font = NewFont
            ViewsAddNewTask_TextBoxes(activeViewName).Font = NewFontFixedSize
        End If

        ' Refresh other views
        For Each viewName In ViewsCheckedListBoxes.Keys
            If viewName <> activeViewName Then
                ViewsCheckedListBoxes(viewName).Font = NewFont
                ViewsAddNewTask_TextBoxes(viewName).Font = NewFontFixedSize
            End If
        Next
    End Sub

#End Region

#Region "Form Management"

    Private Sub AddFormToPanel(form As Form)
        form.TopLevel = False
        form.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(form)
        form.Show()
        form.Hide() ' Initially hide all forms
    End Sub

    Private Sub ShowForm(formToShow As Form)
        formToShow.Show()
        formToShow.BringToFront()
        HighlightActiveFormButton()
    End Sub

    Private Function GetActiveFormInPanel(panel As Panel) As Form
        For Each control As Control In panel.Controls
            If TypeOf control Is Form Then
                Return CType(control, Form)
            End If
        Next
        Return Nothing
    End Function

#End Region

#Region "Sidebar Methods"

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved

        If IsSidebarExpanded Then
            If e.SplitX < ExpandedSidebarWidth - 50 Then
                SetSidebarState(SidebarState.Collapsed)
            ElseIf e.SplitX < ExpandedSidebarWidth Then
                SetSidebarState(SidebarState.Expanded)
            ElseIf e.SplitX > MaxSidebarWidth Then
                SetSidebarState(SidebarState.Maximized)
            End If
        Else
            If e.SplitX > ExpandedSidebarWidth AndAlso e.SplitX < MaxSidebarWidth Then
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = e.SplitX
                ExpandButtons()
                ProfileMaximizeOrMinimize()
            ElseIf e.SplitX < CollapsedSidebarWidth Then
                SetSidebarState(SidebarState.Collapsed)
            ElseIf e.SplitX > CollapsedSidebarWidth Then
                If WindowResized Then
                    WindowResized = False
                    If lastsidebarstate = SidebarState.Collapsed Then
                        SetSidebarState(SidebarState.Collapsed)
                        Exit Sub
                    End If
                End If

                If e.SplitX > MaxSidebarWidth Then
                    SetSidebarState(SidebarState.Maximized)
                ElseIf e.SplitX < MaxSidebarWidth Then
                    SetSidebarState(SidebarState.Expanded)
                End If
            End If
        End If
    End Sub

    Private Sub SplitContainer1_DoubleClick(sender As Object, e As EventArgs) Handles SplitContainer1.DoubleClick
        If IsSidebarExpanded Then
            SetSidebarState(SidebarState.Collapsed)
        Else
            SetSidebarState(SidebarState.Expanded)
        End If
    End Sub

    Private Sub SetSidebarState(state As SidebarState)
        Select Case state
            Case SidebarState.Collapsed
                IsSidebarExpanded = False
                SplitContainer1.SplitterDistance = CollapsedSidebarWidth
                CollapseButtons()
                lastsidebarstate = SidebarState.Collapsed

            Case SidebarState.Expanded
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = ExpandedSidebarWidth
                ExpandButtons()
                lastsidebarstate = SidebarState.Expanded

            Case SidebarState.Maximized
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = MaxSidebarWidth
                ExpandButtons()
                lastsidebarstate = SidebarState.Maximized
        End Select
        ProfileMaximizeOrMinimize()
    End Sub

    Private Sub SetButtonColumnWidth(cl0width As Single, cl1width As Single)
        Dim buttons As CustomButton_2() = {CustomButton1, CustomButton2, CustomButton3, CustomButton4, CustomButton5}

        ' Suspend layout for each button to avoid flickering
        For Each btn As CustomButton_2 In buttons
            btn.TableLayoutPanel1.SuspendLayout()
        Next

        ' Update column styles
        For Each btn As CustomButton_2 In buttons
            btn.TableLayoutPanel1.ColumnStyles(0).SizeType = SizeType.Percent
            btn.TableLayoutPanel1.ColumnStyles(0).Width = cl0width
            btn.TableLayoutPanel1.ColumnStyles(1).SizeType = SizeType.Percent
            btn.TableLayoutPanel1.ColumnStyles(1).Width = cl1width
        Next

        ' Resume layout for each button
        For Each btn As CustomButton_2 In buttons
            btn.TableLayoutPanel1.ResumeLayout()
            btn.TableLayoutPanel1.Refresh() ' Refresh to apply the changes
        Next
    End Sub

    Private Sub CollapseButtons()
        SetButtonColumnWidth(100, 0)
    End Sub

    Private Sub ExpandButtons()
        SetButtonColumnWidth(20, 80)
    End Sub

    Private Sub ProfileMaximizeOrMinimize()
        If IsSidebarExpanded Then
            Pfp_CircularPictureBox.Width = 57
            Pfp_CircularPictureBox.Height = 57

            If My.Settings.IsUsernameVisible = True Then
                Username_Label.Show()
            End If
        Else
            Pfp_CircularPictureBox.Width = 42
            Pfp_CircularPictureBox.Height = 42

            Username_Label.Hide()
        End If
    End Sub

#End Region

#Region "Profile Methods"

    Private Sub LoadProfile()
        If GetPfpPath() = Nothing Then
            Pfp_MenuStripItem_Empty.Checked = True
            Pfp_MenuStripItem_Empty.Enabled = False
            Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
        ElseIf File.Exists(GetPfpPath()) Then
            If My.Settings.IsPfpDefault = True Then
                Pfp_CircularPictureBox.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Defaults\DefaultPfp.png"))
                Pfp_MenuStripItem_Default.Checked = True
                Pfp_MenuStripItem_Default.Enabled = False
                Pfp_MenuStripItem_Empty.Checked = False
            Else
                Pfp_CircularPictureBox.Image = Image.FromFile(GetPfpPath())
                Pfp_MenuStripItem_Default.Checked = False
                Pfp_MenuStripItem_Empty.Checked = False
            End If
        End If
        If GetUsername() = Nothing Then
            Username_MenuStripItem_Empty.Checked = True
            Username_MenuStripItem_Empty.Enabled = False
            Username_Label.Text = "          "
            Username_Label.BorderStyle = BorderStyle.FixedSingle
        Else
            Username_Label.Text = GetUsername()
            If My.Settings.Username = "I'm Batman" And My.Settings.IsPfpDefault = True Then
                ImBatman.Checked = True
                ImBatman.Enabled = False
            Else
                ImBatman.Checked = False
                ImBatman.Enabled = True
            End If
            Username_MenuStripItem_Empty.Enabled = True
            Username_Label.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Function GetPfpPath() As String
        Return My.Settings.PfpPath
    End Function

    Private Function GetUsername() As String
        Return My.Settings.Username
    End Function

#End Region

#Region "Profile Context Menu Methods"

    Private Sub Pfp_MenuStripItem_ChangePicture_Click(sender As Object, e As EventArgs) Handles Pfp_MenuStripItem_ChangePicture.Click
        Pfp_OpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        Pfp_OpenFileDialog.Title = "Select an Image"

        If Pfp_OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Pfp_CircularPictureBox.ImageLocation = Pfp_OpenFileDialog.FileName
            Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
            Pfp_MenuStripItem_Empty.Checked = False
            Pfp_MenuStripItem_Empty.Enabled = True
            Pfp_MenuStripItem_Default.Checked = False
            Pfp_MenuStripItem_Default.Enabled = True
            My.Settings.PfpPath = Pfp_OpenFileDialog.FileName

            My.Settings.IsPfpDefault = False

            ImBatman.Checked = False
            ImBatman.Enabled = True
        End If
    End Sub

    Private Sub Pfp_MenuStripItem_Empty_Click(sender As Object, e As EventArgs) Handles Pfp_MenuStripItem_Empty.Click
        Pfp_CircularPictureBox.Image = Nothing
        Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
        Pfp_MenuStripItem_Empty.Checked = True
        Pfp_MenuStripItem_Empty.Enabled = False
        Pfp_MenuStripItem_Default.Checked = False
        Pfp_MenuStripItem_Default.Enabled = True
        My.Settings.PfpPath = Nothing

        My.Settings.IsPfpDefault = False

        ImBatman.Checked = False
        ImBatman.Enabled = True
    End Sub

    Private Sub Pfp_MenuStripItem_Default_Click(sender As Object, e As EventArgs) Handles Pfp_MenuStripItem_Default.Click
        My.Settings.PfpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Defaults\DefaultPfp.png")
        Pfp_CircularPictureBox.ImageLocation = My.Settings.PfpPath
        Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
        Pfp_MenuStripItem_Empty.Enabled = True
        Pfp_MenuStripItem_Empty.Checked = False
        Pfp_MenuStripItem_Default.Checked = True
        Pfp_MenuStripItem_Default.Enabled = False

        My.Settings.IsPfpDefault = True
    End Sub

    Private Sub Username_MenuStripItem_ChangeName_Click(sender As Object, e As EventArgs) Handles Username_MenuStripItem_ChangeName.Click
        Dim userInput As String
        userInput = InputBox("", "Enter your new Username")

        If String.IsNullOrEmpty(userInput) Then
            Exit Sub
        Else
            My.Settings.Username = userInput
            Username_MenuStripItem_Empty.Checked = False
            Username_MenuStripItem_Empty.Enabled = True
            Username_Label.Text = userInput
            Username_Label.BorderStyle = BorderStyle.None

            ImBatman.Checked = False
            ImBatman.Enabled = True
        End If
    End Sub

    Private Sub Username_MenuStripItem_Empty_Click(sender As Object, e As EventArgs) Handles Username_MenuStripItem_Empty.Click
        Username_Label.Text = "          "
        Username_Label.BorderStyle = BorderStyle.FixedSingle
        Username_MenuStripItem_Empty.Checked = True
        Username_MenuStripItem_Empty.Enabled = False
        My.Settings.Username = Nothing

        ImBatman.Checked = False
        ImBatman.Enabled = True
    End Sub

    Private Sub ImBatman_Click(sender As Object, e As EventArgs) Handles ImBatman.Click
        My.Settings.ImBatman = True

        My.Settings.IsPfpDefault = True
        My.Settings.PfpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Defaults\DefaultPfp.png")
        My.Settings.Username = "Batman"
        Username_Label.ResetText()
        Username_Label.Text = My.Settings.Username

        Pfp_CircularPictureBox.Image = Image.FromFile(My.Settings.PfpPath)

        Pfp_MenuStripItem_Default.Checked = True
        Pfp_MenuStripItem_Default.Enabled = False

        Pfp_MenuStripItem_Empty.Checked = False
        Pfp_MenuStripItem_Empty.Enabled = True

        ImBatman.Checked = True
        ImBatman.Enabled = False

        Username_MenuStripItem_Empty.Checked = False
        Username_MenuStripItem_Empty.Enabled = True

        Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
        Username_Label.BorderStyle = BorderStyle.None
    End Sub

#End Region

#Region "Username Events"

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Username_Label.MouseEnter
        If GetUsername() <> Nothing Then
            Username_Label.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Username_Label.MouseLeave
        If GetUsername() <> Nothing Then
            Username_Label.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub Label1_MouseClick(sender As Object, e As MouseEventArgs) Handles Username_Label.MouseClick
        Username_ContextMenuStrip.Show(Username_Label, e.Location)
    End Sub

#End Region

#Region "Profile Picture Events"

    Private Sub Pfp_CircularPictureBox_MouseEnter(sender As Object, e As EventArgs) Handles Pfp_CircularPictureBox.MouseEnter
        If GetPfpPath() <> Nothing Then
            Dim now As DateTime = DateTime.Now
            If now - PfpLastEventTime > DebounceDelay Then
                PfpLastEventTime = now
                Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
            End If
        End If
    End Sub

    Private Sub Pfp_CircularPictureBox_MouseLeave(sender As Object, e As EventArgs) Handles Pfp_CircularPictureBox.MouseLeave
        If GetPfpPath() <> Nothing Then
            Dim now As DateTime = DateTime.Now
            If now - PfpLastEventTime > DebounceDelay Then
                PfpLastEventTime = now
                Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
            End If
        End If
    End Sub

    Private Sub Pfp_CircularPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles Pfp_CircularPictureBox.MouseClick
        Pfp_ContextMenuStrip.Show(Pfp_CircularPictureBox, e.Location)
    End Sub

#End Region

#Region "Button Click Events"

    Private Sub HandleViewButtonClick(viewInstance As Object, textBox As TextBox, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ShowForm(viewInstance)
            textBox.Focus()
        End If
    End Sub

    Private Sub CustomButton1_Click(sender As Object, e As MouseEventArgs) Handles CustomButton1.MouseClick
        HandleViewButtonClick(MyDayInstance, MyDayInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As MouseEventArgs) Handles CustomButton2.MouseClick
        HandleViewButtonClick(RepeatedInstance, RepeatedInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As MouseEventArgs) Handles CustomButton3.MouseClick
        HandleViewButtonClick(ImportantInstance, ImportantInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As MouseEventArgs) Handles CustomButton4.MouseClick
        HandleViewButtonClick(PlannedInstance, PlannedInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton5_Click(sender As Object, e As MouseEventArgs) Handles CustomButton5.MouseClick
        HandleViewButtonClick(TasksInstance, TasksInstance.AddNewTask_TextBox, e)
    End Sub

#End Region

#Region "Helper Methods"

    Private Sub Test_BackColors_Click(sender As Object, e As EventArgs) Handles Test_BackColors.Click
        ' Dim activeForm As Form = GetActiveFormInPanel(SplitContainer1.Panel2)
        If ActiveForm IsNot Nothing Then
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                ' Safely access MainTableLayoutPanel if it exists
                Dim mainTableLayoutPanel As Control = ActiveForm.Controls.Find("MainTlp", True).FirstOrDefault()
                If mainTableLayoutPanel IsNot Nothing Then
                    mainTableLayoutPanel.BackColor = ColorDialog1.Color
                Else
                    MessageBox.Show("The active form does not contain a MainTableLayoutPanel control.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("No active form found in the panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Settings_Button_Click(sender As Object, e As EventArgs) Handles Settings_Button.Click
        ActiveControl = Nothing
        Dim activeView As ViewName = ViewsManager.GetActiveViewName()
        Select Case activeView
            Case ViewName.MyDay
                MyDayInstance.DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
            Case ViewName.Repeated
                RepeatedInstance.DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
            Case ViewName.Important
                ImportantInstance.DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
            Case ViewName.Planned
                PlannedInstance.DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
            Case ViewName.Tasks
                TasksInstance.DisableHide_TaskPropertiesSidebar(TaskPropertiesSidebarAction.DisableOnly)
        End Select
        SettingsInstance.ShowDialog()
        SettingsInstance.BringToFront()
        HighlightActiveFormButton()
    End Sub

#End Region

    Private Sub Base_resize(sender As Object, e As EventArgs) Handles Me.Resize
        workingArea = Screen.GetWorkingArea(Me)
        If isMaximized = True Then
            ResizeLogic()
        End If
        WindowResized = True
    End Sub

#Region "Custom Titlebar"

    Private Sub ResizeLogic()
        isMaximized = False
        If My.Settings.ColorScheme = "Dark" Then
            SetColorScheme.SetCustomTitleBarScheme("Dark") ' Sub is little confusing as it also changes the restore/maximize icons
        Else
            SetColorScheme.SetCustomTitleBarScheme("Light")
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startX = e.X
            startY = e.Y
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If isDragging Then
            If isMaximized = True Then
                Button2.PerformClick()
            End If
            Dim currentPos = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(currentPos.X - startX, currentPos.Y - startY)
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.Red
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Panel1.BackColor
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.ActiveControl = Nothing
        If SettingsCache.OnCloseRunInTheBackground Then
            Me.Hide()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ActiveControl = Nothing

        If isMaximized Then
            isMaximized = False
            Me.Size = CurrentNormalWindowSize
            Me.WindowState = FormWindowState.Normal
            Me.CenterToScreen()
        Else
            isMaximized = True
            CurrentNormalWindowSize = Me.Size
            SimulateMaximizedState()
            Me.CenterToScreen()
        End If

        If My.Settings.ColorScheme = "Dark" Then
            SetColorScheme.SetCustomTitleBarScheme("Dark")
        Else
            SetColorScheme.SetCustomTitleBarScheme("Light")
        End If
    End Sub

    Private Sub SimulateMaximizedState()
        ' Get the working area (excluding taskbar)
        workingArea = Screen.GetWorkingArea(Me)

        ' Set the form's size to the working area

        Dim MaximizedWidth As Integer = workingArea.Size.Width
        Dim MaximizedHeight As Integer = workingArea.Size.Height - 1
        Me.Size = New Size(MaximizedWidth, MaximizedHeight)

        ' Set the form's location to the top-left of the working area
        Me.Location = workingArea.Location

        ' Ensure the form has a sizable border to allow resizing
        Me.FormBorderStyle = FormBorderStyle.Sizable

        ' You can set a flag if you need to track this custom "maximized" state
        isMaximized = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.ActiveControl = Nothing
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDoubleClick
        Button2.PerformClick()
    End Sub

    ' Override the CreateParams to hide the title bar without removing resizability
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style And Not &HC00000 ' WS_CAPTION (removes the title bar)
            Return cp
        End Get
    End Property

#End Region

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.ActiveControl = Nothing
        If SettingsInstance.ColorScheme_Dark_RadioBtn.Checked Then
            SettingsInstance.ColorScheme_Light_RadioBtn.Checked = True
            HighlightActiveFormButton()
        Else
            SettingsInstance.ColorScheme_Dark_RadioBtn.Checked = True
            HighlightActiveFormButton()
        End If

    End Sub

    Private Sub Help_Button_Click(sender As Object, e As EventArgs) Handles Help_Button.Click
        Me.ActiveControl = Nothing
        Help_Dialog.Show()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Save the window size before closing
        My.Settings.LastSavedWindowSize_Width = Me.Size.Width
        My.Settings.LastSavedWindowSize_Height = Me.Size.Height
    End Sub

    Private Sub ReminderNotification_MouseClick(sender As Object, e As MouseEventArgs) Handles ReminderNotification.MouseClick
        If e.Button = MouseButtons.Left Then
            Me.Show()
        End If
    End Sub

    Private Sub Settings_Button_MouseEnter(sender As Object, e As EventArgs) Handles Settings_Button.MouseEnter
        Settings_Button.BackgroundImage = My.Resources.SettingsIcon_Blue_
    End Sub

    Private Sub Settings_Button_MouseLeave(sender As Object, e As EventArgs) Handles Settings_Button.MouseLeave
        Select Case SettingsCache.ColorScheme
            Case "Dark"
                Settings_Button.BackgroundImage = My.Resources.SettingsIcon_White_
            Case "Light"
                Settings_Button.BackgroundImage = My.Resources.SettingsIcon_Black_
        End Select
    End Sub

    Private Sub Help_Button_MouseEnter(sender As Object, e As EventArgs) Handles Help_Button.MouseEnter
        Help_Button.BackgroundImage = My.Resources.HelpIcon_Blue_
    End Sub

    Private Sub Helps_Button_MouseLeave(sender As Object, e As EventArgs) Handles Help_Button.MouseLeave
        Select Case SettingsCache.ColorScheme
            Case "Dark"
                Help_Button.BackgroundImage = My.Resources.HelpIcon_White_
            Case "Light"
                Help_Button.BackgroundImage = My.Resources.HelpIcon_Black_
        End Select
    End Sub

    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ReminderNotification.Dispose()
    End Sub
End Class