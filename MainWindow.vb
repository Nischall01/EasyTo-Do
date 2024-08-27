Imports System.IO
'Imports Newtonsoft.Json
'Imports Newtonsoft.Json.Linq

Public Class MainWindow
    ' Constants
    Private Const CollapsedSidebarWidth As Integer = 50
    Private Const ExpandedSidebarWidth As Integer = 200
    Private Const MaxSidebarWidth As Integer = 333

    ' Fields
    Private PfpLastEventTime As DateTime
    Private IsSidebarExpanded As Boolean
    Private ReadOnly DebounceDelay As TimeSpan = TimeSpan.FromMilliseconds(50)

    ' Enums
    Private Enum SidebarState
        Collapsed
        Expanded
        Maximized
    End Enum

    Public Enum TaskPropertiesVisibility
        Toggle
        Show
        Hide
    End Enum

    Public Enum ViewName
        MyDay
        Repeated
        Important
        Planned
        Tasks
        None
    End Enum

    ' Forms
    Public MyDayInstance As New MyDay_View()
    Public RepeatedInstance As New Repeated_View()
    Public ImportantInstance As New Important_View()
    Public PlannedInstance As New Planned_View()
    Public TasksInstance As New Tasks_View()
    Public SettingsInstance As New Settings_Dialog()

    Public Shared isUiUpdating As Boolean = False
    '--------------------------------------------------------------------On Load-----------------------------------------------------------------------'
#Region "Constructor and Load"
    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForms()
        InitializeApp()
    End Sub
#End Region

    '-------------------------------------------------------------Initialization Methods---------------------------------------------------------------'
#Region "Initialization Methods"
    Private Sub InitializeForms()
        AddFormToPanel(MyDayInstance)
        AddFormToPanel(RepeatedInstance)
        AddFormToPanel(ImportantInstance)
        AddFormToPanel(PlannedInstance)
        AddFormToPanel(TasksInstance)
    End Sub

    Private Sub InitializeApp()
        ' Initial state for sidebar is set as expanded
        Select Case My.Settings.SidebarOnStart
            Case "Expanded"
                SetSidebarState(SidebarState.Expanded)
            Case "Collapsed"
                SetSidebarState(SidebarState.Collapsed)
        End Select
        'Load the User Profile
        LoadProfile()
        ViewsManager.RefreshTasks()
        ' Initial Form
        ShowForm(MyDayInstance)
        MyDayInstance.ActiveControl = MyDayInstance.AddNewTask_TextBox
        ' Load the Selected Appearance 
        LoadSettings()
    End Sub
#End Region

    '-----------------------------------------------------------------UI Appearance---------------------------------------------------------------
#Region "UI Appearance"
    Private Sub LoadSettings()
        SetColorSchemeFromSettings()
        SetSidebarStateFromSettings()
        SetTaskPropertiesSidebarStateFromSettings()
        SetTimeFormatFromSettings()
        SetProfileVisibilityFromSettings()
    End Sub

    Private Sub SetColorSchemeFromSettings()
        Select Case My.Settings.ColorScheme
            Case "Light"
                SetColorScheme.Light()
                SettingsInstance.ColorScheme_Light_RadioBtn.Checked = True
            Case "Dark"
                SetColorScheme.Dark()
                SettingsInstance.ColorScheme_Dark_RadioBtn.Checked = True
            Case "Custom"
                SetColorScheme.Custom()
                SettingsInstance.ColorScheme_Custom_RadioBtn.Checked = True
        End Select
    End Sub

    Private Sub SetSidebarStateFromSettings()
        Select Case My.Settings.SidebarOnStart
            Case "Expanded"
                SettingsInstance.RadioButton3.Checked = True
            Case "Collapsed"
                SettingsInstance.RadioButton2.Checked = True
        End Select
    End Sub

    Private Sub SetTaskPropertiesSidebarStateFromSettings()
        Select Case My.Settings.TaskPropertiesSidebarOnStart
            Case "Expanded"
                SettingsInstance.RadioButton4.Checked = True
            Case "Collapsed"
                SettingsInstance.RadioButton1.Checked = True
        End Select
    End Sub

    Private Sub SetTimeFormatFromSettings()
        Select Case My.Settings.TimeFormat
            Case "12"
                SettingsInstance.RadioButton6.Checked = True
            Case "24"
                SettingsInstance.RadioButton5.Checked = True
        End Select
    End Sub

    Private Sub SetProfileVisibilityFromSettings()
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

    Private Sub HighlightActiveFormButton()
        ' Array of View buttons
        Dim ViewButtons() As CustomButton_2 = {CustomButton1, CustomButton2, CustomButton3, CustomButton4, CustomButton5}

        ' Enable all buttons first
        EnableAllButtons()

        ' Get the active view
        Dim activeView As ViewName = ViewsManager.GetActiveViewName()

        ' Index mapping from ViewName to button array
        Dim buttonIndex As Integer = CType(activeView, Integer)
        If buttonIndex >= 0 AndAlso buttonIndex < ViewButtons.Length Then
            ViewButtons(buttonIndex).DisableEffects()
        End If
    End Sub

    Private Sub EnableAllButtons()
        CustomButton1.EnableEffects()
        CustomButton2.EnableEffects()
        CustomButton3.EnableEffects()
        CustomButton4.EnableEffects()
        CustomButton5.EnableEffects()
    End Sub

#End Region

    '----------------------------------------------------------------Form Management-------------------------------------------------------------------'
#Region "Form Management"
    Private Sub AddFormToPanel(form As Form)
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(form)
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

    '----------------------------------------------------------------Sidebar Methods-------------------------------------------------------------------'
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

            Case SidebarState.Expanded
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = ExpandedSidebarWidth
                ExpandButtons()

            Case SidebarState.Maximized
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = MaxSidebarWidth
                ExpandButtons()
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

    '----------------------------------------------------------------Profile Methods-------------------------------------------------------------------'
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

    '----Profile Context Menu Methods----'
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
        My.Settings.Username = "I'm Batman"
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

    '----Username Events----'
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

    '----Profile Picture Events----'
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

    '--------------------------------------------------------------Button Click Events----------------------------------------------------------------'
#Region "Button Click Events"
    Private Sub HandleViewButtonClick(viewInstance As Object, checkListBox As CheckedListBox, textBox As TextBox, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ShowForm(viewInstance)
            textBox.Focus()
        End If
    End Sub

    Private Sub CustomButton1_Click(sender As Object, e As MouseEventArgs) Handles CustomButton1.MouseClick
        HandleViewButtonClick(MyDayInstance, MyDayInstance.MyDay_CheckedListBox, MyDayInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As MouseEventArgs) Handles CustomButton2.MouseClick
        HandleViewButtonClick(RepeatedInstance, RepeatedInstance.Repeated_CheckedListBox, RepeatedInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As MouseEventArgs) Handles CustomButton3.MouseClick
        HandleViewButtonClick(ImportantInstance, ImportantInstance.Important_CheckedListBox, ImportantInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As MouseEventArgs) Handles CustomButton4.MouseClick
        HandleViewButtonClick(PlannedInstance, PlannedInstance.Planned_CheckedListBox, PlannedInstance.AddNewTask_TextBox, e)
    End Sub

    Private Sub CustomButton5_Click(sender As Object, e As MouseEventArgs) Handles CustomButton5.MouseClick
        HandleViewButtonClick(TasksInstance, TasksInstance.Tasks_CheckedListBox, TasksInstance.AddNewTask_TextBox, e)
    End Sub
#End Region

    '----------------------------------------------------------------Helper Methods-------------------------------------------------------------------'
#Region "Helper Methods"
    Private Sub Test_BackColors_Click(sender As Object, e As EventArgs) Handles Test_BackColors.Click
        Dim activeForm As Form = GetActiveFormInPanel(SplitContainer1.Panel2)
        If activeForm IsNot Nothing Then
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                ' Safely access MainTableLayoutPanel if it exists
                Dim mainTableLayoutPanel As Control = activeForm.Controls.Find("MainTlp", True).FirstOrDefault()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SettingsInstance.ShowDialog()
        SettingsInstance.BringToFront()
        HighlightActiveFormButton()
    End Sub
#End Region
End Class
