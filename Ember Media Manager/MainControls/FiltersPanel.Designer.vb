<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltersPanel
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
        Me.gbExtraSorting = New System.Windows.Forms.GroupBox()
        Me.btnIMDBRating = New System.Windows.Forms.Button()
        Me.btnSortTitle = New System.Windows.Forms.Button()
        Me.btnSortDate = New System.Windows.Forms.Button()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.chkFilterTolerance = New System.Windows.Forms.CheckBox()
        Me.chkFilterMissing = New System.Windows.Forms.CheckBox()
        Me.chkFilterDupe = New System.Windows.Forms.CheckBox()
        Me.gbSpecific = New System.Windows.Forms.GroupBox()
        Me.txtFilterSource = New System.Windows.Forms.TextBox()
        Me.lblFileSource = New System.Windows.Forms.Label()
        Me.cbFilterFileSource = New System.Windows.Forms.ComboBox()
        Me.chkFilterLock = New System.Windows.Forms.CheckBox()
        Me.gbModifier = New System.Windows.Forms.GroupBox()
        Me.rbFilterAnd = New System.Windows.Forms.RadioButton()
        Me.rbFilterOr = New System.Windows.Forms.RadioButton()
        Me.chkFilterNew = New System.Windows.Forms.CheckBox()
        Me.cbFilterYear = New System.Windows.Forms.ComboBox()
        Me.chkFilterMark = New System.Windows.Forms.CheckBox()
        Me.cbFilterYearMod = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtFilterGenre = New System.Windows.Forms.TextBox()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lblGenre = New System.Windows.Forms.Label()
        Me.pnlFilterGenre = New System.Windows.Forms.Panel()
        Me.clbFilterGenres = New System.Windows.Forms.CheckedListBox()
        Me.lblGFilClose = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlFilterSource = New System.Windows.Forms.Panel()
        Me.lblSFilClose = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.clbFilterSource = New System.Windows.Forms.CheckedListBox()
        Me.tmrFilterAni = New System.Windows.Forms.Timer(Me.components)
        Me.gbExtraSorting.SuspendLayout()
        Me.gbGeneral.SuspendLayout()
        Me.gbSpecific.SuspendLayout()
        Me.gbModifier.SuspendLayout()
        Me.pnlFilterGenre.SuspendLayout()
        Me.pnlFilterSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbExtraSorting
        '
        Me.gbExtraSorting.Controls.Add(Me.btnIMDBRating)
        Me.gbExtraSorting.Controls.Add(Me.btnSortTitle)
        Me.gbExtraSorting.Controls.Add(Me.btnSortDate)
        Me.gbExtraSorting.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbExtraSorting.Location = New System.Drawing.Point(3, 70)
        Me.gbExtraSorting.Name = "gbExtraSorting"
        Me.gbExtraSorting.Size = New System.Drawing.Size(131, 77)
        Me.gbExtraSorting.TabIndex = 2
        Me.gbExtraSorting.TabStop = False
        Me.gbExtraSorting.Text = "Extra Sorting"
        '
        'btnIMDBRating
        '
        Me.btnIMDBRating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))        
        Me.btnIMDBRating.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIMDBRating.Location = New System.Drawing.Point(7, 53)
        Me.btnIMDBRating.Name = "btnIMDBRating"
        Me.btnIMDBRating.Size = New System.Drawing.Size(117, 21)
        Me.btnIMDBRating.TabIndex = 2
        Me.btnIMDBRating.Text = "IMDB Rating"
        Me.btnIMDBRating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIMDBRating.UseVisualStyleBackColor = True
        '
        'btnSortTitle
        '
        Me.btnSortTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSortTitle.Image = My.Resources.Modules.img_Actor_Silhouette
        Me.btnSortTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSortTitle.Location = New System.Drawing.Point(7, 33)
        Me.btnSortTitle.Name = "btnSortTitle"
        Me.btnSortTitle.Size = New System.Drawing.Size(117, 21)
        Me.btnSortTitle.TabIndex = 1
        Me.btnSortTitle.Text = "Sort Title"
        Me.btnSortTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSortTitle.UseVisualStyleBackColor = True
        '
        'btnSortDate
        '
        Me.btnSortDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))        
        Me.btnSortDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSortDate.Location = New System.Drawing.Point(7, 13)
        Me.btnSortDate.Name = "btnSortDate"
        Me.btnSortDate.Size = New System.Drawing.Size(117, 21)
        Me.btnSortDate.TabIndex = 0
        Me.btnSortDate.Text = "Date Added"
        Me.btnSortDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSortDate.UseVisualStyleBackColor = True
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnClearFilters.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Filters
        Me.btnClearFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearFilters.Location = New System.Drawing.Point(22, 154)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(92, 20)
        Me.btnClearFilters.TabIndex = 4
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClearFilters.UseVisualStyleBackColor = True
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.chkFilterTolerance)
        Me.gbGeneral.Controls.Add(Me.chkFilterMissing)
        Me.gbGeneral.Controls.Add(Me.chkFilterDupe)
        Me.gbGeneral.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbGeneral.Location = New System.Drawing.Point(3, 4)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(131, 59)
        Me.gbGeneral.TabIndex = 1
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "General"
        '
        'chkFilterTolerance
        '
        Me.chkFilterTolerance.AutoSize = True
        Me.chkFilterTolerance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkFilterTolerance.Location = New System.Drawing.Point(7, 41)
        Me.chkFilterTolerance.Name = "chkFilterTolerance"
        Me.chkFilterTolerance.Size = New System.Drawing.Size(112, 17)
        Me.chkFilterTolerance.TabIndex = 2
        Me.chkFilterTolerance.Text = "Out of Tolerance"
        Me.chkFilterTolerance.UseVisualStyleBackColor = True
        '
        'chkFilterMissing
        '
        Me.chkFilterMissing.AutoSize = True
        Me.chkFilterMissing.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkFilterMissing.Location = New System.Drawing.Point(7, 27)
        Me.chkFilterMissing.Name = "chkFilterMissing"
        Me.chkFilterMissing.Size = New System.Drawing.Size(96, 17)
        Me.chkFilterMissing.TabIndex = 1
        Me.chkFilterMissing.Text = "Missing Items"
        Me.chkFilterMissing.UseVisualStyleBackColor = True
        '
        'chkFilterDupe
        '
        Me.chkFilterDupe.AutoSize = True
        Me.chkFilterDupe.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkFilterDupe.Location = New System.Drawing.Point(7, 13)
        Me.chkFilterDupe.Name = "chkFilterDupe"
        Me.chkFilterDupe.Size = New System.Drawing.Size(80, 17)
        Me.chkFilterDupe.TabIndex = 0
        Me.chkFilterDupe.Text = "Duplicates"
        Me.chkFilterDupe.UseVisualStyleBackColor = True
        '
        'gbSpecific
        '
        Me.gbSpecific.Controls.Add(Me.txtFilterSource)
        Me.gbSpecific.Controls.Add(Me.lblFileSource)
        Me.gbSpecific.Controls.Add(Me.cbFilterFileSource)
        Me.gbSpecific.Controls.Add(Me.chkFilterLock)
        Me.gbSpecific.Controls.Add(Me.gbModifier)
        Me.gbSpecific.Controls.Add(Me.chkFilterNew)
        Me.gbSpecific.Controls.Add(Me.cbFilterYear)
        Me.gbSpecific.Controls.Add(Me.chkFilterMark)
        Me.gbSpecific.Controls.Add(Me.cbFilterYearMod)
        Me.gbSpecific.Controls.Add(Me.lblYear)
        Me.gbSpecific.Controls.Add(Me.txtFilterGenre)
        Me.gbSpecific.Controls.Add(Me.lblSource)
        Me.gbSpecific.Controls.Add(Me.lblGenre)
        Me.gbSpecific.Controls.Add(Me.pnlFilterGenre)
        Me.gbSpecific.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbSpecific.Location = New System.Drawing.Point(135, 4)
        Me.gbSpecific.Name = "gbSpecific"
        Me.gbSpecific.Size = New System.Drawing.Size(224, 155)
        Me.gbSpecific.TabIndex = 3
        Me.gbSpecific.TabStop = False
        Me.gbSpecific.Text = "Specific"
        '
        'txtFilterSource
        '
        Me.txtFilterSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilterSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilterSource.Location = New System.Drawing.Point(50, 129)
        Me.txtFilterSource.Name = "txtFilterSource"
        Me.txtFilterSource.ReadOnly = True
        Me.txtFilterSource.Size = New System.Drawing.Size(166, 22)
        Me.txtFilterSource.TabIndex = 8
        '
        'lblFileSource
        '
        Me.lblFileSource.AutoSize = True
        Me.lblFileSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblFileSource.Location = New System.Drawing.Point(6, 108)
        Me.lblFileSource.Name = "lblFileSource"
        Me.lblFileSource.Size = New System.Drawing.Size(66, 13)
        Me.lblFileSource.TabIndex = 38
        Me.lblFileSource.Text = "File Source:"
        '
        'cbFilterFileSource
        '
        Me.cbFilterFileSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilterFileSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilterFileSource.FormattingEnabled = True
        Me.cbFilterFileSource.Location = New System.Drawing.Point(77, 105)
        Me.cbFilterFileSource.Name = "cbFilterFileSource"
        Me.cbFilterFileSource.Size = New System.Drawing.Size(139, 21)
        Me.cbFilterFileSource.TabIndex = 7
        '
        'chkFilterLock
        '
        Me.chkFilterLock.AutoSize = True
        Me.chkFilterLock.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFilterLock.Location = New System.Drawing.Point(73, 18)
        Me.chkFilterLock.Name = "chkFilterLock"
        Me.chkFilterLock.Size = New System.Drawing.Size(62, 17)
        Me.chkFilterLock.TabIndex = 2
        Me.chkFilterLock.Text = "Locked"
        Me.chkFilterLock.UseVisualStyleBackColor = True
        '
        'gbModifier
        '
        Me.gbModifier.Controls.Add(Me.rbFilterAnd)
        Me.gbModifier.Controls.Add(Me.rbFilterOr)
        Me.gbModifier.Location = New System.Drawing.Point(140, 10)
        Me.gbModifier.Name = "gbModifier"
        Me.gbModifier.Size = New System.Drawing.Size(76, 43)
        Me.gbModifier.TabIndex = 3
        Me.gbModifier.TabStop = False
        Me.gbModifier.Text = "Modifier"
        '
        'rbFilterAnd
        '
        Me.rbFilterAnd.AutoSize = True
        Me.rbFilterAnd.Checked = True
        Me.rbFilterAnd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFilterAnd.Location = New System.Drawing.Point(6, 11)
        Me.rbFilterAnd.Name = "rbFilterAnd"
        Me.rbFilterAnd.Size = New System.Drawing.Size(46, 17)
        Me.rbFilterAnd.TabIndex = 0
        Me.rbFilterAnd.TabStop = True
        Me.rbFilterAnd.Text = "And"
        Me.rbFilterAnd.UseVisualStyleBackColor = True
        '
        'rbFilterOr
        '
        Me.rbFilterOr.AutoSize = True
        Me.rbFilterOr.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFilterOr.Location = New System.Drawing.Point(6, 25)
        Me.rbFilterOr.Name = "rbFilterOr"
        Me.rbFilterOr.Size = New System.Drawing.Size(38, 17)
        Me.rbFilterOr.TabIndex = 1
        Me.rbFilterOr.Text = "Or"
        Me.rbFilterOr.UseVisualStyleBackColor = True
        '
        'chkFilterNew
        '
        Me.chkFilterNew.AutoSize = True
        Me.chkFilterNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkFilterNew.Location = New System.Drawing.Point(9, 18)
        Me.chkFilterNew.Name = "chkFilterNew"
        Me.chkFilterNew.Size = New System.Drawing.Size(49, 17)
        Me.chkFilterNew.TabIndex = 0
        Me.chkFilterNew.Text = "New"
        Me.chkFilterNew.UseVisualStyleBackColor = True
        '
        'cbFilterYear
        '
        Me.cbFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilterYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilterYear.FormattingEnabled = True
        Me.cbFilterYear.Items.AddRange(New Object() {"=", ">", "<", "!="})
        Me.cbFilterYear.Location = New System.Drawing.Point(141, 81)
        Me.cbFilterYear.Name = "cbFilterYear"
        Me.cbFilterYear.Size = New System.Drawing.Size(75, 21)
        Me.cbFilterYear.TabIndex = 6
        '
        'chkFilterMark
        '
        Me.chkFilterMark.AutoSize = True
        Me.chkFilterMark.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkFilterMark.Location = New System.Drawing.Point(9, 36)
        Me.chkFilterMark.Name = "chkFilterMark"
        Me.chkFilterMark.Size = New System.Drawing.Size(65, 17)
        Me.chkFilterMark.TabIndex = 1
        Me.chkFilterMark.Text = "Marked"
        Me.chkFilterMark.UseVisualStyleBackColor = True
        '
        'cbFilterYearMod
        '
        Me.cbFilterYearMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilterYearMod.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilterYearMod.FormattingEnabled = True
        Me.cbFilterYearMod.Items.AddRange(New Object() {"=", ">", "<", "<>"})
        Me.cbFilterYearMod.Location = New System.Drawing.Point(77, 81)
        Me.cbFilterYearMod.Name = "cbFilterYearMod"
        Me.cbFilterYearMod.Size = New System.Drawing.Size(59, 21)
        Me.cbFilterYearMod.TabIndex = 5
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblYear.Location = New System.Drawing.Point(6, 83)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(31, 13)
        Me.lblYear.TabIndex = 33
        Me.lblYear.Text = "Year:"
        '
        'txtFilterGenre
        '
        Me.txtFilterGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilterGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilterGenre.Location = New System.Drawing.Point(50, 56)
        Me.txtFilterGenre.Name = "txtFilterGenre"
        Me.txtFilterGenre.ReadOnly = True
        Me.txtFilterGenre.Size = New System.Drawing.Size(166, 22)
        Me.txtFilterGenre.TabIndex = 4
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSource.Location = New System.Drawing.Point(6, 132)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(45, 13)
        Me.lblSource.TabIndex = 29
        Me.lblSource.Text = "Source:"
        '
        'lblGenre
        '
        Me.lblGenre.AutoSize = True
        Me.lblGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblGenre.Location = New System.Drawing.Point(6, 58)
        Me.lblGenre.Name = "lblGenre"
        Me.lblGenre.Size = New System.Drawing.Size(41, 13)
        Me.lblGenre.TabIndex = 31
        Me.lblGenre.Text = "Genre:"
        '
        'pnlFilterGenre
        '
        Me.pnlFilterGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilterGenre.Controls.Add(Me.clbFilterGenres)
        Me.pnlFilterGenre.Controls.Add(Me.lblGFilClose)
        Me.pnlFilterGenre.Controls.Add(Me.Label4)
        Me.pnlFilterGenre.Controls.Add(Me.pnlFilterSource)
        Me.pnlFilterGenre.Location = New System.Drawing.Point(29, 4)
        Me.pnlFilterGenre.Name = "pnlFilterGenre"
        Me.pnlFilterGenre.Size = New System.Drawing.Size(166, 146)
        Me.pnlFilterGenre.TabIndex = 39
        Me.pnlFilterGenre.Visible = False
        '
        'clbFilterGenres
        '
        Me.clbFilterGenres.CheckOnClick = True
        Me.clbFilterGenres.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clbFilterGenres.FormattingEnabled = True
        Me.clbFilterGenres.Location = New System.Drawing.Point(1, 20)
        Me.clbFilterGenres.Name = "clbFilterGenres"
        Me.clbFilterGenres.Size = New System.Drawing.Size(162, 123)
        Me.clbFilterGenres.TabIndex = 8
        Me.clbFilterGenres.TabStop = False
        '
        'lblGFilClose
        '
        Me.lblGFilClose.AutoSize = True
        Me.lblGFilClose.BackColor = System.Drawing.Color.DimGray
        Me.lblGFilClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGFilClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblGFilClose.ForeColor = System.Drawing.Color.White
        Me.lblGFilClose.Location = New System.Drawing.Point(130, 2)
        Me.lblGFilClose.Name = "lblGFilClose"
        Me.lblGFilClose.Size = New System.Drawing.Size(35, 13)
        Me.lblGFilClose.TabIndex = 24
        Me.lblGFilClose.Text = "Close"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(1, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 17)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Genres"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlFilterSource
        '
        Me.pnlFilterSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilterSource.Controls.Add(Me.lblSFilClose)
        Me.pnlFilterSource.Controls.Add(Me.Label8)
        Me.pnlFilterSource.Controls.Add(Me.clbFilterSource)
        Me.pnlFilterSource.Location = New System.Drawing.Point(-1, -1)
        Me.pnlFilterSource.Name = "pnlFilterSource"
        Me.pnlFilterSource.Size = New System.Drawing.Size(166, 146)
        Me.pnlFilterSource.TabIndex = 25
        Me.pnlFilterSource.Visible = False
        '
        'lblSFilClose
        '
        Me.lblSFilClose.AutoSize = True
        Me.lblSFilClose.BackColor = System.Drawing.Color.DimGray
        Me.lblSFilClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSFilClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSFilClose.ForeColor = System.Drawing.Color.White
        Me.lblSFilClose.Location = New System.Drawing.Point(130, 2)
        Me.lblSFilClose.Name = "lblSFilClose"
        Me.lblSFilClose.Size = New System.Drawing.Size(33, 13)
        Me.lblSFilClose.TabIndex = 24
        Me.lblSFilClose.Text = "Close"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label8.Location = New System.Drawing.Point(1, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Sources"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'clbFilterSource
        '
        Me.clbFilterSource.CheckOnClick = True
        Me.clbFilterSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clbFilterSource.FormattingEnabled = True
        Me.clbFilterSource.Location = New System.Drawing.Point(1, 20)
        Me.clbFilterSource.Name = "clbFilterSource"
        Me.clbFilterSource.Size = New System.Drawing.Size(162, 123)
        Me.clbFilterSource.TabIndex = 8
        Me.clbFilterSource.TabStop = False
        '
        'tmrFilterAni
        '
        Me.tmrFilterAni.Interval = 1
        '
        'FiltersPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.gbExtraSorting)
        Me.Controls.Add(Me.btnClearFilters)
        Me.Controls.Add(Me.gbGeneral)
        Me.Controls.Add(Me.gbSpecific)
        Me.Name = "FiltersPanel"
        Me.Size = New System.Drawing.Size(362, 178)
        Me.gbExtraSorting.ResumeLayout(False)
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.gbSpecific.ResumeLayout(False)
        Me.gbSpecific.PerformLayout()
        Me.gbModifier.ResumeLayout(False)
        Me.gbModifier.PerformLayout()
        Me.pnlFilterGenre.ResumeLayout(False)
        Me.pnlFilterGenre.PerformLayout()
        Me.pnlFilterSource.ResumeLayout(False)
        Me.pnlFilterSource.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbExtraSorting As System.Windows.Forms.GroupBox
    Friend WithEvents btnIMDBRating As System.Windows.Forms.Button
    Friend WithEvents btnSortTitle As System.Windows.Forms.Button
    Friend WithEvents btnSortDate As System.Windows.Forms.Button
    Friend WithEvents btnClearFilters As System.Windows.Forms.Button
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents chkFilterTolerance As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilterMissing As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilterDupe As System.Windows.Forms.CheckBox
    Friend WithEvents gbSpecific As System.Windows.Forms.GroupBox
    Friend WithEvents txtFilterSource As System.Windows.Forms.TextBox
    Friend WithEvents lblFileSource As System.Windows.Forms.Label
    Friend WithEvents cbFilterFileSource As System.Windows.Forms.ComboBox
    Friend WithEvents chkFilterLock As System.Windows.Forms.CheckBox
    Friend WithEvents gbModifier As System.Windows.Forms.GroupBox
    Friend WithEvents rbFilterAnd As System.Windows.Forms.RadioButton
    Friend WithEvents rbFilterOr As System.Windows.Forms.RadioButton
    Friend WithEvents chkFilterNew As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterYear As System.Windows.Forms.ComboBox
    Friend WithEvents chkFilterMark As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterYearMod As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtFilterGenre As System.Windows.Forms.TextBox
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lblGenre As System.Windows.Forms.Label
    Friend WithEvents tmrFilterAni As System.Windows.Forms.Timer
    Friend WithEvents pnlFilterGenre As System.Windows.Forms.Panel
    Friend WithEvents clbFilterGenres As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblGFilClose As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlFilterSource As System.Windows.Forms.Panel
    Friend WithEvents lblSFilClose As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents clbFilterSource As System.Windows.Forms.CheckedListBox

End Class
