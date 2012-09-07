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
Imports System.Threading.Tasks
Imports TechNuts.ScraperXML

Namespace Scrapers.Movies

    Public Class dlgIMDBSearchResults

#Region "Methods"
        Private Class IMDBIDComparer
            Implements IEqualityComparer(Of ScrapeResultsEntity)
            Public Overloads Function Equals(ByVal x As ScrapeResultsEntity, ByVal y As ScrapeResultsEntity) As Boolean Implements IEqualityComparer(Of ScrapeResultsEntity).Equals
                Return x.ID = y.ID
            End Function

            Public Overloads Function GetHashCode(ByVal obj As ScrapeResultsEntity) As Integer Implements IEqualityComparer(Of ScrapeResultsEntity).GetHashCode
                Return obj.ToString().GetHashCode()
            End Function
        End Class


        Private Sub ScrapeData(movieTitle As String, movieYear As String)
            Dim scrapeResults As List(Of ScrapeResultsEntity)
            scrapeResults = Master.ScraperMan.GetMovieResults("IMDB", movieTitle, movieYear)
            tvResults.Nodes.Clear()
            ClearInfo()
            If scrapeResults.Count > 0 Then
                Dim mainTreeNode As New TreeNode(String.Format(Languages.Matches_WithParam, scrapeResults.Count))
                For Each result As ScrapeResultsEntity In scrapeResults.Distinct(New IMDBIDComparer())
                    mainTreeNode.Nodes.Add(New TreeNode() With {.Text = String.Concat(result.Title, If(Not String.IsNullOrEmpty(result.Year), String.Format(" ({0})", result.Year), String.Empty)), .Tag = result})
                Next
                mainTreeNode.Expand()
                tvResults.Nodes.Add(mainTreeNode)
                If scrapeResults.Count = 1 Then
                    tvResults.SelectedNode = mainTreeNode.FirstNode
                Else
                    tvResults.SelectedNode = Nothing
                End If
                tvResults.Focus()
            Else
                tvResults.Nodes.Add(New TreeNode With {.Text = Languages.No_Matches_Found})
            End If
            pnlLoading.Visible = False
            chkManual.Enabled = True
        End Sub

        Private Sub ScrapeMovieDetails(movieDetails As TechNuts.MediaTags.MovieTag)
            If movieDetails IsNot Nothing Then
                lblTitle.Text = movieDetails.Title
                lblTagline.Text = movieDetails.Tagline
                lblYear.Text = movieDetails.Year
                lblDirector.Text = movieDetails.Directors.Item(0).Name
                lblGenre.Text = movieDetails.Genres.Item(0)
                txtOutline.Text = movieDetails.Outline
                lblIMDB.Text = movieDetails.ID

                pnlPicStatus.Visible = True
                Dim downloadTask As Task(Of Image) = Task.Factory.StartNew(Function() Classes.Http.DownloadImage(movieDetails.Thumbs(0).Thumb))
                While Not downloadTask.IsCompleted
                    Application.DoEvents()
                    Threading.Thread.Sleep(50)
                End While
                pnlPicStatus.Visible = False
                If downloadTask.Result IsNot Nothing Then
                    pbPoster.Image = downloadTask.Result
                Else
                    pbPoster.Image = Nothing
                End If
            Else
                If chkManual.Checked Then
                    MsgBox("Unable to retrieve movie details for the entered IMDB ID. Please check your entry and try again.", MsgBoxStyle.Exclamation, Master.eLang.GetString(16, "Verification Failed"))
                    btnVerify.Enabled = True
                End If
            End If
        End Sub

        Public Overloads Function ShowDialog(ByVal sMovieTitle As String, sMovieYear As String) As Windows.Forms.DialogResult
            Text = String.Concat(Languages.Search_Results, sMovieTitle)
            txtSearch.Text = sMovieTitle
            chkManual.Enabled = False
            ScrapeData(sMovieTitle, sMovieYear)
            Return ShowDialog()
        End Function

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            If Not String.IsNullOrEmpty(txtSearch.Text) Then
                OK_Button.Enabled = False
                pnlPicStatus.Visible = False                
                ClearInfo()
                Label3.Text = "Searching IMDB..."
                pnlLoading.Visible = True
                chkManual.Enabled = False
                ScrapeData(txtSearch.Text, "")
            End If
        End Sub

        Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
            'If Regex.IsMatch(Me.txtIMDBID.Text.Replace("tt", String.Empty), "\d\d\d\d\d\d\d") Then
            '    IMDB.IMDBURL = IMDBURL
            '    IMDB.GetSearchMovieInfoAsync(Me.txtIMDBID.Text.Replace("tt", String.Empty), Master.tmpMovie, Master.DefaultOptions)
            'Else
            '    MsgBox(Master.eLang.GetString(12, "The ID you entered is not a valid IMDB ID."), MsgBoxStyle.Exclamation, Master.eLang.GetString(292, "Invalid Entry", True))
            'End If
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub chkManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManual.CheckedChanged
            ClearInfo()
            OK_Button.Enabled = False
            txtIMDBID.Enabled = chkManual.Checked
            btnVerify.Enabled = chkManual.Checked
            tvResults.Enabled = Not chkManual.Checked

            If Not chkManual.Checked Then
                txtIMDBID.Text = String.Empty
            End If
        End Sub

        Private Sub ClearInfo()
            ControlsVisible(False)
            lblTitle.Text = String.Empty
            lblTagline.Text = String.Empty
            lblYear.Text = String.Empty
            lblDirector.Text = String.Empty
            lblGenre.Text = String.Empty
            txtOutline.Text = String.Empty
            lblIMDB.Text = String.Empty
            pbPoster.Image = Nothing
        End Sub

        Private Sub ControlsVisible(ByVal areVisible As Boolean)
            lblYearHeader.Visible = areVisible
            lblDirectorHeader.Visible = areVisible
            lblGenreHeader.Visible = areVisible
            lblPlotHeader.Visible = areVisible
            lblIMDBHeader.Visible = areVisible
            txtOutline.Visible = areVisible
            lblYear.Visible = areVisible
            lblTagline.Visible = areVisible
            lblTitle.Visible = areVisible
            lblDirector.Visible = areVisible
            lblGenre.Visible = areVisible
            lblIMDB.Visible = areVisible
            pbPoster.Visible = areVisible
        End Sub

        Private Sub dlgIMDBSearchResults_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
            AcceptButton = OK_Button
        End Sub

        Private Sub dlgIMDBSearchResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            SetUp()
            pnlPicStatus.Visible = False

            Try
                Dim iBackground As New Bitmap(pnlTop.Width, pnlTop.Height)
                Using g As Graphics = Graphics.FromImage(iBackground)
                    g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
                    pnlTop.BackgroundImage = iBackground
                End Using
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub dlgIMDBSearchResults_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
            Activate()
            tvResults.Focus()
        End Sub

        Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
            'Try
            '    If Me.chkManual.Checked AndAlso Me.btnVerify.Enabled Then
            '        If Not Regex.IsMatch(Me.txtIMDBID.Text.Replace("tt", String.Empty), "\d\d\d\d\d\d\d") Then
            '            MsgBox(Master.eLang.GetString(12, "The ID you entered is not a valid IMDB ID."), MsgBoxStyle.Exclamation, Master.eLang.GetString(292, "Invalid Entry", True))
            '            Exit Sub
            '        Else
            '            If MsgBox(String.Concat(Master.eLang.GetString(13, "You have manually entered an IMDB ID but have not verified it is correct."), vbNewLine, vbNewLine, Master.eLang.GetString(101, "Are you sure you want to continue?", True)), MsgBoxStyle.YesNo, Master.eLang.GetString(14, "Continue without verification?")) = MsgBoxResult.No Then
            '                Exit Sub
            '            Else
            '                Master.tmpMovie.IMDBID = Me.txtIMDBID.Text.Replace("tt", String.Empty)
            '            End If
            '        End If
            '    End If
            '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
            'Catch ex As Exception
            '    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            'End Try

            'Me.Close()
        End Sub

        Private Sub SetUp()
            OK_Button.Text = Master.eLang.GetString(179, "OK", True)
            Cancel_Button.Text = Master.eLang.GetString(167, "Cancel", True)
            Label2.Text = Master.eLang.GetString(21, "View details of each result to find the proper movie.")
            Label1.Text = Master.eLang.GetString(22, "Movie Search Results")
            chkManual.Text = Master.eLang.GetString(23, "Manual IMDB Entry:")
            btnVerify.Text = Master.eLang.GetString(24, "Verify")
            lblYearHeader.Text = Master.eLang.GetString(49, "Year:", True)
            lblDirectorHeader.Text = Master.eLang.GetString(239, "Director:", True)
            lblGenreHeader.Text = Master.eLang.GetString(51, "Genre(s):", True)
            lblIMDBHeader.Text = Master.eLang.GetString(289, "IMDB ID:", True)
            lblPlotHeader.Text = Master.eLang.GetString(242, "Plot Outline:", True)
            Label3.Text = Master.eLang.GetString(25, "Searching IMDB...")
        End Sub

        Private Sub tvResults_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvResults.AfterSelect
            Try
                ClearInfo()
                OK_Button.Enabled = False

                If tvResults.SelectedNode.Tag IsNot Nothing Then
                    Dim selectedItem = tvResults.SelectedNode.Tag
                    pnlLoading.Visible = True
                    Dim scrapeTask = Task.Factory.StartNew(Function() Master.ScraperMan.GetMovieDetails(selectedItem))
                    While Not scrapeTask.IsCompleted
                        Application.DoEvents()
                        Threading.Thread.Sleep(50)
                    End While
                    pnlLoading.Visible = False
                    ControlsVisible(True)
                    If scrapeTask.Result IsNot Nothing Then
                        ScrapeMovieDetails(scrapeTask.Result)
                    End If                    
                End If

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
        End Sub

        Private Sub tvResults_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvResults.GotFocus
            AcceptButton = OK_Button
        End Sub

        Private Sub txtIMDBID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIMDBID.GotFocus
            AcceptButton = btnVerify
        End Sub

        Private Sub txtIMDBID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIMDBID.TextChanged
            If chkManual.Checked Then
                btnVerify.Enabled = True
                OK_Button.Enabled = False
            End If
        End Sub

        Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
            AcceptButton = btnSearch
        End Sub

#End Region 'Methods

    End Class
End Namespace