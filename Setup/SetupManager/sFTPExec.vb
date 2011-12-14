Imports System.Collections
Imports Tamir.SharpSsh

Namespace sharpSsh
    ''' <summary>
    ''' Summary description for SshExeTest.
    ''' </summary>
    Public Class SshExeTest
        Public Shared Sub RunExample()
            Try
                Dim input As SshConnectionInfo = Util.GetInput()
                Dim exec As New SshExec(input.Host, input.User)
                If input.Pass IsNot Nothing Then
                    exec.Password = input.Pass
                End If
                If input.IdentityFile IsNot Nothing Then
                    exec.AddIdentityFile(input.IdentityFile)
                End If

                Console.Write("Connecting...")
                exec.Connect()
                Console.WriteLine("OK")
                While True
                    Console.Write("Enter a command to execute ['Enter' to cancel]: ")
                    Dim command As String = Console.ReadLine()
                    If command = "" Then
                        Exit While
                    End If
                    Dim output As String = exec.RunCommand(command)
                    Console.WriteLine(output)
                End While
                Console.Write("Disconnecting...")
                exec.Close()
                Console.WriteLine("OK")
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
        End Sub
    End Class
End Namespace
