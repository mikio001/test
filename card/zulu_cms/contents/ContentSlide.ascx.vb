
Partial Class zulu_cms_contents_ContentSlide
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxItemCount As Integer = 20
    Public Property Height As String = "198px"

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ContentSlideEnd.ContentID = ContentID
        ContentSlideEnd.EditorID = "CONTSLIDE"
        ContentSlideStart.ContentID = ContentID
        RegisterJquery()
        RegisterStyleSheet("CONTSLIDECSS", "~/zulu_cms/contents/slidedesk/slidedeck.skin.css")
        RegisterScriptInclude("CONTSLIDESCR0", "~/zulu_cms/contents/slidedesk/jquery-mousewheel/jquery.mousewheel.min.js")
        RegisterScriptInclude("CONTSLIDESCR1", "~/zulu_cms/contents/slidedesk/slidedeck.jquery.lite.js")
    End Sub

    Protected Sub ContentSlide_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles ContentSlide.RenderHtml
        w.Write("<div id=""slidedeck_frame"" class=""skin-slidedeck"" style=""height:" & Height & " ;"">")
        w.Write("<dl class=""slidedeck"">")

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String

        If MaxItemCount > 0 Then
            sql = "select top " & MaxItemCount & " itemID,title,contentBody from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE() order by orderNo,itemID"
        Else
            sql = "select itemID,title,contentBody from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE() order by orderNo,itemID"
        End If

        Dim dr = db.GetReader(sql, db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        db.ThrowIfError()

        While dr.Read
            w.Write("<dt>")
            w.Write(dr.GetString(1))
            w.Write("</dt>")
            w.Write("<dd>")
            w.Write(dr.GetString(2))
            w.Write("</dd>")
        End While

        dr.Close()
        db.Close()

        w.Write("</dl>")
        w.Write("</div>")
        w.Write("<script type=""text/javascript"">")
        w.Write("$('.slidedeck').slidedeck({")
        w.Write("autoPlay: true,")
        w.Write("cycle: true,")
        w.Write("autoPlayInterval: 7000")
        w.Write("});")
        w.Write("</script>")
    End Sub
End Class
