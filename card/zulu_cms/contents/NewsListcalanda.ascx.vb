
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 8
    Public Property NewsReaderPageUrl As String = "~/ContentShow.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
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

        sql = "select  " & top & " itemID,title,modifyDate,refUrl,startDate from ZCMS_CONTENT where contentID=@contentID and enddate>=getdate() and startdate<=dateadd(month,3,getdate()) and siteID=@siteID " & WnewType & " order by startDate,itemID "

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", FromSiteID))

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)


            'w.Write("<ul>")
            w.Write("<div class='event postcard-left'>")
            While dr.Read
                Dim refUrl As String
                If Not dr.IsDBNull(3) AndAlso dr.GetString(3) <> "" Then
                    refUrl = dr.GetString(3)
                Else
                    refUrl = String.Format(readPage, dr.GetInt32(0))
                End If
                w.Write("<div class='event-date'>")
                w.Write("<span class='event-month'>")
                w.Write("<div style='font-size: 16px'>" & dr("startDate") & "</div>")
                'w.Write("<div class=""bs-callout bs-callout-warning""><a href=""" & refUrl & """ target=""" & Target & """>" & dr.GetString(1) & "</a> <span class=""smallText"">" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</span></div>")
                w.Write("</span>")
                w.Write("</div>")
                w.Write("<h3><a href=""" & refUrl & """>" & dr.GetString(1) & "</a></h3>")
            End While

            w.Write("</div>")
            'w.Write("</ul>")

            dr.Close()
        End If

        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = FormEditorID
        StartEditorToolbox1.ContentID = ContentID

    End Sub
End Class