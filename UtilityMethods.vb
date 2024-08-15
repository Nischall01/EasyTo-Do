Module UtilityMethods
    Public Sub ClearListItemSelection(clb As CheckedListBox)
        clb.SelectedItem = Nothing
        clb.SelectedIndex = -1
    End Sub

    Public Sub ShowContextMenuCentered(contextMenu As ContextMenuStrip, control As Control)
        ' Calculate the center position of the control on the screen
        Dim buttonCenterScreenPosition As Point = control.PointToScreen(New Point(control.Width / 2, control.Height / 2))
        ' Calculate the location to show the ContextMenuStrip centered over the control
        Dim contextMenuPosition As New Point(buttonCenterScreenPosition.X - (contextMenu.Width / 2), buttonCenterScreenPosition.Y - (contextMenu.Height / 2))
        ' Show the ContextMenuStrip at the calculated position
        contextMenu.Show(contextMenuPosition)
    End Sub

    Public Sub ToggleTaskProperties(IsTaskPropertiesVisible As Boolean, MainTlp As TableLayoutPanel)
        If IsTaskPropertiesVisible Then
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 75%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 25%
        Else
            MainTlp.ColumnStyles(0).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(0).Width = 100%
            MainTlp.ColumnStyles(1).SizeType = SizeType.Percent
            MainTlp.ColumnStyles(1).Width = 0%
        End If
    End Sub
End Module
