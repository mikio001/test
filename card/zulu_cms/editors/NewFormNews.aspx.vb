
Partial Class zulu_cms_editors_NewEditer
    Inherits System.Web.UI.Page

    Private Const UploadDirectory As String = "~/FileUpload/"
    Dim Editor = "NewEditorNews"
    Public Function GetSiteID() As String
        Dim SSiteID = rqSiteID()
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Return SSiteID
    End Function
    Protected Function rqSiteID() As String
        Return HttpContext.Current.Request.QueryString.Item("siteID")
    End Function
    Protected Function ContentID() As String
        Return Request.QueryString("ContentID")
    End Function
    Function UploadFile(ByVal FU As Object) As String
        If (Not FU.HasFile) Then
            Return ""
        End If
        If FU.FileName = "" Then Return ""
        Dim fileInfo As New IO.FileInfo(FU.FileName)

        Dim filename = Replace(fileInfo.Name, fileInfo.Extension, "") & "_" & Now.Ticks & fileInfo.Extension
        Dim resFileName As String = MapPath(UploadDirectory) & filename
        FU.SaveAs(resFileName)
        Return UploadDirectory & filename
    End Function
    Private Sub Save_Click()
        Dim newsID = Request.QueryString("itemID")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, True)

        Dim filesavename = UploadFile(btnRefImg)
        Dim filesavename2 = UploadFile(btnRefUrl)

        Dim url = txtRefUrl.Text
        If filesavename2 <> "" Then
            url = filesavename2
        End If


        Dim urlImg = txtRefImg.Text
        If filesavename <> "" Then
            urlImg = filesavename
        End If

        If String.IsNullOrEmpty(newsID) Then
            db.Execute("insert into ZCMS_CONTENT(contentID,title,contentBody,createDate,createBy,modifyDate,modifyBy,siteID,editorID,status,refUrl,imgUrl,subTitle) values(@contentID,@title,@html,GETDATE(),@username,GETDATE(),@username,@siteID,'NEWS',0,@refUrl,@imgUrl,@subTitle)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("html", ASPxHtmlEditor1.Html), db.NewParam("username", Session("username")), db.NewParam("siteID", GetSiteID()), db.NewParam("refUrl", url), db.NewParam("imgUrl", urlImg), db.NewParam("subTitle", newsSubTitle.Value))


            'btnRefImg.Text = ""
            'btnRefUrl.Text = ""
            'btnRefImg.Value = ""
            'btnRefUrl.Value = ""
        Else


            db.Execute("update ZCMS_CONTENT set title=@title,contentBody=@html,createDate=GETDATE(),modifyDate=GETDATE(),modifyBy=@username,status=0,refUrl=@refUrl,imgUrl=@refImg,subTitle=@subTitle where itemID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("html", ASPxHtmlEditor1.Html), db.NewParam("username", Session("username")), db.NewParam("newsID", newsID), db.NewParam("refUrl", url), db.NewParam("subTitle", newsSubTitle.Value), db.NewParam("refImg", urlImg))
        End If

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            ShowErrorMsg(errMsg)
        Else
            newsTitle.Text = ""
            ASPxHtmlEditor1.Html = ""
            newsSubTitle.Value = ""
            btnSave.Visible = False
            ShowSuccessMsg("บันทึกข้อมูลเรียบร้อยแล้ว")
        End If

        db.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback AndAlso Not Page.IsPostBack Then
            Dim newsID = Request.QueryString("itemID")

            If Not String.IsNullOrEmpty(newsID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
                Dim dr = db.GetReader("select title,contentBody,expireDate,refUrl,imgUrl,subTitle,imgUrl2 from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", newsID))
                db.ThrowIfError()

                If dr.Read Then
                    newsTitle.Text = dr.GetString(0)
                    'newsExpireDate.Date = dr.GetDateTime(2)
                    If dr("subTitle").ToString <> "" Then newsSubTitle.Value = dr("subTitle")

                    If dr("refUrl").ToString <> "" Then
                        '    btnRefUrl.Value = dr.GetString(4)
                        txtRefUrl.Text = dr("refUrl") '"<a target='_blank' href='" & ResolveClientUrl(UploadDirectory & dr.GetString(4)) & "'>" &  & "<a>"
                    End If

                    If dr("imgUrl").ToString <> "" Then
                        '    btnRefImg.Value = dr.GetString(5)
                        txtRefImg.Text = dr("imgUrl") '"<a target='_blank' href='" & ResolveClientUrl(UploadDirectory & ) & "'>" & dr.GetString(5) & "<a>"
                    End If

                    ASPxHtmlEditor1.Html = dr("contentBody")
                 
                End If

                dr.Close()
                db.Close()
            End If
        End If

       
        With btnCancel
            Dim PageForm = HttpContext.Current.Request.QueryString.Item("FormSelect")
            If PageForm = "" Then
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl(("~/zulu_cms/editors/" & Editor & ".aspx?contentID=" & Me.ContentID)) & "&SiteID=" & GetSiteID() & "';}")
            Else
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl("~/" & PageForm) & ".aspx';}")
            End If
            '.ClientSideEvents.Click = GetShowEditorClientHandler("NewsEditor")
        End With
    End Sub

    Public Sub ShowErrorMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/error.gif") & """ align=""absmiddle"" />ERROR:" & errMsg
    End Sub

    Public Sub ShowSuccessMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/ok.gif") & """ align=""absmiddle"" />" & errMsg
    End Sub

    Protected Sub cbPanel_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanel.Callback
        If e.Parameter = "SAVE" Then
            Save_Click()
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save_Click()
    End Sub
End Class
