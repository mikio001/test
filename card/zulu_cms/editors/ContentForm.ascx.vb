
Partial Class zulu_cms_editors_NewsAdd
    Inherits Zulu.Cms.EditorControl

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim newsID = Request.QueryString("itemID")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, True)

        If String.IsNullOrEmpty(newsID) Then
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckAddPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If

            db.Execute("insert into ZCMS_CONTENT(contentID,title,contentBody,createDate,createBy,modifyDate,modifyBy,siteID,editorID,status) values(@contentID,@title,@html,GETDATE(),@username,GETDATE(),@username,@siteID,'CONTENT',0)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
            newsTitle.Text = ""
            FckEditor1.HTML = ""
        Else
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckEditPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If

            db.Execute("update ZCMS_CONTENT set title=@title,contentBody=@html,createDate=GETDATE(),modifyDate=GETDATE(),modifyBy=@username,status=0,editorID='CONTENT' where itemID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("newsID", newsID))
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
                Dim dr = db.GetReader("select title,contentBody,expireDate,contentType,orderNo from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", newsID))
                db.ThrowIfError()

                If dr.Read Then
                    newsTitle.Text = dr.GetString(0)
                    FckEditor1.HTML = dr.GetString(1)
                End If

                dr.Close()
            Else
                Dim tmp = db.GetValue("select max(orderNo) from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", SiteID))

            End If

            db.Close()
        End If

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With

        With EditorContainer.CancelButton
            .ClientSideEvents.Click = GetShowEditorClientHandler("ContentEditor")
        End With
    End Sub
End Class