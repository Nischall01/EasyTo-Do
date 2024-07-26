<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class My_Day
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(My_Day))
        Me.MainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SubTableLayoutPanel_Bottom = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_AddNewTask = New System.Windows.Forms.TextBox()
        Me.SubTablelayoutPanel_Top = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox_PanelIcon = New System.Windows.Forms.PictureBox()
        Me.SubTableLayoutPanel_Middle = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedListBox_MyDay = New System.Windows.Forms.CheckedListBox()
        Me.SubTableLayoutPanel_TaskProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MainTableLayoutPanel.SuspendLayout()
        Me.SubTableLayoutPanel_Bottom.SuspendLayout()
        Me.SubTablelayoutPanel_Top.SuspendLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubTableLayoutPanel_Middle.SuspendLayout()
        Me.SubTableLayoutPanel_TaskProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTableLayoutPanel
        '
        Me.MainTableLayoutPanel.BackColor = System.Drawing.Color.White
        Me.MainTableLayoutPanel.ColumnCount = 2
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_Bottom, 0, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_TaskProperties, 1, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTablelayoutPanel_Top, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_Middle, 0, 1)
        Me.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainTableLayoutPanel.Name = "MainTableLayoutPanel"
        Me.MainTableLayoutPanel.RowCount = 3
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainTableLayoutPanel.Size = New System.Drawing.Size(784, 461)
        Me.MainTableLayoutPanel.TabIndex = 4
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
        Me.SubTableLayoutPanel_Bottom.Size = New System.Drawing.Size(609, 64)
        Me.SubTableLayoutPanel_Bottom.TabIndex = 4
        '
        'TextBox_AddNewTask
        '
        Me.TextBox_AddNewTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox_AddNewTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_AddNewTask.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox_AddNewTask.Location = New System.Drawing.Point(155, 3)
        Me.TextBox_AddNewTask.Name = "TextBox_AddNewTask"
        Me.TextBox_AddNewTask.Size = New System.Drawing.Size(298, 20)
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
        Me.SubTablelayoutPanel_Top.Controls.Add(Me.Label2, 1, 0)
        Me.SubTablelayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTablelayoutPanel_Top.Location = New System.Drawing.Point(3, 3)
        Me.SubTablelayoutPanel_Top.Name = "SubTablelayoutPanel_Top"
        Me.SubTablelayoutPanel_Top.RowCount = 1
        Me.SubTablelayoutPanel_Top.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTablelayoutPanel_Top.Size = New System.Drawing.Size(609, 86)
        Me.SubTablelayoutPanel_Top.TabIndex = 5
        '
        'PictureBox_PanelIcon
        '
        Me.PictureBox_PanelIcon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox_PanelIcon.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_PanelIcon.Enabled = False
        Me.PictureBox_PanelIcon.Image = CType(resources.GetObject("PictureBox_PanelIcon.Image"), System.Drawing.Image)
        Me.PictureBox_PanelIcon.Location = New System.Drawing.Point(39, 23)
        Me.PictureBox_PanelIcon.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_PanelIcon.Name = "PictureBox_PanelIcon"
        Me.PictureBox_PanelIcon.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox_PanelIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_PanelIcon.TabIndex = 1
        Me.PictureBox_PanelIcon.TabStop = False
        '
        'SubTableLayoutPanel_Middle
        '
        Me.SubTableLayoutPanel_Middle.ColumnCount = 1
        Me.SubTableLayoutPanel_Middle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.0!))
        Me.SubTableLayoutPanel_Middle.Controls.Add(Me.CheckedListBox_MyDay, 0, 0)
        Me.SubTableLayoutPanel_Middle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTableLayoutPanel_Middle.Location = New System.Drawing.Point(3, 95)
        Me.SubTableLayoutPanel_Middle.Name = "SubTableLayoutPanel_Middle"
        Me.SubTableLayoutPanel_Middle.RowCount = 1
        Me.SubTableLayoutPanel_Middle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTableLayoutPanel_Middle.Size = New System.Drawing.Size(609, 293)
        Me.SubTableLayoutPanel_Middle.TabIndex = 6
        '
        'CheckedListBox_MyDay
        '
        Me.CheckedListBox_MyDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CheckedListBox_MyDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox_MyDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox_MyDay.ForeColor = System.Drawing.Color.White
        Me.CheckedListBox_MyDay.FormattingEnabled = True
        Me.CheckedListBox_MyDay.Location = New System.Drawing.Point(0, 0)
        Me.CheckedListBox_MyDay.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBox_MyDay.Name = "CheckedListBox_MyDay"
        Me.CheckedListBox_MyDay.Size = New System.Drawing.Size(609, 293)
        Me.CheckedListBox_MyDay.TabIndex = 0
        '
        'SubTableLayoutPanel_TaskProperties
        '
        Me.SubTableLayoutPanel_TaskProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.SubTableLayoutPanel_TaskProperties.ColumnCount = 1
        Me.SubTableLayoutPanel_TaskProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Button2, 0, 0)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.TextBox1, 0, 1)
        Me.SubTableLayoutPanel_TaskProperties.Controls.Add(Me.Label1, 0, 2)
        Me.SubTableLayoutPanel_TaskProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTableLayoutPanel_TaskProperties.Location = New System.Drawing.Point(615, 92)
        Me.SubTableLayoutPanel_TaskProperties.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTableLayoutPanel_TaskProperties.Name = "SubTableLayoutPanel_TaskProperties"
        Me.SubTableLayoutPanel_TaskProperties.RowCount = 6
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.SubTableLayoutPanel_TaskProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.SubTableLayoutPanel_TaskProperties.Size = New System.Drawing.Size(169, 299)
        Me.SubTableLayoutPanel_TaskProperties.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(71, 0)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 26)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Location = New System.Drawing.Point(3, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(163, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(46, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 7)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Added Date and Time:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 37)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "My Day"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(447, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DateTime"
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
        Me.SubTableLayoutPanel_Bottom.ResumeLayout(False)
        Me.SubTableLayoutPanel_Bottom.PerformLayout()
        Me.SubTablelayoutPanel_Top.ResumeLayout(False)
        Me.SubTablelayoutPanel_Top.PerformLayout()
        CType(Me.PictureBox_PanelIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubTableLayoutPanel_Middle.ResumeLayout(False)
        Me.SubTableLayoutPanel_TaskProperties.ResumeLayout(False)
        Me.SubTableLayoutPanel_TaskProperties.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTableLayoutPanel As TableLayoutPanel
    Friend WithEvents SubTableLayoutPanel_Bottom As TableLayoutPanel
    Friend WithEvents SubTablelayoutPanel_Top As TableLayoutPanel
    Friend WithEvents PictureBox_PanelIcon As PictureBox
    Friend WithEvents TextBox_AddNewTask As TextBox
    Friend WithEvents SubTableLayoutPanel_Middle As TableLayoutPanel
    Friend WithEvents CheckedListBox_MyDay As CheckedListBox
    Friend WithEvents SubTableLayoutPanel_TaskProperties As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
