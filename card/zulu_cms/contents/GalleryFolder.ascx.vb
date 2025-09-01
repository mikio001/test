
Partial Class zulu_cms_contents_Gallery
    Inherits Zulu.Cms.ReaderControl
    Property ItemID As Integer
    Private Const UploadDirectory As String = "~/GalleryContent/"
    Public Property GalleryFilePageUrl As String = "~/Gallery.aspx?itemID={0}"
    Public Property FolderLimit As Int32 = 200
    Public Property ShowRightDescription As Boolean = False
    Public Property ColumnCount As Int32 = 4
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GalleryEnd.ContentID = ContentID
        GalleryEnd.EditorID = "GalleryFileEditor"

        ' RegisterJquery()
    End Sub
    Function getImgURL(ByVal img As String, ByVal id As String) As String
        Return ResolveClientUrl(UploadDirectory & id & "/" & img)
    End Function
    Function getImgURLthumbnail(ByVal img As String, ByVal id As String) As String
        Return ResolveClientUrl(UploadDirectory & id & "/thumbnail_" & img)
    End Function

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim max = " top " & FolderLimit

        Dim sql = "select " & max & " itemID,title,contentBody,(select top 1 storename from ZCMS_CONTENT_GALLERY where ItemID=ZCMS_CONTENT.ItemID order by showFirst DESC) as storename,modifyDate,(select count(imageID) from ZCMS_CONTENT_GALLERY where ItemID=ZCMS_CONTENT.ItemID ) as imgCount from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID order by orderNo desc,itemID desc"
        Dim dr = db.GetReader(sql, db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim refUrl, title, imgURL, contentBody As String
        Dim imgCount As Integer = 0
        Dim rows As Integer = 0
        db.ThrowIfError()
        Dim readPage = ResolveClientUrl(GalleryFilePageUrl)
        '   w.Write("<table>")
        '   w.Write("<tr>")
        While dr.Read
            rows += 1
            ' Dim imgCount As String = db.GetValue("select count(*) from ZCMS_CONTENT_GALLERY where ItemID=@ItemID ", db.NewParam("ItemID", dr.GetInt32(0)))
            ' Dim dr = db.GetReader(sql, db.NewParam("ItemID", ItemID))

            title = dr.GetString(1)
            contentBody = ""
            If Not dr.IsDBNull(2) Then contentBody = dr.GetString(2)
            'If dr.GetInt32(5) Is Nothing Then imgCount = 0
            imgCount = dr.GetInt32(5)
            If contentBody.ToString <> "" And contentBody.Length > 50 Then contentBody = contentBody.Substring(1, 50) & "..."
            refUrl = String.Format(readPage, dr.GetInt32(0))
            Try
                imgURL = dr.GetString(3)
            Catch ex As Exception
                imgURL = ""
            End Try

            w.Write("<div class='col-md-3 col-sm-6 highlight'>")
            w.Write("<div class='h-caption'>")
            w.Write(" <img style='padding-bottom:20px' src='" & getImgURLthumbnail(imgURL, dr.GetInt32(0)) & "' />")
            w.Write("</div>")
            w.Write("<div class='h-body'>")
            ' w.Write("<p>" & title & "</p>")
            w.Write("<p><a style='color: #ffffff' href='" & refUrl & "'>" & title & "</a></p>")
            w.Write("</div>")
            w.Write(" </div>")



            'w.Write("<div class='col-sm-6 col-md-4'>")
            'w.Write("<div class='thumbnail'>")
            'w.Write("<img class='img-thumbnail' alt='Responsive image' src='" & getImgURLthumbnail(imgURL, dr.GetInt32(0)) & "' alt='...'>")
            'w.Write("<div class='caption'>")
            'w.Write("<div style='font-size:14px;margin:10px'>" & title & "</div>")

            'w.Write("<p><a href='" & refUrl & "' class='btn btn-primary' role='button'>ดูภาพกิจกรรม</a></p>")
            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("</div>")

            'If ShowRightDescription = False Then
            '    w.Write("<td align='center' class='vTop hLeft'>")
            '    w.Write("<div class='dragWrapper'>")
            '    w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbMedium uiMediaThumbAlb uiMediaThumbAlbMedium'  href='" & refUrl & "'  ><span class='uiMediaThumbWrap'><i style='background-image: url(" & getImgURLthumbnail(imgURL, dr.GetInt32(0)) & ");'></i></span></a>")

            '    w.Write("<div class='pls photoDetails'><strong>" & title & "</strong><div class='fsm fwn fcg'>" & imgCount & " รูปภาพ</div></div></div>")

            '    w.Write("</td>")
            '    If rows Mod (ColumnCount) = 0 Then w.Write("</tr><tr>")
            'End If
            'If ShowRightDescription = True Then
            '    w.Write("<tr>")
            '    w.Write("<td class='vTop hLeft'>")
            '    w.Write("<div class='dragWrapper'>")
            '    w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbSmall uiMediaThumbAlb uiMediaThumbAlbSmall'  href='" & refUrl & "'  ><span class='uiMediaThumbWrap'><i style='background-image: url(" & getImgURLthumbnail(imgURL, dr.GetInt32(0)) & ");'></i></span></a>")



            '    w.Write("</td>")
            '    w.Write("<td valign='top'><br>")
            '    w.Write("<div><strong>" & title & "</strong></div>")
            '    w.Write("<div>" & contentBody & "</div>")

            '    w.Write("<div class='fsm fwn fcg'>" & imgCount & " รูปภาพ&nbsp; ," & dr.GetDateTime(4).ToString("d MMM yyyy") & "</div>")
            '    w.Write("</td>")
            '    w.Write("</tr>")
            'End If
        End While
        '    w.Write("</tr></table>")
        dr.Close()
        db.Close()

    End Sub
End Class
