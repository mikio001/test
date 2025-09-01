
Partial Class zulu_cms_editors_HtmlEditor
    Inherits Zulu.Cms.EditorControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback AndAlso Not IsPostBack Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
            Dim dr = db.GetReader("select title,contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
            db.ThrowIfError()

            If dr.Read Then
                txtTitle.Text = dr.GetString(0)
                FckEditor1.HTML = dr.GetString(1)
            End If

            dr.Close()
            db.Close()
        End If

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With
    End Sub
 
    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim chkPermit As New CheckContentPermit

        If chkPermit.CheckEditPermission(ContentID) Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
            db.Execute("update ZCMS_CONTENT set contentBody=@contentBody,modifyBy=@username,modifyDate=GETDATE(),title=@title where contentID=@contentID and siteID=@siteID", db.NewParam("contentBody", FckEditor1.HTML), db.NewParam("contentID", Request.QueryString("contentID")), db.NewParam("siteID", Zulu.Cms.Factory.SiteID), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("title", txtTitle.Text))

            Dim errMsg As String = ""

            If db.IsError(errMsg) Then
                EditorContainer.ShowErrorMsg(errMsg)
            Else
                EditorContainer.CloseEditor()
            End If
        Else
            Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
        End If
    End Sub

End Class
