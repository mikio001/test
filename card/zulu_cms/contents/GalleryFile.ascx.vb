
Partial Class zulu_cms_contents_Gallery
    Inherits Zulu.Cms.ReaderControl
    Property ItemID As Integer
    Private Const UploadDirectory As String = "~/GalleryContent/"
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GalleryEnd.ContentID = ContentID
        GalleryEnd.EditorID = "GALLERYFILE"

        RegisterJquery()
        RegisterStyleSheet("GALLERYCSS1", "~/zulu_cms/contents/gallery/css/galleriffic-2.css")
        RegisterScriptInclude("GALLERYSCR0", "~/zulu_cms/contents/gallery/js/jquery-1.3.2.js")
        RegisterScriptInclude("GALLERYSCR2", "~/zulu_cms/contents/gallery/js/jquery.galleriffic.js")
        RegisterScriptInclude("GALLERYSCR3", "~/zulu_cms/contents/gallery/js/jquery.opacityrollover.js")
      
    End Sub
    Function getImgURL(ByVal img As String) As String
        Return ResolveClientUrl(UploadDirectory & img)
    End Function
    Function getImgURLthumbnail(ByVal img As String) As String
        Return ResolveClientUrl(UploadDirectory & "thumbnail_" & img)
    End Function

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select imageID,filename,description,storename from ZCMS_CONTENT_GALLERY where ItemID=@ItemID order by imageID", db.NewParam("ItemID", ItemID))
        Dim refUrl, title As String
        db.ThrowIfError()

        w.Write("<h2>Integration with history plugin</h2>")

        w.Write("<div id='gallery' class='content'>")
        w.Write("<div id='controls' class='controls'></div>")
        w.Write("<div class='slideshow-container'>")
        w.Write("<div id='loading' class='loader'></div>")
        w.Write("<div id='slideshow' class='slideshow'></div>")
        w.Write("</div>")
        w.Write("<div id='caption' class='caption-container'></div>")
        w.Write("</div>")
        w.Write("<div id='thumbs' class='navigation'>")
        w.Write("<ul class='thumbs noscript'>")

        While dr.Read
            title = dr.GetString(1)
            refUrl = dr.GetString(3)
            w.Write("<li>")
            w.Write("<a class='thumb' name='leaf' href='" & getImgURL(refUrl) & "' title='Title #0'>")
            w.Write("<img src='" & getImgURLthumbnail(refUrl) & "' alt='Title #0' />")
            w.Write("</a>")
            w.Write("<div class='caption'>")
            w.Write("<div class='download'>")
            w.Write("<a href='" & getImgURL(refUrl) & "'>Download Original</a>")
            w.Write("</div>")
            w.Write("<div class='image-title'>Title #0</div>")
            w.Write("<div class='image-desc'>Description</div>")
            w.Write("</div>")
            w.Write("</li>")
        End While

        w.Write("</ul>")
        w.Write("</div>")
        w.Write("<div style='clear: both;'></div>")
        w.Write("<script type='text/javascript' src='" & ResolveClientUrl("~/zulu_cms/contents/gallery/jsGallery.js") & "'></script>")

        dr.Close()
        db.Close()


        'w.Write("<script type=""text/javascript"">")
        'w.Write("document.write('<style>.noscript { display: none; }</style>');")
        'w.Write("</script>")

        'w.Write("<div id=""gallery"" class=""content"">")
        'w.Write("<div id=""controls"" class=""controls""></div>")
        'w.Write("<div class=""slideshow-container"">")
        'w.Write("<div id=""loading"" class=""loader""></div>")
        'w.Write("<div id=""slideshow"" class=""slideshow""></div>")
        'w.Write("</div>")
        'w.Write("<div id=""caption"" class=""caption-container""></div>")
        'w.Write("</div>")

        'w.Write("<div id=""thumbs"" class=""navigation"">")
        'w.Write("<ul class=""thumbs noscript"">")

        'Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        'Dim dr = db.GetReader("select imageID,filename,description,storename from ZCMS_CONTENT_GALLERY where ItemID=@ItemID order by imageID", db.NewParam("ItemID", ItemID))
        'Dim refUrl, title As String
        'db.ThrowIfError()

        'While dr.Read
        '    title = dr.GetString(1)
        '    refUrl = dr.GetString(3)

        '    w.Write("<li>")
        '    w.Write("<a class=""thumb"" name=""leaf"" href=""" & getImgURL(refUrl) & """ title=""" & title & """>")
        '    w.Write("<img src=""" & getImgURLthumbnail(refUrl) & """ alt=""" & title & """ />")
        '    w.Write("</a>")
        '    w.Write("<div class=""caption"">")
        '    w.Write("<div class=""download"">")
        '    w.Write("<a href=""" & dr.GetString(3) & """>ดาวน์โหลดภาพขนาดต้นฉบับ</a>")
        '    w.Write("</div>")
        '    w.Write("<div class=""image-title"">" & title & "</div>")
        '    w.Write("<div class=""image-desc"">" & dr.GetString(2) & "</div>")
        '    w.Write("</div>")
        '    w.Write("</li>")
        'End While

        'dr.Close()
        'db.Close()


        'w.Write("</ul>")
        'w.Write("</div>")
        'w.Write("<div style=""clear: both;""></div>")

        'w.Write("<script type=""text/javascript"">")
        'w.Write("jQuery(document).ready(function($) {")
        'w.Write("$('div.navigation').css({'width' : '300px', 'float' : 'left'});")
        'w.Write("$('div.content').css('display', 'block');")
        'w.Write("var onMouseOutOpacity = 0.67;")
        'w.Write("$('#thumbs ul.thumbs li').opacityrollover({")
        'w.Write("mouseOutOpacity:   onMouseOutOpacity,")
        'w.Write("mouseOverOpacity:  1.0,")
        'w.Write("fadeSpeed:  'fast',")
        'w.Write("exemptionSelector:  '.selected'")
        'w.Write("});")
        'w.Write("var gallery = $('#thumbs').galleriffic({")
        'w.Write("delay:                     2500,")
        'w.Write("numThumbs:                 15,")
        'w.Write("preloadAhead:              10,")
        'w.Write("enableTopPager:            true,")
        'w.Write("enableBottomPager:         true,")
        'w.Write("maxPagesToShow:            7,")
        'w.Write("imageContainerSel:  '#slideshow',")
        'w.Write("controlsContainerSel:  '#controls',")
        'w.Write("captionContainerSel:  '#caption',")
        'w.Write("loadingContainerSel:  '#loading',")
        'w.Write("renderSSControls:          true,")
        'w.Write("renderNavControls:         true,")
        'w.Write("playLinkText:  'เล่นสไลด์โชว์',")
        'w.Write("pauseLinkText:  'หยุดสไลด์โชว์',")
        'w.Write("prevLinkText:  '&lsaquo;&lsaquo; ภาพก่อนหน้า',")
        'w.Write("nextLinkText:  'ภาพถัดไป &rsaquo;&rsaquo;',")
        'w.Write("nextPageLinkText:  'ถัดไป &rsaquo;&rsaquo;',")
        'w.Write("prevPageLinkText:  '&lsaquo;&lsaquo; ก่อนหน้า',")
        'w.Write("enableHistory:             false,")
        'w.Write("autoStart:                 false,")
        'w.Write("syncTransitions:           true,")
        'w.Write("defaultTransitionDuration: 900,")
        'w.Write("onSlideChange:             function(prevIndex, nextIndex) {")
        'w.Write("this.find('ul.thumbs').children()")
        'w.Write(".eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()")
        'w.Write(".eq(nextIndex).fadeTo('fast', 1.0);")
        'w.Write("},")
        'w.Write("onPageTransitionOut:       function(callback) {")
        'w.Write("this.fadeTo('fast', 0.0, callback);")
        'w.Write("},")
        'w.Write("onPageTransitionIn:        function() {")
        'w.Write("this.fadeTo('fast', 1.0);")
        'w.Write("}")
        'w.Write("});")
        'w.Write("});")
        'w.Write("</script>")
    End Sub
End Class
