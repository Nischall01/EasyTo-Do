Namespace ViewsManager
    Module ViewsManager
        Public isUiUpdating As Boolean = False

        ' Dictionary to map view names to their corresponding task-loading actions
        Private ReadOnly viewLoadActions As New Dictionary(Of String, Action) From {
    {ViewName.MyDay, Sub() MainWindow.MyDayInstance.LoadTasksToMyDayView()},
    {ViewName.Repeated, Sub() MainWindow.RepeatedInstance.LoadTasksToRepeatedView()},
    {ViewName.Important, Sub() MainWindow.ImportantInstance.LoadTasksToImportantView()},
    {ViewName.Planned, Sub() MainWindow.PlannedInstance.LoadTasksToPlannedView()},
    {ViewName.Tasks, Sub() MainWindow.TasksInstance.LoadTasksToTasksView()}
}

        Public Sub RefreshTasks()
            isUiUpdating = True

            ' Get the active view
            Dim activeViewName As ViewName = GetActiveViewName()

            ' Refresh the active view first
            If viewLoadActions.ContainsKey(activeViewName) Then
                Try
                    viewLoadActions(activeViewName).Invoke()
                    'MsgBox("Refreshed " & activeViewName.ToString)
                Catch ex As Exception
                    MessageBox.Show("An error occurred while refreshing the active view: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            ' Refresh other views
            For Each viewName In viewLoadActions.Keys
                If viewName <> activeViewName Then
                    Try
                        viewLoadActions(viewName).Invoke()
                        'MsgBox("Refreshed " & viewName.ToString)
                    Catch ex As Exception
                        MessageBox.Show("An error occurred while refreshing tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next

            MainWindow.CacheTasksWithReminder()

            isUiUpdating = False
        End Sub

        Public Function GetActiveViewName() As ViewName
            Dim activeViewName As String = MainWindow.SplitContainer1.Panel2.Controls.Cast(Of Control)().FirstOrDefault().Name
            ' Map the control name to the corresponding enum value
            Select Case activeViewName
                Case "MyDay_View"
                    Return ViewName.MyDay
                Case "Repeated_View"
                    Return ViewName.Repeated
                Case "Important_View"
                    Return ViewName.Important
                Case "Planned_View"
                    Return ViewName.Planned
                Case "Tasks_View"
                    Return ViewName.Tasks
                Case Else
                    Return ViewName.None
            End Select
        End Function

    End Module
End Namespace