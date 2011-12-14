<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainManager
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
        Me.components = New System.ComponentModel.Container
        Me.lstVersions = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbPlatform = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnEditNews = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnRescan = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnUpload = New System.Windows.Forms.Button
        Me.btnPack = New System.Windows.Forms.Button
        Me.btnSaveVersion = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.lstFiles = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllwaysExcludeFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveExclusionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllwaysExcludeFileinFolderMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveExcludeFileinFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllwaysExcludeFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveFolderExclusionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.txtEMMVersion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.gbCommands = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDescriptions = New System.Windows.Forms.TextBox
        Me.txtCommand = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbType = New System.Windows.Forms.ComboBox
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.lstCommands = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.lstModulesx64 = New System.Windows.Forms.ListView
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.lstModulesx86 = New System.Windows.Forms.ListView
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.Label12 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.btnReport = New System.Windows.Forms.Button
        Me.txtReport = New System.Windows.Forms.TextBox
        Me.cboStats = New System.Windows.Forms.ComboBox
        Me.lstStats = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.Button1 = New System.Windows.Forms.Button
        Me.pnlWork = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnOriginPath = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnUpdateFrom = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.cmdExFiles = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbCommands.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.pnlWork.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstVersions
        '
        Me.lstVersions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lstVersions.FullRowSelect = True
        Me.lstVersions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstVersions.HideSelection = False
        Me.lstVersions.Location = New System.Drawing.Point(1, 23)
        Me.lstVersions.Name = "lstVersions"
        Me.lstVersions.Size = New System.Drawing.Size(123, 225)
        Me.lstVersions.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstVersions.TabIndex = 0
        Me.lstVersions.UseCompatibleStateImageBehavior = False
        Me.lstVersions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Versions"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Location = New System.Drawing.Point(132, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 497)
        Me.Panel1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(3, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(858, 497)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cbPlatform)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.lstFiles)
        Me.TabPage1.Controls.Add(Me.txtEMMVersion)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(850, 471)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Files"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(699, 372)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Label14"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Platform"
        '
        'cbPlatform
        '
        Me.cbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPlatform.FormattingEnabled = True
        Me.cbPlatform.Items.AddRange(New Object() {"x86", "x64", "Common", "Mono"})
        Me.cbPlatform.Location = New System.Drawing.Point(59, 369)
        Me.cbPlatform.Name = "cbPlatform"
        Me.cbPlatform.Size = New System.Drawing.Size(84, 21)
        Me.cbPlatform.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btnEditNews)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnRescan)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Me.btnPack)
        Me.GroupBox1.Controls.Add(Me.btnSaveVersion)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 391)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(836, 74)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(458, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "4. Upload Files (Beta)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnEditNews
        '
        Me.btnEditNews.Location = New System.Drawing.Point(340, 17)
        Me.btnEditNews.Name = "btnEditNews"
        Me.btnEditNews.Size = New System.Drawing.Size(115, 23)
        Me.btnEditNews.TabIndex = 15
        Me.btnEditNews.Text = "3. Edit Whats New"
        Me.btnEditNews.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(782, 43)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(54, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(593, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Host"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(628, 45)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(153, 20)
        Me.TextBox3.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(709, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Password"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(6, 17)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(85, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnRescan
        '
        Me.btnRescan.Location = New System.Drawing.Point(6, 43)
        Me.btnRescan.Name = "btnRescan"
        Me.btnRescan.Size = New System.Drawing.Size(85, 23)
        Me.btnRescan.TabIndex = 6
        Me.btnRescan.Text = "ReScan"
        Me.btnRescan.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(593, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "User"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(764, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(66, 20)
        Me.TextBox2.TabIndex = 9
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(628, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 8
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(458, 17)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(129, 23)
        Me.btnUpload.TabIndex = 7
        Me.btnUpload.Text = "4. Upload Files"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnPack
        '
        Me.btnPack.Location = New System.Drawing.Point(220, 17)
        Me.btnPack.Name = "btnPack"
        Me.btnPack.Size = New System.Drawing.Size(115, 23)
        Me.btnPack.TabIndex = 6
        Me.btnPack.Text = "2. Pack Version Files"
        Me.btnPack.UseVisualStyleBackColor = True
        '
        'btnSaveVersion
        '
        Me.btnSaveVersion.Enabled = False
        Me.btnSaveVersion.Location = New System.Drawing.Point(98, 17)
        Me.btnSaveVersion.Name = "btnSaveVersion"
        Me.btnSaveVersion.Size = New System.Drawing.Size(115, 23)
        Me.btnSaveVersion.TabIndex = 0
        Me.btnSaveVersion.Text = "1. Save Version"
        Me.btnSaveVersion.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(753, 371)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Show All Files"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lstFiles
        '
        Me.lstFiles.CheckBoxes = True
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstFiles.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstFiles.FullRowSelect = True
        Me.lstFiles.Location = New System.Drawing.Point(0, 1)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(847, 360)
        Me.lstFiles.TabIndex = 0
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Path"
        Me.ColumnHeader1.Width = 208
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File"
        Me.ColumnHeader2.Width = 319
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Ember Path"
        Me.ColumnHeader3.Width = 220
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Platform"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 76
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllwaysExcludeFileToolStripMenuItem, Me.RemoveExclusionToolStripMenuItem, Me.AllwaysExcludeFileinFolderMenuItem, Me.RemoveExcludeFileinFolderToolStripMenuItem, Me.AllwaysExcludeFolderToolStripMenuItem, Me.RemoveFolderExclusionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(250, 136)
        '
        'AllwaysExcludeFileToolStripMenuItem
        '
        Me.AllwaysExcludeFileToolStripMenuItem.Name = "AllwaysExcludeFileToolStripMenuItem"
        Me.AllwaysExcludeFileToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.AllwaysExcludeFileToolStripMenuItem.Text = "Allways Exclude File"
        '
        'RemoveExclusionToolStripMenuItem
        '
        Me.RemoveExclusionToolStripMenuItem.Name = "RemoveExclusionToolStripMenuItem"
        Me.RemoveExclusionToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.RemoveExclusionToolStripMenuItem.Text = "Remove File Exclusion"
        '
        'AllwaysExcludeFileinFolderMenuItem
        '
        Me.AllwaysExcludeFileinFolderMenuItem.Name = "AllwaysExcludeFileinFolderMenuItem"
        Me.AllwaysExcludeFileinFolderMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.AllwaysExcludeFileinFolderMenuItem.Text = "Allways Exclude File in this Folder"
        '
        'RemoveExcludeFileinFolderToolStripMenuItem
        '
        Me.RemoveExcludeFileinFolderToolStripMenuItem.Name = "RemoveExcludeFileinFolderToolStripMenuItem"
        Me.RemoveExcludeFileinFolderToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.RemoveExcludeFileinFolderToolStripMenuItem.Text = "Remove File in Folder Exclusion"
        '
        'AllwaysExcludeFolderToolStripMenuItem
        '
        Me.AllwaysExcludeFolderToolStripMenuItem.Name = "AllwaysExcludeFolderToolStripMenuItem"
        Me.AllwaysExcludeFolderToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.AllwaysExcludeFolderToolStripMenuItem.Text = "Allways Exclude Folder"
        '
        'RemoveFolderExclusionToolStripMenuItem
        '
        Me.RemoveFolderExclusionToolStripMenuItem.Name = "RemoveFolderExclusionToolStripMenuItem"
        Me.RemoveFolderExclusionToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.RemoveFolderExclusionToolStripMenuItem.Text = "Remove Folder Exclusion"
        '
        'txtEMMVersion
        '
        Me.txtEMMVersion.Location = New System.Drawing.Point(231, 369)
        Me.txtEMMVersion.Name = "txtEMMVersion"
        Me.txtEMMVersion.ReadOnly = True
        Me.txtEMMVersion.Size = New System.Drawing.Size(78, 20)
        Me.txtEMMVersion.TabIndex = 0
        Me.txtEMMVersion.Text = "2404"
        Me.txtEMMVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "EMM Version"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.gbCommands)
        Me.TabPage2.Controls.Add(Me.btnRemove)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.btnNew)
        Me.TabPage2.Controls.Add(Me.lstCommands)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(850, 471)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Upgrade Commands"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(288, 355)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Commands for Version: "
        '
        'gbCommands
        '
        Me.gbCommands.Controls.Add(Me.Button4)
        Me.gbCommands.Controls.Add(Me.Label7)
        Me.gbCommands.Controls.Add(Me.Label6)
        Me.gbCommands.Controls.Add(Me.txtDescriptions)
        Me.gbCommands.Controls.Add(Me.txtCommand)
        Me.gbCommands.Controls.Add(Me.Label5)
        Me.gbCommands.Controls.Add(Me.cbType)
        Me.gbCommands.Location = New System.Drawing.Point(6, 378)
        Me.gbCommands.Name = "gbCommands"
        Me.gbCommands.Size = New System.Drawing.Size(841, 87)
        Me.gbCommands.TabIndex = 5
        Me.gbCommands.TabStop = False
        Me.gbCommands.Text = "Command"
        Me.gbCommands.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(814, 50)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(18, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(159, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Command"
        '
        'txtDescriptions
        '
        Me.txtDescriptions.Location = New System.Drawing.Point(225, 19)
        Me.txtDescriptions.Name = "txtDescriptions"
        Me.txtDescriptions.Size = New System.Drawing.Size(610, 20)
        Me.txtDescriptions.TabIndex = 3
        '
        'txtCommand
        '
        Me.txtCommand.Location = New System.Drawing.Point(60, 50)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(748, 20)
        Me.txtCommand.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Type"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"DB", "FILE.Delete"})
        Me.cbType.Location = New System.Drawing.Point(60, 19)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(69, 21)
        Me.cbType.TabIndex = 0
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(168, 350)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(87, 350)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Location = New System.Drawing.Point(6, 350)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lstCommands
        '
        Me.lstCommands.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lstCommands.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstCommands.FullRowSelect = True
        Me.lstCommands.Location = New System.Drawing.Point(2, 3)
        Me.lstCommands.Name = "lstCommands"
        Me.lstCommands.Size = New System.Drawing.Size(847, 341)
        Me.lstCommands.TabIndex = 1
        Me.lstCommands.UseCompatibleStateImageBehavior = False
        Me.lstCommands.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Type"
        Me.ColumnHeader6.Width = 63
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Command"
        Me.ColumnHeader7.Width = 761
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.lstModulesx64)
        Me.TabPage3.Controls.Add(Me.lstModulesx86)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(850, 471)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Modules"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(443, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Versions x64"
        '
        'lstModulesx64
        '
        Me.lstModulesx64.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lstModulesx64.FullRowSelect = True
        Me.lstModulesx64.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstModulesx64.Location = New System.Drawing.Point(446, 19)
        Me.lstModulesx64.Name = "lstModulesx64"
        Me.lstModulesx64.Size = New System.Drawing.Size(376, 254)
        Me.lstModulesx64.TabIndex = 16
        Me.lstModulesx64.UseCompatibleStateImageBehavior = False
        Me.lstModulesx64.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Module"
        Me.ColumnHeader10.Width = 282
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Version"
        Me.ColumnHeader11.Width = 71
        '
        'lstModulesx86
        '
        Me.lstModulesx86.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lstModulesx86.FullRowSelect = True
        Me.lstModulesx86.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstModulesx86.Location = New System.Drawing.Point(19, 19)
        Me.lstModulesx86.Name = "lstModulesx86"
        Me.lstModulesx86.Size = New System.Drawing.Size(376, 254)
        Me.lstModulesx86.TabIndex = 15
        Me.lstModulesx86.UseCompatibleStateImageBehavior = False
        Me.lstModulesx86.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Module"
        Me.ColumnHeader8.Width = 282
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Version"
        Me.ColumnHeader9.Width = 71
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Versions x86"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnReport)
        Me.TabPage4.Controls.Add(Me.txtReport)
        Me.TabPage4.Controls.Add(Me.cboStats)
        Me.TabPage4.Controls.Add(Me.lstStats)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(850, 471)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Stats"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(476, 5)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(75, 23)
        Me.btnReport.TabIndex = 9
        Me.btnReport.Text = "Gen. Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'txtReport
        '
        Me.txtReport.Location = New System.Drawing.Point(470, 36)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReport.Size = New System.Drawing.Size(367, 427)
        Me.txtReport.TabIndex = 8
        '
        'cboStats
        '
        Me.cboStats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStats.Enabled = False
        Me.cboStats.FormattingEnabled = True
        Me.cboStats.Location = New System.Drawing.Point(212, 3)
        Me.cboStats.Name = "cboStats"
        Me.cboStats.Size = New System.Drawing.Size(121, 21)
        Me.cboStats.TabIndex = 7
        '
        'lstStats
        '
        Me.lstStats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15})
        Me.lstStats.FullRowSelect = True
        Me.lstStats.Location = New System.Drawing.Point(3, 32)
        Me.lstStats.Name = "lstStats"
        Me.lstStats.Size = New System.Drawing.Size(448, 431)
        Me.lstStats.TabIndex = 6
        Me.lstStats.UseCompatibleStateImageBehavior = False
        Me.lstStats.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Name"
        Me.ColumnHeader12.Width = 244
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "x86"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "x64"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Sum"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Download Stats Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlWork
        '
        Me.pnlWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWork.Controls.Add(Me.Label4)
        Me.pnlWork.Location = New System.Drawing.Point(315, 181)
        Me.pnlWork.Name = "pnlWork"
        Me.pnlWork.Size = New System.Drawing.Size(373, 76)
        Me.pnlWork.TabIndex = 12
        Me.pnlWork.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(132, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Please Wait"
        '
        'btnOriginPath
        '
        Me.btnOriginPath.Location = New System.Drawing.Point(1, 254)
        Me.btnOriginPath.Name = "btnOriginPath"
        Me.btnOriginPath.Size = New System.Drawing.Size(121, 23)
        Me.btnOriginPath.TabIndex = 4
        Me.btnOriginPath.Text = "Origin Path"
        Me.btnOriginPath.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(3, 464)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(121, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdateFrom
        '
        Me.btnUpdateFrom.Location = New System.Drawing.Point(5, 405)
        Me.btnUpdateFrom.Name = "btnUpdateFrom"
        Me.btnUpdateFrom.Size = New System.Drawing.Size(121, 23)
        Me.btnUpdateFrom.TabIndex = 13
        Me.btnUpdateFrom.Text = "Update from Site"
        Me.btnUpdateFrom.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(5, 432)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(121, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Update from Beta Site"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'cmdExFiles
        '
        Me.cmdExFiles.Location = New System.Drawing.Point(1, 284)
        Me.cmdExFiles.Name = "cmdExFiles"
        Me.cmdExFiles.Size = New System.Drawing.Size(121, 23)
        Me.cmdExFiles.TabIndex = 15
        Me.cmdExFiles.Text = "Excluded Files"
        Me.cmdExFiles.UseVisualStyleBackColor = True
        '
        'frmMainManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 499)
        Me.Controls.Add(Me.cmdExFiles)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.pnlWork)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdateFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstVersions)
        Me.Controls.Add(Me.btnOriginPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMainManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ember Setup Manager"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbCommands.ResumeLayout(False)
        Me.gbCommands.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.pnlWork.ResumeLayout(False)
        Me.pnlWork.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstVersions As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveVersion As System.Windows.Forms.Button
    Friend WithEvents lstFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnOriginPath As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRescan As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbPlatform As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEMMVersion As System.Windows.Forms.TextBox
    Friend WithEvents pnlWork As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AllwaysExcludeFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveExclusionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllwaysExcludeFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFolderExclusionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPack As System.Windows.Forms.Button
    Friend WithEvents lstCommands As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbCommands As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescriptions As System.Windows.Forms.TextBox
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lstModulesx86 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lstModulesx64 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEditNews As System.Windows.Forms.Button
    Friend WithEvents btnUpdateFrom As System.Windows.Forms.Button
    Friend WithEvents AllwaysExcludeFileinFolderMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveExcludeFileinFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lstStats As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboStats As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents cmdExFiles As System.Windows.Forms.Button

End Class
