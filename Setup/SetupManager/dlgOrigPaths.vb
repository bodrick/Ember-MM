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

Public Class dlgOrigPaths

    #Region "Methods"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using ed As New dlgEditOrigPath
            If ed.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim i As New frmMainManager.OrigPaths
                i.platform = ed.cbPlatform.Text
                i.origpath = ed.orig
                i.emberpath = ed.ember
                i.recursive = ed.recurse
                frmMainManager.OPaths.Add(i)
                frmMainManager.MasterDB.DBAddChangeOirgPaths(i)
                FillPaths()
            End If

        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            frmMainManager.MasterDB.DBDeleteOirgPaths(ListView1.SelectedItems(0).SubItems(1).Text, ListView1.SelectedItems(0).Text)
            frmMainManager.LoadOPaths()
            FillPaths()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Using ed As New dlgEditOrigPath
            For Each i As frmMainManager.OrigPaths In frmMainManager.OPaths
                If i.origpath = ListView1.SelectedItems(0).SubItems(1).Text AndAlso i.platform = ListView1.SelectedItems(0).Text Then
                    ed.cbPlatform.Text = i.platform
                    ed.TextBox1.Text = i.origpath
                    ed.TextBox2.Text = i.emberpath
                    ed.CheckBox1.Checked = i.recursive
                    If ed.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        i.platform = ed.cbPlatform.Text
                        i.origpath = ed.orig
                        i.emberpath = ed.ember
                        i.recursive = ed.recurse
                        frmMainManager.MasterDB.DBAddChangeOirgPaths(i)
                        FillPaths()
                    End If
                    Exit For
                End If
            Next
        End Using
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgOrigPaths_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPaths()
    End Sub

    Sub FillPaths()
        ListView1.Items.Clear()
        Dim i As ListViewItem
        For Each p As frmMainManager.OrigPaths In frmMainManager.OPaths
            i = New ListViewItem
            i.Name = p.origpath
            i.Text = p.platform
            i.SubItems.Add(p.origpath)
            i.SubItems.Add(p.emberpath)
            If p.recursive Then
                i.SubItems.Add("Yes")
            Else
                i.SubItems.Add("No")
            End If
            ListView1.Items.Add(i)
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Button2.Enabled = True
            Button3.Enabled = True
        Else
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    #End Region 'Methods

End Class