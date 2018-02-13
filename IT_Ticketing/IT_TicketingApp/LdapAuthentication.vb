Imports System
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices

Public Class LdapAuthentication
    Private _path As String
    Private _filterAttribute As String

    Public Sub New(ByVal path As String)
        _path = path
    End Sub

    Function IsAuthenticated(ByVal username As String, ByVal pwd As String) As String

        Dim domainAndUsername As String = "multinet.com.pk\" & username
        Dim entry As New DirectoryEntry(_path, domainAndUsername, pwd)
        Dim result As SearchResult

        Try
            'Bind to the native AdsObject to force authentication.
            Dim obj As Object = entry.NativeObject

            Dim search As New DirectorySearcher(entry)

            search.Filter = (Convert.ToString("(SAMAccountName=") & username) + ")"
            search.PropertiesToLoad.Add("cn")
            result = search.FindOne()

            If result Is Nothing Then
                Return Nothing
            End If

            'Update the new path to the user in the directory.
            _path = result.Path
            _filterAttribute = DirectCast(result.Properties("cn")(0), String)
        Catch ex As Exception
            Throw New Exception("Error authenticating user. " + ex.Message)
        End Try

        Return result.Path
    End Function

End Class
