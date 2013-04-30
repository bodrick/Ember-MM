<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTMDBMediaSettingsHolder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTMDBMediaSettingsHolder))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbImages = New System.Windows.Forms.GroupBox()
        Me.gbGetFanart = New System.Windows.Forms.GroupBox()
        Me.chkUseFANARTTV = New System.Windows.Forms.CheckBox()
        Me.gbGetPoster = New System.Windows.Forms.GroupBox()
        Me.chkUseMPDB = New System.Windows.Forms.CheckBox()
        Me.chkUseIMDBp = New System.Windows.Forms.CheckBox()
        Me.chkUseIMPA = New System.Windows.Forms.CheckBox()
        Me.gbExtrathumbsSize = New System.Windows.Forms.GroupBox()
        Me.cbManualETSize = New System.Windows.Forms.ComboBox()
        Me.gbSaveFanartIn = New System.Windows.Forms.GroupBox()
        Me.optFanartFolderExtraFanart = New System.Windows.Forms.RadioButton()
        Me.optFanartFolderExtraThumbs = New System.Windows.Forms.RadioButton()
        Me.chkScrapePoster = New System.Windows.Forms.CheckBox()
        Me.chkScrapeFanart = New System.Windows.Forms.CheckBox()
        Me.gbTrailers = New System.Windows.Forms.GroupBox()
        Me.chkDownloadTrailer = New System.Windows.Forms.CheckBox()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.gbSupportedSites = New System.Windows.Forms.GroupBox()
        Me.chkTrailerIMDB = New System.Windows.Forms.CheckBox()
        Me.gbYouTubeTrailer = New System.Windows.Forms.GroupBox()
        Me.cbTrailerTMDBPref = New System.Windows.Forms.ComboBox()
        Me.lblPrefLanguage = New System.Windows.Forms.Label()
        Me.chkTrailerTMDBXBMC = New System.Windows.Forms.CheckBox()
        Me.chkTrailerTMDB = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblScraperOrder = New System.Windows.Forms.Label()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.cbEnabled = New System.Windows.Forms.CheckBox()
        Me.pnlSettings.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImages.SuspendLayout()
        Me.gbGetFanart.SuspendLayout()
        Me.gbGetPoster.SuspendLayout()
        Me.gbExtrathumbsSize.SuspendLayout()
        Me.gbSaveFanartIn.SuspendLayout()
        Me.gbTrailers.SuspendLayout()
        Me.gbSupportedSites.SuspendLayout()
        Me.gbYouTubeTrailer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.Controls.Add(Me.lblInfo)
        Me.pnlSettings.Controls.Add(Me.PictureBox1)
        Me.pnlSettings.Controls.Add(Me.gbImages)
        Me.pnlSettings.Controls.Add(Me.gbTrailers)
        Me.pnlSettings.Controls.Add(Me.Panel2)
        Me.pnlSettings.Location = New System.Drawing.Point(12, 4)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(617, 369)
        Me.pnlSettings.TabIndex = 0
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Blue
        Me.lblInfo.Location = New System.Drawing.Point(37, 337)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(350, 31)
        Me.lblInfo.TabIndex = 3
        Me.lblInfo.Text = "These settings are specific to this module." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please refer to the global settings " & _
    "for more options."
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 335)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 94
        Me.PictureBox1.TabStop = False
        '
        'gbImages
        '
        Me.gbImages.Controls.Add(Me.gbGetFanart)
        Me.gbImages.Controls.Add(Me.gbGetPoster)
        Me.gbImages.Controls.Add(Me.gbExtrathumbsSize)
        Me.gbImages.Controls.Add(Me.gbSaveFanartIn)
        Me.gbImages.Controls.Add(Me.chkScrapePoster)
        Me.gbImages.Controls.Add(Me.chkScrapeFanart)
        Me.gbImages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImages.Location = New System.Drawing.Point(15, 31)
        Me.gbImages.Name = "gbImages"
        Me.gbImages.Size = New System.Drawing.Size(587, 177)
        Me.gbImages.TabIndex = 1
        Me.gbImages.TabStop = False
        Me.gbImages.Text = "Images"
        '
        'gbGetFanart
        '
        Me.gbGetFanart.Controls.Add(Me.chkUseFANARTTV)
        Me.gbGetFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGetFanart.Location = New System.Drawing.Point(165, 97)
        Me.gbGetFanart.Name = "gbGetFanart"
        Me.gbGetFanart.Size = New System.Drawing.Size(160, 52)
        Me.gbGetFanart.TabIndex = 96
        Me.gbGetFanart.TabStop = False
        Me.gbGetFanart.Text = "Get Fanart From:"
        '
        'chkUseFANARTTV
        '
        Me.chkUseFANARTTV.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseFANARTTV.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseFANARTTV.Location = New System.Drawing.Point(6, 20)
        Me.chkUseFANARTTV.Name = "chkUseFANARTTV"
        Me.chkUseFANARTTV.Size = New System.Drawing.Size(150, 17)
        Me.chkUseFANARTTV.TabIndex = 2
        Me.chkUseFANARTTV.Text = "fanart.tv"
        Me.chkUseFANARTTV.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseFANARTTV.UseVisualStyleBackColor = True
        '
        'gbGetPoster
        '
        Me.gbGetPoster.Controls.Add(Me.chkUseMPDB)
        Me.gbGetPoster.Controls.Add(Me.chkUseIMDBp)
        Me.gbGetPoster.Controls.Add(Me.chkUseIMPA)
        Me.gbGetPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGetPoster.Location = New System.Drawing.Point(165, 11)
        Me.gbGetPoster.Name = "gbGetPoster"
        Me.gbGetPoster.Size = New System.Drawing.Size(160, 80)
        Me.gbGetPoster.TabIndex = 5
        Me.gbGetPoster.TabStop = False
        Me.gbGetPoster.Text = "Get Poster From:"
        '
        'chkUseMPDB
        '
        Me.chkUseMPDB.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseMPDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseMPDB.Location = New System.Drawing.Point(6, 52)
        Me.chkUseMPDB.Name = "chkUseMPDB"
        Me.chkUseMPDB.Size = New System.Drawing.Size(150, 17)
        Me.chkUseMPDB.TabIndex = 2
        Me.chkUseMPDB.Text = "MoviePosterDB.com"
        Me.chkUseMPDB.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseMPDB.UseVisualStyleBackColor = True
        '
        'chkUseIMDBp
        '
        Me.chkUseIMDBp.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseIMDBp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseIMDBp.Location = New System.Drawing.Point(6, 20)
        Me.chkUseIMDBp.Name = "chkUseIMDBp"
        Me.chkUseIMDBp.Size = New System.Drawing.Size(149, 17)
        Me.chkUseIMDBp.TabIndex = 0
        Me.chkUseIMDBp.Text = "IMDB.com"
        Me.chkUseIMDBp.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseIMDBp.UseVisualStyleBackColor = True
        '
        'chkUseIMPA
        '
        Me.chkUseIMPA.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseIMPA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseIMPA.Location = New System.Drawing.Point(6, 36)
        Me.chkUseIMPA.Name = "chkUseIMPA"
        Me.chkUseIMPA.Size = New System.Drawing.Size(149, 17)
        Me.chkUseIMPA.TabIndex = 1
        Me.chkUseIMPA.Text = "IMPAwards.com"
        Me.chkUseIMPA.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkUseIMPA.UseVisualStyleBackColor = True
        '
        'gbExtrathumbsSize
        '
        Me.gbExtrathumbsSize.Controls.Add(Me.cbManualETSize)
        Me.gbExtrathumbsSize.Location = New System.Drawing.Point(374, 11)
        Me.gbExtrathumbsSize.Name = "gbExtrathumbsSize"
        Me.gbExtrathumbsSize.Size = New System.Drawing.Size(160, 80)
        Me.gbExtrathumbsSize.TabIndex = 4
        Me.gbExtrathumbsSize.TabStop = False
        Me.gbExtrathumbsSize.Text = "TMDB Extrathumbs Size:"
        '
        'cbManualETSize
        '
        Me.cbManualETSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbManualETSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbManualETSize.FormattingEnabled = True
        Me.cbManualETSize.Items.AddRange(New Object() {"original", "w1280", "poster", "thumb"})
        Me.cbManualETSize.Location = New System.Drawing.Point(21, 35)
        Me.cbManualETSize.Name = "cbManualETSize"
        Me.cbManualETSize.Size = New System.Drawing.Size(121, 21)
        Me.cbManualETSize.TabIndex = 0
        '
        'gbSaveFanartIn
        '
        Me.gbSaveFanartIn.Controls.Add(Me.optFanartFolderExtraFanart)
        Me.gbSaveFanartIn.Controls.Add(Me.optFanartFolderExtraThumbs)
        Me.gbSaveFanartIn.Enabled = False
        Me.gbSaveFanartIn.Location = New System.Drawing.Point(23, 52)
        Me.gbSaveFanartIn.Name = "gbSaveFanartIn"
        Me.gbSaveFanartIn.Size = New System.Drawing.Size(123, 66)
        Me.gbSaveFanartIn.TabIndex = 2
        Me.gbSaveFanartIn.TabStop = False
        Me.gbSaveFanartIn.Text = "Save Fanart In:"
        '
        'optFanartFolderExtraFanart
        '
        Me.optFanartFolderExtraFanart.AutoSize = True
        Me.optFanartFolderExtraFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFanartFolderExtraFanart.Location = New System.Drawing.Point(22, 38)
        Me.optFanartFolderExtraFanart.Name = "optFanartFolderExtraFanart"
        Me.optFanartFolderExtraFanart.Size = New System.Drawing.Size(85, 17)
        Me.optFanartFolderExtraFanart.TabIndex = 1
        Me.optFanartFolderExtraFanart.TabStop = True
        Me.optFanartFolderExtraFanart.Text = "\extrafanart"
        Me.optFanartFolderExtraFanart.UseVisualStyleBackColor = True
        '
        'optFanartFolderExtraThumbs
        '
        Me.optFanartFolderExtraThumbs.AutoSize = True
        Me.optFanartFolderExtraThumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFanartFolderExtraThumbs.Location = New System.Drawing.Point(22, 19)
        Me.optFanartFolderExtraThumbs.Name = "optFanartFolderExtraThumbs"
        Me.optFanartFolderExtraThumbs.Size = New System.Drawing.Size(93, 17)
        Me.optFanartFolderExtraThumbs.TabIndex = 0
        Me.optFanartFolderExtraThumbs.TabStop = True
        Me.optFanartFolderExtraThumbs.Text = "\extrathumbs"
        Me.optFanartFolderExtraThumbs.UseVisualStyleBackColor = True
        '
        'chkScrapePoster
        '
        Me.chkScrapePoster.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkScrapePoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkScrapePoster.Location = New System.Drawing.Point(6, 20)
        Me.chkScrapePoster.Name = "chkScrapePoster"
        Me.chkScrapePoster.Size = New System.Drawing.Size(114, 17)
        Me.chkScrapePoster.TabIndex = 0
        Me.chkScrapePoster.Text = "Get Posters"
        Me.chkScrapePoster.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkScrapePoster.UseVisualStyleBackColor = True
        '
        'chkScrapeFanart
        '
        Me.chkScrapeFanart.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkScrapeFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkScrapeFanart.Location = New System.Drawing.Point(6, 36)
        Me.chkScrapeFanart.Name = "chkScrapeFanart"
        Me.chkScrapeFanart.Size = New System.Drawing.Size(114, 17)
        Me.chkScrapeFanart.TabIndex = 1
        Me.chkScrapeFanart.Text = "Get Fanart"
        Me.chkScrapeFanart.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkScrapeFanart.UseVisualStyleBackColor = True
        '
        'gbTrailers
        '
        Me.gbTrailers.Controls.Add(Me.chkDownloadTrailer)
        Me.gbTrailers.Controls.Add(Me.lblTimeout)
        Me.gbTrailers.Controls.Add(Me.txtTimeout)
        Me.gbTrailers.Controls.Add(Me.gbSupportedSites)
        Me.gbTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTrailers.Location = New System.Drawing.Point(15, 214)
        Me.gbTrailers.Name = "gbTrailers"
        Me.gbTrailers.Size = New System.Drawing.Size(587, 112)
        Me.gbTrailers.TabIndex = 2
        Me.gbTrailers.TabStop = False
        Me.gbTrailers.Text = "Trailers"
        Me.gbTrailers.UseCompatibleTextRendering = True
        '
        'chkDownloadTrailer
        '
        Me.chkDownloadTrailer.AutoSize = True
        Me.chkDownloadTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDownloadTrailer.Location = New System.Drawing.Point(6, 20)
        Me.chkDownloadTrailer.Name = "chkDownloadTrailer"
        Me.chkDownloadTrailer.Size = New System.Drawing.Size(140, 17)
        Me.chkDownloadTrailer.TabIndex = 0
        Me.chkDownloadTrailer.Text = "Enable Trailer Support"
        Me.chkDownloadTrailer.UseVisualStyleBackColor = True
        '
        'lblTimeout
        '
        Me.lblTimeout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeout.Location = New System.Drawing.Point(6, 44)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(72, 13)
        Me.lblTimeout.TabIndex = 1
        Me.lblTimeout.Text = "Timeout:"
        Me.lblTimeout.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTimeout
        '
        Me.txtTimeout.Enabled = False
        Me.txtTimeout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeout.Location = New System.Drawing.Point(85, 40)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(50, 22)
        Me.txtTimeout.TabIndex = 2
        '
        'gbSupportedSites
        '
        Me.gbSupportedSites.Controls.Add(Me.chkTrailerIMDB)
        Me.gbSupportedSites.Controls.Add(Me.gbYouTubeTrailer)
        Me.gbSupportedSites.Controls.Add(Me.chkTrailerTMDBXBMC)
        Me.gbSupportedSites.Controls.Add(Me.chkTrailerTMDB)
        Me.gbSupportedSites.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupportedSites.Location = New System.Drawing.Point(165, 12)
        Me.gbSupportedSites.Name = "gbSupportedSites"
        Me.gbSupportedSites.Size = New System.Drawing.Size(321, 94)
        Me.gbSupportedSites.TabIndex = 3
        Me.gbSupportedSites.TabStop = False
        Me.gbSupportedSites.Text = "Supported Sites:"
        '
        'chkTrailerIMDB
        '
        Me.chkTrailerIMDB.AutoSize = True
        Me.chkTrailerIMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrailerIMDB.Location = New System.Drawing.Point(6, 60)
        Me.chkTrailerIMDB.Name = "chkTrailerIMDB"
        Me.chkTrailerIMDB.Size = New System.Drawing.Size(54, 17)
        Me.chkTrailerIMDB.TabIndex = 5
        Me.chkTrailerIMDB.Text = "IMDB"
        Me.chkTrailerIMDB.UseVisualStyleBackColor = True
        '
        'gbYouTubeTrailer
        '
        Me.gbYouTubeTrailer.Controls.Add(Me.cbTrailerTMDBPref)
        Me.gbYouTubeTrailer.Controls.Add(Me.lblPrefLanguage)
        Me.gbYouTubeTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbYouTubeTrailer.Location = New System.Drawing.Point(140, 12)
        Me.gbYouTubeTrailer.Name = "gbYouTubeTrailer"
        Me.gbYouTubeTrailer.Size = New System.Drawing.Size(161, 76)
        Me.gbYouTubeTrailer.TabIndex = 4
        Me.gbYouTubeTrailer.TabStop = False
        Me.gbYouTubeTrailer.Text = "Youtube/TMDB Trailer:"
        '
        'cbTrailerTMDBPref
        '
        Me.cbTrailerTMDBPref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTrailerTMDBPref.Enabled = False
        Me.cbTrailerTMDBPref.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cbTrailerTMDBPref.FormattingEnabled = True
        Me.cbTrailerTMDBPref.Items.AddRange(New Object() {"bg", "cs", "da", "de", "el", "en", "es", "fi", "fr", "he", "hu", "it", "nb", "nl", "no", "pl", "pt", "ru", "sk", "sv", "ta", "tr", "uk", "vi", "xx", "zh"})
        Me.cbTrailerTMDBPref.Location = New System.Drawing.Point(21, 42)
        Me.cbTrailerTMDBPref.Name = "cbTrailerTMDBPref"
        Me.cbTrailerTMDBPref.Size = New System.Drawing.Size(121, 21)
        Me.cbTrailerTMDBPref.TabIndex = 1
        '
        'lblPrefLanguage
        '
        Me.lblPrefLanguage.AutoSize = True
        Me.lblPrefLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblPrefLanguage.Location = New System.Drawing.Point(26, 20)
        Me.lblPrefLanguage.Name = "lblPrefLanguage"
        Me.lblPrefLanguage.Size = New System.Drawing.Size(111, 13)
        Me.lblPrefLanguage.TabIndex = 0
        Me.lblPrefLanguage.Text = "Preferred Language:"
        '
        'chkTrailerTMDBXBMC
        '
        Me.chkTrailerTMDBXBMC.AutoSize = True
        Me.chkTrailerTMDBXBMC.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrailerTMDBXBMC.Location = New System.Drawing.Point(26, 36)
        Me.chkTrailerTMDBXBMC.Name = "chkTrailerTMDBXBMC"
        Me.chkTrailerTMDBXBMC.Size = New System.Drawing.Size(95, 17)
        Me.chkTrailerTMDBXBMC.TabIndex = 1
        Me.chkTrailerTMDBXBMC.Text = "XBMC Format"
        Me.chkTrailerTMDBXBMC.UseVisualStyleBackColor = True
        '
        'chkTrailerTMDB
        '
        Me.chkTrailerTMDB.AutoSize = True
        Me.chkTrailerTMDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrailerTMDB.Location = New System.Drawing.Point(6, 20)
        Me.chkTrailerTMDB.Name = "chkTrailerTMDB"
        Me.chkTrailerTMDB.Size = New System.Drawing.Size(103, 17)
        Me.chkTrailerTMDB.TabIndex = 0
        Me.chkTrailerTMDB.Text = "Youtube/TMDB"
        Me.chkTrailerTMDB.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.lblScraperOrder)
        Me.Panel2.Controls.Add(Me.btnDown)
        Me.Panel2.Controls.Add(Me.btnUp)
        Me.Panel2.Controls.Add(Me.cbEnabled)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 25)
        Me.Panel2.TabIndex = 0
        '
        'lblScraperOrder
        '
        Me.lblScraperOrder.AutoSize = True
        Me.lblScraperOrder.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScraperOrder.Location = New System.Drawing.Point(470, 7)
        Me.lblScraperOrder.Name = "lblScraperOrder"
        Me.lblScraperOrder.Size = New System.Drawing.Size(58, 12)
        Me.lblScraperOrder.TabIndex = 1
        Me.lblScraperOrder.Text = "Scraper order"
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Image = CType(resources.GetObject("btnDown.Image"), System.Drawing.Image)
        Me.btnDown.Location = New System.Drawing.Point(591, 1)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(23, 23)
        Me.btnDown.TabIndex = 3
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Image = CType(resources.GetObject("btnUp.Image"), System.Drawing.Image)
        Me.btnUp.Location = New System.Drawing.Point(566, 1)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(23, 23)
        Me.btnUp.TabIndex = 2
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'cbEnabled
        '
        Me.cbEnabled.AutoSize = True
        Me.cbEnabled.Location = New System.Drawing.Point(10, 5)
        Me.cbEnabled.Name = "cbEnabled"
        Me.cbEnabled.Size = New System.Drawing.Size(68, 17)
        Me.cbEnabled.TabIndex = 0
        Me.cbEnabled.Text = "Enabled"
        Me.cbEnabled.UseVisualStyleBackColor = True
        '
        'frmTMDBMediaSettingsHolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(652, 388)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTMDBMediaSettingsHolder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scraper Setup"
        Me.pnlSettings.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImages.ResumeLayout(False)
        Me.gbGetFanart.ResumeLayout(False)
        Me.gbGetPoster.ResumeLayout(False)
        Me.gbExtrathumbsSize.ResumeLayout(False)
        Me.gbSaveFanartIn.ResumeLayout(False)
        Me.gbSaveFanartIn.PerformLayout()
        Me.gbTrailers.ResumeLayout(False)
        Me.gbTrailers.PerformLayout()
        Me.gbSupportedSites.ResumeLayout(False)
        Me.gbSupportedSites.PerformLayout()
        Me.gbYouTubeTrailer.ResumeLayout(False)
        Me.gbYouTubeTrailer.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents chkScrapeFanart As System.Windows.Forms.CheckBox
    Friend WithEvents chkScrapePoster As System.Windows.Forms.CheckBox
    Friend WithEvents chkDownloadTrailer As System.Windows.Forms.CheckBox
    Friend WithEvents gbSupportedSites As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblTimeout As System.Windows.Forms.Label
    Friend WithEvents txtTimeout As System.Windows.Forms.TextBox
    Friend WithEvents gbImages As System.Windows.Forms.GroupBox
    Friend WithEvents gbTrailers As System.Windows.Forms.GroupBox
    Friend WithEvents lblScraperOrder As System.Windows.Forms.Label
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbSaveFanartIn As System.Windows.Forms.GroupBox
    Friend WithEvents optFanartFolderExtraFanart As System.Windows.Forms.RadioButton
    Friend WithEvents optFanartFolderExtraThumbs As System.Windows.Forms.RadioButton
    Friend WithEvents chkTrailerTMDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrailerTMDBXBMC As System.Windows.Forms.CheckBox
    Friend WithEvents gbExtrathumbsSize As System.Windows.Forms.GroupBox
    Friend WithEvents cbManualETSize As System.Windows.Forms.ComboBox
    Friend WithEvents gbYouTubeTrailer As System.Windows.Forms.GroupBox
    Friend WithEvents cbTrailerTMDBPref As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrefLanguage As System.Windows.Forms.Label
    Friend WithEvents gbGetPoster As System.Windows.Forms.GroupBox
    Friend WithEvents chkUseMPDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseIMDBp As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseIMPA As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrailerIMDB As System.Windows.Forms.CheckBox
    Friend WithEvents gbGetFanart As System.Windows.Forms.GroupBox
	Friend WithEvents chkUseFANARTTV As System.Windows.Forms.CheckBox

End Class