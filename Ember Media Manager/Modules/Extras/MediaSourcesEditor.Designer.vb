Imports EmberControls

Namespace Modules.Extras

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaSourcesEditor
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
            Me.btnRemoveByFile = New System.Windows.Forms.Button()
            Me.btnAddByFile = New System.Windows.Forms.Button()
            Me.dgvByFile = New System.Windows.Forms.DataGridView()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.chkMapByFile = New System.Windows.Forms.CheckBox()
            Me.btnSetDefaults = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnRemoveSource = New System.Windows.Forms.Button()
            Me.btnAddSource = New System.Windows.Forms.Button()
            Me.dgvSources = New System.Windows.Forms.DataGridView()
            Me.Search = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.dgvByFile, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvSources, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRemoveByFile
            '
            Me.btnRemoveByFile.Enabled = False
            Me.btnRemoveByFile.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveByFile.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveByFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveByFile.Location = New System.Drawing.Point(520, 267)
            Me.btnRemoveByFile.Name = "btnRemoveByFile"
            Me.btnRemoveByFile.Size = New System.Drawing.Size(87, 23)
            Me.btnRemoveByFile.TabIndex = 29
            Me.btnRemoveByFile.Text = "Remove"
            Me.btnRemoveByFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveByFile.UseVisualStyleBackColor = True
            '
            'btnAddByFile
            '
            Me.btnAddByFile.Enabled = False
            Me.btnAddByFile.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddByFile.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddByFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddByFile.Location = New System.Drawing.Point(427, 267)
            Me.btnAddByFile.Name = "btnAddByFile"
            Me.btnAddByFile.Size = New System.Drawing.Size(87, 23)
            Me.btnAddByFile.TabIndex = 30
            Me.btnAddByFile.Text = "Add"
            Me.btnAddByFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddByFile.UseVisualStyleBackColor = True
            '
            'dgvByFile
            '
            Me.dgvByFile.AllowUserToAddRows = False
            Me.dgvByFile.AllowUserToDeleteRows = False
            Me.dgvByFile.AllowUserToResizeColumns = False
            Me.dgvByFile.AllowUserToResizeRows = False
            Me.dgvByFile.BackgroundColor = System.Drawing.Color.White
            Me.dgvByFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvByFile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
            Me.dgvByFile.Enabled = False
            Me.dgvByFile.Location = New System.Drawing.Point(365, 31)
            Me.dgvByFile.MultiSelect = False
            Me.dgvByFile.Name = "dgvByFile"
            Me.dgvByFile.RowHeadersVisible = False
            Me.dgvByFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvByFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvByFile.ShowCellErrors = False
            Me.dgvByFile.ShowCellToolTips = False
            Me.dgvByFile.ShowRowErrors = False
            Me.dgvByFile.Size = New System.Drawing.Size(242, 230)
            Me.dgvByFile.TabIndex = 28
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.FillWeight = 120.0!
            Me.DataGridViewTextBoxColumn1.HeaderText = "File Extension"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Width = 120
            '
            'DataGridViewTextBoxColumn2
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn2.HeaderText = "Source Name"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'chkMapByFile
            '
            Me.chkMapByFile.AutoSize = True
            Me.chkMapByFile.Location = New System.Drawing.Point(365, 14)
            Me.chkMapByFile.Name = "chkMapByFile"
            Me.chkMapByFile.Size = New System.Drawing.Size(198, 17)
            Me.chkMapByFile.TabIndex = 27
            Me.chkMapByFile.Text = "Map Media Source by File Extension"
            Me.chkMapByFile.UseVisualStyleBackColor = True
            '
            'btnSetDefaults
            '
            Me.btnSetDefaults.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetDefaults.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Defaults
            Me.btnSetDefaults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSetDefaults.Location = New System.Drawing.Point(21, 267)
            Me.btnSetDefaults.Name = "btnSetDefaults"
            Me.btnSetDefaults.Size = New System.Drawing.Size(105, 23)
            Me.btnSetDefaults.TabIndex = 26
            Me.btnSetDefaults.Text = "Set Defaults"
            Me.btnSetDefaults.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnSetDefaults.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(16, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 13)
            Me.Label1.TabIndex = 25
            Me.Label1.Text = "Sources"
            '
            'btnRemoveSource
            '
            Me.btnRemoveSource.Enabled = False
            Me.btnRemoveSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveSource.Location = New System.Drawing.Point(242, 267)
            Me.btnRemoveSource.Name = "btnRemoveSource"
            Me.btnRemoveSource.Size = New System.Drawing.Size(87, 23)
            Me.btnRemoveSource.TabIndex = 23
            Me.btnRemoveSource.Text = "Remove"
            Me.btnRemoveSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveSource.UseVisualStyleBackColor = True
            '
            'btnAddSource
            '
            Me.btnAddSource.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddSource.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddSource.Location = New System.Drawing.Point(149, 267)
            Me.btnAddSource.Name = "btnAddSource"
            Me.btnAddSource.Size = New System.Drawing.Size(87, 23)
            Me.btnAddSource.TabIndex = 24
            Me.btnAddSource.Text = "Add"
            Me.btnAddSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddSource.UseVisualStyleBackColor = True
            '
            'dgvSources
            '
            Me.dgvSources.AllowUserToAddRows = False
            Me.dgvSources.AllowUserToDeleteRows = False
            Me.dgvSources.AllowUserToResizeColumns = False
            Me.dgvSources.AllowUserToResizeRows = False
            Me.dgvSources.BackgroundColor = System.Drawing.Color.White
            Me.dgvSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSources.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Search, Me.DataGridViewComboBoxColumn1})
            Me.dgvSources.Location = New System.Drawing.Point(16, 31)
            Me.dgvSources.MultiSelect = False
            Me.dgvSources.Name = "dgvSources"
            Me.dgvSources.RowHeadersVisible = False
            Me.dgvSources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.dgvSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvSources.ShowCellErrors = False
            Me.dgvSources.ShowCellToolTips = False
            Me.dgvSources.ShowRowErrors = False
            Me.dgvSources.Size = New System.Drawing.Size(312, 230)
            Me.dgvSources.TabIndex = 22
            '
            'Search
            '
            Me.Search.FillWeight = 190.0!
            Me.Search.HeaderText = "Search String"
            Me.Search.Name = "Search"
            Me.Search.Width = 190
            '
            'DataGridViewComboBoxColumn1
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewComboBoxColumn1.HeaderText = "Source Name"
            Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
            Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'MediaSourcesEditor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.btnRemoveByFile)
            Me.Controls.Add(Me.btnAddByFile)
            Me.Controls.Add(Me.dgvByFile)
            Me.Controls.Add(Me.chkMapByFile)
            Me.Controls.Add(Me.btnSetDefaults)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.btnRemoveSource)
            Me.Controls.Add(Me.btnAddSource)
            Me.Controls.Add(Me.dgvSources)
            Me.Name = "MediaSourcesEditor"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_MediaSources
            Me.PanelOrder = 100
            Me.PanelText = "Media Sources Editor"
            Me.PanelType = "Miscellaneous"
            CType(Me.dgvByFile, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvSources, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnRemoveByFile As System.Windows.Forms.Button
        Friend WithEvents btnAddByFile As System.Windows.Forms.Button
        Friend WithEvents dgvByFile As System.Windows.Forms.DataGridView
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents chkMapByFile As System.Windows.Forms.CheckBox
        Friend WithEvents btnSetDefaults As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveSource As System.Windows.Forms.Button
        Friend WithEvents btnAddSource As System.Windows.Forms.Button
        Friend WithEvents dgvSources As System.Windows.Forms.DataGridView
        Friend WithEvents Search As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace