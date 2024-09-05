Public Class CustomButton_2
    Inherits UserControl

    Private effectsEnabled As Boolean = True

    Public Sub New()
        InitializeComponent()

        ' Set default properties
        Me.PictureBox1.BackColor = Color.Transparent
        Me.Label1.BackColor = Color.Transparent
        Me.TableLayoutPanel1.BackColor = Color.Transparent

        Me.Label1.ForeColor = Color.White

        ' Add event handlers for the TableLayoutPanel and child controls
        AddHandler TableLayoutPanel1.MouseEnter, AddressOf CustomButton_MouseEnter
        AddHandler TableLayoutPanel1.MouseLeave, AddressOf CustomButton_MouseLeave
        AddHandler TableLayoutPanel1.MouseDown, AddressOf CustomButton_MouseDown
        AddHandler TableLayoutPanel1.MouseUp, AddressOf CustomButton_MouseUp
        AddHandler TableLayoutPanel1.Click, AddressOf CustomButton_Click

        AddHandler PictureBox1.MouseEnter, AddressOf CustomButton_MouseEnter
        AddHandler PictureBox1.MouseLeave, AddressOf CustomButton_MouseLeave
        AddHandler PictureBox1.MouseDown, AddressOf CustomButton_MouseDown
        AddHandler PictureBox1.MouseUp, AddressOf CustomButton_MouseUp
        AddHandler PictureBox1.Click, AddressOf CustomButton_Click

        AddHandler Label1.MouseEnter, AddressOf CustomButton_MouseEnter
        AddHandler Label1.MouseLeave, AddressOf CustomButton_MouseLeave
        AddHandler Label1.MouseDown, AddressOf CustomButton_MouseDown
        AddHandler Label1.MouseUp, AddressOf CustomButton_MouseUp
        AddHandler Label1.Click, AddressOf CustomButton_Click
    End Sub

    ' Property to set icon
    Public Property Icon As Image
        Get
            Return PictureBox1.Image
        End Get
        Set(value As Image)
            PictureBox1.Image = value
        End Set
    End Property

    ' Property to set text
    Public Property ButtonText As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    ' Property to set PictureBox size
    Public Property PictureBoxSize As Size
        Get
            Return PictureBox1.Size
        End Get
        Set(value As Size)
            PictureBox1.Size = value
        End Set
    End Property

    ' Property to set Label font
    Public Property TextFont As Font
        Get
            Return Label1.Font
        End Get
        Set(value As Font)
            Label1.Font = value
        End Set
    End Property

    ' Property to set PictureBox anchor
    Public Property IconAnchor As AnchorStyles
        Get
            Return PictureBox1.Anchor
        End Get
        Set(value As AnchorStyles)
            PictureBox1.Anchor = value
        End Set
    End Property

    ' Property to set Label anchor
    Public Property TextAnchor As AnchorStyles
        Get
            Return Label1.Anchor
        End Get
        Set(value As AnchorStyles)
            Label1.Anchor = value
        End Set
    End Property

    ' Property to set PictureBox size
    Public Property IconSize As Size
        Get
            Return PictureBox1.Size
        End Get
        Set(value As Size)
            PictureBox1.Size = value
        End Set
    End Property

    ' Property to set Label margin
    Public Property LabelMargin As Padding
        Get
            Return Label1.Margin
        End Get
        Set(value As Padding)
            Label1.Margin = value
        End Set
    End Property

    ' Mouse hover effect
    Private Sub CustomButton_MouseEnter(sender As Object, e As EventArgs)
        If My.Settings.ColorScheme = "Dark" Then
            Me.BackColor = Color.FromArgb(50, 50, 50)
        Else
            Me.BackColor = Color.FromArgb(159, 159, 159)
        End If
    End Sub

    Private Sub CustomButton_MouseLeave(sender As Object, e As EventArgs)
        If effectsEnabled Then
            Me.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub CustomButton_MouseDown(sender As Object, e As EventArgs)
        Me.BackColor = Color.FromArgb(127, 127, 127)
    End Sub

    Private Sub CustomButton_MouseUp(sender As Object, e As EventArgs)
        If effectsEnabled = True Then
            Me.BackColor = Color.Transparent
        Else
            If My.Settings.ColorScheme = "Dark" Then
                Me.BackColor = Color.FromArgb(50, 50, 50)
            ElseIf My.Settings.ColorScheme = "Light" Then
                Me.BackColor = Color.FromArgb(159, 159, 159)
            End If
        End If
    End Sub

    ' Click event to handle button click
    Private Sub CustomButton_Click(sender As Object, e As EventArgs)
        MyBase.OnMouseClick(e)
        MyBase.OnClick(e)
    End Sub

    ' Method to disable all effects
    Public Sub DisableEffects()
        effectsEnabled = False
        Me.BorderStyle = BorderStyle.FixedSingle
        If My.Settings.ColorScheme = "Dark" Then
            Me.BackColor = Color.FromArgb(50, 50, 50)
        Else
            Me.BackColor = Color.FromArgb(159, 159, 159)
        End If
    End Sub

    ' Method to enable all effects
    Public Sub EnableEffects()
        effectsEnabled = True
        Me.BackColor = Color.Transparent
        Me.BorderStyle = BorderStyle.None
    End Sub

End Class