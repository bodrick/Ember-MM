Imports System.Net
Imports EmberMediaManger.API
Imports System.IO

Namespace Classes
    Public Class Http
        Public Shared Function DownloadImage(url As String) As Image
            Dim returnImage As Bitmap = Nothing
            Try
                Dim wc As New WebClient()
                If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                    Dim wProxy As New WebProxy(Master.eSettings.ProxyURI, Master.eSettings.ProxyPort)
                    wProxy.BypassProxyOnLocal = True
                    If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) AndAlso _
                       Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.Password) Then
                        wProxy.Credentials = Master.eSettings.ProxyCreds
                    Else
                        wProxy.Credentials = CredentialCache.DefaultCredentials
                    End If
                    wc.Proxy = wProxy
                End If
                Dim dataBuffer As Byte() = wc.DownloadData(Url)

                Using stream As New MemoryStream(dataBuffer)
                    returnImage = New Bitmap(stream)
                End Using
            Catch ex As Exception

            End Try
            Return returnImage
        End Function

        Public Shared Function DownloadImages(urls As List(Of String)) As List(Of Image)            
            Dim images As New List(Of Image)
            Try
                Dim wc As New WebClient()
                If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                    Dim wProxy As New WebProxy(Master.eSettings.ProxyURI, Master.eSettings.ProxyPort)
                    wProxy.BypassProxyOnLocal = True
                    If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) AndAlso _
                       Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.Password) Then
                        wProxy.Credentials = Master.eSettings.ProxyCreds
                    Else
                        wProxy.Credentials = CredentialCache.DefaultCredentials
                    End If
                    wc.Proxy = wProxy
                End If
                For Each url In urls
                    Dim returnImage As Bitmap = Nothing
                    Try
                        Dim dataBuffer As Byte() = wc.DownloadData(url)

                        Using stream As New MemoryStream(dataBuffer)
                            returnImage = New Bitmap(stream)
                        End Using
                        If (returnImage IsNot Nothing) Then
                            images.Add(returnImage)
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception

            End Try
            Return images
        End Function

        Public Shared Function DownloadData(url As String) As String
            Dim returnData As String = String.Empty
            Try
                Dim wc As New WebClient()
                If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                    Dim wProxy As New WebProxy(Master.eSettings.ProxyURI, Master.eSettings.ProxyPort)
                    wProxy.BypassProxyOnLocal = True
                    If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) AndAlso _
                       Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.Password) Then
                        wProxy.Credentials = Master.eSettings.ProxyCreds
                    Else
                        wProxy.Credentials = CredentialCache.DefaultCredentials
                    End If
                    wc.Proxy = wProxy
                End If
                returnData = wc.DownloadString(Url)
            Catch ex As Exception

            End Try
            Return returnData
        End Function

        Public Shared Function VerfiyUrl(url As String) As Boolean
            Dim returnData As Boolean = False
            Try
                Dim wc As New WebClient()
                If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                    Dim wProxy As New WebProxy(Master.eSettings.ProxyURI, Master.eSettings.ProxyPort)
                    wProxy.BypassProxyOnLocal = True
                    If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) AndAlso _
                       Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.Password) Then
                        wProxy.Credentials = Master.eSettings.ProxyCreds
                    Else
                        wProxy.Credentials = CredentialCache.DefaultCredentials
                    End If
                    wc.Proxy = wProxy
                End If
                If wc.DownloadData(Url).Length > 0 Then
                    returnData = True
                End If
            Catch ex As Exception

            End Try
            Return returnData
        End Function

        Public Shared Function DownloadZip(url As String) As Byte()
            Dim returnData As Byte() = Nothing
            Try
                Dim wc As New WebClient()
                If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                    Dim wProxy As New WebProxy(Master.eSettings.ProxyURI, Master.eSettings.ProxyPort)
                    wProxy.BypassProxyOnLocal = True
                    If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) AndAlso _
                       Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.Password) Then
                        wProxy.Credentials = Master.eSettings.ProxyCreds
                    Else
                        wProxy.Credentials = CredentialCache.DefaultCredentials
                    End If
                    wc.Proxy = wProxy
                End If
                returnData = wc.DownloadData(Url)
            Catch ex As Exception

            End Try
            Return returnData
        End Function
    End Class
End Namespace