﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tasks_View
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tasks_View))
        Me.MainTlp = New System.Windows.Forms.TableLayoutPanel()
        Me.MainTlp_SubTlpTaskProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.TaskTitle_TextBox = New System.Windows.Forms.TextBox()
        Me.Button_DeleteTask = New System.Windows.Forms.Button()
        Me.Label_ADT = New System.Windows.Forms.Label()
        Me.Button_CloseTaskProperties = New System.Windows.Forms.Button()
        Me.Label_TaskEntryDateTime = New System.Windows.Forms.Label()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.CustomButton_AddDueDate = New EasyTo_Do.CustomButton_2()
        Me.CustomButton_Repeat = New EasyTo_Do.CustomButton_2()
        Me.CustomButton_AddReminder = New EasyTo_Do.CustomButton_2()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TaskDescription_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.Tlp_ImportantButton = New System.Windows.Forms.TableLayoutPanel()
        Me.Important_Button = New System.Windows.Forms.Button()
        Me.MainTlp_SubTlpTaskView = New System.Windows.Forms.TableLayoutPanel()
        Me.SubTlpTaskView_SubTlpBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.AddNewTask_TextBox = New System.Windows.Forms.TextBox()
        Me.SubTlpTaskView_SubTlpTop = New System.Windows.Forms.TableLayoutPanel()
        Me.Tasks_Label = New System.Windows.Forms.Label()
        Me.PictureBox_PanelIcon = New System.Windows.Forms.PictureBox()
        Me.SubTlpTaskView_SubTlpMiddle = New System.Windows.Forms.TableLayoutPanel()
        Me.Tasks_CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.MainTlp.SuspendLayout()
        Me.MainTlp_SubTlpTaskProperties.SuspendLayout()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tlp_ImportantButton.SuspendLayout()
        Me.MainTlp_SubTlpTaskView.SuspendLayout()
        Me.SubTlpTaskView_SubTlpBottom.SuspendLayout()
        Me.SubTlpTaskView_SubTlpTop.SuspendLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubTlpTaskView_SubTlpMiddle.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTlp
        '
        Me.MainTlp.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.MainTlp.ColumnCount = 2
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.MainTlp.Controls.Add(Me.MainTlp_SubTlpTaskProperties, 1, 0)
        Me.MainTlp.Controls.Add(Me.MainTlp_SubTlpTaskView, 0, 0)
        Me.MainTlp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp.Location = New System.Drawing.Point(0, 0)
        Me.MainTlp.Name = "MainTlp"
        Me.MainTlp.RowCount = 1
        Me.MainTlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp.Size = New System.Drawing.Size(784, 461)
        Me.MainTlp.TabIndex = 1
        '
        'MainTlp_SubTlpTaskProperties
        '
        Me.MainTlp_SubTlpTaskProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MainTlp_SubTlpTaskProperties.ColumnCount = 1
        Me.MainTlp_SubTlpTaskProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.TaskTitle_TextBox, 0, 1)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Button_DeleteTask, 0, 6)
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
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.65657!))
        Me.MainTlp_SubTlpTaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.34343!))
        Me.MainTlp_SubTlpTaskProperties.Size = New System.Drawing.Size(196, 461)
        Me.MainTlp_SubTlpTaskProperties.TabIndex = 4
        '
        'TaskTitle_TextBox
        '
        Me.TaskTitle_TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TaskTitle_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TaskTitle_TextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskTitle_TextBox.ForeColor = System.Drawing.Color.White
        Me.TaskTitle_TextBox.Location = New System.Drawing.Point(0, 38)
        Me.TaskTitle_TextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.TaskTitle_TextBox.Name = "TaskTitle_TextBox"
        Me.TaskTitle_TextBox.Size = New System.Drawing.Size(196, 20)
        Me.TaskTitle_TextBox.TabIndex = 12
        Me.TaskTitle_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Button_DeleteTask.Location = New System.Drawing.Point(81, 394)
        Me.Button_DeleteTask.Name = "Button_DeleteTask"
        Me.Button_DeleteTask.Padding = New System.Windows.Forms.Padding(3)
        Me.Button_DeleteTask.Size = New System.Drawing.Size(34, 34)
        Me.Button_DeleteTask.TabIndex = 8
        Me.Button_DeleteTask.UseVisualStyleBackColor = False
        '
        'Label_ADT
        '
        Me.Label_ADT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label_ADT.AutoSize = True
        Me.Label_ADT.BackColor = System.Drawing.Color.Transparent
        Me.Label_ADT.Font = New System.Drawing.Font("Leelawadee UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ADT.ForeColor = System.Drawing.Color.Snow
        Me.Label_ADT.Location = New System.Drawing.Point(55, 65)
        Me.Label_ADT.Name = "Label_ADT"
        Me.Label_ADT.Size = New System.Drawing.Size(85, 11)
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
        Me.Label_TaskEntryDateTime.Font = New System.Drawing.Font("Microsoft YaHei", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TaskEntryDateTime.ForeColor = System.Drawing.Color.Snow
        Me.Label_TaskEntryDateTime.Location = New System.Drawing.Point(92, 84)
        Me.Label_TaskEntryDateTime.Name = "Label_TaskEntryDateTime"
        Me.Label_TaskEntryDateTime.Size = New System.Drawing.Size(11, 14)
        Me.Label_TaskEntryDateTime.TabIndex = 3
        Me.Label_TaskEntryDateTime.Text = "-"
        '
        'SubTlpTaskProperties_SubTlpTaskFeatureButtons
        '
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ColumnCount = 1
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_AddDueDate, 0, 2)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_Repeat, 0, 1)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.CustomButton_AddReminder, 0, 0)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Controls.Add(Me.Panel1, 0, 3)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Location = New System.Drawing.Point(3, 178)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Name = "SubTlpTaskProperties_SubTlpTaskFeatureButtons"
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowCount = 4
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Size = New System.Drawing.Size(190, 181)
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.TabIndex = 10
        '
        'CustomButton_AddDueDate
        '
        Me.CustomButton_AddDueDate.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_AddDueDate.ButtonText = "Add Due Date"
        Me.CustomButton_AddDueDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_AddDueDate.ForeColor = System.Drawing.Color.White
        Me.CustomButton_AddDueDate.Icon = CType(resources.GetObject("CustomButton_AddDueDate.Icon"), System.Drawing.Image)
        Me.CustomButton_AddDueDate.IconAnchor = System.Windows.Forms.AnchorStyles.None
        Me.CustomButton_AddDueDate.IconSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_AddDueDate.LabelMargin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CustomButton_AddDueDate.Location = New System.Drawing.Point(0, 80)
        Me.CustomButton_AddDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomButton_AddDueDate.Name = "CustomButton_AddDueDate"
        Me.CustomButton_AddDueDate.PictureBoxSize = New System.Drawing.Size(17, 17)
        Me.CustomButton_AddDueDate.Size = New System.Drawing.Size(190, 40)
        Me.CustomButton_AddDueDate.TabIndex = 11
        Me.CustomButton_AddDueDate.TextAnchor = System.Windows.Forms.AnchorStyles.Left
        Me.CustomButton_AddDueDate.TextFont = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'CustomButton_Repeat
        '
        Me.CustomButton_Repeat.BackColor = System.Drawing.Color.Transparent
        Me.CustomButton_Repeat.ButtonText = "Repeat"
        Me.CustomButton_Repeat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomButton_Repeat.ForeColor = System.Drawing.Color.White
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
        Me.CustomButton_AddReminder.ForeColor = System.Drawing.Color.Transparent
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TaskDescription_RichTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 123)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 55)
        Me.Panel1.TabIndex = 12
        '
        'TaskDescription_RichTextBox
        '
        Me.TaskDescription_RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TaskDescription_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TaskDescription_RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskDescription_RichTextBox.ForeColor = System.Drawing.Color.Pink
        Me.TaskDescription_RichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.TaskDescription_RichTextBox.Margin = New System.Windows.Forms.Padding(5, 10, 5, 10)
        Me.TaskDescription_RichTextBox.Name = "TaskDescription_RichTextBox"
        Me.TaskDescription_RichTextBox.Size = New System.Drawing.Size(182, 53)
        Me.TaskDescription_RichTextBox.TabIndex = 13
        Me.TaskDescription_RichTextBox.Text = ""
        '
        'Tlp_ImportantButton
        '
        Me.Tlp_ImportantButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tlp_ImportantButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Tlp_ImportantButton.ColumnCount = 1
        Me.Tlp_ImportantButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_ImportantButton.Controls.Add(Me.Important_Button, 0, 0)
        Me.Tlp_ImportantButton.Location = New System.Drawing.Point(80, 129)
        Me.Tlp_ImportantButton.Name = "Tlp_ImportantButton"
        Me.Tlp_ImportantButton.RowCount = 1
        Me.Tlp_ImportantButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_ImportantButton.Size = New System.Drawing.Size(36, 36)
        Me.Tlp_ImportantButton.TabIndex = 11
        '
        'Important_Button
        '
        Me.Important_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Important_Button.BackgroundImage = CType(resources.GetObject("Important_Button.BackgroundImage"), System.Drawing.Image)
        Me.Important_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Important_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Important_Button.FlatAppearance.BorderSize = 0
        Me.Important_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Important_Button.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Important_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Important_Button.Location = New System.Drawing.Point(3, 3)
        Me.Important_Button.Margin = New System.Windows.Forms.Padding(2)
        Me.Important_Button.Name = "Important_Button"
        Me.Important_Button.Size = New System.Drawing.Size(30, 30)
        Me.Important_Button.TabIndex = 8
        Me.Important_Button.UseVisualStyleBackColor = False
        '
        'MainTlp_SubTlpTaskView
        '
        Me.MainTlp_SubTlpTaskView.ColumnCount = 1
        Me.MainTlp_SubTlpTaskView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.SubTlpTaskView_SubTlpBottom, 0, 2)
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.SubTlpTaskView_SubTlpTop, 0, 0)
        Me.MainTlp_SubTlpTaskView.Controls.Add(Me.SubTlpTaskView_SubTlpMiddle, 0, 1)
        Me.MainTlp_SubTlpTaskView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp_SubTlpTaskView.Location = New System.Drawing.Point(0, 0)
        Me.MainTlp_SubTlpTaskView.Margin = New System.Windows.Forms.Padding(0)
        Me.MainTlp_SubTlpTaskView.Name = "MainTlp_SubTlpTaskView"
        Me.MainTlp_SubTlpTaskView.RowCount = 3
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainTlp_SubTlpTaskView.Size = New System.Drawing.Size(588, 461)
        Me.MainTlp_SubTlpTaskView.TabIndex = 1
        '
        'SubTlpTaskView_SubTlpBottom
        '
        Me.SubTlpTaskView_SubTlpBottom.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpBottom.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SubTlpTaskView_SubTlpBottom.Controls.Add(Me.AddNewTask_TextBox, 1, 0)
        Me.SubTlpTaskView_SubTlpBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpBottom.Location = New System.Drawing.Point(3, 394)
        Me.SubTlpTaskView_SubTlpBottom.Name = "SubTlpTaskView_SubTlpBottom"
        Me.SubTlpTaskView_SubTlpBottom.RowCount = 1
        Me.SubTlpTaskView_SubTlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpBottom.Size = New System.Drawing.Size(582, 64)
        Me.SubTlpTaskView_SubTlpBottom.TabIndex = 10
        '
        'AddNewTask_TextBox
        '
        Me.AddNewTask_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.AddNewTask_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.AddNewTask_TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.AddNewTask_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddNewTask_TextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddNewTask_TextBox.ForeColor = System.Drawing.Color.White
        Me.AddNewTask_TextBox.Location = New System.Drawing.Point(148, 3)
        Me.AddNewTask_TextBox.Name = "AddNewTask_TextBox"
        Me.AddNewTask_TextBox.Size = New System.Drawing.Size(285, 20)
        Me.AddNewTask_TextBox.TabIndex = 3
        '
        'SubTlpTaskView_SubTlpTop
        '
        Me.SubTlpTaskView_SubTlpTop.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpTop.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.85911!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.2543!))
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.Tasks_Label, 1, 0)
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.PictureBox_PanelIcon, 0, 0)
        Me.SubTlpTaskView_SubTlpTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpTop.Location = New System.Drawing.Point(3, 3)
        Me.SubTlpTaskView_SubTlpTop.Name = "SubTlpTaskView_SubTlpTop"
        Me.SubTlpTaskView_SubTlpTop.RowCount = 1
        Me.SubTlpTaskView_SubTlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpTop.Size = New System.Drawing.Size(582, 86)
        Me.SubTlpTaskView_SubTlpTop.TabIndex = 6
        '
        'Tasks_Label
        '
        Me.Tasks_Label.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tasks_Label.AutoSize = True
        Me.Tasks_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tasks_Label.ForeColor = System.Drawing.Color.White
        Me.Tasks_Label.Location = New System.Drawing.Point(78, 25)
        Me.Tasks_Label.Name = "Tasks_Label"
        Me.Tasks_Label.Size = New System.Drawing.Size(90, 36)
        Me.Tasks_Label.TabIndex = 6
        Me.Tasks_Label.Text = "Tasks"
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
        'SubTlpTaskView_SubTlpMiddle
        '
        Me.SubTlpTaskView_SubTlpMiddle.ColumnCount = 1
        Me.SubTlpTaskView_SubTlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpMiddle.Controls.Add(Me.Tasks_CheckedListBox, 0, 0)
        Me.SubTlpTaskView_SubTlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpMiddle.Location = New System.Drawing.Point(6, 92)
        Me.SubTlpTaskView_SubTlpMiddle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.SubTlpTaskView_SubTlpMiddle.Name = "SubTlpTaskView_SubTlpMiddle"
        Me.SubTlpTaskView_SubTlpMiddle.RowCount = 1
        Me.SubTlpTaskView_SubTlpMiddle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpMiddle.Size = New System.Drawing.Size(576, 299)
        Me.SubTlpTaskView_SubTlpMiddle.TabIndex = 11
        '
        'Tasks_CheckedListBox
        '
        Me.Tasks_CheckedListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Tasks_CheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Tasks_CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tasks_CheckedListBox.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tasks_CheckedListBox.ForeColor = System.Drawing.Color.White
        Me.Tasks_CheckedListBox.Location = New System.Drawing.Point(0, 0)
        Me.Tasks_CheckedListBox.Margin = New System.Windows.Forms.Padding(0)
        Me.Tasks_CheckedListBox.Name = "Tasks_CheckedListBox"
        Me.Tasks_CheckedListBox.Size = New System.Drawing.Size(576, 299)
        Me.Tasks_CheckedListBox.TabIndex = 10
        '
        'Tasks_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.MainTlp)
        Me.Name = "Tasks_View"
        Me.Text = "Tasks"
        Me.MainTlp.ResumeLayout(False)
        Me.MainTlp_SubTlpTaskProperties.ResumeLayout(False)
        Me.MainTlp_SubTlpTaskProperties.PerformLayout()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Tlp_ImportantButton.ResumeLayout(False)
        Me.MainTlp_SubTlpTaskView.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpBottom.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpBottom.PerformLayout()
        Me.SubTlpTaskView_SubTlpTop.ResumeLayout(False)
        Me.SubTlpTaskView_SubTlpTop.PerformLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubTlpTaskView_SubTlpMiddle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTlp As TableLayoutPanel
    Friend WithEvents MainTlp_SubTlpTaskProperties As TableLayoutPanel
    Friend WithEvents TaskTitle_TextBox As TextBox
    Friend WithEvents Button_DeleteTask As Button
    Friend WithEvents Label_ADT As Label
    Friend WithEvents Button_CloseTaskProperties As Button
    Friend WithEvents Label_TaskEntryDateTime As Label
    Friend WithEvents SubTlpTaskProperties_SubTlpTaskFeatureButtons As TableLayoutPanel
    Friend WithEvents CustomButton_AddDueDate As CustomButton_2
    Friend WithEvents CustomButton_Repeat As CustomButton_2
    Friend WithEvents CustomButton_AddReminder As CustomButton_2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TaskDescription_RichTextBox As RichTextBox
    Friend WithEvents Tlp_ImportantButton As TableLayoutPanel
    Friend WithEvents Important_Button As Button
    Friend WithEvents MainTlp_SubTlpTaskView As TableLayoutPanel
    Friend WithEvents SubTlpTaskView_SubTlpBottom As TableLayoutPanel
    Friend WithEvents AddNewTask_TextBox As TextBox
    Friend WithEvents SubTlpTaskView_SubTlpTop As TableLayoutPanel
    Friend WithEvents Tasks_Label As Label
    Friend WithEvents PictureBox_PanelIcon As PictureBox
    Friend WithEvents SubTlpTaskView_SubTlpMiddle As TableLayoutPanel
    Friend WithEvents Tasks_CheckedListBox As CheckedListBox
End Class