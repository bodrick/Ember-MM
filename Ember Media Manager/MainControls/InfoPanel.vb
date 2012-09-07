Imports System.ComponentModel
Imports EmberMediaManger.API
Imports System.Data.Objects
Imports System.Threading.Tasks

Public Class InfoPanel
    Public Sub Clear()
        pnlTop250.Visible = False
        lblTop250.Text = String.Empty
        lstActors.Items.Clear()
        If Not IsNothing(pbActors.Image) Then
            pbActors.Image.Dispose()
            pbActors.Image = Nothing
        End If
        lblDirector.Text = String.Empty
        lblReleaseDate.Text = String.Empty
        txtCerts.Text = String.Empty
        txtIMDBID.Text = String.Empty
        txtFilePath.Text = String.Empty
        txtOutline.Text = String.Empty
        txtPlot.Text = String.Empty
        txtMetaData.Text = String.Empty
    End Sub

    Public Sub Setup()
        lblCertsHeader.Text = Languages.Certifications
        lblReleaseDateHeader.Text = Languages.Release_Date
        lblFilePathHeader.Text = Languages.File_Path
        lblIMDBHeader.Text = Languages.IMDB_ID
        lblDirectorHeader.Text = Languages.Director
        xppMeta.Text = Languages.Meta_Data
        xppCast.Text = Languages.Cast
        xppPlotOutline.Text = Languages.Plot_Outline
        xppPlot.Text = Languages.Plot
        xppMisc.Text = Languages.Miscellaneous
    End Sub

    <Localizable(False)>
    Private Sub lblIMDBHeader_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblIMDBHeader.Click
        If Not String.IsNullOrEmpty(txtIMDBID.Text) Then
            If Master.isWindows Then
                Process.Start(String.Format("http://www.imdb.com/title/tt{0}/", txtIMDBID.Text))
            Else
                Using Explorer As New Process
                    Explorer.StartInfo.FileName = "xdg-open"
                    Explorer.StartInfo.Arguments = String.Format("http://www.imdb.com/title/tt{0}/", txtIMDBID.Text)
                    Explorer.Start()
                End Using
            End If
        End If
    End Sub

    Private Sub lblIMDBHeader_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles lblIMDBHeader.MouseEnter
        If Not String.IsNullOrEmpty(txtIMDBID.Text) Then
            lblIMDBHeader.Tag = lblIMDBHeader.ForeColor
            lblIMDBHeader.ForeColor = Color.FromArgb(Not lblIMDBHeader.ForeColor.R, Not lblIMDBHeader.ForeColor.G, Not lblIMDBHeader.ForeColor.B)
            Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub lblIMDBHeader_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles lblIMDBHeader.MouseLeave
        If Not lblIMDBHeader.Tag Is Nothing Then
            lblIMDBHeader.ForeColor = DirectCast(lblIMDBHeader.Tag, Color)
            Cursor = Cursors.Default
            lblIMDBHeader.Tag = Nothing
        End If
    End Sub

    <Localizable(False)>
    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        '//
        ' Launch video using system default player
        '\\

        Try
            If Not String.IsNullOrEmpty(txtFilePath.Text) Then
                If IO.File.Exists(txtFilePath.Text) Then
                    If Master.isWindows Then
                        Process.Start(String.Concat("""", txtFilePath.Text, """"))
                    Else
                        Using Explorer As New Process
                            Explorer.StartInfo.FileName = "xdg-open"
                            Explorer.StartInfo.Arguments = String.Format("""{0}""", txtFilePath.Text)
                            Explorer.Start()
                        End Using
                    End If

                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Public Sub LoadInfo(currentMedia As Object)
        Select Case ObjectContext.GetObjectType(currentMedia.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(currentMedia, Model.Movie)

                Try
                    If Not String.IsNullOrEmpty(currentMovie.Top250) AndAlso IsNumeric(currentMovie.Top250) AndAlso (IsNumeric(currentMovie.Top250) AndAlso Convert.ToInt32(currentMovie.Top250) > 0) Then
                        pnlTop250.Visible = True
                        lblTop250.Text = currentMovie.Top250
                    Else
                        pnlTop250.Visible = False
                    End If

                    txtOutline.Text = currentMovie.Outline
                    txtPlot.Text = currentMovie.Plot

                    pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
                    lstActors.DataSource = (From r In Classes.Database.GetMovieActors(currentMovie.ID) Select New With {.Name = String.Format("{0} as {1}", r.ActorName, r.Role), .ThumbUrl = r.Actor.thumb}).ToList()
                    lstActors.ValueMember = "ThumbUrl"
                    lstActors.DisplayMember = "Name"
                    lstActors.SelectedIndex = 0

                    lblDirector.Text = currentMovie.Director
                    txtIMDBID.Text = currentMovie.Imdb
                    txtFilePath.Text = Master.currMovie.MoviePath
                    lblReleaseDate.Text = currentMovie.ReleaseDate
                    txtCerts.Text = currentMovie.Certification
                    txtFilePath.Text = currentMovie.MoviePath

                    'txtMetaData.Text = NFO.FIToString(currentMovie.FileInfo, False)
                    xppMisc.Visible = True
                    xppMeta.Visible = True
                    xppPlotOutline.Visible = True
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                End Try
            Case GetType(Model.TVShow)
                Dim currentTVShow = DirectCast(currentMedia, Model.TVShow)
                Try
                    txtPlot.Text = currentTVShow.Plot
                    pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
                    xppMisc.Visible = False
                    xppMeta.Visible = False
                    xppPlotOutline.Visible = False
                    lstActors.DataSource = (From r In Classes.Database.GetTVShowActors(currentTVShow.ID) Select New With {.Name = String.Format("{0} as {1}", r.ActorName, r.Role), .ThumbUrl = r.Actor.thumb}).ToList()
                    lstActors.ValueMember = "ThumbUrl"
                    lstActors.DisplayMember = "Name"
                    lstActors.SelectedIndex = 0
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                End Try
            Case GetType(Model.TVSeason)
                Dim currentTVSeason = DirectCast(currentMedia, Model.TVSeason)
                Dim currentTVShow = Classes.Database.GetTVShow(currentTVSeason.TVShowID)
                Try
                    txtPlot.Text = currentTVShow.Plot
                    pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
                    xppMisc.Visible = False
                    xppMeta.Visible = False
                    xppPlotOutline.Visible = False
                    lstActors.DataSource = (From r In Classes.Database.GetTVShowActors(currentTVShow.ID) Select New With {.Name = String.Format("{0} as {1}", r.ActorName, r.Role), .ThumbUrl = r.Actor.thumb}).ToList()
                    lstActors.ValueMember = "ThumbUrl"
                    lstActors.DisplayMember = "Name"
                    lstActors.SelectedIndex = 0
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                End Try
            Case GetType(Model.TVEp)
                Dim currentTVEp = DirectCast(currentMedia, Model.TVEp)
                Try
                    txtPlot.Text = currentTVEp.Plot
                    pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
                    lblDirector.Text = currentTVEp.Director
                    txtFilePath.Text = currentTVEp.TVEpPath.FilePath
                    xppMisc.Visible = True
                    xppMeta.Visible = True
                    xppPlotOutline.Visible = False
                    lstActors.DataSource = (From r In Classes.Database.GetTVEpActors(currentTVEp.ID) Select New With {.Name = String.Format("{0} as {1}", r.ActorName, r.Role), .ThumbUrl = r.Actor.thumb}).ToList()
                    lstActors.ValueMember = "ThumbUrl"
                    lstActors.DisplayMember = "Name"
                    lstActors.SelectedIndex = 0
                    '            Me.txtMetaData.Text = NFO.FIToString(Master.currShow.TVEp.FileInfo, True)
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                End Try
        End Select
    End Sub

    <Localizable(False)>
    Private Sub lstActors_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstActors.SelectedValueChanged
        '//
        ' Begin thread to download actor image if one exists
        '\\
        Try
            Dim currentItem = lstActors.SelectedItem
            If Not String.IsNullOrEmpty(currentItem.ThumbUrl) AndAlso currentItem.ThumbUrl <> "none" Then
                If Not IsNothing(pbActors.Image) Then
                    pbActors.Image.Dispose()
                    pbActors.Image = Nothing
                End If

                pbActLoad.Visible = True                
                Dim downloadTask As Task(Of Image) = Task.Factory.StartNew(Function() Classes.Http.DownloadImage(currentItem.ThumbUrl))
                While Not downloadTask.IsCompleted
                    Application.DoEvents()
                    Threading.Thread.Sleep(50)
                End While
                pbActLoad.Visible = False
                If downloadTask.Result IsNot Nothing Then
                    pbActors.Image = downloadTask.Result
                Else
                    pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
                End If
            Else
                pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            pbActors.Image = My.Resources.Modules.img_Actor_Silhouette
            pbActLoad.Visible = False
        End Try
    End Sub


    '    Private Sub btnMIRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '//
    '        ' Refresh Media Info
    '        '\\

    '        If Me.tabsMain.SelectedIndex = 0 Then
    '            If Not String.IsNullOrEmpty(Master.currMovie.Filename) AndAlso Me.dgvMediaList.SelectedRows.Count > 0 Then
    '                Me.LoadInfo(Convert.ToInt32(Master.currMovie.ID), Master.currMovie.Filename, False, True, True)
    '            End If
    '        ElseIf Not String.IsNullOrEmpty(Master.currShow.Filename) AndAlso Me.dgvTVEpisodes.SelectedRows.Count > 0 Then
    '            Me.SetControlsEnabled(False, True)

    '            If Me.bwMediaInfo.IsBusy Then Me.bwMediaInfo.CancelAsync()

    '            Me.txtMetaData.Clear()
    '            Me.pbMILoading.Visible = True

    '            Me.bwMediaInfo = New System.ComponentModel.BackgroundWorker
    '            Me.bwMediaInfo.WorkerSupportsCancellation = True
    '            Me.bwMediaInfo.RunWorkerAsync(New Arguments With {.TVShow = Master.currShow, .IsTV = True, .setEnabled = True})
    '        End If
    '    End Sub
End Class
