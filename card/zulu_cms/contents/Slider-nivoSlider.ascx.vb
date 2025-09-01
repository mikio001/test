
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml
        w.Write("<script type='text/javascript'>" &
           " $(window).load(function () {" &
            "    $('#slider').nivoSlider({pauseTime:7000});" &
          "  });" &
   "  </script> ")

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and (expireDate is null or expireDate > GETDATE()) order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
        w.Write("  <div id='slider-wrapper'> <div id='slider' class='nivoSlider'>")
        While dr.Read
            Dim refUrl = ""
            If (Not dr.IsDBNull(3)) And dr.GetString(3).ToString <> "" Then
                refUrl = dr.GetString(3).ToString
            ElseIf (Not dr.IsDBNull(5)) And dr.GetString(5).ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr.GetInt32(0)
            End If

            Dim imgUrl = ""
            If Not dr.IsDBNull(4) Then imgUrl = dr.GetString(4).ToString
            Dim subtitle = ""
            If Not dr.IsDBNull(6) Then subtitle = dr.GetString(6).ToString
            ' If refUrl <> "" Then w.Write("<A href=""" & refUrl & """>")
            ' w.Write("<IMG id='slide-img-" & dr.GetInt32(0).ToString & "' class='slide' alt='' src='" & imgUrl & "'>")
            If refUrl <> "" Then w.Write("<a href='" & refUrl & "' target='_blank'>")
            w.Write("  <img src='" & imgUrl & "' alt='' height='390' title='" & dr.GetString(1).ToString & "' />")
            If refUrl <> "" Then w.Write("</a>")
        End While
        w.Write("</div></div>")
     
        dr.Close()
        db.Close()

    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        'RegisterJquery()
        RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/nivo-slide/nivo-slider/nivo-slider.css")
        RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/nivo-slide/nivo-slider/jquery.nivo.slider.js")

 

    End Sub
End Class