Imports System.Data

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
            If seOrderNo.Value <> 0 Then
                Dim rc As Integer = db.GetValue("select count(*) from ZCMS_CONTENT where orderNO=@orderNO and @siteID=siteID and contentID=@contentID", db.NewParam("contentID", ContentID), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("siteID", GetSiteID()))
                If rc <> 0 Then
                    db.Execute("update ZCMS_CONTENT set orderNO=orderNO+1 where orderNO>=@orderNO and @siteID=siteID and contentID=@contentID", db.NewParam("contentID", ContentID), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("siteID", GetSiteID()))
                End If
            Else
                seOrderNo.Value = 999
            End If
            db.Execute("insert into ZCMS_CONTENT(contentID,title,contentBody,createDate,createBy,modifyDate,modifyBy,siteID,editorID,status,refUrl,imgUrl,subTitle,orderNo) values(@contentID,@title,@html,GETDATE(),@username,GETDATE(),@username,@siteID,'SERVICE',0,@refUrl,@imgUrl,@subTitle,@orderNo)", db.NewParam("contentID", ContentID), db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("siteID", GetSiteID()), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("imgUrl", btnRefImg.Text), db.NewParam("subTitle", newsSubTitle.Text), db.NewParam("orderNo", seOrderNo.Value))

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
            Dim rc As Integer = db.GetValue("select count(*) from ZCMS_CONTENT where orderNO=@orderNO and @siteID=siteID and contentID=@contentID", db.NewParam("contentID", ContentID), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("siteID", GetSiteID()))
            If rc <> 0 Then
                db.Execute("update ZCMS_CONTENT set orderNO=orderNO+1 where orderNO>=@orderNO and @siteID=siteID and contentID=@contentID", db.NewParam("contentID", ContentID), db.NewParam("orderNo", seOrderNo.Value), db.NewParam("siteID", GetSiteID()))
            End If
            db.Execute("update ZCMS_CONTENT set title=@title,contentBody=@html,createDate=GETDATE(),modifyDate=GETDATE(),modifyBy=@username,status=0,refUrl=@refUrl,imgUrl=@refImg,subTitle=@subTitle,orderNo=@orderNo where itemID=@newsID", db.NewParam("title", newsTitle.Text), db.NewParam("html", FckEditor1.HTML), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("newsID", newsID), db.NewParam("refUrl", btnRefUrl.Text), db.NewParam("subTitle", newsSubTitle.Text), db.NewParam("refImg", btnRefImg.Text), db.NewParam("orderNo", seOrderNo.Value))
        End If
        Dim dtb As DataTable = db.GetDataTable("select itemID from ZCMS_CONTENT where @siteID=siteID and contentID=@contentID order by orderNO", db.NewParam("contentID", ContentID), db.NewParam("siteID", GetSiteID()))
        Dim i = 0
        For Each dr As DataRow In dtb.Rows
            db.Execute("update ZCMS_CONTENT set orderNO=@orderNO where @itemID=itemID ", db.NewParam("orderNO", i), db.NewParam("itemID", dr(0)))
            i += 1
        Next
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
                Dim dr = db.GetReader("select title,contentBody,expireDate,contentType,refUrl,imgUrl,subTitle,orderno from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", newsID))
                db.ThrowIfError()

                If dr.Read Then
                    newsTitle.Text = dr.GetString(0)

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
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl(("~/zulu_cms/Editor.aspx?editor=MixContent/ServiceEditor&contentID=" & Me.ContentID)) & "&SiteID=" & GetSiteID() & "';}")
            Else
                .ClientSideEvents.Click = ("function(s,e){window.location='" & Me.ResolveClientUrl("~/MixContent/" & PageForm) & ".aspx';}")
            End If
            '.ClientSideEvents.Click = GetShowEditorClientHandler("NewsEditor")
        End With
    End Sub
End Class