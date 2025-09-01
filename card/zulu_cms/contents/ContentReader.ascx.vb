
Partial Class zulu_cms_contents_ContentReader
    Inherits Zulu.Cms.ReaderControl
    Public Property CustomEditPage As String
    Public Property CustomAddPage As String
    Public Property EditorID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EndNewsReader.ContentID = ContentID
        EndNewsReader.EditorID = "NEWS"
    End Sub

    Protected Sub NewsReader_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewsReader.RenderHtml


        Dim itemID = Request.QueryString("itemID")
        If IsNumeric(itemID) Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)

            Dim dr = db.GetReader("select title,contentBody,modifyBy,modifyDate,ContentID from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", itemID))
            db.ThrowIfError()

            If dr.Read Then
                w.Write("<div class='col-lg-12'><h3>" & dr("title") & "</h3>")
                w.Write("<p>")
                w.Write(dr("contentBody"))
                w.Write("</p></div>")
                EndNewsReader.ContentID = dr.GetString(4)
                If CustomAddPage <> "" Then EndNewsReader.CustomAddPage = CustomAddPage
                If CustomEditPage <> "" Then EndNewsReader.CustomEditPage = CustomEditPage
                If EditorID <> "" Then EndNewsReader.EditorID = EditorID
            Else
                w.Write("ไม่พบหน้า")
            End If

            dr.Close()
            db.Close()
        Else
            w.Write("ไม่พบหน้า")
        End If

    End Sub
End Class
