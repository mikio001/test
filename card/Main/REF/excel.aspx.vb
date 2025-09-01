
Imports System.IO
Imports Zen.Barcode
Imports Zulu.Data
Imports CrystalDecisions.Shared


Partial Class Main_REF_excel
    Inherits System.Web.UI.Page


    Function convertImage(ByVal FilePath)
        Dim fs As New FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim Image As Byte() = New Byte(fs.Length - 1) {}
        fs.Read(Image, 0, Convert.ToInt32(fs.Length))
        fs.Close()
        Return Image
    End Function
    Private Sub Main_REF_excel_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = Zulu.Data.PlatformFactory.GetPlatform("MainDB", True, False)
        Dim table = "EXPORT_RSH"
        Dim ID = Request.QueryString("id")
        ID = Replace(ID, "on", "")
        Dim dtb = db.GetDataTable("SELECT        dbo.Card_TB.Card_Num AS ลำดับ, dbo.Card_TB.Card_Name + N'  ' + dbo.Card_TB.Card_Surname AS [ชื่อ สกุล], dbo.Card_TB.CitizenID AS เลขบัตรประชาชน, dbo.Card_TYPE_TB.Card_TYPE_name AS ประเภทบุคคล, dbo.Card_TB.Card_Job AS บทบาทหน้าที่, dbo.Card_TB.Card_duty AS รายละเอียดหน้าที่, dbo.Card_TB.Card_FAC_Name AS หน่วยงาน, dbo.Card_TB.IMG_File_TEMP AS หมายเหตุ , 'https://doga.up.ac.th/card/Main/REF/img/' + dbo.Card_TB.Card_img AS imgurl FROM            dbo.Card_TB INNER JOIN dbo.Card_TYPE_TB ON dbo.Card_TB.Card_TYPE = dbo.Card_TYPE_TB.Card_TYPE  WHERE  Card_ID in  (" & ID & ")")

        Dim row As New TableRow()
        row.Cells.Add(New TableCell())

        'For i As Integer = 0 To dtb.Rows.Count - 1
        '    With dtb.Rows(i)
        '        row.Cells(0).Controls.Add(convertImage(Server.MapPath("img/" & .Item("Card_img"))))
        '    End With
        'Next
        'dtb.Rows.Add(row)

        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.Charset = "Windows-874"
        Response.ContentEncoding = System.Text.Encoding.UTF8
        Me.EnableViewState = False
        Response.AddHeader("content-disposition", "attachment;filename=ออกรายงานบัตร.xls")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim gv As GridView = New GridView()
        gv.DataSource = dtb
        gv.DataBind()
        gv.RenderControl(hw)
        Response.Output.Write(sw)
        Response.Flush()
        Response.End()

        db.Close()

    End Sub
End Class
