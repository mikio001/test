
Partial Class zulu_cms_EditorToolbox1
    Inherits System.Web.UI.UserControl

    Public Property EditorID As String
    Public Property FormID As String
    Public Property ContentID As String
    Public Property EditText As String = "แก้ไข"
    Public Property AddText As String = "เพิ่ม"

    Public Property CustomEditPage As String
    Public Property CustomAddPage As String
    Public Property SSiteID As String
    ' Dim CHK As New CheckContentPermit
    Protected Overrides Sub Render(ByVal w As System.Web.UI.HtmlTextWriter)
        ' If Session("EditMode") Then
        If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID

        If Zulu.Cms.Factory.IsEditMode Then
            '  If CHK.CheckAddPermission(ContentID, SSiteID) = True Or CHK.CheckEditPermission(ContentID, SSiteID) = True Then


            Dim Allowadd = True
            'If CustomEditPage = "" Then
            '    'Dim cw = Zulu.Cms.Factory.GetContentWidget(EditorID)
            '    'Allowadd = cw.AllowAddItem
            '    'CustomEditPage = cw.EditPageName
            '    'CustomAddPage = cw.AddPageName
            'End If

            Dim NewsString As String = ""

            w.Write("<div style='position:absolute;bottom:0px;right:0px;background-color: gainsboro;z-index:99999'>")
            Dim url = ResolveClientUrl("~/zulu_cms/editors/" & EditorID & ".aspx?SiteID=" & SSiteID & "&contentID=" & ContentID)
            w.Write("<a onclick='loadIframe(&#39;editFrame&#39;,&#39;" & url & "&#39;);$(&#39;#ModalEdit&#39;).modal(&#39;show&#39;)' >")
            w.Write("<img src=""")
            w.Write(ResolveClientUrl("~/zulu_web/images/edit.gif"))
            w.Write(""" border=""0"" align=""absmiddle"" />")
            w.Write(EditText)
            w.Write("</a>")

            If Allowadd Then
                w.Write("&nbsp;")
                w.Write("<a onclick='loadIframe(&#39;editFrame&#39;,&#39;" & url & "&#39;);$(&#39;#ModalEdit&#39;).modal(&#39;show&#39;)' >")
                w.Write("<img src=""")
                w.Write(ResolveClientUrl("~/zulu_web/images/add.gif"))
                w.Write(""" border=""0"" align=""absmiddle"" />")
                w.Write(AddText)
                w.Write("</a>: " & ContentID)
            End If

            w.Write("</div>")

            w.Write("</div></div>")
            ' w.Write(" : " & ContentID)
            'End If
        End If
        '  
        ' End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.ClientScript.IsClientScriptIncludeRegistered("zulu_cms") Then
            Page.ClientScript.RegisterClientScriptInclude("zulu_cms", ResolveClientUrl("~/zulu_cms/script.js"))
        End If
    End Sub
End Class
