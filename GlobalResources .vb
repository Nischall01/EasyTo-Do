Module GlobalResources

    ' Image cache variables
    Public ReadOnly UncheckedImportantIcon As Image = My.Resources._1

    Public ReadOnly CheckedImportantIcon As Image = My.Resources._2
    Public ReadOnly DisabledImportantIcon As Image = My.Resources._3

    Public ReadOnly connectionString As String = My.Settings.ConnectionString
    Public ReadOnly importantTaskIndicator As String = "[ ! ]"
    Public ReadOnly repeatedTaskIndicator As String = "[R]"
End Module