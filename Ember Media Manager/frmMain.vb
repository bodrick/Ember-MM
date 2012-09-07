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
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports EmberMediaManger.Modules.BulkRename
Imports EmberMediaManger.API
Imports System.Data.Objects
Imports TechNuts.ScraperXML
Imports HTTP = EmberMediaManger.Classes.HTTP
Imports Settings = EmberMediaManger.Dialogs.Settings

Public Class frmMain

#Region "Fields"
    Friend Property CurrentMedia As Object
    Private fLoading As New frmSplash

    'Friend WithEvents bwCleanDB As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwDownloadPic As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwLoadEpInfo As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwLoadInfo As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwLoadSeasonInfo As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwLoadShowInfo As New System.ComponentModel.BackgroundWorker    
    'Friend WithEvents bwMovieScraper As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwNonScrape As New System.ComponentModel.BackgroundWorker
    'Friend WithEvents bwRefreshMovies As New System.ComponentModel.BackgroundWorker

    Private aniRaise As Boolean = False
    Private aniShowType As Integer = 0 '0 = down, 1 = mid, 2 = up
    Private aniType As Integer = 0 '0 = down, 1 = mid, 2 = up

    Private dScrapeRow As DataRow = Nothing
    'Private fScanner As New Scanner
    Private InfoCleared As Boolean = False
    Private isCL As Boolean = False
    Private LoadingDone As Boolean = False
    Private prevText As String = String.Empty
    Private ReportDownloadPercent As Boolean = False
    Private ScrapeList As New List(Of DataRow)
    Private ScraperDone As Boolean = False
    Private sHTTP As New HTTP
    Private tmpLang As String = String.Empty
    Private tmpTitle As String = String.Empty
    Private tmpTVDB As String = String.Empty
    Private tmpOrdering As Enums.Ordering = Enums.Ordering.Standard

    'Loading Delays
    Private currRow As Integer = -1
    Private currEpRow As Integer = -1
    Private currSeasonRow As Integer = -1
    Private currShowRow As Integer = -1
    Private currList As Integer = 0
    Private currText As String = String.Empty
    Private prevEpRow As Integer = -1
    Private prevRow As Integer = -1
    Private prevSeasonRow As Integer = -1
    Private prevShowRow As Integer = -1
    Private bDoingSearch As Boolean = False

    'filters
    Private FilterArray As New List(Of String)
    Private filSearch As String = String.Empty
    Private filSource As String = String.Empty
    Private filYear As String = String.Empty
    Private filGenre As String = String.Empty
    Private filMissing As String = String.Empty
    Private CloseApp As Boolean = False

    Private oldStatus As String = String.Empty

    Private KeyBuffer As String = String.Empty

#End Region 'Fields

#Region "Delegates"

    Delegate Sub DelegateEvent(ByVal eType As Enums.MovieScraperEventType, ByVal Parameter As Object)

    Delegate Sub MydtListUpdate(ByVal drow As DataRow, ByVal i As Integer, ByVal v As Object)

    Delegate Sub MySettingsShow(ByVal dlg As Settings)

#End Region 'Delegates

    '#Region "Methods"



    '    Public Sub LoadMedia(ByVal Scan As Structures.Scans, Optional ByVal SourceName As String = "")
    '        Try
    '            Me.SetStatus(Master.eLang.GetString(116, "Performing Preliminary Tasks (Gathering Data)..."))
    '            Me.tspbLoading.ProgressBar.Style = ProgressBarStyle.Marquee
    '            Me.tspbLoading.Visible = True

    '            Application.DoEvents()

    '            Me.ClearInfo()
    '            Me.ClearFilters()
    '            Me.EnableFilters(False)

    '            Me.SetControlsEnabled(False)    
    '            pnlSearch.Clear()

    '            Me.fScanner.CancelAndWait()

    '            If Scan.Movies Then
    '                Me.dgvMediaList.DataSource = Nothing
    '            End If

    '            If Scan.TV Then
    '                Me.dgvTVShows.DataSource = Nothing
    '                Me.dgvTVSeasons.DataSource = Nothing
    '                Me.dgvTVEpisodes.DataSource = Nothing
    '            End If

    '            Me.fScanner.Start(Scan, SourceName)

    '        Catch ex As Exception
    '            Me.LoadingDone = True
    '            Me.EnableFilters(True)
    '            Me.SetControlsEnabled(True)
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Public Sub SetListItemAfterEdit(ByVal iID As Integer, ByVal iRow As Integer)
    '        Try
    '            Dim dRow = From drvRow In dtMedia.Rows Where Convert.ToInt32(DirectCast(drvRow, DataRow).Item(0)) = iID Select drvRow

    '            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                SQLcommand.CommandText = String.Concat("SELECT mark, SortTitle FROM movies WHERE id = ", iID, ";")
    '                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
    '                    DirectCast(dRow(0), DataRow).Item(11) = Convert.ToBoolean(SQLreader("mark"))
    '                    If Not DBNull.Value.Equals(SQLreader("SortTitle")) Then DirectCast(dRow(0), DataRow).Item(47) = SQLreader("SortTitle").ToString
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Public Sub SetShowListItemAfterEdit(ByVal iID As Integer, ByVal iRow As Integer)
    '        Try
    '            Dim dRow = From drvRow In dtShows.Rows Where Convert.ToInt32(DirectCast(drvRow, DataRow).Item(0)) = iID Select drvRow

    '            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                SQLcommand.CommandText = String.Concat("SELECT Ordering FROM TVShows WHERE id = ", iID, ";")
    '                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
    '                    DirectCast(dRow(0), DataRow).Item(23) = Convert.ToInt32(SQLreader("Ordering"))
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Using dAbout As New dlgAbout
            dAbout.ShowDialog()
        End Using
    End Sub

    '    Private Sub bwCleanDB_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCleanDB.DoWork
    '        Master.DB.Clean(True, True)
    '    End Sub

    '    Private Sub bwCleanDB_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCleanDB.RunWorkerCompleted
    '        Me.SetStatus(String.Empty)
    '        Me.tspbLoading.Visible = False

    '        Me.FillList(0)
    '    End Sub

    '    Private Sub bwMovieScraper_Completed(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwMovieScraper.RunWorkerCompleted
    '        Dim Res As Results = DirectCast(e.Result, Results)
    '        If isCL Then
    '            Me.ScraperDone = True
    '        End If

    '        If Res.scrapeType = Enums.ScrapeType.SingleScrape Then
    '            Me.MovieInfoDownloaded()
    '        Else
    '            If Me.dgvMediaList.SelectedRows.Count > 0 Then
    '                Me.SelectRow(Me.dgvMediaList.SelectedRows(0).Index)
    '            Else
    '                Me.ClearInfo()
    '            End If
    '            Me.tslLoading.Visible = False
    '            Me.tspbLoading.Visible = False
    '            Me.btnCancel.Visible = False
    '            Me.lblCanceling.Visible = False
    '            Me.pbCanceling.Visible = False
    '            Me.pnlCancel.Visible = False
    '            Me.SetControlsEnabled(True)
    '        End If
    '    End Sub

    '    Private Sub bwMovieScraper_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwMovieScraper.DoWork
    '        Dim Args As Arguments = DirectCast(e.Argument, Arguments)
    '        Dim OldTitle As String = String.Empty
    '        Dim NewTitle As String = String.Empty

    '        AddHandler ModulesManager.Instance.MovieScraperEvent, AddressOf MovieScraperEvent

    '        For Each dRow As DataRow In ScrapeList
    '            Try
    '                If bwMovieScraper.CancellationPending Then Exit For
    '                OldTitle = dRow.Item(3).ToString
    '                bwMovieScraper.ReportProgress(1, OldTitle)

    '                dScrapeRow = dRow
    '                Dim DBScrapeMovie As Structures.DBMovie = Master.DB.LoadMovieFromDB(Convert.ToInt64(dRow.Item(0)))
    '                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.BeforeEditMovie, Nothing, DBScrapeMovie)
    '                If Not ModulesManager.Instance.MovieScrapeOnly(DBScrapeMovie, Args.scrapeType, Args.Options) Then
    '                    If Master.eSettings.ScanMediaInfo AndAlso Master.GlobalScrapeMod.Meta Then
    '                        MediaInfo.UpdateMediaInfo(DBScrapeMovie)
    '                    End If
    '                    If bwMovieScraper.CancellationPending Then Exit For
    '                    If Not Args.scrapeType = Enums.ScrapeType.SingleScrape Then
    '                        MovieScraperEvent(Enums.MovieScraperEventType.NFOItem, True)

    '                        NewTitle = DBScrapeMovie.ListTitle

    '                        If Not NewTitle = OldTitle Then
    '                            bwMovieScraper.ReportProgress(0, String.Format(Master.eLang.GetString(812, "Old Title: {0} | New Title: {1}"), OldTitle, NewTitle))
    '                        End If

    '                        MovieScraperEvent(Enums.MovieScraperEventType.ListTitle, NewTitle)
    '                        MovieScraperEvent(Enums.MovieScraperEventType.SortTitle, DBScrapeMovie.Movie.SortTitle)

    '                        Dim didEts As Interfaces.ModuleResult = ModulesManager.Instance.MoviePostScrapeOnly(DBScrapeMovie, Args.scrapeType)

    '                        If bwMovieScraper.CancellationPending Then Exit For

    '                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieScraperRDYtoSave, Nothing, DBScrapeMovie)

    '                        If Master.GlobalScrapeMod.Extra Then
    '                            If Master.eSettings.AutoThumbs > 0 AndAlso DBScrapeMovie.isSingle Then
    '                                Dim params As New List(Of Object)(New Object() {DBScrapeMovie, Master.eSettings.AutoThumbs, False, ""})
    '                                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.RandomFrameExtrator, params, Nothing, True)
    '                                MovieScraperEvent(Enums.MovieScraperEventType.ThumbsItem, True)
    '                                Dim ETasFA As String = DirectCast(params(3), String)
    '                                If Not String.IsNullOrEmpty(ETasFA) Then
    '                                    DBScrapeMovie.ExtraPath = "TRUE"
    '                                    If Not ETasFA = "TRUE" Then
    '                                        MovieScraperEvent(Enums.MovieScraperEventType.FanartItem, True)
    '                                        DBScrapeMovie.FanartPath = ETasFA
    '                                    End If
    '                                End If
    '                            End If
    '                        End If

    '                        Master.DB.SaveMovieToDB(DBScrapeMovie, False, False, Not String.IsNullOrEmpty(DBScrapeMovie.Movie.IMDBID))
    '                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieSync, Nothing, DBScrapeMovie)
    '                        bwMovieScraper.ReportProgress(-1, If(Not OldTitle = NewTitle, String.Format(Master.eLang.GetString(812, "Old Title: {0} | New Title: {1}"), OldTitle, NewTitle), NewTitle))
    '                        bwMovieScraper.ReportProgress(-2, dScrapeRow.Item(0).ToString)
    '                    Else
    '                        Master.tmpMovie = DBScrapeMovie.Movie
    '                    End If
    '                Else
    '                    Master.tmpMovie = DBScrapeMovie.Movie
    '                    Args.scrapeType = Enums.ScrapeType.None
    '                End If
    '            Catch ex As Exception
    '                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error, False)
    '            End Try
    '        Next

    '        RemoveHandler ModulesManager.Instance.MovieScraperEvent, AddressOf MovieScraperEvent
    '        e.Result = New Results With {.scrapeType = Args.scrapeType}
    '    End Sub

    '    Private Sub bwMovieScraper_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwMovieScraper.ProgressChanged
    '        If e.ProgressPercentage = -1 Then
    '            ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"moviescraped", 3, Master.eLang.GetString(813, "Movie Scraped"), e.UserState.ToString, Nothing}))
    '        ElseIf e.ProgressPercentage = -2 Then
    '            If Me.dgvMediaList.SelectedRows.Count > 0 AndAlso Me.dgvMediaList.SelectedRows(0).Cells(0).Value.ToString = e.UserState.ToString Then
    '                If Me.dgvMediaList.CurrentCell Is Me.dgvMediaList.SelectedRows(0).Cells(3) Then
    '                    Me.SelectRow(Me.dgvMediaList.SelectedRows(0).Index)
    '                End If
    '            End If
    '        Else
    '            Me.tspbLoading.Value += e.ProgressPercentage
    '            Me.SetStatus(e.UserState.ToString)
    '        End If
    '    End Sub

    '    Private Sub bwNonScrape_Completed(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwNonScrape.RunWorkerCompleted
    '        Me.tslLoading.Visible = False
    '        Me.tspbLoading.Visible = False
    '        Me.btnCancel.Visible = False
    '        Me.lblCanceling.Visible = False
    '        Me.pbCanceling.Visible = False
    '        Me.pnlCancel.Visible = False
    '        Me.SetControlsEnabled(True)
    '        Me.EnableFilters(True)
    '        Me.Cursor = Cursors.Default
    '    End Sub

    '    Private Sub bwNonScrape_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwNonScrape.DoWork
    '        Dim scrapeMovie As Structures.DBMovie
    '        Dim iCount As Integer = 0
    '        Dim Args As Arguments = DirectCast(e.Argument, Arguments)
    '        Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction

    '            Try
    '                If Me.dtMedia.Rows.Count > 0 Then

    '                    Select Case Args.scrapeType
    '                        Case Enums.ScrapeType.CleanFolders
    '                            Dim fDeleter As New FileUtils
    '                            For Each drvRow As DataRow In Me.dtMedia.Rows
    '                                Try
    '                                    Me.bwNonScrape.ReportProgress(iCount, drvRow.Item(15))
    '                                    iCount += 1
    '                                    If Convert.ToBoolean(drvRow.Item(14)) Then Continue For

    '                                    If Me.bwNonScrape.CancellationPending Then GoTo doCancel

    '                                    scrapeMovie = Master.DB.LoadMovieFromDB(Convert.ToInt64(drvRow.Item(0)))

    '                                    fDeleter.GetItemsToDelete(True, scrapeMovie)

    '                                    Me.RefreshMovie(Convert.ToInt64(drvRow.Item(0)), True, True)

    '                                    Me.bwNonScrape.ReportProgress(iCount, String.Format("[[{0}]]", drvRow.Item(0).ToString))
    '                                Catch ex As Exception
    '                                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
    '                                End Try
    '                            Next
    '                        Case Enums.ScrapeType.CopyBD
    '                            Dim sPath As String = String.Empty
    '                            For Each drvRow As DataRow In Me.dtMedia.Rows
    '                                Try
    '                                    Me.bwNonScrape.ReportProgress(iCount, drvRow.Item(15).ToString)
    '                                    iCount += 1

    '                                    If Me.bwNonScrape.CancellationPending Then GoTo doCancel
    '                                    sPath = drvRow.Item(37).ToString
    '                                    If Not String.IsNullOrEmpty(sPath) Then
    '                                        If FileUtils.isVideoTS(sPath) Then
    '                                            If Master.eSettings.VideoTSParent Then
    '                                                FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName, Directory.GetParent(Directory.GetParent(sPath).FullName).Name), "-fanart.jpg")))
    '                                            Else
    '                                                If Path.GetFileName(sPath).ToLower = "fanart.jpg" Then
    '                                                    FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, String.Concat(Directory.GetParent(Directory.GetParent(sPath).FullName).Name, "-fanart.jpg")))
    '                                                Else
    '                                                    FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, Path.GetFileName(sPath)))
    '                                                End If
    '                                            End If
    '                                        ElseIf FileUtils.isBDRip(sPath) Then
    '                                            If Master.eSettings.VideoTSParent Then
    '                                                FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName).Name), "-fanart.jpg")))
    '                                            Else
    '                                                If Path.GetFileName(sPath).ToLower = "fanart.jpg" Then
    '                                                    FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, String.Concat(Directory.GetParent(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName).Name, "-fanart.jpg")))
    '                                                Else
    '                                                    FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, Path.GetFileName(sPath)))
    '                                                End If
    '                                            End If
    '                                        Else
    '                                            If Path.GetFileName(sPath).ToLower = "fanart.jpg" Then
    '                                                FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, String.Concat(Path.GetFileNameWithoutExtension(drvRow.Item(1).ToString), "-fanart.jpg")))
    '                                            Else
    '                                                FileUtils.MoveFileWithStream(sPath, Path.Combine(Master.eSettings.BDPath, Path.GetFileName(sPath)))
    '                                            End If

    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
    '                                End Try
    '                            Next
    '                    End Select

    'doCancel:
    '                    If Not Args.scrapeType = Enums.ScrapeType.CopyBD Then
    '                        SQLtransaction.Commit()
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error, False)
    '            End Try
    '        End Using
    '    End Sub

    '    Private Sub bwNonScrape_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwNonScrape.ProgressChanged
    '        If Not isCL Then
    '            If Regex.IsMatch(e.UserState.ToString, "\[\[[0-9]+\]\]") AndAlso Me.dgvMediaList.SelectedRows.Count > 0 Then
    '                Try
    '                    If Me.dgvMediaList.SelectedRows(0).Cells(0).Value.ToString = e.UserState.ToString.Replace("[[", String.Empty).Replace("]]", String.Empty).Trim Then
    '                        Me.SelectRow(Me.dgvMediaList.SelectedRows(0).Index)
    '                    End If
    '                Catch ex As Exception
    '                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error, False)
    '                End Try
    '            Else
    '                Me.SetStatus(e.UserState.ToString)
    '                Me.tspbLoading.Value = e.ProgressPercentage
    '            End If
    '        End If

    '        Me.dgvMediaList.Invalidate()
    '    End Sub

    '    Private Sub bwRefreshMovies_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwRefreshMovies.DoWork
    '        Dim iCount As Integer = 0
    '        Dim MovieIDs As New Dictionary(Of Long, String)

    '        For Each sRow As DataRow In Me.dtMedia.Rows
    '            MovieIDs.Add(Convert.ToInt64(sRow.Item(0)), sRow.Item(3).ToString)
    '        Next

    '        Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '            For Each KVP As KeyValuePair(Of Long, String) In MovieIDs
    '                Try
    '                    If Me.bwMovieScraper.CancellationPending Then Return
    '                    Me.bwRefreshMovies.ReportProgress(iCount, KVP.Value)
    '                    Me.RefreshMovie(KVP.Key, True)
    '                Catch ex As Exception
    '                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error, False)
    '                End Try
    '                iCount += 1
    '            Next
    '            SQLtransaction.Commit()
    '        End Using
    '    End Sub

    '    Private Sub bwRefreshMovies_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwRefreshMovies.ProgressChanged
    '        Me.SetStatus(e.UserState.ToString)
    '        Me.tspbLoading.Value = e.ProgressPercentage
    '    End Sub

    '    Private Sub bwRefreshMovies_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwRefreshMovies.RunWorkerCompleted
    '        Me.tslLoading.Text = String.Empty
    '        Me.tspbLoading.Visible = False
    '        Me.tslLoading.Visible = False

    '        Me.FillList(0)
    '        Me.Cursor = Cursors.Default
    '    End Sub

    '    

    Private Sub CleanDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleanDatabaseToolStripMenuItem.Click, CleanDatabaseToolStripMenuItem1.Click
        '        Me.SetControlsEnabled(False, True)
        '        Me.tspbLoading.Style = ProgressBarStyle.Marquee
        '        Me.EnableFilters(False)

        '        Me.SetStatus(Master.eLang.GetString(644, "Cleaning Database..."))
        '        Me.tspbLoading.Visible = True

        '        Me.bwCleanDB.WorkerSupportsCancellation = True
        '        Me.bwCleanDB.RunWorkerAsync()
    End Sub

    Private Sub CleanFiles()
        Try
            Dim sWarning As String = String.Empty
            Dim sWarningFile As String = String.Empty
            With Master.eSettings
                If .ExpertCleaner Then
                    sWarning = String.Concat(Master.eLang.GetString(102, "WARNING: If you continue, all non-whitelisted file types will be deleted!"), vbNewLine, vbNewLine, Master.eLang.GetString(101, "Are you sure you want to continue?"))
                Else
                    If .CleanDotFanartJPG Then sWarningFile += String.Concat("<movie>.fanart.jpg", vbNewLine)
                    If .CleanFanartJPG Then sWarningFile += String.Concat("fanart.jpg", vbNewLine)
                    If .CleanFolderJPG Then sWarningFile += String.Concat("folder.jpg", vbNewLine)
                    If .CleanMovieFanartJPG Then sWarningFile += String.Concat("<movie>-fanart.jpg", vbNewLine)
                    If .CleanMovieJPG Then sWarningFile += String.Concat("movie.jpg", vbNewLine)
                    If .CleanMovieNameJPG Then sWarningFile += String.Concat("<movie>.jpg", vbNewLine)
                    If .CleanMovieNFO Then sWarningFile += String.Concat("movie.nfo", vbNewLine)
                    If .CleanMovieNFOB Then sWarningFile += String.Concat("<movie>.nfo", vbNewLine)
                    If .CleanMovieTBN Then sWarningFile += String.Concat("movie.tbn", vbNewLine)
                    If .CleanMovieTBNB Then sWarningFile += String.Concat("<movie>.tbn", vbNewLine)
                    If .CleanPosterJPG Then sWarningFile += String.Concat("poster.jpg", vbNewLine)
                    If .CleanPosterTBN Then sWarningFile += String.Concat("poster.tbn", vbNewLine)
                    If .CleanExtraThumbs Then sWarningFile += String.Concat("/extrathumbs/", vbNewLine)
                    sWarning = String.Concat(Master.eLang.GetString(103, "WARNING: If you continue, all files of the following types will be permanently deleted:"), vbNewLine, vbNewLine, sWarningFile, vbNewLine, Master.eLang.GetString(101, "Are you sure you want to continue?"))
                End If
            End With
            If MsgBox(sWarning, MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are you sure?")) = MsgBoxResult.Yes Then
                'Me.NonScrape(Enums.ScrapeType.CleanFolders, Nothing)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub CleanFoldersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleanFoldersToolStripMenuItem.Click, CleanFilesToolStripMenuItem.Click
        CleanFiles()
    End Sub

    Private Sub ClearAllCachesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllCachesToolStripMenuItem.Click, ClearAllCachesToolStripMenuItem1.Click
        ClearCache()
    End Sub

    Private Sub ClearCache()
        If Directory.Exists(Master.TempPath) Then
            Dim dInfo As New DirectoryInfo(Master.TempPath)
            For Each dDir As DirectoryInfo In dInfo.GetDirectories.Where(Function(d) Not d.Name.ToLower = "shows" AndAlso Not d.Name.ToLower = "addons")
                FileUtils.DeleteDirectory(dDir.FullName)
            Next

            For Each fFile As FileInfo In dInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                fFile.Delete()
            Next
        Else
            Directory.CreateDirectory(Master.TempPath)
        End If
    End Sub



    Private Sub ConvertFileSourceToFolderSourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertFileSourceToFolderSourceToolStripMenuItem.Click, SortFilesIntoFoldersToolStripMenuItem.Click
        'Me.SetControlsEnabled(False)
        'Using dSortFiles As New dlgSortFiles
        '    If dSortFiles.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        Me.LoadMedia(New Structures.Scans With {.Movies = True})
        '    Else
        '        Me.SetControlsEnabled(True)
        '    End If
        'End Using
    End Sub

    Private Sub CopyExistingFanartToBackdropsFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyExistingFanartToBackdropsFolderToolStripMenuItem.Click, CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Click
        'Me.NonScrape(Enums.ScrapeType.CopyBD, Nothing)
    End Sub

    '    

    '    Private Sub CustomUpdaterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomUpdaterToolStripMenuItem.Click, TrayCustomUpdaterToolStripMenuItem.Click
    '        Me.SetControlsEnabled(False)
    '        Using dUpdate As New dlgUpdateMedia
    '            Dim CustomUpdater As Structures.CustomUpdaterStruct = Nothing
    '            CustomUpdater = dUpdate.ShowDialog()
    '            If Not CustomUpdater.Canceled Then
    '                Me.MovieScrapeData(False, CustomUpdater.ScrapeType, CustomUpdater.Options)
    '            Else
    '                Me.SetControlsEnabled(True)
    '            End If
    '        End Using
    '    End Sub

    '    Private Sub DeleteMovieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMovieToolStripMenuItem.Click
    '        Try
    '            Dim MoviesToDelete As New Dictionary(Of Long, Long)
    '            Dim MovieId As Int64 = -1

    '            For Each sRow As DataGridViewRow In Me.dgvMediaList.SelectedRows
    '                MovieId = Convert.ToInt64(sRow.Cells(0).Value)
    '                If Not MoviesToDelete.ContainsKey(MovieId) Then
    '                    MoviesToDelete.Add(MovieId, 0)
    '                End If
    '            Next

    '            If MoviesToDelete.Count > 0 Then
    '                Using dlg As New dlgDeleteConfirm
    '                    If dlg.ShowDialog(MoviesToDelete, Enums.DelType.Movies) = Windows.Forms.DialogResult.OK Then
    '                        Me.FillList(0)
    '                    End If
    '                End Using
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub ShowEpisodeMenuItems(ByVal Visible As Boolean)
    '        Dim cMnu As ToolStripMenuItem
    '        Dim cSep As ToolStripSeparator

    '        Try
    '            If Visible Then
    '                For Each cMnuItem As Object In Me.mnuEpisodes.Items
    '                    If TypeOf cMnuItem Is ToolStripMenuItem Then
    '                        DirectCast(cMnuItem, ToolStripMenuItem).Visible = True
    '                    ElseIf TypeOf cMnuItem Is ToolStripSeparator Then
    '                        DirectCast(cMnuItem, ToolStripSeparator).Visible = True
    '                    End If
    '                Next
    '                Me.cmnuDeleteTVEp.Visible = True
    '            Else
    '                For Each cMnuItem As Object In Me.mnuEpisodes.Items
    '                    If TypeOf cMnuItem Is ToolStripMenuItem Then
    '                        cMnu = DirectCast(cMnuItem, ToolStripMenuItem)
    '                        If Not cMnu.Name = "RemoveEpToolStripMenuItem" AndAlso Not cMnu.Name = "cmnuEpTitle" Then
    '                            cMnu.Visible = False
    '                        End If
    '                    ElseIf TypeOf cMnuItem Is ToolStripSeparator Then
    '                        cSep = DirectCast(cMnuItem, ToolStripSeparator)
    '                        If Not cSep.Name = "ToolStripSeparator6" Then
    '                            cSep.Visible = False
    '                        End If
    '                    End If
    '                    Me.cmnuDeleteTVEp.Visible = False
    '                Next
    '            End If
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '    End Sub



    Private Sub DonateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DonateToolStripMenuItem.Click
        If Master.isWindows Then
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=G4WN5KRET4K48")
        Else
            Using explorer As New Process
                explorer.StartInfo.FileName = "xdg-open"
                explorer.StartInfo.Arguments = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=G4WN5KRET4K48"
                explorer.Start()
            End Using
        End If
    End Sub

    '    Private Sub DoTitleCheck()
    '        Try

    '            Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                    SQLcommand.CommandText = "UPDATE movies SET OutOfTolerance = (?) WHERE ID = (?);"
    '                    Dim parOutOfTolerance As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parOutOfTolerance", DbType.Boolean, 0, "OutOfTolerance")
    '                    Dim parID As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parID", DbType.Int32, 0, "ID")
    '                    Dim LevFail As Boolean = False
    '                    Dim pTitle As String = String.Empty
    '                    For Each drvRow As DataGridViewRow In Me.dgvMediaList.Rows.Cast(Of DataGridViewRow)()

    '                        If Master.eSettings.LevTolerance > 0 Then
    '                            If FileUtils.isVideoTS(drvRow.Cells(1).Value.ToString) Then
    '                                pTitle = Directory.GetParent(Directory.GetParent(drvRow.Cells(1).Value.ToString).FullName).Name
    '                            ElseIf FileUtils.isBDRip(drvRow.Cells(1).Value.ToString) Then
    '                                pTitle = Directory.GetParent(Directory.GetParent(Directory.GetParent(drvRow.Cells(1).Value.ToString).FullName).FullName).Name
    '                            Else
    '                                If Convert.ToBoolean(drvRow.Cells(42).Value) AndAlso Convert.ToBoolean(drvRow.Cells(2).Value) Then
    '                                    pTitle = Directory.GetParent(drvRow.Cells(1).Value.ToString).Name
    '                                Else
    '                                    pTitle = Path.GetFileNameWithoutExtension(drvRow.Cells(1).Value.ToString)
    '                                End If
    '                            End If

    '                            LevFail = StringUtils.ComputeLevenshtein(StringUtils.FilterName(drvRow.Cells(15).Value.ToString, False, True).ToLower, StringUtils.FilterName(pTitle, False, True).ToLower) > Master.eSettings.LevTolerance

    '                            parOutOfTolerance.Value = LevFail
    '                            drvRow.Cells(43).Value = LevFail
    '                            parID.Value = drvRow.Cells(0).Value
    '                        Else
    '                            parOutOfTolerance.Value = False
    '                            drvRow.Cells(43).Value = False
    '                            parID.Value = drvRow.Cells(0).Value
    '                        End If
    '                        SQLcommand.ExecuteNonQuery()
    '                    Next
    '                End Using

    '                SQLtransaction.Commit()
    '            End Using

    '            Me.dgvMediaList.Invalidate()
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Sub dtListUpdate(ByVal drow As DataRow, ByVal i As Integer, ByVal v As Object)
    '        drow.Item(i) = v
    '    End Sub



    Private Sub ErrorOccurred()
        ErrorToolStripMenuItem.Visible = True
        If dlgErrorViewer.Visible Then dlgErrorViewer.UpdateLog()
    End Sub

    Private Sub ErrorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorToolStripMenuItem.Click
        dlgErrorViewer.Show(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click, cmnuTrayIconExit.Click
        If isCL Then
            'fLoading.SetLoadingMesg("Canceling ...")
            'If Me.bwMovieScraper.IsBusy Then Me.bwMovieScraper.CancelAsync()
            'If Me.bwRefreshMovies.IsBusy Then Me.bwRefreshMovies.CancelAsync()
            'While Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy OrElse Me.bwMovieScraper.IsBusy
            'Application.DoEvents()
            'Threading.Thread.Sleep(50)
            'End While
        Else
            Close()
            Application.Exit()
        End If
    End Sub



    '    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    '        Try

    '            Dim doSave As Boolean = True

    '            Me.SetControlsEnabled(False, True)
    '            Me.EnableFilters(False)

    '            Master.eSettings.Version = String.Format("r{0}", My.Application.Info.Version.Revision)

    '            If Me.fScanner.IsBusy OrElse isCL Then
    '                doSave = False
    '            End If

    '            If Me.fScanner.IsBusy Then Me.fScanner.Cancel()
    '            If Me.bwMediaInfo.IsBusy Then Me.bwMediaInfo.CancelAsync()
    '            If Me.bwLoadInfo.IsBusy Then Me.bwLoadInfo.CancelAsync()
    '            If Me.bwLoadShowInfo.IsBusy Then Me.bwLoadShowInfo.CancelAsync()
    '            If Me.bwLoadSeasonInfo.IsBusy Then Me.bwLoadSeasonInfo.CancelAsync()
    '            If Me.bwLoadEpInfo.IsBusy Then Me.bwLoadEpInfo.CancelAsync()
    '            If Me.bwDownloadPic.IsBusy Then Me.bwDownloadPic.CancelAsync()
    '            If Me.bwRefreshMovies.IsBusy Then Me.bwRefreshMovies.CancelAsync()
    '            If Me.bwCleanDB.IsBusy Then Me.bwCleanDB.CancelAsync()
    '            If Me.bwMovieScraper.IsBusy Then Me.bwMovieScraper.CancelAsync()
    '            If ModulesManager.Instance.TVIsBusy Then ModulesManager.Instance.TVCancelAsync()

    '            lblCanceling.Text = Master.eLang.GetString(99, "Canceling All Processes...")
    '            btnCancel.Visible = False
    '            lblCanceling.Visible = True
    '            pbCanceling.Visible = True
    '            pnlCancel.Visible = True
    '            Me.Refresh()

    '            While Me.fScanner.IsBusy OrElse Me.bwMediaInfo.IsBusy OrElse Me.bwLoadInfo.IsBusy _
    '            OrElse Me.bwDownloadPic.IsBusy OrElse Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy _
    '            OrElse Me.bwCleanDB.IsBusy OrElse Me.bwLoadShowInfo.IsBusy OrElse Me.bwLoadEpInfo.IsBusy _
    '            OrElse Me.bwLoadSeasonInfo.IsBusy OrElse ModulesManager.Instance.TVIsBusy
    '                Application.DoEvents()
    '                Threading.Thread.Sleep(50)
    '            End While

    '            If doSave Then Master.DB.ClearNew()

    '            If Not isCL Then
    '                Master.DB.Close()
    '            End If
    '            If Not Master.eSettings.PersistImgCache Then
    '                Me.ClearCache()
    '            End If

    '            If Not isCL Then
    '                Master.eSettings.WindowLoc = Me.Location
    '                Master.eSettings.WindowSize = Me.Size
    '                Master.eSettings.WindowState = Me.WindowState
    '                Master.eSettings.InfoPanelState = Me.aniType
    '                Master.eSettings.ShowInfoPanelState = Me.aniShowType
    '                Master.eSettings.FilterPanelState = Me.aniFilterRaise
    '                Master.eSettings.SplitterPanelState = Me.scMain.SplitterDistance
    '                Me.pnlFilter.Visible = False
    '                Master.eSettings.SeasonSplitterPanelState = Me.SplitContainer2.SplitterDistance
    '                Master.eSettings.ShowSplitterPanelState = Me.scTV.SplitterDistance
    '            End If
    '            If Not Me.WindowState = FormWindowState.Minimized Then Master.eSettings.Save()

    '        Catch ex As Exception
    '            ' If we got here, then some of the above not run. Application.Exit can not be used. 
    '            ' Because Exit will dispose object that are in use by BackgroundWorkers
    '            ' If any BackgroundWorker still running will raise exception 
    '            ' "Collection was modified; enumeration operation may not execute."
    '            ' Application.Exit()
    '        End Try
    '    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Visible = False
            fLoading = New frmSplash
            If Master.isWindows Then 'Dam mono on MacOSX don't have trayicon implemented yet
                TrayIcon = New Windows.Forms.NotifyIcon(components)
                TrayIcon.Icon = Icon
                TrayIcon.ContextMenuStrip = cmnuTrayIcon
                TrayIcon.Text = Languages.Ember_Media_Manager
                TrayIcon.Visible = True
            End If

            'Me.TrayIcon.Icon = Me.Icon
            Dim args() As String = Environment.GetCommandLineArgs

            If args.Count > 1 Then
                isCL = True
                fLoading.SetProgressBarSize(10)
            End If
            fLoading.Show(Me)
            Application.DoEvents()

            fLoading.SetLoadingMesg("Basic setup...")

            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            'ModulesManager.AssemblyList.Add(New ModulesManager.AssemblyListItem With {.AssemblyName = "EmberAPI", _
            '.Assembly = Assembly.LoadFile(Path.Combine(Functions.AppPath, "EmberAPI.dll"))})
            'AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler

            Dim sPath As String = String.Concat(Functions.AppPath, "Log", Path.DirectorySeparatorChar, "errlog.txt")
            If File.Exists(sPath) Then
                If File.Exists(sPath.Insert(sPath.LastIndexOf("."), "-old")) Then File.Delete(sPath.Insert(sPath.LastIndexOf("."), "-old"))
                FileUtils.MoveFileWithStream(sPath, sPath.Insert(sPath.LastIndexOf("."), "-old"))
                File.Delete(sPath)
            End If
            AdvancedSettings.Start()
            'Create Modules Folders
            sPath = String.Concat(Functions.AppPath, "Modules")
            If Not Directory.Exists(sPath) Then
                Directory.CreateDirectory(sPath)
            End If
            sPath = String.Concat(Functions.AppPath, "Modules", Path.DirectorySeparatorChar, "Langs")
            If Not Directory.Exists(sPath) Then
                Directory.CreateDirectory(sPath)
            End If
            fLoading.SetLoadingMesg("Loading settings...")
            Master.eSettings.Load()
            fLoading.SetLoadingMesg("Creating default options...")
            Functions.CreateDefaultOptions()
            '//
            ' Add our handlers, load settings, set form colors, and try to load movies at startup
            '\\
            fLoading.SetLoadingMesg("Loading modules...")
            'Setup/Load Modules Manager and set runtime objects (ember application) so they can be exposed to modules
            'ExternalModulesManager = New ModulesManager
            'ModulesManager.Instance.RuntimeObjects.MenuMediaList = Me.mnuMediaList
            'ModulesManager.Instance.RuntimeObjects.MenuTVShowList = Me.mnuShows
            'ModulesManager.Instance.RuntimeObjects.MediaList = Me.dgvMediaList
            'ModulesManager.Instance.RuntimeObjects.TopMenu = Me.MenuStrip
            'ModulesManager.Instance.RuntimeObjects.MainTool = Me.tsMain
            'ModulesManager.Instance.RuntimeObjects.TrayMenu = Me.cmnuTrayIcon
            'ModulesManager.Instance.RuntimeObjects.DelegateLoadMedia(AddressOf LoadMedia)
            'ModulesManager.Instance.RuntimeObjects.DelegateOpenImageViewer(AddressOf OpenImageViewer)
            'ModulesManager.Instance.LoadAllModules()
            'LoadModules()



            If Not isCL Then fLoading.SetLoadingMesg("Creating GUI...")

            'AddHandler fScanner.ScannerUpdated, AddressOf ScannerUpdated
            'AddHandler fScanner.ScanningCompleted, AddressOf ScanningCompleted
            'AddHandler ModulesManager.Instance.TVScraperEvent, AddressOf TVScraperEvent
            'AddHandler Master.eLog.ErrorOccurred, AddressOf ErrorOccurred
            'AddHandler ModulesManager.Instance.GenericEvent, AddressOf Me.GenericRunCallBack

            'Functions.DGVDoubleBuffer(Me.dgvMediaList)
            'Functions.DGVDoubleBuffer(Me.dgvTVShows)
            'Functions.DGVDoubleBuffer(Me.dgvTVSeasons)
            'Functions.DGVDoubleBuffer(Me.dgvTVEpisodes)
            SetStyle(ControlStyles.DoubleBuffer, True)
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.UserPaint, True)


            If Not Directory.Exists(Master.TempPath) Then Directory.CreateDirectory(Master.TempPath)

            If isCL Then ' Command Line
                Try
                    Dim moviePath As String = String.Empty
                    Dim isSingle As Boolean = False
                    Dim hasSpec As Boolean = False
                    Dim clScrapeType As Enums.ScrapeType = Nothing
                    Dim clExport As Boolean = False
                    Dim clExportResizePoster As Integer = 0
                    Dim clExportTemplate As String = "template"
                    Dim clAsk As Boolean = False
                    Dim nowindow As Boolean = False
                    Dim runModule As Boolean = False
                    Dim moduleName As String = String.Empty
                    For i As Integer = 1 To args.Count - 1

                        Select Case args(i).ToLower
                            Case "-fullask"
                                clScrapeType = Enums.ScrapeType.FullAsk
                                clAsk = True
                            Case "-fullauto"
                                clScrapeType = Enums.ScrapeType.FullAuto
                                clAsk = False
                            Case "-missask"
                                clScrapeType = Enums.ScrapeType.UpdateAsk
                                clAsk = True
                            Case "-missauto"
                                clScrapeType = Enums.ScrapeType.UpdateAuto
                                clAsk = False
                            Case "-newask"
                                clScrapeType = Enums.ScrapeType.NewAsk
                                clAsk = True
                            Case "-newauto"
                                clScrapeType = Enums.ScrapeType.NewAuto
                                clAsk = False
                            Case "-markask"
                                clScrapeType = Enums.ScrapeType.MarkAsk
                                clAsk = True
                            Case "-markauto"
                                clScrapeType = Enums.ScrapeType.MarkAuto
                                clAsk = False
                            Case "-file"
                                If args.Count - 1 > i Then
                                    isSingle = False
                                    hasSpec = True
                                    clScrapeType = Enums.ScrapeType.SingleScrape
                                    If File.Exists(args(i + 1).Replace("""", String.Empty)) Then
                                        moviePath = args(i + 1).Replace("""", String.Empty)
                                        i += 1
                                    End If
                                Else
                                    Exit For
                                End If
                            Case "-folder"
                                If args.Count - 1 > i Then
                                    isSingle = True
                                    hasSpec = True
                                    clScrapeType = Enums.ScrapeType.SingleScrape
                                    If File.Exists(args(i + 1).Replace("""", String.Empty)) Then
                                        moviePath = args(i + 1).Replace("""", String.Empty)
                                        i += 1
                                    End If
                                Else
                                    Exit For
                                End If
                            Case "-export"
                                If args.Count - 1 > i Then
                                    moviePath = args(i + 1).Replace("""", String.Empty)
                                    clExport = True
                                Else
                                    Exit For
                                End If
                            Case "-template"
                                If args.Count - 1 > i Then
                                    clExportTemplate = args(i + 1).Replace("""", String.Empty)
                                Else
                                    Exit For
                                End If
                            Case "-resize"
                                If args.Count - 1 > i Then
                                    clExportResizePoster = Convert.ToUInt16(args(i + 1).Replace("""", String.Empty))
                                Else
                                    Exit For
                                End If
                            Case "-all"
                                Functions.SetScraperMod(Enums.ModType.All, True)
                            Case "-nfo"
                                Functions.SetScraperMod(Enums.ModType.NFO, True)
                            Case "-posters"
                                Functions.SetScraperMod(Enums.ModType.Poster, True)
                            Case "-fanart"
                                Functions.SetScraperMod(Enums.ModType.Fanart, True)
                            Case "-extra"
                                Functions.SetScraperMod(Enums.ModType.Extra, True)
                            Case "--verbose"
                                clAsk = True
                            Case "-nowindow"
                                nowindow = True
                            Case "-run"
                                If args.Count - 1 > i Then
                                    moduleName = args(i + 1).Replace("""", String.Empty)
                                    runModule = True
                                Else
                                    Exit For
                                End If
                            Case Else
                                'If File.Exists(Args(2).Replace("""", String.Empty)) Then
                                'MoviePath = Args(2).Replace("""", String.Empty)
                                'End If
                        End Select
                    Next
                    If nowindow Then fLoading.Hide()
                    APIXML.CacheXMLs()
                    fLoading.SetLoadingMesg("Loading database...")
                    If Master.DB.CheckEssentials() Then
                        'Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
                    End If

                    Master.MovieSources.Clear()
                    Master.MovieSources.AddRange(Classes.Database.GetMovieSources())
                    Master.TVSources.Clear()
                    Master.TVSources.AddRange(Classes.Database.GetTVSources())

                    If runModule Then
                        fLoading.SetProgressBarStyle(ProgressBarStyle.Marquee)
                        fLoading.SetLoadingMesg("Running Module...")
                        Dim gModule As ModulesManager._externalGenericModuleClass = ModulesManager.Instance.externalProcessorModules.FirstOrDefault(Function(y) y.ProcessorModule.ModuleName = moduleName)
                        If Not IsNothing(gModule) Then
                            gModule.ProcessorModule.RunGeneric(Enums.ModuleEventType.CommandLine, Nothing, Nothing)
                        End If
                    End If
                    If clExport = True Then
                        ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.CommandLine, New List(Of Object)(New Object() {moviePath, clExportTemplate, clExportResizePoster}))
                        'dlgExportMovies.CLExport(MoviePath, clExportTemplate, clExportResizePoster)
                    End If

                    If Not IsNothing(clScrapeType) Then
                        cmnuTrayIconExit.Enabled = True
                        cmnuTrayIcon.Enabled = True
                        If Functions.HasModifier AndAlso Not clScrapeType = Enums.ScrapeType.SingleScrape Then
                            Try
                                fLoading.SetProgressBarStyle(ProgressBarStyle.Marquee)
                                fLoading.SetLoadingMesg("Loading Media...")
                                'LoadMedia(New Structures.Scans With {.Movies = True})
                                While Not LoadingDone
                                    Application.DoEvents()
                                    Threading.Thread.Sleep(50)
                                End While
                                fLoading.SetProgressBarStyle(ProgressBarStyle.Marquee)
                                fLoading.SetLoadingMesg("Command Line Scraping...")
                                'MovieScrapeData(False, clScrapeType, Master.DefaultOptions)
                            Catch ex As Exception
                                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                            End Try
                        Else
                            Try
                                If Not String.IsNullOrEmpty(moviePath) AndAlso hasSpec Then
                                    Master.currMovie = Classes.Database.GetMovie(moviePath)
                                    Dim tmpTitle As String = String.Empty
                                    If FileUtils.isVideoTS(moviePath) Then
                                        tmpTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(moviePath).FullName).Name, False)
                                    ElseIf FileUtils.isBDRip(moviePath) Then
                                        tmpTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(moviePath).FullName).FullName).Name, False)
                                    Else
                                        tmpTitle = StringUtils.FilterName(If(isSingle, Directory.GetParent(moviePath).Name, Path.GetFileNameWithoutExtension(moviePath)))
                                    End If
                                    If IsNothing(Master.currMovie) Then                                        
                                        Master.currMovie.FormatedTitle = tmpTitle
                                        Dim sFile As New Scanner.MovieContainer
                                        sFile.Filename = moviePath
                                        sFile.isSingle = isSingle
                                        sFile.UseFolder = isSingle
                                        'fScanner.GetMovieFolderContents(sFile)
                                        If Not String.IsNullOrEmpty(sFile.Nfo) Then
                                            Master.currMovie = NFO.LoadMovieFromNFO(sFile.Nfo, sFile.isSingle)
                                        Else
                                            Master.currMovie = NFO.LoadMovieFromNFO(sFile.Filename, sFile.isSingle)
                                        End If
                                        If String.IsNullOrEmpty(Master.currMovie.Title) Then
                                            'no title so assume it's an invalid nfo, clear nfo path if exists
                                            sFile.Nfo = String.Empty
                                            If FileUtils.isVideoTS(sFile.Filename) Then
                                                Master.currMovie.ListTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(sFile.Filename).FullName).Name)
                                            ElseIf FileUtils.isBDRip(sFile.Filename) Then
                                                Master.currMovie.ListTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(sFile.Filename).FullName).FullName).Name)
                                            Else
                                                If sFile.UseFolder AndAlso sFile.isSingle Then
                                                    Master.currMovie.ListTitle = StringUtils.FilterName(Directory.GetParent(sFile.Filename).Name)
                                                Else
                                                    Master.currMovie.ListTitle = StringUtils.FilterName(Path.GetFileNameWithoutExtension(sFile.Filename))
                                                End If
                                            End If
                                            If String.IsNullOrEmpty(Master.currMovie.SortTitle) Then Master.currMovie.SortTitle = Master.currMovie.ListTitle
                                        Else
                                            Dim tTitle As String = StringUtils.FilterTokens(Master.currMovie.Title)
                                            If String.IsNullOrEmpty(Master.currMovie.SortTitle) Then Master.currMovie.SortTitle = tTitle
                                            If Master.eSettings.DisplayYear AndAlso Not String.IsNullOrEmpty(Master.currMovie.Year) Then
                                                Master.currMovie.ListTitle = String.Format("{0} ({1})", tTitle, Master.currMovie.Year)
                                            Else
                                                Master.currMovie.ListTitle = tTitle
                                            End If
                                        End If

                                        If Not String.IsNullOrEmpty(Master.currMovie.ListTitle) Then
                                            Master.currMovie.NfoPath = sFile.Nfo
                                            Master.currMovie.PosterPath = sFile.Poster
                                            Master.currMovie.FanartPath = sFile.Fanart
                                            Master.currMovie.TrailerPath = sFile.Trailer
                                            Master.currMovie.SubPath = sFile.Subs
                                            Master.currMovie.ExtraPath = sFile.Extra
                                            Master.currMovie.MoviePath = sFile.Filename
                                            'Master.currMovie. = sFile.isSingle
                                            Master.currMovie.UseFolder = sFile.UseFolder
                                            Master.currMovie.Source = sFile.Source
                                        End If
                                        Master.tmpMovie = Master.currMovie
                                    End If
                                    fLoading.SetProgressBarStyle(ProgressBarStyle.Marquee)
                                    fLoading.SetLoadingMesg("Command Line Scraping...")
                                    'MovieScrapeData(False, Enums.ScrapeType.SingleScrape, Master.DefaultOptions)
                                Else
                                    Me.ScraperDone = True
                                End If
                            Catch ex As Exception
                                Me.ScraperDone = True
                                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                            End Try
                        End If

                        While Not Me.ScraperDone
                            Application.DoEvents()
                            Threading.Thread.Sleep(50)
                        End While
                    End If

                    frmSplash.Close()
                    Me.Close()
                Catch ex As Exception
                End Try

            Else 'Regular Run (GUI)
                Try
                    'If Master.eSettings.CheckUpdates Then
                    '    If Functions.CheckNeedUpdate() Then
                    '        Using dNewVer As New dlgNewVersion
                    '            fLoading.Hide()
                    '            If dNewVer.ShowDialog() = Windows.Forms.DialogResult.Abort Then
                    '                tmrAppExit.Enabled = True
                    '                CloseApp = True
                    '            End If
                    '        End Using
                    '    End If

                    'End If
                    If Not CloseApp Then
                        fLoading.SetLoadingMesg("Loading translations...")
                        APIXML.CacheXMLs()

                        'Me.SetUp(True)
                        'Me.cbSearch.SelectedIndex = 0

                        fLoading.SetLoadingMesg("Positioning controls...")
                        Me.Location = Master.eSettings.WindowLoc
                        Me.Size = Master.eSettings.WindowSize
                        Me.WindowState = Master.eSettings.WindowState

                        'Me.aniType = 
                        'Select Master.eSettings.InfoPanelState
                        '    Case 0

                        '        'Me.pnlInfoPanel.Height = 25
                        '        '        Me.btnDown.Enabled = False
                        '        '        Me.btnMid.Enabled = True
                        '        '        Me.btnUp.Enabled = True
                        '        '    Case 1
                        '        '        Me.pnlInfoPanel.Height = Me.IPMid
                        '        '        Me.btnMid.Enabled = False
                        '        '        Me.btnDown.Enabled = True
                        '        '        Me.btnUp.Enabled = True
                        '        '    Case 2
                        '        '        Me.pnlInfoPanel.Height = Me.IPUp
                        '        '        Me.btnUp.Enabled = False
                        '        '        Me.btnDown.Enabled = True
                        '        '        Me.btnMid.Enabled = True
                        '        'End Select

                        'Me.aniShowType = Master.eSettings.ShowInfoPanelState

                        'Me.aniFilterRaise = Master.eSettings.FilterPanelState
                        'If Me.aniFilterRaise Then
                        '    Me.pnlFilter.Height = Functions.Quantize(Me.gbSpecific.Height + Me.lblFilter.Height + 15, 5)
                        '    Me.btnFilterDown.Enabled = True
                        '    Me.btnFilterUp.Enabled = False
                        'Else
                        '    Me.pnlFilter.Height = 25
                        '    Me.btnFilterDown.Enabled = False
                        '    Me.btnFilterUp.Enabled = True
                        'End If
                        Try ' On error just ignore this a let it use default
                            Me.scMain.SplitterDistance = Master.eSettings.SplitterPanelState
                            'Me.SplitContainer2.SplitterDistance = Master.eSettings.SeasonSplitterPanelState
                        Catch ex As Exception
                        End Try
                        'Me.pnlFilter.Visible = True

                        'Me.ClearInfo()

                        Application.DoEvents()
                        fLoading.SetLoadingMesg("Loading database...")
                        If Master.eSettings.Version = String.Format("r{0}", My.Application.Info.Version.Revision) Then
                            If Master.DB.CheckEssentials() Then
                                'Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
                            End If
                            ucSidePanel.PopulateMovies()
                            Me.Visible = True
                        Else
                            If Master.DB.CheckEssentials() Then
                                'Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
                            End If
                            If dlgWizard.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Application.DoEvents()
                                'Me.SetUp(False) 'just in case user changed languages
                                Me.Visible = True
                                'Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
                            Else
                                ucSidePanel.PopulateMovies()
                                Me.Visible = True
                            End If
                        End If

                        Dim appPath As String = Application.StartupPath + Path.DirectorySeparatorChar.ToString()
                        Dim cacheFolder As String = appPath + "cache" + Path.DirectorySeparatorChar.ToString()
                        Dim scrapersFolder As String = appPath + "scrapers" + Path.DirectorySeparatorChar.ToString()
                        'subscribe to log first
                        Master.ScraperMan = New ScraperManager(scrapersFolder, cacheFolder)

                        Master.MovieSources.Clear()
                        Master.MovieSources.AddRange(Classes.Database.GetMovieSources())
                        Master.TVSources.Clear()
                        Master.TVSources.AddRange(Classes.Database.GetTVSources())
                        fLoading.SetLoadingMesg("Setting menus...")
                        'Me.SetMenus(True)
                        Functions.GetListOfSources()
                        Me.cmnuTrayIconExit.Enabled = True
                        Me.cmnuTrayIconSettings.Enabled = True
                        Me.EditToolStripMenuItem.Enabled = True
                        'If tsbMediaCenters.DropDownItems.Count > 0 Then tsbMediaCenters.Enabled = True
                        pnlhInfo.Expand = False
                    End If
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                End Try

            End If

            fLoading.Close()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub MediaItemSelected(sender As Object, e As SidePanel.MediaSelectedArgs) Handles ucSidePanel.MediaItemSelected
        CurrentMedia = e.SelectedMedia
        SetStatus(e.StatusText)
        pnlImages.LoadInfo(CurrentMedia)
        pnlInfoPanel.LoadInfo(CurrentMedia)
        LoadInfo()
    End Sub

    Private Sub LoadInfo()
        Select Case ObjectContext.GetObjectType(CurrentMedia.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(CurrentMedia, Model.Movie)
        End Select
    End Sub


    '    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '        Try
    '            If Me.Created Then
    '                Me.MoveMPAA()
    '                Me.MoveGenres()
    '                ImageUtils.ResizePB(Me.pbFanart, Me.pbFanartCache, Me.scMain.Panel2.Height - 90, Me.scMain.Panel2.Width)
    '                Me.pbFanart.Left = Convert.ToInt32((Me.scMain.Panel2.Width - Me.pbFanart.Width) / 2)
    '                Me.pnlNoInfo.Location = New Point(Convert.ToInt32((Me.scMain.Panel2.Width - Me.pnlNoInfo.Width) / 2), Convert.ToInt32((Me.scMain.Panel2.Height - Me.pnlNoInfo.Height) / 2))
    '                Me.pnlCancel.Location = New Point(Convert.ToInt32((Me.scMain.Panel2.Width - Me.pnlNoInfo.Width) / 2), 100)
    '                Me.pnlFilterGenre.Location = New Point(Me.gbSpecific.Left + Me.txtFilterGenre.Left, (Me.pnlFilter.Top + Me.txtFilterGenre.Top + Me.gbSpecific.Top) - Me.pnlFilterGenre.Height)
    '                Me.pnlFilterSource.Location = New Point(Me.gbSpecific.Left + Me.txtFilterSource.Left, (Me.pnlFilter.Top + Me.txtFilterSource.Top + Me.gbSpecific.Top) - Me.pnlFilterSource.Height)
    '                Me.pnlLoadingSettings.Location = New Point(Convert.ToInt32((Me.Width - Me.pnlLoadingSettings.Width) / 2), Convert.ToInt32((Me.Height - Me.pnlLoadingSettings.Height) / 2))
    '                Me.pnlAllSeason.Location = New Point(Me.pbFanart.Width - Me.pnlAllSeason.Width - 9, 112)
    '            End If
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    '    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '        If Not CloseApp Then
    '            Me.BringToFront()
    '            Me.Activate()
    '            Me.cmnuTrayIcon.Enabled = True
    '            If Not Functions.CheckIfWindows Then Mono_Shown()
    '        End If
    '    End Sub

    '    Private Sub GenericRunCallBack(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object))
    '        Select Case mType
    '            Case Enums.ModuleEventType.Generic
    '                Select Case _params(0).ToString
    '                    Case "controlsenabled"
    '                        Me.SetControlsEnabled(Convert.ToBoolean(_params(1)), If(_params.Count = 3, Convert.ToBoolean(_params(2)), False))
    '                End Select
    '            Case Enums.ModuleEventType.Notification
    '                Select Case _params(0).ToString
    '                    Case "error"
    '                        dlgErrorViewer.Show(Me)
    '                    Case Else
    '                        Me.Activate()
    '                End Select
    '            Case Enums.ModuleEventType.RenameMovie
    '                Try
    '                    Me.SetListItemAfterEdit(Convert.ToInt16(_params(0)), Convert.ToInt16(_params(1)))
    '                    If Me.RefreshMovie(Convert.ToInt16(_params(0))) Then
    '                        Me.FillList(0)
    '                    End If
    '                    Me.SetStatus(Master.currMovie.Filename)
    '                Catch ex As Exception
    '                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
    '                End Try
    '            Case Enums.ModuleEventType.RenameMovieManual
    '                Try
    '                    Me.SetListItemAfterEdit(Convert.ToInt16(_params(0)), Convert.ToInt16(_params(1)))
    '                    If Me.RefreshMovie(Convert.ToInt16(_params(0))) Then
    '                        Me.FillList(0)
    '                    End If
    '                    Me.SetStatus(Master.currMovie.Filename)
    '                Catch ex As Exception
    '                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
    '                End Try
    '        End Select
    '    End Sub


    '    Private Sub mnuAllAskAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskAll.Click, mnuTrayAllAskAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskExtra.Click, mnuTrayAllAskExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskFanart.Click, mnuTrayAllAskFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskNfo.Click, mnuTrayAllAskNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskPoster.Click, mnuTrayAllAskPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAskTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAskTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoAll.Click, mnuTrayAllAutoAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoExtra.Click, mnuTrayAllAutoExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoFanart.Click, mnuTrayAllAutoFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoNfo.Click, mnuTrayAllAutoNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoPoster.Click, mnuTrayAllAutoPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuAllAutoTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllAutoTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FullAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskAll.Click, mnuTrayFilterAskAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskExtra.Click, mnuTrayFilterAskExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskFanart.Click, mnuTrayFilterAskFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskMI.Click, mnuTrayFilterAskMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskNfo.Click, mnuTrayFilterAskNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskPoster.Click, mnuTrayFilterAskPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAskTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAskTrailer.Click, mnuTrayFilterAskTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoAll.Click, mnuTrayFilterAutoAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoExtra.Click, mnuTrayFilterAutoExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoFanart.Click, mnuTrayFilterAutoFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoMI.Click, mnuTrayFilterAutoMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoNfo.Click, mnuTrayFilterAutoNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoPoster.Click, mnuTrayFilterAutoPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuFilterAutoTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilterAutoTrailer.Click, mnuTrayFilterAutoTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.FilterAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskAll.Click, mnuTrayMarkAskAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskExtra.Click, mnuTrayMarkAskExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskFanart.Click, mnuTrayMarkAskFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskNfo.Click, mnuTrayMarkAskNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskPoster.Click, mnuTrayMarkAskPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAskTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAskTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoAll.Click, mnuTrayMarkAutoAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        'Me.ScrapeData(Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoExtra.Click, mnuTrayMarkAutoExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoFanart.Click, mnuTrayMarkAutoFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoNfo.Click, mnuTrayMarkAutoNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        'Me.ScrapeData(Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoPoster.Click, mnuTrayMarkAutoPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMarkAutoTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarkAutoTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.MarkAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskAll.Click, mnuTrayMissAskAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskExtra.Click, mnuTrayMissAskExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskFanart.Click, mnuTrayMissAskFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskNfo.Click, mnuTrayMissAskNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskPoster.Click, mnuTrayMissAskPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAskTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAskTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoAll.Click, mnuTrayMissAutoAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoExtra.Click, mnuTrayMissAutoExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoFanart.Click, mnuTrayMissAutoFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoNfo.Click, mnuTrayMissAutoNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoPoster.Click, mnuTrayMissAutoPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuMissAutoTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMissAutoTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.UpdateAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskAll.Click, mnuTrayNewAskAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskExtra.Click, mnuTrayNewAskExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        'Me.ScrapeData(Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskFanart.Click, mnuTrayNewAskFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskNfo.Click, mnuTrayNewAskNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskPoster.Click, mnuTrayNewAskPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAskTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAskTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoAll.Click, mnuTrayNewAutoAll.Click
    '        Functions.SetScraperMod(Enums.ModType.All, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoExtra.Click, mnuTrayNewAutoExtra.Click
    '        Functions.SetScraperMod(Enums.ModType.Extra, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoFanart.Click, mnuTrayNewAutoFanart.Click
    '        Functions.SetScraperMod(Enums.ModType.Fanart, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoMI.Click
    '        Functions.SetScraperMod(Enums.ModType.Meta, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoNfo.Click, mnuTrayNewAutoNfo.Click
    '        Functions.SetScraperMod(Enums.ModType.NFO, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoPoster.Click, mnuTrayNewAutoPoster.Click
    '        Functions.SetScraperMod(Enums.ModType.Poster, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub mnuNewAutoTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewAutoTrailer.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        Me.MovieScrapeData(False, Enums.ScrapeType.NewAuto, Master.DefaultOptions)
    '    End Sub

    '    Private Sub Mono_Shown()
    '        Me.pnlNoInfo.Location = New Point(Convert.ToInt32((Me.scMain.Panel2.Width - Me.pnlNoInfo.Width) / 2), Convert.ToInt32((Me.scMain.Panel2.Height - Me.pnlNoInfo.Height) / 2))
    '    End Sub


    '    

    '    Private Sub MovieInfoDownloaded()
    '        Try
    '            If Not String.IsNullOrEmpty(Master.tmpMovie.Title) Then
    '                Master.currMovie.Movie = Master.tmpMovie
    '                If Master.eSettings.ScanMediaInfo Then
    '                    Me.tslLoading.Text = Master.eLang.GetString(140, "Scanning Meta Data:")
    '                    Me.tspbLoading.Value = Me.tspbLoading.Maximum
    '                    Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                    Application.DoEvents()
    '                    MediaInfo.UpdateMediaInfo(Master.currMovie)
    '                End If

    '                If Master.eSettings.SingleScrapeImages Then
    '                    Dim tmpImages As New Images
    '                    Dim AllowFA As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Fanart) AndAlso tmpImages.IsAllowedToDownload(Master.currMovie, Enums.ImageType.Fanart, True)

    '                    If ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Poster) AndAlso tmpImages.IsAllowedToDownload(Master.currMovie, Enums.ImageType.Posters, True) Then
    '                        Me.tslLoading.Text = Master.eLang.GetString(572, "Scraping Posters:")
    '                        Application.DoEvents()
    '                        Dim pResults As New Containers.ImgResult
    '                        ModulesManager.Instance.ScraperSelectImageOfType(Master.currMovie, Enums.ImageType.Posters, pResults, True, AllowFA)
    '                        If Not String.IsNullOrEmpty(pResults.ImagePath) Then
    '                            Master.currMovie.PosterPath = pResults.ImagePath
    '                            If Not Master.eSettings.NoSaveImagesToNfo AndAlso pResults.Posters.Count > 0 Then Master.currMovie.Movie.Thumb = pResults.Posters
    '                        End If
    '                        pResults = Nothing
    '                    End If

    '                    If AllowFA Then
    '                        Me.tslLoading.Text = Master.eLang.GetString(573, "Scraping Fanart:")
    '                        Application.DoEvents()
    '                        Dim fResults As New Containers.ImgResult
    '                        ModulesManager.Instance.ScraperSelectImageOfType(Master.currMovie, Enums.ImageType.Fanart, fResults, True, True)
    '                        If Not String.IsNullOrEmpty(fResults.ImagePath) Then
    '                            Master.currMovie.FanartPath = fResults.ImagePath
    '                            If Not Master.eSettings.NoSaveImagesToNfo AndAlso fResults.Fanart.Thumb.Count > 0 Then Master.currMovie.Movie.Fanart = fResults.Fanart
    '                        End If
    '                        fResults = Nothing
    '                    End If

    '                    tmpImages.Dispose()
    '                    tmpImages = Nothing
    '                End If

    '                If Master.eSettings.SingleScrapeTrailer AndAlso ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Trailer) Then
    '                    Me.tslLoading.Text = Master.eLang.GetString(574, "Scraping Trailers:")
    '                    Application.DoEvents()
    '                    Dim tURL As String = ModulesManager.Instance.ScraperDownloadTrailer(Master.currMovie)
    '                    ' If Not String.IsNullOrEmpty(tURL) AndAlso tURL.Contains("://") Then
    '                    If Not String.IsNullOrEmpty(tURL) AndAlso tURL.Substring(0, 7) = "http://" Then
    '                        Master.currMovie.Movie.Trailer = tURL
    '                    ElseIf Not String.IsNullOrEmpty(tURL) AndAlso tURL.Substring(0, 9) = "plugin://" Then
    '                        Master.currMovie.Movie.Trailer = tURL
    '                    End If
    '                End If

    '                If Master.eSettings.AutoThumbs > 0 AndAlso Master.currMovie.isSingle Then
    '                    Me.tslLoading.Text = Master.eLang.GetString(575, "Generating Extrathumbs:")
    '                    Application.DoEvents()
    '                    'ThumbGenerator.CreateRandomThumbs(Master.currMovie, Master.eSettings.AutoThumbs, True)
    '                    Dim params As New List(Of Object)(New Object() {Master.currMovie, Master.eSettings.AutoThumbs, True, ""})
    '                    ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.RandomFrameExtrator, params, Nothing, True)
    '                    MovieScraperEvent(Enums.MovieScraperEventType.ThumbsItem, True)
    '                    Dim ETasFA As String = DirectCast(params(3), String)
    '                    If Not String.IsNullOrEmpty(ETasFA) Then
    '                        Master.currMovie.ExtraPath = "TRUE"
    '                        If Not ETasFA = "TRUE" Then
    '                            Master.currMovie.FanartPath = ETasFA
    '                        End If
    '                    End If
    '                End If
    '                Me.tslLoading.Text = Master.eLang.GetString(568, "Generating Actors Cache:")
    '                If Master.GlobalScrapeMod.Actors AndAlso AdvancedSettings.GetBooleanSetting("ScrapeActorsThumbs", False) Then
    '                    For Each act As MediaContainers.Person In Master.currMovie.Movie.Actors
    '                        Dim img As New Images
    '                        img.FromWeb(act.Thumb)
    '                        img.SaveAsActorThumb(act, Directory.GetParent(Master.currMovie.Filename).FullName)
    '                    Next
    '                End If

    '                Dim indX As Integer = Me.dgvMediaList.SelectedRows(0).Index
    '                Dim ID As Integer = Convert.ToInt32(Me.dgvMediaList.Item(0, indX).Value)

    '                Me.tslLoading.Text = Master.eLang.GetString(576, "Verifying Movie Details:")
    '                Application.DoEvents()

    '                Using dEditMovie As New dlgEditMovie
    '                    AddHandler ModulesManager.Instance.GenericEvent, AddressOf dEditMovie.GenericRunCallBack
    '                    Select Case dEditMovie.ShowDialog()
    '                        Case Windows.Forms.DialogResult.OK
    '                            ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieScraperRDYtoSave, Nothing, Master.currMovie)
    '                            Me.SetListItemAfterEdit(ID, indX)
    '                            If Me.RefreshMovie(ID) Then
    '                                Me.FillList(0)
    '                            End If
    '                            ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.MovieSync, Nothing, Master.currMovie)
    '                        Case Windows.Forms.DialogResult.Retry
    '                            Master.currMovie.ClearExtras = False
    '                            Functions.SetScraperMod(Enums.ModType.All, True, True)
    '                            Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions) ', ID)
    '                        Case Windows.Forms.DialogResult.Abort
    '                            Master.currMovie.ClearExtras = False
    '                            Functions.SetScraperMod(Enums.ModType.DoSearch, True)
    '                            Functions.SetScraperMod(Enums.ModType.All, True, False)
    '                            Me.MovieScrapeData(True, Enums.ScrapeType.SingleScrape, Master.DefaultOptions) ', ID, True)
    '                        Case Else
    '                            If Me.InfoCleared Then Me.LoadInfo(ID, Me.dgvMediaList.Item(1, indX).Value.ToString, True, False)
    '                    End Select
    '                    RemoveHandler ModulesManager.Instance.GenericEvent, AddressOf dEditMovie.GenericRunCallBack
    '                End Using

    '            End If
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '        Master.currMovie.ClearExtras = False

    '        Me.pnlCancel.Visible = False
    '        Me.tslLoading.Visible = False
    '        Me.tspbLoading.Visible = False
    '        Me.SetStatus(String.Empty)
    '        Me.SetControlsEnabled(True)
    '        Me.EnableFilters(True)
    '    End Sub

    '    Private Sub MovieInfoDownloadedPercent(ByVal iPercent As Integer)
    '        If Me.ReportDownloadPercent = True Then
    '            Me.tspbLoading.Value = iPercent
    '            Me.Refresh()
    '        End If
    '    End Sub

    '    Private Sub MovieScrapeData(ByVal selected As Boolean, ByVal sType As Enums.ScrapeType, ByVal Options As Structures.ScrapeOptions)
    '        ScrapeList.Clear()
    '        If selected Then
    '            'create snapshoot list of selected movies
    '            For Each sRow As DataGridViewRow In Me.dgvMediaList.SelectedRows
    '                ScrapeList.Add(DirectCast(sRow.DataBoundItem, DataRowView).Row)
    '            Next
    '        Else
    '            Dim PosterAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Poster)
    '            Dim FanartAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Fanart)
    '            Dim TrailerAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Trailer)

    '            'create list of movies acording to scrapetype
    '            For Each drvRow As DataRow In Me.dtMedia.Rows

    '                If Convert.ToBoolean(drvRow.Item(14)) Then Continue For

    '                Select Case sType
    '                    Case Enums.ScrapeType.NewAsk, Enums.ScrapeType.NewAuto
    '                        If Not Convert.ToBoolean(drvRow.Item(10)) Then Continue For
    '                    Case Enums.ScrapeType.MarkAsk, Enums.ScrapeType.MarkAuto
    '                        If Not Convert.ToBoolean(drvRow.Item(11)) Then Continue For
    '                    Case Enums.ScrapeType.FilterAsk, Enums.ScrapeType.FilterAuto
    '                        Dim index As Integer = Me.bsMedia.Find("id", drvRow.Item(0))
    '                        If Not index >= 0 Then Continue For
    '                    Case Enums.ScrapeType.UpdateAsk, Enums.ScrapeType.UpdateAuto
    '                        If Not ((Master.GlobalScrapeMod.Poster AndAlso Master.eSettings.MissingFilterPoster AndAlso PosterAllowed AndAlso Not Convert.ToBoolean(drvRow.Item(4))) OrElse _
    '                                (Master.GlobalScrapeMod.Fanart AndAlso Master.eSettings.MissingFilterFanart AndAlso FanartAllowed AndAlso Not Convert.ToBoolean(drvRow.Item(5))) OrElse _
    '                                (Master.GlobalScrapeMod.NFO AndAlso Master.eSettings.MissingFilterNFO AndAlso Not Convert.ToBoolean(drvRow.Item(6))) OrElse _
    '                                (Master.GlobalScrapeMod.Trailer AndAlso Master.eSettings.MissingFilterTrailer AndAlso TrailerAllowed AndAlso Not Convert.ToBoolean(drvRow.Item(7))) OrElse _
    '                                (Master.GlobalScrapeMod.Extra AndAlso Master.eSettings.MissingFilterExtras AndAlso (Master.eSettings.AutoET OrElse Master.eSettings.AutoThumbs > 0) AndAlso Not Convert.ToBoolean(drvRow.Item(9)))) Then
    '                            Continue For
    '                        End If
    '                End Select

    '                ScrapeList.Add(drvRow)
    '            Next
    '        End If

    '        Me.SetControlsEnabled(False)

    '        Me.tspbLoading.Value = 0
    '        If ScrapeList.Count > 1 Then
    '            Me.tspbLoading.Style = ProgressBarStyle.Continuous
    '            Me.tspbLoading.Maximum = ScrapeList.Count
    '        Else
    '            Me.tspbLoading.Maximum = 100
    '            Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '        End If

    '        Select Case sType
    '            Case Enums.ScrapeType.FullAsk
    '                Me.tslLoading.Text = Master.eLang.GetString(127, "Scraping Media (All Movies - Ask):")
    '            Case Enums.ScrapeType.FullAuto
    '                Me.tslLoading.Text = Master.eLang.GetString(128, "Scraping Media (All Movies - Auto):")
    '            Case Enums.ScrapeType.UpdateAuto
    '                Me.tslLoading.Text = Master.eLang.GetString(132, "Scraping Media (Movies Missing Items - Auto):")
    '            Case Enums.ScrapeType.UpdateAsk
    '                Me.tslLoading.Text = Master.eLang.GetString(133, "Scraping Media (Movies Missing Items - Ask):")
    '            Case Enums.ScrapeType.FilterAsk
    '                Me.tslLoading.Text = Master.eLang.GetString(622, "Scraping Media (Current Filter - Ask):")
    '            Case Enums.ScrapeType.FilterAuto
    '                Me.tslLoading.Text = Master.eLang.GetString(623, "Scraping Media (Current Filter - Auto):")
    '            Case Enums.ScrapeType.SingleScrape
    '                Me.tslLoading.Text = Master.eLang.GetString(139, "Scraping:")
    '        End Select

    '        If Not sType = Enums.ScrapeType.SingleScrape Then
    '            Me.btnCancel.Text = Master.eLang.GetString(126, "Cancel Scraper")
    '            Me.lblCanceling.Text = Master.eLang.GetString(125, "Canceling Scraper...")
    '            Me.btnCancel.Visible = True
    '            Me.lblCanceling.Visible = False
    '            Me.pbCanceling.Visible = False
    '            Me.pnlCancel.Visible = True
    '        End If

    '        Me.tslLoading.Visible = True
    '        Me.tspbLoading.Visible = True
    '        Application.DoEvents()
    '        bwMovieScraper.WorkerSupportsCancellation = True
    '        bwMovieScraper.WorkerReportsProgress = True
    '        bwMovieScraper.RunWorkerAsync(New Arguments With {.scrapeType = sType, .Options = Options})
    '    End Sub

    '    Private Sub MovieScraperEvent(ByVal eType As Enums.MovieScraperEventType, ByVal Parameter As Object)
    '        If (Me.InvokeRequired) Then
    '            Me.Invoke(New DelegateEvent(AddressOf MovieScraperEvent), New Object() {eType, Parameter})
    '        Else
    '            Select Case eType
    '                Case Enums.MovieScraperEventType.PosterItem
    '                    dScrapeRow.Item(4) = DirectCast(Parameter, Boolean)
    '                Case Enums.MovieScraperEventType.FanartItem
    '                    dScrapeRow.Item(5) = DirectCast(Parameter, Boolean)
    '                Case Enums.MovieScraperEventType.NFOItem
    '                    dScrapeRow.Item(6) = DirectCast(Parameter, Boolean)
    '                Case Enums.MovieScraperEventType.TrailerItem
    '                    dScrapeRow.Item(7) = DirectCast(Parameter, Boolean)
    '                Case Enums.MovieScraperEventType.ThumbsItem
    '                    dScrapeRow.Item(9) = DirectCast(Parameter, Boolean)
    '                Case Enums.MovieScraperEventType.SortTitle
    '                    dScrapeRow.Item(47) = DirectCast(Parameter, String)
    '                Case Enums.MovieScraperEventType.ListTitle
    '                    dScrapeRow.Item(3) = DirectCast(Parameter, String)

    '            End Select
    '            Me.dgvMediaList.Invalidate()
    '        End If
    '    End Sub

    '    Function MyResolveEventHandler(ByVal sender As Object, ByVal args As ResolveEventArgs) As [Assembly]
    '        Dim name As String = args.Name.Split(Convert.ToChar(","))(0)
    '        Dim asm As Assembly = ModulesManager.AssemblyList.FirstOrDefault(Function(y) y.AssemblyName = name).Assembly
    '        If asm Is Nothing Then
    '            asm = ModulesManager.AssemblyList.FirstOrDefault(Function(y) y.AssemblyName = name.Split(Convert.ToChar("."))(0)).Assembly
    '        End If
    '        Return asm
    '    End Function

    '    Private Sub NonScrape(ByVal sType As Enums.ScrapeType, ByVal Options As Structures.ScrapeOptions)
    '        Me.Cursor = Cursors.WaitCursor

    '        Select Case sType
    '            Case Enums.ScrapeType.CleanFolders
    '                Me.btnCancel.Text = Master.eLang.GetString(120, "Cancel Cleaner")
    '                Me.lblCanceling.Text = Master.eLang.GetString(119, "Canceling File Cleaner...")
    '                Me.tslLoading.Text = Master.eLang.GetString(129, "Cleaning Files:")
    '            Case Enums.ScrapeType.CopyBD
    '                Me.btnCancel.Text = Master.eLang.GetString(122, "Cancel Copy")
    '                Me.lblCanceling.Text = Master.eLang.GetString(121, "Canceling Backdrop Copy...")
    '                Me.tslLoading.Text = Master.eLang.GetString(130, "Copying Fanart to Backdrops Folder:")
    '        End Select

    '        btnCancel.Visible = True
    '        lblCanceling.Visible = False
    '        pbCanceling.Visible = False
    '        Me.pnlCancel.Visible = True
    '        Me.tslLoading.Visible = True
    '        Me.tspbLoading.Value = 0
    '        Me.tspbLoading.Maximum = Me.dtMedia.Rows.Count
    '        Me.tspbLoading.Visible = True
    '        Me.SetControlsEnabled(False, True)
    '        Me.EnableFilters(False)

    '        bwNonScrape.WorkerReportsProgress = True
    '        bwNonScrape.WorkerSupportsCancellation = True
    '        bwNonScrape.RunWorkerAsync(New Arguments With {.scrapeType = sType, .Options = Options})
    '    End Sub


    '    Private Sub OpenImageViewer(ByVal _Image As Image)
    '        Using dImgView As New dlgImgView
    '            dImgView.ShowDialog(_Image)
    '        End Using
    '    End Sub





    '    Private Sub RefreshAllMovies()
    '        If Me.dtMedia.Rows.Count > 0 Then
    '            Me.Cursor = Cursors.WaitCursor
    '            Me.SetControlsEnabled(False, True)
    '            Me.tspbLoading.Style = ProgressBarStyle.Continuous
    '            Me.EnableFilters(False)

    '            Me.tspbLoading.Maximum = Me.dtMedia.Rows.Count + 1
    '            Me.tspbLoading.Value = 0
    '            Me.tslLoading.Text = Master.eLang.GetString(110, "Refreshing Media:")
    '            Me.tspbLoading.Visible = True
    '            Me.tslLoading.Visible = True

    '            Me.bwRefreshMovies.WorkerReportsProgress = True
    '            Me.bwRefreshMovies.WorkerSupportsCancellation = True
    '            Me.bwRefreshMovies.RunWorkerAsync()
    '        Else
    '            Me.SetControlsEnabled(True)
    '        End If
    '    End Sub

    '    Private Sub RefreshAllMoviesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshAllMoviesToolStripMenuItem.Click, ReloadAllMoviesToolStripMenuItem.Click
    '        RefreshAllMovies()
    '    End Sub

    '    Private Function RefreshEpisode(ByVal ID As Long, Optional ByVal BatchMode As Boolean = False, Optional ByVal FromNfo As Boolean = True, Optional ByVal ToNfo As Boolean = False) As Boolean
    '        Dim tmpShowDb As New Structures.DBTV
    '        Dim tmpEp As New MediaContainers.EpisodeDetails
    '        Dim SeasonChanged As Boolean = False
    '        Dim EpisodeChanged As Boolean = False
    '        Dim ShowID As Integer = -1
    '        Dim myDelegate As New MydtListUpdate(AddressOf dtListUpdate)

    '        Try

    '            tmpShowDb = Master.DB.LoadTVEpFromDB(ID, True)

    '            If Directory.Exists(tmpShowDb.ShowPath) Then

    '                If FromNfo Then
    '                    If String.IsNullOrEmpty(tmpShowDb.EpNfoPath) Then
    '                        Dim sNFO As String = NFO.GetEpNfoPath(tmpShowDb.Filename)
    '                        tmpShowDb.EpNfoPath = sNFO
    '                        tmpEp = NFO.LoadTVEpFromNFO(sNFO, tmpShowDb.TVEp.Season, tmpShowDb.TVEp.Episode)
    '                    Else
    '                        tmpEp = NFO.LoadTVEpFromNFO(tmpShowDb.EpNfoPath, tmpShowDb.TVEp.Season, tmpShowDb.TVEp.Episode)
    '                    End If
    '                    tmpShowDb.TVEp = tmpEp
    '                End If

    '                If String.IsNullOrEmpty(tmpShowDb.TVEp.Title) Then
    '                    tmpShowDb.TVEp.Title = StringUtils.FilterTVEpName(Path.GetFileNameWithoutExtension(tmpShowDb.Filename), tmpShowDb.TVShow.Title, False)
    '                End If

    '                Dim eContainer As New Scanner.EpisodeContainer With {.Filename = tmpShowDb.Filename}
    '                fScanner.GetEpFolderContents(eContainer)
    '                tmpShowDb.EpPosterPath = eContainer.Poster
    '                tmpShowDb.EpFanartPath = eContainer.Fanart
    '                'assume invalid nfo if no title
    '                tmpShowDb.EpNfoPath = If(String.IsNullOrEmpty(tmpShowDb.TVEp.Title), String.Empty, eContainer.Nfo)

    '                Dim dRow = From drvRow In dtEpisodes.Rows Where Convert.ToInt64(DirectCast(drvRow, DataRow).Item(0)) = ID Select drvRow

    '                If Not IsNothing(dRow(0)) Then
    '                    tmpShowDb.IsMarkEp = Convert.ToBoolean(DirectCast(dRow(0), DataRow).Item(8))
    '                    tmpShowDb.IsLockEp = Convert.ToBoolean(DirectCast(dRow(0), DataRow).Item(11))

    '                    If Not Convert.ToInt32(DirectCast(dRow(0), DataRow).Item(12)) = tmpShowDb.TVEp.Season Then
    '                        SeasonChanged = True
    '                        ShowID = Convert.ToInt32(tmpShowDb.ShowID)
    '                    End If

    '                    If Not Convert.ToInt32(DirectCast(dRow(0), DataRow).Item(2)) = tmpShowDb.TVEp.Episode Then
    '                        EpisodeChanged = True
    '                        ShowID = Convert.ToInt32(tmpShowDb.ShowID)
    '                    End If

    '                    If Me.InvokeRequired Then
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 3, tmpShowDb.TVEp.Title})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 4, If(String.IsNullOrEmpty(eContainer.Poster), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 5, If(String.IsNullOrEmpty(eContainer.Fanart), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 6, If(String.IsNullOrEmpty(tmpShowDb.EpNfoPath), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 7, False})
    '                    Else
    '                        DirectCast(dRow(0), DataRow).Item(3) = tmpShowDb.TVEp.Title
    '                        DirectCast(dRow(0), DataRow).Item(4) = If(String.IsNullOrEmpty(eContainer.Poster), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(5) = If(String.IsNullOrEmpty(eContainer.Fanart), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(6) = If(String.IsNullOrEmpty(tmpShowDb.EpNfoPath), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(7) = False
    '                    End If
    '                End If

    '                Master.DB.SaveTVEpToDB(tmpShowDb, False, False, BatchMode, ToNfo)

    '            Else
    '                Master.DB.DeleteTVEpFromDB(ID, False, True, BatchMode)
    '                Return True
    '            End If

    '            If Not BatchMode Then
    '                If (SeasonChanged OrElse EpisodeChanged) AndAlso ShowID > -1 Then
    '                    Master.DB.CleanSeasons(BatchMode)
    '                    Me.FillSeasons(ShowID)
    '                Else
    '                    Me.LoadEpisodeInfo(Convert.ToInt32(ID))
    '                End If
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '        Return False
    '    End Function

    '    Private Function RefreshMovie(ByVal ID As Long, Optional ByVal BatchMode As Boolean = False, Optional ByVal FromNfo As Boolean = True, Optional ByVal ToNfo As Boolean = False) As Boolean
    '        Dim tmpMovie As New MediaContainers.Movie
    '        Dim tmpMovieDb As New Structures.DBMovie
    '        Dim OldTitle As String = String.Empty
    '        Dim selRow As DataRow = Nothing

    '        Dim hasPoster As Boolean = False
    '        Dim hasFanart As Boolean = False
    '        Dim hasNfo As Boolean = False
    '        Dim hasTrailer As Boolean = False
    '        Dim hasSub As Boolean = False
    '        Dim hasExtra As Boolean = False

    '        Dim myDelegate As New MydtListUpdate(AddressOf dtListUpdate)

    '        Try

    '            tmpMovieDb = Master.DB.LoadMovieFromDB(ID)

    '            OldTitle = tmpMovieDb.Movie.Title

    '            If Directory.Exists(Directory.GetParent(tmpMovieDb.Filename).FullName) Then

    '                If FromNfo Then
    '                    If String.IsNullOrEmpty(tmpMovieDb.NfoPath) Then
    '                        Dim sNFO As String = NFO.GetNfoPath(tmpMovieDb.Filename, tmpMovieDb.isSingle)
    '                        tmpMovieDb.NfoPath = sNFO
    '                        tmpMovie = NFO.LoadMovieFromNFO(sNFO, tmpMovieDb.isSingle)
    '                    Else
    '                        tmpMovie = NFO.LoadMovieFromNFO(tmpMovieDb.NfoPath, tmpMovieDb.isSingle)
    '                    End If
    '                    'subsType and subsPath not in NFO , try to load it from DB
    '                    For x = 0 To tmpMovie.FileInfo.StreamDetails.Subtitle.Count - 1
    '                        If tmpMovieDb.Movie.FileInfo.StreamDetails.Subtitle.Count > 0 AndAlso Not tmpMovieDb.Movie.FileInfo.StreamDetails.Subtitle(x) Is Nothing AndAlso tmpMovieDb.Movie.FileInfo.StreamDetails.Subtitle(x).Language = tmpMovie.FileInfo.StreamDetails.Subtitle(x).Language Then
    '                            tmpMovie.FileInfo.StreamDetails.Subtitle(x).SubsType = tmpMovieDb.Movie.FileInfo.StreamDetails.Subtitle(x).SubsType
    '                            tmpMovie.FileInfo.StreamDetails.Subtitle(x).SubsPath = tmpMovieDb.Movie.FileInfo.StreamDetails.Subtitle(x).SubsPath
    '                        End If
    '                    Next
    '                    tmpMovieDb.Movie = tmpMovie
    '                End If

    '                If String.IsNullOrEmpty(tmpMovieDb.Movie.Title) Then
    '                    If FileUtils.isVideoTS(tmpMovieDb.Filename) Then
    '                        tmpMovieDb.ListTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(tmpMovieDb.Filename).FullName).Name)
    '                        tmpMovieDb.Movie.Title = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(tmpMovieDb.Filename).FullName).Name, False)
    '                    ElseIf FileUtils.isBDRip(tmpMovieDb.Filename) Then
    '                        tmpMovieDb.ListTitle = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(tmpMovieDb.Filename).FullName).FullName).Name)
    '                        tmpMovieDb.Movie.Title = StringUtils.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(tmpMovieDb.Filename).FullName).FullName).Name, False)
    '                    Else
    '                        If tmpMovieDb.UseFolder AndAlso tmpMovieDb.isSingle Then
    '                            tmpMovieDb.ListTitle = StringUtils.FilterName(Directory.GetParent(tmpMovieDb.Filename).Name)
    '                            tmpMovieDb.Movie.Title = StringUtils.FilterName(Directory.GetParent(tmpMovieDb.Filename).Name, False)
    '                        Else
    '                            tmpMovieDb.ListTitle = StringUtils.FilterName(Path.GetFileNameWithoutExtension(tmpMovieDb.Filename))
    '                            tmpMovieDb.Movie.Title = StringUtils.FilterName(Path.GetFileNameWithoutExtension(tmpMovieDb.Filename), False)
    '                        End If
    '                    End If
    '                    If Not OldTitle = tmpMovieDb.Movie.Title OrElse String.IsNullOrEmpty(tmpMovieDb.Movie.SortTitle) Then tmpMovieDb.Movie.SortTitle = tmpMovieDb.ListTitle
    '                Else
    '                    Dim tTitle As String = StringUtils.FilterTokens(tmpMovieDb.Movie.Title)
    '                    If Not OldTitle = tmpMovieDb.Movie.Title OrElse String.IsNullOrEmpty(tmpMovieDb.Movie.SortTitle) Then tmpMovieDb.Movie.SortTitle = tTitle
    '                    If Master.eSettings.DisplayYear AndAlso Not String.IsNullOrEmpty(tmpMovieDb.Movie.Year) Then
    '                        tmpMovieDb.ListTitle = String.Format("{0} ({1})", tTitle, tmpMovieDb.Movie.Year)
    '                    Else
    '                        tmpMovieDb.ListTitle = tTitle
    '                    End If
    '                End If
    '                Dim fromFile As String = APIXML.GetFileSource(tmpMovieDb.Filename)
    '                If Not String.IsNullOrEmpty(fromFile) Then
    '                    tmpMovieDb.FileSource = fromFile
    '                ElseIf String.IsNullOrEmpty(tmpMovieDb.FileSource) AndAlso AdvancedSettings.GetBooleanSetting("MediaSourcesByExtension", False, "*EmberAPP") Then
    '                    tmpMovieDb.FileSource = AdvancedSettings.GetSetting(String.Concat("MediaSourcesByExtension:", Path.GetExtension(tmpMovieDb.Filename)), String.Empty, "*EmberAPP")
    '                End If

    '                Dim mContainer As New Scanner.MovieContainer With {.Filename = tmpMovieDb.Filename, .isSingle = tmpMovieDb.isSingle}
    '                fScanner.GetMovieFolderContents(mContainer)
    '                tmpMovieDb.PosterPath = mContainer.Poster
    '                tmpMovieDb.FanartPath = mContainer.Fanart
    '                'assume invalid nfo if no title
    '                tmpMovieDb.NfoPath = If(String.IsNullOrEmpty(tmpMovieDb.Movie.Title), String.Empty, mContainer.Nfo)
    '                tmpMovieDb.TrailerPath = mContainer.Trailer
    '                tmpMovieDb.SubPath = mContainer.Subs
    '                tmpMovieDb.ExtraPath = mContainer.Extra

    '                hasPoster = Not String.IsNullOrEmpty(mContainer.Poster)
    '                hasFanart = Not String.IsNullOrEmpty(mContainer.Fanart)
    '                hasNfo = Not String.IsNullOrEmpty(tmpMovieDb.NfoPath)
    '                hasTrailer = Not String.IsNullOrEmpty(mContainer.Trailer)
    '                hasSub = Not String.IsNullOrEmpty(mContainer.Subs)
    '                hasExtra = Not String.IsNullOrEmpty(mContainer.Extra)

    '                Dim dRow = From drvRow In dtMedia.Rows Where Convert.ToInt64(DirectCast(drvRow, DataRow).Item(0)) = ID Select drvRow

    '                If Not IsNothing(dRow(0)) Then
    '                    selRow = DirectCast(dRow(0), DataRow)
    '                    tmpMovieDb.IsMark = Convert.ToBoolean(selRow.Item(11))
    '                    tmpMovieDb.IsLock = Convert.ToBoolean(selRow.Item(14))

    '                    If Me.InvokeRequired Then
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 1, tmpMovieDb.Filename})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 3, tmpMovieDb.ListTitle})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 4, hasPoster})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 5, hasFanart})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 6, hasNfo})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 7, hasTrailer})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 8, hasSub})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 9, hasExtra})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 10, False})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 15, tmpMovieDb.Movie.Title})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 47, tmpMovieDb.Movie.SortTitle})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 27, tmpMovieDb.Movie.Genre})
    '                    Else
    '                        selRow.Item(1) = tmpMovieDb.Filename
    '                        selRow.Item(3) = tmpMovieDb.ListTitle
    '                        selRow.Item(4) = hasPoster
    '                        selRow.Item(5) = hasFanart
    '                        selRow.Item(6) = hasNfo
    '                        selRow.Item(7) = hasTrailer
    '                        selRow.Item(8) = hasSub
    '                        selRow.Item(9) = hasExtra
    '                        selRow.Item(10) = False
    '                        selRow.Item(15) = tmpMovieDb.Movie.Title
    '                        selRow.Item(47) = tmpMovieDb.Movie.SortTitle
    '                        selRow.Item(27) = tmpMovieDb.Movie.Genre
    '                    End If
    '                End If
    '                'Why on earth resave the movie if we just refreshed its data (causes issues with saving rescrapes_
    '                'Master.DB.SaveMovieToDB(tmpMovieDb, False, BatchMode, ToNfo)

    '            Else
    '                Master.DB.DeleteFromDB(ID, BatchMode)
    '                Return True
    '            End If

    '            If Not BatchMode Then
    '                Me.DoTitleCheck()

    '                Dim selI As Integer = 0

    '                If Me.dgvMediaList.SelectedRows.Count > 0 Then selI = Me.dgvMediaList.SelectedRows(0).Index

    '                Me.dgvMediaList.ClearSelection()
    '                Me.dgvMediaList.CurrentCell = Nothing

    '                If Me.dgvMediaList.RowCount - 1 < selI Then selI = Me.dgvMediaList.RowCount

    '                Me.ClearInfo()
    '                Me.prevRow = -2
    '                Me.currRow = -1

    '                If Me.dgvMediaList.RowCount > 0 Then
    '                    Me.dgvMediaList.Rows(selI).Cells(3).Selected = True
    '                    Me.dgvMediaList.CurrentCell = Me.dgvMediaList.Rows(selI).Cells(3)
    '                End If
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '        Return False
    '    End Function

    '    Private Function RefreshSeason(ByVal ShowID As Integer, ByVal Season As Integer, ByVal BatchMode As Boolean) As Boolean
    '        Dim tmpSeasonDb As New Structures.DBTV
    '        Dim tmpShow As New MediaContainers.TVShow

    '        Dim myDelegate As New MydtListUpdate(AddressOf dtListUpdate)

    '        Try
    '            Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
    '            If Not BatchMode Then SQLtransaction = Master.DB.BeginTransaction

    '            tmpSeasonDb = Master.DB.LoadTVSeasonFromDB(ShowID, Season, True)

    '            Dim tPath As String = Functions.GetSeasonDirectoryFromShowPath(tmpSeasonDb.ShowPath, Season)

    '            If String.IsNullOrEmpty(tPath) Then
    '                tPath = tmpSeasonDb.ShowPath
    '            End If

    '            'fake file just for getting images
    '            tmpSeasonDb.Filename = Path.Combine(tPath, "file.ext")
    '            fScanner.GetSeasonImages(tmpSeasonDb, Season)

    '            Dim dRow = From drvRow In dtSeasons.Rows Where Convert.ToInt64(DirectCast(drvRow, DataRow).Item(0)) = ShowID AndAlso Convert.ToInt32(DirectCast(drvRow, DataRow).Item(2)) = Season Select drvRow

    '            If Not IsNothing(dRow(0)) Then
    '                If Me.InvokeRequired Then
    '                    Me.Invoke(myDelegate, New Object() {dRow(0), 3, If(String.IsNullOrEmpty(tmpSeasonDb.SeasonPosterPath), False, True)})
    '                    If Master.eSettings.SeasonFanartEnabled Then
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 4, If(String.IsNullOrEmpty(tmpSeasonDb.SeasonFanartPath), False, True)})
    '                    End If
    '                    Me.Invoke(myDelegate, New Object() {dRow(0), 9, False})
    '                Else
    '                    DirectCast(dRow(0), DataRow).Item(3) = If(String.IsNullOrEmpty(tmpSeasonDb.SeasonPosterPath), False, True)
    '                    If Master.eSettings.SeasonFanartEnabled Then
    '                        DirectCast(dRow(0), DataRow).Item(4) = If(String.IsNullOrEmpty(tmpSeasonDb.SeasonFanartPath), False, True)
    '                    End If
    '                    DirectCast(dRow(0), DataRow).Item(9) = False
    '                End If
    '            End If

    '            If Not BatchMode Then
    '                SQLtransaction.Commit()
    '                SQLtransaction = Nothing

    '                Me.LoadSeasonInfo(ShowID, Season)
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '        Return False
    '    End Function

    '    Private Function RefreshShow(ByVal ID As Long, ByVal BatchMode As Boolean, ByVal FromNfo As Boolean, ByVal ToNfo As Boolean, ByVal WithEpisodes As Boolean) As Boolean
    '        If Not BatchMode Then
    '            Me.tspbLoading.Style = ProgressBarStyle.Continuous
    '            Me.tspbLoading.Value = 0

    '            Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                SQLCommand.CommandText = String.Concat("SELECT COUNT(ID) AS COUNT FROM TVEps WHERE TVShowID = ", ID, " AND Missing = 0;")
    '                Me.tspbLoading.Maximum = Convert.ToInt32(SQLCommand.ExecuteScalar) + 1
    '            End Using

    '            Me.tslLoading.Text = Master.eLang.GetString(731, "Refreshing Show:")
    '            Me.tslLoading.Visible = True
    '            Me.tspbLoading.Visible = True
    '            Application.DoEvents()
    '        End If

    '        Dim tmpShowDb As New Structures.DBTV
    '        Dim tmpShow As New MediaContainers.TVShow

    '        Dim myDelegate As New MydtListUpdate(AddressOf dtListUpdate)

    '        Try
    '            Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
    '            If Not BatchMode Then SQLtransaction = Master.DB.BeginTransaction

    '            tmpShowDb = Master.DB.LoadTVFullShowFromDB(ID)

    '            If Directory.Exists(tmpShowDb.ShowPath) Then

    '                If FromNfo Then
    '                    If String.IsNullOrEmpty(tmpShowDb.ShowNfoPath) Then
    '                        Dim sNFO As String = NFO.GetShowNfoPath(tmpShowDb.ShowPath)
    '                        tmpShowDb.ShowNfoPath = sNFO
    '                        tmpShow = NFO.LoadTVShowFromNFO(sNFO)
    '                    Else
    '                        tmpShow = NFO.LoadTVShowFromNFO(tmpShowDb.ShowNfoPath)
    '                    End If
    '                    tmpShowDb.TVShow = tmpShow
    '                End If

    '                If String.IsNullOrEmpty(tmpShowDb.TVShow.Title) Then
    '                    tmpShowDb.TVShow.Title = StringUtils.FilterTVShowName(Path.GetFileNameWithoutExtension(tmpShowDb.ShowPath), False)
    '                End If

    '                Dim sContainer As New Scanner.TVShowContainer With {.ShowPath = tmpShowDb.ShowPath}
    '                fScanner.GetShowFolderContents(sContainer)
    '                tmpShowDb.ShowPosterPath = sContainer.Poster
    '                tmpShowDb.ShowFanartPath = sContainer.Fanart
    '                'assume invalid nfo if no title
    '                tmpShowDb.ShowNfoPath = If(String.IsNullOrEmpty(tmpShowDb.TVShow.Title), String.Empty, sContainer.Nfo)

    '                Dim dRow = From drvRow In dtShows.Rows Where Convert.ToInt64(DirectCast(drvRow, DataRow).Item(0)) = ID Select drvRow

    '                If Not IsNothing(dRow(0)) Then
    '                    tmpShowDb.IsMarkShow = Convert.ToBoolean(DirectCast(dRow(0), DataRow).Item(6))
    '                    tmpShowDb.IsLockShow = Convert.ToBoolean(DirectCast(dRow(0), DataRow).Item(10))

    '                    If Me.InvokeRequired Then
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 1, tmpShowDb.TVShow.Title})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 2, If(String.IsNullOrEmpty(sContainer.Poster), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 3, If(String.IsNullOrEmpty(sContainer.Fanart), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 4, If(String.IsNullOrEmpty(tmpShowDb.ShowNfoPath), False, True)})
    '                        Me.Invoke(myDelegate, New Object() {dRow(0), 5, False})
    '                    Else
    '                        DirectCast(dRow(0), DataRow).Item(1) = tmpShowDb.TVShow.Title
    '                        DirectCast(dRow(0), DataRow).Item(2) = If(String.IsNullOrEmpty(sContainer.Poster), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(3) = If(String.IsNullOrEmpty(sContainer.Fanart), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(4) = If(String.IsNullOrEmpty(tmpShowDb.ShowNfoPath), False, True)
    '                        DirectCast(dRow(0), DataRow).Item(5) = False
    '                    End If
    '                End If

    '                Master.DB.SaveTVShowToDB(tmpShowDb, False, WithEpisodes, ToNfo)

    '                If Not BatchMode Then
    '                    Me.tspbLoading.Value += 1
    '                    Application.DoEvents()
    '                End If

    '                If WithEpisodes Then
    '                    Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                        SQLCommand.CommandText = String.Concat("SELECT ID FROM TVEps WHERE TVShowID = ", ID, " AND Missing = 0;")
    '                        Using SQLReader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader
    '                            While SQLReader.Read
    '                                Me.RefreshEpisode(Convert.ToInt64(SQLReader("ID")), True)
    '                                If Not BatchMode Then
    '                                    Me.tspbLoading.Value += 1
    '                                    Application.DoEvents()
    '                                    Threading.Thread.Sleep(50)
    '                                End If
    '                            End While
    '                        End Using
    '                    End Using

    '                    Master.DB.CleanSeasons(True)
    '                End If

    '            Else
    '                Master.DB.DeleteTVShowFromDB(ID, WithEpisodes)
    '                Return True
    '            End If

    '            If Not BatchMode Then
    '                SQLtransaction.Commit()
    '                SQLtransaction = Nothing

    '                Me.LoadShowInfo(Convert.ToInt32(ID))

    '                Me.tslLoading.Visible = False
    '                Me.tspbLoading.Visible = False
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try

    '        Return False
    '    End Function

    '    Private Sub ReloadMovie()
    '        Try
    '            Me.dgvMediaList.Cursor = Cursors.WaitCursor
    '            Me.SetControlsEnabled(False, True)

    '            Dim doFill As Boolean = False
    '            Dim tFill As Boolean = False

    '            Dim doBatch As Boolean = Not Me.dgvMediaList.SelectedRows.Count = 1

    '            Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
    '                For Each sRow As DataGridViewRow In Me.dgvMediaList.SelectedRows
    '                    tFill = Me.RefreshMovie(Convert.ToInt64(sRow.Cells(0).Value), doBatch)
    '                    If tFill Then doFill = True
    '                Next
    '                SQLtransaction.Commit()
    '            End Using

    '            Me.dgvMediaList.Cursor = Cursors.Default
    '            Me.SetControlsEnabled(True)

    '            If doFill Then FillList(0) Else DoTitleCheck()
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub





    '    Private Sub ScannerUpdated(ByVal iType As Integer, ByVal sText As String)
    '        Select Case iType
    '            Case 1
    '                Me.SetStatus(String.Concat(Master.eLang.GetString(814, "Added Episode: "), sText))
    '            Case 2
    '                Me.SetStatus(Master.eLang.GetString(116, "Performing Preliminary Tasks (Gathering Data)..."))
    '            Case 3
    '                Me.SetStatus(Master.eLang.GetString(644, "Cleaning Database..."))
    '            Case Else
    '                Me.SetStatus(String.Concat(Master.eLang.GetString(815, "Added Movie: "), sText))
    '        End Select
    '    End Sub

    '    Private Sub ScanningCompleted()
    '        If Not isCL Then
    '            Me.SetStatus(String.Empty)
    '            Me.FillList(0)
    '            Me.tspbLoading.Visible = False
    '            Me.tslLoading.Visible = False
    '        Else
    '            Me.FillList(0)
    '            LoadingDone = True
    '        End If
    '    End Sub

    '    Private Sub scMain_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles scMain.SplitterMoved
    '        Try
    '            If Me.Created Then
    '                Me.SuspendLayout()
    '                Me.MoveMPAA()
    '                Me.MoveGenres()

    '                ImageUtils.ResizePB(Me.pbFanart, Me.pbFanartCache, Me.scMain.Panel2.Height - 90, Me.scMain.Panel2.Width)
    '                Me.pbFanart.Left = Convert.ToInt32((Me.scMain.Panel2.Width - Me.pbFanart.Width) / 2)
    '                Me.pnlNoInfo.Location = New Point(Convert.ToInt32((Me.scMain.Panel2.Width - Me.pnlNoInfo.Width) / 2), Convert.ToInt32((Me.scMain.Panel2.Height - Me.pnlNoInfo.Height) / 2))
    '                Me.pnlCancel.Location = New Point(Convert.ToInt32((Me.scMain.Panel2.Width - Me.pnlNoInfo.Width) / 2), 100)
    '                Me.pnlFilterGenre.Location = New Point(Me.gbSpecific.Left + Me.txtFilterGenre.Left, (Me.pnlFilter.Top + Me.txtFilterGenre.Top + Me.gbSpecific.Top) - Me.pnlFilterGenre.Height)
    '                Me.pnlFilterSource.Location = New Point(Me.gbSpecific.Left + Me.txtFilterSource.Left, (Me.pnlFilter.Top + Me.txtFilterSource.Top + Me.gbSpecific.Top) - Me.pnlFilterSource.Height)

    '                Select Case Me.tabsMain.SelectedIndex
    '                    Case 0
    '                        Me.dgvMediaList.Focus()
    '                    Case 1
    '                        Me.dgvTVShows.Focus()
    '                End Select

    '                Me.ResumeLayout(True)
    '            End If
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub


    '   
    'Private Sub SetControlsEnabled(ByVal isEnabled As Boolean, Optional ByVal withLists As Boolean = False, Optional ByVal withTools As Boolean = True)
    '    'Me.ToolsToolStripMenuItem.Enabled = isEnabled AndAlso (Me.dgvMediaList.RowCount > 0 OrElse Me.dgvTVShows.RowCount > 0)
    '    For Each i As Object In Me.ToolsToolStripMenuItem.DropDownItems
    '        If TypeOf i Is ToolStripMenuItem Then
    '            Dim o As ToolStripMenuItem = DirectCast(i, ToolStripMenuItem)
    '            If o.Tag Is Nothing Then
    '                o.Enabled = isEnabled AndAlso (Me.dgvMediaList.RowCount > 0 OrElse Me.dgvTVShows.RowCount > 0) AndAlso tabsMain.SelectedIndex = 0
    '            ElseIf TypeOf o.Tag Is Structures.ModulesMenus Then
    '                Dim tagmenu As Structures.ModulesMenus = DirectCast(o.Tag, Structures.ModulesMenus)
    '                o.Enabled = (isEnabled OrElse Not withTools) AndAlso (((Me.dgvMediaList.RowCount > 0 OrElse tagmenu.IfNoMovies) AndAlso tabsMain.SelectedIndex = 0) OrElse ((Me.dgvTVShows.RowCount > 0 OrElse tagmenu.IfNoTVShow) AndAlso tabsMain.SelectedIndex = 1))
    '            End If
    '        ElseIf TypeOf i Is ToolStripSeparator Then
    '            Dim o As ToolStripSeparator = DirectCast(i, ToolStripSeparator)
    '            o.Visible = (Me.ToolsToolStripMenuItem.DropDownItems.IndexOf(o) < Me.ToolsToolStripMenuItem.DropDownItems.Count - 1)
    '        End If
    '    Next
    '    With Master.eSettings
    '        If (Not .ExpertCleaner AndAlso (.CleanDotFanartJPG OrElse .CleanFanartJPG OrElse .CleanFolderJPG OrElse .CleanMovieFanartJPG OrElse _
    '        .CleanMovieJPG OrElse .CleanMovieNameJPG OrElse .CleanMovieNFO OrElse .CleanMovieNFOB OrElse _
    '        .CleanMovieTBN OrElse .CleanMovieTBNB OrElse .CleanPosterJPG OrElse .CleanPosterTBN OrElse .CleanExtraThumbs)) OrElse _
    '        (.ExpertCleaner AndAlso (.CleanWhitelistVideo OrElse .CleanWhitelistExts.Count > 0)) Then
    '            Me.CleanFoldersToolStripMenuItem.Enabled = isEnabled AndAlso Me.dgvMediaList.RowCount > 0 AndAlso Me.tabsMain.SelectedIndex = 0
    '        Else
    '            Me.CleanFoldersToolStripMenuItem.Enabled = False
    '        End If
    '    End With
    '    Me.EditToolStripMenuItem.Enabled = isEnabled
    '    Me.tsbAutoPilot.Enabled = isEnabled AndAlso Me.dgvMediaList.RowCount > 0 AndAlso Me.tabsMain.SelectedIndex = 0
    '    Me.tsbRefreshMedia.Enabled = isEnabled
    '    Me.tsbMediaCenters.Enabled = isEnabled
    '    Me.mnuMediaList.Enabled = isEnabled
    '    Me.mnuShows.Enabled = isEnabled
    '    Me.mnuSeasons.Enabled = isEnabled
    '    Me.mnuEpisodes.Enabled = isEnabled
    '    Me.txtSearch.Enabled = isEnabled
    '    Me.tabsMain.Enabled = isEnabled
    '    Me.btnMarkAll.Enabled = isEnabled
    '    Me.btnMetaDataRefresh.Enabled = isEnabled
    '    Me.scMain.IsSplitterFixed = Not isEnabled
    '    Me.scTV.IsSplitterFixed = Not isEnabled
    '    Me.SplitContainer2.IsSplitterFixed = Not isEnabled
    '    Me.HelpToolStripMenuItem.Enabled = isEnabled
    '    Me.cmnuTrayIconTools.Enabled = Me.ToolsToolStripMenuItem.Enabled
    '    Me.cmnuTrayIconScrapeMedia.Enabled = Me.tsbAutoPilot.Enabled
    '    Me.cmnuTrayIconUpdateMedia.Enabled = isEnabled
    '    Me.cmnuTrayIconMediaCenters.Enabled = isEnabled
    '    Me.cmnuTrayIconSettings.Enabled = isEnabled
    '    Me.cmnuTrayIconExit.Enabled = isEnabled

    '    If withLists OrElse isEnabled Then
    '        Me.dgvMediaList.TabStop = isEnabled
    '        Me.dgvTVShows.TabStop = isEnabled
    '        Me.dgvTVSeasons.TabStop = isEnabled
    '        Me.dgvTVEpisodes.TabStop = isEnabled
    '        Me.dgvMediaList.Enabled = isEnabled
    '        Me.dgvTVShows.Enabled = isEnabled
    '        Me.dgvTVSeasons.Enabled = isEnabled
    '        Me.dgvTVEpisodes.Enabled = isEnabled
    '    End If
    'End Sub



    '    Private Sub SetMenus(ByVal ReloadFilters As Boolean)
    '        Dim mnuItem As ToolStripItem

    '        Try
    '            With Master.eSettings
    '                If (Not .ExpertCleaner AndAlso (.CleanDotFanartJPG OrElse .CleanFanartJPG OrElse .CleanFolderJPG OrElse .CleanMovieFanartJPG OrElse _
    '                .CleanMovieJPG OrElse .CleanMovieNameJPG OrElse .CleanMovieNFO OrElse .CleanMovieNFOB OrElse _
    '                .CleanMovieTBN OrElse .CleanMovieTBNB OrElse .CleanPosterJPG OrElse .CleanPosterTBN OrElse .CleanExtraThumbs)) OrElse _
    '                (.ExpertCleaner AndAlso (.CleanWhitelistVideo OrElse .CleanWhitelistExts.Count > 0)) Then
    '                    Me.CleanFoldersToolStripMenuItem.Enabled = True AndAlso Me.dgvMediaList.RowCount > 0 AndAlso Me.tabsMain.SelectedIndex = 0
    '                Else
    '                    Me.CleanFoldersToolStripMenuItem.Enabled = False
    '                End If

    '                Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.Enabled = Directory.Exists(.BDPath)

    '                Me.ClearAllCachesToolStripMenuItem.Enabled = .UseImgCache

    '                Me.mnuAllAutoExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuAllAskExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuMissAutoExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuMissAskExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuMarkAutoExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuMarkAskExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuNewAutoExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuNewAskExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuFilterAutoExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET
    '                Me.mnuFilterAskExtra.Enabled = .AutoThumbs > 0 OrElse .AutoET

    '                Dim PosterAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Poster)
    '                Me.mnuAllAutoPoster.Enabled = PosterAllowed
    '                Me.mnuAllAskPoster.Enabled = PosterAllowed
    '                Me.mnuMissAutoPoster.Enabled = PosterAllowed
    '                Me.mnuMissAskPoster.Enabled = PosterAllowed
    '                Me.mnuMarkAutoPoster.Enabled = PosterAllowed
    '                Me.mnuMarkAskPoster.Enabled = PosterAllowed
    '                Me.mnuNewAutoPoster.Enabled = PosterAllowed
    '                Me.mnuNewAskPoster.Enabled = PosterAllowed
    '                Me.mnuFilterAutoPoster.Enabled = PosterAllowed
    '                Me.mnuFilterAskPoster.Enabled = PosterAllowed

    '                Dim FanartAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Fanart)
    '                Me.mnuAllAutoFanart.Enabled = FanartAllowed
    '                Me.mnuAllAskFanart.Enabled = FanartAllowed
    '                Me.mnuMissAutoFanart.Enabled = FanartAllowed
    '                Me.mnuMissAskFanart.Enabled = FanartAllowed
    '                Me.mnuMarkAutoFanart.Enabled = FanartAllowed
    '                Me.mnuMarkAskFanart.Enabled = FanartAllowed
    '                Me.mnuNewAutoFanart.Enabled = FanartAllowed
    '                Me.mnuNewAskFanart.Enabled = FanartAllowed
    '                Me.mnuFilterAutoFanart.Enabled = FanartAllowed
    '                Me.mnuFilterAskFanart.Enabled = FanartAllowed

    '                Me.mnuAllAskMI.Enabled = .ScanMediaInfo
    '                Me.mnuAllAutoMI.Enabled = .ScanMediaInfo
    '                Me.mnuNewAskMI.Enabled = .ScanMediaInfo
    '                Me.mnuNewAutoMI.Enabled = .ScanMediaInfo
    '                Me.mnuMarkAskMI.Enabled = .ScanMediaInfo
    '                Me.mnuMarkAutoMI.Enabled = .ScanMediaInfo
    '                Me.mnuFilterAskMI.Enabled = .ScanMediaInfo
    '                Me.mnuFilterAutoMI.Enabled = .ScanMediaInfo

    '                Dim TrailerAllowed As Boolean = ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Trailer)
    '                Me.mnuAllAutoTrailer.Enabled = TrailerAllowed
    '                Me.mnuAllAskTrailer.Enabled = TrailerAllowed
    '                Me.mnuMissAutoTrailer.Enabled = TrailerAllowed
    '                Me.mnuMissAskTrailer.Enabled = TrailerAllowed
    '                Me.mnuNewAutoTrailer.Enabled = TrailerAllowed
    '                Me.mnuNewAskTrailer.Enabled = TrailerAllowed
    '                Me.mnuMarkAutoTrailer.Enabled = TrailerAllowed
    '                Me.mnuMarkAskTrailer.Enabled = TrailerAllowed
    '                Me.mnuFilterAutoTrailer.Enabled = TrailerAllowed
    '                Me.mnuFilterAskTrailer.Enabled = TrailerAllowed

    '                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                    SQLNewcommand.CommandText = String.Concat("SELECT COUNT(id) AS mcount FROM movies WHERE mark = 1;")
    '                    Using SQLcount As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
    '                        If Convert.ToInt32(SQLcount("mcount")) > 0 Then
    '                            Me.btnMarkAll.Text = Master.eLang.GetString(105, "Unmark All")
    '                        Else
    '                            Me.btnMarkAll.Text = Master.eLang.GetString(35, "Mark All")
    '                        End If
    '                    End Using
    '                End Using

    '                Me.mnuMoviesUpdate.DropDownItems.Clear()
    '                Me.cmnuTrayIconUpdateMovies.DropDownItems.Clear()
    '                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                    SQLNewcommand.CommandText = "SELECT COUNT(ID) AS cID FROM Sources;"
    '                    If Convert.ToInt32(SQLNewcommand.ExecuteScalar) > 1 Then
    '                        mnuItem = Me.mnuMoviesUpdate.DropDownItems.Add(Master.eLang.GetString(649, "Update All"), Nothing, New System.EventHandler(AddressOf SourceSubClick))
    '                        mnuItem.Tag = String.Empty
    '                        mnuItem = Me.cmnuTrayIconUpdateMovies.DropDownItems.Add(Master.eLang.GetString(649, "Update All"), Nothing, New System.EventHandler(AddressOf SourceSubClick))
    '                        mnuItem.Tag = String.Empty
    '                    End If
    '                    SQLNewcommand.CommandText = "SELECT Name FROM Sources;"
    '                    Using SQLReader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
    '                        While SQLReader.Read
    '                            mnuItem = Me.mnuMoviesUpdate.DropDownItems.Add(String.Format(Master.eLang.GetString(143, "Update {0} Only"), SQLReader("Name")), Nothing, New System.EventHandler(AddressOf SourceSubClick))
    '                            mnuItem.Tag = SQLReader("Name").ToString
    '                            mnuItem = Me.cmnuTrayIconUpdateMovies.DropDownItems.Add(String.Format(Master.eLang.GetString(143, "Update {0} Only"), SQLReader("Name")), Nothing, New System.EventHandler(AddressOf SourceSubClick))
    '                            mnuItem.Tag = SQLReader("Name").ToString
    '                        End While
    '                    End Using
    '                End Using

    '                Me.mnuTVShowUpdate.DropDownItems.Clear()
    '                Me.cmnuTrayIconUpdateTV.DropDownItems.Clear()
    '                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                    SQLNewcommand.CommandText = "SELECT COUNT(ID) AS cID FROM TVSources;"
    '                    If Convert.ToInt32(SQLNewcommand.ExecuteScalar) > 1 Then
    '                        mnuItem = Me.mnuTVShowUpdate.DropDownItems.Add(Master.eLang.GetString(649, "Update All"), Nothing, New System.EventHandler(AddressOf TVSourceSubClick))
    '                        mnuItem.Tag = String.Empty
    '                        mnuItem = Me.cmnuTrayIconUpdateTV.DropDownItems.Add(Master.eLang.GetString(649, "Update All"), Nothing, New System.EventHandler(AddressOf TVSourceSubClick))
    '                        mnuItem.Tag = String.Empty
    '                    End If
    '                    SQLNewcommand.CommandText = "SELECT Name FROM TVSources;"
    '                    Using SQLReader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
    '                        While SQLReader.Read
    '                            mnuItem = Me.mnuTVShowUpdate.DropDownItems.Add(String.Format(Master.eLang.GetString(143, "Update {0} Only"), SQLReader("Name")), Nothing, New System.EventHandler(AddressOf TVSourceSubClick))
    '                            mnuItem.Tag = SQLReader("Name").ToString
    '                            mnuItem = Me.cmnuTrayIconUpdateTV.DropDownItems.Add(String.Format(Master.eLang.GetString(143, "Update {0} Only"), SQLReader("Name")), Nothing, New System.EventHandler(AddressOf TVSourceSubClick))
    '                            mnuItem.Tag = SQLReader("Name").ToString
    '                        End While
    '                    End Using
    '                End Using


    '                'not technically a menu, but it's a good place to put it
    '                If ReloadFilters Then

    '                    clbFilterSource.Items.Clear()
    '                    Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
    '                        SQLNewcommand.CommandText = String.Concat("SELECT Name FROM Sources;")
    '                        Using SQLReader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
    '                            While SQLReader.Read
    '                                clbFilterSource.Items.Add(SQLReader("Name"))
    '                            End While
    '                        End Using
    '                    End Using

    '                    RemoveHandler cbFilterYear.SelectedIndexChanged, AddressOf cbFilterYear_SelectedIndexChanged
    '                    Me.cbFilterYear.Items.Clear()
    '                    cbFilterYear.Items.Add(Master.eLang.All)
    '                    For i As Integer = (Year(Today) + 1) To 1888 Step -1
    '                        Me.cbFilterYear.Items.Add(i)
    '                    Next
    '                    cbFilterYear.SelectedIndex = 0
    '                    AddHandler cbFilterYear.SelectedIndexChanged, AddressOf cbFilterYear_SelectedIndexChanged

    '                    RemoveHandler cbFilterYearMod.SelectedIndexChanged, AddressOf cbFilterYearMod_SelectedIndexChanged
    '                    cbFilterYearMod.SelectedIndex = 0
    '                    AddHandler cbFilterYearMod.SelectedIndexChanged, AddressOf cbFilterYearMod_SelectedIndexChanged

    '                    RemoveHandler cbFilterFileSource.SelectedIndexChanged, AddressOf cbFilterFileSource_SelectedIndexChanged
    '                    cbFilterFileSource.Items.Clear()
    '                    cbFilterFileSource.Items.Add(Master.eLang.All)
    '                    cbFilterFileSource.Items.AddRange(APIXML.SourceList.ToArray)
    '                    cbFilterFileSource.Items.Add(Languages.None)
    '                    cbFilterFileSource.SelectedIndex = 0
    '                    AddHandler cbFilterFileSource.SelectedIndexChanged, AddressOf cbFilterFileSource_SelectedIndexChanged

    '                End If

    '            End With
    '            Me.tsbAutoPilot.Enabled = (Me.dgvMediaList.RowCount > 0 AndAlso Me.tabsMain.SelectedIndex = 0)
    '            Me.cmnuTrayIconScrapeMedia.Enabled = Me.tsbAutoPilot.Enabled
    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    Private Sub SetsManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetsManagerToolStripMenuItem.Click, SetsManagerToolStripMenuItem1.Click
        Using dSetsManager As New dlgSetsManager
            dSetsManager.ShowDialog()
        End Using
    End Sub

    Private Sub SetStatus(ByVal sText As String)
        Me.tslStatus.Text = sText.Replace("&", "&&")
    End Sub

    Private Function GetStatus() As String
        Return Me.tslStatus.Text.Replace("&&", "&")
    End Function

    '    Sub HideLoadingSettings()
    '        If Not Me.pnlLoadingSettings.InvokeRequired Then
    '            Me.pnlLoadingSettings.Visible = False
    '        End If
    '    End Sub

    Sub SettingsShow(ByVal dlg As Settings)
        'AddHandler dlg.LoadEnd, AddressOf HideLoadingSettings
        Dim dresult As Structures.SettingsResult = dlg.ShowDialog()
        'RemoveHandler dlg.LoadEnd, AddressOf HideLoadingSettings
        'Me.SettingsToolStripMenuItem.Enabled = True
        'Me.pnlLoadingSettings.Visible = False
        'Me.cmnuTrayIconSettings.Enabled = True
        'Me.cmnuTrayIconExit.Enabled = True
        'If Not dresult.DidCancel Then

        '    If Not Master.eSettings.DisplayMissingEpisodes Then
        '        Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
        '            Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
        '                SQLCommand.CommandText = "DELETE FROM TVEps WHERE Missing = 1"
        '                SQLCommand.ExecuteNonQuery()

        '                Master.DB.CleanSeasons(True)
        '            End Using
        '            SQLTrans.Commit()
        '        End Using
        '    End If

        '    Me.SetUp(True)

        '    If Me.dgvMediaList.RowCount > 0 Then
        '        Me.dgvMediaList.Columns(4).Visible = Not Master.eSettings.MoviePosterCol
        '        Me.dgvMediaList.Columns(5).Visible = Not Master.eSettings.MovieFanartCol
        '        Me.dgvMediaList.Columns(6).Visible = Not Master.eSettings.MovieInfoCol
        '        Me.dgvMediaList.Columns(7).Visible = Not Master.eSettings.MovieTrailerCol
        '        Me.dgvMediaList.Columns(8).Visible = Not Master.eSettings.MovieSubCol
        '        Me.dgvMediaList.Columns(9).Visible = Not Master.eSettings.MovieExtraCol
        '    End If

        '    If Me.dgvTVShows.RowCount > 0 Then
        '        Me.dgvTVShows.Columns(2).Visible = Not Master.eSettings.ShowPosterCol
        '        Me.dgvTVShows.Columns(3).Visible = Not Master.eSettings.ShowFanartCol
        '        Me.dgvTVShows.Columns(4).Visible = Not Master.eSettings.ShowNfoCol
        '    End If

        '    If Me.dgvTVSeasons.RowCount > 0 Then
        '        Me.dgvTVSeasons.Columns(3).Visible = Not Master.eSettings.SeasonPosterCol
        '        Me.dgvTVSeasons.Columns(4).Visible = Not Master.eSettings.SeasonFanartCol
        '    End If

        '    If Me.dgvTVEpisodes.RowCount > 0 Then
        '        Me.dgvTVEpisodes.Columns(4).Visible = Not Master.eSettings.EpisodePosterCol
        '        Me.dgvTVEpisodes.Columns(5).Visible = Not Master.eSettings.EpisodeFanartCol
        '        Me.dgvTVEpisodes.Columns(6).Visible = Not Master.eSettings.EpisodeNfoCol
        '    End If

        '    'might as well wait for these
        '    While Me.bwMediaInfo.IsBusy OrElse Me.bwDownloadPic.IsBusy
        '        Application.DoEvents()
        '        Threading.Thread.Sleep(50)
        '    End While

        '    If dresult.NeedsRefresh OrElse dresult.NeedsUpdate Then
        '        If dresult.NeedsRefresh Then
        '            If Not Me.fScanner.IsBusy Then
        '                While Me.bwLoadInfo.IsBusy OrElse Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy OrElse Me.bwCleanDB.IsBusy
        '                    Application.DoEvents()
        '                    Threading.Thread.Sleep(50)
        '                End While
        '                Me.RefreshAllMovies()
        '            End If
        '        End If
        '        If dresult.NeedsUpdate Then
        '            If Not Me.fScanner.IsBusy Then
        '                While Me.bwLoadInfo.IsBusy OrElse Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy OrElse Me.bwCleanDB.IsBusy
        '                    Application.DoEvents()
        '                    Threading.Thread.Sleep(50)
        '                End While
        '                Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
        '            End If
        '        End If
        '    Else
        '        If Not Me.fScanner.IsBusy AndAlso Not Me.bwLoadInfo.IsBusy AndAlso Not Me.bwMovieScraper.IsBusy AndAlso Not Me.bwRefreshMovies.IsBusy AndAlso Not Me.bwCleanDB.IsBusy Then
        '            Me.FillList(0)
        '        End If
        '    End If

        '    Me.SetMenus(True)
        '    If dresult.NeedsRestart Then
        '        Using dRestart As New dlgRestart
        '            If dRestart.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                Application.Restart()
        '            End If
        '        End Using
        '    End If
        'Else
        '    Me.SetMenus(False)
        '    Me.SetControlsEnabled(True)
        'End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click, cmnuTrayIconSettings.Click
        Try
            'Me.SetControlsEnabled(False)
            'Me.pnlLoadingSettings.Visible = True

            'Dim dThread As Threading.Thread = New Threading.Thread(AddressOf ShowSettings)
            'dThread.SetApartmentState(Threading.ApartmentState.STA)
            'dThread.Start()
            ShowSettings()
        Catch ex As Exception
            Me.SettingsToolStripMenuItem.Enabled = True
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub


    'Private Sub SetUp(ByVal doTheme As Boolean)
    '    Try
    '        With Me
    '            .MinimumSize = New Size(800, 600)
    '            .pnlFilterGenre.Tag = String.Empty
    '            .pnlFilterSource.Tag = String.Empty
    '            .FileToolStripMenuItem.Text = Master.eLang.GetString(1, "&File")
    '            .ExitToolStripMenuItem.Text = Master.eLang.GetString(2, "E&xit")
    '            .cmnuTrayIconExit.Text = Master.eLang.GetString(2, "E&xit")
    '            .EditToolStripMenuItem.Text = Master.eLang.GetString(3, "&Edit")
    '            .SettingsToolStripMenuItem.Text = Master.eLang.GetString(4, "&Settings...")
    '            .cmnuTrayIconSettings.Text = Master.eLang.GetString(4, "&Settings...")
    '            .HelpToolStripMenuItem.Text = Master.eLang.GetString(5, "&Help")
    '            .AboutToolStripMenuItem.Text = Master.eLang.GetString(6, "&About...")
    '            .tslLoading.Text = Master.eLang.GetString(7, "Loading Media:")
    '            .ToolsToolStripMenuItem.Text = Master.eLang.GetString(8, "&Tools")
    '            .cmnuTrayIconTools.Text = Master.eLang.GetString(8, "&Tools")
    '            .CleanFoldersToolStripMenuItem.Text = Master.eLang.GetString(9, "&Clean Files")
    '            .CleanFilesToolStripMenuItem.Text = .CleanFoldersToolStripMenuItem.Text
    '            .ConvertFileSourceToFolderSourceToolStripMenuItem.Text = Master.eLang.GetString(10, "&Sort Files Into Folders")
    '            .SortFilesIntoFoldersToolStripMenuItem.Text = .ConvertFileSourceToFolderSourceToolStripMenuItem.Text
    '            .CopyExistingFanartToBackdropsFolderToolStripMenuItem.Text = Master.eLang.GetString(11, "Copy Existing Fanart To &Backdrops Folder")
    '            .CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Text = .CopyExistingFanartToBackdropsFolderToolStripMenuItem.Text
    '            .SetsManagerToolStripMenuItem.Text = Master.eLang.GetString(14, "Sets &Manager")
    '            .SetsManagerToolStripMenuItem1.Text = .SetsManagerToolStripMenuItem.Text
    '            .ClearAllCachesToolStripMenuItem.Text = Master.eLang.GetString(17, "Clear &All Caches")
    '            .ClearAllCachesToolStripMenuItem1.Text = .ClearAllCachesToolStripMenuItem.Text
    '            .RefreshAllMoviesToolStripMenuItem.Text = Master.eLang.GetString(18, "Re&load All Movies")
    '            .ReloadAllMoviesToolStripMenuItem.Text = .RefreshAllMoviesToolStripMenuItem.Text
    '            .lblGFilClose.Text = Master.eLang.GetString(19, "Close")
    '            .lblSFilClose.Text = Master.eLang.GetString(19, "Close")
    '            .Label4.Text = Master.eLang.GetString(20, "Genres")
    '            .Label8.Text = Master.eLang.GetString(602, "Sources")
    '            .cmnuTitle.Text = Master.eLang.GetString(21, "Title")
    '            .cmnuRefresh.Text = Master.eLang.GetString(22, "Reload")
    '            .cmnuMark.Text = Master.eLang.GetString(23, "Mark")
    '            .cmnuLock.Text = Master.eLang.GetString(24, "Lock")
    '            .cmnuEditMovie.Text = Master.eLang.GetString(25, "Edit Movie")
    '            .GenresToolStripMenuItem.Text = Master.eLang.GetString(20, "Genres")
    '            .LblGenreStripMenuItem2.Text = Master.eLang.GetString(27, ">> Select Genre <<")
    '            .AddGenreToolStripMenuItem.Text = Master.eLang.GetString(28, "Add")
    '            .SetGenreToolStripMenuItem.Text = Master.eLang.GetString(29, "Set")
    '            .RemoveGenreToolStripMenuItem.Text = Master.eLang.GetString(30, "Remove")
    '            .ScrapingToolStripMenuItem.Text = Master.eLang.GetString(31, "(Re)Scrape Selected Movies")
    '            .cmnuSearchNew.Text = Master.eLang.GetString(32, "Change Movie")
    '            .OpenContainingFolderToolStripMenuItem.Text = Master.eLang.GetString(33, "Open Containing Folder")
    '            .cmnuShowOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '            .cmnuSeasonOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '            .cmnuEpOpenFolder.Text = .OpenContainingFolderToolStripMenuItem.Text
    '            .RemoveToolStripMenuItem.Text = Master.eLang.GetString(30, "Remove")
    '            .DeleteMovieToolStripMenuItem.Text = Master.eLang.GetString(34, "Delete Movie")
    '            .RemoveFromDatabaseToolStripMenuItem.Text = Master.eLang.GetString(646, "Remove From Database")
    '            .btnMarkAll.Text = Master.eLang.GetString(35, "Mark All")
    '            .tabMovies.Text = Master.eLang.GetString(36, "Movies")
    '            .tabTV.Text = Master.eLang.GetString(653, "TV")

    '            'pnlCancel.Setup
    '            pnlFilter.Setup()
    '            pnlInfoPanel.Setup()
    '            .tsbAutoPilot.Text = Master.eLang.GetString(67, "Scrape Media")
    '            .cmnuTrayIconScrapeMedia.Text = Master.eLang.GetString(67, "Scrape Media")
    '            .FullToolStripMenuItem.Text = Master.eLang.GetString(68, "All Movies")
    '            .FullAutoToolStripMenuItem.Text = Master.eLang.GetString(69, "Automatic (Force Best Match)")
    '            .mnuAllAutoAll.Text = Master.eLang.GetString(70, "All Items")
    '            .mnuAllAutoNfo.Text = Master.eLang.GetString(71, "NFO Only")
    '            .mnuAllAutoPoster.Text = Master.eLang.GetString(72, "Poster Only")
    '            .mnuAllAutoFanart.Text = Master.eLang.GetString(73, "Fanart Only")
    '            .mnuAllAutoExtra.Text = Master.eLang.GetString(74, "Extrathumbs Only")
    '            .mnuAllAutoTrailer.Text = Master.eLang.GetString(75, "Trailer Only")
    '            .mnuAllAutoMI.Text = Master.eLang.GetString(76, "Meta Data Only")
    '            .FullAskToolStripMenuItem.Text = Master.eLang.GetString(77, "Ask (Require Input If No Exact Match)")
    '            .mnuAllAskAll.Text = mnuAllAutoAll.Text
    '            .mnuAllAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuAllAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuAllAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuAllAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuAllAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuAllAskMI.Text = .mnuAllAutoMI.Text
    '            .UpdateOnlyToolStripMenuItem.Text = Master.eLang.GetString(78, "Movies Missing Items")
    '            .UpdateAutoToolStripMenuItem.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuMissAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuMissAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuMissAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuMissAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuMissAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuMissAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .UpdateAskToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuMissAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuMissAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuMissAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuMissAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuMissAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuMissAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .NewMoviesToolStripMenuItem.Text = Master.eLang.GetString(79, "New Movies")
    '            .AutomaticForceBestMatchToolStripMenuItem.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuNewAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuNewAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuNewAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuNewAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuNewAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuNewAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuNewAutoMI.Text = .mnuAllAutoMI.Text
    '            .AskRequireInputToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuNewAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuNewAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuNewAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuNewAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuNewAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuNewAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuNewAskMI.Text = .mnuAllAutoMI.Text
    '            .MarkedMoviesToolStripMenuItem.Text = Master.eLang.GetString(80, "Marked Movies")
    '            .AutomaticForceBestMatchToolStripMenuItem1.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuMarkAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuMarkAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuMarkAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuMarkAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuMarkAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuMarkAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuMarkAutoMI.Text = .mnuAllAutoMI.Text
    '            .AskRequireInputIfNoExactMatchToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuMarkAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuMarkAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuMarkAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuMarkAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuMarkAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuMarkAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuMarkAskMI.Text = .mnuAllAutoMI.Text
    '            .CurrentFilterToolStripMenuItem.Text = Master.eLang.GetString(624, "Current Filter")
    '            .AutomaticForceBestMatchToolStripMenuItem2.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuFilterAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuFilterAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuFilterAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuFilterAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuFilterAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuFilterAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuFilterAutoMI.Text = .mnuAllAutoMI.Text
    '            .AskRequireInputIfNoExactMatchToolStripMenuItem1.Text = .FullAskToolStripMenuItem.Text
    '            .mnuFilterAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuFilterAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuFilterAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuFilterAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuFilterAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuFilterAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuFilterAskMI.Text = .mnuAllAutoMI.Text
    '            .TrayFullToolStripMenuItem.Text = .FullToolStripMenuItem.Text
    '            .TrayFullAutoToolStripMenuItem.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuTrayAllAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayAllAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayAllAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayAllAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayAllAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayAllAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayAllAutoMI.Text = .mnuAllAutoMI.Text
    '            .TrayFullAskToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuTrayAllAskAll.Text = mnuAllAutoAll.Text
    '            .mnuTrayAllAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayAllAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayAllAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayAllAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayAllAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayAllAskMI.Text = .mnuAllAutoMI.Text
    '            .UpdateOnlyToolStripMenuItem.Text = .UpdateOnlyToolStripMenuItem.Text
    '            .TrayUpdateAutoToolStripMenuItem.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuTrayMissAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayMissAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayMissAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayMissAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayMissAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayMissAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .UpdateAskToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuTrayMissAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayMissAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayMissAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayMissAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayMissAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayMissAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .TrayNewMoviesToolStripMenuItem.Text = .NewMoviesToolStripMenuItem.Text
    '            .TrayAutomaticForceBestMatchToolStripMenuItem.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuTrayNewAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayNewAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayNewAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayNewAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayNewAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayNewAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayNewAutoMI.Text = .mnuAllAutoMI.Text
    '            .TrayAskRequireInputToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuTrayNewAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayNewAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayNewAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayNewAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayNewAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayNewAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayNewAskMI.Text = .mnuAllAutoMI.Text
    '            .TrayMarkedMoviesToolStripMenuItem.Text = .MarkedMoviesToolStripMenuItem.Text
    '            .TrayAutomaticForceBestMatchToolStripMenuItem1.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuTrayMarkAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayMarkAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayMarkAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayMarkAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayMarkAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayMarkAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayMarkAutoMI.Text = .mnuAllAutoMI.Text
    '            .TrayAskRequireInputIfNoExactMatchToolStripMenuItem.Text = .FullAskToolStripMenuItem.Text
    '            .mnuTrayMarkAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayMarkAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayMarkAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayMarkAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayMarkAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayMarkAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayMarkAskMI.Text = .mnuAllAutoMI.Text
    '            .TrayCurrentFilterToolStripMenuItem.Text = .CurrentFilterToolStripMenuItem.Text
    '            .TrayAutomaticForceBestMatchToolStripMenuItem2.Text = .FullAutoToolStripMenuItem.Text
    '            .mnuTrayFilterAutoAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayFilterAutoNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayFilterAutoPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayFilterAutoFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayFilterAutoExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayFilterAutoTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayFilterAutoMI.Text = .mnuAllAutoMI.Text
    '            .TrayAskRequireInputIfNoExactMatchToolStripMenuItem1.Text = .FullAskToolStripMenuItem.Text
    '            .mnuTrayFilterAskAll.Text = .mnuAllAutoAll.Text
    '            .mnuTrayFilterAskNfo.Text = .mnuAllAutoNfo.Text
    '            .mnuTrayFilterAskPoster.Text = .mnuAllAutoPoster.Text
    '            .mnuTrayFilterAskFanart.Text = .mnuAllAutoFanart.Text
    '            .mnuTrayFilterAskExtra.Text = .mnuAllAutoExtra.Text
    '            .mnuTrayFilterAskTrailer.Text = .mnuAllAutoTrailer.Text
    '            .mnuTrayFilterAskMI.Text = .mnuAllAutoMI.Text
    '            .mnuMoviesUpdate.Text = Master.eLang.GetString(36, "Movies")
    '            .mnuTVShowUpdate.Text = Master.eLang.GetString(698, "TV Shows")
    '            .cmnuEditEpisode.Text = Master.eLang.GetString(656, "Edit Episode")
    '            .cmnuEditShow.Text = Master.eLang.GetString(663, "Edit Show")
    '            .CustomUpdaterToolStripMenuItem.Text = Master.eLang.GetString(81, "Custom Scraper...")
    '            .TrayCustomUpdaterToolStripMenuItem.Text = .CustomUpdaterToolStripMenuItem.Text
    '            .tsbRefreshMedia.Text = Master.eLang.GetString(82, "Update Library")
    '            .cmnuTrayIconUpdateMedia.Text = Master.eLang.GetString(82, "Update Library")
    '            .tsbMediaCenters.Text = Master.eLang.GetString(83, "Media Centers")
    '            .cmnuTrayIconMediaCenters.Text = .tsbMediaCenters.Text
    '            .Label6.Text = Master.eLang.GetString(579, "File Source:")
    '            .GroupBox1.Text = Master.eLang.GetString(600, "Extra Sorting")
    '            .btnSortDate.Text = Master.eLang.GetString(601, "Date Added")
    '            .cmnuMetaData.Text = Master.eLang.GetString(603, "Edit Meta Data")
    '            .btnSortTitle.Text = Master.eLang.GetString(642, "Sort Title")
    '            .btnIMDBRating.Text = Master.eLang.GetString(400, "Rating")
    '            .DonateToolStripMenuItem.Text = Master.eLang.GetString(708, "Donate")
    '            .CleanDatabaseToolStripMenuItem.Text = Master.eLang.GetString(709, "Clean Database")
    '            .cmnuReloadShow.Text = Master.eLang.GetString(22, "Reload")
    '            .cmnuMarkShow.Text = Master.eLang.GetString(23, "Mark")
    '            .cmnuLockShow.Text = Master.eLang.GetString(24, "Lock")
    '            .cmnuEditShow.Text = Master.eLang.GetString(663, "Edit Show")
    '            .cmnuRescrapeShow.Text = Master.eLang.GetString(766, "(Re)Scrape Show")
    '            .cmnuChangeShow.Text = Master.eLang.GetString(767, "Change Show")
    '            .RemoveShowToolStripMenuItem.Text = Master.eLang.GetString(30, "Remove")
    '            .cmnuRemoveTVShow.Text = Master.eLang.GetString(646, "Remove from Database")
    '            .cmnuDeleteTVShow.Text = Master.eLang.GetString(768, "Delete TV Show")
    '            .cmnuReloadSeason.Text = Master.eLang.GetString(22, "Reload")
    '            .cmnuMarkSeason.Text = Master.eLang.GetString(23, "Mark")
    '            .cmnuLockSeason.Text = Master.eLang.GetString(24, "Lock")
    '            .cmnuSeasonChangeImages.Text = Master.eLang.GetString(770, "Change Images")
    '            .cmnuSeasonRescrape.Text = Master.eLang.GetString(146, "(Re)Scrape Season")
    '            .cmnuSeasonRemove.Text = Master.eLang.GetString(30, "Remove")
    '            .cmnuRemoveSeasonFromDB.Text = Master.eLang.GetString(646, "Remove from Database")
    '            .cmnuDeleteSeason.Text = Master.eLang.GetString(771, "Delete Season")
    '            .cmnuReloadEp.Text = Master.eLang.GetString(22, "Reload")
    '            .cmnuMarkEp.Text = Master.eLang.GetString(23, "Mark")
    '            .cmnuLockEp.Text = Master.eLang.GetString(24, "Lock")
    '            .cmnuEditEpisode.Text = Master.eLang.GetString(656, "Edit Episode")
    '            .cmnuRescrapeEp.Text = Master.eLang.GetString(147, "(Re)Scrape Episode")
    '            .cmnuChangeEp.Text = Master.eLang.GetString(772, "Change Episode")
    '            .RemoveEpToolStripMenuItem.Text = Master.eLang.GetString(30, "Remove")
    '            .cmnuRemoveTVEp.Text = Master.eLang.GetString(646, "Remove from Database")
    '            .cmnuDeleteTVEp.Text = Master.eLang.GetString(773, "Delete Episode")
    '            .DonateToolStripMenuItem.Text = Master.eLang.GetString(792, "Donate")
    '            .VersionsToolStripMenuItem.Text = Master.eLang.GetString(793, "&Versions...")
    '            .Label7.Text = Master.eLang.GetString(484, "Loading Settings...")
    '            .cmnuRescrape.Text = Master.eLang.GetString(163, "(Re)Scrape Movie")
    '            .ScrapingToolStripMenuItem.Text = Master.eLang.GetString(164, "(Re)Scrape Selected Movies")

    '            Dim TT As ToolTip = New System.Windows.Forms.ToolTip(.components)
    '            .tsbAutoPilot.ToolTipText = Master.eLang.GetString(84, "Scrape/download data from the internet for multiple movies.")
    '            .tsbRefreshMedia.ToolTipText = Master.eLang.GetString(85, "Scans sources for new content and cleans database.")
    '            TT.SetToolTip(.btnMarkAll, Master.eLang.GetString(87, "Mark or Unmark all movies in the list."))
    '            TT.SetToolTip(.txtSearch, Master.eLang.GetString(88, "Search the movie titles by entering text here."))
    '            TT.SetToolTip(.btnPlay, Master.eLang.GetString(89, "Play the movie file with the system default media player."))
    '            TT.SetToolTip(.btnMetaDataRefresh, Master.eLang.GetString(90, "Rescan and save the meta data for the selected movie."))
    '            TT.SetToolTip(.chkFilterDupe, Master.eLang.GetString(91, "Display only movies that have duplicate IMDB IDs."))
    '            TT.SetToolTip(.chkFilterTolerance, Master.eLang.GetString(92, "Display only movies whose title matching is out of tolerance."))
    '            TT.SetToolTip(.chkFilterMissing, Master.eLang.GetString(93, "Display only movies that have items missing."))
    '            TT.SetToolTip(.chkFilterNew, Master.eLang.GetString(94, "Display only new movies."))
    '            TT.SetToolTip(.chkFilterMark, Master.eLang.GetString(95, "Display only marked movies."))
    '            TT.SetToolTip(.chkFilterLock, Master.eLang.GetString(96, "Display only locked movies."))
    '            TT.SetToolTip(.txtFilterSource, Master.eLang.GetString(97, "Display only movies from the selected source."))
    '            TT.SetToolTip(.cbFilterFileSource, Master.eLang.GetString(580, "Display only movies from the selected file source."))
    '            TT.Active = True

    '        End With
    '    Catch ex As Exception
    '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '    End Try
    'End Sub



    Private Sub ShowSettings()
        Using dSettings As New Settings
            'If Me.InvokeRequired Then
            'Me.Invoke(New MySettingsShow(AddressOf SettingsShow), dSettings)
            '            Else
            SettingsShow(dSettings)
            '            End If
        End Using
    End Sub

    '    Private Sub SourceSubClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim SourceName As String = DirectCast(sender, ToolStripItem).Tag.ToString
    '        Me.LoadMedia(New Structures.Scans With {.Movies = True}, SourceName)
    '    End Sub

    '    Private Sub tabsMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Me.ClearInfo()
    '        Me.ShowNoInfo(False)
    '        ModulesManager.Instance.RuntimeObjects.MediaTabSelected = tabsMain.SelectedIndex
    '        Select Case tabsMain.SelectedIndex
    '            Case 0
    '                Me.ToolsToolStripMenuItem.Enabled = True
    '                Me.cmnuTrayIconTools.Enabled = True
    '                Me.pnlFilter.Visible = True
    '                Me.pnlListTop.Height = 56
    '                Me.btnMarkAll.Visible = True
    '                Me.scTV.Visible = False
    '                Me.dgvMediaList.Visible = True
    '                If Me.bwLoadEpInfo.IsBusy Then Me.bwLoadEpInfo.CancelAsync()
    '                If Me.bwLoadSeasonInfo.IsBusy Then Me.bwLoadSeasonInfo.CancelAsync()
    '                If Me.bwLoadShowInfo.IsBusy Then Me.bwLoadShowInfo.CancelAsync()
    '                If Me.bwDownloadPic.IsBusy Then Me.bwDownloadPic.CancelAsync()
    '                If Me.dgvMediaList.RowCount > 0 Then
    '                    Me.prevRow = -1

    '                    Me.dgvMediaList.CurrentCell = Nothing
    '                    Me.dgvMediaList.ClearSelection()
    '                    Me.dgvMediaList.Rows(0).Selected = True
    '                    Me.dgvMediaList.CurrentCell = Me.dgvMediaList.Rows(0).Cells(3)

    '                    Me.dgvMediaList.Focus()
    '                End If
    '            Case 1
    '                Me.ToolsToolStripMenuItem.Enabled = True
    '                Me.cmnuTrayIconTools.Enabled = False
    '                Me.tsbAutoPilot.Enabled = False
    '                Me.cmnuTrayIconScrapeMedia.Enabled = False
    '                Me.dgvMediaList.Visible = False
    '                Me.pnlFilter.Visible = False
    '                Me.pnlListTop.Height = 23
    '                Me.btnMarkAll.Visible = False
    '                Me.scTV.Visible = True
    '                If Me.bwLoadInfo.IsBusy Then Me.bwLoadInfo.CancelAsync()
    '                If Me.bwDownloadPic.IsBusy Then Me.bwDownloadPic.CancelAsync()
    '                If Me.dgvTVShows.RowCount > 0 Then
    '                    Me.prevShowRow = -1
    '                    Me.currList = 0

    '                    Me.dgvTVShows.CurrentCell = Nothing
    '                    Me.dgvTVShows.ClearSelection()
    '                    Me.dgvTVShows.Rows(0).Selected = True
    '                    Me.dgvTVShows.CurrentCell = Me.dgvTVShows.Rows(0).Cells(1)

    '                    Me.dgvTVShows.Focus()

    '                End If
    '        End Select
    '    End Sub




    '    Private Sub tmrLoadEp_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLoadEp.Tick
    '        Me.tmrWaitEp.Stop()
    '        Me.tmrLoadEp.Stop()
    '        Try

    '            If Me.dgvTVEpisodes.SelectedRows.Count > 0 Then

    '                If Me.dgvTVEpisodes.SelectedRows.Count > 1 Then
    '                    Me.SetStatus(String.Format(Master.eLang.GetString(627, "Selected Items: {0}"), Me.dgvTVEpisodes.SelectedRows.Count))
    '                ElseIf Me.dgvTVEpisodes.SelectedRows.Count = 1 Then
    '                    Me.SetStatus(Me.dgvTVEpisodes.SelectedRows(0).Cells(3).Value.ToString)
    '                End If

    '                Me.SelectEpisodeRow(Me.dgvTVEpisodes.SelectedRows(0).Index)
    '            End If
    '        Catch
    '        End Try
    '    End Sub

    '    Private Sub tmrLoadSeason_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLoadSeason.Tick
    '        Me.tmrWaitSeason.Stop()
    '        Me.tmrLoadSeason.Stop()
    '        Try
    '            If Me.dgvTVSeasons.SelectedRows.Count > 0 Then

    '                If Me.dgvTVSeasons.SelectedRows.Count > 1 Then
    '                    Me.SetStatus(String.Format(Master.eLang.GetString(627, "Selected Items: {0}"), Me.dgvTVSeasons.SelectedRows.Count))
    '                ElseIf Me.dgvMediaList.SelectedRows.Count = 1 Then
    '                    Me.SetStatus(Me.dgvTVSeasons.SelectedRows(0).Cells(1).Value.ToString)
    '                End If

    '                Me.SelectSeasonRow(Me.dgvTVSeasons.SelectedRows(0).Index)
    '            End If
    '        Catch
    '        End Try
    '    End Sub

    '    Private Sub tmrLoadShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLoadShow.Tick
    '        Me.tmrWaitShow.Stop()
    '        Me.tmrLoadShow.Stop()
    '        Try
    '            If Me.dgvTVShows.SelectedRows.Count > 0 Then

    '                If Me.dgvTVShows.SelectedRows.Count > 1 Then
    '                    Me.SetStatus(String.Format(Master.eLang.GetString(627, "Selected Items: {0}"), Me.dgvTVShows.SelectedRows.Count))
    '                ElseIf Me.dgvTVShows.SelectedRows.Count = 1 Then
    '                    Me.SetStatus(Me.dgvTVShows.SelectedRows(0).Cells(1).Value.ToString)
    '                End If

    '                Me.SelectShowRow(Me.dgvTVShows.SelectedRows(0).Index)
    '            End If
    '        Catch
    '        End Try
    '    End Sub

    '    Private Sub tmrLoad_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLoad.Tick
    '        Me.tmrWait.Stop()
    '        Me.tmrLoad.Stop()
    '        Try
    '            If Me.dgvMediaList.SelectedRows.Count > 0 Then

    '                If Me.dgvMediaList.SelectedRows.Count > 1 Then
    '                    Me.SetStatus(String.Format(Master.eLang.GetString(627, "Selected Items: {0}"), Me.dgvMediaList.SelectedRows.Count))
    '                ElseIf Me.dgvMediaList.SelectedRows.Count = 1 Then
    '                    Me.SetStatus(Me.dgvMediaList.SelectedRows(0).Cells(1).Value.ToString)
    '                End If

    '                Me.SelectRow(Me.dgvMediaList.SelectedRows(0).Index)
    '            End If
    '        Catch
    '        End Try
    '    End Sub



    '    Private Sub tmrWaitEp_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrWaitEp.Tick
    '        Me.tmrLoadSeason.Stop()
    '        Me.tmrLoadShow.Stop()
    '        Me.tmrWaitSeason.Stop()
    '        Me.tmrWaitShow.Stop()

    '        If Not Me.prevEpRow = Me.currEpRow Then
    '            Me.prevEpRow = Me.currEpRow
    '            Me.tmrWaitEp.Stop()
    '            Me.tmrLoadEp.Start()
    '        Else
    '            Me.tmrLoadEp.Stop()
    '            Me.tmrWaitEp.Stop()
    '        End If
    '    End Sub

    '    Private Sub tmrWaitSeason_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrWaitSeason.Tick
    '        Me.tmrLoadShow.Stop()
    '        Me.tmrLoadEp.Stop()
    '        Me.tmrWaitShow.Stop()
    '        Me.tmrWaitEp.Stop()

    '        If Not Me.prevSeasonRow = Me.currSeasonRow Then
    '            Me.prevSeasonRow = Me.currSeasonRow
    '            Me.tmrWaitSeason.Stop()
    '            Me.tmrLoadSeason.Start()
    '        Else
    '            Me.tmrLoadSeason.Stop()
    '            Me.tmrWaitSeason.Stop()
    '        End If
    '    End Sub

    '    Private Sub tmrWaitShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrWaitShow.Tick
    '        Me.tmrLoadSeason.Stop()
    '        Me.tmrLoadEp.Stop()
    '        Me.tmrWaitSeason.Stop()
    '        Me.tmrWaitEp.Stop()

    '        If Not Me.prevShowRow = Me.currShowRow Then
    '            Me.prevShowRow = Me.currShowRow
    '            Me.tmrWaitShow.Stop()
    '            Me.tmrLoadShow.Start()
    '        Else
    '            Me.tmrLoadShow.Stop()
    '            Me.tmrWaitShow.Stop()
    '        End If
    '    End Sub

    '    Private Sub tmrWait_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrWait.Tick
    '        If Not Me.prevRow = Me.currRow Then
    '            Me.prevRow = Me.currRow
    '            Me.tmrWait.Stop()
    '            Me.tmrLoad.Start()
    '        Else
    '            Me.tmrLoad.Stop()
    '            Me.tmrWait.Stop()
    '        End If
    '    End Sub

    '    Private Sub ToolStripAskMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAskMenuItem19.Click
    '        Functions.SetScraperMod(Enums.ModType.Trailer, True)
    '        MovieScrapeData(True, Enums.ScrapeType.FullAsk, Master.DefaultOptions)
    '    End Sub

    '    Private Sub tsbRefreshMedia_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefreshMedia.ButtonClick
    '        Me.LoadMedia(New Structures.Scans With {.Movies = True, .TV = True})
    '    End Sub

    '    Private Sub TVScraperEvent(ByVal eType As Enums.TVScraperEventType, ByVal iProgress As Integer, ByVal Parameter As Object)
    '        Select Case eType
    '            Case Enums.TVScraperEventType.LoadingEpisodes
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Me.tslLoading.Text = Master.eLang.GetString(756, "Loading All Episodes:")
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True
    '            Case Enums.TVScraperEventType.SavingStarted
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Me.tslLoading.Text = Master.eLang.GetString(757, "Saving All Images:")
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True
    '            Case Enums.TVScraperEventType.ScraperDone
    '                Me.RefreshShow(Master.currShow.ShowID, False, False, False, True)

    '                Me.tspbLoading.Visible = False
    '                Me.tslLoading.Visible = False
    '                'Me.tslStatus.Visible = False

    '                Me.SetControlsEnabled(True)

    '            Case Enums.TVScraperEventType.Searching
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Me.tslLoading.Text = Master.eLang.GetString(758, "Searching theTVDB:")
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True
    '            Case Enums.TVScraperEventType.SelectImages
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Me.tslLoading.Text = Master.eLang.GetString(759, "Select Images:")
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True
    '            Case Enums.TVScraperEventType.StartingDownload
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Me.tslLoading.Text = Master.eLang.GetString(760, "Downloading Show Zip:")
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True
    '            Case Enums.TVScraperEventType.SaveAuto
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee
    '                Select Case iProgress
    '                    Case 0 ' show
    '                        Me.SetShowListItemAfterEdit(Convert.ToInt32(Master.currShow.ShowID), Me.dgvTVShows.SelectedRows(0).Index)
    '                        ModulesManager.Instance.TVSaveImages()
    '                End Select

    '            Case Enums.TVScraperEventType.Verifying
    '                Me.tspbLoading.Style = ProgressBarStyle.Marquee

    '                Select Case iProgress
    '                    Case 0 ' show
    '                        Me.tslLoading.Text = Master.eLang.GetString(761, "Verifying TV Show:")
    '                        Me.tspbLoading.Visible = True
    '                        Me.tslLoading.Visible = True
    '                        Using dEditShow As New dlgEditShow
    '                            If dEditShow.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                                Me.SetShowListItemAfterEdit(Convert.ToInt32(Master.currShow.ShowID), Me.dgvTVShows.SelectedRows(0).Index)
    '                                ModulesManager.Instance.TVSaveImages()
    '                            Else
    '                                Me.tspbLoading.Visible = False
    '                                Me.tslLoading.Visible = False

    '                                Me.LoadShowInfo(Convert.ToInt32(Master.currShow.ShowID))

    '                                Me.SetControlsEnabled(True)
    '                            End If
    '                        End Using
    '                    Case 1 ' episode
    '                        Me.tslLoading.Text = Master.eLang.GetString(762, "Verifying TV Episode:")
    '                        Me.tspbLoading.Visible = True
    '                        Me.tslLoading.Visible = True
    '                        Using dEditEp As New dlgEditEpisode
    '                            AddHandler ModulesManager.Instance.GenericEvent, AddressOf dEditEp.GenericRunCallBack
    '                            If dEditEp.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                                Me.RefreshEpisode(Master.currShow.EpID)
    '                            End If
    '                            RemoveHandler ModulesManager.Instance.GenericEvent, AddressOf dEditEp.GenericRunCallBack
    '                        End Using
    '                        Me.tspbLoading.Visible = False
    '                        Me.tslLoading.Visible = False
    '                        Me.SetControlsEnabled(True)
    '                End Select

    '            Case Enums.TVScraperEventType.Progress
    '                Select Case Parameter.ToString
    '                    Case "max"
    '                        Me.tspbLoading.Value = 0
    '                        Me.tspbLoading.Style = ProgressBarStyle.Continuous
    '                        Me.tspbLoading.Maximum = iProgress
    '                    Case "progress"
    '                        Me.tspbLoading.Value = iProgress
    '                End Select
    '                Me.tspbLoading.Visible = True
    '                Me.tslLoading.Visible = True

    '            Case Enums.TVScraperEventType.Cancelled
    '                Me.tspbLoading.Visible = False
    '                Me.tslLoading.Visible = False

    '                Me.LoadShowInfo(Convert.ToInt32(Master.currShow.ShowID))

    '                Me.SetControlsEnabled(True)
    '        End Select
    '    End Sub

    '    Private Sub TVSourceSubClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim SourceName As String = DirectCast(sender, ToolStripItem).Tag.ToString
    '        Me.LoadMedia(New Structures.Scans With {.TV = True}, SourceName)
    '    End Sub

    Private Sub WikiStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WikiStripMenuItem.Click
        If Master.isWindows Then
            Process.Start("http://ember.purplepig.net/projects/embermm/wiki")
        Else
            Using Explorer As New Process
                Explorer.StartInfo.FileName = "xdg-open"
                Explorer.StartInfo.Arguments = "http://ember.purplepig.net/projects/embermm/wiki"
                Explorer.Start()
            End Using
        End If
    End Sub


    '    Private Sub LoadModules()
    '        Dim bulkRenameModule As New Modules.BulkRename.BulkRenamerModule(Me)
    '        bulkRenameModule.Setup()
    '        Dim exportModule As New Modules.MovieExporter.MovieExporterModule(Me)
    '        exportModule.Setup()
    '    End Sub

End Class