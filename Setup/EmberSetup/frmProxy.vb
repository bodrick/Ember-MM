Imports System.Windows.Forms
Imports System.IO
Imports EmberSetup.frmMainSetup

Public Class frmProxy

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub chkEnableProxy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableProxy.CheckedChanged
        Me.txtProxyURI.Enabled = Me.chkEnableProxy.Checked
        Me.txtProxyPort.Enabled = Me.chkEnableProxy.Checked
        Me.gbCreds.Enabled = Me.chkEnableProxy.Checked

        If Not Me.chkEnableProxy.Checked Then
            Me.txtProxyURI.Text = String.Empty
            Me.txtProxyPort.Text = String.Empty
            Me.chkEnableCredentials.Checked = False
            Me.txtProxyUsername.Text = String.Empty
            Me.txtProxyPassword.Text = String.Empty
            Me.txtProxyDomain.Text = String.Empty
        End If
    End Sub

    Private Sub chkEnableCredentials_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableCredentials.CheckedChanged
        Me.txtProxyUsername.Enabled = Me.chkEnableCredentials.Checked
        Me.txtProxyPassword.Enabled = Me.chkEnableCredentials.Checked
        Me.txtProxyDomain.Enabled = Me.chkEnableCredentials.Checked

        If Not Me.chkEnableCredentials.Checked Then
            Me.txtProxyUsername.Text = String.Empty
            Me.txtProxyPassword.Text = String.Empty
            Me.txtProxyDomain.Text = String.Empty
        End If
    End Sub

    Private Sub frmProxy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmMainSetup.eSettings = Settings.Load(Path.Combine(frmMainSetup.emberPath, "Setup.xml"))
        If Not String.IsNullOrEmpty(frmMainSetup.eSettings.ProxyURI) AndAlso frmMainSetup.eSettings.ProxyPort >= 0 Then
            Me.chkEnableProxy.Checked = True
            Me.txtProxyURI.Text = frmMainSetup.eSettings.ProxyURI
            Me.txtProxyPort.Text = frmMainSetup.eSettings.ProxyPort.ToString

            If Not String.IsNullOrEmpty(frmMainSetup.eSettings.ProxyCreds.UserName) Then
                Me.chkEnableCredentials.Checked = True
                Me.txtProxyUsername.Text = frmMainSetup.eSettings.ProxyCreds.UserName
                Me.txtProxyPassword.Text = frmMainSetup.eSettings.ProxyCreds.Password
                Me.txtProxyDomain.Text = frmMainSetup.eSettings.ProxyCreds.Domain
            End If
        End If
    End Sub
End Class
