Imports IWshRuntimeLibrary
Imports System.IO

Module StartupShortcut
    Sub CreateStartupShortcut(StartupType As Integer)
        ' Path to the Startup folder
        Dim startupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        ' Shortcut name and path
        Dim shortcutName As String = "EasyTo-Do.lnk"
        Dim shortcutPath As String = Path.Combine(startupFolder, shortcutName)

        Dim targetPath As String = Application.ExecutablePath

        ' Create WshShell and shortcut
        Dim shell As New WshShell()
        Dim shortcut As IWshShortcut = CType(shell.CreateShortcut(shortcutPath), IWshShortcut)

        shortcut.TargetPath = targetPath

        If StartupType = 2 Then
            shortcut.Arguments = "--silent"
        End If

        shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath)
        shortcut.WindowStyle = 1
        shortcut.Description = "EasyTo-Do Shortcut"
        shortcut.Save()
    End Sub

    Sub DeleteStartupShortcut()
        ' Path to the Startup folder
        Dim startupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        ' Name of the shortcut to delete
        Dim shortcutName As String = "EasyTo-Do.lnk"
        Dim shortcutPath As String = Path.Combine(startupFolder, shortcutName)

        ' Check if the file exists and delete it
        If IO.File.Exists(shortcutPath) Then
            IO.File.Delete(shortcutPath)
        End If
    End Sub

End Module
