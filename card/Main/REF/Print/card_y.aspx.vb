Imports Zen.Barcode
Imports System.IO
Imports Zulu.Data
Imports CrystalDecisions.Shared

Partial Class Main_Document_DocumentList
    Inherits System.Web.UI.Page


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



            report.Load(Server.MapPath("card_y.rpt"))

            Dim dtb = db.GetDataTable("SELECT TOP (200)   * FROM  dbo.Card_TB  WHERE Card_TYPE = @Card_TYPE and  Card_ID in (" & ID & ")",
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
