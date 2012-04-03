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

Imports System.Text.RegularExpressions
Imports EmberAPI

Public Class dlgAddons
    Public NeedsRestart As Boolean = False

    Friend WithEvents bwDownload As New System.ComponentModel.BackgroundWorker

    Private SessionID As String = String.Empty
    Private currType As String = String.Empty

    Private AddonItem() As AddonItem

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dlgAddons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iBackground As New Bitmap(Me.pnlCurrent.Width, Me.pnlCurrent.Height)
        Using b As Graphics = Graphics.FromImage(iBackground)
            b.FillRectangle(New Drawing2D.LinearGradientBrush(Me.pnlCurrent.ClientRectangle, Color.SteelBlue, Color.FromKnownColor(KnownColor.Control), Drawing2D.LinearGradientMode.Horizontal), pnlCurrent.ClientRectangle)
            Me.pnlCurrent.BackgroundImage = iBackground
        End Using

        Me.txtUsername.Text = Master.eSettings.Username
        Me.txtPassword.Text = Master.eSettings.Password

        Me.SetUp()

        If Not String.IsNullOrEmpty(Me.txtUsername.Text) AndAlso Not String.IsNullOrEmpty(txtPassword.Text) Then
            Me.Login()
        End If
    End Sub

    Private Sub SetUp()
        Me.Text = Master.eLang.GetString(285, "Addons")

        Me.lblLogin.Text = Master.eLang.GetString(287, "Login to Addons Server")
        Me.lblUsername.Text = Master.eLang.GetString(425, "Username:")
        Me.lblPassword.Text = Master.eLang.GetString(426, "Password")

        Me.btnLogin.Text = Master.eLang.GetString(286, "Login")
        Me.Cancel_Button.Text = Master.eLang.GetString(19, "Close")

        Me.tsbTranslations.Text = Master.eLang.GetString(290, "Translations")
        Me.tsbThemes.Text = Master.eLang.GetString(629, "Themes")
        Me.tsbTemplates.Text = Master.eLang.GetString(291, "Templates")
        Me.tsbModules.Text = Master.eLang.GetString(802, "Modules")
        Me.tsbOther.Text = Master.eLang.GetString(293, "Other")
        Me.tsbNew.Text = Master.eLang.GetString(294, "Create New")
    End Sub

    Private Function GetStatus(ByVal status As String) As String
        Try
            Dim regStat As Match = Regex.Match(status, "\<status\>(?<status>.*?)\<\/status\>", RegexOptions.IgnoreCase)
            If regStat.Success Then
                Dim tStatus As String = regStat.Groups("status").Value
                If Not String.IsNullOrEmpty(tStatus) Then
                    Return tStatus
                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
        Return String.Empty
    End Function

    Private Sub DoUpload(ByVal tAddon As Containers.Addon)
        Me.ControlsEnabled(False)
        Dim sHTTP As New HTTP

        Try
            Dim postData As New List(Of String())
            postData.Add((New String() {"username", Me.txtUsername.Text}))
            postData.Add((New String() {"password", Me.txtPassword.Text}))
            postData.Add((New String() {"func", "add"}))
            postData.Add((New String() {"id", If(tAddon.ID > -1, tAddon.ID.ToString, String.Empty)}))
            postData.Add((New String() {"Name", tAddon.Name}))
            postData.Add((New String() {"Description", tAddon.Description}))
            postData.Add((New String() {"Category", tAddon.Category}))
            postData.Add((New String() {"AddonVersion", tAddon.Version.ToString}))
            postData.Add((New String() {"EmberVersion_Min", tAddon.MinEVersion.ToString}))
            postData.Add((New String() {"EmberVersion_Max", tAddon.MaxEVersion.ToString}))
            postData.Add((New String() {"screenshot", tAddon.ScreenShotPath}))
            If Not tAddon.ScreenShotPath = "!KEEP!" Then
                postData.Add((New String() {tAddon.ScreenShotPath, tAddon.ScreenShotPath, "file"}))
            End If
            '   FIX
            Me.SessionID = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)

            If IsNumeric(GetStatus(Me.SessionID)) Then
                If Not tAddon.ID > -1 Then tAddon.ID = Convert.ToInt32(GetStatus(Me.SessionID))
                For Each f As String In tAddon.DeleteFiles
                    Try
                        postData.Clear()
                        postData.Add((New String() {"username", Me.txtUsername.Text}))
                        postData.Add((New String() {"password", Me.txtPassword.Text}))
                        postData.Add((New String() {"func", "deletefile"}))
                        postData.Add((New String() {"addon_id", tAddon.ID.ToString}))
                        postData.Add((New String() {"filename", f.Substring(Functions.AppPath.Length).Replace(System.IO.Path.DirectorySeparatorChar, "/")}))
                        '    FIX
                        Me.SessionID = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)
                        If IsNumeric(GetStatus(Me.SessionID)) Then
                            'ok
                        End If
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                    End Try
                Next
                For Each f As Generic.KeyValuePair(Of String, String) In tAddon.Files
                    Try
                        postData.Clear()
                        postData.Add((New String() {"username", Me.txtUsername.Text}))
                        postData.Add((New String() {"password", Me.txtPassword.Text}))
                        postData.Add((New String() {"func", "addfile"}))
                        postData.Add((New String() {"addon_id", tAddon.ID.ToString}))
                        postData.Add((New String() {"Description", f.Value}))
                        postData.Add((New String() {"Filename", f.Key.Substring(Functions.AppPath.Length).Replace(System.IO.Path.DirectorySeparatorChar, "/")}))
                        postData.Add((New String() {System.IO.Path.GetFileName(f.Key), f.Key, "file"}))
                        '    FIX
                        Me.SessionID = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)
                        If IsNumeric(GetStatus(Me.SessionID)) Then
                            'ok
                        End If
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                    End Try
                Next
            Else
                'error
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        sHTTP = Nothing

        If Me.currType = tAddon.Category Then Me.RefreshItems()
    End Sub

    Private Sub tsCategories_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsCategories.ItemClicked
        Try
            If Not e.ClickedItem.Tag Is Nothing Then
                If e.ClickedItem.Tag.ToString = "Create New" Then
                    Using dNewAddon As New dlgAddEditAddon
                        Dim tAddon As Containers.Addon = dNewAddon.ShowDialog(New Containers.Addon)
                        If Not IsNothing(tAddon) Then
                            Me.DoUpload(tAddon)
                        End If
                    End Using
                Else
                    If Not Me.currType = e.ClickedItem.Tag.ToString Then
                        Me.currType = e.ClickedItem.Tag.ToString
                        Me.pbCurrent.Image = e.ClickedItem.Image
                        Me.lblCurrent.Text = e.ClickedItem.Text
                        Me.LoadItems(e.ClickedItem.Tag.ToString)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub LoadItems(ByVal sType As String)
        Me.ClearList()

        Me.ControlsEnabled(False)

        Me.lblStatus.Text = String.Format(Master.eLang.GetString(288, "Fetching ""{0}"" Addons..."), sType)
        Me.pnlStatus.Visible = True

        Me.bwDownload = New System.ComponentModel.BackgroundWorker
        Me.bwDownload.WorkerReportsProgress = True
        Me.bwDownload.RunWorkerAsync(sType)
    End Sub

    Public Sub RefreshItems()
        Me.LoadItems(Me.currType)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Login()
    End Sub

    Private Sub Login()
        Dim sHTTP As New HTTP

        Try
            Me.SessionID = String.Empty

            Me.pnlLogin.Visible = False
            Me.lblStatus.Text = Master.eLang.GetString(289, "Logging in...")
            Me.pnlStatus.Visible = True

            Application.DoEvents()
            Dim postData As New List(Of String())
            postData.Add((New String() {"username", Me.txtUsername.Text}))
            postData.Add((New String() {"password", Me.txtPassword.Text}))
            postData.Add((New String() {"func", "login"}))
            '    FIX
            Me.SessionID = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)
            If Not String.IsNullOrEmpty(Me.SessionID) AndAlso Me.SessionID.Contains("OK") Then
                Me.pnlStatus.Visible = False
                Me.tsCategories.Enabled = True
                Master.eSettings.Username = Me.txtUsername.Text
                Master.eSettings.Password = Me.txtPassword.Text
                Master.eSettings.Save()
            Else
                Me.pnlStatus.Visible = False
                Me.pnlLogin.Visible = True
                Master.eLog.WriteToErrorLog("HTTP Response", Me.SessionID, "HTTP Error", False)
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
        sHTTP = Nothing
    End Sub

    Private Sub bwDownload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDownload.DoWork
        Dim aoXML As String = String.Empty
        Dim sHTTP As New HTTP
        Dim postData As New List(Of String())

        Try
            postData.Add((New String() {"username", Me.txtUsername.Text}))
            postData.Add((New String() {"password", Me.txtPassword.Text}))
            postData.Add((New String() {"type", e.Argument.ToString}))
            postData.Add((New String() {"func", "fetch"}))
            '    FIX
            aoXML = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)

            If Not String.IsNullOrEmpty(aoXML) Then
                Dim xdAddons As XDocument = XDocument.Parse(aoXML)
                Dim tTop As Integer = 0
                Dim iIndex As Integer = 0

                For Each xAddon In xdAddons.Descendants("entry")
                    Try
                        If (xAddon.Element("User").Value = Me.txtUsername.Text) OrElse EmberAddons.AllowedVersion(xAddon.Element("EmberVersion_Min").Value, xAddon.Element("EmberVersion_Max").Value) Then
                            ReDim Preserve Me.AddonItem(iIndex)
                            Me.AddonItem(iIndex) = New AddonItem
                            Me.AddonItem(iIndex).ID = Convert.ToInt32(xAddon.Element("id").Value)
                            Me.AddonItem(iIndex).AddonName = xAddon.Element("Name").Value
                            Me.AddonItem(iIndex).Author = xAddon.Element("User").Value
                            Me.AddonItem(iIndex).Version = NumUtils.ConvertToSingle(xAddon.Element("AddonVersion").Value)
                            Me.AddonItem(iIndex).MinEVersion = NumUtils.ConvertToSingle(xAddon.Element("EmberVersion_Min").Value)
                            Me.AddonItem(iIndex).MaxEVersion = NumUtils.ConvertToSingle(xAddon.Element("EmberVersion_Max").Value)
                            Me.AddonItem(iIndex).Summary = xAddon.Element("Description").Value
                            Me.AddonItem(iIndex).Category = e.Argument.ToString
                            If Me.txtUsername.Text = Me.AddonItem(iIndex).Author Then
                                Me.AddonItem(iIndex).Downloads = Convert.ToInt32(xAddon.Element("Count").Value)
                            End If
                            '    FIX
                            sHTTP.StartDownloadImage(String.Format("http://www.embermm.com/addons/addons.php?screenshot={0}", xAddon.Element("id").Value))
                            While sHTTP.IsDownloading
                                Application.DoEvents()
                                Threading.Thread.Sleep(50)
                            End While
                            Me.AddonItem(iIndex).ScreenShot = sHTTP.Image

                            Dim fList As New Generic.SortedList(Of String, String)
                            For Each fFile As XElement In xAddon.Descendants("file")
                                fList.Add(fFile.Element("Filename").Value, fFile.Element("Description").Value)
                            Next
                            Me.AddonItem(iIndex).FileList = fList

                            Me.AddonItem(iIndex).Left = 0
                            Me.AddonItem(iIndex).Top = tTop

                            Me.bwDownload.ReportProgress(0, Me.AddonItem(iIndex))

                            tTop += 105
                            iIndex += 1
                        End If
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                    End Try
                Next
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        postData = Nothing
        sHTTP = Nothing

    End Sub


    Private Sub bwDownload_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDownload.ProgressChanged
        Dim tAOI As AddonItem = DirectCast(e.UserState, AddonItem)
        AddHandler tAOI.NeedsRefresh, AddressOf Me.RefreshItems
        AddHandler tAOI.SendEdit, AddressOf Me.DoUpload
        AddHandler tAOI.IsDownloading, AddressOf Me.IsDownloading
        AddHandler tAOI.NeedsRestart, AddressOf Me.HandleNeedsRestart
        If tAOI.Downloads >= 0 Then
            tAOI.lblDownloads.Visible = True
            tAOI.lblDownloadsCount.Visible = True
            tAOI.lblDownloadsCount.Text = tAOI.Downloads.ToString
        End If
        tAOI.Owned = tAOI.Author = Master.eSettings.Username AndAlso Not String.IsNullOrEmpty(Me.SessionID)
        tAOI.Installed = Master.DB.IsAddonInstalled(tAOI.ID)
        Me.pnlList.Controls.Add(tAOI)
    End Sub

    Private Sub bwDownload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownload.RunWorkerCompleted
        Me.pnlStatus.Visible = False
        Me.ControlsEnabled(True)
    End Sub

    Private Sub ClearList()
        If Me.pnlList.Controls.Count > 0 Then
            For i As Integer = UBound(Me.AddonItem) To 0 Step -1
                Try
                    If Not IsNothing(Me.AddonItem(i)) Then
                        RemoveHandler Me.AddonItem(i).NeedsRefresh, AddressOf Me.RefreshItems
                        RemoveHandler Me.AddonItem(i).SendEdit, AddressOf Me.DoUpload
                        RemoveHandler Me.AddonItem(i).IsDownloading, AddressOf Me.IsDownloading
                        RemoveHandler Me.AddonItem(i).NeedsRestart, AddressOf Me.HandleNeedsRestart
                        Me.pnlList.Controls.Remove(Me.AddonItem(i))
                    End If
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                End Try
            Next
        End If
    End Sub
    Private Sub HandleNeedsRestart()
        NeedsRestart = True
    End Sub
    Private Sub IsDownloading(ByVal Bool As Boolean)
        Me.ControlsEnabled(Not Bool)
    End Sub

    Private Sub ControlsEnabled(ByVal isEnabled As Boolean)
        Me.pnlList.Enabled = isEnabled
        Me.tsCategories.Enabled = isEnabled
        Me.Cancel_Button.Enabled = isEnabled
    End Sub
End Class
