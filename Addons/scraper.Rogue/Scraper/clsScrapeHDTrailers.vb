Imports System.Collections.Specialized
Imports EmberAPI

Public Class clsScrapeHDTrailers

    Shared Function GetTrailerURL() As String
        Dim qualityPreference As String = ""

        Dim nvc As NameValueCollection = GetDownloadUrls("")
        If nvc Is Nothing OrElse nvc.Count = 0 Then
            Return String.Empty
        End If

        Dim theURL As String = GetPreferredURL(nvc, New String() {"720p", "480p"}, qualityPreference)

        Return theURL
    End Function

    Shared Function GetDownloadUrls(ByVal link As String) As NameValueCollection
        Try
            Dim nvc = New NameValueCollection()

            Dim sHTTP As New HTTP
            Dim HTML As String = sHTTP.DownloadData(link)
            sHTTP = Nothing

            Dim pos As Integer = HTML.IndexOf("Download</strong>:")
            If (pos = -1) Then Return nvc

            ' find the urls for the movies, extract the string following "Download:
            Dim tempString As String = HTML.Substring(pos + 18)
            ' find the end of the screen line (a </p> or a <br />)
            Dim tempStringArray As String() = tempString.Split(New String() {"</p>", "<br"}, StringSplitOptions.None)
            tempString = tempStringArray(0)

            ' extract all the individual links from the tempString
            ' Sample link: [0] = "<a href=\"http://movies.apple.com/movies/magnolia_pictures/twolovers/twolovers-clip_h480p.mov\">480p</a>"
            tempStringArray = tempString.Split(New String() {","}, StringSplitOptions.None)

            For i As Integer = 0 To tempStringArray.Length - 1
                Dim s1 As String = tempStringArray(i).Substring(tempStringArray(i).IndexOf(">") + 1, (tempStringArray(i).IndexOf("</a>") - tempStringArray(i).IndexOf(">") - 1))
                Dim s2 As String = tempStringArray(i).Substring(tempStringArray(i).IndexOf("http"), tempStringArray(i).IndexOf(""">") - tempStringArray(i).IndexOf("http"))

                nvc.Add(s1, s2)
            Next

            Return nvc

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Shared Function GetPreferredURL(ByVal nvc As NameValueCollection, ByVal quality As String(), ByRef qualPref As String) As String
        Try
            Dim tempString2 As String = String.Empty
            'Need a loop here to pick highest priority quality. 

            For i As Integer = 0 To quality.Length - 1
                'Does a trailer of the preferred quality exist? If so, set it.. if not, try the next one
                tempString2 = nvc.Get(quality(i))
                If Not String.IsNullOrEmpty(tempString2) Then
                    tempString2 = nvc.Get(quality(i)).Replace("amp;", "")
                    qualPref = quality(i)

                    'If you find one with the proper key, jump out of the for-loop
                    If Not String.IsNullOrEmpty(tempString2) Then Exit For
                End If
            Next


            Return tempString2

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
