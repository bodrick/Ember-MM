Public Class CancelPanel
    Public Sub Setup()
        lblCanceling.Text = Languages.Canceling_Scraper
        btnCancel.Text = Languages.Cancel_Scraper
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        btnCancel.Visible = False
        lblCanceling.Visible = True
        pbCanceling.Visible = True

        'If Me.bwMovieScraper.IsBusy Then Me.bwMovieScraper.CancelAsync()
        'If Me.bwRefreshMovies.IsBusy Then Me.bwRefreshMovies.CancelAsync()
        'If Me.bwNonScrape.IsBusy Then Me.bwNonScrape.CancelAsync()
        'While Me.bwMovieScraper.IsBusy OrElse Me.bwRefreshMovies.IsBusy OrElse Me.bwNonScrape.IsBusy
        '        Application.DoEvents()
        'Threading.Thread.Sleep(50)
        'End While
    End Sub
End Class
