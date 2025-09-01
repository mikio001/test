
Partial Class zulu_cms_contents_NewsCard
    Inherits Zulu.Cms.ReaderControl
    Public Property NewsReaderPageUrl As String = "~/News_hot.aspx?itemID={0}"
    Public Property MaxNewsCount As Integer = 4
    Public Property SlideMode As String = ""
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        RegisterScriptInclude("CONTSLIDEslide-news", "~/zulu_cms/contents/slide-news/jquery.bxSlider/jquery.bxSlider.min.js")
        RegisterStyleSheet("CONTSLIDECSSslide-news", "~/zulu_cms/contents/slide-news/jquery.bxSlider/bx_styles/bx_styles.css")
        GalleryEnd.ContentID = ContentID
        GalleryEnd.EditorID = "NEWS"
        GalleryStart.ContentID = ContentID

    End Sub

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml

        w.Write(" <script type='text/javascript' charset='utf-8'> " &
           "  $(document).ready(function () { " &
           "      $('#" & ContentID & "').bxSlider({ ")
        If SlideMode <> "" Then w.Write("mode:   '" & SlideMode & "', ")

        w.Write("       auto: true, " &
              "       pager: false, " &
              "       controls: false, autoHover: true, " &
              "       speed: 3000, " &
              "       pause: 5000 " &
              "   }); " &
          "   }); " &
            "    </script> ")

        w.Write("")

        Dim MAXNEW = ""
        If MaxNewsCount > 0 Then
            MAXNEW = " top " & MaxNewsCount
        End If
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        db.Execute("update ZCMS_CONTENT set orderNo=99 where orderNo is null and  siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim dr = db.GetReader("select " & MAXNEW & " itemID,title,subtitle,contentBody,refUrl,imgUrl,modifyDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE() order by orderNo,itemID desc", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim refUrl, title, subtitle, refImg As String
        db.ThrowIfError()
        Dim i = 1
        Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
        w.Write("<ul id='" & ContentID & "'> ")
        Dim cnt As Integer = 0
        While dr.Read
            cnt += 1
            title = dr.GetString(1)
            If Not dr.IsDBNull(2) Then subtitle = dr.GetString(2)
            If Not dr.IsDBNull(5) AndAlso dr.GetString(5) <> "" Then
                refImg = dr.GetString(5)
            Else
                refImg = ResolveClientUrl("~/themes/icon_up3.jpg")
            End If
            If Not dr.IsDBNull(4) AndAlso dr.GetString(4) <> "" Then
                refUrl = dr.GetString(4)
            Else
                refUrl = String.Format(readPage, dr.GetInt32(0))
            End If

            If subtitle.Length > 140 Then subtitle = subtitle.Substring(0, 140)

            w.Write("  <li><table ><tr><td style='padding-left:10px;'> " &
                  "      <img style='border:1px solid #666;	width:80px;	height:80px;float:left;	margin-right:10px;margin-left:10px;' src='" & refImg & "'  /></td><td style='padding-right:10px;'><a  " &
                  "          href='" & refUrl & "'> " & title & " </a></td></tr></table> " &
                  "     </li> ")


        End While
        If cnt = 0 Then
            w.Write("<li></li>")
        End If
        w.Write("  </ul>")

        dr.Close()
        db.Close()




    End Sub
End Class
