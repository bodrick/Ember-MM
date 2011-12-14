<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddEditAddon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAddEditAddon))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtVersion = New System.Windows.Forms.TextBox
        Me.lvFiles = New System.Windows.Forms.ListView
        Me.colFile = New System.Windows.Forms.ColumnHeader
        Me.colDescription = New System.Windows.Forms.ColumnHeader
        Me.lblName = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblMinEVersion = New System.Windows.Forms.Label
        Me.txtMinEVersion = New System.Windows.Forms.TextBox
        Me.lblMaxEVersion = New System.Windows.Forms.Label
        Me.txtMaxEVersion = New System.Windows.Forms.TextBox
        Me.lblCategory = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.pbScreenShot = New System.Windows.Forms.PictureBox
        Me.txtScreenShotPath = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnEditFile = New System.Windows.Forms.Button
        Me.btnAddFile = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lblSSPath = New System.Windows.Forms.Label
        Me.lblPreview = New System.Windows.Forms.Label
        Me.lblSSInfo = New System.Windows.Forms.Label
        CType(Me.pbScreenShot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(518, 394)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(591, 394)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(95, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(282, 22)
        Me.txtName.TabIndex = 2
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(95, 40)
        Me.txtDescription.MaxLength = 150
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(282, 49)
        Me.txtDescription.TabIndex = 3
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(558, 12)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(100, 22)
        Me.txtVersion.TabIndex = 4
        '
        'lvFiles
        '
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFile, Me.colDescription})
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.Location = New System.Drawing.Point(6, 122)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(652, 155)
        Me.lvFiles.TabIndex = 6
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'colFile
        '
        Me.colFile.Text = "File"
        Me.colFile.Width = 329
        '
        'colDescription
        '
        Me.colDescription.Text = "Description"
        Me.colDescription.Width = 300
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(3, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(86, 13)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(3, 40)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(86, 13)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Description:"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(426, 15)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(126, 13)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Addon Version:"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMinEVersion
        '
        Me.lblMinEVersion.Location = New System.Drawing.Point(426, 42)
        Me.lblMinEVersion.Name = "lblMinEVersion"
        Me.lblMinEVersion.Size = New System.Drawing.Size(126, 13)
        Me.lblMinEVersion.TabIndex = 11
        Me.lblMinEVersion.Text = "Min. Ember Version:"
        Me.lblMinEVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMinEVersion
        '
        Me.txtMinEVersion.Location = New System.Drawing.Point(558, 39)
        Me.txtMinEVersion.Name = "txtMinEVersion"
        Me.txtMinEVersion.Size = New System.Drawing.Size(100, 22)
        Me.txtMinEVersion.TabIndex = 10
        '
        'lblMaxEVersion
        '
        Me.lblMaxEVersion.Location = New System.Drawing.Point(426, 70)
        Me.lblMaxEVersion.Name = "lblMaxEVersion"
        Me.lblMaxEVersion.Size = New System.Drawing.Size(126, 13)
        Me.lblMaxEVersion.TabIndex = 13
        Me.lblMaxEVersion.Text = "Max. Ember Version:"
        Me.lblMaxEVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMaxEVersion
        '
        Me.txtMaxEVersion.Location = New System.Drawing.Point(558, 67)
        Me.txtMaxEVersion.Name = "txtMaxEVersion"
        Me.txtMaxEVersion.Size = New System.Drawing.Size(100, 22)
        Me.txtMaxEVersion.TabIndex = 12
        '
        'lblCategory
        '
        Me.lblCategory.Location = New System.Drawing.Point(426, 98)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(126, 13)
        Me.lblCategory.TabIndex = 14
        Me.lblCategory.Text = "Category:"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(558, 95)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(100, 21)
        Me.cboCategory.TabIndex = 15
        '
        'pbScreenShot
        '
        Me.pbScreenShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbScreenShot.Location = New System.Drawing.Point(318, 322)
        Me.pbScreenShot.Name = "pbScreenShot"
        Me.pbScreenShot.Size = New System.Drawing.Size(133, 95)
        Me.pbScreenShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbScreenShot.TabIndex = 16
        Me.pbScreenShot.TabStop = False
        '
        'txtScreenShotPath
        '
        Me.txtScreenShotPath.Location = New System.Drawing.Point(6, 322)
        Me.txtScreenShotPath.Name = "txtScreenShotPath"
        Me.txtScreenShotPath.Size = New System.Drawing.Size(282, 22)
        Me.txtScreenShotPath.TabIndex = 17
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(291, 321)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 18
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnEditFile
        '
        Me.btnEditFile.Image = CType(resources.GetObject("btnEditFile.Image"), System.Drawing.Image)
        Me.btnEditFile.Location = New System.Drawing.Point(35, 279)
        Me.btnEditFile.Name = "btnEditFile"
        Me.btnEditFile.Size = New System.Drawing.Size(23, 23)
        Me.btnEditFile.TabIndex = 20
        Me.btnEditFile.UseVisualStyleBackColor = True
        '
        'btnAddFile
        '
        Me.btnAddFile.Image = CType(resources.GetObject("btnAddFile.Image"), System.Drawing.Image)
        Me.btnAddFile.Location = New System.Drawing.Point(6, 279)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(23, 23)
        Me.btnAddFile.TabIndex = 19
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(635, 279)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(23, 23)
        Me.btnRemove.TabIndex = 21
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lblSSPath
        '
        Me.lblSSPath.Location = New System.Drawing.Point(6, 306)
        Me.lblSSPath.Name = "lblSSPath"
        Me.lblSSPath.Size = New System.Drawing.Size(282, 13)
        Me.lblSSPath.TabIndex = 22
        Me.lblSSPath.Text = "Path To New Screen Shot Image:"
        '
        'lblPreview
        '
        Me.lblPreview.Location = New System.Drawing.Point(315, 306)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(136, 13)
        Me.lblPreview.TabIndex = 23
        Me.lblPreview.Text = "Current Screen Shot:"
        '
        'lblSSInfo
        '
        Me.lblSSInfo.Location = New System.Drawing.Point(6, 347)
        Me.lblSSInfo.Name = "lblSSInfo"
        Me.lblSSInfo.Size = New System.Drawing.Size(309, 70)
        Me.lblSSInfo.TabIndex = 24
        Me.lblSSInfo.Text = "Screen Shot image must be a JPEG, equal to or less than 150 KB in size, and equal" & _
            " to or less than 133x95 in dimension."
        Me.lblSSInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dlgAddEditAddon
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(665, 421)
        Me.Controls.Add(Me.lblSSInfo)
        Me.Controls.Add(Me.lblPreview)
        Me.Controls.Add(Me.lblSSPath)
        Me.Controls.Add(Me.btnEditFile)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtScreenShotPath)
        Me.Controls.Add(Me.pbScreenShot)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblMaxEVersion)
        Me.Controls.Add(Me.txtMaxEVersion)
        Me.Controls.Add(Me.lblMinEVersion)
        Me.Controls.Add(Me.txtMinEVersion)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lvFiles)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAddEditAddon"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Addon"
        CType(Me.pbScreenShot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents colFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblMinEVersion As System.Windows.Forms.Label
    Friend WithEvents txtMinEVersion As System.Windows.Forms.TextBox
    Friend WithEvents lblMaxEVersion As System.Windows.Forms.Label
    Friend WithEvents txtMaxEVersion As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents pbScreenShot As System.Windows.Forms.PictureBox
    Friend WithEvents txtScreenShotPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnEditFile As System.Windows.Forms.Button
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lblSSPath As System.Windows.Forms.Label
    Friend WithEvents lblPreview As System.Windows.Forms.Label
    Friend WithEvents lblSSInfo As System.Windows.Forms.Label

End Class
