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
Imports EmberMediaManger.API

Namespace Modules.XBMC

    Public Class XBMCSettings

#Region "Fields"

        Public XComs As New List(Of XBMCxCom.XBMCCom)        
#End Region 'Fields

#Region "Methods"
        Public Sub LoadXComs()
            lbXBMCCom.Items.Clear()
            cbPlayCountHost.Items.Clear()
            For Each x As XBMCxCom.XBMCCom In XComs
                lbXBMCCom.Items.Add(x.Name)
                cbPlayCountHost.Items.Add(x.Name)
            Next
            cbPlayCountHost.SelectedIndex = cbPlayCountHost.FindStringExact(AdvancedSettings.GetSetting("XBMCSyncPlayCountHost", ""))
        End Sub

        Private Sub btnAddCom_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddCom.Click
            Using dlg As New dlgXBMCHost
                dlg.XComs = XComs
                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    XComs = dlg.XComs                    
                    LoadXComs()
                End If
            End Using
        End Sub

        Private Sub btnEditCom_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEditCom.Click            
            If lbXBMCCom.SelectedItems.Count > 0 Then
                Using dlg As New dlgXBMCHost
                    dlg.XComs = XComs
                    dlg.hostid = lbXBMCCom.SelectedItem.ToString
                    If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        XComs = dlg.XComs                        
                        LoadXComs()
                    End If
                    btnEditCom.Enabled = False
                End Using
            End If
        End Sub

        Private Sub lbXBMCCom_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles lbXBMCCom.KeyDown
            If e.KeyCode = Keys.Delete Then RemoveXCom()
        End Sub

        Private Sub lbXBMCCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lbXBMCCom.SelectedIndexChanged
            Try
                If lbXBMCCom.SelectedItems.Count > 0 Then
                    btnEditCom.Enabled = True
                Else
                    btnEditCom.Enabled = False
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub RemoveXCom()
            If lbXBMCCom.SelectedItems.Count > 0 Then
                XComs.Remove(XComs.FirstOrDefault(Function(y) y.Name = lbXBMCCom.SelectedItem.ToString))
                LoadXComs()
                OnControlValueChanged(Nothing, New ControlValueChangedArgs(False))
            End If
        End Sub

        Private Sub btnRemoveCom_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveCom.Click
            RemoveXCom()
        End Sub

        Private Sub chkPlayCount_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkPlayCount.CheckedChanged
            cbPlayCountHost.Enabled = chkPlayCount.Checked            
        End Sub        

#End Region 'Methods

        Protected Overrides Sub LoadSettings()
            chkRealTime.Checked = AdvancedSettings.GetBooleanSetting("XBMCSync", False)
            chkPlayCount.Checked = AdvancedSettings.GetBooleanSetting("XBMCSyncPlayCount", False)
            chkNotification.Checked = AdvancedSettings.GetBooleanSetting("XBMCNotifications", False)
            LoadXComs()
        End Sub

        Public Overrides Sub SaveSettings()
            AdvancedSettings.SetBooleanSetting("XBMCSyncPlayCount", chkPlayCount.Checked)
            AdvancedSettings.SetBooleanSetting("XBMCSync", chkRealTime.Checked)
            AdvancedSettings.SetBooleanSetting("XBMCNotifications", chkNotification.Checked)
        End Sub

        Protected Overrides Sub LoadResources()
            gbXBMCCommunication.Text = Languages.XBMC_Communication
            btnEditCom.Text = Languages.Edit
            btnAddCom.Text = Languages.Add
            btnRemoveCom.Text = Languages.Remove_Selected
            chkRealTime.Text = Languages.Enable_Real_Time_synchronization
            chkNotification.Text = Languages.Send_Notifications                        
        End Sub
    End Class
End Namespace