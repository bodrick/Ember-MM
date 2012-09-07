Imports EmberControls

Namespace Modules.Extras

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GenresEditor
        Inherits ManagedPanel

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
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRemoveGenre = New System.Windows.Forms.Button()
            Me.btnAddGenre = New System.Windows.Forms.Button()
            Me.btnRemoveLang = New System.Windows.Forms.Button()
            Me.btnAddLang = New System.Windows.Forms.Button()
            Me.cbLangs = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnChangeImg = New System.Windows.Forms.Button()
            Me.pbIcon = New System.Windows.Forms.PictureBox()
            Me.dgvGenres = New System.Windows.Forms.DataGridView()
            Me.searchstring = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvLang = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.GroupBox1.SuspendLayout()
            CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvGenres, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvLang, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRemoveGenre
            '
            Me.btnRemoveGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveGenre.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveGenre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveGenre.Location = New System.Drawing.Point(87, 249)
            Me.btnRemoveGenre.Name = "btnRemoveGenre"
            Me.btnRemoveGenre.Size = New System.Drawing.Size(72, 23)
            Me.btnRemoveGenre.TabIndex = 50
            Me.btnRemoveGenre.Tag = ""
            Me.btnRemoveGenre.Text = "Remove"
            Me.btnRemoveGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveGenre.UseVisualStyleBackColor = True
            '
            'btnAddGenre
            '
            Me.btnAddGenre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddGenre.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddGenre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddGenre.Location = New System.Drawing.Point(9, 249)
            Me.btnAddGenre.Name = "btnAddGenre"
            Me.btnAddGenre.Size = New System.Drawing.Size(72, 23)
            Me.btnAddGenre.TabIndex = 51
            Me.btnAddGenre.Tag = ""
            Me.btnAddGenre.Text = "Add"
            Me.btnAddGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddGenre.UseVisualStyleBackColor = True
            '
            'btnRemoveLang
            '
            Me.btnRemoveLang.Enabled = False
            Me.btnRemoveLang.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveLang.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveLang.Location = New System.Drawing.Point(315, 249)
            Me.btnRemoveLang.Name = "btnRemoveLang"
            Me.btnRemoveLang.Size = New System.Drawing.Size(72, 23)
            Me.btnRemoveLang.TabIndex = 48
            Me.btnRemoveLang.Text = "Remove"
            Me.btnRemoveLang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveLang.UseVisualStyleBackColor = True
            '
            'btnAddLang
            '
            Me.btnAddLang.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddLang.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddLang.Location = New System.Drawing.Point(237, 249)
            Me.btnAddLang.Name = "btnAddLang"
            Me.btnAddLang.Size = New System.Drawing.Size(72, 23)
            Me.btnAddLang.TabIndex = 49
            Me.btnAddLang.Text = "Add"
            Me.btnAddLang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddLang.UseVisualStyleBackColor = True
            '
            'cbLangs
            '
            Me.cbLangs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLangs.FormattingEnabled = True
            Me.cbLangs.Location = New System.Drawing.Point(9, 26)
            Me.cbLangs.Name = "cbLangs"
            Me.cbLangs.Size = New System.Drawing.Size(188, 21)
            Me.cbLangs.TabIndex = 47
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(6, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(90, 13)
            Me.Label1.TabIndex = 46
            Me.Label1.Text = "Genres Filter"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.btnChangeImg)
            Me.GroupBox1.Controls.Add(Me.pbIcon)
            Me.GroupBox1.Location = New System.Drawing.Point(427, 50)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(180, 195)
            Me.GroupBox1.TabIndex = 43
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Image"
            '
            'btnChangeImg
            '
            Me.btnChangeImg.Enabled = False
            Me.btnChangeImg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeImg.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Media
            Me.btnChangeImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnChangeImg.Location = New System.Drawing.Point(87, 19)
            Me.btnChangeImg.Name = "btnChangeImg"
            Me.btnChangeImg.Size = New System.Drawing.Size(81, 23)
            Me.btnChangeImg.TabIndex = 12
            Me.btnChangeImg.Text = "Change"
            Me.btnChangeImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnChangeImg.UseVisualStyleBackColor = True
            '
            'pbIcon
            '
            Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pbIcon.Location = New System.Drawing.Point(8, 19)
            Me.pbIcon.Name = "pbIcon"
            Me.pbIcon.Size = New System.Drawing.Size(68, 102)
            Me.pbIcon.TabIndex = 6
            Me.pbIcon.TabStop = False
            '
            'dgvGenres
            '
            Me.dgvGenres.AllowUserToAddRows = False
            Me.dgvGenres.AllowUserToDeleteRows = False
            Me.dgvGenres.AllowUserToResizeColumns = False
            Me.dgvGenres.AllowUserToResizeRows = False
            Me.dgvGenres.BackgroundColor = System.Drawing.Color.White
            Me.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvGenres.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.searchstring})
            Me.dgvGenres.Location = New System.Drawing.Point(9, 53)
            Me.dgvGenres.MultiSelect = False
            Me.dgvGenres.Name = "dgvGenres"
            Me.dgvGenres.RowHeadersVisible = False
            Me.dgvGenres.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvGenres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvGenres.ShowCellErrors = False
            Me.dgvGenres.ShowCellToolTips = False
            Me.dgvGenres.ShowRowErrors = False
            Me.dgvGenres.Size = New System.Drawing.Size(202, 192)
            Me.dgvGenres.TabIndex = 44
            Me.dgvGenres.Tag = ""
            '
            'searchstring
            '
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.searchstring.DefaultCellStyle = DataGridViewCellStyle10
            Me.searchstring.FillWeight = 180.0!
            Me.searchstring.HeaderText = "Genre"
            Me.searchstring.Name = "searchstring"
            Me.searchstring.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.searchstring.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.searchstring.Width = 180
            '
            'dgvLang
            '
            Me.dgvLang.AllowUserToAddRows = False
            Me.dgvLang.AllowUserToDeleteRows = False
            Me.dgvLang.AllowUserToResizeColumns = False
            Me.dgvLang.AllowUserToResizeRows = False
            Me.dgvLang.BackgroundColor = System.Drawing.Color.White
            Me.dgvLang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn1})
            Me.dgvLang.Location = New System.Drawing.Point(237, 53)
            Me.dgvLang.MultiSelect = False
            Me.dgvLang.Name = "dgvLang"
            Me.dgvLang.RowHeadersVisible = False
            Me.dgvLang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvLang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvLang.ShowCellErrors = False
            Me.dgvLang.ShowCellToolTips = False
            Me.dgvLang.ShowEditingIcon = False
            Me.dgvLang.ShowRowErrors = False
            Me.dgvLang.Size = New System.Drawing.Size(164, 192)
            Me.dgvLang.TabIndex = 45
            Me.dgvLang.Tag = ""
            '
            'Column1
            '
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle11.NullValue = False
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
            Me.Column1.DefaultCellStyle = DataGridViewCellStyle11
            Me.Column1.FillWeight = 22.0!
            Me.Column1.HeaderText = ""
            Me.Column1.Name = "Column1"
            Me.Column1.Width = 22
            '
            'DataGridViewTextBoxColumn1
            '
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle12
            Me.DataGridViewTextBoxColumn1.FillWeight = 120.0!
            Me.DataGridViewTextBoxColumn1.HeaderText = "Languages"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.DataGridViewTextBoxColumn1.Width = 120
            '
            'GenresEditor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.btnRemoveGenre)
            Me.Controls.Add(Me.btnAddGenre)
            Me.Controls.Add(Me.btnRemoveLang)
            Me.Controls.Add(Me.btnAddLang)
            Me.Controls.Add(Me.cbLangs)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.dgvGenres)
            Me.Controls.Add(Me.dgvLang)
            Me.Name = "GenresEditor"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Genres
            Me.PanelOrder = 100
            Me.PanelText = "Genres Editor"
            Me.PanelType = "Miscellaneous"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvGenres, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvLang, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnRemoveGenre As System.Windows.Forms.Button
        Friend WithEvents btnAddGenre As System.Windows.Forms.Button
        Friend WithEvents btnRemoveLang As System.Windows.Forms.Button
        Friend WithEvents btnAddLang As System.Windows.Forms.Button
        Friend WithEvents cbLangs As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnChangeImg As System.Windows.Forms.Button
        Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
        Friend WithEvents dgvGenres As System.Windows.Forms.DataGridView
        Friend WithEvents searchstring As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvLang As System.Windows.Forms.DataGridView
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace