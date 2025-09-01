
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 10
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewsType As Integer = 0
    Public Property NewSID As String = ""
    Public Property ContentID As String = "News1"

    Protected Sub NewsTopList_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles NewsTopList.RenderHtml
      

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim sql As String = ""
        Dim WnewType As String = ""
        If NewsType <> 0 Then
            WnewType = " and contenttype=" & NewsType
        End If
        sql = GetSQL(0, WnewType)

        Dim dr = db.GetReader(sql)
        Dim errMsg As String = ""
        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
            Dim IDN = ""
            'If NewSID <> "" Then IDN = "ID='" & ContentID & "'"
            w.Write("<ul >")

            While dr.Read
                Dim refUrl As String
                If Not dr.IsDBNull(3) AndAlso dr.GetString(3) <> "" Then
                    refUrl = dr.GetString(3)
                Else
                    refUrl = String.Format(readPage, dr.GetInt32(0))
                End If

                w.Write("<li style='list-style-image: url(../resources/bullet.jpg);border-bottom-style: dotted; border-bottom-width: 1px;padding-top:5px;padding-bottom:10px; border-bottom-color: #C0C0C0' ><a href=""" & refUrl & """ target=""" & Target & """>" & dr.GetString(1) & "</a> |<font style='font-style: italic; color: #808080'>" & dr.GetString(4) & "  " & dr.GetDateTime(2).ToString("d MMM yyyy") & "</font></li>")
            End While

            w.Write("</ul>")
            dr.Close()
        End If
        db.Close()

    End Sub
    Function GetSQL(ByVal index As Integer, ByVal WnewType As String)
        ' Dim SiteKey As New NewsSite
        Dim sql = ""
        Dim top = ""
        Dim Where = ""
        If MaxNewsCount > 0 Then
            top = " top " & MaxNewsCount & ""
        End If
        Dim Desp = ""
        'For i As Integer = 1 To SiteKey.GetCount
        '    Dim vSiteID = SiteKey.GetSite(i)
        '    If Desp = "" Then Desp &= " Case  "
        '    If Where <> "" Then Where &= " or "
        '    Where &= " (ContentID='" & vSiteID(1) & "' and SiteID='" & vSiteID(0) & "') "
        '    Desp &= " when SiteID='" & vSiteID(0) & "' then '" & vSiteID(2) & "'"
        'Next
        If Where <> "" Then Where = " and (" & Where & ")" : Desp &= " else '' end "
        sql = " select " & top & " itemID,title,modifyDate,refUrl, Description from vwZCMS_CONTENT_NEWSOTHER where  propsStatus=1 and (expireDate is null or expireDate > GETDATE()) " & WnewType & " " & Where & ""
        sql &= " order by itemID desc"
        Return sql
    End Function

End Class



