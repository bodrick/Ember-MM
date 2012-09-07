Namespace Dialogs
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AddEditActor
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEditActor))
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.OK_Button = New System.Windows.Forms.Button()
            Me.Cancel_Button = New System.Windows.Forms.Button()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.txtRole = New System.Windows.Forms.TextBox()
            Me.txtThumb = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.lblRole = New System.Windows.Forms.Label()
            Me.lblThumb = New System.Windows.Forms.Label()
            Me.pbActLoad = New System.Windows.Forms.PictureBox()
            Me.pbActors = New System.Windows.Forms.PictureBox()
            Me.btnVerify = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pbActors, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'OK_Button
            '
            resources.ApplyResources(Me.OK_Button, "OK_Button")
            Me.OK_Button.Name = "OK_Button"
            '
            'Cancel_Button
            '
            resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
            Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Cancel_Button.Name = "Cancel_Button"
            '
            'txtName
            '
            resources.ApplyResources(Me.txtName, "txtName")
            Me.txtName.Name = "txtName"
            '
            'txtRole
            '
            resources.ApplyResources(Me.txtRole, "txtRole")
            Me.txtRole.Name = "txtRole"
            '
            'txtThumb
            '
            resources.ApplyResources(Me.txtThumb, "txtThumb")
            Me.txtThumb.Name = "txtThumb"
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'lblRole
            '
            resources.ApplyResources(Me.lblRole, "lblRole")
            Me.lblRole.Name = "lblRole"
            '
            'lblThumb
            '
            resources.ApplyResources(Me.lblThumb, "lblThumb")
            Me.lblThumb.Name = "lblThumb"
            '
            'pbActLoad
            '
            Me.pbActLoad.Image = Global.EmberMediaManger.My.Resources.Modules.img_Loading
            resources.ApplyResources(Me.pbActLoad, "pbActLoad")
            Me.pbActLoad.Name = "pbActLoad"
            Me.pbActLoad.TabStop = False
            '
            'pbActors
            '
            Me.pbActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            resources.ApplyResources(Me.pbActors, "pbActors")
            Me.pbActors.Name = "pbActors"
            Me.pbActors.TabStop = False
            '
            'btnVerify
            '
            resources.ApplyResources(Me.btnVerify, "btnVerify")
            Me.btnVerify.Name = "btnVerify"
            Me.btnVerify.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.btnVerify)
            Me.Panel1.Controls.Add(Me.pbActLoad)
            Me.Panel1.Controls.Add(Me.pbActors)
            Me.Panel1.Controls.Add(Me.lblThumb)
            Me.Panel1.Controls.Add(Me.lblRole)
            Me.Panel1.Controls.Add(Me.lblName)
            Me.Panel1.Controls.Add(Me.txtThumb)
            Me.Panel1.Controls.Add(Me.txtRole)
            Me.Panel1.Controls.Add(Me.txtName)
            resources.ApplyResources(Me.Panel1, "Panel1")
            Me.Panel1.Name = "Panel1"
            '
            'AddEditActor
            '
            Me.AcceptButton = Me.OK_Button
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.CancelButton = Me.Cancel_Button
            Me.ControlBox = False
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AddEditActor"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TableLayoutPanel1.ResumeLayout(False)
            CType(Me.pbActLoad, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pbActors, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents OK_Button As System.Windows.Forms.Button
        Friend WithEvents Cancel_Button As System.Windows.Forms.Button
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtRole As System.Windows.Forms.TextBox
        Friend WithEvents txtThumb As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblRole As System.Windows.Forms.Label
        Friend WithEvents lblThumb As System.Windows.Forms.Label
        Friend WithEvents pbActLoad As System.Windows.Forms.PictureBox
        Friend WithEvents pbActors As System.Windows.Forms.PictureBox
        Friend WithEvents btnVerify As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel

    End Class
End Namespace