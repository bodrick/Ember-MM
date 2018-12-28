Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports EmberMediaManger.API
Imports System.Data.Objects

Public Class dlgEditGenres
    Private _currentMediaItem As Object
    Public Overloads Function ShowDialog(Optional mediaItem As Object = Nothing) As Object
        If mediaItem IsNot Nothing Then
            _currentMediaItem = mediaItem
            If MyBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return _currentMediaItem
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Sub dlgEditGenres_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        LoadGenres()
        Dim genreArray() As String
        Select Case ObjectContext.GetObjectType(_currentMediaItem.GetType())
            Case GetType(Model.TVShow)
                Dim tempTVShow As Model.TVShow = DirectCast(_currentMediaItem, Model.TVShow)
                genreArray = tempTVShow.Genre.Split((New String() {" / "}), StringSplitOptions.RemoveEmptyEntries)
                Text = String.Format(Languages.Genres_for_Param, tempTVShow.Title)
            Case GetType(Model.Movie)
                Dim tempMovie As Model.Movie = DirectCast(_currentMediaItem, Model.Movie)
                genreArray = tempMovie.Genre.Split((New String() {" / "}), StringSplitOptions.RemoveEmptyEntries)
                Text = String.Format(Languages.Genres_for_Param, tempMovie.Title)
        End Select
        If genreArray.Count > 0 Then
            For Each genre In genreArray
                If lbGenre.FindString(genre.Trim) > 0 Then
                    lbGenre.SetItemChecked(lbGenre.FindString(genre.Trim), True)
                End If
            Next
            If lbGenre.CheckedItems.Count = 0 Then
                lbGenre.SetItemChecked(0, True)
            End If
        Else
            lbGenre.SetItemChecked(0, True)
        End If
    End Sub

    Private Sub LoadGenres()
        '//
        ' Read all the genres from the xml and load into the list
        '\\
        lbGenre.Items.Add(Languages.None)
        lbGenre.Items.AddRange(APIXML.GetGenreList)
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As EventArgs) Handles OK_Button.Click
        Dim iChecked = From iCheck In lbGenre.CheckedItems

        Dim genreString As String = String.Join(" / ", iChecked.ToArray())
        Select Case ObjectContext.GetObjectType(_currentMediaItem.GetType())
            Case GetType(Model.Movie)
                Dim currentMovie = DirectCast(_currentMediaItem, Model.Movie)
                currentMovie.Genre = genreString
                Classes.Database.SaveMovie(currentMovie, EntityState.Modified)
            Case (GetType(Model.TVShow))
                Dim currentTVShow As Model.TVShow = DirectCast(_currentMediaItem, Model.TVShow)
                currentTVShow.Genre = genreString
                Classes.Database.SaveTVShow(currentTVShow, EntityState.Modified)
        End Select
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class