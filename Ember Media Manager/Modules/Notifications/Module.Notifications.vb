Imports EmberMediaManger.API

Namespace Modules.Notifications

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

    Public Class NotificationsModule


#Region "Fields"

        Private dNotify As frmNotify

#End Region 'Fields

#Region "Events"

#End Region 'Events

#Region "Properties"

#End Region 'Properties

#Region "Methods"

        Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object) As Interfaces.ModuleResult
            Try
                If mType = Enums.ModuleEventType.Notification Then
                    Dim ShowIt As Boolean = False
                    Select Case True
                        Case _params(0).ToString = "error" AndAlso AdvancedSettings.GetBooleanSetting("NotifyOnError", True)
                            ShowIt = True
                        Case _params(0).ToString = "newmovie" AndAlso AdvancedSettings.GetBooleanSetting("NotifyOnNewMovie", False)
                            ShowIt = True
                        Case _params(0).ToString = "moviescraped" AndAlso AdvancedSettings.GetBooleanSetting("NotifyOnMovieScraped", True)
                            ShowIt = True
                        Case _params(0).ToString = "newep" AndAlso AdvancedSettings.GetBooleanSetting("NotifyOnNewEp", False)
                            ShowIt = True
                        Case _params(0).ToString = "info"
                            ShowIt = True
                    End Select

                    If ShowIt Then
                        dNotify = New frmNotify
                        AddHandler dNotify.NotifierClicked, AddressOf Me.Handle_NotifierClicked
                        AddHandler dNotify.NotifierClosed, AddressOf Me.Handle_NotifierClosed
                        dNotify.Show(_params(0).ToString, Convert.ToInt32(_params(1)), _params(2).ToString, _params(3).ToString, If(Not IsNothing(_params(4)), DirectCast(_params(4), Image), Nothing))
                    End If
                End If
            Catch ex As Exception
            End Try
            Return New Interfaces.ModuleResult With {.breakChain = False}
        End Function

        Private Sub Handle_NotifierClicked(ByVal _type As String)
            'RaiseEvent GenericEvent(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {_type}))
        End Sub

        Private Sub Handle_NotifierClosed()
            RemoveHandler Me.dNotify.NotifierClicked, AddressOf Me.Handle_NotifierClicked
            RemoveHandler Me.dNotify.NotifierClosed, AddressOf Me.Handle_NotifierClosed
        End Sub

#End Region 'Methods

    End Class
End Namespace