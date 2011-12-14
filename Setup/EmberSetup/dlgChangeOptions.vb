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
Imports System.Net

Public Class dlgChangeOptions

    #Region "Fields"

    'Private localPath As String = String.Empty
    'Private internalChange As Boolean = False
    #End Region 'Fields

    #Region "Methods"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If frmMainSetup.bwFF.IsBusy Then
            frmMainSetup.bwFF.CancelAsync()
            btnCancel.Enabled = False
        End If
    End Sub

    Private Sub btnFindPaths_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPaths.Click
        btnFindPaths.Enabled = False
        pbCancel.MarqueeAnimationSpeed = 25
        pbCancel.Style = ProgressBarStyle.Marquee
        pnlCancel.Visible = True
        btnCancel.Enabled = True
        frmMainSetup.FindEmberPath()
        pnlCancel.Visible = False
        If frmMainSetup.emberAllFounds.Count > 0 Then
            frmMainSetup.emberPath = frmMainSetup.emberAllFounds(0)
            lstEMMPaths.Items.Clear()
            For Each t As String In frmMainSetup.emberAllFounds
                lstEMMPaths.Items.Add(Path.GetDirectoryName(t))
            Next
        End If
        If frmMainSetup.emberPath = String.Empty Then
            If frmMainSetup.CheckIfWindows Then
                frmMainSetup.emberPath = frmMainSetup.WindowsInstallPath
                'frmMainSetup.emberPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData)
                If frmMainSetup.emberPath = String.Empty Then
                    frmMainSetup.emberPath = "C:\Ember Media Manager"
                End If
            End If
        End If
        If File.Exists(Path.Combine(frmMainSetup.AppPath, "Ember Media Manager.exe")) Then
            frmMainSetup.emberPath = frmMainSetup.AppPath()
        End If
        txtEMMPath.Text = frmMainSetup.emberPath
        pnlCancel.Visible = False
        btnFindPaths.Enabled = True
        frmMainSetup.LogWrite(String.Format("Main: Using Ember Path: {0}", frmMainSetup.emberPath))
    End Sub

    Private Sub btnGetEMMPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEMMPath.Click
        Using d As New FolderBrowserDialog
            d.Description = "Select the folder in which you would like to install Ember Media Manager."
            If d.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                txtEMMPath.Text = (Path.Combine(d.SelectedPath, "Ember Media Manager") & Path.DirectorySeparatorChar).Replace(Path.DirectorySeparatorChar + Path.DirectorySeparatorChar, Path.DirectorySeparatorChar)
                txtEMMPath.Text.Replace(Path.DirectorySeparatorChar + Path.DirectorySeparatorChar, Path.DirectorySeparatorChar)
            End If
        End Using
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangeOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUp()
        If String.IsNullOrEmpty(frmMainSetup.emberPath) Then
            txtEMMPath.Text = (Path.Combine(frmMainSetup.AppPath(), "Ember Media Manager") & Path.DirectorySeparatorChar).Replace(Path.DirectorySeparatorChar + Path.DirectorySeparatorChar, Path.DirectorySeparatorChar)
        Else
            txtEMMPath.Text = (frmMainSetup.emberPath & Path.DirectorySeparatorChar).Replace(Path.DirectorySeparatorChar + Path.DirectorySeparatorChar, Path.DirectorySeparatorChar)
        End If
        'txtEMMPath.Text = frmMainSetup.emberPath
        'localPath = frmMainSetup.emberPath
    End Sub

    Private Sub dlgChangeOptions_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Refresh()
    End Sub

    Private Sub lstEMMPaths_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEMMPaths.SelectedIndexChanged
        If lstEMMPaths.SelectedItems.Count > 0 Then
            txtEMMPath.Text = lstEMMPaths.SelectedItems(0).Text
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        frmMainSetup.emberPath = txtEMMPath.Text
        Me.Close()
    End Sub

    Private Sub rbX64_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbX64.CheckedChanged
        If rbX64.Checked Then frmMainSetup.CurrentEmberPlatform = "x64"
    End Sub

    Private Sub rbX86_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbX86.CheckedChanged
        If rbX86.Checked Then frmMainSetup.CurrentEmberPlatform = "x86"
    End Sub

    Private Sub txtEMMPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEMMPath.TextChanged
        If frmMainSetup.CheckIfWindows Then
            Dim p As String = String.Empty
            If Directory.Exists(txtEMMPath.Text) Then
                p = frmMainSetup.GetEmberPlatform(Path.GetDirectoryName(txtEMMPath.Text))
            Else
                p = If(frmMainSetup.Is64Bit, "x64", "x86")
            End If

            If p = "x86" Then
                rbX86.Checked = True
            End If
            If p = "x64" Then
                rbX64.Checked = True
            End If

        Else
            lblInfo.Text = "Platform: Mono"
            rbX86.Visible = False
            rbX64.Visible = False
        End If
    End Sub
    Sub SetUp()
        GroupBox1.Text = frmMainSetup.MyLang.GetString(46, "Ember Media Manager Installation Path")
        lblStatus.Text = frmMainSetup.MyLang.GetString(47, "Searching for possible Ember Media Manager Installations")
        btnFindPaths.Text = frmMainSetup.MyLang.GetString(49, "Find Ember Installations")
        OK_Button.Text = frmMainSetup.MyLang.GetString(50, "OK")
        Cancel_Button.Text = frmMainSetup.MyLang.GetString(37, "Cancel")
        btnCancel.Text = frmMainSetup.MyLang.GetString(37, "Cancel")
        lblInfo.Text = frmMainSetup.MyLang.GetString(51, "Platform")
    End Sub
    #End Region 'Methods

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProxy.Click
        Using proxy As New frmProxy
            If proxy.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(proxy.txtProxyURI.Text) AndAlso Not String.IsNullOrEmpty(proxy.txtProxyPort.Text) Then
                    frmMainSetup.eSettings.ProxyURI = proxy.txtProxyURI.Text
                    frmMainSetup.eSettings.ProxyPort = Convert.ToInt32(proxy.txtProxyPort.Text)

                    If Not String.IsNullOrEmpty(proxy.txtProxyUsername.Text) AndAlso Not String.IsNullOrEmpty(proxy.txtProxyPassword.Text) Then
                        frmMainSetup.eSettings.ProxyCreds.UserName = proxy.txtProxyUsername.Text
                        frmMainSetup.eSettings.ProxyCreds.Password = proxy.txtProxyPassword.Text
                        frmMainSetup.eSettings.ProxyCreds.Domain = proxy.txtProxyDomain.Text
                    Else
                        frmMainSetup.eSettings.ProxyCreds = New NetworkCredential
                    End If
                Else
                    frmMainSetup.eSettings.ProxyURI = String.Empty
                    frmMainSetup.eSettings.ProxyPort = -1
                End If
                frmMainSetup.eSettings.Save(Path.Combine(frmMainSetup.emberPath, "Setup.xml"))
            End If
        End Using
    End Sub
End Class