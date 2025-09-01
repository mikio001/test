
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml
       
       

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and (expireDate is null or expireDate > GETDATE()) order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
        Dim hg = ""
       
        Dim loopRing() = {"1", "2", "3", "4", "5", "5", "7"}
        Dim i = 0
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
     

            If refUrl <> "" Then w.Write("<a href='" & refUrl & "'>")

            w.Write(" <div class='oneByOne_item' >")

            
            w.Write("       <img src='http://www.up.ac.th/" & imgUrl & "' alt='Placeholder' class='bigImage animate" & loopRing(i) & "' style='display: none;'>")
            ' w.Write("<span class='slide5Txt1 animate1 fadeInLeftBig' data-animate='fadeInLeftBig' style=''>มหาวิทยาลัยพะเยา</span>")
            '  w.Write("<span class='slide5Txt2 animate2 fadeInRightBig' data-animate='fadeInRightBig' style=''>University of Phayao</span>")
            w.Write("</div>")
            If refUrl <> "" Then w.Write("</a>")

            i += 1
            If i > loopRing.Length - 1 Then
                i = 0
            End If
        End While


        dr.Close()
        db.Close()

    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        'RegisterJquery()
        ' RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/nivo-slide/nivo-slider/nivo-slider.css")
        ' RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/nivo-slide/nivo-slider/jquery.nivo.slider.js")



    End Sub
End Class