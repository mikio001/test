
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 8
    Public Property NewsReaderPageUrl As String = "~/ContentShow.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
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

        sql = "select  " & top & " itemID,title,modifyDate,refUrl,subtitle,imgURL from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID " & WnewType & " order by itemID desc"

        Dim dr = db.GetReader(sql, db.NewParam("contentID", ContentID), db.NewParam("siteID", FromSiteID))

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            Dim readPage = ResolveClientUrl(NewsReaderPageUrl)


            w.Write("  <div id='" & ContentID & "' class='tab-content'>")
            Dim i = 1
            Dim j = 1
            w.Write("<div id='tap" & j & "' class='tab-pane bounceIn in  active'>")
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
                    imgURL = "images/sample/blog1.jpg"
                End If


                w.Write(" <div class='blog-item well '>")
                w.Write("<a href='#'><h2>" & dr("title") & "</h2></a>")
                w.Write("<p><img src='" & imgURL & "' width='100%' alt='' /></p>")
                w.Write("<p>" & dr("subtitle") & "</p>")
                w.Write("<a class='btn btn-link' href=""" & refUrl & """>อ่านต่อ <i class='icon-angle-right'></i></a>")
                w.Write("</div>")
                                              

                If i Mod 2 = 0 Then
                    j += 1
                    w.Write("</div>")
                    w.Write("<div id='tap" & j & "' class='tab-pane bounceIn'>")
                End If
                i += 1
                'w.Write("<div class='col-md-4 col-sm-4'>")
                'w.Write("<div class='thumbnail'>")
                'w.Write("<div><img style='width:100%' src='" & imgURL & "' ></div>")
                'w.Write("<div style='font-size:14px;margin:10px'>" & dr.GetString(1))
                'w.Write("<span class='smallText'><div style='padding-left: 3px'><abbr title='attribute'>" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</abbr></div></span>")
                'w.Write("</div>")
                ''w.Write("<div>" & dr.GetString(4) & "</div>")
                'w.Write("<a class='btn btn-default' href=""" & refUrl & """>อ่านต่อ</a>")
                ''w.Write("<div class=""bs-callout bs-callout-warning""><a href=""" & refUrl & """ target=""" & Target & """>" & dr.GetString(1) & "</a> <span class=""smallText"">" & dr.GetDateTime(2).ToString("d MMM yyyy") & "</span></div>")
                'w.Write("</div>")
                'w.Write("</div>")
            End While
            If i Mod 2 = 0 Then w.Write("</div>")

            w.Write("<div class='gap'></div>")
            w.Write(" <div class='pagination'>")
            w.Write("  <ul class='nav nav-tabs' role='tablist'>  <li><a href='#mytap' data-slide='prev'><i class='icon-angle-left'></i></a></li>")

            For i = 1 To j
                w.Write("  <li " & IIf(i = 1, "class='active' ", "") & "><a href='#tap" & i & "' role='tab' data-toggle='tab'>" & i & "</a></li>")
            Next


                                                 

            w.Write("  <li><a href='#tap6' role='tab' data-toggle='tab'><i class='icon-angle-right'></i></a></li> </ul>")
            w.Write(" </div>")


            w.Write("</div>")

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