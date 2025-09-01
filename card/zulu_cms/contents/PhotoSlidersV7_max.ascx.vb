Imports System.Data

Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl


    'Public Property EditorID As String = "GALLERY"
    'Public Property ReaderPage As String = "ContentShow"
    Public Property FormEditorID As String = "GalleryFileEditor"
    Public Property NewEditorNews As String = "NewEditorNews"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml


        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)

        Dim dtb As DataTable = db.GetDataTable("select itemID,title,contentType,refUrl,imgUrl,contentBody,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID  order by orderNO ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
        Dim active = "active"
        Dim i = 0
        For Each dr In dtb.Rows
            If i = 0 Then w.Write("  <div class='item " & active & "'>") : active = ""
            i += 1
            w.Write("                     <div class='row'>")
            w.Write("                        <div class='col-xs-4'>")
            w.Write("                          <div class='portfolio-item'>")
            w.Write("                              <div class='item-inner'>")
            w.Write("                                  <img class='img-responsive' src='fileupload/" & dr("imgurl") & "' alt=''>")
            w.Write("                                 <h5>")
            w.Write(dr("title"))
            w.Write("                                     </h5>")
            w.Write("                                     <div class='overlay'>")
            w.Write("                                         <a class='preview btn btn-danger' title='Malesuada fames ac turpis egestas' href='images/portfolio/full/item3.jpg' rel='prettyPhoto'><i class='icon-eye-open'></i></a>")
            w.Write("                                      </div>")
            w.Write("                                </div>")
            w.Write("                            </div>")
            w.Write("                         </div>    ")

            If i = 3 Then
                w.Write("</div><!--/.row-->")
                w.Write("</div>")
                i = 0
            End If

        Next
        If i <> 3 Then
            w.Write("</div><!--/.row-->")
            w.Write("</div>")
        End If




        db.Close()



    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        'EndEditorToolbox1.EditorID = EditorID
        EndEditorToolbox1.EditorID = NewEditorNews
        EndEditorToolbox1.FormID = FormEditorID
        StartEditorToolbox1.ContentID = ContentID
        '   RegisterJquery()
        '   RegisterStyleSheet("PhotoslidersCSS", "~/zulu_cms/contents/Photosliders/style.css")
        '  RegisterScriptInclude("PhotoslidersCR", "~/zulu_cms/contents/Photosliders/js/scripts.js")
    End Sub
End Class