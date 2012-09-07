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
Imports System.Xml.Serialization
Imports System.Net
Imports System.Drawing
Imports System.Windows.Forms

Namespace API

    <Serializable()> _
    Public Class Settings

#Region "Constructors"

        Public Sub New()
            Me.Clear()
        End Sub

#End Region 'Constructors

#Region "Enumerations"

        Public Enum EpRetrieve As Integer
            FromDirectory = 0
            FromFilename = 1
            FromSeasonResult = 2
        End Enum

#End Region 'Enumerations

#Region "Properties"

        Public Property ActorLimit As Integer
        Public Property AllSPosterHeight As Integer
        Public Property AllSPosterQuality As Integer
        Public Property AllSPosterWidth As Integer
        Public Property AllwaysDisplayGenresText As Boolean
        Public Property AlwaysGetEnglishTVImages As Boolean
        Public Property ClickScrape As Boolean
        Public Property AskCheckboxScrape As Boolean
        Public Property AutoBD As Boolean
        Public Property AutoDetectVTS As Boolean
        Public Property AutoET As Boolean
        Public Property AutoETSize As Enums.FanartSize
        Public Property AutoThumbs As Integer
        Public Property AutoThumbsNoSpoilers As Boolean
        Public Property BDPath As String
        Public Property CastImagesOnly As Boolean
        Public Property CertificationLang As String
        Public Property CheckUpdates As Boolean
        Public Property CleanDB As Boolean
        Public Property CleanDotFanartJPG As Boolean
        Public Property CleanExtraThumbs As Boolean
        Public Property CleanFanartJPG As Boolean
        Public Property CleanFolderJPG As Boolean
        Public Property CleanMovieFanartJPG As Boolean
        Public Property CleanMovieJPG As Boolean
        Public Property CleanMovieNameJPG As Boolean
        Public Property CleanMovieNFO As Boolean
        Public Property CleanMovieNFOB As Boolean
        Public Property CleanMovieTBN As Boolean
        Public Property CleanMovieTBNB As Boolean
        Public Property CleanPosterJPG As Boolean
        Public Property CleanPosterTBN As Boolean
        Public Property CleanWhitelistExts As List(Of String)
        Public Property CleanWhitelistVideo As Boolean
        Public Property DashTrailer As Boolean
        Public Property DeleteAllTrailers As Boolean
        Public Property DisplayAllSeason As Boolean
        Public Property DisplayMissingEpisodes As Boolean
        Public Property DisplayYear As Boolean
        Public Property DownloadTrailers As Boolean
        Public Property OrderDefault As Enums.Ordering
        Public Property EnableIFOScan As Boolean
        Public Property EpFanartHeight As Integer
        Public Property EpFanartQuality As Integer
        Public Property EpFanartWidth As Integer
        Public Property EpFilterCustom As List(Of String)
        Public Property EpisodeDashFanart As Boolean
        Public Property EpisodeDotFanart As Boolean
        Public Property EpisodeFanartCol As Boolean
        Public Property EpisodeJPG As Boolean
        Public Property EpisodeNfoCol As Boolean
        Public Property EpisodePosterCol As Boolean
        Public Property EpisodeTBN As Boolean
        Public Property EpLockPlot As Boolean
        Public Property EpLockRating As Boolean
        Public Property EpLockTitle As Boolean
        Public Property EpPosterHeight As Integer
        Public Property EpPosterQuality As Integer
        Public Property EpPosterWidth As Integer
        Public Property EpProperCase As Boolean
        Public Property ETHeight As Integer
        Public Property ETNative As Boolean
        Public Property ETPadding As Boolean
        Public Property ETWidth As Integer
        Public Property ExpertCleaner As Boolean
        Public Property FanartHeight As Integer
        Public Property FanartJPG As Boolean
        Public Property FanartPrefSizeOnly As Boolean
        Public Property FanartQuality As Integer
        Public Property FanartWidth As Integer
        Public Property Field250 As Boolean
        Public Property FieldCountry As Boolean
        Public Property FieldCast As Boolean
        Public Property FieldCert As Boolean
        Public Property FieldCrew As Boolean
        Public Property FieldDirector As Boolean
        Public Property FieldGenre As Boolean
        Public Property FieldMPAA As Boolean
        Public Property FieldMusic As Boolean
        Public Property FieldOutline() As Boolean
        Public Property FieldPlot() As Boolean
        Public Property FieldProducers() As Boolean
        Public Property FieldRating() As Boolean
        Public Property FieldRelease() As Boolean
        Public Property FieldRuntime() As Boolean
        Public Property FieldStudio() As Boolean
        Public Property FieldTagline() As Boolean
        Public Property FieldTitle() As Boolean
        Public Property FieldTrailer() As Boolean
        Public Property FieldVotes() As Boolean
        Public Property FieldWriters() As Boolean
        Public Property FieldYear() As Boolean
        Public Property FilterCustom() As List(Of String)
        Public Property FilterPanelState() As Boolean
        Public Property FlagLang() As String
        Public Property FolderJPG() As Boolean
        Public Property ForceTitle() As String
        Public Property FullCast() As Boolean
        Public Property FullCrew() As Boolean
        Public Property GenreFilter() As String
        Public Property GenreLimit() As Integer
        Public Property IgnoreLastScan() As Boolean
        Public Property InfoPanelAnim() As Boolean
        Public Property InfoPanelState() As Integer
        Public Property IsAllSBanner() As Boolean
        Public Property IsShowBanner() As Boolean
        Public Property Language() As String
        Public Property LevTolerance() As Integer
        Public Property LockGenre() As Boolean
        Public Property LockOutline() As Boolean
        Public Property LockPlot() As Boolean
        Public Property LockRating() As Boolean
        Public Property LockStudio() As Boolean
        Public Property LockTagline() As Boolean
        Public Property LockTitle() As Boolean
        Public Property LockTrailer() As Boolean
        Public Property LogErrors() As Boolean
        Public Property MarkNew() As Boolean
        Public Property MarkNewEpisodes() As Boolean
        Public Property MarkNewShows() As Boolean
        Public Property MetadataPerFileType() As List(Of MetadataPerType)
        Public Property MissingFilterExtras() As Boolean
        Public Property MissingFilterFanart() As Boolean
        Public Property MissingFilterNFO() As Boolean
        Public Property MissingFilterPoster() As Boolean
        Public Property MissingFilterSubs() As Boolean
        Public Property MissingFilterTrailer() As Boolean
        Public Property MovieExtraCol() As Boolean
        Public Property MovieFanartCol() As Boolean
        Public Property MovieInfoCol() As Boolean
        Public Property MovieJPG() As Boolean
        Public Property MovieNameDotFanartJPG() As Boolean
        Public Property MovieNameFanartJPG() As Boolean
        Public Property MovieNameJPG() As Boolean
        Public Property MovieNameMultiOnly() As Boolean
        Public Property MovieNameNFO() As Boolean
        Public Property MovieNameTBN() As Boolean
        Public Property MovieNFO() As Boolean
        Public Property MoviePosterCol() As Boolean
        Public Property MovieSubCol() As Boolean
        Public Property MovieTBN() As Boolean
        Public Property MovieTrailerCol() As Boolean
        Public Property NoDisplayFanart() As Boolean
        Public Property NoDisplayPoster() As Boolean
        Public Property NoEpFilters() As Boolean
        Public Property NoFilterEpisode() As Boolean
        Public Property NoFilters() As Boolean
        Public Property NoSaveImagesToNfo() As Boolean
        Public Property NoShowFilters() As Boolean
        Public Property NoStackExts() As List(Of String)
        Public Property NoTokens() As Boolean
        Public Property OnlyGetTVImagesForSelectedLanguage() As Boolean
        Public Property OnlyValueForCert() As Boolean
        Public Property OutlineForPlot() As Boolean
        Public Property OverwriteAllSPoster() As Boolean
        Public Property OverwriteEpFanart() As Boolean
        Public Property OverwriteEpPoster() As Boolean
        Public Property OverwriteFanart() As Boolean
        Public Property OverwriteNfo() As Boolean
        Public Property OverwritePoster() As Boolean
        Public Property OverwriteSeasonFanart() As Boolean
        Public Property OverwriteSeasonPoster() As Boolean
        Public Property OverwriteShowFanart() As Boolean
        Public Property OverwriteShowPoster() As Boolean
        Public Property OverwriteTrailer() As Boolean
        Public Property PersistImgCache() As Boolean
        Public Property PosterHeight() As Integer
        Public Property PosterJPG() As Boolean
        Public Property PosterPrefSizeOnly() As Boolean
        Public Property PosterQuality() As Integer
        Public Property PosterTBN() As Boolean
        Public Property PosterWidth() As Integer
        Public Property PreferredAllSBannerType() As Enums.ShowBannerType
        Public Property PreferredAllSPosterSize() As Enums.PosterSize
        Public Property PreferredEpFanartSize() As Enums.FanartSize
        Public Property PreferredFanartSize() As Enums.FanartSize
        Public Property PreferredPosterSize() As Enums.PosterSize
        Public Property PreferredSeasonFanartSize() As Enums.FanartSize
        Public Property PreferredSeasonPosterSize() As Enums.SeasonPosterType
        Public Property PreferredShowBannerType() As Enums.ShowBannerType
        Public Property PreferredShowFanartSize() As Enums.FanartSize
        Public Property PreferredShowPosterSize() As Enums.PosterSize
        Public Property PreferredTrailerQuality() As Enums.TrailerQuality
        Public Property ProperCase() As Boolean
        Public Property ProxyCreds() As NetworkCredential
        Public Property ProxyPort() As Integer
        Public Property ProxyURI() As String
        Public Property ResizeAllSPoster() As Boolean
        Public Property ResizeEpFanart() As Boolean
        Public Property ResizeEpPoster() As Boolean
        Public Property ResizeFanart() As Boolean
        Public Property ResizePoster() As Boolean
        Public Property ResizeSeasonFanart() As Boolean
        Public Property ResizeSeasonPoster() As Boolean
        Public Property ResizeShowFanart() As Boolean
        Public Property ResizeShowPoster() As Boolean
        Public Property RuntimeMask() As String
        Public Property ScanMediaInfo() As Boolean
        Public Property ScanOrderModify() As Boolean
        Public Property ScanTVMediaInfo() As Boolean
        Public Property ScraperEpActors() As Boolean
        Public Property ScraperEpAired() As Boolean
        Public Property ScraperEpCredits() As Boolean
        Public Property ScraperEpDirector() As Boolean
        Public Property ScraperEpEpisode() As Boolean
        Public Property ScraperEpPlot() As Boolean
        Public Property ScraperEpRating() As Boolean
        Public Property ScraperEpSeason() As Boolean
        Public Property ScraperEpTitle() As Boolean
        Public Property ScraperShowActors() As Boolean
        Public Property ScraperShowEGU() As Boolean
        Public Property ScraperShowGenre() As Boolean
        Public Property ScraperShowMPAA() As Boolean
        Public Property ScraperShowPlot() As Boolean
        Public Property ScraperShowPremiered() As Boolean
        Public Property ScraperShowRating() As Boolean
        Public Property ScraperShowStudio() As Boolean
        Public Property ScraperShowTitle() As Boolean
        Public Property SeasonAllJPG() As Boolean
        Public Property SeasonAllTBN() As Boolean
        Public Property SeasonDashFanart() As Boolean
        Public Property SeasonDotFanart() As Boolean
        Public Property SeasonFanartCol() As Boolean
        Public Property SeasonFanartHeight() As Integer
        Public Property SeasonFanartJPG() As Boolean
        Public Property SeasonFanartQuality() As Integer
        Public Property SeasonFanartWidth() As Integer
        Public Property SeasonFolderJPG() As Boolean
        Public Property SeasonNameJPG() As Boolean
        Public Property SeasonNameTBN() As Boolean
        Public Property SeasonPosterCol() As Boolean
        Public Property SeasonPosterHeight() As Integer
        Public Property SeasonPosterJPG() As Boolean
        Public Property SeasonPosterQuality() As Integer
        Public Property SeasonPosterTBN() As Boolean
        Public Property SeasonPosterWidth() As Integer
        Public Property SeasonX() As Boolean
        Public Property SeasonXX() As Boolean
        Public Property Sets() As List(Of String)
        Public Property ShowDashFanart() As Boolean
        Public Property ShowDims() As Boolean
        Public Property ShowDotFanart() As Boolean
        Public Property ShowFanartCol() As Boolean
        Public Property ShowFanartHeight() As Integer
        Public Property ShowFanartJPG() As Boolean
        Public Property ShowFanartQuality() As Integer
        Public Property ShowFanartWidth() As Integer
        Public Property ShowFilterCustom() As List(Of String)
        Public Property ShowFolderJPG() As Boolean
        Public Property ShowInfoPanelState() As Integer
        Public Property ShowJPG() As Boolean
        Public Property ShowLockGenre() As Boolean
        Public Property ShowLockPlot() As Boolean
        Public Property ShowLockRating() As Boolean
        Public Property ShowLockStudio() As Boolean
        Public Property ShowLockTitle() As Boolean
        Public Property ShowNfoCol() As Boolean
        Public Property ShowPosterCol() As Boolean
        Public Property ShowPosterHeight() As Integer
        Public Property ShowPosterJPG() As Boolean
        Public Property ShowBannerJPG() As Boolean
        Public Property ShowPosterQuality() As Integer
        Public Property ShowPosterTBN() As Boolean
        Public Property ShowPosterWidth() As Integer
        Public Property ShowProperCase() As Boolean
        Public Property ShowRatingRegion() As String
        Public Property ShowTBN() As Boolean
        Public Property SingleScrapeImages() As Boolean
        Public Property SingleScrapeTrailer() As Boolean
        Public Property SkipLessThan() As Integer
        Public Property SkipStackSizeCheck() As Boolean
        Public Property SkipLessThanEp() As Integer
        Public Property SortBeforeScan() As Boolean
        Public Property SortPath() As String
        Public Property SortTokens() As List(Of String)
        Public Property SourceFromFolder() As Boolean
        Public Property SplitterPanelState() As Integer
        Public Property ShowSplitterPanelState() As Integer
        Public Property SeasonSplitterPanelState() As Integer
        Public Property TrailerTimeout() As Integer
        Public Property TVCleanDB() As Boolean
        Public Property TVDBLanguage() As String
        Public Property TVDBLanguages() As List(Of Containers.TVLanguage)
        Public Property TVFlagLang() As String
        Public Property TVIgnoreLastScan() As Boolean
        Public Property TVMetadataperFileType() As List(Of MetadataPerType)
        Public Property TVScanOrderModify() As Boolean
        Public Property TVShowRegexes() As List(Of TVShowRegEx)
        Public Property TVUpdateTime() As Enums.TVUpdateTime
        Public Property UpdaterTrailers() As Boolean
        Public Property UpdaterTrailersNoDownload() As Boolean
        Public Property UseCertForMPAA() As Boolean
        Public Property UseETasFA() As Boolean
        Public Property UseImgCache() As Boolean
        Public Property UseImgCacheUpdaters() As Boolean
        Public Property UseMIDuration() As Boolean
        Public Property ValidExts() As List(Of String)
        Public Property Version() As String
        Public Property VideoTSParent() As Boolean
        Public Property WindowLoc() As Point
        Public Property WindowSize() As Size
        Public Property WindowState() As FormWindowState
        Public Property YAMJSetsCompatible() As Boolean
        Public Property Username() As String
        Public Property Password() As String

#End Region 'Properties

#Region "Methods"
        Public Function AllSeasonPosterEnabled() As Boolean
            Return Me._SeasonAllTBN OrElse Me._SeasonAllJPG
        End Function

        Public Sub Clear()
            Me._Version = String.Empty
            Me._FilterCustom = New List(Of String)
            Me._ShowFilterCustom = New List(Of String)
            Me._EpFilterCustom = New List(Of String)
            Me._ForceTitle = String.Empty
            Me._CertificationLang = String.Empty
            Me._UseCertForMPAA = False
            Me._ShowRatingRegion = "usa"
            Me._AskCheckboxScrape = True
            Me._ScanMediaInfo = True
            Me._ScanTVMediaInfo = True
            Me._FullCast = True     'emm-r
            Me._FullCrew = False
            Me._CastImagesOnly = False
            Me._MoviePosterCol = False
            Me._MovieFanartCol = False
            Me._MovieInfoCol = False
            Me._MovieTrailerCol = False
            Me._MovieSubCol = False
            Me._MovieExtraCol = False
            Me._CleanFolderJPG = False
            Me._CleanMovieTBN = False
            Me._CleanMovieTBNB = False
            Me._CleanFanartJPG = False
            Me._CleanMovieFanartJPG = False
            Me._CleanMovieNFO = False
            Me._CleanMovieNFOB = False
            Me._CleanPosterTBN = False
            Me._CleanPosterJPG = False
            Me._CleanMovieJPG = False
            Me._CleanDotFanartJPG = False
            Me._CleanMovieNameJPG = False
            Me._CleanExtraThumbs = False
            Me._ExpertCleaner = False
            Me._CleanWhitelistVideo = False
            Me._CleanWhitelistExts = New List(Of String)
            Me.PreferredPosterSize = Enums.PosterSize.Xlrg
            Me.PreferredFanartSize = Enums.FanartSize.Lrg
            Me.ShowBannerJPG = True
            Me.PreferredShowBannerType = Enums.ShowBannerType.Graphical
            Me.PreferredShowPosterSize = Enums.PosterSize.Xlrg
            Me._IsAllSBanner = False
            Me._PreferredAllSBannerType = Enums.ShowBannerType.Graphical
            Me.PreferredAllSPosterSize = Enums.PosterSize.Xlrg
            Me.PreferredShowFanartSize = Enums.FanartSize.Lrg
            Me.PreferredEpFanartSize = Enums.FanartSize.Lrg
            Me.PreferredSeasonPosterSize = Enums.SeasonPosterType.Poster
            Me.PreferredSeasonFanartSize = Enums.FanartSize.Lrg
            Me._AutoET = False
            Me._AutoETSize = Enums.FanartSize.Lrg
            Me._FanartPrefSizeOnly = False
            Me._PosterPrefSizeOnly = False
            Me._PosterQuality = 0
            Me._FanartQuality = 0
            Me._OverwritePoster = True
            Me._OverwriteFanart = True
            Me._ShowPosterQuality = 0
            Me._ShowFanartQuality = 0
            Me._OverwriteShowPoster = True
            Me._OverwriteShowFanart = True
            Me._AllSPosterQuality = 0
            Me._OverwriteAllSPoster = True
            Me._EpPosterQuality = 0
            Me._EpFanartQuality = 0
            Me._OverwriteEpPoster = True
            Me._OverwriteEpFanart = True
            Me._SeasonPosterQuality = 0
            Me._SeasonFanartQuality = 0
            Me._OverwriteSeasonPoster = True
            Me._OverwriteSeasonFanart = True
            Me._LogErrors = True
            Me._ProperCase = True
            Me._ShowProperCase = True
            Me._EpProperCase = True
            Me._OverwriteNfo = False
            Me._OverwriteNfo = False
            Me._OverwriteNfo = False
            Me._ValidExts = New List(Of String)
            Me._NoStackExts = New List(Of String)
            Me._MovieTBN = True
            Me._MovieNameTBN = True
            Me._MovieJPG = False
            Me._MovieNameJPG = False
            Me._PosterTBN = False
            Me._PosterJPG = False
            Me._FolderJPG = False
            Me._FanartJPG = True
            Me._MovieNameFanartJPG = True
            Me._MovieNameDotFanartJPG = False
            Me._MovieNFO = True
            Me._MovieNameNFO = True
            Me._MovieNameMultiOnly = False
            Me._DashTrailer = True
            Me._VideoTSParent = False
            Me._LockPlot = False
            Me._LockOutline = False
            Me._LockTitle = False
            Me._LockTagline = False
            Me._LockRating = False
            Me._LockStudio = False
            Me._LockRating = False
            Me._LockTrailer = False
            Me._SingleScrapeImages = True
            Me._MarkNew = False
            Me._ResizeFanart = False
            Me._FanartHeight = 0
            Me._FanartWidth = 0
            Me._ResizePoster = False
            Me._PosterHeight = 0
            Me._PosterWidth = 0
            Me._ResizeShowFanart = False
            Me._ShowFanartHeight = 0
            Me._ShowFanartWidth = 0
            Me._ResizeShowPoster = False
            Me._ShowPosterHeight = 0
            Me._ShowPosterWidth = 0
            Me._ResizeAllSPoster = False
            Me._AllSPosterHeight = 0
            Me._AllSPosterWidth = 0
            Me._ResizeEpFanart = False
            Me._EpFanartHeight = 0
            Me._EpFanartWidth = 0
            Me._ResizeEpPoster = False
            Me._EpPosterHeight = 0
            Me._EpPosterWidth = 0
            Me._ResizeSeasonFanart = False
            Me._SeasonFanartHeight = 0
            Me._SeasonFanartWidth = 0
            Me._ResizeSeasonPoster = False
            Me._SeasonPosterHeight = 0
            Me._SeasonPosterWidth = 0
            Me._AutoThumbs = 0
            Me._AutoThumbsNoSpoilers = False
            Me._WindowLoc = New Point(If(Screen.PrimaryScreen.WorkingArea.Width <= 1024, 0, Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Width - 1024) / 2)), If(Screen.PrimaryScreen.WorkingArea.Height <= 768, 0, Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Height - 768) / 2)))
            Me._WindowSize = New Size(1024, 768)
            Me._WindowState = FormWindowState.Normal
            Me._InfoPanelState = 0
            Me._ShowInfoPanelState = 0
            Me._FilterPanelState = False
            Me._InfoPanelAnim = False   'emm-r
            Me._CheckUpdates = True
            Me._BDPath = String.Empty
            Me._AutoBD = False
            Me._UseMIDuration = False
            Me._RuntimeMask = "<m>"     'emm-r
            Me._GenreFilter = "English"
            Me._UseETasFA = False
            Me._UseImgCache = False
            Me.UseImgCacheUpdaters = False
            Me.PersistImgCache = False
            Me._SkipLessThan = 0
            Me._SkipStackSizeCheck = False
            Me._SkipLessThanEp = 0
            Me._DownloadTrailers = False
            Me.PreferredTrailerQuality = Enums.TrailerQuality.HD1080p
            Me._UpdaterTrailers = False
            Me._UpdaterTrailersNoDownload = False
            Me._SingleScrapeTrailer = False
            Me._TrailerTimeout = 2
            Me._OverwriteTrailer = False
            Me._DeleteAllTrailers = False
            Me._Sets = New List(Of String)
            Me._NoSaveImagesToNfo = False
            Me._ShowDims = False
            Me._NoDisplayPoster = False
            Me._NoDisplayFanart = False
            Me._OutlineForPlot = False
            Me._SortPath = String.Empty
            Me._AllwaysDisplayGenresText = False
            Me._DisplayYear = False
            Me._SortTokens = New List(Of String)
            Me._ETNative = True
            Me._ETWidth = 0
            Me._ETHeight = 0
            Me._ETPadding = False
            Me._NoFilters = False
            Me._NoShowFilters = False
            Me._NoEpFilters = False
            Me._NoTokens = False
            Me._LevTolerance = 0
            Me._AutoDetectVTS = True
            Me._FlagLang = String.Empty
            Me._TVFlagLang = String.Empty
            Me._Language = "English_(en_US)"
            Me._FieldTitle = True
            Me._FieldYear = True
            Me._FieldMPAA = True
            Me._FieldCert = True
            Me._FieldRelease = True
            Me._FieldRuntime = True
            Me._FieldRating = True
            Me._FieldVotes = True
            Me._FieldStudio = True
            Me._FieldGenre = True
            Me._FieldTrailer = True
            Me._FieldTagline = True
            Me._FieldOutline = True
            Me._FieldPlot = True
            Me._FieldCast = True
            Me._FieldDirector = True
            Me._FieldWriters = True
            Me._FieldProducers = True
            Me._FieldMusic = True
            Me._FieldCrew = True
            Me._Field250 = True
            Me._FieldCountry = True
            Me._GenreLimit = 0
            Me._ActorLimit = 0
            Me._MissingFilterPoster = True
            Me._MissingFilterFanart = True
            Me._MissingFilterNFO = True
            Me._MissingFilterTrailer = True
            Me._MissingFilterSubs = True
            Me._MissingFilterExtras = True
            Me._MetadataPerFileType = New List(Of MetadataPerType)
            Me.TVMetadataperFileType = New List(Of MetadataPerType)
            Me._EnableIFOScan = True
            Me._YAMJSetsCompatible = False
            Me._CleanDB = True
            Me._IgnoreLastScan = True
            Me._TVCleanDB = True
            Me._TVIgnoreLastScan = True
            Me._TVShowRegexes = New List(Of TVShowRegEx)
            Me._SeasonAllTBN = True
            Me._SeasonAllJPG = False
            Me._ShowFolderJPG = True
            Me._ShowTBN = False
            Me._ShowJPG = False
            Me._ShowPosterTBN = False
            Me._ShowPosterJPG = False
            Me._ShowBannerJPG = False
            Me._ShowFanartJPG = True
            Me._ShowDashFanart = False
            Me._ShowDotFanart = False
            Me._SeasonXX = True
            Me._SeasonX = False
            Me._SeasonPosterTBN = False
            Me._SeasonPosterJPG = False
            Me._SeasonNameTBN = False
            Me._SeasonNameJPG = False
            Me._SeasonFolderJPG = False
            Me._SeasonFanartJPG = False
            Me._SeasonDashFanart = False
            Me._SeasonDotFanart = False
            Me._EpisodeTBN = True
            Me._EpisodeJPG = False
            Me._EpisodeDashFanart = False
            Me._EpisodeDotFanart = False
            Me._ShowPosterCol = False
            Me._ShowFanartCol = False
            Me._ShowNfoCol = False
            Me._SeasonPosterCol = False
            Me._SeasonFanartCol = True
            Me._EpisodePosterCol = False
            Me._EpisodeFanartCol = True
            Me._EpisodeNfoCol = False
            Me._ProxyURI = String.Empty
            Me._ProxyPort = -1
            Me.ProxyCreds = New NetworkCredential
            Me._SourceFromFolder = False
            Me._SortBeforeScan = False
            Me._TVDBLanguage = "en"
            Me._TVDBLanguages = New List(Of Containers.TVLanguage)
            Me._ScanOrderModify = False
            Me._TVScanOrderModify = False
            Me._TVUpdateTime = Enums.TVUpdateTime.Week
            Me._NoFilterEpisode = True
            Me.OnlyGetTVImagesForSelectedLanguage = True
            Me._AlwaysGetEnglishTVImages = True
            Me._DisplayMissingEpisodes = False
            Me._ShowLockTitle = False
            Me._ShowLockPlot = False
            Me._ShowLockRating = False
            Me._ShowLockGenre = False
            Me._ShowLockStudio = False
            Me._EpLockTitle = False
            Me._EpLockPlot = False
            Me._EpLockRating = False
            Me._ScraperShowTitle = True
            Me._ScraperShowEGU = True
            Me._ScraperShowGenre = True
            Me._ScraperShowMPAA = True
            Me._ScraperShowPlot = True
            Me._ScraperShowPremiered = True
            Me._ScraperShowRating = True
            Me._ScraperShowStudio = True
            Me._ScraperShowActors = True
            Me._ScraperEpTitle = True
            Me._ScraperEpSeason = True
            Me._ScraperEpEpisode = True
            Me._ScraperEpAired = True
            Me._ScraperEpRating = True
            Me._ScraperEpPlot = True
            Me._ScraperEpDirector = True
            Me._ScraperEpCredits = True
            Me._ScraperEpActors = True
            Me._DisplayAllSeason = True
            Me._MarkNewShows = False
            Me._MarkNewEpisodes = False
            Me._OrderDefault = Enums.Ordering.Standard
            Me._OnlyValueForCert = False
            Me._Username = String.Empty
            Me._Password = String.Empty
        End Sub

        Public Function EpisodeFanartEnabled() As Boolean
            Return Me._EpisodeDashFanart OrElse Me._EpisodeDotFanart
        End Function

        Public Sub Load()
            Try
                Dim xmlSerial As New XmlSerializer(GetType(Settings))

                If File.Exists(Path.Combine(Functions.AppPath, "Settings.xml")) Then
                    Dim strmReader As New StreamReader(Path.Combine(Functions.AppPath, "Settings.xml"))
                    Master.eSettings = DirectCast(xmlSerial.Deserialize(strmReader), Settings)
                    strmReader.Close()
                Else
                    Master.eSettings = New Settings
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                Master.eSettings = New Settings
            End Try

            If Not Master.eSettings.Version = String.Format("r{0}", My.Application.Info.Version.Revision) Then
                SetDefaultsForLists(Enums.DefaultType.All, False)
            End If
        End Sub

        Public Sub Save()
            Try
                Dim xmlSerial As New XmlSerializer(GetType(Settings))
                Dim xmlWriter As New StreamWriter(Path.Combine(Functions.AppPath, "Settings.xml"))
                xmlSerial.Serialize(xmlWriter, Master.eSettings)
                xmlWriter.Close()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Public Function SeasonFanartEnabled() As Boolean
            Return Master.eSettings.SeasonFanartJPG OrElse Master.eSettings.SeasonDashFanart OrElse Master.eSettings.SeasonDotFanart
        End Function

        Public Sub SetDefaultsForLists(ByVal Type As Enums.DefaultType, ByVal Force As Boolean)
            If (Type = Enums.DefaultType.All OrElse Type = Enums.DefaultType.MovieFilters) AndAlso (Force OrElse (Master.eSettings.FilterCustom.Count <= 0 AndAlso Not Master.eSettings.NoFilters)) Then
                Master.eSettings.FilterCustom.Clear()
                Master.eSettings.FilterCustom.Add("[\W_]\(?\d{4}\)?.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]dvd.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]720.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]1080.*") 'not really needed because the year title will catch this one, but just in case a user doesn't want the year filter but wants to filter 1080
                Master.eSettings.FilterCustom.Add("(?i)[\W_]ac3.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]dts.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]divx.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]xvid.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]extended.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]hd(tv)?.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]unrated.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]uncut.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]\[offline\].*")
                Master.eSettings.FilterCustom.Add("(?i)[\W_]ntsc.*")
                Master.eSettings.FilterCustom.Add("[\W_]PAL[\W_]?.*")
                Master.eSettings.FilterCustom.Add("\.[->] ")
            End If

            If (Type = Enums.DefaultType.All OrElse Type = Enums.DefaultType.ShowFilters) AndAlso (Force OrElse (Master.eSettings.ShowFilterCustom.Count <= 0 AndAlso Not Master.eSettings.NoShowFilters)) Then
                Master.eSettings.ShowFilterCustom.Clear()
                Master.eSettings.ShowFilterCustom.Add("[\W_]\(?\d{4}\)?.*")
                'would there ever be season or episode info in the show folder name??
                'Master.eSettings.ShowFilterCustom.Add("(?i)([\W_]+\s?)?s[0-9]+[\W_]*e[0-9]+(\])*")
                'Master.eSettings.ShowFilterCustom.Add("(?i)([\W_]+\s?)?[0-9]+x[0-9]+(\])*")
                'Master.eSettings.ShowFilterCustom.Add("(?i)([\W_]+\s?)?s(eason)?[\W_]*[0-9]+(\])*")
                'Master.eSettings.ShowFilterCustom.Add("(?i)([\W_]+\s?)?e(pisode)?[\W_]*[0-9]+(\])*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]dvd.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]720.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]1080.*") 'not really needed because the year title will catch this one, but just in case a user doesn't want the year filter but wants to filter 1080
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]ac3.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]dts.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]divx.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]xvid.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]extended.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]hd(tv)?.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]unrated.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]uncut.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]\[offline\].*")
                Master.eSettings.ShowFilterCustom.Add("(?i)[\W_]ntsc.*")
                Master.eSettings.ShowFilterCustom.Add("[\W_]PAL[\W_]?.*")
                Master.eSettings.ShowFilterCustom.Add("\.[->] ")
            End If

            If (Type = Enums.DefaultType.All OrElse Type = Enums.DefaultType.EpFilters) AndAlso (Force OrElse (Master.eSettings.EpFilterCustom.Count <= 0 AndAlso Not Master.eSettings.NoEpFilters)) Then
                Master.eSettings.EpFilterCustom.Clear()
                Master.eSettings.EpFilterCustom.Add("[\W_]\(?\d{4}\)?.*")
                Master.eSettings.EpFilterCustom.Add("(?i)([\W_]+\s?)?s[0-9]+[\W_]*([-e][0-9]+)+(\])*")
                Master.eSettings.EpFilterCustom.Add("(?i)([\W_]+\s?)?[0-9]+([-x][0-9]+)+(\])*")
                Master.eSettings.EpFilterCustom.Add("(?i)([\W_]+\s?)?s(eason)?[\W_]*[0-9]+(\])*")
                Master.eSettings.EpFilterCustom.Add("(?i)([\W_]+\s?)?e(pisode)?[\W_]*[0-9]+(\])*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]dvd.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]720.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]1080.*") 'not really needed because the year title will catch this one, but just in case a user doesn't want the year filter but wants to filter 1080
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]ac3.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]dts.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]divx.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]xvid.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]extended.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]hd(tv)?.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]unrated.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]uncut.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]\[offline\].*")
                Master.eSettings.EpFilterCustom.Add("(?i)[\W_]ntsc.*")
                Master.eSettings.EpFilterCustom.Add("[\W_]PAL[\W_]?.*")
                Master.eSettings.EpFilterCustom.Add("\.[->] ")
            End If

            If Type = Enums.DefaultType.All AndAlso Master.eSettings.SortTokens.Count <= 0 AndAlso Not Master.eSettings.NoTokens Then
                Master.eSettings.SortTokens.Add("the[\W_]")
                Master.eSettings.SortTokens.Add("a[\W_]")
                Master.eSettings.SortTokens.Add("an[\W_]")
            End If

            If (Type = Enums.DefaultType.All OrElse Type = Enums.DefaultType.ValidExts) AndAlso (Force OrElse Master.eSettings.ValidExts.Count <= 0) Then
                Master.eSettings.ValidExts.Clear()
                Master.eSettings.ValidExts.AddRange(Strings.Split(".avi,.divx,.mkv,.iso,.mpg,.mp4,.mpeg,.wmv,.wma,.mov,.mts,.m2t,.img,.dat,.bin,.cue,.ifo,.vob,.dvb,.evo,.asf,.asx,.avs,.nsv,.ram,.ogg,.ogm,.ogv,.flv,.swf,.nut,.viv,.rar,.m2ts,.dvr-ms,.ts,.m4v,.rmvb", ","))
            End If

            If (Type = Enums.DefaultType.All OrElse Type = Enums.DefaultType.ShowRegex) AndAlso (Force OrElse Master.eSettings.TVShowRegexes.Count <= 0) Then
                Master.eSettings.TVShowRegexes.Clear()
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 0, .SeasonRegex = "(s(eason[\W_]*)?(?<season>[0-9]+))([\W_]*(\.?(-|(e(pisode[\W_]*)?))[0-9]+)+)?", .SeasonFromDirectory = False, .EpisodeRegex = "(-|(e(pisode[\W_]*)?))(?<episode>[0-9]+)", .EpisodeRetrieve = EpRetrieve.FromSeasonResult})
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 1, .SeasonRegex = "(([0-9]{4}-[0-9]{2}(-[0-9]{2})?)|([0-9]{2}-[0-9]{2}-[0-9]{4})|((?<season>[0-9]+)([x-][0-9]+)+))", .SeasonFromDirectory = False, .EpisodeRegex = "[x-](?<episode>[0-9]+)", .EpisodeRetrieve = EpRetrieve.FromSeasonResult})
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 2, .SeasonRegex = "(([0-9]{4}-[0-9]{2}(-[0-9]{2})?)|([0-9]{2}-[0-9]{2}-[0-9]{4})|((?<season>[0-9]+)(-?[0-9]{2,})+(?![0-9])))", .SeasonFromDirectory = False, .EpisodeRegex = "(\([0-9]{4}\))|((([0-9]+|-)(?<episode>[0-9]{2,})))", .EpisodeRetrieve = EpRetrieve.FromSeasonResult})
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 3, .SeasonRegex = "^(?<season>specials?)$", .SeasonFromDirectory = True, .EpisodeRegex = "[^a-zA-Z]e(pisode[\W_]*)?(?<episode>[0-9]+)", .EpisodeRetrieve = EpRetrieve.FromFilename})
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 4, .SeasonRegex = "^(s(eason)?)?[\W_]*(?<season>[0-9]+)$", .SeasonFromDirectory = True, .EpisodeRegex = "[^a-zA-Z]e(pisode[\W_]*)?(?<episode>[0-9]+)", .EpisodeRetrieve = EpRetrieve.FromFilename})
                Master.eSettings.TVShowRegexes.Add(New TVShowRegEx With {.ID = 5, .SeasonRegex = "[^\w]s(eason)?[\W_]*(?<season>[0-9]+)", .SeasonFromDirectory = True, .EpisodeRegex = "[^a-zA-Z]e(pisode[\W_]*)?(?<episode>[0-9]+)", .EpisodeRetrieve = EpRetrieve.FromFilename})
            End If
        End Sub

#End Region 'Methods

#Region "Nested Types"

        Public Class MetadataPerType

#Region "Fields"

            Private _filetype As String
            Private _metadata As MediaInfo.Fileinfo

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property FileType() As String
                Get
                    Return Me._filetype
                End Get
                Set(ByVal value As String)
                    Me._filetype = value
                End Set
            End Property

            Public Property MetaData() As MediaInfo.Fileinfo
                Get
                    Return Me._metadata
                End Get
                Set(ByVal value As MediaInfo.Fileinfo)
                    Me._metadata = value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._filetype = String.Empty
                Me._metadata = New MediaInfo.Fileinfo
            End Sub

#End Region 'Methods

        End Class

        Public Class TVShowRegEx

#Region "Fields"

            Private _episoderegex As String
            Private _episoderetrieve As EpRetrieve
            Private _id As Integer
            Private _seasonfromdirectory As Boolean
            Private _seasonregex As String

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property EpisodeRegex() As String
                Get
                    Return Me._episoderegex
                End Get
                Set(ByVal value As String)
                    Me._episoderegex = value
                End Set
            End Property

            Public Property EpisodeRetrieve() As EpRetrieve
                Get
                    Return Me._episoderetrieve
                End Get
                Set(ByVal value As EpRetrieve)
                    Me._episoderetrieve = value
                End Set
            End Property

            Public Property ID() As Integer
                Get
                    Return _id
                End Get
                Set(ByVal value As Integer)
                    _id = value
                End Set
            End Property

            Public Property SeasonFromDirectory() As Boolean
                Get
                    Return Me._seasonfromdirectory
                End Get
                Set(ByVal value As Boolean)
                    Me._seasonfromdirectory = value
                End Set
            End Property

            Public Property SeasonRegex() As String
                Get
                    Return Me._seasonregex
                End Get
                Set(ByVal value As String)
                    Me._seasonregex = value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._id = -1
                Me._seasonregex = String.Empty
                Me._seasonfromdirectory = True
                Me._episoderegex = String.Empty
                Me._episoderetrieve = EpRetrieve.FromSeasonResult
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class
End Namespace