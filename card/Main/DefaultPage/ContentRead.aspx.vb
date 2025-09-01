
Partial Class Main_DefaultPage_ContentRead
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        HtmlContent1.ContentID = Request.QueryString("c")
    End Sub
End Class
