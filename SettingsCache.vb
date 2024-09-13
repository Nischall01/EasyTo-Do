Module SettingsCache
    ' Caching for Frequently accessed settings

    Public ReadOnly connectionString As String = My.Settings.ConnectionString
    Public ReadOnly TaskPropertiesSidebarStateOnStart As String = My.Settings.TaskPropertiesSidebarStateOnStart
    Public ReadOnly TimeFormat As String = My.Settings.TimeFormat

    Public onDeleteAskForConfirmation As Boolean = My.Settings.OnDeleteAskForConfirmation
    Public SortByCompletionStatus As Boolean = My.Settings.SortByCompletionStatus
    Public HideCompletedTasks As Boolean = My.Settings.HideCompletedTasks
    Public ColorScheme As String = My.Settings.ColorScheme

    ' Method to update the cache
    Public Sub UpdateSettingsCache()
        onDeleteAskForConfirmation = My.Settings.OnDeleteAskForConfirmation
        SortByCompletionStatus = My.Settings.SortByCompletionStatus
        HideCompletedTasks = My.Settings.HideCompletedTasks
        ColorScheme = My.Settings.ColorScheme
    End Sub

End Module