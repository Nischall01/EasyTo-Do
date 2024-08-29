Namespace UiUtils
    Module UiUtils
        Public Sub TaskSelection_Clear(CLB As CheckedListBox)
            CLB.SelectedItem = Nothing
            CLB.SelectedIndex = -1
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

        Public Sub TaskSelection_Retain(CLB As CheckedListBox, TaskId As Integer)
            For i As Integer = 0 To CLB.Items.Count - 1
                If CLB.Items(i).ID = TaskId Then
                    CLB.SelectedIndex = i
                    Exit For
                End If
            Next
        End Sub

        Public Sub TaskSelection_Shift(CLB As CheckedListBox, TaskIndex As Integer, View As ViewName)
            If CLB.Items.Count <> 0 Then
                If TaskIndex >= CLB.Items.Count Then
                    TaskIndex = CLB.Items.Count - 1
                End If
                CLB.SelectedIndex = TaskIndex
            Else
                Select Case View
                    Case ViewName.MyDay
                        MainWindow.MyDayInstance.DisableAndHide_TaskPropertiesSidebar()
                    Case ViewName.Repeated
                        MainWindow.RepeatedInstance.DisableAndHide_TaskPropertiesSidebar()
                    Case ViewName.Important
                        MainWindow.ImportantInstance.DisableAndHide_TaskPropertiesSidebar()
                    Case ViewName.Planned
                        MainWindow.PlannedInstance.DisableAndHide_TaskPropertiesSidebar()
                    Case ViewName.Tasks
                        MainWindow.TasksInstance.DisableAndHide_TaskPropertiesSidebar()
                End Select
            End If
        End Sub
    End Module
End Namespace