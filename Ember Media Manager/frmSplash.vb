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

Public NotInheritable Class frmSplash

#Region "Delegates"

    Delegate Sub DelegateToCloseForm()

#End Region 'Delegates

#Region "Methods"

    ' if the splash form, is closed by the main form, it is cross-thread
    ' operation. so we need to use the Invoke method to deal with it.
    Public Sub CloseForm()
        If (Me.InvokeRequired) Then
            Me.Invoke(New DelegateToCloseForm(AddressOf CloseForm))
        Else
            Me.Close()
        End If
    End Sub

    Public Sub SetStage(ByVal txt As String)
        Me.txtStage.Text = txt
        Me.pbLoading.Value += 1
        Application.DoEvents()
    End Sub

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PictureBox1.Location = New Point(4, 4)
        Me.PictureBox1.Size = New Size(Me.Width - 10, Me.Height - 10)
        Version.Text = String.Format("Version {0}.{1}", Master.MajorVersion.ToString, My.Application.Info.Version.Revision)
    End Sub

#End Region 'Methods

End Class