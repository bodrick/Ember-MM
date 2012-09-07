' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################
Imports System
Imports EmberControls
Imports EmberMediaManger.API

Namespace Dialogs

    Public Class Settings

#Region "Fields"

        Private currText As String = "Options"
        Private dHelp As New Dictionary(Of String, String)
        Private didApply As Boolean = False
        Private NoUpdate As Boolean = True
        Private sResult As New Structures.SettingsResult
        Public Event LoadEnd()

#End Region 'Fields

#Region "Methods"

        Public Overloads Function ShowDialog() As Structures.SettingsResult
            MyBase.ShowDialog()
            Return sResult
        End Function

        Private Sub AddHelpHandlers(ByVal Parent As Control, ByVal Prefix As String)
            Dim pfName As String = String.Empty

            For Each ctrl As Control In Parent.Controls
                If Not TypeOf ctrl Is GroupBox AndAlso Not TypeOf ctrl Is Panel AndAlso Not TypeOf ctrl Is Label AndAlso _
                   Not TypeOf ctrl Is TreeView AndAlso Not TypeOf ctrl Is ToolStrip AndAlso Not TypeOf ctrl Is PictureBox AndAlso _
                   Not TypeOf ctrl Is TabControl Then
                    pfName = String.Concat(Prefix, ctrl.Name)
                    ctrl.AccessibleDescription = pfName
                    If dHelp.ContainsKey(pfName) Then
                        dHelp.Item(pfName) = Master.eLang.GetHelpString(pfName)
                    Else
                        AddHandler ctrl.MouseEnter, AddressOf HelpMouseEnter
                        AddHandler ctrl.MouseLeave, AddressOf HelpMouseLeave
                        dHelp.Add(pfName, Master.eLang.GetHelpString(pfName))
                    End If
                End If
                If ctrl.HasChildren Then
                    AddHelpHandlers(ctrl, Prefix)
                End If
            Next
        End Sub

        Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
            Try
                SaveSettings(True)
                If Not NoUpdate Then btnApply.Enabled = False
                If sResult.NeedsUpdate OrElse sResult.NeedsRefresh Then didApply = True
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            If Not didApply Then sResult.DidCancel = True
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            NoUpdate = True
            SaveSettings(False)
            Close()
        End Sub

        Private Sub SettingsChanged(ByVal e As ManagedPanel.ControlValueChangedArgs)
            If e.NeedsUpdate Then
                sResult.NeedsRefresh = True
            End If
            If Not NoUpdate Then btnApply.Enabled = True
        End Sub

        Private Sub dlgSettings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
            Activate()
        End Sub

        Private Sub FillList(ByVal sType As String)
            Dim pNode As New TreeNode
            Dim cNode As TreeNode

            tvSettings.Nodes.Clear()
            Dim settingPanels = EmberControls.Functions.GetAllControls(Of ManagedPanel)(Me).OfType(Of ManagedPanel)().ToList()
            For Each pPanel As ManagedPanel In settingPanels.Where(Function(s) s.PanelType = sType AndAlso String.IsNullOrEmpty(s.ParentName)).OrderBy(Function(s) s.PanelOrder)
                pNode = New TreeNode(pPanel.PanelText, ilPanelImages.Images.IndexOfKey(pPanel.Name), ilPanelImages.Images.IndexOfKey(pPanel.Name))
                pNode.Name = pPanel.Name
                For Each cPanel As ManagedPanel In settingPanels.Where(Function(p) p.PanelType = sType AndAlso p.ParentName = pNode.Name).OrderBy(Function(s) s.PanelOrder)
                    cNode = New TreeNode(cPanel.PanelText, ilPanelImages.Images.IndexOfKey(cPanel.Name), ilPanelImages.Images.IndexOfKey(cPanel.Name))
                    cNode.Name = cPanel.Name
                    pNode.Nodes.Add(cNode)
                Next
                tvSettings.Nodes.Add(pNode)
            Next

            If tvSettings.Nodes.Count > 0 Then
                tvSettings.ExpandAll()
                tvSettings.SelectedNode = tvSettings.Nodes(0)
            Else
                pbCurrent.Image = Nothing
                lblCurrent.Text = String.Empty
            End If
        End Sub

        Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Text = Languages.Settings
                btnOK.Text = Languages.OK
                btnApply.Text = Languages.Apply
                btnCancel.Text = Languages.Cancel
                Label2.Text = Languages.Configure_Ember_appearance_and_operation
                Label4.Text = Text
                gbHelp.Text = String.Concat("     ", Languages.Help)
                Dim settingPanels = EmberControls.Functions.GetAllControls(Of ManagedPanel)(Me).OfType(Of ManagedPanel)()
                For Each pnl In settingPanels
                    If pnl.PanelImage IsNot Nothing Then
                        ilPanelImages.Images.Add(pnl.Name, pnl.PanelImage)
                    End If
                Next
                AddHelpHandlers(Me, "Core_")

                Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
                Using g As Graphics = Graphics.FromImage(iBackground)
                    g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
                    pnlTop.BackgroundImage = iBackground
                End Using

                iBackground = New Bitmap(pnlCurrent.Width, pnlCurrent.Height)
                Using b As Graphics = Graphics.FromImage(iBackground)
                    b.FillRectangle(New Drawing2D.LinearGradientBrush(pnlCurrent.ClientRectangle, Color.SteelBlue, Color.FromKnownColor(KnownColor.Control), Drawing2D.LinearGradientMode.Horizontal), pnlCurrent.ClientRectangle)
                    pnlCurrent.BackgroundImage = iBackground
                End Using

                sResult.NeedsUpdate = False
                sResult.NeedsRefresh = False
                sResult.DidCancel = False
                didApply = False
                NoUpdate = False
                FillList(pnlGeneral.PanelType)
                SelectPanel(pnlGeneral)
                RaiseEvent LoadEnd()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub HelpMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
            lblHelp.Text = dHelp.Item(DirectCast(sender, Control).AccessibleDescription)
        End Sub

        Private Sub HelpMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
            lblHelp.Text = String.Empty
        End Sub

        Private Sub RefreshHelpStrings(ByVal Language As String)
            For Each sKey As String In dHelp.Keys
                dHelp.Item(sKey) = Master.eLang.GetHelpString(sKey)
            Next
        End Sub

        Private Sub SaveSettings(ByVal isApply As Boolean)
            Try
                Dim settingPanels = EmberControls.Functions.GetAllControls(Of ManagedPanel)(Me).OfType(Of ManagedPanel)()
                For Each pnl In settingPanels.Where(Function(s) s.Loaded = True)
                    pnl.SaveSettings()
                Next
                Master.eSettings.Save()
                API.Functions.CreateDefaultOptions()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbModules.Click, tsbTVhows.Click, tsbMovies.Click, tsbOptions.Click, tsbMiscellaneous.Click
            currText = DirectCast(sender, ToolStripButton).Text
            FillList(currText)
        End Sub

        Private Sub tvSettings_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSettings.AfterSelect
            Dim settingsPanel = EmberControls.Functions.GetAllControls(Of ManagedPanel)(Me).OfType(Of ManagedPanel)().FirstOrDefault(Function(f) f.Name = tvSettings.SelectedNode.Name)
            SelectPanel(settingsPanel)
        End Sub

        Private Sub SelectPanel(pnl As ManagedPanel)
            pbCurrent.Image = ilPanelImages.Images(tvSettings.SelectedNode.ImageIndex)
            lblCurrent.Text = String.Format("{0} - {1}", currText, tvSettings.SelectedNode.Text)
            If Not pnl.Loaded Then
                AddHandler pnl.ControlValueChanged, AddressOf SettingsChanged
                pnl.Setup()
            End If
            SettingsPanelManager.SelectedPanel = pnl
        End Sub

#End Region 'Methods
    End Class
End Namespace