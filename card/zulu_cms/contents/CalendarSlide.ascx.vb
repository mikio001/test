
Partial Class zulu_cms_contents_CalendarSlide
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxItemCount As Integer = 20

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CalendarSlideEnd.ContentID = ContentID
        CalendarSlideEnd.EditorID = "CALSLIDE"

        RegisterJquery()
        RegisterStyleSheet("CAROUSELCSS", "~/zulu_cms/contents/carousel/css/website.css")
        RegisterScriptInclude("CAROUSELSCR", "~/zulu_cms/contents/carousel/js/jquery.tinycarousel.min.js")
    End Sub

    Protected Sub CalendarSlide_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles CalendarSlide.RenderHtml
        w.Write("<script type=""text/javascript"">")
        w.Write("$(document).ready(function () {")
        w.Write("$('#slider1').tinycarousel({ display: 2 });")
        w.Write("});")
        w.Write("</script>")
        w.Write("<div id=""slider1"" style=""height: 130px;"">")
        w.Write("<a class=""buttons prev"" href=""#"">left</a>")
        w.Write("<div class=""viewport"" style=""width: 840px; height: 130px;"">")
        w.Write("<ul class=""overview"" style=""width: 240px;"">")

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String

        If MaxItemCount > 0 Then
            sql = "select top " & MaxItemCount & " itemID,title,startDate,endDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and endDate >= GETDATE() order by startDate"
        Else
            sql = "select itemID,title,startDate,endDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and endDate >= GETDATE() order by startDate"
        End If

        Dim dr = db.GetReader(sql, db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        db.ThrowIfError()

        While dr.Read
            w.Write("<li style=""width: 236px;height: 121px;""><table cellpadding=""0"" cellspacing=""0""><tr><td valign=""top""><div class=""slideCalDay"">")

            If Not dr.IsDBNull(3) Then
                w.Write(dr.GetDateTime(2).ToString("d-"))
                w.Write(dr.GetDateTime(3).ToString("d<br/>MMM"))
            Else
                w.Write(dr.GetDateTime(2).ToString("d<br/>MMM"))
            End If

            w.Write("</div>")
            w.Write("</td><td valign=""top"" class=""slideCalItem"">")
            w.Write(dr.GetString(1))
            w.Write("</td></tr></table>")
            w.Write("</li>")
        End While

        dr.Close()
        db.Close()

        w.Write("</ul>")
        w.Write("</div>")
        w.Write("<a class=""buttons next"" href=""#"">right</a>")
        w.Write("</div>")
    End Sub
End Class
