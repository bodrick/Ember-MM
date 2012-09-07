Imports System.Windows.Forms
Imports EmberMediaManger.API

Namespace Modules.Extras

    Public Class MediaSourcesEditor

        Private Sub LoadSources()
            dgvSources.Rows.Clear()
            Dim sources As Hashtable = AdvancedSettings.GetComplexSetting("MovieSources", "*EmberAPP")
            For Each sett As Object In sources.Keys
                dgvSources.Rows.Add(New Object() {sett.ToString, sources.Item(sett.ToString)})
            Next
            dgvSources.ClearSelection()
        End Sub

        Private Sub btnAddSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddSource.Click
            Dim i As Integer = dgvSources.Rows.Add(New Object() {String.Empty, String.Empty})
            dgvSources.Rows(i).Tag = False
            dgvSources.CurrentCell = dgvSources.Rows(i).Cells(0)
            dgvSources.BeginEdit(True)
        End Sub
        Private Sub btnRemoveSource_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveSource.Click
            If dgvSources.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvSources.Rows(dgvSources.SelectedCells(0).RowIndex).Tag) Then
                dgvSources.Rows.RemoveAt(dgvSources.SelectedCells(0).RowIndex)                
            End If
        End Sub
        
        Private Sub dgvSources_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvSources.SelectionChanged
            If dgvSources.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvSources.Rows(dgvSources.SelectedCells(0).RowIndex).Tag) Then
                btnRemoveSource.Enabled = True
            Else
                btnRemoveSource.Enabled = False
            End If
        End Sub

        Private Sub dgvSources_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles dgvSources.KeyDown
            e.Handled = (e.KeyCode = Keys.Enter)
        End Sub

        Private Sub dgvVideo_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles dgvByFile.KeyDown
            e.Handled = (e.KeyCode = Keys.Enter)
        End Sub

        Public Overrides Sub SaveSettings()
            Dim deleteitem As List(Of String) = (From sett In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MediaSourcesByExtension:")) Select sett.Name).ToList()
            For Each s As String In deleteitem
                AdvancedSettings.CleanSetting(s, "*EmberAPP")
            Next

            Dim sources As New Hashtable
            For Each r As DataGridViewRow In From r1 In dgvSources.Rows.Cast(Of DataGridViewRow)() Where Not String.IsNullOrEmpty(r1.Cells(0).Value.ToString) AndAlso Not sources.ContainsKey(r1.Cells(0).Value.ToString)
                sources.Add(r.Cells(0).Value.ToString, r.Cells(1).Value.ToString)
            Next
            AdvancedSettings.SetComplexSetting("MovieSources", sources, "*EmberAPP")
            AdvancedSettings.SetBooleanSetting("MediaSourcesByExtension", chkMapByFile.Checked, "*EmberAPP")
            For Each r As DataGridViewRow In From r1 In dgvByFile.Rows.Cast(Of DataGridViewRow)() Where Not String.IsNullOrEmpty(r1.Cells(0).Value.ToString) AndAlso Not sources.ContainsKey(r1.Cells(0).Value.ToString)
                AdvancedSettings.SetSetting(String.Concat("MediaSourcesByExtension:", r.Cells(0).Value.ToString), r.Cells(1).Value.ToString, "*EmberAPP")
            Next
        End Sub

        Private Sub btnSetDefaults_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSetDefaults.Click
            AdvancedSettings.SetDefaults(True, "MovieSources")
            LoadSources()
        End Sub

        Private Sub chkMapByFile_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles chkMapByFile.CheckedChanged
            SetByFileStatus(chkMapByFile.Checked)            
        End Sub

        Private Sub SetByFileStatus(ByVal b As Boolean)
            dgvByFile.ClearSelection()
            dgvByFile.Enabled = b
            btnAddByFile.Enabled = b
            btnRemoveByFile.Enabled = b
        End Sub

        Private Sub btnAddByFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddByFile.Click
            Dim i As Integer = dgvByFile.Rows.Add(New Object() {String.Empty, String.Empty})
            dgvByFile.Rows(i).Tag = False
            dgvByFile.CurrentCell = dgvByFile.Rows(i).Cells(0)
            dgvByFile.BeginEdit(True)            
        End Sub

        Private Sub btnremoveByFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveByFile.Click
            If dgvByFile.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvByFile.Rows(dgvByFile.SelectedCells(0).RowIndex).Tag) Then
                dgvByFile.Rows.RemoveAt(dgvByFile.SelectedCells(0).RowIndex)                
            End If
        End Sub

        Private Sub dgvByFile_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvByFile.SelectionChanged
            If dgvByFile.Enabled AndAlso dgvByFile.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvByFile.Rows(dgvByFile.SelectedCells(0).RowIndex).Tag) Then
                btnRemoveByFile.Enabled = True
            Else
                btnRemoveByFile.Enabled = False
            End If
        End Sub

        Protected Overrides Sub LoadSettings()
            LoadSources()
            dgvByFile.Rows.Clear()
            For Each sett As AdvancedSettings.SettingItem In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MediaSourcesByExtension:"))
                dgvByFile.Rows.Add(New Object() {sett.Name.Substring(24), sett.Value})
            Next
            SetByFileStatus(False)
            chkMapByFile.Checked = AdvancedSettings.GetBooleanSetting("MediaSourcesByExtension", False, "*EmberAPP")
        End Sub

        Protected Overrides Sub LoadResources()
            btnAddSource.Text = Languages.Add
            btnRemoveSource.Text = Languages.Remove
            btnAddByFile.Text = Languages.Add
            btnRemoveByFile.Text = Languages.Remove
            btnSetDefaults.Text = Languages.Set_Defaults
            Label1.Text = Languages.Sources
            dgvSources.Columns(0).HeaderText = Languages.Search_String
            dgvSources.Columns(1).HeaderText = Languages.Source_Name
            chkMapByFile.Text = Languages.Map_Media_Source_by_File_Extension
            dgvByFile.Columns(0).HeaderText = Languages.File_Extension
            dgvByFile.Columns(1).HeaderText = Languages.Source_Name            
        End Sub
    End Class
End Namespace