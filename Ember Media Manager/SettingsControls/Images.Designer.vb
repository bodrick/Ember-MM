Imports EmberControls

Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Images
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
            Me.gbTrailers = New System.Windows.Forms.GroupBox()
            Me.cbTrailerQuality = New System.Windows.Forms.ComboBox()
            Me.lblPreferredQuality = New System.Windows.Forms.Label()
            Me.chkDeleteAllTrailers = New System.Windows.Forms.CheckBox()
            Me.chkOverwriteTrailer = New System.Windows.Forms.CheckBox()
            Me.chkNoDLTrailer = New System.Windows.Forms.CheckBox()
            Me.chkSingleScrapeTrailer = New System.Windows.Forms.CheckBox()
            Me.chkUpdaterTrailer = New System.Windows.Forms.CheckBox()
            Me.chkDownloadTrailer = New System.Windows.Forms.CheckBox()
            Me.gbImages = New System.Windows.Forms.GroupBox()
            Me.chkActorCache = New System.Windows.Forms.CheckBox()
            Me.chkNoSaveImagesToNfo = New System.Windows.Forms.CheckBox()
            Me.chkSingleScrapeImages = New System.Windows.Forms.CheckBox()
            Me.gbCaching = New System.Windows.Forms.GroupBox()
            Me.chkUseImgCacheUpdaters = New System.Windows.Forms.CheckBox()
            Me.chkPersistImgCache = New System.Windows.Forms.CheckBox()
            Me.chkUseImgCache = New System.Windows.Forms.CheckBox()
            Me.gbFanart = New System.Windows.Forms.GroupBox()
            Me.txtFanartWidth = New System.Windows.Forms.TextBox()
            Me.txtFanartHeight = New System.Windows.Forms.TextBox()
            Me.chkFanartOnly = New System.Windows.Forms.CheckBox()
            Me.lblFanartQualValue = New System.Windows.Forms.Label()
            Me.tbFanartQual = New System.Windows.Forms.TrackBar()
            Me.lblFanartQuality = New System.Windows.Forms.Label()
            Me.lblFanartMaxWidth = New System.Windows.Forms.Label()
            Me.lblFanartMaxHeight = New System.Windows.Forms.Label()
            Me.chkResizeFanart = New System.Windows.Forms.CheckBox()
            Me.cbFanartSize = New System.Windows.Forms.ComboBox()
            Me.lblFanartSize = New System.Windows.Forms.Label()
            Me.chkOverwriteFanart = New System.Windows.Forms.CheckBox()
            Me.gbPoster = New System.Windows.Forms.GroupBox()
            Me.chkPosterOnly = New System.Windows.Forms.CheckBox()
            Me.txtPosterWidth = New EmberControls.IntegerTextbox()
            Me.txtPosterHeight = New EmberControls.IntegerTextbox()
            Me.lblPosterQualValue = New System.Windows.Forms.Label()
            Me.tbPosterQual = New System.Windows.Forms.TrackBar()
            Me.lblPosterQuality = New System.Windows.Forms.Label()
            Me.lblPosterMaxWidth = New System.Windows.Forms.Label()
            Me.lblPosterMaxHeight = New System.Windows.Forms.Label()
            Me.chkResizePoster = New System.Windows.Forms.CheckBox()
            Me.lblPosterSize = New System.Windows.Forms.Label()
            Me.cbPosterSize = New System.Windows.Forms.ComboBox()
            Me.chkOverwritePoster = New System.Windows.Forms.CheckBox()
            Me.gbExtrathumbs = New System.Windows.Forms.GroupBox()
            Me.chkAutoETSize = New System.Windows.Forms.CheckBox()
            Me.cbAutoETSize = New System.Windows.Forms.ComboBox()
            Me.txtAutoThumbs = New EmberControls.IntegerTextbox()
            Me.gbSizing = New System.Windows.Forms.GroupBox()
            Me.txtETWidth = New EmberControls.IntegerTextbox()
            Me.txtETHeight = New EmberControls.IntegerTextbox()
            Me.chkETPadding = New System.Windows.Forms.CheckBox()
            Me.lblSizingWidth = New System.Windows.Forms.Label()
            Me.lblSizingHeight = New System.Windows.Forms.Label()
            Me.rbETCustom = New System.Windows.Forms.RadioButton()
            Me.rbETNative = New System.Windows.Forms.RadioButton()
            Me.chkAutoThumbs = New System.Windows.Forms.CheckBox()
            Me.chkUseETasFA = New System.Windows.Forms.CheckBox()
            Me.lblNumExtraThumbs = New System.Windows.Forms.Label()
            Me.chkNoSpoilers = New System.Windows.Forms.CheckBox()
            Me.gbTrailers.SuspendLayout()
            Me.gbImages.SuspendLayout()
            Me.gbCaching.SuspendLayout()
            Me.gbFanart.SuspendLayout()
            CType(Me.tbFanartQual, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbPoster.SuspendLayout()
            CType(Me.tbPosterQual, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbExtrathumbs.SuspendLayout()
            Me.gbSizing.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTrailers
            '
            Me.gbTrailers.Controls.Add(Me.cbTrailerQuality)
            Me.gbTrailers.Controls.Add(Me.lblPreferredQuality)
            Me.gbTrailers.Controls.Add(Me.chkDeleteAllTrailers)
            Me.gbTrailers.Controls.Add(Me.chkOverwriteTrailer)
            Me.gbTrailers.Controls.Add(Me.chkNoDLTrailer)
            Me.gbTrailers.Controls.Add(Me.chkSingleScrapeTrailer)
            Me.gbTrailers.Controls.Add(Me.chkUpdaterTrailer)
            Me.gbTrailers.Controls.Add(Me.chkDownloadTrailer)
            Me.gbTrailers.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbTrailers.Location = New System.Drawing.Point(4, 172)
            Me.gbTrailers.Name = "gbTrailers"
            Me.gbTrailers.Size = New System.Drawing.Size(183, 230)
            Me.gbTrailers.TabIndex = 69
            Me.gbTrailers.TabStop = False
            Me.gbTrailers.Text = "Trailers"
            '
            'cbTrailerQuality
            '
            Me.cbTrailerQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbTrailerQuality.Enabled = False
            Me.cbTrailerQuality.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbTrailerQuality.FormattingEnabled = True
            Me.cbTrailerQuality.Location = New System.Drawing.Point(33, 204)
            Me.cbTrailerQuality.Name = "cbTrailerQuality"
            Me.cbTrailerQuality.Size = New System.Drawing.Size(106, 21)
            Me.cbTrailerQuality.TabIndex = 69
            '
            'lblPreferredQuality
            '
            Me.lblPreferredQuality.AutoSize = True
            Me.lblPreferredQuality.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPreferredQuality.Location = New System.Drawing.Point(31, 189)
            Me.lblPreferredQuality.Name = "lblPreferredQuality"
            Me.lblPreferredQuality.Size = New System.Drawing.Size(97, 13)
            Me.lblPreferredQuality.TabIndex = 70
            Me.lblPreferredQuality.Text = "Preferred Quality:"
            '
            'chkDeleteAllTrailers
            '
            Me.chkDeleteAllTrailers.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkDeleteAllTrailers.Enabled = False
            Me.chkDeleteAllTrailers.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDeleteAllTrailers.Location = New System.Drawing.Point(25, 163)
            Me.chkDeleteAllTrailers.Name = "chkDeleteAllTrailers"
            Me.chkDeleteAllTrailers.Size = New System.Drawing.Size(152, 27)
            Me.chkDeleteAllTrailers.TabIndex = 11
            Me.chkDeleteAllTrailers.Text = Global.EmberMediaManger.Languages.Delete_All_Existing
            Me.chkDeleteAllTrailers.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkDeleteAllTrailers.UseVisualStyleBackColor = True
            '
            'chkOverwriteTrailer
            '
            Me.chkOverwriteTrailer.AutoSize = True
            Me.chkOverwriteTrailer.Enabled = False
            Me.chkOverwriteTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOverwriteTrailer.Location = New System.Drawing.Point(25, 143)
            Me.chkOverwriteTrailer.Name = "chkOverwriteTrailer"
            Me.chkOverwriteTrailer.Size = New System.Drawing.Size(119, 17)
            Me.chkOverwriteTrailer.TabIndex = 10
            Me.chkOverwriteTrailer.Text = Global.EmberMediaManger.Languages.Overwrite_Existing
            Me.chkOverwriteTrailer.UseVisualStyleBackColor = True
            '
            'chkNoDLTrailer
            '
            Me.chkNoDLTrailer.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoDLTrailer.Enabled = False
            Me.chkNoDLTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoDLTrailer.Location = New System.Drawing.Point(25, 72)
            Me.chkNoDLTrailer.Name = "chkNoDLTrailer"
            Me.chkNoDLTrailer.Size = New System.Drawing.Size(151, 30)
            Me.chkNoDLTrailer.TabIndex = 8
            Me.chkNoDLTrailer.Text = Global.EmberMediaManger.Languages.Only_Get_URLs_When_Scraping
            Me.chkNoDLTrailer.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoDLTrailer.UseVisualStyleBackColor = True
            '
            'chkSingleScrapeTrailer
            '
            Me.chkSingleScrapeTrailer.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSingleScrapeTrailer.Enabled = False
            Me.chkSingleScrapeTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSingleScrapeTrailer.Location = New System.Drawing.Point(25, 106)
            Me.chkSingleScrapeTrailer.Name = "chkSingleScrapeTrailer"
            Me.chkSingleScrapeTrailer.Size = New System.Drawing.Size(154, 34)
            Me.chkSingleScrapeTrailer.TabIndex = 9
            Me.chkSingleScrapeTrailer.Text = Global.EmberMediaManger.Languages.Get_During_Single_Scrape
            Me.chkSingleScrapeTrailer.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSingleScrapeTrailer.UseVisualStyleBackColor = True
            '
            'chkUpdaterTrailer
            '
            Me.chkUpdaterTrailer.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUpdaterTrailer.Enabled = False
            Me.chkUpdaterTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUpdaterTrailer.Location = New System.Drawing.Point(25, 38)
            Me.chkUpdaterTrailer.Name = "chkUpdaterTrailer"
            Me.chkUpdaterTrailer.Size = New System.Drawing.Size(151, 33)
            Me.chkUpdaterTrailer.TabIndex = 7
            Me.chkUpdaterTrailer.Text = "Get During Automated Scrapers"
            Me.chkUpdaterTrailer.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUpdaterTrailer.UseVisualStyleBackColor = True
            '
            'chkDownloadTrailer
            '
            Me.chkDownloadTrailer.AutoSize = True
            Me.chkDownloadTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDownloadTrailer.Location = New System.Drawing.Point(12, 16)
            Me.chkDownloadTrailer.Name = "chkDownloadTrailer"
            Me.chkDownloadTrailer.Size = New System.Drawing.Size(140, 17)
            Me.chkDownloadTrailer.TabIndex = 6
            Me.chkDownloadTrailer.Text = "Enable Trailer Support"
            Me.chkDownloadTrailer.UseVisualStyleBackColor = True
            '
            'gbImages
            '
            Me.gbImages.Controls.Add(Me.chkActorCache)
            Me.gbImages.Controls.Add(Me.chkNoSaveImagesToNfo)
            Me.gbImages.Controls.Add(Me.chkSingleScrapeImages)
            Me.gbImages.Controls.Add(Me.gbCaching)
            Me.gbImages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbImages.Location = New System.Drawing.Point(3, 3)
            Me.gbImages.Name = "gbImages"
            Me.gbImages.Size = New System.Drawing.Size(184, 168)
            Me.gbImages.TabIndex = 65
            Me.gbImages.TabStop = False
            Me.gbImages.Text = "Images"
            '
            'chkActorCache
            '
            Me.chkActorCache.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkActorCache.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkActorCache.Location = New System.Drawing.Point(6, 35)
            Me.chkActorCache.Name = "chkActorCache"
            Me.chkActorCache.Size = New System.Drawing.Size(173, 19)
            Me.chkActorCache.TabIndex = 5
            Me.chkActorCache.Text = "Enable Actors Cache"
            Me.chkActorCache.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkActorCache.UseVisualStyleBackColor = True
            '
            'chkNoSaveImagesToNfo
            '
            Me.chkNoSaveImagesToNfo.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoSaveImagesToNfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoSaveImagesToNfo.Location = New System.Drawing.Point(6, 53)
            Me.chkNoSaveImagesToNfo.Name = "chkNoSaveImagesToNfo"
            Me.chkNoSaveImagesToNfo.Size = New System.Drawing.Size(172, 34)
            Me.chkNoSaveImagesToNfo.TabIndex = 4
            Me.chkNoSaveImagesToNfo.Text = "Do Not Save Image URLs to Nfo"
            Me.chkNoSaveImagesToNfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoSaveImagesToNfo.UseVisualStyleBackColor = True
            '
            'chkSingleScrapeImages
            '
            Me.chkSingleScrapeImages.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSingleScrapeImages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSingleScrapeImages.Location = New System.Drawing.Point(6, 16)
            Me.chkSingleScrapeImages.Name = "chkSingleScrapeImages"
            Me.chkSingleScrapeImages.Size = New System.Drawing.Size(173, 19)
            Me.chkSingleScrapeImages.TabIndex = 3
            Me.chkSingleScrapeImages.Text = Global.EmberMediaManger.Languages.Get_on_Single_Scrape
            Me.chkSingleScrapeImages.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSingleScrapeImages.UseVisualStyleBackColor = True
            '
            'gbCaching
            '
            Me.gbCaching.Controls.Add(Me.chkUseImgCacheUpdaters)
            Me.gbCaching.Controls.Add(Me.chkPersistImgCache)
            Me.gbCaching.Controls.Add(Me.chkUseImgCache)
            Me.gbCaching.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbCaching.Location = New System.Drawing.Point(4, 84)
            Me.gbCaching.Name = "gbCaching"
            Me.gbCaching.Size = New System.Drawing.Size(176, 79)
            Me.gbCaching.TabIndex = 1
            Me.gbCaching.TabStop = False
            Me.gbCaching.Text = "Caching"
            '
            'chkUseImgCacheUpdaters
            '
            Me.chkUseImgCacheUpdaters.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUseImgCacheUpdaters.Enabled = False
            Me.chkUseImgCacheUpdaters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUseImgCacheUpdaters.Location = New System.Drawing.Point(20, 35)
            Me.chkUseImgCacheUpdaters.Name = "chkUseImgCacheUpdaters"
            Me.chkUseImgCacheUpdaters.Size = New System.Drawing.Size(155, 18)
            Me.chkUseImgCacheUpdaters.TabIndex = 1
            Me.chkUseImgCacheUpdaters.Text = "Use Cache for Scrapers"
            Me.chkUseImgCacheUpdaters.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUseImgCacheUpdaters.UseVisualStyleBackColor = True
            '
            'chkPersistImgCache
            '
            Me.chkPersistImgCache.AutoSize = True
            Me.chkPersistImgCache.Enabled = False
            Me.chkPersistImgCache.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPersistImgCache.Location = New System.Drawing.Point(20, 58)
            Me.chkPersistImgCache.Name = "chkPersistImgCache"
            Me.chkPersistImgCache.Size = New System.Drawing.Size(144, 17)
            Me.chkPersistImgCache.TabIndex = 2
            Me.chkPersistImgCache.Text = "Persistent Image Cache"
            Me.chkPersistImgCache.UseVisualStyleBackColor = True
            '
            'chkUseImgCache
            '
            Me.chkUseImgCache.AutoSize = True
            Me.chkUseImgCache.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUseImgCache.Location = New System.Drawing.Point(7, 16)
            Me.chkUseImgCache.Name = "chkUseImgCache"
            Me.chkUseImgCache.Size = New System.Drawing.Size(113, 17)
            Me.chkUseImgCache.TabIndex = 0
            Me.chkUseImgCache.Text = "Use Image Cache"
            Me.chkUseImgCache.UseVisualStyleBackColor = True
            '
            'gbFanart
            '
            Me.gbFanart.Controls.Add(Me.txtFanartWidth)
            Me.gbFanart.Controls.Add(Me.txtFanartHeight)
            Me.gbFanart.Controls.Add(Me.chkFanartOnly)
            Me.gbFanart.Controls.Add(Me.lblFanartQualValue)
            Me.gbFanart.Controls.Add(Me.tbFanartQual)
            Me.gbFanart.Controls.Add(Me.lblFanartQuality)
            Me.gbFanart.Controls.Add(Me.lblFanartMaxWidth)
            Me.gbFanart.Controls.Add(Me.lblFanartMaxHeight)
            Me.gbFanart.Controls.Add(Me.chkResizeFanart)
            Me.gbFanart.Controls.Add(Me.cbFanartSize)
            Me.gbFanart.Controls.Add(Me.lblFanartSize)
            Me.gbFanart.Controls.Add(Me.chkOverwriteFanart)
            Me.gbFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbFanart.Location = New System.Drawing.Point(190, 185)
            Me.gbFanart.Name = "gbFanart"
            Me.gbFanart.Size = New System.Drawing.Size(218, 176)
            Me.gbFanart.TabIndex = 67
            Me.gbFanart.TabStop = False
            Me.gbFanart.Text = "Fanart"
            '
            'txtFanartWidth
            '
            Me.txtFanartWidth.Enabled = False
            Me.txtFanartWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFanartWidth.Location = New System.Drawing.Point(69, 100)
            Me.txtFanartWidth.Name = "txtFanartWidth"
            Me.txtFanartWidth.Size = New System.Drawing.Size(40, 22)
            Me.txtFanartWidth.TabIndex = 4
            '
            'txtFanartHeight
            '
            Me.txtFanartHeight.Enabled = False
            Me.txtFanartHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFanartHeight.Location = New System.Drawing.Point(175, 100)
            Me.txtFanartHeight.Name = "txtFanartHeight"
            Me.txtFanartHeight.Size = New System.Drawing.Size(40, 22)
            Me.txtFanartHeight.TabIndex = 5
            '
            'chkFanartOnly
            '
            Me.chkFanartOnly.AutoSize = True
            Me.chkFanartOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFanartOnly.Location = New System.Drawing.Point(163, 38)
            Me.chkFanartOnly.Name = "chkFanartOnly"
            Me.chkFanartOnly.Size = New System.Drawing.Size(50, 17)
            Me.chkFanartOnly.TabIndex = 1
            Me.chkFanartOnly.Text = Global.EmberMediaManger.Languages.Only
            Me.chkFanartOnly.UseVisualStyleBackColor = True
            '
            'lblFanartQualValue
            '
            Me.lblFanartQualValue.AutoSize = True
            Me.lblFanartQualValue.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lblFanartQualValue.Location = New System.Drawing.Point(183, 151)
            Me.lblFanartQualValue.Name = "lblFanartQualValue"
            Me.lblFanartQualValue.Size = New System.Drawing.Size(29, 17)
            Me.lblFanartQualValue.TabIndex = 49
            Me.lblFanartQualValue.Text = "100"
            '
            'tbFanartQual
            '
            Me.tbFanartQual.AutoSize = False
            Me.tbFanartQual.LargeChange = 10
            Me.tbFanartQual.Location = New System.Drawing.Point(6, 143)
            Me.tbFanartQual.Maximum = 100
            Me.tbFanartQual.Name = "tbFanartQual"
            Me.tbFanartQual.Size = New System.Drawing.Size(180, 27)
            Me.tbFanartQual.TabIndex = 6
            Me.tbFanartQual.TickFrequency = 10
            Me.tbFanartQual.Value = 100
            '
            'lblFanartQuality
            '
            Me.lblFanartQuality.AutoSize = True
            Me.lblFanartQuality.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFanartQuality.Location = New System.Drawing.Point(2, 131)
            Me.lblFanartQuality.Name = "lblFanartQuality"
            Me.lblFanartQuality.Size = New System.Drawing.Size(47, 13)
            Me.lblFanartQuality.TabIndex = 47
            Me.lblFanartQuality.Text = "Quality:"
            '
            'lblFanartMaxWidth
            '
            Me.lblFanartMaxWidth.AutoSize = True
            Me.lblFanartMaxWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFanartMaxWidth.Location = New System.Drawing.Point(3, 104)
            Me.lblFanartMaxWidth.Name = "lblFanartMaxWidth"
            Me.lblFanartMaxWidth.Size = New System.Drawing.Size(66, 13)
            Me.lblFanartMaxWidth.TabIndex = 43
            Me.lblFanartMaxWidth.Text = "Max Width:"
            '
            'lblFanartMaxHeight
            '
            Me.lblFanartMaxHeight.AutoSize = True
            Me.lblFanartMaxHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFanartMaxHeight.Location = New System.Drawing.Point(107, 104)
            Me.lblFanartMaxHeight.Name = "lblFanartMaxHeight"
            Me.lblFanartMaxHeight.Size = New System.Drawing.Size(69, 13)
            Me.lblFanartMaxHeight.TabIndex = 42
            Me.lblFanartMaxHeight.Text = "Max Height:"
            '
            'chkResizeFanart
            '
            Me.chkResizeFanart.AutoSize = True
            Me.chkResizeFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkResizeFanart.Location = New System.Drawing.Point(6, 82)
            Me.chkResizeFanart.Name = "chkResizeFanart"
            Me.chkResizeFanart.Size = New System.Drawing.Size(133, 17)
            Me.chkResizeFanart.TabIndex = 3
            Me.chkResizeFanart.Text = Global.EmberMediaManger.Languages.Automatically_Resize
            Me.chkResizeFanart.UseVisualStyleBackColor = True
            '
            'cbFanartSize
            '
            Me.cbFanartSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbFanartSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbFanartSize.FormattingEnabled = True
            Me.cbFanartSize.Location = New System.Drawing.Point(6, 34)
            Me.cbFanartSize.Name = "cbFanartSize"
            Me.cbFanartSize.Size = New System.Drawing.Size(148, 21)
            Me.cbFanartSize.TabIndex = 0
            '
            'lblFanartSize
            '
            Me.lblFanartSize.AutoSize = True
            Me.lblFanartSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFanartSize.Location = New System.Drawing.Point(4, 18)
            Me.lblFanartSize.Name = "lblFanartSize"
            Me.lblFanartSize.Size = New System.Drawing.Size(80, 13)
            Me.lblFanartSize.TabIndex = 15
            Me.lblFanartSize.Text = "Preferred Size:"
            '
            'chkOverwriteFanart
            '
            Me.chkOverwriteFanart.AutoSize = True
            Me.chkOverwriteFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOverwriteFanart.Location = New System.Drawing.Point(6, 62)
            Me.chkOverwriteFanart.Name = "chkOverwriteFanart"
            Me.chkOverwriteFanart.Size = New System.Drawing.Size(119, 17)
            Me.chkOverwriteFanart.TabIndex = 2
            Me.chkOverwriteFanart.Text = Global.EmberMediaManger.Languages.Overwrite_Existing
            Me.chkOverwriteFanart.UseVisualStyleBackColor = True
            '
            'gbPoster
            '
            Me.gbPoster.Controls.Add(Me.chkPosterOnly)
            Me.gbPoster.Controls.Add(Me.txtPosterWidth)
            Me.gbPoster.Controls.Add(Me.txtPosterHeight)
            Me.gbPoster.Controls.Add(Me.lblPosterQualValue)
            Me.gbPoster.Controls.Add(Me.tbPosterQual)
            Me.gbPoster.Controls.Add(Me.lblPosterQuality)
            Me.gbPoster.Controls.Add(Me.lblPosterMaxWidth)
            Me.gbPoster.Controls.Add(Me.lblPosterMaxHeight)
            Me.gbPoster.Controls.Add(Me.chkResizePoster)
            Me.gbPoster.Controls.Add(Me.lblPosterSize)
            Me.gbPoster.Controls.Add(Me.cbPosterSize)
            Me.gbPoster.Controls.Add(Me.chkOverwritePoster)
            Me.gbPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbPoster.Location = New System.Drawing.Point(190, 3)
            Me.gbPoster.Name = "gbPoster"
            Me.gbPoster.Size = New System.Drawing.Size(218, 170)
            Me.gbPoster.TabIndex = 66
            Me.gbPoster.TabStop = False
            Me.gbPoster.Text = "Poster"
            '
            'chkPosterOnly
            '
            Me.chkPosterOnly.AutoSize = True
            Me.chkPosterOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPosterOnly.Location = New System.Drawing.Point(163, 38)
            Me.chkPosterOnly.Name = "chkPosterOnly"
            Me.chkPosterOnly.Size = New System.Drawing.Size(50, 17)
            Me.chkPosterOnly.TabIndex = 47
            Me.chkPosterOnly.Text = Global.EmberMediaManger.Languages.Only
            Me.chkPosterOnly.UseVisualStyleBackColor = True
            '
            'txtPosterWidth
            '
            Me.txtPosterWidth.Enabled = False
            Me.txtPosterWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPosterWidth.Location = New System.Drawing.Point(68, 100)
            Me.txtPosterWidth.Name = "txtPosterWidth"
            Me.txtPosterWidth.Size = New System.Drawing.Size(40, 22)
            Me.txtPosterWidth.TabIndex = 3
            '
            'txtPosterHeight
            '
            Me.txtPosterHeight.Enabled = False
            Me.txtPosterHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPosterHeight.Location = New System.Drawing.Point(175, 100)
            Me.txtPosterHeight.Name = "txtPosterHeight"
            Me.txtPosterHeight.Size = New System.Drawing.Size(40, 22)
            Me.txtPosterHeight.TabIndex = 4
            '
            'lblPosterQualValue
            '
            Me.lblPosterQualValue.AutoSize = True
            Me.lblPosterQualValue.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lblPosterQualValue.Location = New System.Drawing.Point(183, 147)
            Me.lblPosterQualValue.Name = "lblPosterQualValue"
            Me.lblPosterQualValue.Size = New System.Drawing.Size(29, 17)
            Me.lblPosterQualValue.TabIndex = 46
            Me.lblPosterQualValue.Text = "100"
            '
            'tbPosterQual
            '
            Me.tbPosterQual.AutoSize = False
            Me.tbPosterQual.LargeChange = 10
            Me.tbPosterQual.Location = New System.Drawing.Point(7, 139)
            Me.tbPosterQual.Maximum = 100
            Me.tbPosterQual.Name = "tbPosterQual"
            Me.tbPosterQual.Size = New System.Drawing.Size(179, 27)
            Me.tbPosterQual.TabIndex = 5
            Me.tbPosterQual.TickFrequency = 10
            Me.tbPosterQual.Value = 100
            '
            'lblPosterQuality
            '
            Me.lblPosterQuality.AutoSize = True
            Me.lblPosterQuality.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPosterQuality.Location = New System.Drawing.Point(3, 127)
            Me.lblPosterQuality.Name = "lblPosterQuality"
            Me.lblPosterQuality.Size = New System.Drawing.Size(47, 13)
            Me.lblPosterQuality.TabIndex = 44
            Me.lblPosterQuality.Text = "Quality:"
            '
            'lblPosterMaxWidth
            '
            Me.lblPosterMaxWidth.AutoSize = True
            Me.lblPosterMaxWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPosterMaxWidth.Location = New System.Drawing.Point(3, 104)
            Me.lblPosterMaxWidth.Name = "lblPosterMaxWidth"
            Me.lblPosterMaxWidth.Size = New System.Drawing.Size(66, 13)
            Me.lblPosterMaxWidth.TabIndex = 43
            Me.lblPosterMaxWidth.Text = "Max Width:"
            '
            'lblPosterMaxHeight
            '
            Me.lblPosterMaxHeight.AutoSize = True
            Me.lblPosterMaxHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPosterMaxHeight.Location = New System.Drawing.Point(106, 104)
            Me.lblPosterMaxHeight.Name = "lblPosterMaxHeight"
            Me.lblPosterMaxHeight.Size = New System.Drawing.Size(69, 13)
            Me.lblPosterMaxHeight.TabIndex = 42
            Me.lblPosterMaxHeight.Text = "Max Height:"
            '
            'chkResizePoster
            '
            Me.chkResizePoster.AutoSize = True
            Me.chkResizePoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkResizePoster.Location = New System.Drawing.Point(6, 82)
            Me.chkResizePoster.Name = "chkResizePoster"
            Me.chkResizePoster.Size = New System.Drawing.Size(133, 17)
            Me.chkResizePoster.TabIndex = 2
            Me.chkResizePoster.Text = Global.EmberMediaManger.Languages.Automatically_Resize
            Me.chkResizePoster.UseVisualStyleBackColor = True
            '
            'lblPosterSize
            '
            Me.lblPosterSize.AutoSize = True
            Me.lblPosterSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPosterSize.Location = New System.Drawing.Point(4, 18)
            Me.lblPosterSize.Name = "lblPosterSize"
            Me.lblPosterSize.Size = New System.Drawing.Size(80, 13)
            Me.lblPosterSize.TabIndex = 14
            Me.lblPosterSize.Text = "Preferred Size:"
            '
            'cbPosterSize
            '
            Me.cbPosterSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbPosterSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbPosterSize.FormattingEnabled = True
            Me.cbPosterSize.Location = New System.Drawing.Point(6, 34)
            Me.cbPosterSize.Name = "cbPosterSize"
            Me.cbPosterSize.Size = New System.Drawing.Size(148, 21)
            Me.cbPosterSize.TabIndex = 0
            '
            'chkOverwritePoster
            '
            Me.chkOverwritePoster.AutoSize = True
            Me.chkOverwritePoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOverwritePoster.Location = New System.Drawing.Point(6, 62)
            Me.chkOverwritePoster.Name = "chkOverwritePoster"
            Me.chkOverwritePoster.Size = New System.Drawing.Size(119, 17)
            Me.chkOverwritePoster.TabIndex = 1
            Me.chkOverwritePoster.Text = Global.EmberMediaManger.Languages.Overwrite_Existing
            Me.chkOverwritePoster.UseVisualStyleBackColor = True
            '
            'gbExtrathumbs
            '
            Me.gbExtrathumbs.Controls.Add(Me.chkAutoETSize)
            Me.gbExtrathumbs.Controls.Add(Me.cbAutoETSize)
            Me.gbExtrathumbs.Controls.Add(Me.txtAutoThumbs)
            Me.gbExtrathumbs.Controls.Add(Me.gbSizing)
            Me.gbExtrathumbs.Controls.Add(Me.chkAutoThumbs)
            Me.gbExtrathumbs.Controls.Add(Me.chkUseETasFA)
            Me.gbExtrathumbs.Controls.Add(Me.lblNumExtraThumbs)
            Me.gbExtrathumbs.Controls.Add(Me.chkNoSpoilers)
            Me.gbExtrathumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbExtrathumbs.Location = New System.Drawing.Point(412, 3)
            Me.gbExtrathumbs.Name = "gbExtrathumbs"
            Me.gbExtrathumbs.Size = New System.Drawing.Size(199, 358)
            Me.gbExtrathumbs.TabIndex = 68
            Me.gbExtrathumbs.TabStop = False
            Me.gbExtrathumbs.Text = "Extrathumbs"
            '
            'chkAutoETSize
            '
            Me.chkAutoETSize.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoETSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAutoETSize.Location = New System.Drawing.Point(6, 236)
            Me.chkAutoETSize.Name = "chkAutoETSize"
            Me.chkAutoETSize.Size = New System.Drawing.Size(188, 43)
            Me.chkAutoETSize.TabIndex = 67
            Me.chkAutoETSize.Text = "Download All Fanart Images of the Following Size as Extrathumbs:"
            Me.chkAutoETSize.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoETSize.UseVisualStyleBackColor = True
            '
            'cbAutoETSize
            '
            Me.cbAutoETSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbAutoETSize.Enabled = False
            Me.cbAutoETSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbAutoETSize.FormattingEnabled = True
            Me.cbAutoETSize.Location = New System.Drawing.Point(26, 283)
            Me.cbAutoETSize.Name = "cbAutoETSize"
            Me.cbAutoETSize.Size = New System.Drawing.Size(148, 21)
            Me.cbAutoETSize.TabIndex = 65
            '
            'txtAutoThumbs
            '
            Me.txtAutoThumbs.Enabled = False
            Me.txtAutoThumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAutoThumbs.Location = New System.Drawing.Point(124, 47)
            Me.txtAutoThumbs.Name = "txtAutoThumbs"
            Me.txtAutoThumbs.Size = New System.Drawing.Size(53, 22)
            Me.txtAutoThumbs.TabIndex = 6
            '
            'gbSizing
            '
            Me.gbSizing.Controls.Add(Me.txtETWidth)
            Me.gbSizing.Controls.Add(Me.txtETHeight)
            Me.gbSizing.Controls.Add(Me.chkETPadding)
            Me.gbSizing.Controls.Add(Me.lblSizingWidth)
            Me.gbSizing.Controls.Add(Me.lblSizingHeight)
            Me.gbSizing.Controls.Add(Me.rbETCustom)
            Me.gbSizing.Controls.Add(Me.rbETNative)
            Me.gbSizing.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbSizing.Location = New System.Drawing.Point(7, 120)
            Me.gbSizing.Name = "gbSizing"
            Me.gbSizing.Size = New System.Drawing.Size(185, 104)
            Me.gbSizing.TabIndex = 64
            Me.gbSizing.TabStop = False
            Me.gbSizing.Text = "Sizing (Extracted Frames)"
            '
            'txtETWidth
            '
            Me.txtETWidth.Enabled = False
            Me.txtETWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtETWidth.Location = New System.Drawing.Point(61, 57)
            Me.txtETWidth.Name = "txtETWidth"
            Me.txtETWidth.Size = New System.Drawing.Size(40, 22)
            Me.txtETWidth.TabIndex = 44
            '
            'txtETHeight
            '
            Me.txtETHeight.Enabled = False
            Me.txtETHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtETHeight.Location = New System.Drawing.Point(143, 57)
            Me.txtETHeight.Name = "txtETHeight"
            Me.txtETHeight.Size = New System.Drawing.Size(40, 22)
            Me.txtETHeight.TabIndex = 45
            '
            'chkETPadding
            '
            Me.chkETPadding.AutoSize = True
            Me.chkETPadding.Enabled = False
            Me.chkETPadding.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkETPadding.Location = New System.Drawing.Point(21, 81)
            Me.chkETPadding.Name = "chkETPadding"
            Me.chkETPadding.Size = New System.Drawing.Size(69, 17)
            Me.chkETPadding.TabIndex = 48
            Me.chkETPadding.Text = "Padding"
            Me.chkETPadding.UseVisualStyleBackColor = True
            '
            'lblSizingWidth
            '
            Me.lblSizingWidth.AutoSize = True
            Me.lblSizingWidth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSizingWidth.Location = New System.Drawing.Point(17, 61)
            Me.lblSizingWidth.Name = "lblSizingWidth"
            Me.lblSizingWidth.Size = New System.Drawing.Size(42, 13)
            Me.lblSizingWidth.TabIndex = 47
            Me.lblSizingWidth.Text = "Width:"
            '
            'lblSizingHeight
            '
            Me.lblSizingHeight.AutoSize = True
            Me.lblSizingHeight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSizingHeight.Location = New System.Drawing.Point(98, 61)
            Me.lblSizingHeight.Name = "lblSizingHeight"
            Me.lblSizingHeight.Size = New System.Drawing.Size(45, 13)
            Me.lblSizingHeight.TabIndex = 46
            Me.lblSizingHeight.Text = "Height:"
            '
            'rbETCustom
            '
            Me.rbETCustom.AutoSize = True
            Me.rbETCustom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbETCustom.Location = New System.Drawing.Point(7, 38)
            Me.rbETCustom.Name = "rbETCustom"
            Me.rbETCustom.Size = New System.Drawing.Size(109, 17)
            Me.rbETCustom.TabIndex = 1
            Me.rbETCustom.TabStop = True
            Me.rbETCustom.Text = "Use Custom Size"
            Me.rbETCustom.UseVisualStyleBackColor = True
            '
            'rbETNative
            '
            Me.rbETNative.AutoSize = True
            Me.rbETNative.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbETNative.Location = New System.Drawing.Point(7, 20)
            Me.rbETNative.Name = "rbETNative"
            Me.rbETNative.Size = New System.Drawing.Size(138, 17)
            Me.rbETNative.TabIndex = 0
            Me.rbETNative.TabStop = True
            Me.rbETNative.Text = "Use Native Resolution"
            Me.rbETNative.UseVisualStyleBackColor = True
            '
            'chkAutoThumbs
            '
            Me.chkAutoThumbs.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoThumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAutoThumbs.Location = New System.Drawing.Point(6, 17)
            Me.chkAutoThumbs.Name = "chkAutoThumbs"
            Me.chkAutoThumbs.Size = New System.Drawing.Size(188, 30)
            Me.chkAutoThumbs.TabIndex = 5
            Me.chkAutoThumbs.Text = Global.EmberMediaManger.Languages.Extract_During_Scrapers
            Me.chkAutoThumbs.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoThumbs.UseVisualStyleBackColor = True
            '
            'chkUseETasFA
            '
            Me.chkUseETasFA.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUseETasFA.Enabled = False
            Me.chkUseETasFA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUseETasFA.Location = New System.Drawing.Point(25, 84)
            Me.chkUseETasFA.Name = "chkUseETasFA"
            Me.chkUseETasFA.Size = New System.Drawing.Size(171, 30)
            Me.chkUseETasFA.TabIndex = 8
            Me.chkUseETasFA.Text = Global.EmberMediaManger.Languages.Use_if_no_Fanart_Found
            Me.chkUseETasFA.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkUseETasFA.UseVisualStyleBackColor = True
            '
            'lblNumExtraThumbs
            '
            Me.lblNumExtraThumbs.AutoSize = True
            Me.lblNumExtraThumbs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNumExtraThumbs.Location = New System.Drawing.Point(22, 50)
            Me.lblNumExtraThumbs.Name = "lblNumExtraThumbs"
            Me.lblNumExtraThumbs.Size = New System.Drawing.Size(102, 13)
            Me.lblNumExtraThumbs.TabIndex = 61
            Me.lblNumExtraThumbs.Text = "Number To Create:"
            '
            'chkNoSpoilers
            '
            Me.chkNoSpoilers.AutoSize = True
            Me.chkNoSpoilers.Enabled = False
            Me.chkNoSpoilers.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoSpoilers.Location = New System.Drawing.Point(25, 67)
            Me.chkNoSpoilers.Name = "chkNoSpoilers"
            Me.chkNoSpoilers.Size = New System.Drawing.Size(85, 17)
            Me.chkNoSpoilers.TabIndex = 7
            Me.chkNoSpoilers.Text = Global.EmberMediaManger.Languages.No_Spoilers
            Me.chkNoSpoilers.UseVisualStyleBackColor = True
            '
            'Images
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbTrailers)
            Me.Controls.Add(Me.gbImages)
            Me.Controls.Add(Me.gbFanart)
            Me.Controls.Add(Me.gbPoster)
            Me.Controls.Add(Me.gbExtrathumbs)
            Me.Name = "Images"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Media
            Me.PanelOrder = 400
            Me.PanelText = "Scrapers - Images & Trailers"
            Me.PanelType = "Movies"
            Me.gbTrailers.ResumeLayout(False)
            Me.gbTrailers.PerformLayout()
            Me.gbImages.ResumeLayout(False)
            Me.gbCaching.ResumeLayout(False)
            Me.gbCaching.PerformLayout()
            Me.gbFanart.ResumeLayout(False)
            Me.gbFanart.PerformLayout()
            CType(Me.tbFanartQual, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbPoster.ResumeLayout(False)
            Me.gbPoster.PerformLayout()
            CType(Me.tbPosterQual, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbExtrathumbs.ResumeLayout(False)
            Me.gbExtrathumbs.PerformLayout()
            Me.gbSizing.ResumeLayout(False)
            Me.gbSizing.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTrailers As System.Windows.Forms.GroupBox
        Friend WithEvents cbTrailerQuality As System.Windows.Forms.ComboBox
        Friend WithEvents lblPreferredQuality As System.Windows.Forms.Label
        Friend WithEvents chkDeleteAllTrailers As System.Windows.Forms.CheckBox
        Friend WithEvents chkOverwriteTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoDLTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkSingleScrapeTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkUpdaterTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkDownloadTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents gbImages As System.Windows.Forms.GroupBox
        Friend WithEvents chkActorCache As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoSaveImagesToNfo As System.Windows.Forms.CheckBox
        Friend WithEvents chkSingleScrapeImages As System.Windows.Forms.CheckBox
        Friend WithEvents gbCaching As System.Windows.Forms.GroupBox
        Friend WithEvents chkUseImgCacheUpdaters As System.Windows.Forms.CheckBox
        Friend WithEvents chkPersistImgCache As System.Windows.Forms.CheckBox
        Friend WithEvents chkUseImgCache As System.Windows.Forms.CheckBox
        Friend WithEvents gbFanart As System.Windows.Forms.GroupBox
        Friend WithEvents txtFanartWidth As System.Windows.Forms.TextBox
        Friend WithEvents txtFanartHeight As System.Windows.Forms.TextBox
        Friend WithEvents chkFanartOnly As System.Windows.Forms.CheckBox
        Friend WithEvents lblFanartQualValue As System.Windows.Forms.Label
        Friend WithEvents tbFanartQual As System.Windows.Forms.TrackBar
        Friend WithEvents lblFanartQuality As System.Windows.Forms.Label
        Friend WithEvents lblFanartMaxWidth As System.Windows.Forms.Label
        Friend WithEvents lblFanartMaxHeight As System.Windows.Forms.Label
        Friend WithEvents chkResizeFanart As System.Windows.Forms.CheckBox
        Friend WithEvents cbFanartSize As System.Windows.Forms.ComboBox
        Friend WithEvents lblFanartSize As System.Windows.Forms.Label
        Friend WithEvents chkOverwriteFanart As System.Windows.Forms.CheckBox
        Friend WithEvents gbPoster As System.Windows.Forms.GroupBox
        Friend WithEvents chkPosterOnly As System.Windows.Forms.CheckBox
        Friend WithEvents txtPosterWidth As IntegerTextbox
        Friend WithEvents txtPosterHeight As IntegerTextbox
        Friend WithEvents lblPosterQualValue As System.Windows.Forms.Label
        Friend WithEvents tbPosterQual As System.Windows.Forms.TrackBar
        Friend WithEvents lblPosterQuality As System.Windows.Forms.Label
        Friend WithEvents lblPosterMaxWidth As System.Windows.Forms.Label
        Friend WithEvents lblPosterMaxHeight As System.Windows.Forms.Label
        Friend WithEvents chkResizePoster As System.Windows.Forms.CheckBox
        Friend WithEvents lblPosterSize As System.Windows.Forms.Label
        Friend WithEvents cbPosterSize As System.Windows.Forms.ComboBox
        Friend WithEvents chkOverwritePoster As System.Windows.Forms.CheckBox
        Friend WithEvents gbExtrathumbs As System.Windows.Forms.GroupBox
        Friend WithEvents chkAutoETSize As System.Windows.Forms.CheckBox
        Friend WithEvents cbAutoETSize As System.Windows.Forms.ComboBox
        Friend WithEvents txtAutoThumbs As IntegerTextbox
        Friend WithEvents gbSizing As System.Windows.Forms.GroupBox
        Friend WithEvents txtETWidth As IntegerTextbox
        Friend WithEvents txtETHeight As IntegerTextbox
        Friend WithEvents chkETPadding As System.Windows.Forms.CheckBox
        Friend WithEvents lblSizingWidth As System.Windows.Forms.Label
        Friend WithEvents lblSizingHeight As System.Windows.Forms.Label
        Friend WithEvents rbETCustom As System.Windows.Forms.RadioButton
        Friend WithEvents rbETNative As System.Windows.Forms.RadioButton
        Friend WithEvents chkAutoThumbs As System.Windows.Forms.CheckBox
        Friend WithEvents chkUseETasFA As System.Windows.Forms.CheckBox
        Friend WithEvents lblNumExtraThumbs As System.Windows.Forms.Label
        Friend WithEvents chkNoSpoilers As System.Windows.Forms.CheckBox

    End Class
End Namespace