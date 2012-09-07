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
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Serialization

Namespace API

    Public Class NFO

#Region "Methods"

        Public Shared Function GetEpNfoPath(ByVal EpPath As String) As String
            Dim nPath As String = String.Empty

            If File.Exists(String.Concat(FileUtils.RemoveExtFromPath(EpPath), ".nfo")) Then
                nPath = String.Concat(FileUtils.RemoveExtFromPath(EpPath), ".nfo")
            End If

            Return nPath
        End Function

        Public Shared Function GetIMDBFromNonConf(ByVal sPath As String, ByVal isSingle As Boolean) As NonConf
            Dim tNonConf As New NonConf
            Dim dirPath As String = Directory.GetParent(sPath).FullName
            Dim lFiles As New List(Of String)

            If isSingle Then
                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, "*.nfo"))
                Catch
                End Try
                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, "*.info"))
                Catch
                End Try
            Else
                Dim fName As String = StringUtils.CleanStackingMarkers(Path.GetFileNameWithoutExtension(sPath)).ToLower
                Dim oName As String = Path.GetFileNameWithoutExtension(sPath)
                fName = If(fName.EndsWith("*"), fName, String.Concat(fName, "*"))
                oName = If(oName.EndsWith("*"), oName, String.Concat(oName, "*"))

                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(fName, ".nfo")))
                Catch
                End Try
                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(oName, ".nfo")))
                Catch
                End Try
                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(fName, ".info")))
                Catch
                End Try
                Try
                    lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(oName, ".info")))
                Catch
                End Try
            End If

            For Each sFile As String In lFiles
                Using srInfo As New StreamReader(sFile)
                    Dim sInfo As String = srInfo.ReadToEnd
                    Dim sIMDBID As String = Regex.Match(sInfo, "tt\d\d\d\d\d\d\d", RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).ToString

                    If Not String.IsNullOrEmpty(sIMDBID) Then
                        tNonConf.IMDBID = sIMDBID
                        'now lets try to see if the rest of the file is a proper nfo
                        If sInfo.ToLower.Contains("</movie>") Then
                            tNonConf.Text = APIXML.XMLToLowerCase(sInfo.Substring(0, sInfo.ToLower.IndexOf("</movie>") + 8))
                        End If
                        Exit For
                    Else
                        sIMDBID = Regex.Match(sPath, "tt\d\d\d\d\d\d\d", RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).ToString
                        If Not String.IsNullOrEmpty(sIMDBID) Then
                            tNonConf.IMDBID = sIMDBID
                        End If
                    End If
                End Using
            Next
            Return tNonConf
        End Function

        Public Shared Function GetNfoPath(ByVal sPath As String, ByVal isSingle As Boolean) As String
            '//
            ' Get the proper path to NFO
            '\\

            Dim nPath As String = String.Empty

            If Master.eSettings.VideoTSParent AndAlso FileUtils.isVideoTS(sPath) Then
                nPath = String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName, Directory.GetParent(Directory.GetParent(sPath).FullName).Name), ".nfo")
                If File.Exists(nPath) Then
                    Return nPath
                Else
                    If Not isSingle Then
                        Return String.Empty
                    Else
                        'return movie path so we can use it for looking for non-conforming nfos
                        Return sPath
                    End If
                End If
            ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.isBDRip(sPath) Then
                nPath = String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(Directory.GetParent(sPath).FullName).FullName).Name), ".nfo")
                If File.Exists(nPath) Then
                    Return nPath
                Else
                    If Not isSingle Then
                        Return String.Empty
                    Else
                        'return movie path so we can use it for looking for non-conforming nfos
                        Return sPath
                    End If
                End If
            Else
                Dim tmpName As String = StringUtils.CleanStackingMarkers(Path.GetFileNameWithoutExtension(sPath))
                Dim tmpNameNoStack As String = Path.GetFileNameWithoutExtension(sPath)
                nPath = Path.Combine(Directory.GetParent(sPath).FullName, tmpName).ToLower
                Dim nPathWithStack As String = Path.Combine(Directory.GetParent(sPath).FullName, tmpNameNoStack).ToLower

                Dim fList As New List(Of String)
                Try
                    fList.AddRange(Directory.GetFiles(Directory.GetParent(sPath).FullName, "*.nfo"))
                Catch
                End Try
                fList = fList.ConvertAll(Function(s) s.ToLower)

                If isSingle AndAlso Master.eSettings.MovieNFO AndAlso fList.Contains(Path.Combine(Directory.GetParent(sPath).FullName.ToLower, "movie.nfo")) Then
                    Return Path.Combine(Directory.GetParent(nPath).FullName.ToLower, "movie.nfo")
                ElseIf Master.eSettings.MovieNameNFO AndAlso fList.Contains(String.Concat(nPathWithStack, ".nfo")) Then
                    Return String.Concat(nPathWithStack, ".nfo")
                ElseIf Master.eSettings.MovieNameNFO AndAlso fList.Contains(String.Concat(nPath, ".nfo")) Then
                    Return String.Concat(nPath, ".nfo")
                Else
                    If Not isSingle Then
                        Return String.Empty
                    Else
                        'return movie path so we can use it for looking for non-conforming nfos
                        Return sPath
                    End If
                End If
            End If
        End Function

        Public Shared Function GetShowNfoPath(ByVal ShowPath As String) As String
            Dim nPath As String = String.Empty

            If File.Exists(Path.Combine(ShowPath, "tvshow.nfo")) Then
                nPath = Path.Combine(ShowPath, "tvshow.nfo")
            End If

            Return nPath
        End Function

        Public Shared Function IsConformingEpNfo(ByVal sPath As String) As Boolean
            Dim testSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.EpisodeDetails))
            Dim testEp As New MediaContainers.EpisodeDetails

            Try
                If (Path.GetExtension(sPath) = ".nfo" OrElse Path.GetExtension(sPath) = ".info") AndAlso File.Exists(sPath) Then
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        Dim xmlStr As String = xmlSR.ReadToEnd
                        Dim rMatches As MatchCollection = Regex.Matches(xmlStr, "<episodedetails.*?>.*?</episodedetails>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.IgnorePatternWhitespace)
                        If rMatches.Count = 1 Then
                            Using xmlRead As StringReader = New StringReader(rMatches(0).Value)
                                testEp = DirectCast(testSer.Deserialize(xmlRead), MediaContainers.EpisodeDetails)
                                testSer = Nothing
                                testEp = Nothing
                                Return True
                            End Using
                        ElseIf rMatches.Count > 1 Then
                            'read them all... if one fails, the entire nfo is non conforming
                            For Each xmlReg As Match In rMatches
                                Using xmlRead As StringReader = New StringReader(xmlReg.Value)
                                    testEp = DirectCast(testSer.Deserialize(xmlRead), MediaContainers.EpisodeDetails)
                                    testEp = Nothing
                                End Using
                            Next
                            testSer = Nothing
                            Return True
                        Else
                            testSer = Nothing
                            If Not IsNothing(testEp) Then
                                testEp = Nothing
                            End If
                            Return False
                        End If
                    End Using
                Else
                    testSer = Nothing
                    testEp = Nothing
                    Return False
                End If
            Catch
                If Not IsNothing(testSer) Then
                    testSer = Nothing
                End If
                If Not IsNothing(testEp) Then
                    testEp = Nothing
                End If
                Return False
            End Try
        End Function

        Public Shared Function IsConformingNfo(ByVal sPath As String) As Boolean
            Dim testSer As XmlSerializer = Nothing

            Try
                If (Path.GetExtension(sPath) = ".nfo" OrElse Path.GetExtension(sPath) = ".info") AndAlso File.Exists(sPath) Then
                    Using testSR As StreamReader = New StreamReader(sPath)
                        testSer = New XmlSerializer(GetType(MediaContainers.Movie))
                        Dim testMovie As MediaContainers.Movie = DirectCast(testSer.Deserialize(testSR), MediaContainers.Movie)
                        testMovie = Nothing
                        testSer = Nothing
                    End Using
                    Return True
                Else
                    Return False
                End If
            Catch
                If Not IsNothing(testSer) Then
                    testSer = Nothing
                End If

                Return False
            End Try
        End Function

        Public Shared Function IsConformingShowNfo(ByVal sPath As String) As Boolean
            Dim testSer As XmlSerializer = Nothing

            Try
                If (Path.GetExtension(sPath) = ".nfo" OrElse Path.GetExtension(sPath) = ".info") AndAlso File.Exists(sPath) Then
                    Using testSR As StreamReader = New StreamReader(sPath)
                        testSer = New XmlSerializer(GetType(MediaContainers.TVShow))
                        Dim testShow As MediaContainers.TVShow = DirectCast(testSer.Deserialize(testSR), MediaContainers.TVShow)
                        testShow = Nothing
                        testSer = Nothing
                    End Using
                    Return True
                Else
                    Return False
                End If
            Catch
                If Not IsNothing(testSer) Then
                    testSer = Nothing
                End If

                Return False
            End Try
        End Function

        Public Shared Function LoadMovieFromNFO(ByVal sPath As String, ByVal isSingle As Boolean) As Model.Movie
            '//
            ' Deserialze the NFO to pass all the data to a MediaContainers.Movie
            '\\

            Dim xmlSer As XmlSerializer = Nothing
            Dim xmlMov As New Model.Movie

            'If Not String.IsNullOrEmpty(sPath) Then
            '    Try
            '        If File.Exists(sPath) AndAlso Path.GetExtension(sPath).ToLower = ".nfo" Then
            '            Using xmlSR As StreamReader = New StreamReader(sPath)
            '                xmlSer = New XmlSerializer(GetType(MediaContainers.Movie))
            '                xmlMov = DirectCast(xmlSer.Deserialize(xmlSR), Model.Movie)
            '                xmlMov.Genre = Strings.Join(xmlMov.LGenre.ToArray, " / ")
            '                xmlMov.Outline = xmlMov.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '                xmlMov.Plot = xmlMov.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '            End Using
            '        Else
            '            If Not String.IsNullOrEmpty(sPath) Then
            '                Dim sReturn As New NonConf
            '                sReturn = GetIMDBFromNonConf(sPath, isSingle)
            '                xmlMov.Imdb = sReturn.IMDBID
            '                Try
            '                    If Not String.IsNullOrEmpty(sReturn.Text) Then
            '                        Using xmlSTR As StringReader = New StringReader(sReturn.Text)
            '                            xmlSer = New XmlSerializer(GetType(MediaContainers.Movie))
            '                            xmlMov = DirectCast(xmlSer.Deserialize(xmlSTR), Model.Movie)                                        
            '                            xmlMov.Genre = Strings.Join(xmlMov.Genre.ToArray, " / ")
            '                            xmlMov.Outline = xmlMov.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '                            xmlMov.Plot = xmlMov.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '                            xmlMov.IMDBID = sReturn.IMDBID
            '                        End Using
            '                    End If
            '                Catch
            '                End Try
            '            End If
            '        End If

            '    Catch
            '        xmlMov.Clear()
            '        If Not String.IsNullOrEmpty(sPath) Then

            '            'go ahead and rename it now, will still be picked up in getimdbfromnonconf
            '            If Not Master.eSettings.OverwriteNfo Then
            '                RenameNonConfNfo(sPath, True)
            '            End If

            '            Dim sReturn As New NonConf
            '            sReturn = GetIMDBFromNonConf(sPath, isSingle)
            '            xmlMov.IMDBID = sReturn.IMDBID
            '            Try
            '                If Not String.IsNullOrEmpty(sReturn.Text) Then
            '                    Using xmlSTR As StringReader = New StringReader(sReturn.Text)
            '                        xmlSer = New XmlSerializer(GetType(MediaContainers.Movie))
            '                        xmlMov = DirectCast(xmlSer.Deserialize(xmlSTR), MediaContainers.Movie)
            '                        xmlMov.Genre = Strings.Join(xmlMov.LGenre.ToArray, " / ")
            '                        xmlMov.Outline = xmlMov.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '                        xmlMov.Plot = xmlMov.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            '                        xmlMov.IMDBID = sReturn.IMDBID
            '                    End Using
            '                End If
            '            Catch
            '            End Try
            '        End If
            '    End Try

            '    If Not IsNothing(xmlSer) Then
            '        xmlSer = Nothing
            '    End If
            'End If

            Return xmlMov
        End Function

        

        Public Shared Function LoadTVShowFromNFO(ByVal sPath As String) As MediaContainers.TVShow
            Dim xmlSer As XmlSerializer = Nothing
            Dim xmlShow As New MediaContainers.TVShow

            If Not String.IsNullOrEmpty(sPath) Then
                Try
                    If File.Exists(sPath) AndAlso Path.GetExtension(sPath).ToLower = ".nfo" Then
                        Using xmlSR As StreamReader = New StreamReader(sPath)
                            xmlSer = New XmlSerializer(GetType(MediaContainers.TVShow))
                            xmlShow = DirectCast(xmlSer.Deserialize(xmlSR), MediaContainers.TVShow)
                            xmlShow.Genre = Strings.Join(xmlShow.LGenre.ToArray, " / ")
                        End Using
                    Else
                        'not really anything else to do with non-conforming nfos aside from rename them
                        If Not Master.eSettings.OverwriteNfo Then
                            RenameShowNonConfNfo(sPath)
                        End If
                    End If

                Catch
                    'not really anything else to do with non-conforming nfos aside from rename them
                    If Not Master.eSettings.OverwriteNfo Then
                        RenameShowNonConfNfo(sPath)
                    End If
                End Try

                Try
                    Dim params As New List(Of Object)(New Object() {xmlShow})
                    Dim doContinue As Boolean = True
                    ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.OnTVShowNFORead, params, doContinue, False)

                Catch ex As Exception
                End Try

                If Not IsNothing(xmlSer) Then
                    xmlSer = Nothing
                End If
            End If

            Return xmlShow
        End Function

        Public Shared Sub SaveMovieToNFO(ByRef movieToSave As Structures.DBMovie)
            '//
            ' Serialize MediaContainers.Movie to an NFO
            '\\
            Try
                Try
                    Dim params As New List(Of Object)(New Object() {movieToSave})
                    Dim doContinue As Boolean = True
                    ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.OnMovieNFOSave, params, doContinue, False)
                    If Not doContinue Then Return
                Catch ex As Exception
                End Try

                If Not String.IsNullOrEmpty(movieToSave.Filename) Then
                    Dim xmlSer As New XmlSerializer(GetType(MediaContainers.Movie))

                    Dim tPath As String = String.Empty
                    Dim nPath As String = String.Empty
                    Dim doesExist As Boolean = False
                    Dim fAtt As New FileAttributes
                    Dim fAttWritable As Boolean = True

                    If Master.eSettings.VideoTSParent AndAlso FileUtils.isVideoTS(movieToSave.Filename) Then
                        tPath = String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(movieToSave.Filename).FullName).FullName, Directory.GetParent(Directory.GetParent(movieToSave.Filename).FullName).Name), ".nfo")

                        If Not Master.eSettings.OverwriteNfo Then
                            RenameNonConfNfo(tPath, False)
                        End If

                        doesExist = File.Exists(tPath)
                        If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                            If doesExist Then
                                fAtt = File.GetAttributes(tPath)
                                Try
                                    File.SetAttributes(tPath, FileAttributes.Normal)
                                Catch ex As Exception
                                    fAttWritable = False
                                End Try
                            End If

                            Using xmlSW As New StreamWriter(tPath)
                                movieToSave.NfoPath = tPath
                                xmlSer.Serialize(xmlSW, movieToSave.Movie)
                            End Using

                            If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                        End If
                    ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.isBDRip(movieToSave.Filename) Then
                        tPath = String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(movieToSave.Filename).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(Directory.GetParent(movieToSave.Filename).FullName).FullName).Name), ".nfo")

                        If Not Master.eSettings.OverwriteNfo Then
                            RenameNonConfNfo(tPath, False)
                        End If

                        doesExist = File.Exists(tPath)
                        If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                            If doesExist Then
                                fAtt = File.GetAttributes(tPath)
                                Try
                                    File.SetAttributes(tPath, FileAttributes.Normal)
                                Catch ex As Exception
                                    fAttWritable = False
                                End Try
                            End If

                            Using xmlSW As New StreamWriter(tPath)
                                movieToSave.NfoPath = tPath
                                xmlSer.Serialize(xmlSW, movieToSave.Movie)
                            End Using

                            If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                        End If
                    Else
                        Dim tmpName As String = Path.GetFileNameWithoutExtension(movieToSave.Filename)
                        nPath = Path.Combine(Directory.GetParent(movieToSave.Filename).FullName, tmpName)

                        If Master.eSettings.MovieNameNFO AndAlso (Not movieToSave.isSingle OrElse Not Master.eSettings.MovieNameMultiOnly) Then
                            If FileUtils.isVideoTS(movieToSave.Filename) Then
                                tPath = Path.Combine(Directory.GetParent(movieToSave.Filename).FullName, "video_ts.nfo")
                            ElseIf FileUtils.isBDRip(movieToSave.Filename) Then
                                tPath = Path.Combine(Directory.GetParent(movieToSave.Filename).FullName, "index.nfo")
                            Else
                                tPath = String.Concat(nPath, ".nfo")
                            End If

                            If Not Master.eSettings.OverwriteNfo Then
                                RenameNonConfNfo(tPath, False)
                            End If

                            doesExist = File.Exists(tPath)
                            If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                                If doesExist Then
                                    fAtt = File.GetAttributes(tPath)
                                    Try
                                        File.SetAttributes(tPath, FileAttributes.Normal)
                                    Catch ex As Exception
                                        fAttWritable = False
                                    End Try
                                End If

                                Using xmlSW As New StreamWriter(tPath)
                                    movieToSave.NfoPath = tPath
                                    xmlSer.Serialize(xmlSW, movieToSave.Movie)
                                End Using

                                If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                            End If
                        End If

                        If movieToSave.isSingle AndAlso Master.eSettings.MovieNFO Then
                            tPath = Path.Combine(Directory.GetParent(nPath).FullName, "movie.nfo")

                            If Not Master.eSettings.OverwriteNfo Then
                                RenameNonConfNfo(tPath, False)
                            End If

                            doesExist = File.Exists(tPath)
                            If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                                If doesExist Then
                                    fAtt = File.GetAttributes(tPath)
                                    Try
                                        File.SetAttributes(tPath, FileAttributes.Normal)
                                    Catch ex As Exception
                                        fAttWritable = False
                                    End Try
                                End If

                                Using xmlSW As New StreamWriter(tPath)
                                    movieToSave.NfoPath = tPath
                                    xmlSer.Serialize(xmlSW, movieToSave.Movie)
                                End Using
                                If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Shared Sub SaveSingleNFOItem(ByVal sPath As String, ByVal strToWrite As String, ByVal strNode As String)
            '//
            ' Save just one item of an NFO file
            '\\

            Try
                Dim xmlDoc As New XmlDocument()
                'use streamreader to open NFO so we don't get any access violations when trying to save
                Dim xmlSR As New StreamReader(sPath)
                'copy NFO to string
                Dim xmlString As String = xmlSR.ReadToEnd
                'close the streamreader... we're done with it
                xmlSR.Close()
                xmlSR = Nothing

                xmlDoc.LoadXml(xmlString)
                Dim xNode As XmlNode = xmlDoc.SelectSingleNode(strNode)
                xNode.InnerText = strToWrite
                xmlDoc.Save(sPath)

                xmlDoc = Nothing
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public NotInheritable Class Utf8StringWriter
            Inherits StringWriter
            Public Overloads Overrides ReadOnly Property Encoding() As Encoding
                Get
                    Return Encoding.UTF8
                End Get
            End Property
        End Class

        Public Shared Sub LoadTVEpFromNFO(ByRef inputTVEp As Model.TVEp)
            If Not String.IsNullOrEmpty(inputTVEp.NfoPath) AndAlso inputTVEp.Season >= -1 Then
                Try
                    If File.Exists(inputTVEp.NfoPath) AndAlso Path.GetExtension(inputTVEp.NfoPath).ToLower = ".nfo" Then
                        Dim nfoData As String = File.ReadAllText(inputTVEp.NfoPath)
                        Dim xmlDoc As XDocument
                        Dim rMatches As MatchCollection = Regex.Matches(nfoData, "<episodedetails.*?>.*?</episodedetails>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.IgnorePatternWhitespace)
                        For Each xmlEntry As Match In rMatches
                            xmlDoc = XDocument.Parse(xmlEntry.Value)
                            If (xmlDoc.Root.Element("season").Value = inputTVEp.Season And xmlDoc.Root.Element("episode").Value = inputTVEp.Episode) Then
                                inputTVEp.Title = xmlDoc.Root.Element("title").Value
                                inputTVEp.Episode = xmlDoc.Root.Element("episode").Value
                                inputTVEp.Season = xmlDoc.Root.Element("season").Value
                                inputTVEp.Aired = xmlDoc.Root.Element("aired").Value
                                inputTVEp.Plot = xmlDoc.Root.Element("plot").Value
                                inputTVEp.Credits = xmlDoc.Root.Element("credits").Value
                                inputTVEp.Director = xmlDoc.Root.Element("director").Value
                                inputTVEp.Rating = xmlDoc.Root.Element("rating").Value
                                inputTVEp.TVEpActors.Clear()
                                For Each actor As XElement In xmlDoc.Root.Elements("actor")
                                    Dim tvActor As New Model.TVEpActor
                                    tvActor.ActorName = actor.Element("name").Value
                                    tvActor.Role = actor.Element("role").Value
                                    inputTVEp.TVEpActors.Add(tvActor)
                                Next
                            End If
                        Next
                    Else
                        'not really anything else to do with non-conforming nfos aside from rename them
                        If Not Master.eSettings.OverwriteNfo Then
                            RenameEpNonConfNfo(inputTVEp.NfoPath, True)
                        End If
                    End If

                Catch
                    'not really anything else to do with non-conforming nfos aside from rename them
                    If Not Master.eSettings.OverwriteNfo Then
                        RenameEpNonConfNfo(inputTVEp.NfoPath, True)
                    End If
                End Try
            End If
        End Sub

        Private Shared Sub RenameEpNonConfNfo(ByVal sPath As String, ByVal isChecked As Boolean)
            'test if current nfo is non-conforming... rename per setting

            Try
                If File.Exists(sPath) AndAlso Not IsConformingEpNfo(sPath) Then
                    RenameToInfo(sPath)
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Shared Sub RenameToInfo(ByVal sPath As String)
            Try
                Dim i As Integer = 1
                Dim strNewName As String = String.Concat(FileUtils.RemoveExtFromPath(sPath), ".info")
                'in case there is already a .info file
                If File.Exists(strNewName) Then
                    Do
                        strNewName = String.Format("{0}({1}).info", FileUtils.RemoveExtFromPath(sPath), i)
                        i += 1
                    Loop While File.Exists(strNewName)
                    strNewName = String.Format("{0}({1}).info", FileUtils.RemoveExtFromPath(sPath), i)
                End If
                My.Computer.FileSystem.RenameFile(sPath, Path.GetFileName(strNewName))
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Public Shared Sub SaveTVEpToNFO(ByRef tvEpToSave As Structures.DBTV)
            Try

                If Not String.IsNullOrEmpty(tvEpToSave.Filename) Then
                    Dim xmlSer As New XmlSerializer(GetType(MediaContainers.EpisodeDetails))

                    Dim tPath As String = String.Empty
                    Dim doesExist As Boolean = False
                    Dim fAtt As New FileAttributes
                    Dim fAttWritable As Boolean = True
                    Dim EpList As New List(Of MediaContainers.EpisodeDetails)
                    Dim sBuilder As New StringBuilder

                    Dim tmpName As String = Path.GetFileNameWithoutExtension(tvEpToSave.Filename)
                    tPath = String.Concat(Path.Combine(Directory.GetParent(tvEpToSave.Filename).FullName, tmpName), ".nfo")

                    If Not Master.eSettings.OverwriteNfo Then
                        RenameEpNonConfNfo(tPath, False)
                    End If

                    doesExist = File.Exists(tPath)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                        If doesExist Then
                            fAtt = File.GetAttributes(tPath)
                            Try
                                File.SetAttributes(tPath, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If

                        Using SQLCommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                            SQLCommand.CommandText = "SELECT ID FROM TVEps WHERE ID <> (?) AND TVEpPathID IN (SELECT ID FROM TVEpPaths WHERE TVEpPath = (?)) ORDER BY Episode"
                            Dim parID As SQLite.SQLiteParameter = SQLCommand.Parameters.Add("parID", DbType.Int64, 0, "ID")
                            Dim parTVEpPath As SQLite.SQLiteParameter = SQLCommand.Parameters.Add("parTVEpPath", DbType.String, 0, "TVEpPath")

                            parID.Value = tvEpToSave.EpID
                            parTVEpPath.Value = tvEpToSave.Filename

                            Using SQLreader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader
                                While SQLreader.Read
                                    'EpList.Add(Classes.Database.GetTVShowEpisode(Convert.ToInt64(SQLreader("ID"))))
                                End While
                            End Using

                            EpList.Add(tvEpToSave.TVEp)

                            Dim NS As New XmlSerializerNamespaces
                            NS.Add(String.Empty, String.Empty)

                            For Each tvEp As MediaContainers.EpisodeDetails In EpList.OrderBy(Function(s) s.Season)
                                Using xmlSW As New Utf8StringWriter
                                    xmlSer.Serialize(xmlSW, tvEp, NS)
                                    If sBuilder.Length > 0 Then
                                        sBuilder.Append(vbNewLine)
                                        xmlSW.GetStringBuilder.Remove(0, xmlSW.GetStringBuilder.ToString.IndexOf(vbNewLine) + 1)
                                    End If
                                    sBuilder.Append(xmlSW.ToString)
                                End Using
                            Next

                            tvEpToSave.EpNfoPath = tPath

                            If sBuilder.Length > 0 Then
                                Using fSW As New StreamWriter(tPath)
                                    fSW.Write(sBuilder.ToString)
                                End Using
                            End If
                        End Using
                        If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                    End If
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Shared Sub SaveTVShowToNFO(ByRef tvShowToSave As Structures.DBTV)
            '//
            ' Serialize MediaContainers.TVShow to an NFO
            '\\

            Try
                Dim params As New List(Of Object)(New Object() {tvShowToSave})
                Dim doContinue As Boolean = True
                ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.OnTVShowNFOSave, params, doContinue, False)
                If Not doContinue Then Return
            Catch ex As Exception
            End Try

            Try
                If Not String.IsNullOrEmpty(tvShowToSave.ShowPath) Then
                    Dim xmlSer As New XmlSerializer(GetType(MediaContainers.TVShow))

                    Dim tPath As String = String.Empty
                    Dim doesExist As Boolean = False
                    Dim fAtt As New FileAttributes
                    Dim fAttWritable As Boolean = True

                    tPath = Path.Combine(tvShowToSave.ShowPath, "tvshow.nfo")

                    If Not Master.eSettings.OverwriteNfo Then
                        RenameShowNonConfNfo(tPath)
                    End If

                    doesExist = File.Exists(tPath)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(tPath) And FileAttributes.ReadOnly)) Then

                        If doesExist Then
                            fAtt = File.GetAttributes(tPath)
                            Try
                                File.SetAttributes(tPath, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If

                        Using xmlSW As New StreamWriter(tPath)
                            tvShowToSave.ShowNfoPath = tPath
                            xmlSer.Serialize(xmlSW, tvShowToSave.TVShow)
                        End Using

                        If doesExist And fAttWritable Then File.SetAttributes(tPath, fAtt)
                    End If
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        

        Private Shared Sub RenameNonConfNfo(ByVal sPath As String, ByVal isChecked As Boolean)
            'test if current nfo is non-conforming... rename per setting
            Try
                If isChecked OrElse Not IsConformingNfo(sPath) Then
                    If isChecked OrElse File.Exists(sPath) Then
                        RenameToInfo(sPath)
                    End If
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Private Shared Sub RenameShowNonConfNfo(ByVal sPath As String)
            'test if current nfo is non-conforming... rename per setting
            Try
                If File.Exists(sPath) AndAlso Not IsConformingShowNfo(sPath) Then
                    RenameToInfo(sPath)
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        

        Public Shared Sub LoadTVEpDuration(ByVal _TVEpDB As Structures.DBTV)
            'Fix for runtime to display in gui without watching episode first.
            Try
                If Not IsNothing(_TVEpDB.TVEp.FileInfo.StreamDetails) AndAlso _TVEpDB.TVEp.FileInfo.StreamDetails.Video.Count > 0 Then
                    Dim cTotal As String = String.Empty
                    For Each tVid As MediaInfo.Video In _TVEpDB.TVEp.FileInfo.StreamDetails.Video
                        cTotal = cTotal + tVid.Duration
                    Next
                    _TVEpDB.TVEp.Runtime = cTotal
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

#End Region 'Methods

#Region "Nested Types"

        Public Class NonConf

#Region "Fields"

            Private _imdbid As String
            Private _text As String

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property IMDBID() As String
                Get
                    Return Me._imdbid
                End Get
                Set(ByVal value As String)
                    Me._imdbid = value
                End Set
            End Property

            Public Property Text() As String
                Get
                    Return Me._text
                End Get
                Set(ByVal value As String)
                    Me._text = value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._imdbid = String.Empty
                Me._text = String.Empty
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class
End Namespace