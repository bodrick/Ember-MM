Imports System.ComponentModel
Imports EmberControls
Imports EmberMediaManger.API
Imports System.Data.Objects

Public Class ImagesPanel
    Private Sub LoadMovieInfo(CurrentMovie As Model.Movie)
        If Not String.IsNullOrEmpty(CurrentMovie.Title) AndAlso Not String.IsNullOrEmpty(CurrentMovie.Year) Then
            lblTitle.Text = String.Format("{0} ({1})", CurrentMovie.Title, CurrentMovie.Year)
        ElseIf Not String.IsNullOrEmpty(CurrentMovie.Title) AndAlso String.IsNullOrEmpty(CurrentMovie.Year) Then
            lblTitle.Text = CurrentMovie.Title
        ElseIf String.IsNullOrEmpty(CurrentMovie.Title) AndAlso Not String.IsNullOrEmpty(CurrentMovie.Year) Then
            lblTitle.Text = String.Format(Languages.Unknown_Movie_Param, CurrentMovie.Year)
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.OriginalTitle) AndAlso CurrentMovie.OriginalTitle <> StringUtils.FilterTokens(CurrentMovie.Title) Then
            lblOriginalTitle.Text = String.Format(String.Concat(Languages.Original_Title, ": {0}"), CurrentMovie.OriginalTitle)
        Else
            lblOriginalTitle.Text = String.Empty
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.Votes) Then
            lblVotes.Text = String.Format(Languages.Votes, CurrentMovie.Votes)
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.Runtime) Then
            lblRuntime.Text = String.Format(Languages.Runtime, If(CurrentMovie.Runtime.Contains("|"), Microsoft.VisualBasic.Strings.Left(CurrentMovie.Runtime, CurrentMovie.Runtime.IndexOf("|")), CurrentMovie.Runtime)).Trim
        End If

        'If Master.eSettings.UseMIDuration Then
        '    If Not String.IsNullOrEmpty(CurrentMovie.Runtime) Then
        '        lblRuntime.Text = String.Format(Master.eLang.GetString(112, "Runtime: {0}"), CurrentMovie.Runtime)
        '    End If
        'End If

        lblTagline.Text = CurrentMovie.Tagline

        Dim tmpRating As Single = NumUtils.ConvertToSingle(CurrentMovie.Rating)
        If tmpRating > 0 Then
            BuildStars(tmpRating)
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.Studio) Then
            pbStudio.Image = APIXML.GetStudioImage(CurrentMovie.Studio.ToLower) 'ByDef all images file a lower case
            pbStudio.Tag = CurrentMovie.Studio
        Else
            pbStudio.Image = APIXML.GetStudioImage("####")
            pbStudio.Tag = String.Empty
        End If
        If AdvancedSettings.GetBooleanSetting("StudioTagAlwaysOn", False) Then
            lblStudio.Text = pbStudio.Tag.ToString
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.Genre) Then
            CreateGenreThumbs(CurrentMovie.Genre)
        End If

        If Not String.IsNullOrEmpty(CurrentMovie.MPAA) Then
            Dim tmpRatingImg As Image = APIXML.GetRatingImage(CurrentMovie.MPAA)
            If Not IsNothing(tmpRatingImg) Then
                bpMPAA.Image = tmpRatingImg
                bpMPAA.Top = pnlGenres.Top + 4
                bpMPAA.Visible = True
            Else
                bpMPAA.Visible = False
            End If
        Else
            bpMPAA.Visible = False
        End If
        SetPictureboxImage(CurrentMovie.PosterPath, Master.eSettings.NoDisplayPoster, False, pbPoster, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))
        SetPictureboxImage(CurrentMovie.FanartPath, Master.eSettings.NoDisplayFanart, False, pbFanart, False)
        pbAllSeason.Visible = False

        bwMediaInfo = New System.ComponentModel.BackgroundWorker
        bwMediaInfo.WorkerSupportsCancellation = True
        bwMediaInfo.RunWorkerAsync(New With {.MediaItem = CurrentMovie})
    End Sub

    Private Sub SetPictureboxImage(imagePath As String, displayImage As Boolean, grayscale As Boolean, pb As BorderPicturebox, Overlays As Boolean)
        Dim img As Image = Classes.Images.FromFile(imagePath)
        If img IsNot Nothing AndAlso grayscale Then
            img = Classes.Images.GrayscaleImage(img)
        End If
        If Not displayImage AndAlso img IsNot Nothing Then
            pb.Visible = True
            pb.Image = img
            pb.EnableOverlays = Overlays
            If Master.eSettings.ShowDims Then
                pb.CaptionText = String.Format("{0} x {1}", pb.Image.Width, pb.Image.Height)
            End If
        Else
            If Not IsNothing(pb.Image) Then
                pb.Image.Dispose()
                pb.Image = Nothing
            End If
            pb.Visible = False
        End If
    End Sub

    Private Sub LoadTVShowInfo(CurrentTVShow As Model.TVShow, Optional CurrentTVSeason As Model.TVSeason = Nothing)
        If Not String.IsNullOrEmpty(CurrentTVShow.Title) Then
            lblTitle.Text = CurrentTVShow.Title
        End If
        lblRuntime.Text = String.Format(Languages.Premiered_Param, If(String.IsNullOrEmpty(CurrentTVShow.Premiered), "?", CurrentTVShow.Premiered))
        If Not String.IsNullOrEmpty(CurrentTVShow.MPAA) Then
            Dim tmpRatingImg As Image = APIXML.GetTVRatingImage(CurrentTVShow.MPAA)
            If Not IsNothing(tmpRatingImg) Then
                bpMPAA.Image = tmpRatingImg
                bpMPAA.Top = pnlGenres.Top + 4
                bpMPAA.Visible = True
            Else
                bpMPAA.Visible = False
            End If
        End If

        Dim tmpRating As Single = NumUtils.ConvertToSingle(CurrentTVShow.Rating)
        If tmpRating > 0 Then
            BuildStars(tmpRating)
        End If

        If Not String.IsNullOrEmpty(CurrentTVShow.Genre) Then
            CreateGenreThumbs(CurrentTVShow.Genre)
        End If

        If Not String.IsNullOrEmpty(CurrentTVShow.Studio) Then
            pbStudio.Image = APIXML.GetStudioImage(CurrentTVShow.Studio)
        Else
            pbStudio.Image = APIXML.GetStudioImage("####")
        End If

        pnlInfoIcons.Width = pbStudio.Width + 1
        pbStudio.Left = 0

        If CurrentTVSeason IsNot Nothing Then
            SetPictureboxImage(CurrentTVSeason.PosterPath, Master.eSettings.NoDisplayPoster, False, pbPoster, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))
            SetPictureboxImage(CurrentTVShow.FanartPath, Master.eSettings.NoDisplayFanart, True, pbFanart, False)
        Else
            SetPictureboxImage(CurrentTVShow.PosterPath, Master.eSettings.NoDisplayPoster, False, pbPoster, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))
            SetPictureboxImage(CurrentTVShow.FanartPath, Master.eSettings.NoDisplayFanart, False, pbFanart, False)
        End If

        SetPictureboxImage(Classes.Database.GetTVAllSeasonPath(CurrentTVShow.ID), Master.eSettings.NoDisplayPoster, False, pbAllSeason, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))
    End Sub

    Private Sub LoadTVEpInfo(CurrentTVShow As Model.TVShow, CurrentTVEp As Model.TVEp)
        Dim filePath As String = CurrentTVEp.TVEpPath.FilePath

        lblTitle.Text = If(String.IsNullOrEmpty(filePath), String.Concat(CurrentTVEp.Title, Languages.MISSING), CurrentTVEp.Title)
        lblRuntime.Text = String.Format(Languages.Aired_Param, If(String.IsNullOrEmpty(CurrentTVEp.Aired), "?", CurrentTVEp.Aired))

        lblTagline.Text = String.Format(Languages.SeasonEpisode_Param, _
                        If(String.IsNullOrEmpty(CurrentTVEp.Season.ToString), "?", CurrentTVEp.Season.ToString), _
                        If(String.IsNullOrEmpty(CurrentTVEp.Episode.ToString), "?", CurrentTVEp.Episode.ToString))


        If Not String.IsNullOrEmpty(CurrentTVShow.MPAA) Then
            Dim tmpRatingImg As Image = APIXML.GetTVRatingImage(CurrentTVShow.MPAA)
            If Not IsNothing(tmpRatingImg) Then
                bpMPAA.Image = tmpRatingImg
                bpMPAA.Top = pnlGenres.Top + 4
                bpMPAA.Visible = True
            Else
                bpMPAA.Visible = False
            End If
        End If

        Dim tmpRating As Single = NumUtils.ConvertToSingle(CurrentTVEp.Rating)
        If tmpRating > 0 Then
            BuildStars(tmpRating)
        End If

        If Not String.IsNullOrEmpty(CurrentTVShow.Genre) Then
            CreateGenreThumbs(CurrentTVShow.Genre)
        End If

        If Not String.IsNullOrEmpty(CurrentTVShow.Studio) Then
            pbStudio.Image = APIXML.GetStudioImage(CurrentTVShow.Studio)
        Else
            pbStudio.Image = APIXML.GetStudioImage("####")
        End If

        SetPictureboxImage(CurrentTVEp.PosterPath, Master.eSettings.NoDisplayPoster, False, pbPoster, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))
        If String.IsNullOrEmpty(CurrentTVEp.FanartPath) Then
            SetPictureboxImage(CurrentTVShow.FanartPath, Master.eSettings.NoDisplayFanart, True, pbFanart, False)
        Else
            SetPictureboxImage(CurrentTVEp.FanartPath, Master.eSettings.NoDisplayFanart, False, pbFanart, False)
        End If
        SetPictureboxImage(Classes.Database.GetTVAllSeasonPath(CurrentTVShow.ID), Master.eSettings.NoDisplayPoster, False, pbAllSeason, AdvancedSettings.GetBooleanSetting("PosterGlassOverlay", True))

        bwMediaInfo = New System.ComponentModel.BackgroundWorker
        bwMediaInfo.WorkerSupportsCancellation = True
        bwMediaInfo.RunWorkerAsync(New With {.MediaItem = CurrentTVEp})
    End Sub

    Public Sub LoadInfo(CurrentMedia As Object)
        Select Case ObjectContext.GetObjectType(CurrentMedia.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(CurrentMedia, Model.Movie)
                LoadMovieInfo(currentMovie)
            Case GetType(Model.TVShow)
                Dim currentTVShow = DirectCast(CurrentMedia, Model.TVShow)
                LoadTVShowInfo(currentTVShow)
            Case GetType(Model.TVSeason)
                Dim currentTVSeason = DirectCast(CurrentMedia, Model.TVSeason)
                Dim currentTVShow = Classes.Database.GetTVShow(currentTVSeason.TVShowID)
                LoadTVShowInfo(currentTVShow, currentTVSeason)
            Case GetType(Model.TVEp)
                Dim currentTVEp = DirectCast(CurrentMedia, Model.TVEp)
                Dim currentTVShow = Classes.Database.GetTVShow(currentTVEp.TVShowID)
                LoadTVEpInfo(currentTVShow, currentTVEp)
        End Select
    End Sub

    Private Sub SetAVImages(ByVal aImage As Image())
        Try
            pbResolution.Image = aImage(0)
            pbVideo.Image = aImage(1)
            pbVType.Image = aImage(2)
            pbAudio.Image = aImage(3)
            pbChannels.Image = aImage(4)
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Public Sub Clear()
        pbStar1.Image = Nothing
        pbStar2.Image = Nothing
        pbStar3.Image = Nothing
        pbStar4.Image = Nothing
        pbStar5.Image = Nothing
        ToolTips.SetToolTip(pbStar1, "")
        ToolTips.SetToolTip(pbStar2, "")
        ToolTips.SetToolTip(pbStar3, "")
        ToolTips.SetToolTip(pbStar4, "")
        ToolTips.SetToolTip(pbStar5, "")
        pbStudio.Image = Nothing
        pbVideo.Image = Nothing
        pbVType.Image = Nothing
        pbAudio.Image = Nothing
        pbAllSeason.Image = Nothing
        pbResolution.Image = Nothing
        pbChannels.Image = Nothing
        lblTitle.Text = String.Empty
        lblVotes.Text = String.Empty
        lblRuntime.Text = String.Empty
        lblTagline.Text = String.Empty
        pnlGenres.Controls.Clear()
    End Sub

    Private Sub pbStudio_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles pbStudio.MouseEnter
        If pbStudio.Tag IsNot Nothing Then
            If Not AdvancedSettings.GetBooleanSetting("StudioTagAlwaysOn", False) AndAlso Not String.IsNullOrEmpty(pbStudio.Tag.ToString) Then
                lblStudio.Text = pbStudio.Tag.ToString
            End If
        End If
    End Sub
    Private Sub pbStudio_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles pbStudio.MouseLeave
        If Not AdvancedSettings.GetBooleanSetting("StudioTagAlwaysOn", False) Then lblStudio.Text = String.Empty
    End Sub

    Private Sub BuildStars(ByVal sinRating As Single)
        '//
        ' Convert # rating to star images
        '\\

        Try           
            With Me
                .pbStar1.Image = Nothing
                .pbStar2.Image = Nothing
                .pbStar3.Image = Nothing
                .pbStar4.Image = Nothing
                .pbStar5.Image = Nothing

                Dim tTip As String = String.Concat(Languages.Rating, String.Format(" {0:N}", sinRating))
                ToolTips.SetToolTip(.pbStar1, tTip)
                ToolTips.SetToolTip(.pbStar2, tTip)
                ToolTips.SetToolTip(.pbStar3, tTip)
                ToolTips.SetToolTip(.pbStar4, tTip)
                ToolTips.SetToolTip(.pbStar5, tTip)

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

    Private Sub bwMediaInfo_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwMediaInfo.DoWork
        '//
        ' Thread to procure technical and tag information about media via MediaInfo.dll
        '\\      
        Try
            Select Case ObjectContext.GetObjectType(e.Argument.MediaItem.GetType())
                Case GetType(Model.Movie)
                    Dim currentMovie = DirectCast(e.Argument.MediaItem, Model.Movie)
                    MediaInfo.UpdateMediaInfo(currentMovie)
                    'Master.DB.SaveMovieToDB(e.Argument.Movie, False, False, True)
                    e.Result = New With {.fileinfo = MediaInfo.FIToString(currentMovie.FileInfo), .MediaItem = currentMovie}
                Case GetType(Model.TVEp)
                    Dim currentTVEp = DirectCast(e.Argument.MediaItem, Model.TVEp)
                    MediaInfo.UpdateTVMediaInfo(currentTVEp)
                    'Master.DB.SaveTVEpToDB(e.Argument.MediaItem, False, False, False, True)
                    e.Result = New With {.fileinfo = MediaInfo.FIToString(currentTVEp.FileInfo), .MediaItem = currentTVEp}
            End Select

            If bwMediaInfo.CancellationPending Then
                e.Cancel = True
                Return
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error, False)
            e.Result = New With {.fileinfo = "error"}
            e.Cancel = True
        End Try
    End Sub

    Private Sub bwMediaInfo_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwMediaInfo.RunWorkerCompleted
        '//
        ' Thread finished: fill textbox with result
        '\\

        If Not e.Cancelled Then
            Try                
                If Not e.Result.fileInfo = "error" Then
                    'Me.pbMILoading.Visible = False
                    'Me.txtMetaData.Text = Res.fileInfo                    
                    Select Case ObjectContext.GetObjectType(e.Result.MediaItem.GetType())
                        Case GetType(Model.Movie)
                            Dim currentMovie = DirectCast(e.Result.MediaItem, Model.Movie)
                            If Master.eSettings.ScanMediaInfo Then
                                SetAVImages(APIXML.GetAVImages(currentMovie.FileInfo, currentMovie.MoviePath, False, currentMovie.FileSource))
                                pnlInfoIcons.Width = pbVideo.Width + pbVType.Width + pbResolution.Width + pbAudio.Width + pbChannels.Width + pbStudio.Width + 6
                                pbStudio.Left = pbVideo.Width + pbVType.Width + pbResolution.Width + pbAudio.Width + pbChannels.Width + 5
                            Else
                                pnlInfoIcons.Width = pbStudio.Width + 1
                                pbStudio.Left = 0
                            End If
                        Case GetType(Model.TVEp)
                            Dim currentTVEp = DirectCast(e.Result.MediaItem, Model.TVEp)
                            Dim filePath As String = currentTVEp.TVEpPath.FilePath
                            If Master.eSettings.ScanTVMediaInfo Then
                                SetAVImages(APIXML.GetAVImages(currentTVEp.FileInfo, filePath, False, APIXML.GetFileSource(filePath)))
                                pnlInfoIcons.Width = pbVideo.Width + pbVType.Width + pbResolution.Width + pbAudio.Width + pbChannels.Width + pbStudio.Width + 6
                                pbStudio.Left = pbVideo.Width + pbVType.Width + pbResolution.Width + pbAudio.Width + pbChannels.Width + 5
                            Else
                                pnlInfoIcons.Width = pbStudio.Width + 1
                                pbStudio.Left = 0
                            End If
                    End Select
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End If
    End Sub

    <Localizable(False)>
    Private Sub CreateGenreThumbs(ByVal strGenres As String)
        '//
        ' Parse the genre string and create panels/pictureboxes for each one
        '\\        
        pnlGenres.Controls.Clear()
        Try
            Dim genreArray() As String = strGenres.Split(New String() {" / "}, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer = 0
            For Each genre In genreArray
                Dim pbGenre As New BorderPicturebox
                pbGenre.Name = genre.Trim.ToUpper
                pbGenre.BorderWidth = 2
                pbGenre.Size = New Size(68, 100)
                pbGenre.SizeMode = BorderPicturebox.PhotoBoxSizeMode.Normal
                pbGenre.BorderColor = Color.Gainsboro
                pbGenre.Image = APIXML.GetGenreImage(genre.Trim)
                pbGenre.Left = ((pnlGenres.Right) - (i * 73)) - 73
                pbGenre.Top = 0
                pbGenre.Anchor = AnchorStyles.Right + AnchorStyles.Top
                pnlGenres.Controls.Add(pbGenre)                

                If Master.eSettings.AllwaysDisplayGenresText Then
                    pbGenre.CaptionText = pbGenre.Name
                    pbGenre.CaptionFont = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                Else
                    AddHandler pbGenre.MouseEnter, AddressOf pbGenre_MouseEnter
                    AddHandler pbGenre.MouseLeave, AddressOf pbGenre_MouseLeave
                End If
                i = i + 1
            Next
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    <Localizable(False)>
    Private Sub pbGenre_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        '//
        ' Draw genre text over the image when mouse hovers
        '\\
        Try
            Dim pb As BorderPicturebox = DirectCast(sender, BorderPicturebox)
            pb.CaptionText = pb.Name
            pb.CaptionFont = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            pb.Invalidate()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub pbGenre_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        '//
        ' Reset genre image when mouse leaves to "clear" the text
        '\\
        Try
            Dim pb As BorderPicturebox = DirectCast(sender, BorderPicturebox)
            pb.CaptionText = ""
            pb.Invalidate()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles pbPoster.DoubleClick, pbFanart.DoubleClick
        Try
            If DirectCast(sender, BorderPicturebox).Image IsNot Nothing Then
                Using dImgView As New dlgImgView
                    dImgView.ShowDialog(DirectCast(sender, BorderPicturebox).Image)
                End Using
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub ImagesPanel_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        Dim toolStripProfessionalRenderer = TryCast(tsMain.Renderer, ToolStripProfessionalRenderer)
        If (toolStripProfessionalRenderer IsNot Nothing) Then
            toolStripProfessionalRenderer.RoundedEdges = False
        End If
    End Sub

    Private Sub ImagesPanel_Resize(sender As System.Object, e As EventArgs) Handles MyBase.Resize
        bpMPAA.Top = pnlGenres.Top + 4
    End Sub
End Class
