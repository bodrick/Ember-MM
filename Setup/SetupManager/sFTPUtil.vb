Imports System.Collections
Imports Tamir.SharpSsh

Namespace sharpSsh
    ''' <summary>
    ''' Summary description for Util.
    ''' </summary>
    Public Class Util

        Public Shared Sub DownloadSiteData()
            Try
                Dim input As SshConnectionInfo = Util.GetSettings()
                Dim sshCp As SshTransferProtocolBase

                sshCp = New Sftp(input.Host, input.User)
                sshCp.Password = input.Pass
                'connect to ftp
                sshCp.Connect()

                'Download Files
                frmMainManager.Label1.Text = "Download Files: WhatsNew.txt"
                Application.DoEvents()
                sshCp.[Get](input.RemotePath & "WhatsNew.txt", "Site\WhatsNew.txt")

                frmMainManager.Label1.Text = "Download Files: versionlist.xml"
                Application.DoEvents()
                sshCp.[Get](input.RemotePath & "versionlist.xml", "Site\versionlist.xml")

                frmMainManager.Label1.Text = "Download Files: versions.xml"
                Application.DoEvents()
                sshCp.[Get](input.RemotePath & "versions.xml", "Site\versions.xml")

                'Close connection
                sshCp.Close()

            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function GetSettings() As SshConnectionInfo
            Dim info As New SshConnectionInfo()
            info.Host = frmMainManager.TextBox3.Text
            info.User = frmMainManager.TextBox1.Text
            info.Pass = frmMainManager.TextBox2.Text
            info.RemotePath = "/home/pfs/project/e/em/emm-r/updates/"
            Return info
        End Function

        ''' <summary>
        ''' Get input from the user
        ''' </summary>
        Public Shared Function GetInput() As SshConnectionInfo
            Dim info As New SshConnectionInfo()
            Console.Write("Enter Remote Host: ")
            info.Host = Console.ReadLine()
            Console.Write("Enter Username: ")
            info.User = Console.ReadLine()

            Console.Write("Use publickey authentication? [Yes|No] :")
            Dim resp As String = Console.ReadLine()
            If resp.ToLower().StartsWith("y") Then
                Console.Write("Enter identity key filename: ")
                info.IdentityFile = Console.ReadLine()
            Else
                Console.Write("Enter Password: ")
                info.Pass = Console.ReadLine()
            End If
            Console.WriteLine()
            Return info
        End Function
    End Class

    Public Structure SshConnectionInfo
        Public Host As String
        Public User As String
        Public Pass As String
        Public RemotePath As String
        Public IdentityFile As String
    End Structure
End Namespace
