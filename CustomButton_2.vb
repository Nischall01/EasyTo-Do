Public Class CustomButton_2
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        ' Set default properties
        Me.BackColor = Color.FromArgb(30, 30, 30)
        Me.Label1.ForeColor = Color.White

        ' Add event handlers for the TableLayoutPanel and child controls
        AddHandler Me.TableLayoutPanel1.MouseEnter, AddressOf CustomButton_MouseEnter
        AddHandler Me.TableLayoutPanel1.MouseLeave, AddressOf CustomButton_MouseLeave
        AddHandler Me.TableLayoutPanel1.MouseDown, AddressOf CustomButton_MouseDown
        AddHandler Me.TableLayoutPanel1.MouseUp, AddressOf CustomButton_MouseUp
        AddHandler Me.TableLayoutPanel1.Click, AddressOf CustomButton_Click

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
        Me.BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Private Sub CustomButton_MouseLeave(sender As Object, e As EventArgs)
        Me.BackColor = Color.FromArgb(30, 30, 30)
    End Sub

    Private Sub CustomButton_MouseDown(sender As Object, e As EventArgs)
        Me.BackColor = Color.FromArgb(127, 127, 127)
    End Sub

    Private Sub CustomButton_MouseUp(sender As Object, e As EventArgs)
        Me.BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    ' Click event to handle button click
    Private Sub CustomButton_Click(sender As Object, e As EventArgs)
        MyBase.OnClick(e)
    End Sub
End Class
