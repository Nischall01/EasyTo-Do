<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DueDate_Dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DueDate_Dialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CloseReminder_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.ReminderProperty_Icon = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.ReminderProperty_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MonthCalendar1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(249, 295)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MonthCalendar1.Location = New System.Drawing.Point(11, 78)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CloseReminder_Button, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(249, 32)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'CloseReminder_Button
        '
        Me.CloseReminder_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CloseReminder_Button.BackColor = System.Drawing.Color.Transparent
        Me.CloseReminder_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CloseReminder_Button.Font = New System.Drawing.Font("Yu Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseReminder_Button.ForeColor = System.Drawing.Color.White
        Me.CloseReminder_Button.Location = New System.Drawing.Point(112, 4)
        Me.CloseReminder_Button.Margin = New System.Windows.Forms.Padding(0)
        Me.CloseReminder_Button.Name = "CloseReminder_Button"
        Me.CloseReminder_Button.Size = New System.Drawing.Size(24, 24)
        Me.CloseReminder_Button.TabIndex = 4
        Me.CloseReminder_Button.TabStop = False
        Me.CloseReminder_Button.Text = "X"
        Me.CloseReminder_Button.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.ReminderProperty_Icon, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(249, 37)
        Me.TableLayoutPanel6.TabIndex = 5
        '
        'ReminderProperty_Icon
        '
        Me.ReminderProperty_Icon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ReminderProperty_Icon.BackgroundImage = CType(resources.GetObject("ReminderProperty_Icon.BackgroundImage"), System.Drawing.Image)
        Me.ReminderProperty_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ReminderProperty_Icon.Location = New System.Drawing.Point(109, 4)
        Me.ReminderProperty_Icon.Margin = New System.Windows.Forms.Padding(0)
        Me.ReminderProperty_Icon.Name = "ReminderProperty_Icon"
        Me.ReminderProperty_Icon.Size = New System.Drawing.Size(30, 28)
        Me.ReminderProperty_Icon.TabIndex = 2
        Me.ReminderProperty_Icon.TabStop = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(87, 261)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Set"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'DueDate_Dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 295)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "DueDate_Dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DueDate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.ReminderProperty_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents CloseReminder_Button As Button
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents ReminderProperty_Icon As PictureBox
    Friend WithEvents Button2 As Button
End Class
