Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class BorderPicturebox
    Inherits PictureBox

    Public Enum PhotoBoxSizeMode
        Normal = PictureBoxSizeMode.Normal
        StretchImage = PictureBoxSizeMode.StretchImage
        AutoSize = PictureBoxSizeMode.AutoSize
        CenterImage = PictureBoxSizeMode.CenterImage
        ScaleImage
    End Enum

    Public Enum ResizeType
        Width
        Height
        Both
    End Enum

    Public Enum TextPosition
        Top
        Bottom
        Middle
    End Enum

    Public Property BorderWidth As Integer = 4
    Public Property BorderColor As Color = Color.LightGray
    Public Property CaptionText As String = String.Empty
    Public Property CaptionFont As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
    Public Property CaptionColor As Color = Color.White    
    Public Property ScaleType As ResizeType = ResizeType.Both
    Public Property EnableOverlays As Boolean = False
    Public Property CaptionPosition As TextPosition = TextPosition.Bottom

    Private _sizeMode As PhotoBoxSizeMode = PhotoBoxSizeMode.ScaleImage
    Private _overlays As OverlayObject()

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
    End Sub

    <Category("Behavior"), Description("Controls how the image is " + "drawn within the control."), DefaultValue(PhotoBoxSizeMode.ScaleImage)> _
    Public Shadows Property SizeMode() As PhotoBoxSizeMode
        Get
            Return _sizeMode
        End Get
        Set(value As PhotoBoxSizeMode)
            _sizeMode = value
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Overlays() As OverlayObject()
        Get            
            Return _overlays
        End Get
        Set(value As OverlayObject())
            _overlays = value            
        End Set
    End Property
        
    Protected Overrides Sub OnPaint(ByVal pe As Windows.Forms.PaintEventArgs)
        If SizeMode = PhotoBoxSizeMode.ScaleImage Then
            MyBase.SizeMode = PictureBoxSizeMode.Normal
        Else
            MyBase.SizeMode = DirectCast(_sizeMode, PictureBoxSizeMode)
        End If
        MyBase.OnPaint(pe)
        If Image IsNot Nothing Then
            pe.Graphics.Clear(BorderColor)
            If SizeMode = PhotoBoxSizeMode.ScaleImage Then
                Dim resizedImage As Image = ResizeImage(Image, Height - (BorderWidth * 2), Width - (BorderWidth * 2), ScaleType)
                If resizedImage IsNot Nothing Then
                    pe.Graphics.DrawImageUnscaled(resizedImage, BorderWidth, BorderWidth)
                    Width = resizedImage.Width + (BorderWidth * 2)
                    Height = resizedImage.Height + (BorderWidth * 2)
                Else
                    pe.Graphics.DrawImageUnscaled(Image, BorderWidth, BorderWidth)
                    Width = Image.Width + (BorderWidth * 2)
                    Height = Image.Height + (BorderWidth * 2)
                End If
            ElseIf SizeMode = PhotoBoxSizeMode.AutoSize Then
                pe.Graphics.DrawImage(Image, BorderWidth, BorderWidth, Image.Width, Image.Height)
                Width = Image.Width + (BorderWidth * 2)
                Height = Image.Height + (BorderWidth * 2)
            Else
                pe.Graphics.DrawImage(Image, BorderWidth, BorderWidth, Image.Width - (BorderWidth * 2), Image.Height - (BorderWidth * 2))
            End If
            If EnableOverlays Then
                DrawOverlays(pe.Graphics)
            End If
            DrawText(pe.Graphics)
        End If
    End Sub

    Private Sub DrawText(ByRef g As Graphics)
        If Not String.IsNullOrEmpty(CaptionText) Then
            Dim strFormat As StringFormat = New StringFormat()
            strFormat.FormatFlags = StringFormatFlags.NoClip + StringFormatFlags.FitBlackBox + StringFormatFlags.LineLimit
            strFormat.Trimming = StringTrimming.None            

            Dim layoutSize As New Size(ClientRectangle.Width - (BorderWidth * 2), ClientRectangle.Height - (BorderWidth * 2))
            Dim drawFontSize As Integer = Math.Floor(BestFontSize(g, layoutSize, CaptionFont, CaptionText))
            Dim drawFont As Font = New Font(CaptionFont.FontFamily, If(drawFontSize > CaptionFont.Size, CaptionFont.Size, drawFontSize), CaptionFont.Style)
            Dim dims As SizeF = g.MeasureString(CaptionText, drawFont, layoutSize.Width, strFormat)
            Dim iLeft As Integer = Math.Floor((Width / 2) - (dims.Width / 2))
            Dim iTop As Integer = 0
            Select Case CaptionPosition
                Case TextPosition.Bottom                    
                    iTop = Height - Math.Ceiling(dims.Height) - BorderWidth
                Case TextPosition.Top
                    iTop = BorderWidth
                Case TextPosition.Middle
                    iTop = (Height / 2) + BorderWidth                    
            End Select

            Dim rect As Rectangle = New Rectangle(iLeft - 12, iTop - 10, dims.Width + 20, dims.Height + 20)
            Dim fontBrush As New SolidBrush(CaptionColor)
            Dim pgBrush As PathGradientBrush
            Dim gPath As New GraphicsPath
            gPath.AddEllipse(rect.X, rect.Y, rect.Width, rect.Height)
            pgBrush = New PathGradientBrush(gPath)
            pgBrush.CenterColor = Color.FromArgb(250, 120, 120, 120)
            pgBrush.SurroundColors = New Color() {Color.FromArgb(0, 255, 255, 255)}
            g.FillEllipse(pgBrush, rect.X, rect.Y, rect.Width, rect.Height)
            g.DrawString(CaptionText, drawFont, fontBrush, iLeft, iTop, strFormat)
        End If
    End Sub

    Private Function BestFontSize(g As Graphics, z As Size, f As Font, s As String) As Single
        Dim p As SizeF = g.MeasureString(s, f)
        Dim hRatio As Single = z.Height / p.Height
        Dim wRatio As Single = z.Width / p.Width
        Dim ratio As Single = Math.Min(hRatio, wRatio)
        Return f.Size * ratio
    End Function

    Protected Overrides Sub OnResize(e As EventArgs)
        If SizeMode = PhotoBoxSizeMode.ScaleImage Then
            Invalidate()
        End If
        ' redraw image
        MyBase.OnResize(e)
    End Sub

    Private Function ResizeImage(objGraphics As Bitmap, maxHeight As Integer, maxWidth As Integer, rType As ResizeType) As Bitmap
        Dim tempImageWidth As Integer = objGraphics.Width
        Dim tempImageHeight As Integer = objGraphics.Height
        Dim resizeFactor As Double
        Select Case rType
            Case ResizeType.Both
                resizeFactor = Math.Max((tempImageWidth + 0.0) / (maxWidth + 0.0), (tempImageHeight + 0.0) / (maxHeight + 0.0))
            Case ResizeType.Height
                resizeFactor = (tempImageHeight + 0.0) / (maxHeight + 0.0)
            Case ResizeType.Width
                resizeFactor = (tempImageWidth + 0.0) / (maxWidth + 0.0)
        End Select
        If resizeFactor > 1.0 Then
            Dim newImage As New Bitmap(CInt(tempImageWidth / resizeFactor), CInt(tempImageHeight / resizeFactor))
            Dim oGraphic As Graphics = Graphics.FromImage(newImage)

            oGraphic.CompositingQuality = CompositingQuality.HighQuality
            oGraphic.SmoothingMode = SmoothingMode.HighQuality
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic
            Dim oRectangle As New Rectangle(0, 0, CInt(tempImageWidth / resizeFactor), CInt(tempImageHeight / resizeFactor))
            oGraphic.DrawImage(objGraphics, oRectangle)
            Return newImage
        End If
        Return Nothing
    End Function

    Private Sub DrawOverlays(ByRef g As Graphics)
        If Overlays IsNot Nothing AndAlso EnableOverlays Then
            For Each overlay In Overlays
                If overlay.OverlayImage IsNot Nothing Then
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic

                    If overlay.Ratio > 0 Then
                        Dim bmHeight As Integer = Convert.ToInt32(Height * overlay.Ratio)
                        g.DrawImage(overlay.OverlayImage, 0, 0, Width, bmHeight)
                    Else
                        g.DrawImage(overlay.OverlayImage, 0, 0, Width, Height)
                    End If
                End If
            Next
        End If
    End Sub

    <TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class OverlayObject
        Public Property OverlayImage As Image
        Public Property Position As Point
        Public Property Ratio As Single = 0.0
    End Class
End Class
