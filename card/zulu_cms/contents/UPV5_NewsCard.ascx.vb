Imports System.IO
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Partial Class zulu_cms_contents_NewsCard
    Inherits Zulu.Cms.ReaderControl
    Public Property NewsReaderPageUrl As String = "~/News_hot.aspx?itemID={0}"
    Public Property MaxNewsCount As Integer = 4
    Public Property SlideMode As String = ""
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender




        'RegisterScriptInclude("CONTSLIDEslide-news", "~/zulu_cms/contents/slide-news/jquery.bxSlider/jquery.bxSlider.min.js")
        'RegisterStyleSheet("CONTSLIDECSSslide-news", "~/zulu_cms/contents/slide-news/jquery.bxSlider/bx_styles/bx_styles.css")
        RegisterStyleSheet("facebookStyle", "~/zulu_cms/contents/prettyPhoto/css/FaceBookStyle.css")
        GalleryEnd.ContentID = ContentID
        GalleryEnd.EditorID = "NEWS"
        GalleryStart.ContentID = ContentID

    End Sub

    Protected Sub Gallery_RenderHtml(ByVal w As System.Web.UI.HtmlTextWriter, ByVal dItem As Object) Handles Gallery.RenderHtml

        'CreateTrumbnel PICNEW
        Dim UploadDirectory As String = "~/temp_thumbnail/"
        Dim DirInfo As New DirectoryInfo(Server.MapPath(UploadDirectory))
        '*** Create Folder ***'
        If Not DirInfo.Exists Then
            DirInfo.Create()
        End If


        Dim MAXNEW = ""
        If MaxNewsCount > 0 Then
            MAXNEW = " top " & MaxNewsCount
        End If
        Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
        'db.Execute("update ZCMS_CONTENT set orderNo=99 where orderNo is null and  siteID=@siteID and contentID=@contentID and expireDate >= GETDATE()", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim dtb As DataTable = db.GetDataTable("select " & MAXNEW & " itemID,title,subtitle,contentBody,refUrl,imgUrl,modifyDate from ZCMS_CONTENT where siteID=@siteID and contentID=@contentID and expireDate >= GETDATE() order by orderNo,itemID desc", db.NewParam("siteID", SiteID), db.NewParam("contentID", ContentID))
        Dim refUrl, title, subtitle, refImg As String
        db.ThrowIfError()
        Dim i = 1
        Dim readPage = ResolveClientUrl(NewsReaderPageUrl)
        w.Write("<ul id='" & ContentID & "'> ")
        Dim cnt As Integer = 0
        For Each dr As DataRow In dtb.Rows

            cnt += 1
            title = dr(1)
            If Not IsDBNull(dr(2)) Then subtitle = dr(2)


            If Not IsDBNull(dr(5)) AndAlso dr(5) <> "" Then
                refImg = dr(5)
            Else
                refImg = ResolveClientUrl("~/themes/icon_up3.jpg")
            End If
            If Not IsDBNull(dr(4)) AndAlso dr(4) <> "" Then
                refUrl = dr(4)
            Else
                refUrl = String.Format(readPage, dr(0))
            End If

            If subtitle.Length > 140 Then subtitle = subtitle.Substring(0, 140)

            Dim FileID = ""
            Dim sp = refImg.Split("=")
            If sp.Length = 2 Then
                FileID = sp(1)
                Dim FileIn As New FileInfo(Server.MapPath(UploadDirectory & FileID & ".jpg"))
                If Not FileIn.Exists Then
                    Dim resFileNameT As String = MapPath(UploadDirectory) & FileID
                    Dim drs = db.GetReader("select fileName,storePath from ZSTORE_ITEM left join ZSTORE_STORAGE on ZSTORE_ITEM.storeID=ZSTORE_STORAGE.storeID where fileID=@fileID", db.NewParam("fileID", FileID))
                    If drs.Read Then
                        Dim fileURL = drs(1) & "\" & FileID & "_" & drs(0)
                        Dim FileInserver As New FileInfo(fileURL)
                        If FileInserver.Exists Then
                            Using original As Image = Image.FromFile(fileURL)
                                Dim ext As String = Path.GetExtension(fileURL).ToLowerInvariant()
                                Using thumbnail As Image = PhotoUtils.Inscribe(original, 120, 80)
                                    PhotoUtils.SaveToJpeg(thumbnail, Server.MapPath(UploadDirectory) & FileID & ext)
                                End Using
                            End Using
                        End If
                    End If
                    drs.Close()

                End If
                If FileIn.Exists Then
                    refImg = UploadDirectory.Replace("~/", "../") & FileID & ".jpg"
                End If
            End If



            w.Write("  <li style='width:280px; height:90px; display:block; border:0px solid #ccc;float:left;'><table ><tr><td style='padding-left:10px;'> " &
                  "      <img style='border:1px solid #666;	width:120px;	height:80px;float:left; text-aligh:left;	margin-right:10px;margin-left:10px;' src='" & refImg & "'  /></td><td style='padding-right:10px;'><a  " &
                  "          href='" & refUrl & "'>" & title & " </a></td></tr></table> " &
                  "     </li> ")


        Next
        If cnt = 0 Then
            w.Write("<li></li>")
        End If
        w.Write("  </ul>")


        db.Close()




    End Sub
End Class
