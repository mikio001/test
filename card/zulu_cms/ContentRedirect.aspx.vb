
Partial Class zulu_cms_ContentRedirect
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, False)
        db.Execute("update ZCMS_CONTENT set countRead=0 where countRead is null and itemID=" & Request.QueryString("itemID"))
        db.Execute("update ZCMS_CONTENT set countRead=countRead+1 where itemID=" & Request.QueryString("itemID"))
        db.Close()
        Response.Redirect(Request.QueryString("URL"))
    End Sub
End Class
