Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports SD = System.Drawing


Public NotInheritable Class PhotoUtils

    Private Sub New()
    End Sub
    Public Shared Function Inscribe(ByVal image As Image, ByVal size As Integer) As Image
        Return Inscribe(image, size, size)
    End Function

    Public Shared Function Inscribe(ByVal image As Image, ByVal width As Integer, ByVal height As Integer) As Image
        Dim result As New Bitmap(width, height)
        Using graphics As Graphics = graphics.FromImage(result)
            Dim factor As Double = 1.0 * width / image.Width
            If image.Height * factor < height Then
                factor = 1.0 * height / image.Height
            End If
            Dim size As New Size(CInt(Fix(width / factor)), CInt(Fix(height / factor)))
            Dim sourceLocation As New Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2)

            SmoothGraphics(graphics)
            graphics.DrawImage(image, New Rectangle(0, 0, width, height), New Rectangle(sourceLocation, size), GraphicsUnit.Pixel)
        End Using
        Return result
    End Function
    Public Shared Function InscribeFix(ByVal image As Image, ByVal size As Integer) As Image
        Return Inscribe(image, size, size)
    End Function
    Public Shared Function InscribeFix(ByVal image As Image, ByVal width As Integer, ByVal height As Integer) As Image
        Dim W = width
        Dim H = height
        If width < image.Width Then
            Dim radio As Single = width / image.Width
            W = width
            H = image.Height * radio
        Else
            W = image.Width
            H = image.Height
        End If
        If H > height Then
            Dim radio As Single = height / image.Height
            W = image.Width * radio
            H = height
            'Else
            '    H = image.Height
        End If

        Dim result As New Bitmap(W, H)
        Using graphics As Graphics = graphics.FromImage(result)
            Dim factor As Double = 1.0 * W / image.Width
            If image.Height * factor < H Then
                factor = 1.0 * H / image.Height
            End If
            Dim size As New Size(CInt(Fix(W / factor)), CInt(Fix(H / factor)))
            Dim sourceLocation As New Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2)

            SmoothGraphics(graphics)
            graphics.DrawImage(image, New Rectangle(0, 0, W, H), New Rectangle(sourceLocation, size), GraphicsUnit.Pixel)
        End Using
        Return result
    End Function
    Private Shared Function Crop(ByVal Img As String, ByVal Width As Integer, ByVal Height As Integer, ByVal X As Integer, ByVal Y As Integer) As Byte()
        Try
            Using OriginalImage As SD.Image = SD.Image.FromFile(Img)
                '//
                'Dim newWidth As Single = 200
                'Dim radio As Single = newWidth / Width
                'Dim newHeight As Single = Height * radio
                'Using bmp As New SD.Bitmap(Convert.ToInt32(newWidth), Convert.ToInt32(newHeight))
                'Using bmp As New SD.Bitmap(200, 200)
                '//
                Using bmp As New SD.Bitmap(Width, Height)
                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution)
                    Using Graphic As SD.Graphics = SD.Graphics.FromImage(bmp)
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality
                        Graphic.DrawImage(OriginalImage, New SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, _
                        SD.GraphicsUnit.Pixel)
                        Dim ms As New MemoryStream()
                        bmp.Save(ms, OriginalImage.RawFormat)
                        Return ms.GetBuffer()
                    End Using
                End Using
            End Using
        Catch Ex As Exception
            Throw (Ex)
        End Try
    End Function

    Private Shared Sub SmoothGraphics(ByVal g As Graphics)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
    End Sub

    Public Shared Sub SaveToJpeg(ByVal image As Image, ByVal output As Stream)
        image.Save(output, ImageFormat.Jpeg)
    End Sub

    Public Shared Sub SaveToJpeg(ByVal image As Image, ByVal fileName As String)
        image.Save(fileName, ImageFormat.Jpeg)
    End Sub


End Class


