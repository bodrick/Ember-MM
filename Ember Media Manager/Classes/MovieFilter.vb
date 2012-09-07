Imports System.Data.Objects
Imports BrightIdeasSoftware

Namespace Classes
    Public Class MovieFilter
        Implements IModelFilter

        Public Property FilterText As String
        Public Property FilterType As FilterTypeEnum
        Public Enum FilterTypeEnum
            Title
            Actor
            Director            
        End Enum

        Public Function IModelFilter_Filter(ByVal modelObject As Object) As Boolean Implements IModelFilter.Filter
            Select Case ObjectContext.GetObjectType(modelObject.GetType())
                Case GetType(Model.Movie)
                    Dim currentMovie = DirectCast(modelObject, Model.Movie)
                    Select Case FilterType
                        Case FilterTypeEnum.Actor
                            If currentMovie.MoviesActors.Where(Function(f) f.ActorName.Contains(_FilterText)).Count > 0 Then
                                Return True
                            End If
                        Case FilterTypeEnum.Director
                            If currentMovie.Director.Contains(_FilterText) Then
                                Return True
                            End If
                        Case FilterTypeEnum.Title
                            If currentMovie.Title.Contains(_FilterText) Then
                                Return True
                            End If
                    End Select
            End Select
            Return False
        End Function
    End Class
End Namespace