Imports System.IO
Imports EmberMediaManger.API
Imports System.Drawing.Imaging

Namespace Classes
    Public Class Images
        Public Shared Function FromFile(ByVal sPath As String) As Image
            Dim returnValue As Image = Nothing
            If Not String.IsNullOrEmpty(sPath) AndAlso File.Exists(sPath) Then
                Try
                    returnValue = Image.FromFile(sPath)                    
                Catch ex As Exception
                    Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, Languages._Error & sPath)
                End Try
            End If
            Return returnValue
        End Function

        Public Shared Function GrayscaleImage(img As Image) As Image
            Dim bm As Bitmap = New Bitmap(img.Width, img.Height)
            Dim g As Graphics = Graphics.FromImage(bm)
            Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
                 {New Single() {0.3, 0.3, 0.3, 0, 0}, _
                New Single() {0.59, 0.59, 0.59, 0, 0}, _
                New Single() {0.11, 0.11, 0.11, 0, 0}, _
                New Single() {0, 0, 0, 1, 0}, _
                New Single() {0, 0, 0, 0, 1}})

            Dim ia As ImageAttributes = New ImageAttributes()
            ia.SetColorMatrix(cm)
            g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
            g.Dispose()
            Return bm            
        End Function
    End Class
End Namespace
