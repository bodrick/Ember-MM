<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingPanel
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pbLoadingIcon = New System.Windows.Forms.PictureBox()
        Me.lblLoadingText = New System.Windows.Forms.Label()
        Me.pbarLoading = New System.Windows.Forms.ProgressBar()        
        Me.Panel3.SuspendLayout()
        CType(Me.pbLoadingIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()        
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pbLoadingIcon)
        Me.Panel3.Controls.Add(Me.lblLoadingText)
        Me.Panel3.Controls.Add(Me.pbarLoading)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(249, 111)
        Me.Panel3.TabIndex = 2
        '
        'pbLoadingIcon
        '
        Me.pbLoadingIcon.Image = Global.EmberMediaManger.My.Resources.Modules.large_icon_General
        Me.pbLoadingIcon.Location = New System.Drawing.Point(12, 11)
        Me.pbLoadingIcon.Name = "pbLoadingIcon"
        Me.pbLoadingIcon.Size = New System.Drawing.Size(48, 48)
        Me.pbLoadingIcon.TabIndex = 2
        Me.pbLoadingIcon.TabStop = False
        '
        'lblLoadingText
        '
        Me.lblLoadingText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadingText.Location = New System.Drawing.Point(63, 11)
        Me.lblLoadingText.Name = "lblLoadingText"
        Me.lblLoadingText.Size = New System.Drawing.Size(175, 48)
        Me.lblLoadingText.TabIndex = 0
        Me.lblLoadingText.Text = "Loading Settings..."
        Me.lblLoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbarLoading
        '
        Me.pbarLoading.Location = New System.Drawing.Point(8, 68)
        Me.pbarLoading.MarqueeAnimationSpeed = 25
        Me.pbarLoading.Name = "pbarLoading"
        Me.pbarLoading.Size = New System.Drawing.Size(231, 23)
        Me.pbarLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarLoading.TabIndex = 1
        '
        'LoadingPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.Panel3)
        Me.Name = "LoadingPanel"
        Me.Size = New System.Drawing.Size(257, 119)        
        Me.Panel3.ResumeLayout(False)
        CType(Me.pbLoadingIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbLoadingIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblLoadingText As System.Windows.Forms.Label
    Friend WithEvents pbarLoading As System.Windows.Forms.ProgressBar

End Class
