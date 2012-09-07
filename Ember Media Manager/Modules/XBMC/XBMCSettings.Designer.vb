Imports EmberControls

Namespace Modules.XBMC
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class XBMCSettings
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
            Me.gbXBMCCommunication = New System.Windows.Forms.GroupBox()
            Me.chkNotification = New System.Windows.Forms.CheckBox()
            Me.cbPlayCountHost = New System.Windows.Forms.ComboBox()
            Me.chkPlayCount = New System.Windows.Forms.CheckBox()
            Me.chkRealTime = New System.Windows.Forms.CheckBox()
            Me.btnEditCom = New System.Windows.Forms.Button()
            Me.btnRemoveCom = New System.Windows.Forms.Button()
            Me.lbXBMCCom = New System.Windows.Forms.ListBox()
            Me.btnAddCom = New System.Windows.Forms.Button()
            Me.gbXBMCCommunication.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbXBMCCommunication
            '
            Me.gbXBMCCommunication.Controls.Add(Me.chkNotification)
            Me.gbXBMCCommunication.Controls.Add(Me.cbPlayCountHost)
            Me.gbXBMCCommunication.Controls.Add(Me.chkPlayCount)
            Me.gbXBMCCommunication.Controls.Add(Me.chkRealTime)
            Me.gbXBMCCommunication.Controls.Add(Me.btnEditCom)
            Me.gbXBMCCommunication.Controls.Add(Me.btnRemoveCom)
            Me.gbXBMCCommunication.Controls.Add(Me.lbXBMCCom)
            Me.gbXBMCCommunication.Controls.Add(Me.btnAddCom)
            Me.gbXBMCCommunication.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbXBMCCommunication.Location = New System.Drawing.Point(3, 6)
            Me.gbXBMCCommunication.Name = "gbXBMCCommunication"
            Me.gbXBMCCommunication.Size = New System.Drawing.Size(611, 299)
            Me.gbXBMCCommunication.TabIndex = 84
            Me.gbXBMCCommunication.TabStop = False
            Me.gbXBMCCommunication.Text = "XBMC Communication"
            '
            'chkNotification
            '
            Me.chkNotification.AutoSize = True
            Me.chkNotification.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNotification.Location = New System.Drawing.Point(319, 92)
            Me.chkNotification.Name = "chkNotification"
            Me.chkNotification.Size = New System.Drawing.Size(121, 17)
            Me.chkNotification.TabIndex = 12
            Me.chkNotification.Text = "Send Notifications"
            Me.chkNotification.UseVisualStyleBackColor = True
            '
            'cbPlayCountHost
            '
            Me.cbPlayCountHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbPlayCountHost.FormattingEnabled = True
            Me.cbPlayCountHost.Location = New System.Drawing.Point(337, 61)
            Me.cbPlayCountHost.Name = "cbPlayCountHost"
            Me.cbPlayCountHost.Size = New System.Drawing.Size(121, 21)
            Me.cbPlayCountHost.TabIndex = 11
            '
            'chkPlayCount
            '
            Me.chkPlayCount.AutoSize = True
            Me.chkPlayCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPlayCount.Location = New System.Drawing.Point(319, 38)
            Me.chkPlayCount.Name = "chkPlayCount"
            Me.chkPlayCount.Size = New System.Drawing.Size(152, 17)
            Me.chkPlayCount.TabIndex = 10
            Me.chkPlayCount.Text = "Retrieve PlayCount from:"
            Me.chkPlayCount.UseVisualStyleBackColor = True
            '
            'chkRealTime
            '
            Me.chkRealTime.AutoSize = True
            Me.chkRealTime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRealTime.Location = New System.Drawing.Point(319, 15)
            Me.chkRealTime.Name = "chkRealTime"
            Me.chkRealTime.Size = New System.Drawing.Size(200, 17)
            Me.chkRealTime.TabIndex = 9
            Me.chkRealTime.Text = "Enable Real Time synchronization "
            Me.chkRealTime.UseVisualStyleBackColor = True
            '
            'btnEditCom
            '
            Me.btnEditCom.Enabled = False
            Me.btnEditCom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditCom.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Edit
            Me.btnEditCom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnEditCom.Location = New System.Drawing.Point(199, 182)
            Me.btnEditCom.Name = "btnEditCom"
            Me.btnEditCom.Size = New System.Drawing.Size(91, 23)
            Me.btnEditCom.TabIndex = 7
            Me.btnEditCom.Text = "Edit"
            Me.btnEditCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnEditCom.UseVisualStyleBackColor = True
            '
            'btnRemoveCom
            '
            Me.btnRemoveCom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveCom.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Remove
            Me.btnRemoveCom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnRemoveCom.Location = New System.Drawing.Point(106, 182)
            Me.btnRemoveCom.Name = "btnRemoveCom"
            Me.btnRemoveCom.Size = New System.Drawing.Size(87, 23)
            Me.btnRemoveCom.TabIndex = 1
            Me.btnRemoveCom.Text = "Remove"
            Me.btnRemoveCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnRemoveCom.UseVisualStyleBackColor = True
            '
            'lbXBMCCom
            '
            Me.lbXBMCCom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbXBMCCom.FormattingEnabled = True
            Me.lbXBMCCom.Location = New System.Drawing.Point(13, 15)
            Me.lbXBMCCom.Name = "lbXBMCCom"
            Me.lbXBMCCom.Size = New System.Drawing.Size(283, 160)
            Me.lbXBMCCom.Sorted = True
            Me.lbXBMCCom.TabIndex = 0
            '
            'btnAddCom
            '
            Me.btnAddCom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCom.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Add
            Me.btnAddCom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAddCom.Location = New System.Drawing.Point(13, 182)
            Me.btnAddCom.Name = "btnAddCom"
            Me.btnAddCom.Size = New System.Drawing.Size(87, 23)
            Me.btnAddCom.TabIndex = 8
            Me.btnAddCom.Text = "Add"
            Me.btnAddCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAddCom.UseVisualStyleBackColor = True
            '
            'XBMCSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.gbXBMCCommunication)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "XBMCSettings"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_XBMC
            Me.PanelOrder = 100
            Me.PanelText = "XBMC Controller"
            Me.PanelType = "Modules"
            Me.gbXBMCCommunication.ResumeLayout(False)
            Me.gbXBMCCommunication.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents gbXBMCCommunication As System.Windows.Forms.GroupBox
        Friend WithEvents chkNotification As System.Windows.Forms.CheckBox
        Friend WithEvents cbPlayCountHost As System.Windows.Forms.ComboBox
        Friend WithEvents chkPlayCount As System.Windows.Forms.CheckBox
        Friend WithEvents chkRealTime As System.Windows.Forms.CheckBox
        Friend WithEvents btnEditCom As System.Windows.Forms.Button
        Friend WithEvents btnRemoveCom As System.Windows.Forms.Button
        Friend WithEvents lbXBMCCom As System.Windows.Forms.ListBox
        Friend WithEvents btnAddCom As System.Windows.Forms.Button

    End Class
End Namespace