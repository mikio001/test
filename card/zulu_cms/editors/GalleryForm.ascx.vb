
Partial Class zulu_cms_editors_NewsAdd
    Inherits Zulu.Cms.EditorControl

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim newsID = Request.QueryString("itemID")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, True)

        If String.IsNullOrEmpty(newsExpireDate.Text) Then newsExpireDate.Value = Now.AddYears(10)

        If String.IsNullOrEmpty(newsID) Then
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckAddPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If

            db.Execute("insert into ZCMS_CONTENT(contentID,title,createDate,createBy,modifyDate,modifyBy,expireDate,siteID,editorID,contentType,status,orderNo,refUrl,imgUrl,contentBody,subtitle) values(@contentID,@title,GETDATE(),@username,GETDATE(),@username,@expireDate,@siteID,'CONTSLIDE',@contentType,0,@orderNo,@refUrl,@imgUrl,@contentBody,@subtitle)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("expireDate", newsExpireDate.Date), db.NewParam("siteID", Zulu.Cms.Factory.SiteID), db.NewParam("contentType", cmbContentType.Value), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("imgUrl", btnRefImg.Text), db.NewParam("subtitle", subtitle.Text), db.NewParam("contentBody", FckEditor1.HTML))

            newsTitle.Text = ""
            seOrderNo.Value = seOrderNo.Value + 1
            FckEditor1.HTML = ""
            btnRefImg.Text = ""
            btnRefUrl.Text = ""
            btnRefImg.Value = ""
            btnRefUrl.Value = ""
            subtitle.Text = ""
        Else
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckEditPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If

            db.Execute("update ZCMS_CONTENT set title=@title,subtitle=@subtitle,createDate=GETDATE(),modifyDate=GETDATE(),modifyBy=@username,expireDate=@expireDate,contentType=@contentType,status=0,orderNo=@orderNo,refUrl=@refUrl,imgUrl=@imgUrl,contentBody=@contentBody where itemID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("newsID", newsID), db.NewParam("contentType", cmbContentType.Value), db.NewParam("expireDate", newsExpireDate.Date), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("imgUrl", btnRefImg.Text), db.NewParam("contentBody", FckEditor1.HTML), db.NewParam("subtitle", subtitle.Text))
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
            Dim newsID = Request.QueryString("itemID")
            Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, False)

            If Not String.IsNullOrEmpty(newsID) Then
                Dim dr = db.GetReader("select title,contentBody,expireDate,contentType,orderNo,refUrl,subtitle,imgUrl,subtitle from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", newsID))
                db.ThrowIfError()

                If dr.Read Then

                    btnRefUrl.Value = dr.GetString(5)
                    btnRefUrl.Text = dr.GetString(5)
                    seOrderNo.Value = dr.GetInt32(4)
                    newsTitle.Text = dr.GetString(0)
                    newsExpireDate.Date = dr.GetDateTime(2)
                    If Not dr.IsDBNull(8) Then subtitle.Text = dr.GetString(8)
                    If Not dr.IsDBNull(7) Then btnRefImg.Value = dr.GetString(7)
                    If Not dr.IsDBNull(7) Then btnRefImg.Text = dr.GetString(7)
                    If Not dr.IsDBNull(1) Then FckEditor1.HTML = dr.GetString(1)
                    '  If Not dr.IsDBNull(6) Then newsSubTitle.Text = dr.GetString(6)

                    If Not dr.IsDBNull(3) Then cmbContentType.Value = dr.GetInt32(3)
                End If

                dr.Close()
            Else
                Dim tmp = db.GetValue("select max(orderNo) from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", SiteID))

                If IsDBNull(tmp) OrElse tmp Is Nothing Then
                    seOrderNo.Value = 1
                Else
                    seOrderNo.Value = CInt(tmp) + 1
                End If
            End If

            db.Close()
        End If

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With

        With EditorContainer.CancelButton
            .ClientSideEvents.Click = GetShowEditorClientHandler("GalleryEditor")
        End With
    End Sub
End Class