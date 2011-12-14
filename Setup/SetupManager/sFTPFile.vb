Imports System.Collections
Imports Tamir.SharpSsh

Namespace sharpSsh
    ''' <summary>
    ''' Sample showing the use of the SSH file trasfer features of 
    ''' SharpSSH such as SFTP and SCP
    ''' </summary>
    Public Class SshFileTransferTest
        Public Shared Sub RunExample()
            Try
                Dim input As SshConnectionInfo = Util.GetInput()
                Dim proto As String = GetProtocol()
                Dim sshCp As SshTransferProtocolBase

                If proto.Equals("scp") Then
                    sshCp = New Scp(input.Host, input.User)
                Else
                    sshCp = New Sftp(input.Host, input.User)
                End If

                If input.Pass IsNot Nothing Then
                    sshCp.Password = input.Pass
                End If
                If input.IdentityFile IsNot Nothing Then
                    sshCp.AddIdentityFile(input.IdentityFile)
                End If
                'sshCp.OnTransferStart += New FileTransferEvent(AddressOf sshCp_OnTransferStart)
                'sshCp.OnTransferProgress += New FileTransferEvent(AddressOf sshCp_OnTransferProgress)
                'sshCp.OnTransferEnd += New FileTransferEvent(AddressOf sshCp_OnTransferEnd)

                Console.Write("Connecting...")
                sshCp.Connect()
                Console.WriteLine("OK")

                While True
                    Dim direction As String = GetTransferDirection()
                    If direction.Equals("to") Then
                        Dim lfile As String = GetArg("Enter local file ['Enter to cancel']")
                        If lfile = "" Then
                            Exit While
                        End If
                        Dim rfile As String = GetArg("Enter remote file ['Enter to cancel']")
                        If rfile = "" Then
                            Exit While
                        End If
                        sshCp.Put(lfile, rfile)
                    Else
                        Dim rfile As String = GetArg("Enter remote file ['Enter to cancel']")
                        If rfile = "" Then
                            Exit While
                        End If
                        Dim lpath As String = GetArg("Enter local path ['Enter to cancel']")
                        If lpath = "" Then
                            Exit While
                        End If
                        sshCp.[Get](rfile, lpath)
                    End If
                End While

                Console.Write("Disconnecting...")
                sshCp.Close()
                Console.WriteLine("OK")
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
        End Sub

        Public Shared Function GetProtocol() As String
            Dim proto As String = ""
            While True
                Console.Write("Enter SSH transfer protocol [SCP|SFTP]: ")
                proto = Console.ReadLine()
                If proto.ToLower().Equals("") Then
                    Exit While
                End If
                If proto.ToLower().Equals("scp") OrElse proto.ToLower().Equals("sftp") Then
                    Exit While
                End If
                Console.Write("Bad input, ")
            End While
            Return proto
        End Function

        Public Shared Function GetTransferDirection() As String
            Dim dir As String = ""
            While True
                Console.Write("Enter transfer direction [To|From]: ")
                dir = Console.ReadLine()
                If dir.ToLower().Equals("") Then
                    Exit While
                End If
                If dir.ToLower().Equals("to") OrElse dir.ToLower().Equals("from") Then
                    Exit While
                End If
                Console.Write("Bad input, ")
            End While
            Return dir
        End Function

        Public Shared Function GetArg(ByVal msg As String) As String
            Console.Write(msg & ": ")
            Return Console.ReadLine()
        End Function

        'Shared progressBar As ConsoleProgressBar

        Private Shared Sub sshCp_OnTransferStart(ByVal src As String, ByVal dst As String, ByVal transferredBytes As Integer, ByVal totalBytes As Integer, ByVal message As String)
            Console.WriteLine()
            'progressBar = New ConsoleProgressBar()
            'progressBar.Update(transferredBytes, totalBytes, message)
        End Sub

        Private Shared Sub sshCp_OnTransferProgress(ByVal src As String, ByVal dst As String, ByVal transferredBytes As Integer, ByVal totalBytes As Integer, ByVal message As String)
            'If progressBar IsNot Nothing Then
            'ProgressBar.Update(transferredBytes, totalBytes, message)
            'End If
        End Sub

        Private Shared Sub sshCp_OnTransferEnd(ByVal src As String, ByVal dst As String, ByVal transferredBytes As Integer, ByVal totalBytes As Integer, ByVal message As String)
            'If progressBar IsNot Nothing Then
            'ProgressBar.Update(transferredBytes, totalBytes, message)
            'ProgressBar = Nothing
            'End If
        End Sub
    End Class
End Namespace
