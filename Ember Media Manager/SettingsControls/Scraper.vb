Imports System.ComponentModel
Imports EmberMediaManger.API
Imports System.Globalization

Namespace SettingsControls
    Public Class Scraper
        Private Meta As New List(Of Settings.MetadataPerType)
        Private Sub btnEditMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditMetaDataFT.Click
            Using dEditMeta As New dlgFileInfo
                Dim fi As MediaInfo.Fileinfo
                For Each x As Settings.MetadataPerType In Meta
                    If x.FileType = lstMetaData.SelectedItems(0).ToString Then
                        fi = dEditMeta.ShowDialog(x.MetaData, False)
                        If Not fi Is Nothing Then
                            Meta.Remove(x)
                            Dim m As New Settings.MetadataPerType
                            m.FileType = x.FileType
                            m.MetaData = New MediaInfo.Fileinfo
                            m.MetaData = fi
                            Meta.Add(m)
                            LoadMetadata()                            
                        End If
                        Exit For
                    End If
                Next
            End Using
        End Sub

        <Localizable(False)>
        Private Sub btnNewMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNewMetaDataFT.Click
            If Not txtDefFIExt.Text.StartsWith(".") Then txtDefFIExt.Text = String.Concat(".", txtDefFIExt.Text)
            Using dEditMeta As New dlgFileInfo
                Dim fi As New MediaInfo.Fileinfo
                fi = dEditMeta.ShowDialog(fi, False)
                If Not fi Is Nothing Then
                    Dim m As New Settings.MetadataPerType
                    m.FileType = txtDefFIExt.Text
                    m.MetaData = New MediaInfo.Fileinfo
                    m.MetaData = fi
                    Meta.Add(m)
                    LoadMetadata()                    
                    txtDefFIExt.Text = String.Empty
                    txtDefFIExt.Focus()
                End If
            End Using
        End Sub

        <Localizable(False)>
        Private Sub chkCast_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkCast.CheckedChanged
            chkFullCast.Enabled = chkCast.Checked
            chkCastWithImg.Enabled = chkCast.Checked
            txtActorLimit.Enabled = chkCast.Checked

            If Not chkCast.Checked Then
                chkFullCast.Checked = False
                chkCastWithImg.Checked = False
                txtActorLimit.Text = "0"
            End If
        End Sub

        Private Sub chkCert_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkCert.CheckedChanged
            cbCert.SelectedIndex = -1
            cbCert.Enabled = chkCert.Checked
            chkUseCertForMPAA.Enabled = chkCert.Checked
            If Not chkCert.Checked Then
                chkUseCertForMPAA.Checked = False
                chkOnlyValueForCert.Checked = False
                chkOnlyValueForCert.Enabled = False
            End If            
        End Sub

        Private Sub chkForceTitle_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkForceTitle.CheckedChanged
            cbForce.SelectedIndex = -1
            cbForce.Enabled = chkForceTitle.Checked            
        End Sub

        Private Sub chkFullCrew_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkFullCrew.CheckedChanged
            chkProducers.Enabled = chkFullCrew.Checked
            chkMusicBy.Enabled = chkFullCrew.Checked
            chkCrew.Enabled = chkFullCrew.Checked

            If Not chkFullCrew.Checked Then
                chkProducers.Checked = False
                chkMusicBy.Checked = False
                chkCrew.Checked = False
            End If
        End Sub

        <Localizable(False)>
        Private Sub chkGenre_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkGenre.CheckedChanged
            txtGenreLimit.Enabled = chkGenre.Checked
            If Not chkGenre.Checked Then txtGenreLimit.Text = "0"
        End Sub

        Private Sub chkMPAA_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkMPAA.CheckedChanged
            chkCert.Enabled = chkMPAA.Checked
            If Not chkMPAA.Checked Then
                chkCert.Checked = False
                cbCert.Enabled = False
                cbCert.SelectedIndex = -1
                chkUseCertForMPAA.Enabled = False
                chkUseCertForMPAA.Checked = False
            End If
        End Sub

        Private Sub chkOutline_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkOutline.CheckedChanged
            chkOutlineForPlot.Enabled = chkOutline.Checked
            If Not chkOutline.Checked Then chkOutlineForPlot.Checked = False
        End Sub

        Private Sub chkUseCertForMPAA_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkUseCertForMPAA.CheckedChanged
            chkOnlyValueForCert.Enabled = chkUseCertForMPAA.Checked
            If Not chkUseCertForMPAA.Checked Then chkOnlyValueForCert.Checked = False
        End Sub

        Private Sub chkUseMIDuration_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkUseMIDuration.CheckedChanged
            txtRuntimeFormat.Enabled = chkUseMIDuration.Checked
        End Sub

        Protected Overrides Sub LoadSettings()
            Meta.AddRange(Master.eSettings.MetadataPerFileType)
            If Not String.IsNullOrEmpty(Master.eSettings.CertificationLang) Then
                chkCert.Checked = True
                cbCert.Enabled = True
                cbCert.Text = Master.eSettings.CertificationLang
                chkUseCertForMPAA.Enabled = True
                chkUseCertForMPAA.Checked = Master.eSettings.UseCertForMPAA
            End If
            If Not String.IsNullOrEmpty(Master.eSettings.ForceTitle) Then
                chkForceTitle.Checked = True
                cbForce.Enabled = True
                cbForce.Text = Master.eSettings.ForceTitle
            End If
            chkScanMediaInfo.Checked = Master.eSettings.ScanMediaInfo
            chkFullCast.Checked = Master.eSettings.FullCast
            chkFullCrew.Checked = Master.eSettings.FullCrew
            chkCastWithImg.Checked = Master.eSettings.CastImagesOnly
            chkLockPlot.Checked = Master.eSettings.LockPlot
            chkLockOutline.Checked = Master.eSettings.LockOutline
            chkLockTitle.Checked = Master.eSettings.LockTitle
            chkLockTagline.Checked = Master.eSettings.LockTagline
            chkLockRating.Checked = Master.eSettings.LockRating
            chkLockRealStudio.Checked = Master.eSettings.LockStudio
            chkLockGenre.Checked = Master.eSettings.LockGenre
            chkLockTrailer.Checked = Master.eSettings.LockTrailer
            chkUseMIDuration.Checked = Master.eSettings.UseMIDuration
            txtRuntimeFormat.Enabled = Master.eSettings.UseMIDuration
            txtRuntimeFormat.Text = Master.eSettings.RuntimeMask
            chkOutlineForPlot.Checked = Master.eSettings.OutlineForPlot
            cbLanguages.SelectedItem = If(String.IsNullOrEmpty(Master.eSettings.FlagLang), Master.eLang.Disabled, Master.eSettings.FlagLang)
            chkTitle.Checked = Master.eSettings.FieldTitle
            chkYear.Checked = Master.eSettings.FieldYear
            chkMPAA.Checked = Master.eSettings.FieldMPAA
            chkCertification.Checked = Master.eSettings.FieldCert
            chkRelease.Checked = Master.eSettings.FieldRelease
            chkRuntime.Checked = Master.eSettings.FieldRuntime
            chkRating.Checked = Master.eSettings.FieldRating
            chkVotes.Checked = Master.eSettings.FieldVotes
            chkStudio.Checked = Master.eSettings.FieldStudio
            chkGenre.Checked = Master.eSettings.FieldGenre
            chkTrailer.Checked = Master.eSettings.FieldTrailer
            chkTagline.Checked = Master.eSettings.FieldTagline
            chkOutline.Checked = Master.eSettings.FieldOutline
            chkPlot.Checked = Master.eSettings.FieldPlot
            chkCast.Checked = Master.eSettings.FieldCast
            chkDirector.Checked = Master.eSettings.FieldDirector
            chkWriters.Checked = Master.eSettings.FieldWriters
            If Master.eSettings.FullCrew Then
                chkProducers.Checked = Master.eSettings.FieldProducers
                chkMusicBy.Checked = Master.eSettings.FieldMusic
                chkCrew.Checked = Master.eSettings.FieldCrew
            End If
            chkTop250.Checked = Master.eSettings.Field250
            chkCountry.Checked = Master.eSettings.FieldCountry
            txtActorLimit.Text = Master.eSettings.ActorLimit.ToString
            txtGenreLimit.Text = Master.eSettings.GenreLimit.ToString
            chkIFOScan.Checked = Master.eSettings.EnableIFOScan
            chkOnlyValueForCert.Checked = Master.eSettings.OnlyValueForCert
            LoadMetadata()
        End Sub
        Private Sub LoadLangs()
            cbLanguages.Items.Add(Master.eLang.Disabled)
            cbLanguages.Items.AddRange(CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(Function(f) f.NativeName))
        End Sub

        Private Sub LoadMetadata()
            lstMetaData.Items.Clear()
            For Each x As Settings.MetadataPerType In Meta
                lstMetaData.Items.Add(x.FileType)
            Next
        End Sub
        Private Sub lstMetaData_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstMetaData.DoubleClick
            If lstMetaData.SelectedItems.Count > 0 Then
                Using dEditMeta As New dlgFileInfo
                    Dim fi As MediaInfo.Fileinfo
                    For Each x As Settings.MetadataPerType In Meta
                        If x.FileType = lstMetaData.SelectedItems(0).ToString Then
                            fi = dEditMeta.ShowDialog(x.MetaData, False)
                            If Not fi Is Nothing Then
                                Meta.Remove(x)
                                Dim m As New Settings.MetadataPerType
                                m.FileType = x.FileType
                                m.MetaData = New MediaInfo.Fileinfo
                                m.MetaData = fi
                                Meta.Add(m)
                                LoadMetadata()
                                OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
                            End If
                            Exit For
                        End If
                    Next
                End Using
            End If
        End Sub

        Private Sub lstMetadata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstMetaData.SelectedIndexChanged
            If lstMetaData.SelectedItems.Count > 0 Then
                btnEditMetaDataFT.Enabled = True
                btnRemoveMetaDataFT.Enabled = True
                txtDefFIExt.Text = String.Empty
            Else
                btnEditMetaDataFT.Enabled = False
                btnRemoveMetaDataFT.Enabled = False
            End If
        End Sub

        Private Sub RemoveMetaData()
            If lstMetaData.SelectedItems.Count > 0 Then
                For Each x As Settings.MetadataPerType In Meta
                    If x.FileType = lstMetaData.SelectedItems(0).ToString Then
                        Meta.Remove(x)
                        LoadMetadata()
                        OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.MetadataPerFileType.Clear()
            Master.eSettings.MetadataPerFileType.AddRange(Meta)
            Master.eSettings.CertificationLang = cbCert.Text
            If Not String.IsNullOrEmpty(cbCert.Text) Then
                Master.eSettings.UseCertForMPAA = chkUseCertForMPAA.Checked
            Else
                Master.eSettings.UseCertForMPAA = False
            End If
            Master.eSettings.ForceTitle = cbForce.Text
            Master.eSettings.ScanMediaInfo = chkScanMediaInfo.Checked
            Master.eSettings.FullCast = chkFullCast.Checked
            Master.eSettings.FullCrew = chkFullCrew.Checked
            Master.eSettings.CastImagesOnly = chkCastWithImg.Checked
            Master.eSettings.LockPlot = chkLockPlot.Checked
            Master.eSettings.LockOutline = chkLockOutline.Checked
            Master.eSettings.LockTitle = chkLockTitle.Checked
            Master.eSettings.LockTagline = chkLockTagline.Checked
            Master.eSettings.LockRating = chkLockRating.Checked
            Master.eSettings.LockStudio = chkLockRealStudio.Checked
            Master.eSettings.LockGenre = chkLockGenre.Checked
            Master.eSettings.LockTrailer = chkLockTrailer.Checked
            Master.eSettings.UseMIDuration = chkUseMIDuration.Checked
            Master.eSettings.RuntimeMask = txtRuntimeFormat.Text
            Master.eSettings.OutlineForPlot = chkOutlineForPlot.Checked
            Master.eSettings.FlagLang = If(cbLanguages.Text = Master.eLang.Disabled, String.Empty, cbLanguages.Text)
            Master.eSettings.FieldTitle = chkTitle.Checked
            Master.eSettings.FieldYear = chkYear.Checked
            Master.eSettings.FieldMPAA = chkMPAA.Checked
            Master.eSettings.FieldCert = chkCertification.Checked
            Master.eSettings.FieldRelease = chkRelease.Checked
            Master.eSettings.FieldRuntime = chkRuntime.Checked
            Master.eSettings.FieldRating = chkRating.Checked
            Master.eSettings.FieldVotes = chkVotes.Checked
            Master.eSettings.FieldStudio = chkStudio.Checked
            Master.eSettings.FieldGenre = chkGenre.Checked
            Master.eSettings.FieldTrailer = chkTrailer.Checked
            Master.eSettings.FieldTagline = chkTagline.Checked
            Master.eSettings.FieldOutline = chkOutline.Checked
            Master.eSettings.FieldPlot = chkPlot.Checked
            Master.eSettings.FieldCast = chkCast.Checked
            Master.eSettings.FieldDirector = chkDirector.Checked
            Master.eSettings.FieldWriters = chkWriters.Checked
            Master.eSettings.FieldProducers = chkProducers.Checked
            Master.eSettings.FieldMusic = chkMusicBy.Checked
            Master.eSettings.FieldCrew = chkCrew.Checked
            Master.eSettings.Field250 = chkTop250.Checked
            Master.eSettings.FieldCountry = chkCountry.Checked
            Master.eSettings.ActorLimit = txtActorLimit.IntValue
            Master.eSettings.GenreLimit = txtGenreLimit.IntValue
            Master.eSettings.EnableIFOScan = chkIFOScan.Checked
            Master.eSettings.OnlyValueForCert = chkOnlyValueForCert.Checked
        End Sub

        Private Sub txtDefFIExt_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtDefFIExt.TextChanged
            btnNewMetaDataFT.Enabled = Not String.IsNullOrEmpty(txtDefFIExt.Text) AndAlso Not lstMetaData.Items.Contains(If(txtDefFIExt.Text.StartsWith("."), txtDefFIExt.Text, String.Concat(".", txtDefFIExt.Text)))
            If btnNewMetaDataFT.Enabled Then
                btnEditMetaDataFT.Enabled = False
                btnRemoveMetaDataFT.Enabled = False
            End If
        End Sub

        Private Sub lstMetaData_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstMetaData.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveMetaData()
        End Sub

        Private Sub btnRemoveMetaDataFT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveMetaDataFT.Click
            RemoveMetaData()
        End Sub

        Protected Overrides Sub LoadResources()
            cbForce.Items.AddRange(Strings.Split(AdvancedSettings.GetSetting("ForceTitle", ""), "|"))
            lblDisplayOverlay.Text = Master.eLang.GetString(436, "Display Overlay if Video Contains an Audio Stream With the Following Language:")
            chkLockTrailer.Text = Master.eLang.GetString(489, "Lock Trailer")
            chkLockGenre.Text = Master.eLang.GetString(490, "Lock Genre")
            chkLockRealStudio.Text = Master.eLang.GetString(491, "Lock Studio")
            chkLockRating.Text = Master.eLang.GetString(492, "Lock Rating")
            chkLockTagline.Text = Master.eLang.GetString(493, "Lock Tagline")
            chkLockTitle.Text = Master.eLang.GetString(494, "Lock Title")
            chkLockOutline.Text = Master.eLang.GetString(495, "Lock Outline")
            chkLockPlot.Text = Master.eLang.GetString(496, "Lock Plot")
            chkOutlineForPlot.Text = Master.eLang.GetString(508, "Use Outline for Plot if Plot is Empty")

            chkCastWithImg.Text = Master.eLang.GetString(510, "Scrape Only Actors With Images")
            chkUseCertForMPAA.Text = Master.eLang.GetString(511, "Use Certification for MPAA")
            chkFullCast.Text = Master.eLang.GetString(512, "Scrape Full Cast")
            chkFullCrew.Text = Master.eLang.GetString(513, "Scrape Full Crew")
            chkCert.Text = Master.eLang.GetString(514, "Use Certification Language:")
            gbRTFormat.Text = Master.eLang.GetString(515, "Duration Format")
            chkUseMIDuration.Text = Master.eLang.GetString(516, "Use Duration for Runtime")
            chkScanMediaInfo.Text = Master.eLang.GetString(517, "Scan Meta Data")
            gbMetaData.Text = Master.eLang.GetString(59, "Meta Data")
            gbOptions.Text = Master.eLang.GetString(577, "Scraper Fields")

            chkCrew.Text = Master.eLang.GetString(391, "Other Crew")
            chkMusicBy.Text = Master.eLang.GetString(392, "Music By")
            chkProducers.Text = Master.eLang.GetString(393, "Producers")
            chkWriters.Text = Master.eLang.GetString(394, "Writers")
            chkStudio.Text = Master.eLang.GetString(395, "Studio")
            chkRuntime.Text = Master.eLang.GetString(396, "Runtime")
            chkPlot.Text = Master.eLang.GetString(65, "Plot")
            chkOutline.Text = Master.eLang.GetString(64, "Plot Outline")
            chkGenre.Text = Master.eLang.GetString(20, "Genres")
            chkDirector.Text = Master.eLang.GetString(62, "Director")
            chkTagline.Text = Master.eLang.GetString(397, "Tagline")
            chkCast.Text = Master.eLang.GetString(398, "Cast")
            chkVotes.Text = Master.eLang.GetString(399, "Votes")
            chkTrailer.Text = Master.eLang.GetString(151, "Trailer")
            chkRating.Text = Master.eLang.GetString(400, "Rating")
            chkRelease.Text = Master.eLang.GetString(57, "Release Date")
            chkMPAA.Text = Master.eLang.GetString(401, "MPAA")
            chkCertification.Text = Master.eLang.GetString(722, "Certification")
            chkYear.Text = Master.eLang.GetString(278, "Year")
            chkTitle.Text = Master.eLang.GetString(21, "Title")
            lblCastLimit.Text = Master.eLang.GetString(578, "Limit:")
            lblGenreLimit.Text = lblCastLimit.Text
            chkTop250.Text = Master.eLang.GetString(591, "Top 250")
            chkCountry.Text = Master.eLang.GetString(301, "Country")
            gbDefaultsByFileType.Text = Master.eLang.GetString(625, "Defaults by File Type")
            lblFileType.Text = Master.eLang.GetString(626, "File Type")
            chkIFOScan.Text = Master.eLang.GetString(628, "Enable IFO Parsing")
            lblDurationFormat.Text = Master.eLang.GetString(732, "<h>=Hours <m>=Minutes <s>=Seconds")
            chkForceTitle.Text = Master.eLang.GetString(710, "Force Title Language:")
            chkOnlyValueForCert.Text = Master.eLang.GetString(835, "Only Save the Value to NFO")
            LoadLangs()            
        End Sub
    End Class
End Namespace