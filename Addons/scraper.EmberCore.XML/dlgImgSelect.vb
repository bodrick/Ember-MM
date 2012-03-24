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

Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports EmberAPI

Public Class dlgImgSelect

    #Region "Fields"

    Friend WithEvents bwDownload As New System.ComponentModel.BackgroundWorker

    Private CachePath As String = String.Empty
    Private chkImage() As CheckBox
    Private DLType As Enums.ImageType
    Private ETHashes As New List(Of String)
    Private iCounter As Integer = 0
    Private iLeft As Integer = 5
    Private MovieImages As New List(Of MediaContainers.Image)
    Private isEdit As Boolean = False
    Private isShown As Boolean = False
    Private iTop As Integer = 5
    Private lblImage() As Label
    Private noImages As Boolean = False
    Private pbImage() As PictureBox
    Private pnlImage() As Panel
    Private PreDL As Boolean = False
    Private Results As New Containers.ImgResult
    Private selIndex As Integer = -1
    Private tMovie As New Structures.DBMovie
    Private tmpImage As New Images

#End Region 'Fields

#Region "Events"

    Private Event EventImagesDone()

#End Region 'Events

#Region "Methods"

    Public Sub PreLoad(ByVal mMovie As Structures.DBMovie, ByVal _DLType As Enums.ImageType, Optional ByVal _isEdit As Boolean = False)
        Me.tMovie = mMovie
        Me.DLType = _DLType
        Me.isEdit = _isEdit
        Me.PreDL = True
        Me.SetUp()
        Me.StartDownload()
    End Sub

    Public Overloads Function ShowDialog(ByVal mMovie As Structures.DBMovie, ByVal _DLType As Enums.ImageType, Optional ByVal _isEdit As Boolean = False) As Containers.ImgResult
        '//
        ' Overload to pass data
        '\\

        Me.tMovie = mMovie
        Me.DLType = _DLType
        Me.isEdit = _isEdit
        Me.isShown = True

        MyBase.ShowDialog()
        Return Results
    End Function

    Public Overloads Function ShowDialog() As Containers.ImgResult
        Me.isShown = True
        MyBase.ShowDialog()

        Return Results
    End Function

    Private Sub AddImage(ByVal iImage As Image, ByVal sDescription As String, ByVal iIndex As Integer, ByVal sURL As String, ByVal isChecked As Boolean)
        Try
            ReDim Preserve Me.pnlImage(iIndex)
            ReDim Preserve Me.pbImage(iIndex)
            Me.pnlImage(iIndex) = New Panel()
            Me.pbImage(iIndex) = New PictureBox()
            Me.pbImage(iIndex).Name = iIndex.ToString
            Me.pnlImage(iIndex).Name = iIndex.ToString
            Me.pnlImage(iIndex).Size = New Size(256, 286)
            Me.pbImage(iIndex).Size = New Size(250, 250)
            Me.pnlImage(iIndex).BackColor = Color.White
            Me.pnlImage(iIndex).BorderStyle = BorderStyle.FixedSingle
            Me.pbImage(iIndex).SizeMode = PictureBoxSizeMode.Zoom
            Me.pnlImage(iIndex).Tag = sURL
            Me.pbImage(iIndex).Tag = sURL
            Me.pbImage(iIndex).Image = iImage
            Me.pnlImage(iIndex).Left = iLeft
            Me.pbImage(iIndex).Left = 3
            Me.pnlImage(iIndex).Top = iTop
            Me.pbImage(iIndex).Top = 3
            Me.pnlBG.Controls.Add(Me.pnlImage(iIndex))
            Me.pnlImage(iIndex).Controls.Add(Me.pbImage(iIndex))
            Me.pnlImage(iIndex).BringToFront()
            AddHandler pbImage(iIndex).Click, AddressOf pbImage_Click
            AddHandler pbImage(iIndex).DoubleClick, AddressOf pbImage_DoubleClick
            AddHandler pnlImage(iIndex).Click, AddressOf pnlImage_Click

            AddHandler pbImage(iIndex).MouseWheel, AddressOf MouseWheelEvent
            AddHandler pnlImage(iIndex).MouseWheel, AddressOf MouseWheelEvent

            If Me.DLType = Enums.ImageType.Fanart Then
                ReDim Preserve Me.chkImage(iIndex)
                Me.chkImage(iIndex) = New CheckBox()
                Me.chkImage(iIndex).Name = iIndex.ToString
                Me.chkImage(iIndex).Size = New Size(250, 30)
                Me.chkImage(iIndex).AutoSize = False
                Me.chkImage(iIndex).BackColor = Color.White
                Me.chkImage(iIndex).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                Me.chkImage(iIndex).Text = String.Format("{0}x{1} ({2})", Me.pbImage(iIndex).Image.Width.ToString, Me.pbImage(iIndex).Image.Height.ToString, sDescription)
                Me.chkImage(iIndex).Left = 0
                Me.chkImage(iIndex).Top = 250
                Me.chkImage(iIndex).Checked = isChecked
                Me.pnlImage(iIndex).Controls.Add(Me.chkImage(iIndex))
                AddHandler pnlImage(iIndex).MouseWheel, AddressOf MouseWheelEvent
            Else
                ReDim Preserve Me.lblImage(iIndex)
                Me.lblImage(iIndex) = New Label()
                Me.lblImage(iIndex).Name = iIndex.ToString
                Me.lblImage(iIndex).Size = New Size(250, 30)
                Me.lblImage(iIndex).AutoSize = False
                Me.lblImage(iIndex).BackColor = Color.White
                Me.lblImage(iIndex).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                'Me.lblImage(iIndex).Text = Master.eLang.GetString(55, "Multiple")
                Me.lblImage(iIndex).Text = String.Format("{0}x{1} ({2})", Me.pbImage(iIndex).Image.Width.ToString, Me.pbImage(iIndex).Image.Height.ToString, sDescription)

                Me.lblImage(iIndex).Tag = sURL
                Me.lblImage(iIndex).Left = 0
                Me.lblImage(iIndex).Top = 250
                Me.pnlImage(iIndex).Controls.Add(Me.lblImage(iIndex))
                AddHandler lblImage(iIndex).Click, AddressOf lblImage_Click
                AddHandler lblImage(iIndex).MouseWheel, AddressOf MouseWheelEvent
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        Me.iCounter += 1

        If Me.iCounter = 3 Then
            Me.iCounter = 0
            Me.iLeft = 5
            Me.iTop += 301
        Else
            Me.iLeft += 271
        End If
    End Sub

    Private Sub AllDoneDownloading()
        ' If Me._impaDone AndAlso Me._tmdbDone AndAlso Me._mpdbDone Then
        Me.pnlDLStatus.Visible = False
        'Me.TMDBPosters.AddRange(Me.Posters)
        'Me.TMDBPosters.AddRange(Me.MPDBPosters)
        Me.ProcessPics(Me.MovieImages)
        Me.pnlBG.Visible = True
        'End If
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Dim tImage As New Images

            Me.pnlSinglePic.Visible = True
            Application.DoEvents()

            Select Case True
                Case rbXLarge.Checked
                    If Master.eSettings.UseImgCache Then
                        tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(original)_(url=", Me.rbXLarge.Tag, ").jpg")))
                    Else
                        tImage.FromWeb(Me.rbXLarge.Tag.ToString)
                    End If
                Case rbLarge.Checked
                    If Master.eSettings.UseImgCache Then
                        tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(mid)_(url=", Me.rbLarge.Tag, ").jpg")))
                    Else
                        tImage.FromWeb(Me.rbLarge.Tag.ToString)
                    End If
                Case rbMedium.Checked
                    If Master.eSettings.UseImgCache Then
                        tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(cover)_(url=", Me.rbMedium.Tag, ").jpg")))
                    Else
                        tImage.FromWeb(Me.rbMedium.Tag.ToString)
                    End If
                Case rbSmall.Checked
                    If Master.eSettings.UseImgCache Then
                        tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(thumb)_(url=", Me.rbSmall.Tag, ").jpg")))
                    Else
                        tImage.FromWeb(Me.rbSmall.Tag.ToString)
                    End If
            End Select

            Me.pnlSinglePic.Visible = False

            If Not IsNothing(tImage.Image) Then

                ModulesManager.Instance.RuntimeObjects.InvokeOpenImageViewer(tImage.Image)

            End If

            tImage.Dispose()
            tImage = Nothing

        Catch ex As Exception
            Me.pnlSinglePic.Visible = False
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwDownload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDownload.DoWork
        '//
        ' Thread to download impa posters from the internet (multi-threaded because sometimes
        ' the web server is slow to respond or not reachable, hanging the GUI)
        '\\

        For i As Integer = 0 To Me.MovieImages.Count - 1
            If bwDownload.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Me.bwDownload.ReportProgress(i + 1, Me.MovieImages.Item(i).URL)
            Try
                Me.MovieImages.Item(i).WebImage.FromWeb(Me.MovieImages.Item(i).URL)
                If Not Master.eSettings.NoSaveImagesToNfo Then Me.Results.Posters.Add(Me.MovieImages.Item(i).URL)
                If Master.eSettings.UseImgCache Then
                    Try
                        Me.MovieImages.Item(i).URL = StringUtils.CleanURL(Me.MovieImages.Item(i).URL)
                        Me.MovieImages.Item(i).WebImage.Save(Path.Combine(CachePath, String.Concat("poster_(", Me.MovieImages.Item(i).Description, ")_(url=", Me.MovieImages.Item(i).URL, ").jpg")))
                    Catch
                    End Try
                End If
            Catch
            End Try
        Next
    End Sub

    Private Sub bwDownload_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDownload.ProgressChanged
        '//
        ' Update the status bar with the name of the current media name and increase progress bar
        '\\
        Try
            Dim sStatus As String = e.UserState.ToString
            Me.lblDL2Status.Text = String.Format(Master.eLang.GetString(27, "Downloading {0}"), If(sStatus.Length > 40, StringUtils.TruncateURL(sStatus, 40), sStatus))
            Me.pbDL2.Value = e.ProgressPercentage
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwDownload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownload.RunWorkerCompleted
        '//
        ' Thread finished: process the pics
        '\\
        If Not e.Cancelled Then
            RaiseEvent EventImagesDone()
        End If
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If bwDownload.IsBusy Then bwDownload.CancelAsync()
        While bwDownload.IsBusy
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        End While

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckAll(ByVal sType As String, ByVal Checked As Boolean)
        For i As Integer = 0 To UBound(Me.chkImage)
            If Me.chkImage(i).Text.ToLower.Contains(sType) Then
                Me.chkImage(i).Checked = Checked
            End If
        Next
    End Sub

    Private Sub chkMid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMid.CheckedChanged
        Me.CheckAll("(mid)", chkMid.Checked)
    End Sub

    Private Sub chkOriginal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOriginal.CheckedChanged
        Me.CheckAll("(original)", chkOriginal.Checked)
    End Sub

    Private Sub chkThumb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThumb.CheckedChanged
        Me.CheckAll("(thumb)", chkThumb.Checked)
    End Sub

    Private Sub dlgImgSelect_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'Me.tmpImage.Dispose()
        MovieImages = Nothing
    End Sub

    Private Sub dlgImgSelect_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Master.eSettings.AutoET AndAlso Not Master.eSettings.UseImgCache Then FileUtils.Delete.DeleteDirectory(Me.CachePath)
    End Sub

    Private Sub dlgImgSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not PreDL Then SetUp()
    End Sub

    Private Sub dlgImgSelect_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Application.DoEvents()
            If Not PreDL Then
                StartDownload()
            ElseIf noImages Then
                If Me.DLType = Enums.ImageType.Fanart Then
                    MsgBox(Master.eLang.GetString(28, "No Fanart found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(29, "No Fanart Found"))
                Else
                    MsgBox(Master.eLang.GetString(30, "No Posters found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(31, "No Posters Found"))
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub DoSelect(ByVal iIndex As Integer, ByVal sURL As String)
        Try
            'set all pnl colors to white first
            'remove all the current genres
            For i As Integer = 0 To UBound(Me.pnlImage)
                Me.pnlImage(i).BackColor = Color.White

                If DLType = Enums.ImageType.Fanart Then
                    Me.chkImage(i).BackColor = Color.White
                    Me.chkImage(i).ForeColor = Color.Black
                Else
                    Me.lblImage(i).BackColor = Color.White
                    Me.lblImage(i).ForeColor = Color.Black
                End If
            Next

            'set selected pnl color to blue
            Me.pnlImage(iIndex).BackColor = Color.Blue

            If DLType = Enums.ImageType.Fanart Then
                Me.chkImage(iIndex).BackColor = Color.Blue
                Me.chkImage(iIndex).ForeColor = Color.White
            Else
                Me.lblImage(iIndex).BackColor = Color.Blue
                Me.lblImage(iIndex).ForeColor = Color.White
            End If

            Me.selIndex = iIndex

            Me.pnlSize.Visible = False

            If Not Me.DLType = Enums.ImageType.Fanart AndAlso sURL.ToLower.Contains("themoviedb.org") Then
                Me.SetupSizes(sURL)
                If Not rbLarge.Checked AndAlso Not rbMedium.Checked AndAlso Not rbSmall.Checked AndAlso Not rbXLarge.Checked Then
                    Me.OK_Button.Enabled = False
                Else
                    Me.OK_Button.Focus()
                End If
                Me.tmpImage.Clear()
            Else
                Me.rbXLarge.Checked = False
                Me.rbLarge.Checked = False
                Me.rbMedium.Checked = False
                Me.rbSmall.Checked = False
                Me.OK_Button.Enabled = True
                Me.OK_Button.Focus()
                Me.tmpImage.Image = Me.pbImage(iIndex).Image
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub GetFanart()
        Try
            Dim NoneFound As Boolean = True

            If Master.eSettings.UseImgCache Then
                Dim di As New DirectoryInfo(CachePath)
                Dim lFi As New List(Of FileInfo)

                If Not Directory.Exists(CachePath) Then
                    Directory.CreateDirectory(CachePath)
                Else
                    Try
                        lFi.AddRange(di.GetFiles("*.jpg"))
                    Catch
                    End Try
                End If

                If lFi.Count > 0 Then
                    Me.pnlDLStatus.Visible = True
                    Application.DoEvents()
                    NoneFound = False
                    Dim tImage As MediaContainers.Image
                    For Each sFile As FileInfo In lFi
                        tImage = New MediaContainers.Image
                        tImage.WebImage.FromFile(sFile.FullName)
                        If Not IsNothing(tImage.WebImage.Image) Then
                            Select Case True
                                Case sFile.Name.Contains("(original)")
                                    tImage.Description = "original"
                                    If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Lrg Then
                                        If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
                                            tImage.isChecked = True
                                        End If
                                    End If
                                Case sFile.Name.Contains("(mid)")
                                    tImage.Description = "mid"
                                    If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Mid Then
                                        If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
                                            tImage.isChecked = True
                                        End If
                                    End If
                                Case sFile.Name.Contains("(thumb)")
                                    tImage.Description = "thumb"
                                    If Master.eSettings.AutoET AndAlso Master.eSettings.AutoETSize = Enums.FanartSize.Small Then
                                        If Not ETHashes.Contains(HashFile.HashCalcFile(sFile.FullName)) Then
                                            tImage.isChecked = True
                                        End If
                                    End If
                            End Select
                            tImage.URL = Regex.Match(sFile.Name, "\(url=(.*?)\)").Groups(1).ToString
                            'Me.TMDBPosters.Add(tImage)
                        End If
                    Next
                    'ProcessPics(TMDBPosters)
                    Me.pnlDLStatus.Visible = False
                    Me.pnlBG.Visible = True
                    Me.pnlFanart.Visible = True
                    Me.lblInfo.Visible = True
                End If

                lFi = Nothing
                di = Nothing
            End If

            If NoneFound Then
                If Master.eSettings.AutoET AndAlso Not Directory.Exists(CachePath) Then
                    Directory.CreateDirectory(CachePath)
                End If

                Me.lblDL2.Text = Master.eLang.GetString(32, "Retrieving images ...")
                Me.lblDL2Status.Text = String.Empty
                Me.pbDL2.Maximum = 3
                Me.pnlDLStatus.Visible = True
                Me.Refresh()
                Application.DoEvents()
                Dim _images As New List(Of MediaContainers.Image)
                For Each t As MediaContainers.Thumb In tMovie.Movie.Fanart.Thumb
                    _images.Add(New MediaContainers.Image With {.URL = t.Text})
                Next
                ImagesDownloaded(_images)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub GetPosters()
        Try
            Dim NoneFound As Boolean = True

            If Master.eSettings.UseImgCache Then
                Dim lFi As New List(Of FileInfo)
                Dim di As New DirectoryInfo(CachePath)

                If Not Directory.Exists(CachePath) Then
                    Directory.CreateDirectory(CachePath)
                Else
                    Try
                        lFi.AddRange(di.GetFiles("*.jpg"))
                    Catch
                    End Try
                End If

                If lFi.Count > 0 Then
                    Me.pnlDLStatus.Height = 75
                    Me.pnlDLStatus.Top = 207
                    Me.pnlDLStatus.Visible = True
                    Application.DoEvents()
                    NoneFound = False
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
                        'Me.TMDBPosters.Add(tImage)
                    Next
                    'ProcessPics(TMDBPosters)
                    Me.pnlDLStatus.Visible = False
                    'Me.pnlBG.Visible = True
                End If

                lFi = Nothing
                di = Nothing
            End If

            If NoneFound Then

                Me.lblDL2.Text = Master.eLang.GetString(34, "Retrieving images ...")
                Me.lblDL2Status.Text = String.Empty
                Me.pbDL2.Maximum = 3
                Me.pnlDLStatus.Visible = True
                Me.Refresh()
                Application.DoEvents()
                Dim _images As New List(Of MediaContainers.Image)
                For Each t As String In tMovie.Movie.Thumb
                    _images.Add(New MediaContainers.Image With {.URL = t})
                Next
                ImagesDownloaded(_images)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub DoneDownloading()
        Try
            Me.AllDoneDownloading()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub ImagesDownloaded(ByVal _images As List(Of MediaContainers.Image))
        Try
            Me.pbDL2.Value = 0

            Me.lblDL2.Text = Master.eLang.GetString(38, "Preparing images...")
            Me.lblDL2Status.Text = String.Empty
            Me.pbDL2.Maximum = _images.Count

            Me.MovieImages = _images

            Me.bwDownload.WorkerSupportsCancellation = True
            Me.bwDownload.WorkerReportsProgress = True
            Me.bwDownload.RunWorkerAsync()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub lblImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.DoSelect(Convert.ToInt32(DirectCast(sender, Label).Name), DirectCast(sender, Label).Tag.ToString)
    End Sub

    Private Sub MouseWheelEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Delta < 0 Then
            If (pnlBG.VerticalScroll.Value + 50) <= pnlBG.VerticalScroll.Maximum Then
                pnlBG.VerticalScroll.Value += 50
            Else
                pnlBG.VerticalScroll.Value = pnlBG.VerticalScroll.Maximum
            End If
        Else
            If (pnlBG.VerticalScroll.Value - 50) >= pnlBG.VerticalScroll.Minimum Then
                pnlBG.VerticalScroll.Value -= 50
            Else
                pnlBG.VerticalScroll.Value = pnlBG.VerticalScroll.Minimum
            End If
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Dim tmpPathPlus As String = String.Empty

            If DLType = Enums.ImageType.Fanart Then
                tmpPathPlus = Path.Combine(Master.TempPath, "fanart.jpg")
            Else
                tmpPathPlus = Path.Combine(Master.TempPath, "poster.jpg")
            End If

            If Not IsNothing(Me.tmpImage.Image) Then
                If isEdit Then
                    Me.tmpImage.Save(tmpPathPlus)
                    Results.ImagePath = tmpPathPlus
                Else
                    If Me.DLType = Enums.ImageType.Fanart Then
                        Results.ImagePath = Me.tmpImage.SaveAsFanart(tMovie)
                    Else
                        Results.ImagePath = Me.tmpImage.SaveAsPoster(tMovie)
                    End If
                End If
            Else
                Me.pnlBG.Visible = False
                Me.pnlSinglePic.Visible = True
                Me.Refresh()
                Application.DoEvents()
                Select Case True
                    Case Me.rbXLarge.Checked
                        If Master.eSettings.UseImgCache Then
                            tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(original)_(url=", Me.rbXLarge.Tag, ").jpg")))
                        Else
                            Me.tmpImage.FromWeb(Me.rbXLarge.Tag.ToString)
                        End If
                    Case Me.rbLarge.Checked
                        If Master.eSettings.UseImgCache Then
                            Me.tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(mid)_(url=", Me.rbLarge.Tag, ").jpg")))
                        Else
                            Me.tmpImage.FromWeb(Me.rbLarge.Tag.ToString)
                        End If
                    Case Me.rbMedium.Checked
                        Me.tmpImage.Image = Me.pbImage(selIndex).Image
                    Case Me.rbSmall.Checked
                        If Master.eSettings.UseImgCache Then
                            Me.tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(thumb)_(url=", Me.rbSmall.Tag, ").jpg")))
                        Else
                            Me.tmpImage.FromWeb(Me.rbSmall.Tag.ToString)
                        End If
                End Select

                If Not IsNothing(Me.tmpImage.Image) Then
                    If isEdit Then
                        Me.tmpImage.Save(tmpPathPlus)
                        Results.ImagePath = tmpPathPlus
                    Else
                        If Me.DLType = Enums.ImageType.Fanart Then
                            Results.ImagePath = Me.tmpImage.SaveAsFanart(Me.tMovie)
                        Else
                            Results.ImagePath = Me.tmpImage.SaveAsPoster(Me.tMovie)
                        End If
                    End If
                End If
                Me.pnlSinglePic.Visible = False
            End If

            If Me.DLType = Enums.ImageType.Fanart Then
                Dim iMod As Integer = 0
                Dim iVal As Integer = 1
                Dim extraPath As String = String.Empty
                Dim isChecked As Boolean = False

                For i As Integer = 0 To UBound(Me.chkImage)
                    If Me.chkImage(i).Checked Then
                        isChecked = True
                        Exit For
                    End If
                Next

                If isChecked Then

                    If isEdit Then
                        extraPath = Path.Combine(Master.TempPath, "extrathumbs")
                    Else
                        If Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isVideoTS(Me.tMovie.Filename) Then
                            extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(Me.tMovie.Filename).FullName).FullName, "extrathumbs")
                        ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isBDRip(Me.tMovie.Filename) Then
                            extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Me.tMovie.Filename).FullName).FullName).FullName, "extrathumbs")
                        Else
                            extraPath = Path.Combine(Directory.GetParent(Me.tMovie.Filename).FullName, "extrathumbs")
                        End If
                        iMod = Functions.GetExtraModifier(extraPath)
                        iVal = iMod + 1
                    End If

                    If Not Directory.Exists(extraPath) Then
                        Directory.CreateDirectory(extraPath)
                    End If

                    Dim fsET As FileStream
                    For i As Integer = 0 To UBound(Me.chkImage)
                        If Me.chkImage(i).Checked Then
                            fsET = New FileStream(Path.Combine(extraPath, String.Concat("thumb", iVal, ".jpg")), FileMode.Create, FileAccess.ReadWrite)
                            Me.pbImage(i).Image.Save(fsET, System.Drawing.Imaging.ImageFormat.Jpeg)
                            fsET.Close()
                            iVal += 1
                        End If
                    Next
                    fsET = Nothing
                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub pbImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.DoSelect(Convert.ToInt32(DirectCast(sender, PictureBox).Name), DirectCast(sender, PictureBox).Tag.ToString)
    End Sub

    Private Sub pbImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.DLType = Enums.ImageType.Fanart Then
                ModulesManager.Instance.RuntimeObjects.InvokeOpenImageViewer(DirectCast(sender, PictureBox).Image)
            End If
        Catch
        End Try
    End Sub

    Private Sub pnlImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.DoSelect(Convert.ToInt32(DirectCast(sender, Panel).Name), DirectCast(sender, Panel).Tag.ToString)
    End Sub

    Private Sub ProcessPics(ByVal posters As List(Of MediaContainers.Image))
        Try
            Dim iIndex As Integer = 0

            'remove all entries with invalid images
            If Master.eSettings.UseImgCache Then
                For i As Integer = posters.Count - 1 To 0 Step -1
                    If IsNothing(posters.Item(i).WebImage.Image) Then
                        posters.RemoveAt(i)
                    End If
                Next
            End If

            If posters.Count > 0 Then
                For Each xPoster As MediaContainers.Image In posters.OrderBy(Function(p) p.URL)
                    If Not IsNothing(xPoster.WebImage.Image) AndAlso (Me.DLType = Enums.ImageType.Fanart OrElse Not (xPoster.URL.ToLower.Contains("themoviedb.org") AndAlso Not xPoster.Description = "cover")) Then
                        Me.AddImage(xPoster.WebImage.Image, xPoster.Description, iIndex, xPoster.URL, xPoster.isChecked)
                        iIndex += 1
                    End If
                Next
            Else
                If Not Me.PreDL OrElse isShown Then
                    If Me.DLType = Enums.ImageType.Fanart Then
                        MsgBox(Master.eLang.GetString(28, "No Fanart found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(29, "No Fanart Found"))
                    Else
                        MsgBox(Master.eLang.GetString(30, "No Posters found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(31, "No Posters Found"))
                    End If
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                Else
                    noImages = True
                End If
            End If

            Me.Activate()

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub rbLarge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLarge.CheckedChanged
        Me.OK_Button.Enabled = True
        Me.btnPreview.Enabled = True
    End Sub

    Private Sub rbMedium_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMedium.CheckedChanged
        Me.OK_Button.Enabled = True
        Me.btnPreview.Enabled = True
    End Sub

    Private Sub rbSmall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSmall.CheckedChanged
        Me.OK_Button.Enabled = True
        Me.btnPreview.Enabled = True
    End Sub

    Private Sub rbXLarge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbXLarge.CheckedChanged
        Me.OK_Button.Enabled = True
        Me.btnPreview.Enabled = True
    End Sub

    Private Sub SetUp()
        Try
            AddHandler EventImagesDone, AddressOf DoneDownloading

            AddHandler MyBase.MouseWheel, AddressOf MouseWheelEvent
            AddHandler pnlBG.MouseWheel, AddressOf MouseWheelEvent

            Functions.PNLDoubleBuffer(Me.pnlBG)

            If Me.DLType = Enums.ImageType.Posters Then
                Me.Text = String.Concat(Master.eLang.GetString(39, "Select Poster - "), If(Not String.IsNullOrEmpty(Me.tMovie.Movie.Title), Me.tMovie.Movie.Title, Me.tMovie.ListTitle))
            Else
                Me.Text = String.Concat(Master.eLang.GetString(40, "Select Fanart - "), If(Not String.IsNullOrEmpty(Me.tMovie.Movie.Title), Me.tMovie.Movie.Title, Me.tMovie.ListTitle))
                Me.pnlDLStatus.Height = 75
                Me.pnlDLStatus.Top = 207

                If Master.eSettings.AutoET Then
                    ETHashes = HashFile.CurrentETHashes(tMovie.Filename)
                End If
            End If

            CachePath = String.Concat(Master.TempPath, Path.DirectorySeparatorChar, tMovie.Movie.IMDBID, Path.DirectorySeparatorChar, If(Me.DLType = Enums.ImageType.Posters, "posters", "fanart"))

            Me.OK_Button.Text = Master.eLang.GetString(179, "OK", True)
            Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel", True)
            Me.btnPreview.Text = Master.eLang.GetString(180, "Preview", True)
            Me.chkThumb.Text = Master.eLang.GetString(41, "Check All Thumb")
            Me.chkMid.Text = Master.eLang.GetString(42, "Check All Mid")
            Me.chkOriginal.Text = Master.eLang.GetString(43, "Check All Original")
            Me.lblInfo.Text = Master.eLang.GetString(44, "Selected item will be set as fanart. All checked items will be saved to \extrathumbs.")
            Me.lblDL2.Text = Master.eLang.GetString(45, "Performing Preliminary Tasks...")
            Me.Label2.Text = Master.eLang.GetString(46, "Downloading Selected Image...")
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub SetupSizes(ByVal sURL As String)
        Try
            Dim sLeft As String = Strings.Left(sURL, sURL.Length - 10)

            Me.rbXLarge.Checked = False
            Me.rbXLarge.Enabled = False
            Me.rbXLarge.Text = Master.eLang.GetString(47, "X-Large")
            Me.rbLarge.Checked = False
            Me.rbLarge.Enabled = False
            Me.rbLarge.Text = Master.eLang.GetString(48, "Large")
            Me.rbMedium.Checked = False
            Me.rbMedium.Text = Master.eLang.GetString(49, "Medium")
            Me.rbSmall.Checked = False
            Me.rbSmall.Enabled = False
            Me.rbSmall.Text = Master.eLang.GetString(50, "Small")

            Me.rbMedium.Tag = sURL

            'For i As Integer = 0 To Me.TMDBPosters.Count - 1
            'Select Case True
            '   Case Me.TMDBPosters.Item(i).URL = String.Concat(sLeft, ".jpg")
            ' xlarge
            'If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPosters.Item(i).WebImage.Image) Then
            'Me.rbXLarge.Enabled = True
            'Me.rbXLarge.Tag = Me.TMDBPosters.Item(i).URL
            'If Master.eSettings.UseImgCache Then Me.rbXLarge.Text = String.Format(Master.eLang.GetString(51, "X-Large ({0}x{1})"), Me.TMDBPosters.Item(i).WebImage.Image.Width, Me.TMDBPosters.Item(i).WebImage.Image.Height)
            'End If
            '   Case Me.TMDBPosters.Item(i).URL = String.Concat(sLeft, "_mid.jpg")
            ' large
            'If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPosters.Item(i).WebImage.Image) Then
            'Me.rbLarge.Enabled = True
            'Me.rbLarge.Tag = Me.TMDBPosters.Item(i).URL
            'If Master.eSettings.UseImgCache Then Me.rbLarge.Text = String.Format(Master.eLang.GetString(52, "Large ({0}x{1})"), Me.TMDBPosters.Item(i).WebImage.Image.Width, Me.TMDBPosters.Item(i).WebImage.Image.Height)
            'End If
            '   Case Me.TMDBPosters.Item(i).URL = String.Concat(sLeft, "_thumb.jpg")
            ' small
            'If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPosters.Item(i).WebImage.Image) Then
            'Me.rbSmall.Enabled = True
            'Me.rbSmall.Tag = Me.TMDBPosters.Item(i).URL
            'If Master.eSettings.UseImgCache Then Me.rbSmall.Text = String.Format(Master.eLang.GetString(53, "Small ({0}x{1})"), Me.TMDBPosters.Item(i).WebImage.Image.Width, Me.TMDBPosters.Item(i).WebImage.Image.Height)
            'End If
            '    Case Me.TMDBPosters.Item(i).URL = sURL
            'If Master.eSettings.UseImgCache Then Me.rbMedium.Text = String.Format(Master.eLang.GetString(54, "Medium ({0}x{1})"), Me.TMDBPosters.Item(i).WebImage.Image.Width, Me.TMDBPosters.Item(i).WebImage.Image.Height)
            'End Select
            'Next

            Select Case Master.eSettings.PreferredPosterSize
                Case Enums.PosterSize.Small
                    Me.rbSmall.Checked = Me.rbSmall.Enabled
                Case Enums.PosterSize.Mid
                    Me.rbMedium.Checked = Me.rbMedium.Enabled
                Case Enums.PosterSize.Lrg
                    Me.rbLarge.Checked = Me.rbLarge.Enabled
                Case Enums.PosterSize.Xlrg
                    Me.rbXLarge.Checked = Me.rbXLarge.Enabled
            End Select

            pnlSize.Visible = True

            Me.Invalidate()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub StartDownload()
        Try
            Select Case Me.DLType
                Case Enums.ImageType.Posters
                    Me.GetPosters()
                Case Enums.ImageType.Fanart
                    Me.GetFanart()
            End Select
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

#End Region 'Methods

End Class