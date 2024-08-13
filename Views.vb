Module Views
    Public Enum TaskPropertiesVisibility
        Toggle
        Show
        Hide
    End Enum

    Public _isUiUpdating As Boolean = False

    ' Dictionary to map view names to their instances
    Private ReadOnly viewInstances As New Dictionary(Of String, Action) From {
        {"MyDay", Sub() MainWindow.MyDayInstance.LoadTasksToMyDay()},
        {"Repeated", Sub() MainWindow.RepeatedInstance.LoadTasksToRepeated()},
        {"Important", Sub() MainWindow.ImportantInstance.LoadTasksToImportant()},
        {"Planned", Sub() MainWindow.PlannedInstance.LoadTasksToPlanned()},
        {"Tasks", Sub() MainWindow.TasksInstance.LoadTasksToTasks()}
    }

    Public Sub RefreshTasks()
        'MsgBox("Refresh Triggered")
        _isUiUpdating = True
        For Each refreshAction In viewInstances.Values
            Try
                refreshAction.Invoke()
            Catch ex As Exception
                MessageBox.Show("An error occurred while refreshing tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
        _isUiUpdating = False
    End Sub
End Module
