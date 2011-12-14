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

Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Resources
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Security.Permissions
Imports System.Security.AccessControl

Public Class frmMainSetup

#Region "Fields"

    Public Shared EmberVersions As New UpgradeList

    Public isSiteReady As Boolean = True
    Public CurrentEmberPlatform As String
    Public CurrentEmberVersion As String
    Public ExeCurrentEmberVersion As String
    Public DEBUG As Boolean = False 'So I can Debug without a Web Server
    Public DoInstall As Boolean = True
    Public emberAllFounds As New List(Of String)
    Public emberPath As String
    Public ExitMe As Boolean = False
    Public Final As Boolean = False
    Public Force As Boolean = False
    Public Recover As Boolean = False
    Public BlindSetup As Boolean = False
    Public mePainting As New Object
    Public NoArgs As Boolean = True
    Public MyLang As New Langs

    Public WindowsInstallPath As String
    Friend WithEvents bwDoInstall As New System.ComponentModel.BackgroundWorker
    Friend WithEvents bwFF As New System.ComponentModel.BackgroundWorker
    Friend WithEvents lblInfo As New MyLabel
    Friend WithEvents lblStatus As New MyLabel
    Private Language As String = "English_(en_US)"
    Private BackAlpha As Integer = 0
    Private BackUp As Boolean = True
    Dim bCredits As Bitmap = Nothing
    Dim CredList As New List(Of CredLine)
    Private DisablePaint As Boolean = False
    Private iLogo As Bitmap = Nothing
    Dim intcounter As Integer = 0
    Private LogoAlpha As Integer = 50
    Private LogoStop As Boolean = True
    Private LogoUp As Boolean = True
    Private NeedDoEvents As Boolean = False
    Dim PicY As Single
    Private ShowCredits As Boolean = False
    Dim SlowDown As Integer = 0
    Private w As New dlgCommands
    Private RemoteSiteFolder As String = "updates"
    Private IsBeta As Boolean = False

    Dim ProxyURI As String = ""
    Dim ProxyPort As Integer = 0
    Dim ProxyUserName As String = ""
    Dim ProxyPassword As String = ""
    Public Shared eSettings As New Settings

#End Region 'Fields

#Region "Methods"

    Public Shared Function AppPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory
    End Function

    Public Shared Function CheckIfWindows() As Boolean
        Return Environment.OSVersion.ToString.ToLower.IndexOf("windows") > 0
    End Function

    Public Shared Sub DeleteDirectory(ByVal sPath As String)
        Try
            If Directory.Exists(sPath) Then
                Dim Dirs As New ArrayList
                Try
                    Dirs.AddRange(Directory.GetDirectories(sPath))
                Catch ex As Exception
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                End Try
                For Each inDir As String In Dirs
                    DeleteDirectory(inDir)
                Next
                Dim fFiles As New ArrayList
                Try
                    fFiles.AddRange(Directory.GetFiles(sPath))
                Catch ex As Exception
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                End Try
                For Each fFile As String In fFiles
                    Try
                        File.Delete(fFile)
                    Catch ex As Exception
                        LogWrite(String.Format("--- Error: {0}", ex.Message))
                        LogWrite(ex.StackTrace)
                    End Try
                Next
                Directory.Delete(sPath, True)
            End If
        Catch ex As Exception
            LogWrite(String.Format("--- Error: {0}", ex.Message))
            LogWrite(ex.StackTrace)
        End Try
    End Sub

    Public Shared Function Is64Bit() As Boolean
        Return (IntPtr.Size = 8)
    End Function

    Public Shared Sub LogWrite(ByVal s As String)
        Dim log As New StreamWriter(Path.Combine(AppPath, "install.log"), True)
        log.WriteLine(s)
        log.Close()
    End Sub

    Public Shared Sub UncompressFile(ByVal spath As String, ByVal dpath As String)
        Dim sourceFile As FileStream = File.OpenRead(spath)
        Dim destinationFile As FileStream = File.Create(dpath)
        Try
            ' Because the uncompressed size of the file is unknown,
            ' we are imports an arbitrary buffer size.
            Dim buffer(4096) As Byte
            Dim n As Integer

            Using input As New GZipStream(sourceFile, _
                CompressionMode.Decompress, False)

                Console.WriteLine("Decompressing {0} to {1}.", sourceFile.Name, _
                    destinationFile.Name)
                Do
                    n = input.Read(buffer, 0, buffer.Length)
                    destinationFile.Write(buffer, 0, n)
                Loop While n > 0
            End Using
        Catch ex As Exception
            LogWrite(String.Format("--- Error: {0}", ex.Message))
            LogWrite(ex.StackTrace)
        End Try
        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

    Public Sub CreateSetupFolders(ByVal setupPath As String)
        'DeleteDirectory(Path.Combine(setupPath, "updates"))
        If Not Directory.Exists(Path.Combine(setupPath, "updates")) Then
            LogWrite(String.Format("--- CreateSetupFolders: {0}\updates", setupPath))
            Directory.CreateDirectory(Path.Combine(setupPath, "updates"))
        Else
            LogWrite(String.Format("--- SetupFoldersExists: {0}\updates", setupPath))
        End If
    End Sub

    Public Sub FindEmberPath()
        emberAllFounds.Clear()
        bwFF.WorkerSupportsCancellation = True
        bwFF.WorkerReportsProgress = True
        bwFF.RunWorkerAsync()
        While bwFF.IsBusy
            Application.DoEvents()
        End While
    End Sub

    Public Function GetEmberPlatform(ByVal fpath As String) As String
        Try
            If Not File.Exists(Path.Combine(fpath, "Ember Media Manager.exe")) Then Return String.Empty
            Dim _Assembly As Assembly = Assembly.ReflectionOnlyLoadFrom(Path.Combine(fpath, "Ember Media Manager.exe"))
            Dim kinds As PortableExecutableKinds
            Dim imgFileMachine As ImageFileMachine
            _Assembly.ManifestModule.GetPEKind(kinds, imgFileMachine)
            If kinds And PortableExecutableKinds.PE32Plus Then
                _Assembly = Nothing
                Return "x64"
            End If
            _Assembly = Nothing
            Return "x86"
        Catch ex As Exception
            LogWrite(String.Format("--- Error: {0}", ex.Message))
            LogWrite(ex.StackTrace)
            Return String.Empty
        End Try
    End Function

    Public Function GetEmberVersion(ByVal fpath As String) As String
        If Not File.Exists(Path.Combine(fpath, "Ember Media Manager.exe")) Then Return String.Empty
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(fpath, "Ember Media Manager.exe"))
        Return myBuildInfo.ProductPrivatePart
    End Function

    Public Function DownloadTextData(ByVal URL As String) As String
        Dim sResponse As String = String.Empty
        Dim cEncoding As System.Text.Encoding
        Dim wrRequest As HttpWebRequest
        Try
            wrRequest = DirectCast(WebRequest.Create(String.Format("http://pcjco.dommel.be/emm-r/{0}/{1}", RemoteSiteFolder, URL)), HttpWebRequest)
            wrRequest.Timeout = 20000
            wrRequest.Headers.Add("Accept-Encoding", "gzip,deflate")

            If Not String.IsNullOrEmpty(eSettings.ProxyURI) AndAlso eSettings.ProxyPort >= 0 Then
                Dim wProxy As New WebProxy(eSettings.ProxyURI, eSettings.ProxyPort)
                wProxy.BypassProxyOnLocal = True
                If Not String.IsNullOrEmpty(eSettings.ProxyCreds.UserName) AndAlso _
                Not String.IsNullOrEmpty(eSettings.ProxyCreds.Password) Then
                    wProxy.Credentials = eSettings.ProxyCreds
                Else
                    wProxy.Credentials = CredentialCache.DefaultCredentials
                End If
                wrRequest.Proxy = wProxy
            End If

            Using wrResponse As HttpWebResponse = DirectCast(wrRequest.GetResponse(), HttpWebResponse)
                Select Case True
                    'for our purposes I think it's safe to assume that all xmls we will be dealing with will be UTF-8 encoded
                    Case wrResponse.ContentType.ToLower.Contains("application/xml") OrElse wrResponse.ContentType.ToLower.Contains("charset=utf-8")
                        cEncoding = System.Text.Encoding.UTF8
                    Case Else
                        cEncoding = System.Text.Encoding.GetEncoding(28591)
                End Select
                Using Ms As Stream = wrResponse.GetResponseStream
                    If wrResponse.ContentEncoding.ToLower = "gzip" Then
                        sResponse = New StreamReader(New GZipStream(Ms, CompressionMode.Decompress), cEncoding, True).ReadToEnd
                    ElseIf wrResponse.ContentEncoding.ToLower = "deflate" Then
                        sResponse = New StreamReader(New DeflateStream(Ms, CompressionMode.Decompress), cEncoding, True).ReadToEnd
                    Else
                        sResponse = New StreamReader(Ms, cEncoding, True).ReadToEnd
                    End If
                End Using
            End Using
        Catch ex As Exception
        End Try

        Return sResponse
    End Function


    Public Function GetURLDataBin(ByVal URL As String, ByVal FName As String, _
        Optional ByRef UserName As String = "", _
        Optional ByRef Password As String = "") As Boolean
        Dim Req As HttpWebRequest
        Dim SourceStream As System.IO.Stream
        Dim Response As HttpWebResponse
        Try
            If System.IO.File.Exists(FName) Then
                System.IO.File.Delete(FName)
            End If

            'Ignore bad https certificates - expired, untrusted, bad name, etc.
            'ServicePointManager.CertificatePolicy = New MyAcceptCertificatePolicy
            'Dim value As RemoteCertificateValidationCallback
            'value = ServicePointManager.ServerCertificateValidationCallback
            'ServicePointManager.ServerCertificateValidationCallback = New ServicePointManager.ServerCertificateValidationCallback
            'create a web request to the URL
            Req = HttpWebRequest.Create(URL)
            '---
            If Not String.IsNullOrEmpty(eSettings.ProxyURI) AndAlso eSettings.ProxyPort >= 0 Then
                'Dim myUri As New Uri(String.Concat(If(eSettings.ProxyURI.StartsWith("http"), String.Empty, "http://"), String.Format("{0}:{1}", eSettings.ProxyURI, eSettings.ProxyPort)))
                'Dim wProxy As New WebProxy(myUri)
                Dim wProxy As New WebProxy(eSettings.ProxyURI, eSettings.ProxyPort)
                wProxy.BypassProxyOnLocal = True
                If Not String.IsNullOrEmpty(eSettings.ProxyCreds.UserName) AndAlso _
                Not String.IsNullOrEmpty(eSettings.ProxyCreds.Password) Then
                    wProxy.Credentials = eSettings.ProxyCreds
                Else
                    wProxy.Credentials = CredentialCache.DefaultCredentials
                End If
                Req.Proxy = wProxy
            End If


            '---
            Dim noCachePolicy As System.Net.Cache.HttpRequestCachePolicy = New System.Net.Cache.HttpRequestCachePolicy(System.Net.Cache.HttpRequestCacheLevel.Reload)
            Req.CachePolicy = noCachePolicy
            'Grrrrr.... HttpWebRequest does not know rfc
            'you cannot use http://username:password@server:port/uri
            'Set username and password if required
            If Len(UserName) > 0 Then
                Req.Credentials = New NetworkCredential(UserName, Password)
            End If
            'get a response from web site
            Response = Req.GetResponse()
            'Source stream with requested document
            SourceStream = Response.GetResponseStream()
            Dim readStream As New BinaryReader(SourceStream)
            'SourceStream has no ReadAll, so we must read data block-by-block
            'Temporary Buffer and block size
            Dim bufferSize As Integer = 4096 '512 for debug slow down
            Dim Buffer(bufferSize) As Byte, BlockSize As Integer
            Dim TempStream As New IO.FileStream(FName, IO.FileMode.Create)
            Do
                BlockSize = readStream.Read(Buffer, 0, bufferSize)
                If BlockSize > 0 Then TempStream.Write(Buffer, 0, BlockSize)
                'System.Threading.Thread.Sleep(5) 'Slow Down for debug
            Loop While BlockSize > 0
            TempStream.Close()
            readStream.Close()
            SourceStream.Close()
            Response.Close()
            Return True
        Catch ex As Exception
            'Report("Error", ex.Message)
            LogWrite(String.Format("+++ GetURLDataBin Error: {0}", ex.Message))
            Return False
        End Try
    End Function

    Public Function GetURLFile(ByVal url As String, ByVal localfile As String)
        Try
            If Not isSiteReady Then
                CheckIsSiteReady()
                If Not isSiteReady Then Return False
            End If
            LogWrite(String.Format("--- GetURL: URL={2}/{0}  File={1}", url, localfile, RemoteSiteFolder))
            If Not DEBUG Then
                Return GetURLDataBin(String.Concat(String.Format("http://pcjco.dommel.be/emm-r/{0}/", RemoteSiteFolder), url), localfile)
            Else
                Return True
                'Return GetURLDataBin(String.Concat("http://127.0.0.1/updates/", url), localfile)
            End If
        Catch ex As Exception
            LogWrite(String.Format("+++ GetURL Error: {0}", ex.Message))
        End Try
        Return False
    End Function

    Public Sub LoadVersions()
        EmberVersions.VersionList.Clear()
        If File.Exists(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "versionlist.xml"))) Then
            Dim xmlSer As New XmlSerializer(GetType(UpgradeList))
            Using xmlSW As New StreamReader(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "versionlist.xml")))
                EmberVersions = xmlSer.Deserialize(xmlSW)
            End Using
        End If
    End Sub

    Public Sub RemoveSetupFolders(ByVal setupPath As String)
        LogWrite(String.Format("--- RemoveSetupFolders: {1}{0}updates", Path.DirectorySeparatorChar, setupPath))
        DeleteDirectory(Path.Combine(setupPath, "updates"))
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If btnExit.Text = MyLang.GetString(38, "Exit") Then
            Me.Close()
            Application.Exit()
        Else
            If bwDoInstall.IsBusy Then
                bwDoInstall.CancelAsync()
                lblStatus.ForeColor = Color.Red
                lblStatus.Text = MyLang.GetString(1, "Canceling...")
            End If
            While bwDoInstall.IsBusy
                Application.DoEvents()
            End While
        End If
    End Sub

    Private Sub btnInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstall.Click
        StartWorker()
        LogoStop = False
        llAbout.Visible = False
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        LogWrite(String.Format("--- Options: Enter"))
        Me.DisablePaint = True
        btnOptions.Enabled = False
        Using chgOptons As New dlgChangeOptions
            NeedDoEvents = True
            If chgOptons.ShowDialog() = Windows.Forms.DialogResult.OK Then
                NeedDoEvents = False
                emberPath = If(Not emberPath.EndsWith(Path.DirectorySeparatorChar), String.Concat(emberPath, Path.DirectorySeparatorChar), emberPath)
                If Not emberPath = String.Empty Then
                    LogWrite(String.Format("--- Options: Setting Install Path: {0}", emberPath))
                    CurrentEmberVersion = GetEmberVersion(Path.GetDirectoryName(emberPath))
                    LogWrite(String.Format("--- Options: Found Ember Version: {0}", If(CurrentEmberVersion = String.Empty OrElse CurrentEmberVersion = "0", "(None)", CurrentEmberVersion)))
                    'CurrentEmberPlatform = GetEmberPlatform(Path.GetDirectoryName(emberPath))
                End If
                lblInfo.TextAlign = ContentAlignment.MiddleCenter
                lblInfo.ForeColor = Color.Black
                lblInfo.Font = New Font("Arial", 11, FontStyle.Regular)
                lblInfo.Text = String.Format(MyLang.GetString(2, "Ember Media Manager Installation Path:{0}""{1}"""), vbCrLf, emberPath)
            Else
                NeedDoEvents = False
            End If

            Me.DisablePaint = False
            MyBackGround.Invalidate()

        End Using
        btnOptions.Enabled = True
        If Not emberPath = String.Empty AndAlso Not CurrentEmberPlatform = String.Empty Then
            btnInstall.Enabled = True
        End If
        LogWrite(String.Format("--- Options: Exit"))
        Me.Activate()
        Me.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub btnRunEmber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunEmber.Click
        If CheckIfWindows() Then
            Using Explorer As New Process
                Explorer.StartInfo.FileName = Path.Combine(emberPath, "Ember Media Manager.exe")

                Explorer.Start()
            End Using
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "mono"
                Explorer.StartInfo.Arguments = String.Concat("""", Path.Combine(emberPath, "Ember Media Manager.exe"), """")
                Explorer.Start()
            End Using
        End If

        Close()
    End Sub

    Private Sub bwDoInstall_Completed(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDoInstall.RunWorkerCompleted
        NeedDoEvents = False
        btnExit.Text = "Exit"
        If ExitMe Then
            'Me.Close()
        End If
        pbFiles.Visible = False
        'Me.Activate()
        If e.Cancelled Then
            LogWrite(String.Format("--- Main: Cancelled by User ({0})", Now))
            lblStatus.Text = MyLang.GetString(3, "Installation Aborted")
            pnlProgress.Visible = False
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.ForeColor = Color.Red
            lblInfo.Font = New Font("Arial", 11, FontStyle.Bold)
            lblInfo.Text = MyLang.GetString(4, "Cancelled by User")
            btnOptions.Enabled = True
        End If
        Me.Refresh()
        LogoStop = True
    End Sub

    Private Sub bwDoInstall_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDoInstall.DoWork
        e.Cancel = Not DOInstallEmber()
    End Sub

    Private Sub bwDoInstall_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDoInstall.ProgressChanged
        If e.ProgressPercentage = 0 Then
            Dim progress As Integer = e.UserState(0) 'This is true progress %
            Dim txt As String = e.UserState(1)
            lblStatus.TextAlign = ContentAlignment.MiddleCenter
            lblStatus.ForeColor = Color.Blue
            lblStatus.Font = New Font("Arial", 12, FontStyle.Bold)
            lblStatus.Text = txt
            If progress >= pbFiles.Minimum AndAlso progress <= pbFiles.Maximum Then pbFiles.Value = progress
        End If
        If e.ProgressPercentage = 1 Then
            lblStatus.Text = e.UserState
        End If
        If e.ProgressPercentage = 2 Then
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.ForeColor = Color.Red
            lblInfo.Font = New Font("Arial", 12, FontStyle.Bold)
            lblInfo.Text = e.UserState
            pnlProgress.Visible = False
            btnInstall.Enabled = True
            btnOptions.Enabled = True
        End If
        If e.ProgressPercentage = 3 Then
            lblStatus.TextAlign = ContentAlignment.MiddleCenter
            lblStatus.ForeColor = Color.Red
            lblStatus.Font = New Font("Arial", 13, FontStyle.Bold)
            lblStatus.Text = e.UserState
            btnInstall.Enabled = False
            btnOptions.Enabled = False
        End If
        If e.ProgressPercentage = 4 Then
            lblInfo.ForeColor = Color.Blue
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.Font = New Font("Arial", 12, FontStyle.Bold)
            lblInfo.Text = e.UserState
        End If
        If e.ProgressPercentage = 5 Then
            lblInfo.ForeColor = Color.Black
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.Font = New Font("Arial", 12, FontStyle.Bold)
            lblInfo.Text = e.UserState
        End If
        If e.ProgressPercentage = 6 Then
            lblStatus.Text = MyLang.GetString(5, "Installation Finished")
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.Font = New Font("Arial", 12, FontStyle.Bold)
            lblInfo.Text = e.UserState
            btnInstall.Visible = False
            btnOptions.Visible = False
            btnRunEmber.Visible = True
            pnlProgress.Visible = False
            pbFiles.Visible = False
        End If
        If e.ProgressPercentage = 7 Then
            lblStatus.Text = MyLang.GetString(3, "Installation Aborted")
            pnlProgress.Visible = False
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.ForeColor = Color.Red
            lblInfo.Font = New Font("Arial", 11, FontStyle.Bold)
            lblInfo.Text = e.UserState
        End If
        If e.ProgressPercentage = 8 Then
            pbFiles.Style = ProgressBarStyle.Continuous
            pbFiles.Value = pbFiles.Minimum
            pbFiles.Maximum = Convert.ToInt32(e.UserState)
        End If
        If e.ProgressPercentage = 9 Then
            pbFiles.Style = ProgressBarStyle.Marquee
        End If
        If e.ProgressPercentage = 10 Then
            Dim progress As Integer = e.UserState(0) 'This is true progress %
            Dim txt As String = e.UserState(1)
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.ForeColor = Color.Black
            lblInfo.Font = New Font("Arial", 12, FontStyle.Bold)
            lblInfo.Text = txt
            If progress >= pbFiles.Minimum AndAlso progress <= pbFiles.Maximum Then pbFiles.Value = progress
        End If
        If e.ProgressPercentage = 11 Then
            Dim progress As Integer = e.UserState(0) 'This is true progress %
            lblStatus.TextAlign = ContentAlignment.MiddleCenter
            lblStatus.ForeColor = Color.Blue
            lblStatus.Font = New Font("Arial", 12, FontStyle.Bold)
            lblStatus.Text = e.UserState(1).ToString
            lblInfo.TextAlign = ContentAlignment.MiddleCenter
            lblInfo.ForeColor = Color.Red
            lblInfo.Font = New Font("Arial", 11, FontStyle.Bold)
            lblInfo.Text = e.UserState(2).ToString
            btnInstall.Visible = False
            btnOptions.Visible = False
            btnRunEmber.Visible = False
            pnlProgress.Visible = False
            pbFiles.Visible = False
        End If
        If e.ProgressPercentage = 12 Then
            Dim progress As Integer = e.UserState 'This is true progress %
            If progress >= pbFiles.Minimum AndAlso progress <= pbFiles.Maximum Then pbFiles.Value = progress
        End If
    End Sub

    Private Sub bwFindeEmber_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwFF.DoWork
        FindFile(Path.GetPathRoot(Application.StartupPath), "Ember Media Manager.exe")
    End Sub

    Sub CloseHandles()
    End Sub

    Sub Credits(ByVal e As Graphics)
        'bCredits = New Bitmap(Me.MyBackGround.Width, Me.MyBackGround.Height)
        'Dim e As Graphics = Graphics.FromImage(bCredits)
        Dim CurrentX As Single, CurrentY As Single, FontMod As Single = 0
        For i As Integer = 0 To CredList.Count - 1
            CurrentY = PicY + FontMod
            FontMod += CredList(i).Font.Size + 10
            CurrentX = (Me.MyBackGround.Width - e.MeasureString(CredList(i).Text, CredList(i).Font).Width) / 2
            If i = CredList.Count - 1 And CurrentY < -25 Then PicY = Me.MyBackGround.Height
            e.DrawString(CredList(i).Text, CredList(i).Font, Brushes.Black, CurrentX, CurrentY)
        Next
        SlowDown += 1
        If SlowDown > 2 Then
            PicY -= 1
            SlowDown = 0
        End If
    End Sub

    Function DOInstallEmber() As Boolean
        ' From BackGorundWorker Only
        Dim InstallVersion As String = String.Empty
        Dim counter As Integer = 0
        Me.bwDoInstall.ReportProgress(9, Nothing)
        If Not Final Then
            Me.bwDoInstall.ReportProgress(0, New Object() {1, MyLang.GetString(6, "Looking for Ember Installation Folder")})
            LogWrite(String.Format("--- Main: Looking for Ember Installation Folder ({0})", Now))
            If emberPath = String.Empty Then
                If File.Exists(Path.Combine(AppPath, "Ember Media Manager.exe")) Then
                    emberPath = AppPath()
                Else
                    FindEmberPath()
                    If emberAllFounds.Count > 0 Then
                        emberPath = emberAllFounds(0)
                    End If
                    If emberPath = String.Empty Then
                        emberPath = Path.Combine(WindowsInstallPath, "Ember Media Manager")
                        If emberPath = String.Empty Then
                            emberPath = Path.Combine(Path.GetPathRoot(Application.StartupPath), "Ember Media Manager")
                        End If
                    End If
                End If
            End If
            LogWrite(String.Format("*** Main: Ember Installation Folder: {0}", emberPath))
        End If
        If bwDoInstall.CancellationPending Then Return False

        If Not emberPath = String.Empty Then
            If Not Final Then
                Try
                    Me.bwDoInstall.ReportProgress(0, New Object() {2, MyLang.GetString(7, "Downloading Version List")})
                    LogWrite(String.Format("--- Main: Downloading Version List ({0})", Now))
                    CurrentEmberVersion = GetEmberVersion(Path.GetDirectoryName(emberPath))
                    ExeCurrentEmberVersion = CurrentEmberVersion
                    If CurrentEmberPlatform = String.Empty Then
                        CurrentEmberPlatform = GetEmberPlatform(Path.GetDirectoryName(emberPath))
                    End If
                    If CurrentEmberPlatform = String.Empty Then
                        CurrentEmberPlatform = If(Is64Bit, "x64", "x86")
                        LogWrite(String.Format("*** Main: No Platform Selected ABORT"))
                        Me.bwDoInstall.ReportProgress(7, MyLang.GetString(8, "No Platform Selected")) '  Error
                        Return True
                    End If

                    If Not Directory.Exists(Path.GetDirectoryName(emberPath)) OrElse NoArgs Then
                        CreateSetupFolders(Path.GetDirectoryName(emberPath))
                    End If
                    If Not GetURLFile("versionlist.xml", Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "versionlist.xml"))) Then
                        ' Cant get Version List ... Abort
                        If Not isSiteReady Then
                            Me.bwDoInstall.ReportProgress(0, New Object() {2, MyLang.GetString(34, "Welcome to Ember Media Manager Installation")})
                            LogWrite(String.Format("*** Main: No Versions List, SITE IN MAINTENANCE ABORT"))
                            Me.bwDoInstall.ReportProgress(2, String.Format(MyLang.GetString(52, "A new version is currently being uploaded. {0}Please try again in a few moments."), vbCrLf)) '  Error
                            Return True
                        Else
                            LogWrite(String.Format("*** Main: No Versions List, SITE DOWN? ABORT"))
                            Me.bwDoInstall.ReportProgress(2, String.Format(MyLang.GetString(9, "Ember Download Site is Not Available.{0}Please try again later."), vbCrLf)) '  Error
                            Return True
                        End If
                    Else
                        LoadVersions()
                        EmberVersions.VersionList.Sort()
                        If Not EmberVersions.VersionList.Count > 0 Then
                            LogWrite(String.Format("*** Main: Invalid Version List. No Versions Found, ABORT"))
                            Me.bwDoInstall.ReportProgress(7, "Invalid Version List")
                            Return True
                        End If
                        InstallVersion = EmberVersions.VersionList(EmberVersions.VersionList.Count - 1).Version
                        If InstallVersion = CurrentEmberVersion AndAlso Not Recover Then
                            LogWrite(String.Format("*** Main: Nothing to Update ... EXIT"))
                            Me.bwDoInstall.ReportProgress(6, MyLang.GetString(10, "No New Version to Install"))
                            RemoveSetupFolders(Path.GetDirectoryName(emberPath))
                            Return True
                        End If
                        Me.bwDoInstall.ReportProgress(5, "")
                        Dim getFile As String
                        '###################################################################################
                        If bwDoInstall.CancellationPending Then Return False
                        Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(12, "Downloading Update Script Files")})
                        LogWrite(String.Format("--- Main: Downloading Update Script Files ({0})", Now))
                        getFile = String.Format("commands_base.xml")
                        If GetURLFile(getFile, Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile))) Then
                            ' Found it ...
                        End If
                        If Not CurrentEmberVersion = String.Empty Then
                            Dim Count_Versions As Integer = 0
                            For Each v As Versions In EmberVersions.VersionList
                                If Convert.ToInt32(v.Version) > Convert.ToInt32(CurrentEmberVersion) Then
                                    Count_Versions += 1
                                    'Get Commands fro every version from the current to the new
                                    getFile = String.Format("commands_{0}.xml", v.Version)
                                    If GetURLFile(getFile, Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile))) Then
                                        ' Found it ...
                                    End If
                                End If
                                If bwDoInstall.CancellationPending Then Return False
                            Next
                        End If
                        Me.bwDoInstall.ReportProgress(5, "")
                        '###################################################################################
                        If bwDoInstall.CancellationPending Then Return False
                        Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(11, "Downloading Version Files")})
                        LogWrite(String.Format("--- Main: Downloading Version Files ({0})", Now))
                        getFile = String.Format("version_{0}.xml", InstallVersion)

                        If BlindSetup AndAlso File.Exists(Path.Combine(AppPath, getFile)) Then
                            LogWrite(String.Format("### Main: BlindSetup... Using Version Files ({0})", Path.Combine(AppPath, getFile)))
                            File.Copy(Path.Combine(AppPath, getFile), Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile)))
                        Else
                            If Not GetURLFile(getFile, Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile))) Then
                                ' Cant get Version # ... Abort
                                LogWrite(String.Format("*** Main: Installation File Not Found, ABORT : {0}", getFile))
                                CurrentEmberVersion = String.Empty
                                Me.bwDoInstall.ReportProgress(2, Nothing) '  Error
                                Return True
                            End If
                        End If
                        If Not CurrentEmberVersion = String.Empty Then
                            getFile = String.Format("version_{0}.xml", CurrentEmberVersion)
                            If Not GetURLFile(getFile, Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile))) Then
                                ' Cant get Current Version  ... Special Situation, Will Force Full Installation
                                LogWrite(String.Format("--- Main: No Version File for: {0}", CurrentEmberVersion))
                                CurrentEmberVersion = String.Empty
                            End If
                        End If
                        Me.bwDoInstall.ReportProgress(5, "")
                        '###################################################################################
                        Dim _CurrentFiles As New FilesList
                        Dim _NewFiles As New FilesList
                        Dim xmlSer As XmlSerializer
                        getFile = String.Format("version_{0}.xml", InstallVersion)
                        xmlSer = New XmlSerializer(GetType(FilesList))
                        Using xmlSW As New StreamReader(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile)))
                            _NewFiles = xmlSer.Deserialize(xmlSW)
                        End Using
                        _NewFiles.ConvertToPlatform()
                        '###################################################################################
                        'At this point it have current a new file list and all commands
                        'Need to mark files changed by user, and download all new (hash based) files
                        Dim skipFiles As String() = {"\images\genres\genres.xml", "\bin\mediainfo.dll"}
                        If bwDoInstall.CancellationPending Then Return False
                        If Not CurrentEmberVersion = String.Empty Then
                            Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(13, "Checking Installed Files")})
                            LogWrite(String.Format("--- Main: Checking Installed Files ({0})", Now))
                            getFile = String.Format("version_{0}.xml", CurrentEmberVersion)
                            xmlSer = New XmlSerializer(GetType(FilesList))
                            Using xmlSW As New StreamReader(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, getFile)))
                                _CurrentFiles = xmlSer.Deserialize(xmlSW)
                            End Using
                        End If
                        _CurrentFiles.ConvertToPlatform()
                        Dim fpath As String = String.Empty
                        Dim hash As String = String.Empty
                        Dim curr_hash As String = String.Empty
                        Dim inCache As Boolean = False
                        Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(14, "Downloading Files")})
                        Me.bwDoInstall.ReportProgress(8, _NewFiles.Files.Count)
                        counter = 0
                        For Each f As FileOfList In _NewFiles.Files
                            f.NeedBackup = False
                            f.NeedInstall = True
                            f.inCache = False
                            curr_hash = String.Empty
                            If f.Path = String.Empty Then
                                fpath = Path.Combine(Path.GetDirectoryName(emberPath), f.Filename)
                            Else
                                fpath = Path.Combine(Path.Combine(Path.GetDirectoryName(emberPath), f.Path.Substring(1)), f.Filename)
                            End If
                            If File.Exists(fpath) Then
                                hash = GetHash(fpath)
                                If Not _CurrentFiles.Files Is Nothing Then
                                    Dim cf As FileOfList = GetFromList(_CurrentFiles, f)
                                    If Not cf Is Nothing Then
                                        curr_hash = cf.Hash
                                    End If

                                    If Not hash = curr_hash Then
                                        f.NeedBackup = True
                                    End If
                                End If
                            End If
                            If (curr_hash = f.Hash AndAlso Not f.NeedBackup) OrElse (f.Hash = hash) Then
                                f.NeedInstall = False
                            End If
                            If (File.Exists(fpath) AndAlso skipFiles.Contains(String.Concat(f.Path, "\", f.Filename).ToLower)) And Not Recover Then
                                f.NeedInstall = False
                            End If

                            Dim cachefile As String = Path.Combine(Path.GetDirectoryName(emberPath), String.Format(String.Concat("updates", Path.DirectorySeparatorChar, "{0}.emm"), f.Hash))
                            If File.Exists(cachefile) Then
                                If GetHash(cachefile) = f.Hash Then
                                    f.inCache = True
                                Else
                                    File.Delete(cachefile)
                                End If
                            End If
                            If bwDoInstall.CancellationPending Then Return False
                            If f.Platform = CurrentEmberPlatform OrElse f.Platform = "Common" _
                                OrElse (Not CheckIfWindows() AndAlso f.Platform = "Mono") Then
                                If f.NeedInstall = True OrElse (Not CheckIfWindows() AndAlso f.Platform = "Mono") Then
                                    'f.NeedInstall = True
                                    'getFile = String.Format("Files/{0}.gz", f.Filename)

                                    If f.inCache Then
                                        LogWrite(String.Format("--- Main: File in cache: skipping ({0})", f.Filename))
                                        Me.bwDoInstall.ReportProgress(10, New Object() {counter, String.Format(MyLang.GetString(15, "In Cache: {0}"), f.Filename)})
                                    Else
                                        Me.bwDoInstall.ReportProgress(10, New Object() {counter, String.Format(MyLang.GetString(16, "Downloading: {0}"), f.Filename)})
                                        'If Path.GetExtension(f.Filename) = ".dll" OrElse Path.GetExtension(f.Filename) = ".exe" Then
                                        'getFile = String.Format("download.php?fname=({2}) {0}&hfname=Files/{1}.emm", f.Filename, f.Hash, CurrentEmberPlatform)
                                        'Else
                                        getFile = String.Format("Files/{0}.emm", f.Hash)
                                        'End If

                                        If Not GetURLFile(getFile, Path.Combine(Path.GetDirectoryName(emberPath), String.Format(String.Concat("updates", Path.DirectorySeparatorChar, "{0}.emm"), f.Hash))) Then
                                            ' Error Downloading File... Abort
                                            LogWrite(String.Format("+++ Main: Error downloading: {0}", f.Filename))
                                            Me.bwDoInstall.ReportProgress(7, String.Format(MyLang.GetString(17, "Error downloading: {0}"), f.Filename))
                                            Return True
                                        End If
                                    End If
                            End If
                            Else
                                f.NeedInstall = False
                            End If
                            counter += 1
                            Me.bwDoInstall.ReportProgress(12, counter)
                            If bwDoInstall.CancellationPending Then Return False
                        Next
                        Me.bwDoInstall.ReportProgress(5, "")
                        Me.bwDoInstall.ReportProgress(9, Nothing)
                        ' If we split this in fases we can Save FileList now
                        '###################################################################################
                        ' Now do the Installation
                        ' Keep separated from Check/Download so it can do in different fases if needed
                        ' If we separate in fases will need to load Saved File List
                        If bwDoInstall.CancellationPending Then Return False
                        Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(18, "Installing Files")})
                        LogWrite(String.Format("--- Main: Installing Files ({0})", Now))
                        Me.bwDoInstall.ReportProgress(8, _NewFiles.Files.Count)
                        counter = 0
                        Dim installedFiles As Integer = 0
                        For Stage As Integer = 1 To If(CheckIfWindows, 1, 2) ' Stage 2 = second pass for Mono
                            If Stage = 2 Then
                                Me.bwDoInstall.ReportProgress(0, New Object() {0, MyLang.GetString(19, "Installing Mono Specific Files")})
                                LogWrite(String.Format("--- Main: Installing Mono Specific Files ({0})", Now))
                            End If

                            For Each f As FileOfList In _NewFiles.Files
                                If f.NeedInstall = True OrElse (Not CheckIfWindows() AndAlso f.Platform = "Mono") Then
                                    If Stage = 1 AndAlso f.Platform = "Mono" Then Continue For
                                    'Me.bwDoInstall.ReportProgress(5, String.Format("Installing: {0}", f.Filename))
                                    'UncompressFile(Path.Combine(Path.GetDirectoryName(emberPath), String.Format("updates\{0}.gz", f.Filename)), Path.Combine(Path.GetDirectoryName(emberPath), String.Format("updates\{0}", f.Filename)))
                                    'File.Delete(Path.Combine(Path.GetDirectoryName(emberPath), String.Format("updates\{0}.gz", f.Filename)))
                                    'Dim spath As String = Path.Combine(Path.GetDirectoryName(emberPath), String.Format("updates\{0}", f.Filename))
                                    Dim spath As String = Path.Combine(Path.GetDirectoryName(emberPath), String.Format("updates{0}{1}.emm", Path.DirectorySeparatorChar, f.Hash))
                                    Dim dpath As String
                                    If f.Path = String.Empty Then
                                        dpath = Path.Combine(Path.GetDirectoryName(emberPath), f.Filename)
                                    Else
                                        dpath = Path.Combine(Path.Combine(Path.GetDirectoryName(emberPath), f.Path.Substring(1)), f.Filename)
                                    End If
                                    Try
                                        'Check File Hash to be sure was not tampered
                                        hash = GetHash(spath)
                                        If Not hash = f.Hash Then
                                            LogWrite(String.Format("*** Main: WARNING File Hash Not Correct : {0}", dpath))
                                            Me.bwDoInstall.ReportProgress(0, New Object() {3, MyLang.GetString(20, "WARNING File Hash Not Correct"), dpath})
                                            Return True
                                        End If
                                        If File.Exists(dpath) Then

                                            If f.NeedBackup = True Then
                                                Try
                                                    If File.Exists(String.Format("{0}.backup", dpath)) Then
                                                        File.Delete(String.Format("{0}.backup", dpath))
                                                    End If
                                                    LogWrite(String.Format("--- Main: Creating Backup of : {0}", dpath))
                                                    File.Move(dpath, String.Format("{0}.backup", dpath))
                                                Catch ex As Exception
                                                    LogWrite(String.Format("+++ Main: Locked File on Make Backup: {0}", String.Format("{0}", dpath)))
                                                End Try
                                            Else
                                                'Dont Need backup, but File could be Locked...
                                                'Also, .exe files can be locked by the Load Assenbly (get Ember Version and Platform)
                                                'In this cases Move will succedd,
                                                'Let's try Move it so we can Install the New File
                                                If File.Exists(String.Format("{0}.old", dpath)) Then
                                                    Try
                                                        File.Delete(String.Format("{0}.old", dpath))
                                                    Catch ex As Exception
                                                        LogWrite(String.Format("--- Main: Locked File on Delete Old: {0}", String.Format("{0}.old", dpath)))
                                                        'Ignore this
                                                    End Try
                                                End If
                                                Try
                                                    File.Move(dpath, String.Format("{0}.old", dpath))
                                                Catch ex As Exception
                                                    LogWrite(String.Format("--- Main: Locked File on Move: {0}", String.Format("{0}", dpath)))
                                                    'Ignore this , Possible locked by Assembly Load
                                                    'Install will possible fail, but dont abort now.. let it happen later
                                                End Try
                                                Try
                                                    If File.Exists(String.Format("{0}.old", dpath)) Then
                                                        File.Delete(String.Format("{0}.old", dpath))
                                                    End If
                                                Catch ex As Exception
                                                    LogWrite(String.Format("--- Main: Locked File on Delete After Move: {0}", String.Format("{0}.old", dpath)))
                                                    'Ignore this , Possible locked by Assembly Load
                                                    'File is locked, but installation will succedd
                                                End Try
                                            End If
                                        End If
                                        If Not Directory.Exists(Path.GetDirectoryName(dpath)) Then
                                            LogWrite(String.Format("--- Main: Creating Directory: {0}", Path.GetDirectoryName(dpath)))
                                            Directory.CreateDirectory(Path.GetDirectoryName(dpath))
                                        End If
                                        LogWrite(String.Format("--- Main: Installing File: {0}", dpath))
                                        File.Copy(spath, dpath)
                                        installedFiles += 1
                                    Catch ex As Exception
                                        Me.bwDoInstall.ReportProgress(7, String.Format(MyLang.GetString(21, "Error: {0} {1}"), dpath, ex.Message))
                                        LogWrite(String.Format("--- Error: {0}", ex.Message))
                                        LogWrite(ex.StackTrace)
                                        Return True
                                    End Try
                                    Me.bwDoInstall.ReportProgress(10, New Object() {counter, String.Format(MyLang.GetString(22, "Installed: {0}"), f.Filename)})
                                End If
                                counter += 1
                                f.NeedInstall = False
                                If bwDoInstall.CancellationPending Then Return False
                            Next
                        Next
                        If installedFiles = 0 Then
                            LogWrite(String.Format("--- Main: No Files needed Installtion ({0})", Now))
                        End If
                        Me.bwDoInstall.ReportProgress(9, Nothing)
                    End If
                Catch ex As Exception
                    Me.bwDoInstall.ReportProgress(7, String.Format(MyLang.GetString(23, "Error: {0}"), ex.Message))
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                    Return True
                End Try
            End If
            Me.bwDoInstall.ReportProgress(5, "")
            '###################################################################################
            'Time to Run Version Commands
            'Will Run on another Class so It Can Load SQLite DLL on Demand ...
            '... after Setup restart when it is in the Ember folder
            'This is needed because Assembly Manager dont allow to load DLL's from random folder
            Try
                If bwDoInstall.CancellationPending Then Return False

                Me.bwDoInstall.ReportProgress(0, New Object() {2, MyLang.GetString(24, "Preparing For Ember Configuration")})
                Me.bwDoInstall.ReportProgress(9, Nothing)
                If Not Final Then
                    LogWrite(String.Format("--- Main: INFO: SETUP {0}", AppPath))
                    LogWrite(String.Format("--- Main: INFO: EMBER {0}", emberPath))
                    Dim NeedReload As Boolean = True 'Wlll check if needs reload for dll Assenbly Load
                    If Not AppPath() = emberPath Then
                        LogWrite(String.Format("*** Main: EmberSetup Not in Ember Folder"))
                        Try
                            If File.Exists(Path.Combine(emberPath, "EmberSetup.exe")) Then
                                File.Delete(Path.Combine(emberPath, "EmberSetup.exe"))
                            End If
                            If File.Exists(Path.Combine(emberPath, "install.log")) Then
                                File.Delete(Path.Combine(emberPath, "install.log"))
                            End If
                        Catch ex As Exception
                            LogWrite(String.Format("--- Error: {0}", ex.Message))
                            LogWrite(ex.StackTrace)
                        End Try
                        Try
                            File.Copy(Path.Combine(AppPath, "EmberSetup.exe"), Path.Combine(emberPath, "EmberSetup.exe"))
                            File.Copy(Path.Combine(AppPath, "install.log"), Path.Combine(emberPath, "install.log"))
                        Catch ex As Exception
                            LogWrite(String.Format("--- Error: {0}", ex.Message))
                            LogWrite(ex.StackTrace)
                        End Try
                    Else
                        LogWrite(String.Format("*** Main: EmberSetup in Ember Folder"))
                        ' PLACE #1
                    End If
                    ' PLACE #2
                End If
                InstallVersion = GetEmberVersion(Path.GetDirectoryName(emberPath))

                LogWrite(String.Format("--- Main: Last Version {0}", If(CurrentEmberVersion = String.Empty OrElse CurrentEmberVersion = "0", "(None)", CurrentEmberVersion)))
                LogWrite(String.Format("--- Main: Installing Version {0}", InstallVersion))

                Dim plat As String = If(Not CheckIfWindows(), "Mono", CurrentEmberPlatform)
                DownloadTextData(String.Format("EmberDownload.php?Platform={0}&Version={1}&OldVersion={2}", plat, InstallVersion, If(CurrentEmberVersion = String.Empty OrElse CurrentEmberVersion = "0", "(New)", CurrentEmberVersion)))

                System.Threading.Thread.Sleep(3000)
                If bwDoInstall.CancellationPending Then Return False
                ' pnlProgress.Visible = False
                Me.bwDoInstall.ReportProgress(5, MyLang.GetString(25, "Building Update Tasks"))
                LogWrite(String.Format("*** Main: Commands START"))
                'Dim cmds As New Commands(emberPath)
                'Dim dbExist As Boolean = File.Exists(Path.Combine(emberPath, "Media.emm"))
                'cmds.DB.Connect()

                Dim xmlSer As XmlSerializer
                Dim _cmds As New InstallCommands
                Dim UpdateTasks As New InstallCommands
                System.Threading.Thread.Sleep(1000)
                Dim di As New DirectoryInfo(Path.Combine(Path.GetDirectoryName(emberPath), "updates"))
                Dim fis As FileInfo() = di.GetFiles
                Array.Sort(fis, New Comparer)
                Dim HaveCommands As Boolean = False

                Try
                    If String.IsNullOrEmpty(ExeCurrentEmberVersion) Then
                        UpdateTasks.Command.Clear()
                        If File.Exists(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "commands_base.xml"))) Then
                            Me.bwDoInstall.ReportProgress(5, MyLang.GetString(53, "Executing Commands for Base"))
                            xmlSer = New XmlSerializer(GetType(InstallCommands))
                            Using xmlSW As New StreamReader(Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "commands_base.xml")))
                                _cmds = xmlSer.Deserialize(xmlSW)
                            End Using
                            LogWrite(String.Format("*** Execute DB File: {0}", Path.Combine(Path.GetDirectoryName(emberPath), String.Concat("updates", Path.DirectorySeparatorChar, "commands_base.xml"))))
                            For Each s As InstallCommand In _cmds.Command
                                If s.CommandType = "DB" Then
                                    LogWrite(String.Format("*** Execute DB: {0}", s.CommandExecute))
                                    UpdateTasks.Command.Add(s)
                                    HaveCommands = True
                                ElseIf s.CommandType = "FILE.Delete" Then
                                    Try
                                        LogWrite(String.Format("*** Execute File Delete: {0}", s.CommandExecute))
                                        File.Delete(Path.Combine(Path.GetDirectoryName(emberPath), s.CommandExecute.Replace("/", Path.DirectorySeparatorChar)))
                                    Catch ex As Exception
                                        LogWrite(String.Format("--- Error: {0}", ex.Message))
                                    End Try
                                End If
                            Next
                            If HaveCommands Then UpdateTasks.Save(Path.Combine(Path.GetDirectoryName(emberPath), "InstallTasks.xml"))
                        End If
                    Else
                        UpdateTasks.Command.Clear()
                        For Each f As FileInfo In fis
                            If f.Name.StartsWith("commands_") AndAlso f.Extension = ".xml" AndAlso Not f.Name = "commands_base.xml" Then
                                Me.bwDoInstall.ReportProgress(5, String.Format(MyLang.GetString(26, "Executing Commands for Version: {0}"), f.Name.Replace("commands_", String.Empty).Replace(".xml", String.Empty)))
                                xmlSer = New XmlSerializer(GetType(InstallCommands))
                                Using xmlSW As New StreamReader(f.FullName)
                                    _cmds = xmlSer.Deserialize(xmlSW)
                                End Using
                                LogWrite(String.Format("*** Execute DB File: {0}", f.Name))
                                For Each s As InstallCommand In _cmds.Command
                                    If s.CommandType = "DB" Then
                                        LogWrite(String.Format("*** Execute DB: {0}", s.CommandExecute))
                                        UpdateTasks.Command.Add(s)
                                        HaveCommands = True
                                    ElseIf s.CommandType = "FILE.Delete" Then
                                        Try
                                            LogWrite(String.Format("*** Execute File Delete: {0}", s.CommandExecute))
                                            File.Delete(Path.Combine(Path.GetDirectoryName(emberPath), s.CommandExecute.Replace("/", Path.DirectorySeparatorChar)))
                                        Catch ex As Exception
                                            LogWrite(String.Format("--- Error: {0}", ex.Message))
                                        End Try
                                    End If
                                Next
                            End If
                        Next
                        If HaveCommands Then UpdateTasks.Save(Path.Combine(Path.GetDirectoryName(emberPath), "UpdateTasks.xml"))
                    End If
                Catch ex As Exception
                End Try
                System.Threading.Thread.Sleep(1000)
                Me.bwDoInstall.ReportProgress(0, New Object() {80, ""})
                If bwDoInstall.CancellationPending Then Return False
                LogWrite(String.Format("*** Main: Commands END"))

            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try

            '###################################################################################
            Me.bwDoInstall.ReportProgress(5, MyLang.GetString(55, "Cleaning Up"))
            If Not CheckIfWindows() Then
                'Mono Can't run Movie Exporter.. Until Commands are working this will solve the issue
                File.Delete(Path.Combine(Path.Combine(emberPath, "Modules"), "generic.EmberCore.MovieExporter.dll"))
            End If
            RemoveSetupFolders(Path.GetDirectoryName(emberPath))
            System.Threading.Thread.Sleep(2000)
            LogWrite(String.Format("*** Main: Installation Finished with Success"))
            Me.bwDoInstall.ReportProgress(6, String.Format(MyLang.GetString(54, "Thank you for supporting Ember{0}You can now Start Ember Media Manager"), vbCrLf))

            '###################################################################################
        Else
            Me.bwDoInstall.ReportProgress(2, MyLang.GetString(27, "No Installation Path Found")) '  Error
            'No Instalation Path, This never should happen
        End If
        Return True
    End Function

    Sub DrawString(ByVal g As Graphics, ByVal l As MyLabel)
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim s() As String = l.Text.Split(vbCrLf)
        Dim line As Integer = 0
        Dim si As New SizeF

        For Each t As String In s
            si = g.MeasureString(t, l.Font, l.Width)
            If l.TextAlign = ContentAlignment.BottomCenter OrElse l.TextAlign = ContentAlignment.MiddleCenter OrElse l.TextAlign = ContentAlignment.TopCenter Then
                x = (l.Width - si.Width) / 2
            Else
                x = 0
            End If
            If l.TextAlign = ContentAlignment.MiddleLeft OrElse l.TextAlign = ContentAlignment.MiddleCenter OrElse l.TextAlign = ContentAlignment.MiddleRight Then
                y = (l.Height - (l.Font.Height * (s.Count + 1))) / 2
            Else
                y = 0
            End If
            g.DrawString(t, l.Font, New SolidBrush(l.ForeColor), l.Left + x, l.Top + y + (line * l.Font.Height))
            line += 1
            'g.DrawRectangle(Pens.Black, l.Left, l.Top, l.Width, l.Height)
        Next
    End Sub

    Private Sub FindFile(ByVal SourcePath As String, ByVal filename As String)
        If bwFF.CancellationPending Then
            Return
        End If
        Dim foundPath As String = String.Empty
        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        If SourceDir.Exists Then
            Dim ChildFile As FileInfo
            Try
                For Each ChildFile In SourceDir.GetFiles()
                    If Path.GetFileName(ChildFile.FullName).ToLower = filename Then
                        emberAllFounds.Add(ChildFile.FullName)
                    End If
                Next
            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try

            Dim SubDir As DirectoryInfo
            Try
                For Each SubDir In SourceDir.GetDirectories()
                    FindFile(SubDir.FullName, filename)
                    If bwFF.CancellationPending Then
                        Return
                    End If
                Next
            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmMainSetup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Refresh()
    End Sub

    Private Sub frmMainSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        LogWrite(String.Format("*** Main: END {0}", Now))

        If bwFF.IsBusy Then
            bwFF.CancelAsync()
        End If
        If ExitMe AndAlso Not AppPath() = emberPath Then
            Try
                If File.Exists(Path.Combine(emberPath, "install.log")) Then
                    File.Delete(Path.Combine(emberPath, "install.log"))
                End If
            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try
            Try
                File.Move(Path.Combine(AppPath, "install.log"), Path.Combine(emberPath, "install.log"))
            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try
        End If
        If File.Exists(Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml")) Then
            File.Delete(Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml"))
        End If
        If File.Exists(Path.Combine(frmMainSetup.AppPath, String.Format("Setup.{0}.xml", Language))) Then
            File.Delete(Path.Combine(frmMainSetup.AppPath, String.Format("Setup.{0}.xml", Language)))
        End If

        End
    End Sub

    Private Sub frmMainSetup_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim shape As New System.Drawing.Drawing2D.GraphicsPath
        'shape.AddRectangle(New Rectangle(0, 0, Me.Width, Me.Height))
        'Me.Region = New System.Drawing.Region(shape)
    End Sub

    Private Sub frmMainSetup_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Final Then
            w.Hide()
            w.Refresh()
            w.Close()
        End If
        Me.Activate()
        Me.Refresh()
        'Application.DoEvents()
    End Sub

    Private Sub SetUp()
        Me.Text = MyLang.GetString(43, "Setup - Ember Media Manager")
        Me.btnRunEmber.Text = MyLang.GetString(42, "Start Ember Media Manager")
        Me.btnInstall.Text = MyLang.GetString(39, "Install")
        Me.btnExit.Text = MyLang.GetString(38, "Exit")
        Me.btnOptions.Text = MyLang.GetString(40, "Change Options")
        Me.emmNotify.Text = MyLang.GetString(41, "EmberMM Setup")
        Me.llAbout.Text = MyLang.GetString(36, "About")
    End Sub


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SetupMyControls()
            InitCredits()
            If File.Exists(Path.Combine(AppPath, "Beta.Tester")) Then
                RemoteSiteFolder = "UpdatesBeta"
                IsBeta = True
            End If
            'Me.lblStatus.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent

            ' Optimize Painting.
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

            Dim Args() As String = Environment.GetCommandLineArgs
            For i As Integer = 1 To Args.Count - 1
                Select Case Args(i).ToLower
                    Case "-final"
                        Final = True
                        'w = New dlgCommands
                        w.TopMost = True
                        w.Show()
                        w.Activate()
                        w.Refresh()
                        emberPath = AppPath()
                        'NoArgs = False
                        If Args.Count - 1 > i Then
                            CurrentEmberVersion = Convert.ToInt32(Args(i + 1)).ToString
                            ExeCurrentEmberVersion = CurrentEmberVersion
                        End If
                        If Args.Count - 1 > i + 2 Then
                            Me.Top = Convert.ToInt32(Args(i + 2))
                            Me.Left = Convert.ToInt32(Args(i + 3))
                        End If
                    Case "-force"
                        Force = True
                    Case "-recover"
                        Recover = True
                    Case "-blind"
                        blindSetup = True
                End Select
            Next
            WindowsInstallPath = Path.GetDirectoryName(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData))
            Dim PInstallPath As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles)
            Dim fol As String = String.Concat(Path.GetDirectoryName(AppPath), "|", System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "|", PInstallPath, "|", WindowsInstallPath)
            For Each ss As String In fol.Split(New String() {"|"}, StringSplitOptions.RemoveEmptyEntries)
                If File.Exists(Path.Combine(Path.Combine(ss, "Ember Media Manager"), "Ember Media Manager.exe")) Then
                    emberPath = String.Concat(Path.Combine(ss, "Ember Media Manager"), Path.DirectorySeparatorChar)
                    Exit For
                End If
                If File.Exists(Path.Combine(ss, "Ember Media Manager.exe")) Then
                    emberPath = String.Concat(ss, Path.DirectorySeparatorChar)
                    Exit For
                End If
            Next
            If Not String.IsNullOrEmpty(emberPath) Then
                If File.Exists(Path.Combine(emberPath, "Setup.xml")) Then
                    eSettings = Settings.Load(Path.Combine(emberPath, "Setup.xml"))
                Else
                    eSettings = Settings.Load(Path.Combine(emberPath, "Settings.xml"))
                End If
            End If
            MyLang.GetFromSite()
            MyLang.Load()
            If MyLang.lLanguages.Count > 1 Then
                Using dLang As New dlgLanguage

                    For Each l As Langs.LanguageList In MyLang.lLanguages
                        dLang.cbLanguage.Items.Add(l.Name)
                    Next
                    Dim si As Integer = dLang.cbLanguage.Items.IndexOf("English (en/US)")
                    If si >= 0 Then dLang.cbLanguage.SelectedIndex = si
                    If dLang.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Language = MyLang.lLanguages.FirstOrDefault(Function(y) y.Name = dLang.cbLanguage.Text).Filename
                        'Language = dLang.cbLanguage.Text
                        MyLang.LoadLanguage(Language)
                    End If
                End Using
            End If

            SetUp()

            If Final Then
                LogoStop = False
                '"Wait Calling instace to finish
                Dim p As Process()
                Try
                    p = Process.GetProcessesByName("EmberSetup")
                    While p.Count > 1
                        Try
                            Application.DoEvents()
                            p = Process.GetProcessesByName("EmberSetup")
                        Catch ex As Exception
                            LogWrite(String.Format("--- Error: {0}", ex.Message))
                            LogWrite(ex.StackTrace)
                        End Try
                    End While
                Catch ex As Exception
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                End Try
                'All of this is just for smooth Visual transitions

                System.Threading.Thread.Sleep(500)
                lblStatus.TextAlign = ContentAlignment.MiddleCenter
                lblStatus.ForeColor = Color.Blue
                lblStatus.Font = New Font("Arial", 11, FontStyle.Bold)
                lblStatus.Text = MyLang.GetString(27, "Loading Settings")
                lblInfo.Text = ""
                btnInstall.Enabled = False
                btnOptions.Enabled = False
                Me.Show()
                System.Threading.Thread.Sleep(1000)
                LogWrite(String.Format("*** Main: SECOND START {0}", Now))
                System.Threading.Thread.Sleep(500)
                'Re-Start at Commands stuff
                StartWorker()
            Else
                'Wait Calling instace to finish
                Dim p As Process()
                Try
                    p = Process.GetProcessesByName("EmberSetup")
                    If p.Count > 1 Then
                        Dim w = New dlgCommands
                        w.lblStatus.Text = MyLang.GetString(28, "Can Only Run ONE Setup Instance")
                        w.TopMost = True
                        w.Show()
                        Me.Refresh()
                        Application.DoEvents()
                        System.Threading.Thread.Sleep(3000)
                        Me.Close()
                    End If
                Catch ex As Exception
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                End Try
                Try
                    Dim timeOut As Integer = 0
                    p = Process.GetProcessesByName("Ember Media Manager")
                    While p.Count > 0
                        System.Threading.Thread.Sleep(500)
                        Application.DoEvents()
                        p = Process.GetProcessesByName("Ember Media Manager")
                        timeOut += 1
                        If timeOut > 30 Then ' ~15 seconds
                            ' TODO Msg User and kill Ember
                            Exit While
                        End If
                    End While
                Catch ex As Exception
                End Try
                Try
                    File.Delete(Path.Combine(AppPath, "install.log"))
                Catch ex As Exception
                    LogWrite(String.Format("--- Error: {0}", ex.Message))
                    LogWrite(ex.StackTrace)
                End Try
                LogWrite(String.Format("*** Main: START {0}", Now))
                Dim EmberFound As Boolean = False
                WindowsInstallPath = Path.GetDirectoryName(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData))

                Dim PFInstallPath As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles)
                fol = String.Concat(Path.GetDirectoryName(AppPath), "|", System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "|", PFInstallPath, "|", WindowsInstallPath)
                For Each ss As String In fol.Split(New String() {"|"}, StringSplitOptions.RemoveEmptyEntries)
                    If File.Exists(Path.Combine(Path.Combine(ss, "Ember Media Manager"), "Ember Media Manager.exe")) OrElse File.Exists(Path.Combine(ss, "Ember Media Manager.exe")) Then
                        If File.Exists(Path.Combine(Path.Combine(ss, "Ember Media Manager"), "Ember Media Manager.exe")) Then
                            emberPath = String.Concat(Path.Combine(ss, "Ember Media Manager"), Path.DirectorySeparatorChar)
                        Else
                            emberPath = String.Concat(ss, Path.DirectorySeparatorChar)
                        End If
                        EmberFound = True
                        CurrentEmberVersion = GetEmberVersion(emberPath)
                        LogWrite(String.Format("--- Main: Found Ember Version: {0}", If(CurrentEmberVersion = String.Empty OrElse CurrentEmberVersion = "0", "(None)", CurrentEmberVersion)))
                        CurrentEmberPlatform = GetEmberPlatform(emberPath)
                        LogWrite(String.Format("--- Main: Found Ember Platform: {0}", CurrentEmberPlatform))
                        lblInfo.TextAlign = ContentAlignment.MiddleCenter
                        lblInfo.Text = String.Format(MyLang.GetString(29, "We have found a EMM Installation in {0}"), vbCrLf)
                        lblInfo.Text += String.Format("{0}{1}{1}", emberPath, vbCrLf)
                        If Not Force Then
                            lblInfo.Text += MyLang.GetString(30, "If you want to change this please use [Change Options]")
                        End If
                        Exit For
                    End If
                Next
                If Not EmberFound Then
                    If CheckIfWindows() Then
                        emberPath = Path.Combine(WindowsInstallPath, "Ember Media Manager")
                    Else
                        emberPath = Path.Combine(String.Concat("~", Path.DirectorySeparatorChar), "Ember Media Manager")
                    End If
                    emberPath = If(Not emberPath.EndsWith(Path.DirectorySeparatorChar), String.Concat(emberPath, Path.DirectorySeparatorChar), emberPath)
                    CurrentEmberPlatform = If(Is64Bit, "x64", "x86")
                    lblInfo.TextAlign = ContentAlignment.MiddleCenter
                    lblInfo.Text = String.Format(MyLang.GetString(31, "No Ember Media Manager Installation Found{0}"), vbCrLf)
                    lblInfo.Text += String.Format(MyLang.GetString(32, "Default Installation Folder{0}"), vbCrLf)
                    lblInfo.Text += String.Format("{0}{1}{1}", emberPath, vbCrLf)
                    lblInfo.Text += MyLang.GetString(33, "Please use [Change Options] to change the Installation Folder")
                End If
                lblStatus.Text = MyLang.GetString(34, "Welcome to Ember Media Manager Installation")
            End If
            If Not emberPath = String.Empty AndAlso Not CurrentEmberPlatform = String.Empty Then
                btnInstall.Enabled = True
                LogWrite(String.Format("--- Main: Setting Install Path: {0}", emberPath))
            End If
            If Force OrElse Recover Then
                StartWorker()
                LogoStop = False
                llAbout.Visible = False
            End If
            CheckIsSiteReady()
        Catch ex As Exception
            LogWrite(String.Format("+++ Main: ERROR ON LOAD ... EXIT"))
            LogWrite(ex.Message)
            LogWrite(ex.StackTrace)
            Me.Close()
        End Try
    End Sub

    Sub CheckIsSiteReady()
        Dim SiteReady As String = DownloadTextData("status.php")
        If SiteReady = "BUSY" Then
            isSiteReady = False
        Else
            isSiteReady = True
        End If
    End Sub

    Function GetFromList(ByVal l As FilesList, ByVal f As FileOfList) As FileOfList
        Try
            For Each fi As FileOfList In l.Files
                If fi.Filename = f.Filename AndAlso fi.Path = f.Path AndAlso fi.Platform = f.Platform Then
                    Return fi
                End If
            Next
        Catch ex As Exception
            LogWrite(String.Format("--- Error: {0}", ex.Message))
            LogWrite(ex.StackTrace)
        End Try
        Return Nothing
    End Function

    Function GetHash(ByVal fname As String)
        Using reader As New FileStream(fname, FileMode.Open, FileAccess.Read)
            Dim KeyValue As Byte() = (New System.Text.UnicodeEncoding).GetBytes("HashingKey")
            Using HMA As New HMACSHA1(KeyValue, True)

                Dim hash() As Byte = HMA.ComputeHash(reader)

                Dim sb As New StringBuilder(hash.Length * 2)

                For i As Integer = 0 To hash.Length - 1
                    sb.Append(hash(i).ToString("X2"))
                Next

                Return sb.ToString().ToLower
            End Using
        End Using
    End Function

    Sub InitCredits()
        CredList.Add(New CredLine With {.Text = "Ember Media Manager", .Font = New Font("Microsoft Sans Serif", 18, FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = My.Application.Info.Description, .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = My.Application.Info.Copyright, .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Created By: Jason Schnitzler", .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "__________Project Coders__________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        'CredList.Add(New CredLine With {.Text = "_______Project Main Coders________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Jason ""nul7"" Schnitzler"})
        CredList.Add(New CredLine With {.Text = "Nuno ""Zordor"" Novais"})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        'CredList.Add(New CredLine With {.Text = "__________Project Manager_________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = "___QA/Documentation Coordinator___", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Bence ""olympia"" Nádas"})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        'CredList.Add(New CredLine With {.Text = "__________Project Coders__________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        'CredList.Add(New CredLine With {.Text = String.Empty})
        'CredList.Add(New CredLine With {.Text = String.Empty})
        'CredList.Add(New CredLine With {.Text = String.Empty})
        'CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "___________Beta Testers___________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Tristan ""sphere"" Fischer"})
        CredList.Add(New CredLine With {.Text = "Bud ""WheresWaldo"" Hammerton"})
        CredList.Add(New CredLine With {.Text = "Wayne ""nitr8"" Humphrey"})
        CredList.Add(New CredLine With {.Text = "Roberto Lucena"})
        CredList.Add(New CredLine With {.Text = "Brenton McSweyn"})
        CredList.Add(New CredLine With {.Text = "Clay Mitchell"})
        CredList.Add(New CredLine With {.Text = "Adyn Rex"})
        CredList.Add(New CredLine With {.Text = "Chris ""NasaGeek"" Roberts"})
        CredList.Add(New CredLine With {.Text = "Tom ""themugger"" Shine"})
        CredList.Add(New CredLine With {.Text = "Dale ""FidoFuz"" Williams"})
        CredList.Add(New CredLine With {.Text = "Alex ""spylex"" Spyrou"})
        CredList.Add(New CredLine With {.Text = "Daniel Z."})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "___________Contributors___________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Darren ""RogueDazza"" Sayers"})
        CredList.Add(New CredLine With {.Text = "Jim ""FCCWizard"" Brown"})
        CredList.Add(New CredLine With {.Text = "Jeremy ""Jem"" Worboys"})
        CredList.Add(New CredLine With {.Text = """pcjco"""})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "__________Special Thanks__________", .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline Or FontStyle.Bold)})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Carlos ""asphinx"" Nabb - Genre Images"})
        CredList.Add(New CredLine With {.Text = "Benjamin ""ccMatrix"" Schirmer - Studio Icon Repository"})
        CredList.Add(New CredLine With {.Text = """Jezz_X"" and Wayne ""nitr8"" Humphrey - Media Flags"})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Ember Media Manager is free software:"})
        CredList.Add(New CredLine With {.Text = "you can redistribute it and/or modify"})
        CredList.Add(New CredLine With {.Text = "it under the terms of the GNU General"})
        CredList.Add(New CredLine With {.Text = "Public License as published by the Free"})
        CredList.Add(New CredLine With {.Text = "Software Foundation, either version 3"})
        CredList.Add(New CredLine With {.Text = "of the License, or (at your option) any"})
        CredList.Add(New CredLine With {.Text = "later version."})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "Ember Media Manager is distributed in"})
        CredList.Add(New CredLine With {.Text = "the hope that it will be useful, but"})
        CredList.Add(New CredLine With {.Text = "WITHOUT ANY WARRANTY; without even the"})
        CredList.Add(New CredLine With {.Text = "implied warranty of MERCHANTABILITY or"})
        CredList.Add(New CredLine With {.Text = "FITNESS FOR A PARTICULAR PURPOSE."})
        CredList.Add(New CredLine With {.Text = String.Empty})
        CredList.Add(New CredLine With {.Text = "See the GNU General Public License for more details."})
        PicY = Me.MyBackGround.Height
    End Sub

    Private Sub llAbout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAbout.LinkClicked
        ShowCredits = Not ShowCredits
        If ShowCredits Then
            Timer1.Enabled = False
            llAbout.Text = MyLang.GetString(35, "Back")
            btnInstall.Tag = btnInstall.Visible
            btnInstall.Visible = False
            btnOptions.Tag = btnOptions.Visible
            btnOptions.Visible = False
            btnExit.Tag = btnExit.Visible
            btnExit.Visible = False

            LogoStop = False
            PicY = Me.MyBackGround.Height
        Else
            Timer1.Enabled = True
            llAbout.Text = MyLang.GetString(36, "About")
            btnInstall.Visible = btnInstall.Tag
            btnOptions.Visible = btnOptions.Tag
            btnExit.Visible = btnExit.Tag
            LogoStop = True
            Me.Refresh()
        End If
    End Sub

    Private Sub MyBackGround_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBackGround.Paint
        SyncLock mePainting
            Try
                Dim g As Graphics = e.Graphics
                If CheckIfWindows() Then
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
                    'g.CompositingMode = Drawing2D.CompositingMode.SourceOver
                    If iLogo Is Nothing Then
                        SetupLogo()
                    End If
                    Dim WaterLine As Double = 0.78
                    Dim DrawRect As New Rectangle(0, 0, Me.MyBackGround.Width, Me.MyBackGround.Height * WaterLine)
                    g.FillRectangle(New Drawing2D.LinearGradientBrush(DrawRect, Color.FromArgb(255, 180 + BackAlpha, 180 + BackAlpha, 255), Color.FromArgb(255, 250 - BackAlpha, 250 - BackAlpha, 250), Drawing2D.LinearGradientMode.Vertical), DrawRect)
                    DrawRect = New Rectangle(0, Convert.ToInt32(Me.MyBackGround.Height * WaterLine), Me.MyBackGround.Width, Convert.ToInt32(Me.MyBackGround.Height * (1 - WaterLine)))
                    g.FillRectangle(New Drawing2D.LinearGradientBrush(DrawRect, Color.White, Color.FromArgb(255, 230, 230, 230), Drawing2D.LinearGradientMode.Vertical), DrawRect)
                    Dim x As Integer = Convert.ToInt32((Me.MyBackGround.Width - My.Resources.Logo.Width) / 2)
                    Dim y As Integer = Convert.ToInt32((Me.MyBackGround.Height - My.Resources.Logo.Height) / 2)
                    g.DrawImage(iLogo, x, y, My.Resources.Logo.Width, My.Resources.Logo.Height)
                    If DisablePaint Then Return
                    UpdateBackgorund()
                End If
                If ShowCredits Then
                    Credits(g)
                    'If Not bCredits Is Nothing Then g.DrawImage(bCredits, 0, 0)
                Else
                    DrawString(g, lblStatus)
                    DrawString(g, lblInfo)
                End If
                If CheckIfWindows() Then Me.MyBackGround.Invalidate()
            Catch ex As Exception
                LogWrite(String.Format("--- Error: {0}", ex.Message))
                LogWrite(ex.StackTrace)
            End Try
        End SyncLock
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
    End Sub

    Sub SetupLogo()
        Dim tLogo = New Bitmap(My.Resources.Logo)
        For xPix As Integer = 0 To tLogo.Width - 1
            For yPix As Integer = 0 To tLogo.Height - 1
                Dim clr As Color = tLogo.GetPixel(xPix, yPix)
                If clr.A > LogoAlpha Then
                    clr = Color.FromArgb(LogoAlpha, clr.R, clr.G, clr.B)
                    tLogo.SetPixel(xPix, yPix, clr)
                End If
            Next
        Next
        iLogo = New Bitmap(tLogo)
    End Sub

    Sub SetupMyControls()
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(18, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(470, 27)
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter

        Me.lblInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(18, 36)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(470, 170)
        Me.lblInfo.Text = "lblInfo"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '###############################################################3
    End Sub

    Sub StartSetup()
        Try
            Dim startInfo As New ProcessStartInfo(Path.Combine(emberPath, "EmberSetup.exe"))
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo.Arguments = String.Format("-final {0} {1} {2}", If(CurrentEmberVersion = String.Empty, "0", CurrentEmberVersion), Me.Top, Me.Left)
            Process.Start(startInfo)
            System.Threading.Thread.Sleep(1000)
        Catch ex As Exception
            LogWrite(String.Format("--- Error: {0}", ex.Message))
            LogWrite(ex.StackTrace)

        End Try
    End Sub

    Sub StartWorker()
        If File.Exists(Path.Combine(emberPath, "Setup.xml")) Then
            eSettings = Settings.Load(Path.Combine(emberPath, "Setup.xml"))
        Else
            eSettings = Settings.Load(Path.Combine(emberPath, "Settings.xml"))
        End If
        btnExit.Text = MyLang.GetString(37, "Cancel")
        btnInstall.Enabled = False
        btnOptions.Enabled = False
        bwDoInstall.WorkerReportsProgress = True
        bwDoInstall.WorkerSupportsCancellation = True
        lblInfo.Text = ""
        pnlProgress.Visible = True
        pbFiles.Visible = True
        pbFiles.Style = ProgressBarStyle.Marquee
        bwDoInstall.RunWorkerAsync()
        'Application.DoEvents()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Me.Refresh()
        Application.DoEvents()
    End Sub

    Sub UpdateBackgorund()
        If Not LogoStop OrElse Not LogoAlpha = 50 Then
            If LogoUp Then
                'LogoAlpha += 5
            Else
                'LogoAlpha -= 5
            End If
        End If
        If LogoAlpha > 90 OrElse LogoAlpha < 20 Then
            LogoUp = Not LogoUp
        End If
        intcounter += 1
        If intcounter > 15 Then
            If BackUp Then
                BackAlpha += 2
            Else
                BackAlpha -= 2
            End If
            If BackAlpha > 70 OrElse BackAlpha < 0 Then
                BackUp = Not BackUp
            End If
            intcounter = 0
        End If
        'SetupLogo()
        'Credits()
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class Comparer
        Implements IComparer(Of FileInfo)

        Public Function Compare(ByVal x As FileInfo, _
            ByVal y As FileInfo) As Integer Implements IComparer(Of FileInfo).Compare
            Return x.Name.CompareTo(y.Name)
        End Function

    End Class

    Friend Class CredLine

        Private _font As Font
        Private _text As String

        Public Sub New()
            Clear()
        End Sub

        Public Property Font() As Font
            Get
                Return _font
            End Get
            Set(ByVal value As Font)
                _font = value
            End Set
        End Property

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        Public Sub Clear()
            _text = String.Empty
            _font = New Font("Microsoft Sans Serif", 11, FontStyle.Regular)
        End Sub

    End Class

    Class MyLabel
        Inherits Label

        ' My Label Class, Inherits from Label so i do not need to implement all Properties
        Private _visible As Boolean = True

        Public Sub New()
            MyBase.AutoSize = False
            MyBase.Visible = False
        End Sub

        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As Color)
                MyBase.BackColor = value
            End Set
        End Property

        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                frmMainSetup.MyBackGround.Invalidate()
            End Set
        End Property

        Public Shadows Property Visible() As Boolean
            Get
                Return _visible
            End Get
            Set(ByVal value As Boolean)
                _visible = value
            End Set
        End Property

        Public Overloads Sub SetStyle(ByVal style As ControlStyles, ByVal value As Boolean)
            MyBase.SetStyle(style, value)
        End Sub
    End Class

    Public Class Settings
        Private _proxycredentials As NetworkCredential
        Private _proxyport As Integer
        Private _proxyuri As String
        Public Property ProxyCreds() As NetworkCredential
            Get
                Return Me._proxycredentials
            End Get
            Set(ByVal value As NetworkCredential)
                Me._proxycredentials = value
            End Set
        End Property

        Public Property ProxyPort() As Integer
            Get
                Return Me._proxyport
            End Get
            Set(ByVal value As Integer)
                Me._proxyport = value
            End Set
        End Property

        Public Property ProxyURI() As String
            Get
                Return Me._proxyuri
            End Get
            Set(ByVal value As String)
                Me._proxyuri = value
            End Set
        End Property
        Sub New()
            Me._proxyuri = String.Empty
            Me._proxyport = -1
            Me.ProxyCreds = New NetworkCredential
        End Sub

        Public Shared Function Load(ByVal fname As String) As Settings
            Try
                Dim eset As Settings
                Dim xmlSerial As New XmlSerializer(GetType(Settings))

                If File.Exists(fname) Then
                    Dim strmReader As New StreamReader(fname)
                    eset = DirectCast(xmlSerial.Deserialize(strmReader), Settings)
                    strmReader.Close()
                    Return eset
                Else
                    Return New Settings
                End If
            Catch ex As Exception
                'Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Return New Settings
            End Try
        End Function

        Public Sub Save(ByVal fname As String)
            Try
                Dim xmlSerial As New XmlSerializer(GetType(Settings))
                Dim xmlWriter As New StreamWriter(fname)
                xmlSerial.Serialize(xmlWriter, Me)
                xmlWriter.Close()
            Catch ex As Exception
                'Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub
    End Class
#End Region 'Nested Types

End Class