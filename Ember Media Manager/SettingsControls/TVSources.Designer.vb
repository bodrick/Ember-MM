Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TVSources
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
            Me.TabControl2 = New System.Windows.Forms.TabControl()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.lvTVSources = New System.Windows.Forms.ListView()
            Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.gbMiscTVSourceOpts = New System.Windows.Forms.GroupBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtTVSkipLessThan = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.chkTVScanOrderModify = New System.Windows.Forms.CheckBox()
            Me.chkTVIgnoreLastScan = New System.Windows.Forms.CheckBox()
            Me.chkTVCleanDB = New System.Windows.Forms.CheckBox()
            Me.btnAddTVSource = New System.Windows.Forms.Button()
            Me.btnEditTVSource = New System.Windows.Forms.Button()
            Me.btnRemTVSource = New System.Windows.Forms.Button()
            Me.gbTVNaming = New System.Windows.Forms.GroupBox()
            Me.gbShowBanner = New System.Windows.Forms.GroupBox()
            Me.chkShowBannerJPG = New System.Windows.Forms.CheckBox()
            Me.gbAllSeasonPoster = New System.Windows.Forms.GroupBox()
            Me.chkSeasonAllJPG = New System.Windows.Forms.CheckBox()
            Me.chkSeasonAllTBN = New System.Windows.Forms.CheckBox()
            Me.gbEpisodeFanart = New System.Windows.Forms.GroupBox()
            Me.chkEpisodeDotFanart = New System.Windows.Forms.CheckBox()
            Me.chkEpisodeDashFanart = New System.Windows.Forms.CheckBox()
            Me.gbEpisodePosters = New System.Windows.Forms.GroupBox()
            Me.chkEpisodeJPG = New System.Windows.Forms.CheckBox()
            Me.chkEpisodeTBN = New System.Windows.Forms.CheckBox()
            Me.gbSeasonFanart = New System.Windows.Forms.GroupBox()
            Me.chkSeasonDotFanart = New System.Windows.Forms.CheckBox()
            Me.chkSeasonDashFanart = New System.Windows.Forms.CheckBox()
            Me.chkSeasonFanartJPG = New System.Windows.Forms.CheckBox()
            Me.gbSeasonPosters = New System.Windows.Forms.GroupBox()
            Me.chkSeasonFolderJPG = New System.Windows.Forms.CheckBox()
            Me.chkSeasonNameJPG = New System.Windows.Forms.CheckBox()
            Me.chkSeasonNameTBN = New System.Windows.Forms.CheckBox()
            Me.chkSeasonPosterJPG = New System.Windows.Forms.CheckBox()
            Me.chkSeasonPosterTBN = New System.Windows.Forms.CheckBox()
            Me.chkSeasonXTBN = New System.Windows.Forms.CheckBox()
            Me.chkSeasonXXTBN = New System.Windows.Forms.CheckBox()
            Me.gbShowFanart = New System.Windows.Forms.GroupBox()
            Me.chkShowDotFanart = New System.Windows.Forms.CheckBox()
            Me.chkShowDashFanart = New System.Windows.Forms.CheckBox()
            Me.chkShowFanartJPG = New System.Windows.Forms.CheckBox()
            Me.gbShowPosters = New System.Windows.Forms.GroupBox()
            Me.chkShowJPG = New System.Windows.Forms.CheckBox()
            Me.chkShowTBN = New System.Windows.Forms.CheckBox()
            Me.chkShowPosterJPG = New System.Windows.Forms.CheckBox()
            Me.chkShowPosterTBN = New System.Windows.Forms.CheckBox()
            Me.chkShowFolderJPG = New System.Windows.Forms.CheckBox()
            Me.TabPage6 = New System.Windows.Forms.TabPage()
            Me.btnGetTVProfiles = New System.Windows.Forms.Button()
            Me.btnRegexDown = New System.Windows.Forms.Button()
            Me.btnRegexUp = New System.Windows.Forms.Button()
            Me.btnResetShowRegex = New System.Windows.Forms.Button()
            Me.gbShowRegex = New System.Windows.Forms.GroupBox()
            Me.btnClearRegex = New System.Windows.Forms.Button()
            Me.lblSeasonMatch = New System.Windows.Forms.Label()
            Me.btnAddShowRegex = New System.Windows.Forms.Button()
            Me.txtSeasonRegex = New System.Windows.Forms.TextBox()
            Me.lblEpisodeRetrieve = New System.Windows.Forms.Label()
            Me.cboSeasonRetrieve = New System.Windows.Forms.ComboBox()
            Me.lblSeasonRetrieve = New System.Windows.Forms.Label()
            Me.txtEpRegex = New System.Windows.Forms.TextBox()
            Me.lblEpisodeMatch = New System.Windows.Forms.Label()
            Me.cboEpRetrieve = New System.Windows.Forms.ComboBox()
            Me.btnEditShowRegex = New System.Windows.Forms.Button()
            Me.btnRemoveShowRegex = New System.Windows.Forms.Button()
            Me.lvShowRegex = New System.Windows.Forms.ListView()
            Me.colRegID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colSeason = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colSeasonApply = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colEpisode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colEpApply = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TabControl2.SuspendLayout()
            Me.TabPage5.SuspendLayout()
            Me.gbMiscTVSourceOpts.SuspendLayout()
            Me.gbTVNaming.SuspendLayout()
            Me.gbShowBanner.SuspendLayout()
            Me.gbAllSeasonPoster.SuspendLayout()
            Me.gbEpisodeFanart.SuspendLayout()
            Me.gbEpisodePosters.SuspendLayout()
            Me.gbSeasonFanart.SuspendLayout()
            Me.gbSeasonPosters.SuspendLayout()
            Me.gbShowFanart.SuspendLayout()
            Me.gbShowPosters.SuspendLayout()
            Me.TabPage6.SuspendLayout()
            Me.gbShowRegex.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl2
            '
            Me.TabControl2.Controls.Add(Me.TabPage5)
            Me.TabControl2.Controls.Add(Me.TabPage6)
            Me.TabControl2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.TabControl2.Location = New System.Drawing.Point(0, 3)
            Me.TabControl2.Name = "TabControl2"
            Me.TabControl2.SelectedIndex = 0
            Me.TabControl2.Size = New System.Drawing.Size(612, 392)
            Me.TabControl2.TabIndex = 7
            '
            'TabPage5
            '
            Me.TabPage5.Controls.Add(Me.lvTVSources)
            Me.TabPage5.Controls.Add(Me.gbMiscTVSourceOpts)
            Me.TabPage5.Controls.Add(Me.btnAddTVSource)
            Me.TabPage5.Controls.Add(Me.btnEditTVSource)
            Me.TabPage5.Controls.Add(Me.btnRemTVSource)
            Me.TabPage5.Controls.Add(Me.gbTVNaming)
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage5.Size = New System.Drawing.Size(604, 366)
            Me.TabPage5.TabIndex = 0
            Me.TabPage5.Text = "General"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'lvTVSources
            '
            Me.lvTVSources.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
            Me.lvTVSources.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lvTVSources.FullRowSelect = True
            Me.lvTVSources.HideSelection = False
            Me.lvTVSources.Location = New System.Drawing.Point(6, 4)
            Me.lvTVSources.Name = "lvTVSources"
            Me.lvTVSources.Size = New System.Drawing.Size(483, 105)
            Me.lvTVSources.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvTVSources.TabIndex = 0
            Me.lvTVSources.UseCompatibleStateImageBehavior = False
            Me.lvTVSources.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Width = 0
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "Name"
            Me.ColumnHeader2.Width = 94
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "Path"
            Me.ColumnHeader3.Width = 368
            '
            'gbMiscTVSourceOpts
            '
            Me.gbMiscTVSourceOpts.Controls.Add(Me.Label6)
            Me.gbMiscTVSourceOpts.Controls.Add(Me.txtTVSkipLessThan)
            Me.gbMiscTVSourceOpts.Controls.Add(Me.Label7)
            Me.gbMiscTVSourceOpts.Controls.Add(Me.chkTVScanOrderModify)
            Me.gbMiscTVSourceOpts.Controls.Add(Me.chkTVIgnoreLastScan)
            Me.gbMiscTVSourceOpts.Controls.Add(Me.chkTVCleanDB)
            Me.gbMiscTVSourceOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMiscTVSourceOpts.Location = New System.Drawing.Point(6, 110)
            Me.gbMiscTVSourceOpts.Name = "gbMiscTVSourceOpts"
            Me.gbMiscTVSourceOpts.Size = New System.Drawing.Size(151, 253)
            Me.gbMiscTVSourceOpts.TabIndex = 5
            Me.gbMiscTVSourceOpts.TabStop = False
            Me.gbMiscTVSourceOpts.Text = "Miscellaneous Options"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(114, 39)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(24, 13)
            Me.Label6.TabIndex = 76
            Me.Label6.Text = "MB"
            '
            'txtTVSkipLessThan
            '
            Me.txtTVSkipLessThan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTVSkipLessThan.Location = New System.Drawing.Point(11, 34)
            Me.txtTVSkipLessThan.Name = "txtTVSkipLessThan"
            Me.txtTVSkipLessThan.Size = New System.Drawing.Size(100, 22)
            Me.txtTVSkipLessThan.TabIndex = 74
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(6, 18)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(122, 13)
            Me.Label7.TabIndex = 75
            Me.Label7.Text = "Skip files smaller than:"
            '
            'chkTVScanOrderModify
            '
            Me.chkTVScanOrderModify.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVScanOrderModify.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTVScanOrderModify.Location = New System.Drawing.Point(4, 110)
            Me.chkTVScanOrderModify.Name = "chkTVScanOrderModify"
            Me.chkTVScanOrderModify.Size = New System.Drawing.Size(142, 43)
            Me.chkTVScanOrderModify.TabIndex = 73
            Me.chkTVScanOrderModify.Text = "Scan in order of last write time"
            Me.chkTVScanOrderModify.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVScanOrderModify.UseVisualStyleBackColor = True
            '
            'chkTVIgnoreLastScan
            '
            Me.chkTVIgnoreLastScan.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVIgnoreLastScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTVIgnoreLastScan.Location = New System.Drawing.Point(4, 68)
            Me.chkTVIgnoreLastScan.Name = "chkTVIgnoreLastScan"
            Me.chkTVIgnoreLastScan.Size = New System.Drawing.Size(142, 43)
            Me.chkTVIgnoreLastScan.TabIndex = 72
            Me.chkTVIgnoreLastScan.Text = "Ignore last scan time when updating library"
            Me.chkTVIgnoreLastScan.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVIgnoreLastScan.UseVisualStyleBackColor = True
            '
            'chkTVCleanDB
            '
            Me.chkTVCleanDB.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVCleanDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTVCleanDB.Location = New System.Drawing.Point(4, 152)
            Me.chkTVCleanDB.Name = "chkTVCleanDB"
            Me.chkTVCleanDB.Size = New System.Drawing.Size(142, 43)
            Me.chkTVCleanDB.TabIndex = 71
            Me.chkTVCleanDB.Text = "Clean database after updating library"
            Me.chkTVCleanDB.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkTVCleanDB.UseVisualStyleBackColor = True
            '
            'btnAddTVSource
            '
            Me.btnAddTVSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnAddTVSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_AddFolder
            Me.btnAddTVSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddTVSource.Location = New System.Drawing.Point(494, 4)
            Me.btnAddTVSource.Name = "btnAddTVSource"
            Me.btnAddTVSource.Size = New System.Drawing.Size(104, 23)
            Me.btnAddTVSource.TabIndex = 1
            Me.btnAddTVSource.Tag = "forceupdate"
            Me.btnAddTVSource.Text = "Add Source"
            Me.btnAddTVSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddTVSource.UseVisualStyleBackColor = True
            '
            'btnEditTVSource
            '
            Me.btnEditTVSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnEditTVSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditTVSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditTVSource.Location = New System.Drawing.Point(494, 33)
            Me.btnEditTVSource.Name = "btnEditTVSource"
            Me.btnEditTVSource.Size = New System.Drawing.Size(104, 23)
            Me.btnEditTVSource.TabIndex = 2
            Me.btnEditTVSource.Tag = "forceupdate"
            Me.btnEditTVSource.Text = "Edit Source"
            Me.btnEditTVSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditTVSource.UseVisualStyleBackColor = True
            '
            'btnRemTVSource
            '
            Me.btnRemTVSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnRemTVSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemTVSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemTVSource.Location = New System.Drawing.Point(494, 86)
            Me.btnRemTVSource.Name = "btnRemTVSource"
            Me.btnRemTVSource.Size = New System.Drawing.Size(104, 23)
            Me.btnRemTVSource.TabIndex = 3
            Me.btnRemTVSource.Tag = "forceupdate"
            Me.btnRemTVSource.Text = "Remove"
            Me.btnRemTVSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemTVSource.UseVisualStyleBackColor = True
            '
            'gbTVNaming
            '
            Me.gbTVNaming.Controls.Add(Me.gbShowBanner)
            Me.gbTVNaming.Controls.Add(Me.gbAllSeasonPoster)
            Me.gbTVNaming.Controls.Add(Me.gbEpisodeFanart)
            Me.gbTVNaming.Controls.Add(Me.gbEpisodePosters)
            Me.gbTVNaming.Controls.Add(Me.gbSeasonFanart)
            Me.gbTVNaming.Controls.Add(Me.gbSeasonPosters)
            Me.gbTVNaming.Controls.Add(Me.gbShowFanart)
            Me.gbTVNaming.Controls.Add(Me.gbShowPosters)
            Me.gbTVNaming.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTVNaming.Location = New System.Drawing.Point(161, 110)
            Me.gbTVNaming.Name = "gbTVNaming"
            Me.gbTVNaming.Size = New System.Drawing.Size(437, 253)
            Me.gbTVNaming.TabIndex = 6
            Me.gbTVNaming.TabStop = False
            Me.gbTVNaming.Text = "File Naming"
            '
            'gbShowBanner
            '
            Me.gbShowBanner.Controls.Add(Me.chkShowBannerJPG)
            Me.gbShowBanner.Location = New System.Drawing.Point(292, 150)
            Me.gbShowBanner.Name = "gbShowBanner"
            Me.gbShowBanner.Size = New System.Drawing.Size(140, 71)
            Me.gbShowBanner.TabIndex = 9
            Me.gbShowBanner.TabStop = False
            Me.gbShowBanner.Text = "Show Banner"
            '
            'chkShowBannerJPG
            '
            Me.chkShowBannerJPG.AutoSize = True
            Me.chkShowBannerJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.chkShowBannerJPG.Location = New System.Drawing.Point(6, 15)
            Me.chkShowBannerJPG.Name = "chkShowBannerJPG"
            Me.chkShowBannerJPG.Size = New System.Drawing.Size(83, 17)
            Me.chkShowBannerJPG.TabIndex = 0
            Me.chkShowBannerJPG.Text = "banner.jpg"
            Me.chkShowBannerJPG.UseVisualStyleBackColor = True
            '
            'gbAllSeasonPoster
            '
            Me.gbAllSeasonPoster.Controls.Add(Me.chkSeasonAllJPG)
            Me.gbAllSeasonPoster.Controls.Add(Me.chkSeasonAllTBN)
            Me.gbAllSeasonPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbAllSeasonPoster.Location = New System.Drawing.Point(5, 195)
            Me.gbAllSeasonPoster.Name = "gbAllSeasonPoster"
            Me.gbAllSeasonPoster.Size = New System.Drawing.Size(133, 54)
            Me.gbAllSeasonPoster.TabIndex = 8
            Me.gbAllSeasonPoster.TabStop = False
            Me.gbAllSeasonPoster.Text = "All Season Posters"
            '
            'chkSeasonAllJPG
            '
            Me.chkSeasonAllJPG.AutoSize = True
            Me.chkSeasonAllJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonAllJPG.Location = New System.Drawing.Point(6, 34)
            Me.chkSeasonAllJPG.Name = "chkSeasonAllJPG"
            Me.chkSeasonAllJPG.Size = New System.Drawing.Size(98, 17)
            Me.chkSeasonAllJPG.TabIndex = 1
            Me.chkSeasonAllJPG.Text = "season-all.jpg"
            Me.chkSeasonAllJPG.UseVisualStyleBackColor = True
            '
            'chkSeasonAllTBN
            '
            Me.chkSeasonAllTBN.AutoSize = True
            Me.chkSeasonAllTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonAllTBN.Location = New System.Drawing.Point(6, 18)
            Me.chkSeasonAllTBN.Name = "chkSeasonAllTBN"
            Me.chkSeasonAllTBN.Size = New System.Drawing.Size(99, 17)
            Me.chkSeasonAllTBN.TabIndex = 0
            Me.chkSeasonAllTBN.Text = "season-all.tbn"
            Me.chkSeasonAllTBN.UseVisualStyleBackColor = True
            '
            'gbEpisodeFanart
            '
            Me.gbEpisodeFanart.Controls.Add(Me.chkEpisodeDotFanart)
            Me.gbEpisodeFanart.Controls.Add(Me.chkEpisodeDashFanart)
            Me.gbEpisodeFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbEpisodeFanart.Location = New System.Drawing.Point(292, 67)
            Me.gbEpisodeFanart.Name = "gbEpisodeFanart"
            Me.gbEpisodeFanart.Size = New System.Drawing.Size(140, 52)
            Me.gbEpisodeFanart.TabIndex = 4
            Me.gbEpisodeFanart.TabStop = False
            Me.gbEpisodeFanart.Text = "Episode Fanart"
            '
            'chkEpisodeDotFanart
            '
            Me.chkEpisodeDotFanart.AutoSize = True
            Me.chkEpisodeDotFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeDotFanart.Location = New System.Drawing.Point(5, 31)
            Me.chkEpisodeDotFanart.Name = "chkEpisodeDotFanart"
            Me.chkEpisodeDotFanart.Size = New System.Drawing.Size(137, 17)
            Me.chkEpisodeDotFanart.TabIndex = 2
            Me.chkEpisodeDotFanart.Text = "<episode>.fanart.jpg"
            Me.chkEpisodeDotFanart.UseVisualStyleBackColor = True
            '
            'chkEpisodeDashFanart
            '
            Me.chkEpisodeDashFanart.AutoSize = True
            Me.chkEpisodeDashFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeDashFanart.Location = New System.Drawing.Point(5, 15)
            Me.chkEpisodeDashFanart.Name = "chkEpisodeDashFanart"
            Me.chkEpisodeDashFanart.Size = New System.Drawing.Size(138, 17)
            Me.chkEpisodeDashFanart.TabIndex = 1
            Me.chkEpisodeDashFanart.Text = "<episode>-fanart.jpg"
            Me.chkEpisodeDashFanart.UseVisualStyleBackColor = True
            '
            'gbEpisodePosters
            '
            Me.gbEpisodePosters.Controls.Add(Me.chkEpisodeJPG)
            Me.gbEpisodePosters.Controls.Add(Me.chkEpisodeTBN)
            Me.gbEpisodePosters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbEpisodePosters.Location = New System.Drawing.Point(292, 15)
            Me.gbEpisodePosters.Name = "gbEpisodePosters"
            Me.gbEpisodePosters.Size = New System.Drawing.Size(140, 52)
            Me.gbEpisodePosters.TabIndex = 6
            Me.gbEpisodePosters.TabStop = False
            Me.gbEpisodePosters.Text = "Episode Posters"
            '
            'chkEpisodeJPG
            '
            Me.chkEpisodeJPG.AutoSize = True
            Me.chkEpisodeJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeJPG.Location = New System.Drawing.Point(6, 31)
            Me.chkEpisodeJPG.Name = "chkEpisodeJPG"
            Me.chkEpisodeJPG.Size = New System.Drawing.Size(103, 17)
            Me.chkEpisodeJPG.TabIndex = 1
            Me.chkEpisodeJPG.Text = "<episode>.jpg"
            Me.chkEpisodeJPG.UseVisualStyleBackColor = True
            '
            'chkEpisodeTBN
            '
            Me.chkEpisodeTBN.AutoSize = True
            Me.chkEpisodeTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeTBN.Location = New System.Drawing.Point(6, 15)
            Me.chkEpisodeTBN.Name = "chkEpisodeTBN"
            Me.chkEpisodeTBN.Size = New System.Drawing.Size(104, 17)
            Me.chkEpisodeTBN.TabIndex = 0
            Me.chkEpisodeTBN.Text = "<episode>.tbn"
            Me.chkEpisodeTBN.UseVisualStyleBackColor = True
            '
            'gbSeasonFanart
            '
            Me.gbSeasonFanart.Controls.Add(Me.chkSeasonDotFanart)
            Me.gbSeasonFanart.Controls.Add(Me.chkSeasonDashFanart)
            Me.gbSeasonFanart.Controls.Add(Me.chkSeasonFanartJPG)
            Me.gbSeasonFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbSeasonFanart.Location = New System.Drawing.Point(144, 150)
            Me.gbSeasonFanart.Name = "gbSeasonFanart"
            Me.gbSeasonFanart.Size = New System.Drawing.Size(145, 71)
            Me.gbSeasonFanart.TabIndex = 3
            Me.gbSeasonFanart.TabStop = False
            Me.gbSeasonFanart.Text = "Season Fanart"
            '
            'chkSeasonDotFanart
            '
            Me.chkSeasonDotFanart.AutoSize = True
            Me.chkSeasonDotFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonDotFanart.Location = New System.Drawing.Point(6, 47)
            Me.chkSeasonDotFanart.Name = "chkSeasonDotFanart"
            Me.chkSeasonDotFanart.Size = New System.Drawing.Size(132, 17)
            Me.chkSeasonDotFanart.TabIndex = 2
            Me.chkSeasonDotFanart.Text = "<season>.fanart.jpg"
            Me.chkSeasonDotFanart.UseVisualStyleBackColor = True
            '
            'chkSeasonDashFanart
            '
            Me.chkSeasonDashFanart.AutoSize = True
            Me.chkSeasonDashFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonDashFanart.Location = New System.Drawing.Point(6, 31)
            Me.chkSeasonDashFanart.Name = "chkSeasonDashFanart"
            Me.chkSeasonDashFanart.Size = New System.Drawing.Size(133, 17)
            Me.chkSeasonDashFanart.TabIndex = 1
            Me.chkSeasonDashFanart.Text = "<season>-fanart.jpg"
            Me.chkSeasonDashFanart.UseVisualStyleBackColor = True
            '
            'chkSeasonFanartJPG
            '
            Me.chkSeasonFanartJPG.AutoSize = True
            Me.chkSeasonFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonFanartJPG.Location = New System.Drawing.Point(6, 15)
            Me.chkSeasonFanartJPG.Name = "chkSeasonFanartJPG"
            Me.chkSeasonFanartJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkSeasonFanartJPG.TabIndex = 0
            Me.chkSeasonFanartJPG.Text = "fanart.jpg"
            Me.chkSeasonFanartJPG.UseVisualStyleBackColor = True
            '
            'gbSeasonPosters
            '
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonFolderJPG)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonNameJPG)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonNameTBN)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonPosterJPG)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonPosterTBN)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonXTBN)
            Me.gbSeasonPosters.Controls.Add(Me.chkSeasonXXTBN)
            Me.gbSeasonPosters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbSeasonPosters.Location = New System.Drawing.Point(143, 15)
            Me.gbSeasonPosters.Name = "gbSeasonPosters"
            Me.gbSeasonPosters.Size = New System.Drawing.Size(145, 130)
            Me.gbSeasonPosters.TabIndex = 4
            Me.gbSeasonPosters.TabStop = False
            Me.gbSeasonPosters.Text = "Season Posters"
            '
            'chkSeasonFolderJPG
            '
            Me.chkSeasonFolderJPG.AutoSize = True
            Me.chkSeasonFolderJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonFolderJPG.Location = New System.Drawing.Point(6, 111)
            Me.chkSeasonFolderJPG.Name = "chkSeasonFolderJPG"
            Me.chkSeasonFolderJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkSeasonFolderJPG.TabIndex = 6
            Me.chkSeasonFolderJPG.Text = "folder.jpg"
            Me.chkSeasonFolderJPG.UseVisualStyleBackColor = True
            '
            'chkSeasonNameJPG
            '
            Me.chkSeasonNameJPG.AutoSize = True
            Me.chkSeasonNameJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonNameJPG.Location = New System.Drawing.Point(6, 95)
            Me.chkSeasonNameJPG.Name = "chkSeasonNameJPG"
            Me.chkSeasonNameJPG.Size = New System.Drawing.Size(98, 17)
            Me.chkSeasonNameJPG.TabIndex = 5
            Me.chkSeasonNameJPG.Text = "<season>.jpg"
            Me.chkSeasonNameJPG.UseVisualStyleBackColor = True
            '
            'chkSeasonNameTBN
            '
            Me.chkSeasonNameTBN.AutoSize = True
            Me.chkSeasonNameTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonNameTBN.Location = New System.Drawing.Point(6, 79)
            Me.chkSeasonNameTBN.Name = "chkSeasonNameTBN"
            Me.chkSeasonNameTBN.Size = New System.Drawing.Size(99, 17)
            Me.chkSeasonNameTBN.TabIndex = 4
            Me.chkSeasonNameTBN.Text = "<season>.tbn"
            Me.chkSeasonNameTBN.UseVisualStyleBackColor = True
            '
            'chkSeasonPosterJPG
            '
            Me.chkSeasonPosterJPG.AutoSize = True
            Me.chkSeasonPosterJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonPosterJPG.Location = New System.Drawing.Point(6, 63)
            Me.chkSeasonPosterJPG.Name = "chkSeasonPosterJPG"
            Me.chkSeasonPosterJPG.Size = New System.Drawing.Size(79, 17)
            Me.chkSeasonPosterJPG.TabIndex = 3
            Me.chkSeasonPosterJPG.Text = "poster.jpg"
            Me.chkSeasonPosterJPG.UseVisualStyleBackColor = True
            '
            'chkSeasonPosterTBN
            '
            Me.chkSeasonPosterTBN.AutoSize = True
            Me.chkSeasonPosterTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonPosterTBN.Location = New System.Drawing.Point(6, 47)
            Me.chkSeasonPosterTBN.Name = "chkSeasonPosterTBN"
            Me.chkSeasonPosterTBN.Size = New System.Drawing.Size(80, 17)
            Me.chkSeasonPosterTBN.TabIndex = 2
            Me.chkSeasonPosterTBN.Text = "poster.tbn"
            Me.chkSeasonPosterTBN.UseVisualStyleBackColor = True
            '
            'chkSeasonXTBN
            '
            Me.chkSeasonXTBN.AutoSize = True
            Me.chkSeasonXTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonXTBN.Location = New System.Drawing.Point(6, 31)
            Me.chkSeasonXTBN.Name = "chkSeasonXTBN"
            Me.chkSeasonXTBN.Size = New System.Drawing.Size(89, 17)
            Me.chkSeasonXTBN.TabIndex = 1
            Me.chkSeasonXTBN.Text = "seasonX.tbn"
            Me.chkSeasonXTBN.UseVisualStyleBackColor = True
            '
            'chkSeasonXXTBN
            '
            Me.chkSeasonXXTBN.AutoSize = True
            Me.chkSeasonXXTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonXXTBN.Location = New System.Drawing.Point(6, 15)
            Me.chkSeasonXXTBN.Name = "chkSeasonXXTBN"
            Me.chkSeasonXXTBN.Size = New System.Drawing.Size(95, 17)
            Me.chkSeasonXXTBN.TabIndex = 0
            Me.chkSeasonXXTBN.Text = "seasonXX.tbn"
            Me.chkSeasonXXTBN.UseVisualStyleBackColor = True
            '
            'gbShowFanart
            '
            Me.gbShowFanart.Controls.Add(Me.chkShowDotFanart)
            Me.gbShowFanart.Controls.Add(Me.chkShowDashFanart)
            Me.gbShowFanart.Controls.Add(Me.chkShowFanartJPG)
            Me.gbShowFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbShowFanart.Location = New System.Drawing.Point(5, 120)
            Me.gbShowFanart.Name = "gbShowFanart"
            Me.gbShowFanart.Size = New System.Drawing.Size(133, 70)
            Me.gbShowFanart.TabIndex = 2
            Me.gbShowFanart.TabStop = False
            Me.gbShowFanart.Text = "Show Fanart"
            '
            'chkShowDotFanart
            '
            Me.chkShowDotFanart.AutoSize = True
            Me.chkShowDotFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowDotFanart.Location = New System.Drawing.Point(6, 51)
            Me.chkShowDotFanart.Name = "chkShowDotFanart"
            Me.chkShowDotFanart.Size = New System.Drawing.Size(124, 17)
            Me.chkShowDotFanart.TabIndex = 2
            Me.chkShowDotFanart.Text = "<show>.fanart.jpg"
            Me.chkShowDotFanart.UseVisualStyleBackColor = True
            '
            'chkShowDashFanart
            '
            Me.chkShowDashFanart.AutoSize = True
            Me.chkShowDashFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowDashFanart.Location = New System.Drawing.Point(6, 35)
            Me.chkShowDashFanart.Name = "chkShowDashFanart"
            Me.chkShowDashFanart.Size = New System.Drawing.Size(125, 17)
            Me.chkShowDashFanart.TabIndex = 1
            Me.chkShowDashFanart.Text = "<show>-fanart.jpg"
            Me.chkShowDashFanart.UseVisualStyleBackColor = True
            '
            'chkShowFanartJPG
            '
            Me.chkShowFanartJPG.AutoSize = True
            Me.chkShowFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowFanartJPG.Location = New System.Drawing.Point(6, 19)
            Me.chkShowFanartJPG.Name = "chkShowFanartJPG"
            Me.chkShowFanartJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkShowFanartJPG.TabIndex = 0
            Me.chkShowFanartJPG.Text = "fanart.jpg"
            Me.chkShowFanartJPG.UseVisualStyleBackColor = True
            '
            'gbShowPosters
            '
            Me.gbShowPosters.Controls.Add(Me.chkShowJPG)
            Me.gbShowPosters.Controls.Add(Me.chkShowTBN)
            Me.gbShowPosters.Controls.Add(Me.chkShowPosterJPG)
            Me.gbShowPosters.Controls.Add(Me.chkShowPosterTBN)
            Me.gbShowPosters.Controls.Add(Me.chkShowFolderJPG)
            Me.gbShowPosters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbShowPosters.Location = New System.Drawing.Point(5, 15)
            Me.gbShowPosters.Name = "gbShowPosters"
            Me.gbShowPosters.Size = New System.Drawing.Size(133, 99)
            Me.gbShowPosters.TabIndex = 0
            Me.gbShowPosters.TabStop = False
            Me.gbShowPosters.Text = "Show Posters"
            '
            'chkShowJPG
            '
            Me.chkShowJPG.AutoSize = True
            Me.chkShowJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowJPG.Location = New System.Drawing.Point(6, 32)
            Me.chkShowJPG.Name = "chkShowJPG"
            Me.chkShowJPG.Size = New System.Drawing.Size(90, 17)
            Me.chkShowJPG.TabIndex = 5
            Me.chkShowJPG.Text = "<show>.jpg"
            Me.chkShowJPG.UseVisualStyleBackColor = True
            '
            'chkShowTBN
            '
            Me.chkShowTBN.AutoSize = True
            Me.chkShowTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowTBN.Location = New System.Drawing.Point(6, 16)
            Me.chkShowTBN.Name = "chkShowTBN"
            Me.chkShowTBN.Size = New System.Drawing.Size(91, 17)
            Me.chkShowTBN.TabIndex = 4
            Me.chkShowTBN.Text = "<show>.tbn"
            Me.chkShowTBN.UseVisualStyleBackColor = True
            '
            'chkShowPosterJPG
            '
            Me.chkShowPosterJPG.AutoSize = True
            Me.chkShowPosterJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowPosterJPG.Location = New System.Drawing.Point(6, 64)
            Me.chkShowPosterJPG.Name = "chkShowPosterJPG"
            Me.chkShowPosterJPG.Size = New System.Drawing.Size(79, 17)
            Me.chkShowPosterJPG.TabIndex = 3
            Me.chkShowPosterJPG.Text = "poster.jpg"
            Me.chkShowPosterJPG.UseVisualStyleBackColor = True
            '
            'chkShowPosterTBN
            '
            Me.chkShowPosterTBN.AutoSize = True
            Me.chkShowPosterTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowPosterTBN.Location = New System.Drawing.Point(6, 48)
            Me.chkShowPosterTBN.Name = "chkShowPosterTBN"
            Me.chkShowPosterTBN.Size = New System.Drawing.Size(80, 17)
            Me.chkShowPosterTBN.TabIndex = 2
            Me.chkShowPosterTBN.Text = "poster.tbn"
            Me.chkShowPosterTBN.UseVisualStyleBackColor = True
            '
            'chkShowFolderJPG
            '
            Me.chkShowFolderJPG.AutoSize = True
            Me.chkShowFolderJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowFolderJPG.Location = New System.Drawing.Point(6, 80)
            Me.chkShowFolderJPG.Name = "chkShowFolderJPG"
            Me.chkShowFolderJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkShowFolderJPG.TabIndex = 1
            Me.chkShowFolderJPG.Text = "folder.jpg"
            Me.chkShowFolderJPG.UseVisualStyleBackColor = True
            '
            'TabPage6
            '
            Me.TabPage6.Controls.Add(Me.btnGetTVProfiles)
            Me.TabPage6.Controls.Add(Me.btnRegexDown)
            Me.TabPage6.Controls.Add(Me.btnRegexUp)
            Me.TabPage6.Controls.Add(Me.btnResetShowRegex)
            Me.TabPage6.Controls.Add(Me.gbShowRegex)
            Me.TabPage6.Controls.Add(Me.btnEditShowRegex)
            Me.TabPage6.Controls.Add(Me.btnRemoveShowRegex)
            Me.TabPage6.Controls.Add(Me.lvShowRegex)
            Me.TabPage6.Location = New System.Drawing.Point(4, 22)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage6.Size = New System.Drawing.Size(604, 366)
            Me.TabPage6.TabIndex = 1
            Me.TabPage6.Text = "Regex"
            Me.TabPage6.UseVisualStyleBackColor = True
            '
            'btnGetTVProfiles
            '
            Me.btnGetTVProfiles.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Download
            Me.btnGetTVProfiles.Location = New System.Drawing.Point(550, 3)
            Me.btnGetTVProfiles.Name = "btnGetTVProfiles"
            Me.btnGetTVProfiles.Size = New System.Drawing.Size(23, 23)
            Me.btnGetTVProfiles.TabIndex = 19
            Me.btnGetTVProfiles.UseVisualStyleBackColor = True
            '
            'btnRegexDown
            '
            Me.btnRegexDown.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Down
            Me.btnRegexDown.Location = New System.Drawing.Point(304, 167)
            Me.btnRegexDown.Name = "btnRegexDown"
            Me.btnRegexDown.Size = New System.Drawing.Size(23, 23)
            Me.btnRegexDown.TabIndex = 18
            Me.btnRegexDown.UseVisualStyleBackColor = True
            '
            'btnRegexUp
            '
            Me.btnRegexUp.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Up
            Me.btnRegexUp.Location = New System.Drawing.Point(280, 167)
            Me.btnRegexUp.Name = "btnRegexUp"
            Me.btnRegexUp.Size = New System.Drawing.Size(23, 23)
            Me.btnRegexUp.TabIndex = 17
            Me.btnRegexUp.UseVisualStyleBackColor = True
            '
            'btnResetShowRegex
            '
            Me.btnResetShowRegex.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnResetShowRegex.Location = New System.Drawing.Point(576, 3)
            Me.btnResetShowRegex.Name = "btnResetShowRegex"
            Me.btnResetShowRegex.Size = New System.Drawing.Size(23, 23)
            Me.btnResetShowRegex.TabIndex = 16
            Me.btnResetShowRegex.UseVisualStyleBackColor = True
            '
            'gbShowRegex
            '
            Me.gbShowRegex.Controls.Add(Me.btnClearRegex)
            Me.gbShowRegex.Controls.Add(Me.lblSeasonMatch)
            Me.gbShowRegex.Controls.Add(Me.btnAddShowRegex)
            Me.gbShowRegex.Controls.Add(Me.txtSeasonRegex)
            Me.gbShowRegex.Controls.Add(Me.lblEpisodeRetrieve)
            Me.gbShowRegex.Controls.Add(Me.cboSeasonRetrieve)
            Me.gbShowRegex.Controls.Add(Me.lblSeasonRetrieve)
            Me.gbShowRegex.Controls.Add(Me.txtEpRegex)
            Me.gbShowRegex.Controls.Add(Me.lblEpisodeMatch)
            Me.gbShowRegex.Controls.Add(Me.cboEpRetrieve)
            Me.gbShowRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbShowRegex.Location = New System.Drawing.Point(6, 196)
            Me.gbShowRegex.Name = "gbShowRegex"
            Me.gbShowRegex.Size = New System.Drawing.Size(592, 148)
            Me.gbShowRegex.TabIndex = 15
            Me.gbShowRegex.TabStop = False
            Me.gbShowRegex.Text = "Show Match Regex"
            '
            'btnClearRegex
            '
            Me.btnClearRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnClearRegex.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Clear
            Me.btnClearRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnClearRegex.Location = New System.Drawing.Point(10, 116)
            Me.btnClearRegex.Name = "btnClearRegex"
            Me.btnClearRegex.Size = New System.Drawing.Size(104, 23)
            Me.btnClearRegex.TabIndex = 15
            Me.btnClearRegex.Text = "Clear"
            Me.btnClearRegex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnClearRegex.UseVisualStyleBackColor = True
            '
            'lblSeasonMatch
            '
            Me.lblSeasonMatch.AutoSize = True
            Me.lblSeasonMatch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeasonMatch.Location = New System.Drawing.Point(8, 25)
            Me.lblSeasonMatch.Name = "lblSeasonMatch"
            Me.lblSeasonMatch.Size = New System.Drawing.Size(116, 13)
            Me.lblSeasonMatch.TabIndex = 11
            Me.lblSeasonMatch.Text = "Season Match Regex:"
            '
            'btnAddShowRegex
            '
            Me.btnAddShowRegex.Enabled = False
            Me.btnAddShowRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnAddShowRegex.Image = Global.EmberMediaManger.My.Resources.Modules.btn_AddFolder
            Me.btnAddShowRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddShowRegex.Location = New System.Drawing.Point(482, 117)
            Me.btnAddShowRegex.Name = "btnAddShowRegex"
            Me.btnAddShowRegex.Size = New System.Drawing.Size(104, 23)
            Me.btnAddShowRegex.TabIndex = 4
            Me.btnAddShowRegex.Text = "Add Regex"
            Me.btnAddShowRegex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddShowRegex.UseVisualStyleBackColor = True
            '
            'txtSeasonRegex
            '
            Me.txtSeasonRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSeasonRegex.Location = New System.Drawing.Point(10, 40)
            Me.txtSeasonRegex.Name = "txtSeasonRegex"
            Me.txtSeasonRegex.Size = New System.Drawing.Size(417, 22)
            Me.txtSeasonRegex.TabIndex = 7
            '
            'lblEpisodeRetrieve
            '
            Me.lblEpisodeRetrieve.AutoSize = True
            Me.lblEpisodeRetrieve.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEpisodeRetrieve.Location = New System.Drawing.Point(441, 69)
            Me.lblEpisodeRetrieve.Name = "lblEpisodeRetrieve"
            Me.lblEpisodeRetrieve.Size = New System.Drawing.Size(54, 13)
            Me.lblEpisodeRetrieve.TabIndex = 14
            Me.lblEpisodeRetrieve.Text = "Apply To:"
            '
            'cboSeasonRetrieve
            '
            Me.cboSeasonRetrieve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSeasonRetrieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSeasonRetrieve.FormattingEnabled = True
            Me.cboSeasonRetrieve.Items.AddRange(New Object() {"Folder Name", "File Name"})
            Me.cboSeasonRetrieve.Location = New System.Drawing.Point(443, 40)
            Me.cboSeasonRetrieve.Name = "cboSeasonRetrieve"
            Me.cboSeasonRetrieve.Size = New System.Drawing.Size(135, 21)
            Me.cboSeasonRetrieve.TabIndex = 8
            '
            'lblSeasonRetrieve
            '
            Me.lblSeasonRetrieve.AutoSize = True
            Me.lblSeasonRetrieve.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeasonRetrieve.Location = New System.Drawing.Point(441, 25)
            Me.lblSeasonRetrieve.Name = "lblSeasonRetrieve"
            Me.lblSeasonRetrieve.Size = New System.Drawing.Size(54, 13)
            Me.lblSeasonRetrieve.TabIndex = 13
            Me.lblSeasonRetrieve.Text = "Apply To:"
            '
            'txtEpRegex
            '
            Me.txtEpRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEpRegex.Location = New System.Drawing.Point(10, 84)
            Me.txtEpRegex.Name = "txtEpRegex"
            Me.txtEpRegex.Size = New System.Drawing.Size(417, 22)
            Me.txtEpRegex.TabIndex = 9
            '
            'lblEpisodeMatch
            '
            Me.lblEpisodeMatch.AutoSize = True
            Me.lblEpisodeMatch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEpisodeMatch.Location = New System.Drawing.Point(8, 69)
            Me.lblEpisodeMatch.Name = "lblEpisodeMatch"
            Me.lblEpisodeMatch.Size = New System.Drawing.Size(120, 13)
            Me.lblEpisodeMatch.TabIndex = 12
            Me.lblEpisodeMatch.Text = "Episode Match Regex:"
            '
            'cboEpRetrieve
            '
            Me.cboEpRetrieve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboEpRetrieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEpRetrieve.FormattingEnabled = True
            Me.cboEpRetrieve.Items.AddRange(New Object() {"Folder Name", "File Name", "Season Result"})
            Me.cboEpRetrieve.Location = New System.Drawing.Point(443, 84)
            Me.cboEpRetrieve.Name = "cboEpRetrieve"
            Me.cboEpRetrieve.Size = New System.Drawing.Size(135, 21)
            Me.cboEpRetrieve.TabIndex = 10
            '
            'btnEditShowRegex
            '
            Me.btnEditShowRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnEditShowRegex.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditShowRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditShowRegex.Location = New System.Drawing.Point(1, 167)
            Me.btnEditShowRegex.Name = "btnEditShowRegex"
            Me.btnEditShowRegex.Size = New System.Drawing.Size(104, 23)
            Me.btnEditShowRegex.TabIndex = 5
            Me.btnEditShowRegex.Text = "Edit Regex"
            Me.btnEditShowRegex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditShowRegex.UseVisualStyleBackColor = True
            '
            'btnRemoveShowRegex
            '
            Me.btnRemoveShowRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnRemoveShowRegex.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveShowRegex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveShowRegex.Location = New System.Drawing.Point(494, 167)
            Me.btnRemoveShowRegex.Name = "btnRemoveShowRegex"
            Me.btnRemoveShowRegex.Size = New System.Drawing.Size(104, 23)
            Me.btnRemoveShowRegex.TabIndex = 6
            Me.btnRemoveShowRegex.Text = "Remove"
            Me.btnRemoveShowRegex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveShowRegex.UseVisualStyleBackColor = True
            '
            'lvShowRegex
            '
            Me.lvShowRegex.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRegID, Me.colSeason, Me.colSeasonApply, Me.colEpisode, Me.colEpApply})
            Me.lvShowRegex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lvShowRegex.FullRowSelect = True
            Me.lvShowRegex.HideSelection = False
            Me.lvShowRegex.Location = New System.Drawing.Point(0, 28)
            Me.lvShowRegex.Name = "lvShowRegex"
            Me.lvShowRegex.Size = New System.Drawing.Size(598, 135)
            Me.lvShowRegex.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvShowRegex.TabIndex = 1
            Me.lvShowRegex.UseCompatibleStateImageBehavior = False
            Me.lvShowRegex.View = System.Windows.Forms.View.Details
            '
            'colRegID
            '
            Me.colRegID.DisplayIndex = 4
            Me.colRegID.Width = 0
            '
            'colSeason
            '
            Me.colSeason.DisplayIndex = 0
            Me.colSeason.Text = "Season Regex"
            Me.colSeason.Width = 224
            '
            'colSeasonApply
            '
            Me.colSeasonApply.DisplayIndex = 1
            Me.colSeasonApply.Text = "Apply To"
            Me.colSeasonApply.Width = 70
            '
            'colEpisode
            '
            Me.colEpisode.DisplayIndex = 2
            Me.colEpisode.Text = "Episode Regex"
            Me.colEpisode.Width = 219
            '
            'colEpApply
            '
            Me.colEpApply.DisplayIndex = 3
            Me.colEpApply.Text = "Apply To"
            Me.colEpApply.Width = 70
            '
            'TVSources
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControl2)
            Me.Name = "TVSources"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Sources
            Me.PanelOrder = 200
            Me.PanelText = "Files and Sources"
            Me.PanelType = "TV Shows"
            Me.TabControl2.ResumeLayout(False)
            Me.TabPage5.ResumeLayout(False)
            Me.gbMiscTVSourceOpts.ResumeLayout(False)
            Me.gbMiscTVSourceOpts.PerformLayout()
            Me.gbTVNaming.ResumeLayout(False)
            Me.gbShowBanner.ResumeLayout(False)
            Me.gbShowBanner.PerformLayout()
            Me.gbAllSeasonPoster.ResumeLayout(False)
            Me.gbAllSeasonPoster.PerformLayout()
            Me.gbEpisodeFanart.ResumeLayout(False)
            Me.gbEpisodeFanart.PerformLayout()
            Me.gbEpisodePosters.ResumeLayout(False)
            Me.gbEpisodePosters.PerformLayout()
            Me.gbSeasonFanart.ResumeLayout(False)
            Me.gbSeasonFanart.PerformLayout()
            Me.gbSeasonPosters.ResumeLayout(False)
            Me.gbSeasonPosters.PerformLayout()
            Me.gbShowFanart.ResumeLayout(False)
            Me.gbShowFanart.PerformLayout()
            Me.gbShowPosters.ResumeLayout(False)
            Me.gbShowPosters.PerformLayout()
            Me.TabPage6.ResumeLayout(False)
            Me.gbShowRegex.ResumeLayout(False)
            Me.gbShowRegex.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents lvTVSources As System.Windows.Forms.ListView
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
        Friend WithEvents gbMiscTVSourceOpts As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtTVSkipLessThan As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents chkTVScanOrderModify As System.Windows.Forms.CheckBox
        Friend WithEvents chkTVIgnoreLastScan As System.Windows.Forms.CheckBox
        Friend WithEvents chkTVCleanDB As System.Windows.Forms.CheckBox
        Friend WithEvents btnAddTVSource As System.Windows.Forms.Button
        Friend WithEvents btnEditTVSource As System.Windows.Forms.Button
        Friend WithEvents btnRemTVSource As System.Windows.Forms.Button
        Friend WithEvents gbTVNaming As System.Windows.Forms.GroupBox
        Friend WithEvents gbShowBanner As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowBannerJPG As System.Windows.Forms.CheckBox
        Friend WithEvents gbAllSeasonPoster As System.Windows.Forms.GroupBox
        Friend WithEvents chkSeasonAllJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonAllTBN As System.Windows.Forms.CheckBox
        Friend WithEvents gbEpisodeFanart As System.Windows.Forms.GroupBox
        Friend WithEvents chkEpisodeDotFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpisodeDashFanart As System.Windows.Forms.CheckBox
        Friend WithEvents gbEpisodePosters As System.Windows.Forms.GroupBox
        Friend WithEvents chkEpisodeJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpisodeTBN As System.Windows.Forms.CheckBox
        Friend WithEvents gbSeasonFanart As System.Windows.Forms.GroupBox
        Friend WithEvents chkSeasonDotFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonDashFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents gbSeasonPosters As System.Windows.Forms.GroupBox
        Friend WithEvents chkSeasonFolderJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonNameJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonNameTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonPosterJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonPosterTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonXTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonXXTBN As System.Windows.Forms.CheckBox
        Friend WithEvents gbShowFanart As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowDotFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowDashFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents gbShowPosters As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowPosterJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowPosterTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowFolderJPG As System.Windows.Forms.CheckBox
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents btnGetTVProfiles As System.Windows.Forms.Button
        Friend WithEvents btnRegexDown As System.Windows.Forms.Button
        Friend WithEvents btnRegexUp As System.Windows.Forms.Button
        Friend WithEvents btnResetShowRegex As System.Windows.Forms.Button
        Friend WithEvents gbShowRegex As System.Windows.Forms.GroupBox
        Friend WithEvents btnClearRegex As System.Windows.Forms.Button
        Friend WithEvents lblSeasonMatch As System.Windows.Forms.Label
        Friend WithEvents btnAddShowRegex As System.Windows.Forms.Button
        Friend WithEvents txtSeasonRegex As System.Windows.Forms.TextBox
        Friend WithEvents lblEpisodeRetrieve As System.Windows.Forms.Label
        Friend WithEvents cboSeasonRetrieve As System.Windows.Forms.ComboBox
        Friend WithEvents lblSeasonRetrieve As System.Windows.Forms.Label
        Friend WithEvents txtEpRegex As System.Windows.Forms.TextBox
        Friend WithEvents lblEpisodeMatch As System.Windows.Forms.Label
        Friend WithEvents cboEpRetrieve As System.Windows.Forms.ComboBox
        Friend WithEvents btnEditShowRegex As System.Windows.Forms.Button
        Friend WithEvents btnRemoveShowRegex As System.Windows.Forms.Button
        Friend WithEvents lvShowRegex As System.Windows.Forms.ListView
        Friend WithEvents colRegID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colSeason As System.Windows.Forms.ColumnHeader
        Friend WithEvents colSeasonApply As System.Windows.Forms.ColumnHeader
        Friend WithEvents colEpisode As System.Windows.Forms.ColumnHeader
        Friend WithEvents colEpApply As System.Windows.Forms.ColumnHeader

    End Class
End Namespace