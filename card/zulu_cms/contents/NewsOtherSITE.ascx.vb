
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 20
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewsType As Integer = 0
    Public Property FromSiteID As String = Zulu.Cms.Factory.SiteID

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.EditorID = FormEditorID

        EndEditorToolbox1.ContentID = ContentID
        StartEditorToolbox1.ContentID = ContentID

        EndEditorToolbox1.SSiteID = FromSiteID
        StartEditorToolbox1.SSiteID = FromSiteID
    End Sub
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

        Dim props = ""
        Dim CHK As New CheckContentPermit
        If Zulu.Cms.Factory.IsEditMode = True Then
            If CHK.CheckAddPermission(ContentID, FromSiteID) = False And CHK.CheckEditPermission(ContentID, FromSiteID) = False And CHK.CheckPropPermission(FromSiteID) = False Then
                props = " and propsStatus = 1 "
            End If
        Else
            props = " and propsStatus = 1 "
        End If


        sql = "select " & top & " itemID,title,modifyDate,refUrl,(case when propsStatus is null or propsStatus=0 then 'รอพิจารณา' when propsStatus=2 then 'ไม่อนุญาติให้ขึ้นเว็บไซต์' else '' End) as Description from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID and expireDate > GETDATE() " & WnewType & " " & props & " order by itemID desc"

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", FromSiteID))
        Dim errMsg As String = ""
        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)

            w.Write("<ul>")

            While dr.Read
                Dim refUrl As String
                If Not dr.IsDBNull(3) AndAlso dr.GetString(3) <> "" Then
                    refUrl = dr.GetString(3)
                Else
                    refUrl = String.Format(readPage, dr.GetInt32(0))
                End If

                w.Write("<li><a href=""" & refUrl & """ target=""" & Target & """>" & dr.GetString(1) & "</a> <span class=""smallText"">" & "  " & dr.GetString(4) & "  " & dr.GetDateTime(2).ToString("d MMM yyyy") & "</span></li>")
            End While

            w.Write("</ul>")
            dr.Close()
        End If
        db.Close()

    End Sub
    

End Class



