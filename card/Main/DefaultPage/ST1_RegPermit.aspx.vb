Imports System.Data

Partial Class Main_ST1_RegPermit
    Inherits System.Web.UI.Page

    'Protected Sub OnCustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)
    '    ' ASPxGridView2.Enabled = True

    '    Dim username = ASPxGridView1.GetSelectedFieldValues("username").Item(0)
    '    ASPxGridView2.Selection.UnselectAll()
    '    Dim db = Zulu.Data.PlatformFactory.GetPlatform("DCT", True, False)
    '    Dim dtb As DataTable = db.GetDataTable("select * from MIS_PERMISSION_FACULTY_REG where username=@username", db.NewParam("username", username))
    '    For i As Integer = 0 To ASPxGridView2.VisibleRowCount - 1
    '        Dim Faculty_PK = ASPxGridView2.GetRowValues(i, "Faculty_PK")
    '        Dim dtr = dtb.Select("Faculty_PK=" & Faculty_PK)
    '        If dtr.Length <> 0 Then
    '            ASPxGridView2.Selection.SetSelectionByKey(Faculty_PK, True)
    '        End If
    '    Next
    '    SubmitMessage.Text = ""



    '    db.Close()
    'End Sub
    'Protected Sub OnCustomCallbackERP(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)
    '    ' ASPxGridView2.Enabled = True

    '    Dim username = ASPxGridView1.GetSelectedFieldValues("username").Item(0)
    '    Dim db = Zulu.Data.PlatformFactory.GetPlatform("DCT", True, False)
    '    ASPxGridView3.Selection.UnselectAll()
    '    '  Dim db = Zulu.Data.PlatformFactory.GetPlatform("DCT", True, False)
    '    Dim dtb As DataTable = db.GetDataTable("select * from MIS_PERMISSION_FACULTY_ERP where username=@username", db.NewParam("username", username))
    '    For i As Integer = 0 To ASPxGridView3.VisibleRowCount - 1
    '        Dim Faculty_PK = ASPxGridView3.GetRowValues(i, "depID")
    '        Dim dtr = dtb.Select("depID=" & Faculty_PK)
    '        If dtr.Length <> 0 Then
    '            ASPxGridView3.Selection.SetSelectionByKey(Faculty_PK, True)
    '        End If
    '    Next
    '    SubmitMessage0.Text = ""

    '    db.Close()
    'End Sub

    'Protected Sub ASPxGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxGridView1.SelectionChanged

    'End Sub

    'Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxButton1.Click
    '    Dim username = ASPxGridView1.GetSelectedFieldValues("username").Item(0)
    '    Dim db = Zulu.Data.PlatformFactory.GetPlatform("DCT", True, False)
    '    db.Execute("delete from MIS_PERMISSION_FACULTY_REG where username=@username", db.NewParam("username", username))
    '    For i As Integer = 0 To ASPxGridView2.Selection.Count - 1
    '        Dim Faculty_PK = ASPxGridView2.GetSelectedFieldValues("Faculty_PK").Item(i)
    '        db.Execute("insert into MIS_PERMISSION_FACULTY_REG(username,Faculty_PK) VALUES (@username,@Faculty_PK)", db.NewParam("username", username), db.NewParam("Faculty_PK", Faculty_PK))
    '    Next
    '    SubmitMessage.Text = "* บันทึกข้อมูลเรียบร้อยแล้ว"
    '    db.Close()
    'End Sub

    'Protected Sub ASPxButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxButton3.Click
    '    Dim username = ASPxGridView1.GetSelectedFieldValues("username").Item(0)
    '    Dim db = Zulu.Data.PlatformFactory.GetPlatform("DCT", True, False)
    '    db.Execute("delete from MIS_PERMISSION_FACULTY_REG where username=@username", db.NewParam("username", username))
    '    For i As Integer = 0 To ASPxGridView3.Selection.Count - 1
    '        Dim Faculty_PK = ASPxGridView3.GetSelectedFieldValues("depID").Item(i)
    '        db.Execute("insert into MIS_PERMISSION_FACULTY_ERP(username,depID) VALUES (@username,@depID)", db.NewParam("username", username), db.NewParam("depID", Faculty_PK))
    '    Next
    '    SubmitMessage0.Text = "* บันทึกข้อมูลเรียบร้อยแล้ว"
    '    db.Close()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("security") <> "A" Then Response.Redirect("../DefaultPage/AccessDenied.aspx")
    End Sub

   
End Class
