
Partial Class zulu_cms_editors_FileEditor
    Inherits Zulu.Cms.EditorControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback AndAlso Not IsPostBack Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
            Dim dr = db.GetReader("select refUrl,title,contentBody,props from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
            db.ThrowIfError()

            If dr.read Then
                FileSelector1.Text = dr.GetString(0)
                txtTitle.Text = dr.GetString(1)
                txtContentBody.HTML = dr.GetString(2)

                Dim sa = Split(dr.GetString(3), "|")
                playerType.Value = CInt(sa(0))
                playerWidth.Number = CInt(sa(1))
                playerHeight.Number = CInt(sa(2))
            End If

            dr.close()
            db.Close()
        End If

        With EditorContainer.SaveButton
            .Visible = True
            AddHandler .Click, AddressOf Save_Click
        End With
    End Sub

    Private Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Zulu.Cms.Factory.CheckEditPermission(ContentID) Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
            db.Execute("update ZCMS_CONTENT set refUrl=@refUrl,modifyBy=@username,modifyDate=GETDATE(),title=@title,contentBody=@contentBody,props=@props where contentID=@contentID and siteID=@siteID", db.NewParam("refUrl", FileSelector1.Text), db.NewParam("contentID", Request.QueryString("contentID")), db.NewParam("siteID", Zulu.Cms.Factory.SiteID), db.NewParam("username", Zulu.Security.Factory.UserProvider.GetCurrentUsername), db.NewParam("title", txtTitle.Text), db.NewParam("contentBody", txtContentBody.HTML), db.NewParam("props", playerType.Value & "|" & playerWidth.Number & "|" & playerHeight.Number))

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
