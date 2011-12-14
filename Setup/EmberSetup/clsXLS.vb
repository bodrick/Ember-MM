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

Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Web

Public Class FileOfList

    #Region "Fields"

    Public Filename As String
    Public Hash As String
    Public inCache As Boolean = False
    Public NeedBackup As Boolean = False
    Public NeedInstall As Boolean = True
    Public Path As String
    Public Platform As String

    #End Region 'Fields

End Class

<XmlRoot("UpgradeFile")> _
Public Class FilesList

    #Region "Fields"

    <XmlArray("Files")> _
    <XmlArrayItem("File")> _
    Public Files As List(Of FileOfList)

    #End Region 'Fields

    #Region "Methods"

    Public Sub ConvertToPlatform()
        If Not Files Is Nothing Then
            For Each f As FileOfList In Files
                f.Path = f.Path.Replace("\", Path.DirectorySeparatorChar)
            Next
        End If
    End Sub

    Public Sub Save(ByVal fpath As String)
        Dim xmlSer As New XmlSerializer(GetType(FilesList))
        Using xmlSW As New StreamWriter(fpath)
            xmlSer.Serialize(xmlSW, Me)
        End Using
    End Sub

    #End Region 'Methods

End Class

Public Class FileToInstall

    #Region "Fields"

    Public EmberPath As String
    Public Filename As String
    Public Hash As String
    Public OriginalPath As String
    Public Platform As String

    #End Region 'Fields

End Class

Public Class InstallCommand

    #Region "Fields"

    <XmlElement("Description")> _
    Public CommandDescription As String
    <XmlElement("Execute")> _
    Public CommandExecute As String
    <XmlAttribute("Type")> _
    Public CommandType As String

    #End Region 'Fields

End Class

<XmlRoot("CommandFile")> _
Public Class InstallCommands

    #Region "Fields"

    <XmlArray("Commands")> _
    <XmlArrayItem("Command")> _
    Public Command As New List(Of InstallCommand)

    #End Region 'Fields

    #Region "Methods"

    Public Sub Save(ByVal fpath As String)
        Dim xmlSer As New XmlSerializer(GetType(InstallCommands))
        Using xmlSW As New StreamWriter(fpath)
            xmlSer.Serialize(xmlSW, Me)
        End Using
    End Sub

    #End Region 'Methods

End Class

<XmlRoot("VersionsFile")> _
Public Class UpgradeList

    #Region "Fields"

    <XmlArray("Versions")> _
    <XmlArrayItem("Version")> _
    Public VersionList As New List(Of Versions)

    #End Region 'Fields

    #Region "Methods"

    Public Sub Save(ByVal fpath As String)
        Dim xmlSer As New XmlSerializer(GetType(UpgradeList))
        Using xmlSW As New StreamWriter(fpath)
            xmlSer.Serialize(xmlSW, Me)
        End Using
    End Sub

    #End Region 'Methods

End Class

Public Class Versions
    Implements IComparable(Of Versions)

    #Region "Fields"

    <XmlAttribute("Number")> _
    Public Version As String

    #End Region 'Fields

    #Region "Methods"

    Public Function CompareTo(ByVal other As Versions) As Integer Implements IComparable(Of Versions).CompareTo
        Return Convert.ToInt32(Me.Version).CompareTo(Convert.ToInt32(other.Version))
    End Function

    #End Region 'Methods

End Class

Public Class Langs
    Private Shared htStrings As New Hashtable

    Public lLanguages As New List(Of LanguageList)
    Public Function GetString(ByVal ID As Integer, ByVal strDefault As String) As String
        Try
            If IsNothing(htStrings) Then
                Return strDefault
            End If
            If htStrings.ContainsKey(ID) Then
                Return htStrings.Item(ID).ToString
            Else
                Return strDefault
            End If
        Catch ex As Exception
        End Try
        Return strDefault
    End Function
    Public Function LangExist(ByVal Language As String) As String
        Dim lPath As String = String.Empty
        Try
            lPath = Path.Combine(frmMainSetup.AppPath, String.Format("Setup.{0}.xml", Language))
            If Not File.Exists(lPath) Then
                frmMainSetup.GetURLFile("Setup/" & String.Format("Setup.{0}.xml", System.Web.HttpUtility.HtmlEncode(Language)), lPath)
            End If
            If Not File.Exists(lPath) Then
                lPath = String.Empty
            End If
        Catch ex As Exception
        End Try

        Return lPath
    End Function

    Public Sub LoadLanguage(ByVal Language As String)
        Dim lPath As String = String.Empty
        Dim lhPath As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(Language) Then

                htStrings = New Hashtable
                htStrings.Clear()

                lPath = LangExist(Language)
                If Not String.IsNullOrEmpty(lPath) AndAlso File.Exists(lPath) Then
                    Dim LangXML As XDocument = XDocument.Load(lPath)
                    Dim xLanguage = From xLang In LangXML...<strings>...<string> Select xLang.@id, xLang.Value
                    If xLanguage.Count > 0 Then
                        For i As Integer = 0 To xLanguage.Count - 1
                            htStrings.Add(Convert.ToInt32(xLanguage(i).id), xLanguage(i).Value)
                        Next
                    Else
                    End If
                Else
                    'MsgBox(String.Concat(String.Format("Cannot find {0}.xml.", Language), vbNewLine, vbNewLine, "Expected path:", vbNewLine, lPath), MsgBoxStyle.Critical, "File Not Found")
                End If
            End If

        Catch ex As Exception
            'Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub
    Public Sub Save()
        Try
            Dim xmlSer As New XmlSerializer(GetType(List(Of LanguageList)))
            Using xmlSW As New StreamWriter(Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml"))
                xmlSer.Serialize(xmlSW, lLanguages)
            End Using

        Catch ex As Exception
        End Try
    End Sub
    Public Sub Load()
        Try
            If File.Exists(Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml")) Then
                Dim xmlSer As New XmlSerializer(GetType(List(Of LanguageList)))
                Using xmlSW As New StreamReader(Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml"))
                    lLanguages = xmlSer.Deserialize(xmlSW)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetFromSite()
        frmMainSetup.GetURLFile("setup/Setup.Languages.xml", Path.Combine(frmMainSetup.AppPath, "Setup.Languages.xml"))
    End Sub
    Public Class LanguageList
        Public Name As String
        Public Filename As String
    End Class
End Class