Imports EmberControls

Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Movies
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
            Me.gbGenreFilter = New System.Windows.Forms.GroupBox()
            Me.lbGenre = New System.Windows.Forms.CheckedListBox()
            Me.gbFilters = New System.Windows.Forms.GroupBox()
            Me.btnResetMovieFilters = New System.Windows.Forms.Button()
            Me.btnDown = New System.Windows.Forms.Button()
            Me.btnUp = New System.Windows.Forms.Button()
            Me.chkProperCase = New System.Windows.Forms.CheckBox()
            Me.btnRemoveFilter = New System.Windows.Forms.Button()
            Me.btnAddFilter = New System.Windows.Forms.Button()
            Me.txtFilter = New System.Windows.Forms.TextBox()
            Me.lstFilters = New System.Windows.Forms.ListBox()
            Me.gbMissingItems = New System.Windows.Forms.GroupBox()
            Me.chkMissingExtra = New System.Windows.Forms.CheckBox()
            Me.chkMissingSubs = New System.Windows.Forms.CheckBox()
            Me.chkMissingTrailer = New System.Windows.Forms.CheckBox()
            Me.chkMissingNFO = New System.Windows.Forms.CheckBox()
            Me.chkMissingFanart = New System.Windows.Forms.CheckBox()
            Me.chkMissingPoster = New System.Windows.Forms.CheckBox()
            Me.gbMiscellaneous = New System.Windows.Forms.GroupBox()
            Me.chkClickScrape = New System.Windows.Forms.CheckBox()
            Me.chkAskCheckboxScrape = New System.Windows.Forms.CheckBox()
            Me.chkMarkNew = New System.Windows.Forms.CheckBox()
            Me.gbMediaList = New System.Windows.Forms.GroupBox()
            Me.txtCheckTitleTol = New EmberControls.IntegerTextbox()
            Me.lblMismatchTolerance = New System.Windows.Forms.Label()
            Me.chkCheckTitles = New System.Windows.Forms.CheckBox()
            Me.GroupBox25 = New System.Windows.Forms.GroupBox()
            Me.btnRemoveToken = New System.Windows.Forms.Button()
            Me.btnAddToken = New System.Windows.Forms.Button()
            Me.txtSortToken = New System.Windows.Forms.TextBox()
            Me.lstSortTokens = New System.Windows.Forms.ListBox()
            Me.chkDisplayYear = New System.Windows.Forms.CheckBox()
            Me.chkMovieExtraCol = New System.Windows.Forms.CheckBox()
            Me.chkMovieSubCol = New System.Windows.Forms.CheckBox()
            Me.chkMovieTrailerCol = New System.Windows.Forms.CheckBox()
            Me.chkMovieInfoCol = New System.Windows.Forms.CheckBox()
            Me.chkMovieFanartCol = New System.Windows.Forms.CheckBox()
            Me.chkMoviePosterCol = New System.Windows.Forms.CheckBox()
            Me.gbGenreFilter.SuspendLayout()
            Me.gbFilters.SuspendLayout()
            Me.gbMissingItems.SuspendLayout()
            Me.gbMiscellaneous.SuspendLayout()
            Me.gbMediaList.SuspendLayout()
            Me.GroupBox25.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbGenreFilter
            '
            Me.gbGenreFilter.Controls.Add(Me.lbGenre)
            Me.gbGenreFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbGenreFilter.Location = New System.Drawing.Point(428, 209)
            Me.gbGenreFilter.Name = "gbGenreFilter"
            Me.gbGenreFilter.Size = New System.Drawing.Size(183, 151)
            Me.gbGenreFilter.TabIndex = 12
            Me.gbGenreFilter.TabStop = False
            Me.gbGenreFilter.Text = "Genre Language Filter"
            '
            'lbGenre
            '
            Me.lbGenre.CheckOnClick = True
            Me.lbGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lbGenre.FormattingEnabled = True
            Me.lbGenre.IntegralHeight = False
            Me.lbGenre.Location = New System.Drawing.Point(10, 18)
            Me.lbGenre.Name = "lbGenre"
            Me.lbGenre.Size = New System.Drawing.Size(157, 124)
            Me.lbGenre.Sorted = True
            Me.lbGenre.TabIndex = 0
            '
            'gbFilters
            '
            Me.gbFilters.Controls.Add(Me.btnResetMovieFilters)
            Me.gbFilters.Controls.Add(Me.btnDown)
            Me.gbFilters.Controls.Add(Me.btnUp)
            Me.gbFilters.Controls.Add(Me.chkProperCase)
            Me.gbFilters.Controls.Add(Me.btnRemoveFilter)
            Me.gbFilters.Controls.Add(Me.btnAddFilter)
            Me.gbFilters.Controls.Add(Me.txtFilter)
            Me.gbFilters.Controls.Add(Me.lstFilters)
            Me.gbFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbFilters.Location = New System.Drawing.Point(229, 7)
            Me.gbFilters.Name = "gbFilters"
            Me.gbFilters.Size = New System.Drawing.Size(382, 200)
            Me.gbFilters.TabIndex = 11
            Me.gbFilters.TabStop = False
            Me.gbFilters.Text = "Folder/File Name Filters"
            '
            'btnResetMovieFilters
            '
            Me.btnResetMovieFilters.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnResetMovieFilters.Location = New System.Drawing.Point(355, 11)
            Me.btnResetMovieFilters.Name = "btnResetMovieFilters"
            Me.btnResetMovieFilters.Size = New System.Drawing.Size(23, 23)
            Me.btnResetMovieFilters.TabIndex = 8
            Me.btnResetMovieFilters.Tag = "forceupdate"
            Me.btnResetMovieFilters.UseVisualStyleBackColor = True
            '
            'btnDown
            '
            Me.btnDown.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Down
            Me.btnDown.Location = New System.Drawing.Point(313, 172)
            Me.btnDown.Name = "btnDown"
            Me.btnDown.Size = New System.Drawing.Size(23, 23)
            Me.btnDown.TabIndex = 5
            Me.btnDown.Tag = "forceupdate"
            Me.btnDown.UseVisualStyleBackColor = True
            '
            'btnUp
            '
            Me.btnUp.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Up
            Me.btnUp.Location = New System.Drawing.Point(289, 172)
            Me.btnUp.Name = "btnUp"
            Me.btnUp.Size = New System.Drawing.Size(23, 23)
            Me.btnUp.TabIndex = 4
            Me.btnUp.Tag = "forceupdate"
            Me.btnUp.UseVisualStyleBackColor = True
            '
            'chkProperCase
            '
            Me.chkProperCase.AutoSize = True
            Me.chkProperCase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkProperCase.Location = New System.Drawing.Point(6, 16)
            Me.chkProperCase.Name = "chkProperCase"
            Me.chkProperCase.Size = New System.Drawing.Size(181, 17)
            Me.chkProperCase.TabIndex = 0
            Me.chkProperCase.Tag = "forceupdate"
            Me.chkProperCase.Text = "Convert Names to Proper Case"
            Me.chkProperCase.UseVisualStyleBackColor = True
            '
            'btnRemoveFilter
            '
            Me.btnRemoveFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveFilter.Location = New System.Drawing.Point(354, 172)
            Me.btnRemoveFilter.Name = "btnRemoveFilter"
            Me.btnRemoveFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveFilter.TabIndex = 6
            Me.btnRemoveFilter.UseVisualStyleBackColor = True
            '
            'btnAddFilter
            '
            Me.btnAddFilter.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddFilter.Location = New System.Drawing.Point(247, 172)
            Me.btnAddFilter.Name = "btnAddFilter"
            Me.btnAddFilter.Size = New System.Drawing.Size(23, 23)
            Me.btnAddFilter.TabIndex = 3
            Me.btnAddFilter.Tag = "forceupdate"
            Me.btnAddFilter.UseVisualStyleBackColor = True
            '
            'txtFilter
            '
            Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFilter.Location = New System.Drawing.Point(6, 173)
            Me.txtFilter.Name = "txtFilter"
            Me.txtFilter.Size = New System.Drawing.Size(239, 22)
            Me.txtFilter.TabIndex = 2
            Me.txtFilter.Tag = "IGNORE"
            '
            'lstFilters
            '
            Me.lstFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstFilters.FormattingEnabled = True
            Me.lstFilters.Location = New System.Drawing.Point(6, 36)
            Me.lstFilters.Name = "lstFilters"
            Me.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstFilters.Size = New System.Drawing.Size(371, 121)
            Me.lstFilters.TabIndex = 1
            '
            'gbMissingItems
            '
            Me.gbMissingItems.Controls.Add(Me.chkMissingExtra)
            Me.gbMissingItems.Controls.Add(Me.chkMissingSubs)
            Me.gbMissingItems.Controls.Add(Me.chkMissingTrailer)
            Me.gbMissingItems.Controls.Add(Me.chkMissingNFO)
            Me.gbMissingItems.Controls.Add(Me.chkMissingFanart)
            Me.gbMissingItems.Controls.Add(Me.chkMissingPoster)
            Me.gbMissingItems.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMissingItems.Location = New System.Drawing.Point(229, 209)
            Me.gbMissingItems.Name = "gbMissingItems"
            Me.gbMissingItems.Size = New System.Drawing.Size(185, 123)
            Me.gbMissingItems.TabIndex = 10
            Me.gbMissingItems.TabStop = False
            Me.gbMissingItems.Text = "Missing Items Filter"
            '
            'chkMissingExtra
            '
            Me.chkMissingExtra.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingExtra.Location = New System.Drawing.Point(8, 98)
            Me.chkMissingExtra.Name = "chkMissingExtra"
            Me.chkMissingExtra.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingExtra.TabIndex = 11
            Me.chkMissingExtra.Text = "Check for Extrathumbs"
            Me.chkMissingExtra.UseVisualStyleBackColor = True
            '
            'chkMissingSubs
            '
            Me.chkMissingSubs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingSubs.Location = New System.Drawing.Point(8, 82)
            Me.chkMissingSubs.Name = "chkMissingSubs"
            Me.chkMissingSubs.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingSubs.TabIndex = 10
            Me.chkMissingSubs.Text = "Check for Subs"
            Me.chkMissingSubs.UseVisualStyleBackColor = True
            '
            'chkMissingTrailer
            '
            Me.chkMissingTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingTrailer.Location = New System.Drawing.Point(8, 66)
            Me.chkMissingTrailer.Name = "chkMissingTrailer"
            Me.chkMissingTrailer.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingTrailer.TabIndex = 9
            Me.chkMissingTrailer.Text = "Check for Trailer"
            Me.chkMissingTrailer.UseVisualStyleBackColor = True
            '
            'chkMissingNFO
            '
            Me.chkMissingNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingNFO.Location = New System.Drawing.Point(8, 50)
            Me.chkMissingNFO.Name = "chkMissingNFO"
            Me.chkMissingNFO.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingNFO.TabIndex = 8
            Me.chkMissingNFO.Text = "Check for NFO"
            Me.chkMissingNFO.UseVisualStyleBackColor = True
            '
            'chkMissingFanart
            '
            Me.chkMissingFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingFanart.Location = New System.Drawing.Point(8, 34)
            Me.chkMissingFanart.Name = "chkMissingFanart"
            Me.chkMissingFanart.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingFanart.TabIndex = 7
            Me.chkMissingFanart.Text = "Check for Fanart"
            Me.chkMissingFanart.UseVisualStyleBackColor = True
            '
            'chkMissingPoster
            '
            Me.chkMissingPoster.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMissingPoster.Location = New System.Drawing.Point(8, 18)
            Me.chkMissingPoster.Name = "chkMissingPoster"
            Me.chkMissingPoster.Size = New System.Drawing.Size(174, 17)
            Me.chkMissingPoster.TabIndex = 6
            Me.chkMissingPoster.Text = "Check for Poster"
            Me.chkMissingPoster.UseVisualStyleBackColor = True
            '
            'gbMiscellaneous
            '
            Me.gbMiscellaneous.Controls.Add(Me.chkClickScrape)
            Me.gbMiscellaneous.Controls.Add(Me.chkAskCheckboxScrape)
            Me.gbMiscellaneous.Controls.Add(Me.chkMarkNew)
            Me.gbMiscellaneous.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMiscellaneous.Location = New System.Drawing.Point(6, 7)
            Me.gbMiscellaneous.Name = "gbMiscellaneous"
            Me.gbMiscellaneous.Size = New System.Drawing.Size(219, 93)
            Me.gbMiscellaneous.TabIndex = 8
            Me.gbMiscellaneous.TabStop = False
            Me.gbMiscellaneous.Text = "Miscellaneous"
            '
            'chkClickScrape
            '
            Me.chkClickScrape.AutoSize = True
            Me.chkClickScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.chkClickScrape.Location = New System.Drawing.Point(12, 36)
            Me.chkClickScrape.Name = "chkClickScrape"
            Me.chkClickScrape.Size = New System.Drawing.Size(125, 17)
            Me.chkClickScrape.TabIndex = 65
            Me.chkClickScrape.Text = "Enable Click Scrape"
            Me.chkClickScrape.UseVisualStyleBackColor = True
            '
            'chkAskCheckboxScrape
            '
            Me.chkAskCheckboxScrape.AutoSize = True
            Me.chkAskCheckboxScrape.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.chkAskCheckboxScrape.Location = New System.Drawing.Point(25, 56)
            Me.chkAskCheckboxScrape.Name = "chkAskCheckboxScrape"
            Me.chkAskCheckboxScrape.Size = New System.Drawing.Size(127, 17)
            Me.chkAskCheckboxScrape.TabIndex = 64
            Me.chkAskCheckboxScrape.Text = "Ask On Click Scrape"
            Me.chkAskCheckboxScrape.UseVisualStyleBackColor = True
            '
            'chkMarkNew
            '
            Me.chkMarkNew.AutoSize = True
            Me.chkMarkNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMarkNew.Location = New System.Drawing.Point(12, 14)
            Me.chkMarkNew.Name = "chkMarkNew"
            Me.chkMarkNew.Size = New System.Drawing.Size(117, 17)
            Me.chkMarkNew.TabIndex = 0
            Me.chkMarkNew.Text = "Mark New Movies"
            Me.chkMarkNew.UseVisualStyleBackColor = True
            '
            'gbMediaList
            '
            Me.gbMediaList.Controls.Add(Me.txtCheckTitleTol)
            Me.gbMediaList.Controls.Add(Me.lblMismatchTolerance)
            Me.gbMediaList.Controls.Add(Me.chkCheckTitles)
            Me.gbMediaList.Controls.Add(Me.GroupBox25)
            Me.gbMediaList.Controls.Add(Me.chkDisplayYear)
            Me.gbMediaList.Controls.Add(Me.chkMovieExtraCol)
            Me.gbMediaList.Controls.Add(Me.chkMovieSubCol)
            Me.gbMediaList.Controls.Add(Me.chkMovieTrailerCol)
            Me.gbMediaList.Controls.Add(Me.chkMovieInfoCol)
            Me.gbMediaList.Controls.Add(Me.chkMovieFanartCol)
            Me.gbMediaList.Controls.Add(Me.chkMoviePosterCol)
            Me.gbMediaList.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMediaList.Location = New System.Drawing.Point(7, 106)
            Me.gbMediaList.Name = "gbMediaList"
            Me.gbMediaList.Size = New System.Drawing.Size(218, 279)
            Me.gbMediaList.TabIndex = 9
            Me.gbMediaList.TabStop = False
            Me.gbMediaList.Text = "Media List Options"
            '
            'txtCheckTitleTol
            '
            Me.txtCheckTitleTol.Enabled = False
            Me.txtCheckTitleTol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCheckTitleTol.Location = New System.Drawing.Point(142, 50)
            Me.txtCheckTitleTol.Name = "txtCheckTitleTol"
            Me.txtCheckTitleTol.Size = New System.Drawing.Size(61, 22)
            Me.txtCheckTitleTol.TabIndex = 74
            '
            'lblMismatchTolerance
            '
            Me.lblMismatchTolerance.AutoSize = True
            Me.lblMismatchTolerance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMismatchTolerance.Location = New System.Drawing.Point(27, 54)
            Me.lblMismatchTolerance.Name = "lblMismatchTolerance"
            Me.lblMismatchTolerance.Size = New System.Drawing.Size(111, 13)
            Me.lblMismatchTolerance.TabIndex = 73
            Me.lblMismatchTolerance.Text = "Mismatch Tolerance:"
            Me.lblMismatchTolerance.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'chkCheckTitles
            '
            Me.chkCheckTitles.AutoSize = True
            Me.chkCheckTitles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCheckTitles.Location = New System.Drawing.Point(8, 35)
            Me.chkCheckTitles.Name = "chkCheckTitles"
            Me.chkCheckTitles.Size = New System.Drawing.Size(178, 17)
            Me.chkCheckTitles.TabIndex = 72
            Me.chkCheckTitles.Text = "Check Title Match Confidence"
            Me.chkCheckTitles.UseVisualStyleBackColor = True
            '
            'GroupBox25
            '
            Me.GroupBox25.Controls.Add(Me.btnRemoveToken)
            Me.GroupBox25.Controls.Add(Me.btnAddToken)
            Me.GroupBox25.Controls.Add(Me.txtSortToken)
            Me.GroupBox25.Controls.Add(Me.lstSortTokens)
            Me.GroupBox25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.GroupBox25.Location = New System.Drawing.Point(9, 73)
            Me.GroupBox25.Name = "GroupBox25"
            Me.GroupBox25.Size = New System.Drawing.Size(200, 102)
            Me.GroupBox25.TabIndex = 71
            Me.GroupBox25.TabStop = False
            Me.GroupBox25.Text = "Sort Tokens to Ignore"
            '
            'btnRemoveToken
            '
            Me.btnRemoveToken.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveToken.Location = New System.Drawing.Point(168, 72)
            Me.btnRemoveToken.Name = "btnRemoveToken"
            Me.btnRemoveToken.Size = New System.Drawing.Size(23, 23)
            Me.btnRemoveToken.TabIndex = 3
            Me.btnRemoveToken.UseVisualStyleBackColor = True
            '
            'btnAddToken
            '
            Me.btnAddToken.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddToken.Location = New System.Drawing.Point(72, 72)
            Me.btnAddToken.Name = "btnAddToken"
            Me.btnAddToken.Size = New System.Drawing.Size(23, 23)
            Me.btnAddToken.TabIndex = 2
            Me.btnAddToken.Tag = "forceupdate"
            Me.btnAddToken.UseVisualStyleBackColor = True
            '
            'txtSortToken
            '
            Me.txtSortToken.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSortToken.Location = New System.Drawing.Point(10, 73)
            Me.txtSortToken.Name = "txtSortToken"
            Me.txtSortToken.Size = New System.Drawing.Size(61, 22)
            Me.txtSortToken.TabIndex = 1
            Me.txtSortToken.Tag = "IGNORE"
            '
            'lstSortTokens
            '
            Me.lstSortTokens.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lstSortTokens.FormattingEnabled = True
            Me.lstSortTokens.Location = New System.Drawing.Point(10, 15)
            Me.lstSortTokens.Name = "lstSortTokens"
            Me.lstSortTokens.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.lstSortTokens.Size = New System.Drawing.Size(180, 43)
            Me.lstSortTokens.Sorted = True
            Me.lstSortTokens.TabIndex = 0
            '
            'chkDisplayYear
            '
            Me.chkDisplayYear.AutoSize = True
            Me.chkDisplayYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDisplayYear.Location = New System.Drawing.Point(8, 19)
            Me.chkDisplayYear.Name = "chkDisplayYear"
            Me.chkDisplayYear.Size = New System.Drawing.Size(144, 17)
            Me.chkDisplayYear.TabIndex = 70
            Me.chkDisplayYear.Tag = "forceupdate"
            Me.chkDisplayYear.Text = "Display Year in List Title"
            Me.chkDisplayYear.UseVisualStyleBackColor = True
            '
            'chkMovieExtraCol
            '
            Me.chkMovieExtraCol.AutoSize = True
            Me.chkMovieExtraCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieExtraCol.Location = New System.Drawing.Point(9, 258)
            Me.chkMovieExtraCol.Name = "chkMovieExtraCol"
            Me.chkMovieExtraCol.Size = New System.Drawing.Size(155, 17)
            Me.chkMovieExtraCol.TabIndex = 5
            Me.chkMovieExtraCol.Text = "Hide Extrathumb Column"
            Me.chkMovieExtraCol.UseVisualStyleBackColor = True
            '
            'chkMovieSubCol
            '
            Me.chkMovieSubCol.AutoSize = True
            Me.chkMovieSubCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieSubCol.Location = New System.Drawing.Point(9, 242)
            Me.chkMovieSubCol.Name = "chkMovieSubCol"
            Me.chkMovieSubCol.Size = New System.Drawing.Size(116, 17)
            Me.chkMovieSubCol.TabIndex = 4
            Me.chkMovieSubCol.Text = "Hide Sub Column"
            Me.chkMovieSubCol.UseVisualStyleBackColor = True
            '
            'chkMovieTrailerCol
            '
            Me.chkMovieTrailerCol.AutoSize = True
            Me.chkMovieTrailerCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieTrailerCol.Location = New System.Drawing.Point(9, 226)
            Me.chkMovieTrailerCol.Name = "chkMovieTrailerCol"
            Me.chkMovieTrailerCol.Size = New System.Drawing.Size(127, 17)
            Me.chkMovieTrailerCol.TabIndex = 3
            Me.chkMovieTrailerCol.Text = "Hide Trailer Column"
            Me.chkMovieTrailerCol.UseVisualStyleBackColor = True
            '
            'chkMovieInfoCol
            '
            Me.chkMovieInfoCol.AutoSize = True
            Me.chkMovieInfoCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieInfoCol.Location = New System.Drawing.Point(9, 210)
            Me.chkMovieInfoCol.Name = "chkMovieInfoCol"
            Me.chkMovieInfoCol.Size = New System.Drawing.Size(117, 17)
            Me.chkMovieInfoCol.TabIndex = 2
            Me.chkMovieInfoCol.Text = "Hide Info Column"
            Me.chkMovieInfoCol.UseVisualStyleBackColor = True
            '
            'chkMovieFanartCol
            '
            Me.chkMovieFanartCol.AutoSize = True
            Me.chkMovieFanartCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieFanartCol.Location = New System.Drawing.Point(9, 194)
            Me.chkMovieFanartCol.Name = "chkMovieFanartCol"
            Me.chkMovieFanartCol.Size = New System.Drawing.Size(129, 17)
            Me.chkMovieFanartCol.TabIndex = 1
            Me.chkMovieFanartCol.Text = "Hide Fanart Column"
            Me.chkMovieFanartCol.UseVisualStyleBackColor = True
            '
            'chkMoviePosterCol
            '
            Me.chkMoviePosterCol.AutoSize = True
            Me.chkMoviePosterCol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMoviePosterCol.Location = New System.Drawing.Point(9, 178)
            Me.chkMoviePosterCol.Name = "chkMoviePosterCol"
            Me.chkMoviePosterCol.Size = New System.Drawing.Size(128, 17)
            Me.chkMoviePosterCol.TabIndex = 0
            Me.chkMoviePosterCol.Text = "Hide Poster Column"
            Me.chkMoviePosterCol.UseVisualStyleBackColor = True
            '
            'Movies
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gbGenreFilter)
            Me.Controls.Add(Me.gbFilters)
            Me.Controls.Add(Me.gbMissingItems)
            Me.Controls.Add(Me.gbMiscellaneous)
            Me.Controls.Add(Me.gbMediaList)
            Me.Name = "Movies"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Movies
            Me.PanelOrder = 100
            Me.PanelText = "General"
            Me.PanelType = "Movies"
            Me.gbGenreFilter.ResumeLayout(False)
            Me.gbFilters.ResumeLayout(False)
            Me.gbFilters.PerformLayout()
            Me.gbMissingItems.ResumeLayout(False)
            Me.gbMiscellaneous.ResumeLayout(False)
            Me.gbMiscellaneous.PerformLayout()
            Me.gbMediaList.ResumeLayout(False)
            Me.gbMediaList.PerformLayout()
            Me.GroupBox25.ResumeLayout(False)
            Me.GroupBox25.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbGenreFilter As System.Windows.Forms.GroupBox
        Friend WithEvents lbGenre As System.Windows.Forms.CheckedListBox
        Friend WithEvents gbFilters As System.Windows.Forms.GroupBox
        Friend WithEvents btnResetMovieFilters As System.Windows.Forms.Button
        Friend WithEvents btnDown As System.Windows.Forms.Button
        Friend WithEvents btnUp As System.Windows.Forms.Button
        Friend WithEvents chkProperCase As System.Windows.Forms.CheckBox
        Friend WithEvents btnRemoveFilter As System.Windows.Forms.Button
        Friend WithEvents btnAddFilter As System.Windows.Forms.Button
        Friend WithEvents txtFilter As System.Windows.Forms.TextBox
        Friend WithEvents lstFilters As System.Windows.Forms.ListBox
        Friend WithEvents gbMissingItems As System.Windows.Forms.GroupBox
        Friend WithEvents chkMissingExtra As System.Windows.Forms.CheckBox
        Friend WithEvents chkMissingSubs As System.Windows.Forms.CheckBox
        Friend WithEvents chkMissingTrailer As System.Windows.Forms.CheckBox
        Friend WithEvents chkMissingNFO As System.Windows.Forms.CheckBox
        Friend WithEvents chkMissingFanart As System.Windows.Forms.CheckBox
        Friend WithEvents chkMissingPoster As System.Windows.Forms.CheckBox
        Friend WithEvents gbMiscellaneous As System.Windows.Forms.GroupBox
        Friend WithEvents chkClickScrape As System.Windows.Forms.CheckBox
        Friend WithEvents chkAskCheckboxScrape As System.Windows.Forms.CheckBox
        Friend WithEvents chkMarkNew As System.Windows.Forms.CheckBox
        Friend WithEvents gbMediaList As System.Windows.Forms.GroupBox
        Friend WithEvents txtCheckTitleTol As IntegerTextBox
        Friend WithEvents lblMismatchTolerance As System.Windows.Forms.Label
        Friend WithEvents chkCheckTitles As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
        Friend WithEvents btnRemoveToken As System.Windows.Forms.Button
        Friend WithEvents btnAddToken As System.Windows.Forms.Button
        Friend WithEvents txtSortToken As System.Windows.Forms.TextBox
        Friend WithEvents lstSortTokens As System.Windows.Forms.ListBox
        Friend WithEvents chkDisplayYear As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieExtraCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieSubCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieTrailerCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieInfoCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieFanartCol As System.Windows.Forms.CheckBox
        Friend WithEvents chkMoviePosterCol As System.Windows.Forms.CheckBox

    End Class
End Namespace