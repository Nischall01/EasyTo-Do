Module Views
    Sub RefreshTasks()
        MainWindow.MyDayInstance.LoadTasksToMyDay()
        MainWindow.RepeatedInstance.LoadTasksToRepeated()
        MainWindow.ImportantInstance.LoadTasksToImportant()
        MainWindow.PlannedInstance.LoadTasksToPlanned()
        MainWindow.TasksInstance.LoadTasksToTasks()
    End Sub
    Sub RefreshTasksWithException(View As String)
        Select Case View
            Case "MyDay"
                MainWindow.RepeatedInstance.LoadTasksToRepeated()
                MainWindow.ImportantInstance.LoadTasksToImportant()
                MainWindow.PlannedInstance.LoadTasksToPlanned()
                MainWindow.TasksInstance.LoadTasksToTasks()
            Case "Repeated"
                MainWindow.MyDayInstance.LoadTasksToMyDay()
                MainWindow.ImportantInstance.LoadTasksToImportant()
                MainWindow.PlannedInstance.LoadTasksToPlanned()
                MainWindow.TasksInstance.LoadTasksToTasks()
            Case "Important"
                MainWindow.MyDayInstance.LoadTasksToMyDay()
                MainWindow.RepeatedInstance.LoadTasksToRepeated()
                MainWindow.PlannedInstance.LoadTasksToPlanned()
                MainWindow.TasksInstance.LoadTasksToTasks()
            Case "Planned"
                MainWindow.MyDayInstance.LoadTasksToMyDay()
                MainWindow.RepeatedInstance.LoadTasksToRepeated()
                MainWindow.ImportantInstance.LoadTasksToImportant()
                MainWindow.TasksInstance.LoadTasksToTasks()
            Case "Tasks"
                MainWindow.MyDayInstance.LoadTasksToMyDay()
                MainWindow.RepeatedInstance.LoadTasksToRepeated()
                MainWindow.ImportantInstance.LoadTasksToImportant()
                MainWindow.PlannedInstance.LoadTasksToPlanned()
        End Select
    End Sub

End Module
