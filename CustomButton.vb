Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomButton
    Inherits Button

    ' Property for the icon
    Private _icon As Image
    Public Property Icon As Image
        Get
            Return _icon
        End Get
        Set(value As Image)
            _icon = value
            Invalidate() ' Trigger a redraw when the icon is changed
        End Set
    End Property

    ' Property for the icon margin
    Private _iconMargin As Integer = 5
    Public Property IconMargin As Integer
        Get
            Return _iconMargin
        End Get
        Set(value As Integer)
            _iconMargin = value
            Invalidate() ' Trigger a redraw when the margin is changed
        End Set
    End Property

    ' Property for the icon size
    Private _iconSize As Size = New Size(16, 16)
    Public Property IconSize As Size
        Get
            Return _iconSize
        End Get
        Set(value As Size)
            _iconSize = value
            Invalidate() ' Trigger a redraw when the icon size is changed
        End Set
    End Property

    ' Override OnPaint to draw the icon
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        If _icon IsNot Nothing Then
            ' Draw the icon
            Dim iconRect As New Rectangle(IconMargin, (Height - _iconSize.Height) \ 2, IconSize.Width, IconSize.Height)
            e.Graphics.DrawImage(_icon, iconRect)
        End If
    End Sub
End Class
