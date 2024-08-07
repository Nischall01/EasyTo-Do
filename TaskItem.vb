Public Class TaskItem
    Public Property Task As String
    Public Property TaskID As Integer
    Public Property IsDone As Boolean

    Public Sub New(task As String, taskID As Integer, isDone As Boolean)
        Me.Task = task
        Me.TaskID = taskID
        Me.IsDone = isDone
    End Sub

    Public Overrides Function ToString() As String
        Return Task
    End Function
End Class
