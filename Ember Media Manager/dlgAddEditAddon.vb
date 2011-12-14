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
Imports System.IO
Imports EmberAPI

Public Class dlgAddEditAddon
    Dim _image As Image = Nothing
    Dim _imagecache As Image = Nothing
    Dim _addon As New Containers.Addon

    Public Overloads Function ShowDialog(ByVal Addon As Containers.Addon) As Containers.Addon
        Me.Setup()

        If Not Addon.ID = -1 Then
            Try
                Me.Text = String.Concat(Master.eLang.GetString(279, "Edit Addon - "), Addon.Name)
                Me.txtName.Text = Addon.Name
                Me.txtDescription.Text = Addon.Description
                Me.txtVersion.Text = Addon.Version.ToString
                Me.txtMinEVersion.Text = Addon.MinEVersion.ToString
                Me.txtMaxEVersion.Text = Addon.MaxEVersion.ToString
                Me.cboCategory.SelectedIndex = Me.GetIndexFromCategory(Addon.Category)
                Me.pbScreenShot.Image = Addon.ScreenShotImage
                Me._imagecache = Addon.ScreenShotImage

                Dim lvItem As New ListViewItem
                For Each _file As KeyValuePair(Of String, String) In Addon.Files
                    lvItem = lvFiles.Items.Add(Path.Combine(Functions.AppPath, _file.Key.Replace("/", Path.DirectorySeparatorChar)))
                    lvItem.SubItems.Add(_file.Value)
                Next
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        Else
            Me.Text = Master.eLang.GetString(277, "New Addon")
        End If

        If MyBase.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return _addon
        Else
            Return Nothing
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If ValidateEntry() Then

                Me._addon.Name = Me.txtName.Text
                Me._addon.Description = Me.txtDescription.Text
                Me._addon.Version = NumUtils.ConvertToSingle(Me.txtVersion.Text)
                Me._addon.MinEVersion = NumUtils.ConvertToSingle(Me.txtMinEVersion.Text)
                Me._addon.MaxEVersion = NumUtils.ConvertToSingle(Me.txtMaxEVersion.Text)
                Me._addon.Category = Me.GetCategoryFromIndex(Me.cboCategory.SelectedIndex)

                If String.IsNullOrEmpty(Me.txtScreenShotPath.Text) Then
                    Me._addon.ScreenShotPath = "!KEEP!"
                Else
                    Me._addon.ScreenShotPath = Me.txtScreenShotPath.Text
                End If

                For Each lvItem As ListViewItem In lvFiles.Items
                    Me._addon.Files.Add(lvItem.Text, lvItem.SubItems(1).Text)
                Next

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Version_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVersion.KeyPress, txtMinEVersion.KeyPress, txtMaxEVersion.KeyPress
        If e.KeyChar = "," Then e.KeyChar = Convert.ToChar(".")
        e.Handled = StringUtils.NumericOnly(e.KeyChar, True) OrElse (e.KeyChar = "." AndAlso Regex.Matches(DirectCast(sender, TextBox).Text, "\.").Count > 1)
    End Sub

    Private Function ValidateEntry() As Boolean
        Return Not String.IsNullOrEmpty(Me.txtName.Text) AndAlso Not String.IsNullOrEmpty(Me.txtDescription.Text) AndAlso _
        (Not String.IsNullOrEmpty(Me.txtVersion.Text) AndAlso Convert.ToSingle(Me.txtVersion.Text) > 0) AndAlso _
        Me.lvFiles.Items.Count > 0 AndAlso ValidateFiles() AndAlso ValidateSS(Me.txtScreenShotPath.Text) AndAlso _
        Me.cboCategory.SelectedIndex > -1
    End Function

    Private Function ValidateFiles() As Boolean
        For Each lvItem As ListViewItem In Me.lvFiles.Items
            If Not File.Exists(lvItem.Text) Then Return False
        Next
        Return True
    End Function

    Private Function ValidateSS(ByVal ssPath As String) As Boolean
        Dim bReturn As Boolean = False
        Try
            If Not String.IsNullOrEmpty(ssPath) Then
                Dim fInfo As New FileInfo(ssPath)
                If fInfo.Exists AndAlso fInfo.Length <= 153600 Then
                    Me._image = Image.FromFile(ssPath)
                    If Me._image.Width <= 133 AndAlso Me._image.Height <= 95 Then
                        bReturn = True
                    End If
                End If
                fInfo = Nothing
            ElseIf Not IsNothing(Me._imagecache) Then
                bReturn = True
            End If
        Catch
        End Try
        Return bReturn
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            Using ofdImage As New OpenFileDialog
                With ofdImage
                    .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    .Filter = "Supported Images(*.jpg, *.jpeg)|*.jpg;*.jpeg|jpeg (*.jpg, *.jpeg)|*.jpg;*.jpeg"
                    .FilterIndex = 0
                End With

                If ofdImage.ShowDialog() = DialogResult.OK Then
                    If ValidateSS(ofdImage.FileName) Then
                        Me.txtScreenShotPath.Text = ofdImage.FileName
                        Me.pbScreenShot.Image = Me._image
                    Else
                        Me.txtScreenShotPath.Text = String.Empty
                        Me.pbScreenShot.Image = Me._imagecache
                        Me._image = Nothing
                    End If
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Me.DeleteFiles()
    End Sub

    Private Sub DeleteFiles()
        Try
            If Me.lvFiles.Items.Count > 0 Then
                While Me.lvFiles.SelectedItems.Count > 0
                    Me._addon.DeleteFiles.Add(Me.lvFiles.SelectedItems(0).Text)
                    Me.lvFiles.Items.Remove(Me.lvFiles.SelectedItems(0))
                End While
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub lvFiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFiles.DoubleClick
        Me.EditFile()
    End Sub

    Private Sub lvFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiles.KeyDown
        If e.KeyCode = Keys.Delete Then Me.DeleteFiles()
    End Sub

    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click
        Try
            Using dNewFile As New dlgAddonFile
                Dim KVP As KeyValuePair(Of String, String) = dNewFile.ShowDialog(String.Empty, String.Empty)
                If Not IsNothing(KVP.Key) Then
                    If IsNothing(lvFiles.FindItemWithText(KVP.Key)) Then
                        Dim lvItem As ListViewItem = lvFiles.Items.Add(KVP.Key)
                        lvItem.SubItems.Add(KVP.Value)
                    End If
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnEditFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditFile.Click
        Me.EditFile()
    End Sub

    Private Sub EditFile()
        Try
            If lvFiles.SelectedItems.Count > 0 Then
                Dim lvItem As ListViewItem = lvFiles.SelectedItems(0)
                Using dEditFile As New dlgAddonFile
                    Dim KVP As KeyValuePair(Of String, String) = dEditFile.ShowDialog(lvItem.Text, lvItem.SubItems(1).Text)
                    If Not IsNothing(KVP.Key) Then
                        lvItem.Text = KVP.Key
                        lvItem.SubItems(1).Text = KVP.Value
                    End If
                End Using
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub Setup()
        Me.lblName.Text = Master.eLang.GetString(171, "Name:")
        Me.lblDescription.Text = Master.eLang.GetString(172, "Description:")
        Me.lblVersion.Text = Master.eLang.GetString(173, "Addon Version:")
        Me.lblMinEVersion.Text = Master.eLang.GetString(178, "Min. Ember Version:")
        Me.lblMaxEVersion.Text = Master.eLang.GetString(257, "Max. Ember Version:")
        Me.lblCategory.Text = Master.eLang.GetString(258, "Category")
        Me.lblSSPath.Text = Master.eLang.GetString(259, "Path To New Screen Shot Image:")
        Me.lblPreview.Text = Master.eLang.GetString(260, "Current Screen Shot:")
        Me.lblSSInfo.Text = Master.eLang.GetString(261, "Screen Shot image must be a JPEG, equal to or less than 150 KB in size, and equal to or less than 133x95 in dimension.")

        Me.lvFiles.Columns(0).Text = Master.eLang.GetString(444, "File")
        Me.lvFiles.Columns(1).Text = Master.eLang.GetString(821, "Description")

        Me.OK_Button.Text = Master.eLang.GetString(179, "OK")
        Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")

        Me.cboCategory.Items.AddRange(New String() {Master.eLang.GetString(290, "Translations"), Master.eLang.GetString(629, "Themes"), Master.eLang.GetString(291, "Templates"), Master.eLang.GetString(802, "Modules"), Master.eLang.GetString(293, "Other")})
    End Sub

    Private Function GetCategoryFromIndex(ByVal iIndex As Integer) As String
        Select Case iIndex
            Case 0
                Return "Translations"
            Case 1
                Return "Themes"
            Case 2
                Return "Templates"
            Case 3
                Return "Modules"
            Case 4
                Return "Other"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Function GetIndexFromCategory(ByVal sCat As String) As Integer
        Select Case sCat
            Case "Translations"
                Return 0
            Case "Themes"
                Return 1
            Case "Templates"
                Return 2
            Case "Modules"
                Return 3
            Case "Other"
                Return 4
            Case Else
                Return -1
        End Select
    End Function
End Class
