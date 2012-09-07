Imports System.Windows.Forms

Namespace API

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

    Public Class ListViewColumnSorter
        Implements System.Collections.IComparer

#Region "Fields"

        Private ObjectCompare As CaseInsensitiveComparer        

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            _SortColumn = 0
            _Order = SortOrder.None
            ObjectCompare = New CaseInsensitiveComparer
            _SortByText = False
            _NumericSort = False
        End Sub

#End Region 'Constructors

#Region "Properties"

        Public Property NumericSort() As Boolean            
        Public Property Order() As SortOrder            
        Public Property SortByText() As Boolean            
        Public Property SortColumn() As Integer            

#End Region 'Properties

#Region "Methods"

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim compareResult As Integer
            Dim listviewX As ListViewItem
            Dim listviewY As ListViewItem

            Try
                ' Cast the objects to be compared to ListViewItem objects.
                listviewX = DirectCast(x, ListViewItem)
                listviewY = DirectCast(y, ListViewItem)

                ' Compare the two items.
                If _SortByText Then
                    If _NumericSort Then
                        compareResult = ObjectCompare.Compare(Convert.ToInt32(listviewX.Text.Trim), Convert.ToInt32(listviewY.Text.Trim))
                    Else
                        compareResult = ObjectCompare.Compare(listviewX.Text.Trim, listviewY.Text.Trim)
                    End If
                Else
                    If _NumericSort Then
                        compareResult = ObjectCompare.Compare(Convert.ToInt32(listviewX.SubItems(_SortColumn).Text.Trim), Convert.ToInt32(listviewY.SubItems(_SortColumn).Text.Trim))
                    Else
                        compareResult = ObjectCompare.Compare(listviewX.SubItems(_SortColumn).Text.Trim, listviewY.SubItems(_SortColumn).Text.Trim)
                    End If
                End If

                ' Calculate the correct return value based on the object
                ' comparison.
                If (_Order = SortOrder.Ascending) Then
                    ' Ascending sort is selected, return typical result of
                    ' compare operation.
                    Return compareResult
                ElseIf (_Order = SortOrder.Descending) Then
                    ' Descending sort is selected, return negative result of
                    ' compare operation.
                    Return (-compareResult)
                Else
                    ' Return '0' to indicate that they are equal.
                    Return 0
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error)
                Return 0
            End Try
        End Function

#End Region 'Methods

    End Class
End Namespace