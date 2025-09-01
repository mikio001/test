Imports DevExpress.Web

Partial Class Main_COFFEE_ManageTable
    Inherits System.Web.UI.Page

    Protected Sub ASPxGridView1_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles ASPxGridView1.RowValidating
        Dim grid As ASPxGridView = CType(sender, ASPxGridView)
        If e.NewValues("Barcode") <> "" Then
            Dim db = Zulu.Data.PlatformFactory.GetPlatform("MAINDB", True, False)
            Dim cnt = db.GetValue("select count(*) from REF_Product where Barcode=@Barcode and ProductID<>@ProductID", db.NewParam("ProductID", e.NewValues("ProductID")), db.NewParam("Barcode", e.NewValues("Barcode")))
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
    Protected Sub PickList_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles ASPxGridView1.HtmlRowPrepared
        If e.RowType = GridViewRowType.Data Then
            If CInt(e.GetValue("BalanceVolumn")) < e.GetValue("MinVolumn") Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f2dede")
            End If
        End If




    End Sub
End Class
