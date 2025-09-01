
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 8
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NewFormNews"
    Public Property NewEditorNews As String = "NewEditorNews"
    Public Property NewsType As Integer = 0
    Public Property FromSiteID As String = Zulu.Cms.Factory.SiteID
    Public Property title As String = "ข่าวประชาสัมพันธ์"


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

        sql = "select  " & top & " itemID,title,modifyDate,refUrl,subtitle,imgURL,createBy,subtitle from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID " & WnewType & " order by itemID desc"

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", FromSiteID))

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)



            While dr.Read
                Dim refUrl, imgURL As String
                If Not dr.IsDBNull(3) AndAlso dr.GetString(3) <> "" Then
                    refUrl = dr.GetString(3)
                Else
                    refUrl = String.Format(readPage, dr.GetInt32(0)) & "&title=" & title
                End If
                If dr("imgURL").ToString <> "" Then
                    imgURL = dr("imgURL")
                Else
                    imgURL = "imges/blog2.jpg"
                End If
                w.Write("<div class='col-md-6 col-sm-6'>")
                w.Write("<div class='blog-item'>")
                w.Write("<img class='img-responsive img-blog' src='fileupload/" & imgURL & "' width='100%'>")
                w.Write(" <div class='blog-content'>")
                w.Write("<a href='" & refUrl & "'><h3>" & dr.GetString(1) & "</h3></a>")
                w.Write("<div class='entry-meta'>")
                w.Write("<span><i class='icon-user'></i> " & dr("createBy") & "</span>")
                w.Write("<span><i class='icon-calendar'></i>" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</span>")
                w.Write("</div>")
                w.Write("<p>" & dr("subtitle") & "</p>")
                w.Write("<a class='btn btn-default' href='" & refUrl & "'>อ่านต่อ <i class='icon-angle-right'></i></a>")
                'w.Write("<div class='col-md-6 col-sm-6'>")
                'w.Write("<div class='thumbnail'>")
                'w.Write("<div><img style='width:100%' src='" & imgURL & "' ></div>")
                'w.Write("<div style='font-size:14px;margin:10px'>" & dr.GetString(1))
                'w.Write("<span class='smallText'><div style='padding-left: 3px'><abbr title='attribute'>" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</abbr></div></span>")
                'w.Write("</div>")
                'w.Write("<a class='btn btn-default' href=""" & refUrl & """>อ่านต่อ</a>")
                'w.Write("</div>")
                'w.Write("</div>")
                w.Write("</div>")
                w.Write("</div>")
                w.Write("</div>")
            End While



            dr.Close()
        End If

        db.Close()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EndEditorToolbox1.ContentID = ContentID
        EndEditorToolbox1.EditorID = NewEditorNews
        EndEditorToolbox1.FormID = FormEditorID
        StartEditorToolbox1.ContentID = ContentID

    End Sub
End Class