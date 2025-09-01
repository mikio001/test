
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml

        w.Write("<DIV id=header><DIV class=wrap>" &
                "<DIV id=slide-holder>" &
                "<DIV id=slide-runner>")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select itemID,title,contentType,refUrl,imgUrl,contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
      
        While dr.Read
            Dim refUrl = ""
            If (Not dr.IsDBNull(3)) And dr.GetString(3).ToString <> "" Then
                refUrl = dr.GetString(3).ToString
            ElseIf (Not dr.IsDBNull(5)) And dr.GetString(5).ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr.GetInt32(0)
            End If

            Dim imgUrl
            If Not dr.IsDBNull(4) Then imgUrl = dr.GetString(4).ToString

            If refUrl <> "" Then w.Write("<A href=""" & refUrl & """>")
            w.Write("<IMG id='slide-img-" & dr.GetInt32(0).ToString & "' class='slide' alt='' src='" & imgUrl & "'>")
            If refUrl <> "" Then w.Write("</A>")

            If str <> "" Then str &= ","
            str &= "{'id': 'slide-img-" & dr.GetInt32(0).ToString & "','client': '" & dr.GetString(1).ToString & "','desc': ''}"

        End While

        dr.Close()
        db.Close()
        w.Write("<DIV id=slide-controls>")
        w.Write("<P id=slide-client class=text><STRONG> </STRONG><SPAN></SPAN></P>" &
                "<P id=slide-desc class=text></P>" &
                "<P id=slide-nav></P></DIV>")
        w.Write("</DIV><!--content featured gallery here --></DIV>" &
                "<SCRIPT type=text/javascript>")
        w.Write("if (!window.slider) var slider = {}; slider.data = [" & str & "];")

        w.Write("</SCRIPT>" &
                "</DIV></DIV>")
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        RegisterJquery()
        RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/Photosliders/style.css")
        RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/Photosliders/js/scripts.js")
    End Sub
End Class