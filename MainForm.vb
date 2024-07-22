Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainForm
    'Booleans
    Dim IsSidebarExpanded As Boolean

    'Constants
    Const CollapsedSidebarWidth As Integer = 50
    Const ExpandedSidebarWidth As Integer = 200
    Const MaxSidebarWidth As Integer = 350

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
        ExpandSidebar()
        LoadProfile()
        ' Initial Form
        ShowForm(MyDayFormInstance)
    End Sub

    '-----------------------------------------------Methods-----------------------------------------------------'

    ' Toggle the sidebar state between expanded and collapsed
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If IsSidebarExpanded Then
            CollapseSidebar()
        Else
            ExpandSidebar()
        End If
    End Sub

    ' Sidebar collapsed state
    Private Sub CollapseSidebar()
        IsSidebarExpanded = False
        SplitContainer1.SplitterDistance = CollapsedSidebarWidth

        CustomButton1.Text = ""
        CustomButton2.Text = ""
        CustomButton3.Text = ""
        CustomButton4.Text = ""
        CustomButton5.Text = ""

        ShowOrHideUsername()
    End Sub

    ' Sidebar expanded state
    Private Sub ExpandSidebar()
        IsSidebarExpanded = True
        SplitContainer1.SplitterDistance = ExpandedSidebarWidth

        CustomButton1.Text = Button1_Text
        CustomButton2.Text = Button2_Text
        CustomButton3.Text = Button3_Text
        CustomButton4.Text = Button4_Text
        CustomButton5.Text = Button5_Text

        ShowOrHideUsername()
    End Sub

    Private Sub MaxSidebar()
        IsSidebarExpanded = True
        SplitContainer1.SplitterDistance = MaxSidebarWidth

        CustomButton1.Text = Button1_Text
        CustomButton2.Text = Button2_Text
        CustomButton3.Text = Button3_Text
        CustomButton4.Text = Button4_Text
        CustomButton5.Text = Button5_Text

        ShowOrHideUsername()
    End Sub

    Private Sub ShowOrHideUsername()
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

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If IsSidebarExpanded Then
            If e.SplitX < ExpandedSidebarWidth - 50 Then
                CollapseSidebar()
            ElseIf e.SplitX < ExpandedSidebarWidth Then
                ExpandSidebar()
            ElseIf e.SplitX > MaxSidebarWidth Then
                SplitContainer1.SplitterDistance = MaxSidebarWidth
                IsSidebarExpanded = True
                CustomButton1.Text = Button1_Text
                CustomButton2.Text = Button2_Text
                CustomButton3.Text = Button3_Text
                CustomButton4.Text = Button4_Text
                CustomButton5.Text = Button5_Text
            End If
        Else
            If e.SplitX < CollapsedSidebarWidth Then
                CollapseSidebar()
            ElseIf e.SplitX > CollapsedSidebarWidth Then
                If e.SplitX > MaxSidebarWidth Then
                    MaxSidebar()
                ElseIf e.SplitX < MaxSidebarWidth Then
                    ExpandSidebar()
                End If
                IsSidebarExpanded = True
            ElseIf e.SplitX > ExpandedSidebarWidth And e.SplitX < MaxSidebarWidth Then
                SplitContainer1.SplitterDistance = e.SplitX
                IsSidebarExpanded = True
                CustomButton1.Text = Button1_Text
                CustomButton2.Text = Button2_Text
                CustomButton3.Text = Button3_Text
                CustomButton4.Text = Button4_Text
                CustomButton5.Text = Button5_Text
            End If
        End If
    End Sub

    Private Sub LoadProfile()
        'CircularPictureBox1.Image = Image.FromFile(GetPfpPath())
        CircularPictureBox1.ImageLocation = GetPfpPath()
    End Sub

    Private Function GetPfpPath() As String
        Dim PfpPath As String
        PfpPath = "C:\Users\Nischal\Pictures\ShyLily.jpg"
        Return PfpPath
    End Function

    Private Function GetUsername()
        Dim Username As String
        Username = "Nischal"
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

    Private Sub CustomButton1_Click_1(sender As Object, e As EventArgs) Handles CustomButton1.Click
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
        ChangeImageToolStripMenuItem.Checked = False

    End Sub

    'Private Sub CircularPictureBox1_MouseHover(sender As Object, e As EventArgs) Handles CircularPictureBox1.MouseHover
    '    ContextMenuStrip1.Show()
    'End Sub

    'Private Sub CircularPictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles CircularPictureBox1.MouseLeave
    '    ContextMenuStrip1.Hide()
    'End Sub
End Class