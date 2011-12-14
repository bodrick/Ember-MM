<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddonItem
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddonItem))
        Me.pbScreenShot = New System.Windows.Forms.PictureBox
        Me.lblName = New System.Windows.Forms.Label
        Me.lblSummary = New System.Windows.Forms.Label
        Me.lblAuthor = New System.Windows.Forms.Label
        Me.btnDownload = New System.Windows.Forms.Button
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblInstalled = New System.Windows.Forms.Label
        Me.lblVersionNumber = New System.Windows.Forms.Label
        Me.lblInstalledNumber = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewFileListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlStatus = New System.Windows.Forms.Panel
        Me.lblStatus = New System.Windows.Forms.Label
        Me.pbStatus = New System.Windows.Forms.ProgressBar
        Me.btnUninstall = New System.Windows.Forms.Button
        Me.lblDownloads = New System.Windows.Forms.Label
        Me.lblDownloadsCount = New System.Windows.Forms.Label
        CType(Me.pbScreenShot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cMenu.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbScreenShot
        '
        Me.pbScreenShot.BackColor = System.Drawing.Color.Transparent
        Me.pbScreenShot.Location = New System.Drawing.Point(5, 5)
        Me.pbScreenShot.Name = "pbScreenShot"
        Me.pbScreenShot.Size = New System.Drawing.Size(133, 95)
        Me.pbScreenShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbScreenShot.TabIndex = 0
        Me.pbScreenShot.TabStop = False
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(144, 5)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(261, 17)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'lblSummary
        '
        Me.lblSummary.BackColor = System.Drawing.Color.Transparent
        Me.lblSummary.Location = New System.Drawing.Point(144, 50)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(296, 50)
        Me.lblSummary.TabIndex = 2
        Me.lblSummary.Text = "Summary"
        '
        'lblAuthor
        '
        Me.lblAuthor.BackColor = System.Drawing.Color.Transparent
        Me.lblAuthor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(145, 28)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(260, 13)
        Me.lblAuthor.TabIndex = 3
        Me.lblAuthor.Text = "Author"
        '
        'btnDownload
        '
        Me.btnDownload.Image = CType(resources.GetObject("btnDownload.Image"), System.Drawing.Image)
        Me.btnDownload.Location = New System.Drawing.Point(468, 78)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(24, 23)
        Me.btnDownload.TabIndex = 4
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(413, 5)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(37, 13)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version:"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInstalled
        '
        Me.lblInstalled.BackColor = System.Drawing.Color.Transparent
        Me.lblInstalled.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstalled.Location = New System.Drawing.Point(413, 18)
        Me.lblInstalled.Name = "lblInstalled"
        Me.lblInstalled.Size = New System.Drawing.Size(37, 13)
        Me.lblInstalled.TabIndex = 6
        Me.lblInstalled.Text = "Installed:"
        Me.lblInstalled.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblInstalled.Visible = False
        '
        'lblVersionNumber
        '
        Me.lblVersionNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionNumber.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionNumber.Location = New System.Drawing.Point(451, 5)
        Me.lblVersionNumber.Name = "lblVersionNumber"
        Me.lblVersionNumber.Size = New System.Drawing.Size(41, 13)
        Me.lblVersionNumber.TabIndex = 8
        Me.lblVersionNumber.Text = "10.10.1000"
        '
        'lblInstalledNumber
        '
        Me.lblInstalledNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblInstalledNumber.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstalledNumber.Location = New System.Drawing.Point(451, 18)
        Me.lblInstalledNumber.Name = "lblInstalledNumber"
        Me.lblInstalledNumber.Size = New System.Drawing.Size(41, 13)
        Me.lblInstalledNumber.TabIndex = 9
        Me.lblInstalledNumber.Text = "10.10.1000"
        Me.lblInstalledNumber.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(468, 53)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(24, 23)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(444, 53)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(24, 23)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'cMenu
        '
        Me.cMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewFileListToolStripMenuItem})
        Me.cMenu.Name = "cMenu"
        Me.cMenu.Size = New System.Drawing.Size(151, 26)
        '
        'ViewFileListToolStripMenuItem
        '
        Me.ViewFileListToolStripMenuItem.Image = CType(resources.GetObject("ViewFileListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewFileListToolStripMenuItem.Name = "ViewFileListToolStripMenuItem"
        Me.ViewFileListToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ViewFileListToolStripMenuItem.Text = "View File List..."
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.White
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.lblStatus)
        Me.pnlStatus.Controls.Add(Me.pbStatus)
        Me.pnlStatus.Location = New System.Drawing.Point(88, 24)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(321, 57)
        Me.pnlStatus.TabIndex = 12
        Me.pnlStatus.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(5, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(310, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Downloading Files..."
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(6, 32)
        Me.pbStatus.MarqueeAnimationSpeed = 25
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(309, 19)
        Me.pbStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbStatus.TabIndex = 6
        '
        'btnUninstall
        '
        Me.btnUninstall.Image = CType(resources.GetObject("btnUninstall.Image"), System.Drawing.Image)
        Me.btnUninstall.Location = New System.Drawing.Point(444, 78)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(24, 23)
        Me.btnUninstall.TabIndex = 13
        Me.btnUninstall.UseVisualStyleBackColor = True
        Me.btnUninstall.Visible = False
        '
        'lblDownloads
        '
        Me.lblDownloads.BackColor = System.Drawing.Color.Transparent
        Me.lblDownloads.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloads.Location = New System.Drawing.Point(395, 31)
        Me.lblDownloads.Name = "lblDownloads"
        Me.lblDownloads.Size = New System.Drawing.Size(55, 12)
        Me.lblDownloads.TabIndex = 14
        Me.lblDownloads.Text = "Downloads:"
        Me.lblDownloads.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblDownloads.Visible = False
        '
        'lblDownloadsCount
        '
        Me.lblDownloadsCount.BackColor = System.Drawing.Color.Transparent
        Me.lblDownloadsCount.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadsCount.Location = New System.Drawing.Point(451, 31)
        Me.lblDownloadsCount.Name = "lblDownloadsCount"
        Me.lblDownloadsCount.Size = New System.Drawing.Size(24, 13)
        Me.lblDownloadsCount.TabIndex = 15
        Me.lblDownloadsCount.Text = "0"
        Me.lblDownloadsCount.Visible = False
        '
        'AddonItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContextMenuStrip = Me.cMenu
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.lblDownloadsCount)
        Me.Controls.Add(Me.lblDownloads)
        Me.Controls.Add(Me.btnUninstall)
        Me.Controls.Add(Me.lblInstalledNumber)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblVersionNumber)
        Me.Controls.Add(Me.lblInstalled)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.pbScreenShot)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AddonItem"
        Me.Size = New System.Drawing.Size(496, 105)
        CType(Me.pbScreenShot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cMenu.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbScreenShot As System.Windows.Forms.PictureBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents lblAuthor As System.Windows.Forms.Label
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblInstalled As System.Windows.Forms.Label
    Friend WithEvents lblVersionNumber As System.Windows.Forms.Label
    Friend WithEvents lblInstalledNumber As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewFileListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents btnUninstall As System.Windows.Forms.Button
    Friend WithEvents lblDownloads As System.Windows.Forms.Label
    Friend WithEvents lblDownloadsCount As System.Windows.Forms.Label

End Class
