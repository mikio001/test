
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 300
    Public Property boxHeight As Integer = 230
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml

        w.Write("<div id='jslidernews1' class='lof-slidecontent' style='width:280px; height:230px;'>")
        w.Write("<div class='preload'><div></div></div>")
        w.Write("<div  class='button-previous'>Previous</div>")
        w.Write("<div  class='button-next'>Next</div>")
        w.Write("<!-- MAIN CONTENT --> ")
        w.Write("<div class='main-slider-content' style='width:280px; height:230px;'>")
        w.Write("<ul class='sliders-wrap-inner'>")
   

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
        Dim i = 1
        While dr.Read
            Dim refUrl = ""
            If (Not dr.IsDBNull(3)) And dr.GetString(3).ToString <> "" Then
                refUrl = dr.GetString(3).ToString
            ElseIf (Not dr.IsDBNull(5)) And dr.GetString(5).ToString <> "" Then
                refUrl = ReaderPage & ".aspx?itemID=" & dr.GetInt32(0)
            End If

            Dim imgUrl
            If Not dr.IsDBNull(4) Then imgUrl = dr.GetString(4).ToString
            Dim subtitle = ""
            If Not dr.IsDBNull(6) Then subtitle = dr.GetString(6).ToString
            If refUrl <> "" Then w.Write("<A href=""" & refUrl & """>")
            ' w.Write("<IMG id='slide-img-" & dr.GetInt32(0).ToString & "' class='slide' alt='' src='" & imgUrl & "'>")
            w.Write("                <li>")
            w.Write("                        <img src='" & imgUrl & "' width='300' height='230' title='" & dr.GetString(1) & "' >  ")
            w.Write("                        <div>")
            w.Write("                     </div>")
            w.Write("               </li> ")
            i += 1
        End While


        w.Write("            </ul>  	")
        w.Write("       </div>")
        w.Write("	   <!-- END MAIN CONTENT --> ")
        'w.Write("      <!-- NAVIGATOR -->")
        'w.Write("      	<div class='navigator-content'>")
        'w.Write("            <div class='button-control'><span></span></div>	")
        'w.Write("           <div class='navigator-wrapper'>")
        'w.Write("                 <ul class='navigator-wrap-inner'>")
        'For j = 1 To i
        '    w.Write("                    <li><span>" & j & "</span></li>")
        'Next

        'w.Write("                  </ul>")
        'w.Write("           </div>")

        'w.Write("      </div> ")
        w.Write("    <!----------------- END OF NAVIGATOR --------------------->")
        w.Write(" </div> ")


        dr.Close()
        db.Close()

    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID


        'RegisterJquery()
        RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/lofslidernews/css/style4.css")
        RegisterStyleSheet("PhotoslidersCSS2", "~/zulu_cms/contents/lofslidernews/css/layout.css")
        'RegisterScriptInclude("PhotoslidersCR1", "~/zulu_cms/contents/lofslidernews/js/jquery.js")
        RegisterScriptInclude("PhotoslidersCR2", "~/zulu_cms/contents/lofslidernews/js/jquery.easing.js")
        RegisterScriptInclude("PhotoslidersCR3", "~/zulu_cms/contents/lofslidernews/js/script.js")
    End Sub
End Class