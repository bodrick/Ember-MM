Imports System.ComponentModel
Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class Images
        Private Sub chkAutoThumbs_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkAutoThumbs.CheckedChanged
            txtAutoThumbs.Enabled = chkAutoThumbs.Checked
            chkNoSpoilers.Enabled = chkAutoThumbs.Checked
            chkUseETasFA.Enabled = chkAutoThumbs.Checked
            If Not chkAutoThumbs.Checked Then
                txtAutoThumbs.Text = String.Empty
                chkNoSpoilers.Checked = False
                chkUseETasFA.Checked = False
            End If
        End Sub

        Private Sub chkDownloadTrailer_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkDownloadTrailer.CheckedChanged
            chkUpdaterTrailer.Enabled = chkDownloadTrailer.Checked
            chkSingleScrapeTrailer.Enabled = chkDownloadTrailer.Checked
            chkOverwriteTrailer.Enabled = chkDownloadTrailer.Checked
            chkNoDLTrailer.Enabled = chkDownloadTrailer.Checked
            chkDeleteAllTrailers.Enabled = chkDownloadTrailer.Checked

            If Not chkDownloadTrailer.Checked Then
                chkUpdaterTrailer.Checked = False
                chkSingleScrapeTrailer.Checked = False
                chkNoDLTrailer.Checked = False
                chkOverwriteTrailer.Checked = False
                chkDeleteAllTrailers.Checked = False
                cbTrailerQuality.Enabled = False
                cbTrailerQuality.SelectedIndex = -1
            Else
                cbTrailerQuality.Enabled = True
            End If
        End Sub

        Private Sub chkResizeFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizeFanart.CheckedChanged
            txtFanartWidth.Enabled = chkResizeFanart.Checked
            txtFanartHeight.Enabled = chkResizeFanart.Checked

            If Not chkResizeFanart.Checked Then
                txtFanartWidth.Text = String.Empty
                txtFanartHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkResizePoster_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkResizePoster.CheckedChanged
            txtPosterWidth.Enabled = chkResizePoster.Checked
            txtPosterHeight.Enabled = chkResizePoster.Checked

            If Not chkResizePoster.Checked Then
                txtPosterWidth.Text = String.Empty
                txtPosterHeight.Text = String.Empty
            End If
        End Sub

        Private Sub chkUseImgCache_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkUseImgCache.CheckedChanged
            chkPersistImgCache.Enabled = chkUseImgCache.Checked
            chkUseImgCacheUpdaters.Enabled = chkUseImgCache.Checked
            If Not chkUseImgCache.Checked Then
                chkPersistImgCache.Checked = False
                chkUseImgCacheUpdaters.Checked = False
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            cbPosterSize.SelectedIndex = Master.eSettings.PreferredPosterSize
            cbFanartSize.SelectedIndex = Master.eSettings.PreferredFanartSize
            chkAutoETSize.Checked = Master.eSettings.AutoET
            cbAutoETSize.SelectedIndex = Master.eSettings.AutoETSize
            chkFanartOnly.Checked = Master.eSettings.FanartPrefSizeOnly
            chkPosterOnly.Checked = Master.eSettings.PosterPrefSizeOnly
            tbPosterQual.Value = Master.eSettings.PosterQuality
            tbFanartQual.Value = Master.eSettings.FanartQuality
            chkOverwritePoster.Checked = Master.eSettings.OverwritePoster
            chkOverwriteFanart.Checked = Master.eSettings.OverwriteFanart
            chkSingleScrapeImages.Checked = Master.eSettings.SingleScrapeImages
            chkResizeFanart.Checked = Master.eSettings.ResizeFanart
            If Master.eSettings.ResizeFanart Then
                txtFanartWidth.Text = Master.eSettings.FanartWidth.ToString
                txtFanartHeight.Text = Master.eSettings.FanartHeight.ToString
            End If
            chkResizePoster.Checked = Master.eSettings.ResizePoster
            If Master.eSettings.ResizePoster Then
                txtPosterWidth.Text = Master.eSettings.PosterWidth.ToString
                txtPosterHeight.Text = Master.eSettings.PosterHeight.ToString
            End If
            If Master.eSettings.AutoThumbs > 0 Then
                chkAutoThumbs.Checked = True
                txtAutoThumbs.Enabled = True
                txtAutoThumbs.Text = Master.eSettings.AutoThumbs.ToString
                chkNoSpoilers.Enabled = True
                chkNoSpoilers.Checked = Master.eSettings.AutoThumbsNoSpoilers
                chkUseETasFA.Enabled = True
                chkUseETasFA.Checked = Master.eSettings.UseETasFA
            End If
            chkUseImgCache.Checked = Master.eSettings.UseImgCache
            chkUseImgCacheUpdaters.Checked = Master.eSettings.UseImgCacheUpdaters
            chkPersistImgCache.Checked = Master.eSettings.PersistImgCache
            chkNoSaveImagesToNfo.Checked = Master.eSettings.NoSaveImagesToNfo
            chkDownloadTrailer.Checked = Master.eSettings.DownloadTrailers
            chkUpdaterTrailer.Checked = Master.eSettings.UpdaterTrailers
            chkNoDLTrailer.Checked = Master.eSettings.UpdaterTrailersNoDownload
            chkSingleScrapeTrailer.Checked = Master.eSettings.SingleScrapeTrailer

            chkOverwriteTrailer.Checked = Master.eSettings.OverwriteTrailer
            chkDeleteAllTrailers.Checked = Master.eSettings.DeleteAllTrailers

            cbTrailerQuality.SelectedValue = Master.eSettings.PreferredTrailerQuality
            rbETNative.Checked = Master.eSettings.ETNative
            If Not Master.eSettings.ETNative AndAlso Master.eSettings.ETWidth > 0 AndAlso Master.eSettings.ETHeight > 0 Then
                rbETCustom.Checked = True
                txtETHeight.Text = Master.eSettings.ETHeight.ToString
                txtETWidth.Text = Master.eSettings.ETWidth.ToString
                chkETPadding.Checked = Master.eSettings.ETPadding
            Else
                rbETNative.Checked = True
            End If
            chkActorCache.Checked = AdvancedSettings.GetBooleanSetting("ScrapeActorsThumbs", False)
        End Sub

        <Localizable(False)>
        Private Sub LoadTrailerQualities()
            Dim items As New Dictionary(Of String, Enums.TrailerQuality)
            items.Add("1080p", Enums.TrailerQuality.HD1080p)
            items.Add("1080p (VP8)", Enums.TrailerQuality.HD1080pVP8)
            items.Add("720p", Enums.TrailerQuality.HD720p)
            items.Add("720p (VP8)", Enums.TrailerQuality.HD720pVP8)
            items.Add("SQ (MP4)", Enums.TrailerQuality.SQMP4)
            items.Add("HQ (FLV)", Enums.TrailerQuality.HQFLV)
            items.Add("HQ (VP8)", Enums.TrailerQuality.HQVP8)
            items.Add("SQ (FLV)", Enums.TrailerQuality.SQFLV)
            items.Add("SQ (VP8)", Enums.TrailerQuality.SQVP8)
            cbTrailerQuality.DataSource = items.ToList
            cbTrailerQuality.DisplayMember = "Key"
            cbTrailerQuality.ValueMember = "Value"
        End Sub

        Private Sub rbETCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbETCustom.CheckedChanged
            txtETHeight.Enabled = rbETCustom.Checked
            txtETWidth.Enabled = rbETCustom.Checked
            chkETPadding.Enabled = rbETCustom.Checked
        End Sub

        Private Sub rbETNative_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbETNative.CheckedChanged
            If rbETNative.Checked Then
                txtETHeight.Text = String.Empty
                txtETWidth.Text = String.Empty
                chkETPadding.Checked = False
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.PreferredPosterSize = DirectCast(cbPosterSize.SelectedIndex, Enums.PosterSize)
            Master.eSettings.PreferredFanartSize = DirectCast(cbFanartSize.SelectedIndex, Enums.FanartSize)
            Master.eSettings.AutoET = chkAutoETSize.Checked
            Master.eSettings.AutoETSize = DirectCast(cbAutoETSize.SelectedIndex, Enums.FanartSize)
            Master.eSettings.FanartPrefSizeOnly = chkFanartOnly.Checked
            Master.eSettings.PosterPrefSizeOnly = chkPosterOnly.Checked
            Master.eSettings.PosterQuality = tbPosterQual.Value
            Master.eSettings.FanartQuality = tbFanartQual.Value
            Master.eSettings.OverwritePoster = chkOverwritePoster.Checked
            Master.eSettings.OverwriteFanart = chkOverwriteFanart.Checked
            Master.eSettings.SingleScrapeImages = chkSingleScrapeImages.Checked
            Master.eSettings.ResizeFanart = chkResizeFanart.Checked
            Master.eSettings.FanartHeight = If(Not String.IsNullOrEmpty(txtFanartHeight.Text), Convert.ToInt32(txtFanartHeight.Text), 0)
            Master.eSettings.FanartWidth = If(Not String.IsNullOrEmpty(txtFanartWidth.Text), Convert.ToInt32(txtFanartWidth.Text), 0)
            Master.eSettings.ResizePoster = chkResizePoster.Checked
            Master.eSettings.PosterHeight = If(Not String.IsNullOrEmpty(txtPosterHeight.Text), Convert.ToInt32(txtPosterHeight.Text), 0)
            Master.eSettings.PosterWidth = If(Not String.IsNullOrEmpty(txtPosterWidth.Text), Convert.ToInt32(txtPosterWidth.Text), 0)
            If Not String.IsNullOrEmpty(txtAutoThumbs.Text) AndAlso Convert.ToInt32(txtAutoThumbs.Text) > 0 Then
                Master.eSettings.AutoThumbs = Convert.ToInt32(txtAutoThumbs.Text)
                Master.eSettings.AutoThumbsNoSpoilers = chkNoSpoilers.Checked
                Master.eSettings.UseETasFA = chkUseETasFA.Checked
            Else
                Master.eSettings.AutoThumbs = 0
                Master.eSettings.AutoThumbsNoSpoilers = False
                Master.eSettings.UseETasFA = False
            End If
            Master.eSettings.UseImgCache = chkUseImgCache.Checked
            Master.eSettings.UseImgCacheUpdaters = chkUseImgCacheUpdaters.Checked
            Master.eSettings.PersistImgCache = chkPersistImgCache.Checked
            Master.eSettings.NoSaveImagesToNfo = chkNoSaveImagesToNfo.Checked

            If cbTrailerQuality.SelectedValue IsNot Nothing Then
                Master.eSettings.PreferredTrailerQuality = DirectCast(cbTrailerQuality.SelectedValue, Enums.TrailerQuality)
            End If

            Master.eSettings.DownloadTrailers = chkDownloadTrailer.Checked
            Master.eSettings.UpdaterTrailers = chkUpdaterTrailer.Checked

            Master.eSettings.SingleScrapeTrailer = chkSingleScrapeTrailer.Checked
            Master.eSettings.UpdaterTrailersNoDownload = chkNoDLTrailer.Checked
            Master.eSettings.OverwriteTrailer = chkOverwriteTrailer.Checked
            Master.eSettings.DeleteAllTrailers = chkDeleteAllTrailers.Checked
            Master.eSettings.ETNative = rbETNative.Checked
            Dim iWidth As Integer = If(txtETWidth.Text.Length > 0, Convert.ToInt32(txtETWidth.Text), 0)
            Dim iHeight As Integer = If(txtETHeight.Text.Length > 0, Convert.ToInt32(txtETHeight.Text), 0)
            If rbETCustom.Checked AndAlso iWidth > 0 AndAlso iHeight > 0 Then
                Master.eSettings.ETWidth = iWidth
                Master.eSettings.ETHeight = iHeight
                Master.eSettings.ETPadding = chkETPadding.Checked
            Else
                Master.eSettings.ETWidth = 0
                Master.eSettings.ETHeight = 0
                Master.eSettings.ETPadding = False
            End If
            AdvancedSettings.SetBooleanSetting("ScrapeActorsThumbs", chkActorCache.Checked)
        End Sub

        Private Sub tbFanartQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbFanartQual.ValueChanged            
            lblFanartQualValue.Text = tbFanartQual.Value.ToString
            'change text color to indicate recommendations
            With lblFanartQualValue
                Select Case True
                    Case tbFanartQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbFanartQual.Value > 95 OrElse tbFanartQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbFanartQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbFanartQual.Value, 300 - tbFanartQual.Value, 0)
                    Case tbFanartQual.Value >= 80 AndAlso tbFanartQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbFanartQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbFanartQual.Value - 20)), 0)
                    Case tbFanartQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbFanartQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Private Sub tbPosterQual_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbPosterQual.ValueChanged            
            lblPosterQualValue.Text = tbPosterQual.Value.ToString
            'change text color to indicate recommendations
            With lblPosterQualValue
                Select Case True
                    Case tbPosterQual.Value = 0
                        .ForeColor = Color.Black
                    Case tbPosterQual.Value > 95 OrElse tbPosterQual.Value < 20
                        .ForeColor = Color.Red
                    Case tbPosterQual.Value > 85
                        .ForeColor = Color.FromArgb(255, 155 + tbPosterQual.Value, 300 - tbPosterQual.Value, 0)
                    Case tbPosterQual.Value >= 80 AndAlso tbPosterQual.Value <= 85
                        .ForeColor = Color.Blue
                    Case tbPosterQual.Value <= 50
                        .ForeColor = Color.FromArgb(255, 255, Convert.ToInt32(8.5 * (tbPosterQual.Value - 20)), 0)
                    Case tbPosterQual.Value < 80
                        .ForeColor = Color.FromArgb(255, Convert.ToInt32(255 - (8.5 * (tbPosterQual.Value - 50))), 255, 0)
                End Select
            End With
        End Sub

        Protected Overrides Sub LoadResources()
            lblPosterQuality.Text = Languages.Quality
            lblFanartQuality.Text = Languages.Quality
            lblFanartMaxWidth.Text = Languages.Max_Height
            chkResizePoster.Text = Languages.Automatically_Resize
            chkResizeFanart.Text = Languages.Automatically_Resize
            lblPosterSize.Text = Languages.Preferred_Size
            lblFanartSize.Text = Languages.Preferred_Size
            chkOverwritePoster.Text = Languages.Overwrite_Existing
            chkOverwriteFanart.Text = Languages.Overwrite_Existing
            chkFanartOnly.Text = Languages.Only
            chkPosterOnly.Text = Languages.Only
            chkNoSaveImagesToNfo.Text = Languages.Do_Not_Save_URLs_to_Nfo
            chkSingleScrapeImages.Text = Languages.Get_on_Single_Scrape
            chkUseETasFA.Text = Languages.Use_if_no_Fanart_Found
            chkNoSpoilers.Text = Languages.No_Spoilers
            lblPosterMaxHeight.Text = Languages.Number_To_Create
            chkAutoThumbs.Text = Languages.Extract_During_Scrapers
            gbImages.Text = Languages.Backdrops_Folder
            chkDeleteAllTrailers.Text = Languages.Delete_All_Existing
            chkOverwriteTrailer.Text = Languages.Overwrite_Existing
            chkNoDLTrailer.Text = Languages.Only_Get_URLs_When_Scraping
            chkSingleScrapeTrailer.Text = Languages.Get_During_Single_Scrape
            chkUpdaterTrailer.Text = Languages.Get_During_Automated_Scrapers
            chkDownloadTrailer.Text = Languages.Enable_Trailer_Support
            gbFanart.Text = Languages.Valid_Video_Extensions
            gbPoster.Text = Languages.Miscellaneous_Options
            gbExtrathumbs.Text = Languages.Extrathumbs
            gbSizing.Text = Languages.Sizing_Extracted_Frames
            chkETPadding.Text = Languages.Padding
            lblSizingWidth.Text = Languages.Width
            lblSizingHeight.Text = Languages.Height
            rbETCustom.Text = Languages.Use_Custom_Size
            rbETNative.Text = Languages.Use_Native_Resolution
            gbCaching.Text = Languages.Caching
            chkUseImgCacheUpdaters.Text = Languages.Use_During_Automated_Scrapers
            chkPersistImgCache.Text = Languages.Persistent_Image_Cache
            chkUseImgCache.Text = Languages.Use_Image_Cache
            chkAutoETSize.Text = Languages.Download_All_Fanart_Images_of_the_Following_Size_as_Extrathumbs
            lblPreferredQuality.Text = Languages.Preferred_Quality
            chkActorCache.Text = Languages.Enable_Actors_Cache
            cbPosterSize.Items.Clear()
            cbPosterSize.Items.AddRange(New String() {Languages.X_Large, Languages.Large, Languages.Medium, Languages.Small, Languages.Wide})
            cbFanartSize.Items.Clear()
            cbFanartSize.Items.AddRange(New String() {Languages.Large, Languages.Medium, Languages.Small})
            cbAutoETSize.Items.Clear()
            cbAutoETSize.Items.AddRange(New String() {Languages.Large, Languages.Medium, Languages.Small})
            LoadTrailerQualities()                        
        End Sub
    End Class
End Namespace