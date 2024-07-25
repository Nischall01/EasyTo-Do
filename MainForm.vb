Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO

Public Class MainForm
    'Booleans
    Dim IsSidebarExpanded As Boolean

    'Constants
    Const CollapsedSidebarWidth As Integer = 50
    Const ExpandedSidebarWidth As Integer = 200
    Const MaxSidebarWidth As Integer = 350

    Private Enum SidebarState
        Collapsed
        Expanded
        Maximized
    End Enum

    Const Button1_Text As String = "My Day"
    Const Button2_Text As String = "Daily"
    Const Button3_Text As String = "Important"
    Const Button4_Text As String = "Planned"
    Const Button5_Text As String = "Tasks"

    ' Forms
    Private MyDayFormInstance As New My_Day()
    Private DailyFormInstance As New Daily()
    Private ImportantFormInstance As New Important()
    Private PlannedFormInstance As New Planned()
    Private TasksFormInstance As New Tasks()
    '-----------------------------------------------On load-----------------------------------------------------'
    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForms()
        InitializeApp()
    End Sub

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

    '-----------------------------------------------Methods-----------------------------------------------------'

    ' Toggle the sidebar state between expanded and collapsed on Splitter double click
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
            If e.SplitX > ExpandedSidebarWidth And e.SplitX < MaxSidebarWidth Then
                IsSidebarExpanded = True
                SplitContainer1.SplitterDistance = e.SplitX
                ExpandButtons()
            ElseIf e.SplitX < CollapsedSidebarWidth Then
                SetSidebarState(SidebarState.Collapsed)
            ElseIf e.SplitX > CollapsedSidebarWidth Then
                If e.SplitX > MaxSidebarWidth Then
                    SetSidebarState(SidebarState.Maximized)
                ElseIf e.SplitX < MaxSidebarWidth Then
                    SetSidebarState(SidebarState.Expanded)
                End If
            Else
            End If
        End If
    End Sub

    Private Sub ProfileMaximizeOrMinimize()
        If IsSidebarExpanded Then
            Pfp_CircularPictureBox.Width = 57
            Pfp_CircularPictureBox.Height = 57

            Username_PictureBox.Show()
        Else
            Pfp_CircularPictureBox.Width = 42
            Pfp_CircularPictureBox.Height = 42

            Username_PictureBox.Hide()
        End If
    End Sub



    Private Sub LoadProfile()

        If GetPfpPath() = Nothing Then
            Pfp_MenuStripItem_Empty.Checked = True
            Pfp_MenuStripItem_Empty.Enabled = False
            Pfp_CircularPictureBox.BorderStyle = BorderStyle.FixedSingle
        ElseIf File.Exists(GetPfpPath()) Then
            Pfp_CircularPictureBox.Image = Image.FromFile(GetPfpPath())
            Pfp_MenuStripItem_Empty.Enabled = True
        End If

    End Sub

    Private Function GetPfpPath() As String
        Dim PfpPath As String
        PfpPath = My.Settings.PfpPath
        Return PfpPath
    End Function

    Private Function GetUsername()
        Dim Username As String
        'Username = "Meleys"
        Username = My.Settings.Username
        Return Username
    End Function

    Private Sub AddFormToPanel(form As Form)
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(form)
        form.Hide() ' Initially hide all forms
    End Sub

    Private Sub ShowForm(formToShow As Form)
        ' Show the selected form
        formToShow.Show()
        formToShow.BringToFront()
    End Sub

    Private Sub Username_PictureBox_Paint(sender As Object, e As PaintEventArgs) Handles Username_PictureBox.Paint
        Dim text As String = GetUsername()

        If String.IsNullOrWhiteSpace(text) Then
            Username_PictureBox.BorderStyle = BorderStyle.FixedSingle
            Username_MenuStripItem_Empty.Checked = True
            Username_MenuStripItem_Empty.Enabled = False
        Else
            Username_PictureBox.BorderStyle = BorderStyle.None
            Username_MenuStripItem_Empty.Checked = False
            Username_MenuStripItem_Empty.Enabled = True
        End If

        Dim font As New Font("Microsoft YaHei", 8.25, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.White)

        AdjustUsernamePictureBoxWidth(Username_PictureBox, text, font)

        ' Draw the text in the center of the PictureBox
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (Username_PictureBox.ClientSize.Width - textSize.Width) / 2
        Dim textY As Single = (Username_PictureBox.ClientSize.Height - textSize.Height) / 2

        ' Draw the text
        e.Graphics.DrawString(text, font, brush, New PointF(textX, textY))


    End Sub

    Private Sub CustomButton1_Click(sender As Object, e As EventArgs) Handles CustomButton1.Click
        ShowForm(MyDayFormInstance)
    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As EventArgs) Handles CustomButton2.Click
        ShowForm(DailyFormInstance)
    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As EventArgs) Handles CustomButton3.Click
        ShowForm(ImportantFormInstance)
    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As EventArgs) Handles CustomButton4.Click
        ShowForm(PlannedFormInstance)
    End Sub

    Private Sub CustomButton5_Click(sender As Object, e As EventArgs) Handles CustomButton5.Click
        ShowForm(TasksFormInstance)
    End Sub

    Private Function GetActiveFormInPanel(panel As Panel) As Form
        For Each control As Control In panel.Controls
            If TypeOf control Is Form Then
                Return CType(control, Form)
            End If
        Next
        Return Nothing
    End Function

    'Will be helpful later on
    Private Sub Test_BackColors_Click(sender As Object, e As EventArgs) Handles Test_BackColors.Click
        Dim activeForm As Form = GetActiveFormInPanel(SplitContainer1.Panel2)
        If activeForm IsNot Nothing Then
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                ' Safely access MainTableLayoutPanel if it exists
                Dim mainTableLayoutPanel As Control = activeForm.Controls.Find("MainTableLayoutPanel", True).FirstOrDefault()
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



    Private Sub CircularPictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles Pfp_CircularPictureBox.MouseClick
        Pfp_ContextMenuStrip.Show(Pfp_CircularPictureBox, e.Location)
    End Sub

    Private Sub PictureBox_Username_MouseClick(sender As Object, e As MouseEventArgs) Handles Username_PictureBox.MouseClick
        Username_ContextMenuStrip.Show(Username_PictureBox, e.Location)
    End Sub

    Private Sub Pfp_MenuStripItem_ChangePicture_Click(sender As Object, e As EventArgs) Handles Pfp_MenuStripItem_ChangePicture.Click
        Pfp_OpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        Pfp_OpenFileDialog.Title = "Select an Image"

        If Pfp_OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Pfp_CircularPictureBox.ImageLocation = Pfp_OpenFileDialog.FileName

            My.Settings.PfpPath = Pfp_OpenFileDialog.FileName

            Pfp_CircularPictureBox.BorderStyle = BorderStyle.None
            Pfp_MenuStripItem_Empty.Checked = False
            Pfp_MenuStripItem_Empty.Enabled = True
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
            Username_PictureBox.Refresh()
            Username_MenuStripItem_Empty.Checked = False
        End If
    End Sub

    Private Sub Username_MenuStripItem_Empty_Click(sender As Object, e As EventArgs) Handles Username_MenuStripItem_Empty.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want Username to be empty?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            My.Settings.Username = ""
            Username_PictureBox.Refresh()
            Username_MenuStripItem_Empty.Checked = True
            Username_PictureBox.BorderStyle = BorderStyle.Fixed3D
        ElseIf result = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub AdjustUsernamePictureBoxWidth(picBox As PictureBox, text As String, font As Font)
        ' Create a Graphics object to measure the text width
        Using g As Graphics = picBox.CreateGraphics()
            ' Measure the string's width using the specified font
            Dim textSize As SizeF = g.MeasureString(text, font)

            ' Set the PictureBox's width based on the text width
            ' Add some padding for better appearance
            picBox.Width = CInt(textSize.Width) + 20 ' Adding 20 pixels padding
        End Using
    End Sub
End Class