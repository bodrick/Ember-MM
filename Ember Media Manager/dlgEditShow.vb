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

Imports System.Data.Entity
Imports System.IO
Imports BrightIdeasSoftware
Imports EmberMediaManger.API

Public Class dlgEditShow

#Region "Fields"

    Private ASPoster As New Images With {.IsEdit = True}
    Private Fanart As New Images With {.IsEdit = True}    
    Private Poster As New Images With {.IsEdit = True}
    Private _tmpRating As String
    Private _currentTVShowItem As Model.TVShow
#End Region 'Fields

#Region "Methods"

    Public Overloads Function ShowDialog(mediaItem As Model.TVShow) As Object
        _currentTVShowItem = mediaItem
        If ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return _currentTVShowItem
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
        '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        'End Try
    End Sub

    Private Sub btnASChangePosterScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASChangePosterScrape.Click
        Using tvImageDialog As New Scrapers.TV.dlgTVImageSelect
            Dim returnImage = tvImageDialog.ShowDialog(_currentTVShowItem, Enums.TVImageType.AllSeasonPoster, Enums.ScrapeType.SingleScrape, pbASPoster.Image)
            If (returnImage IsNot Nothing) Then
                ASPoster.Image = returnImage
                pbASPoster.Image = returnImage

                lblASSize.Text = String.Format(Languages.Size_Param, pbASPoster.Image.Width, pbASPoster.Image.Height)
                lblASSize.Visible = True
            End If
        End Using
    End Sub

    Private Sub btnASChangePoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASChangePoster.Click
        Try
            With ofdImage
                .InitialDirectory = _currentTVShowItem.TVShowPath
                .Filter = "Supported Images(*.jpg, *.jpeg, *.tbn)|*.jpg;*.jpeg;*.tbn|jpeg (*.jpg, *.jpeg)|*.jpg;*.jpeg|tbn (*.tbn)|*.tbn"
                .FilterIndex = 0
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                ASPoster.FromFile(ofdImage.FileName)
                pbASPoster.Image = ASPoster.Image

                lblASSize.Text = String.Format(Languages.Size_Param, pbASPoster.Image.Width, pbASPoster.Image.Height)
                lblASSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnASPosterChangeDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASPosterChangeDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.ASPoster) = DialogResult.OK Then
                    ASPoster.FromFile(Path.Combine(Master.TempPath, "asposter.jpg"))
                    pbASPoster.Image = ASPoster.Image

                    lblASSize.Text = String.Format(Languages.Size_Param, pbASPoster.Image.Width, pbASPoster.Image.Height)
                    lblASSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnASPosterRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASPosterRemove.Click
        pbASPoster.Image = Nothing
        ASPoster.Image = Nothing
    End Sub

    Private Sub btnEditActor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditActor.Click
        EditActor()
    End Sub

    Private Sub btnManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManual.Click
        Try
            If dlgManualEdit.ShowDialog(_currentTVShowItem.NfoPath) = Windows.Forms.DialogResult.OK Then
                '_currentTVShowItem = NFO.LoadTVShowFromNFO(_currentTVShowItem.NfoPath)
                FillInfo()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
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

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        DeleteActors()
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

    Private Sub btnSetFanartScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartScrape.Click
        Using tvImageDialog As New Scrapers.TV.dlgTVImageSelect
            Dim returnImage = tvImageDialog.ShowDialog(_currentTVShowItem, Enums.TVImageType.ShowFanart, Enums.ScrapeType.SingleScrape, pbFanart.Image)
        If (returnImage IsNot Nothing) Then
            Fanart.Image = returnImage
            pbFanart.Image = returnImage

            lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
            End If
        End Using
    End Sub

    Private Sub btnSetFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanart.Click
        Try
            With ofdImage
                .InitialDirectory = _currentTVShowItem.TVShowPath
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

    Private Sub btnSetPosterDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterDL.Click
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

    Private Sub btnSetPosterScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterScrape.Click
        Using tvImageDialog As New Scrapers.TV.dlgTVImageSelect
            Dim returnImage = tvImageDialog.ShowDialog(_currentTVShowItem, Enums.TVImageType.ShowPoster, Enums.ScrapeType.SingleScrape, pbPoster.Image)
            If (returnImage IsNot Nothing) Then
                Poster.Image = returnImage
                pbPoster.Image = returnImage

                lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                lblPosterSize.Visible = True
            End If
        End Using
    End Sub

    Private Sub btnSetPoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPoster.Click
        Try
            With ofdImage
                .InitialDirectory = _currentTVShowItem.TVShowPath
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

    Private Sub BuildStars(ByVal sinRating As Single)
        '//
        ' Convert # rating to star images
        '\\

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

            If File.Exists(Path.Combine(Master.TempPath, "asposter.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "asposter.jpg"))
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
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

    Private Sub dlgEditShow_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Master.eSettings.AllSeasonPosterEnabled Then TabControl1.TabPages.Remove(TabPage4)

        SetUp()

        Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
        Using g As Graphics = Graphics.FromImage(iBackground)
            g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
            pnlTop.BackgroundImage = iBackground
        End Using

        LoadGenres()
        LoadRatings()

        FillInfo()
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
        '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        'End Try
    End Sub

    Private Sub FillInfo()
        With Me
            .cbOrdering.SelectedIndex = _currentTVShowItem.Ordering

            If Not String.IsNullOrEmpty(_currentTVShowItem.Title) Then .txtTitle.Text = _currentTVShowItem.Title
            If Not String.IsNullOrEmpty(_currentTVShowItem.Plot) Then .txtPlot.Text = _currentTVShowItem.Plot
            If Not String.IsNullOrEmpty(_currentTVShowItem.Premiered) Then .txtPremiered.Text = _currentTVShowItem.Premiered
            If Not String.IsNullOrEmpty(_currentTVShowItem.Studio) Then .txtStudio.Text = _currentTVShowItem.Studio

            For i As Integer = 0 To .lbGenre.Items.Count - 1
                .lbGenre.SetItemChecked(i, False)
            Next
            If Not String.IsNullOrEmpty(_currentTVShowItem.Genre) Then
                Dim genreArray() As String = _currentTVShowItem.Genre.Split(" / ")
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

            _currentTVShowItem.LoadActors()
            lvActors.Items.Clear()
            If _currentTVShowItem.TVShowActors.Count > 0 Then
                lvActors.SetObjects(_currentTVShowItem.TVShowActors)
            End If
            lvActors.DragSource = New SimpleDragSource()
            lvActors.DropSink = New RearrangingDropSink(False)
            
            Dim tRating As Single = NumUtils.ConvertToSingle(_currentTVShowItem.Rating)
            ._tmpRating = tRating.ToString
            .pbStar1.Tag = tRating
            .pbStar2.Tag = tRating
            .pbStar3.Tag = tRating
            .pbStar4.Tag = tRating
            .pbStar5.Tag = tRating
            If tRating > 0 Then .BuildStars(tRating)

            SelectMPAA()

            Fanart.FromFile(_currentTVShowItem.FanartPath)
            If Not IsNothing(Fanart.Image) Then
                .pbFanart.Image = Fanart.Image

                .lblFanartSize.Text = String.Format(Languages.Size_Param, .pbFanart.Image.Width, .pbFanart.Image.Height)
                .lblFanartSize.Visible = True
            End If

            Poster.FromFile(_currentTVShowItem.PosterPath)
            If Not IsNothing(Poster.Image) Then
                .pbPoster.Image = Poster.Image

                .lblPosterSize.Text = String.Format(Languages.Size_Param, .pbPoster.Image.Width, .pbPoster.Image.Height)
                .lblPosterSize.Visible = True
            End If

            If Master.eSettings.AllSeasonPosterEnabled Then
                'Figure out path of allseasons poster file                
                .ASPoster.FromFile(Classes.Database.GetTVAllSeasonPath(_currentTVShowItem.ID))
                If Not IsNothing(.ASPoster.Image) Then
                    .pbASPoster.Image = .ASPoster.Image

                    .lblASSize.Text = String.Format(Languages.Size_Param, .pbASPoster.Image.Width, .pbASPoster.Image.Height)
                    .lblASSize.Visible = True
                End If
            End If
        End With
    End Sub

    Private Sub LoadGenres()
        'lbGenre.Items.Add(Languages.None)

        lbGenre.Items.AddRange(APIXML.GetGenreList)
    End Sub

    Private Sub LoadRatings()
        'lbMPAA.Items.Add(Languages.None)

        lbMPAA.Items.AddRange(APIXML.GetTVRatingList)
    End Sub

    Private Sub lvActors_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvActors.DoubleClick
        EditActor()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK_Button.Click
        Try
            SetInfo()

            Classes.Database.SaveTVEp(Master.currShow, EntityState.Modified)
            'Save NFO too            

            'If Master.eSettings.AllSeasonPosterEnabled Then Master.DB.SaveTVSeasonToDB(Master.currShow, False)

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

    Private Sub SelectMPAA()
        If Not String.IsNullOrEmpty(_currentTVShowItem.MPAA) Then
            Try
                If Not IsNothing(APIXML.RatingXML.Element("ratings").Element(Master.eSettings.ShowRatingRegion.ToLower)) AndAlso APIXML.RatingXML.Element("ratings").Element(Master.eSettings.ShowRatingRegion.ToLower).Descendants("tv").Count > 0 Then
                    Dim l As Integer = lbMPAA.FindString(_currentTVShowItem.MPAA.Trim())
                    lbMPAA.SelectedIndex = l
                    If lbMPAA.SelectedItems.Count = 0 Then
                        lbMPAA.SelectedIndex = 0
                    End If

                    lbMPAA.TopIndex = 0

                Else

                    lbMPAA.SelectedIndex = 0
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
                _currentTVShowItem.Ordering = DirectCast(.cbOrdering.SelectedIndex, Enums.Ordering)

                _currentTVShowItem.Title = .txtTitle.Text.Trim
                _currentTVShowItem.Plot = .txtPlot.Text.Trim
                _currentTVShowItem.Premiered = .txtPremiered.Text.Trim
                _currentTVShowItem.Studio = .txtStudio.Text.Trim

                If .lbMPAA.SelectedIndices.Count > 0 AndAlso Not .lbMPAA.SelectedIndex <= 0 Then
                    _currentTVShowItem.MPAA = .lbMPAA.SelectedItem.ToString
                End If

                _currentTVShowItem.Rating = ._tmpRating

                If .lbGenre.CheckedItems.Count > 0 Then

                    If .lbGenre.CheckedIndices.Contains(0) Then
                        _currentTVShowItem.Genre = String.Empty
                    Else
                        Dim strGenre As String
                        Dim isFirst As Boolean = True
                        Dim iChecked = From iCheck In .lbGenre.CheckedItems
                        strGenre = Strings.Join(iChecked.ToArray, " / ")
                        _currentTVShowItem.Genre = strGenre.Trim
                    End If
                End If

                _currentTVShowItem.TVShowActors.Clear()

                If .lvActors.Items.Count > 0 Then
                    For Each lviActor As ListViewItem In .lvActors.Items
                        Dim addActor As New Model.TVShowActor
                        addActor.ActorName = lviActor.Text.Trim
                        addActor.Role = lviActor.SubItems(1).Text.Trim
                        addActor.Actor.thumb = lviActor.SubItems(2).Text.Trim

                        _currentTVShowItem.TVShowActors.Add(addActor)
                    Next
                End If

                If Not IsNothing(.Fanart.Image) Then
                    _currentTVShowItem.FanartPath = .Fanart.SaveAsShowFanart(Master.currShow)
                Else
                    .Fanart.DeleteShowFanart(Master.currShow)
                    _currentTVShowItem.FanartPath = String.Empty
                End If

                If Not IsNothing(.Poster.Image) Then
                    _currentTVShowItem.PosterPath = .Poster.SaveAsShowPoster(Master.currShow)
                Else
                    .Poster.DeleteShowPosters(Master.currShow)
                    _currentTVShowItem.PosterPath = String.Empty
                End If

                If Master.eSettings.AllSeasonPosterEnabled Then
                    If Not IsNothing(.ASPoster.Image) Then
                        _currentTVShowItem.PosterPath = .ASPoster.SaveAsAllSeasonPoster(Master.currShow)
                    Else
                        .ASPoster.DeleteAllSeasonPosters(Master.currShow)
                        _currentTVShowItem.PosterPath = String.Empty
                    End If
                End If
            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub SetUp()
        Dim mTitle As String = _currentTVShowItem.Title
        Dim sTitle As String = String.Concat(Master.eLang.GetString(663, "Edit Show"), If(String.IsNullOrEmpty(mTitle), String.Empty, String.Concat(" - ", mTitle)))
        Text = sTitle
        OK_Button.Text = Master.eLang.GetString(179, "OK")
        Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
        Label2.Text = Master.eLang.GetString(664, "Edit the details for the selected show.")
        Label1.Text = Master.eLang.GetString(663, "Edit Show")
        TabPage1.Text = Master.eLang.GetString(26, "Details")
        lblStudio.Text = Master.eLang.GetString(226, "Studio:")
        btnManual.Text = Master.eLang.GetString(230, "Manual Edit")
        lblActors.Text = Master.eLang.GetString(231, "Actors:")
        olvcName.Text = Master.eLang.GetString(232, "Name")
        olvcRole.Text = Master.eLang.GetString(233, "Role")
        olvcRole.Text = Master.eLang.GetString(234, "Thumb")
        lblGenre.Text = Master.eLang.GetString(51, "Genre(s):")
        lblMPAA.Text = Master.eLang.GetString(235, "MPAA Rating:")
        lblPlot.Text = Master.eLang.GetString(241, "Plot:")
        lblRating.Text = Master.eLang.GetString(245, "Rating:")
        lblPremiered.Text = Master.eLang.GetString(665, "Premiered:")
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
        TabPage4.Text = Master.eLang.GetString(786, "All Seasons Poster")
        btnASPosterRemove.Text = Master.eLang.GetString(247, "Remove Poster")
        btnASChangePosterScrape.Text = Master.eLang.GetString(248, "Change Poster (Scrape)")
        btnASChangePoster.Text = Master.eLang.GetString(249, "Change Poster (Local)")
        btnASPosterChangeDL.Text = Master.eLang.GetString(265, "Change Poster (Download)")
        lblOrdering.Text = Master.eLang.GetString(739, "Episode Ordering:")

        cbOrdering.Items.AddRange(New String() {Master.eLang.GetString(438, Languages.Standard), Master.eLang.GetString(350, "DVD"), Master.eLang.GetString(839, "Absolute")})

    End Sub

#End Region 'Methods

End Class