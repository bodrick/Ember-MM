Imports EmberControls

Namespace Modules.Extras
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AVCodecEditor
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnRemoveVideo = New System.Windows.Forms.Button()
            Me.btnAddVideo = New System.Windows.Forms.Button()
            Me.dgvVideo = New System.Windows.Forms.DataGridView()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btnRemoveAudio = New System.Windows.Forms.Button()
            Me.btnAddAudio = New System.Windows.Forms.Button()
            Me.dgvAudio = New System.Windows.Forms.DataGridView()
            Me.Codec = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.dgvVideo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvAudio, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(314, 7)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(34, 13)
            Me.Label2.TabIndex = 25
            Me.Label2.Text = "Video"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(34, 13)
            Me.Label1.TabIndex = 24
            Me.Label1.Text = "Audio"
            '
            'btnRemoveVideo
            '
            Me.btnRemoveVideo.Enabled = False
            Me.btnRemoveVideo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveVideo.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveVideo.Location = New System.Drawing.Point(525, 259)
            Me.btnRemoveVideo.Name = "btnRemoveVideo"
            Me.btnRemoveVideo.Size = New System.Drawing.Size(87, 23)
            Me.btnRemoveVideo.TabIndex = 22
            Me.btnRemoveVideo.Tag = ""
            Me.btnRemoveVideo.Text = "Remove"
            Me.btnRemoveVideo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveVideo.UseVisualStyleBackColor = True
            '
            'btnAddVideo
            '
            Me.btnAddVideo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddVideo.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddVideo.Location = New System.Drawing.Point(432, 259)
            Me.btnAddVideo.Name = "btnAddVideo"
            Me.btnAddVideo.Size = New System.Drawing.Size(87, 23)
            Me.btnAddVideo.TabIndex = 23
            Me.btnAddVideo.Tag = ""
            Me.btnAddVideo.Text = "Add"
            Me.btnAddVideo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddVideo.UseVisualStyleBackColor = True
            '
            'dgvVideo
            '
            Me.dgvVideo.AllowUserToAddRows = False
            Me.dgvVideo.AllowUserToDeleteRows = False
            Me.dgvVideo.AllowUserToResizeColumns = False
            Me.dgvVideo.AllowUserToResizeRows = False
            Me.dgvVideo.BackgroundColor = System.Drawing.Color.White
            Me.dgvVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvVideo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
            Me.dgvVideo.Location = New System.Drawing.Point(317, 23)
            Me.dgvVideo.MultiSelect = False
            Me.dgvVideo.Name = "dgvVideo"
            Me.dgvVideo.RowHeadersVisible = False
            Me.dgvVideo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvVideo.ShowCellErrors = False
            Me.dgvVideo.ShowCellToolTips = False
            Me.dgvVideo.ShowRowErrors = False
            Me.dgvVideo.Size = New System.Drawing.Size(295, 230)
            Me.dgvVideo.TabIndex = 21
            Me.dgvVideo.Tag = ""
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.FillWeight = 130.0!
            Me.DataGridViewTextBoxColumn1.HeaderText = "Mediainfo Codec"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Width = 130
            '
            'DataGridViewTextBoxColumn2
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn2.FillWeight = 150.0!
            Me.DataGridViewTextBoxColumn2.HeaderText = "Mapped Codec"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn2.Width = 150
            '
            'btnRemoveAudio
            '
            Me.btnRemoveAudio.Enabled = False
            Me.btnRemoveAudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAudio.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveAudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveAudio.Location = New System.Drawing.Point(214, 259)
            Me.btnRemoveAudio.Name = "btnRemoveAudio"
            Me.btnRemoveAudio.Size = New System.Drawing.Size(87, 23)
            Me.btnRemoveAudio.TabIndex = 19
            Me.btnRemoveAudio.Tag = ""
            Me.btnRemoveAudio.Text = "Remove"
            Me.btnRemoveAudio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveAudio.UseVisualStyleBackColor = True
            '
            'btnAddAudio
            '
            Me.btnAddAudio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddAudio.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddAudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddAudio.Location = New System.Drawing.Point(121, 259)
            Me.btnAddAudio.Name = "btnAddAudio"
            Me.btnAddAudio.Size = New System.Drawing.Size(87, 23)
            Me.btnAddAudio.TabIndex = 20
            Me.btnAddAudio.Tag = ""
            Me.btnAddAudio.Text = "Add"
            Me.btnAddAudio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddAudio.UseVisualStyleBackColor = True
            '
            'dgvAudio
            '
            Me.dgvAudio.AllowUserToAddRows = False
            Me.dgvAudio.AllowUserToDeleteRows = False
            Me.dgvAudio.AllowUserToResizeColumns = False
            Me.dgvAudio.AllowUserToResizeRows = False
            Me.dgvAudio.BackgroundColor = System.Drawing.Color.White
            Me.dgvAudio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvAudio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codec, Me.DataGridViewComboBoxColumn1})
            Me.dgvAudio.Location = New System.Drawing.Point(6, 23)
            Me.dgvAudio.MultiSelect = False
            Me.dgvAudio.Name = "dgvAudio"
            Me.dgvAudio.RowHeadersVisible = False
            Me.dgvAudio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvAudio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvAudio.ShowCellErrors = False
            Me.dgvAudio.ShowCellToolTips = False
            Me.dgvAudio.ShowRowErrors = False
            Me.dgvAudio.Size = New System.Drawing.Size(295, 230)
            Me.dgvAudio.TabIndex = 18
            Me.dgvAudio.Tag = ""
            '
            'Codec
            '
            Me.Codec.FillWeight = 130.0!
            Me.Codec.HeaderText = "Mediainfo Codec"
            Me.Codec.Name = "Codec"
            Me.Codec.Width = 130
            '
            'DataGridViewComboBoxColumn1
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewComboBoxColumn1.FillWeight = 150.0!
            Me.DataGridViewComboBoxColumn1.HeaderText = "Mapped Codec"
            Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
            Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn1.Width = 150
            '
            'AVCodecEditor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.btnRemoveVideo)
            Me.Controls.Add(Me.btnAddVideo)
            Me.Controls.Add(Me.dgvVideo)
            Me.Controls.Add(Me.btnRemoveAudio)
            Me.Controls.Add(Me.btnAddAudio)
            Me.Controls.Add(Me.dgvAudio)
            Me.Name = "AVCodecEditor"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Audio
            Me.PanelOrder = 100
            Me.PanelText = "Audio & Video Codec Mapping"
            Me.PanelType = "Miscellaneous"
            CType(Me.dgvVideo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvAudio, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveVideo As System.Windows.Forms.Button
        Friend WithEvents btnAddVideo As System.Windows.Forms.Button
        Friend WithEvents dgvVideo As System.Windows.Forms.DataGridView
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnRemoveAudio As System.Windows.Forms.Button
        Friend WithEvents btnAddAudio As System.Windows.Forms.Button
        Friend WithEvents dgvAudio As System.Windows.Forms.DataGridView
        Friend WithEvents Codec As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace