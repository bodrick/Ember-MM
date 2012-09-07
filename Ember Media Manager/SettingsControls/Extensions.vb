Imports System.ComponentModel
Imports EmberMediaManger.API

Namespace SettingsControls
    Public Class Extensions

        <Localizable(False)>
        Private Sub BtnAddMovieExtClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddMovieExt.Click
            If Not String.IsNullOrEmpty(txtMovieExt.Text) Then
                If Not txtMovieExt.Text.StartsWith(".") Then txtMovieExt.Text = String.Concat(".", txtMovieExt.Text)
                If Not lstMovieExts.Items.Contains(txtMovieExt.Text.ToLower) Then
                    lstMovieExts.Items.Add(txtMovieExt.Text.ToLower)                    
                    txtMovieExt.Text = String.Empty
                    txtMovieExt.Focus()
                End If
            End If
        End Sub

        <Localizable(False)>
        Private Sub BtnAddNoStackClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddNoStack.Click
            If Not String.IsNullOrEmpty(txtNoStack.Text) Then
                If Not txtNoStack.Text.StartsWith(".") Then txtNoStack.Text = String.Concat(".", txtNoStack.Text)
                If Not lstNoStack.Items.Contains(txtNoStack.Text) Then
                    lstNoStack.Items.Add(txtNoStack.Text)                    
                    txtNoStack.Text = String.Empty
                    txtNoStack.Focus()
                End If
            End If
        End Sub

        <Localizable(False)>
        Private Sub BtnAddWhitelistClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddWhitelist.Click
            If Not String.IsNullOrEmpty(txtWhitelist.Text) Then
                If Not txtWhitelist.Text.StartsWith(".") Then txtWhitelist.Text = String.Concat(".", txtWhitelist.Text)
                If Not lstWhitelist.Items.Contains(txtWhitelist.Text.ToLower) Then
                    lstWhitelist.Items.Add(txtWhitelist.Text.ToLower)                    
                    txtWhitelist.Text = String.Empty
                    txtWhitelist.Focus()
                End If
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            chkCleanFolderJPG.Checked = Master.eSettings.CleanFolderJPG
            chkCleanMovieTBN.Checked = Master.eSettings.CleanMovieTBN
            chkCleanMovieTBNb.Checked = Master.eSettings.CleanMovieTBNB
            chkCleanFanartJPG.Checked = Master.eSettings.CleanFanartJPG
            chkCleanMovieFanartJPG.Checked = Master.eSettings.CleanMovieFanartJPG
            chkCleanMovieNFO.Checked = Master.eSettings.CleanMovieNFO
            chkCleanMovieNFOb.Checked = Master.eSettings.CleanMovieNFOB
            chkCleanPosterTBN.Checked = Master.eSettings.CleanPosterTBN
            chkCleanPosterJPG.Checked = Master.eSettings.CleanPosterJPG
            chkCleanMovieJPG.Checked = Master.eSettings.CleanMovieJPG
            chkCleanMovieNameJPG.Checked = Master.eSettings.CleanMovieNameJPG
            chkCleanDotFanartJPG.Checked = Master.eSettings.CleanDotFanartJPG
            chkCleanExtrathumbs.Checked = Master.eSettings.CleanExtraThumbs
            tcCleaner.SelectedTab = If(Master.eSettings.ExpertCleaner, tpExpert, tpStandard)
            chkWhitelistVideo.Checked = Master.eSettings.CleanWhitelistVideo
            lstWhitelist.Items.AddRange(Master.eSettings.CleanWhitelistExts.ToArray)
            lstNoStack.Items.AddRange(Master.eSettings.NoStackExts.ToArray)
            RefreshValidExts()
        End Sub

        Private Sub LstMovieExtsKeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstMovieExts.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveMovieExt()
        End Sub

        Private Sub LstNoStackKeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lstNoStack.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveNoStack()
        End Sub

        Private Sub RefreshValidExts()
            lstMovieExts.Items.Clear()
            lstMovieExts.Items.AddRange(Master.eSettings.ValidExts.ToArray)
        End Sub

        Private Sub RemoveMovieExt()
            If lstMovieExts.Items.Count > 0 AndAlso lstMovieExts.SelectedItems.Count > 0 Then
                While lstMovieExts.SelectedItems.Count > 0
                    lstMovieExts.Items.Remove(lstMovieExts.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
            End If
        End Sub

        Private Sub RemoveNoStack()
            If lstNoStack.Items.Count > 0 AndAlso lstNoStack.SelectedItems.Count > 0 Then
                While lstNoStack.SelectedItems.Count > 0
                    lstNoStack.Items.Remove(lstNoStack.SelectedItems(0))
                End While
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            If tcCleaner.SelectedTab.Name = "tpExpert" Then
                Master.eSettings.ExpertCleaner = True
                Master.eSettings.CleanFolderJPG = False
                Master.eSettings.CleanMovieTBN = False
                Master.eSettings.CleanMovieTBNB = False
                Master.eSettings.CleanFanartJPG = False
                Master.eSettings.CleanMovieFanartJPG = False
                Master.eSettings.CleanMovieNFO = False
                Master.eSettings.CleanMovieNFOB = False
                Master.eSettings.CleanPosterTBN = False
                Master.eSettings.CleanPosterJPG = False
                Master.eSettings.CleanMovieJPG = False
                Master.eSettings.CleanMovieNameJPG = False
                Master.eSettings.CleanDotFanartJPG = False
                Master.eSettings.CleanExtraThumbs = False
                Master.eSettings.CleanWhitelistVideo = chkWhitelistVideo.Checked
                Master.eSettings.CleanWhitelistExts.Clear()
                Master.eSettings.CleanWhitelistExts.AddRange(lstWhitelist.Items.OfType(Of String).ToList)
            Else
                Master.eSettings.ExpertCleaner = False
                Master.eSettings.CleanFolderJPG = chkCleanFolderJPG.Checked
                Master.eSettings.CleanMovieTBN = chkCleanMovieTBN.Checked
                Master.eSettings.CleanMovieTBNB = chkCleanMovieTBNb.Checked
                Master.eSettings.CleanFanartJPG = chkCleanFanartJPG.Checked
                Master.eSettings.CleanMovieFanartJPG = chkCleanMovieFanartJPG.Checked
                Master.eSettings.CleanMovieNFO = chkCleanMovieNFO.Checked
                Master.eSettings.CleanMovieNFOB = chkCleanMovieNFOb.Checked
                Master.eSettings.CleanPosterTBN = chkCleanPosterTBN.Checked
                Master.eSettings.CleanPosterJPG = chkCleanPosterJPG.Checked
                Master.eSettings.CleanMovieJPG = chkCleanMovieJPG.Checked
                Master.eSettings.CleanMovieNameJPG = chkCleanMovieNameJPG.Checked
                Master.eSettings.CleanDotFanartJPG = chkCleanDotFanartJPG.Checked
                Master.eSettings.CleanExtraThumbs = chkCleanExtrathumbs.Checked
                Master.eSettings.CleanWhitelistVideo = False
                Master.eSettings.CleanWhitelistExts.Clear()
            End If

            Master.eSettings.ValidExts.Clear()
            Master.eSettings.ValidExts.AddRange(lstMovieExts.Items.OfType(Of String).ToList)
            Master.eSettings.NoStackExts.Clear()
            Master.eSettings.NoStackExts.AddRange(lstNoStack.Items.OfType(Of String).ToList)
        End Sub

        Private Sub BtnRemMovieExtClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemMovieExt.Click
            RemoveMovieExt()
        End Sub

        Private Sub BtnResetValidExtsClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetValidExts.Click
            If MsgBox(Languages.Are_you_sure_you_want_to_reset_to_the_default_list_of_valid_video_extensions, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Languages.Are_You_Sure) = MsgBoxResult.Yes Then
                Master.eSettings.SetDefaultsForLists(Enums.DefaultType.ValidExts, True)
                RefreshValidExts()                
            End If
        End Sub

        Private Sub BtnRemoveNoStackClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveNoStack.Click
            RemoveNoStack()
        End Sub

        Private Sub BtnRemoveWhitelistClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveWhitelist.Click
            If lstWhitelist.Items.Count > 0 AndAlso lstWhitelist.SelectedItems.Count > 0 Then
                While lstWhitelist.SelectedItems.Count > 0
                    lstWhitelist.Items.Remove(lstWhitelist.SelectedItems(0))
                End While                
            End If
        End Sub

        Protected Overrides Sub LoadResources()            
            tpStandard.Text = Languages.Standard
            tpExpert.Text = Languages.Expert
            chkWhitelistVideo.Text = Languages.Whitelist_Video_Extensions
            lblWhitelistExt.Text = Languages.Whitelisted_Extensions
            lblWarning.Text = Languages.WARNING__Using_the_Expert_Mode_Cleaner
            gbCleanFiles.Text = Languages.Clean_Files
            gbNoStackExt.Text = Languages.No_Stack_Extensions
            gbValidVideoExt.Text = Languages.Valid_Video_Extensions            
        End Sub
    End Class
End Namespace