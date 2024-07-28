<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MainSidebarTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SubSidebarTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CustomButton5 = New EasyTo_do.CustomButton_2()
        Me.CustomButton4 = New EasyTo_do.CustomButton_2()
        Me.CustomButton3 = New EasyTo_do.CustomButton_2()
        Me.CustomButton2 = New EasyTo_do.CustomButton_2()
        Me.CustomButton1 = New EasyTo_do.CustomButton_2()
        Me.Pfp_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Pfp_MenuStripItem_ChangePicture = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pfp_MenuStripItem_Empty = New System.Windows.Forms.ToolStripMenuItem()
        Me.Test_BackColors = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Username_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Username_MenuStripItem_ChangeName = New System.Windows.Forms.ToolStripMenuItem()
        Me.Username_MenuStripItem_Empty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Pfp_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Pfp_CircularPictureBox = New EasyTo_do.CircularPictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MainSidebarTableLayoutPanel.SuspendLayout()
        Me.SubSidebarTableLayoutPanel.SuspendLayout()
        Me.Pfp_ContextMenuStrip.SuspendLayout()
        Me.Username_ContextMenuStrip.SuspendLayout()
        CType(Me.Pfp_CircularPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Panel1.Controls.Add(Me.MainSidebarTableLayoutPanel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 511)
        Me.SplitContainer1.SplitterDistance = 204
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'MainSidebarTableLayoutPanel
        '
        Me.MainSidebarTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MainSidebarTableLayoutPanel.ColumnCount = 1
        Me.MainSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.SubSidebarTableLayoutPanel, 0, 2)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Pfp_CircularPictureBox, 0, 0)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Test_BackColors, 0, 3)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Label1, 0, 1)
        Me.MainSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSidebarTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainSidebarTableLayoutPanel.Name = "MainSidebarTableLayoutPanel"
        Me.MainSidebarTableLayoutPanel.RowCount = 5
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainSidebarTableLayoutPanel.Size = New System.Drawing.Size(202, 509)
        Me.MainSidebarTableLayoutPanel.TabIndex = 0
        '
        'SubSidebarTableLayoutPanel
        '
        Me.SubSidebarTableLayoutPanel.ColumnCount = 1
        Me.SubSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton5, 0, 4)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton4, 0, 3)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton3, 0, 2)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton2, 0, 1)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton1, 0, 0)
        Me.SubSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubSidebarTableLayoutPanel.Location = New System.Drawing.Point(3, 129)
        Me.SubSidebarTableLayoutPanel.Name = "SubSidebarTableLayoutPanel"
        Me.SubSidebarTableLayoutPanel.RowCount = 5
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.19192!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.SubSidebarTableLayoutPanel.Size = New System.Drawing.Size(196, 238)
        Me.SubSidebarTableLayoutPanel.TabIndex = 6
        '
        'CustomButton5
        '
        Me.CustomButton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton5.ButtonText = "Tasks"
        Me.CustomButton5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton5.ForeColor = System.Drawing.Color.White
        Me.CustomButton5.Icon = CType(resources.GetObject("CustomButton5.Icon"), System.Drawing.Image)
        Me.CustomButton5.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton5.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton5.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton5.Location = New System.Drawing.Point(0, 192)
        Me.CustomButton5.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton5.Name = "CustomButton5"
        Me.CustomButton5.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton5.Size = New System.Drawing.Size(196, 46)
        Me.CustomButton5.TabIndex = 10
        Me.CustomButton5.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton5.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton4
        '
        Me.CustomButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton4.ButtonText = "Planned"
        Me.CustomButton4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton4.ForeColor = System.Drawing.Color.White
        Me.CustomButton4.Icon = CType(resources.GetObject("CustomButton4.Icon"), System.Drawing.Image)
        Me.CustomButton4.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton4.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton4.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton4.Location = New System.Drawing.Point(0, 144)
        Me.CustomButton4.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton4.Name = "CustomButton4"
        Me.CustomButton4.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton4.Size = New System.Drawing.Size(196, 48)
        Me.CustomButton4.TabIndex = 9
        Me.CustomButton4.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton4.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton3
        '
        Me.CustomButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton3.ButtonText = "Important"
        Me.CustomButton3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton3.ForeColor = System.Drawing.Color.White
        Me.CustomButton3.Icon = CType(resources.GetObject("CustomButton3.Icon"), System.Drawing.Image)
        Me.CustomButton3.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton3.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton3.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton3.Location = New System.Drawing.Point(0, 96)
        Me.CustomButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton3.Name = "CustomButton3"
        Me.CustomButton3.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton3.Size = New System.Drawing.Size(196, 48)
        Me.CustomButton3.TabIndex = 8
        Me.CustomButton3.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton3.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton2
        '
        Me.CustomButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton2.ButtonText = "Daily"
        Me.CustomButton2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CustomButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomButton2.ForeColor = System.Drawing.Color.White
        Me.CustomButton2.Icon = CType(resources.GetObject("CustomButton2.Icon"), System.Drawing.Image)
        Me.CustomButton2.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton2.IconSize = New System.Drawing.Size(20, 20)
        Me.CustomButton2.LabelMargin = New System.Windows.Forms.Padding(0)
        Me.CustomButton2.Location = New System.Drawing.Point(0, 48)
        Me.CustomButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton2.Name = "CustomButton2"
        Me.CustomButton2.PictureBoxSize = New System.Drawing.Size(20, 20)
        Me.CustomButton2.Size = New System.Drawing.Size(196, 48)
        Me.CustomButton2.TabIndex = 7
        Me.CustomButton2.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton2.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton1
        '
        Me.CustomButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
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
        Me.CustomButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.PictureBoxSize = New System.Drawing.Size(23, 23)
        Me.CustomButton1.Size = New System.Drawing.Size(196, 48)
        Me.CustomButton1.TabIndex = 6
        Me.CustomButton1.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton1.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Pfp_ContextMenuStrip
        '
        Me.Pfp_ContextMenuStrip.BackColor = System.Drawing.Color.White
        Me.Pfp_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pfp_MenuStripItem_ChangePicture, Me.Pfp_MenuStripItem_Empty})
        Me.Pfp_ContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.Pfp_ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.Pfp_ContextMenuStrip.Size = New System.Drawing.Size(156, 48)
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
        'Test_BackColors
        '
        Me.Test_BackColors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Test_BackColors.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Test_BackColors.Location = New System.Drawing.Point(40, 389)
        Me.Test_BackColors.Name = "Test_BackColors"
        Me.Test_BackColors.Size = New System.Drawing.Size(122, 23)
        Me.Test_BackColors.TabIndex = 7
        Me.Test_BackColors.Text = "Test BackColors"
        Me.Test_BackColors.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(70, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Username"
        '
        'Username_ContextMenuStrip
        '
        Me.Username_ContextMenuStrip.BackColor = System.Drawing.Color.White
        Me.Username_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Username_MenuStripItem_ChangeName, Me.Username_MenuStripItem_Empty})
        Me.Username_ContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.Username_ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.Username_ContextMenuStrip.Size = New System.Drawing.Size(151, 48)
        '
        'Username_MenuStripItem_ChangeName
        '
        Me.Username_MenuStripItem_ChangeName.Name = "Username_MenuStripItem_ChangeName"
        Me.Username_MenuStripItem_ChangeName.Size = New System.Drawing.Size(150, 22)
        Me.Username_MenuStripItem_ChangeName.Text = "Change Name"
        '
        'Username_MenuStripItem_Empty
        '
        Me.Username_MenuStripItem_Empty.Name = "Username_MenuStripItem_Empty"
        Me.Username_MenuStripItem_Empty.Size = New System.Drawing.Size(150, 22)
        Me.Username_MenuStripItem_Empty.Text = "Empty"
        '
        'Pfp_CircularPictureBox
        '
        Me.Pfp_CircularPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Pfp_CircularPictureBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Pfp_CircularPictureBox.ContextMenuStrip = Me.Pfp_ContextMenuStrip
        Me.Pfp_CircularPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pfp_CircularPictureBox.Location = New System.Drawing.Point(72, 17)
        Me.Pfp_CircularPictureBox.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Pfp_CircularPictureBox.Name = "Pfp_CircularPictureBox"
        Me.Pfp_CircularPictureBox.Size = New System.Drawing.Size(57, 57)
        Me.Pfp_CircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pfp_CircularPictureBox.TabIndex = 0
        Me.Pfp_CircularPictureBox.TabStop = False
        Me.Pfp_CircularPictureBox.Tag = ""
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(784, 511)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(800, 550)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EasyTo-Do"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MainSidebarTableLayoutPanel.ResumeLayout(False)
        Me.MainSidebarTableLayoutPanel.PerformLayout()
        Me.SubSidebarTableLayoutPanel.ResumeLayout(False)
        Me.Pfp_ContextMenuStrip.ResumeLayout(False)
        Me.Username_ContextMenuStrip.ResumeLayout(False)
        CType(Me.Pfp_CircularPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MainSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents Pfp_CircularPictureBox As CircularPictureBox
    Friend WithEvents SubSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents Test_BackColors As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Pfp_OpenFileDialog As OpenFileDialog
    Friend WithEvents Pfp_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents Pfp_MenuStripItem_ChangePicture As ToolStripMenuItem
    Friend WithEvents Pfp_MenuStripItem_Empty As ToolStripMenuItem
    Friend WithEvents Username_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents Username_MenuStripItem_ChangeName As ToolStripMenuItem
    Friend WithEvents Username_MenuStripItem_Empty As ToolStripMenuItem
    Friend WithEvents CustomButton1 As CustomButton_2
    Friend WithEvents CustomButton5 As CustomButton_2
    Friend WithEvents CustomButton4 As CustomButton_2
    Friend WithEvents CustomButton3 As CustomButton_2
    Friend WithEvents CustomButton2 As CustomButton_2
    Friend WithEvents Label1 As Label
End Class
