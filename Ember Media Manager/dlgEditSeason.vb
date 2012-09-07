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
Imports EmberMediaManger.API

Public Class dlgEditSeason

#Region "Fields"

    Private Fanart As New Images With {.IsEdit = True}
    Private Poster As New Images With {.IsEdit = True}
    Private _currentTVSeason As Model.TVSeason
    Private _detailTVSeason As Model.TVSeason

#End Region 'Fields

#Region "Methods"

    Public Overloads Function ShowDialog(ByVal inSeason As Model.TVSeason) As Model.TVSeason
        '//
        ' Overload to pass data
        '\\
        _currentTVSeason = inSeason
        _detailTVSeason = Classes.Database.GetTVShowSeason(_currentTVSeason.TVShowID, _currentTVSeason.Season)
        If ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return _currentTVSeason
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnRemoveFanart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveFanart.Click
        pbFanart.Image = Nothing
        Fanart.Image = Nothing
    End Sub

    Private Sub btnRemovePoster_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemovePoster.Click
        pbPoster.Image = Nothing
        Poster.Image = Nothing
    End Sub

    Private Sub btnSetFanartDL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanartDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Fanart) = DialogResult.OK Then
                    Fanart.FromFile(Path.Combine(Master.TempPath, "fanart.jpg"))
                    pbFanart.Image = Fanart.Image

                    lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
                    lblFanartSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetFanartScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanartScrape.Click
        Dim returnImage = Scrapers.TV.dlgTVImageSelect.ShowDialog(_detailTVSeason, Enums.TVImageType.SeasonFanart, Enums.ScrapeType.SingleScrape, pbFanart.Image)
        If (returnImage IsNot Nothing) Then
            Fanart.Image = returnImage
            pbFanart.Image = returnImage

            lblFanartSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
            lblPosterSize.Visible = True
        End If        
    End Sub

    Private Sub btnSetFanart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetFanart.Click
        Try
            With ofdImage
                .InitialDirectory = Master.currShow.TVShow.TVShowPath
                .Filter = "JPEGs|*.jpg"
                .FilterIndex = 4
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Fanart.FromFile(ofdImage.FileName)
                pbFanart.Image = Fanart.Image

                lblFanartSize.Text = String.Format(Languages.Size_Param, pbFanart.Image.Width, pbFanart.Image.Height)
                lblFanartSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPosterDL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPosterDL.Click
        Try
            Using dImgManual As New dlgImgManual
                If dImgManual.ShowDialog(Enums.ImageType.Posters) = DialogResult.OK Then
                    Poster.FromFile(Path.Combine(Master.TempPath, "poster.jpg"))
                    pbPoster.Image = Poster.Image

                    lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub btnSetPosterScrape_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPosterScrape.Click
        Dim returnImage = Scrapers.TV.dlgTVImageSelect.ShowDialog(_detailTVSeason, Enums.TVImageType.SeasonPoster, Enums.ScrapeType.SingleScrape, pbPoster.Image)
        If (returnImage IsNot Nothing) Then
            Poster.Image = returnImage
            pbPoster.Image = returnImage

            lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
            lblPosterSize.Visible = True
        End If
    End Sub

    Private Sub btnSetPoster_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetPoster.Click
        Try
            With ofdImage
                .InitialDirectory = Master.currShow.TVShow.TVShowPath
                .Filter = "Supported Images(*.jpg, *.jpeg, *.tbn)|*.jpg;*.jpeg;*.tbn|jpeg (*.jpg, *.jpeg)|*.jpg;*.jpeg|tbn (*.tbn)|*.tbn"
                .FilterIndex = 0
            End With

            If ofdImage.ShowDialog() = DialogResult.OK Then
                Poster.FromFile(ofdImage.FileName)
                pbPoster.Image = Poster.Image

                lblPosterSize.Text = String.Format(Languages.Size_Param, pbPoster.Image.Width, pbPoster.Image.Height)
                lblPosterSize.Visible = True
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub CleanUp()
        Try
            If File.Exists(Path.Combine(Master.TempPath, "poster.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "poster.jpg"))
            End If

            If File.Exists(Path.Combine(Master.TempPath, "fanart.jpg")) Then
                File.Delete(Path.Combine(Master.TempPath, "fanart.jpg"))
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub dlgEditSeason_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Master.eSettings.SeasonFanartEnabled AndAlso Not String.IsNullOrEmpty(Functions.GetSeasonDirectoryFromShowPath(Master.currShow.TVShow.TVShowPath, Master.currShow.Season)) Then TabControl1.TabPages.Remove(TabPage3)

        SetUp()

        Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
        Using g As Graphics = Graphics.FromImage(iBackground)
            g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
            pnlTop.BackgroundImage = iBackground
        End Using

        FillInfo()
    End Sub

    Private Sub FillInfo()
        With Me

            If Master.eSettings.SeasonFanartEnabled AndAlso Not String.IsNullOrEmpty(Functions.GetSeasonDirectoryFromShowPath(_detailTVSeason.TVShow.TVShowPath, _detailTVSeason.Season)) Then
                Fanart.FromFile(_detailTVSeason.FanartPath)
                If Not IsNothing(Fanart.Image) Then
                    .pbFanart.Image = Fanart.Image

                    .lblFanartSize.Text = String.Format(Languages.Size_Param, .pbFanart.Image.Width, .pbFanart.Image.Height)
                    .lblFanartSize.Visible = True
                End If
            End If

            Poster.FromFile(_detailTVSeason.PosterPath)
            If Not IsNothing(Poster.Image) Then
                .pbPoster.Image = Poster.Image

                .lblPosterSize.Text = String.Format(Languages.Size_Param, .pbPoster.Image.Width, .pbPoster.Image.Height)
                .lblPosterSize.Visible = True
            End If
        End With
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            SetInfo()

            'Classes.Database.SaveTVSeason(Master.currShow.
            'Master.DB.SaveTVSeasonToDB(Master.currShow, False)

            CleanUp()

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try

        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub SetInfo()
        Try
            With Me

                If Master.eSettings.SeasonFanartEnabled AndAlso Not String.IsNullOrEmpty(Functions.GetSeasonDirectoryFromShowPath(_detailTVSeason.TVShow.TVShowPath, _detailTVSeason.Season)) Then
                    If Not IsNothing(.Fanart.Image) Then
                        Dim fPath As String = .Fanart.SaveAsSeasonFanart(_detailTVSeason)
                        _currentTVSeason.FanartPath = fPath
                    Else
                        .Fanart.DeleteSeasonFanart(_detailTVSeason)
                        _currentTVSeason.FanartPath = String.Empty
                    End If
                End If

                If Not IsNothing(.Poster.Image) Then
                    Dim pPath As String = .Poster.SaveAsSeasonPoster(_detailTVSeason)
                    _currentTVSeason.PosterPath = pPath
                Else
                    .Poster.DeleteSeasonPosters(_detailTVSeason)
                    _currentTVSeason.PosterPath = String.Empty
                End If
            End With
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
        End Try
    End Sub

    Private Sub SetUp()
        Me.Text = Master.eLang.GetString(769, "Edit Season")
        Me.OK_Button.Text = Master.eLang.GetString(179, "OK")
        Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
        Me.Label2.Text = Master.eLang.GetString(830, "Edit the details for the selected season.")
        Me.Label1.Text = Me.Text
        Me.TabPage2.Text = Master.eLang.GetString(148, "Poster")
        Me.btnRemovePoster.Text = Master.eLang.GetString(247, "Remove Poster")
        Me.btnSetPosterScrape.Text = Master.eLang.GetString(248, "Change Poster (Scrape)")
        Me.btnSetPoster.Text = Master.eLang.GetString(249, "Change Poster (Local)")
        Me.TabPage3.Text = Master.eLang.GetString(149, "Fanart")
        Me.btnRemoveFanart.Text = Master.eLang.GetString(250, "Remove Fanart")
        Me.btnSetFanartScrape.Text = Master.eLang.GetString(251, "Change Fanart (Scrape)")
        Me.btnSetFanart.Text = Master.eLang.GetString(252, "Change Fanart (Local)")
        Me.btnSetPosterDL.Text = Master.eLang.GetString(265, "Change Poster (Download)")
        Me.btnSetFanartDL.Text = Master.eLang.GetString(266, "Change Fanart (Download)")
    End Sub

#End Region 'Methods

End Class