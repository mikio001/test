
Partial Class zulu_cms_editors_NewsAdd
    Inherits Zulu.Cms.EditorControl

    Public Function GetSiteID() As String
        Dim SSiteID = rqSiteID()
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
        Return SSiteID
    End Function
    Protected Function rqSiteID() As String
        Return HttpContext.Current.Request.QueryString.Item("siteID")
    End Function

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim newsID = Request.QueryString("itemID")
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, True)

        If String.IsNullOrEmpty(newsID) Then
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckAddPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If
            db.Execute("update ZCMS_CONTENT set orderNo=orderNo+1 where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
            db.Execute("update ZCMS_CONTENT set orderNo=99 where orderNo>99 and siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
            db.Execute("insert into ZCMS_CONTENT(contentID,title,contentBody,createDate,createBy,modifyDate,modifyBy,expireDate,siteID,editorID,contentType,status,refUrl,imgUrl,subTitle,orderNo,StrategicID) values(@contentID,@title,@html,GETDATE(),@username,GETDATE(),@username,@expireDate,@siteID,'NEWS',@contentType,0,@refUrl,@imgUrl,@subTitle,@orderNo,@StrategicID)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("expireDate", newsExpireDate.Date), db.NewParam("siteID", GetSiteID()), db.NewParam("contentType", cmbContentType.Value), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("imgUrl", btnRefImg.Text), db.NewParam("subTitle", newsSubTitle.Text), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("StrategicID", IIf(cmbSTRATEGIC.SelectedIndex = -1, DBNull.Value, cmbSTRATEGIC.Value)))

            newsTitle.Text = ""
            FckEditor1.HTML = ""
            newsSubTitle.Text = ""
            btnRefImg.Text = ""
            btnRefUrl.Text = ""
            btnRefImg.Value = ""
            btnRefUrl.Value = ""
        Else
            If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
                If Not Zulu.Cms.Factory.CheckEditPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If

            db.Execute("update ZCMS_CONTENT set title=@title,contentBody=@html,createDate=GETDATE(),modifyDate=GETDATE(),modifyBy=@username,expireDate=@expireDate,contentType=@contentType,status=0,refUrl=@refUrl,imgUrl=@refImg,subTitle=@subTitle,orderNo=@orderNo,StrategicID=@StrategicID where itemID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("expireDate", newsExpireDate.Date), db.NewParam("newsID", newsID), db.NewParam("contentType", cmbContentType.Value), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("subTitle", newsSubTitle.Text), db.NewParam("refImg", btnRefImg.Text), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("StrategicID", IIf(cmbSTRATEGIC.SelectedIndex = -1, DBNull.Value, cmbSTRATEGIC.Value)))
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

            If Not String.IsNullOrEmpty(newsID) Then
                Dim db = Zulu.Data.PlatformFactory.GetPlatform("ZuluDB", True, False)
                Dim dr = db.GetReader("select title,contentBody,expireDate,contentType,refUrl,imgUrl,subTitle,orderno,StrategicID from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", newsID))
                db.ThrowIfError()

                If dr.Read Then
                    newsTitle.Text = dr.GetString(0)
                    newsExpireDate.Date = dr.GetDateTime(2)
                    If Not dr.IsDBNull(6) Then newsSubTitle.Text = dr.GetString(6)

                    If Not dr.IsDBNull(4) Then
                        btnRefUrl.Value = dr.GetString(4)
                        btnRefUrl.Text = dr.GetString(4)
                    End If

                    If Not dr.IsDBNull(5) Then
                        btnRefImg.Value = dr.GetString(5)
                        btnRefImg.Text = dr.GetString(5)
                    End If

                    If Not dr.IsDBNull(7) Then seOrderNo.Value = dr.GetInt32(7)
                    FckEditor1.HTML = dr.GetString(1)
                    cmbSTRATEGIC.DataBind()
                    cmbContentType.DataBind()
                    SqlDataSource1.DataBind()
                    If Not dr.IsDBNull(3) Then cmbContentType.Value = dr.GetInt32(3)
                    If Not IsDBNull(dr("StrategicID")) Then cmbSTRATEGIC.Value = dr("StrategicID")
                End If

                dr.Close()
                db.Close()
            End If
        End If

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With

        With EditorContainer.CancelButton
            Dim PageForm = HttpContext.Current.Request.QueryString.Item("FormSelect")
            If PageForm = "" Then
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl(("~/zulu_cms/Editor.aspx?editor=NewCardEditor&contentID=" & Me.ContentID)) & "&SiteID=" & GetSiteID() & "';}")
            Else
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl("~/" & PageForm) & ".aspx';}")
            End If
            '.ClientSideEvents.Click = GetShowEditorClientHandler("NewsEditor")
        End With
    End Sub
End Class