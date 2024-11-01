Module SettingsCache
    ' Caching for Frequently accessed settings

    Public ReadOnly connectionString As String = My.Settings.ConnectionString
    Public ReadOnly TaskPropertiesSidebarStateOnStart As String = My.Settings.TaskPropertiesSidebarStateOnStart

    Public OnDeleteAskForConfirmation As Boolean = My.Settings.OnDeleteAskForConfirmation
    Public SortByCompletionStatus As Boolean = My.Settings.SortByCompletionStatus
    Public HideCompletedTasks As Boolean = My.Settings.HideCompletedTasks
    Public ColorScheme As String = My.Settings.ColorScheme
    Public TimeFormat As String = My.Settings.TimeFormat
    Public SelectedTaskFont As Font = My.Settings.SelectedTaskFont
    Public OnCloseRunInTheBackground As Boolean = My.Settings.OnCloseRunInTheBackground

    ' Method to update the cache
    Public Sub UpdateSettingsCache()
        OnDeleteAskForConfirmation = My.Settings.OnDeleteAskForConfirmation
        SortByCompletionStatus = My.Settings.SortByCompletionStatus
        HideCompletedTasks = My.Settings.HideCompletedTasks
        ColorScheme = My.Settings.ColorScheme
        TimeFormat = My.Settings.TimeFormat
        SelectedTaskFont = My.Settings.SelectedTaskFont
        OnCloseRunInTheBackground = My.Settings.OnCloseRunInTheBackground
    End Sub

End Module