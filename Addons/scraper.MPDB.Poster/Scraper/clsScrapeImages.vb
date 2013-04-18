﻿' ################################################################################
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

Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text.RegularExpressions
Imports EmberAPI
Imports RestSharp
Imports WatTmdb


Public Class ScrapeImages

#Region "Fields"

	Private _MySettings As EmberTMDBScraperModule.sMySettings
	Private _TMDBConf As V3.TmdbConfiguration
	Private _TMDBConfE As V3.TmdbConfiguration
	Private _TMDBApi As V3.Tmdb
	Private _TMDBApiE As V3.Tmdb
	Private TMDB As TMDB.Scraper
	Private IMPA As New IMPA.Scraper
	Private MPDB As New MPDB.Scraper
	Private IMDB As New IMDBimg.Scraper
	Private FANARTTVs As FANARTTVs.Scraper

#End Region	'Fields

#Region "Methods"

	Public Sub New(ByRef tTMDBConf As V3.TmdbConfiguration, ByRef tTMDBConfE As V3.TmdbConfiguration, ByRef tTMDBApi As V3.Tmdb, ByRef tTMDBApiE As V3.Tmdb, ByRef tMySettings As EmberTMDBScraperModule.sMySettings)

		' Add any initialization after the InitializeComponent() call.
		_MySettings = tMySettings
		_TMDBApi = tTMDBApi
		_TMDBConf = tTMDBConf
		_TMDBApiE = tTMDBApiE
		_TMDBConfE = tTMDBConfE
		TMDB = New TMDB.Scraper(_TMDBConf, _TMDBConfE, _TMDBApi, _TMDBApiE, _MySettings)
		FANARTTVs = New FANARTTVs.Scraper(_MySettings)
	End Sub

	Public Function GetPreferredImage(ByRef Image As Images, ByVal IMDBID As String, ByVal TMDBID As String, ByVal iType As Enums.ImageType, ByRef imgResult As Containers.ImgResult, ByVal sPath As String, ByVal doETs As Boolean, Optional ByVal doAsk As Boolean = False) As Boolean
		'//
		' Try to get the best match between what the user selected in settings and the actual posters downloaded
		'\\

		Dim hasImages As Boolean = False
		Dim tmpListTMDB As New List(Of MediaContainers.Image)
		Dim tmpListIMPA As New List(Of MediaContainers.Image)
		Dim tmpListIMDB As New List(Of MediaContainers.Image)
		Dim tmpListMPDB As New List(Of MediaContainers.Image)
		Dim tmpIMDBX As Images = Nothing
		Dim tmpIMDBL As Images = Nothing
		Dim tmpIMDBM As Images = Nothing
		Dim tmpIMDBS As Images = Nothing
		Dim tmpIMDBW As Images = Nothing
		Dim tmpTMDBX As Images = Nothing
		Dim tmpTMDBL As Images = Nothing
		Dim tmpTMDBM As Images = Nothing
		Dim tmpTMDBS As Images = Nothing
		Dim tmpTMDBW As Images = Nothing
		Dim tmpIMPAX As Images = Nothing
		Dim tmpIMPAL As Images = Nothing
		Dim tmpIMPAM As Images = Nothing
		Dim tmpIMPAS As Images = Nothing
		Dim tmpIMPAW As Images = Nothing
		Dim tmpMPDBX As Images = Nothing
		Dim tmpMPDBL As Images = Nothing
		Dim tmpMPDBM As Images = Nothing
		Dim tmpMPDBS As Images = Nothing
		Dim tmpMPDBW As Images = Nothing

		Dim CachePath As String = String.Concat(Master.TempPath, Path.DirectorySeparatorChar, IMDBID, Path.DirectorySeparatorChar, If(iType = Enums.ImageType.Posters, "posters", "fanart"))

		Try

			If iType = Enums.ImageType.Posters Then	'posters

				If Master.eSettings.UseImgCacheUpdaters Then
					Dim lFi As New List(Of FileInfo)

					If Not Directory.Exists(CachePath) Then
						Directory.CreateDirectory(CachePath)
					Else
						Dim di As New DirectoryInfo(CachePath)

						Try
							lFi.AddRange(di.GetFiles("*.jpg"))
						Catch
						End Try
					End If

					If lFi.Count > 0 Then
						Dim tImage As MediaContainers.Image
						For Each sFile As FileInfo In lFi
							tImage = New MediaContainers.Image
							tImage.WebImage.FromFile(sFile.FullName)
							Select Case True
								Case sFile.Name.Contains("(original)")
									tImage.Description = "original"
								Case sFile.Name.Contains("(mid)")
									tImage.Description = "mid"
								Case sFile.Name.Contains("(cover)")
									tImage.Description = "cover"
								Case sFile.Name.Contains("(thumb)")
									tImage.Description = "thumb"
								Case sFile.Name.Contains("(poster)")
									tImage.Description = "poster"
							End Select
							tImage.URL = Regex.Match(sFile.Name, "\(url=(.*?)\)").Groups(1).ToString
							If Not Master.eSettings.NoSaveImagesToNfo Then imgResult.Posters.Add(tImage.URL)
							tmpListTMDB.Add(tImage)
							Image.Clear()
						Next
					Else
						tmpListTMDB.AddRange(TMDB.GetTMDBImages(TMDBID, "poster"))

						If _MySettings.UseIMPA Then
							tmpListTMDB.AddRange(IMPA.GetIMPAPosters(IMDBID))
						End If

						If _MySettings.UseMPDB Then
							tmpListMPDB.AddRange(MPDB.GetMPDBPosters(IMDBID))
						End If

						If _MySettings.UseIMDB Then
							tmpListTMDB.AddRange(IMDB.GetIMDBPosters(IMDBID))
						End If

						For Each tmdbThumb As MediaContainers.Image In tmpListTMDB
							tmdbThumb.WebImage.FromWeb(tmdbThumb.URL)
							If Not IsNothing(tmdbThumb.WebImage.Image) Then
								If Not Master.eSettings.NoSaveImagesToNfo Then imgResult.Posters.Add(tmdbThumb.URL)
								Image = tmdbThumb.WebImage
								Image.Save(Path.Combine(CachePath, String.Concat("poster_(", tmdbThumb.Description, ")_(url=", StringUtils.CleanURL(tmdbThumb.URL), ").jpg")), , , False)
							End If
							Image.Clear()
						Next
					End If

					If tmpListTMDB.Count > 0 Then
						hasImages = True

						'remove all entries without images
						For i As Integer = tmpListTMDB.Count - 1 To 0 Step -1
							If IsNothing(tmpListTMDB(i).WebImage.Image) Then
								tmpListTMDB.RemoveAt(i)
							End If
						Next

						For Each iMovie As MediaContainers.Image In tmpListTMDB
							If Images.GetPosterDims(iMovie.WebImage.Image) = Master.eSettings.PreferredPosterSize Then
								Image = iMovie.WebImage
								GoTo foundit
							End If
						Next

						If Not doAsk Then
							Image = tmpListTMDB.OrderBy(Function(i) i.WebImage.Image.Height + i.WebImage.Image.Height).FirstOrDefault.WebImage
						End If
					End If
				Else
					'download all TMBD images
					tmpListTMDB = TMDB.GetTMDBImages(TMDBID, "poster")

					'check each one for it's size to see if it matched the preferred size
					If tmpListTMDB.Count > 0 Then
						hasImages = True

						If Not Master.eSettings.NoSaveImagesToNfo Then
							For Each tmdbThumb As MediaContainers.Image In tmpListTMDB
								imgResult.Posters.Add(tmdbThumb.URL)
							Next
						End If

						For Each iMovie As MediaContainers.Image In tmpListTMDB
							Select Case Master.eSettings.PreferredPosterSize
								Case Enums.PosterSize.Xlrg
									If iMovie.Description.ToLower = "original" Then
										Image.FromWeb(iMovie.URL)
										If Not IsNothing(Image.Image) Then GoTo foundIT
									End If
								Case Enums.PosterSize.Lrg
									If iMovie.Description.ToLower = "mid" Then
										Image.FromWeb(iMovie.URL)
										If Not IsNothing(Image.Image) Then GoTo foundIT
									End If
								Case Enums.PosterSize.Mid
									If iMovie.Description.ToLower = "cover" Then
										Image.FromWeb(iMovie.URL)
										If Not IsNothing(Image.Image) Then GoTo foundIT
									End If
								Case Enums.PosterSize.Small
									If iMovie.Description.ToLower = "thumb" Then
										Image.FromWeb(iMovie.URL)
										If Not IsNothing(Image.Image) Then GoTo foundIT
									End If
									'no "wide" for TMDB
							End Select
							Image.Clear()
						Next
					End If

					If _MySettings.UseIMDB Then
						If IsNothing(Image.Image) Then
							'no poster of the proper size from TMDB found... try IMPA

							tmpListIMDB = IMDB.GetIMDBPosters(IMDBID)

							If tmpListIMDB.Count > 0 Then
								hasImages = True
								For Each iImage As MediaContainers.Image In tmpListIMDB
									Image.FromWeb(iImage.URL)
									If Not IsNothing(Image.Image) Then
										If Not Master.eSettings.NoSaveImagesToNfo Then imgResult.Posters.Add(iImage.URL)
										Dim tmpSize As Enums.PosterSize = Images.GetPosterDims(Image.Image)
										If Not tmpSize = Master.eSettings.PreferredPosterSize Then
											'cache the first result from each type in case the preferred size is not available
											Select Case tmpSize
												Case Enums.PosterSize.Xlrg
													If IsNothing(tmpIMDBX) Then
														tmpIMDBX = Image
													End If
												Case Enums.PosterSize.Lrg
													If IsNothing(tmpIMDBL) Then
														tmpIMDBL = Image
													End If
												Case Enums.PosterSize.Mid
													If IsNothing(tmpIMDBM) Then
														tmpIMDBM = Image
													End If
												Case Enums.PosterSize.Small
													If IsNothing(tmpIMDBS) Then
														tmpIMDBS = Image
													End If
												Case Enums.PosterSize.Wide
													If IsNothing(tmpIMDBW) Then
														tmpIMDBW = Image
													End If
											End Select
										Else
											'image found
											GoTo foundIT
										End If
									End If
									Image.Clear()
								Next
							End If
						End If
					End If

					If _MySettings.UseIMPA Then
						If IsNothing(Image.Image) Then
							'no poster of the proper size from IMDB found... try IMPA

							tmpListIMPA = IMPA.GetIMPAPosters(IMDBID)

							If tmpListIMPA.Count > 0 Then
								hasImages = True
								For Each iImage As MediaContainers.Image In tmpListIMPA
									Image.FromWeb(iImage.URL)
									If Not IsNothing(Image.Image) Then
										If Not Master.eSettings.NoSaveImagesToNfo Then imgResult.Posters.Add(iImage.URL)
										Dim tmpSize As Enums.PosterSize = Images.GetPosterDims(Image.Image)
										If Not tmpSize = Master.eSettings.PreferredPosterSize Then
											'cache the first result from each type in case the preferred size is not available
											Select Case tmpSize
												Case Enums.PosterSize.Xlrg
													If IsNothing(tmpIMPAX) Then
														tmpIMPAX = Image
													End If
												Case Enums.PosterSize.Lrg
													If IsNothing(tmpIMPAL) Then
														tmpIMPAL = Image
													End If
												Case Enums.PosterSize.Mid
													If IsNothing(tmpIMPAM) Then
														tmpIMPAM = Image
													End If
												Case Enums.PosterSize.Small
													If IsNothing(tmpIMPAS) Then
														tmpIMPAS = Image
													End If
												Case Enums.PosterSize.Wide
													If IsNothing(tmpIMPAW) Then
														tmpIMPAW = Image
													End If
											End Select
										Else
											'image found
											GoTo foundIT
										End If
									End If
									Image.Clear()
								Next
							End If
						End If
					End If

					If _MySettings.UseMPDB Then
						If IsNothing(Image.Image) Then
							'no poster of the proper size from TMDB or IMPA found... try MPDB

							tmpListMPDB = MPDB.GetMPDBPosters(IMDBID)

							If tmpListMPDB.Count > 0 Then
								hasImages = True
								For Each iImage As MediaContainers.Image In tmpListMPDB
									Image.FromWeb(iImage.URL)
									If Not IsNothing(Image.Image) Then
										If Not Master.eSettings.NoSaveImagesToNfo Then imgResult.Posters.Add(iImage.URL)
										Dim tmpSize As Enums.PosterSize = Images.GetPosterDims(Image.Image)
										If Not tmpSize = Master.eSettings.PreferredPosterSize Then
											'cache the first result from each type in case the preferred size is not available
											Select Case tmpSize
												Case Enums.PosterSize.Xlrg
													If IsNothing(tmpMPDBX) Then
														tmpMPDBX = Image
													End If
												Case Enums.PosterSize.Lrg
													If IsNothing(tmpMPDBL) Then
														tmpMPDBL = Image
													End If
												Case Enums.PosterSize.Mid
													If IsNothing(tmpMPDBM) Then
														tmpMPDBM = Image
													End If
												Case Enums.PosterSize.Small
													If IsNothing(tmpMPDBS) Then
														tmpMPDBS = Image
													End If
												Case Enums.PosterSize.Wide
													If IsNothing(tmpMPDBW) Then
														tmpMPDBW = Image
													End If
											End Select
										Else
											'image found
											GoTo foundIT
										End If
									End If
									Image.Clear()
								Next
							End If
						End If
					End If

					If IsNothing(Image.Image) AndAlso Not doAsk Then
						'STILL no image found, just get the first available image, starting with the largest
						'check TMDB first
						If tmpListTMDB.Count > 0 Then
							Dim x = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "original"
							If x.Count > 0 Then
								Image.FromWeb(x(0).URL)
								If Not IsNothing(Image.Image) Then GoTo foundIT
							End If

							Dim l = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "mid"
							If l.Count > 0 Then
								Image.FromWeb(l(0).URL)
								If Not IsNothing(Image.Image) Then GoTo foundIT
							End If

							Dim m = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "cover"
							If m.Count > 0 Then
								Image.FromWeb(m(0).URL)
								If Not IsNothing(Image.Image) Then GoTo foundIT
							End If

							Dim s = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "thumb"
							If s.Count > 0 Then
								Image.FromWeb(s(0).URL)
								If Not IsNothing(Image.Image) Then GoTo foundIT
							End If

						End If

						Image.Clear()

						If _MySettings.UseIMDB Then
							If tmpListIMDB.Count > 0 Then
								If Not IsNothing(tmpIMDBX) Then
									Image = tmpIMDBX
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMDBL) Then
									Image = tmpIMDBL
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMDBM) Then
									Image = tmpIMDBM
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMDBS) Then
									Image = tmpIMDBS
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMDBW) Then
									Image = tmpIMDBW
									GoTo foundIT
								End If
							End If
						End If

						If _MySettings.UseIMPA Then
							If tmpListIMPA.Count > 0 Then
								If Not IsNothing(tmpIMPAX) Then
									Image = tmpIMPAX
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMPAL) Then
									Image = tmpIMPAL
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMPAM) Then
									Image = tmpIMPAM
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMPAS) Then
									Image = tmpIMPAS
									GoTo foundIT
								End If
								If Not IsNothing(tmpIMPAW) Then
									Image = tmpIMPAW
									GoTo foundIT
								End If
							End If
						End If

						Image.Clear()

						If _MySettings.UseMPDB Then
							If tmpListMPDB.Count > 0 Then
								If Not IsNothing(tmpMPDBX) Then
									Image = tmpMPDBX
									GoTo foundIT
								End If
								If Not IsNothing(tmpMPDBL) Then
									Image = tmpMPDBL
									GoTo foundIT
								End If
								If Not IsNothing(tmpMPDBM) Then
									Image = tmpMPDBM
									GoTo foundIT
								End If
								If Not IsNothing(tmpMPDBS) Then
									Image = tmpMPDBS
									GoTo foundIT
								End If
								If Not IsNothing(tmpMPDBW) Then
									Image = tmpMPDBW
									GoTo foundIT
								End If
							End If
						End If

						Image.Clear()

					End If

				End If

			Else 'fanart

				Dim ETHashes As New List(Of String)
				If Master.eSettings.AutoET AndAlso doETs Then
					ETHashes = HashFile.CurrentETHashes(sPath)
				End If

				If Master.eSettings.UseImgCacheUpdaters Then
					Dim lFi As New List(Of FileInfo)

					If Not Directory.Exists(CachePath) Then
						Directory.CreateDirectory(CachePath)
					Else
						Dim di As New DirectoryInfo(CachePath)

						Try
							lFi.AddRange(di.GetFiles("*.jpg"))
						Catch
						End Try
					End If

					If lFi.Count > 0 Then
						Dim tImage As MediaContainers.Image
						For Each sFile As FileInfo In lFi
							tImage = New MediaContainers.Image
							tImage.WebImage.FromFile(sFile.FullName)
							Select Case True
								Case sFile.Name.Contains("(original)")
									tImage.Description = "original"
									If Master.eSettings.AutoET AndAlso doETs AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
										If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
											Image.SaveFAasET(sFile.FullName, sPath)
										End If
									End If
								Case sFile.Name.Contains("(mid)")
									tImage.Description = "mid"
									If Master.eSettings.AutoET AndAlso doETs AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
										If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
											Image.SaveFAasET(sFile.FullName, sPath)
										End If
									End If
								Case sFile.Name.Contains("(thumb)")
									tImage.Description = "thumb"
									If Master.eSettings.AutoET AndAlso doETs AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
										If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
											Image.SaveFAasET(sFile.FullName, sPath)
										End If
									End If
							End Select
							tImage.URL = Regex.Match(sFile.Name, "\(url=(.*?)\)").Groups(1).ToString
							tmpListTMDB.Add(tImage)
							Image.Clear()
						Next
					Else
						'download all the fanart from TMDB
						tmpListTMDB = TMDB.GetTMDBImages(TMDBID, "backdrop")

						If tmpListTMDB.Count > 0 Then

							'setup fanart for nfo
							Dim thumbLink As String = String.Empty
							imgResult.Fanart.URL = "http://images.themoviedb.org"
							For Each miFanart As MediaContainers.Image In tmpListTMDB
								miFanart.WebImage.FromWeb(miFanart.URL)
								If Not IsNothing(miFanart.WebImage.Image) Then
									Image = miFanart.WebImage
									Dim savePath As String = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
									Image.Save(savePath, , , False)
									If Master.eSettings.AutoET AndAlso doETs Then
										Select Case miFanart.Description.ToLower
											Case "original"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
													If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
														Image.SaveFAasET(savePath, sPath)
													End If
												End If
											Case "mid"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
													If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
														Image.SaveFAasET(savePath, sPath)
													End If
												End If
											Case "thumb"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
													If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
														Image.SaveFAasET(savePath, sPath)
													End If
												End If
										End Select
									End If
									If Not Master.eSettings.NoSaveImagesToNfo Then
										If Not miFanart.URL.Contains("_thumb.") Then
											thumbLink = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)
											If thumbLink.Contains("_poster.") Then
												thumbLink = thumbLink.Replace("_poster.", "_thumb.")
											Else
												thumbLink = thumbLink.Insert(thumbLink.LastIndexOf("."), "_thumb")
											End If
											imgResult.Fanart.Thumb.Add(New MediaContainers.Thumb With {.Preview = thumbLink, .Text = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)})
										End If
									End If
								End If
								Image.Clear()
							Next
						Else
							If _MySettings.UseFANARTTV Then
								tmpListTMDB = FANARTTVs.GetFANARTTVImages(IMDBID)

								If tmpListTMDB.Count > 0 Then

									'setup fanart for nfo
									Dim thumbLink As String = String.Empty
									imgResult.Fanart.URL = "http://fanart.tv"
									For Each miFanart As MediaContainers.Image In tmpListTMDB
										miFanart.WebImage.FromWeb(miFanart.URL)
										If Not IsNothing(miFanart.WebImage.Image) Then
											Image = miFanart.WebImage
											Dim savePath As String = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
											Image.Save(savePath, , , False)
											If Master.eSettings.AutoET AndAlso doETs Then
												Select Case miFanart.Description.ToLower
													Case "original"
														If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
															If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
																Image.SaveFAasET(savePath, sPath)
															End If
														End If
													Case "mid"
														If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
															If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
																Image.SaveFAasET(savePath, sPath)
															End If
														End If
													Case "thumb"
														If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
															If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
																Image.SaveFAasET(savePath, sPath)
															End If
														End If
												End Select
											End If
											If Not Master.eSettings.NoSaveImagesToNfo Then
												If Not miFanart.URL.Contains("_thumb.") Then
													thumbLink = miFanart.URL.Replace("http://fanart.tv", String.Empty)
													If thumbLink.Contains("_poster.") Then
														thumbLink = thumbLink.Replace("_poster.", "_thumb.")
													Else
														thumbLink = thumbLink.Insert(thumbLink.LastIndexOf("."), "_thumb")
													End If
													imgResult.Fanart.Thumb.Add(New MediaContainers.Thumb With {.Preview = thumbLink, .Text = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)})
												End If
											End If
										End If
										Image.Clear()
									Next
								End If
							End If

							If tmpListTMDB.Count > 0 Then
								hasImages = True
								'remove all entries without images
								For i As Integer = tmpListTMDB.Count - 1 To 0 Step -1
									If IsNothing(tmpListTMDB(i).WebImage.Image) Then
										tmpListTMDB.RemoveAt(i)
									End If
								Next

								For Each iMovie As MediaContainers.Image In tmpListTMDB
									If Images.GetFanartDims(iMovie.WebImage.Image) = Master.eSettings.PreferredFanartSize Then
										Image = iMovie.WebImage
										GoTo foundit
									End If
								Next

								Image.Clear()

								If Not doAsk Then
									Image = tmpListTMDB.OrderBy(Function(i) i.WebImage.Image.Height + i.WebImage.Image.Height).FirstOrDefault.WebImage
								End If

							End If
						End If
					End If

				Else
					'download all the fanart from TMDB
					tmpListTMDB = TMDB.GetTMDBImages(TMDBID, "backdrop")

					If tmpListTMDB.Count > 0 Then
						hasImages = True

						'setup fanart for nfo
						Dim thumbLink As String = String.Empty
						If Not Master.eSettings.NoSaveImagesToNfo Then
							imgResult.Fanart.URL = "http://images.themoviedb.org"
							For Each miFanart As MediaContainers.Image In tmpListTMDB
								If Not miFanart.URL.Contains("_thumb.") Then
									thumbLink = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)
									If thumbLink.Contains("_poster.") Then
										thumbLink = thumbLink.Replace("_poster.", "_thumb.")
									Else
										thumbLink = thumbLink.Insert(thumbLink.LastIndexOf("."), "_thumb")
									End If
									imgResult.Fanart.Thumb.Add(New MediaContainers.Thumb With {.Preview = thumbLink, .Text = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)})
								End If
							Next
						End If

						If Master.eSettings.AutoET AndAlso doETs Then

							If Not Directory.Exists(CachePath) Then
								Directory.CreateDirectory(CachePath)
							End If

							Dim savePath As String = String.Empty
							For Each miFanart As MediaContainers.Image In tmpListTMDB
								Select Case miFanart.Description.ToLower
									Case "original"
										If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
											miFanart.WebImage.FromWeb(miFanart.URL)
											If Not IsNothing(miFanart.WebImage.Image) Then
												Image = miFanart.WebImage
												savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
												Image.Save(savePath, , , False)
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													Image.SaveFAasET(savePath, sPath)
												End If
											End If
										End If
									Case "mid"
										If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
											miFanart.WebImage.FromWeb(miFanart.URL)
											If Not IsNothing(miFanart.WebImage.Image) Then
												Image = miFanart.WebImage
												savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
												Image.Save(savePath, , , False)
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													Image.SaveFAasET(savePath, sPath)
												End If
											End If
										End If
									Case "thumb"
										If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
											miFanart.WebImage.FromWeb(miFanart.URL)
											If Not IsNothing(miFanart.WebImage.Image) Then
												Image = miFanart.WebImage
												savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
												Image.Save(savePath, , , False)
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													Image.SaveFAasET(savePath, sPath)
												End If
											End If
										End If
								End Select
							Next

							Image.Clear()
							FileUtils.Delete.DeleteDirectory(CachePath)
						End If

						For Each iMovie As MediaContainers.Image In tmpListTMDB
							Select Case Master.eSettings.PreferredFanartSize
								Case Enums.FanartSize.Lrg
									If iMovie.Description.ToLower = "original" Then
										If Not IsNothing(iMovie.WebImage.Image) Then
											Image = iMovie.WebImage
										Else
											Image.FromWeb(iMovie.URL)
										End If
										GoTo foundIT
									End If
								Case Enums.FanartSize.Mid
									If iMovie.Description.ToLower = "mid" Then
										If Not IsNothing(iMovie.WebImage.Image) Then
											Image = iMovie.WebImage
										Else
											Image.FromWeb(iMovie.URL)
										End If
										GoTo foundIT
									End If
								Case Enums.FanartSize.Small
									If iMovie.Description.ToLower = "thumb" Then
										If Not IsNothing(iMovie.WebImage.Image) Then
											Image = iMovie.WebImage
										Else
											Image.FromWeb(iMovie.URL)
										End If
										GoTo foundIT
									End If
							End Select
						Next

						Image.Clear()

						If IsNothing(Image.Image) AndAlso Not doAsk Then

							'STILL no image found, just get the first available image, starting with the largest

							Dim l = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "original"
							If l.Count > 0 Then
								Image.FromWeb(l(0).URL)
								GoTo foundIT
							End If

							Dim m = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "mid"
							If m.Count > 0 Then
								Image.FromWeb(m(0).URL)
								GoTo foundIT
							End If

							Dim s = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "thumb"
							If s.Count > 0 Then
								Image.FromWeb(s(0).URL)
								GoTo foundIT
							End If

						End If

						Image.Clear()
					Else
						If _MySettings.UseFANARTTV Then
							tmpListTMDB = FANARTTVs.GetFANARTTVImages(IMDBID)
							If tmpListTMDB.Count > 0 Then
								hasImages = True

								'setup fanart for nfo
								Dim thumbLink As String = String.Empty
								If Not Master.eSettings.NoSaveImagesToNfo Then
									imgResult.Fanart.URL = "http://fanart.tv"
									For Each miFanart As MediaContainers.Image In tmpListTMDB
										If Not miFanart.URL.Contains("_thumb.") Then
											thumbLink = miFanart.URL.Replace("http://fanart.tv", String.Empty)
											If thumbLink.Contains("_poster.") Then
												thumbLink = thumbLink.Replace("_poster.", "_thumb.")
											Else
												thumbLink = thumbLink.Insert(thumbLink.LastIndexOf("."), "_thumb")
											End If
											imgResult.Fanart.Thumb.Add(New MediaContainers.Thumb With {.Preview = thumbLink, .Text = miFanart.URL.Replace("http://images.themoviedb.org", String.Empty)})
										End If
									Next
								End If

								If Master.eSettings.AutoET AndAlso doETs Then

									If Not Directory.Exists(CachePath) Then
										Directory.CreateDirectory(CachePath)
									End If

									Dim savePath As String = String.Empty
									For Each miFanart As MediaContainers.Image In tmpListTMDB
										Select Case miFanart.Description.ToLower
											Case "original"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
													miFanart.WebImage.FromWeb(miFanart.URL)
													If Not IsNothing(miFanart.WebImage.Image) Then
														Image = miFanart.WebImage
														savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
														Image.Save(savePath, , , False)
														If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
															Image.SaveFAasET(savePath, sPath)
														End If
													End If
												End If
											Case "mid"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
													miFanart.WebImage.FromWeb(miFanart.URL)
													If Not IsNothing(miFanart.WebImage.Image) Then
														Image = miFanart.WebImage
														savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
														Image.Save(savePath, , , False)
														If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
															Image.SaveFAasET(savePath, sPath)
														End If
													End If
												End If
											Case "thumb"
												If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
													miFanart.WebImage.FromWeb(miFanart.URL)
													If Not IsNothing(miFanart.WebImage.Image) Then
														Image = miFanart.WebImage
														savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
														Image.Save(savePath, , , False)
														If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
															Image.SaveFAasET(savePath, sPath)
														End If
													End If
												End If
										End Select
									Next

									Image.Clear()
									FileUtils.Delete.DeleteDirectory(CachePath)
								End If

								For Each iMovie As MediaContainers.Image In tmpListTMDB
									Select Case Master.eSettings.PreferredFanartSize
										Case Enums.FanartSize.Lrg
											If iMovie.Description.ToLower = "original" Then
												If Not IsNothing(iMovie.WebImage.Image) Then
													Image = iMovie.WebImage
												Else
													Image.FromWeb(iMovie.URL)
												End If
												GoTo foundIT
											End If
										Case Enums.FanartSize.Mid
											If iMovie.Description.ToLower = "mid" Then
												If Not IsNothing(iMovie.WebImage.Image) Then
													Image = iMovie.WebImage
												Else
													Image.FromWeb(iMovie.URL)
												End If
												GoTo foundIT
											End If
										Case Enums.FanartSize.Small
											If iMovie.Description.ToLower = "thumb" Then
												If Not IsNothing(iMovie.WebImage.Image) Then
													Image = iMovie.WebImage
												Else
													Image.FromWeb(iMovie.URL)
												End If
												GoTo foundIT
											End If
									End Select
								Next

								Image.Clear()

								If IsNothing(Image.Image) AndAlso Not doAsk Then

									'STILL no image found, just get the first available image, starting with the largest

									Dim l = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "original"
									If l.Count > 0 Then
										Image.FromWeb(l(0).URL)
										GoTo foundIT
									End If

									Dim m = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "mid"
									If m.Count > 0 Then
										Image.FromWeb(m(0).URL)
										GoTo foundIT
									End If

									Dim s = From MI As MediaContainers.Image In tmpListTMDB Where MI.Description = "thumb"
									If s.Count > 0 Then
										Image.FromWeb(s(0).URL)
										GoTo foundIT
									End If

								End If

								Image.Clear()
							End If
						End If
					End If
				End If
			End If
		Catch ex As Exception
			Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
		End Try

foundIT:
		tmpListTMDB = Nothing
		tmpListIMPA = Nothing
		tmpListMPDB = Nothing
		Return hasImages
	End Function

	Public Sub GetPreferredFAasET(ByVal IMDBID As String, ByVal sPath As String)
		Dim _Image As Image

		If AdvancedSettings.GetBooleanSetting("tUseTMDB", True) Then

			Dim tmpListTMDB As New List(Of MediaContainers.Image)
			Dim ETHashes As New List(Of String)

			Dim CachePath As String = String.Concat(Master.TempPath, Path.DirectorySeparatorChar, IMDBID, Path.DirectorySeparatorChar, "fanart")

			If Master.eSettings.AutoET Then
				ETHashes = HashFile.CurrentETHashes(sPath)
			End If

			If Master.eSettings.UseImgCacheUpdaters Then
				Dim lFi As New List(Of FileInfo)

				If Not Directory.Exists(CachePath) Then
					Directory.CreateDirectory(CachePath)
				Else
					Dim di As New DirectoryInfo(CachePath)

					Try
						lFi.AddRange(di.GetFiles("*.jpg"))
					Catch
					End Try
				End If

				If lFi.Count > 0 Then
					For Each sFile As FileInfo In lFi
						Select Case True
							Case sFile.Name.Contains("(original)")
								If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
									If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
										SaveFAasET(sFile.FullName, sPath)
									End If
								End If
							Case sFile.Name.Contains("(mid)")
								If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
									If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
										SaveFAasET(sFile.FullName, sPath)
									End If
								End If
							Case sFile.Name.Contains("(thumb)")
								If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
									If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
										SaveFAasET(sFile.FullName, sPath)
									End If
								End If
						End Select
					Next
				Else
					'download all the fanart from TMDB
					tmpListTMDB = TMDB.GetTMDBImages(IMDBID, "backdrop")

					If tmpListTMDB.Count > 0 Then

						'setup fanart for nfo
						Dim thumbLink As String = String.Empty
						For Each miFanart As MediaContainers.Image In tmpListTMDB
							miFanart.WebImage.FromWeb(miFanart.URL)
							If Not IsNothing(miFanart.WebImage.Image) Then
								_Image = miFanart.WebImage.Image
								Dim savePath As String = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
								miFanart.WebImage.Save(savePath, , , False)
								If Master.eSettings.AutoET Then
									Select Case miFanart.Description.ToLower
										Case "original"
											If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													SaveFAasET(savePath, sPath)
												End If
											End If
										Case "mid"
											If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													SaveFAasET(savePath, sPath)
												End If
											End If
										Case "thumb"
											If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
												If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
													SaveFAasET(savePath, sPath)
												End If
											End If
									End Select
								End If
							End If
						Next
					End If
				End If
			Else
				'download all the fanart from TMDB
				tmpListTMDB = TMDB.GetTMDBImages(IMDBID, "backdrop")

				If tmpListTMDB.Count > 0 Then

					If Not Directory.Exists(CachePath) Then
						Directory.CreateDirectory(CachePath)
					End If

					Dim savePath As String = String.Empty
					For Each miFanart As MediaContainers.Image In tmpListTMDB
						Select Case miFanart.Description.ToLower
							Case "original"
								If Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
									miFanart.WebImage.FromWeb(miFanart.URL)
									If Not IsNothing(miFanart.WebImage.Image) Then
										_Image = miFanart.WebImage.Image
										savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
										miFanart.WebImage.Save(savePath, , , False)
										If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
											SaveFAasET(savePath, sPath)
										End If
									End If
								End If
							Case "mid"
								If Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
									miFanart.WebImage.FromWeb(miFanart.URL)
									If Not IsNothing(miFanart.WebImage.Image) Then
										_Image = miFanart.WebImage.Image
										savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
										miFanart.WebImage.Save(savePath, , , False)
										If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
											SaveFAasET(savePath, sPath)
										End If
									End If
								End If
							Case "thumb"
								If Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
									miFanart.WebImage.FromWeb(miFanart.URL)
									If Not IsNothing(miFanart.WebImage.Image) Then
										_Image = miFanart.WebImage.Image
										savePath = Path.Combine(CachePath, String.Concat("fanart_(", miFanart.Description, ")_(url=", StringUtils.CleanURL(miFanart.URL), ").jpg"))
										miFanart.WebImage.Save(savePath, , , False)
										If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
											SaveFAasET(savePath, sPath)
										End If
									End If
								End If
						End Select
						'Me.Clear()
					Next

					_Image = Nothing
					FileUtils.Delete.DeleteDirectory(CachePath)

				End If
			End If
		End If
	End Sub

	Public Function IsAllowedToDownload(ByVal mMovie As Structures.DBMovie, ByVal fType As Enums.ImageType, Optional ByVal isChange As Boolean = False) As Boolean
		Try
			Select Case fType
				Case Enums.ImageType.Fanart
					If (isChange OrElse (String.IsNullOrEmpty(mMovie.FanartPath) OrElse Master.eSettings.OverwriteFanart)) AndAlso _
					(Master.eSettings.MovieNameDotFanartJPG OrElse Master.eSettings.MovieNameFanartJPG OrElse Master.eSettings.FanartJPG) AndAlso _
					AdvancedSettings.GetBooleanSetting("tUseTMDB", True) Then
						Return True
					Else
						Return False
					End If
				Case Else
					If (isChange OrElse (String.IsNullOrEmpty(mMovie.PosterPath) OrElse Master.eSettings.OverwritePoster)) AndAlso _
					(Master.eSettings.MovieTBN OrElse Master.eSettings.MovieNameTBN OrElse Master.eSettings.MovieJPG OrElse _
					 Master.eSettings.MovieNameJPG OrElse Master.eSettings.PosterTBN OrElse Master.eSettings.PosterJPG OrElse Master.eSettings.FolderJPG) AndAlso _
					 (AdvancedSettings.GetBooleanSetting("tUseIMPA", False) OrElse AdvancedSettings.GetBooleanSetting("UseMPDB", False) OrElse AdvancedSettings.GetBooleanSetting("UseTMDB", True)) Then
						Return True
					Else
						Return False
					End If
			End Select
		Catch ex As Exception
			Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
			Return False
		End Try
	End Function
	Public Shared Sub SaveFAasET(ByVal faPath As String, ByVal inPath As String)
		Dim iMod As Integer = 0
		Dim iVal As Integer = 1
		Dim extraPath As String = String.Empty

		If Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isVideoTS(inPath) Then
			extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(inPath).FullName).FullName, "extrathumbs")
		ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isBDRip(inPath) Then
			extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(inPath).FullName).FullName).FullName, "extrathumbs")
		Else
			extraPath = Path.Combine(Directory.GetParent(inPath).FullName, "extrathumbs")
		End If

		iMod = Functions.GetExtraModifier(extraPath)
		iVal = iMod + 1

		If Not Directory.Exists(extraPath) Then
			Directory.CreateDirectory(extraPath)
		End If

		FileUtils.Common.MoveFileWithStream(faPath, Path.Combine(extraPath, String.Concat("thumb", iVal, ".jpg")))
	End Sub


	'Public Shared Sub Save(ByVal _image As Image, ByVal sPath As String, Optional ByVal iQuality As Long = 0)
	'	Try
	'		If IsNothing(_image) Then Exit Sub

	'		Dim doesExist As Boolean = File.Exists(sPath)
	'		Dim fAtt As New FileAttributes
	'		If Not String.IsNullOrEmpty(sPath) AndAlso (Not doesExist OrElse (Not CBool(File.GetAttributes(sPath) And FileAttributes.ReadOnly))) Then
	'			If doesExist Then
	'				'get the current attributes to set them back after writing
	'				fAtt = File.GetAttributes(sPath)
	'				'set attributes to none for writing
	'				File.SetAttributes(sPath, FileAttributes.Normal)
	'			End If

	'			Using msSave As New MemoryStream
	'				Dim retSave() As Byte
	'				Dim ICI As ImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg)
	'				Dim EncPars As EncoderParameters = New EncoderParameters(If(iQuality > 0, 2, 1))

	'				EncPars.Param(0) = New EncoderParameter(Encoder.RenderMethod, EncoderValue.RenderNonProgressive)

	'				If iQuality > 0 Then
	'					EncPars.Param(1) = New EncoderParameter(Encoder.Quality, iQuality)
	'				End If

	'				_image.Save(msSave, ICI, EncPars)

	'				retSave = msSave.ToArray

	'				Using fs As New FileStream(sPath, FileMode.Create, FileAccess.Write)
	'					fs.Write(retSave, 0, retSave.Length)
	'					fs.Flush()
	'				End Using
	'				msSave.Flush()
	'			End Using

	'			If doesExist Then File.SetAttributes(sPath, fAtt)
	'		End If
	'	Catch ex As Exception
	'		Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
	'	End Try
	'End Sub
	Private Shared Function GetEncoderInfo(ByVal Format As ImageFormat) As ImageCodecInfo
		Dim Encoders() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()

		For i As Integer = 0 To UBound(Encoders)
			If Encoders(i).FormatID = Format.Guid Then
				Return Encoders(i)
			End If
		Next

		Return Nothing
	End Function
#End Region	'Methods



End Class