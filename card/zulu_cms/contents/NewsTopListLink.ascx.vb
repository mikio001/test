
Partial Class zulu_cms_contents_NewsTopListLink
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 8
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewsTopList.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String = ""

        If MaxNewsCount > 0 Then
            sql = "select top " & MaxNewsCount & " itemID,title,modifyDate from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate > GETDATE() order by itemID desc"
        Else
            sql = "select itemID,title,modifyDate from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate > GETDATE() order by itemID desc"
        End If

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)

            w.Write("<ul>")

            While dr.Read
                w.Write("<li><a href=""" & String.Format(readPage, dr.GetInt32(0)) & """ target=""" & Target & """>" & dr.GetString(1) & "</a> <span class=""smallText"">" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</span></li>")
            End While

            w.Write("</ul>")
            dr.Close()
        End If

        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = "NEWS"
        StartEditorToolbox1.ContentID = ContentID
    End Sub
End Class