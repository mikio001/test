
Partial Class zulu_cms_StartEditorToolbox
    Inherits System.Web.UI.UserControl
    Public Property ContentID As String = ""
    Public Property ItemID As String = ""
    Public Property SSiteID As String = ""

    Protected Overrides Sub Render(ByVal w As System.Web.UI.HtmlTextWriter)
        ' Response.Write(Zulu.Cms.Factory.IsEditMode)
        Dim CHK As New CheckContentPermit

        If Zulu.Cms.Factory.IsEditMode Then
            If SSiteID = "" Then SSiteID = Zulu.Cms.Factory.SiteID
            If CHK.CheckAddPermission(ContentID, SSiteID) = True Or CHK.CheckEditPermission(ContentID, SSiteID) = True Then
                w.Write("<div class='editDiv' style='border-color: gainsboro;border-width: 1px;border-style: dashed;position: relative;'><div class='row'>")
            End If



        End If

    End Sub
End Class
