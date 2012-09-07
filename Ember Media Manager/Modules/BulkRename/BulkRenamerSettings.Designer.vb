Namespace Modules.BulkRename
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BulkRenamerSettings
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
            Me.lblBulkRenameHelp = New System.Windows.Forms.Label()
            Me.gbRenamerPatterns = New System.Windows.Forms.GroupBox()
            Me.chkRenameSingle = New System.Windows.Forms.CheckBox()
            Me.chkRenameMulti = New System.Windows.Forms.CheckBox()
            Me.lblFilePattern = New System.Windows.Forms.Label()
            Me.lblFolderPattern = New System.Windows.Forms.Label()
            Me.txtFilePattern = New System.Windows.Forms.TextBox()
            Me.txtFolderPattern = New System.Windows.Forms.TextBox()
            Me.chkBulkRenamer = New System.Windows.Forms.CheckBox()
            Me.chkGenericModule = New System.Windows.Forms.CheckBox()
            Me.gbRenamerPatterns.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblBulkRenameHelp
            '
            Me.lblBulkRenameHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblBulkRenameHelp.Location = New System.Drawing.Point(224, 96)
            Me.lblBulkRenameHelp.Name = "lblBulkRenameHelp"
            Me.lblBulkRenameHelp.Size = New System.Drawing.Size(372, 263)
            Me.lblBulkRenameHelp.TabIndex = 86
            '
            'gbRenamerPatterns
            '
            Me.gbRenamerPatterns.Controls.Add(Me.chkRenameSingle)
            Me.gbRenamerPatterns.Controls.Add(Me.chkRenameMulti)
            Me.gbRenamerPatterns.Controls.Add(Me.lblFilePattern)
            Me.gbRenamerPatterns.Controls.Add(Me.lblFolderPattern)
            Me.gbRenamerPatterns.Controls.Add(Me.txtFilePattern)
            Me.gbRenamerPatterns.Controls.Add(Me.txtFolderPattern)
            Me.gbRenamerPatterns.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.gbRenamerPatterns.Location = New System.Drawing.Point(21, 96)
            Me.gbRenamerPatterns.Name = "gbRenamerPatterns"
            Me.gbRenamerPatterns.Size = New System.Drawing.Size(197, 191)
            Me.gbRenamerPatterns.TabIndex = 90
            Me.gbRenamerPatterns.TabStop = False
            Me.gbRenamerPatterns.Text = "Default Renaming Patterns"
            '
            'chkRenameSingle
            '
            Me.chkRenameSingle.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkRenameSingle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRenameSingle.Location = New System.Drawing.Point(8, 146)
            Me.chkRenameSingle.Name = "chkRenameSingle"
            Me.chkRenameSingle.Size = New System.Drawing.Size(176, 30)
            Me.chkRenameSingle.TabIndex = 74
            Me.chkRenameSingle.Text = "Automatically Rename Files During Single-Scraper"
            Me.chkRenameSingle.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkRenameSingle.UseVisualStyleBackColor = True
            '
            'chkRenameMulti
            '
            Me.chkRenameMulti.CheckAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkRenameMulti.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRenameMulti.Location = New System.Drawing.Point(8, 108)
            Me.chkRenameMulti.Name = "chkRenameMulti"
            Me.chkRenameMulti.Size = New System.Drawing.Size(179, 30)
            Me.chkRenameMulti.TabIndex = 73
            Me.chkRenameMulti.Text = "Automatically Rename Files During Multi-Scraper"
            Me.chkRenameMulti.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkRenameMulti.UseVisualStyleBackColor = True
            '
            'lblFilePattern
            '
            Me.lblFilePattern.AutoSize = True
            Me.lblFilePattern.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFilePattern.Location = New System.Drawing.Point(7, 56)
            Me.lblFilePattern.Name = "lblFilePattern"
            Me.lblFilePattern.Size = New System.Drawing.Size(70, 13)
            Me.lblFilePattern.TabIndex = 3
            Me.lblFilePattern.Text = "Files Pattern"
            '
            'lblFolderPattern
            '
            Me.lblFolderPattern.AutoSize = True
            Me.lblFolderPattern.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFolderPattern.Location = New System.Drawing.Point(6, 17)
            Me.lblFolderPattern.Name = "lblFolderPattern"
            Me.lblFolderPattern.Size = New System.Drawing.Size(85, 13)
            Me.lblFolderPattern.TabIndex = 2
            Me.lblFolderPattern.Text = "Folders Pattern"
            '
            'txtFilePattern
            '
            Me.txtFilePattern.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFilePattern.Location = New System.Drawing.Point(8, 71)
            Me.txtFilePattern.Name = "txtFilePattern"
            Me.txtFilePattern.Size = New System.Drawing.Size(176, 22)
            Me.txtFilePattern.TabIndex = 1
            '
            'txtFolderPattern
            '
            Me.txtFolderPattern.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFolderPattern.Location = New System.Drawing.Point(8, 32)
            Me.txtFolderPattern.Name = "txtFolderPattern"
            Me.txtFolderPattern.Size = New System.Drawing.Size(177, 22)
            Me.txtFolderPattern.TabIndex = 0
            '
            'chkBulkRenamer
            '
            Me.chkBulkRenamer.AutoSize = True
            Me.chkBulkRenamer.Location = New System.Drawing.Point(391, 73)
            Me.chkBulkRenamer.Name = "chkBulkRenamer"
            Me.chkBulkRenamer.Size = New System.Drawing.Size(153, 17)
            Me.chkBulkRenamer.TabIndex = 89
            Me.chkBulkRenamer.Text = "Enable Bulk Renamer Tool"
            Me.chkBulkRenamer.UseVisualStyleBackColor = True
            '
            'chkGenericModule
            '
            Me.chkGenericModule.AutoSize = True
            Me.chkGenericModule.Location = New System.Drawing.Point(10, 73)
            Me.chkGenericModule.Name = "chkGenericModule"
            Me.chkGenericModule.Size = New System.Drawing.Size(180, 17)
            Me.chkGenericModule.TabIndex = 88
            Me.chkGenericModule.Text = "Enable Generic Rename Module"
            Me.chkGenericModule.UseVisualStyleBackColor = True
            '
            'BulkRenamerSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.lblBulkRenameHelp)
            Me.Controls.Add(Me.gbRenamerPatterns)
            Me.Controls.Add(Me.chkBulkRenamer)
            Me.Controls.Add(Me.chkGenericModule)
            Me.Name = "BulkRenamerSettings"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_BulkRename
            Me.PanelOrder = 100
            Me.PanelText = "Renamer"
            Me.PanelType = "Modules"
            Me.gbRenamerPatterns.ResumeLayout(False)
            Me.gbRenamerPatterns.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblBulkRenameHelp As System.Windows.Forms.Label
        Friend WithEvents gbRenamerPatterns As System.Windows.Forms.GroupBox
        Friend WithEvents chkRenameSingle As System.Windows.Forms.CheckBox
        Friend WithEvents chkRenameMulti As System.Windows.Forms.CheckBox
        Friend WithEvents lblFilePattern As System.Windows.Forms.Label
        Friend WithEvents lblFolderPattern As System.Windows.Forms.Label
        Friend WithEvents txtFilePattern As System.Windows.Forms.TextBox
        Friend WithEvents txtFolderPattern As System.Windows.Forms.TextBox
        Friend WithEvents chkBulkRenamer As System.Windows.Forms.CheckBox
        Friend WithEvents chkGenericModule As System.Windows.Forms.CheckBox

    End Class
End Namespace