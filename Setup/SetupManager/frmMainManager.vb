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

Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Drawing.Imaging

Public Class frmMainManager

#Region "Fields"

    Public Shared EmberVersions As New UpgradeList
    Public Shared ModulesVersions As New _LastVersion
    Public Shared OPaths As New List(Of OrigPaths)

    Public CurrentEmberPath As String = String.Empty
    Public CurrentEmberPlatform As String
    Public CurrentEmberVersion As String
    Public MasterDB As New DB
    Public Platform As String = "x86"

    Friend WithEvents bwFF As New System.ComponentModel.BackgroundWorker

    Dim AddCommand As Boolean = False
    Dim CmdsChanged As Boolean = False
    Dim CmdVersion As String
    Dim excludesDirs As New ArrayList
    Dim excludesFiles As New ArrayList
    Dim excludesFilesInFolders As New List(Of FilesInFolders)
    Dim InCommandTab As Boolean
    Dim SetupSettings As New SetupManager.Settings
    Dim _cmds As New InstallCommands

#End Region 'Fields

#Region "Methods"

    Public Shared Function AppPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory
    End Function

    Public Shared Sub CompressFile(ByVal spath As String, ByVal dpath As String)
        Dim sourceFile As FileStream = File.OpenRead(spath)
        Dim destinationFile As FileStream = File.Create(dpath)

        Dim buffer(Convert.ToInt32(sourceFile.Length)) As Byte
        sourceFile.Read(buffer, 0, buffer.Length)

        Using output As New GZipStream(destinationFile, _
            CompressionMode.Compress)

            Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name, _
                destinationFile.Name, False)

            output.Write(buffer, 0, buffer.Length)
        End Using

        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

    Public Shared Sub DeleteDirectory(ByVal sPath As String)
        Try
            If Directory.Exists(sPath) Then
                Dim Dirs As New ArrayList
                Try
                    Dirs.AddRange(Directory.GetDirectories(sPath))
                Catch
                End Try
                For Each inDir As String In Dirs
                    DeleteDirectory(inDir)
                Next
                Dim fFiles As New ArrayList
                Try
                    fFiles.AddRange(Directory.GetFiles(sPath))
                Catch
                End Try
                For Each fFile As String In fFiles
                    Try
                        File.Delete(fFile)
                    Catch
                    End Try
                Next
                Directory.Delete(sPath, True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub UncompressFile(ByVal spath As String, ByVal dpath As String)
        Dim sourceFile As FileStream = File.OpenRead(spath)
        Dim destinationFile As FileStream = File.Create(dpath)

        ' Because the uncompressed size of the file is unknown,
        ' we are imports an arbitrary buffer size.
        Dim buffer(4096) As Byte
        Dim n As Integer

        Using input As New GZipStream(sourceFile, _
            CompressionMode.Decompress, False)

            Console.WriteLine("Decompressing {0} to {1}.", sourceFile.Name, _
                destinationFile.Name)

            n = input.Read(buffer, 0, buffer.Length)
            destinationFile.Write(buffer, 0, n)
        End Using

        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

    Public Sub DoPopulateFiles()
        DisableGui()
        lstFiles.Items.Clear()
        LoadExcludes()
        bwFF.WorkerSupportsCancellation = True
        bwFF.WorkerReportsProgress = True
        bwFF.RunWorkerAsync()
    End Sub

    Public Function GetEmberPlatform(ByVal fpath As String) As String
        Try

            Dim _Assembly As Assembly = Assembly.ReflectionOnlyLoadFrom(Path.Combine(fpath, "Ember Media Manager.exe"))

            Dim kinds As PortableExecutableKinds
            Dim imgFileMachine As ImageFileMachine
            _Assembly.ManifestModule.GetPEKind(kinds, imgFileMachine)
            If (kinds And PortableExecutableKinds.PE32Plus) = PortableExecutableKinds.PE32Plus Then
                Return "64"
            End If
        Catch ex As Exception
        End Try
        Return "32"
    End Function

    Public Function GetEmberVersion(ByVal fpath As String) As String
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(fpath, "Ember Media Manager.exe"))
        Return myBuildInfo.ProductPrivatePart.ToString
    End Function

    'ugly and dirt but do the job
    Public Sub GetModulesVersions()
        lstModulesx86.Items.Clear()
        lstModulesx64.Items.Clear()
        ModulesVersions.Modules.Clear()
        Dim o As New FileOfList
        Dim m As String = String.Empty
        Dim v As String = String.Empty
        Using SQLcommandEmberFiles As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommandEmberFiles.CommandText = String.Concat("Select * FROM EmberFiles;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommandEmberFiles.ExecuteReader()
                While SQLreader.Read
                    If Convert.ToBoolean(SQLreader("UseFile")) Then
                        o = New FileOfList
                        If Not DBNull.Value.Equals(SQLreader("EmberPath")) Then o.Path = SQLreader("EmberPath").ToString
                        If Not DBNull.Value.Equals(SQLreader("Filename")) Then o.Filename = SQLreader("Filename").ToString
                        If Not DBNull.Value.Equals(SQLreader("Hash")) Then o.Hash = SQLreader("Hash").ToString
                        If Not DBNull.Value.Equals(SQLreader("Platform")) Then o.Platform = SQLreader("Platform").ToString
                        If (SQLreader("EmberPath").ToString = "\Modules" AndAlso Path.GetExtension(SQLreader("Filename").ToString) = ".dll") Then
                            If File.Exists(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)) Then
                                v = FileVersionInfo.GetVersionInfo(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)).ProductPrivatePart.ToString
                                ModulesVersions.Modules.Add(New _Module With {.Version = v, .Name = SQLreader("Filename").ToString, .Platform = SQLreader("Platform").ToString})
                                If SQLreader("Platform").ToString = "x86" Then
                                    lstModulesx86.Items.Add((New ListViewItem(SQLreader("Filename").ToString))).SubItems.Add(v)
                                Else
                                    lstModulesx64.Items.Add((New ListViewItem(SQLreader("Filename").ToString))).SubItems.Add(v)
                                End If
                            End If
                        End If

                        If SQLreader("Filename").ToString.ToLower = "ember media manager.exe" Then

                            If File.Exists(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)) Then
                                v = FileVersionInfo.GetVersionInfo(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)).ProductPrivatePart.ToString
                                ModulesVersions.Modules.Add(New _Module With {.Version = v, .Name = "*EmberAPP", .Platform = SQLreader("Platform").ToString})
                                If SQLreader("Platform").ToString = "x86" Then
                                    lstModulesx86.Items.Add((New ListViewItem("*EmberAPP"))).SubItems.Add(v)
                                Else
                                    lstModulesx64.Items.Add((New ListViewItem("*EmberAPP"))).SubItems.Add(v)
                                End If
                            End If
                        End If
                        If SQLreader("Filename").ToString.ToLower = "emberapi.dll" Then
                            v = String.Empty
                            If File.Exists(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)) Then
                                v = FileVersionInfo.GetVersionInfo(Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)).ProductPrivatePart.ToString
                                ModulesVersions.Modules.Add(New _Module With {.Version = v, .Name = "*EmberAPI", .Platform = SQLreader("Platform").ToString})
                                If SQLreader("Platform").ToString = "x86" Then
                                    lstModulesx86.Items.Add((New ListViewItem("*EmberAPI"))).SubItems.Add(v)
                                Else
                                    lstModulesx64.Items.Add((New ListViewItem("*EmberAPI"))).SubItems.Add(v)
                                End If
                            End If
                        End If
                    End If
                End While
            End Using
        End Using

        ModulesVersions.Save(Path.Combine(AppPath, String.Concat("site", Path.DirectorySeparatorChar, "versions.xml")))
    End Sub

    Public Sub LoadOPaths()
        OPaths.Clear()
        Using SQLcommand As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommand.CommandText = String.Concat("SELECT * FROM OrigPaths;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                Dim o As OrigPaths
                While SQLreader.Read
                    o = New OrigPaths
                    If Not DBNull.Value.Equals(SQLreader("OrigPath")) Then o.origpath = SQLreader("OrigPath").ToString
                    If Not DBNull.Value.Equals(SQLreader("EmberPath")) Then o.emberpath = SQLreader("EmberPath").ToString
                    If Not DBNull.Value.Equals(SQLreader("Recursive")) Then o.recursive = Convert.ToBoolean(SQLreader("Recursive"))
                    If Not DBNull.Value.Equals(SQLreader("Platform")) Then o.platform = SQLreader("Platform").ToString
                    OPaths.Add(o)
                End While
            End Using
        End Using
    End Sub

    Public Sub PopulateFileList(ByRef _f As FilesList)
        Dim o As New FileOfList
        Dim m As String = String.Empty
        Using SQLcommandEmberFiles As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommandEmberFiles.CommandText = String.Concat("Select * FROM EmberFiles;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommandEmberFiles.ExecuteReader()
                While SQLreader.Read
                    If Convert.ToBoolean(SQLreader("UseFile")) Then
                        o = New FileOfList
                        If Not DBNull.Value.Equals(SQLreader("EmberPath")) Then o.Path = SQLreader("EmberPath").ToString
                        If Not DBNull.Value.Equals(SQLreader("Filename")) Then o.Filename = SQLreader("Filename").ToString
                        If Not DBNull.Value.Equals(SQLreader("Hash")) Then o.Hash = SQLreader("Hash").ToString
                        If Not DBNull.Value.Equals(SQLreader("Platform")) Then o.Platform = SQLreader("Platform").ToString
                        _f.Files.Add(o)

                    End If
                End While
            End Using
        End Using
    End Sub

    Sub AddToDB(ByVal s As String, ByVal o As OrigPaths)
        Dim op As New OrigPaths
        op = o
        Dim fti As New EmberFiles
        fti.FTI = New FileToInstall
        fti.FTI.OriginalPath = Path.GetDirectoryName(s)
        fti.FTI.EmberPath = String.Concat(op.emberpath, Path.GetDirectoryName(s).Replace(op.origpath, String.Empty))
        fti.FTI.Filename = Path.GetFileName(s)
        fti.FTI.Hash = GetHash(s)
        fti.FTI.Platform = op.platform
        fti.UseFile = True
        If excludesFiles.Contains(fti.FTI.Filename) Then
            fti.UseFile = False
        End If
        If excludesFilesInFolders.Contains(New FilesInFolders With {.Filename = fti.FTI.Filename, .EmberPath = fti.FTI.EmberPath}) Then
            fti.UseFile = False
        End If
        MasterDB.DBAddChangeEmberFile(fti)
    End Sub

    Private Sub AllwaysExcludeFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllwaysExcludeFileToolStripMenuItem.Click
        If lstFiles.SelectedItems.Count > 0 Then
            Dim ee As New EmberFiles
            ee = MasterDB.DBGetEmberFile(lstFiles.SelectedItems(0).Text, lstFiles.SelectedItems(0).SubItems(1).Text)
            ee.UseFile = False
            MasterDB.DBAddChangeEmberFile(ee)
            MasterDB.DBAddChangeExcludeFile(lstFiles.SelectedItems(0).SubItems(1).Text)
            LoadExcludes()
            LoadFiles(CheckBox1.Checked)
        End If
    End Sub

    Private Sub AllwaysExcludeFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllwaysExcludeFolderToolStripMenuItem.Click
        If lstFiles.SelectedItems.Count > 0 Then
            MasterDB.DBAddChangeExcludeDir(Path.GetFileName(lstFiles.SelectedItems(0).SubItems(0).Text))
            MasterDB.DBDeleteAllEmberFile()
            DoPopulateFiles()
            'LoadExcludes()
            'LoadFiles(CheckBox1.Checked)
        End If
    End Sub

    Private Sub btnAddPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOriginPath.Click
        Using opath As New dlgOrigPaths
            opath.ShowDialog()
        End Using
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        cbType.SelectedIndex = 0
        CmdsChanged = False
        CheckCommandButtons()
        gbCommands.Visible = True
        txtCommand.Text = String.Empty
        txtDescriptions.Text = String.Empty
        AddCommand = True
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        DoPopulateFiles()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If btnRemove.Text = "Cancel" Then
            CmdsChanged = False
            CheckCommandButtons()
        End If
        If btnRemove.Text = "Remove" Then
            CmdsChanged = False
            CheckCommandButtons()
            lstCommands.SelectedItems(0).Remove()
            SaveCommands(False)
            LoadCommands(CmdVersion)
            ShowCommands()
        End If
        AddCommand = False
    End Sub

    Private Sub btnRescan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRescan.Click
        MasterDB.DBDeleteAllEmberFile()
        DoPopulateFiles()
    End Sub

    Private Sub btnSaveVesrion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveVersion.Click
        pnlWork.Visible = True
        Application.DoEvents()
        Dim v As New Versions
        v.Version = txtEMMVersion.Text
        Dim found As Boolean = False
        For Each f As Versions In EmberVersions.VersionList
            If f.Version = v.Version Then
                found = True
                Exit For
            End If
        Next
        If Not found Then
            EmberVersions.VersionList.Add(v)
        End If
        EmberVersions.Save(Path.Combine(AppPath, String.Concat("site", Path.DirectorySeparatorChar, "versionlist.xml")))
        Dim sVersion As String = String.Concat("<?xml version=""1.0"" encoding=""utf-8"" ?> ", vbCrLf, String.Format("<version current=""{0}"" /> ", v.Version))
        'UNCOMMENT when we go live
        File.WriteAllText(Path.Combine(AppPath, String.Concat("site", Path.DirectorySeparatorChar, "Update.xml")), sVersion, System.Text.Encoding.ASCII)
        Dim _files As New FilesList
        _files.Files = New List(Of FileOfList)
        PopulateFileList(_files)
        _files.Save(Path.Combine(AppPath, String.Format(String.Concat("site", Path.DirectorySeparatorChar, "version_{0}.xml"), v.Version)))
        Dim _cmds As New InstallCommands
        _cmds.Command = New List(Of InstallCommand)
        If Not File.Exists(SetupSettings.DbPath) OrElse Not File.Exists(Path.Combine(AppPath, String.Format(String.Concat("site", Path.DirectorySeparatorChar, "commands_base.xml")))) Then
            'For Each s As String In DefaultStrings.Tables
            '_cmds.Command.Add(New InstallCommand With {.CommandType = "DB", .CommandExecute = s})
            'Next
            Dim fd As New OpenFileDialog
            MsgBox("Please choose a Media Database", MsgBoxStyle.Critical, AcceptButton)
            If fd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If File.Exists(fd.FileName) Then
                    CreateCommandBase(fd.FileName)
                End If
            End If

            SetupSettings.DbPath = (fd.FileName)
            SetupSettings.Save(Path.Combine(AppPath, "settings.xml"))
        Else
            CreateCommandBase(SetupSettings.DbPath)
        End If
        GetModulesVersions()
        '_cmds.Save(Path.Combine(AppPath, String.Format("site\commands_{0}.xml", v.Version)))
        pnlWork.Visible = False
        LoadVersions()
    End Sub
    Sub CreateCommandBase(ByVal fname As String)
        Dim lSQLcn As New SQLite.SQLiteConnection()
        lSQLcn.ConnectionString = String.Format("Data Source=""{0}"";Compress=True", fname)
        lSQLcn.Open()
        Using SQLcommand As SQLite.SQLiteCommand = lSQLcn.CreateCommand
            SQLcommand.CommandText = "select type, sql from sqlite_master;"
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                While SQLreader.Read
                    If Not DBNull.Value.Equals(SQLreader("sql")) Then
                        Dim cmd As String = SQLreader("sql").ToString
                        Dim t As String = SQLreader("type").ToString
                        If (t = "index" OrElse t = "table") AndAlso Not cmd.Contains("CREATE TABLE sqlite_sequence") Then
                            _cmds.Command.Add(New InstallCommand With {.CommandType = "DB", .CommandExecute = cmd})
                        End If
                    End If
                End While
            End Using
        End Using
        _cmds.Save(Path.Combine(AppPath, String.Format(String.Concat("site", Path.DirectorySeparatorChar, "commands_base.xml"))))
        _cmds.Command.Clear()
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AddCommand Then
            Dim i As ListViewItem = lstCommands.Items.Add(DirectCast(cbType.SelectedItem, String))
            i.Selected = True
            i.SubItems.Add("")
        End If
        SaveCommands()
        LoadCommands(CmdVersion)
        ShowCommands()
        CmdsChanged = False
        CheckCommandButtons()
        gbCommands.Visible = False
        AddCommand = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPack.Click
        pnlWork.Visible = True
        Application.DoEvents()
        DeleteDirectory(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")))
        Directory.CreateDirectory(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")))
        PackFiles()
        pnlWork.Visible = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ftp As New FTPClass
        Dim dlg As New Uploading
        Try

            dlg.TopMost = True
            dlg.Show()
            dlg.Label1.Text = "Connecting to Server"
            Application.DoEvents()
            ftp.setRemoteHost(TextBox3.Text)
            ftp.setRemoteUser(TextBox1.Text)
            ftp.setRemotePass(TextBox2.Text)
            ftp.setRemotePath("/public_html/Updates/logs")
            ftp.login()
            Dim dirLogs As String() = Nothing
            Try
                dirLogs = ftp.getFileList("")
            Catch ex As Exception
            End Try

            If Not Directory.Exists(Path.Combine(AppPath, "logs")) Then
                Directory.CreateDirectory(Path.Combine(AppPath, "logs"))
            End If
            dlg.Label1.Text = "Downloading File"
            Application.DoEvents()
            For Each s As String In dirLogs
                If s = "." OrElse s = ".." OrElse s = "" Then Continue For
                Try
                    dlg.Label2.Text = s
                    Application.DoEvents()
                    ftp.download(s, String.Concat("logs", Path.DirectorySeparatorChar, s))
                Catch ex As Exception
                End Try
                'ftp.download("download.log", "download.log")
            Next
            ftp.close()
            dlg.Close()
            UpdateStats()
        Catch ex As Exception
            dlg.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        ' Dim state = New FtpState
        Dim ftp As New FTPClass
        Dim dlg As New Uploading
        ' Dim AppDest As String = "D:\Devel\embermediamanager\updates_jco\"
        ' Dim AppDestFile As String = Path.Combine(AppDest, "Files\")
        Try
            dlg.TopMost = True
            dlg.Show()
            dlg.Label1.Text = "Connecting to Server"
            Application.DoEvents()
            ftp.setRemoteHost(SetupSettings.FTPHost)
            ftp.setRemoteUser(SetupSettings.FTPUser)
            ftp.setRemotePass(SetupSettings.FTPPassword)
            ftp.setRemotePath("emm-r/updates")
            ftp.login()
            Dim dirRoot As String()
            Dim dirFiles As New List(Of String)
            'ftp.IdVerify(SetupSettings.FTPUser, SetupSettings.FTPPassword)
            'ftp.cmdPasv2Port()
            Application.DoEvents()

            'Create Lock File
            File.WriteAllText(Path.Combine(AppPath, "locked.flg"), "Lock")
            ftp.upload(Path.Combine(AppPath, "locked.flg"))
            File.Delete(Path.Combine(AppPath, "locked.flg"))

            'Check for Files Directory / Create if it does not exist.
            ' If Not Directory.Exists(Path.Combine(AppDest, "Files")) Then
            ' Directory.CreateDirectory(Path.Combine(AppDest, "Files"))
            ' End If
            dirRoot = ftp.getFileList("")
            If Not dirRoot.Contains("Files") Then
                ftp.mkdir("Files")
            End If
            ftp.chdir("Files")

            'load files into list 
            dirFiles = ftp.getFileList("").ToList
            dirFiles.Remove(".")
            dirFiles.Remove("..")

            Dim inDisk As Integer = Directory.GetFiles(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files"))).Count
            Dim done As Integer = 0
            Dim skiped As Integer = 0

            For Each s In Directory.GetFiles(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")))
                Try
                    dlg.Label1.Text = String.Format(" File {0} of {1} - Copied {2} , Skiped {3}", done + skiped, inDisk, done, skiped)
                    dlg.Refresh()
                    Application.DoEvents()
                    If Not dirFiles.Contains(Path.GetFileName(s)) Then
                        dirFiles.Remove(Path.GetFileName(s))
                        dlg.Label2.Text = String.Concat("Uploading: ", Path.GetFileName(s))
                        dlg.Refresh()
                        Application.DoEvents()
                        'File.Copy(s, Path.Combine(AppDestFile, Path.GetFileName(s)))
                        ftp.upload(s)
                        ftp.chmod("644", Path.GetFileName(s))
                        done += 1
                    Else
                        dirFiles.Remove(Path.GetFileName(s))
                        skiped += 1
                    End If
                    dlg.Label2.Text = ""
                Catch ex As Exception
                    File.AppendAllText(Path.Combine(AppPath, "errors.log"), ex.Message)
                End Try
            Next
            inDisk = dirFiles.Count
            done = 0
            For Each s As String In dirFiles.Where(Function(i) Not String.IsNullOrEmpty(i))
                done += 1
                dlg.Label1.Text = String.Format(" Removing obsolete files {0} of {1}", done, inDisk)
                dlg.Label2.Text = String.Concat("Deleting: ", Path.GetFileName(s))
                Application.DoEvents()
                'File.Delete(Path.Combine(AppDestFile, s))
                ftp.deleteRemoteFile(s)
            Next
            dlg.Label1.Text = "Uploading Configuration"
            Application.DoEvents()
            ftp.chdir("..")
            For Each s In Directory.GetFiles(Path.Combine(AppPath, "Site"))
                dlg.Label2.Text = Path.GetFileName(s)
                Application.DoEvents()
                ftp.upload(s)
                'If File.Exists(Path.Combine(AppDest, Path.GetFileName(s))) Then
                'File.Delete(Path.Combine(AppDest, Path.GetFileName(s)))
                'End If
                'File.Copy(s, Path.Combine(AppDest, Path.GetFileName(s)))
                ftp.chmod("644", Path.GetFileName(s))
            Next
            ftp.deleteRemoteFile("locked.flg")
            ftp.close()
        Catch ex As Exception
            File.AppendAllText(Path.Combine(AppPath, "errors.log"), ex.Message)
        End Try
        dlg.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SetupSettings.FTPHost = (TextBox3.Text)
        SetupSettings.FTPUser = (TextBox1.Text)
        SetupSettings.FTPPassword = (TextBox2.Text)
        SetupSettings.Save(Path.Combine(AppPath, "settings.xml"))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditNews.Click
        Dim sEditor As String = String.Empty
        If File.Exists(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "WhatsNew.txt"))) Then
            sEditor = File.ReadAllText(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "WhatsNew.txt"))).Replace("\n", vbCrLf)
        End If
        Using editor As New dlgEditor
            editor.TextBox1.Text = sEditor
            If editor.ShowDialog = Windows.Forms.DialogResult.OK Then
                File.WriteAllText(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "WhatsNew.txt")), editor.TextBox1.Text.Replace(vbCrLf, "\n"))
            End If
        End Using
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFrom.Click
        Dim ftp As New FTPClass
        Dim dlg As New Uploading
        Try

            dlg.TopMost = True
            dlg.Show()
            dlg.Label1.Text = "Connecting to Server"
            Application.DoEvents()
            ftp.setRemoteHost(TextBox3.Text)
            ftp.setRemoteUser(TextBox1.Text)
            ftp.setRemotePass(TextBox2.Text)
            ftp.setRemotePath("/public_html/Updates")
            ftp.login()
            dlg.Label1.Text = "Download Files: WhatsNew.txt"
            Application.DoEvents()
            ftp.download("WhatsNew.txt", String.Concat("Site", Path.DirectorySeparatorChar, "WhatsNew.txt"))
            dlg.Label1.Text = "Download Files: versionlist.xml"
            Application.DoEvents()
            ftp.download("versionlist.xml", String.Concat("Site", Path.DirectorySeparatorChar, "versionlist.xml"))
            dlg.Label1.Text = "Download Files: versions.xml"
            Application.DoEvents()
            ftp.download("versions.xml", String.Concat("Site", Path.DirectorySeparatorChar, "versions.xml"))
            ftp.close()
            dlg.Close()
        Catch ex As Exception
            dlg.Close()
        End Try
        LoadAll()
    End Sub

    Private Sub bwPopulate(ByVal SourcePath As String, ByVal recurse As Boolean, ByVal op As OrigPaths)
        Try
            If bwFF.CancellationPending Then
                Return
            End If
            Dim foundPath As String = String.Empty
            Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
            If excludesDirs.Contains(Path.GetFileName(SourceDir.FullName)) Then Return
            If SourceDir.Exists Then
                Dim ChildFile As FileInfo
                Try
                    For Each ChildFile In SourceDir.GetFiles()
                        'Me.bwFF.ReportProgress(1, New Object() {ChildFile.FullName, op})
                        AddToDB(ChildFile.FullName, op)
                    Next
                Catch ex As Exception
                End Try
                If recurse Then
                    Dim SubDir As DirectoryInfo
                    Try
                        For Each SubDir In SourceDir.GetDirectories()
                            bwPopulate(SubDir.FullName, recurse, op)
                            If bwFF.CancellationPending Then
                                Return
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bwPopulate_Complete(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwFF.RunWorkerCompleted
        LoadFiles(CheckBox1.Checked)
        EnableGui()
    End Sub

    Private Sub bwPopulate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwFF.DoWork
        Try
            Dim t As SQLite.SQLiteTransaction
            t = MasterDB.BeginTransaction()
            For Each op As OrigPaths In OPaths
                bwPopulate(op.origpath, op.recursive, op)
            Next
            t.Commit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bwPopulate_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwFF.ProgressChanged
    End Sub

    Private Sub cboStats_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStats.SelectedIndexChanged
        UpdateList(cboStats.SelectedItem.ToString)
    End Sub

    Private Sub cbPlatform_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPlatform.SelectedIndexChanged
        Platform = cbPlatform.Text
        LoadFiles(CheckBox1.Checked)
    End Sub

    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        CmdsChanged = True
        CheckCommandButtons()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        LoadFiles(CheckBox1.Checked)
    End Sub

    Sub CheckCommandButtons()
        If CmdsChanged Then
            btnSave.Enabled = True
            btnRemove.Enabled = True
            CmdsChanged = False
            btnRemove.Text = "Cancel"
        Else
            btnSave.Enabled = False
            btnRemove.Enabled = False
            gbCommands.Visible = False
            btnRemove.Text = "Remove"
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If lstFiles.SelectedItems.Count > 0 Then
            If excludesFiles.Contains(lstFiles.SelectedItems(0).SubItems(1).Text) Then
                AllwaysExcludeFileToolStripMenuItem.Visible = False
                RemoveExclusionToolStripMenuItem.Visible = True
            Else
                AllwaysExcludeFileToolStripMenuItem.Visible = True
                RemoveExclusionToolStripMenuItem.Visible = False
            End If
            If excludesDirs.Contains(Path.GetFileName(lstFiles.SelectedItems(0).SubItems(0).Text)) Then
                AllwaysExcludeFolderToolStripMenuItem.Visible = False
            Else
                AllwaysExcludeFolderToolStripMenuItem.Visible = True
            End If
            If excludesDirs.Count > 0 Then
                RemoveFolderExclusionToolStripMenuItem.DropDownItems.Clear()
                For Each s As String In excludesDirs
                    Dim i As ToolStripMenuItem
                    RemoveFolderExclusionToolStripMenuItem.DropDownItems.Add(s)
                    i = RemoveFolderExclusionToolStripMenuItem
                    AddHandler i.DropDownItemClicked, AddressOf RemoveExcludeDirs
                Next
                RemoveFolderExclusionToolStripMenuItem.Visible = True
            Else
                RemoveFolderExclusionToolStripMenuItem.Visible = False
            End If
            If excludesFilesInFolders.Contains(New FilesInFolders With {.Filename = lstFiles.SelectedItems(0).SubItems(1).Text, .EmberPath = lstFiles.SelectedItems(0).SubItems(2).Text}) Then
                AllwaysExcludeFileinFolderMenuItem.Visible = False
                RemoveExcludeFileinFolderToolStripMenuItem.Visible = True
            Else
                AllwaysExcludeFileinFolderMenuItem.Visible = True
                RemoveExcludeFileinFolderToolStripMenuItem.Visible = False
            End If

        End If
    End Sub

    Sub DisableGui()
        btnOriginPath.Enabled = False
        btnSaveVersion.Enabled = False
        btnRefresh.Enabled = False
        btnRescan.Enabled = False
        cbPlatform.Enabled = False
        pnlWork.Visible = True
        CheckBox1.Enabled = False
        lstFiles.Enabled = False
        ContextMenuStrip1.Enabled = False
        btnPack.Enabled = False
        btnEditNews.Enabled = False
        btnUpload.Enabled = False
        btnUpdateFrom.Enabled = False
    End Sub

    Sub EnableGui()
        pnlWork.Visible = False
        btnOriginPath.Enabled = True
        btnSaveVersion.Enabled = True
        btnRefresh.Enabled = True
        btnRescan.Enabled = True
        cbPlatform.Enabled = True
        CheckBox1.Enabled = True
        lstFiles.Enabled = True
        ContextMenuStrip1.Enabled = True
        btnPack.Enabled = True
        btnEditNews.Enabled = True
        btnUpload.Enabled = True
        btnUpdateFrom.Enabled = True
    End Sub

    Private Sub frmMainManager_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MasterDB.Close()
    End Sub

    Private Sub frmMainManager_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    'Gilles Khouzams colour corrected grayscale shear

    'Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
    '     {New Single() {0.3, 0.3, 0.3, 0, 0}, _
    '    New Single() {0.59, 0.59, 0.59, 0, 0}, _
    '    New Single() {0.11, 0.11, 0.11, 0, 0}, _
    '    New Single() {0, 0, 0, 1, 0}, _
    '    New Single() {0, 0, 0, 0, 1}})


    Private Sub frmMainManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Directory.Exists(Path.Combine(AppPath, "Site")) Then Directory.CreateDirectory(Path.Combine(AppPath, "Site"))
        If Not Directory.Exists(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files"))) Then Directory.CreateDirectory(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")))
        If Not Directory.Exists(Path.Combine(AppPath, "logs")) Then Directory.CreateDirectory(Path.Combine(AppPath, "logs"))

        MasterDB.Connect()
        If File.Exists(Path.Combine(AppPath, "errors.log")) Then
            File.Delete(Path.Combine(AppPath, "errors.log"))
        End If
        LoadAll()
        UpdateStats()       'REMOVE
    End Sub

    Private Function GetHash(ByVal fname As String) As String
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

    Sub LoadAll()
        Try
            LoadSettings()
            LoadOPaths()
            cbPlatform.SelectedIndex = 0
            LoadExcludes()
            EmberVersions.VersionList.Clear()
            If File.Exists(Path.Combine(AppPath, String.Concat("site", Path.DirectorySeparatorChar, "versionlist.xml"))) Then
                Dim xmlSer As New XmlSerializer(GetType(UpgradeList))
                Using xmlSW As New StreamReader(Path.Combine(AppPath, String.Concat("site", Path.DirectorySeparatorChar, "versionlist.xml")))
                    EmberVersions = DirectCast(xmlSer.Deserialize(xmlSW), SetupManager.UpgradeList)
                End Using
                LoadVersions()
            End If
            _cmds.Command = New List(Of InstallCommand)
            GetModulesVersions()
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadCommands(ByVal n As String)
        Dim p As String = Path.Combine(AppPath, "Site")
        Dim f As String = String.Format("commands_{0}.xml", n)
        _cmds.Command.Clear()
        If File.Exists(Path.Combine(p, f)) Then
            Dim xmlSer As XmlSerializer
            xmlSer = New XmlSerializer(GetType(InstallCommands))
            Using xmlSW As New StreamReader(Path.Combine(p, f))
                _cmds = DirectCast(xmlSer.Deserialize(xmlSW), InstallCommands)
            End Using
        End If
        CmdVersion = n
    End Sub

    Sub LoadExcludes()
        excludesFiles.Clear()
        Using SQLcommand As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommand.CommandText = String.Concat("SELECT * FROM ExcludeFiles;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                While SQLreader.Read
                    If Not DBNull.Value.Equals(SQLreader("Filename")) Then excludesFiles.Add(SQLreader("Filename").ToString)
                End While
            End Using
        End Using
        excludesDirs.Clear()
        Using SQLcommand As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommand.CommandText = String.Concat("SELECT * FROM ExcludeDir;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                While SQLreader.Read
                    If Not DBNull.Value.Equals(SQLreader("Dirname")) Then excludesDirs.Add(SQLreader("Dirname").ToString)
                End While
            End Using
        End Using
        excludesFilesInFolders.Clear()
        Using SQLcommand As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommand.CommandText = String.Concat("SELECT * FROM ExcludeFilesInFolders;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                While SQLreader.Read
                    If Not DBNull.Value.Equals(SQLreader("EmberPath")) AndAlso Not DBNull.Value.Equals(SQLreader("FileName")) Then
                        excludesFilesInFolders.Add(New FilesInFolders With {.EmberPath = SQLreader("EmberPath").ToString, .Filename = SQLreader("Filename").ToString})
                    End If
                End While
            End Using
        End Using
    End Sub

    Dim AllFilesCount As Integer
    Sub LoadFiles(Optional ByVal showAll As Boolean = True)
        lstFiles.Items.Clear()
        txtEMMVersion.Text = ""
        AllFilesCount = 0
        RemoveHandler lstFiles.ItemCheck, AddressOf lstFiles_ItemCheck
        Using SQLcommand As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommand.CommandText = String.Concat("SELECT OrigPath,EmberPath,Filename,Hash,UseFile,Platform FROM EmberFiles ORDER BY EmberPath,Filename  ;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                Dim o As EmberFiles
                While SQLreader.Read
                    o = New EmberFiles
                    o.FTI = New FileToInstall
                    If Not DBNull.Value.Equals(SQLreader("OrigPath")) Then o.FTI.OriginalPath = SQLreader("OrigPath").ToString
                    If Not DBNull.Value.Equals(SQLreader("EmberPath")) Then o.FTI.EmberPath = SQLreader("EmberPath").ToString
                    If Not DBNull.Value.Equals(SQLreader("Filename")) Then o.FTI.Filename = SQLreader("Filename").ToString
                    If Not DBNull.Value.Equals(SQLreader("Hash")) Then o.FTI.Hash = SQLreader("Hash").ToString
                    If Not DBNull.Value.Equals(SQLreader("Platform")) Then o.FTI.Platform = SQLreader("Platform").ToString
                    If Not DBNull.Value.Equals(SQLreader("UseFile")) Then o.UseFile = Convert.ToBoolean(SQLreader("UseFile"))
                    'If (showAll OrElse o.UseFile) AndAlso (Platform = o.FTI.Platform OrElse o.FTI.Platform = "Common") Then
                    If (showAll OrElse o.UseFile) AndAlso (Platform = o.FTI.Platform) Then
                        Dim i = New ListViewItem
                        i.Text = o.FTI.OriginalPath
                        i.SubItems.Add(o.FTI.Filename)
                        i.SubItems.Add(o.FTI.EmberPath)
                        i.SubItems.Add(o.FTI.Platform)
                        i.Checked = o.UseFile
                        If o.UseFile Then AllFilesCount += 1
                        lstFiles.Items.Add(i)
                        If o.FTI.EmberPath = "" AndAlso o.FTI.Filename = "Ember Media Manager.exe" Then
                            If File.Exists(Path.Combine(o.FTI.OriginalPath, "Ember Media Manager.exe")) Then
                                CurrentEmberVersion = GetEmberVersion(o.FTI.OriginalPath)
                                CurrentEmberPlatform = GetEmberPlatform(o.FTI.OriginalPath)
                                txtEMMVersion.Text = CurrentEmberVersion
                                CurrentEmberPath = o.FTI.OriginalPath
                            End If

                        End If
                    End If
                End While
            End Using
        End Using
        AddHandler lstFiles.ItemCheck, AddressOf lstFiles_ItemCheck
        Label14.Text = AllFilesCount.ToString
    End Sub

    Sub LoadSettings()
        If File.Exists(Path.Combine(AppPath, "settings.xml")) Then
            Dim xmlSer As New XmlSerializer(GetType(Settings))
            Using xmlSW As New StreamReader(Path.Combine(AppPath, "settings.xml"))
                SetupSettings = DirectCast(xmlSer.Deserialize(xmlSW), SetupManager.Settings)
            End Using
        End If
    End Sub

    Sub LoadVersions()
        lstVersions.Items.Clear()
        Me.lstVersions.ListViewItemSorter = New ListViewItemComparer(0)
        For Each v As Versions In EmberVersions.VersionList
            If IsNumeric(v.Version) Then lstVersions.Items.Add(v.Version)
        Next
    End Sub

    Private Sub lstCommands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCommands.SelectedIndexChanged
        If lstCommands.SelectedItems.Count > 0 AndAlso Not AddCommand Then
            txtCommand.Text = lstCommands.SelectedItems(0).Tag.ToString
            cbType.SelectedIndex = cbType.FindString(lstCommands.SelectedItems(0).Text)
            txtDescriptions.Text = lstCommands.SelectedItems(0).SubItems(1).Text
            CmdsChanged = False
            CheckCommandButtons()
            gbCommands.Visible = True
            btnRemove.Enabled = True
        End If
    End Sub

    Private Sub lstFiles_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstFiles.ItemCheck
        Dim o As New EmberFiles
        o = MasterDB.DBGetEmberFile(lstFiles.Items(e.Index).Text, lstFiles.Items(e.Index).SubItems(1).Text)
        o.UseFile = Convert.ToBoolean(e.NewValue)
        MasterDB.DBAddChangeEmberFile(o)
    End Sub

    Private Sub lstVersions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVersions.SelectedIndexChanged
        If lstVersions.SelectedItems.Count > 0 Then
            If Not InCommandTab Then
                lstVersions.SelectedItems(0).Selected = False
            Else
                LoadCommands(lstVersions.SelectedItems(0).Text)
                ShowCommands()
                CmdsChanged = False
                CheckCommandButtons()
                gbCommands.Visible = False
                btnNew.Enabled = True
            End If
        End If
    End Sub

    Sub PackFiles()
        Dim terror As Boolean = False
        Dim o As New FileOfList
        Using SQLcommandEmberFiles As SQLite.SQLiteCommand = MasterDB.SQLcn.CreateCommand
            SQLcommandEmberFiles.CommandText = String.Concat("Select * FROM EmberFiles;")
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommandEmberFiles.ExecuteReader()
                While SQLreader.Read
                    If Convert.ToBoolean(SQLreader("UseFile")) Then
                        Dim srcFile As String = Path.Combine(SQLreader("OrigPath").ToString, SQLreader("Filename").ToString)
                        'Dim dstFile As String = Path.Combine(Path.Combine(AppPath, "Site\Files"), SQLreader("Filename").ToString) ' & ".gz")
                        Dim dstFile As String = Path.Combine(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")), String.Concat(SQLreader("Hash").ToString, ".emm"))
                        Try
                            If File.Exists(dstFile) Then File.Delete(dstFile)
                            File.Copy(srcFile, dstFile)
                        Catch ex As Exception
                            terror = True
                            File.AppendAllText(Path.Combine(AppPath, "errors.log"), ex.Message)
                        End Try
                        'CompressFile(srcFile, dstFile)
                    End If
                End While
            End Using
        End Using
        If terror Then MsgBox("Some Errors Found ... look in errors.log", MsgBoxStyle.Critical, AcceptButton)
    End Sub

    Sub RemoveExcludeDirs(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
        MasterDB.DBDeleteExcludeDir(e.ClickedItem.Text)
        LoadExcludes()
        MasterDB.DBDeleteAllEmberFile()
        DoPopulateFiles()
    End Sub

    Private Sub RemoveExclusionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveExclusionToolStripMenuItem.Click
        MasterDB.DBDeleteExcludeFile(lstFiles.SelectedItems(0).SubItems(1).Text)
        LoadExcludes()
    End Sub

    Sub SaveCommands(Optional ByVal savetolist As Boolean = True)
        If savetolist Then
            lstCommands.SelectedItems(0).Text = cbType.SelectedItem.ToString
            lstCommands.SelectedItems(0).SubItems(1).Text = txtDescriptions.Text
            lstCommands.SelectedItems(0).Tag = txtCommand.Text
        End If
        Dim p As String = Path.Combine(AppPath, "Site")
        Dim f As String = String.Format("commands_{0}.xml", CmdVersion)
        _cmds.Command.Clear()
        For Each s As ListViewItem In lstCommands.Items
            _cmds.Command.Add(New InstallCommand With {.CommandType = s.Text, .CommandDescription = s.SubItems(1).Text, .CommandExecute = s.Tag.ToString})
        Next
        _cmds.Save(Path.Combine(p, f))
    End Sub

    Sub ShowCommands()
        If Not CmdVersion = String.Empty Then
            Label8.Text = String.Format("Commands for Version: {0}", CmdVersion)
            lstCommands.Items.Clear()
            Dim i As ListViewItem
            For Each t As InstallCommand In _cmds.Command
                i = New ListViewItem
                i = lstCommands.Items.Add(t.CommandType)
                i.SubItems.Add(t.CommandExecute)
                i.Tag = t.CommandExecute
            Next
        End If
    End Sub

    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        InCommandTab = False
        CmdVersion = String.Empty
        lstCommands.Items.Clear()
        CmdsChanged = False
        CheckCommandButtons()
        btnNew.Enabled = False
        If lstVersions.SelectedItems.Count > 0 Then
            lstVersions.SelectedItems(0).Selected = False
        End If
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        InCommandTab = True
        ShowCommands()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescriptions.TextChanged
        CmdsChanged = True
        CheckCommandButtons()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllwaysExcludeFileinFolderMenuItem.Click
        If lstFiles.SelectedItems.Count > 0 Then
            Dim ee As New EmberFiles
            ee = MasterDB.DBGetEmberFile(lstFiles.SelectedItems(0).Text, lstFiles.SelectedItems(0).SubItems(1).Text)
            ee.UseFile = False
            MasterDB.DBAddChangeEmberFile(ee)
            MasterDB.DBAddChangeExcludeFileInFolder(ee.FTI.Filename, ee.FTI.EmberPath)
            LoadExcludes()
            LoadFiles(CheckBox1.Checked)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveExcludeFileinFolderToolStripMenuItem.Click
        MasterDB.DBDeleteExcludeFileInFolder(lstFiles.SelectedItems(0).SubItems(1).Text, lstFiles.SelectedItems(0).SubItems(2).Text)
        LoadExcludes()
    End Sub

    Private Sub txtCommand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommand.TextChanged
        CmdsChanged = True
        CheckCommandButtons()
    End Sub

    Private Sub txtEMMVersion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEMMVersion.TextChanged
        If Not txtEMMVersion.Text = String.Empty Then
            btnSaveVersion.Enabled = True
        Else
            btnSaveVersion.Enabled = False
        End If
    End Sub

    Sub UpdateList(ByVal filen As String)
        lstStats.Items.Clear()
        Dim filename As String = Path.Combine(AppPath, String.Concat("logs", Path.DirectorySeparatorChar, "download-", filen, ".log"))
        If File.Exists(filename) Then
            Dim t As String() = File.ReadAllLines(filename)
            For Each s As String In t
                Dim i As String() = s.Split(Convert.ToChar(vbTab))
                Dim n As String = i(0).Replace("(x86) ", "").Replace("(x64) ", "")
                Dim li As ListViewItem
                li = lstStats.Items(n)
                If li Is Nothing Then
                    li = lstStats.Items.Add(n)
                    li.Name = n
                    li.SubItems.Add("0")
                    li.SubItems.Add("0")
                    li.SubItems.Add("0")
                End If
                li.SubItems(1).Text = (If(i(0).Contains("(x86)"), i(1), li.SubItems(1).Text))
                li.SubItems(2).Text = (If(i(0).Contains("(x64)"), i(1), li.SubItems(2).Text))
                li.SubItems(3).Text = (Convert.ToInt32(li.SubItems(1).Text) + Convert.ToInt32(li.SubItems(2).Text)).ToString
            Next
        End If
    End Sub

    Sub UpdateStats()
        cboStats.Items.Clear()
        'lstStats.Items.Clear()
        Dim found As Boolean = False
        Dim f As FileInfo() = New DirectoryInfo(Path.Combine(AppPath, "logs")).GetFiles("*.log")
        For Each fi As FileInfo In f
            cboStats.Items.Add(Path.GetFileNameWithoutExtension(fi.Name).Replace("download-", ""))
            found = True
        Next
        If found Then
            cboStats.Enabled = True
            cboStats.SelectedIndex = 0
        End If
        'Dim t As String() = File.ReadAllLines(Path.Combine(AppPath, "download.log"))
        'For Each s As String In t
        'Dim i As String() = s.Split(Convert.ToChar(vbTab))
        'lstStats.Items.Add(i(0)).SubItems.Add(i(1))
        ' Next
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure FilesInFolders

#Region "Fields"

        Dim EmberPath As String
        Dim Filename As String

#End Region 'Fields

    End Structure

    Class DB

#Region "Fields"

        Public SQLcn As New SQLite.SQLiteConnection()

#End Region 'Fields

#Region "Methods"

        Public Function BeginTransaction() As SQLite.SQLiteTransaction
            Return SQLcn.BeginTransaction
        End Function

        Public Sub Close()
            SQLcn.Close()
        End Sub

        Public Sub Connect()
            Try
                SQLcn.ConnectionString = String.Format("Data Source=""{0}"";Compress=True", Path.Combine(AppPath, "SetupManager.emm"))
                SQLcn.Open()
                Using SQLtransaction As SQLite.SQLiteTransaction = SQLcn.BeginTransaction
                    Using SQLcommand As SQLite.SQLiteCommand = SQLcn.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS OrigPaths(" & _
                            "OrigPath TEXT NOT NULL, " & _
                            "EmberPath TEXT NOT NULL, " & _
                            "Platform TEXT NOT NULL, " & _
                            "Recursive BOOL NOT NULL DEFAULT False, " & _
                            "PRIMARY KEY (OrigPath,Platform) " & _
                             ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    Using SQLcommand As SQLite.SQLiteCommand = SQLcn.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS EmberFiles(" & _
                            "OrigPath TEXT NOT NULL, " & _
                            "EmberPath TEXT NOT NULL, " & _
                            "Filename TEXT NOT NULL, " & _
                            "Hash TEXT NOT NULL, " & _
                            "Platform TEXT NOT NULL, " & _
                            "UseFile BOOL NOT NULL DEFAULT False, " & _
                            "PRIMARY KEY (OrigPath,Filename ) " & _
                             ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    Using SQLcommand As SQLite.SQLiteCommand = SQLcn.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS ExcludeFiles(" & _
                            "Filename TEXT NOT NULL, " & _
                            "PRIMARY KEY (Filename) " & _
                             ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    Using SQLcommand As SQLite.SQLiteCommand = SQLcn.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS ExcludeDir(" & _
                            "Dirname TEXT NOT NULL, " & _
                            "PRIMARY KEY (Dirname) " & _
                             ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    Using SQLcommand As SQLite.SQLiteCommand = SQLcn.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS ExcludeFilesInFolders(" & _
                            "Filename TEXT NOT NULL, " & _
                            "EmberPath TEXT NOT NULL, " & _
                            "PRIMARY KEY (Filename,EmberPath) " & _
                             ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    SQLtransaction.Commit()
                End Using
            Catch ex As Exception
            End Try
        End Sub

        Public Function CreateCommand() As SQLite.SQLiteCommand
            Return SQLcn.CreateCommand
        End Function

        Public Sub DBAddChangeEmberFile(ByVal p As EmberFiles)
            Using SQLcommandOrigPaths As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandOrigPaths.CommandText = String.Concat("INSERT OR REPLACE INTO EmberFiles (OrigPath,EmberPath,Filename,Hash,UseFile,Platform) VALUES (?,?,?,?,?,?);")
                Dim parorigpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parorigpath", DbType.String, 0, "OrigPath")
                Dim paremberpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("paremberpath", DbType.String, 0, "EmberPath")
                Dim parfilename As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parfilename", DbType.String, 0, "Filename")
                Dim parhash As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parhash", DbType.String, 0, "Hash")
                Dim parUseFile As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parUseFile", DbType.Boolean, 0, "UseFile")
                Dim parPlatform As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parPlatform", DbType.String, 0, "Platform")
                parfilename.Value = p.FTI.Filename
                parorigpath.Value = p.FTI.OriginalPath
                paremberpath.Value = p.FTI.EmberPath
                parhash.Value = p.FTI.Hash
                parPlatform.Value = p.FTI.Platform
                parUseFile.Value = p.UseFile
                SQLcommandOrigPaths.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBAddChangeExcludeDir(ByVal p As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("INSERT OR REPLACE INTO ExcludeDir (Dirname) VALUES (?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Dirname")
                parFilename.Value = p
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBAddChangeExcludeFile(ByVal p As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("INSERT OR REPLACE INTO ExcludeFiles (Filename) VALUES (?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Filename")
                parFilename.Value = p
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBAddChangeExcludeFileInFolder(ByVal p As String, ByVal f As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("INSERT OR REPLACE INTO ExcludeFilesInFolders (Filename,EmberPath) VALUES (?,?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Filename")
                Dim parEmberPath As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parEmberPath", DbType.String, 0, "EmberPath")
                parFilename.Value = p
                parEmberPath.Value = f
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBAddChangeOirgPaths(ByVal p As OrigPaths)
            Using SQLcommandOrigPaths As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandOrigPaths.CommandText = String.Concat("INSERT OR REPLACE INTO OrigPaths (OrigPath,EmberPath,Recursive,Platform) VALUES (?,?,?,?);")
                Dim parorigpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parorigpath", DbType.String, 0, "OrigPath")
                Dim paremberpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("paremberpath", DbType.String, 0, "EmberPath")
                Dim parrecursive As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parrecursive", DbType.Boolean, 0, "Recursive")
                Dim parPlatform As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parPlatform", DbType.String, 0, "Platform")
                parrecursive.Value = p.recursive
                parorigpath.Value = p.origpath
                paremberpath.Value = p.emberpath
                parPlatform.Value = p.platform
                SQLcommandOrigPaths.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteAllEmberFile()
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("DELETE FROM EmberFiles;")
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteEmberFile(ByVal s As String, ByVal s1 As String)
            Using SQLcommandOrigPaths As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandOrigPaths.CommandText = String.Concat("DELETE FROM EmberFiles Where OrigPath=(?) AND Filename=(?);")
                Dim parorigpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parorigpath", DbType.String, 0, "OrigPath")
                Dim parfilename As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parfilename", DbType.String, 0, "Filename")
                parorigpath.Value = s
                parfilename.Value = s1
                SQLcommandOrigPaths.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteExcludeDir(ByVal s As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("DELETE FROM ExcludeDir Where Dirname=(?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Dirname")
                parFilename.Value = s
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteExcludeFile(ByVal s As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("DELETE FROM ExcludeFiles Where Filename=(?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Filename")
                parFilename.Value = s
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteExcludeFileInFolder(ByVal s As String, ByVal f As String)
            Using SQLcommandFilename As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandFilename.CommandText = String.Concat("DELETE FROM ExcludeFilesInFolders Where Filename=(?) And EmberPath=(?);")
                Dim parFilename As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parFilename", DbType.String, 0, "Filename")
                Dim parEmberPath As SQLite.SQLiteParameter = SQLcommandFilename.Parameters.Add("parEmberPath", DbType.String, 0, "EmberPath")
                parFilename.Value = s
                parEmberPath.Value = f
                SQLcommandFilename.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DBDeleteOirgPaths(ByVal s As String, ByVal s1 As String)
            Using SQLcommandOrigPaths As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandOrigPaths.CommandText = String.Concat("DELETE FROM OrigPaths Where OrigPath=(?) AND Platform=(?);")
                Dim parorigpath As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parorigpath", DbType.String, 0, "OrigPath")
                Dim parPlatform As SQLite.SQLiteParameter = SQLcommandOrigPaths.Parameters.Add("parPlatform", DbType.String, 0, "Platform")
                parorigpath.Value = s
                parPlatform.Value = s1
                SQLcommandOrigPaths.ExecuteNonQuery()
            End Using
        End Sub

        Public Function DBGetEmberFile(ByVal s As String, ByVal s1 As String) As EmberFiles
            Dim o As New EmberFiles
            Using SQLcommandEmberFiles As SQLite.SQLiteCommand = SQLcn.CreateCommand
                SQLcommandEmberFiles.CommandText = String.Concat("Select * FROM EmberFiles Where OrigPath=(?) AND Filename=(?);")
                Dim parorigpath As SQLite.SQLiteParameter = SQLcommandEmberFiles.Parameters.Add("parorigpath", DbType.String, 0, "OrigPath")
                Dim parfilename As SQLite.SQLiteParameter = SQLcommandEmberFiles.Parameters.Add("parfilename", DbType.String, 0, "Filename")
                parorigpath.Value = s
                parfilename.Value = s1
                Using SQLreader As SQLite.SQLiteDataReader = SQLcommandEmberFiles.ExecuteReader()
                    While SQLreader.Read
                        o = New EmberFiles
                        o.FTI = New FileToInstall
                        If Not DBNull.Value.Equals(SQLreader("OrigPath")) Then o.FTI.OriginalPath = SQLreader("OrigPath").ToString
                        If Not DBNull.Value.Equals(SQLreader("EmberPath")) Then o.FTI.EmberPath = SQLreader("EmberPath").ToString
                        If Not DBNull.Value.Equals(SQLreader("Filename")) Then o.FTI.Filename = SQLreader("Filename").ToString
                        If Not DBNull.Value.Equals(SQLreader("Hash")) Then o.FTI.Hash = SQLreader("Hash").ToString
                        If Not DBNull.Value.Equals(SQLreader("Platform")) Then o.FTI.Platform = SQLreader("Platform").ToString
                        If Not DBNull.Value.Equals(SQLreader("UseFile")) Then o.UseFile = Convert.ToBoolean(SQLreader("UseFile"))
                        Exit While
                    End While
                End Using
            End Using
            Return o
        End Function

#End Region 'Methods

    End Class

    Class EmberFiles

#Region "Fields"

        Public FTI As FileToInstall
        Public UseFile As Boolean

#End Region 'Fields

    End Class

    Class ListViewItemComparer
        Implements IComparer

#Region "Fields"

        ' Implements the manual sorting of items by columns.
        Private col As Integer

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Return -1 * Convert.ToInt32(CType(x, ListViewItem).SubItems(col).Text).CompareTo(Convert.ToInt32(CType(y, ListViewItem).SubItems(col).Text))
            'Return Convert.ToInt32(x.text).CompareTo(Convert.ToInt32(y))
        End Function

#End Region 'Methods

    End Class

    Class OrigPaths

#Region "Fields"

        Public emberpath As String
        Public origpath As String
        Public platform As String
        Public recursive As Boolean

#End Region 'Fields

    End Class

#End Region 'Nested Types

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Dim state = New FtpState
        Dim ftp As New FTPClass
        Dim dlg As New Uploading
        Try
            dlg.TopMost = True
            dlg.Show()
            dlg.Label1.Text = "Connecting to Server"
            Application.DoEvents()
            ftp.setRemoteHost(SetupSettings.FTPHost)
            ftp.setRemoteUser(SetupSettings.FTPUser)
            ftp.setRemotePass(SetupSettings.FTPPassword)
            ftp.setRemotePath("/public_html/UpdatesBeta")
            ftp.login()
            Dim dirRoot As String()
            Dim dirFiles As List(Of String)
            'ftp.IdVerify(TextBox1.Text, TextBox2.Text)
            'ftp.cmdPasv2Port()
            Application.DoEvents()
            File.WriteAllText(Path.Combine(AppPath, "locked.flg"), "Lock")
            ftp.upload(Path.Combine(AppPath, "locked.flg"))
            File.Delete(Path.Combine(AppPath, "locked.flg"))
            dirRoot = ftp.getFileList("")
            If Not dirRoot.Contains("Files") Then
                ftp.mkdir("Files")
            End If
            ftp.chdir("Files")
            dirFiles = ftp.getFileList("").ToList
            dirFiles.Remove(".")
            dirFiles.Remove("..")
            Dim inDisk As Integer = Directory.GetFiles(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files"))).Count
            Dim done As Integer = 0
            Dim skiped As Integer = 0

            For Each s In Directory.GetFiles(Path.Combine(AppPath, String.Concat("Site", Path.DirectorySeparatorChar, "Files")))
                Try
                    dlg.Label1.Text = String.Format(" File {0} of {1} - Uploaded {2} , Skiped {3}", done + skiped, inDisk, done, skiped)
                    dlg.Refresh()
                    Application.DoEvents()
                    If Not dirFiles.Contains(Path.GetFileName(s)) Then
                        dirFiles.Remove(Path.GetFileName(s))
                        dlg.Label2.Text = String.Concat("Uploading: ", Path.GetFileName(s))
                        dlg.Refresh()
                        Application.DoEvents()
                        ftp.upload(s)
                        ftp.chmod("644", Path.GetFileName(s))
                        done += 1
                    Else
                        dirFiles.Remove(Path.GetFileName(s))
                        skiped += 1
                    End If
                    dlg.Label2.Text = ""
                Catch ex As Exception
                    File.AppendAllText(Path.Combine(AppPath, "errors.log"), ex.Message)
                End Try
            Next
            inDisk = dirFiles.Count
            done = 0
            For Each s As String In dirFiles.Where(Function(i) Not String.IsNullOrEmpty(i))
                done += 1
                dlg.Label1.Text = String.Format(" Removing obsolete files {0} of {1}", done, inDisk)
                Application.DoEvents()
                ftp.deleteRemoteFile(s)
            Next
            dlg.Label1.Text = "Uploading Configuration"
            Application.DoEvents()
            ftp.chdir("..")
            For Each s In Directory.GetFiles(Path.Combine(AppPath, "Site"))
                dlg.Label2.Text = Path.GetFileName(s)
                Application.DoEvents()
                ftp.upload(s)
                ftp.chmod("644", Path.GetFileName(s))
            Next
            ftp.deleteRemoteFile("locked.flg")
            ftp.close()
        Catch ex As Exception
            File.AppendAllText(Path.Combine(AppPath, "errors.log"), ex.Message)
        End Try
        dlg.Close()

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim fd As New OpenFileDialog
        MsgBox("Please choose a diff File", MsgBoxStyle.Critical, AcceptButton)
        If fd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If File.Exists(fd.FileName) Then
                txtCommand.Text = File.ReadAllText(fd.FileName)
            End If
        End If
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ftp As New FTPClass
        Dim dlg As New Uploading
        Try

            dlg.TopMost = True
            dlg.Show()
            dlg.Label1.Text = "Connecting to Server"
            Application.DoEvents()
            ftp.setRemoteHost(SetupSettings.FTPHost)
            ftp.setRemoteUser(SetupSettings.FTPUser)
            ftp.setRemotePass(SetupSettings.FTPPassword)
            ftp.setRemotePath("/public_html/UpdatesBeta")
            ftp.login()
            dlg.Label1.Text = "Download Files: WhatsNew.txt"
            Application.DoEvents()
            ftp.download("WhatsNew.txt", String.Concat("Site", Path.DirectorySeparatorChar, "WhatsNew.txt"))
            dlg.Label1.Text = "Download Files: versionlist.xml"
            Application.DoEvents()
            ftp.download("versionlist.xml", String.Concat("Site", Path.DirectorySeparatorChar, "versionlist.xml"))
            dlg.Label1.Text = "Download Files: versions.xml"
            Application.DoEvents()
            ftp.download("versions.xml", String.Concat("Site", Path.DirectorySeparatorChar, "versions.xml"))
            ftp.close()
            dlg.Close()
        Catch ex As Exception
            dlg.Close()
        End Try
        LoadAll()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim f As FileInfo() = New DirectoryInfo(Path.Combine(AppPath, "logs")).GetFiles("*.log")
        Dim report As String = String.Empty
        For Each fi As FileInfo In f
            Dim rdate As String = Path.GetFileNameWithoutExtension(fi.Name).Replace("download-", "")
            Dim lines() As String = Array.FindAll(File.ReadAllLines(fi.FullName), AddressOf FindEmber)
            Dim c As Integer = 0
            Dim x86 As Integer = 0
            Dim x64 As Integer = 0
            For Each s As String In lines
                Dim parts As String() = s.Split(Convert.ToChar(vbTab))
                If parts(0).Contains("Ember Media Manager") Then
                    If parts(0).Contains("x86") Then
                        x86 += Convert.ToUInt16(parts(1))
                    Else
                        x64 += Convert.ToUInt16(parts(1))
                    End If
                End If
                'If parts.Length >= 2 Then c += Convert.ToUInt16(parts(1))
            Next

            report = String.Concat(report, String.Format("INSERT INTO `EmberDownloads` (`DownloadDate`, `Version`,`x86`,`x64`,`Mono`) VALUES ( '{0}','?' , '{1}','{2}' ,'0');", rdate, x86.ToString, x64.ToString), vbCrLf)
            'report = String.Concat(report, "Date: ", rdate, "    = ", c.ToString, vbCrLf)
        Next
        txtReport.Text = report
    End Sub
    Private Shared Function FindEmber(ByVal l As String) As Boolean
        Return l.Contains("Ember Media Manager.exe")
    End Function

    Private Sub cmdExFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExFiles.Click
        Using exFiles As New dlgExcludedFiles
            exFiles.ShowDialog()
        End Using
    End Sub
End Class