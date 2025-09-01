Imports Zulu.Cms

Partial Class zulu_cms_Editor
    Inherits System.Web.UI.Page
    'Inherits EditorContainer
    Dim ContentID = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ContentID = Request.QueryString("contentID").ToString
        If Not Page.IsCallback AndAlso Not IsPostBack Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
            Dim dr = db.GetReader("select title,contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
            db.ThrowIfError()

            If dr.Read Then
                txtTitle.Text = dr.GetString(0)
                ASPxHtmlEditor1.Html = dr.GetString(1)
            End If

            dr.Close()
            db.Close()
        End If


        btnSave.Visible = True
        AddHandler btnSave.Click, AddressOf Save_Click

    End Sub

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        ContentID = Request.QueryString("contentID").ToString
        If Zulu.Cms.Factory.IsEditMode Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)

            db.Execute("update ZCMS_CONTENT set contentBody=@contentBody,modifyBy=@username,modifyDate=GETDATE(),title=@title where contentID=@contentID and siteID=@siteID", db.NewParam("contentBody", ASPxHtmlEditor1.Html), db.NewParam("contentID", Request.QueryString("contentID")), db.NewParam("siteID", Zulu.Cms.Factory.SiteID), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("title", txtTitle.Text))

            Dim errMsg As String = ""

            If db.IsError(errMsg) Then
                ShowErrorMsg(errMsg)
            Else
                CloseEditor()
            End If
        Else
            Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
        End If
    End Sub
    Public Sub CloseEditor()
        ltMsg.Text = "<script type=""text/javascript"">zulu_cms_closeEditor();</script>"
    End Sub

    Public Sub ShowErrorMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/error.gif") & """ align=""absmiddle"" />ERROR:" & errMsg
    End Sub

    Public Sub ShowSuccessMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/ok.gif") & """ align=""absmiddle"" />" & errMsg
    End Sub
End Class