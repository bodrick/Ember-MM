Imports System.Text.RegularExpressions
Imports TechNuts.ScraperXML

Namespace SettingsControls

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

    Public Class ScraperSettings
        Private Sub ScraperSettings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            
            'subscribe to events
            'Progress reports for MultiSearch        
            MainInfoSource.DataSource = API.Master.ScraperMan
            MainInfoSource.ResetBindings(False)            
            CreateDynamicControls()
        End Sub


        Protected Overrides Sub LoadSettings()

        End Sub

        Public Overrides Sub SaveSettings()

        End Sub

        Protected Overrides Sub LoadResources()

        End Sub

        Private Sub CreateDynamicControls()
            If (cmbScraperSelected.SelectedItem IsNot Nothing) Then
                SuspendLayout()
                pnlSettings.Controls.Clear()
                SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
                Dim settings = DirectCast(cmbScraperSelected.SelectedItem, ScraperInfo).Settings
                Dim grpCategories = settings.GroupBy(Function(category) category.Category)
                For Each grpCategory In grpCategories
                    Dim gp = New GroupBox() With { _
                     .AutoSize = True, _
                     .Dock = DockStyle.Left, _
                     .Margin = New Padding(5, 0, 0, 0) _
                    }
                    Dim j As Integer = 15
                    For Each setting In grpCategory
                        Dim setVisible As Boolean = True
                        If Not String.IsNullOrEmpty(setting.Visible) Then
                            Dim matches = Regex.Matches(setting.Visible, "(\+|!?)(\w{2})\(([^)]*)\)")
                            For Each values As Match In matches
                                If values.Success Then
                                    Dim param = values.Groups(3).Value.Split(New Char() {","c})
                                    Dim compareSetting = settings(settings.IndexOf(setting) + Integer.Parse(param(0)))
                                    Dim value = ""
                                    Dim op As Boolean = True
                                    Select Case compareSetting.Type
                                        Case "labelenum"
                                            value = compareSetting.Values.ToArray()(Integer.Parse(param(1)))
                                            Exit Select
                                        Case Else
                                            value = param(1)
                                            Exit Select
                                    End Select

                                    If Not String.IsNullOrEmpty(values.Groups(1).Value) AndAlso values.Groups(1).Value = "!" Then
                                        op = False
                                    End If

                                    Dim valueToCompare = compareSetting.Parameter
                                    Select Case values.Groups(2).Value
                                        Case "eq"
                                            If valueToCompare <> value Then
                                                If op Then
                                                    setVisible = False
                                                End If
                                            End If
                                            Exit Select
                                    End Select
                                End If
                            Next
                        End If
                        If setVisible Then
                            Select Case setting.Type
                                Case "bool"
                                    Dim dynamicCheckbox = New CheckBox()
                                    dynamicCheckbox.Text = setting.Label.Trim()
                                    dynamicCheckbox.Name = setting.ID
                                    dynamicCheckbox.Checked = Boolean.Parse(setting.Parameter)
                                    dynamicCheckbox.Location = New Point(5, j)
                                    dynamicCheckbox.AutoSize = True
                                    gp.Controls.Add(dynamicCheckbox)
                                    AddHandler dynamicCheckbox.CheckedChanged, AddressOf DynamicCheckBox_CheckedChanged
                                    j += 20
                                    Exit Select
                                Case "labelenum"
                                    CreateLabel(setting.Label.Trim(), New Point(5, j), gp)
                                    j += 15
                                    Dim dynamicComboBox = New ComboBox()
                                    dynamicComboBox.Items.AddRange(setting.Values.ToArray())
                                    dynamicComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                                    dynamicComboBox.Text = setting.Parameter.Trim()
                                    dynamicComboBox.Location = New Point(5, j)
                                    dynamicComboBox.AutoSize = True
                                    dynamicComboBox.Name = setting.ID
                                    gp.Controls.Add(dynamicComboBox)
                                    AddHandler dynamicComboBox.SelectedIndexChanged, AddressOf DynamicComboBox_SelectedIndexChanged
                                    j += 25
                                    Exit Select
                                Case "text"
                                    CreateLabel(setting.Label.Trim(), New Point(5, j), gp)
                                    j += 15
                                    Dim dynamicTextBox = New TextBox()
                                    dynamicTextBox.Text = setting.Parameter.Trim()
                                    dynamicTextBox.Location = New Point(5, j)
                                    dynamicTextBox.AutoSize = False
                                    dynamicTextBox.Width = 150
                                    dynamicTextBox.Height = 20
                                    dynamicTextBox.Name = setting.ID
                                    gp.Controls.Add(dynamicTextBox)
                                    AddHandler dynamicTextBox.TextChanged, AddressOf DynamicTextBox_TextChanged
                                    If setting.Hidden Then
                                        dynamicTextBox.UseSystemPasswordChar = True
                                    End If
                                    j += 20
                                    Exit Select
                                Case "sep"
                                    Dim sep = New TechNuts.Utilities.LineSeparator()
                                    sep.Location = New Point(5, j)
                                    sep.Width = gp.Width
                                    gp.Controls.Add(sep)
                                    j += 5
                                    Exit Select
                                Case "lsep"
                                    Dim lsep = New TechNuts.Utilities.LineSeparator()
                                    lsep.Caption = setting.Label.Trim()
                                    lsep.Location = New Point(5, j)
                                    lsep.Width = gp.Width
                                    gp.Controls.Add(lsep)
                                    j += 20
                                    Exit Select
                            End Select
                        End If
                    Next
                    gp.Text = grpCategory.Key
                    pnlSettings.Controls.Add(gp)
                Next
                ResumeLayout()
            End If
        End Sub

        Private Sub CreateLabel(strLabelText As String, xyPos As Point, ctl As Control)
            Dim dynamicLabel = New Label()
            dynamicLabel.Text = strLabelText
            dynamicLabel.Location = xyPos
            dynamicLabel.AutoSize = True
            ctl.Controls.Add(dynamicLabel)
        End Sub

        Private Sub DynamicCheckBox_CheckedChanged(sender As Object, e As EventArgs)
            Dim selectedItem = DirectCast(sender, CheckBox)
            DirectCast(cmbScraperSelected.SelectedItem, ScraperInfo).Settings.First(Function(f) f.ID = selectedItem.Name).Parameter = DirectCast(sender, CheckBox).Checked.ToString().ToLower()
            CreateDynamicControls()
        End Sub

        Private Sub DynamicComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
            Dim selectedItem = DirectCast(sender, ComboBox)
            DirectCast(cmbScraperSelected.SelectedItem, ScraperInfo).Settings.First(Function(f) f.ID = selectedItem.Name).Parameter = DirectCast(sender, ComboBox).SelectedItem.ToString()
            CreateDynamicControls()
        End Sub

        Private Sub DynamicTextBox_TextChanged(sender As Object, e As EventArgs)
            Dim selectedItem = DirectCast(sender, TextBox)
            DirectCast(cmbScraperSelected.SelectedItem, ScraperInfo).Settings.First(Function(f) f.ID = selectedItem.Name).Parameter = DirectCast(sender, TextBox).Text
            CreateDynamicControls()
        End Sub

        Private Sub cmbScraperSelected_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbScraperSelected.SelectedIndexChanged
            'Load Scraper Settings here            
            CreateDynamicControls()
        End Sub
    End Class
End Namespace