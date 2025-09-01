
Partial Class zulu_cms_contents_NewsCard
    Inherits Zulu.Cms.ReaderControl
    Public Property NewsReaderPageUrl As String = "~/News_hot.aspx?itemID={0}"
    Public Property MaxNewsCount As Integer = 6
    Public Property ItemPerrow As Integer = 3
    Public Property SlideMode As String = ""
    Public Property StrategicID As Integer = 0

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

   
        GalleryEnd.ContentID = ContentID
        GalleryEnd.EditorID = "NEWS"
        GalleryStart.ContentID = ContentID

    End Sub

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml

  

        Dim MAXNEW = ""
        If MaxNewsCount > 0 Then
            MAXNEW = " top " & MaxNewsCount
        End If
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        db.Execute("update ZCMS_CONTENT set orderNo=99 where orderNo is null and  siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim dr = db.GetReader("select " & MAXNEW & " itemID,title,subtitle,contentBody,refUrl,imgUrl,modifyDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()" & IIf(StrategicID <> 0, " and StrategicID=" & StrategicID, "") & " order by orderNo,itemID desc", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim refUrl, title, subtitle, refImg As String
        db.ThrowIfError()
        Dim i = 1
        Dim readPage = ResolveClientUrl(NewsReaderPageUrl)

        Dim cnt As Integer = 0

        While dr.Read
            cnt += 1
            If (cnt - 1) Mod 3 = 0 Then
                w.Write(" <div class='container'>")
                w.Write(" <div class='row'>")

            End If
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

            'w.Write("  <li><table ><tr><td style='padding-left:10px;'> " &
            '      "      <img style='border:1px solid #666;	width:80px;	height:80px;float:left;	margin-right:10px;margin-left:10px;' src='" & refImg & "'  /></td><td style='padding-right:10px;'><a  " &
            '      "          href='" & refUrl & "'> " & title & " </a></td></tr></table> " &
            '      "     </li> ")


            w.Write(" <div class='col-lg-4'>")
            w.Write("              <div style='padding: 5px'>")
            w.Write("                   <img class='img-rounded'  style='border-color: rgb(123, 126, 133);border-width: 1px;border-style: solid; width=50px; height=50px;' src='" & refImg & "'>")
            ' w.Write("                  <h4>Heading</h4>")
            w.Write("                  <p>" & title & "</p>")
            w.Write("              <p><a class='btn' href='" & refUrl & "'>ดูรายละเอียด</a></p>")
            w.Write("             </div>")
            w.Write(" </div>")


        End While
        If cnt = 0 Then
            w.Write("<div class='col-lg-12'><br><br><br><br><br><br>    ยังไม่มีข่าวในหมวดนี้<br><br><br><br><br><br></div>")
        End If
        'If cnt = 0 Then
        '    w.Write("<li></li>")
        'End If
        'w.Write("  </ul>")
        w.Write(" </div>")
        w.Write(" </div>")
        dr.Close()
        db.Close()




    End Sub
End Class
