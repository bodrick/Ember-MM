Imports EmberControls

Namespace SettingsControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ScraperSettings
        Inherits EmberControls.ManagedPanel

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
            Me.components = New System.ComponentModel.Container()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ScraperSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.MainInfoSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.cmbScraperSelected = New System.Windows.Forms.ComboBox()
            Me.pnlSettings = New System.Windows.Forms.FlowLayoutPanel()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.lblScraperDate = New System.Windows.Forms.Label()
            Me.lblScraperContent = New System.Windows.Forms.Label()
            Me.lblScraperFramework = New System.Windows.Forms.Label()
            Me.lblScraperName = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            CType(Me.ScraperSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainInfoSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(8, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(45, 13)
            Me.Label1.TabIndex = 102
            Me.Label1.Text = "Scraper"
            '
            'ScraperSource
            '
            Me.ScraperSource.DataMember = "Movies"
            Me.ScraperSource.DataSource = Me.MainInfoSource
            '
            'MainInfoSource
            '
            Me.MainInfoSource.DataSource = GetType(TechNuts.ScraperXML.ScraperManager)
            '
            'cmbScraperSelected
            '
            Me.cmbScraperSelected.DataSource = Me.ScraperSource
            Me.cmbScraperSelected.DisplayMember = "ScraperName"
            Me.cmbScraperSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbScraperSelected.FormattingEnabled = True
            Me.cmbScraperSelected.Location = New System.Drawing.Point(59, 10)
            Me.cmbScraperSelected.Name = "cmbScraperSelected"
            Me.cmbScraperSelected.Size = New System.Drawing.Size(181, 21)
            Me.cmbScraperSelected.TabIndex = 113
            Me.cmbScraperSelected.ValueMember = "FileName"
            '
            'pnlSettings
            '
            Me.pnlSettings.AutoScroll = True
            Me.pnlSettings.Location = New System.Drawing.Point(5, 84)
            Me.pnlSettings.Name = "pnlSettings"
            Me.pnlSettings.Size = New System.Drawing.Size(643, 318)
            Me.pnlSettings.TabIndex = 114
            Me.pnlSettings.WrapContents = False
            '
            'label5
            '
            Me.label5.Location = New System.Drawing.Point(366, 56)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(75, 13)
            Me.label5.TabIndex = 124
            Me.label5.Text = "Label7"
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label6.Location = New System.Drawing.Point(366, 41)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(118, 13)
            Me.label6.TabIndex = 123
            Me.label6.Text = "Scraper Language"
            '
            'lblScraperDate
            '
            Me.lblScraperDate.Location = New System.Drawing.Point(256, 56)
            Me.lblScraperDate.Name = "lblScraperDate"
            Me.lblScraperDate.Size = New System.Drawing.Size(79, 13)
            Me.lblScraperDate.TabIndex = 122
            Me.lblScraperDate.Text = "Label8"
            '
            'lblScraperContent
            '
            Me.lblScraperContent.Location = New System.Drawing.Point(502, 56)
            Me.lblScraperContent.Name = "lblScraperContent"
            Me.lblScraperContent.Size = New System.Drawing.Size(101, 13)
            Me.lblScraperContent.TabIndex = 121
            Me.lblScraperContent.Text = "Label7"
            '
            'lblScraperFramework
            '
            Me.lblScraperFramework.Location = New System.Drawing.Point(126, 56)
            Me.lblScraperFramework.Name = "lblScraperFramework"
            Me.lblScraperFramework.Size = New System.Drawing.Size(106, 13)
            Me.lblScraperFramework.TabIndex = 120
            Me.lblScraperFramework.Text = "Label6"
            '
            'lblScraperName
            '
            Me.lblScraperName.Location = New System.Drawing.Point(5, 56)
            Me.lblScraperName.Name = "lblScraperName"
            Me.lblScraperName.Size = New System.Drawing.Size(115, 13)
            Me.lblScraperName.TabIndex = 119
            Me.lblScraperName.Text = "Label5"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(256, 41)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(177, 13)
            Me.Label4.TabIndex = 118
            Me.Label4.Text = "Scraper Date"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(502, 41)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(177, 13)
            Me.Label3.TabIndex = 117
            Me.Label3.Text = "Scraper Content"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(126, 41)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(124, 13)
            Me.Label2.TabIndex = 116
            Me.Label2.Text = "Scraper Framework"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(5, 41)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(115, 13)
            Me.Label7.TabIndex = 115
            Me.Label7.Text = "Scraper Name"
            '
            'ScraperSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.label5)
            Me.Controls.Add(Me.label6)
            Me.Controls.Add(Me.lblScraperDate)
            Me.Controls.Add(Me.lblScraperContent)
            Me.Controls.Add(Me.lblScraperFramework)
            Me.Controls.Add(Me.lblScraperName)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.pnlSettings)
            Me.Controls.Add(Me.cmbScraperSelected)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "ScraperSettings"
            Me.PanelOrder = 110
            Me.PanelText = "Scraper"
            Me.PanelType = "Movies"
            Me.Size = New System.Drawing.Size(652, 405)
            CType(Me.ScraperSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainInfoSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Private WithEvents ScraperSource As System.Windows.Forms.BindingSource
        Private WithEvents MainInfoSource As System.Windows.Forms.BindingSource
        Friend WithEvents cmbScraperSelected As System.Windows.Forms.ComboBox
        Private WithEvents pnlSettings As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents label5 As System.Windows.Forms.Label
        Friend WithEvents label6 As System.Windows.Forms.Label
        Friend WithEvents lblScraperDate As System.Windows.Forms.Label
        Friend WithEvents lblScraperContent As System.Windows.Forms.Label
        Friend WithEvents lblScraperFramework As System.Windows.Forms.Label
        Friend WithEvents lblScraperName As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label

    End Class
End Namespace