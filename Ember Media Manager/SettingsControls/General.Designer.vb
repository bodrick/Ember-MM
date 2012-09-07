Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class General
        Inherits EmberControls.ManagedPanel

        'UserControl overrides dispose to clean up the component list.
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
            Me.gbMiscellaneous = New System.Windows.Forms.GroupBox()
            Me.chkShowGenresText = New System.Windows.Forms.CheckBox()
            Me.chkSourceFromFolder = New System.Windows.Forms.CheckBox()
            Me.chkNoDisplayFanart = New System.Windows.Forms.CheckBox()
            Me.chkInfoPanelAnim = New System.Windows.Forms.CheckBox()
            Me.chkNoDisplayPoster = New System.Windows.Forms.CheckBox()
            Me.chkShowDims = New System.Windows.Forms.CheckBox()
            Me.chkUpdates = New System.Windows.Forms.CheckBox()
            Me.chkOverwriteNfo = New System.Windows.Forms.CheckBox()
            Me.lblWarningNfos = New System.Windows.Forms.Label()
            Me.chkLogErrors = New System.Windows.Forms.CheckBox()
            Me.gbProxy = New System.Windows.Forms.GroupBox()
            Me.gbCreds = New System.Windows.Forms.GroupBox()
            Me.txtProxyDomain = New System.Windows.Forms.TextBox()
            Me.lblProxyDomain = New System.Windows.Forms.Label()
            Me.txtProxyPassword = New System.Windows.Forms.TextBox()
            Me.txtProxyUsername = New System.Windows.Forms.TextBox()
            Me.lblProxyUN = New System.Windows.Forms.Label()
            Me.lblProxyPW = New System.Windows.Forms.Label()
            Me.chkEnableCredentials = New System.Windows.Forms.CheckBox()
            Me.lblProxyPort = New System.Windows.Forms.Label()
            Me.lblProxyURI = New System.Windows.Forms.Label()
            Me.txtProxyPort = New System.Windows.Forms.TextBox()
            Me.txtProxyURI = New System.Windows.Forms.TextBox()
            Me.chkEnableProxy = New System.Windows.Forms.CheckBox()
            Me.gbMiscellaneous.SuspendLayout()
            Me.gbProxy.SuspendLayout()
            Me.gbCreds.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbMiscellaneous
            '
            Me.gbMiscellaneous.Controls.Add(Me.chkShowGenresText)
            Me.gbMiscellaneous.Controls.Add(Me.chkSourceFromFolder)
            Me.gbMiscellaneous.Controls.Add(Me.chkNoDisplayFanart)
            Me.gbMiscellaneous.Controls.Add(Me.chkInfoPanelAnim)
            Me.gbMiscellaneous.Controls.Add(Me.chkNoDisplayPoster)
            Me.gbMiscellaneous.Controls.Add(Me.chkShowDims)
            Me.gbMiscellaneous.Controls.Add(Me.chkUpdates)
            Me.gbMiscellaneous.Controls.Add(Me.chkOverwriteNfo)
            Me.gbMiscellaneous.Controls.Add(Me.lblWarningNfos)
            Me.gbMiscellaneous.Controls.Add(Me.chkLogErrors)
            Me.gbMiscellaneous.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMiscellaneous.Location = New System.Drawing.Point(12, 3)
            Me.gbMiscellaneous.Name = "gbMiscellaneous"
            Me.gbMiscellaneous.Size = New System.Drawing.Size(290, 246)
            Me.gbMiscellaneous.TabIndex = 5
            Me.gbMiscellaneous.TabStop = False
            Me.gbMiscellaneous.Text = "Miscellaneous"
            '
            'chkShowGenresText
            '
            Me.chkShowGenresText.AutoSize = True
            Me.chkShowGenresText.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowGenresText.Location = New System.Drawing.Point(10, 178)
            Me.chkShowGenresText.Name = "chkShowGenresText"
            Me.chkShowGenresText.Size = New System.Drawing.Size(166, 17)
            Me.chkShowGenresText.TabIndex = 57
            Me.chkShowGenresText.Text = "Allways Display Genres Text"
            Me.chkShowGenresText.UseVisualStyleBackColor = True
            '
            'chkSourceFromFolder
            '
            Me.chkSourceFromFolder.AutoSize = True
            Me.chkSourceFromFolder.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSourceFromFolder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSourceFromFolder.Location = New System.Drawing.Point(10, 110)
            Me.chkSourceFromFolder.Name = "chkSourceFromFolder"
            Me.chkSourceFromFolder.Size = New System.Drawing.Size(243, 17)
            Me.chkSourceFromFolder.TabIndex = 16
            Me.chkSourceFromFolder.Text = Global.EmberMediaManger.Languages.Include_Folder_Name_in_Source_Type_Check
            Me.chkSourceFromFolder.UseVisualStyleBackColor = True
            '
            'chkNoDisplayFanart
            '
            Me.chkNoDisplayFanart.AutoSize = True
            Me.chkNoDisplayFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoDisplayFanart.Location = New System.Drawing.Point(10, 144)
            Me.chkNoDisplayFanart.Name = "chkNoDisplayFanart"
            Me.chkNoDisplayFanart.Size = New System.Drawing.Size(139, 17)
            Me.chkNoDisplayFanart.TabIndex = 2
            Me.chkNoDisplayFanart.Text = Global.EmberMediaManger.Languages.Do_Not_Display_Fanart
            Me.chkNoDisplayFanart.UseVisualStyleBackColor = True
            '
            'chkInfoPanelAnim
            '
            Me.chkInfoPanelAnim.AutoSize = True
            Me.chkInfoPanelAnim.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkInfoPanelAnim.Location = New System.Drawing.Point(10, 94)
            Me.chkInfoPanelAnim.Name = "chkInfoPanelAnim"
            Me.chkInfoPanelAnim.Size = New System.Drawing.Size(148, 17)
            Me.chkInfoPanelAnim.TabIndex = 3
            Me.chkInfoPanelAnim.Text = "Enable Panel Animation"
            Me.chkInfoPanelAnim.UseVisualStyleBackColor = True
            '
            'chkNoDisplayPoster
            '
            Me.chkNoDisplayPoster.AutoSize = True
            Me.chkNoDisplayPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoDisplayPoster.Location = New System.Drawing.Point(10, 127)
            Me.chkNoDisplayPoster.Name = "chkNoDisplayPoster"
            Me.chkNoDisplayPoster.Size = New System.Drawing.Size(138, 17)
            Me.chkNoDisplayPoster.TabIndex = 1
            Me.chkNoDisplayPoster.Text = Global.EmberMediaManger.Languages.Do_Not_Display_Poster
            Me.chkNoDisplayPoster.UseVisualStyleBackColor = True
            '
            'chkShowDims
            '
            Me.chkShowDims.AutoSize = True
            Me.chkShowDims.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowDims.Location = New System.Drawing.Point(10, 161)
            Me.chkShowDims.Name = "chkShowDims"
            Me.chkShowDims.Size = New System.Drawing.Size(160, 17)
            Me.chkShowDims.TabIndex = 3
            Me.chkShowDims.Text = Global.EmberMediaManger.Languages.Display_Image_Dimensions
            Me.chkShowDims.UseVisualStyleBackColor = True
            '
            'chkUpdates
            '
            Me.chkUpdates.AutoSize = True
            Me.chkUpdates.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUpdates.Location = New System.Drawing.Point(10, 20)
            Me.chkUpdates.Name = "chkUpdates"
            Me.chkUpdates.Size = New System.Drawing.Size(121, 17)
            Me.chkUpdates.TabIndex = 0
            Me.chkUpdates.Text = "Check for Updates"
            Me.chkUpdates.UseVisualStyleBackColor = True
            '
            'chkOverwriteNfo
            '
            Me.chkOverwriteNfo.AutoSize = True
            Me.chkOverwriteNfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOverwriteNfo.Location = New System.Drawing.Point(10, 54)
            Me.chkOverwriteNfo.Name = "chkOverwriteNfo"
            Me.chkOverwriteNfo.Size = New System.Drawing.Size(191, 17)
            Me.chkOverwriteNfo.TabIndex = 2
            Me.chkOverwriteNfo.Text = Global.EmberMediaManger.Languages.Overwrite_Non_conforming_nfos
            Me.chkOverwriteNfo.UseVisualStyleBackColor = True
            '
            'lblWarningNfos
            '
            Me.lblWarningNfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarningNfos.Location = New System.Drawing.Point(20, 68)
            Me.lblWarningNfos.Name = "lblWarningNfos"
            Me.lblWarningNfos.Size = New System.Drawing.Size(165, 24)
            Me.lblWarningNfos.TabIndex = 15
            Me.lblWarningNfos.Text = "(If unchecked, non-conforming nfos will be renamed to <filename>.info)"
            Me.lblWarningNfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkLogErrors
            '
            Me.chkLogErrors.AutoSize = True
            Me.chkLogErrors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLogErrors.Location = New System.Drawing.Point(10, 37)
            Me.chkLogErrors.Name = "chkLogErrors"
            Me.chkLogErrors.Size = New System.Drawing.Size(113, 17)
            Me.chkLogErrors.TabIndex = 1
            Me.chkLogErrors.Text = Global.EmberMediaManger.Languages.Log_Errors_to_File
            Me.chkLogErrors.UseVisualStyleBackColor = True
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
            Me.gbProxy.Location = New System.Drawing.Point(314, 3)
            Me.gbProxy.Name = "gbProxy"
            Me.gbProxy.Size = New System.Drawing.Size(290, 246)
            Me.gbProxy.TabIndex = 6
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
            'General
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbProxy)
            Me.Controls.Add(Me.gbMiscellaneous)
            Me.Name = "General"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_General
            Me.PanelOrder = 100
            Me.PanelText = "General"
            Me.PanelType = "Options"
            Me.gbMiscellaneous.ResumeLayout(False)
            Me.gbMiscellaneous.PerformLayout()
            Me.gbProxy.ResumeLayout(False)
            Me.gbProxy.PerformLayout()
            Me.gbCreds.ResumeLayout(False)
            Me.gbCreds.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbMiscellaneous As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowGenresText As System.Windows.Forms.CheckBox
        Friend WithEvents chkSourceFromFolder As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoDisplayFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkInfoPanelAnim As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoDisplayPoster As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowDims As System.Windows.Forms.CheckBox
        Friend WithEvents chkUpdates As System.Windows.Forms.CheckBox
        Friend WithEvents chkOverwriteNfo As System.Windows.Forms.CheckBox
        Friend WithEvents lblWarningNfos As System.Windows.Forms.Label
        Friend WithEvents chkLogErrors As System.Windows.Forms.CheckBox
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
End Namespace