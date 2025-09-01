Imports DevExpress.XtraCharts
Imports Zulu.Data

Partial Class Main_Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Response.Redirect("../Coffee/")
    End Sub

    'Protected Sub ASPxGridView1_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles ASPxGridView1.CustomCallback
    '    Dim data = e.Parameters
    '    If e.Parameters <> "" Then
    '        Dim db = PlatformFactory.GetPlatform("MainDB", True, False)
    '        db.Execute("insert into MAS_CHAT (ChatMessage,CreateDate,CreateUser) VALUES  (@ChatMessage,getDate(),@CreateUser)",
    '                   db.NewParam("ChatMessage", e.Parameters),
    '                   db.NewParam("CreateUser", Session("username")))
    '        Dim err
    '        If db.IsError(err) Then
    '            MsgBox(err)
    '        End If
    '        ASPxGridView1.DataBind()
    '        db.Close()
    '    End If

    'End Sub
    Function getSession()

        If Session("username") Is Nothing Then
            Return "visibility:hidden"
        Else
            Return ""
        End If
    End Function

End Class


