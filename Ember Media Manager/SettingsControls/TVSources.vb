Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class TVSources
        Private ShowRegex As New List(Of Settings.TVShowRegEx)

        Private Sub btnAddShowRegex_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddShowRegex.Click
            If String.IsNullOrEmpty(btnAddShowRegex.Tag.ToString) Then
                Dim lID = (From lRegex As Settings.TVShowRegEx In ShowRegex Select lRegex.ID).Max
                ShowRegex.Add(New Settings.TVShowRegEx With {.ID = Convert.ToInt32(lID) + 1, .SeasonRegex = txtSeasonRegex.Text, .SeasonFromDirectory = Not Convert.ToBoolean(cboSeasonRetrieve.SelectedIndex), .EpisodeRegex = txtEpRegex.Text, .EpisodeRetrieve = DirectCast(cboEpRetrieve.SelectedIndex, Settings.EpRetrieve)})
            Else
                Dim selRex = From lRegex As Settings.TVShowRegEx In ShowRegex Where lRegex.ID = Convert.ToInt32(btnAddShowRegex.Tag)
                If selRex.Count > 0 Then
                    selRex(0).SeasonRegex = txtSeasonRegex.Text
                    selRex(0).SeasonFromDirectory = Not Convert.ToBoolean(cboSeasonRetrieve.SelectedIndex)
                    selRex(0).EpisodeRegex = txtEpRegex.Text
                    selRex(0).EpisodeRetrieve = DirectCast(cboEpRetrieve.SelectedIndex, Settings.EpRetrieve)
                End If
            End If
            ClearRegex()            
            LoadShowRegex()
        End Sub

        Private Sub btnEditShowRegex_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditShowRegex.Click
            If lvShowRegex.SelectedItems.Count > 0 Then EditShowRegex(lvShowRegex.SelectedItems(0))
        End Sub

        Private Sub btnEditTVSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditTVSource.Click
            If lvTVSources.SelectedItems.Count > 0 Then
                Using dTVSource As New dlgTVSource
                    If dTVSource.ShowDialog(Convert.ToInt32(lvTVSources.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                        RefreshTVSources()                        
                    End If
                End Using
            End If
        End Sub

        Private Sub btnRegexUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRegexUp.Click
            Try
                If lvShowRegex.Items.Count > 0 AndAlso lvShowRegex.SelectedItems.Count > 0 AndAlso Not lvShowRegex.SelectedItems(0).Index = 0 Then
                    Dim selItem As Settings.TVShowRegEx = ShowRegex.FirstOrDefault(Function(r) r.ID = Convert.ToInt32(lvShowRegex.SelectedItems(0).Text))

                    If Not IsNothing(selItem) Then
                        lvShowRegex.SuspendLayout()
                        Dim iIndex As Integer = ShowRegex.IndexOf(selItem)
                        Dim selIndex As Integer = lvShowRegex.SelectedIndices(0)
                        ShowRegex.Remove(selItem)
                        ShowRegex.Insert(iIndex - 1, selItem)

                        RenumberRegex()
                        LoadShowRegex()

                        lvShowRegex.Items(selIndex - 1).Selected = True
                        lvShowRegex.ResumeLayout()
                    End If
                    lvShowRegex.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnRegexDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRegexDown.Click
            Try
                If lvShowRegex.Items.Count > 0 AndAlso lvShowRegex.SelectedItems.Count > 0 AndAlso lvShowRegex.SelectedItems(0).Index < (lvShowRegex.Items.Count - 1) Then
                    Dim selItem As Settings.TVShowRegEx = ShowRegex.FirstOrDefault(Function(r) r.ID = Convert.ToInt32(lvShowRegex.SelectedItems(0).Text))

                    If Not IsNothing(selItem) Then
                        lvShowRegex.SuspendLayout()
                        Dim iIndex As Integer = ShowRegex.IndexOf(selItem)
                        Dim selIndex As Integer = lvShowRegex.SelectedIndices(0)
                        ShowRegex.Remove(selItem)
                        ShowRegex.Insert(iIndex + 1, selItem)

                        RenumberRegex()
                        LoadShowRegex()

                        lvShowRegex.Items(selIndex + 1).Selected = True
                        lvShowRegex.ResumeLayout()
                    End If
                    lvShowRegex.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnGetTVProfiles_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnGetTVProfiles.Click
            Using dd As New dlgTVRegExProfiles
                If dd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ShowRegex.Clear()
                    ShowRegex.AddRange(dd.ShowRegex)
                    LoadShowRegex()                    
                End If
            End Using
        End Sub

        Private Sub btnResetShowRegex_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetShowRegex.Click
            If MsgBox(Master.eLang.GetString(844, "Are you sure you want to reset to the default list of show regex?"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                Master.eSettings.SetDefaultsForLists(Enums.DefaultType.ShowRegex, True)
                ShowRegex.Clear()
                ShowRegex.AddRange(Master.eSettings.TVShowRegexes)
                LoadShowRegex()                
            End If
        End Sub

        Private Sub ClearRegex()
            btnAddShowRegex.Text = Master.eLang.GetString(115, "Add Regex")
            btnAddShowRegex.Tag = String.Empty
            btnAddShowRegex.Enabled = False
            txtSeasonRegex.Text = String.Empty
            cboSeasonRetrieve.SelectedIndex = -1
            txtEpRegex.Text = String.Empty
            cboEpRetrieve.SelectedIndex = -1
        End Sub

        Private Sub EditShowRegex(ByVal lItem As ListViewItem)
            btnAddShowRegex.Text = Master.eLang.GetString(124, "Update Regex")
            btnAddShowRegex.Tag = lItem.Text

            txtSeasonRegex.Text = lItem.SubItems(1).Text.ToString

            Select Case lItem.SubItems(2).Text
                Case "Folder"
                    cboSeasonRetrieve.SelectedIndex = 0
                Case "File"
                    cboSeasonRetrieve.SelectedIndex = 1
            End Select

            txtEpRegex.Text = lItem.SubItems(3).Text

            Select Case lItem.SubItems(4).Text
                Case "Folder"
                    cboEpRetrieve.SelectedIndex = 0
                Case "File"
                    cboEpRetrieve.SelectedIndex = 1
                Case "Result"
                    cboEpRetrieve.SelectedIndex = 2
            End Select
        End Sub

        Protected Overrides Sub LoadSettings()
            txtTVSkipLessThan.Text = Master.eSettings.SkipLessThanEp.ToString
            chkTVCleanDB.Checked = Master.eSettings.TVCleanDB
            chkTVIgnoreLastScan.Checked = Master.eSettings.TVIgnoreLastScan
            ShowRegex.AddRange(Master.eSettings.TVShowRegexes)
            LoadShowRegex()
            chkSeasonAllTBN.Checked = Master.eSettings.SeasonAllTBN
            chkSeasonAllJPG.Checked = Master.eSettings.SeasonAllJPG
            chkShowTBN.Checked = Master.eSettings.ShowTBN
            chkShowJPG.Checked = Master.eSettings.ShowJPG
            chkShowFolderJPG.Checked = Master.eSettings.ShowFolderJPG
            chkShowPosterTBN.Checked = Master.eSettings.ShowPosterTBN
            chkShowPosterJPG.Checked = Master.eSettings.ShowPosterJPG
            chkShowBannerJPG.Checked = Master.eSettings.ShowBannerJPG
            chkShowFanartJPG.Checked = Master.eSettings.ShowFanartJPG
            chkShowDashFanart.Checked = Master.eSettings.ShowDashFanart
            chkShowDotFanart.Checked = Master.eSettings.ShowDotFanart
            chkSeasonXXTBN.Checked = Master.eSettings.SeasonXX
            chkSeasonXTBN.Checked = Master.eSettings.SeasonX
            chkSeasonPosterTBN.Checked = Master.eSettings.SeasonPosterTBN
            chkSeasonPosterJPG.Checked = Master.eSettings.SeasonPosterJPG
            chkSeasonNameTBN.Checked = Master.eSettings.SeasonNameTBN
            chkSeasonNameJPG.Checked = Master.eSettings.SeasonNameJPG
            chkSeasonFolderJPG.Checked = Master.eSettings.SeasonFolderJPG
            chkSeasonFanartJPG.Checked = Master.eSettings.SeasonFanartJPG
            chkSeasonDashFanart.Checked = Master.eSettings.SeasonDashFanart
            chkSeasonDotFanart.Checked = Master.eSettings.SeasonDotFanart
            chkEpisodeTBN.Checked = Master.eSettings.EpisodeTBN
            chkEpisodeJPG.Checked = Master.eSettings.EpisodeJPG
            chkEpisodeDashFanart.Checked = Master.eSettings.EpisodeDashFanart
            chkEpisodeDotFanart.Checked = Master.eSettings.EpisodeDotFanart
            chkTVScanOrderModify.Checked = Master.eSettings.TVScanOrderModify
            RefreshTVSources()
        End Sub

        Private Sub LoadShowRegex()
            Dim lvItem As ListViewItem
            lvShowRegex.Items.Clear()
            For Each rShow As Settings.TVShowRegEx In ShowRegex
                lvItem = New ListViewItem(rShow.ID.ToString)
                lvItem.SubItems.Add(rShow.SeasonRegex)
                lvItem.SubItems.Add(If(rShow.SeasonFromDirectory, "Folder", "File"))
                lvItem.SubItems.Add(rShow.EpisodeRegex)
                Select Case rShow.EpisodeRetrieve
                    Case Settings.EpRetrieve.FromDirectory
                        lvItem.SubItems.Add("Folder")
                    Case Settings.EpRetrieve.FromFilename
                        lvItem.SubItems.Add("File")
                    Case Settings.EpRetrieve.FromSeasonResult
                        lvItem.SubItems.Add("Result")
                End Select
                lvShowRegex.Items.Add(lvItem)
            Next
        End Sub

        Private Sub lvShowRegex_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvShowRegex.DoubleClick
            If lvShowRegex.SelectedItems.Count > 0 Then EditShowRegex(lvShowRegex.SelectedItems(0))
        End Sub

        Private Sub lvShowRegex_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lvShowRegex.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveRegex()
        End Sub

        Private Sub lvShowRegex_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lvShowRegex.SelectedIndexChanged
            If Not String.IsNullOrEmpty(btnAddShowRegex.Tag.ToString) Then ClearRegex()
        End Sub

        Private Sub lvTVSources_ColumnClick(ByVal sender As Object, ByVal e As Windows.Forms.ColumnClickEventArgs) Handles lvTVSources.ColumnClick
            lvTVSources.ListViewItemSorter = New StringUtils.ListViewItemComparer(e.Column)
        End Sub

        Private Sub lvTVSources_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvTVSources.DoubleClick
            If lvTVSources.SelectedItems.Count > 0 Then
                Using dTVSource As New dlgTVSource
                    If dTVSource.ShowDialog(Convert.ToInt32(lvTVSources.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                        RefreshTVSources()
                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
                    End If
                End Using
            End If
        End Sub

        Private Sub RefreshTVSources()
            Dim lvItem As ListViewItem
            Master.TVSources.Clear()
            Master.TVSources.AddRange(Classes.Database.GetTVSources())
            lvTVSources.Items.Clear()
            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                SQLcommand.CommandText = "SELECT * FROM TVSources;"
                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                    While SQLreader.Read
                        lvItem = New ListViewItem(SQLreader("ID").ToString)
                        lvItem.SubItems.Add(SQLreader("Name").ToString)
                        lvItem.SubItems.Add(SQLreader("Path").ToString)
                        lvTVSources.Items.Add(lvItem)
                    End While
                End Using
            End Using
        End Sub

        Private Sub RemoveRegex()
            Dim ID As Integer
            For Each lItem As ListViewItem In lvShowRegex.SelectedItems
                ID = Convert.ToInt32(lItem.Text)
                Dim selRex = From lRegex As Settings.TVShowRegEx In ShowRegex Where lRegex.ID = ID
                If selRex.Count > 0 Then
                    ShowRegex.Remove(selRex(0))
                    OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
                End If
            Next
            LoadShowRegex()
        End Sub

        Private Sub RemoveTVSource()
            Try
                If lvTVSources.SelectedItems.Count > 0 Then
                    If MsgBox(Master.eLang.GetString(418, "Are you sure you want to remove the selected sources? This will remove the TV Shows from these sources from the Ember database."), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                        lvTVSources.BeginUpdate()

                        Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
                            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                                Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.String, 0, "source")
                                While lvTVSources.SelectedItems.Count > 0
                                    parSource.Value = lvTVSources.SelectedItems(0).SubItems(1).Text
                                    SQLcommand.CommandText = "SELECT Id FROM TVShows WHERE Source = (?);"
                                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                        While SQLReader.Read
                                            Master.DB.DeleteTVShowFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                        End While
                                    End Using
                                    SQLcommand.CommandText = String.Concat("DELETE FROM TVSources WHERE name = (?);")
                                    SQLcommand.ExecuteNonQuery()
                                    lvTVSources.Items.Remove(lvTVSources.SelectedItems(0))
                                End While
                            End Using
                            SQLtransaction.Commit()
                        End Using

                        lvTVSources.Sort()
                        lvTVSources.EndUpdate()
                        lvTVSources.Refresh()
                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
                    End If
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub RenumberRegex()
            For i As Integer = 0 To ShowRegex.Count - 1
                ShowRegex(i).ID = i
            Next
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.SkipLessThanEp = Convert.ToInt32(txtTVSkipLessThan.Text)
            Master.eSettings.TVCleanDB = chkTVCleanDB.Checked
            Master.eSettings.TVIgnoreLastScan = chkTVIgnoreLastScan.Checked
            Master.eSettings.TVShowRegexes.Clear()
            Master.eSettings.TVShowRegexes.AddRange(ShowRegex)
            Master.eSettings.SeasonAllTBN = chkSeasonAllTBN.Checked
            Master.eSettings.SeasonAllJPG = chkSeasonAllJPG.Checked
            Master.eSettings.ShowTBN = chkShowTBN.Checked
            Master.eSettings.ShowJPG = chkShowJPG.Checked
            Master.eSettings.ShowFolderJPG = chkShowFolderJPG.Checked
            Master.eSettings.ShowPosterTBN = chkShowPosterTBN.Checked
            Master.eSettings.ShowPosterJPG = chkShowPosterJPG.Checked
            Master.eSettings.ShowBannerJPG = chkShowBannerJPG.Checked
            Master.eSettings.ShowFanartJPG = chkShowFanartJPG.Checked
            Master.eSettings.ShowDashFanart = chkShowDashFanart.Checked
            Master.eSettings.ShowDotFanart = chkShowDotFanart.Checked
            Master.eSettings.SeasonXX = chkSeasonXXTBN.Checked
            Master.eSettings.SeasonX = chkSeasonXTBN.Checked
            Master.eSettings.SeasonPosterTBN = chkSeasonPosterTBN.Checked
            Master.eSettings.SeasonPosterJPG = chkSeasonPosterJPG.Checked
            Master.eSettings.SeasonNameTBN = chkSeasonNameTBN.Checked
            Master.eSettings.SeasonNameJPG = chkSeasonNameJPG.Checked
            Master.eSettings.SeasonFolderJPG = chkSeasonFolderJPG.Checked
            Master.eSettings.SeasonFanartJPG = chkSeasonFanartJPG.Checked
            Master.eSettings.SeasonDashFanart = chkSeasonDashFanart.Checked
            Master.eSettings.SeasonDotFanart = chkSeasonDotFanart.Checked
            Master.eSettings.EpisodeTBN = chkEpisodeTBN.Checked
            Master.eSettings.EpisodeJPG = chkEpisodeJPG.Checked
            Master.eSettings.EpisodeDashFanart = chkEpisodeDashFanart.Checked
            Master.eSettings.EpisodeDotFanart = chkEpisodeDotFanart.Checked
            Master.eSettings.TVScanOrderModify = chkTVScanOrderModify.Checked
        End Sub

        Private Sub btnAddTVSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddTVSource.Click
            Using dSource As New dlgTVSource
                If dSource.ShowDialog = Windows.Forms.DialogResult.OK Then
                    RefreshTVSources()                    
                End If
            End Using
        End Sub

        Private Sub btnClearRegex_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnClearRegex.Click
            ClearRegex()
        End Sub

        Private Sub btnRemoveShowRegex_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveShowRegex.Click
            RemoveRegex()
        End Sub

        Private Sub btnRemTVSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemTVSource.Click
            RemoveTVSource()
            Master.TVSources.Clear()
            Master.TVSources.AddRange(Classes.Database.GetTVSources())
        End Sub

        Private Sub lvTVSources_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lvTVSources.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveTVSource()
        End Sub

        Private Sub ValidateRegex()
            If Not String.IsNullOrEmpty(txtSeasonRegex.Text) AndAlso Not String.IsNullOrEmpty(txtEpRegex.Text) Then
                If cboSeasonRetrieve.SelectedIndex > -1 AndAlso cboEpRetrieve.SelectedIndex > -1 Then
                    btnAddShowRegex.Enabled = True
                Else
                    btnAddShowRegex.Enabled = False
                End If
            End If
        End Sub

        Private Sub cboEpRetrieve_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cboEpRetrieve.SelectedIndexChanged
            ValidateRegex()
        End Sub

        Private Sub cboSeasonRetrieve_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cboSeasonRetrieve.SelectedIndexChanged
            ValidateRegex()
        End Sub

        Private Sub txtEpRegex_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtEpRegex.TextChanged
            ValidateRegex()
        End Sub

        Private Sub txtSeasonRegex_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSeasonRegex.TextChanged
            ValidateRegex()
        End Sub

        Protected Overrides Sub LoadResources()
            btnAddShowRegex.Tag = String.Empty
            btnRemTVSource.Text = Master.eLang.GetString(30, "Remove")
            btnEditTVSource.Text = Master.eLang.GetString(535, "Edit Source")
            gbMiscTVSourceOpts.Text = Master.eLang.GetString(536, "Miscellaneous Options")
            gbShowPosters.Text = Master.eLang.GetString(683, "Show Posters")
            gbShowFanart.Text = Master.eLang.GetString(684, "Show Fanart")
            gbSeasonPosters.Text = Master.eLang.GetString(685, "Season Posters")
            gbSeasonFanart.Text = Master.eLang.GetString(686, "Season Fanart")
            gbEpisodePosters.Text = Master.eLang.GetString(687, "Episode Posters")
            gbEpisodeFanart.Text = Master.eLang.GetString(688, "Episode Fanart")
            btnEditShowRegex.Text = Master.eLang.GetString(690, "Edit Regex")
            btnRemoveShowRegex.Text = Master.eLang.GetString(30, "Remove")
            gbShowRegex.Text = Master.eLang.GetString(691, "Show Match Regex")
            lblSeasonMatch.Text = Master.eLang.GetString(692, "Season Match Regex:")
            lblEpisodeMatch.Text = Master.eLang.GetString(693, "Episode Match Regex:")
            lblSeasonRetrieve.Text = String.Concat(Master.eLang.GetString(694, "Apply To"), ":")
            lblEpisodeRetrieve.Text = lblSeasonRetrieve.Text
            btnAddShowRegex.Text = Master.eLang.GetString(695, "Edit Regex")
            gbAllSeasonPoster.Text = Master.eLang.GetString(735, "All Season Posters")
            btnClearRegex.Text = Master.eLang.GetString(123, "Clear")
            lvTVSources.Columns(1).Text = Master.eLang.GetString(232, "Name")
            lvTVSources.Columns(2).Text = Master.eLang.GetString(410, "Path")
            lvShowRegex.Columns(1).Text = Master.eLang.GetString(696, "Show Regex")
            lvShowRegex.Columns(2).Text = Master.eLang.GetString(694, "Apply To")
            lvShowRegex.Columns(3).Text = Master.eLang.GetString(697, "Episode Regex")
            lvShowRegex.Columns(4).Text = Master.eLang.GetString(694, "Apply To")
            TabPage5.Text = Master.eLang.GetString(38, "General")
            TabPage6.Text = Master.eLang.GetString(699, "Regex")
            cboSeasonRetrieve.Items.Clear()
            cboSeasonRetrieve.Items.AddRange(New String() {Master.eLang.GetString(13, "Folder Name"), Master.eLang.GetString(15, "File Name")})
            cboEpRetrieve.Items.Clear()
            cboEpRetrieve.Items.AddRange(New String() {Master.eLang.GetString(13, "Folder Name"), Master.eLang.GetString(15, "File Name"), Master.eLang.GetString(16, "Season Result")})
            lvTVSources.ListViewItemSorter = New StringUtils.ListViewItemComparer(1)            
        End Sub

        Private Sub txtTVSkipLessThan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTVSkipLessThan.TextChanged
            OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
        End Sub
    End Class

End Namespace