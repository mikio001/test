
Partial Class V5_Tools_NewAppend_get_data
    Inherits System.Web.UI.Page
    Dim MaxNewsCount As Integer = 5
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewsType As Integer = 0
    Public Property NewSID As String = ""
    Dim ContentID = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Response.ExpiresAbsolute = DateTime.Now
        ' Response.Expires = -1441
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.AddHeader("cache-control", "no-cache")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoServerCaching()
        ContentID = Request.QueryString("ContentID")

        System.Threading.Thread.Sleep(100)
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
            Response.Write(errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
            Dim IDN = ""
            'If NewSID <> "" Then IDN = "ID='" & ContentID & "'"
            Response.Write("<ul id=" & ContentID & ">")

            While dr.Read
                Dim refUrl As String
                If Not dr.IsDBNull(3) AndAlso dr.GetString(3) <> "" Then
                    refUrl = dr.GetString(3)
                Else
                    refUrl = String.Format(readPage, dr.GetInt32(0))
                End If

                Response.Write("<li style='border-bottom:1px dotted #96F;vertical-align:middle;color:#66666;background-image: url('../resources/bullet.jpg');background-repeat: no-repeat; background-position: left 5px; padding-left: 14px;'><table style='width: 100%; height: 40px;' ><tr><td valign='middle'><img src='../resources/bullet.jpg' />&nbsp;&nbsp;<a href=""" & refUrl & """ target=""" & Target & """ >" & dr.GetString(1) & "</a> |" & dr.GetString(4) & "  " & dr.GetDateTime(2).ToString("d MMM yyyy") & "</td></tr></table></li>")
            End While

            Response.Write("</ul>")
            Response.Write(ContentID)
            dr.Close()
        End If
        db.Close()
    End Sub

    Function GetSQL(ByVal index As Integer, ByVal WnewType As String)
        Dim SiteKey As New NewsSite
        Dim sql = ""
        Dim top = ""
        '    Dim SiteURL = ""
        Dim Where = ""
        If MaxNewsCount > 0 Then
            top = " top " & MaxNewsCount & ""
        End If
        

        Dim Desp = ""
        For i As Integer = 1 To SiteKey.GetCount
            Dim vSiteID = SiteKey.GetSite(i)
            If Desp = "" Then Desp &= " Case  "
            If Where <> "" Then Where &= " or "
            Where &= " (ContentID='" & vSiteID(1) & "' and SiteID='" & vSiteID(0) & "') "
            Desp &= " when SiteID='" & vSiteID(0) & "' then '" & vSiteID(2) & "'"
            ' SiteURL &= " when SiteID='" & vSiteID(0) & "' then '" & vSiteID(3) & "'"
        Next
        If Where <> "" Then Where = " and (" & Where & ")" : Desp &= " else '' end "

        Dim wherenotin = ""
        Dim Page = CInt(Request.QueryString("Pid")) - 1

       

        sql = " select " & top & " itemID,title,modifyDate,refUrl,(" & Desp & ") as Description from ZCMS_CONTENT where  propsStatus=1 and (expireDate is null or expireDate > GETDATE()) " & WnewType & " " & Where & " "

        If Page <> 0 Then
            sql &= " and itemID not in  (select top " & Page * MaxNewsCount & " itemID from ZCMS_CONTENT where  propsStatus=1 and (expireDate is null or expireDate > GETDATE()) " & WnewType & " " & Where & " order by itemID desc) "
        End If

        sql &= " order by itemID desc"

        Return sql
    End Function
End Class
