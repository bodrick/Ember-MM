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
Imports System.Drawing
Imports System.IO
Imports EmberMediaManger.API

Namespace Modules.BulkRename

    Public Class dlgBulkRenamer

#Region "Fields"

        Friend WithEvents bwDoRename As New System.ComponentModel.BackgroundWorker
        Friend WithEvents bwLoadInfo As New System.ComponentModel.BackgroundWorker

        Private bsMovies As New BindingSource
        Private CancelRename As Boolean = False
        Private DoneRename As Boolean = False
        Private FFRenamer As FileFolderRenamer
        Private isLoaded As Boolean = False
        Private run_once As Boolean = True
        Private _columnsize(9) As Integer
        Private dHelpTips As dlgHelpTips
#End Region 'Fields

#Region "Delegates"

        Delegate Sub MyFinish()

        Delegate Sub MyStart()

#End Region 'Delegates

#Region "Methods"

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCancel.Click
            If DoneRename Then
                CancelRename = True
            Else
                DoCancel()
            End If
        End Sub

        Private Sub bwbwDoRename_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDoRename.RunWorkerCompleted
            pnlCancel.Visible = False
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub bwDoRename_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDoRename.DoWork
            FFRenamer.DoRename(AddressOf ShowProgressRename)
        End Sub

        Private Sub bwDoRename_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDoRename.ProgressChanged
            pbCompile.Value = e.ProgressPercentage
            lblFile.Text = e.UserState.ToString
        End Sub

        Private Sub bwLoadInfo_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadInfo.DoWork
            '//
            ' Thread to load movieinformation (from nfo)
            '\\
            Try
                Dim MovieFile As FileFolderRenamer.FileRename
                Dim _curMovie As Model.Movie

                ' Load nfo movies using path from DB
                Using SQLNewcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                    Dim _tmpPath As String = String.Empty
                    Dim iProg As Integer = 0
                    SQLNewcommand.CommandText = String.Concat("SELECT COUNT(id) AS mcount FROM movies;")
                    Using SQLcount As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
                        bwLoadInfo.ReportProgress(-1, SQLcount("mcount")) ' set maximum
                    End Using
                    SQLNewcommand.CommandText = String.Concat("SELECT NfoPath ,id FROM movies ORDER BY ListTitle ASC;")
                    Using SQLreader As SQLite.SQLiteDataReader = SQLNewcommand.ExecuteReader()
                        If SQLreader.HasRows Then
                            While SQLreader.Read()
                                Try
                                    If Not DBNull.Value.Equals(SQLreader("NfoPath")) AndAlso Not DBNull.Value.Equals(SQLreader("id")) Then
                                        _tmpPath = SQLreader("NfoPath").ToString
                                        If Not String.IsNullOrEmpty(_tmpPath) Then

                                            MovieFile = New FileFolderRenamer.FileRename
                                            MovieFile.ID = Convert.ToInt32(SQLreader("id"))
                                            _curMovie = Classes.Database.GetMovie(MovieFile.ID)
                                            If Not _curMovie.ID = -1 AndAlso Not String.IsNullOrEmpty(_curMovie.MoviePath) Then
                                                If String.IsNullOrEmpty(_curMovie.Title) Then
                                                    MovieFile.Title = _curMovie.ListTitle
                                                Else
                                                    MovieFile.Title = _curMovie.Title
                                                End If
                                                If String.IsNullOrEmpty(_curMovie.SortTitle) Then
                                                    MovieFile.SortTitle = MovieFile.Title
                                                Else
                                                    MovieFile.SortTitle = _curMovie.SortTitle
                                                End If
                                                MovieFile.ListTitle = _curMovie.ListTitle
                                                MovieFile.MPAARate = FileFolderRenamer.SelectMPAA(_curMovie)
                                                MovieFile.OriginalTitle = _curMovie.OriginalTitle
                                                MovieFile.Year = _curMovie.Year
                                                MovieFile.IsLocked = _curMovie.Lock
                                                MovieFile.IsSingle = _curMovie.UseFolder
                                                MovieFile.IMDBID = _curMovie.Imdb
                                                MovieFile.Genre = _curMovie.Genre
                                                MovieFile.Director = _curMovie.Director
                                                MovieFile.FileSource = _curMovie.FileSource

                                                If Not IsNothing(_curMovie.FileInfo) Then
                                                    Try
                                                        If _curMovie.FileInfo.StreamDetails.Video.Count > 0 Then
                                                            Dim tVid As MediaInfo.Video = MediaInfo.GetBestVideo(_curMovie.FileInfo)
                                                            Dim tRes As String = MediaInfo.GetResFromDimensions(tVid)
                                                            MovieFile.Resolution = String.Format("{0}", If(String.IsNullOrEmpty(tRes), Master.eLang.GetString(283, "Unknown", True), tRes))
                                                        Else
                                                            MovieFile.Resolution = String.Empty
                                                        End If

                                                        If _curMovie.FileInfo.StreamDetails.Audio.Count > 0 Then
                                                            Dim tAud As MediaInfo.Audio = MediaInfo.GetBestAudio(_curMovie.FileInfo, False)
                                                            MovieFile.Audio = String.Format("{0}-{1}ch", If(String.IsNullOrEmpty(tAud.Codec), Master.eLang.GetString(283, "Unknown", True), tAud.Codec), If(String.IsNullOrEmpty(tAud.Channels), Master.eLang.GetString(283, "Unknown", True), tAud.Channels))
                                                        Else
                                                            MovieFile.Audio = String.Empty
                                                        End If
                                                    Catch ex As Exception
                                                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error FileInfo")
                                                    End Try
                                                Else
                                                    MovieFile.Resolution = String.Empty
                                                    MovieFile.Audio = String.Empty
                                                End If

                                                For Each i As String In FFRenamer.MovieFolders
                                                    If _curMovie.MoviePath.StartsWith(i, StringComparison.OrdinalIgnoreCase) Then
                                                        MovieFile.BasePath = If(i.EndsWith(Path.DirectorySeparatorChar.ToString), i.Substring(0, i.Length - 1), i)
                                                        If FileUtils.isVideoTS(_curMovie.MoviePath) Then
                                                            MovieFile.Parent = Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).Name
                                                            If MovieFile.BasePath = Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName Then
                                                                MovieFile.OldPath = String.Empty
                                                                MovieFile.BasePath = Directory.GetParent(MovieFile.BasePath).FullName
                                                            Else
                                                                MovieFile.OldPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName).FullName.Replace(MovieFile.BasePath, String.Empty)
                                                            End If
                                                            MovieFile.IsVideo_TS = True
                                                        ElseIf FileUtils.isBDRip(_curMovie.MoviePath) Then
                                                            MovieFile.Parent = Directory.GetParent(Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName).Name
                                                            If MovieFile.BasePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName).FullName Then
                                                                MovieFile.OldPath = String.Empty
                                                                MovieFile.BasePath = Directory.GetParent(MovieFile.BasePath).FullName
                                                            Else
                                                                MovieFile.OldPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName).FullName).FullName.Replace(MovieFile.BasePath, String.Empty)
                                                            End If
                                                            MovieFile.IsBDMV = True
                                                        Else
                                                            MovieFile.Parent = Directory.GetParent(_curMovie.MoviePath).Name
                                                            If MovieFile.BasePath = Directory.GetParent(_curMovie.MoviePath).FullName Then
                                                                MovieFile.OldPath = String.Empty
                                                                MovieFile.BasePath = Directory.GetParent(MovieFile.BasePath).FullName
                                                            Else
                                                                MovieFile.OldPath = Directory.GetParent(Directory.GetParent(_curMovie.MoviePath).FullName).FullName.Replace(MovieFile.BasePath, String.Empty)
                                                            End If
                                                        End If
                                                    End If
                                                Next

                                                If Not MovieFile.IsVideo_TS AndAlso Not MovieFile.IsBDMV Then
                                                    MovieFile.FileName = StringUtils.CleanStackingMarkers(Path.GetFileNameWithoutExtension(_curMovie.MoviePath))
                                                    Dim stackMark As String = Path.GetFileNameWithoutExtension(_curMovie.MoviePath).Replace(MovieFile.FileName, String.Empty).ToLower
                                                    If Not stackMark = String.Empty AndAlso _curMovie.Title.ToLower.EndsWith(stackMark) Then
                                                        MovieFile.FileName = Path.GetFileNameWithoutExtension(_curMovie.MoviePath)
                                                    End If
                                                ElseIf MovieFile.IsBDMV Then
                                                    MovieFile.FileName = String.Concat("BDMV", Path.DirectorySeparatorChar, "STREAM")
                                                Else
                                                    MovieFile.FileName = "VIDEO_TS"
                                                End If

                                                FFRenamer.AddMovie(MovieFile)

                                                bwLoadInfo.ReportProgress(iProg, _curMovie.ListTitle)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                                End Try
                                iProg += 1

                                If bwLoadInfo.CancellationPending Then
                                    e.Cancel = True
                                    Return
                                End If
                            End While
                            e.Result = True
                        Else
                            e.Cancel = True
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub bwLoadInfo_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwLoadInfo.ProgressChanged
            If e.ProgressPercentage >= 0 Then
                pbCompile.Value = e.ProgressPercentage
                lblFile.Text = e.UserState.ToString
            Else
                pbCompile.Maximum = Convert.ToInt32(e.UserState)
            End If
        End Sub

        Private Sub bwLoadInfo_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoadInfo.RunWorkerCompleted
            '//
            ' Thread finished: display it if not cancelled
            '\\
            Try
                If Not e.Cancelled Then
                    Rename_Button.Enabled = True
                    isLoaded = True
                    tmrSimul.Enabled = True
                Else
                End If
                pnlCancel.Visible = False
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub chkRenamedOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkRenamedOnly.CheckedChanged
            If chkRenamedOnly.Checked Then
                bsMovies.Filter = "IsRenamed = True AND IsLocked = False"
            Else
                bsMovies.RemoveFilter()
            End If
        End Sub

        Private Sub Close_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Close_Button.Click
            If DoneRename Then
                DialogResult = Windows.Forms.DialogResult.OK
            Else
                DialogResult = Windows.Forms.DialogResult.Cancel
            End If

            Close()
        End Sub

        Private Sub cmsMovieList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsMovieList.Opening
            Dim count As Integer = FFRenamer.GetCount
            Dim lockcount As Integer = FFRenamer.GetCountLocked
            If count > 0 Then
                If lockcount > 0 Then
                    tsmUnlockAll.Visible = True
                    If lockcount < count Then
                        tsmLockAll.Visible = True
                    Else
                        tsmLockAll.Visible = False
                    End If
                    If lockcount = count Then
                        tsmLockAll.Visible = False
                    End If

                Else
                    tsmLockAll.Visible = True
                    tsmUnlockAll.Visible = False
                End If
            Else
                tsmUnlockAll.Visible = False
                tsmLockAll.Visible = False
            End If
            tsmLockMovie.Visible = False
            tsmUnlockMovie.Visible = False
            For Each row As DataGridViewRow In dgvMoviesList.SelectedRows
                If Convert.ToBoolean(row.Cells(5).Value) Then
                    tsmUnlockMovie.Visible = True
                Else
                    tsmLockMovie.Visible = True
                End If
            Next
        End Sub

        Private Sub dgvMoviesList_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvMoviesList.CellPainting
            Try

                If (e.ColumnIndex = 3 OrElse e.ColumnIndex = 4) AndAlso e.RowIndex >= 0 Then
                    If Convert.ToBoolean(dgvMoviesList.Rows(e.RowIndex).Cells(5).Value) Then
                        e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                        e.CellStyle.ForeColor = Color.Red
                    ElseIf Not IsNothing(e.Value) AndAlso Not dgvMoviesList.Rows(e.RowIndex).Cells(e.ColumnIndex - 2).Value.ToString = e.Value.ToString Then
                        e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                        If (Convert.ToBoolean(dgvMoviesList.Rows(e.RowIndex).Cells(6).Value) AndAlso e.ColumnIndex = 3) OrElse (Convert.ToBoolean(dgvMoviesList.Rows(e.RowIndex).Cells(7).Value) AndAlso e.ColumnIndex = 4) Then
                            e.CellStyle.ForeColor = Color.Purple
                        Else
                            e.CellStyle.ForeColor = Color.Blue
                        End If
                    End If
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub dgvMoviesList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMoviesList.ColumnHeaderMouseClick
            dgvMoviesList.Sort(dgvMoviesList.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
        End Sub

        Private Sub dgvMoviesList_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvMoviesList.ColumnWidthChanged
            If Not dgvMoviesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None OrElse dgvMoviesList.Columns.Count < 9 OrElse Convert.ToBoolean(dgvMoviesList.Tag) Then Return
            Dim sum As Integer = (From c As DataGridViewColumn In dgvMoviesList.Columns.OfType(Of DataGridViewColumn)() Where c.Visible).Sum(Function(c) c.Width)
            If sum < dgvMoviesList.Width Then
                e.Column.Width = dgvMoviesList.Width - (sum - e.Column.Width)
            End If
        End Sub

        Private Sub dlgBulkRename_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If bwLoadInfo.IsBusy Then
                DoCancel()
                While bwLoadInfo.IsBusy
                    Application.DoEvents()
                    Threading.Thread.Sleep(50)
                End While
            End If
        End Sub

        Private Sub dlgBulkRename_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetUp()

            FFRenamer = New FileFolderRenamer
            Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
            Using g As Graphics = Graphics.FromImage(iBackground)
                g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
                pnlTop.BackgroundImage = iBackground
            End Using

        End Sub

        Private Sub dlgBulkRename_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
            Activate()

            Try
                ' Show Cancel Panel
                btnCancel.Visible = True
                lblCompiling.Visible = True
                pbCompile.Visible = True
                pbCompile.Style = ProgressBarStyle.Continuous
                lblCanceling.Visible = False
                pnlCancel.Visible = True
                Application.DoEvents()

                'Start worker
                bwLoadInfo = New System.ComponentModel.BackgroundWorker
                bwLoadInfo.WorkerSupportsCancellation = True
                bwLoadInfo.WorkerReportsProgress = True
                bwLoadInfo.RunWorkerAsync()

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub DoCancel()
            Try
                bwLoadInfo.CancelAsync()
                btnCancel.Visible = False
                lblCompiling.Visible = False
                pbCompile.Style = ProgressBarStyle.Marquee
                pbCompile.MarqueeAnimationSpeed = 25
                lblCanceling.Visible = True
                lblFile.Visible = False
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub DoProcess()
            Dim Sta As MyStart = New MyStart(AddressOf Start)
            Dim Fin As MyFinish = New MyFinish(AddressOf Finish)
            Invoke(Sta)
            FFRenamer.ProccessFiles(txtFolder.Text, txtFile.Text, txtFolderNotSingle.Text)
            Invoke(Fin)
        End Sub

        Private Sub Finish()
            Simulate()
            pnlCancel.Visible = False
        End Sub

        Private Sub Rename_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Rename_Button.Click
            DoneRename = True
            pnlCancel.Visible = True
            lblCompiling.Text = Languages.Renaming
            lblFile.Visible = True
            pbCompile.Style = ProgressBarStyle.Continuous
            pbCompile.Maximum = FFRenamer.GetMoviesCount
            pbCompile.Value = 0
            Application.DoEvents()
            'Start worker
            bwDoRename = New System.ComponentModel.BackgroundWorker
            bwDoRename.WorkerSupportsCancellation = True
            bwDoRename.WorkerReportsProgress = True
            bwDoRename.RunWorkerAsync()
        End Sub

        Sub SetLock(ByVal lock As Boolean)
            For Each row As DataGridViewRow In dgvMoviesList.SelectedRows
                FFRenamer.SetIsLocked(row.Cells(1).Value.ToString, row.Cells(2).Value.ToString, lock)
                row.Cells(5).Value = lock
            Next

            If chkRenamedOnly.Checked AndAlso lock Then
                dgvMoviesList.ClearSelection()
                dgvMoviesList.CurrentCell = Nothing
            End If

            dgvMoviesList.Refresh()
        End Sub

        Sub SetLockAll(ByVal lock As Boolean)
            Try
                FFRenamer.SetIsLocked(String.Empty, String.Empty, False)
                For Each row As DataGridViewRow In dgvMoviesList.Rows.Cast(Of DataGridViewRow)()
                    row.Cells(5).Value = lock
                Next

                If chkRenamedOnly.Checked AndAlso lock Then
                    dgvMoviesList.ClearSelection()
                    dgvMoviesList.CurrentCell = Nothing
                End If

                dgvMoviesList.Refresh()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub SetUp()
            Text = Languages.Bulk_Renamer
            Close_Button.Text = Languages.Close
            Label2.Text = Languages.Rename_movies_and_files
            Label4.Text = Languages.Bulk_Renamer
            lblCompiling.Text = Languages.Compiling_Movie_List
            lblCanceling.Text = Languages.Canceling_Compilation
            btnCancel.Text = Languages.Cancel
            Rename_Button.Text = Languages.Rename
            tsmLockMovie.Text = Languages.Lock
            tsmUnlockMovie.Text = Languages.Unlock
            tsmLockAll.Text = Languages.Lock_All
            tsmUnlockAll.Text = Languages.Unlock_All
            lblFolderPattern.Text = Languages.Folder_Pattern_for_Single_movie_in_Folder
            lblFilePattern.Text = Languages.File_Pattern
            Label1.Text = Languages.Folder_Pattern__for_Multiple_movies_in_Folder
            chkRenamedOnly.Text = Languages.Display_Only_Movies_That_Will_Be_Renamed

            Dim frmToolTip As New ToolTip()
            Dim s As String = String.Format(Languages.BulkRenamerHelp, vbNewLine)
            frmToolTip.SetToolTip(txtFolder, s)
            frmToolTip.SetToolTip(txtFile, s)
            frmToolTip.SetToolTip(txtFolderNotSingle, s)
        End Sub

        Private Function ShowProgressRename(ByVal mov As String, ByVal iProg As Integer) As Boolean
            bwDoRename.ReportProgress(iProg, mov.ToString)
            If CancelRename Then Return False
            Return True
        End Function

        Private Sub Simulate()
            Try
                With dgvMoviesList
                    If Not run_once Then
                        For Each c As DataGridViewColumn In .Columns
                            _columnsize(c.Index) = c.Width
                        Next
                    End If
                    .DataSource = Nothing
                    .Rows.Clear()
                    .AutoGenerateColumns = True
                    If run_once Then
                        .Tag = False
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    End If
                    bsMovies.DataSource = FFRenamer.GetMovies
                    .DataSource = bsMovies
                    .Columns(5).Visible = False
                    .Columns(6).Visible = False
                    .Columns(7).Visible = False
                    .Columns(8).Visible = False
                    .Columns(9).Visible = False
                    If run_once Then
                        For Each c As DataGridViewColumn In .Columns
                            c.MinimumWidth = Convert.ToInt32(.Width / 5)
                        Next
                        .AutoResizeColumns()
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                        For Each c As DataGridViewColumn In .Columns
                            c.MinimumWidth = 20
                        Next
                        run_once = False
                    Else
                        .Tag = True
                        For Each c As DataGridViewColumn In .Columns
                            c.Width = _columnsize(c.Index)
                        Next
                        .Tag = False
                    End If
                End With
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub Start()
            btnCancel.Visible = False
            lblFile.Visible = False
            pbCompile.Style = ProgressBarStyle.Marquee
            pnlCancel.Visible = True
        End Sub

        Private Sub tmrSimul_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles tmrSimul.Tick
            Try
                'Need to make simulate thread safe
                tmrSimul.Enabled = False
                If isLoaded Then
                    Dim tThread As Threading.Thread = New Threading.Thread(AddressOf DoProcess)
                    tThread.Start()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub tsmLockAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsmLockAll.Click
            setLockAll(True)
        End Sub

        Private Sub tsmLockMovie_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsmLockMovie.Click
            setLock(True)
        End Sub

        Private Sub tsmUnlockAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsmUnlockAll.Click
            setLockAll(False)
        End Sub

        Private Sub tsmUnlockMovie_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsmUnlockMovie.Click
            setLock(False)
        End Sub

        Private Sub txtFile_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtFile.TextChanged
            Try
                If String.IsNullOrEmpty(txtFile.Text) Then txtFile.Text = "$F"
                tmrSimul.Enabled = True
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub txtFolderNotSingle_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtFolderNotSingle.TextChanged
            Try
                If String.IsNullOrEmpty(txtFolderNotSingle.Text) Then txtFolderNotSingle.Text = "$D"
                tmrSimul.Enabled = True
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub txtFolder_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtFolder.TextChanged
            Try
                If String.IsNullOrEmpty(txtFolder.Text) Then txtFolder.Text = "$D"
                tmrSimul.Enabled = True
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub
        Sub LoadHelpTips()
            If dHelpTips Is Nothing OrElse dHelpTips.IsDisposed Then
                dHelpTips = New dlgHelpTips
            End If
            Dim s As String = String.Format(Languages.BulkRenamerHelp, vbNewLine)
            dHelpTips.lblTips.Text = s
            dHelpTips.Width = dHelpTips.lblTips.Width + 5
            dHelpTips.Height = dHelpTips.lblTips.Height + 35
            dHelpTips.Top = Top + 10
            dHelpTips.Left = Right - dHelpTips.Width - 10
            If dHelpTips.Visible Then
                dHelpTips.Hide()
            Else
                dHelpTips.Show(Me)
            End If
        End Sub
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
            LoadHelpTips()
        End Sub        
#End Region 'Methods
    End Class
End Namespace