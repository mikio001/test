
Partial Class zulu_cms_contents_NewsCard
    Inherits Zulu.Cms.ReaderControl
    Public Property NewsReaderPageUrl As String = "~/News_hot.aspx?itemID={0}"
    Public Property MaxNewsCount As Integer = 4
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
        Dim dr = db.GetReader("select " & MAXNEW & " itemID,title,subtitle,contentBody,refUrl,imgUrl,modifyDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE() order by orderNo,itemID", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim refUrl, title, subtitle, refImg As String
        db.ThrowIfError()
        Dim i = 1
        Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
        '   w.Write("<ul class='thumbnails'>")
        While dr.Read
            ' w.Write("<td width='200px'>")
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
            'If i = 1 Then
            '    w.Write("<div class='clearfloat'>")
            '    w.Write("<div class='tanbox left'>")
            'Else
            '    w.Write("<div class='tanbox right'>")
            'End If


            w.Write("<div class='col-lg-4'>")
            'w.Write("<h4>" & title & "</h4>")
            w.Write("<div class='thumbnail' style='background-color: #FFFFFF'>")

            w.Write("<img data-src='holder.js/300x200' alt='300x200' style='width: 220px; height: 150px; margin-left: 0;' src='" & refImg & "'>")
            w.Write("<div class='caption' style='word-wrap: break-word;'>")
            w.Write("<p>" & subtitle & "</p>")
            w.Write("<p><a  <button class='btn btn-primary' href='" & refUrl & "' data-target='.bs-example-modal-sm'>อ่านข่าว</button></a></p>")
            w.Write("</div>")
            w.Write("</div>")
            w.Write("</div>")



            'w.Write("<br><a href='" & refUrl & "' rel='bookmark' title=''><img src=""" & refImg & """ alt='' class='left' width='50px' height='65px' /></a>")
            'w.Write("<div class='ppky'><br>ภูกามยาวนิวส์<br><b>" & title & "</b><br>" & subtitle & " </div>")
            'w.Write("</div>")

            'If i = 5 Then
            '    i += 1
            '    w.Write("</tr><tr>") 'เครีย flot
            '    i = 1
            'End If
            'w.Write("</td>")
        End While
        ' w.Write("</ul>")
        'If i = 2 Then w.Write("</div>")
        dr.Close()
        db.Close()




    End Sub
End Class
