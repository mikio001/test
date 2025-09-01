
Partial Class zulu_cms_editors_CalendarEdit
    Inherits Zulu.Cms.EditorControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With

        With EditorContainer.CancelButton
            .ClientSideEvents.Click = GetShowEditorClientHandler("CalendarEditor")
        End With

        If Not IsPostBack Then
            Dim itemID = Request.QueryString("itemID")

            If Not String.IsNullOrEmpty(itemID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
                Dim dr = db.GetReader("select title,contentType,startDate,endDate,contentBody from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", itemID))
                db.ThrowIfError()

                If dr.Read Then
                    txtTitle.Text = dr.GetString(0)
                    cmbContentType.Value = dr.GetInt32(1)
                    deStart.Value = dr.GetDateTime(2)
                    deEnd.Value = dr.GetDateTime(3)
                    FckEditor1.HTML = dr.GetString(4)
                End If

                dr.Close()
                db.Close()
            End If
        End If
    End Sub

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim itemID = Request.QueryString("itemID")

        If Not String.IsNullOrEmpty(itemID) Then
            If Zulu.Cms.Factory.CheckEditPermission(ContentID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
                db.Execute("update ZCMS_CONTENT set title=@title,contentType=@contentType,startDate=@startDate,endDate=@endDate,contentBody=@contentBody,status=0,modifyDate=GETDATE(),modifyBy=@username where itemID=@itemID", db.NewParam("title", txtTitle.Text), db.NewParam("contentType", cmbContentType.Value), db.NewParam("startDate", deStart.Value), db.NewParam("endDate", deEnd.Value), db.NewParam("contentBody", FckEditor1.HTML), db.NewParam("itemID", itemID), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
                db.ThrowIfError()
                EditorContainer.ShowSuccessMsg("ทำการแก้ไขข้อมูลเรียบร้อยแล้ว")
            Else
                Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If
        Else
            If Zulu.Cms.Factory.CheckAddPermission(ContentID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
                db.Execute("insert into ZCMS_CONTENT(title,contentType,startDate,endDate,contentBody,status,contentID,siteID,createDate,createBy,modifyDate,modifyBy,editorID) values(@title,@contentType,@startDate,@endDate,@contentBody,0,@contentID,@siteID,GETDATE(),@username,GETDATE(),@username,'CALSLIDE')", db.NewParam("title", txtTitle.Text), db.NewParam("contentType", cmbContentType.Value), db.NewParam("startDate", deStart.Value), db.NewParam("endDate", deEnd.Value), db.NewParam("contentBody", FckEditor1.HTML), db.NewParam("contentID", ContentID), db.NewParam("siteID", SiteID), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername))
                db.ThrowIfError()
                EditorContainer.ShowSuccessMsg("ทำการแก้ไขข้อมูลเรียบร้อยแล้ว")

                txtTitle.Text = ""
                FckEditor1.HTML = ""
            Else
                Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If
        End If
    End Sub

End Class
