
Partial Class zulu_cms_admin_Default
    Inherits System.Web.UI.Page
    Dim CHKSite As New CheckContentPermit
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource1.SelectParameters("siteID").DefaultValue = Zulu.Cms.Factory.SiteID
        SqlDataSource1.InsertParameters("siteID").DefaultValue = Zulu.Cms.Factory.SiteID
        SqlDataSource1.UpdateParameters("original_siteID").DefaultValue = Zulu.Cms.Factory.SiteID
        SqlDataSource1.DeleteParameters("original_siteID").DefaultValue = Zulu.Cms.Factory.SiteID

        If Page.IsCallback = False Then
            If Zulu.Security.Factory.RoleProvider.IsInRole("admins") = False And CHKSite.CheckAdminPermission = False Then
                Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
            End If
        End If

    End Sub

    Protected Sub memberGrid_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles memberGrid.InitNewRow
        e.NewValues("contentID") = "*"
        e.NewValues("canAdd") = "0"
        e.NewValues("canEdit") = "0"
        e.NewValues("canDelete") = "0"
        e.NewValues("canAdmin") = "0"
    End Sub

    Protected Sub memberGrid_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles memberGrid.RowDeleting
        'If Not Zulu.Cms.Factory.CheckAdminPermission Then
        '    e.Cancel = True
        '    Throw New Exception("Access denied!")
        'End If
    End Sub

    Protected Sub memberGrid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles memberGrid.RowInserting
        'If Not Zulu.Cms.Factory.CheckAdminPermission Then
        '    e.Cancel = True
        '    Throw New Exception("Access denied!")
        'End If
    End Sub

    Protected Sub memberGrid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles memberGrid.RowUpdating
        'If Not Zulu.Cms.Factory.CheckAdminPermission Then
        '    e.Cancel = True
        '    Throw New Exception("Access denied!")
        'End If
    End Sub
End Class