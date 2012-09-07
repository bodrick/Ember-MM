Imports TechNuts.MediaTags
Imports TechNuts.ScraperXML
Imports EmberMediaManger.API

Namespace Classes
    Public Class ScraperFunctions
        Public Shared Function GetTVEpisodeDetails(tvEpisode As Model.TVEp) As TechNuts.MediaTags.TVEpisodeTag
            Dim tempList = Master.ScraperMan.GetTvShowResults("The TVDB", tvEpisode.TVShow.Title, "")
            Dim show As TechNuts.MediaTags.TvShowTag = Master.ScraperMan.GetTvShowDetails(tempList(0))
            Dim episodeList As List(Of ScrapeResultsEntity) = Master.ScraperMan.GetEpisodeList("The TVDB", show.EpisodeGuide)
            Dim episode = Master.ScraperMan.GetEpisodeDetails((From r In episodeList Where r.EpisodeNumber = tvEpisode.Episode And r.Season = tvEpisode.Season).SingleOrDefault())
            Return episode
        End Function

        Public Shared Function GetTVSeasonPosterUrls(tvSeason As Model.TVSeason) As List(Of String)
            Dim tempList = Master.ScraperMan.GetTvShowResults("The TVDB", tvSeason.TVShow.Title, "")
            Dim show As TechNuts.MediaTags.TvShowTag = Master.ScraperMan.GetTvShowDetails(tempList(0))
            Dim returnImage = From r In show.Thumbs Where r.Season = tvSeason.Season.ToString Select r.Thumb
            Return returnImage.ToList()
        End Function

        Public Shared Function GetTVPosterUrls(tvSeason As Model.TVShow) As List(Of Thumbnail)
            Dim tempList = Master.ScraperMan.GetTvShowResults("The TVDB", tvSeason.Title, "")
            Dim show As TechNuts.MediaTags.TvShowTag = Master.ScraperMan.GetTvShowDetails(tempList(0))
            Dim returnImage = From r In show.Thumbs Where r.Type = ""
            Return returnImage.ToList()
        End Function

        Public Shared Function GetTVAllSeasonsPosterUrls(tvSeason As Model.TVShow) As List(Of String)
            Dim tempList = Master.ScraperMan.GetTvShowResults("The TVDB", tvSeason.Title, "")
            Dim show As TechNuts.MediaTags.TvShowTag = Master.ScraperMan.GetTvShowDetails(tempList(0))
            Dim returnImage = From r In show.Thumbs Where r.Type = "" And r.Season <= 0 Select r.Thumb
            Return returnImage.ToList()
        End Function

        Public Shared Function GetTVFanart(tvSeason As Model.TVShow) As List(Of String)
            Dim tempList = Master.ScraperMan.GetTvShowResults("The TVDB", tvSeason.Title, "")
            Dim show As TechNuts.MediaTags.TvShowTag = Master.ScraperMan.GetTvShowDetails(tempList(0))
            Dim returnImage = From r In show.Fanart.Thumbs Select show.Fanart.Url + r.Preview
            Return returnImage.ToList()
        End Function
    End Class
End Namespace