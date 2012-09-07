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
Imports EmberMediaManger.API
Imports System.Threading.Tasks
Imports TechNuts.ScraperXML
Imports TechNuts.MediaTags

Namespace Scrapers.Movies

    Public Class dlgImgSelect

#Region "Fields"

        Private CachePath As String = String.Empty        
        Private _imageType As Enums.ImageType
        Private ETHashes As New List(Of String)
        Private iCounter As Integer = 0
        Private iLeft As Integer = 5
        Private isEdit As Boolean = False
        Private isShown As Boolean = False
        Private iTop As Integer = 5        
        Private noImages As Boolean = False        
        Private PreDL As Boolean = False
        Private Results As New Containers.ImgResult
        Private selIndex As Integer = -1
        Private _imageList As New List(Of TechNuts.MediaTags.Thumbnail)
        Private tmpImage As New Images
        Private _currentMovie As Model.Movie

#End Region 'Fields

#Region "Methods"

        Public Sub PreLoad(ByVal mMovie As Model.Movie, ByVal imageType As Enums.ImageType, Optional ByVal _isEdit As Boolean = False)
            _currentMovie = mMovie
            _imageType = imageType
            isEdit = _isEdit
            PreDL = True
            SetUp()
            StartDownload()
        End Sub

        Public Overloads Function ShowDialog(ByVal mMovie As Model.Movie, ByVal imageType As Enums.ImageType, Optional ByVal _isEdit As Boolean = False) As Image
            '//
            ' Overload to pass data
            '\\

            _currentMovie = mMovie
            _imageType = imageType
            isEdit = _isEdit
            isShown = True

            If MyBase.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return Nothing 'Return selected image heres'
            Else
                Return Nothing
            End If
        End Function

        Public Overloads Function ShowDialog() As Containers.ImgResult
            isShown = True
            MyBase.ShowDialog()

            Return Results
        End Function

        'Rewrite to simplify
        Private Sub AddImage(ByVal iImage As Thumbnail, index As Integer)
            Try
                Dim pnlImage = New Panel
                Dim pbImage = New PictureBox
                pnlImage.Name = index
                pbImage.Name = "pbImage"
                pbImage.Tag = index
                pnlImage.Size = New Size(256, 286)
                pbImage.Size = New Size(250, 250)
                pnlImage.BackColor = Color.White
                pnlImage.BorderStyle = BorderStyle.FixedSingle
                pbImage.SizeMode = PictureBoxSizeMode.Zoom
                pbImage.Left = 3
                pbImage.Top = 3
                pbImage.Image = iImage.Img
                pnlImages.Controls.Add(pnlImage)
                pnlImage.Controls.Add(pbImage)
                pnlImage.BringToFront()
                AddHandler pbImage.Click, AddressOf pbImage_Click
                AddHandler pbImage.DoubleClick, AddressOf pbImage_DoubleClick
                AddHandler pnlImage.Click, AddressOf pnlImage_Click

                AddHandler pbImage.MouseWheel, AddressOf MouseWheelEvent
                AddHandler pnlImage.MouseWheel, AddressOf MouseWheelEvent

                If _imageType = Enums.ImageType.Fanart Then
                    Dim chkImage = New CheckBox()
                    chkImage.Name = "chkImage"
                    chkImage.Size = New Size(250, 30)
                    chkImage.AutoSize = False
                    chkImage.BackColor = Color.White
                    chkImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    chkImage.Text = Master.eLang.GetString(55, "Multiple")
                    'chkImage(iIndex).Text = String.Format("{0}x{1} ({2})", pbImage(iIndex).Image.Width.ToString, pbImage(iIndex).Image.Height.ToString, sDescription)
                    chkImage.Left = 0
                    chkImage.Top = 250
                    'chkImage.Checked = False
                    pnlImage.Controls.Add(chkImage)
                    AddHandler chkImage.MouseWheel, AddressOf MouseWheelEvent
                Else
                    Dim lblImage = New Label
                    lblImage.Name = "lblImage"
                    lblImage.Tag = index
                    lblImage.Size = New Size(250, 30)
                    lblImage.AutoSize = False
                    lblImage.BackColor = Color.White
                    lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    If String.IsNullOrEmpty(iImage.Dimensions) Then
                        lblImage.Text = String.Format(Languages.Size_Param, iImage.Img.Width, iImage.Img.Height)
                    Else
                        lblImage.Text = iImage.Dimensions
                    End If
                    lblImage.Left = 0
                    lblImage.Top = 250
                    pnlImage.Controls.Add(lblImage)
                    AddHandler lblImage.Click, AddressOf lblImage_Click
                    AddHandler lblImage.MouseWheel, AddressOf MouseWheelEvent
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        'Private Sub PreviewImageOld()
        '    Try
        '        Dim tImage As New Images

        '        pnlSinglePic.Visible = True
        '        Application.DoEvents()

        '        Select Case True
        '            Case rbXLarge.Checked
        '                If Master.eSettings.UseImgCache Then
        '                    tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(original)_(url=", rbXLarge.Tag, ").jpg")))
        '                Else
        '                    tImage.FromWeb(rbXLarge.Tag.ToString)
        '                End If
        '            Case rbLarge.Checked
        '                If Master.eSettings.UseImgCache Then
        '                    tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(mid)_(url=", rbLarge.Tag, ").jpg")))
        '                Else
        '                    tImage.FromWeb(rbLarge.Tag.ToString)
        '                End If
        '            Case rbMedium.Checked
        '                If Master.eSettings.UseImgCache Then
        '                    tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(cover)_(url=", rbMedium.Tag, ").jpg")))
        '                Else
        '                    tImage.FromWeb(rbMedium.Tag.ToString)
        '                End If
        '            Case rbSmall.Checked
        '                If Master.eSettings.UseImgCache Then
        '                    tImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(thumb)_(url=", rbSmall.Tag, ").jpg")))
        '                Else
        '                    tImage.FromWeb(rbSmall.Tag.ToString)
        '                End If
        '        End Select

        '        pnlSinglePic.Visible = False

        '        If Not IsNothing(tImage.Image) Then

        '            ModulesManager.Instance.RuntimeObjects.InvokeOpenImageViewer(tImage.Image)

        '        End If

        '        tImage.Dispose()
        '        tImage = Nothing

        '    Catch ex As Exception
        '        pnlSinglePic.Visible = False
        '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        '    End Try
        'End Sub



        'Private Sub bwTMDBDownload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwTMDBDownload.DoWork
        '    '//
        '    ' Thread to download tmdb posters from the internet (multi-threaded because sometimes
        '    ' the web server is slow to respond or not reachable, hanging the GUI)
        '    '\\
        '    Dim thumbLink As String = String.Empty
        '    Dim savePath As String = String.Empty
        '    Dim extrathumbSize As String = String.Empty

        '    extrathumbSize = AdvancedSettings.GetSetting("ManualETSize", "thumb")

        '    'Only download the posters themselves that match the cover criteria for display purposes, no need to download them all.
        '    Dim posters As MediaContainers.Image()
        '    If DLType = Enums.ImageType.Fanart Then
        '        posters = TMDBPosters.Where(Function(s) s.Description = extrathumbSize).ToArray()
        '    Else
        '        posters = TMDBPosters.Where(Function(s) s.Description = "cover").ToArray()
        '    End If

        '    Dim percent = 100 / posters.Count
        '    For i As Integer = 0 To posters.Count - 1
        '        Try
        '            If DLType = Enums.ImageType.Fanart OrElse (Master.eSettings.UseImgCache OrElse (posters(i).Description = "cover" OrElse Master.eSettings.PosterPrefSizeOnly)) Then
        '                If bwTMDBDownload.CancellationPending Then
        '                    e.Cancel = True
        '                    Return
        '                End If
        '                bwTMDBDownload.ReportProgress(Convert.ToInt32((i + 1) * percent), posters(i).URL)
        '                Try
        '                    posters(i).WebImage.FromWeb(posters(i).URL)
        '                    If Not Master.eSettings.NoSaveImagesToNfo Then
        '                        If DLType = Enums.ImageType.Fanart Then


        '                            If Not posters(i).URL.Contains("-thumb.") Then
        '                                Results.Fanart.URL = GetServerURL(posters(i).URL) '  "http://images.themoviedb.org"
        '                                thumbLink = RemoveServerURL(posters(i).URL)
        '                                'If thumbLink.Contains("_poster.") Then
        '                                thumbLink = thumbLink.Replace("-poster.", "-thumb.")
        '                                thumbLink = thumbLink.Replace("-original.", "-thumb.")
        '                                ''Else
        '                                'thumbLink = thumbLink.Insert(thumbLink.LastIndexOf("."), "-thumb")
        '                                'End If
        '                                Results.Fanart.Thumb.Add(New MediaContainers.Thumb With {.Preview = thumbLink, .Text = posters(i).URL.Replace("http://images.themoviedb.org", String.Empty)})
        '                            End If
        '                        Else
        '                            Results.Posters.Add(posters(i).URL)
        '                        End If
        '                    End If
        '                    If Master.eSettings.UseImgCache OrElse Master.eSettings.AutoET Then
        '                        Try
        '                            posters(i).URL = CleanTMDBURL(posters(i).URL)

        '                            savePath = Path.Combine(CachePath, String.Concat(If(DLType = Enums.ImageType.Fanart, "fanart_(", "poster_("), posters(i).Description, ")_(url=", posters(i).URL, ").jpg"))
        '                            posters(i).WebImage.Save(savePath)

        '                            If Master.eSettings.AutoET Then
        '                                Dim tSize As New Enums.FanartSize
        '                                Select Case posters(i).Description.ToLower
        '                                    Case "original"
        '                                        tSize = Enums.FanartSize.Lrg
        '                                    Case "mid"
        '                                        tSize = Enums.FanartSize.Mid
        '                                    Case "thumb"
        '                                        tSize = Enums.FanartSize.Small
        '                                End Select
        '                                If Master.eSettings.AutoETSize = tSize Then
        '                                    If Not ETHashes.Contains(HashFile.HashCalcFile(savePath)) Then
        '                                        posters(i).isChecked = True
        '                                    End If
        '                                End If
        '                            End If

        '                        Catch
        '                        End Try
        '                    End If
        '                Catch
        '                End Try
        '            End If
        '        Catch
        '        End Try
        '    Next
        'End Sub

        Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        'Private Sub CheckAll(ByVal sType As String, ByVal Checked As Boolean)
        '    For i As Integer = 0 To UBound(chkImage)
        '        If chkImage(i).Text.ToLower.Contains(sType) Then
        '            chkImage(i).Checked = Checked
        '        End If
        '    Next
        'End Sub

        'Private Sub chkMid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMid.CheckedChanged
        '    CheckAll("(poster)", chkMid.Checked)
        'End Sub

        'Private Sub chkOriginal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOriginal.CheckedChanged
        '    CheckAll("(original)", chkOriginal.Checked)
        'End Sub

        'Private Sub chkThumb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThumb.CheckedChanged
        '    CheckAll("(thumb)", chkThumb.Checked)
        'End Sub

        Private Sub dlgImgSelect_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If Master.eSettings.AutoET AndAlso Not Master.eSettings.UseImgCache Then FileUtils.DeleteDirectory(CachePath)
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
                    If _imageType = Enums.ImageType.Fanart Then
                        MsgBox(Master.eLang.GetString(28, "No Fanart found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(29, "No Fanart Found"))
                    Else
                        MsgBox(Master.eLang.GetString(30, "No Posters found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(31, "No Posters Found"))
                    End If
                    DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Close()
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub DoSelect(ByVal index As Integer)
            Try
                Dim pnlImage As Panel
                Dim chkImage As CheckBox
                Dim lblImage As Label
                For Each ctl In pnlImages.Controls
                    Select Case ctl.GetType()
                        Case GetType(Panel)
                            pnlImage = DirectCast(ctl, Panel)
                            pnlImage.BackColor = Color.White
                            If _imageType = Enums.ImageType.Posters Then
                                lblImage = DirectCast(pnlImage.Controls.Item("lblImage"), Label)
                                lblImage.BackColor = Color.White
                                lblImage.ForeColor = Color.Black
                            ElseIf _imageType = Enums.ImageType.Fanart Then
                                chkImage = DirectCast(pnlImage.Controls.Item("chkImage"), CheckBox)
                                chkImage.BackColor = Color.White
                                chkImage.ForeColor = Color.Black
                            End If                            
                    End Select
                Next
                pnlImage = DirectCast(pnlImages.Controls.Item(index.ToString()), Panel)
                pnlImage.BackColor = Color.Blue

                If _imageType = Enums.ImageType.Posters Then
                    lblImage = DirectCast(pnlImage.Controls.Item("lblImage"), Label)
                    lblImage.BackColor = Color.Blue
                    lblImage.ForeColor = Color.White
                ElseIf _imageType = Enums.ImageType.Fanart Then
                    chkImage = DirectCast(pnlImage.Controls.Item("chkImage"), CheckBox)
                    chkImage.BackColor = Color.Blue
                    chkImage.ForeColor = Color.White
                End If


                'SetupSizes(poster.ParentID)
                '        If Not rbLarge.Checked AndAlso Not rbMedium.Checked AndAlso Not rbSmall.Checked AndAlso Not rbXLarge.Checked Then
                '            OK_Button.Enabled = False
                '        Else
                '            OK_Button.Focus()
                '        End If
                '        tmpImage.Clear()
                '    Else
                '        rbXLarge.Checked = False
                '        rbLarge.Checked = False
                '        rbMedium.Checked = False
                '        rbSmall.Checked = False
                '        OK_Button.Enabled = True
                '        OK_Button.Focus()
                '        tmpImage.Image = pbImage(iIndex).Image
                '    End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub DoSelect(ByVal iIndex As Integer, poster As MediaContainers.Image)
            'Try
            '    'set all pnl colors to white first
            '    'remove all the current genres
            '    For i As Integer = 0 To UBound(pnlImage)
            '        pnlImage(i).BackColor = Color.White

            '        If DLType = Enums.ImageType.Fanart Then
            '            chkImage(i).BackColor = Color.White
            '            chkImage(i).ForeColor = Color.Black
            '        Else
            '            lblImage(i).BackColor = Color.White
            '            lblImage(i).ForeColor = Color.Black
            '        End If
            '    Next

            '    'set selected pnl color to blue
            '    pnlImage(iIndex).BackColor = Color.Blue

            '    If DLType = Enums.ImageType.Fanart Then
            '        chkImage(iIndex).BackColor = Color.Blue
            '        chkImage(iIndex).ForeColor = Color.White
            '    Else
            '        lblImage(iIndex).BackColor = Color.Blue
            '        lblImage(iIndex).ForeColor = Color.White
            '    End If

            '    selIndex = iIndex

            '    pnlSize.Visible = False

            '    If IsTMDBURL(poster.URL) Then
            'SetupSizes(poster.ParentID)
            '        If Not rbLarge.Checked AndAlso Not rbMedium.Checked AndAlso Not rbSmall.Checked AndAlso Not rbXLarge.Checked Then
            '            OK_Button.Enabled = False
            '        Else
            '            OK_Button.Focus()
            '        End If
            '        tmpImage.Clear()
            '    Else
            '        rbXLarge.Checked = False
            '        rbLarge.Checked = False
            '        rbMedium.Checked = False
            '        rbSmall.Checked = False
            '        OK_Button.Enabled = True
            '        OK_Button.Focus()
            '        tmpImage.Image = pbImage(iIndex).Image
            '    End If

            'Catch ex As Exception
            '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            'End Try
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
                        pnlStatus.Visible = True
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
                                        'Case sFile.NaContains("(mid)")
                                        ' tImage.Description = "mid"
                                    Case sFile.Name.Contains("(poster)")
                                        tImage.Description = "poster"

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
                                'TMDBPosters.Add(tImage)
                            End If
                        Next
                        ProcessPics(_imageList)
                        pnlStatus.Visible = False
                        pnlImages.Visible = True
                        'pnlFanart.Visible = True
                        'lblInfo.Visible = True
                    End If

                    lFi = Nothing
                    di = Nothing
                End If

                If NoneFound Then
                    lblStatus.Text = "Retrieving data ..."
                    lblDL1Status.Text = String.Empty
                    pbStatus.Maximum = 3
                    pnlStatus.Visible = True
                    Dim scrapeTask = Task.Factory.StartNew(Sub() GetMovieImages())
                    While Not scrapeTask.IsCompleted
                        Application.DoEvents()
                        Threading.Thread.Sleep(50)
                    End While
                    ProcessPics(_imageList)
                    pnlStatus.Visible = False
                    pnlImages.Visible = True
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub GetPosters()
            Try
                Dim noneFound As Boolean = True

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
                        pnlStatus.Height = 75
                        pnlStatus.Top = 207
                        pnlStatus.Visible = True
                        Application.DoEvents()
                        noneFound = False
                        For Each sFile As FileInfo In lFi
                            Dim sizeDesc As String = ""
                            Select Case True
                                Case sFile.Name.Contains("(original)")
                                    sizeDesc = "original"
                                Case sFile.Name.Contains("(mid)")
                                    sizeDesc = "mid"
                                Case sFile.Name.Contains("(cover)")
                                    sizeDesc = "cover"
                                Case sFile.Name.Contains("(thumb)")
                                    sizeDesc = "thumb"
                                Case sFile.Name.Contains("(poster)")
                                    sizeDesc = "poster"
                            End Select
                            'Dim poster = Tuple.Create(Image.FromFile(sFile.FullName), sizeDesc, Regex.Match(sFile.Name, "\(url=(.*?)\)").Groups(1).ToString)
                            'MoviePosters.Add(poster)
                        Next
                        ProcessPics(_imageList)
                        pnlStatus.Visible = False
                        pnlImages.Visible = True
                    End If
                End If

                If noneFound Then
                    lblStatus.Text = "Retrieving data ..."
                    lblDL1Status.Text = String.Empty
                    pbStatus.Maximum = 3
                    pnlStatus.Visible = True
                    Dim scrapeTask = Task.Factory.StartNew(Sub() GetMovieImages())
                    While Not scrapeTask.IsCompleted
                        Application.DoEvents()
                        Threading.Thread.Sleep(50)
                    End While
                    ProcessPics(_imageList)
                    pnlStatus.Visible = False
                    pnlImages.Visible = True
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub GetMovieImages()
            Dim searchResults = Master.ScraperMan.GetMovieResults("IMDB", "tt" & _currentMovie.Imdb, "")
            If searchResults.Count > 0 Then
                Dim movieDetails = Master.ScraperMan.GetMovieDetails(searchResults(0))
                If movieDetails IsNot Nothing Then
                    If _imageType = Enums.ImageType.Posters Then
                        _imageList.AddRange(movieDetails.Thumbs)
                    ElseIf _imageType = Enums.ImageType.Fanart Then
                        _imageList.AddRange(movieDetails.Fanart.Thumbs)
                    End If
                    Parallel.ForEach(_imageList, Sub(item, loopState, processed)
                                                     Try
                                                         Dim url As String = item.Thumb
                                                         If Not String.IsNullOrEmpty(item.Preview) Then
                                                             url = item.Preview
                                                         End If

                                                         Dim tempImage = Classes.Http.DownloadImage(url)
                                                         If (tempImage IsNot Nothing) Then
                                                             item.Img = tempImage
                                                         End If

                                                         'If Not Master.eSettings.NoSaveImagesToNfo Then Results.Posters.Add(IMPAPosters.Item(i).URL)
                                                         'If Master.eSettings.UseImgCache Then
                                                         '    Try
                                                         '        IMPAPosters.Item(i).URL = StringUtils.CleanURL(IMPAPosters.Item(i).URL)
                                                         '        IMPAPosters.Item(i).WebImage.Save(Path.Combine(CachePath, String.Concat("poster_(", IMPAPosters.Item(i).Description, ")_(url=", IMPAPosters.Item(i).URL, ").jpg")))
                                                         '    Catch
                                                         '    End Try
                                                         'End If


                                                     Catch ex As Exception
                                                         Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                                                     End Try
                                                 End Sub)
                End If
            End If
        End Sub

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

        Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
            'Try
            '    Dim tmpPathPlus As String = String.Empty
            '    Dim extrathumbSize As String

            '    extrathumbSize = AdvancedSettings.GetSetting("ManualETSize", "thumb")

            '    If DLType = Enums.ImageType.Fanart Then
            '        tmpPathPlus = Path.Combine(Master.TempPath, "fanart.jpg")
            '    Else
            '        tmpPathPlus = Path.Combine(Master.TempPath, "poster.jpg")
            '    End If

            '    If Not IsNothing(tmpImage.Image) Then
            '        If isEdit Then
            '            tmpImage.Save(tmpPathPlus)
            '            Results.ImagePath = tmpPathPlus
            '        Else
            '            If DLType = Enums.ImageType.Fanart Then
            '                Results.ImagePath = tmpImage.SaveAsFanart(tMovie)
            '            Else
            '                Results.ImagePath = tmpImage.SaveAsPoster(tMovie)
            '            End If
            '        End If
            '    Else
            '        pnlBG.Visible = False
            '        pnlSinglePic.Visible = True
            '        Refresh()
            '        Application.DoEvents()
            '        Select Case True
            '            Case rbXLarge.Checked
            '                If Master.eSettings.UseImgCache Then
            '                    tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(original)_(url=", rbXLarge.Tag, ").jpg")))
            '                Else
            '                    If extrathumbSize = "original" And DLType = Enums.ImageType.Fanart Then
            '                        tmpImage.Image = pbImage(selIndex).Image
            '                    Else
            '                        tmpImage.FromWeb(rbXLarge.Tag.ToString)
            '                    End If
            '                End If
            '            Case rbLarge.Checked
            '                If Master.eSettings.UseImgCache Then
            '                    tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(mid)_(url=", rbLarge.Tag, ").jpg")))
            '                Else
            '                    If extrathumbSize = "w1280" And DLType = Enums.ImageType.Fanart Or Not DLType = Enums.ImageType.Fanart Then
            '                        tmpImage.Image = pbImage(selIndex).Image
            '                    Else
            '                        tmpImage.FromWeb(rbLarge.Tag.ToString)
            '                    End If
            '                End If
            '            Case rbMedium.Checked
            '                If extrathumbSize = "poster" And DLType = Enums.ImageType.Fanart Then
            '                    tmpImage.Image = pbImage(selIndex).Image
            '                Else
            '                    tmpImage.FromWeb(rbMedium.Tag.ToString)
            '                End If
            '            Case rbSmall.Checked
            '                If Master.eSettings.UseImgCache Then
            '                    tmpImage.FromFile(Path.Combine(CachePath, String.Concat("poster_(thumb)_(url=", rbSmall.Tag, ").jpg")))
            '                Else
            '                    If extrathumbSize = "thumb" And DLType = Enums.ImageType.Fanart Then
            '                        tmpImage.Image = pbImage(selIndex).Image
            '                    Else
            '                        tmpImage.FromWeb(rbSmall.Tag.ToString)
            '                    End If
            '                End If
            '        End Select

            '        If Not IsNothing(tmpImage.Image) Then
            '            If isEdit Then
            '                tmpImage.Save(tmpPathPlus)
            '                Results.ImagePath = tmpPathPlus
            '            Else
            '                If DLType = Enums.ImageType.Fanart Then
            '                    Results.ImagePath = tmpImage.SaveAsFanart(tMovie)
            '                Else
            '                    Results.ImagePath = tmpImage.SaveAsPoster(tMovie)
            '                End If
            '            End If
            '        End If
            '        pnlSinglePic.Visible = False
            '    End If

            '    If DLType = Enums.ImageType.Fanart Then
            '        Dim iMod As Integer = 0
            '        Dim iVal As Integer = 1
            '        Dim extraPath As String = String.Empty
            '        Dim isChecked As Boolean = False

            '        For i As Integer = 0 To UBound(chkImage)
            '            If chkImage(i).Checked Then
            '                isChecked = True
            '                Exit For
            '            End If
            '        Next

            '        If isChecked Then
            '            Dim extrathumbsFolderName As String = AdvancedSettings.GetSetting("ExtraThumbsFolderName", "extrathumbs")
            '            If isEdit Then
            '                extraPath = Path.Combine(Master.TempPath, extrathumbsFolderName)
            '            Else
            '                If Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isVideoTS(tMovie.Filename) Then
            '                    extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(tMovie.Filename).FullName).FullName, extrathumbsFolderName)
            '                ElseIf Master.eSettings.VideoTSParent AndAlso FileUtils.Common.isBDRip(tMovie.Filename) Then
            '                    extraPath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(tMovie.Filename).FullName).FullName).FullName, extrathumbsFolderName)
            '                Else
            '                    extraPath = Path.Combine(Directory.GetParent(tMovie.Filename).FullName, extrathumbsFolderName)
            '                End If
            '                iMod = Functions.GetExtraModifier(extraPath)
            '                iVal = iMod + 1
            '            End If

            '            If Not Directory.Exists(extraPath) Then
            '                Directory.CreateDirectory(extraPath)
            '            End If

            '            Dim fsET As FileStream
            '            For i As Integer = 0 To UBound(chkImage)
            '                If chkImage(i).Checked Then
            '                    fsET = New FileStream(Path.Combine(extraPath, String.Concat("thumb", iVal, ".jpg")), FileMode.Create, FileAccess.ReadWrite)
            '                    pbImage(i).Image.Save(fsET, System.Drawing.Imaging.ImageFormat.Jpeg)
            '                    fsET.Close()
            '                    iVal += 1
            '                End If
            '            Next
            '            fsET = Nothing
            '        End If
            '    End If
            'Catch ex As Exception
            '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            'End Try

            'DialogResult = System.Windows.Forms.DialogResult.OK
            'Close()
        End Sub

        Private Sub pbImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DoSelect(Convert.ToInt32(DirectCast(sender, PictureBox).Tag))
        End Sub

        Private Sub pbImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim imgTag = _imageList(Integer.Parse(sender.Tag))
            Dim tempImage As Image
            If String.IsNullOrEmpty(imgTag.Preview) Then
                tempImage = imgTag.Img
            Else
                Dim url As String = imgTag.Thumb
                tempImage = DownloadFanart(url)
            End If
            If tempImage IsNot Nothing Then
                dlgImgView.ShowDialog(tempImage)
            End If
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

        Private Sub pnlImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iIndex As Integer = Convert.ToInt32(DirectCast(sender, Panel).Name)
            DoSelect(iIndex)
        End Sub

        Private Sub ProcessPics(ByVal posters As List(Of Thumbnail))
            Try
                Dim iIndex As Integer = 0

                If posters.Count > 0 Then
                    For Each xPoster In posters
                        AddImage(xPoster, iIndex)
                        iIndex += 1
                    Next
                Else
                    If Not PreDL OrElse isShown Then
                        If _imageType = Enums.ImageType.Fanart Then
                            MsgBox(Master.eLang.GetString(28, "No Fanart found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(29, "No Fanart Found"))
                        Else
                            MsgBox(Master.eLang.GetString(30, "No Posters found for this movie."), MsgBoxStyle.Information, Master.eLang.GetString(31, "No Posters Found"))
                        End If
                        DialogResult = Windows.Forms.DialogResult.Cancel
                        Close()
                    Else
                        noImages = True
                    End If
                End If

                Activate()

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub rbLarge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            OK_Button.Enabled = True
            btnPreview.Enabled = True
        End Sub

        Private Sub rbMedium_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            OK_Button.Enabled = True
            btnPreview.Enabled = True
        End Sub

        Private Sub rbSmall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            OK_Button.Enabled = True
            btnPreview.Enabled = True
        End Sub

        Private Sub rbXLarge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            OK_Button.Enabled = True
            btnPreview.Enabled = True
        End Sub

        Private Sub SetUp()
            Try
                AddHandler MyBase.MouseWheel, AddressOf MouseWheelEvent
                AddHandler pnlImages.MouseWheel, AddressOf MouseWheelEvent

                Functions.PNLDoubleBuffer(pnlImages)

                If _imageType = Enums.ImageType.Posters Then
                    Text = String.Concat(Master.eLang.GetString(39, "Select Poster - "), If(Not String.IsNullOrEmpty(_currentMovie.Title), _currentMovie.Title, _currentMovie.ListTitle))
                Else
                    Text = String.Concat(Master.eLang.GetString(40, "Select Fanart - "), If(Not String.IsNullOrEmpty(_currentMovie.Title), _currentMovie.Title, _currentMovie.ListTitle))
                    pnlStatus.Height = 75
                    pnlStatus.Top = 207

                    If Master.eSettings.AutoET Then
                        ETHashes = HashFile.CurrentETHashes(_currentMovie.MoviePath)
                    End If
                End If

                CachePath = String.Concat(Master.TempPath, Path.DirectorySeparatorChar, _currentMovie.ID, Path.DirectorySeparatorChar, If(_imageType = Enums.ImageType.Posters, "posters", "fanart"))

                OK_Button.Text = Master.eLang.GetString(179, "OK", True)
                Cancel_Button.Text = Master.eLang.GetString(167, "Cancel", True)
                btnPreview.Text = Master.eLang.GetString(180, "Preview", True)
                chkThumb.Text = Master.eLang.GetString(41, "Check All Thumb")
                chkMid.Text = Master.eLang.GetString(42, "Check All Mid")
                chkOriginal.Text = Master.eLang.GetString(43, "Check All Original")
                lblInfo.Text = Master.eLang.GetString(44, "Selected item will be set as fanart. All checked items will be saved to \extrathumbs.")
                lblStatus.Text = Master.eLang.GetString(45, "Performing Preliminary Tasks...")
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        'Private Sub SetupSizes(ByVal ParentID As String)
        '    Try
        '        rbXLarge.Checked = False
        '        rbXLarge.Enabled = False
        '        rbXLarge.Text = Master.eLang.GetString(47, "Original")
        '        rbLarge.Checked = False
        '        rbLarge.Enabled = False
        '        rbMedium.Checked = False
        '        rbSmall.Checked = False
        '        rbSmall.Enabled = False
        '        If DLType = Enums.ImageType.Fanart Then
        '            rbLarge.Text = "w1280"
        '            rbMedium.Text = "poster"
        '            rbSmall.Text = "thumb"
        '        Else
        '            rbLarge.Text = Master.eLang.GetString(48, "Cover")
        '            rbMedium.Text = Master.eLang.GetString(49, "Medium")
        '            rbSmall.Text = Master.eLang.GetString(50, "Small")
        '        End If

        '        For Each TMDBPoster As MediaContainers.Image In TMDBPosters.Where(Function(f) f.ParentID = ParentID)
        '            Select Case TMDBPoster.Description
        '                Case "original"
        '                    ' xlarge
        '                    If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPoster.WebImage.Image) Then
        '                        rbXLarge.Enabled = True
        '                        rbXLarge.Tag = TMDBPoster.URL
        '                        'If Master.eSettings.UseImgCache Then rbXLarge.Text = String.Format(Master.eLang.GetString(51, "Original ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                        rbXLarge.Text = String.Format(Master.eLang.GetString(51, "Original ({0}x{1})"), TMDBPoster.Width, TMDBPoster.Height)
        '                    End If
        '                Case "cover"
        '                    ' large
        '                    If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPoster.WebImage.Image) Then
        '                        rbLarge.Enabled = True
        '                        rbLarge.Tag = TMDBPoster.URL
        '                        'If Master.eSettings.UseImgCache Then rbLarge.Text = String.Format(Master.eLang.GetString(52, "Cover ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                        rbLarge.Text = String.Format(Master.eLang.GetString(52, "Cover ({0}x{1})"), TMDBPoster.Width, TMDBPoster.Height)
        '                    End If
        '                Case "w1280"
        '                    ' large
        '                    If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPoster.WebImage.Image) Then
        '                        rbLarge.Enabled = True
        '                        rbLarge.Tag = TMDBPoster.URL
        '                        'If Master.eSettings.UseImgCache Then rbLarge.Text = String.Format(Master.eLang.GetString(52, "Cover ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                        rbLarge.Text = String.Format("w1280 ({0}x{1})", TMDBPoster.Width, TMDBPoster.Height)
        '                    End If
        '                Case "thumb"
        '                    ' small                        
        '                    If Not Master.eSettings.UseImgCache OrElse Not IsNothing(TMDBPoster.WebImage.Image) Then
        '                        rbSmall.Enabled = True
        '                        rbSmall.Tag = TMDBPoster.URL
        '                        'If Master.eSettings.UseImgCache Then rbSmall.Text = String.Format(Master.eLang.GetString(53, "Small ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                        rbSmall.Text = String.Format(Master.eLang.GetString(53, "Small ({0}x{1})"), TMDBPoster.Width, TMDBPoster.Height)
        '                    End If
        '                Case "mid"
        '                    'If Master.eSettings.UseImgCache Then rbMedium.Text = String.Format(Master.eLang.GetString(54, "Medium ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                    rbMedium.Text = String.Format(Master.eLang.GetString(54, "Medium ({0}x{1})"), TMDBPoster.Width, TMDBPoster.Height)
        '                    rbMedium.Tag = TMDBPoster.URL
        '                Case "poster"
        '                    'If Master.eSettings.UseImgCache Then rbMedium.Text = String.Format(Master.eLang.GetString(54, "Medium ({0}x{1})"), TMDBPosters.Item(i).WebImage.Image.Width, TMDBPosters.Item(i).WebImage.Image.Height)
        '                    rbMedium.Text = String.Format("Poster ({0}x{1})", TMDBPoster.Width, TMDBPoster.Height)
        '                    rbMedium.Tag = TMDBPoster.URL
        '            End Select
        '        Next

        '        Select Case Master.eSettings.PreferredPosterSize
        '            Case Enums.PosterSize.Small
        '                rbSmall.Checked = rbSmall.Enabled
        '            Case Enums.PosterSize.Mid
        '                rbMedium.Checked = rbMedium.Enabled
        '            Case Enums.PosterSize.Lrg
        '                rbLarge.Checked = rbLarge.Enabled
        '            Case Enums.PosterSize.Xlrg
        '                rbXLarge.Checked = rbXLarge.Enabled
        '        End Select

        '        pnlSize.Visible = True

        '        Invalidate()
        '    Catch ex As Exception
        '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        '    End Try
        'End Sub

        Private Sub StartDownload()
            Try
                Dim currentScraper As ScraperInfo = (From s In Master.ScraperMan.AllScrapers Where s.ScraperName = "IMDb").SingleOrDefault()
                Dim imageSizeSettings As ScraperSetting
                Select Case _imageType
                    Case Enums.ImageType.Posters
                        GetPosters()
                        imageSizeSettings = currentScraper.Settings.Find(Function(f) f.ID = "postersize")
                    Case Enums.ImageType.Fanart
                        GetFanart()
                        imageSizeSettings = currentScraper.Settings.Find(Function(f) f.ID = "fanartsize")
                End Select
                If imageSizeSettings IsNot Nothing Then
                    For Each itm In imageSizeSettings.Values
                        Dim rdButton As New RadioButton
                        rdButton.Name = itm
                        rdButton.Text = itm
                        pnlSize.Controls.Add(rdButton)
                    Next
                    pnlSize.Visible = True
                Else
                    pnlSize.Visible = False
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

#End Region 'Methods
    End Class
End Namespace