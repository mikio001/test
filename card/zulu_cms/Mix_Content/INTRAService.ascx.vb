
Partial Class zulu_cms_contents_NewsCard
    Inherits Zulu.Cms.ReaderControl
    ' Public Property NewsReaderPageUrl As String = "~/News_hot.aspx?itemID={0}"
    'Public Property MaxNewsCount As Integer = 4

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ServiceEnd.ContentID = ContentID
        ServiceEnd.EditorID = "SERVICE"
        ServiceStart.ContentID = ContentID

        ' RegisterJquery()
        RegisterStyleSheet("CONTSLIDECSS", "~/zulu_cms/contents/prettyPhoto/css/prettyPhoto.css")
        RegisterStyleSheet("facebookStyle", "~/zulu_cms/contents/prettyPhoto/css/facebookStyle.css")
        RegisterScriptInclude("CONTSLIDESCR0", "~/zulu_cms/contents/prettyPhoto/js/jquery.prettyPhoto.js")

        RegisterStyleSheet("easySlideCSS", "~/zulu_cms/contents/easyslider/StyleSheet.css")
        RegisterScriptInclude("easySlider15", "~/zulu_cms/contents/easyslider/js/easySlider1.5.js")
    End Sub

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Service.RenderHtml
      
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, False)
        'db.Execute("update ZCMS_CONTENT set orderNo=99 where orderNo is null and  siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim dr = db.GetReader("select  ContentID,title,contentBody,imgURL,subtitle,refURL from ZCMS_CONTENT where  siteID=@siteID and contentID=@contentID order by orderNO", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        db.ThrowIfError()
        Dim i = 1
        Dim refUrl, title, contentBody, imgURL, subtitle As String
        w.Write("<table style='margin-left: 40px;'><tr><td><div id='slider'><ul>")

        w.Write("<li>")
        While dr.Read
            title = dr.GetString(1)
            refUrl = dr.GetString(5)
            imgURL = dr.GetString(3)
            contentBody = dr.GetString(2)
            subtitle = dr.GetString(4)
            '  w.Write("<div style='float:left; width:300px;'>")
            'w.Write("<table style='float: left' width='300px'><tr><td>")
            'w.Write("<img  src='" & dr.GetString(3) & "' />")
            'w.Write("</td><td>")
            'w.Write(dr.GetString(1))
            'w.Write(dr.GetString(2))
            'w.Write("</td></tr></table>")
            '  w.Write("<div>")
            w.Write("<table style='float: left';' width='300px'>")
            w.Write("<tr></tr><tr><td width='30px'>&nbsp;</td>")
            w.Write("<td class='vTop hLeft' width='50px'>")
            w.Write("<div class='dragWrapper'>")
            w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbSmall uiMediaThumbAlbPlus uiMediaThumbAlbSmallPlus'  href='" & refUrl & "' target='_blank' rel='prettyPhoto' title='" & title & "' ><img class='uiMediaThumbSmall' src='" & imgURL & "' width='73' height='54'></a>")

            w.Write("</td>")
            w.Write("<td valign='top' align='left'>")
            w.Write("<div><strong>" & title & "</strong></div>")
            w.Write("<div class='newsFooter'>" & subtitle & "</div>")

            w.Write("</td>")
            w.Write("</tr><tr></tr>")
            w.Write("</table>")
            i += 1
            If i = 13 Then w.Write("</li><li>") : i = 1

        End While
        w.Write("</li> </ul> </div></td></tr></table>")
        dr.Close()
        db.Close()




    End Sub
End Class
