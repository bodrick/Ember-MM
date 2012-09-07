Imports EmberMediaManger.API
Imports System.Globalization

Namespace SettingsControls
    Public Class TVScraper
        Private tLangList As New List(Of Containers.TVLanguage)
        Private TVMeta As New List(Of Settings.MetadataPerType)

        Private Sub btnEditTVMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditTVMetaDataFT.Click
            Using dEditMeta As New dlgFileInfo
                Dim fi As MediaInfo.Fileinfo
                For Each x As Settings.MetadataPerType In TVMeta
                    If x.FileType = lstTVMetaData.SelectedItems(0).ToString Then
                        fi = dEditMeta.ShowDialog(x.MetaData, True)
                        If Not fi Is Nothing Then
                            TVMeta.Remove(x)
                            Dim m As New Settings.MetadataPerType
                            m.FileType = x.FileType
                            m.MetaData = New MediaInfo.Fileinfo
                            m.MetaData = fi
                            TVMeta.Add(m)
                            LoadTVMetadata()                            
                        End If
                        Exit For
                    End If
                Next
            End Using
        End Sub

        Private Sub btnNewTVMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewTVMetaDataFT.Click
            If Not txtTVDefFIExt.Text.StartsWith(".") Then txtTVDefFIExt.Text = String.Concat(".", txtTVDefFIExt.Text)
            Using dEditMeta As New dlgFileInfo
                Dim fi As New MediaInfo.Fileinfo
                fi = dEditMeta.ShowDialog(fi, True)
                If Not fi Is Nothing Then
                    Dim m As New Settings.MetadataPerType
                    m.FileType = txtTVDefFIExt.Text
                    m.MetaData = New MediaInfo.Fileinfo
                    m.MetaData = fi
                    TVMeta.Add(m)
                    LoadTVMetadata()                    
                    txtTVDefFIExt.Text = String.Empty
                    txtTVDefFIExt.Focus()
                End If
            End Using
        End Sub

        Private Sub btnTVLanguageFetch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnTVLanguageFetch.Click
            'tLangList.Clear()
            'tLangList.AddRange(ModulesManager.Instance.TVGetLangs(Master.eSettings.TVDBMirror))
            cbTVLanguage.Items.AddRange((From lLang In tLangList Select lLang.LongLang).ToArray)

            If cbTVLanguage.Items.Count > 0 Then
                cbTVLanguage.Text = tLangList.FirstOrDefault(Function(l) l.ShortLang = Master.eSettings.TVDBLanguage).LongLang
            End If
        End Sub

        Private Sub chkTVScanMetaData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTVScanMetaData.CheckedChanged
            cboTVMetaDataOverlay.Enabled = chkTVScanMetaData.Checked
            If Not chkTVScanMetaData.Checked Then
                cboTVMetaDataOverlay.SelectedIndex = 0
            End If
        End Sub
        Protected Overrides Sub LoadSettings()
            chkTVScanMetaData.Checked = Master.eSettings.ScanTVMediaInfo
            cboTVMetaDataOverlay.SelectedItem = If(String.IsNullOrEmpty(Master.eSettings.TVFlagLang), Master.eLang.Disabled, Master.eSettings.TVFlagLang)
            TVMeta.AddRange(Master.eSettings.TVMetadataperFileType)
            tLangList.Clear()
            tLangList.AddRange(Master.eSettings.TVDBLanguages)
            cbTVLanguage.Items.AddRange((From lLang In Master.eSettings.TVDBLanguages Select lLang.LongLang).ToArray)
            If cbTVLanguage.Items.Count > 0 Then
                cbTVLanguage.Text = tLangList.FirstOrDefault(Function(l) l.ShortLang = Master.eSettings.TVDBLanguage).LongLang
            End If            
            cboTVUpdate.SelectedIndex = Master.eSettings.TVUpdateTime
            chkShowLockTitle.Checked = Master.eSettings.ShowLockTitle
            chkShowLockPlot.Checked = Master.eSettings.ShowLockPlot
            chkShowLockRating.Checked = Master.eSettings.ShowLockRating
            chkShowLockGenre.Checked = Master.eSettings.ShowLockGenre
            chkShowLockStudio.Checked = Master.eSettings.ShowLockStudio
            chkEpLockTitle.Checked = Master.eSettings.EpLockTitle
            chkEpLockPlot.Checked = Master.eSettings.EpLockPlot
            chkEpLockRating.Checked = Master.eSettings.EpLockRating
            chkScraperShowTitle.Checked = Master.eSettings.ScraperShowTitle
            chkScraperShowEGU.Checked = Master.eSettings.ScraperShowEGU
            chkScraperShowGenre.Checked = Master.eSettings.ScraperShowGenre
            chkScraperShowMPAA.Checked = Master.eSettings.ScraperShowMPAA
            chkScraperShowPlot.Checked = Master.eSettings.ScraperShowPlot
            chkScraperShowPremiered.Checked = Master.eSettings.ScraperShowPremiered
            chkScraperShowRating.Checked = Master.eSettings.ScraperShowRating
            chkScraperShowStudio.Checked = Master.eSettings.ScraperShowStudio
            chkScraperShowActors.Checked = Master.eSettings.ScraperShowActors
            chkScraperEpTitle.Checked = Master.eSettings.ScraperEpTitle
            chkScraperEpSeason.Checked = Master.eSettings.ScraperEpSeason
            chkScraperEpEpisode.Checked = Master.eSettings.ScraperEpEpisode
            chkScraperEpAired.Checked = Master.eSettings.ScraperEpAired
            chkScraperEpRating.Checked = Master.eSettings.ScraperEpRating
            chkScraperEpPlot.Checked = Master.eSettings.ScraperEpPlot
            chkScraperEpDirector.Checked = Master.eSettings.ScraperEpDirector
            chkScraperEpCredits.Checked = Master.eSettings.ScraperEpCredits
            chkScraperEpActors.Checked = Master.eSettings.ScraperEpActors
            cbOrdering.SelectedIndex = Master.eSettings.OrderDefault
            LoadTVMetadata()
        End Sub

        Private Sub LoadLangs()
            cboTVMetaDataOverlay.Items.Add(Master.eLang.Disabled)
            cboTVMetaDataOverlay.Items.AddRange(CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(Function(f) f.NativeName))
        End Sub

        Private Sub LoadTVMetadata()
            lstTVMetaData.Items.Clear()
            For Each x As Settings.MetadataPerType In TVMeta
                lstTVMetaData.Items.Add(x.FileType)
            Next
        End Sub

        Private Sub lstTVMetaData_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstTVMetaData.DoubleClick
            If lstTVMetaData.SelectedItems.Count > 0 Then
                Using dEditMeta As New dlgFileInfo
                    Dim fi As MediaInfo.Fileinfo
                    For Each x As Settings.MetadataPerType In TVMeta
                        If x.FileType = lstTVMetaData.SelectedItems(0).ToString Then
                            fi = dEditMeta.ShowDialog(x.MetaData, True)
                            If Not fi Is Nothing Then
                                TVMeta.Remove(x)
                                Dim m As New Settings.MetadataPerType
                                m.FileType = x.FileType
                                m.MetaData = New MediaInfo.Fileinfo
                                m.MetaData = fi
                                TVMeta.Add(m)
                                LoadTVMetadata()
                                OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
                            End If
                            Exit For
                        End If
                    Next
                End Using
            End If
        End Sub

        Private Sub lstTVMetadata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstTVMetaData.SelectedIndexChanged
            If lstTVMetaData.SelectedItems.Count > 0 Then
                btnEditTVMetaDataFT.Enabled = True
                btnRemoveTVMetaDataFT.Enabled = True
                txtTVDefFIExt.Text = String.Empty
            Else
                btnEditTVMetaDataFT.Enabled = False
                btnRemoveTVMetaDataFT.Enabled = False
            End If
        End Sub

        Private Sub RemoveTVMetaData()
            If lstTVMetaData.SelectedItems.Count > 0 Then
                For Each x As Settings.MetadataPerType In TVMeta
                    If x.FileType = lstTVMetaData.SelectedItems(0).ToString Then
                        TVMeta.Remove(x)
                        LoadTVMetadata()
                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.ScanTVMediaInfo = chkTVScanMetaData.Checked
            Master.eSettings.TVFlagLang = If(cboTVMetaDataOverlay.Text = Master.eLang.Disabled, String.Empty, cboTVMetaDataOverlay.Text)
            Master.eSettings.TVMetadataperFileType.Clear()
            Master.eSettings.TVMetadataperFileType.AddRange(TVMeta)
            If tLangList.Count > 0 Then
                Dim tLang As String = tLangList.FirstOrDefault(Function(l) l.LongLang = cbTVLanguage.Text).ShortLang
                If Not String.IsNullOrEmpty(tLang) Then
                    Master.eSettings.TVDBLanguage = tLang
                Else
                    Master.eSettings.TVDBLanguage = "en"
                End If
            Else
                Master.eSettings.TVDBLanguage = "en"
            End If
            Master.eSettings.TVDBLanguages = tLangList
            
            Master.eSettings.TVUpdateTime = DirectCast(cboTVUpdate.SelectedIndex, Enums.TVUpdateTime)
            Master.eSettings.ShowLockTitle = chkShowLockTitle.Checked
            Master.eSettings.ShowLockPlot = chkShowLockPlot.Checked
            Master.eSettings.ShowLockRating = chkShowLockRating.Checked
            Master.eSettings.ShowLockGenre = chkShowLockGenre.Checked
            Master.eSettings.ShowLockStudio = chkShowLockStudio.Checked
            Master.eSettings.EpLockTitle = chkEpLockTitle.Checked
            Master.eSettings.EpLockPlot = chkEpLockPlot.Checked
            Master.eSettings.EpLockRating = chkEpLockRating.Checked
            Master.eSettings.ScraperShowTitle = chkScraperShowTitle.Checked
            Master.eSettings.ScraperShowEGU = chkScraperShowEGU.Checked
            Master.eSettings.ScraperShowGenre = chkScraperShowGenre.Checked
            Master.eSettings.ScraperShowMPAA = chkScraperShowMPAA.Checked
            Master.eSettings.ScraperShowPlot = chkScraperShowPlot.Checked
            Master.eSettings.ScraperShowPremiered = chkScraperShowPremiered.Checked
            Master.eSettings.ScraperShowRating = chkScraperShowRating.Checked
            Master.eSettings.ScraperShowStudio = chkScraperShowStudio.Checked
            Master.eSettings.ScraperShowActors = chkScraperShowActors.Checked
            Master.eSettings.ScraperEpTitle = chkScraperEpTitle.Checked
            Master.eSettings.ScraperEpSeason = chkScraperEpSeason.Checked
            Master.eSettings.ScraperEpEpisode = chkScraperEpEpisode.Checked
            Master.eSettings.ScraperEpAired = chkScraperEpAired.Checked
            Master.eSettings.ScraperEpRating = chkScraperEpRating.Checked
            Master.eSettings.ScraperEpPlot = chkScraperEpPlot.Checked
            Master.eSettings.ScraperEpDirector = chkScraperEpDirector.Checked
            Master.eSettings.ScraperEpCredits = chkScraperEpCredits.Checked
            Master.eSettings.ScraperEpActors = chkScraperEpActors.Checked

            Master.eSettings.OrderDefault = DirectCast(cbOrdering.SelectedIndex, Enums.Ordering)
        End Sub

        Private Sub txtTVDefFIExt_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtTVDefFIExt.TextChanged
            btnNewTVMetaDataFT.Enabled = Not String.IsNullOrEmpty(txtTVDefFIExt.Text) AndAlso Not lstTVMetaData.Items.Contains(If(txtTVDefFIExt.Text.StartsWith("."), txtTVDefFIExt.Text, String.Concat(".", txtTVDefFIExt.Text)))
            If btnNewTVMetaDataFT.Enabled Then
                btnEditTVMetaDataFT.Enabled = False
                btnRemoveTVMetaDataFT.Enabled = False
            End If
        End Sub

        Private Sub lstTVMetaData_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstTVMetaData.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveTVMetaData()
        End Sub

        Private Sub btnRemoveTVMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveTVMetaDataFT.Click
            RemoveTVMetaData()
        End Sub

        Protected Overrides Sub LoadResources()
            chkScraperShowTitle.Text = Master.eLang.GetString(21, "Title")
            chkScraperShowEGU.Text = Master.eLang.GetString(723, "EpisodeGuideURL")
            chkScraperShowGenre.Text = Master.eLang.GetString(20, "Genres")
            chkScraperShowMPAA.Text = Master.eLang.GetString(401, "MPAA")
            chkScraperShowPlot.Text = Master.eLang.GetString(65, "Plot")
            chkScraperShowPremiered.Text = Master.eLang.GetString(724, "Premiered")
            chkScraperShowRating.Text = Master.eLang.GetString(400, "Rating")
            chkScraperShowStudio.Text = Master.eLang.GetString(395, "Studio")
            chkScraperShowActors.Text = Master.eLang.GetString(725, "Actors")
            chkScraperEpTitle.Text = Master.eLang.GetString(21, "Title")
            chkScraperEpSeason.Text = Master.eLang.GetString(650, "Season")
            chkScraperEpEpisode.Text = Master.eLang.GetString(727, Languages.Episode)
            chkScraperEpAired.Text = Master.eLang.GetString(728, "Aired")
            chkScraperEpRating.Text = Master.eLang.GetString(400, "Rating")
            chkScraperEpPlot.Text = Master.eLang.GetString(65, "Plot")
            chkScraperEpDirector.Text = Master.eLang.GetString(62, "Director")
            chkScraperEpCredits.Text = Master.eLang.GetString(729, "Credits")
            chkScraperEpActors.Text = Master.eLang.GetString(725, "Actors")
            lblTVUpdate.Text = Master.eLang.GetString(740, "Re-download Show Information Every:")
            gbLanguage.Text = Master.eLang.GetString(610, "Language")
            lblTVLanguagePreferred.Text = Master.eLang.GetString(741, "Preferred Language:")
            btnTVLanguageFetch.Text = Master.eLang.GetString(742, "Fetch Available Languages")
            gbShowLocks.Text = Master.eLang.GetString(743, Languages.Show)
            chkShowLockTitle.Text = Master.eLang.GetString(494, "Lock Title")
            chkShowLockPlot.Text = Master.eLang.GetString(496, "Lock Plot")
            chkShowLockRating.Text = Master.eLang.GetString(492, "Lock Rating")
            chkShowLockGenre.Text = Master.eLang.GetString(490, "Lock Genre")
            chkShowLockStudio.Text = Master.eLang.GetString(491, "Lock Studio")
            gbEpLocks.Text = Master.eLang.GetString(727, Languages.Episode)
            chkEpLockTitle.Text = Master.eLang.GetString(494, "Lock Title")
            chkEpLockPlot.Text = Master.eLang.GetString(496, "Lock Plot")
            chkEpLockRating.Text = Master.eLang.GetString(492, "Lock Rating")
            gbTVScraperOptions.Text = Master.eLang.GetString(390, "Options")            
            lblOrdering.Text = Master.eLang.GetString(797, "Default Episode Ordering:")
            cboTVUpdate.Items.Clear()
            cboTVUpdate.Items.AddRange(New String() {Master.eLang.GetString(749, "Week"), Master.eLang.GetString(750, "Bi-Weekly"), Master.eLang.GetString(751, "Month"), Master.eLang.GetString(752, "Never"), Master.eLang.GetString(753, "Always")})
            cbOrdering.Items.Clear()
            cbOrdering.Items.AddRange(New String() {Master.eLang.GetString(438, Languages.Standard), Master.eLang.GetString(350, "DVD"), Master.eLang.GetString(839, "Absolute")})
            LoadLangs()            
        End Sub
    End Class
End Namespace