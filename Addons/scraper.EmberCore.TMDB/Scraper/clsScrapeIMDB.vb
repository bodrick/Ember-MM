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
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports EmberAPI

Namespace IMDBimg

	Public Class Scraper

#Region "Fields"



		Friend WithEvents bwIMDBimg As New System.ComponentModel.BackgroundWorker

#End Region	'Fields

#Region "Events"

		Public Event PostersDownloaded(ByVal Posters As List(Of MediaContainers.Image))

		Public Event ProgressUpdated(ByVal iPercent As Integer)

#End Region	'Events

#Region "Methods"

		Public Sub Cancel()
			If Me.bwIMDBimg.IsBusy Then Me.bwIMDBimg.CancelAsync()

			While Me.bwIMDBimg.IsBusy
				Application.DoEvents()
				Threading.Thread.Sleep(50)
			End While
		End Sub

		Public Sub GetImagesAsync(ByVal sURL As String)
			Try
				If Not bwIMDBimg.IsBusy Then
					bwIMDBimg.WorkerSupportsCancellation = True
					bwIMDBimg.WorkerReportsProgress = True
					bwIMDBimg.RunWorkerAsync(New Arguments With {.Parameter = sURL})
				End If
			Catch ex As Exception
				Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
			End Try
		End Sub

		Public Function GetIMDBPosters(ByVal imdbID As String) As List(Of MediaContainers.Image)
			Dim alPoster As New List(Of MediaContainers.Image)

			Try
				If bwIMDBimg.CancellationPending Then Return Nothing
				Dim sHTTP As New HTTP
				Dim HTML As String = sHTTP.DownloadData(String.Concat("http://www.imdb.com/title/tt", imdbID, ""))
				sHTTP = Nothing
				' check existence of a line like this
				'      <a href="/media/rm2995297536/tt0089218?ref_=tt_ov_i" > <img height="317"
				' and then return this one
				'      src = "http://ia.media-imdb.com/images/M/MV5BMTY1Mzk3MTg0M15BMl5BanBnXkFtZTcwOTQzODYyMQ@@._V1_SY317_CR3,0,214,317_.jpg"
				Dim mcIMDB As MatchCollection = Regex.Matches(HTML, String.Concat("/media/[a-zA-Z0-9]{3,12}/tt", imdbID, "\?ref_=tt_ov_i"), RegexOptions.IgnoreCase)
				If mcIMDB.Count > 0 Then
					'Dim sUrl1 As String = sHTTP.DownloadData(mcIMDB(0).Value)

					mcIMDB = Regex.Matches(HTML, "http://ia.media-imdb.com/images/.{3,80}?.jpg")
					If mcIMDB.Count > 0 Then
						'just use the first one if more are found
						alPoster.Add(New MediaContainers.Image With {.Description = "thumb", .URL = mcIMDB(0).Value})
					End If

					Dim aSP As String() = Regex.Split(mcIMDB(0).Value, "SY\d+?_CR\d+?,\d+?,\d+?,\d+?_")
					Dim sUrl1 = aSP(0) + aSP(1)
					alPoster.Add(New MediaContainers.Image With {.Description = "poster", .URL = sUrl1})
					'sHTTP = New HTTP
					'HTML = sUrl1
					'sHTTP = Nothing
					'mcIMDB = Regex.Matches(HTML, "http://ia.media-imdb.com/images/.{3,60}?.jpg")
					'If mcIMDB.Count > 0 Then
					'	'just use the first one if more are found
					'	alPoster.Add(New MediaContainers.Image With {.Description = "poster", .URL = mcIMDB(0).Value})
					'End If
				End If

				'Dim sURL As String = GetLink(imdbID)


				'If Not String.IsNullOrEmpty(sURL) Then

				'	Dim sHTTP As New HTTP
				'	Dim HTML As String = sHTTP.DownloadData(sURL)
				'	sHTTP = Nothing

				'	If bwIMDBimg.CancellationPending Then Return Nothing

				'	Dim mcPoster As MatchCollection = Regex.Matches(HTML, "(thumbs/imp_([^>]*ver[^>]*.jpg))|(thumbs/imp_([^>]*.jpg))")

				'	Dim PosterURL As String

				'	For Each mPoster As Match In mcPoster
				'		If bwIMDBimg.CancellationPending Then Return Nothing
				'		PosterURL = Strings.Replace(String.Format("{0}/{1}", sURL.Substring(0, sURL.LastIndexOf("/")), mPoster.Value.ToString()).Replace("thumbs", "posters"), "imp_", String.Empty)


				'		PosterURL = PosterURL.Insert(PosterURL.LastIndexOf("."), "_xlg")
				'		alPoster.Add(New MediaContainers.Image With {.Description = "original", .URL = PosterURL})
				'	Next
				'End If
			Catch ex As Exception
				Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
			End Try

			Return alPoster
		End Function

		Private Sub bwIMDBimg_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwIMDBimg.DoWork
			Dim Args As Arguments = DirectCast(e.Argument, Arguments)
			Try
				e.Result = GetIMDBPosters(Args.Parameter)
			Catch ex As Exception
				Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
				e.Result = Nothing
			End Try
		End Sub

		Private Sub bwIMDBimg_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwIMDBimg.ProgressChanged
			If Not bwIMDBimg.CancellationPending Then
				RaiseEvent ProgressUpdated(e.ProgressPercentage)
			End If
		End Sub

		Private Sub bwIMDBimg_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwIMDBimg.RunWorkerCompleted
			If Not IsNothing(e.Result) Then
				RaiseEvent PostersDownloaded(DirectCast(e.Result, List(Of MediaContainers.Image)))
			End If
		End Sub


#End Region	'Methods

#Region "Nested Types"

		Private Structure Arguments

#Region "Fields"

			Dim Parameter As String
			Dim sType As String

#End Region	'Fields

		End Structure

		Private Structure Results

#Region "Fields"

			Dim Result As Object
			Dim ResultList As List(Of MediaContainers.Image)

#End Region	'Fields

		End Structure

#End Region	'Nested Types

	End Class

End Namespace

