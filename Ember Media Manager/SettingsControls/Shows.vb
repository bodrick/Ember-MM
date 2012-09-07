Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class Shows
        Private Sub btnAddEpFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddEpFilter.Click
            If Not String.IsNullOrEmpty(txtEpFilter.Text) Then
                lstEpFilters.Items.Add(txtEpFilter.Text)
                txtEpFilter.Text = String.Empty            
            End If
            txtEpFilter.Focus()
        End Sub

        Private Sub btnAddShowFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddShowFilter.Click
            If Not String.IsNullOrEmpty(txtShowFilter.Text) Then
                lstShowFilters.Items.Add(txtShowFilter.Text)
                txtShowFilter.Text = String.Empty                
            End If
            txtShowFilter.Focus()
        End Sub

        Private Sub btnEpFilterDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEpFilterDown.Click
            Try
                If lstEpFilters.Items.Count > 0 AndAlso Not IsNothing(lstEpFilters.SelectedItem) AndAlso lstEpFilters.SelectedIndex < (lstEpFilters.Items.Count - 1) Then
                    Dim iIndex As Integer = lstEpFilters.SelectedIndices(0)
                    lstEpFilters.Items.Insert(iIndex + 2, lstEpFilters.SelectedItems(0))
                    lstEpFilters.Items.RemoveAt(iIndex)
                    lstEpFilters.SelectedIndex = iIndex + 1                    
                    lstEpFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnEpFilterUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEpFilterUp.Click
            Try
                If lstEpFilters.Items.Count > 0 AndAlso Not IsNothing(lstEpFilters.SelectedItem) AndAlso lstEpFilters.SelectedIndex > 0 Then
                    Dim iIndex As Integer = lstEpFilters.SelectedIndices(0)
                    lstEpFilters.Items.Insert(iIndex - 1, lstEpFilters.SelectedItems(0))
                    lstEpFilters.Items.RemoveAt(iIndex + 1)
                    lstEpFilters.SelectedIndex = iIndex - 1                    
                    lstEpFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnShowFilterDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnShowFilterDown.Click
            Try
                If lstShowFilters.Items.Count > 0 AndAlso Not IsNothing(lstShowFilters.SelectedItem) AndAlso lstShowFilters.SelectedIndex < (lstShowFilters.Items.Count - 1) Then
                    Dim iIndex As Integer = lstShowFilters.SelectedIndices(0)
                    lstShowFilters.Items.Insert(iIndex + 2, lstShowFilters.SelectedItems(0))
                    lstShowFilters.Items.RemoveAt(iIndex)
                    lstShowFilters.SelectedIndex = iIndex + 1                    
                    lstShowFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnShowFilterUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnShowFilterUp.Click
            Try
                If lstShowFilters.Items.Count > 0 AndAlso Not IsNothing(lstShowFilters.SelectedItem) AndAlso lstShowFilters.SelectedIndex > 0 Then
                    Dim iIndex As Integer = lstShowFilters.SelectedIndices(0)
                    lstShowFilters.Items.Insert(iIndex - 1, lstShowFilters.SelectedItems(0))
                    lstShowFilters.Items.RemoveAt(iIndex + 1)
                    lstShowFilters.SelectedIndex = iIndex - 1                    
                    lstShowFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub chkNoFilterEpisode_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkNoFilterEpisode.CheckedChanged
            chkEpProperCase.Enabled = Not chkNoFilterEpisode.Checked
            lstEpFilters.Enabled = Not chkNoFilterEpisode.Checked
            txtEpFilter.Enabled = Not chkNoFilterEpisode.Checked
            btnAddEpFilter.Enabled = Not chkNoFilterEpisode.Checked
            btnEpFilterUp.Enabled = Not chkNoFilterEpisode.Checked
            btnEpFilterDown.Enabled = Not chkNoFilterEpisode.Checked
            btnRemoveEpFilter.Enabled = Not chkNoFilterEpisode.Checked
        End Sub

        Protected Overrides Sub LoadSettings()
            chkShowProperCase.Checked = Master.eSettings.ShowProperCase
            chkEpProperCase.Checked = Master.eSettings.EpProperCase
            cbRatingRegion.Text = Master.eSettings.ShowRatingRegion
            chkShowPosterCol.Checked = Master.eSettings.ShowPosterCol
            chkShowFanartCol.Checked = Master.eSettings.ShowFanartCol
            chkShowNfoCol.Checked = Master.eSettings.ShowNfoCol
            chkSeasonPosterCol.Checked = Master.eSettings.SeasonPosterCol
            chkSeasonFanartCol.Checked = Master.eSettings.SeasonFanartCol
            chkEpisodePosterCol.Checked = Master.eSettings.EpisodePosterCol
            chkEpisodeFanartCol.Checked = Master.eSettings.EpisodeFanartCol
            chkEpisodeNfoCol.Checked = Master.eSettings.EpisodeNfoCol
            chkNoFilterEpisode.Checked = Master.eSettings.NoFilterEpisode
            chkDisplayMissingEpisodes.Checked = Master.eSettings.DisplayMissingEpisodes
            chkDisplayAllSeason.Checked = Master.eSettings.DisplayAllSeason
            chkMarkNewShows.Checked = Master.eSettings.MarkNewShows
            chkMarkNewEpisodes.Checked = Master.eSettings.MarkNewEpisodes
            RefreshShowFilters()
            RefreshEpFilters()
        End Sub

        Private Sub LoadRatingRegions()
            cbRatingRegion.Items.AddRange(APIXML.GetRatingRegions)
        End Sub

        Private Sub RefreshEpFilters()
            lstEpFilters.Items.Clear()
            lstEpFilters.Items.AddRange(Master.eSettings.EpFilterCustom.ToArray)
        End Sub

        Private Sub RefreshShowFilters()
            lstShowFilters.Items.Clear()
            lstShowFilters.Items.AddRange(Master.eSettings.ShowFilterCustom.ToArray)
        End Sub

        Private Sub RemoveEpFilter()
            If lstEpFilters.Items.Count > 0 AndAlso lstEpFilters.SelectedItems.Count > 0 Then
                While lstEpFilters.SelectedItems.Count > 0
                    lstEpFilters.Items.Remove(lstEpFilters.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
            End If
        End Sub

        Private Sub RemoveShowFilter()
            If lstShowFilters.Items.Count > 0 AndAlso lstShowFilters.SelectedItems.Count > 0 Then
                While lstShowFilters.SelectedItems.Count > 0
                    lstShowFilters.Items.Remove(lstShowFilters.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.ShowFilterCustom.Clear()
            Master.eSettings.ShowFilterCustom.AddRange(lstShowFilters.Items.OfType(Of String).ToList)
            If Master.eSettings.ShowFilterCustom.Count <= 0 Then Master.eSettings.NoShowFilters = True
            Master.eSettings.ShowProperCase = chkShowProperCase.Checked

            Master.eSettings.EpFilterCustom.Clear()
            Master.eSettings.EpFilterCustom.AddRange(lstEpFilters.Items.OfType(Of String).ToList)
            If Master.eSettings.EpFilterCustom.Count <= 0 Then Master.eSettings.NoEpFilters = True
            Master.eSettings.EpProperCase = chkEpProperCase.Checked

            If String.IsNullOrEmpty(cbRatingRegion.Text) Then
                Master.eSettings.ShowRatingRegion = "usa"
            Else
                Master.eSettings.ShowRatingRegion = cbRatingRegion.Text
            End If
            Master.eSettings.ShowPosterCol = chkShowPosterCol.Checked
            Master.eSettings.ShowFanartCol = chkShowFanartCol.Checked
            Master.eSettings.ShowNfoCol = chkShowNfoCol.Checked
            Master.eSettings.SeasonPosterCol = chkSeasonPosterCol.Checked
            Master.eSettings.SeasonFanartCol = chkSeasonFanartCol.Checked
            Master.eSettings.EpisodePosterCol = chkEpisodePosterCol.Checked
            Master.eSettings.EpisodeFanartCol = chkEpisodeFanartCol.Checked
            Master.eSettings.EpisodeNfoCol = chkEpisodeNfoCol.Checked
            Master.eSettings.NoFilterEpisode = chkNoFilterEpisode.Checked
            Master.eSettings.DisplayMissingEpisodes = chkDisplayMissingEpisodes.Checked
            Master.eSettings.DisplayAllSeason = chkDisplayAllSeason.Checked
            Master.eSettings.MarkNewShows = chkMarkNewShows.Checked
            Master.eSettings.MarkNewEpisodes = chkMarkNewEpisodes.Checked
        End Sub

        Private Sub lstEpFilters_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstEpFilters.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveEpFilter()
        End Sub

        Private Sub lstShowFilters_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstShowFilters.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveShowFilter()
        End Sub

        Private Sub btnRemoveEpFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveEpFilter.Click
            RemoveEpFilter()
        End Sub

        Private Sub btnResetShowFilters_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetShowFilters.Click
            If MsgBox(Master.eLang.GetString(840, "Are you sure you want to reset to the default list of show filters?"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                Master.eSettings.SetDefaultsForLists(Enums.DefaultType.ShowFilters, True)
                RefreshShowFilters()                
            End If
        End Sub

        Private Sub btnResetEpFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetEpFilter.Click
            If MsgBox(Master.eLang.GetString(841, "Are you sure you want to reset to the default list of episode filters?"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                Master.eSettings.SetDefaultsForLists(Enums.DefaultType.EpFilters, True)
                RefreshEpFilters()                
            End If
        End Sub

        Private Sub btnRemoveShowFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveShowFilter.Click
            RemoveShowFilter()
        End Sub

        Protected Overrides Sub LoadResources()
            gbShowFilter.Text = Master.eLang.GetString(670, "Show Folder/File Name Filters")
            gbEpFilter.Text = Master.eLang.GetString(671, "Episode Folder/File Name Filters")
            lblRatingRegion.Text = Master.eLang.GetString(679, "TV Rating Region")
            gbTVListOptions.Text = Master.eLang.GetString(460, "Media List Options")
            gbShowListOptions.Text = Master.eLang.GetString(680, "Shows")
            gbSeasonListOptions.Text = Master.eLang.GetString(681, "Seasons")
            gbEpisodeListOptions.Text = Master.eLang.GetString(682, "Episodes")
            chkDisplayMissingEpisodes.Text = Master.eLang.GetString(733, "Display Missing Episodes")
            chkNoFilterEpisode.Text = Master.eLang.GetString(734, "Build Episode Title Instead of Filtering")
            chkDisplayAllSeason.Text = Master.eLang.GetString(832, "Display All Season Poster")
            chkMarkNewShows.Text = Master.eLang.GetString(549, "Mark New Shows")
            chkMarkNewEpisodes.Text = Master.eLang.GetString(621, "Mark New Episodes")
            LoadRatingRegions()            
        End Sub
    End Class
End Namespace