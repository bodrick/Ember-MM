Public Class Form1
    Dim tempScraper As Scrapers.Movies.XMLScraper
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            tempScraper = New Scrapers.Movies.XMLScraper(OpenFileDialog1.FileName)
        End If
    End Sub
End Class
