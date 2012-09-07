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

Namespace My

    Partial Friend Class MyApplication

#Region "Methods"

        ''' <summary>
        ''' Process/load information before beginning the main application.
        ''' </summary>
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Try                
                Functions.TestMediaInfoDLL()
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        ''' <summary>
        ''' Check if Ember is already running, but only for GUI instances
        ''' </summary>
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Dim Args() As String = Environment.GetCommandLineArgs
            If Args.Count = 1 Then
                MsgBox(Languages.Ember_Media_Manager_is_already_running, MsgBoxStyle.OkOnly, Languages.Ember_Media_Manager)
                End
            End If
        End Sub

        ''' <summary>
        ''' Basic wrapper for unhandled exceptions
        ''' </summary>
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox(e.Exception.Message, MsgBoxStyle.OkOnly, Languages.Ember_Media_Manager)
            Application.Log.WriteException(e.Exception, TraceEventType.Critical, Languages.Unhandled_Exception)
        End Sub

#End Region 'Methods

    End Class

End Namespace

