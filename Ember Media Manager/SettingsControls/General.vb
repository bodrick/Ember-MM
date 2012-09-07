Imports EmberMediaManger.API
Imports System.Net

Namespace SettingsControls    
    Public Class General

        Private Sub ChkNoDisplayFanartCheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkNoDisplayFanart.CheckedChanged            
            If chkNoDisplayFanart.Checked AndAlso chkNoDisplayPoster.Checked Then
                chkShowDims.Enabled = False
                chkShowDims.Checked = False
            Else
                chkShowDims.Enabled = True
            End If
        End Sub

        Private Sub ChkNoDisplayPosterCheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkNoDisplayPoster.CheckedChanged            
            If chkNoDisplayFanart.Checked AndAlso chkNoDisplayPoster.Checked Then
                chkShowDims.Enabled = False
                chkShowDims.Checked = False
            Else
                chkShowDims.Enabled = True
            End If
        End Sub

        Private Sub chkEnableCredentials_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkEnableCredentials.CheckedChanged
            txtProxyUsername.Enabled = chkEnableCredentials.Checked
            txtProxyPassword.Enabled = chkEnableCredentials.Checked
            txtProxyDomain.Enabled = chkEnableCredentials.Checked

            If Not chkEnableCredentials.Checked Then
                txtProxyUsername.Text = String.Empty
                txtProxyPassword.Text = String.Empty
                txtProxyDomain.Text = String.Empty
            End If
        End Sub

        Private Sub chkEnableProxy_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkEnableProxy.CheckedChanged
            txtProxyURI.Enabled = chkEnableProxy.Checked
            txtProxyPort.Enabled = chkEnableProxy.Checked
            gbCreds.Enabled = chkEnableProxy.Checked

            If Not chkEnableProxy.Checked Then
                txtProxyURI.Text = String.Empty
                txtProxyPort.Text = String.Empty
                chkEnableCredentials.Checked = False
                txtProxyUsername.Text = String.Empty
                txtProxyPassword.Text = String.Empty
                txtProxyDomain.Text = String.Empty
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            chkOverwriteNfo.Checked = Master.eSettings.OverwriteNfo
            chkLogErrors.Checked = Master.eSettings.LogErrors
            chkUpdates.Checked = Master.eSettings.CheckUpdates
            chkInfoPanelAnim.Checked = Master.eSettings.InfoPanelAnim
            chkShowDims.Checked = Master.eSettings.ShowDims
            chkNoDisplayFanart.Checked = Master.eSettings.NoDisplayFanart
            chkNoDisplayPoster.Checked = Master.eSettings.NoDisplayPoster
            chkShowGenresText.Checked = Master.eSettings.AllwaysDisplayGenresText
            chkSourceFromFolder.Checked = Master.eSettings.SourceFromFolder
            If Not String.IsNullOrEmpty(Master.eSettings.ProxyURI) AndAlso Master.eSettings.ProxyPort >= 0 Then
                chkEnableProxy.Checked = True
                txtProxyURI.Text = Master.eSettings.ProxyURI
                txtProxyPort.Text = Master.eSettings.ProxyPort.ToString

                If Not String.IsNullOrEmpty(Master.eSettings.ProxyCreds.UserName) Then
                    chkEnableCredentials.Checked = True
                    txtProxyUsername.Text = Master.eSettings.ProxyCreds.UserName
                    txtProxyPassword.Text = Master.eSettings.ProxyCreds.Password
                    txtProxyDomain.Text = Master.eSettings.ProxyCreds.Domain
                End If
            End If
        End Sub

        Public Overrides Sub SaveSettings()
            Master.eSettings.LogErrors = chkLogErrors.Checked
            Master.eSettings.OverwriteNfo = chkOverwriteNfo.Checked
            Master.eSettings.CheckUpdates = chkUpdates.Checked
            Master.eSettings.InfoPanelAnim = chkInfoPanelAnim.Checked
            Master.eSettings.ShowDims = chkShowDims.Checked
            Master.eSettings.NoDisplayFanart = chkNoDisplayFanart.Checked
            Master.eSettings.NoDisplayPoster = chkNoDisplayPoster.Checked
            Master.eSettings.AllwaysDisplayGenresText = chkShowGenresText.Checked
            Master.eSettings.SourceFromFolder = chkSourceFromFolder.Checked
            If Not String.IsNullOrEmpty(txtProxyURI.Text) AndAlso Not String.IsNullOrEmpty(txtProxyPort.Text) Then
                Master.eSettings.ProxyURI = txtProxyURI.Text
                Master.eSettings.ProxyPort = Convert.ToInt32(txtProxyPort.Text)

                If Not String.IsNullOrEmpty(txtProxyUsername.Text) AndAlso Not String.IsNullOrEmpty(txtProxyPassword.Text) Then
                    Master.eSettings.ProxyCreds.UserName = txtProxyUsername.Text
                    Master.eSettings.ProxyCreds.Password = txtProxyPassword.Text
                    Master.eSettings.ProxyCreds.Domain = txtProxyDomain.Text
                Else
                    Master.eSettings.ProxyCreds = New NetworkCredential
                End If
            Else
                Master.eSettings.ProxyURI = String.Empty
                Master.eSettings.ProxyPort = -1
            End If
        End Sub

        Protected Overrides Sub LoadResources()
            gbMiscellaneous.Text = Languages.Miscellaneous
            chkUpdates.Text = Languages.Check_for_Updates
            chkInfoPanelAnim.Text = Languages.Enable_Panel_Animation
            chkOverwriteNfo.Text = Languages.Overwrite_Non_conforming_nfos
            lblWarningNfos.Text = Languages.If_unchecked_non_conforming_nfos_will_be_renamed
            chkLogErrors.Text = Languages.Log_Errors_to_File
            chkShowGenresText.Text = Languages.Always_Display_Genre_Text
            chkNoDisplayFanart.Text = Languages.Do_Not_Display_Fanart
            chkNoDisplayPoster.Text = Languages.Do_Not_Display_Poster
            chkShowDims.Text = Languages.Display_Image_Dimensions
            chkSourceFromFolder.Text = Languages.Include_Folder_Name_in_Source_Type_Check
            gbProxy.Text = Languages.Proxy
            chkEnableProxy.Text = Languages.Enable_Proxy
            lblProxyURI.Text = Languages.Proxy_URL
            lblProxyPort.Text = Languages.Proxy_Port
            gbCreds.Text = Languages.Credentials
            chkEnableCredentials.Text = Languages.Enable_Credentials
            lblProxyUN.Text = Languages.Username
            lblProxyPW.Text = Languages.Password
            lblProxyDomain.Text = Languages.Domain
        End Sub
    End Class
End Namespace