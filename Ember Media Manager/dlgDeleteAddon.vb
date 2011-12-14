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

Imports System.Text.RegularExpressions
Imports EmberAPI

Public Class dlgDeleteAddon

    Private _id As Integer = -1

    Public Overloads Function ShowDialog(ByVal ID As Integer) As System.Windows.Forms.DialogResult
        Me._id = ID

        Return MyBase.ShowDialog
    End Function

    Function GetStatus(ByVal status As String) As String
        Dim regStat As Match = Regex.Match(status, "\<status\>(?<status>.*?)\<\/status\>", RegexOptions.IgnoreCase)
        If regStat.Success Then
            Dim tStatus As String = regStat.Groups("status").Value
            If Not String.IsNullOrEmpty(tStatus) Then
                Return tStatus
            End If
        End If
        Return String.Empty
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim sHTTP As New HTTP
        Dim postData As New List(Of String())
        postData.Add((New String() {"username", Me.txtUsername.Text}))
        postData.Add((New String() {"password", Me.txtPassword.Text}))
        postData.Add((New String() {"id", Me._id.ToString}))
        postData.Add((New String() {"func", "delete"}))

        Dim Result As String = sHTTP.PostDownloadData("http://www.embermm.com/addons/addons.php", postData)
        sHTTP = Nothing

        If Not String.IsNullOrEmpty(Result) AndAlso Me.GetStatus(Result) = "OK" Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgDeleteAddon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetUp()
    End Sub

    Private Sub SetUp()
        Me.Text = Master.eLang.GetString(295, "Delete Addon")

        Me.lblConfirm.Text = Master.eLang.GetString(296, "In order to continue with deletion, you need to confirm you are the owner of the Addon.")
        Me.lblLogin.Text = Master.eLang.GetString(297, "Confirm Ownership")
        Me.lblUsername.Text = Master.eLang.GetString(425, "Username:")
        Me.lblPassword.Text = Master.eLang.GetString(426, "Password:")

        Me.OK_Button.Text = Master.eLang.GetString(179, "OK")
        Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
    End Sub
End Class
