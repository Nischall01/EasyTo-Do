<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planned_View
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Planned_View))
        Me.MainTlp = New System.Windows.Forms.TableLayoutPanel()
        Me.MainTlp_SubTlpTaskProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.TaskTitle_TextBox = New System.Windows.Forms.TextBox()
        Me.DeleteTask_Button = New System.Windows.Forms.Button()
        Me.Label_ADT = New System.Windows.Forms.Label()
        Me.CloseTaskProperties_Button = New System.Windows.Forms.Button()
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
        Me.PlannedView_Label = New System.Windows.Forms.Label()
        Me.ViewIcon_PictureBox = New System.Windows.Forms.PictureBox()
        Me.SubTlpTaskView_SubTlpMiddle = New System.Windows.Forms.TableLayoutPanel()
        Me.Planned_CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainTlp.SuspendLayout()
        Me.MainTlp_SubTlpTaskProperties.SuspendLayout()
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tlp_ImportantButton.SuspendLayout()
        Me.MainTlp_SubTlpTaskView.SuspendLayout()
        Me.SubTlpTaskView_SubTlpBottom.SuspendLayout()
        Me.SubTlpTaskView_SubTlpTop.SuspendLayout()
        CType(Me.ViewIcon_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubTlpTaskView_SubTlpMiddle.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTlp
        '
        Me.MainTlp.BackColor = System.Drawing.Color.Transparent
        Me.MainTlp.ColumnCount = 2
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.0!))
        Me.MainTlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.0!))
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
        Me.MainTlp_SubTlpTaskProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.MainTlp_SubTlpTaskProperties.ColumnCount = 1
        Me.MainTlp_SubTlpTaskProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.TaskTitle_TextBox, 0, 1)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.DeleteTask_Button, 0, 6)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Label_ADT, 0, 2)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.CloseTaskProperties_Button, 0, 0)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Label_TaskEntryDateTime, 0, 3)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons, 0, 5)
        Me.MainTlp_SubTlpTaskProperties.Controls.Add(Me.Tlp_ImportantButton, 0, 4)
        Me.MainTlp_SubTlpTaskProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTlp_SubTlpTaskProperties.Location = New System.Drawing.Point(619, 0)
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
        Me.MainTlp_SubTlpTaskProperties.Size = New System.Drawing.Size(165, 461)
        Me.MainTlp_SubTlpTaskProperties.TabIndex = 3
        '
        'TaskTitle_TextBox
        '
        Me.TaskTitle_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TaskTitle_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TaskTitle_TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TaskTitle_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TaskTitle_TextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskTitle_TextBox.ForeColor = System.Drawing.Color.White
        Me.TaskTitle_TextBox.Location = New System.Drawing.Point(3, 38)
        Me.TaskTitle_TextBox.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TaskTitle_TextBox.Name = "TaskTitle_TextBox"
        Me.TaskTitle_TextBox.Size = New System.Drawing.Size(159, 20)
        Me.TaskTitle_TextBox.TabIndex = 12
        Me.TaskTitle_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DeleteTask_Button
        '
        Me.DeleteTask_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeleteTask_Button.BackColor = System.Drawing.Color.Transparent
        Me.DeleteTask_Button.BackgroundImage = CType(resources.GetObject("DeleteTask_Button.BackgroundImage"), System.Drawing.Image)
        Me.DeleteTask_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DeleteTask_Button.FlatAppearance.BorderSize = 0
        Me.DeleteTask_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.DeleteTask_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.DeleteTask_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteTask_Button.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteTask_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DeleteTask_Button.Location = New System.Drawing.Point(72, 401)
        Me.DeleteTask_Button.Name = "DeleteTask_Button"
        Me.DeleteTask_Button.Padding = New System.Windows.Forms.Padding(3)
        Me.DeleteTask_Button.Size = New System.Drawing.Size(21, 21)
        Me.DeleteTask_Button.TabIndex = 8
        Me.DeleteTask_Button.UseVisualStyleBackColor = False
        '
        'Label_ADT
        '
        Me.Label_ADT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label_ADT.AutoSize = True
        Me.Label_ADT.BackColor = System.Drawing.Color.Transparent
        Me.Label_ADT.Font = New System.Drawing.Font("Leelawadee UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ADT.ForeColor = System.Drawing.Color.Snow
        Me.Label_ADT.Location = New System.Drawing.Point(40, 65)
        Me.Label_ADT.Name = "Label_ADT"
        Me.Label_ADT.Size = New System.Drawing.Size(85, 11)
        Me.Label_ADT.TabIndex = 2
        Me.Label_ADT.Text = "Added Date and Time:"
        '
        'CloseTaskProperties_Button
        '
        Me.CloseTaskProperties_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CloseTaskProperties_Button.BackColor = System.Drawing.Color.Transparent
        Me.CloseTaskProperties_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CloseTaskProperties_Button.Font = New System.Drawing.Font("Yu Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseTaskProperties_Button.ForeColor = System.Drawing.Color.White
        Me.CloseTaskProperties_Button.Location = New System.Drawing.Point(70, 7)
        Me.CloseTaskProperties_Button.Margin = New System.Windows.Forms.Padding(0)
        Me.CloseTaskProperties_Button.Name = "CloseTaskProperties_Button"
        Me.CloseTaskProperties_Button.Size = New System.Drawing.Size(24, 24)
        Me.CloseTaskProperties_Button.TabIndex = 0
        Me.CloseTaskProperties_Button.Text = "X"
        Me.CloseTaskProperties_Button.UseVisualStyleBackColor = False
        '
        'Label_TaskEntryDateTime
        '
        Me.Label_TaskEntryDateTime.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_TaskEntryDateTime.AutoSize = True
        Me.Label_TaskEntryDateTime.BackColor = System.Drawing.Color.Transparent
        Me.Label_TaskEntryDateTime.Font = New System.Drawing.Font("Microsoft YaHei", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TaskEntryDateTime.ForeColor = System.Drawing.Color.Snow
        Me.Label_TaskEntryDateTime.Location = New System.Drawing.Point(77, 84)
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
        Me.SubTlpTaskProperties_SubTlpTaskFeatureButtons.Size = New System.Drawing.Size(159, 181)
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
        Me.CustomButton_AddDueDate.Size = New System.Drawing.Size(159, 40)
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
        Me.CustomButton_Repeat.Size = New System.Drawing.Size(159, 40)
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
        Me.CustomButton_AddReminder.Size = New System.Drawing.Size(159, 40)
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
        Me.Panel1.Size = New System.Drawing.Size(153, 55)
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
        Me.TaskDescription_RichTextBox.Size = New System.Drawing.Size(151, 53)
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
        Me.Tlp_ImportantButton.Location = New System.Drawing.Point(64, 129)
        Me.Tlp_ImportantButton.Name = "Tlp_ImportantButton"
        Me.Tlp_ImportantButton.RowCount = 1
        Me.Tlp_ImportantButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_ImportantButton.Size = New System.Drawing.Size(36, 36)
        Me.Tlp_ImportantButton.TabIndex = 11
        '
        'Important_Button
        '
        Me.Important_Button.BackColor = System.Drawing.Color.Transparent
        Me.Important_Button.BackgroundImage = CType(resources.GetObject("Important_Button.BackgroundImage"), System.Drawing.Image)
        Me.Important_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Important_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Important_Button.FlatAppearance.BorderSize = 0
        Me.Important_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Important_Button.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Important_Button.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Important_Button.Location = New System.Drawing.Point(3, 3)
        Me.Important_Button.Margin = New System.Windows.Forms.Padding(2)
        Me.Important_Button.Name = "Important_Button"
        Me.Important_Button.Size = New System.Drawing.Size(30, 30)
        Me.Important_Button.TabIndex = 8
        Me.Important_Button.UseVisualStyleBackColor = False
        '
        'MainTlp_SubTlpTaskView
        '
        Me.MainTlp_SubTlpTaskView.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
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
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainTlp_SubTlpTaskView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.MainTlp_SubTlpTaskView.Size = New System.Drawing.Size(619, 461)
        Me.MainTlp_SubTlpTaskView.TabIndex = 0
        '
        'SubTlpTaskView_SubTlpBottom
        '
        Me.SubTlpTaskView_SubTlpBottom.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpBottom.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.0!))
        Me.SubTlpTaskView_SubTlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.SubTlpTaskView_SubTlpBottom.Controls.Add(Me.AddNewTask_TextBox, 1, 0)
        Me.SubTlpTaskView_SubTlpBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpBottom.Location = New System.Drawing.Point(0, 414)
        Me.SubTlpTaskView_SubTlpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTlpTaskView_SubTlpBottom.Name = "SubTlpTaskView_SubTlpBottom"
        Me.SubTlpTaskView_SubTlpBottom.RowCount = 1
        Me.SubTlpTaskView_SubTlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpBottom.Size = New System.Drawing.Size(619, 47)
        Me.SubTlpTaskView_SubTlpBottom.TabIndex = 10
        '
        'AddNewTask_TextBox
        '
        Me.AddNewTask_TextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AddNewTask_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.AddNewTask_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.AddNewTask_TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.AddNewTask_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddNewTask_TextBox.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewTask_TextBox.ForeColor = System.Drawing.Color.White
        Me.AddNewTask_TextBox.Location = New System.Drawing.Point(18, 10)
        Me.AddNewTask_TextBox.Name = "AddNewTask_TextBox"
        Me.AddNewTask_TextBox.Size = New System.Drawing.Size(582, 27)
        Me.AddNewTask_TextBox.TabIndex = 4
        '
        'SubTlpTaskView_SubTlpTop
        '
        Me.SubTlpTaskView_SubTlpTop.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpTop.ColumnCount = 3
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.0!))
        Me.SubTlpTaskView_SubTlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.PlannedView_Label, 1, 0)
        Me.SubTlpTaskView_SubTlpTop.Controls.Add(Me.ViewIcon_PictureBox, 0, 0)
        Me.SubTlpTaskView_SubTlpTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpTop.Location = New System.Drawing.Point(0, 0)
        Me.SubTlpTaskView_SubTlpTop.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTlpTaskView_SubTlpTop.Name = "SubTlpTaskView_SubTlpTop"
        Me.SubTlpTaskView_SubTlpTop.RowCount = 1
        Me.SubTlpTaskView_SubTlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTlpTaskView_SubTlpTop.Size = New System.Drawing.Size(619, 69)
        Me.SubTlpTaskView_SubTlpTop.TabIndex = 6
        '
        'PlannedView_Label
        '
        Me.PlannedView_Label.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PlannedView_Label.AutoSize = True
        Me.PlannedView_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlannedView_Label.ForeColor = System.Drawing.Color.White
        Me.PlannedView_Label.Location = New System.Drawing.Point(58, 16)
        Me.PlannedView_Label.Name = "PlannedView_Label"
        Me.PlannedView_Label.Size = New System.Drawing.Size(127, 36)
        Me.PlannedView_Label.TabIndex = 6
        Me.PlannedView_Label.Text = "Planned"
        '
        'ViewIcon_PictureBox
        '
        Me.ViewIcon_PictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ViewIcon_PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ViewIcon_PictureBox.Enabled = False
        Me.ViewIcon_PictureBox.Image = CType(resources.GetObject("ViewIcon_PictureBox.Image"), System.Drawing.Image)
        Me.ViewIcon_PictureBox.Location = New System.Drawing.Point(15, 14)
        Me.ViewIcon_PictureBox.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewIcon_PictureBox.Name = "ViewIcon_PictureBox"
        Me.ViewIcon_PictureBox.Size = New System.Drawing.Size(40, 40)
        Me.ViewIcon_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ViewIcon_PictureBox.TabIndex = 1
        Me.ViewIcon_PictureBox.TabStop = False
        '
        'SubTlpTaskView_SubTlpMiddle
        '
        Me.SubTlpTaskView_SubTlpMiddle.BackColor = System.Drawing.Color.Transparent
        Me.SubTlpTaskView_SubTlpMiddle.ColumnCount = 1
        Me.SubTlpTaskView_SubTlpMiddle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpMiddle.Controls.Add(Me.Planned_CheckedListBox, 0, 0)
        Me.SubTlpTaskView_SubTlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTlpTaskView_SubTlpMiddle.Location = New System.Drawing.Point(0, 69)
        Me.SubTlpTaskView_SubTlpMiddle.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTlpTaskView_SubTlpMiddle.Name = "SubTlpTaskView_SubTlpMiddle"
        Me.SubTlpTaskView_SubTlpMiddle.RowCount = 1
        Me.SubTlpTaskView_SubTlpMiddle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.SubTlpTaskView_SubTlpMiddle.Size = New System.Drawing.Size(619, 345)
        Me.SubTlpTaskView_SubTlpMiddle.TabIndex = 11
        '
        'Planned_CheckedListBox
        '
        Me.Planned_CheckedListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Planned_CheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Planned_CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Planned_CheckedListBox.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Planned_CheckedListBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Planned_CheckedListBox.Location = New System.Drawing.Point(5, 0)
        Me.Planned_CheckedListBox.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Planned_CheckedListBox.Name = "Planned_CheckedListBox"
        Me.Planned_CheckedListBox.Size = New System.Drawing.Size(609, 345)
        Me.Planned_CheckedListBox.TabIndex = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(93, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripMenuItem1.Text = "Remove"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip2.ShowImageMargin = False
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(93, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripMenuItem2.Text = "Remove"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip3.ShowImageMargin = False
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(93, 26)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripMenuItem3.Text = "Remove"
        '
        'Planned_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.MainTlp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Planned_View"
        Me.Text = "Planned"
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
        CType(Me.ViewIcon_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubTlpTaskView_SubTlpMiddle.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTlp As TableLayoutPanel
    Friend WithEvents MainTlp_SubTlpTaskView As TableLayoutPanel
    Friend WithEvents SubTlpTaskView_SubTlpTop As TableLayoutPanel
    Friend WithEvents PlannedView_Label As Label
    Friend WithEvents ViewIcon_PictureBox As PictureBox
    Friend WithEvents SubTlpTaskView_SubTlpBottom As TableLayoutPanel
    Friend WithEvents MainTlp_SubTlpTaskProperties As TableLayoutPanel
    Friend WithEvents TaskTitle_TextBox As TextBox
    Friend WithEvents DeleteTask_Button As Button
    Friend WithEvents Label_ADT As Label
    Friend WithEvents CloseTaskProperties_Button As Button
    Friend WithEvents Label_TaskEntryDateTime As Label
    Friend WithEvents SubTlpTaskProperties_SubTlpTaskFeatureButtons As TableLayoutPanel
    Friend WithEvents CustomButton_AddDueDate As CustomButton_2
    Friend WithEvents CustomButton_Repeat As CustomButton_2
    Friend WithEvents CustomButton_AddReminder As CustomButton_2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TaskDescription_RichTextBox As RichTextBox
    Friend WithEvents Tlp_ImportantButton As TableLayoutPanel
    Friend WithEvents Important_Button As Button
    Friend WithEvents SubTlpTaskView_SubTlpMiddle As TableLayoutPanel
    Friend WithEvents Planned_CheckedListBox As CheckedListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents AddNewTask_TextBox As TextBox
End Class
