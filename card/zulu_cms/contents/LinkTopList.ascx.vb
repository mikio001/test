
Partial Class zulu_cms_contents_LinkTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxLinkCount As Integer = 8
    Public Property LinkReaderPageUrl As String = "~/Link_Read.aspx?linkID={0}"
    Public Property Target As String = "_self"
    Public Property ShowReaderPage As Boolean = False

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles LinkTopList.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String

        If MaxLinkCount > 0 Then
            sql = "select top " & MaxLinkCount & " itemID,title,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID order by orderNo"
        Else
            sql = "select itemID,title,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID order by orderNo"
        End If

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))

        Dim errMsg As String = ""
        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            w.Write("<ul>")

            If ShowReaderPage Then
                Dim readPage = ResolveClientUrl(LinkReaderPageUrl)

                While dr.Read
                    w.Write("<li><a href=""" & String.Format(readPage, dr.GetInt32(0)) & """ target=""" & Target & """>" & dr.GetString(1) & "</a></li>")
                End While
            Else
                While dr.Read
                    w.Write("<li><a href=""" & ResolveClientUrl(dr.GetString(2)) & """ target=""" & Target & """>" & dr.GetString(1) & "</a></li>")
                End While
            End If

            w.Write("</ul>")
            dr.Close()
        End If

        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = "LINK"
    End Sub
End Class