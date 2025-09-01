Partial Class zulu_cms_contents_SubMenu
    Inherits System.Web.UI.UserControl

    Protected Overrides Sub Render(ByVal w As System.Web.UI.HtmlTextWriter)
        w.Write("<table cellpadding=""0"" cellspacing=""0"">")
        w.Write("<tr>")

        Dim cNode = SiteMap.CurrentNode
        Dim rNode As SiteMapNode = Nothing

        If cNode IsNot Nothing Then
            If cNode.ParentNode IsNot Nothing Then
                rNode = cNode.ParentNode
                Dim isFirst = True

                For Each n As SiteMapNode In rNode.ChildNodes
                    If isFirst Then
                        isFirst = False
                    Else
                        w.Write("<td class=""mainMenuSep""></td>")
                    End If

                    If n.Equals(cNode) Then
                        w.Write("<td id=""subMenuActiveItem"">")
                        w.Write(n.Title)
                        w.Write("</td>")
                    Else
                        w.Write("<td onmouseover=""this.className='subMenuHoverItem'"" onmouseout=""this.className='subMenuItem'""")
                        w.Write("class=""subMenuItem"">")
                        w.Write("<a href=""" & n.Url & """>" & n.Title & "</a>")
                        w.Write("</td>")
                    End If
                Next
            End If
        End If

        w.Write("</tr>")
        w.Write("</table>")
    End Sub
End Class