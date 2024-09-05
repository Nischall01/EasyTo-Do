Imports System.Drawing.Drawing2D

Public Class CircularPictureBox
    Inherits PictureBox

    Public PfpColorScheme As String = My.Settings.ColorScheme
    Private PictureBoxBackColor As Color

    Public Sub New()
        InitializeComponent()
        InitializeCircularPictureBox()
    End Sub

    Private Sub InitializeCircularPictureBox()
        ' Ensure the PictureBox maintains a square aspect ratio
        Me.SizeMode = PictureBoxSizeMode.CenterImage

        Select Case PfpColorScheme
            Case "Light"
                PictureBoxBackColor = Color.White
            Case "Dark"
                PictureBoxBackColor = Color.FromArgb(30, 30, 30)
            Case "Custom"
        End Select
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        PfpColorScheme = My.Settings.ColorScheme
        Select Case PfpColorScheme
            Case "Light"
                PictureBoxBackColor = Color.White
            Case "Dark"
                PictureBoxBackColor = Color.FromArgb(30, 30, 30)
            Case "Custom"
        End Select

        MyBase.OnPaint(e)

        ' Define the diameter for the circular clipping region
        Dim diameter As Integer = Math.Min(Me.Width, Me.Height)
        Dim circlePath As New GraphicsPath()

        ' Create the circular path
        circlePath.AddEllipse(0, 0, diameter, diameter)

        ' Set up the circular clipping region
        Using clipRegion As New Region(circlePath)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            ' Clear the background to make sure transparency is visible
            e.Graphics.Clear(PictureBoxBackColor)

            ' Set the clipping region to circular
            e.Graphics.SetClip(clipRegion, CombineMode.Replace)

            ' Draw the image within the circular region
            If Me.Image IsNot Nothing Then
                e.Graphics.DrawImage(Me.Image, New Rectangle(0, 0, diameter, diameter))
            End If

            ' Draw the circular border if needed
            Using pen As New Pen(PictureBoxBackColor, 4)
                e.Graphics.DrawEllipse(pen, 0, 0, diameter - 1, diameter - 1)
            End Using
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        ' Ensure the PictureBox is square to maintain circular shape
        If Me.Width <> Me.Height Then
            Me.Width = Me.Height
        End If
    End Sub

End Class