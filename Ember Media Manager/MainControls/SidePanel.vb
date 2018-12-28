Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports BrightIdeasSoftware
Imports EmberMediaManger.Classes
Imports EmberMediaManger.API
Imports System.Data.Objects
Imports System.IO
Imports EmberMediaManger.Scrapers.Movies
Imports Database = EmberMediaManger.Classes.Database

Public Class SidePanel
    Public Event MediaItemSelected As EventHandler(Of MediaSelectedArgs)

    Public Class MediaSelectedArgs
        Inherits EventArgs

        ReadOnly _selectedMedia As Object
        ReadOnly _statusText As String

        Public Sub New(selectedMedia As Object, statusText As String)
            _selectedMedia = selectedMedia
            _statusText = statusText
        End Sub

        Public ReadOnly Property SelectedMedia As Object
            Get
                Return _selectedMedia
            End Get
        End Property

        Public ReadOnly Property StatusText As String
            Get
                Return _statusText
            End Get
        End Property
    End Class

    Private Sub SetTVCount()
        Dim ShowCount As Integer = Database.GetTVShowCount()
        Dim EpCount As Integer = Database.GetTVEpsCount()

        If ShowCount > 0 Then
            tabTV.Text = String.Format("{0} ({1}/{2})", Languages.TV, ShowCount, EpCount)
        Else
            tabTV.Text = Languages.TV
        End If
    End Sub

    Public Sub PopulateMovies()        
        lvMedia.ModelFilter = Nothing
        lvMedia.RemoveObjects(DirectCast(lvMedia.Objects, ICollection))
        lvMedia.AddObjects(Database.LoadAllMovies())
        olvcPoster.IsVisible = Not Master.eSettings.MoviePosterCol
        olvcFanart.IsVisible = Not Master.eSettings.MovieFanartCol
        olvcNFO.IsVisible = Not Master.eSettings.MovieInfoCol
        olvcTrailer.IsVisible = Not Master.eSettings.MovieTrailerCol
        olvcSub.IsVisible = Not Master.eSettings.MovieSubCol
        olvcExtra.IsVisible = Not Master.eSettings.MovieExtraCol
        olvcTrailer.AspectName = "HasTrailer"
        olvcSub.AspectName = "HasSub"
        olvcExtra.AspectName = "HasExtra"
        lvMedia.RebuildColumns()
    End Sub

    Private Function CanExpand(x As Object) As Boolean
        Select Case ObjectContext.GetObjectType(x.GetType())
            Case GetType(Model.TVShow), GetType(Model.TVSeason)
                Return True
        End Select
        Return False
    End Function

    Private Function SetTitle(x As Object) As Object        
        Select Case ObjectContext.GetObjectType(x.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(x, Model.Movie)
                Return currentMovie.ListTitle
            Case GetType(Model.TVShow)
                Dim currentTVShow As Model.TVShow = DirectCast(x, Model.TVShow)
                Return currentTVShow.Title
            Case GetType(Model.TVSeason)
                Dim currentTVSeason = DirectCast(x, Model.TVSeason)
                Return currentTVSeason.SeasonText
            Case GetType(Model.TVEp)
                Dim currentTVEp = DirectCast(x, Model.TVEp)
                Return String.Format("{0} - {1}", currentTVEp.Episode, currentTVEp.Title)
        End Select
        Return ""
    End Function

    Private Function SetNFO(x As Object) As Object
        Select Case ObjectContext.GetObjectType(x.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(x, Model.Movie)
                Return currentMovie.HasNfo
            Case GetType(Model.TVShow)
                Dim currentTVShow As Model.TVShow = DirectCast(x, Model.TVShow)
                Return currentTVShow.HasNfo
            Case GetType(Model.TVEp)
                Dim currentTVEp = DirectCast(x, Model.TVEp)
                Return currentTVEp.HasNfo
        End Select
        Return False
    End Function

    Public Sub PopulateTV()        
        lvMedia.ModelFilter = Nothing
        lvMedia.RemoveObjects(DirectCast(lvMedia.Objects, ICollection))
        lvMedia.AddObjects(Database.LoadAllTVShows())

        olvcPoster.IsVisible = Not Master.eSettings.ShowPosterCol
        olvcFanart.IsVisible = Not Master.eSettings.ShowFanartCol
        olvcNFO.IsVisible = Not Master.eSettings.ShowNfoCol
        olvcTrailer.IsVisible = False
        olvcSub.IsVisible = False
        olvcExtra.IsVisible = False

        olvcExtra.AspectName = ""
        olvcSub.AspectName = ""
        olvcTrailer.AspectName = ""

        '            .dgvTVSeasons.Columns(3).Visible = Not Master.eSettings.SeasonPosterCol
        '            .dgvTVSeasons.Columns(4).Visible = Not Master.eSettings.SeasonFanartCol
        '            .dgvTVEpisodes.Columns(4).Visible = Not Master.eSettings.EpisodePosterCol
        '            .dgvTVEpisodes.Columns(5).Visible = Not Master.eSettings.EpisodeFanartCol
        '            .dgvTVEpisodes.Columns(6).Visible = Not Master.eSettings.EpisodeNfoCol
        lvMedia.RebuildColumns()        
    End Sub

    Private Function PopulateChildren(x As Object) As IEnumerable
        Select Case ObjectContext.GetObjectType(x.GetType())
            Case GetType(Model.TVShow)
                Dim tempTVShow As Model.TVShow = DirectCast(x, Model.TVShow)
                Return Database.LoadTVShowSeasons(tempTVShow.ID)
            Case GetType(Model.TVSeason)
                Dim tempTVSeason As Model.TVSeason = DirectCast(x, Model.TVSeason)
                Return Database.LoadTVShowEpisodes(tempTVSeason.TVShowID, tempTVSeason.Season)
        End Select
        Return Nothing
    End Function
    'Private Sub FillList(ByVal iIndex As Integer)
    '    Try            
    '        'If Not String.IsNullOrEmpty(Me.filSearch) AndAlso Me.cbSearch.Text = Master.eLang.GetString(100, "Actor") Then
    '        '    Master.DB.FillDataTable(Me.dtMedia, String.Concat("SELECT * FROM movies WHERE ID IN (SELECT MovieID FROM MoviesActors WHERE ActorName LIKE '%", Me.filSearch, "%') ORDER BY ListTitle COLLATE NOCASE;"))
    '        'Else
    '        '    If Me.chkFilterDupe.Checked Then
    '        '        Master.DB.FillDataTable(Me.dtMedia, "SELECT * FROM movies WHERE imdb IN (SELECT imdb FROM movies WHERE imdb IS NOT NULL AND LENGTH(imdb) > 0 GROUP BY imdb HAVING ( COUNT(imdb) > 1 )) ORDER BY ListTitle COLLATE NOCASE;")
    '        '    Else
    '        '        Master.DB.FillDataTable(Me.dtMedia, "SELECT * FROM movies ORDER BY ListTitle COLLATE NOCASE;")
    '        '    End If
    '        'End If



    '    If Not isCL Then
    '        Me.tsbRefreshMedia.Enabled = True
    '        Me.cmnuTrayIconExit.Enabled = True
    '        Me.cmnuTrayIconSettings.Enabled = True
    '        Me.EditToolStripMenuItem.Enabled = True
    '        Me.cmnuTrayIconUpdateMedia.Enabled = True
    '        Me.HelpToolStripMenuItem.Enabled = True
    '        Me.tslLoading.Visible = False
    '        Me.tspbLoading.Visible = False
    '        Me.tspbLoading.Value = 0
    '        Me.tabsMain.Enabled = True
    '        Me.DoTitleCheck()
    '        Me.EnableFilters(True)
    '        Me.SetTVCount()
    '    End If
    'End Sub

    Private Sub SidePanel_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        olvcTitle.Text = Languages.Title
        olvcTitle.ToolTipText = Languages.Title
        olvcPoster.IsVisible = Not Master.eSettings.MoviePosterCol
        olvcPoster.ToolTipText = Languages.Poster
        olvcFanart.IsVisible = Not Master.eSettings.MovieFanartCol
        olvcFanart.ToolTipText = Languages.Fanart
        olvcNFO.IsVisible = Not Master.eSettings.MovieInfoCol
        olvcNFO.ToolTipText = Languages.Nfo
        olvcTrailer.IsVisible = Not Master.eSettings.MovieTrailerCol
        olvcTrailer.ToolTipText = Languages.Trailer
        olvcSub.IsVisible = Not Master.eSettings.MovieSubCol
        olvcSub.ToolTipText = Languages.Subtitles
        olvcExtra.IsVisible = Not Master.eSettings.MovieExtraCol
        olvcExtra.ToolTipText = Languages.Extrathumbs

        tabMovies.Text = Languages.Movies
        tabTV.Text = Languages.TV_Shows

        TrueFalseImageRenderer.Add(True, My.Resources.Modules.small_icon_Tick)
        TrueFalseImageRenderer.Add(False, My.Resources.Modules.small_icon_Bullet)
        olvcTitle.AspectGetter = AddressOf SetTitle
        olvcNFO.AspectGetter = AddressOf SetNFO
        Dim tvTreeRenderer As New TreeListView.TreeRenderer
        tvTreeRenderer.IsShowLines = False
        lvMedia.TreeColumnRenderer = tvTreeRenderer
        lvMedia.ChildrenGetter = AddressOf PopulateChildren
        lvMedia.CanExpandGetter = AddressOf CanExpand
        cbSearch.Items.Clear()        
        cbSearch.Items.AddRange(New Object() {Languages.Title, Languages.Actor, Languages.Director})
        cbSearch.SelectedIndex = 0
        xppFilters.Expand = False
        SetTVCount()
    End Sub

    Private Sub cbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbSearch.SelectedIndexChanged
        txtSearch.Text = String.Empty
    End Sub

    Private Sub tabsMain_SelectedIndexChanged(sender As System.Object, e As EventArgs) Handles tabsMain.SelectedIndexChanged
        If tabsMain.SelectedIndex = 0 Then
            PopulateMovies()
        ElseIf tabsMain.SelectedIndex = 1 Then
            PopulateTV()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As EventArgs) Handles btnSearch.Click
        Dim searchFilter As New MovieFilter
        searchFilter.FilterText = txtSearch.Text
        searchFilter.FilterType = DirectCast([Enum].Parse(GetType(MovieFilter.FilterTypeEnum), cbSearch.SelectedIndex.ToString), MovieFilter.FilterTypeEnum)
        lvMedia.ModelFilter = searchFilter
    End Sub

    Private Sub SelectFanartAskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFanartAskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Fanart, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectFanartAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFanartAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Fanart, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    Private Sub SelectExtraAskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectExtraAskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Extra, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectExtraAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectExtraAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Extra, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub


    Private Sub SelectMeEtaAskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectMeEtaAskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Meta, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectMetaAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectMetaAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Meta, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    Private Sub SelectNfoAskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNfoAskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.NFO, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectNfoAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNfoAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.NFO, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    Private Sub SelectPosterAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectPosterAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Poster, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    Private Sub SelectPosterÃskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectPosterÃskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Poster, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectTrailerAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectTrailerAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.Trailer, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    Private Sub SelectAllAskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllAskToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.All, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    End Sub

    Private Sub SelectAllAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllAutoToolStripMenuItem.Click
        Functions.SetScraperMod(Enums.ModType.All, True)
        'MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    End Sub

    


    Private Sub RemoveFromDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFromDatabaseToolStripMenuItem.Click
        'Try
        '    Me.ClearInfo()

        '    For Each sRow As DataGridViewRow In Me.dgvMediaList.SelectedRows
        '        Master.DB.DeleteFromDB(Convert.ToInt64(sRow.Cells(0).Value))
        '    Next

        '    Me.FillList(0)

        'Catch ex As Exception
        '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        'End Try
    End Sub

    Private Sub OpenContainingFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenContainingFolderToolStripMenuItem.Click, cmnuShowOpenFolder.Click, cmnuSeasonOpenFolder.Click, cmnuEpOpenFolder.Click
        If lvMedia.SelectedItems.Count > 0 Then
            Dim doOpen As Boolean = True
            If lvMedia.SelectedItems.Count > 10 Then
                If Not MsgBox(String.Format(Languages.You_have_selected_folders_to_open__Are_you_sure_you_want_to_do_this, lvMedia.SelectedItems.Count), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, Languages.Are_You_Sure) = MsgBoxResult.Yes Then doOpen = False
            End If

            If doOpen Then
                For Each sRow As OLVListItem In lvMedia.SelectedItems
                    Dim mediaPath As String = String.Empty
                    Select Case ObjectContext.GetObjectType(sRow.RowObject.GetType())
                        Case GetType(Model.Movie)
                            mediaPath = DirectCast(sRow.RowObject, Model.Movie).MoviePath
                        Case GetType(Model.TVEp)
                            mediaPath = DirectCast(sRow.RowObject, Model.TVEp).TVEpPath.FilePath
                        Case GetType(Model.TVShow)
                            mediaPath = DirectCast(sRow.RowObject, Model.TVShow).TVShowPath
                        Case GetType(Model.TVSeason)
                            Dim currentTVSeason = DirectCast(sRow.RowObject, Model.TVSeason)
                            mediaPath = Functions.GetSeasonDirectoryFromShowPath(currentTVSeason.TVShow.TVShowPath, currentTVSeason.Season)
                    End Select

                    Using Explorer As New Process
                        If Master.isWindows Then
                            Explorer.StartInfo.FileName = "explorer.exe"
                            Explorer.StartInfo.Arguments = String.Format("/select,""{0}""", mediaPath)
                        Else
                            Explorer.StartInfo.FileName = "xdg-open"
                            Explorer.StartInfo.Arguments = String.Format("""{0}""", Path.GetDirectoryName(mediaPath))
                        End If
                        Explorer.Start()
                    End Using
                Next
            End If
        End If
    End Sub

    '    Private Sub dgvMediaList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        Try
    '           
    '            ElseIf Master.eSettings.ClickScrape AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex <> 8 AndAlso Not bwMovieScraper.IsBusy Then
    '                Dim movie As Int32 = CType(Me.dgvMediaList.Rows(e.RowIndex).Cells(0).Value, Int32)
    '                Dim objCell As DataGridViewCell = CType(Me.dgvMediaList.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewCell)

    '                'EMM not able to scrape subtitles yet.
    '                'So don't set status for it, but leave the option open for the future.
    '                Me.dgvMediaList.ClearSelection()
    '                Me.dgvMediaList.Rows(objCell.RowIndex).Selected = True
    '                Me.currRow = objCell.RowIndex
    '                Select Case e.ColumnIndex
    '                    Case 4 'Poster
    '                        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '                    Case 5 'Fanart
    '                        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '                    Case 6 'Nfo
    '                        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '                    Case 7 'Trailer
    '                        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '                    Case 8 'Subtitles
    '                        'Functions.SetScraperMod(Enums.ModType.Subtitles, True)
    '                    Case 9 'Extrathumbs
    '                        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '                    Case 10 'Metadata - need to add this column to the view.
    '                        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '                End Select
    '                If Master.eSettings.AskCheckboxScrape Then
    '                    MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '                Else
    '                    MovieScrapeData(True, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '                End If
    '            End If
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub dgvMediaList_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        'EMM not able to scrape subtitles yet.
    '        'So don't set status for it, but leave the option open for the future.
    '        If Master.eSettings.ClickScrape AndAlso e.RowIndex > 0 AndAlso e.ColumnIndex > 3 AndAlso e.ColumnIndex < 11 AndAlso e.ColumnIndex <> 8 AndAlso Not bwMovieScraper.IsBusy Then
    '            oldStatus = GetStatus()
    '            Dim movieName As String = Me.dgvMediaList.Rows(e.RowIndex).Cells(15).Value.ToString
    '            Dim scrapeFor As String = ""
    '            Dim scrapeType As String = ""
    '            Select Case e.ColumnIndex
    '                Case 4
    '                    scrapeFor = Master.eLang.GetString(72, "Poster Only")
    '                Case 5
    '                    scrapeFor = Master.eLang.GetString(73, "Fanart Only")
    '                Case 6
    '                    scrapeFor = Master.eLang.GetString(71, "NFO Only")
    '                Case 7
    '                    scrapeFor = Master.eLang.GetString(75, "Trailer Only")
    '                Case 8
    '                    'scrapeFor = Master.eLang.GetString(00, "Subtitles")
    '                Case 9
    '                    scrapeFor = Master.eLang.GetString(74, "Extrathumbs Only")
    '                Case 10
    '                    scrapeFor = Master.eLang.GetString(76, "Meta Data Only")
    '            End Select
    '            If Master.eSettings.AskCheckboxScrape Then
    '                scrapeType = Master.eLang.GetString(77, "Ask (Require Input If No Exact Match)")
    '            Else
    '                scrapeType = Master.eLang.GetString(69, "Automatic (Force Best Match)")
    '            End If
    '            Me.SetStatus(String.Format("Scrape ""{0}"" for {1} - {2}", movieName, scrapeFor, scrapeType))
    '        Else
    '            oldStatus = String.Empty
    '        End If
    '    End Sub

    '    Private Sub dgvMediaList_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        If Not String.IsNullOrEmpty(oldStatus) Then Me.SetStatus(oldStatus)
    '    End Sub

  
   
    '    Private Sub cmnuRemoveTVEp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRemoveTVEp.Click
    '        Me.ClearInfo(False)

    '        Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '            For Each sRow As DataGridViewRow In Me.dgvTVEpisodes.SelectedRows
    '                Master.DB.DeleteTVEpFromDB(Convert.ToInt32(sRow.Cells(0).Value), True, False, True)
    '            Next

    '            Master.DB.CleanSeasons(True)

    '            SQLTrans.Commit()
    '        End Using

    '        Dim cSeas As Integer = 0

    '        If Not Me.currSeasonRow = -1 Then
    '            cSeas = Me.currSeasonRow
    '        End If

    '        Me.FillEpisodes(Convert.ToInt32(Me.dgvTVSeasons.Item(0, cSeas).Value), Convert.ToInt32(Me.dgvTVSeasons.Item(2, cSeas).Value))

    '        Me.SetTVCount()
    '    End Sub

    '    Private Sub cmnuRemoveTVShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRemoveTVShow.Click
    '        Me.ClearInfo()

    '        Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '            For Each sRow As DataGridViewRow In Me.dgvTVShows.SelectedRows
    '                Master.DB.DeleteTVShowFromDB(Convert.ToInt32(sRow.Cells(0).Value), True)
    '            Next
    '            SQLTrans.Commit()
    '        End Using

    '        Me.FillList(0)
    '    End Sub

    '    Private Sub cmnuRescrapeEp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRescrapeEp.Click
    '        Me.SetControlsEnabled(False, True)
    '        ModulesManager.Instance.TVScrapeEpisode(Convert.ToInt32(Me.dgvTVEpisodes.Item(1, Me.dgvTVEpisodes.SelectedRows(0).Index).Value), Me.tmpTitle, Me.tmpTVDB, Convert.ToInt32(Me.dgvTVEpisodes.Item(2, Me.dgvTVEpisodes.SelectedRows(0).Index).Value), Convert.ToInt32(Me.dgvTVEpisodes.Item(12, Me.dgvTVEpisodes.SelectedRows(0).Index).Value), Me.tmpLang, Me.tmpOrdering, Master.DefaultTVOptions)
    '    End Sub

    '    Private Sub cmnuRescrapeShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRescrapeShow.Click
    '        Me.SetControlsEnabled(False, True)
    '        TVShowScrapeData()
    '    End Sub

    '    Sub TVShowScrapeData()
    '        Me.SetControlsEnabled(False)
    '        For Each s As DataGridViewRow In Me.dgvTVShows.SelectedRows
    '            ' Temporary Scratetype
    '            Dim ScrapeType As Enums.ScrapeType
    '            'If Me.dgvTVShows.SelectedRows.Count = 1 Then
    '            'ScrapeType = Enums.ScrapeType.FullAsk
    '            'Else
    '            'ScrapeType = Enums.ScrapeType.FullAuto
    '            'End If
    '            ScrapeType = Enums.ScrapeType.FullAsk
    '            Dim Lang As String = Me.dgvTVShows.Item(22, s.Index).Value.ToString
    '            ModulesManager.Instance.TVScrapeOnly(Convert.ToInt32(Me.dgvTVShows.Item(0, s.Index).Value), Me.dgvTVShows.Item(1, s.Index).Value.ToString, Me.dgvTVShows.Item(9, s.Index).Value.ToString, If(String.IsNullOrEmpty(Lang), Master.eSettings.TVDBLanguage, Lang), DirectCast(Convert.ToInt32(Me.dgvTVShows.Item(23, s.Index).Value), Enums.Ordering), Master.DefaultTVOptions, ScrapeType, True)
    '        Next
    '        Me.SetControlsEnabled(True)
    '    End Sub


    '    Private Sub cmnuRescrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRescrape.Click
    '        If Me.dgvMediaList.SelectedRows.Count = 1 Then
    '            Functions.SetScraperMod(Enums.ModType.All, True, True)
    '            Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions)
    '        End If
    '    End Sub

    '    Private Sub cmnuSearchNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuSearchNew.Click
    '        If Me.dgvMediaList.SelectedRows.Count > 1 Then Return
    '        Functions.SetScraperMod(Enums.ModType.DoSearch, True)
    '        Functions.SetScraperMod(Enums.ModType.All, True, False)
    '        Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions)
    '    End Sub

    '    Private Sub cmnuSeasonChangeImages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuSeasonChangeImages.Click
    '        Me.SetControlsEnabled(False)
    '        Using dEditSeason As New dlgEditSeason
    '            If dEditSeason.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                If Me.RefreshSeason(Convert.ToInt32(Master.currShow.ShowID), Master.currShow.TVEp.Season, False) Then
    '                    Me.FillSeasons(Convert.ToInt32(Master.currShow.ShowID))
    '                End If
    '            End If
    '        End Using
    '        Me.SetControlsEnabled(True)
    '    End Sub


    '    Private Sub cmnuSeasonRescrape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuSeasonRescrape.Click
    '        Me.SetControlsEnabled(False, True)
    '        ModulesManager.Instance.TVScrapeSeason(Convert.ToInt32(Me.dgvTVSeasons.Item(0, Me.dgvTVSeasons.SelectedRows(0).Index).Value), Me.tmpTitle, Me.tmpTVDB, Convert.ToInt32(Me.dgvTVSeasons.Item(2, Me.dgvTVSeasons.SelectedRows(0).Index).Value), Me.tmpLang, Me.tmpOrdering, Master.DefaultTVOptions)
    '    End Sub

 
    '    Private Sub cmnuMetaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuMetaData.Click
    '        If Me.dgvMediaList.SelectedRows.Count > 1 Then Return
    '        Dim indX As Integer = Me.dgvMediaList.SelectedRows(0).Index
    '        Dim ID As Integer = Convert.ToInt32(Me.dgvMediaList.Item(0, indX).Value)
    '        Using dEditMeta As New dlgFileInfo
    '            Select Case dEditMeta.ShowDialog(False)
    '                Case Windows.Forms.DialogResult.OK
    '                    Me.SetListItemAfterEdit(ID, indX)
    '                    If Me.RefreshMovie(ID) Then
    '                        Me.FillList(0)
    '                    End If
    '            End Select
    '        End Using
    '    End Sub

    '    Private Sub cmnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRefresh.Click
    '        ReloadMovie()
    '    End Sub

    '    Private Sub cmnuReloadEp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuReloadEp.Click
    '        Try
    '            Me.dgvTVShows.Cursor = Cursors.WaitCursor
    '            Me.dgvTVSeasons.Cursor = Cursors.WaitCursor
    '            Me.dgvTVEpisodes.Cursor = Cursors.WaitCursor
    '            Me.SetControlsEnabled(False, True)

    '            Dim doFill As Boolean = False
    '            Dim tFill As Boolean = False

    '            Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '                For Each sRow As DataGridViewRow In Me.dgvTVEpisodes.SelectedRows
    '                    tFill = Me.RefreshEpisode(Convert.ToInt64(sRow.Cells(0).Value), True)
    '                    If tFill Then doFill = True
    '                Next

    '                Master.DB.CleanSeasons(True)

    '                SQLtransaction.Commit()
    '            End Using

    '            Me.dgvTVShows.Cursor = Cursors.Default
    '            Me.dgvTVSeasons.Cursor = Cursors.Default
    '            Me.dgvTVEpisodes.Cursor = Cursors.Default
    '            Me.SetControlsEnabled(True)

    '            If doFill Then FillEpisodes(Convert.ToInt32(Me.dgvTVEpisodes.SelectedRows(0).Cells(0).Value), Convert.ToInt32(Me.dgvTVEpisodes.SelectedRows(0).Cells(12).Value))
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub cmnuReloadSeason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuReloadSeason.Click
    '        Me.dgvTVShows.Cursor = Cursors.WaitCursor
    '        Me.dgvTVSeasons.Cursor = Cursors.WaitCursor
    '        Me.dgvTVEpisodes.Cursor = Cursors.WaitCursor
    '        Me.SetControlsEnabled(False, True)

    '        Dim doFill As Boolean = False
    '        Dim tFill As Boolean = False

    '        If Me.dgvTVSeasons.SelectedRows.Count > 0 Then
    '            Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '                For Each sRow As DataGridViewRow In Me.dgvTVSeasons.SelectedRows

    '                    doFill = Me.RefreshSeason(Convert.ToInt32(sRow.Cells(0).Value), Convert.ToInt32(sRow.Cells(2).Value), True)

    '                    Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                        SQLCommand.CommandText = String.Concat("SELECT ID FROM TVEps WHERE TVShowID = ", sRow.Cells(0).Value, " AND Season = ", sRow.Cells(2).Value, " AND Missing = 0;")
    '                        Using SQLReader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader
    '                            While SQLReader.Read
    '                                tFill = Me.RefreshEpisode(Convert.ToInt64(SQLReader("ID")), True)
    '                                If tFill Then doFill = True
    '                            End While
    '                        End Using
    '                    End Using
    '                Next

    '                Master.DB.CleanSeasons(True)

    '                SQLTrans.Commit()
    '            End Using
    '        End If

    '        Me.dgvTVShows.Cursor = Cursors.Default
    '        Me.dgvTVSeasons.Cursor = Cursors.Default
    '        Me.dgvTVEpisodes.Cursor = Cursors.Default
    '        Me.SetControlsEnabled(True)

    '        If doFill Then Me.FillSeasons(Convert.ToInt32(Me.dgvTVSeasons.SelectedRows(0).Cells(0).Value))
    '    End Sub

    '    Private Sub cmnuReloadShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuReloadShow.Click
    '        Try
    '            Me.dgvTVShows.Cursor = Cursors.WaitCursor
    '            Me.dgvTVSeasons.Cursor = Cursors.WaitCursor
    '            Me.dgvTVEpisodes.Cursor = Cursors.WaitCursor
    '            Me.SetControlsEnabled(False, True)

    '            Dim doFill As Boolean = False
    '            Dim tFill As Boolean = False

    '            If Me.dgvTVShows.SelectedRows.Count > 1 Then
    '                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '                    For Each sRow As DataGridViewRow In Me.dgvTVShows.SelectedRows
    '                        tFill = Me.RefreshShow(Convert.ToInt64(sRow.Cells(0).Value), True, True, False, True)
    '                        If tFill Then doFill = True
    '                    Next
    '                    SQLtransaction.Commit()
    '                End Using
    '            ElseIf Me.dgvTVShows.SelectedRows.Count = 1 Then
    '                'seperate single refresh so we can have a progress bar
    '                tFill = Me.RefreshShow(Convert.ToInt64(Me.dgvTVShows.SelectedRows(0).Cells(0).Value), False, True, False, True)
    '                If tFill Then doFill = True
    '            End If

    '            Me.dgvTVShows.Cursor = Cursors.Default
    '            Me.dgvTVSeasons.Cursor = Cursors.Default
    '            Me.dgvTVEpisodes.Cursor = Cursors.Default
    '            Me.SetControlsEnabled(True)

    '            If doFill Then FillList(0)
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub cmnuRemoveSeasonFromDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuRemoveSeasonFromDB.Click
    '        Me.ClearInfo(False)

    '        Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '            For Each sRow As DataGridViewRow In Me.dgvTVSeasons.SelectedRows
    '                Master.DB.DeleteTVSeasonFromDB(Convert.ToInt32(sRow.Cells(0).Value), Convert.ToInt32(sRow.Cells(2).Value), True)
    '            Next
    '            SQLTrans.Commit()
    '        End Using

    '        Me.FillSeasons(Convert.ToInt32(Me.dgvTVSeasons.SelectedRows(0).Cells(0).Value))

    '        Me.SetTVCount()
    '    End Sub

  
    '    Private Sub cmnuChangeEp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuChangeEp.Click
    '        Me.SetControlsEnabled(False, True)
    '        Dim tEpisode As MediaContainers.EpisodeDetails = ModulesManager.Instance.ChangeEpisode(Convert.ToInt32(Master.currShow.ShowID), Me.tmpTVDB, Me.tmpLang)

    '        If Not IsNothing(tEpisode) Then
    '            Master.currShow.TVEp = tEpisode
    '            Master.currShow.EpPosterPath = tEpisode.Poster.SaveAsEpPoster(Master.currShow)

    '            Master.DB.SaveTVEpToDB(Master.currShow, False, True, False, True)

    '            Me.FillEpisodes(Convert.ToInt32(Master.currShow.ShowID), Convert.ToInt32(Me.dgvTVSeasons.SelectedRows(0).Cells(2).Value))
    '        End If

    '        Me.SetControlsEnabled(True)
    '    End Sub

    '    Private Sub cmnuChangeShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuChangeShow.Click
    '        Me.SetControlsEnabled(False, True)
    '        Dim Lang As String = Me.dgvTVShows.Item(22, Me.dgvTVShows.SelectedRows(0).Index).Value.ToString
    '        ModulesManager.Instance.TVScrapeOnly(Convert.ToInt32(Me.dgvTVShows.Item(0, Me.dgvTVShows.SelectedRows(0).Index).Value), Me.dgvTVShows.Item(1, Me.dgvTVShows.SelectedRows(0).Index).Value.ToString, String.Empty, If(String.IsNullOrEmpty(Lang), Master.eSettings.TVDBLanguage, Lang), DirectCast(Convert.ToInt32(Me.dgvTVShows.Item(23, Me.dgvTVShows.SelectedRows(0).Index).Value), Enums.Ordering), Master.DefaultTVOptions, Enums.ScrapeType.FullAsk, False)
    '    End Sub

    '    Private Sub cmnuDeleteSeason_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuDeleteSeason.Click
    '        Try

    '            Dim SeasonsToDelete As New Dictionary(Of Long, Long)
    '            Dim ShowId As Long = -1
    '            Dim SeasonNum As Integer = -1

    '            For Each sRow As DataGridViewRow In Me.dgvTVSeasons.SelectedRows
    '                ShowId = Convert.ToInt64(sRow.Cells(0).Value)
    '                SeasonNum = Convert.ToInt32(sRow.Cells(2).Value)
    '                'seasonnum first... showid can't be key or else only one season will be deleted
    '                If Not SeasonsToDelete.ContainsKey(SeasonNum) Then
    '                    SeasonsToDelete.Add(SeasonNum, ShowId)
    '                End If
    '            Next

    '            If SeasonsToDelete.Count > 0 Then
    '                Using dlg As New dlgDeleteConfirm
    '                    If dlg.ShowDialog(SeasonsToDelete, Enums.DelType.Seasons) = Windows.Forms.DialogResult.OK Then
    '                        Me.FillSeasons(Convert.ToInt32(Me.dgvTVSeasons.Item(0, Me.currSeasonRow).Value))
    '                        Me.SetTVCount()
    '                    End If
    '                End Using
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub cmnuDeleteTVEp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuDeleteTVEp.Click
    '        Try

    '            Dim EpsToDelete As New Dictionary(Of Long, Long)
    '            Dim EpId As Long = -1

    '            For Each sRow As DataGridViewRow In Me.dgvTVEpisodes.SelectedRows
    '                EpId = Convert.ToInt64(sRow.Cells(0).Value)
    '                If Not EpsToDelete.ContainsKey(EpId) Then
    '                    EpsToDelete.Add(EpId, 0)
    '                End If
    '            Next

    '            If EpsToDelete.Count > 0 Then
    '                Using dlg As New dlgDeleteConfirm
    '                    If dlg.ShowDialog(EpsToDelete, Enums.DelType.Episodes) = Windows.Forms.DialogResult.OK Then
    '                        Me.FillEpisodes(Convert.ToInt32(Me.dgvTVSeasons.Item(0, Me.currSeasonRow).Value), Convert.ToInt32(Me.dgvTVSeasons.Item(2, Me.currSeasonRow).Value))
    '                        Me.SetTVCount()
    '                    End If
    '                End Using
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '    End Sub

    '    Private Sub cmnuDeleteTVShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuDeleteTVShow.Click
    '        Try

    '            Dim ShowsToDelete As New Dictionary(Of Long, Long)
    '            Dim ShowId As Long = -1

    '            For Each sRow As DataGridViewRow In Me.dgvTVShows.SelectedRows
    '                ShowId = Convert.ToInt64(sRow.Cells(0).Value)
    '                If Not ShowsToDelete.ContainsKey(ShowId) Then
    '                    ShowsToDelete.Add(ShowId, 0)
    '                End If
    '            Next

    '            If ShowsToDelete.Count > 0 Then
    '                Using dlg As New dlgDeleteConfirm
    '                    If dlg.ShowDialog(ShowsToDelete, Enums.DelType.Shows) = Windows.Forms.DialogResult.OK Then
    '                        Me.FillList(0)
    '                    End If
    '                End Using
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    Private Sub cmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuEditShow.Click, cmnuEditMovie.Click, cmnuEditEpisode.Click
        If lvMedia.SelectedObjects.Count > 0 Then
            EditMediaItem(lvMedia.SelectedObjects.Item(0))
        End If
    End Sub
    
    Private Sub cmnuGenres_Click(sender As System.Object, e As System.EventArgs) Handles cmnuGenres.Click
        For Each sRow As Object In lvMedia.SelectedObjects
            Select Case ObjectContext.GetObjectType(sRow.GetType())
                Case GetType(Model.Movie), GetType(Model.TVShow)
                    Dim editGenres As New dlgEditGenres()
                    Dim returnResult As Object = editGenres.ShowDialog(sRow)
                    If returnResult IsNot Nothing Then                        
                        lvMedia.RefreshObject(returnResult)
                    End If
            End Select
        Next
        ItemSelected(e, lvMedia.SelectedObjects)
    End Sub

    Private Sub lvMedia_CellRightClick(sender As Object, e As CellRightClickEventArgs) Handles lvMedia.CellRightClick
        e.MenuStrip = DecideRightClickMenu(e.Model, e.Column)
    End Sub

    Private Function DecideRightClickMenu(Model As Object, Column As OLVColumn) As ContextMenuStrip
        Dim setMark As Boolean = False
        Dim setLock As Boolean = False
        Select Case ObjectContext.GetObjectType(Model.GetType())
            Case GetType(Model.Movie)
                mnuMediaList.Enabled = True
                If lvMedia.SelectedObjects.Count > 1 Then
                    cmnuTitle.Text = Languages.Multiple
                    cmnuEditMovie.Visible = False
                    ScrapingToolStripMenuItem.Visible = True
                    cmnuRescrape.Visible = False
                    cmnuSearchNew.Visible = False
                    cmnuMetaData.Visible = False
                    cmnuSep2.Visible = False
                    For Each sRow In lvMedia.SelectedObjects
                        Select Case ObjectContext.GetObjectType(sRow.GetType())
                            Case GetType(Model.Movie)
                                If Not DirectCast(sRow, Model.Movie).Mark.Value Then
                                    setMark = True
                                End If
                                If Not DirectCast(sRow, Model.Movie).Lock Then
                                    setLock = True
                                End If
                        End Select
                    Next
                    cmnuMark.Text = If(setMark, Languages.Mark, Languages.Unmark)
                    cmnuLock.Text = If(setLock, Languages.Lock, Languages.Unlock)
                ElseIf lvMedia.SelectedObjects.Count = 1 Then
                    Dim currentMovie As Model.Movie = DirectCast(lvMedia.SelectedObjects.Item(0), Model.Movie)
                    cmnuEditMovie.Visible = True
                    ScrapingToolStripMenuItem.Visible = False
                    cmnuRescrape.Visible = True
                    cmnuSearchNew.Visible = True
                    cmnuMetaData.Visible = True
                    cmnuSep.Visible = True
                    cmnuSep2.Visible = True
                    cmnuTitle.Text = String.Format(">> {0} ({1}) <<", currentMovie.SortTitle, currentMovie.Year)
                    cmnuMark.Text = If(currentMovie.Mark, Languages.Unmark, Languages.Mark)
                    cmnuLock.Text = If(currentMovie.Lock, Languages.Unlock, Languages.Lock)
                Else
                    mnuMediaList.Enabled = False
                    cmnuTitle.Text = Languages.No_Item_Selected                                        
                End If
                Return mnuMediaList
            Case GetType(Model.TVShow)
                mnuShows.Enabled = True
                If lvMedia.SelectedObjects.Count > 1 Then                    
                    cmnuShowTitle.Text = Languages.Multiple
                    ToolStripSeparator8.Visible = False
                    cmnuEditShow.Visible = False
                    ToolStripSeparator7.Visible = False
                    ' Me.cmnuRescrapeShow.Visible = False
                    cmnuChangeShow.Visible = False
                    cmnuShowOpenFolder.Visible = False
                    ToolStripSeparator20.Visible = False
                    For Each sRow In lvMedia.SelectedObjects
                        Select Case ObjectContext.GetObjectType(sRow.GetType())
                            Case GetType(Model.TVShow)
                                If Not DirectCast(sRow, Model.TVShow).Mark Then
                                    setMark = True
                                End If
                                If Not DirectCast(sRow, Model.TVShow).Lock Then
                                    setLock = True
                                End If
                        End Select
                    Next
                    cmnuMarkShow.Text = If(setMark, Languages.Mark, Languages.Unmark)
                    cmnuLockShow.Text = If(setLock, Languages.Lock, Languages.Unlock)
                ElseIf lvMedia.SelectedObjects.Count = 1 Then
                    Dim currentTVShow As Model.TVShow = DirectCast(lvMedia.SelectedObjects.Item(0), Model.TVShow)
                    ToolStripSeparator8.Visible = True
                    cmnuEditShow.Visible = True
                    ToolStripSeparator7.Visible = True
                    cmnuRescrapeShow.Visible = True
                    cmnuChangeShow.Visible = True
                    cmnuShowOpenFolder.Visible = True
                    ToolStripSeparator20.Visible = True
                    cmnuShowTitle.Text = String.Format(">> {0} <<", currentTVShow.Title)
                    cmnuMarkShow.Text = If(currentTVShow.Mark, Languages.Unmark, Languages.Mark)
                    cmnuLockShow.Text = If(currentTVShow.Lock, Languages.Unlock, Languages.Lock)
                Else
                    Return Nothing
                End If
                Return mnuShows
            Case GetType(Model.TVEp)
                mnuEpisodes.Enabled = True
                If lvMedia.SelectedObjects.Count > 1 Then                    
                    cmnuEpTitle.Text = Languages.Multiple
                    For Each sRow In lvMedia.SelectedObjects
                        Select Case ObjectContext.GetObjectType(sRow.GetType())
                            Case GetType(Model.TVEp)
                                If Not DirectCast(sRow, Model.TVEp).Mark Then
                                    setMark = True
                                End If
                                If Not DirectCast(sRow, Model.TVEp).Lock Then
                                    setLock = True
                                End If
                        End Select
                    Next
                    ToolStripSeparator9.Visible = False
                    cmnuEditEpisode.Visible = False
                    ToolStripSeparator10.Visible = False
                    cmnuRescrapeEp.Visible = False
                    cmnuChangeEp.Visible = False
                    ToolStripSeparator12.Visible = False
                    cmnuEpOpenFolder.Visible = False
                    cmnuMarkEp.Text = If(setMark, Languages.Mark, Languages.Unmark)
                    cmnuLockEp.Text = If(setLock, Languages.Lock, Languages.Unlock)
                ElseIf lvMedia.SelectedObjects.Count = 1 Then
                    Dim currentTVEp As Model.TVEp = DirectCast(lvMedia.SelectedObjects.Item(0), Model.TVEp)
                    cmnuEpTitle.Text = String.Format(">> {0} <<", currentTVEp.Title)
                    ToolStripSeparator9.Visible = True
                    cmnuEditEpisode.Visible = True
                    ToolStripSeparator10.Visible = True
                    cmnuRescrapeEp.Visible = True
                    cmnuChangeEp.Visible = True
                    ToolStripSeparator12.Visible = True
                    cmnuEpOpenFolder.Visible = True
                    cmnuMarkEp.Text = If(currentTVEp.Mark, Languages.Unmark, Languages.Mark)
                    cmnuLockEp.Text = If(currentTVEp.Lock, Languages.Unlock, Languages.Lock)
                Else
                    Return Nothing
                End If
                '                        For Each sRow As DataGridViewRow In Me.dgvTVEpisodes.SelectedRows
                '                            If Convert.ToBoolean(sRow.Cells(22).Value) Then
                '                                hasMissing = True
                '                                Exit For
                '                            End If
                '                        Next



                '                        If hasMissing Then
                '                            Me.ShowEpisodeMenuItems(False)
                '                        Else
                '                           
                '                            Me.ShowEpisodeMenuItems(True)

                '                            '                            
                '                        End If

                '                        If Convert.ToBoolean(Me.dgvTVEpisodes.Item(22, dgvHTI.RowIndex).Value) Then hasMissing = True

                '                        If hasMissing Then
                '                            Me.ShowEpisodeMenuItems(False)
                '                        Else
                '                            Me.ShowEpisodeMenuItems(True)
                Return mnuEpisodes
            Case GetType(Model.TVSeason)
                mnuSeasons.Enabled = True
                If lvMedia.SelectedObjects.Count > 1 Then
                    cmnuSeasonTitle.Text = Languages.Multiple
                    For Each sRow In lvMedia.SelectedObjects
                        Select Case ObjectContext.GetObjectType(sRow.GetType())
                            Case GetType(Model.TVSeason)
                                If Not DirectCast(sRow, Model.TVSeason).Mark Then
                                    setMark = True
                                End If
                                If Not DirectCast(sRow, Model.TVSeason).Lock Then
                                    setLock = True
                                End If
                        End Select
                    Next
                    ToolStripSeparator16.Visible = False
                    cmnuSeasonChangeImages.Visible = False
                    ToolStripSeparator14.Visible = False
                    cmnuSeasonRescrape.Visible = False
                    ToolStripSeparator15.Visible = False
                    cmnuSeasonOpenFolder.Visible = False
                    cmnuMarkSeason.Text = If(setMark, Languages.Mark, Languages.Unmark)
                    cmnuLockSeason.Text = If(setLock, Languages.Lock, Languages.Unlock)
                ElseIf lvMedia.SelectedObjects.Count = 1 Then
                    Dim currentTVSeason As Model.TVSeason = DirectCast(lvMedia.SelectedObjects.Item(0), Model.TVSeason)
                    cmnuSeasonTitle.Text = String.Format(">> {0} <<", currentTVSeason.SeasonText)
                    ToolStripSeparator16.Visible = True
                    cmnuSeasonChangeImages.Visible = True
                    ToolStripSeparator14.Visible = True
                    cmnuSeasonRescrape.Visible = True
                    ToolStripSeparator15.Visible = True
                    cmnuSeasonOpenFolder.Visible = True
                    cmnuMarkEp.Text = If(currentTVSeason.Mark, Languages.Unmark, Languages.Mark)
                    cmnuLockEp.Text = If(currentTVSeason.Lock, Languages.Unlock, Languages.Lock)
                Else
                    Return Nothing
                End If
                Return mnuSeasons
        End Select
        Return Nothing
    End Function

    'Private Sub Setup()
    '    With Me
    '        .lblGFilClose.Text = Master.eLang.GetString(19, "Close")
    '        .lblSFilClose.Text = Master.eLang.GetString(19, "Close")
    '        .Label4.Text = Master.eLang.GetString(20, "Genres")
    '        .Label8.Text = Master.eLang.GetString(602, "Sources")
    '        .cmnuTitle.Text = Master.eLang.GetString(21, "Title")
    '        .cmnuRefresh.Text = Master.eLang.GetString(22, "Reload")
    '        .cmnuMark.Text = Master.eLang.GetString(23, "Mark")
    '        .cmnuLock.Text = Master.eLang.GetString(24, "Lock")
    '        .cmnuEditMovie.Text = Master.eLang.GetString(25, "Edit Movie")
    '        .GenresToolStripMenuItem.Text = Master.eLang.GetString(20, "Genres")    
    '        .ScrapingToolStripMenuItem.Text = Master.eLang.GetString(31, "(Re)Scrape Selected Movies")
    '        .cmnuSearchNew.Text = Master.eLang.GetString(32, "Change Movie")
    '        .OpenContainingFolderToolStripMenuItem.Text = Master.eLang.GetString(33, "Open Containing Folder")
    '        .cmnuShowOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '        .cmnuSeasonOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '        .cmnuEpOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '        .RemoveToolStripMenuItem.Text = Master.eLang.GetString(30, "Remove")
    '        .DeleteMovieToolStripMenuItem.Text = Master.eLang.GetString(34, "Delete Movie")
    '        .RemoveFromDatabaseToolStripMenuItem.Text = Master.eLang.GetString(646, "Remove From Database")
    '        .btnMarkAll.Text = Master.eLang.GetString(35, "Mark All")
    '        .tabMovies.Text = Master.eLang.GetString(36, "Movies")
    '        .tabTV.Text = Master.eLang.GetString(653, "TV")
    '    End With
    'End Sub

    Private Sub cmnuLock_Click(sender As System.Object, e As System.EventArgs) Handles cmnuLockSeason.Click, cmnuLockShow.Click, cmnuLockEp.Click, cmnuLock.Click
        For Each sRow As Object In lvMedia.SelectedObjects
            Select Case ObjectContext.GetObjectType(sRow.GetType())
                Case GetType(Model.Movie)
                    Dim currentMovie As Model.Movie = DirectCast(sRow, Model.Movie)
                    currentMovie.Lock = Not currentMovie.Lock
                    Database.SaveMovie(currentMovie, EntityState.Modified)
                    lvMedia.RefreshObject(currentMovie)
                Case GetType(Model.TVEp)
                    Dim currentTVEp As Model.TVEp = DirectCast(sRow, Model.TVEp)
                    currentTVEp.Lock = Not currentTVEp.Lock
                    Database.SaveTVEp(currentTVEp, EntityState.Modified)
                    lvMedia.RefreshObject(currentTVEp)
                Case GetType(Model.TVSeason)
                    Dim currentTVSeason As Model.TVSeason = DirectCast(sRow, Model.TVSeason)
                    Database.LockTVSeason(currentTVSeason)
                    lvMedia.RefreshObject(currentTVSeason)
                Case GetType(Model.TVShow)
                    Dim currentTVShow As Model.TVShow = DirectCast(sRow, Model.TVShow)
                    Database.LockTVShow(currentTVSHow)
                    lvMedia.RefreshObject(currentTVSHow)
            End Select
        Next
        ItemSelected(e, lvMedia.SelectedObjects)
    End Sub

    Private Sub cmnuMark_Click(sender As System.Object, e As System.EventArgs) Handles cmnuMark.Click, cmnuMarkShow.Click, cmnuMarkSeason.Click, cmnuMarkEp.Click
        For Each sRow As Object In lvMedia.SelectedObjects
            Select Case ObjectContext.GetObjectType(sRow.GetType())
                Case GetType(Model.Movie)
                    Dim currentMovie As Model.Movie = DirectCast(sRow, Model.Movie)
                    currentMovie.Mark = Not currentMovie.Mark.Value
                    Database.SaveMovie(currentMovie, EntityState.Modified)
                    lvMedia.RefreshObject(currentMovie)
                Case GetType(Model.TVEp)
                    Dim currentTVEp As Model.TVEp = DirectCast(sRow, Model.TVEp)
                    currentTVEp.Mark = Not currentTVEp.Mark
                    Database.SaveTVEp(currentTVEp, EntityState.Modified)
                    lvMedia.RefreshObject(currentTVEp)
                Case GetType(Model.TVSeason)
                    Dim currentTVSeason As Model.TVSeason = DirectCast(sRow, Model.TVSeason)
                    Database.MarkTVSeason(currentTVSeason)
                    lvMedia.RefreshObject(currentTVSeason)
                Case GetType(Model.TVShow)
                    Dim currentTVShow As Model.TVShow = DirectCast(sRow, Model.TVShow)
                    Database.MarkTVShow(currentTVShow)
                    lvMedia.RefreshObject(currentTVShow)
            End Select
        Next
        ItemSelected(e, lvMedia.SelectedObjects)
    End Sub

    Private Sub lvMedia_FormatRow(sender As Object, e As FormatRowEventArgs) Handles lvMedia.FormatRow
        Select ObjectContext.GetObjectType(e.Model.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie As Model.Movie = DirectCast(e.Model, Model.Movie)
                If currentMovie.Mark Then
                    e.Item.ForeColor = Color.Red
                End If
                If currentMovie.Lock Then
                    e.Item.BackColor = Color.LightSteelBlue                    
                End If
                If currentMovie.IsNew Then
                    e.Item.ForeColor = Color.Green
                End If
            Case GetType(Model.TVEp)
                Dim currentTVEp As Model.TVEp = DirectCast(e.Model, Model.TVEp)
                If currentTVEp.Mark Then
                    e.Item.ForeColor = Color.Red
                End If
                If currentTVEp.Lock Then
                    e.Item.BackColor = Color.LightSteelBlue
                End If
            Case GetType(Model.TVSeason)
                Dim currentTVSeason As Model.TVSeason = DirectCast(e.Model, Model.TVSeason)
                If currentTVSeason.Mark Then
                    e.Item.ForeColor = Color.Red
                End If
                If currentTVSeason.Lock Then
                    e.Item.BackColor = Color.LightSteelBlue
                End If
            Case GetType(Model.TVShow)
                Dim currentTVShow As Model.TVShow = DirectCast(e.Model, Model.TVShow)
                If currentTVShow.Mark Then
                    e.Item.ForeColor = Color.Red
                End If
                If currentTVShow.Lock Then
                    e.Item.BackColor = Color.LightSteelBlue
                End If
        End Select
        'If e.ColumnIndex = 1 AndAlso e.RowIndex >= 0 Then
        '                If Convert.ToBoolean(Me.dgvTVShows.Item(6, e.RowIndex).Value) Then
        '                    e.CellStyle.ForeColor = Color.Crimson
        '                    e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        '                    e.CellStyle.SelectionForeColor = Color.Crimson
        '                ElseIf Convert.ToBoolean(Me.dgvTVShows.Item(5, e.RowIndex).Value) Then
        '                    e.CellStyle.ForeColor = Color.Green
        '                    e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        '                    e.CellStyle.SelectionForeColor = Color.Green
        '                Else
        '                    e.CellStyle.ForeColor = Color.Black
        '                    e.CellStyle.Font = New Font("Segoe UI", 8.25, FontStyle.Regular)
        '                    e.CellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText)
        '                End If
        '            End If

        '            If e.ColumnIndex >= 1 AndAlso e.ColumnIndex <= 4 AndAlso e.RowIndex >= 0 Then

        '                If Convert.ToBoolean(Me.dgvTVShows.Item(10, e.RowIndex).Value) Then
        '                    e.CellStyle.BackColor = Color.LightSteelBlue
        '                    e.CellStyle.SelectionBackColor = Color.DarkTurquoise
        '                Else
        '                    e.CellStyle.BackColor = Color.White
        '                    e.CellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight)
        '                End If
    End Sub

    Private Sub lvMedia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvMedia.KeyPress
        If e.KeyChar = Chr(13) And lvMedia.SelectedObjects.Count > 0 Then
            EditMediaItem(lvMedia.SelectedObjects.Item(0))
        End If
    End Sub

    Private Sub EditMediaItem(mediaItem As Object)
        Select Case ObjectContext.GetObjectType(mediaItem.GetType())
            Case GetType(Model.TVShow)
                Dim currentTVShow = DirectCast(mediaItem, Model.TVShow)
                Using dEditShow As New dlgEditShow
                    Dim returnResult As Model.TVShow = dEditShow.ShowDialog(currentTVShow)
                    If returnResult IsNot Nothing Then
                        lvMedia.RefreshObject(returnResult)
                    End If
                End Using
            Case GetType(Model.TVEp)
                Dim currentTVEp = DirectCast(mediaItem, Model.TVEp)
                Using dEditEpisode As New dlgEditEpisode                    
                    Dim returnValue As Model.TVEp = dEditEpisode.ShowDialog(currentTVEp)
                    If returnValue IsNot Nothing Then
                        lvMedia.RefreshObject(returnValue)
                    End If
                End Using
            Case GetType(Model.TVSeason)
                Dim currentTVSeason = DirectCast(mediaItem, Model.TVSeason)
                Using dEditSeason As New dlgEditSeason
                    Dim returnResult As Model.TVSeason = dEditSeason.ShowDialog(currentTVSeason)
                    If returnResult IsNot Nothing Then
                        lvMedia.RefreshObject(returnResult)
                    End If
                End Using
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(mediaItem, Model.Movie)
                Using dEditMovie As New dlgEditMovie
                    Dim returnResult As Model.TVSeason = dEditMovie.ShowDialog(currentMovie)
                    If returnResult IsNot Nothing Then
                        lvMedia.RefreshObject(returnResult)
                    End If
                    '                AddHandler ModulesManager.Instance.GenericEvent, AddressOf dEditMovie.GenericRunCallBack
                    '                Select Case dEditMovie.ShowDialog()
                    '                    Case Windows.Forms.DialogResult.OK
                    '                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieScraperRDYtoSave, Nothing, Master.currMovie)
                    '                        Me.SetListItemAfterEdit(ID, indX)
                    '                        If Me.RefreshMovie(ID) Then
                    '                            Me.FillList(0)
                    '                        Else
                    '                            Me.SetControlsEnabled(True)
                    '                        End If
                    '                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieSync, Nothing, Master.currMovie)
                    '                    Case Windows.Forms.DialogResult.Retry
                    '                        Functions.SetScraperMod(Enums.ModType.All, True, True)
                    '                        Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions)
                    '                    Case Windows.Forms.DialogResult.Abort
                    '                        Master.currMovie.ClearExtras = False
                    '                        Functions.SetScraperMod(Enums.ModType.DoSearch, True)
                    '                        Functions.SetScraperMod(Enums.ModType.All, True, False)
                    '                        Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions)
                    '                    Case Else
                    '                        If Me.InfoCleared Then
                    '                            Me.LoadInfo(ID, Me.dgvMediaList.Item(1, indX).Value.ToString, True, False)
                    '                        Else
                    '                            Me.SetControlsEnabled(True)
                    '                        End If
                    '                End Select
                    '                RemoveHandler ModulesManager.Instance.GenericEvent, AddressOf dEditMovie.GenericRunCallBack
                End Using
        End Select
    End Sub

    Private Sub lvMedia_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvMedia.DoubleClick
        If lvMedia.SelectedObjects.Count > 0 Then
            EditMediaItem(lvMedia.SelectedObjects.Item(0))
        End If
    End Sub

    Private Sub lvMedia_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles lvMedia.SelectionChanged
        If lvMedia.SelectedObjects.Count > 0 Then
            ItemSelected(e, lvMedia.SelectedObjects)
        End If
    End Sub

    Private Sub ItemSelected(e As EventArgs, mediaItem As IList)
        Dim statusText As String = ""
        If mediaItem.Count = 1 Then
            Select Case ObjectContext.GetObjectType(mediaItem.Item(0).GetType())
                Case GetType(Model.TVSeason)
                    Dim currentTVSeason As Model.TVSeason = DirectCast(mediaItem.Item(0), Model.TVSeason)
                    statusText = currentTVSeason.SeasonText
                Case GetType(Model.TVShow)
                    Dim currentTVShow As Model.TVShow = DirectCast(mediaItem.Item(0), Model.TVShow)
                    statusText = currentTVShow.Title
                Case GetType(Model.TVEp)
                    Dim currentTVEp As Model.TVEp = DirectCast(mediaItem.Item(0), Model.TVEp)
                    statusText = currentTVEp.Title
                Case GetType(Model.Movie)
                    Dim currentMovie As Model.Movie = DirectCast(mediaItem.Item(0), Model.Movie)
                    statusText = currentMovie.MoviePath
            End Select
        Else
            statusText = String.Format(Languages.Selected_Items_Param, mediaItem.Count)
        End If
        RaiseEvent MediaItemSelected(e, New MediaSelectedArgs(mediaItem.Item(0), statusText))
    End Sub

    Private Sub cmnuSeasonChangeImages_Click(sender As System.Object, e As System.EventArgs) Handles cmnuSeasonChangeImages.Click
        If lvMedia.SelectedObjects.Count > 0 Then
            EditMediaItem(lvMedia.SelectedObjects.Item(0))
        End If
    End Sub

    Private Sub cmnuSearchNew_Click(sender As System.Object, e As System.EventArgs) Handles cmnuSearchNew.Click
        If lvMedia.SelectedObjects.Count > 0 Then
            Dim currentMovie As Model.Movie = DirectCast(lvMedia.SelectedObjects.Item(0), Model.Movie)
            Dim searchDialog As New dlgIMDBSearchResults
            searchDialog.ShowDialog(currentMovie.Title, currentMovie.Year)
        End If
    End Sub
End Class


