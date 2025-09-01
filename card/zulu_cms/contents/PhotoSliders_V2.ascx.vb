
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 315
    Public Property boxHeight As Integer = 121
   
    Public Property EditorID As String = "GALLERY"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml
        w.Write("<div id='main_container'> " &
               " <div id='content'> " &
                 "   <div class='right_panel'> " &
                  "      <a id='main-content'></a> " &
                   "     <div id='home_features'> " &
                     "       <div class='region region-featured-slider'> " &
                     "           <div id='block-views-featured-slideshow-block-1'  " &
                      "              class='block block-views first last odd'> " &
                       "             <div class='content'> " &
                        "                <div class='view view-featured-slideshow view-id-featured_slideshow view-display-id-block_1 feature-content view-dom-id-1'> " &
                         "                ")



        w.Write("<DIV id=header><DIV class=wrap>" &
                "<DIV id=slide-holder>" &
                "<DIV id=slide-runner>")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and (expireDate is null or expireDate > GETDATE()) order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
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
            Dim subtitle = ""
            If Not dr.IsDBNull(6) Then subtitle = dr.GetString(6).ToString
            ' If refUrl <> "" Then w.Write("<A href=""" & refUrl & """>")
            ' w.Write("<IMG id='slide-img-" & dr.GetInt32(0).ToString & "' class='slide' alt='' src='" & imgUrl & "'>")

            w.Write("<div class='feature'> " &
                                                "<div class='field field-name-field-slider-image field-type-image field-label-hidden'> " &
                                                   " <div class='field-items'> " &
                                                       " <div class='field-item even'> " &
                                                        "    <img alt=''  " &
                                                         "       src='" & imgUrl & "' typeof='foaf:Image' /></div> " &
                                                   " </div> " &
                                              "  </div> " &
                                              "  <div class='feature_content'> " &
                                                 "   <h2> " &
                                                     "   <a href='http://localhost:50922/node/215'>" & dr.GetString(1).ToString & "</a></h2> " &
                                                  "  <div class='field field-name-body field-type-text-with-summary field-label-hidden'> " &
                                                     "   <div class='field-items'> " &
                                                       "     <div class='field-item even' property='content:encoded'> " &
                                                       "         " & subtitle & "</div> " &
                                                     "   </div> " &
                                                "    </div> " &
                                                 "   <div class='field field-name-field-slider-link field-type-link-field field-label-hidden'> " &
                                                    "    <div class='field-items'> " &
                                                      "      <div class='field-item even'> " &
                                                       "         <a href='" & refUrl & "'>testing</a></div> " &
                                                      "  </div> " &
                                                 "   </div> " &
                                            "    </div> " &
                                          "  </div>")

            ' If refUrl <> "" Then w.Write("</A>")

            If str <> "" Then str &= ","
            str &= "{'id': 'slide-img-" & dr.GetInt32(0).ToString & "','client': '" & dr.GetString(1).ToString & "','desc': ''}"

        End While

        w.Write("                    </div> " &
                        "            </div> " &
                       "         </div>   " &
                       "     </div>   " &
            "   </div> " &
                   "     <div class='over_panel'> " &
                     "       <h2></h2> " &
                    "        <p></p> " &
                    "        <div class='navigation'> " &
                    "            <a class='btn_learnmore' href='http://localhost:50922/summer-camps'>อ่านต่อ</a> " &
                     "           <a class='btn_prev' href='#'>Previous</a> <a class='btn_next' href='#'>Next</a> " &
                    "        </div> " &
                    "    </div>           " &
                     "   </div> " &
                    "    <div class='over_nav'> " &
                    "        <div class='region region-highlight'> " &
                     "           <div id='block-block-2' class='block block-block first last odd'> " &
                     "           </div>          " &
                     "       </div>        " &
            "   </div>    " &
             "    </div> " &
               " </div> ")

        w.Write(" <script type='text/javascript'>" &
       "        var setup_homepage = new SetupHomepage(); " &
"</script> ")
        dr.Close()
        db.Close()

    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = EditorID
        StartEditorToolbox1.ContentID = ContentID
        'RegisterJquery()
        'RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/Photosliders/style.css")
        'RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/Photosliders/js/scripts.js")
    End Sub
End Class