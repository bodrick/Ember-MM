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

Namespace Modules.MovieExporter

    Public Class MovieExporterModule
        Inherits EmberModule

#Region "Fields"

        Private WithEvents MyMenu As New System.Windows.Forms.ToolStripMenuItem
        Private WithEvents MyTrayMenu As New System.Windows.Forms.ToolStripMenuItem

#End Region 'Fields

#Region "Methods"

        Public Sub New(parentForm As frmMain)
            _parentForm = parentForm
        End Sub

        Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object) As Interfaces.ModuleResult
            Try
                dlgExportMovies.CLExport(DirectCast(_params(0), String), DirectCast(_params(1), String), DirectCast(_params(2), Int32))
            Catch ex As Exception
            End Try

            Return New Interfaces.ModuleResult With {.breakChain = False}
        End Function

        Public Overrides Sub Setup()
            Dim tsi As ToolStripMenuItem
            MyMenu.Image = New Bitmap(My.Resources.Modules.small_icon_Pad)
            MyMenu.Text = Languages.Export_Movie_List
            tsi = DirectCast(_parentForm.MenuStrip.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
            tsi.DropDownItems.Add(MyMenu)
            MyTrayMenu.Image = New Bitmap(My.Resources.Modules.small_icon_Pad)
            MyTrayMenu.Text = Languages.Export_Movie_List
            tsi = DirectCast(_parentForm.cmnuTrayIcon.Items("cmnuTrayIconTools"), ToolStripMenuItem)
            tsi.DropDownItems.Add(MyTrayMenu)
        End Sub

        Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyMenu.Click, MyTrayMenu.Click
            Using dExportMovies As New dlgExportMovies
                dExportMovies.ShowDialog()
            End Using
        End Sub

#End Region 'Methods

    End Class
End Namespace