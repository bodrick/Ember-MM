Imports EmberControls

Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Scraper
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
            Me.gbGlobalLocks = New System.Windows.Forms.GroupBox()
            Me.chkLockOutline = New System.Windows.Forms.CheckBox()
            Me.chkLockPlot = New System.Windows.Forms.CheckBox()
            Me.chkLockTrailer = New System.Windows.Forms.CheckBox()
            Me.chkLockGenre = New System.Windows.Forms.CheckBox()
            Me.chkLockRealStudio = New System.Windows.Forms.CheckBox()
            Me.chkLockRating = New System.Windows.Forms.CheckBox()
            Me.chkLockTagline = New System.Windows.Forms.CheckBox()
            Me.chkLockTitle = New System.Windows.Forms.CheckBox()
            Me.gbOptions = New System.Windows.Forms.GroupBox()
            Me.chkCertification = New System.Windows.Forms.CheckBox()
            Me.chkTop250 = New System.Windows.Forms.CheckBox()
            Me.chkCountry = New System.Windows.Forms.CheckBox()
            Me.txtGenreLimit = New EmberControls.IntegerTextbox()
            Me.lblGenreLimit = New System.Windows.Forms.Label()
            Me.txtActorLimit = New EmberControls.IntegerTextbox()
            Me.lblCastLimit = New System.Windows.Forms.Label()
            Me.chkCrew = New System.Windows.Forms.CheckBox()
            Me.chkMusicBy = New System.Windows.Forms.CheckBox()
            Me.chkProducers = New System.Windows.Forms.CheckBox()
            Me.chkWriters = New System.Windows.Forms.CheckBox()
            Me.chkStudio = New System.Windows.Forms.CheckBox()
            Me.chkRuntime = New System.Windows.Forms.CheckBox()
            Me.chkPlot = New System.Windows.Forms.CheckBox()
            Me.chkOutline = New System.Windows.Forms.CheckBox()
            Me.chkGenre = New System.Windows.Forms.CheckBox()
            Me.chkDirector = New System.Windows.Forms.CheckBox()
            Me.chkTagline = New System.Windows.Forms.CheckBox()
            Me.chkCast = New System.Windows.Forms.CheckBox()
            Me.chkVotes = New System.Windows.Forms.CheckBox()
            Me.chkTrailer = New System.Windows.Forms.CheckBox()
            Me.chkRating = New System.Windows.Forms.CheckBox()
            Me.chkRelease = New System.Windows.Forms.CheckBox()
            Me.chkMPAA = New System.Windows.Forms.CheckBox()
            Me.chkYear = New System.Windows.Forms.CheckBox()
            Me.chkTitle = New System.Windows.Forms.CheckBox()
            Me.gbMiscellaneous = New System.Windows.Forms.GroupBox()
            Me.chkOnlyValueForCert = New System.Windows.Forms.CheckBox()
            Me.cbForce = New System.Windows.Forms.ComboBox()
            Me.chkForceTitle = New System.Windows.Forms.CheckBox()
            Me.chkOutlineForPlot = New System.Windows.Forms.CheckBox()
            Me.chkCastWithImg = New System.Windows.Forms.CheckBox()
            Me.chkUseCertForMPAA = New System.Windows.Forms.CheckBox()
            Me.chkFullCast = New System.Windows.Forms.CheckBox()
            Me.chkFullCrew = New System.Windows.Forms.CheckBox()
            Me.cbCert = New System.Windows.Forms.ComboBox()
            Me.chkCert = New System.Windows.Forms.CheckBox()
            Me.gbMetaData = New System.Windows.Forms.GroupBox()
            Me.gbDefaultsByFileType = New System.Windows.Forms.GroupBox()
            Me.lstMetaData = New System.Windows.Forms.ListBox()
            Me.txtDefFIExt = New System.Windows.Forms.TextBox()
            Me.lblFileType = New System.Windows.Forms.Label()
            Me.btnRemoveMetaDataFT = New System.Windows.Forms.Button()
            Me.btnEditMetaDataFT = New System.Windows.Forms.Button()
            Me.btnNewMetaDataFT = New System.Windows.Forms.Button()
            Me.chkIFOScan = New System.Windows.Forms.CheckBox()
            Me.cbLanguages = New System.Windows.Forms.ComboBox()
            Me.lblDisplayOverlay = New System.Windows.Forms.Label()
            Me.gbRTFormat = New System.Windows.Forms.GroupBox()
            Me.lblDurationFormat = New System.Windows.Forms.Label()
            Me.txtRuntimeFormat = New System.Windows.Forms.TextBox()
            Me.chkUseMIDuration = New System.Windows.Forms.CheckBox()
            Me.chkScanMediaInfo = New System.Windows.Forms.CheckBox()
            Me.gbGlobalLocks.SuspendLayout()
            Me.gbOptions.SuspendLayout()
            Me.gbMiscellaneous.SuspendLayout()
            Me.gbMetaData.SuspendLayout()
            Me.gbDefaultsByFileType.SuspendLayout()
            Me.gbRTFormat.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbGlobalLocks
            '
            Me.gbGlobalLocks.Controls.Add(Me.chkLockOutline)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockPlot)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockTrailer)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockGenre)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockRealStudio)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockRating)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockTagline)
            Me.gbGlobalLocks.Controls.Add(Me.chkLockTitle)
            Me.gbGlobalLocks.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbGlobalLocks.Location = New System.Drawing.Point(8, 6)
            Me.gbGlobalLocks.Name = "gbGlobalLocks"
            Me.gbGlobalLocks.Size = New System.Drawing.Size(145, 176)
            Me.gbGlobalLocks.TabIndex = 69
            Me.gbGlobalLocks.TabStop = False
            Me.gbGlobalLocks.Text = "Global Locks"
            '
            'chkLockOutline
            '
            Me.chkLockOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockOutline.Location = New System.Drawing.Point(6, 50)
            Me.chkLockOutline.Name = "chkLockOutline"
            Me.chkLockOutline.Size = New System.Drawing.Size(129, 17)
            Me.chkLockOutline.TabIndex = 1
            Me.chkLockOutline.Text = "Lock Outline"
            Me.chkLockOutline.UseVisualStyleBackColor = True
            '
            'chkLockPlot
            '
            Me.chkLockPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockPlot.Location = New System.Drawing.Point(6, 33)
            Me.chkLockPlot.Name = "chkLockPlot"
            Me.chkLockPlot.Size = New System.Drawing.Size(129, 17)
            Me.chkLockPlot.TabIndex = 0
            Me.chkLockPlot.Text = "Lock Plot"
            Me.chkLockPlot.UseVisualStyleBackColor = True
            '
            'chkLockTrailer
            '
            Me.chkLockTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockTrailer.Location = New System.Drawing.Point(6, 135)
            Me.chkLockTrailer.Name = "chkLockTrailer"
            Me.chkLockTrailer.Size = New System.Drawing.Size(129, 17)
            Me.chkLockTrailer.TabIndex = 46
            Me.chkLockTrailer.Text = "Lock Trailer"
            Me.chkLockTrailer.UseVisualStyleBackColor = True
            '
            'chkLockGenre
            '
            Me.chkLockGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockGenre.Location = New System.Drawing.Point(6, 118)
            Me.chkLockGenre.Name = "chkLockGenre"
            Me.chkLockGenre.Size = New System.Drawing.Size(129, 17)
            Me.chkLockGenre.TabIndex = 7
            Me.chkLockGenre.Text = "Lock Genre"
            Me.chkLockGenre.UseVisualStyleBackColor = True
            '
            'chkLockRealStudio
            '
            Me.chkLockRealStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockRealStudio.Location = New System.Drawing.Point(6, 101)
            Me.chkLockRealStudio.Name = "chkLockRealStudio"
            Me.chkLockRealStudio.Size = New System.Drawing.Size(129, 17)
            Me.chkLockRealStudio.TabIndex = 5
            Me.chkLockRealStudio.Text = "Lock Studio"
            Me.chkLockRealStudio.UseVisualStyleBackColor = True
            '
            'chkLockRating
            '
            Me.chkLockRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockRating.Location = New System.Drawing.Point(6, 84)
            Me.chkLockRating.Name = "chkLockRating"
            Me.chkLockRating.Size = New System.Drawing.Size(129, 17)
            Me.chkLockRating.TabIndex = 4
            Me.chkLockRating.Text = "Lock Rating"
            Me.chkLockRating.UseVisualStyleBackColor = True
            '
            'chkLockTagline
            '
            Me.chkLockTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockTagline.Location = New System.Drawing.Point(6, 67)
            Me.chkLockTagline.Name = "chkLockTagline"
            Me.chkLockTagline.Size = New System.Drawing.Size(129, 17)
            Me.chkLockTagline.TabIndex = 3
            Me.chkLockTagline.Text = "Lock Tagline"
            Me.chkLockTagline.UseVisualStyleBackColor = True
            '
            'chkLockTitle
            '
            Me.chkLockTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockTitle.Location = New System.Drawing.Point(6, 16)
            Me.chkLockTitle.Name = "chkLockTitle"
            Me.chkLockTitle.Size = New System.Drawing.Size(129, 17)
            Me.chkLockTitle.TabIndex = 2
            Me.chkLockTitle.Text = "Lock Title"
            Me.chkLockTitle.UseVisualStyleBackColor = True
            '
            'gbOptions
            '
            Me.gbOptions.Controls.Add(Me.chkCertification)
            Me.gbOptions.Controls.Add(Me.chkTop250)
            Me.gbOptions.Controls.Add(Me.chkCountry)
            Me.gbOptions.Controls.Add(Me.txtGenreLimit)
            Me.gbOptions.Controls.Add(Me.lblGenreLimit)
            Me.gbOptions.Controls.Add(Me.txtActorLimit)
            Me.gbOptions.Controls.Add(Me.lblCastLimit)
            Me.gbOptions.Controls.Add(Me.chkCrew)
            Me.gbOptions.Controls.Add(Me.chkMusicBy)
            Me.gbOptions.Controls.Add(Me.chkProducers)
            Me.gbOptions.Controls.Add(Me.chkWriters)
            Me.gbOptions.Controls.Add(Me.chkStudio)
            Me.gbOptions.Controls.Add(Me.chkRuntime)
            Me.gbOptions.Controls.Add(Me.chkPlot)
            Me.gbOptions.Controls.Add(Me.chkOutline)
            Me.gbOptions.Controls.Add(Me.chkGenre)
            Me.gbOptions.Controls.Add(Me.chkDirector)
            Me.gbOptions.Controls.Add(Me.chkTagline)
            Me.gbOptions.Controls.Add(Me.chkCast)
            Me.gbOptions.Controls.Add(Me.chkVotes)
            Me.gbOptions.Controls.Add(Me.chkTrailer)
            Me.gbOptions.Controls.Add(Me.chkRating)
            Me.gbOptions.Controls.Add(Me.chkRelease)
            Me.gbOptions.Controls.Add(Me.chkMPAA)
            Me.gbOptions.Controls.Add(Me.chkYear)
            Me.gbOptions.Controls.Add(Me.chkTitle)
            Me.gbOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbOptions.Location = New System.Drawing.Point(8, 187)
            Me.gbOptions.Name = "gbOptions"
            Me.gbOptions.Size = New System.Drawing.Size(302, 179)
            Me.gbOptions.TabIndex = 71
            Me.gbOptions.TabStop = False
            Me.gbOptions.Text = "Scraper Fields - Global"
            '
            'chkCertification
            '
            Me.chkCertification.AutoSize = True
            Me.chkCertification.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCertification.Location = New System.Drawing.Point(6, 76)
            Me.chkCertification.Name = "chkCertification"
            Me.chkCertification.Size = New System.Drawing.Size(89, 17)
            Me.chkCertification.TabIndex = 24
            Me.chkCertification.Text = "Certification"
            Me.chkCertification.UseVisualStyleBackColor = True
            '
            'chkTop250
            '
            Me.chkTop250.AutoSize = True
            Me.chkTop250.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTop250.Location = New System.Drawing.Point(205, 133)
            Me.chkTop250.Name = "chkTop250"
            Me.chkTop250.Size = New System.Drawing.Size(66, 17)
            Me.chkTop250.TabIndex = 23
            Me.chkTop250.Text = "Top 250"
            Me.chkTop250.UseVisualStyleBackColor = True
            '
            'chkCountry
            '
            Me.chkCountry.AutoSize = True
            Me.chkCountry.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCountry.Location = New System.Drawing.Point(205, 152)
            Me.chkCountry.Name = "chkCountry"
            Me.chkCountry.Size = New System.Drawing.Size(67, 17)
            Me.chkCountry.TabIndex = 25
            Me.chkCountry.Text = "Country"
            Me.chkCountry.UseVisualStyleBackColor = True
            '
            'txtGenreLimit
            '
            Me.txtGenreLimit.Enabled = False
            Me.txtGenreLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGenreLimit.Location = New System.Drawing.Point(255, 55)
            Me.txtGenreLimit.Name = "txtGenreLimit"
            Me.txtGenreLimit.Size = New System.Drawing.Size(39, 22)
            Me.txtGenreLimit.TabIndex = 21
            '
            'lblGenreLimit
            '
            Me.lblGenreLimit.AutoSize = True
            Me.lblGenreLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGenreLimit.Location = New System.Drawing.Point(223, 58)
            Me.lblGenreLimit.Name = "lblGenreLimit"
            Me.lblGenreLimit.Size = New System.Drawing.Size(34, 13)
            Me.lblGenreLimit.TabIndex = 22
            Me.lblGenreLimit.Text = "Limit:"
            Me.lblGenreLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtActorLimit
            '
            Me.txtActorLimit.Enabled = False
            Me.txtActorLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtActorLimit.Location = New System.Drawing.Point(151, 112)
            Me.txtActorLimit.Name = "txtActorLimit"
            Me.txtActorLimit.Size = New System.Drawing.Size(39, 22)
            Me.txtActorLimit.TabIndex = 19
            '
            'lblCastLimit
            '
            Me.lblCastLimit.AutoSize = True
            Me.lblCastLimit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCastLimit.Location = New System.Drawing.Point(118, 115)
            Me.lblCastLimit.Name = "lblCastLimit"
            Me.lblCastLimit.Size = New System.Drawing.Size(34, 13)
            Me.lblCastLimit.TabIndex = 20
            Me.lblCastLimit.Text = "Limit:"
            Me.lblCastLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkCrew
            '
            Me.chkCrew.AutoSize = True
            Me.chkCrew.Enabled = False
            Me.chkCrew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCrew.Location = New System.Drawing.Point(205, 114)
            Me.chkCrew.Name = "chkCrew"
            Me.chkCrew.Size = New System.Drawing.Size(85, 17)
            Me.chkCrew.TabIndex = 18
            Me.chkCrew.Text = "Other Crew"
            Me.chkCrew.UseVisualStyleBackColor = True
            '
            'chkMusicBy
            '
            Me.chkMusicBy.AutoSize = True
            Me.chkMusicBy.Enabled = False
            Me.chkMusicBy.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMusicBy.Location = New System.Drawing.Point(205, 95)
            Me.chkMusicBy.Name = "chkMusicBy"
            Me.chkMusicBy.Size = New System.Drawing.Size(71, 17)
            Me.chkMusicBy.TabIndex = 17
            Me.chkMusicBy.Text = "Music By"
            Me.chkMusicBy.UseVisualStyleBackColor = True
            '
            'chkProducers
            '
            Me.chkProducers.AutoSize = True
            Me.chkProducers.Enabled = False
            Me.chkProducers.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkProducers.Location = New System.Drawing.Point(205, 19)
            Me.chkProducers.Name = "chkProducers"
            Me.chkProducers.Size = New System.Drawing.Size(77, 17)
            Me.chkProducers.TabIndex = 16
            Me.chkProducers.Text = "Producers"
            Me.chkProducers.UseVisualStyleBackColor = True
            '
            'chkWriters
            '
            Me.chkWriters.AutoSize = True
            Me.chkWriters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWriters.Location = New System.Drawing.Point(101, 152)
            Me.chkWriters.Name = "chkWriters"
            Me.chkWriters.Size = New System.Drawing.Size(63, 17)
            Me.chkWriters.TabIndex = 15
            Me.chkWriters.Text = "Writers"
            Me.chkWriters.UseVisualStyleBackColor = True
            '
            'chkStudio
            '
            Me.chkStudio.AutoSize = True
            Me.chkStudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkStudio.Location = New System.Drawing.Point(101, 19)
            Me.chkStudio.Name = "chkStudio"
            Me.chkStudio.Size = New System.Drawing.Size(60, 17)
            Me.chkStudio.TabIndex = 14
            Me.chkStudio.Text = "Studio"
            Me.chkStudio.UseVisualStyleBackColor = True
            '
            'chkRuntime
            '
            Me.chkRuntime.AutoSize = True
            Me.chkRuntime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRuntime.Location = New System.Drawing.Point(6, 114)
            Me.chkRuntime.Name = "chkRuntime"
            Me.chkRuntime.Size = New System.Drawing.Size(69, 17)
            Me.chkRuntime.TabIndex = 13
            Me.chkRuntime.Text = "Runtime"
            Me.chkRuntime.UseVisualStyleBackColor = True
            '
            'chkPlot
            '
            Me.chkPlot.AutoSize = True
            Me.chkPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPlot.Location = New System.Drawing.Point(101, 76)
            Me.chkPlot.Name = "chkPlot"
            Me.chkPlot.Size = New System.Drawing.Size(46, 17)
            Me.chkPlot.TabIndex = 12
            Me.chkPlot.Text = "Plot"
            Me.chkPlot.UseVisualStyleBackColor = True
            '
            'chkOutline
            '
            Me.chkOutline.AutoSize = True
            Me.chkOutline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOutline.Location = New System.Drawing.Point(101, 57)
            Me.chkOutline.Name = "chkOutline"
            Me.chkOutline.Size = New System.Drawing.Size(65, 17)
            Me.chkOutline.TabIndex = 11
            Me.chkOutline.Text = "Outline"
            Me.chkOutline.UseVisualStyleBackColor = True
            '
            'chkGenre
            '
            Me.chkGenre.AutoSize = True
            Me.chkGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkGenre.Location = New System.Drawing.Point(205, 38)
            Me.chkGenre.Name = "chkGenre"
            Me.chkGenre.Size = New System.Drawing.Size(57, 17)
            Me.chkGenre.TabIndex = 10
            Me.chkGenre.Text = "Genre"
            Me.chkGenre.UseVisualStyleBackColor = True
            '
            'chkDirector
            '
            Me.chkDirector.AutoSize = True
            Me.chkDirector.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDirector.Location = New System.Drawing.Point(101, 133)
            Me.chkDirector.Name = "chkDirector"
            Me.chkDirector.Size = New System.Drawing.Size(67, 17)
            Me.chkDirector.TabIndex = 9
            Me.chkDirector.Text = "Director"
            Me.chkDirector.UseVisualStyleBackColor = True
            '
            'chkTagline
            '
            Me.chkTagline.AutoSize = True
            Me.chkTagline.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTagline.Location = New System.Drawing.Point(101, 38)
            Me.chkTagline.Name = "chkTagline"
            Me.chkTagline.Size = New System.Drawing.Size(63, 17)
            Me.chkTagline.TabIndex = 8
            Me.chkTagline.Text = "Tagline"
            Me.chkTagline.UseVisualStyleBackColor = True
            '
            'chkCast
            '
            Me.chkCast.AutoSize = True
            Me.chkCast.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCast.Location = New System.Drawing.Point(101, 95)
            Me.chkCast.Name = "chkCast"
            Me.chkCast.Size = New System.Drawing.Size(48, 17)
            Me.chkCast.TabIndex = 7
            Me.chkCast.Text = "Cast"
            Me.chkCast.UseVisualStyleBackColor = True
            '
            'chkVotes
            '
            Me.chkVotes.AutoSize = True
            Me.chkVotes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkVotes.Location = New System.Drawing.Point(6, 152)
            Me.chkVotes.Name = "chkVotes"
            Me.chkVotes.Size = New System.Drawing.Size(55, 17)
            Me.chkVotes.TabIndex = 6
            Me.chkVotes.Text = "Votes"
            Me.chkVotes.UseVisualStyleBackColor = True
            '
            'chkTrailer
            '
            Me.chkTrailer.AutoSize = True
            Me.chkTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTrailer.Location = New System.Drawing.Point(205, 76)
            Me.chkTrailer.Name = "chkTrailer"
            Me.chkTrailer.Size = New System.Drawing.Size(57, 17)
            Me.chkTrailer.TabIndex = 5
            Me.chkTrailer.Text = "Trailer"
            Me.chkTrailer.UseVisualStyleBackColor = True
            '
            'chkRating
            '
            Me.chkRating.AutoSize = True
            Me.chkRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRating.Location = New System.Drawing.Point(6, 133)
            Me.chkRating.Name = "chkRating"
            Me.chkRating.Size = New System.Drawing.Size(60, 17)
            Me.chkRating.TabIndex = 4
            Me.chkRating.Text = "Rating"
            Me.chkRating.UseVisualStyleBackColor = True
            '
            'chkRelease
            '
            Me.chkRelease.AutoSize = True
            Me.chkRelease.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRelease.Location = New System.Drawing.Point(6, 95)
            Me.chkRelease.Name = "chkRelease"
            Me.chkRelease.Size = New System.Drawing.Size(92, 17)
            Me.chkRelease.TabIndex = 3
            Me.chkRelease.Text = "Release Date"
            Me.chkRelease.UseVisualStyleBackColor = True
            '
            'chkMPAA
            '
            Me.chkMPAA.AutoSize = True
            Me.chkMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMPAA.Location = New System.Drawing.Point(6, 57)
            Me.chkMPAA.Name = "chkMPAA"
            Me.chkMPAA.Size = New System.Drawing.Size(56, 17)
            Me.chkMPAA.TabIndex = 2
            Me.chkMPAA.Text = "MPAA"
            Me.chkMPAA.UseVisualStyleBackColor = True
            '
            'chkYear
            '
            Me.chkYear.AutoSize = True
            Me.chkYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkYear.Location = New System.Drawing.Point(6, 38)
            Me.chkYear.Name = "chkYear"
            Me.chkYear.Size = New System.Drawing.Size(47, 17)
            Me.chkYear.TabIndex = 1
            Me.chkYear.Text = "Year"
            Me.chkYear.UseVisualStyleBackColor = True
            '
            'chkTitle
            '
            Me.chkTitle.AutoSize = True
            Me.chkTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTitle.Location = New System.Drawing.Point(6, 19)
            Me.chkTitle.Name = "chkTitle"
            Me.chkTitle.Size = New System.Drawing.Size(47, 17)
            Me.chkTitle.TabIndex = 0
            Me.chkTitle.Text = "Title"
            Me.chkTitle.UseVisualStyleBackColor = True
            '
            'gbMiscellaneous
            '
            Me.gbMiscellaneous.Controls.Add(Me.chkOnlyValueForCert)
            Me.gbMiscellaneous.Controls.Add(Me.cbForce)
            Me.gbMiscellaneous.Controls.Add(Me.chkForceTitle)
            Me.gbMiscellaneous.Controls.Add(Me.chkOutlineForPlot)
            Me.gbMiscellaneous.Controls.Add(Me.chkCastWithImg)
            Me.gbMiscellaneous.Controls.Add(Me.chkUseCertForMPAA)
            Me.gbMiscellaneous.Controls.Add(Me.chkFullCast)
            Me.gbMiscellaneous.Controls.Add(Me.chkFullCrew)
            Me.gbMiscellaneous.Controls.Add(Me.cbCert)
            Me.gbMiscellaneous.Controls.Add(Me.chkCert)
            Me.gbMiscellaneous.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMiscellaneous.Location = New System.Drawing.Point(313, 187)
            Me.gbMiscellaneous.Name = "gbMiscellaneous"
            Me.gbMiscellaneous.Size = New System.Drawing.Size(289, 198)
            Me.gbMiscellaneous.TabIndex = 68
            Me.gbMiscellaneous.TabStop = False
            Me.gbMiscellaneous.Text = "Miscellaneous"
            '
            'chkOnlyValueForCert
            '
            Me.chkOnlyValueForCert.AutoSize = True
            Me.chkOnlyValueForCert.Enabled = False
            Me.chkOnlyValueForCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOnlyValueForCert.Location = New System.Drawing.Point(32, 145)
            Me.chkOnlyValueForCert.Name = "chkOnlyValueForCert"
            Me.chkOnlyValueForCert.Size = New System.Drawing.Size(168, 17)
            Me.chkOnlyValueForCert.TabIndex = 66
            Me.chkOnlyValueForCert.Text = "Only Save the Value to NFO"
            Me.chkOnlyValueForCert.UseVisualStyleBackColor = True
            '
            'cbForce
            '
            Me.cbForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbForce.Enabled = False
            Me.cbForce.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbForce.FormattingEnabled = True
            Me.cbForce.Location = New System.Drawing.Point(139, 167)
            Me.cbForce.Name = "cbForce"
            Me.cbForce.Size = New System.Drawing.Size(144, 21)
            Me.cbForce.Sorted = True
            Me.cbForce.TabIndex = 65
            '
            'chkForceTitle
            '
            Me.chkForceTitle.AutoSize = True
            Me.chkForceTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkForceTitle.Location = New System.Drawing.Point(6, 168)
            Me.chkForceTitle.Name = "chkForceTitle"
            Me.chkForceTitle.Size = New System.Drawing.Size(135, 17)
            Me.chkForceTitle.TabIndex = 64
            Me.chkForceTitle.Text = "Force Title Language:"
            Me.chkForceTitle.UseVisualStyleBackColor = True
            '
            'chkOutlineForPlot
            '
            Me.chkOutlineForPlot.AutoSize = True
            Me.chkOutlineForPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOutlineForPlot.Location = New System.Drawing.Point(6, 82)
            Me.chkOutlineForPlot.Name = "chkOutlineForPlot"
            Me.chkOutlineForPlot.Size = New System.Drawing.Size(206, 17)
            Me.chkOutlineForPlot.TabIndex = 3
            Me.chkOutlineForPlot.Text = "Use Outline for Plot if Plot is Empty"
            Me.chkOutlineForPlot.UseVisualStyleBackColor = True
            '
            'chkCastWithImg
            '
            Me.chkCastWithImg.AutoSize = True
            Me.chkCastWithImg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCastWithImg.Location = New System.Drawing.Point(6, 40)
            Me.chkCastWithImg.Name = "chkCastWithImg"
            Me.chkCastWithImg.Size = New System.Drawing.Size(189, 17)
            Me.chkCastWithImg.TabIndex = 1
            Me.chkCastWithImg.Text = "Scrape Only Actors With Images"
            Me.chkCastWithImg.UseVisualStyleBackColor = True
            '
            'chkUseCertForMPAA
            '
            Me.chkUseCertForMPAA.AutoSize = True
            Me.chkUseCertForMPAA.Enabled = False
            Me.chkUseCertForMPAA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUseCertForMPAA.Location = New System.Drawing.Point(13, 124)
            Me.chkUseCertForMPAA.Name = "chkUseCertForMPAA"
            Me.chkUseCertForMPAA.Size = New System.Drawing.Size(162, 17)
            Me.chkUseCertForMPAA.TabIndex = 6
            Me.chkUseCertForMPAA.Text = "Use Certification for MPAA"
            Me.chkUseCertForMPAA.UseVisualStyleBackColor = True
            '
            'chkFullCast
            '
            Me.chkFullCast.AutoSize = True
            Me.chkFullCast.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFullCast.Location = New System.Drawing.Point(6, 19)
            Me.chkFullCast.Name = "chkFullCast"
            Me.chkFullCast.Size = New System.Drawing.Size(107, 17)
            Me.chkFullCast.TabIndex = 0
            Me.chkFullCast.Text = "Scrape Full Cast"
            Me.chkFullCast.UseVisualStyleBackColor = True
            '
            'chkFullCrew
            '
            Me.chkFullCrew.AutoSize = True
            Me.chkFullCrew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFullCrew.Location = New System.Drawing.Point(6, 61)
            Me.chkFullCrew.Name = "chkFullCrew"
            Me.chkFullCrew.Size = New System.Drawing.Size(111, 17)
            Me.chkFullCrew.TabIndex = 2
            Me.chkFullCrew.Text = "Scrape Full Crew"
            Me.chkFullCrew.UseVisualStyleBackColor = True
            '
            'cbCert
            '
            Me.cbCert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCert.Enabled = False
            Me.cbCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbCert.FormattingEnabled = True
            Me.cbCert.Items.AddRange(New Object() {"Argentina", "Australia", "Belgium", "Brazil", "Canada", "Finland", "France", "Germany", "Hong Kong", "Iceland", "Ireland", "Netherlands", "New Zealand", "Peru", "Portugal", "Singapore", "South Korea", "Spain", "Sweden", "Switzerland", "UK", "USA"})
            Me.cbCert.Location = New System.Drawing.Point(175, 102)
            Me.cbCert.Name = "cbCert"
            Me.cbCert.Size = New System.Drawing.Size(108, 21)
            Me.cbCert.Sorted = True
            Me.cbCert.TabIndex = 5
            '
            'chkCert
            '
            Me.chkCert.AutoSize = True
            Me.chkCert.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCert.Location = New System.Drawing.Point(6, 103)
            Me.chkCert.Name = "chkCert"
            Me.chkCert.Size = New System.Drawing.Size(168, 17)
            Me.chkCert.TabIndex = 4
            Me.chkCert.Text = "Use Certification Language:"
            Me.chkCert.UseVisualStyleBackColor = True
            '
            'gbMetaData
            '
            Me.gbMetaData.Controls.Add(Me.gbDefaultsByFileType)
            Me.gbMetaData.Controls.Add(Me.chkIFOScan)
            Me.gbMetaData.Controls.Add(Me.cbLanguages)
            Me.gbMetaData.Controls.Add(Me.lblDisplayOverlay)
            Me.gbMetaData.Controls.Add(Me.gbRTFormat)
            Me.gbMetaData.Controls.Add(Me.chkScanMediaInfo)
            Me.gbMetaData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMetaData.Location = New System.Drawing.Point(159, 6)
            Me.gbMetaData.Name = "gbMetaData"
            Me.gbMetaData.Size = New System.Drawing.Size(443, 176)
            Me.gbMetaData.TabIndex = 70
            Me.gbMetaData.TabStop = False
            Me.gbMetaData.Text = "Meta Data"
            '
            'gbDefaultsByFileType
            '
            Me.gbDefaultsByFileType.Controls.Add(Me.lstMetaData)
            Me.gbDefaultsByFileType.Controls.Add(Me.txtDefFIExt)
            Me.gbDefaultsByFileType.Controls.Add(Me.lblFileType)
            Me.gbDefaultsByFileType.Controls.Add(Me.btnRemoveMetaDataFT)
            Me.gbDefaultsByFileType.Controls.Add(Me.btnEditMetaDataFT)
            Me.gbDefaultsByFileType.Controls.Add(Me.btnNewMetaDataFT)
            Me.gbDefaultsByFileType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbDefaultsByFileType.Location = New System.Drawing.Point(252, 11)
            Me.gbDefaultsByFileType.Name = "gbDefaultsByFileType"
            Me.gbDefaultsByFileType.Size = New System.Drawing.Size(183, 144)
            Me.gbDefaultsByFileType.TabIndex = 8
            Me.gbDefaultsByFileType.TabStop = False
            Me.gbDefaultsByFileType.Text = "Defaults by File Type"
            '
            'lstMetaData
            '
            Me.lstMetaData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstMetaData.FormattingEnabled = True
            Me.lstMetaData.Location = New System.Drawing.Point(9, 15)
            Me.lstMetaData.Name = "lstMetaData"
            Me.lstMetaData.Size = New System.Drawing.Size(165, 95)
            Me.lstMetaData.TabIndex = 34
            '
            'txtDefFIExt
            '
            Me.txtDefFIExt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDefFIExt.Location = New System.Drawing.Point(72, 115)
            Me.txtDefFIExt.Name = "txtDefFIExt"
            Me.txtDefFIExt.Size = New System.Drawing.Size(35, 22)
            Me.txtDefFIExt.TabIndex = 33
            Me.txtDefFIExt.Tag = "IGNORE"
            '
            'lblFileType
            '
            Me.lblFileType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileType.Location = New System.Drawing.Point(7, 118)
            Me.lblFileType.Name = "lblFileType"
            Me.lblFileType.Size = New System.Drawing.Size(63, 19)
            Me.lblFileType.TabIndex = 32
            Me.lblFileType.Text = "File Type:"
            Me.lblFileType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveMetaDataFT
            '
            Me.btnRemoveMetaDataFT.Enabled = False
            Me.btnRemoveMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveMetaDataFT.Location = New System.Drawing.Point(152, 114)
            Me.btnRemoveMetaDataFT.Name = "btnRemoveMetaDataFT"
            Me.btnRemoveMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveMetaDataFT.TabIndex = 31
            Me.btnRemoveMetaDataFT.UseVisualStyleBackColor = True
            '
            'btnEditMetaDataFT
            '
            Me.btnEditMetaDataFT.Enabled = False
            Me.btnEditMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditMetaDataFT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditMetaDataFT.Location = New System.Drawing.Point(129, 114)
            Me.btnEditMetaDataFT.Name = "btnEditMetaDataFT"
            Me.btnEditMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnEditMetaDataFT.TabIndex = 30
            Me.btnEditMetaDataFT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditMetaDataFT.UseVisualStyleBackColor = True
            '
            'btnNewMetaDataFT
            '
            Me.btnNewMetaDataFT.Enabled = False
            Me.btnNewMetaDataFT.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnNewMetaDataFT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNewMetaDataFT.Location = New System.Drawing.Point(107, 114)
            Me.btnNewMetaDataFT.Name = "btnNewMetaDataFT"
            Me.btnNewMetaDataFT.Size = New System.Drawing.Size(23, 23)
            Me.btnNewMetaDataFT.TabIndex = 29
            Me.btnNewMetaDataFT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNewMetaDataFT.UseVisualStyleBackColor = True
            '
            'chkIFOScan
            '
            Me.chkIFOScan.AutoSize = True
            Me.chkIFOScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkIFOScan.Location = New System.Drawing.Point(5, 33)
            Me.chkIFOScan.Name = "chkIFOScan"
            Me.chkIFOScan.Size = New System.Drawing.Size(123, 17)
            Me.chkIFOScan.TabIndex = 18
            Me.chkIFOScan.Text = "Enable IFO Parsing"
            Me.chkIFOScan.UseVisualStyleBackColor = True
            '
            'cbLanguages
            '
            Me.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLanguages.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbLanguages.FormattingEnabled = True
            Me.cbLanguages.Location = New System.Drawing.Point(38, 147)
            Me.cbLanguages.Name = "cbLanguages"
            Me.cbLanguages.Size = New System.Drawing.Size(174, 21)
            Me.cbLanguages.Sorted = True
            Me.cbLanguages.TabIndex = 17
            '
            'lblDisplayOverlay
            '
            Me.lblDisplayOverlay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisplayOverlay.Location = New System.Drawing.Point(2, 117)
            Me.lblDisplayOverlay.Name = "lblDisplayOverlay"
            Me.lblDisplayOverlay.Size = New System.Drawing.Size(245, 29)
            Me.lblDisplayOverlay.TabIndex = 16
            Me.lblDisplayOverlay.Text = "Display Overlay if Video Contains an Audio Stream With the Following Language:"
            Me.lblDisplayOverlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'gbRTFormat
            '
            Me.gbRTFormat.Controls.Add(Me.lblDurationFormat)
            Me.gbRTFormat.Controls.Add(Me.txtRuntimeFormat)
            Me.gbRTFormat.Controls.Add(Me.chkUseMIDuration)
            Me.gbRTFormat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbRTFormat.Location = New System.Drawing.Point(5, 51)
            Me.gbRTFormat.Name = "gbRTFormat"
            Me.gbRTFormat.Size = New System.Drawing.Size(244, 63)
            Me.gbRTFormat.TabIndex = 9
            Me.gbRTFormat.TabStop = False
            Me.gbRTFormat.Text = "Duration Format"
            '
            'lblDurationFormat
            '
            Me.lblDurationFormat.Font = New System.Drawing.Font("Segoe UI", 7.0!)
            Me.lblDurationFormat.Location = New System.Drawing.Point(168, 9)
            Me.lblDurationFormat.Name = "lblDurationFormat"
            Me.lblDurationFormat.Size = New System.Drawing.Size(70, 50)
            Me.lblDurationFormat.TabIndex = 23
            Me.lblDurationFormat.Text = "<h>=Hours" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<m>=Minutes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<s>=Seconds"
            Me.lblDurationFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtRuntimeFormat
            '
            Me.txtRuntimeFormat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRuntimeFormat.Location = New System.Drawing.Point(5, 34)
            Me.txtRuntimeFormat.Name = "txtRuntimeFormat"
            Me.txtRuntimeFormat.Size = New System.Drawing.Size(145, 22)
            Me.txtRuntimeFormat.TabIndex = 22
            '
            'chkUseMIDuration
            '
            Me.chkUseMIDuration.AutoSize = True
            Me.chkUseMIDuration.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUseMIDuration.Location = New System.Drawing.Point(5, 15)
            Me.chkUseMIDuration.Name = "chkUseMIDuration"
            Me.chkUseMIDuration.Size = New System.Drawing.Size(158, 17)
            Me.chkUseMIDuration.TabIndex = 8
            Me.chkUseMIDuration.Text = "Use Duration for Runtime"
            Me.chkUseMIDuration.UseVisualStyleBackColor = True
            '
            'chkScanMediaInfo
            '
            Me.chkScanMediaInfo.AutoSize = True
            Me.chkScanMediaInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScanMediaInfo.Location = New System.Drawing.Point(5, 16)
            Me.chkScanMediaInfo.Name = "chkScanMediaInfo"
            Me.chkScanMediaInfo.Size = New System.Drawing.Size(106, 17)
            Me.chkScanMediaInfo.TabIndex = 7
            Me.chkScanMediaInfo.Text = "Scan Meta Data"
            Me.chkScanMediaInfo.UseVisualStyleBackColor = True
            '
            'Scraper
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbGlobalLocks)
            Me.Controls.Add(Me.gbOptions)
            Me.Controls.Add(Me.gbMiscellaneous)
            Me.Controls.Add(Me.gbMetaData)
            Me.Name = "Scraper"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Data
            Me.PanelOrder = 300
            Me.PanelText = "Scrapers - Data"
            Me.PanelType = "Movies"
            Me.gbGlobalLocks.ResumeLayout(False)
            Me.gbOptions.ResumeLayout(False)
            Me.gbOptions.PerformLayout()
            Me.gbMiscellaneous.ResumeLayout(False)
            Me.gbMiscellaneous.PerformLayout()
            Me.gbMetaData.ResumeLayout(False)
            Me.gbMetaData.PerformLayout()
            Me.gbDefaultsByFileType.ResumeLayout(False)
            Me.gbDefaultsByFileType.PerformLayout()
            Me.gbRTFormat.ResumeLayout(False)
            Me.gbRTFormat.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbGlobalLocks As System.Windows.Forms.GroupBox
        Friend WithEvents chkLockOutline As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockGenre As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockRealStudio As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockTagline As System.Windows.Forms.CheckBox
        Friend WithEvents chkLockTitle As System.Windows.Forms.CheckBox
        Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
        Friend WithEvents chkCertification As System.Windows.Forms.CheckBox
        Friend WithEvents chkTop250 As System.Windows.Forms.CheckBox
        Friend WithEvents chkCountry As System.Windows.Forms.CheckBox
        Friend WithEvents txtGenreLimit As IntegerTextbox
        Friend WithEvents lblGenreLimit As System.Windows.Forms.Label
        Friend WithEvents txtActorLimit As IntegerTextbox
        Friend WithEvents lblCastLimit As System.Windows.Forms.Label
        Friend WithEvents chkCrew As System.Windows.Forms.CheckBox
        Friend WithEvents chkMusicBy As System.Windows.Forms.CheckBox
        Friend WithEvents chkProducers As System.Windows.Forms.CheckBox
        Friend WithEvents chkWriters As System.Windows.Forms.CheckBox
        Friend WithEvents chkStudio As System.Windows.Forms.CheckBox
        Friend WithEvents chkRuntime As System.Windows.Forms.CheckBox
        Friend WithEvents chkPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkOutline As System.Windows.Forms.CheckBox
        Friend WithEvents chkGenre As System.Windows.Forms.CheckBox
        Friend WithEvents chkDirector As System.Windows.Forms.CheckBox
        Friend WithEvents chkTagline As System.Windows.Forms.CheckBox
        Friend WithEvents chkCast As System.Windows.Forms.CheckBox
        Friend WithEvents chkVotes As System.Windows.Forms.CheckBox
        Friend WithEvents chkTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkRating As System.Windows.Forms.CheckBox
        Friend WithEvents chkRelease As System.Windows.Forms.CheckBox
        Friend WithEvents chkMPAA As System.Windows.Forms.CheckBox
        Friend WithEvents chkYear As System.Windows.Forms.CheckBox
        Friend WithEvents chkTitle As System.Windows.Forms.CheckBox
        Friend WithEvents gbMiscellaneous As System.Windows.Forms.GroupBox
        Friend WithEvents chkOnlyValueForCert As System.Windows.Forms.CheckBox
        Friend WithEvents cbForce As System.Windows.Forms.ComboBox
        Friend WithEvents chkForceTitle As System.Windows.Forms.CheckBox
        Friend WithEvents chkOutlineForPlot As System.Windows.Forms.CheckBox
        Friend WithEvents chkCastWithImg As System.Windows.Forms.CheckBox
        Friend WithEvents chkUseCertForMPAA As System.Windows.Forms.CheckBox
        Friend WithEvents chkFullCast As System.Windows.Forms.CheckBox
        Friend WithEvents chkFullCrew As System.Windows.Forms.CheckBox
        Friend WithEvents cbCert As System.Windows.Forms.ComboBox
        Friend WithEvents chkCert As System.Windows.Forms.CheckBox
        Friend WithEvents gbMetaData As System.Windows.Forms.GroupBox
        Friend WithEvents gbDefaultsByFileType As System.Windows.Forms.GroupBox
        Friend WithEvents lstMetaData As System.Windows.Forms.ListBox
        Friend WithEvents txtDefFIExt As System.Windows.Forms.TextBox
        Friend WithEvents lblFileType As System.Windows.Forms.Label
        Friend WithEvents btnRemoveMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents btnEditMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents btnNewMetaDataFT As System.Windows.Forms.Button
        Friend WithEvents chkIFOScan As System.Windows.Forms.CheckBox
        Friend WithEvents cbLanguages As System.Windows.Forms.ComboBox
        Friend WithEvents lblDisplayOverlay As System.Windows.Forms.Label
        Friend WithEvents gbRTFormat As System.Windows.Forms.GroupBox
        Friend WithEvents lblDurationFormat As System.Windows.Forms.Label
        Friend WithEvents txtRuntimeFormat As System.Windows.Forms.TextBox
        Friend WithEvents chkUseMIDuration As System.Windows.Forms.CheckBox
        Friend WithEvents chkScanMediaInfo As System.Windows.Forms.CheckBox

    End Class
End Namespace