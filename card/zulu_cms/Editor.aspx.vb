Imports Zulu.Cms

Partial Class zulu_cms_Editor
    Inherits EditorContainer

    Private Function LoadEditorControl() As Zulu.Cms.EditorControl
        If EditorPlaceHolder.Controls.Count = 0 Then
            Dim url = "~/zulu_cms/editors/" & Request.QueryString("editor") & ".ascx"
            Dim ec = LoadControl(url)
            EditorPlaceHolder.Controls.Add(ec)
            Return ec
        Else
            Return EditorPlaceHolder.Controls(0)
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadEditorControl()
    End Sub

   

    Public Overrides Sub CloseEditor()
        ltMsg.Text = "<script type=""text/javascript"">zulu_cms_closeEditor();</script>"
    End Sub

    Public Overrides Sub ShowErrorMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/error.gif") & """ align=""absmiddle"" />ERROR:" & errMsg
    End Sub

    Public Overrides Sub ShowSuccessMsg(ByVal errMsg As String)
        ltMsg.Text = "<img src=""" & ResolveClientUrl("~/zulu_web/images/ok.gif") & """ align=""absmiddle"" />" & errMsg
    End Sub

  
End Class