Imports System.IO
Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class Sources
        Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnBrowse.Click
            With fbdBrowse
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Not String.IsNullOrEmpty(.SelectedPath.ToString) AndAlso Directory.Exists(.SelectedPath) Then
                        txtBDPath.Text = .SelectedPath.ToString
                    End If
                End If
            End With
        End Sub

        Private Sub btnEditSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditSource.Click
            If lvMovies.SelectedItems.Count > 0 Then
                Using dMovieSource As New dlgMovieSource
                    If dMovieSource.ShowDialog(Convert.ToInt32(lvMovies.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                        RefreshSources()                        
                    End If
                End Using
            End If
        End Sub

        Private Sub chkAutoBD_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkAutoBD.CheckedChanged
            txtBDPath.Enabled = chkAutoBD.Checked
            btnBrowse.Enabled = chkAutoBD.Checked
        End Sub

        Protected Overrides Sub LoadSettings()
            chkMovieTBN.Checked = Master.eSettings.MovieTBN
            chkMovieNameTBN.Checked = Master.eSettings.MovieNameTBN
            chkMovieJPG.Checked = Master.eSettings.MovieJPG
            chkMovieNameJPG.Checked = Master.eSettings.MovieNameJPG
            chkPosterTBN.Checked = Master.eSettings.PosterTBN
            chkPosterJPG.Checked = Master.eSettings.PosterJPG
            chkFolderJPG.Checked = Master.eSettings.FolderJPG
            chkFanartJPG.Checked = Master.eSettings.FanartJPG
            chkMovieNameFanartJPG.Checked = Master.eSettings.MovieNameFanartJPG
            chkMovieNameDotFanartJPG.Checked = Master.eSettings.MovieNameDotFanartJPG
            chkMovieNFO.Checked = Master.eSettings.MovieNFO
            chkMovieNameNFO.Checked = Master.eSettings.MovieNameNFO
            chkMovieNameMultiOnly.Checked = Master.eSettings.MovieNameMultiOnly
            rbDashTrailer.Checked = Master.eSettings.DashTrailer
            rbBracketTrailer.Checked = Not Master.eSettings.DashTrailer
            txtBDPath.Text = Master.eSettings.BDPath
            txtBDPath.Enabled = Master.eSettings.AutoBD
            btnBrowse.Enabled = Master.eSettings.AutoBD
            chkAutoBD.Checked = Master.eSettings.AutoBD
            txtSkipLessThan.Text = Master.eSettings.SkipLessThan.ToString
            chkSkipStackedSizeCheck.Checked = Master.eSettings.SkipStackSizeCheck
            chkAutoDetectVTS.Checked = Master.eSettings.AutoDetectVTS
            chkCleanDB.Checked = Master.eSettings.CleanDB
            chkIgnoreLastScan.Checked = Master.eSettings.IgnoreLastScan
            chkSortBeforeScan.Checked = Master.eSettings.SortBeforeScan
            chkScanOrderModify.Checked = Master.eSettings.ScanOrderModify
            RefreshSources()
        End Sub

        Private Sub lvMovies_ColumnClick(ByVal sender As Object, ByVal e As Windows.Forms.ColumnClickEventArgs) Handles lvMovies.ColumnClick
            lvMovies.ListViewItemSorter = New StringUtils.ListViewItemComparer(e.Column)
        End Sub

        Private Sub lvMovies_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvMovies.DoubleClick
            If lvMovies.SelectedItems.Count > 0 Then
                Using dMovieSource As New dlgMovieSource
                    If dMovieSource.ShowDialog(Convert.ToInt32(lvMovies.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                        RefreshSources()
                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
                    End If
                End Using
            End If
        End Sub

        Private Sub RefreshSources()
            Dim lvItem As ListViewItem

            lvMovies.Items.Clear()
            Master.MovieSources.Clear()
            Master.MovieSources.AddRange(Classes.Database.GetMovieSources())
            For Each s As Model.Source In Master.MovieSources
                lvItem = New ListViewItem(s.ID)
                lvItem.SubItems.Add(s.Name)
                lvItem.SubItems.Add(s.path)
                lvItem.SubItems.Add(If(s.Recursive, "Yes", "No"))
                lvItem.SubItems.Add(If(s.Foldername, "Yes", "No"))
                lvItem.SubItems.Add(If(s.Single, "Yes", "No"))
                lvMovies.Items.Add(lvItem)
            Next
        End Sub

        Private Sub RemoveMovieSource()
            Try
                If lvMovies.SelectedItems.Count > 0 Then
                    If MsgBox(Master.eLang.GetString(418, "Are you sure you want to remove the selected sources? This will remove the movies from these sources from the Ember database."), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                        lvMovies.BeginUpdate()

                        Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
                            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                                Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.String, 0, "source")
                                While lvMovies.SelectedItems.Count > 0
                                    parSource.Value = lvMovies.SelectedItems(0).SubItems(1).Text
                                    SQLcommand.CommandText = "SELECT Id FROM movies WHERE source = (?);"
                                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                        While SQLReader.Read
                                            Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                        End While
                                    End Using
                                    SQLcommand.CommandText = String.Concat("DELETE FROM sources WHERE name = (?);")
                                    SQLcommand.ExecuteNonQuery()
                                    lvMovies.Items.Remove(lvMovies.SelectedItems(0))
                                End While
                            End Using
                            SQLtransaction.Commit()
                        End Using

                        lvMovies.Sort()
                        lvMovies.EndUpdate()
                        lvMovies.Refresh()

                        Functions.GetListOfSources()

                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
                    End If
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub lvMovies_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lvMovies.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveMovieSource()
        End Sub

        Private Sub btnMovieAddFolders_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnMovieAddFolder.Click
            Using dSource As New dlgMovieSource
                If dSource.ShowDialog = Windows.Forms.DialogResult.OK Then
                    RefreshSources()                    
                End If
            End Using
        End Sub

        Private Sub btnMovieRem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnMovieRem.Click
            RemoveMovieSource()
            RefreshSources()
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.MovieTBN = chkMovieTBN.Checked
            Master.eSettings.MovieNameTBN = chkMovieNameTBN.Checked
            Master.eSettings.MovieJPG = chkMovieJPG.Checked
            Master.eSettings.MovieNameJPG = chkMovieNameJPG.Checked
            Master.eSettings.PosterTBN = chkPosterTBN.Checked
            Master.eSettings.PosterJPG = chkPosterJPG.Checked
            Master.eSettings.FolderJPG = chkFolderJPG.Checked
            Master.eSettings.FanartJPG = chkFanartJPG.Checked
            Master.eSettings.MovieNameFanartJPG = chkMovieNameFanartJPG.Checked
            Master.eSettings.MovieNameDotFanartJPG = chkMovieNameDotFanartJPG.Checked
            Master.eSettings.MovieNFO = chkMovieNFO.Checked
            Master.eSettings.MovieNameNFO = chkMovieNameNFO.Checked
            Master.eSettings.MovieNameMultiOnly = chkMovieNameMultiOnly.Checked
            Master.eSettings.DashTrailer = rbDashTrailer.Checked
            Master.eSettings.BDPath = txtBDPath.Text
            If Not String.IsNullOrEmpty(txtBDPath.Text) Then
                Master.eSettings.AutoBD = chkAutoBD.Checked
            Else
                Master.eSettings.AutoBD = False
            End If
            Master.eSettings.SkipLessThan = Convert.ToInt32(txtSkipLessThan.Text)
            Master.eSettings.SkipStackSizeCheck = chkSkipStackedSizeCheck.Checked
            Master.eSettings.AutoDetectVTS = chkAutoDetectVTS.Checked
            Master.eSettings.CleanDB = chkCleanDB.Checked
            Master.eSettings.IgnoreLastScan = chkIgnoreLastScan.Checked
            Master.eSettings.SortBeforeScan = chkSortBeforeScan.Checked
            Master.eSettings.ScanOrderModify = chkScanOrderModify.Checked
        End Sub

        Protected Overrides Sub LoadResources()
            chkMovieNameMultiOnly.Text = Master.eLang.GetString(472, "Use <movie> Only for Folders with Multiple Movies")
            gbFileNaming.Text = Master.eLang.GetString(151, "Trailer")
            colName.Text = Master.eLang.GetString(232, "Name")
            colPath.Text = Master.eLang.GetString(410, "Path")
            colRecur.Text = Master.eLang.GetString(411, "Recursive")
            colFolder.Text = Master.eLang.GetString(412, "Use Folder Name")
            colSingle.Text = Master.eLang.GetString(413, "Single Video")
            btnMovieRem.Text = Master.eLang.GetString(30, "Remove")
            btnMovieAddFolder.Text = Master.eLang.GetString(407, "Add Source")
            chkAutoBD.Text = Master.eLang.GetString(521, "Automatically Save Fanart To Backdrops Folder")
            gbTrailer.Text = Master.eLang.GetString(530, "No Stack Extensions")
            btnEditSource.Text = Master.eLang.GetString(535, "Edit Source")
            chkAutoDetectVTS.Text = Master.eLang.GetString(537, "Automatically Detect VIDEO_TS Folders Even if They Are Not Named ""VIDEO_TS""")
            chkSkipStackedSizeCheck.Text = Master.eLang.GetString(538, "Skip Size Check of Stacked Files")
            lblMB.Text = Master.eLang.GetString(539, "MB")
            lblSkipSmallFiles.Text = Master.eLang.GetString(540, "Skip files smaller than:")
            gbPosters.Text = Master.eLang.GetString(577, "Scraper Fields")
            chkCleanDB.Text = Master.eLang.GetString(668, "Clean database after updating library")
            chkIgnoreLastScan.Text = Master.eLang.GetString(669, "Ignore last scan time when updating library")
            chkSortBeforeScan.Text = Master.eLang.GetString(712, "Sort files into folder before each library update")
            gbBackdrops.Text = Master.eLang.GetString(488, "Global Locks")
            chkScanOrderModify.Text = Master.eLang.GetString(796, "Scan in order of last write time")
            lvMovies.Columns(1).Text = Master.eLang.GetString(232, "Name")
            lvMovies.Columns(2).Text = Master.eLang.GetString(410, "Path")
            lvMovies.Columns(3).Text = Master.eLang.GetString(411, "Recursive")
            lvMovies.Columns(4).Text = Master.eLang.GetString(412, "Use Folder Name")
            lvMovies.Columns(5).Text = Master.eLang.GetString(413, "Single Video")
            lvMovies.ListViewItemSorter = New StringUtils.ListViewItemComparer(1)            
        End Sub

        Private Sub txtSkipLessThan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSkipLessThan.TextChanged
            OnControlValueChanged(Nothing, New ControlValueChangedArgs(True))
        End Sub
    End Class
End Namespace