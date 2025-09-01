Imports Zulu.Data
Imports CrystalDecisions.Shared

Partial Class Main_Report_Print_ReportListGroupbyFac
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = PlatformFactory.GetPlatform("MainDB", True, False)
        Dim type = Request.QueryString("type")
        Dim NAME = Request.QueryString("NAME")
        Dim TECHINFO1 = Request.QueryString("TECHINFO1")

        Using report As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            report.Load(Server.MapPath("print_item1.rpt"))
            'Dim type = Request.QueryString("type")
            Dim dtb = db.GetDataTable("SELECT * FROM dbo.View_ASSET  where (item_status <> 12 )  ORDER BY  item_status2,ITEM_YEAR ", db.NewParam("item_status", type))
            'WHERE   item_status = @item_status  and ck = '-'

            'Dim dtb As New StringBuilder
            'dtb.Append("SELECT * FROM dbo.View_ASSET WHERE   1 = 1   ")
            'กล่องปฏิบัติงาน()

            'If type <> "" Then


            '    dtb.Append(" AND (item_status = '" & type & "')  ")
            'End If
            'If NAME <> "" Then


            '    dtb.Append(" AND (NAME = '" & NAME & "')  ")
            'End If

            'If TECHINFO1 <> "" Then
            '    dtb.Append(" AND (TECHINFO1 = '" & TECHINFO1 & "')  ")
            'End If



            Dim Err
            If db.IsError(Err) Then
                Response.Write(Err)
                db.Close()
                Exit Sub
            End If





            report.SetDataSource(dtb)

            report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "")
            report.Clone()
            report.Dispose()
            db.Close()
        End Using
    End Sub
End Class
