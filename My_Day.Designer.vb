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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(My_Day))
        Me.MainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedListBox_MyDay = New System.Windows.Forms.CheckedListBox()
        Me.SubTableLayoutPanel_Bottom = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_AddNewTask = New System.Windows.Forms.TextBox()
        Me.SubTablelayoutPanel_Top = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox_PanelIcon = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_MyDay = New System.Windows.Forms.Label()
        Me.SubTableLayoutPanel_TaskProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_DeleteTask = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CustomButton_22 = New EasyTo_do_.CustomButton_2()
        Me.CustomButton_21 = New EasyTo_do_.CustomButton_2()
        Me.CustomButton_24 = New EasyTo_do_.CustomButton_2()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MainTableLayoutPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SubTableLayoutPanel_Bottom.SuspendLayout()
        Me.SubTablelayoutPanel_Top.SuspendLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubTableLayoutPanel_TaskProperties.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTableLayoutPanel
        '
        Me.MainTableLayoutPanel.ColumnCount = 2
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.MainTableLayoutPanel.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_TaskProperties, 1, 0)
        Me.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainTableLayoutPanel.Name = "MainTableLayoutPanel"
        Me.MainTableLayoutPanel.RowCount = 1
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTableLayoutPanel.Size = New System.Drawing.Size(784, 461)
        Me.MainTableLayoutPanel.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBox_MyDay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SubTableLayoutPanel_Bottom, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.SubTablelayoutPanel_Top, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(588, 461)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'CheckedListBox_MyDay
        '
        Me.CheckedListBox_MyDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CheckedListBox_MyDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox_MyDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox_MyDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox_MyDay.ForeColor = System.Drawing.Color.White
        Me.CheckedListBox_MyDay.Location = New System.Drawing.Point(3, 92)
        Me.CheckedListBox_MyDay.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CheckedListBox_MyDay.Name = "CheckedListBox_MyDay"
        Me.CheckedListBox_MyDay.Size = New System.Drawing.Size(582, 299)
        Me.CheckedListBox_MyDay.TabIndex = 6
        Me.CheckedListBox_MyDay.ThreeDCheckBoxes = True
        '
        'SubTableLayoutPanel_Bottom
        '
        Me.SubTableLayoutPanel_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.SubTableLayoutPanel_Bottom.ColumnCount = 3
        Me.SubTableLayoutPanel_Bottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTableLayoutPanel_Bottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTableLayoutPanel_Bottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTableLayoutPanel_Bottom.Controls.Add(Me.TextBox_AddNewTask, 1, 0)
        Me.SubTableLayoutPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTableLayoutPanel_Bottom.Location = New System.Drawing.Point(3, 394)
        Me.SubTableLayoutPanel_Bottom.Name = "SubTableLayoutPanel_Bottom"
        Me.SubTableLayoutPanel_Bottom.RowCount = 1
        Me.SubTableLayoutPanel_Bottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTableLayoutPanel_Bottom.Size = New System.Drawing.Size(582, 64)
        Me.SubTableLayoutPanel_Bottom.TabIndex = 4
        '
        'TextBox_AddNewTask
        '
        Me.TextBox_AddNewTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox_AddNewTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_AddNewTask.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox_AddNewTask.Location = New System.Drawing.Point(148, 3)
        Me.TextBox_AddNewTask.Name = "TextBox_AddNewTask"
        Me.TextBox_AddNewTask.Size = New System.Drawing.Size(285, 20)
        Me.TextBox_AddNewTask.TabIndex = 3
        '
        'SubTablelayoutPanel_Top
        '
        Me.SubTablelayoutPanel_Top.BackColor = System.Drawing.Color.Transparent
        Me.SubTablelayoutPanel_Top.ColumnCount = 3
        Me.SubTablelayoutPanel_Top.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.SubTablelayoutPanel_Top.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.SubTablelayoutPanel_Top.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.0!))
        Me.SubTablelayoutPanel_Top.Controls.Add(Me.PictureBox_PanelIcon, 0, 0)
        Me.SubTablelayoutPanel_Top.Controls.Add(Me.Label3, 2, 0)
        Me.SubTablelayoutPanel_Top.Controls.Add(Me.Label_MyDay, 1, 0)
        Me.SubTablelayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTablelayoutPanel_Top.Location = New System.Drawing.Point(3, 3)
        Me.SubTablelayoutPanel_Top.Name = "SubTablelayoutPanel_Top"
        Me.SubTablelayoutPanel_Top.RowCount = 1
        Me.SubTablelayoutPanel_Top.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTablelayoutPanel_Top.Size = New System.Drawing.Size(582, 86)
        Me.SubTablelayoutPanel_Top.TabIndex = 5
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
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(427, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DateTime"
        '
        'Label_MyDay
        '
        Me.Label_MyDay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label_MyDay.AutoSize = True
        Me.Label_MyDay.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MyDay.Location = New System.Drawing.Point(78, 24)
        Me.Label_MyDay.Name = "Label_MyDay"
        Me.Label_MyDay.Size = New System.Drawing.Size(110, 37)
        Me.Label_MyDay.TabIndex = 4
        Me.Label_MyDay.Text = "My Day"
        '
        'SubTableLayoutPanel_TaskProperties
        '
        Me.SubTableLayoutPanel_TaskProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.SubTableLayoutPanel_TaskProperties.ColumnCount = 1
        Me.SubTableLayoutPanel_TaskProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Button_DeleteTask, 0, 6)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.TextBox1, 0, 1)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Label1, 0, 2)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Button2, 0, 0)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Label2, 0, 3)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.TableLayoutPanel3, 0, 4)
        Me.SubTableLayoutPanel_TaskProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTableLayoutPanel_TaskProperties.Location = New System.Drawing.Point(588, 0)
        Me.SubTableLayoutPanel_TaskProperties.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTableLayoutPanel_TaskProperties.Name = "SubTableLayoutPanel_TaskProperties"
        Me.SubTableLayoutPanel_TaskProperties.RowCount = 7
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.65656!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.34343!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.SubTableLayoutPanel_TaskProperties.Size = New System.Drawing.Size(196, 461)
        Me.SubTableLayoutPanel_TaskProperties.TabIndex = 2
        '
        'Button_DeleteTask
        '
        Me.Button_DeleteTask.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_DeleteTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
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
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Location = New System.Drawing.Point(3, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(190, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(58, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 9)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Added Date and Time:"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Yu Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(86, 7)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Snow
        Me.Label2.Location = New System.Drawing.Point(93, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(9, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "-"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CustomButton_22, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CustomButton_21, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CustomButton_24, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 184)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(190, 177)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'CustomButton_22
        '
        Me.CustomButton_22.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_22.ButtonText = "Add Due Date"
        Me.CustomButton_22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_22.Icon = CType(resources.GetObject("CustomButton_22.Icon"), System.Drawing.Image)
        Me.CustomButton_22.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_22.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_22.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_22.Location = New System.Drawing.Point(0, 80)
        Me.CustomButton_22.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_22.Name = "CustomButton_22"
        Me.CustomButton_22.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_22.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_22.TabIndex = 11
        Me.CustomButton_22.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_22.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton_21
        '
        Me.CustomButton_21.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_21.ButtonText = "Repeat"
        Me.CustomButton_21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_21.Icon = CType(resources.GetObject("CustomButton_21.Icon"), System.Drawing.Image)
        Me.CustomButton_21.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_21.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_21.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_21.Location = New System.Drawing.Point(0, 40)
        Me.CustomButton_21.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_21.Name = "CustomButton_21"
        Me.CustomButton_21.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_21.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_21.TabIndex = 10
        Me.CustomButton_21.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_21.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton_24
        '
        Me.CustomButton_24.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_24.ButtonText = "Add Reminder"
        Me.CustomButton_24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_24.Icon = CType(resources.GetObject("CustomButton_24.Icon"), System.Drawing.Image)
        Me.CustomButton_24.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_24.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_24.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_24.Location = New System.Drawing.Point(0, 0)
        Me.CustomButton_24.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_24.Name = "CustomButton_24"
        Me.CustomButton_24.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_24.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_24.TabIndex = 9
        Me.CustomButton_24.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_24.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(79, 135)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(38, 37)
        Me.TableLayoutPanel3.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(4, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 29)
        Me.Button1.TabIndex = 8
        Me.Button1.UseVisualStyleBackColor = False
        '
        'My_Day
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.MainTableLayoutPanel)
        Me.Name = "My_Day"
        Me.Text = "My Day"
        Me.MainTableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SubTableLayoutPanel_Bottom.ResumeLayout(False)
        Me.SubTableLayoutPanel_Bottom.PerformLayout()
        Me.SubTablelayoutPanel_Top.ResumeLayout(False)
        Me.SubTablelayoutPanel_Top.PerformLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubTableLayoutPanel_TaskProperties.ResumeLayout(False)
        Me.SubTableLayoutPanel_TaskProperties.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTableLayoutPanel As TableLayoutPanel
    Friend WithEvents SubTableLayoutPanel_TaskProperties As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CheckedListBox_MyDay As CheckedListBox
    Friend WithEvents SubTableLayoutPanel_Bottom As TableLayoutPanel
    Friend WithEvents TextBox_AddNewTask As TextBox
    Friend WithEvents SubTablelayoutPanel_Top As TableLayoutPanel
    Friend WithEvents PictureBox_PanelIcon As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label_MyDay As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CustomButton_24 As CustomButton_2
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents CustomButton_22 As CustomButton_2
    Friend WithEvents CustomButton_21 As CustomButton_2
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Button_DeleteTask As Button
End Class
