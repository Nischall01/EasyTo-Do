<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class My_Day
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(My_Day))
        Me.MainTlp = New System.Windows.Forms.TableLayoutPanel()
        Me.MainTlp_SubTlpTaskView = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedListBox_MyDay = New System.Windows.Forms.CheckedListBox()
        Me.SubTlpTaskView_SubTlpBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_AddNewTask = New System.Windows.Forms.TextBox()
        Me.SubTlpTaskView_SubTlpTop = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox_PanelIcon = New System.Windows.Forms.PictureBox()
        Me.MainTlp_SubTlpTaskProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_DeleteTask = New System.Windows.Forms.Button()
        Me.Textbox_TaskTitle = New System.Windows.Forms.TextBox()
        Me.Label_ADT = New System.Windows.Forms.Label()
        Me.Button_CloseTaskProperties = New System.Windows.Forms.Button()
        Me.Label_TaskEntryDateTime = New System.Windows.Forms.Label()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Tlp_ImportantButton = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_Important = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReminderTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CustomButton_DueDate = New EasyTo_do.CustomButton_2()
        Me.CustomButton_Repeat = New EasyTo_do.CustomButton_2()
        Me.CustomButton_AddReminder = New EasyTo_do.CustomButton_2()
        Me.MyDay_Label = New System.Windows.Forms.Label()
        Me.Time_Label = New System.Windows.Forms.Label()
        Me.Label_DayDate = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MainTlp.SuspendLayout()
        Me.MainTlp_SubTlpTaskView.SuspendLayout()
        Me.SubTlpTaskView_SubTlpBottom.SuspendLayout()
        Me.SubTlpTaskView_SubTlpTop.SuspendLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTlp_SubTlpTaskProperties.SuspendLayout()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.SuspendLayout()
        Me.Tlp_ImportantButton.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTlp
        '
        Me.MainTlp.BackColor = System.Drawing.Color.White
        Me.MainTlp.ColumnCount = 2
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.MainTlp.Controls.Add(Me.MainTlp_SubTlpTaskView, 0, 0)
        Me.MainTlp.Controls.Add(Me.MainTlp_SubTlpTaskProperties, 1, 0)
        Me.MainTlp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp.Location = New System.Drawing.Point(0, 0)
        Me.MainTlp.Name = "MainTlp"
        Me.MainTlp.RowCount = 1
        Me.MainTlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp.Size = New System.Drawing.Size(784, 461)
        Me.MainTlp.TabIndex = 0
        '
        'MainTlp_SubTlpTaskView
        '
        Me.MainTlp_SubTlpTaskView.BackColor = System.Drawing.Color.Transparent
        Me.MainTlp_SubTlpTaskView.ColumnCount = 1
        Me.MainTlp_SubTlpTaskView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.CheckedListBox_MyDay, 0, 1)
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.SubTlpTaskView_SubTlpBottom, 0, 2)
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.SubTlpTaskView_SubTlpTop, 0, 0)
        Me.MainTlp_SubTlpTaskView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp_SubTlpTaskView.Location = New System.Drawing.Point(0, 0)
        Me.MainTlp_SubTlpTaskView.Margin = New System.Windows.Forms.Padding(0)
        Me.MainTlp_SubTlpTaskView.Name = "MainTlp_SubTlpTaskView"
        Me.MainTlp_SubTlpTaskView.RowCount = 3
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainTlp_SubTlpTaskView.Size = New System.Drawing.Size(588, 461)
        Me.MainTlp_SubTlpTaskView.TabIndex = 6
        '
        'CheckedListBox_MyDay
        '
        Me.CheckedListBox_MyDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CheckedListBox_MyDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox_MyDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox_MyDay.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox_MyDay.ForeColor = System.Drawing.Color.White
        Me.CheckedListBox_MyDay.Location = New System.Drawing.Point(3, 95)
        Me.CheckedListBox_MyDay.Name = "CheckedListBox_MyDay"
        Me.CheckedListBox_MyDay.Size = New System.Drawing.Size(582, 293)
        Me.CheckedListBox_MyDay.TabIndex = 7
        '
        'SubTlpTaskView_SubTlpBottom
        '
        Me.SubTlpTaskView_SubTlpBottom.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpBottom.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTlpTaskView_SubTlpBottom.Controls.Add(Me.TextBox_AddNewTask, 1, 0)
        Me.SubTlpTaskView_SubTlpBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpBottom.Location = New System.Drawing.Point(3, 394)
        Me.SubTlpTaskView_SubTlpBottom.Name = "SubTlpTaskView_SubTlpBottom"
        Me.SubTlpTaskView_SubTlpBottom.RowCount = 1
        Me.SubTlpTaskView_SubTlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpBottom.Size = New System.Drawing.Size(582, 64)
        Me.SubTlpTaskView_SubTlpBottom.TabIndex = 4
        '
        'TextBox_AddNewTask
        '
        Me.TextBox_AddNewTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox_AddNewTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_AddNewTask.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_AddNewTask.Location = New System.Drawing.Point(148, 3)
        Me.TextBox_AddNewTask.Name = "TextBox_AddNewTask"
        Me.TextBox_AddNewTask.Size = New System.Drawing.Size(285, 20)
        Me.TextBox_AddNewTask.TabIndex = 3
        '
        'SubTlpTaskView_SubTlpTop
        '
        Me.SubTlpTaskView_SubTlpTop.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpTop.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.85911!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.2543!))
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.MyDay_Label, 1, 0)
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.PictureBox_PanelIcon, 0, 0)
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.TableLayoutPanel1, 2, 0)
        Me.SubTlpTaskView_SubTlpTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpTop.Location = New System.Drawing.Point(3, 3)
        Me.SubTlpTaskView_SubTlpTop.Name = "SubTlpTaskView_SubTlpTop"
        Me.SubTlpTaskView_SubTlpTop.RowCount = 1
        Me.SubTlpTaskView_SubTlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpTop.Size = New System.Drawing.Size(582, 86)
        Me.SubTlpTaskView_SubTlpTop.TabIndex = 5
        '
        'PictureBox_PanelIcon
        '
        Me.PictureBox_PanelIcon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox_PanelIcon.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_PanelIcon.Enabled = False
        Me.PictureBox_PanelIcon.Image = CType(resources.GetObject("PictureBox_PanelIcon.Image"), System.Drawing.Image)
        Me.PictureBox_PanelIcon.Location = New System.Drawing.Point(35, 23)
        Me.PictureBox_PanelIcon.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_PanelIcon.Name = "PictureBox_PanelIcon"
        Me.PictureBox_PanelIcon.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox_PanelIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_PanelIcon.TabIndex = 1
        Me.PictureBox_PanelIcon.TabStop = False
        '
        'MainTlp_SubTlpTaskProperties
        '
        Me.MainTlp_SubTlpTaskProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MainTlp_SubTlpTaskProperties.ColumnCount = 1
        Me.MainTlp_SubTlpTaskProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Button_DeleteTask, 0, 6)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Textbox_TaskTitle, 0, 1)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Label_ADT, 0, 2)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Button_CloseTaskProperties, 0, 0)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Label_TaskEntryDateTime, 0, 3)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons, 0, 5)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Tlp_ImportantButton, 0, 4)
        Me.MainTlp_SubTlpTaskProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp_SubTlpTaskProperties.Location = New System.Drawing.Point(588, 0)
        Me.MainTlp_SubTlpTaskProperties.Margin = New System.Windows.Forms.Padding(0)
        Me.MainTlp_SubTlpTaskProperties.Name = "MainTlp_SubTlpTaskProperties"
        Me.MainTlp_SubTlpTaskProperties.RowCount = 7
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.65656!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.34343!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainTlp_SubTlpTaskProperties.Size = New System.Drawing.Size(196, 461)
        Me.MainTlp_SubTlpTaskProperties.TabIndex = 2
        '
        'Button_DeleteTask
        '
        Me.Button_DeleteTask.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_DeleteTask.BackColor = System.Drawing.Color.Transparent
        Me.Button_DeleteTask.BackgroundImage = CType(resources.GetObject("Button_DeleteTask.BackgroundImage"), System.Drawing.Image)
        Me.Button_DeleteTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_DeleteTask.FlatAppearance.BorderSize = 0
        Me.Button_DeleteTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button_DeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_DeleteTask.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_DeleteTask.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button_DeleteTask.Location = New System.Drawing.Point(81, 395)
        Me.Button_DeleteTask.Name = "Button_DeleteTask"
        Me.Button_DeleteTask.Padding = New System.Windows.Forms.Padding(3)
        Me.Button_DeleteTask.Size = New System.Drawing.Size(34, 34)
        Me.Button_DeleteTask.TabIndex = 8
        Me.Button_DeleteTask.UseVisualStyleBackColor = False
        '
        'Textbox_TaskTitle
        '
        Me.Textbox_TaskTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.Textbox_TaskTitle.Location = New System.Drawing.Point(3, 41)
        Me.Textbox_TaskTitle.Name = "Textbox_TaskTitle"
        Me.Textbox_TaskTitle.Size = New System.Drawing.Size(190, 20)
        Me.Textbox_TaskTitle.TabIndex = 1
        Me.Textbox_TaskTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_ADT
        '
        Me.Label_ADT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label_ADT.AutoSize = True
        Me.Label_ADT.BackColor = System.Drawing.Color.Transparent
        Me.Label_ADT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ADT.ForeColor = System.Drawing.Color.Snow
        Me.Label_ADT.Location = New System.Drawing.Point(58, 69)
        Me.Label_ADT.Name = "Label_ADT"
        Me.Label_ADT.Size = New System.Drawing.Size(80, 9)
        Me.Label_ADT.TabIndex = 2
        Me.Label_ADT.Text = "Added Date and Time:"
        '
        'Button_CloseTaskProperties
        '
        Me.Button_CloseTaskProperties.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_CloseTaskProperties.BackColor = System.Drawing.Color.Transparent
        Me.Button_CloseTaskProperties.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_CloseTaskProperties.Font = New System.Drawing.Font("Yu Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_CloseTaskProperties.ForeColor = System.Drawing.Color.White
        Me.Button_CloseTaskProperties.Location = New System.Drawing.Point(86, 7)
        Me.Button_CloseTaskProperties.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_CloseTaskProperties.Name = "Button_CloseTaskProperties"
        Me.Button_CloseTaskProperties.Size = New System.Drawing.Size(24, 24)
        Me.Button_CloseTaskProperties.TabIndex = 0
        Me.Button_CloseTaskProperties.Text = "X"
        Me.Button_CloseTaskProperties.UseVisualStyleBackColor = False
        '
        'Label_TaskEntryDateTime
        '
        Me.Label_TaskEntryDateTime.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_TaskEntryDateTime.AutoSize = True
        Me.Label_TaskEntryDateTime.BackColor = System.Drawing.Color.Transparent
        Me.Label_TaskEntryDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TaskEntryDateTime.ForeColor = System.Drawing.Color.Snow
        Me.Label_TaskEntryDateTime.Location = New System.Drawing.Point(93, 83)
        Me.Label_TaskEntryDateTime.Name = "Label_TaskEntryDateTime"
        Me.Label_TaskEntryDateTime.Size = New System.Drawing.Size(9, 12)
        Me.Label_TaskEntryDateTime.TabIndex = 3
        Me.Label_TaskEntryDateTime.Text = "-"
        '
        'SubTlpTaskProperties_SubTlpTaskFeatureButtons
        '
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ColumnCount = 1
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_DueDate, 0, 2)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_Repeat, 0, 1)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_AddReminder, 0, 0)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.RichTextBox1, 0, 3)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Location = New System.Drawing.Point(3, 184)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Name = "SubTlpTaskProperties_SubTlpTaskFeatureButtons"
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowCount = 4
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Size = New System.Drawing.Size(190, 177)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.TabIndex = 10
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(5, 130)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(5, 10, 5, 10)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(180, 37)
        Me.RichTextBox1.TabIndex = 12
        Me.RichTextBox1.Text = ""
        '
        'Tlp_ImportantButton
        '
        Me.Tlp_ImportantButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tlp_ImportantButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp_ImportantButton.ColumnCount = 1
        Me.Tlp_ImportantButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_ImportantButton.Controls.Add(Me.Button_Important, 0, 0)
        Me.Tlp_ImportantButton.Location = New System.Drawing.Point(80, 135)
        Me.Tlp_ImportantButton.Name = "Tlp_ImportantButton"
        Me.Tlp_ImportantButton.RowCount = 1
        Me.Tlp_ImportantButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_ImportantButton.Size = New System.Drawing.Size(36, 36)
        Me.Tlp_ImportantButton.TabIndex = 11
        '
        'Button_Important
        '
        Me.Button_Important.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button_Important.BackgroundImage = CType(resources.GetObject("Button_Important.BackgroundImage"), System.Drawing.Image)
        Me.Button_Important.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Important.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Important.FlatAppearance.BorderSize = 0
        Me.Button_Important.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Important.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Important.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button_Important.Location = New System.Drawing.Point(3, 3)
        Me.Button_Important.Margin = New System.Windows.Forms.Padding(2)
        Me.Button_Important.Name = "Button_Important"
        Me.Button_Important.Size = New System.Drawing.Size(30, 30)
        Me.Button_Important.TabIndex = 8
        Me.Button_Important.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripMenuItem1.Text = "Remove"
        '
        'ReminderTimer
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'CustomButton_DueDate
        '
        Me.CustomButton_DueDate.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_DueDate.ButtonText = "Add Due Date"
        Me.CustomButton_DueDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_DueDate.Icon = CType(resources.GetObject("CustomButton_DueDate.Icon"), System.Drawing.Image)
        Me.CustomButton_DueDate.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_DueDate.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_DueDate.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_DueDate.Location = New System.Drawing.Point(0, 80)
        Me.CustomButton_DueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_DueDate.Name = "CustomButton_DueDate"
        Me.CustomButton_DueDate.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_DueDate.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_DueDate.TabIndex = 11
        Me.CustomButton_DueDate.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_DueDate.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton_Repeat
        '
        Me.CustomButton_Repeat.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_Repeat.ButtonText = "Repeat"
        Me.CustomButton_Repeat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_Repeat.Icon = CType(resources.GetObject("CustomButton_Repeat.Icon"), System.Drawing.Image)
        Me.CustomButton_Repeat.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_Repeat.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_Repeat.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_Repeat.Location = New System.Drawing.Point(0, 40)
        Me.CustomButton_Repeat.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_Repeat.Name = "CustomButton_Repeat"
        Me.CustomButton_Repeat.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_Repeat.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_Repeat.TabIndex = 10
        Me.CustomButton_Repeat.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_Repeat.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton_AddReminder
        '
        Me.CustomButton_AddReminder.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_AddReminder.ButtonText = "Add Reminder"
        Me.CustomButton_AddReminder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_AddReminder.Icon = CType(resources.GetObject("CustomButton_AddReminder.Icon"), System.Drawing.Image)
        Me.CustomButton_AddReminder.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_AddReminder.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_AddReminder.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_AddReminder.Location = New System.Drawing.Point(0, 0)
        Me.CustomButton_AddReminder.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_AddReminder.Name = "CustomButton_AddReminder"
        Me.CustomButton_AddReminder.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_AddReminder.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_AddReminder.TabIndex = 9
        Me.CustomButton_AddReminder.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_AddReminder.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'MyDay_Label
        '
        Me.MyDay_Label.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MyDay_Label.AutoSize = True
        Me.MyDay_Label.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyDay_Label.Location = New System.Drawing.Point(78, 24)
        Me.MyDay_Label.Name = "MyDay_Label"
        Me.MyDay_Label.Size = New System.Drawing.Size(110, 37)
        Me.MyDay_Label.TabIndex = 6
        Me.MyDay_Label.Text = "My Day"
        '
        'Time_Label
        '
        Me.Time_Label.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Time_Label.AutoSize = True
        Me.Time_Label.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Time_Label.Location = New System.Drawing.Point(82, 43)
        Me.Time_Label.Margin = New System.Windows.Forms.Padding(3)
        Me.Time_Label.Name = "Time_Label"
        Me.Time_Label.Size = New System.Drawing.Size(42, 20)
        Me.Time_Label.TabIndex = 5
        Me.Time_Label.Text = "Time"
        '
        'Label_DayDate
        '
        Me.Label_DayDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label_DayDate.AutoSize = True
        Me.Label_DayDate.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DayDate.Location = New System.Drawing.Point(82, 17)
        Me.Label_DayDate.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_DayDate.Name = "Label_DayDate"
        Me.Label_DayDate.Size = New System.Drawing.Size(41, 20)
        Me.Label_DayDate.TabIndex = 4
        Me.Label_DayDate.Text = "Date"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label_DayDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Time_Label, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(373, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(206, 80)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'My_Day
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.MainTlp)
        Me.Name = "My_Day"
        Me.Text = "My Day"
        Me.MainTlp.ResumeLayout(False)
        Me.MainTlp_SubTlpTaskView.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpBottom.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpBottom.PerformLayout()
        Me.SubTlpTaskView_SubTlpTop.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpTop.PerformLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTlp_SubTlpTaskProperties.ResumeLayout(False)
        Me.MainTlp_SubTlpTaskProperties.PerformLayout()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ResumeLayout(False)
        Me.Tlp_ImportantButton.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTlp As TableLayoutPanel
    Friend WithEvents MainTlp_SubTlpTaskProperties As TableLayoutPanel
    Friend WithEvents Button_CloseTaskProperties As Button
    Friend WithEvents Textbox_TaskTitle As TextBox
    Friend WithEvents Label_ADT As Label
    Friend WithEvents MainTlp_SubTlpTaskView As TableLayoutPanel
    Friend WithEvents SubTlpTaskView_SubTlpBottom As TableLayoutPanel
    Friend WithEvents TextBox_AddNewTask As TextBox
    Friend WithEvents SubTlpTaskView_SubTlpTop As TableLayoutPanel
    Friend WithEvents PictureBox_PanelIcon As PictureBox
    Friend WithEvents Label_TaskEntryDateTime As Label
    Friend WithEvents Button_Important As Button
    Friend WithEvents CustomButton_AddReminder As CustomButton_2
    Friend WithEvents SubTlpTaskProperties_SubTlpTaskFeatureButtons As TableLayoutPanel
    Friend WithEvents CustomButton_DueDate As CustomButton_2
    Friend WithEvents CustomButton_Repeat As CustomButton_2
    Friend WithEvents Tlp_ImportantButton As TableLayoutPanel
    Friend WithEvents Button_DeleteTask As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents CheckedListBox_MyDay As CheckedListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReminderTimer As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents MyDay_Label As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label_DayDate As Label
    Friend WithEvents Time_Label As Label
End Class
