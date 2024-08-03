<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ColorScheme_Custom_RadioBtn = New System.Windows.Forms.RadioButton()
        Me.ColorScheme_Dark_RadioBtn = New System.Windows.Forms.RadioButton()
        Me.ColorScheme_Light_RadioBtn = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(283, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(277, 224)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(271, 106)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(83, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color Scheme"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Controls.Add(Me.ColorScheme_Custom_RadioBtn, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ColorScheme_Dark_RadioBtn, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ColorScheme_Light_RadioBtn, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 56)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(263, 46)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'ColorScheme_Custom_RadioBtn
        '
        Me.ColorScheme_Custom_RadioBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ColorScheme_Custom_RadioBtn.AutoSize = True
        Me.ColorScheme_Custom_RadioBtn.ForeColor = System.Drawing.Color.White
        Me.ColorScheme_Custom_RadioBtn.Location = New System.Drawing.Point(188, 14)
        Me.ColorScheme_Custom_RadioBtn.Name = "ColorScheme_Custom_RadioBtn"
        Me.ColorScheme_Custom_RadioBtn.Size = New System.Drawing.Size(60, 17)
        Me.ColorScheme_Custom_RadioBtn.TabIndex = 2
        Me.ColorScheme_Custom_RadioBtn.TabStop = True
        Me.ColorScheme_Custom_RadioBtn.Text = "Custom"
        Me.ColorScheme_Custom_RadioBtn.UseVisualStyleBackColor = True
        '
        'ColorScheme_Dark_RadioBtn
        '
        Me.ColorScheme_Dark_RadioBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ColorScheme_Dark_RadioBtn.AutoSize = True
        Me.ColorScheme_Dark_RadioBtn.ForeColor = System.Drawing.Color.White
        Me.ColorScheme_Dark_RadioBtn.Location = New System.Drawing.Point(106, 14)
        Me.ColorScheme_Dark_RadioBtn.Name = "ColorScheme_Dark_RadioBtn"
        Me.ColorScheme_Dark_RadioBtn.Size = New System.Drawing.Size(48, 17)
        Me.ColorScheme_Dark_RadioBtn.TabIndex = 1
        Me.ColorScheme_Dark_RadioBtn.TabStop = True
        Me.ColorScheme_Dark_RadioBtn.Text = "Dark"
        Me.ColorScheme_Dark_RadioBtn.UseVisualStyleBackColor = True
        '
        'ColorScheme_Light_RadioBtn
        '
        Me.ColorScheme_Light_RadioBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ColorScheme_Light_RadioBtn.AutoSize = True
        Me.ColorScheme_Light_RadioBtn.ForeColor = System.Drawing.Color.White
        Me.ColorScheme_Light_RadioBtn.Location = New System.Drawing.Point(19, 14)
        Me.ColorScheme_Light_RadioBtn.Name = "ColorScheme_Light_RadioBtn"
        Me.ColorScheme_Light_RadioBtn.Size = New System.Drawing.Size(48, 17)
        Me.ColorScheme_Light_RadioBtn.TabIndex = 0
        Me.ColorScheme_Light_RadioBtn.TabStop = True
        Me.ColorScheme_Light_RadioBtn.Text = "Light"
        Me.ColorScheme_Light_RadioBtn.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(283, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents ColorScheme_Custom_RadioBtn As RadioButton
    Friend WithEvents ColorScheme_Dark_RadioBtn As RadioButton
    Friend WithEvents ColorScheme_Light_RadioBtn As RadioButton
End Class
