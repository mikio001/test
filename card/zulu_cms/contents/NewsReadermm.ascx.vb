
Partial Class zulu_cms_contents_NewsReader
    Inherits Zulu.Cms.ReaderControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EndNewsReader.ContentID = ContentID
        EndNewsReader.EditorID = "NEWS"
        StartNewsReader.ContentID = ContentID
    End Sub

    Protected Sub NewsReader_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewsReader.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)

        Dim itemID = CInt(Request.QueryString("itemID"))

        Dim dr = db.GetReader("select title,contentBody,modifyBy,modifyDate,SiteID from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", itemID))
        db.ThrowIfError()

        Dim NSite As New NewsSite
        If dr.Read Then
            w.Write("<h2>ประกาศระเบียบ</h2>")
            w.Write("<h1>")
            w.Write(dr.GetString(0))
            w.Write("</h1>")
            w.Write("<div class=""newsContent"">")
            w.Write(dr.GetString(1))
            w.Write("</div>")
            w.Write("<div class=""newsFooter"">")
            w.Write("ที่มา :" & NSite.GetSiteName(dr.GetString(4)) & " &nbsp;&nbsp; ")
            w.Write("แก้ไขล่าสุดโดย: ")
            w.Write(dr.GetString(2))
            w.Write(" วันที่: ")
            w.Write(dr.GetDateTime(3).ToString("d MMM yyyy HH:mm"))
            w.Write("</div>")
            EndNewsReader.SSiteID = dr.GetString(4)
            StartNewsReader.SSiteID = dr.GetString(4)
        End If
      
        dr.Close()
        db.Close()
    End Sub
End Class
