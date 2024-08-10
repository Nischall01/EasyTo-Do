Module Views
    ' Dictionary to map view names to their instances
    Private ReadOnly viewInstances As New Dictionary(Of String, Action) From {
        {"MyDay", Sub() MainWindow.MyDayInstance.LoadTasksToMyDay()},
        {"Repeated", Sub() MainWindow.RepeatedInstance.LoadTasksToRepeated()},
        {"Important", Sub() MainWindow.ImportantInstance.LoadTasksToImportant()},
        {"Planned", Sub() MainWindow.PlannedInstance.LoadTasksToPlanned()},
        {"Tasks", Sub() MainWindow.TasksInstance.LoadTasksToTasks()}
    }

    ' Refresh all tasks for all views
    Sub RefreshTasks()
        For Each refreshAction In viewInstances.Values
            refreshAction.Invoke()
        Next
    End Sub

    ' Refresh tasks for all views except the one specified
    Sub RefreshTasksWithException(excludedView As String)
        For Each viewName In viewInstances.Keys
            If viewName <> excludedView Then
                viewInstances(viewName).Invoke()
            End If
        Next
    End Sub
End Module
