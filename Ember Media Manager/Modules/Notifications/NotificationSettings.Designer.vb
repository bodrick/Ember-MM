Imports EmberControls

Namespace Modules.Notifications
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NotificationSettings
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
            Me.chkOnNewEp = New System.Windows.Forms.CheckBox()
            Me.chkOnMovieScraped = New System.Windows.Forms.CheckBox()
            Me.chkOnNewMovie = New System.Windows.Forms.CheckBox()
            Me.chkOnError = New System.Windows.Forms.CheckBox()
            Me.SuspendLayout()
            '
            'chkOnNewEp
            '
            Me.chkOnNewEp.AutoSize = True
            Me.chkOnNewEp.Location = New System.Drawing.Point(13, 115)
            Me.chkOnNewEp.Name = "chkOnNewEp"
            Me.chkOnNewEp.Size = New System.Drawing.Size(149, 17)
            Me.chkOnNewEp.TabIndex = 90
            Me.chkOnNewEp.Text = "On New Episode Added"
            Me.chkOnNewEp.UseVisualStyleBackColor = True
            '
            'chkOnMovieScraped
            '
            Me.chkOnMovieScraped.AutoSize = True
            Me.chkOnMovieScraped.Location = New System.Drawing.Point(13, 78)
            Me.chkOnMovieScraped.Name = "chkOnMovieScraped"
            Me.chkOnMovieScraped.Size = New System.Drawing.Size(120, 17)
            Me.chkOnMovieScraped.TabIndex = 89
            Me.chkOnMovieScraped.Text = "On Movie Scraped"
            Me.chkOnMovieScraped.UseVisualStyleBackColor = True
            '
            'chkOnNewMovie
            '
            Me.chkOnNewMovie.AutoSize = True
            Me.chkOnNewMovie.Location = New System.Drawing.Point(13, 55)
            Me.chkOnNewMovie.Name = "chkOnNewMovie"
            Me.chkOnNewMovie.Size = New System.Drawing.Size(139, 17)
            Me.chkOnNewMovie.TabIndex = 88
            Me.chkOnNewMovie.Text = "On New Movie Added"
            Me.chkOnNewMovie.UseVisualStyleBackColor = True
            '
            'chkOnError
            '
            Me.chkOnError.AutoSize = True
            Me.chkOnError.Location = New System.Drawing.Point(13, 14)
            Me.chkOnError.Name = "chkOnError"
            Me.chkOnError.Size = New System.Drawing.Size(70, 17)
            Me.chkOnError.TabIndex = 87
            Me.chkOnError.Text = "On Error"
            Me.chkOnError.UseVisualStyleBackColor = True
            '
            'NotificationSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.Controls.Add(Me.chkOnNewEp)
            Me.Controls.Add(Me.chkOnMovieScraped)
            Me.Controls.Add(Me.chkOnNewMovie)
            Me.Controls.Add(Me.chkOnError)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "NotificationSettings"
            Me.PanelImage = Global.EmberMediaManger.My.Resources.Modules.small_icon_Notify
            Me.PanelOrder = 100
            Me.PanelText = "Notifications"
            Me.PanelType = "Modules"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents chkOnNewEp As System.Windows.Forms.CheckBox
        Friend WithEvents chkOnMovieScraped As System.Windows.Forms.CheckBox
        Friend WithEvents chkOnNewMovie As System.Windows.Forms.CheckBox
        Friend WithEvents chkOnError As System.Windows.Forms.CheckBox
    End Class
End Namespace