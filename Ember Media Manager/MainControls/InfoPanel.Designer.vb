<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoPanel
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
        Me.pbMILoading = New System.Windows.Forms.PictureBox()
        Me.XPanderPanelList2 = New BSE.Windows.Forms.XPanderPanelList()
        Me.xppCast = New BSE.Windows.Forms.XPanderPanel()
        Me.lstActors = New System.Windows.Forms.ListBox()
        Me.pbActLoad = New System.Windows.Forms.PictureBox()
        Me.pbActors = New System.Windows.Forms.PictureBox()
        Me.xppMeta = New BSE.Windows.Forms.XPanderPanel()
        Me.txtMetaData = New System.Windows.Forms.TextBox()
        Me.XPanderPanelList1 = New BSE.Windows.Forms.XPanderPanelList()
        Me.xppMisc = New BSE.Windows.Forms.XPanderPanel()
        Me.lblDirectorHeader = New System.Windows.Forms.Label()
        Me.txtCerts = New System.Windows.Forms.TextBox()
        Me.lblDirector = New System.Windows.Forms.Label()
        Me.lblCertsHeader = New System.Windows.Forms.Label()
        Me.lblReleaseDateHeader = New System.Windows.Forms.Label()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.pnlTop250 = New System.Windows.Forms.Panel()
        Me.lblTop250 = New System.Windows.Forms.Label()
        Me.pbTop250 = New System.Windows.Forms.PictureBox()
        Me.lblReleaseDate = New System.Windows.Forms.Label()
        Me.lblIMDBHeader = New System.Windows.Forms.Label()
        Me.txtIMDBID = New System.Windows.Forms.TextBox()
        Me.lblFilePathHeader = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.xppPlotOutline = New BSE.Windows.Forms.XPanderPanel()
        Me.txtOutline = New System.Windows.Forms.TextBox()
        Me.xppPlot = New BSE.Windows.Forms.XPanderPanel()
        Me.txtPlot = New System.Windows.Forms.TextBox()
        CType(Me.pbMILoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XPanderPanelList2.SuspendLayout()
        Me.xppCast.SuspendLayout()
        CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbActors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xppMeta.SuspendLayout()
        Me.XPanderPanelList1.SuspendLayout()
        Me.xppMisc.SuspendLayout()
        Me.pnlTop250.SuspendLayout()
        CType(Me.pbTop250, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xppPlotOutline.SuspendLayout()
        Me.xppPlot.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbMILoading
        '
        Me.pbMILoading.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMILoading.Image = Global.EmberMediaManger.My.Resources.Modules.img_Loading
        Me.pbMILoading.Location = New System.Drawing.Point(477, 374)
        Me.pbMILoading.Name = "pbMILoading"
        Me.pbMILoading.Size = New System.Drawing.Size(41, 39)
        Me.pbMILoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbMILoading.TabIndex = 36
        Me.pbMILoading.TabStop = False
        Me.pbMILoading.Visible = False
        '
        'XPanderPanelList2
        '
        Me.XPanderPanelList2.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal
        Me.XPanderPanelList2.Controls.Add(Me.xppCast)
        Me.XPanderPanelList2.Controls.Add(Me.xppMeta)
        Me.XPanderPanelList2.GradientBackground = System.Drawing.Color.Empty
        Me.XPanderPanelList2.Location = New System.Drawing.Point(342, 3)
        Me.XPanderPanelList2.Name = "XPanderPanelList2"
        Me.XPanderPanelList2.PanelColors = Nothing
        Me.XPanderPanelList2.ShowExpandIcon = True
        Me.XPanderPanelList2.Size = New System.Drawing.Size(302, 280)
        Me.XPanderPanelList2.TabIndex = 43
        Me.XPanderPanelList2.Text = "XPanderPanelList2"
        '
        'xppCast
        '
        Me.xppCast.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xppCast.Controls.Add(Me.lstActors)
        Me.xppCast.Controls.Add(Me.pbActLoad)
        Me.xppCast.Controls.Add(Me.pbActors)
        Me.xppCast.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.xppCast.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppCast.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.xppCast.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.xppCast.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.xppCast.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppCast.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppCast.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppCast.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppCast.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppCast.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppCast.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.xppCast.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppCast.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppCast.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppCast.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppCast.Expand = True
        Me.xppCast.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppCast.Image = Nothing
        Me.xppCast.Name = "xppCast"
        Me.xppCast.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppCast.Size = New System.Drawing.Size(302, 255)
        Me.xppCast.TabIndex = 0
        Me.xppCast.Text = "Cast"
        Me.xppCast.ToolTipTextCloseIcon = Nothing
        Me.xppCast.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppCast.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'lstActors
        '
        Me.lstActors.BackColor = System.Drawing.Color.Gainsboro
        Me.lstActors.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstActors.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstActors.ForeColor = System.Drawing.Color.Black
        Me.lstActors.FormattingEnabled = True
        Me.lstActors.Location = New System.Drawing.Point(4, 27)
        Me.lstActors.Name = "lstActors"
        Me.lstActors.Size = New System.Drawing.Size(207, 221)
        Me.lstActors.TabIndex = 28
        Me.lstActors.TabStop = False
        '
        'pbActLoad
        '
        Me.pbActLoad.Image = Global.EmberMediaManger.My.Resources.Modules.img_Loading
        Me.pbActLoad.Location = New System.Drawing.Point(238, 108)
        Me.pbActLoad.Name = "pbActLoad"
        Me.pbActLoad.Size = New System.Drawing.Size(41, 39)
        Me.pbActLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbActLoad.TabIndex = 26
        Me.pbActLoad.TabStop = False
        Me.pbActLoad.Visible = False
        '
        'pbActors
        '
        Me.pbActors.Image = Global.EmberMediaManger.My.Resources.Modules.img_Actor_Silhouette
        Me.pbActors.Location = New System.Drawing.Point(217, 74)
        Me.pbActors.Name = "pbActors"
        Me.pbActors.Size = New System.Drawing.Size(81, 106)
        Me.pbActors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbActors.TabIndex = 27
        Me.pbActors.TabStop = False
        '
        'xppMeta
        '
        Me.xppMeta.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xppMeta.Controls.Add(Me.txtMetaData)
        Me.xppMeta.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.xppMeta.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.xppMeta.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.xppMeta.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.xppMeta.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppMeta.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppMeta.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppMeta.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMeta.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.xppMeta.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppMeta.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppMeta.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppMeta.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppMeta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppMeta.Image = Nothing
        Me.xppMeta.Name = "xppMeta"
        Me.xppMeta.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppMeta.Size = New System.Drawing.Size(302, 25)
        Me.xppMeta.TabIndex = 1
        Me.xppMeta.Text = "Meta Data"
        Me.xppMeta.ToolTipTextCloseIcon = Nothing
        Me.xppMeta.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppMeta.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'txtMetaData
        '
        Me.txtMetaData.BackColor = System.Drawing.Color.Gainsboro
        Me.txtMetaData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMetaData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMetaData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMetaData.ForeColor = System.Drawing.Color.Black
        Me.txtMetaData.Location = New System.Drawing.Point(1, 25)
        Me.txtMetaData.Multiline = True
        Me.txtMetaData.Name = "txtMetaData"
        Me.txtMetaData.ReadOnly = True
        Me.txtMetaData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMetaData.Size = New System.Drawing.Size(300, 0)
        Me.txtMetaData.TabIndex = 35
        Me.txtMetaData.TabStop = False
        '
        'XPanderPanelList1
        '
        Me.XPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal
        Me.XPanderPanelList1.Controls.Add(Me.xppMisc)
        Me.XPanderPanelList1.Controls.Add(Me.xppPlotOutline)
        Me.XPanderPanelList1.Controls.Add(Me.xppPlot)
        Me.XPanderPanelList1.GradientBackground = System.Drawing.Color.Empty
        Me.XPanderPanelList1.Location = New System.Drawing.Point(3, 3)
        Me.XPanderPanelList1.Name = "XPanderPanelList1"
        Me.XPanderPanelList1.PanelColors = Nothing
        Me.XPanderPanelList1.ShowExpandIcon = True
        Me.XPanderPanelList1.Size = New System.Drawing.Size(333, 280)
        Me.XPanderPanelList1.TabIndex = 42
        Me.XPanderPanelList1.Text = "XPanderPanelList1"
        '
        'xppMisc
        '
        Me.xppMisc.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xppMisc.Controls.Add(Me.lblDirectorHeader)
        Me.xppMisc.Controls.Add(Me.txtCerts)
        Me.xppMisc.Controls.Add(Me.lblDirector)
        Me.xppMisc.Controls.Add(Me.lblCertsHeader)
        Me.xppMisc.Controls.Add(Me.lblReleaseDateHeader)
        Me.xppMisc.Controls.Add(Me.btnPlay)
        Me.xppMisc.Controls.Add(Me.pnlTop250)
        Me.xppMisc.Controls.Add(Me.lblReleaseDate)
        Me.xppMisc.Controls.Add(Me.lblIMDBHeader)
        Me.xppMisc.Controls.Add(Me.txtIMDBID)
        Me.xppMisc.Controls.Add(Me.lblFilePathHeader)
        Me.xppMisc.Controls.Add(Me.txtFilePath)
        Me.xppMisc.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.xppMisc.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.xppMisc.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.xppMisc.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.xppMisc.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppMisc.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppMisc.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppMisc.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppMisc.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.xppMisc.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppMisc.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppMisc.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppMisc.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppMisc.Expand = True
        Me.xppMisc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppMisc.Image = Nothing
        Me.xppMisc.Name = "xppMisc"
        Me.xppMisc.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppMisc.Size = New System.Drawing.Size(333, 230)
        Me.xppMisc.TabIndex = 2
        Me.xppMisc.Text = "Miscellaneous"
        Me.xppMisc.ToolTipTextCloseIcon = Nothing
        Me.xppMisc.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppMisc.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'lblDirectorHeader
        '
        Me.lblDirectorHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDirectorHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDirectorHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirectorHeader.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblDirectorHeader.Location = New System.Drawing.Point(3, 27)
        Me.lblDirectorHeader.Name = "lblDirectorHeader"
        Me.lblDirectorHeader.Size = New System.Drawing.Size(150, 17)
        Me.lblDirectorHeader.TabIndex = 40
        Me.lblDirectorHeader.Text = "Director"
        Me.lblDirectorHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCerts
        '
        Me.txtCerts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCerts.Location = New System.Drawing.Point(118, 101)
        Me.txtCerts.Name = "txtCerts"
        Me.txtCerts.ReadOnly = True
        Me.txtCerts.Size = New System.Drawing.Size(181, 20)
        Me.txtCerts.TabIndex = 41
        Me.txtCerts.TabStop = False
        '
        'lblDirector
        '
        Me.lblDirector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirector.ForeColor = System.Drawing.Color.Black
        Me.lblDirector.Location = New System.Drawing.Point(5, 47)
        Me.lblDirector.Name = "lblDirector"
        Me.lblDirector.Size = New System.Drawing.Size(142, 16)
        Me.lblDirector.TabIndex = 41
        Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCertsHeader
        '
        Me.lblCertsHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCertsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCertsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCertsHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertsHeader.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblCertsHeader.Location = New System.Drawing.Point(118, 81)
        Me.lblCertsHeader.Name = "lblCertsHeader"
        Me.lblCertsHeader.Size = New System.Drawing.Size(181, 17)
        Me.lblCertsHeader.TabIndex = 40
        Me.lblCertsHeader.Text = "Certifications"
        Me.lblCertsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReleaseDateHeader
        '
        Me.lblReleaseDateHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReleaseDateHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblReleaseDateHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReleaseDateHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleaseDateHeader.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblReleaseDateHeader.Location = New System.Drawing.Point(160, 28)
        Me.lblReleaseDateHeader.Name = "lblReleaseDateHeader"
        Me.lblReleaseDateHeader.Size = New System.Drawing.Size(105, 17)
        Me.lblReleaseDateHeader.TabIndex = 42
        Me.lblReleaseDateHeader.Text = "Release Date"
        Me.lblReleaseDateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnPlay
        '
        Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlay.Image = Global.EmberMediaManger.My.Resources.Modules.btn_Play
        Me.btnPlay.Location = New System.Drawing.Point(280, 147)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(20, 20)
        Me.btnPlay.TabIndex = 32
        Me.btnPlay.TabStop = False
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'pnlTop250
        '
        Me.pnlTop250.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTop250.Controls.Add(Me.lblTop250)
        Me.pnlTop250.Controls.Add(Me.pbTop250)
        Me.pnlTop250.Location = New System.Drawing.Point(271, 28)
        Me.pnlTop250.Name = "pnlTop250"
        Me.pnlTop250.Size = New System.Drawing.Size(56, 48)
        Me.pnlTop250.TabIndex = 15
        '
        'lblTop250
        '
        Me.lblTop250.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTop250.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTop250.ForeColor = System.Drawing.Color.Black
        Me.lblTop250.Location = New System.Drawing.Point(1, 30)
        Me.lblTop250.Name = "lblTop250"
        Me.lblTop250.Size = New System.Drawing.Size(52, 17)
        Me.lblTop250.TabIndex = 15
        Me.lblTop250.Text = "# 250"
        Me.lblTop250.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbTop250
        '
        Me.pbTop250.Image = Global.EmberMediaManger.My.Resources.Modules.img_Top250
        Me.pbTop250.Location = New System.Drawing.Point(1, 1)
        Me.pbTop250.Name = "pbTop250"
        Me.pbTop250.Size = New System.Drawing.Size(54, 30)
        Me.pbTop250.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTop250.TabIndex = 14
        Me.pbTop250.TabStop = False
        '
        'lblReleaseDate
        '
        Me.lblReleaseDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReleaseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleaseDate.ForeColor = System.Drawing.Color.Black
        Me.lblReleaseDate.Location = New System.Drawing.Point(162, 49)
        Me.lblReleaseDate.Name = "lblReleaseDate"
        Me.lblReleaseDate.Size = New System.Drawing.Size(105, 16)
        Me.lblReleaseDate.TabIndex = 43
        Me.lblReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIMDBHeader
        '
        Me.lblIMDBHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIMDBHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIMDBHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMDBHeader.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblIMDBHeader.Location = New System.Drawing.Point(4, 81)
        Me.lblIMDBHeader.Name = "lblIMDBHeader"
        Me.lblIMDBHeader.Size = New System.Drawing.Size(108, 17)
        Me.lblIMDBHeader.TabIndex = 28
        Me.lblIMDBHeader.Text = "IMDB ID"
        Me.lblIMDBHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIMDBID
        '
        Me.txtIMDBID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIMDBID.Location = New System.Drawing.Point(4, 101)
        Me.txtIMDBID.Name = "txtIMDBID"
        Me.txtIMDBID.ReadOnly = True
        Me.txtIMDBID.Size = New System.Drawing.Size(108, 20)
        Me.txtIMDBID.TabIndex = 29
        Me.txtIMDBID.TabStop = False
        '
        'lblFilePathHeader
        '
        Me.lblFilePathHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFilePathHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFilePathHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFilePathHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilePathHeader.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblFilePathHeader.Location = New System.Drawing.Point(4, 127)
        Me.lblFilePathHeader.Name = "lblFilePathHeader"
        Me.lblFilePathHeader.Size = New System.Drawing.Size(295, 17)
        Me.lblFilePathHeader.TabIndex = 30
        Me.lblFilePathHeader.Text = "File Path"
        Me.lblFilePathHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFilePath
        '
        Me.txtFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilePath.Location = New System.Drawing.Point(4, 147)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(273, 20)
        Me.txtFilePath.TabIndex = 31
        Me.txtFilePath.TabStop = False
        '
        'xppPlotOutline
        '
        Me.xppPlotOutline.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xppPlotOutline.Controls.Add(Me.txtOutline)
        Me.xppPlotOutline.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.xppPlotOutline.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.xppPlotOutline.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.xppPlotOutline.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.xppPlotOutline.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppPlotOutline.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppPlotOutline.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppPlotOutline.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlotOutline.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.xppPlotOutline.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppPlotOutline.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppPlotOutline.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppPlotOutline.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppPlotOutline.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppPlotOutline.Image = Nothing
        Me.xppPlotOutline.Name = "xppPlotOutline"
        Me.xppPlotOutline.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppPlotOutline.Size = New System.Drawing.Size(333, 25)
        Me.xppPlotOutline.TabIndex = 1
        Me.xppPlotOutline.Text = "Plot Outline"
        Me.xppPlotOutline.ToolTipTextCloseIcon = Nothing
        Me.xppPlotOutline.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppPlotOutline.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'txtOutline
        '
        Me.txtOutline.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOutline.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutline.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutline.ForeColor = System.Drawing.Color.Black
        Me.txtOutline.Location = New System.Drawing.Point(1, 25)
        Me.txtOutline.Multiline = True
        Me.txtOutline.Name = "txtOutline"
        Me.txtOutline.ReadOnly = True
        Me.txtOutline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutline.Size = New System.Drawing.Size(331, 0)
        Me.txtOutline.TabIndex = 17
        Me.txtOutline.TabStop = False
        '
        'xppPlot
        '
        Me.xppPlot.CaptionFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xppPlot.Controls.Add(Me.txtPlot)
        Me.xppPlot.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.xppPlot.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.xppPlot.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.xppPlot.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.xppPlot.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.xppPlot.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.xppPlot.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.xppPlot.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xppPlot.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.xppPlot.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.xppPlot.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.xppPlot.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.xppPlot.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.xppPlot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xppPlot.Image = Nothing
        Me.xppPlot.Name = "xppPlot"
        Me.xppPlot.PanelStyle = BSE.Windows.Forms.PanelStyle.[Default]
        Me.xppPlot.Size = New System.Drawing.Size(333, 25)
        Me.xppPlot.TabIndex = 3
        Me.xppPlot.Text = "Plot"
        Me.xppPlot.ToolTipTextCloseIcon = Nothing
        Me.xppPlot.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.xppPlot.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'txtPlot
        '
        Me.txtPlot.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlot.ForeColor = System.Drawing.Color.Black
        Me.txtPlot.Location = New System.Drawing.Point(1, 25)
        Me.txtPlot.Multiline = True
        Me.txtPlot.Name = "txtPlot"
        Me.txtPlot.ReadOnly = True
        Me.txtPlot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlot.Size = New System.Drawing.Size(331, 0)
        Me.txtPlot.TabIndex = 7
        Me.txtPlot.TabStop = False
        '
        'InfoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.XPanderPanelList2)
        Me.Controls.Add(Me.XPanderPanelList1)
        Me.Controls.Add(Me.pbMILoading)
        Me.Name = "InfoPanel"
        Me.Size = New System.Drawing.Size(646, 287)
        CType(Me.pbMILoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XPanderPanelList2.ResumeLayout(False)
        Me.xppCast.ResumeLayout(False)
        CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbActors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xppMeta.ResumeLayout(False)
        Me.xppMeta.PerformLayout()
        Me.XPanderPanelList1.ResumeLayout(False)
        Me.xppMisc.ResumeLayout(False)
        Me.xppMisc.PerformLayout()
        Me.pnlTop250.ResumeLayout(False)
        CType(Me.pbTop250, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xppPlotOutline.ResumeLayout(False)
        Me.xppPlotOutline.PerformLayout()
        Me.xppPlot.ResumeLayout(False)
        Me.xppPlot.PerformLayout()
        Me.ResumeLayout(False)

End Sub

    Friend WithEvents txtCerts As System.Windows.Forms.TextBox
    Friend WithEvents lblCertsHeader As System.Windows.Forms.Label
    Friend WithEvents pbMILoading As System.Windows.Forms.PictureBox
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents lblFilePathHeader As System.Windows.Forms.Label
    Friend WithEvents txtIMDBID As System.Windows.Forms.TextBox
    Friend WithEvents lblIMDBHeader As System.Windows.Forms.Label
    Friend WithEvents pbActLoad As System.Windows.Forms.PictureBox
    Friend WithEvents lstActors As System.Windows.Forms.ListBox
    Friend WithEvents pbActors As System.Windows.Forms.PictureBox
    Friend WithEvents pnlTop250 As System.Windows.Forms.Panel
    Friend WithEvents lblTop250 As System.Windows.Forms.Label
    Friend WithEvents pbTop250 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlot As System.Windows.Forms.TextBox
    Friend WithEvents XPanderPanelList1 As BSE.Windows.Forms.XPanderPanelList
    Friend WithEvents xppPlotOutline As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents txtOutline As System.Windows.Forms.TextBox
    Friend WithEvents xppMisc As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents xppPlot As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents lblDirectorHeader As System.Windows.Forms.Label
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents lblReleaseDateHeader As System.Windows.Forms.Label
    Friend WithEvents lblReleaseDate As System.Windows.Forms.Label
    Friend WithEvents XPanderPanelList2 As BSE.Windows.Forms.XPanderPanelList
    Friend WithEvents xppCast As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents xppMeta As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents txtMetaData As System.Windows.Forms.TextBox

End Class
