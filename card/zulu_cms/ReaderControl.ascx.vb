
Partial Class zulu_cms_ReaderControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim itemID = Request.QueryString("itemID")

        If String.IsNullOrEmpty(itemID) Then
            Throw New Exception("Invalid content's itemID!")
        Else
            Dim db = Zulu.Data.PlatformFactory.GetPlatform(Zulu.Web.Settings.ZuluDbConnectionName, True, False)
            Dim dr = db.GetReader("select editorID,contentID from ZCMS_CONTENT where itemID=@itemID", db.NewParam("itemID", itemID))
            db.ThrowIfError()

            If dr.Read() Then
                Dim cw = Zulu.Cms.Factory.GetContentWidget(dr.GetString(0))
                Dim ctrl = CType(LoadControl("~/zulu_cms/contents/" & cw.ReadPageName & ".ascx"), Zulu.Cms.ReaderControl)
                ctrl.ContentID = dr.GetString(1)
                Controls.Add(ctrl)
            End If

            dr.Close()
            db.Close()
        End If
    End Sub
End Class