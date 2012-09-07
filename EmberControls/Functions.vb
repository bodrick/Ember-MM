Public Class Functions
    Public Shared Function GetAllControls(Of T)(ByVal searchWithin As Control) As List(Of Control)
        Dim returnList As New List(Of Control)
        If searchWithin.HasChildren = True Then
            For Each ctrl As Control In searchWithin.Controls
                If TypeOf ctrl Is T Then
                    returnList.Add(ctrl)
                End If
                returnList.AddRange(GetAllControls(Of T)(ctrl))
            Next
        ElseIf searchWithin.HasChildren = False Then
            For Each ctrl As Control In searchWithin.Controls
                If TypeOf ctrl Is T Then
                    returnList.Add(ctrl)
                End If
                returnList.AddRange(GetAllControls(Of T)(ctrl))
            Next
        End If
        Return returnList
    End Function
End Class
