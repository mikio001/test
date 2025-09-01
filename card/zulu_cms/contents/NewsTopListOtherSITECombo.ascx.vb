
Partial Class zulu_cms_contents_NewsTopList
    Inherits Zulu.Cms.ReaderControl

    Public Property MaxNewsCount As Integer = 5
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewsType As Integer = 0
    Public Property NewsSite2 As Collection

    Dim NewsSite As New Collection

    Public Sub AddKeySite(ByVal _SiteID As String, ByVal _ContentID As String, ByVal _Description As String)
        ' New String() {Value(0), Value(1), Value(2)}
        NewsSite.Add(New String() {_SiteID, _ContentID, _Description})
        If Page.IsPostBack = False Then
            DropDownList1.Items.Add(_Description)
        End If


    End Sub
 


    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If DropDownList1.SelectedIndex = 0 Then
        '    For i As Integer = 1 To NewsSite.Count
        '        Dim a = NewsSite(i)
        '        NewsTopListOtherSITE1.AddKeySite(a(0), a(1), a(2))
        '    Next
        'Else
        '    Dim a = NewsSite(DropDownList1.SelectedIndex)
        '    NewsTopListOtherSITE1.AddKeySite(a(0), a(1), a(2))
        'End If
    End Sub
End Class



