Public Class TaskItem
    Public Property Task As String
    Public Property ID As Integer
    Public Property IsDone As Boolean

    Public Sub New(task As String, id As Integer, isDone As Boolean)
        Me.Task = task
        Me.ID = id
        Me.IsDone = isDone
    End Sub

    Public Overrides Function ToString() As String
        Return Task
    End Function
End Class
