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

    Private Sub SetButtonColumnWidth(cl1width As Single, cl2width As Single)
        Dim buttons As CustomButton_2() = {CustomButton1, CustomButton2, CustomButton3, CustomButton4, CustomButton5}

        For Each btn As CustomButton_2 In buttons
            btn.TableLayoutPanel1.ColumnStyles(0).SizeType = SizeType.Percent
            btn.TableLayoutPanel1.ColumnStyles(0).Width = cl1width
            btn.TableLayoutPanel1.ColumnStyles(1).SizeType = SizeType.Percent
            btn.TableLayoutPanel1.ColumnStyles(1).Width = cl2width
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
            CircularPictureBox1.Width = 57
            CircularPictureBox1.Height = 57

            PictureBox_Username.Show()
        Else
            CircularPictureBox1.Width = 42
            CircularPictureBox1.Height = 42

            PictureBox_Username.Hide()
        End If
    End Sub



    Private Sub LoadProfile()
        If File.Exists(GetPfpPath()) Then
            CircularPictureBox1.Image = Image.FromFile(GetPfpPath())
        Else
            EmptyToolStripMenuItem_Click(Nothing, Nothing)
            EmptyToolStripMenuItem.Checked = True
        End If

    End Sub

    Private Function GetPfpPath() As String
        Dim PfpPath As String
        PfpPath = "C:\Users\Nischal\Pictures\ShyLily.jpg"
        Return PfpPath
    End Function

    Private Function GetUsername()
        Dim Username As String
        Username = "Meleys"
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

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox_Username.Paint
        Dim text As String = GetUsername()
        Dim font As New Font("Microsoft YaHei", 8.25, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.White)

        ' Draw the text in the center of the PictureBox
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (PictureBox_Username.ClientSize.Width - textSize.Width) / 2
        Dim textY As Single = (PictureBox_Username.ClientSize.Height - textSize.Height) / 2

        ' Draw the text
        e.Graphics.DrawString(text, font, brush, New PointF(textX, textY))
    End Sub

    Private Sub CustomButton1_Click_1(sender As Object, e As EventArgs)
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

    Private Sub ChangeImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeImageToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            CircularPictureBox1.ImageLocation = OpenFileDialog1.FileName
            CircularPictureBox1.BorderStyle = BorderStyle.None

            EmptyToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub EmptyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmptyToolStripMenuItem.Click

        CircularPictureBox1.Image = Nothing
        CircularPictureBox1.BorderStyle = BorderStyle.FixedSingle

        EmptyToolStripMenuItem.Checked = True
    End Sub

    Private Sub CircularPictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CircularPictureBox1.MouseClick
        ContextMenuStrip1.Show(CircularPictureBox1, e.Location)
    End Sub

    Private Sub PictureBox_Username_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox_Username.MouseClick
        ContextMenuStrip2.Show(PictureBox_Username, e.Location)
    End Sub

    Private Sub CustomButton1_Click(sender As Object, e As EventArgs) Handles CustomButton1.Click
        ShowForm(MyDayFormInstance)
    End Sub
End Class