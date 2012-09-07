Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TVScraper
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
            Me.GroupBox37 = New System.Windows.Forms.GroupBox()
            Me.GroupBox38 = New System.Windows.Forms.GroupBox()
            Me.chkScraperShowRating = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowActors = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowStudio = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowPremiered = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowEGU = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowMPAA = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowPlot = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowGenre = New System.Windows.Forms.CheckBox()
            Me.chkScraperShowTitle = New System.Windows.Forms.CheckBox()
            Me.GroupBox39 = New System.Windows.Forms.GroupBox()
            Me.chkScraperEpActors = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpCredits = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpDirector = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpPlot = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpRating = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpAired = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpTitle = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpEpisode = New System.Windows.Forms.CheckBox()
            Me.chkScraperEpSeason = New System.Windows.Forms.CheckBox()
            Me.GroupBox40 = New System.Windows.Forms.GroupBox()
            Me.gbEpLocks = New System.Windows.Forms.GroupBox()
            Me.chkEpLockTitle = New System.Windows.Forms.CheckBox()
            Me.chkEpLockRating = New System.Windows.Forms.CheckBox()
            Me.chkEpLockPlot = New System.Windows.Forms.CheckBox()
            Me.gbShowLocks = New System.Windows.Forms.GroupBox()
            Me.chkShowLockPlot = New System.Windows.Forms.CheckBox()
            Me.chkShowLockGenre = New System.Windows.Forms.CheckBox()
            Me.chkShowLockStudio = New System.Windows.Forms.CheckBox()
            Me.chkShowLockRating = New System.Windows.Forms.CheckBox()
            Me.chkShowLockTitle = New System.Windows.Forms.CheckBox()
            Me.GroupBox41 = New System.Windows.Forms.GroupBox()
            Me.gbTVMIDefaults = New System.Windows.Forms.GroupBox()
            Me.lstTVMetaData = New System.Windows.Forms.ListBox()
            Me.txtTVDefFIExt = New System.Windows.Forms.TextBox()
            Me.Label49 = New System.Windows.Forms.Label()
            Me.btnRemoveTVMetaDataFT = New System.Windows.Forms.Button()
            Me.btnEditTVMetaDataFT = New System.Windows.Forms.Button()
            Me.btnNewTVMetaDataFT = New System.Windows.Forms.Button()
            Me.cboTVMetaDataOverlay = New System.Windows.Forms.ComboBox()
            Me.Label50 = New System.Windows.Forms.Label()
            Me.chkTVScanMetaData = New System.Windows.Forms.CheckBox()
            Me.gbTVScraperOptions = New System.Windows.Forms.GroupBox()
            Me.lblOrdering = New System.Windows.Forms.Label()
            Me.cbOrdering = New System.Windows.Forms.ComboBox()
            Me.lblTVUpdate = New System.Windows.Forms.Label()
            Me.cboTVUpdate = New System.Windows.Forms.ComboBox()
            Me.gbLanguage = New System.Windows.Forms.GroupBox()
            Me.lblTVLanguagePreferred = New System.Windows.Forms.Label()
            Me.btnTVLanguageFetch = New System.Windows.Forms.Button()
            Me.cbTVLanguage = New System.Windows.Forms.ComboBox()
            Me.GroupBox37.SuspendLayout()
            Me.GroupBox38.SuspendLayout()
            Me.GroupBox39.SuspendLayout()
            Me.GroupBox40.SuspendLayout()
            Me.gbEpLocks.SuspendLayout()
            Me.gbShowLocks.SuspendLayout()
            Me.GroupBox41.SuspendLayout()
            Me.gbTVMIDefaults.SuspendLayout()
            Me.gbTVScraperOptions.SuspendLayout()
            Me.gbLanguage.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox37
            '
            Me.GroupBox37.Controls.Add(Me.GroupBox38)
            Me.GroupBox37.Controls.Add(Me.GroupBox39)
            Me.GroupBox37.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox37.Location = New System.Drawing.Point(208, 252)
            Me.GroupBox37.Name = "GroupBox37"
            Me.GroupBox37.Size = New System.Drawing.Size(403, 114)
            Me.GroupBox37.TabIndex = 73
            Me.GroupBox37.TabStop = False
            Me.GroupBox37.Text = "Scraper Fields"
            '
            'GroupBox38
            '
            Me.GroupBox38.Controls.Add(Me.chkScraperShowRating)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowActors)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowStudio)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowPremiered)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowEGU)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowMPAA)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowPlot)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowGenre)
            Me.GroupBox38.Controls.Add(Me.chkScraperShowTitle)
            Me.GroupBox38.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox38.Location = New System.Drawing.Point(3, 14)
            Me.GroupBox38.Name = "GroupBox38"
            Me.GroupBox38.Size = New System.Drawing.Size(213, 96)
            Me.GroupBox38.TabIndex = 15
            Me.GroupBox38.TabStop = False
            Me.GroupBox38.Text = "Show"
            '
            'chkScraperShowRating
            '
            Me.chkScraperShowRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowRating.Location = New System.Drawing.Point(130, 29)
            Me.chkScraperShowRating.Name = "chkScraperShowRating"
            Me.chkScraperShowRating.Size = New System.Drawing.Size(78, 17)
            Me.chkScraperShowRating.TabIndex = 13
            Me.chkScraperShowRating.Text = "Rating"
            Me.chkScraperShowRating.UseVisualStyleBackColor = True
            '
            'chkScraperShowActors
            '
            Me.chkScraperShowActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowActors.Location = New System.Drawing.Point(130, 61)
            Me.chkScraperShowActors.Name = "chkScraperShowActors"
            Me.chkScraperShowActors.Size = New System.Drawing.Size(78, 17)
            Me.chkScraperShowActors.TabIndex = 16
            Me.chkScraperShowActors.Text = "Actors"
            Me.chkScraperShowActors.UseVisualStyleBackColor = True
            '
            'chkScraperShowStudio
            '
            Me.chkScraperShowStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowStudio.Location = New System.Drawing.Point(130, 45)
            Me.chkScraperShowStudio.Name = "chkScraperShowStudio"
            Me.chkScraperShowStudio.Size = New System.Drawing.Size(78, 17)
            Me.chkScraperShowStudio.TabIndex = 15
            Me.chkScraperShowStudio.Text = "Studio"
            Me.chkScraperShowStudio.UseVisualStyleBackColor = True
            '
            'chkScraperShowPremiered
            '
            Me.chkScraperShowPremiered.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowPremiered.Location = New System.Drawing.Point(130, 13)
            Me.chkScraperShowPremiered.Name = "chkScraperShowPremiered"
            Me.chkScraperShowPremiered.Size = New System.Drawing.Size(78, 17)
            Me.chkScraperShowPremiered.TabIndex = 14
            Me.chkScraperShowPremiered.Text = "Premiered"
            Me.chkScraperShowPremiered.UseVisualStyleBackColor = True
            '
            'chkScraperShowEGU
            '
            Me.chkScraperShowEGU.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowEGU.Location = New System.Drawing.Point(6, 29)
            Me.chkScraperShowEGU.Name = "chkScraperShowEGU"
            Me.chkScraperShowEGU.Size = New System.Drawing.Size(118, 17)
            Me.chkScraperShowEGU.TabIndex = 8
            Me.chkScraperShowEGU.Text = "EpisodeGuideURL"
            Me.chkScraperShowEGU.UseVisualStyleBackColor = True
            '
            'chkScraperShowMPAA
            '
            Me.chkScraperShowMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowMPAA.Location = New System.Drawing.Point(6, 61)
            Me.chkScraperShowMPAA.Name = "chkScraperShowMPAA"
            Me.chkScraperShowMPAA.Size = New System.Drawing.Size(119, 17)
            Me.chkScraperShowMPAA.TabIndex = 11
            Me.chkScraperShowMPAA.Text = "MPAA"
            Me.chkScraperShowMPAA.UseVisualStyleBackColor = True
            '
            'chkScraperShowPlot
            '
            Me.chkScraperShowPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowPlot.Location = New System.Drawing.Point(6, 77)
            Me.chkScraperShowPlot.Name = "chkScraperShowPlot"
            Me.chkScraperShowPlot.Size = New System.Drawing.Size(119, 17)
            Me.chkScraperShowPlot.TabIndex = 5
            Me.chkScraperShowPlot.Text = "Plot"
            Me.chkScraperShowPlot.UseVisualStyleBackColor = True
            '
            'chkScraperShowGenre
            '
            Me.chkScraperShowGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowGenre.Location = New System.Drawing.Point(6, 45)
            Me.chkScraperShowGenre.Name = "chkScraperShowGenre"
            Me.chkScraperShowGenre.Size = New System.Drawing.Size(118, 17)
            Me.chkScraperShowGenre.TabIndex = 10
            Me.chkScraperShowGenre.Text = "Genre"
            Me.chkScraperShowGenre.UseVisualStyleBackColor = True
            '
            'chkScraperShowTitle
            '
            Me.chkScraperShowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperShowTitle.Location = New System.Drawing.Point(6, 13)
            Me.chkScraperShowTitle.Name = "chkScraperShowTitle"
            Me.chkScraperShowTitle.Size = New System.Drawing.Size(118, 17)
            Me.chkScraperShowTitle.TabIndex = 9
            Me.chkScraperShowTitle.Text = "Title"
            Me.chkScraperShowTitle.UseVisualStyleBackColor = True
            '
            'GroupBox39
            '
            Me.GroupBox39.Controls.Add(Me.chkScraperEpActors)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpCredits)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpDirector)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpPlot)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpRating)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpAired)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpTitle)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpEpisode)
            Me.GroupBox39.Controls.Add(Me.chkScraperEpSeason)
            Me.GroupBox39.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox39.Location = New System.Drawing.Point(219, 14)
            Me.GroupBox39.Name = "GroupBox39"
            Me.GroupBox39.Size = New System.Drawing.Size(181, 96)
            Me.GroupBox39.TabIndex = 14
            Me.GroupBox39.TabStop = False
            Me.GroupBox39.Text = "Episode"
            '
            'chkScraperEpActors
            '
            Me.chkScraperEpActors.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpActors.Location = New System.Drawing.Point(94, 60)
            Me.chkScraperEpActors.Name = "chkScraperEpActors"
            Me.chkScraperEpActors.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpActors.TabIndex = 10
            Me.chkScraperEpActors.Text = "Actors"
            Me.chkScraperEpActors.UseVisualStyleBackColor = True
            '
            'chkScraperEpCredits
            '
            Me.chkScraperEpCredits.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpCredits.Location = New System.Drawing.Point(94, 44)
            Me.chkScraperEpCredits.Name = "chkScraperEpCredits"
            Me.chkScraperEpCredits.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpCredits.TabIndex = 9
            Me.chkScraperEpCredits.Text = "Credits"
            Me.chkScraperEpCredits.UseVisualStyleBackColor = True
            '
            'chkScraperEpDirector
            '
            Me.chkScraperEpDirector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpDirector.Location = New System.Drawing.Point(94, 28)
            Me.chkScraperEpDirector.Name = "chkScraperEpDirector"
            Me.chkScraperEpDirector.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpDirector.TabIndex = 8
            Me.chkScraperEpDirector.Text = "Director"
            Me.chkScraperEpDirector.UseVisualStyleBackColor = True
            '
            'chkScraperEpPlot
            '
            Me.chkScraperEpPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpPlot.Location = New System.Drawing.Point(94, 12)
            Me.chkScraperEpPlot.Name = "chkScraperEpPlot"
            Me.chkScraperEpPlot.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpPlot.TabIndex = 7
            Me.chkScraperEpPlot.Text = "Plot"
            Me.chkScraperEpPlot.UseVisualStyleBackColor = True
            '
            'chkScraperEpRating
            '
            Me.chkScraperEpRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpRating.Location = New System.Drawing.Point(6, 77)
            Me.chkScraperEpRating.Name = "chkScraperEpRating"
            Me.chkScraperEpRating.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpRating.TabIndex = 6
            Me.chkScraperEpRating.Text = "Rating"
            Me.chkScraperEpRating.UseVisualStyleBackColor = True
            '
            'chkScraperEpAired
            '
            Me.chkScraperEpAired.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpAired.Location = New System.Drawing.Point(6, 61)
            Me.chkScraperEpAired.Name = "chkScraperEpAired"
            Me.chkScraperEpAired.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpAired.TabIndex = 5
            Me.chkScraperEpAired.Text = "Aired"
            Me.chkScraperEpAired.UseVisualStyleBackColor = True
            '
            'chkScraperEpTitle
            '
            Me.chkScraperEpTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpTitle.Location = New System.Drawing.Point(6, 13)
            Me.chkScraperEpTitle.Name = "chkScraperEpTitle"
            Me.chkScraperEpTitle.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpTitle.TabIndex = 2
            Me.chkScraperEpTitle.Text = "Title"
            Me.chkScraperEpTitle.UseVisualStyleBackColor = True
            '
            'chkScraperEpEpisode
            '
            Me.chkScraperEpEpisode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpEpisode.Location = New System.Drawing.Point(6, 45)
            Me.chkScraperEpEpisode.Name = "chkScraperEpEpisode"
            Me.chkScraperEpEpisode.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpEpisode.TabIndex = 4
            Me.chkScraperEpEpisode.Text = Global.EmberMediaManger.Languages.Episode
            Me.chkScraperEpEpisode.UseVisualStyleBackColor = True
            '
            'chkScraperEpSeason
            '
            Me.chkScraperEpSeason.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScraperEpSeason.Location = New System.Drawing.Point(6, 29)
            Me.chkScraperEpSeason.Name = "chkScraperEpSeason"
            Me.chkScraperEpSeason.Size = New System.Drawing.Size(67, 17)
            Me.chkScraperEpSeason.TabIndex = 0
            Me.chkScraperEpSeason.Text = "Season"
            Me.chkScraperEpSeason.UseVisualStyleBackColor = True
            '
            'GroupBox40
            '
            Me.GroupBox40.Controls.Add(Me.gbEpLocks)
            Me.GroupBox40.Controls.Add(Me.gbShowLocks)
            Me.GroupBox40.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox40.Location = New System.Drawing.Point(208, 6)
            Me.GroupBox40.Name = "GroupBox40"
            Me.GroupBox40.Size = New System.Drawing.Size(191, 243)
            Me.GroupBox40.TabIndex = 72
            Me.GroupBox40.TabStop = False
            Me.GroupBox40.Text = "Global Locks"
            '
            'gbEpLocks
            '
            Me.gbEpLocks.Controls.Add(Me.chkEpLockTitle)
            Me.gbEpLocks.Controls.Add(Me.chkEpLockRating)
            Me.gbEpLocks.Controls.Add(Me.chkEpLockPlot)
            Me.gbEpLocks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbEpLocks.Location = New System.Drawing.Point(5, 112)
            Me.gbEpLocks.Name = "gbEpLocks"
            Me.gbEpLocks.Size = New System.Drawing.Size(181, 66)
            Me.gbEpLocks.TabIndex = 9
            Me.gbEpLocks.TabStop = False
            Me.gbEpLocks.Text = "Episode"
            '
            'chkEpLockTitle
            '
            Me.chkEpLockTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpLockTitle.Location = New System.Drawing.Point(6, 15)
            Me.chkEpLockTitle.Name = "chkEpLockTitle"
            Me.chkEpLockTitle.Size = New System.Drawing.Size(166, 17)
            Me.chkEpLockTitle.TabIndex = 2
            Me.chkEpLockTitle.Text = "Lock Title"
            Me.chkEpLockTitle.UseVisualStyleBackColor = True
            '
            'chkEpLockRating
            '
            Me.chkEpLockRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpLockRating.Location = New System.Drawing.Point(6, 47)
            Me.chkEpLockRating.Name = "chkEpLockRating"
            Me.chkEpLockRating.Size = New System.Drawing.Size(168, 17)
            Me.chkEpLockRating.TabIndex = 4
            Me.chkEpLockRating.Text = "Lock Rating"
            Me.chkEpLockRating.UseVisualStyleBackColor = True
            '
            'chkEpLockPlot
            '
            Me.chkEpLockPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpLockPlot.Location = New System.Drawing.Point(6, 31)
            Me.chkEpLockPlot.Name = "chkEpLockPlot"
            Me.chkEpLockPlot.Size = New System.Drawing.Size(166, 17)
            Me.chkEpLockPlot.TabIndex = 0
            Me.chkEpLockPlot.Text = "Lock Plot"
            Me.chkEpLockPlot.UseVisualStyleBackColor = True
            '
            'gbShowLocks
            '
            Me.gbShowLocks.Controls.Add(Me.chkShowLockPlot)
            Me.gbShowLocks.Controls.Add(Me.chkShowLockGenre)
            Me.gbShowLocks.Controls.Add(Me.chkShowLockStudio)
            Me.gbShowLocks.Controls.Add(Me.chkShowLockRating)
            Me.gbShowLocks.Controls.Add(Me.chkShowLockTitle)
            Me.gbShowLocks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbShowLocks.Location = New System.Drawing.Point(5, 13)
            Me.gbShowLocks.Name = "gbShowLocks"
            Me.gbShowLocks.Size = New System.Drawing.Size(181, 96)
            Me.gbShowLocks.TabIndex = 8
            Me.gbShowLocks.TabStop = False
            Me.gbShowLocks.Text = "Show"
            '
            'chkShowLockPlot
            '
            Me.chkShowLockPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowLockPlot.Location = New System.Drawing.Point(6, 29)
            Me.chkShowLockPlot.Name = "chkShowLockPlot"
            Me.chkShowLockPlot.Size = New System.Drawing.Size(168, 17)
            Me.chkShowLockPlot.TabIndex = 8
            Me.chkShowLockPlot.Text = "Lock Plot"
            Me.chkShowLockPlot.UseVisualStyleBackColor = True
            '
            'chkShowLockGenre
            '
            Me.chkShowLockGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowLockGenre.Location = New System.Drawing.Point(6, 61)
            Me.chkShowLockGenre.Name = "chkShowLockGenre"
            Me.chkShowLockGenre.Size = New System.Drawing.Size(168, 17)
            Me.chkShowLockGenre.TabIndex = 11
            Me.chkShowLockGenre.Text = "Lock Genre"
            Me.chkShowLockGenre.UseVisualStyleBackColor = True
            '
            'chkShowLockStudio
            '
            Me.chkShowLockStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowLockStudio.Location = New System.Drawing.Point(6, 77)
            Me.chkShowLockStudio.Name = "chkShowLockStudio"
            Me.chkShowLockStudio.Size = New System.Drawing.Size(168, 17)
            Me.chkShowLockStudio.TabIndex = 5
            Me.chkShowLockStudio.Text = "Lock Studio"
            Me.chkShowLockStudio.UseVisualStyleBackColor = True
            '
            'chkShowLockRating
            '
            Me.chkShowLockRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowLockRating.Location = New System.Drawing.Point(6, 45)
            Me.chkShowLockRating.Name = "chkShowLockRating"
            Me.chkShowLockRating.Size = New System.Drawing.Size(168, 17)
            Me.chkShowLockRating.TabIndex = 10
            Me.chkShowLockRating.Text = "Lock Rating"
            Me.chkShowLockRating.UseVisualStyleBackColor = True
            '
            'chkShowLockTitle
            '
            Me.chkShowLockTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowLockTitle.Location = New System.Drawing.Point(6, 13)
            Me.chkShowLockTitle.Name = "chkShowLockTitle"
            Me.chkShowLockTitle.Size = New System.Drawing.Size(168, 17)
            Me.chkShowLockTitle.TabIndex = 9
            Me.chkShowLockTitle.Text = "Lock Title"
            Me.chkShowLockTitle.UseVisualStyleBackColor = True
            '
            'GroupBox41
            '
            Me.GroupBox41.Controls.Add(Me.gbTVMIDefaults)
            Me.GroupBox41.Controls.Add(Me.cboTVMetaDataOverlay)
            Me.GroupBox41.Controls.Add(Me.Label50)
            Me.GroupBox41.Controls.Add(Me.chkTVScanMetaData)
            Me.GroupBox41.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox41.Location = New System.Drawing.Point(403, 6)
            Me.GroupBox41.Name = "GroupBox41"
            Me.GroupBox41.Size = New System.Drawing.Size(208, 243)
            Me.GroupBox41.TabIndex = 71
            Me.GroupBox41.TabStop = False
            Me.GroupBox41.Text = "Meta Data"
            '
            'gbTVMIDefaults
            '
            Me.gbTVMIDefaults.Controls.Add(Me.lstTVMetaData)
            Me.gbTVMIDefaults.Controls.Add(Me.txtTVDefFIExt)
            Me.gbTVMIDefaults.Controls.Add(Me.Label49)
            Me.gbTVMIDefaults.Controls.Add(Me.btnRemoveTVMetaDataFT)
            Me.gbTVMIDefaults.Controls.Add(Me.btnEditTVMetaDataFT)
            Me.gbTVMIDefaults.Controls.Add(Me.btnNewTVMetaDataFT)
            Me.gbTVMIDefaults.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTVMIDefaults.Location = New System.Drawing.Point(12, 93)
            Me.gbTVMIDefaults.Name = "gbTVMIDefaults"
            Me.gbTVMIDefaults.Size = New System.Drawing.Size(183, 144)
            Me.gbTVMIDefaults.TabIndex = 8
            Me.gbTVMIDefaults.TabStop = False
            Me.gbTVMIDefaults.Text = "Defaults by File Type"
            '
            'lstTVMetaData
            '
            Me.lstTVMetaData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstTVMetaData.FormattingEnabled = True
            Me.lstTVMetaData.Location = New System.Drawing.Point(10, 16)
            Me.lstTVMetaData.Name = "lstTVMetaData"
            Me.lstTVMetaData.Size = New System.Drawing.Size(165, 95)
            Me.lstTVMetaData.TabIndex = 34
            '
            'txtTVDefFIExt
            '
            Me.txtTVDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTVDefFIExt.Location = New System.Drawing.Point(73, 116)
            Me.txtTVDefFIExt.Name = "txtTVDefFIExt"
            Me.txtTVDefFIExt.Size = New System.Drawing.Size(35, 22)
            Me.txtTVDefFIExt.TabIndex = 33
            '
            'Label49
            '
            Me.Label49.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label49.Location = New System.Drawing.Point(8, 116)
            Me.Label49.Name = "Label49"
            Me.Label49.Size = New System.Drawing.Size(66, 19)
            Me.Label49.TabIndex = 32
            Me.Label49.Text = "File Type"
            Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveTVMetaDataFT
            '
            Me.btnRemoveTVMetaDataFT.Enabled = False
            Me.btnRemoveTVMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveTVMetaDataFT.Location = New System.Drawing.Point(153, 115)
            Me.btnRemoveTVMetaDataFT.Name = "btnRemoveTVMetaDataFT"
            Me.btnRemoveTVMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveTVMetaDataFT.TabIndex = 31
            Me.btnRemoveTVMetaDataFT.UseVisualStyleBackColor = True
            '
            'btnEditTVMetaDataFT
            '
            Me.btnEditTVMetaDataFT.Enabled = False
            Me.btnEditTVMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditTVMetaDataFT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditTVMetaDataFT.Location = New System.Drawing.Point(130, 115)
            Me.btnEditTVMetaDataFT.Name = "btnEditTVMetaDataFT"
            Me.btnEditTVMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnEditTVMetaDataFT.TabIndex = 30
            Me.btnEditTVMetaDataFT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditTVMetaDataFT.UseVisualStyleBackColor = True
            '
            'btnNewTVMetaDataFT
            '
            Me.btnNewTVMetaDataFT.Enabled = False
            Me.btnNewTVMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnNewTVMetaDataFT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNewTVMetaDataFT.Location = New System.Drawing.Point(108, 115)
            Me.btnNewTVMetaDataFT.Name = "btnNewTVMetaDataFT"
            Me.btnNewTVMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnNewTVMetaDataFT.TabIndex = 29
            Me.btnNewTVMetaDataFT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNewTVMetaDataFT.UseVisualStyleBackColor = True
            '
            'cboTVMetaDataOverlay
            '
            Me.cboTVMetaDataOverlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTVMetaDataOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cboTVMetaDataOverlay.FormattingEnabled = True
            Me.cboTVMetaDataOverlay.Location = New System.Drawing.Point(13, 62)
            Me.cboTVMetaDataOverlay.Name = "cboTVMetaDataOverlay"
            Me.cboTVMetaDataOverlay.Size = New System.Drawing.Size(182, 21)
            Me.cboTVMetaDataOverlay.Sorted = True
            Me.cboTVMetaDataOverlay.TabIndex = 17
            '
            'Label50
            '
            Me.Label50.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label50.Location = New System.Drawing.Point(4, 35)
            Me.Label50.Name = "Label50"
            Me.Label50.Size = New System.Drawing.Size(202, 29)
            Me.Label50.TabIndex = 16
            Me.Label50.Text = "Display Overlay if Video Contains an Audio Stream With the Following Language:"
            Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'chkTVScanMetaData
            '
            Me.chkTVScanMetaData.AutoSize = True
            Me.chkTVScanMetaData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTVScanMetaData.Location = New System.Drawing.Point(5, 16)
            Me.chkTVScanMetaData.Name = "chkTVScanMetaData"
            Me.chkTVScanMetaData.Size = New System.Drawing.Size(106, 17)
            Me.chkTVScanMetaData.TabIndex = 7
            Me.chkTVScanMetaData.Text = "Scan Meta Data"
            Me.chkTVScanMetaData.UseVisualStyleBackColor = True
            '
            'gbTVScraperOptions
            '
            Me.gbTVScraperOptions.Controls.Add(Me.lblOrdering)
            Me.gbTVScraperOptions.Controls.Add(Me.cbOrdering)
            Me.gbTVScraperOptions.Controls.Add(Me.lblTVUpdate)
            Me.gbTVScraperOptions.Controls.Add(Me.cboTVUpdate)
            Me.gbTVScraperOptions.Controls.Add(Me.gbLanguage)
            Me.gbTVScraperOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTVScraperOptions.Location = New System.Drawing.Point(5, 6)
            Me.gbTVScraperOptions.Name = "gbTVScraperOptions"
            Me.gbTVScraperOptions.Size = New System.Drawing.Size(200, 359)
            Me.gbTVScraperOptions.TabIndex = 70
            Me.gbTVScraperOptions.TabStop = False
            Me.gbTVScraperOptions.Text = "Options"
            '
            'lblOrdering
            '
            Me.lblOrdering.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lblOrdering.Location = New System.Drawing.Point(12, 284)
            Me.lblOrdering.Name = "lblOrdering"
            Me.lblOrdering.Size = New System.Drawing.Size(177, 13)
            Me.lblOrdering.TabIndex = 8
            Me.lblOrdering.Text = "Default Episode Ordering:"
            Me.lblOrdering.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'cbOrdering
            '
            Me.cbOrdering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbOrdering.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbOrdering.FormattingEnabled = True
            Me.cbOrdering.Location = New System.Drawing.Point(17, 304)
            Me.cbOrdering.Name = "cbOrdering"
            Me.cbOrdering.Size = New System.Drawing.Size(166, 21)
            Me.cbOrdering.TabIndex = 7
            '
            'lblTVUpdate
            '
            Me.lblTVUpdate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTVUpdate.Location = New System.Drawing.Point(5, 217)
            Me.lblTVUpdate.Name = "lblTVUpdate"
            Me.lblTVUpdate.Size = New System.Drawing.Size(190, 31)
            Me.lblTVUpdate.TabIndex = 5
            Me.lblTVUpdate.Text = "Re-download Show Information Every:"
            Me.lblTVUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'cboTVUpdate
            '
            Me.cboTVUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTVUpdate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cboTVUpdate.FormattingEnabled = True
            Me.cboTVUpdate.Location = New System.Drawing.Point(17, 248)
            Me.cboTVUpdate.Name = "cboTVUpdate"
            Me.cboTVUpdate.Size = New System.Drawing.Size(166, 21)
            Me.cboTVUpdate.TabIndex = 3
            '
            'gbLanguage
            '
            Me.gbLanguage.Controls.Add(Me.lblTVLanguagePreferred)
            Me.gbLanguage.Controls.Add(Me.btnTVLanguageFetch)
            Me.gbLanguage.Controls.Add(Me.cbTVLanguage)
            Me.gbLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbLanguage.Location = New System.Drawing.Point(5, 92)
            Me.gbLanguage.Name = "gbLanguage"
            Me.gbLanguage.Size = New System.Drawing.Size(190, 100)
            Me.gbLanguage.TabIndex = 0
            Me.gbLanguage.TabStop = False
            Me.gbLanguage.Text = "Language"
            '
            'lblTVLanguagePreferred
            '
            Me.lblTVLanguagePreferred.AutoSize = True
            Me.lblTVLanguagePreferred.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTVLanguagePreferred.Location = New System.Drawing.Point(10, 24)
            Me.lblTVLanguagePreferred.Name = "lblTVLanguagePreferred"
            Me.lblTVLanguagePreferred.Size = New System.Drawing.Size(111, 13)
            Me.lblTVLanguagePreferred.TabIndex = 2
            Me.lblTVLanguagePreferred.Text = "Preferred Language:"
            '
            'btnTVLanguageFetch
            '
            Me.btnTVLanguageFetch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnTVLanguageFetch.Location = New System.Drawing.Point(12, 68)
            Me.btnTVLanguageFetch.Name = "btnTVLanguageFetch"
            Me.btnTVLanguageFetch.Size = New System.Drawing.Size(166, 23)
            Me.btnTVLanguageFetch.TabIndex = 1
            Me.btnTVLanguageFetch.Text = "Fetch Available Languages"
            Me.btnTVLanguageFetch.UseVisualStyleBackColor = True
            '
            'cbTVLanguage
            '
            Me.cbTVLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbTVLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbTVLanguage.Location = New System.Drawing.Point(12, 39)
            Me.cbTVLanguage.Name = "cbTVLanguage"
            Me.cbTVLanguage.Size = New System.Drawing.Size(166, 21)
            Me.cbTVLanguage.TabIndex = 0
            '
            'TVScraper
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GroupBox37)
            Me.Controls.Add(Me.GroupBox40)
            Me.Controls.Add(Me.GroupBox41)
            Me.Controls.Add(Me.gbTVScraperOptions)
            Me.Name = "TVScraper"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Data
            Me.PanelOrder = 300
            Me.PanelText = "Scrapers - Data"
            Me.PanelType = "TV Shows"
            Me.GroupBox37.ResumeLayout(False)
            Me.GroupBox38.ResumeLayout(False)
            Me.GroupBox39.ResumeLayout(False)
            Me.GroupBox40.ResumeLayout(False)
            Me.gbEpLocks.ResumeLayout(False)
            Me.gbShowLocks.ResumeLayout(False)
            Me.GroupBox41.ResumeLayout(False)
            Me.GroupBox41.PerformLayout()
            Me.gbTVMIDefaults.ResumeLayout(False)
            Me.gbTVMIDefaults.PerformLayout()
            Me.gbTVScraperOptions.ResumeLayout(False)
            Me.gbLanguage.ResumeLayout(False)
            Me.gbLanguage.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBox37 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox38 As System.Windows.Forms.GroupBox
        Friend WithEvents chkScraperShowRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowActors As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowStudio As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowPremiered As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowEGU As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowMPAA As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowGenre As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperShowTitle As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox39 As System.Windows.Forms.GroupBox
        Friend WithEvents chkScraperEpActors As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpCredits As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpDirector As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpAired As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpTitle As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpEpisode As System.Windows.Forms.CheckBox
        Friend WithEvents chkScraperEpSeason As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox40 As System.Windows.Forms.GroupBox
        Friend WithEvents gbEpLocks As System.Windows.Forms.GroupBox
        Friend WithEvents chkEpLockTitle As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpLockRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpLockPlot As System.Windows.Forms.CheckBox
        Friend WithEvents gbShowLocks As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowLockPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowLockGenre As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowLockStudio As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowLockRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowLockTitle As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox41 As System.Windows.Forms.GroupBox
        Friend WithEvents gbTVMIDefaults As System.Windows.Forms.GroupBox
        Friend WithEvents lstTVMetaData As System.Windows.Forms.ListBox
        Friend WithEvents txtTVDefFIExt As System.Windows.Forms.TextBox
        Friend WithEvents Label49 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveTVMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents btnEditTVMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents btnNewTVMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents cboTVMetaDataOverlay As System.Windows.Forms.ComboBox
        Friend WithEvents Label50 As System.Windows.Forms.Label
        Friend WithEvents chkTVScanMetaData As System.Windows.Forms.CheckBox
        Friend WithEvents gbTVScraperOptions As System.Windows.Forms.GroupBox
        Friend WithEvents lblOrdering As System.Windows.Forms.Label
        Friend WithEvents cbOrdering As System.Windows.Forms.ComboBox
        Friend WithEvents lblTVUpdate As System.Windows.Forms.Label
        Friend WithEvents cboTVUpdate As System.Windows.Forms.ComboBox
        Friend WithEvents gbLanguage As System.Windows.Forms.GroupBox
        Friend WithEvents lblTVLanguagePreferred As System.Windows.Forms.Label
        Friend WithEvents btnTVLanguageFetch As System.Windows.Forms.Button
        Friend WithEvents cbTVLanguage As System.Windows.Forms.ComboBox

    End Class
End Namespace