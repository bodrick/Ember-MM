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

'TODO: 1.5 - TV Show renaming (including "dump folder")
'TODO: 1.5 - Support VIDEO_TS/BDMV folders for TV Shows
Imports System.IO
Imports System.Text.RegularExpressions
Imports EmberMediaManger.API
Imports System.Data.Objects
Imports System.Threading.Tasks
Imports TechNuts.ScraperXML
Imports TechNuts.MediaTags

Namespace Scrapers.TV

    Public Class dlgTVImageSelect

#Region "Fields"

        Private _imageList As New List(Of Thumbnail)
        Private DefaultImages As New TechNuts.MediaTags.Thumbnail
        Private FanartList As New List(Of TechNuts.MediaTags.Thumbnail)
        Private GenericPosterList As New List(Of TechNuts.MediaTags.Thumbnail)
        Private iCounter As Integer = 0
        Private iLeft As Integer = 5
        Private iTop As Integer = 5
        Private SeasonList As New List(Of TechNuts.MediaTags.Thumbnail)
        Private SelIsPoster As Boolean = True
        Private SelSeason As Integer = -999
        Private ShowPosterList As New List(Of TechNuts.MediaTags.Thumbnail)
        Private _fanartchanged As Boolean = False
        Private _id As Integer = -1
        Private _season As Integer = -999
        Private _episode As Integer = -1
        Private _type As Enums.TVImageType = Enums.TVImageType.All
        Private _withcurrent As Boolean = True
        Private _ScrapeType As Enums.ScrapeType
        Private _currentMediaItem As Object
        Private _tvShow As TvShowTag

#End Region 'Fields

#Region "Methods"

        Public Function SetDefaults() As Boolean
            'Dim iSeason As Integer = -1
            'Dim iEpisode As Integer = -1
            'Dim iProgress As Integer = 3

            'Dim tSea As Scraper.TVDBSeasonPoster

            'Try
            '    bwLoadImages.ReportProgress(Scraper.TVDBImages.SeasonImageList.Count + Scraper.tmpTVDBShow.Episodes.Count + 3, "defaults")

            '    If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowPoster) AndAlso IsNothing(Scraper.TVDBImages.ShowPoster.Image.Image) Then
            '        If Master.eSettings.IsShowBanner Then
            '            Dim tSP As Scraper.TVDBShowPoster = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Type = Master.eSettings.PreferredShowBannerType AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '            If Master.eSettings.OnlyGetTVImagesForSelectedLanguage Then
            '                If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Language = Master.eSettings.TVDBLanguage)
            '            End If

            '            If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Type = Master.eSettings.PreferredShowBannerType)

            '            'no preferred size, just get any one of them
            '            If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '            If Not IsNothing(tSP) Then
            '                Scraper.TVDBImages.ShowPoster.Image.Image = tSP.Image.Image
            '                Scraper.TVDBImages.ShowPoster.LocalFile = tSP.LocalFile
            '                Scraper.TVDBImages.ShowPoster.URL = tSP.URL
            '            Else
            '                'still nothing? try to get from generic posters
            '                Dim tSPg As Scraper.TVDBPoster = GenericPosterList.FirstOrDefault(Function(p) p.Language = Master.eSettings.TVDBLanguage AndAlso Not IsNothing(p.Image.Image))

            '                If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '                If Not IsNothing(tSPg) Then
            '                    Scraper.TVDBImages.ShowPoster.Image.Image = tSPg.Image.Image
            '                    Scraper.TVDBImages.ShowPoster.LocalFile = tSPg.LocalFile
            '                    Scraper.TVDBImages.ShowPoster.URL = tSPg.URL
            '                End If
            '            End If
            '        Else
            '            Dim tSPg As Scraper.TVDBPoster = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso GetPosterDims(p.Size) = Master.eSettings.PreferredShowPosterSize AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '            If Master.eSettings.OnlyGetTVImagesForSelectedLanguage Then
            '                If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Language = Master.eSettings.TVDBLanguage)
            '            End If

            '            If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso GetPosterDims(p.Size) = Master.eSettings.PreferredShowPosterSize)

            '            'no preferred size, just get any one of them
            '            If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '            If Not IsNothing(tSPg) Then
            '                Scraper.TVDBImages.ShowPoster.Image.Image = tSPg.Image.Image
            '                Scraper.TVDBImages.ShowPoster.LocalFile = tSPg.LocalFile
            '                Scraper.TVDBImages.ShowPoster.URL = tSPg.URL
            '            Else
            '                Dim tSP As Scraper.TVDBShowPoster = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '                If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '                If Not IsNothing(tSP) Then
            '                    Scraper.TVDBImages.ShowPoster.Image.Image = tSP.Image.Image
            '                    Scraper.TVDBImages.ShowPoster.LocalFile = tSP.LocalFile
            '                    Scraper.TVDBImages.ShowPoster.URL = tSP.URL
            '                End If
            '            End If
            '        End If
            '    End If

            '    If bwLoadImages.CancellationPending Then
            '        Return True
            '    End If
            '    bwLoadImages.ReportProgress(1, "progress")

            '    If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowFanart OrElse _type = Enums.TVImageType.EpisodeFanart) AndAlso IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '        Dim tSF As Scraper.TVDBFanart = FanartList.FirstOrDefault(Function(f) Not IsNothing(f.Image.Image) AndAlso GetFanartDims(f.Size) = Master.eSettings.PreferredShowFanartSize AndAlso f.Language = Master.eSettings.TVDBLanguage)

            '        If IsNothing(tSF) Then tSF = FanartList.FirstOrDefault(Function(f) Not IsNothing(f.Image.Image) AndAlso GetFanartDims(f.Size) = Master.eSettings.PreferredShowFanartSize)

            '        'no fanart of the preferred size, just get the first available
            '        If IsNothing(tSF) Then tSF = FanartList.FirstOrDefault(Function(f) Not IsNothing(f.Image.Image))

            '        If Not IsNothing(tSF) Then
            '            If Not String.IsNullOrEmpty(tSF.LocalFile) AndAlso File.Exists(tSF.LocalFile) Then
            '                Scraper.TVDBImages.ShowFanart.Image.FromFile(tSF.LocalFile)
            '                Scraper.TVDBImages.ShowFanart.LocalFile = tSF.LocalFile
            '                Scraper.TVDBImages.ShowFanart.URL = tSF.URL
            '            ElseIf Not String.IsNullOrEmpty(tSF.LocalFile) AndAlso Not String.IsNullOrEmpty(tSF.URL) Then
            '                Scraper.TVDBImages.ShowFanart.Image.FromWeb(tSF.URL)
            '                If Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '                    Directory.CreateDirectory(Directory.GetParent(tSF.LocalFile).FullName)
            '                    Scraper.TVDBImages.ShowFanart.Image.Save(tSF.LocalFile)
            '                    Scraper.TVDBImages.ShowFanart.LocalFile = tSF.LocalFile
            '                    Scraper.TVDBImages.ShowFanart.URL = tSF.URL
            '                End If
            '            End If
            '        End If
            '    End If

            '    If bwLoadImages.CancellationPending Then
            '        Return True
            '    End If
            '    bwLoadImages.ReportProgress(2, "progress")

            '    If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.AllSeasonPoster) AndAlso Master.eSettings.AllSeasonPosterEnabled AndAlso IsNothing(Scraper.TVDBImages.AllSeasonPoster.Image.Image) Then
            '        If Master.eSettings.IsAllSBanner Then
            '            Dim tSP As Scraper.TVDBShowPoster = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Type = Master.eSettings.PreferredAllSBannerType AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '            If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Type = Master.eSettings.PreferredAllSBannerType)

            '            'no preferred size, just get any one of them
            '            If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '            If Not IsNothing(tSP) Then
            '                Scraper.TVDBImages.AllSeasonPoster.Image.Image = tSP.Image.Image
            '                Scraper.TVDBImages.AllSeasonPoster.LocalFile = tSP.LocalFile
            '                Scraper.TVDBImages.AllSeasonPoster.URL = tSP.URL
            '            Else
            '                'still nothing? try to get from generic posters
            '                Dim tSPg As Scraper.TVDBPoster = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '                If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '                If Not IsNothing(tSPg) Then
            '                    Scraper.TVDBImages.AllSeasonPoster.Image.Image = tSPg.Image.Image
            '                    Scraper.TVDBImages.AllSeasonPoster.LocalFile = tSPg.LocalFile
            '                    Scraper.TVDBImages.AllSeasonPoster.URL = tSPg.URL
            '                End If
            '            End If
            '        Else
            '            Dim tSPg As Scraper.TVDBPoster = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso GetPosterDims(p.Size) = Master.eSettings.PreferredAllSPosterSize AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '            If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso GetPosterDims(p.Size) = Master.eSettings.PreferredAllSPosterSize)

            '            'no preferred size, just get any one of them
            '            If IsNothing(tSPg) Then tSPg = GenericPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '            If Not IsNothing(tSPg) Then
            '                Scraper.TVDBImages.AllSeasonPoster.Image.Image = tSPg.Image.Image
            '                Scraper.TVDBImages.AllSeasonPoster.LocalFile = tSPg.LocalFile
            '                Scraper.TVDBImages.AllSeasonPoster.URL = tSPg.URL
            '            Else
            '                Dim tSP As Scraper.TVDBShowPoster = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Language = Master.eSettings.TVDBLanguage)

            '                If IsNothing(tSP) Then tSP = ShowPosterList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image))

            '                If Not IsNothing(tSP) Then
            '                    Scraper.TVDBImages.AllSeasonPoster.Image.Image = tSP.Image.Image
            '                    Scraper.TVDBImages.AllSeasonPoster.LocalFile = tSP.LocalFile
            '                    Scraper.TVDBImages.AllSeasonPoster.URL = tSP.URL
            '                End If
            '            End If
            '        End If
            '    End If

            '    If bwLoadImages.CancellationPending Then
            '        Return True
            '    End If
            '    bwLoadImages.ReportProgress(3, "progress")

            '    If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.SeasonPoster OrElse _type = Enums.TVImageType.SeasonFanart Then
            '        For Each cSeason As Scraper.TVDBSeasonImage In Scraper.TVDBImages.SeasonImageList
            '            Try
            '                iSeason = cSeason.Season
            '                If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.SeasonPoster) AndAlso IsNothing(cSeason.Poster.Image) Then
            '                    tSea = SeasonList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Season = iSeason AndAlso p.Type = Master.eSettings.PreferredSeasonPosterSize AndAlso p.Language = Master.eSettings.TVDBLanguage)
            '                    If IsNothing(tSea) Then tSea = SeasonList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Season = iSeason AndAlso p.Type = Master.eSettings.PreferredSeasonPosterSize)
            '                    If IsNothing(tSea) Then tSea = SeasonList.FirstOrDefault(Function(p) Not IsNothing(p.Image.Image) AndAlso p.Season = iSeason)
            '                    If Not IsNothing(tSea) Then cSeason.Poster.Image = tSea.Image.Image
            '                End If
            '                If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.SeasonFanart) AndAlso Master.eSettings.SeasonFanartEnabled AndAlso IsNothing(cSeason.Fanart.Image.Image) AndAlso Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then cSeason.Fanart.Image.Image = Scraper.TVDBImages.ShowFanart.Image.Image

            '                If bwLoadImages.CancellationPending Then
            '                    Return True
            '                End If
            '                bwLoadImages.ReportProgress(iProgress, "progress")
            '                iProgress += 1
            '            Catch ex As Exception
            '                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            '            End Try
            '        Next
            '    End If

            '    If _type = Enums.TVImageType.All Then
            '        For Each Episode As Structures.DBTV In Scraper.tmpTVDBShow.Episodes
            '            Try
            '                If Not String.IsNullOrEmpty(Episode.TVEp.LocalFile) Then
            '                    Episode.TVEp.Poster.FromFile(Episode.TVEp.LocalFile)
            '                ElseIf Not String.IsNullOrEmpty(Episode.EpPosterPath) Then
            '                    Episode.TVEp.Poster.FromFile(Episode.EpPosterPath)
            '                End If

            '                If Master.eSettings.EpisodeFanartEnabled Then
            '                    If Not String.IsNullOrEmpty(Episode.EpFanartPath) Then
            '                        Episode.TVEp.Fanart.FromFile(Episode.EpFanartPath)
            '                    ElseIf Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '                        Episode.TVEp.Fanart.Image = Scraper.TVDBImages.ShowFanart.Image.Image
            '                    End If
            '                End If

            '                If bwLoadImages.CancellationPending Then
            '                    Return True
            '                End If
            '                bwLoadImages.ReportProgress(iProgress, "progress")
            '                iProgress += 1
            '            Catch ex As Exception
            '                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            '            End Try
            '        Next
            '    End If
            'Catch ex As Exception
            '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            'End Try

            'DefaultImages = Scraper.TVDBImages.Clone

            Return False
        End Function

        Public Overloads Function ShowDialog(ByVal currentObject As Object, ByVal imageType As Enums.TVImageType, ByVal scrapeType As Enums.ScrapeType, ByVal currentImage As Image) As Image
            _currentMediaItem = currentObject
            _type = imageType
            _ScrapeType = scrapeType
            If currentImage IsNot Nothing Then
                pbCurrent.Image = currentImage
            End If

            If MyBase.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return pbCurrent.Image
            Else
                Return Nothing
            End If
        End Function

        Private Sub AddImage(ByVal iImage As Thumbnail, index As Integer)
            Try
                Dim pnlImage = New Panel
                Dim pbImage = New PictureBox
                Dim lblImage = New Label
                pnlImage.Name = index
                pbImage.Name = "pbImage"
                lblImage.Name = "lblImage"
                pbImage.Tag = index
                lblImage.Tag = index
                pnlImage.Size = New Size(187, 187)
                pbImage.Size = New Size(181, 151)
                lblImage.Size = New Size(181, 30)
                pnlImage.BackColor = Color.White
                pnlImage.BorderStyle = BorderStyle.FixedSingle
                pbImage.SizeMode = PictureBoxSizeMode.Zoom
                lblImage.AutoSize = False
                lblImage.BackColor = Color.White
                lblImage.TextAlign = ContentAlignment.MiddleCenter
                If String.IsNullOrEmpty(iImage.Dimensions) Then
                    lblImage.Text = String.Format(Languages.Size_Param, iImage.Img.Width, iImage.Img.Height)
                Else
                    lblImage.Text = iImage.Dimensions
                End If
                lblImage.Left = 0
                lblImage.Top = 151
                pbImage.Left = 3
                pbImage.Top = 3
                pbImage.Image = iImage.Img
                pnlImages.Controls.Add(pnlImage)
                pnlImage.Controls.Add(pbImage)
                pnlImage.Controls.Add(lblImage)
                pnlImage.BringToFront()
                AddHandler pbImage.Click, AddressOf pbImage_Click
                AddHandler pbImage.DoubleClick, AddressOf pbImage_DoubleClick
                AddHandler pnlImage.Click, AddressOf pnlImage_Click
                AddHandler lblImage.Click, AddressOf lblImage_Click

                AddHandler pbImage.MouseWheel, AddressOf MouseWheelEvent
                AddHandler pnlImage.MouseWheel, AddressOf MouseWheelEvent
                AddHandler lblImage.MouseWheel, AddressOf MouseWheelEvent

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCancel.Click
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            DoneAndClose()
        End Sub

        Private Sub DoneAndClose()
            'If _type = Enums.TVImageType.All Then
            '    lblStatus.Text = Master.eLang.GetString(87, "Downloading Fullsize Fanart Image...")
            '    pbStatus.Style = ProgressBarStyle.Marquee
            '    pnlStatus.Visible = True
            '    Master.currShow.ShowPosterPath = Scraper.TVDBImages.ShowPoster.LocalFile
            '    If Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.LocalFile) AndAlso File.Exists(Scraper.TVDBImages.ShowFanart.LocalFile) Then
            '        Scraper.TVDBImages.ShowFanart.Image.FromFile(Scraper.TVDBImages.ShowFanart.LocalFile)
            '        Master.currShow.ShowFanartPath = Scraper.TVDBImages.ShowFanart.LocalFile
            '    ElseIf Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.URL) AndAlso Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.LocalFile) Then
            '        Scraper.TVDBImages.ShowFanart.Image.Clear()
            '        Scraper.TVDBImages.ShowFanart.Image.FromWeb(Scraper.TVDBImages.ShowFanart.URL)
            '        If Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '            Directory.CreateDirectory(Directory.GetParent(Scraper.TVDBImages.ShowFanart.LocalFile).FullName)
            '            Scraper.TVDBImages.ShowFanart.Image.Save(Scraper.TVDBImages.ShowFanart.LocalFile)
            '            Master.currShow.ShowFanartPath = Scraper.TVDBImages.ShowFanart.LocalFile
            '        End If
            '    End If
            '    If Master.eSettings.AllSeasonPosterEnabled AndAlso Not IsNothing(Scraper.TVDBImages.AllSeasonPoster.Image.Image) Then
            '        Master.currShow.SeasonPosterPath = Scraper.TVDBImages.AllSeasonPoster.LocalFile
            '    End If
            'ElseIf _type = Enums.TVImageType.SeasonFanart AndAlso _fanartchanged Then
            '    lblStatus.Text = Master.eLang.GetString(87, "Downloading Fullsize Fanart Image...")
            '    pbStatus.Style = ProgressBarStyle.Marquee
            '    pnlStatus.Visible = True
            '    If Not String.IsNullOrEmpty(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile) AndAlso File.Exists(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile) Then
            '        Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.FromFile(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile)
            '        pbCurrent.Image = Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.Image
            '    ElseIf Not String.IsNullOrEmpty(Scraper.TVDBImages.SeasonImageList(0).Fanart.URL) AndAlso Not String.IsNullOrEmpty(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile) Then
            '        Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.Clear()
            '        Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.FromWeb(Scraper.TVDBImages.SeasonImageList(0).Fanart.URL)
            '        If Not IsNothing(Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.Image) Then
            '            Directory.CreateDirectory(Directory.GetParent(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile).FullName)
            '            Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.Save(Scraper.TVDBImages.SeasonImageList(0).Fanart.LocalFile)
            '            pbCurrent.Image = Scraper.TVDBImages.SeasonImageList(0).Fanart.Image.Image
            '        End If
            '    End If
            'ElseIf (_type = Enums.TVImageType.ShowFanart OrElse _type = Enums.TVImageType.EpisodeFanart) AndAlso _fanartchanged Then
            '    lblStatus.Text = Master.eLang.GetString(87, "Downloading Fullsize Fanart Image...")
            '    pbStatus.Style = ProgressBarStyle.Marquee
            '    pnlStatus.Visible = True
            '    If Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.LocalFile) AndAlso File.Exists(Scraper.TVDBImages.ShowFanart.LocalFile) Then
            '        Scraper.TVDBImages.ShowFanart.Image.FromFile(Scraper.TVDBImages.ShowFanart.LocalFile)
            '        pbCurrent.Image = Scraper.TVDBImages.ShowFanart.Image.Image
            '    ElseIf Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.URL) AndAlso Not String.IsNullOrEmpty(Scraper.TVDBImages.ShowFanart.LocalFile) Then
            '        Scraper.TVDBImages.ShowFanart.Image.Clear()
            '        Scraper.TVDBImages.ShowFanart.Image.FromWeb(Scraper.TVDBImages.ShowFanart.URL)
            '        If Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '            Directory.CreateDirectory(Directory.GetParent(Scraper.TVDBImages.ShowFanart.LocalFile).FullName)
            '            Scraper.TVDBImages.ShowFanart.Image.Save(Scraper.TVDBImages.ShowFanart.LocalFile)
            '            pbCurrent.Image = Scraper.TVDBImages.ShowFanart.Image.Image
            '        End If
            '    End If
            'End If

            'DialogResult = Windows.Forms.DialogResult.OK
            'Close()
        End Sub


        Private Sub ScrapeData()
            Dim scrapeResults As New List(Of TechNuts.ScraperXML.ScrapeResultsEntity)
            Select Case ObjectContext.GetObjectType(_currentMediaItem.GetType())
                Case GetType(Model.TVShow)
                    Dim currentTVShow As Model.TVShow = DirectCast(_currentMediaItem, Model.TVShow)
                    scrapeResults = Master.ScraperMan.GetTvShowResults("The TVDB", currentTVShow.Title, "")
                Case GetType(Model.TVSeason)
                    Dim currentTVSeason = DirectCast(_currentMediaItem, Model.TVSeason)
                    scrapeResults = Master.ScraperMan.GetTvShowResults("The TVDB", currentTVSeason.TVShow.Title, "")
                    _season = currentTVSeason.Season
                Case GetType(Model.TVEp)
                    Dim currentTVEp = DirectCast(_currentMediaItem, Model.TVEp)
                    scrapeResults = Master.ScraperMan.GetTvShowResults("The TVDB", currentTVEp.TVShow.Title, "")
                    _season = currentTVEp.Season
                    _episode = currentTVEp.Episode
            End Select
            If scrapeResults.Count > 0 Then
                _tvShow = Master.ScraperMan.GetTvShowDetails(scrapeResults(0))

                Dim iProgress As Integer = 1
                Dim iSeason As Integer = -1

                Select Case _type
                    Case Enums.TVImageType.AllSeasonPoster
                        _imageList = (From r In _tvShow.Thumbs Where r.Season = "-1" Or r.Season = "0").Select(
                            Function(f)
                                f.Type = "AllSeasonPoster"
                                Return f
                            End Function).ToList()
                    Case Enums.TVImageType.SeasonFanart
                        _imageList = (From r In _tvShow.Fanart.Thumbs Where r.Season = _season.ToString()).Select(
                            Function(f)
                                f.Type = "SeasonFanart"
                                Return f
                            End Function).ToList()
                    Case Enums.TVImageType.SeasonPoster
                        _imageList = (From r In _tvShow.Thumbs Where r.Season = _season.ToString()).Select(
                            Function(f)
                                f.Type = "SeasonPoster"
                                Return f
                            End Function).ToList()
                    Case Enums.TVImageType.ShowFanart
                        _imageList = (From r In _tvShow.Fanart.Thumbs).Select(
                            Function(f)
                                f.Type = "ShowFanart"
                                Return f
                            End Function).ToList()
                    Case Enums.TVImageType.EpisodePoster
                        Dim episodeList As List(Of ScrapeResultsEntity) = Master.ScraperMan.GetEpisodeList("The TVDB", _tvShow.EpisodeGuide)
                        Dim episode = Master.ScraperMan.GetEpisodeDetails((From r In episodeList Where r.EpisodeNumber = _episode And r.Season = _season).SingleOrDefault())
                        Dim tempThumb = New Thumbnail
                        tempThumb.Thumb = episode.Thumb
                        tempThumb.Type = "EpisodePoster"
                        _imageList.Add(tempThumb)
                    Case Enums.TVImageType.ShowPoster
                        _imageList = (From r In _tvShow.Thumbs Where r.Season = "").Select(
                            Function(f)
                                f.Type = "ShowPoster"
                                Return f
                            End Function).ToList()
                    Case Enums.TVImageType.All
                        If _withcurrent Then

                            'If Not String.IsNullOrEmpty(Scraper.tmpTVDBShow.Show.ShowPosterPath) Then
                            '    Scraper.TVDBImages.ShowPoster.Image.FromFile(Scraper.tmpTVDBShow.Show.ShowPosterPath)
                            '    Scraper.TVDBImages.ShowPoster.LocalFile = Scraper.tmpTVDBShow.Show.ShowPosterPath
                            'End If

                            'If bwLoadData.CancellationPending Then
                            '    e.Cancel = True
                            '    Return
                            'End If

                            'If Not String.IsNullOrEmpty(Scraper.tmpTVDBShow.Show.ShowFanartPath) Then
                            '    Scraper.TVDBImages.ShowFanart.Image.FromFile(Scraper.tmpTVDBShow.Show.ShowFanartPath)
                            '    Scraper.TVDBImages.ShowFanart.LocalFile = Scraper.tmpTVDBShow.Show.ShowFanartPath
                            'End If

                            'If bwLoadData.CancellationPending Then
                            '    e.Cancel = True
                            '    Return
                            'End If

                            'If Master.eSettings.AllSeasonPosterEnabled AndAlso Not String.IsNullOrEmpty(Scraper.tmpTVDBShow.AllSeason.SeasonPosterPath) Then
                            '    Scraper.TVDBImages.AllSeasonPoster.Image.FromFile(Scraper.tmpTVDBShow.AllSeason.SeasonPosterPath)
                            '    Scraper.TVDBImages.AllSeasonPoster.LocalFile = Scraper.tmpTVDBShow.AllSeason.SeasonPosterPath
                            'End If

                            'If bwLoadData.CancellationPending Then
                            '    e.Cancel = True
                            '    Return
                            'End If

                            'For Each sEpisode As Structures.DBTV In Scraper.tmpTVDBShow.Episodes
                            '    Try
                            '        iSeason = sEpisode.TVEp.Season
                            '        If iSeason > -1 Then
                            '            If IsNothing(Scraper.TVDBImages.ShowPoster.Image) AndAlso Not String.IsNullOrEmpty(sEpisode.ShowPosterPath) Then
                            '                Scraper.TVDBImages.ShowPoster.Image.FromFile(sEpisode.ShowPosterPath)
                            '            End If

                            '            If bwLoadData.CancellationPending Then
                            '                e.Cancel = True
                            '                Return
                            '            End If

                            '            If Master.eSettings.EpisodeFanartEnabled AndAlso IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) AndAlso Not String.IsNullOrEmpty(sEpisode.ShowFanartPath) Then
                            '                Scraper.TVDBImages.ShowFanart.Image.FromFile(sEpisode.ShowFanartPath)
                            '                Scraper.TVDBImages.ShowFanart.LocalFile = sEpisode.ShowFanartPath
                            '            End If

                            '            If bwLoadData.CancellationPending Then
                            '                e.Cancel = True
                            '                Return
                            '            End If

                            '            If Scraper.TVDBImages.SeasonImageList.Where(Function(s) s.Season = iSeason).Count = 0 Then
                            '                cSI = New Scraper.TVDBSeasonImage
                            '                cSI.Season = iSeason
                            '                If Not String.IsNullOrEmpty(sEpisode.SeasonPosterPath) Then
                            '                    cSI.Poster.FromFile(sEpisode.SeasonPosterPath)
                            '                End If
                            '                If Master.eSettings.SeasonFanartEnabled AndAlso Not String.IsNullOrEmpty(sEpisode.SeasonFanartPath) Then
                            '                    cSI.Fanart.Image.FromFile(sEpisode.SeasonFanartPath)
                            '                    cSI.Fanart.LocalFile = sEpisode.SeasonFanartPath
                            '                End If
                            '                Scraper.TVDBImages.SeasonImageList.Add(cSI)
                            '            End If

                            '            If bwLoadData.CancellationPending Then
                            '                e.Cancel = True
                            '                Return
                            '            End If
                            '        End If
                            '        bwLoadData.ReportProgress(iProgress, "progress")
                            '        iProgress += 1
                            '    Catch ex As Exception
                            '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                            '    End Try
                            'Next
                        Else
                            'For Each sEpisode As Structures.DBTV In Scraper.tmpTVDBShow.Episodes
                            '    Try
                            '        iSeason = sEpisode.TVEp.Season

                            '        If Scraper.TVDBImages.SeasonImageList.Where(Function(s) s.Season = iSeason).Count = 0 Then
                            '            cSI = New Scraper.TVDBSeasonImage
                            '            cSI.Season = iSeason
                            '            Scraper.TVDBImages.SeasonImageList.Add(cSI)
                            '        End If

                            '        If bwLoadData.CancellationPending Then
                            '            e.Cancel = True
                            '            Return
                            '        End If

                            '        bwLoadData.ReportProgress(iProgress, "progress")
                            '        iProgress += 1
                            '    Catch ex As Exception
                            '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                            '    End Try
                            'Next
                        End If
                End Select
            End If
        End Sub

        Private Sub CheckCurrentImage()
            pbDelete.Visible = Not IsNothing(pbCurrent.Image) AndAlso pbCurrent.Visible
            pbUndo.Visible = pbCurrent.Visible
        End Sub

        Private Sub ClearImages()
            pnlImages.Controls.Clear()
        End Sub

        Private Sub dlgTVImageSelect_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            AddHandler pnlImages.MouseWheel, AddressOf MouseWheelEvent
            AddHandler MouseWheel, AddressOf MouseWheelEvent
            AddHandler tvList.MouseWheel, AddressOf MouseWheelEvent

            Functions.PNLDoubleBuffer(pnlImages)

            SetUp()
        End Sub

        Private Sub dlgTVImageSelect_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
            lblStatus.Text = Languages.Scraping_data
            pbStatus.Style = ProgressBarStyle.Marquee
            Dim dataTask = Task.Factory.StartNew(Sub() ScrapeData())
            While Not dataTask.IsCompleted
                Application.DoEvents()
                Threading.Thread.Sleep(50)
            End While
            GenerateList()
            lblStatus.Text = Languages.DownLoading_New_Images            
            Dim imageTask = Task.Factory.StartNew(Sub() DownloadAllImages())
            While Not imageTask.IsCompleted
                Application.DoEvents()
                Threading.Thread.Sleep(50)
            End While
            pnlStatus.Visible = False
            If _ScrapeType = Enums.ScrapeType.FullAuto Then
                DoneAndClose()
            Else
                tvList.Enabled = True
                tvList.Visible = True
                tvList.SelectedNode = tvList.Nodes(0)
                tvList.Focus()
                btnOK.Enabled = True
                pbCurrent.Visible = True
                lblCurrentImage.Visible = True
                Dim count As Integer = 0
                For Each img In _imageList
                    AddImage(img, count)
                    count = count + 1
                Next
            End If
        End Sub

        Private Sub DoSelect(ByVal index As Integer)
            Try
                Dim pnlImage As Panel
                Dim lblImage As Label
                For Each ctl In pnlImages.Controls
                    Select Case ctl.GetType()
                        Case GetType(Panel)
                            pnlImage = DirectCast(ctl, Panel)
                            pnlImage.BackColor = Color.White
                            lblImage = DirectCast(pnlImage.Controls.Item("lblImage"), Label)
                            lblImage.BackColor = Color.White
                            lblImage.ForeColor = Color.Black
                    End Select
                Next
                pnlImage = DirectCast(pnlImages.Controls.Item(index.ToString()), Panel)
                pnlImage.BackColor = Color.Blue
                lblImage = DirectCast(pnlImage.Controls.Item("lblImage"), Label)
                lblImage.BackColor = Color.Blue
                lblImage.ForeColor = Color.White
                SetImage(index)

                CheckCurrentImage()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub DownloadAllImages()            
            Try                
                Parallel.ForEach(_imageList, Sub(item, loopState, processed)
                                                 Dim localFileName = GetFileNameFromUrl(item.Thumb)
                                                 Try
                                                     Dim url As String = item.Thumb
                                                     If Not String.IsNullOrEmpty(item.Preview) Then
                                                         url = item.Preview
                                                     End If
                                                     If _type = Enums.TVImageType.EpisodeFanart Or _type = Enums.TVImageType.SeasonFanart Or _type = Enums.TVImageType.ShowFanart Then
                                                         url = _tvShow.Fanart.Url + url
                                                     End If

                                                     Dim tempImage = Classes.Http.DownloadImage(url)
                                                     If (tempImage IsNot Nothing) Then
                                                         item.Img = tempImage
                                                     End If

                                                 Catch ex As Exception
                                                     Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                                                 End Try
                                             End Sub)
                'If _type = Enums.TVImageType.All Then
                '    For Each Epi As Structures.DBTV In Scraper.tmpTVDBShow.Episodes
                '        Try
                '            If Not File.Exists(Epi.TVEp.LocalFile) Then
                '                If Not String.IsNullOrEmpty(Epi.TVEp.PosterURL) Then
                '                    Epi.TVEp.Poster.FromWeb(Epi.TVEp.PosterURL)
                '                    If Not IsNothing(Epi.TVEp.Poster.Image) Then
                '                        Directory.CreateDirectory(Directory.GetParent(Epi.TVEp.LocalFile).FullName)
                '                        Epi.TVEp.Poster.Save(Epi.TVEp.LocalFile)
                '                    End If
                '                End If
                '            Else
                '                Epi.TVEp.Poster.FromFile(Epi.TVEp.LocalFile)
                '            End If

                '            If bwLoadImages.CancellationPending Then
                '                Return True
                '            End If

                '            bwLoadImages.ReportProgress(iProgress, "progress")
                '            iProgress += 1
                '        Catch ex As Exception
                '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                '        End Try
                '    Next
                'End If

                'If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.SeasonPoster OrElse _type = Enums.TVImageType.AllSeasonPoster Then
                '    Select Case ObjectContext.GetObjectType(_currentMediaItem.GetType())
                '        Case GetType(Model.TVShow)
                '            Dim currentTVShow As Model.TVShow = DirectCast(_currentMediaItem, Model.TVShow)

                '        Case GetType(Model.TVSeason)
                '            Dim currentTVSeason = DirectCast(_currentMediaItem, Model.TVSeason)

                '    End Select
                '    Classes.ScraperFunctions.GetTVPosterUrls()
                '    For Each Seas As Scraper.TVDBSeasonPoster In Scraper.tmpTVDBShow.SeasonPosters
                '        Try
                '            If Not File.Exists(Seas.LocalFile) Then
                '                If Not String.IsNullOrEmpty(Seas.URL) Then
                '                    Seas.Image.FromWeb(Seas.URL)
                '                    If Not IsNothing(Seas.Image.Image) Then
                '                        Directory.CreateDirectory(Directory.GetParent(Seas.LocalFile).FullName)
                '                        Seas.Image.Save(Seas.LocalFile)
                '                        SeasonList.Add(Seas)
                '                    End If
                '                End If
                '            Else
                '                Seas.Image.FromFile(Seas.LocalFile)
                '                SeasonList.Add(Seas)
                '            End If

                '            If bwLoadImages.CancellationPending Then
                '                Return True
                '            End If

                '            bwLoadImages.ReportProgress(iProgress, "progress")
                '            iProgress += 1
                '        Catch ex As Exception
                '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                '        End Try
                '    Next
                'End If

                'If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowPoster OrElse _type = Enums.TVImageType.AllSeasonPoster Then
                '    For Each SPost As Scraper.TVDBShowPoster In Scraper.tmpTVDBShow.ShowPosters
                '        Try
                '            If Not File.Exists(SPost.LocalFile) Then
                '                If Not String.IsNullOrEmpty(SPost.URL) Then
                '                    SPost.Image.FromWeb(SPost.URL)
                '                    If Not IsNothing(SPost.Image.Image) Then
                '                        Directory.CreateDirectory(Directory.GetParent(SPost.LocalFile).FullName)
                '                        SPost.Image.Save(SPost.LocalFile)
                '                        ShowPosterList.Add(SPost)
                '                    End If
                '                End If
                '            Else
                '                SPost.Image.FromFile(SPost.LocalFile)
                '                ShowPosterList.Add(SPost)
                '            End If

                '            If bwLoadImages.CancellationPending Then
                '                Return True
                '            End If

                '            bwLoadImages.ReportProgress(iProgress, "progress")
                '            iProgress += 1
                '        Catch ex As Exception
                '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                '        End Try
                '    Next
                'End If

                'If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowFanart OrElse _type = Enums.TVImageType.SeasonFanart OrElse _type = Enums.TVImageType.EpisodeFanart Then
                '    For Each SFan As Scraper.TVDBFanart In Scraper.tmpTVDBShow.Fanart
                '        Try
                '            If Not File.Exists(SFan.LocalThumb) Then
                '                If Not String.IsNullOrEmpty(SFan.ThumbnailURL) Then
                '                    SFan.Image.FromWeb(SFan.ThumbnailURL)
                '                    If Not IsNothing(SFan.Image.Image) Then
                '                        Directory.CreateDirectory(Directory.GetParent(SFan.LocalThumb).FullName)
                '                        SFan.Image.Image.Save(SFan.LocalThumb)
                '                        FanartList.Add(SFan)
                '                    End If
                '                End If
                '            Else
                '                SFan.Image.FromFile(SFan.LocalThumb)
                '                FanartList.Add(SFan)
                '            End If

                '            If bwLoadImages.CancellationPending Then
                '                Return True
                '            End If

                '            bwLoadImages.ReportProgress(iProgress, "progress")
                '            iProgress += 1
                '        Catch ex As Exception
                '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                '        End Try
                '    Next
                'End If

                'If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowPoster OrElse _
                '_type = Enums.TVImageType.SeasonPoster OrElse _type = Enums.TVImageType.AllSeasonPoster Then
                '    For Each Post As Scraper.TVDBPoster In Scraper.tmpTVDBShow.Posters
                '        Try
                '            If Not File.Exists(Post.LocalFile) Then
                '                If Not String.IsNullOrEmpty(Post.URL) Then
                '                    Post.Image.FromWeb(Post.URL)
                '                    If Not IsNothing(Post.Image.Image) Then
                '                        Directory.CreateDirectory(Directory.GetParent(Post.LocalFile).FullName)
                '                        Post.Image.Save(Post.LocalFile)
                '                        GenericPosterList.Add(Post)
                '                    End If
                '                End If
                '            Else
                '                Post.Image.FromFile(Post.LocalFile)
                '                GenericPosterList.Add(Post)
                '            End If

                '            If bwLoadImages.CancellationPending Then
                '                Return True
                '            End If

                '            bwLoadImages.ReportProgress(iProgress, "progress")
                '            iProgress += 1
                '        Catch ex As Exception
                '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                '        End Try
                '    Next
                'End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Function DownloadFanart(ByVal url As String) As Image
            'Using tImage As New Images
            '    If Not String.IsNullOrEmpty(iTag.Path) AndAlso File.Exists(iTag.Path) Then
            '        tImage.FromFile(iTag.Path)
            '    ElseIf Not String.IsNullOrEmpty(iTag.Path) AndAlso Not String.IsNullOrEmpty(iTag.URL) Then
            lblStatus.Text = Languages.Downloading_Fullsize_Fanart_Image
            pbStatus.Style = ProgressBarStyle.Marquee
            pnlStatus.Visible = True

            Application.DoEvents()
            Dim fanartTask As Task(Of Image) = Task.Factory.StartNew(Function()
                                                                         Return Classes.Http.DownloadImage(url)
                                                                     End Function)
            While Not fanartTask.IsCompleted
                Application.DoEvents()
                Threading.Thread.Sleep(50)
            End While
            pnlStatus.Visible = False
            'Dim tempImage As Image = 
            '        If Not IsNothing(tImage.Image) Then
            '            Directory.CreateDirectory(Directory.GetParent(iTag.Path).FullName)
            '            tImage.Save(iTag.Path)
            '        End If

            '        sHTTP = Nothing


            '    End If

            Return fanartTask.Result
            'End Using
        End Function

        Private Sub GenerateList()
            Try
                If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowPoster Then tvList.Nodes.Add(New TreeNode With {.Text = Master.eLang.GetString(91, "Show Poster"), .Tag = "showp", .ImageIndex = 0, .SelectedImageIndex = 0})
                If _type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.ShowFanart OrElse _type = Enums.TVImageType.EpisodeFanart Then tvList.Nodes.Add(New TreeNode With {.Text = If(_type = Enums.TVImageType.EpisodeFanart, Master.eLang.GetString(92, "Episode Fanart"), Master.eLang.GetString(93, "Show Fanart")), .Tag = "showf", .ImageIndex = 1, .SelectedImageIndex = 1})
                If (_type = Enums.TVImageType.All OrElse _type = Enums.TVImageType.AllSeasonPoster) AndAlso Master.eSettings.AllSeasonPosterEnabled Then tvList.Nodes.Add(New TreeNode With {.Text = Master.eLang.GetString(94, "All Seasons Poster"), .Tag = "allp", .ImageIndex = 2, .SelectedImageIndex = 2})

                Dim TnS As TreeNode
                If _type = Enums.TVImageType.All Then
                    'For Each cSeason As Scraper.TVDBSeasonImage In Scraper.TVDBImages.SeasonImageList.OrderBy(Function(s) s.Season)
                    '    Try
                    '        TnS = New TreeNode(String.Format(Master.eLang.GetString(726, "Season {0}", True), cSeason.Season), 3, 3)
                    '        TnS.Nodes.Add(New TreeNode With {.Text = Master.eLang.GetString(95, "Season Posters"), .Tag = String.Concat("p", cSeason.Season.ToString), .ImageIndex = 0, .SelectedImageIndex = 0})
                    '        If Master.eSettings.SeasonFanartEnabled Then TnS.Nodes.Add(New TreeNode With {.Text = Master.eLang.GetString(96, "Season Fanart"), .Tag = String.Concat("f", cSeason.Season.ToString), .ImageIndex = 1, .SelectedImageIndex = 1})
                    '        tvList.Nodes.Add(TnS)
                    '    Catch ex As Exception
                    '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                    '    End Try
                    'Next
                ElseIf _type = Enums.TVImageType.SeasonPoster Then
                    tvList.Nodes.Add(New TreeNode With {.Text = String.Format(Master.eLang.GetString(97, "Season {0} Posters"), _season), .Tag = String.Concat("p", _season)})
                ElseIf _type = Enums.TVImageType.SeasonFanart Then
                    If Master.eSettings.SeasonFanartEnabled Then tvList.Nodes.Add(New TreeNode With {.Text = String.Format(Master.eLang.GetString(99, "Season {0} Fanart"), _season), .Tag = String.Concat("f", _season)})
                End If

                tvList.ExpandAll()

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Function GetFanartDims(ByVal fSize As Size) As Enums.FanartSize
            Try
                If (fSize.Width > 1000 AndAlso fSize.Height > 750) OrElse (fSize.Height > 1000 AndAlso fSize.Width > 750) Then
                    Return Enums.FanartSize.Lrg
                ElseIf (fSize.Width > 700 AndAlso fSize.Height > 400) OrElse (fSize.Height > 700 AndAlso fSize.Width > 400) Then
                    Return Enums.FanartSize.Mid
                Else
                    Return Enums.FanartSize.Small
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Function

        Private Function GetPosterDims(ByVal pSize As Size) As Enums.PosterSize
            Try
                If (pSize.Width > pSize.Height) AndAlso (pSize.Width > (pSize.Height * 2)) AndAlso (pSize.Width > 300) Then
                    'at least twice as wide than tall... consider it wide (also make sure it's big enough)
                    Return Enums.PosterSize.Wide
                ElseIf (pSize.Height > 1000 AndAlso pSize.Width > 750) OrElse (pSize.Width > 1000 AndAlso pSize.Height > 750) Then
                    Return Enums.PosterSize.Xlrg
                ElseIf (pSize.Height > 700 AndAlso pSize.Width > 500) OrElse (pSize.Width > 700 AndAlso pSize.Height > 500) Then
                    Return Enums.PosterSize.Lrg
                ElseIf (pSize.Height > 250 AndAlso pSize.Width > 150) OrElse (pSize.Width > 250 AndAlso pSize.Height > 150) Then
                    Return Enums.PosterSize.Mid
                Else
                    Return Enums.PosterSize.Small
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Function

        Private Sub lblImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DoSelect(Convert.ToInt32(DirectCast(sender, Label).Tag))
        End Sub

        Private Sub MouseWheelEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If e.Delta < 0 Then
                If (pnlImages.VerticalScroll.Value + 50) <= pnlImages.VerticalScroll.Maximum Then
                    pnlImages.VerticalScroll.Value += 50
                Else
                    pnlImages.VerticalScroll.Value = pnlImages.VerticalScroll.Maximum
                End If
            Else
                If (pnlImages.VerticalScroll.Value - 50) >= pnlImages.VerticalScroll.Minimum Then
                    pnlImages.VerticalScroll.Value -= 50
                Else
                    pnlImages.VerticalScroll.Value = pnlImages.VerticalScroll.Minimum
                End If
            End If
        End Sub

        Private Sub pbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDelete.Click
            pbCurrent.Image = Nothing
            SetImage(-1)
        End Sub

        Private Sub pbImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DoSelect(Convert.ToInt32(DirectCast(sender, PictureBox).Tag))
        End Sub

        Private Sub pbImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim imgTag = _imageList(Integer.Parse(sender.Tag))
            Dim tempImage As Image
            If String.IsNullOrEmpty(imgTag.Preview) Then
                tempImage = imgTag.Img
            Else
                Dim url As String = imgTag.Thumb
                If _type = Enums.TVImageType.EpisodeFanart Or _type = Enums.TVImageType.SeasonFanart Or _type = Enums.TVImageType.ShowFanart Then
                    url = _tvShow.Fanart.Url + url
                End If
                tempImage = DownloadFanart(url)
            End If
            If tempImage IsNot Nothing Then
                dlgImgView.ShowDialog(tempImage)
            End If
        End Sub

        Private Sub pbUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbUndo.Click
            'If SelSeason = -999 Then
            '    If SelIsPoster Then
            '        Scraper.TVDBImages.ShowPoster.Image.Image = DefaultImages.ShowPoster.Image.Image
            '        Scraper.TVDBImages.ShowPoster.LocalFile = DefaultImages.ShowPoster.LocalFile
            '        Scraper.TVDBImages.ShowPoster.URL = DefaultImages.ShowPoster.URL
            '        pbCurrent.Image = Scraper.TVDBImages.ShowPoster.Image.Image
            '    Else
            '        Scraper.TVDBImages.ShowFanart.Image.Image = DefaultImages.ShowFanart.Image.Image
            '        Scraper.TVDBImages.ShowFanart.LocalFile = DefaultImages.ShowFanart.LocalFile
            '        Scraper.TVDBImages.ShowFanart.URL = DefaultImages.ShowFanart.URL
            '        pbCurrent.Image = Scraper.TVDBImages.ShowFanart.Image.Image
            '    End If
            'ElseIf SelSeason = 999 Then
            '    Scraper.TVDBImages.AllSeasonPoster.Image.Image = DefaultImages.AllSeasonPoster.Image.Image
            '    Scraper.TVDBImages.AllSeasonPoster.LocalFile = DefaultImages.AllSeasonPoster.LocalFile
            '    Scraper.TVDBImages.AllSeasonPoster.URL = DefaultImages.AllSeasonPoster.URL
            '    pbCurrent.Image = Scraper.TVDBImages.AllSeasonPoster.Image.Image
            'Else
            '    If SelIsPoster Then
            '        Dim dSPost As Image = DefaultImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Poster.Image
            '        Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Poster.Image = dSPost
            '        pbCurrent.Image = dSPost
            '    Else
            '        Dim dSFan As Scraper.TVDBFanart = DefaultImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Fanart
            '        Dim tSFan As Scraper.TVDBFanart = Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Fanart
            '        tSFan.Image.Image = dSFan.Image.Image
            '        tSFan.LocalFile = dSFan.LocalFile
            '        tSFan.URL = dSFan.URL
            '        pbCurrent.Image = dSFan.Image.Image
            '    End If
            'End If
        End Sub

        Private Sub pnlImage_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim iIndex As Integer = Convert.ToInt32(DirectCast(sender, Panel).Name)
            DoSelect(iIndex)
        End Sub

        Private Sub SetImage(ByVal index As Integer)
            If (index > -1) Then
                pbCurrent.Image = _imageList(index).Img
            Else
                pbCurrent.Image = Nothing
            End If
            '_fanartchanged = True

            'If SelSeason = -999 Then
            '    If SelIsPoster Then
            '        Scraper.TVDBImages.ShowPoster.Image.Image = SelImage
            '        Scraper.TVDBImages.ShowPoster.LocalFile = SelTag.Path
            '        Scraper.TVDBImages.ShowPoster.URL = SelTag.URL
            '    Else
            '        Scraper.TVDBImages.ShowFanart.Image.Image = SelImage
            '        Scraper.TVDBImages.ShowFanart.LocalFile = SelTag.Path
            '        Scraper.TVDBImages.ShowFanart.URL = SelTag.URL
            '    End If
            'ElseIf SelSeason = 999 Then
            '    Scraper.TVDBImages.AllSeasonPoster.Image.Image = SelImage
            '    Scraper.TVDBImages.AllSeasonPoster.LocalFile = SelTag.Path
            '    Scraper.TVDBImages.AllSeasonPoster.URL = SelTag.URL
            'Else
            '    If SelIsPoster Then
            '        Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Poster.Image = SelImage
            '    Else
            '        Dim tFan As Scraper.TVDBFanart = Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(s) s.Season = SelSeason).Fanart
            '        If Not IsNothing(tFan) Then
            '            tFan.Image.Image = SelImage
            '            tFan.LocalFile = SelTag.Path
            '            tFan.URL = SelTag.URL
            '        End If
            '    End If
            'End If
        End Sub

        Private Sub SetUp()
            Text = Languages.TV_Image_Selection
            btnOK.Text = Languages.OK
            btnCancel.Text = Languages.Cancel
            lblCurrentImage.Text = Languages.Current_Image
        End Sub

        Private Sub tvList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvList.AfterSelect
            'Dim iCount As Integer = 0

            'Try
            '    ClearImages()
            '    If Not IsNothing(e.Node.Tag) AndAlso Not String.IsNullOrEmpty(e.Node.Tag.ToString) Then
            '        pbCurrent.Visible = True
            '        lblCurrentImage.Visible = True
            '        If e.Node.Tag.ToString = "showp" Then
            '            SelSeason = -999
            '            SelIsPoster = True
            '            If Not IsNothing(Scraper.TVDBImages.ShowPoster) AndAlso Not IsNothing(Scraper.TVDBImages.ShowPoster.Image) AndAlso Not IsNothing(Scraper.TVDBImages.ShowPoster.Image.Image) Then
            '                pbCurrent.Image = Scraper.TVDBImages.ShowPoster.Image.Image
            '            Else
            '                pbCurrent.Image = Nothing
            '            End If

            '            iCount = ShowPosterList.Count
            '            For i = 0 To iCount - 1
            '                If Not IsNothing(ShowPosterList(i)) AndAlso Not IsNothing(ShowPosterList(i).Image) AndAlso Not IsNothing(ShowPosterList(i).Image.Image) Then
            '                    AddImage(ShowPosterList(i).Image.Image, String.Format("{0}x{1}", ShowPosterList(i).Image.Image.Width, ShowPosterList(i).Image.Image.Height), i, New ImageTag With {.URL = ShowPosterList(i).URL, .Path = ShowPosterList(i).LocalFile, .isFanart = False})
            '                End If
            '            Next

            '            For i = 0 To GenericPosterList.Count - 1
            '                If Not IsNothing(GenericPosterList(i)) AndAlso Not IsNothing(GenericPosterList(i).Image) AndAlso Not IsNothing(GenericPosterList(i).Image.Image) Then
            '                    AddImage(GenericPosterList(i).Image.Image, String.Format("{0}x{1}", GenericPosterList(i).Image.Image.Width, GenericPosterList(i).Image.Image.Height), i + iCount, New ImageTag With {.URL = GenericPosterList(i).URL, .Path = GenericPosterList(i).LocalFile, .isFanart = False})
            '                End If
            '            Next

            '        ElseIf e.Node.Tag.ToString = "showf" Then

            '            SelSeason = -999
            '            SelIsPoster = False
            '            If Not IsNothing(Scraper.TVDBImages.ShowFanart) AndAlso Not IsNothing(Scraper.TVDBImages.ShowFanart.Image) AndAlso Not IsNothing(Scraper.TVDBImages.ShowFanart.Image.Image) Then
            '                pbCurrent.Image = Scraper.TVDBImages.ShowFanart.Image.Image
            '            Else
            '                pbCurrent.Image = Nothing
            '            End If

            '            For i = 0 To FanartList.Count - 1
            '                If Not IsNothing(FanartList(i)) AndAlso Not IsNothing(FanartList(i).Image) AndAlso Not IsNothing(FanartList(i).Image.Image) Then
            '                    AddImage(FanartList(i).Image.Image, String.Format("{0}x{1}", FanartList(i).Size.Width, FanartList(i).Size.Height), i, New ImageTag With {.URL = FanartList(i).URL, .Path = FanartList(i).LocalFile, .isFanart = True})
            '                End If
            '            Next

            '        ElseIf e.Node.Tag.ToString = "allp" Then
            '            SelSeason = 999
            '            SelIsPoster = True
            '            If Not IsNothing(Scraper.TVDBImages.AllSeasonPoster) AndAlso Not IsNothing(Scraper.TVDBImages.AllSeasonPoster.Image) AndAlso Not IsNothing(Scraper.TVDBImages.AllSeasonPoster.Image.Image) Then
            '                pbCurrent.Image = Scraper.TVDBImages.AllSeasonPoster.Image.Image
            '            Else
            '                pbCurrent.Image = Nothing
            '            End If

            '            iCount = GenericPosterList.Count
            '            For i = 0 To iCount - 1
            '                If Not IsNothing(GenericPosterList(i)) AndAlso Not IsNothing(GenericPosterList(i).Image) AndAlso Not IsNothing(GenericPosterList(i).Image.Image) Then
            '                    AddImage(GenericPosterList(i).Image.Image, String.Format("{0}x{1}", GenericPosterList(i).Image.Image.Width, GenericPosterList(i).Image.Image.Height), i, New ImageTag With {.URL = GenericPosterList(i).URL, .Path = GenericPosterList(i).LocalFile, .isFanart = False})
            '                End If
            '            Next

            '            For i = 0 To ShowPosterList.Count - 1
            '                If Not IsNothing(ShowPosterList(i)) AndAlso Not IsNothing(ShowPosterList(i).Image) AndAlso Not IsNothing(ShowPosterList(i).Image.Image) Then
            '                    AddImage(ShowPosterList(i).Image.Image, String.Format("{0}x{1}", ShowPosterList(i).Image.Image.Width, ShowPosterList(i).Image.Image.Height), i + iCount, New ImageTag With {.URL = ShowPosterList(i).URL, .Path = ShowPosterList(i).LocalFile, .isFanart = False})
            '                End If
            '            Next
            '        Else
            '            Dim tMatch As Match = Regex.Match(e.Node.Tag.ToString, "(?<type>f|p)(?<num>[0-9]+)")
            '            If tMatch.Success Then
            '                If tMatch.Groups("type").Value = "f" Then
            '                    SelSeason = Convert.ToInt32(tMatch.Groups("num").Value)
            '                    SelIsPoster = False
            '                    Dim tFanart As Scraper.TVDBSeasonImage = Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(f) f.Season = Convert.ToInt32(tMatch.Groups("num").Value))
            '                    If Not IsNothing(tFanart) AndAlso Not IsNothing(tFanart.Fanart) AndAlso Not IsNothing(tFanart.Fanart.Image) AndAlso Not IsNothing(tFanart.Fanart.Image.Image) Then
            '                        pbCurrent.Image = tFanart.Fanart.Image.Image
            '                    Else
            '                        pbCurrent.Image = Nothing
            '                    End If
            '                    For i = 0 To FanartList.Count - 1
            '                        If Not IsNothing(FanartList(i)) AndAlso Not IsNothing(FanartList(i).Image) AndAlso Not IsNothing(FanartList(i).Image.Image) Then
            '                            AddImage(FanartList(i).Image.Image, String.Format("{0}x{1}", FanartList(i).Size.Width, FanartList(i).Size.Height), i, New ImageTag With {.URL = FanartList(i).URL, .Path = FanartList(i).LocalFile, .isFanart = True})
            '                        End If
            '                    Next
            '                ElseIf tMatch.Groups("type").Value = "p" Then
            '                    SelSeason = Convert.ToInt32(tMatch.Groups("num").Value)
            '                    SelIsPoster = True
            '                    Dim tPoster As Scraper.TVDBSeasonImage = Scraper.TVDBImages.SeasonImageList.FirstOrDefault(Function(f) f.Season = SelSeason)
            '                    If Not IsNothing(tPoster) AndAlso Not IsNothing(tPoster.Poster) AndAlso Not IsNothing(tPoster.Poster.Image) Then
            '                        pbCurrent.Image = tPoster.Poster.Image
            '                    Else
            '                        pbCurrent.Image = Nothing
            '                    End If
            '                    iCount = 0
            '                    For Each SImage As Scraper.TVDBSeasonPoster In SeasonList.Where(Function(s) s.Season = Convert.ToInt32(tMatch.Groups("num").Value))
            '                        If Not IsNothing(SImage.Image) AndAlso Not IsNothing(SImage.Image.Image) Then
            '                            AddImage(SImage.Image.Image, String.Format("{0}x{1}", SImage.Image.Image.Width, SImage.Image.Image.Height), iCount, New ImageTag With {.URL = SImage.URL, .Path = SImage.LocalFile, .isFanart = False})
            '                        End If
            '                        iCount += 1
            '                    Next
            '                End If
            '            End If
            '        End If
            '    Else
            '        pbCurrent.Image = Nothing
            '        pbCurrent.Visible = False
            '        lblCurrentImage.Visible = False
            '    End If

            '    CheckCurrentImage()
            'Catch ex As Exception
            '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            'End Try
        End Sub

        Function GetFileNameFromUrl(ByVal url As String) As String
            Try
                Return url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1)
            Catch ex As Exception
                Return url
            End Try
        End Function

#End Region 'Methods

    End Class
End Namespace