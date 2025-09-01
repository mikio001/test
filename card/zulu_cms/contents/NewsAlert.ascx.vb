
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"
    Function getImgURL(ByVal img As String, Optional ByVal type As Integer = 0) As String
        Return "http://img.youtube.com/vi/" & img & "/" & type & ".jpg"

    End Function
    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml
        Dim refUrl = ""
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select top 1 itemID,title,contentType,refUrl,imgUrl,contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate>getDate() order by orderNO,itemID desc ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
        Dim PoptypeType = "contentBody"
        Dim contentBody As String = ""
        While dr.Read
            refUrl = ""
            Dim imgURL = ""
            If (Not dr.IsDBNull(3)) And dr.GetString(3).ToString <> "" Then
                refUrl = dr.GetString(3).ToString
            ElseIf (Not dr.IsDBNull(5)) And dr.GetString(5).ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr.GetInt32(0)
            End If
            ' w.Write((dr.GetString(1)))
            If Not dr.IsDBNull(5) Then contentBody = dr.GetString(5)

            If Not dr.IsDBNull(4) Then imgURL = dr.GetString(4)
            If imgURL <> "" Then

                If InStr(LCase(dr.GetString(4)), "zulu_store") = 0 Then
                    PoptypeType = "youtube"

                    w.Write("<a id='inline' href='http://www.youtube.com/watch?v=" & imgURL & "' rel='prettyPhoto[gallery1]' title='" & dr.GetString(1) & "' style='visible='hidden'></a>")

                Else
                    PoptypeType = "image"
                    w.Write("<a id='inline' href='" & ResolveClientUrl(imgURL) & "' rel='prettyPhoto[gallery1]' title='" & "" & "' style='visible='hidden'></a>")

                End If
            Else
                w.Write("<a id='inline' href='#inline_demo' rel='prettyPhoto[gallery1]' style='visible='hidden'></a>")
                w.Write("<div id='inline_demo' style='display:none;'>" & contentBody & "</div>")
            End If

          
        End While
        'If Not Zulu.Cms.Factory.IsEditMode Then
        w.Write(" <script language='javascript'> " &
                     " $(document).ready(function(){" &
                     "     $('#inline').prettyPhoto().click();" &
                     "   });" &
                     "  </script> ")
        'End If

        dr.Close()
        db.Close()
    End Sub

    Function YoutubeEM2(ByVal YoutubeURL As String) As String
        Dim str As String
        str = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' width='" & boxWidth & "' height='" & boxHeight & "' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0'><param name='controls' value='true' /><param name='allowFullScreen' value='true' /><param name='allowScriptAccess' value='always' />" &
            "<param name='src' value='http://www.youtube.com/v/" & YoutubeURL & "&amp;rel=0&amp;hl=en_US&amp;feature=player_embedded&amp;version=3' /><param name='allowfullscreen' value='true' /><embed type='application/x-shockwave-flash' width='" & boxWidth & "' height='" & boxHeight & "' " &
            " src='http://www.youtube.com/v/" & YoutubeURL & "&amp;rel=0&amp;hl=en_US&amp;feature=player_embedded&amp;version=3' allowfullscreen='true' allowscriptaccess='always'></embed></object>"
        Return str
    End Function

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        'RegisterJquery()
        'RegisterStyleSheet("fancyboxCSS1", "~/zulu_cms/contents/fancybox/fancybox/jquery.fancybox-1.3.4.css")

        'RegisterScriptInclude("fancybox1", "/zulu_cms/contents/fancybox/jquery.min.js")
        'RegisterScriptInclude("fancybox2", "~/zulu_cms/contents/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js")
        'RegisterScriptInclude("fancybox3", "~/zulu_cms/contents/fancybox/fancybox/jquery.easing-1.4.pack.js")
        'RegisterScriptInclude("fancybox4", "~/zulu_cms/contents/fancybox/fancybox/jquery.mousewheel-3.0.4.pack.js")
        ' RegisterJquery()
        RegisterStyleSheet("CONTSLIDECSS", "~/zulu_cms/contents/prettyPhoto/css/prettyPhoto.css")
        RegisterStyleSheet("facebookStyle", "~/zulu_cms/contents/prettyPhoto/css/facebookStyle.css")
        RegisterScriptInclude("CONTSLIDESCR0", "~/zulu_cms/contents/prettyPhoto/js/jquery.prettyPhoto.js")


    End Sub
End Class