<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChangeOptions
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtEMMPath = New System.Windows.Forms.TextBox
        Me.btnGetEMMPath = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnFindPaths = New System.Windows.Forms.Button
        Me.lstEMMPaths = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.pnlCancel = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.pbCancel = New System.Windows.Forms.ProgressBar
        Me.rbX64 = New System.Windows.Forms.RadioButton
        Me.rbX86 = New System.Windows.Forms.RadioButton
        Me.lblInfo = New System.Windows.Forms.Label
        Me.btnProxy = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCancel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(228, 207)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(171, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(79, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(88, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(79, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txtEMMPath
        '
        Me.txtEMMPath.Location = New System.Drawing.Point(7, 125)
        Me.txtEMMPath.Name = "txtEMMPath"
        Me.txtEMMPath.Size = New System.Drawing.Size(364, 22)
        Me.txtEMMPath.TabIndex = 1
        '
        'btnGetEMMPath
        '
        Me.btnGetEMMPath.Location = New System.Drawing.Point(371, 124)
        Me.btnGetEMMPath.Name = "btnGetEMMPath"
        Me.btnGetEMMPath.Size = New System.Drawing.Size(25, 23)
        Me.btnGetEMMPath.TabIndex = 3
        Me.btnGetEMMPath.Text = "..."
        Me.btnGetEMMPath.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFindPaths)
        Me.GroupBox1.Controls.Add(Me.lstEMMPaths)
        Me.GroupBox1.Controls.Add(Me.txtEMMPath)
        Me.GroupBox1.Controls.Add(Me.btnGetEMMPath)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 150)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ember Media Manager Installation Path"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'btnFindPaths
        '
        Me.btnFindPaths.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindPaths.Location = New System.Drawing.Point(7, 99)
        Me.btnFindPaths.Name = "btnFindPaths"
        Me.btnFindPaths.Size = New System.Drawing.Size(110, 23)
        Me.btnFindPaths.TabIndex = 5
        Me.btnFindPaths.Text = "Find Ember Installations"
        Me.btnFindPaths.UseVisualStyleBackColor = True
        '
        'lstEMMPaths
        '
        Me.lstEMMPaths.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstEMMPaths.FullRowSelect = True
        Me.lstEMMPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstEMMPaths.Location = New System.Drawing.Point(7, 19)
        Me.lstEMMPaths.Name = "lstEMMPaths"
        Me.lstEMMPaths.Size = New System.Drawing.Size(390, 79)
        Me.lstEMMPaths.TabIndex = 4
        Me.lstEMMPaths.UseCompatibleStateImageBehavior = False
        Me.lstEMMPaths.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 367
        '
        'pnlCancel
        '
        Me.pnlCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCancel.Controls.Add(Me.btnCancel)
        Me.pnlCancel.Controls.Add(Me.lblStatus)
        Me.pnlCancel.Controls.Add(Me.pbCancel)
        Me.pnlCancel.Location = New System.Drawing.Point(80, 67)
        Me.pnlCancel.Name = "pnlCancel"
        Me.pnlCancel.Size = New System.Drawing.Size(260, 96)
        Me.pnlCancel.TabIndex = 5
        Me.pnlCancel.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(91, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(79, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(3, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(256, 39)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Searching for possible Ember Media Manager Installations"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbCancel
        '
        Me.pbCancel.Location = New System.Drawing.Point(3, 67)
        Me.pbCancel.Name = "pbCancel"
        Me.pbCancel.Size = New System.Drawing.Size(254, 23)
        Me.pbCancel.TabIndex = 0
        '
        'rbX64
        '
        Me.rbX64.AutoSize = True
        Me.rbX64.Location = New System.Drawing.Point(213, 173)
        Me.rbX64.Name = "rbX64"
        Me.rbX64.Size = New System.Drawing.Size(42, 17)
        Me.rbX64.TabIndex = 5
        Me.rbX64.Text = "x64"
        Me.rbX64.UseVisualStyleBackColor = True
        '
        'rbX86
        '
        Me.rbX86.AutoSize = True
        Me.rbX86.Checked = True
        Me.rbX86.Location = New System.Drawing.Point(165, 173)
        Me.rbX86.Name = "rbX86"
        Me.rbX86.Size = New System.Drawing.Size(42, 17)
        Me.rbX86.TabIndex = 6
        Me.rbX86.TabStop = True
        Me.rbX86.Text = "x86"
        Me.rbX86.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(165, 157)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(90, 13)
        Me.lblInfo.TabIndex = 7
        Me.lblInfo.Text = "Platform"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnProxy
        '
        Me.btnProxy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProxy.Location = New System.Drawing.Point(12, 210)
        Me.btnProxy.Name = "btnProxy"
        Me.btnProxy.Size = New System.Drawing.Size(79, 23)
        Me.btnProxy.TabIndex = 8
        Me.btnProxy.Text = "Setup Proxy"
        '
        'dlgChangeOptions
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(411, 248)
        Me.Controls.Add(Me.btnProxy)
        Me.Controls.Add(Me.pnlCancel)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.rbX86)
        Me.Controls.Add(Me.rbX64)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChangeOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCancel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtEMMPath As System.Windows.Forms.TextBox
    Friend WithEvents btnGetEMMPath As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstEMMPaths As System.Windows.Forms.ListView
    Friend WithEvents btnFindPaths As System.Windows.Forms.Button
    Friend WithEvents pnlCancel As System.Windows.Forms.Panel
    Friend WithEvents pbCancel As System.Windows.Forms.ProgressBar
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents rbX64 As System.Windows.Forms.RadioButton
    Friend WithEvents rbX86 As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnProxy As System.Windows.Forms.Button

End Class
