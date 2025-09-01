
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "NewEditor"
    Public Property FormID As String = "NewForm"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewEditor.RenderHtml



        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dtb = db.GetDataTable("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle,imgUrl2 from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID  order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        Dim err
        If db.IsError(Err) Then
            w.Write(err)
            db.Close()
            Exit Sub
        End If
        Dim str = ""
        Dim hg = ""
        Dim ol
        Dim item

        w.Write("<div id='" & ContentID & "' class='carousel slide'>")
        'Dim loopRing() = {"1", "2", "3", "4", "5", "5", "7"}

        ' Dim i = 0

        Dim active = "class='active'"
        Dim itemactive = "class='item active'"
        w.Write("<ol class='carousel-indicators'>")

        For i As Integer = 0 To dtb.Rows.Count - 1
            w.Write("<li data-target='#" & ContentID & "' data-slide-to='" & i & "' " & active & "></li>")
            active = ""
        Next
        w.Write("</ol>")
        w.Write("<div class='carousel-inner'>")
        For Each dr In dtb.Rows


            Dim refUrl = ""
            If (Not IsDBNull(dr("refUrl"))) And dr("refUrl").ToString <> "" Then
                refUrl = dr("refUrl").ToString
            ElseIf (Not IsDBNull(dr("contentBody"))) And dr("contentBody").ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr("itemID").ToString
            End If

            Dim imgUrl = ""
            Dim imgUrl2 = ""
            If Not IsDBNull(dr("imgUrl")) Then imgUrl = dr("imgUrl")
            If Not IsDBNull(dr("imgUrl2")) Then imgUrl2 = dr("imgUrl2")
            Dim subtitle = ""
            If Not IsDBNull(dr("subtitle")) Then subtitle = dr("subtitle")

            w.Write(" <div " & itemactive & " style=''>") : itemactive = "class='item'"
            w.Write("<div style='position:absolute;background-image: url(FileUpload/" & imgUrl2 & ");-webkit-filter: blur(5px); -moz-filter: blur(5px); -o-filter: blur(5px); -ms-filter: blur(5px); filter: blur(5px);height: 100%;width: 100%;'></div>")
            w.Write("        <div class='container'>")
            w.Write("            <div class='row slide-margin'>")
            w.Write("                <div class='col-sm-6'>")
            w.Write("                    <div class='carousel-content center centered maxky'>")
            w.Write("                        <h1 class='animation animated-item-1'>" & dr("title") & "</h1>")
            w.Write("                        <h4 class='animation animated-item-2'>" & dr("subtitle") & "</h4>")
            w.Write("                        <a class='btn-slide animation animated-item-3' href='FileUpload/" & refUrl & "'></a>")
            w.Write("                    </div>")
            w.Write("                </div>")

            w.Write("                <div class='col-sm-6 hidden-xs animation animated-item-4'>")
            w.Write("                    <div class='slider-img' >")
            w.Write("                        <img src='FileUpload/" & imgUrl & "' class='img-responsive' style='padding-top:0px'>")
            w.Write("                    </div>")
            w.Write("                </div>")

            w.Write("            </div>")
            w.Write("        </div>")
            w.Write("    </div><!--/.item-->")


            'w.Write("<div " & itemactive & " style='background-image: url(images/slider/bg1.jpg)'") : itemactive = "class='item'"

            'w.Write("<div class='container'>")
            'w.Write("<div class='row slide-margin'>")
            'w.Write("<div class='col-sm-6'>")
            'w.Write("<div class='carousel-content'>")
            'w.Write("<h1 class='animation animated-item-1'>" & dr("title") & "</h1>")
            'w.Write("<h2 class='animation animated-item-2'>" & dr("subtitle") & "</h2>")
            'w.Write("<a class='btn-slide animation animated-item-3'")
            'If refUrl <> "" Then item &= ("<a href='" & refUrl & "'>")

            'w.Write("</a>")

            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("<div class='col-sm-6 hidden-xs animation animated-item-4'>")
            'w.Write("<div class='slider-img' >")
            'w.Write("<img src='" & imgUrl & "' alt='...' class='img-responsive'>")
            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("</div>")
            'w.Write("</div>")












            'item &= "<div " & itemactive & ">"
            'If refUrl <> "" Then item &= ("<a href='" & refUrl & "'>")
            'If InStr(imgUrl, "http") > 0 Then
            '    item &= "<img src='" & imgUrl & "' alt='...'>"
            'Else
            '    item &= "<img src='http://www.up.ac.th/" & imgUrl & "' alt='...'>"
            'End If

            'If refUrl <> "" Then item &= ("</a>")
            'item &= "<div class='carousel-caption'>"
            'item &= "  <h3 style='color: #FFF;'>" & dr("title") & "</h3>"
            'item &= "   <p>" & dr("subtitle") & "</p>"
            'item &= " </div>"
            'item &= "</div>"
            'itemactive = "class='item'"
            '   w.Write("       <img src='http://www.up.ac.th/" & imgUrl & "' alt='Placeholder' class='bigImage animate" & loopRing(i) & "' style='display: none;'>")
            ' w.Write("<span class='slide5Txt1 animate1 fadeInLeftBig' data-animate='fadeInLeftBig' style=''>มหาวิทยาลัยพะเยา</span>")
            '  w.Write("<span class='slide5Txt2 animate2 fadeInRightBig' data-animate='fadeInRightBig' style=''>University of Phayao</span>")



        Next
        w.Write("</div>")
        'w.Write("<ol class='carousel-indicators'>")
        'w.Write(ol)
        'w.Write("</ol>")


        w.Write("<a class='prev hidden-xs' href='#'" & ContentID & "data-slide='prev'><i class='icon-angle-left'></i></a>")
        w.Write("<a class='next hidden-xs' href='#" & ContentID & "' data-slide='next'><i class='icon-angle-right'></i></a>")
        'w.Write("<a class='prev hidden-xs' href='#" & ContentID & "' data-slide='prev'>&lsaquo; <i class='fa fa-chevron-left'></i></a>")
        'w.Write("<a class='prev hidden-xs' href='#" & ContentID & "' data-slide='next'>&rsaquo;<i class='fa fa-chevron-right'></i></a>")

        'w.Write("</div>")
        'w.Write("<script type='text/javascript'>")
        'w.Write(" $(document).ready(function() {")
        'w.Write("     $('#" & ContentID & "').carousel({")
        'w.Write("          interval: 5000")
        'w.Write("      })")
        'w.Write(" });    ")
        'w.Write("</script>")
        dtb = Nothing
        db.Close()

    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        EndEditorToolbox1.FormID = FormID
        StartEditorToolbox1.ContentID = ContentID
        'RegisterJquery()
        ' RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/nivo-slide/nivo-slider/nivo-slider.css")
        ' RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/nivo-slide/nivo-slider/jquery.nivo.slider.js")



    End Sub
End Class