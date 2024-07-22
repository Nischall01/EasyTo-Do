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
        Me.CustomButton6 = New EasyTo_do_.CustomButton(Me.components)
        Me.SubSidebarTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CustomButton5 = New EasyTo_do_.CustomButton(Me.components)
        Me.CustomButton1 = New EasyTo_do_.CustomButton(Me.components)
        Me.CustomButton4 = New EasyTo_do_.CustomButton(Me.components)
        Me.CustomButton3 = New EasyTo_do_.CustomButton(Me.components)
        Me.CustomButton2 = New EasyTo_do_.CustomButton(Me.components)
        Me.CircularPictureBox1 = New EasyTo_do_.CircularPictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmptyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox_Username = New System.Windows.Forms.PictureBox()
        Me.Test_BackColors = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MainSidebarTableLayoutPanel.SuspendLayout()
        Me.SubSidebarTableLayoutPanel.SuspendLayout()
        CType(Me.CircularPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox_Username, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 461)
        Me.SplitContainer1.SplitterDistance = 204
        Me.SplitContainer1.TabIndex = 0
        '
        'MainSidebarTableLayoutPanel
        '
        Me.MainSidebarTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MainSidebarTableLayoutPanel.ColumnCount = 1
        Me.MainSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.CustomButton6, 0, 4)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.SubSidebarTableLayoutPanel, 0, 2)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.CircularPictureBox1, 0, 0)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.PictureBox_Username, 0, 1)
        Me.MainSidebarTableLayoutPanel.Controls.Add(Me.Test_BackColors, 0, 3)
        Me.MainSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSidebarTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainSidebarTableLayoutPanel.Name = "MainSidebarTableLayoutPanel"
        Me.MainSidebarTableLayoutPanel.RowCount = 5
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.MainSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainSidebarTableLayoutPanel.Size = New System.Drawing.Size(202, 459)
        Me.MainSidebarTableLayoutPanel.TabIndex = 0
        '
        'CustomButton6
        '
        Me.CustomButton6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CustomButton6.Icon = CType(resources.GetObject("CustomButton6.Icon"), System.Drawing.Image)
        Me.CustomButton6.IconMargin = 12
        Me.CustomButton6.IconSize = New System.Drawing.Size(16, 16)
        Me.CustomButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CustomButton6.Location = New System.Drawing.Point(81, 408)
        Me.CustomButton6.Name = "CustomButton6"
        Me.CustomButton6.Size = New System.Drawing.Size(40, 30)
        Me.CustomButton6.TabIndex = 0
        Me.CustomButton6.UseVisualStyleBackColor = False
        '
        'SubSidebarTableLayoutPanel
        '
        Me.SubSidebarTableLayoutPanel.ColumnCount = 1
        Me.SubSidebarTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton5, 0, 4)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton1, 0, 0)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton4, 0, 3)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton3, 0, 2)
        Me.SubSidebarTableLayoutPanel.Controls.Add(Me.CustomButton2, 0, 1)
        Me.SubSidebarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubSidebarTableLayoutPanel.Location = New System.Drawing.Point(3, 116)
        Me.SubSidebarTableLayoutPanel.Name = "SubSidebarTableLayoutPanel"
        Me.SubSidebarTableLayoutPanel.RowCount = 5
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.20202!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.19192!))
        Me.SubSidebarTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.SubSidebarTableLayoutPanel.Size = New System.Drawing.Size(196, 214)
        Me.SubSidebarTableLayoutPanel.TabIndex = 6
        '
        'CustomButton5
        '
        Me.CustomButton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton5.FlatAppearance.BorderSize = 0
        Me.CustomButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton5.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CustomButton5.ForeColor = System.Drawing.Color.White
        Me.CustomButton5.Icon = CType(resources.GetObject("CustomButton5.Icon"), System.Drawing.Image)
        Me.CustomButton5.IconMargin = 5
        Me.CustomButton5.IconSize = New System.Drawing.Size(30, 30)
        Me.CustomButton5.Location = New System.Drawing.Point(0, 172)
        Me.CustomButton5.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton5.Name = "CustomButton5"
        Me.CustomButton5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CustomButton5.Size = New System.Drawing.Size(196, 42)
        Me.CustomButton5.TabIndex = 5
        Me.CustomButton5.UseVisualStyleBackColor = False
        '
        'CustomButton1
        '
        Me.CustomButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton1.FlatAppearance.BorderSize = 0
        Me.CustomButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton1.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CustomButton1.ForeColor = System.Drawing.Color.White
        Me.CustomButton1.Icon = CType(resources.GetObject("CustomButton1.Icon"), System.Drawing.Image)
        Me.CustomButton1.IconMargin = 5
        Me.CustomButton1.IconSize = New System.Drawing.Size(30, 30)
        Me.CustomButton1.Location = New System.Drawing.Point(0, 0)
        Me.CustomButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CustomButton1.Size = New System.Drawing.Size(196, 43)
        Me.CustomButton1.TabIndex = 1
        Me.CustomButton1.UseVisualStyleBackColor = False
        '
        'CustomButton4
        '
        Me.CustomButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton4.FlatAppearance.BorderSize = 0
        Me.CustomButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton4.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CustomButton4.ForeColor = System.Drawing.Color.White
        Me.CustomButton4.Icon = CType(resources.GetObject("CustomButton4.Icon"), System.Drawing.Image)
        Me.CustomButton4.IconMargin = 5
        Me.CustomButton4.IconSize = New System.Drawing.Size(30, 30)
        Me.CustomButton4.Location = New System.Drawing.Point(0, 129)
        Me.CustomButton4.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton4.Name = "CustomButton4"
        Me.CustomButton4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CustomButton4.Size = New System.Drawing.Size(196, 43)
        Me.CustomButton4.TabIndex = 4
        Me.CustomButton4.UseVisualStyleBackColor = False
        '
        'CustomButton3
        '
        Me.CustomButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton3.FlatAppearance.BorderSize = 0
        Me.CustomButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton3.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CustomButton3.ForeColor = System.Drawing.Color.White
        Me.CustomButton3.Icon = CType(resources.GetObject("CustomButton3.Icon"), System.Drawing.Image)
        Me.CustomButton3.IconMargin = 5
        Me.CustomButton3.IconSize = New System.Drawing.Size(30, 30)
        Me.CustomButton3.Location = New System.Drawing.Point(0, 86)
        Me.CustomButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton3.Name = "CustomButton3"
        Me.CustomButton3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CustomButton3.Size = New System.Drawing.Size(196, 43)
        Me.CustomButton3.TabIndex = 3
        Me.CustomButton3.UseVisualStyleBackColor = False
        '
        'CustomButton2
        '
        Me.CustomButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CustomButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton2.FlatAppearance.BorderSize = 0
        Me.CustomButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton2.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CustomButton2.ForeColor = System.Drawing.Color.White
        Me.CustomButton2.Icon = CType(resources.GetObject("CustomButton2.Icon"), System.Drawing.Image)
        Me.CustomButton2.IconMargin = 5
        Me.CustomButton2.IconSize = New System.Drawing.Size(30, 30)
        Me.CustomButton2.Location = New System.Drawing.Point(0, 43)
        Me.CustomButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton2.Name = "CustomButton2"
        Me.CustomButton2.Size = New System.Drawing.Size(196, 43)
        Me.CustomButton2.TabIndex = 2
        Me.CustomButton2.UseVisualStyleBackColor = False
        '
        'CircularPictureBox1
        '
        Me.CircularPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CircularPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CircularPictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.CircularPictureBox1.Location = New System.Drawing.Point(72, 8)
        Me.CircularPictureBox1.Name = "CircularPictureBox1"
        Me.CircularPictureBox1.Size = New System.Drawing.Size(57, 57)
        Me.CircularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CircularPictureBox1.TabIndex = 0
        Me.CircularPictureBox1.TabStop = False
        Me.CircularPictureBox1.Tag = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeImageToolStripMenuItem, Me.EmptyToolStripMenuItem})
        Me.ContextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 48)
        '
        'ChangeImageToolStripMenuItem
        '
        Me.ChangeImageToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ChangeImageToolStripMenuItem.Name = "ChangeImageToolStripMenuItem"
        Me.ChangeImageToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ChangeImageToolStripMenuItem.Text = "Change Image"
        '
        'EmptyToolStripMenuItem
        '
        Me.EmptyToolStripMenuItem.CheckOnClick = True
        Me.EmptyToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EmptyToolStripMenuItem.Name = "EmptyToolStripMenuItem"
        Me.EmptyToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.EmptyToolStripMenuItem.Text = "Empty"
        '
        'PictureBox_Username
        '
        Me.PictureBox_Username.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox_Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PictureBox_Username.Location = New System.Drawing.Point(51, 71)
        Me.PictureBox_Username.Name = "PictureBox_Username"
        Me.PictureBox_Username.Size = New System.Drawing.Size(100, 24)
        Me.PictureBox_Username.TabIndex = 1
        Me.PictureBox_Username.TabStop = False
        '
        'Test_BackColors
        '
        Me.Test_BackColors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Test_BackColors.Location = New System.Drawing.Point(40, 349)
        Me.Test_BackColors.Name = "Test_BackColors"
        Me.Test_BackColors.Size = New System.Drawing.Size(122, 23)
        Me.Test_BackColors.TabIndex = 7
        Me.Test_BackColors.Text = "Test BackColors"
        Me.Test_BackColors.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " EasyTo-Do"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MainSidebarTableLayoutPanel.ResumeLayout(False)
        Me.SubSidebarTableLayoutPanel.ResumeLayout(False)
        CType(Me.CircularPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox_Username, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MainSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents CircularPictureBox1 As CircularPictureBox
    Friend WithEvents CustomButton2 As CustomButton
    Friend WithEvents CustomButton5 As CustomButton
    Friend WithEvents CustomButton4 As CustomButton
    Friend WithEvents CustomButton1 As CustomButton
    Friend WithEvents CustomButton3 As CustomButton
    Friend WithEvents SubSidebarTableLayoutPanel As TableLayoutPanel
    Friend WithEvents PictureBox_Username As PictureBox
    Friend WithEvents Test_BackColors As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ChangeImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmptyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomButton6 As CustomButton
End Class
