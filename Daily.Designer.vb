<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Daily
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Daily))
        Me.MainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedListBox_MyDay = New System.Windows.Forms.CheckedListBox()
        Me.SubTableLayoutPanel_Top = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_FormName = New System.Windows.Forms.TextBox()
        Me.PictureBox_FormIcon = New System.Windows.Forms.PictureBox()
        Me.SubTableLayoutPanel_Bottom = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_AddNewTask = New System.Windows.Forms.TextBox()
        Me.MainTableLayoutPanel.SuspendLayout()
        Me.SubTableLayoutPanel_Top.SuspendLayout()
        CType(Me.PictureBox_FormIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubTableLayoutPanel_Bottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTableLayoutPanel
        '
        Me.MainTableLayoutPanel.BackColor = System.Drawing.Color.White
        Me.MainTableLayoutPanel.ColumnCount = 1
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTableLayoutPanel.Controls.Add(Me.CheckedListBox_MyDay, 0, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_Top, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.SubTableLayoutPanel_Bottom, 0, 2)
        Me.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainTableLayoutPanel.Name = "MainTableLayoutPanel"
        Me.MainTableLayoutPanel.RowCount = 3
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.MainTableLayoutPanel.Size = New System.Drawing.Size(784, 461)
        Me.MainTableLayoutPanel.TabIndex = 0
        '
        'CheckedListBox_MyDay
        '
        Me.CheckedListBox_MyDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CheckedListBox_MyDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheckedListBox_MyDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox_MyDay.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!)
        Me.CheckedListBox_MyDay.ForeColor = System.Drawing.Color.White
        Me.CheckedListBox_MyDay.FormattingEnabled = True
        Me.CheckedListBox_MyDay.Location = New System.Drawing.Point(3, 95)
        Me.CheckedListBox_MyDay.Name = "CheckedListBox_MyDay"
        Me.CheckedListBox_MyDay.Size = New System.Drawing.Size(778, 293)
        Me.CheckedListBox_MyDay.TabIndex = 3
        '
        'SubTableLayoutPanel_Top
        '
        Me.SubTableLayoutPanel_Top.ColumnCount = 2
        Me.SubTableLayoutPanel_Top.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.SubTableLayoutPanel_Top.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.0!))
        Me.SubTableLayoutPanel_Top.Controls.Add(Me.TextBox_FormName, 0, 0)
        Me.SubTableLayoutPanel_Top.Controls.Add(Me.PictureBox_FormIcon, 0, 0)
        Me.SubTableLayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTableLayoutPanel_Top.Location = New System.Drawing.Point(3, 3)
        Me.SubTableLayoutPanel_Top.Name = "SubTableLayoutPanel_Top"
        Me.SubTableLayoutPanel_Top.RowCount = 1
        Me.SubTableLayoutPanel_Top.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SubTableLayoutPanel_Top.Size = New System.Drawing.Size(778, 86)
        Me.SubTableLayoutPanel_Top.TabIndex = 0
        '
        'TextBox_FormName
        '
        Me.TextBox_FormName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox_FormName.BackColor = System.Drawing.Color.White
        Me.TextBox_FormName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_FormName.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_FormName.ForeColor = System.Drawing.Color.Black
        Me.TextBox_FormName.Location = New System.Drawing.Point(106, 25)
        Me.TextBox_FormName.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.TextBox_FormName.Name = "TextBox_FormName"
        Me.TextBox_FormName.ReadOnly = True
        Me.TextBox_FormName.Size = New System.Drawing.Size(95, 36)
        Me.TextBox_FormName.TabIndex = 3
        Me.TextBox_FormName.Text = "Daily"
        '
        'PictureBox_FormIcon
        '
        Me.PictureBox_FormIcon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox_FormIcon.BackColor = System.Drawing.Color.White
        Me.PictureBox_FormIcon.Enabled = False
        Me.PictureBox_FormIcon.Image = CType(resources.GetObject("PictureBox_FormIcon.Image"), System.Drawing.Image)
        Me.PictureBox_FormIcon.Location = New System.Drawing.Point(61, 23)
        Me.PictureBox_FormIcon.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_FormIcon.Name = "PictureBox_FormIcon"
        Me.PictureBox_FormIcon.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox_FormIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_FormIcon.TabIndex = 2
        Me.PictureBox_FormIcon.TabStop = False
        '
        'SubTableLayoutPanel_Bottom
        '
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
        Me.SubTableLayoutPanel_Bottom.Size = New System.Drawing.Size(778, 64)
        Me.SubTableLayoutPanel_Bottom.TabIndex = 1
        '
        'TextBox_AddNewTask
        '
        Me.TextBox_AddNewTask.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox_AddNewTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox_AddNewTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_AddNewTask.Location = New System.Drawing.Point(197, 22)
        Me.TextBox_AddNewTask.Name = "TextBox_AddNewTask"
        Me.TextBox_AddNewTask.Size = New System.Drawing.Size(383, 20)
        Me.TextBox_AddNewTask.TabIndex = 2
        '
        'Daily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.MainTableLayoutPanel)
        Me.Name = "Daily"
        Me.Text = "Daily"
        Me.MainTableLayoutPanel.ResumeLayout(False)
        Me.SubTableLayoutPanel_Top.ResumeLayout(False)
        Me.SubTableLayoutPanel_Top.PerformLayout()
        CType(Me.PictureBox_FormIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubTableLayoutPanel_Bottom.ResumeLayout(False)
        Me.SubTableLayoutPanel_Bottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTableLayoutPanel As TableLayoutPanel
    Friend WithEvents SubTableLayoutPanel_Top As TableLayoutPanel
    Friend WithEvents SubTableLayoutPanel_Bottom As TableLayoutPanel
    Friend WithEvents TextBox_AddNewTask As TextBox
    Friend WithEvents PictureBox_FormIcon As PictureBox
    Friend WithEvents TextBox_FormName As TextBox
    Friend WithEvents CheckedListBox_MyDay As CheckedListBox
End Class
