Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class Movies
        Private Sub btnAddFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddFilter.Click
            If Not String.IsNullOrEmpty(txtFilter.Text) Then
                lstFilters.Items.Add(txtFilter.Text)
                txtFilter.Text = String.Empty
            End If
            txtFilter.Focus()
        End Sub

        Private Sub btnAddToken_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddToken.Click
            If Not String.IsNullOrEmpty(txtSortToken.Text) Then
                If Not lstSortTokens.Items.Contains(txtSortToken.Text) Then
                    lstSortTokens.Items.Add(txtSortToken.Text)                    
                    txtSortToken.Text = String.Empty
                    txtSortToken.Focus()
                End If
            End If
        End Sub

        Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnDown.Click
            Try
                If lstFilters.Items.Count > 0 AndAlso Not IsNothing(lstFilters.SelectedItem) AndAlso lstFilters.SelectedIndex < (lstFilters.Items.Count - 1) Then
                    Dim iIndex As Integer = lstFilters.SelectedIndices(0)
                    lstFilters.Items.Insert(iIndex + 2, lstFilters.SelectedItems(0))
                    lstFilters.Items.RemoveAt(iIndex)
                    lstFilters.SelectedIndex = iIndex + 1                    
                    lstFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUp.Click
            Try
                If lstFilters.Items.Count > 0 AndAlso Not IsNothing(lstFilters.SelectedItem) AndAlso lstFilters.SelectedIndex > 0 Then
                    Dim iIndex As Integer = lstFilters.SelectedIndices(0)
                    lstFilters.Items.Insert(iIndex - 1, lstFilters.SelectedItems(0))
                    lstFilters.Items.RemoveAt(iIndex + 1)
                    lstFilters.SelectedIndex = iIndex - 1                    
                    lstFilters.Focus()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub chkCheckTitles_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkCheckTitles.CheckedChanged
            txtCheckTitleTol.Enabled = chkCheckTitles.Checked
            If Not chkCheckTitles.Checked Then txtCheckTitleTol.Text = String.Empty
        End Sub

        Private Sub FillGenres()
            If Not String.IsNullOrEmpty(Master.eSettings.GenreFilter) Then
                Dim genreArray() As String = Master.eSettings.GenreFilter.Split({","c})
                For Each index In From g In genreArray Select index1 = lbGenre.FindString(g.Trim()) Where index1 <> -1
                    lbGenre.SetItemChecked(index, True)
                Next

                If lbGenre.CheckedItems.Count = 0 Then
                    lbGenre.SetItemChecked(0, True)
                End If
            Else
                lbGenre.SetItemChecked(0, True)
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            chkProperCase.Checked = Master.eSettings.ProperCase
            chkMoviePosterCol.Checked = Master.eSettings.MoviePosterCol
            chkMovieFanartCol.Checked = Master.eSettings.MovieFanartCol
            chkMovieInfoCol.Checked = Master.eSettings.MovieInfoCol
            chkMovieTrailerCol.Checked = Master.eSettings.MovieTrailerCol
            chkMovieSubCol.Checked = Master.eSettings.MovieSubCol
            chkMovieExtraCol.Checked = Master.eSettings.MovieExtraCol
            chkClickScrape.Checked = Master.eSettings.ClickScrape
            chkAskCheckboxScrape.Enabled = chkClickScrape.Checked
            chkAskCheckboxScrape.Checked = Master.eSettings.AskCheckboxScrape
            chkMarkNew.Checked = Master.eSettings.MarkNew
            chkDisplayYear.Checked = Master.eSettings.DisplayYear
            lstSortTokens.Items.AddRange(Master.eSettings.SortTokens.ToArray)
            If Master.eSettings.LevTolerance > 0 Then
                chkCheckTitles.Checked = True
                txtCheckTitleTol.Enabled = True
                txtCheckTitleTol.Text = Master.eSettings.LevTolerance.ToString
            End If
            chkMissingPoster.Checked = Master.eSettings.MissingFilterPoster
            chkMissingFanart.Checked = Master.eSettings.MissingFilterFanart
            chkMissingNFO.Checked = Master.eSettings.MissingFilterNFO
            chkMissingTrailer.Checked = Master.eSettings.MissingFilterTrailer
            chkMissingSubs.Checked = Master.eSettings.MissingFilterSubs
            chkMissingExtra.Checked = Master.eSettings.MissingFilterExtras
            FillGenres()
            RefreshMovieFilters()
        End Sub

        Private Sub lbGenre_ItemCheck(ByVal sender As Object, ByVal e As Windows.Forms.ItemCheckEventArgs) Handles lbGenre.ItemCheck
            If e.Index = 0 Then
                For i As Integer = 1 To lbGenre.Items.Count - 1
                    lbGenre.SetItemChecked(i, False)
                Next
            Else
                lbGenre.SetItemChecked(0, False)
            End If
        End Sub

        Private Sub LoadGenreLangs()
            lbGenre.Items.Add(Master.eLang.All)
            lbGenre.Items.AddRange(APIXML.GetGenreList(True))
        End Sub

        Private Sub RefreshMovieFilters()
            lstFilters.Items.Clear()
            lstFilters.Items.AddRange(Master.eSettings.FilterCustom.ToArray)
        End Sub

        Private Sub btnResetMovieFilters_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetMovieFilters.Click
            If MsgBox(Master.eLang.GetString(842, Languages.Are_you_sure_you_want_to_reset_to_the_default_list_of_movie_filters), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, Languages.Are_You_Sure)) = MsgBoxResult.Yes Then
                Master.eSettings.SetDefaultsForLists(Enums.DefaultType.MovieFilters, True)
                RefreshMovieFilters()                
            End If
        End Sub

        Private Sub RemoveFilter()
            If lstFilters.Items.Count > 0 AndAlso lstFilters.SelectedItems.Count > 0 Then
                While lstFilters.SelectedItems.Count > 0
                    lstFilters.Items.Remove(lstFilters.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
            End If
        End Sub

        Private Sub lstFilters_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstFilters.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveFilter()
        End Sub

        Private Sub RemoveSortToken()
            If lstSortTokens.Items.Count > 0 AndAlso lstSortTokens.SelectedItems.Count > 0 Then
                While lstSortTokens.SelectedItems.Count > 0
                    lstSortTokens.Items.Remove(lstSortTokens.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
            End If
        End Sub

        Private Sub btnRemoveFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveFilter.Click
            RemoveFilter()
        End Sub

        Private Sub btnRemoveToken_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveToken.Click
            RemoveSortToken()
        End Sub

        Private Sub lstSortTokens_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstSortTokens.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveSortToken()
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.FilterCustom.Clear()
            Master.eSettings.FilterCustom.AddRange(lstFilters.Items.OfType(Of String).ToList)
            If Master.eSettings.FilterCustom.Count <= 0 Then Master.eSettings.NoFilters = True
            Master.eSettings.ProperCase = chkProperCase.Checked
            Master.eSettings.MoviePosterCol = chkMoviePosterCol.Checked
            Master.eSettings.MovieFanartCol = chkMovieFanartCol.Checked
            Master.eSettings.MovieInfoCol = chkMovieInfoCol.Checked
            Master.eSettings.MovieTrailerCol = chkMovieTrailerCol.Checked
            Master.eSettings.MovieSubCol = chkMovieSubCol.Checked
            Master.eSettings.MovieExtraCol = chkMovieExtraCol.Checked
            Master.eSettings.ClickScrape = chkClickScrape.Checked
            Master.eSettings.AskCheckboxScrape = chkAskCheckboxScrape.Checked
            Master.eSettings.MarkNew = chkMarkNew.Checked
            If lbGenre.CheckedItems.Count > 0 Then
                If lbGenre.CheckedItems.Contains(String.Format("{0}", Master.eLang.GetString(569, Master.eLang.All))) Then
                    Master.eSettings.GenreFilter = String.Format("{0}", Master.eLang.GetString(569, Master.eLang.All))
                Else
                    Dim iChecked = From iCheck In lbGenre.CheckedItems
                    Dim strGenre As String = Strings.Join(iChecked.ToArray, ",").Trim()
                    Master.eSettings.GenreFilter = strGenre
                End If
            End If
            Master.eSettings.DisplayYear = chkDisplayYear.Checked
            Master.eSettings.SortTokens.Clear()
            Master.eSettings.SortTokens.AddRange(lstSortTokens.Items.OfType(Of String).ToList)
            If Master.eSettings.SortTokens.Count <= 0 Then Master.eSettings.NoTokens = True

            Master.eSettings.LevTolerance = txtCheckTitleTol.IntValue
            lbGenre.Items.Clear()
            LoadGenreLangs()
            FillGenres()
            Master.eSettings.MissingFilterPoster = chkMissingPoster.Checked
            Master.eSettings.MissingFilterFanart = chkMissingFanart.Checked
            Master.eSettings.MissingFilterNFO = chkMissingNFO.Checked
            Master.eSettings.MissingFilterTrailer = chkMissingTrailer.Checked
            Master.eSettings.MissingFilterSubs = chkMissingSubs.Checked
            Master.eSettings.MissingFilterExtras = chkMissingExtra.Checked
        End Sub

        Protected Overrides Sub LoadResources()
            gbFilters.Text = Languages.Folder_File_Name_Filters
            chkProperCase.Text = Languages.Convert_Names_to_Proper_Case
            gbGenreFilter.Text = Languages.Genre_Language_Filter
            chkMarkNew.Text = Languages.Mark_New_Movies
            gbMediaList.Text = Languages.Media_List_Options
            lblMismatchTolerance.Text = Languages.Mismatch_Tolerance
            chkCheckTitles.Text = Languages.Check_Title_Match_Confidence
            GroupBox25.Text = Languages.Sort_Tokens_to_Ignore
            chkDisplayYear.Text = Languages.Display_Year_in_List_Title
            chkMovieExtraCol.Text = Languages.Hide_Extrathumb_Column
            chkMovieSubCol.Text = Languages.Hide_Sub_Column
            chkMovieTrailerCol.Text = Languages.Hide_Trailer_Column
            chkMovieInfoCol.Text = Languages.Hide_Info_Column
            chkMovieFanartCol.Text = Languages.Hide_Fanart_Column
            chkMoviePosterCol.Text = Languages.Hide_Poster_Column
            gbMissingItems.Text = Languages.Missing_Items_Filter
            chkMissingPoster.Text = Languages.Check_for_Poster
            chkMissingFanart.Text = Languages.Check_for_Fanart
            chkMissingNFO.Text = Languages.Check_for_NFO
            chkMissingTrailer.Text = Languages.Check_for_Trailer
            chkMissingSubs.Text = Languages.Check_for_Subs
            chkMissingExtra.Text = Languages.Check_for_Extrathumbs
            chkClickScrape.Text = Languages.Enable_Click_Scrape
            chkAskCheckboxScrape.Text = Languages.Ask_On_Click_Scrape
            LoadGenreLangs()            
        End Sub
    End Class
End Namespace
