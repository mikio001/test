
Partial Class zulu_cms_contents_HtmlContent
    Inherits Zulu.Cms.ReaderControl

    Protected Sub DirectRender1_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles HtmlContent.RenderHtml
        If String.IsNullOrEmpty(ContentID) Then Exit Sub

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        Dim errMsg As String = ""

        If Not db.IsError(errMsg) Then
            If dr.Read Then
                w.Write(dr.GetString(0))
                dr.Close()
                db.Close()
                Exit Sub
            Else
                dr.Close()
                db.Execute("insert into ZCMS_CONTENT(contentID,contentBody,siteID,title,createBy,createDate,modifyBy,modifyDate,editorID) values(@contentID,'HTML CONTENT',@siteID,'Untitled Page','SYSTEM',GETDATE(),'SYSTEM',GETDATE(),'HTML')", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
                db.Close()
                w.Write("HTML CONTENT")
                If Not db.IsError(errMsg) Then Exit Sub
            End If
        End If

        Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
    End Sub
 
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        HtmlEditorToolbox.ContentID = ContentID
        'StartEditorToolbox1.ContentID = ContentID
        HtmlEditorToolbox.EditorID = "HtmlEditor"

    End Sub
End Class
