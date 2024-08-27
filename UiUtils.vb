Namespace UiUtils
    Module UiUtils
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

        Public Sub RetainItemSelection(CLB As CheckedListBox, SelectedTaskIndex As Integer)
            CLB.SelectedIndex = SelectedTaskIndex
        End Sub

        Public Sub ItemSelectionAfterTaskDeletion(CLB As CheckedListBox, SelectedTaskIndex As Integer, View As ViewName)
            ' Adjust the selected task index after deletion
            If CLB.Items.Count > 0 Then
                If SelectedTaskIndex >= CLB.Items.Count Then
                    SelectedTaskIndex = CLB.Items.Count - 1
                End If
                CLB.SelectedIndex = SelectedTaskIndex
            Else
                Select Case View
                    Case ViewName.MyDay
                        MainWindow.MyDayInstance.DisableTaskProperties(True)
                    Case ViewName.Repeated
                        MainWindow.RepeatedInstance.DisableTaskProperties(True)
                    Case ViewName.Important
                        MainWindow.ImportantInstance.DisableTaskProperties(True)
                    Case ViewName.Planned
                        MainWindow.PlannedInstance.DisableTaskProperties(True)
                    Case ViewName.Tasks
                        MainWindow.TasksInstance.DisableTaskProperties(True)
                End Select
            End If
        End Sub
    End Module
End Namespace