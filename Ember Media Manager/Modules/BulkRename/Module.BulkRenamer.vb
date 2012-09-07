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

Namespace Modules.BulkRename

    Public Class BulkRenamerModule
        Inherits EmberModule


#Region "Fields"
        Private WithEvents MyMenu As New System.Windows.Forms.ToolStripMenuItem
        Private WithEvents MyTrayMenu As New System.Windows.Forms.ToolStripMenuItem
        Private WithEvents ctxMyMenu As New System.Windows.Forms.ToolStripMenuItem
        Private WithEvents MyMenuSep As New System.Windows.Forms.ToolStripSeparator
        Private WithEvents ctxMySubMenu1 As New System.Windows.Forms.ToolStripMenuItem
        Private WithEvents ctxMySubMenu2 As New System.Windows.Forms.ToolStripMenuItem        
        Private MySettings As New _MySettings        
        Private _enabled As Boolean = False
        
#End Region 'Fields

#Region "Methods"
        Public Sub New(parentForm As frmMain)
            _parentForm = parentForm
        End Sub

        Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object) As Interfaces.ModuleResult
            Select Case mType
                Case Enums.ModuleEventType.MovieScraperRDYtoSave
                    Dim tDBMovie As Model.Movie = DirectCast(_refparam, Model.Movie)
                    If Not String.IsNullOrEmpty(tDBMovie.Title) AndAlso MySettings.AutoRenameMulti AndAlso Master.GlobalScrapeMod.NFO AndAlso (Not String.IsNullOrEmpty(MySettings.FoldersPattern) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern)) Then
                        FileFolderRenamer.RenameSingle(tDBMovie, MySettings.FoldersPattern, MySettings.FilesPattern, False, Not String.IsNullOrEmpty(tDBMovie.Imdb), False)
                    End If
                Case Enums.ModuleEventType.RenameMovie
                    
                Case Enums.ModuleEventType.RenameMovieManual
                    Using dRenameManual As New dlgRenameManual
                        Select Case dRenameManual.ShowDialog()
                            Case Windows.Forms.DialogResult.OK
                                Return New Interfaces.ModuleResult With {.Cancelled = False, .breakChain = False}
                            Case Else
                                Return New Interfaces.ModuleResult With {.Cancelled = True, .breakChain = False}
                        End Select
                    End Using
            End Select
            Return New Interfaces.ModuleResult With {.breakChain = False}
        End Function
        Private Sub FolderSubMenuItemAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxMySubMenu1.Click
            'Cursor.Current = Cursors.WaitCursor
            'Dim indX As Integer = _parentForm.dgvMediaList.SelectedRows(0).Index
            'Dim ID As Integer = Convert.ToInt32(_parentForm.dgvMediaList.Item(0, indX).Value)
            'FileFolderRenamer.RenameSingle(Master.currMovie, MySettings.FoldersPattern, MySettings.FilesPattern, True, True, True)
            'Cursor.Current = Cursors.Default
        End Sub
        Private Sub FolderSubMenuItemManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxMySubMenu2.Click
            'Dim indX As Integer = _parentForm.dgvMediaList.SelectedRows(0).Index
            'Dim ID As Integer = Convert.ToInt32(_parentForm.dgvMediaList.Item(0, indX).Value)
            'Using dRenameManual As New dlgRenameManual
            '    Select Case dRenameManual.ShowDialog()
            '        Case Windows.Forms.DialogResult.OK
            '            If MySettings.AutoRenameSingle AndAlso Not String.IsNullOrEmpty(MySettings.FoldersPattern) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern) Then
            '                FileFolderRenamer.RenameSingle(Master.currMovie, MySettings.FoldersPattern, MySettings.FilesPattern, True, True, True)
            '            End If
            '    End Select
            'End Using
        End Sub

        'Sub Disable()
        '    Dim tsi As ToolStripMenuItem
        '    tsi = DirectCast(_parentForm.MenuStrip.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
        '    tsi.DropDownItems.Remove(MyMenu)
        '    tsi = DirectCast(_parentForm.cmnuTrayIcon.Items("cmnuTrayIconTools"), ToolStripMenuItem)
        '    tsi.DropDownItems.Remove(MyTrayMenu)
        '    _parentForm.mnuMediaList.Items.Add(MyMenuSep)
        '    _parentForm.mnuMediaList.Items.Add(ctxMyMenu)
        '    '_enabled = False
        'End Sub

        Public Overrides Sub Setup()
            Dim tsi As ToolStripMenuItem
            MyMenu.Image = New Bitmap(My.Resources.Modules.small_icon_Pad)
            MyMenu.Text = Languages.Bulk_Renamer
            tsi = DirectCast(_parentForm.MenuStrip.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
            MyMenu.Tag = New Structures.ModulesMenus With {.IfNoMovies = True, .IfNoTVShow = True}
            tsi.DropDownItems.Add(MyMenu)
            MyTrayMenu.Image = New Bitmap(My.Resources.Modules.small_icon_Pad)
            MyTrayMenu.Text = Languages.Bulk_Renamer
            tsi = DirectCast(_parentForm.cmnuTrayIcon.Items("cmnuTrayIconTools"), ToolStripMenuItem)
            tsi.DropDownItems.Add(MyTrayMenu)

            ctxMyMenu.Text = Languages.Rename
            ctxMyMenu.ShortcutKeys = Windows.Forms.Keys.Control And Windows.Forms.Keys.R
            ctxMySubMenu1.Text = Languages._Auto
            ctxMySubMenu2.Text = Languages.Manual
            ctxMyMenu.DropDownItems.Add(ctxMySubMenu1)
            ctxMyMenu.DropDownItems.Add(ctxMySubMenu2)

            '_parentForm.mnuMediaList.Items.Add(MyMenuSep)
            '_parentForm.mnuMediaList.Items.Add(ctxMyMenu)
        End Sub

        Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyMenu.Click
            'Select Case _parentForm.tabsMain.SelectedIndex
            '    Case 0
            '        Using dBulkRename As New dlgBulkRenamer
            '            dBulkRename.txtFolder.Text = AdvancedSettings.GetSetting("FoldersPattern", "$T {($Y)}")
            '            dBulkRename.txtFile.Text = AdvancedSettings.GetSetting("FilesPattern", "$T{.$S}")
            '            Try
            '                If dBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                    '_parentForm.LoadMedia(New Structures.Scans With {.Movies = True})
            '                End If
            '            Catch ex As Exception
            '            End Try
            '        End Using
            '    Case 1
            '        MsgBox("Not implemented yet", MsgBoxStyle.OkOnly, "Info")
            '        'Using dTVBulkRename As New dlgtvBulkRenamer
            '        'If dTVBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        'End If
            '        'End Using
            'End Select
        End Sub



#End Region 'Methods

#Region "Nested Types"

        Structure _MySettings

#Region "Fields"

            Dim AutoRenameMulti As Boolean
            Dim AutoRenameSingle As Boolean
            Dim BulkRenamer As Boolean
            Dim FilesPattern As String
            Dim FoldersPattern As String
            Dim GenericModule As Boolean

#End Region 'Fields

        End Structure

#End Region 'Nested Types

        
    End Class
End Namespace