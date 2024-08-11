﻿Imports System.ComponentModel

Public Class DueDate_Dialog
    Public DueDate_SelectedTaskID As Integer

    Private AlreadySetDueDate As Date

    Private dt As New DataTable()

    Private connectionString As String = My.Settings.ConnectionString

    Private Sub DueDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None

        LoadTable()
        GetAlreadySetDueDate()
        DueDateInitialization()
    End Sub

    Private Sub CloseReminder_Button_Click(sender As Object, e As EventArgs) Handles CloseReminder_Button.Click
        Me.Close()
    End Sub

    Private Sub DueDateInitialization()
        MonthCalendar1.SetDate(AlreadySetDueDate)
    End Sub

#Region "Database and DataTables"
    Private Sub LoadTable()
        Dim query As String = "SELECT * FROM Tasks"
        Try
            Using connection As New SqlCeConnection(connectionString)
                Using command As New SqlCeCommand(query, connection)
                    Using adapter As New SqlCeDataAdapter(command)
                        connection.Open()
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As SqlCeException
            MessageBox.Show("A SQL error occurred: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub



    Private Sub GetAlreadySetDueDate()
        For Each row As DataRow In dt.Rows
            If row("TaskID") = DueDate_SelectedTaskID Then
                If IsDBNull(row("DueDate")) Then
                    AlreadySetDueDate = Nothing
                Else
                    AlreadySetDueDate = row("DueDate")
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SelectedDate As DateTime = MonthCalendar1.SelectionEnd
        DueDate.SetDueDate(SelectedDate.Date, DueDate_SelectedTaskID)
        Me.Close()
    End Sub
#End Region
End Class