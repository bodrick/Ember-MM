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
Imports System.Threading.Tasks

Namespace Dialogs

    Public Class AddEditActor

#Region "Fields"
        Public Enum ActorType
            Movie
            TV
        End Enum
        Private tvActor As Model.TVEpActor
        Private movieActor As Model.MoviesActor
        Private isNew As Boolean = True
#End Region 'Fields

#Region "Methods"

        Public Overloads Function ShowDialog(ByVal inActor As Model.TVEpActor) As Model.TVEpActor
            '//
            ' Overload to pass data
            '\\
            tvActor = inActor
            If ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return tvActor
            Else
                Return Nothing
            End If
        End Function

        Public Overloads Function ShowDialog(ByVal inActor As Model.MoviesActor) As Model.MoviesActor
            '//
            ' Overload to pass data
            '\\
            movieActor = inActor
            If ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return movieActor
            Else
                Return Nothing
            End If
        End Function

        Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
            '//
            ' Download the pic to verify the url was entered correctly
            '\\

            Try
                If Not String.IsNullOrEmpty(txtThumb.Text) Then
                    If StringUtils.isValidURL(txtThumb.Text) Then
                        pbActLoad.Visible = True
                        Dim downloadTask As Task(Of Image) = Task.Factory.StartNew(Function() Classes.Http.DownloadImage(txtThumb.Text))
                        While Not downloadTask.IsCompleted
                            Application.DoEvents()
                            Threading.Thread.Sleep(50)
                        End While
                        pbActLoad.Visible = False
                        pbActors.Image = downloadTask.Result                        
                    Else
                        MsgBox(Languages.Specified_URL_is_not_valid, MsgBoxStyle.Exclamation, Languages.Invalid_URL)
                    End If
                Else
                    MsgBox(Languages.Please_enter_a_URL_to_verify, MsgBoxStyle.Exclamation, Languages.No_Thumb_URL_Specified)
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
            '//
            ' Get me out of here!
            '\\
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub AddEditActor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '//
            ' Fill form with data if needed
            '\\

            Try
                If (movieActor Is Nothing AndAlso tvActor.Actor Is Nothing) Or (tvActor Is Nothing AndAlso tvActor.Actor Is Nothing) Then
                    Text = Languages.New_Actor
                Else
                    Text = Languages.Edit_Actor
                    If movieActor IsNot Nothing Then
                        txtName.Text = movieActor.Actor.Name
                        txtThumb.Text = movieActor.Actor.thumb
                    ElseIf tvActor IsNot Nothing Then
                        txtName.Text = tvActor.Actor.Name
                        txtThumb.Text = tvActor.Actor.thumb
                    End If
                End If

                Activate()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
            '//
            ' Fill the MediaContainers.Person with the data
            '\\
            Try
                If movieActor.Actor IsNot Nothing Then
                    movieActor.Actor.Name = txtName.Text
                    movieActor.Actor.thumb = txtThumb.Text
                    movieActor.Role = txtRole.Text
                ElseIf tvActor.Actor IsNot Nothing Then
                    tvActor.Actor.Name = txtName.Text
                    tvActor.Actor.thumb = txtThumb.Text
                    tvActor.Role = txtRole.Text
                ElseIf (movieActor Is Nothing AndAlso tvActor.Actor Is Nothing) Then
                    tvActor.Role = txtRole.Text
                    Dim actor As New Model.Actor
                    actor.Name = txtName.Text
                    actor.thumb = txtThumb.Text
                    tvActor.Actor = actor
                ElseIf (tvActor Is Nothing AndAlso movieActor.Actor Is Nothing) Then
                    movieActor.Role = txtRole.Text
                    Dim actor As New Model.Actor
                    actor.Name = txtName.Text
                    actor.thumb = txtThumb.Text
                    movieActor.Actor = actor
                End If
                DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
            Close()
        End Sub

#End Region 'Methods

    End Class
End Namespace