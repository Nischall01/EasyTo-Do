Imports System.Net.Http
Imports System.Net.Http.Json
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Threading.Tasks

Public Class GitHubReleaseChecker
    Private Shared ReadOnly _httpClient As New HttpClient()

    ' Check for internet connection by pinging a known reliable server
    Public Shared Function IsInternetAvailable() As Boolean
        Try
            ' Try pinging Google's public DNS server (8.8.8.8) to check connectivity
            Using ping As New Ping()
                Dim reply As PingReply = ping.Send("8.8.8.8", 2000)
                Return reply.Status = IPStatus.Success
            End Using
        Catch ex As PingException
            Return False
        Catch ex As SocketException
            Return False
        End Try
    End Function

    Public Shared Async Function GetLatestReleaseAsync(owner As String, repo As String) As Task(Of String)

        ' Check if there is an internet connection
        If Not GitHubReleaseChecker.IsInternetAvailable() Then
            Return "No internet connection."
        End If

        ' GitHub API URL to get the latest release
        Dim url As String = $"https://api.github.com/repos/{owner}/{repo}/releases/latest"

        ' GitHub API requires a user-agent header
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "EasyTo-Do")

        Try
            ' Make the request and deserialize the response as JSON
            Dim release As GitHubRelease = Await _httpClient.GetFromJsonAsync(Of GitHubRelease)(url)

            If release IsNot Nothing Then
                Return $"Latest Release: {release.Tag_name}, Published at: {release.Published_at}"
            End If
        Catch ex As HttpRequestException
            Console.WriteLine("Error fetching release: " & ex.Message)
        End Try

        Return "Could not get the latest release."
    End Function

    Public Shared Async Function GetLatestRelease_TagAsync(owner As String, repo As String) As Task(Of String)

        ' Check if there is an internet connection
        If Not GitHubReleaseChecker.IsInternetAvailable() Then
            Return "No internet connection."
        End If

        ' GitHub API URL to get the latest release
        Dim url As String = $"https://api.github.com/repos/{owner}/{repo}/releases/latest"

        ' GitHub API requires a user-agent header
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "EasyTo-Do")

        Try
            ' Make the request and deserialize the response as JSON
            Dim release As GitHubRelease = Await _httpClient.GetFromJsonAsync(Of GitHubRelease)(url)

            If release IsNot Nothing Then
                Return release.Tag_name
            End If
        Catch ex As HttpRequestException
            Console.WriteLine("Error fetching release: " & ex.Message)
        End Try

        Return "Could not get the latest release."
    End Function

End Class

' Define a model for the release response
Public Class GitHubRelease
    Public Property Tag_name As String
    Public Property Published_at As DateTime
End Class