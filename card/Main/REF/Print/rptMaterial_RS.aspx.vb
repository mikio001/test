Imports Zulu.Data
Imports CrystalDecisions.Shared

Partial Class Main_Report_Print_ReportListGroupbyFac
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = PlatformFactory.GetPlatform("MainDB", True, False)

        Using report As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            report.Load(Server.MapPath("rptMaterial_RS.rpt"))

            Dim type = Request.QueryString("type")
            Dim dtb = db.GetDataTable("SELECT * FROM dbo.REF_MATERIAL WHERE (IS_IM = @IS_IM)",
                                      db.NewParam("IS_IM", type))
            If dtb.Rows.Count = 0 Then
                Response.Write("ไม่มีข้อมูล")
            Else
                For Each dr In dtb.Rows
                    dr("rptName") = "ข้อมูล ณ วันที่ " & Now.ToString("dd/MM/yyyy")
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
