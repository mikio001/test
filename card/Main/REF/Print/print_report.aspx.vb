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
        'Dim burden_ID = Request.QueryString("burden_ID")

        Using report As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            ' SLIPID = enc.getDecode(SLIPID)

            Dim ID = Request.QueryString("id")
            ID = Replace(ID, "on", "")
            Dim type = Request.QueryString("type")
            Dim typename As String = 0
            If type = 1 Then
                typename = "บุคคลชั้นในสุด"
            ElseIf type = 2 Then
                typename = "บุคคลชั้นในสุด"
            ElseIf type = 3 Then
                typename = "บุคคลชั้นกลาง"
            End If


            report.Load(Server.MapPath("print_report.rpt"))

            Dim dtb = db.GetDataTable("SELECT TOP (200)   * FROM  dbo.Card_TB  WHERE Card_TYPE = @Card_TYPE and Card_year = 2567 and  Card_ID in (" & ID & ") ORDER BY Card_Num",
                                      db.NewParam("Card_TYPE", type))


            'If dtb.Rows.Count = 0 Then
            '    Response.Write("ไม่มีข้อมูล")
            'Else
            '    For i As Integer = 0 To dtb.Rows.Count - 1
            '        With dtb.Rows(i)
            '            If Not System.IO.File.Exists(Server.MapPath("../img/" & .Item("nophoto.jpg"))) Then
            '                .Item("IMG_File_TEMP") = convertImage(Server.MapPath("../img/nophoto.jpg"))
            '            Else
            '                .Item("IMG_File_TEMP") = convertImage(Server.MapPath("../img/" & .Item("Card_img")))
            '            End If
            '            '.Item("PrintName") = Session("PersonName")
            '        End With
            '    Next
            'End If



            For i As Integer = 0 To dtb.Rows.Count - 1
                With dtb.Rows(i)
                    .Item("IMG_File_TEMP") = convertImage(Server.MapPath("../img/" & .Item("Card_img")))
                    .Item("color_TEMP") = typename
                End With
            Next


            report.SetDataSource(dtb)
            report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "")
            db.Close()
            report.Close()
            report.Dispose()
            ' db.Close()
        End Using
    End Sub
End Class
