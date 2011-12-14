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
Imports EmberAPI

Public Class AddonItem
    Friend WithEvents bwDownload As New System.ComponentModel.BackgroundWorker

    Public Event NeedsRefresh()
    Public Event SendEdit(ByVal tAddon As Containers.Addon)
    Public Event IsDownloading(ByVal Bool As Boolean)
    Public Event NeedsRestart()

    Private _enabled As Boolean = True

    Private _id As Integer
    Private _addonname As String
    Private _author As String
    Private _summary As String
    Private _category As String
    Private _screenshot As Image
    Private _version As Single
    Private _mineversion As Single
    Private _maxeversion As Single
    Private _filelist As Generic.SortedList(Of String, String)
    Private _owned As Boolean
    Private _installed As Single

    Private _downloads As Integer = -1

    Public Property ID() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
        End Set
    End Property

    Public Property AddonName() As String
        Get
            Return Me._addonname
        End Get
        Set(ByVal value As String)
            Me._addonname = value
            Me.lblName.Text = value
        End Set
    End Property

    Public Property Author() As String
        Get
            Return Me._author
        End Get
        Set(ByVal value As String)
            Me._author = value
            Me.lblAuthor.Text = value
        End Set
    End Property

    Public Property Summary() As String
        Get
            Return Me._summary
        End Get
        Set(ByVal value As String)
            Me._summary = value
            Me.lblSummary.Text = value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return Me._category
        End Get
        Set(ByVal value As String)
            Me._category = value
        End Set
    End Property

    Public Property ScreenShot() As Image
        Get
            Return Me._screenshot
        End Get
        Set(ByVal value As Image)
            Me._screenshot = value
            Me.pbScreenShot.Image = value
        End Set
    End Property

    Public Property Version() As Single
        Get
            Return Me._version
        End Get
        Set(ByVal value As Single)
            Me._version = value
            Me.lblVersionNumber.Text = value.ToString
        End Set
    End Property

    Public Property Downloads() As Integer
        Get
            Return Me._downloads
        End Get
        Set(ByVal value As Integer)
            Me._downloads = value
        End Set
    End Property

    Public Property MinEVersion() As Single
        Get
            Return Me._mineversion
        End Get
        Set(ByVal value As Single)
            Me._mineversion = value
        End Set
    End Property

    Public Property MaxEVersion() As Single
        Get
            Return Me._maxeversion
        End Get
        Set(ByVal value As Single)
            Me._maxeversion = value
        End Set
    End Property

    Public Property FileList() As Generic.SortedList(Of String, String)
        Get
            Return Me._filelist
        End Get
        Set(ByVal value As Generic.SortedList(Of String, String))
            Me._filelist = value
        End Set
    End Property

    Public Property Owned() As Boolean
        Get
            Return Me._owned
        End Get
        Set(ByVal value As Boolean)
            Me._owned = value
            If value Then
                Me.btnDelete.Visible = True
                Me.btnEdit.Visible = True
            End If
        End Set
    End Property

    Public Property Installed() As Single
        Get
            Return Me._installed
        End Get
        Set(ByVal value As Single)
            Me._installed = value
            If value > 0 Then
                Me.lblInstalledNumber.Text = value.ToString
                Me.lblInstalledNumber.Visible = True
                Me.lblInstalled.Visible = True
                Me.btnUninstall.Visible = True
            Else
                Me.lblInstalledNumber.Visible = False
                Me.lblInstalled.Visible = False
                Me.btnUninstall.Visible = False
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Me.Clear()
        Me.SetUp()
    End Sub

    Public Sub Clear()
        Me._id = -1
        Me._addonname = String.Empty
        Me._author = String.Empty
        Me._summary = String.Empty
        Me._category = String.Empty
        Me._version = -1
        Me._mineversion = -1
        Me._maxeversion = -1
        Me._screenshot = Nothing
        Me._owned = False
        Me._installed = 0
        Me._filelist = New Generic.SortedList(Of String, String)
    End Sub

    Private Sub SetUp()
        Me.lblVersion.Text = Master.eLang.GetString(262, "Version:")
        Me.lblInstalled.Text = Master.eLang.GetString(263, "Installed:")
        Me.lblDownloads.Text = Master.eLang.GetString(825, "Downloads:")
        Me.lblStatus.Text = Master.eLang.GetString(447, "Downloading Files...")
    End Sub

    Private Sub ViewFileListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewFileListToolStripMenuItem.Click
        Using dFileList As New dlgAddonFiles
            dFileList.ShowDialog(Me._filelist)
        End Using
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        RaiseEvent IsDownloading(True)

        Me.ControlsEnabled(False)

        Me.pbStatus.Maximum = Me._filelist.Count
        Me.pbStatus.Value = 0
        Me.pnlStatus.Visible = True

        Me.bwDownload = New System.ComponentModel.BackgroundWorker
        Me.bwDownload.WorkerReportsProgress = True
        Me.bwDownload.RunWorkerAsync()
    End Sub

    Private Sub bwDownload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDownload.DoWork
        Try
            Dim _needRestart As Boolean = False
            If Me.Installed > 0 Then Master.DB.UninstallAddon(Me._id)

            Dim sHTTP As New HTTP
            Dim finalFile As String = String.Empty

            Dim _cmds As Containers.InstallCommands = Containers.InstallCommands.Load(Path.Combine(Functions.AppPath, "InstallTasks.xml"))
            If Not Directory.Exists(Path.Combine(Functions.AppPath, String.Concat("Temp", Path.DirectorySeparatorChar, "addons"))) Then
                Directory.CreateDirectory(Path.Combine(Functions.AppPath, String.Concat("Temp", Path.DirectorySeparatorChar, "addons")))
            End If
            Try
                Dim scHTTP As New HTTP
                '  FIX
                Dim result As String = scHTTP.DownloadData(String.Format("http://www.embermm.com/addons/addons.php?DownloadCount={0}&Version={1}", Me._id, Me._version))
                scHTTP = Nothing
            Catch ex As Exception
            End Try
            For Each _file As KeyValuePair(Of String, String) In Me._filelist
                Dim tempFile As String = Path.Combine(Functions.AppPath, Path.Combine(String.Concat("Temp", Path.DirectorySeparatorChar, "addons"), String.Concat(Functions.ConvertToUnixTimestamp(Now).ToString, Now.Ticks.ToString)))
                Try
                    finalFile = Path.Combine(Functions.AppPath, _file.Key.Replace("/", Path.DirectorySeparatorChar))
                    '  FIX
                    sHTTP.DownloadFile(String.Format("http://www.embermm.com/addons/addons.php?getfile={0}&id={1}", Web.HttpUtility.UrlEncode(_file.Key), Me._id), tempFile, False, "other")
                    Me.bwDownload.ReportProgress(1)
                    Try
                        If Not Directory.Exists(Path.GetDirectoryName(finalFile)) Then
                            Directory.CreateDirectory(Path.GetDirectoryName(finalFile))
                        End If
                        File.Move(tempFile, finalFile)
                    Catch
                        _cmds.Command.Add(New Containers.InstallCommand With {.CommandType = "FILE.Move", .CommandExecute = String.Concat(tempFile, "|", finalFile)})
                        _needRestart = True
                    End Try
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                End Try
            Next
            ' Almost all addons will need restat for one reason ot another
            ' Until we find a way to control it better better allways ask fro restart
            _needRestart = True

            If _needRestart Then
                _cmds.Save(Path.Combine(Functions.AppPath, "InstallTasks.xml"))
                RaiseEvent NeedsRestart()
            End If

            sHTTP = Nothing

            Master.DB.SaveAddonToDB(New Containers.Addon With {.ID = Me._id, .Version = Me._version, .Files = Me._filelist})
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwDownload_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDownload.ProgressChanged
        Me.pbStatus.Value += 1
    End Sub

    Private Sub bwDownload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownload.RunWorkerCompleted
        Me.pnlStatus.Visible = False
        Me.ControlsEnabled(True)
        Me.Installed = Me._version
        RaiseEvent IsDownloading(False)
    End Sub

    Private Sub ControlsEnabled(ByVal isEnabled As Boolean)
        Me._enabled = isEnabled
        Me.btnDelete.Enabled = isEnabled
        Me.btnDownload.Enabled = isEnabled
        Me.btnEdit.Enabled = isEnabled
    End Sub

    Private Sub AddonItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then Me.ContextMenuStrip = If(Not Me._enabled, Nothing, Me.cMenu)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Using dDelAddon As New dlgDeleteAddon
            If dDelAddon.ShowDialog(Me._id) = DialogResult.OK Then
                ' Almost all addons will need restat for one reason ot another
                ' Until we find a way to control it better better allways ask fro restart
                RaiseEvent NeedsRestart()
                RaiseEvent NeedsRefresh()
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim tAddon As New Containers.Addon
        tAddon.ID = Me._id
        tAddon.Name = Me._addonname
        tAddon.Description = Me._summary
        tAddon.Version = Me._version
        tAddon.MinEVersion = Me._mineversion
        tAddon.MaxEVersion = Me._maxeversion
        tAddon.Category = Me._category
        tAddon.Files = Me._filelist
        tAddon.ScreenShotImage = Me._screenshot

        Using dEditAddon As New dlgAddEditAddon
            Dim eAddon As Containers.Addon = dEditAddon.ShowDialog(tAddon)
            If Not IsNothing(eAddon) Then
                eAddon.ID = Me._id
                RaiseEvent SendEdit(eAddon)
            End If
        End Using
    End Sub

    Private Sub btnUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUninstall.Click
        RaiseEvent IsDownloading(True)
        Master.DB.UninstallAddon(Me._id)
        Me.Installed = 0
        RaiseEvent IsDownloading(False)
    End Sub
End Class
