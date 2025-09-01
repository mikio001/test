
Partial Class zulu_cms_contents_SlideCalendar
    Inherits Zulu.Cms.ReaderControl
    Public Property boxWidth As Integer = 320
    Public Property boxHeight As Integer = 200
   
    Public Property EditorID As String = "VIDEO"
    Public Property ReaderPage As String = "ContentShow"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles PhotoSlider.RenderHtml

    
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        ' Response.Write("select itemID,title,contentType,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID ")
        Dim dr = db.GetReader("select top 1 itemID,title,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID order by orderNO,itemID desc ", db.NewParam("contentID", ContentID), db.NewParam("SiteID", SiteID))
        db.ThrowIfError()
        Dim str = ""
      
        While dr.Read
            Dim refUrl = ""

            w.Write(YoutubeEM2(dr(2)))
        End While

        dr.Close()
        db.Close()
       
    End Sub

    Function YoutubeEM(ByVal YoutubeURL As String) As String
        Dim str As String
        str = "<object width='425' height='344'> " &
                "<param name='movie' value='" & YoutubeURL & "?fs=1'</param>   " &
                "<param name='allowFullScreen' value='true'></param> " &
                "<param name='allowScriptAccess' value='always'></param> " &
                "<embed src='" & YoutubeURL & "?fs=1' " &
                 " type='application/x-shockwave-flash' " &
                 " allowfullscreen='true' " &
                 " allowscriptaccess='always' " &
                 " width='425' height='344'> " &
                "</embed> " &
                "</object>"
        Return str
    End Function
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
        
    End Sub
End Class