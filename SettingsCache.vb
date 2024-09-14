Module SettingsCache
    ' Caching for Frequently accessed settings

    Public ReadOnly connectionString As String = My.Settings.ConnectionString
    Public ReadOnly TaskPropertiesSidebarStateOnStart As String = My.Settings.TaskPropertiesSidebarStateOnStart
    Public ReadOnly DefaultTaskFont As String = My.Settings.DefaultTaskFont

    Public onDeleteAskForConfirmation As Boolean = My.Settings.OnDeleteAskForConfirmation
    Public SortByCompletionStatus As Boolean = My.Settings.SortByCompletionStatus
    Public HideCompletedTasks As Boolean = My.Settings.HideCompletedTasks
    Public ColorScheme As String = My.Settings.ColorScheme
    Public TimeFormat As String = My.Settings.TimeFormat
    Public SelectedTaskFont As Font = My.Settings.SelectedTaskFont

    ' Method to update the cache
    Public Sub UpdateSettingsCache()
        onDeleteAskForConfirmation = My.Settings.OnDeleteAskForConfirmation
        SortByCompletionStatus = My.Settings.SortByCompletionStatus
        HideCompletedTasks = My.Settings.HideCompletedTasks
        ColorScheme = My.Settings.ColorScheme
        TimeFormat = My.Settings.TimeFormat
        SelectedTaskFont = My.Settings.SelectedTaskFont
    End Sub

End Module