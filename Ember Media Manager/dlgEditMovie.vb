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
Imports System.IO
Imports System.Text.RegularExpressions
Imports EmberMediaManger.API

Public Class dlgEditMovie

#Region "Fields"

    Friend WithEvents bwThumbs As New System.ComponentModel.BackgroundWorker

    Private CachePath As String = String.Empty
    Private DeleteList As New List(Of String)
    Private ExtraIndex As Integer = 0
    Private Fanart As New Images With {.IsEdit = True}
    Private fResults As New Containers.ImgResult
    Private hasCleared As Boolean = False
    Private isAborting As Boolean = False    
    Private lvwThumbSorter As ListViewColumnSorter
    Private Poster As New Images With {.IsEdit = True}
    Private pResults As New Containers.ImgResult
    Private PreviousFrameValue As Integer
    Private Thumbs As New List(Of ExtraThumbs)
    Private _tmpRating As String = String.Empty
    Private _currentMovie As Model.Movie

#End Region 'Fields

#Region "Methods"

    Public Overloads Function ShowDialog(mediaItem As Model.Movie) As Object
        _currentMovie = mediaItem
        If ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return _currentMovie
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnAddActor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddActor.Click
        'Try
        '    Dim eActor As New MediaContainers.Person
        '    Using dAddEditActor As New dlgAddEditActor
        '        eActor = dAddEditActor.ShowDialog(True)
        '    End Using
        '    If Not IsNothing(eActor) Then
        '        Dim lvItem As ListViewItem = lvActors.Items.Add(eActor.Name)
        '        lvItem.SubItems.Add(eActor.Role)
        '        lvItem.SubItems.Add(eActor.Thumb)
        '    End If
        'Catch ex As Exception
        '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        'End Try
    End Sub

    Private Sub btnChangeMovie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeMovie.Click
        CleanUp()
        ' ***
        DialogResult = Windows.Forms.DialogResult.Abort
        Close()
    End Sub

    Private Sub btnClearCache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCache.Click
        Try
            If Directory.Exists(CachePath) Then
                FileUtils.DeleteDirectory(CachePath)
            End If

            btnClearCache.Visible = False
        Catch ex As Exception
            MsgBox(Master.eLang.GetString(267, "One or more cache resources is currently in use and cannot be deleted at the moment."), MsgBoxStyle.Information, Master.eLang.GetString(268, "Cannot Clear Cache"))
        End Try
    End Sub

    Private Sub btnDLTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDLTrailer.Click
        Dim tURL As String = ModulesManager.Instance.ScraperDownloadTrailer(_currentMovie)
        If Not String.IsNullOrEmpty(tURL) Then
            btnPlayTrailer.Enabled = True
            If StringUtils.isValidURL(tURL) Then
                txtTrailer.Text = tURL
            Else
                _currentMovie.TrailerPath = tURL
                lblLocalTrailer.Visible = True
            End If
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            If lvThumbs.Items.Count > 0 AndAlso lvThumbs.SelectedIndices(0) < (lvThumbs.Items.Count - 1) Then
                Dim iIndex As Integer = lvThumbs.SelectedIndices(0)
                lvThumbs.Items(iIndex).Text = String.Concat("  ", CStr(Convert.ToInt32(lvThumbs.Items(iIndex).Text.Trim) + 1))
                lvThumbs.Items(iIndex + 1).Text = String.Concat("  ", CStr(Convert.ToInt32(lvThumbs.Items(iIndex + 1).Text.Trim) - 1))
                lvThumbs.Sort()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnEditActor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditActor.Click
        EditActor()
    End Sub

    Private Sub btnManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManual.Click
        Try
            If dlgManualEdit.ShowDialog(_currentMovie.NfoPath) = Windows.Forms.DialogResult.OK Then
                _currentMovie = NFO.LoadMovieFromNFO(_currentMovie.NfoPath, _currentMovie.UseFolder)
                FillInfo(False)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnPlayTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayTrailer.Click
        Try

            Dim tPath As String = String.Empty

            If Not String.IsNullOrEmpty(_currentMovie.TrailerPath) Then
                tPath = String.Concat("""", _currentMovie.TrailerPath, """")
            ElseIf Not String.IsNullOrEmpty(txtTrailer.Text) Then
                tPath = String.Concat("""", txtTrailer.Text, """")
            End If

            If Not String.IsNullOrEmpty(tPath) Then
                If Master.isWindows Then
                    Process.Start(tPath)
                Else
                    Using Explorer As New Process
                        Explorer.StartInfo.FileName = "xdg-open"
                        Explorer.StartInfo.Arguments = tPath
                        Explorer.Start()
                    End Using
                End If
            End If

        Catch
            MsgBox(Master.eLang.GetString(270, "The trailer could not be played. This could be due to an invalid URI or you do not have the proper player to play the trailer type."), MsgBoxStyle.Critical, Master.eLang.GetString(271, "Error Playing Trailer"))
        End Try
    End Sub

    Private Sub btnRemoveFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFanart.Click
        pbFanart.Image = Nothing
        Fanart.Image = Nothing
    End Sub

    Private Sub btnRemovePoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemovePoster.Click
        pbPoster.Image = Nothing
        Poster.Image = Nothing
    End Sub

    Private Sub btnRemoveThumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveThumb.Click
        DeleteExtraThumbs()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        DeleteActors()
    End Sub

    Private Sub btnRescrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRescrape.Click
        CleanUp()
        ' ***
        DialogResult = Windows.Forms.DialogResult.Retry
        Close()
    End Sub

    Private Sub btnSetAsFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsFanart.Click
        Fanart.FromFile(Thumbs.Item(ExtraIndex).Path)
        pbFanart.Image = pbExtraThumbs.Image
        lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
        btnSetAsFanart.Enabled = False
    End Sub

    Private Sub btnSetFanartDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Fanart) = DialogResult.OK Then
                    Fanart.FromFile(Path.Combine(Master.TempPath, "fanart.jpg"))
                    pbFanart.Image = Fanart.Image

                    lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
                    lblFanartSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetFanartScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanartScrape.Click
        Try
            Dim sPath As String = Path.Combine(Master.TempPath, "fanart.jpg")

            Using movieImageDialog As New Scrapers.Movies.dlgImgSelect
                Dim returnImage = movieImageDialog.ShowDialog(_currentMovie, Enums.ImageType.Fanart)
                If (returnImage IsNot Nothing) Then
                    Poster.Image = returnImage
                    pbPoster.Image = returnImage

                    lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End Using

            If Master.eSettings.UseImgCache AndAlso Directory.Exists(CachePath) Then
                btnClearCache.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetFanart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanart.Click
        Try
            With ofdImage
                .InitialDirectory = Directory.GetParent(_currentMovie.MoviePath).FullName
                .Filter = "JPEGs|*.jpg"
                .FilterIndex = 4
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Fanart.FromFile(ofdImage.FileName)
                pbFanart.Image = Fanart.Image

                lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
                lblFanartSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPosterDL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPosterDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Posters) = DialogResult.OK Then
                    Poster.FromFile(Path.Combine(Master.TempPath, "poster.jpg"))
                    pbPoster.Image = Poster.Image

                    lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPosterScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPosterScrape.Click
        Try
            Using movieImageDialog As New Scrapers.Movies.dlgImgSelect
                Dim returnImage = movieImageDialog.ShowDialog(_currentMovie, Enums.ImageType.Posters)
                If (returnImage IsNot Nothing) Then
                    Poster.Image = returnImage
                    pbPoster.Image = returnImage

                    lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End Using

            If Master.eSettings.UseImgCache AndAlso Directory.Exists(CachePath) Then
                btnClearCache.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPoster_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPoster.Click
        Try
            With ofdImage
                .InitialDirectory = Directory.GetParent(_currentMovie.MoviePath).FullName
                .Filter = "Supported Images(*.jpg, *.jpeg, *.tbn)|*.jpg;*.jpeg;*.tbn|jpeg (*.jpg, *.jpeg)|*.jpg;*.jpeg|tbn (*.tbn)|*.tbn"
                .FilterIndex = 0
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Poster.FromFile(ofdImage.FileName)
                pbPoster.Image = Poster.Image

                lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                lblPosterSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnStudio_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnStudio.Click
        Using dStudio As New dlgStudioSelect
            Dim tStudio As String = dStudio.ShowDialog(_currentMovie)
            If Not String.IsNullOrEmpty(tStudio) Then
                txtStudio.Text = tStudio
            End If
        End Using
    End Sub

    Private Sub btnThumbsRefresh_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnThumbsRefresh.Click
        RefreshExtraThumbs()
    End Sub

    Private Sub btnTransferNow_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnTransferNow.Click
        TransferETs()
        RefreshExtraThumbs()
        pnlETQueue.Visible = False
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUp.Click
        Try
            If lvThumbs.Items.Count > 0 AndAlso lvThumbs.SelectedIndices(0) > 0 Then
                Dim iIndex As Integer = lvThumbs.SelectedIndices(0)
                lvThumbs.Items(iIndex).Text = String.Concat("  ", CStr(Convert.ToInt32(lvThumbs.Items(iIndex).Text.Trim) - 1))
                lvThumbs.Items(iIndex - 1).Text = String.Concat("  ", CStr(Convert.ToInt32(lvThumbs.Items(iIndex - 1).Text.Trim) + 1))
                lvThumbs.Sort()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub BuildStars(ByVal sinRating As Single)

        Try
            'f'in MS and them leaving control arrays out of VB.NET
            With Me
                .pbStar1.Image = Nothing
                .pbStar2.Image = Nothing
                .pbStar3.Image = Nothing
                .pbStar4.Image = Nothing
                .pbStar5.Image = Nothing

                If sinRating >= 0.5 Then ' if rating is less than .5 out of ten, consider it a 0
                    Select Case (sinRating / 2)
                        Case Is <= 0.5
                            .pbStar1.Image = My.Resources.Modules.img_HalfStar
                        Case Is <= 1
                            .pbStar1.Image = My.Resources.Modules.img_Star
                        Case Is <= 1.5
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_HalfStar
                        Case Is <= 2
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                        Case Is <= 2.5
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_HalfStar
                        Case Is <= 3
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_Star
                        Case Is <= 3.5
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_Star
                            .pbStar4.Image = My.Resources.Modules.img_HalfStar
                        Case Is <= 4
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_Star
                            .pbStar4.Image = My.Resources.Modules.img_Star
                        Case Is <= 4.5
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_Star
                            .pbStar4.Image = My.Resources.Modules.img_Star
                            .pbStar5.Image = My.Resources.Modules.img_HalfStar
                        Case Else
                            .pbStar1.Image = My.Resources.Modules.img_Star
                            .pbStar2.Image = My.Resources.Modules.img_Star
                            .pbStar3.Image = My.Resources.Modules.img_Star
                            .pbStar4.Image = My.Resources.Modules.img_Star
                            .pbStar5.Image = My.Resources.Modules.img_Star
                    End Select
                End If
            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub bwThumbs_DoWork(ByVal sender As Object, ByVal e As ComponentModel.DoWorkEventArgs) Handles bwThumbs.DoWork
        'If Not _currentMovie.ClearExtras OrElse hasCleared Then LoadThumbs()
    End Sub

    Private Sub bwThumbs_RunWorkerCompleted(ByVal sender As Object, ByVal e As ComponentModel.RunWorkerCompletedEventArgs) Handles bwThumbs.RunWorkerCompleted
        Try
            Dim lItem As ListViewItem
            If Thumbs.Count > 0 Then
                For Each thumb As ExtraThumbs In Thumbs
                    lItem = lvThumbs.Items.Add(thumb.Name, String.Concat("  ", CStr(thumb.Index + 1)), thumb.Name)
                    lItem.Tag = thumb.Index
                Next
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        CleanUp()
        _currentMovie = Classes.Database.GetMovie(_currentMovie.ID)
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub CleanUp()
        Try
            If File.Exists(Path.Combine(Master.TempPath, "poster.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "poster.jpg"))
            End If

            If File.Exists(Path.Combine(Master.TempPath, "fanart.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "fanart.jpg"))
            End If

            If File.Exists(Path.Combine(Master.TempPath, "frame.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "frame.jpg"))
            End If

            If Directory.Exists(Path.Combine(Master.TempPath, "extrathumbs")) Then
                FileUtils.DeleteDirectory(Path.Combine(Master.TempPath, "extrathumbs"))
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub DelayTimer_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles DelayTimer.Tick
        DelayTimer.Stop()
        'GrabTheFrame()
    End Sub

    Private Sub DeleteActors()
        Try
            If lvActors.Items.Count > 0 Then
                While lvActors.SelectedItems.Count > 0
                    lvActors.Items.Remove(lvActors.SelectedItems(0))
                End While
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub DeleteExtraThumbs()
        Try
            Dim iIndex As Integer
            While lvThumbs.SelectedItems.Count > 0
                iIndex = lvThumbs.SelectedItems(0).Index
                DeleteList.Add(lvThumbs.Items(iIndex).Name)
                lvThumbs.Items.Remove(lvThumbs.SelectedItems(0))
                pbExtraThumbs.Image = Nothing
                btnSetAsFanart.Enabled = False
            End While
            RenumberThumbs()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub dlgEditMovie_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
        Poster.Dispose()
        Poster = Nothing

        Fanart.Dispose()
        Fanart = Nothing

        Thumbs.Clear()
        Thumbs = Nothing
    End Sub

    Private Sub dlgEditMovie_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bwThumbs.IsBusy Then bwThumbs.CancelAsync()
        While bwThumbs.IsBusy
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        End While
    End Sub

    Private Sub dlgEditMovie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            SetUp()                        
            lvwThumbSorter = New ListViewColumnSorter() With {.SortByText = True, .Order = SortOrder.Ascending, .NumericSort = True}
            lvThumbs.ListViewItemSorter = lvwThumbSorter

            Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
            Using g As Graphics = Graphics.FromImage(iBackground)
                g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
                pnlTop.BackgroundImage = iBackground
            End Using

            Dim dFileInfoEdit As New dlgFileInfo
            dFileInfoEdit.TopLevel = False
            dFileInfoEdit.FormBorderStyle = FormBorderStyle.None
            dFileInfoEdit.BackColor = Color.White
            dFileInfoEdit.Cancel_Button.Visible = False
            pnlFileInfo.Controls.Add(dFileInfoEdit)
            Dim oldwidth As Integer = dFileInfoEdit.Width
            dFileInfoEdit.Width = pnlFileInfo.Width
            dFileInfoEdit.Height = pnlFileInfo.Height
            dFileInfoEdit.Show(False)

            LoadGenres()
            LoadRatings()
            MovieExtractorPanel.CurrentMovie = _currentMovie
            FillInfo()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub dlgEditMovie_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        Activate()
    End Sub

    Private Sub EditActor()
        'Try
        '    If lvActors.SelectedItems.Count > 0 Then
        '        Dim lvwItem As ListViewItem = lvActors.SelectedItems(0)
        '        Dim eActor As New MediaContainers.Person With {.Name = lvwItem.Text, .Role = lvwItem.SubItems(1).Text, .Thumb = lvwItem.SubItems(2).Text}
        '        Using dAddEditActor As New dlgAddEditActor
        '            eActor = dAddEditActor.ShowDialog(False, eActor)
        '        End Using
        '        If Not IsNothing(eActor) Then
        '            lvwItem.Text = eActor.Name
        '            lvwItem.SubItems(1).Text = eActor.Role
        '            lvwItem.SubItems(2).Text = eActor.Thumb
        '            lvwItem.Selected = True
        '            lvwItem.EnsureVisible()
        '        End If
        '        eActor = Nothing
        '    End If
        'Catch ex As Exception
        '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        'End Try
    End Sub

    Private Sub FillInfo(Optional ByVal DoAll As Boolean = True)
        Try
            With Me
                If String.IsNullOrEmpty(_currentMovie.NfoPath) Then
                    .btnManual.Enabled = False
                End If

                chkMark.Checked = _currentMovie.Mark

                If Not String.IsNullOrEmpty(_currentMovie.Title) Then
                    .txtTitle.Text = _currentMovie.Title
                End If

                If Not String.IsNullOrEmpty(_currentMovie.OriginalTitle) Then
                    If _currentMovie.OriginalTitle <> StringUtils.FilterTokens(_currentMovie.Title) Then
                        .txtOriginalTitle.Text = _currentMovie.OriginalTitle
                    End If
                End If

                If Not String.IsNullOrEmpty(_currentMovie.SortTitle) Then
                    If _currentMovie.SortTitle <> StringUtils.FilterTokens(_currentMovie.Title) Then
                        .txtSortTitle.Text = _currentMovie.SortTitle
                    End If
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Tagline) Then
                    .txtTagline.Text = _currentMovie.Tagline
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Year) Then
                    .mtxtYear.Text = _currentMovie.Year
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Votes) Then
                    .txtVotes.Text = _currentMovie.Votes
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Outline) Then
                    .txtOutline.Text = _currentMovie.Outline
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Plot) Then
                    .txtPlot.Text = _currentMovie.Plot
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Top250) Then
                    .txtTop250.Text = _currentMovie.Top250
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Country) Then
                    .txtCountry.Text = _currentMovie.Country
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Runtime) Then
                    .txtRuntime.Text = _currentMovie.Runtime
                End If

                If Not String.IsNullOrEmpty(_currentMovie.ReleaseDate) Then
                    .txtReleaseDate.Text = _currentMovie.ReleaseDate
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Director) Then
                    .txtDirector.Text = _currentMovie.Director
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Credits) Then
                    .txtCredits.Text = _currentMovie.Credits
                End If


                If Not String.IsNullOrEmpty(_currentMovie.FileSource) Then
                    .txtFileSource.Text = _currentMovie.FileSource
                End If

                If Not String.IsNullOrEmpty(_currentMovie.Certification) Then
                    If Not String.IsNullOrEmpty(Master.eSettings.CertificationLang) Then
                        Dim lCert() As String = _currentMovie.Certification.Trim.Split(Convert.ToChar("/"))
                        Dim fCert = From eCert In lCert Where Regex.IsMatch(eCert, String.Concat(Regex.Escape(Master.eSettings.CertificationLang), "\:(.*?)"))
                        If fCert.Count > 0 Then
                            .txtCerts.Text = fCert(0).ToString.Trim
                        Else
                            .txtCerts.Text = _currentMovie.Certification
                        End If
                    Else
                        .txtCerts.Text = _currentMovie.Certification
                    End If
                End If

                lblLocalTrailer.Visible = Not String.IsNullOrEmpty(_currentMovie.TrailerPath)
                If Not String.IsNullOrEmpty(_currentMovie.Trailer) Then
                    .txtTrailer.Text = _currentMovie.Trailer
                Else
                    If String.IsNullOrEmpty(_currentMovie.TrailerPath) Then
                        .btnPlayTrailer.Enabled = False
                    End If
                End If

                .btnDLTrailer.Enabled = Master.eSettings.DownloadTrailers AndAlso ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Trailer)

                If Not String.IsNullOrEmpty(_currentMovie.Studio) Then
                    .txtStudio.Text = _currentMovie.Studio
                End If

                SelectMPAA()

                For i As Integer = 0 To .lbGenre.Items.Count - 1
                    .lbGenre.SetItemChecked(i, False)
                Next
                If Not String.IsNullOrEmpty(_currentMovie.Genre) Then
                    Dim genreArray() As String
                    genreArray = Strings.Split(_currentMovie.Genre, " / ")
                    For g As Integer = 0 To UBound(genreArray)
                        If .lbGenre.FindString(genreArray(g).Trim) > 0 Then
                            .lbGenre.SetItemChecked(.lbGenre.FindString(genreArray(g).Trim), True)
                        End If
                    Next

                    If .lbGenre.CheckedItems.Count = 0 Then
                        .lbGenre.SetItemChecked(0, True)
                    End If
                Else
                    .lbGenre.SetItemChecked(0, True)
                End If

                Dim lvItem As ListViewItem
                .lvActors.Items.Clear()
                For Each imdbAct As Model.MoviesActor In _currentMovie.MoviesActors
                    lvItem = .lvActors.Items.Add(imdbAct.ActorName)
                    lvItem.SubItems.Add(imdbAct.Role)
                    lvItem.SubItems.Add(imdbAct.Actor.thumb)
                Next

                Dim tRating As Single = NumUtils.ConvertToSingle(_currentMovie.Rating)
                ._tmpRating = tRating.ToString
                .pbStar1.Tag = tRating
                .pbStar2.Tag = tRating
                .pbStar3.Tag = tRating
                .pbStar4.Tag = tRating
                .pbStar5.Tag = tRating
                If tRating > 0 Then .BuildStars(tRating)

                If DoAll Then

                    If Not _currentMovie.UseFolder Then
                        TabControl1.TabPages.Remove(TabPage4)
                        TabControl1.TabPages.Remove(TabPage5)
                    Else
                        Dim pExt As String = Path.GetExtension(_currentMovie.MoviePath).ToLower
                        If pExt = ".rar" OrElse pExt = ".iso" OrElse pExt = ".img" OrElse _
                        pExt = ".bin" OrElse pExt = ".cue" OrElse pExt = ".dat" Then
                            TabControl1.TabPages.Remove(TabPage4)
                        Else
                            .bwThumbs.WorkerSupportsCancellation = True
                            .bwThumbs.RunWorkerAsync()
                        End If
                    End If

                    Fanart.FromFile(_currentMovie.FanartPath)
                    If Not IsNothing(Fanart.Image) Then
                        .pbFanart.Image = Fanart.Image

                        .lblFanartSize.Text = String.Format(Languages.Size_Param, .pbFanart.Image.Width, .pbFanart.Image.Height)
                        .lblFanartSize.Visible = True
                    End If

                    Poster.FromFile(_currentMovie.PosterPath)
                    If Not IsNothing(Poster.Image) Then
                        .pbPoster.Image = Poster.Image

                        .lblPosterSize.Text = String.Format(Languages.Size_Param, .pbPoster.Image.Width, .pbPoster.Image.Height)
                        .lblPosterSize.Visible = True
                    End If

                    'If Not ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Poster) Then
                    '    .btnSetPosterScrape.Enabled = False
                    'End If

                    'If Not ModulesManager.Instance.QueryPostScraperCapabilities(Enums.PostScraperCapabilities.Fanart) Then
                    '    .btnSetFanartScrape.Enabled = False
                    'End If

                End If

                If Not String.IsNullOrEmpty(_currentMovie.Imdb) AndAlso Master.eSettings.UseImgCache Then
                    CachePath = String.Concat(Master.TempPath, Path.DirectorySeparatorChar, _currentMovie.Imdb.Replace("tt", String.Empty))
                    If Directory.Exists(CachePath) Then
                        btnClearCache.Visible = True
                    End If
                End If
            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
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

    Private Sub LoadGenres()
        '//
        ' Read all the genres from the xml and load into the list
        '\\

        lbGenre.Items.Add(Languages.None)

        lbGenre.Items.AddRange(APIXML.GetGenreList)
    End Sub

    Private Sub LoadRatings()
        '//
        ' Read all the ratings from the xml and load into the list
        '\\

        lbMPAA.Items.Add(Languages.None)

        lbMPAA.Items.AddRange(APIXML.GetRatingList)
    End Sub

    Private Sub LoadThumbs()
        Dim tPath As String = Path.Combine(Directory.GetParent(_currentMovie.MoviePath).FullName, "extrathumbs")
        If Directory.Exists(tPath) Then
            Dim di As New DirectoryInfo(tPath)
            Dim lFI As New List(Of FileInfo)
            Dim i As Integer = 0
            Try
                Try
                    lFI.AddRange(di.GetFiles("thumb*.jpg"))
                Catch
                End Try

                If lFI.Count > 0 Then
                    For Each thumb As FileInfo In lFI.OrderBy(Function(t) Convert.ToInt32(Regex.Match(t.Name, "(\d+)").Groups(0).ToString))
                        If bwThumbs.CancellationPending Then Return
                        If Not DeleteList.Contains(thumb.Name) Then
                            Using fsImage As New FileStream(thumb.FullName, FileMode.Open, FileAccess.Read)
                                If fsImage.Length = 0 Then Continue For
                                If bwThumbs.CancellationPending Then Return
                                Thumbs.Add(New ExtraThumbs With {.Image = Image.FromStream(fsImage), .Name = thumb.Name, .Index = i, .Path = thumb.FullName})
                                ilThumbs.Images.Add(thumb.Name, Thumbs.Item(i).Image)
                            End Using
                            i += 1
                        End If
                    Next
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
            lFI = Nothing
            di = Nothing
        End If
    End Sub

   
    Private Sub lvActors_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        EditActor()
    End Sub

    Private Sub lvActors_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then DeleteActors()
    End Sub

    Private Sub lvThumbs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvThumbs.KeyDown
        If e.KeyCode = Keys.Delete Then DeleteExtraThumbs()
    End Sub

    Private Sub lvThumbs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvThumbs.SelectedIndexChanged
        If lvThumbs.SelectedIndices.Count > 0 Then
            Try
                pbExtraThumbs.Image = Thumbs.Item(Convert.ToInt32(lvThumbs.SelectedItems(0).Tag)).Image
                ExtraIndex = Convert.ToInt32(lvThumbs.SelectedItems(0).Tag)
                btnSetAsFanart.Enabled = True
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            SetInfo()

            Classes.Database.SaveMovie(_currentMovie, EntityState.Modified)
            'Save NFO

            CleanUp()

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try

        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub pbStar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles pbStar5.Click, pbStar4.Click, pbStar3.Click, pbStar2.Click, pbStar1.Click
        Dim currentStar As PictureBox = sender
        _tmpRating = currentStar.Tag.ToString
    End Sub

    Private Sub pbStar_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles pbStar5.MouseLeave, pbStar4.MouseLeave, pbStar3.MouseLeave, pbStar2.MouseLeave, pbStar1.MouseLeave
        Try
            Dim tmpDBL As Single = 0
            Single.TryParse(_tmpRating, tmpDBL)
            BuildStars(tmpDBL)
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub pbStar_MouseMove(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles pbStar5.MouseMove, pbStar4.MouseMove, pbStar3.MouseMove, pbStar2.MouseMove, pbStar1.MouseMove
        Dim currentStar As PictureBox = sender
        Dim value As Integer = Integer.Parse(currentStar.Name.Substring(currentStar.Name.Length - 1, 1))
        Try
            If e.X < 12 Then
                currentStar.Tag = (value * 2) - 1
                BuildStars((value * 2) - 1)
            Else
                pbStar5.Tag = (value * 2)
                BuildStars((value * 2))
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub RefreshExtraThumbs()
        Try
            If bwThumbs.IsBusy Then bwThumbs.CancelAsync()
            While bwThumbs.IsBusy
                Application.DoEvents()
                Threading.Thread.Sleep(50)
            End While

            Thumbs.Clear()
            lvThumbs.Clear()
            ilThumbs.Images.Clear()

            bwThumbs.WorkerSupportsCancellation = True
            bwThumbs.RunWorkerAsync()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub RenumberThumbs()
        For i As Integer = 0 To lvThumbs.Items.Count - 1
            lvThumbs.Items(i).Text = String.Concat("  ", CStr(i + 1))
            lvThumbs.Sort()
        Next
    End Sub

    Private Sub SaveExtraThumbsList()
        Dim tPath As String = String.Empty
        Try
            If Master.eSettings.VideoTSParent AndAlso FileUtils.isVideoTS(_currentMovie.MoviePath) Then
                tPath = Path.Combine(Directory.GetParent(Directory.GetParent(_currentMovie.MoviePath).FullName).FullName, "extrathumbs")
            ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.isBDRip(_currentMovie.MoviePath) Then
                tPath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(_currentMovie.MoviePath).FullName).FullName).FullName, "extrathumbs")
            Else
                tPath = Path.Combine(Directory.GetParent(_currentMovie.MoviePath).FullName, "extrathumbs")
            End If

            'Figure out clearextras association '_currentMovie.ClearExtras
            If True AndAlso Not hasCleared Then
                FileUtils.DeleteDirectory(tPath)
                hasCleared = True
            Else
                'first delete the ones from the delete list
                For Each del As String In DeleteList
                    File.Delete(Path.Combine(tPath, del))
                Next

                'now name the rest something arbitrary so we don't get any conflicts
                For Each lItem As ListViewItem In lvThumbs.Items
                    FileSystem.Rename(Path.Combine(tPath, lItem.Name), Path.Combine(tPath, String.Concat("temp", lItem.Name)))
                Next

                'now rename them properly
                For Each lItem As ListViewItem In lvThumbs.Items
                    FileSystem.Rename(Path.Combine(tPath, String.Concat("temp", lItem.Name)), Path.Combine(tPath, String.Concat("thumb", lItem.Text.Trim, ".jpg")))
                Next
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub SelectMPAA()
        If Not String.IsNullOrEmpty(_currentMovie.MPAA) Then
            Try
                If Master.eSettings.UseCertForMPAA AndAlso Not Master.eSettings.CertificationLang = "USA" AndAlso Not IsNothing(APIXML.RatingXML.Element("ratings").Element(Master.eSettings.CertificationLang.ToLower)) AndAlso APIXML.RatingXML.Element("ratings").Element(Master.eSettings.CertificationLang.ToLower).Descendants("movie").Count > 0 Then
                    If Master.eSettings.OnlyValueForCert Then
                        Dim sItem As String
                        For i As Integer = 0 To lbMPAA.Items.Count - 1
                            sItem = lbMPAA.Items(i).ToString
                            If sItem.Contains(":") AndAlso sItem.Split(Convert.ToChar(":"))(1) = _currentMovie.MPAA Then
                                lbMPAA.SelectedIndex = i
                                lbMPAA.TopIndex = i
                                Exit For
                            End If
                        Next
                    Else
                        Dim l As Integer = lbMPAA.FindString(_currentMovie.MPAA.Trim())
                        lbMPAA.SelectedIndex = l
                        lbMPAA.TopIndex = l
                    End If

                    If lbMPAA.SelectedItems.Count = 0 Then
                        lbMPAA.SelectedIndex = 0
                        lbMPAA.TopIndex = 0
                    End If

                    txtMPAADesc.Enabled = False
                ElseIf lbMPAA.Items.Count >= 6 Then
                    Dim strMPAA As String = _currentMovie.MPAA
                    If strMPAA.ToLower.StartsWith("rated g") Then
                        lbMPAA.SelectedIndex = 1
                    ElseIf strMPAA.ToLower.StartsWith("rated pg-13") Then
                        lbMPAA.SelectedIndex = 3
                    ElseIf strMPAA.ToLower.StartsWith("rated pg") Then
                        lbMPAA.SelectedIndex = 2
                    ElseIf strMPAA.ToLower.StartsWith("rated r") Then
                        lbMPAA.SelectedIndex = 4
                    ElseIf strMPAA.ToLower.StartsWith("rated nc-17") Then
                        lbMPAA.SelectedIndex = 5
                    Else
                        lbMPAA.SelectedIndex = 0
                    End If

                    If lbMPAA.SelectedIndex > 0 AndAlso Not String.IsNullOrEmpty(strMPAA) Then
                        Dim strMPAADesc As String = strMPAA
                        strMPAADesc = Strings.Replace(strMPAADesc, "rated g", String.Empty, 1, -1, CompareMethod.Text).Trim
                        If Not String.IsNullOrEmpty(strMPAADesc) Then strMPAADesc = Strings.Replace(strMPAADesc, "rated pg-13", String.Empty, 1, -1, CompareMethod.Text).Trim
                        If Not String.IsNullOrEmpty(strMPAADesc) Then strMPAADesc = Strings.Replace(strMPAADesc, "rated pg", String.Empty, 1, -1, CompareMethod.Text).Trim
                        If Not String.IsNullOrEmpty(strMPAADesc) Then strMPAADesc = Strings.Replace(strMPAADesc, "rated r", String.Empty, 1, -1, CompareMethod.Text).Trim
                        If Not String.IsNullOrEmpty(strMPAADesc) Then strMPAADesc = Strings.Replace(strMPAADesc, "rated nc-17", String.Empty, 1, -1, CompareMethod.Text).Trim
                        txtMPAADesc.Text = strMPAADesc
                    End If
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        Else
            lbMPAA.SelectedIndex = 0
        End If
    End Sub

    Private Sub SetInfo()
        Try
            With Me

                _currentMovie.Mark = chkMark.Checked

                If Not String.IsNullOrEmpty(.txtTitle.Text) Then
                    If Master.eSettings.DisplayYear AndAlso Not String.IsNullOrEmpty(.mtxtYear.Text.Trim) Then
                        _currentMovie.ListTitle = String.Format("{0} ({1})", StringUtils.FilterTokens(.txtTitle.Text.Trim), .mtxtYear.Text.Trim)
                    Else
                        _currentMovie.ListTitle = StringUtils.FilterTokens(.txtTitle.Text.Trim)
                    End If
                    _currentMovie.Title = .txtTitle.Text.Trim
                End If

                If Not String.IsNullOrEmpty(.txtOriginalTitle.Text) Then
                    _currentMovie.OriginalTitle = .txtOriginalTitle.Text.Trim
                Else
                    _currentMovie.OriginalTitle = StringUtils.FilterTokens(.txtTitle.Text.Trim)
                End If

                If Not String.IsNullOrEmpty(.txtSortTitle.Text) Then
                    _currentMovie.SortTitle = .txtSortTitle.Text.Trim
                Else
                    _currentMovie.SortTitle = StringUtils.FilterTokens(.txtTitle.Text.Trim)
                End If

                _currentMovie.Tagline = .txtTagline.Text.Trim
                _currentMovie.Year = .mtxtYear.Text.Trim
                _currentMovie.Votes = .txtVotes.Text.Trim
                _currentMovie.Outline = .txtOutline.Text.Trim
                _currentMovie.Plot = .txtPlot.Text.Trim
                _currentMovie.Top250 = .txtTop250.Text.Trim
                _currentMovie.Country = .txtCountry.Text.Trim
                _currentMovie.Director = .txtDirector.Text.Trim

                _currentMovie.Certification = .txtCerts.Text.Trim

                _currentMovie.FileSource = .txtFileSource.Text.Trim

                If .lbMPAA.SelectedIndices.Count > 0 AndAlso Not .lbMPAA.SelectedIndex <= 0 Then
                    _currentMovie.MPAA = String.Concat(If(Master.eSettings.UseCertForMPAA AndAlso Master.eSettings.OnlyValueForCert AndAlso .lbMPAA.SelectedItem.ToString.Contains(":"), .lbMPAA.SelectedItem.ToString.Split(Convert.ToChar(":"))(1), .lbMPAA.SelectedItem.ToString), " ", .txtMPAADesc.Text).Trim
                Else
                    If Master.eSettings.UseCertForMPAA AndAlso (Not Master.eSettings.CertificationLang = "USA" OrElse (Master.eSettings.CertificationLang = "USA" AndAlso .lbMPAA.SelectedIndex = 0)) Then
                        Dim lCert() As String = .txtCerts.Text.Trim.Split(Convert.ToChar("/"))
                        Dim fCert = From eCert In lCert Where Regex.IsMatch(eCert, String.Concat(Regex.Escape(Master.eSettings.CertificationLang), "\:(.*?)"))
                        If fCert.Count > 0 Then
                            _currentMovie.MPAA = If(Master.eSettings.CertificationLang = "USA", StringUtils.USACertToMPAA(fCert(0).ToString.Trim), If(Master.eSettings.OnlyValueForCert, fCert(0).ToString.Trim.Split(Convert.ToChar(":"))(1), fCert(0).ToString.Trim))
                        Else
                            _currentMovie.MPAA = String.Empty
                        End If
                    Else
                        _currentMovie.MPAA = String.Empty
                    End If
                End If

                _currentMovie.Rating = ._tmpRating
                _currentMovie.Runtime = .txtRuntime.Text.Trim
                _currentMovie.ReleaseDate = .txtReleaseDate.Text.Trim
                _currentMovie.Credits = .txtCredits.Text.Trim
                _currentMovie.Trailer = .txtTrailer.Text.Trim
                _currentMovie.Studio = .txtStudio.Text.Trim

                If .lbGenre.CheckedItems.Count > 0 Then

                    If .lbGenre.CheckedIndices.Contains(0) Then
                        _currentMovie.Genre = String.Empty
                    Else
                        Dim strGenre As String = String.Empty
                        Dim isFirst As Boolean = True
                        Dim iChecked = From iCheck In .lbGenre.CheckedItems
                        strGenre = Strings.Join(iChecked.ToArray, " / ")
                        _currentMovie.Genre = strGenre.Trim
                    End If
                End If

                _currentMovie.MoviesActors.Clear()

                If .lvActors.Items.Count > 0 Then
                    For Each lviActor As ListViewItem In .lvActors.Items
                        Dim addActor As New Model.MoviesActor
                        addActor.ActorName = lviActor.Text.Trim
                        addActor.Role = lviActor.SubItems(1).Text.Trim
                        addActor.Actor.thumb = lviActor.SubItems(2).Text.Trim

                        _currentMovie.MoviesActors.Add(addActor)
                    Next
                End If

                'If _currentMovie.ClearExtras Then
                '    .Fanart.DeleteFanart(_currentMovie)
                '    .Poster.DeletePosters(_currentMovie)
                'End If

                If Not IsNothing(.Fanart.Image) Then
                    Dim fPath As String = .Fanart.SaveAsFanart(_currentMovie)
                    _currentMovie.FanartPath = fPath
                Else
                    .Fanart.DeleteFanart(_currentMovie)
                    _currentMovie.FanartPath = String.Empty
                End If

                If Not IsNothing(.Poster.Image) Then
                    Dim pPath As String = .Poster.SaveAsPoster(_currentMovie)
                    _currentMovie.PosterPath = pPath
                Else
                    .Poster.DeletePosters(_currentMovie)
                    _currentMovie.PosterPath = String.Empty
                End If

                If Not Master.eSettings.NoSaveImagesToNfo AndAlso pResults.Posters.Count > 0 Then _currentMovie.MoviesPosters = pResults.Posters
                If Not Master.eSettings.NoSaveImagesToNfo AndAlso fResults.Fanart.Thumb.Count > 0 Then _currentMovie.MoviesFanarts = pResults.Fanart

                .SaveExtraThumbsList()

                .TransferETs()

            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub SetUp()
        Dim mTitle As String = _currentMovie.Title
        Dim mPathPieces() As String = _currentMovie.MoviePath.Split(Path.DirectorySeparatorChar)
        Dim mShortPath As String = _currentMovie.MoviePath
        If Not String.IsNullOrEmpty(mShortPath) AndAlso FileUtils.isVideoTS(mShortPath) Then
            mShortPath = String.Concat(Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 3), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 2), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 1))
        ElseIf Not String.IsNullOrEmpty(mShortPath) AndAlso FileUtils.isBDRip(mShortPath) Then
            mShortPath = String.Concat(Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 4), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 3), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 2), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 1))
        Else
            mShortPath = String.Concat(Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 2), Path.DirectorySeparatorChar, mPathPieces(mPathPieces.Count - 1))
        End If
        Dim sTitle As String = String.Concat(Master.eLang.GetString(25, "Edit Movie"), If(String.IsNullOrEmpty(mTitle), String.Empty, String.Concat(" - ", mTitle)), If(String.IsNullOrEmpty(mShortPath), String.Empty, String.Concat(" | ", mShortPath)))
        Text = sTitle
        OK_Button.Text = Master.eLang.GetString(179, "OK")
        Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
        Label2.Text = Master.eLang.GetString(224, "Edit the details for the selected movie.")
        Label1.Text = Master.eLang.GetString(25, "Edit Movie")
        TabPage1.Text = Master.eLang.GetString(26, "Details")
        lblLocalTrailer.Text = Master.eLang.GetString(225, "Local Trailer Found")
        lblStudio.Text = Master.eLang.GetString(226, "Studio:")
        lblTrailer.Text = Master.eLang.GetString(227, "Trailer URL:")
        lblReleaseDate.Text = Master.eLang.GetString(236, "Release Date:")
        lblCredits.Text = Master.eLang.GetString(228, "Credits:")
        lblCerts.Text = Master.eLang.GetString(237, "Certification(s):")
        lblRuntime.Text = Master.eLang.GetString(238, "Runtime:")
        lblMPAADesc.Text = Master.eLang.GetString(229, "MPAA Rating Description:")
        btnManual.Text = Master.eLang.GetString(230, "Manual Edit")
        lblActors.Text = Master.eLang.GetString(231, "Actors:")        
        lblGenre.Text = Master.eLang.GetString(51, "Genre(s):")
        lblMPAA.Text = Master.eLang.GetString(235, "MPAA Rating:")
        lblDirector.Text = Master.eLang.GetString(239, "Director:")
        lblTop250.Text = Master.eLang.GetString(240, "Top 250:")
        lblCountry.Text = String.Concat(Master.eLang.GetString(301, "Country"), ":")
        lblPlot.Text = Master.eLang.GetString(241, "Plot:")
        lblOutline.Text = Master.eLang.GetString(242, "Plot Outline:")
        lblTagline.Text = Master.eLang.GetString(243, "Tagline:")
        lblVotes.Text = Master.eLang.GetString(244, "Votes:")
        lblRating.Text = Master.eLang.GetString(245, "Rating:")
        lblYear.Text = Master.eLang.GetString(49, "Year:")
        lblTitle.Text = Master.eLang.GetString(246, "Title:")
        TabPage2.Text = Master.eLang.GetString(148, "Poster")
        btnRemovePoster.Text = Master.eLang.GetString(247, "Remove Poster")
        btnSetPosterScrape.Text = Master.eLang.GetString(248, "Change Poster (Scrape)")
        btnSetPoster.Text = Master.eLang.GetString(249, "Change Poster (Local)")
        TabPage3.Text = Master.eLang.GetString(149, "Fanart")
        btnRemoveFanart.Text = Master.eLang.GetString(250, "Remove Fanart")
        btnSetFanartScrape.Text = Master.eLang.GetString(251, "Change Fanart (Scrape)")
        btnSetFanart.Text = Master.eLang.GetString(252, "Change Fanart (Local)")
        TabPage5.Text = Master.eLang.GetString(153, "Extrathumbs")
        Label4.Text = Master.eLang.GetString(253, "You have extrathumbs queued to be transferred to the movie directory.")
        btnTransferNow.Text = Master.eLang.GetString(254, "Transfer Now")
        btnSetAsFanart.Text = Master.eLang.GetString(255, "Set As Fanart")
        TabPage4.Text = Master.eLang.GetString(256, "Frame Extraction")
        chkMark.Text = Master.eLang.GetString(23, "Mark")
        btnRescrape.Text = Master.eLang.GetString(716, "Re-scrape")
        btnChangeMovie.Text = Master.eLang.GetString(32, "Change Movie")
        btnClearCache.Text = Master.eLang.GetString(264, "Clear Cache")
        btnSetPosterDL.Text = Master.eLang.GetString(265, "Change Poster (Download)")
        btnSetFanartDL.Text = Master.eLang.GetString(266, "Change Fanart (Download)")
        Label6.Text = String.Concat(Master.eLang.GetString(642, "Sort Title"), ":")
        lblOriginalTitle.Text = String.Concat(Master.eLang.GetString(302, "Original Title"), ":")
        lblFileSource.Text = Master.eLang.GetString(824, "Video Source:")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 3 Then
                If File.Exists(String.Concat(Master.TempPath, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")) Then
                    pnlETQueue.Visible = True
                Else
                    pnlETQueue.Visible = False
                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub



    Private Sub TransferETs()
        Try
            If Directory.Exists(Path.Combine(Master.TempPath, "extrathumbs")) Then
                Dim ePath As String = String.Empty
                If Master.eSettings.VideoTSParent AndAlso FileUtils.isVideoTS(_currentMovie.MoviePath) Then
                    ePath = Path.Combine(Directory.GetParent(Directory.GetParent(_currentMovie.MoviePath).FullName).FullName, "extrathumbs")
                ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.isBDRip(_currentMovie.MoviePath) Then
                    ePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(_currentMovie.MoviePath).FullName).FullName).FullName, "extrathumbs")
                Else
                    ePath = Path.Combine(Directory.GetParent(_currentMovie.MoviePath).FullName, "extrathumbs")
                End If

                'If _currentMovie.ClearExtras AndAlso Not hasCleared Then
                '    FileUtils.DeleteDirectory(ePath)
                '    hasCleared = True
                'End If

                Dim iMod As Integer = Functions.GetExtraModifier(ePath)
                Dim iVal As Integer = iMod + 1
                Dim hasET As Boolean = Not iMod = 0
                Dim fList As New List(Of String)

                Try
                    fList.AddRange(Directory.GetFiles(Path.Combine(Master.TempPath, "extrathumbs"), "thumb*.jpg"))
                Catch
                End Try

                If fList.Count > 0 Then

                    If Not hasET Then
                        Directory.CreateDirectory(ePath)
                    End If

                    For Each sFile As String In fList
                        FileUtils.MoveFileWithStream(sFile, Path.Combine(ePath, String.Concat("thumb", iVal, ".jpg")))
                        iVal += 1
                    Next
                End If

                _currentMovie.ExtraPath = ePath

                FileUtils.DeleteDirectory(Path.Combine(Master.TempPath, "extrathumbs"))
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub txtThumbCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtThumbCount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        AcceptButton = OK_Button
    End Sub

    Private Sub txtTrailer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrailer.TextChanged
        If StringUtils.isValidURL(txtTrailer.Text) Then
            btnPlayTrailer.Enabled = True
        Else
            btnPlayTrailer.Enabled = False
        End If
    End Sub

    Sub GenericRunCallBack(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object))
        If mType = Enums.ModuleEventType.MovieFrameExtrator Then
            RefreshExtraThumbs()
        End If

    End Sub

#End Region 'Methods

#Region "Nested Types"

    Friend Class ExtraThumbs

#Region "Fields"

        Private _image As Image
        Private _index As Integer
        Private _name As String
        Private _path As String

#End Region 'Fields

#Region "Constructors"

        Friend Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        Friend Property Image() As Image
            Get
                Return _image
            End Get
            Set(ByVal value As Image)
                _image = value
            End Set
        End Property

        Friend Property Index() As Integer
            Get
                Return _index
            End Get
            Set(ByVal value As Integer)
                _index = value
            End Set
        End Property

        Friend Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Friend Property Path() As String
            Get
                Return _path
            End Get
            Set(ByVal value As String)
                _path = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Private Sub Clear()
            _image = Nothing
            _name = String.Empty
            _index = Nothing
            _path = String.Empty
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types
End Class