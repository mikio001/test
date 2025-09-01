
Partial Class zulu_cms_contents_SearchBox
    Inherits System.Web.UI.UserControl

    Public Property Width As String
    Public Property SearchResultPageUrl As String = "SearchResult.aspx?k="

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsCallback Then
            If Not String.IsNullOrEmpty(Width) Then searchBox.Width = Unit.Parse(Width)
            searchBox.ClientSideEvents.ButtonClick = "function(s,e){window.location='" & SearchResultPageUrl & "'+searchBox.GetText();}"
            searchBox.ClientSideEvents.KeyUp = "function(s,e){if(e.htmlEvent.keyCode==13){window.location='" & SearchResultPageUrl & "'+searchBox.GetText();}}"
        End If
    End Sub
End Class
