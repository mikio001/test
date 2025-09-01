
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 8
    Public Property NewsReaderPageUrl As String = "News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewDateLength As Integer = 5
    Public Property NewsType As Integer = 0
    Public Property FromSiteID As String = Zulu.Cms.Factory.SiteID

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewsTopList.RenderHtml
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String = ""
        Dim WnewType As String = ""
        If NewsType <> 0 Then
            WnewType = " and contenttype=" & NewsType
        End If

        Dim top = ""
        If MaxNewsCount > 0 Then
            top = " top " & MaxNewsCount & ""
        End If
        Dim resUrl = ResolveClientUrl("~/resources")
        sql = "select  " & top & " itemID,title,modifyDate,refUrl from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate > GETDATE() " & WnewType & " order by itemID desc"

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", FromSiteID))

        Dim errMsg As String = ""
        Dim hasNews = False
        w.Write("<ul>")
        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
            While dr.Read

                w.Write("<li>")
                w.Write("<a href=""")
                w.Write(String.Format(NewsReaderPageUrl, dr.GetInt32(0)))
                w.Write(""" class=""bulletLink"">")
                w.Write(dr.GetString(1))
                If DateDiff(DateInterval.Day, dr.GetDateTime(2), Now) <= NewDateLength Then
                    'w.Write(" <img src=""" & resUrl & "/new.gif"" align=""absmiddle"" border=""0"" />")
                End If
                w.Write("</a>")
                w.Write("</li>")
                hasNews = True
            End While
            dr.Close()
        End If
        w.Write("</ul>")
        If Not hasNews Then w.Write("- ยังไม่มีข่าวในหมวดนี้ -")
        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = FormEditorID
        StartEditorToolbox1.ContentID = ContentID

    End Sub
End Class