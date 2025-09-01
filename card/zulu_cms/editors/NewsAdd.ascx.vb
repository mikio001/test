
Partial Class zulu_cms_editors_NewsAdd
    Inherits Zulu.Cms.EditorControl

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim newsID = Request.QueryString("newsID")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, True)

        If String.IsNullOrEmpty(newsID) Then
            db.Execute("insert into ZCMS_NEWS(contentID,title,html,createDate,createBy,lastModifyDate,lastModifyBy,expireDate) values(@contentID,@title,@html,GETDATE(),@username,GETDATE(),@username,@expireDate)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("html", newsHtml.Html), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("expireDate", newsExpireDate.Date))
        Else
            db.Execute("update ZCMS_NEWS set title=@title,html=@html,createDate=GETDATE(),lastModifyDate=GETDATE(),lastModifyBy=@username,expireDate=@expireDate where newsID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("html", newsHtml.Html), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("expireDate", newsExpireDate.Date), db.NewParam("newsID", newsID))
        End If

        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            EditorContainer.ShowErrorMsg(errMsg)
        Else
            EditorContainer.ShowSuccessMsg("บันทึกข้อมูลเรียบร้อยแล้ว")
        End If

        db.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback AndAlso Not Page.IsPostBack Then
            Dim newsID = Request.QueryString("newsID")

            If Not String.IsNullOrEmpty(newsID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, False)
                Dim dr = db.GetReader("select title,html,expireDate from ZCMS_NEWS where newsID=@newsID", db.NewParam("newsID", newsID))
                db.ThrowIfError()

                If dr.Read Then
                    newsTitle.Text = dr.GetString(0)
                    newsExpireDate.Date = dr.GetDateTime(2)
                    newsHtml.Html = dr.GetString(1)
                End If

                dr.Close()
                db.Close()
            End If
        End If

        newsHtml.SettingsImageUpload.UploadImageFolder = Zulu.Cms.Factory.GetUserFolderVPath

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With

        With EditorContainer.CancelButton
            .ClientSideEvents.Click = GetShowEditorClientHandler("NewsEditor")
        End With
    End Sub
End Class