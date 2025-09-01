
Partial Class zulu_cms_editors_CalendarEditor
    Inherits Zulu.Cms.EditorControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource1.SelectParameters("contentID").DefaultValue = ContentID()
        SqlDataSource1.SelectParameters("siteID").DefaultValue = Zulu.Cms.Factory.SiteID

        With EditorContainer.AppendButton
            .Visible = True
            .AutoPostBack = False
            .ClientSideEvents.Click = GetShowEditorClientHandler("CalendarForm")
        End With
    End Sub

    Protected Sub ASPxGridView1_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles ASPxGridView1.RowDeleting
        If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
            If Not Zulu.Cms.Factory.CheckDeletePermission(ContentID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
        End If
    End Sub
End Class
