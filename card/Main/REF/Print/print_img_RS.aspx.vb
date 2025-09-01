Imports Zulu.Data

Imports Zen.Barcode
Imports CrystalDecisions.Shared
Imports System.IO


Partial Class Main_Report_Print_ReportListGroupbyFac
    Inherits System.Web.UI.Page

    Private Function CreateBarcode128(barcodeText) As Byte()

        Dim bdf As Code128BarcodeDraw = BarcodeDrawFactory.Code128WithChecksum

        Dim objBitmap As System.Drawing.Bitmap
        Dim objGraphics As System.Drawing.Graphics
        Dim oColor As System.Drawing.Color

        objBitmap = bdf.Draw(barcodeText, 60)
        objGraphics = System.Drawing.Graphics.FromImage(objBitmap)

        Dim ms = New MemoryStream()
        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Dim bytes = ms.ToArray()

        '  objBitmap.Save(Server.MapPath("test.gif"), System.Drawing.Imaging.ImageFormat.Gif)

        ' Image1.ImageUrl = "test.gif"
        objBitmap.Dispose()
        objGraphics.Dispose()
        Return bytes
    End Function
    Function convertImage(ByVal FilePath)
        Dim fs As New FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim Image As Byte() = New Byte(fs.Length - 1) {}
        fs.Read(Image, 0, Convert.ToInt32(fs.Length))
        fs.Close()
        Return Image
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ID = Request.QueryString("id")
        ID = Replace(ID, "on,", "")
        Using report As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            report.Load(Server.MapPath("print_img_RS.rpt"))
            Dim type = Request.QueryString("type")
            Dim dtb = db.GetDataTable("SELECT * FROM dbo.REF_MATERIAL WHERE MaterialID in (" & ID & ")")
            Dim Err
            If db.IsError(Err) Then
                Response.Write(Err)
                db.Close()
                Exit Sub
            End If

            If dtb.Rows.Count = 0 Then
                Response.Write("ไม่มีข้อมูล")
            Else
                For i As Integer = 0 To dtb.Rows.Count - 1
                    With dtb.Rows(i)
                        If Not System.IO.File.Exists(Server.MapPath("../img/" & .Item("ReciveFile"))) Then
                            .Item("IMG_File_TEMP") = convertImage(Server.MapPath("../img/nophoto.jpg"))
                        Else
                            .Item("IMG_File_TEMP") = convertImage(Server.MapPath("../img/" & .Item("ReciveFile")))
                        End If
                        '.Item("PrintName") = Session("PersonName")
                    End With
                Next
            End If

            report.SetDataSource(dtb)

            report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "")
            report.Clone()
            report.Dispose()
            db.Close()
        End Using
    End Sub
End Class
