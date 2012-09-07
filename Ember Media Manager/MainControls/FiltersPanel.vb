Imports System.ComponentModel
Imports EmberMediaManger.API

Public Class FiltersPanel    
    'Public Sub Setup()
    '    btnSortDate.Tag = String.Empty
    '    btnSortTitle.Tag = String.Empty
    '    btnIMDBRating.Tag = String.Empty
    '    btnClearFilters.Text = Languages.Clear_Filters
    '    gbGeneral.Text = Languages.General
    '    chkFilterTolerance.Text = Languages.Out_of_Tolerance
    '    chkFilterMissing.Text = Languages.Missing_Items
    '    chkFilterDupe.Text = Languages.Duplicates
    '    gbSpecific.Text = Languages.Specific
    '    chkFilterLock.Text = Languages.Locked
    '    gbModifier.Text = Languages.Modifier
    '    rbFilterAnd.Text = Languages._And
    '    rbFilterOr.Text = Languages._Or
    '    chkFilterNew.Text = Languages._New
    '    chkFilterMark.Text = Languages.Marked
    '    lblYear.Text = Languages.Year
    '    lblSource.Text = Languages.Source
    '    lblGenre.Text = Languages.Genre
    '    lblFilter.Text = Languages.Filters
    'End Sub

    '    Private Sub RunFilter(Optional ByVal doFill As Boolean = False)
    '        Try
    '            If Me.Visible Then

    '                Me.ClearInfo()

    '                Me.prevRow = -2
    '                Me.currRow = -1
    '                Me.dgvMediaList.ClearSelection()
    '                Me.dgvMediaList.CurrentCell = Nothing

    '                If FilterArray.Count > 0 Then
    '                    Dim FilterString As String = String.Empty

    '                    If rbFilterAnd.Checked Then
    '                        FilterString = Microsoft.VisualBasic.Strings.Join(FilterArray.ToArray, " AND ")
    '                    Else
    '                        FilterString = Microsoft.VisualBasic.Strings.Join(FilterArray.ToArray, " OR ")
    '                    End If

    '                    bsMedia.Filter = FilterString
    '                Else
    '                    bsMedia.RemoveFilter()
    '                End If

    '                If doFill Then
    '                    Me.FillList(0)
    '                Else
    '                    Me.dgvMediaList.Focus()
    '                End If
    '            End If

    '        Catch ex As Exception
    '            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '        End Try
    '    End Sub

    'Private Sub btnClearFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFilters.Click
    '    ClearFilters(True)
    'End Sub

    'Private Sub ClearFilters(Optional ByVal Reload As Boolean = False)
    '    Try
    '        Me.bsMedia.RemoveFilter()
    '        Me.FilterArray.Clear()
    '        Me.filSearch = String.Empty
    '        Me.filGenre = String.Empty
    '        Me.filYear = String.Empty
    '        Me.filSource = String.Empty

    '        RemoveHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
    '        Me.txtSearch.Text = String.Empty
    '        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
    '        If Me.cbSearch.Items.Count > 0 Then
    '            Me.cbSearch.SelectedIndex = 0
    '        End If
    '        Me.chkFilterDupe.Checked = False
    '        Me.chkFilterTolerance.Checked = False
    '        Me.chkFilterMissing.Checked = False
    '        Me.chkFilterMark.Checked = False
    '        Me.chkFilterNew.Checked = False
    '        Me.chkFilterLock.Checked = False
    '        Me.rbFilterOr.Checked = False
    '        Me.rbFilterAnd.Checked = True
    '        Me.txtFilterGenre.Text = String.Empty
    '        For i As Integer = 0 To Me.clbFilterGenres.Items.Count - 1
    '            Me.clbFilterGenres.SetItemChecked(i, False)
    '        Next
    '        Me.txtFilterSource.Text = String.Empty
    '        For i As Integer = 0 To Me.clbFilterSource.Items.Count - 1
    '            Me.clbFilterSource.SetItemChecked(i, False)
    '        Next

    '        RemoveHandler cbFilterYear.SelectedIndexChanged, AddressOf cbFilterYear_SelectedIndexChanged
    '        If Me.cbFilterYear.Items.Count > 0 Then
    '            Me.cbFilterYear.SelectedIndex = 0
    '        End If
    '        AddHandler cbFilterYear.SelectedIndexChanged, AddressOf cbFilterYear_SelectedIndexChanged

    '        RemoveHandler cbFilterYearMod.SelectedIndexChanged, AddressOf cbFilterYearMod_SelectedIndexChanged
    '        If Me.cbFilterYearMod.Items.Count > 0 Then
    '            Me.cbFilterYearMod.SelectedIndex = 0
    '        End If
    '        AddHandler cbFilterYearMod.SelectedIndexChanged, AddressOf cbFilterYearMod_SelectedIndexChanged

    '        RemoveHandler cbFilterFileSource.SelectedIndexChanged, AddressOf cbFilterFileSource_SelectedIndexChanged
    '        If Me.cbFilterFileSource.Items.Count > 0 Then
    '            Me.cbFilterFileSource.SelectedIndex = 0
    '        End If
    '        AddHandler cbFilterFileSource.SelectedIndexChanged, AddressOf cbFilterFileSource_SelectedIndexChanged

    '        If Reload Then Me.FillList(0)
    '    Catch ex As Exception
    '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '    End Try
    'End Sub

    'Private Sub btnIMDBRating_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIMDBRating.Click
    '    If dgvMediaList.RowCount > 0 Then
    '        If btnIMDBRating.Tag.ToString = "DESC" Then
    '            btnIMDBRating.Tag = "ASC"
    '            btnIMDBRating.Image = EmberResources.desc
    '            dgvMediaList.Sort(Me.dgvMediaList.Columns(18), ListSortDirection.Descending)
    '        Else
    '            btnIMDBRating.Tag = "DESC"
    '            btnIMDBRating.Image = EmberResources.asc
    '            dgvMediaList.Sort(Me.dgvMediaList.Columns(18), ListSortDirection.Ascending)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnSortDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSortDate.Click
    '    If dgvMediaList.RowCount > 0 Then
    '        If btnSortDate.Tag.ToString = "DESC" Then
    '            btnSortDate.Tag = "ASC"
    '            btnSortDate.Image = EmberResources.desc
    '            dgvMediaList.Sort(dgvMediaList.Columns(0), ListSortDirection.Descending)
    '        Else
    '            btnSortDate.Tag = "DESC"
    '            btnSortDate.Image = EmberResources.asc
    '            dgvMediaList.Sort(dgvMediaList.Columns(0), ListSortDirection.Ascending)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnSortTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSortTitle.Click
    '    If dgvMediaList.RowCount > 0 Then
    '        If btnSortTitle.Tag.ToString = "DESC" Then
    '            btnSortTitle.Tag = "ASC"
    '            btnSortTitle.Image = EmberResources.desc
    '            dgvMediaList.Sort(dgvMediaList.Columns(47), ListSortDirection.Descending)
    '        Else
    '            btnSortTitle.Tag = "DESC"
    '            btnSortTitle.Image = EmberResources.asc
    '            dgvMediaList.Sort(dgvMediaList.Columns(47), ListSortDirection.Ascending)
    '        End If
    '    End If
    'End Sub

    'Private Sub cbFilterFileSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        While Me.fScanner.IsBusy OrElse Me.bwMediaInfo.IsBusy OrElse Me.bwLoadInfo.IsBusy OrElse Me.bwDownloadPic.IsBusy OrElse Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy OrElse Me.bwCleanDB.IsBusy
    '            Application.DoEvents()
    '            Threading.Thread.Sleep(50)
    '        End While

    '        For i As Integer = Me.FilterArray.Count - 1 To 0 Step -1
    '            If Me.FilterArray(i).ToString.StartsWith("FileSource =") Then
    '                Me.FilterArray.RemoveAt(i)
    '            End If
    '        Next

    '        If Not cbFilterFileSource.Text = Master.eLang.All Then
    '            Me.FilterArray.Add(String.Format("FileSource = '{0}'", If(cbFilterFileSource.Text = Languages.None, String.Empty, cbFilterFileSource.Text)))
    '        End If

    '        Me.RunFilter()
    '    Catch ex As Exception
    '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '    End Try
    'End Sub

    'Private Sub cbFilterYearMod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Not String.IsNullOrEmpty(cbFilterYear.Text) AndAlso Not cbFilterYear.Text = Master.eLang.All Then
    '            Me.FilterArray.Remove(Me.filYear)
    '            Me.filYear = String.Empty

    '            Me.filYear = String.Concat("Year ", cbFilterYearMod.Text, " '", cbFilterYear.Text, "'")

    '            Me.FilterArray.Add(Me.filYear)
    '            Me.RunFilter()
    '        Else
    '            If Not String.IsNullOrEmpty(Me.filYear) Then
    '                Me.FilterArray.Remove(Me.filYear)
    '                Me.filYear = String.Empty
    '                Me.RunFilter()
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub cbFilterYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Not String.IsNullOrEmpty(cbFilterYearMod.Text) AndAlso Not cbFilterYear.Text = Master.eLang.All Then
    '            Me.FilterArray.Remove(Me.filYear)
    '            Me.filYear = String.Empty

    '            Me.filYear = String.Concat("Year ", cbFilterYearMod.Text, " '", cbFilterYear.Text, "'")

    '            Me.FilterArray.Add(Me.filYear)
    '            Me.RunFilter()
    '        Else
    '            If Not String.IsNullOrEmpty(Me.filYear) Then
    '                Me.FilterArray.Remove(Me.filYear)
    '                Me.filYear = String.Empty
    '                Me.RunFilter()
    '            End If

    '            If cbFilterYear.Text = Master.eLang.All Then
    '                Me.cbFilterYearMod.Text = String.Empty
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub chkFilterDupe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Me.RunFilter(True)
    '    Catch ex As Exception
    '        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
    '    End Try
    'End Sub

    'Private Sub chkFilterLock_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.chkFilterLock.Checked Then
    '            Me.FilterArray.Add("Lock = 1")
    '        Else
    '            Me.FilterArray.Remove("Lock = 1")
    '        End If
    '        Me.RunFilter()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub chkFilterMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.chkFilterMark.Checked Then
    '            Me.FilterArray.Add("mark = 1")
    '        Else
    '            Me.FilterArray.Remove("mark = 1")
    '        End If
    '        Me.RunFilter()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub chkFilterMissing_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim MissingFilter As New List(Of String)
    '        If Me.chkFilterMissing.Checked Then
    '            With Master.eSettings
    '                If .MissingFilterPoster Then MissingFilter.Add("HasPoster = 0")
    '                If .MissingFilterFanart Then MissingFilter.Add("HasFanart = 0")
    '                If .MissingFilterNFO Then MissingFilter.Add("HasNfo = 0")
    '                If .MissingFilterTrailer Then MissingFilter.Add("HasTrailer = 0")
    '                If .MissingFilterSubs Then MissingFilter.Add("HasSub = 0")
    '                If .MissingFilterExtras Then MissingFilter.Add("HasExtra = 0")
    '            End With
    '            filMissing = Microsoft.VisualBasic.Strings.Join(MissingFilter.ToArray, " OR ")
    '            Me.FilterArray.Add(filMissing)
    '        Else
    '            Me.FilterArray.Remove(filMissing)
    '        End If
    '        Me.RunFilter()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub chkFilterNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.chkFilterNew.Checked Then
    '            Me.FilterArray.Add("new = 1")
    '        Else
    '            Me.FilterArray.Remove("new = 1")
    '        End If
    '        Me.RunFilter()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub chkFilterTolerance_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.chkFilterTolerance.Checked Then
    '            Me.FilterArray.Add("OutOfTolerance = 1")
    '        Else
    '            Me.FilterArray.Remove("OutOfTolerance = 1")
    '        End If
    '        Me.RunFilter()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub EnableFilters(ByVal isEnabled As Boolean)
    '    Me.txtSearch.Enabled = isEnabled
    '    Me.cbSearch.Enabled = isEnabled
    '    Me.chkFilterDupe.Enabled = isEnabled
    '    Me.chkFilterTolerance.Enabled = If(Master.eSettings.LevTolerance > 0, isEnabled, False)
    '    Me.chkFilterMissing.Enabled = isEnabled
    '    Me.chkFilterMark.Enabled = isEnabled
    '    Me.chkFilterNew.Enabled = isEnabled
    '    Me.chkFilterLock.Enabled = isEnabled
    '    Me.rbFilterOr.Enabled = isEnabled
    '    Me.rbFilterAnd.Enabled = isEnabled
    '    Me.txtFilterSource.Enabled = isEnabled
    '    Me.cbFilterFileSource.Enabled = isEnabled
    '    Me.txtFilterGenre.Enabled = isEnabled
    '    Me.cbFilterYearMod.Enabled = isEnabled
    '    Me.cbFilterYear.Enabled = isEnabled
    '    Me.btnClearFilters.Enabled = isEnabled
    'End Sub

    'Private Sub txtFilterGenre_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.pnlFilterGenre.Location = New Point(Me.gbSpecific.Left + Me.txtFilterGenre.Left, (Me.pnlFilter.Top + Me.txtFilterGenre.Top + Me.gbSpecific.Top) - Me.pnlFilterGenre.Height)
    '    If Me.pnlFilterGenre.Visible Then
    '        Me.pnlFilterGenre.Visible = False
    '    ElseIf Not Me.pnlFilterGenre.Tag.ToString = "NO" Then
    '        Me.pnlFilterGenre.Tag = String.Empty
    '        Me.pnlFilterGenre.Visible = True
    '        Me.clbFilterGenres.Focus()
    '    Else
    '        Me.pnlFilterGenre.Tag = String.Empty
    '    End If
    'End Sub

    'Private Sub txtFilterSource_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.pnlFilterSource.Location = New Point(Me.gbSpecific.Left + Me.txtFilterSource.Left, (Me.pnlFilter.Top + Me.txtFilterSource.Top + Me.gbSpecific.Top) - Me.pnlFilterSource.Height)
    '    If Me.pnlFilterSource.Visible Then
    '        Me.pnlFilterSource.Visible = False
    '    ElseIf Not Me.pnlFilterSource.Tag.ToString = "NO" Then
    '        Me.pnlFilterSource.Tag = String.Empty
    '        Me.pnlFilterSource.Visible = True
    '        Me.clbFilterSource.Focus()
    '    Else
    '        Me.pnlFilterSource.Tag = String.Empty
    '    End If
    'End Sub

    'Private Sub clbFilterGenres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Me.pnlFilterGenre.Visible = False
    '        Me.pnlFilterGenre.Tag = "NO"

    '        If clbFilterGenres.CheckedItems.Count > 0 Then
    '            Me.txtFilterGenre.Text = String.Empty
    '            Me.FilterArray.Remove(Me.filGenre)

    '            Dim alGenres As New List(Of String)
    '            alGenres.AddRange(clbFilterGenres.CheckedItems.OfType(Of String).ToList)

    '            If rbFilterAnd.Checked Then
    '                Me.txtFilterGenre.Text = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " AND ")
    '            Else
    '                Me.txtFilterGenre.Text = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " OR ")
    '            End If

    '            For i As Integer = 0 To alGenres.Count - 1
    '                alGenres.Item(i) = String.Format("Genre LIKE '%{0}%'", alGenres.Item(i))
    '            Next

    '            If rbFilterAnd.Checked Then
    '                Me.filGenre = String.Format("({0})", Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " AND "))
    '            Else
    '                Me.filGenre = String.Format("({0})", Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " OR "))
    '            End If

    '            Me.FilterArray.Add(Me.filGenre)
    '            Me.RunFilter()
    '        Else
    '            If Not String.IsNullOrEmpty(Me.filGenre) Then
    '                Me.txtFilterGenre.Text = String.Empty
    '                Me.FilterArray.Remove(Me.filGenre)
    '                Me.filGenre = String.Empty
    '                Me.RunFilter()
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub clbFilterSource_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Me.pnlFilterSource.Visible = False
    '        Me.pnlFilterSource.Tag = "NO"

    '        If clbFilterSource.CheckedItems.Count > 0 Then
    '            Me.txtFilterSource.Text = String.Empty
    '            Me.FilterArray.Remove(Me.filSource)

    '            Dim alSource As New List(Of String)
    '            alSource.AddRange(clbFilterSource.CheckedItems.OfType(Of String).ToList)

    '            Me.txtFilterSource.Text = Microsoft.VisualBasic.Strings.Join(alSource.ToArray, " | ")

    '            For i As Integer = 0 To alSource.Count - 1
    '                alSource.Item(i) = String.Format("Source = '{0}'", alSource.Item(i))
    '            Next

    '            Me.filSource = String.Format("({0})", Microsoft.VisualBasic.Strings.Join(alSource.ToArray, " OR "))

    '            Me.FilterArray.Add(Me.filSource)
    '            Me.RunFilter()
    '        Else
    '            If Not String.IsNullOrEmpty(Me.filSource) Then
    '                Me.txtFilterSource.Text = String.Empty
    '                Me.FilterArray.Remove(Me.filSource)
    '                Me.filSource = String.Empty
    '                Me.RunFilter()
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    'Private Sub lblGFilClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtFilterGenre.Focus()
    '    Me.pnlFilterGenre.Tag = String.Empty
    'End Sub

    'Private Sub lblSFilClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtFilterSource.Focus()
    '    Me.pnlFilterSource.Tag = String.Empty
    'End Sub

    'Private Sub rbFilterAnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If clbFilterGenres.CheckedItems.Count > 0 Then
    '        Me.txtFilterGenre.Text = String.Empty
    '        Me.FilterArray.Remove(Me.filGenre)

    '        Dim alGenres As New List(Of String)
    '        alGenres.AddRange(clbFilterGenres.CheckedItems.OfType(Of String).ToList)

    '        Me.txtFilterGenre.Text = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " AND ")

    '        For i As Integer = 0 To alGenres.Count - 1
    '            alGenres.Item(i) = String.Format("Genre LIKE '%{0}%'", alGenres.Item(i))
    '        Next

    '        Me.filGenre = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " AND ")

    '        Me.FilterArray.Add(Me.filGenre)
    '    End If

    '    If (Not String.IsNullOrEmpty(Me.cbFilterYear.Text) AndAlso Not Me.cbFilterYear.Text = Master.eLang.All) OrElse Me.clbFilterGenres.CheckedItems.Count > 0 OrElse _
    '    Me.chkFilterMark.Checked OrElse Me.chkFilterNew.Checked OrElse Me.chkFilterLock.Checked OrElse Not Me.clbFilterSource.CheckedItems.Count > 0 OrElse _
    '    Me.chkFilterDupe.Checked OrElse Me.chkFilterMissing.Checked OrElse Me.chkFilterTolerance.Checked OrElse Not Me.cbFilterFileSource.Text = Master.eLang.All Then Me.RunFilter()
    'End Sub

    'Private Sub rbFilterOr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If clbFilterGenres.CheckedItems.Count > 0 Then
    '        Me.txtFilterGenre.Text = String.Empty
    '        Me.FilterArray.Remove(Me.filGenre)

    '        Dim alGenres As New List(Of String)
    '        alGenres.AddRange(clbFilterGenres.CheckedItems.OfType(Of String).ToList)

    '        Me.txtFilterGenre.Text = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " OR ")

    '        For i As Integer = 0 To alGenres.Count - 1
    '            alGenres.Item(i) = String.Format("Genre LIKE '%{0}%'", alGenres.Item(i))
    '        Next

    '        Me.filGenre = Microsoft.VisualBasic.Strings.Join(alGenres.ToArray, " OR ")

    '        Me.FilterArray.Add(Me.filGenre)
    '    End If

    '    If (Not String.IsNullOrEmpty(Me.cbFilterYear.Text) AndAlso Not Me.cbFilterYear.Text = Master.eLang.All) OrElse Me.clbFilterGenres.CheckedItems.Count > 0 OrElse _
    '    Me.chkFilterMark.Checked OrElse Me.chkFilterNew.Checked OrElse Me.chkFilterLock.Checked OrElse Not Me.clbFilterSource.CheckedItems.Count > 0 OrElse _
    '    Me.chkFilterDupe.Checked OrElse Me.chkFilterMissing.Checked OrElse Me.chkFilterTolerance.Checked OrElse Not Me.cbFilterFileSource.Text = Master.eLang.All Then Me.RunFilter()
    'End Sub
End Class
