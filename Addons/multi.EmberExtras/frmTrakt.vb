Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports System.IO
Imports EmberAPI

Public Class frmTrakt
    Public Event ModuleSettingsChanged()
    Dim myWatchedMovies As New Dictionary(Of String, KeyValuePair(Of String, Integer))
    Dim bkWrk As New System.ComponentModel.BackgroundWorker()

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        SetUp()
    End Sub

    Sub SetUp()
        lblstate.Visible = False
        prgtrakt.Value = 0
        prgtrakt.Maximum = myWatchedMovies.Count
        prgtrakt.Minimum = 0
        prgtrakt.Step = 1
        chkUseTrakt.Text = Master.eLang.GetString(870, "Use Trakt.tv", True)
        btGetMoviesTrakt.Text = Master.eLang.GetString(872, "Trakt Settings", True)
        btSaveMoviesTrakt.Text = Master.eLang.GetString(873, "Trakt Settings", True)
        txtTraktUser.Text = Master.eSettings.TraktUser
        lblTraktUser.Text = Master.eLang.GetString(875, "Trakt.tv Username (Privacy setting must be turned off!)", True)

        If Not String.IsNullOrEmpty(Master.eSettings.UseTrakt.ToString) Then
            chkUseTrakt.Checked = Master.eSettings.UseTrakt
        End If
        dgvTraktWatched.DataSource = Nothing
        dgvTraktWatched.Rows.Clear()

        If Master.eSettings.UseTrakt = True Then
            txtTraktUser.Enabled = True
            If Not String.IsNullOrEmpty(Master.eSettings.TraktUser) Then
                btGetMoviesTrakt.Enabled = True
            Else
                btGetMoviesTrakt.Enabled = False
            End If
        Else
            btGetMoviesTrakt.Enabled = False
            txtTraktUser.Enabled = False
        End If
    End Sub

    'Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlTrakt.Paint

    'End Sub

    Private Sub chkUseTrakt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseTrakt.CheckedChanged
        If chkUseTrakt.Checked = True Then
            If Not String.IsNullOrEmpty(txtTraktUser.Text) Then
                btGetMoviesTrakt.Enabled = True
            End If
            txtTraktUser.Enabled = True
        Else
            btGetMoviesTrakt.Enabled = False
            txtTraktUser.Enabled = False
        End If
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub txtTraktUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTraktUser.TextChanged
        RaiseEvent ModuleSettingsChanged()
        If Not String.IsNullOrEmpty(txtTraktUser.Text) AndAlso txtTraktUser.Enabled = True Then
            btGetMoviesTrakt.Enabled = True
        Else
            btGetMoviesTrakt.Enabled = False
        End If
    End Sub

    Private Sub btGetMoviesTrakt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGetMoviesTrakt.Click
        dgvTraktWatched.DataSource = Nothing
        dgvTraktWatched.Rows.Clear()
        myWatchedMovies.Clear()

        If Not String.IsNullOrEmpty(txtTraktUser.Text) AndAlso chkUseTrakt.Checked = True Then
            myWatchedMovies = GetWatchedMoviesFromTrakt(txtTraktUser.Text)
        End If
        dgvTraktWatched.AutoGenerateColumns = True
        If Not myWatchedMovies Is Nothing Then
            btSaveMoviesTrakt.Enabled = True
            'we map to dgv manually
            dgvTraktWatched.AutoGenerateColumns = False
            'fill rows
            For Each Item In myWatchedMovies
                    dgvTraktWatched.Rows.Add(New Object() {Item.Key, Item.Value.Value})
                Next
        Else
            btSaveMoviesTrakt.Enabled = False
        End If
    End Sub



    Public Sub SaveChanges()
        Master.eSettings.TraktUser = txtTraktUser.Text
        Master.eSettings.UseTrakt = chkUseTrakt.Checked
        If Not String.IsNullOrEmpty(Master.eSettings.TraktUser) AndAlso Master.eSettings.UseTrakt = True Then
            btGetMoviesTrakt.Enabled = True
        Else
            btGetMoviesTrakt.Enabled = False
        End If
    End Sub

    Private Sub btSaveMoviesTrakt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveMoviesTrakt.Click
        If Not String.IsNullOrEmpty(txtTraktUser.Text) AndAlso chkUseTrakt.Checked = True Then
            If Not myWatchedMovies Is Nothing Then
                prgtrakt.Value = 0
                prgtrakt.Maximum = myWatchedMovies.Count
                prgtrakt.Minimum = 0
                prgtrakt.Step = 1
                btSaveMoviesTrakt.Enabled = False
                Dim traktthread As Threading.Thread
                traktthread = New Threading.Thread(AddressOf SavePlaycount)
                traktthread.IsBackground = True
                traktthread.Start()
            End If

        End If
    End Sub


    'Save plays-information from trakt.tv to database/nfo
    Private Sub SavePlaycount()
        Try

            Dim i As Integer = 0
            For Each watchedMovieData In myWatchedMovies
                i = i + 1
                Master.DB.SaveMoviePlayCountInDatabase(watchedMovieData)
                ' Invoke to update UI from thread...
                prgtrakt.Invoke(New UpdateProgressBarDelegate(AddressOf UpdateProgressBar), i)
                Threading.Thread.Sleep(10)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Delegate Sub UpdateProgressBarDelegate(ByVal i As Integer)
    ' Do all the ui thread updates here
    'Use progressbar to show user progress of saving, since it can take some time
    Private Sub UpdateProgressBar(ByVal i As Integer)
        If i = 1 Then
            lblstate.Visible = False
        End If

        prgtrakt.Value = i

        If i = myWatchedMovies.Count - 1 Then
            lblstate.Text = "Done!"
            lblstate.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' cocotus 2013/02 Trakt.tv syncing
    ''' Connects with trakt.tv Website and gets Watched Movies from specific User and returns them in a List of String (IMDBID)
    ''' More Info here: http://trakt.tv/api-docs/user-library-movies-watched
    ''' </summary>
    ''' <param name="traktID">UserId, necessary to get User specific information</param>
    ''' <returns>3 values in dictionary: IMDBID (ex: tt0114746), Title, Playcount</returns>
    Public Shared Function GetWatchedMoviesFromTrakt(ByVal traktID As String) As Dictionary(Of String, KeyValuePair(Of String, Integer))

        Dim wc As New Net.WebClient
        Try
            'Saving 3 values in Dictionary style
            Dim dictMovieWatched As New Dictionary(Of String, KeyValuePair(Of String, Integer))

            'The REQUEST String (includes API-ID + UserID)
            Dim URL As String = "http://api.trakt.tv/user/library/movies/watched.json/b59a24b6a3fb93fc2fb565a681bb8a1d/" & traktID

            Dim json As String = wc.DownloadString(URL)
            If Not String.IsNullOrEmpty(json) Then

                'Now we are using free  3rd party class/dll to make an easy parse of the json String
                Dim client = New RestSharp.RestClient(URL)
                Dim request = New RestSharp.RestRequest(RestSharp.Method.[GET])
                Dim response = client.Execute(Of List(Of TraktWatchedMovieData))(request)

                If Not response Is Nothing Then
                    'Now loop through to every entry
                    For Each Item As TraktWatchedMovieData In response.Data
                        'Check if information is stored...
                        If Not Item.title Is Nothing AndAlso Item.title <> "" AndAlso Not Item.imdb_id Is Nothing AndAlso Item.imdb_id <> "" Then
                            If Not dictMovieWatched.ContainsKey(Item.title) Then
                                'Now store imdbid, title and playcount information into dictionary (for now no other info needed...)
                                If Item.imdb_id.Length > 2 AndAlso Item.imdb_id.Substring(0, 2) = "tt" Then
                                    'IMDBID beginning with tt -> strip tt first and save only number!
                                    dictMovieWatched.Add(Item.title, New KeyValuePair(Of String, Integer)(Item.imdb_id.Substring(2), CInt(Item.plays)))
                                Else
                                    'IMDBID is alright
                                    dictMovieWatched.Add(Item.title, New KeyValuePair(Of String, Integer)(Item.imdb_id, CInt(Item.plays)))
                                End If
                            End If
                        End If
                    Next
                End If
            End If
            wc.Dispose()
            Return dictMovieWatched

        Catch ex As Exception
            wc.Dispose()
            Return Nothing
        End Try
    End Function


End Class

'New Class which holds/described an item of WatcheMovie on trakt.tv
'Todo Expand class move to seperate project and build wrapper around
Public Class TraktWatchedMovieData
    Private m_title As String
    Public Property title() As String
        Get
            Return m_title
        End Get
        Set(value As String)
            m_title = value
        End Set
    End Property

    Private m_url As String
    Public Property url() As String
        Get
            Return m_url
        End Get
        Set(value As String)
            m_url = value
        End Set
    End Property

    Private m_imdb_id As String
    Public Property imdb_id() As String
        Get
            Return m_imdb_id
        End Get
        Set(value As String)
            m_imdb_id = value
        End Set
    End Property

    Private m_plays As String
    Public Property plays() As String
        Get
            Return m_plays
        End Get
        Set(value As String)
            m_plays = value
        End Set
    End Property

End Class