Imports EmberMediaManger.Modules.Extras
Imports EmberMediaManger.SettingsControls

Namespace Dialogs

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Settings
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Catch ex As Exception
            End Try
            Try
                'Finally
                MyBase.Dispose(disposing)
            Catch ex As Exception
            End Try
        End Sub

        Delegate Sub DelegateSub(ByVal b As Boolean)

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnApply = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.tvSettings = New System.Windows.Forms.TreeView()
            Me.ilPanelImages = New System.Windows.Forms.ImageList(Me.components)
            Me.lblCurrent = New System.Windows.Forms.Label()
            Me.pnlCurrent = New System.Windows.Forms.Panel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.pbCurrent = New System.Windows.Forms.PictureBox()
            Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.tsbOptions = New System.Windows.Forms.ToolStripButton()
            Me.tsbMovies = New System.Windows.Forms.ToolStripButton()
            Me.tsbTVhows = New System.Windows.Forms.ToolStripButton()
            Me.tsbModules = New System.Windows.Forms.ToolStripButton()
            Me.tsbMiscellaneous = New System.Windows.Forms.ToolStripButton()
            Me.gbHelp = New System.Windows.Forms.GroupBox()
            Me.PictureBox2 = New System.Windows.Forms.PictureBox()
            Me.lblHelp = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.SettingsPanelManager = New EmberControls.PanelManager()
            Me.XbmcSettings = New EmberMediaManger.Modules.XBMC.XBMCSettings()
            Me.NotificationSettings = New EmberMediaManger.Modules.Notifications.NotificationSettings()
            Me.pnlTvScraper = New EmberMediaManger.SettingsControls.TVScraper()
            Me.pnlTvImages = New EmberMediaManger.SettingsControls.TVImages()
            Me.BulkRenamerSettings = New EmberMediaManger.Modules.BulkRename.BulkRenamerSettings()
            Me.pnlSources = New EmberMediaManger.SettingsControls.Sources()
            Me.MediaSourcesEditor = New EmberMediaManger.Modules.Extras.MediaSourcesEditor()
            Me.pnlTVSources = New EmberMediaManger.SettingsControls.TVSources()
            Me.pnlTVShows = New EmberMediaManger.SettingsControls.Shows()
            Me.pnlScraper = New EmberMediaManger.SettingsControls.Scraper()
            Me.pnlMovies = New EmberMediaManger.SettingsControls.Movies()
            Me.pnlMovieMedia = New EmberMediaManger.SettingsControls.Images()
            Me.pnlExtensions = New EmberMediaManger.SettingsControls.Extensions()
            Me.pnlGeneral = New EmberMediaManger.SettingsControls.General()
            Me.AvCodecEditor = New EmberMediaManger.Modules.Extras.AVCodecEditor()
            Me.GenresEditorPanel = New EmberMediaManger.Modules.Extras.GenresEditor()
            Me.pnlScraperSettings = New EmberMediaManger.SettingsControls.ScraperSettings()
            Me.pnlTop.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip1.SuspendLayout()
            Me.gbHelp.SuspendLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SettingsPanelManager.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnOK.Location = New System.Drawing.Point(813, 601)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(75, 23)
            Me.btnOK.TabIndex = 22
            Me.btnOK.Text = "OK"
            Me.btnOK.UseVisualStyleBackColor = True
            '
            'btnApply
            '
            Me.btnApply.Enabled = False
            Me.btnApply.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnApply.Location = New System.Drawing.Point(650, 601)
            Me.btnApply.Name = "btnApply"
            Me.btnApply.Size = New System.Drawing.Size(75, 23)
            Me.btnApply.TabIndex = 20
            Me.btnApply.Text = "Apply"
            Me.btnApply.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(732, 601)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 21
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlTop.Controls.Add(Me.Label2)
            Me.pnlTop.Controls.Add(Me.Label4)
            Me.pnlTop.Controls.Add(Me.PictureBox1)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Size = New System.Drawing.Size(894, 64)
            Me.pnlTop.TabIndex = 57
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(61, 38)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(246, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Configure Ember's appearance and operation."
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(58, 3)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(107, 32)
            Me.Label4.TabIndex = 1
            Me.Label4.Text = "Settings"
            '
            'PictureBox1
            '
            Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox1.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_Settings
            Me.PictureBox1.Location = New System.Drawing.Point(7, 8)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            '
            'tvSettings
            '
            Me.tvSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tvSettings.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tvSettings.FullRowSelect = True
            Me.tvSettings.HideSelection = False
            Me.tvSettings.ImageIndex = 0
            Me.tvSettings.ImageList = Me.ilPanelImages
            Me.tvSettings.Location = New System.Drawing.Point(5, 147)
            Me.tvSettings.Name = "tvSettings"
            Me.tvSettings.SelectedImageIndex = 0
            Me.tvSettings.ShowLines = False
            Me.tvSettings.ShowPlusMinus = False
            Me.tvSettings.Size = New System.Drawing.Size(242, 401)
            Me.tvSettings.TabIndex = 58
            '
            'ilPanelImages
            '
            Me.ilPanelImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.ilPanelImages.ImageSize = New System.Drawing.Size(24, 24)
            Me.ilPanelImages.TransparentColor = System.Drawing.Color.Transparent
            '
            'lblCurrent
            '
            Me.lblCurrent.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrent.ForeColor = System.Drawing.Color.White
            Me.lblCurrent.Location = New System.Drawing.Point(26, -1)
            Me.lblCurrent.Name = "lblCurrent"
            Me.lblCurrent.Size = New System.Drawing.Size(489, 25)
            Me.lblCurrent.TabIndex = 63
            Me.lblCurrent.Text = "General"
            '
            'pnlCurrent
            '
            Me.pnlCurrent.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlCurrent.Location = New System.Drawing.Point(516, 119)
            Me.pnlCurrent.Name = "pnlCurrent"
            Me.pnlCurrent.Size = New System.Drawing.Size(371, 25)
            Me.pnlCurrent.TabIndex = 64
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel1.Controls.Add(Me.pbCurrent)
            Me.Panel1.Controls.Add(Me.lblCurrent)
            Me.Panel1.Location = New System.Drawing.Point(5, 119)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(515, 25)
            Me.Panel1.TabIndex = 65
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
            'ToolStrip1
            '
            Me.ToolStrip1.AllowMerge = False
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOptions, Me.tsbMovies, Me.tsbTVhows, Me.tsbModules, Me.tsbMiscellaneous})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 64)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(894, 54)
            Me.ToolStrip1.Stretch = True
            Me.ToolStrip1.TabIndex = 74
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'tsbOptions
            '
            Me.tsbOptions.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_General
            Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbOptions.Name = "tsbOptions"
            Me.tsbOptions.Size = New System.Drawing.Size(53, 51)
            Me.tsbOptions.Tag = "100"
            Me.tsbOptions.Text = "Options"
            Me.tsbOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'tsbMovies
            '
            Me.tsbMovies.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_Movies
            Me.tsbMovies.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbMovies.Name = "tsbMovies"
            Me.tsbMovies.Size = New System.Drawing.Size(49, 51)
            Me.tsbMovies.Tag = "200"
            Me.tsbMovies.Text = "Movies"
            Me.tsbMovies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'tsbTVhows
            '
            Me.tsbTVhows.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_TV
            Me.tsbTVhows.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbTVhows.Name = "tsbTVhows"
            Me.tsbTVhows.Size = New System.Drawing.Size(62, 51)
            Me.tsbTVhows.Tag = "300"
            Me.tsbTVhows.Text = "TV Shows"
            Me.tsbTVhows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'tsbModules
            '
            Me.tsbModules.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_Modules
            Me.tsbModules.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbModules.Name = "tsbModules"
            Me.tsbModules.Size = New System.Drawing.Size(57, 51)
            Me.tsbModules.Tag = "400"
            Me.tsbModules.Text = "Modules"
            Me.tsbModules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'tsbMiscellaneous
            '
            Me.tsbMiscellaneous.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_Miscellaneous
            Me.tsbMiscellaneous.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbMiscellaneous.Name = "tsbMiscellaneous"
            Me.tsbMiscellaneous.Size = New System.Drawing.Size(86, 51)
            Me.tsbMiscellaneous.Text = "Miscellaneous"
            Me.tsbMiscellaneous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'gbHelp
            '
            Me.gbHelp.BackColor = System.Drawing.Color.White
            Me.gbHelp.Controls.Add(Me.PictureBox2)
            Me.gbHelp.Controls.Add(Me.lblHelp)
            Me.gbHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbHelp.Location = New System.Drawing.Point(3, 3)
            Me.gbHelp.Name = "gbHelp"
            Me.gbHelp.Size = New System.Drawing.Size(628, 62)
            Me.gbHelp.TabIndex = 76
            Me.gbHelp.TabStop = False
            Me.gbHelp.Text = "     Help"
            '
            'PictureBox2
            '
            Me.PictureBox2.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Help
            Me.PictureBox2.Location = New System.Drawing.Point(6, -2)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
            Me.PictureBox2.TabIndex = 1
            Me.PictureBox2.TabStop = False
            '
            'lblHelp
            '
            Me.lblHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHelp.Location = New System.Drawing.Point(3, 14)
            Me.lblHelp.Name = "lblHelp"
            Me.lblHelp.Size = New System.Drawing.Size(622, 43)
            Me.lblHelp.TabIndex = 0
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.gbHelp)
            Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Panel2.Location = New System.Drawing.Point(5, 555)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(636, 69)
            Me.Panel2.TabIndex = 77
            '
            'SettingsPanelManager
            '
            Me.SettingsPanelManager.Controls.Add(Me.XbmcSettings)
            Me.SettingsPanelManager.Controls.Add(Me.NotificationSettings)
            Me.SettingsPanelManager.Controls.Add(Me.pnlTvScraper)
            Me.SettingsPanelManager.Controls.Add(Me.pnlTvImages)
            Me.SettingsPanelManager.Controls.Add(Me.BulkRenamerSettings)
            Me.SettingsPanelManager.Controls.Add(Me.pnlSources)
            Me.SettingsPanelManager.Controls.Add(Me.MediaSourcesEditor)
            Me.SettingsPanelManager.Controls.Add(Me.pnlTVSources)
            Me.SettingsPanelManager.Controls.Add(Me.pnlTVShows)
            Me.SettingsPanelManager.Controls.Add(Me.pnlScraper)
            Me.SettingsPanelManager.Controls.Add(Me.pnlMovies)
            Me.SettingsPanelManager.Controls.Add(Me.pnlMovieMedia)
            Me.SettingsPanelManager.Controls.Add(Me.pnlExtensions)
            Me.SettingsPanelManager.Controls.Add(Me.pnlGeneral)
            Me.SettingsPanelManager.Controls.Add(Me.AvCodecEditor)
            Me.SettingsPanelManager.Controls.Add(Me.GenresEditorPanel)
            Me.SettingsPanelManager.Controls.Add(Me.pnlScraperSettings)
            Me.SettingsPanelManager.Location = New System.Drawing.Point(253, 147)
            Me.SettingsPanelManager.Name = "SettingsPanelManager"
            Me.SettingsPanelManager.SelectedIndex = 0
            Me.SettingsPanelManager.SelectedPanel = Me.XbmcSettings
            Me.SettingsPanelManager.Size = New System.Drawing.Size(617, 400)
            Me.SettingsPanelManager.TabIndex = 78
            '
            'XbmcSettings
            '
            Me.XbmcSettings.BackColor = System.Drawing.Color.White
            Me.XbmcSettings.Dock = System.Windows.Forms.DockStyle.None
            Me.XbmcSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XbmcSettings.ImageIndex = 0
            Me.XbmcSettings.Location = New System.Drawing.Point(0, 0)
            Me.XbmcSettings.Name = "XbmcSettings"
            Me.XbmcSettings.PanelImage = CType(resources.GetObject("XbmcSettings.PanelImage"), System.Drawing.Image)
            Me.XbmcSettings.PanelOrder = 100
            Me.XbmcSettings.PanelText = "XBMC Controller"
            Me.XbmcSettings.PanelType = "Modules"
            Me.XbmcSettings.ParentName = Nothing
            Me.XbmcSettings.Size = New System.Drawing.Size(617, 400)
            Me.XbmcSettings.TabIndex = 40
            '
            'NotificationSettings
            '
            Me.NotificationSettings.BackColor = System.Drawing.Color.White
            Me.NotificationSettings.Dock = System.Windows.Forms.DockStyle.None
            Me.NotificationSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.NotificationSettings.ImageIndex = 0
            Me.NotificationSettings.Location = New System.Drawing.Point(0, 0)
            Me.NotificationSettings.Name = "NotificationSettings"
            Me.NotificationSettings.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Notify
            Me.NotificationSettings.PanelOrder = 100
            Me.NotificationSettings.PanelText = "Notifications"
            Me.NotificationSettings.PanelType = "Modules"
            Me.NotificationSettings.ParentName = Nothing
            Me.NotificationSettings.Size = New System.Drawing.Size(617, 400)
            Me.NotificationSettings.TabIndex = 39
            '
            'pnlTvScraper
            '
            Me.pnlTvScraper.BackColor = System.Drawing.Color.White
            Me.pnlTvScraper.Dock = System.Windows.Forms.DockStyle.None
            Me.pnlTvScraper.ImageIndex = 0
            Me.pnlTvScraper.Location = New System.Drawing.Point(0, 0)
            Me.pnlTvScraper.Name = "pnlTvScraper"
            Me.pnlTvScraper.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Data
            Me.pnlTvScraper.PanelOrder = 300
            Me.pnlTvScraper.PanelText = "Scrapers - Data"
            Me.pnlTvScraper.PanelType = "TV Shows"
            Me.pnlTvScraper.ParentName = Nothing
            Me.pnlTvScraper.Size = New System.Drawing.Size(617, 400)
            Me.pnlTvScraper.TabIndex = 38
            '
            'pnlTvImages
            '
            Me.pnlTvImages.BackColor = System.Drawing.Color.White
            Me.pnlTvImages.Dock = System.Windows.Forms.DockStyle.None
            Me.pnlTvImages.ImageIndex = 0
            Me.pnlTvImages.Location = New System.Drawing.Point(0, 0)
            Me.pnlTvImages.Name = "pnlTvImages"
            Me.pnlTvImages.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Media
            Me.pnlTvImages.PanelOrder = 400
            Me.pnlTvImages.PanelText = "Scrapers - Images"
            Me.pnlTvImages.PanelType = "TV Shows"
            Me.pnlTvImages.ParentName = Nothing
            Me.pnlTvImages.Size = New System.Drawing.Size(617, 400)
            Me.pnlTvImages.TabIndex = 37
            '
            'BulkRenamerSettings
            '
            Me.BulkRenamerSettings.BackColor = System.Drawing.Color.White
            Me.BulkRenamerSettings.Dock = System.Windows.Forms.DockStyle.None
            Me.BulkRenamerSettings.ImageIndex = 0
            Me.BulkRenamerSettings.Location = New System.Drawing.Point(0, 0)
            Me.BulkRenamerSettings.Name = "BulkRenamerSettings"
            Me.BulkRenamerSettings.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_BulkRename
            Me.BulkRenamerSettings.PanelOrder = 100
            Me.BulkRenamerSettings.PanelText = "Renamer"
            Me.BulkRenamerSettings.PanelType = "Modules"
            Me.BulkRenamerSettings.ParentName = Nothing
            Me.BulkRenamerSettings.Size = New System.Drawing.Size(617, 400)
            Me.BulkRenamerSettings.TabIndex = 36
            '
            'pnlSources
            '
            Me.pnlSources.BackColor = System.Drawing.Color.White
            Me.pnlSources.Dock = System.Windows.Forms.DockStyle.None
            Me.pnlSources.ImageIndex = 0
            Me.pnlSources.Location = New System.Drawing.Point(0, 0)
            Me.pnlSources.Name = "pnlSources"
            Me.pnlSources.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Sources
            Me.pnlSources.PanelOrder = 200
            Me.pnlSources.PanelText = "Files and Sources"
            Me.pnlSources.PanelType = "Movies"
            Me.pnlSources.ParentName = Nothing
            Me.pnlSources.Size = New System.Drawing.Size(617, 400)
            Me.pnlSources.TabIndex = 35
            '
            'MediaSourcesEditor
            '
            Me.MediaSourcesEditor.BackColor = System.Drawing.Color.White
            Me.MediaSourcesEditor.ImageIndex = 0
            Me.MediaSourcesEditor.Location = New System.Drawing.Point(0, 0)
            Me.MediaSourcesEditor.Name = "MediaSourcesEditor"
            Me.MediaSourcesEditor.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_MediaSources
            Me.MediaSourcesEditor.PanelOrder = 100
            Me.MediaSourcesEditor.PanelText = "Media Sources Editor"
            Me.MediaSourcesEditor.PanelType = "Miscellaneous"
            Me.MediaSourcesEditor.ParentName = Nothing
            Me.MediaSourcesEditor.Size = New System.Drawing.Size(617, 400)
            Me.MediaSourcesEditor.TabIndex = 34
            '
            'pnlTVSources
            '
            Me.pnlTVSources.BackColor = System.Drawing.Color.White
            Me.pnlTVSources.Dock = System.Windows.Forms.DockStyle.None
            Me.pnlTVSources.ImageIndex = 0
            Me.pnlTVSources.Location = New System.Drawing.Point(0, 0)
            Me.pnlTVSources.Name = "pnlTVSources"
            Me.pnlTVSources.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Sources
            Me.pnlTVSources.PanelOrder = 200
            Me.pnlTVSources.PanelText = "Files and Sources"
            Me.pnlTVSources.PanelType = "TV Shows"
            Me.pnlTVSources.ParentName = Nothing
            Me.pnlTVSources.Size = New System.Drawing.Size(617, 400)
            Me.pnlTVSources.TabIndex = 33
            '
            'pnlTVShows
            '
            Me.pnlTVShows.BackColor = System.Drawing.Color.White
            Me.pnlTVShows.ImageIndex = 0
            Me.pnlTVShows.Location = New System.Drawing.Point(0, 0)
            Me.pnlTVShows.Name = "pnlTVShows"
            Me.pnlTVShows.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_TV
            Me.pnlTVShows.PanelOrder = 100
            Me.pnlTVShows.PanelText = "General"
            Me.pnlTVShows.PanelType = "TV Shows"
            Me.pnlTVShows.ParentName = Nothing
            Me.pnlTVShows.Size = New System.Drawing.Size(617, 400)
            Me.pnlTVShows.TabIndex = 32
            '
            'pnlScraper
            '
            Me.pnlScraper.BackColor = System.Drawing.Color.White
            Me.pnlScraper.ImageIndex = 0
            Me.pnlScraper.Location = New System.Drawing.Point(0, 0)
            Me.pnlScraper.Name = "pnlScraper"
            Me.pnlScraper.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Data
            Me.pnlScraper.PanelOrder = 300
            Me.pnlScraper.PanelText = "Scrapers - Data"
            Me.pnlScraper.PanelType = "Movies"
            Me.pnlScraper.ParentName = Nothing
            Me.pnlScraper.Size = New System.Drawing.Size(617, 400)
            Me.pnlScraper.TabIndex = 31
            '
            'pnlMovies
            '
            Me.pnlMovies.BackColor = System.Drawing.Color.White
            Me.pnlMovies.ImageIndex = 0
            Me.pnlMovies.Location = New System.Drawing.Point(0, 0)
            Me.pnlMovies.Name = "pnlMovies"
            Me.pnlMovies.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Movies
            Me.pnlMovies.PanelOrder = 100
            Me.pnlMovies.PanelText = "General"
            Me.pnlMovies.PanelType = "Movies"
            Me.pnlMovies.ParentName = Nothing
            Me.pnlMovies.Size = New System.Drawing.Size(617, 400)
            Me.pnlMovies.TabIndex = 30
            '
            'pnlMovieMedia
            '
            Me.pnlMovieMedia.BackColor = System.Drawing.Color.White
            Me.pnlMovieMedia.ImageIndex = 0
            Me.pnlMovieMedia.Location = New System.Drawing.Point(0, 0)
            Me.pnlMovieMedia.Name = "pnlMovieMedia"
            Me.pnlMovieMedia.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Media
            Me.pnlMovieMedia.PanelOrder = 400
            Me.pnlMovieMedia.PanelText = "Scrapers - Images & Trailers"
            Me.pnlMovieMedia.PanelType = "Movies"
            Me.pnlMovieMedia.ParentName = Nothing
            Me.pnlMovieMedia.Size = New System.Drawing.Size(617, 400)
            Me.pnlMovieMedia.TabIndex = 29
            '
            'pnlExtensions
            '
            Me.pnlExtensions.BackColor = System.Drawing.Color.White
            Me.pnlExtensions.ImageIndex = 0
            Me.pnlExtensions.Location = New System.Drawing.Point(0, 0)
            Me.pnlExtensions.Name = "pnlExtensions"
            Me.pnlExtensions.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_File
            Me.pnlExtensions.PanelOrder = 200
            Me.pnlExtensions.PanelText = "File System"
            Me.pnlExtensions.PanelType = "Options"
            Me.pnlExtensions.ParentName = Nothing
            Me.pnlExtensions.Size = New System.Drawing.Size(617, 400)
            Me.pnlExtensions.TabIndex = 28
            '
            'pnlGeneral
            '
            Me.pnlGeneral.BackColor = System.Drawing.Color.White
            Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.None
            Me.pnlGeneral.ImageIndex = 0
            Me.pnlGeneral.Location = New System.Drawing.Point(0, 0)
            Me.pnlGeneral.Name = "pnlGeneral"
            Me.pnlGeneral.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_General
            Me.pnlGeneral.PanelOrder = 100
            Me.pnlGeneral.PanelText = "General"
            Me.pnlGeneral.PanelType = "Options"
            Me.pnlGeneral.ParentName = Nothing
            Me.pnlGeneral.Size = New System.Drawing.Size(617, 400)
            Me.pnlGeneral.TabIndex = 26
            '
            'AvCodecEditor
            '
            Me.AvCodecEditor.BackColor = System.Drawing.Color.White
            Me.AvCodecEditor.ImageIndex = 0
            Me.AvCodecEditor.Location = New System.Drawing.Point(0, 0)
            Me.AvCodecEditor.Name = "AvCodecEditor"
            Me.AvCodecEditor.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Audio
            Me.AvCodecEditor.PanelOrder = 100
            Me.AvCodecEditor.PanelText = "Audio & Video Codec Mapping"
            Me.AvCodecEditor.PanelType = "Miscellaneous"
            Me.AvCodecEditor.ParentName = Nothing
            Me.AvCodecEditor.Size = New System.Drawing.Size(617, 400)
            Me.AvCodecEditor.TabIndex = 25
            '
            'GenresEditorPanel
            '
            Me.GenresEditorPanel.BackColor = System.Drawing.Color.White
            Me.GenresEditorPanel.Dock = System.Windows.Forms.DockStyle.None
            Me.GenresEditorPanel.ImageIndex = 0
            Me.GenresEditorPanel.Location = New System.Drawing.Point(0, 0)
            Me.GenresEditorPanel.Name = "GenresEditorPanel"
            Me.GenresEditorPanel.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Genres
            Me.GenresEditorPanel.PanelOrder = 100
            Me.GenresEditorPanel.PanelText = "Genres Editor"
            Me.GenresEditorPanel.PanelType = "Miscellaneous"
            Me.GenresEditorPanel.ParentName = Nothing
            Me.GenresEditorPanel.Size = New System.Drawing.Size(617, 400)
            Me.GenresEditorPanel.TabIndex = 23
            '
            'pnlScraperSettings
            '
            Me.pnlScraperSettings.BackColor = System.Drawing.Color.White
            Me.pnlScraperSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlScraperSettings.ImageIndex = 0
            Me.pnlScraperSettings.Location = New System.Drawing.Point(0, 0)
            Me.pnlScraperSettings.Name = "pnlScraperSettings"
            Me.pnlScraperSettings.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Data
            Me.pnlScraperSettings.PanelOrder = 300
            Me.pnlScraperSettings.PanelText = "Scrapers"
            Me.pnlScraperSettings.PanelType = "Options"
            Me.pnlScraperSettings.ParentName = Nothing
            Me.pnlScraperSettings.Size = New System.Drawing.Size(617, 400)
            Me.pnlScraperSettings.TabIndex = 31
            '
            'dlgSettings
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(894, 629)
            Me.Controls.Add(Me.SettingsPanelManager)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.ToolStrip1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.pnlCurrent)
            Me.Controls.Add(Me.tvSettings)
            Me.Controls.Add(Me.pnlTop)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnApply)
            Me.Controls.Add(Me.btnOK)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgSettings"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Settings"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.pbCurrent, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.gbHelp.ResumeLayout(False)
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.SettingsPanelManager.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnApply As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents tvSettings As System.Windows.Forms.TreeView
        Friend WithEvents lblCurrent As System.Windows.Forms.Label
        Friend WithEvents pnlCurrent As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
        Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents pbCurrent As System.Windows.Forms.PictureBox
        Friend WithEvents gbHelp As System.Windows.Forms.GroupBox
        Friend WithEvents lblHelp As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
        Friend WithEvents tsbOptions As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbMovies As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbTVhows As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbModules As System.Windows.Forms.ToolStripButton
        Friend WithEvents SettingsPanelManager As EmberControls.PanelManager
        Friend WithEvents GenresEditorPanel As GenresEditor
        Friend WithEvents ilPanelImages As System.Windows.Forms.ImageList
        Friend WithEvents AvCodecEditor As EmberMediaManger.Modules.Extras.AVCodecEditor
        Friend WithEvents pnlGeneral As EmberMediaManger.SettingsControls.General
        Friend WithEvents pnlExtensions As EmberMediaManger.SettingsControls.Extensions
        Friend WithEvents pnlMovieMedia As EmberMediaManger.SettingsControls.Images
        Friend WithEvents pnlTVShows As EmberMediaManger.SettingsControls.Shows
        Friend WithEvents pnlScraper As EmberMediaManger.SettingsControls.Scraper
        Friend WithEvents pnlMovies As EmberMediaManger.SettingsControls.Movies
        Friend WithEvents pnlScraperSettings As EmberMediaManger.SettingsControls.ScraperSettings
        Friend WithEvents pnlTVSources As EmberMediaManger.SettingsControls.TVSources
        Friend WithEvents MediaSourcesEditor As EmberMediaManger.Modules.Extras.MediaSourcesEditor
        Friend WithEvents pnlSources As EmberMediaManger.SettingsControls.Sources
        Friend WithEvents BulkRenamerSettings As EmberMediaManger.Modules.BulkRename.BulkRenamerSettings
        Friend WithEvents pnlTvImages As EmberMediaManger.SettingsControls.TVImages
        Friend WithEvents pnlTvScraper As EmberMediaManger.SettingsControls.TVScraper
        Friend WithEvents NotificationSettings As EmberMediaManger.Modules.Notifications.NotificationSettings
        Friend WithEvents XbmcSettings As EmberMediaManger.Modules.XBMC.XBMCSettings
        Friend WithEvents tsbMiscellaneous As System.Windows.Forms.ToolStripButton
    End Class
End Namespace