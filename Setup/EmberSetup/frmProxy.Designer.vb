<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProxy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.gbProxy = New System.Windows.Forms.GroupBox
        Me.gbCreds = New System.Windows.Forms.GroupBox
        Me.txtProxyDomain = New System.Windows.Forms.TextBox
        Me.lblProxyDomain = New System.Windows.Forms.Label
        Me.txtProxyPassword = New System.Windows.Forms.TextBox
        Me.txtProxyUsername = New System.Windows.Forms.TextBox
        Me.lblProxyUN = New System.Windows.Forms.Label
        Me.lblProxyPW = New System.Windows.Forms.Label
        Me.chkEnableCredentials = New System.Windows.Forms.CheckBox
        Me.lblProxyPort = New System.Windows.Forms.Label
        Me.lblProxyURI = New System.Windows.Forms.Label
        Me.txtProxyPort = New System.Windows.Forms.TextBox
        Me.txtProxyURI = New System.Windows.Forms.TextBox
        Me.chkEnableProxy = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbProxy.SuspendLayout()
        Me.gbCreds.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(152, 251)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'gbProxy
        '
        Me.gbProxy.Controls.Add(Me.gbCreds)
        Me.gbProxy.Controls.Add(Me.lblProxyPort)
        Me.gbProxy.Controls.Add(Me.lblProxyURI)
        Me.gbProxy.Controls.Add(Me.txtProxyPort)
        Me.gbProxy.Controls.Add(Me.txtProxyURI)
        Me.gbProxy.Controls.Add(Me.chkEnableProxy)
        Me.gbProxy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbProxy.Location = New System.Drawing.Point(12, 12)
        Me.gbProxy.Name = "gbProxy"
        Me.gbProxy.Size = New System.Drawing.Size(290, 230)
        Me.gbProxy.TabIndex = 1
        Me.gbProxy.TabStop = False
        Me.gbProxy.Text = "Proxy"
        '
        'gbCreds
        '
        Me.gbCreds.Controls.Add(Me.txtProxyDomain)
        Me.gbCreds.Controls.Add(Me.lblProxyDomain)
        Me.gbCreds.Controls.Add(Me.txtProxyPassword)
        Me.gbCreds.Controls.Add(Me.txtProxyUsername)
        Me.gbCreds.Controls.Add(Me.lblProxyUN)
        Me.gbCreds.Controls.Add(Me.lblProxyPW)
        Me.gbCreds.Controls.Add(Me.chkEnableCredentials)
        Me.gbCreds.Enabled = False
        Me.gbCreds.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbCreds.Location = New System.Drawing.Point(5, 115)
        Me.gbCreds.Name = "gbCreds"
        Me.gbCreds.Size = New System.Drawing.Size(279, 103)
        Me.gbCreds.TabIndex = 3
        Me.gbCreds.TabStop = False
        Me.gbCreds.Text = "Credentials"
        '
        'txtProxyDomain
        '
        Me.txtProxyDomain.Enabled = False
        Me.txtProxyDomain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProxyDomain.Location = New System.Drawing.Point(64, 69)
        Me.txtProxyDomain.Name = "txtProxyDomain"
        Me.txtProxyDomain.Size = New System.Drawing.Size(209, 22)
        Me.txtProxyDomain.TabIndex = 3
        '
        'lblProxyDomain
        '
        Me.lblProxyDomain.AutoSize = True
        Me.lblProxyDomain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxyDomain.Location = New System.Drawing.Point(14, 72)
        Me.lblProxyDomain.Name = "lblProxyDomain"
        Me.lblProxyDomain.Size = New System.Drawing.Size(50, 13)
        Me.lblProxyDomain.TabIndex = 17
        Me.lblProxyDomain.Text = "Domain:"
        '
        'txtProxyPassword
        '
        Me.txtProxyPassword.Enabled = False
        Me.txtProxyPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProxyPassword.Location = New System.Drawing.Point(201, 39)
        Me.txtProxyPassword.Name = "txtProxyPassword"
        Me.txtProxyPassword.Size = New System.Drawing.Size(72, 22)
        Me.txtProxyPassword.TabIndex = 2
        Me.txtProxyPassword.UseSystemPasswordChar = True
        '
        'txtProxyUsername
        '
        Me.txtProxyUsername.Enabled = False
        Me.txtProxyUsername.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProxyUsername.Location = New System.Drawing.Point(64, 39)
        Me.txtProxyUsername.Name = "txtProxyUsername"
        Me.txtProxyUsername.Size = New System.Drawing.Size(72, 22)
        Me.txtProxyUsername.TabIndex = 1
        '
        'lblProxyUN
        '
        Me.lblProxyUN.AutoSize = True
        Me.lblProxyUN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxyUN.Location = New System.Drawing.Point(3, 42)
        Me.lblProxyUN.Name = "lblProxyUN"
        Me.lblProxyUN.Size = New System.Drawing.Size(61, 13)
        Me.lblProxyUN.TabIndex = 15
        Me.lblProxyUN.Text = "Username:"
        '
        'lblProxyPW
        '
        Me.lblProxyPW.AutoSize = True
        Me.lblProxyPW.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxyPW.Location = New System.Drawing.Point(143, 42)
        Me.lblProxyPW.Name = "lblProxyPW"
        Me.lblProxyPW.Size = New System.Drawing.Size(59, 13)
        Me.lblProxyPW.TabIndex = 14
        Me.lblProxyPW.Text = "Password:"
        '
        'chkEnableCredentials
        '
        Me.chkEnableCredentials.AutoSize = True
        Me.chkEnableCredentials.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableCredentials.Location = New System.Drawing.Point(8, 17)
        Me.chkEnableCredentials.Name = "chkEnableCredentials"
        Me.chkEnableCredentials.Size = New System.Drawing.Size(122, 17)
        Me.chkEnableCredentials.TabIndex = 0
        Me.chkEnableCredentials.Text = "Enable Credentials"
        Me.chkEnableCredentials.UseVisualStyleBackColor = True
        '
        'lblProxyPort
        '
        Me.lblProxyPort.AutoSize = True
        Me.lblProxyPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxyPort.Location = New System.Drawing.Point(9, 88)
        Me.lblProxyPort.Name = "lblProxyPort"
        Me.lblProxyPort.Size = New System.Drawing.Size(61, 13)
        Me.lblProxyPort.TabIndex = 5
        Me.lblProxyPort.Text = "Proxy Port:"
        '
        'lblProxyURI
        '
        Me.lblProxyURI.AutoSize = True
        Me.lblProxyURI.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxyURI.Location = New System.Drawing.Point(9, 39)
        Me.lblProxyURI.Name = "lblProxyURI"
        Me.lblProxyURI.Size = New System.Drawing.Size(58, 13)
        Me.lblProxyURI.TabIndex = 4
        Me.lblProxyURI.Text = "Proxy URI:"
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Enabled = False
        Me.txtProxyPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProxyPort.Location = New System.Drawing.Point(72, 84)
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Size = New System.Drawing.Size(51, 22)
        Me.txtProxyPort.TabIndex = 2
        '
        'txtProxyURI
        '
        Me.txtProxyURI.Enabled = False
        Me.txtProxyURI.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProxyURI.Location = New System.Drawing.Point(11, 54)
        Me.txtProxyURI.Name = "txtProxyURI"
        Me.txtProxyURI.Size = New System.Drawing.Size(267, 22)
        Me.txtProxyURI.TabIndex = 1
        '
        'chkEnableProxy
        '
        Me.chkEnableProxy.AutoSize = True
        Me.chkEnableProxy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableProxy.Location = New System.Drawing.Point(11, 17)
        Me.chkEnableProxy.Name = "chkEnableProxy"
        Me.chkEnableProxy.Size = New System.Drawing.Size(91, 17)
        Me.chkEnableProxy.TabIndex = 0
        Me.chkEnableProxy.Text = "Enable Proxy"
        Me.chkEnableProxy.UseVisualStyleBackColor = True
        '
        'frmProxy
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(310, 292)
        Me.Controls.Add(Me.gbProxy)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProxy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proxy Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.gbProxy.ResumeLayout(False)
        Me.gbProxy.PerformLayout()
        Me.gbCreds.ResumeLayout(False)
        Me.gbCreds.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents gbProxy As System.Windows.Forms.GroupBox
    Friend WithEvents gbCreds As System.Windows.Forms.GroupBox
    Friend WithEvents txtProxyDomain As System.Windows.Forms.TextBox
    Friend WithEvents lblProxyDomain As System.Windows.Forms.Label
    Friend WithEvents txtProxyPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblProxyUN As System.Windows.Forms.Label
    Friend WithEvents lblProxyPW As System.Windows.Forms.Label
    Friend WithEvents chkEnableCredentials As System.Windows.Forms.CheckBox
    Friend WithEvents lblProxyPort As System.Windows.Forms.Label
    Friend WithEvents lblProxyURI As System.Windows.Forms.Label
    Friend WithEvents txtProxyPort As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyURI As System.Windows.Forms.TextBox
    Friend WithEvents chkEnableProxy As System.Windows.Forms.CheckBox

End Class
