
Partial Class zulu_cms_contents_HtmlContent
    Inherits Zulu.Cms.ReaderControl
    Public Property MaxNewsCount As Integer = 5
    Public Property NewsReaderPageUrl As String = "~/News_Read.aspx?itemID={0}"
    Public Property Target As String = "_self"
    Public Property FormEditorID As String = "NEWS"
    Public Property NewsType As Integer = 0
    Public Property NewSID As String = ""

    Protected Sub DirectRender1_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles AJAX_News_Other.RenderHtml
        If String.IsNullOrEmpty(ContentID) Then
            ContentID = "NewsOtherSite"
        End If
        w.Write("<div id='Contentdata_" & ContentID & "'></div>")
        w.Write("<p id='loader_" & ContentID & "' align='center'><img src='v5/Tools/NewAppend/GsNJNwuI-UM.gif' /></p>")



        w.Write("<script>")
        w.Write("jQuery.ajaxSetup({")
        w.Write("beforeSend: function () {")
        w.Write("$('#loader_" & ContentID & "').slideToggle();")
        w.Write("$('#loadother_" & ContentID & "').hide();")
        w.Write("},")
        w.Write("complete: function () {")
        w.Write("$('#loader_" & ContentID & "').slideToggle();")
        w.Write("$('#loadother_" & ContentID & "').show();")
        w.Write("},")
        w.Write("success: function () { }")
        w.Write("});")

        ' Hide Loader'


        w.Write("$('#loader_" & ContentID & "').slideToggle();")

        w.Write("var " & ContentID & "PID=0;")
        w.Write("  function example_append() {")
        w.Write("" & ContentID & "PID+=1;")
        w.Write("$.get('" & ResolveClientUrl("get_data.aspx") & "', { ContentID: '" & ContentID & "',Pid:" & ContentID & "PID }, function (data) {")
        w.Write("var new_div = $(data).hide();")
        w.Write("$('#Contentdata_" & ContentID & "').append(new_div);")
        'w.Write("new_div.fadeIn('slow');")
        w.Write("new_div.fadeIn('slow').slideDown();")
        'w.Write("alert(data);")
        w.Write("}, 'text'")
        w.Write(");")
        w.Write("}")
        w.Write("example_append();")
        w.Write("</script>")

        w.Write("<div id='loadother_" & ContentID & "'  style='text-align:center;background-color:#C6C6C6; padding:5px; border:1px solid #aaa;' ><a  onclick='example_append()'>ข่าวที่เก่ากว่า</a></div>")
        'If String.IsNullOrEmpty(ContentID) Then Exit Sub

        'Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        'Dim dr = db.GetReader("select contentBody from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        'Dim errMsg As String = ""

        'If Not db.IsError(errMsg) Then
        '    If dr.Read Then
        '        w.Write(dr.GetString(0))
        '        dr.Close()
        '        db.Close()
        '        Exit Sub
        '    Else
        '        dr.Close()
        '        db.Execute("insert into ZCMS_CONTENT(contentID,contentBody,siteID,title,createBy,createDate,modifyBy,modifyDate,editorID) values(@contentID,'HTML CONTENT',@siteID,'Untitled Page','SYSTEM',GETDATE(),'SYSTEM',GETDATE(),'HTML')", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        '        db.Close()
        '        w.Write("HTML CONTENT")
        '        If Not db.IsError(errMsg) Then Exit Sub
        '    End If
        'End If

        'Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
    End Sub
 
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        
    End Sub
End Class
