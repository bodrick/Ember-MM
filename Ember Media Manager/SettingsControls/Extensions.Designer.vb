Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Extensions
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
            Me.gbNoStackExt = New System.Windows.Forms.GroupBox()
            Me.btnRemoveNoStack = New System.Windows.Forms.Button()
            Me.btnAddNoStack = New System.Windows.Forms.Button()
            Me.txtNoStack = New System.Windows.Forms.TextBox()
            Me.lstNoStack = New System.Windows.Forms.ListBox()
            Me.gbCleanFiles = New System.Windows.Forms.GroupBox()
            Me.tcCleaner = New System.Windows.Forms.TabControl()
            Me.tpStandard = New System.Windows.Forms.TabPage()
            Me.chkCleanFolderJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanExtrathumbs = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieTBN = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieNameJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieTBNb = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanFanartJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanPosterJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieFanartJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanPosterTBN = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieNFO = New System.Windows.Forms.CheckBox()
            Me.chkCleanDotFanartJPG = New System.Windows.Forms.CheckBox()
            Me.chkCleanMovieNFOb = New System.Windows.Forms.CheckBox()
            Me.tpExpert = New System.Windows.Forms.TabPage()
            Me.chkWhitelistVideo = New System.Windows.Forms.CheckBox()
            Me.lblWhitelistExt = New System.Windows.Forms.Label()
            Me.btnRemoveWhitelist = New System.Windows.Forms.Button()
            Me.btnAddWhitelist = New System.Windows.Forms.Button()
            Me.txtWhitelist = New System.Windows.Forms.TextBox()
            Me.lstWhitelist = New System.Windows.Forms.ListBox()
            Me.lblWarning = New System.Windows.Forms.Label()
            Me.gbValidVideoExt = New System.Windows.Forms.GroupBox()
            Me.btnResetValidExts = New System.Windows.Forms.Button()
            Me.btnRemMovieExt = New System.Windows.Forms.Button()
            Me.btnAddMovieExt = New System.Windows.Forms.Button()
            Me.txtMovieExt = New System.Windows.Forms.TextBox()
            Me.lstMovieExts = New System.Windows.Forms.ListBox()
            Me.gbNoStackExt.SuspendLayout()
            Me.gbCleanFiles.SuspendLayout()
            Me.tcCleaner.SuspendLayout()
            Me.tpStandard.SuspendLayout()
            Me.tpExpert.SuspendLayout()
            Me.gbValidVideoExt.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbNoStackExt
            '
            Me.gbNoStackExt.Controls.Add(Me.btnRemoveNoStack)
            Me.gbNoStackExt.Controls.Add(Me.btnAddNoStack)
            Me.gbNoStackExt.Controls.Add(Me.txtNoStack)
            Me.gbNoStackExt.Controls.Add(Me.lstNoStack)
            Me.gbNoStackExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbNoStackExt.Location = New System.Drawing.Point(202, 6)
            Me.gbNoStackExt.Name = "gbNoStackExt"
            Me.gbNoStackExt.Size = New System.Drawing.Size(194, 199)
            Me.gbNoStackExt.TabIndex = 5
            Me.gbNoStackExt.TabStop = False
            Me.gbNoStackExt.Text = "No Stack Extensions"
            '
            'btnRemoveNoStack
            '
            Me.btnRemoveNoStack.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveNoStack.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnRemoveNoStack.Location = New System.Drawing.Point(160, 167)
            Me.btnRemoveNoStack.Name = "btnRemoveNoStack"
            Me.btnRemoveNoStack.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveNoStack.TabIndex = 3
            Me.btnRemoveNoStack.UseVisualStyleBackColor = True
            '
            'btnAddNoStack
            '
            Me.btnAddNoStack.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddNoStack.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnAddNoStack.Location = New System.Drawing.Point(73, 167)
            Me.btnAddNoStack.Name = "btnAddNoStack"
            Me.btnAddNoStack.Size = New System.Drawing.Size(23, 23)
            Me.btnAddNoStack.TabIndex = 2
            Me.btnAddNoStack.UseVisualStyleBackColor = True
            '
            'txtNoStack
            '
            Me.txtNoStack.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.txtNoStack.Location = New System.Drawing.Point(11, 168)
            Me.txtNoStack.Name = "txtNoStack"
            Me.txtNoStack.Size = New System.Drawing.Size(61, 22)
            Me.txtNoStack.TabIndex = 1
            Me.txtNoStack.Tag = "IGNORE"
            '
            'lstNoStack
            '
            Me.lstNoStack.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.lstNoStack.FormattingEnabled = True
            Me.lstNoStack.Location = New System.Drawing.Point(11, 15)
            Me.lstNoStack.Name = "lstNoStack"
            Me.lstNoStack.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstNoStack.Size = New System.Drawing.Size(171, 134)
            Me.lstNoStack.Sorted = True
            Me.lstNoStack.TabIndex = 0
            '
            'gbCleanFiles
            '
            Me.gbCleanFiles.Controls.Add(Me.tcCleaner)
            Me.gbCleanFiles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbCleanFiles.Location = New System.Drawing.Point(401, 6)
            Me.gbCleanFiles.Name = "gbCleanFiles"
            Me.gbCleanFiles.Size = New System.Drawing.Size(208, 385)
            Me.gbCleanFiles.TabIndex = 6
            Me.gbCleanFiles.TabStop = False
            Me.gbCleanFiles.Text = "Clean Files"
            '
            'tcCleaner
            '
            Me.tcCleaner.Controls.Add(Me.tpStandard)
            Me.tcCleaner.Controls.Add(Me.tpExpert)
            Me.tcCleaner.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.tcCleaner.Location = New System.Drawing.Point(6, 19)
            Me.tcCleaner.Name = "tcCleaner"
            Me.tcCleaner.SelectedIndex = 0
            Me.tcCleaner.Size = New System.Drawing.Size(196, 363)
            Me.tcCleaner.TabIndex = 0
            '
            'tpStandard
            '
            Me.tpStandard.BackColor = System.Drawing.Color.White
            Me.tpStandard.Controls.Add(Me.chkCleanFolderJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanExtrathumbs)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieTBN)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieNameJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieTBNb)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanFanartJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanPosterJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieFanartJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanPosterTBN)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieNFO)
            Me.tpStandard.Controls.Add(Me.chkCleanDotFanartJPG)
            Me.tpStandard.Controls.Add(Me.chkCleanMovieNFOb)
            Me.tpStandard.Location = New System.Drawing.Point(4, 22)
            Me.tpStandard.Name = "tpStandard"
            Me.tpStandard.Padding = New System.Windows.Forms.Padding(3)
            Me.tpStandard.Size = New System.Drawing.Size(188, 337)
            Me.tpStandard.TabIndex = 0
            Me.tpStandard.Text = Global.EmberMediaManger.Languages.Standard
            Me.tpStandard.UseVisualStyleBackColor = True
            '
            'chkCleanFolderJPG
            '
            Me.chkCleanFolderJPG.AutoSize = True
            Me.chkCleanFolderJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanFolderJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanFolderJPG.Location = New System.Drawing.Point(7, 10)
            Me.chkCleanFolderJPG.Name = "chkCleanFolderJPG"
            Me.chkCleanFolderJPG.Size = New System.Drawing.Size(81, 17)
            Me.chkCleanFolderJPG.TabIndex = 0
            Me.chkCleanFolderJPG.Text = "/folder.jpg"
            Me.chkCleanFolderJPG.UseVisualStyleBackColor = True
            '
            'chkCleanExtrathumbs
            '
            Me.chkCleanExtrathumbs.AutoSize = True
            Me.chkCleanExtrathumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanExtrathumbs.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanExtrathumbs.Location = New System.Drawing.Point(7, 238)
            Me.chkCleanExtrathumbs.Name = "chkCleanExtrathumbs"
            Me.chkCleanExtrathumbs.Size = New System.Drawing.Size(98, 17)
            Me.chkCleanExtrathumbs.TabIndex = 12
            Me.chkCleanExtrathumbs.Text = "/extrathumbs/"
            Me.chkCleanExtrathumbs.UseVisualStyleBackColor = True
            '
            'chkCleanMovieTBN
            '
            Me.chkCleanMovieTBN.AutoSize = True
            Me.chkCleanMovieTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieTBN.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieTBN.Location = New System.Drawing.Point(7, 29)
            Me.chkCleanMovieTBN.Name = "chkCleanMovieTBN"
            Me.chkCleanMovieTBN.Size = New System.Drawing.Size(81, 17)
            Me.chkCleanMovieTBN.TabIndex = 1
            Me.chkCleanMovieTBN.Text = "/movie.tbn"
            Me.chkCleanMovieTBN.UseVisualStyleBackColor = True
            '
            'chkCleanMovieNameJPG
            '
            Me.chkCleanMovieNameJPG.AutoSize = True
            Me.chkCleanMovieNameJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieNameJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieNameJPG.Location = New System.Drawing.Point(7, 124)
            Me.chkCleanMovieNameJPG.Name = "chkCleanMovieNameJPG"
            Me.chkCleanMovieNameJPG.Size = New System.Drawing.Size(96, 17)
            Me.chkCleanMovieNameJPG.TabIndex = 6
            Me.chkCleanMovieNameJPG.Text = "/<movie>.jpg"
            Me.chkCleanMovieNameJPG.UseVisualStyleBackColor = True
            '
            'chkCleanMovieTBNb
            '
            Me.chkCleanMovieTBNb.AutoSize = True
            Me.chkCleanMovieTBNb.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieTBNb.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieTBNb.Location = New System.Drawing.Point(7, 48)
            Me.chkCleanMovieTBNb.Name = "chkCleanMovieTBNb"
            Me.chkCleanMovieTBNb.Size = New System.Drawing.Size(97, 17)
            Me.chkCleanMovieTBNb.TabIndex = 2
            Me.chkCleanMovieTBNb.Text = "/<movie>.tbn"
            Me.chkCleanMovieTBNb.UseVisualStyleBackColor = True
            '
            'chkCleanMovieJPG
            '
            Me.chkCleanMovieJPG.AutoSize = True
            Me.chkCleanMovieJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieJPG.Location = New System.Drawing.Point(7, 105)
            Me.chkCleanMovieJPG.Name = "chkCleanMovieJPG"
            Me.chkCleanMovieJPG.Size = New System.Drawing.Size(80, 17)
            Me.chkCleanMovieJPG.TabIndex = 5
            Me.chkCleanMovieJPG.Text = "/movie.jpg"
            Me.chkCleanMovieJPG.UseVisualStyleBackColor = True
            '
            'chkCleanFanartJPG
            '
            Me.chkCleanFanartJPG.AutoSize = True
            Me.chkCleanFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanFanartJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanFanartJPG.Location = New System.Drawing.Point(7, 143)
            Me.chkCleanFanartJPG.Name = "chkCleanFanartJPG"
            Me.chkCleanFanartJPG.Size = New System.Drawing.Size(81, 17)
            Me.chkCleanFanartJPG.TabIndex = 7
            Me.chkCleanFanartJPG.Text = "/fanart.jpg"
            Me.chkCleanFanartJPG.UseVisualStyleBackColor = True
            '
            'chkCleanPosterJPG
            '
            Me.chkCleanPosterJPG.AutoSize = True
            Me.chkCleanPosterJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanPosterJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanPosterJPG.Location = New System.Drawing.Point(7, 86)
            Me.chkCleanPosterJPG.Name = "chkCleanPosterJPG"
            Me.chkCleanPosterJPG.Size = New System.Drawing.Size(83, 17)
            Me.chkCleanPosterJPG.TabIndex = 4
            Me.chkCleanPosterJPG.Text = "/poster.jpg"
            Me.chkCleanPosterJPG.UseVisualStyleBackColor = True
            '
            'chkCleanMovieFanartJPG
            '
            Me.chkCleanMovieFanartJPG.AutoSize = True
            Me.chkCleanMovieFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieFanartJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieFanartJPG.Location = New System.Drawing.Point(7, 162)
            Me.chkCleanMovieFanartJPG.Name = "chkCleanMovieFanartJPG"
            Me.chkCleanMovieFanartJPG.Size = New System.Drawing.Size(131, 17)
            Me.chkCleanMovieFanartJPG.TabIndex = 8
            Me.chkCleanMovieFanartJPG.Text = "/<movie>-fanart.jpg"
            Me.chkCleanMovieFanartJPG.UseVisualStyleBackColor = True
            '
            'chkCleanPosterTBN
            '
            Me.chkCleanPosterTBN.AutoSize = True
            Me.chkCleanPosterTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanPosterTBN.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanPosterTBN.Location = New System.Drawing.Point(7, 67)
            Me.chkCleanPosterTBN.Name = "chkCleanPosterTBN"
            Me.chkCleanPosterTBN.Size = New System.Drawing.Size(84, 17)
            Me.chkCleanPosterTBN.TabIndex = 3
            Me.chkCleanPosterTBN.Text = "/poster.tbn"
            Me.chkCleanPosterTBN.UseVisualStyleBackColor = True
            '
            'chkCleanMovieNFO
            '
            Me.chkCleanMovieNFO.AutoSize = True
            Me.chkCleanMovieNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieNFO.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieNFO.Location = New System.Drawing.Point(7, 200)
            Me.chkCleanMovieNFO.Name = "chkCleanMovieNFO"
            Me.chkCleanMovieNFO.Size = New System.Drawing.Size(81, 17)
            Me.chkCleanMovieNFO.TabIndex = 10
            Me.chkCleanMovieNFO.Text = "/movie.nfo"
            Me.chkCleanMovieNFO.UseVisualStyleBackColor = True
            '
            'chkCleanDotFanartJPG
            '
            Me.chkCleanDotFanartJPG.AutoSize = True
            Me.chkCleanDotFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanDotFanartJPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanDotFanartJPG.Location = New System.Drawing.Point(7, 181)
            Me.chkCleanDotFanartJPG.Name = "chkCleanDotFanartJPG"
            Me.chkCleanDotFanartJPG.Size = New System.Drawing.Size(130, 17)
            Me.chkCleanDotFanartJPG.TabIndex = 9
            Me.chkCleanDotFanartJPG.Text = "/<movie>.fanart.jpg"
            Me.chkCleanDotFanartJPG.UseVisualStyleBackColor = True
            '
            'chkCleanMovieNFOb
            '
            Me.chkCleanMovieNFOb.AutoSize = True
            Me.chkCleanMovieNFOb.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkCleanMovieNFOb.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCleanMovieNFOb.Location = New System.Drawing.Point(7, 219)
            Me.chkCleanMovieNFOb.Name = "chkCleanMovieNFOb"
            Me.chkCleanMovieNFOb.Size = New System.Drawing.Size(97, 17)
            Me.chkCleanMovieNFOb.TabIndex = 11
            Me.chkCleanMovieNFOb.Text = "/<movie>.nfo"
            Me.chkCleanMovieNFOb.UseVisualStyleBackColor = True
            '
            'tpExpert
            '
            Me.tpExpert.BackColor = System.Drawing.Color.White
            Me.tpExpert.Controls.Add(Me.chkWhitelistVideo)
            Me.tpExpert.Controls.Add(Me.lblWhitelistExt)
            Me.tpExpert.Controls.Add(Me.btnRemoveWhitelist)
            Me.tpExpert.Controls.Add(Me.btnAddWhitelist)
            Me.tpExpert.Controls.Add(Me.txtWhitelist)
            Me.tpExpert.Controls.Add(Me.lstWhitelist)
            Me.tpExpert.Controls.Add(Me.lblWarning)
            Me.tpExpert.Location = New System.Drawing.Point(4, 22)
            Me.tpExpert.Name = "tpExpert"
            Me.tpExpert.Padding = New System.Windows.Forms.Padding(3)
            Me.tpExpert.Size = New System.Drawing.Size(188, 337)
            Me.tpExpert.TabIndex = 1
            Me.tpExpert.Text = Global.EmberMediaManger.Languages.Expert
            Me.tpExpert.UseVisualStyleBackColor = True
            '
            'chkWhitelistVideo
            '
            Me.chkWhitelistVideo.AutoSize = True
            Me.chkWhitelistVideo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkWhitelistVideo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkWhitelistVideo.Location = New System.Drawing.Point(4, 85)
            Me.chkWhitelistVideo.Name = "chkWhitelistVideo"
            Me.chkWhitelistVideo.Size = New System.Drawing.Size(163, 17)
            Me.chkWhitelistVideo.TabIndex = 0
            Me.chkWhitelistVideo.Text = Global.EmberMediaManger.Languages.Whitelist_Video_Extensions
            Me.chkWhitelistVideo.UseVisualStyleBackColor = True
            '
            'lblWhitelistExt
            '
            Me.lblWhitelistExt.AutoSize = True
            Me.lblWhitelistExt.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.lblWhitelistExt.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWhitelistExt.Location = New System.Drawing.Point(19, 107)
            Me.lblWhitelistExt.Name = "lblWhitelistExt"
            Me.lblWhitelistExt.Size = New System.Drawing.Size(127, 13)
            Me.lblWhitelistExt.TabIndex = 10
            Me.lblWhitelistExt.Text = "Whitelisted Extensions:"
            '
            'btnRemoveWhitelist
            '
            Me.btnRemoveWhitelist.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveWhitelist.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnRemoveWhitelist.Location = New System.Drawing.Point(134, 251)
            Me.btnRemoveWhitelist.Name = "btnRemoveWhitelist"
            Me.btnRemoveWhitelist.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveWhitelist.TabIndex = 4
            Me.btnRemoveWhitelist.UseVisualStyleBackColor = True
            '
            'btnAddWhitelist
            '
            Me.btnAddWhitelist.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddWhitelist.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnAddWhitelist.Location = New System.Drawing.Point(82, 251)
            Me.btnAddWhitelist.Name = "btnAddWhitelist"
            Me.btnAddWhitelist.Size = New System.Drawing.Size(23, 23)
            Me.btnAddWhitelist.TabIndex = 3
            Me.btnAddWhitelist.UseVisualStyleBackColor = True
            '
            'txtWhitelist
            '
            Me.txtWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.txtWhitelist.Location = New System.Drawing.Point(20, 252)
            Me.txtWhitelist.Name = "txtWhitelist"
            Me.txtWhitelist.Size = New System.Drawing.Size(61, 22)
            Me.txtWhitelist.TabIndex = 2
            '
            'lstWhitelist
            '
            Me.lstWhitelist.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.lstWhitelist.FormattingEnabled = True
            Me.lstWhitelist.Location = New System.Drawing.Point(19, 126)
            Me.lstWhitelist.Name = "lstWhitelist"
            Me.lstWhitelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstWhitelist.Size = New System.Drawing.Size(138, 108)
            Me.lstWhitelist.TabIndex = 1
            '
            'lblWarning
            '
            Me.lblWarning.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblWarning.ForeColor = System.Drawing.Color.Red
            Me.lblWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblWarning.Location = New System.Drawing.Point(12, 10)
            Me.lblWarning.Name = "lblWarning"
            Me.lblWarning.Size = New System.Drawing.Size(155, 68)
            Me.lblWarning.TabIndex = 0
            Me.lblWarning.Text = "WARNING: Using the Expert Mode Cleaner could potentially delete wanted files. Tak" & _
        "e care when using this tool."
            Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'gbValidVideoExt
            '
            Me.gbValidVideoExt.Controls.Add(Me.btnResetValidExts)
            Me.gbValidVideoExt.Controls.Add(Me.btnRemMovieExt)
            Me.gbValidVideoExt.Controls.Add(Me.btnAddMovieExt)
            Me.gbValidVideoExt.Controls.Add(Me.txtMovieExt)
            Me.gbValidVideoExt.Controls.Add(Me.lstMovieExts)
            Me.gbValidVideoExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbValidVideoExt.Location = New System.Drawing.Point(3, 6)
            Me.gbValidVideoExt.Name = "gbValidVideoExt"
            Me.gbValidVideoExt.Size = New System.Drawing.Size(192, 385)
            Me.gbValidVideoExt.TabIndex = 4
            Me.gbValidVideoExt.TabStop = False
            Me.gbValidVideoExt.Text = "Valid Video Extensions"
            '
            'btnResetValidExts
            '
            Me.btnResetValidExts.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnResetValidExts.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnResetValidExts.Location = New System.Drawing.Point(164, 12)
            Me.btnResetValidExts.Name = "btnResetValidExts"
            Me.btnResetValidExts.Size = New System.Drawing.Size(23, 23)
            Me.btnResetValidExts.TabIndex = 9
            Me.btnResetValidExts.UseVisualStyleBackColor = True
            '
            'btnRemMovieExt
            '
            Me.btnRemMovieExt.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemMovieExt.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnRemMovieExt.Location = New System.Drawing.Point(163, 356)
            Me.btnRemMovieExt.Name = "btnRemMovieExt"
            Me.btnRemMovieExt.Size = New System.Drawing.Size(23, 23)
            Me.btnRemMovieExt.TabIndex = 3
            Me.btnRemMovieExt.UseVisualStyleBackColor = True
            '
            'btnAddMovieExt
            '
            Me.btnAddMovieExt.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddMovieExt.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.btnAddMovieExt.Location = New System.Drawing.Point(68, 356)
            Me.btnAddMovieExt.Name = "btnAddMovieExt"
            Me.btnAddMovieExt.Size = New System.Drawing.Size(23, 23)
            Me.btnAddMovieExt.TabIndex = 2
            Me.btnAddMovieExt.UseVisualStyleBackColor = True
            '
            'txtMovieExt
            '
            Me.txtMovieExt.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.txtMovieExt.Location = New System.Drawing.Point(6, 357)
            Me.txtMovieExt.Name = "txtMovieExt"
            Me.txtMovieExt.Size = New System.Drawing.Size(61, 22)
            Me.txtMovieExt.TabIndex = 1
            Me.txtMovieExt.Tag = "IGNORE"
            '
            'lstMovieExts
            '
            Me.lstMovieExts.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.lstMovieExts.FormattingEnabled = True
            Me.lstMovieExts.Location = New System.Drawing.Point(6, 37)
            Me.lstMovieExts.Name = "lstMovieExts"
            Me.lstMovieExts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstMovieExts.Size = New System.Drawing.Size(180, 303)
            Me.lstMovieExts.Sorted = True
            Me.lstMovieExts.TabIndex = 0
            '
            'Extensions
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbNoStackExt)
            Me.Controls.Add(Me.gbCleanFiles)
            Me.Controls.Add(Me.gbValidVideoExt)
            Me.Name = "Extensions"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_File
            Me.PanelOrder = 200
            Me.PanelText = "File System"
            Me.PanelType = "Options"
            Me.gbNoStackExt.ResumeLayout(False)
            Me.gbNoStackExt.PerformLayout()
            Me.gbCleanFiles.ResumeLayout(False)
            Me.tcCleaner.ResumeLayout(False)
            Me.tpStandard.ResumeLayout(False)
            Me.tpStandard.PerformLayout()
            Me.tpExpert.ResumeLayout(False)
            Me.tpExpert.PerformLayout()
            Me.gbValidVideoExt.ResumeLayout(False)
            Me.gbValidVideoExt.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbNoStackExt As System.Windows.Forms.GroupBox
        Friend WithEvents btnRemoveNoStack As System.Windows.Forms.Button
        Friend WithEvents btnAddNoStack As System.Windows.Forms.Button
        Friend WithEvents txtNoStack As System.Windows.Forms.TextBox
        Friend WithEvents lstNoStack As System.Windows.Forms.ListBox
        Friend WithEvents gbCleanFiles As System.Windows.Forms.GroupBox
        Friend WithEvents tcCleaner As System.Windows.Forms.TabControl
        Friend WithEvents tpStandard As System.Windows.Forms.TabPage
        Friend WithEvents chkCleanFolderJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanExtrathumbs As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieNameJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieTBNb As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanPosterJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanPosterTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieNFO As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanDotFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanMovieNFOb As System.Windows.Forms.CheckBox
        Friend WithEvents tpExpert As System.Windows.Forms.TabPage
        Friend WithEvents chkWhitelistVideo As System.Windows.Forms.CheckBox
        Friend WithEvents lblWhitelistExt As System.Windows.Forms.Label
        Friend WithEvents btnRemoveWhitelist As System.Windows.Forms.Button
        Friend WithEvents btnAddWhitelist As System.Windows.Forms.Button
        Friend WithEvents txtWhitelist As System.Windows.Forms.TextBox
        Friend WithEvents lstWhitelist As System.Windows.Forms.ListBox
        Friend WithEvents lblWarning As System.Windows.Forms.Label
        Friend WithEvents gbValidVideoExt As System.Windows.Forms.GroupBox
        Friend WithEvents btnResetValidExts As System.Windows.Forms.Button
        Friend WithEvents btnRemMovieExt As System.Windows.Forms.Button
        Friend WithEvents btnAddMovieExt As System.Windows.Forms.Button
        Friend WithEvents txtMovieExt As System.Windows.Forms.TextBox
        Friend WithEvents lstMovieExts As System.Windows.Forms.ListBox

    End Class
End Namespace