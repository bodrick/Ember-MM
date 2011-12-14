<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainSetup))
        Me.btnInstall = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnOptions = New System.Windows.Forms.Button
        Me.emmNotify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.pbFiles = New System.Windows.Forms.ProgressBar
        Me.pnlProgress = New System.Windows.Forms.Panel
        Me.MyBackGround = New System.Windows.Forms.PictureBox
        Me.btnRunEmber = New System.Windows.Forms.Button
        Me.llAbout = New System.Windows.Forms.LinkLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pnlProgress.SuspendLayout()
        CType(Me.MyBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInstall
        '
        Me.btnInstall.Enabled = False
        Me.btnInstall.Location = New System.Drawing.Point(98, 259)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(101, 23)
        Me.btnInstall.TabIndex = 0
        Me.btnInstall.Text = "Install"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(205, 258)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Location = New System.Drawing.Point(302, 258)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(101, 23)
        Me.btnOptions.TabIndex = 4
        Me.btnOptions.Text = "Change Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'emmNotify
        '
        Me.emmNotify.Text = "EmberMM Setup"
        '
        'pbFiles
        '
        Me.pbFiles.Location = New System.Drawing.Point(0, 3)
        Me.pbFiles.Name = "pbFiles"
        Me.pbFiles.Size = New System.Drawing.Size(405, 13)
        Me.pbFiles.TabIndex = 6
        '
        'pnlProgress
        '
        Me.pnlProgress.Controls.Add(Me.pbFiles)
        Me.pnlProgress.Location = New System.Drawing.Point(48, 212)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(411, 19)
        Me.pnlProgress.TabIndex = 7
        Me.pnlProgress.Visible = False
        '
        'MyBackGround
        '
        Me.MyBackGround.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.MyBackGround.Location = New System.Drawing.Point(-2, 0)
        Me.MyBackGround.Name = "MyBackGround"
        Me.MyBackGround.Size = New System.Drawing.Size(508, 214)
        Me.MyBackGround.TabIndex = 9
        Me.MyBackGround.TabStop = False
        '
        'btnRunEmber
        '
        Me.btnRunEmber.Location = New System.Drawing.Point(170, 231)
        Me.btnRunEmber.Name = "btnRunEmber"
        Me.btnRunEmber.Size = New System.Drawing.Size(161, 23)
        Me.btnRunEmber.TabIndex = 8
        Me.btnRunEmber.Text = "Start Ember Media Manager"
        Me.btnRunEmber.UseVisualStyleBackColor = True
        Me.btnRunEmber.Visible = False
        '
        'llAbout
        '
        Me.llAbout.AutoSize = True
        Me.llAbout.Location = New System.Drawing.Point(446, 263)
        Me.llAbout.Name = "llAbout"
        Me.llAbout.Size = New System.Drawing.Size(39, 13)
        Me.llAbout.TabIndex = 11
        Me.llAbout.TabStop = True
        Me.llAbout.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMainSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(505, 325)
        Me.ControlBox = False
        Me.Controls.Add(Me.llAbout)
        Me.Controls.Add(Me.pnlProgress)
        Me.Controls.Add(Me.MyBackGround)
        Me.Controls.Add(Me.btnRunEmber)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnInstall)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMainSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup - Ember Media Manager"
        Me.pnlProgress.ResumeLayout(False)
        CType(Me.MyBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOptions As System.Windows.Forms.Button
    Friend WithEvents emmNotify As System.Windows.Forms.NotifyIcon
    Friend WithEvents pbFiles As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlProgress As System.Windows.Forms.Panel
    Friend WithEvents btnRunEmber As System.Windows.Forms.Button
    Friend WithEvents MyBackGround As System.Windows.Forms.PictureBox
    Friend WithEvents llAbout As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
