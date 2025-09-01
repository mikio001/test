
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles SlideCalendar.RenderHtml
        w.Write("<script type=""text/javascript"">")
        w.Write("$(document).ready(function () {")
        w.Write("$('#slider1').tinycarousel({ display: 2 });")
        w.Write("});")
        w.Write("</script>")
        w.Write("<div id=""slider1"" style=""height: 130px;"">")
        w.Write("<a class=""buttons prev"" href=""#"">left</a>")
        w.Write("<div class=""viewport"" style=""width: 840px; height: 130px;"">")
        w.Write("<ul class=""overview"" style=""width: 240px;"">")


        w.Write("<li style=""width: 236px;height: 121px;""><table cellpadding=""0"" cellspacing=""0""><tr><td valign=""top""><div class=""slideCalDay"">")
        w.Write(Now.ToString("d<br/>MMM"))
        w.Write("</div>")
        w.Write("</td><td valign=""top"" class=""slideCalItem"">")
        w.Write("")
        w.Write("</td></tr></table>")
        w.Write("</li>")

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select ZSCHE_APPPOINTMENT.itemID,ZSCHE_APPPOINTMENT.subject,ZSCHE_APPPOINTMENT.startTime,ZSCHE_APPPOINTMENT.endTime from ZSCHE_APPPOINTMENT inner join ZSCHE_SCHEDULE on ZSCHE_APPPOINTMENT.scheID=ZSCHE_SCHEDULE.scheID where ZSCHE_SCHEDULE.cmsKey=@contentID and startTime >= GETDATE()", db.NewParam("contentID", ContentID))
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

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'EndEditorToolbox1.ContentID = ContentID
        'EndEditorToolbox1.EditorID = "Calendar"
    End Sub
End Class