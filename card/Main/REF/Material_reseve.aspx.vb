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
    '        If CInt(e.GetValue("BalanceVolumn")) < e.GetValue("MinVolumn") Then
    '            e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f2dede")
    '        End If
    '    End If




    'End Sub
    Function getFile(MaterialID)
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim ret = ""
        If db.GetValue("SELECT COUNT(*) AS Expr1 FROM dbo.REF_MATERIAL WHERE (MaterialID = @MaterialID) AND (ReciveFile = 'nophoto.jpg')", db.NewParam("MaterialID", MaterialID)) > 0 Then
            ret = ""
        Else
            ret = "btn-success"
        End If
        db.Close()
        Return ret
    End Function
    Protected Sub loadfile_Callback(sender As Object, e As CallbackEventArgsBase) Handles loadfile.Callback
        DataList2.DataBind()
    End Sub
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

            'upload the file onto the server                  
            Dim reciveID = Me.reciveID2.Text
            FileUpload1.SaveAs(Server.MapPath(Convert.ToString("~/Main/REF/img/") & txt_MaterialID.Value & fileEmp_Name))

            db.Execute("update REF_MATERIAL set ReciveFile = @ReciveFile where MaterialID=@MaterialID", db.NewParam("MaterialID", txt_MaterialID.Value), db.NewParam("ReciveFile", txt_MaterialID.Value & fileEmp_Name))

            ASPxGridView1.DataBind()
        End If
        db.Close()
    End Sub
End Class
