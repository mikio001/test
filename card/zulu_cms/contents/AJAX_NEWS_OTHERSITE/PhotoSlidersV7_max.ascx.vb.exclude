
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
  
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml

       
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dtb = db.GetDataTable("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate>=getDate() order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""


        w.Write("<div id='myCarousel' class='carousel slide'>")
        w.Write("<ol class='carousel-indicators'>")
        Dim i = 0
        For Each dr In dtb.Rows
            w.Write("<li data-target='#myCarousel' data-slide-to='" & i & "' class='" & IIf(i = 0, "active", "") & "'></li>")
            i += 1
        Next

        w.Write("</ol>")
        w.Write("<div class='carousel-inner'>")
        i = 0
        For Each dr In dtb.Rows
            Dim refUrl = "#"
            If (Not IsDBNull(dr(3))) And dr(3).ToString <> "" Then
                refUrl = dr(3).ToString
            ElseIf (Not IsDBNull((5))) And dr(5).ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr(0)
            End If
            Dim imgUrl
            If Not IsDBNull(dr(4)) Then imgUrl = dr(4).ToString

            w.Write("<div class='item " & IIf(i = 0, "active", "") & "'>")
            i += 1
            w.Write("<a href='" & refUrl & "'>")
            w.Write("<img src='" & imgUrl & "' alt=''>")

            w.Write("</a>")
            w.Write("<div class='carousel-caption'>")
            'If dr("title").ToString <> "" Then w.Write(" <h4>" & dr("title") & "</h4>")
            'If dr("subtitle").ToString <> "" Then w.Write("  <p>" & dr("subtitle") & "</p>")
            w.Write("</div>")
            w.Write("</div>")
        Next


        w.Write("</div>")
        w.Write("<a class='left carousel-control' href='#myCarousel' data-slide='prev'>‹</a>")
        w.Write("<a class='right carousel-control' href='#myCarousel' data-slide='next'>›</a>")
        w.Write("</div>")

        'w.Write("<div id='slide_" & ContentID & "' class='carousel slide'>")
        'w.Write("<ol class='carousel-indicators'>")

        'For Each dr In dtb.Rows
        '    w.Write("<li data-target='#slide_" & ContentID & "' data-slide-to='" & i & "' class='" & IIf(i = 0, "active", "") & "'></li>")
        '    i += 1

        'Next
        'w.Write("</ol>")
        'w.Write("<div class='carousel-inner'>")

        'For Each dr In dtb.Rows
        '    w.Write("<div class='item " & IIf(i = 0, "active", "") & "'>")

        '    Dim refUrl = ""
        '    If (Not IsDBNull(dr(3))) And dr(3).ToString <> "" Then
        '        refUrl = dr.GetString(3).ToString
        '    ElseIf (Not IsDBNull((5))) And dr(5).ToString <> "" Then
        '        refUrl = ReaderPage & ".aspx?itemID=" & dr(0)
        '    End If

        '    Dim imgUrl
        '    If Not IsDBNull(dr(4)) Then imgUrl = dr(4).ToString

        '    If refUrl <> "" Then w.Write("<A href=""" & refUrl & """>")
        '    w.Write("<IMG  alt='' src='" & imgUrl & "'>")
        '    If refUrl <> "" Then w.Write("</A>")

        '    w.Write("<div class='carousel-caption'>")
        '    If dr("title").ToString <> "" Then w.Write(" <h4>" & dr("title") & "</h4>")
        '    If dr("subtitle").ToString <> "" Then w.Write("  <p>" & dr("subtitle") & "</p>")
        '    w.Write("</DIV>")

        '    w.Write("</DIV>")
        'Next
        'w.Write("<a class='left carousel-control' href='#slide_" & ContentID & "' data-slide='prev'>‹</a>" &
        '                       "     <a class='right carousel-control' href='#slide_" & ContentID & "' data-slide='next'>›</a>")
        'w.Write("</DIV>")
        'dtb = Nothing
        db.Close()


        ' w.Write("</DIV>")
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        '   RegisterJquery()
        '   RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/Photosliders/style.css")
        '  RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/Photosliders/js/scripts.js")
    End Sub
End Class