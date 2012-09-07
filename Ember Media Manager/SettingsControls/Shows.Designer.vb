Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Shows
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
            Me.gbTVListOptions = New System.Windows.Forms.GroupBox()
            Me.chkDisplayMissingEpisodes = New System.Windows.Forms.CheckBox()
            Me.gbEpisodeListOptions = New System.Windows.Forms.GroupBox()
            Me.chkEpisodeNfoCol = New System.Windows.Forms.CheckBox()
            Me.chkEpisodeFanartCol = New System.Windows.Forms.CheckBox()
            Me.chkEpisodePosterCol = New System.Windows.Forms.CheckBox()
            Me.gbSeasonListOptions = New System.Windows.Forms.GroupBox()
            Me.chkSeasonFanartCol = New System.Windows.Forms.CheckBox()
            Me.chkSeasonPosterCol = New System.Windows.Forms.CheckBox()
            Me.gbShowListOptions = New System.Windows.Forms.GroupBox()
            Me.chkShowNfoCol = New System.Windows.Forms.CheckBox()
            Me.chkShowFanartCol = New System.Windows.Forms.CheckBox()
            Me.chkShowPosterCol = New System.Windows.Forms.CheckBox()
            Me.gbTVMisc = New System.Windows.Forms.GroupBox()
            Me.chkMarkNewShows = New System.Windows.Forms.CheckBox()
            Me.chkMarkNewEpisodes = New System.Windows.Forms.CheckBox()
            Me.chkDisplayAllSeason = New System.Windows.Forms.CheckBox()
            Me.lblRatingRegion = New System.Windows.Forms.Label()
            Me.cbRatingRegion = New System.Windows.Forms.ComboBox()
            Me.gbEpFilter = New System.Windows.Forms.GroupBox()
            Me.btnResetEpFilter = New System.Windows.Forms.Button()
            Me.chkNoFilterEpisode = New System.Windows.Forms.CheckBox()
            Me.btnEpFilterDown = New System.Windows.Forms.Button()
            Me.btnEpFilterUp = New System.Windows.Forms.Button()
            Me.chkEpProperCase = New System.Windows.Forms.CheckBox()
            Me.btnRemoveEpFilter = New System.Windows.Forms.Button()
            Me.btnAddEpFilter = New System.Windows.Forms.Button()
            Me.txtEpFilter = New System.Windows.Forms.TextBox()
            Me.lstEpFilters = New System.Windows.Forms.ListBox()
            Me.gbShowFilter = New System.Windows.Forms.GroupBox()
            Me.btnResetShowFilters = New System.Windows.Forms.Button()
            Me.btnShowFilterDown = New System.Windows.Forms.Button()
            Me.btnShowFilterUp = New System.Windows.Forms.Button()
            Me.chkShowProperCase = New System.Windows.Forms.CheckBox()
            Me.btnRemoveShowFilter = New System.Windows.Forms.Button()
            Me.btnAddShowFilter = New System.Windows.Forms.Button()
            Me.txtShowFilter = New System.Windows.Forms.TextBox()
            Me.lstShowFilters = New System.Windows.Forms.ListBox()
            Me.gbTVListOptions.SuspendLayout()
            Me.gbEpisodeListOptions.SuspendLayout()
            Me.gbSeasonListOptions.SuspendLayout()
            Me.gbShowListOptions.SuspendLayout()
            Me.gbTVMisc.SuspendLayout()
            Me.gbEpFilter.SuspendLayout()
            Me.gbShowFilter.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbTVListOptions
            '
            Me.gbTVListOptions.Controls.Add(Me.chkDisplayMissingEpisodes)
            Me.gbTVListOptions.Controls.Add(Me.gbEpisodeListOptions)
            Me.gbTVListOptions.Controls.Add(Me.gbSeasonListOptions)
            Me.gbTVListOptions.Controls.Add(Me.gbShowListOptions)
            Me.gbTVListOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTVListOptions.Location = New System.Drawing.Point(6, 149)
            Me.gbTVListOptions.Name = "gbTVListOptions"
            Me.gbTVListOptions.Size = New System.Drawing.Size(219, 245)
            Me.gbTVListOptions.TabIndex = 9
            Me.gbTVListOptions.TabStop = False
            Me.gbTVListOptions.Text = "Media List Options"
            '
            'chkDisplayMissingEpisodes
            '
            Me.chkDisplayMissingEpisodes.AutoSize = True
            Me.chkDisplayMissingEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDisplayMissingEpisodes.Location = New System.Drawing.Point(10, 224)
            Me.chkDisplayMissingEpisodes.Name = "chkDisplayMissingEpisodes"
            Me.chkDisplayMissingEpisodes.Size = New System.Drawing.Size(155, 17)
            Me.chkDisplayMissingEpisodes.TabIndex = 4
            Me.chkDisplayMissingEpisodes.Text = "Display Missing Episodes"
            Me.chkDisplayMissingEpisodes.UseVisualStyleBackColor = True
            '
            'gbEpisodeListOptions
            '
            Me.gbEpisodeListOptions.Controls.Add(Me.chkEpisodeNfoCol)
            Me.gbEpisodeListOptions.Controls.Add(Me.chkEpisodeFanartCol)
            Me.gbEpisodeListOptions.Controls.Add(Me.chkEpisodePosterCol)
            Me.gbEpisodeListOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbEpisodeListOptions.Location = New System.Drawing.Point(10, 143)
            Me.gbEpisodeListOptions.Name = "gbEpisodeListOptions"
            Me.gbEpisodeListOptions.Size = New System.Drawing.Size(199, 68)
            Me.gbEpisodeListOptions.TabIndex = 7
            Me.gbEpisodeListOptions.TabStop = False
            Me.gbEpisodeListOptions.Text = "Episodes"
            '
            'chkEpisodeNfoCol
            '
            Me.chkEpisodeNfoCol.AutoSize = True
            Me.chkEpisodeNfoCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeNfoCol.Location = New System.Drawing.Point(7, 48)
            Me.chkEpisodeNfoCol.Name = "chkEpisodeNfoCol"
            Me.chkEpisodeNfoCol.Size = New System.Drawing.Size(117, 17)
            Me.chkEpisodeNfoCol.TabIndex = 5
            Me.chkEpisodeNfoCol.Text = "Hide Info Column"
            Me.chkEpisodeNfoCol.UseVisualStyleBackColor = True
            '
            'chkEpisodeFanartCol
            '
            Me.chkEpisodeFanartCol.AutoSize = True
            Me.chkEpisodeFanartCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodeFanartCol.Location = New System.Drawing.Point(7, 32)
            Me.chkEpisodeFanartCol.Name = "chkEpisodeFanartCol"
            Me.chkEpisodeFanartCol.Size = New System.Drawing.Size(129, 17)
            Me.chkEpisodeFanartCol.TabIndex = 4
            Me.chkEpisodeFanartCol.Text = "Hide Fanart Column"
            Me.chkEpisodeFanartCol.UseVisualStyleBackColor = True
            '
            'chkEpisodePosterCol
            '
            Me.chkEpisodePosterCol.AutoSize = True
            Me.chkEpisodePosterCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpisodePosterCol.Location = New System.Drawing.Point(7, 16)
            Me.chkEpisodePosterCol.Name = "chkEpisodePosterCol"
            Me.chkEpisodePosterCol.Size = New System.Drawing.Size(128, 17)
            Me.chkEpisodePosterCol.TabIndex = 3
            Me.chkEpisodePosterCol.Text = "Hide Poster Column"
            Me.chkEpisodePosterCol.UseVisualStyleBackColor = True
            '
            'gbSeasonListOptions
            '
            Me.gbSeasonListOptions.Controls.Add(Me.chkSeasonFanartCol)
            Me.gbSeasonListOptions.Controls.Add(Me.chkSeasonPosterCol)
            Me.gbSeasonListOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbSeasonListOptions.Location = New System.Drawing.Point(10, 87)
            Me.gbSeasonListOptions.Name = "gbSeasonListOptions"
            Me.gbSeasonListOptions.Size = New System.Drawing.Size(199, 52)
            Me.gbSeasonListOptions.TabIndex = 7
            Me.gbSeasonListOptions.TabStop = False
            Me.gbSeasonListOptions.Text = "Seasons"
            '
            'chkSeasonFanartCol
            '
            Me.chkSeasonFanartCol.AutoSize = True
            Me.chkSeasonFanartCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonFanartCol.Location = New System.Drawing.Point(7, 32)
            Me.chkSeasonFanartCol.Name = "chkSeasonFanartCol"
            Me.chkSeasonFanartCol.Size = New System.Drawing.Size(129, 17)
            Me.chkSeasonFanartCol.TabIndex = 4
            Me.chkSeasonFanartCol.Text = "Hide Fanart Column"
            Me.chkSeasonFanartCol.UseVisualStyleBackColor = True
            '
            'chkSeasonPosterCol
            '
            Me.chkSeasonPosterCol.AutoSize = True
            Me.chkSeasonPosterCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSeasonPosterCol.Location = New System.Drawing.Point(7, 16)
            Me.chkSeasonPosterCol.Name = "chkSeasonPosterCol"
            Me.chkSeasonPosterCol.Size = New System.Drawing.Size(128, 17)
            Me.chkSeasonPosterCol.TabIndex = 3
            Me.chkSeasonPosterCol.Text = "Hide Poster Column"
            Me.chkSeasonPosterCol.UseVisualStyleBackColor = True
            '
            'gbShowListOptions
            '
            Me.gbShowListOptions.Controls.Add(Me.chkShowNfoCol)
            Me.gbShowListOptions.Controls.Add(Me.chkShowFanartCol)
            Me.gbShowListOptions.Controls.Add(Me.chkShowPosterCol)
            Me.gbShowListOptions.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbShowListOptions.Location = New System.Drawing.Point(9, 16)
            Me.gbShowListOptions.Name = "gbShowListOptions"
            Me.gbShowListOptions.Size = New System.Drawing.Size(199, 68)
            Me.gbShowListOptions.TabIndex = 6
            Me.gbShowListOptions.TabStop = False
            Me.gbShowListOptions.Text = "Shows"
            '
            'chkShowNfoCol
            '
            Me.chkShowNfoCol.AutoSize = True
            Me.chkShowNfoCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowNfoCol.Location = New System.Drawing.Point(7, 48)
            Me.chkShowNfoCol.Name = "chkShowNfoCol"
            Me.chkShowNfoCol.Size = New System.Drawing.Size(117, 17)
            Me.chkShowNfoCol.TabIndex = 5
            Me.chkShowNfoCol.Text = "Hide Info Column"
            Me.chkShowNfoCol.UseVisualStyleBackColor = True
            '
            'chkShowFanartCol
            '
            Me.chkShowFanartCol.AutoSize = True
            Me.chkShowFanartCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowFanartCol.Location = New System.Drawing.Point(7, 32)
            Me.chkShowFanartCol.Name = "chkShowFanartCol"
            Me.chkShowFanartCol.Size = New System.Drawing.Size(129, 17)
            Me.chkShowFanartCol.TabIndex = 4
            Me.chkShowFanartCol.Text = "Hide Fanart Column"
            Me.chkShowFanartCol.UseVisualStyleBackColor = True
            '
            'chkShowPosterCol
            '
            Me.chkShowPosterCol.AutoSize = True
            Me.chkShowPosterCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowPosterCol.Location = New System.Drawing.Point(7, 16)
            Me.chkShowPosterCol.Name = "chkShowPosterCol"
            Me.chkShowPosterCol.Size = New System.Drawing.Size(128, 17)
            Me.chkShowPosterCol.TabIndex = 3
            Me.chkShowPosterCol.Text = "Hide Poster Column"
            Me.chkShowPosterCol.UseVisualStyleBackColor = True
            '
            'gbTVMisc
            '
            Me.gbTVMisc.Controls.Add(Me.chkMarkNewShows)
            Me.gbTVMisc.Controls.Add(Me.chkMarkNewEpisodes)
            Me.gbTVMisc.Controls.Add(Me.chkDisplayAllSeason)
            Me.gbTVMisc.Controls.Add(Me.lblRatingRegion)
            Me.gbTVMisc.Controls.Add(Me.cbRatingRegion)
            Me.gbTVMisc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTVMisc.Location = New System.Drawing.Point(6, 6)
            Me.gbTVMisc.Name = "gbTVMisc"
            Me.gbTVMisc.Size = New System.Drawing.Size(219, 142)
            Me.gbTVMisc.TabIndex = 8
            Me.gbTVMisc.TabStop = False
            Me.gbTVMisc.Text = "Miscellaneous"
            '
            'chkMarkNewShows
            '
            Me.chkMarkNewShows.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMarkNewShows.Location = New System.Drawing.Point(8, 90)
            Me.chkMarkNewShows.Name = "chkMarkNewShows"
            Me.chkMarkNewShows.Size = New System.Drawing.Size(204, 17)
            Me.chkMarkNewShows.TabIndex = 6
            Me.chkMarkNewShows.Text = "Mark New Shows"
            Me.chkMarkNewShows.UseVisualStyleBackColor = True
            '
            'chkMarkNewEpisodes
            '
            Me.chkMarkNewEpisodes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMarkNewEpisodes.Location = New System.Drawing.Point(8, 113)
            Me.chkMarkNewEpisodes.Name = "chkMarkNewEpisodes"
            Me.chkMarkNewEpisodes.Size = New System.Drawing.Size(204, 17)
            Me.chkMarkNewEpisodes.TabIndex = 5
            Me.chkMarkNewEpisodes.Text = "Mark New Episodes"
            Me.chkMarkNewEpisodes.UseVisualStyleBackColor = True
            '
            'chkDisplayAllSeason
            '
            Me.chkDisplayAllSeason.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDisplayAllSeason.Location = New System.Drawing.Point(8, 67)
            Me.chkDisplayAllSeason.Name = "chkDisplayAllSeason"
            Me.chkDisplayAllSeason.Size = New System.Drawing.Size(204, 17)
            Me.chkDisplayAllSeason.TabIndex = 4
            Me.chkDisplayAllSeason.Text = "Display All Season Poster"
            Me.chkDisplayAllSeason.UseVisualStyleBackColor = True
            '
            'lblRatingRegion
            '
            Me.lblRatingRegion.AutoSize = True
            Me.lblRatingRegion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRatingRegion.Location = New System.Drawing.Point(8, 21)
            Me.lblRatingRegion.Name = "lblRatingRegion"
            Me.lblRatingRegion.Size = New System.Drawing.Size(99, 13)
            Me.lblRatingRegion.TabIndex = 1
            Me.lblRatingRegion.Text = "TV Rating Region:"
            '
            'cbRatingRegion
            '
            Me.cbRatingRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbRatingRegion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.cbRatingRegion.FormattingEnabled = True
            Me.cbRatingRegion.Location = New System.Drawing.Point(8, 36)
            Me.cbRatingRegion.Name = "cbRatingRegion"
            Me.cbRatingRegion.Size = New System.Drawing.Size(163, 21)
            Me.cbRatingRegion.TabIndex = 0
            '
            'gbEpFilter
            '
            Me.gbEpFilter.Controls.Add(Me.btnResetEpFilter)
            Me.gbEpFilter.Controls.Add(Me.chkNoFilterEpisode)
            Me.gbEpFilter.Controls.Add(Me.btnEpFilterDown)
            Me.gbEpFilter.Controls.Add(Me.btnEpFilterUp)
            Me.gbEpFilter.Controls.Add(Me.chkEpProperCase)
            Me.gbEpFilter.Controls.Add(Me.btnRemoveEpFilter)
            Me.gbEpFilter.Controls.Add(Me.btnAddEpFilter)
            Me.gbEpFilter.Controls.Add(Me.txtEpFilter)
            Me.gbEpFilter.Controls.Add(Me.lstEpFilters)
            Me.gbEpFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbEpFilter.Location = New System.Drawing.Point(229, 184)
            Me.gbEpFilter.Name = "gbEpFilter"
            Me.gbEpFilter.Size = New System.Drawing.Size(382, 205)
            Me.gbEpFilter.TabIndex = 7
            Me.gbEpFilter.TabStop = False
            Me.gbEpFilter.Text = "Episode Folder/File Name Filters"
            '
            'btnResetEpFilter
            '
            Me.btnResetEpFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnResetEpFilter.Location = New System.Drawing.Point(354, 38)
            Me.btnResetEpFilter.Name = "btnResetEpFilter"
            Me.btnResetEpFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnResetEpFilter.TabIndex = 8
            Me.btnResetEpFilter.Tag = "forceupdate"
            Me.btnResetEpFilter.UseVisualStyleBackColor = True
            '
            'chkNoFilterEpisode
            '
            Me.chkNoFilterEpisode.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoFilterEpisode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.chkNoFilterEpisode.Location = New System.Drawing.Point(6, 15)
            Me.chkNoFilterEpisode.Name = "chkNoFilterEpisode"
            Me.chkNoFilterEpisode.Size = New System.Drawing.Size(371, 21)
            Me.chkNoFilterEpisode.TabIndex = 7
            Me.chkNoFilterEpisode.Text = "Build Episode Title Instead of Filtering"
            Me.chkNoFilterEpisode.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkNoFilterEpisode.UseVisualStyleBackColor = True
            '
            'btnEpFilterDown
            '
            Me.btnEpFilterDown.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Down
            Me.btnEpFilterDown.Location = New System.Drawing.Point(320, 176)
            Me.btnEpFilterDown.Name = "btnEpFilterDown"
            Me.btnEpFilterDown.Size = New System.Drawing.Size(23, 23)
            Me.btnEpFilterDown.TabIndex = 5
            Me.btnEpFilterDown.Tag = "forceupdate"
            Me.btnEpFilterDown.UseVisualStyleBackColor = True
            '
            'btnEpFilterUp
            '
            Me.btnEpFilterUp.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Up
            Me.btnEpFilterUp.Location = New System.Drawing.Point(296, 176)
            Me.btnEpFilterUp.Name = "btnEpFilterUp"
            Me.btnEpFilterUp.Size = New System.Drawing.Size(23, 23)
            Me.btnEpFilterUp.TabIndex = 4
            Me.btnEpFilterUp.Tag = "forceupdate"
            Me.btnEpFilterUp.UseVisualStyleBackColor = True
            '
            'chkEpProperCase
            '
            Me.chkEpProperCase.AutoSize = True
            Me.chkEpProperCase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEpProperCase.Location = New System.Drawing.Point(6, 47)
            Me.chkEpProperCase.Name = "chkEpProperCase"
            Me.chkEpProperCase.Size = New System.Drawing.Size(181, 17)
            Me.chkEpProperCase.TabIndex = 0
            Me.chkEpProperCase.Tag = "forceupdate"
            Me.chkEpProperCase.Text = "Convert Names to Proper Case"
            Me.chkEpProperCase.UseVisualStyleBackColor = True
            '
            'btnRemoveEpFilter
            '
            Me.btnRemoveEpFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveEpFilter.Location = New System.Drawing.Point(354, 176)
            Me.btnRemoveEpFilter.Name = "btnRemoveEpFilter"
            Me.btnRemoveEpFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveEpFilter.TabIndex = 6
            Me.btnRemoveEpFilter.Tag = "forceupdate"
            Me.btnRemoveEpFilter.UseVisualStyleBackColor = True
            '
            'btnAddEpFilter
            '
            Me.btnAddEpFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddEpFilter.Location = New System.Drawing.Point(260, 176)
            Me.btnAddEpFilter.Name = "btnAddEpFilter"
            Me.btnAddEpFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnAddEpFilter.TabIndex = 3
            Me.btnAddEpFilter.Tag = "forceupdate"
            Me.btnAddEpFilter.UseVisualStyleBackColor = True
            '
            'txtEpFilter
            '
            Me.txtEpFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEpFilter.Location = New System.Drawing.Point(6, 177)
            Me.txtEpFilter.Name = "txtEpFilter"
            Me.txtEpFilter.Size = New System.Drawing.Size(252, 22)
            Me.txtEpFilter.TabIndex = 2
            Me.txtEpFilter.Tag = "IGNORE"
            '
            'lstEpFilters
            '
            Me.lstEpFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstEpFilters.FormattingEnabled = True
            Me.lstEpFilters.Location = New System.Drawing.Point(6, 64)
            Me.lstEpFilters.Name = "lstEpFilters"
            Me.lstEpFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstEpFilters.Size = New System.Drawing.Size(371, 95)
            Me.lstEpFilters.TabIndex = 1
            '
            'gbShowFilter
            '
            Me.gbShowFilter.Controls.Add(Me.btnResetShowFilters)
            Me.gbShowFilter.Controls.Add(Me.btnShowFilterDown)
            Me.gbShowFilter.Controls.Add(Me.btnShowFilterUp)
            Me.gbShowFilter.Controls.Add(Me.chkShowProperCase)
            Me.gbShowFilter.Controls.Add(Me.btnRemoveShowFilter)
            Me.gbShowFilter.Controls.Add(Me.btnAddShowFilter)
            Me.gbShowFilter.Controls.Add(Me.txtShowFilter)
            Me.gbShowFilter.Controls.Add(Me.lstShowFilters)
            Me.gbShowFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbShowFilter.Location = New System.Drawing.Point(229, 6)
            Me.gbShowFilter.Name = "gbShowFilter"
            Me.gbShowFilter.Size = New System.Drawing.Size(382, 175)
            Me.gbShowFilter.TabIndex = 6
            Me.gbShowFilter.TabStop = False
            Me.gbShowFilter.Text = "Show Folder/File Name Filters"
            '
            'btnResetShowFilters
            '
            Me.btnResetShowFilters.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnResetShowFilters.Location = New System.Drawing.Point(354, 9)
            Me.btnResetShowFilters.Name = "btnResetShowFilters"
            Me.btnResetShowFilters.Size = New System.Drawing.Size(23, 23)
            Me.btnResetShowFilters.TabIndex = 7
            Me.btnResetShowFilters.Tag = "forceupdate"
            Me.btnResetShowFilters.UseVisualStyleBackColor = True
            '
            'btnShowFilterDown
            '
            Me.btnShowFilterDown.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Down
            Me.btnShowFilterDown.Location = New System.Drawing.Point(320, 146)
            Me.btnShowFilterDown.Name = "btnShowFilterDown"
            Me.btnShowFilterDown.Size = New System.Drawing.Size(23, 23)
            Me.btnShowFilterDown.TabIndex = 5
            Me.btnShowFilterDown.Tag = "forceupdate"
            Me.btnShowFilterDown.UseVisualStyleBackColor = True
            '
            'btnShowFilterUp
            '
            Me.btnShowFilterUp.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Up
            Me.btnShowFilterUp.Location = New System.Drawing.Point(296, 146)
            Me.btnShowFilterUp.Name = "btnShowFilterUp"
            Me.btnShowFilterUp.Size = New System.Drawing.Size(23, 23)
            Me.btnShowFilterUp.TabIndex = 4
            Me.btnShowFilterUp.Tag = "forceupdate"
            Me.btnShowFilterUp.UseVisualStyleBackColor = True
            '
            'chkShowProperCase
            '
            Me.chkShowProperCase.AutoSize = True
            Me.chkShowProperCase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowProperCase.Location = New System.Drawing.Point(6, 17)
            Me.chkShowProperCase.Name = "chkShowProperCase"
            Me.chkShowProperCase.Size = New System.Drawing.Size(181, 17)
            Me.chkShowProperCase.TabIndex = 0
            Me.chkShowProperCase.Tag = "forceupdate"
            Me.chkShowProperCase.Text = "Convert Names to Proper Case"
            Me.chkShowProperCase.UseVisualStyleBackColor = True
            '
            'btnRemoveShowFilter
            '
            Me.btnRemoveShowFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveShowFilter.Location = New System.Drawing.Point(354, 146)
            Me.btnRemoveShowFilter.Name = "btnRemoveShowFilter"
            Me.btnRemoveShowFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveShowFilter.TabIndex = 6
            Me.btnRemoveShowFilter.Tag = "forceupdate"
            Me.btnRemoveShowFilter.UseVisualStyleBackColor = True
            '
            'btnAddShowFilter
            '
            Me.btnAddShowFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddShowFilter.Location = New System.Drawing.Point(260, 146)
            Me.btnAddShowFilter.Name = "btnAddShowFilter"
            Me.btnAddShowFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnAddShowFilter.TabIndex = 3
            Me.btnAddShowFilter.Tag = "forceupdate"
            Me.btnAddShowFilter.UseVisualStyleBackColor = True
            '
            'txtShowFilter
            '
            Me.txtShowFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShowFilter.Location = New System.Drawing.Point(6, 147)
            Me.txtShowFilter.Name = "txtShowFilter"
            Me.txtShowFilter.Size = New System.Drawing.Size(252, 22)
            Me.txtShowFilter.TabIndex = 2
            Me.txtShowFilter.Tag = "IGNORE"
            '
            'lstShowFilters
            '
            Me.lstShowFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstShowFilters.FormattingEnabled = True
            Me.lstShowFilters.Location = New System.Drawing.Point(6, 35)
            Me.lstShowFilters.Name = "lstShowFilters"
            Me.lstShowFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstShowFilters.Size = New System.Drawing.Size(371, 95)
            Me.lstShowFilters.TabIndex = 1
            '
            'Shows
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbTVListOptions)
            Me.Controls.Add(Me.gbTVMisc)
            Me.Controls.Add(Me.gbEpFilter)
            Me.Controls.Add(Me.gbShowFilter)
            Me.Name = "Shows"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_TV
            Me.PanelOrder = 100
            Me.PanelText = "General"
            Me.PanelType = "TV Shows"
            Me.gbTVListOptions.ResumeLayout(False)
            Me.gbTVListOptions.PerformLayout()
            Me.gbEpisodeListOptions.ResumeLayout(False)
            Me.gbEpisodeListOptions.PerformLayout()
            Me.gbSeasonListOptions.ResumeLayout(False)
            Me.gbSeasonListOptions.PerformLayout()
            Me.gbShowListOptions.ResumeLayout(False)
            Me.gbShowListOptions.PerformLayout()
            Me.gbTVMisc.ResumeLayout(False)
            Me.gbTVMisc.PerformLayout()
            Me.gbEpFilter.ResumeLayout(False)
            Me.gbEpFilter.PerformLayout()
            Me.gbShowFilter.ResumeLayout(False)
            Me.gbShowFilter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbTVListOptions As System.Windows.Forms.GroupBox
        Friend WithEvents chkDisplayMissingEpisodes As System.Windows.Forms.CheckBox
        Friend WithEvents gbEpisodeListOptions As System.Windows.Forms.GroupBox
        Friend WithEvents chkEpisodeNfoCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpisodeFanartCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkEpisodePosterCol As System.Windows.Forms.CheckBox
        Friend WithEvents gbSeasonListOptions As System.Windows.Forms.GroupBox
        Friend WithEvents chkSeasonFanartCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkSeasonPosterCol As System.Windows.Forms.CheckBox
        Friend WithEvents gbShowListOptions As System.Windows.Forms.GroupBox
        Friend WithEvents chkShowNfoCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowFanartCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowPosterCol As System.Windows.Forms.CheckBox
        Friend WithEvents gbTVMisc As System.Windows.Forms.GroupBox
        Friend WithEvents chkMarkNewShows As System.Windows.Forms.CheckBox
        Friend WithEvents chkMarkNewEpisodes As System.Windows.Forms.CheckBox
        Friend WithEvents chkDisplayAllSeason As System.Windows.Forms.CheckBox
        Friend WithEvents lblRatingRegion As System.Windows.Forms.Label
        Friend WithEvents cbRatingRegion As System.Windows.Forms.ComboBox
        Friend WithEvents gbEpFilter As System.Windows.Forms.GroupBox
        Friend WithEvents btnResetEpFilter As System.Windows.Forms.Button
        Friend WithEvents chkNoFilterEpisode As System.Windows.Forms.CheckBox
        Friend WithEvents btnEpFilterDown As System.Windows.Forms.Button
        Friend WithEvents btnEpFilterUp As System.Windows.Forms.Button
        Friend WithEvents chkEpProperCase As System.Windows.Forms.CheckBox
        Friend WithEvents btnRemoveEpFilter As System.Windows.Forms.Button
        Friend WithEvents btnAddEpFilter As System.Windows.Forms.Button
        Friend WithEvents txtEpFilter As System.Windows.Forms.TextBox
        Friend WithEvents lstEpFilters As System.Windows.Forms.ListBox
        Friend WithEvents gbShowFilter As System.Windows.Forms.GroupBox
        Friend WithEvents btnResetShowFilters As System.Windows.Forms.Button
        Friend WithEvents btnShowFilterDown As System.Windows.Forms.Button
        Friend WithEvents btnShowFilterUp As System.Windows.Forms.Button
        Friend WithEvents chkShowProperCase As System.Windows.Forms.CheckBox
        Friend WithEvents btnRemoveShowFilter As System.Windows.Forms.Button
        Friend WithEvents btnAddShowFilter As System.Windows.Forms.Button
        Friend WithEvents txtShowFilter As System.Windows.Forms.TextBox
        Friend WithEvents lstShowFilters As System.Windows.Forms.ListBox

    End Class
End Namespace