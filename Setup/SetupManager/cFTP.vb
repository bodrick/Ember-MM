' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class FTPClass

    #Region "Fields"

    Private Shared BLOCK_SIZE As Integer = 512

    Private ASCII As Encoding = Encoding.ASCII
    Private buffer As Byte() = New Byte(BLOCK_SIZE - 1) {}
    Private bytes As Integer
    Private clientSocket As Socket
    Private debug As Boolean
    Private logined As Boolean
    Private mes As String
    Private remoteHost As String
    Private remotePass As String
    Private remotePath As String
    Private remotePort As Integer
    Private remoteUser As String
    Private reply As String
    Private retValue As Integer
    Private timeOut As Integer = 10

    #End Region 'Fields

    #Region "Constructors"

    Public Sub New()
        remoteHost = "192.168.1.1"
        remotePath = "."
        remoteUser = ""
        remotePass = ""
        remotePort = 21
        debug = False
        logined = False
    End Sub

    #End Region 'Constructors

    #Region "Methods"

    '''
    ''' Change the current working directory on the remote FTP server.
    '''
    '''
    Public Sub chdir(ByVal dirName As String)
        If dirName.Equals(".") Then
            Exit Sub
        End If
        If Not logined Then
            login()
        End If
        sendCommand("CWD " & dirName)
        If retValue <> 250 Then
            Throw New IOException(reply.Substring(4))
        End If
        Me.remotePath = dirName
        Console.WriteLine("Current directory is " & remotePath)
    End Sub

    '''
    ''' Change Permissions
    '''
    '''
    Public Sub chmod(ByVal chmod As String, ByVal fieName As String)
        If Not logined Then
            login()
        End If
        sendCommand("SITE CHMOD " & chmod.ToString & " " & fieName)
        If retValue <> 200 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Close the FTP connection.
    '''
    Public Sub close()
        If clientSocket IsNot Nothing Then
            sendCommand("QUIT")
        End If
        cleanup()
        Console.WriteLine("Closing...")
    End Sub

    '''
    ''' Delete a file from the remote FTP server.
    '''
    '''
    Public Sub deleteRemoteFile(ByVal fileName As String)
        If Not logined Then
            login()
        End If
        sendCommand("DELE " & fileName)
        If retValue <> 250 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Download a file to the Assembly's local directory,
    ''' keeping the same file name.
    '''
    '''
    Public Sub download(ByVal remFileName As String)
        download(remFileName, "", False)
    End Sub

    '''
    ''' Download a remote file to the Assembly's local directory,
    ''' keeping the same file name, and set the resume flag.
    '''
    '''
    '''
    Public Sub download(ByVal remFileName As String, ByVal [resume] As Boolean)
        download(remFileName, "", [resume])
    End Sub

    '''
    ''' Download a remote file to a local file name which can include
    ''' a path. The local file name will be created or overwritten,
    ''' but the path must exist.
    '''
    '''
    '''
    Public Sub download(ByVal remFileName As String, ByVal locFileName As String)
        download(remFileName, locFileName, False)
    End Sub

    '''
    ''' Download a remote file to a local file name which can include
    ''' a path, and set the resume flag. The local file name will be
    ''' created or overwritten, but the path must exist.
    '''
    '''
    '''
    '''
    Public Sub download(ByVal remFileName As String, ByVal locFileName As String, ByVal [resume] As Boolean)
        If Not logined Then
            login()
        End If
        setBinaryMode(True)
        Console.WriteLine((("Downloading file " & remFileName & " from ") + remoteHost & "/") + remotePath)
        If locFileName.Equals("") Then
            locFileName = remFileName
        End If
        If Not File.Exists(locFileName) Then
            Dim st As Stream = File.Create(locFileName)
            st.Close()
        End If
        Dim output As New FileStream(locFileName, FileMode.Open)
        Dim cSocket As Socket = createDataSocket()
        Dim offset As Long = 0
        If [resume] Then
            offset = output.Length
            If offset > 0 Then
                sendCommand("REST " & offset)
                If retValue <> 350 Then
                    'throw new IOException(reply.Substring(4));
                    'Some servers may not support resuming.
                    offset = 0
                End If
            End If
            If offset > 0 Then
                If debug Then
                    Console.WriteLine("seeking to " & offset)
                End If
                Dim npos As Long = output.Seek(offset, SeekOrigin.Begin)
                Console.WriteLine("new pos=" & npos)
            End If
        End If
        sendCommand("RETR " & remFileName)
        If Not (retValue = 150 OrElse retValue = 125) Then
            Return
            'Throw New IOException(reply.Substring(4))
        End If

        Try
            While True
                bytes = cSocket.Receive(buffer, buffer.Length, 0)
                output.Write(buffer, 0, bytes)
                If bytes <= 0 Then
                    Exit While
                End If
            End While
        Catch ex As Exception
        End Try
        output.Close()
        If cSocket.Connected Then
            cSocket.Close()
        End If
        Console.WriteLine("")
        readReply()
        If Not (retValue = 226 OrElse retValue = 250) Then
            Return
            'Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Return a string array containing the remote directory's file list.
    '''
    '''
    '''
    Public Function getFileList(ByVal mask As String) As String()
        If Not logined Then
            login()
        End If
        Dim cSocket As Socket = createDataSocket()
        sendCommand("NLST " & mask)
        If Not (retValue = 150 OrElse retValue = 125) Then
            Throw New IOException(reply.Substring(4))
        End If
        mes = ""
        Dim timeout_ As DateTime = DateTime.Now.AddSeconds(timeOut)
        While (timeout_ > DateTime.Now)
            Dim bytes As Integer = cSocket.Receive(buffer, buffer.Length, 0)
            mes += ASCII.GetString(buffer, 0, bytes)
            'If bytes < buffer.Length Then
            If bytes = 0 Then
                Exit While
            End If
        End While

        Dim seperator As Char() = {ControlChars.Lf}
        Dim mess As String() = mes.Split(seperator)
        For c = 0 To mess.Length - 1
            mess(c) = mess(c).Trim
        Next
        cSocket.Close()
        readReply()
        If retValue <> 226 Then
            Throw New IOException(reply.Substring(4))
        End If
        Return mess
    End Function

    '''
    ''' Return the size of a file.
    '''
    '''
    '''
    Public Function getFileSize(ByVal fileName As String) As Long
        If Not logined Then
            login()
        End If
        sendCommand("SIZE " & fileName)
        Dim size As Long = 0
        If retValue = 213 Then
            size = Int64.Parse(reply.Substring(4))
        Else
            Throw New IOException(reply.Substring(4))
        End If
        Return size
    End Function

    '''
    ''' Return the name of the current FTP server.
    '''
    ''' Server name
    Public Function getRemoteHost() As String
        Return remoteHost
    End Function

    '''
    ''' Return the current remote directory path.
    '''
    ''' The current remote directory path.
    Public Function getRemotePath() As String
        Return remotePath
    End Function

    '''
    ''' Return the current port number.
    '''
    ''' Current port number
    Public Function getRemotePort() As Integer
        Return remotePort
    End Function

    '''
    ''' Login to the remote server.
    '''
    Public Sub login()
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ep As New IPEndPoint(Dns.GetHostEntry(remoteHost).AddressList(0), remotePort)
        Try
            clientSocket.Connect(ep)
        Catch generatedExceptionName As Exception
            Throw New IOException("Couldn't connect to remote server")
        End Try
        readReply()
        If retValue <> 220 Then
            close()
            Throw New IOException(reply.Substring(4))
        End If
        If debug Then
            Console.WriteLine("USER " & remoteUser)
        End If
        sendCommand("USER " & remoteUser)
        If Not (retValue = 331 OrElse retValue = 230) Then
            cleanup()
            Throw New IOException(reply.Substring(4))
        End If
        If retValue <> 230 Then
            If debug Then
                Console.WriteLine("PASS xxx")
            End If
            sendCommand("PASS " & remotePass)
            If Not (retValue = 230 OrElse retValue = 202) Then
                cleanup()
                Throw New IOException(reply.Substring(4))
            End If
        End If
        logined = True
        Console.WriteLine("Connected to " & remoteHost)
        chdir(remotePath)
    End Sub

    '''
    ''' Create a directory on the remote FTP server.
    '''
    '''
    Public Sub mkdir(ByVal dirName As String)
        If Not logined Then
            login()
        End If
        sendCommand("MKD " & dirName)
        If retValue > 400 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Rename a file on the remote FTP server.
    '''
    '''
    '''
    Public Sub renameRemoteFile(ByVal oldFileName As String, ByVal newFileName As String)
        If Not logined Then
            login()
        End If
        sendCommand("RNFR " & oldFileName)
        If retValue <> 350 Then
            Throw New IOException(reply.Substring(4))
        End If
        ' known problem
        ' rnto will not take care of existing file.
        ' i.e. It will overwrite if newFileName exist
        sendCommand("RNTO " & newFileName)
        If retValue <> 250 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Delete a directory on the remote FTP server.
    '''
    '''
    Public Sub rmdir(ByVal dirName As String)
        If Not logined Then
            login()
        End If
        sendCommand("RMD " & dirName)
        If retValue <> 250 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' If the value of mode is true, set binary mode for downloads.
    ''' Else, set Ascii mode.
    '''
    '''
    Public Sub setBinaryMode(ByVal mode As Boolean)
        If mode Then
            sendCommand("TYPE I")
        Else
            sendCommand("TYPE A")
        End If
        If retValue <> 200 Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    '''
    ''' Set debug mode.
    '''
    '''
    Public Sub setDebug(ByVal debug As Boolean)
        Me.debug = debug
    End Sub

    '''
    ''' Set the name of the FTP server to connect to.
    '''
    ''' Server name
    Public Sub setRemoteHost(ByVal remoteHost As String)
        Me.remoteHost = remoteHost
    End Sub

    '''
    ''' Set the password to user for logging into the remote server.
    '''
    ''' Password
    Public Sub setRemotePass(ByVal remotePass As String)
        Me.remotePass = remotePass
    End Sub

    '''
    ''' Set the remote directory path.
    '''
    ''' The remote directory path
    Public Sub setRemotePath(ByVal remotePath As String)
        Me.remotePath = remotePath
    End Sub

    '''
    ''' Set the port number to use for FTP.
    '''
    ''' Port number
    Public Sub setRemotePort(ByVal remotePort As Integer)
        Me.remotePort = remotePort
    End Sub

    '''
    ''' Set the user name to use for logging into the remote server.
    '''
    ''' Username
    Public Sub setRemoteUser(ByVal remoteUser As String)
        Me.remoteUser = remoteUser
    End Sub

    '''
    ''' Upload a file.
    '''
    '''
    Public Sub upload(ByVal fileName As String)
        upload(fileName, False)
    End Sub

    '''
    ''' Upload a file and set the resume flag.
    '''
    '''
    '''
    Public Sub upload(ByVal fileName As String, ByVal [resume] As Boolean)
        If Not logined Then
            login()
        End If
        Dim cSocket As Socket = createDataSocket()
        Dim offset As Long = 0
        setBinaryMode(True)
        If [resume] Then
            Try
                offset = getFileSize(Path.GetFileName(fileName))
            Catch generatedExceptionName As Exception
                offset = 0
            End Try
        End If
        If offset > 0 Then
            sendCommand("REST " & offset)
            If retValue <> 350 Then
                'throw new IOException(reply.Substring(4));
                'Remote server may not support resuming.
                offset = 0
            End If
        End If
        sendCommand("STOR " & Path.GetFileName(fileName))
        If Not (retValue = 125 OrElse retValue = 150) Then
            Throw New IOException(reply.Substring(4))
        End If
        ' open input stream to read source file
        Dim input As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        If offset <> 0 Then
            If debug Then
                Console.WriteLine("seeking to " & offset)
            End If
            input.Seek(offset, SeekOrigin.Begin)
        End If
        Console.WriteLine(("Uploading file " & fileName & " to ") + remotePath)
        Dim filesize = FileLen(fileName)
        While (offset < filesize)
            bytes = input.Read(buffer, 0, buffer.Length)
            cSocket.Send(buffer, bytes, 0)
            offset += bytes
            Application.DoEvents()
        End While
        input.Close()
        Console.WriteLine("")
        If cSocket.Connected Then
            cSocket.Close()
        End If
        readReply()
        If Not (retValue = 226 OrElse retValue = 250) Then
            Throw New IOException(reply.Substring(4))
        End If
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private Sub cleanup()
        If clientSocket IsNot Nothing Then
            clientSocket.Close()
            clientSocket = Nothing
        End If
        logined = False
    End Sub

    Private Function createDataSocket() As Socket
        sendCommand("PASV")
        If retValue <> 227 Then
            Throw New IOException(reply.Substring(4))
        End If
        Dim index1 As Integer = reply.IndexOf("("c)
        Dim index2 As Integer = reply.IndexOf(")"c)
        Dim ipData As String = reply.Substring(index1 + 1, index2 - index1 - 1)
        Dim parts As Integer() = New Integer(5) {}
        Dim len As Integer = ipData.Length
        Dim partCount As Integer = -1
        Dim buf As String = ""
        Dim i As Integer = 0
        While i < len AndAlso partCount <= 6
            Dim ch As Char = [Char].Parse(ipData.Substring(i, 1))
            If [Char].IsDigit(ch) Then
                buf += ch
            ElseIf ch <> ","c Then
                Throw New IOException("Malformed PASV reply: " & reply)
            End If
            If ch = ","c OrElse i + 1 = len Then
                Try
                    parts(System.Math.Max(System.Threading.Interlocked.Increment(partCount), partCount - 1)) = Int32.Parse(buf)
                    buf = ""
                Catch generatedExceptionName As Exception
                    Throw New IOException("Malformed PASV reply: " & reply)
                End Try
            End If
            i += 1
        End While
        Dim ipAddress As String = (((CStr(parts(0)) & ".") + CStr(parts(1)) & ".") + CStr(parts(2)) & ".") + CStr(parts(3))
        Dim port As Integer = (parts(4) << 8) + parts(5)
        Dim host As IPAddress()

        host = Dns.GetHostAddresses(ipAddress)
        Dim ip As IPAddress = host(0)
        Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ep As New IPEndPoint(ip, port)
        Try
            s.Connect(ep)
        Catch generatedExceptionName As Exception
            Throw New IOException("Can't connect to remote server")
        End Try
        Return s
    End Function

    Private Function readLine() As String
        While True
            bytes = clientSocket.Receive(buffer, buffer.Length, 0)
            mes += ASCII.GetString(buffer, 0, bytes)
            If bytes < buffer.Length Then
                Exit While
            End If
        End While
        Dim seperator As String() = {ControlChars.NewLine}
        Dim mess As String() = mes.Split(seperator, StringSplitOptions.RemoveEmptyEntries)
        If mess.Length > 1 Then
            mes = mess(mess.Length - 1) & ControlChars.NewLine
        Else
            mes = mess(0) & ControlChars.NewLine
        End If
        If Not mes.Substring(3, 1).Equals(" ") Then
            Return readLine()
        End If
        If debug Then
            For k As Integer = 0 To mess.Length - 1
                Console.WriteLine(mess(k))
            Next
        End If
        Return mes
    End Function

    Private Sub readReply()
        mes = ""
        reply = readLine()
        retValue = Int32.Parse(reply.Substring(0, 3))
    End Sub

    Private Sub sendCommand(ByVal command As String)
        Dim cmdBytes As Byte() = Encoding.ASCII.GetBytes((command & vbCr & vbLf).ToCharArray())
        clientSocket.Send(cmdBytes, cmdBytes.Length, 0)
        readReply()
    End Sub

    #End Region 'Methods

End Class