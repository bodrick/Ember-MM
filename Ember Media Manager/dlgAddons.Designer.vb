<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAddons))
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.pnlList = New System.Windows.Forms.Panel
        Me.pnlStatus = New System.Windows.Forms.Panel
        Me.lblStatus = New System.Windows.Forms.Label
        Me.pbStatus = New System.Windows.Forms.ProgressBar
        Me.pnlLogin = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnLogin = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblLogin = New System.Windows.Forms.Label
        Me.pbLogin = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tsCategories = New System.Windows.Forms.ToolStrip
        Me.tsbTranslations = New System.Windows.Forms.ToolStripButton
        Me.tsbThemes = New System.Windows.Forms.ToolStripButton
        Me.tsbTemplates = New System.Windows.Forms.ToolStripButton
        Me.tsbModules = New System.Windows.Forms.ToolStripButton
        Me.tsbOther = New System.Windows.Forms.ToolStripButton
        Me.tslSpacer = New System.Windows.Forms.ToolStripLabel
        Me.tsbNew = New System.Windows.Forms.ToolStripButton
        Me.pnlCurrent = New System.Windows.Forms.Panel
        Me.pbCurrent = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCurrent = New System.Windows.Forms.Label
        Me.pnlStatus.SuspendLayout()
        Me.pnlLogin.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tsCategories.SuspendLayout()
        CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(454, 418)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'pnlList
        '
        Me.pnlList.AutoScroll = True
        Me.pnlList.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlList.Location = New System.Drawing.Point(5, 90)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(516, 322)
        Me.pnlList.TabIndex = 1
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.White
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.lblStatus)
        Me.pnlStatus.Controls.Add(Me.pbStatus)
        Me.pnlStatus.Location = New System.Drawing.Point(102, 216)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(321, 57)
        Me.pnlStatus.TabIndex = 10
        Me.pnlStatus.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(5, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(310, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "lblStatus"
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(6, 32)
        Me.pbStatus.MarqueeAnimationSpeed = 25
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(309, 19)
        Me.pbStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbStatus.TabIndex = 6
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlLogin.Controls.Add(Me.Panel4)
        Me.pnlLogin.Location = New System.Drawing.Point(107, 169)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(310, 153)
        Me.pnlLogin.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.btnLogin)
        Me.Panel4.Controls.Add(Me.txtPassword)
        Me.Panel4.Controls.Add(Me.txtUsername)
        Me.Panel4.Controls.Add(Me.lblPassword)
        Me.Panel4.Controls.Add(Me.lblUsername)
        Me.Panel4.Controls.Add(Me.lblLogin)
        Me.Panel4.Controls.Add(Me.pbLogin)
        Me.Panel4.Location = New System.Drawing.Point(5, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(300, 143)
        Me.Panel4.TabIndex = 0
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(215, 110)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(78, 25)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(126, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(113, 22)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(126, 47)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(113, 22)
        Me.txtUsername.TabIndex = 4
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(61, 78)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(59, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password:"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(59, 50)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(61, 13)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = "Username:"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(48, 7)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(245, 30)
        Me.lblLogin.TabIndex = 1
        Me.lblLogin.Text = "Login to Addons Server"
        '
        'pbLogin
        '
        Me.pbLogin.Image = CType(resources.GetObject("pbLogin.Image"), System.Drawing.Image)
        Me.pbLogin.Location = New System.Drawing.Point(3, 3)
        Me.pbLogin.Name = "pbLogin"
        Me.pbLogin.Size = New System.Drawing.Size(43, 34)
        Me.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogin.TabIndex = 0
        Me.pbLogin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tsCategories)
        Me.Panel1.Location = New System.Drawing.Point(5, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 54)
        Me.Panel1.TabIndex = 2
        '
        'tsCategories
        '
        Me.tsCategories.CanOverflow = False
        Me.tsCategories.Enabled = False
        Me.tsCategories.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsCategories.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsCategories.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbTranslations, Me.tsbThemes, Me.tsbTemplates, Me.tsbModules, Me.tsbOther, Me.tslSpacer, Me.tsbNew})
        Me.tsCategories.Location = New System.Drawing.Point(0, 0)
        Me.tsCategories.Name = "tsCategories"
        Me.tsCategories.Size = New System.Drawing.Size(516, 54)
        Me.tsCategories.TabIndex = 0
        '
        'tsbTranslations
        '
        Me.tsbTranslations.Image = CType(resources.GetObject("tsbTranslations.Image"), System.Drawing.Image)
        Me.tsbTranslations.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTranslations.Name = "tsbTranslations"
        Me.tsbTranslations.Size = New System.Drawing.Size(75, 51)
        Me.tsbTranslations.Tag = "Translations"
        Me.tsbTranslations.Text = "Translations"
        Me.tsbTranslations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbTranslations.ToolTipText = "Translations"
        '
        'tsbThemes
        '
        Me.tsbThemes.Image = CType(resources.GetObject("tsbThemes.Image"), System.Drawing.Image)
        Me.tsbThemes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbThemes.Name = "tsbThemes"
        Me.tsbThemes.Size = New System.Drawing.Size(53, 51)
        Me.tsbThemes.Tag = "Themes"
        Me.tsbThemes.Text = "Themes"
        Me.tsbThemes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbTemplates
        '
        Me.tsbTemplates.Image = CType(resources.GetObject("tsbTemplates.Image"), System.Drawing.Image)
        Me.tsbTemplates.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTemplates.Name = "tsbTemplates"
        Me.tsbTemplates.Size = New System.Drawing.Size(66, 51)
        Me.tsbTemplates.Tag = "Templates"
        Me.tsbTemplates.Text = "Templates"
        Me.tsbTemplates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbModules
        '
        Me.tsbModules.Image = CType(resources.GetObject("tsbModules.Image"), System.Drawing.Image)
        Me.tsbModules.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModules.Name = "tsbModules"
        Me.tsbModules.Size = New System.Drawing.Size(57, 51)
        Me.tsbModules.Tag = "Modules"
        Me.tsbModules.Text = "Modules"
        Me.tsbModules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbOther
        '
        Me.tsbOther.Image = CType(resources.GetObject("tsbOther.Image"), System.Drawing.Image)
        Me.tsbOther.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOther.Name = "tsbOther"
        Me.tsbOther.Size = New System.Drawing.Size(41, 51)
        Me.tsbOther.Tag = "Other"
        Me.tsbOther.Text = "Other"
        Me.tsbOther.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tslSpacer
        '
        Me.tslSpacer.Name = "tslSpacer"
        Me.tslSpacer.Size = New System.Drawing.Size(148, 51)
        Me.tslSpacer.Text = "                                               "
        '
        'tsbNew
        '
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(72, 51)
        Me.tsbNew.Tag = "Create New"
        Me.tsbNew.Text = "Create New"
        Me.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'pnlCurrent
        '
        Me.pnlCurrent.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlCurrent.Location = New System.Drawing.Point(214, 65)
        Me.pnlCurrent.Name = "pnlCurrent"
        Me.pnlCurrent.Size = New System.Drawing.Size(307, 25)
        Me.pnlCurrent.TabIndex = 66
        '
        'pbCurrent
        '
        Me.pbCurrent.Location = New System.Drawing.Point(2, 0)
        Me.pbCurrent.Name = "pbCurrent"
        Me.pbCurrent.Size = New System.Drawing.Size(24, 24)
        Me.pbCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCurrent.TabIndex = 2
        Me.pbCurrent.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.pbCurrent)
        Me.Panel2.Controls.Add(Me.lblCurrent)
        Me.Panel2.Location = New System.Drawing.Point(5, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(209, 25)
        Me.Panel2.TabIndex = 67
        '
        'lblCurrent
        '
        Me.lblCurrent.BackColor = System.Drawing.Color.SteelBlue
        Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent.ForeColor = System.Drawing.Color.White
        Me.lblCurrent.Location = New System.Drawing.Point(26, -1)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(179, 25)
        Me.lblCurrent.TabIndex = 63
        '
        'dlgAddons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(527, 446)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCurrent)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.pnlList)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAddons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Addons"
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlLogin.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsCategories.ResumeLayout(False)
        Me.tsCategories.PerformLayout()
        CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tsCategories As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbTranslations As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbThemes As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbTemplates As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbModules As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOther As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlCurrent As System.Windows.Forms.Panel
    Friend WithEvents pbCurrent As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents pbLogin As System.Windows.Forms.PictureBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents tslSpacer As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton

End Class
