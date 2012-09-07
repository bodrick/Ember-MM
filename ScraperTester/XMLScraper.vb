Imports System.Xml.Linq
Imports System.ComponentModel

Namespace Scrapers.Movies
    <Localizable(False)>
    Public Class XMLScraper
        Private _scraperXML As XDocument
        Private _searchURL As String
        Public Sub New(inputFile As String)
            Try
                _scraperXML = XDocument.Load(inputFile)
                ParseScraper()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub ParseScraper()
            If _scraperXML IsNot Nothing Then
                Dim searchNode As XElement = (From xSearch In _scraperXML.Descendants("CreateSearchUrl")).FirstOrDefault
                If searchNode IsNot Nothing Then
                    Dim regExpNodes As List(Of XNode) = (From xSearch In searchNode.Nodes() Where xSearch.ToString() = "RegExp").ToList()
                    For Each regExpNode As XElement In regExpNodes
                        _searchURL = regExpNode.Attribute("output").Value
                    Next
                End If
            End If
        End Sub
    End Class
End Namespace