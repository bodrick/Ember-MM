<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WikiStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsSpring = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslLoading = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbLoading = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanFoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetsManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearAllCachesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshAllMoviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DonateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.ucSidePanel = New EmberMediaManger.SidePanel()
        Me.pnlhInfo = New BSE.Windows.Forms.Panel()
        Me.pnlInfoPanel = New EmberMediaManger.InfoPanel()
        Me.pnlImages = New EmberMediaManger.ImagesPanel()
        Me.ilColumnIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrWait = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrWaitShow = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoadShow = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWaitSeason = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoadSeason = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWaitEp = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoadEp = New System.Windows.Forms.Timer(Me.components)
        Me.cmnuTrayIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuTrayIconTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuTrayIconUpdateMedia = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuTrayIconUpdateMovies = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuTrayIconUpdateTV = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuTrayIconScrapeMedia = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayFullToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayFullAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAutoMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayFullAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayAllAskMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayUpdateOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayUpdateAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAutoTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayUpdateAskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMissAskTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayNewMoviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAutomaticForceBestMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAutoMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAskRequireInputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayNewAskMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayMarkedMoviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAutomaticForceBestMatchToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAutoMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayMarkAskMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayCurrentFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAutomaticForceBestMatchToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAutoMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskNfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskPoster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskExtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskTrailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrayFilterAskMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayCustomUpdaterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuTrayIconMediaCenters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuTrayIconTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortFilesIntoFoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetsManagerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearAllCachesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadAllMoviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanDatabaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuTrayIconSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuTrayIconExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrAppExit = New System.Windows.Forms.Timer(Me.components)
        Me.tmrKeyBuffer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrAni = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.pnlhInfo.SuspendLayout()
        Me.cmnuTrayIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 175)
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WikiStripMenuItem, Me.ToolStripSeparator18, Me.ToolStripSeparator19, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'WikiStripMenuItem
        '
        Me.WikiStripMenuItem.Image = CType(resources.GetObject("WikiStripMenuItem.Image"), System.Drawing.Image)
        Me.WikiStripMenuItem.Name = "WikiStripMenuItem"
        Me.WikiStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.WikiStripMenuItem.Text = "EmberMM.com &Wiki..."
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(182, 6)
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(182, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'StatusStrip
        '
        Me.StatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus, Me.tsSpring, Me.tslLoading, Me.tspbLoading})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 712)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1016, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip"
        '
        'tslStatus
        '
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(0, 17)
        Me.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsSpring
        '
        Me.tsSpring.Name = "tsSpring"
        Me.tsSpring.Size = New System.Drawing.Size(1001, 17)
        Me.tsSpring.Spring = True
        Me.tsSpring.Text = "  "
        '
        'tslLoading
        '
        Me.tslLoading.AutoSize = False
        Me.tslLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslLoading.Name = "tslLoading"
        Me.tslLoading.Size = New System.Drawing.Size(424, 17)
        Me.tslLoading.Text = "Loading Media:"
        Me.tslLoading.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tslLoading.Visible = False
        '
        'tspbLoading
        '
        Me.tspbLoading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tspbLoading.AutoSize = False
        Me.tspbLoading.MarqueeAnimationSpeed = 25
        Me.tspbLoading.Name = "tspbLoading"
        Me.tspbLoading.Size = New System.Drawing.Size(150, 16)
        Me.tspbLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspbLoading.Visible = False
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem, Me.DonateToolStripMenuItem, Me.ErrorToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CleanFoldersToolStripMenuItem, Me.ConvertFileSourceToFolderSourceToolStripMenuItem, Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem, Me.ToolStripSeparator4, Me.SetsManagerToolStripMenuItem, Me.ToolStripMenuItem3, Me.ClearAllCachesToolStripMenuItem, Me.RefreshAllMoviesToolStripMenuItem, Me.CleanDatabaseToolStripMenuItem, Me.ToolStripSeparator5})
        Me.ToolsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'CleanFoldersToolStripMenuItem
        '
        Me.CleanFoldersToolStripMenuItem.Image = CType(resources.GetObject("CleanFoldersToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CleanFoldersToolStripMenuItem.Name = "CleanFoldersToolStripMenuItem"
        Me.CleanFoldersToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CleanFoldersToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.CleanFoldersToolStripMenuItem.Text = "&Clean Files"
        '
        'ConvertFileSourceToFolderSourceToolStripMenuItem
        '
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem.Image = CType(resources.GetObject("ConvertFileSourceToFolderSourceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem.Name = "ConvertFileSourceToFolderSourceToolStripMenuItem"
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.ConvertFileSourceToFolderSourceToolStripMenuItem.Text = "&Sort Files Into Folders"
        '
        'CopyExistingFanartToBackdropsFolderToolStripMenuItem
        '
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.Image = CType(resources.GetObject("CopyExistingFanartToBackdropsFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.Name = "CopyExistingFanartToBackdropsFolderToolStripMenuItem"
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem.Text = "Copy Existing Fanart To &Backdrops Folder"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(346, 6)
        '
        'SetsManagerToolStripMenuItem
        '
        Me.SetsManagerToolStripMenuItem.Image = CType(resources.GetObject("SetsManagerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetsManagerToolStripMenuItem.Name = "SetsManagerToolStripMenuItem"
        Me.SetsManagerToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.SetsManagerToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.SetsManagerToolStripMenuItem.Text = "Sets &Manager"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(346, 6)
        '
        'ClearAllCachesToolStripMenuItem
        '
        Me.ClearAllCachesToolStripMenuItem.Image = CType(resources.GetObject("ClearAllCachesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClearAllCachesToolStripMenuItem.Name = "ClearAllCachesToolStripMenuItem"
        Me.ClearAllCachesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ClearAllCachesToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.ClearAllCachesToolStripMenuItem.Text = "Clear &All Caches"
        '
        'RefreshAllMoviesToolStripMenuItem
        '
        Me.RefreshAllMoviesToolStripMenuItem.Image = CType(resources.GetObject("RefreshAllMoviesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshAllMoviesToolStripMenuItem.Name = "RefreshAllMoviesToolStripMenuItem"
        Me.RefreshAllMoviesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.RefreshAllMoviesToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.RefreshAllMoviesToolStripMenuItem.Text = "Re&load All Movies"
        '
        'CleanDatabaseToolStripMenuItem
        '
        Me.CleanDatabaseToolStripMenuItem.Image = CType(resources.GetObject("CleanDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CleanDatabaseToolStripMenuItem.Name = "CleanDatabaseToolStripMenuItem"
        Me.CleanDatabaseToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.CleanDatabaseToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.CleanDatabaseToolStripMenuItem.Text = "Clean Database"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(346, 6)
        '
        'DonateToolStripMenuItem
        '
        Me.DonateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DonateToolStripMenuItem.Image = CType(resources.GetObject("DonateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        Me.DonateToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.DonateToolStripMenuItem.Text = "Donate"
        '
        'ErrorToolStripMenuItem
        '
        Me.ErrorToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ErrorToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ErrorToolStripMenuItem.Image = CType(resources.GetObject("ErrorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ErrorToolStripMenuItem.Name = "ErrorToolStripMenuItem"
        Me.ErrorToolStripMenuItem.Size = New System.Drawing.Size(28, 20)
        Me.ErrorToolStripMenuItem.ToolTipText = "An Error Has Occurred"
        Me.ErrorToolStripMenuItem.Visible = False
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scMain.Location = New System.Drawing.Point(0, 24)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.scMain.Panel1.Controls.Add(Me.ucSidePanel)
        Me.scMain.Panel1.Margin = New System.Windows.Forms.Padding(3)
        Me.scMain.Panel1MinSize = 165
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.scMain.Panel2.Controls.Add(Me.pnlhInfo)
        Me.scMain.Panel2.Controls.Add(Me.pnlImages)
        Me.scMain.Panel2.Margin = New System.Windows.Forms.Padding(3)
        Me.scMain.Size = New System.Drawing.Size(1016, 688)
        Me.scMain.SplitterDistance = 364
        Me.scMain.TabIndex = 7
        Me.scMain.TabStop = False
        '
        'ucSidePanel
        '
        Me.ucSidePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucSidePanel.Location = New System.Drawing.Point(0, 0)
        Me.ucSidePanel.Name = "ucSidePanel"
        Me.ucSidePanel.Size = New System.Drawing.Size(364, 688)
        Me.ucSidePanel.TabIndex = 0
        '
        'pnlhInfo
        '
        Me.pnlhInfo.AssociatedSplitter = Nothing
        Me.pnlhInfo.BackColor = System.Drawing.Color.Transparent
        Me.pnlhInfo.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlhInfo.CaptionHeight = 20
        Me.pnlhInfo.ColorScheme = BSE.Windows.Forms.ColorScheme.Custom
        Me.pnlhInfo.Controls.Add(Me.pnlInfoPanel)
        Me.pnlhInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlhInfo.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.pnlhInfo.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.pnlhInfo.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.pnlhInfo.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlhInfo.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.pnlhInfo.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlhInfo.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlhInfo.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlhInfo.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.pnlhInfo.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText
        Me.pnlhInfo.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace
        Me.pnlhInfo.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlhInfo.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.pnlhInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlhInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlhInfo.Image = Nothing
        Me.pnlhInfo.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlhInfo.Location = New System.Drawing.Point(0, 380)
        Me.pnlhInfo.MinimumSize = New System.Drawing.Size(20, 20)
        Me.pnlhInfo.Name = "pnlhInfo"
        Me.pnlhInfo.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.pnlhInfo.ShowExpandIcon = True
        Me.pnlhInfo.ShowTransparentBackground = False
        Me.pnlhInfo.ShowXPanderPanelProfessionalStyle = True
        Me.pnlhInfo.Size = New System.Drawing.Size(648, 308)
        Me.pnlhInfo.TabIndex = 17
        Me.pnlhInfo.Text = "Info"
        Me.pnlhInfo.ToolTipTextCloseIcon = Nothing
        Me.pnlhInfo.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.pnlhInfo.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'pnlInfoPanel
        '
        Me.pnlInfoPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfoPanel.Location = New System.Drawing.Point(1, 21)
        Me.pnlInfoPanel.Name = "pnlInfoPanel"
        Me.pnlInfoPanel.Size = New System.Drawing.Size(646, 286)
        Me.pnlInfoPanel.TabIndex = 16
        '
        'pnlImages
        '
        Me.pnlImages.BackColor = System.Drawing.Color.DimGray
        Me.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlImages.Location = New System.Drawing.Point(0, 0)
        Me.pnlImages.Name = "pnlImages"
        Me.pnlImages.Size = New System.Drawing.Size(648, 688)
        Me.pnlImages.TabIndex = 16
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
        'tmrWait
        '
        Me.tmrWait.Interval = 250
        '
        'ToolTips
        '
        Me.ToolTips.AutoPopDelay = 15000
        Me.ToolTips.InitialDelay = 500
        Me.ToolTips.ReshowDelay = 100
        '
        'tmrWaitShow
        '
        Me.tmrWaitShow.Interval = 250
        '
        'tmrWaitSeason
        '
        Me.tmrWaitSeason.Interval = 250
        '
        'tmrWaitEp
        '
        Me.tmrWaitEp.Interval = 250
        '
        'cmnuTrayIcon
        '
        Me.cmnuTrayIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuTrayIconTitle, Me.ToolStripSeparator21, Me.cmnuTrayIconUpdateMedia, Me.cmnuTrayIconScrapeMedia, Me.cmnuTrayIconMediaCenters, Me.ToolStripSeparator23, Me.cmnuTrayIconTools, Me.ToolStripSeparator22, Me.cmnuTrayIconSettings, Me.ToolStripSeparator13, Me.cmnuTrayIconExit})
        Me.cmnuTrayIcon.Name = "cmnuTrayIcon"
        Me.cmnuTrayIcon.Size = New System.Drawing.Size(195, 182)
        Me.cmnuTrayIcon.Text = "Ember Media Manager"
        '
        'cmnuTrayIconTitle
        '
        Me.cmnuTrayIconTitle.Enabled = False
        Me.cmnuTrayIconTitle.Image = CType(resources.GetObject("cmnuTrayIconTitle.Image"), System.Drawing.Image)
        Me.cmnuTrayIconTitle.Name = "cmnuTrayIconTitle"
        Me.cmnuTrayIconTitle.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconTitle.Text = "Ember Media Manager"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(191, 6)
        '
        'cmnuTrayIconUpdateMedia
        '
        Me.cmnuTrayIconUpdateMedia.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuTrayIconUpdateMovies, Me.cmnuTrayIconUpdateTV})
        Me.cmnuTrayIconUpdateMedia.Image = CType(resources.GetObject("cmnuTrayIconUpdateMedia.Image"), System.Drawing.Image)
        Me.cmnuTrayIconUpdateMedia.Name = "cmnuTrayIconUpdateMedia"
        Me.cmnuTrayIconUpdateMedia.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconUpdateMedia.Text = "Update Media"
        '
        'cmnuTrayIconUpdateMovies
        '
        Me.cmnuTrayIconUpdateMovies.Name = "cmnuTrayIconUpdateMovies"
        Me.cmnuTrayIconUpdateMovies.Size = New System.Drawing.Size(125, 22)
        Me.cmnuTrayIconUpdateMovies.Text = "Movies"
        '
        'cmnuTrayIconUpdateTV
        '
        Me.cmnuTrayIconUpdateTV.Name = "cmnuTrayIconUpdateTV"
        Me.cmnuTrayIconUpdateTV.Size = New System.Drawing.Size(125, 22)
        Me.cmnuTrayIconUpdateTV.Text = "TV Shows"
        '
        'cmnuTrayIconScrapeMedia
        '
        Me.cmnuTrayIconScrapeMedia.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayFullToolStripMenuItem, Me.TrayUpdateOnlyToolStripMenuItem, Me.TrayNewMoviesToolStripMenuItem, Me.TrayMarkedMoviesToolStripMenuItem, Me.TrayCurrentFilterToolStripMenuItem, Me.TrayCustomUpdaterToolStripMenuItem})
        Me.cmnuTrayIconScrapeMedia.Image = CType(resources.GetObject("cmnuTrayIconScrapeMedia.Image"), System.Drawing.Image)
        Me.cmnuTrayIconScrapeMedia.Name = "cmnuTrayIconScrapeMedia"
        Me.cmnuTrayIconScrapeMedia.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconScrapeMedia.Text = "Scrape Media"
        '
        'TrayFullToolStripMenuItem
        '
        Me.TrayFullToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayFullAutoToolStripMenuItem, Me.TrayFullAskToolStripMenuItem})
        Me.TrayFullToolStripMenuItem.Name = "TrayFullToolStripMenuItem"
        Me.TrayFullToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayFullToolStripMenuItem.Text = "All Movies"
        '
        'TrayFullAutoToolStripMenuItem
        '
        Me.TrayFullAutoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayAllAutoAll, Me.mnuTrayAllAutoNfo, Me.mnuTrayAllAutoPoster, Me.mnuTrayAllAutoFanart, Me.mnuTrayAllAutoExtra, Me.mnuTrayAllAutoTrailer, Me.mnuTrayAllAutoMI})
        Me.TrayFullAutoToolStripMenuItem.Name = "TrayFullAutoToolStripMenuItem"
        Me.TrayFullAutoToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayFullAutoToolStripMenuItem.Text = "Automatic (Force Best Match)"
        '
        'mnuTrayAllAutoAll
        '
        Me.mnuTrayAllAutoAll.Name = "mnuTrayAllAutoAll"
        Me.mnuTrayAllAutoAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoAll.Text = "All Items"
        '
        'mnuTrayAllAutoNfo
        '
        Me.mnuTrayAllAutoNfo.Name = "mnuTrayAllAutoNfo"
        Me.mnuTrayAllAutoNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoNfo.Text = "NFO Only"
        '
        'mnuTrayAllAutoPoster
        '
        Me.mnuTrayAllAutoPoster.Name = "mnuTrayAllAutoPoster"
        Me.mnuTrayAllAutoPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoPoster.Text = "Poster Only"
        '
        'mnuTrayAllAutoFanart
        '
        Me.mnuTrayAllAutoFanart.Name = "mnuTrayAllAutoFanart"
        Me.mnuTrayAllAutoFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoFanart.Text = "Fanart Only"
        '
        'mnuTrayAllAutoExtra
        '
        Me.mnuTrayAllAutoExtra.Name = "mnuTrayAllAutoExtra"
        Me.mnuTrayAllAutoExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayAllAutoTrailer
        '
        Me.mnuTrayAllAutoTrailer.Name = "mnuTrayAllAutoTrailer"
        Me.mnuTrayAllAutoTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoTrailer.Text = "Trailer Only"
        '
        'mnuTrayAllAutoMI
        '
        Me.mnuTrayAllAutoMI.Name = "mnuTrayAllAutoMI"
        Me.mnuTrayAllAutoMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAutoMI.Text = "Meta Data Only"
        '
        'TrayFullAskToolStripMenuItem
        '
        Me.TrayFullAskToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayAllAskAll, Me.mnuTrayAllAskNfo, Me.mnuTrayAllAskPoster, Me.mnuTrayAllAskFanart, Me.mnuTrayAllAskExtra, Me.mnuTrayAllAskTrailer, Me.mnuTrayAllAskMI})
        Me.TrayFullAskToolStripMenuItem.Name = "TrayFullAskToolStripMenuItem"
        Me.TrayFullAskToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayFullAskToolStripMenuItem.Text = "Ask (Require Input If No Exact Match)"
        '
        'mnuTrayAllAskAll
        '
        Me.mnuTrayAllAskAll.Name = "mnuTrayAllAskAll"
        Me.mnuTrayAllAskAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskAll.Text = "All Items"
        '
        'mnuTrayAllAskNfo
        '
        Me.mnuTrayAllAskNfo.Name = "mnuTrayAllAskNfo"
        Me.mnuTrayAllAskNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskNfo.Text = "NFO Only"
        '
        'mnuTrayAllAskPoster
        '
        Me.mnuTrayAllAskPoster.Name = "mnuTrayAllAskPoster"
        Me.mnuTrayAllAskPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskPoster.Text = "Poster Only"
        '
        'mnuTrayAllAskFanart
        '
        Me.mnuTrayAllAskFanart.Name = "mnuTrayAllAskFanart"
        Me.mnuTrayAllAskFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskFanart.Text = "Fanart Only"
        '
        'mnuTrayAllAskExtra
        '
        Me.mnuTrayAllAskExtra.Name = "mnuTrayAllAskExtra"
        Me.mnuTrayAllAskExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayAllAskTrailer
        '
        Me.mnuTrayAllAskTrailer.Name = "mnuTrayAllAskTrailer"
        Me.mnuTrayAllAskTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskTrailer.Text = "Trailer Only"
        '
        'mnuTrayAllAskMI
        '
        Me.mnuTrayAllAskMI.Name = "mnuTrayAllAskMI"
        Me.mnuTrayAllAskMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayAllAskMI.Text = "Meta Data Only"
        '
        'TrayUpdateOnlyToolStripMenuItem
        '
        Me.TrayUpdateOnlyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayUpdateAutoToolStripMenuItem, Me.TrayUpdateAskToolStripMenuItem})
        Me.TrayUpdateOnlyToolStripMenuItem.Name = "TrayUpdateOnlyToolStripMenuItem"
        Me.TrayUpdateOnlyToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayUpdateOnlyToolStripMenuItem.Text = "Movies Missing Items"
        '
        'TrayUpdateAutoToolStripMenuItem
        '
        Me.TrayUpdateAutoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayMissAutoAll, Me.mnuTrayMissAutoNfo, Me.mnuTrayMissAutoPoster, Me.mnuTrayMissAutoFanart, Me.mnuTrayMissAutoExtra, Me.mnuTrayMissAutoTrailer})
        Me.TrayUpdateAutoToolStripMenuItem.Name = "TrayUpdateAutoToolStripMenuItem"
        Me.TrayUpdateAutoToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayUpdateAutoToolStripMenuItem.Text = "Automatic (Force Best Match)"
        '
        'mnuTrayMissAutoAll
        '
        Me.mnuTrayMissAutoAll.Name = "mnuTrayMissAutoAll"
        Me.mnuTrayMissAutoAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoAll.Text = "All Items"
        '
        'mnuTrayMissAutoNfo
        '
        Me.mnuTrayMissAutoNfo.Name = "mnuTrayMissAutoNfo"
        Me.mnuTrayMissAutoNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoNfo.Text = "NFO Only"
        '
        'mnuTrayMissAutoPoster
        '
        Me.mnuTrayMissAutoPoster.Name = "mnuTrayMissAutoPoster"
        Me.mnuTrayMissAutoPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoPoster.Text = "Poster Only"
        '
        'mnuTrayMissAutoFanart
        '
        Me.mnuTrayMissAutoFanart.Name = "mnuTrayMissAutoFanart"
        Me.mnuTrayMissAutoFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoFanart.Text = "Fanart Only"
        '
        'mnuTrayMissAutoExtra
        '
        Me.mnuTrayMissAutoExtra.Name = "mnuTrayMissAutoExtra"
        Me.mnuTrayMissAutoExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayMissAutoTrailer
        '
        Me.mnuTrayMissAutoTrailer.Name = "mnuTrayMissAutoTrailer"
        Me.mnuTrayMissAutoTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAutoTrailer.Text = "Trailer Only"
        '
        'TrayUpdateAskToolStripMenuItem
        '
        Me.TrayUpdateAskToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayMissAskAll, Me.mnuTrayMissAskNfo, Me.mnuTrayMissAskPoster, Me.mnuTrayMissAskFanart, Me.mnuTrayMissAskExtra, Me.mnuTrayMissAskTrailer})
        Me.TrayUpdateAskToolStripMenuItem.Name = "TrayUpdateAskToolStripMenuItem"
        Me.TrayUpdateAskToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayUpdateAskToolStripMenuItem.Text = "Ask (Require Input If No Exact Match)"
        '
        'mnuTrayMissAskAll
        '
        Me.mnuTrayMissAskAll.Name = "mnuTrayMissAskAll"
        Me.mnuTrayMissAskAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskAll.Text = "All Items"
        '
        'mnuTrayMissAskNfo
        '
        Me.mnuTrayMissAskNfo.Name = "mnuTrayMissAskNfo"
        Me.mnuTrayMissAskNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskNfo.Text = "NFO Only"
        '
        'mnuTrayMissAskPoster
        '
        Me.mnuTrayMissAskPoster.Name = "mnuTrayMissAskPoster"
        Me.mnuTrayMissAskPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskPoster.Text = "Poster Only"
        '
        'mnuTrayMissAskFanart
        '
        Me.mnuTrayMissAskFanart.Name = "mnuTrayMissAskFanart"
        Me.mnuTrayMissAskFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskFanart.Text = "Fanart Only"
        '
        'mnuTrayMissAskExtra
        '
        Me.mnuTrayMissAskExtra.Name = "mnuTrayMissAskExtra"
        Me.mnuTrayMissAskExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayMissAskTrailer
        '
        Me.mnuTrayMissAskTrailer.Name = "mnuTrayMissAskTrailer"
        Me.mnuTrayMissAskTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMissAskTrailer.Text = "Trailer Only"
        '
        'TrayNewMoviesToolStripMenuItem
        '
        Me.TrayNewMoviesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayAutomaticForceBestMatchToolStripMenuItem, Me.TrayAskRequireInputToolStripMenuItem})
        Me.TrayNewMoviesToolStripMenuItem.Name = "TrayNewMoviesToolStripMenuItem"
        Me.TrayNewMoviesToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayNewMoviesToolStripMenuItem.Text = "New Movies"
        '
        'TrayAutomaticForceBestMatchToolStripMenuItem
        '
        Me.TrayAutomaticForceBestMatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayNewAutoAll, Me.mnuTrayNewAutoNfo, Me.mnuTrayNewAutoPoster, Me.mnuTrayNewAutoFanart, Me.mnuTrayNewAutoExtra, Me.mnuTrayNewAutoTrailer, Me.mnuTrayNewAutoMI})
        Me.TrayAutomaticForceBestMatchToolStripMenuItem.Name = "TrayAutomaticForceBestMatchToolStripMenuItem"
        Me.TrayAutomaticForceBestMatchToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayAutomaticForceBestMatchToolStripMenuItem.Text = "Automatic (Force Best Match)"
        '
        'mnuTrayNewAutoAll
        '
        Me.mnuTrayNewAutoAll.Name = "mnuTrayNewAutoAll"
        Me.mnuTrayNewAutoAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoAll.Text = "All Items"
        '
        'mnuTrayNewAutoNfo
        '
        Me.mnuTrayNewAutoNfo.Name = "mnuTrayNewAutoNfo"
        Me.mnuTrayNewAutoNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoNfo.Text = "NFO Only"
        '
        'mnuTrayNewAutoPoster
        '
        Me.mnuTrayNewAutoPoster.Name = "mnuTrayNewAutoPoster"
        Me.mnuTrayNewAutoPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoPoster.Text = "Poster Only"
        '
        'mnuTrayNewAutoFanart
        '
        Me.mnuTrayNewAutoFanart.Name = "mnuTrayNewAutoFanart"
        Me.mnuTrayNewAutoFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoFanart.Text = "Fanart Only"
        '
        'mnuTrayNewAutoExtra
        '
        Me.mnuTrayNewAutoExtra.Name = "mnuTrayNewAutoExtra"
        Me.mnuTrayNewAutoExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayNewAutoTrailer
        '
        Me.mnuTrayNewAutoTrailer.Name = "mnuTrayNewAutoTrailer"
        Me.mnuTrayNewAutoTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoTrailer.Text = "Trailer Only"
        '
        'mnuTrayNewAutoMI
        '
        Me.mnuTrayNewAutoMI.Name = "mnuTrayNewAutoMI"
        Me.mnuTrayNewAutoMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAutoMI.Text = "Meta Data Only"
        '
        'TrayAskRequireInputToolStripMenuItem
        '
        Me.TrayAskRequireInputToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayNewAskAll, Me.mnuTrayNewAskNfo, Me.mnuTrayNewAskPoster, Me.mnuTrayNewAskFanart, Me.mnuTrayNewAskExtra, Me.mnuTrayNewAskTrailer, Me.mnuTrayNewAskMI})
        Me.TrayAskRequireInputToolStripMenuItem.Name = "TrayAskRequireInputToolStripMenuItem"
        Me.TrayAskRequireInputToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayAskRequireInputToolStripMenuItem.Text = "Ask (Require Input If No Exact Match)"
        '
        'mnuTrayNewAskAll
        '
        Me.mnuTrayNewAskAll.Name = "mnuTrayNewAskAll"
        Me.mnuTrayNewAskAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskAll.Text = "All Items"
        '
        'mnuTrayNewAskNfo
        '
        Me.mnuTrayNewAskNfo.Name = "mnuTrayNewAskNfo"
        Me.mnuTrayNewAskNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskNfo.Text = "NFO Only"
        '
        'mnuTrayNewAskPoster
        '
        Me.mnuTrayNewAskPoster.Name = "mnuTrayNewAskPoster"
        Me.mnuTrayNewAskPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskPoster.Text = "Poster Only"
        '
        'mnuTrayNewAskFanart
        '
        Me.mnuTrayNewAskFanart.Name = "mnuTrayNewAskFanart"
        Me.mnuTrayNewAskFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskFanart.Text = "Fanart Only"
        '
        'mnuTrayNewAskExtra
        '
        Me.mnuTrayNewAskExtra.Name = "mnuTrayNewAskExtra"
        Me.mnuTrayNewAskExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayNewAskTrailer
        '
        Me.mnuTrayNewAskTrailer.Name = "mnuTrayNewAskTrailer"
        Me.mnuTrayNewAskTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskTrailer.Text = "Trailer Only"
        '
        'mnuTrayNewAskMI
        '
        Me.mnuTrayNewAskMI.Name = "mnuTrayNewAskMI"
        Me.mnuTrayNewAskMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayNewAskMI.Text = "Meta Data Only"
        '
        'TrayMarkedMoviesToolStripMenuItem
        '
        Me.TrayMarkedMoviesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayAutomaticForceBestMatchToolStripMenuItem1, Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem})
        Me.TrayMarkedMoviesToolStripMenuItem.Name = "TrayMarkedMoviesToolStripMenuItem"
        Me.TrayMarkedMoviesToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayMarkedMoviesToolStripMenuItem.Text = "Marked Movies"
        '
        'TrayAutomaticForceBestMatchToolStripMenuItem1
        '
        Me.TrayAutomaticForceBestMatchToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayMarkAutoAll, Me.mnuTrayMarkAutoNfo, Me.mnuTrayMarkAutoPoster, Me.mnuTrayMarkAutoFanart, Me.mnuTrayMarkAutoExtra, Me.mnuTrayMarkAutoTrailer, Me.mnuTrayMarkAutoMI})
        Me.TrayAutomaticForceBestMatchToolStripMenuItem1.Name = "TrayAutomaticForceBestMatchToolStripMenuItem1"
        Me.TrayAutomaticForceBestMatchToolStripMenuItem1.Size = New System.Drawing.Size(271, 22)
        Me.TrayAutomaticForceBestMatchToolStripMenuItem1.Text = "Automatic (Force Best Match)"
        '
        'mnuTrayMarkAutoAll
        '
        Me.mnuTrayMarkAutoAll.Name = "mnuTrayMarkAutoAll"
        Me.mnuTrayMarkAutoAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoAll.Text = "All Items"
        '
        'mnuTrayMarkAutoNfo
        '
        Me.mnuTrayMarkAutoNfo.Name = "mnuTrayMarkAutoNfo"
        Me.mnuTrayMarkAutoNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoNfo.Text = "NFO Only"
        '
        'mnuTrayMarkAutoPoster
        '
        Me.mnuTrayMarkAutoPoster.Name = "mnuTrayMarkAutoPoster"
        Me.mnuTrayMarkAutoPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoPoster.Text = "Poster Only"
        '
        'mnuTrayMarkAutoFanart
        '
        Me.mnuTrayMarkAutoFanart.Name = "mnuTrayMarkAutoFanart"
        Me.mnuTrayMarkAutoFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoFanart.Text = "Fanart Only"
        '
        'mnuTrayMarkAutoExtra
        '
        Me.mnuTrayMarkAutoExtra.Name = "mnuTrayMarkAutoExtra"
        Me.mnuTrayMarkAutoExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayMarkAutoTrailer
        '
        Me.mnuTrayMarkAutoTrailer.Name = "mnuTrayMarkAutoTrailer"
        Me.mnuTrayMarkAutoTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoTrailer.Text = "Trailer Only"
        '
        'mnuTrayMarkAutoMI
        '
        Me.mnuTrayMarkAutoMI.Name = "mnuTrayMarkAutoMI"
        Me.mnuTrayMarkAutoMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAutoMI.Text = "Meta Data Only"
        '
        'TrayAskRequireInputIfNoExactMatchToolStripMenuItem
        '
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayMarkAskAll, Me.mnuTrayMarkAskNfo, Me.mnuTrayMarkAskPoster, Me.mnuTrayMarkAskFanart, Me.mnuTrayMarkAskExtra, Me.mnuTrayMarkAskTrailer, Me.mnuTrayMarkAskMI})
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem.Name = "TrayAskRequireInputIfNoExactMatchToolStripMenuItem"
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem.Text = "Ask (Require Input If No Exact Match)"
        '
        'mnuTrayMarkAskAll
        '
        Me.mnuTrayMarkAskAll.Name = "mnuTrayMarkAskAll"
        Me.mnuTrayMarkAskAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskAll.Text = "All Items"
        '
        'mnuTrayMarkAskNfo
        '
        Me.mnuTrayMarkAskNfo.Name = "mnuTrayMarkAskNfo"
        Me.mnuTrayMarkAskNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskNfo.Text = "NFO Only"
        '
        'mnuTrayMarkAskPoster
        '
        Me.mnuTrayMarkAskPoster.Name = "mnuTrayMarkAskPoster"
        Me.mnuTrayMarkAskPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskPoster.Text = "Poster Only"
        '
        'mnuTrayMarkAskFanart
        '
        Me.mnuTrayMarkAskFanart.Name = "mnuTrayMarkAskFanart"
        Me.mnuTrayMarkAskFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskFanart.Text = "Fanart Only"
        '
        'mnuTrayMarkAskExtra
        '
        Me.mnuTrayMarkAskExtra.Name = "mnuTrayMarkAskExtra"
        Me.mnuTrayMarkAskExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayMarkAskTrailer
        '
        Me.mnuTrayMarkAskTrailer.Name = "mnuTrayMarkAskTrailer"
        Me.mnuTrayMarkAskTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskTrailer.Text = "Trailer Only"
        '
        'mnuTrayMarkAskMI
        '
        Me.mnuTrayMarkAskMI.Name = "mnuTrayMarkAskMI"
        Me.mnuTrayMarkAskMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayMarkAskMI.Text = "Meta Data Only"
        '
        'TrayCurrentFilterToolStripMenuItem
        '
        Me.TrayCurrentFilterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayAutomaticForceBestMatchToolStripMenuItem2, Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1})
        Me.TrayCurrentFilterToolStripMenuItem.Name = "TrayCurrentFilterToolStripMenuItem"
        Me.TrayCurrentFilterToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayCurrentFilterToolStripMenuItem.Text = "Current Filter"
        '
        'TrayAutomaticForceBestMatchToolStripMenuItem2
        '
        Me.TrayAutomaticForceBestMatchToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayFilterAutoAll, Me.mnuTrayFilterAutoNfo, Me.mnuTrayFilterAutoPoster, Me.mnuTrayFilterAutoFanart, Me.mnuTrayFilterAutoExtra, Me.mnuTrayFilterAutoTrailer, Me.mnuTrayFilterAutoMI})
        Me.TrayAutomaticForceBestMatchToolStripMenuItem2.Name = "TrayAutomaticForceBestMatchToolStripMenuItem2"
        Me.TrayAutomaticForceBestMatchToolStripMenuItem2.Size = New System.Drawing.Size(271, 22)
        Me.TrayAutomaticForceBestMatchToolStripMenuItem2.Text = "Automatic (Force Best Match)"
        '
        'mnuTrayFilterAutoAll
        '
        Me.mnuTrayFilterAutoAll.Name = "mnuTrayFilterAutoAll"
        Me.mnuTrayFilterAutoAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoAll.Text = "All Items"
        '
        'mnuTrayFilterAutoNfo
        '
        Me.mnuTrayFilterAutoNfo.Name = "mnuTrayFilterAutoNfo"
        Me.mnuTrayFilterAutoNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoNfo.Text = "NFO Only"
        '
        'mnuTrayFilterAutoPoster
        '
        Me.mnuTrayFilterAutoPoster.Name = "mnuTrayFilterAutoPoster"
        Me.mnuTrayFilterAutoPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoPoster.Text = "Poster Only"
        '
        'mnuTrayFilterAutoFanart
        '
        Me.mnuTrayFilterAutoFanart.Name = "mnuTrayFilterAutoFanart"
        Me.mnuTrayFilterAutoFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoFanart.Text = "Fanart Only"
        '
        'mnuTrayFilterAutoExtra
        '
        Me.mnuTrayFilterAutoExtra.Name = "mnuTrayFilterAutoExtra"
        Me.mnuTrayFilterAutoExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayFilterAutoTrailer
        '
        Me.mnuTrayFilterAutoTrailer.Name = "mnuTrayFilterAutoTrailer"
        Me.mnuTrayFilterAutoTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoTrailer.Text = "Trailer Only"
        '
        'mnuTrayFilterAutoMI
        '
        Me.mnuTrayFilterAutoMI.Name = "mnuTrayFilterAutoMI"
        Me.mnuTrayFilterAutoMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAutoMI.Text = "Meta Data Only"
        '
        'TrayAskRequireInputIfNoExactMatchToolStripMenuItem1
        '
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrayFilterAskAll, Me.mnuTrayFilterAskNfo, Me.mnuTrayFilterAskPoster, Me.mnuTrayFilterAskFanart, Me.mnuTrayFilterAskExtra, Me.mnuTrayFilterAskTrailer, Me.mnuTrayFilterAskMI})
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1.Name = "TrayAskRequireInputIfNoExactMatchToolStripMenuItem1"
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1.Size = New System.Drawing.Size(271, 22)
        Me.TrayAskRequireInputIfNoExactMatchToolStripMenuItem1.Text = "Ask (Require Input If No Exact Match)"
        '
        'mnuTrayFilterAskAll
        '
        Me.mnuTrayFilterAskAll.Name = "mnuTrayFilterAskAll"
        Me.mnuTrayFilterAskAll.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskAll.Text = "All Items"
        '
        'mnuTrayFilterAskNfo
        '
        Me.mnuTrayFilterAskNfo.Name = "mnuTrayFilterAskNfo"
        Me.mnuTrayFilterAskNfo.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskNfo.Text = "NFO Only"
        '
        'mnuTrayFilterAskPoster
        '
        Me.mnuTrayFilterAskPoster.Name = "mnuTrayFilterAskPoster"
        Me.mnuTrayFilterAskPoster.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskPoster.Text = "Poster Only"
        '
        'mnuTrayFilterAskFanart
        '
        Me.mnuTrayFilterAskFanart.Name = "mnuTrayFilterAskFanart"
        Me.mnuTrayFilterAskFanart.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskFanart.Text = "Fanart Only"
        '
        'mnuTrayFilterAskExtra
        '
        Me.mnuTrayFilterAskExtra.Name = "mnuTrayFilterAskExtra"
        Me.mnuTrayFilterAskExtra.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskExtra.Text = "Extrathumbs Only"
        '
        'mnuTrayFilterAskTrailer
        '
        Me.mnuTrayFilterAskTrailer.Name = "mnuTrayFilterAskTrailer"
        Me.mnuTrayFilterAskTrailer.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskTrailer.Text = "Trailer Only"
        '
        'mnuTrayFilterAskMI
        '
        Me.mnuTrayFilterAskMI.Name = "mnuTrayFilterAskMI"
        Me.mnuTrayFilterAskMI.Size = New System.Drawing.Size(168, 22)
        Me.mnuTrayFilterAskMI.Text = "Meta Data Only"
        '
        'TrayCustomUpdaterToolStripMenuItem
        '
        Me.TrayCustomUpdaterToolStripMenuItem.Name = "TrayCustomUpdaterToolStripMenuItem"
        Me.TrayCustomUpdaterToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.TrayCustomUpdaterToolStripMenuItem.Text = "Custom Scraper..."
        '
        'cmnuTrayIconMediaCenters
        '
        Me.cmnuTrayIconMediaCenters.Image = CType(resources.GetObject("cmnuTrayIconMediaCenters.Image"), System.Drawing.Image)
        Me.cmnuTrayIconMediaCenters.Name = "cmnuTrayIconMediaCenters"
        Me.cmnuTrayIconMediaCenters.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconMediaCenters.Text = "Media Centers"
        Me.cmnuTrayIconMediaCenters.Visible = False
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(191, 6)
        '
        'cmnuTrayIconTools
        '
        Me.cmnuTrayIconTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CleanFilesToolStripMenuItem, Me.SortFilesIntoFoldersToolStripMenuItem, Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1, Me.ToolStripSeparator24, Me.SetsManagerToolStripMenuItem1, Me.ToolStripSeparator25, Me.ClearAllCachesToolStripMenuItem1, Me.ReloadAllMoviesToolStripMenuItem, Me.CleanDatabaseToolStripMenuItem1, Me.ToolStripSeparator26})
        Me.cmnuTrayIconTools.Image = CType(resources.GetObject("cmnuTrayIconTools.Image"), System.Drawing.Image)
        Me.cmnuTrayIconTools.Name = "cmnuTrayIconTools"
        Me.cmnuTrayIconTools.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconTools.Text = "Tools"
        '
        'CleanFilesToolStripMenuItem
        '
        Me.CleanFilesToolStripMenuItem.Image = CType(resources.GetObject("CleanFilesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CleanFilesToolStripMenuItem.Name = "CleanFilesToolStripMenuItem"
        Me.CleanFilesToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.CleanFilesToolStripMenuItem.Text = "Clean Files"
        '
        'SortFilesIntoFoldersToolStripMenuItem
        '
        Me.SortFilesIntoFoldersToolStripMenuItem.Image = CType(resources.GetObject("SortFilesIntoFoldersToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SortFilesIntoFoldersToolStripMenuItem.Name = "SortFilesIntoFoldersToolStripMenuItem"
        Me.SortFilesIntoFoldersToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.SortFilesIntoFoldersToolStripMenuItem.Text = "Sort Files into Folders"
        '
        'CopyExistingFanartToBackdropsFolderToolStripMenuItem1
        '
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Image = CType(resources.GetObject("CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Name = "CopyExistingFanartToBackdropsFolderToolStripMenuItem1"
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Size = New System.Drawing.Size(289, 22)
        Me.CopyExistingFanartToBackdropsFolderToolStripMenuItem1.Text = "Copy Existing Fanart to Backdrops Folder"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(286, 6)
        '
        'SetsManagerToolStripMenuItem1
        '
        Me.SetsManagerToolStripMenuItem1.Image = CType(resources.GetObject("SetsManagerToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.SetsManagerToolStripMenuItem1.Name = "SetsManagerToolStripMenuItem1"
        Me.SetsManagerToolStripMenuItem1.Size = New System.Drawing.Size(289, 22)
        Me.SetsManagerToolStripMenuItem1.Text = "Sets Manager"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(286, 6)
        '
        'ClearAllCachesToolStripMenuItem1
        '
        Me.ClearAllCachesToolStripMenuItem1.Image = CType(resources.GetObject("ClearAllCachesToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ClearAllCachesToolStripMenuItem1.Name = "ClearAllCachesToolStripMenuItem1"
        Me.ClearAllCachesToolStripMenuItem1.Size = New System.Drawing.Size(289, 22)
        Me.ClearAllCachesToolStripMenuItem1.Text = "Clear All Caches"
        '
        'ReloadAllMoviesToolStripMenuItem
        '
        Me.ReloadAllMoviesToolStripMenuItem.Image = CType(resources.GetObject("ReloadAllMoviesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReloadAllMoviesToolStripMenuItem.Name = "ReloadAllMoviesToolStripMenuItem"
        Me.ReloadAllMoviesToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.ReloadAllMoviesToolStripMenuItem.Text = "Reload All Movies"
        '
        'CleanDatabaseToolStripMenuItem1
        '
        Me.CleanDatabaseToolStripMenuItem1.Image = CType(resources.GetObject("CleanDatabaseToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CleanDatabaseToolStripMenuItem1.Name = "CleanDatabaseToolStripMenuItem1"
        Me.CleanDatabaseToolStripMenuItem1.Size = New System.Drawing.Size(289, 22)
        Me.CleanDatabaseToolStripMenuItem1.Text = "Clean Database"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(286, 6)
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(191, 6)
        '
        'cmnuTrayIconSettings
        '
        Me.cmnuTrayIconSettings.Image = CType(resources.GetObject("cmnuTrayIconSettings.Image"), System.Drawing.Image)
        Me.cmnuTrayIconSettings.Name = "cmnuTrayIconSettings"
        Me.cmnuTrayIconSettings.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconSettings.Text = "Settings..."
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(191, 6)
        '
        'cmnuTrayIconExit
        '
        Me.cmnuTrayIconExit.Image = CType(resources.GetObject("cmnuTrayIconExit.Image"), System.Drawing.Image)
        Me.cmnuTrayIconExit.Name = "cmnuTrayIconExit"
        Me.cmnuTrayIconExit.Size = New System.Drawing.Size(194, 22)
        Me.cmnuTrayIconExit.Text = "Exit"
        '
        'tmrAppExit
        '
        Me.tmrAppExit.Interval = 1000
        '
        'tmrKeyBuffer
        '
        Me.tmrKeyBuffer.Interval = 1000
        '
        'tmrAni
        '
        Me.tmrAni.Interval = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmMain"
        Me.Text = "Ember Media Manager"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.pnlhInfo.ResumeLayout(False)
        Me.cmnuTrayIcon.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslLoading As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbLoading As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
    Friend WithEvents ilColumnIcons As System.Windows.Forms.ImageList
    Friend WithEvents tmrWait As System.Windows.Forms.Timer
    Friend WithEvents tmrLoad As System.Windows.Forms.Timer
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanFoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertFileSourceToFolderSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyExistingFanartToBackdropsFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SetsManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearAllCachesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshAllMoviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents CleanDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DonateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrWaitShow As System.Windows.Forms.Timer
    Friend WithEvents tmrLoadShow As System.Windows.Forms.Timer
    Friend WithEvents tmrWaitSeason As System.Windows.Forms.Timer
    Friend WithEvents tmrLoadSeason As System.Windows.Forms.Timer
    Friend WithEvents tmrWaitEp As System.Windows.Forms.Timer
    Friend WithEvents tmrLoadEp As System.Windows.Forms.Timer
    Friend WithEvents tsSpring As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WikiStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmnuTrayIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuTrayIconExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuTrayIconTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuTrayIconUpdateMedia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuTrayIconScrapeMedia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuTrayIconTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuTrayIconSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuTrayIconMediaCenters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuTrayIconUpdateMovies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuTrayIconUpdateTV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortFilesIntoFoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyExistingFanartToBackdropsFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetsManagerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllCachesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadAllMoviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanDatabaseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TrayFullToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayFullAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayFullAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayUpdateOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayUpdateAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayUpdateAskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayNewMoviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAutomaticForceBestMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAskRequireInputToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayMarkedMoviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAutomaticForceBestMatchToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAskRequireInputIfNoExactMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayCurrentFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAutomaticForceBestMatchToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayAskRequireInputIfNoExactMatchToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAutoMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskNfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskPoster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskExtra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayFilterAskMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAutoTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMissAskTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskTrailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayCustomUpdaterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAutoMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayAllAskMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAutoMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayNewAskMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAutoMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrayMarkAskMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrAppExit As System.Windows.Forms.Timer
    Friend WithEvents tmrKeyBuffer As System.Windows.Forms.Timer
    Friend WithEvents tmrAni As System.Windows.Forms.Timer
    Friend WithEvents ucSidePanel As EmberMediaManger.SidePanel
    Friend WithEvents pnlImages As EmberMediaManger.ImagesPanel
    Friend WithEvents pnlhInfo As BSE.Windows.Forms.Panel
    Friend WithEvents pnlInfoPanel As EmberMediaManger.InfoPanel
End Class
