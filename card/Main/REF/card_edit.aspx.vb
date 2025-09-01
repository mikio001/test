
Imports System.IO
Imports DevExpress.Web

Partial Class Main_REF_Default2
    Inherits System.Web.UI.Page




    Function getCard_TYPE(Card_TYPE)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""

        If Card_TYPE = 1 Then
            ret = "<a style='font-size: 16px; font-weight: bolder; color: #c73cc4'> บัตรสีชมพู(บุคคลชั้นในสุด)" & "</a>"

        ElseIf Card_TYPE = 2 Then
            ret = "<a style='font-size: 16px; font-weight: bolder; color: #f80909'> บัตรสีแดง(บุคคลชั้นในสุด)" & "</a>"

        ElseIf Card_TYPE = 3 Then
            ret = "<a style='font-size: 16px; font-weight: bolder; color: #fff405'> บัตรสีเหลือง(บุคคลชั้นกลาง)" & "</a>"

        End If
        db.Close()
        Return ret
    End Function



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)



        If FileUpload1.HasFile Then
            Dim fileEmp_Name As String = FileUpload1.FileName
            Dim exten As String = Path.GetExtension(fileEmp_Name)
            'here we have to restrict file type           
            exten = exten.ToLower()
            Dim acceptedFileTypes As String() = New String(3) {}
            acceptedFileTypes(0) = ".jpg"
            acceptedFileTypes(1) = ".jpeg"
            acceptedFileTypes(2) = ".gif"
            acceptedFileTypes(3) = ".png"
            'acceptedFileTypes(4) = ".rar"
            'acceptedFileTypes(5) = ".pdf"
            Dim acceptFile As Boolean = False
            For i As Integer = 0 To 3
                If exten = acceptedFileTypes(i) Then
                    acceptFile = True
                End If
            Next
            Dim rnd As New Random
            Dim x As Integer
            x = rnd.Next
            'upload the file onto the server                  
            Dim reciveID = Me.reciveID2.Text
            FileUpload1.SaveAs(Server.MapPath(Convert.ToString("~/Main/REF/img/") & x & fileEmp_Name))

            db.Execute("update Card_TB set Card_img = @Card_img where Card_ID = @Card_ID ", db.NewParam("Card_ID", txt_ID.Value), db.NewParam("Card_img", x & fileEmp_Name))

        End If
        db.Close()
        ASPxGridView1.DataBind()
    End Sub
    Protected Sub loadfile_Callback(sender As Object, e As CallbackEventArgsBase) Handles loadfile.Callback


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)

        db.Execute("update ITEM_TB set ReciveFile = 'nophoto.jpg' where ID_ITEM=@ID_ITEM", db.NewParam("ID_ITEM", txt_ID.Value))

        db.Close()
        ASPxGridView1.DataBind()
    End Sub


    Function getstatus(ASSETID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        If db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.ITEM_TB WHERE (ID_ITEM = @ID_ITEM) ", db.NewParam("ID_ITEM", ASSETID)) > 0 Then

            Dim statusname As String
            statusname = db.GetValue("SELECT dbo.item_statusTB.item_status_name, dbo.ITEM_TB.ID_ITEM FROM dbo.ITEM_TB INNER JOIN dbo.item_statusTB ON dbo.ITEM_TB.item_status = dbo.item_statusTB.item_status WHERE (dbo.ITEM_TB.ID_ITEM = @ID_ITEM)", db.NewParam("ID_ITEM", ASSETID))
            ret = statusname
        Else
            ret = "ยังไม่ได้ดำเนินการ"
        End If
        db.Close()
        Return ret
    End Function

    'Protected Sub bntprint_Click(sender As Object, e As EventArgs) Handles bntprint.Click
    '    Dim destinationURL = "type=" + ASPxComboBox1.SelectedItem.Value
    '    Dim returnUrl = HttpContext.Current.Server.UrlEncode(destinationURL)
    '    Response.Redirect("Print/print_item1.aspx?" + destinationURL)
    'End Sub


    Function ckicon(ASSETID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        Dim ck = db.GetValue("SELECT ck FROM dbo.View_ASSET WHERE (ASSETID = @ASSETID)", db.NewParam("ASSETID", ASSETID))

        If ck = "/" Then
            ret = "glyphicon glyphicon-ok"
        Else
            ret = "glyphicon glyphicon-minus"
        End If



        db.Close()
        Return ret
    End Function

    Protected Sub ASPxGridView1_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles ASPxGridView1.CustomCallback
        ASPxGridView1.DataBind()
    End Sub
End Class
