
Partial Class zulu_cms_editors_NewEditer
    Inherits System.Web.UI.Page

    Public Function GetContentID() As String
        Return ContentID()
    End Function
    Public Function GetSiteID() As String
        Dim SSiteID = rqSiteID()
        If SSiteID = "" Then SSiteID = SiteID()
        Return SSiteID
    End Function
    Protected Function rqSiteID() As String
        Return HttpContext.Current.Request.QueryString.Item("siteID")
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource1.SelectParameters("contentID").DefaultValue = ContentID()
        Dim SSiteID = rqSiteID()
        If SSiteID = "" Then SSiteID = SiteID()
        SqlDataSource1.SelectParameters("siteID").DefaultValue = SSiteID
       
    End Sub

    Protected Sub ASPxGridView1_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles ASPxGridView1.RowDeleting
        If Not Page.IsPostBack AndAlso Not Page.IsCallback Then
            Dim CHK As New CheckContentPermit
            If Not CHK.CheckDeletePermission(ContentID, rqSiteID) Then Zulu.Web.Factory.GotoAppErrorPage("Access Denied!")
        End If
    End Sub

    Private Function SiteID() As String
        Return Request.QueryString("siteID")
    End Function

    Private Function GetShowEditorClientHandler(p1 As String) As Object
        Throw New NotImplementedException
    End Function

    Private Function ContentID() As String
        Return Request.QueryString("ContentID")

    End Function


End Class
