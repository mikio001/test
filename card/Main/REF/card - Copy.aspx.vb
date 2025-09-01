Imports DevExpress.Web
Imports System.Data
Imports System.IO

Partial Class Main_COFFEE_ManageTable
    Inherits System.Web.UI.Page

    Protected Sub ASPxGridView1_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles ASPxGridView1.RowValidating
        Dim grid As ASPxGridView = CType(sender, ASPxGridView)
        If e.NewValues("Barcode") <> "" Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
            Dim cnt = db.GetValue("select count(*) from REF_MATERIAL where Barcode=@Barcode and MaterialID<>@MaterialID", db.NewParam("MaterialID", e.NewValues("MaterialID")), db.NewParam("Barcode", e.NewValues("Barcode")))
            db.Close()
            If cnt > 0 Then
                AddError(e.Errors, grid.Columns("Barcode"), "เลขบาร์โค๊ดนี้ถูกใช้งานแล้ว")
            End If

        End If

    End Sub

    Private Sub AddError(ByVal errors As Dictionary(Of GridViewColumn, String), ByVal column As GridViewColumn, ByVal errorText As String)
        If errors.ContainsKey(column) Then
            Return
        End If
        errors(column) = errorText
    End Sub
    'Protected Sub PickList_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles ASPxGridView1.HtmlRowPrepared
    '    If e.RowType = GridViewRowType.Data Then
    '        If CInt(e.GetValue("item_status")) <> 1 Then
    '            e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f2dede")
    '        End If
    '    End If

    'End Sub
    Function getFile(ASSETID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        If db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.ITEM_TB WHERE (ID_ITEM = @ASSETID) AND (ReciveFile IS NOT NULL)", db.NewParam("ASSETID", ASSETID)) > 0 Then
            ret = "btn-success"
        Else
            ret = ""
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
            Dim reciveID = Now
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

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)

        If db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.ITEM_TB WHERE (ID_ITEM = @ID_ITEM) ", db.NewParam("ID_ITEM", txt_ID.Text)) > 0 Then
            db.Execute("update ITEM_TB set item_status = @item_status , detail = @detail , update_ITEM = getDate(),location = @location where ID_ITEM=@ID_ITEM", db.NewParam("ID_ITEM", txt_ID.Value), db.NewParam("location", txtlocation.Value), db.NewParam("item_status", cbbstatus.SelectedItem.Value), db.NewParam("detail", IIf(Memo1.Value <> "", Memo1.Value, "")))
        Else
            db.Execute("INSERT INTO ITEM_TB(ID_ITEM, item_status,detail,update_ITEM,location) VALUES (@ID_ITEM, @item_status,@detail,getDate(),@location)",
                                db.NewParam("ID_ITEM", txt_ID.Value),
                                db.NewParam("detail", IIf(Memo1.Value <> "", Memo1.Value, "")),
                                  db.NewParam("location", IIf(txtlocation.Value <> "", txtlocation.Value, "")),
                                db.NewParam("item_status", cbbstatus.SelectedItem.Value))
        End If

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

    Protected Sub cbck_Callback(sender As Object, e As CallbackEventArgsBase) Handles cbck.Callback
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)

        If db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.ITEM_TB WHERE (ID_ITEM = @ID_ITEM) ", db.NewParam("ID_ITEM", txt_ID.Text)) > 0 Then
            Dim ck = db.GetValue("SELECT ck FROM            dbo.ITEM_TB WHERE (ID_ITEM = @ID_ITEM)", db.NewParam("ID_ITEM", txt_ID.Value))
            If ck = "/" Then
                db.Execute("update ITEM_TB set ck = '-' where ID_ITEM=@ID_ITEM", db.NewParam("ID_ITEM", txt_ID.Value))
            ElseIf ck = "-" Then

                db.Execute("update ITEM_TB set ck = '/' where ID_ITEM=@ID_ITEM", db.NewParam("ID_ITEM", txt_ID.Value))
            Else
                db.Execute("update ITEM_TB set ck = '/' where ID_ITEM=@ID_ITEM", db.NewParam("ID_ITEM", txt_ID.Value))
            End If
        Else
            db.Execute("INSERT INTO ITEM_TB(ID_ITEM, item_status,update_ITEM,ck) VALUES (@ID_ITEM, 1,getDate(),'/')",
                                db.NewParam("ID_ITEM", txt_ID.Value))
        End If

        db.Close()


    End Sub
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




    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        ASPxGridViewExporter1.WriteXlsxToResponse("export")
    End Sub
End Class
