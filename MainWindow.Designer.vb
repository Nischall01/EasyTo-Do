<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Pfp_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Pfp_MenuStripItem_ChangePicture = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pfp_MenuStripItem_Empty = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pfp_MenuStripItem_Default = New System.Windows.Forms.ToolStripMenuItem()
        Me.Username_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Username_MenuStripItem_ChangeName = New System.Windows.Forms.ToolStripMenuItem()
        Me.Username_MenuStripItem_Empty = New System.Windows.Forms.ToolStripMenuItem()
        Me.I = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImBatman = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Pfp_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ReminderTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ReminderNotification = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MainSidebarTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SubSidebarTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CustomButton5 = New EasyTo_Do.CustomButton_2()
        Me.CustomButton4 = New EasyTo_Do.CustomButton_2()
        Me.CustomButton3 = New EasyTo_Do.CustomButton_2()
        Me.CustomButton2 = New EasyTo_Do.CustomButton_2()
        Me.CustomButton1 = New EasyTo_Do.CustomButton_2()
        Me.Test_BackColors = New System.Windows.Forms.Button()
        Me.Username_Label = New System.Windows.Forms.Label()
        Me.Settings_Button = New System.Windows.Forms.Button()
        Me.Pfp_CircularPictureBox = New EasyTo_Do.CircularPictureBox()
        Me.Pfp_ContextMenuStrip.SuspendLayout()
        Me.Username_ContextMenuStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MainSidebarTableLayoutPanel.SuspendLayout()
        Me.SubSidebarTableLayoutPanel.SuspendLayout()
        CType(Me.Pfp_CircularPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pfp_ContextMenuStrip
        '
        Me.Pfp_ContextMenuStrip.BackColor = System.Drawing.Color.White
        Me.Pfp_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pfp_MenuStripItem_ChangePicture, Me.Pfp_MenuStripItem_Empty, Me.Pfp_MenuStripItem_Default})
        Me.Pfp_ContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.Pfp_ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.Pfp_ContextMenuStrip.Size = New System.Drawing.Size(156, 70)
        '
        'Pfp_MenuStripItem_ChangePicture
        '
        Me.Pfp_MenuStripItem_ChangePicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Pfp_MenuStripItem_ChangePicture.Name = "Pfp_MenuStripItem_ChangePicture"
        Me.Pfp_MenuStripItem_ChangePicture.Size = New System.Drawing.Size(155, 22)
        Me.Pfp_MenuStripItem_ChangePicture.Text = "Change Picture"
        '
        'Pfp_MenuStripItem_Empty
        '
        Me.Pfp_MenuStripItem_Empty.CheckOnClick = True
        Me.Pfp_MenuStripItem_Empty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Pfp_MenuStripItem_Empty.Name = "Pfp_MenuStripItem_Empty"
        Me.Pfp_MenuStripItem_Empty.Size = New System.Drawing.Size(155, 22)
        Me.Pfp_MenuStripItem_Empty.Text = "Empty"
        '
        'Pfp_MenuStripItem_Default
        '
        Me.Pfp_MenuStripItem_Default.Name = "Pfp_MenuStripItem_Default"
        Me.Pfp_MenuStripItem_Default.Size = New System.Drawing.Size(155, 22)
        Me.Pfp_MenuStripItem_Default.Text = "Default"
        '
        'Username_ContextMenuStrip
        '
        Me.Username_ContextMenuStrip.BackColor = System.Drawing.Color.White
        Me.Username_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Username_MenuStripItem_ChangeName, Me.Username_MenuStripItem_Empty, Me.I})
        Me.Username_ContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.Username_ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.Username_ContextMenuStrip.Size = New System.Drawing.Size(192, 70)
        '
        'Username_MenuStripItem_ChangeName
        '
        Me.Username_MenuStripItem_ChangeName.Name = "Username_MenuStripItem_ChangeName"
        Me.Username_MenuStripItem_ChangeName.Size = New System.Drawing.Size(191, 22)
        Me.Username_MenuStripItem_ChangeName.Text = "Change Name"
        '
        'Username_MenuStripItem_Empty
        '
        Me.Username_MenuStripItem_Empty.Name = "Username_MenuStripItem_Empty"
        Me.Username_MenuStripItem_Empty.Size = New System.Drawing.Size(191, 22)
        Me.Username_MenuStripItem_Empty.Text = "Empty"
        '
        'I
        '
        Me.I.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImBatman})
        Me.I.Name = "I"
        Me.I.Size = New System.Drawing.Size(191, 22)
        Me.I.Text = "What the hell are you?"
        '
        'ImBatman
        '
        Me.ImBatman.Name = "ImBatman"
        Me.ImBatman.Size = New System.Drawing.Size(135, 22)
        Me.ImBatman.Text = "I'm Batman"
        '
        'ReminderTimer
        '
        '
        'ReminderNotification
        '
        Me.ReminderNotification.Text = "ReminderNotification"
        Me.ReminderNotification.Visible = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(900, 32)
        Me.Panel1.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(680, 0)
        Me.Button4.Margin = New System.Windows.Forms.Padding(0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 32)
        Me.Button4.TabIndex = 8
        Me.Button4.TabStop = False
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Info
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "EasyTo-Do"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(750, 0)
        Me.Button3.Margin = New System.Windows.Forms.Padding(0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 32)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(800, 0)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(50, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(850, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Panel1.Controls.Add(Me.MainSidebarTableLayoutPanel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Size = New System.Drawing.Size(900, 543)
        Me.SplitContainer1.SplitterDistance = 233
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 4
        '
        'MainSidebarTableLayoutPanel
        '
        Me.MainSidebarTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.MainSidebarTableLayoutPanel.ColumnCount = 1
        Me.MainSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.SubSidebarTableLayoutPanel, 0, 2)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Test_BackColors, 0, 3)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Username_Label, 0, 1)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Settings_Button, 0, 4)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Pfp_CircularPictureBox, 0, 0)
        Me.MainSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSidebarTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainSidebarTableLayoutPanel.Name = "MainSidebarTableLayoutPanel"
        Me.MainSidebarTableLayoutPanel.RowCount = 5
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35953!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.53831!))
        Me.MainSidebarTableLayoutPanel.Size = New System.Drawing.Size(233, 543)
        Me.MainSidebarTableLayoutPanel.TabIndex = 0
        '
        'SubSidebarTableLayoutPanel
        '
        Me.SubSidebarTableLayoutPanel.BackColor = System.Drawing.Color.Transparent
        Me.SubSidebarTableLayoutPanel.ColumnCount = 1
        Me.SubSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton5, 0, 4)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton4, 0, 3)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton3, 0, 2)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton2, 0, 1)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton1, 0, 0)
        Me.SubSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubSidebarTableLayoutPanel.Location = New System.Drawing.Point(3, 136)
        Me.SubSidebarTableLayoutPanel.Name = "SubSidebarTableLayoutPanel"
        Me.SubSidebarTableLayoutPanel.RowCount = 5
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.19192!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.SubSidebarTableLayoutPanel.Size = New System.Drawing.Size(227, 252)
        Me.SubSidebarTableLayoutPanel.TabIndex = 6
        '
        'CustomButton5
        '
        Me.CustomButton5.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton5.ButtonText = "Tasks"
        Me.CustomButton5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton5.ForeColor = System.Drawing.Color.White
        Me.CustomButton5.Icon = CType(resources.GetObject("CustomButton5.Icon"), System.Drawing.Image)
        Me.CustomButton5.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton5.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton5.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton5.Location = New System.Drawing.Point(0, 200)
        Me.CustomButton5.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton5.Name = "CustomButton5"
        Me.CustomButton5.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton5.Size = New System.Drawing.Size(227, 52)
        Me.CustomButton5.TabIndex = 10
        Me.CustomButton5.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton5.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton4
        '
        Me.CustomButton4.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton4.ButtonText = "Planned"
        Me.CustomButton4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton4.ForeColor = System.Drawing.Color.White
        Me.CustomButton4.Icon = CType(resources.GetObject("CustomButton4.Icon"), System.Drawing.Image)
        Me.CustomButton4.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton4.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton4.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton4.Location = New System.Drawing.Point(0, 150)
        Me.CustomButton4.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.CustomButton4.Name = "CustomButton4"
        Me.CustomButton4.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton4.Size = New System.Drawing.Size(227, 48)
        Me.CustomButton4.TabIndex = 9
        Me.CustomButton4.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton4.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton3
        '
        Me.CustomButton3.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton3.ButtonText = "Important"
        Me.CustomButton3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton3.ForeColor = System.Drawing.Color.White
        Me.CustomButton3.Icon = CType(resources.GetObject("CustomButton3.Icon"), System.Drawing.Image)
        Me.CustomButton3.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton3.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton3.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton3.Location = New System.Drawing.Point(0, 100)
        Me.CustomButton3.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.CustomButton3.Name = "CustomButton3"
        Me.CustomButton3.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton3.Size = New System.Drawing.Size(227, 48)
        Me.CustomButton3.TabIndex = 8
        Me.CustomButton3.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton3.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton2
        '
        Me.CustomButton2.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton2.ButtonText = "Repeated"
        Me.CustomButton2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton2.ForeColor = System.Drawing.Color.White
        Me.CustomButton2.Icon = CType(resources.GetObject("CustomButton2.Icon"), System.Drawing.Image)
        Me.CustomButton2.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton2.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton2.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton2.Location = New System.Drawing.Point(0, 50)
        Me.CustomButton2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.CustomButton2.Name = "CustomButton2"
        Me.CustomButton2.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton2.Size = New System.Drawing.Size(227, 48)
        Me.CustomButton2.TabIndex = 7
        Me.CustomButton2.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton2.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton1
        '
        Me.CustomButton1.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton1.ButtonText = "My Day"
        Me.CustomButton1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton1.ForeColor = System.Drawing.Color.White
        Me.CustomButton1.Icon = CType(resources.GetObject("CustomButton1.Icon"), System.Drawing.Image)
        Me.CustomButton1.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton1.IconSize = New System.Drawing.Size(23, 23)
        Me.CustomButton1.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton1.Location = New System.Drawing.Point(0, 0)
        Me.CustomButton1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.PictureBoxSize = New System.Drawing.Size(23, 23)
        Me.CustomButton1.Size = New System.Drawing.Size(227, 48)
        Me.CustomButton1.TabIndex = 6
        Me.CustomButton1.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton1.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Test_BackColors
        '
        Me.Test_BackColors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Test_BackColors.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Test_BackColors.Location = New System.Drawing.Point(55, 415)
        Me.Test_BackColors.Name = "Test_BackColors"
        Me.Test_BackColors.Size = New System.Drawing.Size(122, 23)
        Me.Test_BackColors.TabIndex = 7
        Me.Test_BackColors.Text = "Test BackColors"
        Me.Test_BackColors.UseVisualStyleBackColor = True
        '
        'Username_Label
        '
        Me.Username_Label.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Username_Label.AutoSize = True
        Me.Username_Label.BackColor = System.Drawing.Color.Transparent
        Me.Username_Label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Username_Label.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username_Label.ForeColor = System.Drawing.Color.White
        Me.Username_Label.Location = New System.Drawing.Point(85, 83)
        Me.Username_Label.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Username_Label.Name = "Username_Label"
        Me.Username_Label.Size = New System.Drawing.Size(62, 16)
        Me.Username_Label.TabIndex = 8
        Me.Username_Label.Text = "Username"
        '
        'Settings_Button
        '
        Me.Settings_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Settings_Button.BackColor = System.Drawing.Color.Transparent
        Me.Settings_Button.BackgroundImage = CType(resources.GetObject("Settings_Button.BackgroundImage"), System.Drawing.Image)
        Me.Settings_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Settings_Button.FlatAppearance.BorderSize = 0
        Me.Settings_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Settings_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Settings_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Settings_Button.Location = New System.Drawing.Point(105, 491)
        Me.Settings_Button.Name = "Settings_Button"
        Me.Settings_Button.Size = New System.Drawing.Size(23, 23)
        Me.Settings_Button.TabIndex = 9
        Me.Settings_Button.UseVisualStyleBackColor = False
        '
        'Pfp_CircularPictureBox
        '
        Me.Pfp_CircularPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Pfp_CircularPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.Pfp_CircularPictureBox.ContextMenuStrip = Me.Pfp_ContextMenuStrip
        Me.Pfp_CircularPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pfp_CircularPictureBox.Location = New System.Drawing.Point(88, 21)
        Me.Pfp_CircularPictureBox.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Pfp_CircularPictureBox.Name = "Pfp_CircularPictureBox"
        Me.Pfp_CircularPictureBox.Size = New System.Drawing.Size(57, 57)
        Me.Pfp_CircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pfp_CircularPictureBox.TabIndex = 0
        Me.Pfp_CircularPictureBox.TabStop = False
        Me.Pfp_CircularPictureBox.Tag = ""
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(900, 575)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(900, 575)
        Me.Name = "MainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EasyTo-Do"
        Me.Pfp_ContextMenuStrip.ResumeLayout(False)
        Me.Username_ContextMenuStrip.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MainSidebarTableLayoutPanel.ResumeLayout(False)
        Me.MainSidebarTableLayoutPanel.PerformLayout()
        Me.SubSidebarTableLayoutPanel.ResumeLayout(False)
        CType(Me.Pfp_CircularPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Pfp_OpenFileDialog As OpenFileDialog
    Friend WithEvents Pfp_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents Pfp_MenuStripItem_ChangePicture As ToolStripMenuItem
    Friend WithEvents Pfp_MenuStripItem_Empty As ToolStripMenuItem
    Friend WithEvents Username_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents Username_MenuStripItem_ChangeName As ToolStripMenuItem
    Friend WithEvents Username_MenuStripItem_Empty As ToolStripMenuItem
    Friend WithEvents Pfp_MenuStripItem_Default As ToolStripMenuItem
    Friend WithEvents I As ToolStripMenuItem
    Friend WithEvents ImBatman As ToolStripMenuItem
    Friend WithEvents ReminderTimer As Timer
    Friend WithEvents ReminderNotification As NotifyIcon
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MainSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents SubSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents CustomButton5 As CustomButton_2
    Friend WithEvents CustomButton4 As CustomButton_2
    Friend WithEvents CustomButton3 As CustomButton_2
    Friend WithEvents CustomButton2 As CustomButton_2
    Friend WithEvents CustomButton1 As CustomButton_2
    Friend WithEvents Test_BackColors As Button
    Friend WithEvents Username_Label As Label
    Friend WithEvents Settings_Button As Button
    Friend WithEvents Pfp_CircularPictureBox As CircularPictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
End Class
