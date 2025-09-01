
Partial Class Main_Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
        Session.Abandon()
        Dim delCookie As HttpCookie
        delCookie = New HttpCookie("Authensecurity")
        delCookie.Expires = DateTime.Now.AddDays(-1D)
        Response.Cookies.Add(delCookie)
        Response.Redirect("../DefaultPage/default.aspx")
        Zulu.Cms.Factory.IsEditMode = False

    End Sub
End Class
