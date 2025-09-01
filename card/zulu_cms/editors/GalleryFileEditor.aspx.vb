
Partial Class zulu_cms_editors_NewEditer
    Inherits System.Web.UI.Page
    Private Function ContentID() As String
        Return Request.QueryString("ContentID")

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
            Dim CHK As New CheckContentPermit
            If Not CHK.CheckEditPermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
        End If

        SqlDataSource1.SelectParameters("contentID").DefaultValue = ContentID()
        SqlDataSource1.SelectParameters("siteID").DefaultValue = Zulu.Cms.Factory.SiteID
        SqlDataSource1.InsertParameters("contentID").DefaultValue = ContentID()
        SqlDataSource1.InsertParameters("siteID").DefaultValue = Zulu.Cms.Factory.SiteID

        Dim username = Zulu.Security.Factory.UserProvider.GetCurrentUsername
        SqlDataSource1.InsertParameters("modifyBy").DefaultValue = username
        SqlDataSource1.UpdateParameters("modifyBy").DefaultValue = username

        If Not Page.IsCallback Then
            '  EditorContainer.AppendButton.ClientSideEvents.Click = "function(s,e){ASPxGridView1.AddNewRow();}"
            '    Dim c = CType(ASPxGridView1.Columns("refUrl"), DevExpress.Web.GridViewDataButtonEditColumn)
            ' c.PropertiesButtonEdit.ClientInstanceName = "fileSelector"
            ' c.PropertiesButtonEdit.ClientSideEvents.ButtonClick = "function(s,e){zulu_showFileBrowser('" & ResolveClientUrl("~/") & "',fileSelector,1);}"

            If Not Page.ClientScript.IsClientScriptBlockRegistered("GFile") Then
                Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "GFile", "var ctrl=0;function GalleryFileBrowser(ctrl) {window.open('" & ResolveClientUrl("~/zulu_gallery/GalleryFileEditor.aspx") & "?ItemID='+ctrl, 'GalleryFile', 'width=800,height=500');}", True)
            End If
        End If



    End Sub

    Protected Sub ASPxGridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles ASPxGridView1.InitNewRow
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
        Dim o = db.GetValue("select max(orderNo) from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        db.Close()

        If IsDBNull(o) OrElse o Is Nothing Then
            e.NewValues("orderNo") = 1
        Else
            e.NewValues("orderNo") = CInt(o) + 1
        End If

        e.NewValues("contentType") = 1
    End Sub


End Class
