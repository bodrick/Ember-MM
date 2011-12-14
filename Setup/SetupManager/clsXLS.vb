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

Public Class FileOfList

#Region "Fields"

    Public Filename As String
    Public Hash As String
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
    Public Command As List(Of InstallCommand)

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

Public Class Settings

    #Region "Fields"

    Public FTPHost As String
    Public FTPPassword As String
    Public FTPUser As String
    Public DbPath As String
    #End Region 'Fields

    #Region "Methods"

    Public Sub Save(ByVal fpath As String)
        Dim xmlSer As New XmlSerializer(GetType(Settings))
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
        Return (Me.Version).CompareTo(other.Version)
    End Function

    #End Region 'Methods

End Class

<XmlRoot("Config")> _
Public Class _LastVersion

    #Region "Fields"

    <XmlArrayItem("File")> _
    Public Modules As New List(Of _Module)

    #End Region 'Fields

    #Region "Methods"

    Public Sub Save(ByVal fpath As String)
        Dim xmlSer As New XmlSerializer(GetType(_LastVersion))
        Using xmlSW As New StreamWriter(fpath)
            xmlSer.Serialize(xmlSW, Me)
        End Using
    End Sub

    #End Region 'Methods

End Class

Public Class _Module
    Implements IComparable(Of Versions)

    #Region "Fields"

    Public Name As String
    Public Platform As String
    Public Version As String

    #End Region 'Fields

    #Region "Methods"

    Public Function CompareTo(ByVal other As Versions) As Integer Implements IComparable(Of Versions).CompareTo
        Return (Me.Version).CompareTo(other.Version)
    End Function

    #End Region 'Methods

End Class