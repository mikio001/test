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

            Dim ID = 1
            Dim type = 1
            ID = Replace(ID, "on", "")




            report.Load(Server.MapPath("CreateBarcode.rpt"))

            Dim dtb = db.GetDataTable("SELECT        dbo.Card_TB.Card_Num AS ลำดับ, dbo.Card_TB.Card_Name + N'  ' + dbo.Card_TB.Card_Surname AS [ชื่อ สกุล], dbo.Card_TB.CitizenID AS เลขบัตรประชาชน, dbo.Card_TYPE_TB.Card_TYPE_name AS ประเภทบุคคล, dbo.Card_TB.Card_Job AS บทบาทหน้าที่, dbo.Card_TB.Card_duty AS รายละเอียดหน้าที่, dbo.Card_TB.Card_FAC_Name AS หน่วยงาน, dbo.Card_TB.IMG_File_TEMP AS หมายเหตุ FROM            dbo.Card_TB INNER JOIN dbo.Card_TYPE_TB ON dbo.Card_TB.Card_TYPE = dbo.Card_TYPE_TB.Card_TYPE  WHERE  Card_ID in  (" & ID & ")")



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
