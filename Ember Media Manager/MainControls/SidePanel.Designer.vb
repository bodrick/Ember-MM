<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SidePanel
    Inherits System.Windows.Forms.UserControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SidePanel))
        Me.ilColumnIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tabsMain = New System.Windows.Forms.TabControl()
        Me.tabMovies = New System.Windows.Forms.TabPage()
        Me.tabTV = New System.Windows.Forms.TabPage()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.mnuMediaList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuMark = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuLock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuEditMovie = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuMetaData = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuGenres = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuSep = New System.Windows.Forms.ToolStripSeparator()
        Me.ScrapingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNfoAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPosterAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFanartAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectExtraAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectTrailerAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectMetaAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNfoAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPosterÃskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectFanartAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectExtraAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripAskMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectMeEtaAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuRescrape = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuSearchNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenContainingFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMovieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEpisodes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuEpTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuReloadEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuMarkEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuLockEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuEditEpisode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuRescrapeEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuChangeEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuEpOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveEpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuRemoveTVEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuDeleteTVEp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShows = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuShowTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuReloadShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuMarkShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuLockShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuEditShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuRescrapeShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuChangeShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuShowOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuRemoveTVShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuDeleteTVShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSeasons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuSeasonTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuReloadSeason = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuMarkSeason = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuLockSeason = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuSeasonChangeImages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuSeasonRescrape = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuSeasonOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuSeasonRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuRemoveSeasonFromDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuDeleteSeason = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvMedia = New BrightIdeasSoftware.TreeListView()
        Me.olvcTitle = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcPoster = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TrueFalseImageRenderer = New BrightIdeasSoftware.MappedImageRenderer()
        Me.olvcFanart = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcNFO = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcTrailer = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcSub = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcExtra = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.xppFilters = New BSE.Windows.Forms.Panel()
        Me.pnlFilters = New EmberMediaManger.FiltersPanel()
        Me.tabsMain.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.mnuMediaList.SuspendLayout()
        Me.mnuEpisodes.SuspendLayout()
        Me.mnuShows.SuspendLayout()
        Me.mnuSeasons.SuspendLayout()
        CType(Me.lvMedia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xppFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'ilColumnIcons
        '
        Me.ilColumnIcons.ImageStream = CType(resources.GetObject("ilColumnIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilColumnIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilColumnIcons.Images.SetKeyName(0, "new_page.png")
        Me.ilColumnIcons.Images.SetKeyName(1, "image.png")
        Me.ilColumnIcons.Images.SetKeyName(2, "info.png")
        Me.ilColumnIcons.Images.SetKeyName(3, "favorite_film.png")
        Me.ilColumnIcons.Images.SetKeyName(4, "comment.png")
        Me.ilColumnIcons.Images.SetKeyName(5, "folder_full.png")
        Me.ilColumnIcons.Images.SetKeyName(6, "listcheck.png")
        Me.ilColumnIcons.Images.SetKeyName(7, "listdotgrey.png")
        '
        'tabsMain
        '
        Me.tabsMain.Controls.Add(Me.tabMovies)
        Me.tabsMain.Controls.Add(Me.tabTV)
        Me.tabsMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabsMain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tabsMain.Location = New System.Drawing.Point(0, 0)
        Me.tabsMain.Name = "tabsMain"
        Me.tabsMain.SelectedIndex = 0
        Me.tabsMain.Size = New System.Drawing.Size(364, 20)
        Me.tabsMain.TabIndex = 16
        Me.tabsMain.TabStop = False
        '
        'tabMovies
        '
        Me.tabMovies.Location = New System.Drawing.Point(4, 22)
        Me.tabMovies.Name = "tabMovies"
        Me.tabMovies.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMovies.Size = New System.Drawing.Size(356, 0)
        Me.tabMovies.TabIndex = 0
        Me.tabMovies.Text = "Movies"
        Me.tabMovies.UseVisualStyleBackColor = True
        '
        'tabTV
        '
        Me.tabTV.Location = New System.Drawing.Point(4, 22)
        Me.tabTV.Name = "tabTV"
        Me.tabTV.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTV.Size = New System.Drawing.Size(356, 0)
        Me.tabTV.TabIndex = 1
        Me.tabTV.Text = "TV Shows"
        Me.tabTV.UseVisualStyleBackColor = True
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.cbSearch)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(0, 20)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(364, 31)
        Me.pnlSearch.TabIndex = 20
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Search
        Me.btnSearch.Location = New System.Drawing.Point(338, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(22, 22)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbSearch
        '
        Me.cbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Location = New System.Drawing.Point(251, 4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(83, 21)
        Me.cbSearch.TabIndex = 10
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(9, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(238, 22)
        Me.txtSearch.TabIndex = 9
        '
        'mnuMediaList
        '
        Me.mnuMediaList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuTitle, Me.ToolStripSeparator3, Me.cmnuRefresh, Me.cmnuMark, Me.cmnuLock, Me.ToolStripMenuItem1, Me.cmnuEditMovie, Me.cmnuMetaData, Me.cmnuGenres, Me.cmnuSep, Me.ScrapingToolStripMenuItem, Me.cmnuRescrape, Me.cmnuSearchNew, Me.cmnuSep2, Me.OpenContainingFolderToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveToolStripMenuItem})
        Me.mnuMediaList.Name = "mnuMediaList"
        Me.mnuMediaList.Size = New System.Drawing.Size(245, 320)
        '
        'cmnuTitle
        '
        Me.cmnuTitle.Enabled = False
        Me.cmnuTitle.Image = CType(resources.GetObject("cmnuTitle.Image"), System.Drawing.Image)
        Me.cmnuTitle.Name = "cmnuTitle"
        Me.cmnuTitle.Size = New System.Drawing.Size(244, 22)
        Me.cmnuTitle.Text = "Title"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuRefresh
        '
        Me.cmnuRefresh.Image = CType(resources.GetObject("cmnuRefresh.Image"), System.Drawing.Image)
        Me.cmnuRefresh.Name = "cmnuRefresh"
        Me.cmnuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cmnuRefresh.Size = New System.Drawing.Size(244, 22)
        Me.cmnuRefresh.Text = "Reload"
        '
        'cmnuMark
        '
        Me.cmnuMark.Image = CType(resources.GetObject("cmnuMark.Image"), System.Drawing.Image)
        Me.cmnuMark.Name = "cmnuMark"
        Me.cmnuMark.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.cmnuMark.Size = New System.Drawing.Size(244, 22)
        Me.cmnuMark.Text = "Mark"
        '
        'cmnuLock
        '
        Me.cmnuLock.Image = CType(resources.GetObject("cmnuLock.Image"), System.Drawing.Image)
        Me.cmnuLock.Name = "cmnuLock"
        Me.cmnuLock.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.cmnuLock.Size = New System.Drawing.Size(244, 22)
        Me.cmnuLock.Text = "Lock"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuEditMovie
        '
        Me.cmnuEditMovie.Image = CType(resources.GetObject("cmnuEditMovie.Image"), System.Drawing.Image)
        Me.cmnuEditMovie.Name = "cmnuEditMovie"
        Me.cmnuEditMovie.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.cmnuEditMovie.Size = New System.Drawing.Size(244, 22)
        Me.cmnuEditMovie.Text = "Edit Movie"
        '
        'cmnuMetaData
        '
        Me.cmnuMetaData.Image = CType(resources.GetObject("cmnuMetaData.Image"), System.Drawing.Image)
        Me.cmnuMetaData.Name = "cmnuMetaData"
        Me.cmnuMetaData.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.cmnuMetaData.Size = New System.Drawing.Size(244, 22)
        Me.cmnuMetaData.Text = "Edit Meta Data"
        '
        'cmnuGenres
        '
        Me.cmnuGenres.Image = CType(resources.GetObject("cmnuGenres.Image"), System.Drawing.Image)
        Me.cmnuGenres.Name = "cmnuGenres"
        Me.cmnuGenres.Size = New System.Drawing.Size(244, 22)
        Me.cmnuGenres.Text = "Genres"
        '
        'cmnuSep
        '
        Me.cmnuSep.Name = "cmnuSep"
        Me.cmnuSep.Size = New System.Drawing.Size(241, 6)
        '
        'ScrapingToolStripMenuItem
        '
        Me.ScrapingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem13})
        Me.ScrapingToolStripMenuItem.Image = CType(resources.GetObject("ScrapingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ScrapingToolStripMenuItem.Name = "ScrapingToolStripMenuItem"
        Me.ScrapingToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.ScrapingToolStripMenuItem.Text = "(Re)Scrape Selected Movies"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllAutoToolStripMenuItem, Me.SelectNfoAutoToolStripMenuItem, Me.SelectPosterAutoToolStripMenuItem, Me.SelectFanartAutoToolStripMenuItem, Me.SelectExtraAutoToolStripMenuItem, Me.SelectTrailerAutoToolStripMenuItem, Me.SelectMetaAutoToolStripMenuItem})
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem5.Text = "Automatic (Force Best Match)"
        '
        'SelectAllAutoToolStripMenuItem
        '
        Me.SelectAllAutoToolStripMenuItem.Name = "SelectAllAutoToolStripMenuItem"
        Me.SelectAllAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectAllAutoToolStripMenuItem.Text = "All Items"
        '
        'SelectNfoAutoToolStripMenuItem
        '
        Me.SelectNfoAutoToolStripMenuItem.Name = "SelectNfoAutoToolStripMenuItem"
        Me.SelectNfoAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectNfoAutoToolStripMenuItem.Text = "NFO Only"
        '
        'SelectPosterAutoToolStripMenuItem
        '
        Me.SelectPosterAutoToolStripMenuItem.Name = "SelectPosterAutoToolStripMenuItem"
        Me.SelectPosterAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectPosterAutoToolStripMenuItem.Text = "Poster Only"
        '
        'SelectFanartAutoToolStripMenuItem
        '
        Me.SelectFanartAutoToolStripMenuItem.Name = "SelectFanartAutoToolStripMenuItem"
        Me.SelectFanartAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectFanartAutoToolStripMenuItem.Text = "Fanart Only"
        '
        'SelectExtraAutoToolStripMenuItem
        '
        Me.SelectExtraAutoToolStripMenuItem.Name = "SelectExtraAutoToolStripMenuItem"
        Me.SelectExtraAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectExtraAutoToolStripMenuItem.Text = "Extrathumbs Only"
        '
        'SelectTrailerAutoToolStripMenuItem
        '
        Me.SelectTrailerAutoToolStripMenuItem.Name = "SelectTrailerAutoToolStripMenuItem"
        Me.SelectTrailerAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectTrailerAutoToolStripMenuItem.Text = "Trailer Only"
        '
        'SelectMetaAutoToolStripMenuItem
        '
        Me.SelectMetaAutoToolStripMenuItem.Name = "SelectMetaAutoToolStripMenuItem"
        Me.SelectMetaAutoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectMetaAutoToolStripMenuItem.Text = "Meta Data Only"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllAskToolStripMenuItem, Me.SelectNfoAskToolStripMenuItem, Me.SelectPosterÃskToolStripMenuItem, Me.SelectFanartAskToolStripMenuItem, Me.SelectExtraAskToolStripMenuItem, Me.ToolStripAskMenuItem19, Me.SelectMeEtaAskToolStripMenuItem})
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem13.Text = "Ask (Require Input If No Exact Match)"
        '
        'SelectAllAskToolStripMenuItem
        '
        Me.SelectAllAskToolStripMenuItem.Name = "SelectAllAskToolStripMenuItem"
        Me.SelectAllAskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectAllAskToolStripMenuItem.Text = "All Items"
        '
        'SelectNfoAskToolStripMenuItem
        '
        Me.SelectNfoAskToolStripMenuItem.Name = "SelectNfoAskToolStripMenuItem"
        Me.SelectNfoAskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectNfoAskToolStripMenuItem.Text = "NFO Only"
        '
        'SelectPosterÃskToolStripMenuItem
        '
        Me.SelectPosterÃskToolStripMenuItem.Name = "SelectPosterÃskToolStripMenuItem"
        Me.SelectPosterÃskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectPosterÃskToolStripMenuItem.Text = "Poster Only"
        '
        'SelectFanartAskToolStripMenuItem
        '
        Me.SelectFanartAskToolStripMenuItem.Name = "SelectFanartAskToolStripMenuItem"
        Me.SelectFanartAskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectFanartAskToolStripMenuItem.Text = "Fanart Only"
        '
        'SelectExtraAskToolStripMenuItem
        '
        Me.SelectExtraAskToolStripMenuItem.Name = "SelectExtraAskToolStripMenuItem"
        Me.SelectExtraAskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectExtraAskToolStripMenuItem.Text = "Extrathumbs Only"
        '
        'ToolStripAskMenuItem19
        '
        Me.ToolStripAskMenuItem19.Name = "ToolStripAskMenuItem19"
        Me.ToolStripAskMenuItem19.Size = New System.Drawing.Size(168, 22)
        Me.ToolStripAskMenuItem19.Text = "Trailer Only"
        '
        'SelectMeEtaAskToolStripMenuItem
        '
        Me.SelectMeEtaAskToolStripMenuItem.Name = "SelectMeEtaAskToolStripMenuItem"
        Me.SelectMeEtaAskToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SelectMeEtaAskToolStripMenuItem.Text = "Meta Data Only"
        '
        'cmnuRescrape
        '
        Me.cmnuRescrape.Image = CType(resources.GetObject("cmnuRescrape.Image"), System.Drawing.Image)
        Me.cmnuRescrape.Name = "cmnuRescrape"
        Me.cmnuRescrape.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.cmnuRescrape.Size = New System.Drawing.Size(244, 22)
        Me.cmnuRescrape.Text = "(Re)Scrape Movie"
        '
        'cmnuSearchNew
        '
        Me.cmnuSearchNew.Image = CType(resources.GetObject("cmnuSearchNew.Image"), System.Drawing.Image)
        Me.cmnuSearchNew.Name = "cmnuSearchNew"
        Me.cmnuSearchNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cmnuSearchNew.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSearchNew.Text = "Change Movie"
        '
        'cmnuSep2
        '
        Me.cmnuSep2.Name = "cmnuSep2"
        Me.cmnuSep2.Size = New System.Drawing.Size(241, 6)
        '
        'OpenContainingFolderToolStripMenuItem
        '
        Me.OpenContainingFolderToolStripMenuItem.Image = CType(resources.GetObject("OpenContainingFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenContainingFolderToolStripMenuItem.Name = "OpenContainingFolderToolStripMenuItem"
        Me.OpenContainingFolderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenContainingFolderToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.OpenContainingFolderToolStripMenuItem.Text = "Open Containing Folder"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(241, 6)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveFromDatabaseToolStripMenuItem, Me.DeleteMovieToolStripMenuItem})
        Me.RemoveToolStripMenuItem.Image = CType(resources.GetObject("RemoveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'RemoveFromDatabaseToolStripMenuItem
        '
        Me.RemoveFromDatabaseToolStripMenuItem.Image = CType(resources.GetObject("RemoveFromDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveFromDatabaseToolStripMenuItem.Name = "RemoveFromDatabaseToolStripMenuItem"
        Me.RemoveFromDatabaseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.RemoveFromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.RemoveFromDatabaseToolStripMenuItem.Text = "Remove from Database"
        '
        'DeleteMovieToolStripMenuItem
        '
        Me.DeleteMovieToolStripMenuItem.Image = CType(resources.GetObject("DeleteMovieToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteMovieToolStripMenuItem.Name = "DeleteMovieToolStripMenuItem"
        Me.DeleteMovieToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.DeleteMovieToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.DeleteMovieToolStripMenuItem.Text = "Delete Movie"
        '
        'mnuEpisodes
        '
        Me.mnuEpisodes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuEpTitle, Me.ToolStripSeparator6, Me.cmnuReloadEp, Me.cmnuMarkEp, Me.cmnuLockEp, Me.ToolStripSeparator9, Me.cmnuEditEpisode, Me.ToolStripSeparator10, Me.cmnuRescrapeEp, Me.cmnuChangeEp, Me.ToolStripSeparator12, Me.cmnuEpOpenFolder, Me.ToolStripSeparator28, Me.RemoveEpToolStripMenuItem})
        Me.mnuEpisodes.Name = "mnuEpisodes"
        Me.mnuEpisodes.Size = New System.Drawing.Size(245, 232)
        '
        'cmnuEpTitle
        '
        Me.cmnuEpTitle.Enabled = False
        Me.cmnuEpTitle.Image = CType(resources.GetObject("cmnuEpTitle.Image"), System.Drawing.Image)
        Me.cmnuEpTitle.Name = "cmnuEpTitle"
        Me.cmnuEpTitle.Size = New System.Drawing.Size(244, 22)
        Me.cmnuEpTitle.Text = "Title"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuReloadEp
        '
        Me.cmnuReloadEp.Image = CType(resources.GetObject("cmnuReloadEp.Image"), System.Drawing.Image)
        Me.cmnuReloadEp.Name = "cmnuReloadEp"
        Me.cmnuReloadEp.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cmnuReloadEp.Size = New System.Drawing.Size(244, 22)
        Me.cmnuReloadEp.Text = "Reload"
        '
        'cmnuMarkEp
        '
        Me.cmnuMarkEp.Image = CType(resources.GetObject("cmnuMarkEp.Image"), System.Drawing.Image)
        Me.cmnuMarkEp.Name = "cmnuMarkEp"
        Me.cmnuMarkEp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.cmnuMarkEp.Size = New System.Drawing.Size(244, 22)
        Me.cmnuMarkEp.Text = "Mark"
        '
        'cmnuLockEp
        '
        Me.cmnuLockEp.Image = CType(resources.GetObject("cmnuLockEp.Image"), System.Drawing.Image)
        Me.cmnuLockEp.Name = "cmnuLockEp"
        Me.cmnuLockEp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.cmnuLockEp.Size = New System.Drawing.Size(244, 22)
        Me.cmnuLockEp.Text = "Lock"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuEditEpisode
        '
        Me.cmnuEditEpisode.Image = CType(resources.GetObject("cmnuEditEpisode.Image"), System.Drawing.Image)
        Me.cmnuEditEpisode.Name = "cmnuEditEpisode"
        Me.cmnuEditEpisode.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.cmnuEditEpisode.Size = New System.Drawing.Size(244, 22)
        Me.cmnuEditEpisode.Text = "Edit Episode"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuRescrapeEp
        '
        Me.cmnuRescrapeEp.Image = CType(resources.GetObject("cmnuRescrapeEp.Image"), System.Drawing.Image)
        Me.cmnuRescrapeEp.Name = "cmnuRescrapeEp"
        Me.cmnuRescrapeEp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.cmnuRescrapeEp.Size = New System.Drawing.Size(244, 22)
        Me.cmnuRescrapeEp.Text = "Re-scrape theTVDB"
        '
        'cmnuChangeEp
        '
        Me.cmnuChangeEp.Image = CType(resources.GetObject("cmnuChangeEp.Image"), System.Drawing.Image)
        Me.cmnuChangeEp.Name = "cmnuChangeEp"
        Me.cmnuChangeEp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cmnuChangeEp.Size = New System.Drawing.Size(244, 22)
        Me.cmnuChangeEp.Text = "Change Episode"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuEpOpenFolder
        '
        Me.cmnuEpOpenFolder.Image = CType(resources.GetObject("cmnuEpOpenFolder.Image"), System.Drawing.Image)
        Me.cmnuEpOpenFolder.Name = "cmnuEpOpenFolder"
        Me.cmnuEpOpenFolder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.cmnuEpOpenFolder.Size = New System.Drawing.Size(244, 22)
        Me.cmnuEpOpenFolder.Text = "Open Contianing Folder"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(241, 6)
        '
        'RemoveEpToolStripMenuItem
        '
        Me.RemoveEpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuRemoveTVEp, Me.cmnuDeleteTVEp})
        Me.RemoveEpToolStripMenuItem.Image = CType(resources.GetObject("RemoveEpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveEpToolStripMenuItem.Name = "RemoveEpToolStripMenuItem"
        Me.RemoveEpToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.RemoveEpToolStripMenuItem.Text = "Remove"
        '
        'cmnuRemoveTVEp
        '
        Me.cmnuRemoveTVEp.Image = CType(resources.GetObject("cmnuRemoveTVEp.Image"), System.Drawing.Image)
        Me.cmnuRemoveTVEp.Name = "cmnuRemoveTVEp"
        Me.cmnuRemoveTVEp.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.cmnuRemoveTVEp.Size = New System.Drawing.Size(221, 22)
        Me.cmnuRemoveTVEp.Text = "Remove from Database"
        '
        'cmnuDeleteTVEp
        '
        Me.cmnuDeleteTVEp.Image = CType(resources.GetObject("cmnuDeleteTVEp.Image"), System.Drawing.Image)
        Me.cmnuDeleteTVEp.Name = "cmnuDeleteTVEp"
        Me.cmnuDeleteTVEp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.cmnuDeleteTVEp.Size = New System.Drawing.Size(221, 22)
        Me.cmnuDeleteTVEp.Text = "Delete Episode"
        '
        'mnuShows
        '
        Me.mnuShows.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuShowTitle, Me.ToolStripMenuItem2, Me.cmnuReloadShow, Me.cmnuMarkShow, Me.cmnuLockShow, Me.ToolStripSeparator8, Me.cmnuEditShow, Me.ToolStripSeparator7, Me.cmnuRescrapeShow, Me.cmnuChangeShow, Me.ToolStripSeparator11, Me.cmnuShowOpenFolder, Me.ToolStripSeparator20, Me.RemoveShowToolStripMenuItem})
        Me.mnuShows.Name = "mnuShows"
        Me.mnuShows.Size = New System.Drawing.Size(245, 232)
        '
        'cmnuShowTitle
        '
        Me.cmnuShowTitle.Enabled = False
        Me.cmnuShowTitle.Image = CType(resources.GetObject("cmnuShowTitle.Image"), System.Drawing.Image)
        Me.cmnuShowTitle.Name = "cmnuShowTitle"
        Me.cmnuShowTitle.Size = New System.Drawing.Size(244, 22)
        Me.cmnuShowTitle.Text = "Title"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuReloadShow
        '
        Me.cmnuReloadShow.Image = CType(resources.GetObject("cmnuReloadShow.Image"), System.Drawing.Image)
        Me.cmnuReloadShow.Name = "cmnuReloadShow"
        Me.cmnuReloadShow.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cmnuReloadShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuReloadShow.Text = "Reload"
        '
        'cmnuMarkShow
        '
        Me.cmnuMarkShow.Image = CType(resources.GetObject("cmnuMarkShow.Image"), System.Drawing.Image)
        Me.cmnuMarkShow.Name = "cmnuMarkShow"
        Me.cmnuMarkShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.cmnuMarkShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuMarkShow.Text = "Mark"
        '
        'cmnuLockShow
        '
        Me.cmnuLockShow.Image = CType(resources.GetObject("cmnuLockShow.Image"), System.Drawing.Image)
        Me.cmnuLockShow.Name = "cmnuLockShow"
        Me.cmnuLockShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.cmnuLockShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuLockShow.Text = "Lock"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuEditShow
        '
        Me.cmnuEditShow.Image = CType(resources.GetObject("cmnuEditShow.Image"), System.Drawing.Image)
        Me.cmnuEditShow.Name = "cmnuEditShow"
        Me.cmnuEditShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.cmnuEditShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuEditShow.Text = "Edit Show"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuRescrapeShow
        '
        Me.cmnuRescrapeShow.Image = CType(resources.GetObject("cmnuRescrapeShow.Image"), System.Drawing.Image)
        Me.cmnuRescrapeShow.Name = "cmnuRescrapeShow"
        Me.cmnuRescrapeShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.cmnuRescrapeShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuRescrapeShow.Text = "Re-scrape theTVDB"
        '
        'cmnuChangeShow
        '
        Me.cmnuChangeShow.Image = CType(resources.GetObject("cmnuChangeShow.Image"), System.Drawing.Image)
        Me.cmnuChangeShow.Name = "cmnuChangeShow"
        Me.cmnuChangeShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cmnuChangeShow.Size = New System.Drawing.Size(244, 22)
        Me.cmnuChangeShow.Text = "Change Show"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuShowOpenFolder
        '
        Me.cmnuShowOpenFolder.Image = CType(resources.GetObject("cmnuShowOpenFolder.Image"), System.Drawing.Image)
        Me.cmnuShowOpenFolder.Name = "cmnuShowOpenFolder"
        Me.cmnuShowOpenFolder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.cmnuShowOpenFolder.Size = New System.Drawing.Size(244, 22)
        Me.cmnuShowOpenFolder.Text = "Open Containing Folder"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(241, 6)
        '
        'RemoveShowToolStripMenuItem
        '
        Me.RemoveShowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuRemoveTVShow, Me.cmnuDeleteTVShow})
        Me.RemoveShowToolStripMenuItem.Image = CType(resources.GetObject("RemoveShowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveShowToolStripMenuItem.Name = "RemoveShowToolStripMenuItem"
        Me.RemoveShowToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.RemoveShowToolStripMenuItem.Text = "Remove"
        '
        'cmnuRemoveTVShow
        '
        Me.cmnuRemoveTVShow.Image = CType(resources.GetObject("cmnuRemoveTVShow.Image"), System.Drawing.Image)
        Me.cmnuRemoveTVShow.Name = "cmnuRemoveTVShow"
        Me.cmnuRemoveTVShow.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.cmnuRemoveTVShow.Size = New System.Drawing.Size(221, 22)
        Me.cmnuRemoveTVShow.Text = "Remove from Database"
        '
        'cmnuDeleteTVShow
        '
        Me.cmnuDeleteTVShow.Image = CType(resources.GetObject("cmnuDeleteTVShow.Image"), System.Drawing.Image)
        Me.cmnuDeleteTVShow.Name = "cmnuDeleteTVShow"
        Me.cmnuDeleteTVShow.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.cmnuDeleteTVShow.Size = New System.Drawing.Size(221, 22)
        Me.cmnuDeleteTVShow.Text = "Delete TV Show"
        '
        'mnuSeasons
        '
        Me.mnuSeasons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuSeasonTitle, Me.ToolStripSeparator17, Me.cmnuReloadSeason, Me.cmnuMarkSeason, Me.cmnuLockSeason, Me.ToolStripSeparator16, Me.cmnuSeasonChangeImages, Me.ToolStripSeparator14, Me.cmnuSeasonRescrape, Me.ToolStripSeparator15, Me.cmnuSeasonOpenFolder, Me.ToolStripSeparator27, Me.cmnuSeasonRemove})
        Me.mnuSeasons.Name = "mnuSeasons"
        Me.mnuSeasons.Size = New System.Drawing.Size(245, 232)
        '
        'cmnuSeasonTitle
        '
        Me.cmnuSeasonTitle.Enabled = False
        Me.cmnuSeasonTitle.Image = CType(resources.GetObject("cmnuSeasonTitle.Image"), System.Drawing.Image)
        Me.cmnuSeasonTitle.Name = "cmnuSeasonTitle"
        Me.cmnuSeasonTitle.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSeasonTitle.Text = "Title"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuReloadSeason
        '
        Me.cmnuReloadSeason.Image = CType(resources.GetObject("cmnuReloadSeason.Image"), System.Drawing.Image)
        Me.cmnuReloadSeason.Name = "cmnuReloadSeason"
        Me.cmnuReloadSeason.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.cmnuReloadSeason.Size = New System.Drawing.Size(244, 22)
        Me.cmnuReloadSeason.Text = "Reload"
        '
        'cmnuMarkSeason
        '
        Me.cmnuMarkSeason.Image = CType(resources.GetObject("cmnuMarkSeason.Image"), System.Drawing.Image)
        Me.cmnuMarkSeason.Name = "cmnuMarkSeason"
        Me.cmnuMarkSeason.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.cmnuMarkSeason.Size = New System.Drawing.Size(244, 22)
        Me.cmnuMarkSeason.Text = "Mark"
        '
        'cmnuLockSeason
        '
        Me.cmnuLockSeason.Image = CType(resources.GetObject("cmnuLockSeason.Image"), System.Drawing.Image)
        Me.cmnuLockSeason.Name = "cmnuLockSeason"
        Me.cmnuLockSeason.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.cmnuLockSeason.Size = New System.Drawing.Size(244, 22)
        Me.cmnuLockSeason.Text = "Lock"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuSeasonChangeImages
        '
        Me.cmnuSeasonChangeImages.Image = CType(resources.GetObject("cmnuSeasonChangeImages.Image"), System.Drawing.Image)
        Me.cmnuSeasonChangeImages.Name = "cmnuSeasonChangeImages"
        Me.cmnuSeasonChangeImages.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.cmnuSeasonChangeImages.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSeasonChangeImages.Text = "Change Images"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuSeasonRescrape
        '
        Me.cmnuSeasonRescrape.Image = CType(resources.GetObject("cmnuSeasonRescrape.Image"), System.Drawing.Image)
        Me.cmnuSeasonRescrape.Name = "cmnuSeasonRescrape"
        Me.cmnuSeasonRescrape.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.cmnuSeasonRescrape.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSeasonRescrape.Text = "Re-scrape theTVDB"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuSeasonOpenFolder
        '
        Me.cmnuSeasonOpenFolder.Image = CType(resources.GetObject("cmnuSeasonOpenFolder.Image"), System.Drawing.Image)
        Me.cmnuSeasonOpenFolder.Name = "cmnuSeasonOpenFolder"
        Me.cmnuSeasonOpenFolder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.cmnuSeasonOpenFolder.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSeasonOpenFolder.Text = "Open Contianing Folder"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(241, 6)
        '
        'cmnuSeasonRemove
        '
        Me.cmnuSeasonRemove.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuRemoveSeasonFromDB, Me.cmnuDeleteSeason})
        Me.cmnuSeasonRemove.Image = CType(resources.GetObject("cmnuSeasonRemove.Image"), System.Drawing.Image)
        Me.cmnuSeasonRemove.Name = "cmnuSeasonRemove"
        Me.cmnuSeasonRemove.Size = New System.Drawing.Size(244, 22)
        Me.cmnuSeasonRemove.Text = "Remove"
        '
        'cmnuRemoveSeasonFromDB
        '
        Me.cmnuRemoveSeasonFromDB.Image = CType(resources.GetObject("cmnuRemoveSeasonFromDB.Image"), System.Drawing.Image)
        Me.cmnuRemoveSeasonFromDB.Name = "cmnuRemoveSeasonFromDB"
        Me.cmnuRemoveSeasonFromDB.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.cmnuRemoveSeasonFromDB.Size = New System.Drawing.Size(221, 22)
        Me.cmnuRemoveSeasonFromDB.Text = "Remove from Database"
        '
        'cmnuDeleteSeason
        '
        Me.cmnuDeleteSeason.Image = CType(resources.GetObject("cmnuDeleteSeason.Image"), System.Drawing.Image)
        Me.cmnuDeleteSeason.Name = "cmnuDeleteSeason"
        Me.cmnuDeleteSeason.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.cmnuDeleteSeason.Size = New System.Drawing.Size(221, 22)
        Me.cmnuDeleteSeason.Text = "Delete Season"
        '
        'lvMedia
        '
        Me.lvMedia.AllColumns.Add(Me.olvcTitle)
        Me.lvMedia.AllColumns.Add(Me.olvcPoster)
        Me.lvMedia.AllColumns.Add(Me.olvcFanart)
        Me.lvMedia.AllColumns.Add(Me.olvcNFO)
        Me.lvMedia.AllColumns.Add(Me.olvcTrailer)
        Me.lvMedia.AllColumns.Add(Me.olvcSub)
        Me.lvMedia.AllColumns.Add(Me.olvcExtra)
        Me.lvMedia.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcTitle, Me.olvcPoster, Me.olvcFanart, Me.olvcNFO, Me.olvcTrailer, Me.olvcSub, Me.olvcExtra})
        Me.lvMedia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvMedia.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lvMedia.FullRowSelect = True
        Me.lvMedia.GridLines = True
        Me.lvMedia.HeaderUsesThemes = False
        Me.lvMedia.HideSelection = False
        Me.lvMedia.Location = New System.Drawing.Point(0, 51)
        Me.lvMedia.Name = "lvMedia"
        Me.lvMedia.OwnerDraw = True
        Me.lvMedia.ShowGroups = False
        Me.lvMedia.Size = New System.Drawing.Size(364, 428)
        Me.lvMedia.SmallImageList = Me.ilColumnIcons
        Me.lvMedia.TabIndex = 18
        Me.lvMedia.TintSortColumn = True
        Me.lvMedia.UseCompatibleStateImageBehavior = False
        Me.lvMedia.UseFiltering = True
        Me.lvMedia.UseOverlays = False
        Me.lvMedia.View = System.Windows.Forms.View.Details
        Me.lvMedia.VirtualMode = True
        '
        'olvcTitle
        '
        Me.olvcTitle.AspectName = "Title"
        Me.olvcTitle.FillsFreeSpace = True
        Me.olvcTitle.Text = "Title"
        '
        'olvcPoster
        '
        Me.olvcPoster.AspectName = "HasPoster"
        Me.olvcPoster.HeaderImageKey = "new_page.png"
        Me.olvcPoster.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvcPoster.MaximumWidth = 22
        Me.olvcPoster.MinimumWidth = 22
        Me.olvcPoster.Renderer = Me.TrueFalseImageRenderer
        Me.olvcPoster.Searchable = False
        Me.olvcPoster.ShowSortIndicator = False
        Me.olvcPoster.ShowTextInHeader = False
        Me.olvcPoster.Text = "Poster"
        Me.olvcPoster.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvcPoster.Width = 22
        '
        'TrueFalseImageRenderer
        '
        Me.TrueFalseImageRenderer.UseGdiTextRendering = False
        '
        'olvcFanart
        '
        Me.olvcFanart.AspectName = "HasFanart"
        Me.olvcFanart.HeaderImageKey = "image.png"
        Me.olvcFanart.MaximumWidth = 22
        Me.olvcFanart.MinimumWidth = 22
        Me.olvcFanart.Renderer = Me.TrueFalseImageRenderer
        Me.olvcFanart.Searchable = False
        Me.olvcFanart.ShowSortIndicator = False
        Me.olvcFanart.ShowTextInHeader = False
        Me.olvcFanart.Text = "Fanart"
        Me.olvcFanart.Width = 22
        '
        'olvcNFO
        '
        Me.olvcNFO.AspectName = "HasNfo"
        Me.olvcNFO.HeaderImageKey = "info.png"
        Me.olvcNFO.MaximumWidth = 22
        Me.olvcNFO.MinimumWidth = 22
        Me.olvcNFO.Renderer = Me.TrueFalseImageRenderer
        Me.olvcNFO.Searchable = False
        Me.olvcNFO.ShowSortIndicator = False
        Me.olvcNFO.ShowTextInHeader = False
        Me.olvcNFO.Text = "NFO"
        Me.olvcNFO.Width = 22
        '
        'olvcTrailer
        '
        Me.olvcTrailer.AspectName = "HasTrailer"
        Me.olvcTrailer.HeaderImageKey = "favorite_film.png"
        Me.olvcTrailer.MaximumWidth = 22
        Me.olvcTrailer.MinimumWidth = 22
        Me.olvcTrailer.Renderer = Me.TrueFalseImageRenderer
        Me.olvcTrailer.Searchable = False
        Me.olvcTrailer.ShowSortIndicator = False
        Me.olvcTrailer.ShowTextInHeader = False
        Me.olvcTrailer.Text = "Trailer"
        Me.olvcTrailer.ToolTipText = "Trailer"
        Me.olvcTrailer.Width = 22
        '
        'olvcSub
        '
        Me.olvcSub.AspectName = "HasSub"
        Me.olvcSub.HeaderImageKey = "comment.png"
        Me.olvcSub.MaximumWidth = 22
        Me.olvcSub.MinimumWidth = 22
        Me.olvcSub.Renderer = Me.TrueFalseImageRenderer
        Me.olvcSub.Searchable = False
        Me.olvcSub.ShowSortIndicator = False
        Me.olvcSub.ShowTextInHeader = False
        Me.olvcSub.ToolTipText = "Subtitles"
        Me.olvcSub.Width = 22
        '
        'olvcExtra
        '
        Me.olvcExtra.AspectName = "HasExtra"
        Me.olvcExtra.HeaderImageKey = "folder_full.png"
        Me.olvcExtra.MaximumWidth = 22
        Me.olvcExtra.MinimumWidth = 22
        Me.olvcExtra.Renderer = Me.TrueFalseImageRenderer
        Me.olvcExtra.Searchable = False
        Me.olvcExtra.ShowSortIndicator = False
        Me.olvcExtra.ShowTextInHeader = False
        Me.olvcExtra.ToolTipText = "Extra Thumbnails"
        Me.olvcExtra.Width = 22
        '
        'xppFilters
        '
        Me.xppFilters.AssociatedSplitter = Nothing
        Me.xppFilters.BackColor = System.Drawing.Color.Transparent
        Me.xppFilters.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.xppFilters.CaptionHeight = 27
        Me.xppFilters.Controls.Add(Me.pnlFilters)
        Me.xppFilters.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppFilters.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppFilters.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppFilters.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppFilters.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppFilters.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppFilters.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppFilters.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppFilters.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppFilters.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText
        Me.xppFilters.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace
        Me.xppFilters.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppFilters.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppFilters.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.xppFilters.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppFilters.Image = Nothing
        Me.xppFilters.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.xppFilters.Location = New System.Drawing.Point(0, 479)
        Me.xppFilters.MinimumSize = New System.Drawing.Size(27, 27)
        Me.xppFilters.Name = "xppFilters"
        Me.xppFilters.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppFilters.ShowExpandIcon = True
        Me.xppFilters.Size = New System.Drawing.Size(364, 209)
        Me.xppFilters.TabIndex = 21
        Me.xppFilters.Text = "Filters"
        Me.xppFilters.ToolTipTextCloseIcon = Nothing
        Me.xppFilters.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppFilters.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'pnlFilters
        '
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFilters.Location = New System.Drawing.Point(1, 28)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(362, 180)
        Me.pnlFilters.TabIndex = 0
        '
        'SidePanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lvMedia)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.tabsMain)
        Me.Controls.Add(Me.xppFilters)
        Me.Name = "SidePanel"
        Me.Size = New System.Drawing.Size(364, 688)
        Me.tabsMain.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.mnuMediaList.ResumeLayout(False)
        Me.mnuEpisodes.ResumeLayout(False)
        Me.mnuShows.ResumeLayout(False)
        Me.mnuSeasons.ResumeLayout(False)
        CType(Me.lvMedia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xppFilters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ilColumnIcons As System.Windows.Forms.ImageList
    Friend WithEvents tabsMain As System.Windows.Forms.TabControl
    Friend WithEvents tabMovies As System.Windows.Forms.TabPage
    Friend WithEvents tabTV As System.Windows.Forms.TabPage
    Friend WithEvents olvcTitle As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcPoster As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcFanart As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcNFO As BrightIdeasSoftware.OLVColumn
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents olvcTrailer As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcSub As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcExtra As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TrueFalseImageRenderer As BrightIdeasSoftware.MappedImageRenderer
    Public WithEvents lvMedia As BrightIdeasSoftware.TreeListView
    Public WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents xppFilters As BSE.Windows.Forms.Panel
    Friend WithEvents pnlFilters As EmberMediaManger.FiltersPanel
    Friend WithEvents mnuMediaList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuMark As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuLock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuEditMovie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuMetaData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuGenres As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ScrapingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNfoAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectPosterAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectFanartAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectExtraAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectTrailerAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectMetaAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNfoAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectPosterÃskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectFanartAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectExtraAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripAskMenuItem19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectMeEtaAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuRescrape As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuSearchNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenContainingFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFromDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMovieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEpisodes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuEpTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuReloadEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuMarkEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuLockEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuEditEpisode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuRescrapeEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuChangeEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuEpOpenFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveEpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuRemoveTVEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuDeleteTVEp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShows As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuShowTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuReloadShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuMarkShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuLockShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuEditShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuRescrapeShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuChangeShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuShowOpenFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuRemoveTVShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuDeleteTVShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSeasons As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuSeasonTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuReloadSeason As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuMarkSeason As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuLockSeason As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuSeasonChangeImages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuSeasonRescrape As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuSeasonOpenFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuSeasonRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuRemoveSeasonFromDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuDeleteSeason As System.Windows.Forms.ToolStripMenuItem

End Class
