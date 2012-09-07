Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Sources
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
            Me.btnEditSource = New System.Windows.Forms.Button()
            Me.gbMiscellaneous = New System.Windows.Forms.GroupBox()
            Me.chkScanOrderModify = New System.Windows.Forms.CheckBox()
            Me.chkSortBeforeScan = New System.Windows.Forms.CheckBox()
            Me.chkIgnoreLastScan = New System.Windows.Forms.CheckBox()
            Me.chkCleanDB = New System.Windows.Forms.CheckBox()
            Me.chkAutoDetectVTS = New System.Windows.Forms.CheckBox()
            Me.chkSkipStackedSizeCheck = New System.Windows.Forms.CheckBox()
            Me.lblMB = New System.Windows.Forms.Label()
            Me.txtSkipLessThan = New System.Windows.Forms.TextBox()
            Me.lblSkipSmallFiles = New System.Windows.Forms.Label()
            Me.lvMovies = New System.Windows.Forms.ListView()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colRecur = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colFolder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colSingle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.btnMovieRem = New System.Windows.Forms.Button()
            Me.btnMovieAddFolder = New System.Windows.Forms.Button()
            Me.gbFileNaming = New System.Windows.Forms.GroupBox()
            Me.chkMovieNameMultiOnly = New System.Windows.Forms.CheckBox()
            Me.gbTrailer = New System.Windows.Forms.GroupBox()
            Me.rbBracketTrailer = New System.Windows.Forms.RadioButton()
            Me.rbDashTrailer = New System.Windows.Forms.RadioButton()
            Me.gbNFO = New System.Windows.Forms.GroupBox()
            Me.chkMovieNameNFO = New System.Windows.Forms.CheckBox()
            Me.chkMovieNFO = New System.Windows.Forms.CheckBox()
            Me.gbFanart = New System.Windows.Forms.GroupBox()
            Me.chkMovieNameDotFanartJPG = New System.Windows.Forms.CheckBox()
            Me.chkMovieNameFanartJPG = New System.Windows.Forms.CheckBox()
            Me.chkFanartJPG = New System.Windows.Forms.CheckBox()
            Me.gbPosters = New System.Windows.Forms.GroupBox()
            Me.chkFolderJPG = New System.Windows.Forms.CheckBox()
            Me.chkPosterJPG = New System.Windows.Forms.CheckBox()
            Me.chkPosterTBN = New System.Windows.Forms.CheckBox()
            Me.chkMovieNameJPG = New System.Windows.Forms.CheckBox()
            Me.chkMovieJPG = New System.Windows.Forms.CheckBox()
            Me.chkMovieNameTBN = New System.Windows.Forms.CheckBox()
            Me.chkMovieTBN = New System.Windows.Forms.CheckBox()
            Me.gbBackdrops = New System.Windows.Forms.GroupBox()
            Me.chkAutoBD = New System.Windows.Forms.CheckBox()
            Me.btnBrowse = New System.Windows.Forms.Button()
            Me.txtBDPath = New System.Windows.Forms.TextBox()
            Me.fbdBrowse = New System.Windows.Forms.FolderBrowserDialog()
            Me.gbMiscellaneous.SuspendLayout()
            Me.gbFileNaming.SuspendLayout()
            Me.gbTrailer.SuspendLayout()
            Me.gbNFO.SuspendLayout()
            Me.gbFanart.SuspendLayout()
            Me.gbPosters.SuspendLayout()
            Me.gbBackdrops.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnEditSource
            '
            Me.btnEditSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditSource.Location = New System.Drawing.Point(506, 35)
            Me.btnEditSource.Name = "btnEditSource"
            Me.btnEditSource.Size = New System.Drawing.Size(104, 23)
            Me.btnEditSource.TabIndex = 9
            Me.btnEditSource.Tag = "forceupdate"
            Me.btnEditSource.Text = "Edit Source"
            Me.btnEditSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditSource.UseVisualStyleBackColor = True
            '
            'gbMiscellaneous
            '
            Me.gbMiscellaneous.Controls.Add(Me.chkScanOrderModify)
            Me.gbMiscellaneous.Controls.Add(Me.chkSortBeforeScan)
            Me.gbMiscellaneous.Controls.Add(Me.chkIgnoreLastScan)
            Me.gbMiscellaneous.Controls.Add(Me.chkCleanDB)
            Me.gbMiscellaneous.Controls.Add(Me.chkAutoDetectVTS)
            Me.gbMiscellaneous.Controls.Add(Me.chkSkipStackedSizeCheck)
            Me.gbMiscellaneous.Controls.Add(Me.lblMB)
            Me.gbMiscellaneous.Controls.Add(Me.txtSkipLessThan)
            Me.gbMiscellaneous.Controls.Add(Me.lblSkipSmallFiles)
            Me.gbMiscellaneous.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbMiscellaneous.Location = New System.Drawing.Point(5, 113)
            Me.gbMiscellaneous.Name = "gbMiscellaneous"
            Me.gbMiscellaneous.Size = New System.Drawing.Size(233, 271)
            Me.gbMiscellaneous.TabIndex = 11
            Me.gbMiscellaneous.TabStop = False
            Me.gbMiscellaneous.Text = "Miscellaneous Options"
            '
            'chkScanOrderModify
            '
            Me.chkScanOrderModify.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkScanOrderModify.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkScanOrderModify.Location = New System.Drawing.Point(5, 201)
            Me.chkScanOrderModify.Name = "chkScanOrderModify"
            Me.chkScanOrderModify.Size = New System.Drawing.Size(223, 35)
            Me.chkScanOrderModify.TabIndex = 74
            Me.chkScanOrderModify.Text = "Scan in order of last write time."
            Me.chkScanOrderModify.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkScanOrderModify.UseVisualStyleBackColor = True
            '
            'chkSortBeforeScan
            '
            Me.chkSortBeforeScan.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSortBeforeScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSortBeforeScan.Location = New System.Drawing.Point(5, 123)
            Me.chkSortBeforeScan.Name = "chkSortBeforeScan"
            Me.chkSortBeforeScan.Size = New System.Drawing.Size(222, 36)
            Me.chkSortBeforeScan.TabIndex = 73
            Me.chkSortBeforeScan.Text = "Sort files into folders before each library update"
            Me.chkSortBeforeScan.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSortBeforeScan.UseVisualStyleBackColor = True
            '
            'chkIgnoreLastScan
            '
            Me.chkIgnoreLastScan.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkIgnoreLastScan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkIgnoreLastScan.Location = New System.Drawing.Point(5, 165)
            Me.chkIgnoreLastScan.Name = "chkIgnoreLastScan"
            Me.chkIgnoreLastScan.Size = New System.Drawing.Size(222, 33)
            Me.chkIgnoreLastScan.TabIndex = 72
            Me.chkIgnoreLastScan.Text = "Always scan all media when updating library"
            Me.chkIgnoreLastScan.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkIgnoreLastScan.UseVisualStyleBackColor = True
            '
            'chkCleanDB
            '
            Me.chkCleanDB.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkCleanDB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCleanDB.Location = New System.Drawing.Point(5, 235)
            Me.chkCleanDB.Name = "chkCleanDB"
            Me.chkCleanDB.Size = New System.Drawing.Size(223, 33)
            Me.chkCleanDB.TabIndex = 71
            Me.chkCleanDB.Text = "Clean database after updating library"
            Me.chkCleanDB.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkCleanDB.UseVisualStyleBackColor = True
            '
            'chkAutoDetectVTS
            '
            Me.chkAutoDetectVTS.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoDetectVTS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAutoDetectVTS.Location = New System.Drawing.Point(5, 90)
            Me.chkAutoDetectVTS.Name = "chkAutoDetectVTS"
            Me.chkAutoDetectVTS.Size = New System.Drawing.Size(222, 34)
            Me.chkAutoDetectVTS.TabIndex = 70
            Me.chkAutoDetectVTS.Text = "Recognize VIDEO_TS Folders"
            Me.chkAutoDetectVTS.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkAutoDetectVTS.UseVisualStyleBackColor = True
            '
            'chkSkipStackedSizeCheck
            '
            Me.chkSkipStackedSizeCheck.AutoSize = True
            Me.chkSkipStackedSizeCheck.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSkipStackedSizeCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSkipStackedSizeCheck.Location = New System.Drawing.Point(27, 58)
            Me.chkSkipStackedSizeCheck.Name = "chkSkipStackedSizeCheck"
            Me.chkSkipStackedSizeCheck.Size = New System.Drawing.Size(188, 17)
            Me.chkSkipStackedSizeCheck.TabIndex = 1
            Me.chkSkipStackedSizeCheck.Text = "Skip Size Check of Stacked Files"
            Me.chkSkipStackedSizeCheck.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkSkipStackedSizeCheck.UseVisualStyleBackColor = True
            '
            'lblMB
            '
            Me.lblMB.AutoSize = True
            Me.lblMB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMB.Location = New System.Drawing.Point(133, 39)
            Me.lblMB.Name = "lblMB"
            Me.lblMB.Size = New System.Drawing.Size(24, 13)
            Me.lblMB.TabIndex = 69
            Me.lblMB.Text = "MB"
            '
            'txtSkipLessThan
            '
            Me.txtSkipLessThan.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSkipLessThan.Location = New System.Drawing.Point(27, 35)
            Me.txtSkipLessThan.Name = "txtSkipLessThan"
            Me.txtSkipLessThan.Size = New System.Drawing.Size(100, 22)
            Me.txtSkipLessThan.TabIndex = 0
            '
            'lblSkipSmallFiles
            '
            Me.lblSkipSmallFiles.AutoSize = True
            Me.lblSkipSmallFiles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSkipSmallFiles.Location = New System.Drawing.Point(4, 19)
            Me.lblSkipSmallFiles.Name = "lblSkipSmallFiles"
            Me.lblSkipSmallFiles.Size = New System.Drawing.Size(122, 13)
            Me.lblSkipSmallFiles.TabIndex = 67
            Me.lblSkipSmallFiles.Text = "Skip files smaller than:"
            '
            'lvMovies
            '
            Me.lvMovies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colName, Me.colPath, Me.colRecur, Me.colFolder, Me.colSingle})
            Me.lvMovies.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lvMovies.FullRowSelect = True
            Me.lvMovies.HideSelection = False
            Me.lvMovies.Location = New System.Drawing.Point(5, 6)
            Me.lvMovies.Name = "lvMovies"
            Me.lvMovies.Size = New System.Drawing.Size(497, 105)
            Me.lvMovies.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvMovies.TabIndex = 7
            Me.lvMovies.UseCompatibleStateImageBehavior = False
            Me.lvMovies.View = System.Windows.Forms.View.Details
            '
            'colID
            '
            Me.colID.Width = 0
            '
            'colName
            '
            Me.colName.Text = "Name"
            Me.colName.Width = 75
            '
            'colPath
            '
            Me.colPath.Text = "Path"
            Me.colPath.Width = 134
            '
            'colRecur
            '
            Me.colRecur.Text = "Recursive"
            Me.colRecur.Width = 78
            '
            'colFolder
            '
            Me.colFolder.Text = "Use Folder Name"
            Me.colFolder.Width = 116
            '
            'colSingle
            '
            Me.colSingle.Text = "Single Video"
            Me.colSingle.Width = 90
            '
            'btnMovieRem
            '
            Me.btnMovieRem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMovieRem.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnMovieRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnMovieRem.Location = New System.Drawing.Point(506, 88)
            Me.btnMovieRem.Name = "btnMovieRem"
            Me.btnMovieRem.Size = New System.Drawing.Size(104, 23)
            Me.btnMovieRem.TabIndex = 10
            Me.btnMovieRem.Tag = "forceupdate"
            Me.btnMovieRem.Text = "Remove"
            Me.btnMovieRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnMovieRem.UseVisualStyleBackColor = True
            '
            'btnMovieAddFolder
            '
            Me.btnMovieAddFolder.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMovieAddFolder.Image = Global.EmberMediaManger.My.Resources.Modules.btn_AddFolder
            Me.btnMovieAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnMovieAddFolder.Location = New System.Drawing.Point(506, 6)
            Me.btnMovieAddFolder.Name = "btnMovieAddFolder"
            Me.btnMovieAddFolder.Size = New System.Drawing.Size(104, 23)
            Me.btnMovieAddFolder.TabIndex = 8
            Me.btnMovieAddFolder.Tag = "forceupdate"
            Me.btnMovieAddFolder.Text = "Add Source"
            Me.btnMovieAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnMovieAddFolder.UseVisualStyleBackColor = True
            '
            'gbFileNaming
            '
            Me.gbFileNaming.Controls.Add(Me.chkMovieNameMultiOnly)
            Me.gbFileNaming.Controls.Add(Me.gbTrailer)
            Me.gbFileNaming.Controls.Add(Me.gbNFO)
            Me.gbFileNaming.Controls.Add(Me.gbFanart)
            Me.gbFileNaming.Controls.Add(Me.gbPosters)
            Me.gbFileNaming.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbFileNaming.Location = New System.Drawing.Point(243, 113)
            Me.gbFileNaming.Name = "gbFileNaming"
            Me.gbFileNaming.Size = New System.Drawing.Size(366, 197)
            Me.gbFileNaming.TabIndex = 12
            Me.gbFileNaming.TabStop = False
            Me.gbFileNaming.Text = "File Naming"
            '
            'chkMovieNameMultiOnly
            '
            Me.chkMovieNameMultiOnly.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkMovieNameMultiOnly.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameMultiOnly.Location = New System.Drawing.Point(195, 70)
            Me.chkMovieNameMultiOnly.Name = "chkMovieNameMultiOnly"
            Me.chkMovieNameMultiOnly.Size = New System.Drawing.Size(167, 43)
            Me.chkMovieNameMultiOnly.TabIndex = 5
            Me.chkMovieNameMultiOnly.Text = "Use <movie> Only for Folders with Multiple Movies"
            Me.chkMovieNameMultiOnly.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkMovieNameMultiOnly.UseVisualStyleBackColor = True
            '
            'gbTrailer
            '
            Me.gbTrailer.Controls.Add(Me.rbBracketTrailer)
            Me.gbTrailer.Controls.Add(Me.rbDashTrailer)
            Me.gbTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbTrailer.Location = New System.Drawing.Point(150, 111)
            Me.gbTrailer.Name = "gbTrailer"
            Me.gbTrailer.Size = New System.Drawing.Size(102, 59)
            Me.gbTrailer.TabIndex = 3
            Me.gbTrailer.TabStop = False
            Me.gbTrailer.Text = "Trailer"
            '
            'rbBracketTrailer
            '
            Me.rbBracketTrailer.AutoSize = True
            Me.rbBracketTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbBracketTrailer.Location = New System.Drawing.Point(5, 33)
            Me.rbBracketTrailer.Name = "rbBracketTrailer"
            Me.rbBracketTrailer.Size = New System.Drawing.Size(61, 17)
            Me.rbBracketTrailer.TabIndex = 1
            Me.rbBracketTrailer.TabStop = True
            Me.rbBracketTrailer.Text = "[trailer]"
            Me.rbBracketTrailer.UseVisualStyleBackColor = True
            '
            'rbDashTrailer
            '
            Me.rbDashTrailer.AutoSize = True
            Me.rbDashTrailer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbDashTrailer.Location = New System.Drawing.Point(5, 17)
            Me.rbDashTrailer.Name = "rbDashTrailer"
            Me.rbDashTrailer.Size = New System.Drawing.Size(59, 17)
            Me.rbDashTrailer.TabIndex = 0
            Me.rbDashTrailer.TabStop = True
            Me.rbDashTrailer.Text = "-trailer"
            Me.rbDashTrailer.UseVisualStyleBackColor = True
            '
            'gbNFO
            '
            Me.gbNFO.Controls.Add(Me.chkMovieNameNFO)
            Me.gbNFO.Controls.Add(Me.chkMovieNFO)
            Me.gbNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbNFO.Location = New System.Drawing.Point(258, 111)
            Me.gbNFO.Name = "gbNFO"
            Me.gbNFO.Size = New System.Drawing.Size(102, 59)
            Me.gbNFO.TabIndex = 4
            Me.gbNFO.TabStop = False
            Me.gbNFO.Text = "NFO"
            '
            'chkMovieNameNFO
            '
            Me.chkMovieNameNFO.AutoSize = True
            Me.chkMovieNameNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameNFO.Location = New System.Drawing.Point(6, 34)
            Me.chkMovieNameNFO.Name = "chkMovieNameNFO"
            Me.chkMovieNameNFO.Size = New System.Drawing.Size(93, 17)
            Me.chkMovieNameNFO.TabIndex = 1
            Me.chkMovieNameNFO.Text = "<movie>.nfo"
            Me.chkMovieNameNFO.UseVisualStyleBackColor = True
            '
            'chkMovieNFO
            '
            Me.chkMovieNFO.AutoSize = True
            Me.chkMovieNFO.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNFO.Location = New System.Drawing.Point(6, 18)
            Me.chkMovieNFO.Name = "chkMovieNFO"
            Me.chkMovieNFO.Size = New System.Drawing.Size(77, 17)
            Me.chkMovieNFO.TabIndex = 0
            Me.chkMovieNFO.Text = "movie.nfo"
            Me.chkMovieNFO.UseVisualStyleBackColor = True
            '
            'gbFanart
            '
            Me.gbFanart.Controls.Add(Me.chkMovieNameDotFanartJPG)
            Me.gbFanart.Controls.Add(Me.chkMovieNameFanartJPG)
            Me.gbFanart.Controls.Add(Me.chkFanartJPG)
            Me.gbFanart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbFanart.Location = New System.Drawing.Point(6, 111)
            Me.gbFanart.Name = "gbFanart"
            Me.gbFanart.Size = New System.Drawing.Size(136, 81)
            Me.gbFanart.TabIndex = 2
            Me.gbFanart.TabStop = False
            Me.gbFanart.Text = "Fanart"
            '
            'chkMovieNameDotFanartJPG
            '
            Me.chkMovieNameDotFanartJPG.AutoSize = True
            Me.chkMovieNameDotFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameDotFanartJPG.Location = New System.Drawing.Point(6, 51)
            Me.chkMovieNameDotFanartJPG.Name = "chkMovieNameDotFanartJPG"
            Me.chkMovieNameDotFanartJPG.Size = New System.Drawing.Size(126, 17)
            Me.chkMovieNameDotFanartJPG.TabIndex = 2
            Me.chkMovieNameDotFanartJPG.Text = "<movie>.fanart.jpg"
            Me.chkMovieNameDotFanartJPG.UseVisualStyleBackColor = True
            '
            'chkMovieNameFanartJPG
            '
            Me.chkMovieNameFanartJPG.AutoSize = True
            Me.chkMovieNameFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameFanartJPG.Location = New System.Drawing.Point(6, 35)
            Me.chkMovieNameFanartJPG.Name = "chkMovieNameFanartJPG"
            Me.chkMovieNameFanartJPG.Size = New System.Drawing.Size(127, 17)
            Me.chkMovieNameFanartJPG.TabIndex = 1
            Me.chkMovieNameFanartJPG.Text = "<movie>-fanart.jpg"
            Me.chkMovieNameFanartJPG.UseVisualStyleBackColor = True
            '
            'chkFanartJPG
            '
            Me.chkFanartJPG.AutoSize = True
            Me.chkFanartJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFanartJPG.Location = New System.Drawing.Point(6, 19)
            Me.chkFanartJPG.Name = "chkFanartJPG"
            Me.chkFanartJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkFanartJPG.TabIndex = 0
            Me.chkFanartJPG.Text = "fanart.jpg"
            Me.chkFanartJPG.UseVisualStyleBackColor = True
            '
            'gbPosters
            '
            Me.gbPosters.Controls.Add(Me.chkFolderJPG)
            Me.gbPosters.Controls.Add(Me.chkPosterJPG)
            Me.gbPosters.Controls.Add(Me.chkPosterTBN)
            Me.gbPosters.Controls.Add(Me.chkMovieNameJPG)
            Me.gbPosters.Controls.Add(Me.chkMovieJPG)
            Me.gbPosters.Controls.Add(Me.chkMovieNameTBN)
            Me.gbPosters.Controls.Add(Me.chkMovieTBN)
            Me.gbPosters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbPosters.Location = New System.Drawing.Point(6, 17)
            Me.gbPosters.Name = "gbPosters"
            Me.gbPosters.Size = New System.Drawing.Size(185, 83)
            Me.gbPosters.TabIndex = 0
            Me.gbPosters.TabStop = False
            Me.gbPosters.Text = "Posters"
            '
            'chkFolderJPG
            '
            Me.chkFolderJPG.AutoSize = True
            Me.chkFolderJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFolderJPG.Location = New System.Drawing.Point(6, 63)
            Me.chkFolderJPG.Name = "chkFolderJPG"
            Me.chkFolderJPG.Size = New System.Drawing.Size(77, 17)
            Me.chkFolderJPG.TabIndex = 3
            Me.chkFolderJPG.Text = "folder.jpg"
            Me.chkFolderJPG.UseVisualStyleBackColor = True
            '
            'chkPosterJPG
            '
            Me.chkPosterJPG.AutoSize = True
            Me.chkPosterJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPosterJPG.Location = New System.Drawing.Point(85, 47)
            Me.chkPosterJPG.Name = "chkPosterJPG"
            Me.chkPosterJPG.Size = New System.Drawing.Size(79, 17)
            Me.chkPosterJPG.TabIndex = 6
            Me.chkPosterJPG.Text = "poster.jpg"
            Me.chkPosterJPG.UseVisualStyleBackColor = True
            '
            'chkPosterTBN
            '
            Me.chkPosterTBN.AutoSize = True
            Me.chkPosterTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPosterTBN.Location = New System.Drawing.Point(6, 47)
            Me.chkPosterTBN.Name = "chkPosterTBN"
            Me.chkPosterTBN.Size = New System.Drawing.Size(80, 17)
            Me.chkPosterTBN.TabIndex = 2
            Me.chkPosterTBN.Text = "poster.tbn"
            Me.chkPosterTBN.UseVisualStyleBackColor = True
            '
            'chkMovieNameJPG
            '
            Me.chkMovieNameJPG.AutoSize = True
            Me.chkMovieNameJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameJPG.Location = New System.Drawing.Point(85, 31)
            Me.chkMovieNameJPG.Name = "chkMovieNameJPG"
            Me.chkMovieNameJPG.Size = New System.Drawing.Size(92, 17)
            Me.chkMovieNameJPG.TabIndex = 5
            Me.chkMovieNameJPG.Text = "<movie>.jpg"
            Me.chkMovieNameJPG.UseVisualStyleBackColor = True
            '
            'chkMovieJPG
            '
            Me.chkMovieJPG.AutoSize = True
            Me.chkMovieJPG.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieJPG.Location = New System.Drawing.Point(6, 31)
            Me.chkMovieJPG.Name = "chkMovieJPG"
            Me.chkMovieJPG.Size = New System.Drawing.Size(76, 17)
            Me.chkMovieJPG.TabIndex = 1
            Me.chkMovieJPG.Text = "movie.jpg"
            Me.chkMovieJPG.UseVisualStyleBackColor = True
            '
            'chkMovieNameTBN
            '
            Me.chkMovieNameTBN.AutoSize = True
            Me.chkMovieNameTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieNameTBN.Location = New System.Drawing.Point(85, 15)
            Me.chkMovieNameTBN.Name = "chkMovieNameTBN"
            Me.chkMovieNameTBN.Size = New System.Drawing.Size(93, 17)
            Me.chkMovieNameTBN.TabIndex = 4
            Me.chkMovieNameTBN.Text = "<movie>.tbn"
            Me.chkMovieNameTBN.UseVisualStyleBackColor = True
            '
            'chkMovieTBN
            '
            Me.chkMovieTBN.AutoSize = True
            Me.chkMovieTBN.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMovieTBN.Location = New System.Drawing.Point(6, 15)
            Me.chkMovieTBN.Name = "chkMovieTBN"
            Me.chkMovieTBN.Size = New System.Drawing.Size(77, 17)
            Me.chkMovieTBN.TabIndex = 0
            Me.chkMovieTBN.Text = "movie.tbn"
            Me.chkMovieTBN.UseVisualStyleBackColor = True
            '
            'gbBackdrops
            '
            Me.gbBackdrops.Controls.Add(Me.chkAutoBD)
            Me.gbBackdrops.Controls.Add(Me.btnBrowse)
            Me.gbBackdrops.Controls.Add(Me.txtBDPath)
            Me.gbBackdrops.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbBackdrops.Location = New System.Drawing.Point(243, 315)
            Me.gbBackdrops.Name = "gbBackdrops"
            Me.gbBackdrops.Size = New System.Drawing.Size(366, 69)
            Me.gbBackdrops.TabIndex = 13
            Me.gbBackdrops.TabStop = False
            Me.gbBackdrops.Text = "Backdrops Folder"
            '
            'chkAutoBD
            '
            Me.chkAutoBD.AutoSize = True
            Me.chkAutoBD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAutoBD.Location = New System.Drawing.Point(12, 46)
            Me.chkAutoBD.Name = "chkAutoBD"
            Me.chkAutoBD.Size = New System.Drawing.Size(265, 17)
            Me.chkAutoBD.TabIndex = 2
            Me.chkAutoBD.Text = "Automatically Save Fanart To Backdrops Folder"
            Me.chkAutoBD.UseVisualStyleBackColor = True
            '
            'btnBrowse
            '
            Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnBrowse.Location = New System.Drawing.Point(336, 15)
            Me.btnBrowse.Name = "btnBrowse"
            Me.btnBrowse.Size = New System.Drawing.Size(25, 23)
            Me.btnBrowse.TabIndex = 1
            Me.btnBrowse.Text = "..."
            Me.btnBrowse.UseVisualStyleBackColor = True
            '
            'txtBDPath
            '
            Me.txtBDPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBDPath.Location = New System.Drawing.Point(7, 17)
            Me.txtBDPath.Name = "txtBDPath"
            Me.txtBDPath.Size = New System.Drawing.Size(323, 22)
            Me.txtBDPath.TabIndex = 0
            '
            'fbdBrowse
            '
            Me.fbdBrowse.Description = "Select the folder where you wish to store your backdrops."
            '
            'Sources
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.btnEditSource)
            Me.Controls.Add(Me.gbMiscellaneous)
            Me.Controls.Add(Me.lvMovies)
            Me.Controls.Add(Me.btnMovieRem)
            Me.Controls.Add(Me.btnMovieAddFolder)
            Me.Controls.Add(Me.gbFileNaming)
            Me.Controls.Add(Me.gbBackdrops)
            Me.Name = "Sources"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Sources
            Me.PanelOrder = 200
            Me.PanelText = "Files and Sources"
            Me.PanelType = "Movies"
            Me.gbMiscellaneous.ResumeLayout(False)
            Me.gbMiscellaneous.PerformLayout()
            Me.gbFileNaming.ResumeLayout(False)
            Me.gbTrailer.ResumeLayout(False)
            Me.gbTrailer.PerformLayout()
            Me.gbNFO.ResumeLayout(False)
            Me.gbNFO.PerformLayout()
            Me.gbFanart.ResumeLayout(False)
            Me.gbFanart.PerformLayout()
            Me.gbPosters.ResumeLayout(False)
            Me.gbPosters.PerformLayout()
            Me.gbBackdrops.ResumeLayout(False)
            Me.gbBackdrops.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnEditSource As System.Windows.Forms.Button
        Friend WithEvents gbMiscellaneous As System.Windows.Forms.GroupBox
        Friend WithEvents chkScanOrderModify As System.Windows.Forms.CheckBox
        Friend WithEvents chkSortBeforeScan As System.Windows.Forms.CheckBox
        Friend WithEvents chkIgnoreLastScan As System.Windows.Forms.CheckBox
        Friend WithEvents chkCleanDB As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutoDetectVTS As System.Windows.Forms.CheckBox
        Friend WithEvents chkSkipStackedSizeCheck As System.Windows.Forms.CheckBox
        Friend WithEvents lblMB As System.Windows.Forms.Label
        Friend WithEvents txtSkipLessThan As System.Windows.Forms.TextBox
        Friend WithEvents lblSkipSmallFiles As System.Windows.Forms.Label
        Friend WithEvents lvMovies As System.Windows.Forms.ListView
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents colPath As System.Windows.Forms.ColumnHeader
        Friend WithEvents colRecur As System.Windows.Forms.ColumnHeader
        Friend WithEvents colFolder As System.Windows.Forms.ColumnHeader
        Friend WithEvents colSingle As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnMovieRem As System.Windows.Forms.Button
        Friend WithEvents btnMovieAddFolder As System.Windows.Forms.Button
        Friend WithEvents gbFileNaming As System.Windows.Forms.GroupBox
        Friend WithEvents chkMovieNameMultiOnly As System.Windows.Forms.CheckBox
        Friend WithEvents gbTrailer As System.Windows.Forms.GroupBox
        Friend WithEvents rbBracketTrailer As System.Windows.Forms.RadioButton
        Friend WithEvents rbDashTrailer As System.Windows.Forms.RadioButton
        Friend WithEvents gbNFO As System.Windows.Forms.GroupBox
        Friend WithEvents chkMovieNameNFO As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieNFO As System.Windows.Forms.CheckBox
        Friend WithEvents gbFanart As System.Windows.Forms.GroupBox
        Friend WithEvents chkMovieNameDotFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieNameFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkFanartJPG As System.Windows.Forms.CheckBox
        Friend WithEvents gbPosters As System.Windows.Forms.GroupBox
        Friend WithEvents chkFolderJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkPosterJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkPosterTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieNameJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieJPG As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieNameTBN As System.Windows.Forms.CheckBox
        Friend WithEvents chkMovieTBN As System.Windows.Forms.CheckBox
        Friend WithEvents gbBackdrops As System.Windows.Forms.GroupBox
        Friend WithEvents chkAutoBD As System.Windows.Forms.CheckBox
        Friend WithEvents btnBrowse As System.Windows.Forms.Button
        Friend WithEvents txtBDPath As System.Windows.Forms.TextBox
        Friend WithEvents fbdBrowse As System.Windows.Forms.FolderBrowserDialog

    End Class
End Namespace