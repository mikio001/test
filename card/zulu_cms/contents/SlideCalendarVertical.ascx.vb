
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles SlideCalendar.RenderHtml
        Dim buttonMargin = (boxWidth / 2) - 25
        w.Write("<script type=""text/javascript"">")
        w.Write("$(document).ready(function () {")

        w.Write("$('#slider5').tinycarousel({ axis: 'y', pager: true, interval: true });")
        w.Write("});")
        w.Write("</script>")
        w.Write("<div id=""slider5"" style="""" >")
        w.Write("<a class=""buttons prev"" href=""#"" style=""margin-left:" & buttonMargin & "px;"">left</a>")
        w.Write("<div class=""viewport"" style=""width: " & boxWidth + 4 & "px;"">")
        w.Write("<ul class=""overview"" style=""width: " & boxWidth + 3 & "px;background-color:#fff;"">")


        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select title,contentType,startDate,endDate,contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and startDate >= GETDATE()", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()

        While dr.Read
            w.Write("<li style=""width: " & boxWidth & "px;height: " & boxHeight & "px;""><table cellpadding=""0"" cellspacing=""0""><tr><td valign=""top""><div class=""slideCalDay"">")

            If Not dr.IsDBNull(3) Then
                w.Write(dr.GetDateTime(2).ToString("d-"))
                w.Write(dr.GetDateTime(3).ToString("d<br/>MMM"))
            Else
                w.Write(dr.GetDateTime(2).ToString("d<br/>MMM"))
            End If

            w.Write("</div>")
            w.Write("</td><td valign=""top"" class=""slideCalItem"">")
            w.Write(dr.GetString(0))
            w.Write("</td></tr></table>")
            w.Write("</li>")
        End While

        dr.Close()
        db.Close()

        w.Write("</ul>")
        w.Write("</div>")
        w.Write("<a class=""buttons next"" href=""#"" style=""margin-left:" & buttonMargin & "px;"">right</a>")
        w.Write("</div>")
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = "CALSLIDE"
    End Sub
End Class