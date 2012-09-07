Imports EmberMediaManger.API

Namespace Model
    Partial Public Class Movie
        Property FileInfo As MediaInfo.Fileinfo
        Property FormatedTitle As String
    End Class

    Partial Public Class TVEp
        Property FileInfo As MediaInfo.Fileinfo
        Public Sub LoadActors()
            Try
                Using db As New MediaEntities
                    db.TVEps.Attach(Me)
                    db.Entry(Me).Collection("TVEpActors").Load()
                End Using
            Catch ex As Exception

            End Try
        End Sub        
    End Class

    Partial Public Class TVShow
        Public Sub LoadAllEpisodes()
            Try
                Using db As New MediaEntities
                    db.TVShows.Attach(Me)
                    db.Entry(Me).Collection("TVSeasons.TVEps").Load()
                End Using
            Catch ex As Exception

            End Try
        End Sub
        Public Sub LoadActors()
            Try
                Using db As New MediaEntities
                    db.TVShows.Attach(Me)
                    db.Entry(Me).Collection("TVShowActors").Load()
                End Using
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace