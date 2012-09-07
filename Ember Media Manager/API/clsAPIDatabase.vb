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
Imports System.Xml.Serialization

Namespace API

    Public Class Database

#Region "Fields"

        Public SQLcn As New SQLite.SQLiteConnection()
        ' NOTE: This will use another DB because: can grow alot, Don't want to stress Media DB with this stuff
        Public SQLcnJobLog As New SQLite.SQLiteConnection()
#End Region 'Fields

#Region "Methods"

        ''' <summary>
        ''' Begin a SQLite transaction
        ''' </summary>
        ''' <returns>Created transaction on the global connection</returns>
        Public Function BeginTransaction() As SQLite.SQLiteTransaction
            Return Master.DB.SQLcn.BeginTransaction
        End Function

        ''' <summary>
        ''' Iterates db entries to check if the paths to the movie files are valid. If not, remove all entries pertaining to the movie.
        ''' </summary>
        Public Sub Clean(ByVal CleanMovies As Boolean, ByVal CleanTV As Boolean, Optional ByVal source As String = "")
            Dim fInfo As FileInfo
            Dim tPath As String = String.Empty
            Dim sPath As String = String.Empty
            Try
                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.SQLcn.BeginTransaction
                    If CleanMovies Then

                        Dim MoviePaths As List(Of String) = GetMoviePaths()
                        MoviePaths.Sort()

                        'get a listing of sources and their recursive properties
                        Dim SourceList As New List(Of SourceHolder)
                        Dim tSource As SourceHolder

                        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                            If source = String.Empty Then
                                SQLcommand.CommandText = "SELECT Path, Name, Recursive, Single FROM sources;"
                            Else
                                SQLcommand.CommandText = String.Format("SELECT Path, Name, Recursive, Single FROM sources WHERE Name=""{0}""", source)
                            End If
                            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                While SQLreader.Read
                                    SourceList.Add(New SourceHolder With {.Name = SQLreader("Name").ToString, .Path = SQLreader("Path").ToString, .Recursive = Convert.ToBoolean(SQLreader("Recursive")), .isSingle = Convert.ToBoolean(SQLreader("Single"))})
                                End While
                            End Using
                        End Using

                        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                            If source = String.Empty Then
                                SQLcommand.CommandText = "SELECT MoviePath, Id, Source, Type FROM movies ORDER BY MoviePath DESC;"
                            Else
                                SQLcommand.CommandText = String.Format("SELECT MoviePath, Id, Source, Type FROM movies WHERE Source = ""{0}"" ORDER BY MoviePath DESC;", source)
                            End If
                            Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                While SQLReader.Read
                                    If Not File.Exists(SQLReader("MoviePath").ToString) OrElse Not Master.eSettings.ValidExts.Contains(Path.GetExtension(SQLReader("MoviePath").ToString).ToLower) Then
                                        MoviePaths.Remove(SQLReader("MoviePath").ToString)
                                        Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                    ElseIf Master.eSettings.SkipLessThan > 0 Then
                                        fInfo = New FileInfo(SQLReader("MoviePath").ToString)
                                        If ((Not Master.eSettings.SkipStackSizeCheck OrElse Not StringUtils.IsStacked(fInfo.Name)) AndAlso fInfo.Length < Master.eSettings.SkipLessThan * 1048576) Then
                                            MoviePaths.Remove(SQLReader("MoviePath").ToString)
                                            Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                        End If
                                    Else
                                        tSource = SourceList.OrderByDescending(Function(s) s.Path).FirstOrDefault(Function(s) s.Name = SQLReader("Source").ToString)
                                        If Not IsNothing(tSource) Then
                                            If Directory.GetParent(Directory.GetParent(SQLReader("MoviePath").ToString).FullName).Name.ToLower = "bdmv" Then
                                                tPath = Directory.GetParent(Directory.GetParent(SQLReader("MoviePath").ToString).FullName).FullName
                                            Else
                                                tPath = Directory.GetParent(SQLReader("MoviePath").ToString).FullName
                                            End If
                                            sPath = FileUtils.GetDirectory(tPath).ToLower
                                            If tSource.Recursive = False AndAlso tPath.Length > tSource.Path.Length AndAlso If(sPath = "video_ts" OrElse sPath = "bdmv", tPath.Substring(tSource.Path.Length).Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar).Count > 2, tPath.Substring(tSource.Path.Length).Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar).Count > 1) Then
                                                MoviePaths.Remove(SQLReader("MoviePath").ToString)
                                                Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                            ElseIf Not Convert.ToBoolean(SQLReader("Type")) AndAlso tSource.isSingle AndAlso Not MoviePaths.Where(Function(s) SQLReader("MoviePath").ToString.ToLower.StartsWith(tSource.Path.ToLower)).Count = 1 Then
                                                MoviePaths.Remove(SQLReader("MoviePath").ToString)
                                                Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                            End If
                                        Else
                                            'orphaned
                                            MoviePaths.Remove(SQLReader("MoviePath").ToString)
                                            Master.DB.DeleteFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                        End If
                                    End If
                                End While
                            End Using
                        End Using
                    End If

                    If CleanTV Then
                        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                            If String.IsNullOrEmpty(source) Then
                                SQLcommand.CommandText = "SELECT TVEpPath FROM TVEpPaths;"
                            Else
                                SQLcommand.CommandText = String.Format("SELECT TVEpPath FROM TVEpPaths INNER JOIN TVEps ON TVEpPaths.ID = TVEps.TVEpPathID WHERE TVEps.Source =""{0}"";", source)
                            End If

                            Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                While SQLReader.Read
                                    If Not File.Exists(SQLReader("TVEpPath").ToString) OrElse Not Master.eSettings.ValidExts.Contains(Path.GetExtension(SQLReader("TVEpPath").ToString).ToLower) Then
                                        Master.DB.DeleteTVEpFromDBByPath(SQLReader("TVEpPath").ToString, False, True)
                                    End If
                                End While
                            End Using
                            'tvshows with no more real episodes
                            SQLcommand.CommandText = "DELETE FROM TVShows WHERE NOT EXISTS (SELECT TVEps.TVShowID FROM TVEps WHERE TVEps.TVShowID = TVShows.ID AND TVEps.Missing = 0)"
                            SQLcommand.ExecuteNonQuery()
                            SQLcommand.CommandText = String.Concat("DELETE FROM TVShows WHERE ID NOT IN (SELECT TVShowID FROM TVEps);")
                            SQLcommand.ExecuteNonQuery()
                            SQLcommand.CommandText = String.Concat("DELETE FROM TVShowActors WHERE TVShowID NOT IN (SELECT ID FROM TVShows);")
                            SQLcommand.ExecuteNonQuery()
                            SQLcommand.CommandText = "DELETE FROM TVEps WHERE TVShowID NOT IN (SELECT ID FROM TVShows);"
                            SQLcommand.ExecuteNonQuery()
                            'orphaned paths
                            SQLcommand.CommandText = "DELETE FROM TVEpPaths WHERE NOT EXISTS (SELECT TVEps.TVEpPathID FROM TVEps WHERE TVEps.TVEpPathID = TVEpPaths.ID AND TVEps.Missing = 0)"
                            SQLcommand.ExecuteNonQuery()
                        End Using
                    End If

                    CleanSeasons(True)

                    SQLtransaction.Commit()
                End Using

                Using SQLcommand As SQLite.SQLiteCommand = CreateCommand()
                    SQLcommand.CommandText = "VACUUM;"
                    SQLcommand.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
            End Try
        End Sub

        Public Sub CleanSeasons(Optional ByVal BatchMode As Boolean = False)
            Dim SQLTrans As SQLite.SQLiteTransaction = Nothing
            If Not BatchMode Then SQLTrans = Master.DB.BeginTransaction()
            Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                SQLCommand.CommandText = "DELETE FROM TVSeason WHERE NOT EXISTS (SELECT TVEps.Season FROM TVEps WHERE TVEps.Season = TVSeason.Season AND TVEps.TVShowID = TVSeason.TVShowID) AND TVSeason.Season <> 999"
                SQLCommand.ExecuteNonQuery()
            End Using
            If Not BatchMode Then SQLTrans.Commit()
            SQLTrans = Nothing
        End Sub

        Public Sub ClearNew()
            Try
                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        SQLcommand.CommandText = "UPDATE movies SET new = (?);"
                        Dim parNew As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parNew", DbType.Boolean, 0, "new")
                        parNew.Value = False
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    Using SQLShowcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        SQLShowcommand.CommandText = "UPDATE TVShows SET new = (?);"
                        Dim parShowNew As SQLite.SQLiteParameter = SQLShowcommand.Parameters.Add("parShowNew", DbType.Boolean, 0, "new")
                        parShowNew.Value = False
                        SQLShowcommand.ExecuteNonQuery()
                    End Using
                    Using SQLSeasoncommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        SQLSeasoncommand.CommandText = "UPDATE TVSeason SET new = (?);"
                        Dim parSeasonNew As SQLite.SQLiteParameter = SQLSeasoncommand.Parameters.Add("parSeasonNew", DbType.Boolean, 0, "new")
                        parSeasonNew.Value = False
                        SQLSeasoncommand.ExecuteNonQuery()
                    End Using
                    Using SQLEpcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        SQLEpcommand.CommandText = "UPDATE TVEps SET new = (?);"
                        Dim parEpNew As SQLite.SQLiteParameter = SQLEpcommand.Parameters.Add("parEpNew", DbType.Boolean, 0, "new")
                        parEpNew.Value = False
                        SQLEpcommand.ExecuteNonQuery()
                    End Using
                    SQLtransaction.Commit()
                End Using

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Sub Close()
            Using SQLcommand As SQLite.SQLiteCommand = CreateCommand()
                SQLcommand.CommandText = "VACUUM;"
                SQLcommand.ExecuteNonQuery()
            End Using
            Master.DB.SQLcn.Close()
            CloseJobLog()
        End Sub

        Public Sub Connect()
            Try
                Master.DB.SQLcn.ConnectionString = String.Format("Data Source=""{0}"";Compress=True", Path.Combine(Functions.AppPath, "Media.emm"))
                Master.DB.SQLcn.Open()

                ConnectJobLog()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        ''' <summary>
        ''' Create a SQLite command
        ''' </summary>
        ''' <returns>Created command on the global connection</returns>
        Public Function CreateCommand() As SQLite.SQLiteCommand
            Return Master.DB.SQLcn.CreateCommand
        End Function

        ''' <summary>
        ''' Remove all information related to a movie from the database.
        ''' </summary>
        ''' <param name="ID">ID of the movie to remove, as stored in the database.</param>
        ''' <param name="BatchMode">Is this function already part of a transaction?</param>
        ''' <returns>True if successful, false if deletion failed.</returns>
        Public Function DeleteFromDB(ByVal ID As Long, Optional ByVal BatchMode As Boolean = False) As Boolean
            Try
                Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
                If Not BatchMode Then SQLtransaction = Master.DB.SQLcn.BeginTransaction
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLcommand.CommandText = String.Concat("DELETE FROM movies WHERE id = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesAStreams WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesVStreams WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesActors WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesSubs WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesPosters WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesFanart WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM MoviesSets WHERE MovieID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                End Using
                If Not BatchMode Then SQLtransaction.Commit()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Remove all information related to a TV episode from the database.
        ''' </summary>
        ''' <param name="ID">ID of the episode to remove, as stored in the database.</param>
        ''' <param name="BatchMode">Is this function already part of a transaction?</param>
        ''' <returns>True if successful, false if deletion failed.</returns>
        Public Function DeleteTVEpFromDB(ByVal ID As Long, ByVal Force As Boolean, ByVal DoCleanSeasons As Boolean, Optional ByVal BatchMode As Boolean = False) As Boolean
            Try
                Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
                If Not BatchMode Then SQLtransaction = Master.DB.SQLcn.BeginTransaction
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLcommand.CommandText = String.Concat("SELECT TVEpPathID, Missing FROM TVEps WHERE ID = ", ID, ";")
                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader
                        While SQLReader.Read
                            Using SQLECommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                                If Not Master.eSettings.DisplayMissingEpisodes OrElse Force Then
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVEpPaths WHERE ID = ", Convert.ToInt32(SQLReader("TVEpPathID")), ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVEps WHERE ID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVEpActors WHERE TVEpID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVVStreams WHERE TVEpID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVAStreams WHERE TVEpID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVSubs WHERE TVEpID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()

                                    If DoCleanSeasons Then Master.DB.CleanSeasons(True)
                                ElseIf Not Convert.ToBoolean(SQLReader("Missing")) Then 'already marked as missing, no need for another query
                                    SQLECommand.CommandText = String.Concat("DELETE FROM TVEpPaths WHERE ID = ", Convert.ToInt32(SQLReader("TVEpPathID")), ";")
                                    SQLECommand.ExecuteNonQuery()
                                    SQLECommand.CommandText = String.Concat("UPDATE TVEps SET Missing = 1 WHERE ID = ", ID, ";")
                                    SQLECommand.ExecuteNonQuery()
                                End If
                            End Using
                        End While
                    End Using
                End Using
                If Not BatchMode Then
                    SQLtransaction.Commit()
                    Master.DB.CleanSeasons()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Return False
            End Try
            Return True
        End Function

        Public Function DeleteTVEpFromDBByPath(ByVal sPath As String, ByVal Force As Boolean, Optional ByVal BatchMode As Boolean = False) As Boolean
            Try
                Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
                If Not BatchMode Then SQLtransaction = Master.DB.SQLcn.BeginTransaction
                Using SQLPCommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLPCommand.CommandText = String.Concat("SELECT ID FROM TVEpPaths WHERE TVEpPath = """, sPath, """;")
                    Using SQLPReader As SQLite.SQLiteDataReader = SQLPCommand.ExecuteReader
                        While SQLPReader.Read
                            Using SQLCommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                                SQLCommand.CommandText = String.Concat("SELECT ID, TVShowID, Season, Missing FROM TVEps WHERE TVEpPathID = ", SQLPReader("ID"), ";")
                                Using SQLReader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader
                                    While SQLReader.Read
                                        Using SQLECommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                                            If Not Master.eSettings.DisplayMissingEpisodes OrElse Force Then
                                                SQLECommand.CommandText = String.Concat("DELETE FROM TVEps WHERE ID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()
                                                SQLECommand.CommandText = String.Concat("DELETE FROM TVEpActors WHERE TVEpID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()
                                                SQLECommand.CommandText = String.Concat("DELETE FROM TVVStreams WHERE TVEpID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()
                                                SQLECommand.CommandText = String.Concat("DELETE FROM TVAStreams WHERE TVEpID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()
                                                SQLECommand.CommandText = String.Concat("DELETE FROM TVSubs WHERE TVEpID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()

                                                SQLECommand.CommandText = String.Concat("SELECT ID FROM TVEps WHERE TVShowID = ", SQLReader("TVShowID"), " AND Season = ", SQLReader("Season"), ";")
                                                Using SQLSeasonReader As SQLite.SQLiteDataReader = SQLECommand.ExecuteReader
                                                    If Not SQLSeasonReader.HasRows Then
                                                        'no more episodes for this season, delete the season
                                                        Using SQLSeasonCommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                                                            SQLSeasonCommand.CommandText = String.Concat("DELETE FROM TVSeason WHERE TVShowID = ", SQLReader("TVShowID"), " AND Season = ", SQLReader("Season"), ";")
                                                            SQLSeasonCommand.ExecuteNonQuery()
                                                        End Using
                                                    End If
                                                End Using
                                            ElseIf Not Convert.ToBoolean(SQLReader("Missing")) Then
                                                SQLECommand.CommandText = String.Concat("UPDATE TVEps SET Missing = 1, TVEpPathID = -1 WHERE ID = ", SQLReader("ID"), ";")
                                                SQLECommand.ExecuteNonQuery()
                                            End If

                                            SQLECommand.CommandText = String.Concat("DELETE FROM TVEpPaths WHERE ID = ", SQLPReader("ID"), ";")
                                            SQLECommand.ExecuteNonQuery()
                                        End Using
                                    End While
                                End Using
                            End Using
                        End While
                    End Using
                End Using
                If Not BatchMode Then SQLtransaction.Commit()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Remove all information related to a TV season from the database.
        ''' </summary>
        ''' <param name="ShowID">ID of the tvshow to remove, as stored in the database.</param>
        ''' <param name="BatchMode">Is this function already part of a transaction?</param>
        ''' <returns>True if successful, false if deletion failed.</returns>
        Public Function DeleteTVSeasonFromDB(ByVal ShowID As Long, ByVal iSeason As Integer, Optional ByVal BatchMode As Boolean = False) As Boolean
            Try
                Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
                If Not BatchMode Then SQLtransaction = Master.DB.SQLcn.BeginTransaction
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLcommand.CommandText = String.Concat("SELECT ID FROM TVEps WHERE TVShowID = ", ShowID, " AND Season = ", iSeason, ";")
                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                        While SQLReader.Read
                            DeleteTVEpFromDB(Convert.ToInt64(SQLReader("ID")), False, False, True)
                        End While
                    End Using
                    SQLcommand.CommandText = String.Concat("DELETE FROM TVSeason WHERE TVShowID = ", ShowID, " AND Season = ", iSeason, ";")
                    SQLcommand.ExecuteNonQuery()
                End Using

                CleanSeasons(True)

                If Not BatchMode Then SQLtransaction.Commit()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Remove all information related to a TV show from the database.
        ''' </summary>
        ''' <param name="ID">ID of the tvshow to remove, as stored in the database.</param>
        ''' <param name="BatchMode">Is this function already part of a transaction?</param>
        ''' <returns>True if successful, false if deletion failed.</returns>
        Public Function DeleteTVShowFromDB(ByVal ID As Long, Optional ByVal BatchMode As Boolean = False) As Boolean
            Try
                Dim SQLtransaction As SQLite.SQLiteTransaction = Nothing
                If Not BatchMode Then SQLtransaction = Master.DB.SQLcn.BeginTransaction
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLcommand.CommandText = String.Concat("SELECT ID FROM TVEps WHERE TVShowID = ", ID, ";")
                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                        While SQLReader.Read
                            DeleteTVEpFromDB(Convert.ToInt64(SQLReader("ID")), True, False, True)
                        End While
                    End Using
                    SQLcommand.CommandText = String.Concat("DELETE FROM TVShows WHERE ID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM TVShowActors WHERE TVShowID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                    SQLcommand.CommandText = String.Concat("DELETE FROM TVSeason WHERE TVShowID = ", ID, ";")
                    SQLcommand.ExecuteNonQuery()
                End Using

                CleanSeasons(True)

                If Not BatchMode Then SQLtransaction.Commit()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Fill DataTable with data returned from the provided command
        ''' </summary>
        ''' <param name="dTable">DataTable to fill</param>
        ''' <param name="Command">SQL Command to process</param>
        Public Sub FillDataTable(ByRef dTable As DataTable, ByVal Command As String)
            Try
                dTable.Clear()
                Dim sqlDA As New SQLite.SQLiteDataAdapter(Command, Master.DB.SQLcn)
                Dim sqlCB As New SQLite.SQLiteCommandBuilder(sqlDA)
                sqlDA.Fill(dTable)
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Function GetMoviePaths() As List(Of String)
            Dim tList As New List(Of String)
            Dim mPath As String

            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                SQLcommand.CommandText = "SELECT Movies.MoviePath FROM Movies;"
                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                    While SQLreader.Read
                        mPath = SQLreader("MoviePath").ToString.ToLower
                        If Master.eSettings.NoStackExts.Contains(Path.GetExtension(mPath)) Then
                            tList.Add(mPath)
                        Else
                            tList.Add(StringUtils.CleanStackingMarkers(mPath))
                        End If
                    End While
                End Using
            End Using

            Return tList
        End Function


        ''' <summary>
        ''' Get the posterpath for the all seasons entry.
        ''' </summary>
        ''' <param name="ShowID">ID of the show to load, as stored in the database</param>
        ''' <returns>Structures.DBTV object</returns>
        Public Function LoadTVAllSeasonFromDB(ByVal ShowID As Long, Optional ByVal WithShow As Boolean = False) As Structures.DBTV
            Dim _TVDB As New Structures.DBTV
            Try
                _TVDB.ShowID = ShowID
                _TVDB.TVEp = New MediaContainers.EpisodeDetails With {.Season = 999}

                Using SQLcommandTVSeason As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                    SQLcommandTVSeason.CommandText = String.Concat("SELECT * FROM TVSeason WHERE TVShowID = ", ShowID, " AND Season = 999;")
                    Using SQLReader As SQLite.SQLiteDataReader = SQLcommandTVSeason.ExecuteReader
                        If SQLReader.HasRows Then
                            If Not DBNull.Value.Equals(SQLReader("PosterPath")) Then _TVDB.SeasonPosterPath = SQLReader("PosterPath").ToString
                        End If
                    End Using
                End Using

                'If WithShow Then Master.DB.FillTVShowFromDB(_TVDB)

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
            Return _TVDB
        End Function

        


        Public Sub PatchDatabase(ByVal fname As String)
            Dim xmlSer As XmlSerializer
            Dim _cmds As New Containers.InstallCommands
            xmlSer = New XmlSerializer(GetType(Containers.InstallCommands))
            Using xmlSW As New StreamReader(Path.Combine(Functions.AppPath, fname))
                _cmds = DirectCast(xmlSer.Deserialize(xmlSW), Containers.InstallCommands)
                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.SQLcn.BeginTransaction
                    For Each _cmd As Containers.InstallCommand In _cmds.Command
                        If _cmd.CommandType = "DB" Then
                            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcn.CreateCommand
                                SQLcommand.CommandText = _cmd.CommandExecute
                                Try
                                    SQLcommand.ExecuteNonQuery()
                                Catch ex As Exception
                                    Dim log As New StreamWriter(Path.Combine(Functions.AppPath, "install.log"), True)
                                    log.WriteLine(String.Format("--- Error: {0}", ex.Message))
                                    log.WriteLine(ex.StackTrace)
                                    log.Close()
                                End Try
                            End Using
                        End If
                    Next
                    SQLtransaction.Commit()
                End Using
            End Using
        End Sub

        Public Function CheckEssentials() As Boolean
            Dim needUpdate As Boolean = False
            Master.DB.Connect()
            If Not File.Exists(Path.Combine(Functions.AppPath, "Media.emm")) Then
                Master.DB.PatchDatabase("CreateDB.xml")
                needUpdate = True
            End If
            Return needUpdate
        End Function

      
        Public Function GetMoviePathsBySource(Optional ByVal source As String = "") As List(Of String)
            Dim Paths As New List(Of String)
            Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                SQLcommand.CommandText = String.Format("SELECT MoviePath, Source FROM Movies {0};", If(source = String.Empty, String.Empty, String.Format("INNER JOIN Sources ON Movies.Source=Sources.Name Where Sources.Path=""{0}""", source)))
                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                    While SQLreader.Read
                        Paths.Add(SQLreader("MoviePath").ToString)
                    End While
                End Using
            End Using
            Return Paths
        End Function


        '''''''''''''''''''''''''''''''''''''''''''
        Private Sub ConnectJobLog()
            Dim NewDB As Boolean = False
            'create database if it doesn't exist
            If Not File.Exists(Path.Combine(Functions.AppPath, "JobLogs.emm")) Then
                NewDB = True
                'ElseIf Delete Then
                'NewDB = True
                'File.Delete(Path.Combine(Functions.AppPath, "Media.emm"))
            End If
            SQLcnJobLog.ConnectionString = String.Format("Data Source=""{0}"";Compress=True", Path.Combine(Functions.AppPath, "JobLogs.emm"))
            SQLcnJobLog.Open()
            If NewDB Then
                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.SQLcnJobLog.BeginTransaction
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcnJobLog.CreateCommand
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS Jobs(" & _
                                                 "ID INTEGER PRIMARY KEY AUTOINCREMENT, " & _
                                                 "MediaType INTEGER NOT NULL, " & _
                                                 "MediaID INTEGER NOT NULL, " & _
                                                 "LastDateAdd TEXT " & _
                                                 ");"
                        SQLcommand.ExecuteNonQuery()
                        SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS JobsEntry(" & _
                                                 "ID INTEGER PRIMARY KEY AUTOINCREMENT, " & _
                                                 "ItemType INTEGER NOT NULL, " & _
                                                 "Message INTEGER NOT NULL, " & _
                                                 "Details INTEGER NOT NULL, " & _
                                                 "DateAdd TEXT " & _
                                                 ");"
                        SQLcommand.ExecuteNonQuery()
                    End Using
                    SQLtransaction.Commit()
                End Using
            End If
        End Sub

        Private Sub CloseJobLog()
            Try
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.SQLcnJobLog.CreateCommand
                    SQLcommand.CommandText = "VACUUM;"
                    SQLcommand.ExecuteNonQuery()
                End Using
                Master.DB.SQLcnJobLog.Close()
            Catch ex As Exception
            End Try
        End Sub

#End Region 'Methods

#Region "Nested Types"

        Private Class SourceHolder

#Region "Fields"

            Private _name As String
            Private _path As String
            Private _recursive As Boolean
            Private _single As Boolean

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property isSingle() As Boolean
                Get
                    Return Me._single
                End Get
                Set(ByVal value As Boolean)
                    Me._single = value
                End Set
            End Property

            Public Property Name() As String
                Get
                    Return Me._name
                End Get
                Set(ByVal value As String)
                    Me._name = value
                End Set
            End Property

            Public Property Path() As String
                Get
                    Return Me._path
                End Get
                Set(ByVal value As String)
                    Me._path = value
                End Set
            End Property

            Public Property Recursive() As Boolean
                Get
                    Return Me._recursive
                End Get
                Set(ByVal value As Boolean)
                    Me._recursive = value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._name = String.Empty
                Me._path = String.Empty
                Me._recursive = False
                Me._single = False
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class
End Namespace