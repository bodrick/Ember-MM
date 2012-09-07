Imports System.Windows.Forms
Imports EmberMediaManger.API

Namespace Modules.Extras

    Public Class AVCodecEditor
        Private Sub btnAddAudio_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddAudio.Click
            Dim i As Integer = dgvAudio.Rows.Add(New Object() {String.Empty, String.Empty})
            dgvAudio.Rows(i).Tag = False
            dgvAudio.CurrentCell = dgvAudio.Rows(i).Cells(0)
            dgvAudio.BeginEdit(True)            
        End Sub
        Private Sub btnAddVideo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddVideo.Click
            Dim i As Integer = dgvVideo.Rows.Add(New Object() {String.Empty, String.Empty})
            dgvVideo.Rows(i).Tag = False
            dgvVideo.CurrentCell = dgvVideo.Rows(i).Cells(0)
            dgvVideo.BeginEdit(True)            
        End Sub

        Private Sub btnRemoveAudio_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveAudio.Click
            If dgvAudio.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvAudio.Rows(dgvAudio.SelectedCells(0).RowIndex).Tag) Then
                dgvAudio.Rows.RemoveAt(dgvAudio.SelectedCells(0).RowIndex)
            End If            
        End Sub
        Private Sub btnRemoveVideo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRemoveVideo.Click
            If dgvVideo.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvVideo.Rows(dgvVideo.SelectedCells(0).RowIndex).Tag) Then
                dgvVideo.Rows.RemoveAt(dgvVideo.SelectedCells(0).RowIndex)
            End If            
        End Sub        

        Private Sub dgvAudio_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvAudio.SelectionChanged
            If dgvAudio.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvAudio.Rows(dgvAudio.SelectedCells(0).RowIndex).Tag) Then
                btnRemoveAudio.Enabled = True
            Else
                btnRemoveAudio.Enabled = False
            End If
        End Sub

        Private Sub dgvVideo_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvVideo.SelectionChanged
            If dgvVideo.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvVideo.Rows(dgvVideo.SelectedCells(0).RowIndex).Tag) Then
                btnRemoveVideo.Enabled = True
            Else
                btnRemoveVideo.Enabled = False
            End If
        End Sub

        Private Sub dgvAudio_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles dgvAudio.KeyDown
            e.Handled = (e.KeyCode = Keys.Enter)
        End Sub

        Private Sub dgvVideo_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles dgvVideo.KeyDown
            e.Handled = (e.KeyCode = Keys.Enter)
        End Sub

        Public Overrides Sub SaveSettings()
            Dim deleteitem As List(Of String) = (From sett In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("AudioFormatConvert:")) Select sett.Name).ToList()
            deleteitem.AddRange(From sett In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("VideoFormatConvert:")) Select sett.Name)
            For Each s As String In deleteitem
                AdvancedSettings.CleanSetting(s, "*EmberAPP")
            Next
            For Each r As DataGridViewRow In dgvAudio.Rows.Cast(Of DataGridViewRow)()
                AdvancedSettings.SetSetting(String.Concat("AudioFormatConvert:", r.Cells(0).Value.ToString), r.Cells(1).Value.ToString, "*EmberAPP")
            Next
            For Each r As DataGridViewRow In dgvVideo.Rows.Cast(Of DataGridViewRow)()
                AdvancedSettings.SetSetting(String.Concat("VideoFormatConvert:", r.Cells(0).Value.ToString), r.Cells(1).Value.ToString, "*EmberAPP")
            Next
        End Sub

        Protected Overrides Sub LoadSettings()
            For Each sett As AdvancedSettings.SettingItem In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("AudioFormatConvert:"))
                Dim i As Integer = dgvAudio.Rows.Add(New Object() {sett.Name.Substring(19), sett.Value})
                If Not sett.DefaultValue = String.Empty Then
                    dgvAudio.Rows(i).Tag = True
                    dgvAudio.Rows(i).Cells(0).ReadOnly = True
                    dgvAudio.Rows(i).Cells(0).Style.SelectionForeColor = Color.Red
                Else
                    dgvAudio.Rows(i).Tag = False
                End If
            Next
            For Each sett As AdvancedSettings.SettingItem In AdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("VideoFormatConvert:"))
                Dim i As Integer = dgvVideo.Rows.Add(New Object() {sett.Name.Substring(19), sett.Value})
                If Not sett.DefaultValue = String.Empty Then
                    dgvVideo.Rows(i).Tag = True
                    dgvVideo.Rows(i).Cells(0).ReadOnly = True
                    dgvVideo.Rows(i).Cells(0).Style.SelectionForeColor = Color.Red
                Else
                    dgvVideo.Rows(i).Tag = False
                End If
            Next
            dgvAudio.ClearSelection()
            dgvVideo.ClearSelection()
        End Sub

        Protected Overrides Sub LoadResources()            
            btnAddAudio.Text = Languages.Add
            btnAddVideo.Text = Languages.Add
            btnRemoveAudio.Text = Languages.Remove
            btnRemoveVideo.Text = Languages.Remove
            Label1.Text = Languages.Audio
            Label2.Text = Languages.Video
            dgvAudio.Columns(0).HeaderText = Languages.Mediainfo_Codec
            dgvAudio.Columns(1).HeaderText = Languages.Mapped_Codec
            dgvVideo.Columns(0).HeaderText = Languages.Mediainfo_Codec
            dgvVideo.Columns(1).HeaderText = Languages.Mapped_Codec            
        End Sub
    End Class
End Namespace