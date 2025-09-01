Partial Class zulu_cms_contents_MainMenu
    Inherits System.Web.UI.UserControl

    Protected Overrides Sub Render(ByVal w As System.Web.UI.HtmlTextWriter)
        w.Write("<table cellpadding=""0"" cellspacing=""0"" style=""margin: auto"">")
        w.Write("<tr>")

        Dim cNode = SiteMap.CurrentNode
        If cNode Is Nothing Then cNode = SiteMap.RootNode

        Dim rNode As SiteMapNode = cNode

        If rNode IsNot Nothing Then
            If rNode.ParentNode IsNot Nothing Then
                rNode = rNode.ParentNode             
            End If

            If rNode.ParentNode IsNot Nothing AndAlso rNode.ParentNode.ChildNodes.Count > 0 Then
                rNode = rNode.ParentNode
            End If

            Dim isFirst = True
            Dim cPage = Split(IO.Path.GetFileNameWithoutExtension(Request.Path), "_")(0)

            For Each n As SiteMapNode In rNode.ChildNodes
                If isFirst Then
                    isFirst = False
                Else
                    w.Write("<td class=""mainMenuSep""></td>")
                End If

                If n.Equals(cNode) Then
                    w.Write("<td id=""mainMenuActiveItem"">")
                    w.Write(n.Title)
                    w.Write("</td>")
                Else
                    Dim sa = IO.Path.GetFileNameWithoutExtension(Split(n.Url, "_")(0))

                    If sa = cPage Then
                        w.Write("<td id=""mainMenuActiveItem"">")
                        w.Write(n.Title)
                        w.Write("</td>")
                    Else
                        w.Write("<td onmouseover=""this.className='mainMenuHoverItem'"" onmouseout=""this.className='mainMenuItem'""")
                        w.Write("class=""mainMenuItem"">")
                        w.Write("<a href=""" & n.Url & """>" & n.Title & "</a>")
                        w.Write("</td>")
                    End If
                End If
            Next
        End If

        w.Write("</tr>")
        w.Write("</table>")
    End Sub
End Class