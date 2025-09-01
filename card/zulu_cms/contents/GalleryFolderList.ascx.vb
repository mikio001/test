
Partial Class zulu_cms_contents_Gallery
    Inherits Zulu.Cms.ReaderControl
    Property ItemID As Integer
    Private Const UploadDirectory As String = "~/GalleryContent/"
    Public Property GalleryFilePageUrl As String = "~/Gallery.aspx"
    Public Property GalleryName As String = "ภาพกิจกรรม"
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
 
        '   RegisterJquery()
        RegisterStyleSheet("CONTSLIDECSS", "~/zulu_cms/contents/prettyPhoto/css/prettyPhoto.css")
        RegisterStyleSheet("facebookStyle", "~/zulu_cms/contents/prettyPhoto/css/face.css")
        ' RegisterScriptInclude("CONTSLIDESCR0", "~/zulu_cms/contents/prettyPhoto/js/jquery.prettyPhoto.js")
    End Sub
    Function getImgURL(ByVal img As String, ByVal id As String) As String
        Return ResolveClientUrl(UploadDirectory & id & "/" & img)
    End Function
    Function getImgURLthumbnail(ByVal img As String, ByVal id As String) As String
        Return ResolveClientUrl(UploadDirectory & id & "/thumbnail_" & img)
    End Function

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml
        Dim itemID = CInt(Request.QueryString("itemID"))
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)

        Dim drtitle = db.GetReader("select title,contentBody,modifyBy,modifyDate,SiteID from ZCMS_CONTENT where ItemID=@ItemID", db.NewParam("ItemID", itemID))

        Dim refUrl, title, Reference, desc As String
        db.ThrowIfError()
        Dim NSite As New NewsSite

        While drtitle.Read
            w.Write("<div><a href='" & ResolveClientUrl(GalleryFilePageUrl) & "'>" & GalleryName & "</a> > " & drtitle.GetString(0) & " </div>")
            w.Write("<div style='padding:0px 20px 20px 20px'><br><h3>" & drtitle("contentBody").ToString & "</h3><br>")
            ' w.Write("<div class=""newsFooter"">")
            'w.Write("ที่มา :" & NSite.GetSiteName(drtitle.GetString(4)) & " &nbsp;&nbsp; ")
            'w.Write(" วันที่: ")
            'w.Write(drtitle.GetDateTime(3).ToString("d MMM yyyy HH:mm"))
            ' w.Write("</div><br>")
            Reference = ("ที่มา :" & NSite.GetSiteName(drtitle.GetString(4)) & " &nbsp;&nbsp; ")
        End While
        drtitle.Close()

        Dim sql = "select imageID,filename,description,storename from ZCMS_CONTENT_GALLERY where ItemID=@ItemID order by imageID"
        Dim dr = db.GetReader(sql, db.NewParam("ItemID", itemID))
        w.Write("<div style='display: inline; '>")
        While dr.Read
            title = dr.GetString(1)
            refUrl = dr.GetString(3)
            If Not dr.IsDBNull(2) Then desc = dr.GetString(2)
            'w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbHuge' href='" & getImgURL(refUrl, itemID) & "' rel='prettyPhoto[gallery1]'><img src='" & getImgURLthumbnail(refUrl, itemID) & "'  alt='" & dr.GetString(2) & "' /></a>")

            w.Write("<a style='margin:10px' class='uiMediaThumb uiScrollableThumb uiMediaThumbHuge' href='" & getImgURL(refUrl, itemID) & "'  title='" & desc & "'  data-gallery=''>")
            w.Write("<div class='tagWrapper'>")
            w.Write("<i style='background-image: url(" & getImgURLthumbnail(refUrl, itemID) & ");' alt='" & title & "' ></i>")
            w.Write("</div></a>")
        
        End While
        w.Write("</div></div>")

        w.Write("<div class=""newsFooter"">")
        w.Write(Reference)
        w.Write("</div>")


        dr.Close()
        db.Close()

    End Sub
End Class
