Namespace Scrapers.Movies
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class dlgImgSelect
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgImgSelect))
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.OK_Button = New System.Windows.Forms.Button()
            Me.Cancel_Button = New System.Windows.Forms.Button()
            Me.pnlImages = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnPreview = New System.Windows.Forms.Button()
            Me.pnlBottomMain = New System.Windows.Forms.Panel()
            Me.pnlSize = New System.Windows.Forms.FlowLayoutPanel()
            Me.pnlFanart = New System.Windows.Forms.Panel()
            Me.chkThumb = New System.Windows.Forms.CheckBox()
            Me.chkMid = New System.Windows.Forms.CheckBox()
            Me.chkOriginal = New System.Windows.Forms.CheckBox()
            Me.lblInfo = New System.Windows.Forms.Label()
            Me.pnlStatus = New System.Windows.Forms.Panel()
            Me.lblDL1Status = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.pbStatus = New System.Windows.Forms.ProgressBar()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.pnlBottomMain.SuspendLayout()
            Me.pnlFanart.SuspendLayout()
            Me.pnlStatus.SuspendLayout()
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
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(687, 11)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'OK_Button
            '
            Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.OK_Button.Enabled = False
            Me.OK_Button.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.OK_Button.Location = New System.Drawing.Point(3, 3)
            Me.OK_Button.Name = "OK_Button"
            Me.OK_Button.Size = New System.Drawing.Size(67, 23)
            Me.OK_Button.TabIndex = 0
            Me.OK_Button.Text = "OK"
            '
            'Cancel_Button
            '
            Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Cancel_Button.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
            Me.Cancel_Button.Name = "Cancel_Button"
            Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
            Me.Cancel_Button.TabIndex = 1
            Me.Cancel_Button.Text = "Cancel"
            '
            'pnlImages
            '
            Me.pnlImages.AutoScroll = True
            Me.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlImages.Location = New System.Drawing.Point(0, 0)
            Me.pnlImages.Name = "pnlImages"
            Me.pnlImages.Size = New System.Drawing.Size(836, 495)
            Me.pnlImages.TabIndex = 4
            Me.pnlImages.Visible = False
            '
            'btnPreview
            '
            Me.btnPreview.Enabled = False
            Me.btnPreview.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
            Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnPreview.Location = New System.Drawing.Point(609, 14)
            Me.btnPreview.Name = "btnPreview"
            Me.btnPreview.Size = New System.Drawing.Size(75, 23)
            Me.btnPreview.TabIndex = 6
            Me.btnPreview.Text = "Preview"
            Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnPreview.UseVisualStyleBackColor = True
            '
            'pnlBottomMain
            '
            Me.pnlBottomMain.Controls.Add(Me.btnPreview)
            Me.pnlBottomMain.Controls.Add(Me.pnlSize)
            Me.pnlBottomMain.Controls.Add(Me.pnlFanart)
            Me.pnlBottomMain.Controls.Add(Me.lblInfo)
            Me.pnlBottomMain.Controls.Add(Me.TableLayoutPanel1)
            Me.pnlBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottomMain.Location = New System.Drawing.Point(0, 495)
            Me.pnlBottomMain.Name = "pnlBottomMain"
            Me.pnlBottomMain.Size = New System.Drawing.Size(836, 50)
            Me.pnlBottomMain.TabIndex = 5
            '
            'pnlSize
            '
            Me.pnlSize.BackColor = System.Drawing.Color.White
            Me.pnlSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlSize.Location = New System.Drawing.Point(8, 8)
            Me.pnlSize.Name = "pnlSize"
            Me.pnlSize.Size = New System.Drawing.Size(596, 34)
            Me.pnlSize.TabIndex = 4
            Me.pnlSize.Visible = False
            '
            'pnlFanart
            '
            Me.pnlFanart.BackColor = System.Drawing.Color.White
            Me.pnlFanart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlFanart.Controls.Add(Me.chkThumb)
            Me.pnlFanart.Controls.Add(Me.chkMid)
            Me.pnlFanart.Controls.Add(Me.chkOriginal)
            Me.pnlFanart.Location = New System.Drawing.Point(8, 8)
            Me.pnlFanart.Name = "pnlFanart"
            Me.pnlFanart.Size = New System.Drawing.Size(339, 34)
            Me.pnlFanart.TabIndex = 5
            Me.pnlFanart.Visible = False
            '
            'chkThumb
            '
            Me.chkThumb.AutoSize = True
            Me.chkThumb.Location = New System.Drawing.Point(231, 8)
            Me.chkThumb.Name = "chkThumb"
            Me.chkThumb.Size = New System.Drawing.Size(111, 17)
            Me.chkThumb.TabIndex = 9
            Me.chkThumb.Text = "Check All Thumb"
            Me.chkThumb.UseVisualStyleBackColor = True
            '
            'chkMid
            '
            Me.chkMid.AutoSize = True
            Me.chkMid.Location = New System.Drawing.Point(131, 8)
            Me.chkMid.Name = "chkMid"
            Me.chkMid.Size = New System.Drawing.Size(96, 17)
            Me.chkMid.TabIndex = 7
            Me.chkMid.Text = "Check All Mid"
            Me.chkMid.UseVisualStyleBackColor = True
            '
            'chkOriginal
            '
            Me.chkOriginal.AutoSize = True
            Me.chkOriginal.Location = New System.Drawing.Point(7, 8)
            Me.chkOriginal.Name = "chkOriginal"
            Me.chkOriginal.Size = New System.Drawing.Size(118, 17)
            Me.chkOriginal.TabIndex = 8
            Me.chkOriginal.Text = "Check All Original"
            Me.chkOriginal.UseVisualStyleBackColor = True
            '
            'lblInfo
            '
            Me.lblInfo.Location = New System.Drawing.Point(357, 9)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(240, 31)
            Me.lblInfo.TabIndex = 3
            Me.lblInfo.Text = "Selected item will be set as fanart. All checked items will be saved to \extrathu" & _
        "mbs."
            Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblInfo.Visible = False
            '
            'pnlStatus
            '
            Me.pnlStatus.BackColor = System.Drawing.Color.White
            Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlStatus.Controls.Add(Me.lblDL1Status)
            Me.pnlStatus.Controls.Add(Me.lblStatus)
            Me.pnlStatus.Controls.Add(Me.pbStatus)
            Me.pnlStatus.Location = New System.Drawing.Point(257, 228)
            Me.pnlStatus.Name = "pnlStatus"
            Me.pnlStatus.Size = New System.Drawing.Size(323, 88)
            Me.pnlStatus.TabIndex = 0
            Me.pnlStatus.Visible = False
            '
            'lblDL1Status
            '
            Me.lblDL1Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lblDL1Status.Location = New System.Drawing.Point(5, 29)
            Me.lblDL1Status.Name = "lblDL1Status"
            Me.lblDL1Status.Size = New System.Drawing.Size(310, 13)
            Me.lblDL1Status.TabIndex = 2
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.lblStatus.Location = New System.Drawing.Point(5, 6)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(310, 13)
            Me.lblStatus.TabIndex = 1
            Me.lblStatus.Text = "Performing Preliminary Tasks..."
            '
            'pbStatus
            '
            Me.pbStatus.Location = New System.Drawing.Point(6, 49)
            Me.pbStatus.Name = "pbStatus"
            Me.pbStatus.Size = New System.Drawing.Size(309, 19)
            Me.pbStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee
            Me.pbStatus.TabIndex = 0
            '
            'dlgImgSelect
            '
            Me.AcceptButton = Me.OK_Button
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.CancelButton = Me.Cancel_Button
            Me.ClientSize = New System.Drawing.Size(836, 545)
            Me.ControlBox = False
            Me.Controls.Add(Me.pnlStatus)
            Me.Controls.Add(Me.pnlImages)
            Me.Controls.Add(Me.pnlBottomMain)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgImgSelect"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Select Poster"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.pnlBottomMain.ResumeLayout(False)
            Me.pnlFanart.ResumeLayout(False)
            Me.pnlFanart.PerformLayout()
            Me.pnlStatus.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents OK_Button As System.Windows.Forms.Button
        Friend WithEvents Cancel_Button As System.Windows.Forms.Button
        Friend WithEvents pnlImages As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnlBottomMain As System.Windows.Forms.Panel
        Friend WithEvents pnlStatus As System.Windows.Forms.Panel
        Friend WithEvents lblDL1Status As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
        Friend WithEvents lblInfo As System.Windows.Forms.Label
        Friend WithEvents pnlSize As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnlFanart As System.Windows.Forms.Panel
        Friend WithEvents chkThumb As System.Windows.Forms.CheckBox
        Friend WithEvents chkMid As System.Windows.Forms.CheckBox
        Friend WithEvents chkOriginal As System.Windows.Forms.CheckBox
        Friend WithEvents btnPreview As System.Windows.Forms.Button

    End Class
End Namespace