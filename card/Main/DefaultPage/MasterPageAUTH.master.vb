
Partial Class Main_MasterPageAUTH
    Inherits System.Web.UI.MasterPage



    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim ax = Session("username")
        ' Session("SessionKey") = ""
        ' Session("security") = "U"

        If Not Page.IsCallback Then
            If Session("security") Is Nothing Then
                '  Response.Write("ERROR 01")
                'Dim cp As DevExpress.Web.ASPxCallbackPanel = CType(sender, DevExpress.Web.ASPxCallbackPanel)
                Dim u As String = "../defaultpage/default.aspx?u=" & Request.ServerVariables("URL") 'Request.QueryString("u")
                DevExpress.Web.ASPxWebControl.RedirectOnCallback(u)
                'If Not String.IsNullOrEmpty(u) Then
                '    cp.JSProperties("cpRedirectUrl") = ResolveClientUrl(Server.UrlDecode(u))
                'End If
                Response.Redirect("../defaultpage/default.aspx?u=" & Request.ServerVariables("URL"))


            End If
        End If

        'Dim str() As String = Split(Session("security"), ",")
        If Not Session("security").Contains("A") Then
            Dim a = Request.ServerVariables("URL")
            InStr(a.ToLower, "main")
            Dim b = Mid(a, InStr(a.ToLower, "main") + 5, a.Length - InStr(a.ToLower, "main") - 5).ToLower
            Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
            Dim dr = db.GetValue("select top 1 AllowShow from MY_MENU where MenuURL like '%" & b & "%'")
            If Not IsNothing(dr) Then
                Dim str() As String = Split(dr, ",")
                If Not str.Contains(Session("security")) Then
                    ' Response.Write(Session("security") & ":" & dr)

                    ' Dim cp As DevExpress.Web.ASPxCallbackPanel = CType(sender, DevExpress.Web.ASPxCallbackPanel)
                    Dim u As String = Request.QueryString("u")

                    If Not String.IsNullOrEmpty(u) Then
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(ResolveClientUrl(Server.UrlDecode(u)))
                        '  cp.JSProperties("cpRedirectUrl") = ResolveClientUrl(Server.UrlDecode(u))
                    Else
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback("../defaultpage/AccessDenied.aspx")
                        ' cp.JSProperties("cpRedirectUrl") = "../defaultpage/AccessDenied.aspx"
                    End If
                    Response.Redirect("../defaultpage/AccessDenied.aspx")

                End If
            End If
        End If
        'Session("SessionKey") = AuthenResult
        'Session("username") = Zulu.Security.Factory.UserProvider.GetCurrentUsername
    End Sub
End Class

