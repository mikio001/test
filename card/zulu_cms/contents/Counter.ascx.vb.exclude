
Partial Class zulu_cms_contents_Counter
    Inherits Zulu.Cms.ReaderControl

    Dim Since As Date

    Protected Sub DirectRender1_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles HtmlContent.RenderHtml
        If String.IsNullOrEmpty(ContentID) Then Exit Sub

        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, True)
        Dim dr = db.GetReader("select title,createDate from ZCMS_CONTENT where contentID=@contentID and siteID=@siteID", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
        Dim errMsg As String = ""

        If Not db.IsError(errMsg) Then
            If dr.Read Then
                If Session(ContentID & "CounterLock") Is Nothing Then
                    Since = dr.GetDateTime(1)
                    Dim newCounter = CInt(dr.GetString(0)) + 1
                    dr.Close()

                    db.Execute("update ZCMS_CONTENT set title='" & newCounter & "',modifyDate=getDate() where contentID='" & ContentID & "' and siteID='" & Zulu.Cms.Factory.SiteID & "'")
                    db.ThrowIfError()
                    Dim counter As String = Application(ContentID)
                    writeValue(getImage(newCounter), w, Since)
                    Session(ContentID & "CounterLock") = True

                    Exit Sub
                Else
                    Since = dr.GetDateTime(1)
                    writeValue(getImage(CInt(dr.GetString(0))), w, Since)
                    'dr.Close()
                End If
            Else
                db.Execute("insert into ZCMS_CONTENT(contentID,siteID,title,createBy,createDate,modifyBy,modifyDate,editorID) values(@contentID,@siteID,'1','SYSTEM',GETDATE(),'SYSTEM',GETDATE(),'COUNTER')", db.NewParam("contentID", ContentID), db.NewParam("siteID", Zulu.Cms.Factory.SiteID))
                Since = Now
                writeValue(getImage(1), w, Now)
                Session(ContentID & "CounterLock") = True
                If Not db.IsError(errMsg) Then Exit Sub
            End If
        End If

        'db.Close()

        'Zulu.Cms.Factory.WriteErrorMsg(w, errMsg)
    End Sub
    Function getImage(ByVal counter As Int64) As String
        Dim cou As String = counter.ToString
        Dim str = ""
        For i As Integer = cou.Length To 7
            cou = "0" & cou
        Next
        For i As Integer = 0 To cou.Length - 1
            Dim b = cou.Substring(i, 1)
            str &= "<img src='" & ResolveClientUrl("Counter/" & b & ".gif'") & " />"
        Next
        Return str
    End Function
    Sub writeValue(ByVal value As String, ByVal w As Object, ByVal sin As Date)
        w.write("<div style='text-align:center;font-size:9px;'>")
        'w.write("You're visitor number<br>")
        w.write(value & "<br>")
        w.Write("Since " & sin.ToString("d MMMM yyyy"))
        w.write("</div>")
    End Sub

End Class
