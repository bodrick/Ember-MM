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

Imports System.IO
Imports BrightIdeasSoftware
Imports EmberMediaManger.API

Public Class dlgEditEpisode

#Region "Fields"

    Private Fanart As New Images With {.IsEdit = True}    
    Private Poster As New Images With {.IsEdit = True}    
    Private _tmpRating As String
    Private _currentTVEp As Model.TVEp
    Private _detailedEpisode As Model.TVEp

#End Region 'Fields

#Region "Methods"

    Public Overloads Function ShowDialog(ByVal inEpisode As Model.TVEp) As Model.TVEp
        '//
        ' Overload to pass data
        '\\
        _currentTVEp = inEpisode
        _detailedEpisode = Classes.Database.GetTVShowEpisode(_currentTVEp.ID)
        If ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return _currentTVEp
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnAddActor_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddActor.Click
        Try
            Dim eActor As New Model.TVEpActor
            Using dAddEditActor As New Dialogs.AddEditActor
                eActor = dAddEditActor.ShowDialog(eActor)
            End Using
            If eActor IsNot Nothing Then
                lvActors.AddObject(eActor)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnEditActor_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditActor.Click
        EditActor()
    End Sub

    Private Sub btnManual_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnManual.Click
        Try
            If dlgManualEdit.ShowDialog(_currentTVEp.NfoPath) = Windows.Forms.DialogResult.OK Then
                NFO.LoadTVEpFromNFO(_currentTVEp)
                FillInfo()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnRemoveFanart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveFanart.Click
        pbFanart.Image = Nothing
        Fanart.Image = Nothing
    End Sub

    Private Sub btnRemovePoster_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemovePoster.Click
        pbPoster.Image = Nothing
        Poster.Image = Nothing
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemove.Click
        DeleteActors()
    End Sub

    Private Sub btnSetFanartScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanartScrape.Click
        Dim tImage As Image = ModulesManager.Instance.TVSingleImageOnly(_currentTVEp.Title, Convert.ToInt32(_currentTVEp.TVShowID), _currentTVEp.TVSeason.TVShow.TVDB, Enums.TVImageType.EpisodeFanart, 0, 0, _currentTVEp.TVSeason.TVShow.Language, _currentTVEp.TVSeason.TVShow.Ordering, pbFanart.Image)

        If Not IsNothing(tImage) Then
            Fanart.Image = New Bitmap(tImage)
            pbFanart.Image = tImage

            lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
        End If
    End Sub

    Private Sub btnSetPosterScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPosterScrape.Click
        Dim returnImage = Scrapers.TV.dlgTVImageSelect.ShowDialog(_currentTVEp, Enums.TVImageType.EpisodePoster, Enums.ScrapeType.SingleScrape, pbPoster.Image)
        If (returnImage IsNot Nothing) Then
            Poster.Image = returnImage
            pbPoster.Image = returnImage

            lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
            lblPosterSize.Visible = True
        End If


        'Dim tImage As Image = Classes.Http.DownloadImage(Classes.ScraperFunctions.GetTVEpisodeDetails(_detailedEpisode).Thumb)
        'If Not IsNothing(tImage) Then
        '    Dim returnImage = Scrapers.TV.dlgTVEpisodePoster.ShowDialog(tImage)
        '    If (returnImage IsNot Nothing) Then
        '        Poster.Image = New Bitmap(tImage)
        '        pbPoster.Image = tImage

        '        lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
        '        lblPosterSize.Visible = True
        '    End If
        'End If
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

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
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

            If File.Exists(Path.Combine(Master.TempPath, "frajpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "frajpg"))
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub DeleteActors()
        Try
            lvActors.RemoveObjects(lvActors.SelectedObjects)
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub dlgEditEpisode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUp()

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
        dFileInfoEdit.Show(True)

        If Not (Master.eSettings.EpisodeDashFanart OrElse Master.eSettings.EpisodeDotFanart) Then
            TabControl1.TabPages.Remove(TabPage3)
        End If
        TvExtratorPanel.CurrentTVEp = _detailedEpisode
        FillInfo()
    End Sub

    Private Sub EditActor()
        Try
            If lvActors.SelectedObjects.Count > 0 Then
                Dim eActor As Model.TVEpActor = lvActors.SelectedObjects.Item(0)
                Using dAddEditActor As New Dialogs.AddEditActor
                    eActor = dAddEditActor.ShowDialog(eActor)
                End Using
                If Not IsNothing(eActor) Then
                    lvActors.RefreshObject(eActor)
                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub FillInfo()
        With Me
            If Not String.IsNullOrEmpty(_currentTVEp.Title) Then .txtTitle.Text = _currentTVEp.Title
            If Not String.IsNullOrEmpty(_currentTVEp.Plot) Then .txtPlot.Text = _currentTVEp.Plot
            If Not String.IsNullOrEmpty(_currentTVEp.Aired) Then .txtAired.Text = _currentTVEp.Aired
            If Not String.IsNullOrEmpty(_currentTVEp.Director) Then .txtDirector.Text = _currentTVEp.Director
            If Not String.IsNullOrEmpty(_currentTVEp.Credits) Then .txtCredits.Text = _currentTVEp.Credits
            If Not String.IsNullOrEmpty(_currentTVEp.Season.ToString) Then .txtSeason.Text = _currentTVEp.Season.ToString
            If Not String.IsNullOrEmpty(_currentTVEp.Episode.ToString) Then .txtEpisode.Text = _currentTVEp.Episode.ToString
            _currentTVEp.LoadActors()
            lvActors.Items.Clear()
            If _currentTVEp.TVEpActors.Count > 0 Then
                lvActors.SetObjects(_currentTVEp.TVEpActors)
            End If
            lvActors.DragSource = New SimpleDragSource()
            lvActors.DropSink = New RearrangingDropSink(False)

            Dim tRating As Single = NumUtils.ConvertToSingle(_currentTVEp.Rating)
            ._tmpRating = tRating.ToString
            .pbStar1.Tag = tRating
            .pbStar2.Tag = tRating
            .pbStar3.Tag = tRating
            .pbStar4.Tag = tRating
            .pbStar5.Tag = tRating
            If tRating > 0 Then .BuildStars(tRating)

            If TabControl1.TabPages.Contains(TabPage3) Then
                Dim fanartImage As Image = Classes.Images.FromFile(_currentTVEp.FanartPath)
                If Not IsNothing(fanartImage) Then
                    .pbFanart.Image = fanartImage

                    .lblFanartSize.Text = String.Format(Languages.Size_Param, .pbFanart.Image.Width, .pbFanart.Image.Height)
                    .lblFanartSize.Visible = True
                End If
            End If

            Dim posterImage As Image = Classes.Images.FromFile(_currentTVEp.PosterPath)
            If Not IsNothing(posterImage) Then
                .pbPoster.Image = posterImage
                .lblPosterSize.Text = String.Format(Languages.Size_Param, .pbPoster.Image.Width, .pbPoster.Image.Height)
                .lblPosterSize.Visible = True
            End If
        End With
    End Sub

    Private Sub lvActors_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvActors.DoubleClick
        EditActor()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            SetInfo()

            Classes.Database.SaveTVEp(Master.currShow, EntityState.Modified)
            'Save NFO

            CleanUp()

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try

        DialogResult = Windows.Forms.DialogResult.OK
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

    Private Sub SetInfo()
        Try
            With Me
                _currentTVEp.Title = .txtTitle.Text.Trim
                _currentTVEp.Plot = .txtPlot.Text.Trim
                _currentTVEp.Aired = .txtAired.Text.Trim
                _currentTVEp.Director = .txtDirector.Text.Trim
                _currentTVEp.Credits = .txtCredits.Text.Trim
                _currentTVEp.Season = .txtSeason.IntValue
                _currentTVEp.Episode = .txtEpisode.IntValue
                _currentTVEp.Rating = ._tmpRating

                _currentTVEp.TVEpActors.Clear()
                _currentTVEp.TVEpActors = lvActors.Objects

                If Not IsNothing(.Fanart.Image) Then
                    _currentTVEp.FanartPath = .Fanart.SaveAsEpFanart(Master.currShow)
                Else
                    .Fanart.DeleteEpFanart(Master.currShow)
                    _currentTVEp.FanartPath = String.Empty
                End If

                If Not IsNothing(.Poster.Image) Then
                    _currentTVEp.PosterPath = .Poster.SaveAsEpPoster(Master.currShow)
                Else
                    .Poster.DeleteEpPosters(Master.currShow)
                    _currentTVEp.PosterPath = String.Empty
                End If
            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub SetUp()
        Dim mTitle As String = _currentTVEp.Title
        Dim sTitle As String = String.Concat(Languages.Edit_Episode, If(String.IsNullOrEmpty(mTitle), String.Empty, String.Concat(" - ", mTitle)))
        Text = sTitle
        OK_Button.Text = Languages.OK
        Cancel_Button.Text = Languages.Cancel
        Label2.Text = Languages.Edit_the_details_for_the_selected_episode
        Label1.Text = Languages.Edit_Episode
        TabPage1.Text = Master.eLang.GetString(26, "Details")
        btnManual.Text = Master.eLang.GetString(230, "Manual Edit")
        lblActors.Text = Master.eLang.GetString(231, "Actors:")
        colName.Text = Master.eLang.GetString(232, "Name")
        colRole.Text = Master.eLang.GetString(233, "Role")
        colThumb.Text = Master.eLang.GetString(234, "Thumb")
        lblPlot.Text = Master.eLang.GetString(241, "Plot:")
        lblRating.Text = Master.eLang.GetString(245, "Rating:")
        lblAired.Text = Master.eLang.GetString(658, "Aired:")
        lblSeason.Text = Master.eLang.GetString(659, "Season:")
        lblEpisode.Text = Master.eLang.GetString(660, "Episode:")
        lblTitle.Text = Master.eLang.GetString(246, "Title:")
        TabPage2.Text = Master.eLang.GetString(148, "Poster")
        btnRemovePoster.Text = Master.eLang.GetString(247, "Remove Poster")
        btnSetPosterScrape.Text = Master.eLang.GetString(248, "Change Poster (Scrape)")
        btnSetPoster.Text = Master.eLang.GetString(249, "Change Poster (Local)")
        TabPage3.Text = Master.eLang.GetString(149, "Fanart")
        btnRemoveFanart.Text = Master.eLang.GetString(250, "Remove Fanart")
        btnSetFanartScrape.Text = Master.eLang.GetString(251, "Change Fanart (Scrape)")
        btnSetFanart.Text = Master.eLang.GetString(252, "Change Fanart (Local)")
        btnSetPosterDL.Text = Master.eLang.GetString(265, "Change Poster (Download)")
        btnSetFanartDL.Text = Master.eLang.GetString(266, "Change Fanart (Download)")
        lblDirector.Text = Master.eLang.GetString(239, "Director:")
        lblCredits.Text = Master.eLang.GetString(228, "Credits:")
        TabPage4.Text = Master.eLang.GetString(256, "Frame Extraction")

        TabPage5.Text = Master.eLang.GetString(59, "Meta Data")
    End Sub

    Sub ExtractorFrameSaved() Handles TvExtratorPanel.FrameSave
        Poster.Image = TvExtratorPanel.ExtractedImage
        pbPoster.Image = TvExtratorPanel.ExtractedImage
    End Sub

    Private Sub btnSetPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPoster.Click
        Try
            With ofdImage
                .InitialDirectory = Directory.GetParent(Master.currShow.TVShow.TVShowPath).FullName
                .Filter = "Supported Images(*.jpg, *.jpeg, *.tbn)|*.jpg;*.jpeg;*.tbn|jpeg (*.jpg, *.jpeg)|*.jpg;*.jpeg|tbn (*.tbn)|*.tbn"
                .FilterIndex = 0
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Poster.FromFile(ofdImage.FileName)
                pbPoster.Image = Poster.Image

                lblPosterSize.Text = String.Format(Master.eLang.GetString(269, Languages.Size_Param), pbPoster.Image.Width, pbPoster.Image.Height)
                lblPosterSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPosterDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Posters) = DialogResult.OK Then
                    Poster.FromFile(Path.Combine(Master.TempPath, "poster.jpg"))
                    pbPoster.Image = Poster.Image

                    lblPosterSize.Text = String.Format(Master.eLang.GetString(269, Languages.Size_Param), pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanart.Click
        Try
            With ofdImage
                .InitialDirectory = Directory.GetParent(Master.currShow.TVShow.TVShowPath).FullName
                .Filter = "JPEGs|*.jpg"
                .FilterIndex = 4
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Fanart.FromFile(ofdImage.FileName)
                pbFanart.Image = Fanart.Image

                lblFanartSize.Text = String.Format(Master.eLang.GetString(269, Languages.Size_Param), pbFanart.Image.Width, pbFanart.Image.Height)
                lblFanartSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetFanartDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Fanart) = DialogResult.OK Then
                    Fanart.FromFile(Path.Combine(Master.TempPath, "fanart.jpg"))
                    pbFanart.Image = Fanart.Image

                    lblFanartSize.Text = String.Format(Master.eLang.GetString(269, Languages.Size_Param), pbFanart.Image.Width, pbFanart.Image.Height)
                    lblFanartSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

#End Region 'Methods

End Class