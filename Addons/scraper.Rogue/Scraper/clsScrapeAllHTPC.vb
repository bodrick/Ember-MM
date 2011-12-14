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

Namespace AllHTPC

    Public Class Scraper

#Region "Methods"

        Public Function GetTrailer(ByVal imdbID As String) As String
            Dim sHTTP As New HTTP

            Try
                Dim sResults As String = sHTTP.DownloadData(String.Format("http://hdtrailers.allhtpc.com/search/{0}", imdbID))
                sHTTP = Nothing

                If Not sResults.ToLower.Contains("no movies in the database") AndAlso Not sResults.ToLower.Contains("not been verified yet") Then
                    Return sResults.Trim
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try

            Return String.Empty
        End Function

#End Region 'Methods

    End Class

End Namespace

