
Partial Class zulu_cms_contents_Gallery
    Inherits Zulu.Cms.ReaderControl
    Property ItemID As Integer
    Private Const UploadDirectory As String = "~/GalleryContent/"
    Public Property GalleryFilePageUrl As String = "~/Gallery_Folder.aspx"
    Public Property EditorID As String = "VIDEO"
    Public Property ReaderPage As String = "VideoGallery"
    Public Property ShowRightDescription As Boolean = False
    Public Property Limit As Integer = 0

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID

        ' RegisterJquery()
        RegisterStyleSheet("CONTSLIDECSS", "~/zulu_cms/contents/prettyPhoto/css/prettyPhoto.css")
        RegisterStyleSheet("facebookStyle", "~/zulu_cms/contents/prettyPhoto/css/facebookStyle.css")
        RegisterScriptInclude("CONTSLIDESCR0", "~/zulu_cms/contents/prettyPhoto/js/jquery.prettyPhoto.js")
    End Sub
 
    Function getImgURL(ByVal img As String, Optional ByVal type As Integer = 0) As String
        Return "http://img.youtube.com/vi/" & img & "/" & type & ".jpg"

    End Function

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Youtube.RenderHtml

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)

        Dim refUrl, title, contentBody As String

        Dim Strlimit As String = ""
        If Limit <> 0 Then
            Strlimit = " top " & Limit
        End If
        db.ThrowIfError()
        If ShowRightDescription = True Then w.Write("<table>")
        ' Dim sql = "select imageID,filename,description,storename from ZCMS_CONTENT_GALLERY where ItemID=@ItemID order by imageID"
        Dim dr = db.GetReader("select " & Strlimit & " title,refURL,contentBody,modifyBy,modifyDate,SiteID from ZCMS_CONTENT where ContentID=@ContentID order by orderNO,itemID desc", db.NewParam("ContentID", ContentID))
        While dr.Read
            title = dr.GetString(0)
            refUrl = dr.GetString(1)
            contentBody = ""
            If Not dr.IsDBNull(2) Then contentBody = dr.GetString(2)
            If ShowRightDescription = True Then
                w.Write("<tr>")
                w.Write("<td class='vTop hLeft'>")
                w.Write("<div class='dragWrapper'>")
                w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbSmall uiMediaThumbAlbPlus uiMediaThumbAlbSmallPlus'  href='http://www.youtube.com/watch?v=" & refUrl & "' rel='prettyPhoto' title='" & title & "' ><img class='uiMediaThumbSmall' src='" & getImgURL(refUrl, 0) & "' width='73' height='54'></a>")

                w.Write("</td>")
                w.Write("<td valign='top'>")
                w.Write("<div><strong>" & title & "</strong></div>")
                w.Write("<div>" & contentBody & "</div>")

                w.Write("<div  style='color: #666;'>" & dr.GetDateTime(4).ToString("d MMM yyyy") & "</div>")
                w.Write("</td>")
                w.Write("</tr>")
            Else
                'w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbHuge' href='" & getImgURL(refUrl, itemID) & "' rel='prettyPhoto[gallery1]'><img src='" & getImgURLthumbnail(refUrl, itemID) & "'  alt='" & dr.GetString(2) & "' /></a>")
                w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbHuge' href='http://www.youtube.com/watch?v=" & refUrl & "' rel='prettyPhoto' title='" & title & "'>")
                'w.Write("<a class='uiMediaThumb uiScrollableThumb uiMediaThumbHuge' href='" & getImgURL(refUrl) & "'  title='" & dr.GetString(0) & "' rel='prettyPhoto[gallery1]' >")
                w.Write("<div class='tagWrapper'>")
                w.Write("<i style='background-image: url('" & getImgURL(refUrl) & "' alt='" & title & "' ><img src='" & getImgURL(refUrl) & "' width='100%' ></i>")
                w.Write("<div class='newsFooter' style='width:161px;'>")
                w.Write("<b>" & title & "</b> &nbsp;&nbsp; ")
                w.Write(" <br>วันที่: ")
                w.Write(dr.GetDateTime(4).ToString("d MMM yyyy HH:mm"))
                w.Write("</div>")
                w.Write("</div></a>&nbsp;&nbsp;")
            End If


        End While
        'w.Write("</div></div>")
        If ShowRightDescription = True Then w.Write("</table>")
        dr.Close()
        db.Close()

    End Sub

End Class
