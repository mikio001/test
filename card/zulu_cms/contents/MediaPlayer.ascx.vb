
Partial Class zulu_cms_contents_MediaPlayer
    Inherits Zulu.Cms.ReaderControl
 
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        MediaPlayerEditor1.ContentID = ContentID
        MediaPlayerEditor1.EditorID = "MEDIA"
        RegisterJquery()
    End Sub

    Protected Sub MediaPlayer_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles MediaPlayer.RenderHtml
        If String.IsNullOrEmpty(ContentID) Then Exit Sub

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        Dim dr = db.GetReader("select refUrl,title,contentBody,props from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        Dim errMsg As String = ""

        If db.IsError(errMsg) Then
            Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
        Else
            If dr.Read Then
                dr.Close()
                db.Execute("insert into ZCMS_CONTENT(contentID,refUrl,siteID,createBy,createDate,modifyBy,modifyDate,editorID,title,contentBody,props) values(@contentID,'',@siteID,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),'MEDIA','Untitled Media','Description...','1|320|240')", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))

                If db.IsError(errMsg) Then
                    Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
                    db.Close()
                    Exit Sub
                Else

                End If
            Else
                Dim sa = Split(dr.GetString(3), "|")

                If sa(0) = "1" Then
                    'video, audio
                    w.Write("<OBJECT id='mediaPlayer' width=""" & sa(1) & """ height=""" & sa(2) & """ ")
                    w.Write("classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95' ")
                    w.Write("codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701'")
                    w.Write("standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>")
                    w.Write("<param name='fileName' value=""" & dr.GetString(1) & """>")
                    w.Write("<param name='animationatStart' value='true'>")
                    w.Write("<param name='transparentatStart' value='true'>")
                    w.Write("<param name='autoStart' value=""true"">")
                    w.Write("<param name='showControls' value=""true"">")
                    w.Write("<param name='loop' value=""true"">")
                    w.Write("<EMBED type='application/x-mplayer2'")
                    w.Write("pluginspage='http://microsoft.com/windows/mediaplayer/en/download/'")
                    w.Write("id='mediaPlayer' name='mediaPlayer' displaysize='4' autosize='-1' ")
                    w.Write("bgcolor='darkblue' showcontrols=""true"" showtracker='-1' ")
                    w.Write("showdisplay='0' showstatusbar='-1' videoborder3d='-1' width=""" & sa(1) & """ height=""" & sa(2) & """")
                    w.Write("src=""" & dr.GetString(1) & """ autostart=""true"" designtimesp='5311' loop=""true"">")
                    w.Write("</EMBED>")
                    w.Write("</OBJECT>")
                Else
                    'flash, youtube
                    w.Write("<EMBED height=""" & sa(1) & """ type=application/x-shockwave-flash width=" & sa(2) & " src=""" & dr.GetString(1) & """></EMBED>")
                End If
            End If

            db.Close()
        End If
    End Sub
End Class