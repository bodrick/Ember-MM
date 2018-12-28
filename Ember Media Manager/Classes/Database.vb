Imports System.Data.Entity

Namespace Classes
    Public Class Database
        Public Shared Function LoadAllTVShows() As List(Of Model.TVShow)
            Try
                Using db As New Model.MediaEntities
                    Dim allShows = From r In db.TVShows.OrderBy(Function(f) f.Title)
                    Return allShows.ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function LoadTVShowSeasons(ID As Long) As List(Of Model.TVSeason)
            Try
                Using db As New Model.MediaEntities
                    Dim allSeasons = From r In db.TVSeasons Where r.TVShowID = ID And r.Season <> 999 Select r Order By r.Season
                    Return allSeasons.ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function LoadTVShowEpisodes(ID As Long, Season As Long) As List(Of Model.TVEp)
            Try
                Using db As New Model.MediaEntities
                    Dim allEpisodes = From r In db.TVEps.Include("TVEpPath") Where r.TVShowID = ID And r.Season = Season Select r Order By r.Episode
                    Return allEpisodes.ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVShowEpisode(episodeId As Long) As Model.TVEp
            Try
                Using db As New Model.MediaEntities
                    Dim tvEpObject = (From r In db.TVEps Where r.ID = episodeId).FirstOrDefault()
                    db.Entry(tvEpObject).Reference("TVShow").Load()
                    db.Entry(tvEpObject).Reference("TVEpPath").Load()
                    Return tvEpObject
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVShowSeason(TVShowID As Long, Season As Long) As Model.TVSeason
            Try
                Using db As New Model.MediaEntities
                    Dim tvSeasonObject = (From r In db.TVSeasons Where r.TVShowID = TVShowID And r.Season = Season).FirstOrDefault()
                    db.Entry(tvSeasonObject).Reference("TVShow").Load()
                    Return tvSeasonObject
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function LoadAllMovies() As List(Of Model.Movie)
            Try
                Using db As New Model.MediaEntities
                    Dim allMovies = From r In db.Movies.OrderBy(Function(f) f.Title)
                    Return allMovies.ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetMovieActors(ID As Long) As List(Of Model.MoviesActor)
            Try
                Using db As New Model.MediaEntities
                    Dim allActors = From r In db.MoviesActors.Include("Actor") Where r.MovieID = ID
                    Return allActors.ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVShowCount() As Integer
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVShows).Count()
                End Using
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Shared Function GetTVEpsCount() As Integer
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVEps Where r.Missing = False).Count()
                End Using
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Shared Function GetTVAllSeasonPath(ShowID As Integer) As String
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVSeasons Where r.Season = 999 And r.TVShowID = ShowID).SingleOrDefault().PosterPath
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVShowActors(ShowID As Integer) As List(Of Model.TVShowActor)
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVShowActors.Include("Actor") Where r.TVShowID = ShowID).ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetMovieActors(MovieID As Integer) As List(Of Model.MoviesActor)
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.MoviesActors.Include("Actor") Where r.MovieID = MovieID).ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVShow(ShowID As Integer) As Model.TVShow
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVShows Where r.ID = ShowID).SingleOrDefault()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVEpActors(TVEpID As Integer) As List(Of Model.TVEpActor)
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVEpActors.Include("Actor") Where r.TVEpID = TVEpID).ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Sub SaveMovie(movieObject As Model.Movie, state As EntityState)
            Try
                Using db As New Model.MediaEntities
                    db.Entry(movieObject).State = state
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub SaveTVShow(tvShowObject As Model.TVShow, state As EntityState)
            Try
                Using db As New Model.MediaEntities
                    db.Entry(tvShowObject).State = state
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub SaveTVSeason(tvSeasonObject As Model.TVSeason, state As EntityState)
            Try
                Using db As New Model.MediaEntities
                    db.Entry(tvSeasonObject).State = state
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub SaveTVEp(tvEpObject As Model.TVEp, state As EntityState)
            Try
                Using db As New Model.MediaEntities
                    db.Entry(tvEpObject).State = state
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub LockTVSeason(tvSeasonObject As Model.TVSeason)
            Try
                Using db As New Model.MediaEntities
                    tvSeasonObject.Lock = Not tvSeasonObject.Lock
                    db.Entry(tvSeasonObject).Reference("TVEps").Load()
                    For Each tvEpObject In tvSeasonObject.TVEps
                        tvEpObject.Lock = tvSeasonObject.Lock
                        db.Entry(tvEpObject).State = EntityState.Modified
                    Next
                    db.Entry(tvSeasonObject).State = EntityState.Modified
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub LockTVShow(tvShowObject As Model.TVShow)
            Try
                Using db As New Model.MediaEntities
                    tvShowObject.Lock = Not tvShowObject.Lock
                    db.Entry(tvShowObject).Reference("TVSeasons").Load()
                    For Each tvSeasonObject In tvShowObject.TVSeasons
                        db.Entry(tvSeasonObject).Reference("TVEps").Load()
                        For Each tvEpObject In tvSeasonObject.TVEps
                            tvEpObject.Lock = tvShowObject.Lock
                            db.Entry(tvEpObject).State = EntityState.Modified
                        Next
                        tvSeasonObject.Lock = tvShowObject.Lock
                        db.Entry(tvSeasonObject).State = EntityState.Modified
                    Next
                    db.Entry(tvShowObject).State = EntityState.Modified
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub MarkTVSeason(tvSeasonObject As Model.TVSeason)
            Try
                Using db As New Model.MediaEntities
                    tvSeasonObject.Mark = Not tvSeasonObject.Mark
                    db.Entry(tvSeasonObject).Reference("TVEps").Load()
                    For Each tvEpObject In tvSeasonObject.TVEps
                        tvEpObject.Mark = tvSeasonObject.Mark
                        db.Entry(tvEpObject).State = EntityState.Modified
                    Next
                    db.Entry(tvSeasonObject).State = EntityState.Modified
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub MarkTVShow(tvShowObject As Model.TVShow)
            Try
                Using db As New Model.MediaEntities
                    tvShowObject.Mark = Not tvShowObject.Mark
                    db.Entry(tvShowObject).Reference("TVSeasons").Load()
                    For Each tvSeasonObject In tvShowObject.TVSeasons
                        db.Entry(tvSeasonObject).Reference("TVEps").Load()
                        For Each tvEpObject In tvSeasonObject.TVEps
                            tvEpObject.Mark = tvShowObject.Mark
                            db.Entry(tvEpObject).State = EntityState.Modified
                        Next
                        tvSeasonObject.Mark = tvShowObject.Mark
                        db.Entry(tvSeasonObject).State = EntityState.Modified
                    Next
                    db.Entry(tvShowObject).State = EntityState.Modified
                    db.SaveChanges()
                End Using
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function GetMovieSources() As List(Of Model.Source)
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.Sources).ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetTVSources() As List(Of Model.TVSource)
            Try
                Using db As New Model.MediaEntities
                    Return (From r In db.TVSources).ToList()
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetMovie(moviePath As String) As Model.Movie
            Try
                Using db As New Model.MediaEntities
                    Dim movieObject = (From r In db.Movies Where r.MoviePath = moviePath).FirstOrDefault()
                    db.Entry(movieObject).Reference("MoviesActors").Load()
                    db.Entry(movieObject).Reference("MoviesAStreams").Load()
                    db.Entry(movieObject).Reference("MoviesVStreams").Load()
                    db.Entry(movieObject).Reference("MoviesSubs").Load()
                    db.Entry(movieObject).Reference("MoviesSets").Load()
                    db.Entry(movieObject).Reference("MoviesPosters").Load()
                    db.Entry(movieObject).Reference("MoviesFanarts").Load()
                    Return movieObject
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function GetMovie(movieID As Long) As Model.Movie
            Try
                Using db As New Model.MediaEntities
                    Dim movieObject = (From r In db.Movies Where r.ID = movieID).FirstOrDefault()
                    db.Entry(movieObject).Reference("MoviesActors").Load()
                    db.Entry(movieObject).Reference("MoviesAStreams").Load()
                    db.Entry(movieObject).Reference("MoviesVStreams").Load()
                    db.Entry(movieObject).Reference("MoviesSubs").Load()
                    db.Entry(movieObject).Reference("MoviesSets").Load()
                    db.Entry(movieObject).Reference("MoviesPosters").Load()
                    db.Entry(movieObject).Reference("MoviesFanarts").Load()
                    Return movieObject
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class
End Namespace