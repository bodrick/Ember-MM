Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class TVImages
        Private Sub chkOnlyTVImagesLanguage_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkOnlyTVImagesLanguage.CheckedChanged
            chkGetEnglishImages.Enabled = chkOnlyTVImagesLanguage.Checked
            If Not chkOnlyTVImagesLanguage.Checked Then chkGetEnglishImages.Checked = False
        End Sub

        Private Sub chkResizeAllSPoster_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeAllSPoster.CheckedChanged
            txtAllSPosterWidth.Enabled = chkResizeAllSPoster.Checked
            txtAllSPosterHeight.Enabled = chkResizeAllSPoster.Checked
            If Not chkResizeAllSPoster.Checked Then
                txtAllSPosterWidth.Text = String.Empty
                txtAllSPosterHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkResizeEpFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeEpFanart.CheckedChanged
            txtEpFanartWidth.Enabled = chkResizeEpFanart.Checked
            txtEpFanartHeight.Enabled = chkResizeEpFanart.Checked
            If Not chkResizeEpFanart.Checked Then
                txtEpFanartWidth.Text = String.Empty
                txtEpFanartHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkResizeEpPoster_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeEpPoster.CheckedChanged
            txtEpPosterWidth.Enabled = chkResizeEpPoster.Checked
            txtEpPosterHeight.Enabled = chkResizeEpPoster.Checked
            If Not chkResizeEpFanart.Checked Then
                txtEpPosterWidth.Text = String.Empty
                txtEpPosterHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkResizeShowFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeShowFanart.CheckedChanged
            txtShowFanartWidth.Enabled = chkResizeShowFanart.Checked
            txtShowFanartHeight.Enabled = chkResizeShowFanart.Checked
            If Not chkResizeShowFanart.Checked Then
                txtShowFanartWidth.Text = String.Empty
                txtShowFanartHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkResizeShowPoster_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeShowPoster.CheckedChanged
            txtShowPosterWidth.Enabled = chkResizeShowPoster.Checked
            txtShowPosterHeight.Enabled = chkResizeShowPoster.Checked
            If Not chkResizeShowPoster.Checked Then
                txtShowPosterWidth.Text = String.Empty
                txtShowPosterHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkSeaResizeFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkSeaResizeFanart.CheckedChanged
            txtSeaFanartWidth.Enabled = chkSeaResizeFanart.Checked
            txtSeaFanartHeight.Enabled = chkSeaResizeFanart.Checked
            If Not chkSeaResizeFanart.Checked Then
                txtSeaFanartWidth.Text = String.Empty
                txtSeaFanartHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkSeaResizePoster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeaResizePoster.CheckedChanged
            txtSeaPosterWidth.Enabled = chkSeaResizePoster.Checked
            txtSeaPosterHeight.Enabled = chkSeaResizePoster.Checked
            If Not chkSeaResizePoster.Checked Then
                txtSeaPosterWidth.Text = String.Empty
                txtSeaPosterHeight.Text = String.Empty
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            If Master.eSettings.IsShowBanner Then
                rbBanner.Checked = True
                cbShowPosterSize.SelectedIndex = Master.eSettings.PreferredShowBannerType
            Else
                rbPoster.Checked = True
                cbShowPosterSize.SelectedIndex = Master.eSettings.PreferredShowPosterSize
            End If
            If Master.eSettings.IsAllSBanner Then
                rbAllSBanner.Checked = True
                cbAllSPosterSize.SelectedIndex = Master.eSettings.PreferredAllSBannerType
            Else
                rbAllSPoster.Checked = True
                cbAllSPosterSize.SelectedIndex = Master.eSettings.PreferredAllSPosterSize
            End If
            cbShowFanartSize.SelectedIndex = Master.eSettings.PreferredShowFanartSize
            cbEpFanartSize.SelectedIndex = Master.eSettings.PreferredEpFanartSize
            cbSeaPosterSize.SelectedIndex = Master.eSettings.PreferredSeasonPosterSize
            cbSeaFanartSize.SelectedIndex = Master.eSettings.PreferredSeasonFanartSize

            tbShowPosterQual.Value = Master.eSettings.ShowPosterQuality
            tbShowFanartQual.Value = Master.eSettings.ShowFanartQuality
            tbAllSPosterQual.Value = Master.eSettings.AllSPosterQuality
            tbEpPosterQual.Value = Master.eSettings.EpPosterQuality
            tbEpFanartQual.Value = Master.eSettings.EpFanartQuality
            tbSeaPosterQual.Value = Master.eSettings.SeasonPosterQuality
            tbSeaFanartQual.Value = Master.eSettings.SeasonFanartQuality
            chkOverwriteShowPoster.Checked = Master.eSettings.OverwriteShowPoster
            chkOverwriteAllSPoster.Checked = Master.eSettings.OverwriteAllSPoster
            chkOverwriteShowFanart.Checked = Master.eSettings.OverwriteShowFanart
            chkOverwriteEpPoster.Checked = Master.eSettings.OverwriteEpPoster
            chkOverwriteEpFanart.Checked = Master.eSettings.OverwriteEpFanart
            chkSeaOverwritePoster.Checked = Master.eSettings.OverwriteSeasonPoster
            chkSeaOverwriteFanart.Checked = Master.eSettings.OverwriteSeasonFanart
            chkResizeShowFanart.Checked = Master.eSettings.ResizeShowFanart
            If Master.eSettings.ResizeShowFanart Then
                txtShowFanartWidth.Text = Master.eSettings.ShowFanartWidth.ToString
                txtShowFanartHeight.Text = Master.eSettings.ShowFanartHeight.ToString
            End If
            chkResizeShowPoster.Checked = Master.eSettings.ResizeShowPoster
            If Master.eSettings.ResizeShowPoster Then
                txtShowPosterWidth.Text = Master.eSettings.ShowPosterWidth.ToString
                txtShowPosterHeight.Text = Master.eSettings.ShowPosterHeight.ToString
            End If
            chkResizeAllSPoster.Checked = Master.eSettings.ResizeAllSPoster
            If Master.eSettings.ResizeAllSPoster Then
                txtAllSPosterWidth.Text = Master.eSettings.AllSPosterWidth.ToString
                txtAllSPosterHeight.Text = Master.eSettings.AllSPosterHeight.ToString
            End If
            chkResizeEpFanart.Checked = Master.eSettings.ResizeEpFanart
            If Master.eSettings.ResizeEpFanart Then
                txtEpFanartWidth.Text = Master.eSettings.EpFanartWidth.ToString
                txtEpFanartHeight.Text = Master.eSettings.EpFanartHeight.ToString
            End If
            chkResizeEpPoster.Checked = Master.eSettings.ResizeEpPoster
            If Master.eSettings.ResizeEpPoster Then
                txtEpPosterWidth.Text = Master.eSettings.EpPosterWidth.ToString
                txtEpPosterHeight.Text = Master.eSettings.EpPosterHeight.ToString
            End If
            chkSeaResizeFanart.Checked = Master.eSettings.ResizeSeasonFanart
            If Master.eSettings.ResizeSeasonFanart Then
                txtSeaFanartWidth.Text = Master.eSettings.SeasonFanartWidth.ToString
                txtSeaFanartHeight.Text = Master.eSettings.SeasonFanartHeight.ToString
            End If
            chkSeaResizePoster.Checked = Master.eSettings.ResizeSeasonPoster
            If Master.eSettings.ResizeSeasonPoster Then
                txtSeaPosterWidth.Text = Master.eSettings.SeasonPosterWidth.ToString
                txtSeaPosterHeight.Text = Master.eSettings.SeasonPosterHeight.ToString
            End If
            chkOnlyTVImagesLanguage.Checked = Master.eSettings.OnlyGetTVImagesForSelectedLanguage
            chkGetEnglishImages.Checked = Master.eSettings.AlwaysGetEnglishTVImages
        End Sub

        Private Sub rbAllSBanner_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbAllSBanner.CheckedChanged
            cbAllSPosterSize.Items.Clear()
            If rbAllSBanner.Checked Then
                cbAllSPosterSize.Items.AddRange(New String() {Master.eLang.GetString(745, "None"), Master.eLang.GetString(746, "Blank"), Master.eLang.GetString(747, "Graphical"), Master.eLang.GetString(748, "Text")})
            Else
                cbAllSPosterSize.Items.AddRange(New String() {Master.eLang.GetString(322, "X-Large"), Master.eLang.GetString(323, "Large"), Master.eLang.GetString(324, "Medium"), Master.eLang.GetString(325, "Small"), Master.eLang.GetString(558, "Wide")})
            End If
            cbAllSPosterSize.SelectedIndex = 0
        End Sub

        Private Sub rbBanner_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbBanner.CheckedChanged
            cbShowPosterSize.Items.Clear()
            If rbBanner.Checked Then
                cbShowPosterSize.Items.AddRange(New String() {Master.eLang.GetString(745, "None"), Master.eLang.GetString(746, "Blank"), Master.eLang.GetString(747, "Graphical"), Master.eLang.GetString(748, "Text")})
            Else
                cbShowPosterSize.Items.AddRange(New String() {Master.eLang.GetString(322, "X-Large"), Master.eLang.GetString(323, "Large"), Master.eLang.GetString(324, "Medium"), Master.eLang.GetString(325, "Small"), Master.eLang.GetString(558, "Wide")})
            End If
            cbShowPosterSize.SelectedIndex = 0
        End Sub

        Public Overrides Sub SaveSettings()
            If rbBanner.Checked Then
                Master.eSettings.IsShowBanner = True
                Master.eSettings.PreferredShowBannerType = DirectCast(cbShowPosterSize.SelectedIndex, Enums.ShowBannerType)
            Else
                Master.eSettings.IsShowBanner = False
                Master.eSettings.PreferredShowPosterSize = DirectCast(cbShowPosterSize.SelectedIndex, Enums.PosterSize)
            End If
            If rbAllSBanner.Checked Then
                Master.eSettings.IsAllSBanner = True
                Master.eSettings.PreferredAllSBannerType = DirectCast(cbAllSPosterSize.SelectedIndex, Enums.ShowBannerType)
            Else
                Master.eSettings.IsAllSBanner = False
                Master.eSettings.PreferredAllSPosterSize = DirectCast(cbAllSPosterSize.SelectedIndex, Enums.PosterSize)
            End If
            Master.eSettings.PreferredShowFanartSize = DirectCast(cbShowFanartSize.SelectedIndex, Enums.FanartSize)
            Master.eSettings.PreferredEpFanartSize = DirectCast(cbEpFanartSize.SelectedIndex, Enums.FanartSize)
            Master.eSettings.PreferredSeasonPosterSize = DirectCast(cbSeaPosterSize.SelectedIndex, Enums.SeasonPosterType)
            Master.eSettings.PreferredEpFanartSize = DirectCast(cbSeaFanartSize.SelectedIndex, Enums.FanartSize)
            Master.eSettings.ShowPosterQuality = tbShowPosterQual.Value
            Master.eSettings.ShowFanartQuality = tbShowFanartQual.Value
            Master.eSettings.OverwriteShowPoster = chkOverwriteShowPoster.Checked
            Master.eSettings.OverwriteShowFanart = chkOverwriteShowFanart.Checked
            Master.eSettings.AllSPosterQuality = tbAllSPosterQual.Value
            Master.eSettings.OverwriteAllSPoster = chkOverwriteAllSPoster.Checked
            Master.eSettings.EpPosterQuality = tbEpPosterQual.Value
            Master.eSettings.EpFanartQuality = tbEpFanartQual.Value
            Master.eSettings.OverwriteEpPoster = chkOverwriteEpPoster.Checked
            Master.eSettings.OverwriteEpFanart = chkOverwriteEpFanart.Checked
            Master.eSettings.SeasonPosterQuality = tbSeaPosterQual.Value
            Master.eSettings.SeasonFanartQuality = tbSeaFanartQual.Value
            Master.eSettings.OverwriteSeasonPoster = chkSeaOverwritePoster.Checked
            Master.eSettings.OverwriteSeasonFanart = chkSeaOverwriteFanart.Checked
            Master.eSettings.ResizeShowFanart = chkResizeShowFanart.Checked
            Master.eSettings.ShowFanartHeight = If(Not String.IsNullOrEmpty(txtShowFanartHeight.Text), Convert.ToInt32(txtShowFanartHeight.Text), 0)
            Master.eSettings.ShowFanartWidth = If(Not String.IsNullOrEmpty(txtShowFanartWidth.Text), Convert.ToInt32(txtShowFanartWidth.Text), 0)
            Master.eSettings.ResizeShowPoster = chkResizeShowPoster.Checked
            Master.eSettings.ShowPosterHeight = If(Not String.IsNullOrEmpty(txtShowPosterHeight.Text), Convert.ToInt32(txtShowPosterHeight.Text), 0)
            Master.eSettings.ShowPosterWidth = If(Not String.IsNullOrEmpty(txtShowPosterWidth.Text), Convert.ToInt32(txtShowPosterWidth.Text), 0)
            Master.eSettings.ResizeAllSPoster = chkResizeAllSPoster.Checked
            Master.eSettings.AllSPosterHeight = If(Not String.IsNullOrEmpty(txtAllSPosterHeight.Text), Convert.ToInt32(txtAllSPosterHeight.Text), 0)
            Master.eSettings.AllSPosterWidth = If(Not String.IsNullOrEmpty(txtAllSPosterWidth.Text), Convert.ToInt32(txtAllSPosterWidth.Text), 0)
            Master.eSettings.ResizeEpFanart = chkResizeEpFanart.Checked
            Master.eSettings.EpFanartHeight = If(Not String.IsNullOrEmpty(txtEpFanartHeight.Text), Convert.ToInt32(txtEpFanartHeight.Text), 0)
            Master.eSettings.EpFanartWidth = If(Not String.IsNullOrEmpty(txtEpFanartWidth.Text), Convert.ToInt32(txtEpFanartWidth.Text), 0)
            Master.eSettings.ResizeEpPoster = chkResizeEpPoster.Checked
            Master.eSettings.EpPosterHeight = If(Not String.IsNullOrEmpty(txtEpPosterHeight.Text), Convert.ToInt32(txtEpPosterHeight.Text), 0)
            Master.eSettings.EpPosterWidth = If(Not String.IsNullOrEmpty(txtEpPosterWidth.Text), Convert.ToInt32(txtEpPosterWidth.Text), 0)
            Master.eSettings.ResizeSeasonFanart = chkSeaResizeFanart.Checked
            Master.eSettings.SeasonFanartHeight = If(Not String.IsNullOrEmpty(txtSeaFanartHeight.Text), Convert.ToInt32(txtSeaFanartHeight.Text), 0)
            Master.eSettings.SeasonFanartWidth = If(Not String.IsNullOrEmpty(txtSeaFanartWidth.Text), Convert.ToInt32(txtSeaFanartWidth.Text), 0)
            Master.eSettings.ResizeSeasonPoster = chkSeaResizePoster.Checked
            Master.eSettings.SeasonPosterHeight = If(Not String.IsNullOrEmpty(txtSeaPosterHeight.Text), Convert.ToInt32(txtSeaPosterHeight.Text), 0)
            Master.eSettings.SeasonPosterWidth = If(Not String.IsNullOrEmpty(txtSeaPosterWidth.Text), Convert.ToInt32(txtSeaPosterWidth.Text), 0)
            Master.eSettings.OnlyGetTVImagesForSelectedLanguage = chkOnlyTVImagesLanguage.Checked
            Master.eSettings.AlwaysGetEnglishTVImages = chkGetEnglishImages.Checked
        End Sub

        Private Sub tbAllSPosterQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbAllSPosterQual.ValueChanged
            lblAllSPosterQual.Text = tbAllSPosterQual.Value.ToString
            'change text color to indicate recommendations
            With lblAllSPosterQual
                Select Case True
                    Case tbAllSPosterQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbAllSPosterQual.Value > 95 OrElse tbAllSPosterQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbAllSPosterQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbAllSPosterQual.Value, 300 - tbAllSPosterQual.Value, 0)
                    Case tbAllSPosterQual.Value >= 80 AndAlso tbAllSPosterQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbAllSPosterQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbAllSPosterQual.Value - 20)), 0)
                    Case tbAllSPosterQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbAllSPosterQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbEpFanartQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbEpFanartQual.ValueChanged            
            lblEpFanartQual.Text = tbEpFanartQual.Value.ToString
            'change text color to indicate recommendations
            With lblEpFanartQual
                Select Case True
                    Case tbEpFanartQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbEpFanartQual.Value > 95 OrElse tbEpFanartQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbEpFanartQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbEpFanartQual.Value, 300 - tbEpFanartQual.Value, 0)
                    Case tbEpFanartQual.Value >= 80 AndAlso tbEpFanartQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbEpFanartQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbEpFanartQual.Value - 20)), 0)
                    Case tbEpFanartQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbEpFanartQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbEpPosterQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbEpPosterQual.ValueChanged            
            lblEpPosterQual.Text = tbEpPosterQual.Value.ToString
            'change text color to indicate recommendations
            With lblEpPosterQual
                Select Case True
                    Case tbEpPosterQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbEpPosterQual.Value > 95 OrElse tbEpPosterQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbEpPosterQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbEpPosterQual.Value, 300 - tbEpPosterQual.Value, 0)
                    Case tbEpPosterQual.Value >= 80 AndAlso tbEpPosterQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbEpPosterQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbEpPosterQual.Value - 20)), 0)
                    Case tbEpPosterQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbEpPosterQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbSeaFanartQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbSeaFanartQual.ValueChanged
            lblSeaFanartQual.Text = tbSeaFanartQual.Value.ToString
            'change text color to indicate recommendations
            With lblSeaFanartQual
                Select Case True
                    Case tbSeaFanartQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbSeaFanartQual.Value > 95 OrElse tbSeaFanartQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbSeaFanartQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbSeaFanartQual.Value, 300 - tbSeaFanartQual.Value, 0)
                    Case tbSeaFanartQual.Value >= 80 AndAlso tbSeaFanartQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbSeaFanartQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbSeaFanartQual.Value - 20)), 0)
                    Case tbSeaFanartQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbSeaFanartQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbSeaPosterQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbSeaPosterQual.ValueChanged
            lblSeaPosterQual.Text = tbSeaPosterQual.Value.ToString
            'change text color to indicate recommendations
            With lblSeaPosterQual
                Select Case True
                    Case tbSeaPosterQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbSeaPosterQual.Value > 95 OrElse tbSeaPosterQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbSeaPosterQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbSeaPosterQual.Value, 300 - tbSeaPosterQual.Value, 0)
                    Case tbSeaPosterQual.Value >= 80 AndAlso tbSeaPosterQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbSeaPosterQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbSeaPosterQual.Value - 20)), 0)
                    Case tbSeaPosterQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbSeaPosterQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbShowFanartQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbShowFanartQual.ValueChanged
            lblShowFanartQual.Text = tbShowFanartQual.Value.ToString
            'change text color to indicate recommendations
            With lblShowFanartQual
                Select Case True
                    Case tbShowFanartQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbShowFanartQual.Value > 95 OrElse tbShowFanartQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbShowFanartQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbShowFanartQual.Value, 300 - tbShowFanartQual.Value, 0)
                    Case tbShowFanartQual.Value >= 80 AndAlso tbShowFanartQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbShowFanartQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbShowFanartQual.Value - 20)), 0)
                    Case tbShowFanartQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbShowFanartQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbShowPosterQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbShowPosterQual.ValueChanged
            lblShowPosterQual.Text = tbShowPosterQual.Value.ToString
            'change text color to indicate recommendations
            With lblShowPosterQual
                Select Case True
                    Case tbShowPosterQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbShowPosterQual.Value > 95 OrElse tbShowPosterQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbShowPosterQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbShowPosterQual.Value, 300 - tbShowPosterQual.Value, 0)
                    Case tbShowPosterQual.Value >= 80 AndAlso tbShowPosterQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbShowPosterQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbShowPosterQual.Value - 20)), 0)
                    Case tbShowPosterQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbShowPosterQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Protected Overrides Sub LoadResources()
            lblShowPosterSize.Text = Master.eLang.GetString(730, "Preferred Type:")
            chkOnlyTVImagesLanguage.Text = Master.eLang.GetString(736, "Only Get Images for the Selected Language")
            chkGetEnglishImages.Text = Master.eLang.GetString(737, "Also Get English Images")
            rbBanner.Text = Master.eLang.GetString(838, "Banner")
            tpTVShow.Text = Master.eLang.GetString(700, "TV Show")
            tpTVSeason.Text = Master.eLang.GetString(744, "TV Season")
            tpTVEpisode.Text = Master.eLang.GetString(701, "TV Episode")
            tpGeneral.Text = Master.eLang.GetString(38, "General")
            cbShowFanartSize.Items.Clear()
            cbShowFanartSize.Items.AddRange(New String() {Master.eLang.GetString(323, "Large"), Master.eLang.GetString(324, "Medium"), Master.eLang.GetString(325, "Small")})
            cbEpFanartSize.Items.Clear()
            cbEpFanartSize.Items.AddRange(New String() {Master.eLang.GetString(323, "Large"), Master.eLang.GetString(324, "Medium"), Master.eLang.GetString(325, "Small")})
            cbSeaPosterSize.Items.Clear()
            cbSeaPosterSize.Items.AddRange(New String() {Master.eLang.GetString(745, "None"), "Poster", Master.eLang.GetString(558, "Wide")})
            cbAllSPosterSize.Items.Clear()
            cbAllSPosterSize.Items.AddRange(New String() {Master.eLang.GetString(745, "None"), "Poster", Master.eLang.GetString(558, "Wide")})
            cbSeaFanartSize.Items.Clear()
            cbSeaFanartSize.Items.AddRange(New String() {Master.eLang.GetString(323, "Large"), Master.eLang.GetString(324, "Medium"), Master.eLang.GetString(325, "Small")})            
        End Sub
    End Class
End Namespace