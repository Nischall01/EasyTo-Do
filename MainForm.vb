Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class MainForm
    ' Constants
    Private Const CollapsedSidebarWidth As Integer = 50
    Private Const ExpandedSidebarWidth As Integer = 200
    Private Const MaxSidebarWidth As Integer = 350

    ' Fields
    Private PfpLastEventTime As DateTime
    Private debounceDelay As TimeSpan = TimeSpan.FromMilliseconds(50)
    Private IsSidebarExpanded As Boolean

    ' Enums
    Private Enum SidebarState
        Collapsed
        Expanded
        Maximized
    End Enum

    ' Forms
    Private MyDayFormInstance As New My_Day()
    Private DailyFormInstance As New Daily()
    Private ImportantFormInstance As New Important()
    Private PlannedFormInstance As New Planned()
    Private TasksFormInstance As New Tasks()

    '--------------------------------------------------------------------On Load-----------------------------------------------------------------------'
#Region "Constructor and Load"
    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForms()
        InitializeApp()
    End Sub
#End Region

    '-------------------------------------------------------------Initialization Methods---------------------------------------------------------------'
#Region "Initialization Methods"
    Private Sub InitializeForms()
        AddFormToPanel(MyDayFormInstance)
        AddFormToPanel(DailyFormInstance)
        AddFormToPanel(ImportantFormInstance)
        AddFormToPanel(PlannedFormInstance)
        AddFormToPanel(TasksFormInstance)
    End Sub

    Private Sub InitializeApp()
        ' Initial state for sidebar is set as expanded
        SetSidebarState(SidebarState.Expanded)
        LoadProfile()
        ' Initial Form
        ShowForm(MyDayFormInstance)
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

            Label1.Show()
        Else
            Pfp_CircularPictureBox.Width = 42
            Pfp_CircularPictureBox.Height = 42

            Label1.Hide()
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
            Pfp_CircularPictureBox.Image = Image.FromFile(GetPfpPath())
            Pfp_MenuStripItem_Empty.Enabled = True
        End If

        If GetUsername() = Nothing Then
            Label1.Text = "          "
            Label1.BorderStyle = BorderStyle.FixedSingle
        Else
            Label1.Text = GetUsername()
            Label1.BorderStyle = BorderStyle.None
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
            My.Settings.PfpPath = Pfp_OpenFileDialog.FileName
        End If
    End Sub

    Private Sub Pfp_MenuStripItem_Empty_Click(sender As Object, e As EventArgs) Handles Pfp_MenuStripItem_Empty.Click
        Pfp_CircularPictureBox.Image = Nothing
        Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
        Pfp_MenuStripItem_Empty.Checked = True
        Pfp_MenuStripItem_Empty.Enabled = False
        My.Settings.PfpPath = Nothing
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
            Label1.Text = userInput
            Label1.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub Username_MenuStripItem_Empty_Click(sender As Object, e As EventArgs) Handles Username_MenuStripItem_Empty.Click
        Label1.Text = "          "
        Label1.BorderStyle = BorderStyle.FixedSingle
        Username_MenuStripItem_Empty.Checked = True
        Username_MenuStripItem_Empty.Enabled = False
        My.Settings.Username = Nothing
    End Sub
#End Region

    '----Username Events----'
#Region "Username Events"
    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label1_MouseClick(sender As Object, e As MouseEventArgs) Handles Label1.MouseClick
        Username_ContextMenuStrip.Show(Label1, e.Location)
    End Sub
#End Region

    '----Profile Picture Events----'
#Region "Profile Picture Events"
    Private Sub Pfp_CircularPictureBox_MouseEnter(sender As Object, e As EventArgs) Handles Pfp_CircularPictureBox.MouseEnter
        Dim now As DateTime = DateTime.Now
        If now - PfpLastEventTime > debounceDelay Then
            PfpLastEventTime = now
            Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub Pfp_CircularPictureBox_MouseLeave(sender As Object, e As EventArgs) Handles Pfp_CircularPictureBox.MouseLeave
        Dim now As DateTime = DateTime.Now
        If now - PfpLastEventTime > debounceDelay Then
            PfpLastEventTime = now
            Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub Pfp_CircularPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles Pfp_CircularPictureBox.MouseClick
        Pfp_ContextMenuStrip.Show(Pfp_CircularPictureBox, e.Location)
    End Sub
#End Region

    '--------------------------------------------------------------Button Click Events----------------------------------------------------------------'
#Region "Button Click Events"
    Private Sub CustomButton1_Click(sender As Object, e As MouseEventArgs) Handles CustomButton1.Click
        If e.Button = MouseButtons.Left Then
            ShowForm(MyDayFormInstance)
            MyDayFormInstance.TextBox_AddNewTask.Focus()
        End If
    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As MouseEventArgs) Handles CustomButton2.Click
        If e.Button = MouseButtons.Left Then
            ShowForm(DailyFormInstance)
        End If
    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As MouseEventArgs) Handles CustomButton3.Click
        If e.Button = MouseButtons.Left Then
            ShowForm(ImportantFormInstance)
        End If
    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As MouseEventArgs) Handles CustomButton4.Click
        If e.Button = MouseButtons.Left Then
            ShowForm(PlannedFormInstance)
        End If
    End Sub

    Private Sub CustomButton5_Click(sender As Object, e As MouseEventArgs) Handles CustomButton5.Click
        If e.Button = MouseButtons.Left Then
            ShowForm(TasksFormInstance)
        End If
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

    Private Sub CustomButton5_Click(sender As Object, e As EventArgs) Handles CustomButton5.Click

    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As EventArgs) Handles CustomButton4.Click

    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As EventArgs) Handles CustomButton3.Click

    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As EventArgs) Handles CustomButton2.Click

    End Sub

    Private Sub CustomButton1_Click(sender As Object, e As EventArgs) Handles CustomButton1.Click

    End Sub
#End Region
End Class
