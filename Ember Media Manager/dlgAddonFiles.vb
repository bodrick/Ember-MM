Imports EmberAPI

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

Public Class dlgAddonFiles

    Public Overloads Function ShowDialog(ByVal FileList As Generic.SortedList(Of String, String)) As DialogResult

        Dim lvItem As New ListViewItem
        For Each _file As KeyValuePair(Of String, String) In FileList
            Try
                lvItem = lvFiles.Items.Add(_file.Key)
                lvItem.SubItems.Add(_file.Value)
            Catch
            End Try
        Next

        Return MyBase.ShowDialog
    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub dlgAddonFiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetUp()
    End Sub

    Private Sub SetUp()
        Me.Text = Master.eLang.GetString(280, "Addon Files")

        Me.lvFiles.Columns(0).Text = Master.eLang.GetString(444, "File")
        Me.lvFiles.Columns(1).Text = Master.eLang.GetString(821, "Description")

        Me.Cancel_Button.Text = Master.eLang.GetString(19, "Close")
    End Sub
End Class
