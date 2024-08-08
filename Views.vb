Module Views
    Sub RefreshTasks()
        MainWindow.MyDayInstance.LoadTasksToMyDay()
        MainWindow.RepeatedInstance.LoadTasksToRepeated()
        MainWindow.ImportantInstance.LoadTasksToImportant()
        MainWindow.PlannedInstance.LoadTasksToPlanned()
        MainWindow.TasksInstance.LoadTasksToTasks()
    End Sub
End Module
