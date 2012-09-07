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
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Text

Namespace API

    Public Class MediaInfo

#Region "Fields"

        Private Handle As IntPtr
        Private UseAnsi As Boolean

#End Region 'Fields

#Region "Enumerations"

        Public Enum InfoKind As UInteger
            Name
            Text
        End Enum

        Public Enum StreamKind As UInteger
            General
            Visual
            Audio
            Text
        End Enum

#End Region 'Enumerations

#Region "Methods"

        Public Shared Function ApplyDefaults(ByVal ext As String, metaDataFileTypes As List(Of Settings.MetadataPerType)) As Fileinfo
            Dim fi As Fileinfo
            For Each m As Settings.MetadataPerType In From m1 In metaDataFileTypes Where m1.FileType = ext
                fi = m.MetaData
                Return fi
            Next
            Return Nothing
        End Function

        Public Shared Sub UpdateMediaInfo(ByRef miMovie As Model.Movie)
            Try
                'DON'T clear it out                
                Dim tinfo As Fileinfo
                Dim pExt As String = Path.GetExtension(miMovie.MoviePath).ToLower
                If Not pExt = ".rar" AndAlso (Master.CanScanDiscImage OrElse Not (pExt = ".iso" OrElse _
                                                                                  pExt = ".img" OrElse pExt = ".bin" OrElse pExt = ".cue" OrElse pExt = ".nrg")) Then
                    Dim MI As New MediaInfo                    
                    tinfo = MI.GetMIFromPath(miMovie.MoviePath, Master.eSettings.FlagLang)
                    If tinfo.StreamDetails.Video.Count > 0 OrElse tinfo.StreamDetails.Audio.Count > 0 OrElse tinfo.StreamDetails.Subtitle.Count > 0 Then
                        ' overwrite only if it get something from Mediainfo
                        miMovie.FileInfo = tinfo
                    End If
                    If miMovie.FileInfo.StreamDetails.Video.Count > 0 AndAlso Master.eSettings.UseMIDuration Then
                        Dim tVid As Video = GetBestVideo(miMovie.FileInfo)
                        If Not String.IsNullOrEmpty(tVid.Duration) Then
                            miMovie.Runtime = FormatDuration(DurationToSeconds(tVid.Duration, True))
                        End If
                    End If
                    MI = Nothing
                End If
                If miMovie.FileInfo.StreamDetails.Video.Count = 0 AndAlso miMovie.FileInfo.StreamDetails.Audio.Count = 0 AndAlso miMovie.FileInfo.StreamDetails.Subtitle.Count = 0 Then
                    Dim _mi As Fileinfo
                    _mi = ApplyDefaults(pExt, Master.eSettings.MetadataPerFileType)
                    If Not _mi Is Nothing Then miMovie.FileInfo = _mi
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Shared Sub UpdateTVMediaInfo(ByRef miTV As Model.TVEp)
            Try
                'clear it out
                miTV.FileInfo = New Fileinfo
                Dim fileName As String = miTV.TVEpPath.FilePath

                Dim pExt As String = Path.GetExtension(fileName).ToLower
                If Not pExt = ".rar" AndAlso (Master.CanScanDiscImage OrElse Not (pExt = ".iso" OrElse _
                                                                                  pExt = ".img" OrElse pExt = ".bin" OrElse pExt = ".cue" OrElse pExt = ".nrg")) Then
                    Dim MI As New MediaInfo
                    miTV.FileInfo = MI.GetMIFromPath(fileName, Master.eSettings.TVFlagLang)
                    MI = Nothing
                End If
                If miTV.FileInfo.StreamDetails.Video.Count = 0 AndAlso miTV.FileInfo.StreamDetails.Audio.Count = 0 AndAlso miTV.FileInfo.StreamDetails.Subtitle.Count = 0 Then
                    Dim _mi As Fileinfo
                    _mi = ApplyDefaults(pExt, Master.eSettings.TVMetadataperFileType)
                    If Not _mi Is Nothing Then miTV.FileInfo = _mi
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Function GetMIFromPath(ByVal sPath As String, ByVal preferredLanguage As String) As Fileinfo
            Dim returnValue As Fileinfo = Nothing
            If Not String.IsNullOrEmpty(sPath) AndAlso File.Exists(sPath) Then
                Dim sExt As String = Path.GetExtension(sPath).ToLower
                Dim fiOut As New Fileinfo
                Dim miVideo As New Video
                Dim miAudio As New Audio
                Dim miSubtitle As New Subtitle
                Dim AudioStreams As Integer
                Dim SubtitleStreams As Integer
                Dim aLang As String = String.Empty
                Dim sLang As String = String.Empty
                Dim cDVD As New DVD

                Dim ifoVideo(2) As String
                Dim ifoAudio(2) As String

                If Master.eSettings.EnableIFOScan AndAlso (sExt = ".ifo" OrElse sExt = ".vob" OrElse sExt = ".bup") AndAlso cDVD.fctOpenIFOFile(sPath) Then
                    Try
                        ifoVideo = cDVD.GetIFOVideo
                        Dim vRes() As String = ifoVideo(1).Split(Convert.ToChar("x"))
                        miVideo.Width = vRes(0)
                        miVideo.Height = vRes(1)
                        miVideo.Codec = ifoVideo(0)
                        miVideo.Duration = cDVD.GetProgramChainPlayBackTime(1)
                        miVideo.Aspect = ifoVideo(2)

                        With miVideo
                            If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Duration) OrElse Not String.IsNullOrEmpty(.Aspect) OrElse _
                               Not String.IsNullOrEmpty(.Height) OrElse Not String.IsNullOrEmpty(.Width) Then
                                fiOut.StreamDetails.Video.Add(miVideo)
                            End If
                        End With

                        AudioStreams = cDVD.GetIFOAudioNumberOfTracks
                        For a As Integer = 1 To AudioStreams
                            miAudio = New Audio
                            ifoAudio = cDVD.GetIFOAudio(a)
                            miAudio.Codec = ifoAudio(0)
                            miAudio.Channels = ifoAudio(2)
                            aLang = ifoAudio(1)
                            If Not String.IsNullOrEmpty(aLang) Then
                                miAudio.LongLanguage = aLang
                                miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                            End If
                            With miAudio
                                If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Channels) OrElse Not String.IsNullOrEmpty(.Language) Then
                                    fiOut.StreamDetails.Audio.Add(miAudio)
                                End If
                            End With
                        Next

                        SubtitleStreams = cDVD.GetIFOSubPicNumberOf
                        For s As Integer = 1 To SubtitleStreams
                            miSubtitle = New Subtitle
                            sLang = cDVD.GetIFOSubPic(s)
                            If Not String.IsNullOrEmpty(sLang) Then
                                miSubtitle.LongLanguage = sLang
                                miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                                miSubtitle.SubsType = "Embedded"
                                If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                                    fiOut.StreamDetails.Subtitle.Add(miSubtitle)
                                End If
                            End If
                        Next

                        cDVD.Close()
                        cDVD = Nothing

                        returnValue = fiOut
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
                    End Try
                ElseIf StringUtils.IsStacked(Path.GetFileNameWithoutExtension(sPath), True) OrElse FileUtils.isVideoTS(sPath) OrElse FileUtils.isBDRip(sPath) Then
                    Try
                        Dim oFile As String = StringUtils.CleanStackingMarkers(sPath, False)
                        Dim sFile As New List(Of String)
                        Dim bIsVTS As Boolean = False

                        If sExt = ".ifo" OrElse sExt = ".bup" OrElse sExt = ".vob" Then
                            bIsVTS = True
                        End If

                        If bIsVTS Then
                            Try
                                sFile.AddRange(Directory.GetFiles(Directory.GetParent(sPath).FullName, "VTS*.VOB"))
                            Catch
                            End Try
                        ElseIf sExt = ".m2ts" Then
                            Try
                                sFile.AddRange(Directory.GetFiles(Directory.GetParent(sPath).FullName, "*.m2ts"))
                            Catch
                            End Try
                        Else
                            Try
                                sFile.AddRange(Directory.GetFiles(Directory.GetParent(sPath).FullName, StringUtils.CleanStackingMarkers(Path.GetFileName(sPath), True)))
                            Catch
                            End Try
                        End If

                        Dim TotalDur As Integer = 0
                        Dim tInfo As New Fileinfo
                        Dim tVideo As New Video
                        Dim tAudio As New Audio

                        miVideo.Width = "0"
                        miAudio.Channels = "0"

                        For Each File As String In sFile
                            'make sure the file is actually part of the stack
                            'handles movie.cd1.ext, movie.cd2.ext and movie.extras.ext
                            'disregards movie.extras.ext in this case
                            If bIsVTS OrElse (oFile = StringUtils.CleanStackingMarkers(File, False)) Then
                                tInfo = ScanMI(File)

                                tVideo = GetBestVideo(tInfo)
                                tAudio = GetBestAudio(tInfo, preferredLanguage)

                                If String.IsNullOrEmpty(miVideo.Codec) OrElse Not String.IsNullOrEmpty(tVideo.Codec) Then
                                    If Not String.IsNullOrEmpty(tVideo.Width) AndAlso Convert.ToInt32(tVideo.Width) >= Convert.ToInt32(miVideo.Width) Then
                                        miVideo = tVideo
                                    End If
                                End If

                                If String.IsNullOrEmpty(miAudio.Codec) OrElse Not String.IsNullOrEmpty(tAudio.Codec) Then
                                    If Not String.IsNullOrEmpty(tAudio.Channels) AndAlso Convert.ToInt32(tAudio.Channels) >= Convert.ToInt32(miAudio.Channels) Then
                                        miAudio = tAudio
                                    End If
                                End If

                                If Not String.IsNullOrEmpty(tVideo.Duration) Then TotalDur += Convert.ToInt32(DurationToSeconds(tVideo.Duration, False))

                                For Each sSub As Subtitle In tInfo.StreamDetails.Subtitle
                                    If Not fiOut.StreamDetails.Subtitle.Contains(sSub) Then
                                        fiOut.StreamDetails.Subtitle.Add(sSub)
                                    End If
                                Next
                            End If
                        Next

                        fiOut.StreamDetails.Video.Add(miVideo)
                        fiOut.StreamDetails.Audio.Add(miAudio)
                        fiOut.StreamDetails.Video(0).Duration = DurationToSeconds(TotalDur.ToString, True)

                        returnValue = fiOut
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
                    End Try
                Else
                    returnValue = ScanMI(sPath)
                End If

                'finally go through all the video streams and reformat the duration
                'we do this afterwards because of scanning mediainfo from stacked files... we need total
                'duration so we need to keep a consistent duration format while scanning
                'it's easier to format at the end so we don't need to bother with creating a generic
                'conversion routine
                If Not IsNothing(returnValue.StreamDetails) AndAlso returnValue.StreamDetails.Video.Count > 0 Then
                    For Each tVid As Video In returnValue.StreamDetails.Video
                        tVid.Duration = DurationToSeconds(tVid.Duration, False)
                    Next
                End If
            End If
            Return returnValue
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfoA_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As UIntPtr, ByVal Parameter As IntPtr, ByVal KindOfInfo As UIntPtr, ByVal KindOfSearch As UIntPtr) As IntPtr
        End Function

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfoA_Open(ByVal Handle As IntPtr, ByVal FileName As IntPtr) As UIntPtr
        End Function

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Sub MediaInfo_Close(ByVal Handle As IntPtr)
        End Sub

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfo_Count_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As IntPtr) As Integer
        End Function

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Sub MediaInfo_Delete(ByVal Handle As IntPtr)
        End Sub

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfo_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As UIntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal Parameter As String, ByVal KindOfInfo As UIntPtr, ByVal KindOfSearch As UIntPtr) As IntPtr
        End Function

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfo_New() As IntPtr
        End Function

        <DllImport("Bin\MediaInfo.DLL")> _
        Private Shared Function MediaInfo_Open(ByVal Handle As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal FileName As String) As UIntPtr
        End Function

        Private Sub Close()
            MediaInfo_Close(Handle)
            MediaInfo_Delete(Handle)
            Handle = Nothing
        End Sub

        Private Function ConvertAFormat(ByVal sFormat As String, Optional ByVal sProfile As String = "") As String
            If Not String.IsNullOrEmpty(sFormat) Then
                Select Case sFormat.ToLower
                    Case "dts", "a_dts"
                        Select Case sProfile.ToUpper
                            Case "MA"   'master audio
                                sFormat = "dtsma"
                            Case "HRA"   'high resolution
                                sFormat = "dtshr"
                        End Select
                End Select
                Return AdvancedSettings.GetSetting(String.Concat("AudioFormatConvert:", sFormat.ToLower), sFormat.ToLower)
                'Return sFormat
            Else
                Return String.Empty
            End If
        End Function

        Private Function ConvertVFormat(ByVal sFormat As String, Optional ByVal sModifier As String = "") As String
            If Not String.IsNullOrEmpty(sFormat) Then
                Dim tFormat As String = sFormat.ToLower
                If tFormat = "mpeg video" Then
                    If sModifier.ToLower = "version 2" Then
                        tFormat = "mpeg2"
                    Else
                        tFormat = "mpeg"
                    End If
                End If
                Return AdvancedSettings.GetSetting(String.Concat("VideoFormatConvert:", tFormat.ToLower), tFormat.ToLower)
            Else
                Return String.Empty
            End If
        End Function

        Private Function Count_Get(ByVal StreamKind As StreamKind, Optional ByVal StreamNumber As UInteger = UInteger.MaxValue) As Integer
            If StreamNumber = UInteger.MaxValue Then
                Return MediaInfo_Count_Get(Handle, CType(StreamKind, UIntPtr), CType(-1, IntPtr))
            Else
                Return MediaInfo_Count_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, IntPtr))
            End If
        End Function

        Private Shared Function DurationToSeconds(ByVal Duration As String, ByVal Reverse As Boolean) As String
            If Not String.IsNullOrEmpty(Duration) Then
                If Reverse Then
                    Dim ts As New TimeSpan(0, 0, Convert.ToInt32(Duration))
                    Return String.Format("{0}h {1}mn {2}s", ts.Hours, ts.Minutes, ts.Seconds)
                Else
                    Dim sDuration As Match = Regex.Match(Duration, "(([0-9]+)h)?\s?(([0-9]+)mn)?\s?(([0-9]+)s)?")
                    Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
                    Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
                    Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
                    Return ((sHour * 60 * 60) + (sMin * 60) + sSec).ToString
                End If
            End If
            Return "0"
        End Function

        Private Function Get_(ByVal StreamKind As StreamKind, ByVal StreamNumber As Integer, ByVal Parameter As String, Optional ByVal KindOfInfo As InfoKind = InfoKind.Text, Optional ByVal KindOfSearch As InfoKind = InfoKind.Name) As String
            If UseAnsi Then
                Dim Parameter_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(Parameter)
                Dim ToReturn As String = Marshal.PtrToStringAnsi(MediaInfoA_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, UIntPtr), Parameter_Ptr, CType(KindOfInfo, UIntPtr), CType(KindOfSearch, UIntPtr)))
                Marshal.FreeHGlobal(Parameter_Ptr)
                Return ToReturn
            Else
                Return Marshal.PtrToStringUni(MediaInfo_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, UIntPtr), Parameter, CType(KindOfInfo, UIntPtr), CType(KindOfSearch, UIntPtr)))
            End If
        End Function

        Private Sub Open(ByVal FileName As String)
            If UseAnsi Then
                Dim FileName_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(FileName)
                MediaInfoA_Open(Handle, FileName_Ptr)
                Marshal.FreeHGlobal(FileName_Ptr)
            Else
                MediaInfo_Open(Handle, FileName)
            End If
        End Sub

        Private Function ScanMI(ByVal sPath As String) As Fileinfo
            Dim fiOut As New Fileinfo
            Try
                If Not String.IsNullOrEmpty(sPath) Then
                    Dim miVideo As New Video
                    Dim miAudio As New Audio
                    Dim miSubtitle As New Subtitle
                    Dim VideoStreams As Integer
                    Dim AudioStreams As Integer
                    Dim SubtitleStreams As Integer
                    Dim vLang As String = String.Empty
                    Dim aLang As String = String.Empty
                    Dim sLang As String = String.Empty
                    Dim a_Profile As String = String.Empty

                    Me.Handle = MediaInfo_New()

                    If Master.isWindows Then
                        UseAnsi = False
                    Else
                        UseAnsi = True
                    End If

                    Me.Open(sPath)

                    VideoStreams = Me.Count_Get(StreamKind.Visual)
                    Dim vCodec As String = String.Empty
                    For v As Integer = 0 To VideoStreams - 1
                        miVideo = New Video
                        miVideo.Width = Me.Get_(StreamKind.Visual, v, "Width")
                        miVideo.Height = Me.Get_(StreamKind.Visual, v, "Height")
                        miVideo.Codec = ConvertVFormat(Me.Get_(StreamKind.Visual, v, "CodecID/Hint"))
                        If String.IsNullOrEmpty(miVideo.Codec) OrElse IsNumeric(miVideo.Codec) Then
                            vCodec = ConvertVFormat(Me.Get_(StreamKind.Visual, v, "CodecID"))
                            If IsNumeric(vCodec) OrElse String.IsNullOrEmpty(vCodec) Then
                                miVideo.Codec = ConvertVFormat(Me.Get_(StreamKind.Visual, v, "Format"), Me.Get_(StreamKind.Visual, v, "Format_Version"))
                            Else
                                miVideo.Codec = vCodec
                            End If
                        End If

                        miVideo.Duration = Me.Get_(StreamKind.Visual, v, "Duration/String1")
                        miVideo.Aspect = Me.Get_(StreamKind.Visual, v, "DisplayAspectRatio")
                        miVideo.Scantype = Me.Get_(StreamKind.Visual, v, "ScanType")
                        With miVideo
                            If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Duration) OrElse Not String.IsNullOrEmpty(.Aspect) OrElse _
                               Not String.IsNullOrEmpty(.Height) OrElse Not String.IsNullOrEmpty(.Width) OrElse Not String.IsNullOrEmpty(.Scantype) Then
                                fiOut.StreamDetails.Video.Add(miVideo)
                            End If
                        End With
                        vLang = Me.Get_(StreamKind.Visual, v, "Language/String")
                        If Not String.IsNullOrEmpty(vLang) Then
                            miVideo.LongLanguage = vLang
                            miVideo.Language = Localization.ISOLangGetCode3ByLang(miVideo.LongLanguage)
                        End If
                    Next

                    AudioStreams = Me.Count_Get(StreamKind.Audio)
                    Dim aCodec As String
                    For a As Integer = 0 To AudioStreams - 1
                        miAudio = New Audio
                        a_Profile = Me.Get_(StreamKind.Audio, a, "Format_Profile")
                        miAudio.Codec = ConvertAFormat(Me.Get_(StreamKind.Audio, a, "CodecID/Hint"), a_Profile)
                        If String.IsNullOrEmpty(miAudio.Codec) OrElse IsNumeric(miAudio.Codec) Then
                            aCodec = ConvertAFormat(Me.Get_(StreamKind.Audio, a, "CodecID"), a_Profile)
                            miAudio.Codec = If(IsNumeric(aCodec) OrElse String.IsNullOrEmpty(aCodec), ConvertAFormat(Me.Get_(StreamKind.Audio, a, "Format"), a_Profile), aCodec)
                        End If
                        miAudio.Channels = Me.Get_(StreamKind.Audio, a, "Channel(s)")
                        aLang = Me.Get_(StreamKind.Audio, a, "Language/String")
                        If Not String.IsNullOrEmpty(aLang) Then
                            miAudio.LongLanguage = aLang                            
                            miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                        End If
                        With miAudio
                            If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Channels) OrElse Not String.IsNullOrEmpty(.Language) Then
                                fiOut.StreamDetails.Audio.Add(miAudio)
                            End If
                        End With
                    Next

                    SubtitleStreams = Me.Count_Get(StreamKind.Text)
                    For s As Integer = 0 To SubtitleStreams - 1
                        miSubtitle = New MediaInfo.Subtitle
                        sLang = Me.Get_(StreamKind.Text, s, "Language/String")
                        If Not String.IsNullOrEmpty(sLang) Then
                            miSubtitle.LongLanguage = sLang
                            miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                            miSubtitle.SubsType = "Embedded"
                        End If
                        If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                            fiOut.StreamDetails.Subtitle.Add(miSubtitle)
                        End If
                    Next

                    Me.Close()
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error", False)
            End Try
            Return fiOut
        End Function

        Private Shared Function FormatDuration(ByVal tDur As String) As String
            Dim sDuration As Match = Regex.Match(tDur, "(([0-9]+)h)?\s?(([0-9]+)mn)?\s?(([0-9]+)s)?")
            Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
            Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
            Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
            Dim sMask As String = Master.eSettings.RuntimeMask
            'Dim sRuntime As String = String.Empty

            If sMask.Contains("<h>") Then
                If sMask.Contains("<m>") OrElse sMask.Contains("<0m>") Then
                    If sMask.Contains("<s>") OrElse sMask.Contains("<0s>") Then
                        Return sMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00")).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
                    Else
                        Return sMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00"))
                    End If
                Else
                    Dim tHDec As String = If(sMin > 0, Convert.ToSingle(1 / (60 / sMin)).ToString(".00"), String.Empty)
                    Return sMask.Replace("<h>", String.Concat(sHour, tHDec))
                End If
            ElseIf sMask.Contains("<m>") Then
                If sMask.Contains("<s>") OrElse sMask.Contains("<0s>") Then
                    Return sMask.Replace("<m>", ((sHour * 60) + sMin).ToString).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
                Else
                    Return sMask.Replace("<m>", ((sHour * 60) + sMin).ToString)
                End If
            ElseIf sMask.Contains("<s>") Then
                Return sMask.Replace("<s>", ((sHour * 60 * 60) + sMin * 60 + sSec).ToString)
            Else
                Return sMask
            End If
        End Function

        Public Shared Function FIToString(ByVal miFI As Fileinfo) As String
            '//
            ' Convert Fileinfo into a string to be displayed in the GUI
            '\\

            Dim strOutput As New StringBuilder
            Dim iVS As Integer = 1
            Dim iAS As Integer = 1
            Dim iSS As Integer = 1

            Try
                If Not IsNothing(miFI) Then

                    If Not IsNothing(miFI.StreamDetails) Then
                        If miFI.StreamDetails.Video.Count > 0 Then
                            strOutput.AppendFormat("{0}: {1}{2}", Languages.Video_Streams, miFI.StreamDetails.Video.Count.ToString, vbNewLine)
                        End If

                        If miFI.StreamDetails.Audio.Count > 0 Then
                            strOutput.AppendFormat("{0}: {1}{2}", Languages.Audio_Streams, miFI.StreamDetails.Audio.Count.ToString, vbNewLine)
                        End If

                        If miFI.StreamDetails.Subtitle.Count > 0 Then
                            strOutput.AppendFormat("{0}: {1}{2}", Languages.Subtitle_Streams, miFI.StreamDetails.Subtitle.Count.ToString, vbNewLine)
                        End If

                        For Each miVideo As MediaInfo.Video In miFI.StreamDetails.Video
                            strOutput.AppendFormat("{0}{1} {2}{0}", vbNewLine, Languages.Video_Stream, iVS)
                            If Not String.IsNullOrEmpty(miVideo.Width) AndAlso Not String.IsNullOrEmpty(miVideo.Height) Then
                                strOutput.AppendFormat("- {0}{1}", String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), miVideo.Width, miVideo.Height), vbNewLine)
                            End If
                            If Not String.IsNullOrEmpty(miVideo.Aspect) Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(614, "Aspect Ratio"), miVideo.Aspect, vbNewLine)
                            If Not String.IsNullOrEmpty(miVideo.Scantype) Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(605, "Scan Type"), miVideo.Scantype, vbNewLine)
                            If Not String.IsNullOrEmpty(miVideo.Codec) Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(604, "Codec"), miVideo.Codec, vbNewLine)
                            If Not String.IsNullOrEmpty(miVideo.Duration) Then strOutput.AppendFormat("- {0}: {1}", Master.eLang.GetString(609, "Duration"), miVideo.Duration)
                            If Not String.IsNullOrEmpty(miVideo.LongLanguage) Then strOutput.AppendFormat("{0}- {1}: {2}", vbNewLine, Master.eLang.GetString(610, "Language"), miVideo.LongLanguage)
                            iVS += 1
                        Next

                        strOutput.Append(vbNewLine)

                        For Each miAudio As MediaInfo.Audio In miFI.StreamDetails.Audio
                            'audio
                            strOutput.AppendFormat("{0}{1} {2}{0}", vbNewLine, Master.eLang.GetString(618, "Audio Stream"), iAS.ToString)
                            If Not String.IsNullOrEmpty(miAudio.Codec) Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(604, "Codec"), miAudio.Codec, vbNewLine)
                            If Not String.IsNullOrEmpty(miAudio.Channels) Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(611, "Channels"), miAudio.Channels, vbNewLine)
                            If Not String.IsNullOrEmpty(miAudio.LongLanguage) Then strOutput.AppendFormat("- {0}: {1}", Master.eLang.GetString(610, "Language"), miAudio.LongLanguage)
                            iAS += 1
                        Next

                        strOutput.Append(vbNewLine)

                        For Each miSub As MediaInfo.Subtitle In miFI.StreamDetails.Subtitle
                            'subtitles
                            strOutput.AppendFormat("{0}{1} {2}{0}", vbNewLine, Master.eLang.GetString(619, "Subtitle Stream"), iSS.ToString)
                            If Not String.IsNullOrEmpty(miSub.LongLanguage) Then strOutput.AppendFormat("- {0}: {1}", Master.eLang.GetString(610, "Language"), miSub.LongLanguage)
                            iSS += 1
                        Next
                    End If
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try

            If strOutput.ToString.Trim.Length > 0 Then
                Return strOutput.ToString
            Else
                Return Master.eLang.GetString(504, "Meta Data is not available. Try rescanning.")
            End If
        End Function

        Public Shared Function GetBestAudio(ByVal miFIA As Fileinfo, ByVal preferredLanguage As String) As Audio
            '//
            ' Get the highest values from file info
            '\\

            Dim fiaOut As New Audio
            Try
                Dim sinMostChannels As Single = 0
                Dim sinChans As Single

                fiaOut.Codec = String.Empty
                fiaOut.Channels = String.Empty
                fiaOut.Language = String.Empty

                For Each miAudio As MediaInfo.Audio In miFIA.StreamDetails.Audio
                    If Not String.IsNullOrEmpty(miAudio.Channels) Then
                        sinChans = NumUtils.ConvertToSingle(miAudio.Channels)
                        If sinChans > sinMostChannels Then
                            sinMostChannels = sinChans
                            fiaOut.Codec = miAudio.Codec
                            fiaOut.Channels = sinChans.ToString
                            fiaOut.Language = miAudio.Language
                        End If
                    End If
                    If Not String.IsNullOrEmpty(preferredLanguage) AndAlso miAudio.LongLanguage.ToLower = preferredLanguage.ToLower Then fiaOut.HasPreferred = True
                Next

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
            Return fiaOut
        End Function

        Public Shared Function GetBestVideo(ByVal miFIV As Fileinfo) As Video
            '//
            ' Get the highest values from file info
            '\\

            Dim fivOut As New Video
            Try
                Dim iWidest As Integer = 0
                Dim iWidth As Integer = 0

                'set some defaults to make it easy on ourselves
                fivOut.Width = String.Empty
                fivOut.Height = String.Empty
                fivOut.Aspect = String.Empty
                fivOut.Codec = String.Empty
                fivOut.Duration = String.Empty
                fivOut.Scantype = String.Empty
                fivOut.Language = String.Empty

                For Each miVideo As Video In miFIV.StreamDetails.Video
                    If Not String.IsNullOrEmpty(miVideo.Width) Then
                        iWidth = Convert.ToInt32(miVideo.Width)
                        If iWidth > iWidest Then
                            iWidest = iWidth
                            fivOut.Width = miVideo.Width
                            fivOut.Height = miVideo.Height
                            fivOut.Aspect = miVideo.Aspect
                            fivOut.Codec = miVideo.Codec
                            fivOut.Duration = miVideo.Duration
                            fivOut.Scantype = miVideo.Scantype
                            fivOut.Language = miVideo.Language
                        End If
                    End If
                Next

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try
            Return fivOut
        End Function

        Public Shared Function GetDimensionsFromVideo(ByVal fiRes As Video) As String
            '//
            ' Get the dimension values of the video from the information provided by MediaInfo.dll
            '\\

            Dim result As String = String.Empty
            Try
                If Not String.IsNullOrEmpty(fiRes.Width) AndAlso Not String.IsNullOrEmpty(fiRes.Height) AndAlso Not String.IsNullOrEmpty(fiRes.Aspect) Then
                    Dim iWidth As Integer = Convert.ToInt32(fiRes.Width)
                    Dim iHeight As Integer = Convert.ToInt32(fiRes.Height)
                    Dim sinADR As Single = NumUtils.ConvertToSingle(fiRes.Aspect)

                    result = String.Format("{0}x{1} ({2})", iWidth, iHeight, sinADR.ToString("0.00"))
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try

            Return result
        End Function

        Public Shared Function GetResFromDimensions(ByVal fiRes As MediaInfo.Video) As String
            '//
            ' Get the resolution of the video from the dimensions provided by MediaInfo.dll
            '\\

            Dim resOut As String = String.Empty
            Try
                If Not String.IsNullOrEmpty(fiRes.Width) AndAlso Not String.IsNullOrEmpty(fiRes.Height) AndAlso Not String.IsNullOrEmpty(fiRes.Aspect) Then
                    Dim iWidth As Integer = Convert.ToInt32(fiRes.Width)
                    Dim iHeight As Integer = Convert.ToInt32(fiRes.Height)
                    Dim sinADR As Single = NumUtils.ConvertToSingle(fiRes.Aspect)

                    Select Case True
                        Case iWidth < 640
                            resOut = "SD"
                            'exact
                        Case (iWidth = 1920 AndAlso (iHeight = 1080 OrElse iHeight = 800)) OrElse (iWidth = 1440 AndAlso iHeight = 1080) OrElse (iWidth = 1280 AndAlso iHeight = 1080)
                            resOut = "1080"
                        Case (iWidth = 1366 AndAlso iHeight = 768) OrElse (iWidth = 1024 AndAlso iHeight = 768)
                            resOut = "768"
                        Case (iWidth = 960 AndAlso iHeight = 720) OrElse (iWidth = 1280 AndAlso (iHeight = 720 OrElse iHeight = 544))
                            resOut = "720"
                        Case (iWidth = 1024 AndAlso iHeight = 576) OrElse (iWidth = 720 AndAlso iHeight = 576)
                            resOut = "576"
                        Case (iWidth = 720 OrElse iWidth = 960) AndAlso iHeight = 540
                            resOut = "540"
                        Case (iWidth = 852 OrElse iWidth = 720 OrElse iWidth = 704 OrElse iWidth = 640) AndAlso iHeight = 480
                            resOut = "480"
                            'by ADR
                        Case sinADR >= 1.4 AndAlso iWidth = 1920
                            resOut = "1080"
                        Case sinADR >= 1.4 AndAlso iWidth = 1366
                            resOut = "768"
                        Case sinADR >= 1.4 AndAlso iWidth = 1280
                            resOut = "720"
                        Case sinADR >= 1.4 AndAlso iWidth = 1024
                            resOut = "576"
                        Case sinADR >= 1.4 AndAlso iWidth = 960
                            resOut = "540"
                        Case sinADR >= 1.4 AndAlso iWidth = 852
                            resOut = "480"
                            'loose
                        Case iWidth >= 1200 AndAlso iHeight > 768
                            resOut = "1080"
                        Case iWidth >= 1000 AndAlso iHeight > 720
                            resOut = "768"
                        Case iWidth >= 1000 AndAlso iHeight > 500
                            resOut = "720"
                        Case iWidth >= 700 AndAlso iHeight > 540
                            resOut = "576"
                        Case iWidth >= 700 AndAlso iHeight > 480
                            resOut = "540"
                        Case Else
                            resOut = "480"
                    End Select
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
            End Try

            If Not String.IsNullOrEmpty(resOut) Then
                If String.IsNullOrEmpty(fiRes.Scantype) Then
                    Return String.Concat(resOut)
                Else
                    Return String.Concat(resOut, If(fiRes.Scantype.ToLower = "progressive", "p", "i"))
                End If
            Else
                Return String.Empty
            End If
        End Function

#End Region 'Methods

#Region "Nested Types"

        Public Class Audio

#Region "Fields"

            Private _channels As String = String.Empty
            Private _codec As String = String.Empty
            Private _haspreferred As Boolean = False
            Private _language As String = String.Empty
            Private _longlanguage As String = String.Empty

#End Region 'Fields

#Region "Properties"

            <XmlElement("channels")> _
            Public Property Channels() As String
                Get
                    Return Me._channels
                End Get
                Set(ByVal Value As String)
                    Me._channels = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property ChannelsSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._channels)
                End Get
            End Property

            <XmlElement("codec")> _
            Public Property Codec() As String
                Get
                    Return Me._codec
                End Get
                Set(ByVal Value As String)
                    Me._codec = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property CodecSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._codec)
                End Get
            End Property

            <XmlIgnore()> _
            Public Property HasPreferred() As Boolean
                Get
                    Return Me._haspreferred
                End Get
                Set(ByVal value As Boolean)
                    Me._haspreferred = value
                End Set
            End Property

            <XmlElement("language")> _
            Public Property Language() As String
                Get
                    Return Me._language
                End Get
                Set(ByVal Value As String)
                    Me._language = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._language)
                End Get
            End Property

            <XmlElement("longlanguage")> _
            Public Property LongLanguage() As String
                Get
                    Return Me._longlanguage
                End Get
                Set(ByVal value As String)
                    Me._longlanguage = value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LongLanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._longlanguage)
                End Get
            End Property

#End Region 'Properties

        End Class

        <XmlRoot("fileinfo")> _
        Public Class Fileinfo

#Region "Fields"

            Private _streamdetails As New StreamData

#End Region 'Fields

#Region "Properties"

            <XmlIgnore()> _
            Public ReadOnly Property StreamDetailsSpecified() As Boolean
                Get
                    Return (Not IsNothing(_streamdetails.Video) AndAlso _streamdetails.Video.Count > 0) OrElse _
                           (Not IsNothing(_streamdetails.Audio) AndAlso _streamdetails.Audio.Count > 0) OrElse _
                           (Not IsNothing(_streamdetails.Subtitle) AndAlso _streamdetails.Subtitle.Count > 0)
                End Get
            End Property

            <XmlElement("streamdetails")> _
            Property StreamDetails() As StreamData
                Get
                    Return _streamdetails
                End Get
                Set(ByVal value As StreamData)
                    _streamdetails = value
                End Set
            End Property

#End Region 'Properties

        End Class

        <XmlRoot("streamdata")> _
        Public Class StreamData

#Region "Fields"

            Private _audio As New List(Of Audio)
            Private _subtitle As New List(Of Subtitle)
            Private _video As New List(Of Video)

#End Region 'Fields

#Region "Properties"

            <XmlElement("audio")> _
            Public Property Audio() As List(Of Audio)
                Get
                    Return Me._audio
                End Get
                Set(ByVal Value As List(Of Audio))
                    Me._audio = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property AudioSpecified() As Boolean
                Get
                    Return Me._audio.Count > 0
                End Get
            End Property

            <XmlElement("subtitle")> _
            Public Property Subtitle() As List(Of Subtitle)
                Get
                    Return Me._subtitle
                End Get
                Set(ByVal Value As List(Of Subtitle))
                    Me._subtitle = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property SubtitleSpecified() As Boolean
                Get
                    Return Me._subtitle.Count > 0
                End Get
            End Property

            <XmlElement("video")> _
            Public Property Video() As List(Of Video)
                Get
                    Return Me._video
                End Get
                Set(ByVal Value As List(Of Video))
                    Me._video = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property VideoSpecified() As Boolean
                Get
                    Return Me._video.Count > 0
                End Get
            End Property

#End Region 'Properties

        End Class

        Public Class Subtitle

#Region "Fields"

            Private _language As String = String.Empty
            Private _longlanguage As String = String.Empty
            Private _subs_path As String = String.Empty
            Private _subs_type As String = String.Empty

#End Region 'Fields

#Region "Properties"

            <XmlElement("language")> _
            Public Property Language() As String
                Get
                    Return Me._language
                End Get
                Set(ByVal Value As String)
                    Me._language = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._language)
                End Get
            End Property

            <XmlElement("longlanguage")> _
            Public Property LongLanguage() As String
                Get
                    Return Me._longlanguage
                End Get
                Set(ByVal value As String)
                    Me._longlanguage = value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LongLanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._longlanguage)
                End Get
            End Property

            <XmlIgnore()> _
            Public Property SubsPath() As String
                Get
                    Return _subs_path
                End Get
                Set(ByVal value As String)
                    _subs_path = value
                End Set
            End Property

            <XmlIgnore()> _
            Public Property SubsType() As String
                Get
                    Return _subs_type
                End Get
                Set(ByVal value As String)
                    _subs_type = value
                End Set
            End Property

#End Region 'Properties

        End Class

        Public Class Video

#Region "Fields"

            Private _aspect As String = String.Empty
            Private _codec As String = String.Empty
            Private _duration As String = String.Empty
            Private _durationinseconds As String = String.Empty
            Private _height As String = String.Empty
            Private _language As String = String.Empty
            Private _longlanguage As String = String.Empty
            Private _scantype As String = String.Empty
            Private _width As String = String.Empty

#End Region 'Fields

#Region "Properties"

            <XmlElement("aspect")> _
            Public Property Aspect() As String
                Get
                    Return Me._aspect
                End Get
                Set(ByVal Value As String)
                    Me._aspect = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property AspectSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._aspect)
                End Get
            End Property

            <XmlElement("codec")> _
            Public Property Codec() As String
                Get
                    Return Me._codec
                End Get
                Set(ByVal Value As String)
                    Me._codec = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property CodecSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._codec)
                End Get
            End Property

            <XmlElement("durationinseconds")> _
            Public Property Duration() As String
                Get
                    Return Me._duration
                End Get
                Set(ByVal Value As String)
                    Me._duration = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property DurationSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._duration)
                End Get
            End Property

            <XmlElement("height")> _
            Public Property Height() As String
                Get
                    Return Me._height
                End Get
                Set(ByVal Value As String)
                    Me._height = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property HeightSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._height)
                End Get
            End Property

            <XmlElement("language")> _
            Public Property Language() As String
                Get
                    Return Me._language
                End Get
                Set(ByVal Value As String)
                    Me._language = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._language)
                End Get
            End Property

            <XmlElement("longlanguage")> _
            Public Property LongLanguage() As String
                Get
                    Return Me._longlanguage
                End Get
                Set(ByVal value As String)
                    Me._longlanguage = value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property LongLanguageSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._longlanguage)
                End Get
            End Property

            <XmlElement("scantype")> _
            Public Property Scantype() As String
                Get
                    Return Me._scantype
                End Get
                Set(ByVal Value As String)
                    Me._scantype = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property ScantypeSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._scantype)
                End Get
            End Property

            <XmlElement("width")> _
            Public Property Width() As String
                Get
                    Return Me._width
                End Get
                Set(ByVal Value As String)
                    Me._width = Value
                End Set
            End Property

            <XmlIgnore()> _
            Public ReadOnly Property WidthSpecified() As Boolean
                Get
                    Return Not String.IsNullOrEmpty(Me._width)
                End Get
            End Property

#End Region 'Properties

        End Class

#End Region 'Nested Types

    End Class
End Namespace